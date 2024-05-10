using DomainEntities;
using DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Attributes;
using WebApplication.Models.Player;
using WebApplication.Managers;

namespace WebApplication.Controllers
{
    public class PlayerController : Controller
    {
        #region Fields

        private readonly UserService _userService;
        private readonly PlayerService _playerService;
        private readonly RoleService _roleService;
        private readonly MailManager _mailManager;

        #endregion

        #region Constructors

        public PlayerController(UserService userService, PlayerService playerService, RoleService roleService, MailManager mailManager)
        {
            this._userService = userService;
            this._playerService = playerService;
            this._roleService = roleService;
            this._mailManager = mailManager;
        }

        #endregion

        #region Methods

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a player list from database</summary>       ///
        /// <param name="">None</param>                                               ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Logged Users only</permission>                                ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [LogonAuthorize]
        public ActionResult Index()
        {
            //get users from db
            List<User> users = _userService.GetAllUser();

            //create model
            List<PlayerViewModel> model = new List<PlayerViewModel>();

            foreach (User user in users)
            {
                if (user.PlayerId != null)
                {
                    //get player from db
                    Player player =_playerService.GetPlayerById((int)user.PlayerId);
                    //populate model
                    PlayerViewModel playerViewModel = new PlayerViewModel()
                    {
                        Id = user.Id,
                        License = player.License,
                        Name = user.Name,
                        Surname = user.Surname,
                        Alias = player.Alias,
                        Phone = player.Phone,
                        Email = user.Email,
                        RealHP = player.RealHP,
                        GameHP = player.GameHP,
                        PlayerId = (int)user.PlayerId,
                        AvailableRoles = GetAvailableRoles()                     
                    };        
                    model.Add(playerViewModel);
                }
            }
            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show player details from database</summary>      ///
        /// <param name="id">PlayerId</param>                                         ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Logged Users only</permission>                                ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [LogonAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null) throw new HttpException(404, "");
            //get user from database
            User user = _userService.GetUserById((int)id);
            if (user == null) throw new HttpException("User " + id + " not found");   
            
            //get player from database
            Player player = _playerService.GetPlayerById((int)user.PlayerId);
            if (player == null) throw new HttpException("Player " + user.PlayerId + " not found");   

            //populate model
            var model = new PlayerViewModel()
            {
                Id = user.Id,
                License = player.License,
                Name = user.Name,
                Surname = user.Surname,
                Alias = player.Alias,
                Phone = player.Phone,
                Email = user.Email,
                RealHP = player.RealHP,
                GameHP = player.GameHP,
                PlayerId = (int)user.PlayerId,
                AvailableRoles = GetAvailableRoles()
            }; 

            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a create player form</summary>              ///
        /// <param name="">None</param>                                               ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin only</permission>                                       ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Create()
        {
            PlayerViewModel model = new PlayerViewModel()
            {
                AvailableRoles = GetAvailableRoles()
            };
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Create a player in database</summary>                           ///
        /// <param name="model">PlayerViewModel</param>                               ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin only</permission>                                       ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Create(PlayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (LicenseExist(model)) ModelState.AddModelError("", "La licencia pertence a otro usuario");
                else if (EmailExist(model)) ModelState.AddModelError("", "El email pertence a otro usuario");                              
                else
                {
                    Player player = new Player()
                    {
                        License = model.License,
                        Alias = model.Alias,       
                        GameHP = model.GameHP,
                        RealHP = model.RealHP,
                        Phone = model.Phone
                    };

                    //insert player in database
                    int playerId = _playerService.InsertPlayer(player);

                    User user = new User()
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Surname = model.Surname,
                        Password = SecurityManager.Encrypt(model.Password),
                        RoleId = model.RoleId,
                        PlayerId = playerId
                    };

                    //insert user in database
                    int userId = _userService.InsertUser(user);

                    //redirect to confirmation mail send
                    return RedirectToAction("Confirmation", new { id = userId });
                }
            }
            //populate the selectList
            model.AvailableRoles = GetAvailableRoles();

            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a confimation page</summary>                ///
        /// <param name="model">PlayerViewModel</param>                               ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin</permission>                                            ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Confirmation(int? id)
        {
            if (id == null) throw new HttpException("User " + id + " not found");
            return View(id);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Send an email to the new user</summary>                         ///
        /// <param name="model">PlayerViewModel</param>                               ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin</permission>                                            ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult SendEmail(int? id)
        {
            if (id == null) throw new HttpException("User " + id + " not found");
            var user = _userService.GetUserById((int)id);

            List<User> users = new List<User>();
            users.Add(user);

            string subject = "Creación de usuario en www.torneocampoy.tk";

            string body = "Ya puede acceder a la web www.torneocampoy.tk con sus credenciales: USUARIO: "
                + user.Email + " CONTRASEÑA: " + SecurityManager.Decrypt(user.Password);

            if (_mailManager.SendMail(subject, body, users, true)) return RedirectToAction("Index");
            else return RedirectToRoute("MailError");
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a edit player form</summary>                ///
        /// <param name="id">PlayerId</param>                                         ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin only</permission>                                       ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null) throw new HttpException(404, "");

            //get user from db
            User user = _userService.GetUserById((int)id);
            if (user == null) throw new HttpException("User " + id + " not found");
            
            //get player from db
            Player player = _playerService.GetPlayerById((int)user.PlayerId);
            if (player == null) throw new HttpException("Player " + user.PlayerId + " not found");

            //populate model
            PlayerViewModel model = new PlayerViewModel() 
            { 
                Id = user.Id,
                License = player.License,
                Name = user.Name,
                Surname = user.Surname,
                Alias = player.Alias,
                Phone = player.Phone,
                RoleId = user.RoleId,                
                Email = user.Email,
                RealHP = player.RealHP,
                GameHP = player.GameHP,
                Password = null,
                ConfirmPassword = null,
                AvailableRoles = GetAvailableRoles(),   
                PlayerId = (int)user.PlayerId
            };

            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Edit player in database</summary>                                ///
        /// <param name="id, model">FieldId, FieldViewModel</param>                   ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin only</permission>                                       ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Edit(int? id, PlayerViewModel model)
        {
            if (id == null) throw new HttpException(404, "");
            if (ModelState.IsValid)
            {
                string message = ValidateModel(model);
                if (message!=null) ModelState.AddModelError("", message);                
                else
                {
                    //get user from database
                    User currentUser = _userService.GetUserById(model.Id);

                    Player player = new Player()
                    {
                        Id = (int)currentUser.PlayerId,
                        License = model.License,
                        Alias = model.Alias,
                        GameHP = model.GameHP,
                        RealHP = model.RealHP,
                        Phone = model.Phone
                    };

                    //update player
                    _playerService.UpdatePlayer(player);

                    User user = new User()
                    {
                        Id = currentUser.Id,
                        Email = model.Email,
                        Name = model.Name,
                        Surname = model.Surname,
                        Password = currentUser.Password,
                        RoleId = model.RoleId,
                        PlayerId = model.PlayerId
                    };

                    //update user
                    _userService.UpdateUser(user);

                    //redirect to Player List Page
                    return RedirectToAction("Index");
                }
            }

            //populate selectlist
            model.AvailableRoles = GetAvailableRoles();
            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a delete player form</summary>              ///
        /// <param name="id">UserId</param>                                           ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin</permission>                                            ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null) throw new HttpException(404, "");

            //get user from db
            User user = _userService.GetUserById((int)id);
            if (user == null) throw new HttpException("User " + id + " not found");

            //get player from db
            var player = _playerService.GetPlayerById((int)user.PlayerId);
            if (player == null) throw new HttpException("Player " + player.Id + " not found");

            //populate model
            var model = new PlayerViewModel()
            {
                Id = user.Id,
                License = player.License,
                Name = user.Name,
                Surname = user.Surname,
                Alias = player.Alias,
                Phone = player.Phone,
                Email = user.Email,
                RealHP = player.RealHP,
                GameHP = player.GameHP,
                PlayerId = (int)user.PlayerId,
                AvailableRoles = GetAvailableRoles()
            }; 

            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Logical delete player from database</summary>                   ///
        /// <param name="id, model">PlayerId, PlayerViewModel</param>                 ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin only</permission>                                       ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Delete(int? id, PlayerViewModel model)
        {
            if (id == null) throw new HttpException(404, "");

            //get user from database
            User user = _userService.GetUserById(model.Id);
            if (user == null) throw new HttpException("User " + id + " not found");

            //get player from database
            Player player = _playerService.GetPlayerById((int)user.PlayerId);
            if (player == null) throw new HttpException("Player " + player.Id + " not found");

            //logical delete user/player
            _userService.LogicalDeleteUser(user);
            _playerService.LogicalDeletePlayer(player);

            //redirect to Player List Page
            return RedirectToAction("Index");
        }

        #endregion

        #region Utilities

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Validate model</summary>                                        ///
        /// <param name="model">PlayerViewModel</param>                               ///
        /// <returns>string</returns>                                                 ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public string ValidateModel(PlayerViewModel model)
        {
            //get user from db
            User currentUser = _userService.GetUserById(model.Id);
            if (currentUser == null) throw new HttpException("User " + model.Id + " not found");

            //get player form db
            Player currentPlayer = _playerService.GetPlayerById((int)model.PlayerId);
            if (currentPlayer == null) throw new HttpException("Player " + (int)model.PlayerId + " not found");

            if (currentUser.Email.CompareTo(model.Email) != 0) 
            {
                var user = (from u in _userService.GetAllUser()
                            where u.Email == model.Email
                            select u).FirstOrDefault();

                if (user != null) return "El email pertenece a otro usuario";
            
            }
            else if (currentPlayer.License.CompareTo(model.License) != 0) 
            {
                var player = (from u in _playerService.GetAllPlayer()
                            where u.License == model.License
                            select u).FirstOrDefault();
                
                if (player != null) return "La licencia pertenece a otro jugador";
            }
            return null;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if the email exist</summary>                              ///
        /// <param name="model">PlayerViewModel</param>                               ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool EmailExist(PlayerViewModel model)
        {
            var user = (from u in _userService.GetAllUser()
                          where u.Email == model.Email
                          select u).FirstOrDefault();

            if (user != null) return true;
            else return false;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if the license exist</summary>                            ///
        /// <param name="model">PlayerViewModel</param>                               ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool LicenseExist(PlayerViewModel model)
        {
            var player = (from p in _playerService.GetAllPlayer()
                          where p.License == model.License
                          select p).FirstOrDefault();
           
            if (player != null) return true;
            else return false;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Get roles except User role</summary>                            ///
        /// <param name=""></param>                                                   ///
        /// <returns>List<SelectListItem></returns>                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public List<SelectListItem> GetAvailableRoles()
        {
            List<SelectListItem> ls = new List<SelectListItem>();

            var roles = from r in _roleService.GetAllRole()
                        where r.RoleName != "User"
                        select r;
            
            foreach (var temp in roles) ls.Add(new SelectListItem() { Text = temp.RoleName, Value = temp.Id.ToString() });
            
            return ls;
        }

        #endregion
    }
}
using DomainEntities;
using DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Attributes;
using WebApplication.Managers;
using WebApplication.Models.Login;
using WebApplication.Models.Profile;
using WebApplication.Models.User;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        #region Fields

        private readonly UserService _userService;
        private readonly PlayerService _playerService;

        #endregion

        #region Constructors

        public ProfileController(UserService userService, PlayerService playerService)
        {
            this._userService = userService;
            this._playerService = playerService;
        }

        #endregion

        #region Methods


        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show the register user form</summary>            ///
        /// <param name=""></param>                                                   ///
        /// <returns>View</returns>                                                   ///
        /// <permission>AllowAnonymous</permission>                                   ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [Attributes.AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Create a user in database</summary>                             ///
        /// <param name="model">UserViewModel</param>                                 ///
        /// <returns>View</returns>                                                   ///
        /// <permission>AllowAnonymous</permission>                                   ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [Attributes.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in _userService.GetAllUser()
                            where u.Email == model.Email
                            select u).FirstOrDefault();               

                if (user == null)
                {
                    user = new User()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        Password = SecurityManager.Encrypt(model.Password),
                        RoleId = 3,
                        PlayerId = null
                    };

                    _userService.InsertUser(user);

                    LoginModel logon = new LoginModel()
                    {
                        Email = model.Email,
                        Password = model.Password
                    };

                    UserManager.ValidateUser(logon, Response);

                    return RedirectToRoute("HomePage");
                }
                else
                {
                    ModelState.AddModelError("", "Ya existe el usuario");
                }
            }
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show the change password form</summary>          ///
        /// <param name="id">int</param>                                              ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Logged Users only</permission>                                ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [LogonAuthorize]
        public ActionResult ChangePassword(int? id)
        {
            if (id == null) throw new HttpException(404, "");
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Update user password in database</summary>                      ///
        /// <param name="model">ChangePasswordViewModel</param>                       ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Loged Users only</permission>                                 ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LogonAuthorize]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //get user from db
                User user = _userService.GetUserById(model.Id);
                if (user == null) throw new HttpException("User " + model.Id + " not found");

                //if password is valid
                if (user.Password.CompareTo(SecurityManager.Encrypt(model.CurrentPassword)) != 0)
                {
                    ModelState.AddModelError("", "El password no es válido");
                }
                else 
                {
                    user.Password = SecurityManager.Encrypt(model.NewPassword);
                    //update user password
                    _userService.UpdateUser(user);
                    //redirect to Homepage
                    return RedirectToRoute("HomePage");
                }
            }
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check the kind of user</summary>                                ///
        /// <param name="id">int</param>                                              ///
        /// <returns></returns>                                                       ///
        /// <permission>Logged Users only</permission>                                ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [LogonAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null) throw new HttpException(404, "");

            //get user from db
            User user = _userService.GetUserById((int)id);
            if (user == null) throw new HttpException("User " + id + " not found");

            //if not player go to edit user action
            if (user.PlayerId != null) return RedirectToAction("EditPlayer", "Profile", new { id = id });
            //if player go to edit player action
            else return RedirectToAction("EditUser", "Profile", new { id = id });
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a edit user profile form</summary>          ///
        /// <param name="id">int</param>                                              ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/User only</permission>                                  ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin User")]
        public ActionResult EditUser(int? id)
        {
            if (id == null) throw new HttpException(404, "");

            //get user from db
            User user = _userService.GetUserById((int)id);
            if (user == null) throw new HttpException("User " + id + " not found");

            //populate model
            UserProfileViewModel model = new UserProfileViewModel() 
            { 
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                CurrentPassword = null            
            };
            //send model to the UI
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Update a user in database</summary>                             ///
        /// <param name="model">UserProfileViewModel</param>                          ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/User only</permission>                                  ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin User")]
        public ActionResult EditUser(int? id, UserProfileViewModel model)
        {
            if (id == null) throw new HttpException(404, "");
            if (ModelState.IsValid)
            {
                if (!PasswordIsValid((int)id, model.CurrentPassword)) ModelState.AddModelError("", "El password no es válido");               
                else if (UserExist((int)id, model.Email)) ModelState.AddModelError("", "El email pertence a otro usuario");
                else
                {
                    //get user from db
                    User user = _userService.GetUserById((int)id);
                    if (user == null) throw new HttpException("User " + id + " not found");

                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Email = model.Email;
                    
                    //update user in db
                    _userService.UpdateUser(user);

                    LoginModel logon = new LoginModel()
                    {
                        Email = model.Email,
                        Password = SecurityManager.Decrypt(user.Password)
                    };

                    //Relogon user
                    UserManager.ValidateUser(logon, Response);
                    //Redirect to Homepage
                    return RedirectToRoute("HomePage");
                }

            }
            //send model to the UI (View)
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a edit player profile form</summary>        ///
        /// <param name="id">int</param>                                              ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/Player only</permission>                                ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult EditPlayer(int? id)
        {
            if (id == null) throw new HttpException(404, "");

            //get user from db
            User user = _userService.GetUserById((int)id);
            if (user == null) throw new HttpException("User " + id + " not found");

            //get player from fb
            Player player = _playerService.GetPlayerById((int)user.PlayerId);
            if (player == null) throw new HttpException("Player " + player.Id + " not found");

            //populate model
            PlayerProfileViewModel model = new PlayerProfileViewModel()
            {
                License = player.License,
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,                
                Surname = user.Surname,
                Alias = player.Alias,
                Phone = player.Phone,
                CurrentPassword = null
            };

            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Update a player in database</summary>                           ///
        /// <param name="model">PlayerProfileViewModel</param>                        ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin/Player only</permission>                                ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin Player")]
        public ActionResult EditPlayer(int? id, PlayerProfileViewModel model)
        {
            if (id == null) throw new HttpException(404, "");
            if (ModelState.IsValid)
            {
                if (!PasswordIsValid((int)id, model.CurrentPassword)) ModelState.AddModelError("", "El password no es válido");             
                else if (LicenseExist((int)id, model.License)) ModelState.AddModelError("", "La licencia pertence a otro usuario");
                else if (UserExist((int)id, model.Email)) ModelState.AddModelError("", "El email pertence a otro usuario");
                else
                {
                    User user = _userService.GetUserById((int)id);
                    if (user == null) throw new HttpException("User " + id + " not found");
                    Player player = _playerService.GetPlayerById((int)user.PlayerId);
                    if (user == null) throw new HttpException("Player " + user.PlayerId + " not found");
                    

                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Email = model.Email;
                    player.License = model.License;
                    player.Phone = model.Phone;
                    player.Alias = model.Alias;                   

                    //update user/player
                    _userService.UpdateUser(user);
                    _playerService.UpdatePlayer(player);

                    LoginModel logon = new LoginModel()
                    {
                        Email = model.Email,
                        Password = SecurityManager.Decrypt(user.Password)
                    };

                    //relogon user
                    UserManager.ValidateUser(logon, Response);

                    //redirect to HomePage
                    return RedirectToRoute("HomePage");
                }

            }
            //send model to the UI (View)
            return View();
        }

        #endregion

        #region Utilities

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if the password is valid</summary>                        ///
        /// <param name="int, string">userId, Password</param>                        ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool PasswordIsValid(int userId, string password)
        {
            User user = _userService.GetUserById(userId);

            if (user == null || SecurityManager.Decrypt(user.Password).CompareTo(password) != 0) return false;
            else return true;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if the user exist</summary>                               ///
        /// <param name="int, string">userId, email</param>                           ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool UserExist(int userId, string email)
        {
            User currentUser = _userService.GetUserById(userId);
            if (currentUser.Email.CompareTo(email) != 0)
            {
                var user = (from u in _userService.GetAllUser()
                            where u.Email == email
                            select u).FirstOrDefault();
                
                if (user != null) return true;
            }
            return false;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if the license exist</summary>                            ///
        /// <param name="int, string">userId, license</param>                         ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool LicenseExist(int userId, string license)
        {
            User currentUser =_userService.GetUserById(userId);
            if (currentUser == null) throw new HttpException("User " + userId + " not found");

            Player currentPlayer = _playerService.GetPlayerById((int)currentUser.PlayerId);
            if (currentPlayer == null) throw new HttpException("Player " + currentUser.PlayerId + " not found");

            if (currentPlayer.License.CompareTo(license) != 0)
            {
                var player = (from p in _playerService.GetAllPlayer()
                            where p.License == license
                            select p).FirstOrDefault();
                
                if (player != null) return true;
            }
            return false;
        }

        #endregion
    }

}
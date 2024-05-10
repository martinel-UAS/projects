using DomainEntities;
using DomainServices;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Attributes;
using WebApplication.Managers;
using WebApplication.Models.User;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        private readonly UserService _userService;
        private readonly PlayerService _playerService;
        private readonly RoleService _roleService;

        #endregion

        #region Constructors

        public UserController(UserService userService, PlayerService playerService, RoleService roleService)
        {
            this._userService = userService;
            this._playerService = playerService;
            this._roleService = roleService;
        }

        #endregion

        #region Methods

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a user list from database</summary>         ///
        /// <param name="">None</param>                                               ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin only</permission>                                      ///
        /// <request>GET</request>                                                    ///
        /////////////////////////////////////////////////////////////////////////////////
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Index()
        {
            //get user from db
            List<User> users = _userService.GetAllUser();
            List<UserViewModel> model = new List<UserViewModel>();

            //populate model
            foreach (User user in users)
            {
                UserViewModel userModel = new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    RoleId = user.RoleId,
                    RoleName = _roleService.GetRoleById(user.RoleId).RoleName
                };
                model.Add(userModel);
            }
            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Gets a View to show a edit user form</summary>                  ///
        /// <param name="id">UserId</param>                                           ///
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

            //populate model
            UserViewModel model = new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                RoleId = user.RoleId,
                Email = user.Email,
                Password = null,
                ConfirmPassword = null,
                AvailableRoles = GetAvailableRoles()
            };

            model.AvailableRoles.ElementAt(user.RoleId - 1).Selected = true;

            //send model to the UI (View)
            return View(model);
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Edit user in database</summary>                                 ///
        /// <param name="id, model">FieldId, FieldViewModel</param>                   ///
        /// <returns>View</returns>                                                   ///
        /// <permission>Admin only</permission>                                       ///
        /// <request>POST</request>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(AccessLevel = "Admin")]
        public ActionResult Edit(int id, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //get user from database
                User currentUser = _userService.GetUserById(model.Id);                
                if (currentUser.PlayerId == null && model.RoleId == 2) { ModelState.AddModelError("", "El usuario no es jugador, utilice el menú jugadores para crearlo"); }
                else if (currentUser.PlayerId != null && model.RoleId == 3) { ModelState.AddModelError("", "El usuario es jugador, utilice el menú jugadores para eliminarlo"); }
                else
                {
                    User user = new User()
                    {
                        Id = currentUser.Id,
                        Email = model.Email,
                        Name = model.Name,
                        Surname = model.Surname,
                        Password = currentUser.Password,
                        RoleId = model.RoleId,
                        PlayerId = currentUser.PlayerId
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

        #endregion

        #region Utilities

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if the Password is valid</summary>                        ///
        /// <param name="model">UserViewModel</param>                                 ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool PasswordIsValid(UserViewModel model)
        {
            User user = _userService.GetUserById(model.Id);

            if (user == null || SecurityManager.Decrypt(user.Password).CompareTo(model.Password) != 0) return false;
            else return true;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Check if the user exist</summary>                               ///
        /// <param name="model">UserViewModel</param>                                 ///
        /// <returns>bool</returns>                                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public bool UserExist(UserViewModel model)
        {
            User currentUser = _userService.GetUserById(model.Id);
            if (currentUser.Email.CompareTo(model.Email) != 0)
            {
                var user = (from u in _userService.GetAllUser()
                            where u.Email == model.Email
                            select u).FirstOrDefault();

                if (user != null) return true;
            }
            return false;
        }

        /////////////////////////////////////////////////////////////////////////////////
        /// <summary> Get roles</summary>                                             ///
        /// <param name=""></param>                                                   ///
        /// <returns>List<SelectListItem></returns>                                   ///
        /////////////////////////////////////////////////////////////////////////////////
        [NonAction]
        public List<SelectListItem> GetAvailableRoles()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            var lm = from m in _roleService.GetAllRole()
                     select m;
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.RoleName, Value = temp.Id.ToString() });
            }
            return ls;
        }

        #endregion

    }
}

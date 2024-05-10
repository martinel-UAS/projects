using DomainEntities;
using DomainServices;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Managers;
using WebApplication.Models.Login;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {

        #region Fields
        
        private readonly UserService _userService;
        private readonly MailManager _mailManager;     

        #endregion

        #region Constructors

        public LoginController(UserService userService, MailManager mailManager)
        {
            this._userService = userService;
            this._mailManager = mailManager;            
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method will Login a user
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [WebApplication.Attributes.AllowAnonymous]
        public JsonResult Login(LoginModel model)
        {
            string status = "Usuario o password no válidos";

            // Verify the fields.
            if (ModelState.IsValid)
            {
                // Authenticate the user.
                if (UserManager.ValidateUser(model, Response))
                {
                    // Redirect to the secure area.
                    if (string.IsNullOrWhiteSpace(model.RedirectUrl))
                    {
                        model.RedirectUrl = "/";
                    }
                    status = "OK";
                }
            }

            return Json(new { RedirectUrl = model.RedirectUrl, Status = status });
        }

        /// <summary>
        /// This method will logout a user
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [WebApplication.Attributes.AllowAnonymous]
        public ActionResult Logout()
        {
            // Clear the user session and forms auth ticket.
            UserManager.Logoff(Session, Response);
            // Redirect user to main page
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// This method will remind user password
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [WebApplication.Attributes.AllowAnonymous]
        public JsonResult Remind(LoginModel model)
        {
            string status = "El email no se corresponde con ningún usuario";            
            
            //Get users usin LinQ
            var user = (from u in _userService.GetAllUser()
                        where u.Email == model.Email
                        select u).FirstOrDefault();

            if (user != null)
            {
                string subject = "Password recovery";
                string body = "Su password es: " + SecurityManager.Decrypt(user.Password);
                List<User> recipients = new List<User>();
                recipients.Add(user);

                user.Email = model.Email;

                if(_mailManager.SendMail(subject, body, recipients, true))
                    status = "Inicie sesión con la contraseña que le ha sido enviada";                
                else status = "Error enviando correo. Pruebe de nuevo pasados unos minutos";                
            }
            return Json(new { RedirectUrl = model.RedirectUrl, Status = status });
        }

        #endregion

        #region Methods

        #endregion
    }
}
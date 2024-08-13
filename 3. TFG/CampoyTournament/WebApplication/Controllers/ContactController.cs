using DomainEntities;
using System.Web.Mvc;
using WebApplication.Attributes;
using WebApplication.Managers;
using WebApplication.Models.Contact;

namespace WebApplication.Controllers
{
    public class ContactController : Controller
    {
        #region Fields

        private readonly MailManager _mailManager;

        #endregion

        #region Constructors

        public ContactController(MailManager mailManager)
        {
            this._mailManager = mailManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method will return the Contact View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method submits the Contact form
        /// </summary>
        /// <param name="model">ContactViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [LogonAuthorize]
        public ActionResult Index(ContactViewModel model)
        {           
            string subject = "Formulario de contacto enviado por: " + User.Identity.Name;
            if(_mailManager.SendMail(subject, model.Message, null, true)) return RedirectToAction("Confirmation");
            else return RedirectToRoute("MailError");
        }

        /// <summary>
        /// This method will return the Confirmation View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult Confirmation()
        {
            return View();
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Attributes;

namespace WebApplication.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// This method will return the Main Error View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [WebApplication.Attributes.AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method will return the UpdateBrowser View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [WebApplication.Attributes.AllowAnonymous]
        public ActionResult UpdateBrowser()
        {
            return View();
        }

        /// <summary>
        /// This method will return the NotFound View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult NotFound()
        {
            return View();
        }

        /// <summary>
        /// This method will return the MailError View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [LogonAuthorize]
        public ActionResult MailError()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class AboutController : Controller
    {
        /// <summary>
        /// This method will return the About View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
	}
}
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This method will return the Home View
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) {
                if (!BrowserIsUpToDate()) return RedirectToAction("UpdateBrowser", "Error"); 
            }            
            
            return View();
        }

        /// <summary>
        /// This method will return the UpdateBrowser
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected bool BrowserIsUpToDate()
        {
            HttpBrowserCapabilitiesBase objBrwInfo = Request.Browser;
            if (objBrwInfo.Browser.Equals("IE"))
            { 
            if( (objBrwInfo.Version.Equals("5.0")) || (objBrwInfo.Version.Equals("6.0")) || (objBrwInfo.Version.Equals("7.0")) ||
                (objBrwInfo.Version.Equals("8.0"))) return false;
            }               
            return true;          
        }
    }
}
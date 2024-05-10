using System.Web;
using System.Web.Mvc;
using WebApplication.Attributes;

namespace WebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Add controller security (AllowAnonymousAttribute).
            filters.Add(new LogonAuthorize());
        }
    }
}

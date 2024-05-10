using DomainEntities;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using WebApplication.Managers;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Initialise();            
        }

        //Authetication Request Management
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var identity = new GenericIdentity(authTicket.Name, "Forms");
                var principal = new MyPrincipal(identity);

                // Get the custom user data encrypted in the ticket.
                string userData = ((FormsIdentity)(Context.User.Identity)).Ticket.UserData;

                // Deserialize the json data and set it on the custom principal.
                var serializer = new JavaScriptSerializer();
                principal.User = (User)serializer.Deserialize(userData, typeof(User));

                // Set the context user.
                Context.User = principal;
            }
        }

        // Exception Management
        protected void Application_Error(object sender, EventArgs e)
        {

            // Clear the response            
            Response.Clear();

            // Get the exception object
            Exception exc = Server.GetLastError();

            // Log the exception (enabled for testing)
            ExceptionManager.LogException(exc, exc.Source);

            // Notify system operators
            try { ExceptionManager.NotifySystemOps(exc); }
            catch { }

            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException) || exc.GetType() == typeof(HttpAntiForgeryException))
            {
                var ex = (HttpException)Server.GetLastError();
                int httpCode = ex.GetHttpCode();

                if (httpCode == 404) 
                {
                    // Clear the error from the server
                    Server.ClearError();

                    // Redirect to an error page
                    Response.Redirect("~/Error/NotFound");
                
                }
                else
                {
                    // Clear the error from the server
                    Server.ClearError();

                    // Redirect to an error page
                    Response.Redirect("~/Error/Index");
                
                }

            }

            // For other kinds of errors give the user some information
            // but stay on the default page
            Response.Write("<h2>Global Page Error</h2>\n");
            Response.Write("<p>" + exc.Message + "</p>\n");
            Response.Write("Return to the <a href='/'>" + "Default Page</a>\n");

            // Clear the error from the server
            Server.ClearError();
        }
    }
}

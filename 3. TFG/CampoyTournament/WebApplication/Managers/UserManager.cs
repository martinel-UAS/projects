using DomainEntities;
using DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using WebApplication.Models.Login;

namespace WebApplication.Managers
{
    public static class UserManager
    {
        /// <summary>
        /// Returns the User from the Context.User.Identity by decrypting the forms auth ticket and returning the user object.
        /// </summary>
        public static User User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // The user is authenticated. Return the user from the forms auth ticket.
                    return ((MyPrincipal)(HttpContext.Current.User)).User;
                }
                else if (HttpContext.Current.Items.Contains("User"))
                // if (HttpContext.Current.Items.Contains("User"))
                {
                    // The user is not authenticated, but has successfully logged in.
                    return (User)HttpContext.Current.Items["User"];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Authenticates a user against a database, web service, etc.
        /// </summary>
        /// <param name="username">Email</param>
        /// <param name="password">Password</param>
        /// <returns>User</returns>
        public static User AuthenticateUser(string email, string password)
        {
            User user = null;

            password = SecurityManager.Encrypt(password);

            UserService _userService = new UserService();

            string whereClause = "Email='" + email + "' AND Password='" + password + "' AND IsDeleted=0";
            user = _userService.GetAllUsersOrderBy(whereClause, "Id").FirstOrDefault();

            // Returns the user
            return user;
        }

        /// <summary>
        /// Authenticates a user via the MembershipProvider and creates the associated forms authentication ticket.
        /// </summary>
        /// <param name="logon">Logon</param>
        /// <param name="response">HttpResponseBase</param>
        /// <returns>bool</returns>
        public static bool ValidateUser(LoginModel logon, HttpResponseBase response)
        {
            bool result = false;

            if (Membership.ValidateUser(logon.Email, logon.Password))
            {
                // Create the authentication ticket with custom user data.
                var serializer = new JavaScriptSerializer();
                UserService us = new UserService();
                string userData = serializer.Serialize(us.GetUserById(UserManager.User.Id));
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        logon.Email,
                        DateTime.Now,
                        DateTime.Now.AddHours(1),
                        false,
                        userData,
                        FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                result = true;
            }

            return result;
        }

        /// <summary>
        /// Clears the user session, clears the forms auth ticket, expires the forms auth cookie.
        /// </summary>
        /// <param name="session">HttpSessionStateBase</param>
        /// <param name="response">HttpResponseBase</param>
        public static void Logoff(HttpSessionStateBase session, HttpResponseBase response)
        {
            // Delete the user details from cache.
            session.Abandon();

            // Delete the authentication ticket and sign out.
            FormsAuthentication.SignOut();

            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            response.Cookies.Add(cookie);
        }

        public static bool IsInRole(User user, string role)
        {
            RoleService _roleService = new RoleService();
            if (role.Contains(_roleService.GetRoleById(user.RoleId).RoleName)) return true;
            return false;
        }
    }
}
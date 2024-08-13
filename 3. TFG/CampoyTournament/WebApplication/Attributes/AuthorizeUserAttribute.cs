using DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Managers;

namespace WebApplication.Attributes
{
public class AuthorizeUserAttribute : AuthorizeAttribute
{
    // Custom property
    public string AccessLevel { get; set; }

    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        var isAuthorized = base.AuthorizeCore(httpContext);
        if (!isAuthorized)
        {                
            return false;
        }
        //string privilegeLevels = string.Empty;
        RoleService rs = new RoleService();
        var role = rs.GetRoleById(UserManager.User.RoleId).RoleName;

        string privilegeLevels = string.Join("", role);

        if ((this.AccessLevel).Contains(privilegeLevels))
        {
            return true;
        }
        else
        {
            return false;
        }            
    }
}
}
using Antlr.Runtime.Misc;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace WebApplication
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string spanClass)
        {
            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            var newlinktext = spanClass + " " + linkText;

            var builder = new TagBuilder("li")
            {                     
                InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString().Replace(linkText, newlinktext)                    
            };

            if (controllerName == currentController && actionName == currentAction)
                builder.AddCssClass("active");
                                            
            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString SpanLink(this HtmlHelper htmlHelper, string linkText, string newLinkText, string actionName, string controllerName, object routeValues)
        {
            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            var builder = htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, null).ToHtmlString().Replace(linkText, newLinkText);

            return new MvcHtmlString(builder.ToString());
        }

        public static MvcForm BeginForm(this HtmlHelper helper, object htmlAttributes)
        {
            return helper.BeginForm(helper.ViewContext.RouteData.Values["Action"].ToString(),
                                    helper.ViewContext.RouteData.Values["Controller"].ToString(),
                                    FormMethod.Post, htmlAttributes);
        }

        public static MvcHtmlString Image(this HtmlHelper html, string name, string url, object htmlAttributes)
        {
            var img = new TagBuilder("img");
            img.GenerateId(name);           
            img.MergeAttribute("src", url);
            img.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }

    }
}
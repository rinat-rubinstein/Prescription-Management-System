using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PrescriptionUI
{
    public static class HtmlExtensions
    {
        public static IHtmlString NoEncodeActionLink(this HtmlHelper htmlHelper, string linkText, string action, object htmlAttributes)
        {
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            TagBuilder builder = new TagBuilder("a");
            builder.InnerHtml = linkText;
            builder.Attributes["href"] = urlHelper.Action(action);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
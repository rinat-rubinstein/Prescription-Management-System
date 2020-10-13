using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrescriptionUI
{
    public class htmlHelper
    {
    }
    public static class CustomHelpers
    {
        public static IHtmlString DisplayImage(this HtmlHelper helper, string imageUrl)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", imageUrl);
            return new MvcHtmlString(tb.ToString());
        }
    }
}
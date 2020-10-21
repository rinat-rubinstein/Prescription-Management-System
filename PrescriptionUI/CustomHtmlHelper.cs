using PrescriptionBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PrescriptionUI
{
    public static class CustomHtmlHelper
    {

        public static MvcHtmlString DropDownListForUsers(this HtmlHelper htmlHelper, string name)
        {
            IBL bl = new BLImplement();
            string options = "";
            foreach (var user in bl.getAllMedicines())
            {
                options += $"<option value ='{user.Name}'> {user.Name} </option>";
            }
            return new MvcHtmlString($"<select  name={name} id='medId' style='color:black'>{options}</select>");
        }
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
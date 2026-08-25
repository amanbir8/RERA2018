using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ComplaintPrint
{
    public static class Cls_Custom_Helper
    {
        public static IHtmlString Create_HTML1()
        {
            string LableStr = $"<label style=\"background-color:gray;color:yellow;font-size:24px\">Hello ABC ZAMS</label>";
            return new HtmlString(LableStr);
        }

        public static IHtmlString Create_HTML2(string Content)
        {
            string LableStr = $"{Content}";
            return new HtmlString(LableStr);
        }
    }
}
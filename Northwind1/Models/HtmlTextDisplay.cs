using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class HtmlTextDisplay : IDisplay
    {
        public string Display(List<string> attrList, NWDataModel data)
        {
            // Create html string
            string html = "";

            foreach (string attr in attrList)
            {
                html += data.GetType().GetProperty(attr).GetValue(data, null) + "<br />";
            }

            html += "<br />";

            return html;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class TableRowDisplay : IDisplay
    {
        public string Display(List<string> attrList, NWDataModel data)
        {
            // Create html string
            string html = "<tr>";

            foreach (string attr in attrList)
            {
                html += "<td>" + data.GetType().GetProperty(attr).GetValue(data, null) + "</td>";
            }

            html += "</tr>";

            return html;
        }
    }
}
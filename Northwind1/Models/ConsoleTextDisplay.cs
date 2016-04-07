using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class ConsoleTextDisplay
    {
        public string Display(List<string> attrList, NWDataModel data)
        {
            // Create text string
            string text = "";

            foreach (string attr in attrList)
            {
                text += data.GetType().GetProperty(attr).GetValue(data, null) + "\n";
            }

            text += "\n";

            return text;
        }
    }
}
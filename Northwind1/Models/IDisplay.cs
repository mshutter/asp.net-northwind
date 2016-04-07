using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public interface IDisplay
    {
        string Display(List<string> attrList, NWDataModel data);
    }
}
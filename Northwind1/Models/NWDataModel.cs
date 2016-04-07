using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public abstract class NWDataModel
    {
        IDisplay displayInterface;

        public virtual void SetDisplay (IDisplay newDisplay)
        {
            this.displayInterface = newDisplay;
        }

        public virtual string Display(List<string> attrList, NWDataModel data)
        {
            return this.displayInterface.Display(attrList, data);
        }
    }
}
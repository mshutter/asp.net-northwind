using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class Category : NWDataModel
    {
        // Static list of attributes used for display methods
        public static List<string> attrList = new List<string>(
            new string[] {
                "CategoryID",
                "CategoryName",
                "Description"
            });


        // ********** Private Variables **********

        private int categoryID = -1;
        private string categoryName = "N/a";
        private string description = "N/a";

        // Number of Categories
        public static int count = 0;


        // ********** Accessor Methods **********

        public int CategoryID
        {
            // Read Only
            get
            {
                return categoryID;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }

            set
            {
                if (value == "") { }

                else
                {
                    this.categoryName = value;
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value == "") { }

                else
                {
                    this.description = value;
                }
            }
        }


        // ********** Constructors **********

        public Category()
        {
            // Each time a Category is created, add +1 to static counter
            Category.count++;

            // Default display interface will be TableRowDisplay
            SetDisplay(new TableRowDisplay());
        }

        public Category(int aCategoryID, string aCategoryName, string aDescription)
            : this()
        {
            this.categoryID = aCategoryID;
            this.CategoryName = aCategoryName;
            this.Description = aDescription;
        }

        public Category(int aCategoryID, string aCategoryName)
            : this(aCategoryID, aCategoryName, "N/a")
        {

        }

        public Category(int aCategoryID)
            : this(aCategoryID, "N/a", "N/a")
        {

        }


        // ********** Display Method **********
        public override string ToString ()
        {
            return Display(Category.attrList, this);
        }
    }
}
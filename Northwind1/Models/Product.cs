using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class Product : NWDataModel
    {
        // Static list of attributes used for display methods
        public static List<string> attrList = new List<string>(
            new string[] {
                "ProductID",
                "ProductName",
                "SupplierID",
                "CategoryID",
                "QuantityPerUnit",
                "UnitPrice",
                "UnitsInStock",
                "UnitsOnOrder",
                "ReorderLevel",
                "Discontinued"
            });

        // ********** Private Variables **********

        private int productID = -1;
        private string productName = "N/a";
        private int supplierID = -1;
        private int categoryID = -1;
        private string quantityPerUnit = "N/a";
        private double unitPrice = -1;
        private int unitsInStock = -1;
        private int unitsOnOrder = -1;
        private int reorderLevel = -1;
        private string discontinued = "FALSE";

        // Number of Products
        public static int count = 0;



        // ********** Accessor Methods **********

        public int ProductID
        {
            // Read Only
            get
            {
                return productID;
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                this.productName = value;
            }
        }

        public int SupplierID
        {
            get
            {
                return supplierID;
            }

            set
            {
                this.supplierID = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return categoryID;
            }

            set
            {
                this.categoryID = value;
            }
        }

        public string QuantityPerUnit
        {
            get
            {
                return quantityPerUnit;
            }

            set
            {
                this.quantityPerUnit = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                this.unitPrice = value;
            }
        }

        public int UnitsInStock
        {
            get
            {
                return unitsInStock;
            }

            set
            {
                this.unitsInStock = value;
            }
        }

        public int UnitsOnOrder
        {
            get
            {
                return unitsOnOrder;
            }

            set
            {
                this.unitsOnOrder = value;
            }
        }

        public int ReorderLevel
        {
            get
            {
                return reorderLevel;
            }

            set
            {
                this.reorderLevel = value;
            }
        }

        public string Discontinued
        {
            get
            {
                return this.discontinued;
            }

            set
            {
                this.discontinued = value;
            }
        }



        // ********** Constructors **********

        public Product()
        {
            // Each time a Product is created, add +1 to static counter
            Product.count++;

            // Set Display interface
            SetDisplay(new TableRowDisplay());
        }

        public Product(int aProductID, string aProductName, int aSupplierID, int aCategoryID, string aQuantPer, double aPrice, int aInStock, int aOnOrder, int aReorderLvl, string aDiscontinued)
            : this()
        {
            this.productID = aProductID;
            this.ProductName = aProductName;
            this.SupplierID = aSupplierID;
            this.CategoryID = aCategoryID;
            this.QuantityPerUnit = aQuantPer;
            this.UnitPrice = aPrice;
            this.UnitsInStock = aInStock;
            this.UnitsOnOrder = aOnOrder;
            this.ReorderLevel = aReorderLvl;
            this.Discontinued = aDiscontinued;
        }

        public Product(int aProductID, string aProductName, int aSupplierID, int aCategoryID, string aQuantPer, double aPrice, int aInStock, int aOnOrder, int aReorderLvl)
            : this(aProductID, aProductName, aSupplierID, aCategoryID, aQuantPer, aPrice, aInStock, aOnOrder, aReorderLvl, "N/a")
        {

        }

        public Product(int aProductID, string aProductName, int aSupplierID, int aCategoryID, string aQuantPer, double aPrice, int aInStock, int aOnOrder)
            : this(aProductID, aProductName, aSupplierID, aCategoryID, aQuantPer, aPrice, aInStock, aOnOrder, -1, "N/a")
        {

        }

        public Product(int aProductID, string aProductName, int aSupplierID, int aCategoryID, string aQuantPer, double aPrice, int aInStock)
            : this(aProductID, aProductName, aSupplierID, aCategoryID, aQuantPer, aPrice, aInStock, 0, -1, "N/a")
        {

        }

        public Product(int aProductID, string aProductName, int aSupplierID, int aCategoryID, string aQuantPer, double aPrice)
            : this(aProductID, aProductName, aSupplierID, aCategoryID, aQuantPer, aPrice, 0, 0, -1, "N/a")
        {

        }

        public Product(int aProductID, string aProductName, int aSupplierID, int aCategoryID, string aQuantPer)
            : this(aProductID, aProductName, aSupplierID, aCategoryID, aQuantPer, -1, 0, 0, -1, "N/a")
        {

        }

        public Product(int aProductID, string aProductName, int aSupplierID, int aCategoryID)
            : this(aProductID, aProductName, aSupplierID, aCategoryID, "N/a", -1, 0, 0, -1, "N/a")
        {

        }

        public Product(int aProductID, string aProductName, int aSupplierID)
            : this(aProductID, aProductName, aSupplierID, -1, "N/a", -1, 0, 0, -1, "N/a")
        {

        }

        public Product(int aProductID, string aProductName)
            : this(aProductID, aProductName, -1, -1, "N/a", -1, 0, 0, -1, "N/a")
        {

        }

        public Product(int aProductID)
            : this(aProductID, "N/a", -1, -1, "N/a", -1, 0, 0, -1, "N/a")
        {

        }


        // ********** Display Method **********
        public override string ToString()
        {
            return Display(Product.attrList, this);
        }
    }
}
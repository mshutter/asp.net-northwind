using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class OrderDetail : NWDataModel
    {
        // Static list of attributes used for display methods
        public static List<string> attrList = new List<string>(
            new string[] {
                "OrderID",
                "ProductID",
                "UnitPrice",
                "Quantity",
                "Discount"
            });

        // ********** Private Variables **********

        private int orderID = -1;
        private int productID = -1;
        private double unitPrice = -1;
        private int quantity = -1;
        private double discount = 0;

        //total number of OrderDetail instances created
        public static int count = 0;



        // ********** Accessor Methods **********

        public int OrderID
        {
            // Read Only
            get
            {
                return orderID;
            }
        }

        public int ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                if (value >= 1)
                {
                    this.productID = value;
                }
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
                if (value > 0)
                {
                    this.unitPrice = value;
                }
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                if (value >= 0)
                {
                    this.quantity = value;
                }
            }
        }

        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                if (value > 0)
                {
                    this.discount = value;
                }
                else
                {
                    this.discount = 0;
                }
            }
        }



        // ********** Constructors **********

        public OrderDetail()
        {
            //increment OrderDetail counter
            OrderDetail.count++;

            //set DIsplay interface
            SetDisplay(new TableRowDisplay());
        }

        public OrderDetail(int anOrderID, int aProductID, double aUnitPrice, int aQuantity, double aDiscount)
            : this()
        {
            this.orderID = anOrderID;
            this.ProductID = aProductID;
            this.UnitPrice = aUnitPrice;
            this.Quantity = aQuantity;
            this.Discount = aDiscount;
        }

        public OrderDetail(int anOrderID, int aProductID, double aUnitPrice, int aQuantity)
            : this(anOrderID, aProductID, aUnitPrice, aQuantity, 0)
        {

        }

        public OrderDetail(int anOrderID, int aProductID, double aUnitPrice)
            : this(anOrderID, aProductID, aUnitPrice, -1, 0)
        {

        }

        public OrderDetail(int anOrderID, int aProductID)
            : this(anOrderID, aProductID, -1, -1, 0)
        {

        }

        public OrderDetail(int anOrderID)
            : this(anOrderID, -1, -1, -1, 0)
        {

        }

        
        // ********** Display Method **********
        public override string ToString()
        {
            return Display(OrderDetail.attrList, this);
        }
    }
}
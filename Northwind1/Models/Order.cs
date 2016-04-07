using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class Order : NWDataModel
    {
        // Static list of attributes used for display methods
        public static List<string> attrList = new List<string>(
            new string[] {
                "OrderID",
                "CustomerID",
                "EmployeeID",
                "OrderDate",
                "RequiredDate",
                "ShippedDate",
                "ShipVia",
                "Freight",
                "ShipName",
                "ShipAddress",
                "ShipCity",
                "ShipRegion",
                "ShipPostalCode",
                "ShipCountry"
            });


        // ********** Private Variables **********

        private int orderID = -1;
        private string customerID = "N/a";
        private int employeeID = -1;
        private string orderDate = "N/a";
        private string requiredDate = "N/a";
        private string shippedDate = "N/a";
        private int shipVia = -1;
        private double freight = -1;
        private string shipName = "N/a";
        private string shipAddress = "N/a";
        private string shipCity = "N/a";
        private string shipRegion = "N/a";
        private string shipPostalCode = "N/a";
        private string shipCountry = "N/a";

        // Total number of Orders created
        private static int count = 0;



        // ********** Accessor Methods **********

        public int OrderID
        {
            // Read Only
            get
            {
                return orderID;
            }
        }

        public string CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                if (value != "")
                {
                    this.customerID = value;
                }
            }
        }

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }

            set
            {
                if (value > 0)
                {
                    this.employeeID = value;
                }
            }
        }

        public string OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                if (value != "")
                {
                    this.orderDate = value;
                }
            }
        }

        public string RequiredDate
        {
            get
            {
                return requiredDate;
            }

            set
            {
                if (value != "")
                {
                    this.requiredDate = value;
                }
            }
        }

        public string ShippedDate
        {
            get
            {
                return shippedDate;
            }

            set
            {
                if (value != "")
                {
                    this.shippedDate = value;
                }
            }
        }

        public int ShipVia
        {
            get
            {
                return shipVia;
            }

            set
            {
                if (value >= 0)
                {
                    this.shipVia = value;
                }
            }
        }

        public double Freight
        {
            get
            {
                return freight;
            }

            set
            {
                this.freight = value;
            }
        }

        public string ShipName
        {
            get
            {
                return shipName;
            }

            set
            {
                if (value != "")
                {
                    this.shipName = value;
                }
            }
        }

        public string ShipAddress
        {
            get
            {
                return shipAddress;
            }

            set
            {
                if (value != "")
                {
                    this.shipAddress = value;
                }
            }
        }

        public string ShipCity
        {
            get
            {
                return shipCity;
            }

            set
            {
                if (value != "")
                {
                    this.shipCity = value;
                }
            }
        }

        public string ShipRegion
        {
            get
            {
                return shipRegion;
            }

            set
            {
                if (value != "")
                {
                    this.shipRegion = value;
                }
            }
        }

        public string ShipPostalCode
        {
            get
            {
                return shipPostalCode;
            }

            set
            {
                if (value != "")
                {
                    this.shipPostalCode = value;
                }
            }
        }

        public string ShipCountry
        {
            get
            {
                return shipCountry;
            }

            set
            {
                if (value != "")
                {
                    this.shipCountry = value;
                }
            }
        }


        // ********** Constructors **********

        public Order()
        {
            // Increment counter
            Order.count++;

            // Default display interface will be TableRowDisplay
            SetDisplay(new TableRowDisplay());
        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, double aFreight, string aShipName, string aShipAddress, string aShipCity, string aShipRegion, string aShipPostalCode, string aShipCountry)
            : this()
        {
            this.orderID = anOrderID;
            this.CustomerID = aCustomerID;
            this.EmployeeID = anEmployeeID;
            this.OrderDate = anOrderDate;
            this.RequiredDate = aRequiredDate;
            this.ShippedDate = aShippedDate;
            this.ShipVia = aShipVia;
            this.Freight = aFreight;
            this.ShipName = aShipName;
            this.ShipAddress = aShipAddress;
            this.ShipCity = aShipCity;
            this.ShipRegion = aShipRegion;
            this.ShipPostalCode = aShipPostalCode;
            this.ShipCountry = aShipCountry;
        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, double aFreight, string aShipName, string aShipAddress, string aShipCity, string aShipRegion, string aShipPostalCode)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, aFreight, aShipName, aShipAddress, aShipCity, aShipRegion, aShipPostalCode, "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, double aFreight, string aShipName, string aShipAddress, string aShipCity, string aShipRegion)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, aFreight, aShipName, aShipAddress, aShipCity, aShipRegion, "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, double aFreight, string aShipName, string aShipAddress, string aShipCity)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, aFreight, aShipName, aShipAddress, aShipCity, "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, double aFreight, string aShipName, string aShipAddress)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, aFreight, aShipName, aShipAddress, "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, double aFreight, string aShipName)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, aFreight, aShipName, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, double aFreight)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, aFreight, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate, int aShipVia)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, -1, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate, string aShippedDate)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, -1, -1, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate, string aRequiredDate)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, "N/a", -1, -1, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID, string anOrderDate)
            : this(anOrderID, aCustomerID, anEmployeeID, anOrderDate, "N/a", "N/a", -1, -1, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID, int anEmployeeID)
            : this(anOrderID, aCustomerID, anEmployeeID, "N/a", "N/a", "N/a", -1, -1, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID, string aCustomerID)
            : this(anOrderID, aCustomerID, -1, "N/a", "N/a", "N/a", -1, -1, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Order(int anOrderID)
            : this(anOrderID, "N/a", -1, "N/a", "N/a", "N/a", -1, -1, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }


        // ********** Display Method **********
        public override string ToString ()
        {
            return Display(Order.attrList, this);
        }
    }
}
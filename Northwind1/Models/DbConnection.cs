using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data;
using Northwind1.Models;

namespace Northwind1.Models
{
    // Seal class to make it final
    // "DbConnection can not be subclassed"
    public sealed class DbConnection
    {
        // Start instance as null

        private static DbConnection instance = null;
        private List<Category> categoryList = null;
        private List<Product> productList = null;
        private List<Supplier> supplierList = null;
        private List<Order> orderList = null;
        private List<OrderDetail> orderDetailList = null;
        private IReaderFactory readerFactory;


        // Explicity create constructor to force it *private*

        private DbConnection()
        {
            this.SetReaderFactory(new OdbcReaderFactory());
            this.categoryList = GetCategories();
            this.productList = GetProducts();
            this.supplierList = GetSuppliers();
            this.orderList = GetOrders();
            this.orderDetailList = GetOrderDetails();
        }



        // Return new DbConnection (prevents more than one instance of DbConnection from being created)

        public static DbConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    return new DbConnection();
                }

                return Instance;
            }
        }



        // Accessors (read only)

        public List<Category> CategoryList
        {
            get
            {
                return this.categoryList;
            }
        }

        public List<Product> ProductList
        {
            get
            {
                return this.productList;
            }
        }

        public List<Supplier> SupplierList
        {
            get
            {
                return this.supplierList;
            }
        }

        public List<Order> OrderList
        {
            get
            {
                return this.orderList;
            }
        }

        public List<OrderDetail> OrderDetailList
        {
            get
            {
                return this.orderDetailList;
            }
        }


        // Configure reader factory
        public void SetReaderFactory (IReaderFactory factory)
        {
            this.readerFactory = factory;
        }



        // Category DB Connection

        public List<Category> GetCategories()
        {
            // Create list to hold Categories
            List<Category> categoryList = new List<Category>();

            // Create SQL query string
            string sql = "SELECT CategoryId, CategoryName, Description FROM Categories;";

            // Pass SQL to a ReaderFactory to get data reader
            IDataReader aReader = readerFactory.GetReader(sql);


            // Iterate through returned results
            while (aReader.Read())
            {
                // Get field values of current row
                int aCategoryId      = (int)aReader["categoryId"];
                string aCategoryName = (string)aReader["CategoryName"];
                string aDescription  = (string)aReader["Description"];
                
                // Create a Category object
                Category aCategory = new Category(aCategoryId, aCategoryName, aDescription);

                // Add record to categoryList
                categoryList.Add(aCategory);
            }

            return categoryList;
        }


        // Product DB Connection

        public List<Product> GetProducts()
        {
            // Create list to hold Products
            List<Product> productList = new List<Product>();

            // SQL query string
            string sql = "SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM Products;";

            // Pass SQL to a ReaderFactory to get data reader
            IDataReader aReader = readerFactory.GetReader(sql);

            // Iterate through returned results
            while (aReader.Read())
            {
                // Get field values of current row
                int aProductID          = (int)aReader["ProductID"];
                string aProductName     = (string)aReader["ProductName"];
                int aSupplierID         = (int)aReader["SupplierID"];
                int aCategoryID         = (int)aReader["CategoryID"];
                string aQuantityPerUnit = (string)aReader["QuantityPerUnit"];
                double aUnitPrice       = (double)(decimal)aReader["UnitPrice"];
                int aUnitsInStock       = (int)(short)aReader["UnitsInStock"];
                int aUnitsOnOrder       = (int)(short)aReader["UnitsOnOrder"];
                int aReorderLevel       = (int)(short)aReader["ReorderLevel"];
                string aDiscontinued    = ((bool)aReader["Discontinued"]) ? "TRUE" : "FALSE";

                // Create a Product object
                Product aProduct = new Product(aProductID, aProductName, aSupplierID, aCategoryID, aQuantityPerUnit, aUnitPrice, aUnitsInStock, aUnitsOnOrder, aReorderLevel, aDiscontinued);

                // Add record to productList
                productList.Add(aProduct);
            }

            return productList;
        }


        // Supplier DB Connection

        public List<Supplier> GetSuppliers()
        {
            // Create list to hold Suppliers
            List<Supplier> supplierList = new List<Supplier>();

            // SQL query string
            string sql = "SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage FROM Suppliers;";

            // Pass SQL to a ReaderFactory to get data reader
            IDataReader aReader = readerFactory.GetReader(sql);

            // Iterate through returned results
            while (aReader.Read())
            {
                // Get field values of current row
                // lines using .ToString() method will accept null values and return empty strings
                int aSupplierID      = (int)aReader["SupplierID"];
                string aCompanyName  = (string)aReader["CompanyName"];
                string aContactName  = (string)aReader["ContactName"];
                string aContactTitle = (string)aReader["ContactTitle"];
                string aAddress      = (string)aReader["Address"];
                string aCity         = (string)aReader["City"];
                string aRegion       = aReader["Region"].ToString();
                string aPostalCode   = (string)aReader["PostalCode"];
                string aCountry      = (string)aReader["Country"];
                string aPhone        = (string)aReader["Phone"];
                string aFax          = aReader["Fax"].ToString();
                string aHomePage     = aReader["HomePage"].ToString();

                // Create a Supplier object
                Supplier aSupplier = new Supplier(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, aCity, aRegion, aPostalCode, aCountry, aPhone, aFax, aHomePage);

                // Add record to supplierList
                supplierList.Add(aSupplier);
            }

            return supplierList;
        }


        // Order DB Connection
        public List<Order> GetOrders()
        {
            // Create list to hold Orders
            List<Order> orderList = new List<Order>();

            // SQL query string
            string sql = "SELECT * FROM Orders;";

            // Pass SQL to a ReaderFactory to get data reader
            IDataReader aReader = readerFactory.GetReader(sql);

            // Iterate through returned results
            while (aReader.Read())
            {
                // Get field values of current row
                // lines using .ToString() method will accept null values and return empty strings
                int anOrderID          = (int)aReader["OrderID"];
                string aCustomerID     = (string)aReader["CustomerID"];
                int anEmployeeID       = (int)aReader["EmployeeID"];
                string anOrderDate     = aReader["OrderDate"].ToString();
                string aRequiredDate   = aReader["RequiredDate"].ToString();
                string aShippedDate    = aReader["ShippedDate"].ToString();
                int aShipVia           = (int)aReader["ShipVia"];
                double aFreight        = (double)(decimal)aReader["Freight"];
                string aShipName       = (string)aReader["ShipName"];
                string aShipAddress    = (string)aReader["ShipAddress"];
                string aShipCity       = (string)aReader["ShipCity"];
                string aShipRegion     = aReader["ShipRegion"].ToString();
                string aShipPostalCode = aReader["ShipPostalCode"].ToString();
                string aShipCountry    = (string)aReader["ShipCountry"];

                // Create a Order object
                Order anOrder = new Order(anOrderID, aCustomerID, anEmployeeID, anOrderDate, aRequiredDate, aShippedDate, aShipVia, aFreight, aShipName, aShipAddress, aShipCity, aShipRegion, aShipPostalCode, aShipCountry);

                // Add record to orderList
                orderList.Add(anOrder);
            }

            return orderList;
        }


        // Order DB Connection
        public List<OrderDetail> GetOrderDetails()
        {
            // Create list to hold OrderDetails
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            // SQL query string
            string sql = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM `Order Details`;";

            // Pass SQL to a ReaderFactory to get data reader
            IDataReader aReader = readerFactory.GetReader(sql);

            // Iterate through returned results
            while (aReader.Read())
            {
                // Get field values of current row
                // lines using .ToString() method will accept null values and return empty strings
                int anOrderID = (int)aReader["OrderID"];
                int aProductID = (int)aReader["ProductID"];
                double aUnitPrice = (double)(decimal)aReader["UnitPrice"];
                int aQuantity = (int)(short)aReader["Quantity"];
                double aDiscount = Convert.ToDouble(aReader["Discount"]);

                // Create a OrderDetail object
                OrderDetail anOrderDetail = new OrderDetail(anOrderID, aProductID, aUnitPrice, aQuantity, aDiscount);

                // Add record to orderDetailList
                orderDetailList.Add(anOrderDetail);
            }

            return orderDetailList;
        }
    }
}
using Northwind1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DisplayInterfaceTest ( string model = "Product" )
        {
            switch (model)
            {
                case "Product":
                    ViewBag.attrList = Product.attrList;
                    ViewBag.dataList = connection.ProductList;
                    break;

                case "Supplier":
                    ViewBag.attrList = Supplier.attrList;
                    ViewBag.datalist = connection.SupplierList;
                    break;

                case "Category":
                    ViewBag.attrList = Category.attrList;
                    ViewBag.dataList = connection.CategoryList;
                    break;

                case "Order":
                    ViewBag.attrList = Order.attrList;
                    ViewBag.dataList = connection.OrderList;
                    break;
                
                case "OrderDetail":
                    ViewBag.attrList = OrderDetail.attrList;
                    ViewBag.dataList = connection.OrderDetailList;
                    break;

                default:
                    break;
            }

            return View();
        }



        // Instantiate DbConnection
        // Upon this instantiation, connection will hold CategoryList, ProductList, SupplierList and OrderList within it
        private DbConnection connection = DbConnection.Instance;



        // Render Index page
        public ActionResult Index()
        {
            // Make productList available to the View
            ViewBag.productList = connection.ProductList;
    
            // Return Index.cshtml
            return View();
        }



        // Render page that will list all products
        public ActionResult ListProducts()
        {
            // Make list of Products accessable by view
            ViewBag.productList = connection.ProductList;

            // Return ListProducts.cshtml
            return View();
        }



        // Render page to browse products by min and max price
        public ActionResult ListByPrice(double min = -1, double max = -1)
        {
            // If parameters have not been set
            if (min < 0 && max < 0)
            {
                // Pass list of all products to View
                ViewBag.productList = (from p in connection.ProductList
                                       orderby p.UnitPrice
                                       select p).ToList();
            }

            // If min has not been set or is negative
            else if (min < 0)
            {
                // Pass products with unit price less than or equal to @max to View
                ViewBag.productList = (from p in connection.ProductList
                                       where p.UnitPrice <= max
                                       orderby p.UnitPrice
                                       select p).ToList();
            }

            // If max has not been set or is negative
            else if (max < 0)
            {
                // Pass products with unit price greater than or equal to @min to View
                ViewBag.productList = (from p in connection.ProductList
                                       where p.UnitPrice >= min
                                       orderby p.UnitPrice
                                       select p).ToList();
            }

            // If parameters were both set and valid
            else
            {
                // Pass products with a unit price between @min and @max to View
                ViewBag.productList = (from p in connection.ProductList
                                       where p.UnitPrice <= max
                                       where p.UnitPrice >= min
                                       orderby p.UnitPrice
                                       select p).ToList();
            }


            // Pass min and max back to View if they are valid
            ViewBag.min = (min > 0) ? min.ToString() : "";
            ViewBag.max = (max > 0) ? max.ToString() : "";


            // Return ListByPrice.cshtml
            return View();
        }



        // Render page to browse products by category
        public ActionResult ListByCategory(int id = -1)
        {
            // Make list of Categories accessable by the view 
            ViewBag.categoryList = connection.CategoryList;


            // If @id has default value (-1) pass all products to View
            if (id == -1)
            {
                ViewBag.categorySelection = new Category();
                ViewBag.productList = connection.ProductList;
            }

            // If @id has been explicitly set, pass products with that CategoryID TO VIEW
            else
            {
                ViewBag.categorySelection = (from c in connection.CategoryList
                                                     where c.CategoryID == id
                                                     select c).FirstOrDefault();


                ViewBag.productList = from p in connection.ProductList
                                      where p.CategoryID == id
                                      select p;
            }


            // Return ListByCategory.cshtml
            return View();
        }



        // Render page to browse products by supplier
        public ActionResult ListBySupplier(int id = -1)
        {
            // Make list of Suppliers accessable by view
            ViewBag.supplierList = connection.SupplierList;


            // If @id has default value (-1) pass all products to View
            if (id == -1)
            {
                ViewBag.supplierSelection = new Supplier();
                ViewBag.productList = connection.ProductList;
            }

            // If @id has been explicitly set, pass products with that SupplierID TO VIEW
            else
            {
                ViewBag.supplierSelection = (from s in connection.SupplierList
                                             where s.SupplierID == id
                                             select s).FirstOrDefault();


                ViewBag.productList = from p in connection.ProductList
                                      where p.SupplierID == id
                                      select p;
            }


            // Return ListBySuppliers.cshtml
            return View();
        }

        

        // Render detailed information about a specific product
        public ActionResult ProductDetails(int id)
        {
            // Get product who's ProductID matches the id parameter
            Product aProduct = (from p in connection.ProductList
                                where p.ProductID == id
                                select p)
                               .FirstOrDefault();

            // Get the name of corresponding category
            string aCategoryName = (from c in connection.CategoryList
                                    where c.CategoryID == aProduct.CategoryID
                                    select c.CategoryName)
                                   .FirstOrDefault();

            // Get the name of corresponding supplier
            string aSupplierName = (from s in connection.SupplierList
                                    where s.SupplierID == aProduct.SupplierID
                                    select s.CompanyName)
                                   .FirstOrDefault();


            // Pass Product to View
            ViewBag.product = aProduct;

            // Pass Category name to View
            ViewBag.categoryName = aCategoryName;

            // Pass Supplier name to View
            ViewBag.supplierName = aSupplierName;

            return View();
        }



        // Render list of orders (no id argument) or details about a specific order (id < -1)
        public ActionResult Orders(int id = -1)
        {
            // If no Order has been selected
            if (id == -1)
            {
                // Provide list of all Orders to View
                ViewBag.orderList = connection.OrderList;

                // Render ListOrders.cshtml
                return View("ListOrders");
            }
            
            // Order[id] has been selected...
            else
            {
                // pass it to the view...
                ViewBag.orderSelection = (from o in connection.OrderList
                                          where o.OrderID == id
                                          select o).FirstOrDefault();

                // along with the products in that order...
                ViewBag.productList = from od in connection.OrderDetailList
                                      join o in connection.OrderList on od.OrderID equals o.OrderID
                                      join p in connection.ProductList on od.ProductID equals p.ProductID
                                      where o.OrderID == id
                                      select p;
    

                // and render the OrderDetails.cshtml.
                return View("OrderDetails");
            }
        }
    }
}
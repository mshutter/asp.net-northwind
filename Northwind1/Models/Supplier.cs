using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind1.Models
{
    public class Supplier : NWDataModel
    {
        // Static list of attributes used for display methods
        public static List<string> attrList = new List<string>(
            new string[] {
                "SupplierID",
                "CompanyName",
                "ContactName",
                "ContactTitle",
                "Address",
                "City",
                "Region",
                "PostalCode",
                "Country",
                "Phone",
                "Fax",
                "HomePage"
            });

        // ********** Private Variables **********

        private int supplierID = -1;
        private string companyName = "N/a";
        private string contactName = "N/a";
        private string contactTitle = "N/a";
        private string address = "N/a";
        private string city = "N/a";
        private string region = "N/a";
        private string postalCode = "N/a";
        private string country = "N/a";
        private string phone = "N/a";
        private string fax = "N/a";
        private string homePage = "N/a";

        // Number of Suppliers
        public static int count = 0;
        

        // ********** Accessor Methods **********

        public int SupplierID
        {
            // Read only
            get
            {
                return this.supplierID;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                this.companyName = value;
            }
        }

        public string ContactName
        {
            get
            {
                return this.contactName;
            }

            set
            {
                this.contactName = value;
            }
        }

        public string ContactTitle
        {
            get
            {
                return this.contactTitle;
            }

            set
            {
                this.contactTitle = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
            }
        }

        public string Region
        {
            get
            {
                return this.region;
            }

            set
            {
                this.region = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return this.postalCode;
            }

            set
            {
                this.postalCode = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                this.country = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            
            set
            {
                this.phone = value;
            }
        }

        public string Fax
        {
            get
            {
                return this.fax;
            }

            set
            {
                this.fax = value;
            }
        }

        public string HomePage
        {
            get
            {
                return this.homePage;
            }

            set
            {
                this.homePage = value;
            }
        }


        // ********** Constructors **********

        public Supplier ()
        {
            // Each time a Supplier is created, add +1 to static counter
            Supplier.count++;

            // Set Display interface
            SetDisplay(new TableRowDisplay());
        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity, string aRegion, string aPostalCode, string aCountry, string aPhone, string aFax, string aHomePage)
            : this()
        {
            this.supplierID = aSupplierID;
            this.CompanyName = aCompanyName;
            this.ContactName = aContactName;
            this.ContactTitle = aContactTitle;
            this.Address = aAddress;
            this.City = aCity;
            this.Region = aRegion;
            this.PostalCode = aPostalCode;
            this.Country = aCountry;
            this.Phone = aPhone;
            this.Fax = aFax;
            this.HomePage = aHomePage;
        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity, string aRegion, string aPostalCode, string aCountry, string aPhone, string aFax)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, aCity, aRegion, aPostalCode, aCountry, aPhone, aFax, "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity, string aRegion, string aPostalCode, string aCountry, string aPhone)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, aCity, aRegion, aPostalCode, aCountry, aPhone, "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity, string aRegion, string aPostalCode, string aCountry)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, aCity, aRegion, aPostalCode, aCountry, "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity, string aRegion, string aPostalCode)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, aCity, aRegion, aPostalCode, "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity, string aRegion)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, aCity, aRegion, "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress, string aCity)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, aCity, "N/a", "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle, string aAddress)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, aAddress, "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName, string aContactTitle)
            : this(aSupplierID, aCompanyName, aContactName, aContactTitle, "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName, string aContactName)
            : this(aSupplierID, aCompanyName, aContactName, "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID, string aCompanyName)
            : this(aSupplierID, aCompanyName, "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }

        public Supplier(int aSupplierID)
            : this(aSupplierID, "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a", "N/a")
        {

        }


        // ********** Display Method **********
        public override string ToString()
        {
            return Display(Supplier.attrList, this);
        }
    }
}
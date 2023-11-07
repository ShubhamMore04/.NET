using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace CA_Customer_Data
{
    internal class Program
    {
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            //PrintCustomerInfo();
            //AddCustomer();
            CustomerDisplay();
            SearchCustomerId(); 
            SearchCustomerName();
            DeleCustomer();
            GetCustmerList();
        }

        static void GetAppSettingsFile()
        {
            var bulider = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true);
            _configuration = bulider.Build();
        }

        /*static void PrintCustomerInfo()
        {
            CustomerInfo obj = new CustomerInfo(_configuration);
            obj.CustomersInfo(); 
        }*/

        static void AddCustomer()
        {
            Console.WriteLine("ADD CUSTOMER :");
            Strongly_type indata = new Strongly_type(_configuration);
            Customers p1 = new Customers {Id = 100, Name = "Kalpesh", Address = "Airoli", Mobile_No = "9879849849" };
            int a = indata.AddData(p1);
            Console.WriteLine("{0}", a);

            Console.WriteLine("--------------------------------------");
        }

        static void CustomerDisplay()
        {
            Console.WriteLine("DISPLAY CUSTOMER LIST :");
            Strongly_type indata = new Strongly_type(_configuration);
            indata.PrintCustomer();

            Console.WriteLine("--------------------------------------");
        }

        static void SearchCustomerId()
        {
            Console.WriteLine("SEARCH CUSTOMER WITH ID :");

            Strongly_type indata = new Strongly_type(_configuration);
            Customers r = indata.SearchCustomerId(3);
            Console.WriteLine("{0} {1} {2} {3}", r.Id, r.Name, r.Address, r.Mobile_No);

            Console.WriteLine("--------------------------------------");
        }

        static void SearchCustomerName()
        {
            Console.WriteLine("SEARCH CUSTOMER WITH NAME :");

            Strongly_type indata = new Strongly_type(_configuration);
            List<Customers> pl = indata.SearchCustomerName("Akshay");
            if(pl != null) 
            {
                foreach (var x in pl)
                {
                    Console.WriteLine("{0} {1} {2} {3}", x.Id, x.Name, x.Address, x.Mobile_No);
                }
            }
            else
            {
                Console.WriteLine("Records with Akshsy is not Found");
            }

            Console.WriteLine("--------------------------------------");
        }

        static void DeleCustomer()
        {
            Console.WriteLine("DELETE CUSTOMER WITH ID :");

            Strongly_type indata = new Strongly_type(_configuration);
            int ID = 7;
            int no = indata.DelCustomer(ID);
            Console.WriteLine("Deleted Customer ID = {0}", ID);

            Console.WriteLine("--------------------------------------");
        }

        static void GetCustmerList()
        {
            Console.WriteLine("SHOW CUSTOMER LIST :");

            Strongly_type indata = new Strongly_type(_configuration);
            List<Customers> ls = indata.GetCustomers();
            foreach (var x in ls)
            {
                Console.WriteLine("{0} {1} {2} {3}", x.Id, x.Name, x.Address, x.Mobile_No);
            }

            Console.WriteLine("--------------------------------------");

            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class SaleDetails
    {
        int SalesNo;
        int ProductNo;
        double Price;
        DateTime dateTime;
        int Quantity;
        double TotalAmt;


        static void Main()
        {
            SaleDetails sd = new SaleDetails(1874, 0042, 542, 3, dateTime: DateTime.Now);
            sd.Sales();
            sd.ShowData();
            Console.Read();
        }

        // Constructor for Sales details-----
        SaleDetails(int SalesNo, int ProductNo, double Price, int Quantity, DateTime dateTime)
        {
            this.SalesNo = SalesNo;
            this.ProductNo = ProductNo;
            this.Price = Price;
            this.Quantity = Quantity;
            this.dateTime = dateTime;
        }

        public void Sales()
        {
            TotalAmt = Quantity * Price;
        }
        //Showing the Equivalent Data
        public void ShowData()
        {
            Console.WriteLine("Sale Details-> ");
            Console.WriteLine($"Sales Number: {SalesNo}");
            Console.WriteLine($"Product Number: {ProductNo}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Total Amount: {TotalAmt}");
            Console.WriteLine($"Date of Sale: : {dateTime}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Customer
    {
        static int Cust_ID;
        static string Name;
        static int Age;
        static string Mobile_No;
        static string City;

        public Customer()
        {
        }
        public Customer(int Cust_Id, string name, int age, string mobile_No, string city)
        {
            Cust_ID = Cust_Id;
            Name = name;
            Age = age;
            Mobile_No = mobile_No;
            City = city;
        }

        ~Customer()       // Destructor
        {
            Console.WriteLine("Object has Destroyed successfully !");
            Console.Read();
        }
        static void DisplayCustomer()
        {
            Console.WriteLine($"Customer Id: {Cust_ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Phone Number: {Mobile_No}");
            Console.WriteLine($"City: {City}");

        }
        static void Main()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer(1, "Mahesh", 22, "1034340", "BENGALURU");  //Parameterized constructor
            Console.WriteLine("Customer Information");
            DisplayCustomer();  //Static function   
            //customer2.Instance();
            customer1 = null;
            customer2 = null;
            GC.Collect();
            Console.Read();
        }
    }
}
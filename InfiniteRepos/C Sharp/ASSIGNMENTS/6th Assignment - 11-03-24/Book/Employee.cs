using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public float Salary { get; set; }

        // Constructor to initialize Empid, Empname, and Salary
        public Employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }
    }

    class ParttimeEmployee : Employee
    {
        public float Wages { get; set; }

        // Constructor to initialize base class and Wages
        public ParttimeEmployee(int empid, string empname, float salary, float wages)
            : base(empid, empname, salary)
        {
            Wages = wages;
        }
    }

    class PartTimeEmployee
    {
        static void Main()
        {
            // Instantiate a ParttimeEmployee object
            ParttimeEmployee parttimeEmp = new ParttimeEmployee(empid: 1034340, empname: "Mahesh Sekhar Sahu", salary: 450000, wages: 35000);

            // Display employee details
            Console.WriteLine($"Employee ID: {parttimeEmp.Empid}");
            Console.WriteLine($"Employee Name: {parttimeEmp.Empname}");
            Console.WriteLine($"Salary: {parttimeEmp.Salary}");
            Console.WriteLine($"Wages (Part-time): {parttimeEmp.Wages}");
            Console.ReadKey();
        }
    }
}

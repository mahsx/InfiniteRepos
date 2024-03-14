using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of employees
            List<Employee> empList = new List<Employee>
            {

                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 1, 6), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 6, 11), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 3, 12), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            // LINQ queries
            Console.WriteLine("a. Details of all employees:");
            foreach (var emp in empList)
            {
                Console.WriteLine($"{emp.EmployeeID} - {emp.FirstName} {emp.LastName}, {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
            }

            Console.WriteLine("\nb. Employees not in Mumbai:");
            var nonMumbaiEmployees = empList.Where(emp => emp.City != "Mumbai");
            foreach (var emp in nonMumbaiEmployees)
            {
                Console.WriteLine($"{emp.EmployeeID} - {emp.FirstName} {emp.LastName}, City: {emp.City}");
            }

            Console.WriteLine("\nc. Employees with title 'AsstManager':");
            var asstManagers = empList.Where(emp => emp.Title == "AsstManager");
            foreach (var emp in asstManagers)
            {
                Console.WriteLine($"{emp.EmployeeID} - {emp.FirstName} {emp.LastName}, Title: {emp.Title}");
            }

            Console.WriteLine("\nd. Employees with last name starting with 'S':");
            var lastNameStartsWithS = empList.Where(emp => emp.LastName.StartsWith("S"));
            foreach (var emp in lastNameStartsWithS)
            {
                Console.WriteLine($"{emp.EmployeeID} - {emp.FirstName} {emp.LastName}");
            }
            Console.ReadKey();
        }
    }
}

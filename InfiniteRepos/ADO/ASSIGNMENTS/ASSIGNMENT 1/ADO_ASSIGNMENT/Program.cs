using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
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
    static void Main()
    {

        List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 6, 11), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 3, 12), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
        };

        // 1. Display a list of all the employees who have joined before 1/1/2015
        var before2015 = empList.Where(emp => emp.DOJ < new DateTime(2015, 1, 1)).ToList();
        Console.WriteLine("1.Employees who joined before 1/1/2015:");
        foreach (var emp in before2015)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} ({emp.DOJ:d})");
        }

        // 2. Display a list of all the employees whose date of birth is after 1/1/1990
        var after1990 = empList.Where(emp => emp.DOB > new DateTime(1990, 1, 1)).ToList();
        Console.WriteLine("\n2. Employees with date of birth after 1/1/1990:");
        foreach (var emp in after1990)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} ({emp.DOB:d})");
        }

        // 3. Display a list of all the employees whose designation is Consultant and Associate
        var consultantsAndAssociates = empList.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate").ToList();
        Console.WriteLine("\n3. Employees with designation Consultant or Associate:");
        foreach (var emp in consultantsAndAssociates)
        {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} ({emp.Title})");
        }

        // 4. Display total number of employees
        int totalEmployees = empList.Count;
        Console.WriteLine($"\n4. Total number of employees: {totalEmployees}");

        // 5. Display total number of employees belonging to “Chennai”
        int employeesInChennai = empList.Count(emp => emp.City == "Chennai");
        Console.WriteLine($"5. Total number of employees in Chennai: {employeesInChennai}");

        // 6. Display highest employee id from the list
        int highestEmployeeId = empList.Max(emp => emp.EmployeeID);
        Console.WriteLine($"6. Highest Employee ID: {highestEmployeeId}");

        // 7. Display total number of employees who have joined after 1/1/2015
        int employeesJoinedAfter2015 = empList.Count(emp => emp.DOJ > new DateTime(2015, 1, 1));
        Console.WriteLine($"7. Total number of employees who joined after 1/1/2015: {employeesJoinedAfter2015}");

        // 8. Display total number of employees whose designation is not “Associate”
        int nonAssociateEmployees = empList.Count(emp => emp.Title != "Associate");
        Console.WriteLine($"8. Total number of employees with designation not Associate: {nonAssociateEmployees}");

        // 9. Display total number of employees based on City
        var employeesByCity = empList.GroupBy(emp => emp.City).Select(g => new { City = g.Key, Count = g.Count() });
        Console.WriteLine("\n9. Total number of employees based on City:");
        foreach (var group in employeesByCity)
        {
            Console.WriteLine($"{group.City}: {group.Count}");
        }

        // 10. Display total number of employees based on city and title
        var employeesByCityAndTitle = empList.GroupBy(emp => new { emp.City, emp.Title }).Select(g => new { g.Key.City, g.Key.Title, Count = g.Count() });
        Console.WriteLine("\n10. Total number of employees based on City and Title:");
        foreach (var group in employeesByCityAndTitle)
        {
            Console.WriteLine($"{group.City} - {group.Title}: {group.Count}");
        }

        // 11. Display total number of employees who are youngest in the list
        var youngestEmployee = empList.OrderBy(emp => emp.DOB).First();
        var youngestEmployeesCount = empList.Count(emp => emp.DOB == youngestEmployee.DOB);
        Console.WriteLine($"\n11.Total number of employees who are youngest in the list: {youngestEmployeesCount}");

        Console.ReadLine();
    }
}

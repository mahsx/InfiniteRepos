using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    private static string connectionString = "Server=ICS-LT-4XYM473\\SQLEXPRESS;Database=Employeemanagement;Integrated Security=True;";

    static void Main()
    {
        // Create the stored procedure if it doesn't exist
        CreateStoredProcedure();

        // Take input from the user
        Console.Write("Enter employee name: ");
        string empName = Console.ReadLine();

        Console.Write("Enter employee salary: ");
        decimal empSal;
        while (!decimal.TryParse(Console.ReadLine(), out empSal) || empSal < 25000)
        {
            Console.WriteLine("Salary should be a whole value and at least 25000. Please try again.");
            Console.Write("Enter employee salary: ");
        }

        Console.Write("Enter employee type (P , C ): ");
        char empType;
        while (!char.TryParse(Console.ReadLine(), out empType) || (empType != 'P' && empType != 'C'))
        {
            Console.WriteLine("Invalid type. Please enter 'P' or 'C' ");
            Console.Write("Enter employee type (P , C ): ");
        }

        // Insert employee details using the stored procedure
        InsertEmployee(empName, empSal, empType);

        // Display all employee rows
        DisplayEmployeeDetails();

        Console.ReadLine();
    }

    static void CreateStoredProcedure()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connection;
            command.CommandText = @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddEmployee')
                BEGIN
                    EXEC('
                    CREATE PROCEDURE AddEmployee
                        @EmpName VARCHAR(50),
                        @Empsal NUMERIC(10,2),
                        @Emptype CHAR(1)
                    AS
                    BEGIN
                        DECLARE @Empno INT;

                        -- Generate Empno
                        SELECT @Empno = ISNULL(MAX(Empno), 0) + 1 FROM Employee_Details;

                        -- Insert into Employee_Details table
                        INSERT INTO Employee_Details (Empno, EmpName, Empsal, Emptype)
                        VALUES (@Empno, @EmpName, @Empsal, @Emptype);
                    END
                    ');
                END;
            ";

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    static void InsertEmployee(string empName, decimal empSal, char empType)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand("AddEmployee", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmpName", empName);
            command.Parameters.AddWithValue("@Empsal", empSal);
            command.Parameters.AddWithValue("@Emptype", empType);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    static void DisplayEmployeeDetails()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand("SELECT * FROM Employee_Details", connection))
        {
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Empno: {reader["Empno"]}, EmpName: {reader["EmpName"]}, Empsal: {reader["Empsal"]}, Emptype: {reader["Emptype"]}");
                }
            }
        }
    }
}

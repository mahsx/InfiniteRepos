CREATE DATABASE Employeemanagement

USE Employeemanagement

CREATE TABLE Employee_Details (
    Empno INT PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    Empsal NUMERIC(10,2) CHECK (Empsal >= 25000),
    Emptype CHAR CHECK (Emptype IN ('P', 'C'))
)

SELECT * FROM Employee_Details

delete from Employee_Details
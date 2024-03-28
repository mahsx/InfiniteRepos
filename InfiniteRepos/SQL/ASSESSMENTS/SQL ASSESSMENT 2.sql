USE InfiniteAssignment

--1. Write a query to display your birthday ( day of week)

SELECT DATENAME(WEEKDAY, '2022-02-28') AS Birthday_Day_Of_Week
--or
SELECT DATENAME(DW, '2022-02-28') AS Birthday_Day_Of_Week

/* OUTPUT

Birthday_Day_Of_Week
------------------------------
Monday

*/

--2. Write a query to display your age in days

SELECT DATEDIFF(day, '2001-02-28', GETDATE()) AS Age_In_Days
--or
SELECT CAST(GETDATE() - '2001-02-28' AS INT) AS Age_In_Days

/* OUTPUT

Age_In_Days
-----------
8429

*/

--3. Write a query to display all employees information those who joined before 5 years in the current month

SELECT * FROM EMPLOYEE

ALTER TABLE Employee
ADD HireDate DATE;

UPDATE Employee
SET HireDate = DATEADD(YEAR, -(ID + 1), GETDATE())
WHERE ID BETWEEN 1 AND 7;

SELECT HireDate FROM EMPLOYEE

/*
THERE WAS A TRIGGER WHICH I USED IN EMP TABLE SO I COULD NOT USE THAT SO I USED THE EMPLOYEE TABLE AND ADDED 
ANOTHER COLUMN NAMED AS HIREDATE AND UPDATED THE VALUE AS PER THE QUESTION.
HireDate
----------
2022-03-28
2021-03-28
2020-03-28
2019-03-28
2018-03-28
2017-03-28
2016-03-28

*/

-- MAIN PROGRAM FOR THE QUESTION 3

SELECT id,hiredate,SALARY FROM Employee
WHERE YEAR(HireDate) <= YEAR(GETDATE()) - 5
  AND MONTH(HireDate) = MONTH(GETDATE())

/*
Output

id          hiredate   SALARY
----------- ---------- ---------
4           2019-03-28 6500.00
5           2018-03-28 8500.00
6           2017-03-28 9453.00
7           2016-03-28 22321.00

*/

/* 4 . Create table Employee with empno, ename, sal, doj columns and perform the following operations in a single transaction
			a. First insert 3 rows 
			b. Update the second row sal with 15% increment  
			c. Delete first row.
		After completing above all actions how to recall the deleted row without losing increment of second row.
*/

--ANS

CREATE TABLE EmployeeINFINITE (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal DECIMAL,
    doj DATE)

	--EMPLOYEE INFINITE TABLE CREATED

BEGIN TRANSACTION;

					-- a. INSERTING 3 ROWS BELOW
					INSERT INTO EmployeeINFINITE (empno, ename, sal, doj)
					VALUES 
						(1, 'MAHESH', 50000.00, '2022-01-01'),
						(2, 'SURESH', 60000.00, '2022-01-02'),
						(3, 'RAMESH', 55000.00, '2022-01-03')

					-- b. Update the second row salary with 15% increment
					UPDATE EmployeeINFINITE
					SET sal = sal * 1.15  -- 15% INCREMENT MEANS 100+15% SO I WROTE 1.15
					WHERE empno = 2

					-- c. Delete first row 
					CREATE TABLE DeletedINFINITEEmployee (
						empno INT PRIMARY KEY,
						ename VARCHAR(50),
						sal DECIMAL,
						doj DATE)

					INSERT INTO DeletedINFINITEEmployee (empno, ename, sal, doj)
					SELECT empno, ename, sal, doj
					FROM EmployeeINFINITE
					WHERE empno = 1;

					DELETE FROM EmployeeINFINITE WHERE empno = 1;

-- Commit transaction if all operations are successful
COMMIT

SELECT * FROM EmployeeINFINITE

/*

empno       ename                                              sal                                     doj
----------- -------------------------------------------------- --------------------------------------- ----------
2           SURESH                                             69000                                   2022-01-02
3           RAMESH                                             55000                                   2022-01-03

*/

--Recalling the deleted row From the deleted table

INSERT INTO EmployeeINFINITE (empno, ename, sal, doj)
SELECT empno, ename, sal, doj
FROM DeletedINFINITEEmployee
WHERE empno = 1;

SELECT * FROM EmployeeINFINITE where empno = 1
SELECT * FROM EmployeeINFINITE

/*

empno       ename                                              sal                                     doj
----------- -------------------------------------------------- --------------------------------------- ----------
1           MAHESH                                             50000                                   2022-01-01
2           SURESH                                             69000                                   2022-01-02
3           RAMESH                                             55000                                   2022-01-03

*/

/*
5.Create a user defined function calculate Bonus for all employees of a  given job using 	following conditions
	a.     For Deptno 10 employees 15% of sal as bonus.
	b.     For Deptno 20 employees  20% of sal as bonus
	c      For Others employees 5%of sal as bonus
*/

-- Create the function

CREATE FUNCTION CalculateBonus (@empJob VARCHAR(50))

RETURNS DECIMAL
AS
BEGIN
    DECLARE @bonus DECIMAL

    -- Calculate bonus based on job
    SELECT @bonus =
        CASE 
            WHEN @empJob = 'CLERK' AND Deptno = 10 THEN Sal * 0.15
            WHEN @empJob = 'MANAGER' AND Deptno = 20 THEN Sal * 0.20
            ELSE Sal * 0.05
        END
    FROM EMP
    WHERE JOB = @empJob;

    RETURN @bonus;
END;

DECLARE @empJob VARCHAR(50) = 'CLERK'


DECLARE @bonus DECIMAL
SET @bonus = dbo.CalculateBonus(@empJob)

-- Display the calculated bonus
SELECT @bonus AS BonusAmount

/*
BonusAmount
--------------
195.00

*/


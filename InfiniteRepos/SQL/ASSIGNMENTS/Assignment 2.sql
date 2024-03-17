-- Create EMP table
CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    job VARCHAR(50),
    mgr_id INT,
    hiredate DATE,
    sal INT,
    comm INT,
    deptno INT
);

-- Insert data into EMP table
INSERT INTO EMP (empno, ename, job, mgr_id, hiredate, sal, comm, deptno) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

-- Create DEPT table
CREATE TABLE DEPT (
    deptno INT PRIMARY KEY,
    dname VARCHAR(50),
    loc VARCHAR(50)
);

-- Insert data into DEPT table
INSERT INTO DEPT (deptno, dname, loc) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

-- List all employees whose name begins with 'A' (1)
SELECT * FROM EMP WHERE ENAME LIKE 'A%';

-- Select all those employees who don't have a manager (2)
SELECT * FROM EMP WHERE MGR_ID IS NULL;

-- List employee name, number, and salary for those employees who earn in the range 1200 to 1400 (3)
SELECT ENAME, EMPNO, SAL FROM EMP WHERE SAL BETWEEN 1200 AND 1400;

-- Give all the employees in the RESEARCH department a 10% pay rise. Verify before and after the rise (4)
-- Before the pay rise
SELECT * FROM EMP WHERE DEPTNO = 20;

-- Give a 10% pay rise to employees in the RESEARCH department
UPDATE EMP SET SAL = (SAL + ((sal/100)* 10)) WHERE DEPTNO = 20;

-- After the pay rise
SELECT * FROM EMP WHERE DEPTNO = 20;

-- Find the number of CLERKS employed (5)
SELECT COUNT(*) AS "Number of Clerks" FROM EMP WHERE JOB = 'CLERK';

-- Find the average salary for each job type and the number of people employed in each job (6)
SELECT JOB, AVG(SAL) AS "Average Salary", COUNT(*) AS "Number of Employees" 
FROM EMP
GROUP BY JOB;


-- List the employees with the lowest and highest salary (7)
SELECT * FROM EMP WHERE SAL IN (SELECT MIN(SAL) FROM EMP UNION SELECT MAX(SAL) FROM EMP);

-- List full details of departments that don't have any employees (8)
SELECT * FROM DEPT WHERE DEPTNO NOT IN (SELECT DISTINCT DEPTNO FROM EMP);

-- Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort by name (9)
SELECT ENAME, SAL FROM EMP WHERE JOB = 'ANALYST' AND SAL > 1200 AND DEPTNO = 20 ORDER BY ENAME ASC;

-- For each department, list its name and number together with the total salary paid to employees in that department (10)
SELECT DNAME, DEPTNO, SUM(SAL) AS "Total Salary" 
FROM EMP 
RIGHT JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO 
GROUP BY DNAME, DEPTNO;

-- Find out salary of both MILLER and SMITH (11)
SELECT ENAME, SAL FROM EMP WHERE ENAME IN ('MILLER', 'SMITH');

-- Find out the names of the employees whose name begin with ‘A’ or ‘M’ (12)
SELECT ENAME FROM EMP WHERE ENAME LIKE 'A%' OR ENAME LIKE 'M%';

-- Compute yearly salary of SMITH (13)
SELECT SAL * 12 AS "Yearly Salary" FROM EMP WHERE ENAME = 'SMITH';

-- List the name and salary for all employees whose salary is not in the range of 1500 and 2850 (14)
SELECT ENAME, SAL FROM EMP WHERE SAL NOT BETWEEN 1500 AND 2850;

-- Find all managers who have more than 2 employees reporting to them (15)
SELECT MGR_ID, COUNT(*) AS "Number of Employees"
FROM EMP
WHERE JOB = 'MANAGER'
GROUP BY MGR_ID
HAVING COUNT(*) > 2;

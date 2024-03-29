use InfiniteAssignment

-- 1. Retrieve a list of MANAGERS. 
select * from EMP where job = 'manager' 

--2. Find out the names and salaries of all employees earning more than 1000 per month. 
select ename,sal from EMP WHERE SAL>1000 

--3. Display the names and salaries of all employees except JAMES. 
select ename, sal from EMP where ename <> 'JAMES'
--4. Find out the details of employees whose names begin with �S�. 
select * from EMP where ename like 's%'
--5. Find out the names of all employees that have �A� anywhere in their name. 
select * from EMP where ename like '%a%'
--6. Find out the names of all employees that have �L� as their third character in their name. 
select * from EMP where ename like '__L%'
--7. Compute daily salary of JONES. 
select sal/30 AS 'daily salary' from EMP where ename = 'jones'

--8. Calculate the total monthly salary of all employees. 
select sum(sal) as total_monthly_salary from emp
--9. Print the average annual salary .
select avg(sal) as average_annual_salary from emp
--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
select ename,job,sal,deptno from EMP where job <> 'salesman' and  deptno=30
--11. List unique departments of the EMP table. 
select distinct deptno from EMP
--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as "Employee", sal as "Monthly Salary", deptno 
from emp 
where sal > 1500 
and (deptno = 10 or deptno = 30)
--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename, job, sal 
from emp 
where (job = 'manager' or job = 'analyst') 
and sal not in (1000, 3000, 5000)
--14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
select ename,sal,comm from emp where comm > sal*1.1
--15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 
select ename from EMP where ename like '%l%l' and deptno ='30' or mgr_id='7782'
--16. Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees.
select ename from emp
where hiredate <= dateadd(year, -30, getdate())
and hiredate > dateadd(year, -40, getdate())
--17. Retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname, e.ename from dept d
join emp e on d.deptno = e.deptno
order by d.dname asc, e.ename desc
--18. Find out experience of MILLER. 
select datediff(year, hiredate, getdate()) as experience from emp
where ename = 'MILLER'
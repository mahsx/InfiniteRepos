use InfiniteAssignment

-- 1. Retrieve a list of MANAGERS. 
select * from EMP where job = 'manager' 

--2. Find out the names and salaries of all employees earning more than 1000 per month. 
select ename,sal from EMP WHERE SAL>1000 

--3. Display the names and salaries of all employees except JAMES. 
select ename, sal from EMP where ename <> 'JAMES'
--4. Find out the details of employees whose names begin with ‘S’. 
select * from EMP where ename like 's%'
--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select * from EMP where ename like '%a%'
--6. Find out the names of all employees that have ‘L’ as their third character in their name. 
select * from EMP where ename like '__L%'
--7. Compute daily salary of JONES. 
select sal/30 AS 'daily salary' from EMP where ename = 'jones'

--8. Calculate the total monthly salary of all employees. 
select sum(sal) as total_monthly_salary from emp
--9. Print the average annual salary .
select avg(sal) as average_annual_salary from emp
--10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
select ename,job,sal,deptno from EMP where job <> 'salesman'
--11. List unique departments of the EMP table. 
select distinct job from EMP
--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename,sal,deptno from EMP where sal > '1500' 
--13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 
--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
--16. Display the names of employees with experience of over 30 years and under 40 yrs.
-- Count the total number of employees. 
--17. Retrieve the names of departments in ascending order and their employees in 
--descending order. 
--18. Find out experience of MILLER. 
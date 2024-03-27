USE InfiniteAssignment

CREATE PROCEDURE GeneratePayslip
    @EmpNo INT
AS
BEGIN
    DECLARE @Salary DECIMAL
    DECLARE @HRA DECIMAL
    DECLARE @DA DECIMAL
    DECLARE @PF DECIMAL
    DECLARE @IT DECIMAL
    DECLARE @Deductions DECIMAL
    DECLARE @GrossSalary DECIMAL
    DECLARE @NetSalary DECIMAL
    DECLARE @EmpName VARCHAR(100)

    -- Get employee name
    SELECT @EmpName = ENAME
    FROM EMP
    WHERE EMPNO = @EmpNo

    -- Get employee salary
    SELECT @Salary = SAL
    FROM EMP
    WHERE EMPNO = @EmpNo

    -- Calculate allowances and deductions
    SET @HRA = @Salary * 0.1
    SET @DA = @Salary * 0.2
    SET @PF = @Salary * 0.08
    SET @IT = @Salary * 0.05
    SET @Deductions = @PF + @IT
    SET @GrossSalary = @Salary + @HRA + @DA
    SET @NetSalary = @GrossSalary - @Deductions

    -- Display the payslip
    PRINT 'Employee Payslip'
    PRINT 'Employee Number: ' + CAST(@EmpNo AS VARCHAR(10))
    PRINT 'Employee Name: ' + @EmpName
    PRINT 'Salary: ' + CAST(@Salary AS VARCHAR(20))
    PRINT 'HRA: ' + CAST(@HRA AS VARCHAR(20))
    PRINT 'DA: ' + CAST(@DA AS VARCHAR(20))
    PRINT 'PF: ' + CAST(@PF AS VARCHAR(20))
    PRINT 'IT: ' + CAST(@IT AS VARCHAR(20))
    PRINT 'Deductions: ' + CAST(@Deductions AS VARCHAR(20))
    PRINT 'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR(20))
    PRINT 'Net Salary: ' + CAST(@NetSalary AS VARCHAR(20))
END

SELECT * FROM EMP
EXEC GeneratePayslip @EmpNo = 1001

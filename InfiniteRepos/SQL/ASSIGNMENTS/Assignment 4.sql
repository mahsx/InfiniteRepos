-- find factorial

DECLARE @number INT, @factorial BIGINT
SET @number = 3
SET @factorial = 1
WHILE @number > 1
BEGIN
    SET @factorial = @factorial * @number
    SET @number = @number - 1
END
SELECT @factorial AS Factorial

-- Generate multiplication tables

alter procedure GenerateMultiplicationTables
    @maxNumber int
as
begin
    declare @multiplier int = 1

    while @multiplier <= @maxNumber
    begin
        declare @multiplicand int = 1

        while @multiplicand <= 10
        begin
            declare @result int = @multiplier * @multiplicand

            print concat(@multiplier, ' x ', @multiplicand, ' = ', @result)

            set @multiplicand = @multiplicand + 1
        end

        set @multiplier = @multiplier + 1
        print 'COMPLETED '+ cast(@multiplier-1 as varchar(10))
    end
end
exec GenerateMultiplicationTables @maxNumber = 5

-- holiday list
create table holiday (
    holiday_date date primary key,
    holiday_name varchar(50)
)

insert into holiday (holiday_date, holiday_name)
values
	('2024-03-25','Holi'),
    ('2024-08-15', 'Independence Day'),
    ('2024-10-02', 'Gandhi Baba'),
    ('2024-12-25', 'Christmas')

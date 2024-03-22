USE InfiniteAssignment

-- Create Books Table
CREATE TABLE Books (
    id INT PRIMARY KEY,
    title VARCHAR(255),
    author VARCHAR(255),
    isbn BIGINT UNIQUE,
    published_date DATETIME
);

-- Insert data into Books Table
INSERT INTO Books (id, title, author, isbn, published_date)
VALUES (1, 'My First SQL book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17'),
       (2, 'My Second SQL book', 'John Mayer', 857300923713, '1972-07-03 09:22:45'),
       (3, 'My Third SQL book', 'Cary Flint', 523120967812, '2015-10-18 14:05:44');

-- Query 1: Fetch details of books written by authors whose names end with "er"
SELECT * FROM Books WHERE author LIKE '%er';

-- Create Reviews Table
CREATE TABLE Reviews (
    id INT PRIMARY KEY,
    book_id INT,
    reviewer_name VARCHAR(255),
    content TEXT,
    rating INT,
    published_date DATETIME,
    FOREIGN KEY (book_id) REFERENCES Books(id)
);

-- Insert data into Reviews Table
INSERT INTO Reviews (id, book_id, reviewer_name, content, rating, published_date)
VALUES (1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11.1'),
       (2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
       (3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

-- Query 2: Display Title, Author, and ReviewerName for all books
SELECT b.title, b.author, r.reviewer_name
FROM Books b
INNER JOIN Reviews r ON b.id = r.book_id;

-- Create CUSTOMERS Table
CREATE TABLE CUSTOMERS (
    ID INT PRIMARY KEY,
    NAME VARCHAR(255),
    AGE INT,
    ADDRESS VARCHAR(255),
    SALARY DECIMAL(10, 2)
);

-- Insert data into CUSTOMERS Table
INSERT INTO CUSTOMERS (ID, NAME, AGE, ADDRESS, SALARY)
VALUES (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
       (2, 'Khilan', 25, 'Delhi', 1500.00),
       (3, 'Kaushik', 23, 'Kota', 2000.00),
       (4, 'Chaitali', 25, 'Mumbai', 6500.00),
       (5, 'Hardik', 27, 'Bhopal', 8500.00),
       (6, 'Komal', 22, 'MP', 4500.00),
       (7, 'Muffy', 24, 'Indore', 10000.00);

-- Query 3: Display names of customers who live in an address containing the character 'o'
SELECT NAME
FROM CUSTOMERS
WHERE ADDRESS LIKE '%o%';

-- Create ORDERS Table
CREATE TABLE ORDERS (
    ID INT PRIMARY KEY,
    DATE DATETIME,
    CUSTOMER_ID INT,
    AMOUNT DECIMAL(10, 2),
    FOREIGN KEY (CUSTOMER_ID) REFERENCES CUSTOMERS(ID)
);

-- Insert data into ORDERS Table
INSERT INTO ORDERS (ID, DATE, CUSTOMER_ID, AMOUNT)
VALUES (102, '2009-10-08 00:00:00', 3, 3000),
       (100, '2009-10-08 00:00:00', 3, 1500),
       (101, '2009-11-20 00:00:00', 2, 1560),
       (103, '2008-05-20 00:00:00', 4, 2060);

-- Query 4: Display Date and total number of customers who placed orders on the same date
SELECT DATE, COUNT(CUSTOMER_ID) AS TotalCustomers
FROM ORDERS
GROUP BY DATE;

-- Create EMPLOYEE Table
CREATE TABLE EMPLOYEE (
    ID INT PRIMARY KEY,
    NAME VARCHAR(255),
    AGE INT,
    ADDRESS VARCHAR(255),
    SALARY DECIMAL(10, 2)
);

-- Insert data into EMPLOYEE Table
INSERT INTO EMPLOYEE (ID, NAME, AGE, ADDRESS, SALARY)
VALUES (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
       (2, 'Khilan', 25, 'Delhi', 1500.00),
       (3, 'Kaushik', 23, 'Kota', 2000.00),
       (4, 'Chaitali', 25, 'Mumbai', 6500.00),
       (5, 'Hardik', 27, 'Bhopal', 8500.00),
       (6, 'Komal', 22, 'MP', NULL),
       (7, 'Muffy', 24, 'Indore', NULL);

-- Query 5: Display names of employees in lowercase whose salary is null
SELECT LOWER(NAME) AS LowercaseName
FROM EMPLOYEE
WHERE SALARY IS NULL;

-- Create StudentDetails Table
CREATE TABLE StudentDetails (
    RegisterNo INT PRIMARY KEY,
    Name VARCHAR(255),
    Age INT,
    Qualification VARCHAR(255),
    MobileNo BIGINT,
    Mail_id VARCHAR(255),
    Locationn VARCHAR(255),
    Gender CHAR(1)
);

-- Insert data into StudentDetails Table
INSERT INTO StudentDetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Locationn, Gender)
VALUES (1, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M'),
       (2, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M'),
       (3, 'Selvi', 22, 'B.TECH', 8904567342, 'selvi@gmail.com', 'Salem', 'F'),
       (4, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F'),
       (5, 'SaiSaran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madurai', 'F'),
       (6, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M');

-- Query 6: Display gender and total count of males and females from the StudentDetails table
SELECT Gender, COUNT(*) AS TotalCount
FROM StudentDetails
GROUP BY Gender;








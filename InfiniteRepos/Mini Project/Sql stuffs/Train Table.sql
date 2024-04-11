USE Trains;

CREATE TABLE Trains (
    TrainId INT PRIMARY KEY ,
    TrainName VARCHAR(100) NOT NULL,
    FirstClassBerths INT,
    SecondClassBerths INT,
    SleeperBerths INT,
    Source VARCHAR(100) NOT NULL,
    Destination VARCHAR(100) NOT NULL
);

ALTER TABLE Trains
ADD IsActive BIT NOT NULL DEFAULT 1


INSERT INTO Trains (TrainId, TrainName, Source, Destination, FirstClassBerths, SecondClassBerths, SleeperBerths)
VALUES
(12301, 'Rajdhani Express', 'Delhi', 'Mumbai', 50, 100, 200),
(12008, 'Shatabdi Express', 'Bangalore', 'Chennai', 30, 80, 150),
(12213, 'Duronto Express', 'Kolkata', 'Delhi', 40, 90, 180),
(12216, 'Garib Rath', 'Mumbai', 'Ahmedabad', 60, 120, 220),
(97432,	'Berhampur',	'UP',	'ODISHA'	,90, 99, 100 )

update Trains 
set FirstClassBerths=100,
	 secondclassBERTHS=100,
	 SleeperBerths=100
	 where TrainId in (12008,12213,12216,12301,97432)

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL
)
alter table users
add Email varchar(50)

insert into Users (Username,Password)
values('','')


CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL,
)

INSERT INTO Admins (Username,Password) values ('','')
delete from Admins where AdminId in (1,3)


CREATE TABLE Bookings (
    BookingId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    TrainId INT NOT NULL,
    ClassType NVARCHAR(20) NOT NULL,
    NumTickets INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (TrainId) REFERENCES Trains(TrainId)
)

CREATE TABLE Cancellations (
    CancellationId INT PRIMARY KEY IDENTITY(1,1),
    BookingId INT NOT NULL,
    UserId INT NOT NULL,
    CancellationDate DATETIME NOT NULL DEFAULT GETDATE(),
    Reason NVARCHAR(MAX),
    CONSTRAINT FK_Cancellations_Bookings FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId),
    CONSTRAINT FK_Cancellations_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
)


select * from Users
select * from Admins
select * from Trains
select * from Bookings
select * from Cancellations

UPDATE Users SET Email = 'maheshsekharsahu@gmail.com' WHERE UserId = 15;

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
(12216, 'Garib Rath', 'Mumbai', 'Ahmedabad', 60, 120, 220)

update Trains 
set FirstClassBerths=100,
	 secondclassBERTHS=100,
	 SleeperBerths=100
	 where TrainId in (12008,12213,12216,12301,12345,97432)

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL
)

UPDATE Users
SET Username = 'a', password = 'qw'
WHERE USERID = 1;

delete from users where UserId in (1,2,6,7,9)

CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1
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

select * from Users
select * from Admins
select * from Trains
select * from Bookings


insert into Users (Username,Password)
values('','')

update Trains
set isActive=1 where TrainId=12008



USE Trains;

-- Create the Trains table

-- Create the Trains table
CREATE TABLE Trains (
    TrainId INT PRIMARY KEY ,
    TrainName VARCHAR(100) NOT NULL,
    FirstClassBerths INT,
    SecondClassBerths INT,
    SleeperBerths INT,
    Source VARCHAR(100) NOT NULL,
    Destination VARCHAR(100) NOT NULL
);

select * from trains
delete Trains



INSERT INTO Trains (TrainId, TrainName, Source, Destination, FirstClassBerths, SecondClassBerths, SleeperBerths)
VALUES
(12301, 'Rajdhani Express', 'Delhi', 'Mumbai', 50, 100, 200),
(12008, 'Shatabdi Express', 'Bangalore', 'Chennai', 30, 80, 150),
(12213, 'Duronto Express', 'Kolkata', 'Delhi', 40, 90, 180),
(12216, 'Garib Rath', 'Mumbai', 'Ahmedabad', 60, 120, 220)s


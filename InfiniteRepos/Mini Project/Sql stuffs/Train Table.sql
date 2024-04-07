
USE Trains;
GO

-- Create the Trains table

CREATE Trains (
    TrainId INT PRIMARY KEY IDENTITY(1,1),
    TrainName NVARCHAR(100) NOT NULL,
    Class NVARCHAR(50) NOT NULL,
    TotalBerths INT NOT NULL,
    AvailableBerths INT NOT NULL,
    Source NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL
)



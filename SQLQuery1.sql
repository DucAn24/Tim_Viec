USE TimViec

CREATE TABLE Account (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Role INT, -- 0 Client, 1 Craftsman
    Username NVARCHAR(100),
    Password NVARCHAR(255)
);

CREATE TABLE Craftsman (
    ID INT PRIMARY KEY,
    FirstName NVARCHAR(255),
    LastName NVARCHAR(255),
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Gender NVARCHAR(10),
    Email NVARCHAR(255),
    DateOfBirth DATETIME,
    ImagePath NVARCHAR(MAX),
    FOREIGN KEY (ID) REFERENCES Account(ID)
);

CREATE TABLE Client (
    ID INT PRIMARY KEY,
    FirstName NVARCHAR(255),
    LastName NVARCHAR(255),
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Gender NVARCHAR(10),
    Email NVARCHAR(255),
    DateOfBirth DATETIME,
    ImagePath NVARCHAR(MAX), 
    FOREIGN KEY (ID) REFERENCES Account(ID)
);







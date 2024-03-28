CREATE TABLE Account(
	Username varchar(100),
	Password varchar(100)
);

INSERT INTO Account VALUES('abc','123');

CREATE TABLE Person (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    DateOfBirth DATE, -- Date of birth of the user
    ProfilePicture VARCHAR(100), 
    Phone VARCHAR(20), -- Phone number of the user
	Address VARCHAR(250),
    Gender CHAR(1) -- Gender of the user (M for Male, F for Female, O for Other, etc.)
);

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description TEXT NOT NULL,
    MinBudget DECIMAL(10, 2),
    MaxBudget DECIMAL(10, 2),
	Category VARCHAR(50),
    --FOREIGN KEY (ClientID) REFERENCES Person(UserID)
);







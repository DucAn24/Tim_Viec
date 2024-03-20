USE TimViec


CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    UserType INT NOT NULL, -- (e.g., 1 for Client, 2 for Freelancer)
    DateOfBirth DATE, -- Date of birth of the user
    ProfilePicture VARBINARY(MAX), 
    Phone VARCHAR(20), -- Phone number of the user
	Address VARCHAR(250),
    Gender CHAR(1) -- Gender of the user (M for Male, F for Female, O for Other, etc.)
);

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description TEXT NOT NULL,
    MinBudget DECIMAL(10, 2),
    MaxBudget DECIMAL(10, 2),
	Category VARCHAR(50),
	ClientID INT NOT NULL,
    FOREIGN KEY (ClientID) REFERENCES Users(UserID)
);






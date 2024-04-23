CREATE DATABASE TimViec
GO

USE TimViec
GO

CREATE TABLE Users  (
    user_id INT IDENTITY PRIMARY KEY,
    Role INT, -- 0 Client, 1 Worker
    Username NVARCHAR(100) ,
    Password NVARCHAR(255) ,
    Name NVARCHAR(255),
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Gender NVARCHAR(10),
    Email NVARCHAR(255),
    DateOfBirth DATE,
    ImagePath NVARCHAR(MAX)
);
GO


CREATE TABLE Worker (
    Worker_id INT IDENTITY PRIMARY KEY,
    user_id INT,
    Bio NVARCHAR(MAX),
    Skills NVARCHAR(MAX),
	Category NVARCHAR(80),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
GO

CREATE TABLE HiredWorkers (
    hired_id INT IDENTITY PRIMARY KEY,
    user_id INT,
    Worker_id INT,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id),
);
GO

CREATE TABLE Favourite (
    favourite_id INT IDENTITY PRIMARY KEY,
    Worker_id INT,
    user_id INT,
	isFavourite VARCHAR(50),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
GO

CREATE TRIGGER trg_AfterInsertUsers
ON Users
AFTER INSERT
AS
BEGIN
    INSERT INTO Worker(user_id, Bio, Skills)
    SELECT i.user_id, '', ''
    FROM inserted i
	WHERE Role = 1
END
GO


CREATE TABLE JobList (
    job_id INT IDENTITY PRIMARY KEY,
    PostedBy INT,
    JobTitle NVARCHAR(255),
    JobDescription NVARCHAR(MAX),
	Category NVARCHAR(80),
	Price DECIMAL(18, 2),
	ImagesJob NVARCHAR(MAX),
    FOREIGN KEY (PostedBy) REFERENCES Users(user_id)
);
GO


CREATE TABLE JobHistory (
    job_history_id INT IDENTITY PRIMARY KEY,
    Worker_id INT,
    JobTitle NVARCHAR(255),
    JobDescription NVARCHAR(MAX),
	Category NVARCHAR(80),
	Price DECIMAL(18, 2),
	ImagesJob NVARCHAR(MAX),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id),
);
GO

CREATE TABLE Applications (
    application_id INT IDENTITY PRIMARY KEY,
    job_id INT,
    Worker_id INT,
    FOREIGN KEY (job_id) REFERENCES JobList(job_id),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id),
);
GO

CREATE TRIGGER trg_AcceptedJob
ON Applications
AFTER INSERT
AS
BEGIN
    -- Inserting accepted job details into JobHistory table
    INSERT INTO JobHistory (Worker_id, JobTitle, JobDescription, Category, Price, ImagesJob)
    SELECT i.Worker_id, j.JobTitle, j.JobDescription, j.Category, j.Price, j.ImagesJob
    FROM inserted i
    INNER JOIN JobList j ON i.job_id = j.job_id
    WHERE i.Worker_id IS NOT NULL; -- Ensuring that a worker has accepted the job
END;


SELECT COUNT(*) AS TriggerCount
FROM sys.triggers;




CREATE TABLE Ratings (
    rating_id INT IDENTITY PRIMARY KEY,
    Worker_id INT,
    user_id INT,
    Stars INT,
    Comment NVARCHAR(MAX),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id),
	FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
GO

CREATE TABLE Appointment (
    appointment_id INT IDENTITY PRIMARY KEY,
    Worker_id INT,
    user_id INT,
    Date DATETIME,
	Content NVARCHAR(MAX),
    Status NVARCHAR(50),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
GO



SELECT * FROM Users
SELECT * FROM Worker
SELECT * FROM Favourite
SELECT * FROM HiredWorkers


SELECT W.Category,
		U.Name,
		U.ImagePath
FROM Worker W
JOIN HiredWorkers H
	ON W.Worker_id = H.Worker_id
JOIN Users U
	ON U.user_id = W.user_id
WHERE H.user_id = 1

SELECT W.Category,
		U.Name,
		U.ImagePath,
		U.PhoneNumber,
		U.Email,
		U.DateOfBirth,
		U.Address
FROM Worker W
JOIN Favourite F
	ON W.Worker_id = F.Worker_id
JOIN Users U
	ON U.user_id = W.user_id
WHERE F.user_id = 2

INSERT INTO Applications (job_id,Worker_id)
VALUES
    (1, 3);



SELECT * FROM JobList
SELECT * FROM Applications
SELECT * FROM JobHistory
SELECT * FROM Ratings
SELECT * FROM Appointment

SELECT Worker_id, COUNT(*) as NumberOfJobs
FROM JobHistory
GROUP BY Worker_id;









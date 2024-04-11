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

CREATE TRIGGER trg_AfterInsertUsers
ON Users
AFTER INSERT
AS
BEGIN
    INSERT INTO Worker(user_id, Bio, Skills)
    SELECT i.user_id, '', ''
    FROM inserted i
END
GO

CREATE TABLE Worker (
    Worker_id INT IDENTITY PRIMARY KEY,
    user_id INT,
    Bio NVARCHAR(MAX),
    Skills NVARCHAR(MAX),
	Category NVARCHAR(80);
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
    user_id INT,
    hired_user_id INT,
    job_history_id INT,
    status VARCHAR(50),
    FOREIGN KEY (job_id) REFERENCES JobList(job_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (hired_user_id) REFERENCES Users(user_id),
    FOREIGN KEY (job_history_id) REFERENCES JobHistory(job_history_id)
);
GO

CREATE TRIGGER AddToJobHistory
ON Applications
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra xem trạng thái có phải là 'Accepted' không
    IF EXISTS (SELECT 1 FROM inserted WHERE status = 'Accepted')
    BEGIN
        -- Lấy thông tin về công việc
        DECLARE @Worker_id INT, @job_id INT, @JobTitle NVARCHAR(255), @JobDescription NVARCHAR(MAX), @Category NVARCHAR(80), @Price DECIMAL(18, 2), @ImagesJob NVARCHAR(MAX);
        SELECT @Worker_id = hired_user_id, @job_id = job_id FROM inserted;
        SELECT @JobTitle = JobTitle, @JobDescription = JobDescription, @Category = Category, @Price = Price, @ImagesJob = ImagesJob
        FROM JobList
        WHERE job_id = @job_id;

        -- Thêm công việc vào lịch sử công việc
        INSERT INTO JobHistory (Worker_id,  JobTitle, JobDescription, Category, Price, ImagesJob)
        VALUES (@Worker_id,  @JobTitle, @JobDescription, @Category, @Price, @ImagesJob);
    END
END;
GO


CREATE TABLE Favourite (
    favourite_id INT IDENTITY PRIMARY KEY,
    Worker_id INT,
    user_id INT,
	isFavourite VARCHAR(50),
    FOREIGN KEY (Worker_id) REFERENCES Users(user_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
GO

CREATE TABLE Ratings (
    rating_id INT IDENTITY PRIMARY KEY,
    job_id INT,
    Worker_id INT,
    Stars INT,
    Comment NVARCHAR(MAX),
    FOREIGN KEY (job_id) REFERENCES JobList(job_id),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id)
);
GO

CREATE TABLE Appointments (
    appointment_id INT IDENTITY PRIMARY KEY,
    job_id INT,
    Worker_id INT,
    employer_id INT,
    Date DATETIME,
    Status NVARCHAR(50),
    FOREIGN KEY (job_id) REFERENCES JobList(job_id),
    FOREIGN KEY (Worker_id) REFERENCES Worker(Worker_id),
    FOREIGN KEY (employer_id) REFERENCES Users(user_id)
);
GO



SELECT * FROM Users
SELECT * FROM Worker

SELECT W.worker_id,
		U.Name,
		U.Email,
		U.ImagePath,
		U.DateOfBirth,
		W.Bio,
		W.Skills
FROM Users U
JOIN Worker W
ON U.user_id = w.user_id

SELECT * FROM HiredWorkers
SELECT * FROM Applications

SELECT * FROM JobList
SELECT * FROM JobHistory

SELECT Worker_id, COUNT(*) as NumberOfJobs
FROM JobHistory
GROUP BY Worker_id;



SELECT * FROM Favourite





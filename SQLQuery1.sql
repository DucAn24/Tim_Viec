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

CREATE TABLE Appointment (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ClientID INT,
    CraftsmanID INT,
    AppointmentTime DATETIME,
    FOREIGN KEY (ClientID) REFERENCES Account(ID),
    FOREIGN KEY (CraftsmanID) REFERENCES Account(ID)
);

CREATE TABLE CraftsmanRating (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CraftsmanID INT,
    ClientID INT,
    Rating INT,
    Comment NVARCHAR(MAX),
    FOREIGN KEY (CraftsmanID) REFERENCES Account(ID),
    FOREIGN KEY (ClientID) REFERENCES Account(ID)
);

CREATE TABLE FavoriteCraftsman (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ClientID INT,
    CraftsmanID INT,
    FOREIGN KEY (ClientID) REFERENCES Account(ID),
    FOREIGN KEY (CraftsmanID) REFERENCES Account(ID)
);

CREATE TABLE JobInformation (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    CraftsmanID INT,
    JobTitle NVARCHAR(255),
    JobDescription NVARCHAR(MAX),
	Category NVARCHAR(80),
	ImagePath NVARCHAR(MAX),
	MinPrice DECIMAL(18, 2),
	MaxPrice DECIMAL(18, 2),
	PayType INT, -- 0 project, 1 hour
    FOREIGN KEY (CraftsmanID) REFERENCES Craftsman(ID)
);



INSERT INTO Craftsman (ID, FirstName, LastName, Address, PhoneNumber, Gender, Email, DateOfBirth, ImagePath)
VALUES
    (1, 'John', 'Doe', '123 Main St', '123456789', 'Male', 'john@example.com', '1980-01-01', 'E:\winForm\Image\man.png'),
    (2, 'Jane', 'Smith', '456 Oak St', '987654321', 'Female', 'jane@example.com', '1985-05-05', 'E:\winForm\Image\man.png');


INSERT INTO JobInformation (CraftsmanID, JobTitle, JobDescription, Category, ImagePath, MinPrice, MaxPrice, PayType)
VALUES
    (1, 'House Painting', 'Paint the interior and exterior of a house', 'Devlopment-IT', 'E:\winForm\Image\68747470733a2f2f73332e616d617a6f6e6177732e636f6d2f776174747061642d6d656469612d736572766963652f53746f7279496d6167652f6867514f413661494a7255656b413d3d2d3830343936383231362e31356436633638646239313762626564383835323437373439303.jpg', 100, 500, 0),
    (1, 'Plumbing Repair', 'Fix leaking pipes and repair plumbing fixtures', 'Devlopment-IT', 'E:\winForm\Image\boy.png', 50, 300, 1),
    (2, 'Lawn Mowing', 'Mow and maintain lawns', 'AI-Services', 'E:\winForm\Image\man.png', 30, 150, 1),
    (2, 'Furniture Assembly', 'Assemble furniture items', 'AI-Services', 'E:\winForm\Image\woman.png', 20, 100, 0),
	(1, 'Python Developer : Django - Flask - RESTful APIs - Automation Scripts', 'Paint the interior and exterior of a house', 'Devlopment-IT', 'E:\winForm\Image\68747470733a2f2f73332e616d617a6f6e6177732e636f6d2f776174747061642d6d656469612d736572766963652f53746f7279496d6167652f6867514f413661494a7255656b413d3d2d3830343936383231362e31356436633638646239313762626564383835323437373439303.jpg', 100, 500, 0),
    (1, 'Python Programmer', 'Fix leaking pipes and repair plumbing fixtures', 'Devlopment-IT', 'E:\winForm\Image\boy.png', 50, 300, 1),
    (2, 'Python Machine Learning Developer | Expert in Flask & Django', 'Mow and maintain lawns', 'AI-Services', 'E:\winForm\Image\man.png', 30, 150, 1),
    (2, 'Mobile App Developer / Python Developer', '👋 Hey there! Im akshay vayak, a seasoned Python and Machine Learning enthusiast with a passion for turning data into actionable insights. Im here to supercharge your projects with cutting-edge technology and data-driven solutions', 'AI-Services', 'E:\winForm\Image\woman.png', 20, 100, 0),
	(1, 'Python Developer : Django - Flask - RESTful APIs - Automation Scripts', 'Paint the interior and exterior of a house', 'Devlopment-IT', 'E:\winForm\Image\68747470733a2f2f73332e616d617a6f6e6177732e636f6d2f776174747061642d6d656469612d736572766963652f53746f7279496d6167652f6867514f413661494a7255656b413d3d2d3830343936383231362e31356436633638646239313762626564383835323437373439303.jpg', 100, 500, 0),
    (1, 'Python Programmer', 'Fix leaking pipes and repair plumbing fixtures', 'Devlopment-IT', 'E:\winForm\Image\boy.png', 50, 300, 1),
    (2, 'Python Machine Learning Developer | Expert in Flask & Django', 'Mow and maintain lawns', 'AI-Services', 'E:\winForm\Image\man.png', 30, 150, 1),
    (2, 'Mobile App Developer / Python Developer', '👋 Hey there! Im akshay vayak, a seasoned Python and Machine Learning enthusiast with a passion for turning data into actionable insights. Im here to supercharge your projects with cutting-edge technology and data-driven solutions', 'AI-Services', 'E:\winForm\Image\woman.png', 20, 100, 0);

select * from JobInformation




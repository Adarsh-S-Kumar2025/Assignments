-- ============================================
-- 1️⃣ THEATRE (Now includes CityName directly)
-- ============================================
CREATE TABLE Theatre (
    TheatreID INT IDENTITY(1,1) PRIMARY KEY,
    TheatreName VARCHAR(150) NOT NULL,
    Address VARCHAR(255),
    CityName VARCHAR(100) NOT NULL
);

-- ============================================
-- 2️⃣ SCREEN (each theatre can have multiple screens)
-- ============================================
CREATE TABLE Screen (
    ScreenID INT IDENTITY(1,1) PRIMARY KEY,
    TheatreID INT NOT NULL,
    ScreenName VARCHAR(100) NOT NULL,
    TotalSeats INT NOT NULL,
    FOREIGN KEY (TheatreID) REFERENCES Theatre(TheatreID)
);

-- ============================================
-- 3️⃣ SEAT TYPE (Normalization for seat category)
-- ============================================
CREATE TABLE SeatType (
    SeatTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName VARCHAR(50) NOT NULL,   -- e.g. Regular, Premium, Recliner
    PriceMultiplier DECIMAL(4,2) DEFAULT 1.00
);

-- ============================================
-- 4️⃣ SEAT (each screen has multiple seats)
-- ============================================
CREATE TABLE Seat (
    SeatID INT IDENTITY(1,1) PRIMARY KEY,
    ScreenID INT NOT NULL,
    SeatNumber VARCHAR(10) NOT NULL,
    SeatTypeID INT NOT NULL,
    FOREIGN KEY (ScreenID) REFERENCES Screen(ScreenID),
    FOREIGN KEY (SeatTypeID) REFERENCES SeatType(SeatTypeID)
);

-- ============================================
-- 5️⃣ MOVIE
-- ============================================
CREATE TABLE Movie (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    Language VARCHAR(50),
    Genre VARCHAR(100),
    DurationMinutes INT,
    Certification VARCHAR(10),
    ReleaseDate DATE
);

-- ============================================
-- 6️⃣ SHOW (specific movie on a specific screen/time)
-- ============================================
CREATE TABLE Show (
    ShowID INT IDENTITY(1,1) PRIMARY KEY,
    MovieID INT NOT NULL,
    ScreenID INT NOT NULL,
    ShowDate DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    BasePrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
    FOREIGN KEY (ScreenID) REFERENCES Screen(ScreenID)
);

-- ============================================
-- 7️⃣ USER (customers)
-- ============================================
CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15) UNIQUE NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- ============================================
-- 8️⃣ TICKET (user’s booking for a show)
-- ============================================
CREATE TABLE Ticket (
    TicketID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    ShowID INT NOT NULL,
    BookingTime DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2),
    Status VARCHAR(20) DEFAULT 'CONFIRMED', -- CONFIRMED / CANCELLED
    FOREIGN KEY (UserID) REFERENCES [User](UserID),
    FOREIGN KEY (ShowID) REFERENCES Show(ShowID)
);

-- ============================================
-- 9️⃣ TICKET-SEAT MAPPING (many-to-many relation)
-- ============================================
CREATE TABLE TicketSeat (
    TicketSeatID INT IDENTITY(1,1) PRIMARY KEY,
    TicketID INT NOT NULL,
    SeatID INT NOT NULL,
    ShowID INT NOT NULL,
    FOREIGN KEY (TicketID) REFERENCES Ticket(TicketID),
    FOREIGN KEY (SeatID) REFERENCES Seat(SeatID),
    FOREIGN KEY (ShowID) REFERENCES Show(ShowID)
);

-- ============================================
-- 🎭 THEATRES
-- ============================================
INSERT INTO Theatre (TheatreName, Address, CityName)
VALUES 
('PVR Phoenix', 'Phoenix Mall', 'Mumbai'),
('INOX Forum', 'Forum Mall', 'Bengaluru'),
('Cinepolis Ambience', 'Ambience Mall', 'Delhi'),
('Carnival Cinemas', 'Orion Mall', 'Bengaluru'),
('Miraj Cinemas', 'Infinity Mall', 'Mumbai');

-- ============================================
-- 🖥️ SCREENS
-- ============================================
INSERT INTO Screen (TheatreID, ScreenName, TotalSeats)
VALUES
(1, 'Screen 1', 100),
(1, 'Screen 2', 120),
(2, 'IMAX', 150),
(3, 'Gold Lounge', 80),
(4, 'Classic', 90),
(5, 'Screen 1', 100),
(5, 'Screen 2', 130);

-- ============================================
-- 💺 SEAT TYPES
-- ============================================
INSERT INTO SeatType (TypeName, PriceMultiplier)
VALUES
('Regular', 1.00),
('Premium', 1.50),
('Recliner', 2.00);

-- ============================================
-- 🪑 SEATS (for first few screens)
-- ============================================
-- Screen 1 (PVR Phoenix)
INSERT INTO Seat (ScreenID, SeatNumber, SeatTypeID)
VALUES
(1, 'A1', 1), (1, 'A2', 1), (1, 'A3', 1), (1, 'A4', 1),
(1, 'B1', 2), (1, 'B2', 2), (1, 'B3', 2), (1, 'B4', 2),
(1, 'C1', 3), (1, 'C2', 3);

-- Screen 3 (IMAX Bengaluru)
INSERT INTO Seat (ScreenID, SeatNumber, SeatTypeID)
VALUES
(3, 'A1', 1), (3, 'A2', 1), (3, 'B1', 2), (3, 'B2', 2), (3, 'C1', 3), (3, 'C2', 3);

-- Screen 4 (Gold Lounge Delhi)
INSERT INTO Seat (ScreenID, SeatNumber, SeatTypeID)
VALUES
(4, 'A1', 2), (4, 'A2', 2), (4, 'B1', 3), (4, 'B2', 3);

-- ============================================
-- 🎥 MOVIES
-- ============================================
INSERT INTO Movie (Title, Language, Genre, DurationMinutes, Certification, ReleaseDate)
VALUES
('Pushpa 2: The Rule', 'Telugu', 'Action', 165, 'UA', '2025-08-15'),
('Joker: Folie à Deux', 'English', 'Thriller', 138, 'A', '2025-10-10'),
('Deadpool & Wolverine', 'English', 'Action Comedy', 128, 'A', '2025-07-20'),
('Kalki 2898 AD', 'Telugu', 'Sci-Fi', 180, 'UA', '2025-09-05'),
('Avengers: Secret Wars', 'English', 'Superhero', 195, 'UA', '2025-11-20');

-- ============================================
-- ⏰ SHOWS
-- ============================================
INSERT INTO Show (MovieID, ScreenID, ShowDate, StartTime, EndTime, BasePrice)
VALUES
(1, 1, '2025-10-29', '18:00', '21:00', 250.00),
(1, 2, '2025-10-29', '21:30', '00:30', 280.00),
(2, 3, '2025-10-29', '19:00', '21:30', 300.00),
(3, 4, '2025-10-29', '20:00', '22:15', 320.00),
(4, 5, '2025-10-30', '17:00', '20:00', 270.00),
(5, 6, '2025-10-30', '20:00', '23:15', 350.00);

-- ============================================
-- 👥 USERS
-- ============================================
INSERT INTO [User] (FullName, Email, PhoneNumber)
VALUES
('Adarsh Kumar', 'adarsh@example.com', '9999988888'),
('Priya Nair', 'priya@example.com', '8888877777'),
('Rahul Mehta', 'rahul@example.com', '7777766666'),
('Sneha Reddy', 'sneha@example.com', '9998877665'),
('Arjun Patel', 'arjun@example.com', '8888999900');

-- ============================================
-- 🎫 TICKETS (Bookings)
-- ============================================
INSERT INTO Ticket (UserID, ShowID, TotalAmount, Status)
VALUES
(1, 1, 500.00, 'CONFIRMED'),
(2, 3, 900.00, 'CONFIRMED'),
(3, 2, 560.00, 'CANCELLED'),
(4, 5, 750.00, 'CONFIRMED'),
(5, 6, 1050.00, 'CONFIRMED');

-- ============================================
-- 🎟️ TICKET-SEAT MAPPINGS
-- ============================================
INSERT INTO TicketSeat (TicketID, SeatID, ShowID)
VALUES
(1, 1, 1), (1, 2, 1),
(2, 3, 3), (2, 4, 3), (2, 5, 3),
(3, 6, 2), (3, 7, 2),
(4, 8, 5), (4, 9, 5),
(5, 10, 6);


select * from TicketSeat;
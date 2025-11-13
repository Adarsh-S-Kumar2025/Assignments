-- Library Management Schema


CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY,
    AuthorName VARCHAR(100),
    BirthYear INT
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(200),
    AuthorID INT,
    PublicationYear INT,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

CREATE TABLE Patrons (
    PatronID INT PRIMARY KEY,
    PatronName VARCHAR(100),
    MembershipDate DATE
);

CREATE TABLE Loans (
    LoanID INT PRIMARY KEY,
    BookID INT,
    PatronID INT,
    LoanDate DATE,
    ReturnDate DATE,
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (PatronID) REFERENCES Patrons(PatronID)
);

INSERT INTO Authors (AuthorID, AuthorName, BirthYear) VALUES
(1, 'George Orwell', 1903),
(2, 'J.K. Rowling', 1965),
(3, 'Author Unknown', NULL),
(4, 'Chetan Bhagat', 1974);
INSERT INTO Books (BookID, Title, AuthorID, PublicationYear) VALUES
(101, '1984', 1, 1949),
(102, 'Animal Farm', 1, 1945),
(103, 'Harry Potter', 2, 1997),
(104, 'Unknown Book', NULL, 2005),
(105, '2 States', 4, 2009);
INSERT INTO Patrons (PatronID, PatronName, MembershipDate) VALUES
(201, 'Alice Johnson', '2024-01-10'),
(202, 'Bob Smith', '2024-02-15'),
(203, 'Charlie Brown', '2024-03-05');
INSERT INTO Loans (LoanID, BookID, PatronID, LoanDate, ReturnDate) VALUES
(301, 101, 201, '2024-09-01', '2024-09-15'),
(302, 103, 202, '2024-10-01', NULL),
(303, 105, 201, '2024-10-10', NULL);
-- Questions

-- 1. List all books along with their authors, including books without assigned authors.

SELECT B.BookID, B.Title, A.AuthorName
FROM Books B
LEFT JOIN Authors A ON B.AuthorID = A.AuthorID;

-- 2. Display all patrons and their loan history, including patrons who have never borrowed a book.

SELECT P.PatronID, P.PatronName, L.LoanID, L.BookID, L.LoanDate
FROM Patrons P
LEFT JOIN Loans L ON P.PatronID = L.PatronID;

-- 3. Show all authors and the books they've written, including authors who haven't written any books in our collection.

SELECT A.AuthorID, A.AuthorName, B.BookID, B.Title
FROM Authors A
LEFT JOIN Books B ON A.AuthorID = B.AuthorID;

-- 4. List all possible book-patron combinations, regardless of whether a loan has occurred.

SELECT B.BookID, B.Title, P.PatronID, P.PatronName
FROM Books B
CROSS JOIN Patrons P;

-- 5. Display all loans with book and patron information, including loans where either the book or patron information is missing.

SELECT L.LoanID, L.LoanDate, B.Title, P.PatronName
FROM Loans L
FULL OUTER JOIN Books B ON L.BookID = B.BookID
FULL OUTER JOIN Patrons P ON L.PatronID = P.PatronID;

-- 6. Show all books that have never been loaned, along with their author information.

SELECT B.BookID, B.Title, A.AuthorName
FROM Books B
LEFT JOIN Loans L ON B.BookID = L.BookID
LEFT JOIN Authors A ON B.AuthorID = A.AuthorID
WHERE L.BookID IS NULL;

-- 7. List all patrons who have borrowed books in the last month, along with the books they've borrowed.

SELECT P.PatronName, B.Title, L.LoanDate
FROM Loans L
JOIN Patrons P ON L.PatronID = P.PatronID
JOIN Books B ON L.BookID = B.BookID
WHERE L.LoanDate >= DATEADD(DAY, -30, GETDATE());

-- 8. Display all authors born after 1970 and their books, including those without any books in our collection.

SELECT A.AuthorName, A.BirthYear, B.Title
FROM Authors A
LEFT JOIN Books B ON A.AuthorID = B.AuthorID
WHERE A.BirthYear > 1970;

-- 9. Show all books published before 2000 and any associated loan information.

SELECT B.Title, B.PublicationYear, L.LoanID, L.LoanDate
FROM Books B
LEFT JOIN Loans L ON B.BookID = L.BookID
WHERE B.PublicationYear < 2000;

-- 10. List all possible author-patron combinations, regardless of whether the patron has borrowed a book by that author.

SELECT A.AuthorName, P.PatronName
FROM Authors A
CROSS JOIN Patrons P;


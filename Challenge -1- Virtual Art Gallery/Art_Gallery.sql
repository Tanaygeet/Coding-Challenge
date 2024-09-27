/* By Tanaygeet Shrivastava */


/* Task -1 - Database Design */

-- 1
CREATE DATABASE Art_Gallery;
USE Art_Gallery;

---------------------------------------------------------------------------------------------------------------------------------------------------------
-- Creating Tables:

-- 2(i)
CREATE TABLE Artists (
ArtistID INT PRIMARY KEY,
Name VARCHAR(255) NOT NULL,
Biography TEXT,
Nationality VARCHAR(100));


-- 2(ii)
CREATE TABLE Categories (
CategoryID INT PRIMARY KEY,
Name VARCHAR(100) NOT NULL);


-- 2(iii)
CREATE TABLE Artworks (
ArtworkID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
ArtistID INT,
CategoryID INT,
Year INT,
Description TEXT,
ImageURL VARCHAR(255),
FOREIGN KEY (ArtistID) REFERENCES Artists (ArtistID),
FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID));


-- 2(iv)
CREATE TABLE Exhibitions (
ExhibitionID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
StartDate DATE,
EndDate DATE,
Description TEXT);


-- 2(v)
CREATE TABLE ExhibitionArtworks (
ExhibitionID INT,
ArtworkID INT,
PRIMARY KEY (ExhibitionID, ArtworkID),
FOREIGN KEY (ExhibitionID) REFERENCES Exhibitions (ExhibitionID),
FOREIGN KEY (ArtworkID) REFERENCES Artworks (ArtworkID));


---------------------------------------------------------------------------------------------------------------------------------------------------------
-- Inserting Sample Data Into Tables:

-- 3(i)
INSERT INTO Artists (ArtistID, Name, Biography, Nationality) VALUES
(1, 'Pablo Picasso', 'Renowned Spanish painter and sculptor.', 'Spanish'),
(2, 'Vincent van Gogh', 'Dutch post-impressionist painter.', 'Dutch'),
(3, 'Leonardo da Vinci', 'Italian polymath of the Renaissance.', 'Italian');


-- 3(ii)
INSERT INTO Categories (CategoryID, Name) VALUES
(1, 'Painting'),
(2, 'Sculpture'),
(3, 'Photography');


-- 3(iii)
INSERT INTO Artworks (ArtworkID, Title, ArtistID, CategoryID, Year, Description, ImageURL) VALUES
(1, 'Starry Night', 2, 1, 1889, 'A famous painting by Vincent van Gogh.', 'starry_night.jpg'),
(2, 'Mona Lisa', 3, 1, 1503, 'The iconic portrait by Leonardo da Vinci.', 'mona_lisa.jpg'),
(3, 'Guernica', 1, 1, 1937, 'Pablo Picasso\'s powerful anti-war mural.', 'guernica.jpg'),
(4, 'The Weeping Woman', 1, 1, 1937, 'Another famous painting by Picasso.', 'weeping_woman.jpg'),
(5, 'Sculpture of Peace', 1, 2, 1945, 'A sculpture by Picasso.', 'sculpture_peace.jpg'),
(6, 'La Vie', 1, 1, 1903, 'A famous blue period painting by Picasso.', 'la_vie.jpg'),
(7, 'Les Demoiselles d\'Avignon', 1, 1, 1907, 'A revolutionary Picasso painting.', 'avignon.jpg'),
(8, 'Unseen Beauty', 3, 1, 1505, 'A lesser-known painting by Leonardo da Vinci.', 'unseen_beauty.jpg'),
(9, 'The Persistence of Memory', 1, 1, 1931, 'A surreal painting by Salvador Dali.', 'persistence_memory.jpg');



-- 3(iv)
INSERT INTO Exhibitions (ExhibitionID, Title, StartDate, EndDate, Description) VALUES
(1, 'Modern Art Masterpieces', '2023-01-01', '2023-03-01', 'A collection of modern art masterpieces.'),
(2, 'Renaissance Art', '2023-04-01', '2023-06-01', 'A showcase of Renaissance art treasures.');


-- 3(v)
INSERT INTO ExhibitionArtworks (ExhibitionID, ArtworkID) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 2),
(2, 1);




-----------------------------------------------------------------------------------------------------------------------------------------------------------------
/* Task - 2 */


/* Schema Adjustments Needed: 
CREATE INDEX idx_artworks_artist ON Artworks (ArtistID);
CREATE INDEX idx_artworks_category ON Artworks (CategoryID);
CREATE INDEX idx_exhibitionartworks_artwork ON ExhibitionArtworks (ArtworkID);
CREATE INDEX idx_exhibitionartworks_exhibition ON ExhibitionArtworks (ExhibitionID);
*/

-- 1
SELECT A.Name, COUNT(Art.ArtworkID) AS ArtworkCount
FROM Artists A
LEFT JOIN Artworks Art ON A.ArtistID = Art.ArtistID
GROUP BY A.Name
ORDER BY ArtworkCount DESC;


-- 2
SELECT Art.Title
FROM Artworks Art
JOIN Artists A ON Art.ArtistID = A.ArtistID
WHERE A.Nationality IN ('Spanish', 'Dutch')
ORDER BY Art.Year ASC;


-- 3
SELECT A.Name, COUNT(Art.ArtworkID) AS ArtworkCount
FROM Artists A
JOIN Artworks Art ON A.ArtistID = Art.ArtistID
JOIN Categories C ON Art.CategoryID = C.CategoryID
WHERE C.Name = 'Painting'
GROUP BY A.Name;


-- 4 
SELECT Art.Title, A.Name AS ArtistName, C.Name AS CategoryName
FROM ExhibitionArtworks EA
JOIN Artworks Art ON EA.ArtworkID = Art.ArtworkID
JOIN Artists A ON Art.ArtistID = A.ArtistID
JOIN Categories C ON Art.CategoryID = C.CategoryID
JOIN Exhibitions E ON EA.ExhibitionID = E.ExhibitionID
WHERE E.Title = 'Modern Art Masterpieces';


-- 5
SELECT A.Name
FROM Artists A
JOIN Artworks Art ON A.ArtistID = Art.ArtistID
GROUP BY A.Name
HAVING COUNT(Art.ArtworkID) > 2;


-- 6
SELECT Art.Title
FROM ExhibitionArtworks EA1
JOIN ExhibitionArtworks EA2 ON EA1.ArtworkID = EA2.ArtworkID
JOIN Artworks Art ON EA1.ArtworkID = Art.ArtworkID
JOIN Exhibitions E1 ON EA1.ExhibitionID = E1.ExhibitionID
JOIN Exhibitions E2 ON EA2.ExhibitionID = E2.ExhibitionID
WHERE E1.Title = 'Modern Art Masterpieces' AND E2.Title = 'Renaissance Art';


-- 7
SELECT C.Name, COUNT(Art.ArtworkID) AS ArtworkCount
FROM Categories C
LEFT JOIN Artworks Art ON C.CategoryID = Art.CategoryID
GROUP BY C.Name;


-- 8
SELECT A.Name
FROM Artists A
JOIN Artworks Art ON A.ArtistID = Art.ArtistID
GROUP BY A.Name
HAVING COUNT(Art.ArtworkID) > 3;


-- 9
SELECT Art.Title
FROM Artworks Art
JOIN Artists A ON Art.ArtistID = A.ArtistID
WHERE A.Nationality = 'Spanish';


-- 10
SELECT E.Title
FROM Exhibitions E
JOIN ExhibitionArtworks EA ON E.ExhibitionID = EA.ExhibitionID
JOIN Artworks Art ON EA.ArtworkID = Art.ArtworkID
JOIN Artists A ON Art.ArtistID = A.ArtistID
WHERE A.Name IN ('Vincent van Gogh', 'Leonardo da Vinci')
GROUP BY E.Title
HAVING COUNT(DISTINCT A.ArtistID) = 2;


-- 11
SELECT Art.Title
FROM Artworks Art
LEFT JOIN ExhibitionArtworks EA ON Art.ArtworkID = EA.ArtworkID
WHERE EA.ExhibitionID IS NULL;


-- 12
SELECT A.Name
FROM Artists A
JOIN Artworks Art ON A.ArtistID = Art.ArtistID
JOIN Categories C ON Art.CategoryID = C.CategoryID
GROUP BY A.Name
HAVING COUNT(DISTINCT Art.CategoryID) = (SELECT COUNT(*) FROM Categories);


-- 13
SELECT C.Name, COUNT(Art.ArtworkID) AS ArtworkCount
FROM Categories C
LEFT JOIN Artworks Art ON C.CategoryID = Art.CategoryID
GROUP BY C.Name;


-- 14
SELECT A.Name
FROM Artists A
JOIN Artworks Art ON A.ArtistID = Art.ArtistID
GROUP BY A.Name
HAVING COUNT(Art.ArtworkID) > 2;


-- 15
SELECT C.Name, AVG(Art.Year) AS AvgYear
FROM Categories C
JOIN Artworks Art ON C.CategoryID = Art.CategoryID
GROUP BY C.Name
HAVING COUNT(Art.ArtworkID) > 1;


-- 16
SELECT Art.Title
FROM Artworks Art
JOIN ExhibitionArtworks EA ON Art.ArtworkID = EA.ArtworkID
JOIN Exhibitions E ON EA.ExhibitionID = E.ExhibitionID
WHERE E.Title = 'Modern Art Masterpieces';


-- 17
SELECT C.Name
FROM Categories C
JOIN Artworks Art ON C.CategoryID = Art.CategoryID
GROUP BY C.Name
HAVING AVG(Art.Year) > (SELECT AVG(Year) FROM Artworks);


-- 18
SELECT Art.Title
FROM Artworks Art
LEFT JOIN ExhibitionArtworks EA ON Art.ArtworkID = EA.ArtworkID
WHERE EA.ExhibitionID IS NULL;


-- 19
SELECT A.Name
FROM Artists A
JOIN Artworks Art ON A.ArtistID = Art.ArtistID
WHERE Art.CategoryID = (SELECT CategoryID FROM Artworks WHERE Title = 'Mona Lisa');


-- 20
SELECT A.Name, COUNT(Art.ArtworkID) AS ArtworkCount
FROM Artists A
JOIN Artworks Art ON A.ArtistID = Art.ArtistID
GROUP BY A.Name;









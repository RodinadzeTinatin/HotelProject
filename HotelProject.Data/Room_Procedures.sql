--USE DOITHotel


--CREATE TABLE Rooms
--(
--	Id INT IDENTITY PRIMARY KEY,
--	[Name] NVARCHAR(50),
--	IsFree BIT,
--	HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
--	DailyPrice FLOAT
--)

--INSERT INTO Rooms ([Name], IsFree, HotelId, DailyPrice)
--VALUES 
--(N'პირველი ოთახი', 1, 1, 40),
--(N'მეორე ოთახი', 0, 2, 50),
--(N'მესამე ოთახი', 1, 3, 43),
--(N'მეოთხე ოთახი', 0, 3, 43)

--CREATE PROCEDURE sp_GetAllRooms
--AS
--BEGIN
--	SELECT 
--		Id,
--		[Name],
--		IsFree,
--		HotelId,
--		DailyPrice
--	FROM Rooms
--END


--CREATE PROCEDURE sp_AddRoom
--@name NVARCHAR(50),
--@isfree BIT,
--@hotelId INT,
--@dailyPrice FLOAT	
--AS
--BEGIN
--	INSERT INTO Rooms ([Name], IsFree, HotelId, DailyPrice)
--	VALUES (@name, @isfree, @hotelId, @dailyPrice)
--END


--CREATE PROCEDURE sp_UpdateRoom
--@id INT,
--@name NVARCHAR(50),
--@isfree BIT,
--@hotelId INT,
--@dailyPrice FLOAT	
--AS
--BEGIN
--	UPDATE Rooms
--	SET
--		[Name] = @name,
--		IsFree = @isfree,
--		HotelId = @hotelId,
--		DailyPrice = @dailyPrice
--	WHERE Id = @id
--END

--CREATE PROCEDURE sp_DeleteRoom
--@id INT
--AS
--BEGIN
--	DELETE FROM Rooms
--	WHERE Id = @id
--END



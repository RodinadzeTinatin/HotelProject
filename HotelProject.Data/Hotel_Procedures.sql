----------------------GET HOTELS-----------------------
CREATE PROCEDURE sp_GetAllHotels
AS
BEGIN
	SELECT  [Id]
			,[Name]
			,[Rating]
			,[Country]
			,[City]
			,[PhysicalAddress]
			,[ManagerId]
	FROM [HOTEL_DOIT].[dbo].[Hotel]
END

----------------------ADD HOTELS-----------------------
GO
CREATE PROCEDURE sp_AddHotel
	@name NVARCHAR(50),
	@rating float,
	@country NVARCHAR(50),
	@city NVARCHAR(50),
	@physAddress NVARCHAR(50),
	@ManagerId INT
AS
BEGIN
	INSERT INTO Hotel([Name], Rating, Country, City, PhysicalAddress,ManagerId)
		   VALUES (@name, @rating, @country, @city, @physAddress, @ManagerId)
END
----------------------UPDATE HOTELS-----------------------
GO
CREATE PROCEDURE sp_UpdateHotel
	@name NVARCHAR(50),
	@rating float,
	@country NVARCHAR(50),
	@city NVARCHAR(50),
	@physAddress NVARCHAR(50),
	@ManagerId INT,
	@id INT
AS
BEGIN
	UPDATE Hotel 
		SET [Name] = @name,
			Rating = @rating,
			Country = @country,
			City = @city,
			PhysicalAddress = @physAddress,
			ManagerId = @ManagerId
		WHERE Id = @id
END

----------------------DELETE HOTELS-----------------------
GO
CREATE PROCEDURE sp_DeleteHotel
	@id INT
AS
BEGIN
	DELETE Hotel WHERE Id = @id
END
CREATE PROCEDURE sp_GetSingleManager
@id as INT
AS
BEGIN
	SELECT [Id]
		  ,[FirstName]
		  ,[LastName]
		  ,[HotelId]
	FROM Managers
	WHERE @id = Id
END

GO
CREATE PROCEDURE sp_GetSingleRoom
@id AS INT
AS
BEGIN
	SELECT 
		Id,
		[Name],
		IsFree,
		HotelId,
		DailyPrice
	FROM Rooms
	WHERE @id = Id 
END

GO
CREATE PROCEDURE sp_GetSingleHotel
@id INT
AS
BEGIN
	SELECT
		[Id]
	   ,[Name]
       ,[Rating]
       ,[Country]
       ,[City]
       ,[PhyisicalAddress]
	FROM Hotels
	WHERE @id = Id
END


-----------------------CREATING sp_GetHotelsWithoutManager
GO
CREATE PROCEDURE sp_GetHotelsWithoutManager
AS
BEGIN
	SELECT 
		H.Id,
		H.[Name],
		H.Rating,
		H.Country,
		H.City,
		H.PhyisicalAddress
	FROM 
		Hotels H
	LEFT JOIN 
		Managers M ON H.Id = M.HotelId
	WHERE 
		M.HotelId IS NULL
END
CREATE PROCEDURE sp_DeleteInventoryDetails
 @ProductId INT
AS
BEGIN
   DELETE FROM Inventory
   WHERE ProductId = @ProductId
END


EXEC sp_DeleteInventoryDetails 123123
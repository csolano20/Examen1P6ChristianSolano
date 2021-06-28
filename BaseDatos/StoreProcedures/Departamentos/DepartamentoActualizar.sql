CREATE PROCEDURE [dbo].[DepartamentoActualizar]
	@ID int,
	@Descripcion VARCHAR (250),
	@Ubicacion VARCHAR (250),
	@Estado BIT 
AS
BEGIN
    SET NOCOUNT ON
	BEGIN TRANSACTION TRASA

	BEGIN TRY 
	
	UPDATE Departamentos 
	
		SET Descripcion = @Descripcion,
		Ubicacion = @Ubicacion,
	    Estado = @Estado 
		where Id_Departamento =@ID
	
	  
	COMMIT TRANSACTION TRASA
	
	 SELECT 0 AS CodeError, '' AS MsgError

	END TRY 

	BEGIN CATCH 
	    SELECT 
		  ERROR_NUMBER() AS CodeError
		, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA
	END  CATCH

END


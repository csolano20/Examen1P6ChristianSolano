CREATE PROCEDURE [dbo].[PuestoActualizar]
    @ID int,
	@Nombre VARCHAR (250),
	@Salario int = null,
	@Estado BIT 
AS
BEGIN
    SET NOCOUNT ON
	BEGIN TRANSACTION TRASA

	BEGIN TRY 
	
	UPDATE Puestos 
	
		SET Nombre = @Nombre,
		Salario = @Salario,
	    Estado = @Estado 
		where Id_Puesto = @ID
	
	  
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


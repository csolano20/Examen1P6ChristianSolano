CREATE PROCEDURE [dbo].[PuestoObtener]
	@ID INT = NULL
	
AS
	BEGIN
	SET NOCOUNT ON 

	SELECT id_Puesto  as ID
	      
         , Nombre
		 , Salario
		 , Estado
	FROM Puestos
	WHERE (@ID IS NULL OR  id_Puesto = @ID)
	END
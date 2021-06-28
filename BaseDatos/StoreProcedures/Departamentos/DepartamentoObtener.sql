CREATE PROCEDURE [dbo].[DepartamentoObtener]
	@ID INT = NULL
	
AS
	BEGIN
	SET NOCOUNT ON 

	SELECT 
	      Id_Departamento as ID   
         , Descripcion
		 , Ubicacion
		 , Estado
	FROM Departamentos
	WHERE (@ID IS NULL OR  Id_Departamento = @ID)
	END

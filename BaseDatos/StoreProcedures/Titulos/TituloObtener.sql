CREATE PROCEDURE [dbo].[TituloObtener]
	@ID INT = NULL
	
AS
	BEGIN
	SET NOCOUNT ON 

	SELECT id_Titulo as ID     
         , Descripcion
		 , Estado
	FROM Titulos
	WHERE (@ID IS NULL OR  Id_Titulo = @ID)
	END

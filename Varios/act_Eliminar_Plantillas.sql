DELETE Bitacora WHERE IdFuncion IN ('ImportarProdPlantillaExcel','PlantillasPreciosABM')
GO

DELETE RolesFunciones WHERE IdFuncion IN ('ImportarProdPlantillaExcel','PlantillasPreciosABM') 
GO

DELETE Funciones WHERE Id IN ('ImportarProdPlantillaExcel','PlantillasPreciosABM')
GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.PlantillasCampos') )
    DROP TABLE dbo.PlantillasCampos
GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.Plantillas') )
    DROP TABLE dbo.Plantillas
GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.Campos') )
    DROP TABLE dbo.Campos
GO

DECLARE @max int
SET @max = (SELECT IdBuscador FROM Buscadores WHERE Titulo = 'Plantillas')

DELETE BuscadoresCampos WHERE IdBuscador = @max;

DELETE Buscadores WHERE IdBuscador = @max 
GO

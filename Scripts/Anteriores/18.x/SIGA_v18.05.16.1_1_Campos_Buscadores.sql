
PRINT '' 
PRINT '1. Tabla Buscadores: Agrego Campos: IniciaConFocoEn/ColumaBusquedaInicial' 
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Buscadores ADD IniciaConFocoEn varchar(15) NULL
ALTER TABLE dbo.Buscadores ADD ColumaBusquedaInicial varchar(50) NULL
GO

PRINT '' 
PRINT '2. Tabla Buscadores: Seteo IniciaConFocoEn que se posicione en la grilla.' 
GO

UPDATE Buscadores SET IniciaConFocoEn = 'Grilla', ColumaBusquedaInicial = '';
-- DISTRIBUIDORA ERRE

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('20177516342'))	

BEGIN
    PRINT '' 
    PRINT '3. Tabla Buscadores: Seteo IniciaConFocoEn que se posicione en la TAB y Descripcion de Producto.' 

    UPDATE Buscadores
       SET IniciaConFocoEn = 'Busqueda'
          ,ColumaBusquedaInicial = 'NombreProducto'
     WHERE Titulo = 'Productos'
END

PRINT '' 
PRINT '4. Tabla Buscadores: Campos nuevos NOT NULL.' 
GO

ALTER TABLE dbo.Buscadores ALTER COLUMN IniciaConFocoEn varchar(15) NOT NULL
ALTER TABLE dbo.Buscadores ALTER COLUMN ColumaBusquedaInicial varchar(50) NOT NULL
GO
ALTER TABLE dbo.Buscadores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

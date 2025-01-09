
GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;

GO
PRINT '1. Productos: Elimino todas las Constraints de Valor Predeterminado';

GO
IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_2') )
    DROP TABLE dbo.t_Referencias_2
--

SELECT t.name AS Nombre_Tabla_Dep
      ,c.name AS NombreColumna
      ,co.name as NombreConstraint
      ,' ALTER TABLE ' + SCHEMA_NAME(t.[schema_id]) + '.' + t.[name] + ' DROP CONSTRAINT [' + co.name + ']' AS DROP_CO
INTO    dbo.t_Referencias_2 
FROM    SYS.TABLES t
        INNER JOIN sys.all_columns c ON (c.object_id = t.object_id)
        INNER JOIN sys.all_objects co ON (co.object_id = c.default_object_id)       
WHERE t.[name] = 'Productos'
  AND c.name in ('UHPorc1', 'UHPorc2', 'UHPorc3', 'UnidHasta1', 'UnidHasta2', 'UnidHasta3')
ORDER BY co.name
--
GO 
--// Eliminar FKs
DECLARE @vSQL VARCHAR(MAX);
SET @vSQL = '';
--
SELECT @vSQL = @vSQL + CHAR(13) + CHAR(10) + r.DROP_CO FROM dbo.t_Referencias_2 r
--
PRINT @vSQL
EXEC (@vSQL)
--

GO
PRINT '2. Productos: Cambio los tipos de Datos';

ALTER TABLE Productos ALTER COLUMN UnidHasta1 Decimal(14, 4) NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UnidHasta2 Decimal(14, 4) NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UnidHasta3 Decimal(14, 4) NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UHPorc1 Decimal(5, 2) NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UHPorc2 Decimal(5, 2) NOT NULL
GO
ALTER TABLE Productos ALTER COLUMN UHPorc3 Decimal(5, 2) NOT NULL
GO


PRINT '3. AuditoriaProductos: Cambio los tipos de Datos';

ALTER TABLE AuditoriaProductos ALTER COLUMN UnidHasta1 Decimal(14, 4) NULL
GO
ALTER TABLE AuditoriaProductos ALTER COLUMN UnidHasta2 Decimal(14, 4) NULL
GO
ALTER TABLE AuditoriaProductos ALTER COLUMN UnidHasta3 Decimal(14, 4) NULL
GO
ALTER TABLE AuditoriaProductos ALTER COLUMN UHPorc1 Decimal(5, 2) NULL
GO
ALTER TABLE AuditoriaProductos ALTER COLUMN UHPorc2 Decimal(5, 2) NULL
GO
ALTER TABLE AuditoriaProductos ALTER COLUMN UHPorc3 Decimal(5, 2) NULL
GO

PRINT '4. Productos: Vuelvo a Asignar los Valores Predeterminados';

ALTER TABLE Productos ADD DEFAULT 0 FOR UnidHasta1 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UnidHasta2 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UnidHasta3 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UHPorc1 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UHPorc2 
GO
ALTER TABLE Productos ADD DEFAULT 0 FOR UHPorc3 
GO

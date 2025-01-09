
/* Borro las FKs hacia la tabla CLIENTES */
-------------------------------------------

-- /// Tabla BKP con referencias 
--
IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_3') )
    DROP TABLE dbo.t_Referencias_3
--
SELECT  t.[name] AS Nombre_Tabla_Dep,
        fk.name AS FK_Name,
        ' ALTER TABLE ' + SCHEMA_NAME(t.[schema_id]) + '.' + ta.[name] + ' DROP CONSTRAINT [' + fk.name + ']' AS DROP_FK
INTO    dbo.t_Referencias_3 
FROM    SYS.TABLES t
        INNER JOIN SYS.FOREIGN_KEYS fk ON (fk.referenced_object_id = t.object_id)
        INNER JOIN SYS.TABLES ta ON (ta.object_id = fk.parent_object_id)
WHERE   t.[name] = 'Proveedores'   -- COLOCAR UN NOMBRE DE TABLA
ORDER BY fk.name
--
GO 
--// Eliminar FKs
DECLARE @vSQL VARCHAR(MAX);
SET @vSQL = '';
--
SELECT @vSQL = @vSQL + CHAR(13) + CHAR(10) + r.DROP_FK FROM dbo.t_Referencias_3 r
--
PRINT @vSQL
EXEC (@vSQL)
--
GO

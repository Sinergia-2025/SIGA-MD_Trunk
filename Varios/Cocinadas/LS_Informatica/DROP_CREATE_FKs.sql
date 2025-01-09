-- /// Tabla BKP con referencias 
--
IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias') )
    DROP TABLE dbo.t_Referencias
--
SELECT  SCHEMA_NAME(ta.[schema_id]) AS Nombre_Esquema,
        ta.[name] AS Nombre_Tabla,
        co.[name] AS Nombre_Columna,
        SCHEMA_NAME(t.[schema_id]) AS Nombre_Esquema_Dep,
        t.[name] AS Nombre_Tabla_Dep,
        c.[name] AS Nombre_Columna_Dep,
        OBJECT_NAME (fkc.constraint_object_id) AS FK_Name,
        ' ALTER TABLE ' + SCHEMA_NAME(t.[schema_id]) + '.' + t.[name] + ' DROP CONSTRAINT [' + OBJECT_NAME (fkc.constraint_object_id) + ']' AS DROP_FK,
        ' ALTER TABLE ' + SCHEMA_NAME(t.[schema_id]) + '.' + t.[name] + ' ADD CONSTRAINT [' + OBJECT_NAME (fkc.constraint_object_id) + '] FOREIGN KEY (' + c.[name] + ') ' + 
        ' REFERENCES ' + SCHEMA_NAME(ta.[schema_id]) + '.' + ta.[name] + ' (' + co.[name] + ')' AS CREATE_FK
--INTO    dbo.t_Referencias 
FROM    SYS.TABLES t 
        INNER JOIN SYS.COLUMNS c ON (c.[object_id] = t.[object_id])
        INNER JOIN SYS.FOREIGN_KEY_COLUMNS fkc ON (fkc.parent_object_id = c.[object_id] AND fkc.parent_column_id = c.column_id) 
        INNER JOIN SYS.COLUMNS co ON (co.object_id = fkc.referenced_object_id AND co.column_id = fkc.referenced_column_id)
        INNER JOIN SYS.TABLES ta ON (ta.object_id = co.object_id)
WHERE   1 = 1
        AND ta.[name] = 'Usuarios'   -- COLOCAR UN NOMBRE DE TABLA
--
GO 


----// Eliminar FKs
--DECLARE @vSQL VARCHAR(MAX);
--SET @vSQL = '';
----
--SELECT  @vSQL = @vSQL + CHAR(13) + CHAR(10) + r.DROP_FK
--FROM    dbo.t_Referencias r
----
--PRINT @vSQL
--EXEC (@vSQL)
----
--GO
----********************************************************************
----
---- REALIZAR CAMBIOS QUE SEAN NECESARIOS EN ESTE SECTOR
----
----********************************************************************
--GO 
----// Crear nuevamente FKs
--DECLARE @vSQL_n VARCHAR(MAX);
--SET @vSQL_n = '';
----
--SELECT  @vSQL_n = @vSQL_n + CHAR(13) + CHAR(10) + r.CREATE_FK 
--FROM    dbo.t_Referencias r
----
--PRINT @vSQL_n
--EXEC (@vSQL_n)
----
----//













--GO
----
--CREATE PROCEDURE [dbo].[DropConstraints] 
--@tablename nvarchar(500), 
--@columnname nvarchar(500)
--AS
 
--SELECT CONSTRAINT_NAME, 'C' AS type
--INTO #dependencies
--FROM    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE 
--WHERE   TABLE_NAME = @tablename AND 
--        COLUMN_NAME = @columnname
 
--INSERT INTO #dependencies
--select d.name, 'C'
--from sys.default_constraints d
--join sys.columns c ON c.column_id = d.parent_column_id AND c.object_id = d.parent_object_id
--join sys.objects o ON o.object_id = d.parent_object_id
--WHERE o.name = @tablename AND c.name = @columnname
 
--INSERT INTO #dependencies
--SELECT i.name, 'I'
--FROM sys.indexes i
--JOIN sys.index_columns ic ON ic.index_id = i.index_id and ic.object_id=i.object_id
--JOIN sys.columns c ON c.column_id = ic.column_id and c.object_id=i.object_id
--JOIN sys.objects o ON o.object_id = i.object_id
--where o.name = @tableName AND i.type=2 AND c.name = @columnname AND is_unique_constraint = 0
 
--DECLARE @dep_name nvarchar(500)
--DECLARE @type nchar(1)
 
--DECLARE dep_cursor CURSOR
--FOR SELECT * FROM #dependencies
 
--OPEN dep_cursor
 
--FETCH NEXT FROM dep_cursor 
--INTO @dep_name, @type;
 
--DECLARE @sql nvarchar(max)
 
--WHILE @@FETCH_STATUS = 0
--BEGIN
--    SET @sql = 
--        CASE @type
--            WHEN 'C' THEN 'ALTER TABLE [' + @tablename + '] DROP CONSTRAINT [' + @dep_name + ']'
--            WHEN 'I' THEN 'DROP INDEX [' + @dep_name + '] ON dbo.[' + @tablename + ']'
--        END
--    print @sql
--    EXEC sp_executesql @sql
--    FETCH NEXT FROM dep_cursor 
--    INTO @dep_name, @type;
--END
 
--DEALLOCATE dep_cursor
 
--DROP TABLE #dependencies
 
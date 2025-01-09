PRINT ''
PRINT '1. Shrink de la BD SIGA'
DBCC SHRINKDATABASE (SIGA, 0);


PRINT '**************************************************************************************************************************************************************************'
PRINT 'Si el servidor tiene más de una base se debe ejecutar este script para cada base cambiando ´SIGA´ por el nombre de la base de datos que corresponde en el SHRINK de arriba'
PRINT '**************************************************************************************************************************************************************************'


PRINT ''
PRINT '2. Recreate de los indices de la BD'
PRINT '2.1. Si da error, considerar restaurar el Backup'
DECLARE @TableName varchar(255) 
DECLARE TableCursor CURSOR FOR 

SELECT table_name FROM information_schema.tables 
  WHERE table_type = 'base table' 

OPEN TableCursor 
    FETCH NEXT FROM TableCursor INTO @TableName 

WHILE @@FETCH_STATUS = 0 
BEGIN 
    DBCC DBREINDEX(@TableName,' ',90) 
    FETCH NEXT FROM TableCursor INTO @TableName 
END 

CLOSE TableCursor 

DEALLOCATE TableCursor 

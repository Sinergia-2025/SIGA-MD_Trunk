PRINT ''
PRINT '1. Letra a.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'á','a')
    , Descripcion = REPLACE(Descripcion,'á','a')
 WHERE Nombre like '%á%' 
    OR Descripcion like '%á%'
GO

PRINT ''
PRINT '2. Letra e.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'é','e')
    , Descripcion = REPLACE(Descripcion,'é','e')
 WHERE Nombre like '%é%' 
    OR Descripcion like '%é%'
GO

PRINT ''
PRINT '3. Letra i.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'í','i')
    , Descripcion = REPLACE(Descripcion,'í','i')
 WHERE Nombre like '%í%' 
    OR Descripcion like '%í%'
GO


PRINT ''
PRINT '4. Letra o.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'ó','o')
    , Descripcion = REPLACE(Descripcion,'ó','o')
 WHERE Nombre like '%ó%' 
    OR Descripcion like '%ó%'
GO

PRINT ''
PRINT '5. Letra u.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'ú','u')
    , Descripcion = REPLACE(Descripcion,'ú','u')
 WHERE Nombre like '%ú%' 
    OR Descripcion like '%ú%'
GO

PRINT ''
PRINT '1. Letra a.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'�','a')
    , Descripcion = REPLACE(Descripcion,'�','a')
 WHERE Nombre like '%�%' 
    OR Descripcion like '%�%'
GO

PRINT ''
PRINT '2. Letra e.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'�','e')
    , Descripcion = REPLACE(Descripcion,'�','e')
 WHERE Nombre like '%�%' 
    OR Descripcion like '%�%'
GO

PRINT ''
PRINT '3. Letra i.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'�','i')
    , Descripcion = REPLACE(Descripcion,'�','i')
 WHERE Nombre like '%�%' 
    OR Descripcion like '%�%'
GO


PRINT ''
PRINT '4. Letra o.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'�','o')
    , Descripcion = REPLACE(Descripcion,'�','o')
 WHERE Nombre like '%�%' 
    OR Descripcion like '%�%'
GO

PRINT ''
PRINT '5. Letra u.'
UPDATE Funciones
  SET Nombre = REPLACE(Nombre,'�','u')
    , Descripcion = REPLACE(Descripcion,'�','u')
 WHERE Nombre like '%�%' 
    OR Descripcion like '%�%'
GO


UPDATE ListasDePrecios
  SET NombreListaPrecios = LTRIM(NombreListaPrecios)
GO

--Ahora se ordena por nombre, dejo primero la principal.

UPDATE ListasDePrecios
   SET NombreListaPrecios = ' ' + LEFT(NombreListaPrecios,49) 
 WHERE IdListaPrecios = 0
GO



PRINT ''
PRINT '1. Tabla Clientes: Pasamos a CUIT aquellos DNI que son CUITs.'
GO

UPDATE Clientes
   SET Cuit = NroDocCliente
 WHERE TipoDocCliente = 'CUIT'
   AND ISNULL(Cuit, '') = ''
   AND LEN(NroDocCliente) = 11
GO


PRINT ''
PRINT '2. Tabla Clientes: Limpiamos los DNIs que son CUITs.'
GO

UPDATE Clientes
   SET TipoDocCliente = NULL
      ,NroDocCliente = NULL
 WHERE TipoDocCliente = 'CUIT'
   AND ISNULL(Cuit, '') = ''
   AND LEN(NroDocCliente) = 11
GO


PRINT ''
PRINT '3. Tabla Clientes: Limpiamos los DNIs que son IGUAL al CUITs.'
GO

UPDATE Clientes
   SET TipoDocCliente = NULL
      ,NroDocCliente = NULL
 WHERE TipoDocCliente = 'CUIT'
   AND LEN(NroDocCliente) = 11
   AND CUIT = NroDocCliente
GO

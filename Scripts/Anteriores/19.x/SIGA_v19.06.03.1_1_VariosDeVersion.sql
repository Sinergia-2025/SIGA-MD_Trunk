PRINT ''
PRINT '1. Tabla Compras: Nuevos campo NombreProveedor y CuitProveedor'
ALTER TABLE Compras ADD NombreProveedor	varchar(100)	null
ALTER TABLE Compras ADD CuitProveedor	varchar(13)	null
GO

PRINT ''
PRINT '2. Parametros: Carga fecha de inicio de actividades como 01/01/1900 si está en blanco'
UPDATE Parametros
   SET ValorParametro = '01/01/1900'
 WHERE IdParametro = 'FECHAINICIOACTIVIDADES'
   AND ISNULL(ValorParametro, '') = ''

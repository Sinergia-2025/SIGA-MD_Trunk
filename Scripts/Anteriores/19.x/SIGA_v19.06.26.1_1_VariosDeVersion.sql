PRINT ''
PRINT '1. Tabla CajasDetalle: Nueva columna CotizacionDolar'
ALTER TABLE dbo.CajasDetalle ADD CotizacionDolar decimal(10, 3) NULL
GO
PRINT ''
PRINT '1.1. Tabla CajasDetalle: Valor por defecto a CotizacionDolar'
UPDATE CajasDetalle SET CotizacionDolar = 0;
PRINT ''
PRINT '1.2. Tabla CajasDetalle: NOT NULL CotizacionDolar'
ALTER TABLE dbo.CajasDetalle ALTER COLUMN CotizacionDolar decimal(10, 3) NOT NULL

PRINT ''
PRINT '2. Inicializar Numerador para Productos'
 INSERT INTO Numeradores
          (IdNumerador,Numero,Descripcion)
SELECT 'PRODUCTOS', MAX(CONVERT(DECIMAL, REPLACE(REPLACE(IdProducto, ',', ''), '.', ''))), ''
  FROM Productos
 WHERE IdProducto not in ('+',' ')
 and ISNUMERIC(IdProducto) = 1

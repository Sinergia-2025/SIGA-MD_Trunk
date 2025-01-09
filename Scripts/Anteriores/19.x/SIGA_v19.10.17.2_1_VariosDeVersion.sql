PRINT ''
PRINT '1. Tabla Categorias: Agrega campo Comisiones.'
ALTER TABLE Categorias ADD Comisiones decimal(7,4) null
GO
PRINT ''
PRINT '1.1. Tabla Categorias: Valores por defecto para campo Comisiones.'
UPDATE Categorias SET Comisiones = 0
GO
PRINT ''
PRINT '1.2. Tabla Categorias: NOT NULL para campo Comisiones.'
ALTER TABLE Categorias ALTER COLUMN Comisiones decimal(7,4) not null
GO

PRINT'2. Tabla AFIPTiposComprobantes: Corrige Fechas de Vencimiento en FCE'
UPDATE [dbo].[AFIPTiposComprobantes]
   SET [IncluyeFechaVencimiento] = 'False'
 WHERE [IdAFIPTipoComprobante] IN (201,202,203,206,207,208,211,212,213)



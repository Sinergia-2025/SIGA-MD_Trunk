
/* Agrega y setea que el Producto Afecta STOCK */

ALTER TABLE dbo.Productos ADD AfectaStock bit NULL
GO

UPDATE dbo.Productos
 SET AfectaStock=1
GO


ALTER TABLE dbo.Productos ALTER COLUMN AfectaStock bit NOT NULL 
GO


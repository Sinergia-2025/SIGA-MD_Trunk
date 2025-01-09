
/* Agrega y setea que el Producto posee Alerta de Caja */

ALTER TABLE dbo.Productos ADD AlertaDeCaja bit NULL
GO

UPDATE dbo.Productos SET AlertaDeCaja = 'False'
GO

ALTER TABLE dbo.Productos ALTER COLUMN AlertaDeCaja bit NOT NULL 
GO

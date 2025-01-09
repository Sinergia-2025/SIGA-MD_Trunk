
/* Agrega y setea que el Producto Solicita Envase */

ALTER TABLE dbo.Productos ADD SolicitaEnvase bit NULL
GO

UPDATE dbo.Productos
   SET SolicitaEnvase = 'False'
GO

ALTER TABLE dbo.Productos ALTER COLUMN SolicitaEnvase bit NOT NULL 
GO

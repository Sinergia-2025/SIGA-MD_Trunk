
ALTER TABLE Clientes ADD [CodigoCliente] [bigint] NULL
GO

UPDATE Clientes
   SET CodigoCliente = NroDocumento
 WHERE LEN(NroDocumento)<6
  AND TipoDocumento IN ('COD','ID')
GO

UPDATE Clientes
   SET CodigoCliente = (SELECT MAX(CodigoCliente) FROM Clientes WHERE CodigoCliente IS NOT NULL)+(SELECT MAX(CodigoCliente) FROM Clientes WHERE CodigoCliente IS NOT NULL)-IdCliente
 WHERE CodigoCliente IS NULL
GO

ALTER TABLE Clientes ALTER COLUMN [CodigoCliente] [bigint] NOT NULL
GO

/*
----- REVISAR !!!!
SELECT TipoDocumento, NroDocumento, IdCliente, CodigoCliente 
  FROM Clientes
  ORDER BY CodigoCliente
GO  
    
UPDATE Clientes
   SET CodigoCliente = CodigoCliente - 26000000
 WHERE CodigoCliente > 62000000
GO
*/


/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	IX_Clientes UNIQUE NONCLUSTERED 
	(
	CodigoCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



ALTER TABLE Proveedores ADD [CodigoProveedor] [bigint] NULL
GO

UPDATE Proveedores
   SET CodigoProveedor = NroDocProveedor
 WHERE LEN(NroDocProveedor)<6
  AND TipoDocProveedor IN ('COD','ID')
GO

UPDATE Proveedores
   SET CodigoProveedor = (SELECT MAX(CodigoProveedor) FROM Proveedores WHERE CodigoProveedor IS NOT NULL)+(SELECT MAX(CodigoProveedor) FROM Proveedores WHERE CodigoProveedor IS NOT NULL)-IdProveedor
 WHERE CodigoProveedor IS NULL
GO

ALTER TABLE Proveedores ALTER COLUMN [CodigoProveedor] [bigint] NOT NULL
GO

/*
----- REVISAR !!!!
SELECT TipoDocProveedor, NroDocProveedor, IdProveedor, CodigoProveedor 
  FROM Proveedores
  ORDER BY CodigoProveedor
GO  
    
UPDATE Proveedores
   SET CodigoProveedor = CodigoProveedor - 26000000
 WHERE CodigoProveedor > 62000000
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
ALTER TABLE dbo.Proveedores ADD CONSTRAINT
	IX_Proveedores UNIQUE NONCLUSTERED 
	(
	CodigoProveedor
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


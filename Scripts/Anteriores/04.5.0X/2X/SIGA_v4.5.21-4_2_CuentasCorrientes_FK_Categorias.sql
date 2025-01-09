-- Puede existir alguna en cero.

--SELECT * FROM CuentasCorrientes
-- WHERE NOT EXISTS 
--     ( SELECT * FROM Categorias C
--       WHERE C.IdCategoria = CuentasCorrientes.IdCategoria )
--GO

UPDATE CuentasCorrientes 
   SET CuentasCorrientes.IdCategoria = C.IdCategoria 
 FROM CuentasCorrientes CC
 INNER JOIN CLientes C ON CC.IdCliente = C.IdCliente
 WHERE CC.IdCategoria = 0
GO


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
ALTER TABLE dbo.Categorias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT
	FK_CuentasCorrientes_Categorias FOREIGN KEY
	(
	IdCategoria
	) REFERENCES dbo.Categorias
	(
	IdCategoria
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


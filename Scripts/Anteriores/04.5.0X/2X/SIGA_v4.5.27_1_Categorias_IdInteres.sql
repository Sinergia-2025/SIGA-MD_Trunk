
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
ALTER TABLE dbo.Intereses SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Categorias ADD IdInteres int NULL
GO
ALTER TABLE dbo.Categorias ADD CONSTRAINT
    FK_Categorias_Intereses FOREIGN KEY (IdInteres)
    REFERENCES dbo.Intereses (IdInteres)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Categorias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* -------------- */

UPDATE Categorias
   SET IdInteres = Intereses.IdInteres
  FROM Categorias
 CROSS JOIN (SELECT TOP 1 * FROM Intereses) Intereses

SELECT IdCategoria, NombreCategoria, IdInteres FROM Categorias
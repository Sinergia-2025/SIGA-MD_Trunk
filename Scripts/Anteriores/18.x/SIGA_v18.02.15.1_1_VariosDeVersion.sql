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
ALTER TABLE dbo.VentasFormasPago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ListasDePrecios ADD IdFormasPago int NULL
GO
ALTER TABLE dbo.ListasDePrecios ADD CONSTRAINT FK_ListasDePrecios_VentasFormasPago
    FOREIGN KEY (IdFormasPago)
    REFERENCES dbo.VentasFormasPago (IdFormasPago)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION
GO
ALTER TABLE dbo.ListasDePrecios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

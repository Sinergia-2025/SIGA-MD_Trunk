
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
ALTER TABLE dbo.Transportistas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Compras ADD Bultos int NULL
ALTER TABLE dbo.Compras ADD ValorDeclarado decimal(12, 2) NULL
ALTER TABLE dbo.Compras ADD IdTransportista int NULL
ALTER TABLE dbo.Compras ADD NumeroLote bigint NULL
GO
UPDATE Compras SET Bultos = 0, ValorDeclarado = 0, NumeroLote = 0;
ALTER TABLE dbo.Compras ALTER COLUMN Bultos int NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN ValorDeclarado decimal(12, 2) NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN NumeroLote bigint NOT NULL
GO

ALTER TABLE dbo.Compras ADD CONSTRAINT FK_Compras_Transportistas
    FOREIGN KEY (IdTransportista)
    REFERENCES dbo.Transportistas (IdTransportista)
    ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

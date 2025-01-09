
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
ALTER TABLE dbo.EstadosVisitas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pedidos ADD IdEstadoVisita int NULL
GO
ALTER TABLE dbo.Pedidos ADD CONSTRAINT FK_Pedidos_EstadosVisitas 
    FOREIGN KEY (IdEstadoVisita)
    REFERENCES dbo.EstadosVisitas (IdEstadoVisita)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

UPDATE Pedidos SET IdEstadoVisita = 1
GO

ALTER TABLE dbo.Pedidos ALTER COLUMN IdEstadoVisita int NOT NULL
GO
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

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
ALTER TABLE dbo.HistorialPrecios ADD NombreListaPrecios varchar(50) NULL
GO
UPDATE HistorialPrecios
   SET NombreListaPrecios = ISNULL(LDP.NombreListaPrecios, '')
  FROM HistorialPrecios HP
  LEFT JOIN ListasDePrecios LDP ON LDP.IdListaPrecios = HP.IdListaPrecios;
ALTER TABLE dbo.HistorialPrecios ALTER COLUMN NombreListaPrecios varchar(50) NOT NULL
GO
ALTER TABLE dbo.HistorialPrecios ALTER COLUMN PrecioFabrica decimal(14,4) NULL
GO
ALTER TABLE dbo.HistorialPrecios ALTER COLUMN PrecioCosto decimal(14,4) NULL
GO
ALTER TABLE dbo.HistorialPrecios ALTER COLUMN PrecioVenta decimal(14,4) NULL
GO
ALTER TABLE dbo.HistorialPrecios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

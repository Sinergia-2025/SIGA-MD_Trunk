
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
ALTER TABLE dbo.Alquileres ADD
	ImporteAlquiler decimal(14, 4) NULL,
	ImporteTraslado decimal(14, 4) NULL
GO

UPDATE dbo.Alquileres 
   SET ImporteAlquiler = ImporteTotal
     , ImporteTraslado = 0
GO

ALTER TABLE dbo.Alquileres ALTER COLUMN ImporteAlquiler decimal(14, 4) NOT NULL
GO

ALTER TABLE dbo.Alquileres ALTER COLUMN ImporteTraslado decimal(14, 4) NOT NULL
GO

ALTER TABLE dbo.Alquileres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

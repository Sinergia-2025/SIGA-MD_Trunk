
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
ALTER TABLE dbo.Compras ADD FechaOficializacionDespacho datetime NULL
ALTER TABLE dbo.Compras ADD IdAduana int NULL
ALTER TABLE dbo.Compras ADD IdDestinacion varchar(10) NULL
ALTER TABLE dbo.Compras ADD NumeroDespacho bigint NULL
ALTER TABLE dbo.Compras ADD DigitoVerificadorDespacho varchar(1) NULL
ALTER TABLE dbo.Compras ADD IdDespachante int NULL
ALTER TABLE dbo.Compras ADD IdAgenteTransporte int NULL
ALTER TABLE dbo.Compras ADD DerechoAduanero decimal(14, 2) NULL
ALTER TABLE dbo.Compras ADD BienCapitalDespacho bit NULL
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.ComprasImpuestos ADD EsDespacho bit NULL
GO
UPDATE ComprasImpuestos SET EsDespacho = 0;
ALTER TABLE dbo.ComprasImpuestos ALTER COLUMN EsDespacho bit NOT NULL
GO
ALTER TABLE dbo.ComprasImpuestos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

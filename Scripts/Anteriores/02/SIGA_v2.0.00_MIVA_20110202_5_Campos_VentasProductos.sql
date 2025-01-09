
ALTER TABLE dbo.VentasProductos ADD
	IdTipoImpuesto varchar(5) NULL,
	AlicuotaImpuesto decimal(6, 2) NULL,
	ImporteImpuesto decimal(12, 2) NULL
GO

/* Los Medios IVA quedaron con el 21 en el detalle, implementado mal */
UPDATE VentasProductos
 SET VentasProductos.PorcentajeIVA = 
       ( SELECT PorcentajeIVA FROM Ventas b
           WHERE VentasProductos.IdSucursal = b.IdSucursal
             AND VentasProductos.IdTipoComprobante = b.IdTipoComprobante
             AND VentasProductos.Letra = b.Letra
             AND VentasProductos.CentroEmisor = b.CentroEmisor
             AND VentasProductos.NumeroComprobante = b.NumeroComprobante
         )
 WHERE PorcentajeIVA = 21
GO

UPDATE VentasProductos SET
	IdTipoImpuesto = 'IVA',
	AlicuotaImpuesto = PorcentajeIVA,
	ImporteImpuesto = ROUND(ImporteTotalNeto * PorcentajeIVA / 100,2)
GO

ALTER TABLE dbo.VentasProductos ALTER COLUMN IdTipoImpuesto varchar(5) NOT NULL
GO

ALTER TABLE dbo.VentasProductos ALTER COLUMN AlicuotaImpuesto decimal(6, 2) NOT NULL
GO
	
ALTER TABLE dbo.VentasProductos ALTER COLUMN ImporteImpuesto decimal(12, 2) NOT NULL
GO


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
ALTER TABLE dbo.Impuestos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT
	FK_VentasProductos_Impuestos FOREIGN KEY
	(
	IdTipoImpuesto,
	AlicuotaImpuesto
	) REFERENCES dbo.Impuestos
	(
	IdTipoImpuesto,
	Alicuota
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



ALTER TABLE VentasProductos DROP COLUMN PorcentajeIVA
GO

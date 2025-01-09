
/* AGREGO EL CAMPO .*/

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
ALTER TABLE dbo.Ventas ADD
	Utilidad decimal(12, 2) NULL
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ACTUALIZO LA HISTORIA .*/

UPDATE Ventas
   SET Ventas.Utilidad = 0
 WHERE IdEstadoComprobante = 'ANULADO'
GO


UPDATE Ventas
   SET Ventas.Utilidad = 
       ( select sum(Utilidad) from VentasProductos b
           where Ventas.IdSucursal = b.IdSucursal
             AND Ventas.IdTipoComprobante = b.IdTipoComprobante
             AND Ventas.Letra = b.Letra
             AND Ventas.CentroEmisor = b.CentroEmisor
             AND Ventas.NumeroComprobante = b.NumeroComprobante
         )
 WHERE Utilidad IS NULL
GO

ALTER TABLE dbo.Ventas ALTER COLUMN Utilidad decimal(12, 2) NOT NULL
GO

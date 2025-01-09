
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
ALTER TABLE dbo.PedidosProductosProveedores ADD
	PrecioNeto decimal(12, 4) NULL
GO
ALTER TABLE dbo.PedidosProductosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


/* -- CALCULO DEL PRECIO NETO --- */


UPDATE dbo.PedidosProductosProveedores 
  SET  PrecioNeto = Precio * (1 + DescuentoRecargoPorc/100) * (1 + DescuentoRecargoPorc2/100)
GO

/* ---- */

ALTER TABLE dbo.PedidosProductosProveedores 
    ALTER COLUMN PrecioNeto decimal(12, 4) not NULL
GO

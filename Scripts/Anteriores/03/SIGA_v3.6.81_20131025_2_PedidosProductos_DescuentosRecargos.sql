
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.PedidosProductos ADD
		DescuentoRecargoProducto	decimal(14, 4)	NULL,
		DescuentoRecargoPorc2	decimal(6, 2)	NULL,
		DescuentoRecargoPorc	decimal(6, 2)	NULL,
		IdTipoImpuesto	varchar(5)	NULL,
		AlicuotaImpuesto	decimal(6, 2)	NULL,
		ImporteImpuesto	decimal(14, 4)	NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/*----------------------------------------------------------------------*/

UPDATE PedidosProductos
  SET DescuentoRecargoPorc2 = 0 , DescuentoRecargoProducto = 0 , DescuentoRecargoPorc = 0 ,IdTipoImpuesto='IVA',
  AlicuotaImpuesto = 0, ImporteImpuesto = 0
GO
/*----------------------------------------------------------------------*/

ALTER TABLE PedidosProductos ALTER COLUMN DescuentoRecargoProducto	decimal(14, 4)	NOT NULL 
ALTER TABLE PedidosProductos ALTER COLUMN DescuentoRecargoPorc2	decimal(6, 2) NOT NULL 
ALTER TABLE PedidosProductos ALTER COLUMN DescuentoRecargoPorc	decimal(6, 2)	NOT NULL
ALTER TABLE PedidosProductos ALTER COLUMN IdTipoImpuesto	varchar(5)	NOT NULL
ALTER TABLE PedidosProductos ALTER COLUMN AlicuotaImpuesto	decimal(6, 2)	NOT NULL
ALTER TABLE PedidosProductos ALTER COLUMN ImporteImpuesto	decimal(14, 4)	NOT NULL
		
	
GO

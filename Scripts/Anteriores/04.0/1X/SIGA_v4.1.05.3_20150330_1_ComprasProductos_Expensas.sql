
ALTER TABLE ComprasProductos ADD
	[PasajeMovimiento] [bit]  NULL,
	[MontoAplicado] [decimal](14, 4) NULL,
	[MontoSaldo] [decimal](14, 4) NULL,
	[ProporcionalImp] [decimal](14, 4) NULL
GO

--- Asumo Todos Pasados. Dejo los valores inconsistentes porque deberia proporcional Retenciones.
UPDATE ComprasProductos 
   SET PasajeMovimiento = 'True'
	 , MontoAplicado = 0
	 , MontoSaldo = 0
	 , ProporcionalImp = 0
GO

/* ------------------------ */

ALTER TABLE ComprasProductos ALTER COLUMN [PasajeMovimiento] [bit] NOT NULL
GO
ALTER TABLE ComprasProductos ALTER COLUMN [MontoAplicado] [decimal](14, 4) NOT NULL
GO
ALTER TABLE ComprasProductos ALTER COLUMN [MontoSaldo] [decimal](14, 4) NOT NULL
GO
ALTER TABLE ComprasProductos ALTER COLUMN [ProporcionalImp] [decimal](14, 4) NOT NULL
GO

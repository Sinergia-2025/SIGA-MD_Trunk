
/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.VentasProductos
	DROP CONSTRAINT FK_Ventas_Productos
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.VentasProductos
	DROP CONSTRAINT FK_VentasProductos_Ventas
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_VentasProductos
	(
	IdSucursal int NOT NULL,
	IdTipoComprobante varchar(15) NOT NULL,
	Letra varchar(1) NOT NULL,
	CentroEmisor int NOT NULL,
	NumeroComprobante bigint NOT NULL,
	Orden bigint NOT NULL IDENTITY (1, 1),
	IdProducto varchar(15) NOT NULL,
	Cantidad decimal(12, 2) NULL,
	Precio decimal(12, 2) NULL,
	Costo decimal(12, 2) NULL,
	DescRecGeneral decimal(12, 2) NULL,
	DescuentoRecargo decimal(12, 2) NULL,
	PrecioLista decimal(12, 2) NULL,
	Utilidad decimal(12, 2) NULL,
	ImporteTotal decimal(12, 2) NULL,
	DescuentoRecargoProducto decimal(12, 2) NULL,
	DescuentoRecargoPorc decimal(6, 2) NULL,
	DescRecGeneralProducto decimal(12, 2) NULL,
	PrecioNeto decimal(12, 2) NULL,
	ImporteTotalNeto decimal(12, 2) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Descuento Recargo de la Factura general'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_VentasProductos', N'COLUMN', N'DescRecGeneral'
GO
DECLARE @v sql_variant 
SET @v = N'Descuento Recargo de la Factura general'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_VentasProductos', N'COLUMN', N'DescRecGeneralProducto'
GO
SET IDENTITY_INSERT dbo.Tmp_VentasProductos OFF
GO
IF EXISTS(SELECT * FROM dbo.VentasProductos)
	 EXEC('INSERT INTO dbo.Tmp_VentasProductos (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProducto, Cantidad, Precio, Costo, DescRecGeneral, DescuentoRecargo, PrecioLista, Utilidad, ImporteTotal, DescuentoRecargoProducto, DescuentoRecargoPorc, DescRecGeneralProducto, PrecioNeto, ImporteTotalNeto)
		SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProducto, Cantidad, Precio, Costo, DescRecGeneral, DescuentoRecargo, PrecioLista, Utilidad, ImporteTotal, DescuentoRecargoProducto, DescuentoRecargoPorc, DescRecGeneralProducto, PrecioNeto, ImporteTotalNeto FROM dbo.VentasProductos WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.VentasProductos
GO
EXECUTE sp_rename N'dbo.Tmp_VentasProductos', N'VentasProductos', 'OBJECT' 
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT
	PK_VentasProductos PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	Orden
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT
	FK_VentasProductos_Ventas FOREIGN KEY
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) REFERENCES dbo.Ventas
	(
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdSucursal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.VentasProductos ADD CONSTRAINT
	FK_Ventas_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT



/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_MovimientosVentasProductos
	(
	IdSucursal int NOT NULL,
	IdTipoMovimiento varchar(15) NOT NULL,
	NumeroMovimiento bigint NOT NULL,
	Orden bigint NOT NULL IDENTITY (1, 1),
	IdProducto varchar(15) NOT NULL,
	Cantidad decimal(12, 2) NULL,
	Precio decimal(12, 2) NULL
	)  ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_MovimientosVentasProductos OFF
GO
IF EXISTS(SELECT * FROM dbo.MovimientosVentasProductos)
	 EXEC('INSERT INTO dbo.Tmp_MovimientosVentasProductos (IdSucursal, IdTipoMovimiento, NumeroMovimiento, IdProducto, Cantidad, Precio)
		SELECT IdSucursal, IdTipoMovimiento, NumeroMovimiento, IdProducto, Cantidad, Precio FROM dbo.MovimientosVentasProductos WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.MovimientosVentasProductos
GO
EXECUTE sp_rename N'dbo.Tmp_MovimientosVentasProductos', N'MovimientosVentasProductos', 'OBJECT' 
GO
ALTER TABLE dbo.MovimientosVentasProductos ADD CONSTRAINT
	PK_MovimientosVentasProductos_1 PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdTipoMovimiento,
	NumeroMovimiento,
	Orden
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.MovimientosVentasProductos ADD CONSTRAINT
	FK_MovimientosVentasProductos_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimientosVentasProductos ADD CONSTRAINT
	FK_MovimientosVentasProductos_MovimientosVentas FOREIGN KEY
	(
	IdSucursal,
	IdTipoMovimiento,
	NumeroMovimiento
	) REFERENCES dbo.MovimientosVentas
	(
	IdSucursal,
	IdTipoMovimiento,
	NumeroMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.ComprasProductos
	DROP CONSTRAINT FK_ComprasProductos_Productos
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ComprasProductos
	DROP CONSTRAINT FK_ComprasProductos_Compras
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_ComprasProductos
	(
	IdSucursal int NOT NULL,
	IdTipoComprobante varchar(15) NOT NULL,
	Letra varchar(1) NOT NULL,
	CentroEmisor int NOT NULL,
	NumeroComprobante bigint NOT NULL,
	TipoDocProveedor varchar(5) NOT NULL,
	NroDocProveedor bigint NOT NULL,
	Orden bigint NOT NULL IDENTITY (1, 1),
	IdProducto varchar(15) NOT NULL,
	Cantidad decimal(12, 2) NULL,
	Precio decimal(12, 2) NULL,
	DescRecGeneral decimal(12, 2) NULL,
	DescuentoRecargo decimal(12, 2) NULL,
	ImporteTotal decimal(12, 2) NULL,
	DescuentoRecargoProducto decimal(12, 2) NULL,
	DescuentoRecargoPorc decimal(6, 2) NULL,
	DescRecGeneralProducto decimal(12, 2) NULL,
	PrecioNeto decimal(12, 2) NULL,
	ImporteTotalNeto decimal(12, 2) NULL,
	PorcentajeIVA decimal(12, 2) NULL,
	IVA decimal(12, 2) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'Descuento Recargo de la Factura general'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_ComprasProductos', N'COLUMN', N'DescRecGeneralProducto'
GO
SET IDENTITY_INSERT dbo.Tmp_ComprasProductos OFF
GO
IF EXISTS(SELECT * FROM dbo.ComprasProductos)
	 EXEC('INSERT INTO dbo.Tmp_ComprasProductos (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, TipoDocProveedor, NroDocProveedor, IdProducto, Cantidad, Precio, DescRecGeneral, DescuentoRecargo, ImporteTotal, DescuentoRecargoProducto, DescuentoRecargoPorc, DescRecGeneralProducto, PrecioNeto, ImporteTotalNeto, PorcentajeIVA, IVA)
		SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, TipoDocProveedor, NroDocProveedor, IdProducto, Cantidad, Precio, DescRecGeneral, DescuentoRecargo, ImporteTotal, DescuentoRecargoProducto, DescuentoRecargoPorc, DescRecGeneralProducto, PrecioNeto, ImporteTotalNeto, PorcentajeIVA, IVA FROM dbo.ComprasProductos WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.ComprasProductos
GO
EXECUTE sp_rename N'dbo.Tmp_ComprasProductos', N'ComprasProductos', 'OBJECT' 
GO
ALTER TABLE dbo.ComprasProductos ADD CONSTRAINT
	PK_ComprasProductos PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	TipoDocProveedor,
	NroDocProveedor,
	Orden
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ComprasProductos ADD CONSTRAINT
	FK_ComprasProductos_Compras FOREIGN KEY
	(
	IdSucursal,
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	TipoDocProveedor,
	NroDocProveedor
	) REFERENCES dbo.Compras
	(
	IdSucursal,
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	TipoDocProveedor,
	NroDocProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ComprasProductos ADD CONSTRAINT
	FK_ComprasProductos_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT


/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.MovimientosComprasProductos
	DROP CONSTRAINT FK_MovimientosComprasProductos_MovimientosCompras
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovimientosComprasProductos
	DROP CONSTRAINT FK_MovimientosComprasProductos_Productos
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_MovimientosComprasProductos
	(
	IdSucursal int NOT NULL,
	IdTipoMovimiento varchar(15) NOT NULL,
	NumeroMovimiento bigint NOT NULL,
	Orden bigint NOT NULL IDENTITY (1, 1),
	IdProducto varchar(15) NOT NULL,
	Cantidad decimal(12, 2) NULL,
	Precio decimal(12, 2) NULL
	)  ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_MovimientosComprasProductos OFF
GO
IF EXISTS(SELECT * FROM dbo.MovimientosComprasProductos)
	 EXEC('INSERT INTO dbo.Tmp_MovimientosComprasProductos (IdSucursal, IdTipoMovimiento, NumeroMovimiento, IdProducto, Cantidad, Precio)
		SELECT IdSucursal, IdTipoMovimiento, NumeroMovimiento, IdProducto, Cantidad, Precio FROM dbo.MovimientosComprasProductos WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.MovimientosComprasProductos
GO
EXECUTE sp_rename N'dbo.Tmp_MovimientosComprasProductos', N'MovimientosComprasProductos', 'OBJECT' 
GO
ALTER TABLE dbo.MovimientosComprasProductos ADD CONSTRAINT
	PK_MovimientosDetalle PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdTipoMovimiento,
	NumeroMovimiento,
	Orden
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.MovimientosComprasProductos ADD CONSTRAINT
	FK_MovimientosComprasProductos_Productos FOREIGN KEY
	(
	IdProducto
	) REFERENCES dbo.Productos
	(
	IdProducto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimientosComprasProductos ADD CONSTRAINT
	FK_MovimientosComprasProductos_MovimientosCompras FOREIGN KEY
	(
	IdSucursal,
	IdTipoMovimiento,
	NumeroMovimiento
	) REFERENCES dbo.MovimientosCompras
	(
	IdSucursal,
	IdTipoMovimiento,
	NumeroMovimiento
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT


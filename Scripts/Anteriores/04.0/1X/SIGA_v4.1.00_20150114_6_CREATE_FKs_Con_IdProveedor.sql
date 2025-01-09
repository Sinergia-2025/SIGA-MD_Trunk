
PRINT '1.1 Creo FK: Cheques'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cheques ADD CONSTRAINT
	FK_Cheques_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '1.2 Borro Campos: Cheques.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.Cheques DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.Cheques DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '2.1 Creo FK: ChequesHistorial'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChequesHistorial ADD CONSTRAINT
	FK_ChequesHistorial_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChequesHistorial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '2.2 Borro Campos: ChequesHistorial.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.ChequesHistorial DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.ChequesHistorial DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '3.1 Creo FK: Compras'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Compras ADD CONSTRAINT
	FK_Compras_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '3.2 Borro Campos: Compras.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.Compras DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.Compras DROP COLUMN NroDocProveedor
GO

PRINT '3.3 Borro Campos: Compras.Tipo y NroDocProveedorFact'
GO
ALTER TABLE dbo.Compras DROP COLUMN TipoDocProveedorFact
GO
ALTER TABLE dbo.Compras DROP COLUMN NroDocProveedorFact
GO

/* ---------------------- */

PRINT '4.1 Borro Campos: ComprasCheques.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.ComprasCheques DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.ComprasCheques DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '5.1 Borro Campos: ComprasObservaciones.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.ComprasObservaciones DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.ComprasObservaciones DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '6.1 Borro Campos: ComprasProductos.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.ComprasProductos DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.ComprasProductos DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '7.1 Creo FK: CuentasCorrientesProv'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesProv ADD CONSTRAINT
	FK_CuentasCorrientesProv_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientesProv SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '7.2 Borro Campos: CuentasCorrientesProv.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.CuentasCorrientesProv DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.CuentasCorrientesProv DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '8.1 Borro Campos: CuentasCorrientesProvCheques.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.CuentasCorrientesProvCheques DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.CuentasCorrientesProvCheques DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '9.1 Borro Campos: CuentasCorrientesProvPagos.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.CuentasCorrientesProvPagos DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.CuentasCorrientesProvPagos DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '10.1 Borro Campos: CuentasCorrientesProvRetenciones.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.CuentasCorrientesProvRetenciones DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.CuentasCorrientesProvRetenciones DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '11.1 Creo FK: FichasProductos'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.FichasProductos ADD CONSTRAINT
	FK_FichasProductos_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FichasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '11.2 Borro Campos: FichasProductos.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.FichasProductos DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.FichasProductos DROP COLUMN NroDocProveedor
GO

/* ---------------------- */


PRINT '12.1 Creo FK: MovimientosCompras'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovimientosCompras ADD CONSTRAINT
	FK_MovimientosCompras_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimientosCompras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '12.2 Borro Campos: MovimientosCompras.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.MovimientosCompras DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.MovimientosCompras DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '13.1 Creo FK: PedidosEstadosProveedores'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosEstadosProveedores ADD CONSTRAINT
	FK_PedidosEstadosProveedores_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosEstadosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '13.2 Borro Campos: PedidosEstadosProveedores.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.PedidosEstadosProveedores DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.PedidosEstadosProveedores DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '14.1 Creo FK: PedidosProveedores'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PedidosProveedores ADD CONSTRAINT
	FK_PedidosProveedores_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PedidosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '14.2 Borro Campos: PedidosProveedores.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.PedidosProveedores DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.PedidosProveedores DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '15.1 Creo FK: ProductosNrosSerie'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProductosNrosSerie ADD CONSTRAINT
	FK_ProductosNrosSerie_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProductosNrosSerie SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '15.2 Borro Campos: ProductosNrosSerie.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.ProductosNrosSerie DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.ProductosNrosSerie DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '16.1 Creo FK: ProductosProveedores'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ProductosProveedores ADD CONSTRAINT
	FK_ProductosProveedores_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProductosProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '16.2 Borro Campos: ProductosProveedores.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.ProductosProveedores DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.ProductosProveedores DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '16.1 Creo FK: RecepcionNotasProveedores'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecepcionNotasProveedores ADD CONSTRAINT
	FK_RecepcionNotasProveedores_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecepcionNotasProveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '16.2 Borro Campos: RecepcionNotasProveedores.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.RecepcionNotasProveedores DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.RecepcionNotasProveedores DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '17.1 Creo FK: RecepcionNotasProveedoresF'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecepcionNotasProveedoresF ADD CONSTRAINT
	FK_RecepcionNotasProveedoresF_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecepcionNotasProveedoresF SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '17.2 Borro Campos: RecepcionNotasProveedoresF.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.RecepcionNotasProveedoresF DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.RecepcionNotasProveedoresF DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '18.1 Creo FK: RetencionesCompras'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RetencionesCompras ADD CONSTRAINT
	FK_RetencionesCompras_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RetencionesCompras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '18.2 Borro Campos: RetencionesCompras.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.RetencionesCompras DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.RetencionesCompras DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

PRINT '19.1 Creo FK: Ventas'
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
ALTER TABLE dbo.Proveedores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT
	FK_Ventas_Proveedores FOREIGN KEY
	(
	IdProveedor
	) REFERENCES dbo.Proveedores
	(
	IdProveedor
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '19.2 Borro Campos: Ventas.Tipo y NroDocProveedor'
GO
ALTER TABLE dbo.Ventas DROP COLUMN TipoDocProveedor
GO
ALTER TABLE dbo.Ventas DROP COLUMN NroDocProveedor
GO

/* ---------------------- */

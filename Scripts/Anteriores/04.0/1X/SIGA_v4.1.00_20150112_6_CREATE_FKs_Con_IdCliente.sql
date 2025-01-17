
PRINT '1.1 Creo FK: Alquileres'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Alquileres ADD CONSTRAINT
	FK_Alquileres_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Alquileres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '1.2 Borro Campos: Alquileres.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.Alquileres DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.Alquileres DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '2.1 Borro Campos: AuditoriaClientes.Tipo y NroDocCliente Garante'
GO

ALTER TABLE dbo.AuditoriaClientes DROP COLUMN TipoDocumentoGarante
GO
ALTER TABLE dbo.AuditoriaClientes DROP COLUMN NroDocumentoGarante
GO

/* ---------------------- */

PRINT '3.1 Creo FK: CartasAClientes'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CartasAClientes ADD CONSTRAINT
	FK_CartasAClientes_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CartasAClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '3.2 Borro Campos: CartasAClientes.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.CartasAClientes DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.CartasAClientes DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '4.1 Creo FK: CartasAClientes Garante'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CartasAClientes ADD CONSTRAINT
	FK_CartasAClientes_Clientes_Garante FOREIGN KEY
	(
	IdClienteGarante
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CartasAClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '4.2 Borro Campos: CartasAClientes.Tipo y NroDocCliente Garante'
GO

ALTER TABLE dbo.CartasAClientes DROP COLUMN TipoDocumentoGarante
GO
ALTER TABLE dbo.CartasAClientes DROP COLUMN NroDocumentoGarante
GO

/* ---------------------- */

PRINT '5.1 Creo FK: Cheques'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cheques ADD CONSTRAINT
	FK_Cheques_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Cheques SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '5.2 Borro Campos: Cheques.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.Cheques DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.Cheques DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '6.1 Creo FK: ChequesHistorial'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ChequesHistorial ADD CONSTRAINT
	FK_ChequesHistorial_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ChequesHistorial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '6.2 Borro Campos: ChequesHistorial.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.ChequesHistorial DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.ChequesHistorial DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '7.1 Borro Campos: Clientes.Tipo y NroDocCliente Garante'
GO

ALTER TABLE dbo.Clientes DROP COLUMN TipoDocumentoGarante
GO
ALTER TABLE dbo.Clientes DROP COLUMN NroDocumentoGarante
GO

/* ---------------------- */

PRINT '8.1 Creo FK: ClientesActividades'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesActividades ADD CONSTRAINT
	FK_ClientesActividades_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClientesActividades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '8.2 Borro Campos: ClientesActividades.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.ClientesActividades DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.ClientesActividades DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '9.1 Creo FK: ClientesDescuentosMarcas'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesDescuentosMarcas ADD CONSTRAINT
	FK_ClientesDescuentosMarcas_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClientesDescuentosMarcas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '9.2 Borro Campos: ClientesDescuentosMarcas.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.ClientesDescuentosMarcas DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.ClientesDescuentosMarcas DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '10.1 Creo FK: ClientesDescuentosSubRubros'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesDescuentosSubRubros ADD CONSTRAINT
	FK_ClientesDescuentosSubRubros_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClientesDescuentosMarcas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '10.2 Borro Campos: ClientesDescuentosSubRubros.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.ClientesDescuentosSubRubros DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.ClientesDescuentosSubRubros DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '11.1 Creo FK: ClientesMarcasListasDePrecios'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesMarcasListasDePrecios ADD CONSTRAINT
	FK_ClientesMarcasListasDePrecios_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClientesMarcasListasDePrecios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '11.2 Borro Campos: ClientesMarcasListasDePrecios.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.ClientesMarcasListasDePrecios DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.ClientesMarcasListasDePrecios DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '12.1 Creo FK: ClientesSucursales'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesSucursales ADD CONSTRAINT
	FK_ClientesSucursales_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ClientesSucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '12.2 Borro Campos: ClientesSucursales.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.ClientesSucursales DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.ClientesSucursales DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '13.1 Creo FK: CuentasCorrientes'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT
	FK_CuentasCorrientes_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '13.2 Borro Campos: CuentasCorrientes.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.CuentasCorrientes DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.CuentasCorrientes DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '14.1 Creo FK: CuentasCorrientesRetenciones'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientesRetenciones ADD CONSTRAINT
	FK_CuentasCorrientesRetenciones_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientesRetenciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '14.2 Borro Campos: CuentasCorrientesRetenciones.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.CuentasCorrientesRetenciones DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.CuentasCorrientesRetenciones DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '14.1 Creo FK: Fichas'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Fichas ADD CONSTRAINT
	FK_Fichas_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Fichas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '14.2 Borro Campos: Fichas.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.Fichas DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.Fichas DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '15.1 Borro Campos: FichasPagos.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.FichasPagos DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.FichasPagos DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '16.1 Borro Campos: FichasPagosAjustes.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.FichasPagosAjustes DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.FichasPagosAjustes DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '17.1 Borro Campos: FichasPagosDetalle.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.FichasPagosDetalle DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.FichasPagosDetalle DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '18.1 Borro Campos: FichasProductos.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.FichasProductos DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.FichasProductos DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '19.1 Creo FK: MovimientosVentas'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovimientosVentas ADD CONSTRAINT
	FK_MovimientosVentas_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.MovimientosVentas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '19.2 Borro Campos: MovimientosVentas.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.MovimientosVentas DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.MovimientosVentas DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '20.1 Creo FK: Pedidos'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Pedidos ADD CONSTRAINT
	FK_Pedidos_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '20.2 Borro Campos: Pedidos.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.Pedidos DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.Pedidos DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '21.1 Creo FK: PercepcionVentas'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.PercepcionVentas ADD CONSTRAINT
	FK_PercepcionVentas_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.PercepcionVentas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '21.2 Borro Campos: PercepcionVentas.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.PercepcionVentas DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.PercepcionVentas DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '22.1 Creo FK: RecepcionNotas'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecepcionNotas ADD CONSTRAINT
	FK_RecepcionNotas_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecepcionNotas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '22.2 Borro Campos: RecepcionNotas.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.RecepcionNotas DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.RecepcionNotas DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '23.1 Creo FK: RecepcionNotasF'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RecepcionNotasF ADD CONSTRAINT
	FK_RecepcionNotasF_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.RecepcionNotasF SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '23.2 Borro Campos: RecepcionNotasF.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.RecepcionNotasF DROP COLUMN TipoDocumento
GO
ALTER TABLE dbo.RecepcionNotasF DROP COLUMN NroDocumento
GO

/* ---------------------- */

PRINT '24.1 Creo FK: Retenciones'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Retenciones ADD CONSTRAINT
	FK_Retenciones_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Retenciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '24.2 Borro Campos: Retenciones.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.Retenciones DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.Retenciones DROP COLUMN NroDocCliente
GO

/* ---------------------- */

PRINT '25.1 Creo FK: Ventas'
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
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT
	FK_Ventas_Clientes FOREIGN KEY
	(
	IdCliente
	) REFERENCES dbo.Clientes
	(
	IdCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '25.2 Borro Campos: Ventas.Tipo y NroDocCliente'
GO

ALTER TABLE dbo.Ventas DROP COLUMN TipoDocCliente
GO
ALTER TABLE dbo.Ventas DROP COLUMN NroDocCliente
GO

/* ---------------------- */

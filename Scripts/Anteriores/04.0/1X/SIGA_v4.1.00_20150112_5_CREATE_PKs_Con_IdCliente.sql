
PRINT '1.1 Creo PK: AuditoriaClientes'
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
ALTER TABLE dbo.AuditoriaClientes ADD CONSTRAINT
	PK_AuditoriaClientes PRIMARY KEY CLUSTERED 
	(
	FechaAuditoria,
	IdCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '1.2 Creo Campos: AuditoriaClientes.Tipo y NroDocCliente'
GO

ALTER TABLE AuditoriaClientes ADD TipoDocCliente varchar(5) NULL
GO
ALTER TABLE AuditoriaClientes ADD NroDocCliente bigint NULL
GO

PRINT '1.3 Actualizo Campos: AuditoriaClientes.Tipo y NroDocCliente'
GO

UPDATE AuditoriaClientes 
   SET TipoDocCliente = TipoDocumento
     , NroDocCliente = CONVERT(bigint ,NroDocumento)
   WHERE TipoDocumento NOT IN ('COD', 'ID', 'CUIT', 'CUIL')
GO

PRINT '1.4 Renombros Campos: AuditoriaClientes.Tipo y NroDocumento'
GO

EXEC sp_rename 'AuditoriaClientes.TipoDocumento', 'TipoDocumentoAnterior', 'COLUMN'
GO
EXEC sp_rename 'AuditoriaClientes.NroDocumento', 'NroDocumentoAnterior', 'COLUMN'
GO

-- Ahora deben permitir null, no se graban mas.
ALTER TABLE AuditoriaClientes ALTER COLUMN TipoDocumentoAnterior varchar(5) NULL
GO
ALTER TABLE AuditoriaClientes ALTER COLUMN NroDocumentoAnterior varchar(12) NULL
GO

/* ------------------------------ */

PRINT '2. Creo PK: CartasAClientes'
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
ALTER TABLE dbo.CartasAClientes ADD CONSTRAINT
	PK_CartasAClientes PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente,
	NroOperacion,
	FechaEnvio
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CartasAClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '3.1 Borro Clientes.FK_Clientes_2 (Indice Unico de IdCliente)'
GO

ALTER TABLE dbo.Clientes DROP CONSTRAINT [FK_Clientes_2]
GO

PRINT '3.2 Creo PK: Clientes'
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
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	PK_Clientes PRIMARY KEY CLUSTERED 
	(
	IdCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '3.3 Creo Campos: Clientes.Tipo y NroDocCliente'
GO

ALTER TABLE Clientes ADD TipoDocCliente varchar(5) NULL
GO
ALTER TABLE Clientes ADD NroDocCliente bigint NULL
GO

PRINT '3.4 Actualizo Campos: Clientes.Tipo y NroDocCliente'
GO

UPDATE Clientes 
   SET TipoDocCliente = TipoDocumento
     , NroDocCliente = CONVERT(bigint, NroDocumento)
   WHERE TipoDocumento NOT IN ('COD', 'ID', 'CUIT', 'CUIL')
GO

PRINT '1.4 Renombros Campos: Clientes.Tipo y NroDocumento'
GO

EXEC sp_rename 'Clientes.TipoDocumento', 'TipoDocumentoAnterior', 'COLUMN'
GO
EXEC sp_rename 'Clientes.NroDocumento', 'NroDocumentoAnterior', 'COLUMN'
GO

-- Ahora deben permitir null, no se graban mas.
ALTER TABLE Clientes ALTER COLUMN TipoDocumentoAnterior varchar(5) NULL
GO
ALTER TABLE Clientes ALTER COLUMN NroDocumentoAnterior varchar(12) NULL
GO


/* ------------------------------ */

PRINT '4. Creo PK: ClientesActividades'
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
ALTER TABLE dbo.ClientesActividades ADD CONSTRAINT
	PK_ClientesActividades PRIMARY KEY CLUSTERED 
	(
	IdCliente,
	IdProvincia,
	IdActividad	
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ClientesActividades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '5. Creo PK: ClientesDescuentosMarcas'
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
ALTER TABLE dbo.ClientesDescuentosMarcas ADD CONSTRAINT
	PK_ClientesDescuentosMarcas PRIMARY KEY CLUSTERED 
	(
	IdCliente,
	IdMarca	
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ClientesDescuentosMarcas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '6. Creo PK: ClientesDescuentosSubRubros'
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
ALTER TABLE dbo.ClientesDescuentosSubRubros ADD CONSTRAINT
	PK_ClientesDescuentosSubRubros PRIMARY KEY CLUSTERED 
	(
	IdCliente,
	IdSubRubro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ClientesDescuentosSubRubros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '7. Creo PK: ClientesMarcasListasDePrecios'
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
ALTER TABLE dbo.ClientesMarcasListasDePrecios ADD CONSTRAINT
	PK_ClientesMarcasListasDePrecios PRIMARY KEY CLUSTERED 
	(
	IdCliente,
	IdMarca
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ClientesMarcasListasDePrecios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '8. Creo PK: ClientesSucursales'
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
ALTER TABLE dbo.ClientesSucursales ADD CONSTRAINT
	PK_ClientesSucursales PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ClientesSucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '9. Creo PK: CuentasCorrientesRetenciones'
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
ALTER TABLE dbo.CuentasCorrientesRetenciones ADD CONSTRAINT
	PK_CuentasCorrientesRetenciones PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdTipoComprobante,
	Letra,
	CentroEmisor,
	NumeroComprobante,
	IdTipoImpuesto,
	EmisorRetencion,
	NumeroRetencion,
	IdCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CuentasCorrientesRetenciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '10. Creo PK: Fichas'
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
ALTER TABLE dbo.Fichas ADD CONSTRAINT
	PK_Fichas PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente,
	NroOperacion
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Fichas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '11. Creo PK: FichasPagos'
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
ALTER TABLE dbo.FichasPagos ADD CONSTRAINT
	PK_FichasPagos PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente,
	NroOperacion,
	NroCuota
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.FichasPagos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '12. Creo PK: FichasPagosAjustes'
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
ALTER TABLE dbo.FichasPagosAjustes ADD CONSTRAINT
	PK_FichasPagosAjustes PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente,
	NroOperacion,
	FechaPago
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.FichasPagosAjustes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '13. Creo PK: FichasPagosDetalle'
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
ALTER TABLE dbo.FichasPagosDetalle ADD CONSTRAINT
	PK_FichasPagosDetalle PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente,
	NroOperacion,
	NroCuota,
	FechaPago
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.FichasPagosDetalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '14. Creo PK: FichasProductos'
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
ALTER TABLE dbo.FichasProductos ADD CONSTRAINT
	PK_FichasProductos PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente,
	NroOperacion,
	IdProducto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.FichasProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ------------------------------ */

PRINT '15. Creo PK: Retenciones'
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
ALTER TABLE dbo.Retenciones ADD CONSTRAINT
	PK_Retenciones PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdTipoImpuesto,
	EmisorRetencion,
	NumeroRetencion,
	IdCliente
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Retenciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

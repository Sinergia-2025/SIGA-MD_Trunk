PRINT ''
PRINT '1. Nueva Tabla EstadosPedidosProveedoresRoles'
IF dbo.ExisteTabla('EstadosPedidosProveedoresRoles') = 0
BEGIN
    CREATE TABLE EstadosPedidosProveedoresRoles(
	    TipoEstadoPedido varchar(15) NOT NULL,
	    IdEstado varchar(10) NOT NULL,
	    IdRol varchar(12) NOT NULL,
	    PermitirEscritura bit NOT NULL,
     CONSTRAINT PK_EstadosPedidosProveedoresRoles PRIMARY KEY CLUSTERED 
    (TipoEstadoPedido ASC, IdEstado ASC, IdRol ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

PRINT ''
PRINT '1.1. Tabla EstadosPedidosProveedoresRoles: FK_EstadosPedidosProveedoresRoles_EstadosPedidosProveedores'
IF dbo.ExisteFK('FK_EstadosPedidosProveedoresRoles_EstadosPedidosProveedores') = 0
BEGIN
    ALTER TABLE dbo.EstadosPedidosProveedoresRoles  WITH CHECK ADD  CONSTRAINT FK_EstadosPedidosProveedoresRoles_EstadosPedidosProveedores FOREIGN KEY(IdEstado, TipoEstadoPedido)
    REFERENCES dbo.EstadosPedidosProveedores (IdEstado, TipoEstadoPedido)
    ALTER TABLE dbo.EstadosPedidosProveedoresRoles CHECK CONSTRAINT FK_EstadosPedidosProveedoresRoles_EstadosPedidosProveedores
END
GO

PRINT ''
PRINT '1.2. Tabla EstadosPedidosProveedoresRoles: FK_EstadosPedidosProveedoresRoles_Roles'
IF dbo.ExisteFK('FK_EstadosPedidosProveedoresRoles_Roles') = 0
BEGIN
    ALTER TABLE dbo.EstadosPedidosProveedoresRoles  WITH CHECK ADD  CONSTRAINT FK_EstadosPedidosProveedoresRoles_Roles FOREIGN KEY(IdRol)
    REFERENCES dbo.Roles (Id)
    ALTER TABLE dbo.EstadosPedidosProveedoresRoles CHECK CONSTRAINT FK_EstadosPedidosProveedoresRoles_Roles
END
GO

PRINT ''
PRINT '1.3. Tabla EstadosPedidosProveedoresRoles: Roles iniciales para todos los estados'
IF NOT EXISTS(SELECT * FROM EstadosPedidosProveedoresRoles)
BEGIN
    INSERT INTO EstadosPedidosProveedoresRoles
           (TipoEstadoPedido, IdEstado, IdRol, PermitirEscritura)
    SELECT TipoEstadoPedido, IdEstado, Id, 'True'
      FROM EstadosPedidosProveedores
     CROSS JOIN Roles
END


PRINT ''
PRINT '2. Nueva Tabla MRPConceptosNoProductivos'
IF dbo.ExisteTabla('MRPConceptosNoProductivos') = 0
BEGIN
    CREATE TABLE [dbo].[MRPConceptosNoProductivos](
	    [IdConceptoNoProductivo] [int] NOT NULL,
	    [CodigoConceptoNoProductivo] [varchar](30) NOT NULL,
	    [NombreConceptoNoProductivo] [varchar](50) NOT NULL,
	    [Activo] [bit] NOT NULL,
     CONSTRAINT [PK_MRPConceptosNoProductivos] PRIMARY KEY CLUSTERED 
    (
	    [IdConceptoNoProductivo] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO

PRINT ''
PRINT '2.1. Tabla MRPConceptosNoProductivos: AK_MRPConceptosNoProductivos'
IF dbo.ExisteIX('AK_MRPConceptosNoProductivos') = 0
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX [AK_MRPConceptosNoProductivos] ON [dbo].[MRPConceptosNoProductivos]
    (
	    [CodigoConceptoNoProductivo] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO

PRINT ''
PRINT '3. Nueva Tabla EstadosPedidosRoles'
IF dbo.ExisteTabla('EstadosPedidosRoles') = 0
BEGIN
    CREATE TABLE EstadosPedidosRoles(
	    TipoEstadoPedido varchar(15) NOT NULL,
	    IdEstado varchar(10) NOT NULL,
	    IdRol varchar(12) NOT NULL,
	    PermitirEscritura bit NOT NULL,
     CONSTRAINT PK_EstadosPedidosRoles PRIMARY KEY CLUSTERED 
    (TipoEstadoPedido ASC, IdEstado ASC, IdRol ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

PRINT ''
PRINT '3.1. Tabla EstadosPedidosRoles: FK_EstadosPedidosRoles_EstadosPedidos'
IF dbo.ExisteFK('FK_EstadosPedidosRoles_EstadosPedidos') = 0
BEGIN
    ALTER TABLE dbo.EstadosPedidosRoles  WITH CHECK ADD  CONSTRAINT FK_EstadosPedidosRoles_EstadosPedidos FOREIGN KEY(IdEstado, TipoEstadoPedido)
    REFERENCES dbo.EstadosPedidos (IdEstado, TipoEstadoPedido)
    ALTER TABLE dbo.EstadosPedidosRoles CHECK CONSTRAINT FK_EstadosPedidosRoles_EstadosPedidos
END
GO

PRINT ''
PRINT '3.2. Tabla EstadosPedidosRoles: FK_EstadosPedidosRoles_Roles'
IF dbo.ExisteFK('FK_EstadosPedidosRoles_Roles') = 0
BEGIN
    ALTER TABLE dbo.EstadosPedidosRoles  WITH CHECK ADD  CONSTRAINT FK_EstadosPedidosRoles_Roles FOREIGN KEY(IdRol)
    REFERENCES dbo.Roles (Id)
    ALTER TABLE dbo.EstadosPedidosRoles CHECK CONSTRAINT FK_EstadosPedidosRoles_Roles
END
GO

PRINT ''
PRINT '3.3. Tabla EstadosPedidosRoles: Roles iniciales para todos los estados'
IF NOT EXISTS(SELECT * FROM EstadosPedidosRoles)
BEGIN
    INSERT INTO EstadosPedidosRoles
           (TipoEstadoPedido, IdEstado, IdRol, PermitirEscritura)
    SELECT TipoEstadoPedido, IdEstado, Id, 'True'
      FROM EstadosPedidos
     CROSS JOIN Roles
END

PRINT ''
PRINT '4. Tabla OrdenesProduccionMRPProductos: Nuevos campos Vinculacion'
IF dbo.ExisteCampo('OrdenesProduccionMRPProductos', 'IdSucursalOp') = 0
BEGIN
    ALTER TABLE OrdenesProduccionMRPProductos ADD IdSucursalOp int NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD IdTipocomprobanteOP Varchar(15) NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD LetraComprobanteOP Varchar(1) NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD CentroEmisorOP int NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD NumeroOrdenProduccionOP int NULL
    ALTER TABLE OrdenesProduccionMRPProductos ADD OrdenOP int NULL
END
GO

PRINT ''
PRINT '5. Tabla OrdenesProduccionEstados: Nuevos campos Vinculacion'
IF dbo.ExisteCampo('OrdenesProduccionEstados', 'PlanMaestroNumero') = 0
BEGIN
    ALTER TABLE OrdenesProduccionEstados ADD PlanMaestroNumero int NULL
    ALTER TABLE OrdenesProduccionEstados ADD PlanMaestroFecha Datetime NULL
END
GO

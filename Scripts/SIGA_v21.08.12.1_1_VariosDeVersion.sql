
PRINT ''
PRINT '1. Tabla CRMNovedades: Campos nuevos en CRMNovedades.-'
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD
	    FechaHoraRetiro datetime NULL,
	    IdDomicilioRetiro int NULL,
	    FechaHoraEntrega datetime NULL,
	    IdDomicilioEntrega int NULL,
	    IdProveedorGarantia bigint NULL,
	    FechaHoraRetiroGarantia datetime NULL,
	    FechaHoraEnvioGarantia datetime NULL,
        AnticipoNovedad Decimal(12,2) NULL,
        IdMarcaProducto Int NULL,
        IdModeloProducto Int NULL

PRINT ''
PRINT '2. Tabla CRMNovedades: Campos nuevos en AuditoriaCRMNovedades.-'
    ALTER TABLE dbo.AuditoriaCRMNovedades ADD
	    FechaHoraRetiro datetime NULL,
	    IdDomicilioRetiro int NULL,
	    FechaHoraEntrega datetime NULL,
	    IdDomicilioEntrega int NULL,
	    IdProveedorGarantia bigint NULL,
	    FechaHoraRetiroGarantia datetime NULL,
	    FechaHoraEnvioGarantia datetime NULL,
        AnticipoNovedad Decimal(12,2) NULL,
        IdMarcaProducto Int NULL,
        IdModeloProducto Int NULL

END

PRINT ''
PRINT '3. Tabla CRMNovedades: Genera Clave Foranea de Domicilio de Retiro.-'
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	    FK_CRMNovedades_DomicilioRetiro FOREIGN KEY
	    (
	    IdCliente,
	    IdDomicilioRetiro
	    ) REFERENCES dbo.ClientesDirecciones
	    (
	    IdCliente,
	    IdDireccion
	    ) ON UPDATE  NO ACTION 
	     ON DELETE  NO ACTION 
END

PRINT ''
PRINT '4. Tabla CRMNovedades: Genera Clave Foranea de Domicilio de Entrega.-'
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	    FK_CRMNovedades_DomicilioEntrega FOREIGN KEY
	    (
	    IdCliente,
	    IdDomicilioEntrega
	    ) REFERENCES dbo.ClientesDirecciones
	    (
	    IdCliente,
	    IdDireccion
	    ) ON UPDATE  NO ACTION 
	     ON DELETE  NO ACTION 
END

PRINT ''
PRINT '5. Tabla CRMNovedades: Genera Clave Foranea de Proveedor de Garantia.-'
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	    FK_CRMNovedades_ProveedorGarantia FOREIGN KEY
	    (
	    IdProveedorGarantia
	    ) REFERENCES dbo.Proveedores
	    (
	    IdProveedor
	    ) ON UPDATE  NO ACTION 
	     ON DELETE  NO ACTION 
END

PRINT ''
PRINT '6. Tabla CRMNovedades: Genera Clave Foranea de Marcas.-'
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	    FK_CRMNovedades_MarcasProductos FOREIGN KEY
	    (
	    IdMarcaProducto
	    ) REFERENCES dbo.Marcas
	    (
	    IdMarca
	    ) ON UPDATE  NO ACTION 
	     ON DELETE  NO ACTION 
END

PRINT ''
PRINT '7. Tabla CRMNovedades: Genera Clave Foranea de Modelos.-'
BEGIN
    ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	    FK_CRMNovedades_ModelosProductos FOREIGN KEY
	    (
        IdModeloProducto
	    ) REFERENCES dbo.Modelos
	    (
        IdModelo
	    ) ON UPDATE  NO ACTION 
	     ON DELETE  NO ACTION 
END

PRINT ''
PRINT '8. Tabla CuentasCorrientes: Genera Campos Novedad en CuentasCorrientes.-'
BEGIN
    ALTER TABLE dbo.CuentasCorrientes ADD
	    IdTipoNovedad varchar(10) NULL,
	    LetraNovedad varchar(1) NULL,
	    CentroEmisorNovedad smallint NULL,
	    NumeroNovedad bigint NULL
END

PRINT ''
PRINT '9. Tabla CuentasCorrientes: Genera Clave Foranea de CRMNovedades.-'
BEGIN
    ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT
	    FK_CuentasCorrientes_CtasCtesNovedades FOREIGN KEY
	    (
	    IdTipoNovedad,
	    LetraNovedad,
	    CentroEmisorNovedad,
	    NumeroNovedad
	    ) REFERENCES dbo.CRMNovedades
	    (
	    IdTipoNovedad,
	    Letra,
	    CentroEmisor,
	    IdNovedad
	    ) ON UPDATE  NO ACTION 
	     ON DELETE  NO ACTION 
END

PRINT ''
PRINT '10. Tabla CuentasCorrientesPagos: Nuevo campo ReferenciaCuota'
ALTER TABLE dbo.CuentasCorrientesPagos ADD ReferenciaCuota bigint NULL
GO

PRINT ''
PRINT '10.1. Tabla CuentasCorrientesPagos: Ajustar registros pre-existentes para campo ReferenciaCuota'
UPDATE CuentasCorrientesPagos SET ReferenciaCuota = 0;
PRINT ''
PRINT '10.2. Tabla CuentasCorrientesPagos: NOT NULL para campo ReferenciaCuota'
ALTER TABLE dbo.CuentasCorrientesPagos ALTER COLUMN ReferenciaCuota bigint NOT NULL
GO


PRINT ''
PRINT '1. Nueva Tabla: PedidosTiendasWeb'
CREATE TABLE PedidosTiendasWeb(
	Id VARCHAR(30) NOT NULL,
	SistemaDestino VARCHAR(200) NOT NULL,
	Numero BIGINT NOT NULL,
	IdClienteTiendaWeb VARCHAR(30) NOT NULL,
	NombreClienteTiendaWeb VARCHAR(100) NOT NULL,
	ObservacionesTiendaWeb VARCHAR(200) NULL,
	IdMoneda VARCHAR(3) NULL,
	TipoEnvio VARCHAR(10) NULL,
	DireccionEnvio VARCHAR(200) NULL,
	FechaPedido DATETIME NOT NULL,
	CostoEnvio DECIMAL(14,2) NULL,
	ImporteTotal DECIMAL(14,2) NOT NULL,
	SubTotal DECIMAL(14,2) NOT NULL,
	IdUsuarioEstado VARCHAR(10) NOT NULL,
	FechaEstado DATETIME NOT NULL,
	IdUsuarioDescarga VARCHAR(10) NOT NULL,
	FechaDescarga DATETIME NOT NULL,
	IdEstadoPedidoTiendaWeb VARCHAR(15) NOT NULL,
	MensajeError VARCHAR(200) NULL,
	JSON VARCHAR(MAX) NULL,

	PRIMARY KEY (Id,SistemaDestino)
)
GO

PRINT ''
PRINT '1.1. FK_PedidosTiendasWeb_Usuarios_Descarga'
ALTER TABLE PedidosTiendasWeb
	ADD CONSTRAINT FK_PedidosTiendasWeb_Usuarios_Descarga
	FOREIGN KEY (IdUsuarioDescarga) REFERENCES Usuarios (Id)
GO

PRINT ''
PRINT '1.2. FK_PedidosTiendasWeb_Usuarios_Estado'
ALTER TABLE PedidosTiendasWeb
	ADD CONSTRAINT FK_PedidosTiendasWeb_Usuarios_Estado
	FOREIGN KEY (IdUsuarioEstado) REFERENCES Usuarios (Id)
GO

PRINT ''
PRINT '2. Nueva Tabla: PedidosProductosTiendasWeb'
CREATE TABLE PedidosProductosTiendasWeb(
	Id VARCHAR(30) NOT NULL,
	SistemaDestino VARCHAR(200) NOT NULL,
	Numero BIGINT NOT NULL,
	IdProductoTiendaWeb VARCHAR(30) NOT NULL,
	NombreProductoTiendaWeb VARCHAR(100) NOT NULL,
	Precio DECIMAL(14,2) NOT NULL,
	Cantidad DECIMAL(12,4) NOT NULL

	PRIMARY KEY (Id,SistemaDestino, IdProductoTiendaWeb)
)
GO

PRINT ''
PRINT '2.1. FK_PedidosProductosTiendasWeb_PedidosTiendasWeb'
ALTER TABLE PedidosProductosTiendasWeb
	ADD CONSTRAINT FK_PedidosProductosTiendasWeb_PedidosTiendasWeb
	FOREIGN KEY (Id,SistemaDestino) REFERENCES PedidosTiendasWeb (Id,SistemaDestino)
GO


PRINT ''
PRINT '3. Tabla PedidosTiendasWeb: Nuevos Campos'
ALTER TABLE PedidosTiendasWeb ADD NroDocCliente BIGINT NULL
ALTER TABLE PedidosTiendasWeb ADD Email VARCHAR(500) NULL
ALTER TABLE PedidosTiendasWeb ADD Telefono VARCHAR(100) NULL
ALTER TABLE PedidosTiendasWeb ADD DireccionCalle VARCHAR(100) NULL
ALTER TABLE PedidosTiendasWeb ADD DireccionNumero VARCHAR(100) NULL
ALTER TABLE PedidosTiendasWeb ADD Adicional VARCHAR(100) NULL
ALTER TABLE PedidosTiendasWeb ADD CodigoPostal INT NULL
ALTER TABLE PedidosTiendasWeb ADD Localidad VARCHAR(200) NULL
ALTER TABLE PedidosTiendasWeb ADD Provincia VARCHAR(100) NULL
ALTER TABLE PedidosTiendasWeb ADD Observacion VARCHAR(200) NULL


PRINT ''
PRINT '4. Tabla CalidadListasControl: Agrega Bloquea Fecha Ingreso'
ALTER TABLE CalidadListasControl ADD BloqueaFechaIngreso bit null
GO

PRINT ''
PRINT '4.1. Tabla CalidadListasControl: Datos históricos de Bloquea Fecha Ingreso'
UPDATE CalidadListasControl SET BloqueaFechaIngreso = 'False'
GO

PRINT ''
PRINT '4.2. Tabla CalidadListasControl: NOT NULL para Bloquea Fecha Ingreso'
ALTER TABLE CalidadListasControl ALTER COLUMN BloqueaFechaIngreso bit not null
GO

PRINT ''
PRINT '4.3. Marca en True las listas con Orden mayor que Mecanica'
IF dbo.BaseConCUIT('33631312379') = 1
BEGIN
	UPDATE CalidadListasControl SET BloqueaFechaIngreso = 'True' 
	 WHERE Orden > 999
END


PRINT ''
PRINT '5. Tabla CRMNovedades: Nuevo Campo NombreProducto'
ALTER TABLE CRMNovedades
	ADD NombreProducto VARCHAR(60) NULL
GO

PRINT ''
PRINT '5.1. Tabla CRMNovedades: Actualización de registros pre-existentes para NombreProducto'
UPDATE N SET N.NombreProducto = P.NombreProducto FROM CRMNovedades N
INNER JOIN Productos P ON N.IdProducto = P.IdProducto
GO

PRINT ''
PRINT '5.2. Tabla AuditoriaCRMNovedades: Nuevo campo NombreProducto'
ALTER TABLE AuditoriaCRMNovedades
	ADD NombreProducto VARCHAR(60) NULL
GO


PRINT ''
PRINT '6. Tabla CRMEstadosNovedades: Nuevo Campo IdEstadoFacturado y AvanceEstadoFacturado'
ALTER TABLE CRMEstadosNovedades ADD IdEstadoFacturado INT NULL
ALTER TABLE CRMEstadosNovedades ADD AvanceEstadoFacturado DECIMAL(5,2) NULL
GO

PRINT ''
PRINT '6.1. Tabla CRMEstadosNovedades: Actualización de registros pre-existentes para IdEstadoFacturado y AvanceEstadoFacturado'
UPDATE N SET N.IdEstadoFacturado = N.IdEstadoNovedad FROM CRMEstadosNovedades N
	WHERE N.AvanceEstadoFacturado IS NULL AND N.EsFacturable = 'True'
GO

PRINT ''
PRINT '6.2. Tabla CRMEstadosNovedades: Actualización de registros pre-existentes para IdEstadoFacturado y AvanceEstadoFacturado'
UPDATE N SET N.AvanceEstadoFacturado = CASE WHEN N.Finalizado = 'True' THEN 100 ELSE 1 END FROM CRMEstadosNovedades N
	WHERE N.AvanceEstadoFacturado IS NULL AND N.EsFacturable = 'True'
GO


PRINT ''
PRINT '7. Tabla CRMNovedades: Nuevo Campo IdEstadoNovedadAnterior y AvanceAnterior'
ALTER TABLE CRMNovedades ADD IdEstadoNovedadAnterior INT NULL
ALTER TABLE CRMNovedades ADD AvanceAnterior DECIMAL(5,2) NULL
GO

PRINT ''
PRINT '7. Tabla AuditoriaCRMNovedades: Nuevo Campo IdEstadoNovedadAnterior y AvanceAnterior'
ALTER TABLE AuditoriaCRMNovedades ADD IdEstadoNovedadAnterior INT NULL
ALTER TABLE AuditoriaCRMNovedades ADD AvanceAnterior DECIMAL(5,2) NULL
GO

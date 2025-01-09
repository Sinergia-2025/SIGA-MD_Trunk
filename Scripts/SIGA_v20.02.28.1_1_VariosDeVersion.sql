
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '1. Tabla Ventas: Nuevo Campo EsCtaOrden'
ALTER TABLE Ventas ADD EsCtaOrden BIT NULL
GO

PRINT ''
PRINT '1.2. Tabla Ventas: Valores por defecto para EsCtaOrden'
UPDATE Ventas SET EsCtaOrden = CASE WHEN IdProveedor IS NULL THEN 0 ELSE 1 END 
GO

PRINT ''
PRINT '1.3. Tabla Ventas: NOT NULL para EsCtaOrden'
ALTER TABLE Ventas ALTER COLUMN EsCtaOrden BIT NOT NULL

PRINT ''
PRINT '2. Nuevo Campo: CapacidadMaxima en TiposVehiculos'
ALTER TABLE TiposVehiculos 
	ADD CapacidadMaxima INT NULL
GO

PRINT ''
PRINT '2.1 Correción de datos'
UPDATE TiposVehiculos SET CapacidadMaxima = 0
	WHERE CapacidadMaxima IS NULL
GO

PRINT ''
PRINT '2.2 Convertir el campo CapacidadMaxima a NOT NULL'
ALTER TABLE TiposVehiculos 
	ALTER COLUMN CapacidadMaxima INT NOT NULL


PRINT ''
PRINT '3. Tabla ReservasProductos: Re-Create'
PRINT '3.1. Tabla ReservasProductos: DROP'
DROP TABLE  ReservasProductos
GO
PRINT '3.2. Tabla ReservasProductos: CREATE'
CREATE TABLE [dbo].[ReservasProductos](
	[IdSucursal] [int] NOT NULL,
	[IdTipoReserva] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[NumeroReserva] [bigint] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[IdProductoComponente] [varchar](15) NULL,
	[IdFormula] [int] NOT NULL,
 CONSTRAINT [PK_ReservasProductos1] PRIMARY KEY CLUSTERED 
([IdSucursal] ASC,[IdTipoReserva] ASC,[Letra] ASC,[CentroEmisor] ASC,[NumeroReserva] ASC,[Orden] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReservasProductos]  WITH CHECK ADD  CONSTRAINT [FK_ReservasProductos_Reservas] FOREIGN KEY([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
REFERENCES [dbo].[Reservas] ([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
GO
ALTER TABLE [dbo].[ReservasProductos] CHECK CONSTRAINT [FK_ReservasProductos_Reservas]
GO


PRINT ''
PRINT '4. Tabla ReservasPasajeros: Nueva Tabla'
CREATE TABLE [dbo].[ReservasPasajeros](
	[IdSucursal] [int] NOT NULL,
	[IdTipoReserva] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [smallint] NOT NULL,
	[NumeroReserva] [bigint] NOT NULL,
	[IdPasajero] [bigint] NOT NULL,
	[IdResponsablePasajero] [bigint] NULL,
	[IdSucursalComprobante] [int] NULL,
	[IdTipoComprobante] [varchar](15) NULL,
	[LetraComprobante] [varchar](1) NULL,
	[CentroEmisorComprobante] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
	[PorcentajeLiberado] [decimal](5, 2) NULL,
	[Costo] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_ReservasPasajeros1] PRIMARY KEY CLUSTERED 
([IdSucursal] ASC,[IdTipoReserva] ASC,[Letra] ASC,[CentroEmisor] ASC,[NumeroReserva] ASC,[IdPasajero] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReservasPasajeros]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPasajeros_Clientes] FOREIGN KEY([IdPasajero])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ReservasPasajeros] CHECK CONSTRAINT [FK_ReservasPasajeros_Clientes]
GO
ALTER TABLE [dbo].[ReservasPasajeros]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPasajeros_Reservas] FOREIGN KEY([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
REFERENCES [dbo].[Reservas] ([IdSucursal], [IdTipoReserva], [Letra], [CentroEmisor], [NumeroReserva])
GO
ALTER TABLE [dbo].[ReservasPasajeros] CHECK CONSTRAINT [FK_ReservasPasajeros_Reservas]
GO

PRINT ''
PRINT '5. Tabla Reservas: Dia cambiar a Varchar'
ALTER TABLE Reservas ALTER COLUMN Dia varchar(30) null
GO

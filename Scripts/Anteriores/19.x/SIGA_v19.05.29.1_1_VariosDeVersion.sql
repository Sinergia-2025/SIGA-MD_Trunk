SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
GO

PRINT ''
PRINT '1. Tabla OrdenesProduccionObservaciones - Creación'
CREATE TABLE [dbo].[OrdenesProduccionObservaciones](
	[IdSucursal] [int] NOT NULL,
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[CentroEmisor] [int] NOT NULL,
	[NumeroOrdenProduccion] [int] NOT NULL,
	[Linea] [int] NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_OrdenesProduccionObservaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoComprobante] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroOrdenProduccion] ASC,
	[Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrdenesProduccionObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesProduccionObservaciones_OrdenesProduccion] FOREIGN KEY([IdSucursal], [NumeroOrdenProduccion], [IdTipoComprobante], [Letra], [CentroEmisor])
REFERENCES [dbo].[OrdenesProduccion] ([IdSucursal], [NumeroOrdenProduccion], [IdTipoComprobante], [Letra], [CentroEmisor])
GO
ALTER TABLE [dbo].[OrdenesProduccionObservaciones] CHECK CONSTRAINT [FK_OrdenesProduccionObservaciones_OrdenesProduccion]
GO

PRINT ''
PRINT '2. Tabla ProductosClientes - Creación'
CREATE TABLE [dbo].[ProductosClientes](
	[IdProducto] [varchar](15) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductosClientes] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProductosClientes]  WITH CHECK ADD  CONSTRAINT [FK_ProductosClientes_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ProductosClientes] CHECK CONSTRAINT [FK_ProductosClientes_Clientes]
GO
ALTER TABLE [dbo].[ProductosClientes]  WITH CHECK ADD  CONSTRAINT [FK_ProductosClientes_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ProductosClientes] CHECK CONSTRAINT [FK_ProductosClientes_Productos]
GO

PRINT ''
PRINT '3. Nueva Función ProductosPorCliente'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('ProductosPorCliente', 'Productos de Cliente', 'Productos de Cliente', 'True', 'False', 'True', 'True'
    ,'Archivos', 105, 'Eniac.Win', 'ProductosPorCliente', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')

PRINT ''
PRINT '3.1. Asignar Roles a la Función ProductosPorCliente'
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosPorCliente' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

PRINT ''
PRINT '4. Tabla MovilRutas: Campos Nuevos EsDeCobranza, EsDePedidos y EsDeGestion'
ALTER TABLE dbo.MovilRutas ADD EsDeCobranza bit NULL
ALTER TABLE dbo.MovilRutas ADD EsDePedidos  bit NULL
ALTER TABLE dbo.MovilRutas ADD EsDeGestion  bit NULL
GO

DECLARE @EsDeCobranza bit
DECLARE @EsDePedidos  bit

IF dbo.GetValorParametro('SIMOVILSUBIDAINCLUIRPRODUCTOS') = 'True'
BEGIN
    SET @EsDeCobranza = 0
    SET @EsDePedidos  = 1
END
ELSE
BEGIN
    SET @EsDeCobranza = 1
    SET @EsDePedidos  = 0
END

PRINT '@EsDeCobranza = ' + CONVERT(VARCHAR(MAX), @EsDeCobranza)
PRINT '@EsDePedidos  = ' + CONVERT(VARCHAR(MAX), @EsDePedidos)

PRINT ''
PRINT '4.1. Tabla MovilRutas: Valores por defecto para campos EsDeCobranza, EsDePedidos y EsDeGestion'
UPDATE MovilRutas
   SET EsDeCobranza = @EsDeCobranza
     , EsDePedidos  = @EsDePedidos
     , EsDeGestion  = 0;

PRINT ''
PRINT '4.1. Tabla MovilRutas: NOT NULL Campos EsDeCobranza, EsDePedidos y EsDeGestion'
ALTER TABLE dbo.MovilRutas ALTER COLUMN EsDeCobranza bit NOT NULL
ALTER TABLE dbo.MovilRutas ALTER COLUMN EsDePedidos  bit NOT NULL
ALTER TABLE dbo.MovilRutas ALTER COLUMN EsDeGestion  bit NOT NULL
GO
ALTER TABLE dbo.MovilRutas SET (LOCK_ESCALATION = TABLE)
GO

SET ANSI_PADDING OFF
GO

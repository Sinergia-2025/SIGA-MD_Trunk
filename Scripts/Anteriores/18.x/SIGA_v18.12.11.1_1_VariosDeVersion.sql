PRINT '1. Crear Modelos para Real Gas'
SET XACT_ABORT ON
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30715973037'))
BEGIN
BEGIN TRANSACTION
    INSERT INTO Modelos (IdModelo,NombreModelo,IdMarca)
                 VALUES (1, 'x 10 KG', 2),
                        (2, 'x 15 KG', 2),
                        (3, 'x 15 KG ESP', 2),
                        (4, 'x 30 KG', 2),
                        (5, 'x 45 KG', 2),
                        (6, 'Otros', 2)

    UPDATE Productos
       SET IdModelo = P.IdModelo
      FROM (SELECT P.IdProducto, P.NombreProducto, P.AfectaStock, P.IdRubro
                 , P.IdMarca
                 , CASE WHEN P.NombreProducto LIKE '%X 10 KG%' THEN 1 ELSE
                   CASE WHEN P.NombreProducto LIKE '%X 15 KG ESP%' THEN 3 ELSE
                   CASE WHEN P.NombreProducto LIKE '%X 15KG ESP%' THEN 3 ELSE
                   CASE WHEN P.NombreProducto LIKE '%X 15 KG%' THEN 2 ELSE
                   CASE WHEN P.NombreProducto LIKE '%X 30 KG%' THEN 4 ELSE
                   CASE WHEN P.NombreProducto LIKE '%X 30KG%' THEN 4 ELSE
                   CASE WHEN P.NombreProducto LIKE '%X 45 KG%' THEN 5 ELSE 6
                   END END END END END END END IdModelo
              FROM Productos P) P
     INNER JOIN Rubros R ON R.IdRubro = P.IdRubro
      LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca
     INNER JOIN Productos P2 ON P.IdProducto = P2.IdProducto
     WHERE P.AfectaStock = 1
COMMIT
END

PRINT '2. Agregar columna Orden en Modelos'
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
ALTER TABLE dbo.Modelos ADD Orden int NULL
GO
UPDATE Modelos SET Orden = IdModelo;
ALTER TABLE dbo.Modelos ALTER COLUMN Orden int NOT NULL
ALTER TABLE dbo.Modelos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT '3. Agregar columna Orden en Rubros'
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
ALTER TABLE dbo.Rubros ADD Orden int NULL
GO
UPDATE Rubros SET Orden = IdRubro;
ALTER TABLE dbo.Rubros ALTER COLUMN Orden int NOT NULL
GO
ALTER TABLE dbo.Rubros SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '4. Opción de Menú Inf. Stock por Modelo'
IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'Stock')
BEGIN
	INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
			 IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
			 PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
			('InfStockPorModelo', 'Inf. Stock por Modelo', 'Inf. Stock por Modelo', 'True', 'False', 'True', 'True', 
			 'Stock', 42, 'Eniac.Win', 'InfStockPorModelo', NULL, NULL,
			 'True', 'S', 'N', 'N', 'N');


	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT IdRol, 'InfStockPorModelo' FROM RolesFunciones WHERE IdFuncion = 'RegistrarReparto'
END


PRINT '5. Habilita opción de Menú Modelo y Habilita el uso de Modelo en Real Gas'
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30715973037'))
BEGIN
    UPDATE Funciones
       SET EsMenu = 1
          ,Enabled = 1
          ,Visible = 1
     WHERE Id = 'Modelos'
    ;
    MERGE INTO RolesFunciones AS P
            USING (SELECT IdRol, 'Modelos' IdFuncion FROM RolesFunciones WHERE IdFuncion = 'Marcas') AS PT ON P.IdRol = PT.IdRol AND P.IdFuncion = PT.IdFuncion
        WHEN NOT MATCHED THEN 
            INSERT (IdRol, IdFuncion) VALUES (PT.IdRol, PT.IdFuncion)
    ;
    MERGE INTO RolesFunciones AS P
            USING (SELECT IdRol, 'Modelos' IdFuncion FROM RolesFunciones WHERE IdFuncion = 'Marcas') AS PT ON P.IdRol = PT.IdRol AND P.IdFuncion = PT.IdFuncion
        WHEN NOT MATCHED THEN 
            INSERT (IdRol, IdFuncion) VALUES (PT.IdRol, PT.IdFuncion)
    ;

    MERGE INTO Parametros AS P
            USING (SELECT 'PRODUCTOTIENEMODELO' AS IdParametro, 'True' ValorParametro, 'El Producto tiene Modelo'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
        WHEN MATCHED THEN
            UPDATE SET P.ValorParametro = PT.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
    ;
END


PRINT '6. Crea tabla Repartos (igual a SILIVE)'
/****** Object:  Table [dbo].[Repartos]    Script Date: 11/12/2018 08:24:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Repartos](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[FechaReparto] [datetime] NULL,
	[IdTransportista] [int] NULL,
	[IdEstado] [varchar](10) NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Repartos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Repartos]  WITH CHECK ADD  CONSTRAINT [FK_Repartos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[Repartos] CHECK CONSTRAINT [FK_Repartos_Sucursales]
GO

ALTER TABLE [dbo].[Repartos]  WITH CHECK ADD  CONSTRAINT [FK_Repartos_Transportistas] FOREIGN KEY([IdTransportista])
REFERENCES [dbo].[Transportistas] ([IdTransportista])
GO

ALTER TABLE [dbo].[Repartos] CHECK CONSTRAINT [FK_Repartos_Transportistas]
GO

ALTER TABLE [dbo].[Repartos]  WITH CHECK ADD  CONSTRAINT [FK_Repartos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Repartos] CHECK CONSTRAINT [FK_Repartos_Usuarios]
GO


PRINT '7. Crea tabla RepartosComprobantes (igual a SILIVE)'
/****** Object:  Table [dbo].[RepartosComprobantes]    Script Date: 11/12/2018 08:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RepartosComprobantes](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdTipoComprobantePedido] [varchar](15) NULL,
	[LetraPedido] [varchar](1) NULL,
	[CentroEmisorPedido] [int] NULL,
	[NumeroPedido] [int] NULL,
	[IdTipoComprobanteFact] [varchar](15) NULL,
	[LetraFact] [varchar](1) NULL,
	[CentroEmisorFact] [int] NULL,
	[NumeroComprobante] [bigint] NULL,
 CONSTRAINT [PK_RepartosComprobantes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[RepartosComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_RepartosComprobantes_Pedidos] FOREIGN KEY([IdSucursal], [NumeroPedido], [IdTipoComprobantePedido], [LetraPedido], [CentroEmisorPedido])
REFERENCES [dbo].[Pedidos] ([IdSucursal], [NumeroPedido], [IdTipoComprobante], [Letra], [CentroEmisor])
GO

ALTER TABLE [dbo].[RepartosComprobantes] CHECK CONSTRAINT [FK_RepartosComprobantes_Pedidos]
GO

ALTER TABLE [dbo].[RepartosComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_RepartosComprobantes_Repartos] FOREIGN KEY([IdSucursal], [IdReparto])
REFERENCES [dbo].[Repartos] ([IdSucursal], [IdReparto])
GO

ALTER TABLE [dbo].[RepartosComprobantes] CHECK CONSTRAINT [FK_RepartosComprobantes_Repartos]
GO

ALTER TABLE [dbo].[RepartosComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_RepartosComprobantes_RepartosComprobantes] FOREIGN KEY([IdSucursal], [IdReparto], [Orden])
REFERENCES [dbo].[RepartosComprobantes] ([IdSucursal], [IdReparto], [Orden])
GO

ALTER TABLE [dbo].[RepartosComprobantes] CHECK CONSTRAINT [FK_RepartosComprobantes_RepartosComprobantes]
GO

ALTER TABLE [dbo].[RepartosComprobantes]  WITH CHECK ADD  CONSTRAINT [FK_RepartosComprobantes_Ventas] FOREIGN KEY([IdTipoComprobanteFact], [LetraFact], [CentroEmisorFact], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO

ALTER TABLE [dbo].[RepartosComprobantes] CHECK CONSTRAINT [FK_RepartosComprobantes_Ventas]
GO


PRINT '8. Crea tabla RepartosComprobantesProductos (no existe en SILIVE)'
/****** Object:  Table [dbo].[RepartosComprobantesProducto]    Script Date: 11/12/2018 08:51:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RepartosComprobantesProductos](
	[IdSucursal] [int] NOT NULL,
	[IdReparto] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[OrdenProducto] [int] NOT NULL,
	[NombreProducto] [varchar](60) NOT NULL,
	[Cantidad] [decimal](16, 4) NOT NULL,
	[CantidadCambio] [decimal](16, 4) NOT NULL,
	[Precio] [decimal](16, 4) NOT NULL,
	[PrecioConImp] [decimal](16, 4) NOT NULL,
 CONSTRAINT [PK_RepartosComprobantesProductos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdReparto] ASC,
	[Orden] ASC,
	[IdProducto] ASC,
	[OrdenProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[RepartosComprobantesProductos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosComprobantesProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[RepartosComprobantesProductos] CHECK CONSTRAINT [FK_RepartosComprobantesProductos_Productos]
GO

ALTER TABLE [dbo].[RepartosComprobantesProductos]  WITH CHECK ADD  CONSTRAINT [FK_RepartosComprobantesProductos_RepartosComprobantes] FOREIGN KEY([IdSucursal], [IdReparto], [Orden])
REFERENCES [dbo].[RepartosComprobantes] ([IdSucursal], [IdReparto], [Orden])
GO

ALTER TABLE [dbo].[RepartosComprobantesProductos] CHECK CONSTRAINT [FK_RepartosComprobantesProductos_RepartosComprobantes]
GO


PRINT '9. Agrega Comprobante de Salida y Entrada a Reparto (no existe en SILIVE)'
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Repartos ADD
	IdSucursalSalida int NULL,
	IdTipoComprobanteSalida varchar(15) NULL,
	LetraSalida varchar(1) NULL,
	CentroEmisorSalida int NULL,
	NumeroComprobanteSalida bigint NULL
ALTER TABLE dbo.Repartos ADD
	IdSucursalEntrada int NULL,
	IdTipoComprobanteEntrada varchar(15) NULL,
	LetraEntrada varchar(1) NULL,
	CentroEmisorEntrada int NULL,
	NumeroComprobanteEntrada bigint NULL

ALTER TABLE dbo.Repartos ADD CONSTRAINT FK_Repartos_Ventas_Entrada
    FOREIGN KEY (IdTipoComprobanteEntrada,LetraEntrada,CentroEmisorEntrada,NumeroComprobanteEntrada,IdSucursalEntrada)
    REFERENCES dbo.Ventas (IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Repartos ADD CONSTRAINT FK_Repartos_Ventas_Salida
    FOREIGN KEY (IdTipoComprobanteSalida,LetraSalida,CentroEmisorSalida,NumeroComprobanteSalida,IdSucursalSalida)
    REFERENCES dbo.Ventas (IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Repartos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '10. Agrega Recibo a RepartoComprobante (no existe en SILIVE)'
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.RepartosComprobantes DROP CONSTRAINT FK_RepartosComprobantes_RepartosComprobantes
GO
ALTER TABLE dbo.RepartosComprobantes ADD
	IdSucursalRecibo int NULL,
	IdTipoComprobanteRecibo varchar(15) NULL,
	LetraRecibo varchar(1) NULL,
	CentroEmisorRecibo int NULL,
	NumeroComprobanteRecibo bigint NULL
GO
ALTER TABLE dbo.RepartosComprobantes ADD CONSTRAINT FK_RepartosComprobantes_CuentasCorrientes_Recibo
    FOREIGN KEY (IdSucursalRecibo,IdTipoComprobanteRecibo,LetraRecibo,CentroEmisorRecibo,NumeroComprobanteRecibo)
    REFERENCES dbo.CuentasCorrientes (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.RepartosComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '11. Agrega TotalGastos a Reparto (no existe en SILIVE)'
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.Repartos ADD TotalGastos decimal(16, 4) NULL
GO
UPDATE Repartos SET TotalGastos = 0;
ALTER TABLE dbo.Repartos ALTER COLUMN TotalGastos decimal(16, 4) NOT NULL
GO
ALTER TABLE dbo.Repartos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

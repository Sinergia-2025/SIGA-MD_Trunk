
-----------------------DROP CONSTRAINTs------------------------------------------------------------------------

--LiquidacionesDetallesClientes
ALTER TABLE LiquidacionesDetallesClientes DROP CONSTRAINT PK_LiquidacionDetalleCliente
GO
ALTER TABLE LiquidacionesDetallesClientes DROP CONSTRAINT FK_LiquidacionesDetallesClientes_LiquidacionesCargos
GO

--LiquidacionesObservaciones
ALTER TABLE LiquidacionesObservaciones DROP CONSTRAINT PK_LiquidacionesObservaciones
GO
ALTER TABLE LiquidacionesObservaciones DROP CONSTRAINT FK_LiquidacionesObservaciones_Liquidaciones
GO

--LiquidacionesCargos
ALTER TABLE LiquidacionesCargos DROP CONSTRAINT PK_LiquidacionesCargos
GO
ALTER TABLE LiquidacionesCargos DROP CONSTRAINT FK_LiquidacionesCargos_Liquidaciones
GO


--Liquidaciones
ALTER TABLE Liquidaciones DROP CONSTRAINT PK_Liquidaciones
GO


--CargosClientes
ALTER TABLE CargosClientes DROP CONSTRAINT  PK_CargosClientes
GO

--CargosClientesObservaciones
ALTER TABLE CargosClientesObservaciones DROP CONSTRAINT  PK_CargosClientesObservaciones
GO

----------------AGREGAR Tipo Liquidacion -------------------------------------------------------------------

--Cargos
ALTER TABLE Cargos ADD IdTipoLiquidacion int null
GO
UPDATE Cargos SET IdTipoLiquidacion = 1
GO


--CargosClientes
ALTER TABLE CargosClientes ADD IdTipoLiquidacion int null
GO
UPDATE CargosClientes SET IdTipoLiquidacion = 1
GO
ALTER TABLE CargosClientes ALTER COLUMN IdTipoLiquidacion int not null
GO

--CargosClientesObservaciones
ALTER TABLE CargosClientesObservaciones ADD IdTipoLiquidacion int null
GO
UPDATE CargosClientesObservaciones SET IdTipoLiquidacion = 1
GO
ALTER TABLE CargosClientesObservaciones ALTER COLUMN IdTipoLiquidacion int not null
GO

--Liquidaciones
ALTER TABLE Liquidaciones ADD IdTipoLiquidacion int null
GO
UPDATE Liquidaciones SET IdTipoLiquidacion = 1
GO
ALTER TABLE Liquidaciones ALTER COLUMN IdTipoLiquidacion int not null
GO

--LiquidacionesObservaciones
ALTER TABLE LiquidacionesObservaciones ADD IdTipoLiquidacion int null
GO
UPDATE LiquidacionesObservaciones SET IdTipoLiquidacion = 1
GO
ALTER TABLE LiquidacionesObservaciones ALTER COLUMN IdTipoLiquidacion int not null
GO

--LiquidacionesCargos
ALTER TABLE LiquidacionesCargos ADD IdTipoLiquidacion int null
GO
UPDATE LiquidacionesCargos SET IdTipoLiquidacion = 1
GO
ALTER TABLE LiquidacionesCargos ALTER COLUMN IdTipoLiquidacion int not null
GO

--LiquidacionesDetallesClientes
ALTER TABLE LiquidacionesDetallesClientes ADD IdTipoLiquidacion int null
GO
UPDATE LiquidacionesDetallesClientes SET IdTipoLiquidacion = 1
GO
ALTER TABLE LiquidacionesDetallesClientes ALTER COLUMN IdTipoLiquidacion int not null
GO

-------------Crear nuevamente PKs y FKs ---------------------------------------------------------------------------------------


--CargosClientes
ALTER TABLE [dbo].[CargosClientes] ADD CONSTRAINT [PK_CargosClientes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoLiquidacion] ASC,
	[IdCliente] ASC,
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--CargosClientesObservaciones
ALTER TABLE [dbo].[CargosClientesObservaciones] ADD CONSTRAINT [PK_CargosClientesObservaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoLiquidacion] ASC,
	[IdCliente] ASC,
	[Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--Liquidaciones
ALTER TABLE [dbo].[Liquidaciones] ADD CONSTRAINT [PK_Liquidaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[PeriodoLiquidacion] ASC,
	[IdTipoLiquidacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--LiquidacionesCargos
ALTER TABLE [dbo].[LiquidacionesCargos] ADD CONSTRAINT [PK_LiquidacionesCargos] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[PeriodoLiquidacion] ASC,
	[IdTipoLiquidacion] ASC,
	[IdLiquidacionCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LiquidacionesCargos]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesCargos_Liquidaciones] FOREIGN KEY([IdSucursal], [PeriodoLiquidacion], [IdTipoLiquidacion])
REFERENCES [dbo].[Liquidaciones] ([IdSucursal], [PeriodoLiquidacion], [IdTipoLiquidacion])
GO

ALTER TABLE [dbo].[LiquidacionesCargos] CHECK CONSTRAINT [FK_LiquidacionesCargos_Liquidaciones]
GO

--LiquidacionesDetallesClientes
ALTER TABLE [dbo].[LiquidacionesDetallesClientes] ADD CONSTRAINT [PK_LiquidacionesDetallesClientes] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[PeriodoLiquidacion] ASC,
	[IdTipoLiquidacion] ASC,
	[IdLiquidacionCargo] ASC,
	[IdLiquidacionDetalleCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LiquidacionesDetallesClientes]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesDetallesClientes_LiquidacionesCargos] FOREIGN KEY([IdSucursal], [PeriodoLiquidacion], [IdTipoLiquidacion], [IdLiquidacionCargo])
REFERENCES [dbo].[LiquidacionesCargos] ([IdSucursal], [PeriodoLiquidacion], [IdTipoLiquidacion], [IdLiquidacionCargo])
GO

ALTER TABLE [dbo].[LiquidacionesDetallesClientes] CHECK CONSTRAINT [FK_LiquidacionesDetallesClientes_LiquidacionesCargos]
GO

--LiquidacionesObservaciones

ALTER TABLE [dbo].[LiquidacionesObservaciones]  ADD  CONSTRAINT [PK_LiquidacionesObservaciones] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[PeriodoLiquidacion] ASC,
	[IdTipoLiquidacion] ASC,
	[IdCliente] ASC,
	[Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LiquidacionesObservaciones]  WITH CHECK ADD  CONSTRAINT [FK_LiquidacionesObservaciones_Liquidaciones] FOREIGN KEY([IdSucursal], [PeriodoLiquidacion], [IdTipoLiquidacion])
REFERENCES [dbo].[Liquidaciones] ([IdSucursal], [PeriodoLiquidacion], [IdTipoLiquidacion])
GO

ALTER TABLE [dbo].[LiquidacionesObservaciones] CHECK CONSTRAINT [FK_LiquidacionesObservaciones_Liquidaciones]
GO

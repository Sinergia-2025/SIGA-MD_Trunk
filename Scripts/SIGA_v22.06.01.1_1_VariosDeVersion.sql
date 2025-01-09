PRINT ''
PRINT '1.PedidosProveedores:  Nuevo Campo: FechaReprogramacion'

	--ALTER TABLE PedidosProveedores ADD FechaReprogramacion datetime Null

IF object_id('CalidadEnviosOC', 'U') is not null
	BEGIN
		PRINT ''
		PRINT 'CalidadEnviosOC:  Nuevo Campo: FechaReprogramacion'

		ALTER TABLE CalidadEnviosOC ADD FechaReprogramacion datetime Null
	END
ELSE
	BEGIN
		PRINT ''
		PRINT 'Creo la tabla CalidadEnviosOC (22.04.06.1_1)'
		SET ANSI_NULLS ON

		SET QUOTED_IDENTIFIER ON

		CREATE TABLE [dbo].[CalidadEnviosOC](
			[IdSucursal] [int] NOT NULL,
			[IdTipoComprobante] [varchar](15) NOT NULL,
			[Letra] [varchar](1) NOT NULL,
			[CentroEmisor] [int] NOT NULL,
			[NumeroPedido] [bigint] NOT NULL,
			[FechaEnvio] [datetime] NOT NULL,
			[IdUsuario] [varchar](10) NOT NULL,
			[MetodoGrabacion] [char](1) NOT NULL,
			[IdFuncion] [varchar](30) NOT NULL,
		 CONSTRAINT [PK_CalidadEnviosOC] PRIMARY KEY CLUSTERED 
		(
			[IdSucursal] ASC,
			[IdTipoComprobante] ASC,
			[Letra] ASC,
			[CentroEmisor] ASC,
			[NumeroPedido] ASC,
			[FechaEnvio] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[CalidadEnviosOC]  WITH CHECK ADD  CONSTRAINT [FK_CalidadEnviosOC_PedidosProveedores] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])
		REFERENCES [dbo].[PedidosProveedores] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroPedido])

		ALTER TABLE [dbo].[CalidadEnviosOC] CHECK CONSTRAINT [FK_CalidadEnviosOC_PedidosProveedores]

		ALTER TABLE [dbo].[CalidadEnviosOC]  WITH CHECK ADD  CONSTRAINT [FK_CalidadEnviosOC_Usuarios] FOREIGN KEY([IdUsuario])
		REFERENCES [dbo].[Usuarios] ([Id])

		ALTER TABLE [dbo].[CalidadEnviosOC] CHECK CONSTRAINT [FK_CalidadEnviosOC_Usuarios]

		ALTER TABLE CalidadEnviosOC ADD FechaReprogramacion datetime Null

	END
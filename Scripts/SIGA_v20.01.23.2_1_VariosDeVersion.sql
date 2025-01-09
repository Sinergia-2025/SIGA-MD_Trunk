/****** Object:  Table [dbo].[CalendariosSucursales]    Script Date: 21/01/2020 15:26:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalendariosSucursales](
	[IdSucursal] [int] NOT NULL,
	[IdCalendario] [int] NOT NULL,
	[IdCaja] [int] NULL,
 CONSTRAINT [PK_CalendariosSucursales] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdCalendario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CalendariosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosSucursales_CajasNombres] FOREIGN KEY([IdSucursal], [IdCaja])
REFERENCES [dbo].[CajasNombres] ([IdSucursal], [IdCaja])
GO

ALTER TABLE [dbo].[CalendariosSucursales] CHECK CONSTRAINT [FK_CalendariosSucursales_CajasNombres]
GO

ALTER TABLE [dbo].[CalendariosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosSucursales_Calendarios] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendarios] ([IdCalendario])
GO

ALTER TABLE [dbo].[CalendariosSucursales] CHECK CONSTRAINT [FK_CalendariosSucursales_Calendarios]
GO

ALTER TABLE [dbo].[CalendariosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosSucursales_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO

ALTER TABLE [dbo].[CalendariosSucursales] CHECK CONSTRAINT [FK_CalendariosSucursales_Sucursales]
GO



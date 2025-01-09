CREATE TABLE [dbo].[ComprasDistribucionExpensas](
    [IdSucursal] [int] NOT NULL,
    [IdTipoComprobante] [varchar](15) NOT NULL,
    [Letra] [varchar](1) NOT NULL,
    [CentroEmisor] [int] NOT NULL,
    [NumeroComprobante] [bigint] NOT NULL,
    [IdProveedor] [bigint] NOT NULL,
    [IdAreaComun] [varchar](10) NOT NULL,
    [Importe] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_ComprasDistribucionExpensas] PRIMARY KEY CLUSTERED 
(
    [IdSucursal] ASC,
    [IdTipoComprobante] ASC,
    [Letra] ASC,
    [CentroEmisor] ASC,
    [NumeroComprobante] ASC,
    [IdProveedor] ASC,
    [IdAreaComun] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ComprasDistribucionExpensas]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDistribucionExpensas_AreasComunes] FOREIGN KEY([IdAreaComun])
REFERENCES [dbo].[AreasComunes] ([IdAreaComun])
ALTER TABLE [dbo].[ComprasDistribucionExpensas] CHECK CONSTRAINT [FK_ComprasDistribucionExpensas_AreasComunes]
GO

ALTER TABLE [dbo].[ComprasDistribucionExpensas]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDistribucionExpensas_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
ALTER TABLE [dbo].[ComprasDistribucionExpensas] CHECK CONSTRAINT [FK_ComprasDistribucionExpensas_Compras]
GO

------------------------------------------------
CREATE TABLE [dbo].[GruposCamas](
    [IdGrupoCama] [int] NOT NULL,
    [NombreGrupoCama] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GruposCamas] PRIMARY KEY CLUSTERED 
(
    [IdGrupoCama] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------------------------

CREATE TABLE [dbo].[ComprasDistribucionPorGrupo](
    [IdSucursal] [int] NOT NULL,
    [IdTipoComprobante] [varchar](15) NOT NULL,
    [Letra] [varchar](1) NOT NULL,
    [CentroEmisor] [int] NOT NULL,
    [NumeroComprobante] [bigint] NOT NULL,
    [IdProveedor] [bigint] NOT NULL,
    [IdGrupoCama] [int] NOT NULL,
    [Importe] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_ComprasDistribucionPorGrupo_1] PRIMARY KEY CLUSTERED 
(
    [IdSucursal] ASC,
    [IdTipoComprobante] ASC,
    [Letra] ASC,
    [CentroEmisor] ASC,
    [NumeroComprobante] ASC,
    [IdProveedor] ASC,
    [IdGrupoCama] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ComprasDistribucionPorGrupo]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDistribucionPorGrupo_Compras] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
REFERENCES [dbo].[Compras] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdProveedor])
ALTER TABLE [dbo].[ComprasDistribucionPorGrupo] CHECK CONSTRAINT [FK_ComprasDistribucionPorGrupo_Compras]
GO

ALTER TABLE [dbo].[ComprasDistribucionPorGrupo]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDistribucionPorGrupo_GruposCamas] FOREIGN KEY([IdGrupoCama])
REFERENCES [dbo].[GruposCamas] ([IdGrupoCama])
ALTER TABLE [dbo].[ComprasDistribucionPorGrupo] CHECK CONSTRAINT [FK_ComprasDistribucionPorGrupo_GruposCamas]
GO


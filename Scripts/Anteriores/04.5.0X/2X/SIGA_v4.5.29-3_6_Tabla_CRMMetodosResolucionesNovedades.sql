
PRINT '1. CRMTiposNovedadesDinamicos - Agregar Metodo de Resolucion';

--INSERT [dbo].[CRMTiposNovedadesDinamicos] ([IdTipoNovedad], [IdNombreDinamico], [EsRequerido]) 
--     VALUES ('RECCLTE', 'METODORESOLUCION', 0)
--GO


PRINT '2. CRMMetodosResolucionesNovedades - Tabla';

/****** Object:  Table [dbo].[CRMMetodosResolucionesNovedades]    Script Date: 10/27/2016 11:44:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CRMMetodosResolucionesNovedades](
    [IdMetodoResolucionNovedad] [int] NOT NULL,
    [NombreMetodoResolucionNovedad] [varchar](20) NOT NULL,
    [Posicion] [int] NOT NULL,
    [IdTipoNovedad] [varchar](10) NOT NULL,
    [PorDefecto] [bit] NOT NULL,
 CONSTRAINT [PK_CRMMetodosResolucionesNovedades] PRIMARY KEY CLUSTERED 
(
    [IdMetodoResolucionNovedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CRMMetodosResolucionesNovedades]  WITH CHECK ADD  CONSTRAINT [FK_CRMMetodosResolucionesNovedades_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
GO

ALTER TABLE [dbo].[CRMMetodosResolucionesNovedades] CHECK CONSTRAINT [FK_CRMMetodosResolucionesNovedades_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMMetodosResolucionesNovedades] ADD CONSTRAINT [DF_CRMMetodosResolucionesNovedades_PorDefecto] DEFAULT ((0)) FOR [PorDefecto]
GO


PRINT '3. CRMMetodosResolucionesNovedades - Registros';

/****** Object:  Table [dbo].[CRMMetodosResolucionesNovedades]    Script Date: 11/02/2016 14:36:45 ******/
INSERT [dbo].[CRMMetodosResolucionesNovedades] ([IdMetodoResolucionNovedad], [NombreMetodoResolucionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) 
 VALUES (1, 'CLIENTE', 1, 'RECCLTE', 0);
INSERT [dbo].[CRMMetodosResolucionesNovedades] ([IdMetodoResolucionNovedad], [NombreMetodoResolucionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) 
 VALUES (2, 'REMOTO', 2, 'RECCLTE', 0);
INSERT [dbo].[CRMMetodosResolucionesNovedades] ([IdMetodoResolucionNovedad], [NombreMetodoResolucionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto]) 
 VALUES (3, 'OFICINA', 3, 'RECCLTE', 1);
INSERT [dbo].[CRMMetodosResolucionesNovedades] ([IdMetodoResolucionNovedad], [NombreMetodoResolucionNovedad], [Posicion], [IdTipoNovedad], [PorDefecto])
 VALUES (4, 'FUERA OFICINA', 4, 'RECCLTE', 0);


PRINT '4. CRMNovedades.IdMetodoResolucionNovedad - Campo y FK';

/****** Object:  Table [dbo].[CRMMetodosResolucionesNovedades]    Script Date: 10/27/2016 11:44:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE dbo.CRMNovedades ADD IdMetodoResolucionNovedad int NULL
GO
ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_CRMMetodosResolucionesNovedades
    FOREIGN KEY (IdMetodoResolucionNovedad)
    REFERENCES dbo.CRMMetodosResolucionesNovedades (IdMetodoResolucionNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

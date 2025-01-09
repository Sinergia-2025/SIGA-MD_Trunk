
PRINT '1. Menu Nuevo: Archivos\ABM de Tipos de Adjuntos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Archivos')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'TiposAdjuntosABM')
            BEGIN
                --Inserto la pantalla nueva
                INSERT INTO Funciones
                     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
                  VALUES
                     ('TiposAdjuntosABM', 'Tipos de Adjuntos', 'Tipos de Adjuntos', 'True', 'False', 'True', 'True',
                      'Archivos', 175, 'Eniac.Win', 'TiposAdjuntosABM', NULL);

                INSERT INTO RolesFunciones 
                      (IdRol,IdFuncion)
                SELECT DISTINCT Id AS Rol, 'TiposAdjuntosABM' AS Pantalla FROM dbo.Roles
                    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            END;
    END;


PRINT ''
PRINT '2. Tabla Nueva: TiposAdjuntos.'
GO

/****** Object:  Table [dbo].[TiposAdjuntos]    Script Date: 02/02/2018 17:32:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposAdjuntos](
	[IdTipoAdjunto] [int] NOT NULL,
	[NombreTipoAdjunto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposAdjuntos] 
 PRIMARY KEY CLUSTERED ([IdTipoAdjunto] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClientesAdjuntos](
	[IdCliente] [bigint] NOT NULL,
	[IdClienteAdjunto] [bigint] NOT NULL,
	[IdTipoAdjunto] [int] NOT NULL,
	[NombreAdjunto] [varchar](260) NOT NULL,
	[Adjunto] [varbinary](max) NULL,
	[Observaciones] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_ClientesAdjuntos] 
 PRIMARY KEY CLUSTERED ([IdCliente] ASC,[IdClienteAdjunto] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesAdjuntos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesAdjuntos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesAdjuntos] CHECK CONSTRAINT [FK_ClientesAdjuntos_Clientes]
GO

ALTER TABLE [dbo].[ClientesAdjuntos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesAdjuntos_TiposAdjuntos] FOREIGN KEY([IdTipoAdjunto])
REFERENCES [dbo].[TiposAdjuntos] ([IdTipoAdjunto])
GO

ALTER TABLE [dbo].[ClientesAdjuntos] CHECK CONSTRAINT [FK_ClientesAdjuntos_TiposAdjuntos]
GO


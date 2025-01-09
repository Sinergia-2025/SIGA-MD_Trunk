
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AuditoriaClientes](
	[FechaAuditoria] [datetime] NOT NULL,
	[OperacionAuditoria] [char](1) NOT NULL,
	[UsuarioAuditoria] [varchar](10) NOT NULL,
	[TipoDocumento] [varchar](5) NOT NULL,
	[NroDocumento] [varchar](12) NOT NULL,
	[NombreCliente] [varchar](100) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[IdLocalidad] [int] NOT NULL,
	[Telefono] [varchar](100) NULL,
	[FechaNacimiento] [datetime] NULL,
	[NroOperacion] [int] NULL,
	[CorreoElectronico] [varchar](50) NULL,
	[Celular] [varchar](100) NULL,
	[NombreTrabajo] [varchar](100) NULL,
	[DireccionTrabajo] [varchar](100) NULL,
	[IdLocalidadTrabajo] [int] NULL,
	[TelefonoTrabajo] [varchar](100) NULL,
	[CorreoTrabajo] [varchar](100) NULL,
	[FechaIngresoTrabajo] [datetime] NULL,
	[FechaAlta] [datetime] NULL,
	[SaldoPendiente] [decimal](10, 2) NULL,
	[TipoDocumentoGarante] [varchar](5) NULL,
	[NroDocumentoGarante] [varchar](12) NULL,
	[IdCategoria] [int] NULL,
	[IdCategoriaFiscal] [smallint] NULL,
	[Cuit] [varchar](13) NULL,
	[TipoDocVendedor] [varchar](5) NOT NULL,
	[NroDocVendedor] [varchar](12) NOT NULL,
	[Observacion] [varchar](200) NULL,
	[IdListaPrecios] [int] NOT NULL,
	[IdZonaGeografica] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_AuditoriaClientes] PRIMARY KEY CLUSTERED 
(
	[FechaAuditoria] ASC,
	[TipoDocumento] ASC,
	[NroDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AuditoriaClientes]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaClientes_Usuarios] FOREIGN KEY([UsuarioAuditoria])
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[AuditoriaClientes] CHECK CONSTRAINT [FK_AuditoriaClientes_Usuarios]
GO



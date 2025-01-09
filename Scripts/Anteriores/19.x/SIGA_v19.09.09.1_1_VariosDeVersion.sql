SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO
PRINT ''
PRINT '1. Nueva Tabla AuditoriaParametros'
CREATE TABLE [dbo].[AuditoriaParametros](
	[FechaAuditoria] [datetime] NOT NULL,
	[OperacionAuditoria] [char](1) NOT NULL,
	[UsuarioAuditoria] [varchar](10) NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[IdParametro] [varchar](50) NOT NULL,
	[ValorParametro] [varchar](200) NULL,
	[CategoriaParametro] [varchar](20) NULL,
	[DescripcionParametro] [varchar](200) NOT NULL,
 CONSTRAINT [PK_AuditoriaParametros] PRIMARY KEY CLUSTERED 
(
    [FechaAuditoria] ASC,
	[IdEmpresa] ASC,
	[IdParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AuditoriaParametros]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaParametros_Usuarios] FOREIGN KEY([UsuarioAuditoria])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[AuditoriaParametros] CHECK CONSTRAINT [FK_AuditoriaParametros_Usuarios]
GO

PRINT ''
PRINT '2. Nueva Tabla AuditoriaParametrosImagenes'
CREATE TABLE [dbo].[AuditoriaParametrosImagenes](
	[FechaAuditoria] [datetime] NOT NULL,
	[OperacionAuditoria] [char](1) NOT NULL,
	[UsuarioAuditoria] [varchar](10) NOT NULL,
	[IdParametroImagen] [varchar](50) NOT NULL,
	[ValorParametroImagen] [image] NULL,
	[IdEmpresa] [int] NOT NULL,
 CONSTRAINT [PK_AuditoriaParametrosImagenes] PRIMARY KEY CLUSTERED 
(
	[FechaAuditoria] ASC,
	[IdParametroImagen] ASC,
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AuditoriaParametrosImagenes]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaParametrosImagenes_Usuarios] FOREIGN KEY([UsuarioAuditoria])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[AuditoriaParametrosImagenes] CHECK CONSTRAINT [FK_AuditoriaParametrosImagenes_Usuarios]
GO

PRINT ''
PRINT '3. Tabla RepartosComprobantes: Nuevos campos ImporteTotalFact y ImporteTotalRecibo'
ALTER TABLE dbo.RepartosComprobantes ADD ImporteTotalFact decimal(14, 2) NULL
ALTER TABLE dbo.RepartosComprobantes ADD ImporteTotalRecibo decimal(14, 2) NULL
GO

PRINT ''
PRINT '3.1. Tabla RepartosComprobantes: Valores por defecto para ImporteTotalFact y ImporteTotalRecibo'
UPDATE RC
   SET ImporteTotalFact = V.ImporteTotal
     , ImporteTotalRecibo = CC.ImporteTotal * -1
  FROM RepartosComprobantes RC
  LEFT JOIN Ventas V ON V.IdSucursal = RC.IdSucursal
                    AND V.IdTipoComprobante = RC.IdTipoComprobanteFact
                    AND V.Letra = RC.LetraFact
                    AND V.CentroEmisor = RC.CentroEmisorFact
                    AND V.NumeroComprobante = RC.NumeroComprobante
  LEFT JOIN CuentasCorrientes CC ON CC.IdSucursal = RC.IdSucursalRecibo
                                AND CC.IdTipoComprobante = RC.IdTipoComprobanteRecibo
                                AND CC.Letra = RC.LetraRecibo
                                AND CC.CentroEmisor = RC.CentroEmisorRecibo
                                AND CC.NumeroComprobante = RC.NumeroComprobanteRecibo


PRINT ''
PRINT '4. Tabla Clientes: Nuevos campos Alicuota2deProducto, CertificadoMiPyme, FechaDesdeCertificado y FechaHastaCertificado'
ALTER TABLE dbo.Clientes ADD Alicuota2deProducto varchar(50) null;
ALTER TABLE dbo.Clientes ADD CertificadoMiPyme bit null;
ALTER TABLE dbo.Clientes ADD FechaDesdeCertificado datetime null;
ALTER TABLE dbo.Clientes ADD FechaHastaCertificado datetime null;
GO

PRINT ''
PRINT '4.1. Tabla Clientes: Valores por defecto para Alicuota2deProducto, CertificadoMiPyme'
UPDATE dbo.Clientes
   SET Alicuota2deProducto  = 'SEGUNCATEGORIAFISCAL'
     , CertificadoMiPyme = 'False';

PRINT ''
PRINT '4.2. Tabla Clientes: NOT NULL para Alicuota2deProducto, CertificadoMiPyme'
ALTER TABLE dbo.Clientes   ALTER COLUMN Alicuota2deProducto varchar(50) NOT NULL
ALTER TABLE dbo.Clientes   ALTER COLUMN CertificadoMiPyme bit NOT NULL


PRINT ''
PRINT '5. Tabla AuditoriaClientes: Nuevos campos Alicuota2deProducto, CertificadoMiPyme, FechaDesdeCertificado y FechaHastaCertificado'
ALTER TABLE dbo.AuditoriaClientes ADD Alicuota2deProducto varchar(50) null;
ALTER TABLE dbo.AuditoriaClientes ADD CertificadoMiPyme bit null;
ALTER TABLE dbo.AuditoriaClientes ADD FechaDesdeCertificado datetime null;
ALTER TABLE dbo.AuditoriaClientes ADD FechaHastaCertificado datetime null;


PRINT ''
PRINT '6. Tabla Prospectos: Nuevos campos Alicuota2deProducto, CertificadoMiPyme, FechaDesdeCertificado y FechaHastaCertificado'
ALTER TABLE dbo.Prospectos ADD Alicuota2deProducto varchar(50) null;
ALTER TABLE dbo.Prospectos ADD CertificadoMiPyme bit null;
ALTER TABLE dbo.Prospectos ADD FechaDesdeCertificado datetime null;
ALTER TABLE dbo.Prospectos ADD FechaHastaCertificado datetime null;
GO

PRINT ''
PRINT '6.1. Tabla Prospectos: Valores por defecto para Alicuota2deProducto, CertificadoMiPyme'
UPDATE dbo.Prospectos
   SET Alicuota2deProducto  = 'SEGUNCATEGORIAFISCAL'
     , CertificadoMiPyme = 'False';

PRINT ''
PRINT '6.2. Tabla Prospectos: NOT NULL para Alicuota2deProducto, CertificadoMiPyme'
ALTER TABLE dbo.Prospectos ALTER COLUMN Alicuota2deProducto varchar(50) NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN CertificadoMiPyme bit NOT NULL


PRINT ''
PRINT '7. Tabla AuditoriaProspectos: Nuevos campos Alicuota2deProducto, CertificadoMiPyme, FechaDesdeCertificado y FechaHastaCertificado'
ALTER TABLE dbo.AuditoriaProspectos ADD Alicuota2deProducto varchar(50) null;
ALTER TABLE dbo.AuditoriaProspectos ADD CertificadoMiPyme bit null;
ALTER TABLE dbo.AuditoriaProspectos ADD FechaDesdeCertificado datetime null;
ALTER TABLE dbo.AuditoriaProspectos ADD FechaHastaCertificado datetime null;

SET ANSI_PADDING OFF
GO

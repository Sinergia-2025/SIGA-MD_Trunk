PRINT '1. Nueva Pantalla: CRM\Envio de Novedades de Versiones.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'CRM')
    BEGIN
    IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
		BEGIN
			--Inserto la pantalla nueva
			INSERT INTO Funciones
					(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
					,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros, Plus, Express, Basica, PV)
				VALUES
					('EnvioNovedadesDeVersiones', 'Envio de Novedades de Versiones', 'Envio de Novedades de Versiones', 'True', 'False', 'True', 'True',
					'CRM', 10, 'Eniac.Win', 'EnvioNovedadesDeVersiones', NULL, NULL,'NO', 'NO', 'NO', 'NO');

			INSERT INTO RolesFunciones 
					(IdRol,IdFuncion)
			SELECT DISTINCT Id AS Rol, 'EnvioNovedadesDeVersiones' AS Pantalla FROM dbo.Roles
				WHERE Id IN ('Adm' );
		END;
END;

PRINT '2. Nueva Tabla: ClientesDispositivos'
GO
/****** Object:  Table [dbo].[ClientesDispositivos]    Script Date: 08/10/2018 17:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientesDispositivos](
	[IdCliente] [bigint] NOT NULL,
	[NombreServidor] [varchar](50) NOT NULL,
	[BaseDatos] [varchar](50) NOT NULL,
	[IdDispositivo] [varchar](100) NOT NULL,
	[NombreDispositivo] [varchar](50) NOT NULL,
	[FechaUltimoLogin] [datetime] NOT NULL,
	[UsuarioUltimoLogin] [varchar](10) NOT NULL,
	[IdTipoDispositivo] [varchar](10) NOT NULL,
	[SistemaOperativo] [varchar](50) NOT NULL,
	[ArquitecturaSO] [varchar](10) NOT NULL,
	[NumeroSerieDiscoRigido] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ClientesDispositivos] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[NombreServidor] ASC,
	[BaseDatos] ASC,
	[IdDispositivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesDispositivos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesDispositivos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesDispositivos] CHECK CONSTRAINT [FK_ClientesDispositivos_Clientes]
GO


PRINT '3. Nueva Tabla: ClientesParametros'
GO
/****** Object:  Table [dbo].[ClientesParametros]    Script Date: 08/10/2018 18:24:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientesParametros](
	[IdCliente] [bigint] NOT NULL,
	[NombreServidor] [varchar](50) NOT NULL,
	[BaseDatos] [varchar](50) NOT NULL,
	[IdParametro] [varchar](50) NOT NULL,
	[ValorParametro] [varchar](200) NULL,
 CONSTRAINT [PK_ClientesParametros] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[NombreServidor] ASC,
	[BaseDatos] ASC,
	[IdParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesParametros]  WITH CHECK ADD  CONSTRAINT [FK_ClientesParametros_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesParametros] CHECK CONSTRAINT [FK_ClientesParametros_Clientes]
GO


PRINT '4. Nueva Tabla: ClientesBackups'
GO
/****** Object:  Table [dbo].[ClientesBackups]    Script Date: 08/10/2018 19:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientesBackups](
	[IdCliente] [bigint] NOT NULL,
	[NombreServidor] [varchar](50) NOT NULL,
	[BaseDatos] [varchar](50) NOT NULL,
	[FechaEjecucion] [datetime] NOT NULL,
	[FechaInicioBackup] [datetime] NULL,
	[FechaFinBackup] [datetime] NULL,
 CONSTRAINT [PK_ClientesBackups] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[NombreServidor] ASC,
	[BaseDatos] ASC,
	[FechaEjecucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ClientesBackups]  WITH CHECK ADD  CONSTRAINT [FK_ClientesBackups_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ClientesBackups] CHECK CONSTRAINT [FK_ClientesBackups_Clientes]
GO

PRINT '5. Corrección de Neto210 y familares'
GO
UPDATE Compras
   SET TotalBruto        = BrutoNoGravado_Viejo + Bruto105_Viejo + Bruto210_Viejo + Bruto270_Viejo
      ,TotalNeto         = NetoNoGravado_Viejo  + Neto105_Viejo  + Neto210_Viejo  + Neto270_Viejo
      ,TotalIVA          = 0                    + IVA105_Viejo   + IVA210_Viejo   + IVA270_Viejo
      ,TotalPercepciones = PercepcionGanancias  + PercepcionIB + PercepcionIVA + PercepcionVarias
 WHERE IdFuncion = 'MovimientosDeCompras'
;

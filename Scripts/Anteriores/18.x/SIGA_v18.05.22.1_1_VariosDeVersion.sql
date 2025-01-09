
PRINT ''
PRINT '1. Agrego Tablas TiposAntecedes, Antecedentes y Otros Seteos.'
GO

/****** Object:  Table [dbo].[TiposAntecedentes]    Script Date: 05/18/2018 13:26:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposAntecedentes](
	[IdTipoAntecedente] [int] NOT NULL,
	[NombreTipoAntecedente] [varchar](80) NULL,
 CONSTRAINT [PK_TiposAntecedentes] PRIMARY KEY CLUSTERED 
(
	[IdTipoAntecedente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Antecedentes]    Script Date: 05/18/2018 13:26:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Antecedentes](
	[IdAntecedente] [int] NOT NULL,
	[NombreAntecedente] [varchar](100) NOT NULL,
	[IdTipoAntecedente] [int] NOT NULL,
 CONSTRAINT [PK_Antecedentes_1] PRIMARY KEY CLUSTERED 
(
	[IdAntecedente] ASC,
	[IdTipoAntecedente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CalendariosUsuarios]    Script Date: 05/18/2018 13:26:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CalendariosUsuarios](
	[IdSucursal] [int] NOT NULL,
	[IdCalendario] [int] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[PermitirEscritura] [bit] NOT NULL,
 CONSTRAINT [PK_CalendariosUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdCalendario] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



/****** Object:  Table [dbo].[ClientesHistorias]    Script Date: 05/18/2018 13:26:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientesHistorias](
	[IdCliente] [bigint] NOT NULL,
	[FechaHoraItem] [datetime] NOT NULL,
	[Item] [varchar](2000) NULL,
	[Usuario] [varchar](10) NULL,
 CONSTRAINT [PK_ClientesHistorias] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[FechaHoraItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[ClientesAntecedentes]    Script Date: 05/18/2018 13:26:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientesAntecedentes](
	[IdAntecedente] [int] NOT NULL,
	[IdCliente] [bigint] NOT NULL,
	[Valor] [varchar](100) NULL,
	[FechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_ClientesAntecedentes] PRIMARY KEY CLUSTERED 
(
	[IdAntecedente] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  ForeignKey [FK_Antecedentes_TiposAntecedentes]    Script Date: 05/18/2018 13:26:44 ******/
ALTER TABLE [dbo].[Antecedentes]  WITH CHECK ADD  CONSTRAINT [FK_Antecedentes_TiposAntecedentes] FOREIGN KEY([IdTipoAntecedente])
REFERENCES [dbo].[TiposAntecedentes] ([IdTipoAntecedente])
GO
ALTER TABLE [dbo].[Antecedentes] CHECK CONSTRAINT [FK_Antecedentes_TiposAntecedentes]
GO
/****** Object:  ForeignKey [FK_CalendariosUsuarios_Calendarios]    Script Date: 05/18/2018 13:26:44 ******/
ALTER TABLE [dbo].[CalendariosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosUsuarios_Calendarios] FOREIGN KEY([IdCalendario])
REFERENCES [dbo].[Calendarios] ([IdCalendario])
GO
ALTER TABLE [dbo].[CalendariosUsuarios] CHECK CONSTRAINT [FK_CalendariosUsuarios_Calendarios]
GO
/****** Object:  ForeignKey [FK_CalendariosUsuarios_Sucursales]    Script Date: 05/18/2018 13:26:44 ******/
ALTER TABLE [dbo].[CalendariosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosUsuarios_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[CalendariosUsuarios] CHECK CONSTRAINT [FK_CalendariosUsuarios_Sucursales]
GO
/****** Object:  ForeignKey [FK_CalendariosUsuarios_Usuarios]    Script Date: 05/18/2018 13:26:44 ******/
ALTER TABLE [dbo].[CalendariosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_CalendariosUsuarios_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[CalendariosUsuarios] CHECK CONSTRAINT [FK_CalendariosUsuarios_Usuarios]
GO
/****** Object:  ForeignKey [FK_ClientesAntecedentes_Clientes]    Script Date: 05/18/2018 13:26:44 ******/
ALTER TABLE [dbo].[ClientesAntecedentes]  WITH CHECK ADD  CONSTRAINT [FK_ClientesAntecedentes_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ClientesAntecedentes] CHECK CONSTRAINT [FK_ClientesAntecedentes_Clientes]
GO
/****** Object:  ForeignKey [FK_ClientesHistorias_Clientes]    Script Date: 05/18/2018 13:26:44 ******/
ALTER TABLE [dbo].[ClientesHistorias]  WITH CHECK ADD  CONSTRAINT [FK_ClientesHistorias_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ClientesHistorias] CHECK CONSTRAINT [FK_ClientesHistorias_Clientes]
GO



PRINT ''
PRINT '2. Tabla Calendarios: Agrego IdUsuario y FK.'
GO

ALTER TABLE Calendarios ADD IdUsuario varchar(10) null
GO



PRINT ''
PRINT '3. Tablas TiposTurnos: Datos.'
GO

/****** Object:  Table [dbo].[TiposTurnos]    Script Date: 05/18/2018 13:08:11 ******/
INSERT [dbo].[TiposTurnos] ([IdTipoTurno], [NombreTipoTurno]) VALUES ('A', 'Asignado')
INSERT [dbo].[TiposTurnos] ([IdTipoTurno], [NombreTipoTurno]) VALUES ('C', 'Cancelado')
INSERT [dbo].[TiposTurnos] ([IdTipoTurno], [NombreTipoTurno]) VALUES ('E', 'En Espera')
INSERT [dbo].[TiposTurnos] ([IdTipoTurno], [NombreTipoTurno]) VALUES ('T', 'Atendido')


PRINT ''
PRINT '4. Tablas TiposAntecedentes: Datos.'
GO

/****** Object:  Table [dbo].[TiposAntecedentes]    Script Date: 05/18/2018 13:08:11 ******/
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (1, 'OTROS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (2, 'Cardiacos')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (3, 'CONGENITOS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (4, 'OSTEO ARTRO MUSCULAR')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (5, 'SANGUINEOS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (6, 'RENALES')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (7, 'HEPATICOS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (8, 'METABOLICOS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (9, 'HORMONALES')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (10, 'CEREBRAL')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (11, 'MUSCULAR')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (12, 'HABITOS TÓXICOS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (13, 'ALERGIAS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (14, 'RESPIRATORIOS')
INSERT [dbo].[TiposAntecedentes] ([IdTipoAntecedente], [NombreTipoAntecedente]) VALUES (15, 'DIGESTIVOS')
/****** Object:  Table [dbo].[Antecedentes]    Script Date: 05/18/2018 13:08:11 ******/
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (1, 'Perdida de Conocimiento', 10)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (2, 'Convulsiones', 10)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (3, 'INFARTO', 2)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (4, 'Hipertension Arterial', 2)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (5, 'PATOLOGIAS', 3)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (6, 'FUMADOR', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (7, 'ANOREXIA', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (8, 'BULIMIA', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (9, 'OBESIDAD', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (10, 'VIGOREXIA', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (11, 'ALCOHOL', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (12, 'DROGAS', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (13, 'RESPIRATORIAS', 13)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (14, 'CUTANEAS', 13)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (15, 'CLIMATICAS', 13)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (16, 'MEDICAMENTOS', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (17, 'SOPLO', 2)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (18, 'MEDICAMENTO', 13)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (19, 'SOPLO FUNCIONAL', 2)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (20, 'ACV', 10)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (21, 'HERNIA DE HIATO', 15)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (22, 'COLON IRRITABLE', 15)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (23, 'GASTRITIS', 15)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (24, 'BILIRRUBINA', 7)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (25, 'TIROIDES', 9)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (26, 'HIPERTIROIDISMO', 9)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (27, 'HIPOTIROIDISMO', 9)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (28, 'desgarros', 11)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (30, 'OTROS', 2)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (31, 'OTROS', 3)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (32, 'OTROS', 15)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (33, 'OTROS', 12)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (34, 'OTROS', 7)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (35, 'OTROS', 9)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (36, 'OTROS', 8)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (37, 'OTROS', 11)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (38, 'OTROS', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (39, 'OTROS', 6)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (40, 'OTROS', 13)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (41, 'OTROS', 14)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (42, 'OTROS', 5)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (43, 'OTROS', 10)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (44, 'HERNIA DE DISCO', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (45, 'PINZAMIENTO', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (46, 'ARTROSIS', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (47, 'ARTROSIS', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (48, 'TENDINITIS', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (49, 'ROTURA DE LIGAMENTOS', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (50, 'ROTURA DE MEÑISCOS', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (51, 'ESGUINCE', 4)
INSERT [dbo].[Antecedentes] ([IdAntecedente], [NombreAntecedente], [IdTipoAntecedente]) VALUES (52, 'DESGARRO', 4)


PRINT ''
PRINT '5. Nuevos Menues de Turnos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Turnos')
 AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                    AND P.ValorParametro IN ('50000000024', '27329245069'))
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('TiposAntecedentesABM', 'ABM de Tipos Antecedentes', 'ABM de Tipos Antecedentes', 'True', 'False', 'True', 'True',
              'Turnos', 210, 'Eniac.Win', 'TiposAntecedentesABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'TiposAntecedentesABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
            
            
              --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('AntecedentesABM', 'ABM de Antecedentes', 'ABM de Antecedentes', 'True', 'False', 'True', 'True',
              'Turnos', 220, 'Eniac.Win', 'AntecedentesABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'AntecedentesABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
            
                      --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('TableroTurnos', 'Tablero de Turnos', 'Tablero de Turnos', 'True', 'False', 'True', 'True',
              'Turnos', 30, 'Eniac.Win', 'Turnos', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'TableroTurnos' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
            
                               --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('ClientesAntecedentes', 'Antecedentes de Clientes', 'Antecedentes de Clientes', 'True', 'False', 'True', 'True',
              'Turnos', 40, 'Eniac.Win', 'ClientesAntecedentes', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'ClientesAntecedentes' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
            
            
                                    --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('Ingreso', 'Ingreso', 'Ingreso', 'True', 'False', 'True', 'True',
              'Turnos', 5, 'Eniac.Win', 'Ingreso', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'Ingreso' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;


PRINT ''
PRINT '6. Nuevos Parametros.'
GO

INSERT INTO Parametros 
           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
     VALUES
           ('TURNOSTIPOBASE', 'A', NULL, 'Tipo de Turno Asignado')
GO


INSERT INTO Parametros 
           (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
     VALUES
           ('TURNOSTIPOCAMBIO', 'E', NULL, 'Tipo de Turno luego del Ingreso')
GO

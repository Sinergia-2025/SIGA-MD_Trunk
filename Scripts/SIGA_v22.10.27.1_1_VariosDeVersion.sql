IF dbo.ExisteTabla('AlertasSistema') = 0
BEGIN
    CREATE TABLE [dbo].[AlertasSistema](
	    [IdAlertaSistema] [int] NOT NULL,
	    [TituloAlerta] [varchar](100) NOT NULL,
	    [ConsultaAlerta] [varchar](max) NOT NULL,
	    [PermisosCondicion] [varchar](5) NOT NULL,
	    [IdFuncionClick] [varchar](30) NULL,
	    [ParametrosPantalla] [varchar](1000) NOT NULL,
     CONSTRAINT [PK_AlertasSistema] PRIMARY KEY CLUSTERED ([IdAlertaSistema] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_AlertasSistema_Funciones') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistema]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistema_Funciones] FOREIGN KEY([IdFuncionClick])
    REFERENCES [dbo].[Funciones] ([Id])

    ALTER TABLE [dbo].[AlertasSistema] CHECK CONSTRAINT [FK_AlertasSistema_Funciones]
END
GO

IF dbo.ExisteTabla('AlertasSistemaCondiciones') = 0
BEGIN
    CREATE TABLE [dbo].[AlertasSistemaCondiciones](
	    [IdAlertaSistema] [int] NOT NULL,
	    [OrdenCondicion] [int] NOT NULL,
	    [CondicionCount] [varchar](5) NOT NULL,
	    [ValorCondicionCount] [int] NOT NULL,
	    [MensajeCount] [varchar](300) NOT NULL,
	    [ColorCondicionCount] [int] NOT NULL,
	    [OrdenPrioridad] [int] NOT NULL,
	    [MostrarPopUp] [bit] NOT NULL,
	    [ParametrosAdicionalesPantalla] [varchar](1000) NOT NULL,
     CONSTRAINT [PK_AlertasSistemaCondiciones] PRIMARY KEY CLUSTERED ([IdAlertaSistema] ASC, [OrdenCondicion] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_AlertasSistemaCondiciones_AlertasSistema') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistemaCondiciones]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistemaCondiciones_AlertasSistema] FOREIGN KEY([IdAlertaSistema])
    REFERENCES [dbo].[AlertasSistema] ([IdAlertaSistema])

    ALTER TABLE [dbo].[AlertasSistemaCondiciones] CHECK CONSTRAINT [FK_AlertasSistemaCondiciones_AlertasSistema]
END
GO

IF dbo.ExisteTabla('AlertasSistemaPermisos') = 0
BEGIN
    CREATE TABLE [dbo].[AlertasSistemaPermisos](
	    [IdAlertaSistema] [int] NOT NULL,
	    [IdFuncion] [varchar](30) NOT NULL,
     CONSTRAINT [PK_AlertasSistemaPermisos] PRIMARY KEY CLUSTERED ([IdAlertaSistema] ASC, [IdFuncion] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_AlertasSistemaPermisos_AlertasSistema') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistemaPermisos]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistemaPermisos_AlertasSistema] FOREIGN KEY([IdAlertaSistema])
    REFERENCES [dbo].[AlertasSistema] ([IdAlertaSistema])

    ALTER TABLE [dbo].[AlertasSistemaPermisos] CHECK CONSTRAINT [FK_AlertasSistemaPermisos_AlertasSistema]
END
GO

IF dbo.ExisteFK('FK_AlertasSistemaPermisos_Funciones') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistemaPermisos]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistemaPermisos_Funciones] FOREIGN KEY([IdFuncion])
    REFERENCES [dbo].[Funciones] ([Id])

    ALTER TABLE [dbo].[AlertasSistemaPermisos] CHECK CONSTRAINT [FK_AlertasSistemaPermisos_Funciones]
END
GO

IF dbo.ExisteTabla('AlertasSistemaRoles') = 0
BEGIN
    CREATE TABLE [dbo].[AlertasSistemaRoles](
	    [IdAlertaSistema] [int] NOT NULL,
	    [IdRol] [varchar](12) NOT NULL,
     CONSTRAINT [PK_AlertasSistemaRoles] PRIMARY KEY CLUSTERED ([IdAlertaSistema] ASC, [IdRol] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_AlertasSistemaRoles_AlertasSistema') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistemaRoles]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistemaRoles_AlertasSistema] FOREIGN KEY([IdAlertaSistema])
    REFERENCES [dbo].[AlertasSistema] ([IdAlertaSistema])

    ALTER TABLE [dbo].[AlertasSistemaRoles] CHECK CONSTRAINT [FK_AlertasSistemaRoles_AlertasSistema]
END
GO

IF dbo.ExisteFK('FK_AlertasSistemaRoles_Roles') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistemaRoles]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistemaRoles_Roles] FOREIGN KEY([IdRol])
    REFERENCES [dbo].[Roles] ([Id])

    ALTER TABLE [dbo].[AlertasSistemaRoles] CHECK CONSTRAINT [FK_AlertasSistemaRoles_Roles]
END
GO

IF dbo.ExisteTabla('AlertasSistemaUsuarios') = 0
BEGIN
    CREATE TABLE [dbo].[AlertasSistemaUsuarios](
	    [IdAlertaSistema] [int] NOT NULL,
	    [IdUsuario] [varchar](10) NOT NULL,
     CONSTRAINT [PK_AlertasSistemaUsuarios] PRIMARY KEY CLUSTERED ([IdAlertaSistema] ASC, [IdUsuario] ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_AlertasSistemaUsuarios_AlertasSistema') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistemaUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistemaUsuarios_AlertasSistema] FOREIGN KEY([IdAlertaSistema])
    REFERENCES [dbo].[AlertasSistema] ([IdAlertaSistema])

    ALTER TABLE [dbo].[AlertasSistemaUsuarios] CHECK CONSTRAINT [FK_AlertasSistemaUsuarios_AlertasSistema]
END
GO

IF dbo.ExisteFK('FK_AlertasSistemaUsuarios_Usuarios') = 0
BEGIN
    ALTER TABLE [dbo].[AlertasSistemaUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_AlertasSistemaUsuarios_Usuarios] FOREIGN KEY([IdUsuario])
    REFERENCES [dbo].[Usuarios] ([Id])

    ALTER TABLE [dbo].[AlertasSistemaUsuarios] CHECK CONSTRAINT [FK_AlertasSistemaUsuarios_Usuarios]
END
GO

UPDATE Funciones
   SET Parametros = 'TipoNovedad=' + Parametros
 WHERE Pantalla = 'CRMNovedadesABM'
   AND Parametros IS NOT NULL
   AND Parametros NOT LIKE '%=%'

IF NOT EXISTS (SELECT * FROM [AlertasSistema]) AND dbo.SoyHAR() = 1
BEGIN
    INSERT [dbo].[AlertasSistema] ([IdAlertaSistema], [TituloAlerta], [ConsultaAlerta], [PermisosCondicion], [IdFuncionClick], [ParametrosPantalla]) 
    VALUES (1, N'Pendientes Nuevos en Análisis', N'SELECT *
      FROM CRMNovedades N
     INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
     INNER JOIN CRMMetodosResolucionesNovedades MRN ON MRN.IdMetodoResolucionNovedad = N.IdMetodoResolucionNovedad
     WHERE N.IdTipoNovedad = ''PENDIENTE''
       AND EN.NombreEstadoNovedad = ''NUEVO''
       AND MRN.NombreMetodoResolucionNovedad = ''ANALISIS''
    ', N'AND', N'CRMNovedadesABMPENDIENTE', N'IdEstadoNovedad=479;IdMetodoResolucionNovedad=250;QuitarFiltroPorUsuario=True'),
           (2, N'Pendientes Nuevos en Testing', N'SELECT *
      FROM CRMNovedades N
     INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
     INNER JOIN CRMMetodosResolucionesNovedades MRN ON MRN.IdMetodoResolucionNovedad = N.IdMetodoResolucionNovedad
     WHERE N.IdTipoNovedad = ''PENDIENTE''
       AND EN.NombreEstadoNovedad = ''NUEVO''
       AND MRN.NombreMetodoResolucionNovedad = ''TESTEO''
    ', N'AND', N'CRMNovedadesABMPENDIENTE', N'IdEstadoNovedad=479;IdMetodoResolucionNovedad=252;QuitarFiltroPorUsuario=True')

    INSERT [dbo].[AlertasSistemaCondiciones] ([IdAlertaSistema], [OrdenCondicion], [CondicionCount], [ValorCondicionCount], [MensajeCount], [ColorCondicionCount], [OrdenPrioridad], [MostrarPopUp], [ParametrosAdicionalesPantalla])
    VALUES (1, 1, N'>', 0, N'Hay @@COUNT@@ registros NUEVOS en Análisis', -255, 200, 0, N''),
           (2, 1, N'>', 0, N'Hay @@COUNT@@ registros NUEVOS en Testing', -255, 200, 0, N'')

    INSERT [dbo].[AlertasSistemaPermisos] ([IdAlertaSistema], [IdFuncion]) VALUES (1, N'CRMNovedadesABMPENDIENTE'), (2, N'CRMNovedadesABMPENDIENTE')
    INSERT [dbo].[AlertasSistemaRoles] ([IdAlertaSistema], [IdRol]) VALUES (1, N'mblanco'), (2, N'EquipoLider')
END
GO
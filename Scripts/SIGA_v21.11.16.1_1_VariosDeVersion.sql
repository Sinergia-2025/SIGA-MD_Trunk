PRINT ''
PRINT 'A1. Facturacion V2 - Agrupa cantidades por Codigo de Producto.-'
BEGIN
    -- Inserto Registro.- --
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'FACTURACIONAGRUPACANTIDADESPRODUCTOS' AS IdParametro, 
                'False' ValorParametro, 
                'FacturacionV2' CategoriaParametro, 
                'FACTURACIONAGRUPACANTIDADESPRODUCTOS' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END

PRINT ''
PRINT 'A2. Insert Estado Cheques.-'
BEGIN
    IF not exists
    (
    SELECT *
    FROM EstadosCheques 
    WHERE IdEstadoCheque = 'ANULADO'
    )
    BEGIN
        INSERT [dbo].[EstadosCheques] ([IdEstadoCheque], [NombreEstadoCheque]) VALUES (N'ANULADO', N'ANULADO')
    END    
END

PRINT ''
PRINT 'A3. Cantidad de Dias DH Recibos.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'CTACTECANTDIASDHRECIBOS' AS IdParametro, 
                '0' ValorParametro, 
                'CantidadDiasDH' CategoriaParametro, 
                'CTACTECANTDIASDHRECIBOS' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END

PRINT ''
PRINT 'A4. Nuevo Menu: Tableros de Comando Graficos'
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT 'A41. Verifica Tablero de Comando'
    IF dbo.ExisteFuncion('TablerosDeComando') = 0
    BEGIN
	      INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
	     VALUES
	       ('TablerosDeComando', 'Tableros de Comando', 'Tableros de Comando', 
		    'True', 'False', 'True', 'True', '', 40, 'Eniac.Win', 'TablerosDeComando', null, null,
                  'True', 'S', 'N', 'N', 'N', 'True')

	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'TablerosDeComando' AS Pantalla FROM dbo.Roles
		    WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')
    END

    PRINT ''
    PRINT 'A42. Nuevo Menu: DashBoard - Graficos'
    IF dbo.ExisteFuncion('TablerosGraficos') = 0
    BEGIN
	      INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
	     VALUES
	       ('TablerosGraficos', 'Tableros Graficos', 'Tableros Graficos', 
		    'True', 'False', 'True', 'True', 'TablerosDeComando', 50, 'Eniac.Win', '', null, null,
                  'True', 'S', 'N', 'N', 'N', 'True')

	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'TablerosGraficos' AS Pantalla FROM dbo.Roles
		    WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')
    END

    PRINT ''
    PRINT 'A43. Nuevo Menu: DashBoard - Principal'
    IF dbo.ExisteFuncion('TableroComandosGraficos') = 0
    BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('TableroComandosGraficos', 'Tablero de Comandos Graficos', 'Tablero de Comandos Graficos', 'True', 'False', 'True', 'True'
            , 'TablerosGraficos', 10, 'Eniac.Win', 'DashBoardTablero', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
   
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'TableroComandosGraficos' AS Pantalla FROM dbo.Roles
	        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END

    PRINT ''
    PRINT 'A5. Nuevo Menu: DashBoard - Paneles - ABM'
    IF dbo.ExisteFuncion('ABMPanelesGraficos') = 0
    BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
        VALUES
            ('ABMPanelesGraficos', 'ABM de Paneles Graficos', 'ABM de Paneles Graficos', 'True', 'False', 'True', 'True'
            , 'TablerosGraficos', 30, 'Eniac.Win', 'DashBoardABMPaneles', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')
   
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'ABMPanelesGraficos' AS Pantalla FROM dbo.Roles
	        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
END
GO

PRINT ''
PRINT 'A5. Nuevo Parametros: DashBoard.'
BEGIN
    PRINT ''
    PRINT 'A51. Establece el Valor Multiplicador de Los Timers.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'DASHBOARDTIMERBASE' AS IdParametro, 
                    '60000' ValorParametro, 
                    'DashBoards' CategoriaParametro, 
                    'DASHBOARDTIMERBASE' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END    

    PRINT ''
    PRINT 'A52. Establece el Valor Multiplicador de los MajorGrid-MinorGrid.-'
    BEGIN
        MERGE INTO Parametros AS DEST
        USING (
                SELECT IdEmpresa, 
                    'DASHBOARDMMGRIDS' AS IdParametro, 
                    '1000000' ValorParametro, 
                    'DashBoards' CategoriaParametro, 
                    'DASHBOARDMMGRIDS' DescripcionParametro FROM Empresas) AS ORIG 
                ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
            VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
    END    
END
GO

PRINT ''
PRINT '1. Nueva Tabla DashBoardModelos.'
BEGIN
    IF not exists
    (
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'DashBoardsModelos'
    )
    BEGIN
        -- CREAR TABLA --
        CREATE TABLE [dbo].[DashBoardsModelos](
	        [IdModelo] [int] NOT NULL,
	        [Descripcion] [varchar](30) NOT NULL,
	        [Estados] [bit] NOT NULL,
	        [IDModeloDB] [int] NOT NULL,
         CONSTRAINT [PK_DashBoardsModelos] PRIMARY KEY CLUSTERED 
        (
	        [IdModelo] ASC
        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ) ON [PRIMARY]

        -- INSERTAR DATOS --
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (1, N'Puntos', 1, 0)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (2, N'Punto Rapido', 1, 1)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (3, N'Linea', 1, 3)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (4, N'Ranura', 1, 4)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (5, N'Línea de paso', 1, 5)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (6, N'Línea rápida', 1, 6)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (7, N'Barras', 1, 7)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (8, N'Barra apilada', 1, 8)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (9, N'Columna', 1, 10)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (10, N'Columna apilada', 1, 11)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (11, N'Area', 1, 13)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (12, N'Area de Ranura', 1, 14)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (13, N'Area Apilada', 1, 15)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (14, N'Torta', 1, 17)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (15, N'Rosquilla', 0, 18)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (16, N'Existencias', 0, 19)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (17, N'Candelero', 1, 20)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (18, N'Rango', 1, 21)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (19, N'Rango de Ranuras', 1, 22)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (20, N'Rango de Barras', 1, 23)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (21, N'Kagi', 0, 31)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (22, N'Embudo', 0, 33)
        INSERT [dbo].[DashBoardsModelos] ([IDModelo], [Descripcion], [Estados], [IDModeloDB]) VALUES (23, N'Piramide', 0, 34)
    END
END
GO
--*******************************************************************************
PRINT ''
PRINT '2. Nueva Tabla DashBoardsTipos.'
BEGIN
    IF not exists
    (
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'DashBoardsTipos'
    )
    BEGIN
        -- CREAR TABLA --
        CREATE TABLE [dbo].[DashBoardsTipos](
	        [IdDashTipos] [int] NOT NULL,
	        [Descripcion] [varchar](30) NOT NULL,
	        [NombreObjeto] [varchar](30) NOT NULL,
	        [Estados] [bit] NOT NULL,
	        [LocationX] [int] NULL,
	        [LocationY] [Int] NULL,
         CONSTRAINT [PK_DashBoardsTipos] PRIMARY KEY CLUSTERED 
        (
	        [IdDashTipos] ASC
        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ) ON [PRIMARY]

        -- INSERTAR DATOS --
        INSERT [dbo].[DashBoardsTipos] ([IdDashTipos], [Descripcion], [NombreObjeto], [Estados], [LocationX], [LocationY] ) 
            VALUES (1, N'Totalizador', N'ucDashTotalizador', 1, 95, 95)
        INSERT [dbo].[DashBoardsTipos] ([IdDashTipos], [Descripcion], [NombreObjeto], [Estados], [LocationX], [LocationY]) 
            VALUES (2, N'Graficador', N'ucDashGraficador', 1, 4, 15)
    END
END
GO
--*******************************************************************************
PRINT ''
PRINT '3. Nueva Tabla DashBoardsRefresh.'
BEGIN
    IF not exists
    (
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'DashBoardsRefresh'
    )
    BEGIN
        CREATE TABLE [dbo].[DashBoardsRefresh](
	        [IdDashRefresh] [int] NOT NULL,
	        [Descripcion] [varchar](30) NOT NULL,
         CONSTRAINT [PK_DashBoardsRefresh] PRIMARY KEY CLUSTERED 
        (
	        [IdDashRefresh] ASC
        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ) ON [PRIMARY]

        INSERT [dbo].[DashBoardsRefresh] ([IdDashRefresh], [Descripcion]) VALUES (1, N'Datos')
        INSERT [dbo].[DashBoardsRefresh] ([IdDashRefresh], [Descripcion]) VALUES (2, N'Full')
    END
END
GO
--*******************************************************************************
PRINT ''
PRINT '4. Nueva Tabla DashBoardsPaneles.'
BEGIN
    IF not exists
    (
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'DashBoardsPaneles'
    )
    BEGIN
        CREATE TABLE [dbo].[DashBoardsPaneles](
	        [IdDashBoard] [int] NOT NULL,
	        [Nombre] [varchar](30) NOT NULL,
	        [TipoDashBoard] [int] NOT NULL,
	        [Titulo] [varchar](50) NOT NULL,
	        [Comentario] [varchar](50) NOT NULL,
	        [SentenciaSQL] [varchar](max) NOT NULL,
	        [AutoRefresh] [bit] NOT NULL,
	        [TipoRefresh] [int] NOT NULL,
	        [TimerRefresh] [int] NOT NULL,
	        [ImagenDashBoard] [varbinary](max) NULL,
	        [ValorObjetivo] [decimal](15, 2) NULL,
	        [ValorMinimo] [decimal](15, 2) NULL,
	        [Area3DStyle] [bit] NULL,
	        [ModeloDashBoard] [int] NULL,
	        [ShowValueLabel] [bit]  NULL,
	        [AxisTitleX] [varchar](15) NULL,
	        [AxisTitleY] [varchar](15) NULL,
	        [Estado] [bit] NOT NULL,
	        [Orden] [int] NOT NULL,
         CONSTRAINT [PK_DashBoardsPaneles] PRIMARY KEY CLUSTERED 
        (
	        [IdDashBoard] ASC
        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

        ALTER TABLE [dbo].[DashBoardsPaneles]  WITH CHECK ADD  CONSTRAINT [FK_DashBoards_Tipos] FOREIGN KEY([TipoDashBoard])
        REFERENCES [dbo].[DashBoardsTipos] ([IdDashTipos])
        ALTER TABLE [dbo].[DashBoardsPaneles] CHECK CONSTRAINT [FK_DashBoards_Tipos]

        ALTER TABLE [dbo].[DashBoardsPaneles]  WITH CHECK ADD  CONSTRAINT [FK_DashBoards_Modelos] FOREIGN KEY([ModeloDashBoard])
        REFERENCES [dbo].[DashBoardsModelos] ([IdModelo])
        ALTER TABLE [dbo].[DashBoardsPaneles] CHECK CONSTRAINT [FK_DashBoards_Modelos]

        ALTER TABLE [dbo].[DashBoardsPaneles]  WITH CHECK ADD  CONSTRAINT [FK_DashBoards_Refresh] FOREIGN KEY([TipoRefresh])
        REFERENCES [dbo].[DashBoardsRefresh] ([IdDashRefresh])
        ALTER TABLE [dbo].[DashBoardsPaneles] CHECK CONSTRAINT [FK_DashBoards_Refresh]
    END
END
GO
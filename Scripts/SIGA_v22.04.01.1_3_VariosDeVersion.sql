--- TABLAS ---------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'T1. Nueva Tabla: Talle-Color - ABM de Tipos de Atributos de Productos(TiposAtributosProductos).'
BEGIN
    --- Tabla -Tipo de Atributos de Productos.- -------------------------------------------------------------------------------------------------------------------
	IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TiposAtributosProductos')
		BEGIN
			CREATE TABLE [dbo].[TiposAtributosProductos](
				[IdTipoAtributoProducto] [smallint] NOT NULL,
				[Descripcion] [varchar](50) NOT NULL
				CONSTRAINT [PK_TiposAtributosProductos] PRIMARY KEY CLUSTERED 
			(
				[IdTipoAtributoProducto] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
			) ON [PRIMARY]

		END
END
GO

PRINT ''
PRINT 'T2. Nueva Tabla: Talle-Color - ABM de Grupos de Tipos de Atributos de Productos(GruposTiposAtributosProductos).'
BEGIN
    --- Tabla -Grupo de Tipos de Atributos de Productos.- ---------------------------------------------------------------------------------------------------------
	IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GruposTiposAtributosProductos')
		BEGIN
			CREATE TABLE [dbo].[GruposTiposAtributosProductos](
				[IdGrupoTipoAtributoProducto] [int] NOT NULL,
				[IdTipoAtributoProducto] [smallint] NOT NULL,
				[Descripcion] [varchar](50) NOT NULL
				CONSTRAINT [PK_GrupoTiposAtributosProductos] PRIMARY KEY CLUSTERED 
			(
				[IdGrupoTipoAtributoProducto] ASC,
				[IdTipoAtributoProducto] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
			) ON [PRIMARY]

			ALTER TABLE GruposTiposAtributosProductos ADD CONSTRAINT FK_GruposTiposAtributos_Productos
				FOREIGN KEY (IdTipoAtributoProducto)
				REFERENCES TiposAtributosProductos (IdTipoAtributoProducto) 
				ON UPDATE  NO ACTION ON DELETE  NO ACTION 
		END
END
GO

PRINT ''
PRINT 'T3. Nueva Tabla: Talle-Color - ABM de Atributos de Productos(AtributosProductos).'
BEGIN
    --- Tabla -Grupo de Tipos de Atributos de Productos.- ---------------------------------------------------------------------------------------------------------
	IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AtributosProductos')
		BEGIN
			CREATE TABLE [dbo].[AtributosProductos](
				[IdAtributoProducto] [int] NOT NULL,
				[IdGrupoTipoAtributoProducto] [int] NOT NULL,
				[IdTipoAtributoProducto] [smallint] NOT NULL,
				[Descripcion] [varchar](50) NOT NULL,
				[Orden] [int] NOT NULL
				CONSTRAINT [PK_AtributosProductos] PRIMARY KEY CLUSTERED 
			(
				[IdAtributoProducto] ASC,
				[IdGrupoTipoAtributoProducto] ASC,
				[IdTipoAtributoProducto] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
			) ON [PRIMARY]

			ALTER TABLE AtributosProductos ADD CONSTRAINT FK_AtributosProductos_Grupo
				FOREIGN KEY (IdGrupoTipoAtributoProducto, idTipoAtributoProducto)
				REFERENCES GruposTiposAtributosProductos (IdGrupoTipoAtributoProducto, idTipoAtributoProducto) 
				ON UPDATE  NO ACTION ON DELETE  NO ACTION 
		END
END
GO
--- BUSCADORES.- --------------------------------------------------------------------------------------------------------------------- 
PRINT ''
PRINT 'B1. Nuevo Buscador: Talle-Color - ABM de Tipos de Atributos de Productos(TiposAtributosProductos).'
BEGIN
	--- Buscador - Tipos de Atributos de Productos.- ---
	DECLARE @id int = (SELECT MAX(IdBuscador) FROM Buscadores) + 1
	INSERT INTO [dbo].[Buscadores]
				([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
			VALUES
				(@id,'TiposAtributosProductos',400,'Grilla','')
	INSERT INTO [dbo].[BuscadoresCampos]
				([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
			VALUES
				(@id, 'IdTipoAtributoProducto', 1, 'Codigo', 16,  80, '', NULL, NULL, NULL),
				(@id, 'Descripcion', 2, 'Descripcion', 16, 250, '', NULL, NULL, NULL)
END
GO
PRINT ''
PRINT 'B2. Nuevo Buscador: Talle-Color - ABM de Grupos de Tipos de Atributos de Productos(GruposTiposAtributosProductos).'
BEGIN
	--- Buscador - Tipos de Atributos de Productos.- ---
	DECLARE @id int = (SELECT MAX(IdBuscador) FROM Buscadores) + 1
	INSERT INTO [dbo].[Buscadores]
				([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
			VALUES
				(@id,'GruposTiposAtributosProductos',400,'Grilla','')
	INSERT INTO [dbo].[BuscadoresCampos]
				([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
			VALUES
				(@id, 'IdGrupoTipoAtributoProducto', 1, 'Codigo Grupo', 16,  80, '', NULL, NULL, NULL),
				(@id, 'Descripcion', 2, 'Descripcion Grupo', 16, 250, '', NULL, NULL, NULL),
				(@id, 'IdTipoAtributoProducto', 3, 'Codigo Tipo', 16,  80, '', NULL, NULL, NULL),
				(@id, 'DescripcionTipo', 4, 'Descripcion Tipo', 16, 250, '', NULL, NULL, NULL)
END
GO
--- PARAMETROS.- --------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'P1. Nuevo Parametro : Talle-Color - Parametro TiposAtributosProductos - 01.'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'TIPOATRIBUTOPRODUCTO01'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Parametro Tipo de Atributo Producto 01'
	DECLARE @valorParametro VARCHAR(MAX) = '0'

	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT 'P2. Nuevo Parametro : Talle-Color - Parametro TiposAtributosProductos - 02.'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'TIPOATRIBUTOPRODUCTO02'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Parametro Tipo de Atributo Producto 02'
	DECLARE @valorParametro VARCHAR(MAX) = '0'

	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT 'P3. Nuevo Parametro : Talle-Color - Parametro TiposAtributosProductos - 03.'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'TIPOATRIBUTOPRODUCTO03'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Parametro Tipo de Atributo Producto 03'
	DECLARE @valorParametro VARCHAR(MAX) = '0'

	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO

PRINT ''
PRINT 'P4. Nuevo Parametro : Talle-Color - Parametro TiposAtributosProductos - 04.'
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'TIPOATRIBUTOPRODUCTO04'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Parametro Tipo de Atributo Producto 04'
	DECLARE @valorParametro VARCHAR(MAX) = '0'

	MERGE INTO Parametros AS DEST
			USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
		WHEN MATCHED THEN
			UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
		WHEN NOT MATCHED THEN 
			INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);
END
GO
--- FUNCIONES.- ---------------------------------------------------------------------------------------------------------------------
IF dbo.BaseConCuit('30716846918') = 1 OR dbo.SoyHAR() = 1
    --- Funcion -Tipo de Atributos de Productos.- -----------------------------------------------------------------------------------
	PRINT ''
	PRINT 'F1. Nuevo Menu: Talle-Color - ABM de Tipos de Atributos de Productos.'
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('ABMTiposAtributosProductos', 'ABM de Tipos de Atributos de Productos', 'ABM de Tipos de Atributos de Productos', 'True', 'False', 'True', 'True'
			, 'Stock', 170, 'Eniac.Win', 'TiposAtributosProductosABM', NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ABMTiposAtributosProductos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
	---------------------------------------------------------------------------------------------------------------------------------
	PRINT ''
	PRINT 'F2. Nuevo Menu: Talle-Color - ABM de Grupos de Tipos de Atributos de Productos.'
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('GruposTiposAtributosProductos', 'ABM de Grupos de Tipos de Atributos de Productos', 'ABM de Grupos de Tipos de Atributos de Productos', 'True', 'False', 'True', 'True'
			, 'Stock', 160, 'Eniac.Win', 'GruposTiposAtributosProductosABM', NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'GruposTiposAtributosProductos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
	---------------------------------------------------------------------------------------------------------------------------------
	PRINT ''
	PRINT 'F3. Nuevo Menu: Talle-Color - ABM de Atributos de Productos.'
	BEGIN
		INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
		VALUES
			('ABMAtributosProductos', 'ABM de Atributos de Productos', 'ABM de Atributos de Productos', 'True', 'False', 'True', 'True'
			, 'Stock', 150, 'Eniac.Win', 'AtributosProductosABM', NULL, NULL
			,'True', 'S', 'N', 'N', 'N', 'True')
   
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ABMAtributosProductos' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
	END
GO
--- CAMPOS.- ------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT 'C1. Nuevos Campos Tabla SubRubros : Talle-Color - GrupoAtributos - 01-04.'
BEGIN
	ALTER TABLE SubRubros ADD GrupoAtributo01 Integer NULL
	ALTER TABLE SubRubros ADD TipoAtributo01 SmallInt NULL
	ALTER TABLE SubRubros ADD GrupoAtributo02 Integer NULL
	ALTER TABLE SubRubros ADD TipoAtributo02 SmallInt NULL
	ALTER TABLE SubRubros ADD GrupoAtributo03 Integer NULL
	ALTER TABLE SubRubros ADD TipoAtributo03 SmallInt NULL
	ALTER TABLE SubRubros ADD GrupoAtributo04 Integer NULL
	ALTER TABLE SubRubros ADD TipoAtributo04 SmallInt NULL
END
GO

------------------------------------------------------------------------------------------------------------------------------------
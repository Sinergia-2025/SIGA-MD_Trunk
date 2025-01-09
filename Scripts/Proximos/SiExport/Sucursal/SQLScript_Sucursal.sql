USE [master]

PRINT ''
PRINT '01. Base Datos SiExport: Creacion de Usuario de base de Datos'
IF NOT EXISTS(SELECT * FROM sys.server_principals WHERE name = N'Eniac')
BEGIN
	CREATE LOGIN [Eniac] WITH PASSWORD='Eniac2010', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[Español], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
	EXEC sys.sp_addsrvrolemember @loginame = N'Eniac', @rolename = N'sysadmin'
	ALTER LOGIN [Eniac] ENABLE
END
GO

PRINT ''
PRINT '02. Base Datos SiExport: Creacion de base de Datos SiExport'
IF NOT EXISTS(SELECT * FROM DBO.SYSDATABASES WHERE NAME = 'SiExport')
BEGIN
	CREATE DATABASE SiExport
END
GO

USE [SiExport]

PRINT ''
PRINT '03. Base Datos SiExport: Creacion de Tabla Cartuchos'
IF NOT EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Cartuchos')
BEGIN
	CREATE TABLE Cartuchos(
		IdCartucho			int  NOT NULL,
		NombreCartucho		varchar(30) NOT NULL,
		Orden				int NOT NULL,
		NombreAssembly		varchar(150) NOT NULL,
		NombreClase			varchar(150) NOT NULL,
		ConnectionString	varchar(max) NULL,
		URLEnvio			varchar(max) NULL,
		IdEmpresa			int NULL,
		IdSucursal			int NULL,
		UsuarioAPI			varchar(50) NULL,
		PwdAPI				varchar(150) NULL,
		Activo				bit NOT NULL,
	 CONSTRAINT PK_Cartuchos PRIMARY KEY CLUSTERED 
		(IdCartucho ASC)
	 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
		   IGNORE_DUP_KEY = OFF, 
		   ALLOW_ROW_LOCKS = ON, 
		   ALLOW_PAGE_LOCKS = ON, 
		   OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) 
	 ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

PRINT ''
PRINT '04. Base Datos SiExport: Inserta Valores en la Tabla de Cartuchos'
IF EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Cartuchos')
BEGIN
	INSERT Cartuchos ([IdCartucho], [NombreCartucho], [Orden], [NombreAssembly], 
					  [NombreClase], [ConnectionString], [URLEnvio], [IdEmpresa], 
					  [IdSucursal], [UsuarioAPI], [PwdAPI], [Activo]) 
		VALUES (1, 'Clientes', 1, 'SiExport.Plugin.Bruler.dll', 'SiExport.Plugin.Bruler.ProcesoC', 'server=SINERGIA-NB-09\SQLEXPRESS01; database=Bruler; User Id=Eniac; Password=Eniac2010; trustServerCertificate=true;', 'https://localhost:44330/', 1, 1, 'sucursal01', 'marrero01', 1),
			   (2, 'Ventas', 2, 'SiExport.Plugin.Bruler.dll', 'SiExport.Plugin.Bruler.ProcesoV', 'server=SINERGIA-NB-09\SQLEXPRESS01; database=Bruler; User Id=Eniac; Password=Eniac2010; trustServerCertificate=true;', 'https://localhost:44330/', 1, 1, 'sucursal01', 'marrero01', 1)

END
GO

PRINT ''
PRINT '05. Base Datos SiExport: Creacion de Tabla Ejecuciones'
IF NOT EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Ejecuciones')
BEGIN
	CREATE TABLE Ejecuciones(
		IdCartucho		int  NOT NULL,
		IdEjecucion		bigint NOT NULL,
		FechaHora		datetime NOT NULL,
	 CONSTRAINT PK_Ejecuciones PRIMARY KEY CLUSTERED 
		(IdCartucho ASC, IdEjecucion ASC)
	  WITH (PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON, 
			OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY])
	 ON [PRIMARY]
END
GO

PRINT ''
PRINT '06. Base Datos SiExport: Creacion de Tabla Mapeos'
IF NOT EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Mapeos')
BEGIN
	CREATE TABLE Mapeos(
		IdCartucho		int NOT NULL,
		SIGA_Tabla		varchar(100) NOT NULL,
		SIGA_Campo		varchar(100) NOT NULL,
		Cartucho_Valor	varchar(100) NOT NULL,
		SIGA_Valor		varchar(100) NOT NULL,
	 CONSTRAINT [PK_Mapeos] PRIMARY KEY CLUSTERED 
		(IdCartucho ASC,
		 SIGA_Tabla ASC,
		 SIGA_Campo ASC,
		 Cartucho_Valor ASC)
		WITH (PAD_INDEX = OFF, 
			  STATISTICS_NORECOMPUTE = OFF, 
			  IGNORE_DUP_KEY = OFF, 
			  ALLOW_ROW_LOCKS = ON, 
			  ALLOW_PAGE_LOCKS = ON, 
			  OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) 
		ON [PRIMARY]
	-- Crea Clave Foranea a Cartuchos.- ---------------------------
    ALTER TABLE Mapeos WITH CHECK 
		ADD CONSTRAINT FK_Mapeos_Cartuchos FOREIGN KEY(IdCartucho)
        REFERENCES Cartuchos (IdCartucho)
    ALTER TABLE Mapeos CHECK CONSTRAINT FK_Mapeos_Cartuchos
END
GO

PRINT ''
PRINT '07. Base Datos SiExport: Inserta Valores en la Tabla Mapeos'
IF EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Mapeos')
BEGIN
	INSERT Mapeos (IdCartucho, SIGA_Tabla, SIGA_Campo, Cartucho_Valor, SIGA_Valor) 
		VALUES (1, 'Clientes', 'CodigoClienteLetras','NA', ''),
			   (1, 'Clientes', 'IdCalle', 'NA', '1'),
			   (1, 'Clientes', 'IdCalle2', 'NA', '1'),
			   (1, 'Clientes', 'IdCategoria', 'NA', '1'),
			   (1, 'Clientes', 'IdCategoriaFiscal', 'B', '3'),
			   (1, 'Clientes', 'IdCategoriaFiscal', 'E', '4'),
			   (1, 'Clientes', 'IdCategoriaFiscal', 'F', '1'),
			   (1, 'Clientes', 'IdCategoriaFiscal', 'I', '2'),
			   (1, 'Clientes', 'IdCobrador', 'NA', '1'),
			   (1, 'Clientes', 'IdDadoAltaPor', 'NA', '1'),
			   (1, 'Clientes', 'IdEstadoCliente', 'NA', '1'),
			   (1, 'Clientes', 'IdListaPrecios', 'NA', '1'),
			   (1, 'Clientes', 'IdLocalidad', 'NA', '2000'),
			   (1, 'Clientes', 'IdTipoCliente', 'NA', '1'),
			   (1, 'Clientes', 'IdVendedor', 'NA', '1'),
			   (1, 'Clientes', 'IdZonaGeografica', 'NA', 'General'),
			   (1, 'Clientes', 'MonedaCredito', 'NA', '1'),
			   (1, 'Clientes', 'Sexo', 'NA', 'NoAplica')
END
GO

PRINT ''
PRINT '08. Base Datos SiExport: Creacion de Tabla Parametros'
IF NOT EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Parametros')
BEGIN
	CREATE TABLE Parametros(
		IdParametro		varchar(100) NOT NULL,
		ValorParametro	varchar(200) NULL,
	 CONSTRAINT PK_Parametros PRIMARY KEY CLUSTERED 
		(IdParametro ASC)
	 WITH (PAD_INDEX = OFF, 
		   STATISTICS_NORECOMPUTE = OFF, 
		   IGNORE_DUP_KEY = OFF, 
		   ALLOW_ROW_LOCKS = ON, 
		   ALLOW_PAGE_LOCKS = ON, 
		   OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) 
		ON [PRIMARY]
END
GO

PRINT ''
PRINT '09. Base Datos SiExport: Inserta Valores en la Tabla Parametros'
IF EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Parametros')
BEGIN
	INSERT Parametros (IdParametro, ValorParametro) 
		VALUES ('APIAuthenticate', 'api/v1/usuarios/authenticate'),
			   ('APIBrulerClientesEliminarTodoEmpresaSucursal', 'api/v1/Bruler/Clientes/EliminarTodoEmpresaSucursal'),
			   ('APIBrulerClientesGetPorEmpresaSucursal', 'api/v1/Bruler/Clientes/GetPorEmpresaSucursal'),
			   ('APIBrulerCLientesInsertarVarios', 'api/v1/Bruler/Clientes/InsertarVarios'),
			   ('APIEjecucionesFinalizar', 'api/v1/ejecuciones/finalizar'),
			   ('APIEjecucionesIniciar', 'api/v1/ejecuciones/iniciar'),
			   ('IntervaloEnvioAWeb', '100')
END
GO

PRINT ''
PRINT '10. Base Datos SiExport: Creacion de Tabla Clientes'
IF NOT EXISTS(SELECT * FROM sysobjects WHERE type = 'U' AND name = 'WClientes')
BEGIN
	CREATE TABLE WClientes(
		IdEmpresa					int NULL,
		IdSucursal					int NULL,
		IdEjecucion					bigint NOT NULL,
		EstadoEjec					varchar(50) NOT NULL,
		CodigoCliente				bigint NOT NULL,
		NombreCliente				varchar(100) NULL,
		Contacto					varchar(100) NULL,
		Direccion					varchar(100) NULL,
		Telefono					varchar(100) NULL,
		CorreoElectronico			varchar(500) NULL,
		IdCategoriaFiscal_Origen	varchar(100) NULL,
		IdCategoriaFiscal			smallint NULL,
		Cuit_Origen					varchar(100) NULL,
		Cuit						varchar(13) NULL,
		FechaNacimiento				datetime NULL,
		Observacion					varchar(1000) NULL,
		Activo						bit NULL,
		IdLocalidad_Origen			varchar(100) NULL,
		IdLocalidad					int NULL,
		IdZonaGeografica			varchar(20) NULL,
		FechaAlta					datetime NULL,
		IdCategoria					int NULL,
		IdListaPrecios				int NULL,
		LimiteDeCredito				decimal(16, 2) NULL,
		IdCliente					bigint NULL,
		IdCobrador					int NULL,
		IdTipoCliente				int NULL,
		FechaBaja					datetime NULL,
		Sexo						varchar(10) NULL,
		IdEstadoCliente				int NULL,
		IdVendedor					int NULL,
		IdDadoAltaPor				int NULL,
		CodigoClienteLetras			varchar(50) NULL,
		IdCalle						int NULL,
		IdCalle2					int NULL,
		MonedaCredito				int NULL
		) ON [PRIMARY]
END
GO

PRINT ''
PRINT '11. Base Datos SiExport: Asignacion de Usuario a SiExport'
IF EXISTS(SELECT * FROM sys.server_principals WHERE name = N'Eniac')
BEGIN
	USE [SiExport]
	CREATE USER [Eniac] FOR LOGIN [Eniac] WITH DEFAULT_SCHEMA=[dbo]
	ALTER ROLE [db_owner] ADD MEMBER [Eniac]
	ALTER ROLE [db_datareader] ADD MEMBER [Eniac]
	ALTER ROLE [db_datawriter] ADD MEMBER [Eniac]
END
GO

PRINT ''
PRINT '12. Base Datos SiExport: Asignacion de Usuario a Bruler'
IF EXISTS(SELECT * FROM sys.server_principals WHERE name = N'Eniac')
BEGIN
	USE [Bruler]
	CREATE USER [Eniac] FOR LOGIN [Eniac] WITH DEFAULT_SCHEMA=[dbo]
	ALTER ROLE [db_owner] ADD MEMBER [Eniac]
	ALTER ROLE [db_datareader] ADD MEMBER [Eniac]
	ALTER ROLE [db_datawriter] ADD MEMBER [Eniac]
END
GO

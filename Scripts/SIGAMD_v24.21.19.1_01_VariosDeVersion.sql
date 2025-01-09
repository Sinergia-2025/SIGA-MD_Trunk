------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '0. Nueva Tabla SiExport Clientes'
IF dbo.ExisteTabla('WClientes') = 0 
BEGIN
	CREATE TABLE [dbo].[WClientes](
		[IdEmpresa] [int] NULL,
		[IdSucursal] [int] NULL,
		[IdEjecucion] [bigint] NOT NULL,
		[EstadoEjec] [varchar](50) NOT NULL,
		[CodigoCliente] [bigint] NOT NULL,
		[NombreCliente] [varchar](100) NULL,
		[Contacto] [varchar](100) NULL,
		[Direccion] [varchar](100) NULL,
		[Telefono] [varchar](100) NULL,
		[CorreoElectronico] [varchar](500) NULL,
		[IdCategoriaFiscal_Origen] [varchar](100) NULL,
		[IdCategoriaFiscal] [smallint] NULL,
		[Cuit_Origen] [varchar](100) NULL,
		[Cuit] [varchar](13) NULL,
		[FechaNacimiento] [datetime] NULL,
		[Observacion] [varchar](1000) NULL,
		[Activo] [bit] NULL,
		[IdLocalidad_Origen] [varchar](100) NULL,
		[IdLocalidad] [int] NULL,
		[IdZonaGeografica] [varchar](20) NULL,
		[FechaAlta] [datetime] NULL,
		[IdCategoria] [int] NULL,
		[IdListaPrecios] [int] NULL,
		[LimiteDeCredito] [decimal](16, 2) NULL,
		[IdCliente] [bigint] NULL,
		[IdCobrador] [int] NULL,
		[IdTipoCliente] [int] NULL,
		[FechaBaja] [datetime] NULL,
		[Sexo] [varchar](10) NULL,
		[IdEstadoCliente] [int] NULL,
		[IdVendedor] [int] NULL,
		[IdDadoAltaPor] [int] NULL,
		[CodigoClienteLetras] [varchar](50) NULL,
		[IdCalle] [int] NULL,
		[IdCalle2] [int] NULL,
		[MonedaCredito] [int] NULL
	) ON [PRIMARY]
END
GO
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Nuevo Menu Importador Web SiExport'
IF dbo.ExisteFuncion('Procesos') = 1 AND dbo.SoyHAR() = 1 AND dbo.ExisteFuncion('ImportarWebSiExport') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('ImportarWebSiExport', 'Importador Web SiExport', 'Importador Web SiExport', 'True', 'False', 'True', 'True'
        , 'Procesos', 100, 'Eniac.Win', 'ImportarWebSiExport', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarWebSiExport' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
------------------------------------------------------------------------------------------------------------------------


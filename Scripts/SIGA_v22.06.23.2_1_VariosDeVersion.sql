PRINT ''
PRINT '1. Nueva Funcion: AjusteMasivoDeStockAtributos'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AjusteMasivoDeStockAtributos', 'Ajuste Masivo de Stock con Atributos', 'Ajuste Masivo de Stock con Atributos', 'True', 'False', 'True', 'True'
        ,'Stock', 47, 'Eniac.Win', 'AjusteMasivoDeStockAtributos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AjusteMasivoDeStockAtributos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '2. Nuevo Registro: TablerosControlPaneles'
INSERT INTO [dbo].[TablerosControlPaneles]
           ([IdTableroControlPanel],[NombrePanel],[Parametros],[IdController])
    VALUES (107, 'Total de equipos reparados', '', 'Eniac.Win.GrillaCRMTotalEquiposReparados')
GO

PRINT ''
PRINT '3. Nueva Funcion: EstadosVehiculosABM'
IF dbo.ExisteFuncion('Archivos') = 1 AND dbo.ExisteFuncion('ABMVehiculos') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('EstadosVehiculosABM', 'Estados Vehiculos', 'Estados Vehiculos', 'True', 'False', 'True', 'True'
        ,'Archivos', 34, 'Eniac.Win', 'EstadosVehiculosABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'EstadosVehiculosABM' FROM RolesFunciones WHERE IdFuncion = 'ABMVehiculos'
END

PRINT ''
PRINT '4. Nueva Tabla: EstadosVehiculos'
CREATE TABLE [dbo].[EstadosVehiculos](
	[IdEstadoVehiculo] [int] NOT NULL,
	[NombreEstadoVehiculo] [varchar](30) NOT NULL,
	[EnStock] [bit] NOT NULL,
	[SolicitaFecha] [bit] NOT NULL,
	[IdEstadoVehiculoLuegoVencer] [int] NULL,
 CONSTRAINT [PK_EstadosVehiculos] PRIMARY KEY CLUSTERED 
(
	[IdEstadoVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EstadosVehiculos]  WITH CHECK ADD  CONSTRAINT [FK_EstadosVehiculos_EstadosVehiculos] FOREIGN KEY([IdEstadoVehiculoLuegoVencer])
REFERENCES [dbo].[EstadosVehiculos] ([IdEstadoVehiculo])
GO

ALTER TABLE [dbo].[EstadosVehiculos] CHECK CONSTRAINT [FK_EstadosVehiculos_EstadosVehiculos]
GO

IF dbo.BaseConCUIT('30701513890') = 0
BEGIN
    INSERT INTO [dbo].[EstadosVehiculos] ([IdEstadoVehiculo], [NombreEstadoVehiculo], [EnStock], [SolicitaFecha], [IdEstadoVehiculoLuegoVencer])
         VALUES (1, 'General', 'True', 'False', NULL)
END
ELSE
BEGIN
    INSERT INTO [dbo].[EstadosVehiculos] ([IdEstadoVehiculo], [NombreEstadoVehiculo], [EnStock], [SolicitaFecha], [IdEstadoVehiculoLuegoVencer])
         VALUES (1, 'En Stock',  'True',  'False', NULL),
                (2, 'Reservado', 'True',  'True',  1),
                (3, 'Vendido',   'False', 'False', NULL)
END
GO

PRINT ''
PRINT '5. Nuevo Parametro: EXPENSASREGISTRACOMPRASPOR'
DECLARE @idParametro VARCHAR(MAX) = 'EXPENSASREGISTRACOMPRASPOR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'ExpensasRegistraComprasPor'
DECLARE @valorParametro VARCHAR(MAX) = 'NoAplica'
IF dbo.BaseConCuit('30714986992') = 1
    SET @valorParametro = 'AreaComun'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro;
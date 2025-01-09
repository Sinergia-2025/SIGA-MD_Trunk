PRINT ''
PRINT '1. Nueva Tabla CalidadEstadosListasControl'
CREATE TABLE [dbo].[CalidadEstadosListasControl](
	[IdEstadoCalidad] [int] NOT NULL,
	[NombreEstadoCalidad] [varchar](20) NOT NULL,
	[Posicion] [int] NOT NULL,
	[Finalizado] [bit] NOT NULL,
	[PorDefecto] [bit] NOT NULL,
	[Color] [int] NULL,
 CONSTRAINT [PK_CalidadEstadosListasControl] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CalidadEstadosListasControl] ADD  CONSTRAINT [DF_CalidadEstadosListasControl_PorDefecto]  DEFAULT ((0)) FOR [PorDefecto]
GO

PRINT ''
PRINT '2. Menu Estados de Listas de Control'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '2.1. Menu Estados de Listas de Control: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('EstadosListasControlABM', 'Estados de Listas de Control', 'Estados de Listas de Control', 'True', 'False', 'True', 'True'
             ,'Calidad', 45, 'Eniac.Win', 'EstadosListasControlABM', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '2.2. Menu Plantillas de Listas de Control: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'EstadosListasControlABM' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

END;

PRINT ''
PRINT '1. Tabla CalidadEstadosListasControl: Carga inicial de tabla'
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (1, N'PENDIENTE',  1, 'False', 'True',  -6422602)
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (2, N'EN PROCESO', 2, 'False', 'False', -92)
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (3, N'CALIDAD',    3, 'False', 'False', -16744193)
INSERT [dbo].[CalidadEstadosListasControl] ([IdEstadoCalidad], [NombreEstadoCalidad], [Posicion], [Finalizado], [PorDefecto], [Color]) VALUES (4, N'TERMINADO',  4, 'True',  'False', -34439)
GO

PRINT ''
PRINT '2. Tabla CalidadListasControlProductos: Agregar nuevo campo IdEstadoCalidad'
ALTER TABLE CalidadListasControlProductos ADD IdEstadoCalidad INT NULL
GO

PRINT ''
PRINT '2.1. Tabla CalidadListasControlProductos: Valores por defecto para IdEstadoCalidad'
UPDATE CalidadListasControlProductos SET IdEstadoCalidad = (SELECT TOP 1 IdEstadoCalidad FROM CalidadEstadosListasControl WHERE PorDefecto = 'True')
GO

PRINT ''
PRINT '2.2. Tabla CalidadListasControlProductos: NOT NULL para IdEstadoCalidad'
ALTER TABLE CalidadListasControlProductos ALTER COLUMN IdEstadoCalidad INT NOT NULL
GO

PRINT ''
PRINT '3. Tabla AuditoriaCalidadListasControlProductos: Agregar nuevo campo IdEstadoCalidad'
ALTER TABLE AuditoriaCalidadListasControlProductos ADD IdEstadoCalidad INT NULL
GO

PRINT ''
PRINT '4. Tabla Transportistas: Agrego Campo Activo'
ALTER TABLE dbo.Transportistas ADD Activo bit null;
GO

PRINT ''
PRINT '4.1. Tabla Transportistas: Valores por defecto para Activo'
UPDATE dbo.Transportistas SET Activo  = 1;

PRINT ''
PRINT '4.2. Tabla Transportistas: NOT NULL Activo'
ALTER TABLE dbo.Transportistas ALTER COLUMN Activo bit NOT NULL
GO
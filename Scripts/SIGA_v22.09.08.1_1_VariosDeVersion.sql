PRINT ''
PRINT '1. Tabla Nueva de Consecionario Operaciones.-'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME = 'ConcesionarioOperacionesCheques')
BEGIN
	CREATE TABLE [dbo].[ConcesionarioOperacionesCheques](
		[IdMarca] [int] NOT NULL,
		[AnioOperacion] [int] NOT NULL,
		[NumeroOperacion] [int] NOT NULL,
		[SecuenciaOperacion] [int] NOT NULL,
		[IdCheque] [bigint] NOT NULL,
	 CONSTRAINT [PK_ConcesionarioOperacionesCheques] PRIMARY KEY CLUSTERED 
	(
		[IdMarca] ASC,
		[AnioOperacion] ASC,
		[NumeroOperacion] ASC,
		[SecuenciaOperacion] ASC,
		[IdCheque] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[ConcesionarioOperacionesCheques]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesCheques_Cheques] FOREIGN KEY([IdCheque])
	REFERENCES [dbo].[Cheques] ([IdCheque])

	ALTER TABLE [dbo].[ConcesionarioOperacionesCheques] CHECK CONSTRAINT [FK_ConcesionarioOperacionesCheques_Cheques]

	ALTER TABLE [dbo].[ConcesionarioOperacionesCheques]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesCheques_ConcesionarioOperaciones] FOREIGN KEY([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])
	REFERENCES [dbo].[ConcesionarioOperaciones] ([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])

	ALTER TABLE [dbo].[ConcesionarioOperacionesCheques] CHECK CONSTRAINT [FK_ConcesionarioOperacionesCheques_ConcesionarioOperaciones]
END
GO
------------------------------------------------------------------------------------------------------------------------------------
ALTER TABLE dbo.ConcesionarioTiposUnidades ADD MuestraEnCeroKm bit NULL
ALTER TABLE dbo.ConcesionarioTiposUnidades ADD MuestraEnUsado  bit NULL
GO

UPDATE ConcesionarioTiposUnidades
   SET MuestraEnCeroKm  = 'True'
     , MuestraEnUsado   = 'True'

ALTER TABLE dbo.ConcesionarioTiposUnidades ALTER COLUMN MuestraEnCeroKm bit NOT NULL
ALTER TABLE dbo.ConcesionarioTiposUnidades ALTER COLUMN MuestraEnUsado  bit NOT NULL

DECLARE @max INT = ISNULL((SELECT MAX(IdTipoUnidad) + 1 FROM ConcesionarioTiposUnidades), 1)
INSERT INTO [dbo].[ConcesionarioTiposUnidades]
        ([IdTipoUnidad],[NombreTipoUnidad],[DescripcionTipoUnidad],[MuestraEnCeroKm],[MuestraEnUsado])
 VALUES (@max, 'VEHICULO', '', 'False', 'True')
GO
---------------------------------------------------------------------------------------------------------
ALTER TABLE dbo.Vehiculos ADD IdTipoUnidad  int         NULL
ALTER TABLE dbo.Vehiculos ADD SubTipoUnidad varchar(50) NULL
GO

DECLARE @id INT = (SELECT MAX(IdTipoUnidad) FROM ConcesionarioTiposUnidades WHERE NombreTipoUnidad = 'VEHICULO')

UPDATE Vehiculos
   SET IdTipoUnidad  = @id
     , SubTipoUnidad = '';

ALTER TABLE dbo.Vehiculos ALTER COLUMN IdTipoUnidad  int         NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN SubTipoUnidad varchar(50) NOT NULL
GO

ALTER TABLE dbo.Vehiculos ADD CONSTRAINT FK_Vehiculos_ConcesionarioTiposUnidades 
    FOREIGN KEY (IdTipoUnidad)
    REFERENCES dbo.ConcesionarioTiposUnidades (IdTipoUnidad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
------------------------------------------------------------------------------------------------------------
ALTER TABLE dbo.Vehiculos ADD AnioPatentamiento int NULL
ALTER TABLE dbo.Vehiculos ADD MedidasVehiculo varchar(50) NULL
ALTER TABLE dbo.Vehiculos ADD LlantasVehiculo varchar(50) NULL
ALTER TABLE dbo.Vehiculos ADD AuxilioVehiculo varchar(50) NULL
ALTER TABLE dbo.Vehiculos ADD NeumaticosVehiculo varchar(50) NULL
ALTER TABLE dbo.Vehiculos ADD OtrosVehiculo varchar(50) NULL
ALTER TABLE dbo.Vehiculos ADD IdentificacionVehiculo varchar(50) NULL
ALTER TABLE dbo.Vehiculos ADD ObservacionesVehiculo varchar(50) NULL
GO

UPDATE Vehiculos
   SET AnioPatentamiento        = 0
     , MedidasVehiculo          = ''
     , LlantasVehiculo          = 'NA'
     , AuxilioVehiculo          = 'NO'
     , NeumaticosVehiculo       = ''
     , OtrosVehiculo            = ''
     , IdentificacionVehiculo   = 'NO'
     , ObservacionesVehiculo    = ''
;

ALTER TABLE dbo.Vehiculos ALTER COLUMN AnioPatentamiento int                NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN MedidasVehiculo varchar(50)          NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN LlantasVehiculo varchar(50)          NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN AuxilioVehiculo varchar(50)          NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN NeumaticosVehiculo varchar(50)       NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN OtrosVehiculo varchar(50)            NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN IdentificacionVehiculo varchar(50)   NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN ObservacionesVehiculo varchar(50)    NOT NULL
------------------------------------------------------------------------------------------------------------
ALTER TABLE dbo.Vehiculos ADD IdEstadoVehiculo int NULL
GO
UPDATE Vehiculos SET IdEstadoVehiculo = 1
ALTER TABLE dbo.Vehiculos ALTER COLUMN IdEstadoVehiculo int NOT NULL
GO
ALTER TABLE dbo.Vehiculos ADD CONSTRAINT FK_Vehiculos_EstadosVehiculos
    FOREIGN KEY (IdEstadoVehiculo)
    REFERENCES dbo.EstadosVehiculos (IdEstadoVehiculo)
    ON UPDATE  NO ACTION  ON DELETE  NO ACTION 
------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[ConcesionarioOperacionesVehiculosPagos](
	[IdMarca] [int] NOT NULL,
	[AnioOperacion] [int] NOT NULL,
	[NumeroOperacion] [int] NOT NULL,
	[SecuenciaOperacion] [int] NOT NULL,
	[PatenteVehiculo] [varchar](8) NOT NULL,
 CONSTRAINT [PK_ConcesionarioOperacionesVehiculosPagos] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC,
	[AnioOperacion] ASC,
	[NumeroOperacion] ASC,
	[SecuenciaOperacion] ASC,
	[PatenteVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConcesionarioOperacionesVehiculosPagos]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesVehiculosPagos_ConcesionarioOperaciones] FOREIGN KEY([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])
REFERENCES [dbo].[ConcesionarioOperaciones] ([IdMarca], [AnioOperacion], [NumeroOperacion], [SecuenciaOperacion])
GO

ALTER TABLE [dbo].[ConcesionarioOperacionesVehiculosPagos] CHECK CONSTRAINT [FK_ConcesionarioOperacionesVehiculosPagos_ConcesionarioOperaciones]
GO

ALTER TABLE [dbo].[ConcesionarioOperacionesVehiculosPagos]  WITH CHECK ADD  CONSTRAINT [FK_ConcesionarioOperacionesVehiculosPagos_Vehiculos] FOREIGN KEY([PatenteVehiculo])
REFERENCES [dbo].[Vehiculos] ([PatenteVehiculo])
GO

ALTER TABLE [dbo].[ConcesionarioOperacionesVehiculosPagos] CHECK CONSTRAINT [FK_ConcesionarioOperacionesVehiculosPagos_Vehiculos]
GO
------------------------------------------------------------------------------------------------------------
ALTER TABLE dbo.Vehiculos ADD PrecioCompra decimal(18, 2) NULL
ALTER TABLE dbo.Vehiculos ADD PrecioReferencia decimal(18, 2) NULL
ALTER TABLE dbo.Vehiculos ADD IdProductoReferencia varchar(15) NULL
ALTER TABLE dbo.Vehiculos ADD PrecioLista decimal(18, 2) NULL
GO

UPDATE Vehiculos SET PrecioCompra = 0, PrecioReferencia = 0, PrecioLista = 0;

ALTER TABLE dbo.Vehiculos ALTER COLUMN PrecioCompra decimal(18, 2)      NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN PrecioReferencia decimal(18, 2)  NOT NULL
ALTER TABLE dbo.Vehiculos ALTER COLUMN PrecioLista decimal(18, 2)       NOT NULL

ALTER TABLE dbo.Vehiculos ADD CONSTRAINT FK_Vehiculos_Productos_Referencia 
    FOREIGN KEY (IdProductoReferencia)
    REFERENCES dbo.Productos (IdProducto) 
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
------------------------------------------------------------------------------------------------------------
INSERT INTO Buscadores 
        (IdBuscador, Titulo,   AnchoAyuda, IniciaConFocoEn, ColumaBusquedaInicial)
 VALUES (40,         'Bancos', 400,        'Grilla',        '')
INSERT INTO BuscadoresCampos
        (IdBuscador, IdBuscadorNombreCampo, Orden, Titulo,   Alineacion, Ancho, Formato, Condicion, Valor, ColorFila)
 VALUES (30        , 'IdBanco',             1,     'Código', 64,         70   , '',      NULL,      NULL,  NULL),
        (30        , 'NombreBanco',         2,     'Banco',  16,         230  , '',      NULL,      NULL,  NULL)
GO
------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Renombra Función: InfRetirosEntregasADomicilio'
IF dbo.ExisteFuncion('InfRetirosEntregasADomicilio') = 1
BEGIN
UPDATE Funciones SET Nombre = 'Informe de Retiros Y Entregas a Domicilio', Descripcion = 'Informe de Retiros Y Entregas a Domicilio'
WHERE id = 'InfRetirosEntregasADomicilio'
END
------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '1. Actualización de registros pre-existentes'
UPDATE C SET C.HorarioClienteCompleto = 
	ISNULL((CASE WHEN C.HoraInicio <> '00:00' AND C.HoraInicio <> '' THEN 'Lun A Vie:' + C.HoraInicio + ' a ' +
			 (CASE WHEN C.HorarioCorrido = 1 THEN C.HoraFin2 ELSE C.HoraFin END) +
			 (CASE WHEN C.HoraInicio2 <> '00:00' AND C.HoraInicio2 <> '' THEN ' Y ' + C.HoraInicio2 + ' a ' + C.HoraFin2 ELSE '' END) ELSE '' END), '') +
	
	-- Sabados
	ISNULL((CASE WHEN C.HoraSabInicio <> '00:00' AND C.HoraSabInicio <> '' THEN ' - Sab:' + C.HoraSabInicio + ' a ' +
			 (CASE WHEN C.HorarioCorridoSab = 1 THEN C.HoraSabFin2 ELSE C.HoraSabFin END) +
			 (CASE WHEN C.HoraSabInicio2 <> '00:00' AND C.HoraSabInicio2 <> '' THEN ' Y ' + C.HoraSabInicio2 + ' a ' + C.HoraSabFin2 ELSE ''END) ELSE '' END), '') +
	
	-- Domingos
	ISNULL((CASE WHEN C.HoraDomInicio <> '00:00' AND C.HoraDomInicio <> '' THEN ' - Dom:' + C.HoraDomInicio + ' a ' +
			 (CASE WHEN C.HorarioCorridoDom = 1 THEN C.HoraDomFin2 ELSE C.HoraDomFin END) +
			 (CASE WHEN C.HoraDomInicio2 <> '00:00' AND C.HoraDomInicio2 <> '' THEN ' Y ' + C.HoraDomInicio2 + ' a ' + C.HoraDomFin2 ELSE ''END) ELSE '' END), '') FROM Clientes C 
GO

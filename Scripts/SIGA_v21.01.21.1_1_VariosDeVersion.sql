/****** Object:  Table [dbo].[CRMTiposNovedadesObjetivos]    Script Date: 19/01/2021 16:35:28 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO

PRINT ''
PRINT '1. Se agrega el campo IdEmbarcacion en la tabla TurnosEmbarcaciones, en caso de que no esté'
IF (SELECT column_name FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = 'TurnosCalendarios' AND COLUMN_NAME = 'IdEmbarcacion') IS NULL
BEGIN
	ALTER TABLE TurnosCalendarios ADD IdEmbarcacion BIGINT NULL
END

PRINT ''
PRINT '2. Nueva Tabla: CuentasCorrientesTransferencias'
CREATE TABLE CuentasCorrientesTransferencias(
	IdSucursal INT NOT NULL,
	IdTipoComprobante VARCHAR(15) NOT NULL,
	Letra VARCHAR(1) NOT NULL,
	CentroEmisor INT NOT NULL,
	NumeroComprobante BIGINT NOT NULL,
	Orden INT NOT NULL,
	Importe DECIMAL(14,2) NOT NULL,
	IdCuentaBancaria INT NOT NULL,
	IdSucursalLibroBanco INT NULL,
	IdCuentaBancariaLibroBanco INT NULL,
	NumeroMovimientoLibroBanco INT NULL
	PRIMARY KEY (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Orden)
)
GO

PRINT ''
PRINT '2.1. FK_CuentasCorrientesTransferencias_CuentasCorrientes'
ALTER TABLE CuentasCorrientesTransferencias
	ADD CONSTRAINT FK_CuentasCorrientesTransferencias_CuentasCorrientes
	FOREIGN KEY (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante) REFERENCES CuentasCorrientes (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)

PRINT ''
PRINT '2.2. FK_CuentasCorrientesTransferencias_LibrosBancos'
ALTER TABLE CuentasCorrientesTransferencias
	ADD CONSTRAINT FK_CuentasCorrientesTransferencias_LibrosBancos
	FOREIGN KEY (IdSucursalLibroBanco, IdCuentaBancariaLibroBanco, NumeroMovimientoLibroBanco) REFERENCES LibrosBancos(IdSucursal, IdCuentaBancaria, NumeroMovimiento)

PRINT ''
PRINT '2.3. FK_CuentasCorrientesTransferencias_CuentasBancarias'
ALTER TABLE CuentasCorrientesTransferencias
	ADD CONSTRAINT FK_CuentasCorrientesTransferencias_CuentasBancarias
	FOREIGN KEY (IdCuentaBancaria) REFERENCES CuentasBancarias (IdCuentaBancaria)
GO

PRINT ''
PRINT '3. Nueva Tabla: CRMTiposNovedadesObjetivos'
CREATE TABLE [dbo].[CRMTiposNovedadesObjetivos](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[PeriodoObjetivo] [int] NOT NULL,
	[IdUsuarioActualizacion] [varchar](10) NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_CRMTiposNovedadesObjetivos] PRIMARY KEY CLUSTERED ([IdTipoNovedad] ASC,[PeriodoObjetivo] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CRMTiposNovedadesObjetivos]  WITH CHECK ADD  CONSTRAINT [FK_CRMTiposNovedadesObjetivos_CRMTiposNovedades] FOREIGN KEY([IdTipoNovedad])
REFERENCES [dbo].[CRMTiposNovedades] ([IdTipoNovedad])
ALTER TABLE [dbo].[CRMTiposNovedadesObjetivos] CHECK CONSTRAINT [FK_CRMTiposNovedadesObjetivos_CRMTiposNovedades]
GO

ALTER TABLE [dbo].[CRMTiposNovedadesObjetivos]  WITH CHECK ADD  CONSTRAINT [FK_CRMTiposNovedadesObjetivos_Usuarios] FOREIGN KEY([IdUsuarioActualizacion])
REFERENCES [dbo].[Usuarios] ([Id])
ALTER TABLE [dbo].[CRMTiposNovedadesObjetivos] CHECK CONSTRAINT [FK_CRMTiposNovedadesObjetivos_Usuarios]
GO

PRINT ''
PRINT '4. Nueva Tabla: CRMTiposNovedadesObjetivosUsuarios'
CREATE TABLE [dbo].[CRMTiposNovedadesObjetivosUsuarios](
	[IdTipoNovedad] [varchar](10) NOT NULL,
	[PeriodoObjetivo] [int] NOT NULL,
	[IdUsuario] [varchar](10) NOT NULL,
	[Objetivo] [decimal](12, 2) NOT NULL,
	[ObjetivoMinimo] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_CRMTiposNovedadesObjetivosUsuarios_1] PRIMARY KEY CLUSTERED ([IdTipoNovedad] ASC,[PeriodoObjetivo] ASC,[IdUsuario] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CRMTiposNovedadesObjetivosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_CRMTiposNovedadesObjetivosUsuarios_CRMTiposNovedadesObjetivos] FOREIGN KEY([IdTipoNovedad], [PeriodoObjetivo])
REFERENCES [dbo].[CRMTiposNovedadesObjetivos] ([IdTipoNovedad], [PeriodoObjetivo])
ALTER TABLE [dbo].[CRMTiposNovedadesObjetivosUsuarios] CHECK CONSTRAINT [FK_CRMTiposNovedadesObjetivosUsuarios_CRMTiposNovedadesObjetivos]
GO

ALTER TABLE [dbo].[CRMTiposNovedadesObjetivosUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_CRMTiposNovedadesObjetivosUsuarios_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
ALTER TABLE [dbo].[CRMTiposNovedadesObjetivosUsuarios] CHECK CONSTRAINT [FK_CRMTiposNovedadesObjetivosUsuarios_Usuarios]
GO

SET ANSI_PADDING OFF
GO




PRINT '5. Nuevos campos para ser usandos en Pantillas de Excel'
INSERT INTO [dbo].[Campos] ([IdCampo],[NombreCampo],[Orden])
     VALUES(18, 'IdProductoNumerico', 18),
           (19, 'NombreSubRubro'    , 19),
           (20, 'NombreSubSubRubro' , 20)

PRINT '5.1. Agrega campos para ser usandos en Pantillas base de Excel'
INSERT INTO PlantillasCampos (IdPlantilla,IdCampo,OrdenColumna)
     VALUES (1, 18, NULL),
            (2, 18, NULL),
            (1, 19, NULL),
            (2, 19, NULL),
            (1, 20, NULL),
            (2, 20, NULL) 
GO

PRINT '5.2. Renumeracion de orden en Plantillas Base'
UPDATE PlantillasCampos SET OrdenColumna = OrdenColumna + 1
  FROM PlantillasCampos PC 
 INNER JOIN Plantillas P ON P.IdPlantilla = PC.IdPlantilla
 WHERE OrdenColumna > 1 AND P.Sistema = 1
UPDATE PlantillasCampos SET OrdenColumna = 2 
  FROM PlantillasCampos PC 
 INNER JOIN Plantillas P ON P.IdPlantilla = PC.IdPlantilla
 WHERE IdCampo = 18  AND P.Sistema = 1
UPDATE PlantillasCampos SET OrdenColumna = OrdenColumna + 2 
  FROM PlantillasCampos PC 
 INNER JOIN Plantillas P ON P.IdPlantilla = PC.IdPlantilla
 WHERE OrdenColumna > 5 AND P.Sistema = 1
UPDATE PlantillasCampos SET OrdenColumna = 6 
  FROM PlantillasCampos PC 
 INNER JOIN Plantillas P ON P.IdPlantilla = PC.IdPlantilla
 WHERE IdCampo = 19 AND P.Sistema = 1
UPDATE PlantillasCampos SET OrdenColumna = 7 
  FROM PlantillasCampos PC 
 INNER JOIN Plantillas P ON P.IdPlantilla = PC.IdPlantilla
 WHERE IdCampo = 20 AND P.Sistema = 1
GO


PRINT ''
PRINT '6. Tablas TablerosControlPaneles: Inicializar datos (Balanmac y HAR)'
IF dbo.BaseConCuit('27201734687') = 1
BEGIN
    PRINT ''
    PRINT '6.1. Tablas TablerosControlPaneles: Paneles para HAR Group'
    INSERT [dbo].[TablerosControlPaneles] ([IdTableroControlPanel], [NombrePanel], [Parametros], [IdController]) 
        VALUES (102, 'Entregados mensuales', 'SERVICE', 'Eniac.Win.GrillaCRMEntregadoMensual')
END
ELSE
IF dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT '6.1. Tablas TablerosControlPaneles: Paneles para HAR Group'
    INSERT [dbo].[TablerosControlPaneles] ([IdTableroControlPanel], [NombrePanel], [Parametros], [IdController]) 
        VALUES (55, 'Entregados mensuales de Soporte', 'TICKETS', 'Eniac.Win.GrillaCRMEntregadoMensual'),
               (56, 'Entregados mensuales de Desarrollo', 'PENDIENTE', 'Eniac.Win.GrillaCRMEntregadoMensual')
END

PRINT ''
PRINT '7. Tablas TablerosControl: Inicializar datos (Balanmac y HAR)'
IF dbo.BaseConCuit('27201734687') = 1
BEGIN
    PRINT ''
    PRINT '7.1. Tablas TablerosControl: Tableros para HAR Group'
    UPDATE TablerosControl
       SET IdTableroControlPanel3 = 102
     WHERE IdTableroControl = 100
END
ELSE
IF dbo.SoyHAR() = 1
BEGIN
    PRINT ''
    PRINT '7.1. Tablas TablerosControl: Tableros para HAR Group'
    INSERT [dbo].[TablerosControl] ([IdTableroControl], [NombreTableroControl], [IdTableroControlPanel1], [IdTableroControlPanel2], [IdTableroControlPanel3], [IdTableroControlPanel4], [IdTableroControlPanel5], [IdTableroControlPanel6]) 
        VALUES (3, 'Performance de Soporte', 51, 53, 55, NULL, NULL, NULL),
               (4, 'Performance de Desarrollo', 52, 54, 56, NULL, NULL, NULL)
END

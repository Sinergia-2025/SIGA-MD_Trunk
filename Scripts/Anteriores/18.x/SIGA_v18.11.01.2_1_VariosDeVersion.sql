PRINT '1. Nuevos campos para ser usandos en Pantillas de Excel'
INSERT INTO [dbo].[Campos] ([IdCampo],[NombreCampo],[Orden])
     VALUES(12,'CodigoLargoProducto',12),
           (13,'Observacion',13)
GO

PRINT '2. Agregar nuevos campos a Pantillas de Excel existentes'
INSERT INTO PlantillasCampos
  (IdPlantilla,IdCampo,OrdenColumna)
SELECT P.IdPlantilla, C.IdCampo, NULL
  FROM Campos C
  CROSS JOIN Plantillas P
  LEFT JOIN PlantillasCampos PC ON PC.IdCampo = C.IdCampo AND PC.IdPlantilla = P.IdPlantilla
 WHERE 1 = 1
   AND PC.IdPlantilla IS NULL

PRINT '3. Nueva función de menú ParametrosSucursalesABM'
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
         PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ParametrosSucursalesABM', 'ABM de Parámetros de Sucursal', 'ABM de Parámetros de Sucursal', 'True', 'False', 'True', 'True', 
         'Configuraciones', 29, 'Eniac.Win', 'ParametrosSucursalesABM', NULL, NULL,
         'True', 'S', 'N', 'N', 'N')
;

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ParametrosSucursalesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm')
;

PRINT '4. Nueva tabla [ParametrosSucursales]'
/****** Object:  Table [dbo].[ParametrosSucursales]    Script Date: 01/11/2018 14:27:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParametrosSucursales](
	[IdSucursal] [int] NOT NULL,
	[IdParametro] [varchar](50) NOT NULL,
	[ValorParametro] [varchar](200) NULL,
 CONSTRAINT [PK_ParametrosSucursales] PRIMARY KEY CLUSTERED 
([IdSucursal] ASC,[IdParametro] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

PRINT '4.1 FK de [ParametrosSucursales]'
ALTER TABLE [dbo].[ParametrosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_ParametrosSucursales_Parametros] FOREIGN KEY([IdParametro])
REFERENCES [dbo].[Parametros] ([IdParametro])
GO
ALTER TABLE [dbo].[ParametrosSucursales] CHECK CONSTRAINT [FK_ParametrosSucursales_Parametros]
GO

ALTER TABLE [dbo].[ParametrosSucursales]  WITH CHECK ADD  CONSTRAINT [FK_ParametrosSucursales_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[ParametrosSucursales] CHECK CONSTRAINT [FK_ParametrosSucursales_Sucursales]
GO



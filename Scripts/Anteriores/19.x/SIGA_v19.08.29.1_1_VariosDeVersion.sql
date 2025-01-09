PRINT ''
PRINT '1. Nueva Tabla: FormatosEtiquetas'
CREATE TABLE [dbo].[FormatosEtiquetas](
	[IdFormatoEtiqueta] [int] NOT NULL,
	[NombreFormatoEtiqueta] [varchar](30) NOT NULL,
	[Tipo] [varchar](20) NOT NULL,
	[ArchivoAImprimir] [varchar](100) NOT NULL,
	[ArchivoAImprimirEmbebido] [bit] NOT NULL,
	[NombreImpresora] [varchar](100) NOT NULL,
    [ImprimeLote] [bit] NOT NULL,
    [MaximoColumnas] int NOT NULL,
    [UtilizaCabecera] [bit] NOT NULL,
    [SolicitaListaPrecios2] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_FormatosEtiquetas] PRIMARY KEY CLUSTERED 
(
	[IdFormatoEtiqueta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

PRINT ''
PRINT '1.1. Tabla FormatosEtiquetas: Datos iniciales'
INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta],[NombreFormatoEtiqueta],[Tipo],[ArchivoAImprimir],[ArchivoAImprimirEmbebido],[NombreImpresora],[ImprimeLote],[MaximoColumnas],[UtilizaCabecera],[SolicitaListaPrecios2],[Activo])
     VALUES
           (1,  '3 x Ancho',                  'PRECIOS',     'Eniac.Win.EmisionDeEtiquetasDePreciosF1.rdlc', 'True', '', 'False', 3, 'False', 'False', 'True'), -- 0
           (2,  '2 x Ancho',                  'PRECIOS',     'Eniac.Win.EmisionDeEtiquetasDePreciosF2.rdlc', 'True', '', 'False', 2, 'False', 'False', 'True'), -- 1
           (3,  '2 x Ancho con Encabezado',   'PRECIOS',     'Eniac.Win.EmisionDeEtiquetasDePreciosF3.rdlc', 'True', '', 'False', 2, 'True',  'False', 'True'), -- 2
           (4,  '2 x Hoja',                   'PRECIOS',     'Eniac.Win.EmisionDeEtiquetasDePreciosF4.rdlc', 'True', '', 'False', 2, 'False', 'False', 'True'), -- 3
           (5,  '2 x Hoja con Encabezado',    'PRECIOS',     'Eniac.Win.EmisionDeEtiquetasDePreciosF5.rdlc', 'True', '', 'False', 2, 'True',  'False', 'True'), -- 4
           (6,  '3 x Ancho 2 Listas Precios', 'PRECIOS',     'Eniac.Win.EmisionDeEtiquetasDePreciosF6.rdlc', 'True', '', 'False', 3, 'False', 'True',  'True')  -- 5

           ,

           (7,  '1 x Ancho (2 x 2.9 cm)',     'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF1.rdlc',  'True', '', 'False', 1, 'False', 'False', 'True'), -- 0
           (8,  '1 x Ancho (4 x 6 cm)',       'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF2.rdlc',  'True', '', 'False', 1, 'False', 'False', 'True'), -- 1
           (9,  '3 x Ancho (4 x 6 cm)',       'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF3.rdlc',  'True', '', 'False', 3, 'False', 'False', 'True'), -- 2
           (10, '5 x Ancho (3.8 x 2.1 cm)',   'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF4.rdlc',  'True', '', 'False', 5, 'False', 'False', 'True'), -- 3
           (11, '3 x Ancho (7 x 2.5 cm)',     'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF5.rdlc',  'True', '', 'False', 3, 'False', 'False', 'True'), -- 4
           (12, '4 x Ancho (5.25 x 3.3 cm)',  'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF6.rdlc',  'True', '', 'False', 4, 'False', 'False', 'True'), -- 5
           (13, '1 x Ancho (5 x 2.5 cm)',     'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF7.rdlc',  'True', '', 'False', 1, 'False', 'False', 'True')  -- 6

GO

IF dbo.ExisteFuncion('Precios') = 'True'
BEGIN
PRINT ''
PRINT '2. Menu ABM de Formatos de Etiquetas'

    PRINT ''
    PRINT '2.1. Menu ABM de Formatos de Etiquetas: Insertar Función'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('FormatosEtiquetasABM', 'ABM de Formatos de Etiquetas', 'ABM de Formatos de Etiquetas', 'True', 'False', 'True', 'True'
        ,'Precios', 310, 'Eniac.Win', 'FormatosEtiquetasABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
   
    PRINT ''
    PRINT '2.2. Menu ABM de Formatos de Etiquetas: Agregar Roles'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'FormatosEtiquetasABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END;

PRINT ''
PRINT '3. Menu Panel de Control'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '3.1. Menu Panel de Control: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('PanelDeControl', 'Panel de Control', 'Panel de Control', 'True', 'False', 'True', 'True'
             ,'Calidad', 80, 'Eniac.Win', 'PanelDeControl', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '3.2. Menu Panel de Control: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'PanelDeControl' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

END;

PRINT '4. Renombrar Repórte RemitoTransportista.rdlc a RemitoTransportista_SinLogo.rdlc'
EXECUTE [dbo].[RenombrarReporte] 'Eniac.Win.RemitoTransportista.rdlc', 'Eniac.Win.RemitoTransportista_SinLogo.rdlc', '1'



/****** Object:  Table [dbo].[CalidadEstadosListasControl]    Script Date: 31/1/2020 09:47:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EstadosTurismo](
	[IdEstadoTurismo] [int] NOT NULL,
	[NombreEstadoTurismo] [varchar](20) NOT NULL,
	[Posicion] [int] NOT NULL,
	[Finalizado] [bit] NOT NULL,
	[PorDefecto] [bit] NOT NULL,
	[Color] [int] NULL,
 CONSTRAINT [PK_EstadosTurismo] PRIMARY KEY CLUSTERED 
(
	[IdEstadoTurismo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EstadosTurismo] ADD  CONSTRAINT [DF_EstadosTurismo_PorDefecto]  DEFAULT ((0)) FOR [PorDefecto]
GO

PRINT ''
PRINT '1. Nuevo Campo: Se agrega un nuevo campo InformaLibroIva a la tabla TiposComprobantes'

ALTER TABLE TiposComprobantes
ADD InformaLibroIva BIT NULL
GO

PRINT ''
PRINT '1.1. UPDATE InformaLibroIva: Se actualiza el campo a FALSE a todos los comprobantes'

UPDATE TiposComprobantes SET InformaLibroIva = 'False'
GO

PRINT ''
PRINT '1.2. UPDATE InformaLibroIva: Se actualiza el campo a TRUE a todos los comprobantes de VENTAS (Tipo = VENTAS) que Graben Libro( GrabaLibro = True )'

UPDATE TiposComprobantes SET InformaLibroIva = 'True' WHERE GrabaLibro = 'True' and Tipo = 'VENTAS'
GO

PRINT ''
PRINT '1.3. UPDATE InformaLibroIva: Se actualiza el campo a TRUE a todos los comprobantes de COMPRAS (Tipo = COMPRAS) que Graben Libro( GrabaLibro = True ) y sean Comerciales ( EsComercial = True )'

UPDATE TiposComprobantes SET InformaLibroIva = 'True' WHERE GrabaLibro = 'True' and EsComercial = 'True' and Tipo = 'COMPRAS'
GO

PRINT ''
PRINT '1.4. UPDATE InformaLibroIva: Se actualiza el campo a TRUE a todos los comprobantes de VENTAS (Tipo = VENTAS) que están en impresora CyO'

UPDATE TiposComprobantes 
   SET InformaLibroIva = 'True'
  FROM TiposComprobantes
 CROSS JOIN Impresoras
 WHERE PorCtaOrden = 'True'
   AND Tipo = 'VENTAS'
   AND (ComprobantesHabilitados LIKE IdTipoComprobante + ',%' OR
        ComprobantesHabilitados LIKE '%,' + IdTipoComprobante + ',%' OR
        ComprobantesHabilitados LIKE '%,' + IdTipoComprobante)


PRINT ''
PRINT '1.5. Nuevo Campo: NOT NULL para campo InformaLibroIva de la tabla TiposComprobantes'

ALTER TABLE TiposComprobantes
ALTER COLUMN InformaLibroIva BIT NOT NULL
GO

PRINT ''
PRINT '7. Menu Calidad'
--IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('') = 'True'
BEGIN
    IF dbo.ExisteFuncion('Turismo') = 'False'
    BEGIN
        INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('Turismo', 'Turismo', 'Turismo', 'True', 'False', 'True', 'True'
            ,NULL, 50, NULL, NULL, NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
   
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'Turismo' AS Pantalla FROM dbo.Roles
	     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END;

    IF dbo.ExisteFuncion('Turismo') = 'True'
    BEGIN

        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('EstadosTurismoABM', 'ABM de Estados', 'ABM de Estados', 'True', 'False', 'True', 'True'
                ,'Turismo', 10, 'Eniac.Win', 'EstadosTurismoABM', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')
        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'EstadosTurismoABM' FROM RolesFunciones WHERE IdFuncion = 'Turismo'

		
END;
END


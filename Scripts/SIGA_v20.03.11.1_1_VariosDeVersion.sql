SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposDocumentosFunciones](
	[IdTipoLink] [varchar](15) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[DescripcionAbreviada] [varchar](10) NULL,
    [Orden] [int] NOT NULL,
 CONSTRAINT [PK_TiposDocumentosFunciones] PRIMARY KEY CLUSTERED 
([IdTipoLink] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

INSERT INTO [dbo].[TiposDocumentosFunciones]
           ([IdTipoLink],[Descripcion],[DescripcionAbreviada],[Orden])
     VALUES
           --123456789012345  123456789012345678901234567890  1234567890
           ('ANALISIS',      'ANALISIS FUNCIONAL',           'ANALISIS',   1),
           ('CASOPRUEBA',    'CASO DE PRUEBA',               'C. PRUEBA',  2),
           ('ESTANDAR',      'ESTANDAR DE PROGRAMACION',     'ESTANDAR',   3),
           ('MANUAL',        'MANUAL DE USUARIO',            'MANUAL U.',  4),
           ('PLANTILLA',     'PLANTILLA',                    'PLANTILLA',  5),
           ('REQUERIMIENTO', 'REQUERIMEINTO DE USUARIO',     'REQ. USUAR', 6)
GO


ALTER TABLE dbo.FuncionesDocumentos ADD CONSTRAINT FK_FuncionesDocumentos_TiposDocumentosFunciones
    FOREIGN KEY (IdTipoLink)
    REFERENCES dbo.TiposDocumentosFunciones (IdTipoLink)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


SET ANSI_PADDING OFF
GO

PRINT ''
PRINT '1. Parametros: Actualizacion Tope CF'

IF dbo.GetValorParametro('FACTURACIONCONTROLATOPECF') <= 5000
	UPDATE Parametros 
	   SET ValorParametro = 7690 
	 WHERE IdParametro = 'FACTURACIONCONTROLATOPECF' 

GO

DECLARE @idParametro VARCHAR(MAX) 
DECLARE @descripcionParametro VARCHAR(MAX) 
DECLARE @valorParametro VARCHAR(MAX) 

IF dbo.BaseConCuit('30714374938') = 'True' -- EduViajes
BEGIN
    
    PRINT ''
    PRINT '5. Inicializo Parametros Roela'

    SET @idParametro = 'TURISMOROELAIDCONCEPTO'
    SET @descripcionParametro = 'Identificador de Concepto'
    SET @valorParametro = '1'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;
    SET @idParametro = 'TURISMOROELAIDCUENTA'
    SET @descripcionParametro = 'Identificador de Cuenta'
    SET @valorParametro = '2'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;
    SET @idParametro = 'TURISMOROELAINTERESVTO'
    SET @descripcionParametro = 'Interes para calculo de Vencimientos'
    SET @valorParametro = '1'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
    ;

END

GO

PRINT ''
PRINT '1. CuentasCorrientes: Nuevas columnas'

ALTER TABLE CuentasCorrientes ADD FechaViaje datetime NULL
GO

ALTER TABLE CuentasCorrientes ADD NombreEstablecimiento varchar(100) NULL
GO

ALTER TABLE CuentasCorrientes ADD NombrePrograma varchar(60) NULL
GO


PRINT ''
PRINT '1. CuentasCorrientesPagos: Nuevas columnas'

ALTER TABLE CuentasCorrientesPagos ADD FechaVencimiento2 datetime NULL
GO

ALTER TABLE CuentasCorrientesPagos ADD ImporteVencimiento2 decimal(14,2) NULL
GO

ALTER TABLE CuentasCorrientesPagos ADD FechaVencimiento3 datetime NULL
GO

ALTER TABLE CuentasCorrientesPagos ADD ImporteVencimiento3 decimal(14,2) NULL
GO

ALTER TABLE CuentasCorrientesPagos ADD CodigoDeBarra varchar(100) NULL
GO


PRINT ''
PRINT '1. Reservas: Nueva columna TipoGeneracion.'
ALTER TABLE Reservas ADD TipoGeneracion varchar(15) NULL
GO

ALTER TABLE Reservas ADD FechaViaje datetime NULL
GO




ALTER TABLE ReservasPasajeros DROP PK_ReservasPasajeros
GO 


ALTER TABLE ReservasPasajeros ALTER COLUMN IdPasajero int not null
GO


ALTER TABLE ReservasPasajeros ADD  CONSTRAINT [PK_ReservasPasajeros] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdTipoReserva] ASC,
	[Letra] ASC,
	[CentroEmisor] ASC,
	[NumeroReserva] ASC,
	[IdPasajero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


GO

DECLARE @idParametro VARCHAR(MAX) 
DECLARE @descripcionParametro VARCHAR(MAX) 
DECLARE @valorParametro VARCHAR(MAX) 

IF dbo.BaseConCuit('30714374938') = 'True' -- EduViajes
BEGIN

  SET @idParametro = 'TURISMOTIPOCOMPROBANTE'
    SET @descripcionParametro = 'Tipo de Comprobante Generacion Cta Cte'
    SET @valorParametro = 'FICHAS'
    MERGE INTO Parametros AS DEST
            USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
        WHEN MATCHED THEN
            UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
        WHEN NOT MATCHED THEN 
            INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro);

	PRINT ''
    PRINT '6.1.- Tabla Impresoras: Agregar FICHAS a impresora NORMAL'
    --Asignacion a la Normal
    UPDATE Impresoras
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',FICHAS'
     WHERE IdImpresora = 'NORMAL'
END

GO



IF dbo.ExisteFuncion('Turismo') = 'True'
BEGIN
 PRINT ''
    PRINT '1. Menu Turismo: Agregar función'
    INSERT INTO Funciones
            (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
            ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
        VALUES
            ('GenerarCuentaCorriente', 'Generar Cuenta Corriente', 'Generar Cuenta Corriente', 'True', 'False', 'True', 'True'
            ,'Turismo', 20, 'Eniac.Win', 'GenerarCuentaCorriente', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    PRINT ''
    PRINT '1.1. Menu Reservas: Agregar roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'GenerarCuentaCorriente' FROM RolesFunciones WHERE IdFuncion = 'Turismo'

END




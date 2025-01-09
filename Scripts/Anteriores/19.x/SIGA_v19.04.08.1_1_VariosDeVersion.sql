/****** Object:  UserDefinedFunction [dbo].[ExisteFuncion]    Script Date: 03/04/2019 17:52:46 ******/
PRINT ''
PRINT '1. Actualizar Script de ExisteFuncion'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[ExisteFuncion](@idFuncion varchar(max))
    RETURNS bit
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Funciones WHERE Id = @idFuncion)
        RETURN 1
    RETURN 0
END
GO

PRINT ''
PRINT '2. Nueva opción de menú EnvioMasivoDeCompVenc'
IF dbo.ExisteFuncion('CuentasCorrientes') = 1 AND dbo.ExisteFuncion('EnvioMasivoDeCompVenc') = 0
BEGIN
  INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	 VALUES
	   ('EnvioMasivoDeCompVenc', 'Envío Masivo de Comprobantes vencidos', 'Envío Masivo de Comprobantes vencidos', 
		'True', 'False', 'True', 'True', 'CuentasCorrientes', 46, 'Eniac.Win', 'EnvioMasivoDeFacturas', null, 'PORVENCIMIENTO',
              'True', 'S', 'N', 'N', 'N')
	

	INSERT INTO RolesFunciones 
				  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'EnvioMasivoDeCompVenc' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END


PRINT ''
PRINT '3. Nuevo campo CotizacionDolar en CuentasCorrientes'
ALTER TABLE CuentasCorrientes ADD CotizacionDolar decimal(10, 3) NULL
GO

UPDATE CuentasCorrientes 
   SET CuentasCorrientes.CotizacionDolar = V.CotizacionDolar
 FROM CuentasCorrientes CC 
 INNER JOIN Ventas V ON V.IdSucursal = CC.IdSucursal
 AND V.IdTipoComprobante = CC.IdTipoComprobante
 AND V.Letra = V.Letra
 AND V.CentroEmisor = CC.CentroEmisor
 AND V.NumeroComprobante = CC.NumeroComprobante
GO

UPDATE CuentasCorrientes SET CotizacionDolar = 1 where CotizacionDolar IS NULL
GO

ALTER TABLE CuentasCorrientes ALTER COLUMN 	CotizacionDolar decimal(10, 3) NOT NULL
GO

PRINT ''
PRINT '4. Nueva tabla AuditoriaMonedas'
CREATE TABLE [dbo].[AuditoriaMonedas](
	[FechaAuditoria] [datetime] NOT NULL,
	[OperacionAuditoria] [char](1) NOT NULL,
	[UsuarioAuditoria] [varchar](10) NOT NULL,
	[IdMoneda] [int] NOT NULL,
	[NombreMoneda] [varchar](30) NOT NULL,
	[IdTipoMoneda] [varchar](15) NOT NULL,
	[OperadorConversion] [char](1) NOT NULL,
	[FactorConversion] [decimal](6, 3) NOT NULL,
	[IdBanco] [int] NULL,
	[Simbolo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_AuditoriaMonedas] PRIMARY KEY CLUSTERED 
(
	[FechaAuditoria] ASC,
	[IdMoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '5. Cambia El Comprobante_Dolares a Embebido'
UPDATE       TiposComprobantesLetras
	SET       ArchivoAImprimir2 = 'Eniac.Win.Comprobante_Dolares.rdlc', ArchivoAImprimirEmbebido2 = 1
WHERE        (ArchivoAImprimir2 = 'Comprobante_Dolares.rdlc')

PRINT ''
PRINT '6. Agregar campos IdSucursalAsociadaPrecios y PublicarEnWeb a Sucursales'
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Sucursales ADD IdSucursalAsociadaPrecios int NULL
GO
ALTER TABLE dbo.Sucursales ADD PublicarEnWeb bit NULL
GO

UPDATE Sucursales SET PublicarEnWeb = EstoyAca;

ALTER TABLE dbo.Sucursales ADD CONSTRAINT
	FK_Sucursales_Sucursales_Precios FOREIGN KEY (IdSucursalAsociadaPrecios)
    REFERENCES dbo.Sucursales (IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.Sucursales ALTER COLUMN PublicarEnWeb bit NOT NULL
GO

ALTER TABLE dbo.Sucursales SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

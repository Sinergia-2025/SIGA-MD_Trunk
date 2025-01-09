
PRINT ''
PRINT '1. Nuevo Parametros: UbicaciónArchivosPDA.'
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('UBICACIONARCHIVOSPDA', 'C:\VENTASPDA\TRN\', null, 'Ubicación Archivos PDA')
GO


PRINT ''
PRINT '2. Tabla ClientesAdjuntos: Nuevos Campos para FK con Ventas.'
GO

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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesAdjuntos ADD IdSucursalVenta int NULL
ALTER TABLE dbo.ClientesAdjuntos ADD IdTipoComprobanteVenta varchar(15) NULL
ALTER TABLE dbo.ClientesAdjuntos ADD LetraVenta varchar(1) NULL
ALTER TABLE dbo.ClientesAdjuntos ADD CentroEmisorVenta int NULL
ALTER TABLE dbo.ClientesAdjuntos ADD NumeroComprobanteVenta bigint NULL
GO
ALTER TABLE dbo.ClientesAdjuntos ADD CONSTRAINT FK_ClientesAdjuntos_Ventas 
    FOREIGN KEY (IdTipoComprobanteVenta,LetraVenta,CentroEmisorVenta,NumeroComprobanteVenta,IdSucursalVenta)
    REFERENCES dbo.Ventas (IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.ClientesAdjuntos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla Ventas: Nuevo Campo IdCobrador y FK.'
GO

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
ALTER TABLE dbo.Cobradores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Ventas ADD IdCobrador int NULL
GO
ALTER TABLE dbo.Ventas ADD CONSTRAINT FK_Ventas_Cobradores
    FOREIGN KEY (IdCobrador)
    REFERENCES dbo.Cobradores (IdCobrador)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla VentasFormasPagos: Campos para calculos de Fechas.'
GO

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
ALTER TABLE dbo.VentasFormasPago ADD FechaBaseProximaCuota varchar(10) NULL
ALTER TABLE dbo.VentasFormasPago ADD ExcluyeSabados bit NULL
ALTER TABLE dbo.VentasFormasPago ADD ExcluyeDomingos bit NULL
ALTER TABLE dbo.VentasFormasPago ADD ExcluyeFeriados bit NULL
GO
UPDATE VentasFormasPago
   SET FechaBaseProximaCuota = 'TEORICA'
      ,ExcluyeSabados = 0
      ,ExcluyeDomingos = 0
      ,ExcluyeFeriados = 0;
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN FechaBaseProximaCuota varchar(10) NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN ExcluyeSabados bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN ExcluyeDomingos bit NOT NULL
ALTER TABLE dbo.VentasFormasPago ALTER COLUMN ExcluyeFeriados bit NOT NULL
GO
ALTER TABLE dbo.VentasFormasPago SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tabla VentasFormasPagos: Seteo Exclusivo para C.D.'
GO

-- Cobros Diarios
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('20326412830'))	
BEGIN
    UPDATE VentasFormasPago
       SET FechaBaseProximaCuota = 'REAL'
          ,ExcluyeSabados = 0
          ,ExcluyeDomingos = 1
          ,ExcluyeFeriados = 1
     WHERE Dias = 1
END
GO


PRINT ''
PRINT '6. Nueva Tabla: TiposComprobantesPDA y Registros Factura Electronica.'
GO

/****** Object:  Table [dbo].[TiposComprobantesPDA]    Script Date: 02/12/2018 15:52:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TiposComprobantesPDA](
	[IdTipoComprobante] [varchar](15) NOT NULL,
	[Letra] [varchar](1) NOT NULL,
	[TipoComprobantePDA] [int] NOT NULL,
 CONSTRAINT [PK_TiposComprobantesPDA] PRIMARY KEY CLUSTERED 
(
	[IdTipoComprobante] ASC,
	[Letra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO TiposComprobantesPDA
           (IdTipoComprobante, Letra, TipoComprobantePDA)
     VALUES
           ('eFACT','A', 1),
           ('FACT','A', 1),
           ('eFACT','B', 2),
           ('FACT','B', 2),
           ('eNDEB','A', 3),
           ('NDEB','A', 3),
           ('eNDEB','B', 4),
           ('NDEB','B', 4),
           ('eNCRED','A', 5),
           ('NCRED','A', 5),
           ('eNCRED','B', 6),
           ('NCRED','B', 6)
GO


PRINT ''
PRINT '7. Nuevo Menu: Ventas\Exportación de Ventas.'
GO

-- Si existe el Menu Ventas.

IF EXISTS (SELECT Id FROM Funciones WHERE Id = 'Ventas')
BEGIN

		--Inserto la pantalla nueva
		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
			 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('ExportacionDeVentas', 'Exportación de Ventas', 'Exportación de Ventas', 'True', 'False', 'True', 'True',
			  'Ventas', 215, 'Eniac.Win', 'ExportacionDeVentas', NULL);

		INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ExportacionDeVentas' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END;


PRINT ''
PRINT '8. AFIPTiposComprobantesTiposCbtes: Ajusto valores para CITI Compras en RES-BANCARIO y RES-TARJETA.'
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
     VALUES
           (99, 'RES-BANCARIO', 'X'),
           (99, 'RES-TARJETA', 'X')
GO


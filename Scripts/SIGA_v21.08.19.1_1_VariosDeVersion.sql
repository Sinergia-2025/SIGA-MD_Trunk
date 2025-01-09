PRINT ''
PRINT '1. Tabla Paises: Nuevos Campos'
ALTER TABLE Paises ADD [IdAfipPais] [int] null
GO

PRINT '1.1. Tabla Paises: Actualizar registros pre-existentes para los campos'
UPDATE Paises SET [IdAfipPais] = 0
PRINT '1.2. Tabla Paises: NOT NULL para los campos agregados'
ALTER TABLE Paises ALTER COLUMN [IdAfipPais] [int] NOT NULL

GO

PRINT ''
PRINT '2. Nueva Tabla: AFIPIncoterms'
CREATE TABLE [dbo].[AFIPIncoterms](
    [IdIncoterm] [varchar](3) NOT NULL,
    [NombreIncoterm] [varchar](100) NOT NULL,
    CONSTRAINT [PK_AFIPIncoterms] PRIMARY KEY CLUSTERED 
([IdIncoterm] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '3. Tabla Ventas: Nuevos Campos IdIcotermExportacion, IdDestinoExportacion, EsFacturaExportacion'
BEGIN
    ALTER TABLE dbo.Ventas ADD
        IdIcotermExportacion Varchar(3) NULL,
        IdDestinoExportacion Varchar(3) NULL,
        EsFacturaExportacion Bit NULL
END

PRINT ''
PRINT '3.1. Tabla Ventas: FK_Ventas_DestinoExportacion'
ALTER TABLE dbo.Ventas ADD CONSTRAINT FK_Ventas_DestinoExportacion
    FOREIGN KEY (IdDestinoExportacion)
    REFERENCES dbo.Paises (IdPais)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
PRINT ''
PRINT '3.2. Tabla Ventas: FK_Ventas_AFIPIncoterms'
ALTER TABLE dbo.Ventas ADD CONSTRAINT FK_Ventas_AFIPIncoterms
    FOREIGN KEY (IdIcotermExportacion)
    REFERENCES dbo.AFIPIncoterms (IdIncoterm)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '4. Nueva Tabla: VentasExportacionEmbarque'
CREATE TABLE VentasExportacionEmbarque
    (
    IdSucursal int NOT NULL,
    IdTipoComprobante varchar(15) NOT NULL,
    LetraComprobante varchar(1) NOT NULL,
    CentroEmisor int NOT NULL,
    NumeroComprobante bigint NOT NULL,
    IdPermisoEmbarque varchar(16) NOT NULL,
    IdDestinoDespacho varchar(3) NOT NULL
    )  ON [PRIMARY]

PRINT ''
PRINT '4.1. Tabla VentasExportacionEmbarque: PK_VentasExportacionEmbarque'
ALTER TABLE dbo.VentasExportacionEmbarque ADD CONSTRAINT PK_VentasExportacionEmbarque
    PRIMARY KEY CLUSTERED (IdSucursal, IdTipoComprobante, LetraComprobante, CentroEmisor, NumeroComprobante, IdPermisoEmbarque)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

PRINT ''
PRINT '4.2. Tabla VentasExportacionEmbarque: FK_VentasExportacionEmbarque'
ALTER TABLE dbo.VentasExportacionEmbarque ADD CONSTRAINT FK_VentasExportacionEmbarque
    FOREIGN KEY (IdDestinoDespacho)
    REFERENCES dbo.Paises (IdPais)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 

ALTER TABLE dbo.VentasExportacionEmbarque SET (LOCK_ESCALATION = TABLE)

PRINT ''
PRINT '5. Tabla TiposComprobantes: Nuevo Campo Color'
ALTER TABLE dbo.TiposComprobantes ADD Color int NULL
GO

PRINT ''
PRINT '6 Tabla MovilRutas: Se modifica el campo IdTransportista a NULL'
ALTER TABLE MovilRutas ALTER COLUMN IdTransportista int null
GO


PRINT ''
PRINT '1. Tabla Compras: Agrego Campos TotalBruto, TotalNeto, TotalIVA y TotalPercepciones.'
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
ALTER TABLE dbo.Compras ADD TotalBruto decimal(14, 2) NULL
ALTER TABLE dbo.Compras ADD TotalNeto decimal(14, 2) NULL
ALTER TABLE dbo.Compras ADD TotalIVA decimal(14, 2) NULL
ALTER TABLE dbo.Compras ADD TotalPercepciones decimal(14, 2) NULL
GO

PRINT ''
PRINT '2. Tabla Compras: Calculo Campos TotalBruto, TotalNeto, TotalIVA y TotalPercepciones.'
GO

UPDATE Compras
   SET TotalBruto        = BrutoNoGravado + Bruto105 + Bruto210 + Bruto270
      ,TotalNeto         = NetoNoGravado  + Neto105  + Neto210  + Neto270
      ,TotalIVA          = 0              + IVA105   + IVA210   + IVA270
      ,TotalPercepciones = PercepcionGanancias + PercepcionIB + PercepcionIVA + PercepcionVarias
;

ALTER TABLE dbo.Compras ALTER COLUMN TotalBruto decimal(14, 2) NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN TotalNeto decimal(14, 2) NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN TotalIVA decimal(14, 2) NOT NULL
ALTER TABLE dbo.Compras ALTER COLUMN TotalPercepciones decimal(14, 2) NOT NULL
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO

COMMIT

PRINT ''
PRINT '3. Tabla ComprasImpuestos: Agrego y Calculo Campo Bruto.'
GO

ALTER TABLE dbo.ComprasImpuestos ADD Bruto decimal(14, 2) NULL
GO
UPDATE ComprasImpuestos
   SET Bruto = CI.BaseImponible / (1 + (C.DescuentoRecargoPorc / 100))
  FROM Compras C
  INNER JOIN ComprasImpuestos CI ON CI.IdSucursal = C.IdSucursal
                                AND CI.IdTipoComprobante = C.IdTipoComprobante
                                AND CI.Letra = C.Letra
                                AND CI.CentroEmisor = C.CentroEmisor
                                AND CI.NumeroComprobante = C.NumeroComprobante
                                AND CI.IdProveedor = C.IdProveedor
;

ALTER TABLE dbo.ComprasImpuestos ALTER COLUMN Bruto decimal(14, 2) NOT NULL
GO
ALTER TABLE dbo.ComprasImpuestos SET (LOCK_ESCALATION = TABLE)
GO

PRINT ''
PRINT '4. Tablas de Services: Ensancho Campos de Observaciones.'
GO

ALTER TABLE RecepcionNotas ALTER COLUMN DefectoProducto varchar(1000) NOT NULL
ALTER TABLE RecepcionNotas ALTER COLUMN Observacion varchar(1000) NOT NULL
ALTER TABLE RecepcionNotas ALTER COLUMN ObservacionPrestamo varchar(1000) NULL

ALTER TABLE RecepcionNotasEstados ALTER COLUMN Observacion varchar(1000) NULL

ALTER TABLE RecepcionNotasF ALTER COLUMN DefectoProducto varchar(1000) NOT NULL
ALTER TABLE RecepcionNotasF ALTER COLUMN Observacion varchar(1000) NOT NULL
ALTER TABLE RecepcionNotasF ALTER COLUMN ObservacionPrestamo varchar(1000) NULL

ALTER TABLE RecepcionNotasEstadosF ALTER COLUMN Observacion varchar(1000) NULL


PRINT ''
PRINT '1. Tabla Cajas: Nuevo Campo FechaCierrePlanilla'
ALTER TABLE dbo.Cajas ADD FechaCierrePlanilla datetime NULL
GO

PRINT ''
PRINT '1.1. Tabla Cajas: FechaCierrePlanilla cargar valor con FechaPlanilla siguiente.'
UPDATE C
   SET FechaCierrePlanilla = C1.FechaCierrePlanilla
  FROM (
        SELECT C.IdSucursal, C.IdCaja, C.NumeroPlanilla, C.FechaPlanilla
             , (SELECT TOP 1 C1.FechaPlanilla FROM Cajas C1
                 WHERE C1.IdSucursal = C.IdSucursal AND C1.IdCaja = C.IdCaja AND C1.NumeroPlanilla > C.NumeroPlanilla) FechaCierrePlanilla
             --, '', *
          FROM Cajas C
         WHERE C.FechaCierrePlanilla IS NULL) C1
 INNER JOIN Cajas C ON C.IdSucursal = C1.IdSucursal AND C1.IdCaja = C.IdCaja AND C1.NumeroPlanilla = C.NumeroPlanilla


PRINT ''
PRINT '2. Tabla Ventas: Nuevo Campo SaldoActualCtaCteUnificado'
ALTER TABLE dbo.Ventas ADD SaldoActualCtaCteUnificado decimal(14, 2) NULL
GO


PRINT ''
PRINT '3.- Nueva Campo Tipos Comprobantes - CodigoRoela.'
BEGIN
    ALTER TABLE TiposComprobantes ADD CodigoRoela VarChar(1) NULL
END
GO

PRINT ''
PRINT '3.1.- Nueva Campo Tipos Comprobantes - CodigoRoela(Modificaciones.'
BEGIN
    UPDATE TiposComprobantes SET CodigoRoela = '';
    ALTER TABLE TiposComprobantes ALTER COLUMN CodigoRoela VarChar(1) NOT NULL
END
GO

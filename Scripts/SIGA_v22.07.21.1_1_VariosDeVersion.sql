PRINT ''
PRINT '1. Tabla CajasDetalle: Modifica Campo IdMonedaImporteBancos'
BEGIN
    UPDATE CJD
       SET IdMonedaImporteBancos = CTB.IdMoneda
      FROM Compras CMP
     INNER JOIN VentasFormasPago AS VFP ON CMP.IdFormasPago = VFP.IdFormasPago 
     INNER JOIN CuentasBancarias AS CTB ON CMP.IdCuentaBancaria = CTB.IdCuentaBancaria
     INNER JOIN CajasDetalle     AS CJD ON CJD.idsucursal = CMP.Idsucursal 
                                       AND CJD.IdCaja = CMP.IdCaja 
                                       AND CJD.NumeroPlanilla = CMP.NumeroPlanilla 
                                       AND CJD.NumeroMovimiento = CMP.NumeroMovimiento
     WHERE NULLIF(CJD.IdMonedaImporteBancos, 0) IS NULL
END
GO

PRINT ''
PRINT '2. Tabla VentasFormasPago:  Nuevo Campo: ArchivoComplementario'
IF NOT EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE [TABLE_NAME] = 'VentasFormasPago' AND [COLUMN_NAME] = 'ArchivoComplementario')
BEGIN
	ALTER TABLE VentasFormasPago ADD ArchivoComplementario VarChar(100) Null
END

PRINT ''
PRINT '2.1. Tabla VentasFormasPago:  Nuevo Campo: ArchivoAImprimirEmbebido'
IF NOT EXISTS(SELECT TOP 1 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE [TABLE_NAME] = 'VentasFormasPago' AND [COLUMN_NAME] = 'ArchivoAImprimirEmbebido')
BEGIN
	ALTER TABLE VentasFormasPago ADD ArchivoAImprimirEmbebido bit NULL
END
GO

PRINT ''
PRINT '2.1.1. Tabla VentasFormasPago:  Nuevo Campo: ArchivoAImprimirEmbebido'
UPDATE VentasFormasPago SET ArchivoAImprimirEmbebido = 'False'
ALTER TABLE VentasFormasPago ALTER COLUMN ArchivoAImprimirEmbebido bit NOT NULL
GO

PRINT ''
PRINT '3. Tabla TiposComprobantes: Copiar estado de ConsumePedido de eFact a ePre-Fact y similares'
UPDATE TC
   SET ConsumePedidos = TC2.ConsumePedidos
  FROM TiposComprobantes TC
 INNER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = TC.IdTipoComprobanteSecundario
 WHERE TC.EsElectronico = 'True'
   AND TC.EsPreElectronico = 'True'


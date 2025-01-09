IF NOT EXISTS (SELECT * FROM CuentasBancarias WHERE IdCuentaBancaria = 999)
BEGIN
    INSERT INTO CuentasBancarias
               (IdCuentaBancaria, CodigoBancario, NombreCuenta, IdCuentaBancariaClase, IdBanco
               ,IdMoneda, TieneChequera, IdLocalidad, Saldo, SaldoConfirmado
               ,IdBancoSucursal, IdPlanCuenta, IdCuentaContable, Cbu, CbuAlias
               ,ParaInformarEnFEC, IdEmpresa, Activo)
         VALUES
               (999, 999, '(multiples cuentas)', 1, 1
               ,1, 'False', 2000, 0, 0
               ,0, 1, NULL, NULL, NULL
               ,'False', NULL, 'True')
END
GO

INSERT INTO VentasTransferencias
           (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, Orden
           ,Importe, IdCuentaBancaria
           ,IdSucursalLibroBanco, IdCuentaBancariaLibroBanco, NumeroMovimientoLibroBanco)
SELECT V.IdSucursal, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante, 1 Orden
     , V.ImporteTransfBancaria, V.IdCuentaBancaria
     , LB.IdSucursal IdSucursalLibroBanco, LB.IdCuentaBancaria IdCuentaBancariaLibroBanco, LB.NumeroMovimiento NumeroMovimientoLibroBanco
  FROM Ventas V
 INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = V.IdFormasPago
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante
  LEFT JOIN LibrosBancos LB ON LB.Observacion LIKE TC.Descripcion + ' ' + V.Letra + ' ' + CONVERT(VARCHAR(MAX), V.CentroEmisor) + '-' + RIGHT('00000000' + CONVERT(VARCHAR(MAX), V.NumeroComprobante), 8) + '%'
 WHERE V.ImporteTransfBancaria <> 0
   AND FP.Dias = 0
   AND NOT EXISTS (SELECT * FROM VentasTransferencias VF
                    WHERE VF.IdSucursal = V.IdSucursal
                      AND VF.IdTipoComprobante = V.IdTipoComprobante
                      AND VF.Letra = V.Letra
                      AND VF.CentroEmisor = V.CentroEmisor
                      AND VF.NumeroComprobante = V.NumeroComprobante)
GO

PRINT ''
PRINT '1. Parametro: MRP: Tipo Comprobante Orden de Produccion en Requerimiento'
DECLARE @idParametro VARCHAR(MAX) = 'TIPOCOMPROBANTEORDENPRODUCCIONREQUERIMIENTO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Tipo Comprobante Orden de Produccion en Requerimiento '
DECLARE @valorParametro VARCHAR(MAX) = 'REQUERIMIENTO'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '1. Parametro: MRP: Estado Orden de Produccion en Planificacion Requerimiento'
DECLARE @idParametro VARCHAR(MAX) = 'ESTADOORDENPRODUCCIONPLANIFICACIONRQ'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Estado Orden de Produccion en Planificacion Requerimiento'
DECLARE @valorParametro VARCHAR(MAX) = ''

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '1. Parametro: MRP: Tipo Comprobante Orden de Produccion en Planificacion'
DECLARE @idParametro VARCHAR(MAX) = 'TIPOCOMPROBANTEORDENPRODUCCIONPLANIFICACION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'MRP: Tipo Comprobante Orden de Produccion en Planificacion '
DECLARE @valorParametro VARCHAR(MAX) = 'ORDENPRODUCCION'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, 'MRP', ORIG.DescripcionParametro)
;
GO

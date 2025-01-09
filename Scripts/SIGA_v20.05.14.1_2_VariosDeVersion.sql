DECLARE @idParametro VARCHAR(MAX)
DECLARE @descripcionParametro VARCHAR(MAX)
DECLARE @valorParametro VARCHAR(MAX)

PRINT ''
PRINT '1. Nuevo parámetro: Envio Masivo de Comprobantes: Adjunta Cta Cte'
SET @idParametro = 'ENVIOMASIVOCOMPROBANTESADJUNTACTACTE'
SET @descripcionParametro = 'Envio Masivo de Comprobantes: Adjunta Cta Cte'
SET @valorParametro = 'True'

IF dbo.BaseConCuit('27055884175') = 1
    SET @valorParametro = 'False'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

PRINT ''
PRINT '2. Nueva Cuenta de Caja: Liquidaciones Tarjeta'
INSERT INTO CuentasDeCajas
        (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable, IdCentroCosto, GeneraContabilidad)
  VALUES((SELECT MAX(IdCuentaCaja)+1 FROM CuentasDeCajas),'Liquidaciones Tarjeta','E','False','False',1,NULL,NULL,'False')

PRINT ''
PRINT '2.1. Nuevo Parámetro: Caja: Cuenta Liquidación Tarjeta'
SET @idParametro = 'CTACAJALIQUIDACIONTARJETA'
SET @descripcionParametro = 'Caja: Cuenta Liquidación Tarjeta'
SET @valorParametro = (SELECT IdCuentaCaja FROM CuentasDeCajas WHERE NombreCuentaCaja = 'Liquidaciones Tarjeta')

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

PRINT ''
PRINT '3. Nueva Cuenta Banco: Liquidaciones Tarjeta'
INSERT INTO CuentasBancos 
        (IdCuentaBanco, NombreCuentaBanco, IdTipoCuenta, EsPosdatado, PideCheque, IdCuentaContable, IdGrupoCuenta, IdCentroCosto) 
 VALUES ((SELECT MAX(IdCuentaBanco)+1 FROM CuentasBancos),'Liquidaciones Tarjeta','I','False','False',NULL,1,NULL)

PRINT ''
PRINT '3.1. Nuevo Parámetro: Bancos: Cuenta Liquidación Tarjeta'
SET @idParametro = 'CTABANCOLIQUIDACIONTARJETA'
SET @descripcionParametro = 'Bancos: Cuenta Liquidación Tarjeta'
SET @valorParametro = (SELECT IdCuentaBanco FROM CuentasBancos WHERE NombreCuentaBanco = 'Liquidaciones Tarjeta')

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

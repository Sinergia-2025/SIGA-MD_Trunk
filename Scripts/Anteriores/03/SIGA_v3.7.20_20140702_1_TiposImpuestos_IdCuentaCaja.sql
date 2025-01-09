
ALTER TABLE TiposImpuestos ADD IdCuentaCaja	int	NULL
GO

INSERT INTO CuentasDeCajas
   (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
SELECT (select max(IdCuentaCaja) from CuentasDeCajas) + 1, NombreTipoImpuesto, 'E', 'False', 'False', '1', NULL FROM TiposImpuestos
 WHERE IdTipoImpuesto = 'RDREI'
GO
UPDATE TiposImpuestos SET IdCuentaCaja = (select max(IdCuentaCaja) from CuentasDeCajas) 
 WHERE IdTipoImpuesto = 'RDREI'
GO

INSERT INTO CuentasDeCajas
   (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
SELECT (select max(IdCuentaCaja) from CuentasDeCajas) + 1, NombreTipoImpuesto, 'E', 'False', 'False', '1', NULL FROM TiposImpuestos
 WHERE IdTipoImpuesto = 'RGANA'
GO
UPDATE TiposImpuestos SET IdCuentaCaja = (select max(IdCuentaCaja) from CuentasDeCajas) 
 WHERE IdTipoImpuesto = 'RGANA'
GO

INSERT INTO CuentasDeCajas
   (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
SELECT (select max(IdCuentaCaja) from CuentasDeCajas) + 1, NombreTipoImpuesto, 'E', 'False', 'False', '1', NULL FROM TiposImpuestos
 WHERE IdTipoImpuesto = 'RIIBB'
GO
UPDATE TiposImpuestos SET IdCuentaCaja = (select max(IdCuentaCaja) from CuentasDeCajas) 
 WHERE IdTipoImpuesto = 'RIIBB'
GO

INSERT INTO CuentasDeCajas
   (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
SELECT (select max(IdCuentaCaja) from CuentasDeCajas) + 1, NombreTipoImpuesto, 'E', 'False', 'False', '1', NULL FROM TiposImpuestos
 WHERE IdTipoImpuesto = 'RIVA'
GO
UPDATE TiposImpuestos SET IdCuentaCaja = (select max(IdCuentaCaja) from CuentasDeCajas) 
 WHERE IdTipoImpuesto = 'RIVA'
GO

INSERT INTO CuentasDeCajas
   (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
SELECT (select max(IdCuentaCaja) from CuentasDeCajas) + 1, NombreTipoImpuesto, 'E', 'False', 'False', '1', NULL FROM TiposImpuestos
 WHERE IdTipoImpuesto = 'RSIJP'
GO
UPDATE TiposImpuestos SET IdCuentaCaja = (select max(IdCuentaCaja) from CuentasDeCajas) 
 WHERE IdTipoImpuesto = 'RSIJP'
GO

INSERT INTO CuentasDeCajas
   (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
SELECT (select max(IdCuentaCaja) from CuentasDeCajas) + 1, NombreTipoImpuesto, 'E', 'False', 'False', '1', NULL FROM TiposImpuestos
 WHERE IdTipoImpuesto = 'RSUSS'
GO
UPDATE TiposImpuestos SET IdCuentaCaja = (select max(IdCuentaCaja) from CuentasDeCajas) 
 WHERE IdTipoImpuesto = 'RSUSS'
GO

INSERT INTO CuentasDeCajas
   (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
SELECT (select max(IdCuentaCaja) from CuentasDeCajas) + 1, 'Retencion Sellado No Fiscal', 'E', 'False', 'False', '1', NULL FROM TiposImpuestos
 WHERE IdTipoImpuesto = 'RSELL'
GO
UPDATE TiposImpuestos SET IdCuentaCaja = (select max(IdCuentaCaja) from CuentasDeCajas) 
 WHERE IdTipoImpuesto = 'RSELL'
GO

--ALTER TABLE TiposImpuestos ALTER COLUMN IdCuentaCaja int NOT NULL
--GO

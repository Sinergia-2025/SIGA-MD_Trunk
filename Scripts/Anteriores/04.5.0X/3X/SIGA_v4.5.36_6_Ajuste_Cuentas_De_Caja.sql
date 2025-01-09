SELECT * FROM CuentasDeCajas WHERE IdCuentaCaja BETWEEN 11 AND 17;

IF NOT EXISTS(SELECT IdCuentaCaja From dbo.CuentasDeCajas WHERE IdCuentaCaja = 11)
INSERT INTO dbo.CuentasDeCajas (IdCuentaCaja,NombreCuentaCaja,IdTipoCuenta,EsPosdatado,PideCheque,IdGrupoCuenta,IdCuentaContable)
						 VALUES(11,'Retencion de DREI','E','False','False',1,NULL);

IF NOT EXISTS(SELECT IdCuentaCaja From dbo.CuentasDeCajas WHERE IdCuentaCaja = 12)
INSERT INTO dbo.CuentasDeCajas (IdCuentaCaja,NombreCuentaCaja,IdTipoCuenta,EsPosdatado,PideCheque,IdGrupoCuenta,IdCuentaContable)
						 VALUES(12,'Retencion de Ganancias','E','False','False',1,NULL);
						 
IF NOT EXISTS(SELECT IdCuentaCaja From dbo.CuentasDeCajas WHERE IdCuentaCaja = 13)
INSERT INTO dbo.CuentasDeCajas (IdCuentaCaja,NombreCuentaCaja,IdTipoCuenta,EsPosdatado,PideCheque,IdGrupoCuenta,IdCuentaContable)
						 VALUES(13,'Retencion de Ingreso Brutos','E','False','False',1,NULL);
						 
IF NOT EXISTS(SELECT IdCuentaCaja From dbo.CuentasDeCajas WHERE IdCuentaCaja = 14)
INSERT INTO dbo.CuentasDeCajas (IdCuentaCaja,NombreCuentaCaja,IdTipoCuenta,EsPosdatado,PideCheque,IdGrupoCuenta,IdCuentaContable)
						 VALUES(14,'Retencion de IVA','E','False','False',1,NULL);
						 
IF NOT EXISTS(SELECT IdCuentaCaja From dbo.CuentasDeCajas WHERE IdCuentaCaja = 15)
INSERT INTO dbo.CuentasDeCajas (IdCuentaCaja,NombreCuentaCaja,IdTipoCuenta,EsPosdatado,PideCheque,IdGrupoCuenta,IdCuentaContable)
						 VALUES(15,'Retencion de SIJP','E','False','False',1,NULL);
						 
IF NOT EXISTS(SELECT IdCuentaCaja From dbo.CuentasDeCajas WHERE IdCuentaCaja = 16)
INSERT INTO dbo.CuentasDeCajas (IdCuentaCaja,NombreCuentaCaja,IdTipoCuenta,EsPosdatado,PideCheque,IdGrupoCuenta,IdCuentaContable)
						 VALUES(16,'Retencion de SUSS','E','False','False',1,NULL);
						 
IF NOT EXISTS(SELECT IdCuentaCaja From dbo.CuentasDeCajas WHERE IdCuentaCaja = 17)
INSERT INTO dbo.CuentasDeCajas (IdCuentaCaja,NombreCuentaCaja,IdTipoCuenta,EsPosdatado,PideCheque,IdGrupoCuenta,IdCuentaContable)
						 VALUES(17,'Retencion de Sellado No Fiscal','E','False','False',1,NULL);
GO

SELECT * FROM CuentasDeCajas WHERE IdCuentaCaja BETWEEN 11 AND 17;

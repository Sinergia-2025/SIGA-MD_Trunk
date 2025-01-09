
DECLARE @idProximaCuenta int;
----------------------------

PRINT '1. CuentasDeCajas: Creo la Cuenta para Extracciones'

SET @idProximaCuenta = (SELECT MAX(IdCuentaCaja)+1 AS xxIdCuentaCaja FROM CuentasDeCajas)

INSERT INTO CuentasDeCajas
     (IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
  VALUES
     (@idProximaCuenta, 'Extraccion Bancaria', 'I', 'False', 'False', 1, NULL)
;

PRINT '2. Parametros: Inserto Parametro Caja - Extraccion'

INSERT INTO Parametros
     (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
     ('CTACAJAEXTRACCION', convert(varchar(10), @idProximaCuenta) , null, 'Define la cuenta para movimientos de Extracciones Bancarias')
;


PRINT '3. CuentasBancos: Creo la Cuenta para Extracciones'

SET @idProximaCuenta = (SELECT MAX(IdCuentaBanco)+1 AS xxIdCuentaBanco FROM CuentasBancos)

INSERT INTO CuentasBancos
     (IdCuentaBanco, NombreCuentaBanco, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta, IdCuentaContable)
  VALUES
     (@idProximaCuenta, 'Extraccion Bancaria', 'E', 'False', 'False', 1, NULL)
;

PRINT '4. Parametros: Inserto Parametro Banco - Extraccion'

INSERT INTO Parametros
     (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
     ('CTABANCOEXTRACCION', convert(varchar(10), @idProximaCuenta) , null, 'Define la cuenta para movimientos de Extracciones Bancaria')
;


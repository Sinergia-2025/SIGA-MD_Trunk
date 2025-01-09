

INSERT INTO Parametros 
    (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
    ('CTACAJAMOVCHEQUES', '7', NULL, 'Define la cuenta para movimientos de Cheques entre Sucursales')

INSERT CuentasDeCajas
(IdCuentaCaja, NombreCuentaCaja, IdTipoCuenta, EsPosdatado, PideCheque, IdGrupoCuenta)
VALUES
(7, 'Mov. Cheques entre sucursales', 'E', 0, 0, '1')


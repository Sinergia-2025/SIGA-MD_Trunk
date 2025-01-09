
SELECT a.IdCuentaBancaria, a.NombreCuenta, b.Saldo, c.SaldoConciliado  FROM CuentasBancarias a
 LEFT OUTER JOIN 
(
SELECT IdCuentaBancaria, Sum(Importe) AS Saldo FROM LibrosBancos 
 WHERE CONVERT(varchar(10), FechaAplicado, 120) <= '2020-12-31'
 GROUP BY IdCuentaBancaria
) b ON a.IdCuentaBancaria = b.IdCuentaBancaria
 LEFT OUTER JOIN 
(
SELECT IdCuentaBancaria, Sum(Importe) AS SaldoConciliado FROM LibrosBancos 
 WHERE CONVERT(varchar(10), FechaAplicado, 120) <= '2020-12-31'
   AND Conciliado = 1
 GROUP BY IdCuentaBancaria
) c ON a.IdCuentaBancaria = c.IdCuentaBancaria
  WHERE a.IdMoneda = 2
  AND (b.Saldo <> 0 OR c.SaldoConciliado <> 0)
--   AND a.Activo = 1
 ORDER BY a.NombreCuenta

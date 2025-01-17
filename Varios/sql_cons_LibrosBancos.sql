
SELECT CB.NombreCuentaBanco, LB.*
  FROM LibrosBancos LB, CuentasBancos CB
 WHERE LB.IdCuentaBanco = CB.IdCuentaBanco
 --IdCuentaBanco IN (233, 228, 147, 227, 40, 196 )
 AND 
( (CONVERT(varchar(11), LB.FechaMovimiento, 120) >= '2012-06-01'
        AND CONVERT(varchar(11), LB.FechaMovimiento, 120) <= '2012-06-31')
       OR
       (CONVERT(varchar(11), LB.FechaAplicado, 120) >= '2012-06-01'
        AND CONVERT(varchar(11), LB.FechaAplicado, 120) <= '2012-06-31')
 )
 ORDER BY FechaAplicado
GO

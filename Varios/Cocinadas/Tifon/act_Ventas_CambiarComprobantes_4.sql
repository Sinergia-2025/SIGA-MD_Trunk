UPDATE Ventas
   SET Fecha = Fecha+12 
WHERE IdTipoComprobante = 'LIQUIDO'
  AND Letra = 'M'
  AND CONVERT(varchar(11), Fecha, 120) = '2018-12-31'
GO

UPDATE MovimientosVentas
   SET FechaMovimiento = FechaMovimiento+12 
WHERE IdTipoComprobante = 'LIQUIDO'
  AND Letra = 'M'
  AND CONVERT(varchar(11), FechaMovimiento, 120) = '2018-12-31'
GO



UPDATE CuentasCorrientes
   SET Fecha = Fecha+12
      ,FechaVencimiento = FechaVencimiento+12
WHERE IdTipoComprobante = 'LIQUIDO'
  AND Letra = 'M'
  AND CONVERT(varchar(11), Fecha, 120) = '2018-12-31'
GO

UPDATE CuentasCorrientesPagos
   SET Fecha = Fecha+12
      ,FechaVencimiento = FechaVencimiento+12
WHERE IdTipoComprobante = 'LIQUIDO'
  AND Letra = 'M'
  AND CONVERT(varchar(11), Fecha, 120) = '2018-12-31'
GO


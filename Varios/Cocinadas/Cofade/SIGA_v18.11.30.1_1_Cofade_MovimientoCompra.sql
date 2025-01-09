
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30680482132'))
BEGIN
    UPDATE MovimientosCompras
       SET NumeroComprobante = 2
      WHERE IdSucursal = 1 AND IdTipoMovimiento = 'COMPRA' AND NumeroMovimiento = 6739
END
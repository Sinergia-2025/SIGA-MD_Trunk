PRINT ''
PRINT '1. Calculo de valores iniciales para Estrellas de Clientes'

IF dbo.SoyHAR() = 'True'
BEGIN
    DECLARE @fechaDesde datetime = '20200301'
    DECLARE @fechaHasta date = DATEADD(Month, 1, @fechaDesde)

    PRINT ''
    PRINT '1.1. Determino el total facturado del mes pasado (Marzo 2020)'
    UPDATE C
       SET ValorizacionFacturacionMensual = V.ImporteTotal
      FROM Clientes C
     INNER JOIN (SELECT IdCliente, SUM(ImporteTotal) ImporteTotal
                   FROM Ventas
                  WHERE Fecha >= @fechaDesde AND Fecha < @fechaHasta
                  GROUP BY IdCliente) V ON V.IdCliente = C.IdCliente

    PRINT ''
    PRINT '1.2. Determino la deuda total de cada cliente'
    UPDATE C
       SET ValorizacionImporteAdeudado = CC.Saldo
      FROM Clientes C
     INNER JOIN (SELECT C.IdCliente
                      , C.CodigoCliente
                      , SUM(CCP.SaldoCuota) AS Saldo
                   FROM CuentasCorrientesPagos CCP
                  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal
                                                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante
                                                 AND CC.Letra = CCP.Letra
                                                 AND CC.CentroEmisor = CCP.CentroEmisor
                                                 AND CC.NumeroComprobante = CCP.NumeroComprobante
                  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente
                  GROUP BY C.IdCliente,C.CodigoCliente
                  HAVING SUM(CCP.SaldoCuota) <> 0) CC ON CC.IdCliente = C.IdCliente

    PRINT ''
    PRINT '1.3. Predefino los coeficientes en 1'
    UPDATE Clientes
       SET ValorizacionCoeficienteFacturacion = 1
         , ValorizacionCoeficienteDeuda = 1

    PRINT ''
    PRINT '1.4. Valorizo la facturación y la deuda'
    UPDATE Clientes
       SET ValorizacionFacturacion = ValorizacionFacturacionMensual * ValorizacionCoeficienteFacturacion
         , ValorizacionDeuda = ValorizacionImporteAdeudado * ValorizacionCoeficienteDeuda
    ;

    PRINT ''
    PRINT '1.5. Valorizo el cliente'
    UPDATE Clientes
       SET ValorizacionCliente = ValorizacionFacturacion + ValorizacionDeuda + ValorizacionProyecto
    ;

    PRINT ''
    PRINT '1.6. Calculo las estrellas'
    UPDATE C
       SET ValorizacionEstrellas = CONVERT(DECIMAL(5,2), ROUND(C.ValorizacionCliente / CT.ValorizacionClienteMaxima * 10, 2))
      FROM Clientes C
     CROSS JOIN (SELECT MAX(ValorizacionCliente) ValorizacionClienteMaxima FROM Clientes) AS CT
    ;

END
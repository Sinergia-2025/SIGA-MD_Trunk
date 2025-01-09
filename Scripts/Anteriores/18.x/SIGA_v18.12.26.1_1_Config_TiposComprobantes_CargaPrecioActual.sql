PRINT '1. Configurar Cotización y Factura para que cargue precio actual al invocar'
--SOLO PARA ALOE
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('23238857449'))
BEGIN
    UPDATE TiposComprobantes
       SET CargaPrecioActual = 1
     WHERE IdTipoComprobante IN ('COTIZACION', 'FACT', 'ePre-FACT')
END
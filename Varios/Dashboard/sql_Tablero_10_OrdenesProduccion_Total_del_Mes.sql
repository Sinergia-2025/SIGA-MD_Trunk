--SELECT * FROM OrdenesProduccion OP
SELECT COUNT(OP.IdSucursal) FROM OrdenesProduccion OP
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = OP.IdTipoComprobante AND TC.Tipo = 'PRODUCCION'
 INNER JOIN OrdenesProduccionEstados OPE ON OP.IdSucursal = OP.IdSucursal 
                                 AND OPE.IdTipoComprobante = OP.IdTipoComprobante
                                 AND OPE.Letra = OP.Letra
                                 AND OPE.CentroEmisor = OP.CentroEmisor
                                 AND OPE.NumeroOrdenProduccion = OP.NumeroOrdenProduccion
 INNER JOIN EstadosOrdenesProduccion EOP ON EOP.IdEstado = OPE.IdEstado AND EOP.IdTipoEstado NOT IN ('ANULADO','RECHAZADO')
 WHERE OP.IdSucursal >= 1
   AND YEAR(OP.FechaOrdenProduccion) = YEAR(GETDATE())
   AND MONTH(OP.FechaOrdenProduccion) = MONTH(GETDATE())
;


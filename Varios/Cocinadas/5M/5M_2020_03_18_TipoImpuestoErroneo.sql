UPDATE VentasImpuestos
   SET IdTipoComprobante = 'IMINT'
 WHERE IdSucursal = 2
   AND IdTipoComprobante = 'TICKET-F'
   AND Letra = 'B'
   AND CentroEmisor = 2
   AND NumeroComprobante = 22976
   AND Alicuota = 0

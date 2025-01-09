select fecha, numerocomprobante, ImporteBruto, SubTotal, DescuentoRecargo,  IvaInscripto, Importetotal, round(SubTotal*0.21,2) as nuevoiva
 from ventas V
where CONVERT(varchar(11), V.fecha, 120) >= '2010-10-01'
   AND CONVERT(varchar(11), V.fecha, 120) <= '2010-10-31'
  and IdTipoComprobante = 'TICKET-F'
  and IvaInscripto<>round(SubTotal*0.21,2)

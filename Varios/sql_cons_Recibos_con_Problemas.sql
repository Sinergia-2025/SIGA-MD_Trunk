select * FROM CuentasCorrientes
 where IdTipoComprobante='RECIBO'
  and Letra='X'
  and CentroEmisor=1
  and NumeroComprobante in (26,33,36,46,51,54,65,71,101,86,90,92,102,108,110,117,121,131,136,146,279)
  and IdSucursal=1


delete CuentasCorrientes
 where IdTipoComprobante='RECIBO'
  and Letra='X'
  and CentroEmisor=1
  and NumeroComprobante in (26,33,36,46,51,54,65,71,101,86,90,92,102,108,110,117,121,131,136,146,279)
  and IdSucursal=1



select * FROM CuentasCorrientesPagos
 where IdTipoComprobante='RECIBO'
  and Letra='X'
  and CentroEmisor=1
  and NumeroComprobante in (26,33,36,46,51,54,65,71,101,86,90,92,102,108,110,117,121,131,136,146,279)
  and IdSucursal=1
  


delete CuentasCorrientesPagos
 where IdTipoComprobante='RECIBO'
  and Letra='X'
  and CentroEmisor=1
  and NumeroComprobante in (26,33,36,46,51,54,65,71,101,86,90,92,102,108,110,117,121,131,136,146,279)
  and IdSucursal=1
  


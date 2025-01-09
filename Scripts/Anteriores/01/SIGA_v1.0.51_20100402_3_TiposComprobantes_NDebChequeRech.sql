
INSERT INTO TiposComprobantes
  (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, 
   LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador,
   AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, 
   EsRemitoTransportista, ComprobantesAsociados, EsComercial)
 VALUES
   ('NDEBCHEQRECH', 'False', 'N.Deb. Cheq. Rech.', 'VENTAS', -1, 'True', 'False', 
   'A,B,C', 100, 'True', 1, NULL, 'False', 
   'True', 'True', 'True', 'NDeb.ChRec', 'False', 2, 
   'False', NULL, 'False')
GO

/* --------------------- */


INSERT INTO VentasNumeros
  (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero, IdTipoComprobanteRelacionado)
SELECT 'NDEBCHEQRECH', 'A', I.CentroEmisor, I.IdSucursal, 0, 'FACT,NCRED,NDEB'
  FROM Impresoras I WHERE I.TipoImpresora='NORMAL'
GO

INSERT INTO VentasNumeros
  (IdTipoComprobante, LetraFiscal, CentroEmisor, IdSucursal, Numero, IdTipoComprobanteRelacionado)
SELECT 'NDEBCHEQRECH', 'B', I.CentroEmisor, I.IdSucursal, 0, 'FACT,NCRED,NDEB'
  FROM Impresoras I WHERE I.TipoImpresora='NORMAL'
GO

UPDATE VentasNumeros SET
  IdTipoComprobanteRelacionado = 'NCRED,NDEB,NDEBCHEQRECH'
  WHERE IdTipoComprobante = 'FACT'
GO

UPDATE VentasNumeros SET
  IdTipoComprobanteRelacionado = 'FACT,NDEB,NDEBCHEQRECH'
  WHERE IdTipoComprobante = 'NCRED'
GO

UPDATE VentasNumeros SET
  IdTipoComprobanteRelacionado = 'FACT,NCRED,NDEBCHEQRECH'
  WHERE IdTipoComprobante = 'NDEB'
GO

UPDATE VentasNumeros  SET
  Numero = (SELECT Numero FROM VentasNumeros B WHERE B.IdTipoComprobante = 'FACT'
                                                 AND VentasNumeros.LetraFiscal = B.LetraFiscal 
                                                 AND VentasNumeros.CentroEmisor = B.CentroEmisor)
                                                 
  WHERE IdTipoComprobante = 'NDEBCHEQRECH'
GO

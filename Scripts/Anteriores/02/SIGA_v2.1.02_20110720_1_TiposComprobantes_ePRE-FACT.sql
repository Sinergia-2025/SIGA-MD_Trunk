DELETE TiposComprobantes WHERE IdTipoComprobante = 'eREMITO'
GO

INSERT INTO TiposComprobantes 

     (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable

     ,LetrasHabilitadas, CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador

     ,AfectaCaja, CargaPrecioActual, ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias

     ,EsRemitoTransportista, ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario

     ,ImporteTope, IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion)

  VALUES ('ePRE-FACT', 'False', ' ePre-Factura', 'VENTAS', 0, 'False' , 'False'

         ,'A,B,C', 24, 'True', 1, 'SOLOPRECIOS', 'True'

         ,'False', 'True', 'True' ,'ePre-Fact.' ,'False', 2

         ,'False', NULL, 'False' ,0 , NULL

         ,0 ,'.' , 'False', 0.10 , 'True', 'True')
GO

UPDATE VentasNumeros SET
     IdTipoComprobante = 'ePRE-FACT'
  WHERE IdTipoComprobante = 'eREMITO'
GO

UPDATE Impresoras SET
     ComprobantesHabilitados = 'ePRE-FACT,eFACT,eNCRED'
  WHERE IdImpresora = 'ELECTRONICA'
GO

UPDATE AFIPTiposComprobantesTiposCbtes SET
     IdTipoComprobante = 'ePRE-FACT'
  WHERE IdTipoComprobante = 'eREMITO'
GO

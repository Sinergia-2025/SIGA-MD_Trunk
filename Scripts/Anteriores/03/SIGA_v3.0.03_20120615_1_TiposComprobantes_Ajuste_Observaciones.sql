
UPDATE TiposComprobantes 
   SET GeneraObservConInvocados = 'True'
      ,CantidadMaximaItemsObserv = CantidadMaximaItems -1
 WHERE Tipo = 'VENTAS'
GO

UPDATE TiposComprobantesLetras
   SET CantidadItemsObservaciones = CantidadItemsProductos -1
 WHERE IdTipoComprobante IN 
      (SELECT IdTipoComprobante FROM TiposComprobantes 
        WHERE Tipo = 'VENTAS')
GO



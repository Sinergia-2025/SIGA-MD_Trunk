UPDATE Productos SET
       EsDeCompras = 'True'
      ,EsDeVentas = 'True'
  WHERE EsDeCompras = 'False' AND EsDeVentas = 'False'
GO

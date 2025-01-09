
UPDATE Productos 
  SET Kilos = Embalaje *
        (SELECT P2.Tamano*UdM.ConversionAKilos AS Peso
           FROM Productos P2, UnidadesDeMedidas UdM
          WHERE Productos.IdProducto = P2.IdProducto
            AND P2.IdUnidadDeMedida = UdM.IdUnidadDeMedida)
 WHERE IdUnidadDeMedida IS NOT NULL
GO


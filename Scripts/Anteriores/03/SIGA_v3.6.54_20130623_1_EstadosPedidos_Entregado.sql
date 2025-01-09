
INSERT INTO EstadosPedidos
    (idEstado, IdTipoComprobante, IdTipoEstado, Orden)
 SELECT 'ENTREGADO', NULL, 'ENTREGADO', Orden FROM EstadosPedidos
  WHERE IdEstado = 'FINALIZADO'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros
            WHERE IdParametro = 'MODULOPRODUCCION'
              AND ValorParametro = 'True')
    BEGIN
		UPDATE EstadosPedidos 
	  	   SET Orden = Orden+1
         WHERE IdEstado = 'ENTREGADO'
    END
ELSE
    BEGIN
		UPDATE EstadosPedidos 
	  	   SET Orden = Orden+1
         WHERE IdEstado = 'FINALIZADO'
    END
GO

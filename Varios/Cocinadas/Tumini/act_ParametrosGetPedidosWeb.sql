
UPDATE Parametros
   SET ValorParametro = 'http://w1021701.ferozo.com/webmovil/api/PedidosPendientes'
 WHERE IdParametro = 'PEDIDOSURLWEBGET'
UPDATE Parametros
   SET ValorParametro = 'http://w1021701.ferozo.com/webmovil/api/Pedidos'
 WHERE IdParametro = 'PEDIDOSURLWEBPUT'

SELECT *
  FROM Parametros
 WHERE IdParametro IN ('PEDIDOSURLWEBGET','PEDIDOSURLWEBPUT')

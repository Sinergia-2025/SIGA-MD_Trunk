SELECT count(*) FROM Clientes
 where nrodocumento='09625' ;

SELECT count(*) FROM CartasAClientes
 where nrodocumento='09625' or nrodocumentogarante='09625';

SELECT count(*) FROM ClientesSucursales
 where nrodocumento='09625';
 
SELECT count(*) FROM Fichas
 where nrodocumento='09625';

SELECT count(*) FROM FichasProductos
 where nrodocumento='09625';

SELECT count(*) FROM FichasPagos
 where nrodocumento='09625';

SELECT count(*) FROM FichasPagosDetalle
 where nrodocumento='09625';

SELECT count(*) FROM FichasPagosAjustes
 where nrodocumento='09625';

SELECT count(*) FROM Ventas
 where nrodoccliente='09625';      

SELECT count(*) FROM MovimientosVentas
 where nrodoccliente='09625';      

SELECT count(*) FROM CuentasCorrientes
 where nrodoccliente='09625'; 

SELECT count(*) FROM RecepcionNotas
 where nrodocumento='09625' ;

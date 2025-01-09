
--BORRA ORDENES DE COMPRA/ENVIOS/ACTIVACIONES por Nro de Orden de Compra


declare @tipocomprobante varchar(15) = 'OC' --CAMBIAR TIPO COMPROBANTE 
declare @numeropedido bigint = 73476		--CAMBIAR NUMERO OC

--select *
DELETE 
FROM  CalidadOCActivaciones 
where idsucursal = 1
AND idtipocomprobante = @tipocomprobante  
AND letra = 'X'
AND centroemisor = 1
AND numeropedido = @numeropedido 

--select *
DELETE 
FROM  calidadEnviosOC 
where idsucursal = 1
AND idtipocomprobante = @tipocomprobante 
AND letra = 'X'
AND centroemisor = 1
AND numeropedido = @numeropedido  

--select *
DELETE 
FROM  pedidosestadosproveedores 
where idsucursal = 1
AND idtipocomprobante = @tipocomprobante    
AND letra = 'X'
AND centroemisor = 1
AND numeropedido = @numeropedido     

--select *
DELETE 
FROM  pedidosproductosproveedores 
where idsucursal = 1
AND idtipocomprobante = @tipocomprobante 
AND letra = 'X'
AND centroemisor = 1
AND numeropedido = @numeropedido     


--select *
DELETE 
FROM  pedidosproveedores 
where idsucursal = 1
AND idtipocomprobante = @tipocomprobante  
AND letra = 'X'
AND centroemisor = 1
AND numeropedido = @numeropedido    
GO 
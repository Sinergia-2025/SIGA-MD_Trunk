
-- Actualiza desde la Auditoria en caso de Problemas/Errores

UPDATE Productos 
   SET Productos.IdProveedor = AP.IdProveedor
      ,Productos.Kilos = AP.Kilos
 FROM Productos P
 INNER JOIN AuditoriaProductos AP ON AP.IdProducto = P.IdProducto
	--Lo correcto seria un TOP o algo asi. 
      AND CONVERT(varchar(11), AP.FechaAuditoria, 120) >= '2019-01-11'
      AND AP.IdProveedor > 0
 WHERE P.IdProveedor IS NULL
GO

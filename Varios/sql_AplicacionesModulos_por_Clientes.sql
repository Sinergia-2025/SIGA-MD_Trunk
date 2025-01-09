--SELECT * FROM AplicacionesModulos
-- WHERE IdModulo IN (49, 50, 87)
--GO

-- IdModulo	NombreModulo
--49	Service
--50	ServiceF
--87	Servicio Tecnico (CRM)

SELECT CAM.IdModulo, AP.NombreModulo, CAM.IdCliente, C.CodigoCliente, C.NombreDeFantasia
  FROM ClientesAplicacionesModulos CAM
 INNER JOIN Clientes C ON C.IdCliente = CAM.IdCliente
 INNER JOIN AplicacionesModulos AP ON AP.IdModulo = CAM.IdModulo
 WHERE CAM.IdModulo IN (49, 50, 87)
-- WHERE CAM.IdModulo	= 49 
--   AND CAM.IdCliente	= 404

 ORDER BY  AP.NombreModulo, C.NombreDeFantasia
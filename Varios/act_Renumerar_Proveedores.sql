SELECT IdProveedor, CodigoProveedor, NombreProveedor FROM Proveedores
 ORDER BY NombreProveedor
GO

UPDATE Proveedores 
  SET CodigoProveedor = NumeroRegistro 
 FROM Proveedores
 INNER JOIN 
  (SELECT IdProveedor, row_number() OVER (ORDER BY NombreProveedor) AS NumeroRegistro
     FROM Proveedores) TablaNumerada ON TablaNumerada.IdProveedor = Proveedores.IdProveedor
GO

--UPDATE AuditoriaProveedores
--   SET AuditoriaProveedores.CodigoProveedor = C.CodigoProveedor
-- FROM AuditoriaProveedores AC
-- INNER JOIN Proveedores C ON AC.IdProveedor = C.IdProveedor
---- WHERE V.Direccion IS NULL
--GO

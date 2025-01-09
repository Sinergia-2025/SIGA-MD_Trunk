
SELECT V.NombreEmpleado as Vendedor
      ,CD.NroDocumento AS CodigoCliente
      ,C.NombreCliente
      ,M.IdMarca
      ,M.NombreMarca
      ,CD.DescuentoRecargoPorc1
      ,CD.DescuentoRecargoPorc2
      ,C.Direccion
      ,L.NombreLocalidad as Localidad
      ,P.NombreProvincia as Provincia
      ,C.Telefono + ' ' + C.Celular as Telefonos
 FROM ClientesDescuentosMarcas CD 
 INNER JOIN Marcas M ON M.IdMarca = CD.IdMarca 
 INNER JOIN Clientes C ON C.TipoDocumento = CD.tipodocumento AND C.NroDocumento = CD.NroDocumento 
 INNER JOIN Empleados V ON V.TipoDocEmpleado = C.TipoDocVendedor AND V.NroDocEmpleado = C.NroDocVendedor
 INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad
 INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia
  ORDER BY M.NombreMarca

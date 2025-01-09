
SELECT 'xx' as Empresa
      ,C.CodigoCliente
      ,C.NombreCliente
	  ,C.NombreDeFantasia
      ,C.Direccion
      ,C.IdLocalidad
      ,L.NombreLocalidad
      ,P.NombreProvincia
      ,Cf.NombreCategoriaFiscal
      ,Ca.NombreCategoria
      ,C.CorreoElectronico
      ,C.Telefono
      ,C.Celular
      ,C.Cuit
      ,C.IdZonaGeografica
      ,Z.NombreZonaGeografica
      ,C.FechaNacimiento
      ,C.IdCategoria
      ,C.IdCategoriaFiscal
      ,C.Observacion
      ,C.Activo
      ,C.IdListaPrecios
      ,LdP.NombreListaPrecios
      ,E.IdEmpleado
      ,E.NombreEmpleado AS NombreVendedor

 FROM Clientes C   
 LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad 
 LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia 
 LEFT JOIN ZonasGeograficas Z  ON Z.IdZonaGeografica = C.IdZonaGeografica
 LEFT JOIN Categorias Ca ON C.IdCategoria = Ca.IdCategoria
 LEFT JOIN CategoriasFiscales Cf ON C.IdCategoriaFiscal = Cf.IdCategoriaFiscal
 LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado
 LEFT JOIN ListasDePrecios LdP ON C.IdListaPrecios = LdP.IdListaPrecios

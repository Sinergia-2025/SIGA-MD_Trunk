
SELECT 'xx' as Empresa
      ,C.CodigoProveedor
      ,C.NombreProveedor
      ,C.DireccionProveedor
      ,C.IdLocalidadProveedor
      ,L.NombreLocalidad
      ,P.NombreProvincia
      ,Cf.NombreCategoriaFiscal
      ,Ca.NombreCategoria
      ,C.CorreoElectronico
      ,C.TelefonoProveedor
      ,C.CuitProveedor
      ,C.TipoDocProveedor
      ,C.NroDocProveedor
      ,C.IdCategoria
      ,C.IdCategoriaFiscal
      ,C.Observacion
      ,C.Activo
 FROM Proveedores C   
 LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidadProveedor 
 LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia 
 LEFT JOIN Categorias Ca ON C.IdCategoria = Ca.IdCategoria
 LEFT JOIN CategoriasFiscales Cf ON C.IdCategoriaFiscal = Cf.IdCategoriaFiscal
GO

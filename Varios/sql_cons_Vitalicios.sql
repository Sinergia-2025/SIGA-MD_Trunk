
SELECT C.CodigoCliente, C.NombreCliente, C.TipoDocCliente, C.NroDocCliente, C.Telefono, C.Celular
     , CONVERT(varchar(11),c.FechaNacimiento, 120) AS Nacimiento
     , Cat.NombreCategoria
      --, C.CorreoElectronico
 FROM Clientes C
 INNER JOIN Categorias Cat ON Cat.IdCategoria = C.IdCategoria
 WHERE C.Activo = 'True'
--  AND CONVERT(varchar(11), C.FechaNacimiento, 120) <= '2010-09-01' --- Clientes Mayores de Edad
  AND C.IdCategoria = 2 -- Vitalicio
 ORDER BY C.NombreCliente

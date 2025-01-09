
SELECT C.CodigoCliente, C.NombreCliente, C.TipoDocCliente, C.NroDocCliente, C.Telefono, C.Celular
     , CONVERT(varchar(11),c.FechaNacimiento, 120) AS Nacimiento
     , Cat.NombreCategoria
      ,CC.SaldoPendiente
      --, C.CorreoElectronico
 FROM Clientes C
 INNER JOIN Categorias Cat ON Cat.IdCategoria = C.IdCategoria
 INNER JOIN (SELECT IdCliente, SUM(Saldo) AS SaldoPendiente
               FROM CuentasCorrientes
              GROUP BY IdCliente
--              HAVING SUM(Saldo)<=0
             ) CC ON CC.IdCliente = C.IdCliente
 WHERE C.Activo = 'True'
  AND CONVERT(varchar(11), C.FechaNacimiento, 120) <= '2000-09-01' --- Clientes Mayores de Edad
 ORDER BY C.NombreCliente

 
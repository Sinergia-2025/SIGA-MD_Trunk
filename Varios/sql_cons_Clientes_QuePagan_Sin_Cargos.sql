
SELECT Ca.IdCategoria, Ca.NombreCategoria, Cl.NombreCliente, Cl.NombreDeFantasia
 FROM Clientes Cl 
 INNER JOIN Categorias Ca ON Ca.IdCategoria = Cl.IdCategoria
 WHERE Ca.IdGrupoCategoria = 'Cobrar'
  -- 2 Abono Secundario, 10 Eventual
  AND Ca.IdCategoria NOT IN (2, 10, 14, 15, 25)
  AND NOT EXISTS 
     (SELECT * FROM CargosClientes CC
       WHERE CC.IdCliente = Cl.IdCliente
      )
ORDER BY 1, 2
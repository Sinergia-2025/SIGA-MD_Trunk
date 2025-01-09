
UPDATE Clientes 
   SET Clientes.IdCalle = Origen.IdCalle
      ,Clientes.Altura = Origen.Altura
	  ,Clientes.DireccionAdicional = Origen.DireccionAdicional
	  ,Clientes.IdCalle2 = Origen.IdCalle2
      ,Clientes.Altura2 = Origen.Altura2
	  ,Clientes.DireccionAdicional2 = Origen.DireccionAdicional2
 FROM SIGA.dbo.Clientes Destino 
 INNER JOIN SILIVE.dbo.CLientes Origen ON Destino.IdCliente = Origen.IdCliente
 WHERE Destino.IdCalle = 1
GO

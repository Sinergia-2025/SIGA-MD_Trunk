PRINT ''
PRINT '1. Clientes que no tienen Liquidacion en la actual.'

SELECT * FROM LiquidacionesDetallesClientes LDC
 where LDC.PeriodoLiquidacion = 202007
 AND NOT EXISTS 
     (SELECT * FROM CargosClientes CC
       WHERE CC.IdCliente = LDC.IdCliente
      )
GO

PRINT '2. Clientes que son nuevos en la Liquidacion actual.'
SELECT Cl.NombreCliente , CC.* FROM CargosClientes CC
 INNER JOIN Clientes CL ON Cl.IdCliente = CC.IdCliente
 WHERE NOT EXISTS 
     (SELECT * FROM LiquidacionesDetallesClientes LDC
       WHERE CC.IdCliente = LDC.IdCliente
	    AND LDC.PeriodoLiquidacion = 202007
      )
GO


--- ATENCION QUE HAY QUE ADAPTAR EL QUERY POR SI EL PRODUCTO TIENE MAS DE UNA FORMULA
--- USAR EL TOP(1)

PRINT ''
PRINT '1. Actualizo la formula predeterminada.'
GO

UPDATE Productos 
   SET Productos.IdFormula = PF.IdFormula
 FROM Productos P
 INNER JOIN ProductosFormulas PF ON PF.IdProducto = P.IdProducto
 WHERE P.EsCompuesto = 'True'
   AND P.IdFormula IS NULL
GO



PRINT ''
PRINT '2. Reviso cuando Productos quedan EsCompuesto=True pero sin formula.'
GO

--SELECT IdProducto, NombreProducto, IdFormula, FechaActualizacionWeb
-- FROM Productos
--WHERE EsCompuesto=  'True'
--  AND IdFormula IS NULL
--GO

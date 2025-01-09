
SELECT RequiereRevisionAdministrativa, idcategoria, nombrecategoria, IdGrupoCategoria, ControlaBackup
 FROM Categorias
-- WHERE IdCategoria = 22
-- order by nombrecategoria
GO

SELECT CodigoCliente, NombreCliente, FechaAlta FROM Clientes
 WHERE IdCategoria = 22

--UPDATE Clientes
--  SET FechaInicio = FechaAlta
--    , FechaInicioReal = FechaAlta
--WHERE IdCategoria IN (1, 2, 4, 5, 7, 8, 10, 11, 12, 13, 14, 15, 16, 18, 19, 23)
--GO

-- NO
--  3. CUOTAS +
--  6. PROSPECTO
--  9. CUOTAS INACTIVO
-- 17. PAUSA
-- 22. ABONO PAUSA (PARAA QUE ??)
-- 20. CUOTAS BLUE
-- 21. CUOTAS PAUSA

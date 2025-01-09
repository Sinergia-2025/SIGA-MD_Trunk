
SELECT DISTINCT NombreCategoria
  FROM LiquidacionesCargos
  ORDER BY 1

SELECT * FROM LiquidacionesCargos
 WHERE NombreCategoria = '0. A Largar'
GO


--UPDATE LiquidacionesCargos
--  SET NombreCategoria = 'Pausa'
-- WHERE NombreCategoria = 'Abono (Pausa)'
--GO

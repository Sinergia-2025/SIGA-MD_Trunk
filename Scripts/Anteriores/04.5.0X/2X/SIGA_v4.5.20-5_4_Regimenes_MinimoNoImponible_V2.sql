
UPDATE Regimenes
   SET MinimoNoImponible = 0
 WHERE IdTipoImpuesto <> 'RGANA'
GO

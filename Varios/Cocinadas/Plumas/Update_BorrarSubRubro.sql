UPDATE Productos
   SET IdSubRubro = NULL
 WHERE ISNULL(IdSubRubro, 0) <> 0
UPDATE AuditoriaProductos
   SET IdSubRubro = NULL
 WHERE ISNULL(IdSubRubro, 0) <> 0
DELETE FROM SubRubros

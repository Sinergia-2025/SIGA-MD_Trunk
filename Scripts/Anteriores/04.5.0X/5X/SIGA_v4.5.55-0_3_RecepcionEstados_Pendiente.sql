
--- Reemplazo el Estado "Devuelto" por "Pendiente" para hacerlo mas Generico.

UPDATE RecepcionEstados 
   SET NombreEstado = 'Pendiente' 
 WHERE IdEstado = 10
;

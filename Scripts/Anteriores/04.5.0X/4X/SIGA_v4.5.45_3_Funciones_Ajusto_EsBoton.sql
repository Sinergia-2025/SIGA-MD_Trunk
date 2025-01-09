
-- Quito el espacio utilizado por Consultar Planillas y se lo Asigno al ABM de Productos.

UPDATE Funciones
   SET EsBoton = 'False'
 WHERE Id = 'ConsultarPlanillas';

UPDATE Funciones
   SET EsBoton = 'True'
 WHERE Id = 'Productos';

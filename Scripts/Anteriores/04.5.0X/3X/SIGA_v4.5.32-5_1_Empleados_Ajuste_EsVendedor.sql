
-- Corregir Inconsistencia - Establecer Empleados con Usuario Asociado como Vendedor

UPDATE Empleados
   SET EsVendedor = 'True'
 WHERE IdUsuario IS NOT NULL
   AND EsVendedor = 'False'
;

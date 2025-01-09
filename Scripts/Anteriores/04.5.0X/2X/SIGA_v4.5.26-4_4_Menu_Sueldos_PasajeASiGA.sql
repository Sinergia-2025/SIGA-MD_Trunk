
UPDATE Funciones
   SET Archivo = 'Eniac.Win'
 WHERE IdPadre = 'Sueldos'
GO
 
-- Invierto las Posiciones
UPDATE Funciones
   SET Posicion = 20
 WHERE ID  = 'SueldosConceptosMasivo'
GO

UPDATE Funciones
   SET Posicion = 10
 WHERE ID  = 'SueldosConceptosPersonal'
GO
 

PRINT ''
PRINT '1. PreventaV2: Deshabilitar funci�n'
UPDATE Funciones
   SET Enabled = 'False'
     , Visible = 'False'
 WHERE Id = 'PreventaV2'

PRINT ''
PRINT '2. Tabla VersionesScriptsEjecuciones: Ajustar ancho de columna Mensaje'
ALTER TABLE VersionesScriptsEjecuciones ALTER COLUMN Mensaje varchar(200) NULL
GO

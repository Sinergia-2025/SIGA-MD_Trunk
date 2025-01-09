UPDATE Funciones
   SET Archivo = 'Eniac.Win'
 WHERE Id IN ('Backups', 'CopiarComprobantes', 'SolicitarCAE')

UPDATE Funciones
   SET Visible = 'True'
 WHERE Id = 'Backups'

UPDATE Funciones
   SET Visible = 'False'
 WHERE Id IN ('RutasABM', 'RutasClientes')

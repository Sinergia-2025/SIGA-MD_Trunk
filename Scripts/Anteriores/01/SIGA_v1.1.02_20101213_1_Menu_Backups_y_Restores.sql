
UPDATE Funciones
   SET Nombre = 'Backup - Copia de Seguridad del Sistema'
      ,Descripcion = 'Backup - Copia de Seguridad del Sistema'
   WHERE id = 'Backups'
GO

UPDATE Funciones
   SET Nombre = 'Restaurar Informaci�n desde Backup'
      ,Descripcion = 'Restaurar Informaci�n desde Backup'
   WHERE id = 'Restores'
GO


PRINT '1. Muestro las Tablas con IdUsuario Distinto a 10.'
GO
SELECT Table_name, Column_Name, Data_Type, CHARACTER_MAXIMUM_LENGTH
  FROM INFORMATION_SCHEMA.COLUMNS 
 WHERE (COLUMN_NAME LIKE '%Usuario%' AND COLUMN_NAME NOT IN ('SiMovilIdUsuario', 'nombre_usuario', 'MailUsuario', 'UsuarioWindows','NombreTipoUsuario'))
   AND DATA_TYPE NOT IN ('int', 'datetime', 'bit')
   AND CHARACTER_MAXIMUM_LENGTH <> 10
 ORDER BY TABLE_NAME
GO

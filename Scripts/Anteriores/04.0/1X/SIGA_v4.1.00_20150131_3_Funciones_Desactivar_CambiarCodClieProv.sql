
UPDATE Funciones
   SET EsMenu = 'False'
     , [Enabled] = 'False'
     , Visible = 'False'
 WHERE Id IN ('CambiarCodCliente', 'ProveedorCambiarCod')
GO
 
 
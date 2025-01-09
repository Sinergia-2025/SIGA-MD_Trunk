
-- Activo/Visible esta Funcion porque ahora siga controla esos campos.
UPDATE Funciones
   SET [Enabled] = 'True'
      , Visible = 'True'
 WHERE Id = 'InfDeVts-Totales+Toolbar'
  AND ([Enabled] = 'False' OR Visible = 'False')
 GO
 
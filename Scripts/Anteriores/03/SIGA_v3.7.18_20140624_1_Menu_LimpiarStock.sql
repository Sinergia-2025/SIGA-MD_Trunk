
--- Reemplazo la Pantalla "AjustarStock" por "LimpiarStock" (solo es un nuevo nombre).

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('LimpiarStock', 'Limpiar Stock', 'Limpiar Stock', 'True', 'False', 'True', 'True', 
      'Stock', 49, 'Eniac.Win', 'LimpiarStock', NULL)
GO


UPDATE RolesFunciones
   SET IdFuncion = 'LimpiarStock'
 WHERE IdFuncion = 'AjustarStock'
GO

DELETE Funciones WHERE Id = 'AjustarStock'
GO

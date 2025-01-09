
INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
  VALUES
     ('InfPercepcionesCompras', 'Informe de Percepciones Compra', 'Informe de Percepciones Compra', 
      'True', 'False', 'True', 'True', 
      'AFIP', 30, 'Eniac.Win', 'InfPercepcionesCompras', NULL, NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPercepcionesCompras' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
GO

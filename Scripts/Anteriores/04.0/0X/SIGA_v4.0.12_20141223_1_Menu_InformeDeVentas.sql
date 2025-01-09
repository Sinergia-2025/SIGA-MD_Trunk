
--Insertar Menu

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InformeDeVentas', 'Informe de Ventas', 'Informe de Ventas', 'True', 'False', 'True',
      'True', 'Ventas', 75, 'Eniac.Win', 'InformeDeVentas', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InformeDeVentas' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO

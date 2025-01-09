
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ModificarNumeracionVentas', 'Modificar Numeracion de Ventas', 'Modificar Numeracion de Ventas', 'True', 'False', 'True', 'True',
      'Ventas', 330, 'Eniac.Win', 'ModificarNumeracionVentas', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ModificarNumeracionVentas' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

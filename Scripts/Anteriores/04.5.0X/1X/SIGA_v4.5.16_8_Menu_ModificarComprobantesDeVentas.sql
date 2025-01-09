
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ModificarComprobantesDeVentas', 'Modificar Comprobantes de Ventas', 'Modificar Comprobantes de Ventas', 
      'True', 'False', 'True', 'True',
      'Ventas', 281, 'Eniac.Win', 'ModificarComprobantesDeVentas', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ModificarComprobantesDeVentas' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

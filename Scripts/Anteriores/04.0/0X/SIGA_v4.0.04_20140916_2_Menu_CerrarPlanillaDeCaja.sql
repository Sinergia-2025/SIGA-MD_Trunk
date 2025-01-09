
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], 
      Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CerrarPlanillaDeCaja', 'Cerrar Planilla de Caja', 'Cerrar Planilla de Caja', 'True', 'False', 'True',
      'True', 'Caja', 12, 'Eniac.Win', 'CerrarPlanillaDeCaja', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CerrarPlanillaDeCaja' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina') 
GO

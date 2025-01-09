 
-- Inserto las Pantallas Nuevas --
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMMetodosResolucionesABM', 'ABM de Metodos Resolucion', 'ABM de Metodos Resolucion', 'True', 'False', 'True', 'True', 
      'CRM', 525, 'Eniac.Win', 'CRMMetodosResolucionesNovedadesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMMetodosResolucionesABM' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

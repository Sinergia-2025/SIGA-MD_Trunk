
-- CREAR LOS PERMISOS PARA VER ALERTAS DE NOVEDADES

-- Novedades
INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CRMNovedades-PuedeVerAlerta', 'Alertas de CRM Novedades - Proximo Contacto',
      'Alertas de CRM Novedades - Proximo Contacto', 'False', 'False', 'True', 'False', 
      'CRM', 999, 'Eniac.Win', 'CRMNovedades-PuedeVerAlerta', NULL)
GO

-- Permisos ---

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'CRMNovedades-PuedeVerAlerta' AS Pantalla FROM Roles
  WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Vendedor', 'Soporte')
GO

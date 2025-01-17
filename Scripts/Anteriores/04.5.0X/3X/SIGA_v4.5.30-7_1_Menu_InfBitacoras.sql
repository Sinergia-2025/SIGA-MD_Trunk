 
-- Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfBitacora', 'Informe de Bitacora de Acciones', 'Informe de Bitacora de Acciones', 'True', 'False', 'True', 'True',
      'Seguridad', 100, 'Eniac.Win', 'InfBitacora', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfBitacora' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

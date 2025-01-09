
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ContabilidadExportacion', 'Exportar Asientos Contables', 'Exportar Asientos Contables', 
      'True', 'False', 'True', 'True',
      'Contabilidad', 500, 'Eniac.Win', 'ContabilidadExportacion', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadExportacion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

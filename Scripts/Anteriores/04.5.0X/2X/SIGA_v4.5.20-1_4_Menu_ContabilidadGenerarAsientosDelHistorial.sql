
--Inserto la Pantalla Nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ContabilidadGeneracionAsientos', 'Generar Asientos del Historial', 'Generar Asientos del Historial', 
      'True', 'False', 'True', 'True',
      'Contabilidad', 350, 'Eniac.Win', 'ContabilidadGeneracionAsientos', NULL)
GO

INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadGeneracionAsientos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

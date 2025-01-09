
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ProductosActualizacionMasiva', 'Productos - Actualizacion Masiva', 'Productos - Actualizacion Masiva', 
      'True', 'False', 'True', 'True',
      'Archivos', 105, 'Eniac.Win', 'ProductosActualizacionMasiva', NULL)
GO


INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ProductosActualizacionMasiva' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

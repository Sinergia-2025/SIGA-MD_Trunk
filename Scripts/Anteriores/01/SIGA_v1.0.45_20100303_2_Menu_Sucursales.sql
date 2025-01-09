
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('Sucursales', 'Sucursales', 'Sucursales', 'True', 'False', 'True', 'True',
           'Archivos', 900, 'Eniac.Win', 'SucursalesABM', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)           
  VALUES ('Adm', 'Sucursales')
GO

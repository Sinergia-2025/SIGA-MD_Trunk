
--Inserto el Menu nuevo

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('AFIP', 'AFIP', '', 'True', 'False', 'True', 'True',
           NULL, 30, NULL, NULL, NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AFIP' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor')
GO


--Inserto la Pantalla Nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ExportacionCitiVentas', 'Exportación para CITI Ventas', 'Exportación para CITI Ventas', 
    'True', 'False', 'True', 'True', 'AFIP', 10, 'Eniac.Win', 'ExportacionCitiVentas', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ExportacionCitiVentas' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor')
GO


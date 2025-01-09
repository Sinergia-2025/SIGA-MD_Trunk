
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ImportarProductosExcel', 'Importar Productos desde Excel', 'Importar Productos desde Excel', 
    'True', 'False', 'True', 'True', 'Procesos', 100,'Eniac.Win', 'ImportarProductosExcel', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarProductosExcel' AS Pantalla FROM dbo.Roles
GO

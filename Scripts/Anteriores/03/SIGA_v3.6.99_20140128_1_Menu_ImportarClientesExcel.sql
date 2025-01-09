
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ImportarClientesExcel', 'Importar Clientes desde Excel', 'Importar Clientes desde Excel', 
    'True', 'False', 'True', 'True', 'Procesos', 96, 'Eniac.Win', 'ImportarClientesExcel', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarClientesExcel' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

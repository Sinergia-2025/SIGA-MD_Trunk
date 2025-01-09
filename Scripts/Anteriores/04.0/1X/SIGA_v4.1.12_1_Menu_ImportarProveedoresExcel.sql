
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ImportarProveedoresExcel', 'Importar Proveedores desde Excel', 'Importar Proveedores desde Excel', 
    'True', 'False', 'True', 'True', 'Procesos', 105, 'Eniac.Win', 'ImportarProveedoresExcel', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarProveedoresExcel' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

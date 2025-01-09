
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfAuditoriaClientes', 'Inf. Auditoría de Clientes', 'Inf. de Auditoría Clientes', 
    'True', 'False', 'True', 'True', 'Archivos', 29, 'Eniac.Win', 'InfAuditoriaClientes', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfAuditoriaClientes' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

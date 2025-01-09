
--Pantalla Nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfUtilidadesPorComprobantes', 'Inf. Utilidades por Comprobantes', 'Inf. Utilidades por Comprobantes', 
    'True', 'False', 'True', 'True', 'Ventas', 83, 'Eniac.Win', 'InfUtilidadesPorComprobantes', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfUtilidadesPorComprobantes' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor')
GO

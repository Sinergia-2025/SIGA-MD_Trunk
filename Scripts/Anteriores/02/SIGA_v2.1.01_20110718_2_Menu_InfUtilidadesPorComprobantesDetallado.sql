
--Pantalla Nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfUtilidadesPorComprobantDet', 'Inf. Utilidades por Comprobantes Detallado', 'Inf. Utilidades por Comprobantes Detallado', 
    'True', 'False', 'True', 'True', 'Ventas', 86, 'Eniac.Win', 'InfUtilidadesPorComprobantesDetallado', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfUtilidadesPorComprobantDet' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor')
GO

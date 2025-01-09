
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('AdministracionNotasRecepcion', 'Administraci�n de Notas de Recepci�n', 'Administraci�n de Notas de Recepci�n', 
    'True', 'False', 'True', 'True', 'Service', 30,'Eniac.Service.Win', 'AdministracionNotasRecepcion', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AdministracionNotasRecepcion' AS Pantalla FROM dbo.Roles
GO

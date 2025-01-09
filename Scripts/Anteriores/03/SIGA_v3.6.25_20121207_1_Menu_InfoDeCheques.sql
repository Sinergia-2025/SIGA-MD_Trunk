
INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('InfCheques', 'Informe de Cheques Semanal', 'Informe de Cheques Semanal', 'True', 'False', 'True', 'True', 
          'Caja', 95, 'Eniac.Win', 'InfCheques', NULL)
GO


INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCheques' AS Pantalla FROM Roles
GO



--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfPagosRealizados', 'Informe de Pagos Realizados', 'Informe de Pagos Realizados', 
      'True', 'False', 'True', 'True',
      'Caja', 140, 'Eniac.Win', 'InfPagosRealizados', NULL)
GO


INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfPagosRealizados' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO


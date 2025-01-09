
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CierreZReimprimir', 'Cierre Z - Reimprimir Anteriores', 'Cierre Z - Reimprimir Anteriores', 
      'True', 'False', 'True', 'True',
      'Ventas', 95, 'Eniac.Win', 'CierreZReimprimir', NULL)
GO


INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CierreZReimprimir' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO
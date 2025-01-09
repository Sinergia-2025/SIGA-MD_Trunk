
--Inserto la Pantalla Nueva y luego piso la anterior porque cambio la funcionalidad.

INSERT INTO Funciones
     (Id, Nombre, Descripcion, 
      EsMenu, EsBoton, [Enabled], Visible,
      IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ConsultarContribuyentesARBA', 'Consultar Contribuyentes ARBA', 'Consultar Contribuyentes ARBA', 
      'True', 'False', 'True', 'True',
      'AFIP', 210, 'Eniac.Win', 'ConsultarContribuyentesARBA', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarContribuyentesARBA' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

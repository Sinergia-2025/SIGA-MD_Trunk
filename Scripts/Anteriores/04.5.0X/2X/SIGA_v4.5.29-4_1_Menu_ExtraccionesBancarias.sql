
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ExtraccionesBancarias', 'Extracciones Bancarias', 'Extracciones Bancarias', 
	 'True', 'False', 'True', 'True',
      'Bancos', 130, 'Eniac.Win', 'ExtraccionesBancarias', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ExtraccionesBancarias' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

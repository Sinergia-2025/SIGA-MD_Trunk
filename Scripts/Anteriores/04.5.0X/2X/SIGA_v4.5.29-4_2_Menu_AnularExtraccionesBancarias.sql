
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('AnularExtracciones', 'Anular Extracciones Bancarias', 'Anular Extracciones Bancarias', 
	 'True', 'False', 'True', 'True',
      'Bancos', 140, 'Eniac.Win', 'AnularExtracciones', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AnularExtracciones' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

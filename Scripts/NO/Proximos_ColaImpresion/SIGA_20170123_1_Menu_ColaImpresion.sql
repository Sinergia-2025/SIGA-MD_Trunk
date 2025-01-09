
--Inserto la pantalla nueva
INSERT INTO Funciones
	 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
	 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
	 ('VentaColaImpresion', 'Cola de Impresion', 'Cola de Impresion', 'True', 'False', 'True', 'True',
	  'Ventas', 900, 'Eniac.Win', 'VentaColaImpresion', NULL);

INSERT INTO RolesFunciones 
	  (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'VentaColaImpresion' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


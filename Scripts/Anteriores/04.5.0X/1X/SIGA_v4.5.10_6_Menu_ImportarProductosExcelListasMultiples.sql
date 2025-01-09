
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ImportarProductosExcelListMult', 'Importar Productos desde Excel para Listas Multiples', 'Importar Productos desde Excel para Listas Multiples', 'True', 'False', 'True', 'True',
	  'Procesos', 101, 'Eniac.Win', 'ImportarProductosExcelListasMultiples', NULL)
GO


INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarProductosExcelListMult' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

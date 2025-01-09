
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ImportarContabilidadCuentasXls', 'Importar Cuentas Contables desde Excel', 'Importar Cuentas Contables desde Excel', 'True', 'False', 'True', 'True',
      'Contabilidad', 400, 'Eniac.Win', 'ImportarContabilidadCuentasExcel', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImportarContabilidadCuentasXls' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

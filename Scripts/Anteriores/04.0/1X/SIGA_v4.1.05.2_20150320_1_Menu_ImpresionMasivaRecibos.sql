
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('ImpresionMasivaRecibos', 'Impresión Masiva de Recibos', 'Impresión Masiva de Recibos', 'True', 'False', 'True', 'True',
      'CuentasCorrientes', 18, 'Eniac.Win', 'ImpresionMasivaRecibos', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImpresionMasivaRecibos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

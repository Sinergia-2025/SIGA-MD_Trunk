
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('EnvioMasivoDeComprobantes', 'Envio Masivo de Comprobantes', 'Envio Masivo de Comprobantes', 'True', 'False', 'True', 'True',
      'Ventas', 45, 'Eniac.Win', 'EnvioMasivoDeFacturas', NULL)
GO

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EnvioMasivoDeComprobantes' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('EnvioMasivoDeCorreos', 'Envio Masivo de Correos', 'Envio Masivo de Correos', 
    'True', 'False', 'True', 'True', 'Procesos', 110, 'Eniac.Win', 'EnvioMasivoDeCorreos', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EnvioMasivoDeCorreos' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

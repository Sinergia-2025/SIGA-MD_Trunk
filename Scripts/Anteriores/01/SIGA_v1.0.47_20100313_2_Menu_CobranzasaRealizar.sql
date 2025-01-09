
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('CobranzasaRealizar', 'Cobranzas a Realizar', 'Cobranzas a Realizar', 'True', 'False', 'True', 'True',
           'CuentasCorrientes', 80, 'Eniac.Win', 'CobranzasaRealizar', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CobranzasaRealizar' AS Pantalla FROM dbo.Roles
GO

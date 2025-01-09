
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('FichasCtaCte', 'Fichas - Cuenta Corriente', 'Fichas - Cuenta Corriente', 
    'True', 'False', 'True', 'True', 'Fichas', 70,'Eniac.Fichas.Win', 'FichasCtaCte', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FichasCtaCte' AS Pantalla FROM dbo.Roles
GO

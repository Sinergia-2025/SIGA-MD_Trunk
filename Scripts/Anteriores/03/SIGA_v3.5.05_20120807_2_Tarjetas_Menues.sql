--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('TarjetasABM', 'Tarjetas', 'Tarjetas', 
    'True', 'False', 'True', 'True', 'Archivos', 50, 'Eniac.Win', 'TarjetasABM', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'TarjetasABM' AS Pantalla FROM dbo.Roles
GO

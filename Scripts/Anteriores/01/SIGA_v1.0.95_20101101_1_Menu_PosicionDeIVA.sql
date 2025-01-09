  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('PosicionDeIVA', 'Posicion de IVA', 'Posicion de IVA', 
    'True', 'False', 'True', 'True', 'Estadisticas', 40, 'Eniac.Win', 'PosicionDeIVA', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'PosicionDeIVA' AS Pantalla FROM dbo.Roles
GO

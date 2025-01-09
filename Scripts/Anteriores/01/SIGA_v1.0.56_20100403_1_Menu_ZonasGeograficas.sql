
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ZonasGeograficas', 'Zonas Geograficas', 'Zonas Geograficas', 'True', 'False', 'True', 'True', 
             'Archivos', 890, 'Eniac.Win', 'ZonasGeograficasABM', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ZonasGeograficas' AS Pantalla FROM dbo.Roles
GO

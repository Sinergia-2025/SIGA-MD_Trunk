
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('TiposImpuestosABM', 'Tipos de Impuestos', 'Tipos de Impuestos', 'True', 'False', 'True', 'True', 
             'Archivos', 890, 'Eniac.Win', 'TiposImpuestosABM', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'TiposImpuestosABM' AS Pantalla FROM Roles
GO


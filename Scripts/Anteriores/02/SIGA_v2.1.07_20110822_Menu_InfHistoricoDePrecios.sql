
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('InfHistoricoDePrecios', 'Inf. Historico de Precios', 'Inf. Historico de Precios', 'True', 'False', 'True', 'True', 
             'Precios', 25, 'Eniac.Win', 'InfHistoricoDePrecios', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfHistoricoDePrecios' AS Pantalla FROM Roles
GO


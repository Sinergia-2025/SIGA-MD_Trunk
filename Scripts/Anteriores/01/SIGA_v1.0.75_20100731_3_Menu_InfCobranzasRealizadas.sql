
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfCobranzasRealizadas', 'Informe de Cobranzas Realizadas', 'Informe de Cobranzas Realizadas', 
    'True', 'False', 'True', 'True', 'Caja', 110, 'Eniac.Win', 'InfCobranzasRealizadas', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCobranzasRealizadas' AS Pantalla FROM dbo.Roles
GO

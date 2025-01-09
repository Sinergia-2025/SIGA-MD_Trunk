
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
 VALUES
   ('AnularProduccion', 'Anular Producción', 'Anular Producción', 
    'True', 'False', 'True', 'True', 'Produccion', 15, 'Eniac.Win', 'AnularProduccion', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AnularProduccion' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO

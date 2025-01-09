
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
 VALUES
   ('InfFormulas', 'Informe de Fórmulas', 'Informe de Fórmulas', 
    'True', 'False', 'True', 'True', 'Produccion', 45, 'Eniac.Win', 'InfFormulas', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfFormulas' AS Pantalla FROM dbo.Roles
GO

PRINT ''
PRINT '1.1. Insertar funcion: Exportación Invoinet '
    BEGIN 
        IF dbo.BaseConCuit('30714757128') = 1 OR dbo.SoyHAR() = 1
            BEGIN
	            --Inserto la Pantalla Nueva
	            INSERT INTO Funciones
	               (Id, Nombre, Descripcion
	               ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	             VALUES
	               ('ExportacionInvoinet', 'Exportación Invoinet', 'Exportación Invoinet', 
		            'True', 'False', 'True', 'True', 'Caja',20, 'Eniac.Win', 'ExportacionInvoinet', null, null,'N','S','N','N','True')

                INSERT INTO RolesFunciones (IdRol, IdFuncion)
                SELECT DISTINCT Id AS Rol, 'ExportacionInvoinet' AS Pantalla FROM Roles
                    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
            END
    END
GO
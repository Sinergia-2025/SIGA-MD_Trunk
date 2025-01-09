

IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'
BEGIN

   IF dbo.ExisteFuncion('Calidad') = 'True'
    BEGIN
        INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
            VALUES
                ('InfAuditoriaItemsListasControl', 'Informe de Auditoría de Items de Listas de Control', 'Informe de Auditoría de Items de Listas de Control', 'True', 'False', 'True', 'True'
                ,'Calidad', 46, 'Eniac.Win', 'InformeAuditoriaItemsListasControl', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N')

        INSERT INTO RolesFunciones (IdRol,IdFuncion)
        SELECT IdRol, 'InfAuditoriaItemsListasControl' FROM RolesFunciones WHERE IdFuncion = 'Calidad'

	END
END

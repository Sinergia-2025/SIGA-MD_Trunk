IF dbo.ExisteFuncion('VentasFiscal') = 1 AND dbo.ExisteFuncion('ReporteFiscalElectronico') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('ReporteFiscalElectronico', 'Reporte Fiscal Electrónico (Cierre Z)', 'Reporte Fiscal Electrónico (Cierre Z)', 'True', 'False', 'True', 'True'
        ,'VentasFiscal', 280, 'Eniac.Win', 'ReporteFiscalElectronico', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ReporteFiscalElectronico' FROM RolesFunciones WHERE IdFuncion = 'CierreZ'
END

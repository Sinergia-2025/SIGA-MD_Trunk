

IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('InformeAuditoriaListasControl') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '1.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('InformeAuditoriaListasControl', 'Informe de Auditoría de Listas de Control', 'Informe de Auditoría de Listas de Control', 
		'True', 'False', 'True', 'True', 'Calidad',47, 'Eniac.Win', 'InformeAuditoriaListasControl', null, null,'N','S','N','N','True')
END;
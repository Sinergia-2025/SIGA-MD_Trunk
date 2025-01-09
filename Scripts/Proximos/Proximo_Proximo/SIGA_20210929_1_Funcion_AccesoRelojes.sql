IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('AccesoRelojes') = 0 
--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: SincronizarPanelDeControl'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('AccesoRelojes', 'Acceso a Relojes', 'Acceso a Relojes', 
		'True', 'False', 'True', 'True', 'Calidad',600, 'Eniac.Win', 'AccesoRelojes', null, null,'N','S','N','N','True')
END;
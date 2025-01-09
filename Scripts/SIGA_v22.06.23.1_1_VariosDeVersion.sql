IF dbo.BaseConCuit('33631312379') = 1 
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Panel de Fechas de Salida de Sección con detalle por Coche'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('PanelFechasSalidaPorCoche', 'Panel de Fechas de Salida de Sección con detalle por Coche', 'Panel de Fechas de Salida de Sección con detalle por Coche', 
		'True', 'False', 'True', 'True', 'MPS',27, 'Eniac.Win', 'PanelFechasSalidaPorCoche', null, null,'N','S','N','N','True')

END;

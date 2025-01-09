
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('ProdCalidadABM_FechaEntregado') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva

    PRINT ''
    PRINT '1.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ProdCalidadABM_FechaEntregado', 'Productos Calidad: Modifica Fecha Entregado', 'Productos Calidad: Modifica Fecha Entregado', 
		'False', 'False', 'True', 'True', 'ProductosCalidadABM',888, 'Eniac.Win', 'ProdCalidadABM_FechaEntregado', null, null,'N','S','N','N','True')
END;
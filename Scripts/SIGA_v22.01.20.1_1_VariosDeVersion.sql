
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Activaciones Ordenes de Compra'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ActivacionesOC', 'Activaciones de Ordenes de Compra', 'Activaciones de Ordenes de Compra', 
		'True', 'False', 'True', 'True', 'PedidosProv',51, 'Eniac.Win', 'ActivacionesOC', null, null,'N','S','N','N','True')

END;


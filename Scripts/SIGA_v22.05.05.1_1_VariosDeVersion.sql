
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: Informe de Envíos de Ordenes de Compra'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('EnviosOC', 'Informe de Envíos de Ordenes de Compra', 'Informe de Envíos de Ordenes de Compra', 
		'True', 'False', 'True', 'True', 'PedidosProv',53, 'Eniac.Win', 'EnviosOC', null, null,'N','S','N','N','True')

END;


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	--Inserto la Pantalla Nueva
    PRINT ''
    PRINT '1.1. Insertar funcion: ABM de Tipos de Modelos de Productos'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ConsultarOrdenesCompra', 'Consultar Ordenes de Compra', 'Consultar Ordenes de Compra', 
		'True', 'False', 'True', 'True', 'PedidosProv',51, 'Eniac.Win', 'ConsultarOrdenesCompra', null, null,'N','S','N','N','True')

		INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], [Posicion], [Archivo], [Pantalla], [Icono], [Parametros], [PermiteMultiplesInstancias], [Plus], [Express], [Basica], [PV], [IdModulo], [EsMDIChild]) VALUES (N'EstadosPedidosProvABM', N'ABM Estados de Pedidos Proveedores', N'ABM Estados de Pedidos Proveedores', 1, 0, 1, 1, N'PedidosProv', 22, N'Eniac.Win', N'EstadosPedidosProvABM', NULL, NULL, 1, N'S', N'N', N'N', N'N', NULL, 1)
END;


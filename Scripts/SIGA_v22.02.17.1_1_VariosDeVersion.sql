


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
IF dbo.ExisteFuncion('ActivacionesOC_DeshabilitaEliminar') = 0 AND dbo.ExisteFuncion('ActivacionesOC') = 1

--Inserto función
    PRINT ''
    PRINT '1.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ActivacionesOC_DeshabEliminar', 'Activaciones: Deshabilita Eliminar', 'Activaciones: Deshabilita Eliminar', 
		'False', 'False', 'True', 'True', 'ActivacionesOC',888, 'Eniac.Win', 'ActivacionesOC_DeshabEliminar', null, null,'N','S','N','N','True')

		IF dbo.ExisteFuncion('ActivacionesOC_DeshabilitaEliminar') = 0 AND dbo.ExisteFuncion('ActivacionesOC') = 1

--Inserto función
    PRINT ''
    PRINT '1.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ActivacionesOC_SoloConsulta', 'Activaciones: Solo Consulta', 'Activaciones: Solo Consulta', 
		'False', 'False', 'True', 'True', 'ActivacionesOC',888, 'Eniac.Win', 'ActivacionesOC_SoloConsulta', null, null,'N','S','N','N','True')

END;


PRINT ''
PRINT '2- PedidosProveedores: Campo nuevo FechaAutorizacion'

ALTER TABLE PedidosProveedores ADD FechaAutorizacion datetime null
GO

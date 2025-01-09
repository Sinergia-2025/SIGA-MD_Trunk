
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '. Menu ListasControlProductos-5S Calidad Edición.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
     VALUES
       ('PanelFechasSalida_IngresaMetas', 'Panel Fechas de Salida - Ingresa Metas', 'Panel Fechas de Salida - Ingresa Metas', 
        'False', 'False', 'True', 'True', 'PanelFechasSalidaSeccion', 10, 'Eniac.Win', 'PanelFechasSalida_IngresaMetas', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')

END;
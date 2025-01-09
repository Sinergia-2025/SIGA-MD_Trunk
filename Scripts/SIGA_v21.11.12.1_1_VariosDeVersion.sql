
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '. Menu ListasControlProductos-5S Calidad Edición.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
     VALUES
       ('ListasControlProductos-5SCE', 'Ejecución de Listas Control Productos-5SCalidadEdicion', 'Ejecución de Listas Control Productos-5SCalidadEdicion', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-5SCE', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')

END;

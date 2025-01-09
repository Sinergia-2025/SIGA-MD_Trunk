
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '. Permiso AsignarCochesProg_VerLiberados'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
     VALUES
       ('AsignarCochesProg_VerLiberados', 'Asignar Coches a Programación - Ver Liberados', 'Asignar Coches a Programación - Ver Liberados', 
        'False', 'False', 'True', 'True', 'MetasTiposModelosProductos', 10, 'Eniac.Win', 'AsignarCochesProg_VerLiberados', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N', 'True')

END;
IF dbo.ExisteFuncion('CajeroModificar') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    SELECT 'CajeroModificar', 'Modificar Comprob. Pendientes en Cajero', 'Modificar Comprob. Pendientes en Cajero', EsMenu, EsBoton, [Enabled], Visible
          ,IdPadre, Posicion + 1, Archivo, Pantalla, Icono, 'Modo=MODIFICAR;IdTipoComprobanteGenerar=PRE-VENTA'
          ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild
      FROM Funciones
     WHERE Id = 'Cajero'

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'CajeroModificar' FROM RolesFunciones WHERE IdFuncion = 'Cajero'
END
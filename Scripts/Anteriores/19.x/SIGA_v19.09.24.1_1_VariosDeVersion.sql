PRINT ''
PRINT '1. Menu Liberar Producto'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '1.1. Menu  Liberar Producto: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('LiberarProducto', 'Liberar Producto', 'Liberar Producto', 'True', 'False', 'True', 'True'
             ,'Calidad', 43, 'Eniac.Win', 'LiberarProducto', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '1.2. Menu  Liberar Producto: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'LiberarProducto' FROM RolesFunciones WHERE IdFuncion = 'Calidad';
END;

PRINT ''
PRINT '2. Menu Entregado a Cliente'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
	PRINT ''
    PRINT '2.1. Menu  Entregado a Cliente: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('Entregado', 'Entregado a Cliente', 'Entregado a Cliente', 'True', 'False', 'True', 'True'
             ,'Calidad', 44, 'Eniac.Win', 'Entregado', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '2.2. Menu  Entregado a Cliente: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Entregado' FROM RolesFunciones WHERE IdFuncion = 'Calidad';

END;

PRINT ''
PRINT '3. Menu Informe 5S Diferencias'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN

	PRINT ''
    PRINT '3.1. Menu  Informe 5S Diferencias: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('Informe5SDiferencias', 'Informe 5S Diferencias en Calificaciones', 'Informe 5S Diferencias en Calificaciones', 'True', 'False', 'True', 'True'
             ,'Calidad', 45, 'Eniac.Win', 'Informe5SDiferencias', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '3.2. Menu  Informe 5S Diferencias: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Informe5SDiferencias' FROM RolesFunciones WHERE IdFuncion = 'Calidad';

END;


PRINT ''
PRINT '4. Menu ProductosCalidadABM: Cambiar Posicion'
UPDATE Funciones SET Posicion = 61 WHERE Id = 'ProductosCalidadABM'
GO


PRINT '5. Renombrar 4 Reportes Nutrisur.'
IF dbo.BaseConCuit('20164865720') = 1
BEGIN

    EXECUTE [dbo].[RenombrarReporte] 'Eniac.Win.Comprobante.rdlc', '279_Cotizacion_x_2.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] '173_Comprobante_PI_A.rdlc', '279_Comprobante_PI_A.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] '173_Comprobante_PI_B.rdlc', '279_Comprobante_PI_B.rdlc', 'N'
    EXECUTE [dbo].[RenombrarReporte] 'PedidoProveedor_Totales.rdlc', '279_PedidoProveevor.rdlc', 'N'

END


PRINT ''
PRINT '1. Tabla TiposComprobantes: Nueva columna AFIPWSRequiereReferenciaComercial y AFIPWSRequiereComprobanteAsociado'
ALTER TABLE dbo.TiposComprobantes ADD AFIPWSRequiereReferenciaComercial bit NULL
ALTER TABLE dbo.TiposComprobantes ADD AFIPWSRequiereComprobanteAsociado bit NULL
GO
PRINT ''
PRINT '1.1. Tabla TiposComprobantes: Valores por defecto para AFIPWSRequiereReferenciaComercial y AFIPWSRequiereComprobanteAsociado'
UPDATE TiposComprobantes
   SET AFIPWSRequiereReferenciaComercial = 'False'
     , AFIPWSRequiereComprobanteAsociado = 'False'
PRINT ''
PRINT '1.2. Tabla TiposComprobantes: NOT NULL AFIPWSRequiereReferenciaComercial y AFIPWSRequiereComprobanteAsociado'
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AFIPWSRequiereReferenciaComercial bit NOT NULL
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AFIPWSRequiereComprobanteAsociado bit NOT NULL
GO

PRINT ''
PRINT '2, 3, 4. Menu Informe Lead Time, Menu Pre Entrega, Importar Clientes Bejerman'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '2.1. Menu Informe Lead Time: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('InformeLeadTime', 'Lead Time', 'Lead Time', 'True', 'False', 'True', 'True'
             ,'Calidad', 41, 'Eniac.Win', 'InformeLeadTime', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '2.2. Menu Informe de Listas de Control: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'InformeLeadTime' FROM RolesFunciones WHERE IdFuncion = 'Calidad';

	PRINT ''
    PRINT '3.1. Menu Pre Entrega: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('PreEntrega', 'Pre Entrega', 'PreEntrega', 'True', 'False', 'True', 'True'
             ,'Calidad', 42, 'Eniac.Win', 'PreEntrega', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '3.2. Menu Pre Entrega: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'PreEntrega' FROM RolesFunciones WHERE IdFuncion = 'Calidad';

    PRINT ''
    PRINT '4.1. Menu Importar Clientes Bejerman: Insertar Función'
    IF dbo.ExisteFuncion('Calidad') = 'True'
    INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
             ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
             ('ImportarClientesCalidad', 'Importar Clientes Bejerman', 'Importar Clientes Bejerman', 'True', 'False', 'True', 'True'
             ,'Calidad', 130, 'Eniac.Win', 'ImportarClientesCalidad', NULL, NULL
             ,'True', 'S', 'N', 'N', 'N');

    PRINT ''
    PRINT '4.2. Menu Importar Clientes Bejerman: Agregar Roles'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ImportarClientesCalidad' FROM RolesFunciones WHERE IdFuncion = 'Calidad';

END;

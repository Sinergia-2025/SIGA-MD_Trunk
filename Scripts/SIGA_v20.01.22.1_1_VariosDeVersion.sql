PRINT ''
PRINT '1. OrganizarEntrega(V2): Permite generar repartos con distintas Fechas De Envio'
DECLARE @idParametro VARCHAR(MAX) = 'ORGANIZARENTREGAPERMITEDISTINTAFECHAENVIO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'OrganizarEntrega(V2): Permite generar repartos con distintas Fechas De Envio'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


PRINT ''
PRINT '2. Menu: Sincronizar Tickets'
IF dbo.ExisteFuncion('CRM') = 'True'
BEGIN
    PRINT ''
    PRINT '2.1. Menu: Agregar opción de menu Sincronizar Tickets'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('SincronizarNovedades', 'Sincronizar', 'Sincronizar', 'True', 'False', 'True', 'True'
        ,'CRM', 800, 'Eniac.Win', 'SincronizarNovedades', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '2.2. Menu: Agregar roles al menu Sincronizar Tickets'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'SincronizarNovedades' FROM RolesFunciones WHERE IdFuncion = 'TableroDeComando'
END


PRINT ''
PRINT '3. Menu: Comando - Sincronización automática para Moviles'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('CmdSincronizacionSubidaMovil', 'Sincronización Automática para SiMoviles', 'Sincronización Automática para SiMoviles', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincronizacionSubidaMovil', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

PRINT ''
PRINT '3.1. Roles para: Proceso Envio Automatico de Doc A Vencer'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'CmdSincronizacionSubidaMovil' FROM RolesFunciones WHERE IdFuncion = 'SincronizacionSubidaMovil'

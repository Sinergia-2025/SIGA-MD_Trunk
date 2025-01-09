
PRINT ''
PRINT '1. Tabla CuentasCorrientesAntiguedadesSaldosConfig: Agregar Información inicial de Rangos (Mensual/Quincenal)'
DECLARE @Valor as Int = (SELECT MAX(IdAntiguedadSaldoConfig) FROM CuentasCorrientesAntiguedadesSaldosConfig)  + 1

INSERT INTO [dbo].[CuentasCorrientesAntiguedadesSaldosConfig]
           ([IdAntiguedadSaldoConfig], [NombreAntiguedadSaldoConfig], [TipoAntiguedadSaldoConfig], [PorDefecto])
     VALUES
           (@Valor, 'Mensual',   'AntiguedadSaldosProveedores', 'True'),
           (@Valor + 1 , 'Quincenal', 'AntiguedadSaldosProveedores', 'False')

INSERT INTO [dbo].[CuentasCorrientesAntiguedadesSaldosRangos]
           ([IdAntiguedadSaldoConfig], [DiasDesde], [DiasHasta], [EtiquetaColumna], [Orden])
     VALUES
           (@Valor,    121, 50000, 'MOROSO',         1),
           (@Valor,     91,   120, '91 a 120 días',  2),
           (@Valor,     61,    90, '61 a  90 días',  3),
           (@Valor,     31,    60, '31 a  60 días',  4),
           (@Valor,      1,    30, ' 1 a  30 días',  5),
           (@Valor,      0,     0, 'AL DIA',         6),
           (@Valor,    -30,    -1, 'prox 30 días',   7),
           (@Valor,    -60,   -31, 'prox 60 días',   8),
           (@Valor,    -90,   -61, 'prox 90 días',   9),
           (@Valor, -50000,   -91, '+ de 91 días',  10),
           (@Valor + 1,     61, 50000, 'MOROSO',         1),
           (@Valor + 1,     46,    60, '46 a 60 días',   2),
           (@Valor + 1,     31,    45, '31 a 45 días',   3),
           (@Valor + 1,     16,    30, '16 a 30 días',   4),
           (@Valor + 1,      1,    15, ' 1 a 15 días',   5),
           (@Valor + 1,      0,     0, 'AL DIA',         6),
           (@Valor + 1,    -15,    -1, 'prox 15 días',   7),
           (@Valor + 1,    -30,   -16, 'prox 30 días',   8),
           (@Valor + 1,    -45,   -31, 'prox 45 días',   9),
           (@Valor + 1, -50000,   -46, '+ de 45 días',  10)
GO

PRINT ''
PRINT '2. Menu: Nueva opción de menú ABM de Rangos Antigüedad de Saldo'
IF dbo.ExisteFuncion('CuentasCorrientes') = 1 AND dbo.ExisteFuncion('AntiguedadesSaldosConfigABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AntiguedadesSaldosConfigABM', 'ABM de Rangos Antigüedad de Saldo', 'ABM de Rangos Antigüedad de Saldo', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 700, 'Eniac.Win', 'CuentasCorrientesAntiguedadesSaldosConfigABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AntiguedadesSaldosConfigABM' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
PRINT ''
PRINT '3. Nuevo parámetro: Carga URLWSPN4 Para Sincronizar con Afip.-'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa, 
            'URLWSPN4' AS IdParametro, 
            'https://aws.afip.gov.ar/sr-padron/webservices/personaServiceA4' ValorParametro, 
            'URL WebService PN4' CategoriaParametro, 
            'URLWSPN4' DescripcionParametro FROM Empresas) AS ORIG 
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN 
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);

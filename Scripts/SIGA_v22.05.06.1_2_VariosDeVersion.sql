PRINT ''
PRINT '1. Nueva Tabla CuentasCorrientesAntiguedadesSaldosConfig'
CREATE TABLE [dbo].[CuentasCorrientesAntiguedadesSaldosConfig](
    [IdAntiguedadSaldoConfig] [int] NOT NULL,
    [NombreAntiguedadSaldoConfig] [varchar](50) NOT NULL,
    [TipoAntiguedadSaldoConfig] [varchar](50) NOT NULL,
    [PorDefecto] [bit] NOT NULL,
 CONSTRAINT [PK_CuentasCorrientesAntiguedadesSaldosConfig] PRIMARY KEY CLUSTERED ([IdAntiguedadSaldoConfig] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CuentasCorrientesAntiguedadesSaldosConfig]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesAntiguedadesSaldosConfig_CuentasCorrientesAntiguedadesSaldosConfig] FOREIGN KEY([IdAntiguedadSaldoConfig])
REFERENCES [dbo].[CuentasCorrientesAntiguedadesSaldosConfig] ([IdAntiguedadSaldoConfig])
GO
ALTER TABLE [dbo].[CuentasCorrientesAntiguedadesSaldosConfig] CHECK CONSTRAINT [FK_CuentasCorrientesAntiguedadesSaldosConfig_CuentasCorrientesAntiguedadesSaldosConfig]
GO


PRINT ''
PRINT '2. Nueva Tabla CuentasCorrientesAntiguedadesSaldosRangos'
CREATE TABLE [dbo].[CuentasCorrientesAntiguedadesSaldosRangos](
    [IdAntiguedadSaldoConfig] [int] NOT NULL,
    [DiasDesde] [int] NOT NULL,
    [DiasHasta] [int] NOT NULL,
    [EtiquetaColumna] [varchar](30) NOT NULL,
    [Orden] [int] NOT NULL,
 CONSTRAINT [PK_CuentasCorrientesAntiguedadesSaldosRangos] PRIMARY KEY CLUSTERED ([IdAntiguedadSaldoConfig] ASC,[DiasDesde] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CuentasCorrientesAntiguedadesSaldosRangos]  WITH CHECK ADD  CONSTRAINT [FK_CuentasCorrientesAntiguedadesSaldosRangos_CuentasCorrientesAntiguedadesSaldosConfig] FOREIGN KEY([IdAntiguedadSaldoConfig])
REFERENCES [dbo].[CuentasCorrientesAntiguedadesSaldosConfig] ([IdAntiguedadSaldoConfig])
GO
ALTER TABLE [dbo].[CuentasCorrientesAntiguedadesSaldosRangos] CHECK CONSTRAINT [FK_CuentasCorrientesAntiguedadesSaldosRangos_CuentasCorrientesAntiguedadesSaldosConfig]
GO

PRINT ''
PRINT '3. Tabla CuentasCorrientesAntiguedadesSaldosConfig: Agregar Información inicial de Rangos (Mensual/Quincenal)'
INSERT INTO [dbo].[CuentasCorrientesAntiguedadesSaldosConfig]
           ([IdAntiguedadSaldoConfig], [NombreAntiguedadSaldoConfig], [TipoAntiguedadSaldoConfig], [PorDefecto])
     VALUES
           (1, 'Mensual',   'AntiguedadSaldosClientes', 'True'),
           (2, 'Quincenal', 'AntiguedadSaldosClientes', 'False')
GO

PRINT ''
PRINT '3.1. Tabla CuentasCorrientesAntiguedadesSaldosRangos: Agregar Información inicial de cada rango'
INSERT INTO [dbo].[CuentasCorrientesAntiguedadesSaldosRangos]
           ([IdAntiguedadSaldoConfig], [DiasDesde], [DiasHasta], [EtiquetaColumna], [Orden])
     VALUES
           (1,    121, 50000, 'MOROSO',         1),
           (1,     91,   120, '91 a 120 días',  2),
           (1,     61,    90, '61 a  90 días',  3),
           (1,     31,    60, '31 a  60 días',  4),
           (1,      1,    30, ' 1 a  30 días',  5),
           (1,      0,     0, 'AL DIA',         6),
           (1,    -30,    -1, 'prox 30 días',   7),
           (1,    -60,   -31, 'prox 60 días',   8),
           (1,    -90,   -61, 'prox 90 días',   9),
           (1, -50000,   -91, '+ de 91 días',  10),

           (2,     61, 50000, 'MOROSO',         1),
           (2,     46,    60, '46 a 60 días',   2),
           (2,     31,    45, '31 a 45 días',   3),
           (2,     16,    30, '16 a 30 días',   4),
           (2,      1,    15, ' 1 a 15 días',   5),
           (2,      0,     0, 'AL DIA',         6),
           (2,    -15,    -1, 'prox 15 días',   7),
           (2,    -30,   -16, 'prox 30 días',   8),
           (2,    -45,   -31, 'prox 45 días',   9),
           (2, -50000,   -46, '+ de 45 días',  10)
GO


PRINT ''
PRINT '4. Menu: Nueva opción de menú ABM de Rangos Antigüedad de Saldo'
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

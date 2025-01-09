SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
GO

PRINT ''
PRINT '1. Nueva Tabla Empresas'
CREATE TABLE [Empresas](
	[IdEmpresa] [int] NOT NULL,
	[NombreEmpresa] [varchar](100) NOT NULL,
	[CuitEmpresa] [varchar](13) NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

PRINT ''
PRINT '2. Datos iniciales de Nueva Tabla Empresas'
INSERT INTO [Empresas] ([IdEmpresa], [NombreEmpresa], [CuitEmpresa])
SELECT
    1 IDEMPRESA,
    (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'NOMBREEMPRESA') NOMBREEMPRESA,
    (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'CUITEMPRESA') CUITEMPRESA


PRINT ''
PRINT '3. Agregar campo IdEmpresa en Sucursales'
ALTER TABLE dbo.Sucursales ADD IdEmpresa int NULL
GO

PRINT ''
PRINT '4. Setea IdEmpresa = 1 en Sucursales'
UPDATE Sucursales SET IdEmpresa = 1;
ALTER TABLE dbo.Sucursales ALTER COLUMN IdEmpresa int NOT NULL
GO

PRINT ''
PRINT '5. FK Sucursales - Empresas'
ALTER TABLE dbo.Sucursales ADD CONSTRAINT FK_Sucursales_Empresas
    FOREIGN KEY (IdEmpresa)
    REFERENCES dbo.Empresas (IdEmpresa)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '6. Nueva funcion EmpresasABM'
IF dbo.ExisteFuncion('Archivos') = 'True'
BEGIN
    PRINT ''
    PRINT '6.1. Agregar Opción de Menu EmpresasABM'
    INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('EmpresasABM', 'Empresas', 'Empresas', 'True', 'False', 'True', 'True'
       ,'Archivos', 43, 'Eniac.Win', 'EmpresasABM', NULL, NULL
       ,'True', 'S', 'N', 'N', 'N')
   
    PRINT ''
    PRINT '6.2. Asigna Roles a EmpresasABM'
    INSERT INTO RolesFunciones 
               (IdRol,IdFuncion)
    SELECT IdRol, 'EmpresasABM' FROM RolesFunciones WHERE IdFuncion = 'Sucursales'
END

PRINT ''
PRINT '7. Agregar IdEmpresa en Parametros/ParametrosSucursales'
    PRINT ''
    PRINT '7.1. DROP DE FK_ParametrosSucursales_Parametros'
    ALTER TABLE dbo.ParametrosSucursales DROP CONSTRAINT FK_ParametrosSucursales_Parametros
    GO
    PRINT ''
    PRINT '7.2. DROP DE PK_Parametros'
    ALTER TABLE dbo.Parametros           DROP CONSTRAINT PK_Parametros
    GO
    PRINT ''
    PRINT '7.3. DROP DE PK_ParametrosSucursales'
    ALTER TABLE dbo.ParametrosSucursales DROP CONSTRAINT PK_ParametrosSucursales
    GO

    PRINT ''
    PRINT '7.4. Agrega IdEmpresa en Parametros'
    ALTER TABLE dbo.Parametros           ADD IdEmpresa int NULL
    PRINT ''
    PRINT '7.5. Agrega IdEmpresa en ParametrosSucursales'
    ALTER TABLE dbo.ParametrosSucursales ADD IdEmpresa int NULL
    GO

    PRINT ''
    PRINT '7.6. Valores por defecto a IdEmpresa en Parametros'
    UPDATE Parametros           SET IdEmpresa = 1;
    PRINT ''
    PRINT '7.7. Valores por defecto a IdEmpresa en ParametrosSucursales'
    UPDATE ParametrosSucursales SET IdEmpresa = 1;

    PRINT ''
    PRINT '7.8. Parametros.IdEmpresa NOT NULL'
    ALTER TABLE dbo.Parametros           ALTER COLUMN IdEmpresa int NOT NULL
    PRINT ''
    PRINT '7.9. Parametros.IdEmpresa NOT NULL'
    ALTER TABLE dbo.ParametrosSucursales ALTER COLUMN IdEmpresa int NOT NULL
    GO

    PRINT ''
    PRINT '7.10. ADD DE PK_Parametros'
    ALTER TABLE dbo.Parametros ADD CONSTRAINT PK_Parametros
        PRIMARY KEY CLUSTERED (IdEmpresa,IdParametro)
        WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    GO
    PRINT ''
    PRINT '7.11. ADD DE PK_ParametrosSucursales'
    ALTER TABLE dbo.ParametrosSucursales ADD CONSTRAINT PK_ParametrosSucursales
        PRIMARY KEY CLUSTERED (IdEmpresa,IdSucursal,IdParametro)
        WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    GO
    PRINT ''
    PRINT '7.12. ADD DE FK_Parametros_Empresas'
    ALTER TABLE dbo.Parametros ADD CONSTRAINT FK_Parametros_Empresas
        FOREIGN KEY (IdEmpresa)
        REFERENCES dbo.Empresas(IdEmpresa)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
    GO
    PRINT ''
    PRINT '7.13. ADD DE FK_ParametrosSucursales_Parametros'
    ALTER TABLE dbo.ParametrosSucursales ADD CONSTRAINT FK_ParametrosSucursales_Parametros
        FOREIGN KEY (IdEmpresa,IdParametro)
        REFERENCES dbo.Parametros (IdEmpresa,IdParametro)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
    GO

    GO


PRINT ''
PRINT '8. Agregar IdEmpresa en Compras/PeriodosFiscales'
    PRINT ''
    PRINT '8.1. DROP DE FK_Compras_PeriodosFiscales'
    ALTER TABLE dbo.Compras DROP CONSTRAINT FK_Compras_PeriodosFiscales
    GO
    PRINT ''
    PRINT '8.2. DROP DE PK_PeriodosFiscales'
    ALTER TABLE dbo.PeriodosFiscales DROP CONSTRAINT PK_PeriodosFiscales
    GO

    PRINT ''
    PRINT '8.3. Agrega IdEmpresa en PeriodosFiscales'
    ALTER TABLE dbo.PeriodosFiscales ADD IdEmpresa int NULL
    GO
    PRINT ''
    PRINT '8.4. Agrega IdEmpresa en Compras'
    ALTER TABLE dbo.Compras ADD IdEmpresa int NULL
    GO

    PRINT ''
    PRINT '8.5. Valores por defecto a IdEmpresa en PeriodosFiscales'
    UPDATE PeriodosFiscales SET IdEmpresa = 1;

    PRINT ''
    PRINT '8.6. Parametros.IdEmpresa NOT NULL'
    ALTER TABLE dbo.PeriodosFiscales ALTER COLUMN IdEmpresa int NOT NULL
    GO

    PRINT ''
    PRINT '8.7. ADD DE FK_PeriodosFiscales_Empresas'
    ALTER TABLE dbo.PeriodosFiscales ADD CONSTRAINT FK_PeriodosFiscales_Empresas
        FOREIGN KEY (IdEmpresa)
        REFERENCES dbo.Empresas (IdEmpresa)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
    GO
    PRINT ''
    PRINT '8.8. ADD DE PK_PeriodosFiscales'
    ALTER TABLE dbo.PeriodosFiscales ADD CONSTRAINT PK_PeriodosFiscales
        PRIMARY KEY CLUSTERED (IdEmpresa,PeriodoFiscal)
        WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    GO
    PRINT ''
    PRINT '8.9. ADD DE FK_Compras_PeriodosFiscales'
    ALTER TABLE dbo.Compras ADD CONSTRAINT FK_Compras_PeriodosFiscales
        FOREIGN KEY (IdEmpresa,PeriodoFiscal)
        REFERENCES dbo.PeriodosFiscales (IdEmpresa,PeriodoFiscal)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 

PRINT ''
PRINT '9. Nueva Tabla CategoriasFiscalesConfiguraciones'
CREATE TABLE [dbo].[CategoriasFiscalesConfiguraciones](
	[IdCategoriaFiscalEmpresa] [smallint] NOT NULL,
	[IdCategoriaFiscalCliente] [smallint] NOT NULL,
	[LetraFiscal] [char](1) NOT NULL,
	[LetraFiscalCompra] [char](1) NOT NULL,
	[IvaDiscriminado] [bit] NOT NULL,
 CONSTRAINT [PK_CategoriasFiscalesConfiguraciones] PRIMARY KEY CLUSTERED 
(
	[IdCategoriaFiscalEmpresa] ASC,
	[IdCategoriaFiscalCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '9.1. ADD de [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Cliente]'
ALTER TABLE [dbo].[CategoriasFiscalesConfiguraciones]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Cliente] FOREIGN KEY([IdCategoriaFiscalCliente])
REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal])
GO
PRINT ''
PRINT '9.2. ADD de [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Cliente]'
ALTER TABLE [dbo].[CategoriasFiscalesConfiguraciones] CHECK CONSTRAINT [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Cliente]
GO
PRINT ''
PRINT '9.3. ADD de [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Empresa]'
ALTER TABLE [dbo].[CategoriasFiscalesConfiguraciones]  WITH CHECK ADD  CONSTRAINT [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Empresa] FOREIGN KEY([IdCategoriaFiscalEmpresa])
REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal])
GO
PRINT ''
PRINT '9.4. ADD de [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Empresa]'
ALTER TABLE [dbo].[CategoriasFiscalesConfiguraciones] CHECK CONSTRAINT [FK_CategoriasFiscalesConfiguraciones_CategoriasFiscales_Empresa]
GO

PRINT ''
PRINT '10. Agrego valores iniciales para CategoriasFiscalesConfiguraciones'

PRINT ''
PRINT '10.1. Agrego CategoriasFiscalesConfiguraciones para un RESPONSABLE INSCRIPTO predeterminadas'
-- Empresa RESPONSABLE INSCRIPTO
INSERT INTO CategoriasFiscalesConfiguraciones (IdCategoriaFiscalEmpresa,IdCategoriaFiscalCliente,LetraFiscal,LetraFiscalCompra,IvaDiscriminado) VALUES
    (2,1,'B','B',0),
    (2,2,'A','A',1),
    (2,3,'A','A',1),
    (2,4,'B','C',0),
    (2,5,'B','C',0),
    (2,6,'B','C',0),
    (2,7,'E','I',0)

PRINT ''
PRINT '10.2. Agrego CategoriasFiscalesConfiguraciones para un MONOTRIBUTISTA predeterminadas'
-- Empresa MONOTRIBUTISTA
INSERT INTO CategoriasFiscalesConfiguraciones (IdCategoriaFiscalEmpresa,IdCategoriaFiscalCliente,LetraFiscal,LetraFiscalCompra,IvaDiscriminado) VALUES
    (6,1,'C','B',0),
    (6,2,'C','B',0),
    (6,3,'C','B',0),
    (6,4,'C','C',0),
    (6,5,'C','C',0),
    (6,6,'C','C',0),
    (6,7,'E','I',0)

PRINT ''
PRINT '10.3. Agrego CategoriasFiscalesConfiguraciones para un EXENTO predeterminadas'
-- Empresa EXENTO
INSERT INTO CategoriasFiscalesConfiguraciones (IdCategoriaFiscalEmpresa,IdCategoriaFiscalCliente,LetraFiscal,LetraFiscalCompra,IvaDiscriminado) VALUES
    (4,1,'C','B',0),
    (4,2,'C','B',0),
    (4,3,'C','B',0),
    (4,4,'C','C',0),
    (4,5,'C','C',0),
    (4,6,'C','C',0),
    (4,7,'E','I',0)

PRINT ''
PRINT '10.4. Actualizo CategoriasFiscalesConfiguraciones de la categoría de la empresa actual con la configuración de CategoriasFiscales por si esta cambió'
MERGE INTO CategoriasFiscalesConfiguraciones AS CFC
        USING (SELECT P.ValorParametro AS IdCategoriaFiscalEmpresa, CF.IdCategoriaFiscal AS IdCategoriaFiscalCliente, CF.LetraFiscal, CF.LetraFiscalCompra, CF.IvaDiscriminado
                 FROM CategoriasFiscales CF
                CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = 1) P) AS CF 
           ON CF.IdCategoriaFiscalEmpresa = CFC.IdCategoriaFiscalEmpresa
          AND CF.IdCategoriaFiscalCliente = CFC.IdCategoriaFiscalCliente
    WHEN MATCHED THEN
        UPDATE SET CFC.LetraFiscal       = CF.LetraFiscal
                  ,CFC.LetraFiscalCompra = CF.LetraFiscalCompra
                  ,CFC.IvaDiscriminado   = CF.IvaDiscriminado
    WHEN NOT MATCHED THEN 
        INSERT (   IdCategoriaFiscalEmpresa,    IdCategoriaFiscalCliente,    LetraFiscal,    LetraFiscalCompra,    IvaDiscriminado)
        VALUES (CF.IdCategoriaFiscalEmpresa, CF.IdCategoriaFiscalCliente, CF.LetraFiscal, CF.LetraFiscalCompra, CF.IvaDiscriminado)
;

PRINT ''
PRINT '11. Drop de columnas innecesarias de CategoriasFiscales (se pasaron a CategoriasFiscalesConfiguraciones)'
PRINT ''
PRINT '11.1. DROP COLUMN LetraFiscal de CategoriasFiscales'
ALTER TABLE CategoriasFiscales DROP COLUMN LetraFiscal;
PRINT ''
PRINT '11.2. DROP COLUMN LetraFiscalCompra de CategoriasFiscales'
ALTER TABLE CategoriasFiscales DROP COLUMN LetraFiscalCompra;
PRINT ''
PRINT '11.3. DROP COLUMN IvaDiscriminado de CategoriasFiscales'
ALTER TABLE CategoriasFiscales DROP COLUMN IvaDiscriminado;


PRINT ''
PRINT '12. Agregar IdEmpresa en VentasNumeros'
ALTER TABLE dbo.VentasNumeros ADD IdEmpresa int NULL
GO
PRINT ''
PRINT '12.1. Valor por defecto de VentasNumeros.IdEmpresa'
UPDATE VentasNumeros SET IdEmpresa = 1;
PRINT ''
PRINT '12.2. VentasNumeros.IdEmpresa NOT NULL'
ALTER TABLE dbo.VentasNumeros ALTER COLUMN IdEmpresa int NOT NULL
GO
PRINT ''
PRINT '12.3. ADD de FK_VentasNumeros_Empresas'
ALTER TABLE dbo.VentasNumeros ADD CONSTRAINT FK_VentasNumeros_Empresas
    FOREIGN KEY (IdEmpresa)
    REFERENCES dbo.Empresas (IdEmpresa)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
PRINT ''
PRINT '12.4. DROP de PK_VentasNumeros'
ALTER TABLE dbo.VentasNumeros DROP CONSTRAINT PK_VentasNumeros
GO
PRINT ''
PRINT '12.5. ADD de PK_VentasNumeros'
ALTER TABLE dbo.VentasNumeros ADD CONSTRAINT PK_VentasNumeros
    PRIMARY KEY CLUSTERED (IdTipoComprobante, LetraFiscal, CentroEmisor, IdEmpresa)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '13. Agregar IdEmpresa en ParametrosImagenes'
ALTER TABLE dbo.ParametrosImagenes ADD IdEmpresa int NULL
GO
PRINT ''
PRINT '13.1. Valores por defecto a ParametrosImagenes.IdEmpresa'
UPDATE ParametrosImagenes SET IdEmpresa = 1;
PRINT ''
PRINT '13.2. ParametrosImagenes.IdEmpresa NOT NULL'
ALTER TABLE dbo.ParametrosImagenes ALTER COLUMN IdEmpresa int NOT NULL
GO
PRINT ''
PRINT '13.3. ADD de FK_ParametrosImagenes_Empresas'
ALTER TABLE dbo.ParametrosImagenes ADD CONSTRAINT FK_ParametrosImagenes_Empresas
    FOREIGN KEY (IdEmpresa)
    REFERENCES dbo.Empresas (IdEmpresa)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
PRINT ''
PRINT '13.4. DROP de PK_ParametrosImagenes'
ALTER TABLE dbo.ParametrosImagenes DROP CONSTRAINT PK_ParametrosImagenes
GO
PRINT ''
PRINT '13.5. ADD de PK_ParametrosImagenes'
ALTER TABLE dbo.ParametrosImagenes ADD CONSTRAINT PK_ParametrosImagenes
    PRIMARY KEY CLUSTERED (IdParametroImagen,IdEmpresa)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '14. Agregar IdEmpresa en ParametrosArchivos'
ALTER TABLE dbo.ParametrosArchivos ADD IdEmpresa int NULL
GO
PRINT ''
PRINT '14.1. Valores por defecto a ParametrosArchivos.IdEmpresa'
UPDATE ParametrosArchivos SET IdEmpresa = 1;
PRINT ''
PRINT '14.2. ParametrosImagenes.IdEmpresa NOT NULL'
ALTER TABLE dbo.ParametrosArchivos ALTER COLUMN IdEmpresa int NOT NULL
GO
PRINT ''
PRINT '14.3. ADD de FK_ParametrosArchivos_Empresas'
ALTER TABLE dbo.ParametrosArchivos ADD CONSTRAINT FK_ParametrosArchivos_Empresas
    FOREIGN KEY (IdEmpresa)
    REFERENCES dbo.Empresas (IdEmpresa)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
PRINT ''
PRINT '14.4. DROP de PK_ParametrosArchivos'
ALTER TABLE dbo.ParametrosArchivos DROP CONSTRAINT PK_ParametrosArchivos
GO
PRINT ''
PRINT '14.4. ADD de PK_ParametrosArchivos'
ALTER TABLE dbo.ParametrosArchivos ADD CONSTRAINT PK_ParametrosArchivos
    PRIMARY KEY CLUSTERED (IdParametroArchivo,IdEmpresa)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

PRINT ''
PRINT '15. Agregar IdEmpresa en ParametrosArchivos'
    ALTER TABLE dbo.ClientesParametros ADD IdEmpresa int NULL
    GO
PRINT ''
PRINT '15.1. Valores por defecto a ClientesParametros.IdEmpresa'
    UPDATE ClientesParametros SET IdEmpresa = 1;
PRINT ''
PRINT '15.2. ClientesParametros.IdEmpresa NOT NULL'
    ALTER TABLE dbo.ClientesParametros ALTER COLUMN IdEmpresa int NOT NULL
    GO
PRINT ''
PRINT '15.3. DROP de PK_ClientesParametros'
    ALTER TABLE dbo.ClientesParametros DROP CONSTRAINT PK_ClientesParametros
    GO
PRINT ''
PRINT '15.4. ADD de PK_ClientesParametros'
    ALTER TABLE dbo.ClientesParametros ADD CONSTRAINT PK_ClientesParametros
        PRIMARY KEY CLUSTERED (IdCliente,NombreServidor,BaseDatos,IdEmpresa,IdParametro)
        WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    GO
PRINT ''
PRINT '15.3. ADD de FK_ClientesParametros_Empresas'
    ALTER TABLE dbo.ClientesParametros ADD CONSTRAINT FK_ClientesParametros_Empresas
        FOREIGN KEY (IdEmpresa)
        REFERENCES dbo.Empresas(IdEmpresa)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
    GO

PRINT ''
PRINT '16. Agregar FechaEnvioCorreo en Ventas'
ALTER TABLE dbo.Ventas ADD FechaEnvioCorreo datetime NULL
GO

PRINT ''
PRINT '17. Corregir parametrización de WEBARCHIVOSPRODSUCURACTUALIZASTOCKESTOYACA'
UPDATE Parametros
   SET ValorParametro = 'False'
 WHERE IdParametro = 'WEBARCHIVOSPRODSUCURACTUALIZASTOCKESTOYACA'


    ALTER TABLE dbo.Parametros              SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.ParametrosSucursales    SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.ParametrosImagenes      SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.ParametrosArchivos      SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.Compras                 SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.PeriodosFiscales        SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.Empresas                SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.Sucursales              SET (LOCK_ESCALATION = TABLE)
    ALTER TABLE dbo.VentasNumeros           SET (LOCK_ESCALATION = TABLE)

SET ANSI_PADDING OFF
GO

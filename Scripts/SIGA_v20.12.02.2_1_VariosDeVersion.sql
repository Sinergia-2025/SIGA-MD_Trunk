/****** Object:  Table [dbo].[TiposCalendarios]    Script Date: 01/12/2020 19:18:46 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
GO

PRINT ''
PRINT '1. Nueva Tabla: TiposCalendarios'
CREATE TABLE [dbo].[TiposCalendarios](
	[IdTipoCalendario] [smallint] NOT NULL,
	[NombreTipoCalendario] [varchar](30) NOT NULL,
 CONSTRAINT [PK_TiposCalendarios] PRIMARY KEY CLUSTERED ([IdTipoCalendario] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

PRINT ''
PRINT '1.1. Tabla TiposCalendarios: Información inicial'
INSERT INTO [dbo].[TiposCalendarios] ([IdTipoCalendario], [NombreTipoCalendario])
     VALUES (1 ,'General')
GO

IF dbo.BaseConCuit('30711934088') = 1
BEGIN
    PRINT ''
    PRINT '1.2. Tabla TiposCalendarios: Información inicial para Tifon'
    UPDATE [dbo].[TiposCalendarios]
       SET NombreTipoCalendario = 'Recepcion/Salida'
     WHERE IdTipoCalendario = 1
    INSERT INTO [dbo].[TiposCalendarios] ([IdTipoCalendario], [NombreTipoCalendario])
         VALUES (2 ,'Servicio'), (3, 'Botado')
END

PRINT ''
PRINT '2. Tabla Calendarios: Nuevo campo IdTipoCalendario'
ALTER TABLE dbo.Calendarios ADD IdTipoCalendario smallint NULL
GO
ALTER TABLE dbo.Calendarios ADD CONSTRAINT FK_Calendarios_TiposCalendarios
    FOREIGN KEY (IdTipoCalendario)
    REFERENCES dbo.TiposCalendarios (IdTipoCalendario)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '2.1. Tabla Calendarios: Datos históricos para campo IdTipoCalendario'
UPDATE Calendarios SET IdTipoCalendario = 1;
ALTER TABLE dbo.Calendarios ALTER COLUMN IdTipoCalendario smallint NOT NULL
GO

IF dbo.BaseConCuit('30711934088') = 1
BEGIN
    PRINT ''
    PRINT '2.2. Tabla Calendarios: Datos históricos para campo IdTipoCalendario para Tifon'
    UPDATE Calendarios
       SET IdTipoCalendario = CASE WHEN IdCalendario IN (2, 3, 4) THEN 2 ELSE 3 END
     WHERE IdCalendario > 1
END

PRINT ''
PRINT '3. Tabla Productos: Nuevo campo IdUnidadDeMedida2 y Conversion'
ALTER TABLE Productos ADD IdUnidadDeMedida2 CHAR(2) NULL
ALTER TABLE Productos ADD Conversion DECIMAL(12,6) NULL
GO

PRINT ''
PRINT '3.1. Tabla AuditoriaProductos: Nuevo campo IdUnidadDeMedida2 y Conversion'
ALTER TABLE AuditoriaProductos ADD IdUnidadDeMedida2 CHAR(2) NULL
ALTER TABLE AuditoriaProductos ADD Conversion DECIMAL(12,6) NULL
GO

DECLARE @um char(2) = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas WHERE IdUnidadDeMedida = 'UN')

IF @um IS NULL
    SET @um = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas)

PRINT @um

PRINT ''
PRINT '3.2. Tabla Productos: Actualización de registros pre-existentes'
UPDATE P SET P.IdUnidadDeMedida = @um, P.Tamano = 1 FROM Productos P WHERE P.IdUnidadDeMedida IS NULL
UPDATE P SET P.Conversion = 1 FROM Productos P
GO

PRINT ''
PRINT '3.3. Tabla Productos: Cambio los campos a NOT NULL: Conversion'
ALTER TABLE Productos ALTER COLUMN Conversion DECIMAL(12,6) NOT NULL
GO

PRINT ''
PRINT '3.4. FK_Productos_UnidadesDeMedidas2'
ALTER TABLE Productos 
	ADD CONSTRAINT FK_Productos_UnidadesDeMedidas2
	FOREIGN KEY (IdUnidadDeMedida2) REFERENCES UnidadesDeMedidas (IdUnidadDeMedida)
GO

PRINT ''
PRINT '4. Tabla VentasProductos: Nuevo campo CantidadManual y Conversion'
ALTER TABLE VentasProductos ADD Conversion DECIMAL(12,6) NULL
ALTER TABLE VentasProductos ADD CantidadManual DECIMAL(16,4) NULL
GO

PRINT ''
PRINT '4.1. Tabla VentasProductos: Actualización de los registros pre-existentes'
UPDATE VP SET VP.Conversion = 1, VP.CantidadManual = VP.Cantidad, VP.IdUnidadDeMedida = P.IdUnidadDeMedida
  FROM VentasProductos VP
 INNER JOIN Productos P ON VP.IdProducto = P.IdProducto
GO

PRINT ''
PRINT '4.2. Tabla VentasProductos: Cambio los campos a NOT NULL'
ALTER TABLE VentasProductos ALTER COLUMN Conversion DECIMAL(12,6) NOT NULL
ALTER TABLE VentasProductos ALTER COLUMN CantidadManual DECIMAL(16,4) NOT NULL
GO


PRINT ''
PRINT '4. Tabla PedidosProductos: Nuevo campo CantidadManual y Conversion'
ALTER TABLE PedidosProductos ADD Conversion DECIMAL(12,6) NULL
ALTER TABLE PedidosProductos ADD CantidadManual DECIMAL(16,4) NULL
GO

PRINT ''
PRINT '4.1. Tabla PedidosProductos: Actualización de los registros pre-existentes'
UPDATE PP SET PP.Conversion = 1, PP.CantidadManual = PP.Cantidad, PP.IdUnidadDeMedida = P.IdUnidadDeMedida
  FROM PedidosProductos PP
 INNER JOIN Productos P ON PP.IdProducto = P.IdProducto
GO

PRINT ''
PRINT '4.2. Cambio los campos a NOT NULL'
ALTER TABLE PedidosProductos ALTER COLUMN Conversion DECIMAL(12,6) NOT NULL
ALTER TABLE PedidosProductos ALTER COLUMN CantidadManual DECIMAL(16,4) NOT NULL
GO

PRINT ''
PRINT '5. Parámetro: URL Base para Turnos'
DECLARE @idParametro VARCHAR(MAX) = 'SIMOVILTURNOSURLBASE'
DECLARE @descripcionParametro VARCHAR(MAX) = 'URL Base para Turnos'
DECLARE @valorParametro VARCHAR(MAX) = 'http://tifon.sinergiamovil.com.ar/api/Turnos'
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

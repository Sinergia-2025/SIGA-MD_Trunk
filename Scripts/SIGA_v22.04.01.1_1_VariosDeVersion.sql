PRINT ''
PRINT '1. Tabla CuentasCorrientesPagos: Nuevas columnas FechaVencimiento4, ImporteVencimiento4, FechaVencimiento5, ImporteVencimiento5'
IF NOT EXISTS
    (SELECT *
       FROM INFORMATION_SCHEMA.COLUMNS
      WHERE COLUMN_NAME = 'FechaVencimiento4' AND TABLE_NAME = 'CuentasCorrientesPagos')
BEGIN
    ALTER TABLE CuentasCorrientesPagos ADD FechaVencimiento4 datetime NULL
    ALTER TABLE CuentasCorrientesPagos ADD ImporteVencimiento4 decimal(14,2) NULL
    ALTER TABLE CuentasCorrientesPagos ADD FechaVencimiento5 datetime NULL
    ALTER TABLE CuentasCorrientesPagos ADD ImporteVencimiento5 decimal(14,2) NULL
END
GO

PRINT ''
PRINT '2. Nueva tabla ContabilidadEstadosAsientos'
CREATE TABLE [dbo].[ContabilidadEstadosAsientos](
	[IdEstadoAsiento] [int] NOT NULL,
	[NombreEstadoAsiento] [varchar](30) NOT NULL,
	[PorDefectoManual] [bit] NOT NULL,
	[PorDefectoAutomatico] [bit] NOT NULL,
 CONSTRAINT [PK_ContabilidadEstadosAsientos] PRIMARY KEY CLUSTERED ([IdEstadoAsiento] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '2.1. Tabla ContabilidadEstadosAsientos: Registro inicial'
INSERT INTO [dbo].[ContabilidadEstadosAsientos]
    ([IdEstadoAsiento], [NombreEstadoAsiento], [PorDefectoManual], [PorDefectoAutomatico])
VALUES
    (1, 'CONFIRMADO', 'True', 'True')
GO

IF dbo.BaseConCuit('30717183769') = 1
BEGIN
    PRINT ''
    PRINT '2.2. Tabla ContabilidadEstadosAsientos: Registro PARA APROBAR'
    UPDATE ContabilidadEstadosAsientos
       SET PorDefectoManual = 'False'
    INSERT INTO [dbo].[ContabilidadEstadosAsientos]
        ([IdEstadoAsiento], [NombreEstadoAsiento], [PorDefectoManual], [PorDefectoAutomatico])
    VALUES
        (2, 'PARA APROBAR', 'True', 'False')
END

PRINT ''
PRINT '3. Tabla ContabilidadAsientos: Nuevas columnas IdEstadoAsiento'
ALTER TABLE dbo.ContabilidadAsientos ADD IdEstadoAsiento int NULL
GO

PRINT ''
PRINT '3.1. Tabla ContabilidadAsientos: Inicializa Registros Pre-Existentes para columna IdEstadoAsiento'
UPDATE ContabilidadAsientos SET IdEstadoAsiento = 1;
ALTER TABLE dbo.ContabilidadAsientos ALTER COLUMN IdEstadoAsiento int NOT NULL
GO

PRINT ''
PRINT '3.2. Tabla ContabilidadAsientos: FK_ContabilidadAsientos_ContabilidadEstadosAsientos'
ALTER TABLE dbo.ContabilidadAsientos ADD CONSTRAINT FK_ContabilidadAsientos_ContabilidadEstadosAsientos
    FOREIGN KEY (IdEstadoAsiento)
    REFERENCES dbo.ContabilidadEstadosAsientos (IdEstadoAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO



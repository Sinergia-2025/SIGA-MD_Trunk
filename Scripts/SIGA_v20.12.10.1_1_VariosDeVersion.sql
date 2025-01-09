/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.TiposCalendarios SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
PRINT ''
PRINT '1. Tabla TiposTurnos: Nuevo campo IdTipoCalendario'
ALTER TABLE dbo.TiposTurnos ADD IdTipoCalendario smallint NULL
GO
ALTER TABLE dbo.TiposTurnos ADD CONSTRAINT FK_TiposTurnos_TiposCalendarios
    FOREIGN KEY (IdTipoCalendario)
    REFERENCES dbo.TiposCalendarios (IdTipoCalendario)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.TiposTurnos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '1.1. Tabla TiposTurnos: Valores históricos para IdTipoCalendario'
UPDATE TiposTurnos SET IdTipoCalendario = (SELECT TOP 1 IdTipoCalendario FROM TiposCalendarios)

PRINT ''
PRINT '1.2. Tabla TiposTurnos: NOT NULL para IdTipoCalendario'
ALTER TABLE dbo.TiposTurnos ALTER COLUMN IdTipoCalendario smallint NOT NULL
GO


IF dbo.BaseConCuit('30711934088') = 1
BEGIN
    PRINT ''
    PRINT '1.3. Tabla TiposTurnos: Valores de IdTipoCalendario para Tifon'
    UPDATE TiposTurnos
       SET IdTipoCalendario = 2
     WHERE IdTipoTurno IN ('mec', 'SE')

    INSERT INTO TiposTurnos (IdTipoTurno,NombreTipoTurno,IdTipoCalendario) VALUES ('BOTADO', 'Botado', 3)

    UPDATE TurnosCalendarios
       SET IdTipoTurno = CASE WHEN IdCalendario = 1 THEN 'SE' ELSE CASE WHEN IdCalendario BETWEEN 2 AND 4 THEN 'S' ELSE 'BOTADO' END END
     WHERE IdTipoTurno IN ('A', 'C', 'E', 'T')

    DELETE TiposTurnos WHERE IdTipoTurno IN ('A', 'C', 'E', 'T')
END

PRINT ''
PRINT '2. Tabla MovimientosVentasProductosLotes: Campo Cantidad cambio en el tipo de DECIMAL: 18,0 >> 16,4'
ALTER TABLE MovimientosVentasProductosLotes
	ALTER COLUMN Cantidad DECIMAL(16,4) NOT NULL
GO

PRINT ''
PRINT '3. SET ValorParametro = True en CRMMuestraSolapaMasInfo'
UPDATE Parametros SET ValorParametro = 'True' WHERE IdParametro = 'CRMMUESTRASOLAPAMASINFO'
GO

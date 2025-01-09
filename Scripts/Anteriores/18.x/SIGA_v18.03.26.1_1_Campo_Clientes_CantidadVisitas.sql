--ALTER TABLE dbo.Clientes DROP CONSTRAINT DF_Clientes_CantidadVisitas
--ALTER TABLE dbo.Clientes DROP COLUMN CantidadVisitas
--ALTER TABLE dbo.AuditoriaClientes DROP COLUMN CantidadVisitas
--GO

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

ALTER TABLE dbo.Clientes ADD CantidadVisitas int NULL
GO
DECLARE @diasVisita int
SET @diasVisita = 7
UPDATE Clientes SET CantidadVisitas = @diasVisita;

MERGE INTO Parametros AS P
     USING (SELECT 'CLIENTESCANTIDADVISITASPORDEFECTO' AS IdParametro, @diasVisita ValorParametro, 'Cantidad de visitas Semanales por defecto' AS DescripcionParametro
            ) AS PT ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN UPDATE SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL , PT.DescripcionParametro)
;

ALTER TABLE dbo.Clientes ALTER COLUMN CantidadVisitas int NOT NULL
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT DF_Clientes_CantidadVisitas DEFAULT 0 FOR CantidadVisitas
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaClientes ADD CantidadVisitas int NULL
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.Prospectos ADD CantidadVisitas int NULL
GO
ALTER TABLE dbo.AuditoriaProspectos ADD CantidadVisitas int NULL
GO
UPDATE Prospectos SET CantidadVisitas = 7;
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT DF_Prospectos_CantidadVisitas DEFAULT 0 FOR CantidadVisitas
GO

COMMIT

SELECT DISTINCT CantidadVisitas FROM Clientes
SELECT * FROM Parametros WHERE IdParametro = 'CLIENTESCANTIDADVISITASPORDEFECTO'

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
ALTER TABLE dbo.EstadosOrdenesProduccion ADD Color int NULL
ALTER TABLE dbo.EstadosOrdenesProduccion ADD ReservaMateriaPrima bit NULL
ALTER TABLE dbo.EstadosOrdenesProduccion ADD GeneraProductoTerminado bit NULL
GO

UPDATE EstadosOrdenesProduccion
   SET Color = EP.Color
     , ReservaMateriaPrima = 0
     , GeneraProductoTerminado = 0
  FROM EstadosOrdenesProduccion EOP
  LEFT JOIN EstadosPedidos EP ON EP.IdEstado = EOP.IdEstado

ALTER TABLE dbo.EstadosOrdenesProduccion ALTER COLUMN Color int NOT NULL
ALTER TABLE dbo.EstadosOrdenesProduccion ALTER COLUMN ReservaMateriaPrima bit NOT NULL
ALTER TABLE dbo.EstadosOrdenesProduccion ALTER COLUMN GeneraProductoTerminado bit NOT NULL
GO

ALTER TABLE dbo.EstadosOrdenesProduccion DROP COLUMN AfectaPendiente
GO
ALTER TABLE dbo.EstadosOrdenesProduccion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

SELECT * FROM EstadosOrdenesProduccion

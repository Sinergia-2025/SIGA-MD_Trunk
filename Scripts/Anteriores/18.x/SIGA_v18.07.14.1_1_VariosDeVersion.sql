
PRINT ''
PRINT '1. Tabla LiquidacionesCargos: Agrego Campo CantidadDePCs.'
GO

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
ALTER TABLE dbo.LiquidacionesCargos ADD	CantidadDePCs int NULL
GO
ALTER TABLE dbo.LiquidacionesCargos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla LiquidacionesCargos: Asigno 0 (cero) al Campo CantidadDePCs.'
GO 

UPDATE LiquidacionesCargos 
   SET CantidadDePCs = 0
GO

PRINT ''
PRINT '3. Tabla LiquidacionesCargos: Ajusto NOT NULL al Campo CantidadDePCs.'
GO

ALTER TABLE dbo.LiquidacionesCargos ALTER COLUMN CantidadDePCs int NOT NULL
GO


PRINT ''
PRINT '4. Tabla LiquidacionesDetallesClientes: Agrego Campos PrecioLista, DescuentoRecargoPorc1, y DescuentoRecargoPorc1.'
GO

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
ALTER TABLE dbo.LiquidacionesDetallesClientes ADD
	PrecioLista decimal(12, 2) NULL,
	DescuentoRecargoPorc1 decimal(10, 5) NULL,
	DescuentoRecargoPorc2 decimal(10, 5) NULL
GO
ALTER TABLE dbo.LiquidacionesDetallesClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tabla LiquidacionesDetallesClientes: Asigno valores a los Campos PrecioLista, DescuentoRecargoPorc1, y DescuentoRecargoPorc1.'
GO

UPDATE LiquidacionesDetallesClientes 
  SET PrecioLista = Importe
	, DescuentoRecargoPorc1 = 0
	, DescuentoRecargoPorc2 = 0
GO


PRINT ''
PRINT '6. Tabla LiquidacionesDetallesClientes: Ajusto NOT NULL a los Campos PrecioLista, DescuentoRecargoPorc1, y DescuentoRecargoPorc1.'
GO

ALTER TABLE dbo.LiquidacionesDetallesClientes ALTER COLUMN PrecioLista decimal(12, 2) NOT NULL
GO

ALTER TABLE dbo.LiquidacionesDetallesClientes ALTER COLUMN DescuentoRecargoPorc1 decimal(10, 5) NOT NULL
GO
	
ALTER TABLE dbo.LiquidacionesDetallesClientes ALTER COLUMN DescuentoRecargoPorc2 decimal(10, 5) NOT NULL
GO


PRINT ''
PRINT '7. Tabla SubRubros: Agegos los Campos de D/R por Volumen.'
GO

ALTER TABLE SubRubros ADD UnidHasta1 int null
ALTER TABLE SubRubros ADD UnidHasta2 int null
ALTER TABLE SubRubros ADD UnidHasta3 int null
ALTER TABLE SubRubros ADD UnidHasta4 int null
ALTER TABLE SubRubros ADD UnidHasta5 int null
ALTER TABLE SubRubros ADD UHPorc1 decimal(14, 2) null
ALTER TABLE SubRubros ADD UHPorc2 decimal(14, 2) null
ALTER TABLE SubRubros ADD UHPorc3 decimal(14, 2) null
ALTER TABLE SubRubros ADD UHPorc4 decimal(14, 2) null
ALTER TABLE SubRubros ADD UHPorc5 decimal(14, 2) null
GO


PRINT ''
PRINT '8. Tabla SubRubros: Asigno Valor 0 a los Campos de D/R por Volumen.'
GO

UPDATE SubRubros 
   SET UnidHasta1 = 0,UnidHasta2 = 0,UnidHasta3 = 0,UnidHasta4 = 0,UnidHasta5 = 0
      ,UHPorc1    = 0,UHPorc2    = 0,UHPorc3    = 0,UHPorc4    = 0,UHPorc5    = 0
GO


PRINT ''
PRINT '9. Tabla SubRubros: Ajusto NOT NULL a los Campos de D/R por Volumen.'
GO

ALTER TABLE SubRubros ALTER COLUMN UnidHasta1 int not null
ALTER TABLE SubRubros ALTER COLUMN UnidHasta2 int not null
ALTER TABLE SubRubros ALTER COLUMN UnidHasta3 int not null
ALTER TABLE SubRubros ALTER COLUMN UnidHasta4 int not null
ALTER TABLE SubRubros ALTER COLUMN UnidHasta5 int not null
ALTER TABLE SubRubros ALTER COLUMN UHPorc1 decimal(14, 2) not null
ALTER TABLE SubRubros ALTER COLUMN UHPorc2 decimal(14, 2) not null
ALTER TABLE SubRubros ALTER COLUMN UHPorc3 decimal(14, 2) not null
ALTER TABLE SubRubros ALTER COLUMN UHPorc4 decimal(14, 2) not null
ALTER TABLE SubRubros ALTER COLUMN UHPorc5 decimal(14, 2) not null
GO


PRINT ''
PRINT '10. Tabla SubRubros: Asigno el Default 0 a los Campos de D/R por Volumen para Otros Sistemass.'
GO

ALTER TABLE SubRubros ADD DEFAULT 0 FOR UnidHasta1 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UnidHasta2 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UnidHasta3 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UnidHasta4 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UnidHasta5 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UHPorc1 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UHPorc2 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UHPorc3 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UHPorc4 
ALTER TABLE SubRubros ADD DEFAULT 0 FOR UHPorc5 
GO

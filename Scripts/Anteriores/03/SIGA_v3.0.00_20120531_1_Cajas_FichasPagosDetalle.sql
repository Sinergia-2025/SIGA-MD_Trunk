﻿
/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.FichasPagosDetalle ADD
	IdCaja int NULL,
	NumeroPlanilla int NULL,
	NumeroMovimiento int NULL
GO
ALTER TABLE dbo.FichasPagosDetalle ADD CONSTRAINT
	DF_FichasPagosDetalle_IdCaja DEFAULT ((1)) FOR IdCaja
GO
ALTER TABLE dbo.FichasPagosDetalle SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


-- Abria que hacer un proceso que ponga lo correcto, pero por ahora es lo mejor.
UPDATE [dbo].[FichasPagosDetalle]
   SET IdCaja = 1
     ,NumeroPlanilla = 
              (SELECT TOP 1 NumeroPlanilla FROM CajasDetalle
                WHERE IdSucursal = FichasPagosDetalle.IdSucursal 
                 AND IdCuentaCaja = 1 ORDER BY NumeroPlanilla)
     ,NumeroMovimiento = 
              (SELECT TOP 1 NumeroMovimiento FROM CajasDetalle
                WHERE IdSucursal = FichasPagosDetalle.IdSucursal 
                 AND IdCuentaCaja = 1 ORDER BY NumeroPlanilla)
GO

/* --------- */

ALTER TABLE dbo.FichasPagosDetalle ALTER COLUMN	IdCaja int NOT NULL
GO

ALTER TABLE dbo.FichasPagosDetalle ALTER COLUMN	NumeroPlanilla int NOT NULL
GO

ALTER TABLE dbo.FichasPagosDetalle ALTER COLUMN	NumeroMovimiento int NOT NULL
GO
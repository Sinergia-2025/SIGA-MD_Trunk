PRINT '1. Productos  Alto Ancho Largo.'
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
ALTER TABLE dbo.Productos ADD Alto decimal(9, 3)	NULL
GO
ALTER TABLE dbo.Productos ADD Ancho decimal(9, 3)	NULL
GO
ALTER TABLE dbo.Productos ADD Largo decimal(9, 3)	NULL
GO

UPDATE Productos SET Alto = 0, Ancho = 0 , Largo = 0;

ALTER TABLE dbo.Productos ALTER COLUMN Alto decimal(9, 3) NOT NULL
GO
ALTER TABLE dbo.Productos ALTER COLUMN Ancho decimal(9, 3) NOT NULL
GO
ALTER TABLE dbo.Productos ALTER COLUMN Largo decimal(9, 3) NOT NULL
GO

ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaProductos ADD Alto decimal(9, 3)	NULL
GO
ALTER TABLE dbo.AuditoriaProductos ADD Ancho decimal(9, 3)	NULL
GO
ALTER TABLE dbo.AuditoriaProductos ADD Largo decimal(9, 3)	NULL
GO


ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO

COMMIT


PRINT '2. Campo_Productos_OrigenPorcImpInt..'
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
ALTER TABLE dbo.Productos ADD OrigenPorcImpInt varchar(15) NULL
GO
UPDATE Productos SET OrigenPorcImpInt = 'BRUTO';
-- SOLO PARA RDS ACE
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro = '30714757128')
    BEGIN
        UPDATE Productos SET OrigenPorcImpInt = 'NETO';
    END
ALTER TABLE dbo.Productos ALTER COLUMN OrigenPorcImpInt varchar(15) NOT NULL
GO
ALTER TABLE dbo.Productos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaProductos ADD OrigenPorcImpInt varchar(15) NULL
GO
ALTER TABLE dbo.AuditoriaProductos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.VentasProductos ADD OrigenPorcImpInt varchar(15) NULL
GO
UPDATE VentasProductos SET OrigenPorcImpInt = 'BRUTO';
ALTER TABLE dbo.VentasProductos ALTER COLUMN OrigenPorcImpInt varchar(15) NOT NULL
GO
ALTER TABLE dbo.VentasProductos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.PedidosProductos ADD OrigenPorcImpInt varchar(15) NULL
GO
UPDATE PedidosProductos SET OrigenPorcImpInt = 'BRUTO';
ALTER TABLE dbo.PedidosProductos ALTER COLUMN OrigenPorcImpInt varchar(15) NOT NULL
GO
ALTER TABLE dbo.PedidosProductos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT '3. Datos_VentasProductos_OrigenPorcImpInt'
GO

UPDATE VentasProductos
   SET OrigenPorcImpInt = 'NETO'
 WHERE PorcImpuestoInterno <> 0
   AND CONVERT(DECIMAL(14,2), ROUND(ImporteTotalNeto * PorcImpuestoInterno / 100, 2)) = ImporteImpuestoInterno

UPDATE PedidosProductos
   SET OrigenPorcImpInt = 'NETO'
 WHERE PorcImpuestoInterno <> 0
   AND CONVERT(DECIMAL(14,2), ROUND(ImporteTotalNeto * PorcImpuestoInterno / 100, 2)) = ImporteImpuestoInterno


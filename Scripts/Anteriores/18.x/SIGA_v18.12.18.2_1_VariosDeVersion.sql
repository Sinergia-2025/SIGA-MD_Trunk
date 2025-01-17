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
ALTER TABLE dbo.VentasFormasPago ADD Porcentaje Decimal(8,2) Null
GO
UPDATE       VentasFormasPago
SET                Porcentaje = 0  
GO
ALTER TABLE VentasFormasPago ALTER COLUMN Porcentaje Decimal(8,2) Not Null
GO
COMMIT

/* Agrega y setea el campo ACTIVO para las Cuentas en las entidades Bancarias */

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

ALTER TABLE dbo.CuentasBancarias ADD Activo bit NULL
GO

ALTER TABLE dbo.CuentasBancarias SET (LOCK_ESCALATION = TABLE)
GO

COMMIT

/*-------------------------*/

UPDATE dbo.CuentasBancarias 
 SET Activo='True'
GO

/*-------------------------*/


ALTER TABLE dbo.CuentasBancarias ALTER COLUMN Activo bit NOT NULL 
GO


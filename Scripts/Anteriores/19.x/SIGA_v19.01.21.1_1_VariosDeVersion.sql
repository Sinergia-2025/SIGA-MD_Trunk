/* ----------------------------------------------------- */

PRINT ''
PRINT '1. Clientes Deudas Vendedor.'

ALTER TABLE ClientesDeudas ADD Vendedor varchar(100) null
GO

/* ----------------------------------------------------- */

PRINT ''
PRINT '2. CRM Novedades Descripcion.'


ALTER TABLE CRMNovedades ALTER COLUMN Descripcion varchar(300) not null
GO

/* ----------------------------------------------------- */
PRINT ''
PRINT '3. Datos Vencimiento de Licencia.'

-- SOLO HAR
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))

BEGIN

	UPDATE Clientes
	   SET VencimientoLicencia = '4000-01-01'
	 WHERE VencimientoLicencia IS NULL
	;

	UPDATE Clientes
	   SET VencimientoLicencia = '4000-01-01'
	 WHERE VencimientoLicencia > '2100'
	 ;

END;

/* ----------------------------------------------------- */

PRINT ''
PRINT '4. Categoria Nuevo Campo Control Backup.'

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
ALTER TABLE dbo.Categorias ADD ControlaBackup bit NULL
GO
UPDATE dbo.Categorias SET ControlaBackup = 'False'
GO
COMMIT

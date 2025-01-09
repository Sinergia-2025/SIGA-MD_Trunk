
ALTER TABLE Produccion ADD
	TipoDocResponsable varchar(5) NULL,
	NroDocResponsable varchar(12) NULL
GO

--Cambiar Responsable segun corresponda
UPDATE Produccion 
   SET TipoDocResponsable = 'COD',
    NroDocResponsable = '1'
GO


ALTER TABLE Produccion ALTER COLUMN 
    TipoDocResponsable varchar(5) NOT NULL 
GO

ALTER TABLE Produccion ALTER COLUMN 
	NroDocResponsable varchar(12) NOT NULL
GO

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
ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Produccion ADD CONSTRAINT
	FK_Produccion_Empleados FOREIGN KEY
	(
	TipoDocResponsable,
	NroDocResponsable
	) REFERENCES dbo.Empleados
	(
	TipoDocEmpleado,
	NroDocEmpleado
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Produccion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

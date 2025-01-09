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
ALTER TABLE dbo.EstadosClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Cobradores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CuentasCorrientes ADD
	IdCobrador int NULL,
	IdEstadoCliente int NULL
GO
ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT
	FK_CuentasCorrientes_Cobradores FOREIGN KEY
	(
	IdCobrador
	) REFERENCES dbo.Cobradores
	(
	IdCobrador
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT
	FK_CuentasCorrientes_EstadosClientes FOREIGN KEY
	(
	IdEstadoCliente
	) REFERENCES dbo.EstadosClientes
	(
	IdEstadoCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.CuentasCorrientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
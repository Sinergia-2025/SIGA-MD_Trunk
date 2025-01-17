
/* Agregar tabla de observaciones para cargos clientes*/
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
ALTER TABLE dbo.CargosClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.CargosClientesObservaciones
	(
	IdSucursal int NOT NULL,
	IdCliente bigint NOT NULL,
	IdCargo int NOT NULL,
	Linea int NOT NULL,
	Observacion nvarchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CargosClientesObservaciones ADD CONSTRAINT
	PK_CargosClientesObservaciones PRIMARY KEY CLUSTERED 
	(
	IdSucursal,
	IdCliente,
	IdCargo,
	Linea
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CargosClientesObservaciones ADD CONSTRAINT
	FK_CargosClientesObservaciones_CargosClientes FOREIGN KEY
	(
	IdCliente,
	IdCargo,
	IdSucursal
	) REFERENCES dbo.CargosClientes
	(
	IdCliente,
	IdCargo,
	IdSucursal
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CargosClientesObservaciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

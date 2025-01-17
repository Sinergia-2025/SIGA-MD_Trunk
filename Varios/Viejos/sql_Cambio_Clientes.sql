

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
ALTER TABLE dbo.Clientes ADD
	Cuit varchar(13) NULL,
	TipoDocVendedor varchar(5) NULL,
	NroDocVendedor varchar(12) NULL,
	Observacion varchar(200) NULL
GO
COMMIT


UPDATE Clientes SET
  TipoDocVendedor='COD', 
  NroDocVendedor='1'
 WHERE TipoDocVendedor IS NULL;


UPDATE Clientes SET
  IdLocalidadTrabajo = NULL
 WHERE IdLocalidadTrabajo = 0 ;


/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_Empleados FOREIGN KEY
	(
	TipoDocVendedor,
	NroDocVendedor
	) REFERENCES dbo.Empleados
	(
	TipoDocEmpleado,
	NroDocEmpleado
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_Localidades FOREIGN KEY
	(
	IdLocalidad
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_LocalidadesTrabajo FOREIGN KEY
	(
	IdLocalidadTrabajo
	) REFERENCES dbo.Localidades
	(
	IdLocalidad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

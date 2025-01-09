
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
ALTER TABLE dbo.Clientes ADD
	VencimientoLicencia datetime NULL,
	BackupAutoCuenta varchar(100) NULL,
	BackupAutoConfig bit NULL,
	TienePreciosConIVA bit NULL,
	ConsultaPreciosConIVA bit NULL,
	TieneServidorDedicado bit NULL,
	MotorBaseDatos varchar(80) NULL,
	CantidadDePCs int NULL,
	HorasCapacitacionPactadas int NULL,
	HorasCapacitacionRealizadas int NULL
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Prospectos ADD
	VencimientoLicencia datetime NULL,
	BackupAutoCuenta varchar(100) NULL,
	BackupAutoConfig bit NULL,
	TienePreciosConIVA bit NULL,
	ConsultaPreciosConIVA bit NULL,
	TieneServidorDedicado bit NULL,
	MotorBaseDatos varchar(80) NULL,
	CantidadDePCs int NULL,
	HorasCapacitacionPactadas int NULL,
	HorasCapacitacionRealizadas int NULL
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaClientes ADD
	VencimientoLicencia datetime NULL,
	BackupAutoCuenta varchar(100) NULL,
	BackupAutoConfig bit NULL,
	TienePreciosConIVA bit NULL,
	ConsultaPreciosConIVA bit NULL,
	TieneServidorDedicado bit NULL,
	MotorBaseDatos varchar(80) NULL,
	CantidadDePCs int NULL,
	HorasCapacitacionPactadas int NULL,
	HorasCapacitacionRealizadas int NULL
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProspectos ADD
	VencimientoLicencia datetime NULL,
	BackupAutoCuenta varchar(100) NULL,
	BackupAutoConfig bit NULL,
	TienePreciosConIVA bit NULL,
	ConsultaPreciosConIVA bit NULL,
	TieneServidorDedicado bit NULL,
	MotorBaseDatos varchar(80) NULL,
	CantidadDePCs int NULL,
	HorasCapacitacionPactadas int NULL,
	HorasCapacitacionRealizadas int NULL
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

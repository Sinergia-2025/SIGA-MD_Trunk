-- Drop CHECK CONSTRAINT from the table
ALTER TABLE Retenciones
	DROP CONSTRAINT FK_Retenciones_Regimenes
GO

-- Drop a column from the table
ALTER TABLE Retenciones
	DROP COLUMN IdRegimen 
GO

EXEC sp_rename 'RetencionesCompras.IdCajaIngreso', 'IdCajaEgreso', 'COLUMN'
GO

EXEC sp_rename 'RetencionesCompras.NroPlanillaIngreso', 'NroPlanillaEgreso', 'COLUMN'
GO

EXEC sp_rename 'RetencionesCompras.NroMovimientoIngreso', 'NroMovimientoEgreso', 'COLUMN'
GO

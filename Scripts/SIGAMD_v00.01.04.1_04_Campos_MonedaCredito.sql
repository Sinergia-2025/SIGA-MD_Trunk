PRINT ''
PRINT '1. Nuevo Campo MonedaCredito: MonedaCredito.'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'MonedaCredito' AND TABLE_NAME = 'Clientes')
BEGIN
	ALTER TABLE Clientes ADD MonedaCredito Int NULL
	ALTER TABLE AuditoriaClientes ADD MonedaCredito Int NULL
	ALTER TABLE Prospectos ADD MonedaCredito Int NULL
	ALTER TABLE AuditoriaProspectos ADD MonedaCredito Int NULL
END
GO

PRINT ''
PRINT '2. Nuevo Campo MonedaCredito: MonedaCredito.'
BEGIN
	UPDATE Clientes SET MonedaCredito = 1
	ALTER TABLE Clientes ALTER COLUMN MonedaCredito Int NOT NULL

	ALTER TABLE Clientes WITH CHECK ADD  
		CONSTRAINT [FK_MonedaCredito] FOREIGN KEY([MonedaCredito])
		REFERENCES [dbo].[Monedas] ([IdMoneda])

	UPDATE AuditoriaClientes SET MonedaCredito = 1
	ALTER TABLE AuditoriaClientes ALTER COLUMN MonedaCredito Int NOT NULL

	UPDATE Prospectos SET MonedaCredito = 1
	ALTER TABLE Prospectos ALTER COLUMN MonedaCredito Int NOT NULL

	UPDATE AuditoriaProspectos SET MonedaCredito = 1
	ALTER TABLE AuditoriaProspectos ALTER COLUMN MonedaCredito Int NOT NULL
END
GO

PRINT ''
PRINT '3. Nuevo Campos Descripcion-Observacion'
IF not exists(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'Descripcion' AND TABLE_NAME = 'ClientesDirecciones')
BEGIN
	ALTER TABLE ClientesDirecciones ADD Descripcion Varchar(100) NULL
	ALTER TABLE ClientesDirecciones ADD Observacion Varchar(100) NULL

	ALTER TABLE ProspectosDirecciones ADD Descripcion Varchar(100) NULL
	ALTER TABLE ProspectosDirecciones ADD Observacion Varchar(100) NULL

END
GO

PRINT ''
PRINT '1. Tabla Pedidos: Agregar Campo NroVersionAplicacion y NroVersionRemoto'
ALTER TABLE dbo.Pedidos ADD NroVersionAplicacion varchar(50) NULL
ALTER TABLE dbo.Pedidos ADD NroVersionRemoto varchar(50) NULL

PRINT ''
PRINT '2. Tabla VersionesScriptsEjecuciones: Cambiar tamaño de campo Mensaje a VARCHAR(MAX)'
ALTER TABLE VersionesScriptsEjecuciones ALTER COLUMN Mensaje VARCHAR(MAX) NULL

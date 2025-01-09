PRINT ''
PRINT '1. Nuevo Campo: IdLocalidad'
ALTER TABLE Pedidos ADD IdLocalidad INT NULL
GO 

PRINT ''
PRINT '1.1 FK_Pedidos_Localidades'
ALTER TABLE Pedidos ADD CONSTRAINT FK_Pedidos_Localidades
	FOREIGN KEY (IdLocalidad) REFERENCES Localidades (IdLocalidad)
GO

PRINT ''
PRINT '2. Nuevo Campo: Cuit'
ALTER TABLE Pedidos ADD Cuit VARCHAR(13) NULL
GO

PRINT ''
PRINT '3. Nuevo Campo: Direccion'
ALTER TABLE Pedidos ADD Direccion VARCHAR(100) NULL
GO

PRINT ''
PRINT '4. Nuevo Campo: TipoDocCliente'
ALTER TABLE Pedidos ADD TipoDocCliente VARCHAR(5) NULL
GO

PRINT ''
PRINT '5. Nuevo Campo: NroDocCliente'
ALTER TABLE Pedidos ADD NroDocCliente BIGINT NULL
GO

PRINT ''
PRINT '6. Nuevo Campo: NombreCliente'
ALTER TABLE Pedidos ADD NombreCliente VARCHAR(100) NULL
GO
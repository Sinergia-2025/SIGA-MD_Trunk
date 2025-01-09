PRINT ''
PRINT '1.1. Tabla Productos: Nuevo Campo de Nivel de Inspeccion'
IF dbo.ExisteCampo('Productos', 'NivelInspeccion') = 0
BEGIN
    ALTER TABLE Productos ADD RealizaControlCalidad bit NULL
    ALTER TABLE Productos ADD NivelInspeccion varchar(10) NULL
    ALTER TABLE AuditoriaProductos ADD RealizaControlCalidad bit NULL
    ALTER TABLE AuditoriaProductos ADD NivelInspeccion varchar(10) NULL
END
GO

PRINT ''
PRINT '1.2. Tabla Productos: Nuevo Campo de Realiza Control Calidad'
BEGIN
    UPDATE Productos SET RealizaControlCalidad = 0 WHERE RealizaControlCalidad IS NULL
	ALTER TABLE Productos ALTER COLUMN RealizaControlCalidad bit NOT NULL

    UPDATE Productos SET NivelInspeccion = '' WHERE NivelInspeccion IS NULL
	ALTER TABLE Productos ALTER COLUMN NivelInspeccion varchar(10) NOT NULL
END
GO

DELETE FROM RolesFunciones WHERE IdFuncion = 'VincularPedidos'
DELETE FROM Funciones WHERE Id = 'VincularPedidos'

DELETE FROM RolesFunciones WHERE IdFuncion = 'DesvincularPedidos'
DELETE FROM Funciones WHERE Id = 'DesvincularPedidos'

UPDATE EstadosPedidosProveedores
   SET IdTipoEstado = 'ENTREGADO'
 WHERE IdTipoEstado = 'FINALIZADO'
UPDATE EstadosPedidosProveedores
   SET IdTipoEstado = 'RECHAZADO'
 WHERE IdTipoEstado = 'CANCELADO'

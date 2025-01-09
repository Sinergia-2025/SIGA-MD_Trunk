PRINT ''
PRINT '1. Tabla LiquidacionesCargos: Nuevo campo Selecciono'
ALTER TABLE LiquidacionesCargos ADD Selecciono VARCHAR(5) NULL
GO
PRINT ''
PRINT '1.1 Tabla LiquidacionesCargos: Ajuste histórico del campo Selecciono'
UPDATE LiquidacionesCargos SET Selecciono = 'SI'
PRINT ''
PRINT '1.2 Tabla LiquidacionesCargos: NOT NULL a Selecciono'
ALTER TABLE LiquidacionesCargos ALTER COLUMN Selecciono VARCHAR(5) NOT NULL
GO

PRINT ''
PRINT '2. Tabla Compras: Nuevo Campo ImpuestosInternos'
ALTER TABLE Compras ADD ImpuestosInternos	decimal(14, 2)	null
GO
PRINT ''
PRINT '2.1. Tabla Compras: Valor por defecto para Campo ImpuestosInternos'
UPDATE Compras SET ImpuestosInternos = 0
PRINT ''
PRINT '2.2. Tabla Compras: NOT NULL para Campo ImpuestosInternos'
ALTER TABLE Compras ALTER COLUMN ImpuestosInternos	decimal(14, 2)	not null
GO

PRINT ''
PRINT '3. Tabla MovimientosCompras: Nuevo Campo ImpuestosInternos'
ALTER TABLE MovimientosCompras ADD ImpuestosInternos	decimal(14, 2)	null
GO
PRINT ''
PRINT '3.1. Tabla MovimientosCompras: Valor por defecto para ImpuestosInternos'
UPDATE MovimientosCompras SET ImpuestosInternos = 0
PRINT ''
PRINT '3.2. Tabla MovimientosCompras: NOT NULL para ImpuestosInternos'
ALTER TABLE MovimientosCompras ALTER COLUMN ImpuestosInternos	decimal(14, 2)	not null
GO

PRINT ''
PRINT '4. Tabla Proyectos: Nuevo campo IdPrioridad'
ALTER TABLE Proyectos ADD IdPrioridad INT NULL
GO
PRINT ''
PRINT '4.1. Tabla Proyectos: Valores historicos para IdPrioridad'
UPDATE Proyectos SET IdPrioridad = 1
PRINT ''
PRINT '4.2 Tabla Proyectos: NOT NULL para IdPrioridad'
ALTER TABLE Proyectos ALTER COLUMN IdPrioridad INT NOT NULL
GO

PRINT ''
PRINT '5. Nueva Tabla: Clasificaciones'
CREATE TABLE Clasificaciones(
	IdClasificacion INT NOT NULL,
	NombreClasificacion VARCHAR(30) NOT NULL
	PRIMARY KEY(IdClasificacion)
)
GO

PRINT ''
PRINT '5.1. Tabla Clasificaciones: Inicializar datos iniciales'
INSERT INTO Clasificaciones (IdClasificacion, NombreClasificacion) VALUES
	 (1,'Interna')
	,(2,'Externa')
	,(3,'Abono')
GO

PRINT ''
PRINT '6. Tabla Proyectos: Nuevo Campo IdClasificacion'
ALTER TABLE Proyectos ADD IdClasificacion INT NULL
GO
PRINT ''
PRINT '6.1. Tabla Proyectos: Actualización de datos históricos de IdClasificacion'
UPDATE Proyectos SET IdClasificacion = 1 -- Interna
PRINT ''
PRINT '6.2. Tabla Proyectos: NOT NULL para IdClasificacion'
ALTER TABLE Proyectos ALTER COLUMN IdClasificacion INT NOT NULL
GO
PRINT ''
PRINT '6.3 Tabla Proyectos: FK_Proyectos_Clasificaciones'
ALTER TABLE Proyectos
	ADD CONSTRAINT FK_Proyectos_Clasificaciones
	FOREIGN KEY (IdClasificacion) REFERENCES Clasificaciones (IdClasificacion)
GO

PRINT ''
PRINT '7. Normalización de la infomación PRE Existente'
DELETE LO FROM LiquidacionesObservaciones LO
WHERE NOT EXISTS 
   ( SELECT * FROM LiquidacionesCargos LC
         WHERE LC.IdSucursal = LO.IdSucursal
           AND LC.IdTipoLiquidacion = LO.IdTipoLiquidacion
           AND LC.PeriodoLiquidacion = LO.PeriodoLiquidacion
           AND LC.IdCliente = LO.IdCliente
     ) 
GO

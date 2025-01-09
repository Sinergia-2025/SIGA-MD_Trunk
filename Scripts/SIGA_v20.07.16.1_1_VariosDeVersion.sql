PRINT ''
PRINT '1. Nueva Tabla: ProyectosEstados'
CREATE TABLE ProyectosEstados(
	IdEstado INT NOT NULL,
	NombreEstado VARCHAR(30) NOT NULL
	PRIMARY KEY (IdEstado)
)
GO

PRINT ''
PRINT '2. Alta de ProyectosEstados'
INSERT INTO ProyectosEstados (IdEstado, NombreEstado) VALUES
	(1,'Pendiente'),
	(2,'Ejecutando'),
	(3,'Abono'),
	(4,'Cerrado')
GO

PRINT ''
PRINT '3. Nuevo Campo en Proyectos: IdEstado'
ALTER TABLE Proyectos
	ADD IdEstado INT NULL
GO

PRINT ''
PRINT '4. Actualización de Estado de los registros pre existentes'
UPDATE P SET P.IdEstado = (SELECT PE.IdEstado FROM ProyectosEstados PE WHERE PE.NombreEstado = P.Estado) 
	FROM Proyectos P
GO

PRINT ''
PRINT '5. FK Proyectos_ProyectosEstados'
ALTER TABLE Proyectos
	ADD CONSTRAINT FK_Proyectos_ProyectosEstados
	FOREIGN KEY (IdEstado) REFERENCES ProyectosEstados (IdEstado)
GO

PRINT ''
PRINT '6. Actualización del campo a NOT NULL'
ALTER TABLE Proyectos 
	ALTER COLUMN IdEstado INT NOT NULL
GO

PRINT ''
PRINT '7. Elimino el campo Estado de la tabla Proyectos'
ALTER TABLE Proyectos
	DROP COLUMN Estado
GO

PRINT ''
PRINT '1. Nuevas Columnas en el buscador de Proyectos'
INSERT INTO BuscadoresCampos (
	IdBuscador
	,IdBuscadorNombreCampo
	,Orden
	,Titulo
	,Alineacion
	,Ancho
	,Formato
) VALUES 
	(12,'IdPrioridad',1,'Prioridad',32,60,''),
	(12,'NombreDeFantasia',5,'Nombre de Fantasía',16,250,''),
	(12,'NombreEstado',6,'Estado',16,100,''),
	(12,'NombreClasificacion',7,'Clasificación',16,100,'')
GO

PRINT ''
PRINT '2. Actualizo las posiciones del resto de los campos'
UPDATE BuscadoresCampos SET
	Orden = 2 WHERE IdBuscador = 12 AND IdBuscadorNombreCampo = 'IdProyecto'
UPDATE BuscadoresCampos SET
	Orden = 3 WHERE IdBuscador = 12 AND IdBuscadorNombreCampo = 'NombreProyecto'
UPDATE BuscadoresCampos SET
	Orden = 4 WHERE IdBuscador = 12 AND IdBuscadorNombreCampo = 'NombreCliente'
GO

PRINT ''
PRINT '1. Nuevo Campo en Proyectos: IdPrioridadImporte'
ALTER TABLE Proyectos
	ADD IdPrioridadImporte INT NULL
GO

PRINT ''
PRINT '2. Nuevo Campo en Proyectos: IdPrioridadEstrategico'
ALTER TABLE Proyectos
	ADD IdPrioridadEstrategico INT NULL
GO

PRINT ''
PRINT '3. Nuevo Campo en Proyectos: IdPrioridadComplejidad'
ALTER TABLE Proyectos
	ADD IdPrioridadComplejidad INT NULL
GO

PRINT ''
PRINT '4. Nuevo Campo en Proyectos: IdPrioridadReplicabilidad'
ALTER TABLE Proyectos
	ADD IdPrioridadReplicabilidad INT NULL
GO

PRINT ''
PRINT '5. Borrar columna IdPrioridad en Proyectos'
ALTER TABLE Proyectos
	DROP COLUMN IdPrioridad
GO

PRINT ''
PRINT '6. Nuevo Campo en Proyectos: IdPrioridadProyecto'
ALTER TABLE Proyectos
	ADD IdPrioridadProyecto DECIMAL(5,2) NULL
GO

PRINT ''
PRINT '7. Actualización de datos históricos'
UPDATE Proyectos SET
	IdPrioridadImporte = 5,
	IdPrioridadEstrategico = 5,
	IdPrioridadComplejidad = 5,
	IdPrioridadReplicabilidad = 5,
	IdPrioridadProyecto = 5
GO

PRINT ''
PRINT '8. Actualizo los campos a NOT NULL'
ALTER TABLE Proyectos
	ALTER COLUMN IdPrioridadImporte INT NOT NULL
GO
ALTER TABLE Proyectos
	ALTER COLUMN IdPrioridadEstrategico INT NOT NULL
GO
ALTER TABLE Proyectos
	ALTER COLUMN IdPrioridadComplejidad INT NOT NULL
GO
ALTER TABLE Proyectos
	ALTER COLUMN IdPrioridadReplicabilidad INT NOT NULL
GO
ALTER TABLE Proyectos
	ALTER COLUMN IdPrioridadProyecto DECIMAL(5,2) NOT NULL
GO

IF dbo.ExisteFuncion('CRMInformes') = 'True'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfNovedadesPorProyecto', 'Inf. Novedades por Proyecto', 'Inf. Novedades por Proyecto', 'True', 'False', 'True', 'True'
        ,'CRMInformes', 400, 'Eniac.Win', 'InfNovedadesPorProyecto', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfNovedadesPorProyecto' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'EquipoLider')
END 
GO
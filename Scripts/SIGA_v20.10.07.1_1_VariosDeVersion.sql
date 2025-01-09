PRINT ''
PRINT '1. Tabla PedidosProductos: Nuevo campo ModificoPrecioManualmente'
ALTER TABLE PedidosProductos ADD ModificoPrecioManualmente BIT NULL
GO

PRINT ''
PRINT '1.1. Tabla PedidosProductos: Valores historicos ModificoPrecioManualmente'
UPDATE PedidosProductos SET	ModificoPrecioManualmente = 0
GO

PRINT ''
PRINT '1.2. Tabla PedidosProductos: NOT NULL en ModificoPrecioManualmente'
ALTER TABLE PedidosProductos ALTER COLUMN ModificoPrecioManualmente BIT NOT NULL
GO

PRINT ''
PRINT '2. Tabla Empleados: Nuevo campo IdUsuarioMovil'
ALTER TABLE dbo.Empleados ADD IdUsuarioMovil varchar(10) NULL
GO
PRINT ''
PRINT '2.1. Tabla Empleados: Nuevo campo FK_Empleados_UsuariosMovil'
ALTER TABLE dbo.Empleados ADD CONSTRAINT FK_Empleados_UsuariosMovil
    FOREIGN KEY (IdUsuarioMovil)
    REFERENCES dbo.Usuarios (Id)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '3. Tabla Ventas: Nuevo campo FechaExportacion'
ALTER TABLE Ventas ADD FechaExportacion DATETIME NULL
GO

PRINT ''
PRINT '4. Tabla MovilRutas: Nuevo campo ConfiguraClienteSegun'
ALTER TABLE dbo.MovilRutas ADD ConfiguraClienteSegun varchar(15) NULL
GO

PRINT ''
PRINT '4.1. Tabla MovilRutas: Valor Historico ConfiguraClienteSegun'
UPDATE MovilRutas SET ConfiguraClienteSegun = 'RUTADIA';  -- RUTADIA / CLIENTE / MOVIMIENTO

PRINT ''
PRINT '4.2. Tabla MovilRutas: NOT NULL para ConfiguraClienteSegun'
ALTER TABLE dbo.MovilRutas ALTER COLUMN ConfiguraClienteSegun varchar(15) NOT NULL
GO

PRINT ''
PRINT '5. Tabla ProyectosEstados: Agregar Campos Finalizado y Color.'
ALTER TABLE dbo.ProyectosEstados ADD
	Finalizado bit NULL,
	Color int NULL
GO

PRINT ''
PRINT '5.2. Tabla ProyectosEstados: Actualizar Campos Finalizado y Color.'
UPDATE ProyectosEstados SET Finalizado = 'False'
UPDATE ProyectosEstados SET Finalizado = 'True'
 WHERE NombreEstado IN ('Cerrado','Finalizado','Cancelado','No Aprobado')
UPDATE ProyectosEstados SET Color = -65536	/*Rojo*/
 WHERE NombreEstado IN ('Cerrado','Finalizado','Cancelado','No Aprobado','Suspendido')
GO

PRINT ''
PRINT '5.3. Tabla ProyectosEstados: Volver NOT NULL A Campo Finalizado.'
ALTER TABLE dbo.ProyectosEstados ALTER COLUMN Finalizado bit NOT NULL
GO

PRINT ''
PRINT '6. Tabla Ventas: Nuevo campo IdPaciente'
ALTER TABLE Ventas ADD IdPaciente BIGINT NULL
GO
PRINT ''
PRINT '6.1. Tabla Ventas: ADD FK_Ventas_Clientes_Paciente'
ALTER TABLE Ventas ADD CONSTRAINT FK_Ventas_Clientes_Paciente
	FOREIGN KEY (IdPaciente) REFERENCES Clientes (IdCliente)
GO

PRINT ''
PRINT '7. Tabla Ventas: Nuevo campo IdDoctor'
ALTER TABLE Ventas ADD IdDoctor BIGINT NULL
GO

PRINT ''
PRINT '7.1. Tabla Ventas: ADD FK_Ventas_Clientes_Doctor'
ALTER TABLE Ventas ADD CONSTRAINT FK_Ventas_Clientes_Doctor
	FOREIGN KEY (IdDoctor) REFERENCES Clientes (IdCliente)
GO

PRINT ''
PRINT '8. Tabla Ventas: Nuevo campo FechaCirugia'
ALTER TABLE Ventas ADD FechaCirugia DATETIME NULL
GO



PRINT ''
PRINT '1. Nueva Función: Importar Contactos de Clientes desde Excel'

IF dbo.ExisteFuncion('Procesos') = 'True'
BEGIN
	INSERT INTO Funciones
				(Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
				,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
	VALUES
				('ImportarClientesContactosExcel', 'Importar Contactos de Clientes desde Excel', 'Importar Contactos de Clientes desde Excel', 'True', 'False', 'True', 'True'
				,'Procesos', 97, 'Eniac.Win', 'ImportarClientesContactosExcel', NULL, NULL
				,'True', 'S', 'N', 'N', 'N');

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'ImportarClientesContactosExcel' FROM RolesFunciones 
	 WHERE IdFuncion = 'Procesos';
END
GO

PRINT ''
PRINT '0. Estados Turismo: Agrega columna Solicita Pasajeros'

ALTER TABLE EstadosTurismo ADD SolicitaPasajeros bit null
GO

UPDATE EstadosTurismo SET SolicitaPasajeros = 'False'
GO

ALTER TABLE EstadosTurismo ALTER COLUMN SolicitaPasajeros bit not null
GO

ALTER TABLE Reservas ADD IdUnicoReserva bigint null
GO



IF dbo.BaseConCuit('30714374938') = 'True'
BEGIN
    PRINT ''
    PRINT '0.- Tabla TiposVehiculos: Inicialización de Datos'
 
 
INSERT INTO [dbo].[TiposVehiculos]
           ([IdTipoVehiculo]
           ,[NombreTipoVehiculo])
     VALUES
           (1, 'MICRO Doble Piso')

INSERT INTO [dbo].[TiposVehiculos]
           ([IdTipoVehiculo]
           ,[NombreTipoVehiculo])
     VALUES
           (2, 'MICRO Piso Bajo')

INSERT INTO [dbo].[TiposVehiculos]
           ([IdTipoVehiculo]
           ,[NombreTipoVehiculo])
     VALUES
           (3, 'Minibus')

INSERT INTO [dbo].[TiposVehiculos]
           ([IdTipoVehiculo]
           ,[NombreTipoVehiculo])
     VALUES
           (4, 'Sprinter')

END



	PRINT ''
	PRINT '1. Creo la tabla Calles si no existe'
	IF OBJECT_ID (N'dbo.Calles', N'U') IS NULL 
	BEGIN
		CREATE TABLE [dbo].[Calles](
			[IdCalle] [int] NOT NULL,
			[NombreCalle] [varchar](100) NOT NULL,
			[IdLocalidad] [int] NOT NULL,
		 CONSTRAINT [PK_Calles] PRIMARY KEY CLUSTERED 
		(
			[IdCalle] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]

		ALTER TABLE [dbo].[Calles]  WITH NOCHECK ADD  CONSTRAINT [FK_Calles_Localidades] FOREIGN KEY([IdLocalidad])
		REFERENCES [dbo].[Localidades] ([IdLocalidad])

		ALTER TABLE [dbo].[Calles] CHECK CONSTRAINT [FK_Calles_Localidades]
	END

	PRINT ''
	PRINT '2. Si la tabla de Calles no tiene registros, creo uno generico'
	IF NOT EXISTS (SELECT* FROM Calles)
		INSERT INTO [dbo].[Calles]
				   ([IdCalle]
				   ,[NombreCalle]
				   ,[IdLocalidad])
			 VALUES
				   (1 ,'General',2000);


	PRINT ''
	PRINT '3. Creo opciones de LIVE en SIGA si estoy en la aplicación SILIVE'
	IF EXISTS (SELECT * FROM Funciones F
				INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
				WHERE F.Id = 'Logistica')
	BEGIN
		INSERT INTO Funciones
				 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
				 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		 VALUES
		   ('Logistica', 'Logistica', 'Logistica', 
			'True', 'False', 'True', 'True', NULL, 3, '', '', null, null,
				  'True', 'S', 'N', 'N', 'N');
	
		INSERT INTO RolesFunciones 
					  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'Logistica' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

		--CALLES
			INSERT INTO Funciones
				 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
				 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		 VALUES
		   ('CallesABM', 'Calles', 'Calles', 
			'True', 'False', 'True', 'True', 'Logistica', 44, 'Eniac.Win', 'CallesABM', null, null,
				  'True', 'S', 'N', 'N', 'N');
	

		INSERT INTO RolesFunciones 
					  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'CallesABM' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

		--ABM CLIENTES LIVE
		INSERT INTO Funciones
				 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
				 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
				 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
		VALUES
		   ('ClientesLIVEABM', 'Clientes', 'Clientes', 
			'True', 'False', 'True', 'True', 'Logistica', 44, 'Eniac.Win', 'ClientesLIVEABM', null, null,
				  'True', 'S', 'N', 'N', 'N');
	

		INSERT INTO RolesFunciones 
					  (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'ClientesLIVEABM' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
	END
	GO

	PRINT ''
	PRINT '4. Creo campos de Cliente de SILIVE en SIGA'

	IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'Clientes'
              AND COLUMN_NAME = 'Contacto') 
		ALTER TABLE Clientes ADD Contacto varchar(100) null;
	GO

	ALTER TABLE Clientes ADD FechaBaja	datetime	null;
	ALTER TABLE Clientes ADD  VerEnConsultas	bit	null;
	ALTER TABLE Clientes ADD IdCalle	int	null;
	ALTER TABLE Clientes ADD Altura	int	null;
	ALTER TABLE Clientes ADD IdCalle2	int	null;
	ALTER TABLE Clientes ADD Altura2	int	null;
	ALTER TABLE Clientes ADD DireccionAdicional2	varchar(100)	null;
	ALTER TABLE Clientes ADD TelefonosParticulares	varchar(100)	null;
	ALTER TABLE Clientes ADD Fax	varchar(100)	null;
	ALTER TABLE Clientes ADD FechaSUS	datetime	null;
	ALTER TABLE Clientes ADD TipoDocDadoAltaPor	varchar(5)	null;
	ALTER TABLE Clientes ADD NroDocDadoAltaPor	varchar(12)	null;
	ALTER TABLE Clientes ADD HabilitarVisita	bit	null;
	ALTER TABLE Clientes ADD Direccion2	varchar(100)	null;
	ALTER TABLE Clientes ADD IdLocalidad2	int	null;
	ALTER TABLE Clientes ADD ObservacionWeb	varchar(200)	null;
	ALTER TABLE Clientes ADD RepartoIndependiente	bit	null;
	GO

	UPDATE CLientes SET  VerEnConsultas = 'True',
						IdCalle = 1,
						Altura = 0,
						IdCalle2 = 1,
						Altura2 = 0,
						TipoDocDadoAltaPor = TipoDocVendedor,
						NroDocDadoAltaPor = NroDocVendedor,
						HabilitarVisita = 'False',
						Direccion2 = '.',
						IdLocalidad2 = IdLocalidad,
						RepartoIndependiente = 'False'
	GO


	ALTER TABLE Clientes ALTER COLUMN  VerEnConsultas	bit	not null;
	ALTER TABLE Clientes ALTER COLUMN IdCalle	int not	null;
	ALTER TABLE Clientes ALTER COLUMN Altura	int not	null;
	ALTER TABLE Clientes ALTER COLUMN IdCalle2	int	not null;
	ALTER TABLE Clientes ALTER COLUMN Altura2	int not	null;
	ALTER TABLE Clientes ALTER COLUMN TipoDocDadoAltaPor	varchar(5)	not null;
	ALTER TABLE Clientes ALTER COLUMN NroDocDadoAltaPor	varchar(12) not	null;
	ALTER TABLE Clientes ALTER COLUMN HabilitarVisita	bit	not null;
	ALTER TABLE Clientes ALTER COLUMN Direccion2	varchar(100) not null;
	ALTER TABLE Clientes ALTER COLUMN IdLocalidad2	int	not null;
	ALTER TABLE Clientes ALTER COLUMN RepartoIndependiente	bit	not null;
	GO

	PRINT ''
	PRINT '5. Creo campos de Prospectos de SILIVE en SIGA'
	IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'Prospectos'
              AND COLUMN_NAME = 'Contacto') 
		ALTER TABLE Prospectos ADD Contacto varchar(100) null;
	GO
	ALTER TABLE Prospectos ADD FechaBaja	datetime	null;
	ALTER TABLE Prospectos ADD  VerEnConsultas	bit	null;
	ALTER TABLE Prospectos ADD IdCalle	int	null;
	ALTER TABLE Prospectos ADD Altura	int	null;
	ALTER TABLE Prospectos ADD IdCalle2	int	null;
	ALTER TABLE Prospectos ADD Altura2	int	null;
	ALTER TABLE Prospectos ADD DireccionAdicional2	varchar(100)	null;
	ALTER TABLE Prospectos ADD TelefonosParticulares	varchar(100)	null;
	ALTER TABLE Prospectos ADD Fax	varchar(100)	null;
	ALTER TABLE Prospectos ADD FechaSUS	datetime	null;
	ALTER TABLE Prospectos ADD TipoDocDadoAltaPor	varchar(5)	null;
	ALTER TABLE Prospectos ADD NroDocDadoAltaPor	varchar(12)	null;
	ALTER TABLE Prospectos ADD HabilitarVisita	bit	null;
	ALTER TABLE Prospectos ADD Direccion2	varchar(100)	null;
	ALTER TABLE Prospectos ADD IdLocalidad2	int	null;
	ALTER TABLE Prospectos ADD ObservacionWeb	varchar(200)	null;
	ALTER TABLE Prospectos ADD RepartoIndependiente	bit	null;
	GO

	UPDATE Prospectos SET  VerEnConsultas = 'True',
						IdCalle = 1,
						Altura = 0,
						IdCalle2 = 1,
						Altura2 = 0,
						TipoDocDadoAltaPor = TipoDocVendedor,
						NroDocDadoAltaPor = NroDocVendedor,
						HabilitarVisita = 'False',
						Direccion2 = '.',
						IdLocalidad2 = IdLocalidad,
						RepartoIndependiente = 'False'
	GO

	ALTER TABLE Prospectos ALTER COLUMN  VerEnConsultas	bit	not null;
	ALTER TABLE Prospectos ALTER COLUMN IdCalle	int not	null;
	ALTER TABLE Prospectos ALTER COLUMN Altura	int not	null;
	ALTER TABLE Prospectos ALTER COLUMN IdCalle2	int	not null;
	ALTER TABLE Prospectos ALTER COLUMN Altura2	int not	null;
	ALTER TABLE Prospectos ALTER COLUMN TipoDocDadoAltaPor	varchar(5)	not null;
	ALTER TABLE Prospectos ALTER COLUMN NroDocDadoAltaPor	varchar(12) not	null;
	ALTER TABLE Prospectos ALTER COLUMN HabilitarVisita	bit	not null;
	ALTER TABLE Prospectos ALTER COLUMN Direccion2	varchar(100) not null;
	ALTER TABLE Prospectos ALTER COLUMN IdLocalidad2	int	not null;
	ALTER TABLE Prospectos ALTER COLUMN RepartoIndependiente	bit	not null;
	GO

	PRINT ''
	PRINT '6. Creo campos de AuditoriaCliente de SILIVE en SIGA'
	IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'AuditoriaClientes'
              AND COLUMN_NAME = 'Contacto') 
		ALTER TABLE AuditoriaClientes ADD Contacto varchar(100) null;
	GO
	ALTER TABLE AuditoriaClientes ADD FechaBaja	datetime	null;
	ALTER TABLE AuditoriaClientes ADD  VerEnConsultas	bit	null;
	ALTER TABLE AuditoriaClientes ADD IdCalle	int	null;
	ALTER TABLE AuditoriaClientes ADD Altura	int	null;
	ALTER TABLE AuditoriaClientes ADD IdCalle2	int	null;
	ALTER TABLE AuditoriaClientes ADD Altura2	int	null;
	ALTER TABLE AuditoriaClientes ADD DireccionAdicional2	varchar(100)	null;
	ALTER TABLE AuditoriaClientes ADD TelefonosParticulares	varchar(100)	null;
	ALTER TABLE AuditoriaClientes ADD Fax	varchar(100)	null;
	ALTER TABLE AuditoriaClientes ADD FechaSUS	datetime	null;
	ALTER TABLE AuditoriaClientes ADD TipoDocDadoAltaPor	varchar(5)	null;
	ALTER TABLE AuditoriaClientes ADD NroDocDadoAltaPor	varchar(12)	null;
	ALTER TABLE AuditoriaClientes ADD HabilitarVisita	bit	null;
	ALTER TABLE AuditoriaClientes ADD Direccion2	varchar(100)	null;
	ALTER TABLE AuditoriaClientes ADD IdLocalidad2	int	null;
	ALTER TABLE AuditoriaClientes ADD ObservacionWeb	varchar(200)	null;
	ALTER TABLE AuditoriaClientes ADD RepartoIndependiente	bit	null;
	GO

	PRINT ''
	PRINT '7. Creo campos de AuditoriaProspectos de SILIVE en SIGA'
	IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'AuditoriaProspectos'
              AND COLUMN_NAME = 'Contacto') 
		ALTER TABLE AuditoriaProspectos ADD Contacto varchar(100) null;
	GO
	ALTER TABLE AuditoriaProspectos ADD FechaBaja	datetime	null;
	ALTER TABLE AuditoriaProspectos ADD  VerEnConsultas	bit	null;
	ALTER TABLE AuditoriaProspectos ADD IdCalle	int	null;
	ALTER TABLE AuditoriaProspectos ADD Altura	int	null;
	ALTER TABLE AuditoriaProspectos ADD IdCalle2	int	null;
	ALTER TABLE AuditoriaProspectos ADD Altura2	int	null;
	ALTER TABLE AuditoriaProspectos ADD DireccionAdicional2	varchar(100)	null;
	ALTER TABLE AuditoriaProspectos ADD TelefonosParticulares	varchar(100)	null;
	ALTER TABLE AuditoriaProspectos ADD Fax	varchar(100)	null;
	ALTER TABLE AuditoriaProspectos ADD FechaSUS	datetime	null;
	ALTER TABLE AuditoriaProspectos ADD TipoDocDadoAltaPor	varchar(5)	null;
	ALTER TABLE AuditoriaProspectos ADD NroDocDadoAltaPor	varchar(12)	null;
	ALTER TABLE AuditoriaProspectos ADD HabilitarVisita	bit	null;
	ALTER TABLE AuditoriaProspectos ADD Direccion2	varchar(100)	null;
	ALTER TABLE AuditoriaProspectos ADD IdLocalidad2	int	null;
	ALTER TABLE AuditoriaProspectos ADD ObservacionWeb	varchar(200)	null;
	ALTER TABLE AuditoriaProspectos ADD RepartoIndependiente	bit	null;
	GO
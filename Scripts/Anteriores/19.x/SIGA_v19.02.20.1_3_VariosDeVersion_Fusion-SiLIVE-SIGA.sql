
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'IDAPLICACION' 
                AND P.ValorParametro = 'SILIVE')
BEGIN

	PRINT ''
	PRINT '1.Prospectos'

	ALTER TABLE Prospectos ADD FechaBaja	datetime	null;

	ALTER TABLE Prospectos ADD VerEnConsultas	bit	null;

	ALTER TABLE Prospectos ADD IdCalle	int null;

	ALTER TABLE Prospectos ADD Altura	int null;

	ALTER TABLE Prospectos ADD IdCalle2	int null;

	ALTER TABLE Prospectos ADD Altura2	int null;

	ALTER TABLE Prospectos ADD DireccionAdicional2	varchar(100)	null;

	ALTER TABLE Prospectos ADD TelefonosParticulares	varchar(100)	null;

	ALTER TABLE Prospectos ADD Fax	varchar(100)	null;

	ALTER TABLE Prospectos ADD FechaSUS	datetime	null;

	ALTER TABLE Prospectos ADD TipoDocDadoAltaPor	varchar(5)	null;

	ALTER TABLE Prospectos ADD NroDocDadoAltaPor	varchar(12) null;

	ALTER TABLE Prospectos ADD HabilitarVisita	bit	null;

	ALTER TABLE Prospectos ADD Direccion2	varchar(100)	null;

	ALTER TABLE Prospectos ADD IdLocalidad2	int null;

	ALTER TABLE Prospectos ADD ObservacionWeb	varchar(200)	null;

	ALTER TABLE Prospectos ADD RepartoIndependiente	bit null;

	ALTER TABLE Prospectos ADD HoraInicio varchar(50) NULL;

	ALTER TABLE Prospectos ADD HoraFin varchar(50) NULL;

	ALTER TABLE Prospectos ADD HoraInicio2 varchar(50) NULL;

	ALTER TABLE Prospectos ADD HoraFin2 varchar(50) NULL;

	ALTER TABLE Prospectos ADD HoraSabInicio varchar(50) NULL;

	ALTER TABLE Prospectos ADD HoraSabFin varchar(50) NULL;

	ALTER TABLE Prospectos ADD HoraSabInicio2 varchar(50) NULL;

	ALTER TABLE Prospectos ADD HoraSabFin2 varchar(50) NULL;

	ALTER TABLE Prospectos ADD HorarioCorrido bit NULL;

	ALTER TABLE Prospectos ADD HorarioCorridoSab bit NULL;

	ALTER TABLE Prospectos ADD DireccionAdicional varchar(100) null;




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

	ALTER TABLE AuditoriaProspectos ADD HoraInicio varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HoraFin varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HoraInicio2 varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HoraFin2 varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HoraSabInicio varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HoraSabFin varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HoraSabInicio2 varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HoraSabFin2 varchar(50) NULL;

	ALTER TABLE AuditoriaProspectos ADD HorarioCorrido bit NULL;

	ALTER TABLE AuditoriaProspectos ADD HorarioCorridoSab bit NULL;

	ALTER TABLE AuditoriaProspectos ADD DireccionAdicional varchar(100) null;

	PRINT ''
	PRINT '2. UPDATE Menu Logistica'


	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'OrganizarEntregasV2';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'SiLIVEConsultarRepartos';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'AnularRepartos';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'ModificarRepartos';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'RegistracionPagos';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'InfCajonesHectolitros';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'InfCanalesYRubros';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'CallesABM';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'Empleados';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'ImportarClientesExcel';
	UPDATE Funciones SET  Archivo = 'Eniac.Win' where Id = 'Clientes';

	UPDATE Funciones SET  Visible = 'False' where Id = 'Backups';
	UPDATE Funciones SET  Visible = 'False' where Id = 'CargarOfertas';
	UPDATE Funciones SET  Visible = 'False' where Id = 'ParametrosAplicacion';

	UPDATE Funciones SET  Pantalla = 'ImportarClientesLIVEExcel' where Id = 'ImportarClientesExcel';
	UPDATE Funciones SET  Pantalla = 'ClientesLIVEABM' where Id = 'Clientes';

END

IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = 'Prospectos'
              AND COLUMN_NAME = 'Contacto') 
	BEGIN

		ALTER TABLE Prospectos ADD Contacto varchar(100) NULL;
		ALTER TABLE AuditoriaProspectos ADD Contacto varchar(100) NULL;

	END;

GO

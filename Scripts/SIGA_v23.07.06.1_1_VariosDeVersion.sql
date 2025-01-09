PRINT ''
PRINT '4. Nueva Tabla de Estados Civiles.'
IF dbo.ExisteTabla('EstadosCiviles') = 0
BEGIN
	CREATE TABLE EstadosCiviles(
		IdEstadoCivil int NOT NULL,
		NombreEstadoCivil varchar(30) NOT NULL,
		CONSTRAINT PK_EstadosCiviles PRIMARY KEY CLUSTERED 
	(
		IdEstadoCivil ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

PRINT ''
PRINT '4.1. Carga Datos Tabla de Estados Civiles.'
BEGIN
	INSERT INTO EstadosCiviles
			   (IdEstadoCivil
			   ,NombreEstadoCivil)
	SELECT 1,'Soltero/a'
	WHERE NOT EXISTS(SELECT 1 FROM EstadosCiviles WHERE IdEstadoCivil = 1);

	INSERT INTO EstadosCiviles
			   (IdEstadoCivil
			   ,NombreEstadoCivil)
	SELECT 2,'Casado/a'
	WHERE NOT EXISTS(SELECT 1 FROM EstadosCiviles WHERE IdEstadoCivil = 2);

	INSERT INTO EstadosCiviles
			   (IdEstadoCivil
			   ,NombreEstadoCivil)
	SELECT 3,'Separado/a'
	WHERE NOT EXISTS(SELECT 1 FROM EstadosCiviles WHERE IdEstadoCivil = 3);

	INSERT INTO EstadosCiviles
			   (IdEstadoCivil
			   ,NombreEstadoCivil)
	SELECT 4,'Divorciado/a'
	WHERE NOT EXISTS(SELECT 1 FROM EstadosCiviles WHERE IdEstadoCivil = 4);

		INSERT INTO EstadosCiviles
			   (IdEstadoCivil
			   ,NombreEstadoCivil)
	SELECT 5,'Viudo/a'
	WHERE NOT EXISTS(SELECT 1 FROM EstadosCiviles WHERE IdEstadoCivil = 5);

		INSERT INTO EstadosCiviles
			   (IdEstadoCivil
			   ,NombreEstadoCivil)
	SELECT 10,'A Definir'
	WHERE NOT EXISTS(SELECT 1 FROM EstadosCiviles WHERE IdEstadoCivil = 10);
END
GO

PRINT ''
PRINT '4.2. Tabla Clientes: Nuevos campos IdEstadoCivil'
IF dbo.ExisteCampo('Clientes', 'IdEstadoCivil') = 0
BEGIN
    ALTER TABLE Clientes ADD IdEstadoCivil int NULL
	ALTER TABLE Clientes  WITH CHECK ADD FOREIGN KEY(IdEstadoCivil) REFERENCES EstadosCiviles(IdEstadoCivil)

    ALTER TABLE AuditoriaClientes ADD IdEstadoCivil int NULL

    ALTER TABLE Prospectos ADD IdEstadoCivil int NULL
	ALTER TABLE Prospectos  WITH CHECK ADD FOREIGN KEY(IdEstadoCivil) REFERENCES EstadosCiviles(IdEstadoCivil)

    ALTER TABLE AuditoriaProspectos ADD IdEstadoCivil int NULL

END
GO

PRINT ''
PRINT '4.3. Tabla Clientes: Modifica campos IdEstadoCivil'
BEGIN
	UPDATE Clientes SET IdEstadoCivil = 10 WHERE IdEstadoCivil IS NULL
    UPDATE Prospectos SET IdEstadoCivil = 10 WHERE IdEstadoCivil IS NULL
END
GO

ALTER TABLE Clientes ALTER COLUMN IdEstadoCivil int NOT NULL
ALTER TABLE Prospectos ALTER COLUMN IdEstadoCivil int NOT NULL

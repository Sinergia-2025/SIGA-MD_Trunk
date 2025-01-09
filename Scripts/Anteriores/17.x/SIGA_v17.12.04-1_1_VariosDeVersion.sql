
PRINT '1. Tabla CRMNovedades: agrego campos Priorizado/Version/Otros.'
GO

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CRMNovedades ADD
	Priorizado bit NULL,
	IdTipoNovedadPadre varchar(10) NULL,
	IdNovedadPadre int NULL,
	[Version] varchar(20) NULL,
	VersionFecha datetime NULL,
	FechaInicioPlan datetime NULL,
	FechaFinPlan datetime NULL
GO

UPDATE CRMNovedades SET Priorizado = 0
 GO

ALTER TABLE CRMNovedades ALTER COLUMN Priorizado bit NOT NULL
 GO

PRINT ''
PRINT '2. Tabla CRMNovedades: agrego FK de Id Novedad Padre.'
GO

ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT
	FK_CRMNovedades_CRMNovedades FOREIGN KEY
	(
	IdTipoNovedadPadre,
	IdNovedadPadre
	) REFERENCES dbo.CRMNovedades
	(
	IdTipoNovedad,
	IdNovedad
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.CRMNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '3. Tabla Buscadores: agrego CRMNovedades.'
GO

DECLARE @max int
DECLARE @titulo varchar(max)

SET @titulo = 'CRMNovedades'
IF NOT EXISTS (SELECT 1 FROM Buscadores VT WHERE Titulo = @titulo)
BEGIN
    SET @max = (SELECT MAX(IdBuscador)+1 FROM Buscadores)
    INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, @titulo, 800);
    INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
        VALUES
           (@max, 'IdNovedad',1, 'Novedad', 64, 80,''),
           (@max, 'Descripcion',2, 'Descripción', 16, 200,''),
		 (@max, 'NombreUsuarioAsignado',3, 'Usuario Asignado', 16, 200,''),
		 (@max, 'IdFuncion',4, 'Función', 16, 200,''),
		 (@max, 'NombreUsuarioAlta',5, 'Usuario Alta', 16, 200,''),
		 (@max, 'NombreEstadoNovedad',6, 'Estado Novedad', 16, 200,''),
		  (@max, 'IdProyecto',7, 'Proyecto', 16, 80,'');
END

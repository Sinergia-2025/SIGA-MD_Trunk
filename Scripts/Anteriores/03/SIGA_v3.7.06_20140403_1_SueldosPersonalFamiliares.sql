
CREATE TABLE SueldosPersonalFamiliares
( 
	IdLegajo             int  NOT NULL ,
	CuilFamiliar         varchar(13)  NOT NULL ,
	NombreFamiliar       varchar(50)  NOT NULL ,
	FechaNacimientoFamiliar datetime  NOT NULL ,
	SexoFamiliar         char(1)  NOT NULL ,
	IdTipoVinculoFamiliar varchar(5)  NOT NULL 
)
GO

ALTER TABLE SueldosPersonalFamiliares
	ADD CONSTRAINT PK_SueldosPersonalFamiliares PRIMARY KEY  CLUSTERED (IdLegajo ASC,CuilFamiliar ASC)
GO

CREATE TABLE SueldosTiposVinculoFamiliar
( 
	IdTipoVinculoFamiliar varchar(5)  NOT NULL ,
	NombreVinculoFamiliar varchar(50)  NOT NULL 
)
GO

ALTER TABLE SueldosTiposVinculoFamiliar
	ADD CONSTRAINT PK_SueldosTiposVinculoFamiliar PRIMARY KEY  CLUSTERED (IdTipoVinculoFamiliar ASC)
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
ALTER TABLE dbo.SueldosTiposVinculoFamiliar SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.SueldosPersonalFamiliares ADD CONSTRAINT
	FK_SueldosPersonalFamiliares_SueldosTiposVinculoFamiliar FOREIGN KEY
	(
	IdTipoVinculoFamiliar
	) REFERENCES dbo.SueldosTiposVinculoFamiliar
	(
	IdTipoVinculoFamiliar
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.SueldosPersonalFamiliares SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ---------------------- */

INSERT [dbo].[SueldosTiposVinculoFamiliar] ([IdTipoVinculoFamiliar], [NombreVinculoFamiliar])
 VALUES ('CONYU', 'Cónyuge')
GO

INSERT [dbo].[SueldosTiposVinculoFamiliar] ([IdTipoVinculoFamiliar], [NombreVinculoFamiliar])
 VALUES ('HIJO', 'Hijo')
GO

INSERT [dbo].[SueldosTiposVinculoFamiliar] ([IdTipoVinculoFamiliar], [NombreVinculoFamiliar])
 VALUES ('MADRE', 'Madre')
GO

INSERT [dbo].[SueldosTiposVinculoFamiliar] ([IdTipoVinculoFamiliar], [NombreVinculoFamiliar])
 VALUES ('PADRE', 'Padre')
GO

/* ---------------------- */

INSERT INTO SueldosPersonalFamiliares
   (IdLegajo, CuilFamiliar, NombreFamiliar, FechaNacimientoFamiliar, SexoFamiliar, IdTipoVinculoFamiliar)
SELECT IdLegajo, CuilHijo, NombreHijo, FechaNacimientoHijo, 'F' AS Sexo, 'HIJO' as Vinculo
  FROM SueldosPersonalHijos
GO
  
DROP TABLE SueldosPersonalHijos
GO
  
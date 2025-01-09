
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
ALTER TABLE dbo.CRMTiposNovedades ADD PrimerOrdenGrilla varchar(50) NULL
ALTER TABLE dbo.CRMTiposNovedades ADD PrimerOrdenDesc bit NULL
ALTER TABLE dbo.CRMTiposNovedades ADD SegundoOrdenGrilla varchar(50) NULL
ALTER TABLE dbo.CRMTiposNovedades ADD SegundoOrdenDesc bit NULL
GO

UPDATE CRMTiposNovedades SET PrimerOrdenGrilla = 'N__FechaNovedad';
UPDATE CRMTiposNovedades SET PrimerOrdenDesc = 'False';
UPDATE CRMTiposNovedades SET SegundoOrdenDesc = 'False';

ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN PrimerOrdenGrilla varchar(50) NOT NULL
ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN PrimerOrdenDesc bit NOT NULL
ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN SegundoOrdenDesc bit NOT NULL
GO

ALTER TABLE dbo.CRMTiposNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

UPDATE CRMTiposNovedades
   SET PrimerOrdenGrilla = 'N__FechaProximoContacto'
      ,PrimerOrdenDesc = 'True'
 WHERE IdTipoNovedad = 'PROSP'
GO

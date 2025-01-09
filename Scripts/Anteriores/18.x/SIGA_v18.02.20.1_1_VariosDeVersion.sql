
PRINT '1. Tabla RecepcionNotasEstados: Ensancho campo Observacion de 150 a 250.'
GO

ALTER TABLE RecepcionNotasEstados ALTER COLUMN Observacion varchar(250) NULL
GO


PRINT ''
PRINT '2. Tablas CRMTiposNovedades/CRMEstadosNovedades: Agrego campo DiasProximoContacto y seteo en 1 para CRMTiposNovedades.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.CRMEstadosNovedades ADD DiasProximoContacto int NULL
GO
ALTER TABLE dbo.CRMEstadosNovedades SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.CRMTiposNovedades ADD DiasProximoContacto int NULL
GO
UPDATE CRMTiposNovedades SET DiasProximoContacto = 1;
ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN DiasProximoContacto int NOT NULL
GO
ALTER TABLE dbo.CRMTiposNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Seteos Perfiles para ver las Alertas de CRM de todos los Usuarios.'
GO

INSERT INTO Funciones
           (Id,Nombre,Descripcion,EsMenu,EsBoton,Enabled,Visible
           ,IdPadre,Posicion,Archivo,Pantalla,Icono,Parametros)
SELECT REPLACE(F.Id, 'VerOtrosUsuarios', 'VerOtrUsrAlertas'),F.Nombre + ' en Alertas',F.Descripcion + ' en Alertas',F.EsMenu,F.EsBoton,F.Enabled,F.Visible
      ,F.IdPadre,F.Posicion,F.Archivo,REPLACE(F.Pantalla, 'VerOtrosUsuarios', 'VerOtrUsrAlertas'),F.Icono,F.Parametros
  FROM Funciones F
 WHERE F.Id LIKE '%-VerOtrosUsuarios'
GO


PRINT ''
PRINT '4. Habilito las Alertas Generales solo para Estudio G.P.'
GO

-- ESTUDIO G.P.
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('24284073068'))
	BEGIN

		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT RF.IdRol, REPLACE(RF.IdFuncion, 'VerOtrosUsuarios', 'VerOtrUsrAlertas')
		  FROM RolesFunciones RF
		 WHERE RF.IdFuncion LIKE '%-VerOtrosUsuarios'

	END
GO


PRINT ''
PRINT '5. Tabla CRMTiposNovedades: Agrego campo PermiteIngresarNumero y seteo en Falso.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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
ALTER TABLE dbo.CRMTiposNovedades ADD PermiteIngresarNumero bit NULL
GO
UPDATE CRMTiposNovedades SET PermiteIngresarNumero = 0;
ALTER TABLE dbo.CRMTiposNovedades ALTER COLUMN PermiteIngresarNumero bit NOT NULL
GO
ALTER TABLE dbo.CRMTiposNovedades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

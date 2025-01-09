
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
ALTER TABLE dbo.Usuarios ADD MailServidorSMTP varchar(100) NULL
GO
ALTER TABLE dbo.Usuarios ADD MailPuertoSalida integer NULL
GO
ALTER TABLE dbo.Usuarios ADD MailDireccion varchar(100) NULL
GO
ALTER TABLE dbo.Usuarios ADD MailUsuario varchar(100) NULL
GO
ALTER TABLE dbo.Usuarios ADD MailPassword varchar(100) NULL
GO
ALTER TABLE dbo.Usuarios ADD MailRequiereSSL bit NULL
GO
ALTER TABLE dbo.Usuarios ADD MailRequiereAutenticacion bit NULL
GO
ALTER TABLE dbo.Usuarios ADD MailCantxHora integer NULL
GO
ALTER TABLE dbo.Usuarios ADD MailCantxMinuto integer NULL
GO
ALTER TABLE dbo.Usuarios ADD UtilizaComoPredeterminado bit NULL
GO
ALTER TABLE dbo.Usuarios ADD CorreoElectronico varchar(100) NULL
GO
ALTER TABLE dbo.Usuarios ADD FechaUltimaModContraseña datetime NULL
GO
ALTER TABLE dbo.Usuarios ADD Activo bit NULL
GO

UPDATE dbo.Usuarios 
   SET Activo = 'True'
     , FechaUltimaModContraseña = GETDATE();

COMMIT

--Inserto la pantalla nueva

INSERT INTO Funciones
		   (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
		   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
	 VALUES
		   ('UsuariosConfiguraciones', 'Mis configuraciones', 'Mis configuraciones', 'True', 'False', 'True', 'True',
		   'Configuraciones', 80, 'Eniac.Win', 'UsuariosConfiguraciones', NULL)
;

INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'UsuariosConfiguraciones' AS Pantalla FROM dbo.Roles
--	WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
;

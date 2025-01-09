
PRINT '1. Seteo Precios en Pantalla InfPedidosDetallados.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'InfPedidosDetallados')
BEGIN
	PRINT ''
	PRINT '7. Seguridad a Inf. Pedidos Detallados'
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('InfPedidosDetallados-VerPre', 'Ver Precios en Inf.Ped. Detallados', 'Ver Precios en Inf.Ped. Detallados', 'False', 'False', 'True', 'True', 
              'InfPedidosDetallados', 999, 'Eniac.Win', 'InfPedidosDetallados-VerPre', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfPedidosDetallados-VerPre' AS Pantalla FROM [dbo].Roles
        INNER JOIN RolesFunciones ON RolesFunciones.IdRol = Roles.Id WHERE RolesFunciones.IdFuncion = 'InfPedidosDetallados';
END;


PRINT ''
PRINT '2. Nuevo Parametro: CLIENTEUTILIZACBU.'
GO

INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('CLIENTEUTILIZACBU', 'False', null, 'Cliente Utiliza CBU')
GO


PRINT ''
PRINT '3. Tabla Clientes/Relacionadas: Agregar Campo FechaActualizacionVersion.'
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
ALTER TABLE dbo.Clientes ADD
	FechaActualizacionVersion datetime NULL
GO

ALTER TABLE dbo.AuditoriaClientes ADD
	FechaActualizacionVersion datetime NULL
GO


ALTER TABLE dbo.Prospectos ADD
	FechaActualizacionVersion datetime NULL
GO

ALTER TABLE dbo.AuditoriaProspectos ADD
	FechaActualizacionVersion datetime NULL
GO

UPDATE Clientes 
   SET FechaActualizacionVersion = FechaActualizacion
 WHERE NroVersion IS NOT NULL AND NroVersion <> ''
GO

UPDATE AuditoriaClientes 
   SET FechaActualizacionVersion = FechaActualizacion
 WHERE NroVersion IS NOT NULL AND NroVersion <> ''
GO

ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla TiposComprobantesLetras: Agregar campos ArchivoAImprimir2 y ArchivoAImprimirEmbebido2.'
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
ALTER TABLE dbo.TiposComprobantesLetras ADD ArchivoAImprimir2 varchar(100) NULL
ALTER TABLE dbo.TiposComprobantesLetras ADD ArchivoAImprimirEmbebido2 bit NULL
GO
UPDATE TiposComprobantesLetras SET ArchivoAImprimir2 = '', ArchivoAImprimirEmbebido2 = 'False';
ALTER TABLE dbo.TiposComprobantesLetras ALTER COLUMN ArchivoAImprimir2 varchar(100) NOT NULL
ALTER TABLE dbo.TiposComprobantesLetras ALTER COLUMN ArchivoAImprimirEmbebido2 bit NOT NULL
GO
ALTER TABLE dbo.TiposComprobantesLetras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



PRINT ''
PRINT '5. Tabla CajasNombres: agregar campo Color.'
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
ALTER TABLE dbo.CajasNombres ADD Color int NULL
GO
ALTER TABLE dbo.CajasNombres SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



PRINT ''
PRINT '6. Tabla Empleados: agregar campo Color.'
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
ALTER TABLE dbo.Empleados ADD Color int NULL
GO
ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '7. Nueva Tabla PersonalizacionDeInformes.'
GO

/****** Object:  Table [dbo].[PersonalizacionDeInformes]    Script Date: 12/27/2017 16:44:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PersonalizacionDeInformes](
    [IdInforme] [varchar](50) NOT NULL,
    [NombreArchivo] [varchar](250) NOT NULL,
    [Embebido] [bit] NOT NULL,
 CONSTRAINT [PK_PersonalizacionDeInformes] PRIMARY KEY CLUSTERED ([IdInforme] ASC)
 WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


PRINT ''
PRINT '8. Nueva Funciones Configuraciones\PersonalizacionDeInformes.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Configuraciones')
BEGIN
    INSERT INTO [dbo].Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
              IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         VALUES
             ('PersonalizacionDeInformes', 'Personalización De Informes', 'Personalización De Informes', 'True', 'False', 'True', 'True', 
              'Configuraciones', 32, 'Eniac.Win', 'PersonalizacionDeInformes', NULL, NULL);

    INSERT INTO [dbo].RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'PersonalizacionDeInformes' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END;


PRINT ''
PRINT '9. Tabla Clientes/Relacionadas: Agregar Campo UsaArchivoAImprimir2.'
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
ALTER TABLE dbo.Clientes ADD UsaArchivoAImprimir2 bit NULL
GO
UPDATE Clientes SET UsaArchivoAImprimir2 = 'False';
ALTER TABLE dbo.Clientes ALTER COLUMN UsaArchivoAImprimir2 bit NOT NULL
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.Prospectos ADD UsaArchivoAImprimir2 bit NULL
GO
UPDATE Prospectos SET UsaArchivoAImprimir2 = 'False';
ALTER TABLE dbo.Prospectos ALTER COLUMN UsaArchivoAImprimir2 bit NOT NULL
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaClientes ADD UsaArchivoAImprimir2 bit NULL
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaProspectos ADD UsaArchivoAImprimir2 bit NULL
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '10. Tabla Clientes/Relacacionadas: Agregar Campos CBU y otros Bancarios.'
GO

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
ALTER TABLE dbo.Clientes ADD
   CBU	char(22) null,
   IdBanco int null,
   IdCuentaBancariaClase	int	null,
   NumeroCuentaBancaria	varchar(20)	null,
   CuitCtaBancaria	varchar(15)	null
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)

GO
ALTER TABLE dbo.Prospectos ADD
   CBU	char(22)	null,
   IdBanco	int	null,
   IdCuentaBancariaClase	int	null,
   NumeroCuentaBancaria	varchar(20)	null,
   CuitCtaBancaria	varchar(15)	null
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaClientes ADD
   CBU	char(22)	null,
   IdBanco	int	null,
   IdCuentaBancariaClase	int	null,
   NumeroCuentaBancaria	varchar(20)	null,
   CuitCtaBancaria	varchar(15)	null
GO
ALTER TABLE dbo.AuditoriaClientes SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.AuditoriaProspectos ADD
   CBU	char(22)	null,
   IdBanco	int	null,
   IdCuentaBancariaClase	int	null,
   NumeroCuentaBancaria	varchar(20)	null,
   CuitCtaBancaria	varchar(15)	null
GO
ALTER TABLE dbo.AuditoriaProspectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '11. Tabla Clientes: Agregar FK por IdBanco y IdCuentaBancariaClase.'
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
ALTER TABLE dbo.CuentasBancariasClase SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Bancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_Bancos FOREIGN KEY
	(
	IdBanco
	) REFERENCES dbo.Bancos
	(
	IdBanco
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_CuentasBancariasClase FOREIGN KEY
	(
	IdCuentaBancariaClase
	) REFERENCES dbo.CuentasBancariasClase
	(
	IdCuentaBancariaClase
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '12. Tabla Prospectos: Agregar FK por IdBanco y IdCuentaBancariaClase.'
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
ALTER TABLE dbo.CuentasBancariasClase SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Bancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT
	FK_Prospectos_Bancos FOREIGN KEY
	(
	IdBanco
	) REFERENCES dbo.Bancos
	(
	IdBanco
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT
	FK_Prospectos_CuentasBancariasClase FOREIGN KEY
	(
	IdCuentaBancariaClase
	) REFERENCES dbo.CuentasBancariasClase
	(
	IdCuentaBancariaClase
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

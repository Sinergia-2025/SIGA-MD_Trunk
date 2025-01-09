
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
CREATE TABLE [dbo].[Cobradores](
	[IdCobrador] [int] NOT NULL,
	[NombreCobrador] [varchar](50) NULL,
	[DebitoDirecto] [bit] NOT NULL,
	[IdBanco] [int] NULL,
 CONSTRAINT [PK_Cobradores] PRIMARY KEY CLUSTERED 
(
	[IdCobrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT INTO [dbo].[Cobradores]([IdCobrador],[NombreCobrador],[DebitoDirecto],[IdBanco])
     VALUES (1,'Empresa',0,null)
GO

ALTER TABLE dbo.Cobradores SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Clientes ADD
	IdCobrador int NULL,
	IdTipoCliente int NULL,
	HoraInicio varchar(50) NULL,
	HoraFin varchar(50) NULL,
	HoraInicio2 varchar(50) NULL,
	HoraFin2 varchar(50) NULL,
	HoraSabInicio varchar(50) NULL,
	HoraSabFin varchar(50) NULL,
	HoraSabInicio2 varchar(50) NULL,
	HoraSabFin2 varchar(50) NULL,
	HoraDomInicio varchar(50) NULL,
	HoraDomFin varchar(50) NULL,
	HoraDomInicio2 varchar(50) NULL,
	HoraDomFin2 varchar(50) NULL,
	HorarioCorrido bit NULL,
	HorarioCorridoSab bit NULL,
	HorarioCorridoDom bit NULL,
	NroVersion varchar(50) NULL,
	FechaActualizacion datetime NULL,
	FechaInicio datetime NULL,
	FechaInicioReal datetime NULL
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_TiposClientes FOREIGN KEY
	(
	IdTipoCliente
	) REFERENCES dbo.TiposClientes
	(
	IdTipoCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Clientes ADD CONSTRAINT
	FK_Clientes_Cobradores FOREIGN KEY
	(
	IdCobrador
	) REFERENCES dbo.Cobradores
	(
	IdCobrador
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.Clientes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaClientes ADD
	IdCobrador int NULL,
	IdTipoCliente int NULL,
	HoraInicio varchar(50) NULL,
	HoraFin varchar(50) NULL,
	HoraInicio2 varchar(50) NULL,
	HoraFin2 varchar(50) NULL,
	HoraSabInicio varchar(50) NULL,
	HoraSabFin varchar(50) NULL,
	HoraSabInicio2 varchar(50) NULL,
	HoraSabFin2 varchar(50) NULL,
	HoraDomInicio varchar(50) NULL,
	HoraDomFin varchar(50) NULL,
	HoraDomInicio2 varchar(50) NULL,
	HoraDomFin2 varchar(50) NULL,
	HorarioCorrido bit NULL,
	HorarioCorridoSab bit NULL,
	HorarioCorridoDom bit NULL,
	NroVersion varchar(50) NULL,
	FechaActualizacion datetime NULL,
	FechaInicio datetime NULL,
	FechaInicioReal datetime NULL
GO


COMMIT

BEGIN TRANSACTION
GO
ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Prospectos ADD
	IdCobrador int NULL,
	IdTipoCliente int NULL,
	HoraInicio varchar(50) NULL,
	HoraFin varchar(50) NULL,
	HoraInicio2 varchar(50) NULL,
	HoraFin2 varchar(50) NULL,
	HoraSabInicio varchar(50) NULL,
	HoraSabFin varchar(50) NULL,
	HoraSabInicio2 varchar(50) NULL,
	HoraSabFin2 varchar(50) NULL,
	HoraDomInicio varchar(50) NULL,
	HoraDomFin varchar(50) NULL,
	HoraDomInicio2 varchar(50) NULL,
	HoraDomFin2 varchar(50) NULL,
	HorarioCorrido bit NULL,
	HorarioCorridoSab bit NULL,
	HorarioCorridoDom bit NULL,
	NroVersion varchar(50) NULL,
	FechaActualizacion datetime NULL,
	FechaInicio datetime NULL,
	FechaInicioReal datetime NULL
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT
	FK_Prospectos_TiposClientes FOREIGN KEY
	(
	IdTipoCliente
	) REFERENCES dbo.TiposClientes
	(
	IdTipoCliente
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Prospectos ADD CONSTRAINT
	FK_Prospectos_Cobradores FOREIGN KEY
	(
	IdCobrador
	) REFERENCES dbo.Cobradores
	(
	IdCobrador
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.Prospectos SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.AuditoriaProspectos ADD
	IdCobrador int NULL,
	IdTipoCliente int NULL,
	HoraInicio varchar(50) NULL,
	HoraFin varchar(50) NULL,
	HoraInicio2 varchar(50) NULL,
	HoraFin2 varchar(50) NULL,
	HoraSabInicio varchar(50) NULL,
	HoraSabFin varchar(50) NULL,
	HoraSabInicio2 varchar(50) NULL,
	HoraSabFin2 varchar(50) NULL,
	HoraDomInicio varchar(50) NULL,
	HoraDomFin varchar(50) NULL,
	HoraDomInicio2 varchar(50) NULL,
	HoraDomFin2 varchar(50) NULL,
	HorarioCorrido bit NULL,
	HorarioCorridoSab bit NULL,
	HorarioCorridoDom bit NULL,
	NroVersion varchar(50) NULL,
	FechaActualizacion datetime NULL,
	FechaInicio datetime NULL,
	FechaInicioReal datetime NULL
GO
COMMIT

BEGIN TRAN

UPDATE [dbo].[Clientes] SET IdCobrador = 1
GO
UPDATE [dbo].Prospectos SET IdCobrador = 1
GO
UPDATE [dbo].[Clientes] SET IdTipoCliente = 1
GO
UPDATE [dbo].Prospectos SET IdTipoCliente = 1
GO

ALTER TABLE dbo.Prospectos ALTER COLUMN
	IdCobrador int NOT NULL
GO
ALTER TABLE dbo.Prospectos ALTER COLUMN
	IdTipoCliente int NOT NULL
GO
ALTER TABLE dbo.Clientes ALTER COLUMN
	IdCobrador int NOT NULL
GO
ALTER TABLE dbo.Clientes ALTER COLUMN
	IdTipoCliente int NOT NULL
GO

COMMIT

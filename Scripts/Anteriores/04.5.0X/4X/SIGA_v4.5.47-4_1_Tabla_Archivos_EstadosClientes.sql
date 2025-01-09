
PRINT '1. Creo la tabla EstadosClientes'

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstadosClientes](
	[IdEstadoCliente] [int] NOT NULL,
	[NombreEstadoCliente] [varchar](15) NOT NULL,
 CONSTRAINT [PK_EstadosClientes] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* ---------------------------------------------------------------- */

PRINT ''
PRINT '2. Inserto Registro GENERAL a la tabla EstadosClientes'

INSERT INTO EstadosClientes
  (IdEstadoCliente, NombreEstadoCliente)
 VALUES
  (1, 'General')
GO


/* ---------------------------------------------------------------- */

PRINT ''
PRINT '3. Agrego campo IdEstado a Tabla Clientes, Actualizo con Estado GENERAL y Agrego FK a EstadosClientes'


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
ALTER TABLE Clientes ADD IdEstado int NULL
GO
UPDATE Clientes 
   SET IdEstado = 1
GO
ALTER TABLE Clientes ALTER COLUMN IdEstado int NOT NULL
GO
ALTER TABLE dbo.Clientes  WITH CHECK ADD  CONSTRAINT FK_Clientes_EstadosClientes FOREIGN KEY(IdEstado)
REFERENCES dbo.EstadosClientes (IdEstadoCliente)
GO
ALTER TABLE dbo.Clientes CHECK CONSTRAINT FK_Clientes_EstadosClientes
GO

COMMIT



/* ---------------------------------------------------------------- */

PRINT ''
PRINT '4. Agrego Campo IdEstado a AuditoriaClientes y Actualizo los Clientes con Estado GENERAL.'

ALTER TABLE AuditoriaClientes ADD IdEstado int NULL
GO
UPDATE AuditoriaClientes 
   SET IdEstado = 1
GO


/* ---------------------------------------------------------------- */

PRINT ''
PRINT '5. Agrego campo IdEstado a Tabla Prospectos, Actualizo con Estado GENERAL y Agrego FK a EstadosClientes'

GO
ALTER TABLE Prospectos ADD IdEstado int NULL
GO
UPDATE Prospectos 
   SET IdEstado = 1
GO
ALTER TABLE Prospectos ALTER COLUMN IdEstado int NOT NULL
GO
ALTER TABLE dbo.Prospectos  WITH CHECK ADD  CONSTRAINT FK_Prospectos_EstadosClientes FOREIGN KEY(IdEstado)
REFERENCES dbo.EstadosClientes (IdEstadoCliente)
GO
ALTER TABLE dbo.Prospectos CHECK CONSTRAINT FK_Prospectos_EstadosClientes
GO


/* ---------------------------------------------------------------- */

PRINT ''
PRINT '6. Agrego Campo IdEstado a AuditoriaProspectos y Actualizo los Clientes con Estado GENERAL.'

ALTER TABLE AuditoriaProspectos ADD IdEstado int NULL
GO
UPDATE AuditoriaProspectos
   SET IdEstado = 1
GO

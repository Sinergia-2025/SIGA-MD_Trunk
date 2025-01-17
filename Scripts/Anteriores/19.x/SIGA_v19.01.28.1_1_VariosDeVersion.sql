
PRINT ''
PRINT '1. Tabla Clientes: Agrego Campo RecibeNotificaciones con Predeterminado en SI.'
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
ALTER TABLE dbo.Clientes ADD [RecibeNotificaciones] [bit] NOT NULL DEFAULT ((1))
GO
COMMIT


PRINT ''
PRINT '2. Tabla AuditoriaClientes: Agrego Campo RecibeNotificaciones.'
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
ALTER TABLE dbo.AuditoriaClientes ADD [RecibeNotificaciones] [bit] NULL
GO
COMMIT


PRINT ''
PRINT '3. Tabla Prospectos: Agrego Campo RecibeNotificaciones con Predeterminado en SI.'
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
ALTER TABLE dbo.Prospectos ADD [RecibeNotificaciones] [bit] NOT NULL DEFAULT ((1))
GO
COMMIT


PRINT ''
PRINT '4. Tabla AuditoriaProspectos: Agrego Campo RecibeNotificaciones.'
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
ALTER TABLE dbo.AuditoriaProspectos ADD [RecibeNotificaciones] [bit] NULL
GO
COMMIT

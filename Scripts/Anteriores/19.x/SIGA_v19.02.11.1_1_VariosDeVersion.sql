PRINT ''
PRINT '1. Calendarios: Renombro campo Sesion por UtilizaSesion.'
GO
EXEC sp_rename 'Calendarios.Sesion', 'UtilizaSesion', 'COLUMN'
GO

PRINT ''
PRINT '2. Tabla Calendarios: Agrego Campo Zona con Predeterminado en No.'
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
ALTER TABLE dbo.Calendarios ADD UtilizaZonas bit NULL
GO
UPDATE dbo.Calendarios SET UtilizaZonas = 'False'
GO
ALTER TABLE dbo.Calendarios ALTER COLUMN UtilizaZonas bit NOT NULL
GO
COMMIT

--PRINT ''
--PRINT 'xx. Calendarios: Borro campo.'
--GO
--IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS 
--            WHERE TABLE_NAME = 'Calendarios'
--              AND COLUMN_NAME = 'UtilizaZona') 

--	ALTER TABLE Calendarios DROP COLUMN UtilizaZona;
--GO



PRINT ''
PRINT '3. Nueva Tabla: TurnosCalendariosProductos.'
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TurnosCalendariosProductos](
	[IdTurno] [int] NOT NULL,
	[IdProducto] [varchar](15) NOT NULL,
	[Orden] [int] NOT NULL,
	[NumeroSesion] [int] NOT NULL,
 CONSTRAINT [PK_TurnosCalendariosProductos] PRIMARY KEY CLUSTERED 
(
	[IdTurno] ASC,
	[IdProducto] ASC,
	[Orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TurnosCalendariosProductos]  WITH CHECK ADD  CONSTRAINT [FK_TurnosCalendariosProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO

ALTER TABLE [dbo].[TurnosCalendariosProductos] CHECK CONSTRAINT [FK_TurnosCalendariosProductos_Productos]
GO


PRINT ''
PRINT '4. Parametro: Nuevo parametro - Turnos: Productos Filtra por Zona.'
GO
INSERT INTO Parametros 
  (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
 VALUES
  ('TURNOSPRODUCTOZONA', '', NULL, 'Turnos: Productos Filtra por Zona')
GO

UPDATE Parametros
  SET ValorParametro = (SELECT MIN(IdRubro) FROM Rubros)
WHERE Idparametro = 'TURNOSPRODUCTOZONA'
GO


PRINT ''
PRINT '5. CRMCategoriasNovedades: Ajuste descripcion de CAMPAÑA.'
GO
UPDATE CRMCategoriasNovedades
   SET NombreCategoriaNovedad = 'CAMPAÑA'
 WHERE NombreCategoriaNovedad = 'CAMPAÑIA'
GO

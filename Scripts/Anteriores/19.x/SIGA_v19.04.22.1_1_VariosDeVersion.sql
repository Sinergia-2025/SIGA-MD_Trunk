SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '1. Menu ActualizarPrecios Ocultar'
DELETE FROM RolesFunciones
 WHERE IdFuncion = 'ActualizarPrecios'
UPDATE Funciones
   SET Enabled = 'False'
      ,Visible = 'False'
      ,EsMenu  = 'False'
      ,EsBoton = 'False'
 WHERE Id = 'ActualizarPrecios'

PRINT ''
PRINT '2. Agregar DireccionMAC en Dispositivos'
ALTER TABLE dbo.Dispositivos ADD DireccionMAC varchar(100) NULL
GO
PRINT ''
PRINT '3. Copiar la IdDispositivo al nuevo campo DireccionMAC'
UPDATE Dispositivos
   SET DireccionMAC = IdDispositivo;
ALTER TABLE dbo.Dispositivos ALTER COLUMN DireccionMAC varchar(100) NOT NULL

PRINT ''
PRINT '4. Borrar los Dispositivos que poseen NumeroSerieDiscoRigido duplicado dejando el más reciente'
DELETE Dispositivos
  FROM Dispositivos D
  LEFT JOIN (SELECT NumeroSerieDiscoRigido, MAX(FechaUltimoLogin) FechaUltimoLogin
               FROM Dispositivos
              GROUP BY NumeroSerieDiscoRigido) DF ON DF.NumeroSerieDiscoRigido = D.NumeroSerieDiscoRigido AND DF.FechaUltimoLogin = D.FechaUltimoLogin
 WHERE DF.FechaUltimoLogin IS NULL

PRINT ''
PRINT '5. Copiar NumeroSerieDiscoRigido como nuevo IdDispositivo'
UPDATE Dispositivos
   SET IdDispositivo = NumeroSerieDiscoRigido;

PRINT ''
PRINT '6. Crea nueva tabla RubrosComisionesPorDescuento'
CREATE TABLE [dbo].[RubrosComisionesPorDescuento](
	[IdRubro] [int] NOT NULL,
	[DescuentoRecargoHasta] [decimal](10, 5) NOT NULL,
	[Comision] [decimal](10, 5) NULL,
 CONSTRAINT [PK_RubrosComisionesPorDescuento] PRIMARY KEY CLUSTERED 
(
	[IdRubro] ASC,
	[DescuentoRecargoHasta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

PRINT ''
PRINT '7. Crea FK entre RubrosComisionesPorDescuento y Rubros'
ALTER TABLE [dbo].[RubrosComisionesPorDescuento]  WITH CHECK ADD  CONSTRAINT [FK_RubrosComisionesPorDescuento_Rubros] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubros] ([IdRubro])
GO
ALTER TABLE [dbo].[RubrosComisionesPorDescuento] CHECK CONSTRAINT [FK_RubrosComisionesPorDescuento_Rubros]
GO

PRINT ''
PRINT '8. Crea nueva tabla SubRubrosComisionesPorDescuento'
CREATE TABLE [dbo].[SubRubrosComisionesPorDescuento](
	[IdSubRubro] [int] NOT NULL,
	[DescuentoRecargoHasta] [decimal](5, 2) NOT NULL,
	[Comision] [decimal](5, 2) NULL,
 CONSTRAINT [PK_SubRubrosComisionesPorDescuento_1] PRIMARY KEY CLUSTERED 
(
	[IdSubRubro] ASC,
	[DescuentoRecargoHasta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

PRINT ''
PRINT '9. Crea FK entre SubRubrosComisionesPorDescuento y SubRubros'
ALTER TABLE [dbo].[SubRubrosComisionesPorDescuento]  WITH CHECK ADD  CONSTRAINT [FK_SubRubrosComisionesPorDescuento_Rubros] FOREIGN KEY([IdSubRubro])
REFERENCES [dbo].[SubRubros] ([IdSubRubro])
GO
ALTER TABLE [dbo].[SubRubrosComisionesPorDescuento] CHECK CONSTRAINT [FK_SubRubrosComisionesPorDescuento_Rubros]
GO

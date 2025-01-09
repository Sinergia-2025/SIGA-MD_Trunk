SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

PRINT ''
PRINT '1. Insertar Ediciones desde ediciones definidas en Clientes'
If dbo.SoyHAR() = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Borrar Ediciones actuales'
    DELETE FROM AplicacionesEdiciones

    PRINT ''
    PRINT '1.2. Insertar Ediciones nuevamente'
    INSERT INTO AplicacionesEdiciones (IdAplicacion, IdEdicion, NombreEdicion)
    select distinct Aplicaciones.IdAplicacion, Edicion, Edicion  from Clientes CROSS JOIN Aplicaciones
    where Edicion is not null
END

PRINT ''
PRINT '2. Tabla Funciones: Agregar campo IdModulo'
ALTER TABLE Funciones ADD IdModulo int null
GO
If dbo.SoyHAR() = 'True'
BEGIN
    PRINT ''
    PRINT '2.1. Cargar Modulo a funciones (Solo HAR)'
    UPDATE Funciones SET
           Funciones.IdModulo = AM.IdModulo
    FROM Funciones AS F
    INNER JOIN AplicacionesModulos AS AM
               ON F.IdPadre = AM.NombreModulo
END

PRINT ''
PRINT '3. Nueva Tabla ClientesAplicacionesModulos'
CREATE TABLE [dbo].[ClientesAplicacionesModulos](
	[IdCliente] [bigint] NOT NULL,
	[IdModulo] [int] NOT NULL,
 CONSTRAINT [PK_ClientesAplicacionesModulos] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC,
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClientesAplicacionesModulos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesAplicacionesModulos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ClientesAplicacionesModulos] CHECK CONSTRAINT [FK_ClientesAplicacionesModulos_Clientes]
GO


PRINT ''
PRINT '4. Nueva Tabla ClientesAplicacionesModulos: FK a AplicacionesModulos'
ALTER TABLE [dbo].[ClientesAplicacionesModulos]  WITH CHECK ADD  CONSTRAINT [FK_ClientesAplicacionesModulos_AplicacionesModulos] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[AplicacionesModulos] ([IdModulo])
GO
ALTER TABLE [dbo].[ClientesAplicacionesModulos] CHECK CONSTRAINT [FK_ClientesAplicacionesModulos_AplicacionesModulos]
GO

PRINT ''
PRINT '5. Nueva Tabla Funciones: FK a AplicacionesModulos'
ALTER TABLE [dbo].[Funciones]  WITH CHECK ADD  CONSTRAINT [FK_Funciones_AplicacionesModulos] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[AplicacionesModulos] ([IdModulo])
GO
ALTER TABLE [dbo].[Funciones] CHECK CONSTRAINT [FK_Funciones_AplicacionesModulos]
GO

PRINT ''
PRINT '6. Nueva Tabla Clientes: FK a AplicacionesEdiciones'
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_AplicacionesEdiciones] FOREIGN KEY([IdAplicacion], [Edicion])
REFERENCES [dbo].[AplicacionesEdiciones] ([IdAplicacion], [IdEdicion])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_AplicacionesEdiciones]
GO

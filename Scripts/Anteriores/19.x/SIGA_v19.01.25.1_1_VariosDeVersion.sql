PRINT ''
PRINT '1.- Crea los campos que faltan en la tabla MovilRutas'
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
ALTER TABLE dbo.MovilRutas ADD PuedeModificarPrecio bit NULL
ALTER TABLE dbo.MovilRutas ADD PrecioConImpuestos bit NULL
ALTER TABLE dbo.MovilRutas ADD Usuario varchar(10) NULL
GO
UPDATE MovilRutas SET PuedeModificarPrecio = 0, PrecioConImpuestos = 0;
ALTER TABLE dbo.MovilRutas ALTER COLUMN PuedeModificarPrecio bit NOT NULL
ALTER TABLE dbo.MovilRutas ALTER COLUMN PrecioConImpuestos bit NOT NULL
GO

PRINT ''
PRINT '2.- Si existe la tabla Rutas hago un MERGE con MovilRutas para actualizar los datos de esta última'
IF OBJECT_ID (N'dbo.Rutas', N'U') IS NOT NULL 
BEGIN
    MERGE INTO MovilRutas AS P
            USING Rutas AS PT ON P.IdRuta = PT.IdRuta
        WHEN MATCHED THEN
            UPDATE SET P.NombreRuta             = PT.NombreRuta
                     , P.Activa                 = PT.Habilitada
                     , P.TipoDocVendedor        = PT.TipoDocVendedor
                     , P.NroDocVendedor         = PT.NroDocVendedor
                     , P.IdTransportista        = PT.IdTransportista
                     , P.PuedeModificarPrecio   = PT.PuedeModificarPrecio
                     , P.PrecioConImpuestos     = PT.PrecioConImpuestos
                     , P.Usuario                = PT.Usuario
        WHEN NOT MATCHED THEN 
            INSERT (IdRuta, NombreRuta, Activa,     IdDispositivoPorDefecto, TipoDocVendedor, NroDocVendedor, IdTransportista, PuedeModificarPrecio, PrecioConImpuestos, Usuario)
            VALUES (IdRuta, NombreRuta, Habilitada, '',                      TipoDocVendedor, NroDocVendedor, IdTransportista, PuedeModificarPrecio, PrecioConImpuestos, Usuario)
    ;
END
ALTER TABLE dbo.MovilRutas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

PRINT ''
PRINT '3.- Si existe la tabla MovilRutasClientes está vacia copio los datos de Rutas'
IF OBJECT_ID (N'dbo.RutasClientes', N'U') IS NOT NULL 
BEGIN
    IF NOT EXISTS(SELECT * FROM MovilRutasClientes)
    BEGIN
        INSERT INTO [dbo].[MovilRutasClientes]
                   ([IdRuta]
                   ,[Dia]
                   ,[Orden]
                   ,[IdCliente])
        SELECT [IdRuta]
              ,[Dia]
              ,[Orden]
              ,[IdCliente]
          FROM [dbo].[RutasClientes]
    END
END

PRINT ''
PRINT '4.- Creo la tabla MovilRutasListasDePrecios'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovilRutasListasDePrecios](
	[IdRuta] [int] NOT NULL,
	[IdListaPrecios] [int] NOT NULL,
 CONSTRAINT [PK_MovilRutasListasDePrecios] PRIMARY KEY CLUSTERED 
(
	[IdRuta] ASC,
	[IdListaPrecios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MovilRutasListasDePrecios]  WITH CHECK ADD  CONSTRAINT [FK_MovilRutasListasDePrecios_ListasDePrecios] FOREIGN KEY([IdListaPrecios])
REFERENCES [dbo].[ListasDePrecios] ([IdListaPrecios])
GO

ALTER TABLE [dbo].[MovilRutasListasDePrecios] CHECK CONSTRAINT [FK_MovilRutasListasDePrecios_ListasDePrecios]
GO

ALTER TABLE [dbo].[MovilRutasListasDePrecios]  WITH CHECK ADD  CONSTRAINT [FK_MovilRutasListasDePrecios_MovilRutas] FOREIGN KEY([IdRuta])
REFERENCES [dbo].[MovilRutas] ([IdRuta])
GO

ALTER TABLE [dbo].[MovilRutasListasDePrecios] CHECK CONSTRAINT [FK_MovilRutasListasDePrecios_MovilRutas]
GO

IF OBJECT_ID (N'dbo.RutasListasDePrecios', N'U') IS NOT NULL 
BEGIN
PRINT ''
PRINT '5.- So existe la tabla RutasListasDePrecios copio los datos a MovilRutasListasDePrecios'
    INSERT INTO [dbo].[MovilRutasListasDePrecios]
               ([IdRuta]
               ,[IdListaPrecios])
    SELECT [IdRuta]
          ,[IdListaPrecios]
      FROM [dbo].[RutasListasDePrecios]
END
ELSE
BEGIN
PRINT ''
PRINT '5.- So NO existe la tabla RutasListasDePrecios asigno todas las listas de precios a todas las rutas en MovilRutasListasDePrecios'
    INSERT INTO [dbo].[MovilRutasListasDePrecios]
               ([IdRuta]
               ,[IdListaPrecios])
    SELECT IdRuta, IdListaPrecios
      FROM MovilRutas
     CROSS JOIN ListasDePrecios
END


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
PRINT ''
PRINT '6.- Creo indice IX_PedidosEstados_ComprobanteFact'
CREATE NONCLUSTERED INDEX IX_PedidosEstados_ComprobanteFact ON dbo.PedidosEstados
	(IdSucursalFact,IdTipoComprobanteFact,LetraFact,CentroEmisorFact,NumeroComprobanteFact)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
PRINT ''
PRINT '7.- Creo indice IX_PedidosEstados_PedidoGenerado'
CREATE NONCLUSTERED INDEX IX_PedidosEstados_PedidoGenerado ON dbo.PedidosEstados
	(IdSucursalGenerado,IdTipoComprobanteGenerado,LetraGenerado,CentroEmisorGenerado,NumeroPedidoGenerado)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
PRINT ''
PRINT '7.- Creo indice IX_PedidosEstados_ComprobanteRemito'
CREATE NONCLUSTERED INDEX IX_PedidosEstados_ComprobanteRemito ON dbo.PedidosEstados
	(IdSucursalRemito,IdTipoComprobanteRemito,LetraRemito,CentroEmisorRemito,NumeroComprobanteRemito)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
PRINT ''
PRINT '8.- Creo indice IX_PedidosEstados_OrdenProduccion'
CREATE NONCLUSTERED INDEX IX_PedidosEstados_OrdenProduccion ON dbo.PedidosEstados
	(IdSucursalProduccion,IdTipoComprobanteProduccion,LetraProduccion,CentroEmisorProduccion,NumeroOrdenProduccion)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
PRINT ''
PRINT '8.- Creo indice IX_PedidosEstados_PedidoVinculado'
CREATE NONCLUSTERED INDEX IX_PedidosEstados_PedidoVinculado ON dbo.PedidosEstados
	(IdSucursalVinculado,IdTipoComprobanteVinculado,LetraVinculado,CentroEmisorVinculado,NumeroPedidoVinculado)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.PedidosEstados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '9.- Quito NC de Recibo Vinculado'
UPDATE TiposComprobantes
   SET ComprobantesAsociados = REPLACE(REPLACE(REPLACE(REPLACE(ComprobantesAsociados, '''eNCRED'',' , ''), '''NCRED-F'',' , ''), '''NCRED'',' , ''), '''DEV-COTIZACION'',' , '')
 WHERE IdTipoComprobante LIKE 'RECIBOV%'


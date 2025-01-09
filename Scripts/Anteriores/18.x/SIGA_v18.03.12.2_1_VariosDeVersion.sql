PRINT '1. Menu_ConsultarPreciosPorCuotas'
GO

--DELETE FROM Bitacora WHERE IdFuncion = 'ConsultarPreciosPorCuotas';
--DELETE FROM RolesFunciones WHERE IdFuncion = 'ConsultarPreciosPorCuotas';
--DELETE FROM Funciones WHERE Id = 'ConsultarPreciosPorCuotas';

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Precios') AND
   EXISTS (SELECT * FROM Parametros WHERE IdParametro = 'MODULOFICHAS' AND ValorParametro = 'True')
    BEGIN
        DECLARE @parametro VARCHAR(MAX)
        -- PAYERO
        IF EXISTS(SELECT ValorParametro FROM Parametros WHERE IdParametro = 'CUITEMPRESA' AND ValorParametro = '20326412830')
            SET @parametro = 'LP';

        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('ConsultarPreciosPorCuotas', 'Consultar Precios Por Cuotas', 'Consultar Precios Por Cuotas', 'True', 'False', 'True', 'True',
              'Precios', 24, 'Eniac.Win', 'ConsultarPreciosPorCuotas', NULL, @parametro);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'ConsultarPreciosPorCuotas' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;

SELECT *
  FROM Funciones
 WHERE IdPadre = 'Precios'
 ORDER BY Posicion

 PRINT '2. Tabla_VentasAdjuntos'
GO

/****** Object:  Table [dbo].[VentasAdjuntos]    Script Date: 02/16/2018 13:06:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[VentasAdjuntos](
    [IdSucursal] [int] NOT NULL,
    [IdTipoComprobante] [varchar](15) NOT NULL,
    [Letra] [varchar](1) NOT NULL,
    [CentroEmisor] [int] NOT NULL,
    [NumeroComprobante] [bigint] NOT NULL,
    [IdVentaAdjunto] [bigint] NOT NULL,
    [IdProducto] [varchar](15) NULL,
    [Orden] [int] NULL,
    [IdTipoAdjunto] [int] NOT NULL,
    [NombreAdjunto] [varchar](260) NOT NULL,
    [Adjunto] [varbinary](max) NULL,
    [Observaciones] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_VentasAdjuntos] PRIMARY KEY CLUSTERED 
(
    [IdSucursal] ASC,
    [IdTipoComprobante] ASC,
    [Letra] ASC,
    [CentroEmisor] ASC,
    [NumeroComprobante] ASC,
    [IdVentaAdjunto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VentasAdjuntos]  WITH CHECK ADD  CONSTRAINT [FK_VentasAdjuntos_Ventas] FOREIGN KEY([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal])
GO
ALTER TABLE [dbo].[VentasAdjuntos] CHECK CONSTRAINT [FK_VentasAdjuntos_Ventas]
GO
ALTER TABLE [dbo].[VentasAdjuntos]  WITH CHECK ADD  CONSTRAINT [FK_VentasAdjuntos_VentasProductos] FOREIGN KEY([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto])
REFERENCES [dbo].[VentasProductos] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto])
GO
ALTER TABLE [dbo].[VentasAdjuntos] CHECK CONSTRAINT [FK_VentasAdjuntos_VentasProductos]
GO


 PRINT '3. Copiar_ClientesAdjuntos_VentasAdjuntos'
GO

INSERT INTO VentasAdjuntos
           (IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante
           ,IdVentaAdjunto,IdProducto,Orden
           ,IdTipoAdjunto,NombreAdjunto,Adjunto,Observaciones)
SELECT IdSucursalVenta,IdTipoComprobanteVenta,LetraVenta,CentroEmisorVenta,NumeroComprobanteVenta
      ,IdClienteAdjunto,NULL,NULL
      ,IdTipoAdjunto,NombreAdjunto,Adjunto,Observaciones
  FROM ClientesAdjuntos
 WHERE IdTipoComprobanteVenta IS NOT NULL

DELETE FROM ClientesAdjuntos WHERE IdTipoComprobanteVenta IS NOT NULL


 PRINT '4. DropColumnas_ClientesAdjuntos'
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
ALTER TABLE dbo.ClientesAdjuntos DROP CONSTRAINT FK_ClientesAdjuntos_Ventas
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ClientesAdjuntos
    DROP COLUMN IdSucursalVenta, IdTipoComprobanteVenta, LetraVenta, CentroEmisorVenta, NumeroComprobanteVenta
GO
ALTER TABLE dbo.ClientesAdjuntos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

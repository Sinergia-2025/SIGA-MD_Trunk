
PRINT '1. Agregar/Actualizar 3 Campos en Tabla TiposComprobantes.'

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
ALTER TABLE dbo.TiposComprobantes ADD AlInvocarPedidoAfectaFactura bit NULL
ALTER TABLE dbo.TiposComprobantes ADD AlInvocarPedidoAfectaRemito bit NULL
ALTER TABLE dbo.TiposComprobantes ADD InvocarPedidosConEstadoEspecifico bit NULL
GO
UPDATE TiposComprobantes
   SET AlInvocarPedidoAfectaFactura = 'True'
      ,AlInvocarPedidoAfectaRemito = 'True'
      ,InvocarPedidosConEstadoEspecifico = 'True';
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AlInvocarPedidoAfectaFactura bit NOT NULL
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN AlInvocarPedidoAfectaRemito bit NOT NULL
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN InvocarPedidosConEstadoEspecifico bit NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

/* ----------------------------------------------------------------------------------------------*/

PRINT ''
PRINT '2. De los campos en (1) cambiar seteos si es Sñl.'

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('30711915695'))
BEGIN
    UPDATE TiposComprobantes
       SET AlInvocarPedidoAfectaFactura = 'False'
          ,AlInvocarPedidoAfectaRemito = 'True'
          ,InvocarPedidosConEstadoEspecifico = 'True'
          ,ConsumePedidos = 'True'
     WHERE IdTipoComprobante IN ('REMITO', 'REMITOTRANSP');
    UPDATE TiposComprobantes
       SET AlInvocarPedidoAfectaFactura = 'True'
          ,AlInvocarPedidoAfectaRemito = 'False'
          ,InvocarPedidosConEstadoEspecifico = 'False'
     WHERE IdTipoComprobante IN ('ePRE-FACT','eFACT','FACT','FACT-F','TCK-FACT-F',
                                 'COTIZACION','TCK-FACT-F','TICKET-F','TICKET-NOFISCAL');
END;

--SELECT IdTipoComprobante
--      ,Tipo
--      ,Grupo
--      ,AlInvocarPedidoAfectaFactura
--      ,AlInvocarPedidoAfectaRemito
--      ,InvocarPedidosConEstadoEspecifico
--  FROM TiposComprobantes
-- WHERE IdTipoComprobante IN ('REMITO', 'REMITOTRANSP',
--                             'ePRE-FACT','eFACT','FACT','FACT-F','TCK-FACT-F',
--                             'COTIZACION','TCK-FACT-F','TICKET-F','TICKET-NOFISCAL');

/* ----------------------------------------------------------------------------------------------*/

PRINT ''
PRINT '3. Creo Nuevo Estado en EstadosPedidos'

INSERT INTO EstadosPedidos
    (idEstado,IdTipoComprobante,IdTipoEstado,Orden,AfectaPendiente,TipoEstadoPedido,Color)
VALUES
    ('PEDANULADO',NULL,'RECHAZADO',60,1,'PRESUPCLIE',-256)

--SELECT *
--  FROM EstadosPedidos
-- WHERE TipoEstadoPedido = 'PRESUPCLIE'
-- ORDER BY TipoEstadoPedido, Orden

/* ----------------------------------------------------------------------------------------------*/

PRINT ''
PRINT '4. Creo Parametro: Visualiza porcentaje de variación de costo'

DECLARE @valorParametro varchar(MAX)
SET @valorParametro = (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'UTILIZAPRECIODECOMPRA')	
;
INSERT INTO Parametros
	(IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
  VALUES
	('VISUALIZAPORCVARCOSTO', @valorParametro, 'COMPRAS', 'Visualiza porcentaje de variación de costo')
;


PRINT ''
PRINT '1. Tablas CajasDetalle y LibrosBancos: Agrega el Campo GeneraContabilidad / Seteo con el mismo valor que EsModificable.'
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
ALTER TABLE dbo.CajasDetalle ADD GeneraContabilidad bit NULL
GO
UPDATE CajasDetalle SET GeneraContabilidad = EsModificable;
ALTER TABLE dbo.CajasDetalle ALTER COLUMN GeneraContabilidad bit NOT NULL
GO
ALTER TABLE dbo.CajasDetalle SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.LibrosBancos ADD GeneraContabilidad bit NULL
GO
UPDATE LibrosBancos SET GeneraContabilidad = EsModificable;
ALTER TABLE dbo.LibrosBancos ALTER COLUMN GeneraContabilidad bit NOT NULL
GO
ALTER TABLE dbo.LibrosBancos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla Compras: Agrego campos de PK de Ventas para Invocar.'
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
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Compras ADD IdSucursalVenta int NULL
ALTER TABLE dbo.Compras ADD IdTipoComprobanteVenta varchar(15) NULL
ALTER TABLE dbo.Compras ADD LetraVenta varchar(1) NULL
ALTER TABLE dbo.Compras ADD CentroEmisorVenta int NULL
ALTER TABLE dbo.Compras ADD NumeroComprobanteVenta bigint NULL
GO
ALTER TABLE dbo.Compras ADD CONSTRAINT FK_Compras_Ventas
    FOREIGN KEY (IdTipoComprobanteVenta,LetraVenta,CentroEmisorVenta,NumeroComprobanteVenta,IdSucursalVenta)
    REFERENCES dbo.Ventas (IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante,IdSucursal)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.Compras SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '3. Tabla TiposComprobantes: Agrego campo InvocaCompras y Seteo en Falso.'
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
ALTER TABLE dbo.TiposComprobantes ADD InvocaCompras bit NULL
GO
UPDATE TiposComprobantes SET InvocaCompras = 'False';
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN InvocaCompras bit NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4. Tabla Funciones: Agrego campo PermiteMultiplesInstancias y Seteo en Verdadero.'
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
ALTER TABLE dbo.Funciones ADD PermiteMultiplesInstancias bit NULL
GO
ALTER TABLE dbo.Funciones ADD CONSTRAINT DF_Funciones_PermiteMultiplesInstancias DEFAULT 1 FOR PermiteMultiplesInstancias
GO
UPDATE Funciones SET PermiteMultiplesInstancias = 'True';
ALTER TABLE dbo.Funciones ALTER COLUMN PermiteMultiplesInstancias bit NOT NULL
GO
ALTER TABLE dbo.Funciones SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tabla Funciones: Agrego Permiso "Permite abrir Multiples Instancias" pero no deberia utilizarse.'
GO

--Inserto nuevo permiso
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
    VALUES
        ('PermiteMultiplesInstancias', 'Permite abrir Multiples Instancias', 'Permite abrir Multiples Instancias', 'False', 'False', 'True', 'False',
        'Configuraciones', 9999, 'Eniac.Win', '', NULL, NULL)
GO

/*  Este permiso no se necesita a menos que le cliente quiera limitar la cantidad de pantallas a abrir
INSERT INTO RolesFunciones 
        (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AntecedentesABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor')
GO    
*/


PRINT ''
PRINT '6. Tabla Ventas: Agrego campo IdMoneda y Seteo en 1 (Pesos).'
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
ALTER TABLE dbo.Ventas ADD IdMoneda int NULL
GO
UPDATE Ventas SET IdMoneda = 1;
ALTER TABLE dbo.Ventas ALTER COLUMN IdMoneda int NOT NULL
GO
ALTER TABLE dbo.Ventas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '7. Tabla TiposComprobantes: Creo el comprobante LIQUIDACION.'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock
           ,GrabaLibro,EsFacturable,LetrasHabilitadas,CantidadMaximaItems,Imprime
           ,CoeficienteValores,ModificaAlFacturar,EsFacturador,AfectaCaja,CargaPrecioActual
           ,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado,CantidadCopias,EsRemitoTransportista
           ,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv,IdTipoComprobanteSecundario,ImporteTope
           ,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo,EsElectronico,UsaFacturacion
           ,UtilizaImpuestos,NumeracionAutomatica,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta
           ,EsAnticipo,EsRecibo,Grupo,EsPreElectronico,GeneraContabilidad
           ,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas,IdTipoComprobanteNCred,IdTipoComprobanteNDeb
           ,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal,CodigoComprobanteSifere,EsDespachoImportacion
           ,CargaDescRecActual,IdTipoComprobanteContraMovInvocar,AlInvocarPedidoAfectaFactura,AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico,InvocaCompras)
     VALUES
           ('LIQUIDACION', 'False', 'Liquidacion', 'VENTAS', -1
           ,'True', 'False', 'A,B,C,M', 100, 'False'
           ,1, NULL, 'True', 'True', 'False'
           ,'True', 'Liquidac.', 'False', 1, 'False'
           ,NULL, 'True', 23, NULL, 0
           ,'.', 'False', 1, 'False', 'True'
           ,'True', 'False', 'True', 'True', 1
           ,'False', 'False', 'VENTAS', 'False', 'True'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'True', 'False', '', 'False'
           ,'False', NULL, 'False', 'False',
           'False', 'True')
GO

-- Por las dudas si se ejecuto en forma independiente en algun cliente.
UPDATE TiposComprobantes
   SET InvocaCompras = 'True'
 WHERE IdTipoComprobante = 'LIQUIDACION'
   AND InvocaCompras = 'False'
GO


PRINT ''
PRINT '8. Tabla AFIPTiposComprobantesTiposCbtes: Creo el seteo para LIQUIDACION A, B y C.'
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
     VALUES
           (63, 'LIQUIDACION', 'A'),
           (64, 'LIQUIDACION', 'B'),
           (68, 'LIQUIDACION', 'C')
GO


PRINT ''
PRINT '9. Tabla TiposComprobantes: Creo el comprobante CIERRE-Z.'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante,EsFiscal,Descripcion,Tipo,CoeficienteStock
           ,GrabaLibro,EsFacturable,LetrasHabilitadas,CantidadMaximaItems,Imprime
           ,CoeficienteValores,ModificaAlFacturar,EsFacturador,AfectaCaja,CargaPrecioActual
           ,ActualizaCtaCte,DescripcionAbrev,PuedeSerBorrado,CantidadCopias,EsRemitoTransportista
           ,ComprobantesAsociados,EsComercial,CantidadMaximaItemsObserv,IdTipoComprobanteSecundario,ImporteTope
           ,IdTipoComprobanteEpson,UsaFacturacionRapida,ImporteMinimo,EsElectronico,UsaFacturacion
           ,UtilizaImpuestos,NumeracionAutomatica,GeneraObservConInvocados,ImportaObservDeInvocados,IdPlanCuenta
           ,EsAnticipo,EsRecibo,Grupo,EsPreElectronico,GeneraContabilidad
           ,UtilizaCtaSecundariaProd,UtilizaCtaSecundariaCateg,IncluirEnExpensas,IdTipoComprobanteNCred,IdTipoComprobanteNDeb
           ,IdProductoNCred,IdProductoNDeb,ConsumePedidos,EsPreFiscal,CodigoComprobanteSifere,EsDespachoImportacion
           ,CargaDescRecActual,IdTipoComprobanteContraMovInvocar,AlInvocarPedidoAfectaFactura,AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico,InvocaCompras)
     VALUES
           ('CIERRE-Z', 'False', 'Cierre Z', 'VENTAS', 0
           ,'True', 'False', 'Z', 100, 'False'
           ,1, NULL, 'True', 'True', 'False'
           ,'True', 'Cierre Z', 'False', 1, 'False'
           ,NULL, 'True', 23, NULL, 0
           ,'.', 'False', 1, 'False', 'True'
           ,'True', 'False', 'True', 'True', 1
           ,'False', 'False', 'VENTAS', 'False', 'True'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'True', 'False', '', 'False'
           ,'False', NULL, 'False', 'False',
           'False', 'False')
GO

-- Por las dudas si se ejecuto en forma independiente en algun cliente.
UPDATE TiposComprobantes
   SET LetrasHabilitadas = 'Z'
 WHERE IdTipoComprobante = 'CIERRE-Z'
   AND LetrasHabilitadas <> 'Z'
GO


PRINT ''
PRINT '10. Tabla AFIPTiposComprobantesTiposCbtes: Creo el seteo para Cierre Z.'
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
     VALUES
           (80, 'CIERRE-Z', 'Z')
GO


PRINT ''
PRINT '11. Tabla AFIPTiposComprobantesTiposCbtes: Creo los seteos para eFACT-Web, eNCRED-Web y eNDEB-Web'
GO

INSERT INTO AFIPTiposComprobantesTiposCbtes
           (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
SELECT IdAFIPTipoComprobante, IdTipoComprobante+'-Web', Letra 
  FROM AFIPTiposComprobantesTiposCbtes
 WHERE IdTipoComprobante IN ('eFACT','eNCRED','eNDEB')
GO

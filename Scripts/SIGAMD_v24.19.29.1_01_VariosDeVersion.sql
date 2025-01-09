

IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('InfOrdenProduccionMRPProductos') = 1
BEGIN
UPDATE funciones SET Nombre = 'Inf. Detalle Operaciones de Orden Producción', 
				     Descripcion = 'Inf. Detalle Operaciones de Orden Producción'
where id = 'InfOrdenProduccionMRPProductos'
END
GO

ALTER TABLE TarjetasCupones ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE TarjetasCuponesHistorial ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE CuentasCorrientesTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

ALTER TABLE VentasTarjetas ALTER COLUMN Monto decimal(16,4) NOT NULL

IF dbo.ExisteFK('FK_ComprasRetenciones_Retenciones') = 1
BEGIN
    ALTER TABLE ComprasRetenciones DROP CONSTRAINT FK_ComprasRetenciones_Retenciones
END
GO
IF dbo.ExisteFK('FK_ComprasRetenciones_Compras') = 1
BEGIN
    ALTER TABLE ComprasRetenciones DROP CONSTRAINT FK_ComprasRetenciones_Compras
END
GO

IF dbo.ExisteFK('FK_ComprasRetenciones_Provincias') = 1
BEGIN
    ALTER TABLE ComprasRetenciones DROP CONSTRAINT FK_ComprasRetenciones_Provincias
END
GO

IF dbo.ExisteFK('FK_CuentasCorrientesRetenciones_Retenciones') = 1
BEGIN
    ALTER TABLE CuentasCorrientesRetenciones DROP CONSTRAINT FK_CuentasCorrientesRetenciones_Retenciones
END
GO


IF dbo.ExisteTabla('ComprasRetenciones') = 1
BEGIN
    DROP TABLE ComprasRetenciones
END
GO


IF dbo.ExisteCampo('Retenciones', 'IdRetencion') = 0
BEGIN
    ALTER TABLE dbo.Retenciones ADD IdRetencion int NULL
END
GO

UPDATE R
   SET IdRetencion = R.Row#
  FROM (SELECT ROW_NUMBER() OVER(ORDER BY FechaEmision ASC) AS Row#, *
        FROM Retenciones) R
 WHERE IdRetencion IS NULL

ALTER TABLE dbo.Retenciones ALTER COLUMN IdRetencion int NOT NULL

IF dbo.ExistePK('PK_Retenciones') = 1
BEGIN
    ALTER TABLE dbo.Retenciones DROP CONSTRAINT PK_Retenciones WITH ( ONLINE = OFF )
END
GO

IF dbo.ExistePK('PK_Retenciones') = 0
BEGIN
    ALTER TABLE dbo.Retenciones ADD CONSTRAINT PK_Retenciones
        PRIMARY KEY CLUSTERED (IdRetencion)
        WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('ComprasRetenciones') = 0
BEGIN
    CREATE TABLE ComprasRetenciones(
	    IdSucursal int NOT NULL,
	    IdTipoComprobante varchar(15) NOT NULL,
	    Letra varchar(1) NOT NULL,
	    CentroEmisor int NOT NULL,
	    NumeroComprobante bigint NOT NULL,
	    IdProveedor bigint NOT NULL,
        IdRetencion int NOT NULL,
     CONSTRAINT PK_ComprasRetenciones PRIMARY KEY CLUSTERED (
	    IdSucursal ASC,
	    IdTipoComprobante ASC, Letra ASC, CentroEmisor ASC, NumeroComprobante ASC, IdProveedor ASC,
	    IdRetencion ASC)
        WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_ComprasRetenciones_Compras') = 0
BEGIN
    ALTER TABLE dbo.ComprasRetenciones  WITH CHECK ADD  CONSTRAINT FK_ComprasRetenciones_Compras FOREIGN KEY(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor)
        REFERENCES dbo.Compras (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor)
    ALTER TABLE dbo.ComprasRetenciones CHECK CONSTRAINT FK_ComprasRetenciones_Compras
END
GO

IF dbo.ExisteFK('FK_ComprasRetenciones_Retenciones') = 0
BEGIN
    ALTER TABLE dbo.ComprasRetenciones  WITH CHECK ADD  CONSTRAINT FK_ComprasRetenciones_Retenciones FOREIGN KEY(IdRetencion)
        REFERENCES dbo.Retenciones (IdRetencion)
    ALTER TABLE dbo.ComprasRetenciones CHECK CONSTRAINT FK_ComprasRetenciones_Retenciones
END
GO

IF dbo.ExisteCampo('CuentasCorrientesRetenciones', 'IdRetencion') = 0
BEGIN
    ALTER TABLE dbo.CuentasCorrientesRetenciones ADD IdRetencion int NULL
END
GO

UPDATE CCR
   SET IdRetencion = R.IdRetencion
  FROM CuentasCorrientesRetenciones CCR
 INNER JOIN Retenciones R
    ON R.IdSucursal      = CCR.IdSucursal
   AND R.IdTipoImpuesto  = CCR.IdTipoImpuesto
   AND R.EmisorRetencion = CCR.EmisorRetencion
   AND R.NumeroRetencion = CCR.NumeroRetencion
   AND R.IdCliente       = CCR.IdCliente
 WHERE CCR.IdRetencion IS NULL

ALTER TABLE dbo.CuentasCorrientesRetenciones ALTER COLUMN IdRetencion int NOT NULL



IF dbo.ExistePK('PK_CuentasCorrientesRetenciones') = 1
BEGIN
    ALTER TABLE dbo.CuentasCorrientesRetenciones DROP CONSTRAINT PK_CuentasCorrientesRetenciones
END
GO

IF dbo.ExistePK('PK_CuentasCorrientesRetenciones') = 0
BEGIN
    ALTER TABLE dbo.CuentasCorrientesRetenciones ADD CONSTRAINT PK_CuentasCorrientesRetenciones
        PRIMARY KEY CLUSTERED (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdRetencion)
        WITH( PAD_INDEX = OFF, FILLFACTOR = 90, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END

IF dbo.ExisteFK('FK_CuentasCorrientesRetenciones_Retenciones') = 0
BEGIN
    ALTER TABLE dbo.CuentasCorrientesRetenciones ADD CONSTRAINT FK_CuentasCorrientesRetenciones_Retenciones 
        FOREIGN KEY (IdRetencion)
        REFERENCES dbo.Retenciones (IdRetencion)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

IF dbo.ExisteFuncion('ComisionesVendedores') = 1 AND dbo.ExisteFuncion('ComisionesProdVendedorLista') = 0
BEGIN

INSERT [dbo].[Funciones] ([Id], [Nombre], [Descripcion], [EsMenu], [EsBoton], [Enabled], [Visible], [IdPadre], 
[Posicion], [Archivo], [Pantalla], [Icono], [Parametros], [PermiteMultiplesInstancias], 
[Plus], [Express], [Basica], [PV], [IdModulo], [EsMDIChild]) 
VALUES (N'ComisionesProdVendedorLista', N'ABM de Comisiones Productos de Vendedores por Lista', N'ABM de Comisiones Productos de Vendedores por Lista', 1, 0, 1, 1, N'ComisionesVendedores', 
201, N'Eniac.Win', N'ComisionesProductoVendedorLista', NULL, NULL, 1, N'S', N'N', N'N', N'N', NULL, 1)

INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ComisionesProdVendedorLista' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

MERGE INTO TiposComprobantes AS DEST
        USING (SELECT 'LIQUIDATARJETA' IdTipoComprobante, 'False' EsFiscal, 'Liquidación Tarjeta' Descripcion, 'COMPRAS' Tipo, 0 CoeficienteStock
                    , 'True' GrabaLibro, 'False' EsFacturable, 'X' LetrasHabilitadas, 100 CantidadMaximaItems, 'True' Imprime
                    , -1 CoeficienteValores, NULL ModificaAlFacturar, 'False' EsFacturador, 'True' AfectaCaja, 'False' CargaPrecioActual
                    , 'False' ActualizaCtaCte, 'Liq. Tarj.' DescripcionAbrev, 'True' PuedeSerBorrado, 1 CantidadCopias, 'False' EsRemitoTransportista
                    , NULL ComprobantesAsociados, 'True' EsComercial, 99 CantidadMaximaItemsObserv, NULL IdTipoComprobanteSecundario, 999999999.99 ImporteTope
                    , '.' IdTipoComprobanteEpson, 'False' UsaFacturacionRapida, -9999999.99 ImporteMinimo, 'False' EsElectronico, 'True' UsaFacturacion
                    , 'True' UtilizaImpuestos, 'False' NumeracionAutomatica, 'False' GeneraObservConInvocados, 'False' ImportaObservDeInvocados, 1 IdPlanCuenta
                    , 'False' EsAnticipo, 'False' EsRecibo, 'COMPRAS' Grupo, 'False' EsPreElectronico, 'True' GeneraContabilidad
                    , 'False' UtilizaCtaSecundariaProd, 'False' UtilizaCtaSecundariaCateg, 'False' IncluirEnExpensas, NULL IdTipoComprobanteNCred, NULL IdTipoComprobanteNDeb
                    , NULL IdProductoNCred, NULL IdProductoNDeb, 'False' ConsumePedidos, 'False' EsPreFiscal, 'C' CodigoComprobanteSifere
                    , 'False' EsDespachoImportacion, 'False' CargaDescRecActual, NULL IdTipoComprobanteContraMovInvocar, 'False' AlInvocarPedidoAfectaFactura, 'False' AlInvocarPedidoAfectaRemito
                    , 'False' InvocarPedidosConEstadoEspecifico, 'False' InvocaCompras, 8 LargoMaximoNumero, 1 NivelAutorizacion, 'False' RequiereReferenciaCtaCte
                    , 'True' ControlaTopeConsumidorFinal, 'False' CargaDescRecGralActual, 'False' EsReciboClienteVinculado, NULL AFIPWSIncluyeFechaVencimiento, 'False' AFIPWSEsFEC
                    , 'False' AFIPWSRequiereReferenciaComercial, 'False' AFIPWSRequiereComprobanteAsociado, 'False' AFIPWSRequiereCBU, 'False' AFIPWSCodigoAnulacion, 10 Orden
                    , 'False' MarcaInvocado, 'False' PermiteSeleccionarAlicuotaIVA, 'False' ImportaObservGrales, 'Liquidación Tarjeta' DescripcionImpresion, 'True' InformaLibroIva
                    , 'False' SolicitaFechaDevolucion, 'False' AFIPWSRequiereReferenciaTransferencia, 'False' ActivaTildeMercDespacha, NULL Color, '' CodigoRoela
                    , 'LIQUIDATARJETA' ClaseComprobante, 'False' SimulaPercepciones, 'False' SolicitaInformeCalidad
              ) AS ORIG ON DEST.IdTipoComprobante = ORIG.IdTipoComprobante
    WHEN MATCHED THEN
        UPDATE SET DEST.IdTipoComprobante = ORIG.IdTipoComprobante
                 , DEST.EsFiscal = ORIG.EsFiscal
                 , DEST.Descripcion = ORIG.Descripcion
                 , DEST.Tipo = ORIG.Tipo
                 , DEST.CoeficienteStock = ORIG.CoeficienteStock
                 , DEST.GrabaLibro = ORIG.GrabaLibro
                 , DEST.EsFacturable = ORIG.EsFacturable
                 , DEST.LetrasHabilitadas = ORIG.LetrasHabilitadas
                 , DEST.CantidadMaximaItems = ORIG.CantidadMaximaItems
                 , DEST.Imprime = ORIG.Imprime
                 , DEST.CoeficienteValores = ORIG.CoeficienteValores
                 , DEST.ModificaAlFacturar = ORIG.ModificaAlFacturar
                 , DEST.EsFacturador = ORIG.EsFacturador
                 , DEST.AfectaCaja = ORIG.AfectaCaja
                 , DEST.CargaPrecioActual = ORIG.CargaPrecioActual
                 , DEST.ActualizaCtaCte = ORIG.ActualizaCtaCte
                 , DEST.DescripcionAbrev = ORIG.DescripcionAbrev
                 , DEST.PuedeSerBorrado = ORIG.PuedeSerBorrado
                 , DEST.CantidadCopias = ORIG.CantidadCopias
                 , DEST.EsRemitoTransportista = ORIG.EsRemitoTransportista
                 , DEST.ComprobantesAsociados = ORIG.ComprobantesAsociados
                 , DEST.EsComercial = ORIG.EsComercial
                 , DEST.CantidadMaximaItemsObserv = ORIG.CantidadMaximaItemsObserv
                 , DEST.IdTipoComprobanteSecundario = ORIG.IdTipoComprobanteSecundario
                 , DEST.ImporteTope = ORIG.ImporteTope
                 , DEST.IdTipoComprobanteEpson = ORIG.IdTipoComprobanteEpson
                 , DEST.UsaFacturacionRapida = ORIG.UsaFacturacionRapida
                 , DEST.ImporteMinimo = ORIG.ImporteMinimo
                 , DEST.EsElectronico = ORIG.EsElectronico
                 , DEST.UsaFacturacion = ORIG.UsaFacturacion
                 , DEST.UtilizaImpuestos = ORIG.UtilizaImpuestos
                 , DEST.NumeracionAutomatica = ORIG.NumeracionAutomatica
                 , DEST.GeneraObservConInvocados = ORIG.GeneraObservConInvocados
                 , DEST.ImportaObservDeInvocados = ORIG.ImportaObservDeInvocados
                 , DEST.IdPlanCuenta = ORIG.IdPlanCuenta
                 , DEST.EsAnticipo = ORIG.EsAnticipo
                 , DEST.EsRecibo = ORIG.EsRecibo
                 , DEST.Grupo = ORIG.Grupo
                 , DEST.EsPreElectronico = ORIG.EsPreElectronico
                 , DEST.GeneraContabilidad = ORIG.GeneraContabilidad
                 , DEST.UtilizaCtaSecundariaProd = ORIG.UtilizaCtaSecundariaProd
                 , DEST.UtilizaCtaSecundariaCateg = ORIG.UtilizaCtaSecundariaCateg
                 , DEST.IncluirEnExpensas = ORIG.IncluirEnExpensas
                 , DEST.IdTipoComprobanteNCred = ORIG.IdTipoComprobanteNCred
                 , DEST.IdTipoComprobanteNDeb = ORIG.IdTipoComprobanteNDeb
                 , DEST.IdProductoNCred = ORIG.IdProductoNCred
                 , DEST.IdProductoNDeb = ORIG.IdProductoNDeb
                 , DEST.ConsumePedidos = ORIG.ConsumePedidos
                 , DEST.EsPreFiscal = ORIG.EsPreFiscal
                 , DEST.CodigoComprobanteSifere = ORIG.CodigoComprobanteSifere
                 , DEST.EsDespachoImportacion = ORIG.EsDespachoImportacion
                 , DEST.CargaDescRecActual = ORIG.CargaDescRecActual
                 , DEST.IdTipoComprobanteContraMovInvocar = ORIG.IdTipoComprobanteContraMovInvocar
                 , DEST.AlInvocarPedidoAfectaFactura = ORIG.AlInvocarPedidoAfectaFactura
                 , DEST.AlInvocarPedidoAfectaRemito = ORIG.AlInvocarPedidoAfectaRemito
                 , DEST.InvocarPedidosConEstadoEspecifico = ORIG.InvocarPedidosConEstadoEspecifico
                 , DEST.InvocaCompras = ORIG.InvocaCompras
                 , DEST.LargoMaximoNumero = ORIG.LargoMaximoNumero
                 , DEST.NivelAutorizacion = ORIG.NivelAutorizacion
                 , DEST.RequiereReferenciaCtaCte = ORIG.RequiereReferenciaCtaCte
                 , DEST.ControlaTopeConsumidorFinal = ORIG.ControlaTopeConsumidorFinal
                 , DEST.CargaDescRecGralActual = ORIG.CargaDescRecGralActual
                 , DEST.EsReciboClienteVinculado = ORIG.EsReciboClienteVinculado
                 , DEST.AFIPWSIncluyeFechaVencimiento = ORIG.AFIPWSIncluyeFechaVencimiento
                 , DEST.AFIPWSEsFEC = ORIG.AFIPWSEsFEC
                 , DEST.AFIPWSRequiereReferenciaComercial = ORIG.AFIPWSRequiereReferenciaComercial
                 , DEST.AFIPWSRequiereComprobanteAsociado = ORIG.AFIPWSRequiereComprobanteAsociado
                 , DEST.AFIPWSRequiereCBU = ORIG.AFIPWSRequiereCBU
                 , DEST.AFIPWSCodigoAnulacion = ORIG.AFIPWSCodigoAnulacion
                 , DEST.Orden = ORIG.Orden
                 , DEST.MarcaInvocado = ORIG.MarcaInvocado
                 , DEST.PermiteSeleccionarAlicuotaIVA = ORIG.PermiteSeleccionarAlicuotaIVA
                 , DEST.ImportaObservGrales = ORIG.ImportaObservGrales
                 , DEST.DescripcionImpresion = ORIG.DescripcionImpresion
                 , DEST.InformaLibroIva = ORIG.InformaLibroIva
                 , DEST.SolicitaFechaDevolucion = ORIG.SolicitaFechaDevolucion
                 , DEST.AFIPWSRequiereReferenciaTransferencia = ORIG.AFIPWSRequiereReferenciaTransferencia
                 , DEST.ActivaTildeMercDespacha = ORIG.ActivaTildeMercDespacha
                 , DEST.Color = ORIG.Color
                 , DEST.CodigoRoela = ORIG.CodigoRoela
                 , DEST.ClaseComprobante = ORIG.ClaseComprobante
                 , DEST.SimulaPercepciones = ORIG.SimulaPercepciones
                 , DEST.SolicitaInformeCalidad = ORIG.SolicitaInformeCalidad
    WHEN NOT MATCHED THEN 
        INSERT (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock
              , GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime
              , CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual
              , ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista
              , ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope
              , IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
              , UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta
              , EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
              , UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
              , IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere
              , EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito
              , InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion, RequiereReferenciaCtaCte
              , ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado, AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC
              , AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado, AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden
              , MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales, DescripcionImpresion, InformaLibroIva
              , SolicitaFechaDevolucion, AFIPWSRequiereReferenciaTransferencia, ActivaTildeMercDespacha, Color, CodigoRoela
              , ClaseComprobante, SimulaPercepciones, SolicitaInformeCalidad
               ) VALUES (
                ORIG.IdTipoComprobante, ORIG.EsFiscal, ORIG.Descripcion, ORIG.Tipo, ORIG.CoeficienteStock
              , ORIG.GrabaLibro, ORIG.EsFacturable, ORIG.LetrasHabilitadas, ORIG.CantidadMaximaItems, ORIG.Imprime
              , ORIG.CoeficienteValores, ORIG.ModificaAlFacturar, ORIG.EsFacturador, ORIG.AfectaCaja, ORIG.CargaPrecioActual
              , ORIG.ActualizaCtaCte, ORIG.DescripcionAbrev, ORIG.PuedeSerBorrado, ORIG.CantidadCopias, ORIG.EsRemitoTransportista
              , ORIG.ComprobantesAsociados, ORIG.EsComercial, ORIG.CantidadMaximaItemsObserv, ORIG.IdTipoComprobanteSecundario, ORIG.ImporteTope
              , ORIG.IdTipoComprobanteEpson, ORIG.UsaFacturacionRapida, ORIG.ImporteMinimo, ORIG.EsElectronico, ORIG.UsaFacturacion
              , ORIG.UtilizaImpuestos, ORIG.NumeracionAutomatica, ORIG.GeneraObservConInvocados, ORIG.ImportaObservDeInvocados, ORIG.IdPlanCuenta
              , ORIG.EsAnticipo, ORIG.EsRecibo, ORIG.Grupo, ORIG.EsPreElectronico, ORIG.GeneraContabilidad
              , ORIG.UtilizaCtaSecundariaProd, ORIG.UtilizaCtaSecundariaCateg, ORIG.IncluirEnExpensas, ORIG.IdTipoComprobanteNCred, ORIG.IdTipoComprobanteNDeb
              , ORIG.IdProductoNCred, ORIG.IdProductoNDeb, ORIG.ConsumePedidos, ORIG.EsPreFiscal, ORIG.CodigoComprobanteSifere
              , ORIG.EsDespachoImportacion, ORIG.CargaDescRecActual, ORIG.IdTipoComprobanteContraMovInvocar, ORIG.AlInvocarPedidoAfectaFactura, ORIG.AlInvocarPedidoAfectaRemito
              , ORIG.InvocarPedidosConEstadoEspecifico, ORIG.InvocaCompras, ORIG.LargoMaximoNumero, ORIG.NivelAutorizacion, ORIG.RequiereReferenciaCtaCte
              , ORIG.ControlaTopeConsumidorFinal, ORIG.CargaDescRecGralActual, ORIG.EsReciboClienteVinculado, ORIG.AFIPWSIncluyeFechaVencimiento, ORIG.AFIPWSEsFEC
              , ORIG.AFIPWSRequiereReferenciaComercial, ORIG.AFIPWSRequiereComprobanteAsociado, ORIG.AFIPWSRequiereCBU, ORIG.AFIPWSCodigoAnulacion, ORIG.Orden
              , ORIG.MarcaInvocado, ORIG.PermiteSeleccionarAlicuotaIVA, ORIG.ImportaObservGrales, ORIG.DescripcionImpresion, ORIG.InformaLibroIva
              , ORIG.SolicitaFechaDevolucion, ORIG.AFIPWSRequiereReferenciaTransferencia, ORIG.ActivaTildeMercDespacha, ORIG.Color, ORIG.CodigoRoela
              , ORIG.ClaseComprobante, ORIG.SimulaPercepciones, ORIG.SolicitaInformeCalidad)
;
UPDATE TiposMovimientos
   SET ComprobantesAsociados = ComprobantesAsociados + ',LIQUIDATARJETA'
 WHERE IdTipoMovimiento = 'COMPRA-NC'
    AND (NOT ComprobantesAsociados LIKE '%LIQUIDATARJETA'
    AND  NOT ComprobantesAsociados LIKE 'LIQUIDATARJETA%'
    AND  NOT ComprobantesAsociados LIKE '%LIQUIDATARJETA%')

MERGE INTO AFIPTiposComprobantesTiposCbtes AS DEST
        USING (SELECT 99 IdAFIPTipoComprobante, 'LIQUIDATARJETA' IdTipoComprobante, 'X' Letra) AS ORIG ON DEST.IdTipoComprobante = ORIG.IdTipoComprobante AND DEST.Letra = ORIG.Letra
    WHEN MATCHED THEN
        UPDATE SET DEST.IdAFIPTipoComprobante = ORIG.IdAFIPTipoComprobante
    WHEN NOT MATCHED THEN 
        INSERT (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (ORIG.IdAFIPTipoComprobante, ORIG.IdTipoComprobante, ORIG.Letra)
;
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('ComprasTarjetas') = 0
BEGIN
    CREATE TABLE ComprasTarjetas(
	    IdSucursal int NOT NULL,
	    IdTipoComprobante varchar(15) NOT NULL,
	    Letra varchar(1) NOT NULL,
	    CentroEmisor int NOT NULL,
	    NumeroComprobante bigint NOT NULL,
	    IdProveedor bigint NOT NULL,
	    IdTarjetaCupon int NOT NULL,
     CONSTRAINT PK_ComprasTarjetas PRIMARY KEY CLUSTERED (IdSucursal ASC, IdTipoComprobante ASC, Letra ASC, CentroEmisor ASC, NumeroComprobante ASC, IdProveedor ASC, IdTarjetaCupon ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_ComprasTarjetas_Compras') = 0
BEGIN
    ALTER TABLE dbo.ComprasTarjetas  WITH CHECK ADD  CONSTRAINT FK_ComprasTarjetas_Compras FOREIGN KEY(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor)
        REFERENCES dbo.Compras (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor)
    ALTER TABLE dbo.ComprasTarjetas CHECK CONSTRAINT FK_ComprasTarjetas_Compras
END
GO

IF dbo.ExisteFK('FK_ComprasTarjetas_TarjetasCupones') = 0
BEGIN
    ALTER TABLE dbo.ComprasTarjetas  WITH CHECK ADD  CONSTRAINT FK_ComprasTarjetas_TarjetasCupones FOREIGN KEY(IdTarjetaCupon)
        REFERENCES dbo.TarjetasCupones (IdTarjetaCupon)
    ALTER TABLE dbo.ComprasTarjetas CHECK CONSTRAINT FK_ComprasTarjetas_TarjetasCupones
END
GO

IF dbo.ExisteFuncion('CuentasCorrientes') = 1 AND dbo.ExisteFuncion('InformeComisionesPremios') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InformeComisionesPremios', 'Informe de Comsiones y Premios', 'Informe de Comsiones y Premios', 'True', 'False', 'True', 'True'
        ,'CuentasCorrientes', 113, 'Eniac.Win', 'InformeDeComisionesPremios', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InformeComisionesPremios' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

--Verificación de que la Base no sea la de HAR GROUP
IF dbo.SoyHAR() = 0
BEGIN
	--Al NO ser la Base de HAR GROUP, comienza la sentencia
	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'PresupuestosAdminProv'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'PresupuestosAdminProv'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'PresupuestosAdminProv'
		DELETE RolesFunciones FROM  RolesFunciones RF INNER JOIN Funciones F ON F.Id = RF.IdFuncion  WHERE IdPadre = 'PresupuestosAdminProv'
		DELETE RolesFunciones WHERE IdFuncion = 'PresupuestosAdminProv'
		DELETE Funciones WHERE IdPadre = 'PresupuestosAdminProv'
		DELETE Funciones WHERE Id = 'PresupuestosAdminProv'
		PRINT 'Se eliminó la función "Administrador de Presupuestos a Proveedor (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Presupuestos a Proveedor (v1)"'
	END

	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'OrdenCompraAdminProv'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'OrdenCompraAdminProv'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'OrdenCompraAdminProv'
		DELETE RolesFunciones FROM  RolesFunciones RF INNER JOIN Funciones F ON F.Id = RF.IdFuncion  WHERE IdPadre = 'OrdenCompraAdminProv'
		DELETE RolesFunciones WHERE IdFuncion = 'OrdenCompraAdminProv'
		DELETE Funciones WHERE IdPadre = 'OrdenCompraAdminProv'
		DELETE Funciones WHERE Id = 'OrdenCompraAdminProv'
		PRINT 'Se eliminó la función "Administrador de Órdenes de Compra Proveedor (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Órdenes de Compra Proveedor (v1)"'
	END

	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'PedidosAdminProv'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'PedidosAdminProv'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'PedidosAdminProv'
		DELETE RolesFunciones FROM  RolesFunciones RF INNER JOIN Funciones F ON F.Id = RF.IdFuncion  WHERE IdPadre = 'PedidosAdminProv'
		DELETE RolesFunciones WHERE IdFuncion = 'PedidosAdminProv'
		DELETE Funciones WHERE IdPadre = 'PedidosAdminProv'
		DELETE Funciones WHERE Id = 'PedidosAdminProv'
		PRINT 'Se eliminó la función "Administrador de Pedidos a Proveedor (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Pedidos a Proveedor (v1)"'
	END

	IF (EXISTS (SELECT * 
                 FROM Funciones 
                 WHERE ID = 'OrdenesProduccionAdmin'))
	BEGIN
		DELETE Traducciones WHERE IdFuncion = 'OrdenesProduccionAdmin'
		UPDATE Funciones SET IdPadre = NULL WHERE Id = 'OrdenesProduccionAdmin'
		DELETE RolesFunciones WHERE IdFuncion = 'OrdenesProduccionAdmin'
		DELETE Funciones WHERE Id = 'OrdenesProduccionAdmin'
		PRINT 'Se eliminó la función "Administrador de Órdenes de Producción (v1)"'
	END
	ELSE
	BEGIN
		PRINT 'No existía la función "Administrador de Órdenes de Producción (v1)"'
	END

END
ELSE --La Base SÍ es de HAR GROUP, no se elimina la función de Administrador
BEGIN
    PRINT 'Script corrido sobre HAR GROUP, no se elimina la función de Administrador'
END
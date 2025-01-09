
DELETE TiposComprobantes
 WHERE IdTipoComprobante IN ('REPARTO-SALIDA','REPARTO-ENTRADA')
GO

PRINT ''
PRINT '1. TiposComprobantes: Nuevo Comprobante "Reparto Salida".'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock
           ,GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime
           ,CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual
           ,ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista
           ,ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope
           ,IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
           ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta
           ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
           ,UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
           ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, EsDespachoImportacion
           ,CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion)
     VALUES
           ('REPARTO-SALIDA', 'False', 'Reparto Salida', 'VENTAS', -1
           ,'False', 'True', 'X', 100, 'True'
           ,1, 'SOLOPRECIOS', 'True', 'False', 'True'
           ,'False', 'Rep.Sal.', 'False', 1, 'True'
           ,NULL, 'False', 99, NULL, 0
           ,'.', 'False', 0.01, 'False', 'True'
           ,'True', 'False', 'True', 'True', 2
           ,'False', 'False', 'VENTAS', 'False', 'False'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'False', 'False', '', 'False'
           ,'True', NULL, 'True', 'True',
           'True', 'False', 8, 1)
GO

PRINT ''
PRINT '2. TiposComprobantes: Nuevo Comprobante "Reparto Entrada".'
GO

INSERT INTO TiposComprobantes
           (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock
           ,GrabaLibro, EsFacturable, LetrasHabilitadas, CantidadMaximaItems, Imprime
           ,CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual
           ,ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista
           ,ComprobantesAsociados, EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope
           ,IdTipoComprobanteEpson, UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion
           ,UtilizaImpuestos, NumeracionAutomatica, GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta
           ,EsAnticipo, EsRecibo, Grupo, EsPreElectronico, GeneraContabilidad
           ,UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred, IdTipoComprobanteNDeb
           ,IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere, EsDespachoImportacion
           ,CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura, AlInvocarPedidoAfectaRemito
           ,InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion)
     VALUES
           ('REPARTO-ENTRADA', 'False', 'Reparto Entrada', 'VENTAS', 1
           ,'False', 'True', 'X', 100, 'True'
           ,-1, 'SOLOPRECIOS', 'True', 'False', 'True'
           ,'False', 'Rep.Ent.', 'False', 1, 'True'
           ,NULL, 'False', 99, NULL, 0
           ,'.', 'False', 0.01, 'False', 'True'
           ,'True', 'False', 'True', 'True', 2
           ,'False', 'False', 'VENTAS', 'False', 'False'
           ,'False', 'False', 'False', NULL, NULL
           ,NULL, NULL, 'False', 'False', '', 'False'
           ,'True', NULL, 'True', 'True',
           'True', 'False', 8, 1)
GO

PRINT ''
PRINT '3. Nuevo Menu: Ventas\Registras Repartos.'
GO

IF EXISTS (SELECT Id FROM Funciones F WHERE F.Id = 'Ventas')
BEGIN

	--Inserto la pantalla nueva

	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
	 VALUES
	   ('RegistrarReparto', 'Registrar Reparto', 'Registrar Reparto', 
	    'True', 'False', 'True', 'True', 'VentasRepartos', 36, 'Eniac.Win', 'RegistrarReparto', NULL, NULL)
	;

	INSERT INTO RolesFunciones 
	              (IdRol,IdFuncion)
	SELECT IdRol,'RegistrarReparto'
      FROM RolesFunciones WHERE IdFuncion = 'FacturacionV2'
	;
    
END;

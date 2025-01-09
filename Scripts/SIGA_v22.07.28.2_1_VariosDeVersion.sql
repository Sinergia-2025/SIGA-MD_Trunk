CREATE NONCLUSTERED INDEX IX_CuentasCorrientesPagos_CodigoDeBarra ON dbo.CuentasCorrientesPagos (CodigoDeBarra) 
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_CuentasCorrientesPagos_2
	ON dbo.CuentasCorrientesPagos (IdSucursal, IdTipoComprobante2, Letra2, CentroEmisor2, NumeroComprobante2)
	WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

IF NOT EXISTS(SELECT IdTipoComprobante FROM TiposComprobantes WHERE IdTipoComprobante = 'RES-DEVTARJETA')
BEGIN

	PRINT ''
	PRINT '1. TiposComprobantes: Creo el comprobante RES-DEVTARJETA.'
	;
	INSERT INTO TiposComprobantes
			   (IdTipoComprobante, EsFiscal, Descripcion, Tipo, CoeficienteStock, GrabaLibro, EsFacturable, LetrasHabilitadas
			   ,CantidadMaximaItems, Imprime, CoeficienteValores, ModificaAlFacturar, EsFacturador, AfectaCaja, CargaPrecioActual
			   ,ActualizaCtaCte, DescripcionAbrev, PuedeSerBorrado, CantidadCopias, EsRemitoTransportista, ComprobantesAsociados
			   ,EsComercial, CantidadMaximaItemsObserv, IdTipoComprobanteSecundario, ImporteTope, IdTipoComprobanteEpson
			   ,UsaFacturacionRapida, ImporteMinimo, EsElectronico, UsaFacturacion, UtilizaImpuestos, NumeracionAutomatica
			   ,GeneraObservConInvocados, ImportaObservDeInvocados, IdPlanCuenta, EsAnticipo, EsRecibo, Grupo, EsPreElectronico
			   ,GeneraContabilidad, UtilizaCtaSecundariaProd, UtilizaCtaSecundariaCateg, IncluirEnExpensas, IdTipoComprobanteNCred
			   ,IdTipoComprobanteNDeb, IdProductoNCred, IdProductoNDeb, ConsumePedidos, EsPreFiscal, CodigoComprobanteSifere
			   ,EsDespachoImportacion, CargaDescRecActual, IdTipoComprobanteContraMovInvocar, AlInvocarPedidoAfectaFactura
			   ,AlInvocarPedidoAfectaRemito, InvocarPedidosConEstadoEspecifico, InvocaCompras, LargoMaximoNumero, NivelAutorizacion
			   ,RequiereReferenciaCtaCte, ControlaTopeConsumidorFinal, CargaDescRecGralActual, EsReciboClienteVinculado
			   ,AFIPWSIncluyeFechaVencimiento, AFIPWSEsFEC, AFIPWSRequiereReferenciaComercial, AFIPWSRequiereComprobanteAsociado
			   ,AFIPWSRequiereCBU, AFIPWSCodigoAnulacion, Orden, MarcaInvocado, PermiteSeleccionarAlicuotaIVA, ImportaObservGrales
			   ,DescripcionImpresion, InformaLibroIva, SolicitaFechaDevolucion, AFIPWSRequiereReferenciaTransferencia
			   ,ActivaTildeMercDespacha, Color, CodigoRoela)
		 VALUES
			  ('RES-DEVTARJETA', 'False', 'Resumen Dev. Tarjeta', 'COMPRAS', 0, 'True', 'False', 'X'
			   , 100, 'False', -1, NULL, 'False', 'True', 'False'
			   , 'True', 'Rs.DevTarj', 'True', 1, 'False', NULL
			   , 'True', 99, NULL, CONVERT(FLOAT,9999999)/100, '.'
			   , 'False', 0, 'False', 'True', 'True', 'True'
			   , 'False', 'False', 1, 'False', 'False', 'COMPRAS', 'False'
			   , 'True', 'False', 'False', 'False', NULL
			   , NULL, NULL, NULL, 'False', 'False', ''
			   , 'False', 'False', NULL, 'True'
			   , 'True', 'True', 'False', 8, 1
			   , 'False', 'True', 'False', 'False'
			   , NULL, 'False', 'False', 'False'
			   , 'False', 'False', 11, 'True', 'False', 'False'
			   , 'Resumen Dev. Tarjeta', 'True', 'False', 'False'
			   , 'False', NULL, '')
	;

	PRINT ''
	PRINT '2. TiposMovimientos: Habilito RES-DEVTARJETA para VARIOS.'
	;

	UPDATE TiposMovimientos
	   SET ComprobantesAsociados = ComprobantesAsociados + ',RES-DEVTARJETA'
	  WHERE IdTipoMovimiento = 'VARIOS'
	;

	PRINT ''
	PRINT '3. Impresoras: Habilito RES-DEVTARJETA para NORMAL.'
	;

	UPDATE Impresoras 
	   SET ComprobantesHabilitados = ComprobantesHabilitados + ',RES-DEVTARJETA'
	 WHERE IdImpresora = 'NORMAL'
	;

	PRINT ''
	PRINT '4. AFIPTiposComprobantesTiposCbtes: Creo Valor 99 para CITI Compras en RES-DEVTARJETA.'
	;

	INSERT INTO AFIPTiposComprobantesTiposCbtes
			   (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
		 VALUES
			   (99, 'RES-DEVTARJETA', 'X')
	;

END

GO
IF NOT EXISTS(SELECT * FROM Roles WHERE Id = 'AdmSinergia')
    INSERT INTO [dbo].[Roles] ([Id],[Nombre],[Descripcion])
				       VALUES ('AdmSinergia', 'Administradores Sinergia', 'Administradores Sinergia')
GO

MERGE INTO RolesFunciones AS D
        USING (SELECT Id, 'AdmSinergia' IdRol FROM Funciones WHERE (IdPadre IN ('Seguridad', 'Configuraciones', 'Ayuda') OR     -- Funciones dentro de los padres
                                                                    Id IN ('Seguridad', 'Configuraciones', 'Ayuda') OR          -- Padres
                                                                    Id IN ('InfProductosSinStock', 'InfChequesADepositar',      -- Alertas
                                                                           'Remitos-RemitosSinFacturar', 'InfPuntoDePedidoDeProductos',
                                                                           'InfStockMinimoDeProductos', 'FacturacionV2'  /*Vto. Certificado AFIP*/  ,
                                                                           'InconsistStockVsStockLotes', 'InconsistStockVsMovDeStock',
                                                                           'InconsistCtaCtevsCtaCtePagos', 'InconsCtaCteProvVsCtaCtePagos',
                                                                           'PlanillaDeCaja', 'OrganizarEntregasV2',
                                                                           'Pedidos-PedidosSinFacturar', 'CRMNovedades-PuedeVerAlerta',
                                                                           'CRMNovedades-PuedeVerAlerta', 'AlertaTurnos',
                                                                           'CRMNovedadesABMPROSP', 'InformeChequesPropios',
                                                                           'AlertaCambioCategoriaCliente', 'AlertaPedidosConCantidadItems',
                                                                           'AlertaPedidosSinCantidadItems', 'AlertaClientesConDeuda',
                                                                           'SincronizarOrdenesCompra')
                                                                   )) AS O
            ON D.IdFuncion = O.Id AND D.IdRol = O.IdRol
    WHEN NOT MATCHED THEN
        INSERT (IdFuncion, IdRol) VALUES (O.Id, O.IdRol)
;

MERGE INTO UsuariosRoles AS D
        USING (SELECT 'Admin' IdUsuario, 'AdmSinergia' IdRol, IdSucursal FROM Sucursales) AS O
            ON D.IdUsuario = O.IdUsuario AND D.IdRol = O.IdRol AND D.IdSucursal = O.IdSucursal
    WHEN NOT MATCHED THEN
        INSERT (IdUsuario, IdRol, IdSucursal) VALUES (O.IdUsuario, O.IdRol, O.IdSucursal)
;

DELETE UsuariosRoles WHERE IdUsuario = 'Admin' AND IdRol = 'Adm'
GO
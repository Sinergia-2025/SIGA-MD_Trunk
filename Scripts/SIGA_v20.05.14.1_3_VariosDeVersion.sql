PRINT ''
PRINT '1. Nueva Función: Liquidaciones de Tarjetas y Anular Liquidaciones de Tarjetas'
IF dbo.ExisteFuncion('Bancos') = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Nueva Función: Crear función de menu Liquidaciones de Tarjetas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('LiquidacionesTarjeta', 'Liquidaciones de Tarjetas', 'Liquidaciones de Tarjetas', 'True', 'False', 'True', 'True'
        ,'Bancos', 135, 'Eniac.Win', 'DepositosBancarios', NULL, 'LIQUIDATARJETA'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '1.2. Nueva Función: Agregar Roles a Liquidaciones de Tarjetas'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'LiquidacionesTarjeta' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

    PRINT ''
    PRINT '1.3. Nueva Función: Anular Liquidaciones de Tarjetas'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('AnularLiquidacionesTarjetas', 'Anular Liquidaciones de Tarjetas', 'Anular Liquidaciones de Tarjetas', 'True', 'False', 'True', 'True'
        ,'Bancos', 145, 'Eniac.Win', 'AnularDepositos', NULL, 'LIQUIDATARJETA'
        ,'True', 'S', 'N', 'N', 'N')

    PRINT ''
    PRINT '1.4. Nueva Función: Roles para Anular Liquidaciones de Tarjetas'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AnularLiquidacionesTarjetas' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '2. Nuevo Tipo de Comprobante: LIQUIDATARJETA'
INSERT INTO TiposComprobantes ([IdTipoComprobante]
		                      ,[EsFiscal]
		                      ,[Descripcion]
		                      ,[Tipo]
		                      ,[CoeficienteStock]
		                      ,[GrabaLibro]
		                      ,[EsFacturable]
		                      ,[LetrasHabilitadas]
		                      ,[CantidadMaximaItems]
		                      ,[Imprime]
		                      ,[CoeficienteValores]
		                      ,[ModificaAlFacturar]
		                      ,[EsFacturador]
		                      ,[AfectaCaja]
		                      ,[CargaPrecioActual]
		                      ,[ActualizaCtaCte]
		                      ,[DescripcionAbrev]
		                      ,[PuedeSerBorrado]
		                      ,[CantidadCopias]
		                      ,[EsRemitoTransportista]
		                      ,[ComprobantesAsociados]
		                      ,[EsComercial]
		                      ,[CantidadMaximaItemsObserv]
		                      ,[IdTipoComprobanteSecundario]
		                      ,[ImporteTope]
		                      ,[IdTipoComprobanteEpson]
		                      ,[UsaFacturacionRapida]
		                      ,[ImporteMinimo]
		                      ,[EsElectronico]
		                      ,[UsaFacturacion]
		                      ,[UtilizaImpuestos]
		                      ,[NumeracionAutomatica]
		                      ,[GeneraObservConInvocados]
		                      ,[ImportaObservDeInvocados]
		                      ,[IdPlanCuenta]
		                      ,[EsAnticipo]
		                      ,[EsRecibo]
		                      ,[Grupo]
		                      ,[EsPreElectronico]
		                      ,[GeneraContabilidad]
		                      ,[UtilizaCtaSecundariaProd]
		                      ,[UtilizaCtaSecundariaCateg]
		                      ,[IncluirEnExpensas]
		                      ,[IdTipoComprobanteNCred]
		                      ,[IdTipoComprobanteNDeb]
		                      ,[IdProductoNCred]
		                      ,[IdProductoNDeb]
		                      ,[ConsumePedidos]
		                      ,[EsPreFiscal]
		                      ,[CodigoComprobanteSifere]
		                      ,[EsDespachoImportacion]
		                      ,[CargaDescRecActual]
		                      ,[IdTipoComprobanteContraMovInvocar]
		                      ,[AlInvocarPedidoAfectaFactura]
		                      ,[AlInvocarPedidoAfectaRemito]
		                      ,[InvocarPedidosConEstadoEspecifico]
		                      ,[InvocaCompras]
		                      ,[LargoMaximoNumero]
		                      ,[NivelAutorizacion]
		                      ,[RequiereReferenciaCtaCte]
		                      ,[ControlaTopeConsumidorFinal]
		                      ,[CargaDescRecGralActual]
		                      ,[EsReciboClienteVinculado]
		                      ,[AFIPWSIncluyeFechaVencimiento]
		                      ,[AFIPWSEsFEC]
		                      ,[AFIPWSRequiereReferenciaComercial]
		                      ,[AFIPWSRequiereComprobanteAsociado]
		                      ,[AFIPWSRequiereCBU]
		                      ,[AFIPWSCodigoAnulacion]
		                      ,[Orden]
		                      ,[MarcaInvocado]
		                      ,[PermiteSeleccionarAlicuotaIVA]
		                      ,[ImportaObservGrales]
		                      ,[DescripcionImpresion]
		                      ,[InformaLibroIva])
		SELECT 'LIQUIDATARJETA'
		      ,[EsFiscal]
		      ,'Liquidación Tarjeta'
		      ,[Tipo]
		      ,[CoeficienteStock]
		      ,[GrabaLibro]
		      ,[EsFacturable]
		      ,[LetrasHabilitadas]
		      ,[CantidadMaximaItems]
		      ,[Imprime]
		      ,[CoeficienteValores]
		      ,[ModificaAlFacturar]
		      ,[EsFacturador]
		      ,[AfectaCaja]
		      ,[CargaPrecioActual]
		      ,[ActualizaCtaCte]
		      ,'Liq. Tarj.'
		      ,[PuedeSerBorrado]
		      ,[CantidadCopias]
		      ,[EsRemitoTransportista]
		      ,[ComprobantesAsociados]
		      ,[EsComercial]
		      ,[CantidadMaximaItemsObserv]
		      ,[IdTipoComprobanteSecundario]
		      ,[ImporteTope]
		      ,[IdTipoComprobanteEpson]
		      ,[UsaFacturacionRapida]
		      ,[ImporteMinimo]
		      ,[EsElectronico]
		      ,[UsaFacturacion]
		      ,[UtilizaImpuestos]
		      ,[NumeracionAutomatica]
		      ,[GeneraObservConInvocados]
		      ,[ImportaObservDeInvocados]
		      ,[IdPlanCuenta]
		      ,[EsAnticipo]
		      ,[EsRecibo]
		      ,[Grupo]
		      ,[EsPreElectronico]
		      ,[GeneraContabilidad]
		      ,[UtilizaCtaSecundariaProd]
		      ,[UtilizaCtaSecundariaCateg]
		      ,[IncluirEnExpensas]
		      ,[IdTipoComprobanteNCred]
		      ,[IdTipoComprobanteNDeb]
		      ,[IdProductoNCred]
		      ,[IdProductoNDeb]
		      ,[ConsumePedidos]
		      ,[EsPreFiscal]
		      ,[CodigoComprobanteSifere]
		      ,[EsDespachoImportacion]
		      ,[CargaDescRecActual]
		      ,[IdTipoComprobanteContraMovInvocar]
		      ,[AlInvocarPedidoAfectaFactura]
		      ,[AlInvocarPedidoAfectaRemito]
		      ,[InvocarPedidosConEstadoEspecifico]
		      ,[InvocaCompras]
		      ,[LargoMaximoNumero]
		      ,[NivelAutorizacion]
		      ,[RequiereReferenciaCtaCte]
		      ,[ControlaTopeConsumidorFinal]
		      ,[CargaDescRecGralActual]
		      ,[EsReciboClienteVinculado]
		      ,[AFIPWSIncluyeFechaVencimiento]
		      ,[AFIPWSEsFEC]
		      ,[AFIPWSRequiereReferenciaComercial]
		      ,[AFIPWSRequiereComprobanteAsociado]
		      ,[AFIPWSRequiereCBU]
		      ,[AFIPWSCodigoAnulacion]
		      ,[Orden]
		      ,[MarcaInvocado]
		      ,[PermiteSeleccionarAlicuotaIVA]
		      ,[ImportaObservGrales]
		      ,'Liquidación Tarjeta'
		      ,[InformaLibroIva]
		  FROM [dbo].[TiposComprobantes] WHERE IdTipoComprobante = 'DEPOSITO'

PRINT ''
PRINT '2.1. Habilitar el comprobante LIQUIDATARJETA'
UPDATE Impresoras SET
	ComprobantesHabilitados = ComprobantesHabilitados + ',LIQUIDATARJETA'
		WHERE 
			ComprobantesHabilitados LIKE '%,DEPOSITO,%'
		OR  ComprobantesHabilitados LIKE 'DEPOSITO,%'
		OR  ComprobantesHabilitados LIKE '%,DEPOSITO'



PRINT ''
PRINT '3.- Finalizar Listas de Control Inconsistentes'
IF  dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN

    UPDATE CalidadListasControlProductos SET IdEstadoCalidad = 4, Observacion = 'Cambio de Estado Automatico'

    --SELECT * FROM CalidadListasControlProductos
     WHERE IdProducto IN ('2253','2345','2511','2552','2572','2724','2726','2744','2787','2809','2810','2812','2813','2814','2816','2816R01','2819','2820','2822','2823','2824',
    '2825','2826','2829','2830','2837','2838','2839','2841','2842','2850','2856','2857','2861','2868','2869','2870','2871','2872','2873','2874')
     AND (IdEstadoCalidad = 1 or IdEstadoCalidad = 2)

END

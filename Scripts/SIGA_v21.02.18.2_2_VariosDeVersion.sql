PRINT ''
PRINT '1. Configuración URL Base Tienda Nube BAZARCELTA'
IF dbo.BaseConCuit('20250887265') = 1
BEGIN
	DECLARE @idParametro VARCHAR(MAX) = 'TIENDANUBEURLBASE'
	DECLARE @descripcionParametro VARCHAR(MAX) = 'Tienda Nube: URL Base'
	DECLARE @valorParametro VARCHAR(MAX) = 'False'
	IF dbo.BaseConCuit('20250887265') = 1
	   SET @valorParametro = 'https://api.tiendanube.com/v1/1463742/'
	
	MERGE INTO Parametros AS DEST
	        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	    WHEN MATCHED THEN
	        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	    WHEN NOT MATCHED THEN 
	        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
	;

END
GO

PRINT ''
PRINT '2. Nuevo Tipo de Comprobante para Pedidos de Tienda Nube >> PEDIDOSTN'
INSERT INTO [dbo].[TiposComprobantes]
           ([IdTipoComprobante]
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
           ,[InformaLibroIva]
           ,[SolicitaFechaDevolucion])
	 SELECT 'PEDIDOTN'
	       ,[EsFiscal]
	       ,'Pedido Tienda Nube'
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
	       ,'Pedido TN'
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
	       ,'Pedido TN'
	       ,[InformaLibroIva]
	       ,[SolicitaFechaDevolucion]
	   FROM [dbo].[TiposComprobantes] WHERE IdTipoComprobante = 'PEDIDO'
GO

PRINT ''
PRINT '3. Agrego el comprobante a las impresoras de Pedidos'
UPDATE I
       SET ComprobantesHabilitados = ComprobantesHabilitados + ',PEDIDOTN'
      FROM Impresoras I
     WHERE (I.ComprobantesHabilitados LIKE 'PEDIDO,%' OR I.ComprobantesHabilitados LIKE '%,PEDIDO,%' OR I.ComprobantesHabilitados LIKE '%,PEDIDO')
GO


PRINT '4. Agrega campos para ser usados en Pantillas de Excel'
INSERT INTO PlantillasCampos
  (IdPlantilla,IdCampo,OrdenColumna)
SELECT P.IdPlantilla, C.IdCampo, NULL
  FROM Campos C
  CROSS JOIN Plantillas P
  LEFT JOIN PlantillasCampos PC ON PC.IdCampo = C.IdCampo AND PC.IdPlantilla = P.IdPlantilla
 WHERE 1 = 1
   AND PC.IdPlantilla IS NULL


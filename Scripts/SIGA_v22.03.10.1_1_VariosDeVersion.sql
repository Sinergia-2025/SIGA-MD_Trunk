PRINT ''
PRINT '1.1. Tabla Proveedores: Agrandar campos Correo'
ALTER TABLE Proveedores ALTER COLUMN CorreoElectronico varchar(150) null
ALTER TABLE Proveedores ALTER COLUMN CorreoAdministrativo varchar(150) null


IF dbo.BaseConCuit('33631312379') = 1 
BEGIN
--Inserta UM
INSERT INTO SIGA.dbo.UnidadesDeMedidas 
SELECT ume_Cod, ume_Desc, 0, 0  FROM SBDAMETA.dbo.UniMed 
where ume_Cod <> 'UN' AND ume_Cod <> 'KG' AND ume_Cod <> 'LT'

--Actualiza Productos UM
UPDATE Productos
SET Productos.IdUnidadDeMedida = VD.sdcume_Cod1
FROM Productos as P 
INNER JOIN SBDAMETA.dbo.Vista_OCDetalle AS VD
ON P.IdProducto = VD.sdcart_CodGen

--Insert OCN
INSERT [dbo].[TiposComprobantes] ([IdTipoComprobante], [EsFiscal], [Descripcion], [Tipo], [CoeficienteStock], 
[GrabaLibro], [EsFacturable], [LetrasHabilitadas], [CantidadMaximaItems], [Imprime], [CoeficienteValores], 
[ModificaAlFacturar], [EsFacturador], [AfectaCaja], [CargaPrecioActual], [ActualizaCtaCte], [DescripcionAbrev], 
[PuedeSerBorrado], [CantidadCopias], [EsRemitoTransportista], [ComprobantesAsociados], [EsComercial], 
[CantidadMaximaItemsObserv], [IdTipoComprobanteSecundario], [ImporteTope], [IdTipoComprobanteEpson], 
[UsaFacturacionRapida], [ImporteMinimo], [EsElectronico], [UsaFacturacion], [UtilizaImpuestos], [NumeracionAutomatica],
[GeneraObservConInvocados], [ImportaObservDeInvocados], [IdPlanCuenta], [EsAnticipo], [EsRecibo], [Grupo], 
[EsPreElectronico], [GeneraContabilidad], [UtilizaCtaSecundariaProd], [UtilizaCtaSecundariaCateg], [IncluirEnExpensas], 
[IdTipoComprobanteNCred], [IdTipoComprobanteNDeb], [IdProductoNCred], [IdProductoNDeb], [ConsumePedidos], [EsPreFiscal],
[CodigoComprobanteSifere], [EsDespachoImportacion], [CargaDescRecActual], [IdTipoComprobanteContraMovInvocar], 
[AlInvocarPedidoAfectaFactura], [AlInvocarPedidoAfectaRemito], [InvocarPedidosConEstadoEspecifico], [InvocaCompras], 
[LargoMaximoNumero], [NivelAutorizacion], [RequiereReferenciaCtaCte], [ControlaTopeConsumidorFinal], 
[CargaDescRecGralActual], [EsReciboClienteVinculado], [AFIPWSIncluyeFechaVencimiento], [AFIPWSEsFEC], 
[AFIPWSRequiereReferenciaComercial], [AFIPWSRequiereComprobanteAsociado], [AFIPWSRequiereCBU], [AFIPWSCodigoAnulacion], 
[Orden], [MarcaInvocado], [PermiteSeleccionarAlicuotaIVA], [ImportaObservGrales], [DescripcionImpresion],
[InformaLibroIva], [SolicitaFechaDevolucion], [AFIPWSRequiereReferenciaTransferencia], [ActivaTildeMercDespacha], 
[Color]) 
VALUES (N'OCN', 0, N'Orden Compra N', N'PEDIDOSPROV', 0, 0, 1, N'X', 100, 1, 1, NULL, 0, 0, 1, 0, N'OCN', 1, 1, 
0, NULL, 0, 99, NULL, CAST(99999999.00 AS Decimal(14, 2)), N'.', 0, CAST(0.01 AS Decimal(10, 2)), 0, 1, 1, 0, 0, 0, 
2, 0, 0, N'COMPRAS', 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 0, 0, N'', 0, 1, NULL, 1, 1, 1, 0, 8, 1, 0, 1, 1, 0, NULL,
0, 0, 0, 0, 0, 10, 1, 0, 0, N'Orden Compra N', 0, 0, 0, 0, NULL)

END;

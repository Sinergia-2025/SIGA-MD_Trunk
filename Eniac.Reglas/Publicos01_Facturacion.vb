#Region "Option/Imports"
Option Explicit On
Option Strict On
#End Region
Partial Class Publicos
   Public Class Facturacion
      Public Shared ReadOnly Property FacturacionAgrupaCantidadesProductos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONAGRUPACANTIDADESPRODUCTOS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturarSinStockControlaNoAfectaStock() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURARSINSTOCKCONTROLANOAFECTASTOCK, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionControlaDNIClienteConsumidorFinal() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCLIENTECONTROLADNICF, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionControlaTopeCF() As Decimal
         Get
            Return Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCONTROLATOPECF.ToString(), "1000"))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionVisualizaSemaforoUtilidad() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONVISUALIZASEMAFOROUTILIDAD, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionRangoFechaFiltroInvocarPedidos() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRANGOFECHAFILTROINVOCARPEDIDOS, "12"))
         End Get
      End Property

      '-- REQ-33360.- -------------------------------------------------------------
      Public Shared ReadOnly Property MantieneVendedorInvocados() As String
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONINVOCADOSMANTIENEVENDEDOR, Entidades.Publicos.VendedorComprobanteInvocado.NO.ToString())
         End Get
      End Property
      '----------------------------------------------------------------------------
      Public Shared ReadOnly Property CotizacionDolarComprobanteInvocado() As Entidades.Publicos.CotizacionDolarComprobanteInvocado
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COTIZACIONDOLARCOMPROBANTEINVOCADO, Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO.ToString()).
                        StringToEnum(Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO)
         End Get
      End Property
      Public Shared ReadOnly Property CotizacionDolarPedidoInvocado() As Entidades.Publicos.CotizacionDolarComprobanteInvocado
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COTIZACIONDOLARPEDIDOINVOCADO, Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO.ToString()).
                        StringToEnum(Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO)
         End Get
      End Property

      Public Shared ReadOnly Property CotizacionDolarComprobantePesosInvocado() As Entidades.Publicos.CotizacionDolarComprobanteInvocado
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COTIZACIONDOLARCOMPROBANTEPESOSINVOCADO, Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO.ToString()).
                        StringToEnum(Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO)
         End Get
      End Property
      Public Shared ReadOnly Property CotizacionDolarPedidoPesosInvocado() As Entidades.Publicos.CotizacionDolarComprobanteInvocado
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.COTIZACIONDOLARPEDIDOPESOSINVOCADO, Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO.ToString()).
                        StringToEnum(Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO)
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionCantidadEnterosEnCotizacionDolar() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCANTIDADENTEROSENCOTIZACIONDOLAR, "3")
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionCantidadDecimalesEnCotizacionDolar() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCANTIDADDECIMALESENCOTIZACIONDOLAR, "2")
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionCantidadEnterosEnCantidad() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCANTIDADENTEROSENCANTIDAD, 4I)
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaNumeroComprobante() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICANUMEROCOMPROBANTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaDescripcionProducto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPCIONPRODUCTO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaDescriProdCantidad() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPRODCANTIDAD, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaPrecioProducto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICAPRECIOPRODUCTO, Boolean.TrueString))
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionModificaDescRecGralPorc() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRECGRALPORC, Boolean.TrueString))
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionModificaDescRecProductoPorMonto() As Boolean
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRECPRODUCTOPORMONTO.ToString(), Boolean.FalseString) = Boolean.TrueString
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaDescriAcumulaProducto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODDESCACUMULAPRODUCTOS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSaldoCtaCteIncluyeCh3ros() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSALDOCTACTEINCLUYECH3ROS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaDescripSolicitaKilos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPSOLICITAKILOS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaDescripSolicitaPrecio() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRIPSOLICITAPRECIO.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaDescRecProducto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICADESCRECPRODUCTO, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionModificaListaDePrecios() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMODIFICALISTADEPRECIOS, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionInvocarInvocador() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONINVOCARINVOCADOR, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionInvocarDeOtroCliente() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONINVOCARDEOTROCLIENTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaVendedor() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITAVENDEDOR, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaVendedorPorClave() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITAVENDEDORPORCLAVE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionTarjetasValidaCuponLote() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONTARJETASVALIDACUPONLOTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaComprobante() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITACOMPROBANTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSeleccionManualLoteProducto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSELECCIONLOTEMANUAL, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionGrabaLibroNoFuerzaConsFinal() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONGRABALIBRONOFUERZACONSFINAL, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionRemitoTranspCalculaBultos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONREMITOTRANSPCALCULABULTOS, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionRemitoTranspUtilizaLote() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONREMITOTRANSPUTILIZALOTE, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionAvisaProductosEnCero() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONAVISAPRODUCTOSENCERO, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FactPorCtaOrden() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPORCUENTAYORDEN, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property SaldoContemplaHora() As Boolean
         Get
            Return SaldoContemplaHora(actual.Sucursal)
         End Get
      End Property
      Public Shared ReadOnly Property SaldoContemplaHora(s As Entidades.Sucursal) As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(s, Entidades.Parametro.Parametros.FACTURACIONSALDOCONTEMPLAHORA, False)
         End Get
      End Property

      Public Shared ReadOnly Property SaldoTomaActualAlImprimir() As Boolean
         Get
            Return SaldoTomaActualAlImprimir(actual.Sucursal)
         End Get
      End Property
      Public Shared ReadOnly Property SaldoTomaActualAlImprimir(s As Entidades.Sucursal) As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(s, Entidades.Parametro.Parametros.SALDOTOMAACTUALALIMPRIMIR, True)
         End Get
      End Property

      Public Shared ReadOnly Property DescuentoMaximo() As Decimal
         Get
            Return Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.DESCUENTOMAXIMO, "0"))
         End Get
      End Property

      Public Shared ReadOnly Property PermiteModificarClienteFacturacion() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITEMODIFICARCLIENTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionDiasInvocacionComprobantes() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDIASINVOCACIONCOMPROBANTES, "7"))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionPermiteCantidadNegativa() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITECANTIDADNEGATIVA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionPermiteCantidadNegativaAcumulada() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITECANTIDADNEGATIVAACUMULADA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionPermitePosicionarNombreProducto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPOSICIONNOMBREPRODUCTO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ProductoCodigoBarraPrecioRespetaEtiqueta() As Boolean
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PRODUCTOCODIGOBARRAPRECIORESPETAETIQUETA, Boolean.FalseString) = Boolean.TrueString
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionDetallaChequesyTarjetas() As Boolean
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDETALLACHEQUESYTARJETAS, Boolean.TrueString) = Boolean.TrueString
         End Get
      End Property

      Public Shared ReadOnly Property CantMaxItemsDetallaChequesyTarjetas() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONITEMSDETALLACHEQUESYTARJETAS, "3"))
         End Get
      End Property

      Public Shared ReadOnly Property FacturarPedidoSeleccionado() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURARPEDIDOSELECCIONADO, Boolean.FalseString))
         End Get
      End Property


      Public Shared ReadOnly Property FacturacionIgnorarUltimoDigitoCB() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONIGNORARULTIMODIGITOCB, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionProductoModificaDescripcionCargaPrecioActual() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPRODUCTOMODIFDESCRIPCARGAPRECIOACTUAL, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionPermiteFacturarEnOtrasMonedas() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITEFACTURARENOTRASMONEDAS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionCoeficienteNegativoRecuperaPrecioUltimaVenta() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCOEFNEGATIVORECUPERAPRECIOULTIMAVENTA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionPermiteCambiarClienteVinculado() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITECAMBIARCLIENTEVINCULADO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaNumeroDeComprobante() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITANUMERODECOMPROBANTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaFormaDePago() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITAFORMADEPAGO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaListaDePrecios() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITALISTADEPRECIOS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionCtaCteSolicitaDiaFijo() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCTACTESOLICITADIAFIJO, Boolean.FalseString))
         End Get
      End Property

      '-- REQ-38566.- -------------------------------------------------------------------------------------------------------------------------------------
      Public Shared ReadOnly Property FacturacionCantidadPorDefecto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCANTIDADDEFECTO, Boolean.FalseString))
         End Get
      End Property
      '-- REQ-36082.- -------------------------------------------------------------------------------------------------------------------------------------
      Public Shared ReadOnly Property FacturacionUtilizaCanje() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONUTILIZACANJE, Boolean.FalseString))
         End Get
      End Property
      '----------------------------------------------------------------------------------------------------------------------------------------------------

      Public Shared ReadOnly Property FacturacionDescuentoImpIntIgualado() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDESCUENTOIMPINTIGUALADO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionDescuentoRecargo2CargaManual() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDESCUENTORECARGO2CARGAMANUAL, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionRelacionaCabecera() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONINVOCADOSRELACIONACABECERA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionDescuentosAgrupaCantidadesPorRubro() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDESCUENTOSAGRUPACANTIDADESPORRUBRO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionInvocarPedidosDeOtrasSucursales() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONINVOCARPEDIDOSDEOTRASSUCURSALES, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturarSinStock() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURARSINSTOCK, "PERMITIR")
         End Get
      End Property
      Public Shared ReadOnly Property ModificarPrecioPorDebajoPrecioLista() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.MODIFICARPRECIOPORDEBAJOPL, "PERMITIR")
         End Get
      End Property

      Public Shared ReadOnly Property PorcentajePermitidoPorDebajoPrecioLista() As Decimal
         Get
            Return Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PORCENTAJEPORDEBAJOPL, "100"))
         End Get
      End Property

      Public Shared ReadOnly Property ModificarPrecioPorArribaPrecioLista() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.MODIFICARPRECIOPORARRIBAPL, "PERMITIR")
         End Get
      End Property

      Public Shared ReadOnly Property PorcentajePermitidoPorArribaPrecioLista() As Decimal
         Get
            Return Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PORCENTAJEPORARRIBAPL, "100000"))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSemaforoCalculoMuestra() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSEMAFOROCALCULOMUESTRA, Entidades.Publicos.SemaforoCalculoMuestra.Rentabilidad.ToString())
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMuestraProvHabitual() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMUESTRAPROVHABITUAL, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionContadoEsEnPesos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCONTADOESENPESOS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionTicketIncluyeRecargoGeneral() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONTICKETINCLUYERECARGOGENERAL, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionPresupuestoIncluyeRecargoGeneral() As Boolean
         Get
            Return FacturacionPresupuestoIncluyeRecargoGeneral(actual.Sucursal)
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionPresupuestoIncluyeRecargoGeneral(sucursal As Entidades.Sucursal) As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(sucursal, Entidades.Parametro.Parametros.FACTURACIONPRESUPUESTOINCLUYERECARGOGENERAL, False)
         End Get
      End Property

      Public Shared ReadOnly Property GrabaLibroNoIncluyeRecargoGeneral() As Boolean
         Get
            Return GrabaLibroNoIncluyeRecargoGeneral(actual.Sucursal)
         End Get
      End Property
      Public Shared ReadOnly Property GrabaLibroNoIncluyeRecargoGeneral(sucursal As Entidades.Sucursal) As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(sucursal, Entidades.Parametro.Parametros.GRABALIBRONOINCLUYERECARGOGENERAL, False)
         End Get
      End Property

      Public Shared ReadOnly Property PermitirComprobFechaNumAnterior() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCOMPROBFECHNUMANTERIOR, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PermitirComprobFechaFutura() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCOMPROBFECHAFUTURA, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMantieneElCliente() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMANTIENECLIENTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMantieneElClienteDefault() As Long
         Get
            Return Long.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMANTIENEELCLIENTEDEFAULT, "0"))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMantieneElComprobante() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMANTIENECOMPROBANTE, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property VentasPrecioCosto() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VENTASPRECIOCOSTO, "ACTUAL")
         End Get
      End Property

      Public Shared ReadOnly Property VentasPrecioVenta() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VENTASPRECIOVENTA, "ACTUAL")
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionIgnorarPCdeCaja() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONIGNORARPCDECAJA, Boolean.FalseString))
         End Get
      End Property


      Public Shared ReadOnly Property FacturacionOfreceCalcularVuelto() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONOFRECECALCULARVUELTO, Boolean.FalseString)
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionVendedorEnTitulo() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONVENDEDORENTITULO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionCajaEnTitulo() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCAJAENTITULO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionOrdenDeTitulo() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONORDENDETITULO, Entidades.Publicos.FacturacionOrdenesDeTitulo.VENDEDORCAJA.ToString())
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionOrdenDeColor() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONORDENDECOLOR,
                                                      String.Format("{0},{1},{2}",
                                                                    Entidades.Publicos.FacturacionOrdenesDeColor.VENDEDOR.ToString(),
                                                                    Entidades.Publicos.FacturacionOrdenesDeColor.CAJA.ToString(),
                                                                    Entidades.Publicos.FacturacionOrdenesDeColor.TIPOCOMPROBANTE.ToString()))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionOrdenDeColor1() As Entidades.Publicos.FacturacionOrdenesDeColor
         Get
            Dim orden = FacturacionOrdenDeColor().Split(","c)
            Return orden(0).StringToEnum(Entidades.Publicos.FacturacionOrdenesDeColor.VENDEDOR)
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionOrdenDeColor2() As Entidades.Publicos.FacturacionOrdenesDeColor
         Get
            Dim orden = FacturacionOrdenDeColor().Split(","c)
            Return If(orden.Length > 1,
                      orden(1).StringToEnum(Entidades.Publicos.FacturacionOrdenesDeColor.CAJA),
                      Entidades.Publicos.FacturacionOrdenesDeColor.CAJA)
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionOrdenDeColor3() As Entidades.Publicos.FacturacionOrdenesDeColor
         Get
            Dim orden = FacturacionOrdenDeColor().Split(","c)
            Return If(orden.Length > 2,
                      orden(2).StringToEnum(Entidades.Publicos.FacturacionOrdenesDeColor.TIPOCOMPROBANTE),
                      Entidades.Publicos.FacturacionOrdenesDeColor.TIPOCOMPROBANTE)
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionVisualizaPrecioCosto As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONVISUALIZAPRECIOCOSTO, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionVisualizaOrden As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONVISUALIZAORDEN, False)
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionRapidaVisualizaPrecioCosto As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAVISUALIZAPRECIOCOSTO, String.Empty)
         End Get
      End Property


      Public Shared ReadOnly Property FacturacionEnvioMailCopiaOculta As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONENVIOMAILCOPIAOCULTA, String.Empty)
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionAsuntoEnvioMasivoEmail As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONASUNTOENVIOMASIVOEMAIL, "{0} - Comprobantes desde el {2:dd/MM/yyyy} al {3:dd/MM/yyyy}")
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMonedaPorDefecto() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMONEDAPORDEFECTO, 1I)
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMostrarPrecioConIVA() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMOSTRARPRECIOCONIVA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMostrarPrecioUnitario() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMOSTRARPRECIOUNITARIO, Boolean.TrueString))
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionPermiteCobroTarjetaAutomatico() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITECOBROTARJETAAUTOMATICO, Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionTarjetaAutomatico() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONTARJETAAUTOMATICO, "0"))
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionBancoTarjetaAutomatico() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONBANCOTARJETAAUTOMATICO, "0"))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMostrarDesc1() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMOSTRARDESC1, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMostrarDesc2() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMOSTRARDESC2, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionMostrarKilos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMOSTRARKILOS, Boolean.TrueString))
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionMostrarStock() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMOSTRARSTOCK, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaVendedorAlAbrir() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITAVENDEDORALABRIR, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionSolicitaCajaAlAbrir() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONSOLICITACAJAALABRIR, Boolean.FalseString))
         End Get
      End Property
      '-- REG-32597.- ----------
      Public Shared ReadOnly Property FacturacionConservaOrdenProductos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCONSERVAORDENPRODUCTO, Boolean.TrueString))
         End Get
      End Property
      Public Shared ReadOnly Property FacturacionPermiteAplicarSaldoCtaCte() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITEAPLICARSALDOCTACTE, False)
         End Get
      End Property
      '-- REG-32661.- ----------
      Public Shared ReadOnly Property FacturacionRapidaConservaOrdenProductos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDACONSERVAORDENPRODUCTO, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property VisualizarComprobanteVentaAsumeImpresion() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.VENTASVISUALIZARCOMPROBANTEASUMEIMPRESION, True)
         End Get
      End Property


      Public Shared ReadOnly Property FacturacionCantidadCaracteresObservaciones() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCANTIDADCARACTERESOBSERVACIONES, 100)
         End Get
      End Property

      Public Class Redondeo
         Public Shared ReadOnly Property FacturacionDecimalesRedondeoEnPrecio() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENPRECIO, "2"))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionDecimalesGrabarDetalleEnPrecio() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESGRABARDETALLEENPRECIO, "4"))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionDecimalesEnPrecio() As Integer
            Get
               Return FacturacionDecimalesEnPrecio(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionDecimalesEnPrecio(sucursal As Entidades.Sucursal) As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(sucursal, Entidades.Parametro.Parametros.FACTURACIONDECIMALESENPRECIO, 2I)
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionDecimalesRedondeoEnCantidad() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENCANTIDAD, "2"))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionDecimalesEnDescRec() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESENDESCREC, "2"))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionDecimalesEnTotalXProducto() As Integer
            Get
               Return FacturacionDecimalesEnTotalXProducto(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionDecimalesEnTotalXProducto(sucursal As Entidades.Sucursal) As Integer
            Get
               Return ParametrosCache.Instancia.GetValorPD(sucursal, Entidades.Parametro.Parametros.FACTURACIONDECIMALESENTOTALXPRODUCTO, 2I)
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionDecimalesMostrarEnCantidad() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESMOSTRARENCANTIDAD, "2"))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionDecimalesRedondeoEnTamano() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENTAMANO, "2"))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionDecimalesMostrarEnTamano() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESMOSTRARENTAMANO, "2"))
            End Get
         End Property



      End Class


      Public Class Rapida
         Public Shared ReadOnly Property FacturacionRapidaAbrirCajaComprobanteNoFiscal() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONABRIRCAJACOMPNOFISCAL, Boolean.FalseString))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaReemplazarComprobantes() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAREEMPLAZARCOMP, Boolean.FalseString))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionRapidaModificaDescRecGralPorc() As Boolean
            Get
               Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMODIFICADESCRECGRALPORC.ToString(), Boolean.TrueString) = Boolean.TrueString
            End Get
         End Property

         Public Shared ReadOnly Property PermiteModificarClienteFacturacionRapida() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAPERMITEMODIFICARCLIENTE, True)
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaMuestraFotoProducto() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMUESTRAFOTOPRODUCTO, Boolean.FalseString))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaMuestraComprobante() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMUESTRACOMPROBANTE, Boolean.TrueString))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionRapidaSolicitaVendedorPorDefecto() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDASOLICITAVENDEDORPORDEFECTO, Boolean.FalseString))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionRapidaSolicitaTipoComprobantePorDefecto() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDASOLICITATIPOCOMPROBANTEPORDEFECTO, Boolean.FalseString))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaMuestraPrUnitario() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARPRUNITARIO, Boolean.FalseString))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaMuestraListaPrecio() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARLISTAPRECIO, Boolean.FalseString))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaRecalcularEfectivoAlCargarTarjeta() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDARECALCULAREFECTIVOALCARGARTARJETA, Boolean.FalseString))
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaSolicitaCantidad() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDASOLICITACANTIDAD, Boolean.FalseString))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionRapidaAgrupaProductos As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAAGRUPAPRODUCTOS, False)
            End Get
         End Property

         Public Shared ReadOnly Property FacturacionRapidaMostrarDesc1() As Boolean
            Get
               Return Boolean.Parse(New Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARDESC1, Boolean.TrueString))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionRapidaMostrarDesc2() As Boolean
            Get
               Return Boolean.Parse(New Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONRAPIDAMOSTRARDESC2, Boolean.TrueString))
            End Get
         End Property

      End Class

      Public Class Impresion
         Public Shared ReadOnly Property FacturacionDetallaChequesyTarjetas() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDETALLACHEQUESYTARJETAS, Boolean.FalseString))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionImpresionFiscalSincronica() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONIMPRESIONFISCALSINCRONICA, Boolean.TrueString))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionImprimeTicketNoFiscalCtaCte() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONIMPRIMETICKETNOFISCAL, False)
            End Get
         End Property
         Public Shared ReadOnly Property ImpresionComprobantesMiraOrdenProductos() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONIMPRESIONORDENPRODUCTOS, False)
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionimprimeReciboVentasCtaCte() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONIMPRIMERECIBOVENTASCTACTE, False)
            End Get
         End Property
         Public Shared ReadOnly Property ImpresionMasivaOrdenInverso() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.IMPRESIONMASIVAORDENINVERSO, False)
            End Get
         End Property
         Public Shared ReadOnly Property MuestraVendedorImpresion() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMUESTRAVENDEDORIMPRESION, True)
            End Get
         End Property
         Public Shared ReadOnly Property MuestraVendedorImpresion(s As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(s, Entidades.Parametro.Parametros.FACTURACIONMUESTRAVENDEDORIMPRESION, True)
            End Get
         End Property
         Public Shared ReadOnly Property MuestraSaldoImpresion() As Boolean
            Get
               Return MuestraSaldoImpresion(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property MuestraSaldoImpresion(s As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(s, Entidades.Parametro.Parametros.FACTURACIONMUESTRASALDOCTACTEIMPRESION, False)
            End Get
         End Property
         Public Shared ReadOnly Property MuestraSaldoImpresionUnificado() As Boolean
            Get
               Return MuestraSaldoImpresionUnificado(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property MuestraSaldoImpresionUnificado(s As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(s, Entidades.Parametro.Parametros.FACTURACIONMUESTRASALDOCTACTEIMPRESIONUNIFICADO, False)
            End Get
         End Property
         Public Shared ReadOnly Property ImpresionMuestraTotalKilos() As Boolean
            Get
               Return ImpresionMuestraTotalKilos(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property ImpresionMuestraTotalKilos(s As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(s, Entidades.Parametro.Parametros.IMPRESIONMUESTRATOTALKILOS, False)
            End Get
         End Property
         Public Shared ReadOnly Property ImpresionMuestraTotalProductos() As Boolean
            Get
               Return ImpresionMuestraTotalProductos(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property ImpresionMuestraTotalProductos(s As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(s, Entidades.Parametro.Parametros.IMPRESIONMUESTRATOTALPRODUCTOS, False)
            End Get
         End Property
         Public Shared ReadOnly Property VentasImpresionVisualizaNrosSerie() As Boolean
            Get
               Return VentasImpresionVisualizaNrosSerie(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property VentasImpresionVisualizaNrosSerie(sucursal As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(sucursal, Entidades.Parametro.Parametros.VENTASIMPRESIONVISNROSERIE, True)
            End Get
         End Property
         Public Shared ReadOnly Property VentasImpresionMuestraLoteObservacion() As Boolean
            Get
               Return VentasImpresionMuestraLoteObservacion(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property VentasImpresionMuestraHoraVenta() As Boolean
            Get
               Return VentasImpresionMuestraHoraVenta(actual.Sucursal)
            End Get
         End Property
         Public Shared ReadOnly Property VentasImpresionMuestraHoraVenta(sucursal As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(sucursal, Entidades.Parametro.Parametros.VENTASIMPRESIONMUESTRAHORAVENTA, False)
            End Get
         End Property
         Public Shared ReadOnly Property VentasImpresionImprimeComponentes() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(actual.Sucursal, Entidades.Parametro.Parametros.VENTASIMPRESIONIMPRIMECOMPONENTES, False)
            End Get
         End Property
         Public Shared ReadOnly Property VentasImpresionImprimeCantidadComponentes() As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(actual.Sucursal, Entidades.Parametro.Parametros.VENTASIMPRESIONIMPRIMECANTCOMPONENTES, False)
            End Get
         End Property
         '-- REQ-34813.- ---------------------------------------------------------------------------
         Public Shared ReadOnly Property VentasImpresionMuestraValidezPresupuesto() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VENTASIMPRESIONMUESTRAVALIDEZPRESUPUESTO, Boolean.TrueString))
            End Get
         End Property
         '------------------------------------------------------------------------------------------
         Public Shared ReadOnly Property VentasImpresionMuestraLoteObservacion(sucursal As Entidades.Sucursal) As Boolean
            Get
               Return ParametrosCache.Instancia.GetValorPD(sucursal, Entidades.Parametro.Parametros.VENTASIMPRESIONMUESTRALOTEOBSERVACION, False)
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionImpresionMargenIzquierdo() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMARGENIZQUIERDO.ToString(), "5"))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionImpresionCantidadLineasSeparacion() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VENTASIMPRESIONIMPRIMECANTLINEASSEPARACION.ToString(), "5"))
            End Get
         End Property
         Public Shared ReadOnly Property FacturacionImpresionMargenDerecho() As Integer
            Get
               Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMARGENDERECHO.ToString(), "1"))
            End Get
         End Property

      End Class
      Public Class FacturacionElectronica
         Public Shared ReadOnly Property FacturacionElectronicaSincronica() As Boolean
            Get
               Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTELECTSINCRONICA, Boolean.TrueString))
            End Get
         End Property

      End Class
      Public Class Exportacion

         Public Shared ReadOnly Property ExportarVentasConFormato As ExportacionVentasEnum
            Get
               Dim valor = ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.EXPORTARVENTASCONFORMATO, ExportacionVentasEnum.PDA.ToString())
               Return valor.StringToEnum(ExportacionVentasEnum.PDA)
            End Get
         End Property

         Public Shared ReadOnly Property UbicacionArchivoPDA() As String
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.UBICACIONARCHIVOSPDA, String.Empty)
            End Get
         End Property

         Public Shared ReadOnly Property FormatoArchivoExportacion() As String
            Get
               Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.FORMATONOMBREARCHIVOEXPORTACION, String.Empty)
            End Get
         End Property

      End Class
   End Class
End Class
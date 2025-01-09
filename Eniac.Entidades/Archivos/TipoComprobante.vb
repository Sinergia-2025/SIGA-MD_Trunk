<Serializable(), DebuggerDisplay("{DebuggerDisplayForClass,nq}")>
<Description("TipoComprobante")>
Public Class TipoComprobante
   Inherits Entidad

   Public Enum Columnas
      IdTipoComprobante
      EsFiscal
      Descripcion
      Tipo
      CoeficienteStock
      GrabaLibro
      InformaLibroIVA
      EsFacturable
      LetrasHabilitadas
      CantidadMaximaItems
      Imprime
      CoeficienteValores
      ModificaAlFacturar
      EsFacturador
      AfectaCaja
      CargaPrecioActual
      ActualizaCtaCte
      DescripcionAbrev
      PuedeSerBorrado
      CantidadCopias
      EsRemitoTransportista
      ComprobantesAsociados
      EsComercial
      CantidadMaximaItemsObserv
      IdTipoComprobanteSecundario
      ImporteTope
      IdTipoComprobanteEpson
      UsaFacturacionRapida
      ImporteMinimo
      EsElectronico
      UtilizaImpuestos
      NumeracionAutomatica
      GeneraObservConInvocados
      IdPlanCuenta
      ImportaObservDeInvocados
      ImportaObservGrales
      IdContraComprobante
      EsRecibo
      EsAnticipo
      EsPreElectronico
      GeneraContabilidad
      UtilizaCtaSecundariaProd
      UtilizaCtaSecundariaCateg
      IncluirEnExpensas
      IdTipoComprobanteNCred
      IdTipoComprobanteNDeb
      IdProductoNCred
      IdProductoNDeb
      ConsumePedidos
      EsPreFiscal
      CodigoComprobanteSifere
      EsDespachoImportacion
      CargaDescRecActual
      IdTipoComprobanteContraMovInvocar
      AlInvocarPedidoAfectaFactura
      AlInvocarPedidoAfectaRemito
      InvocarPedidosConEstadoEspecifico
      InvocaCompras
      LargoMaximoNumero
      NivelAutorizacion
      RequiereReferenciaCtaCte
      ControlaTopeConsumidorFinal
      CargaDescRecGralActual
      EsReciboClienteVinculado
      AFIPWSIncluyeFechaVencimiento
      AFIPWSEsFEC
      AFIPWSRequiereReferenciaComercial
      AFIPWSRequiereComprobanteAsociado
      AFIPWSRequiereCBU
      AFIPWSCodigoAnulacion
      AFIPWSRequiereReferenciaTransferencia
      Orden
      MarcaInvocado
      PermiteSeleccionarAlicuotaIVA
      DescripcionImpresion
      Grupo
      SolicitaFechaDevolucion
      ActivaTildeMercDespacha
      Color
      CodigoRoela
      ClaseComprobante
      SimulaPercepciones
      SolicitaInformeCalidad
   End Enum

   Public Enum Tipos
      VENTAS
      BANCO
      COMPRAS
      CTACTE
      PAGO
      PAGOPROV
      FACT
      eFACT
      'Se quitaron para que no queden referencias explicitas, debe utilizars elas propiedades "EsRecibo" o "EsAnticipo"
      'ANTICIPO
      'ANTICIPOPROV
      RECIBO         'Reemplezar por Parametros.
      RECIBOPROV
      'MINUTA
      'MINUTAPROV
      PEDIDOSCLIE
      PRESUPCLIE
      ORDENCOMPRAPROV
      PEDIDOSPROV
      PRESUPPROV
      PRODUCCION
      eNCRED
      eNDEB
      NCRED
      NDEB
      REQCOMPRAS
      CALIDAD
      '------------------------------------------------------------
   End Enum

   Public Enum ClasesComprobante
      <Description("Sin definir")> SinDefinir
      NOTADEB
      FICHAS
      LIQUIDATARJETA
   End Enum

   Public Enum ValoresFijosIdTipoComprobante As Integer
      <Description("(Selección Multiple)")> SeleccionMultiple = -1
      <Description("(Todos)")> Todos = -2
   End Enum

   Public Sub New()
      NivelAutorizacion = 1

      _IdTipoComprobante = String.Empty
      _Descripcion = String.Empty
      _LetrasHabilitadas = String.Empty
      _CantidadMaximaItems = 0
      _ActualizaCtaCte = False
      _cantidadCopias = 1
      _CantidadMaximaItemsObserv = 0
      _ImporteTope = 0
      _ImporteMinimo = 0
   End Sub
   Public Sub New(idTipoComprobante As String)
      Me.New()
      _IdTipoComprobante = idTipoComprobante
   End Sub

#Region "Propiedades"

   Public Property IdTipoComprobante As String
   Public Property EsFiscal As Boolean
   Public Property Descripcion As String
   Public Property Tipo As String
   Public Property CoeficienteStock As Integer
   Public Property GrabaLibro As Boolean
   Public Property InformaLibroIVA As Boolean
   Public Property EsFacturable As Boolean
   Public Property LetrasHabilitadas As String
   Public Property CantidadMaximaItems As Integer
   Public Property Imprime As Boolean
   Public Property CoeficienteValores As Integer
   Public Property ModificaAlFacturar As String
   Public Property EsFacturador As Boolean
   Public Property AfectaCaja As Boolean
   Public Property CargaPrecioActual As Boolean
   Public Property ActualizaCtaCte As Boolean
   Public Property DescripcionAbrev As String
   Public Property PuedeSerBorrado As Boolean
   Public Property CantidadCopias As Integer
   Public Property EsRemitoTransportista As Boolean
   Public Property ComprobantesAsociados As String
   Public Property EsComercial As Boolean
   Public Property CantidadMaximaItemsObserv As Integer
   Public Property IdTipoComprobanteSecundario As String
   Public Property ImporteTope As Decimal
   Public Property IdTipoComprobanteEpson As String
   Public Property UsaFacturacionRapida As Boolean
   Public Property UsaFacturacion As Boolean
   Public Property ImporteMinimo As Decimal
   Public Property EsElectronico As Boolean
   Public Property UtilizaImpuestos As Boolean
   Public Property NumeracionAutomatica As Boolean
   Public Property GeneraObservConInvocados As Boolean
   Public Property ImportaObservDeInvocados As Boolean
   Public Property ImportaObservGrales As Boolean
   Public Property IdPlanCuenta As Integer
   Public Property EsRecibo As Boolean
   Public Property EsAnticipo As Boolean
   Public Property EsPreElectronico As Boolean
   Public Property GeneraContabilidad As Boolean
   Public Property Grupo As String

   Public Property UtilizaCtaSecundariaProd As Boolean
   Public Property UtilizaCtaSecundariaCateg As Boolean

   Public Property IncluirEnExpensas As Boolean

   Public Property IdTipoComprobanteNCred As String
   Public Property IdTipoComprobanteNDeb As String

   Public Property IdProductoNCred As String
   Public Property IdProductoNDeb As String

   Public Property ConsumePedidos As Boolean

   Public Property EsPreFiscal As Boolean
   Public Property CodigoComprobanteSifere As String
   Public Property EsDespachoImportacion As Boolean
   Public Property CargaDescRecActual As Boolean
   Public Property IdTipoComprobanteContraMovInvocar As String
   Public Property AlInvocarPedidoAfectaFactura As Boolean
   Public Property AlInvocarPedidoAfectaRemito As Boolean
   Public Property InvocarPedidosConEstadoEspecifico As Boolean
   Public Property InvocaCompras As Boolean
   Public Property LargoMaximoNumero As Short
   Public Property RequiereReferenciaCtaCte As Boolean
   Public Property NivelAutorizacion As Short
   Public Property ControlaTopeConsumidorFinal As Boolean
   Public Property CargaDescRecGralActual As Boolean
   Public Property EsReciboClienteVinculado As Boolean
   Public Property AFIPWSIncluyeFechaVencimiento As Boolean?
   Public Property AFIPWSEsFEC As Boolean
   Public Property AFIPWSRequiereReferenciaComercial As Boolean
   Public Property AFIPWSRequiereComprobanteAsociado As Boolean
   Public Property AFIPWSRequiereCBU As Boolean
   Public Property AFIPWSCodigoAnulacion As Boolean
   Public Property AFIPWSRequiereReferenciaTransferencia As Boolean
   Public Property Orden As Integer
   Public Property MarcaInvocado As Boolean
   Public Property PermiteSeleccionarAlicuotaIVA As Boolean
   Public Property DescripcionImpresion As String
   Public Property SolicitaFechaDevolucion As Boolean
   Public Property ActivaTildeMercDespacha As Boolean

   Public Property Color As Integer?
   Public Property CodigoRoela As String
   Public Property ClaseComprobante As ClasesComprobante
   Public Property SimulaPercepciones As Boolean

   Public Property SolicitaInformeCalidad As Boolean

   Private _productos As List(Of TipoComprobanteProducto)
   Public Property Productos As List(Of TipoComprobanteProducto)
      Get
         If _productos Is Nothing Then _productos = New List(Of TipoComprobanteProducto)()
         Return _productos
      End Get
      Set(value As List(Of TipoComprobanteProducto))
         _productos = value
      End Set
   End Property

#End Region

   <DebuggerBrowsable(DebuggerBrowsableState.Never)>
   Private ReadOnly Property DebuggerDisplayForClass() As String
      Get
         Return String.Format("{0} - {1} / Tipo: {2} / GrabaLibro: {3}", IdTipoComprobante, Descripcion, Tipo, GrabaLibro)
      End Get
   End Property


   Public Overridable Function GetCopia() As Entidades.TipoComprobante
      Dim copia = New TipoComprobante()
      With copia
         .ActualizaCtaCte = _ActualizaCtaCte
         .AfectaCaja = _AfectaCaja
         .CantidadCopias = _CantidadCopias
         .CantidadMaximaItems = _CantidadMaximaItems
         .CantidadMaximaItemsObserv = _CantidadMaximaItemsObserv
         .CargaPrecioActual = _CargaPrecioActual
         .CoeficienteStock = _CoeficienteStock
         .CoeficienteValores = _CoeficienteValores
         .ComprobantesAsociados = _ComprobantesAsociados
         .Descripcion = _Descripcion
         .DescripcionAbrev = _DescripcionAbrev
         .EsComercial = _EsComercial
         .EsElectronico = _EsElectronico
         .EsFacturable = _EsFacturable
         .EsFacturador = _EsFacturador
         .EsFiscal = _EsFiscal
         .EsRemitoTransportista = _EsRemitoTransportista
         .GeneraObservConInvocados = _GeneraObservConInvocados
         .IdPlanCuenta = _IdPlanCuenta
         .ImportaObservDeInvocados = _ImportaObservDeInvocados
         .ImportaObservGrales = _ImportaObservGrales
         .GrabaLibro = _GrabaLibro
         .InformaLibroIVA = _InformaLibroIVA
         .IdSucursal = IdSucursal
         .IdTipoComprobante = _IdTipoComprobante
         .IdTipoComprobanteEpson = _IdTipoComprobanteEpson
         .IdTipoComprobanteSecundario = _IdTipoComprobanteSecundario
         .ImporteMinimo = _ImporteMinimo
         .ImporteTope = _ImporteTope
         .Imprime = _Imprime
         .LetrasHabilitadas = _LetrasHabilitadas
         .ModificaAlFacturar = _ModificaAlFacturar
         .NumeracionAutomatica = _NumeracionAutomatica
         .Password = Password
         .PuedeSerBorrado = _PuedeSerBorrado
         .Tipo = _Tipo
         .UsaFacturacionRapida = _UsaFacturacionRapida
         .Usuario = Usuario
         .UtilizaImpuestos = _UtilizaImpuestos
         .EsRecibo = _EsRecibo
         .EsAnticipo = _EsAnticipo
         .EsPreElectronico = _EsPreElectronico
         .GeneraContabilidad = _GeneraContabilidad
         .UtilizaCtaSecundariaProd = _UtilizaCtaSecundariaProd
         .UtilizaCtaSecundariaCateg = _UtilizaCtaSecundariaCateg
         .IncluirEnExpensas = _IncluirEnExpensas
         .IdTipoComprobanteNCred = _IdTipoComprobanteNCred
         .IdTipoComprobanteNDeb = _IdTipoComprobanteNDeb
         .IdProductoNCred = _IdProductoNCred
         .IdProductoNDeb = _IdProductoNDeb
         .ConsumePedidos = _ConsumePedidos
         .CodigoComprobanteSifere = _CodigoComprobanteSifere
         .EsPreFiscal = _EsPreFiscal
         .CargaDescRecActual = _CargaDescRecActual
         .IdTipoComprobanteContraMovInvocar = _IdTipoComprobanteContraMovInvocar
         .AlInvocarPedidoAfectaFactura = _AlInvocarPedidoAfectaFactura
         .AlInvocarPedidoAfectaRemito = _AlInvocarPedidoAfectaRemito
         .InvocarPedidosConEstadoEspecifico = _InvocarPedidosConEstadoEspecifico
         .InvocaCompras = _InvocaCompras
         .LargoMaximoNumero = _LargoMaximoNumero
         .RequiereReferenciaCtaCte = _RequiereReferenciaCtaCte
         .NivelAutorizacion = _NivelAutorizacion
         .CargaDescRecGralActual = _CargaDescRecGralActual
         .EsReciboClienteVinculado = _EsReciboClienteVinculado

         .AFIPWSIncluyeFechaVencimiento = _AFIPWSIncluyeFechaVencimiento
         .AFIPWSEsFEC = _AFIPWSEsFEC
         .AFIPWSRequiereReferenciaComercial = _AFIPWSRequiereReferenciaComercial
         .AFIPWSRequiereComprobanteAsociado = _AFIPWSRequiereComprobanteAsociado
         .AFIPWSRequiereCBU = _AFIPWSRequiereCBU
         .AFIPWSCodigoAnulacion = _AFIPWSCodigoAnulacion
         .AFIPWSRequiereReferenciaTransferencia = _AFIPWSRequiereReferenciaTransferencia
         .Orden = _Orden
         .MarcaInvocado = _MarcaInvocado
         .PermiteSeleccionarAlicuotaIVA = _PermiteSeleccionarAlicuotaIVA
         .DescripcionImpresion = DescripcionImpresion
         '-- REQ-30773 --
         .ActivaTildeMercDespacha = _ActivaTildeMercDespacha
         .Color = Color
         .ClaseComprobante = _ClaseComprobante
         .SolicitaInformeCalidad = SolicitaInformeCalidad
      End With
      Return copia
   End Function
End Class
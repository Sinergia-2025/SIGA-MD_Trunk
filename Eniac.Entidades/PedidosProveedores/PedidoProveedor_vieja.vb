Option Explicit On
Option Strict On

Imports System.Text
Imports Eniac.Entidades

<Serializable()> _
Public Class PedidoProveedor
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _tipoComprobante As Entidades.TipoComprobante
   Private _letraComprobante As String = String.Empty
   Private _centroEmisor As Short
   Private _numeroComprobante As Long
   Private _fecha As Date
   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Private _vendedor As Empleado
   Private _importeBruto As Decimal
   Private _descuentoRecargo As Decimal
   Private _descuentoRecargoPorc As Decimal
   Private _subtotal As Decimal
   Private _importeTotal As Decimal
   Private _ventasProductos As System.Collections.Generic.List(Of Entidades.VentaProducto)
   Private _impresora As Entidades.Impresora
   Private _formaPago As Entidades.VentaFormaPago
   Private _periodo As Entidades.VentaPeriodo
   Private _observacion As String
   Private _facturables As System.Collections.Generic.List(Of Entidades.Venta)
   Private _idEstadoComprobante As String = String.Empty
   Private _tipoComprobanteFact As Entidades.TipoComprobante
   Private _letraFact As String = String.Empty
   Private _centroEmisorFact As Integer
   Private _numeroComprobanteFact As Long
   Private _NumeroPlanilla As Integer
   Private _NumeroMovimiento As Integer
   Private _kilos As Decimal
   Private _comisionVendedor As Decimal
   Private _bultos As Integer
   Private _valorDeclarado As Decimal
   Private _transportista As Entidades.Transportista
   Private _numeroLote As Long
   Private _ventasObservaciones As System.Collections.Generic.List(Of Entidades.VentaObservacion)
   Private _chequesRechazados As List(Of Entidades.Cheque)
   Private _totalImpuestos As Decimal
   Private _cantidadInvocados As Integer
   Private _cantidadLotes As Integer
   Private _ventasProductosLotes As System.Collections.Generic.List(Of Entidades.VentaProductoLote)
   'vml 22/09/12
   Private _grabaAutomatico As Boolean
   Private _esMultipleRubro As Boolean
   Private _tablaContabilidad As DataTable
   Private _proveedor As Entidades.Proveedor

#End Region

#Region "Propiedades"

   'vml 19/3/13
   Public Property Proveedor() As Entidades.Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Entidades.Proveedor()
         End If
         Return Me._proveedor
      End Get
      Set(ByVal value As Entidades.Proveedor)
         Me._proveedor = value
      End Set
   End Property

   Private _importeTarjetas As Decimal
   Public Property ImporteTarjetas() As Decimal
      Get
         Return _importeTarjetas
      End Get
      Set(ByVal value As Decimal)
         _importeTarjetas = value
      End Set
   End Property

   Private _importeTickets As Decimal
   Public Property ImporteTickets() As Decimal
      Get
         Return _importeTickets
      End Get
      Set(ByVal value As Decimal)
         _importeTickets = value
      End Set
   End Property

   Private _importePesos As Decimal
   Public Property ImportePesos() As Decimal
      Get
         Return _importePesos
      End Get
      Set(ByVal value As Decimal)
         _importePesos = value
      End Set
   End Property

   Private _cheques As List(Of Entidades.Cheque)
   Public Property Cheques() As List(Of Entidades.Cheque)
      Get
         If Me._cheques Is Nothing Then
            Me._cheques = New List(Of Entidades.Cheque)()
         End If
         Return _cheques
      End Get
      Set(ByVal value As List(Of Entidades.Cheque))
         _cheques = value
      End Set
   End Property

   Private _tarjetas As List(Of Entidades.VentaTarjeta)
   Public Property Tarjetas() As List(Of Entidades.VentaTarjeta)
      Get
         If Me._tarjetas Is Nothing Then
            Me._tarjetas = New List(Of Entidades.VentaTarjeta)()
         End If
         Return _tarjetas
      End Get
      Set(ByVal value As List(Of Entidades.VentaTarjeta))
         _tarjetas = value
      End Set
   End Property

   Private _cuentaCorriente As Entidades.CuentaCorriente
   Public Property CuentaCorriente() As Entidades.CuentaCorriente
      Get
         If Me._cuentaCorriente Is Nothing Then
            Me._cuentaCorriente = New Entidades.CuentaCorriente()
         End If
         Return _cuentaCorriente
      End Get
      Set(ByVal value As Entidades.CuentaCorriente)
         _cuentaCorriente = value
      End Set
   End Property

   Public Property LetraComprobante() As String
      Get
         Return Me._letraComprobante
      End Get
      Set(ByVal value As String)
         Me._letraComprobante = value
      End Set
   End Property

   Public Property Facturables() As Generic.List(Of Entidades.Venta)
      Get
         If Me._facturables Is Nothing Then
            Me._facturables = New Generic.List(Of Entidades.Venta)
         End If
         Return Me._facturables
      End Get
      Set(ByVal value As Generic.List(Of Entidades.Venta))
         Me._facturables = value
      End Set
   End Property

   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         Return Me._categoriaFiscal
      End Get
      Set(ByVal value As Entidades.CategoriaFiscal)
         Me._categoriaFiscal = value
      End Set
   End Property

   Public Property Vendedor() As Empleado
      Get
         Return Me._vendedor
      End Get
      Set(ByVal value As Empleado)
         Me._vendedor = value
      End Set
   End Property

   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property

   Public Property FormaPago() As Entidades.VentaFormaPago
      Get
         Return Me._formaPago
      End Get
      Set(ByVal value As Entidades.VentaFormaPago)
         Me._formaPago = value
      End Set
   End Property

   Public Property Periodo() As Entidades.VentaPeriodo
      Get
         If Me._periodo Is Nothing Then
            Me._periodo = New Entidades.VentaPeriodo()
         End If
         Return Me._periodo
      End Get
      Set(ByVal value As Entidades.VentaPeriodo)
         Me._periodo = value
      End Set
   End Property

   Public Property Impresora() As Entidades.Impresora
      Get
         If Me._impresora Is Nothing Then
            Me._impresora = New Entidades.Impresora()
         End If
         Return _impresora
      End Get
      Set(ByVal value As Entidades.Impresora)
         _impresora = value
      End Set
   End Property

   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property

   Public Property CentroEmisor() As Short
      Get
         Return Me._centroEmisor
      End Get
      Set(ByVal value As Short)
         Me._centroEmisor = value
      End Set
   End Property

   Public Property NumeroComprobante() As Long
      Get
         Return Me._numeroComprobante
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobante = value
      End Set
   End Property

   Public Property Fecha() As Date
      Get
         Return Me._fecha
      End Get
      Set(ByVal value As Date)
         Me._fecha = value
      End Set
   End Property

   Public Property ImporteBruto() As Decimal
      Get
         Return _importeBruto
      End Get
      Set(ByVal value As Decimal)
         _importeBruto = value
      End Set
   End Property

   Public Property DescuentoRecargo() As Decimal
      Get
         Return _descuentoRecargo
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargo = value
      End Set
   End Property

   Public Property DescuentoRecargoPorc() As Decimal
      Get
         Return _descuentoRecargoPorc
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc = value
      End Set
   End Property

   Public Property Subtotal() As Decimal
      Get
         Return _subtotal
      End Get
      Set(ByVal value As Decimal)
         _subtotal = value
      End Set
   End Property

   Public Property ImporteTotal() As Decimal
      Get
         Return _importeTotal

      End Get
      Set(ByVal value As Decimal)
         _importeTotal = value
      End Set
   End Property

   Public Property VentasProductos() As Generic.List(Of Entidades.VentaProducto)
      Get
         If Me._ventasProductos Is Nothing Then
            Me._ventasProductos = New Generic.List(Of Entidades.VentaProducto)
         End If
         Return Me._ventasProductos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.VentaProducto))
         Me._ventasProductos = value
      End Set
   End Property

   Private _ventasImpuestos As List(Of Entidades.VentaImpuesto)
   Public Property VentasImpuestos() As List(Of Entidades.VentaImpuesto)
      Get
         If Me._ventasImpuestos Is Nothing Then
            Me._ventasImpuestos = New List(Of Entidades.VentaImpuesto)()
         End If
         Return _ventasImpuestos
      End Get
      Set(ByVal value As List(Of Entidades.VentaImpuesto))
         _ventasImpuestos = value
      End Set
   End Property

   Private _impuestosVarios As List(Of Entidades.VentaImpuesto)
   Public Property ImpuestosVarios() As List(Of Entidades.VentaImpuesto)
      Get
         If Me._impuestosVarios Is Nothing Then
            Me._impuestosVarios = New List(Of Entidades.VentaImpuesto)()
         End If
         Return Me._impuestosVarios
      End Get
      Set(ByVal value As List(Of Entidades.VentaImpuesto))
         Me._impuestosVarios = value
      End Set
   End Property

   'Public ReadOnly Property TotalImpuestos() As Decimal
   '   Get
   '      Dim val As Decimal = 0
   '      For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
   '         val += vi.Importe
   '      Next
   '      Return val
   '   End Get
   'End Property

   Public Property IdEstadoComprobante() As String
      Get
         Return Me._idEstadoComprobante
      End Get
      Set(ByVal value As String)
         Me._idEstadoComprobante = value
      End Set
   End Property

   Public Property TipoComprobanteFact() As Entidades.TipoComprobante
      Get
         Return _tipoComprobanteFact
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobanteFact = value
      End Set
   End Property

   Public Property LetraFact() As String
      Get
         Return Me._letraFact
      End Get
      Set(ByVal value As String)
         Me._letraFact = value
      End Set
   End Property

   Public Property CentroEmisorFact() As Integer
      Get
         Return Me._centroEmisorFact
      End Get
      Set(ByVal value As Integer)
         Me._centroEmisorFact = value
      End Set
   End Property

   Public Property NumeroComprobanteFact() As Long
      Get
         Return Me._numeroComprobanteFact
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobanteFact = value
      End Set
   End Property

   Public Property NumeroPlanilla() As Integer
      Get
         Return _NumeroPlanilla
      End Get
      Set(ByVal value As Integer)
         _NumeroPlanilla = value
      End Set
   End Property

   Public Property NumeroMovimiento() As Integer
      Get
         Return _NumeroMovimiento
      End Get
      Set(ByVal value As Integer)
         _NumeroMovimiento = value
      End Set
   End Property

   Public Property Kilos() As Decimal
      Get
         Return _kilos
      End Get
      Set(ByVal value As Decimal)
         _kilos = value
      End Set
   End Property

   Public Property ComisionVendedor() As Decimal
      Get
         Return Me._comisionVendedor
      End Get
      Set(ByVal value As Decimal)
         Me._comisionVendedor = value
      End Set
   End Property

   Public Property Bultos() As Integer
      Get
         Return _bultos
      End Get
      Set(ByVal value As Integer)
         _bultos = value
      End Set
   End Property

   Public Property ValorDeclarado() As Decimal
      Get
         Return _valorDeclarado
      End Get
      Set(ByVal value As Decimal)
         _valorDeclarado = value
      End Set
   End Property

   Public Property Transportista() As Entidades.Transportista
      Get
         If Me._transportista Is Nothing Then
            Me._transportista = New Entidades.Transportista()
         End If
         Return Me._transportista
      End Get
      Set(ByVal value As Entidades.Transportista)
         Me._transportista = value
      End Set
   End Property

   Public Property NumeroLote() As Long
      Get
         Return Me._numeroLote
      End Get
      Set(ByVal value As Long)
         Me._numeroLote = value
      End Set
   End Property

   Public Property VentasObservaciones() As Generic.List(Of Entidades.VentaObservacion)
      Get
         If Me._ventasObservaciones Is Nothing Then
            Me._ventasObservaciones = New Generic.List(Of Entidades.VentaObservacion)
         End If
         Return Me._ventasObservaciones
      End Get
      Set(ByVal value As Generic.List(Of Entidades.VentaObservacion))
         Me._ventasObservaciones = value
      End Set
   End Property

   Public Property ChequesRechazados() As List(Of Entidades.Cheque)
      Get
         If Me._chequesRechazados Is Nothing Then
            Me._chequesRechazados = New List(Of Entidades.Cheque)
         End If
         Return _chequesRechazados
      End Get
      Set(ByVal value As List(Of Entidades.Cheque))
         Me._chequesRechazados = value
      End Set
   End Property

   Public Property TotalImpuestos() As Decimal
      Get
         Return Me._totalImpuestos
      End Get
      Set(ByVal value As Decimal)
         Me._totalImpuestos = value
      End Set
   End Property

   Public Property CantidadInvocados() As Integer
      Get
         Return Me._cantidadInvocados
      End Get
      Set(ByVal value As Integer)
         Me._cantidadInvocados = value
      End Set
   End Property

   Public Property CantidadLotes() As Integer
      Get
         Return Me._cantidadLotes
      End Get
      Set(ByVal value As Integer)
         Me._cantidadLotes = value
      End Set
   End Property

   Public Property VentasProductosLotes() As Generic.List(Of Entidades.VentaProductoLote)
      Get
         If Me._VentasProductosLotes Is Nothing Then
            Me._VentasProductosLotes = New Generic.List(Of Entidades.VentaProductoLote)
         End If
         Return Me._VentasProductosLotes
      End Get
      Set(ByVal value As Generic.List(Of Entidades.VentaProductoLote))
         Me._VentasProductosLotes = value
      End Set
   End Property

   Private _afipCAE As Entidades.AFIPCAE
   Public Property AFIPCAE() As Entidades.AFIPCAE
      Get
         If _afipCAE Is Nothing Then
            Me._afipCAE = New Entidades.AFIPCAE()
         End If
         Return _afipCAE
      End Get
      Set(ByVal value As Entidades.AFIPCAE)
         _afipCAE = value
      End Set
   End Property

   Private _afipIdTipoComprobante As Integer
   Public Property AFIPIdTipoComprobante() As Integer
      Get
         Return _afipIdTipoComprobante
      End Get
      Set(ByVal value As Integer)
         _afipIdTipoComprobante = value
      End Set
   End Property

   Private _utilidad As Decimal
   Public Property Utilidad() As Decimal
      Get
         Return Me._utilidad
      End Get
      Set(ByVal value As Decimal)
         Me._utilidad = value
      End Set
   End Property

   Private _fechaTransmisionAFIP As DateTime
   Public Property FechaTransmisionAFIP() As DateTime
      Get
         Return Me._fechaTransmisionAFIP
      End Get
      Set(ByVal value As DateTime)
         Me._fechaTransmisionAFIP = value
      End Set
   End Property

   Private _cotizacionDolar As Decimal
   Public Property CotizacionDolar() As Decimal
      Get
         Return Me._cotizacionDolar
      End Get
      Set(ByVal value As Decimal)
         Me._cotizacionDolar = value
      End Set
   End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return _idCaja
      End Get
      Set(ByVal value As Integer)
         _idCaja = value
      End Set
   End Property


   'vml 22/09/12

   Public Property grabaAutomatico() As Boolean
      Get
         Return _grabaAutomatico
      End Get
      Set(ByVal value As Boolean)
         _grabaAutomatico = value
      End Set
   End Property

   Public Property esMultipleRubro() As Boolean
      Get
         Return _esMultipleRubro
      End Get
      Set(ByVal value As Boolean)
         _esMultipleRubro = value
      End Set
   End Property
   'vml 22/09/12
   Public Property tablaContabilidad() As DataTable
      Get
         Return _tablaContabilidad
      End Get
      Set(ByVal value As DataTable)
         _tablaContabilidad = value
      End Set
   End Property

   Public Property NumeroOrdenCompra As Long


#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return Me.TipoComprobante.IdTipoComprobante
      End Get
   End Property

   Public ReadOnly Property TipoComprobanteDescripcion() As String
      Get
         Return Me.TipoComprobante.Descripcion
      End Get
   End Property

   Public ReadOnly Property ImporteCheques() As Decimal
      Get
         Dim val As Decimal = 0
         For Each ch As Entidades.Cheque In Me.Cheques
            val += ch.Importe
         Next
         Return val
      End Get
   End Property

   ''' <summary>
   ''' Es el total de la suma de los impuestos que son IVAs.
   ''' </summary>
   ''' <value></value>
   ''' <returns>La suma del total de IVAs</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalIVA() As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
               val += vi.Importe
            End If
         Next
         Return val
      End Get
   End Property

   Public ReadOnly Property TotalIVA(ByVal alicuota As Decimal) As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
               If vi.Alicuota = alicuota Then
                  val += vi.Importe
               End If
            End If
         Next
         Return val
      End Get
   End Property

   ''' <summary>
   ''' Es el total de la suma de los impuestos que son IVAs que tiene IVA igual a Cero
   ''' </summary>
   ''' <value></value>
   ''' <returns>La suma del total de importes Exentos</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalImporteExento() As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
               If vi.Alicuota = 0 Then
                  val += vi.Importe
               End If
            End If
         Next
         Return val
      End Get
   End Property

   ''' <summary>
   ''' Es el total de la suma de los impuestos que no son IVAs
   ''' </summary>
   ''' <value></value>
   ''' <returns>La suma del total de Impuestos que no son IVAs</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalTributos() As Decimal
      Get
         Dim val As Decimal = 0
         For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
            If vi.TipoImpuesto.IdTipoImpuesto <> TipoImpuesto.Tipos.IVA Then
               val += vi.Importe
            End If
         Next
         Return val
      End Get
   End Property

   Public Enum Concepto
      Productos = 1
      Servicios = 2
      ProductosyServicios = 3
   End Enum

   Public ReadOnly Property ConceptoDelComprobante() As Concepto
      Get
         Dim producto As Boolean = False
         Dim servicio As Boolean = False
         For Each pro As Entidades.VentaProducto In Me.VentasProductos
            If pro.Producto.EsServicio Then
               servicio = True
            Else
               producto = True
            End If
         Next
         If producto Then
            If servicio Then
               Return Concepto.ProductosyServicios
            Else
               Return Concepto.Productos
            End If
         Else
            If servicio Then
               Return Concepto.Servicios
            Else
               Return Nothing
            End If
         End If
      End Get
   End Property

   Public ReadOnly Property ImporteACtaCte() As Decimal
      Get
         Return Me.ImporteTotal - (Me.ImportePesos + Me.ImporteTarjetas + Me.ImporteTickets + Me.ImporteCheques)
      End Get
   End Property

#End Region

End Class

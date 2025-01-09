<Serializable()> _
Public Class OrdenProduccion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroOrdenProduccion
      FechaOrdenProduccion
      IdCliente
      Observacion
      IdUsuario
      DescuentoRecargo
      DescuentoRecargoPorc
      IdVendedor
      IdFormasPago
      IdTransportista
      CotizacionDolar
      IdTipoComprobanteFact
      ImporteBruto
      SubTotal
      TotalImpuestos
      TotalImpuestoInterno
      ImporteTotal
      IdEstadoVisita
      NumeroOrdenCompra
   End Enum

#Region "Campos"

#End Region

#Region "Propiedades"


   Public Property TipoComprobante() As Entidades.TipoComprobante

   Private _letraComprobante As String = String.Empty
   Public Property LetraComprobante() As String
      Get
         'Si no fue seteado de la venta, tomo el del Cliente
         If String.IsNullOrEmpty(Me._letraComprobante) AndAlso Cliente IsNot Nothing AndAlso Cliente.CategoriaFiscal IsNot Nothing Then
            Me._letraComprobante = Me.Cliente.CategoriaFiscal.LetraFiscal
         End If
         Return Me._letraComprobante
      End Get
      Set(ByVal value As String)
         Me._letraComprobante = value
      End Set
   End Property

   Public Property CentroEmisor() As Short
   Public Property NumeroOrdenProduccion() As Long

   Public Property Fecha() As Date

   Public Property Observacion() As String
   Public Property IdUsuario() As String

   Public Property DescuentoRecargo() As Decimal
   Public Property DescuentoRecargoPorc() As Decimal

   Private _cliente As Entidades.Cliente
   Public Property Cliente() As Entidades.Cliente
      Get
         If Me._cliente Is Nothing Then
            Me._cliente = New Entidades.Cliente()
         End If
         Return Me._cliente
      End Get
      Set(ByVal value As Entidades.Cliente)
         Me._cliente = value
      End Set
   End Property

   Public Property Vendedor() As Empleado
   Public Property FormaPago() As Entidades.VentaFormaPago

   Private _transportista As Entidades.Transportista
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

   Public Property TipoComprobanteFact() As Entidades.TipoComprobante

   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If Me._categoriaFiscal Is Nothing AndAlso Cliente IsNot Nothing Then
            Me._categoriaFiscal = Me.Cliente.CategoriaFiscal
         End If
         Return Me._categoriaFiscal
      End Get
      Set(ByVal value As Entidades.CategoriaFiscal)
         Me._categoriaFiscal = value
      End Set
   End Property

   Private _impresora As Entidades.Impresora
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

   Public Property CotizacionDolar() As Decimal
   Public Property ImporteBruto() As Decimal
   Public Property SubTotal() As Decimal
   Public Property TotalImpuestos() As Decimal
   Public Property TotalImpuestoInterno() As Decimal
   Public Property ImporteTotal() As Decimal
   Public Property EstadoVisita() As EstadoVisita
   Public Property NumeroOrdenCompra As Long

   Private _OrdenesProduccionProductos As System.Collections.Generic.List(Of Entidades.OrdenProduccionProducto)
   Public Property OrdenesProduccionProductos() As Generic.List(Of Entidades.OrdenProduccionProducto)
      Get
         If Me._OrdenesProduccionProductos Is Nothing Then
            Me._OrdenesProduccionProductos = New Generic.List(Of Entidades.OrdenProduccionProducto)()
         End If
         Return Me._OrdenesProduccionProductos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.OrdenProduccionProducto))
         Me._OrdenesProduccionProductos = value
      End Set
   End Property

   Private _ordenesProduccionObservaciones As List(Of Entidades.OrdenProduccionObservacion)
   Public Property OrdenesProduccionObservaciones() As List(Of Entidades.OrdenProduccionObservacion)
      Get
         If Me._ordenesProduccionObservaciones Is Nothing Then
            Me._ordenesProduccionObservaciones = New List(Of Entidades.OrdenProduccionObservacion)()
         End If
         Return Me._ordenesProduccionObservaciones
      End Get
      Set(ByVal value As List(Of Entidades.OrdenProduccionObservacion))
         Me._ordenesProduccionObservaciones = value
      End Set
   End Property
#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get

         Return If(TipoComprobante Is Nothing, String.Empty, TipoComprobante.IdTipoComprobante)
      End Get
   End Property

   Public ReadOnly Property TipoComprobanteDescripcion() As String
      Get
         Return If(TipoComprobante Is Nothing, String.Empty, TipoComprobante.Descripcion)
      End Get
   End Property

   Public ReadOnly Property IdEmpleado() As Integer
      Get
         If Vendedor Is Nothing Then Return 0
         Return Vendedor.IdEmpleado
      End Get
   End Property


   Public ReadOnly Property IdFormaPago() As Integer?
      Get
         If Vendedor Is Nothing Then Return Nothing
         Return FormaPago.IdFormasPago
      End Get
   End Property

   Public ReadOnly Property IdTransportista() As Integer?
      Get
         If Transportista Is Nothing Then Return Nothing
         Return Transportista.idTransportista
      End Get
   End Property

   Public ReadOnly Property IdTipoComprobanteFact() As String
      Get
         Return If(TipoComprobanteFact Is Nothing, String.Empty, TipoComprobanteFact.IdTipoComprobante)
      End Get
   End Property

   Public ReadOnly Property IdEstadoVisita() As Integer
      Get
         If EstadoVisita Is Nothing Then EstadoVisita = New EstadoVisita()
         Return Me.EstadoVisita.IdEstadoVisita
      End Get
   End Property

   Public ReadOnly Property NombreEstadoVisita() As String
      Get
         If EstadoVisita Is Nothing Then EstadoVisita = New EstadoVisita()
         Return Me.EstadoVisita.NombreEstadoVisita
      End Get
   End Property

   '' <summary>
   '' Es el total de la suma de los impuestos que son IVAs.
   '' </summary>
   '' <value></value>
   '' <returns>La suma del total de IVAs</returns>
   '' <remarks></remarks>
   'Public ReadOnly Property TotalIVA() As Decimal
   '    Get
   '        Dim val As Decimal = 0
   '        For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
   '        If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
   '           val += vi.Importe
   '        End If
   '        Next
   '        Return val
   '    End Get
   'End Property

   'Public ReadOnly Property TotalIVA(ByVal alicuota As Decimal) As Decimal
   '    Get
   '        Dim val As Decimal = 0
   '        For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
   '        If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
   '           If vi.Alicuota = alicuota Then
   '              val += vi.Importe
   '           End If
   '        End If
   '        Next
   '        Return val
   '    End Get
   'End Property

   '' <summary>
   '' Es el total de la suma de los impuestos que son IVAs que tiene IVA igual a Cero
   '' </summary>
   '' <value></value>
   '' <returns>La suma del total de importes Exentos</returns>
   '' <remarks></remarks>
   'Public ReadOnly Property TotalImporteExento() As Decimal
   '    Get
   '        Dim val As Decimal = 0
   '        For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
   '        If vi.TipoImpuesto.IdTipoImpuesto = TipoImpuesto.Tipos.IVA Then
   '           If vi.Alicuota = 0 Then
   '              val += vi.Importe
   '           End If
   '        End If
   '        Next
   '        Return val
   '    End Get
   'End Property

   '' <summary>
   '' Es el total de la suma de los impuestos que no son IVAs
   '' </summary>
   '' <value></value>
   '' <returns>La suma del total de Impuestos que no son IVAs</returns>
   '' <remarks></remarks>
   'Public ReadOnly Property TotalTributos() As Decimal
   '    Get
   '        Dim val As Decimal = 0
   '        For Each vi As Entidades.VentaImpuesto In Me.VentasImpuestos
   '        If vi.TipoImpuesto.IdTipoImpuesto <> TipoImpuesto.Tipos.IVA Then
   '           val += vi.Importe
   '        End If
   '        Next
   '        Return val
   '    End Get
   'End Property

   'Public Enum Concepto
   '   Productos = 1
   '   Servicios = 2
   '   ProductosyServicios = 3
   'End Enum

   'Public ReadOnly Property ConceptoDelComprobante() As Concepto
   '   Get
   '      Dim producto As Boolean = False
   '      Dim servicio As Boolean = False
   '      For Each pro As Entidades.VentaProducto In Me.ProductosProductos
   '         If pro.Producto.EsServicio Then
   '            servicio = True
   '         Else
   '            producto = True
   '         End If
   '      Next
   '      If producto Then
   '         If servicio Then
   '            Return Concepto.ProductosyServicios
   '         Else
   '            Return Concepto.Productos
   '         End If
   '      Else
   '         If servicio Then
   '            Return Concepto.Servicios
   '         Else
   '            Return Nothing
   '         End If
   '      End If
   '   End Get
   'End Property

#End Region

   Public Function Copiar() As OrdenProduccion
      Return Clonar(Me)
   End Function

End Class
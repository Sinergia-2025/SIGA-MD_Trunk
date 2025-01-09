<Serializable()>
Public Class PedidoProveedor
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroPedido

      IdProveedor
      FechaPedido
      Observacion
      IdUsuario
      DescuentoRecargo
      DescuentoRecargoPorc
      IdComprador
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
      'Kilos
      FechaAutorizacion
      FechaReprogramacion
      Idmoneda

   End Enum

#Region "Propiedades"

   Public Property TipoComprobante() As Entidades.TipoComprobante

   Private _letraComprobante As String = String.Empty
   Public Property LetraComprobante() As String
      Get
         'Si no fue seteado de el pedido, tomo el del Proveedor
         If String.IsNullOrEmpty(Me._letraComprobante) AndAlso Proveedor IsNot Nothing AndAlso Proveedor.CategoriaFiscal IsNot Nothing Then
            Me._letraComprobante = Me.Proveedor.CategoriaFiscal.LetraFiscal
         End If
         Return Me._letraComprobante
      End Get
      Set(ByVal value As String)
         Me._letraComprobante = value
      End Set
   End Property

   Public Property CentroEmisor() As Short
   Public Property NumeroPedido() As Long

   Private _proveedor As Entidades.Proveedor
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


   Public Property Fecha() As Date

   Public Property Observacion() As String
   Public Property IdUsuario() As String

   Public Property DescuentoRecargo() As Decimal
   Public Property DescuentoRecargoPorc() As Decimal

   Public Property Comprador() As Empleado
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
         If Me._categoriaFiscal Is Nothing AndAlso Proveedor IsNot Nothing Then
            Me._categoriaFiscal = Me.Proveedor.CategoriaFiscal
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
   Public Property Utilidad As Decimal

   'Public Property Kilos As Decimal

   Private _pedidosProductos As System.Collections.Generic.List(Of Entidades.PedidoProductoProveedor)
   Public Property PedidosProductos() As Generic.List(Of Entidades.PedidoProductoProveedor)
      Get
         If Me._pedidosProductos Is Nothing Then
            Me._pedidosProductos = New Generic.List(Of Entidades.PedidoProductoProveedor)()
         End If
         Return Me._pedidosProductos
      End Get
      Set(ByVal value As Generic.List(Of Entidades.PedidoProductoProveedor))
         Me._pedidosProductos = value
      End Set
   End Property

   'Esto lo comentamos hasta que se implemente ProveedorContacto
   ''Private _contactos As List(Of PedidoClienteContacto)
   ''Public Property Contactos() As List(Of PedidoClienteContacto)
   ''   Get
   ''      Return _contactos
   ''   End Get
   ''   Set(ByVal value As List(Of PedidoClienteContacto))
   ''      _contactos = value
   ''   End Set
   ''End Property

   ''Private _pedidosContactos As List(Of Entidades.PedidoClienteContacto)
   ''Public Property PedidosContactos() As List(Of Entidades.PedidoClienteContacto)
   ''   Get
   ''      If Me._pedidosContactos Is Nothing Then
   ''         Me._pedidosContactos = New List(Of Entidades.PedidoClienteContacto)()
   ''      End If
   ''      Return Me._pedidosContactos
   ''   End Get
   ''   Set(ByVal value As List(Of Entidades.PedidoClienteContacto))
   ''      Me._pedidosContactos = value
   ''   End Set
   ''End Property

   Private _pedidosObservaciones As List(Of Entidades.PedidoObservacionProveedor)
   Public Property PedidosObservaciones() As List(Of Entidades.PedidoObservacionProveedor)
      Get
         If Me._pedidosObservaciones Is Nothing Then
            Me._pedidosObservaciones = New List(Of Entidades.PedidoObservacionProveedor)()
         End If
         Return Me._pedidosObservaciones
      End Get
      Set(ByVal value As List(Of Entidades.PedidoObservacionProveedor))
         Me._pedidosObservaciones = value
      End Set
   End Property

   Public Property FechaAutorizacion() As Date
   Public Property FechaReprogramacion() As Date
   Public Property IdMoneda As Integer

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

   Public ReadOnly Property IdEmpleado() As Integer
      Get
         If Comprador Is Nothing Then Return Nothing
         Return Comprador.IdEmpleado
      End Get
   End Property



   Public ReadOnly Property IdFormaPago() As Integer?
      Get
         If Comprador Is Nothing Then Return Nothing
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
         If TipoComprobanteFact Is Nothing Then Return String.Empty
         Return Me.TipoComprobanteFact.IdTipoComprobante
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

   'Este valor es calculado en el GetUna. No se guarda en BD.
   Public Property CantidadProductos As Decimal

#End Region

   Public Function Copiar() As PedidoProveedor
      Return Clonar(Me)
   End Function

End Class
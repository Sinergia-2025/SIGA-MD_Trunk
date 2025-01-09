<Serializable()>
Public Class VentaProducto
   Inherits Entidad
   Implements IVentaProducto
   Implements IMovimientoConAtributos

   Public Const NombreTabla As String = "VentasProductos"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Orden
      IdProducto
      Cantidad
      Precio
      Costo
      DescRecGeneral
      DescuentoRecargo
      PrecioLista
      Utilidad
      ImporteTotal
      DescuentoRecargoProducto
      DescuentoRecargoPorc
      DescRecGeneralProducto
      PrecioNeto
      ImporteTotalNeto
      Kilos
      DescuentoRecargoPorc2
      NombreProducto
      IdTipoImpuesto
      AlicuotaImpuesto
      ImporteImpuesto
      ComisionVendedorPorc
      ComisionVendedor
      ImporteImpuestoInterno
      PorcImpuestoInterno
      OrigenPorcImpInt
      'Para pedidos
      Criticidad
      FechaEntrega
      CantPendiente
      IdCentroCosto

      PrecioConImpuestos
      PrecioNetoConImpuestos
      ImporteTotalConImpuestos
      ImporteTotalNetoConImpuestos

      PrecioVentaPorTamano
      Tamano
      IdUnidadDeMedida
      IdMoneda

      Garantia
      TipoOperacion
      Nota
      NombreCortoListaPrecios

      IdFormula
      Automatico
      IdEstadoVenta

      IdOferta
      FechaDevolucion
      ModificoPrecioManualmente
      Conversion
      CantidadManual

      '-- REQ-33090.- -----
      PrecioAux
      IdListaPreciosAux
      '-- REQ-34669.- -----
      IdaAtributoProducto01
      IdaAtributoProducto02
      IdaAtributoProducto03
      IdaAtributoProducto04
      '--------------------
      IdProductoMercosur
      IdProductoSecretaria

      IdDeposito
      NombreDeposito
      IdUbicacion
      NombreUbicacion
      '--------------------
   End Enum

#Region "Campos"

   Private _tipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Short
   Private _numeroComprobante As Long
   Private _orden As Integer
   Private _producto As Entidades.Producto
   Private _cantidad As Decimal
   Private _stock As Decimal
   Private _costo As Decimal
   Private _precioLista As Decimal
   Private _precio As Decimal
   Private _descRecGeneral As Decimal
   Private _descRecGeneralProducto As Decimal
   Private _descuentoRecargo As Decimal
   Private _descuentoRecargoProducto As Decimal
   Private _descuentoRecargoPorc1 As Decimal
   Private _descuentoRecargoPorc2 As Decimal
   Private _iva As Decimal
   Private _utilidad As Decimal
   Private _precioNeto As Decimal
   Private _importeTotal As Decimal
   Private _importeTotalNeto As Decimal
   Private _kilos As Decimal
   Private _tipoImpuesto As Entidades.TipoImpuesto
   Private _alicuotaImpuesto As Decimal
   Private _importeImpuesto As Decimal
   Private _comisionVendedorPorc As Decimal
   Private _comisionVendedor As Decimal
   'Para pedidos
   Private _criticidad As String
   Private _fechaEntrega As Date?
   Private _fechaActualizacion As Date

   Private _InvocadesdePedido As Boolean

   Private _precioaux As Decimal

#End Region

#Region "Propiedades"

   Public ReadOnly Property IdProducto() As String
      Get
         Return Me.Producto.IdProducto
      End Get
   End Property

   Public Property NombreProducto() As String
      Get
         Return Me.Producto.NombreProducto
      End Get
      Set(ByVal value As String)
         Me.Producto.NombreProducto = value
      End Set
   End Property

   Public Property TipoComprobante() As String Implements IVentaProducto.IdTipoComprobante
      Get
         Return _tipoComprobante
      End Get
      Set(ByVal value As String)
         _tipoComprobante = value
      End Set
   End Property

   Public Property Letra() As String Implements IVentaProducto.Letra
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         Me._letra = value
      End Set
   End Property

   Public Property CentroEmisor() As Short Implements IVentaProducto.CentroEmisor
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
      End Set
   End Property

   Public Property NumeroComprobante() As Long Implements IVentaProducto.NumeroComprobante
      Get
         Return Me._numeroComprobante
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobante = value
      End Set
   End Property

   Public Property Orden() As Integer Implements IVentaProducto.Orden
      Get
         Return Me._orden
      End Get
      Set(ByVal value As Integer)
         Me._orden = value
      End Set
   End Property

   Public Property Producto() As Entidades.Producto Implements IVentaProducto.Producto
      Get
         If Me._producto Is Nothing Then
            Me._producto = New Entidades.Producto()
         End If
         Return Me._producto
      End Get
      Set(ByVal value As Entidades.Producto)
         Me._producto = value
      End Set
   End Property

   Public Property Cantidad() As Decimal Implements IVentaProducto.Cantidad
      Get
         Return _cantidad
      End Get
      Set(ByVal value As Decimal)
         _cantidad = value
      End Set
   End Property

   Public Property Stock() As Decimal
      Get
         Return _stock
      End Get
      Set(ByVal value As Decimal)
         _stock = value
      End Set
   End Property

   Public Property Costo() As Decimal
      Get
         Return _costo
      End Get
      Set(ByVal value As Decimal)
         _costo = value
      End Set
   End Property
   Public Property CostoParaGrabar As Decimal?     'Para resolver un descalse en el comportamiento de FacturacionV2 y las otras pantallas. NO SE PERSISTE directamente

   Public Property PrecioLista() As Decimal
      Get
         Return _precioLista
      End Get
      Set(ByVal value As Decimal)
         _precioLista = value
      End Set
   End Property

   Public Property PrecioServicioTecnicoSinIVA As Decimal?
   Public Property PrecioServicioTecnicoConIVA As Decimal?

   Public Property Precio() As Decimal
      Get
         Return _precio
      End Get
      Set(ByVal value As Decimal)
         _precio = value
      End Set
   End Property

   Public Property InvocaDesdePedido As Boolean
      Get
         Return _InvocadesdePedido
      End Get
      Set(ByVal value As Boolean)
         _InvocadesdePedido = value
      End Set
   End Property

   Public Property PrecioAux() As Decimal
      Get
         Return _precioaux
      End Get
      Set(ByVal value As Decimal)
         _precioaux = value
      End Set
   End Property

   Public Property DescRecGeneral() As Decimal
      Get
         Return Me._descRecGeneral
      End Get
      Set(ByVal value As Decimal)
         Me._descRecGeneral = value
      End Set
   End Property

   Public Property DescRecGeneralProducto() As Decimal
      Get
         Return Me._descRecGeneralProducto
      End Get
      Set(ByVal value As Decimal)
         Me._descRecGeneralProducto = value
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

   Public Property DescuentoRecargoProducto() As Decimal
      Get
         Return _descuentoRecargoProducto
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoProducto = value
      End Set
   End Property

   Public Property DescuentoRecargoPorc1() As Decimal
      Get
         Return _descuentoRecargoPorc1
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc1 = value
      End Set
   End Property

   Public Property DescuentoRecargoPorc2() As Decimal
      Get
         Return _descuentoRecargoPorc2
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc2 = value
      End Set
   End Property

   Public Property Iva() As Decimal
      Get
         Return _iva
      End Get
      Set(ByVal value As Decimal)
         _iva = value
      End Set
   End Property

   Public Property PrecioNeto() As Decimal
      Get
         Return _precioNeto
      End Get
      Set(ByVal value As Decimal)
         _precioNeto = value
      End Set
   End Property

   Public Property Utilidad() As Decimal
      Get
         Return _utilidad
      End Get
      Set(ByVal value As Decimal)
         _utilidad = value
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

   Public Property ImporteTotalNeto() As Decimal
      Get
         Return _importeTotalNeto
      End Get
      Set(ByVal value As Decimal)
         _importeTotalNeto = value
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

   Public Property TipoImpuesto() As Entidades.TipoImpuesto
      Get
         If Me._tipoImpuesto Is Nothing Then
            Me._tipoImpuesto = New Entidades.TipoImpuesto()
         End If
         Return _tipoImpuesto
      End Get
      Set(ByVal value As Entidades.TipoImpuesto)
         _tipoImpuesto = value
      End Set
   End Property

   Public Property AlicuotaImpuesto() As Decimal
      Get
         Return _alicuotaImpuesto
      End Get
      Set(ByVal value As Decimal)
         _alicuotaImpuesto = value
      End Set
   End Property

   Public Property ImporteImpuesto() As Decimal
      Get
         Return _importeImpuesto
      End Get
      Set(ByVal value As Decimal)
         _importeImpuesto = value
      End Set
   End Property

   Public Property ComisionVendedorPorc() As Decimal
      Get
         Return Me._comisionVendedorPorc
      End Get
      Set(ByVal value As Decimal)
         Me._comisionVendedorPorc = value
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

   'Para pedidos
   Public Property Criticidad() As String
      Get
         Return Me._criticidad
      End Get
      Set(ByVal value As String)
         Me._criticidad = value
      End Set
   End Property

   Public Property FechaEntrega() As Date?
      Get
         Return Me._fechaEntrega
      End Get
      Set(ByVal value As Date?)
         Me._fechaEntrega = value
      End Set
   End Property

   Public Property FechaActualizacion() As Date
      Get
         Return Me._fechaActualizacion
      End Get
      Set(ByVal value As Date)
         Me._fechaActualizacion = value
      End Set
   End Property

   Public Property CantPendiente() As Decimal

   Private _cantEntregada As Decimal
   Public Property CantEntregada() As Decimal
      Get
         Return _cantEntregada
      End Get
      Set(ByVal value As Decimal)
         _cantEntregada = value
      End Set
   End Property

   Private _cantEnProceso As Decimal
   Public Property CantEnProceso() As Decimal
      Get
         Return _cantEnProceso
      End Get
      Set(ByVal value As Decimal)
         _cantEnProceso = value
      End Set
   End Property

   Private _idListaPrecios As Integer
   Public Property IdListaPrecios() As Integer
      Get
         Return _idListaPrecios
      End Get
      Set(ByVal value As Integer)
         _idListaPrecios = value
      End Set
   End Property

   Private _nombreListaPrecios As String
   Public Property NombreListaPrecios() As String
      Get
         Return _nombreListaPrecios
      End Get
      Set(ByVal value As String)
         _nombreListaPrecios = value
      End Set
   End Property

   Public Property NombreCortoListaPrecios As String

   Private _idListaPreciosAux As Integer
   Public Property IdListaPreciosAux() As Integer
      Get
         Return _idListaPreciosAux
      End Get
      Set(ByVal value As Integer)
         _idListaPreciosAux = value
      End Set
   End Property

   Private _importeImpuestoInterno As Decimal
   Public Property ImporteImpuestoInterno() As Decimal
      Get
         Return _importeImpuestoInterno
      End Get
      Set(ByVal value As Decimal)
         _importeImpuestoInterno = value
      End Set
   End Property

   Public Property PorcImpuestoInterno As Decimal
   Public Property OrigenPorcImpInt As Entidades.OrigenesPorcImpInt

   Public Property CentroCosto As ContabilidadCentroCosto
   Public ReadOnly Property IdCentroCosto As Integer?
      Get
         If CentroCosto Is Nothing Then Return Nothing
         Return CentroCosto.IdCentroCosto
      End Get
   End Property
   Public ReadOnly Property NombreCentroCosto As String
      Get
         If CentroCosto Is Nothing Then Return String.Empty
         Return CentroCosto.NombreCentroCosto
      End Get
   End Property


   Public Property PrecioConImpuestos As Decimal
   Public Property PrecioNetoConImpuestos As Decimal
   Public Property ImporteTotalConImpuestos As Decimal
   Public Property ImporteTotalNetoConImpuestos As Decimal

   Public Property PrecioVentaPorTamano As Decimal
   Public Property Tamano As Decimal
   Public Property IdUnidadDeMedida As String

   Public Property Moneda As Moneda

   Public Property ContribucionMarginalPorc As Decimal

   Private _modificoDescuentos As Boolean
   Public Property ModificoDescuentos() As Boolean
      Get
         Return _modificoDescuentos
      End Get
      Set(ByVal value As Boolean)
         _modificoDescuentos = value
      End Set
   End Property

   Public ReadOnly Property IdMoneda As Integer
      Get
         If Moneda Is Nothing Then Return 0
         Return Moneda.IdMoneda
      End Get
   End Property

   Public Property Garantia As Integer

   Public Property IdFormula As Integer
   Public Property NombreFormula As String      'Solo para mostrar en grillas. No se persiste.

   Public Property TipoOperacion As Producto.TiposOperaciones
   Public Property Nota As String

   Public Property Automatico As Boolean = False

   Public Property IdEstadoVenta As Integer?

   Private _IdOferta As Integer
   Public Property IdOferta() As Integer
      Get
         Return _IdOferta
      End Get
      Set(ByVal value As Integer)
         _IdOferta = value
      End Set
   End Property
   Public Property FechaDevolucion As Date?

   Public Property IdDeposito As Integer
   Public Property NombreDeposito As String
   Public Property IdUbicacion As Integer
   Public Property NombreUbicacion As String

   '-- REQ-34986.- -----------------------------------
   Public Property IdaAtributoProducto01 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto01
   Public Property DescripcionAtributo01 As String
   Public Property IdaAtributoProducto02 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto02
   Public Property DescripcionAtributo02 As String
   Public Property IdaAtributoProducto03 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto03
   Public Property DescripcionAtributo03 As String
   Public Property IdaAtributoProducto04 As Integer Implements IMovimientoConAtributos.IdaAtributoProducto04
   Public Property DescripcionAtributo04 As String
   '--------------------------------------------------
   Public Property PrecioDolar As Decimal
   Public Property PrecioNetoDolar As Decimal
   Public Property ImporteTotalDolar As Decimal
   Public Property CostoDolar As Decimal
#End Region

   Private _ventasProductosFormulas As List(Of VentaProductoFormula)
   Public Property VentasProductosFormulas() As List(Of VentaProductoFormula)
      Get
         If _ventasProductosFormulas Is Nothing Then _ventasProductosFormulas = New List(Of VentaProductoFormula)()
         Return _ventasProductosFormulas
      End Get
      Set(ByVal value As List(Of VentaProductoFormula))
         _ventasProductosFormulas = value
      End Set
   End Property

   Private _ventasProductosLotes As List(Of VentaProductoLote)
   Public Property VentasProductosLotes() As List(Of VentaProductoLote)
      Get
         If _ventasProductosLotes Is Nothing Then _ventasProductosLotes = New List(Of VentaProductoLote)()
         Return _ventasProductosLotes
      End Get
      Set(ByVal value As List(Of VentaProductoLote))
         _ventasProductosLotes = value
      End Set
   End Property

   Private _ventasProductosNrosSerie As List(Of VentaProductoNroSerie)
   Public Property VentasProductosNrosSerie() As List(Of VentaProductoNroSerie)
      Get
         If _ventasProductosNrosSerie Is Nothing Then _ventasProductosNrosSerie = New List(Of VentaProductoNroSerie)()
         Return _ventasProductosNrosSerie
      End Get
      Set(ByVal value As List(Of VentaProductoNroSerie))
         _ventasProductosNrosSerie = value
      End Set
   End Property

   Public Property ModificoPrecioManualmente As Boolean
   Public Property Conversion As Decimal
   Public Property CantidadManual As Decimal

   Public Property Ubicacion As String      'Solo para mostrar en grillas. No se persiste.
   Public Property CodigoProductoProveedor As String      'Solo para mostrar en grillas. No se persiste.

   Public Property IdProductoMercosur() As String
   Public Property IdProductoSecretaria() As String

End Class
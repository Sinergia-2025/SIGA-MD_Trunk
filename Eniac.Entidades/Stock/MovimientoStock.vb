<Serializable()>
Public Class MovimientoStock
   Inherits Entidad

   Public Const NombreTabla As String = "MovimientosStock"
   Public Sub New()
      Sucursal = New Sucursal()
      TipoMovimiento = New TipoMovimiento()
      Sucursal2 = New Sucursal()
      Proveedor = New Proveedor()
      Compra = New Compra()
      Cliente = New Cliente()
      Empleado = New Empleado()
      Venta = New Venta()
      Productos = New List(Of MovimientoStockProducto)()
      ProductosLotes = New List(Of ProductoLote)()
      ProductosNrosSerie = New List(Of ProductoNroSerie)()
   End Sub

#Region "Columnas"
   Public Enum Columnas
      IdSucursal
      IdTipoMovimiento
      NumeroMovimiento
      FechaMovimiento
      Neto
      Total
      PorcentajeIVA
      IdCategoriaFiscal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Usuario
      Observacion
      TotalImpuestos
      IdCliente
      IdSucursal2
      PercepcionIVA
      PercepcionIB
      PercepcionGanancias
      PercepcionVarias
      IdProduccion
      IdProveedor
      IdEmpleado
      ImpuestosInternos
      MercEnviada
   End Enum
#End Region

#Region "Propiedades"
   Public Property Sucursal As Sucursal
   'Public Property IdDeposito As Integer
   'Public Property IdUbicacion As Integer
   Public Property TipoMovimiento As TipoMovimiento
   Public Property NumeroMovimiento As Long
   Public Property FechaMovimiento As Date
   Public Property Neto As Decimal
   Public Property Total As Decimal
   Public Property PorcentajeIVA As Decimal
   Public Property Observacion As String
   Public Property TotalImpuestos As Decimal
   Public Property Sucursal2 As Sucursal
   Public Property PercepcionIVA As Decimal
   Public Property PercepcionIB As Decimal
   Public Property PercepcionGanancias As Decimal
   Public Property PercepcionVarias As Decimal
   Public Property DescuentoRecargo As Decimal
   Public Property MercEnviada As Boolean
   Public Property ImpuestosInternos As Decimal
#End Region

#Region "Otras Tablas"
   Public Property IdProduccion As Integer
   Public Property origenMovimiento As String
   Public Property tablaContabilidad As DataTable
   Public Property IdCaja As Integer
   Public Property Comentarios As String
   Public Property Productos As List(Of MovimientoStockProducto)
   Public Property ProductosLotes As List(Of ProductoLote)
   Public Property ProductosNrosSerie As List(Of ProductoNroSerie)
   Public Property Proveedor As Proveedor
   Public Property Compra As Compra
   Public Property Empleado As Empleado
   Public Property Cliente As Cliente
   Public Property Venta As Venta
#End Region

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdEmpleado As Integer
      Get
         If Empleado Is Nothing Then Return 0
         Return Empleado.IdEmpleado
      End Get
   End Property
   Public ReadOnly Property NombreEmpleado As String
      Get
         If Empleado Is Nothing Then Return String.Empty
         Return Empleado.NombreEmpleado
      End Get
   End Property
#End Region

End Class

Public Class NovedadProduccionMRPProducto
   Inherits Entidad

   Public Const NombreTabla As String = "NovedadesProduccionMRPProductos"

#Region "Columnas"
   Public Enum Columnas
      NumeroNovedadesProducccion
      CodigoOperacion
      IdProducto
      EsProductoNecesario
      EsProductoAgregado
      Cantidad
      IdSucursal
      IdDeposito
      IdUbicacion
      PrecioCosto
      InformeCalidadNumero
      InformeCalidadLink
   End Enum
#End Region
   Public Sub New()
      NumeroNovedadesProducccion = 0
      ProductosLotes = New ListConBorrados(Of NovedadProduccionMRPProductoLote)()
   End Sub

#Region "Propiedades"
   Public Property NumeroNovedadesProducccion As Integer
   Public Property CodigoOperacion As String
   Public Property IdProducto As String
   Public Property EsProductoNecesario As Boolean
   Public Property EsProductoAgregado As Boolean
   Public Property Cantidad As Decimal
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer
   Public Property PrecioCosto As Decimal
   Public Property InformeCalidadNumero As String
   Public Property InformeCalidadLink As String
   Public Property ProductosLotes As ListConBorrados(Of NovedadProduccionMRPProductoLote)
#End Region

#Region "Propiedades no pertenecientes a la Entidad"
   Public Property Lotes As String
   Public Property NombreProducto As String
   Public Property UnidadMedidaProd As String
   Public Property NombreDeposito As String
   Public Property NombreUbicacion As String
   Public Property IdMonedaProducto As Integer
   Public Property NombreMonedaProducto As String
   Public Property CantidadInformada As Decimal
   Public Property CantidadPendiente As Decimal
   Public Property CantidadProcesada As Decimal

   Public Property Vincular As String
#End Region
End Class

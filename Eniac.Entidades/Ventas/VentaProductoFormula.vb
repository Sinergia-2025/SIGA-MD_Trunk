Public Class VentaProductoFormula
   Inherits Entidad
   Public Const NombreTabla As String = "VentasProductosFormulas"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProducto
      Orden
      IdProductoComponente
      IdFormula
      NombreProductoComponente
      NombreFormula
      PrecioCosto
      PrecioVenta
      Cantidad
      SegunCalculoForma

   End Enum

   Public Sub New()
      Lotes = New List(Of VentaProductoFormulaLote)()
      NrosSerie = New List(Of VentaProductoFormulaNroSerie)()
   End Sub

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property IdProductoComponente As String
   Public Property IdFormula As Integer
   Public Property NombreProductoComponente As String
   Public Property NombreFormula As String
   Public Property PrecioCosto As Decimal
   Public Property PrecioVenta As Decimal
   Public Property Cantidad As Decimal
   Public Property SegunCalculoForma As Boolean
   Public Property SeleccionMultiple As SeleccionMultipleUbicaciones

   Public Property Lotes As List(Of VentaProductoFormulaLote)
   Public Property NrosSerie As List(Of VentaProductoFormulaNroSerie)

End Class
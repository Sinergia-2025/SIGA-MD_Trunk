Public Class NovedadProduccionMRPProductoLote
   Inherits Entidad

   Public Const NombreTabla As String = "NovedadesProduccionMRPProductosLotes"

#Region "Columnas"
   Public Enum Columnas
      NumeroNovedadesProducccion
      CodigoOperacion
      IdProducto
      EsProductoNecesario
      IdLote
      Cantidad
   End Enum
#End Region
   Public Sub New()
      NumeroNovedadesProducccion = 0
   End Sub

#Region "Propiedades"
   Public Property NumeroNovedadesProducccion As Integer
   Public Property CodigoOperacion As String
   Public Property IdProducto As String
   Public Property EsProductoNecesario As Boolean
   Public Property IdLote As String
   Public Property Cantidad As Decimal
#End Region
End Class

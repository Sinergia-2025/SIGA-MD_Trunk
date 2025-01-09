Public Class ProduccionProductoCompLote
   Inherits Entidad

   Public Const NombreTabla As String = "ProduccionProductosComponentesLotes"

   Public Enum Columnas
      IdSucursal
      IdProduccion
      Orden
      IdProducto
      IdProductoComponente
      SecuenciaFormula
      IdLote
      Cantidad
   End Enum

   Public Sub New()
   End Sub
   Public Sub New(en As ProduccionProductoComp)
      Me.New()
      SetProduccionProductoComp(en)
   End Sub

   Public Sub SetProduccionProductoComp(en As ProduccionProductoComp)
      IdSucursal = en.IdSucursal
      IdProduccion = en.IdProduccion
      Orden = en.Orden
      IdProducto = en.IdProducto
      IdProductoComponente = en.IdProductoComponente
      SecuenciaFormula = en.SecuenciaFormula
   End Sub

   Public Property IdProduccion As Integer
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property IdProductoComponente As String
   Public Property SecuenciaFormula As Integer
   Public Property IdLote As String

   Public Property Cantidad As Decimal

End Class
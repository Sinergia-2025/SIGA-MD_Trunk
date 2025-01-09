Public Class ProduccionModeloForma
   Inherits Entidad

   Public Const NombreTabla As String = "ProduccionModelosFormas"

   Public Enum Columnas
      IdProduccionModeloForma
      NombreProduccionModeloForma

   End Enum

   Public Sub New()
      Variables = New List(Of ProduccionModeloFormaVariable)()
   End Sub

   Public Property IdProduccionModeloForma As Integer
   Public Property NombreProduccionModeloForma As String

   Public Property Variables As List(Of ProduccionModeloFormaVariable)

End Class
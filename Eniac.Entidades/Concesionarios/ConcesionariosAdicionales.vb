Public Class ConcesionariosAdicionales
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "ConcesionariosAdicionales"

   Public Enum Columnas
      IdAdicional
      NombreAdicional
      DescripcionAdicional
      SolicitaDetalle
   End Enum
   Public Sub New()
   End Sub

   Public Property IdAdicional As Integer
   Public Property NombreAdicional As String
   Public Property DescripcionAdicional As String
   Public Property SolicitaDetalle As Boolean
End Class

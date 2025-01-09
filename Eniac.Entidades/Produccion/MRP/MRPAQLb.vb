Public Class MRPAQLB
   Inherits Entidad

   Public Const NombreTabla As String = "MRPAQLB"

   Public Enum Columnas
      LimiteCalidadAceptable
      CodigoNivel
      TamanoMuestreo
      CantidadAceptacion
      CantidadRechazo

   End Enum
   Public Sub New()

   End Sub

   Public Property LimiteCalidadAceptable As Decimal
   Public Property CodigoNivel As String
   Public Property TamanoMuestreo As Integer
   Public Property CantidadAceptacion As Integer
   Public Property CantidadRechazo As Integer

End Class
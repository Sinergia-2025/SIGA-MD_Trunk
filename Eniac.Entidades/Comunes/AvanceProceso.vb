Public Class AvanceProceso
   Public Property Actual As Integer
   Public Property Total As Integer
   Public Property Mensaje As String

   Public Sub New(actual As Integer, total As Integer, mensaje As String)
      Me.New(actual, total)
      Me.Mensaje = mensaje
   End Sub

   Public Sub New(actual As Integer, total As Integer)
      Me.Actual = actual
      Me.Total = total
   End Sub
End Class
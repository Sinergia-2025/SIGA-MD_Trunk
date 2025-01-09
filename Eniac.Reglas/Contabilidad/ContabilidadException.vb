Public Class ContabilidadException
   Inherits Exception
   Public Sub New(ex As Exception)
      MyBase.New("Error generando contabilidad: " + ex.Message + ".", ex)
   End Sub
   Public Sub New(mensaje As String)
      MyBase.New(mensaje)
   End Sub
   Public Sub New(mensaje As String, ex As Exception)
      MyBase.New(mensaje + ". Error: " + ex.Message + ".", ex)
   End Sub
End Class

Public Class Modificable(Of T)

   Public Sub New(valor As T)
      Me.New(valor, modificable:=True)
   End Sub

   Public Sub New(valor As T, modificable As Boolean)
      Me.Valor = valor
      Me.Modificable = modificable
   End Sub

   Public Property Valor As T
   Public Property Modificable As Boolean

   <Obsolete("", True)>
   Public Overrides Function ToString() As String
      Return MyBase.ToString()
   End Function

End Class
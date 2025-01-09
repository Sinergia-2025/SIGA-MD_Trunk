Public Class StringMultilenguaje

   Public Property Es As String
   Public Property En As String
   Public Property Pt As String

   Public Sub New()

   End Sub

   Public Sub New(es As String)
      Me.Es = es
   End Sub

   Public Sub New(es As String, en As String, pt As String)
      Me.New(es)
      Me.En = en
      Me.Pt = pt
   End Sub

   Public Overrides Function ToString() As String
      Return Me.Es
   End Function

End Class

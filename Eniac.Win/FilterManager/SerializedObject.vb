#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Friend Class SerializedObject
      Public Property Valor As String
      Public Sub New()
      End Sub
      Public Sub New(valor As String)
         Me.New()
         Me.Valor = valor
      End Sub
   End Class
End Namespace
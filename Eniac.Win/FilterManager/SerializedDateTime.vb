#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Friend Class SerializedDateTime
      Inherits SerializedObject
      Public Sub New()
         MyBase.New()
      End Sub
      Public Sub New(valor As String)
         MyBase.New(valor)
      End Sub
   End Class
End Namespace
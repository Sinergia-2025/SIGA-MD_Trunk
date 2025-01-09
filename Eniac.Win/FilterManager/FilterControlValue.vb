#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Public Class FilterControlValue
      Public Property Name As String
      Public Property Value As String
   End Class

   Public Class FilterControlValueList
      Inherits List(Of FilterControlValue)
   End Class
End Namespace
#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports System.Runtime.CompilerServices
#End Region
Public Module ToolStripItemExtensions
   <Extension>
   Public Function TagAs(Of T)(item As ToolStripItem) As T
      If TypeOf (item.Tag) Is T Then
         Return DirectCast(item.Tag, T)
      End If
      Return Nothing
   End Function
End Module
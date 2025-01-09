#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports System.Runtime.CompilerServices
#End Region
Public Module ToolStripItemCollectionExtensions
   <Extension>
   Public Function AddMenuItem(items As ToolStripItemCollection, text As String) As ToolStripMenuItem
      Return AddMenuItem(items, text, tag:=Nothing)
   End Function

   <Extension>
   Public Function AddMenuItem(items As ToolStripItemCollection, text As String, tag As Object) As ToolStripMenuItem
      Return AddMenuItem(items, text, tag, openingCallback:=Nothing)
   End Function

   <Extension>
   Public Function AddMenuItem(items As ToolStripItemCollection, text As String, tag As Object, openingCallback As EventHandler) As ToolStripMenuItem
      Dim menu As New ToolStripMenuItem(text)
      items.Add(menu)
      menu.Tag = tag
      If openingCallback IsNot Nothing Then
         AddHandler menu.DropDownOpening, openingCallback
      End If
      Return menu
   End Function
   '
End Module
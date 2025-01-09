Imports System.Runtime.CompilerServices
Imports Infragistics.Win.UltraWinTabControl
Namespace Extensiones
   Public Module UltraTabControlExtensions
      <Extension()>
      Public Function SelectTab(tbc As UltraTabControl, tabPage As String) As UltraTabControl
         Dim tbp = tbc.Tabs(tabPage)
         tbc.SelectedTab = tbp
         Return tbc
      End Function
   End Module
End Namespace
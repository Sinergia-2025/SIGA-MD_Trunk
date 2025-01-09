#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports System.Runtime.CompilerServices
#End Region
Namespace Extensiones
   Module StatusStripExtensions
      <Extension>
      Public Function MostrarRegistros(tss As ToolStripStatusLabel, dt As DataTable) As ToolStripStatusLabel
         Return MostrarRegistros(tss, dt.Rows.Count)
      End Function
      <Extension>
      Public Function MostrarRegistros(tss As ToolStripStatusLabel, col As IList) As ToolStripStatusLabel
         Return MostrarRegistros(tss, col.Count)
      End Function
      <Extension>
      Public Function MostrarRegistros(tss As ToolStripStatusLabel, cantidad As Integer) As ToolStripStatusLabel
         tss.Text = String.Format("{0} Registro{1}", cantidad, If(cantidad = 1, String.Empty, "s"))
         Return tss
      End Function
   End Module
End Namespace
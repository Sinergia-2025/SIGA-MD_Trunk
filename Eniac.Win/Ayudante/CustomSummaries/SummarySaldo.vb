Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid
Namespace Ayudante.CustomSummaries
   Public Class SummaryUltimoValorColumna
      Implements ICustomSummaryCalculator
      Public Property dt() As DataTable
      Private Property columna As String

      Public Sub New(dt As DataTable, columna As String)
         _dt = dt
         _columna = columna
      End Sub
      Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary
      End Sub
      Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary
      End Sub
      Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary
         If dt.Rows.Count > 0 Then
            Return dt.Rows(dt.Rows.Count - 1)(_columna)
         End If
         Return 0
      End Function
   End Class
End Namespace
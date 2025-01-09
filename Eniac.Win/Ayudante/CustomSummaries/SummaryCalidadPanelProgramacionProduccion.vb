Imports Infragistics.Win.UltraWinGrid
Namespace Ayudante.CustomSummaries
   Public Class SummaryCalidadPanelProgramacionProduccion
      Implements ICustomSummaryCalculator

      Private _countPropio As Integer

      Private _dtColumnas As DataTable
      Public Sub New(dtColumnas As DataTable)

         Me._dtColumnas = dtColumnas

      End Sub

      Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary
         If IsNumeric(row.Cells(summarySettings.SourceColumn).Value) Then
            _countPropio += 1
         End If
      End Sub

      Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary
         _countPropio = 0
      End Sub

      Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary
         Return _countPropio
      End Function

   End Class
End Namespace
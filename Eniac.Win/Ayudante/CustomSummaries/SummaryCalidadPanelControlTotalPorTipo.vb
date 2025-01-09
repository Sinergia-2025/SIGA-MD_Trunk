Imports Infragistics.Win.UltraWinGrid
Namespace Ayudante.CustomSummaries
   Public Class SummaryCalidadPanelControlTotalPorTipo
      Implements ICustomSummaryCalculator

      Private _countPropio As Integer
      Private _countDerecha As Integer
      Private _proximaColumna As String

      Private _dtColumnas As DataTable
      Public Sub New(dtColumnas As DataTable)

         Me._dtColumnas = dtColumnas

      End Sub

      Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary
         If IsDate(row.Cells(summarySettings.SourceColumn).Value) Then
            _countPropio += 1
            If Not String.IsNullOrWhiteSpace(_proximaColumna) AndAlso IsDate(row.Cells(_proximaColumna).Value) Then
               _countDerecha += 1
            End If
         End If
      End Sub

      Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary
         _countPropio = 0
         _countDerecha = 0
         _proximaColumna = String.Empty
         Dim colRows = _dtColumnas.Select(String.Format("NombreColumma = '{0}'", summarySettings.SourceColumn))
         If colRows.Length > 0 Then
            Dim drPropio = colRows(0)
            Dim hastaPropio = drPropio.Field(Of Integer)("RangoHasta")
            Dim colMayores = _dtColumnas.Select(String.Format("RangoHasta > {0}", hastaPropio))
            If colMayores.Length > 0 Then
               _proximaColumna = colMayores(0).Field(Of String)("NombreColumma")
            End If
         End If
      End Sub

      Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary
         Return _countPropio - _countDerecha
      End Function
   End Class
End Namespace
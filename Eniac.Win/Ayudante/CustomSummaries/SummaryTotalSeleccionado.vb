Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid
Namespace Ayudante.CustomSummaries
   Public Class SummaryTotalSeleccionado
      Implements ICustomSummaryCalculator
      Public Property Dt() As DataTable
      Private Property ColumnaSumar As String
      Private Property ColumnaSelec As String

      Public Sub New(dt As DataTable, columnaSumar As String, columnaSelec As String)
         Me.Dt = dt
         Me.ColumnaSumar = columnaSumar
         Me.ColumnaSelec = columnaSelec
      End Sub
      Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary
      End Sub
      Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary
      End Sub
      Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary
         Dim total As Decimal = 0
         For Each dr As DataRow In Dt.Select(String.Format("{0} = {1}", ColumnaSelec, True))
            Dim importe As Decimal = 0
            If IsNumeric(dr(ColumnaSumar)) Then
               importe = Decimal.Parse(dr(ColumnaSumar).ToString())
            End If
            total = total + importe
         Next
         Return total
      End Function
   End Class
End Namespace
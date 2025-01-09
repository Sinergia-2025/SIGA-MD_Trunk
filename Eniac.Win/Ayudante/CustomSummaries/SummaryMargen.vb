Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid
Namespace Ayudante.CustomSummaries
   Public Class SummaryMargen
      Implements ICustomSummaryCalculator
      Private Property columnaUtilidad As String
      Private Property columnaTotal As String
      Private Property columna As String

      Public Sub New(columnaUtilidad As String, columnaTotal As String, columna As String)
         Me.columna = columna
         Me.columnaUtilidad = columnaUtilidad
         Me.columnaTotal = columnaTotal
      End Sub
      Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary
      End Sub
      Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary
      End Sub
      Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary

         Dim objUtilidad As Object = rows.SummaryValues(columnaUtilidad).Value
         Dim utilidad As Decimal = 0
         If IsNumeric(objUtilidad) Then
            utilidad = Convert.ToDecimal(objUtilidad)
         End If

         Dim objTotal As Object = rows.SummaryValues(columnaTotal).Value
         Dim total As Decimal = 0
         If IsNumeric(objTotal) Then
            total = Convert.ToDecimal(objTotal)
         End If

         If total = 0 Then
            Return 0
         End If
         Return utilidad / total * 100
      End Function
   End Class
End Namespace
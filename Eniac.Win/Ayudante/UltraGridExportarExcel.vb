Imports Eniac.Entidades
Imports Infragistics.Documents.Excel
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Public Class UltraGridExportarExcel
   Inherits UltraGridExportarBase
   Private WithEvents _ultraGridExcelExporter As UltraGridExcelExporter
   Private _nombreEmpresa As String

   Public Sub New(ultraGridExcelExporter As UltraGridExcelExporter, nombreEmpresa As String)
      _ultraGridExcelExporter = ultraGridExcelExporter
      _nombreEmpresa = nombreEmpresa
   End Sub

   Private Sub _ultraGridExcelExporter_InitializeColumn(sender As Object, e As InitializeColumnEventArgs) Handles _ultraGridExcelExporter.InitializeColumn
      If Not String.IsNullOrWhiteSpace(e.Column.Format) Then
         If e.Column.Format.StartsWith("N") Then
            Dim decimales = e.Column.Format.Substring(1).ValorNumericoPorDefecto(-1I)
            If decimales = 0 Then
               e.ExcelFormatStr = "#,##0"
            ElseIf decimales > 0 Then
               e.ExcelFormatStr = "#,##0." + New String("0"c, decimales)
            End If
         Else
            e.ExcelFormatStr = e.Column.Format
         End If
      End If
   End Sub
   'Private Sub _ultraGridExcelExporter_SummaryCellExported(sender As Object, e As SummaryCellExportedEventArgs) Handles _ultraGridExcelExporter.SummaryCellExported
   '   If e.Summary IsNot Nothing AndAlso IsNumeric(e.Summary.Value) Then
   '      Dim ws = e.CurrentWorksheet
   '      Dim wsRow = ws.Rows(e.CurrentRowIndex)
   '      Dim wsCell = wsRow.Cells(e.CurrentColumnIndex)

   '      wsCell.Value = e.Summary.Value

   '      '' Note that DotNet formats And Excel format are Not the same. So you can't just
   '      '' set the FormatString to e.Summary.SummarySettings.DisplayFormat. You have to             
   '      '' translate it into a format Excel can understand. 
   '      wsCell.CellFormat.FormatString = "#,##0.00"
   '      '#.##0,00
   '      'General
   '   End If
   'End Sub

   Public Sub Exportar(defaultFileName As String, titulo As String, grilla As UltraGrid, filtro As String)
      Exportar(defaultFileName, {New UltraGridExportTituloGrilla() With {.Titulo = titulo, .Grilla = grilla}}, filtro, False)
   End Sub
   Public Sub Exportar(defaultFileName As String, titulo As String, grilla As UltraGrid, filtro As String, grabarDirecto As Boolean)
      Exportar(defaultFileName, {New UltraGridExportTituloGrilla() With {.Titulo = titulo, .Grilla = grilla}}, filtro, grabarDirecto)
   End Sub

   Public Sub Exportar(defaultFileName As String, grillas As UltraGridExportTituloGrilla(), filtro As String)
      Exportar(defaultFileName, grillas, filtro, False)
   End Sub
   Public Sub Exportar(defaultFileName As String, grillas As UltraGridExportTituloGrilla(), filtro As String, grabarDirecto As Boolean)

      If grillas Is Nothing OrElse grillas.Count = 0 Then
         Throw New ArgumentException("Debe suministrar al menos una grilla.")
      End If

      If Not grabarDirecto Then
         Using sfdExportar As New System.Windows.Forms.SaveFileDialog()
            sfdExportar.FileName = defaultFileName
            sfdExportar.Filter = "Archivos excel|*.xls"
            If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
               ExportarExcel(sfdExportar.FileName.Trim(), grillas, filtro)
            End If
         End Using
      Else
         ExportarExcel(defaultFileName.Trim(), grillas, filtro)
      End If            'If Not grabarDirecto Then
   End Sub

   Private Sub ExportarExcel(nombreArchivo As String, grillas As UltraGridExportTituloGrilla(), filtro As String)
      If String.IsNullOrWhiteSpace(nombreArchivo) Then Throw New ArgumentNullException("nombreArchivo", "Nombre de archivo vacio no es válido.")

      Dim myWorkbook As New Workbook()

      For Each tg As UltraGridExportTituloGrilla In grillas
         ExportarExcelIndividual(myWorkbook, tg, filtro)
      Next

      myWorkbook.Save(nombreArchivo)
      AbrirArchivoExportado(nombreArchivo)
   End Sub

   Private Sub ExportarExcelIndividual(myWorkbook As Workbook, tg As UltraGridExportTituloGrilla, filtro As String)
      Dim myWorksheet As Worksheet
      Dim nombreHoja As String = tg.NombreHoja
      If String.IsNullOrWhiteSpace(nombreHoja) Then nombreHoja = String.Format("Hoja {0}", myWorkbook.Worksheets.Count + 1)

      myWorksheet = myWorkbook.Worksheets.Add(nombreHoja)
      myWorksheet.Rows(0).Cells(0).Value = _nombreEmpresa
      myWorksheet.Rows(1).Cells(0).Value = tg.Titulo
      myWorksheet.Rows(2).Cells(0).Value = filtro

      Me._ultraGridExcelExporter.Export(tg.Grilla, myWorksheet, 4, 0)
   End Sub

End Class
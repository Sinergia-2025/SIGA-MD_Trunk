#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.DocumentExport
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

#End Region
Public Class UltraGridExportarPDF
   Inherits UltraGridExportarBase
   Private _ultraGridDocumentExporter As UltraGridDocumentExporter
   Private _nombreEmpresa As String

   Public Sub New(ultraGridDocumentExporter As UltraGridDocumentExporter, nombreEmpresa As String)
      _ultraGridDocumentExporter = ultraGridDocumentExporter
      _nombreEmpresa = nombreEmpresa
   End Sub

   Public Sub Exportar(defaultFileName As String, titulo As String, grilla As UltraGrid, filtro As String)
      Exportar(defaultFileName, {New UltraGridExportTituloGrilla() With {.Titulo = titulo, .Grilla = grilla}}, filtro)
   End Sub

   Public Sub Exportar(defaultFileName As String, grillas As UltraGridExportTituloGrilla(), filtro As String)
      Using sfdExportar As New System.Windows.Forms.SaveFileDialog()
         sfdExportar.FileName = defaultFileName
         sfdExportar.Filter = "Archivos pdf|*.pdf"
         If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(sfdExportar.FileName.Trim()) Then
               Dim r As New Report()

               For Each tg As UltraGridExportTituloGrilla In grillas
                  ExportarPDFIndividual(r, tg, filtro)
               Next

               r.Publish(sfdExportar.FileName, FileFormat.PDF)
               AbrirArchivoExportado(sfdExportar.FileName)
            End If
         End If
      End Using

   End Sub

   Private Sub ExportarPDFIndividual(r As Report, tg As UltraGridExportTituloGrilla, filtro As String)
      Dim sec As ISection = r.AddSection()

      sec.AddText.AddContent(_nombreEmpresa + System.Environment.NewLine)
      sec.AddText.AddContent(tg.Titulo + System.Environment.NewLine)
      sec.AddText.AddContent(filtro + System.Environment.NewLine + System.Environment.NewLine)

      _ultraGridDocumentExporter.Export(tg.Grilla, sec)
   End Sub

End Class
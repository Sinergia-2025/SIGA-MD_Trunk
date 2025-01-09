Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms

Public Class Imprimir
   Implements IDisposable

#Region "Campos"

   Private m_currentPageIndex As Integer
   Private m_streams As IList(Of IO.Stream)
   Private _nombreFile As String = ""
   Private _config As ConfiguracionImprimir

#End Region

#Region "Metodos Privados"

   Public Sub New(config As ConfiguracionImprimir)
      If config Is Nothing Then
         Throw New ArgumentNullException("config", "ConfiguracionImprimir no puede ser Nothing")
      End If
      _config = config
   End Sub

   Private Function CreateStream(name As String,
                                 fileNameExtension As String,
                                 encoding As Encoding, mimeType As String,
                                 willSeek As Boolean) As IO.Stream
      'Dim stream As Stream = New FileStream(Me._nombreFile, FileMode.OpenOrCreate)
      Dim stream = New IO.MemoryStream()
      m_streams.Add(stream)
      Return stream
   End Function

   Private Sub Export(report As LocalReport, seteaMargenes As Boolean)

      Try

         _reporte = report

         Dim MargenIzquierdo As Integer
         Dim MargenDerecho As Integer

         If seteaMargenes Then
            If Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenIzquierdo = 0 Then
               MargenIzquierdo = report.GetDefaultPageSettings().Margins.Left
            Else
               MargenIzquierdo = Convert.ToInt32(Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenIzquierdo * 0.0393700787)
            End If

            If Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenDerecho = 0 Then
               MargenDerecho = report.GetDefaultPageSettings().Margins.Right
            Else
               MargenDerecho = Convert.ToInt32(Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionMargenDerecho * 0.0393700787)
            End If
         Else
            MargenIzquierdo = report.GetDefaultPageSettings().Margins.Left
            MargenDerecho = report.GetDefaultPageSettings().Margins.Right
         End If

         Dim deviceInfo As StringBuilder = New StringBuilder()

         With deviceInfo
            .AppendFormatLine("<DeviceInfo>")
            .AppendFormatLine("  <OutputFormat>EMF</OutputFormat>")
            If report.GetDefaultPageSettings().IsLandscape Then
               .AppendFormatLine("  <PageWidth>{0}in</PageWidth>", report.GetDefaultPageSettings().PaperSize.Height / 100)
               .AppendFormatLine("  <PageHeight>{0}in</PageHeight>", report.GetDefaultPageSettings().PaperSize.Width / 100)
            Else
               .AppendFormatLine("  <PageWidth>{0}in</PageWidth>", report.GetDefaultPageSettings().PaperSize.Width / 100)
               .AppendFormatLine("  <PageHeight>{0}in</PageHeight>", report.GetDefaultPageSettings().PaperSize.Height / 100)
            End If
            .AppendFormatLine("  <MarginTop>{0}in</MarginTop>", report.GetDefaultPageSettings().Margins.Top / 100)
            .AppendFormatLine("  <MarginLeft>{0}in</MarginLeft>", report.GetDefaultPageSettings().Margins.Left / 100)
            .AppendFormatLine("  <MarginRight>{0}in</MarginRight>", report.GetDefaultPageSettings().Margins.Right / 100)
            .AppendFormatLine("  <MarginBottom>{0}in</MarginBottom>", report.GetDefaultPageSettings().Margins.Bottom / 100)
            .AppendFormatLine("</DeviceInfo>")
         End With

         Dim warnings() As Warning = Nothing
         m_streams = New List(Of IO.Stream)()
         report.Render("Image", deviceInfo.ToString(), AddressOf CreateStream, warnings)
         'report.Render("Image", deviceInfo.ToString(), Nothing, Nothing, "pdf", Nothing, warnings)

         For Each stream In m_streams
            stream.Position = 0
         Next
      Finally
         Reglas.Publicos.VerificaConfiguracionRegional()
      End Try

   End Sub

   Private Sub PrintPage(sender As Object, ev As PrintPageEventArgs)
      Using pageImage As New Metafile(m_streams(m_currentPageIndex))

         ' Adjust rectangular area with printer margins.
         Dim settings = _reporte.GetDefaultPageSettings()
         Dim ancho As Integer = If(settings.IsLandscape, settings.PaperSize.Height, settings.PaperSize.Width)
         Dim alto As Integer = If(settings.IsLandscape, settings.PaperSize.Width, settings.PaperSize.Height)

         Dim adjustedRect As New Rectangle(x:=_config.DesplazamientoX, y:=_config.DesplazamientoY, width:=ancho, height:=alto)

         ' Draw a white background for the report
         ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

         'ev.Graphics.DrawImage(pageImage, ev.PageBounds)
         ev.Graphics.DrawImage(pageImage, adjustedRect)
      End Using

      m_currentPageIndex += 1
      ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
   End Sub
   ''Private Sub HandleOnPrintPage(sender As Object, ev As PrintPageEventArgs)
   ''   Dim pageImage As New Metafile(m_streams(m_currentPageIndex))
   ''   Dim xPos As Single = ev.MarginBounds.Left
   ''   Dim yPos As Single = ev.MarginBounds.Height

   ''   Dim ancho As Integer = If(_reporte.GetDefaultPageSettings().IsLandscape, _reporte.GetDefaultPageSettings().PaperSize.Height, _reporte.GetDefaultPageSettings().PaperSize.Width)
   ''   Dim alto As Integer = If(_reporte.GetDefaultPageSettings().IsLandscape, _reporte.GetDefaultPageSettings().PaperSize.Width, _reporte.GetDefaultPageSettings().PaperSize.Height)

   ''   Dim adjustedRect As New Rectangle(x:=0, y:=0, width:=ancho, height:=alto)

   ''   'Dim adjustedRect As New Rectangle(0, _
   ''   '                                  0, _
   ''   '                                _reporte.GetDefaultPageSettings().PaperSize.Width - 1, _
   ''   '                                 _reporte.GetDefaultPageSettings().PaperSize.Height - 1)

   ''   ev.PageSettings.Landscape = True
   ''   ev.Graphics.FillRectangle(Brushes.White, adjustedRect)
   ''   ev.Graphics.DrawImage(pageImage, adjustedRect)
   ''   ev.HasMorePages = False
   ''End Sub

   Private Sub Print(nombreImpresora As String, cantidadCopias As Integer, impHorizontal As Boolean)

      Dim printerName As String = "Microsoft Office Document Image Writer"

      If m_streams Is Nothing OrElse m_streams.Count = 0 Then
         Return
      End If

      Dim printDoc As PrintDocument = New PrintDocument()
      printDoc.DocumentName = Me._nombreFile
      If String.IsNullOrEmpty(nombreImpresora) Then
         printerName = printDoc.PrinterSettings.PrinterName
      Else
         printDoc.PrinterSettings.PrinterName = nombreImpresora
         printerName = nombreImpresora
      End If
      If Not printDoc.PrinterSettings.IsValid Then
         Dim msg As String = String.Format("No puede encontrar la impresora ""{0}"".", printerName)
         MessageBox.Show(msg, "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return
      End If

      printDoc.DefaultPageSettings.Landscape = impHorizontal
      AddHandler printDoc.PrintPage, AddressOf PrintPage

      printDoc.PrinterSettings.Copies = Convert.ToInt16(cantidadCopias)

      printDoc.Print()

      Reglas.Publicos.VerificaConfiguracionRegional()
   End Sub

   Private Function CrearReporte(reporteNombre As String, reporteEmbebido As Boolean) As LocalReport

      Dim PathArchivo As String = System.Windows.Forms.Application.StartupPath + "\"
      Dim ai As Reglas.ArchivosAImprimir = New Reglas.ArchivosAImprimir()
      Dim aai As Entidades.ArchivoAImprimir = ai.GetUno(actual.Sucursal.Id, reporteNombre)

      If Not String.IsNullOrEmpty(aai.NombreReporteOriginal) Then
         reporteEmbebido = False
         System.IO.File.WriteAllText(PathArchivo + reporteNombre, aai.ReporteSecundario)
      End If

      Dim report As LocalReport = New LocalReport()
      If reporteEmbebido Then
         report.ReportEmbeddedResource = reporteNombre
      Else
         report.ReportPath = reporteNombre
      End If

      Return report

   End Function

#End Region

   Private _reporte As LocalReport

   Public Overloads Sub Run(reporteNombre As String,
                            param As IEnumerable(Of ReportParameter),
                            reporteEmbebido As Boolean,
                            nombreImpresora As String,
                            cantidadCopias As Integer,
                            seteaMargenes As Boolean,
                            reportDataSources As ReportDataSource())
      Dim report As LocalReport = Me.CrearReporte(reporteNombre, reporteEmbebido)

      report.EnableExternalImages = True

      For Each rds As ReportDataSource In reportDataSources
         report.DataSources.Add(rds)
      Next

      If param IsNot Nothing Then
         Reporte.SeteaParametrosAReporte(report, param)
         'report.SetParameters(param)
      End If

      Me.Run(report, nombreImpresora, cantidadCopias, seteaMargenes, report.GetDefaultPageSettings().IsLandscape)

   End Sub
   Public Overloads Sub Run(report As LocalReport, nombreImpresora As String, cantidadCopias As Integer, seteaMargenes As Boolean, impHorizontal As Boolean)

      Me.Export(report, seteaMargenes)

      m_currentPageIndex = 0
      Me.Print(nombreImpresora, cantidadCopias, impHorizontal)

   End Sub

   Public Overloads Sub Run(report As LocalReport, nombreImpresora As String, CantidadCopias As Integer, seteaMargenes As Boolean)
      Run(report, nombreImpresora, CantidadCopias, seteaMargenes, impHorizontal:=False)
   End Sub

   Public Overloads Sub Run(reporteNombre As String,
                            ReportDataSource As Microsoft.Reporting.WinForms.ReportDataSource,
                            param As IEnumerable(Of ReportParameter),
                            reporteEmbebido As Boolean,
                            nombreImpresora As String,
                            cantidadCopias As Integer)

      Run(reporteNombre, param, reporteEmbebido, nombreImpresora, cantidadCopias, False,
          {ReportDataSource})
   End Sub

   Public Overloads Sub Run(reporteNombre As String,
                            reporteDataSource As String,
                            dataSource As DataTable,
                            reporteEmbebido As Boolean,
                            nombreImpresora As String,
                            cantidadCopias As Integer)
      Run(reporteNombre, Nothing, reporteEmbebido, nombreImpresora, cantidadCopias, False,
          {NewReportDataSource(reporteDataSource, dataSource)})
   End Sub

   Public Overloads Sub Run(reporteNombre As String,
                            reporteDataSource As String,
                            dataSource As DataTable,
                            param As IEnumerable(Of ReportParameter),
                            reporteEmbebido As Boolean,
                            nombreImpresora As String,
                            cantidadCopias As Integer)

      Run(reporteNombre, param, reporteEmbebido, nombreImpresora, cantidadCopias, False,
          {NewReportDataSource(reporteDataSource, dataSource)})
   End Sub

   Public Overloads Sub Run(reporteNombre As String,
                            reporteDataSource As String,
                            dataSource As DataTable,
                            reporteDataSource2 As String,
                            dataSource2 As DataTable,
                            param As IEnumerable(Of ReportParameter),
                            reporteEmbebido As Boolean,
                            nombreImpresora As String,
                            cantidadCopias As Integer,
                            seteaMargenes As Boolean)

      '# Seteo los valores de desplazamiento

      Run(reporteNombre, param, reporteEmbebido, nombreImpresora, cantidadCopias, seteaMargenes,
          {NewReportDataSource(reporteDataSource, dataSource), NewReportDataSource(reporteDataSource2, dataSource2)})
   End Sub

   Public Overloads Sub Run(reporteNombre As String,
                            reporteDataSource As String,
                            dataSource As DataTable,
                            reporteDataSource2 As String,
                            dataSource2 As DataTable,
                            reporteDataSource3 As String,
                            dataSource3 As DataTable,
                            param As IEnumerable(Of ReportParameter),
                            reporteEmbebido As Boolean,
                            nombreImpresora As String,
                            cantidadCopias As Integer,
                            seteaMargenes As Boolean)

      Run(reporteNombre, param, reporteEmbebido, nombreImpresora, cantidadCopias, seteaMargenes,
          {NewReportDataSource(reporteDataSource, dataSource), NewReportDataSource(reporteDataSource2, dataSource2), NewReportDataSource(reporteDataSource3, dataSource3)})
   End Sub

   Public Overloads Sub Run(reporteNombre As String,
                            reporteDataSource As String,
                            dataSource As DataTable,
                            reporteDataSource2 As String,
                            dataSource2 As DataTable,
                            reporteDataSource3 As String,
                            dataSource3 As DataTable,
                            reporteDataSource4 As String,
                            dataSource4 As DataTable,
                            param As IEnumerable(Of ReportParameter),
                            reporteEmbebido As Boolean,
                            nombreImpresora As String,
                            cantidadCopias As Integer,
                            seteaMargenes As Boolean)

      Run(reporteNombre, param, reporteEmbebido, nombreImpresora, cantidadCopias, seteaMargenes,
          {NewReportDataSource(reporteDataSource, dataSource), NewReportDataSource(reporteDataSource2, dataSource2), NewReportDataSource(reporteDataSource3, dataSource3), NewReportDataSource(reporteDataSource4, dataSource4)})
   End Sub

   Public Shared Function NewReportDataSource(nombre As String, dataSource As DataTable) As ReportDataSource
      Return New ReportDataSource() With {.Name = nombre, .Value = dataSource}
   End Function

   Public Overloads Sub Dispose() Implements IDisposable.Dispose
      If Not (m_streams Is Nothing) Then
         For Each stream In m_streams
            stream.Close()
         Next
         m_streams = Nothing
      End If
   End Sub

End Class

Public Class ConfiguracionImprimir
   Public Property DesplazamientoX As Integer
   Public Property DesplazamientoY As Integer
   Public Sub New(desplazamientoX As Integer, desplazamientoY As Integer)
      Me.DesplazamientoX = desplazamientoX
      Me.DesplazamientoY = desplazamientoY
   End Sub
End Class
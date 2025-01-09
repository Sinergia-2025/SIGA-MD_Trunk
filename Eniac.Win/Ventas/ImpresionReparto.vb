#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Microsoft.Reporting.WinForms
#End Region
Public Class ImpresionReparto
   Private Property TituloVentana As String
   Public Sub New(tituloVentana As String)
      Me.TituloVentana = tituloVentana
   End Sub

   Public Sub Imprimir(dt As DataTable, nroReparto As Integer, nombreTransportista As String, fechaEnvio As DateTime, ordenarPorCodigo As Boolean)
      Dim nombreArchivo As String = "Eniac.Win.Reparto.rdlc"
      Dim idInforme As String = Eniac.Entidades.PersonalizacionDeInforme.Informes.Reparto.ToString()
      Dim reporteEmbebido As Boolean = True

      Dim pdi As Eniac.Entidades.PersonalizacionDeInforme
      pdi = New Eniac.Reglas.PersonalizacionDeInformes().GetUno(idInforme, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      If pdi IsNot Nothing Then
         nombreArchivo = pdi.NombreArchivo
         reporteEmbebido = pdi.Embebido
      End If

      Imprimir(dt, nroReparto, nombreTransportista, fechaEnvio, ordenarPorCodigo, nombreArchivo, reporteEmbebido)
   End Sub

   Public Sub Imprimir(dtDataSource As DataTable,
                       nroReparto As Integer, nombreTransportista As String, fechaEnvio As DateTime, ordenarPorCodigo As Boolean,
                       nombreReporte As String, reporteEmbebido As Boolean)
      Dim parm As List(Of ReportParameter) = New List(Of ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroReparto", nroReparto.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista", nombreTransportista.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaEnvio", fechaEnvio.ToString()))

      Dim OrdenarPor As String = IIf(ordenarPorCodigo, "CODIGO", "NOMBRE").ToString()

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Orden", OrdenarPor))

      Dim reporteDataSource As String = "SistemaDataSet_InfVentasSumaPorProductos"

      Dim frmImprime As VisorReportes = New VisorReportes(nombreReporte, reporteDataSource, dtDataSource, parm, reporteEmbebido, 1) '# 1 = Cantidad Copias
      frmImprime.Text = Me.TituloVentana
      frmImprime.StartPosition = FormStartPosition.CenterScreen
      frmImprime.WindowState = FormWindowState.Maximized
      frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
      frmImprime.ShowDialog()

   End Sub
End Class
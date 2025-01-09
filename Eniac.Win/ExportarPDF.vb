#Region "Imports"

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports Eniac.Entidades
Imports System.Globalization
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region

Public Class ExportarPDF
   Implements IDisposable

#Region "Campos"

   Private m_currentPageIndex As Integer
   Private m_streams As IList(Of Stream)
   Private _nombreFile As String = ""

#End Region

#Region "Metodos Privados"

   Private Function CreateStream(ByVal name As String, _
                              ByVal fileNameExtension As String, _
                              ByVal encoding As Encoding, ByVal mimeType As String, _
                              ByVal willSeek As Boolean) As Stream
      'Dim stream As Stream = New FileStream(Me._nombreFile, FileMode.OpenOrCreate)
      Dim stream As Stream = New MemoryStream()
      m_streams.Add(stream)
      Return stream
   End Function

   Private Sub Export(ByVal report As LocalReport, ByVal nombreComprobante As String)
      Try

         Me._reporte = report
         Dim deviceInfo As StringBuilder = New StringBuilder()
         With deviceInfo
            .AppendFormatLine("<DeviceInfo>")
            .AppendFormatLine("  <OutputFormat>PDF</OutputFormat>")
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
         m_streams = New List(Of Stream)()
         'report.Render("PDF", deviceInfo, AddressOf CreateStream, warnings)
         Dim bytes As Byte() = report.Render("PDF", deviceInfo.ToString(), Nothing, Nothing, "pdf", Nothing, warnings)

         System.IO.File.WriteAllBytes(nombreComprobante, bytes)

         For Each stream As Stream In m_streams
            stream.Position = 0
         Next
      Catch ex As Exception
         Throw ex
      Finally
         Reglas.Publicos.VerificaConfiguracionRegional()
      End Try

   End Sub

   Private Function CrearReporte(ByVal reporteNombre As String, ByVal reporteEmbebido As Boolean) As LocalReport
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

   Public Overloads Sub Run(ByVal report As LocalReport, ByVal nombreComprobante As String)

      Me.Export(report, nombreComprobante)

   End Sub

   Public Overloads Sub Run(ByVal reporteNombre As String, _
                            ByVal reporteDataSource As String, _
                            ByVal dataSource As DataTable, _
                            ByVal reporteDataSource2 As String, _
                            ByVal dataSource2 As DataTable, _
                            ByVal param As System.Collections.Generic.IEnumerable(Of Microsoft.Reporting.WinForms.ReportParameter), _
                            ByVal reporteEmbebido As Boolean, _
                            ByVal nombreComprobante As String)

      Dim report As LocalReport = Me.CrearReporte(reporteNombre, reporteEmbebido)

      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource

      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2

      report.DataSources.Add(ReportDataSource1)
      report.DataSources.Add(ReportDataSource2)

      'Necesario desde que se agrego la Imagen al Reporte
      report.EnableExternalImages = True

      Reporte.SeteaParametrosAReporte(report, param)

      ' report.SetParameters(param)

      Me.Run(report, nombreComprobante)

   End Sub

   Public Overloads Sub Run(ByVal reporteNombre As String,
                  ByVal reporteDataSource As String,
                  ByVal dataSource As DataTable,
                  ByVal parametros As System.Collections.Generic.IEnumerable(Of Microsoft.Reporting.WinForms.ReportParameter),
                  ByVal reporteEmbebido As Boolean,
                            ByVal nombreComprobante As String)
      Dim report As LocalReport = Me.CrearReporte(reporteNombre, reporteEmbebido)

      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource

      report.DataSources.Add(ReportDataSource1)

      'Necesario desde que se agrego la Imagen al Reporte
      report.EnableExternalImages = True

      Reporte.SeteaParametrosAReporte(report, parametros)

      ' report.SetParameters(param)

      Me.Run(report, nombreComprobante)
   End Sub

   Public Overloads Sub RunRecibo(ByVal reporteNombre As String,
                         ByVal reporteDataSource As String,
                         ByVal dataSource As DataTable,
                         ByVal reporteDataSource2 As String,
                         ByVal dataSource2 As DataTable,
                         ByVal reporteDataSource3 As String,
                         ByVal dataSource3 As DataTable,
                         ByVal reporteDataSource4 As String,
                         ByVal dataSource4 As DataTable,
                         ByVal reporteDataSource5 As String,
                         ByVal dataSource5 As DataTable,
                         ByVal param As System.Collections.Generic.IEnumerable(Of Microsoft.Reporting.WinForms.ReportParameter),
                         ByVal reporteEmbebido As Boolean,
                         ByVal nombreComprobante As String)

      Dim report As LocalReport = Me.CrearReporte(reporteNombre, reporteEmbebido)

      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource1.Name = reporteDataSource
      ReportDataSource1.Value = dataSource

      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource2.Name = reporteDataSource2
      ReportDataSource2.Value = dataSource2

      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
      ReportDataSource3.Name = reporteDataSource3
      ReportDataSource3.Value = dataSource3

      Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New ReportDataSource
      ReportDataSource4.Name = reporteDataSource4
      ReportDataSource4.Value = dataSource4

      Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New ReportDataSource
      ReportDataSource5.Name = reporteDataSource5
      ReportDataSource5.Value = dataSource5

      report.DataSources.Add(ReportDataSource1)
      report.DataSources.Add(ReportDataSource2)
      report.DataSources.Add(ReportDataSource3)
      report.DataSources.Add(ReportDataSource4)
      report.DataSources.Add(ReportDataSource5)


      'Necesario desde que se agrego la Imagen al Reporte
      report.EnableExternalImages = True

      ReporteCtaCteClientes.SeteaParametrosAReporte(report, param)

      ' report.SetParameters(param)

      Me.Run(report, nombreComprobante)

   End Sub


   Public Overloads Sub Dispose() Implements IDisposable.Dispose
      If Not (m_streams Is Nothing) Then
         Dim stream As Stream
         For Each stream In m_streams
            stream.Close()
         Next
         m_streams = Nothing
      End If
   End Sub

   Public Sub Exportar(ByVal oVentas As Entidades.Venta,
                        ByVal nombreComprobante As String)
      Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante)

      Dim categoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim rep As Reporte = New Reporte()
      rep.ArmarReporteDeVenta(oVentas, categoriaFiscalEmpresa, False, utilizaArchivoAExportar:=True)

      Me.Run(rep.ReporteNombre,
             rep.ReporteDataSource,
             rep.VentasProductosDT,
             rep.ReporteDataSource2,
             rep.VentasObservacionesDT,
             rep.Parametros,
             rep.ReporteEmbebido,
             nombreComprobante)

   End Sub

   Public Sub ExportarPedidosProveedores(ByVal oPedidosProveedores As Entidades.PedidoProveedor,
                        ByVal nombreComprobante As String)
      Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(oPedidosProveedores.TipoComprobante.IdTipoComprobante, oPedidosProveedores.LetraComprobante)

      Dim categoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

      Dim rep As Reporte = New Reporte()
      rep.ArmarReporteDePedidoProveedor(oPedidosProveedores, categoriaFiscalEmpresa, False, utilizaArchivoAExportar:=True)

      Me.Run(rep.ReporteNombre,
             rep.ReporteDataSource,
             rep.PedidosProductos,
             rep.Parametros,
             rep.ReporteEmbebido,
             nombreComprobante)

   End Sub
   Public Sub ExportarRecibo(ByVal oCuentaCorriente As Entidades.CuentaCorriente, _
                           ByVal nombreComprobante As String)
      Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(oCuentaCorriente.TipoComprobante.IdTipoComprobante, oCuentaCorriente.Letra)

      Dim categoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

      Dim rep As ReporteCtaCteClientes = New ReporteCtaCteClientes()
      rep.ArmarReporteCtaCteClientes(oCuentaCorriente, verEstandar:=False)

      Me.RunRecibo(rep.ReporteNombre,
                  rep.ReporteDataSource,
                  rep.CtaCtePagosDT,
                  rep.ReporteDataSource2,
                  rep.ChequesDT,
                  rep.ReporteDataSource3,
                  rep.RetencionesDT,
                  rep.ReporteDataSource4,
                  rep.TransferenciasDT,
                  rep.ReporteDataSource5,
                  rep.TarjetasDT,
                  rep.Parametros,
                  rep.ReporteEmbebido,
                  nombreComprobante)
   End Sub

   Public Shared Sub ArmarDocumento(ByVal venta As Entidades.Venta, ByVal asunto As String, ByVal cuerpo As String)

      Dim ePDF As ExportarPDF = New ExportarPDF()
      Dim pdf As String = New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.UBICACIONPDFSFE.ToString(), "C:\ENIAC\AFIP\COMPROBANTES")
      Dim ms As Eniac.Win.MailSSS
      Dim destina As List(Of String) = New List(Of String)()
      Dim Correos() As String


      'Dim ArchivoDestino As String = pdf & "\" & Publicos.CuitEmpresa & "_" &
      '                           venta.TipoComprobante.DescripcionAbrev & "_" &
      '                           venta.LetraComprobante & "_" &
      '                           venta.CentroEmisor.ToString("0000") & "_" &
      '                           venta.NumeroComprobante.ToString("00000000") + ".pdf"

      Dim nombreArchivo = New Reglas.Ventas().FormatoNombreArchivoExportacion(venta)
      Dim ArchivoDestino = String.Format("{0}\{1}",
                                     pdf,
                                     nombreArchivo)

      'Vuelvo a Buscarlo en la base porque la grabacion cambio signos segun necesidad.
      Dim oVentas2 As Reglas.Ventas = New Reglas.Ventas()

      venta = oVentas2.GetUna(venta.IdSucursal, _
                               venta.TipoComprobante.IdTipoComprobante, _
                               venta.LetraComprobante, _
                               venta.CentroEmisor, _
                               venta.NumeroComprobante)

      ePDF.Exportar(venta, ArchivoDestino)

      'Envio Mail al Cliente con pdf

      Dim correoNuevo As String = String.Empty
      If Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.Principal.ToString() Then
         correoNuevo = venta.Cliente.CorreoElectronico
      ElseIf Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.Administrativo.ToString() Then
         correoNuevo = venta.Cliente.CorreoAdministrativo
      ElseIf Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.AdminyPrincipal.ToString() Then
         correoNuevo = venta.Cliente.CorreoElectronico + ";" + venta.Cliente.CorreoAdministrativo
      ElseIf Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.AdminoPrincipal.ToString() Then
         If Not String.IsNullOrWhiteSpace(venta.Cliente.CorreoAdministrativo) Then
            correoNuevo = venta.Cliente.CorreoAdministrativo
         Else
            correoNuevo = venta.Cliente.CorreoElectronico
         End If
      End If

      correoNuevo = correoNuevo.Trim().Trim(";"c).Trim()

      If Publicos.EnviaMailComprobanteElectronico And Not String.IsNullOrEmpty(correoNuevo) Then
         Correos = correoNuevo.Split(";"c)
         destina.Clear()
         Dim Cont As Integer
         For Cont = 0 To Correos.Length - 1
            destina.Add(Correos(Cont))
         Next

         'Agrego una Copia a SI Mismo.
         If Reglas.Publicos.EnviaMailCopiaOcultaComprobanteElectronico And Not String.IsNullOrEmpty(Reglas.Publicos.MailCopiaOcultaCompElectronico.ToString()) Then
            destina.Add(Reglas.Publicos.MailCopiaOcultaCompElectronico)
         Else
            destina.Add(Publicos.MailDireccion)
         End If

         'creo el mail y lo envio
         ms = New Eniac.Win.MailSSS()
         ms.CrearMail(destina.ToArray(), asunto, cuerpo, Nothing, {Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta})
         ms.AgregarAdjunto(ArchivoDestino)
         ms.EnviarMail()

         Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
         rVentas.ActualizaFechaEnvioCorreo(venta, Now)

      End If
   End Sub

   Public Shared Sub ArmarRecibo(ByVal ctacte As Entidades.CuentaCorriente, ByVal asunto As String, ByVal cuerpo As String)

      Dim ePDF As ExportarPDF = New ExportarPDF()
      Dim pdf As String = New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.UBICACIONPDFSFE.ToString(), "C:\ENIAC\AFIP\COMPROBANTES")
      Dim ms As Eniac.Win.MailSSS
      Dim destina As List(Of String) = New List(Of String)()
      Dim Correos() As String


      Dim ArchivoDestino As String = pdf & "\" & Publicos.CuitEmpresa & "_" & _
                                 ctacte.TipoComprobante.DescripcionAbrev & "_" & _
                                 ctacte.Letra & "_" & _
                                 ctacte.CentroEmisor.ToString("0000") & "_" & _
                                 ctacte.NumeroComprobante.ToString("00000000") + ".pdf"


      'Vuelvo a Buscarlo en la base porque la grabacion cambio signos segun necesidad.
      Dim octacte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

      ctacte = octacte.GetUna(ctacte.IdSucursal, _
                               ctacte.TipoComprobante.IdTipoComprobante, _
                               ctacte.Letra, _
                               ctacte.CentroEmisor, _
                               ctacte.NumeroComprobante)

      ePDF.ExportarRecibo(ctacte, ArchivoDestino)

      'Envio Mail al Cliente con pdf

      Dim correoNuevo As String = String.Empty
      If Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.Principal.ToString() Then
         correoNuevo = ctacte.Cliente.CorreoElectronico
      ElseIf Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.Administrativo.ToString() Then
         correoNuevo = ctacte.Cliente.CorreoAdministrativo
      ElseIf Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.AdminyPrincipal.ToString() Then
         correoNuevo = ctacte.Cliente.CorreoElectronico + ";" + ctacte.Cliente.CorreoAdministrativo
      ElseIf Publicos.ConfiguraciónMail = Cliente.ConfiguracionMail.AdminoPrincipal.ToString() Then
         If Not String.IsNullOrWhiteSpace(ctacte.Cliente.CorreoAdministrativo) Then
            correoNuevo = ctacte.Cliente.CorreoAdministrativo
         Else
            correoNuevo = ctacte.Cliente.CorreoElectronico
         End If
      End If

      correoNuevo = correoNuevo.Trim().Trim(";"c).Trim()

      ' If Publicos.RecibosEnviaMailCliente And Not String.IsNullOrEmpty(correoNuevo) Then
      If Not String.IsNullOrEmpty(correoNuevo) Then

         Correos = correoNuevo.Split(";"c)
         destina.Clear()
         Dim Cont As Integer
         For Cont = 0 To Correos.Length - 1
            destina.Add(Correos(Cont))
         Next

         'Agrego una Copia a SI Mismo.
         destina.Add(Publicos.MailDireccion)

         'creo el mail y lo envio
         ms = New Eniac.Win.MailSSS()
         ms.CrearMail(destina.ToArray(), asunto, cuerpo, Nothing, {Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta})
         ms.AgregarAdjunto(ArchivoDestino)
         ms.EnviarMail()

         Dim rCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
         octacte.ActualizaFechaEnvioCorreo(ctacte.IdSucursal, ctacte.TipoComprobante.IdTipoComprobante, ctacte.Letra, ctacte.CentroEmisor, ctacte.NumeroComprobante, Now)

      End If
   End Sub


End Class

Public Class ReporteFiscalElectronico

   Private _directorioDefault As String
   Private _impresora As Entidades.Impresora
   Private _metodoExportacion As Reglas.FiscalV2.MetodoExportacionInformeAFIP?
   Private _di As IO.DirectoryInfo = New IO.DirectoryInfo(FileIO.SpecialDirectories.Desktop & "\" & "ExportacionFiscal")

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      'TryCatched(Sub() _directorioDefault = IO.Path.Combine(FileIO.SpecialDirectories.Desktop, "2"))
      'TryCatched(Sub() _directorioDefault = _di)
      _directorioDefault = _di.ToString()
      TryCatched(Sub() RefrescarDatosGrilla())

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         tsbSalir.PerformClick()
         Return True
      ElseIf keyData = Keys.F2 Then
         dtpAuditoriaPorFechaDesde.Focus()
         Return True
      ElseIf keyData = Keys.F3 Then
         txtAuditoriaPorNroZetaDesde.Focus()
         Return True
      ElseIf keyData = Keys.F4 Then
         dtpInformeParaAFIPPorFechaDesde.Focus()
         Return True
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F6 Then
         btnExportarAuditoriaPorFecha.PerformClick()
         Return True
      ElseIf keyData = Keys.F7 Then
         btnExportarAuditoriaPorNroZeta.PerformClick()
         Return True
      ElseIf keyData = Keys.F8 Then
         btnExportarInformeParaAFIPPorFecha.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   'Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
   '   If _impresoraFiscal IsNot Nothing Then
   '      _impresoraFiscal.Dispose()
   '      _impresoraFiscal = Nothing
   '   End If
   '   MyBase.OnFormClosing(e)
   'End Sub

#End Region

#Region "Eventos"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub dtpAuditoriaPorFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpAuditoriaPorFechaDesde.ValueChanged
      TryCatched(Sub() SetAuditoriaPorFechaNombreArchivo())
   End Sub
   Private Sub dtpAuditoriaPorFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpAuditoriaPorFechaHasta.ValueChanged
      TryCatched(Sub() SetAuditoriaPorFechaNombreArchivo())
   End Sub
   Private Sub txtAuditoriaPorNroZetaDesde_TextChanged(sender As Object, e As EventArgs) Handles txtAuditoriaPorNroZetaDesde.TextChanged
      TryCatched(Sub() SetAuditoriaPorNroZetaNombreArchivo())
   End Sub
   Private Sub txtAuditoriaPorNroZetaHasta_TextChanged(sender As Object, e As EventArgs) Handles txtAuditoriaPorNroZetaHasta.TextChanged
      TryCatched(Sub() SetAuditoriaPorNroZetaNombreArchivo())
   End Sub
   Private Sub dtpInformeParaAFIPPorFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpInformeParaAFIPPorFechaDesde.ValueChanged
      TryCatched(Sub() SetInformeAFIPNombreArchivo())
   End Sub
   Private Sub dtpInformeParaAFIPPorFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpInformeParaAFIPPorFechaHasta.ValueChanged
      TryCatched(Sub() SetInformeAFIPNombreArchivo())
   End Sub

   Private Sub btnAuditoriaPorFechaNombreArchivo_Click(sender As Object, e As EventArgs) Handles btnAuditoriaPorFechaNombreArchivo.Click
      TryCatched(Sub()
                    sfdAuditoriaPorFechaNombreArchivo.FileName = txtAuditoriaPorFechaNombreArchivo.Text
                    If sfdAuditoriaPorFechaNombreArchivo.ShowDialog() = DialogResult.OK Then
                       txtAuditoriaPorFechaNombreArchivo.Text = sfdAuditoriaPorFechaNombreArchivo.FileName
                    End If
                 End Sub)
   End Sub
   Private Sub btnAuditoriaPorNroZetaNombreArchivo_Click(sender As Object, e As EventArgs) Handles btnAuditoriaPorNroZetaNombreArchivo.Click
      TryCatched(Sub()
                    sfdAuditoriaPorNroZetaNombreArchivo.FileName = txtAuditoriaPorNroZetaNombreArchivo.Text
                    If sfdAuditoriaPorNroZetaNombreArchivo.ShowDialog() = DialogResult.OK Then
                       txtAuditoriaPorNroZetaNombreArchivo.Text = sfdAuditoriaPorNroZetaNombreArchivo.FileName
                    End If
                 End Sub)
   End Sub
   Private Sub btnInformeParaAFIPPorFechaNombreDirectorio_Click(sender As Object, e As EventArgs) Handles btnInformeParaAFIPPorFechaNombreDirectorio.Click
      TryCatched(Sub()
                    fbdInformeParaAFIPPorFechaNombreDirectorio.SelectedPath = txtInformeParaAFIPPorFechaNombreDirectorio.Text
                    If fbdInformeParaAFIPPorFechaNombreDirectorio.ShowDialog() = DialogResult.OK Then
                       txtInformeParaAFIPPorFechaNombreDirectorio.Text = fbdInformeParaAFIPPorFechaNombreDirectorio.SelectedPath
                    End If
                 End Sub)
   End Sub

   Private Sub btnExportarAuditoriaPorFecha_Click(sender As Object, e As EventArgs) Handles btnExportarAuditoriaPorFecha.Click
      TryCatched(Sub()
                    crearDirectorio()
                    If ShowPregunta(String.Format("¿Desea exportar el archivo {0}?", txtAuditoriaPorFechaNombreArchivo.Text)) = DialogResult.Yes Then
                       ExportarAuditoriaPorFecha()
                    End If
                 End Sub)
   End Sub
   Private Sub btnExportarAuditoriaPorNroZeta_Click(sender As Object, e As EventArgs) Handles btnExportarAuditoriaPorNroZeta.Click
      TryCatched(Sub()
                    crearDirectorio()
                    If ShowPregunta(String.Format("¿Desea exportar el archivo {0}?", txtAuditoriaPorNroZetaNombreArchivo.Text)) = DialogResult.Yes Then
                       ExportarAuditoriaPorNroZeta()
                    End If
                 End Sub)
   End Sub
   Private Sub btnExportarInformeParaAFIPPorFecha_Click(sender As Object, e As EventArgs) Handles btnExportarInformeParaAFIPPorFecha.Click
      TryCatched(Sub()
                    crearDirectorio()
                    If ShowPregunta(String.Format("¿Desea exportar los informes para AFIP en el directorio {0}?", txtInformeParaAFIPPorFechaNombreDirectorio.Text)) = DialogResult.Yes Then
                       ExportarInformeParaAFIPPorFecha()
                    End If
                 End Sub)
   End Sub
#End Region

#Region "Métodos"
   Private Sub RefrescarDatosGrilla()

      LeerDatosImpresora()

      'dtpAuditoriaPorFechaDesde.Value = Date.Today
      'dtpAuditoriaPorFechaHasta.Value = Date.Today.UltimoSegundoDelDia()

      'txtAuditoriaPorNroZetaDesde.Text = "0"
      'txtAuditoriaPorNroZetaHasta.Text = "0"

      'dtpInformeParaAFIPPorFechaDesde.Value = Date.Today
      'dtpInformeParaAFIPPorFechaHasta.Value = Date.Today.UltimoSegundoDelDia()

      txtInformeParaAFIPPorFechaNombreDirectorio.Text = _di.ToString()

      SetAuditoriaPorFechaNombreArchivo()
      SetAuditoriaPorNroZetaNombreArchivo()
      SetInformeAFIPNombreArchivo()

      dtpAuditoriaPorFechaDesde.Focus()

   End Sub
   Private Sub LeerDatosImpresora()
      Try
         ClearInfo()

         _metodoExportacion = Nothing

         txtIdImpresora.Text = String.Empty
         txtTipoImpresora.Text = String.Empty
         txtCentroEmisor.Text = String.Empty
         txtMarca.Text = String.Empty
         txtModelo.Text = String.Empty
         txtPuerto.Text = String.Empty
         txtMetodoImpresion.Text = String.Empty

         grpAuditoriaPorFecha.Enabled = False
         grpAuditoriaPorNroZeta.Enabled = False
         grpExportarInformeParaAFIPPorFecha.Enabled = False

         _impresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, esFiscal:=True)

         txtIdImpresora.Text = _impresora.IdImpresora
         txtTipoImpresora.Text = _impresora.TipoImpresora
         txtCentroEmisor.Text = _impresora.CentroEmisor.ToString()

         txtMarca.Text = _impresora.Marca
         txtModelo.Text = _impresora.Modelo
         txtPuerto.Text = _impresora.Puerto
         If _impresora.Metodo.HasValue Then
            txtMetodoImpresion.Text = _impresora.Metodo.ToString()

            If _impresora.Metodo <> Entidades.Impresora.MetodosFiscal.DLLsV2 Then
               MostrarError("La impresora asociada a esta PC no permite la emisión de este informe")
            Else

               Dim rExtracciones = New Reglas.ImpresorasExtracciones()
               Dim lstExtracciones = rExtracciones.GetTodos(_impresora)
               ugExtracciones.DataSource = lstExtracciones

               grpAuditoriaPorFecha.Enabled = _impresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2
               grpAuditoriaPorNroZeta.Enabled = _impresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2
               grpExportarInformeParaAFIPPorFecha.Enabled = _impresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2

               dtpAuditoriaPorFechaDesde.Value = _impresora.FiscalUltimaFechaExtraidaAuditoria.IfNull(Today.AddSeconds(-1)).AddSeconds(1)
               txtAuditoriaPorNroZetaDesde.Text = (_impresora.FiscalUltimoZetaExtraidoAuditoria.IfNull() + 1).ToString()
               dtpInformeParaAFIPPorFechaDesde.Value = _impresora.FiscalUltimaFechaExtraidaInforme.IfNull(Today.AddSeconds(-1)).AddSeconds(1)

               dtpAuditoriaPorFechaHasta.Value = dtpAuditoriaPorFechaDesde.Value.UltimoSegundoDelDia()
               txtAuditoriaPorNroZetaHasta.Text = txtAuditoriaPorNroZetaDesde.Text
               dtpInformeParaAFIPPorFechaHasta.Value = dtpInformeParaAFIPPorFechaDesde.Value.UltimoSegundoDelDia()

               Dim mensajeInfo = String.Empty

               Using _impresoraFiscal = New ImpresionFiscalV2(_impresora)
                  grpAuditoriaPorNroZeta.Enabled = _impresoraFiscal.PuedeExportarPorNroZeta
                  _metodoExportacion = _impresoraFiscal.MetodoExportacion
                  If lstExtracciones.Count = 0 Then
                     Dim primerDia = _impresoraFiscal.FechaPrimerZeta()
                     dtpInformeParaAFIPPorFechaDesde.Value = _impresoraFiscal.PrimerDiaSemanaFiscal(primerDia.IfNull(New Date(2017, 4, 21))) 'dtpInformeParaAFIPPorFechaDesde.MinDate))
                     dtpInformeParaAFIPPorFechaDesde.Enabled = Not primerDia.HasValue
                     dtpInformeParaAFIPPorFechaHasta.Value = _impresoraFiscal.PrimerDiaSemanaFiscal(Today).AddDays(-1)
                     mensajeInfo = "No se registra extracción para el Zeta 1. Se generarán todos los reportes desde el Zeta 1. La fecha de exportación inicial no se puede cambiar."
                  Else
                     dtpInformeParaAFIPPorFechaDesde.Enabled = True
                  End If

               End Using

               If String.IsNullOrWhiteSpace(mensajeInfo) Then
                  MostrarInfo("¡Listo para exportar!")
               Else
                  MostrarInfo(mensajeInfo)
               End If

            End If
         Else
            MostrarError("La impresora asociada a esta PC no tiene configurado un método de comunicación con la Fiscal")
         End If

      Catch ex As Exception
         'ShowError(ex)
         MostrarError(ex.Message)
      End Try

   End Sub

   Private Sub ExportarAuditoriaPorFecha()
      Exportar(Sub(impf) impf.ObtenerAuditoria(dtpAuditoriaPorFechaDesde.Value,
                                               dtpAuditoriaPorFechaHasta.Value,
                                               txtAuditoriaPorFechaNombreArchivo.Text),
               Sub(rImpresora) rImpresora.ActualizaUltimaFechaExtraidaAuditoria(_impresora, dtpAuditoriaPorFechaHasta.Value))
   End Sub
   Private Sub ExportarAuditoriaPorNroZeta()
      Exportar(Sub(impf) impf.ObtenerAuditoria(txtAuditoriaPorNroZetaDesde.ValorNumericoPorDefecto(0I),
                                               txtAuditoriaPorNroZetaHasta.ValorNumericoPorDefecto(0I),
                                               txtAuditoriaPorNroZetaNombreArchivo.Text),
               Sub(rImpresora) rImpresora.ActualizaUltimoZetaExtraidoAuditoria(_impresora, txtAuditoriaPorNroZetaHasta.ValorNumericoPorDefecto(0I)))
   End Sub
   Public Sub ExportarInformeParaAFIPPorFecha()
      Exportar(Sub(impf) impf.InformeAFIP(_impresora,
                                          dtpInformeParaAFIPPorFechaDesde.Value,
                                          dtpInformeParaAFIPPorFechaHasta.Value,
                                          txtInformeParaAFIPPorFechaNombreDirectorio.Text),
               Sub(rImpresora) rImpresora.ActualizaUltimaFechaExtraidaInforme(_impresora, dtpInformeParaAFIPPorFechaHasta.Value))
   End Sub

   Private Sub Exportar(accion As Action(Of ImpresionFiscalV2), actualiza As Action(Of Reglas.Impresoras))
      'CheckInitialized()
      'Metodo nuevo de impresion
      If _impresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2 Then
         ''Private _impresoraFiscal As ImpresionFiscalV2
         Using _impresoraFiscal = New ImpresionFiscalV2(_impresora)
            accion(_impresoraFiscal)
         End Using

      Else
         Throw New NotImplementedException(String.Format("La impresora seleccionada no permite la exportación."))
      End If

      actualiza(New Reglas.Impresoras())
      RefrescarDatosGrilla()

   End Sub

   'Private Sub CheckInitialized()
   '   If _impresoraFiscal Is Nothing Then
   '      Throw New NullReferenceException("La impresora fiscal no se encuentra correctamente inicializada. Cierre y vuelva a abrir la pantalla para continuar.")
   '   End If
   'End Sub

#Region "Métodos StatusBar"
   Private Sub ClearInfo()
      tssError.Text = String.Empty
      tssInfo.Text = String.Empty
      tssInfo.Visible = False
      tssError.Visible = False
   End Sub
   Private Sub MostrarError(mensaje As String)
      tssError.Text = mensaje
      tssError.Visible = True
   End Sub
   Private Sub MostrarInfo(mensaje As String)
      tssInfo.Text = mensaje
      tssInfo.Visible = True
   End Sub
#End Region

#Region "Métodos Nombre Archivo"
   Private Sub SetAuditoriaPorFechaNombreArchivo()
      If _directorioDefault IsNot Nothing Then
         txtAuditoriaPorFechaNombreArchivo.Text = IO.Path.Combine(_di.ToString(),
                                                                  String.Format("AuditoriaPorFecha_{0:yyyyMMdd-HHmmss}_{1:yyyyMMdd-HHmmss}.xml",
                                                                                dtpAuditoriaPorFechaDesde.Value, dtpAuditoriaPorFechaHasta.Value))
      End If
   End Sub
   Private Sub SetAuditoriaPorNroZetaNombreArchivo()
      If _directorioDefault IsNot Nothing Then
         txtAuditoriaPorNroZetaNombreArchivo.Text = IO.Path.Combine(_di.ToString(),
                                                                    String.Format("AuditoriaPorNroZeta_{0}_{1}.xml",
                                                                                  txtAuditoriaPorNroZetaDesde.Text, txtAuditoriaPorNroZetaHasta.Text))
      End If
   End Sub
   Private Sub SetInformeAFIPNombreArchivo()
      If _directorioDefault IsNot Nothing Then
         If _metodoExportacion.HasValue AndAlso _metodoExportacion.Value = Reglas.FiscalV2.MetodoExportacionInformeAFIP.PorArchivo Then
            txtInformeParaAFIPPorFechaNombreDirectorio.Text = IO.Path.Combine(_di.ToString(),
                                                                     String.Format("InformeAFIP_{0:yyyyMMdd-HHmmss}_{1:yyyyMMdd-HHmmss}",
                                                                                   dtpInformeParaAFIPPorFechaDesde.Value, dtpInformeParaAFIPPorFechaHasta.Value))
            lblInformeParaAFIPPorFechaNombreDirectorio.Text = "Nombre Archivo"
         Else
            txtInformeParaAFIPPorFechaNombreDirectorio.Text = _di.ToString()
            lblInformeParaAFIPPorFechaNombreDirectorio.Text = "Nombre Directorio"
         End If
      End If
   End Sub

   Private Sub crearDirectorio()
      Try
         If Not _di.Exists Then
            _di.Create()
         End If
      Catch ex As Exception
         MsgBox(ex.ToString())
      End Try

   End Sub
#End Region

#End Region
End Class
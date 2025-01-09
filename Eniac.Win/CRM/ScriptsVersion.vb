Public Class ScriptsVersion

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _estaCargandoVersion As Boolean = False
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            _publicos.CargaComboAplicaciones(cmbAplicacion)

            _estaCargando = False

            tssInfo.Text = Reglas.Publicos.URLActualizacion

            RefrescarDatosGrilla()
         End Sub)
   End Sub

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
         Sub()
            Dim sv = New Entidades.VersionScript()
            sv.Aplicacion.IdAplicacion = cmbAplicacion.Text
            sv.Version.NroVersion = cmbVersionDesde.Text
            sv.Obligatorio = True

            Using det = New ScriptsVersionDetalle(sv)
               det.ShowDialog()
            End Using

            Consultar()
         End Sub)
   End Sub

   Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
      TryCatched(
         Sub()
            Dim dr = ugScripts.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Dim oReg = New Reglas.VersionesScripts()
               Dim sv = oReg.GetUno(dr.Field(Of String)("IdAplicacion"), dr.Field(Of String)("NroVersion"), dr.Field(Of Integer)("Orden"))
               Using det = New ScriptsVersionDetalle(sv)
                  det.StateForm = StateForm.Actualizar
                  det.ShowDialog()
               End Using
               tsbRefrescar.PerformClick()
            End If
         End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
         Sub()
            Dim dr = ugScripts.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Dim reg = New Reglas.VersionesScripts()
               reg.Borrar(dr.Field(Of String)("IdAplicacion"), dr.Field(Of String)("NroVersion"), dr.Field(Of Integer)("Orden"))

               Consultar()
            End If

         End Sub)

   End Sub

   Private Sub btnInsertarSeleccioMultiple_Click(sender As Object, e As EventArgs) Handles btnInsertarSeleccioMultiple.Click
      TryCatched(
         Sub()
            If ofgScript.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               ImportarScriptsMasivo(ofgScript.FileNames)
            End If
         End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If ugScripts.Rows.Count = 0 Then Exit Sub
         ugScripts.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If ugScripts.Rows.Count = 0 Then Exit Sub
         ugScripts.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            ugScripts.Imprimir(Text, CargarFiltrosImpresion())
         End Sub)
      'Try

      '   If ugScripts.Rows.Count = 0 Then Exit Sub

      '   Dim titulo = String.Format("{1}{0}{0}{2}{0}{0}{3}", Environment.NewLine, Publicos.NombreEmpresa, Text, CargarFiltrosImpresion())

      '   Dim UltraPrintPreviewD As Printing.UltraPrintPreviewDialog
      '   UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
      '   UltraPrintPreviewD.AutoSizeMode = AutoSizeMode.GrowAndShrink
      '   UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

      '   UltraPrintPreviewD.Document = UltraGridPrintDocument1
      '   UltraPrintPreviewD.Name = Text

      '   UltraGridPrintDocument1.Header.TextCenter = titulo
      '   UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
      '   UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
      '   UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
      '   UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
      '   UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
      '   UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
      '   UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
      '   UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
      '   UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

      '   UltraPrintPreviewD.MdiParent = MdiParent
      '   UltraPrintPreviewD.Show()
      '   UltraPrintPreviewD.Focus()

      'Catch ex As Exception
      '   ShowError(ex)
      'End Try

   End Sub

   Private Sub tsbSincronizacionWeb_Click(sender As Object, e As EventArgs) Handles tsbSincronizacionWeb.Click
      TryCatched(
         Sub()
            If ShowPregunta("¿Esta seguro de querer subir la información a la Web?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
               SincronizarWeb()
            End If
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   'Se ocultó el botón y el textbox porque no estaría funcionando correctamente.
   ''Private Sub tsbTesteaScripts_Click(sender As Object, e As EventArgs) Handles tsbTesteaScripts.Click
   ''   TryCatched(Sub() TesteaScripts())
   ''End Sub
#End Region

   Private Sub cmbAplicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAplicacion.SelectedIndexChanged
      TryCatched(
         Sub()
            If Not _estaCargando Then
               If cmbAplicacion.SelectedIndex > -1 Then
                  _estaCargandoVersion = True
                  _publicos.CargaComboVersiones(cmbVersionDesde, cmbAplicacion.Text)
                  _publicos.CargaComboVersiones(cmbVersionHasta, cmbAplicacion.Text)
               End If
            End If
         End Sub)
      _estaCargandoVersion = False
   End Sub
   Private Sub cmbVersionHasta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVersionDesde.SelectedIndexChanged, cmbVersionHasta.SelectedIndexChanged
      TryCatched(
         Sub()
            If Not _estaCargandoVersion Then
               Consultar()
            End If
         End Sub)
   End Sub

#Region "Eventos Grilla"

   Private Sub ugScripts_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugScripts.DoubleClickRow
      btnEditar.PerformClick()
   End Sub
   Private Sub ugScripts_DragDrop(sender As Object, e As DragEventArgs) Handles ugScripts.DragDrop

      TryCatched(
         Sub()
            Dim archivos = DirectCast(e.Data.GetData(DataFormats.FileDrop), IEnumerable(Of String))

            ImportarScriptsMasivo(archivos)
         End Sub)
   End Sub
   Private Sub ugScripts_DragOver(sender As Object, e As DragEventArgs) Handles ugScripts.DragOver
      If e.Data.GetDataPresent(DataFormats.FileDrop) Then
         e.Effect = DragDropEffects.Copy
      Else
         e.Effect = DragDropEffects.None

      End If
   End Sub

#End Region

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()
      'limpiar la grilla
      ugScripts.ClearFilas()

      'inicializo el combo
      cmbAplicacion.SelectedIndex = -1
      cmbAplicacion.SelectedValue = "SIGA"

      Consultar()
   End Sub

   Private Sub Consultar()

      Dim reg = New Reglas.VersionesScripts()

      Dim _dtScripts = reg.GetXAplicationVersion(cmbAplicacion.Text, cmbVersionDesde.Text, cmbVersionHasta.Text)

      ugScripts.DataSource = _dtScripts
      ConfigurarGrilla()

      tbcDatos.SelectedTab = tbpScripts

      trvResultados.Nodes.Clear()
      tssRegistros.Text = ugScripts.CantidadRegistrosParaStatusbar

      tsbSincronizacionWeb.Enabled = True
   End Sub

   Private Sub ConfigurarGrilla()
      Dim pos = 0I
      With ugScripts.DisplayLayout.Bands(0)
         .Columns(Entidades.VersionScript.Columnas.IdAplicacion.ToString()).FormatearColumna("Aplicación", pos, 50, HAlign.Left, True)
         .Columns(Entidades.VersionScript.Columnas.NroVersion.ToString()).FormatearColumna("Version", pos, 70, HAlign.Left, False)
         .Columns(Entidades.VersionScript.Columnas.Orden.ToString()).FormatearColumna("Orden", pos, 30, HAlign.Right)
         .Columns(Entidades.VersionScript.Columnas.Nombre.ToString()).FormatearColumna("Nombre", pos, 300)
         .Columns(Entidades.VersionScript.Columnas.Script.ToString()).FormatearColumna("Script", pos, 420)
         .Columns(Entidades.VersionScript.Columnas.Obligatorio.ToString()).FormatearColumna("Obligatorio", pos, 35)
         .Columns(Entidades.VersionScript.Columnas.CodigoCliente.ToString()).FormatearColumna("CodigoCliente", pos, 35, , True)
      End With

      ugScripts.AgregarFiltroEnLinea({Entidades.VersionScript.Columnas.Nombre.ToString(),
                                      Entidades.VersionScript.Columnas.Script.ToString()})

   End Sub

   Private Sub HabilitaAccionesBW(habilitar As Boolean)
      tbcDatos.Enabled = habilitar
      grbFiltros.Enabled = habilitar
      tstBarra.Enabled = habilitar
      tspBarra.Visible = Not habilitar
      tspBarra.Value = 0

   End Sub

   Private Sub ImportarScriptsMasivo(archivos As IEnumerable(Of String))
      Dim stbMensaje = New StringBuilder()
      stbMensaje.AppendFormatLine("Se van a cargar {0} scripts", archivos.Count)
      stbMensaje.AppendLine()
      If cmbVersionDesde.Text <> cmbVersionHasta.Text Then
         stbMensaje.AppendFormatLine("    - Se van a borrar los script desde la versión {0} a {1}", cmbVersionDesde.Text, cmbVersionHasta.Text)
         stbMensaje.AppendLine()
      End If
      stbMensaje.AppendFormatLine("¿Desea continuar?")

      If ShowPregunta(stbMensaje.ToString(), MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
         tspBarra.Maximum = archivos.Count
         HabilitaAccionesBW(False)

         bwImportarArchivos.RunWorkerAsync(New Tuple(Of String, String, String, IEnumerable(Of String))(cmbAplicacion.Text, cmbVersionDesde.Text, cmbVersionHasta.Text, archivos))
      End If
   End Sub

#Region "Backgroud Worker ImportarScriptsMasivo"
   Private Sub bwImportarArchivos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwImportarArchivos.DoWork
      Dim params = DirectCast(e.Argument, Tuple(Of String, String, String, IEnumerable(Of String)))

      Try
         Dim regla = New Reglas.VersionesScripts()
         regla.InsertarSeleccionMultiple(params.Item1, params.Item2, params.Item3, params.Item4, Sub(i) bwImportarArchivos.ReportProgress(0, i))
      Catch ex As Exception
         bwImportarArchivos.ReportProgress(0, ex)
      End Try

   End Sub

   Private Sub bwImportarArchivos_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwImportarArchivos.ProgressChanged
      If TypeOf (e.UserState) Is Exception Then
         ShowError(DirectCast(e.UserState, Exception))
      ElseIf TypeOf (e.UserState) Is Entidades.AvanceProceso Then
         tspBarra.Value = Math.Min(DirectCast(e.UserState, Entidades.AvanceProceso).Actual, tspBarra.Maximum)
         tssInfo.Text = DirectCast(e.UserState, Entidades.AvanceProceso).Mensaje
      End If
   End Sub

   Private Sub bwImportarArchivos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwImportarArchivos.RunWorkerCompleted
      Consultar()

      HabilitaAccionesBW(True)

   End Sub
#End Region

   Private Sub SincronizarWeb()
      HabilitaAccionesBW(False)
      bwSincronizar.RunWorkerAsync(New Tuple(Of String, String, String)(cmbAplicacion.Text, cmbVersionDesde.Text, cmbVersionHasta.Text))

   End Sub

   Private Sub bwSincronizar_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwSincronizar.DoWork
      Dim params = DirectCast(e.Argument, Tuple(Of String, String, String))

      Try
         Dim reglas = New Reglas.VersionesScripts()
         Dim cantidad = reglas.Sincronizar(params.Item1, params.Item2, params.Item3, Sub(i) bwSincronizar.ReportProgress(0, i))

         e.Result = cantidad
      Catch ex As Exception
         bwSincronizar.ReportProgress(0, ex)
      End Try

   End Sub

   Private Sub bwSincronizar_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwSincronizar.ProgressChanged
      If TypeOf (e.UserState) Is Exception Then
         ShowError(DirectCast(e.UserState, Exception))
      ElseIf TypeOf (e.UserState) Is Entidades.AvanceProceso Then
         tspBarra.Maximum = DirectCast(e.UserState, Entidades.AvanceProceso).Total
         tspBarra.Value = Math.Min(DirectCast(e.UserState, Entidades.AvanceProceso).Actual, tspBarra.Maximum)
         tssInfo.Text = DirectCast(e.UserState, Entidades.AvanceProceso).Mensaje
      End If

   End Sub

   Private Sub bwSincronizar_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSincronizar.RunWorkerCompleted

      HabilitaAccionesBW(True)

      Dim cantidad = DirectCast(e.Result, Integer)

      ShowMessage(String.Format("Se sincronizaron {0} scripts de las versiones entre {1} y {2}", cantidad, cmbVersionDesde.Text, cmbVersionHasta.Text))

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         filtro.AppendFormat("Aplicación: {0}", cmbAplicacion.Text)
         filtro.AppendFormat(" - Verión Desde: {0} hasta: {1}", cmbVersionDesde.Text, cmbVersionHasta.Text)

      End With
      Return filtro.ToString()
   End Function

   'Se ocultó el botón y el textbox porque no estaría funcionando correctamente.
   ''Private Sub TesteaScripts()
   ''   Dim baseOriginal = Ayudantes.Conexiones.Base
   ''   If String.IsNullOrEmpty(tsbBase.Text) Then
   ''      Exit Sub
   ''   End If

   ''   If baseOriginal.ToUpper().Trim() = tsbBase.Text.ToUpper().Trim() Then
   ''      If ShowPregunta("CUIDADO - Va a testear los scripts sobre la base de datos actual, ¿¿¿esta seguro??!!", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
   ''         Exit Sub
   ''      End If
   ''   End If

   ''   Dim datos = DirectCast(ugScripts.DataSource, DataTable)
   ''   Dim reg = New Reglas.ScriptsAdmin()

   ''   Ayudantes.Conexiones.Base = Me.tsbBase.Text

   ''   Dim resp = reg.EjecutarScrips(datos)
   ''   Dim ultimo = String.Empty

   ''   'actualizo la grilla para saber si todos estaban bien

   ''   trvResultados.Nodes.Clear()
   ''   For Each re As Entidades.VersionScriptEjecucion In resp
   ''      If ultimo <> re.GetAplicacionVersion() Then
   ''         trvResultados.Nodes.Add(re.GetAplicacionVersion(), re.GetAplicacionVersion())
   ''      End If
   ''      trvResultados.Nodes(re.GetAplicacionVersion()).Nodes.Add(re.GetOrdenNombre()).Nodes.Add(re.GetResultado())
   ''      ultimo = re.GetAplicacionVersion()
   ''   Next

   ''   trvResultados.ExpandAll()

   ''   tbcDatos.SelectedTab = tbpResultados

   ''End Sub

#End Region

End Class
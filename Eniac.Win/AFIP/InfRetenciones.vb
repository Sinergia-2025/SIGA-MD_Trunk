Public Class InfRetenciones

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today

         _publicos.CargaComboTiposImpuestos(cmbTipoImpuesto, "RETENCION")
         _publicos.CargaComboProvincias(cmbProvincia)

         ugDetalle.AgregarTotalesSuma({"ImporteTotal"})
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimirP_Click(sender As Object, e As EventArgs) Handles tsbImprimirP.Click
      TryCatched(
      Sub()
         If ugDetalle.DataSource(Of DataTable).Empty() Then Exit Sub

         Dim dt = ugDetalle.DataSource(Of DataTable)
         Dim parm = New ReportParameterCollection(CargaFiltrosImpresion())

         Dim frmImprime = New VisorReportes("Eniac.Win.InfRetenciones.rdlc", "dsAFIP_Retenciones", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargaFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargaFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargaFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbTipoImpuesto_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoImpuesto.CheckedChanged
      TryCatched(Sub() chbTipoImpuesto.FiltroCheckedChanged(cmbTipoImpuesto))
   End Sub
   Private Sub cmbTipoImpuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoImpuesto.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbTipoImpuesto.SelectedIndex > -1 Then
            chbProvincia.Visible = cmbTipoImpuesto.SelectedValue.ToString() = Entidades.TipoImpuesto.Tipos.RIIBB.ToString()
         Else
            chbProvincia.Checked = False
            chbProvincia.Visible = False
         End If
         cmbProvincia.Visible = chbProvincia.Visible
         ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.Provincia.Columnas.IdProvincia.ToString()).Hidden = Not cmbProvincia.Visible
      End Sub)
   End Sub
   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub

#Region "Eventos Busqueda Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbTipoImpuesto.Checked And cmbTipoImpuesto.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Tipo Impuesto aunque activó ese Filtro")
            cmbTipoImpuesto.Focus()
            Exit Sub
         End If

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbProvincia.Visible AndAlso chbProvincia.Checked And cmbProvincia.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Provincia aunque activó ese Filtro")
            cmbProvincia.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today

      chbProvincia.Checked = False
      chbTipoImpuesto.Checked = False
      chbCliente.Checked = False

      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idTipoImpuesto = cmbTipoImpuesto.ValorSeleccionado(chbTipoImpuesto, Entidades.TipoImpuesto.Tipos.Ninguno.ToString()).StringToEnum(Entidades.TipoImpuesto.Tipos.Ninguno)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)

      Dim rRetenciones = New Reglas.Retenciones()
      Dim dt = rRetenciones.GetInformeRetenciones(actual.Sucursal.Id, dtpDesde.Value, dtpHasta.Value, idTipoImpuesto, idProvincia, idCliente)

      dt.Columns.Add("Ingreso", GetType(String), "'P: ' + NroPlanillaIngreso + ' - M: ' + NroMovimientoIngreso")

      Dim _tit = GetColumnasVisiblesGrilla(ugDetalle)
      ugDetalle.DataSource = dt
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub
   Private Function CargaFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      filtro.AppendFormat("Fechas: {0} hasta el {1}", dtpDesde.Text, dtpHasta.Text)
      If chbTipoImpuesto.Checked Then
         filtro.AppendFormat(" - Impuesto: {0}", cmbTipoImpuesto.Text)
      End If
      If chbProvincia.Checked And cmbProvincia.Visible And cmbProvincia.SelectedIndex > -1 Then
         filtro.AppendFormat(" - Provincia: {0}", cmbProvincia.Text.Trim())
      End If
      If chbCliente.Checked Then
         filtro.AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
      End If
      Return filtro.ToString()
   End Function

#End Region

End Class
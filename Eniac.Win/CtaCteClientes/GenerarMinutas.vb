Public Class GenerarMinutas

#Region "Campos"

   Private _publicos As Publicos
   Private _dt As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboTiposComprobantesMinutas(cmbTiposMinutas, "VENTAS", "CTACTECLIE")
            cmbTiposMinutas.SelectedIndex = 0

            _publicos.CargaComboGrupos(cmbGrupos)
            cmbGrupos.SelectedIndex = -1

            ugDetalle.AgregarTotalesSuma({"Aplicado", "Aplicado"})

         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGenerar.PerformClick()
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
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

   Private Sub tsbGenerar_Click(sender As Object, e As EventArgs) Handles tsbGenerar.Click
      TryCatched(
         Sub()
            Generar()
            ShowMessage("¡¡ Proceso Finalizado Exitosamente !!")
            RefrescarDatosGrilla()
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{}.xls", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      TryCatched(Sub() chbGrupo.FiltroCheckedChanged(cmbGrupos))
   End Sub
   Private Sub chbFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechas.CheckedChanged
      dtpDesde.Enabled = chbFechas.Checked
      dtpHasta.Enabled = chbFechas.Checked

      If chbFechas.Checked Then
         dtpDesde.Value = dtpFecha.Value.PrimerDiaMes
         dtpHasta.Value = dtpFecha.Value.UltimoDiaMes
      End If

      dtpDesde.Focus()
   End Sub
   Private Sub dtpDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDesde.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub
   Private Sub controles_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHasta.KeyDown, cmbTiposMinutas.KeyDown, cmbGrupos.KeyDown, dtpFecha.KeyDown
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Enter Then
               btnConsultar.Select()
            End If
         End Sub)
   End Sub
   Private Sub chbNroOrdenDeCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroOrdenDeCompra.CheckedChanged
      TryCatched(Sub() chbNroOrdenDeCompra.FiltroCheckedChanged(usaPermitido:=True, bscNroOrdenDeCompra))
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorClick() Handles bscNroOrdenDeCompra.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaOrdenDeCompra(bscNroOrdenDeCompra)
            Dim nroOrdenDeCompra = bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L)
            bscNroOrdenDeCompra.Datos = New Reglas.OrdenesCompra().GetPorCodigo(actual.Sucursal.Id, nroOrdenDeCompra)
         End Sub)
   End Sub

   Private Sub bscNroOrdenDeCompra_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNroOrdenDeCompra.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscNroOrdenDeCompra.Text = e.FilaDevuelta.Cells("NumeroOrdenCompra").Value.ToString()
               bscNroOrdenDeCompra.Permitido = False
               btnConsultar.Select()
            End If
         End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbNroOrdenDeCompra.Checked And Not bscNroOrdenDeCompra.Selecciono Then
               bscNroOrdenDeCompra.Select()
               ShowMessage("Activó el filtro de Nro. O. C. y no seleccionó una. Debe seleccionar una.")
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      cmbTiposMinutas.SelectedIndex = 0
      chbGrupo.Checked = False
      dtpFecha.Value = Date.Now
      chbNroOrdenDeCompra.Checked = False

      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      btnConsultar.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim grupo = cmbGrupos.ValorSeleccionado(chbGrupo, String.Empty)
      Dim fechaDesde = dtpDesde.Valor(chbFechas)
      Dim fechaHasta = dtpHasta.Valor(chbFechas)
      Dim nroOC = If(chbNroOrdenDeCompra.Checked, bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L), 0L)

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      _dt = rCtaCte.GetSaldoParaMinutas(actual.Sucursal.IdSucursal, cmbTiposMinutas.ItemSeleccionado(Of Entidades.TipoComprobante), grupo, fechaDesde, fechaHasta, nroOC)

      ugDetalle.DataSource = _dt
      tsbGenerar.Enabled = True
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Public Sub Generar()
      Dim grupo = cmbGrupos.ValorSeleccionado(chbGrupo, String.Empty)
      Dim fechaDesde = dtpDesde.Valor(chbFechas)
      Dim fechaHasta = dtpHasta.Valor(chbFechas)

      If dtpFecha.Value > Date.Now Then
         If ShowPregunta("La fecha seleccionada es mayor a la fecha actual, ¿desea continuar?") = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If
      End If

      Dim rCtaCte = New Reglas.CuentasCorrientes()
      rCtaCte.GenerarMinutas(actual.Sucursal.Id, _dt, cmbTiposMinutas.ItemSeleccionado(Of Entidades.TipoComprobante), grupo, fechaDesde, fechaHasta,
                             dtpFecha.Value, bscNroOrdenDeCompra.Text.ValorNumericoPorDefecto(0L),
                             Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Tipo de Recibo: {0}", cmbTiposMinutas.Text)

         If chbGrupo.Checked Then
            .AppendFormat(" - Grupo: {0}", cmbGrupos.Text)
         End If

         If chbFechas.Checked Then
            .AppendFormat(" - Fecha desde: {0:dd/MM/yyyy} - hasta: {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If

         If chbNroOrdenDeCompra.Checked Then
            .AppendFormat(" - Nro. O. C.: {0}", bscNroOrdenDeCompra.Text)
         End If

         .AppendFormat(" - Fecha Emisión: {0:dd/MM/yyyy}", dtpFecha.Value)
      End With

      Return filtro.ToString()
   End Function

#End Region

End Class
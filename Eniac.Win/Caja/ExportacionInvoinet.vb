Public Class ExportacionInvoinet

#Region "Constantes"

#End Region

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            RefrescarDatosGrilla()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData
         Case Keys.F5
            tsbRefrescar.PerformClick()
         Case Keys.F4
            btnConsultar.PerformClick()
         Case Else
            Return MyBase.ProcessCmdKey(msg, keyData)
      End Select
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, filtro:=String.Empty))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub txtNroOrdenPago_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNroOrdenPago.KeyUp
      If e.KeyData = Keys.Enter Then
         btnConsultar.Select()
      End If
   End Sub
   Private Sub chbNroOrdenPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroOrdenPago.CheckedChanged
      TryCatched(
         Sub()
            txtNroOrdenPago.Enabled = chbNroOrdenPago.Checked
            If Not chbNroOrdenPago.Checked Then
               txtNroOrdenPago.Text = String.Empty
            Else
               txtNroOrdenPago.Focus()
            End If
         End Sub)
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbNroOrdenPago.Checked And txtNroOrdenPago.ValorNumericoPorDefecto(0I) = 0 Then
               ShowMessage("ATENCION: NO ingreso un Nro de Orden de Pago")
               txtNroOrdenPago.Focus()
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

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbNroOrdenPago.Checked = False
      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim nroOrdenPago = txtNroOrdenPago.ValorSeleccionado(chbNroOrdenPago, 0I)
      Dim fechaDesde = dtpDesde.Valor(chbFecha)
      Dim fechaHasta = dtpHasta.Valor(chbFecha)

      Dim oCtaCteProv = New Reglas.CuentasCorrientesProvCheques()
      ugDetalle.DataSource = oCtaCteProv.GetCuentasCorrientesProvCheques(nroOrdenPago, fechaDesde, fechaHasta)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

#End Region
End Class
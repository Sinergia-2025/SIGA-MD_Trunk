Public Class ResumenDeBancos

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(
         Sub()
            ugDetalle.AgregarTotalesSuma({"IngresosPesos", "EgresosPesos", "TotalesPesos", "IngresosDolar", "EgresosDolar", "TotalesDolar"})
            ugDetalle.AgregarFiltroEnLinea({"NombreCuentaBanco"})
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancaria)
            bscCuentaBancaria.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancaria.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscCuentaBancaria.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            End If
         End Sub)
   End Sub


   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCuentaBancaria.CheckedChanged
      TryCatched(Sub() chbCuentaBancaria.FiltroCheckedChanged(bscCuentaBancaria))
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Now
      dtpHasta.Value = Date.Now
      rdbFechaMovimiento.Checked = True
      chbCuentaBancaria.Checked = False
      dtpDesde.Focus()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If dtpDesde.Value.Date > dtpHasta.Value.Date Then
               ShowMessage("Rango INVALIDO de Fechas !!")
               Exit Sub
            End If
            If chbCuentaBancaria.Checked And Not bscCuentaBancaria.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó una Cuenta Bancaria aunque activó ese Filtro.")
               bscCuentaBancaria.Focus()
               Exit Sub
            End If

            Dim idCuentaBancaria = 0I

            If bscCuentaBancaria.Enabled Then
               idCuentaBancaria = Integer.Parse(bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())
            End If

            Dim rLibroBancos = New Reglas.LibroBancos()
            Dim dt = rLibroBancos.ResumenDeBanco(actual.Sucursal.Id, idCuentaBancaria,
                                                 dtpDesde.Value, dtpHasta.Value,
                                                 rdbFechaMovimiento.Checked)

            ugDetalle.DataSource = dt

            If dt.Rows.Count = 0 Then
               MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter) From
               {
                  New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion),
                  New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre),
                  New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion())
               }

            Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
            Dim frmImprime = New VisorReportes("Eniac.Win.ResumenDeBancos.rdlc", "DataSetBancos_ResumenDeBancos", dt, parm, True, 1) With
               {
                  .Text = Me.Text,
                  .WindowState = FormWindowState.Maximized
               }
            frmImprime.Show()
         End Sub)
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtros = New StringBuilder()
      filtros.AppendFormat("Fecha de {2}: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text, If(rdbFechaMovimiento.Checked, "Movimiento", "Planilla"))
      If chbCuentaBancaria.Checked Then
         filtros.AppendFormat(" - Cuenta: {0}", bscCuentaBancaria.Text)
      End If
      Return filtros.ToString()
   End Function
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

#End Region

End Class
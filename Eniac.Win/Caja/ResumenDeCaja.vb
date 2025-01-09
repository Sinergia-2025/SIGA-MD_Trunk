Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ResumenDeCaja

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.InicializaCajas()

         Me.chbAgrupado.Checked = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(Sub() InicializaCajas())
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

      Try
         Dim frmImprime As VisorReportes

         If Me.cmbCajas.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Caja")
            Me.cmbCajas.Focus()
            Exit Sub
         End If

         If Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
            MessageBox.Show("Rango INVALIDO de Fechas !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim oCajaDet As New Reglas.CajaDetalles

         Dim dt As DataTable

         dt = oCajaDet.ResumenDeCaja(cmbSucursal.GetSucursales(),
                                     Me.cmbCajas.GetCajas(),   'IdCaja,
                                     Me.dtpDesde.Value, Me.dtpHasta.Value,
                                     Me.rdbFechaMovimiento.Checked)

         If dt.Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Me.CargarFiltrosImpresion()))

         If chbAgrupado.Checked Then
            frmImprime = New VisorReportes("Eniac.Win.ResumenDeCaja.rdlc", "DataSetCaja_ResumenDeCaja", dt, parm, True, 1) '# 1 = Cantidad de Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.ResumenDeCajaSinGrupo.rdlc", "DataSetCaja_ResumenDeCaja", dt, parm, True, 1) '# 1 = Cantidad de Copias
         End If

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub InicializaCajas()
      Me.cmbCajas.Inicializar(Me.cmbSucursal.GetSucursales(), blnMiraUsuario:=True, blnMiraPC:=False, blnCajasModificables:=False, permiteSinSeleccion:=False)
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()

      With filtro
         Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         Me.cmbCajas.CargarFiltrosImpresionCajaNombres(filtro, False, True)

         .AppendFormat(" / Rango de Fechas: Desde {0} Hasta {1} ", dtpDesde.Text, dtpHasta.Text)

         .AppendFormat(" / Fecha de: {0}", IIf(Me.rdbFechaMovimiento.Checked, "Movimiento", "Planilla").ToString())

      End With

      Return filtro.ToString()

   End Function

#End Region

End Class
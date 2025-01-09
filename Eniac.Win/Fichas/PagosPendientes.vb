Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class PagosPendientes

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.dtpDesde.Value = DateTime.Now.AddMonths(-1)
      Me.dtpHasta.Value = DateTime.Now

      Me._publicos.CargaComboEmpleados(Me.cmbCobradores, Eniac.Entidades.Publicos.TiposEmpleados.COMPRADOR)
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
      Try
         Dim IdCob As Integer = 0

         Dim nombreCob As String = String.Empty

         Me.Cursor = Cursors.WaitCursor

         Dim oFPagos As Eniac.Reglas.FichasPagos = New Eniac.Reglas.FichasPagos()

         If Me.chbConCobrador.Checked Then
            If Me.cmbCobradores.SelectedIndex <> -1 Then
               IdCob = DirectCast(Me.cmbCobradores.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
               nombreCob = Me.cmbCobradores.Text
            End If
         End If

         Dim dt As DataTable = oFPagos.GetPagosPendientes(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Me.dtpDesde.Value, Me.dtpHasta.Value, IdCob)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", Me.dtpDesde.Value.ToString("dd/MM/yyyy HH:mm:ss")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", Me.dtpHasta.Value.ToString("dd/MM/yyyy HH:mm:ss")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreCobrador", nombreCob))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.PagosPendientes.rdlc", "SistemaDataSet_PagosPendientes", dt, parm, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Pagos Pendientes"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub chbConCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbConCobrador.CheckedChanged
      Me.cmbCobradores.Enabled = Me.chbConCobrador.Checked
   End Sub

#End Region

End Class
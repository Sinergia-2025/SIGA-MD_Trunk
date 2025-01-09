Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class FichasEmitidas

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.dtpDesde.Value = DateTime.Now
      Me.dtpHasta.Value = DateTime.Now

      Me._publicos.CargaComboEmpleados(Me.cmbCobradores, Eniac.Entidades.Publicos.TiposEmpleados.COMPRADOR)
      Me._publicos.CargaComboEmpleados(Me.cmbVendedores, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)

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

         Dim IdVen As Integer = 0

         Dim nombreVen As String = String.Empty
         Me.Cursor = Cursors.WaitCursor

         Dim oFPagos As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()

         If Me.chbConCobrador.Checked Then
            If Me.cmbCobradores.SelectedIndex <> -1 Then
               IdCob = DirectCast(Me.cmbCobradores.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
               nombreCob = Me.cmbCobradores.Text
            End If
         End If

         If Me.chkConVendedor.Checked Then
            If Me.cmbVendedores.SelectedIndex <> -1 Then
               IdVen = DirectCast(Me.cmbVendedores.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
               nombreVen = Me.cmbVendedores.Text
            End If
         End If

         Dim dt As DataTable = oFPagos.GetEmitidas(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Me.dtpDesde.Value, Me.dtpHasta.Value, IdCob, IdVen, Me.chkAnuladas.Checked)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", Me.dtpDesde.Value.ToString("dd/MM/yyyy HH:mm:ss")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", Me.dtpHasta.Value.ToString("dd/MM/yyyy HH:mm:ss")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreCobrador", nombreCob))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreVendedor", nombreVen))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.FichasEmitidas.rdlc", "SistemaDataSet_FichasEmitidas", dt, parm, 1) '# 1 = Cantidad de Copias
         frmImprime.Text = "Fichas Emitidas"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub chbConCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbConCobrador.CheckedChanged
      Me.cmbCobradores.Enabled = Me.chbConCobrador.Checked
   End Sub
   Private Sub chkConVendedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConVendedor.CheckedChanged
      Me.cmbVendedores.Enabled = Me.chkConVendedor.Checked
   End Sub

#End Region

End Class
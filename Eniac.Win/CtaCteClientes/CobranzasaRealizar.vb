Option Strict On
Option Explicit On

Imports actual = Eniac.Entidades.Usuario.Actual


Public Class CobranzasaRealizar

#Region "Campos"

    Private _publicos As Publicos

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)

        Try
            Me._publicos = New Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
            'que significa el select index'

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

#End Region

#Region "Eventos"

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

            If dgvDetalle.Rows.Count > 0 Then
                Me.btnConsultar.Focus()
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.chbVendedor.Checked = False
         Me.chbFechasVencimiento.Checked = False
         Me.dtpVencimientoDesde.Value = Date.Now
         Me.dtpVencimientoHasta.Value = Date.Now
         Me.txtTotal.Text = ""
         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         Dim Filtros As String = String.Empty
         Dim Filtros1 As String = String.Empty

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            Filtros = "Vendedor: " & Me.cmbVendedor.Text
         End If

         
         If Me.chbFechasVencimiento.Checked Then
            Filtros1 = "Fechas: desde " & Me.dtpVencimientoDesde.Text & " hasta " & Me.dtpVencimientoHasta.Text
         End If

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros1", Filtros1))

         Dim frmImprime As VisorReportes

         frmImprime = New VisorReportes("Eniac.Win.CobranzasaRealizar.rdlc", "SistemaDataSet_CobranzasaRealizar", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub


   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chkFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFechasVencimiento.CheckedChanged

      Me.dtpVencimientoDesde.Enabled = Me.chbFechasVencimiento.Checked
      Me.dtpVencimientoHasta.Enabled = Me.chbFechasVencimiento.Checked

      If Me.chbFechasVencimiento.Checked Then
         Me.dtpVencimientoDesde.Value = Date.Now
         Me.dtpVencimientoHasta.Value = Date.Now
      End If

      Me.dtpVencimientoDesde.Focus()

   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim decTotal As Decimal = 0

      Dim IdVendedor As Integer = 0
    
      Dim Desde As Date = Nothing
      Dim Hasta As Date = Nothing

      Try

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.chbFechasVencimiento.Checked Then
            Desde = Me.dtpVencimientoDesde.Value
            Hasta = Me.dtpVencimientoHasta.Value
         End If

         Dim reg As Reglas.CuentasCorrientesPagos

         reg = New Reglas.CuentasCorrientesPagos()

         Me.dgvDetalle.DataSource = reg.GetDetalleCobranzas(actual.Sucursal.Id, Desde, Hasta, IdVendedor)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

            decTotal += Decimal.Parse(dr.Cells("Importe").Value.ToString())

         Next

         txtTotal.Text = decTotal.ToString("$ #,##0.00")

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try


   End Sub


#End Region


End Class
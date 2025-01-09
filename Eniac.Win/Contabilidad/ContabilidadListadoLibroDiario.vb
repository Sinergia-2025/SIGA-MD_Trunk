Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid

Public Class ContabilidadListadoLibroDiario

#Region "Campos"

   Private _publicos As ContabilidadPublicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New ContabilidadPublicos()

      Me._publicos.CargaComboPlanes(Me.cmbPlan, False)
      Me._publicos.CargarSucursalesACheckListBox(Me.clbSucursales)

      Me.CargarValoresIniciales()

   End Sub

#End Region

#Region "Eventos"

   Private Sub ContabilidadListadoLibroDiario_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Me.RefrescarDatos()
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Me.Cursor = Cursors.WaitCursor

         Dim Sucursales As String = String.Empty
         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales += ", " + DirectCast(ite, Entidades.Sucursal).Nombre
         Next
         If Sucursales.Length > 0 Then Sucursales = Sucursales.Substring(2)

         Dim dt As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Sucursales))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion()))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.rptLibroDiario.rdlc", "dtsLibroDiario_dtLibroDiario", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.rvReporte.DocumentMapCollapsed = True
         frmImprime.Size = New Size(780, 600)
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Me.CargaGrillaDetalle()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      Me.dtpHasta.Value = Date.Now
   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
         Dim oReporteLibroDiario As New Entidades.ContabilidadReporte

         Dim fDesde As Date?
         Dim fHasta As Date?
         Dim idPlan As Integer = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())

         Dim Sucursales As List(Of Integer) = New List(Of Integer)
         For Each ite As Object In Me.clbSucursales.CheckedItems
            Sucursales.Add(DirectCast(ite, Entidades.Sucursal).Id)
         Next

         If dtpDesde.Checked Then fDesde = dtpDesde.Value
         If dtpHasta.Checked Then fHasta = dtpHasta.Value

         oReporteLibroDiario = reg.LibroDiario(fDesde, fHasta, idPlan, Sucursales.ToArray())

         Dim dtsLibroDiario As New dtsLibroDiario
         dtsLibroDiario.Tables("dtLibroDiario").Merge(oReporteLibroDiario.LibroDiario)

         Me.ugDetalle.DataSource = oReporteLibroDiario.LibroDiario

         Me.formatearGrilla()

         If oReporteLibroDiario.LibroDiario Is Nothing OrElse oReporteLibroDiario.LibroDiario.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos para los filtros seleccionados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub RefrescarDatos()

      Dim Cont As Integer

      For Cont = 0 To clbSucursales.Items.Count - 1
         'Siempre marco la actual
         If DirectCast(Me.clbSucursales.Items.Item(Cont), Entidades.Sucursal).Id = actual.Sucursal.Id Then
            Me.clbSucursales.SetItemChecked(Cont, True)
         Else
            Me.clbSucursales.SetItemChecked(Cont, False)
         End If
      Next

      Me.dtpHasta.Value = Now
      Me.cmbPlan.SelectedIndex = 0

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = " 0 Registros"

   End Sub

   Private Function ValidarFiltros() As Boolean
      If CInt(Me.cmbPlan.SelectedValue) = -1 Then
         MessageBox.Show("Debe Seleccionar un plan de cuentas para visualizar el listado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbPlan.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub formatearGrilla()

      Me.ugDetalle.Rows.ExpandAll(True)

      For Each col As UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
         col.CellActivation = UltraWinGrid.Activation.ActivateOnly
      Next

   End Sub

#End Region

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro
         If clbSucursales.CheckedItems.Count > 0 Then
            Dim Sucursales As String = String.Empty
            For Each ite As Object In Me.clbSucursales.CheckedItems
               Sucursales += ", " + DirectCast(ite, Entidades.Sucursal).Nombre
            Next
            Sucursales = Sucursales.Trim().Trim(","c)
            .AppendFormat("Suc.: {0} - ", Sucursales)
         End If

         If cmbPlan.SelectedIndex >= 0 Then
            .AppendFormat("Plan: {0} - ", cmbPlan.Text)
         End If

         .AppendFormat("Fecha ")
         If dtpDesde.Checked Then
            .AppendFormat("desde: {0:d} - ", dtpDesde.Value)
         End If
         If dtpHasta.Checked Then
            .AppendFormat("hasta: {0:d} - ", dtpHasta.Value)
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

End Class
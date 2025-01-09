Option Explicit On
Option Strict Off

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win
Imports Eniac.Reglas
Imports Eniac.Entidades
Imports System.Windows.Forms

Public Class ResumenAnualPorMoneda

#Region "Propiedades"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()

         Me._publicos.CargaComboMonedas(Me.cmbMonedas)

         Me.txtAnio.Text = Date.Now.Year.ToString()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click

      Me.Close()

   End Sub

   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

      Try

         If Me.cmbMonedas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar una Moneda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMonedas.Focus()
            Exit Sub
         End If

         If Me.txtAnio.Text.Trim.Length <> 4 Then
            MessageBox.Show("ATENCION: Debe indicar un Año válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtAnio.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim rLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
         Dim Filtros As String = String.Empty

         Dim dtRes As DataTable = rLibroBancos.ResumenAnualPorMoneda(actual.Sucursal.Id, _
                                                                     Integer.Parse(Me.cmbMonedas.SelectedValue.ToString()), _
                                                                     Integer.Parse(Me.txtAnio.Text))

         If dtRes.Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtAnio.Focus()
            Exit Sub
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Filtros = "Moneda: " & Me.cmbMonedas.Text & " - Año: " & Me.txtAnio.Text

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ResumenAnualPorMoneda.rdlc", "SistemaDataSet_ResumenAnual", dtRes, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

#End Region

   Private Sub btnImprimir1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir1.Click
      Try

         If Me.cmbMonedas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar una Moneda", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMonedas.Focus()
            Exit Sub
         End If

         If Me.txtAnio.Text.Trim.Length <> 4 Then
            MessageBox.Show("ATENCION: Debe indicar un Año válido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtAnio.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim rLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
         Dim Filtros As String = String.Empty

         Dim dtRes As DataTable = rLibroBancos.ResumenAnualPorMoneda(actual.Sucursal.Id, _
                                                                     Integer.Parse(Me.cmbMonedas.SelectedValue.ToString()), _
                                                                     Integer.Parse(Me.txtAnio.Text))

         If dtRes.Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtAnio.Focus()
            Exit Sub
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Filtros = "Moneda: " & Me.cmbMonedas.Text & " - Año: " & Me.txtAnio.Text

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ResumenAnualPorMoneda.rdlc", "SistemaDataSet_ResumenAnual", dtRes, parm, True,1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class
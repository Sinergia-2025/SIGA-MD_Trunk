Option Explicit On
Option Strict Off

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win
Imports Eniac.Reglas
Imports Eniac.Entidades
Imports System.Windows.Forms

Public Class ResumenAnualVA

#Region "Propiedades"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()

         Me.LoadComboAnio()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancaria)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancaria.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancaria.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCuentaBancaria.Text = e.FilaDevuelta.Cells("NombreCuenta").Value
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

      Try

         If Me.bscCuentaBancaria.FilaDevuelta Is Nothing Then
            MessageBox.Show("ATENCION: Selecione una Cuenta Bancaria.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCuentaBancaria.Focus()
            Exit Sub
         End If

         If Me.cmbAnios.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe indicar un Año.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbAnios.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim rLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
         Dim Filtros As String = String.Empty

         Dim dtRes As DataTable = rLibroBancos.ResumenAnual(actual.Sucursal.Id, _
                                                            Integer.Parse(Me.cmbAnios.Text), _
                                                            1,
                                                            Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value)

         If dtRes.Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbAnios.Focus()
            Exit Sub
         End If


         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Filtros = "Nombre de Cuenta: " & Me.bscCuentaBancaria.Text & " - Año: " & Me.cmbAnios.Text

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ResumenAnual.rdlc", "SistemaDataSet_ResumenAnual", dtRes, parm, True, 1) '# 1 = Cantidad Copias

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

   Private Sub LoadComboAnio()

      Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
      Me.cmbAnios.DataSource = oLibroBancos.GetAniosDeLibro(actual.Sucursal.Id)
      Me.cmbAnios.ValueMember = "Anio"
      Me.cmbAnios.DisplayMember = "Anio"

      Me.cmbAnios.SelectedValue = -1

   End Sub

#End Region

   Private Sub btnImprimir1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir1.Click
      Try

         If Me.bscCuentaBancaria.FilaDevuelta Is Nothing Then
            MessageBox.Show("ATENCION: Selecione una Cuenta Bancaria.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCuentaBancaria.Focus()
            Exit Sub
         End If

         If Me.cmbAnios.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe indicar un Año.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbAnios.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim rLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
         Dim Filtros As String = String.Empty

         Dim dtRes As DataTable = rLibroBancos.ResumenAnual(actual.Sucursal.Id, _
                                                            Integer.Parse(Me.cmbAnios.Text), _
                                                            1,
                                                            Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value)

         If dtRes.Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbAnios.Focus()
            Exit Sub
         End If


         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Filtros = "Nombre de Cuenta: " & Me.bscCuentaBancaria.Text & " - Año: " & Me.cmbAnios.Text

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ResumenAnual.rdlc", "SistemaDataSet_ResumenAnual", dtRes, parm, True, 1) '# 1 = Cantidad de Copias

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
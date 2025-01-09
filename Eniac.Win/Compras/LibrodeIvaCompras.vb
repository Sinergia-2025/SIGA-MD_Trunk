Option Explicit On
Option Strict On
Imports Eniac.Entidades
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class LibrodeIvaCompras

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.dtpPeriodoFiscal.Value = Today.PrimerDiaMes()

      Me._publicos.CargaComboEmpleados(Me.cmbCompradores, Entidades.Publicos.TiposEmpleados.COMPRADOR)

   End Sub

#End Region

#Region "Eventos"

   Private Sub chkConVendedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConVendedor.CheckedChanged
      Me.cmbCompradores.Enabled = Me.chkConVendedor.Checked
   End Sub

   Private Sub chkVersionFinal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVersionFinal.CheckedChanged

      Try

         If chkVersionFinal.Checked Then

            Me.txtNumeroInicialHoja.Text = Reglas.Publicos.NroHojaLibroIvaCompras.ToString()

            Me.chkConVendedor.Checked = False

         Else

            Me.txtNumeroInicialHoja.Text = ""

         End If

         Me.txtNumeroInicialHoja.Enabled = Me.chkVersionFinal.Checked
         Me.txtNumeroInicialHoja.IsRequired = Me.chkVersionFinal.Checked

         'Me.dtpPeriodoFiscal.Enabled = Not chkVersionFinal.Checked
         Me.chkConVendedor.Enabled = Not chkVersionFinal.Checked

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         chkVersionFinal.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Try

         Dim idEmpresa As Integer = actual.Sucursal.IdEmpresa
         Dim PeriodoFiscal As Integer = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))

         Dim IdComprador As Integer = 0

         Dim nombreComprador As String = String.Empty

         Dim Filtros As String
         Dim NumeroDeHoja As Integer = 1


         'If me.dtpDesde.Value > me.dtpHasta.Value Then
         '   MessageBox.Show("Rango INVALIDO de FECHAS !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

         Dim oCompras As Reglas.Compras = New Reglas.Compras()

         Filtros = "Filtros: Periodo: " & Me.dtpPeriodoFiscal.Value.ToString("MMMMM") & " " & Me.dtpPeriodoFiscal.Value.ToString("yyyy")

         If Me.chkConVendedor.Checked And Me.cmbCompradores.SelectedIndex <> -1 Then
            IdComprador = DirectCast(Me.cmbCompradores.SelectedItem, Entidades.Empleado).IdEmpleado
            nombreComprador = Me.cmbCompradores.Text
            Filtros = Filtros & " // Comprador: " & IdComprador & " - " & nombreComprador
         End If

         If chkVersionFinal.Checked Then

            If Not String.IsNullOrEmpty(txtNumeroInicialHoja.Text.ToString()) Then
               NumeroDeHoja = Integer.Parse(txtNumeroInicialHoja.Text)
            End If

            Filtros = "Periodo: " & Me.dtpPeriodoFiscal.Value.ToString("MMMMM") & " " & Me.dtpPeriodoFiscal.Value.ToString("yyyy")

         End If

         If NumeroDeHoja <= 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("Numero de Hoja Inicial es INVALIDO !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Dim Orden As String
         If optPorFecha.Checked Then
            Orden = "FECHA"
         Else
            Orden = "PROVINCIA"
         End If

         Dim dt As DataTable

         dt = oCompras.GetLibroDeIVA(idEmpresa, PeriodoFiscal, Orden, IdComprador)

         If dt.Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            If MessageBox.Show("NO hay registros que cumplan con la seleccion!! Desea imprimir de todas maneras?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
               Me.dtpPeriodoFiscal.Focus()
               Exit Sub
            Else
               Dim drCl As DataRow
               drCl = dt.NewRow()

               drCl("BaseImponibleNoGrabado") = 0
               drCl("BaseImponible") = 0
               drCl("Alicuota") = 0
               drCl("Importe") = 0
               drCl("ImportePercepcion") = 0
               drCl("ImporteTotal") = 0


               'drCl("Neto") = 0
               'drCl("NetoNoGravado") = 0
               'drCl("Iva210") = 0
               'drCl("Iva270") = 0
               'drCl("Iva105") = 0
               'drCl("PercepcionIVA") = 0
               'drCl("PercepcionIB") = 0
               'drCl("PercepcionGanancias") = 0
               'drCl("PercepcionVarias") = 0
               'drCl("ImporteTotal") = 0

               dt.Rows.Add(drCl)

            End If
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PaginaInicial", NumeroDeHoja.ToString()))

         'Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.LibrodeIvaCompras.rdlc", "SistemaDataSet_Compras", dt, parm, True)
         Dim frmImprime As VisorReportes
         Dim strReporte As String = String.Empty

         If optPorFecha.Checked Then
            strReporte = "LibrodeIvaCompras.rdlc"
         Else
            strReporte = "LibrodeIvaCompras_PorProvincias.rdlc"
         End If

         frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_Compras", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         If chkVersionFinal.Checked Then
            Me.Cursor = Cursors.Default
            If MessageBox.Show("El Libro Mensual de I.V.A. fue impreso correctamente ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Reglas.Publicos.NroHojaLibroIvaCompras = NumeroDeHoja + frmImprime.rvReporte.LocalReport.GetTotalPages()
               Me.Close()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
   End Sub
End Class
#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class KardexComprobCtaCteClientes

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", "CTACTE", "SI")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Dim aTipoFactura As ArrayList = New ArrayList
         aTipoFactura.Insert(0, "A")
         aTipoFactura.Insert(1, "B")
         aTipoFactura.Insert(2, "C")
         aTipoFactura.Insert(3, "E")
         aTipoFactura.Insert(4, "M")
         aTipoFactura.Insert(5, "R")
         aTipoFactura.Insert(6, "X")
         Me.cboLetra.DataSource = aTipoFactura
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub KardexComprobCtaCteClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         RefrescarDatosGrilla()
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.cmbTiposComprobantes.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar un Tipo de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         If Me.cboLetra.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar una Letra de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboLetra.Focus()
            Exit Sub
         End If

         If Integer.Parse("0" & Me.txtEmisor.Text) = 0 Then
            MessageBox.Show("ATENCION: Es obligatorio digitar un Emisor de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtEmisor.Focus()
            Exit Sub
         End If

         If Integer.Parse("0" & Me.txtNumero.Text) = 0 Then
            MessageBox.Show("ATENCION: Es obligatorio digitar un Numero de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If KardexComprobCtaCteClientesUC1.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         MostrarCantidadRegistros(0)
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbImprimir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir2.Click
      Try

         If KardexComprobCtaCteClientesUC1.Count = 0 Then Exit Sub

         Dim Filtros As String = CargarFiltrosImpresion()

         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes

         frmImprime = New VisorReportes("Eniac.Win.KardexComprobCtaCteClientes.rdlc", "SistemaDataSet_CuentasCorrientesPagos", KardexComprobCtaCteClientesUC1.dtDetalle, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If KardexComprobCtaCteClientesUC1.Count = 0 Then Exit Sub

         Dim Titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion()

         Me.UltraGridPrintDocument1.Grid = DirectCast(KardexComprobCtaCteClientesUC1, IUserControlConUltraGrid).Grilla

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"
         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text
         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If KardexComprobCtaCteClientesUC1.Count = 0 Then Exit Sub
         KardexComprobCtaCteClientesUC1.Exportar(String.Format("{0}.xls", Me.Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If KardexComprobCtaCteClientesUC1.Count = 0 Then Exit Sub
         KardexComprobCtaCteClientesUC1.Exportar(String.Format("{0}.pdf", Me.Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.cmbTiposComprobantes.SelectedIndex = -1
      Me.cboLetra.SelectedIndex = -1
      Me.txtEmisor.Text = ""
      Me.txtNumero.Text = ""

      KardexComprobCtaCteClientesUC1.RefrescarDatosGrilla()
      MostrarCantidadRegistros()

   End Sub

   Private Sub CargaGrillaDetalle()
      Try
         KardexComprobCtaCteClientesUC1.CargaGrillaDetalle(actual.Sucursal.Id,
                                                           cmbTiposComprobantes.SelectedValue.ToString(),
                                                           cboLetra.SelectedValue.ToString(),
                                                           Short.Parse(Me.txtEmisor.Text),
                                                           Long.Parse(Me.txtNumero.Text))

         MostrarCantidadRegistros(KardexComprobCtaCteClientesUC1.Count)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro

         filtro.AppendFormat("Comprobante: {0} {1} {2:0000}-{3:00000000}", cmbTiposComprobantes.Text, cboLetra.Text, Short.Parse(Me.txtEmisor.Text), Long.Parse(Me.txtNumero.Text))

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub MostrarCantidadRegistros()
      MostrarCantidadRegistros(KardexComprobCtaCteClientesUC1.Count)
   End Sub
   Private Sub MostrarCantidadRegistros(cantidad As Integer)
      Me.tssRegistros.Text = String.Format("{0} Registros", cantidad)
   End Sub

#End Region

End Class
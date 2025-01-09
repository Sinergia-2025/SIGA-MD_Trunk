Option Explicit On
Option Strict On

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual
'Imports Eniac.Win
'Imports Eniac.Reglas
'Imports Eniac.Entidades
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

#End Region

Public Class InfAccesosDeUsuarios

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         Me.CargaGrillaDetalle()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         '-.PE-31629.-
         Me._publicos.CargaComboNombrePC(Me.cmbNombrePC)

         '-.PE-31628.-
         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreUsuario", "NombrePC", "Observacion"})

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfAccesosDeUsuarios_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbUsuario.Checked Then
            Filtros = "Usuario: " & Me.cmbUsuario.Text
         End If

         '-.PE-31629.-
         If Me.chbNombrePC.Checked Then
            Filtros = "NombrePC: " & Me.cmbNombrePC.Text
         End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraPrintPreviewDialog1.Name = Me.Text
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

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
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

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   '-.PE-31629.-
   Private Sub chbNombrePC_CheckedChanged(sender As Object, e As EventArgs) Handles chbNombrePC.CheckedChanged
      Try
         Me.cmbNombrePC.Enabled = Me.chbNombrePC.Checked

         If Not Me.chbNombrePC.Checked Then
            Me.cmbNombrePC.SelectedIndex = -1
         Else
            If Me.cmbNombrePC.Items.Count > 0 Then
               Me.cmbNombrePC.SelectedIndex = 0
            End If
         End If

         Me.cmbNombrePC.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         'If Me.chbCaja.Checked And Me.cmbCajas.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó una Caja aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbCajas.Focus()
         '   Exit Sub
         'End If

         'If Me.chbCuentaDeCaja.Checked And Not Me.bscCuentaCaja.Selecciono And Not Me.bscNombreCuentaCaja.Selecciono Then
         '   MessageBox.Show("ATENCION: NO seleccionó una Cuenta aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.bscCuentaCaja.Focus()
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   'Private Sub ugDetalle_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton

   '   If e.Cell.Column.Index = 0 And e.Cell.Row.Index <> -1 Then

   '      Try

   '         Me.Cursor = Cursors.WaitCursor

   '         Dim CDetalle As CajaDetalles = New CajaDetalles()

   '         CDetalle.Operacion = Reglas.CajaDetalles.TipoOperacion.Consulta
   '         CDetalle.NumeroPlanilla = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroPlanilla").Value.ToString())
   '         CDetalle.NroDeMovimiento = Integer.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroMovimiento").Value.ToString())
   '         CDetalle.btnAceptar.Visible = False

   '         CDetalle.ShowDialog()


   '      Catch ex As Exception
   '         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Finally
   '         Me.Cursor = Cursors.Default
   '      End Try
   '   End If

   'End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbUsuario.Checked = False
      Me.chbNombrePC.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreCaja").Hidden = False
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oCajaDet As Reglas.UsuariosAccesos = New Reglas.UsuariosAccesos()

         Dim IdUsuario As String = String.Empty

         Dim IdPC As String = String.Empty

         If Me.cmbUsuario.Enabled Then
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
            'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreCaja").Hidden = True
         End If

         '-.PE-31629.-
         If Me.cmbNombrePC.Enabled Then
            IdPC = Me.cmbNombrePC.SelectedValue.ToString()
         End If

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oCajaDet.GetPorRangoFechas(actual.Sucursal.Id,
                                                Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                IdUsuario, IdPC)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("NombreSucursal") = dr("NombreSucursal").ToString()
            drCl("FechaAcceso") = Date.Parse(dr("FechaAcceso").ToString()).Date
            drCl("HoraAcceso") = Date.Parse(dr("FechaAcceso").ToString()).ToString("HH:mm")
            drCl("IdUsuario") = dr("IdUsuario").ToString()
            drCl("NombreUsuario") = dr("NombreUsuario").ToString()
            drCl("NombrePC") = dr("NombrePC").ToString()
            drCl("Exitoso") = Boolean.Parse(dr("Exitoso").ToString())
            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreSucursal", System.Type.GetType("System.String"))
         .Columns.Add("FechaAcceso", System.Type.GetType("System.DateTime"))
         .Columns.Add("HoraAcceso", System.Type.GetType("System.String"))
         .Columns.Add("IdUsuario", System.Type.GetType("System.String"))
         .Columns.Add("NombreUsuario", System.Type.GetType("System.String"))
         .Columns.Add("NombrePC", System.Type.GetType("System.String"))
         .Columns.Add("Exitoso", System.Type.GetType("System.Boolean"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

#End Region

End Class
Option Strict Off
Imports Infragistics.Win.UltraWinGrid

Public Class InfCajonesHectolitros

   Private _filtroProductos As MFProductos
   Private _filtroLocalidades As MFLocalidades
   Private _filtroZonasGeograficas As MFZonasGeograficas
   Private _filtroTiposComprobantes As MFTipoComprobantes
   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._filtroProductos = New MFProductos()
         Me._filtroLocalidades = New MFLocalidades()
         Me._filtroZonasGeograficas = New MFZonasGeograficas()
         Me._filtroTiposComprobantes = New MFTipoComprobantes(True, Eniac.Entidades.TipoComprobante.Tipos.VENTAS, "")
         Me._publicos = New Publicos()
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboTransportistas(Me.cmbTransportistas)
         Me.cmbTransportistas.SelectedIndex = -1
         Me._publicos.CargaComboTipoClientes(Me.cmbTiposClientes)
         Me.cmbTiposClientes.SelectedIndex = -1
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.txtDias.Text = ""

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
         Me.dgvDetalle.DisplayLayout.Bands(0).Summaries.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub InfVentasDetallePorProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + Eniac.Entidades.Usuario.Actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Dim nombreWS As String = "InfCajonesHectolitros"
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim wb As Infragistics.Documents.Excel.Workbook = New Infragistics.Documents.Excel.Workbook(Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
               wb.Worksheets.Add(nombreWS)
               wb.Worksheets(nombreWS).Rows(0).Cells(0).Value = Me.Text +
                                                                           " desde el " +
                                                                           Me.dtpDesde.Text +
                                                                           " hasta el " + Me.dtpHasta.Text
               wb.Worksheets(nombreWS).Rows(1).Cells(0).Value = Me.lblDias.Text + ": " + Me.txtDias.Text
               If Me.chbVendedor.Checked Then
                  wb.Worksheets(nombreWS).Rows(2).Cells(0).Value = "Vendedor: " + Me.cmbVendedor.Text
               End If
               If Me.chbTransportista.Checked Then
                  wb.Worksheets(nombreWS).Rows(3).Cells(0).Value = "Transportista: " + Me.cmbTransportistas.Text
               End If
               Me.UltraGridExcelExporter1.Export(Me.dgvDetalle, wb.Worksheets(nombreWS), 4, 0)
               wb.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.dgvDetalle, Me.sfdExportar.FileName, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If Me.dgvDetalle.DataSource IsNot Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
            Me.dgvDetalle.DisplayLayout.Bands(0).Summaries.Clear()
         End If
         Me.txtDias.Text = ""

         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         Dim totalFila As Decimal = 0
         Dim valorCampo As Decimal = 0
         Dim columnasDias As Integer = 0
         Dim columnasNoFechas As List(Of String) = New List(Of String)()

         Dim IdVendedor As Integer = 0
    
         Dim idTransportista As Integer = 0
         Dim idTipoCliente As Integer = 0
         Dim muestraImportes As Boolean = False

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
         End If

         If Me.chbTransportista.Checked Then
            idTransportista = DirectCast(Me.cmbTransportistas.SelectedItem, Eniac.Entidades.Transportista).idTransportista
         End If

         If Me.chbTipoCliente.Checked Then
            idTipoCliente = DirectCast(Me.cmbTiposClientes.SelectedItem, Eniac.Entidades.TipoCliente).IdTipoCliente
         End If

         muestraImportes = Me.chbMuestraImportes.Checked

         Dim dt As DataTable = oVentas.GetCajonesHectolitros(Me.dtpDesde.Value,
                                                        Me.dtpHasta.Value,
                                                        Me._filtroProductos.Filtros,
                                                        Me._filtroLocalidades.Filtros,
                                                        Me._filtroTiposComprobantes.Filtros,
                                                        IdVendedor,
                                                        idTransportista,
                                                        idTipoCliente,
                                                        muestraImportes)

         If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("No existen datos para la selección.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         dt.Columns.Add("Tipo", System.Type.GetType("System.String"))
         dt.Columns.Add("Total", System.Type.GetType("System.Decimal"))
         dt.Columns.Add("Promedio", System.Type.GetType("System.Decimal"))

         columnasDias = dt.Columns.Count - 8

         columnasNoFechas.Add("idproducto")
         columnasNoFechas.Add("nombreproducto")
         columnasNoFechas.Add("tamano")
         columnasNoFechas.Add("presentacion")
         columnasNoFechas.Add("nombreMarca")
         columnasNoFechas.Add("Tipo")
         columnasNoFechas.Add("Total")
         columnasNoFechas.Add("Promedio")

         Dim dtfinal As DataTable = dt.Clone()
         Dim drfinal As DataRow

         If Me.chbMuestraImportes.Checked Then
            For Each dr As DataRow In dt.Rows
               totalFila = 0
               drfinal = dtfinal.NewRow()
               drfinal.ItemArray = dr.ItemArray
               drfinal("Tipo") = ""
               For i As Integer = 0 To dt.Columns.Count - 1
                  If columnasNoFechas.Contains(dt.Columns(i).ColumnName) Then
                     Continue For
                  End If
                  If Not String.IsNullOrEmpty(drfinal(i).ToString()) AndAlso Not String.IsNullOrEmpty(drfinal("tamano").ToString()) Then
                     drfinal(i) = Decimal.Parse(drfinal(i).ToString())
                  End If
                  If Decimal.TryParse(drfinal(i).ToString(), valorCampo) Then
                     totalFila += valorCampo
                  End If
               Next
               drfinal("Total") = Decimal.Round(totalFila, 2)
               drfinal("Promedio") = Decimal.Round(totalFila / columnasDias, 2)
               dtfinal.Rows.Add(drfinal)
            Next
         Else
            For Each dr As DataRow In dt.Rows
               'calculo los cajones ----------------------------------------------------------------------------
               totalFila = 0
               drfinal = dtfinal.NewRow()
               drfinal.ItemArray = dr.ItemArray
               drfinal("Tipo") = "Cajones/Pack"
               For i As Integer = 0 To dt.Columns.Count - 1
                  If columnasNoFechas.Contains(dt.Columns(i).ColumnName) Then
                     Continue For
                  End If
                  If Not String.IsNullOrEmpty(drfinal(i).ToString()) AndAlso Not String.IsNullOrEmpty(drfinal("presentacion").ToString()) Then
                     drfinal(i) = Decimal.Parse(drfinal(i).ToString()) / Decimal.Parse(drfinal("presentacion").ToString())
                  End If
                  If Decimal.TryParse(drfinal(i).ToString(), valorCampo) Then
                     totalFila += valorCampo
                  End If
               Next
               drfinal("Total") = Decimal.Round(totalFila, 2)
               drfinal("Promedio") = Decimal.Round(totalFila / columnasDias, 2)
               dtfinal.Rows.Add(drfinal)

               'calculo los hectolitros ----------------------------------------------------------------------------
               totalFila = 0
               drfinal = dtfinal.NewRow()
               drfinal.ItemArray = dr.ItemArray
               drfinal("Tipo") = "Hectolitros"
               For i As Integer = 0 To dt.Columns.Count - 1
                  If columnasNoFechas.Contains(dt.Columns(i).ColumnName) Then
                     Continue For
                  End If
                  If Not String.IsNullOrEmpty(drfinal(i).ToString()) AndAlso Not String.IsNullOrEmpty(drfinal("tamano").ToString()) Then
                     drfinal(i) = Decimal.Parse(drfinal(i).ToString()) * Decimal.Parse(drfinal("tamano").ToString()) / 100
                  End If
                  If Decimal.TryParse(drfinal(i).ToString(), valorCampo) Then
                     totalFila += valorCampo
                  End If
               Next
               drfinal("Total") = Decimal.Round(totalFila, 2)
               drfinal("Promedio") = Decimal.Round(totalFila / columnasDias, 2)
               dtfinal.Rows.Add(drfinal)
            Next
         End If

         Me.dgvDetalle.DataSource = dtfinal
         Me.dgvDetalle.Rows.ExpandAll(True)

         Dim columnToSummarize As UltraGridColumn
         Dim summary As SummarySettings

         For i As Integer = 0 To dt.Columns.Count - 1
            If columnasNoFechas.Contains(dt.Columns(i).ColumnName) Then
               Continue For
            End If
            columnToSummarize = Me.dgvDetalle.DisplayLayout.Bands(0).Columns(dt.Columns(i).ColumnName)

            summary = Me.dgvDetalle.DisplayLayout.Bands(0).Summaries.Add(dt.Columns(i).ColumnName,
                                                                        SummaryType.Sum,
                                                                        columnToSummarize)
            summary.DisplayFormat = "{0:N2}"
            summary.Appearance.TextHAlign = HAlign.Right

            Me.dgvDetalle.DisplayLayout.Bands(0).Columns(dt.Columns(i).ColumnName).Format = "##0.00"
            Me.dgvDetalle.DisplayLayout.Bands(0).Columns(dt.Columns(i).ColumnName).CellAppearance.TextHAlign = HAlign.Right
         Next

         'sumo el total de los totales
         columnToSummarize = Me.dgvDetalle.DisplayLayout.Bands(0).Columns("Total")

         summary = Me.dgvDetalle.DisplayLayout.Bands(0).Summaries.Add("Total",
                                                                     SummaryType.Sum,
                                                                     columnToSummarize)
         summary.DisplayFormat = "{0:N2}"
         summary.Appearance.TextHAlign = HAlign.Right

         'saco el promedio de los promedios
         columnToSummarize = Me.dgvDetalle.DisplayLayout.Bands(0).Columns("Promedio")

         summary = Me.dgvDetalle.DisplayLayout.Bands(0).Summaries.Add("Promedio",
                                                                     SummaryType.Average,
                                                                     columnToSummarize)
         summary.DisplayFormat = "{0:N2}"
         summary.Appearance.TextHAlign = HAlign.Right

         Me.dgvDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
         Me.txtDias.Text = columnasDias.ToString()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompleto.CheckedChanged
      Try

         If chkMesCompleto.Checked Then
            Me.dtpDesde.Value = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 dia.
            Me.dtpHasta.Value = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception
         Me.chkMesCompleto.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkFiltroPorProductos_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroPorProductos.LinkClicked
      Try
         Me._filtroProductos.ShowDialog()
         If Me._filtroProductos.Filtros.Count = 0 Then
            Me.lnkFiltroPorProductos.Text = "Todos los productos"
         Else
            Me.lnkFiltroPorProductos.Text = "Algunos productos"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Try
         Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

         If Not Me.chbVendedor.Checked Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            If Me.cmbVendedor.Items.Count > 0 Then
               Me.cmbVendedor.SelectedIndex = 0
            End If
         End If

         Me.cmbVendedor.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTransportista.CheckedChanged
      Try
         Me.cmbTransportistas.Enabled = Me.chbTransportista.Checked

         If Not Me.chbTransportista.Checked Then
            Me.cmbTransportistas.SelectedIndex = -1
         Else
            If Me.cmbTransportistas.Items.Count > 0 Then
               Me.cmbTransportistas.SelectedIndex = 0
            End If
         End If

         Me.cmbTransportistas.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkFiltroLocalidades_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroLocalidades.LinkClicked
      Try
         Me._filtroLocalidades.ShowDialog()
         If Me._filtroLocalidades.Filtros.Count = 0 Then
            Me.lnkFiltroLocalidades.Text = "Todas las localidades"
         Else
            Me.lnkFiltroLocalidades.Text = "Algunas localidades"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTipoCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTipoCliente.CheckedChanged
      Try
         Me.cmbTiposClientes.Enabled = Me.chbTipoCliente.Checked

         If Not Me.chbTipoCliente.Checked Then
            Me.cmbTiposClientes.SelectedIndex = -1
         Else
            If Me.cmbTiposClientes.Items.Count > 0 Then
               Me.cmbTiposClientes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposClientes.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkFiltroZonas_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroZonas.LinkClicked
      Try
         Me._filtroZonasGeograficas.ShowDialog()
         If Me._filtroZonasGeograficas.Filtros.Count = 0 Then
            Me.lnkFiltroZonas.Text = "Todas las zonas geográficas"
         Else
            Me.lnkFiltroZonas.Text = "Algunas zonas geográficas"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub lnkFiltroTiposComprobantes_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFiltroTiposComprobantes.LinkClicked
      Try
         Me._filtroTiposComprobantes.ShowDialog()
         If Me._filtroTiposComprobantes.Filtros.Count = 0 Then
            Me.lnkFiltroTiposComprobantes.Text = "Todos los comprobantes"
         Else
            Me.lnkFiltroTiposComprobantes.Text = "Algunos comprobantes"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class
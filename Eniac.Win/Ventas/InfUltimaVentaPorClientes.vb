Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Public Class InfUltimaVentaPorClientes

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "Telefono", "Direccion", "CorreoElectronico", "CorreoAdministrativo", "Celular"})

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfUltimaVentaClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
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

   'Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Try

   '      If Me.ugdUltimaVenta.Rows.Count = 0 Then Exit Sub

   '      Dim Titulo As String

   '      Titulo = Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine

   '      Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
   '      Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
   '      Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
   '      Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
   '      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
   '      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
   '      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
   '      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
   '      Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
   '      'Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
   '      Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

   '      Me.UltraPrintPreviewDialog1.ShowDialog()
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

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

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
       Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim excelExport As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.xls", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbTipoComprobante.Checked Then
            .AppendFormat(" Tipo de Comprobante: {0} - ", Me.cmbTiposComprobantes.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim excelExport As UltraGridExportarPDF = New UltraGridExportarPDF(UltraGridDocumentExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.pdf", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs)
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
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
         Me.bscCliente.Enabled = Me.chbCliente.Checked


         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty

         Me.bscCodigoCliente.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbCliente.Checked = False
      Me.chbTipoComprobante.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim TotalNeto As Decimal = 0
         Dim TotalImpuestos As Decimal = 0
         Dim Total As Decimal = 0

         Dim IdCliente As Long = 0

         Dim IdTipoComprobante As String = String.Empty
         Dim NumeroComprobante As Long = 0

         Dim IdFormasPago As Integer = 0
         Dim IdUsuario As String = String.Empty


         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         Dim dt As DataTable

         dt = oVenta.GetUltimaVentaCliente(actual.Sucursal.Id, Me.dtpDesde.Value, Me.dtpHasta.Value, IdCliente, IdTipoComprobante)

         Me.ugDetalle.DataSource = dt

         'Me.dgvDetalle.Columns("colCAE").Visible = Publicos.TieneModuloFacturacionElectronica
         'Me.dgvDetalle.Columns("colCAEVencimiento").Visible = Publicos.TieneModuloFacturacionElectronica

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
         .Columns.Add("Ver")
         .Columns.Add("Imprimir")
         .Columns.Add("VerEstandar")
         .Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("TipoDocCliente", System.Type.GetType("System.String"))
         .Columns.Add("NroDocCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("CantidadInvocados", System.Type.GetType("System.Int32"))
         .Columns.Add("CantidadLotes", System.Type.GetType("System.Int32"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         '.Columns.Add("IdTipoMovimiento", System.Type.GetType("System.String"))
         '.Columns.Add("NumeroMovimiento", System.Type.GetType("System.Int64"))
         '.Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("CAE", System.Type.GetType("System.String"))
         .Columns.Add("CAEVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("MercDespachada", System.Type.GetType("System.Boolean"))

      End With

      Return dtTemp

   End Function

#End Region

End Class
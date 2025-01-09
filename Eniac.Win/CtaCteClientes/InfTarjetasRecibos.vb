Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfTarjetasRecibos

#Region "Campos"

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = True
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)
         Me.cmbCajas.SelectedIndex = -1

         Me._publicos.CargaComboBancos(Me.cmbBanco)

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "CTACTECLIE")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         Me.CargarColumnasASumar()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfTarjetasPorVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text

         If Me.cmbCajas.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Caja: " & Me.cmbCajas.Text
         End If

         If Me.txtNumero.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Numero: " & Me.txtNumero.Text
         End If

         If Me.cmbBanco.Enabled Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Banco: " & Me.cmbBanco.Text
         End If

         If Me.chbCliente.Checked And Me.bscCodigoCliente.Selecciono Or bscCliente.Selecciono Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         'If Filtros.Length > 0 Then Filtros = "Filtros: " & Filtros

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
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

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbBanco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbBanco.CheckedChanged
      If Not Me.chbBanco.Checked Then
         Me.cmbBanco.SelectedIndex = -1
      End If
      Me.cmbBanco.Enabled = Me.chbBanco.Checked
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
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
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
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

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged

      Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

      If Not Me.chbTipoComprobante.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      Else
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If
      End If

      Me.cmbTiposComprobantes.Focus()

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
      End If

      Me.cmbVendedor.Focus()

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

   Private Sub chbMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception

         chbMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbCuentaBancaria_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbCuentaBancaria.CheckedChanged
      Me.bscCuentaBancaria.Enabled = Me.chbCuentaBancaria.Checked
      If Me.chbCuentaBancaria.Checked Then
         Me.bscCuentaBancaria.Focus()
      Else
         Me.bscCuentaBancaria.Text = ""
         Me.bscCuentaBancaria.Tag = Nothing
      End If
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

         If Not Me.bscCuentaBancaria.FilaDevuelta Is Nothing Then

            Me.bscCuentaBancaria.Text = Me.bscCuentaBancaria.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancaria.Tag = Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
            Me.bscCuentaBancaria.Enabled = False

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCaja.CheckedChanged
      Try
         If Not Me.chbCaja.Checked Then
            Me.cmbCajas.SelectedIndex = -1
         Else
            Me.cmbCajas.Focus()
         End If
         Me.cmbCajas.Enabled = Me.chbCaja.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCaja.Checked And Me.cmbCajas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Caja aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCajas.Focus()
            Exit Sub
         End If

         If Me.chbBanco.Checked And Me.cmbBanco.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Banco aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbBanco.Focus()
            Exit Sub
         End If

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
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

      Me.chbMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbCaja.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.chbUsuario.Checked = False
      Me.chbNumero.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbBanco.Checked = False
      Me.chbCliente.Checked = False
      Me.chbCuentaBancaria.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oTarjetas As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()

      Dim IdCaja As Integer = 0
      Dim IdCuentaBancaria As Integer = 0

      Dim FechaCobroDesde As Date = Nothing
      Dim FechaCobroHasta As Date = Nothing
      Dim FechaEnCarteraAl As Date = Nothing

      Dim Numero As Long = 0
      Dim IdBanco As Integer = 0
      Dim IdLocalidad As Integer = 0

      Dim IdCliente As Long = 0
      Dim IdVendedor As Integer = 0

      Dim Titular As String = String.Empty
      Dim IdTipoComprobante As String = String.Empty
      Dim NumeroCupon As Long = 0
      Dim IdUsuario As String = String.Empty

      Try

         If Me.chbCaja.Checked Then
            IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
         End If

         If Me.chbNumero.Checked Then
            Numero = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.chbBanco.Checked Then
            IdBanco = Integer.Parse(Me.cmbBanco.SelectedValue.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.chbNumero.Checked Then
            NumeroCupon = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.chbCuentaBancaria.Checked Then
            IdCuentaBancaria = Integer.Parse(Me.bscCuentaBancaria.Tag.ToString())
         End If

         If Me.cmbUsuario.Enabled Then
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oTarjetas.GetTarjetasRecibos(actual.Sucursal.Id, _
                                                  IdCaja, _
                                                  Me.dtpDesde.Value, Me.dtpHasta.Value, _
                                                  Me.cmbGrabanLibro.Text, _
                                                  IdCliente, _
                                                  IdTipoComprobante, _
                                                  NumeroCupon, _
                                                  IdUsuario, _
                                                  IdBanco, _
                                                  IdCuentaBancaria, _
                                                  IdVendedor)


         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            'drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCaja") = dr("NombreCaja").ToString()
            drCl("IdTarjeta") = Integer.Parse(dr("IdTarjeta").ToString())
            drCl("NombreTarjeta") = dr("NombreTarjeta").ToString()
            drCl("IdBanco") = Integer.Parse(dr("IdBanco").ToString())
            drCl("NombreBanco") = dr("NombreBanco").ToString()
            drCl("Cuotas") = Integer.Parse(dr("Cuotas").ToString())
            drCl("NumeroCupon") = Integer.Parse(dr("NumeroCupon").ToString())
            drCl("Monto") = Decimal.Parse(dr("Monto").ToString())
            drCl("IdUsuario") = dr("IdUsuario").ToString()
            drCl("IdCuentaBancaria") = Integer.Parse(dr("IdBanco").ToString())
            drCl("NombreCuenta") = dr("NombreCuenta").ToString()

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

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim columnToSummarize As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Monto")
      Dim summary As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Monto", SummaryType.Sum, columnToSummarize)
      summary.DisplayFormat = "{0:N2}"
      summary.Appearance.TextHAlign = HAlign.Right

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         '.Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCaja", System.Type.GetType("System.String"))
         .Columns.Add("IdTarjeta", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreTarjeta", System.Type.GetType("System.String"))
         .Columns.Add("IdBanco", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreBanco", System.Type.GetType("System.String"))
         .Columns.Add("Cuotas", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroCupon", System.Type.GetType("System.Int32"))
         .Columns.Add("Monto", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdUsuario", System.Type.GetType("System.String"))
         .Columns.Add("IdCuentaBancaria", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreCuenta", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

#End Region

End Class
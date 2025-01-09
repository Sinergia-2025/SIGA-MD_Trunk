#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class OrganizarRepartos

#Region "Campos"

   Private _publicos As Publicos
   Private _filtros As List(Of Entidades.Venta)

   Private dtDetalle As DataTable
   Private dtComprobantes As DataTable
   Private dtProductoConsolidado As DataTable
   Private dtProducto As DataTable

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try

         Me._publicos = New Publicos()
         Me._filtros = New List(Of Entidades.Venta)()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 0

         Me.cmbMercDespachada.Items.Insert(0, "TODOS")
         Me.cmbMercDespachada.Items.Insert(1, "SI")
         Me.cmbMercDespachada.Items.Insert(2, "NO")
         Me.cmbMercDespachada.SelectedIndex = 2

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1
         'Tengo que hacerlo en el Insertar porque da error... no entiendo porque no existe las columnas!!
         'Me.CargarColumnasASumar()

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         Me.ugProductos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton

         Me.ugProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True


         ugDetalle.AgregarTotalesSuma({"ImporteTotal"})
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreVendedor"})

         tbcDetalle.SelectedTab = tbpComprobantes
         ugComprobantes.AgregarTotalesSuma({"ImporteTotal"})
         ugComprobantes.AgregarFiltroEnLinea({"NombreCliente", "NombreVendedor"})

         tbcDetalle.SelectedTab = tbpProductos
         ugProductos.AgregarTotalesSuma({"Kilos", "Cantidad", "Retornable"})
         ugProductos.AgregarFiltroEnLinea({"NombreProducto"})

         tbcDetalle.SelectedTab = tbpDetalle

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region

#Region "Eventos"

   Private Sub ConsolidarComprobantesPorProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         MuestraCantidadRegistros()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugProductos.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         'Dim TipoDocVendedor As String
         'Dim NroDocVendedor As String

         'Filtros = "Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text

         'If Me.chbVendedor.Checked Then
         '   TipoDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).TipoDocEmpleado
         '   NroDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).NroDocEmpleado
         '   Filtros = Filtros & " / Vendedor: " & TipoDocVendedor & " " & NroDocVendedor & " - " & Me.cmbVendedor.Text
         'End If

         'If Me.cmbTipoDoc.SelectedIndex >= 0 And Me.bscCodigoCliente.Text.Length > 0 Then
         '   Filtros = Filtros & " / Cliente: " & Me.cmbTipoDoc.Text & " " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         'End If

         'If Me.chbMarca.Checked Then
         '   Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
         'End If

         'If Me.chbRubro.Checked Then
         '   Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
         'End If

         'If Me.chbSubRubro.Checked Then
         '   Filtros += " / SubRubro: " & Me.cmbSubRubro.Text
         'End If

         'If Me.chbProducto.Checked Then
         '   Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto.Text & " - " & Me.bscProducto.Text
         'End If

         'If Me.chbPromediar.Checked Then
         '   Filtros = Filtros & " / Promedio Dias: " & Me.lblPromediar.Text
         'End If

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
         Me.UltraGridPrintDocument1.FitWidthToPages = 1  'Fuerzo el Ancho en uno por la observacion, tal vez haya que quitar ese campo.

         If Me.tbcDetalle.SelectedTab Is tbpComprobantes Then
            Me.UltraGridPrintDocument1.Grid = Me.ugComprobantes
         Else
            If Me.tbcDetalle.SelectedTab Is tbpProductos Then
               Me.UltraGridPrintDocument1.Grid = Me.ugProductos
            End If
         End If

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
               Me.UltraGridExcelExporter1.Export(Me.ugProductos, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
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
               Me.UltraGridDocumentExporter1.Export(Me.ugProductos, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbConsolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsolidado.Click
      Try
         If dtProducto Is Nothing OrElse dtProducto.Rows.Count = 0 Then Exit Sub
         Dim nroReparto As Integer
         Dim transportista As String
         Dim fechaEnvio As DateTime
         Dim imprimir As Boolean = False

         Using ID As IngresoDatosReparto = New IngresoDatosReparto()
            If ID.ShowDialog() = Windows.Forms.DialogResult.OK Then
               nroReparto = ID.NroReparto
               transportista = ID.Transportista.ToString()
               fechaEnvio = ID.FechaEnvio

               DespacharComprobantes(ID.Transportista, ID.FechaEnvio, ID.NroReparto)
               imprimir = True
            Else
               Exit Sub
            End If
         End Using

         If imprimir Then
            Dim importe As ImpresionReparto = New ImpresionReparto(Text)
            importe.Imprimir(dtProducto, nroReparto, transportista, fechaEnvio, optOrdenarPorCodigo.Checked)
         End If

         Me.btnConsultar.PerformClick()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos CheckBox Filtros"
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

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
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

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
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

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged

      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region

#Region "Eventos CheckBox"
   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         For Each dr As DataRow In dtDetalle.Rows
            dr("Seleccionar") = chbTodos.Checked
         Next
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugProductos.Rows.ExpandAll(True)
      Else
         Me.ugProductos.Rows.CollapseAll(True)
      End If
   End Sub
#End Region

#Region "Eventos Búsquedas Foraneas"
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
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
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
#End Region

#Region "Eventos Botones"
   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         tbcDetalle.SelectedTab = tbpDetalle
         chbTodos.Checked = False

         If GetCantidadRegistrosDetalle() > 0 Then
            Me.chbTodos.Enabled = True
            If GetCantidadRegistrosDetalle() = 1 Then
               chbTodos.Checked = True
               Me.btnInsertar.Focus()
            Else
               ugDetalle.Focus()
            End If
         Else
            Me.chbTodos.Enabled = False
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If
      Catch ex As Exception
         MuestraCantidadRegistros(0)
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click

      Dim _CantidadAgregados As Integer
      If GetCantidadRegistrosDetalle() = 0 Then Exit Sub

      Try
         Me.Cursor = Cursors.WaitCursor
         ugDetalle.UpdateData()

         Dim drCl As DataRow = Nothing

         MostrarAvance("Copiando comprobantes seleccionados...")
         For Each dr As DataRow In dtDetalle.Select("Seleccionar")
            'Si ya fué seleccionado no lo cargo.
            If dtComprobantes.Select(String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                                   dr("IdSucursal"), dr("IdtipoComprobante"), dr("Letra"), dr("CentroEmisor"), dr("NumeroComprobante"))).Length > 0 Then
               Continue For
            End If
            dtComprobantes.ImportRow(dr)
            _CantidadAgregados += 1

            dr.Delete()
         Next

         dtDetalle.AcceptChanges()
         dtComprobantes.AcceptChanges()

         Me.ugComprobantes.DataSource = dtComprobantes
         Me.CargaGrillaProductos()

         MuestraCantidadRegistros()

         ShowMessage(String.Format("Se agregaron {0} Comprobantes", _CantidadAgregados))
      Catch ex As Exception
         dtDetalle.RejectChanges()
         dtComprobantes.RejectChanges()
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
         MostrarAvance("")
      End Try

   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

      Try
         Me.Cursor = Cursors.WaitCursor
         Dim drCompronte As DataRow = GetRowComprobante()
         If drCompronte Is Nothing Then Exit Sub

         If ShowPregunta(String.Format("¿Esta seguro de Quitar el Comprobante: {0} {1} {2:0000} {3:00000000}?",
                                       drCompronte("DescripcionAbrev"),
                                       drCompronte("Letra"),
                                       drCompronte("CentroEmisor"),
                                       drCompronte("NumeroComprobante"))) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Dim blnMuestraCartel As Boolean = False

         dtDetalle.ImportRow(drCompronte)
         drCompronte.Delete()

         dtComprobantes.AcceptChanges()
         dtDetalle.AcceptChanges()

         MuestraCantidadRegistros()

         Me.CargaGrillaProductos()

         If Me.ugProductos.Rows.Count = 0 Then
            Me.chkExpandAll.Enabled = False
            Me.chkExpandAll.Checked = False
         End If

      Catch ex As Exception
         dtComprobantes.RejectChanges()
         dtDetalle.RejectChanges()
         Me.Cursor = Cursors.Default
         ShowError(ex)
      Finally
         MostrarAvance("")
      End Try

   End Sub
#End Region

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim dr As DataRow = GetRowDetalle(e.Cell)
         'Verifico que algo esté seleccionado
         If dr Is Nothing Then Exit Sub

         Select Case e.Cell.Column.Key
            Case "Ver"
               Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
               Dim oComprobante As Entidades.Venta

               oComprobante = oVentas.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                             dr("IdTipoComprobante").ToString(),
                                             dr("Letra").ToString(),
                                             Short.Parse(dr("CentroEmisor").ToString()),
                                             Long.Parse(dr("NumeroComprobante").ToString()))

               Dim oImpr As Impresion = New Impresion(oComprobante)
               Dim blnReporteEstandar As Boolean = False
               If oComprobante.Impresora.TipoImpresora = "NORMAL" Then
                  oImpr.ImprimirComprobanteNoFiscal(True, blnReporteEstandar)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If

            Case "CantidadInvocados"
               If Not IsNumeric(dr("colCantidadInvocados")) Then Exit Sub

               Using oComprobantesInvocados As FacturablesInvocados = New FacturablesInvocados(Integer.Parse(dr("IdSucursal").ToString()),
                                                                                               dr("IdTipoComprobante").ToString(),
                                                                                               dr("Letra").ToString(),
                                                                                               Short.Parse(dr("CentroEmisor").ToString()),
                                                                                               Long.Parse(dr("NumeroComprobante").ToString()))
                  oComprobantesInvocados.ShowDialog()
               End Using
            Case "CantidadLotes"
               If Not IsNumeric(dr("colCantidadLotes")) Then Exit Sub

               Using cl As ConsultarLotes = New ConsultarLotes(Integer.Parse(dr("IdSucursal").ToString()),
                                                               dr("IdTipoComprobante").ToString(),
                                                               dr("Letra").ToString(),
                                                               Short.Parse(dr("CentroEmisor").ToString()),
                                                               Long.Parse(("NumeroComprobante").ToString()),
                                                               0)
                  cl.ShowDialog()
               End Using
            Case Else
         End Select

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      MuestraCantidadRegistros()
   End Sub

#End Region

#Region "Métodos"

#Region "Métodos Búsquedas Foraneas"
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub
#End Region

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbNumero.Checked = False
      Me.chbCliente.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbAfectaCaja.SelectedIndex = 0
      Me.cmbMercDespachada.SelectedIndex = 2
      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbFormaPago.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      'Limpio las Grillas.

      Me.tbcDetalle.SelectedTab = Me.tbpProductos
      Me.optOrdenarPorNombre.Checked = True
      If Not Me.ugProductos.DataSource Is Nothing Then
         DirectCast(Me.ugProductos.DataSource, DataTable).Rows.Clear()
      End If

      Me.tbcDetalle.SelectedTab = Me.tbpComprobantes
      If Not Me.ugComprobantes.DataSource Is Nothing Then
         DirectCast(Me.ugComprobantes.DataSource, DataTable).Rows.Clear()
      End If

      Me.tbcDetalle.SelectedTab = Me.tbpDetalle
      dtDetalle.Clear()
      dtComprobantes.Clear()
      If dtProductoConsolidado IsNot Nothing Then dtProductoConsolidado.Clear()

      Me.chbTodos.Checked = False
      Me.chbZonaGeografica.Checked = False

      Me._filtros.Clear()

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

         Dim IdVendedor As Integer = 0

         Dim IdFormasPago As Integer = 0
         Dim IdUsuario As String = String.Empty
         Dim IdZonaGeografica As String = String.Empty

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.chbNumero.Checked Then
            NumeroComprobante = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbFormaPago.Enabled Then
            IdFormasPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.cmbUsuario.Enabled Then
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If


         Dim dt As DataTable
         Dim drCl As DataRow

         dt = oVenta.GetConsolidadoComprobantePorProductos(actual.Sucursal.Id, _
                                              Me.dtpDesde.Value, Me.dtpHasta.Value, _
                                              IdVendedor,
                                              Me.cmbGrabanLibro.Text, _
                                              IdCliente, _
                                              Me.cmbAfectaCaja.Text, _
                                              IdTipoComprobante, _
                                              NumeroComprobante, _
                                              IdFormasPago, _
                                              IdUsuario, , , , Me.cmbMercDespachada.Text, , ,
                                              IdZonaGeografica)

         dtDetalle = Me.CrearDT()
         dtComprobantes = Me.CrearDT()

         For Each dr As DataRow In dt.Rows
            drCl = dtDetalle.NewRow()

            drCl("Seleccionar") = False
            drCl("Ver") = "..."

            drCl("TipoImpresora") = dr("TipoImpresora").ToString()
            drCl("IdSucursal") = dr("IdSucursal").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())

            If dr("IdEstadoComprobante").ToString() <> "ANULADO" Then
               drCl("NombreCliente") = dr("NombreCliente").ToString()
            Else
               drCl("NombreCliente") = "** COMPROBANTE ANULADO **"
            End If

            drCl("NombreVendedor") = dr("NombreVendedor").ToString()

            drCl("Direccion") = dr("Direccion").ToString()

            drCl("FormaDePago") = dr("FormaDePago").ToString()

            If Integer.Parse(dr("CantidadInvocados").ToString()) > 0 Then
               drCl("CantidadInvocados") = Integer.Parse(dr("CantidadInvocados").ToString())
            End If

            If Integer.Parse(dr("CantidadLotes").ToString()) > 0 Then
               drCl("CantidadLotes") = Integer.Parse(dr("CantidadLotes").ToString())
            End If

            drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
            drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("Usuario") = dr("Usuario").ToString()
            drCl("MercDespachada") = Boolean.Parse(dr("MercDespachada").ToString())
            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica").ToString()
            drCl("Observacion") = dr("Observacion").ToString()

            dtDetalle.Rows.Add(drCl)

            TotalNeto = TotalNeto + Decimal.Parse(drCl("SubTotal").ToString())
            TotalImpuestos = TotalImpuestos + Decimal.Parse(drCl("TotalImpuestos").ToString())
            Total = Total + Decimal.Parse(drCl("ImporteTotal").ToString())

         Next

         ugDetalle.DataSource = dtDetalle
         ugComprobantes.DataSource = dtComprobantes

         If dtProducto IsNot Nothing Then dtProducto.Clear()
         If dtProductoConsolidado IsNot Nothing Then dtProductoConsolidado.Clear()

         MuestraCantidadRegistros()

         If GetCantidadRegistrosDetalle() > 0 Then
            Me.chbTodos.Enabled = True
            If GetCantidadRegistrosDetalle() = 1 Then
               chbTodos.Checked = True
            Else
               ugDetalle.Focus()
            End If
         Else
            Me.chbTodos.Enabled = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub CargaGrillaProductos()
      Try
         'Dim blnInsertar As Boolean
         Dim rVentasProductos As Reglas.VentasProductos = New Reglas.VentasProductos()
         Dim drProducto As DataRow
         Dim drCol As DataRow()

         dtProductoConsolidado = CrearDT3()
         dtProducto = CrearDT2()

         'For Each dr As DataRow In dtComprobantes.Rows
         '   dtTempProductos = rVentasProductos.GetDetalleParaOrganizarRepartos(Integer.Parse(dr("IdSucursal").ToString()),
         '                                                                      dr("IdTipoComprobante").ToString(), dr("Letra").ToString(),
         '                                                                      Short.Parse(dr("CentroEmisor").ToString()), Long.Parse(dr("NumeroComprobante").ToString()))

         MostrarAvance("Obteniendo los productos de los comprobantes seleccionados...")

         rVentasProductos.FillDetalleParaOrganizarRepartos(dtComprobantes, dtProducto)

         MostrarAvance("Consolidando los productos de los comprobantes seleccionados...")

         For Each drTempProductos As DataRow In dtProducto.Rows
            'blnInsertar = True

            drCol = dtProductoConsolidado.Select(String.Format("IdProducto = '{0}'", drTempProductos("IdProducto")))

            If drCol.Length > 0 Then
               drProducto = drCol(0)
            Else
               drProducto = dtProductoConsolidado.NewRow()
               drProducto("NombreMarca") = drTempProductos("NombreMarca")
               drProducto("NombreRubro") = drTempProductos("NombreRubro")
               drProducto("IdProducto") = drTempProductos("IdProducto")
               drProducto("NombreProducto") = drTempProductos("NombreProducto")
               drProducto("Cantidad") = 0
               drProducto("Retornable") = 0
               drProducto("Kilos") = 0
               dtProductoConsolidado.Rows.Add(drProducto)
            End If

            drProducto("Cantidad") = Decimal.Parse(drProducto("Cantidad").ToString()) + Decimal.Parse(drTempProductos("Cantidad").ToString())
            If Boolean.Parse(drTempProductos("EsRetornable").ToString()) Then
               drProducto("Retornable") = Decimal.Parse(drProducto("Retornable").ToString()) + Decimal.Parse(drTempProductos("Cantidad").ToString())
            End If
            drProducto("Kilos") = Decimal.Parse(drProducto("Kilos").ToString()) + Decimal.Parse(drTempProductos("Kilos").ToString())
         Next

         'dtProducto.Merge(dtTempProductos, True, MissingSchemaAction.Ignore)

         'Next

         Me.ugProductos.DataSource = dtProductoConsolidado

         Me.chkExpandAll.Enabled = (Me.ugProductos.Rows.Count > 0)
         chkExpandAll.Checked = False
         Me.chkExpandAll.Checked = (Me.ugProductos.Rows.Count > 0)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub DespacharComprobantes(trasportista As Entidades.Transportista, fechaEnvio As Date, nroReparto As Integer)
      Dim rVentasProductos As Reglas.VentasProductos = New Reglas.VentasProductos()
      rVentasProductos.DespacharComprobantes(dtComprobantes, trasportista, fechaEnvio, nroReparto)
   End Sub

#Region "Métodos CrearDT"
   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Seleccionar", GetType(Boolean))
         .Columns.Add("Ver")
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("CantidadInvocados", System.Type.GetType("System.Int32"))
         .Columns.Add("CantidadLotes", System.Type.GetType("System.Int32"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("MercDespachada", System.Type.GetType("System.Boolean"))
         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))

         .Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Friend Shared Function CrearDT2() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Short))
         .Columns.Add("NumeroComprobante", GetType(Long))

         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("DireccionCompleta", GetType(String))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("IdLocalidad", GetType(Integer))
         .Columns.Add("NombreLocalidad", GetType(String))
         .Columns.Add("IdProvincia", GetType(String))
         .Columns.Add("NombreProvincia", GetType(String))

         .Columns.Add("Orden", GetType(Integer))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))

         .Columns.Add("Cantidad", GetType(Decimal))
         .Columns.Add("Kilos", GetType(Decimal))

         .Columns.Add("EsRetornable", GetType(Boolean))

         .Columns.Add("IdMarca", GetType(Integer))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("IdRubro", GetType(Integer))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("Telefono", GetType(String))
         .Columns.Add("TipoDocCliente", GetType(String))
         .Columns.Add("NroDocCliente", GetType(String))
      End With
      Return dtTemp

   End Function

   Friend Shared Function CrearDT3() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("Cantidad", GetType(Decimal))
         .Columns.Add("Kilos", GetType(Decimal))
         .Columns.Add("Retornable", GetType(Decimal))
      End With

      Return dtTemp

   End Function
#End Region

#Region "Métodos GetRow"
   Private Function GetRowDetalle(cell As UltraGridCell) As DataRow
      If cell IsNot Nothing AndAlso cell.Row IsNot Nothing Then
         Return GetRowDetalle(cell.Row)
      End If
      Return Nothing
   End Function
   Private Function GetRowDetalle(dr As UltraGridRow) As DataRow
      If dr.ListObject IsNot Nothing AndAlso
         TypeOf (dr.ListObject) Is DataRowView AndAlso
         DirectCast(dr.ListObject, DataRowView).Row IsNot Nothing Then
         Return DirectCast(dr.ListObject, DataRowView).Row
      End If
      Return Nothing
   End Function
   Private Function GetRowComprobante() As DataRow
      Dim dr As UltraGridRow
      If ugComprobantes.ActiveRow IsNot Nothing Then
         dr = ugComprobantes.ActiveRow
         If dr.ListObject IsNot Nothing AndAlso
            TypeOf (dr.ListObject) Is DataRowView AndAlso
            DirectCast(dr.ListObject, DataRowView).Row IsNot Nothing Then
            Return DirectCast(dr.ListObject, DataRowView).Row
         End If
      End If
      Return Nothing
   End Function
#End Region
#Region "Métodos CantidadRegistros"
   Private Function GetCantidadRegistros(dt As DataTable) As Integer
      Dim cantidad As Integer = 0
      If dt IsNot Nothing Then
         cantidad = dt.Rows.Count
      End If
      Return cantidad
   End Function
   Private Function GetCantidadRegistrosDetalle() As Integer
      Return GetCantidadRegistros(dtDetalle)
   End Function
   Private Function GetCantidadRegistrosComprobantes() As Integer
      Return GetCantidadRegistros(dtComprobantes)
   End Function
   Private Function GetCantidadRegistrosProductos() As Integer
      Return GetCantidadRegistros(dtProductoConsolidado)
   End Function
#End Region
#Region "Métodos MostrarCantidades"
   Private Sub MuestraCantidadRegistros()
      Dim cantidad As Integer
      If tbcDetalle.SelectedTab.Equals(tbpComprobantes) Then
         cantidad = GetCantidadRegistrosComprobantes()
      ElseIf tbcDetalle.SelectedTab.Equals(tbpProductos) Then
         cantidad = GetCantidadRegistrosProductos()
      Else
         cantidad = GetCantidadRegistrosDetalle()
      End If

      MuestraCantidadRegistros(cantidad)
   End Sub
   Private Sub MuestraCantidadRegistros(cantidad As Integer)
      Me.tssRegistros.Text = String.Format("{0} Registros", cantidad)
   End Sub
#End Region

   Private Sub MostrarAvance(mensaje As String)
      tssInfo.Text = mensaje
      Application.DoEvents()
   End Sub

#End Region

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If
   End Sub
End Class
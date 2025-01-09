Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfComprobantesCtaCteClientesFecha

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)
      Me.ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

      Try

         Me._publicos = New Publicos()

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            Me.chbVendedor.Checked = True
            Me.chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
         End If

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me._publicos.CargaComboTiposComprobantesCtaCteClientes(Me.cmbTiposComprobantes)
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0
         Me._publicos.CargaComboProvincias(Me.cmbProvincia)

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

   
         cmbFormaDePago.Inicializar("VENTAS")
         Me.cmbFormaDePago.SelectedValue = Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos)

         Me.CargarColumnasASumar()

        'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         Me.PreferenciasLeer(Me.ugDetalle)


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ugDetalle_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index <> -1 And e.Cell.Column.Header.Caption = "Ver" Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante2").Value.ToString())

            If oTipoComprobante.EsRecibo = True Then
               'imprime los recibos
               Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
               Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(actual.Sucursal.Id, _
                             Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante2").Value.ToString(), _
                             Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra2").Value.ToString(), _
                             Int32.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor2").Value.ToString()), _
                             Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante2").Value.ToString()))
               Dim imp As RecibosImprimir = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, True)
            Else
               Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
               Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante2").Value.ToString(), _
                           Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra2").Value.ToString(), _
                           Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor2").Value.ToString()), _
                           Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante2").Value.ToString()))

               Dim oImpr As Impresion = New Impresion(venta)

               If Not oTipoComprobante.EsFiscal Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If

            End If

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub InfCtaCteClientes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            Filtros = "Vendedor: " & Me.cmbVendedor.Text
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Zona G.: " & Me.cmbZonaGeografica.Text
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text
         End If

         If Me.chbCategoria.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Categoría: " & Me.cmbCategoria.Text
         End If

         '0 Es TODOS
         If Me.cmbGrabanLibro.SelectedIndex > 0 Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Graban Libro: " & Me.cmbGrabanLibro.Text
         End If

         If Me.chbProvincia.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Provincia: " & Me.cmbProvincia.Text
         End If

         If Me.chbExcluirAnticipos.Checked Then
            If Filtros.Length > 0 Then Filtros = Filtros & " - "
            Filtros = Filtros & "Excluir Anticipos"
         End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

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

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

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

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

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

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      Try
         Me.cmbGrupos.Enabled = Me.chbGrupo.Checked

         If Not Me.chbGrupo.Checked Then
            Me.cmbGrupos.SelectedIndex = -1
         Else
            If Me.cmbGrupos.Items.Count > 0 Then
               Me.cmbGrupos.SelectedIndex = 0
            End If
         End If

         Me.cmbGrupos.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   Private Sub tsbPreferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPreferencias.Click
      Try
         Me.PreferenciasCargar(Me.ugDetalle)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
      Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize1)
      summary1.DisplayFormat = "{0:N2}"
      summary1.Appearance.TextHAlign = HAlign.Right

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.chbCliente.Checked = False
      Me.dtpHasta.Value = Date.Now
      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.chbExcluirAnticipos.Checked = False
      Me.chbExcluirPreComprobantes.Checked = False
      Me.chbProvincia.Checked = False

      Me.chkExpandAll.Enabled = False
      Me.chbGrupo.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.cmbFormaDePago.Refrescar()

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      Me.ugDetalle.Update()
      Try
         '---------------------------------------------------------------------------------------------
         Dim hasta As Date = Me.dtpHasta.Value

         Dim IdVendedor As Integer = 0

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         Dim idCliente As Long = If(Me.bscCodigoCliente.Text.Length > 0, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0)
         Dim idZonaGeografica As String = If(Me.cmbZonaGeografica.Enabled, DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica, String.Empty)
         Dim tipoComprobante As String = If(Me.cmbTiposComprobantes.Enabled, Me.cmbTiposComprobantes.SelectedValue.ToString(), String.Empty)
         Dim idCategoria As Integer = If(Me.cmbCategoria.Enabled, Integer.Parse(Me.cmbCategoria.SelectedValue.ToString()), 0)
         Dim tipoCategoria As String = If(Me.rbtCatMovimiento.Checked, "MOVIMIENTO", "ACTUAL")

         Dim grupo As String = If(Me.cmbGrupos.Enabled, Me.cmbGrupos.SelectedValue.ToString(), String.Empty)
         Dim excluirAnticipos As String = If(Me.chbExcluirAnticipos.Checked, "SI", "NO")
         Dim excluirPreComprobantes As String = If(Me.chbExcluirPreComprobantes.Checked, "SI", "NO")
         Dim idProvincia As String = If(Me.chbProvincia.Checked, Me.cmbProvincia.SelectedValue.ToString(), String.Empty)

         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
         Dim dtDetalle As DataTable = oCtaCte.GetComprobantesCtaCteFecha(actual.Sucursal.Id,
                                                                         hasta,
                                                                         IdVendedor,
                                                                         idCliente,
                                                                         tipoComprobante,
                                                                         idZonaGeografica,
                                                                         idCategoria,
                                                                         Me.cmbGrabanLibro.Text,
                                                                         grupo,
                                                                         excluirAnticipos,
                                                                         excluirPreComprobantes,
                                                                         idProvincia,
                                                                         tipoCategoria,
                                                                         cmbFormaDePago.GetVentasFormaPagos())

         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = String.Format("{0} Registros", dtDetalle.Rows.Count)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         '.Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         '.Columns.Add("TipoDocVendedor", System.Type.GetType("System.String"))
         '.Columns.Add("NroDocVendedor", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         '.Columns.Add("NombreCliente2", System.Type.GetType("System.String"))
         '.Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         '.Columns.Add("DescripcionTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("CantDias", System.Type.GetType("System.Int32"))
         '.Columns.Add("IdFormasPago", System.Type.GetType("System.Int32"))
         .Columns.Add("DescripcionFormasPago", System.Type.GetType("System.String"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Saldo", System.Type.GetType("System.Decimal"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function
  
#End Region

End Class
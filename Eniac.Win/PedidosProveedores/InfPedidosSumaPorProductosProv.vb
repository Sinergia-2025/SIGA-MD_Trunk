Public Class InfPedidosSumaPorProductosProv
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private IdUsuario As String = actual.Nombre
   Private _tipoTipoComprobante As String
   Private _puedeVerPrecios As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboEstadosPedidosProv(cmbEstados, False, True, True, True, False, _tipoTipoComprobante)
         Me.cmbEstados.SelectedIndex = 0  'SOLO PENDIENTES

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         Me._publicos.CargaComboEmpleados(Me.cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR, IdUsuario)
         If IdUsuario = "" Then
            Me.cmbComprador.SelectedIndex = -1
         Else
            Me.chbComprador.Checked = True
            Me.chbComprador.Enabled = False  'Para que no pueda modificarlo manualmente
         End If
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "InfPedSumaPorProdProv-VerPre")

         If Not _puedeVerPrecios Then
            ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal").Hidden = True
            'ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImporteTotal").Hidden = True
            'ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImportePesos").Hidden = True
         End If

         Me.CargarColumnasASumar()

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         Me._estaCargando = False

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         Me.RefrescarDatos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfPedidosSumaPorProductos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatos()

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

         Dim IdVendedor As Integer

         Filtros = "Filtros: Estado: " & Me.cmbEstados.Text

         If Me.chbFecha.Checked Then
            Filtros = Filtros & " / Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text
         End If

         If Me.chbComprador.Checked Then
            IdVendedor = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado).IdEmpleado
            Filtros = Filtros & " / Vendedor: " & IdVendedor & " - " & Me.cmbComprador.Text
         End If

         If Me.bscCodigoProveedor.Text.Length > 0 Then
            Filtros = Filtros & " / Proveedor: " & Me.bscCodigoProveedor.Text.Trim() & " - " & Me.bscProveedor.Text.Trim()
         End If

         If Me.chbMarca.Checked Then
            Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
         End If

         If Me.chbRubro.Checked Then
            Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
         End If

         If Me.chbSubRubro.Checked Then
            Filtros += " / SubRubro: " & Me.cmbSubRubro.Text
         End If

         If Me.chbProducto.Checked Then
            Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
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

   Private Sub chbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

      Me.chbMesCompleto.Enabled = Me.chbFecha.Checked
      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Not Me.chbFecha.Checked Then
         Me.chbMesCompleto.Checked = False
         Me.dtpDesde.Value = DateTime.Today
         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpDesde.Focus()
      End If

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

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbComprador.CheckedChanged

      Me.cmbComprador.Enabled = Me.chbComprador.Checked

      If Not Me.chbComprador.Checked Then
         Me.cmbComprador.SelectedIndex = -1
      Else
         If Me.cmbComprador.Items.Count > 0 Then
            Me.cmbComprador.SelectedIndex = 0
         End If
      End If

      Me.cmbComprador.Focus()

   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick, bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = rProveedores.GetFiltradoPorCodigo(codigoProveedor, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Me.bscProveedor.Datos = rProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged

      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         If Me.cmbMarca.Items.Count > 0 Then
            Me.cmbMarca.SelectedIndex = 0
         End If
         'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
         'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
      End If

      Me.cmbMarca.Focus()

   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged

      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
         'Si elijo un Rubro, limpio el producto seleccionado (hipoteticamente)
         'La Marca lo dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
      End If

      Me.cmbRubro.Focus()

   End Sub

   Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
            'Si elijo un SubRubro, limpio el producto seleccionado (hipoteticamente)
            'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
            Me.chbProducto.Checked = False
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged

      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
         chbMarca.Checked = False
         chbRubro.Checked = False
      End If

      Me.bscCodigoProducto2.Focus()

   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         If Me.chbComprador.Checked And Me.cmbComprador.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbComprador.Focus()
            Exit Sub
         End If

         If Me.chbProveedor.Checked And Not (Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbProducto.Checked And Me.bscCodigoProducto2.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbOrdenCompra.Checked AndAlso Decimal.Parse(Me.txtOrdenCompra.Text) = 0 Then
            MessageBox.Show("ATENCION: NO colocó una Orden de Compra aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtOrdenCompra.Focus()
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
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      Try
         Me.txtOrdenCompra.Enabled = Me.chbOrdenCompra.Checked

         If Not Me.chbOrdenCompra.Checked Then
            Me.txtOrdenCompra.Text = String.Empty
         Else
            Me.txtOrdenCompra.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      e.Row.Cells("Cantidad").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("Cantidad").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("CantidadUMC").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("CantidadUMC").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("FactorConversionCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("FactorConversionCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
   End Sub

   Private Sub RefrescarDatos()

      Me.chbFecha.Checked = False

      Me.chbComprador.Checked = False
      Me.chbProveedor.Checked = False
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbSubRubro.Checked = False
      Me.chbProducto.Checked = False
      Me.chbOrdenCompra.Checked = False

      If IdUsuario = "" Then
         Me.chbComprador.Checked = False
      End If

      'Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      'Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalNeto")
      'Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotalNeto", SummaryType.Sum, columnToSummarize1)
      'summary1.DisplayFormat = "{0:N2}"
      'summary1.Appearance.TextHAlign = HAlign.Right

      'Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
      'Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize2)
      'summary2.DisplayFormat = "{0:N2}"
      'summary2.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("CantidadUMC")
      Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("CantidadUMC", SummaryType.Sum, columnToSummarize3)
      summary3.DisplayFormat = "{0:N2}"
      summary3.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad")
      Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Cantidad", SummaryType.Sum, columnToSummarize4)
      summary4.DisplayFormat = "{0:N2}"
      summary4.Appearance.TextHAlign = HAlign.Right

      Dim columnToSummarize5 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
      Dim summary5 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize5)
      summary5.DisplayFormat = "{0:N2}"
      summary5.Appearance.TextHAlign = HAlign.Right

      Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oPedidos As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()

         Dim FechaDesde As Date = Nothing
         Dim FechaHasta As Date = Nothing

         Dim IdProveedor As Long = 0

         Dim IdVendedor As Integer = 0

         Dim IdMarca As Integer = 0
         Dim IdRubro As Integer = 0
         Dim IdSubRubro As Integer = 0
         Dim IdProducto As String = String.Empty

         Dim Tamanio As Decimal = 0
         Dim OrdenCompra As Long = 0

         If Me.chbFecha.Checked Then
            FechaDesde = Me.dtpDesde.Value
            FechaHasta = Me.dtpHasta.Value
         End If

         If Me.chbProveedor.Checked Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If Me.chbComprador.Checked Then
            IdVendedor = DirectCast(Me.cmbComprador.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.chbMarca.Checked Then
            IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If

         If Me.chbRubro.Checked Then
            IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.cmbSubRubro.Enabled Then
            IdSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If

         If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text
         End If

         If Me.chbOrdenCompra.Checked Then
            OrdenCompra = Long.Parse(Me.txtOrdenCompra.Text.ToString())
         End If


         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oPedidos.GetPedidosSumaPorProductos(actual.Sucursal.Id,
                                                         Me.cmbEstados.Text,
                                                         FechaDesde, FechaHasta,
                                                         IdProveedor,
                                                         IdVendedor,
                                                         IdMarca,
                                                         IdRubro,
                                                         IdSubRubro,
                                                         IdProducto,
                                                         Tamanio,
                                                         OrdenCompra,
                                                         _tipoTipoComprobante)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("NombreMarca") = dr("NombreMarca").ToString()
            drCl("NombreRubro") = dr("NombreRubro").ToString()
            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            '   drCl("Kilos") = Decimal.Round(Decimal.Parse(dr("Kilos").ToString()), 3)
            drCl("Cantidad") = Decimal.Round(Decimal.Parse(dr("Cantidad").ToString()), 2)
            drCl("Stock") = Decimal.Round(Decimal.Parse(dr("Stock").ToString()), 2)
            If Not String.IsNullOrWhiteSpace(dr("Tamano").ToString()) Then
               drCl("Tamano") = Decimal.Round(Decimal.Parse(dr("Tamano").ToString()), 2)
            End If
            drCl("IdUnidadDeMedida") = dr("IdUnidadDeMedida").ToString()
            drCl("ImporteTotal") = Decimal.Round(Decimal.Parse(dr("ImporteTotal").ToString()), 2)
            drCl("CantidadUMC") = dr("CantidadUMC")
            drCl("IdUnidadDeMedidaCompra") = dr("IdUnidadDeMedidaCompra")
            drCl("FactorConversionCompra") = dr("FactorConversionCompra")
            drCl("NombreUnidadDeMedida") = dr("NombreUnidadDeMedida")
            drCl("NombreUnidadDeMedidaCompra") = dr("NombreUnidadDeMedidaCompra")

            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
         ugDetalle.DisplayLayout.Bands(0).Columns("CantidadUMC").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
         ugDetalle.DisplayLayout.Bands(0).Columns("FactorConversionCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)

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

         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         '  .Columns.Add("Kilos", System.Type.GetType("System.Decimal"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
         .Columns.Add("Stock", System.Type.GetType("System.Decimal"))
         .Columns.Add("Tamano", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("CantidadUMC", System.Type.GetType("System.Decimal"))
         ' .Columns.Add("IdUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("IdUnidadDeMedidaCompra", System.Type.GetType("System.String"))
         .Columns.Add("FactorConversionCompra", System.Type.GetType("System.Decimal"))
         .Columns.Add("NombreUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("NombreUnidadDeMedidaCompra", System.Type.GetType("System.String"))

      End With

      Return dtTemp

   End Function

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

#End Region

End Class
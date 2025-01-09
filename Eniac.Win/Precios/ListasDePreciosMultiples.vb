Public Class ListasDePreciosMultiples

#Region "Campos"

   Private _publicos As Publicos
   Private _precios As List(Of Entidades.ProductoSucursal)
   Private _listas As List(Of Entidades.ListaDePrecios)
   Private _MostrarCosto As Boolean

   Private Class NombresColumnas
      Public Property ColumnaPrecio As String
      Public Property ColumnaPrecioNuevo As String
      Public Property ColumnaPorc As String
      Public Property ColumnaPorcNuevo As String
      Public Property Monto As String

   End Class
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         '------------
         Me._publicos.CargaComboMonedas(Me.cmbMoneda)

         DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows.InsertAt(DirectCast(Me.cmbMoneda.DataSource, DataTable).NewRow, 0)
         DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows(0)("IdMoneda") = -1
         DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows(0)("NombreMoneda") = "del producto"
         Me.cmbMoneda.SelectedIndex = 0
         '------------------------------
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me._MostrarCosto = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ConsultarPrecios-PrecioCosto")
         ckbPrecioCosto.Visible = _MostrarCosto
         ckbPrecioCosto.Checked = _MostrarCosto
         chbMargenSobreCosto.Visible = _MostrarCosto
         dgvprecios.DisplayLayout.Bands(0).Columns("PrecioCosto").Hidden = Not _MostrarCosto
         dgvprecios.DisplayLayout.Bands(0).Columns("PrecioCosto").ExcludeFromColumnChooser = If(Not _MostrarCosto, ExcludeFromColumnChooser.True, ExcludeFromColumnChooser.Default)
         Me.RefrescarDatos()

         Ayudante.Grilla.AgregarFiltroEnLinea(dgvprecios, {"NombreProducto"})
         Me.LeerPreferencias()

         dgvprecios.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
         chkStock.Checked = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor, True)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
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
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      Try
         Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
         Me.bscProveedor.Enabled = Me.bscCodigoProveedor.Enabled
         Me.chbMostrarProveedorHabitual.Enabled = False
         Me.chbMostrarProveedorHabitual.Checked = False
         If Not Me.chbProveedor.Checked Then
            Me.bscCodigoProveedor.Text = String.Empty
            Me.bscProveedor.Text = String.Empty
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ListasDePreciosMultiples_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         Dim UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + "Listas de Precios"
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 5
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 5
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 14
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 8
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")
         If _listas.Count > 5 Then
            Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Else
            Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
         End If
         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      End If
   End Sub

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked
      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
      End If
   End Sub

   Private Sub dgvListasPrecios_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListasPrecios.CellContentClick
      Try
         If e.RowIndex > -1 Then
            Me.dgvListasPrecios.EndEdit()
            'If e.ColumnIndex = 1 Then
            '   'Si es la Lista Cero (siempre es la primera), muestro u oculto la columna (el metodo la devuelve siempre)
            '   If e.RowIndex = 0 Then
            '      Me.dgvprecios.DisplayLayout.Bands(0).Columns("PrecioVenta").Hidden = Not Boolean.Parse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(1).Value.ToString())
            '   End If
            'End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked
      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
      End If
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

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)

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

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If Me.chbProveedor.Checked AndAlso (Not Me.bscProveedor.Selecciono OrElse Not Me.bscCodigoProveedor.Selecciono) Then
            ShowMessage("ATENCIÓN: Activó el filtro por Proveedor pero no seleccionó ninguno.")
            Exit Sub
         End If

         Me.CargaGrillaDetalle()

      Catch ex As Exception
         ShowError(ex)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
      Try
         If cmbMoneda.SelectedIndex = 0 Then
            txtTipoCambio.Enabled = False
            txtTipoCambio.Text = "1.00"
         Else
            txtTipoCambio.Enabled = True
            txtTipoCambio.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
      Me.bscProveedor.Selecciono = True
      Me.bscCodigoProveedor.Selecciono = True
      chbMostrarProveedorHabitual.Enabled = True

   End Sub

   Private Sub RefrescarDatos()

      Me.tsbImprimir.Enabled = False
      Me.tsmiAExcel.Enabled = False
      Me.tsmiAPDF.Enabled = False

      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbProducto.Checked = False
      Me.chbMostrarProveedorHabitual.Checked = False
      chbProveedor.Checked = False
      Me.CargaListasDePrecios()

      If Not Me.dgvprecios.DataSource Is Nothing Then
         DirectCast(Me.dgvprecios.DataSource, DataTable).Rows.Clear()
      End If
      Me.tssRegistros.Text = " 0 Registros"

      'Me.dgvPrecios.Enabled = False

      'Me.PosibilitaOrdenarGrilla(True)

   End Sub

   Private Sub CargaListasDePrecios()

      Dim oLista As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()

      Me._listas = oLista.GetTodos()

      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("Id", System.Type.GetType("System.Int32"))
      dt.Columns.Add("Imprime", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("Lista", System.Type.GetType("System.String"))
      '-- REQ-35893.- ------------------------------------------------
      dt.Columns.Add("DivCta", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("CanCta", System.Type.GetType("System.Int32"))
      '---------------------------------------------------------------
      Dim dr As DataRow

      For Each lp As Entidades.ListaDePrecios In Me._listas
         dr = dt.NewRow()
         dr("Id") = lp.IdListaPrecios
         dr("Imprime") = True
         dr("Lista") = lp.NombreListaPrecios
         '-- REQ-35893.- ------------------------------------------------
         dr("DivCta") = False
         dr("CanCta") = 1
         If lp.FormaPago IsNot Nothing Then
            dr("DivCta") = lp.FormaPago.CantidadCuotas > 1
            dr("CanCta") = Math.Max(lp.FormaPago.CantidadCuotas, 1)
         End If
         '---------------------------------------------------------------
         dt.Rows.Add(dr)
      Next

      Me.dgvListasPrecios.DataSource = dt

      'seteo la grilla
      With Me.dgvListasPrecios
         .RowHeadersVisible = False
         .Columns("Id").Visible = False
         .Columns("Lista").HeaderText = "Nombre"
         .Columns("Lista").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         .Columns("Lista").ReadOnly = True
         .Columns("Imprime").HeaderText = "Imprime"
         .Columns("Imprime").Visible = True
         .Columns("Imprime").Width = 50

         '-- REQ-35893.- ------------------------------------------------
         .Columns("DivCta").HeaderText = "Div.Cta"
         .Columns("DivCta").Visible = True
         .Columns("DivCta").Width = 50

         .Columns("CanCta").HeaderText = "Cant.Cta"
         .Columns("CanCta").Visible = True
         .Columns("CanCta").Width = 50
         .Columns("CanCta").ReadOnly = True
         .Columns("CanCta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         '---------------------------------------------------------------

      End With

      'For Each dr1 As DataGridViewRow In Me.dgvListasPrecios.Rows
      '   dr1.Cells("Imprime").Value = False
      'Next

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim Sucursales(1) As Integer
      Dim Producto As String = ""
      Dim Marca As Integer = 0
      Dim Rubro As Integer = 0
      Dim SinCosto As Boolean
      Dim SinVenta As Boolean
      Dim costo As Boolean = True
      Dim stock As Boolean = True

      Sucursales(0) = actual.Sucursal.Id

      If Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono Then
         Producto = Me.bscCodigoProducto2.Text
      End If
      If Me.bscCodigoProducto2.Selecciono Then
         Producto = Me.bscCodigoProducto2.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim()
      End If
      If Me.chbMarca.Checked Then
         Marca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If
      If Me.chbRubro.Checked Then
         Rubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If
      If Not Me.ckbPrecioCosto.Checked Then
         costo = False
      End If
      If Not Me.chkStock.Checked Then
         stock = False
      End If
      Dim idProveedor As Long = 0
      If Me.chbProveedor.Checked Then
         idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      Dim subrubro As Integer
      Dim ListPrecio As Boolean = False
      Me._listas.Clear()


      For Each dr As DataGridViewRow In Me.dgvListasPrecios.Rows
         If Boolean.Parse(dr.Cells("Imprime").Value.ToString()) Then
            ListPrecio = True
            '-- REQ-35893.- ------------------------------------------------
            Dim ListaPrecio = New Reglas.ListasDePrecios().GetUno(Integer.Parse(DirectCast(dr.DataBoundItem, DataRowView)("Id").ToString()))
            ListaPrecio.DivideCuota = Boolean.Parse(dr.Cells("DivCta").Value.ToString())
            ListaPrecio.DivideCuotaCantidad = Integer.Parse(dr.Cells("CanCta").Value.ToString())
            Me._listas.Add(ListaPrecio)
            '---------------------------------------------------------------
         End If
      Next

      If ListPrecio = False Then
         MessageBox.Show("Debe seleccionar una lista de precio", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      dgvprecios.DataSource = New Reglas.Productos().GetPreciosListasMultiples(Sucursales, Marca, Rubro, subrubro, Producto, SinCosto, SinVenta, _listas, costo, stock,
                                                                               Integer.Parse(cmbMoneda.SelectedValue.ToString()), Decimal.Parse(txtTipoCambio.Text),
                                                                               idProveedor, chbConIVA.Checked, Me.chbMostrarProveedorHabitual.Checked)
      FormateaFechasPrecios()
      tssRegistros.Text = dgvprecios.Rows.Count.ToString() & " Registros"
      tsbImprimir.Enabled = True
      tsmiAExcel.Enabled = True
      tsmiAPDF.Enabled = True

      dgvprecios.Rows.ExpandAll(True)

      SeteoGrillaPrecios()

   End Sub

   Private Sub FormateaFechasPrecios()
      Dim hcPorcentaje As String = "%"
      Dim formato As String = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString()
      Dim maskInput As String = Formatos.MaskInput.CustomMaskInput(14, Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio)
      Dim pos As Integer = 0
      With dgvprecios.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            FormatearColumna(.Columns(Entidades.Proveedor.Columnas.IdProveedor.ToString()), "Id Proveedor", pos, 50, HAlign.Right, True)
            If columna.Key.StartsWith("pv_") Then
               columna.Width = 90
               columna.CellAppearance.TextHAlign = HAlign.Right
               columna.Format = "N2"
               columna.Header.Appearance.TextHAlign = HAlign.Center
               columna.FormatoMaskInput(formato, maskInput)
            End If
            If columna.Key.StartsWith("fa_") Then
               columna.Width = 130
               columna.CellAppearance.TextHAlign = HAlign.Center
               columna.Format = "dd/MM/yyyy HH:mm:ss"
               columna.Hidden = Not chbVerUltimaActualizacion.Checked
               columna.Header.Appearance.TextHAlign = HAlign.Center
            End If
            'Columna de %
            If columna.Key.StartsWith("dr_") Then
               columna.Header.Caption = hcPorcentaje
               columna.Width = 50
               columna.CellAppearance.TextHAlign = HAlign.Right
               columna.Format = "N2"
               columna.Header.Appearance.TextHAlign = HAlign.Center
               columna.FormatoMaskInput(formato, maskInput)
               columna.Hidden = Not chbMargenSobreCosto.Checked
               columna.ExcludeFromColumnChooser = If(Not _MostrarCosto, ExcludeFromColumnChooser.True, ExcludeFromColumnChooser.Default)
            End If
         Next
         .Columns("FechaActualizacionCosto").Hidden = Not chbVerUltimaActualizacion.Checked
         .Columns("Stock").FormatoMaskInput(formato, maskInput)
         .Columns("PrecioCosto").FormatoMaskInput(formato, maskInput)
         FormatearColumna(.Columns(Entidades.Proveedor.Columnas.NombreProveedor.ToString()), "Proveedor", pos, 100, HAlign.Left, False)
      End With
   End Sub

   Private Sub SeteoGrillaPrecios()

      'Si es la Lista Cero (siempre es la primera), muestro u oculto la columna (el metodo la devuelve siempre)
      'Me.dgvprecios.DisplayLayout.Bands(0).Columns("PrecioVenta").Hidden = Not Boolean.Parse(Me.dgvListasPrecios.Rows(0).Cells(1).Value.ToString())

      For Each dr As DataGridViewRow In Me.dgvListasPrecios.Rows
         If Integer.Parse(dr.Cells("Id").Value.ToString()) = 0 Then
            'Me.dgvprecios.DisplayLayout.Bands(0).Columns("PrecioVenta").Hidden = Not Boolean.Parse(dr.Cells("Imprime").Value.ToString())
            'Me.dgvprecios.DisplayLayout.Bands(0).Columns("PrecioVenta").Header.Caption = dr.Cells("Lista").Value.ToString()
            Exit For
            'Else
            '   Me.dgvprecios.DisplayLayout.Bands(0).Columns(dr.Cells("Lista").Value.ToString()).Hidden = Not Boolean.Parse(dr.Cells("Imprime").Value.ToString())
         End If
      Next

   End Sub


   Private Sub CargarProducto(dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
      Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())
   End Sub

#End Region

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = "ListaDePrecios.xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.dgvprecios, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = "ListaDePrecios.pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.dgvprecios, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub chbVerUltimaActualizacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbVerUltimaActualizacion.CheckedChanged
      Try
         FormateaFechasPrecios()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.dgvprecios, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.dgvprecios.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.dgvprecios.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ckbPrecioCosto_CheckedChanged(sender As Object, e As EventArgs) Handles ckbPrecioCosto.CheckedChanged
      Try
         dgvprecios.DisplayLayout.Bands(0).Columns("PrecioCosto").Hidden = Not ckbPrecioCosto.Checked
         chbMargenSobreCosto.Checked = ckbPrecioCosto.Checked
         chbMargenSobreCosto.Enabled = ckbPrecioCosto.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chkStock_CheckedChanged(sender As Object, e As EventArgs) Handles chkStock.CheckedChanged
      Try
         dgvprecios.DisplayLayout.Bands(0).Columns("Stock").Hidden = Not chkStock.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbMargenSobreCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMargenSobreCosto.CheckedChanged
      Try
         For Each col As UltraGridColumn In dgvprecios.DisplayLayout.Bands(0).Columns
            If col.Key.StartsWith("dr_") Then
               col.Hidden = Not chbMargenSobreCosto.Checked
            End If
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


End Class
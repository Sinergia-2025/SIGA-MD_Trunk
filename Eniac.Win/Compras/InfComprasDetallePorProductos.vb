Imports Eniac.Entidades
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Public Class InfComprasDetallePorProductos

#Region "Campos"

   Private _publicos As Publicos
   Private _periodoAnterior As Date? = Nothing

   '-- REQ-35221.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Me.LeerPreferencias()

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         '-.PE-31886.-
         Me.dtpPeriodoFiscalDesde.Value = Date.Today
         Me.dtpPeriodoFiscalHasta.Value = Date.Today.Date.UltimoSegundoDelDia()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)

         '' carga el combo de rubros
         'Me._publicos.CargaComboRubros(Me.cmbRubro, False, False)

         ' inicializo los combos de rubros
         Dim rubros As Entidades.Rubro() = Nothing
         Dim subrubros As Entidades.SubRubro() = Nothing

         Me.cmbRubro.Inicializar(True, True, True)
         Me.cmbSubRubro.Inicializar(True, True, True, rubros)
         Me.cmbSubSubRubro.Inicializar(True, True, True, subrubros)

         'Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)
         'If Not Publicos.ProductoTieneSubRubro Then
         '   Me.chbSubRubro.Visible = False
         '   Me.cmbSubRubro.Visible = False
         '   Me.dgvDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = True
         'End If

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "COMPRAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.COMPRADOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "COMPRAS")
         Me.cmbFormaPago.SelectedIndex = -1

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 1

         Dim aCantidad As ArrayList = New ArrayList
         aCantidad.Insert(0, "Negativo ( < 0 )")
         aCantidad.Insert(1, "Igual a Cero ( = 0 )")
         aCantidad.Insert(2, "Mayor a Cero ( > 0 )")
         Me.cmbCantidad.DataSource = aCantidad
         Me.cmbCantidad.SelectedIndex = -1   '0

         Me.CargarColumnasASumar()

         ' habilita los filtros subrubro y subsubrubro solo si están vendidos
         chbSubRubro.Visible = Reglas.Publicos.ProductoTieneSubRubro
         chbSubSubRubro.Visible = Reglas.Publicos.ProductoTieneSubSubRubro
         cmbSubRubro.Visible = chbSubRubro.Visible
         cmbSubSubRubro.Visible = chbSubSubRubro.Visible


         With Me.ugDetalle.DisplayLayout.Bands(0)
            'AR: No se que pasa que no se oculta!!!
            .Columns("IdProveedor").Hidden = True
            .Columns("CodigoProveedor").Hidden = True

            .Columns(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).Hidden = Not chbSubRubro.Visible
            .Columns(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()).Hidden = Not chbSubSubRubro.Visible

            '-- REQ-35221.- ------------------------------------------------------
            .Columns("DescripcionAtributo01").Header.Caption = If(TipoAtributo01 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion)
            .Columns("DescripcionAtributo01").Hidden = (TipoAtributo01 = 0)
            '-- Atributo 02.- ------------------------------------------------------
            .Columns("DescripcionAtributo02").Header.Caption = If(TipoAtributo02 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion)
            .Columns("DescripcionAtributo02").Hidden = (TipoAtributo02 = 0)
            '-- Atributo 03.- ------------------------------------------------------
            .Columns("DescripcionAtributo03").Header.Caption = If(TipoAtributo03 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion)
            .Columns("DescripcionAtributo03").Hidden = (TipoAtributo03 = 0)
            '-- Atributo 04.- ------------------------------------------------------
            .Columns("DescripcionAtributo04").Header.Caption = If(TipoAtributo04 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion)
            .Columns("DescripcionAtributo04").Hidden = (TipoAtributo04 = 0)
            '---------------------------------------------------------------------
         End With

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         If Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
            Me.ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Hidden = False
            Me.ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = False
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub InfComprasDetallePorProductos_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As EventArgs) Handles tsbRefrescar.Click
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

   Private Sub tsbImprimir_Click(sender As System.Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion
         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

   Private Sub tsmiAExcel_Click(sender As System.Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Reglas.Publicos.NombreEmpresa
         myWorksheet.Rows(1).Cells(0).Value = Me.Text
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugDetalle, myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As System.Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Reglas.Publicos.NombreEmpresa + System.Environment.NewLine)
               sec.AddText.AddContent(Me.Text + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As System.Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As System.Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked And Not Me.rdbPorPeriodoFiscal.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked And Not Me.rdbPorPeriodoFiscal.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbMarca_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbMarca.CheckedChanged

      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
         'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
         'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
         Me.cmbMarca.Focus()
      End If

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            Me.cmbTiposComprobantes.SelectedIndex = 0
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbProducto.CheckedChanged

      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked

      Me.bscProducto2.Enabled = Me.chbProducto.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
         Me.chbMarca.Checked = False
         Me.bscCodigoProducto2.Focus()
      End If

   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         Me.cmbVendedor.SelectedIndex = 0
         Me.cmbVendedor.Focus()
      End If
   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbFormaPago.CheckedChanged

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

   Private Sub chbLote_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbLote.CheckedChanged
      Try
         Me.bscLote.Enabled = Me.chbLote.Checked
         Me.bscLote.Text = String.Empty
         Me.bscLote.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      Try
         Me._publicos.PreparaGrillaLotes(Me.bscLote)
         Dim oLote As Reglas.ProductosLotes = New Reglas.ProductosLotes()
         Me.bscLote.Datos = oLote.GetFiltradoPorId(Me.bscLote.Text, Entidades.Usuario.Actual.Sucursal.Id)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscLote_BuscadorSeleccion(sender As System.Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCantidad_CheckedChanged(sender As System.Object, e As EventArgs) Handles chbCantidad.CheckedChanged
      Try
         Me.cmbCantidad.Enabled = Me.chbCantidad.Checked

         If Not Me.chbCantidad.Checked Then
            Me.cmbCantidad.SelectedIndex = -1
         Else
            Me.cmbCantidad.SelectedIndex = 0
            Me.cmbCantidad.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As System.Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbMarca.Focus()
            Exit Sub
         End If

         If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbLote.Checked And Not Me.bscLote.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Lote aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscLote.Focus()
            Exit Sub
         End If
         '-.PE-31886.-
         If Me.dtpPeriodoFiscalDesde.Value > Me.dtpPeriodoFiscalHasta.Value Then
            MessageBox.Show("ATENCION: La fecha Desde del Periodo Fiscal no puede ser mayor a la fecha Hasta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As System.Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub tsbPreferencias_Click(sender As System.Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscalDesde.ValueChanged
      dtpPeriodoFiscalDesde.Value = dtpPeriodoFiscalDesde.Value.PrimerDiaMes()
   End Sub
   '-.PE-31886.-
   Private Sub dtpPeriodoFiscalHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscalHasta.ValueChanged
      dtpPeriodoFiscalHasta.Value = dtpPeriodoFiscalHasta.Value.PrimerDiaMes()
   End Sub
   Private Sub rdbPorFechas_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPorFechas.CheckedChanged
      Me.dtpPeriodoFiscalDesde.Enabled = Not Me.rdbPorFechas.Checked
      Me.dtpPeriodoFiscalHasta.Enabled = Not Me.rdbPorFechas.Checked
   End Sub
   Private Sub rdbPorPeriodoFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPorPeriodoFiscal.CheckedChanged
      dtpDesde.Enabled = Not rdbPorPeriodoFiscal.Checked
      dtpHasta.Enabled = Not rdbPorPeriodoFiscal.Checked
   End Sub
   Private Sub dtpPeriodoFiscalDesde_Enter(sender As Object, e As EventArgs) Handles dtpPeriodoFiscalDesde.Enter
      _periodoAnterior = dtpPeriodoFiscalDesde.Value
   End Sub

   Private Sub dtpPeriodoFiscalDesde_Leave(sender As Object, e As EventArgs) Handles dtpPeriodoFiscalDesde.Leave
      Try
         If _periodoAnterior.HasValue Then
            Dim desde As Date = dtpPeriodoFiscalDesde.Value
            Dim hasta As Date = dtpPeriodoFiscalHasta.Value
            Dim delta = Convert.ToInt32(DateAndTime.DateDiff(DateInterval.Month, _periodoAnterior.Value, desde))
            dtpPeriodoFiscalHasta.Value = hasta.AddMonths(delta)
         End If
      Catch ex As Exception
         ShowError(ex)
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
   End Sub

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      '-.PE-31886.-
      Me.dtpPeriodoFiscalDesde.Value = DateTime.Today
      Me.dtpPeriodoFiscalHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.rdbPorFechas.Checked = True
      dtpPeriodoFiscalDesde.Value = Today.PrimerDiaMes()


      Me.chbTipoComprobante.Checked = False

      Me.chbProducto.Checked = False
      Me.chbMarca.Checked = False
      Me.chbProducto.Checked = False

      Me.bscLote.Text = String.Empty

      Me.chbCantidad.Checked = False

      Me.chbProveedor.Checked = False
      Me.chbVendedor.Checked = False

      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbAfectaCaja.SelectedIndex = 1

      Me.chbFormaPago.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtSubtotal.Text = "0.00"
      Me.txtImpuestos.Text = "0.00"
      Me.txtTotal.Text = "0.00"

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("ImporteTotalNeto") Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow


         Dim columnToSummarize0 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad")
         Dim summary0 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Cantidad", SummaryType.Sum, columnToSummarize0)
         summary0.DisplayFormat = "{0:N2}"
         summary0.Appearance.TextHAlign = HAlign.Right


         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalNeto")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotalNeto", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("IVA")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("IVA", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:N2}"
         summary3.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      End If


   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oComprasProd As Reglas.ComprasProductos = New Reglas.ComprasProductos()

      Dim TotalNeto As Decimal = 0
      Dim TotalImpuestos As Decimal = 0
      Dim Total As Decimal = 0

      Dim idProducto As String = String.Empty
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim idSubSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim IdProveedor As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdVendedor As Integer = 0

      Dim IdFormaDePago As Integer = 0
      Dim IdUsuario As String = String.Empty
      Dim Cantidad As String = String.Empty

      Dim Desde As Date? = Nothing
      Dim Hasta As Date? = Nothing

      '-.PE-31886.-
      Dim PeriodoFiscalDesde As Integer = 0
      Dim PeriodoFiscalHasta As Integer = 0

      If Me.chbProducto.Checked Then
         idProducto = Me.bscCodigoProducto2.Text.Trim()
      End If

      If Me.chbMarca.Checked Then
         IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If

      If Me.cmbSubRubro.Enabled Then
         idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      If Me.cmbSubSubRubro.Enabled Then
         idSubSubRubro = Integer.Parse(Me.cmbSubSubRubro.SelectedValue.ToString())
      End If

      If Me.chbLote.Checked Then
         lote = Me.bscLote.Text
      End If

      If Me.chbProveedor.Checked Then
         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.cmbTiposComprobantes.Enabled Then
         TipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
      End If

      If Me.chbVendedor.Checked Then
         IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      If Me.cmbFormaPago.Enabled Then
         IdFormaDePago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
      End If

      Select Case Me.cmbCantidad.SelectedIndex
         Case 0
            Cantidad = " < 0"
         Case 1
            Cantidad = " = 0"
         Case 2
            Cantidad = " > 0"
      End Select

      If rdbPorFechas.Checked Or rdbAmbos.Checked Then
         Desde = Me.dtpDesde.Value
         Hasta = Me.dtpHasta.Value
      End If

      If rdbPorPeriodoFiscal.Checked Or rdbAmbos.Checked Then
         PeriodoFiscalDesde = Integer.Parse(dtpPeriodoFiscalDesde.Value.ToString("yyyyMM"))
         PeriodoFiscalHasta = Integer.Parse(dtpPeriodoFiscalHasta.Value.ToString("yyyyMM"))
      Else
         PeriodoFiscalDesde = Nothing
         PeriodoFiscalHasta = Nothing
      End If



      Dim rubros As Entidades.Rubro() = Me.cmbRubro.GetRubros(True)
      Dim subrubros As Entidades.SubRubro() = Me.cmbSubRubro.GetSubRubros(True)
      Dim subsubrubros As Entidades.SubSubRubro() = Me.cmbSubSubRubro.GetSubSubRubros(True)

      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      dtDetalle = oComprasProd.GetDetallePorProductos(actual.Sucursal.Id, Desde, Hasta,
                                                      idProducto, IdMarca,
                                                      rubros, subrubros, subsubrubros,
                                                      TipoComprobante, IdVendedor,
                                                      IdProveedor,
                                                      Me.cmbGrabanLibro.Text, Me.cmbAfectaCaja.Text, IdFormaDePago,
                                                      Cantidad, PeriodoFiscalDesde, PeriodoFiscalHasta,
                                                      top:=0, orderBy:=ComprasProductos_GetDetallePorProductos_OrderBy.Default)

      dt = CrearDT()

      For Each dr As DataRow In dtDetalle.Rows

         drCl = dt.NewRow()

         drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
         drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
         drCl("TipoComprobante") = dr("DescripcionAbrev").ToString()
         drCl("Letra") = dr("Letra").ToString()
         drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
         drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
         drCl("IdProveedor") = Long.Parse(dr("IdProveedor").ToString())
         drCl("CodigoProveedor") = Long.Parse(dr("CodigoProveedor").ToString())
         drCl("NombreProveedor") = dr("NombreProveedor").ToString()
         drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
         drCl("FormaDePago") = dr("FormaDePago").ToString()
         drCl("IdProducto") = dr("IdProducto").ToString()
         drCl("NombreProducto") = dr("NombreProducto").ToString()
         drCl("NombreActualProducto") = dr("NombreActualProducto").ToString()
         drCl("NombreMarca") = dr("NombreMarca").ToString()
         drCl("NombreRubro") = dr("NombreRubro").ToString()
         drCl("NombreSubRubro") = dr("NombreSubRubro").ToString()
         drCl("NombreSubSubRubro") = dr("NombreSubSubRubro").ToString()
         drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())
         ' drCl("PrecioLista") = Decimal.Parse(dr("PrecioLista").ToString())
         drCl("Precio") = Decimal.Parse(dr("Precio").ToString())
         drCl("DescuentoRecargoPorc") = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         'drCl("DescuentoRecargoPorc2") = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
         drCl("DescuentoRecargoPorcGral") = Decimal.Parse(dr("DescuentoRecargoPorcGral").ToString())
         drCl("PrecioNeto") = Decimal.Parse(dr("PrecioNeto").ToString())
         drCl("PorcentajeIva") = Decimal.Parse(dr("PorcentajeIva").ToString())
         drCl("ImporteTotalNeto") = Decimal.Parse(dr("ImporteTotalNeto").ToString())
         drCl("IVA") = Decimal.Parse(dr("IVA").ToString())
         drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotalNeto").ToString()) + Decimal.Parse(dr("IVA").ToString())
         '-.PE-31661.-
         drCl("ImportePesos") = Decimal.Parse(dr("ImportePesos").ToString())
         drCl("ImporteTarjetas") = Decimal.Parse(dr("ImporteTarjetas").ToString())
         drCl("ImporteCheques") = Decimal.Parse(dr("ImporteCheques").ToString())
         drCl("ImporteTransfBancaria") = Decimal.Parse(dr("ImporteTransfBancaria").ToString())
         drCl("NombreCuenta") = dr("NombreCuenta").ToString()
         'drCl("Usuario") = dr("Usuario").ToString()

         drCl(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()) = dr(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString())
         drCl(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()) = dr(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString())

         drCl("PeriodoFiscal") = dr("PeriodoFiscal")

         drCl("Observaciones") = dr("Observaciones")
         '-- REQ-40918.- ------------------------------------------------------------
         drCl("NombreDeposito") = dr("NombreDeposito")
         drCl("NombreUbicacion") = dr("NombreUbicacion")
         drCl("InformeCalidadNumero") = dr("InformeCalidadNumero")
         drCl("InformeCalidadLink") = dr("InformeCalidadLink")
         drCl("IdLote") = dr("IdLote")
         drCl("FechaVencimientoLote") = dr("FechaVencimientoLote")
         '-- REQ-35221.- ------------------------------------------------------------
         drCl("IdaAtributoProducto01") = dr("IdaAtributoProducto01")
         drCl("DescripcionAtributo01") = dr("DescripcionAtributo01")
         drCl("IdaAtributoProducto02") = dr("IdaAtributoProducto02")
         drCl("DescripcionAtributo02") = dr("DescripcionAtributo02")
         drCl("IdaAtributoProducto03") = dr("IdaAtributoProducto03")
         drCl("DescripcionAtributo03") = dr("DescripcionAtributo03")
         drCl("IdaAtributoProducto04") = dr("IdaAtributoProducto04")
         drCl("DescripcionAtributo04") = dr("DescripcionAtributo04")
         '---------------------------------------------------------------------------
         drCl("CantidadUMCompra") = dr("CantidadUMCompra")
         drCl("IdUnidadDeMedida") = dr("IdUnidadDeMedida")
         drCl("IdUnidadDeMedidaCompra") = dr("IdUnidadDeMedidaCompra")
         drCl("FactorConversionCompra") = dr("FactorConversionCompra")
         drCl("NombreUnidadDeMedida") = dr("NombreUnidadDeMedida")
         drCl("NombreUnidadDeMedidaCompra") = dr("NombreUnidadDeMedidaCompra")

         dt.Rows.Add(drCl)

         TotalNeto = TotalNeto + Decimal.Parse(drCl("ImporteTotalNeto").ToString())
         TotalImpuestos = TotalImpuestos + Decimal.Parse(drCl("IVA").ToString())
         Total = Total + Decimal.Parse(drCl("ImporteTotal").ToString())

      Next

      txtSubtotal.Text = TotalNeto.ToString("#,##0.00")
      txtImpuestos.Text = TotalImpuestos.ToString("#,##0.00")
      txtTotal.Text = Total.ToString("#,##0.00")

      ugDetalle.DataSource = dt

      ugDetalle.AgregarFiltroEnLinea({"Fecha", "IdTipoComprobante"})
      ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
      ugDetalle.DisplayLayout.Bands(0).Columns("CantidadUMCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
      ugDetalle.DisplayLayout.Bands(0).Columns("FactorConversionCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)

      tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"


   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("IdProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreActualProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("NombreSubRubro", GetType(String))
         .Columns.Add("NombreSubSubRubro", GetType(String))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
         .Columns.Add("Precio", System.Type.GetType("System.Decimal"))
         .Columns.Add("DescuentoRecargoPorc", System.Type.GetType("System.Decimal"))
         .Columns.Add("DescuentoRecargoPorcGral", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrecioNeto", System.Type.GetType("System.Decimal"))
         .Columns.Add("PorcentajeIva", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotalNeto", System.Type.GetType("System.Decimal"))
         .Columns.Add("IVA", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString(), GetType(Integer))
         .Columns.Add(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString(), GetType(String))
         .Columns.Add("PeriodoFiscal", System.Type.GetType("System.Int32"))

         '-.PE-31661.-
         .Columns.Add("ImportePesos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTarjetas", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteCheques", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTransfBancaria", System.Type.GetType("System.Decimal"))
         .Columns.Add("NombreCuenta", System.Type.GetType("System.String"))
         '-.PE-40918.-
         .Columns.Add("NombreDeposito", System.Type.GetType("System.String"))
         .Columns.Add("NombreUbicacion", System.Type.GetType("System.String"))
         .Columns.Add("InformeCalidadNumero", System.Type.GetType("System.String"))
         .Columns.Add("InformeCalidadLink", System.Type.GetType("System.String"))
         .Columns.Add("IdLote", System.Type.GetType("System.String"))
         .Columns.Add("FechaVencimientoLote", System.Type.GetType("System.DateTime"))
         '-
         .Columns.Add("IdaAtributoProducto01", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo01", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto02", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo02", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto03", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo03", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto04", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo04", System.Type.GetType("System.String"))

         .Columns.Add("CantidadUMCompra", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("IdUnidadDeMedidaCompra", System.Type.GetType("System.String"))
         .Columns.Add("FactorConversionCompra", System.Type.GetType("System.Decimal"))
         .Columns.Add("NombreUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("NombreUnidadDeMedidaCompra", System.Type.GetType("System.String"))

         .Columns.Add("Observaciones", GetType(String))
      End With

      Return dtTemp

   End Function


   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         If Me.rdbPorFechas.Checked Or rdbAmbos.Checked Then
            .AppendFormat(" Fecha: Desde: {0} Hasta {1} - ", dtpDesde.Value.ToString(), dtpHasta.Value.ToString())
         End If
         If Me.rdbPorPeriodoFiscal.Checked Or rdbAmbos.Checked Then
            .AppendFormat(" Periodo Fiscal: {0} - ", dtpPeriodoFiscalDesde.Value.ToString())
         End If

         If Me.bscCodigoProducto2.Text.Length > 0 And Me.bscProducto2.Text.Length > 0 Then
            .AppendFormat(" Producto: {0} - {1} - ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.bscLote.Text.Length > 0 Then
            .AppendFormat(" Lote: {0} - ", bscLote.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat(" Marca: {0} -", Me.cmbMarca.Text)
         End If

         cmbRubro.CargarFiltrosImpresionRubros(filtro, False, True)
         cmbSubRubro.CargarFiltrosImpresionSubRubros(filtro, False, True)
         cmbSubSubRubro.CargarFiltrosImpresionSubRubros(filtro, False, True)

         If Me.cmbCantidad.SelectedIndex > -1 Then
            .AppendFormat(" Cantidad: {0} - ", Me.cmbCantidad.Text)
         End If

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            .AppendFormat(" Proveedor: {0} - {1} - ", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.cmbTiposComprobantes.SelectedIndex > -1 Then
            .AppendFormat(" Tipo Comprobante: {0} - ", Me.cmbTiposComprobantes.Text)
         End If

         .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)

         .AppendFormat(" Afecta Caja: {0} - ", Me.cmbAfectaCaja.Text)

         If Me.cmbFormaPago.SelectedIndex > -1 Then
            .AppendFormat(" Forma de Pago: {0} - ", Me.cmbFormaPago.Text)
         End If

         If Me.cmbVendedor.SelectedIndex > -1 Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         Dim habilitaSubRubro As Boolean = False
         If cmbRubro.SelectedIndex > 0 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
            If rubros.Length = 1 Then
               cmbSubRubro.Inicializar(True, True, True, rubros)
               habilitaSubRubro = True
            End If
         End If
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         cmbSubRubro.Enabled = habilitaSubRubro
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbSubRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      Dim habilitaSubSubRubro As Boolean = False
      If cmbSubRubro.SelectedIndex > 0 Then
         Dim subRubros As Entidades.SubRubro() = cmbSubRubro.GetSubRubros()
         If subRubros.Length = 1 Then
            cmbSubSubRubro.Inicializar(True, True, True, subRubros)
            habilitaSubSubRubro = True
         End If
      End If
      cmbSubSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      cmbSubSubRubro.Enabled = habilitaSubSubRubro
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      e.Row.Cells("Cantidad").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("Cantidad").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("CantidadUMCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("CantidadUMCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("FactorConversionCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("FactorConversionCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
   End Sub
#End Region
End Class
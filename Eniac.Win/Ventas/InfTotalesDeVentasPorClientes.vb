Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Eniac.Entidades
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Public Class InfTotalesDeVentasPorClientes

#Region "Campos"

   Private _publicos As Publicos
   Private _cliente As Entidades.Cliente
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()
         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         '# Origen Vendedor
         Me._publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         Me.cmbOrigenVendedor.SelectedIndex = -1
         Me._publicos.CargaComboDesdeEnum(cmbOrigenVendedorFiltro, GetType(Entidades.OrigenFK))
         Me.cmbOrigenVendedorFiltro.SelectedIndex = -1

         Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA
         Me.dtpDesde.Value = Today.PrimerDiaMes()
         Me.dtpHasta.Value = Today.PrimerDiaMes()

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0
         Me.chbIncluirPreComprobantes.Checked = False

         cmbGrupos.Inicializar()
         Me.cmbGrupos.SelectedValue = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()

         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

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

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         If Me.cmbMarca.Items.Count > 0 Then
            Me.cmbMarca.SelectedIndex = 0
         End If
         Me.cmbMarca.Focus()
      End If
   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
         Me.cmbRubro.Focus()
      End If
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
         Me.cmbOrigenVendedorFiltro.Enabled = False
         Me.cmbOrigenVendedorFiltro.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
            Me.cmbOrigenVendedorFiltro.Enabled = True
            Me.cmbOrigenVendedorFiltro.SelectedValue = Entidades.OrigenFK.Movimiento
         End If
         Me.cmbVendedor.Focus()
      End If
   End Sub

   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
      dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
   End Sub

   Private Sub dtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpHasta.ValueChanged
      dtpHasta.Value = dtpHasta.Value.PrimerDiaMes()
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged

      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked

      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
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

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
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

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbVendedorAgrupar_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedorAgrupar.CheckedChanged

      Try
         Me.cmbOrigenVendedor.Enabled = Me.chbVendedorAgrupar.Checked
         If Not Me.chbVendedorAgrupar.Checked Then
            Me.cmbOrigenVendedor.SelectedIndex = -1
         Else
            Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub InfTotalesDeVentasPorClientes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

   Private Sub tsmiAExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim excelExport As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.xls", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim excelExport As UltraGridExportarPDF = New UltraGridExportarPDF(UltraGridDocumentExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.pdf", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

         If Me.chbTipoComprobante.Checked Then
            .AppendFormat(" Tipo de Comprobante: {0} - ", Me.cmbTiposComprobantes.Text)
         End If

         If Me.chbProducto.Checked Then
            .AppendFormat(" Producto: {0} - {1} - ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat(" Marca: {0} - ", Me.cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" Rubro: {0} - ", Me.cmbRubro.Text)
         End If
         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If

         If Me.chbIncluirPreComprobantes.Checked Then
            .AppendFormat(" Excluir Pre-Comprobantes - ")
         End If

         '# Agrupación
         If Me.chbVendedorAgrupar.Checked Or Me.chbRubroAgrupar.Checked Or Me.chbMarcaAgrupar.Checked Then
            .AppendFormatLine(" Agrupado por: {0} {1} {2}",
                          If(Me.chbVendedorAgrupar.Checked, String.Format("Vendedor ({0})", Me.cmbOrigenVendedor.SelectedValue.ToString()), Nothing),
                          If(Me.chbMarcaAgrupar.Checked, " - Marca", Nothing),
                          If(Me.chbRubroAgrupar.Checked, " - Rubro", Nothing))
         End If

         .AppendFormat(" Incluye IVA: {0} -", IIf(Me.chbConIVA.Checked, "SI", "NO").ToString())
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
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

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         'Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty
      Else
         Me.bscCodigoCliente.Focus()
      End If
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

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If
         If Me.chbProducto.Checked And Me.bscCodigoProducto2.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbProveedor.Checked And Me.bscCodigoProveedor.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Me.RefrescarDatosGrilla()
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbConIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbConIVA.CheckedChanged
      'If Me._estaCargando Then Exit Sub
      'Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalNeto").Hidden = Me.chbConIVA.Checked
      'Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal").Hidden = Not Me.chbConIVA.Checked
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

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
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

   Private Sub bscProveedorProv_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub FormatearGrilla()

      Dim pos As Integer = 0
      With Me.ugDetalle.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.Hidden = True
         Next

         Dim infoCliente As Boolean = Me.chbInformacionCliente.Checked
         Dim vendedor As Boolean = Me.chbVendedorAgrupar.Checked
         Dim marca As Boolean = Me.chbMarcaAgrupar.Checked Or Me.chbMarca.Checked
         Dim rubro As Boolean = Me.chbRubroAgrupar.Checked Or Me.chbRubro.Checked
         Dim Proveedor As Boolean = Me.chbMostrarProveedorHabitual.Checked Or chbProveedor.Checked

         '######################
         '# Inicio de Formateo #
         '######################
         If vendedor Then
            FormatearColumna(.Columns(Entidades.Empleado.Columnas.NombreEmpleado.ToString()), "Vendedor", pos, 100, HAlign.Left)
         End If

         FormatearColumna(.Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()), "Código", pos, 70, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()), "Cliente", pos, 200, HAlign.Left)
         FormatearColumna(.Columns("Total"), "Total", pos, 100, HAlign.Right)
         Me.ugDetalle.AgregarTotalSumaColumna("Total")

         If infoCliente Then
            FormatearColumna(.Columns(Entidades.Cliente.Columnas.Direccion.ToString()), "Dirección", pos, 130, HAlign.Left)
            FormatearColumna(.Columns(Entidades.Cliente.Columnas.Telefono.ToString()), "Teléfono", pos, 100, HAlign.Left)
            FormatearColumna(.Columns(Entidades.Cliente.Columnas.Cuit.ToString()), "CUIT", pos, 100, HAlign.Left)
            FormatearColumna(.Columns(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()), "Tipo", pos, 100, HAlign.Left)
         End If

         If marca Then
            FormatearColumna(.Columns(Entidades.Marca.Columnas.NombreMarca.ToString()), "Marca", pos, 100, HAlign.Left)
         End If

         If rubro Then
            FormatearColumna(.Columns(Entidades.Rubro.Columnas.NombreRubro.ToString()), "Rubro", pos, 100, HAlign.Left)
         End If

         If Proveedor Then
            FormatearColumna(.Columns(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()), "Codigo Prov.", pos, 80, HAlign.Right)
            FormatearColumna(.Columns(Entidades.Proveedor.Columnas.NombreProveedor.ToString()), "Proveedor", pos, 150, HAlign.Left)
         End If

         '# En caso que el check no esté tildado muestro el detalle por período. Caso contrario solo muestro la columna por la suma total de los períodos
         If Not Me.chbSoloTotales.Checked Then

            '# Períodos
            Dim x As Date = Me.dtpHasta.Value
            Me.ugDetalle.InicializaTotales()
            While x >= Me.dtpDesde.Value
               FormatearColumna(.Columns(String.Format("{0}", x.ToString("yyyy/MM"))), x.ToString("yyyy/MM"), pos, 80, HAlign.Right)
               .Columns(String.Format("{0}", x.ToString("yyyy/MM"))).Format = "N2"

               '# Totalizo las columnas de períodos
               Me.ugDetalle.AgregarTotalSumaColumna(String.Format("{0}", x.ToString("yyyy/MM")))
               x = x.AddMonths(-1)
            End While

         End If

         '######################
         '# Fin de Formateo    #
         '######################

         '# Filtros en linea
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      End With

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbCliente.Checked = False
      Me.chbTipoComprobante.Checked = False

      Me.chbVendedor.Checked = False
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbZonaGeografica.Checked = False

      Me.chbMarcaAgrupar.Checked = False
      Me.chbVendedorAgrupar.Checked = False
      Me.chbRubroAgrupar.Checked = False
      Me.chbInformacionCliente.Checked = False
      Me.chbIncluirPreComprobantes.Checked = False
      Me.chbProducto.Checked = False



      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA
      Me.chbProveedor.Checked = False
      Me.chbMostrarProveedorHabitual.Checked = False
      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
         Me.ugDetalle.DataSource = Nothing
      End If

      Me.cmbGrabanLibro.SelectedIndex = 0

      cmbSucursal.Refrescar()
      cmbGrupos.Refrescar()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim idCliente As Long = 0

      Dim idTipoComprobante As String = String.Empty

      Dim IdVendedor As Integer = 0

      Dim idZonaGeografica As String = String.Empty
      Dim idMarca As Integer = 0
      Dim idRubro As Integer = 0
      Dim idProducto As String = String.Empty
      Dim IdProveedor As Long = 0
      Dim incluirPreComprobantes As Boolean = False


      Dim dt As DataTable

      Me.ugDetalle.DataSource = Nothing

      Try

         If Me.chbCliente.Checked Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.chbTipoComprobante.Checked Then
            idTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         Dim tipoVendedor As String = String.Empty
         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
            tipoVendedor = Me.cmbOrigenVendedorFiltro.SelectedValue.ToString()
         End If

         If Me.chbMarca.Checked Then
            idMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If

         If Me.chbRubro.Checked Then
            idRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.chbZonaGeografica.Checked Then
            idZonaGeografica = Me.cmbZonaGeografica.SelectedValue.ToString()
         End If

         If Me.chbProducto.Checked Then
            idProducto = Me.bscCodigoProducto2.Text
         End If

         If Me.chbIncluirPreComprobantes.Checked Then
            incluirPreComprobantes = True
         End If

         If Me.bscCodigoProveedor.Selecciono() Or Me.bscProveedor.Selecciono() Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         Dim desde As Date = Me.dtpDesde.Value
         Dim hasta As Date = Me.dtpHasta.Value

         '# Agrupamientos
         Dim agruparXRubro As Boolean = Me.chbRubroAgrupar.Checked
         Dim agruparXMarca As Boolean = Me.chbMarcaAgrupar.Checked
         Dim agruparXVendedor As String = If(Me.chbVendedorAgrupar.Checked, Me.cmbOrigenVendedor.SelectedValue.ToString(), Nothing)

         dt = oVentas.InfTotalesDeVentasPorClientes(cmbSucursal.GetSucursales(),
                                                    desde,
                                                    hasta,
                                                    Me.chbConIVA.Checked,
                                                    idCliente,
                                                    idTipoComprobante,
                                                    idZonaGeografica,
                                                    idMarca,
                                                    idRubro,
                                                    IdVendedor,
                                                    tipoVendedor,
                                                    idProducto,
                                                    cmbGrupos.GetGruposTiposComprobantes(),
                                                    Me.cmbGrabanLibro.SelectedItem.ToString(),
                                                    agruparXRubro,
                                                    agruparXMarca,
                                                    agruparXVendedor,
                                                    IdProveedor,
                                                    incluirPreComprobantes,
                                                    Me.chbMostrarProveedorHabitual.Checked)

         Me.ugDetalle.DataSource = dt

         Me.FormatearGrilla()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

#End Region

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      'Me.ugDetalle.DisplayLayout.Bands(0).Columns("CodigoProductoProveedor").Hidden = Not Me.chbProveedor.Checked
      'Me.ugDetalle.DisplayLayout.Bands(0).Columns("Embalaje").Hidden = Not Me.chbProveedor.Checked

      If Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Focus()
      End If
   End Sub
End Class
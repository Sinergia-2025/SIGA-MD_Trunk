Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Public Class InfVentasSumaPorMarcas

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private IdUsuario As String = actual.Nombre

   Private _blnMiraUsuario As Boolean
   Private _blnMiraPC As Boolean
   Private _blnCajasModificables As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         _blnMiraUsuario = True
         _blnMiraPC = False
         _blnCajasModificables = False

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
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)


         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboCategorias(Me.cmbCategoria)
         _publicos.CargaComboListaDePrecios(cmbListaDePrecios)

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreMarca", "NombreListaPrecios", "DescripcionFormasPago"})

         Me.CargarColumnasASumar()

         'Hay que colocarlo luego del CargarColumnasASumar porque sino da error.
         Me.PreferenciasLeer(Me.ugDetalle)

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.chbUnificar.Enabled = Me.cmbSucursal.Enabled

         Me._publicos.CargaComboCajas(Me.cmbCajas, cmbSucursal.GetSucursales(), _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         cmbCajas.SelectedIndex = -1

         Me._estaCargando = False

         Me.RefrescarDatos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfVentasSumaPorRubros_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()

         UltraPrintPreviewD.Focus()

         'Dim vri As VisorReportesInfra = New VisorReportesInfra()
         'vri.Documento = Me.UltraGridPrintDocument1
         'vri.Name = Me.Text
         'vri.Show()

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

         If Me.chbMarca.Checked Then
            .AppendFormat(" Marca: {0} - ", Me.cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" Rubro: {0} - ", Me.cmbRubro.Text)
         End If

         If Me.chbProveedor.Checked Then
            .AppendFormat(" Proveedor: {0} - {1} - ", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If
         If Me.chbCategoria.Checked Then
            .AppendFormat(" Categoria: {0} - ", Me.cmbCategoria.Text)
         End If
         If Me.chbCaja.Checked Then
            .AppendFormat(" Caja: {0} - ", Me.cmbCajas.Text)
         End If
         If Me.chbListaDePrecios.Checked Then
            .AppendFormat(" Lista de Precios: {0} - ", Me.cmbListaDePrecios.Text)
         End If
         If Me.chbPromediar.Checked Then
            .AppendFormat(" Promedio Dias: {0} - ", Me.lblPromediar.Text)
         End If

         If Me.chbAlertaDeCaja.Checked Then
            .AppendFormat(" Solo con Alerta de Caja: {0} -", Me.chbAlertaDeCaja.Text)
         End If

         If Me.chbUnificar.Checked Then
            .AppendFormat(" Unificado -")
         End If
         .AppendFormat(" Incluye IVA: {0} -", If(Me.chbConIVA.Checked, "SI", "NO"))
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
            Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim excelExport As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.xls", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim excelExport As UltraGridExportarPDF = New UltraGridExportarPDF(UltraGridDocumentExporter1, Publicos.NombreEmpresaImpresion)
         excelExport.Exportar(String.Format("{0}.pdf", Me.Name), Text, ugDetalle, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbPreferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPreferencias.Click
      Try
         Me.PreferenciasCargar(Me.ugDetalle)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
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

   Private Sub dtpDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDesde.ValueChanged
      Me.lblPromediar.Text = Me.DiasHabiles(Me.dtpDesde.Value, Me.dtpHasta.Value).ToString()
   End Sub

   Private Sub dtpHasta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpHasta.ValueChanged
      Me.lblPromediar.Text = Me.DiasHabiles(Me.dtpDesde.Value, Me.dtpHasta.Value).ToString()
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

   Private Sub chbCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCaja.CheckedChanged
      Try
         If Not Me.chbCaja.Checked Then
            Me.cmbCajas.SelectedIndex = -1
         Else
            Me.cmbCajas.Focus()
         End If
         Me.cmbCajas.Enabled = Me.chbCaja.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
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

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged

      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         If Me.cmbMarca.Items.Count > 0 Then
            Me.cmbMarca.SelectedIndex = 0
         End If
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
      End If

      Me.cmbRubro.Focus()

   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      If Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Focus()
      End If

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

   Private Sub chbPromediar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPromediar.CheckedChanged
      Me.lblPromediar.Visible = Me.chbPromediar.Checked
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbCaja.Checked AndAlso cmbCajas.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar una CAJA.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbCajas.Focus()
            Exit Sub
         End If

         If chbListaDePrecios.Checked AndAlso cmbListaDePrecios.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe seleccionar una LISTA DE PRECIOS.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbListaDePrecios.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         With Me.ugDetalle.DisplayLayout.Bands(0)
            .Columns("Cantidad").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
            .Columns("Kilos").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
            .Columns("Stock").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
         End With

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

   Private Sub chbConIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbConIVA.CheckedChanged
      If Me._estaCargando Then Exit Sub
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalNeto").Hidden = Me.chbConIVA.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal").Hidden = Not Me.chbConIVA.Checked
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
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

   Private Sub chbListaDePrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaDePrecios.CheckedChanged
      Me.cmbListaDePrecios.Enabled = Me.chbListaDePrecios.Checked
      If Not Me.chbListaDePrecios.Checked Then
         Me.cmbListaDePrecios.SelectedIndex = -1
      Else
         If Me.cmbListaDePrecios.Items.Count > 0 Then
            Me.cmbListaDePrecios.SelectedIndex = 0
         End If
         Me.cmbListaDePrecios.Focus()
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

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatos()

      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbMesCompleto.Checked = False

      Me.chbCliente.Checked = False
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbProveedor.Checked = False
      Me.chbAlertaDeCaja.Checked = False
      Me.chbCategoria.Checked = False

      If IdUsuario = "" Then
         Me.chbVendedor.Checked = False
      End If

      Me.chbPromediar.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      cmbSucursal.Refrescar()

      Me.chbUnificar.Checked = True

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("ImporteTotalNeto") Then
         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalNeto")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotalNeto", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Kilos")
         Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Kilos", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:N2}"
         summary3.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad")
         Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Cantidad", SummaryType.Sum, columnToSummarize4)
         summary4.DisplayFormat = "{0:N2}"
         summary4.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim IdCliente As Long = 0
         Dim IdVendedor As Integer = 0

         Dim IdMarca As Integer = 0
         Dim IdRubro As Integer = 0
         Dim IdSubRubro As Integer = 0
         Dim IdProveedor As Long = 0
         Dim AlertaDeCaja As Boolean = False
         Dim IdCategoria As Integer = 0

         If chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.chbMarca.Checked Then
            IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If

         If Me.chbRubro.Checked Then
            IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         If Me.bscCodigoProveedor.Selecciono() Or Me.bscProveedor.Selecciono() Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If chbAlertaDeCaja.Checked Then
            AlertaDeCaja = True
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         Dim idListaPrecios As Integer = -1
         If chbListaDePrecios.Checked AndAlso cmbListaDePrecios.SelectedIndex > -1 Then
            idListaPrecios = Integer.Parse(cmbListaDePrecios.SelectedValue.ToString())
         End If

         Dim idCaja As Integer = 0
         Dim idSucursalCaja As Integer = 0
         If chbCaja.Checked AndAlso cmbCajas.SelectedIndex > -1 Then
            idCaja = Integer.Parse(cmbCajas.SelectedValue.ToString())
            idSucursalCaja = Integer.Parse(DirectCast(cmbCajas.SelectedItem, DataRowView).Row("IdSucursal").ToString())
         End If

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oVenta.GetSumaPorMarcas(Me.cmbSucursal.GetSucursales(), _
                                                Me.dtpDesde.Value, Me.dtpHasta.Value, _
                                                IdVendedor,
                                                IdCliente, _
                                                IdMarca, _
                                                IdRubro, _
                                                IdSubRubro, _
                                                IdProveedor, _
                                                AlertaDeCaja, _
                                                IdCategoria, _
                                                Me.chbUnificar.Checked,
                                                idListaPrecios,
                                                idCaja,
                                                idSucursalCaja)

         dt = Me.CrearDT()

         Dim PromediarPor As Integer = 1

         If Me.chbPromediar.Checked Then
            PromediarPor = Integer.Parse(Me.lblPromediar.Text)
         End If

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("NombreMarca") = dr("NombreMarca").ToString()
            drCl("NombreListaPrecios") = dr("NombreListaPrecios").ToString()
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago").ToString()
            drCl("ImporteTotalNeto") = Decimal.Round(Decimal.Parse(dr("ImporteTotalNeto").ToString()) / PromediarPor, 2)
            drCl("ImporteTotal") = Decimal.Round(Decimal.Parse(dr("ImporteTotal").ToString()) / PromediarPor, 2)
            drCl("Kilos") = Decimal.Round(Decimal.Parse(dr("Kilos").ToString()) / PromediarPor, 2)
            drCl("Cantidad") = Decimal.Round(Decimal.Parse(dr("Cantidad").ToString()) / PromediarPor, Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad)
            drCl("Stock") = Decimal.Parse(dr("Stock").ToString())
            drCl("IdSucursal") = dr("IdSucursal")

            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Me.chbUnificar.Checked

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
         .Columns.Add("NombreListaPrecios", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionFormasPago", System.Type.GetType("System.String"))
         .Columns.Add("ImporteTotalNeto", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Kilos", System.Type.GetType("System.Decimal"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
         .Columns.Add("Stock", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
      End With

      Return dtTemp

   End Function

   Private Function DiasHabiles(ByVal FechaDesde As Date, ByVal FechaHasta As Date) As Integer

      Dim Dias As Integer = 1

      Dim Dia As Date = FechaDesde.Date

      Do While Dia < FechaHasta.Date

         If Dia.DayOfWeek <> DayOfWeek.Saturday And Dia.DayOfWeek <> DayOfWeek.Sunday Then
            Dias += 1
         End If

         Dia = Dia.AddDays(1)

      Loop

      Return Dias

   End Function

#End Region

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      Try
         Me._publicos.CargaComboCajas(Me.cmbCajas, cmbSucursal.GetSucursales(), _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
         cmbCajas.SelectedIndex = -1
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

End Class
Public Class InfComisionesProductos
   Implements IConParametros
#Region "Campos"

   Private _publicos As Publicos

   Private _parametros As Reglas.Parametros
   Private _modo As String
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()

         If String.IsNullOrWhiteSpace(_modo) Then _modo = "COMISION"

         _publicos = New Publicos()

         _parametros = New Reglas.Parametros()

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboCategorias(cmbCategoria)

         'Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)
         'If Not Publicos.ProductoTieneSubRubro Then
         '   Me.chbSubRubro.Visible = False
         '   Me.cmbSubRubro.Visible = False
         '   Me.dgvDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = True
         'End If

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "CTACTECLIE")
         cmbTiposComprobantes.SelectedIndex = -1

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         cmbCobrador.SelectedIndex = -1

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         _publicos.CargaComboUsuarios(cmbUsuario)

         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1

         cmbGrabanLibro.Items.Insert(0, "TODOS")
         cmbGrabanLibro.Items.Insert(1, "SI")
         cmbGrabanLibro.Items.Insert(2, "NO")
         cmbGrabanLibro.SelectedIndex = 0

         cmbAfectaCaja.Items.Insert(0, "TODOS")
         cmbAfectaCaja.Items.Insert(1, "SI")
         cmbAfectaCaja.Items.Insert(2, "NO")
         cmbAfectaCaja.SelectedIndex = 1

         cmbIngresosBrutos.Items.Insert(0, "TODOS")
         cmbIngresosBrutos.Items.Insert(1, "SI")
         cmbIngresosBrutos.Items.Insert(2, "NO")
         cmbIngresosBrutos.SelectedIndex = 0

         cmbProdDescRec.Items.Insert(0, "TODOS")
         cmbProdDescRec.Items.Insert(1, "SI")
         cmbProdDescRec.Items.Insert(2, "NO")
         cmbProdDescRec.SelectedIndex = 0

         cmbVendedorOrigen.Items.Add("RECIBO")
         cmbVendedorOrigen.Items.Add("FACTURA")
         cmbVendedorOrigen.Items.Add("CLIENTE")
         cmbVendedorOrigen.SelectedIndex = 0

         cmbCobradorOrigen.Items.Add("RECIBO")
         cmbCobradorOrigen.Items.Add("FACTURA")
         cmbCobradorOrigen.Items.Add("CLIENTE")
         cmbCobradorOrigen.SelectedIndex = 0

         Dim aCantidad As ArrayList = New ArrayList
         aCantidad.Insert(0, "Negativo ( < 0 )")
         aCantidad.Insert(1, "Igual a Cero ( = 0 )")
         aCantidad.Insert(2, "Mayor a Cero ( > 0 )")
         cmbCantidad.DataSource = aCantidad
         cmbCantidad.SelectedIndex = -1   '0

         _publicos.CargaComboProvincias(cmbProvincia)

         ''Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         ugDetalle.AgregarTotalesSuma({"ImporteTotalNeto", "Comision", "ImporteTotalParcial"})

         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         If _modo = "COBRANZA" Then
            Text = "Informe de Cobranzas por Producto"
         End If

         ugDetalle.DisplayLayout.Bands(0).Columns("PorcComision").Hidden = _modo = "COBRANZA"
         ugDetalle.DisplayLayout.Bands(0).Columns("Comision").Hidden = _modo = "COBRANZA"
         lblTotalComisiones.Visible = _modo = "COMISION"
         txtTotalComisiones.Visible = _modo = "COMISION"

         'ugDetalle.DisplayLayout.Bands(0).Columns("NombreLocalidad").Hidden = False
         'ugDetalle.DisplayLayout.Bands(0).Columns("NombreProvincia").Hidden = False
         chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         cmbSucursal.Initializar(False, IdFuncion) 'actual.Sucursal.Id
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

         If Publicos.IDAplicacionSinergia = "SISEN" Then
            _publicos.CargaComboCategoriasEmbarcaciones(Me.cmbCategoriasEmbarcaciones)
            chbCategoriaEmbarcacion.Visible = True
            cmbCategoriasEmbarcaciones.Visible = True
         End If

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         If Publicos.IDAplicacionSinergia = "SISEN" Then
            ugDetalle.DisplayLayout.Bands(0).Columns("IdEmbarcacion").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreEmbarcacion").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("IdCategoriaEmbarcacion").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreCategoriaEmbarcacion").Hidden = False
         End If


      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbProducto.Checked Then
            Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
         End If

         If Me.chbMarca.Checked Then
            Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
         End If

         If Me.chbRubro.Checked Then
            Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
         End If

         If Me.chbLote.Checked Then
            Filtros = Filtros & " / Lote: " & Me.bscLote.Text
         End If

         If Me.chbCantidad.Checked Then
            Filtros = Filtros & " / Cantidad: " & Me.cmbCantidad.Text
         End If

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            Filtros = Filtros & " / Tipo Comprobante: " & Me.cmbTiposComprobantes.Text
         End If

         If Me.chbVendedor.Checked Then
            Dim IdVendedor As Integer
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
            Filtros = Filtros & " / Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.chbCobrador.Checked Then
            Dim cobrador As Entidades.Empleado
            cobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado)
            Filtros = Filtros & String.Format(" / Cobrador: {1} - {2}", cobrador.NroDocEmpleado, cobrador.NombreEmpleado)
         End If

         If Me.cmbFormaPago.Enabled Then
            Filtros = Filtros & " / F. de Pago: " & Me.cmbFormaPago.Text
         End If

         If Me.cmbUsuario.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
         End If

         If Me.bscCodigoProveedor.Selecciono() Or Me.bscProveedor.Selecciono() Then
            Filtros = Filtros & " / Proveedor: " & Me.bscCodigoProveedor.Text.Trim() & " - " & Me.bscProveedor.Text.Trim()
         End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, String.Empty))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, String.Empty))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         Me._publicos.PreparaGrillaClientes(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      TryCatched(Sub() chbCobrador.FiltroCheckedChanged(cmbCobrador))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
#Region "Eventos Buscador Lote"
   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged
      TryCatched(Sub() chbLote.FiltroCheckedChanged(usaPermitido:=True, bscLote))
   End Sub
   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLotes(bscLote)
         bscLote.Datos = New Reglas.ProductosLotes().GetFiltradoPorId(bscLote.Text, actual.Sucursal.Id)
      End Sub)
   End Sub
   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            bscLote.Permitido = False
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
#End Region
   Private Sub chbCantidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbCantidad.CheckedChanged
      TryCatched(Sub() chbCantidad.FiltroCheckedChanged(cmbCantidad))
   End Sub
#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
   End Sub
#Region "Eventos Buscador Localidad"
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(usaPermitido:=True, bscCodigoLocalidad, bscNombreLocalidad))
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
         bscCodigoLocalidad.Datos = New Reglas.Localidades().GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscNombreLocalidad)
         bscNombreLocalidad.Datos = New Reglas.Localidades().GetPorNombre(bscNombreLocalidad.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion, bscNombreLocalidad.BuscadorSeleccion
      TryCatched(Sub() CargarLocalidad(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
   Private Sub chbCategoriaEmbarcacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaEmbarcacion.CheckedChanged
      TryCatched(Sub() chbCategoriaEmbarcacion.FiltroCheckedChanged(cmbCategoriasEmbarcaciones))
   End Sub

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.")
            cmbMarca.Focus()
            Exit Sub
         End If
         If chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.")
            cmbRubro.Focus()
            Exit Sub
         End If
         If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If
         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If
         If chbLote.Checked And Not bscLote.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Lote aunque activó ese Filtro.")
            bscLote.Focus()
            Exit Sub
         End If
         If chbCategoriaEmbarcacion.Checked And cmbCategoriasEmbarcaciones.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Categoría de Embarcación aunque activó ese Filtro")
            cmbCategoriasEmbarcaciones.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
         bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
         bscNombreLocalidad.Permitido = False
         bscCodigoLocalidad.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      rbtPorProducto.Checked = True
      rbtCobranzaParcial.Checked = True

      chbTipoComprobante.Checked = False

      chbProducto.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      chbProducto.Checked = False

      bscLote.Text = String.Empty

      cmbIngresosBrutos.SelectedIndex = 0
      cmbProdDescRec.SelectedIndex = 0

      chbCantidad.Checked = False

      chbCliente.Checked = False
      chbVendedor.Checked = False

      chbCobrador.Checked = False

      cmbGrabanLibro.SelectedIndex = 0
      cmbAfectaCaja.SelectedIndex = 1

      chbFormaPago.Checked = False
      chbUsuario.Checked = False
      chbProveedor.Checked = False
      chbZonaGeografica.Checked = False

      chbLocalidad.Checked = False
      chbProvincia.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
      chbCategoria.Checked = False
      chbCategoriaEmbarcacion.Checked = False

      ugDetalle.ClearFilas()

      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      txtTotalCobranzas.Text = "0.00"
      txtTotalComisiones.Text = "0.00"
      cmbVendedorOrigen.SelectedIndex = 0
      cmbCobradorOrigen.SelectedIndex = 0

      cmbSucursal.Refrescar()

      dtpDesde.Focus()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text.Trim(), String.Empty)
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim lote = If(chbLote.Checked, bscLote.Text, String.Empty)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim tipoComprobante = If(cmbTiposComprobantes.Enabled, cmbTiposComprobantes.SelectedValue.ToString(), String.Empty)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idCobrador = cmbCobrador.ValorSeleccionado(chbCobrador, 0I)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)
      Dim idFormaDePago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)
      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)
      Dim cantidad = If(chbCantidad.Checked AndAlso cmbCantidad.SelectedIndex > -1, {" < 0", " = 0", " > 0"}(cmbCantidad.SelectedIndex), String.Empty)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0I)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0I)
      Dim tipoVendedor = cmbVendedorOrigen.SelectedItem.ToString()
      Dim tipoCobrador = cmbCobradorOrigen.SelectedItem.ToString()
      Dim idCategoriaEmbarcacion = cmbCategoriasEmbarcaciones.ValorSeleccionado(chbCategoriaEmbarcacion, 0I)
      Dim embarcacion = Publicos.IDAplicacionSinergia = "SISEN"

      Dim rVentasProd = New Reglas.VentasProductos()
      Dim dtDetalle = rVentasProd.GetComisionesPorProducto(cmbSucursal.GetSucursales(), dtpDesde.Value, dtpHasta.Value,
                                                           idProducto, idMarca, idModelo:=0I, idRubro, idSubRubro:=0I,
                                                           idZonaGeografica, tipoComprobante, idVendedor, idCliente,
                                                           cmbGrabanLibro.Text, cmbAfectaCaja.Text, idFormaDePago, idUsuario,
                                                           porcUtilidadDesde:=-1D, porcUtilidadHasta:=-1D,
                                                           cantidad,
                                                           cmbIngresosBrutos.Text, cmbProdDescRec.Text,
                                                           idProveedor, idLocalidad, idProvincia, idCategoria,
                                                           rbtCobranzaParcial.Checked, tipoVendedor, idCobrador, tipoCobrador,
                                                           chbConIVA.Checked, rbtPorVendedor.Checked,
                                                           embarcacion, idCategoriaEmbarcacion, If(rbtPorProducto.Checked, "LISTADO", "FACTURACION"))

      Dim totalNeto = dtDetalle.AsEnumerable().Sum(Function(dr) dr.Field(Of Decimal?)(If(rbtCobranzaParcial.Checked, "ImporteTotalParcial", "ImporteTotalNeto")).IfNull())
      Dim total = dtDetalle.AsEnumerable().Sum(Function(dr) dr.Field(Of Decimal?)("Comision").IfNull())

      txtTotalCobranzas.SetValor(totalNeto)
      txtTotalComisiones.SetValor(total)

      ugDetalle.DataSource = dtDetalle

      If ugDetalle.DisplayLayout.Bands(0).Columns.Exists("ImporteTotalParcial") Then
         ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotalParcial").FormatearColumna("Cobrado", 27, 81, HAlign.Right, rbtCobranzaTotal.Checked, "N2")
         ugDetalle.AgregarTotalesSuma({"ImporteTotalParcial"})
      End If

      If Publicos.IDAplicacionSinergia = "SISEN" Then
         ugDetalle.DisplayLayout.Bands(0).Columns("IdEmbarcacion").Hidden = False
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreEmbarcacion").Hidden = False
         ugDetalle.DisplayLayout.Bands(0).Columns("IdCategoriaEmbarcacion").Hidden = False
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreCategoriaEmbarcacion").Hidden = False
      End If

      AjustarColumnasGrilla(ugDetalle, _tit)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If parametros = "TIPO" Then
         _modo = "COMISION"
      Else
         _modo = "COBRANZA"
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Define el tipo de reporte que se utiliza.")
      stb.AppendFormatLine("Valores posibles: COMISION/COBRANZA")
      stb.AppendFormatLine("Por defecto: COBRANZA")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

#End Region

End Class
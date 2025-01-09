Public Class InfComisionesSobreVentas

#Region "Campos"

   Private _publicos As Publicos
   Private _parametros As Reglas.Parametros
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _parametros = New Reglas.Parametros()

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboCategorias(cmbCategoria)

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "VENTAS")
         cmbTiposComprobantes.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, Entidades.OrigenFK.Movimiento)
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         _publicos.CargaComboUsuarios(cmbUsuario)

         _publicos.CargaComboZonasGeograficas(cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbGrabanLibro, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbAfectaCaja, Entidades.Publicos.SiNoTodos.SI)
         _publicos.CargaComboDesdeEnum(cmbIngresosBrutos, Entidades.Publicos.SiNoTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbProdDescRec, Entidades.Publicos.SiNoTodos.TODOS)


         Dim aCantidad = New ArrayList()
         aCantidad.Insert(0, "Negativo ( < 0 )")
         aCantidad.Insert(1, "Igual a Cero ( = 0 )")
         aCantidad.Insert(2, "Mayor a Cero ( > 0 )")
         cmbCantidad.DataSource = aCantidad
         cmbCantidad.SelectedIndex = -1   '0

         _publicos.CargaComboProvincias(cmbProvincia)

         ''Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         'Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
         'Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         ugDetalle.AgregarFiltroEnLinea({"ImporteTotalNeto", "Comision"})

         'Hay que colocarlo del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreLocalidad").Hidden = False
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreProvincia").Hidden = False

         '-- REQ-31179 --
         MostrarConfiguracion()
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
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub()
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
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
   End Sub
#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(
      Sub()
         chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2)
         If chbProducto.Checked Then
            chbMarca.Checked = False
            chbRubro.Checked = False
         End If
      End Sub)
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
#Region "Eventos Buscador Lotes"
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
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
#End Region
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub
   Private Sub chbCantidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbCantidad.CheckedChanged
      TryCatched(Sub() chbCantidad.FiltroCheckedChanged(cmbCantidad))
   End Sub
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      TryCatched(Sub() chbCategoria.FiltroCheckedChanged(cmbCategoria))
   End Sub
#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region
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
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      TryCatched(Sub() chbZonaGeografica.FiltroCheckedChanged(cmbZonaGeografica))
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
            bscCodigoProducto2.Focus()
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
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
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
   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If chbVendedor.Checked Then
            .AppendFormat(" - Vendedor: {0} - {1}", cmbVendedor.Text, cmbOrigenVendedor.Text)
         End If
         If chbUsuario.Checked Then
            .AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         If chbTipoComprobante.Checked Then
            .AppendFormat(" - Tipo Comprobante: {0}", cmbTiposComprobantes.Text)
         End If
         If cmbAfectaCaja.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" - Afecta Caja: {0}", cmbAfectaCaja.Text)
         End If
         If cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS Then     '0 Es TODOS
            .AppendFormat(" - Graban Libro: {0}", cmbGrabanLibro.Text)
         End If
         If cmbIngresosBrutos.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS Then     '0 Es TODOS
            .AppendFormat(" - Ingresos Brutos: {0}", cmbIngresosBrutos.Text)
         End If
         If chbFormaPago.Checked Then
            .AppendFormat(" - Forma de Pago: {0}", cmbFormaPago.Text)
         End If
         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If chbLote.Checked Then
            .AppendFormat(" - Lote: {0}", bscLote.Text)
         End If
         If chbMarca.Checked Then
            .AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If
         If chbRubro.Checked Then
            .AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If
         .AppendFormat(" - Cantidad: {0}", cmbCantidad.Text)
         If cmbProdDescRec.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormat(" - Con Desc/Recarg.: {0}", cmbProdDescRec.Text)
         End If
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbCategoria.Checked Then
            .AppendFormat(" - Categoría {0}", cmbCategoria.Text)
         End If
         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If chbLocalidad.Checked Then
            .AppendFormat(" - Localidad: {0} - {1}", bscCodigoLocalidad.Text, bscNombreLocalidad.Text)
         End If
         If chbProvincia.Checked Then
            .AppendFormat(" - Provincia {0}", cmbProvincia.Text)
         End If
         If chbZonaGeografica.Checked Then
            .AppendFormat(" - Zona G.: {0}", cmbZonaGeografica.Text)
         End If
         .AppendFormat(" - {0} IVA", If(chbConIVA.Checked, "SI", "NO"))
      End With
      Return filtro.ToString()
   End Function
   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

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
      cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

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

      ugDetalle.ClearFilas()

      txtSubtotal.Text = "0.00"
      txtTotal.Text = "0.00"

      dtpDesde.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim idFormaDePago = cmbFormaPago.ValorSeleccionado(chbFormaPago, 0I)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim lote = If(chbLote.Checked, bscLote.Text, String.Empty)
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim cantidad = If(cmbCantidad.SelectedIndex = 0, " < 0", If(cmbCantidad.SelectedIndex = 1, " = 0", If(cmbCantidad.SelectedIndex = 2, " > 0", String.Empty)))
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idCategoria = cmbCategoria.ValorSeleccionado(chbCategoria, 0S)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0I)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0I)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)
      Dim idZonaGeografica = cmbZonaGeografica.ValorSeleccionado(chbZonaGeografica, String.Empty)

      Dim rVentasProd = New Reglas.VentasProductos()
      Dim dtDetalle = rVentasProd.GetComisionesSobreVentas(
                              actual.Sucursal.Id, dtpDesde.Value, dtpHasta.Value,
                              idProducto, idMarca, idModelo:=0I, idRubro, idSubRubro:=0I,
                              idTipoComprobante, cmbGrabanLibro.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), cmbAfectaCaja.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                              idCategoria, idCliente, idProveedor,
                              idVendedor, cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK),
                              idFormaDePago, idUsuario,
                              porcUtilidadDesde:=-1, porcUtilidadHasta:=-1,
                              cantidad, cmbIngresosBrutos.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), cmbProdDescRec.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                              idLocalidad, idProvincia, idZonaGeografica,
                              chbConIVA.Checked)

      Dim totalNeto = dtDetalle.AsEnumerable().Sum(Function(dr) dr.Field(Of Decimal)("ImporteTotalNeto"))
      Dim total = dtDetalle.AsEnumerable().Sum(Function(dr) dr.Field(Of Decimal)("Comision"))

      txtSubtotal.SetValor(totalNeto)
      txtTotal.SetValor(total)

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   '-- REQ-31179 --
   Private Sub MostrarConfiguracion()
      txtCalculoComisionVendedor.Text = Reglas.Publicos.CalculoComisionVendedor
   End Sub
#End Region

End Class
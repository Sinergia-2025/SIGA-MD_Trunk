Public Class DetalleMovDeProductosNrosSerie

#Region "Campos"
   Private _publicos As Publicos
   Private _stockInicial As Decimal
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         '# Carga Combos
         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         _publicos.CargaComboEmpleados(cmbEmpleado, Entidades.Publicos.TiposEmpleados.TODOS)
         _publicos.CargaComboTiposMovimientos(cmbTipoMovimiento)
         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, "VENTAS", "COMPRAS")

         cmbTipoMovimiento.SelectedIndex = -1
         cmbEmpleado.SelectedIndex = -1

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro

         cmbTiposComprobantes.SelectedIndex = -1

         cmbSucursal.Initializar(False, IdFuncion)
         cmbDepositos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, cmbSucursal.GetSucursales())
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         FormatearGrilla()
         ugDetalle.AgregarTotalesSuma({"Ingreso;{0:N4}", "Egreso;{0:N4}"})

         PreferenciasLeer(ugDetalle, ugDetalle.Name, tsbPreferencias)

         RefrescarDatosGrilla()
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

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If ValidarFiltros() Then
            If chbProducto.Checked Then
               'Actualiza el stock actual queda la pantalla levantada un tiempo y vuelve a "consultar"
               bscCodigoProducto2.PresionarBoton()
            End If

            '# Carga grilla
            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("NO hay registros que cumplan con la seleccion !!!")
            End If
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs)
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, ugDetalle.Name, tsbPreferencias))
      TryCatched(Sub() PreferenciasLeer(ugDetalle, ugDetalle.Name, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim habilitaDeposito As Boolean = False
         If cmbSucursal.SelectedIndex > 0 Then
            Dim sucursal = cmbSucursal.GetSucursales()
            If sucursal.Length > 0 Then
               cmbDepositos.Inicializar(True, True, True, sucursal)
               habilitaDeposito = cmbDepositos.GetDepositos().Count > 1
            End If
         End If
         cmbDepositos.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      End Sub)
   End Sub
   Private Sub chbTipoMovimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoMovimiento.CheckedChanged
      TryCatched(Sub() chbTipoMovimiento.FiltroCheckedChanged(cmbTipoMovimiento))
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTiposComprobantes))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmpleado.CheckedChanged
      TryCatched(Sub() chbEmpleado.FiltroCheckedChanged(cmbEmpleado))
   End Sub
   Private Sub chbNroDeSerie_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroDeSerie.CheckedChanged
      TryCatched(Sub() chbNroDeSerie.FiltroCheckedChanged(txtNroDeSerie))
   End Sub

#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(bscCodigoProducto2, bscProducto2))
      TryCatched(
      Sub()
         lblStockActual.Visible = chbProducto.Checked
         txtStockActual.Visible = chbProducto.Checked
         txtStockActual.Text = "0.00"

         lblStockInicial.Visible = chbProducto.Checked
         txtStockInicial.Visible = chbProducto.Checked
         txtStockInicial.Text = "0.00"

         lblStockFinal.Visible = chbProducto.Checked
         txtStockFinal.Visible = chbProducto.Checked
         txtStockFinal.Text = "0.00"
      End Sub)

      ''Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      'If chbProducto.Checked Then
      '   'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
      '   chbMarca.Checked = False
      '   chbRubro.Checked = False
      'End If
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Lote"
   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged
      TryCatched(Sub() chbLote.FiltroCheckedChanged(bscLote))
   End Sub
   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLotes(bscLote)
         bscLote.Datos = New Reglas.ProductosLotes().GetFiltradoPorId(bscLote.Text, actual.Sucursal.Id)
      End Sub)
   End Sub
   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(
      Sub()
         If e.FilaDevuelta IsNot Nothing Then
            bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            btnConsultar.Focus()
         End If
      End Sub)
   End Sub
#End Region

#Region "Eventos Buscador Cliente"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, busquedaParcial:=True, soloActivos:=False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text)
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
                    cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
                    cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                           marcas:=marcas)
                 End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                    cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
                    cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                                subRubro:=subRubros)
                 End Sub)

   End Sub

#End Region

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If e.Cell.Column.Key = "Ver" Then
               Dim muestraCombo = dr.Field(Of Boolean)("MuestraCombo")

               If Not String.IsNullOrWhiteSpace(dr.Field(Of String)("NumeroComprobante")) Then
                  ShowMessage(String.Format("El movimiento está asociado al comprobante {0} {1} {2}. Dirijase al módulo correspondiente para imprimirlo.",
                                            dr.Field(Of String)("TipoComprobante"),
                                            dr.Field(Of String)("Letra"),
                                            dr.Field(Of Long)("NumeroComprobante")))
               ElseIf Not String.IsNullOrWhiteSpace(dr.Field(Of String)("IdProduccion")) Then
                  ShowMessage(String.Format("El movimiento pertenece al módulo de producción. Dirijase al mismo para imprimirlo."))
               Else
                  Dim idDeposito = dr.Field(Of Integer)("IdDeposito")
                  Dim idTipoMovimiento = dr.Field(Of String)("IdTipoMovimiento")
                  Dim numeroMovimiento = dr.Field(Of Long)("NumeroMovimiento")

                  Dim oMov = New Reglas.MovimientosStock().GetUno(actual.Sucursal.Id, idTipoMovimiento, numeroMovimiento)
                  Dim impresion = New ImprimirMovimientoStock()
                  impresion.Imprimir(oMov)
               End If
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Métodos"

   Private Sub RefrescarDatosGrilla()
      cmbSucursal.Refrescar()
      cmbDepositos.Refrescar()

      chbTipoMovimiento.Checked = False
      chbTipoComprobante.Checked = False

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbEmpleado.Checked = False

      chbProducto.Checked = False
      chbLote.Checked = False
      chbNroDeSerie.Checked = False

      chbCliente.Checked = False
      chbProveedor.Checked = False

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idTipoMovimiento = cmbTipoMovimiento.ValorSeleccionado(chbTipoMovimiento, String.Empty)
      Dim idTipoComprobante = cmbTiposComprobantes.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim idEmpleado = cmbEmpleado.ValorSeleccionado(chbEmpleado, 0I)

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim nroSerie = txtNroDeSerie.ValorSeleccionado(chbNroDeSerie, String.Empty)
      Dim lote = If(chbLote.Checked, bscLote.Text, String.Empty)

      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)

      txtStockInicial.SetValor(0)
      txtStockFinal.SetValor(0)

      Dim rStock = New Reglas.Stock()

      If chbProducto.Checked Then
         Dim saldosIniciales = rStock.GetSaldoDetallePorProducto(actual.Sucursal.Id, Date.Parse("01/01/1900"), dtpDesde.Value.AddDays(-1), idProducto)
         txtStockInicial.Text = String.Format("{0:N4}", _stockInicial + saldosIniciales.SaldoInicial)
      End If

      'Si filtra un producto, muestra el saldo
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("Saldo").Hidden = Not (chbProducto.Checked And txtStockFinal.Visible)
      End With

      'Si filtra NO un producto, muestra otro detalle
      ugDetalle.DisplayLayout.Bands(0).Columns("IdProducto").Hidden = chbProducto.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreProducto").Hidden = chbProducto.Checked

      'Por ahora tiene el codigo, deberia tener la descripcion. Pero por performance no lo hago. Que lo soliciten.
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreMarca").Hidden = chbProducto.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("NombreRubro").Hidden = chbProducto.Checked

      Dim descStockFinal = Decimal.Parse(txtStockInicial.Text)

      Dim dt = rStock.GetInformeDetallePorProductoNrosSerie(cmbSucursal.GetSucursales(), cmbDepositos.GetDepositos(),
                                                            idTipoMovimiento, idTipoComprobante,
                                                            dtpDesde.Value, dtpHasta.Value,
                                                            idEmpleado,
                                                            idProducto, nroSerie, lote,
                                                            idCliente, idProveedor,
                                                            cmbMarcas.GetMarcas(todosVacio:=True), cmbModelos.GetModelos(todosVacio:=True),
                                                            cmbRubros.GetRubros(todosVacio:=True), cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True))

      '# Ajusto algunos valores antes de mostrarlo por pantalla
      AjustarColumnasIngresosEgresos(dt, descStockFinal)

      txtStockFinal.Text = descStockFinal.ToString("N2")

      ugDetalle.DataSource = dt
      FormatearGrilla()
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

         If Boolean.Parse(dr.Cells("AfectaStock").Value.ToString()) Then
            'Me daba error la otra forma, desde que le puse el formato en la grilla
            txtStockActual.Text = dr.Cells("Stock").Value.ToString()     'dr.Cells("Stock").Value.ToString("##,##0.00")
            _stockInicial = Decimal.Parse(dr.Cells("StockInicial").Value.ToString())
            txtStockInicial.SetValor(0)
         Else
            lblStockActual.Visible = False
            txtStockActual.Visible = False
            lblStockInicial.Visible = False
            txtStockInicial.Visible = False
            lblStockFinal.Visible = False
            txtStockFinal.Visible = False
         End If

         bscProducto2.Enabled = False
         bscCodigoProducto2.Enabled = False
      End If
      btnConsultar.Focus()
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Enabled = False
         bscCodigoCliente.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Enabled = False
         bscCodigoProveedor.Enabled = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)
      cmbDepositos.CargarFiltrosImpresionDepositos(filtro, muestraId:=False, muestraNombre:=True)

      If chbTipoMovimiento.Enabled Then
         filtro.AppendFormat(" - Tipo Movimiento: {0}", cmbTipoMovimiento.Text)
      End If
      If chbTipoComprobante.Enabled Then
         filtro.AppendFormat(" - Tipo Comprobante: {0}", cmbTiposComprobantes.Text)
      End If

      filtro.AppendFormat(" - Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy}", dtpDesde.Text, dtpHasta.Text)

      If chbEmpleado.Enabled Then
         filtro.AppendFormat(" - Empleado: {0}", cmbEmpleado.Text)
      End If


      If chbProducto.Checked Then
         filtro.AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
      End If
      If chbLote.Checked Then
         filtro.AppendFormat(" - Lote: {0}", bscLote.Text)
      End If
      If chbNroDeSerie.Checked Then
         filtro.AppendFormat(" - Nro. Serie: {0}", txtNroDeSerie.Text)
      End If

      If chbCliente.Checked Then
         filtro.AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text.Trim(), bscCliente.Text.Trim())
      End If
      If chbProveedor.Checked Then
         filtro.AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text.Trim(), bscProveedor.Text.Trim())
      End If

      If cmbMarcas.Visible Then cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=True, muestraNombre:=False)
      If cmbModelos.Visible Then cmbModelos.CargarFiltrosImpresionModelos(filtro, muestraId:=True, muestraNombre:=False)
      If cmbRubros.Visible Then cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=True, muestraNombre:=False)
      If cmbSubRubros.Visible Then cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, muestraId:=True, muestraNombre:=False)
      If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargarFiltrosImpresionSubSubRubros(filtro, muestraId:=True, muestraNombre:=False)

      Return filtro.ToString()
   End Function

   Private Function ValidarFiltros() As Boolean
      If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
         ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
         bscCodigoProducto2.Focus()
         Return False
      End If
      If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
         ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
         bscCodigoCliente.Focus()
         Return False
      End If
      If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
         ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
         bscCodigoProveedor.Focus()
         Return False
      End If
      If chbLote.Checked And Not bscLote.Selecciono Then
         ShowMessage("ATENCION: NO seleccionó un Lote aunque activó ese Filtro.")
         bscLote.Focus()
         Return False
      End If
      If chbEmpleado.Checked And cmbEmpleado.SelectedIndex = -1 Then
         ShowMessage("ATENCION: NO seleccionó un Empleado aunque activó ese Filtro.")
         cmbEmpleado.Focus()
         Return False
      End If
      If chbNroDeSerie.Checked AndAlso String.IsNullOrEmpty(txtNroDeSerie.Text) Then
         ShowMessage("ATENCION: NO ingresó un Nro. Serie aunque activó ese Filtro.")
         txtNroDeSerie.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub FormatearGrilla()
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdSucursal").Hidden = Not Me.cmbSucursal.Enabled

         .Columns("IdProducto").CellAppearance.TextHAlign = HAlign.Left
         .Columns("Ingreso").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Egreso").CellAppearance.TextHAlign = HAlign.Right

         .Columns("CentroEmisor").Hidden = True
         .Columns("IdClienteProveedor").Hidden = True
         .Columns("NombreSucursalDeA").Hidden = True

         '#####################################################################################################################################
         '# Verificar si las columnas 'Ingreso Disponible' y 'Egreso Disponible' son las únicas columnas de tipo 'Ingreso'/'Egreso' visibles. #
         '# De ser así, el header caption debe mostrar 'Ingreso'/'Egrego' (sin la palabra 'Disponible').                                      #  
         '#####################################################################################################################################
         If Not Reglas.Publicos.UtilizaStockDefectuoso AndAlso
            Not Reglas.Publicos.UtilizaStockReservado AndAlso
            Not Reglas.Publicos.UtilizaStockFuturo AndAlso
            Not Reglas.Publicos.UtilizaStockFuturoReservado Then

            .Columns("Ingreso").Header.Caption = "Ingreso"
            .Columns("Egreso").Header.Caption = "Egreso"
            .Columns("Saldo").Header.Caption = "Saldo"
         End If

         '# En caso de que utilice SubRubro
         .Columns(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).Hidden = Not Reglas.Publicos.ProductoTieneSubRubro

      End With
      AgregarFiltroEnLinea(ugDetalle, {Entidades.Producto.Columnas.IdProducto.ToString(),
                                       "NombreClienteProveedor",
                                       Entidades.ProductoNroSerie.Columnas.NroSerie.ToString(),
                                       Entidades.Producto.Columnas.NombreProducto.ToString(),
                                       "Observacion"})
   End Sub

   Private Sub SetIngresoEgresoSaldo(drOrigen As DataRow, campoIngreso As String, campoEgreso As String, campoSaldo As String, ByRef decStockFinal As Decimal)
      'Dim ingreso As Decimal = 0
      'If IsNumeric(drOrigen(campoIngreso)) Then
      '   ingreso = Decimal.Parse(drOrigen(campoIngreso).ToString())
      'End If
      'Dim egreso As Decimal = 0
      'If IsNumeric(drOrigen(campoEgreso)) Then
      '   egreso = Decimal.Parse(drOrigen(campoEgreso).ToString())
      'End If

      Dim ingreso = drOrigen.Field(Of Decimal?)(campoIngreso).IfNull()
      Dim egreso = drOrigen.Field(Of Decimal?)(campoEgreso).IfNull()

      decStockFinal += ingreso + egreso

      '# Decido quién va a ser la rowDestino si se están pasando datos hacia otro DT o se editando los registros de un mismo DT
      Dim rowDestino = drOrigen
      '------------------------------------------------------
      rowDestino(campoIngreso) = If(ingreso = 0, DBNull.Value, DirectCast(ingreso, Object))
      rowDestino(campoEgreso) = If(egreso = 0, DBNull.Value, DirectCast(egreso * -1, Object))

      'If ingreso = 0 Then
      '   rowDestino(campoIngreso) = DBNull.Value
      'Else
      '   rowDestino(campoIngreso) = ingreso
      'End If

      'If egreso = 0 Then
      '   rowDestino(campoEgreso) = DBNull.Value
      'Else
      '   rowDestino(campoEgreso) = egreso * -1
      'End If

      rowDestino(campoSaldo) = decStockFinal

   End Sub
   Private Sub AjustarColumnasIngresosEgresos(dt As DataTable,
                                              ByRef descStockFinal As Decimal)
      '# Agrego columnas faltantes
      With dt.Columns
         .Add("Saldo", GetType(Decimal))
      End With

      Dim dtAjustado = dt.Copy()
      Dim drA = dtAjustado.NewRow()

      For Each dr In dt.AsEnumerable()
         '# Si las columnas de tipo Ingreso/Egreso vienen con valor 0, las limpio para mejor visualización
         SetIngresoEgresoSaldo(dr, "Ingreso", "Egreso", "Saldo", descStockFinal)
      Next
   End Sub

   'Private Sub SetIngresoEgresoSaldo(drOrigen As DataRow, campoIngreso As String, campoEgreso As String, campoSaldo As String, ByRef decStockFinal As Decimal)
   '   SetIngresoEgresoSaldo(drOrigen, Nothing, campoIngreso, campoEgreso, campoSaldo, decStockFinal)
   'End Sub

#End Region

End Class
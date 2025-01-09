Public Class InfPedidosDetalladosProv
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private IdUsuario As String = actual.Nombre
   Private _tipoTipoComprobante As String

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         _publicos = New Publicos()

         _publicos.CargaComboEstadosPedidosProv(cmbEstados, True, True, True, True, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.TODOS)

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboUsuarios(cmbUsuario)

         'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         _publicos.CargaComboEmpleados(cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR, IdUsuario)
         If IdUsuario = "" Then
            cmbComprador.SelectedIndex = -1
         Else
            chbComprador.Checked = True
            chbComprador.Enabled = False  'Para que no pueda modificarlo manualmente
         End If
         'Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.AgregarTotalesSuma({"cantEntregada", "cantPendiente", "TamanoTotal"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)
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
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region
#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      TryCatched(Sub() chbIdPedido.FiltroCheckedChanged(txtIdPedido))
   End Sub
   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      TryCatched(Sub() chbFechaEntrega.FiltroCheckedChanged(chkMesCompletoEntrega, dtpDesdeEntrega, dtpHastaEntrega))
   End Sub
   Private Sub chkMesCompletoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      TryCatched(Sub() chkMesCompletoEntrega.FiltroCheckedChangedMesCompleto(dtpDesdeEntrega, dtpHastaEntrega))
   End Sub
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra))
   End Sub
#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick, bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor, True)
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
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
#Region "Eventos Buscador Producto"
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
   Private Sub chbComprador_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprador.CheckedChanged
      TryCatched(Sub() chbComprador.FiltroCheckedChanged(cmbComprador))
   End Sub
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(Sub() chbUsuario.FiltroCheckedChanged(cmbUsuario))
   End Sub
#End Region
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbComprador.Checked And cmbComprador.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un VENDEDOR.")
            cmbComprador.Focus()
            Exit Sub
         End If
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
         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         If chbIdPedido.Checked AndAlso txtIdPedido.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me, "__FaltaNumeroPedidoProv"))
            txtIdPedido.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("¡¡¡ NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub



   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      e.Row.Cells("Cantidad").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("Cantidad").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("CantidadUMCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("CantidadUMCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("FactorConversionCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("FactorConversionCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      cmbEstados.SelectedIndex = 0

      chbFecha.Checked = False
      chbProveedor.Checked = False
      chbUsuario.Checked = False
      chbProducto.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      chbProducto.Checked = False
      chbIdPedido.Checked = False
      chbOrdenCompra.Checked = False

      If IdUsuario = "" Then
         chbComprador.Checked = False
      End If

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      cmbEstados.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim rPedidos = New Reglas.PedidosProveedores()
      Dim dtDetalle = rPedidos.GetPedidosDetalladoXEstados(actual.Sucursal.Id,
                                                           cmbEstados.Text,
                                                           dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                           dtpDesdeEntrega.Valor(chbFechaEntrega), dtpHastaEntrega.Valor(chbFechaEntrega),
                                                           txtIdPedido.ValorSeleccionado(chbIdPedido, -1I),
                                                           If(chbProducto.Checked, bscCodigoProducto2.Text.Trim(), String.Empty),
                                                           cmbMarca.ValorSeleccionado(chbMarca, 0I),
                                                           cmbRubro.ValorSeleccionado(chbRubro, 0I),
                                                           lote:=String.Empty,
                                                           If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L),
                                                           cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty),
                                                           cmbComprador.ValorSeleccionado(chbComprador, 0I),
                                                           txtOrdenCompra.ValorSeleccionado(chbOrdenCompra, 0L),
                                                           _tipoTipoComprobante,
                                                           cmbTiposComprobantes.GetTiposComprobantes())
      ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _tit)
      PreferenciasLeer(ugDetalle, tsbPreferencias)

      ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
      ugDetalle.DisplayLayout.Bands(0).Columns("CantidadUMCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
      ugDetalle.DisplayLayout.Bands(0).Columns("FactorConversionCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
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
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         'Dim Filtros As String = String.Empty
         .AppendFormat("Filtros: Estado: {0}", cmbEstados.Text)

         If chbFecha.Checked Then
            .AppendFormat(" - Fechas Pedido: Desde {0} Hasta {1}", dtpDesde.Value, dtpHasta.Value)
         End If
         If chbFechaEntrega.Checked Then
            .AppendFormat(" - Fechas Entrega: Desde {0} Hasta {1}", dtpDesdeEntrega.Value, dtpHastaEntrega.Value)
         End If
         .AppendFormat(" - ")
         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)
         If chbIdPedido.Checked Then
            .AppendFormat(" - Número {0}", txtIdPedido.Text)
         End If

         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         If chbComprador.Checked Then
            .AppendFormat(" - Comprador: {0}", cmbComprador.Text)
         End If
         If chbUsuario.Checked Then
            .AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         If chbOrdenCompra.Checked Then
            .AppendFormat(" - Orden de Compra: {0}", txtOrdenCompra.Text)
         End If

         If chbMarca.Checked Then
            .AppendFormat(" - Marca: {0}", cmbMarca.Text)
         End If
         If chbRubro.Checked Then
            .AppendFormat(" - Rubro: {0}", cmbRubro.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#Region "Metodos IConParametros"
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
#End Region
#End Region

End Class
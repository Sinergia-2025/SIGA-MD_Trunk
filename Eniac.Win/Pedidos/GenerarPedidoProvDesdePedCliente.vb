Public Class GenerarPedidoProvDesdePedCliente

#Region "Campos"
   Private _publicos As Publicos
   Private _dtDetalle As DataTable
   Private _tipoTipoComprobante As String

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         _publicos.CargaComboMarcas(cmbMarca)
         _publicos.CargaComboRubros(cmbRubro)
         _publicos.CargaComboSubRubros(cmbSubRubro)

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         _publicos.CargaComboEstadosPedidos(cmbEstados, True, True, True, True, False, _tipoTipoComprobante)
         cmbEstados.SelectedIndex = 1

         'Hay que colocarlo luego del CargarColumnasASumar porque sino da error.
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         RefrescarDatosGrilla()

         ugDetalle.AgregarFiltroEnLinea({Entidades.Producto.Columnas.NombreProducto.ToString(),
                                         Entidades.Producto.Columnas.Observacion.ToString(),
                                         Entidades.Proveedor.Columnas.NombreProveedor.ToString(),
                                         "ProveedoresAlternativos"})

         ugDetalle.AgregarTotalSumaColumna(ugDetalle.DisplayLayout.Bands(0).Columns("Estimativo"))
         'Ayudante.Grilla.AgregarTotalSumaColumna(Me.ugDetalle, Me.ugDetalle.DisplayLayout.Bands(0).Columns("Pedido"))
         ugDetalle.EnterMueveACeldaDeAbajo = True

         chbOrdenCompra.Enabled = Reglas.Publicos.PedidosGenPedProvOCObligatoria

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGenerarPedido.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Public Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProveedor.Checked And Not IsNumeric(bscCodigoProveedor.Tag) Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         If chbProducto.Checked And bscCodigoProducto2.Text.Length = 0 Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro")
            cmbMarca.Focus()
            Exit Sub
         End If

         If chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro")
            cmbRubro.Focus()
            Exit Sub
         End If

         If chbSubRubro.Checked And cmbSubRubro.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Subrubro aunque activó ese Filtro")
            cmbSubRubro.Focus()
            Exit Sub
         End If

         If Not chbOrdenCompra.Checked And Not chbProveedor.Checked And Reglas.Publicos.PedidosGenPedProvOCObligatoria Then
            ShowMessage("ATENCION: Debe seleccionar Orden de Compra o Proveedor.")
            cmbSubRubro.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            ugDetalle.Focus()
            ugDetalle.IrPrimerCeldaEditable()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
            Exit Sub
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#Region "Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbGenerarPedido_Click(sender As Object, e As EventArgs) Handles tsbGenerarPedido.Click
      TryCatched(Sub() GenerarPedido())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Filtros"
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra, String.Empty))
   End Sub
   Private Sub txtOrdenCompra_Leave(sender As Object, e As EventArgs) Handles txtOrdenCompra.Leave
      TryCatched(
      Sub()
         Dim ordenCompra = txtOrdenCompra.ValorNumericoPorDefecto(0L)
         If ordenCompra <> 0 Then
            Dim OC = New Reglas.OrdenesCompra().GetUno(actual.Sucursal.Id, ordenCompra, True)
            Dim Prov = New Reglas.Proveedores().GetUno(OC.IdProveedor)
            bscCodigoProveedor.Text = Prov.CodigoProveedor.ToString()
            chbProveedor.Checked = True
            bscCodigoProveedor.PresionarBoton()
         End If
      End Sub)
   End Sub
#Region "Buscador de Proveedores"
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
   Private Sub llbProveedor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbProveedor.LinkClicked
      TryCatched(
      Sub()
         If bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono Then
            Dim prov = New Reglas.Proveedores().GetUnoPorCodigo(Long.Parse(bscCodigoProveedor.Text), incluirFoto:=True)
            prov.Usuario = actual.Nombre

            Dim PantProv = New ProveedoresDetalle(prov) With {
               .StateForm = StateForm.Actualizar,
               .CierraAutomaticamente = True
            }
            PantProv.ShowDialog()
         End If
      End Sub)
   End Sub
#End Region
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Buscador de Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
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

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(Sub() chbMarca.FiltroCheckedChanged(cmbMarca))
   End Sub
   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      TryCatched(Sub() chbRubro.FiltroCheckedChanged(cmbRubro))
   End Sub
   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      TryCatched(Sub() chbSubRubro.FiltroCheckedChanged(cmbSubRubro))
   End Sub
#End Region

   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      TryCatched(
      Sub()
         If e.Cell.Row.ListObject IsNot Nothing AndAlso e.Cell.Column.Key = "Pedido" Then
            Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row
            dr("Estimativo") = Decimal.Parse(dr("Pedido").ToString()) * Decimal.Parse(dr("PrecioCosto").ToString())
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim stock As Decimal = Decimal.Parse(dr("Stock").ToString())
            'Dim stockMinimo As Decimal = Decimal.Parse(dr("StockMinimo").ToString())
            'Dim stockMaximo As Decimal = Decimal.Parse(dr("StockMaximo").ToString())
            ' Dim puntoDePedido As Decimal = Decimal.Parse(dr("PuntoDePedido").ToString())
            If stock < 0 Then stock = stock
            If Decimal.Parse(e.Row.Cells("Pedido").Value.ToString()) <> 0 Then
               e.Row.Cells("Pedido").Appearance.BackColor = Color.Cyan
               e.Row.Cells("Pedido").Appearance.ForeColor = Color.Black
               e.Row.Cells("Pedido").ActiveAppearance.BackColor = Color.Cyan
               e.Row.Cells("Pedido").ActiveAppearance.ForeColor = Color.Black
            Else
               e.Row.Cells("Pedido").Appearance.BackColor = Nothing
               e.Row.Cells("Pedido").Appearance.ForeColor = Nothing
               e.Row.Cells("Pedido").ActiveAppearance.BackColor = Nothing
               e.Row.Cells("Pedido").ActiveAppearance.ForeColor = Nothing
            End If

            'If stock < stockMinimo Then
            '   e.Row.Cells("Stock").Appearance.BackColor = Color.LightCoral
            '   e.Row.Cells("Stock").ActiveAppearance.BackColor = Color.LightCoral
            'ElseIf stock < puntoDePedido Then
            '   e.Row.Cells("Stock").Appearance.BackColor = Color.Yellow
            '   e.Row.Cells("Stock").ActiveAppearance.BackColor = Color.Yellow
            '   e.Row.Cells("Stock").Appearance.ForeColor = Color.Black
            '   e.Row.Cells("Stock").ActiveAppearance.ForeColor = Color.Black
            'Else
            '   e.Row.Cells("Stock").Appearance.BackColor = Nothing
            '   e.Row.Cells("Stock").ActiveAppearance.BackColor = Nothing
            '   e.Row.Cells("Stock").Appearance.ForeColor = Nothing
            '   e.Row.Cells("Stock").ActiveAppearance.ForeColor = Nothing
            'End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarProducto(dr As DataGridViewRow)
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

   Private Sub RefrescarDatosGrilla()
      chbProducto.Checked = False
      chbProveedor.Checked = False
      chbFecha.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      cmbEstados.SelectedIndex = 1
      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idProducto = If(bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono, bscCodigoProducto2.Text, String.Empty)
      Dim idMarca = cmbMarca.ValorSeleccionado(chbMarca, 0I)
      Dim idRubro = cmbRubro.ValorSeleccionado(chbRubro, 0I)
      Dim idSubRubro = cmbSubRubro.ValorSeleccionado(chbSubRubro, 0I)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)

      Dim ordenCompra As Long = 0
      If chbOrdenCompra.Checked Then
         ordenCompra = txtOrdenCompra.ValorNumericoPorDefecto(0L)
         Dim OC = New Reglas.OrdenesCompra().GetUno(actual.Sucursal.Id, ordenCompra, True)
         Dim Prov = New Reglas.Proveedores().GetUno(OC.IdProveedor)
         bscCodigoProveedor.Text = Prov.CodigoProveedor.ToString()
         chbProveedor.Checked = True
         bscCodigoProveedor.PresionarBoton()
      End If

      Dim oPedidos = New Reglas.Pedidos()
      _dtDetalle = oPedidos.GetPedidosParaGenerarPedidoProv(actual.Sucursal.Id, idProveedor,
                                                            idMarca, idRubro, idSubRubro,
                                                            idProducto, ordenCompra,
                                                            Reglas.Publicos.PedidosGenPedProvOCObligatoria,
                                                            dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                            cmbEstados.Text)

      _dtDetalle.Columns.Add("PedidoOriginal", GetType(Decimal))
      _dtDetalle.Columns.Add("Pedido", GetType(Decimal))

      Dim generarPedidosStockSeleccionaTrue = Reglas.Publicos.GenerarPedidosStockSeleccionaTrue
      For Each drDetalle As DataRow In _dtDetalle.Rows
         Dim pedido As Decimal = 0
         If Not IsDBNull(drDetalle("Cantidad")) Then pedido = Decimal.Parse(drDetalle("Cantidad").ToString())
         drDetalle("PedidoOriginal") = pedido
         drDetalle("Pedido") = 0
         If generarPedidosStockSeleccionaTrue AndAlso pedido <> 0 Then
            Dim stock As Decimal = Decimal.Parse(drDetalle("Stock").ToString())
            drDetalle("Pedido") = pedido
            drDetalle("Estimativo") = pedido * Decimal.Parse(drDetalle("PrecioCosto").ToString())
            'End If
         End If
      Next
      ugDetalle.DataSource = _dtDetalle
   End Sub


   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         If chbProveedor.Checked Then
            .AppendFormat("Proveedor: {0} - {1} - ", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If chbProducto.Checked Then
            .AppendFormat("Producto: {0} - {1} - ", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If chbMarca.Checked Then
            .AppendFormat("Marca: {0} - ", cmbMarca.Text)
         End If
         If chbRubro.Checked Then
            .AppendFormat("Rubro: {0} - ", cmbRubro.Text)
         End If
         If chbSubRubro.Checked Then
            .AppendFormat("Subrubro: {0} - ", cmbSubRubro.Text)
         End If
      End With
      Return filtro.ToString().Trim().Trim("-"c).Trim()
   End Function

   Private Sub GenerarPedido()
      ugDetalle.UpdateData()
      If _dtDetalle.Select(String.Format("{0} <> 0", "Pedido")).Length = 0 Then
         ShowMessage("No ha seleccionado ningún producto para crear un pedido. Por favor verifique.")
         Exit Sub
      End If

      Dim codigoProveedor As Long? = Nothing
      If chbProveedor.Checked AndAlso IsNumeric(bscCodigoProveedor.Text) AndAlso Long.Parse(bscCodigoProveedor.Text) > 0 Then
         codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(0L)
      End If

      Dim OC As Entidades.OrdenCompra = Nothing
      If chbOrdenCompra.Checked Then
         If txtOrdenCompra.ValorNumericoPorDefecto(0L) <> 0 Then
            OC = New Reglas.OrdenesCompra().GetUno(actual.Sucursal.Id, txtOrdenCompra.ValorNumericoPorDefecto(0L), False)
         End If
      End If

      Dim frmPedido As PedidosProveedores = New PedidosProveedores()
      frmPedido.MdiParent = MdiParent
      frmPedido.Show()
      'si tiene una orden de compra se la seteo a la pantalla de Pedido
      If OC IsNot Nothing AndAlso OC.IdFormasPago <> 0 Then
         frmPedido.cmbFormaPago.SelectedValue = OC.IdFormasPago
         frmPedido.NumeroOrdenCompra = OC.NumeroOrdenCompra
      End If

      frmPedido.CreaDesdeStock(codigoProveedor, _dtDetalle)
   End Sub

#End Region

End Class
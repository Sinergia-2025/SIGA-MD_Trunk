Public Class ProcesoDeclaracionProduccion
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            '-- Setea Fechas.- --
            dtpDesde.Value = Date.Today
            dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
            '-- Carga Tipos de comprobantes.- 
            _publicos.CargaComboTiposComprobantes(cmbTipoComprobanteOP, MiraPC:=False, "PRODUCCION")
            _publicos.CargaComboTiposComprobantes(cmbTipoComprobantePedido, MiraPC:=False, "PEDIDOSCLIE")
            '-- Inicializa Campos de Busqueda.- --
            RefrescarDatos()
            FormateaGrilla()
            PreferenciasLeer(ugDetalle, tsbPreferencias)

         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbInformar.PerformClick()
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
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub tsbInformar_Click(sender As Object, e As EventArgs) Handles tsbInformar.Click
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una Orden para poder continuar")
         End If
         Using oFrmCN = New ProcesoDeclaracionProduccionDetalle(dr)
            oFrmCN.IdFuncion = IdFuncion
            oFrmCN.ShowDialog()
         End Using
         btnConsultar.PerformClick()
      End Sub)
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

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(bscCodigoProducto, bscNombreProducto))
   End Sub
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", True)
      End Sub)
   End Sub
   Private Sub bscNombreProducto_BuscadorClick() Handles bscNombreProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProducto)
         bscNombreProducto.Datos = New Reglas.Productos().GetPorNombre(bscNombreProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", True)
      End Sub)
   End Sub
   Private Sub Producto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreProducto.BuscadorSeleccion, bscCodigoProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscNombreCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscNombreCliente)
         bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbOrdenProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenProduccion.CheckedChanged
      TryCatched(
      Sub()
         txtIdOrdenProduccion.Enabled = chbOrdenProduccion.Checked
         cmbTipoComprobanteOP.Enabled = chbOrdenProduccion.Checked

         If Not chbOrdenProduccion.Checked Then
            txtIdOrdenProduccion.Text = String.Empty
            cmbTipoComprobanteOP.SelectedIndex = -1
         Else
            txtIdOrdenProduccion.Focus()
            cmbTipoComprobanteOP.SelectedIndex = 0
         End If
      End Sub)
   End Sub
   ''''Private Sub ugDetalle_AfterCellActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterCellActivate
   ''''   '-- Activa Boton de Informar.-
   ''''   TryCatched(Sub() tsbInformar.Enabled = ugDetalle.DataSource(Of DataTable).Any())
   ''''End Sub
   Private Sub chbPedidoVta_CheckedChanged(sender As Object, e As EventArgs) Handles chbPedidoVta.CheckedChanged
      TryCatched(
      Sub()
         chbPedidoVta.FiltroCheckedChanged(cmbTipoComprobantePedido)
         chbPedidoVta.FiltroCheckedChanged(txtLineaPedido, "0")
         chbPedidoVta.FiltroCheckedChanged(txtNroPedido, "0")
         'txtNroPedido.Enabled = chbPedidoVta.Checked
         'txtLineaPedido.Enabled = chbPedidoVta.Checked
         'cmbTipoComprobantePedido.Enabled = chbPedidoVta.Checked
         'If chbPedidoVta.Checked Then
         '   cmbTipoComprobantePedido.SelectedIndex = 0
         'Else
         '   cmbTipoComprobantePedido.SelectedIndex = -1
         '   txtNroPedido.Text = String.Empty
         '   txtLineaPedido.Text = String.Empty
         'End If
         'txtNroPedido.Focus()
      End Sub)
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscNombreProducto.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto.Focus()
            Exit Sub
         End If

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscNombreCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbOrdenProduccion.Checked AndAlso txtIdOrdenProduccion.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Número de Orden de Produccion aunque activó ese Filtro.")
            txtIdOrdenProduccion.Focus()
            Exit Sub
         End If

         If chbPedidoVta.Checked Then
            If txtNroPedido.ValorNumericoPorDefecto(0I) = 0 Then
               ShowMessage("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.")
               txtNroPedido.Focus()
               Exit Sub
            End If
            If txtLineaPedido.ValorNumericoPorDefecto(0I) = 0 Then
               ShowMessage("ATENCION: NO Ingresó una Línea de Pedido aunque activó ese Filtro.")
               txtLineaPedido.Focus()
               Exit Sub
            End If
            If cmbTipoComprobantePedido.SelectedIndex < 0 Then
               ShowMessage("ATENCION: NO Ingresó una Tipo de Comprobante de Pedido aunque activó ese Filtro.")
               cmbTipoComprobantePedido.Focus()
               Exit Sub
            End If
         End If

         CargaGrillaDetalle()
         FormateaGrilla()
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         If ugDetalle.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatos()
      '-- DesActiva Boton de Informar.-
      tsbInformar.Enabled = False
      '-- Inicializa Fechas.- --
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbFecha.Checked = False
      chkMesCompleto.Enabled = False
      '-- Inicializa Productos.-
      chbProducto.Checked = False
      bscCodigoProducto.Enabled = False
      bscNombreProducto.Enabled = False
      '-- Inicializa Clientes.- --
      chbCliente.Checked = False
      bscCodigoCliente.Enabled = False
      bscNombreCliente.Enabled = False
      '-- Inicializa Orden de Produccion.- --
      chbOrdenProduccion.Checked = False

      chbPedidoVta.Checked = False

      '-- Limpio la Grilla.-
      ugDetalle.ClearFilas()

      tsbInformar.Enabled = ugDetalle.DataSource(Of DataTable).Any()
   End Sub
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      End If
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim fechaDesde = dtpDesde.Valor(chbFecha)
      Dim fechaHasta = dtpHasta.Valor(chbFecha)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty)
      Dim numeroOrdenProduccion = If(chbOrdenProduccion.Checked, txtIdOrdenProduccion.ValorNumericoPorDefecto(0I), -0I)
      Dim idTipocomprobanteOP = If(chbOrdenProduccion.Checked, cmbTipoComprobanteOP.SelectedValue.ToString(), String.Empty)

      Dim idPedido = If(chbPedidoVta.Checked, txtNroPedido.ValorNumericoPorDefecto(0I), 0I)
      Dim linea = If(chbPedidoVta.Checked, txtLineaPedido.ValorNumericoPorDefecto(0I), 0I)

      Dim rOP = New Reglas.OrdenesProduccion()
      Dim dtDetalle = rOP.GetOrdenesProduccionDeclaracion(actual.Sucursal.IdSucursal, fechaDesde, fechaHasta, numeroOrdenProduccion,
                                                          idProducto, idCliente, idTipocomprobanteOP, idPedido, linea)

      ugDetalle.DataSource = dtDetalle
      tsbInformar.Enabled = ugDetalle.DataSource(Of DataTable).Any()
   End Sub
   Private Sub FormateaGrilla()
      Dim pos = 0I
      With ugDetalle.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 150, HAlign.Left)

         .Columns("Letra").FormatearColumna("L", pos, 50, HAlign.Left)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 50, HAlign.Right)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Numero", pos, 60, HAlign.Right)
         .Columns("FechaOrdenProduccion").FormatearColumna("Fecha", pos, 80, HAlign.Center, , Formatos.Format.FechaSinHora)
         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 150)

         .Columns("IdProducto").FormatearColumna("Codigo", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 190)

         .Columns("CantidadPedida").FormatearColumna("Cant. Pedida", pos, 100, HAlign.Right,, "N2")
         .Columns("CantidadPendiente").FormatearColumna("Cant. Pendiente", pos, 100, HAlign.Right,, "N2")

         .Columns("NumeroPedido").FormatearColumna("Pedido Vta", pos, 70, HAlign.Right)
         .Columns("OrdenPedido").FormatearColumna("Linea Vta", pos, 70, HAlign.Right)

         .Columns("DescripcionProceso").FormatearColumna("Descripcion Proceso", pos, 180, HAlign.Left)
      End With
      ugDetalle.AgregarFiltroEnLinea({"NombreProducto"})

   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         If chbFecha.Checked Then
            .AppendFormat("Fecha: Desde {0} Hasta {1} - ", dtpDesde.Text, dtpHasta.Text)
         End If
         If chbOrdenProduccion.Checked Then
            .AppendFormat("Número: {0} - ", txtIdOrdenProduccion.Text)
         End If
         If chbProducto.Checked Then
            .AppendFormat("Producto: {0} - {1} - ", bscCodigoProducto.Text, bscNombreProducto.Text)
         End If
         .AppendFormat("Tipo Comprobante: {0} - ", cmbTipoComprobanteOP.Text)
         If chbCliente.Checked Then
            .AppendFormat("Cliente: {0} - {1} - ", bscCodigoCliente.Text, bscNombreCliente.Text)
         End If
         If chbPedidoVta.Checked Then
            .AppendFormat("Pedido Vta.: {0} - ", txtNroPedido.Text)
            .AppendFormat("Orden: {0} - ", txtLineaPedido.Text)
            .AppendFormat("Comprobante: {0} - ", cmbTipoComprobantePedido.Text)
         End If
      End With
      Return filtro.ToString().Trim().Trim("-"c)
   End Function

#End Region

End Class
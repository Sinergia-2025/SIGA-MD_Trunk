Public Class InfNovedadesProduccionMRPProductos
#Region "Campos"
   Private _publicos As Publicos
   Private _prevNumeroDesde As Long
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         '-- Carga Tipos de comprobantes.- 
         _publicos.CargaComboTiposComprobantes(cmbTipoComprobante, MiraPC:=False, Entidades.TipoComprobante.Tipos.PRODUCCION.ToString())
         _publicos.CargaComboTiposComprobantes(cmbTipoComprobantePedido, MiraPC:=False, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())
         _publicos.CargaComboLetrasFiscales(cmbLetraFiscal, Entidades.TipoComprobante.Tipos.PRODUCCION)
         _publicos.CargaComboCentrosEmisores(cmbCentroEmisor, Entidades.TipoComprobante.Tipos.PRODUCCION)

         _publicos.CargaComboLetrasFiscales(cmbLetraFiscalPedido, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE)
         _publicos.CargaComboCentrosEmisores(cmbCentroEmisorPedido, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE)

         _publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)

         _publicos.CargaComboDesdeEnum(cmbEsNecesario, Entidades.Publicos.NecesarioResultanteTodos.TODOS)
         _publicos.CargaComboDesdeEnum(cmbEsAgregado, Entidades.Publicos.SiNoTodos.TODOS)

         '-- Inicializa Campos de Busqueda.- --
         RefrescarDatos()

         ugDetalle.AgregarFiltroEnLinea({"NombreProductoDeclarado", "NombreProducto", "DescripcionProceso", "NombreCliente"})
         ugDetalle.AgregarTotalesSuma({"Cantidad", "CantidadUtilizada", "CantidadProducida"})

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
      TryCatched(Sub() RefrescarDatos())
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
   Private Sub chbResponsable_CheckedChanged(sender As Object, e As EventArgs) Handles chbResponsable.CheckedChanged
      TryCatched(Sub() chbResponsable.FiltroCheckedChanged(cmbResponsable))
   End Sub
   Private Sub chbCodigoOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbCodigoOperacion.CheckedChanged
      TryCatched(Sub() chbCodigoOperacion.FiltroCheckedChanged(bscNombreTareas))
   End Sub
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
#Region "Eventos Buscador Productos"
   Private Sub chbProductoDeclarado_CheckedChanged(sender As Object, e As EventArgs) Handles chbProductoDeclarado.CheckedChanged
      TryCatched(Sub() chbProductoDeclarado.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProductoDeclarado, bscNombreProductoDeclarado))
   End Sub
   Private Sub bscCodigoProductoDeclarado_BuscadorClick() Handles bscCodigoProductoDeclarado.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProductoDeclarado)
         bscCodigoProductoDeclarado.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProductoDeclarado.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", True)
      End Sub)
   End Sub
   Private Sub bscNombreProductoDeclarado_BuscadorClick() Handles bscNombreProductoDeclarado.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProductoDeclarado)
         bscNombreProductoDeclarado.Datos = New Reglas.Productos().GetPorNombre(bscNombreProductoDeclarado.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", True)
      End Sub)
   End Sub
   Private Sub ProductoDeclarado_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoDeclarado.BuscadorSeleccion, bscNombreProductoDeclarado.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProductoDeclarado(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      TryCatched(Sub() chbTipoComprobante.FiltroCheckedChanged(cmbTipoComprobante))
   End Sub
   Private Sub chbLetraFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetraFiscal.CheckedChanged
      TryCatched(Sub() chbLetraFiscal.FiltroCheckedChanged(cmbLetraFiscal))
   End Sub
   Private Sub chbCentroEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroEmisor.CheckedChanged
      TryCatched(Sub() chbCentroEmisor.FiltroCheckedChanged(cmbCentroEmisor))
   End Sub
   Private Sub chbOrdenProduccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenProduccion.CheckedChanged
      TryCatched(Sub() chbOrdenProduccion.FiltroCheckedChanged(txtNumeroHasta, "0"))
      TryCatched(Sub() chbOrdenProduccion.FiltroCheckedChanged(txtNumeroDesde, "0"))
   End Sub
   Private Sub txtNumeroDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroDesde.Enter
      TryCatched(Sub() _prevNumeroDesde = txtNumeroDesde.ValorNumericoPorDefecto(0L))
   End Sub
   Private Sub txtNumeroDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroDesde.Leave
      TryCatched(Sub() txtNumeroHasta.SetValor(txtNumeroHasta.ValorNumericoPorDefecto(0L) + txtNumeroDesde.ValorNumericoPorDefecto(0L) - _prevNumeroDesde))
   End Sub
   Private Sub chbPlanMaestroNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbPlanMaestroNumero.CheckedChanged
      TryCatched(Sub() chbPlanMaestroNumero.FiltroCheckedChanged(txtPlanMaestroNumero, "0"))
   End Sub

#Region "Eventos Buscador Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscNombreProducto))
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
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscNombreCliente))
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

#Region "Eventos Buscador Proceso Productivo"
   Private Sub chbProcesoProductivo_CheckedChanged(sender As Object, e As EventArgs) Handles chbProcesoProductivo.CheckedChanged
      TryCatched(Sub() chbProcesoProductivo.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProcesoProductivo, bscDescripcionProcesoProductivo))
   End Sub
   Private Sub bscCodigoProcesoProductivo_BuscadorClick() Handles bscCodigoProcesoProductivo.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPProcesosProductivos(bscCodigoProcesoProductivo)
         bscCodigoProcesoProductivo.Datos = New Reglas.MRPProcesosProductivos().GetPorCodigo(bscCodigoProcesoProductivo.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscDescripcionProcesoProductivo_BuscadorClick() Handles bscDescripcionProcesoProductivo.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPProcesosProductivos(bscDescripcionProcesoProductivo)
         bscDescripcionProcesoProductivo.Datos = New Reglas.MRPProcesosProductivos().GetPorDescripcion(bscDescripcionProcesoProductivo.Text.Trim())
      End Sub)
   End Sub
   Private Sub ProcesoProductivo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDescripcionProcesoProductivo.BuscadorSeleccion, bscCodigoProcesoProductivo.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProcesoProductivo(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Tareas"
   Private Sub bscNombreTareas_BuscadorClick() Handles bscNombreTareas.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMRPTareas(bscNombreTareas)
            bscNombreTareas.Datos = New Reglas.MRPTareas().GetFiltradoPorNombre(bscNombreTareas.Text.Trim(), Entidades.Publicos.SiNoTodos.SI)
         End Sub)
   End Sub
   Private Sub bscNombreTareas_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTareas.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosTareas(e.FilaDevuelta)
               bscNombreTareas.Select()
            End If
         End Sub)
   End Sub
#End Region
   Private Sub chbTipoComprobantePedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobantePedido.CheckedChanged
      TryCatched(Sub() chbTipoComprobantePedido.FiltroCheckedChanged(cmbTipoComprobantePedido))
   End Sub
   Private Sub chbLetraFiscalPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetraFiscalPedido.CheckedChanged
      TryCatched(Sub() chbLetraFiscalPedido.FiltroCheckedChanged(cmbLetraFiscalPedido))
   End Sub
   Private Sub chbCentroEmisorPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbCentroEmisorPedido.CheckedChanged
      TryCatched(Sub() chbCentroEmisorPedido.FiltroCheckedChanged(cmbCentroEmisorPedido))
   End Sub
   Private Sub chbNumeroPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroPedido.CheckedChanged
      TryCatched(Sub() chbNumeroPedido.FiltroCheckedChanged(txtNumeroPedidoHasta, "0"))
      TryCatched(Sub() chbNumeroPedido.FiltroCheckedChanged(txtNumeroPedidoDesde, "0"))
   End Sub
   Private Sub txtNumeroPedidoDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroPedidoDesde.Enter
      TryCatched(Sub() _prevNumeroDesde = txtNumeroPedidoDesde.ValorNumericoPorDefecto(0L))
   End Sub
   Private Sub txtNumeroPedidoDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroPedidoDesde.Leave
      TryCatched(Sub() txtNumeroPedidoHasta.SetValor(txtNumeroPedidoHasta.ValorNumericoPorDefecto(0L) + txtNumeroPedidoDesde.ValorNumericoPorDefecto(0L) - _prevNumeroDesde))
   End Sub
   Private Sub chbLineaPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbLineaPedido.CheckedChanged
      TryCatched(Sub() chbLineaPedido.FiltroCheckedChanged(txtLineaPedido, "0"))
   End Sub
#End Region

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If dr.Field(Of Boolean)("EsProductoNecesario") Then
               e.Row.Cells("DescripcionEsProductoNecesario").Color(foreColor:=Color.Black, backColor:=Color.CadetBlue)
            Else
               e.Row.Cells("DescripcionEsProductoNecesario").Color(foreColor:=Color.Black, backColor:=Color.DarkOrange)
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If dr.Field(Of Integer?)("Lotes").IfNull() > 0 Then
               Dim rLotes = New Reglas.NovedadesProduccionMRPProductosLotes()
               Using dt = rLotes.GetAll(dr.Field(Of Integer)(Entidades.NovedadProduccionMRPProductoLote.Columnas.NumeroNovedadesProducccion.ToString()),
                                        dr.Field(Of String)(Entidades.NovedadProduccionMRPProductoLote.Columnas.CodigoOperacion.ToString()),
                                        dr.Field(Of String)("IdProductoDeclarado"))
                  Dim dcRemove = dt.Columns.OfType(Of DataColumn).Where(Function(dc) dc.ColumnName <> Entidades.NovedadProduccionMRPProductoLote.Columnas.IdLote.ToString()).ToList().ConvertAll(Function(dc) dc.ColumnName)
                  For Each dcR In dcRemove
                     dt.Columns.Remove(dcR)
                  Next
                  dt.Columns(Entidades.NovedadProduccionMRPProductoLote.Columnas.IdLote.ToString()).Caption = "Lote"
                  Using frm = New ConsultaGenerica(dt)
                     frm.Text = "Lotes"
                     frm.Width = 300
                     frm.ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
                     frm.ShowDialog()
                  End Using
               End Using
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If ValidaConErrorBuilder(AddressOf ValidaCargaGrillaDetalle) Then
            CargaGrillaDetalle()
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            If ugDetalle.Rows.Count = 0 Then
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatos()
      chbResponsable.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbFecha.Checked = False
      chkMesCompleto.Enabled = False

      cmbEsNecesario.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbEsAgregado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      chbTipoComprobante.Checked = False
      chbLetraFiscal.Checked = False
      chbCentroEmisor.Checked = False
      chbOrdenProduccion.Checked = False

      chbProducto.Checked = False
      chbCliente.Checked = False
      chbProcesoProductivo.Checked = False

      chbTipoComprobantePedido.Checked = False
      chbLetraFiscalPedido.Checked = False
      chbCentroEmisorPedido.Checked = False
      chbNumeroPedido.Checked = False
      chbLineaPedido.Checked = False
      chbCodigoOperacion.Checked = False
      '-- Limpio la Grilla.-
      ugDetalle.ClearFilas()
   End Sub
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosProductoDeclarado(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProductoDeclarado.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProductoDeclarado.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProductoDeclarado.Permitido = False
         bscCodigoProductoDeclarado.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscNombreCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosProcesoProductivo(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoProcesoProductivo.Text = dr.Cells(Entidades.MRPProcesoProductivo.Columnas.CodigoProcesoProductivo.ToString()).Value.ToString.Trim()
         bscCodigoProcesoProductivo.Tag = dr.Cells(Entidades.MRPProcesoProductivo.Columnas.IdProcesoProductivo.ToString()).Value.ToString.Trim()
         bscDescripcionProcesoProductivo.Text = dr.Cells(Entidades.MRPProcesoProductivo.Columnas.DescripcionProceso.ToString()).Value.ToString()
         bscNombreProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub ValidaCargaGrillaDetalle(err As Entidades.ErrorBuilder)
      If chbResponsable.Checked AndAlso cmbResponsable.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Responsable aunque activó ese Filtro.", cmbResponsable)
      End If
      If chbCodigoOperacion.Checked AndAlso String.IsNullOrWhiteSpace(bscNombreTareas.Text) Then
         err.AddError("ATENCION: NO seleccionó una Tarea aunque activó ese Filtro.", bscNombreTareas)
      End If
      If chbTipoComprobante.Checked AndAlso cmbTipoComprobante.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Tipo de Comprobante aunque activó ese Filtro.", cmbTipoComprobante)
      End If
      If chbLetraFiscal.Checked AndAlso cmbLetraFiscal.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó una Letra aunque activó ese Filtro.", cmbLetraFiscal)
      End If
      If chbCentroEmisor.Checked AndAlso cmbCentroEmisor.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Centro Emisor aunque activó ese Filtro.", cmbCentroEmisor)
      End If
      If chbOrdenProduccion.Checked AndAlso txtNumeroDesde.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número Desde aunque activó ese Filtro.", txtNumeroDesde)
      End If
      If chbOrdenProduccion.Checked AndAlso txtNumeroHasta.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número Hasta aunque activó ese Filtro.", txtNumeroHasta)
      End If
      If chbPlanMaestroNumero.Checked AndAlso txtPlanMaestroNumero.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Plan Maestro aunque activó ese Filtro.", txtPlanMaestroNumero)
      End If
      If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscNombreProducto.Selecciono Then
         err.AddError("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", bscCodigoProducto)
      End If
      If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscNombreCliente.Selecciono Then
         err.AddError("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", bscCodigoCliente)
      End If
      If chbProcesoProductivo.Checked And Not bscCodigoProcesoProductivo.Selecciono And Not bscDescripcionProcesoProductivo.Selecciono Then
         err.AddError("ATENCION: NO seleccionó un Proceso Productivo aunque activó ese Filtro.", bscCodigoProcesoProductivo)
      End If
      If chbTipoComprobantePedido.Checked AndAlso cmbTipoComprobantePedido.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Tipo de Comprobante de Pedido aunque activó ese Filtro.", cmbTipoComprobantePedido)
      End If
      If chbLetraFiscalPedido.Checked AndAlso cmbLetraFiscalPedido.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó una Letra de Pedido aunque activó ese Filtro.", cmbLetraFiscalPedido)
      End If
      If chbCentroEmisorPedido.Checked AndAlso cmbCentroEmisorPedido.SelectedIndex < 0 Then
         err.AddError("ATENCION: NO seleccionó un Centro Emisor de Pedido aunque activó ese Filtro.", cmbCentroEmisorPedido)
      End If
      If chbNumeroPedido.Checked AndAlso txtNumeroPedidoDesde.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número de Pedido Desde aunque activó ese Filtro.", txtNumeroPedidoDesde)
      End If
      If chbNumeroPedido.Checked AndAlso txtNumeroPedidoHasta.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó un Número de Pedido Hasta aunque activó ese Filtro.", txtNumeroPedidoHasta)
      End If
      If chbLineaPedido.Checked AndAlso txtLineaPedido.ValorNumericoPorDefecto(0L) = 0 Then
         err.AddError("ATENCION: NO seleccionó una Línea de Pedido aunque activó ese Filtro.", txtLineaPedido)
      End If
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim idResponsable = cmbResponsable.ValorSeleccionado(chbResponsable, 0I)
      Dim idTarea = If(chbCodigoOperacion.Checked, Integer.Parse(bscNombreTareas.Tag.ToString()), 0I)
      Dim fechaDesde = dtpDesde.Valor(chbFecha)
      Dim fechaHasta = dtpHasta.Valor(chbFecha)

      Dim idProductoDeclarado = If(chbProductoDeclarado.Checked, bscCodigoProductoDeclarado.Text, String.Empty)
      Dim esNecesario = cmbEsNecesario.ValorSeleccionado(Entidades.Publicos.NecesarioResultanteTodos.TODOS)
      Dim esAgregado = cmbEsAgregado.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS)

      Dim idTipocomprobante = cmbTipoComprobante.ValorSeleccionado(chbTipoComprobante, String.Empty)
      Dim letraFiscal = cmbLetraFiscal.ValorSeleccionado(chbLetraFiscal, String.Empty)
      Dim centroEmisor = cmbCentroEmisor.ValorSeleccionado(chbCentroEmisor, 0I)
      Dim numeroDesde = txtNumeroDesde.ValorSeleccionado(chbOrdenProduccion, 0L)
      Dim numeroHasta = txtNumeroHasta.ValorSeleccionado(chbOrdenProduccion, 0L)
      Dim planMaestroNumero = txtPlanMaestroNumero.ValorSeleccionado(chbPlanMaestroNumero, 0I)

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProcesoProductivo = If(chbProcesoProductivo.Checked, Long.Parse(bscCodigoProcesoProductivo.Tag.ToString()), 0L)

      Dim idTipocomprobantePedido = cmbTipoComprobantePedido.ValorSeleccionado(chbTipoComprobantePedido, String.Empty)
      Dim letraFiscalPedido = cmbLetraFiscalPedido.ValorSeleccionado(chbLetraFiscalPedido, String.Empty)
      Dim centroEmisorPedido = cmbCentroEmisorPedido.ValorSeleccionado(chbCentroEmisorPedido, 0I)
      Dim numeroPedidoDesde = txtNumeroPedidoDesde.ValorSeleccionado(chbNumeroPedido, 0L)
      Dim numeroPedidoHasta = txtNumeroPedidoHasta.ValorSeleccionado(chbNumeroPedido, 0L)
      Dim lineaPedido = txtLineaPedido.ValorSeleccionado(chbNumeroPedido, 0I)

      Dim rOP = New Reglas.NovedadesProduccionMRPProductos()
      Dim dtDetalle = rOP.GetInformeDeclaraciones(idResponsable, idTarea, fechaDesde, fechaHasta,
                                                  idProductoDeclarado, esNecesario, esAgregado,
                                                  idTipocomprobante, letraFiscal, centroEmisor, numeroDesde, numeroHasta,
                                                  idProducto, idCliente, idProcesoProductivo,
                                                  idTipocomprobantePedido, letraFiscalPedido, centroEmisorPedido, numeroPedidoDesde, numeroPedidoHasta, lineaPedido,
                                                  planMaestroNumero)

      ugDetalle.DataSource = dtDetalle
   End Sub

   Private Function AgregarFiltro(stb As StringBuilder, label As CheckBox, value As Control) As StringBuilder
      Return AgregarFiltro(stb, label.Text, label.Checked, Function() value.Text)
   End Function
   Private Function AgregarFiltro(stb As StringBuilder, label As CheckBox, value As Func(Of String)) As StringBuilder
      Return AgregarFiltro(stb, label.Text, label.Checked, value)
   End Function
   Private Function AgregarFiltro(stb As StringBuilder, labelText As String, agregar As Boolean, value As Func(Of String)) As StringBuilder
      Return AgregarFiltro(stb, agregar, Function() String.Format("{0}: {1} - ", labelText, value.Invoke()))
   End Function
   Private Function AgregarFiltro(stb As StringBuilder, agregar As Boolean, mensaje As Func(Of String)) As StringBuilder
      If agregar Then
         stb.AppendFormat(mensaje.Invoke())
      End If
      Return stb
   End Function
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         AgregarFiltro(filtro, chbResponsable, cmbResponsable)
         AgregarFiltro(filtro, chbFecha, Function() String.Format("{0}: {1} Hasta {2} - ", chbFecha.Text, dtpDesde.Text, dtpHasta.Text))
         AgregarFiltro(filtro, lblEsNecesario.Text, cmbEsNecesario.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS) <> Entidades.Publicos.SiNoTodos.TODOS, Function() cmbEsNecesario.Text)
         AgregarFiltro(filtro, lblEsAgregado.Text, cmbEsNecesario.ValorSeleccionado(Entidades.Publicos.SiNoTodos.TODOS) <> Entidades.Publicos.SiNoTodos.TODOS, Function() cmbEsAgregado.Text)
         AgregarFiltro(filtro, chbTipoComprobante, cmbTipoComprobante)
         AgregarFiltro(filtro, chbLetraFiscal, cmbLetraFiscal)
         AgregarFiltro(filtro, chbCentroEmisor, cmbCentroEmisor)
         AgregarFiltro(filtro, chbOrdenProduccion, Function() String.Format("{0}: {1} Hasta {2} - ", chbOrdenProduccion.Text, txtNumeroDesde.Text, txtNumeroHasta.Text))
         AgregarFiltro(filtro, chbPlanMaestroNumero, txtPlanMaestroNumero)

         AgregarFiltro(filtro, chbProducto, Function() String.Format("{0}: {1} - {2} - ", chbProducto.Text, bscCodigoProducto.Text, bscNombreProducto.Text))
         AgregarFiltro(filtro, chbCliente, Function() String.Format("{0}: {1} - {2} - ", chbCliente.Text, bscCodigoCliente.Text, bscNombreCliente.Text))
         AgregarFiltro(filtro, chbProcesoProductivo, Function() String.Format("{0}: {1} - {2} - ", chbProcesoProductivo.Text, bscCodigoProcesoProductivo.Text, bscDescripcionProcesoProductivo.Text))

         AgregarFiltro(filtro, chbTipoComprobantePedido, cmbTipoComprobantePedido)
         AgregarFiltro(filtro, chbLetraFiscalPedido, cmbLetraFiscalPedido)
         AgregarFiltro(filtro, chbCentroEmisorPedido, cmbCentroEmisorPedido)
         AgregarFiltro(filtro, chbNumeroPedido, Function() String.Format("{0}: {1} Hasta {2} - ", chbNumeroPedido.Text, txtNumeroPedidoDesde.Text, txtNumeroPedidoHasta.Text))
         AgregarFiltro(filtro, chbLineaPedido, txtLineaPedido)
      End With
      Return filtro.ToString().Trim().Trim("-"c)
   End Function
   Private Sub CargarDatosTareas(dr As DataGridViewRow)
      bscNombreTareas.Text = dr.Cells("Descripcion").Value.ToString()
      bscNombreTareas.Tag = Integer.Parse(dr.Cells("IdTarea").Value.ToString())
   End Sub
#End Region

End Class
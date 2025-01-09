Public Class InfReqComprasDetProducto

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String = Entidades.TipoComprobante.Tipos.REQCOMPRAS.ToString()

   Private _tit As Dictionary(Of String, String)

#End Region

   Private Const imprimirCompColumnKey As String = "ImprimirComp"
   'Private Const imprimirCabConCantidadColumnKey As String = "ImprimirCabConCantidad"
   'Private Const imprimirCabColumnKey As String = "ImprimirCab"

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()


         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos.CargaComboDesdeEnum(cmbAsignados, Entidades.Publicos.SiNoTodos.TODOS)

         _publicos.CargaComboUsuarios(cmbUsuarioAlta)
         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro

         RefrescarDatosGrilla()

         ugDetalle.AgregarFiltroEnLinea({"Observacion", "IdProducto", "NombreProducto", "ObservacionRQProducto", "NombreProveedorHabitual", "NombreProveedorAsignado"})
         ugDetalle.AgregarTotalesSuma({"Cantidad", "CantidadAsignada"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

      End Sub)
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      CargaGrillaDetalle(onLoad:=True)
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
         If chbUsuarioAlta.Checked And cmbUsuarioAlta.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un Usuario.")
            cmbUsuarioAlta.Focus()
            Exit Sub
         End If

         If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscProducto.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto.Focus()
            Exit Sub
         End If

         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscNombreProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If chbIdRequerimiento.Checked AndAlso txtIdRequerimiento.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Número de Requerimiento aunque activó ese Filtro.")
            txtIdRequerimiento.Focus()
            Exit Sub
         End If

         If chbPlanMaestro.Checked AndAlso txtPlanMaestro.ValorNumericoPorDefecto(0L) = 0 Then
            ShowMessage("ATENCION: NO Ingresó un Número de Plan Maestro aunque activó ese Filtro.")
            txtPlanMaestro.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle(onLoad:=False)

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)

   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

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
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chkMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      TryCatched(Sub() chbFechaEntrega.FiltroCheckedChanged(chkMesCompletoEntrega, dtpEntregaDesde, dtpEntregaHasta))
   End Sub
   Private Sub chkMesCompletoEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoEntrega.CheckedChanged
      TryCatched(Sub() chkMesCompletoEntrega.FiltroCheckedChangedMesCompleto(dtpEntregaDesde, dtpEntregaHasta))
   End Sub

   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdRequerimiento.CheckedChanged
      TryCatched(Sub() chbIdRequerimiento.FiltroCheckedChanged(txtIdRequerimiento))
   End Sub
   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuarioAlta.CheckedChanged
      TryCatched(Sub() chbUsuarioAlta.FiltroCheckedChanged(cmbUsuarioAlta))
   End Sub

#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscProducto))
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto)
         bscProducto.Datos = New Reglas.Productos().GetPorNombre(bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub

   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscNombreProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor, True)
      End Sub)
   End Sub
   Private Sub bscNombreProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscNombreProveedor)
         bscNombreProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscNombreProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscNombreProveedor.BuscadorSeleccion
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

#Region "Eventos Grilla"
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         'Imprimer el comprobante Fact o Remito según corresponda.
         If e.Cell.Column.Key = imprimirCompColumnKey Then


            'Dim letra As String = String.Empty
            'Dim IdTipoComprobante As String = String.Empty
            'Dim CentroEmisor As Short = 0
            'Dim NumeroComprobante As Long = 0
            'Dim idProveedor As Long = 0

            'IdTipoComprobante = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).Value.ToString
            'letra = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.Letra.ToString()).Value.ToString
            'CentroEmisor = Short.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).Value.ToString)
            'NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroComprobante").Value.ToString)
            'idProveedor = Long.Parse(e.Cell.Row.Cells("IdProveedor").Value.ToString)

            'Dim oVentas As Reglas.Compras = New Reglas.Compras()
            'Dim Comprobante As Entidades.Compra = oVentas.GetUna(actual.Sucursal.Id,
            '                                                     IdTipoComprobante,
            '                                                     letra,
            '                                                     CentroEmisor,
            '                                                     NumeroComprobante,
            '                                                     idProveedor)
            'Dim oImpr As ImpresionCompra = New ImpresionCompra(Comprobante)
            'Dim ReporteEstandar As Boolean = True

            'oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
         End If

         ''Imprimer el Pedido (estandar o detallado)
         'If e.Cell.Column.Key = imprimirCabColumnKey Or e.Cell.Column.Key = imprimirCabConCantidadColumnKey Then
         '   Dim idTipoComprobante As String = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).Value.ToString()
         '   Dim letra As String = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.Letra.ToString()).Value.ToString()
         '   Dim centroEmisor As Short = Short.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).Value.ToString())
         '   Dim numeroPedido As Long = Long.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).Value.ToString())

         '   Dim oPedido As Entidades.PedidoProveedor = New Reglas.PedidosProveedores().GetUno(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroPedido)
         '   Dim impresion As ImpresionPedidosProv = New ImpresionPedidosProv()

         '   If e.Cell.Column.Header.Caption = "Ver" Then
         '      'Reporte = "Eniac.Win.PedidoV2.rdlc"
         '      impresion.ImprimirPedido(oPedido, True, True)
         '   Else
         '      'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
         '      impresion.ImprimirPedidoDetallado(oPedido, True, True)
         '   End If
         'End If
      End Sub)
   End Sub

   '   'Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
   '   '   TryCatched(
   '   '   Sub()
   '   '      Dim row = e.Row.FilaSeleccionada(Of DataRow)
   '   '      If row IsNot Nothing Then
   '   '         If row.Table.Columns.Contains("UrlPlano") Then
   '   '            If Not String.IsNullOrWhiteSpace(row.Field(Of String)("UrlPlano")) Then
   '   '               e.Row.Cells("ClipArchivoAdjunto").Style = UltraWinGrid.ColumnStyle.EditButton
   '   '               e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
   '   '            Else
   '   '               e.Row.Cells("ClipArchivoAdjunto").Activation = Activation.Disabled
   '   '            End If
   '   '         End If
   '   '         If row.Table.Columns.Contains("Color") AndAlso IsNumeric(e.Row.Cells("Color").Value) Then
   '   '            e.Row.Cells("IdEstado").Appearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
   '   '            e.Row.Cells("IdEstado").Appearance.AlphaLevel = 128
   '   '            e.Row.Cells("IdEstado").Appearance.ForegroundAlpha = Alpha.Opaque

   '   '            e.Row.Cells("IdEstado").ActiveAppearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
   '   '            e.Row.Cells("IdEstado").ActiveAppearance.BackColorAlpha = Alpha.Opaque
   '   '            e.Row.Cells("IdEstado").ActiveAppearance.ForegroundAlpha = Alpha.Opaque
   '   '         End If
   '   '      End If
   '   '   End Sub)
   '   'End Sub

#End Region

#End Region

#Region "Metodos"

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         bscProducto.Selecciono = True
         bscCodigoProducto.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscNombreProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If

   End Sub

   Private Sub RefrescarDatosGrilla()

      chbFecha.Checked = False
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbFechaEntrega.Checked = False
      chkMesCompletoEntrega.Checked = False
      dtpEntregaDesde.Value = Date.Today
      dtpEntregaHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbFechaPlanMaestro.Checked = False
      chkMesCompletoPlanMaestro.Checked = False
      dtpPlanMaestroDesde.Value = Date.Today
      dtpPlanMaestroHasta.Value = Date.Today.UltimoSegundoDelDia()

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
      cmbAsignados.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      chbIdRequerimiento.Checked = False
      chbUsuarioAlta.Checked = False

      chbProducto.Checked = False
      chbProveedor.Checked = False
      chbPlanMaestro.Checked = False

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      cmbAsignados.Focus()

   End Sub

   Private Sub CargaGrillaDetalle(onLoad As Boolean)
      Dim desde = If(onLoad, Date.Today.AddDays(3), dtpDesde.Valor(chbFecha))
      Dim hasta = If(onLoad, Date.Today.AddDays(2), dtpHasta.Valor(chbFecha))

      Dim rPedidos = New Reglas.RequerimientosCompras()
      Dim dtDetalle = rPedidos.GetInfReqDetProducto(desde.Date(), hasta.UltimoSegundoDelDia(), dtpEntregaDesde.Valor(chbFechaEntrega), dtpEntregaHasta.Valor(chbFechaEntrega),
                                                    cmbTiposComprobantes.GetTiposComprobantes(), txtIdRequerimiento.ValorSeleccionado(chbIdRequerimiento, -0I),
                                                    cmbAsignados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos), detallesAsignados:=Entidades.Publicos.SiNoTodos.TODOS, cmbUsuarioAlta.ValorSeleccionado(chbUsuarioAlta, String.Empty),
                                                    If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L), If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty),
                                                    cmbMarcas.GetMarcas(todosVacio:=True), cmbModelos.GetModelos(todosVacio:=True),
                                                    cmbRubros.GetRubros(todosVacio:=True), cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True),
                                                    anulados:=Entidades.Publicos.SiNoTodos.TODOS,
                                                    agregarSelec:=False, incluyeDetalleAsignados:=True, txtPlanMaestro.ValorSeleccionado(chbPlanMaestro, -0I),
                                                    dtpPlanMaestroDesde.Valor(chbFechaPlanMaestro), dtpPlanMaestroHasta.Valor(chbFechaPlanMaestro))
      ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _tit)

      ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
      ugDetalle.DisplayLayout.Bands(0).Columns("CantidadUMCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)
      ugDetalle.DisplayLayout.Bands(0).Columns("FactorConversionCompra").Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesMostrarEnCantidad)


   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=True, muestraNombre:=False)

         If chbFecha.Checked Then
            .AppendFormat(" - Fechas: Desde {0} Hasta {1}", dtpDesde.Value, dtpHasta.Value)
         End If
         If chbFechaEntrega.Checked Then
            .AppendFormat(" - F. Entrega: Desde {0} Hasta {1}", dtpEntregaDesde.Value, dtpEntregaHasta.Value)
         End If

         If chbIdRequerimiento.Checked Then
            .AppendFormat(" - Número {0}", txtIdRequerimiento.Text)
         End If

         .AppendFormat("Asignados: {0}", cmbAsignados.Text)

         If chbUsuarioAlta.Checked Then
            .AppendFormat(" - Usuario: {0}", cmbUsuarioAlta.Text)
         End If

         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscNombreProveedor.Text)
         End If

         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto.Text, bscProducto.Text)
         End If

         If cmbMarcas.Visible Then cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=True, muestraNombre:=False)
         If cmbModelos.Visible Then cmbModelos.CargarFiltrosImpresionModelos(filtro, muestraId:=True, muestraNombre:=False)
         If cmbRubros.Visible Then cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubRubros.Visible Then cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargarFiltrosImpresionSubSubRubros(filtro, muestraId:=True, muestraNombre:=False)

      End With

      Return filtro.ToString()
   End Function

   Private Sub chbPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbPlanMaestro.CheckedChanged
      TryCatched(Sub() chbPlanMaestro.FiltroCheckedChanged(txtPlanMaestro))

   End Sub

   Private Sub chbFechaPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPlanMaestro.CheckedChanged
      TryCatched(Sub() chbFechaPlanMaestro.FiltroCheckedChanged(chkMesCompletoPlanMaestro, dtpPlanMaestroDesde, dtpPlanMaestroHasta))
   End Sub

   Private Sub chkMesCompletoPlanMaestro_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoPlanMaestro.CheckedChanged
      TryCatched(Sub() chkMesCompletoPlanMaestro.FiltroCheckedChangedMesCompleto(dtpPlanMaestroDesde, dtpPlanMaestroHasta))
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      e.Row.Cells("Cantidad").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("Cantidad").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("CantidadUMCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("CantidadUMCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
      e.Row.Cells("FactorConversionCompra").Value = Math.Round(Convert.ToDecimal(e.Row.Cells("FactorConversionCompra").Value), Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad)
   End Sub



#End Region

End Class
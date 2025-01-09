Public Class ConsultarPedidosProv
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String

   Private _tit As Dictionary(Of String, String)
   Private _tit1 As Dictionary(Of String, String)
   Private _tit2 As Dictionary(Of String, String)

   Private _puedeVerPrecios As Boolean

   Private IdUsuario As String = actual.Nombre

#End Region

   Private Const imprimirCompColumnKey As String = "ImprimirComp"
   Private Const imprimirCabConCantidadColumnKey As String = "ImprimirCabConCantidad"
   Private Const imprimirCabColumnKey As String = "ImprimirCab"

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPre")

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         _publicos = New Publicos()

         _publicos.CargaComboEstadosPedidosProv(cmbEstados, True, True, True, True, False, _tipoTipoComprobante)
         cmbEstados.SelectedIndex = 1

         chbFecha.Checked = True
         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboUsuarios(cmbUsuario)

         'Si el Usuario no tiene Compradores asociados limpio la variable para que no filtre en el cargar combo.
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

         If Not _puedeVerPrecios Then
            ugDetalle.DisplayLayout.Bands("Cabecera").Columns("ImporteTotal").Hidden = True

            ugDetalle.DisplayLayout.Bands("Cabecera").Columns("ImporteBruto").Hidden = True
            ugDetalle.DisplayLayout.Bands("Cabecera").Columns("SubTotal").Hidden = True
            ugDetalle.DisplayLayout.Bands("Cabecera").Columns("TotalImpuestos").Hidden = True
            ugDetalle.DisplayLayout.Bands("Cabecera").Columns("TotalImpuestoInterno").Hidden = True

            ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImporteTotal").Hidden = True
            ugDetalle.DisplayLayout.Bands("Comprobante").Columns("ImportePesos").Hidden = True

            ugDetalle.DisplayLayout.Bands("Detalle").Groups("Importes").Hidden = True

         End If

         ugDetalle.AgregarTotalesSuma({"ImporteTotal", "ImporteBruto", "SubTotal", "TotalImpuestos", "TotalImpuestoInterno"}) ',

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))
         _tit1 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Detalle"))
         _tit2 = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Comprobante"))

         '  Me.CargarColumnasASumar()
         ugDetalle.AgregarFiltroEnLineaMultiBanda({({"NombreProveedor"}), ({"NombreProducto"})})

      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
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
         If chbComprador.Checked And cmbComprador.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un COMPRADOR.")
            cmbComprador.Focus()
            Exit Sub
         End If

         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbIdPedido.Checked AndAlso Integer.Parse("0" & Me.txtIdPedido.Text) = 0 Then
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me, "__FaltaNumeroPedido"))
            txtIdPedido.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         Cursor = Cursors.WaitCursor

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

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
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

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick, bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor, True)
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

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      TryCatched(
      Sub()
         cmbUsuario.Enabled = chbUsuario.Checked

         If Not chbUsuario.Checked Then
            cmbUsuario.SelectedIndex = -1
         Else
            If cmbUsuario.Items.Count > 0 Then
               cmbUsuario.SelectedIndex = 0
            End If
         End If

         cmbUsuario.Focus()
      End Sub)
   End Sub

   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      TryCatched(
      Sub()
         txtIdPedido.Enabled = chbIdPedido.Checked
         If Not chbIdPedido.Checked Then
            txtIdPedido.Text = String.Empty
         Else
            txtIdPedido.Focus()
         End If
      End Sub)
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbComprador.CheckedChanged
      TryCatched(Sub() chbComprador.FiltroCheckedChanged(cmbComprador))
   End Sub

   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(
      Sub()
         txtOrdenCompra.Enabled = chbOrdenCompra.Checked
         If Not chbOrdenCompra.Checked Then
            txtOrdenCompra.Text = String.Empty
         Else
            txtOrdenCompra.Focus()
         End If
      End Sub)
   End Sub
#End Region

#Region "Eventos Grilla"
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         'Imprimer el comprobante Fact o Remito según corresponda.
         If e.Cell.Column.Key = imprimirCompColumnKey Then

            Dim letra As String = String.Empty
            Dim IdTipoComprobante As String = String.Empty
            Dim CentroEmisor As Short = 0
            Dim NumeroComprobante As Long = 0
            Dim idProveedor As Long = 0

            IdTipoComprobante = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).Value.ToString
            letra = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.Letra.ToString()).Value.ToString
            CentroEmisor = Short.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).Value.ToString)
            NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroComprobante").Value.ToString)
            idProveedor = Long.Parse(e.Cell.Row.Cells("IdProveedor").Value.ToString)

            Dim oVentas As Reglas.Compras = New Reglas.Compras()
            Dim Comprobante As Entidades.Compra = oVentas.GetUna(actual.Sucursal.Id,
                                                                 IdTipoComprobante,
                                                                 letra,
                                                                 CentroEmisor,
                                                                 NumeroComprobante,
                                                                 idProveedor)
            Dim oImpr As ImpresionCompra = New ImpresionCompra(Comprobante)
            Dim ReporteEstandar As Boolean = True

            oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
         End If

         'Imprimer el Pedido (estandar o detallado)
         If e.Cell.Column.Key = imprimirCabColumnKey Or e.Cell.Column.Key = imprimirCabConCantidadColumnKey Then
            Dim idTipoComprobante As String = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).Value.ToString()
            Dim letra As String = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.Letra.ToString()).Value.ToString()
            Dim centroEmisor As Short = Short.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).Value.ToString())
            Dim numeroPedido As Long = Long.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).Value.ToString())

            Dim oPedido As Entidades.PedidoProveedor = New Reglas.PedidosProveedores().GetUno(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroPedido)
            Dim impresion As ImpresionPedidosProv = New ImpresionPedidosProv()

            If e.Cell.Column.Header.Caption = "Ver" Then
               'Reporte = "Eniac.Win.PedidoV2.rdlc"
               impresion.ImprimirPedido(oPedido, True, True)
            Else
               'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
               impresion.ImprimirPedidoDetallado(oPedido, True, True)
            End If
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim row = e.Row.FilaSeleccionada(Of DataRow)
         If row IsNot Nothing Then
            If row.Table.Columns.Contains("UrlPlano") Then
               If Not String.IsNullOrWhiteSpace(row.Field(Of String)("UrlPlano")) Then
                  e.Row.Cells("ClipArchivoAdjunto").Style = UltraWinGrid.ColumnStyle.EditButton
                  e.Row.Cells("ClipArchivoAdjunto").ButtonAppearance.Image = My.Resources.paper_clip_64
               Else
                  e.Row.Cells("ClipArchivoAdjunto").Activation = Activation.Disabled
               End If
            End If
            If row.Table.Columns.Contains("Color") AndAlso IsNumeric(e.Row.Cells("Color").Value) Then
               e.Row.Cells("IdEstado").Appearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").Appearance.AlphaLevel = 128
               e.Row.Cells("IdEstado").Appearance.ForegroundAlpha = Alpha.Opaque

               e.Row.Cells("IdEstado").ActiveAppearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").ActiveAppearance.BackColorAlpha = Alpha.Opaque
               e.Row.Cells("IdEstado").ActiveAppearance.ForegroundAlpha = Alpha.Opaque
            End If
         End If
      End Sub)
   End Sub

#End Region

#End Region

#Region "Metodos"

   'Private Sub CargarColumnasASumar()
   '   Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"CantEstado", "cantPendiente"})
   'End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Enabled = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      cmbEstados.SelectedIndex = 1

      chbFecha.Checked = False
      chbProveedor.Checked = False
      chbUsuario.Checked = False

      chbIdPedido.Checked = False
      chbOrdenCompra.Checked = False
      If IdUsuario = "" Then
         chbComprador.Checked = False
      End If

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chbFecha.Checked = True

      ugDetalle.ClearFilas()

      cmbEstados.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim fechaDesde = dtpDesde.Valor(chbFecha).IfNull()
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()

      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim idUsuario = cmbUsuario.ValorSeleccionado(chbUsuario, String.Empty)
      Dim idPedido = txtIdPedido.ValorNumericoPorDefecto(-1I)
      Dim ordenCompra = txtOrdenCompra.ValorSeleccionado(chbOrdenCompra, 0I)
      Dim idComprador = cmbComprador.ValorSeleccionado(0I)

      Dim dtsMaster_detalle = New DataSet()

      Dim rPedidos = New Reglas.PedidosProveedores()
      Dim dtDetalle = rPedidos.pedidosCabecera(
                        actual.Sucursal.Id,
                        cmbEstados.Text, fechaDesde, fechaHasta, idPedido,
                        idProducto:=String.Empty, IdMarca:=0, IdRubro:=0, lote:=String.Empty,
                        idProveedor, idUsuario,
                        Tamanio:=0,
                        idComprador, ordenCompra,
                        _tipoTipoComprobante, cmbTiposComprobantes.GetTiposComprobantes(),
                        String.Empty, 0)
      If dtDetalle.Rows.Count = 0 Then
         ugDetalle.ClearFilas()
         Exit Sub
      End If

      dtDetalle.TableName = "Cabecera"

      dtsMaster_detalle.Tables.Add(dtDetalle)

      Dim dtPedidoDetalle = rPedidos.GetPedidosDetalladoXEstadosTodos(
                        actual.Sucursal.Id,
                        cmbEstados.Text, fechaDesde, fechaHasta, idPedido,
                        idProducto:=String.Empty, IdMarca:=0, IdRubro:=0, lote:=String.Empty,
                        idProveedor, idUsuario,
                        Tamanio:=0,
                        idComprador, ordenCompra,
                        _tipoTipoComprobante, cmbTiposComprobantes.GetTiposComprobantes())

      dtPedidoDetalle.TableName = "detalle"
      dtsMaster_detalle.Tables.Add(dtPedidoDetalle)

      Dim ColumnasPadre(4) As DataColumn
      Dim ColumnasHijo(4) As DataColumn
      ColumnasPadre(0) = dtsMaster_detalle.Tables("Cabecera").Columns("IdSucursal")
      ColumnasPadre(1) = dtsMaster_detalle.Tables("Cabecera").Columns("IdTipoComprobante")
      ColumnasPadre(2) = dtsMaster_detalle.Tables("Cabecera").Columns("CentroEmisor")
      ColumnasPadre(3) = dtsMaster_detalle.Tables("Cabecera").Columns("Letra")
      ColumnasPadre(4) = dtsMaster_detalle.Tables("Cabecera").Columns("NumeroPedido")
      ColumnasHijo(0) = dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasHijo(1) = dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasHijo(2) = dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasHijo(3) = dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasHijo(4) = dtsMaster_detalle.Tables("detalle").Columns("NumeroPedido")

      Dim relConstEnum = New DataRelation("Detalle", ColumnasPadre, ColumnasHijo, True)
      dtsMaster_detalle.Relations.Add(relConstEnum)

      Dim dtPedidoDetalleComprobante = rPedidos.GetPedidosDetalleComprobante(
                        actual.Sucursal.Id,
                        cmbEstados.Text, fechaDesde, fechaHasta, idPedido,
                        idProducto:=String.Empty, IdMarca:=0, IdRubro:=0, lote:=String.Empty,
                        idProveedor, idUsuario,
                        Tamanio:=0,
                        idComprador, ordenCompra,
                        _tipoTipoComprobante, cmbTiposComprobantes.GetTiposComprobantes())

      dtPedidoDetalleComprobante.TableName = "dtPedidoDetalleComp"
      dtsMaster_detalle.Tables.Add(dtPedidoDetalleComprobante)

      Dim ColumnasPadre1(7) As DataColumn
      Dim ColumnasHijo1(7) As DataColumn
      ColumnasPadre1(0) = dtsMaster_detalle.Tables("detalle").Columns("IdSucursal")
      ColumnasPadre1(1) = dtsMaster_detalle.Tables("detalle").Columns("IdTipoComprobante")
      ColumnasPadre1(2) = dtsMaster_detalle.Tables("detalle").Columns("CentroEmisor")
      ColumnasPadre1(3) = dtsMaster_detalle.Tables("detalle").Columns("Letra")
      ColumnasPadre1(4) = dtsMaster_detalle.Tables("detalle").Columns("NumeroPedido")
      ColumnasPadre1(5) = dtsMaster_detalle.Tables("detalle").Columns("IdProducto")
      ColumnasPadre1(6) = dtsMaster_detalle.Tables("detalle").Columns("FechaEstado")
      ColumnasPadre1(7) = dtsMaster_detalle.Tables("detalle").Columns("Orden")

      ColumnasHijo1(0) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdSucursal")
      ColumnasHijo1(1) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdTipoComprobanteP")
      ColumnasHijo1(2) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("CentroEmisorP")
      ColumnasHijo1(3) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("LetraP")
      ColumnasHijo1(4) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("NumeroPedido")
      ColumnasHijo1(5) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("IdProducto")
      ColumnasHijo1(6) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("FechaEstado")
      ColumnasHijo1(7) = dtsMaster_detalle.Tables("dtPedidoDetalleComp").Columns("Orden")

      relConstEnum = New DataRelation("Comprobante", ColumnasPadre1, ColumnasHijo1, False)
      dtsMaster_detalle.Relations.Add(relConstEnum)

      ugDetalle.SetDataBinding(dtsMaster_detalle, "Cabecera")
      ugDetalle.DataSource = dtsMaster_detalle

      If Not ugDetalle.DisplayLayout.Bands(0).Columns.Exists(imprimirCabColumnKey) Then
         ugDetalle.DisplayLayout.Bands(0).Columns.Add(imprimirCabColumnKey, "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabColumnKey).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabColumnKey).Header.VisiblePosition = 0
         ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabColumnKey).Width = 30
         If Not _tit.ContainsKey(imprimirCabColumnKey) Then _tit.Add(imprimirCabColumnKey, "")
      End If

      If Not ugDetalle.DisplayLayout.Bands(0).Columns.Exists(imprimirCabConCantidadColumnKey) Then
         ugDetalle.DisplayLayout.Bands(0).Columns.Add(imprimirCabConCantidadColumnKey, "Ver/Cant.").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         ugDetalle.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
         ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabConCantidadColumnKey).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabConCantidadColumnKey).Header.VisiblePosition = 1
         ugDetalle.DisplayLayout.Bands(0).Columns(imprimirCabConCantidadColumnKey).Width = 60
         If Not _tit.ContainsKey(imprimirCabConCantidadColumnKey) Then _tit.Add(imprimirCabConCantidadColumnKey, "")
      End If

      If Not ugDetalle.DisplayLayout.Bands(2).Columns.Exists(imprimirCompColumnKey) Then
         ugDetalle.DisplayLayout.Bands(2).Columns.Add(imprimirCompColumnKey, "Ver").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
         ugDetalle.DisplayLayout.Bands(2).Override.ButtonStyle = UIElementButtonStyle.Button3D
         ugDetalle.DisplayLayout.Bands(2).Columns(imprimirCompColumnKey).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         ugDetalle.DisplayLayout.Bands(2).Columns(imprimirCompColumnKey).Header.VisiblePosition = 0
         ugDetalle.DisplayLayout.Bands(2).Columns(imprimirCompColumnKey).Width = 30
         'Me.ugDetalle.DisplayLayout.Bands(2).Groups("Detalle").Columns.Add(Me.ugDetalle.DisplayLayout.Bands(2).Columns(btnImprimirComp), 0)
         If Not _tit2.ContainsKey(imprimirCompColumnKey) Then _tit2.Add(imprimirCompColumnKey, "")
      End If

      AjustarColumnasGrilla()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"), _tit)
      PreferenciasLeer(ugDetalle, tsbPreferencias)
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Detalle"), _tit1)
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Comprobante"), _tit2)
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: PEDIDOSPROV")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      Dim Primero = True
      With filtro

         'Dim Filtros As String = String.Empty
         .AppendFormat("Filtros: Estado: {0}", cmbEstados.Text)

         If chbFecha.Checked Then
            .AppendFormat(" - Fechas: Desde {0} Hasta {1}", dtpDesde.Value, dtpHasta.Value)
         End If
         .AppendFormat(" - ")
         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)
         If chbIdPedido.Checked Then
            .AppendFormat(" - Número {0}", txtIdPedido.Text)
         End If

         If chbProveedor.Checked Then
            .AppendFormat(" - Proveedor: {0} - {1}", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         If chbComprador.Checked Then
            .AppendFormat(" - Comprador: {0}", cmbComprador.SelectedText)
         End If
         If chbUsuario.Checked Then
            .AppendFormat(" - Usuario: {0}", cmbUsuario.Text)
         End If
         If chbOrdenCompra.Checked Then
            .AppendFormat(" - Orden de Compra: {0}", txtOrdenCompra.Text)
         End If

      End With

      Return filtro.ToString()
   End Function

#End Region

End Class
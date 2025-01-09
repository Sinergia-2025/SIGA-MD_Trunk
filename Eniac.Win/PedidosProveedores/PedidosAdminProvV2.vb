Imports System.ComponentModel

Public Class PedidosAdminProvV2
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _cache As Reglas.BusquedasCacheadas
   ''''Private _idEstado As String = String.Empty
   ''''Private _idTipoEstado As String = String.Empty
   ''''Private _insertaEstado As Boolean = False
   ''''Private _idCriticidad As String = String.Empty
   ''''Private _fechaEntrega As Date? = Nothing
   Private _tipoTipoComprobante As String

   Private _puedeVerPrecios As Boolean

   ''''Private _dtEstadosEscritura As DataTable

   Private _tit As Dictionary(Of String, String)

#End Region

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _cache = New Reglas.BusquedasCacheadas()
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         Dim rUsuario = New Reglas.Usuarios()

         _puedeVerPrecios = rUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPre")
         tsbModificarPedido.Visible = rUsuario.TienePermisos("PedidosAdminProv-Modif")
         tsbModificarPedidoSeparator.Visible = tsbModificarPedido.Visible


         _publicos = New Publicos()

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante, defaultValue:=Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString())
         cmbTiposComprobantes.Refrescar()

         cmbSucursal.Initializar(permiteSinSeleccion:=False, seleccionMultiple:=False, seleccionTodos:=False, IdFuncion, defaultValue:=actual.Sucursal.Id)
         cmbSucursal.Enabled = False   'No lo habilitamos porque aún no está implementada la lógica de inter-sucursal, pero ya reservo el espacio en la pantalla

         _publicos.CargaComboEstadosPedidosProv(cmbEstados, True, True, True, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         With ugDetalle.DisplayLayout.Bands(0)
            .Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
            .Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
            .Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro
         End With


         '_publicos.CargaComboCriticidades(cmbCriticidad)
         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         '_publicos.CargaComboEstadosPedidosProv(cmbEstadoCambiar, False, False, False, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
         ''''_dtEstadosEscritura = New Reglas.EstadosPedidosProveedores().GetAll(_tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.ESCRITURA, activos:=Entidades.Publicos.SiNoTodos.SI)

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         ''''ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

         ''''ugDetalle.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
         'cmbEstadoCambiar.SelectedIndex = 0

         ''''If Not _puedeVerPrecios Then
         ''''   'ugDetalle.DisplayLayout.Bands(0).Columns("").Hidden = True
         ''''End If

         RefrescarDatosGrilla()

         ugDetalle.AgregarFiltroEnLinea({"NombreProveedor", "NombreProducto", "observacion"}, {"ClipArchivoAdjunto"})
         ugDetalle.AgregarTotalesSuma({"cantEntregada", "cantPendiente", "CantidadNuevoEstado", "CantidadUMCompra", "CantidadUMCompraPendiente", "CantidadUMCompraNuevoEstado"})

         ''''HabilitaDetalle()

         PreferenciasLeer(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbCambiar.PerformClick()
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
   Private Sub tsbCambiar_Click(sender As Object, e As EventArgs) Handles tsbCambiar.Click
      TryCatched(
      Sub()
         ugDetalle.UpdateData()
         If Validar() Then
            Using frm = New PedidosAdminProvV2Cambiar(_cache)
               Dim drs = ugDetalle.DataSource(Of DataTable).Where(Function(dr) CBool(dr.Field(Of String)("Masivo")))
               If drs.AnySecure() Then
                  If frm.ShowDialog(Me, _tipoTipoComprobante, drs.CopyToDataTable(copiarExpresiones:=True)) = DialogResult.OK Then
                     btnConsultar.PerformClick()
                  End If
               Else
                  ShowMessage("Debe seleccionar al menos un Pedido.")
               End If
            End Using
         End If
      End Sub)
   End Sub
   Private Sub tsbModificarPedido_Click(sender As Object, e As EventArgs) Handles tsbModificarPedido.Click
      TryCatched(
      Sub()
         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim oPedido = New Reglas.PedidosProveedores().GetUno(dr.Field(Of Integer)(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()),
                                                                 dr.Field(Of String)(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()),
                                                                 dr.Field(Of String)(Entidades.PedidoProveedor.Columnas.Letra.ToString()),
                                                                 dr.Field(Of Integer)(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()),
                                                                 dr.Field(Of Long)(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()))
            Using frmPedidos = New PedidosProveedores()
               frmPedidos.IdFuncion = IdFuncion
               If Not String.IsNullOrWhiteSpace(_parametros) Then
                  frmPedidos.SetParametros(_parametros)
               End If
               frmPedidos.ModificarPedido(oPedido, Me)
            End Using
            btnConsultar.PerformClick()
         Else
            Throw New Exception(Traducciones.TraducirTexto("Por favor seleccione un pedido.", Me, "__NoSeleccionoPedidoModificar"))
         End If
      End Sub)
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
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbOrdenCompra_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdenCompra.CheckedChanged
      TryCatched(Sub() chbOrdenCompra.FiltroCheckedChanged(txtOrdenCompra))
   End Sub
#Region "Eventos Buscadores Proveedor"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
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
   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      TryCatched(Sub() chbIdPedido.FiltroCheckedChanged(txtIdPedido))
   End Sub
#Region "Eventos Buscadores Productos"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , , )
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS", , )
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
         cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
         cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, marcas:=marcas)
      End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
         cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
         cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, rubros:=rubros)
      End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
         cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
         cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, subRubro:=subRubros)
      End Sub)

   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
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
            ShowMessage(Traducciones.TraducirTexto("ATENCION: NO Ingresó un Número de Pedido aunque activó ese Filtro.", Me, "__FaltaNumeroPedido"))
            txtIdPedido.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()
         ''''HabilitaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            ugDetalle.ActiveRow = ugDetalle.Rows(0)
            ugDetalle.ActiveCell = ugDetalle.ActiveRow.Cells("IdEstado")
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

   '''''Ademas de tomar el CLIC sobre la fila, toma el desplazamiento con las flechas!!! 
   '''''Private Sub ugDetalle_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell
   ''''Private Sub ugDetalle_AfterCellActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterCellActivate

   ''''   If ugDetalle.Rows.Count = 0 Then Exit Sub

   ''''   If ugDetalle.ActiveCell Is Nothing Then Exit Sub

   ''''   _idEstado = ugDetalle.ActiveCell.Row.Cells("IdEstado").Value.ToString()
   ''''   _idTipoEstado = ugDetalle.ActiveCell.Row.Cells("idTipoEstado").Value.ToString()
   ''''   _idCriticidad = ugDetalle.ActiveCell.Row.Cells("IdCriticidad").Value.ToString()

   ''''   Try
   ''''      _fechaEntrega = DirectCast(ugDetalle.ActiveCell.Row.Cells("FechaEntrega").Value, Date?)
   ''''   Catch ex As Exception
   ''''      _fechaEntrega = Nothing
   ''''   End Try

   ''''   'txtCantidad.Text = ugDetalle.ActiveCell.Row.Cells("CantEntregada").Value.ToString
   ''''   'cmbCriticidad.SelectedValue = _idCriticidad
   ''''   'cmbEstadoCambiar.SelectedValue = _idEstado

   ''''   'If _fechaEntrega IsNot Nothing Then
   ''''   '   dtpFechaEntrega.Value = _fechaEntrega.Value
   ''''   'Else
   ''''   '   dtpFechaEntrega.Value = Today.Date
   ''''   'End If
   ''''End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim colorEstado = Color.FromArgb(dr.Field(Of Integer)("ColorEstado"))
            e.Row.Cells("Color").Color(colorEstado, colorEstado)
         End If
      End Sub)
   End Sub

   ''''Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
   ''''   TryCatched(
   ''''   Sub()
   ''''      If e.Cell.Column.Key = "masivo" Then
   ''''         ugDetalle.UpdateData()
   ''''         HabilitaDetalle()

   ''''         If Convert.ToBoolean(e.Cell.Value) Then
   ''''            e.Cell.Row.Cells("CantidadNuevoEstado").Value = e.Cell.Row.Cells("CantEntregada").Value
   ''''         Else
   ''''            e.Cell.Row.Cells("CantidadNuevoEstado").Value = DBNull.Value
   ''''         End If
   ''''      End If
   ''''   End Sub)
   ''''End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "masivo"))
      '''',
      ''''Sub(marcar, dr)
      ''''   If Convert.ToBoolean(dr.Cells("masivo").Value) Then
      ''''      dr.Cells("CantidadNuevoEstado").Value = dr.Cells("CantEntregada").Value
      ''''   Else
      ''''      dr.Cells("CantidadNuevoEstado").Value = DBNull.Value
      ''''   End If
      ''''End Sub)) '''',
      ''''onFinallyAction:=Sub(owner) HabilitaDetalle())
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString().Trim()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()
      cmbEstados.SelectedIndex = 1  'SOLO PENDIENTES

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbFecha.Checked = False
      chbProducto.Checked = False
      chbProveedor.Checked = False
      chbIdPedido.Checked = False
      chbOrdenCompra.Checked = False

      cmbTodos.SelectedIndex = 0

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      'Limpio la Grilla.
      ugDetalle.ClearFilas()

      ''''_idEstado = String.Empty
      ''''_idTipoEstado = String.Empty

      cmbEstados.Focus()

      ''''HabilitaDetalle()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim fechaDesde = dtpDesde.Valor(chbFecha).IfNull()
      Dim fechaHasta = dtpHasta.Valor(chbFecha).IfNull()
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)

      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)
      Dim idPedido = txtIdPedido.ValorSeleccionado(chbIdPedido, -1I)

      Dim ordenCompra = txtOrdenCompra.ValorSeleccionado(chbOrdenCompra, 0L)

      Dim rPedidos = New Reglas.PedidosProveedores()
      Dim dtDetalle = rPedidos.GetPedidos(cmbSucursal.GetSucursales(), cmbEstados.Text,
                                          fechaDesde, fechaHasta,
                                          idPedido, idProducto, idProveedor,
                                          cmbMarcas.GetMarcas(todosVacio:=True), cmbModelos.GetModelos(todosVacio:=True),
                                          cmbRubros.GetRubros(todosVacio:=True), cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True),
                                          ordenCompra, _tipoTipoComprobante, cmbTiposComprobantes.GetTiposComprobantes(),
                                          letra:="", centroEmisor:=0, orden:=0, fechaEstado:=Nothing,
                                          seguridadRol:=Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   ''''Private Sub HabilitaDetalle()
   ''''   ''''Dim cantidadSeleccionados As Integer = 0
   ''''   ''''Dim drCol As DataRow() = Nothing
   ''''   ''''If TypeOf (ugDetalle.DataSource) Is DataTable Then
   ''''   ''''   drCol = DirectCast(ugDetalle.DataSource, DataTable).Select("masivo")
   ''''   ''''   cantidadSeleccionados = drCol.Length
   ''''   ''''End If

   ''''   ''''''''cmbCriticidad.Enabled = cantidadSeleccionados > 0
   ''''   ''''''''cmbEstadoCambiar.Enabled = cantidadSeleccionados > 0
   ''''   ''''''''dtpFechaEntrega.Enabled = cantidadSeleccionados > 0
   ''''   ''''''''txtObservacion.Enabled = cantidadSeleccionados > 0
   ''''   ''''''''txtCantidad.Enabled = cantidadSeleccionados = 1
   ''''   ''''''''ugDetalle.DisplayLayout.Bands(0).Columns("CantidadNuevoEstado").Hidden = txtCantidad.Enabled
   ''''   ''''''''lblCantidadObservaciones.Visible = Not txtCantidad.Enabled

   ''''   ''''''''btnMasivo.Enabled = cantidadSeleccionados > 0

   ''''   ''''If cantidadSeleccionados = 1 And drCol IsNot Nothing Then
   ''''   ''''   Dim dr As DataRow = drCol(0)

   ''''   ''''   _idEstado = dr("IdEstado").ToString()
   ''''   ''''   _idTipoEstado = dr("idTipoEstado").ToString()
   ''''   ''''   _idCriticidad = dr("IdCriticidad").ToString()

   ''''   ''''   Try
   ''''   ''''      _fechaEntrega = DirectCast(dr("FechaEntrega"), Date?)
   ''''   ''''   Catch ex As Exception
   ''''   ''''      _fechaEntrega = Nothing
   ''''   ''''   End Try

   ''''   ''''   ''''   Me.txtCantidad.Text = dr("CantEntregada").ToString()
   ''''   ''''   ''''   Me.cmbCriticidad.SelectedValue = _idCriticidad
   ''''   ''''   ''''   Me.cmbEstadoCambiar.SelectedValue = _idEstado

   ''''   ''''   ''''   If _fechaEntrega IsNot Nothing Then
   ''''   ''''   ''''      dtpFechaEntrega.Value = _fechaEntrega.Value
   ''''   ''''   ''''   Else
   ''''   ''''   ''''      dtpFechaEntrega.Value = Today.Date
   ''''   ''''   ''''   End If
   ''''   ''''End If
   ''''End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)
         filtro.AppendFormat(" - Estado: {0} - ", cmbEstados.Text)
         If chbFecha.Checked Then
            filtro.AppendFormat("Fechas: desde {0:dd/MM/yyyy} hasta {1:dd/MM/yyyy} - ", dtpDesde.Value, dtpHasta.Value)
         End If
         If chbOrdenCompra.Checked Then
            filtro.AppendFormat("O. Compra: {0} - ", txtOrdenCompra.Text)
         End If
         If chbProveedor.Checked Then
            filtro.AppendFormatLine("Proveedor: {0} - {1} - ", bscCodigoProveedor.Text, bscProveedor.Text)
         End If
         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, muestraId:=False, muestraNombre:=True)
         If chbIdPedido.Checked Then
            filtro.AppendFormat("Numero: {0} - ", txtIdPedido.Text)
         End If
         If chbProducto.Checked Then
            filtro.AppendFormat("Producto: {0} - {1} - ", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If cmbMarcas.Visible Then cmbMarcas.CargaFiltroImpresion(filtro, muestraId:=False, muestraNombre:=True)
         If cmbModelos.Visible Then cmbModelos.CargaFiltroImpresion(filtro, muestraId:=False, muestraNombre:=True)
         If cmbRubros.Visible Then cmbRubros.CargaFiltroImpresion(filtro, muestraId:=False, muestraNombre:=True)
         If cmbSubRubros.Visible Then cmbSubRubros.CargaFiltroImpresion(filtro, muestraId:=False, muestraNombre:=True)
         If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargaFiltroImpresion(filtro, muestraId:=False, muestraNombre:=True)
      End With
      Return filtro.ToString()
   End Function

   Private Function Validar() As Boolean
      Using errBuilder = New Entidades.ErrorBuilder()
         Dim dtDetalle = ugDetalle.DataSource(Of DataTable)()
         If dtDetalle Is Nothing Then
            errBuilder.AddError("No seleccionó ningún Pedido.")
         Else
            Dim drCol = dtDetalle.AsEnumerable().Where(Function(dr) dr.Field(Of String)("masivo") = Boolean.TrueString)
            If Not drCol.AnySecure() Then
               errBuilder.AddError("No seleccionó ningún Pedido.")
            Else

               For Each fila In drCol
                  Dim idEstadoOriginal = fila.Field(Of String)("IdEstado")
                  Dim estadoOriginal = _cache.BuscaEstadosPedidoProveedores(idEstadoOriginal, _tipoTipoComprobante)
                  If estadoOriginal.IdTipoEstado = Entidades.EstadoPedidoProveedor.TipoEstado.ANULADO Or
                     estadoOriginal.IdTipoEstado = Entidades.EstadoPedidoProveedor.TipoEstado.RECHAZADO Or
                     estadoOriginal.IdTipoEstado = Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO Then
                     errBuilder.AddError(String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Estado Actual ({1}) NO permite cambio.", Me, "__ErrorEstadoNoPermiteCambio"),
                                                       fila("numeropedido"), estadoOriginal.IdEstado))
                  End If
               Next
            End If
         End If

         If errBuilder.AnyError Then
            errBuilder.PerformFocusOnError()
            ShowMessage(errBuilder.ErrorToString)
            Return False
         End If
      End Using
      Return True
   End Function


#Region "IConParametros"
   'Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
   '   _tipoTipoComprobante = parametros
   'End Sub
   'Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
   '   Return "Pendiente documentar"
   'End Function
   Private _parametros As String = String.Empty
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _parametros = parametros
      Dim paramFunc = New ParametrosFuncion()
      ConParametrosAyudante.Parse(parametros, GetType(PedidosProveedores.ParametrosPermitidos), paramFunc)

      _tipoTipoComprobante = paramFunc.GetValor(Of String)(PedidosProveedores.ParametrosPermitidos.TipoTipoComprobante)
      'Dim permitePrecioCero = _parametros.GetValor(Of String)(ParametrosPermitidos.PermitePrecioCero)
      '_permitePrecioCero = If(permitePrecioCero = "SI", True, If(permitePrecioCero = "NO", False, DirectCast(Nothing, Boolean?)))
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return ConParametrosAyudante.ParametrosDisponiblesAyuda(GetType(PedidosProveedores.ParametrosPermitidos))
   End Function

#End Region

#End Region

End Class
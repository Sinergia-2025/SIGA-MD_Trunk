Imports System.ComponentModel

Public Class PedidosAdminProvV2Cambiar
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String

   Private _puedeVerPrecios As Boolean

   Private _dtEstadosEscritura As DataTable
   Private _dtDetalle As DataTable
   Private _dtDetalleOrigen As DataTable

   Private _cache As Reglas.BusquedasCacheadas

   Private _tit As Dictionary(Of String, String)

   Private _ubicaciones As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))

#End Region

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _cache = New Reglas.BusquedasCacheadas()
   End Sub
   Public Sub New(cache As Reglas.BusquedasCacheadas)
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _cache = cache
   End Sub

#Region "Overrides/Overloads"
   Public Overloads Function ShowDialog(owner As BaseForm, tipoTipoComprobante As String, dt As DataTable) As DialogResult
      _tipoTipoComprobante = tipoTipoComprobante

      _dtDetalleOrigen = dt

      RefrescarDatosGrilla(dt)

      Return ShowDialog(owner)
   End Function

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, IdFuncion + "-VerPre")

         _publicos = New Publicos()

         _publicos.CargaComboCriticidades(cmbCriticidad)
         _publicos.CargaComboCriticidades(cmbCriticidadEditor)

         _publicos.CargaComboEstadosPedidosProv(cmbEstadoCambiar, False, False, False, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.LECTURA)
         _dtEstadosEscritura = New Reglas.EstadosPedidosProveedores().GetAll(_tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.ESCRITURA, activos:=Entidades.Publicos.SiNoTodos.SI)

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

         ugDetalle.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
         cmbEstadoCambiar.SelectedIndex = 0

         RefrescarDatosGrilla()

         ugDetalle.AgregarFiltroEnLinea({"NombreProveedor", "NombreProducto", "observacion"}, {"ClipArchivoAdjunto"})
         ugDetalle.AgregarTotalesSuma({"cantEntregada", "cantPendiente", "CantidadNuevoEstado", "CantidadUMCompra", "CantidadUMCompraPendiente", "CantidadUMCompraNuevoEstado"})

         chbGeneraUnPedidoPorProveedor.Visible = _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString()

         PreferenciasLeer(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
         ugDetalle.DataSource = _dtDetalle
         AjustarColumnasGrilla(ugDetalle, _tit)
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape AndAlso (ugDetalle.ActiveCell Is Nothing OrElse Not ugDetalle.ActiveCell.IsInEditMode) Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
      If DialogResult = DialogResult.Cancel Then
         If ShowPregunta("¿Desea cancelar el cambio de estado?", MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
         End If
      End If
      MyBase.OnFormClosing(e)
   End Sub

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla(_dtDetalleOrigen))
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
#End Region

#Region "Eventos Aceptar/Cancelar"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Cancelar())
   End Sub
#End Region

#Region "Eventos Aplicar Masivo"
   Private Sub btnAplicaCriticidad_Click(sender As Object, e As EventArgs) Handles btnAplicaCriticidad.Click
      TryCatched(Sub() If cmbCriticidad.SelectedIndex > -1 Then AplicarDatosMasivos("IdCriticidad", cmbCriticidad.SelectedValue))
   End Sub
   Private Sub btnAplicaFechaEntrega_Click(sender As Object, e As EventArgs) Handles btnAplicaFechaEntrega.Click
      TryCatched(Sub() AplicarDatosMasivos("FechaEntrega", dtpFechaEntrega.Value))
   End Sub
   Private Sub btnAplicaCantidad_Click(sender As Object, e As EventArgs) Handles btnAplicaCantidad.Click
      TryCatched(
      Sub()
         If txtCantidad.ValorNumericoPorDefecto(0D) > -0 Then
            AplicarDatosMasivos("CantidadNuevoEstado", Function(dr) Math.Min(txtCantidad.ValorNumericoPorDefecto(0D), dr.Field(Of Decimal)("CantidadNuevoEstado")))
         End If
      End Sub)
   End Sub
#End Region

   Private Sub controles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown, cmbEstadoCambiar.KeyDown, cmbCriticidad.KeyDown, dtpFechaEntrega.KeyDown, txtCantidad.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown, dtpFechaEntrega.KeyDown, cmbCriticidad.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            If sender.Equals(cmbCriticidad) Then
               btnAplicaCriticidad.PerformClick()
            ElseIf sender.Equals(dtpFechaEntrega) Then
               btnAplicaFechaEntrega.PerformClick()
            ElseIf sender.Equals(txtCantidad) Then
               btnAplicaCantidad.PerformClick()
            End If
            PresionarTab(e)
         End If
      End Sub)
   End Sub
   Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs) Handles txtCantidad.GotFocus
      txtCantidad.SelectAll()
   End Sub
   Private Sub cmbEstadoCambiar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoCambiar.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbEstadoCambiar.SelectedIndex > -1 Then
            Dim idEstado = cmbEstadoCambiar.ValorSeleccionado(Of String)()
            Dim estado = New Reglas.EstadosPedidosProveedores().GetUno(idEstado, _tipoTipoComprobante, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            If estado IsNot Nothing Then
               With ugDetalle.DisplayLayout.Bands(0)
                  .Columns("NombreDepositoUbicacion").Hidden = True
                  .Columns("LoteSeleccionado").Hidden = True
                  .Columns("NroSerieSeleccionado").Hidden = True

                  Dim tipoComp = New Reglas.TiposComprobantes().GetUno(estado.IdTipoComprobante, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
                  If tipoComp IsNot Nothing Then
                     'Si el comprobante afecta stock
                     If tipoComp.CoeficienteStock <> 0 Then
                        'Si hay al menos un producto que AfectaStock muestro la columna 
                        If _dtDetalle.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).AfectaStock) Then
                           .Columns("NombreDepositoUbicacion").Hidden = False
                        End If
                        'Si hay al menos un producto que usa Lote muestro la columna 
                        If _dtDetalle.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).Lote) Then
                           .Columns("LoteSeleccionado").Hidden = False
                        End If
                        'Si hay al menos un producto que usa Nro de Serie muestro la columna 
                        If _dtDetalle.Any(Function(dr) DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto).NroSerie) Then
                           .Columns("NroSerieSeleccionado").Hidden = False
                        End If
                     End If
                  End If
               End With
            End If
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim idEstado = cmbEstadoCambiar.ValorSeleccionado(Of String)()
            Dim estado = New Reglas.EstadosPedidosProveedores().GetUno(idEstado, _tipoTipoComprobante, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            Dim tipoComp = New Reglas.TiposComprobantes().GetUno(estado.IdTipoComprobante, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

            Dim selectedColumn = e.Cell.Column.Key
            Select Case selectedColumn
               Case "NombreDepositoUbicacion"
                  Using frm = New SeleccionMultipleUbicacion()
                     If frm.ShowDialog(Me, tipoComp.CoeficienteStock, tipoComp.SolicitaInformeCalidad,
                                       dr.Field(Of String)("IdProducto"), actual.Sucursal.Id, _ubicaciones(dr), dr.Field(Of Decimal)("CantidadNuevoEstado"),
                                       SeleccionMultipleUbicacion.ModosUbicacion.MultiplesUbicaciones, SeleccionMultipleUbicacion.ModosLoteSerie.Invisible) = DialogResult.OK Then
                        _ubicaciones(dr) = frm.UbicacionesSeleccionadas
                        EvaluaColecciones(dr)
                     End If
                  End Using
               Case "LoteSeleccionado"
                  Using frm = New SeleccionMultipleUbicacion()
                     If frm.ShowDialog(Me, tipoComp.CoeficienteStock, tipoComp.SolicitaInformeCalidad,
                                       dr.Field(Of String)("IdProducto"), actual.Sucursal.Id, _ubicaciones(dr), dr.Field(Of Decimal)("CantidadNuevoEstado"),
                                       SeleccionMultipleUbicacion.ModosUbicacion.MultiplesUbicaciones, SeleccionMultipleUbicacion.ModosLoteSerie.Visible) = DialogResult.OK Then
                        _ubicaciones(dr) = frm.UbicacionesSeleccionadas
                        EvaluaColecciones(dr)
                     End If
                  End Using

               Case "NroSerieSeleccionado"
                  Using frm = New SeleccionMultipleUbicacion()
                     If frm.ShowDialog(Me, tipoComp.CoeficienteStock, tipoComp.SolicitaInformeCalidad,
                                       dr.Field(Of String)("IdProducto"), actual.Sucursal.Id, _ubicaciones(dr), dr.Field(Of Decimal)("CantidadNuevoEstado"),
                                       SeleccionMultipleUbicacion.ModosUbicacion.MultiplesUbicaciones, SeleccionMultipleUbicacion.ModosLoteSerie.Visible) = DialogResult.OK Then
                        _ubicaciones(dr) = frm.UbicacionesSeleccionadas
                        EvaluaColecciones(dr)
                     End If
                  End Using

               Case Else

            End Select
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim prod = DirectCast(dr("Producto"), Entidades.ProductoLivianoParaImportarProducto)
            With e.Row
               If Not prod.Lote Then
                  .Cells("LoteSeleccionado").Activation = Activation.Disabled
               End If
               If Not prod.NroSerie Then
                  .Cells("NroSerieSeleccionado").Activation = Activation.Disabled
               End If
               If .Cells("CantidadNuevoEstado").ValorAs(0D) <= 0 Or
                  .Cells("CantidadNuevoEstado").ValorAs(0D) > .Cells("CantEntregada").ValorAs(0D) Then
                  .Cells("CantidadNuevoEstado").Color(Color.White, Color.Red)
               Else
                  .Cells("CantidadNuevoEstado").Color(Color.Black, Color.LightCyan)
               End If
            End With
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(Sub() e.Cell.Band.Layout.Grid.UpdateData())
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla(dt As DataTable)
      RefrescarDatosGrilla()
      _dtDetalle = dt.Copy()
      _dtDetalle.Columns.Add("NombreDepositoUbicacion", GetType(String))
      _dtDetalle.Columns.Add("LoteSeleccionado", GetType(String))
      _dtDetalle.Columns.Add("NroSerieSeleccionado", GetType(String))

      _dtDetalle.Columns.Add("Producto", GetType(Object))

      _ubicaciones = New Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))()
      For Each dr In _dtDetalle.AsEnumerable()
         _ubicaciones.Add(dr, New List(Of Entidades.SeleccionMultipleUbicaciones)())
      Next

      _dtDetalle.ForEach(
         Sub(dr)
            dr("CantidadNuevoEstado") = dr("CantEntregada")

            dr("LoteSeleccionado") = "(seleccionar)"
            dr("NroSerieSeleccionado") = "(seleccionar)"

            dr("Producto") = New Reglas.Productos().GetUnoParaM(dr.Field(Of String)("IdProducto"))

            EvaluaColecciones(dr)
         End Sub)
   End Sub
   Private Sub RefrescarDatosGrilla()
      cmbEstadoCambiar.SelectedIndexIfAny(0)

      txtObservacion.Clear()
      txtCantidad.SetValor(0D)

      chbGeneraUnPedidoPorProveedor.Visible = _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString()
      chbGeneraUnPedidoPorProveedor.Checked = False

      If _dtDetalle.Any() Then
         cmbEstadoCambiar.SelectedValue = _dtDetalle.First().Field(Of String)("IdEstado")
         cmbCriticidad.SelectedValue = _dtDetalle.First().Field(Of String)("IdCriticidad")
         dtpFechaEntrega.Value = _dtDetalle.First().Field(Of Date)("FechaEntrega")
      End If

      'Limpio la Grilla.
      ugDetalle.ClearFilas()
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
      End With
      Return filtro.ToString()
   End Function

   Private Function EvaluaColecciones(dr As DataRow) As DataRow

      Dim ubicAdmin = _ubicaciones(dr)

      If ubicAdmin.Count = 0 Then
         dr("NombreDepositoUbicacion") = String.Format("{0}/{1}", dr.Field(Of String)("NombreDepositoDefecto"), dr.Field(Of String)("NombreUbicacionDefecto"))
      Else
         If ubicAdmin.Count = 1 Then
            Dim u = ubicAdmin.First()
            dr("NombreDepositoUbicacion") = String.Format("{0}/{1}", u.NombreDeposito, u.NombreUbicacion)
         Else
            dr("NombreDepositoUbicacion") = "(multiples)"
         End If
      End If

      Return dr
   End Function
   Private Sub AplicarDatosMasivos(columna As String, valor As Object)
      AplicarDatosMasivos(columna, Function(dr) valor)
   End Sub
   Private Sub AplicarDatosMasivos(columna As String, accion As Func(Of DataRow, Object))
      ugDetalle.DataSource(Of DataTable).ForEach(
         Sub(dr)
            dr(columna) = accion(dr)
         End Sub)
      ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
   End Sub


   Private Sub Aceptar()
      ugDetalle.UpdateData()
      If Validar() Then

         Dim rPE = New Reglas.PedidosEstadosProveedores(_cache)
         Dim cambioEstado = ConvertirACambioEstado(ugDetalle.DataSource(Of DataTable))

         If Validar(cambioEstado) Then
            rPE.ActualizarEstadoPedidoProveedorMasivo(cambioEstado, IdFuncion)
            Close(DialogResult.OK)

            ShowMessage("¡¡ Estado/s actualizado/s Exitosamente !!.")
         End If
      End If
   End Sub

   Private Sub Cancelar()
      Close(DialogResult.Cancel)
   End Sub

   Private Function ConvertirACambioEstado(dt As DataTable) As Entidades.PedidosProveedoresAdminCambioEstado
      Return New Reglas.PedidosEstadosProveedores().ConvertirACambioEstado(dt, _ubicaciones, _tipoTipoComprobante, cmbEstadoCambiar.ValorSeleccionado(Of String),
                                                                           txtObservacion.Text, chbGeneraUnPedidoPorProveedor.Checked)
   End Function

   Private Function Validar(cambioEstado As Entidades.PedidosProveedoresAdminCambioEstado) As Boolean
      Using errBuilder = New Entidades.ErrorBuilder()
         For Each pedido In cambioEstado.Pedidos
            If pedido.Cantidad = 0 Then
               errBuilder.AddError(String.Format("La cantidad del pedido {0} no puede ser cero.", pedido.PkToString()))
            Else
               If Reglas.PedidosEstadosProveedores.GetCoeficienteStock(pedido.EstadoActual, cambioEstado.EstadoDestino, _cache) <> 0 Then
                  Dim cantidadTotalUbic = 0D
                  For Each ubic In pedido.Ubicaciones
                     cantidadTotalUbic += ubic.Cantidad
                     If ubic.Producto.Lote Then
                        Dim cantidadLotes = ubic.Lotes.SumSecure(Function(l) l.Cantidad).IfNull()
                        If cantidadLotes <> ubic.Cantidad Then
                           errBuilder.AddError(String.Format("La cantidad seleccionada en los Lotes del pedido {0} no coincide con la cantidad de {1}.", pedido.PkToString(), ubic.DisplayMember))
                        End If
                     End If
                     If ubic.Producto.NroSerie Then
                        Dim cantidadNroSerie = ubic.NrosSerie.SumSecure(Function(ns) ns.Cantidad).IfNull()
                        If cantidadNroSerie <> ubic.Cantidad Then
                           errBuilder.AddError(String.Format("La cantidad de Nros de Serie del pedido {0} no coincide con la cantidad de {1}.", pedido.PkToString(), ubic.DisplayMember))
                        End If
                     End If
                  Next
                  If cantidadTotalUbic <> pedido.Cantidad Then
                     errBuilder.AddError(String.Format("La cantidad del pedido {0} no coincide con la cantidad distribuida entre las ubicaciones.", pedido.PkToString()))
                  End If
               End If
            End If
         Next

         If errBuilder.AnyError Then
            errBuilder.PerformFocusOnError()
            ShowMessage(errBuilder.ErrorToString)
            Return False
         End If
      End Using
      Return True
   End Function
   Private Function Validar() As Boolean
      Using errBuilder = New Entidades.ErrorBuilder()
         If Not _dtEstadosEscritura.Any(Function(dr) dr.Field(Of String)("IdEstado") = cmbEstadoCambiar.Text) Then
            errBuilder.AddError(String.Format("No tiene permisos para cambiar al estado {0}", cmbEstadoCambiar.Text), cmbEstadoCambiar)
         End If

         For Each fila In _dtDetalle.AsEnumerable()

            Dim idEstado = cmbEstadoCambiar.ValorSeleccionado(Of String)
            Dim idCriticidad = fila.Field(Of String)("IdCriticidad")
            Dim fechaEntrega = fila.Field(Of Date)("FechaEntrega")

            Dim idEstadoOriginal = fila.Field(Of String)("IdEstado")
            Dim idCriticidadOriginal = fila.Field(Of String)("IdCriticidad", DataRowVersion.Original)
            Dim fechaEntregaOriginal = fila.Field(Of Date)("FechaEntrega", DataRowVersion.Original)

            If idEstado = idEstadoOriginal AndAlso idCriticidad = idCriticidadOriginal AndAlso fechaEntrega = fechaEntregaOriginal Then
               errBuilder.AddError(String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Estado a cambiar debe ser distinto al Estado Actual del Pedido o cambiar Criticidad/Fecha de Entrega.",
                                                                            Me, "__ErrorCambioMasivoNoPermitido"),
                                                 fila("numeropedido")), cmbEstadoCambiar)
            End If

            Dim estado = _cache.BuscaEstadosPedidoProveedores(idEstado, _tipoTipoComprobante)
            Dim estadoOriginal = _cache.BuscaEstadosPedidoProveedores(idEstadoOriginal, _tipoTipoComprobante)

            If Not String.IsNullOrWhiteSpace(estadoOriginal.IdEstadoDestino) Then
               If estadoOriginal.IdEstadoDestino <> estado.IdEstado Then
                  errBuilder.AddError(String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El estado del pedido seleccionado seleccionado (´{2}´) no permite pasar al estado {1}.",
                                                                               Me, "__ErrorEstadoNoPermiteSiguiente"),
                                                    fila("numeropedido"), cmbEstadoCambiar.SelectedValue.ToString(), fila("IdEstado").ToString()), cmbEstadoCambiar)
               End If

            End If

            If Not String.IsNullOrWhiteSpace(estado.IdTipoComprobante) Then
               Dim tipoComprobante = _cache.BuscaTipoComprobante(estado.IdTipoComprobante)
               If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRODUCCION.ToString() AndAlso Not fila.Field(Of Integer?)("IdFormula").HasValue Then
                  errBuilder.AddError(String.Format(Traducciones.TraducirTexto("Pedido: {0} --> El Producto {1} - '{2}' no tiene definida una Formula de Producción. No es posible pasar al módulo de Producción.",
                                                                               Me, "__ErrorCambioMasivoNoPermitido"),
                                                    fila("numeropedido"), fila("IdProducto"), fila("NombreProducto")), cmbEstadoCambiar)

               End If
            End If




         Next

         If errBuilder.AnyError Then
            errBuilder.PerformFocusOnError()
            ShowMessage(errBuilder.ErrorToString)
            Return False
         End If
      End Using
      Return True
   End Function

#End Region

#Region "Metodos IConParametros"
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

#End Region

End Class
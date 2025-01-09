Public Class GenerarOrdenesDeCalidad
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         cmbTiposComprobantes.Initializar(MiraPC:=False, Tipo1:=Entidades.TipoComprobante.Tipos.COMPRAS.ToString(), coeficionesStock:=1, coeficienteValor:=1) ' "TODOS")

         ugDetalle.AgregarFiltroEnLinea({})

         _publicos.CargaComboEstadosOrdenCalidad(cmbEstadosOrdenes)
         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantesGenerar, MiraPC:=True, Entidades.TipoComprobante.Tipos.CALIDAD.ToString())

         RefrescarDatosGrilla()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGenerar.PerformClick()
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
   Private Sub tsbGenerar_Click(sender As Object, e As EventArgs) Handles tsbGenerar.Click
      TryCatched(Sub() GeneraOrdenControlCalidad())
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
   Private Sub bscProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
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
#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscNombreProducto))
   End Sub
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscNombreProducto_BuscadorClick() Handles bscNombreProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProducto)
         bscNombreProducto.Datos = New Reglas.Productos().GetPorNombre(bscNombreProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscNombreProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         Using errBuilder = New Entidades.ErrorBuilder()
            If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscNombreProducto.Selecciono Then
               errBuilder.AddError("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", bscCodigoProducto)
            End If
            If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscNombreProveedor.Selecciono Then
               errBuilder.AddError("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", bscCodigoProveedor)
            End If

            If errBuilder.AnyError() Then
               errBuilder.PerformFocusOnError()
               Exit Sub
            End If
         End Using
         '---------------------------------------------------------------------------------------------------------------------------------------------
         CargaGrillaDetalle()
         '---------------------------------------------------------------------------------------------------------------------------------------------
         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección!")
         End If
      End Sub)
   End Sub
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, "Selec"))
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      chbFecha.Checked = False
      chbProveedor.Checked = False
      chbProducto.Checked = False

      cmbTiposComprobantes.Refrescar()

      cmbEstadosOrdenes.SetSelectedIndexSecure(0)
      cmbTiposComprobantesGenerar.SetSelectedIndexSecure(0)
      dtpFechaOrdenCalidad.Value = Date.Today

      'Limpio la Grilla.
      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim rComprasProd = New Reglas.ComprasProductos()
      Dim dtDetalle = rComprasProd.GetComprobantesOrdenControlCalidad(agregarSeleccionMultiple:=True, dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha),
                                                                      cmbTiposComprobantes.GetTiposComprobantes(),
                                                                      If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L),
                                                                      If(chbProducto.Checked, bscCodigoProducto.Text, txtObservaciones.Text))
      SetGrillaDataSource(dtDetalle)
   End Sub
   Private Sub GeneraOrdenControlCalidad()
      ugDetalle.UpdateData()

      Dim dt = ugDetalle.DataSource(Of DataTable)()
      If dt IsNot Nothing Then
         Dim drCol = dt.Where(Function(dr) dr.Field(Of Boolean)("Selec")).ToArray() ' ugDetalle.FilaSeleccionada(Of DataRow)
         If drCol.AnySecure() Then
            If ValidaGeneraOrdenControlCalidad() Then
               Dim rCalidad = New Reglas.CalidadOrdenDeControl()

               Dim orden = rCalidad.CreaOrdenControlCalidad(drCol,
                                                            cmbTiposComprobantesGenerar.ItemSeleccionado(Of Entidades.TipoComprobante),
                                                            cmbEstadosOrdenes.ItemSeleccionado(Of Entidades.EstadoOrdenCalidad),
                                                            dtpFechaOrdenCalidad.Value, observaciones:=String.Empty)
               If orden.AnySecure() Then
                  ShowMessage(String.Format("Se generaron {0} {1} exitosamente", orden.Count, cmbTiposComprobantesGenerar.Text))
                  btnConsultar.PerformClick()
               End If
            End If
         Else
            ShowMessage(String.Format("Debe selecionar al menos un producto para generar una {0}", cmbTiposComprobantesGenerar.Text))
         End If
      End If
   End Sub
   Private Function ValidaGeneraOrdenControlCalidad() As Boolean
      Using errBuilder = New Entidades.ErrorBuilder()
         If cmbTiposComprobantesGenerar.SelectedIndex < 0 Then
            errBuilder.AddError("¡Debe seleccionar un Tipo de Comprobante!", cmbTiposComprobantesGenerar)
         End If
         If cmbEstadosOrdenes.SelectedIndex < 0 Then
            errBuilder.AddError("¡Debe seleccionar un Estado de Orden de Calidad!", cmbEstadosOrdenes)
         End If

         If errBuilder.AnyError() Then
            errBuilder.PerformFocusOnError()
            ShowMessage(errBuilder.ErrorToString())
            Return False
         Else
            Return True
         End If
      End Using
   End Function

   Private Sub SetGrillaDataSource(dtDetalle As DataTable)
      Dim tit = GetColumnasVisiblesGrilla(ugDetalle)
      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, tit)
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
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

#End Region

End Class
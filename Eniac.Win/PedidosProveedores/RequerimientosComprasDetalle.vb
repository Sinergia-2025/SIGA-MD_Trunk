Public Class RequerimientosComprasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String = Entidades.TipoComprobante.Tipos.REQCOMPRAS.ToString()
   Private _estaCargando As Boolean = False
   Private _tipoComprobanteEditando As String
   Private _numeroRequerimientoEditando As Long
   Private _ordenProducto As Integer = 0
   Private _editarProductoDesdeGrilla As Boolean = False
   Private _tit As Dictionary(Of String, String)

#End Region

   Private ReadOnly Property Requerimiento As Entidades.RequerimientoCompra
      Get
         Return DirectCast(_entidad, Entidades.RequerimientoCompra)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.RequerimientoCompra)
      InitializeComponent()
      _entidad = entidad
      _tipoComprobanteEditando = Requerimiento.IdTipoComprobante
      _numeroRequerimientoEditando = Requerimiento.NumeroRequerimiento
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _estaCargando = StateForm = Eniac.Win.StateForm.Actualizar

         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, MiraPC:=True, _tipoTipoComprobante, UsaFacturacion:=True)

         _tit = GetColumnasVisiblesGrilla(ugProductos)

         BindearControles(_entidad)
         ugProductos.DataSource = Requerimiento.Productos
         AjustarColumnasGrilla(ugProductos, _tit)

         If StateForm = Eniac.Win.StateForm.Insertar Then

            cmbTiposComprobantes.SelectedIndex = -1
            cmbTiposComprobantes.SelectedIndexIfAny(0)

            ''CargarValoresIniciales()

            chbNumeroAutomatico.Checked = True

            CargarProximoNumero()
         Else

            chbNumeroAutomatico.Checked = False

         End If

         EvaluaMuestraUMC()

      End Sub)
      _estaCargando = False
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If Not cmbTiposComprobantes.Any() Then
         ShowMessage("No Existe la PC en Configuraciones/Impresoras")
         grbProveedor.Enabled = False
         tbcDetalle.Enabled = False
         btnAceptar.Enabled = False
      End If
   End Sub
   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      If DialogResult <> DialogResult.OK AndAlso btnAceptar.Enabled Then
         e.Cancel = ShowPregunta(String.Format("¿Está seguro de querer cerrar el requerimiento sin guardar? Se perderan los cambios que haya realizado"), MessageBoxDefaultButton.Button2) = DialogResult.No
      End If
      MyBase.OnClosing(e)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.F9 Then
         tbcDetalle.SelectedTab = tbpProductos
         bscCodigoProducto2.Focus()
      ElseIf keyData = (Keys.Control Or Keys.Add) Then
         btnInsertar.Focus()
         btnInsertar.PerformClick()
      ElseIf keyData = (Keys.Control Or Keys.Subtract) Then
         btnEliminar.Focus()
         btnEliminar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.RequerimientosCompras()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If cmbTiposComprobantes.SelectedIndex = -1 Then
         cmbTiposComprobantes.Focus()
         Return "Falta cargar el tipo de comprobante."
      End If

      Return MyBase.ValidarDetalle()
   End Function
   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"
   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged
      TryCatched(
      Sub()
         If _estaCargando Then Exit Sub

         If cmbTiposComprobantes.SelectedIndex = -1 Then
            Exit Sub
         End If

         Dim tipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)

         'Siempre tomo la primer letra ya que no hay Categoria Fiscal para determinar la letra si hay màs de una.
         txtLetra.Text = tipoComprobante.LetrasHabilitadas.Substring(0, 1)

         chbNumeroAutomatico.Checked = tipoComprobante.IdTipoComprobante <> _tipoComprobanteEditando ' True

         CargarProximoNumero()

      End Sub)
   End Sub
   Private Sub chbNumeroAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroAutomatico.CheckedChanged
      TryCatched(Sub() txtNumeroPosible.ReadOnly = chbNumeroAutomatico.Checked)
   End Sub

#Region "Eventos KeyDown"
   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoObservacion.KeyDown, txtCantidad.KeyDown, dtpFechaEntregaProd.KeyDown, txtObservacionProducto.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub
   Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
      TryCatched(Sub() txtCantidadUMC.SetValor(CalculaCantidadUMCDesdeCantidad(txtCantidad.ValorNumericoPorDefecto(0D), txtCantidadUMC.TagNumericoPorDefecto(0D))))
   End Sub
   Private Sub txtProductoObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoObservacion.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            txtCantidad.Focus()
         End If
      End Sub)
   End Sub
#End Region

#Region "Eventos subABM Productos"
   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      TryCatched(Sub() LimpiarProductos())
   End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(Sub() InsertarProducto())
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminarProducto())
   End Sub
   Private Sub ugProductos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugProductos.DoubleClickCell
      TryCatched(Sub() EditarProducto())
   End Sub
#End Region

#Region "Eventos Buscador Productos"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS", soloBuscaPorIdProducto:=_editarProductoDesdeGrilla)
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      '############### ver cargar proximo ID
      If Not String.IsNullOrWhiteSpace(txtLetra.Text) Then
         If cmbTiposComprobantes.ValorSeleccionado(Of String) = _tipoComprobanteEditando Then
            txtNumeroPosible.SetValor(_numeroRequerimientoEditando)
         Else
            Dim oImpresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, cmbTiposComprobantes.SelectedValue.ToString())
            Dim centroEmisor = oImpresora.CentroEmisor

            Dim rVentasNumeros = New Reglas.VentasNumeros()
            txtNumeroPosible.SetValor(rVentasNumeros.GetProximoNumero(actual.Sucursal, cmbTiposComprobantes.ValorSeleccionado(Of String), txtLetra.Text, centroEmisor))
         End If
      Else
         txtNumeroPosible.SetValor(0)
      End If
   End Sub

   Private Sub LimpiarProductos()
      bscCodigoProducto2.Permitido = True
      bscProducto2.Permitido = True
      bscCodigoProducto2.Selecciono = False
      bscProducto2.Selecciono = False

      bscCodigoProducto2.Text = String.Empty
      bscProducto2.Text = String.Empty
      txtProductoObservacion.Clear()
      txtCantidad.SetValor(0)
      txtObservacionProducto.Clear()

      txtStock.SetValor(0)

      txtCantidadUMC.SetValor(0)
      txtCantidadUMC.Tag = 0D
      pnlCantidadUMC.Visible = False

      bscCodigoProducto2.Focus()

      EvaluaMuestraUMC()
   End Sub
   Private Sub InsertarProducto()
      If ValidarInsertaProducto() Then
         'cargo los valores de los controles a variables locales---------------------
         Dim rqProd = New Entidades.RequerimientoCompraProducto()
         Dim cantidad = txtCantidad.ValorNumericoPorDefecto(0D)
         Dim fechaEntrega = dtpFechaEntregaProd.Value()

         Dim orden As Integer = If(_ordenProducto > 0, _ordenProducto, Requerimiento.Productos.MaxSecure(Function(p) p.Orden).IfNull() + 1)

         Dim producto = New Reglas.Productos().GetUno(bscCodigoProducto2.Text)

         rqProd.IdProducto = bscCodigoProducto2.Text
         rqProd.IdRequerimientoCompra = txtNumeroPosible.ValorNumericoPorDefecto(0L)
         rqProd.NombreProducto = txtProductoObservacion.Text
         rqProd.Orden = _ordenProducto
         rqProd.Cantidad = cantidad
         rqProd.CantidadUMCompra = txtCantidadUMC.ValorNumericoPorDefecto(0D)
         rqProd.FactorConversionCompra = txtCantidadUMC.TagNumericoPorDefecto(0D)
         rqProd.FechaEntrega = fechaEntrega
         rqProd.Observacion = txtObservacionProducto.Text
         rqProd.Stock = txtStock.ValorNumericoPorDefecto(0D)

         rqProd.UnidadDeMedida = producto.UnidadDeMedida
         rqProd.UnidadDeMedidaCompra = producto.UnidadDeMedidaCompra

         Requerimiento.Productos.Add(rqProd)
         ugProductos.Rows.Refresh(RefreshRow.ReloadData)
         EvaluaMuestraUMC()

         LimpiarProductos()
         bscCodigoProducto2.Focus()
      End If

   End Sub
   Private Sub EditarProducto()
      Dim rqProd = ugProductos.FilaSeleccionada(Of Entidades.RequerimientoCompraProducto)
      If rqProd IsNot Nothing Then
         If rqProd.Asignaciones.Any Then
            Throw New Exception(String.Format("El producto seleccionado ({0} {1}) ya fue asignado. No es posible editar.", rqProd.IdProducto, rqProd.NombreProducto))
         End If
         CargarProductoCompleto(rqProd)
      End If
   End Sub
   Private Sub EliminarProducto()
      Dim rqProd = ugProductos.FilaSeleccionada(Of Entidades.RequerimientoCompraProducto)
      If rqProd IsNot Nothing Then
         If rqProd.Asignaciones.Any Then
            Throw New Exception(String.Format("El producto seleccionado ({0} {1}) ya fue asignado. No es posible eliminar.", rqProd.IdProducto, rqProd.NombreProducto))
         End If
         If ShowPregunta(String.Format("¿Está seguro de eliminar el producto {0} - {1}?", rqProd.IdProducto, rqProd.NombreProducto)) = DialogResult.Yes Then
            Requerimiento.Productos.Remove(rqProd)
            ugProductos.Rows.Refresh(RefreshRow.ReloadData)
            EvaluaMuestraUMC()
         End If
      End If
   End Sub
   Public Sub EvaluaMuestraUMC()
      With ugProductos.DisplayLayout.Bands(0)
         Dim algunProductoConUMC = ugProductos.DataSource(Of List(Of Entidades.RequerimientoCompraProducto)).AnySecure(Function(rq) rq.FactorConversionCompra <> 0)
         .Columns(Entidades.RequerimientoCompraProducto.Columnas.CantidadUMCompra.ToString()).Hidden = Not algunProductoConUMC
      End With
   End Sub
   Private Function ValidarInsertaProducto() As Boolean

      'Esta Visible si permite Modificar la Descripcion.
      If txtProductoObservacion.Visible Then
         If String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
            ShowMessage("No puede ingresar sin Codigo de Producto.")
            bscCodigoProducto2.Focus()
            Return False
         End If
         If String.IsNullOrWhiteSpace(txtProductoObservacion.Text) Then
            ShowMessage("No puede ingresar sin Descripción Producto.")
            txtProductoObservacion.Focus()
            Return False
         End If
      End If

      If Not bscCodigoProducto2.Selecciono Then
         ShowMessage("No eligió un Producto ó falto pulsar ENTER.")
         bscCodigoProducto2.Focus()
         Return False
      End If

      txtCantidad.SetValor(txtCantidad.ValorNumericoPorDefecto(0D))
      If txtCantidad.ValorNumericoPorDefecto(0D) = 0 Then
         ShowMessage("La cantidad debe ser distinta de cero.")
         txtCantidad.Focus()
         Return False
      End If
      If txtCantidad.ValorNumericoPorDefecto(0D) <= 0 Then
         ShowMessage("La cantidad debe ser mayor a cero.")
         txtCantidad.Focus()
         Return False
      End If

      Return True

   End Function

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString.Trim())

         bscCodigoProducto2.Text = producto.IdProducto
         bscProducto2.Text = producto.NombreProducto
         bscCodigoProducto2.Permitido = False
         bscProducto2.Permitido = False
         bscCodigoProducto2.Selecciono = True
         bscProducto2.Selecciono = True

         txtProductoObservacion.Text = bscProducto2.Text
         If Reglas.Publicos.ComprasModificaDescripcionProducto And producto.PermiteModificarDescripcion Then
            txtProductoObservacion.Visible = Reglas.Publicos.Facturacion.FacturacionModificaDescripcionProducto And producto.PermiteModificarDescripcion
            txtProductoObservacion.BringToFront()
         End If

         txtStock.Text = dr.Cells("Stock").Value.ToString()
         txtCantidad.SetValor(1D)

         If producto.UnidadDeMedida.IdUnidadDeMedida <> producto.UnidadDeMedidaCompra.IdUnidadDeMedida Then
            pnlCantidadUMC.Visible = True
         End If
         txtCantidadUMC.Tag = producto.FactorConversionCompra
         txtCantidadUMC.SetValor(CalculaCantidadUMCDesdeCantidad(txtCantidad.ValorNumericoPorDefecto(0D), producto.FactorConversionCompra))

         If producto.PermiteModificarDescripcion Then
            txtProductoObservacion.Focus()
         Else
            txtCantidad.Focus()
            txtCantidad.SelectAll()
         End If
      End If
   End Sub

   Public Shared Function CalculaCantidadUMCDesdeCantidad(cantidad As Decimal, factorConversionCompra As Decimal) As Decimal
      Return cantidad * factorConversionCompra
   End Function
   Public Shared Function CalculaCantidadDesdeCantidadUMC(cantidadUMC As Decimal, factorConversionCompra As Decimal) As Decimal
      Return If(factorConversionCompra = 0, 0D, cantidadUMC / factorConversionCompra)
   End Function

   Private Sub CargarProductoCompleto(rqProducto As Entidades.RequerimientoCompraProducto)
      If rqProducto Is Nothing Then Exit Sub
      _editarProductoDesdeGrilla = True
      bscCodigoProducto2.Text = rqProducto.IdProducto
      bscCodigoProducto2.PresionarBoton()
      bscProducto2.Text = rqProducto.NombreProducto
      txtProductoObservacion.Text = rqProducto.NombreProducto
      txtCantidad.SetValor(rqProducto.Cantidad)
      dtpFecha.Value = rqProducto.FechaEntrega
      txtObservacionProducto.Text = rqProducto.Observacion

      txtCantidadUMC.SetValor(rqProducto.CantidadUMCompra)
      txtCantidadUMC.Tag = rqProducto.FactorConversionCompra         ' Guardo en el Tag el FactorConversionCompra de la tabla Producto

      _ordenProducto = rqProducto.Orden

      Requerimiento.Productos.Remove(rqProducto)
      ugProductos.Rows.Refresh(RefreshRow.ReloadData)

      _editarProductoDesdeGrilla = False
   End Sub

#End Region

End Class
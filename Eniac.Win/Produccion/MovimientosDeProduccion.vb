Public Class MovimientosDeProduccion

#Region "Campos"

   Private _publicos As Publicos
   Private _listaProductos As List(Of Entidades.ProduccionProducto)
   Private _numeroOrden As Integer
   Private _productoLoteTemporal As Entidades.ProductoLote
   Private _productosLotes As List(Of Entidades.ProductoLote)
   Private _titProductos As Dictionary(Of String, String)

   Public estadoAnt As New Entidades.EstadoOrdenProduccion
   Private _cargaComboDestino As Boolean = False
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _listaProductos = New List(Of Entidades.ProduccionProducto)()

            _productosLotes = New List(Of Entidades.ProductoLote)()
            _publicos.CargaComboEmpleados(Me.cmbResponsable, Entidades.Publicos.TiposEmpleados.COMPRADOR)

            ugProductos.AgregarFiltroEnLinea({"NombreProducto", "IdLote", "NombreFormula"})
            ugProductos.AgregarTotalesSuma({"Cantidad"})
            _titProductos = GetColumnasVisiblesGrilla(ugProductos)

            _cargaComboDestino = True
            _publicos.CargaComboDepositos(cmbDepositoOrigen, actual.Sucursal.IdSucursal, miraUsuario:=True, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.TODOS)
            _cargaComboDestino = False

            Nuevo()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbNuevo.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnLimpiarProducto.PerformClick()
      ElseIf keyData = (Keys.Add Or Keys.Control) Then
         btnInsertar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
      TryCatched(Sub() Nuevo())
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
         Sub() GrabarComprobante(),
         onErrorAction:=
         Sub(owner, ex)
            tsbGrabar.Enabled = True
            ShowError(ex)
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub dtpFechaProduccion_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFechaProduccion.KeyDown, cmbFormulas.KeyDown, txtCantidad.KeyDown
      TryCatched(Sub() PresionarTab(e))
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      TryCatched(Sub() LimpiarCamposProductos())
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
            bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto2)
            bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
         End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
         Sub()
            If String.IsNullOrWhiteSpace(bscCodigoProducto2.Text) Then
               ShowMessage("Debe elegir un Producto.")
               bscCodigoProducto2.Focus()
               Exit Sub
            End If

            If txtCantidad.ValorNumericoPorDefecto(0D) = 0 Then
               ShowMessage("La cantidad no puede ser 0")
               txtCantidad.Focus()
               Exit Sub
            End If

            tsbGrabar.Enabled = True

            _numeroOrden += 1

            Dim oLineaProducto = New Entidades.ProduccionProducto()

            Dim movi = New Reglas.TiposMovimientos().GetUno("PRODUCCION")
            With oLineaProducto
               .IdSucursal = actual.Sucursal.IdSucursal
               .Usuario = actual.Nombre
               .IdProduccion = 1
               .Orden = _numeroOrden
               .IdProducto = bscCodigoProducto2.Text
               .NombreProducto = bscProducto2.Text
               .IdFormula = cmbFormulas.ValorSeleccionado(Of Integer)()
               .NombreFormula = cmbFormulas.Text
               .Cantidad = txtCantidad.ValorNumericoPorDefecto(0D)
               .IdLote = ""
               .VtoLote = Nothing
               '-----------------------------------------------------------
               .IdDeposito = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
               .NombreDeposito = cmbDepositoOrigen.Text
               .IdUbicacion = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
               .NombreUbicacion = cmbUbicacionOrigen.Text
               '-----------------------------------------------------------
               'ingreso los valores del Lote
               If _productoLoteTemporal.ProductoSucursal.Producto.Lote And movi.CoeficienteStock <> 0 Then
                  Dim idl = New IngresoDeLote()
                  If idl.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                     ShowMessage("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.")
                     txtCantidad.Focus()
                     Exit Sub
                  Else

                     .IdLote = idl.txtIdLote.Text.ToUpper()
                     .VtoLote = idl.dtpFechaVencimiento.Value.Date

                     'Si Agrega, valido fechas.. sino.. que exista
                     If movi.CoeficienteStock > 0 And txtCantidad.ValorNumericoPorDefecto(0D) > 0 Then
                        If Reglas.Publicos.LoteSolicitaFechaVencimiento Then
                           'Controlar la fecha de la factura con la fecha de vencimiento del lote
                           If idl.dtpFechaVencimiento.Value.Date = dtpFechaProduccion.Value.Date Then
                              If ShowPregunta("La fecha del lote es igual a la fecha del comprobante. ¿Desea continuar?") <> DialogResult.Yes Then
                                 Exit Sub
                              End If
                           ElseIf idl.dtpFechaVencimiento.Value.Date < dtpFechaProduccion.Value.Date Then
                              If ShowPregunta("La fecha del lote es menor que la fecha del comprobante. ¿Desea continuar?") <> DialogResult.Yes Then
                                 Exit Sub
                              End If
                           End If

                           _productoLoteTemporal.FechaVencimiento = idl.dtpFechaVencimiento.Value
                        Else
                           _productoLoteTemporal.FechaVencimiento = Nothing
                        End If

                        'Valido que exista
                     Else
                        Dim oProductoLote = New Reglas.ProductosLotes().GetUno(bscCodigoProducto2.Text, idl.txtIdLote.Text.ToUpper(), actual.Sucursal.Id, .IdDeposito, .IdUbicacion)

                        If oProductoLote Is Nothing Then
                           ShowMessage("No existe el Lote informado.")
                           Exit Sub
                        End If

                        If oProductoLote.CantidadActual < Math.Abs(txtCantidad.ValorNumericoPorDefecto(0D)) Then
                           ShowMessage(String.Format("El Lote '{0}' tiene en Stock {1} quedaría en Cantidad Negativa en caso de Restarle {2}.",
                                                     idl.txtIdLote.Text, oProductoLote.CantidadActual, Math.Abs(txtCantidad.ValorNumericoPorDefecto(0D))))
                           Exit Sub
                        End If

                        'Le pongo la fecha del Lote original
                        If oProductoLote.FechaVencimiento.HasValue Then
                           .VtoLote = oProductoLote.FechaVencimiento.Value.Date
                        End If
                        _productoLoteTemporal.FechaVencimiento = .VtoLote

                     End If

                     _productoLoteTemporal.ProductoSucursal.Sucursal.IdSucursal = .IdSucursal
                     _productoLoteTemporal.IdLote = .IdLote.ToUpper()
                     _productoLoteTemporal.FechaIngreso = dtpFechaProduccion.Value

                     _productoLoteTemporal.IdDeposito = .IdDeposito
                     _productoLoteTemporal.IdUbicacion = .IdUbicacion

                     _productoLoteTemporal.CantidadInicial = .Cantidad
                     _productoLoteTemporal.CantidadActual = .Cantidad
                     _productoLoteTemporal.Habilitado = True
                     'Por ahora no hace falta
                     '_productoLoteTemporal.Orden = Me._numeroOrden
                     _productosLotes.Add(_productoLoteTemporal)

                  End If
               End If

            End With

            Dim rEstructura = New Reglas.EstructuraProductos()
            Dim variables = Reglas.ProduccionFormas.GetValoresForma(oLineaProducto.Espmm, oLineaProducto.LargoExtAlto, oLineaProducto.AnchoIntBase, architrave:=0, forma:=Nothing)
            Dim estructura = rEstructura.CreaEstructura(oLineaProducto.IdProducto, oLineaProducto.IdFormula, Publicos.ListaPreciosPredeterminada, oLineaProducto.Cantidad, muestraPrecio:=True,
                                                        variables, moneda:=Entidades.Moneda.Peso, 1)

            Dim eLotesProd As New List(Of Entidades.SeleccionMultipleProducto)

            If estructura.AnySecure() Then
               oLineaProducto.Componentes = estructura.First().ConvertToProduccionProductosFormula()
               For Each c In oLineaProducto.Componentes
                  c.IdSucursal = oLineaProducto.IdSucursal
                  c.IdDeposito = oLineaProducto.IdDeposito
                  c.IdUbicacion = oLineaProducto.IdUbicacion
               Next
            End If

            Using frm = New SeleccionMultipleUbicacionListaProductos()
               Dim rSelecc = New Reglas.SeleccionMultipleUbicaciones()
               Dim lst = oLineaProducto.Componentes.AsEnumerable().ToList().ConvertAll(
                           Function(dr)
                              Dim prod = dr.SeleccionMultiple
                              If prod Is Nothing Then
                                 prod = rSelecc.CreaSeleccionMultipleProducto(dr.IdProductoComponente,
                                                                              oLineaProducto.IdSucursal, oLineaProducto.IdDeposito, oLineaProducto.IdUbicacion,
                                                                              dr.Cantidad, dr) ' * cantidad, dr)
                                 dr.SeleccionMultiple = prod
                              End If
                              Return prod
                           End Function)

               If frm.ShowDialog(Me, lst, movi.CoeficienteStock, solicitaInformeCalidad:=False) <> DialogResult.OK Then
                  Exit Sub
               End If
            End Using


            _listaProductos.Add(oLineaProducto)

            ugProductos.Rows.Refresh(RefreshRow.FireInitializeRow)

            AjustarColumnasGrilla(ugProductos, _titProductos)
            ugProductos.Rows.Refresh(RefreshRow.FireInitializeRow)

            LimpiarCamposProductos()
         End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
         Sub()
            Dim dr = ugProductos.FilaSeleccionada(Of Entidades.ProduccionProducto)()
            If dr IsNot Nothing Then
               If ShowPregunta("Esta seguro de eliminar el producto seleccionado?") = Windows.Forms.DialogResult.Yes Then
                  EliminarLineaProducto(dr)
               End If
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub Nuevo()

      _numeroOrden = 0

      cmbResponsable.SelectedIndex = 0

      dtpFechaProduccion.Value = Date.Now

      bscCodigoProducto2.Enabled = True
      bscCodigoProducto2.Text = ""
      bscProducto2.Enabled = True
      bscProducto2.Text = ""
      txtTamanio.Text = ""
      'cmbUnidadDeMedida.SelectedIndex = -1
      txtUnidadDeMedida.Text = ""
      txtCantidad.Text = "0.00"
      _productosLotes.Clear()
      _listaProductos.Clear()
      ugProductos.DataSource = _listaProductos
      AjustarColumnasGrilla(ugProductos, _titProductos)
      ugProductos.ClearFilas()
      cmbFormulas.Enabled = False
      cmbFormulas.DataSource = Nothing

      cmbDepositoOrigen.Enabled = False
      cmbUbicacionOrigen.Enabled = False
      bscCodigoProducto2.Focus()

   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         txtTamanio.Text = dr.Cells("Tamano").Value.ToString().Trim()
         'cmbUnidadDeMedida.SelectedValue = dr.Cells("IdUnidadDeMedida").Value.ToString()
         txtUnidadDeMedida.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()

         Dim oProd = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text)

         '---------------------------------------------------------------------
         cmbDepositoOrigen.SelectedValue = dr.Cells("IdDepositoDefecto").Value.ToString()
         cmbDepositoOrigen.Enabled = True
         cmbUbicacionOrigen.SelectedValue = dr.Cells("IdUbicacionDefecto").Value.ToString()
         cmbUbicacionOrigen.Enabled = True
         '---------------------------------------------------------------------

         cmbFormulas.Enabled = True
         'Me.cmbFormulas.DisplayMember = "NombreFormula"
         'Me.cmbFormulas.ValueMember = "IdFormula"
         'Me.cmbFormulas.DataSource = New Reglas.ProductosComponentes().GetFormulas(actual.Sucursal.IdSucursal, dr.Cells("IdProducto").Value.ToString.Trim())
         _publicos.CargaComboFormulasDeProductos(cmbFormulas, bscCodigoProducto2.Text)
         If cmbFormulas.Items.Count > 0 Then
            cmbFormulas.SelectedValue = oProd.IdFormula 'Si esta NULL viene en cero y al no encontrar elemento queda en -1
            If cmbFormulas.SelectedIndex = -1 Then
               cmbFormulas.SelectedIndex = 0
            End If
         End If

         If oProd.DescontarStockComponentes Then
            ShowMessage("No puede elegir para producir un producto que descuenta componentes al facturar.")
            LimpiarCamposProductos()
            Exit Sub
         End If

         _productoLoteTemporal = New Entidades.ProductoLote()
         _productoLoteTemporal.ProductoSucursal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())

         bscProducto2.Enabled = False
         bscCodigoProducto2.Enabled = False
         'txtTamanio.Enabled = False
         'cmbUnidadDeMedida.Enabled = False

         If cmbFormulas.Items.Count > 1 Then
            cmbFormulas.Focus()
         Else
            txtCantidad.Focus()
         End If
      End If

   End Sub

   Private Sub LimpiarCamposProductos()
      bscCodigoProducto2.Enabled = True
      bscCodigoProducto2.Text = String.Empty
      bscProducto2.Enabled = True
      bscProducto2.Text = String.Empty
      txtTamanio.Text = String.Empty
      'cmbUnidadDeMedida.SelectedIndex = -1
      txtUnidadDeMedida.Text = String.Empty
      txtCantidad.Text = "0.00"
      cmbFormulas.Enabled = False
      cmbFormulas.DataSource = Nothing

      bscCodigoProducto2.Focus()

   End Sub

   Private Sub EliminarLineaProducto(dr As Entidades.ProduccionProducto)
      _listaProductos.Remove(dr)
      ugProductos.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub

   Private Sub GrabarComprobante()
      tsbGrabar.Enabled = False

      Dim oProd = New Entidades.Produccion()
      With oProd
         .IdSucursal = actual.Sucursal.IdSucursal
         .Fecha = dtpFechaProduccion.Value
         .Usuario = actual.Nombre
         .Responsable = cmbResponsable.ItemSeleccionado(Of Entidades.Empleado)()
         .Productos = _listaProductos
         .ProductosLotes = _productosLotes
      End With

      Dim rProduccion = New Reglas.Produccion()
      rProduccion.Insertar2(oProd, dtpFechaProduccion.Value)

      ugProductos.Rows.Refresh(RefreshRow.FireInitializeRow)

      ShowMessage("Los datos se grabaron correctamente")

      Nuevo()
   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositoOrigen.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
            cmbUbicacionOrigen.SelectedIndex = 0
         End If
      End Sub)
   End Sub

#End Region

End Class
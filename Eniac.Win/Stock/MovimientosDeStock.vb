Public Class MovimientosDeStock

#Region "Campos"

   Private _estado As Estados
   Private _publicos As Publicos
   Private idCategoriaFiscal As Short
   Private _productos As List(Of Entidades.MovimientoStockProducto)
   Private _proveedor As Entidades.Proveedor
   Private _cargaPrecio As String
   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Private _productoLoteTemporal As Entidades.ProductoLote
   Private _productosLotes As List(Of Entidades.ProductoLote)
   Private _productosNrosSeries As List(Of Entidades.ProductoNroSerie)

   Private _editarNrosSeries As List(Of Entidades.ProductoNroSerie)
   Private _numeroOrden As Integer
   Private _valorRedondeo As Integer
   Private _vieneDelDobleClick As Boolean = False

   Private _comprobantesSeleccionados As List(Of Entidades.Compra)
   Private _MovCompProv As Reglas.MovimientosComprasProductosArchivo

   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""

   Public Property MovAtributo01 As Entidades.AtributoProducto
   Public Property MovAtributo02 As Entidades.AtributoProducto
   Public Property MovAtributo03 As Entidades.AtributoProducto
   Public Property MovAtributo04 As Entidades.AtributoProducto

   '-- REG-35666.- ------------------------
   Private _cargaComboDestino As Boolean = False

   Public Property sucOrigen As Integer
   Public Property depOrigen As Integer
   Public Property ubiOrigen As Integer
   Public Property sucDestino As Integer
   Public Property depDestino As Integer
   Public Property ubiDestino As Integer
   '---------------------------------------

   Private flackCargaProductos As Boolean = True
   Private _modalidad As Entidades.Producto.Modalidades
   Private _codigoBarrasCompleto As String


#End Region

#Region "Enumeraciones"

   Private Enum Estados
      Insercion
      Modificacion
   End Enum

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            Me._cargoBienLaPantalla = True

            _productos = New List(Of Entidades.MovimientoStockProducto)
            _productosLotes = New List(Of Entidades.ProductoLote)()
            _productosNrosSeries = New List(Of Entidades.ProductoNroSerie)()

            _publicos = New Publicos()
            Dim rUsuario = New Reglas.Usuarios()
            Dim dtRubros = New Reglas.RubrosCompras().GetAll()

            '-- REQ-35666.- --------------------------------------------------------------------
            cmbSucursalOrigen.Text = actual.Sucursal.Nombre
            sucOrigen = actual.Sucursal.IdSucursal

            _cargaComboDestino = True
            _publicos.CargaComboSucursales(cmbSucursalDestino)
            cmbSucursalDestino.SelectedIndex = -1
            _publicos.CargaComboDepositos(cmbDepositoOrigen, sucOrigen, miraUsuario:=True, PermiteEscritura:=True, Entidades.Publicos.SiNoTodos.TODOS)
            _cargaComboDestino = False

            If cmbDepositoOrigen.Items.Count > 0 Then
               cmbDepositoOrigen.SelectedIndex = 0
            Else
               _mensajeDeErrorEnCarga = String.Format("El usuario no posee depositos autorizados para la sucursal ({0})", cmbSucursalOrigen.Text)
               _cargoBienLaPantalla = False
               Exit Sub
            End If
            '-----------------------------------------------------------------------------------
            _publicos.CargaComboEmpleados(cmbEmpleado, Entidades.Publicos.TiposEmpleados.TODOS)

            'Cargo combo de CantidadesAfectadas
            Dim lstCantidadAfectada = New List(Of Entidades.MovimientoStockProducto.Afecta)()
            lstCantidadAfectada.Add(Entidades.MovimientoStockProducto.Afecta.DISPONIBLE)
            'If Reglas.Publicos.UtilizaStockReservado Then
            '   lstCantidadAfectada.Add(Entidades.MovimientoCompraProducto.Afecta.RESERVADO)
            'End If
            'If Reglas.Publicos.UtilizaStockDefectuoso Then
            '   lstCantidadAfectada.Add(Entidades.MovimientoCompraProducto.Afecta.DEFECTUOSO)
            'End If
            'If Reglas.Publicos.UtilizaStockFuturo Then
            '   lstCantidadAfectada.Add(Entidades.MovimientoCompraProducto.Afecta.FUTURO)
            'End If
            'If Reglas.Publicos.UtilizaStockFuturoReservado Then
            '   lstCantidadAfectada.Add(Entidades.MovimientoCompraProducto.Afecta.FUTURORESERVADO)
            'End If
            _publicos.CargaComboDesdeEnum(cmbCantidadAfectada, lstCantidadAfectada.ToArray())

            cmbCantidadAfectada.SelectedIndex = 0
            cmbCantidadAfectada.Visible = cmbCantidadAfectada.Items.Count > 1
            lblCantidadAfectada.Visible = cmbCantidadAfectada.Visible

            CargarComboTiposMovimientos()

            _categoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

            If Reglas.Publicos.ProductoUtilizaCantidadesEnteras Then
               txtCantidad.Formato = "##,##0"
               'txtCantidad.IsDecimal = False   'No permite ingresar el signo de negativo
            End If

            _valorRedondeo = Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnPrecio

            FormateGrillaCampos()
            Nuevo()
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbGrabar.PerformClick()
         ''Es factible errarle a la tecla y perder todo.
         ''Se podria agregar la pregunta de si esta seguro pero pueden pensar que es la de grabar.
         'ElseIf keyData = Keys.F5 Then
         '   tsbNuevoComprobante.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
      'If e.KeyCode = Keys.F5 Then
      '   Me.tsbNuevo_Click(Me.tsbNuevoComprobante, New EventArgs())
      'End If

   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevoComprobante.Click
      TryCatched(Sub() Nuevo())
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
      Sub()
         If cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).AsociaSucursal Then
            If actual.Sucursal.IdSucursalAsociada = cmbSucursalDestino.ValorSeleccionado(Of Integer) Then
               ShowMessage("No se pueden realizar movimientos de stock entre sucursales asociadas.")
               cmbSucursalDestino.Focus()
               Return
            End If
         End If

         If cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).HabilitaEmpleado Then
            If cmbEmpleado.SelectedIndex = -1 Then
               ShowMessage("Debe seleccionar un empleado para este tipo de movimiento.")
               cmbEmpleado.Focus()
               Return
            End If
         End If

         GrabarComprobante()
      End Sub)
      tsbGrabar.Enabled = True
   End Sub

   Private Sub tsbInvocarComprobantes_Click(sender As Object, e As EventArgs) Handles tsbInvocarComprobantes.Click
      TryCatched(
      Sub()
         Using oFactAyuda = New FacturablesPendientesComAyuda("FACTCOM", "FACTCOM", New List(Of Entidades.Compra))
            oFactAyuda.ShowDialog()

            CargarProductosFacturables(oFactAyuda.ComprobantesSeleccionados)
         End Using

         LimpiarCamposProductos()
         CalcularTotales()

         tsbInvocarComprobantes.Enabled = False

      End Sub)
   End Sub

   Private Sub tsbLeerArchivo_Click(sender As Object, e As EventArgs) Handles tsbLeerArchivo.Click
      TryCatched(
      Sub()
         Using daa = New OpenFileDialog()
            daa.Filter = "Todos los Archivos (*.*)|*.csv"
            daa.FilterIndex = 1
            daa.RestoreDirectory = True

            If daa.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               Using rea = New IO.StreamReader(daa.FileName)
                  Dim linea = rea.ReadLine()

                  Do While linea IsNot Nothing
                     Dim valores = linea.Split(";"c)

                     If Integer.Parse(valores(0).ToString()) = sucOrigen Then
                        bscCodigoProducto2.Text = valores(1).ToString()
                        bscCodigoProducto2.PresionarBoton()
                        txtCantidad.Text = Math.Round(Decimal.Parse(valores(3).ToString()), 2).ToString()
                        CalcularTotalProducto()
                        btnInsertar.PerformClick()
                     Else
                        ShowMessage("Los movimientos no pertenecen a esta sucursal.")
                        Exit Do
                     End If

                     linea = rea.ReadLine()
                  Loop
               End Using
            End If
         End Using
      End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region


#Region "Eventos Buscador Productos"
   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         If bscCodigoProveedor.Enabled And _proveedor Is Nothing Then
            ShowMessage("ATENCION: Debe cargar el Proveedor antes de cargar el producto")
            bscCodigoProducto2.Text = String.Empty
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)

         Dim codProd As String = String.Empty
         Me._codigoBarrasCompleto = Me.bscCodigoProducto2.Text.Trim()

         codProd = Me.bscCodigoProducto2.Text.Trim()

         Dim dt As DataTable
         dt = oProductos.GetPorCodigo(bscCodigoProducto2.Text.Trim(), sucOrigen, Publicos.ListaPreciosPredeterminada, "TODOS")

         If dt.Rows.Count > 0 Then
            Me._modalidad = Entidades.Producto.Modalidades.NORMAL
         Else
            codProd = Me.GetCodigoModalidadPeso()
            dt = oProductos.GetPorCodigo(codProd, sucOrigen, Publicos.ListaPreciosPredeterminada, "VENTAS", , Entidades.Producto.Modalidades.PESO.ToString())
            If dt.Rows.Count > 0 Then
               Me._modalidad = DirectCast([Enum].Parse(GetType(Entidades.Producto.Modalidades), dt.Rows(0)(Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString()).ToString()), Entidades.Producto.Modalidades)  ''   Entidades.Producto.Modalidades.PESO
            End If
         End If

         bscCodigoProducto2.Datos = dt
      End Sub)
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         If bscCodigoProveedor.Enabled And _proveedor Is Nothing Then
            ShowMessage("ATENCION: Debe cargar el Proveedor antes de cargar el producto")
            bscProducto2.Text = String.Empty
            bscCodigoProveedor.Focus()
            Exit Sub
         End If
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), sucOrigen, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            CargarProducto(e.FilaDevuelta)
         End If
      End Sub)
   End Sub
#End Region

#Region "Eventos Buscador Proveedor"
   Private Sub bscCodigoProveedor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles bscCodigoProveedor.KeyPress
      TryCatched(
      Sub()
         If Not Char.IsNumber(e.KeyChar) Then
            e.Handled = True
         End If
      End Sub)
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProveedor(e.FilaDevuelta)
            bscCodigoProducto2.Select()
         End If
      End Sub)
   End Sub
#End Region


#Region "Eventos KeyDown"
   Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            btnInsertar.Select()
         End If
      End Sub)
   End Sub
   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            If txtPrecio.Enabled Then
               txtPrecio.Select()
            Else
               btnInsertar.Select()
            End If
         End If
      End Sub)
   End Sub

#End Region

#Region "Eventos LostFocus"

   Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
      TryCatched(
      Sub()
         If txtPrecio.Text.Trim().Length = 0 Then
            txtPrecio.Text = "0.00"
         End If
         CalcularTotalProducto()
      End Sub)
   End Sub

   Private Sub txtCantidad_LostFocus(sender As Object, e As EventArgs) Handles txtCantidad.LostFocus
      TryCatched(
      Sub()
         If txtCantidad.Text.Trim().Length = 0 Then

         Else
            If txtPrecio.Text = "-" Then
               txtPrecio.Text = "0.00"
            End If
         End If
         CalcularTotalProducto()
      End Sub)
   End Sub

#End Region

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
      Sub()
         If (Not bscProducto2.FilaDevuelta Is Nothing Or Not bscCodigoProducto2.FilaDevuelta Is Nothing) And txtCantidad.Text <> "" Then
            If ValidarInsertaProducto() Then
               InsertarProducto()
               bscCodigoProducto2.Focus()
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
      Sub()
         If _productos.Count > 0 Then
            If ShowPregunta("Esta seguro de eliminar el producto seleccionado?") = Windows.Forms.DialogResult.Yes Then
               EliminarLineaProducto()
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnLimpiarProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarProducto.Click
      TryCatched(
      Sub()
         LimpiarCamposProductos()
         bscCodigoProducto2.Focus()
         _vieneDelDobleClick = False
      End Sub)
   End Sub

#Region "Eventos Controles"

   Private Sub cmbTipoMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoMovimiento.SelectedIndexChanged
      TryCatched(
      Sub()
         DeshabilitarControles()

         HabilitarSucursal()
         HabilitarDestinatario()
         HabilitarEmpleado()

         'Me.LimpiaCampos()
         LimpiarCamposProductos()

         txtObservacion.Enabled = True

         ugProductos.Enabled = True

         bscCodigoProducto2.Enabled = True
         bscProducto2.Enabled = True
         txtCantidad.Enabled = True

         txtPrecio.Enabled = False

         btnInsertar.Enabled = True
         btnEliminar.Enabled = True
         tsbGrabar.Enabled = True

         cmbDepositoOrigen.Enabled = True
         cmbUbicacionOrigen.Enabled = True
         'GAR: Por el momento solo se permite en la recepcion de sucursal. Hay que liberarlo pero tambien cambiar la forma en que grabamos el archivo
         If grbMovimientoDestino.Visible And cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento) IsNot Nothing Then
            If cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).CoeficienteStock > 0 Then
               tsbLeerArchivo.Enabled = True
            End If
         End If

         If grbMovimientoDestino.Visible Then
            tsbInvocarComprobantes.Enabled = True
         End If

         If cboTipoMovimiento.SelectedIndex >= 0 Then
            _cargaPrecio = cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).CargaPrecio
         End If

         LimpiarDetalle()
      End Sub)
   End Sub

   Private Sub cmbCantidadAfectada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCantidadAfectada.SelectedIndexChanged
      TryCatched(Sub() MuestraStock())
   End Sub

#End Region

#End Region

#Region "Metodos"

   Private Function ValidarComprobante() As Boolean
      Dim sistema = Publicos.GetSistema()
      If DateDiff(DateInterval.Day, dtpFecha.Value, sistema.FechaVencimiento) < 0 Then
         ShowMessage(String.Format("La fecha es mayor a la validez del sistema, el {0:dd/MM/yyyy}.", sistema.FechaVencimiento))
         dtpFecha.Select()
         Return False
      End If

      If bscCodigoProveedor.Enabled Then
         If bscCodigoProveedor.Text.Length = 0 Then
            ShowMessage("Debe cargar un Nro. de documento.")
            bscCodigoProveedor.Select()
            Return False
         End If
      End If

      If cmbSucursalDestino.Visible Then
         If cmbSucursalDestino.SelectedIndex = -1 Then
            ShowMessage("Falta cargar la sucursal.")
            cmbSucursalDestino.Select()
            Return False
         End If
      End If

      If ugProductos.Rows.Count = 0 Then
         ShowMessage("Debe cargar como minimo un producto.")
         bscCodigoProducto2.Select()
         Return False
      End If

      Return True
   End Function

   Private Sub GrabarComprobante()
      If ValidarComprobante() Then
         tsbGrabar.Enabled = False
         'Dim oCF As Entidades.CategoriaFiscal = Nothing

         Dim oMov = New Entidades.MovimientoStock()
         With oMov
            .Sucursal = New Reglas.Sucursales().GetUna(sucOrigen, False)
            'si esta habilitada la sucursal de envio o destino
            If grbMovimientoDestino.Visible Then
               .Sucursal2 = New Reglas.Sucursales().GetUna(cmbSucursalDestino.ValorSeleccionado(Of Integer), False)
            End If

            .TipoMovimiento = New Reglas.TiposMovimientos().GetUno(cboTipoMovimiento.SelectedValue.ToString())

            .FechaMovimiento = dtpFecha.Value

            .DescuentoRecargo = 0

            .Total = txtTotalGeneral.ValorNumericoPorDefecto(0D)

            If Not _proveedor Is Nothing Then
               .Proveedor.CodigoProveedor = Long.Parse(bscCodigoProveedor.Text)
               .Proveedor.IdProveedor = Long.Parse(bscCodigoProveedor.Tag.ToString())
               .Proveedor.NombreProveedor = bscProveedor.Text
               .Proveedor.CategoriaFiscal.IdCategoriaFiscal = _proveedor.CategoriaFiscal.IdCategoriaFiscal
               .Proveedor.CategoriaFiscal.IvaDiscriminado = _proveedor.CategoriaFiscal.IvaDiscriminado
            Else
               .Proveedor.CategoriaFiscal.IvaDiscriminado = _categoriaFiscal.IvaDiscriminado
            End If

            If cmbEmpleado.SelectedIndex > -1 Then
               .Empleado = cmbEmpleado.ItemSeleccionado(Of Entidades.Empleado)()
            End If
            .PercepcionIVA = 0
            .PercepcionIB = 0
            .PercepcionGanancias = 0
            .PercepcionVarias = 0
            .Comentarios = txtObservacion.Text.Trim()
            .Observacion = txtObservacion.Text
            .Productos = _productos
            .ProductosLotes = _productosLotes
            .ProductosNrosSerie = _productosNrosSeries
            .Usuario = actual.Nombre
         End With

         Dim rMovimientos = New Reglas.MovimientosStock()
         rMovimientos.Insertar(oMov, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)

         ShowMessage(String.Format("El Movimiento {0} - {1} se ingresó con éxito!!", oMov.TipoMovimiento.Descripcion, oMov.NumeroMovimiento))

         'GAR: Solo pregunto en envio a sucursal opcion envio.
         If cmbSucursalDestino.Visible And oMov.TipoMovimiento.CoeficienteStock < 0 Then
            If ShowPregunta("Desea generar archivo .csv con estos movimientos?") = DialogResult.Yes Then
               Dim rMovArchivo = New Reglas.MovimientosComprasProductosArchivo()
               Dim cantidad = rMovArchivo.GenerarArchivo(sucOrigen, oMov.TipoMovimiento.IdDeposito, oMov.TipoMovimiento.IdTipoMovimiento, oMov.NumeroMovimiento)

               ShowMessage(String.Format("Se Exportaron {0} productos EXITOSAMENTE !!!", cantidad))
            Else
               ShowMessage("Ha cancelado la generación.")
            End If
         End If

         If oMov.TipoMovimiento.Imprime Then
            ImprimirMovimiento(oMov)
         End If
         Nuevo()

      End If
   End Sub

   Private Sub CargarComboTiposMovimientos()
      With cboTipoMovimiento
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoMovimiento"
         .DataSource = New Reglas.TiposMovimientos().GetParaCombos()
      End With
   End Sub

   Private Sub SeteaDetalleProducto()
      _productos = New List(Of Entidades.MovimientoStockProducto)
   End Sub

   ''' <summary>
   ''' Calcula el total del producto a vender
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub CalcularTotalProducto()
      If txtCantidad.Text = "-" Then
         txtCantidad.Text = "0.00"
      End If
      txtTotalProducto.Text = (txtPrecio.ValorNumericoPorDefecto(0D) * txtCantidad.ValorNumericoPorDefecto(0D)).ToString("N2")
   End Sub

   Private Sub LimpiarCamposProductos()
      bscCodigoProducto2.Enabled = True
      bscCodigoProducto2.Text = ""
      bscCodigoProducto2.FilaDevuelta = Nothing
      bscProducto2.Enabled = True
      bscProducto2.Text = ""
      bscProducto2.FilaDevuelta = Nothing
      txtPrecio.Text = "0.00"
      txtStock.Text = "0"
      txtStock2.Text = "0"
      txtCantidad.Text = "0.00"
      txtTotalProducto.Text = "0.00"
      cmbCantidadAfectada.SelectedIndex = 0
      _productoLoteTemporal = Nothing
      If cmbUbicacionOrigen.Items.Count > 0 Then
         cmbUbicacionOrigen.SelectedIndex = 0
      End If
      'If cmbUbicacionDestino.Visible Then
      '   cmbUbicacionDestino.SelectedIndex = 0
      'End If
   End Sub

   Private Sub CalcularTotales()
      'percepciones
      Dim Total = 0D
      For Each pro In _productos
         Total += pro.ImporteTotal
      Next
      txtTotalGeneral.Text = Total.ToString("N2")
   End Sub

   Private Sub Nuevo()

      tsbGrabar.Enabled = False

      _estado = Estados.Insercion

      _proveedor = Nothing

      cboTipoMovimiento.SelectedIndex = -1

      cmbDepositoOrigen.Enabled = False
      cmbUbicacionOrigen.Enabled = False

      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = Nothing

      bscCodigoProveedor.FilaDevuelta = Nothing
      bscProveedor.Text = String.Empty
      bscProveedor.FilaDevuelta = Nothing

      txtCategoriaFiscal.Text = String.Empty

      txtObservacion.Text = String.Empty

      dtpFecha.Value = Date.Now

      'cmbSucursalDestino.SelectedIndex = -1
      cmbEmpleado.SelectedIndex = -1

      txtTotalGeneral.Enabled = True
      txtTotalGeneral.Text = "0.00"


      _productos.Clear()
      ugProductos.DataSource = _productos.ToArray()

      _productosLotes.Clear()

      _productosNrosSeries.Clear()


      bscCodigoProducto2.FilaDevuelta = Nothing
      bscProducto2.Text = String.Empty
      bscProducto2.FilaDevuelta = Nothing
      txtStock.Text = String.Empty
      txtCantidad.Text = "0.00"
      txtPrecio.Text = "0.00"
      txtTotalProducto.Text = "0.00"

      bscCodigoProveedor.Focus()

      DeshabilitarControles()

      _numeroOrden = 0

      grbMovimientoOrigen.Enabled = True
      grbMovimientoDestino.Enabled = True
      grbMovimientoDestino.Visible = False

      grbDestinoDepositoUbicacion.Enabled = grbMovimientoDestino.Enabled
      grbDestinoDepositoUbicacion.Visible = grbMovimientoDestino.Visible

      lblUbicacionDestino.Visible = grbMovimientoDestino.Visible
      cmbUbicacionDestino.Visible = grbMovimientoDestino.Visible

   End Sub

   Private Sub ImprimirMovimiento(oMov As Entidades.MovimientoStock)
      TryCatched(
      Sub()
         Dim impresion = New ImprimirMovimientoStock()
         impresion.Imprimir(oMov)
      End Sub)
   End Sub

   Private Function ValidarInsertaProducto() As Boolean
      If txtCantidad.ValorNumericoPorDefecto(0D) = 0 Then
         ShowMessage("La cantidad debe ser distinta de cero.")
         txtCantidad.Select()
         Return False
      End If

      If txtCantidad.ValorNumericoPorDefecto(0D) < 0 And cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).CoeficienteStock < 0 Then
         ShowMessage("No puede ingresar una Cantidad Negativa para este Tipo de Movimiento.")
         txtCantidad.Select()
         Return False
      End If
      Return True
   End Function

   Private Sub CargarProducto(dr As DataGridViewRow)
      Dim oCF As Entidades.CategoriaFiscal = Nothing
      If _proveedor Is Nothing Then
         oCF = _categoriaFiscal
      Else
         oCF = _proveedor.CategoriaFiscal
      End If
      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      '_publicos.CargaComboUbicacionesProductos(cmbUbicacionOrigen, depOrigen, sucOrigen, dr.Cells("IdProducto").Value.ToString.Trim())
      'cmbUbicacionOrigen.SelectedIndex = 0

      Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(depOrigen, sucOrigen, ubiOrigen, bscCodigoProducto2.Text())
      If dt.Count > 0 Then
         txtStock.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         txtStock2.Text = dt.Rows(0).Field(Of Decimal)("Stock2").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
      End If


      _productoLoteTemporal = New Entidades.ProductoLote()
      _productoLoteTemporal.ProductoSucursal.Producto = New Reglas.Productos().GetUno(dr.Cells("IdProducto").Value.ToString().Trim())
      _productoLoteTemporal.ProductoSucursal = New Reglas.ProductosSucursales().GetUno(sucOrigen, dr.Cells("IdProducto").Value.ToString().Trim())

      _productoLoteTemporal.ProductoSucursal.Stock = _productoLoteTemporal.ProductoSucursal.Producto.StockActual

      bscCodigoProducto2.Enabled = False
      bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscProducto2.Enabled = False

      Dim alicuota = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())

      If _cargaPrecio = "PrecioCosto" Or _cargaPrecio = "PrecioVenta" Then
         Dim decPrecio = Decimal.Parse(dr.Cells(_cargaPrecio).Value.ToString())
         'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
         txtPrecio.Text = Decimal.Round(decPrecio, 2).ToString("N2")
      End If

      '-- REQ-34747.- -------------------------------------------------------------------------------
      MovAtributo01 = New Entidades.AtributoProducto
      MovAtributo02 = New Entidades.AtributoProducto
      MovAtributo03 = New Entidades.AtributoProducto
      MovAtributo04 = New Entidades.AtributoProducto
      If Integer.Parse(dr.Cells("Atributos").Value.ToString()) > 0 Then
         If flackCargaProductos Then
            '-- Carga los Valores de Atributo.- --
            With MovAtributo01
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo01").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo01").Value.ToString())
            End With
            With MovAtributo02
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo02").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo02").Value.ToString())
            End With
            With MovAtributo03
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo03").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo03").Value.ToString())
            End With
            With MovAtributo04
               .IdTipoAtributoProducto = Short.Parse(dr.Cells("TipoAtributo04").Value.ToString())
               .IdGrupoTipoAtributoProducto = Integer.Parse(dr.Cells("GrupoAtributo04").Value.ToString())
            End With
            '-- Convoca Formulario de Carga de Atributos.-
            Using sap = New SeleccionaAtributosProductos()
               With sap
                  .Atributo01 = MovAtributo01
                  .Atributo02 = MovAtributo02
                  .Atributo03 = MovAtributo03
                  .Atributo04 = MovAtributo04
               End With
               '-- Invoca Formulario.- -----------------------------
               If sap.ShowDialog() = DialogResult.Cancel Then
                  btnLimpiarProducto.PerformClick()
                  bscCodigoProducto2.Focus()
                  Exit Sub
               End If
               '-- Aloja los datos recuperados.- --
               With sap
                  MovAtributo01 = .Atributo01
                  MovAtributo02 = .Atributo02
                  MovAtributo03 = .Atributo03
                  MovAtributo04 = .Atributo04
               End With
            End Using
         End If

      End If

      '----------------------------------------------------------------------------------------------
      ubiOrigen = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
      Dim dtPU = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(sucOrigen, depOrigen, ubiOrigen, bscCodigoProducto2.Text())
      If dtPU.Count <> 0 Then
         txtStock.Text = dtPU.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         txtStock2.Text = dtPU.Rows(0).Field(Of Decimal)("Stock2").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
      End If
      '----------------------------------------------------------------------------------------------
      MuestraStock()
      txtCantidad.Text = "1.00"
      txtCantidad.Select()
      txtCantidad.SelectAll()

      If Me._modalidad = Entidades.Producto.Modalidades.PESO Then
         Me.txtCantidad.Text = Decimal.Round(Me.GetPrecioModalidadPeso(), 2).ToString("N2")
      End If

      Me._modalidad = Entidades.Producto.Modalidades.NORMAL

   End Sub

   Private Sub MuestraStock()
      If _productoLoteTemporal IsNot Nothing AndAlso _productoLoteTemporal.ProductoSucursal IsNot Nothing Then
         If cmbCantidadAfectada.SelectedValue.ToString() = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE.ToString() Then
            '   txtStock.Text = _productoLoteTemporal.ProductoSucursal.Stock.ToString("N2")
            'ElseIf cmbCantidadAfectada.SelectedValue.ToString() = Entidades.MovimientoCompraProducto.Afecta.RESERVADO.ToString() Then
            '   txtStock.Text = _productoLoteTemporal.ProductoSucursal.StockReservado.ToString("N2")
            'ElseIf cmbCantidadAfectada.SelectedValue.ToString() = Entidades.MovimientoCompraProducto.Afecta.DEFECTUOSO.ToString() Then
            '   txtStock.Text = _productoLoteTemporal.ProductoSucursal.StockDefectuoso.ToString("N2")
            'ElseIf cmbCantidadAfectada.SelectedValue.ToString() = Entidades.MovimientoCompraProducto.Afecta.FUTURO.ToString() Then
            '   txtStock.Text = _productoLoteTemporal.ProductoSucursal.StockFuturo.ToString("N2")
            'ElseIf cmbCantidadAfectada.SelectedValue.ToString() = Entidades.MovimientoCompraProducto.Afecta.FUTURORESERVADO.ToString() Then
            '   txtStock.Text = _productoLoteTemporal.ProductoSucursal.StockFuturoReservado.ToString("N2")
         Else
            Throw New Exception("CantidadAfectada no válida.")
         End If
      End If
   End Sub

   Private Sub CargarProductoCompleto(dr As DataGridViewRow)

      Dim oProductos = New Reglas.Productos()

      bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscCodigoProducto2.Datos = oProductos.GetPorCodigo(bscCodigoProducto2.Text.Trim(), sucOrigen, Publicos.ListaPreciosPredeterminada, "TODOS")
      bscCodigoProducto2.PresionarBoton()
      bscCodigoProducto2.Enabled = False

      'Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      bscProducto2.Enabled = False
      _editarNrosSeries = DirectCast(DirectCast(dr, DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries

      'Dejo lo que se cargo al presionar el boton.. tal vez cambio...
      'Me.txtStock.Text = dr.Cells("Stock").Value.ToString()   
      If dr.Cells("CantidadParaGrillas").Value Is Nothing Then
         txtCantidad.Text = "0.00"
      Else
         txtCantidad.Text = dr.Cells("CantidadParaGrillas").Value.ToString()
      End If

      cmbCantidadAfectada.SelectedValue = DirectCast(dr.Cells("CantidadAfectada").Value, Entidades.MovimientoStockProducto.Afecta)

      txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Cells("Precio").Value.ToString()), 2).ToString("N2")
      txtTotalProducto.Text = dr.Cells("Importe").Value.ToString()

      '-- REQ-34747.- -- Aloja los datos recuperados.- --
      With MovAtributo01
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto01").Value.ToString())
         If dr.Cells("DescripcionAtributo01").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo01").Value.ToString()
         End If
      End With
      With MovAtributo02
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto02").Value.ToString())
         If dr.Cells("DescripcionAtributo02").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo02").Value.ToString()
         End If
      End With
      With MovAtributo03
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto03").Value.ToString())
         If dr.Cells("DescripcionAtributo03").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo03").Value.ToString()
         End If
      End With
      With MovAtributo04
         .IdaAtributoProducto = Integer.Parse(dr.Cells("idaAtributoProducto04").Value.ToString())
         If dr.Cells("DescripcionAtributo04").Value IsNot Nothing Then
            .Descripcion = dr.Cells("DescripcionAtributo04").Value.ToString()
         End If
      End With
      '----------------------------------------------------------------------
      cmbUbicacionOrigen.SelectedValue = Integer.Parse(dr.Cells("IdUbicacion").Value.ToString())
      If grbMovimientoDestino.Visible Then
         cmbUbicacionDestino.SelectedValue = Integer.Parse(dr.Cells("IdUbicacion2").Value.ToString())
      End If
      '----------------------------------------------------------------------
   End Sub

   Private Sub InsertarProducto()

      _numeroOrden += 1

      Dim oLineaDetalle = New Entidades.MovimientoStockProducto()
      With oLineaDetalle
         .IdProducto = bscCodigoProducto2.Text
         .NombreProducto = bscProducto2.Text
         .DescuentoRecargo = 0
         .Precio = txtPrecio.ValorNumericoPorDefecto(0D)
         '--REQ-34747.- --------------------------------
         .IdaAtributoProducto01 = MovAtributo01.IdaAtributoProducto
         .DescripcionAtributo01 = MovAtributo01.Descripcion
         .IdaAtributoProducto02 = MovAtributo02.IdaAtributoProducto
         .DescripcionAtributo02 = MovAtributo02.Descripcion
         .IdaAtributoProducto03 = MovAtributo03.IdaAtributoProducto
         .DescripcionAtributo03 = MovAtributo03.Descripcion
         .IdaAtributoProducto04 = MovAtributo04.IdaAtributoProducto
         .DescripcionAtributo04 = MovAtributo04.Descripcion
         '---------------------------------------------
         If cmbCantidadAfectada.SelectedValue.ToString() = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE.ToString() Then
            .Cantidad = txtCantidad.ValorNumericoPorDefecto(0D)
            .CantidadParaGrillas = txtCantidad.ValorNumericoPorDefecto(0D)
         Else
            Throw New Exception("CantidadAfectada no válida.")
         End If

         .CantidadAfectada = cmbCantidadAfectada.ValorSeleccionado(Of Entidades.MovimientoStockProducto.Afecta)

         .ImporteTotal = txtTotalProducto.ValorNumericoPorDefecto(0D)
         .PorcentajeIVA = 0
         .IVA = 0
         .TotalProducto = .ImporteTotal
         If txtStock.Text.Length <> 0 Then
            .Stock = txtStock.ValorNumericoPorDefecto(0D)
         Else
            .Stock = 0
         End If
         'REG-35666.- -----------
         .IdSucursal = sucOrigen
         .IdDeposito = depOrigen
         .NombreDeposito = cmbDepositoOrigen.Text
         .IdUbicacion = ubiOrigen
         .NombreUbicacion = cmbUbicacionOrigen.Text
         .IdSucursal2 = If(Not grbMovimientoDestino.Visible, 0, sucDestino)
         .IdDeposito2 = If(Not grbMovimientoDestino.Visible, 0, depDestino)
         .IdUbicacion2 = If(Not grbMovimientoDestino.Visible, 0, ubiDestino)
         .NombreSucursal2 = If(Not grbMovimientoDestino.Visible, "", cmbSucursalDestino.Text)
         .NombreDeposito2 = If(Not grbMovimientoDestino.Visible, "", cmbDepositoDestino.Text)
         .NombreUbicacion2 = If(Not grbMovimientoDestino.Visible, "", cmbUbicacionDestino.Text)
         '-----------------------
         .Usuario = actual.Nombre
         .IdLote = String.Empty
         .VtoLote = Nothing

         'ingreso los valores del Lote
         If _productoLoteTemporal.ProductoSucursal.Producto.Lote And cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).CoeficienteStock <> 0 Then

            'Dim idl As IngresoDeLote = New IngresoDeLote() '# Se cambia la pantalla por la misma que está utilizando Movimientos de Compras V2
            Dim idl = New SeleccionDeLote(.IdProducto, depOrigen, ubiOrigen,
                                          .Cantidad, DirectCast(cboTipoMovimiento.SelectedItem, Entidades.TipoMovimiento).CoeficienteStock, Compra:=True,
                                          loteCargado:=Nothing, False, String.Empty, String.Empty)
            If idl.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
               MessageBox.Show("Si el producto esta marcado que utiliza Lote tiene que ingresar uno en la Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtCantidad.Focus()
               Exit Sub
            Else

               If DirectCast(Me.cboTipoMovimiento.SelectedItem, Entidades.TipoMovimiento).AsociaSucursal And Me.cmbSucursalDestino.SelectedItem Is Nothing Then
                  MessageBox.Show("Debe seleccionar una Sucursal antes de continuar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cmbSucursalDestino.Focus()
                  Exit Sub
               End If

               '.IdLote = idl.txtIdLote.Text
               '.VtoLote = idl.dtpFechaVencimiento.Value.Date

               'If DirectCast(Me.cboTipoMovimiento.SelectedItem, Entidades.TipoMovimiento).AsociaSucursal Then
               '   Me._productoLoteTemporal.ProductoSucursal.Sucursal.IdSucursal = DirectCast(Me.cboSucursal.SelectedItem, Entidades.Sucursal).IdSucursal
               'Else
               '   Me._productoLoteTemporal.ProductoSucursal.Sucursal.IdSucursal = .IdSucursal
               'End If
               'Me._productoLoteTemporal.IdLote = .IdLote
               'Me._productoLoteTemporal.ProductoSucursal.Sucursal.IdSucursal = .IdSucursal
               'Me._productoLoteTemporal.CantidadInicial = .Cantidad
               'Me._productoLoteTemporal.CantidadActual = .Cantidad
               'Me._productoLoteTemporal.FechaIngreso = Me.dtpFecha.Value
               'Me._productoLoteTemporal.FechaVencimiento = idl.dtpFechaVencimiento.Value
               'Me._productoLoteTemporal.Habilitado = True
               'Me._productosLotes.Add(Me._productoLoteTemporal)
               ''Si es un movimiento entre sucursales tengo que grabar el movimiento en los lotes
               ''If DirectCast(Me.cboTipoMovimiento.SelectedItem, Entidades.TipoMovimiento).AsociaSucursal Then
               ''   Dim prLoTe As Entidades.ProductoLote = New Entidades.ProductoLote()
               ''   prLoTe.ProductoSucursal.Producto = Me._productoLoteTemporal.ProductoSucursal.Producto
               ''   prLoTe.ProductoSucursal.Sucursal.IdSucursal = .IdSucursal
               ''   prLoTe.IdLote = .IdLote
               ''   prLoTe.FechaIngreso = Me.dtpFecha.Value
               ''   prLoTe.FechaVencimiento = idl.dtpFechaVencimiento.Value
               ''   prLoTe.CantidadInicial -= .Cantidad
               ''   prLoTe.CantidadActual -= .Cantidad
               ''   prLoTe.Habilitado = True
               ''   Me._productosLotes.Add(prLoTe)
               ''End If

               .IdLote = idl.bscLote.Text.ToUpper()
               .VtoLote = idl.dtpFechaVencimiento.Value.Date

               'Si Agrega, valido fechas.. sino.. que exista
               If DirectCast(Me.cboTipoMovimiento.SelectedItem, Entidades.TipoMovimiento).CoeficienteStock > 0 And Decimal.Parse(Me.txtCantidad.Text) > 0 Then
                  If Publicos.LoteSolicitaFechaVencimiento Then
                     'Controlar la fecha de la factura con la fecha de vencimiento del lote
                     If idl.dtpFechaVencimiento.Value.Date = Me.dtpFecha.Value.Date Then
                        If MessageBox.Show("La fecha del lote es igual a la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                           Exit Sub
                        End If
                     ElseIf idl.dtpFechaVencimiento.Value.Date < Me.dtpFecha.Value.Date Then
                        If MessageBox.Show("La fecha del lote es menor que la fecha del comprobante. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                           Exit Sub
                        End If
                     End If

                     Me._productoLoteTemporal.FechaVencimiento = idl.dtpFechaVencimiento.Value
                  Else
                     Me._productoLoteTemporal.FechaVencimiento = Nothing
                  End If

                  'Valido que exista
               Else

                  Dim oProductoLote As Entidades.ProductoLote

                  oProductoLote = New Reglas.ProductosLotes().GetUno(Me.bscCodigoProducto2.Text, idl.bscLote.Text.ToUpper(), sucOrigen, .IdDeposito, .IdUbicacion)

                  If oProductoLote Is Nothing Then
                     MessageBox.Show("No existe el Lote informado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If

                  If oProductoLote.CantidadActual < Math.Abs(Decimal.Parse(Me.txtCantidad.Text)) Then
                     MessageBox.Show("El Lote '" & idl.bscLote.Text & "' tiene en Stock " & oProductoLote.CantidadActual.ToString() & " quedaría en Cantidad Negativa en caso de Restarle " & Math.Abs(Decimal.Parse(Me.txtCantidad.Text)).ToString() & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If

                  'Le pongo la fecha del Lote original
                  If oProductoLote.FechaVencimiento.HasValue Then
                     .VtoLote = oProductoLote.FechaVencimiento.Value.Date
                  Else
                     .VtoLote = Nothing
                  End If
                  Me._productoLoteTemporal.FechaVencimiento = .VtoLote

               End If

               Me._productoLoteTemporal.ProductoSucursal.Sucursal.IdSucursal = .IdSucursal
               Me._productoLoteTemporal.IdLote = .IdLote.ToUpper()
               Me._productoLoteTemporal.FechaIngreso = Me.dtpFecha.Value

               _productoLoteTemporal.IdDeposito = .IdDeposito
               _productoLoteTemporal.IdUbicacion = .IdUbicacion

               Me._productoLoteTemporal.CantidadInicial = .Cantidad
               Me._productoLoteTemporal.CantidadActual = .Cantidad
               Me._productoLoteTemporal.Habilitado = True
               'Por ahora no hace falta
               'Me._productoLoteTemporal.Orden = Me._numeroOrden
               Me._productosLotes.Add(Me._productoLoteTemporal)

            End If
         End If

         'Selecciono los nros. de serie SOLO si el producto permite
         If Me._productoLoteTemporal.ProductoSucursal.Producto.NroSerie Then
            Dim Valor As Decimal
            Valor = Decimal.Parse(DirectCast(Me.cboTipoMovimiento.SelectedItem, Entidades.TipoMovimiento).CoeficienteStock.ToString()) * Decimal.Parse(Me.txtCantidad.Text.ToString())
            If Valor > 0 Then
               'ingreso los nros. de serie
               ' VER PORQUE ELIMINA LOS RENGLONES QUE NO SE EDITARON

               oLineaDetalle.ProductoSucursal.Producto = New Reglas.Productos().GetUno(.IdProducto)

               If oLineaDetalle.ProductoSucursal.Producto.NroSerie Then
                  Dim cantidadDeProductos As Integer = Integer.Parse(Math.Round(.Cantidad, 0).ToString())

                  If _vieneDelDobleClick Then
                     oLineaDetalle.ProductoSucursal.Producto.NrosSeries = _editarNrosSeries
                  End If

                  Dim Ver As Boolean = False 'Para distinguir el llamado del boton Ver en Grilla
                  Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos, oLineaDetalle.ProductoSucursal.Producto, _productosNrosSeries, Ver,
                                                                           Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()),
                                                                           Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString()))

                  If ins.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                     MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie los tiene que ingresar en la compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Me.btnInsertar.Focus()
                     Exit Sub
                  Else
                     Dim eMCPNS As Entidades.MovimientoStockProductoNrosSerie
                     For Each ns As Entidades.ProductoNroSerie In ins.ProductosNrosSerie
                        ns.OrdenCompra = _numeroOrden
                        eMCPNS = New Entidades.MovimientoStockProductoNrosSerie
                        '-- REG-35666.- -----------------
                        eMCPNS.IdSucursal = ns.IdSucursal
                        eMCPNS.IdDeposito = ns.IdDeposito
                        eMCPNS.IdUbicacion = ns.IdUbicacion
                        '--------------------------------
                        eMCPNS.IdTipoMovimiento = .MovimientoStock.TipoMovimiento.IdTipoMovimiento
                        eMCPNS.NumeroMovimiento = .MovimientoStock.NumeroMovimiento
                        eMCPNS.Orden = ns.OrdenCompra.Value
                        eMCPNS.IdProducto = ns.Producto.IdProducto
                        eMCPNS.NroSerie = ns.NroSerie
                        ns.IdSucursal = sucOrigen
                        ns.IdDeposito = depOrigen
                        ns.IdUbicacion = ubiOrigen
                        .ProductosNrosSerie.Add(eMCPNS)

                        Me._productosNrosSeries.Add(ns)
                     Next

                     If Not _vieneDelDobleClick Then
                        oLineaDetalle.ProductoSucursal.Producto.NrosSeries.Clear()
                        For Each pns As Entidades.ProductoNroSerie In ins.ProductosNrosSerie
                           oLineaDetalle.ProductoSucursal.Producto.NrosSeries.Add(pns)
                        Next
                     End If
                  End If

               End If
            Else
               Dim nrosSerie As DataTable
               Dim onrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie()
               '-- REQ-32489.- --------------------------------------------------------------------------
               nrosSerie = onrosSerie.GetNrosSerieProducto(actual.Sucursal, cmbDepositoOrigen.ValorSeleccionado(Of Integer), cmbUbicacionOrigen.ValorSeleccionado(Of Integer), bscCodigoProducto2.Text)
               Dim cantidadDeProductos As Integer = Int32.Parse(Math.Round(Decimal.Parse(Me.txtCantidad.Text), 0).ToString())
               Dim sel As SeleccionoNrosSerie = New SeleccionoNrosSerie(cantidadDeProductos, Me._productoLoteTemporal.ProductoSucursal.Producto, nrosSerie)
               If sel.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                  MessageBox.Show("Si el producto esta marcado que utiliza Nro. de Serie debe seleccionar los numeros", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Me.btnInsertar.Focus()
                  Exit Sub
               Else
                  For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
                     ns.OrdenCompra = _numeroOrden
                     Dim eMCPNS = New Entidades.MovimientoStockProductoNrosSerie()
                     '-- REG-35666.- -----------------
                     eMCPNS.IdSucursal = ns.IdSucursal
                     eMCPNS.IdDeposito = ns.IdDeposito
                     eMCPNS.IdUbicacion = ns.IdUbicacion
                     '--------------------------------
                     eMCPNS.IdTipoMovimiento = .MovimientoStock.TipoMovimiento.IdTipoMovimiento
                     eMCPNS.NumeroMovimiento = .MovimientoStock.NumeroMovimiento
                     eMCPNS.Orden = ns.OrdenCompra.Value
                     eMCPNS.IdProducto = ns.Producto.IdProducto
                     eMCPNS.NroSerie = ns.NroSerie
                     .ProductosNrosSerie.Add(eMCPNS)

                     _productosNrosSeries.Add(ns)
                  Next


                  For Each ns As Entidades.ProductoNroSerie In sel.ProductosNrosSerie
                     oLineaDetalle.ProductoSucursal.Producto.NrosSeries.Add(ns)
                  Next
               End If
            End If
         End If

         .Orden = Me._numeroOrden
      End With

      Me._productos.Add(oLineaDetalle)

      FormateGrillaCampos()

      Me.LimpiarCamposProductos()
      Me.CalcularTotales()

      grbMovimientoOrigen.Enabled = False
      grbMovimientoDestino.Enabled = False
      'grbDestinoDepositoUbicacion.Enabled = grbMovimientoDestino.Enabled

      Me.tsbGrabar.Enabled = True
      Me.bscCodigoProducto2.Focus()
      Me._vieneDelDobleClick = False
      '--REQ-34747.- --------------------------------
      InicializaAtributos()
      '---------------------------------------------
   End Sub
   Private Sub FormateGrillaCampos()

      Dim pos As Integer = 0
      ugProductos.DataSource = _productos.ToArray()
      ugProductos.UpdateData()

      With ugProductos.DisplayLayout.Bands(0)
         _publicos.OcultaColumnas(ugProductos)

         .Columns("IdProducto").FormatearColumna("Codigo", pos, 100, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Descripción", pos, 300, HAlign.Left)

         .Columns("NombreDeposito").FormatearColumna("Deposito", pos, 80, HAlign.Left)
         .Columns("IdUbicacion").FormatearColumna("Ubicación", pos, 80, HAlign.Left, hidden:=True)
         .Columns("NombreUbicacion").FormatearColumna("Ubicación", pos, 80, HAlign.Left)

         .Columns("Cantidad").FormatearColumna("Cantidad", pos, 80, HAlign.Right)
         .Columns("Precio").FormatearColumna("Precio", pos, 80, HAlign.Right)
         .Columns("Stock").FormatearColumna("Stock", pos, 80, HAlign.Right)
         .Columns("importeTotal").FormatearColumna("Importe", pos, 80, HAlign.Right)
         .Columns("TotalProducto").FormatearColumna("Total", pos, 80, HAlign.Right)

         '---------------------------------------------------------------------
         .Columns("DescripcionAtributo01").Hidden = Not (_productos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0)
         .Columns("DescripcionAtributo02").Hidden = Not (_productos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0)
         .Columns("DescripcionAtributo03").Hidden = Not (_productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0)
         .Columns("DescripcionAtributo04").Hidden = Not (_productos.MaxSecure(Function(p) p.IdaAtributoProducto04).IfNull() > 0)
         '---------------------------------------------------------------------
         .Columns("NombreSucursal2").FormatearColumna("Suc.Destino", pos, 80, HAlign.Left)
         .Columns("NombreSucursal2").Hidden = Not grbMovimientoDestino.Visible
         .Columns("NombreDeposito2").FormatearColumna("Dep.Destino", pos, 80, HAlign.Left)
         .Columns("NombreDeposito2").Hidden = Not grbMovimientoDestino.Visible
         .Columns("IdUbicacion2").FormatearColumna("Ubi.Destino", pos, 80, HAlign.Left, hidden:=True)
         .Columns("NombreUbicacion2").FormatearColumna("Ubi.Destino", pos, 80, HAlign.Left, Not grbMovimientoDestino.Visible)
         '---------------------------------------------------------------------
         .Columns("CantidadAfectada").Hidden = Not cmbCantidadAfectada.Visible

         If Reglas.Publicos.VisualizaLote Then
            .Columns("IdLote").Hidden = True
            .Columns("VtoLote").Hidden = True
         End If

         If Reglas.Publicos.VisualizaNrosSerie Then
            .Columns("NrosSerie").Hidden = True
         End If
      End With

   End Sub

   Private Sub InicializaAtributos()
      MovAtributo01.IdaAtributoProducto = 0
      MovAtributo02.IdaAtributoProducto = 0
      MovAtributo03.IdaAtributoProducto = 0
      MovAtributo04.IdaAtributoProducto = 0
   End Sub
   Private Sub EliminarLineaProducto()

      _productos.RemoveAt(ugProductos.ActiveRow.Index)

      If ugProductos.ActiveRow.Cells("IdLote").Value IsNot Nothing Then
         Me.EliminarProductoLote(ugProductos.ActiveRow.Cells("IdLote").Value.ToString(),
                     Integer.Parse(ugProductos.ActiveRow.Cells("IdSucursal").Value.ToString()),
                     ugProductos.ActiveRow.Cells("IdProducto").Value.ToString())
      End If
      If ugProductos.ActiveRow.Cells("IdProducto").Value IsNot Nothing Then
         Dim colAux = New List(Of Entidades.ProductoNroSerie)()
         For Each nroSerie As Entidades.ProductoNroSerie In _productosNrosSeries
            If nroSerie.Producto.IdProducto = ugProductos.ActiveRow.Cells("IdProducto").Value.ToString() Then
               For Each nroSerie2 As Entidades.ProductoNroSerie In Me._editarNrosSeries
                  If nroSerie.NroSerie = nroSerie2.NroSerie Then
                     colAux.Add(nroSerie)
                  End If
               Next
            End If
         Next
         For Each nro As Entidades.ProductoNroSerie In colAux
            Me._productosNrosSeries.Remove(nro)
         Next
      End If
      '----------------------------------------------------------------------------------------------------------------
      FormateGrillaCampos()
      '----------------------------------------------------------------------------------------------------------------
      grbMovimientoDestino.Enabled = (Not _productos.Count > 0)
      'grbDestinoDepositoUbicacion.Enabled = (Not _productos.Count > 0)
      CalcularTotales()
   End Sub

   Private Sub EliminarProductoLote(idLote As String, idSucursal As Integer, idProducto As String)
      Dim pl As Entidades.ProductoLote
      For i As Integer = 0 To Me._productosLotes.Count - 1
         pl = Me._productosLotes(i)
         If pl.IdLote = idLote And pl.ProductoSucursal.Sucursal.IdSucursal = idSucursal And pl.ProductoSucursal.Producto.IdProducto = idProducto Then
            Me._productosLotes.Remove(pl)
            Exit For
         End If
      Next
   End Sub

   Private Sub DeshabilitarControles()
      ugProductos.Enabled = False

      bscCodigoProveedor.Enabled = False
      bscProveedor.Enabled = False

      cmbEmpleado.Enabled = False

      txtObservacion.Enabled = False

      bscCodigoProducto2.Enabled = False
      bscProducto2.Enabled = False
      txtCantidad.Enabled = False
      txtPrecio.Enabled = False

      btnInsertar.Enabled = False
      btnEliminar.Enabled = False
      tsbInvocarComprobantes.Enabled = False
      tsbGrabar.Enabled = False
      tsbLeerArchivo.Enabled = False

      grbMovimientoDestino.Enabled = True
      grbDestinoDepositoUbicacion.Enabled = grbMovimientoDestino.Enabled
   End Sub

   Private Sub CargarDatosProveedor(FilaDevuelta As DataGridViewRow)

      bscCodigoProveedor.Text = FilaDevuelta.Cells("CodigoProveedor").Value.ToString
      bscCodigoProveedor.Tag = FilaDevuelta.Cells("IdProveedor").Value.ToString
      bscProveedor.Text = FilaDevuelta.Cells("NombreProveedor").Value.ToString

      If IsDBNull(FilaDevuelta.Cells("idCategoriaFiscal").Value) Then
         idCategoriaFiscal = 0
      Else
         idCategoriaFiscal = Convert.ToInt16(FilaDevuelta.Cells("idCategoriaFiscal").Value)
      End If

      If FilaDevuelta.Cells("NombreCategoriaFiscal").Value Is System.DBNull.Value Then
         txtCategoriaFiscal.Text = "Sin Categoria"
      Else
         txtCategoriaFiscal.Text = FilaDevuelta.Cells("NombreCategoriaFiscal").Value.ToString
      End If

      bscCodigoProveedor.Enabled = False
      bscProveedor.Enabled = False

      'Me.bscCodigoProducto2.Enabled = True
      'Me.bscProducto2.Enabled = True
      'Me.txtCantidad.Enabled = True
      'Me.txtPrecio.Enabled = True
      'Me.txtPorDescuento.Enabled = True

      Dim o = New Reglas.Proveedores()
      _proveedor = o.GetUno(Long.Parse(bscCodigoProveedor.Tag.ToString()))

   End Sub

   Private Sub HabilitarSucursal()
      If cboTipoMovimiento.SelectedIndex <> -1 Then
         grbMovimientoDestino.Visible = cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).AsociaSucursal
         grbDestinoDepositoUbicacion.Visible = grbMovimientoDestino.Visible

         If grbMovimientoDestino.Visible Then
            cmbSucursalDestino.SelectedIndex = 0
         End If
         lblUbicacionDestino.Visible = grbMovimientoDestino.Visible
         cmbUbicacionDestino.Visible = grbMovimientoDestino.Visible
      End If
   End Sub

   Private Sub HabilitarEmpleado()
      If cboTipoMovimiento.SelectedIndex <> -1 Then
         cmbEmpleado.Enabled = cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).HabilitaEmpleado
         lblEmpleado.Enabled = cmbEmpleado.Visible
      End If
   End Sub

   Private Sub HabilitarDestinatario()
      Dim habilita As Boolean = False
      If cboTipoMovimiento.SelectedIndex <> -1 Then
         habilita = cboTipoMovimiento.ItemSeleccionado(Of Entidades.TipoMovimiento).HabilitaDestinatario
      End If

      bscCodigoProveedor.FilaDevuelta = Nothing
      bscCodigoProveedor.Text = ""
      bscCodigoProveedor.Tag = Nothing
      bscCodigoProveedor.Enabled = habilita

      bscProveedor.FilaDevuelta = Nothing
      bscProveedor.Text = ""
      bscProveedor.Enabled = habilita
   End Sub

   Private Sub LimpiarDetalle()
      _productos.Clear()
      ugProductos.DataSource = _productos.ToArray()
      LimpiarCamposProductos()
      txtTotalGeneral.Text = "0.00"
   End Sub

   Private Sub CargarProductosFacturables(selec As List(Of Entidades.Compra))
      'limpio todos los productos de la grilla
      _productos = Nothing
      _productos = New List(Of Entidades.MovimientoStockProducto)()

      For Each v As Entidades.Compra In selec
         For Each vp In v.ComprasProductos
            If vp.IdDeposito > 0 Then
               cmbDepositoOrigen.SelectedValue = vp.IdDeposito
               cmbUbicacionOrigen.SelectedValue = vp.IdUbicacion
            End If
            bscCodigoProducto2.Text = vp.Producto.IdProducto
            bscCodigoProducto2.PresionarBoton()
            txtCantidad.Text = vp.Cantidad.ToString()
            CalcularTotalProducto()
            btnInsertar.PerformClick()
         Next
      Next

      tsbGrabar.Enabled = True
   End Sub

   Private Function GetCodigoModalidadPeso() As String
      If _codigoBarrasCompleto.Length = 13 Then
         Dim num As Integer = 0
         Integer.TryParse(_codigoBarrasCompleto.Substring(0, 7), num)
         Return num.ToString()
      Else
         Return _codigoBarrasCompleto
      End If
   End Function

   Private Function GetPrecioModalidadPrecio() As Decimal
      If _codigoBarrasCompleto.Length = 13 Then
         Return Decimal.Parse(_codigoBarrasCompleto.Substring(7, 5).Insert(3, "."))
      Else
         Return 0
      End If
   End Function

   Private Function GetPrecioModalidadPeso() As Decimal
      If _codigoBarrasCompleto.Length = 13 Then
         Return Decimal.Parse(_codigoBarrasCompleto.Substring(7, 5).Insert(2, "."))
      Else
         Return 0
      End If
   End Function

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositoOrigen.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            depOrigen = dr.Field(Of Integer)("IdDeposito")
            sucOrigen = dr.Field(Of Integer)("IdSucursal")
            _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, depOrigen, sucOrigen)
            '_publicos.CargaComboUbicaciones(cmbUbiOrig, depOrigen, sucOrigen)
            cmbUbicacionOrigen.SelectedIndex = 0
         End If
      End Sub)
   End Sub

   Private Sub cmbSucursalDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursalDestino.SelectedIndexChanged
      If Not _cargaComboDestino Then
         sucDestino = Integer.Parse(cmbSucursalDestino.SelectedValue.ToString())
         _cargaComboDestino = True
         _publicos.CargaComboDepositos(cmbDepositoDestino, sucDestino, True, True, Entidades.Publicos.SiNoTodos.TODOS)
         _cargaComboDestino = False
         If cmbDepositoDestino.Items.Count > 0 Then
            cmbDepositoDestino.SelectedIndex = 0
         Else
            MessageBox.Show(String.Format("El usuario no posee depositos autorizados para la sucursal ({0})", cmbSucursalDestino.Text), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If
      End If
   End Sub
   Private Sub cmbDepositoDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoDestino.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositoDestino.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            depDestino = dr.Field(Of Integer)("IdDeposito")
            sucDestino = dr.Field(Of Integer)("IdSucursal")
            _publicos.CargaComboUbicaciones(cmbUbicacionDestino, depDestino, sucDestino)
            '_publicos.CargaComboUbicaciones(cmbUbiDest, depDestino, sucDestino)
            cmbUbicacionDestino.SelectedIndex = 0
         End If
      End Sub)
   End Sub

   Private Sub cmbUbicacionOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionOrigen.SelectedIndexChanged
      If Not _cargaComboDestino Then
         ubiOrigen = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
         Dim dt = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(sucOrigen, depOrigen, ubiOrigen, bscCodigoProducto2.Text())
         If dt.Count <> 0 Then
            txtStock.Text = dt.Rows(0).Field(Of Decimal)("Stock").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
            txtStock2.Text = dt.Rows(0).Field(Of Decimal)("Stock2").ToString(String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesRedondeoEnCantidad))
         End If
      End If

   End Sub

   Private Sub cmbUbicacionDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUbicacionDestino.SelectedIndexChanged
      If cmbUbicacionDestino.SelectedValue.ToString() = Nothing Then
         ubiDestino = 0
      Else
         ubiDestino = Integer.Parse(cmbUbicacionDestino.SelectedValue.ToString())
      End If

   End Sub

   Private Sub ugProductos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugProductos.DoubleClickCell
      TryCatched(
      Sub()
         'limpia los textbox, y demas controles
         LimpiarCamposProductos()
         flackCargaProductos = False
         'carga el producto seleccionado de la grilla en los textbox 
         CargarProductoCompletos(ugProductos.FilaSeleccionada(Of Entidades.MovimientoStockProducto)(e.Cell.Row))
         flackCargaProductos = True
         'elimina el producto de la grilla
         EliminarLineaProducto()
         'hace foco en la cantidad
         txtCantidad.Focus()
         txtCantidad.SelectAll()
         _vieneDelDobleClick = True
      End Sub)
   End Sub

   Private Sub CargarProductoCompletos(dr As Entidades.MovimientoStockProducto)

      Dim oProductos = New Reglas.Productos()

      bscCodigoProducto2.Text = dr.IdProducto.ToString()
      bscCodigoProducto2.Datos = oProductos.GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      bscCodigoProducto2.PresionarBoton()
      bscCodigoProducto2.Enabled = False

      bscProducto2.Enabled = False
      _editarNrosSeries = dr.ProductoSucursal.Producto.NrosSeries

      txtCantidad.Text = dr.CantidadParaGrillas.ToString()

      cmbCantidadAfectada.SelectedValue = dr.CantidadAfectada

      txtPrecio.Text = Decimal.Round(Decimal.Parse(dr.Precio.ToString()), 2).ToString("N2")
      txtTotalProducto.Text = dr.ImporteTotal.ToString()

      cmbDepositoOrigen.SelectedValue = dr.IdDeposito
      cmbUbicacionOrigen.SelectedValue = dr.IdUbicacion

      cmbDepositoDestino.SelectedValue = dr.IdDeposito2
      cmbUbicacionDestino.SelectedValue = dr.IdUbicacion2

      With MovAtributo01
         .IdaAtributoProducto = Integer.Parse(dr.IdaAtributoProducto01.ToString())
         If dr.DescripcionAtributo01 IsNot Nothing Then
            .Descripcion = dr.DescripcionAtributo01.ToString()
         End If
      End With
      With MovAtributo02
         .IdaAtributoProducto = Integer.Parse(dr.IdaAtributoProducto02.ToString())
         If dr.DescripcionAtributo02 IsNot Nothing Then
            .Descripcion = dr.DescripcionAtributo02.ToString()
         End If
      End With
      With MovAtributo03
         .IdaAtributoProducto = Integer.Parse(dr.IdaAtributoProducto03.ToString())
         If dr.DescripcionAtributo03 IsNot Nothing Then
            .Descripcion = dr.DescripcionAtributo03.ToString()
         End If
      End With
      With MovAtributo04
         .IdaAtributoProducto = Integer.Parse(dr.IdaAtributoProducto04.ToString())
         If dr.DescripcionAtributo04 IsNot Nothing Then
            .Descripcion = dr.DescripcionAtributo04.ToString()
         End If
      End With

   End Sub

   Private Sub ugProductos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles ugProductos.ClickCell
      TryCatched(
         Sub()
            If ugProductos.Rows.Count = 0 Then Exit Sub
            If ugProductos.ActiveRow.ListObject Is Nothing Then Exit Sub

            'If dgvProductos.Columns(e.ColumnIndex).Name = "NrosSerie" Then
            '   If e.RowIndex <> -1 Then
            '      If DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries.Count > 0 Then

            '         Dim cantidadDeProductos As Integer = DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto.NrosSeries.Count

            '         Dim Ver As Boolean = True

            '         Dim ins As IngresoNumerosSerie = New IngresoNumerosSerie(cantidadDeProductos, DirectCast(DirectCast(Me.dgvProductos.SelectedRows(0), DataGridViewRow).DataBoundItem, Entidades.MovimientoStockProducto).ProductoSucursal.Producto, _productosNrosSeries, Ver)
            '         ins.ShowDialog()
            '      Else
            '         MessageBox.Show("El producto no tiene definido numero de serie", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '      End If
            '   End If
            'End If
         End Sub)
   End Sub

   Private Sub MovimientosDeStock_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      If Not _cargoBienLaPantalla Then
         MessageBox.Show(_mensajeDeErrorEnCarga, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

         Close()
      End If
   End Sub

   Private Sub ugProductos_CellChange(sender As Object, e As CellEventArgs) Handles ugProductos.CellChange
      ugProductos.UpdateData()
   End Sub

#End Region

End Class
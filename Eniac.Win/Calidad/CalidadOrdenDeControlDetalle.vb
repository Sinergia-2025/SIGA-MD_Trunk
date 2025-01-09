Public Class CalidadOrdenDeControlDetalle

   Private ReadOnly Property OrdenControl As Entidades.CalidadOrdenDeControl
      Get
         Return DirectCast(_entidad, Entidades.CalidadOrdenDeControl)
      End Get
   End Property

#Region "Campos"
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CalidadOrdenDeControl)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos()
      TryCatched(
      Sub()
         If OrdenControl.IdSucursal = 0 Then
            OrdenControl.IdSucursal = actual.Sucursal.Id
         End If

         '-- Carga Estados de OrdenesCalidad.- ---------------------
         _publicos.CargaComboEstadosOrdenCalidad(cmbEstadosOrdenes)
         _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, True, Entidades.TipoComprobante.Tipos.CALIDAD.ToString())

         If cmbTiposComprobantes.Items.Count = 0 Then
            Throw New Exception("No Existe la PC en Configuraciones/Impresoras")
         End If


         _publicos.CargaComboEstadosOrdenCalidad(cmbEstadosOrdenes)

         _publicos.CargaComboDepositos(cmbDeposito, OrdenControl.IdSucursal, miraUsuario:=False, permiteEscritura:=False)

         _liSources.Add("EstadoCalidad", OrdenControl.EstadoCalidad)

         BindearControles(_entidad, _liSources)

         If StateForm = StateForm.Insertar Then
            OrdenControl.IdSucursal = OrdenControl.IdSucursal

            cmbTiposComprobantes.SelectedIndex = 0
            dtpFecha.Value = Date.Today
            cmbEstadosOrdenes.SelectedIndex = 0

            cmbEstadosOrdenes.Enabled = False

            pnlUsuarios.Visible = False

            bscCodigoProducto.Select()
         Else
            lblNumeroPosible.Text = "Número"

            bscCodigoProducto.Text = OrdenControl.IdProducto
            bscCodigoProducto.PresionarBoton()

            If OrdenControl.IdProveedor.HasValue Then
               txtProveedorComprobanteCompra.Tag = OrdenControl.IdProveedor.IfNull()
               txtProveedorComprobanteCompra.Text = New Reglas.Proveedores().GetUno(OrdenControl.IdProveedor.IfNull()).NombreProveedor
               txtCantidadControlar.ReadOnly = True
            End If

            If OrdenControl.IdDeposito.HasValue Then
               cmbDeposito.SelectedValue = OrdenControl.IdDeposito.IfNull()
            End If
            If OrdenControl.IdUbicacion.HasValue Then
               cmbUbicacion.SelectedValue = OrdenControl.IdUbicacion.IfNull()
            End If
            If Not String.IsNullOrWhiteSpace(OrdenControl.IdLote) Then
               bscLote.Text = OrdenControl.IdLote
               bscLote.PresionarBoton()
            End If

            cmbTiposComprobantes.Enabled = False
            bscCodigoProducto.Permitido = False
            bscNombreProducto.Permitido = False

            btnLimpiarComprobantesCompras.Enabled = False
            btnComprobantesCompras.Enabled = False

            cmbDeposito.Enabled = False
            cmbUbicacion.Enabled = False
            bscLote.Permitido = False

            cmbEstadosOrdenes.Select()
         End If

         SetListaControlItemsDataSource()

         _estaCargando = False
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadOrdenDeControl()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function
   Protected Overrides Sub Aceptar()
      '-- Proceso de Orden de Control de Calidad.- --------------------------
      If cmbDeposito.SelectedIndex < 0 Then
         OrdenControl.IdDeposito = Nothing
      Else
         OrdenControl.IdDeposito = cmbDeposito.ValorSeleccionado(0I)
      End If

      If cmbUbicacion.SelectedIndex < 0 Then
         OrdenControl.IdUbicacion = Nothing
      Else
         OrdenControl.IdUbicacion = cmbUbicacion.ValorSeleccionado(0I)
      End If

      OrdenControl.IdLote = bscLote.Text

      If txtProveedorComprobanteCompra.Tag IsNot Nothing Then
         OrdenControl.IdProveedor = Long.Parse(txtProveedorComprobanteCompra.Tag.ToString())
      Else
         OrdenControl.IdProveedor = Nothing
      End If

      '-- Aceptar de Base.- -------------------------------------------------
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"
#Region "Eventos Busqueda Productos"
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), OrdenControl.IdSucursal, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscNombreProducto_BuscadorClick() Handles bscNombreProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProducto)
         bscNombreProducto.Datos = New Reglas.Productos().GetPorNombre(bscNombreProducto.Text.Trim(), OrdenControl.IdSucursal, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscNombreProducto.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub cmbTiposComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantes.SelectedIndexChanged
      TryCatched(
      Sub()
         If StateForm = StateForm.Insertar Then
            ProximoNumeroPosible()
         End If
      End Sub)
   End Sub
   Private Sub cmbDeposito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeposito.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim dr = cmbDeposito.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            Dim idDeposito = dr.Field(Of Integer)("IdDeposito")
            _publicos.CargaComboUbicaciones(cmbUbicacion, idDeposito, OrdenControl.IdSucursal)
            cmbUbicacion.SelectedIndex = 0
         End If
      End Sub)
   End Sub
#Region "Eventos Busqueda Lotes"
   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLotes(bscLote)
         bscLote.Datos = New Reglas.ProductosLotes().GetPorProducto(OrdenControl.IdSucursal, cmbDeposito.ValorSeleccionado(0I), cmbUbicacion.ValorSeleccionado(0I),
                                                                    bscCodigoProducto.Text, bscLote.Text)
      End Sub)
   End Sub
   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      TryCatched(Sub() CargarLote(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub btnLimpiarComprobantesCompras_Click(sender As Object, e As EventArgs) Handles btnLimpiarComprobantesCompras.Click
      TryCatched(
      Sub()
         txtCantidadControlar.ReadOnly = False
         bscCodigoProducto.Permitido = True
         bscNombreProducto.Permitido = True
         cmbDeposito.Enabled = True
         cmbUbicacion.Enabled = True
         bscLote.Permitido = True

         txtIdSucursalCompra.Text = String.Empty
         txtTipoComprobanteCompra.Text = String.Empty
         txtLetraComprobanteCompra.Text = String.Empty
         txtEmisorComprobanteCompra.Text = String.Empty
         txtNumeroComprobanteCompra.Text = String.Empty
         txtOrdenComprobanteCompra.Text = String.Empty

         '-- Proveedor.-
         txtProveedorComprobanteCompra.Text = String.Empty
         txtProveedorComprobanteCompra.Tag = Nothing

         OrdenControl.IdSucursalCompra = Nothing
         OrdenControl.IdTipoComprobanteCompra = String.Empty
         OrdenControl.LetraCompra = String.Empty
         OrdenControl.CentroEmisorCompra = Nothing
         OrdenControl.NumeroComprobanteCompra = Nothing
         OrdenControl.OrdenComprobanteCompra = Nothing

         bscCodigoProducto.PresionarBoton()

      End Sub)
   End Sub
   Private Sub btnComprobantesCompras_Click(sender As Object, e As EventArgs) Handles btnComprobantesCompras.Click
      TryCatched(Sub() InvocarComprobanteCompras())
   End Sub

   Private Sub txtCantidadComprobanteCompra_Leave(sender As Object, e As EventArgs) Handles txtCantidadControlar.Leave
      TryCatched(Sub() ReCalculaValoresAQL())
   End Sub
   Private Sub txtCantidadComprobanteCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadControlar.KeyPress
      'TryCatched(
      'Sub()
      '   If e.KeyChar = Convert.ToChar(Keys.Enter) Then
      '      ReCalculaValoresAQL()
      '      txtObservaciones.Focus()
      '   End If
      'End Sub)
   End Sub
   Private Sub txtCantidadControlar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadControlar.KeyDown, cmbUbicacion.KeyDown, cmbDeposito.KeyDown
      PresionarTab(e)
   End Sub
#End Region

#Region "Metodos"
   Private Sub ProximoNumeroPosible()
      '-- Letra - Centro.- ---------------------------------- 
      Dim tipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)
      If tipoComprobante IsNot Nothing Then
         txtLetra.Text = tipoComprobante.LetrasHabilitadas
         Dim oImpresoras = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(OrdenControl.IdSucursal, My.Computer.Name, tipoComprobante.IdTipoComprobante)
         txtEmisor.Text = oImpresoras.CentroEmisor.ToString()
         '-- Numero Posible.- ----------------------------------
         txtNumeroPosible.Text = New Reglas.CalidadOrdenDeControl().GetUltimoNumeroComprobante(tipoComprobante.IdTipoComprobante, tipoComprobante.LetrasHabilitadas, oImpresoras.CentroEmisor).ToString()
      End If
   End Sub
   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim producto = New Reglas.Productos().GetUnoParaM(dr.Cells("IdProducto").Value.ToString().Trim())

         '-- Carga datos de Buscador.- -----------------------------------------
         bscCodigoProducto.Text = producto.IdProducto
         bscNombreProducto.Text = producto.NombreProducto

         OrdenControl.IdProducto = producto.IdProducto

         '-- Activa Boton de Comprobantes.- ------------------------------------
         If StateForm = StateForm.Insertar Then
            'TODO: Volver. El deposito podría estar cambiando el deposito seleccionado. Quizas poner un par de combos en la pantalla.
            If producto.Lote Then
               cmbDeposito.SelectedValue = producto.IdDepositoDefecto
               cmbUbicacion.SelectedValue = producto.IdUbicacionDefecto
               bscLote.Text = String.Empty

               cmbDeposito.Enabled = True
               cmbUbicacion.Enabled = True
               bscLote.Permitido = True
            Else
               cmbDeposito.Enabled = False
               cmbUbicacion.Enabled = False
               bscLote.Permitido = False
            End If

            '-- Carga las listas - Items del Producto.- ---------------------------
            CargaListaControlItemsDelProducto()
         End If
         '-- Posicional el cursor.- --------------------------------------------
         txtCantidadControlar.Focus()
      End If
   End Sub
   Private Sub CargarLote(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscLote.Text = dr.Cells("IdLote").Value.ToString()
         txtObservaciones.Focus()
      End If
   End Sub

   Private Sub CargaListaControlItemsDelProducto()
      Dim rListaControlItems = New Reglas.CalidadOrdenDeControlItems()

      'Limpio la Grilla.- -----------------------------------------------------------------------------------------
      ugListaControlItems.ClearFilas()
      '-- Recalcula Valores AQL.- ---------------------------------------------------------------------------------
      rListaControlItems.CargaListaControlItemsDelProducto(OrdenControl.CalidadOrdenDeControlItems, bscCodigoProducto.Text())
      '-- Recalcula Valores AQL.- ---------------------------------------------------------------------------------
      ReCalculaValoresAQL()
      ugListaControlItems.RowsRefresh(RefreshRow.FireInitializeRow)
   End Sub
   Private Sub ReCalculaValoresAQL()
      If bscCodigoProducto.Selecciono Or bscNombreProducto.Selecciono Then
         Dim rItems = New Reglas.CalidadOrdenDeControlItems()
         Dim errBuilder = rItems.CalculaCantidadesListaControlItems(OrdenControl.CalidadOrdenDeControlItems, txtCantidadControlar.ValorNumericoPorDefecto(0D))

         If errBuilder.AnyError Then
            ShowMessage(errBuilder.ErrorToString())
            btnAceptar.Enabled = False
         Else
            btnAceptar.Enabled = True
         End If
         '-- Refresca Datos de Grilla.- ------------------------------------------------------------------------------
         ugListaControlItems.RowsRefresh(RefreshRow.FireInitializeRow)
      End If
   End Sub

   Private Sub SetListaControlItemsDataSource()
      Dim _titListaControlItems = GetColumnasVisiblesGrilla(ugListaControlItems)
      ugListaControlItems.DataSource = OrdenControl.CalidadOrdenDeControlItems
      AjustarColumnasGrilla(ugListaControlItems, _titListaControlItems)

      ugListaControlItems.AgregarFiltroEnLinea({"NombreListaControl", "NombreListaControlItem"})
   End Sub

   Private Sub InvocarComprobanteCompras()
      Dim producto As Entidades.ProductoLivianoParaImportarProducto = Nothing
      If bscCodigoProducto.Selecciono Or bscNombreProducto.Selecciono Then
         producto = New Reglas.Productos().GetUnoParaM(bscCodigoProducto.Text)
      ElseIf Not String.IsNullOrWhiteSpace(bscCodigoProducto.Text) Then
         ShowMessage("Seleccione un producto o deje el código de producto en blanco")
         Exit Sub
      End If

      Using frm = New CalidadOrdenDeControlComprobantesCompras()
         If frm.ShowDialog(Me, cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante), txtLetra.Text, txtEmisor.ValorNumericoPorDefecto(0I),
                           txtNumeroPosible.ValorNumericoPorDefecto(0L), producto,
                           cmbEstadosOrdenes.ItemSeleccionado(Of Entidades.EstadoOrdenCalidad), dtpFecha.Value) = DialogResult.OK Then

            txtIdSucursalCompra.Text = frm.DataCC.Field(Of Integer)("IdSucursalCompra").ToString()
            OrdenControl.IdSucursalCompra = frm.DataCC.Field(Of Integer)("IdSucursalCompra")

            txtTipoComprobanteCompra.Text = frm.DataCC.Field(Of String)("IdTipoComprobanteCompra")
            txtLetraComprobanteCompra.Text = frm.DataCC.Field(Of String)("LetraCompra")
            txtEmisorComprobanteCompra.Text = frm.DataCC.Field(Of Integer)("CentroEmisorCompra").ToString()
            txtNumeroComprobanteCompra.Text = frm.DataCC.Field(Of Long)("NumeroComprobanteCompra").ToString()
            txtOrdenComprobanteCompra.Text = frm.DataCC.Field(Of Integer)("OrdenComprobanteCompra").ToString()

            '-- Proveedor.-
            txtProveedorComprobanteCompra.Text = frm.DataCC.Field(Of String)("NombreProveedor")
            txtProveedorComprobanteCompra.Tag = frm.DataCC.Field(Of Long)("IdProveedor")

            If producto Is Nothing Then
               bscCodigoProducto.Text = frm.DataCC.Field(Of String)("IdProducto")
               bscCodigoProducto.PresionarBoton()
               producto = New Reglas.Productos().GetUnoParaM(bscCodigoProducto.Text)
            End If

            If producto.Lote Then
               '-- Deposito.- 
               cmbDeposito.SelectedValue = frm.DataCC.Field(Of Integer)("IdDeposito")
               cmbUbicacion.SelectedValue = frm.DataCC.Field(Of Integer)("IdUbicacion")

               bscLote.Text = frm.DataCC.Field(Of String)("IdLote")
               bscLote.PresionarBoton()
            Else
               cmbDeposito.SelectedIndex = -1
               cmbUbicacion.SelectedIndex = -1

               bscLote.Text = String.Empty
            End If

            cmbDeposito.Enabled = False
            cmbUbicacion.Enabled = False
            bscLote.Permitido = False
            bscCodigoProducto.Permitido = False
            bscNombreProducto.Permitido = False
            txtCantidadControlar.ReadOnly = True

            txtCantidadControlar.SetValor(frm.DataCC.Field(Of Decimal)("Cantidad"))

         End If
      End Using
      '-- Recalcula lso valores AQL.- ---------------------------
      ReCalculaValoresAQL()
      txtObservaciones.Focus()
   End Sub

#End Region

End Class
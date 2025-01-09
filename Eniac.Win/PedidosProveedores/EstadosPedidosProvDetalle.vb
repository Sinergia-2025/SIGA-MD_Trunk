Public Class EstadosPedidosProvDetalle
   Implements IConParametros

   Private ReadOnly Property EstadoProveedor As Entidades.EstadoPedidoProveedor
      Get
         Return DirectCast(_entidad, Entidades.EstadoPedidoProveedor)
      End Get
   End Property

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String
   Private _tipoTipoComprobanteParaCombo As String
   Private _tipoTipoComprobanteParaCombo2 As String
   Private _parametros As String

   Private _titRoles As Dictionary(Of String, String)
   Private _titEstadosRoles As Dictionary(Of String, String)

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.EstadoPedidoProveedor)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"
         If String.IsNullOrWhiteSpace(_tipoTipoComprobanteParaCombo) AndAlso String.IsNullOrWhiteSpace(_tipoTipoComprobanteParaCombo2) Then _tipoTipoComprobanteParaCombo2 = ""
         If String.IsNullOrWhiteSpace(_tipoTipoComprobanteParaCombo) Then _tipoTipoComprobanteParaCombo = "COMPRAS"

         _publicos.CargaComboTiposEstadosPedidosProv(Me.cmbTiposEstados, _tipoTipoComprobante)
         _publicos.CargaComboEstadosPedidos(cmbIdEstadoPedido, False, False, False, False, False, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())

         _publicos.CargaComboTiposComprobantes(cmbComprobantes, False, _tipoTipoComprobanteParaCombo, _tipoTipoComprobanteParaCombo2, , , True)
         ' Me.cmbComprobantes.SelectedIndex = 0

         _publicos.CargaComboEstadosPedidosProv(cmbIdEstadoDestino, False, False, False, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
         _publicos.CargaComboEstadosPedidosProv(cmbIdEstadoFacturado, False, False, False, False, False, _tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.TODOS)

         _publicos.CargaComboTiposMovimientos(cmbTipoMovimiento)
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
         _publicos.CargaComboDesdeEnum(cmbStockAfectado, lstCantidadAfectada.ToArray())


         BindearControles(_entidad)

         _titRoles = GetColumnasVisiblesGrilla(ugRoles)
         ugRoles.DataSource = New Reglas.Roles().GetTodos()
         AjustarColumnasGrilla(ugRoles, _titRoles)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarValoresIniciales()
            AddRoles(ugRoles.DataSource(Of List(Of Entidades.Rol)), EstadoProveedor.Roles)
         Else
            txtColor.BackColor = Color.FromArgb(EstadoProveedor.Color)
            'If DirectCast(Me._entidad, Entidades.EstadoPedidoProveedor).StockAfectado.HasValue Then
            '   cmbStockAfectado.SelectedValue = DirectCast(Me._entidad, Entidades.EstadoPedidoProveedor).StockAfectado.Value
            'End If
         End If

         _titEstadosRoles = GetColumnasVisiblesGrilla(ugEstadosRoles)
         ugEstadosRoles.DataSource = EstadoProveedor.Roles
         AjustarColumnasGrilla(ugEstadosRoles, _titEstadosRoles)

         cmbStockAfectado.Enabled = cmbTipoMovimiento.SelectedIndex > -1
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosPedidosProveedores()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If cmbTipoMovimiento.SelectedIndex > -1 And cmbStockAfectado.SelectedIndex = -1 Then
         Return "ATENCION: Si selecciona un Tipo de Movimiento Debe seleccionar un Stock a Afectar."
         Me.cmbStockAfectado.Focus()
      End If

      'If _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString() Then
      '   If Me.cmbComprobantes.SelectedIndex > -1 Then
      '      If DirectCast(cmbComprobantes.SelectedItem, Entidades.TipoComprobante).Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() Then
      '         If Publicos.PedidosPendientesFacturaAutomaticamente Then
      '            Return "ATENCION: No puede seleccionar un Comprobante porque esta activo el Parametro de Facturación Automática"
      '            Me.cmbComprobantes.Focus()
      '         End If
      '      End If
      '   End If
      'End If         'If _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString() Then

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      EstadoProveedor.IdTipoEstado = cmbTiposEstados.Text
      EstadoProveedor.TipoEstadoPedidoCliente = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString()
      MyBase.Aceptar()
   End Sub

#Region "Eventos Roles"
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(
      Sub()
         Dim drs = ugRoles.FilasSeleccionadas(Of Entidades.Rol)()
         Dim estadosRoles = ugEstadosRoles.DataSource(Of List(Of Entidades.EstadoPedidoProveedorRol))
         AddRoles(drs, estadosRoles)
      End Sub)
   End Sub

   Private Sub AddRoles(drs As IEnumerable(Of Entidades.Rol), estadosRoles As List(Of Entidades.EstadoPedidoProveedorRol))
      If drs.AnySecure() AndAlso estadosRoles IsNot Nothing Then
         estadosRoles.AddRange(drs.Where(Function(dr) Not estadosRoles.Exists(Function(dr1) dr1.IdRol = dr.Id)).ToList().
                               ConvertAll(Function(dr) New Entidades.EstadoPedidoProveedorRol() With
                               {
                                  .Rol = dr,
                                  .PermitirEscritura = ChbPermitirEscritura.Checked
                               }))
         ugEstadosRoles.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub

   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      TryCatched(
      Sub()
         Dim drs = ugEstadosRoles.FilasSeleccionadas(Of Entidades.EstadoPedidoProveedorRol)
         Dim estadosRoles = ugEstadosRoles.DataSource(Of List(Of Entidades.EstadoPedidoProveedorRol))
         If drs.AnySecure() Then
            If ShowPregunta("¿Desea eliminar los roles seleccionados del estado?") = DialogResult.Yes Then
               estadosRoles.RemoveRange(drs)
               ugEstadosRoles.Rows.Refresh(RefreshRow.ReloadData)
            End If
         End If
      End Sub)
   End Sub
#End Region

#End Region

#Region "Eventos"

   Private Sub btnLimpiarTamaño_Click(sender As Object, e As EventArgs) Handles btnLimpiarTamaño.Click
      Me.cmbComprobantes.SelectedIndex = -1
      'DirectCast(Me._entidad, Entidades.EstadoPedidoProveedor).idTipoComprobante = String.Empty
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarValoresIniciales()
      'End If
      ' Me.txtIdPlanCuenta.Focus()
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      TryCatched(
      Sub()
         cdColor.Color = txtColor.BackColor
         If cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtColor.Key = cdColor.Color.ToArgb().ToString()
            DirectCast(_entidad, Entidades.EstadoPedidoProveedor).Color = cdColor.Color.ToArgb()
            txtColor.BackColor = cdColor.Color
         End If
      End Sub)
   End Sub

   Private Sub btnIdEstadoPedido_Click(sender As Object, e As EventArgs) Handles btnIdEstadoPedido.Click
      TryCatched(Sub() cmbIdEstadoPedido.SelectedIndex = -1)
   End Sub

   Private Sub btnTipoMovimiento_Click(sender As Object, e As EventArgs) Handles btnTipoMovimiento.Click
      TryCatched(Sub() cmbTipoMovimiento.SelectedIndex = -1)
      TryCatched(Sub() cmbStockAfectado.SelectedIndex = -1)
   End Sub
   Private Sub btnIdEstadoDestino_Click(sender As Object, e As EventArgs) Handles btnIdEstadoDestino.Click
      TryCatched(Sub() cmbIdEstadoDestino.SelectedIndex = -1)
   End Sub
   Private Sub btnIdEstadoFacturado_Click(sender As Object, e As EventArgs) Handles btnIdEstadoFacturado.Click
      TryCatched(Sub() cmbIdEstadoFacturado.SelectedIndex = -1)
   End Sub

   Private Sub cmbTipoMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMovimiento.SelectedIndexChanged
      TryCatched(Sub() cmbStockAfectado.Enabled = cmbTipoMovimiento.SelectedIndex > -1)
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      '  Me.CargarProximoNumero()
      'Me.cmbTiposEstados.SelectedIndex = -1
      Me.cmbComprobantes.SelectedIndex = -1
      DirectCast(Me._entidad, Entidades.EstadoPedidoProveedor).Color = System.Drawing.SystemColors.Control.ToArgb()
      Me.txtColor.BackColor = System.Drawing.SystemColors.Control
   End Sub

   'Private Sub CargarProximoNumero()
   '    Dim oplan As Reglas.ContabilidadPlanes = New Reglas.ContabilidadPlanes
   '    Dim ProximoID As Integer
   '    ProximoID = oplan.GetIdMaximo() + 1
   '    Me.txtIdPlanCuenta.Text = ProximoID.ToString()
   'End Sub

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _parametros = parametros
      If parametros IsNot Nothing Then
         Dim parametrosCol As String() = parametros.Split("\"c)
         _tipoTipoComprobante = parametrosCol(0)
         If parametrosCol.Length > 1 Then
            Dim tipos As String() = parametrosCol(1).Split(","c)
            _tipoTipoComprobanteParaCombo = tipos(0)
            If tipos.Length > 1 Then
               _tipoTipoComprobanteParaCombo2 = tipos(1)
            End If
         End If
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: PEDIDOSPROV\COMPRAS")
      stb.AppendFormatLine("Estructura: {TiposComprobantes.Tipo}\{TiposComprobantes.Tipo Combo (1)},{TiposComprobantes.Tipo Combo (2)}")
      stb.AppendFormatLine("")
      stb.AppendFormatLine("Donde:")
      stb.AppendFormatLine("    {TiposComprobantes.Tipo} es el Tipo de tipo de comprobante de los estados gestionados en la pantalla")
      stb.AppendFormatLine("    {TiposComprobantes.Tipo Combo (1)} es el Tipo de tipo de comprobante que se carga en el combo de TP Comp")
      stb.AppendFormatLine("    {TiposComprobantes.Tipo Combo (2)} es el segundo Tipo de TP comp que se carga en el combo de TP Comp")
      stb.AppendFormatLine("")
      stb.AppendFormatLine("    Los TiposComprobantes.Tipo Combo (1) y TiposComprobantes.Tipo Combo (2) se combinan con OR")
      Return stb.ToString()
   End Function


End Class
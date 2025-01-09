Public Class EstadosPedidosDetalle
   Implements IConParametros

   Private ReadOnly Property EstadoPedido As Entidades.EstadoPedido
      Get
         Return DirectCast(_entidad, Entidades.EstadoPedido)
      End Get
   End Property

#Region "Campos"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String
   Private _tipoTipoComprobanteParaCombo As String
   Private _tipoTipoComprobanteParaCombo2 As String
   Private _cargaDeposito As Boolean = False
   Private _parametros As String = ""

   Private _titRoles As Dictionary(Of String, String)
   Private _titEstadosRoles As Dictionary(Of String, String)

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.EstadoPedido)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"
         If String.IsNullOrWhiteSpace(_tipoTipoComprobanteParaCombo) AndAlso String.IsNullOrWhiteSpace(_tipoTipoComprobanteParaCombo2) Then _tipoTipoComprobanteParaCombo2 = "PRODUCCION"
         If String.IsNullOrWhiteSpace(_tipoTipoComprobanteParaCombo) Then _tipoTipoComprobanteParaCombo = "VENTAS"

         Me._publicos.CargaComboTiposEstadosPedidos(Me.cmbTiposEstados, _tipoTipoComprobante)

         Me._publicos.CargaComboEstadosPedidos(Me.cmbEstadoDivideA, False, False, False, False, False, _tipoTipoComprobante)
         Me._publicos.CargaComboEstadosPedidos(Me.cmbEstadoDivideB, False, False, False, False, False, _tipoTipoComprobante)

         Me._publicos.CargaComboTiposComprobantesFacturablesReales(Me.cmbComprobantes, False, _tipoTipoComprobanteParaCombo, _tipoTipoComprobanteParaCombo2)
         Me.cmbComprobantes.SelectedIndex = 0
         _cargaDeposito = True
         _publicos.CargaComboDepositos(cmbDepositoOrigen, actual.Sucursal.IdSucursal, miraUsuario:=False, PermiteEscritura:=False, Entidades.Publicos.SiNoTodos.TODOS,
                                       tipos:={Entidades.SucursalDeposito.TiposDepositos.RESERVADO})
         cmbDepositoOrigen.SelectedIndex = -1
         _cargaDeposito = False

         Me.BindearControles(Me._entidad)

         _titRoles = GetColumnasVisiblesGrilla(ugRoles)
         ugRoles.DataSource = New Reglas.Roles().GetTodos()
         AjustarColumnasGrilla(ugRoles, _titRoles)

         If Not DirectCast(Me._entidad, Entidades.EstadoPedido).ReservaStock Then
            cmbDepositoOrigen.SelectedIndex = -1
            cmbUbicacionOrigen.SelectedIndex = -1
         End If

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.CargarValoresIniciales()
            AddRoles(ugRoles.DataSource(Of List(Of Entidades.Rol)), EstadoPedido.Roles)
         Else
            Try
               Me.txtColor.BackColor = System.Drawing.Color.FromArgb(EstadoPedido.Color)
            Catch ex As Exception
               Me.txtColor.BackColor = Color.FromKnownColor(KnownColor.Control)
            End Try
         End If

         _titEstadosRoles = GetColumnasVisiblesGrilla(ugEstadosRoles)
         ugEstadosRoles.DataSource = EstadoPedido.Roles
         AjustarColumnasGrilla(ugEstadosRoles, _titEstadosRoles)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosPedidos
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If _tipoTipoComprobante = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString() Then
         If Me.cmbComprobantes.SelectedIndex > -1 Then
            If DirectCast(cmbComprobantes.SelectedItem, Entidades.TipoComprobante).Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() Then
               If Publicos.PedidosPendientesFacturaAutomaticamente Then
                  If Not chbSolicitaSucursalParaTipoComprobante.Checked Then
                     Me.cmbComprobantes.Focus()
                     Return "ATENCION: No puede seleccionar un Comprobante porque esta activo el Parametro de Facturación Automática"
                  End If
               End If
            End If
         End If
      End If

      If chbReservaStock.Checked AndAlso cmbDepositoOrigen.SelectedIndex = -1 Then
         cmbDepositoOrigen.Focus()
         Return "ATENCION: Debe seleccionar un Deposito y una Ubicacion porque esta activo Reserva Stock"
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      With DirectCast(_entidad, Entidades.EstadoPedido)
         .IdTipoEstado = cmbTiposEstados.Text
         .IdSucursal = actual.Sucursal.IdSucursal
         If cmbDepositoOrigen.SelectedIndex > -1 Then
            .IdDeposito = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
            .IdUbicacion = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
         End If
      End With


      If Not chbDivide.Checked Then
         DirectCast(_entidad, Entidades.EstadoPedido).IdEstadoDivideA = String.Empty
         DirectCast(_entidad, Entidades.EstadoPedido).IdEstadoDivideB = String.Empty
         DirectCast(_entidad, Entidades.EstadoPedido).PorcDivideA = 0
         DirectCast(_entidad, Entidades.EstadoPedido).PorcDivideB = 0
      End If

      If Not chbSolicitaSucursalParaTipoComprobante.Enabled Then
         DirectCast(_entidad, Entidades.EstadoPedido).SolicitaSucursalParaTipoComprobante = False
      End If

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnLimpiarTamaño_Click(sender As Object, e As EventArgs) Handles btnLimpiarTamaño.Click
      Me.cmbComprobantes.SelectedIndex = -1
      DirectCast(Me._entidad, Entidades.EstadoPedido).IdTipoComprobante = String.Empty
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarValoresIniciales()
      'End If
      ' Me.txtIdPlanCuenta.Focus()
   End Sub

#Region "Eventos Roles"
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(
      Sub()
         Dim drs = ugRoles.FilasSeleccionadas(Of Entidades.Rol)()
         Dim estadosRoles = ugEstadosRoles.DataSource(Of List(Of Entidades.EstadoPedidoRol))
         AddRoles(drs, estadosRoles)
      End Sub)
   End Sub

   Private Sub AddRoles(drs As IEnumerable(Of Entidades.Rol), estadosRoles As List(Of Entidades.EstadoPedidoRol))
      If drs.AnySecure() AndAlso estadosRoles IsNot Nothing Then
         estadosRoles.AddRange(drs.Where(Function(dr) Not estadosRoles.Exists(Function(dr1) dr1.IdRol = dr.Id)).ToList().
                               ConvertAll(Function(dr) New Entidades.EstadoPedidoRol() With
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
         Dim drs = ugEstadosRoles.FilasSeleccionadas(Of Entidades.EstadoPedidoRol)
         Dim estadosRoles = ugEstadosRoles.DataSource(Of List(Of Entidades.EstadoPedidoRol))
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

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      '  Me.CargarProximoNumero()
      'Me.cmbTiposEstados.SelectedIndex = -1
      Me.cmbComprobantes.SelectedIndex = -1
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
      Return "Pendiente documentar"
   End Function

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Try
         Me.cdColor.Color = Me.txtColor.BackColor

         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.EstadoPedido).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbDivide_CheckedChanged(sender As Object, e As EventArgs) Handles chbDivide.CheckedChanged
      Try
         cmbEstadoDivideA.Enabled = chbDivide.Checked
         cmbEstadoDivideB.Enabled = chbDivide.Checked
         txtPorcDivideA.Enabled = chbDivide.Checked
         txtPorcDivideB.Enabled = chbDivide.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbComprobantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprobantes.SelectedIndexChanged
      chbSolicitaSucursalParaTipoComprobante.Enabled = cmbComprobantes.SelectedIndex > -1
   End Sub

   Private Sub chbReservaStock_CheckedChanged(sender As Object, e As EventArgs) Handles chbReservaStock.CheckedChanged
      Try
         cmbDepositoOrigen.Enabled = chbReservaStock.Checked
         cmbUbicacionOrigen.Enabled = chbReservaStock.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbDepositoOrigen.SelectedIndex > -1 Then
            Dim dr = cmbDepositoOrigen.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing And Not _cargaDeposito Then
               _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("Idsucursal"))
            End If
         End If
      End Sub)
   End Sub
End Class
Option Explicit On
Option Strict On

Public Class EstadosOrdenesProduccionDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _cargaDeposito As Boolean = False
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.EstadoOrdenProduccion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Me.cmbTiposEstados.Items.Insert(0, "ANULADO")
      'Me.cmbTiposEstados.Items.Insert(1, "CANCELADO")
      'Me.cmbTiposEstados.Items.Insert(2, "EN PROCESO")
      'Me.cmbTiposEstados.Items.Insert(3, "ENTREGADO")
      'Me.cmbTiposEstados.Items.Insert(4, "FINALIZADO")
      'Me.cmbTiposEstados.Items.Insert(5, "PENDIENTE")

      _cargaDeposito = True
      _publicos.CargaComboDepositos(cmbDepositoOrigen, actual.Sucursal.IdSucursal, miraUsuario:=False, PermiteEscritura:=False, Entidades.Publicos.SiNoTodos.TODOS)
      cmbDepositoOrigen.SelectedIndex = -1
      _cargaDeposito = False


      Me._publicos.CargaComboTiposEstadosOrdenesProduccion(Me.cmbTiposEstados)
      _publicos.CargaComboEstadosPedidos(cmbIdEstadoPedido, False, False, False, False, False, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())

      Me._publicos.CargaComboTiposComprobantesFacturablesReales(Me.cmbComprobantes, False, "VENTAS")
      Me.cmbComprobantes.SelectedIndex = 0


      Me.BindearControles(Me._entidad)


      If Not DirectCast(Me._entidad, Entidades.EstadoOrdenProduccion).ReservaMateriaPrima Then
         cmbDepositoOrigen.SelectedIndex = -1
         cmbUbicacionOrigen.SelectedIndex = -1
      End If

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarValoresIniciales()
      Else
         Try
            Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.EstadoOrdenProduccion).Color)
         Catch ex As Exception
            Me.txtColor.BackColor = Color.FromKnownColor(KnownColor.Control)
         End Try
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosOrdenesProduccion
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Me.cmbComprobantes.SelectedIndex <> -1 And Publicos.PedidosPendientesFacturaAutomaticamente Then
         Me.cmbComprobantes.Focus()
         Return "ATENCION: No puede seleccionar un Comprobante porque esta activo el Parametro de Facturación Automática"
      End If

      If chbGeneraProductoTerminado.Checked And chbReservaMateriaPrima.Checked Then
         Me.chbReservaMateriaPrima.Focus()
         Return "ATENCION: No se puede marcar un estado como ´Reserva Materia Prima´ y ´Genera Producto Terminado´ a la vez. Por favor verifique y reintente."
      End If

      If txtidTipoEstado.Text = Entidades.EstadoOrdenProduccion.ESTADO_ALTA And chbGeneraProductoTerminado.Checked Then
         Me.chbGeneraProductoTerminado.Focus()
         Return String.Format("ATENCION: El Estado {0} no se puede marcar como ´Genera Producto Terminado´. Por favor verifique y reintente.", Entidades.EstadoOrdenProduccion.ESTADO_ALTA)
      End If

      If chbReservaMateriaPrima.Checked AndAlso cmbDepositoOrigen.SelectedIndex = -1 Then
         cmbDepositoOrigen.Focus()
         Return "ATENCION: Debe seleccionar un Deposito y una Ubicacion porque esta activo Reserva Materia Prima"
      End If
      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnLimpiarTamaño_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarTamaño.Click
      Me.cmbComprobantes.SelectedIndex = -1
      'DirectCast(Me._entidad, Entidades.EstadoOrdenProduccion).idTipoComprobante = String.Empty
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarValoresIniciales()
      'End If
      ' Me.txtIdPlanCuenta.Focus()
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Try
         Me.cdColor.Color = Me.txtColor.BackColor

         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.EstadoOrdenProduccion).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      '  Me.CargarProximoNumero()
      'Me.cmbTiposEstados.SelectedIndex = -1
      Me.cmbComprobantes.SelectedIndex = -1
   End Sub

   Protected Overrides Sub Aceptar()
      With DirectCast(_entidad, Entidades.EstadoOrdenProduccion)
         .IdSucursal = actual.Sucursal.IdSucursal
         If cmbDepositoOrigen.SelectedIndex > -1 Then
            .IdDeposito = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
            .IdUbicacion = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
         End If
      End With
      MyBase.Aceptar()
   End Sub

   'Private Sub CargarProximoNumero()
   '    Dim oplan As Reglas.ContabilidadPlanes = New Reglas.ContabilidadPlanes
   '    Dim ProximoID As Integer
   '    ProximoID = oplan.GetIdMaximo() + 1
   '    Me.txtIdPlanCuenta.Text = ProximoID.ToString()
   'End Sub

#End Region

   Private Sub btnIdEstadoPedido_Click(sender As Object, e As EventArgs) Handles btnIdEstadoPedido.Click
      Me.cmbIdEstadoPedido.SelectedIndex = -1
   End Sub

   Private Sub chbReservaMateriaPrima_CheckedChanged(sender As Object, e As EventArgs) Handles chbReservaMateriaPrima.CheckedChanged
      Try
         cmbDepositoOrigen.Enabled = chbReservaMateriaPrima.Checked
         cmbUbicacionOrigen.Enabled = chbReservaMateriaPrima.Checked
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
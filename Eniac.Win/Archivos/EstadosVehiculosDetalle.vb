Public Class EstadosVehiculosDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _cargando As Boolean = False
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.EstadoVehiculo)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _cargando = True
            _publicos = New Publicos()

            _publicos.CargaComboEstadoVehiculo(cmbIdEstadoVehiculoLuegoVencer)

            BindearControles(_entidad, _liSources)
            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               txtId.Text = (DirectCast(GetReglas(), Reglas.EstadosVehiculos).GetCodigoMaximo() + 1).ToString()
            Else

            End If
            _cargando = True
         End Sub)

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.EstadosVehiculos()
   End Function

#End Region

#Region "Eventos"
   Private Sub chbSolicitaFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbSolicitaFecha.CheckedChanged
      'TryCatched(Sub() chbSolicitaFecha.FiltroCheckedChanged(cmbIdEstadoVehiculoLuegoVencer))
      TryCatched(
         Sub()
            cmbIdEstadoVehiculoLuegoVencer.Enabled = chbSolicitaFecha.Checked
            If Not _cargando Then
               cmbIdEstadoVehiculoLuegoVencer.SelectedIndex = -1
            End If
         End Sub)
   End Sub
#End Region

#Region "Metodos"
   Protected Overrides Function ValidarDetalle() As String
      If chbSolicitaFecha.Checked AndAlso cmbIdEstadoVehiculoLuegoVencer.SelectedIndex = -1 Then
         Return "El estado solicita fecha, debe indicar a que estado pasa una vez vencido."
      End If
      Return MyBase.ValidarDetalle()
   End Function
#End Region

End Class
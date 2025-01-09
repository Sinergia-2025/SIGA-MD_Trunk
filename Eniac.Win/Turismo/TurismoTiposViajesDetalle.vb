Public Class TurismoTiposViajesDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

   Private ReadOnly Property TipoViaje As Entidades.TurismoTipoViaje
      Get
         Return DirectCast(_entidad, Entidades.TurismoTipoViaje)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.TurismoTipoViaje)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboIntereses(cmbIntereses)
            If cmbIntereses.Items.Count = 1 Then
               cmbIntereses.SelectedIndex = 0
            End If

            BindearControles(_entidad)

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarProximoNumero()
            Else

            End If
         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TurismoTiposViajes()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      txtCodigo.Text = (New Reglas.TurismoTiposViajes().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class
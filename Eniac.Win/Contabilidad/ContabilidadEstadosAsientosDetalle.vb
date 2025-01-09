Public Class ContabilidadEstadosAsientosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

   Private ReadOnly Property EstadoAsiento As Entidades.ContabilidadEstadoAsiento
      Get
         Return DirectCast(_entidad, Entidades.ContabilidadEstadoAsiento)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.ContabilidadEstadoAsiento)
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

            BindearControles(_entidad)

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
               CargarProximoNumero()
               EstadoAsiento.Usuario = actual.Nombre
            Else

            End If
         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadEstadosAsientos()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      txtCodigo.Text = (New Reglas.ContabilidadEstadosAsientos().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

End Class
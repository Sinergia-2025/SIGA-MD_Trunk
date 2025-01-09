Public Class GruposCamasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Public ReadOnly Property GrupoCama As Entidades.GrupoCama
      Get
         Return DirectCast(_entidad, Entidades.GrupoCama)
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.GrupoCama)
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
               GrupoCama.Usuario = actual.Nombre
            Else

            End If
         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.GruposCamas()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      txtId.SetValor(New Reglas.GruposCamas().GetCodigoMaximo() + 1)
   End Sub

#End Region

End Class
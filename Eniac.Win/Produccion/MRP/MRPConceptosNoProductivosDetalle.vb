Public Class MRPConceptosNoProductivosDetalle
#Region "Campos"
   Private _publicos As Publicos
#End Region

   Private ReadOnly Property Concepto As Entidades.MRPConceptoNoProductivo
      Get
         Return DirectCast(_entidad, Entidades.MRPConceptoNoProductivo)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.MRPConceptoNoProductivo)
      InitializeComponent()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos()

      BindearControles(_entidad, _liSources)

      If StateForm = Eniac.Win.StateForm.Insertar Then
         CargarProximoNumero()
      Else

      End If
      txtCodigoConceptoNoProductivo.Focus()

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPConceptosNoProductivos()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"
   Private Sub CargarProximoNumero()
      Dim regla = New Reglas.MRPConceptosNoProductivos()
      txtCodigoConceptoNoProductivo.Text = (regla.GetCodigoMaximo() + 1).ToString()
   End Sub
#End Region

#Region "Eventos"

#End Region
End Class
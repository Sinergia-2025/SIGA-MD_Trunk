Public Class AFIPIncotermsDetalle
#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.AFIPIncoterm)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Me._Publicos = New Win.Publicos

      Me.BindearControles(Me._entidad, _liSources)

      If Me.StateForm = Win.StateForm.Insertar Then

      End If
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AFIPIncoterms()
   End Function
#End Region
End Class
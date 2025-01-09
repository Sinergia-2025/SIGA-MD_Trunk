Public Class ConcesionarioTiposUnidadesDetalle
#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.ConcesionarioTipoUnidad)
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
         txtId.Text = (DirectCast(GetReglas(), Reglas.ConcesionarioTiposUnidades).GetCodigoMaximo() + 1).ToString()
      End If
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ConcesionarioTiposUnidades()
   End Function
#End Region
End Class
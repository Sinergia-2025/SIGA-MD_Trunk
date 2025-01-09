Public Class PlazosEntregaDetalle

#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.PlazoEntrega)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      _Publicos = New Publicos()

      Me.BindearControles(Me._entidad, _liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         txtId.Text = (DirectCast(GetReglas(), Reglas.PlazosEntregas).GetCodigoMaximo() + 1).ToString()
         chbActivo.Checked = True
      End If

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.PlazosEntregas()
   End Function
#End Region

End Class
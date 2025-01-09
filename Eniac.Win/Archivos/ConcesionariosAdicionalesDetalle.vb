Public Class ConcesionariosAdicionalesDetalle

#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.ConcesionariosAdicionales)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._Publicos = New Eniac.Win.Publicos()

      Me.BindearControles(Me._entidad, _liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         txtId.Text = (DirectCast(GetReglas(), Reglas.ConcesionariosAdicionales).GetCodigoMaximo() + 1).ToString()
      Else

      End If
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ConcesionariosAdicionales()
   End Function

#End Region
End Class
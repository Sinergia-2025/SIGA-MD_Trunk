Public Class NacionalidadesDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _idNacionalidad As Integer
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(eNacionalidad As Entidades.Nacionalidad)
      Me.InitializeComponent()
      Me._entidad = eNacionalidad
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)
      Me._publicos = New Publicos()

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Nacionalidades()
   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtId.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim rNacionalidades As Reglas.Nacionalidades = New Reglas.Nacionalidades()
      Me.txtId.Text = (rNacionalidades.GetCodigoMaximo() + 1).ToString()
   End Sub
#End Region
End Class
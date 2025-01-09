Public Class TiposObservacionesDetalle

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.TipoObservacion)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BindearControles(_entidad)
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         txtIdObservaciones.Text = (DirectCast(GetReglas(), Reglas.TiposObservaciones).GetCodigoMaximo() + 1).ToString()
      End If
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposObservaciones()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function
#End Region

End Class
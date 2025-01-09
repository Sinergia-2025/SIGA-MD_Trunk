Public Class UnidadesDeMedidasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.UnidadDeMedida)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BindearControles(_entidad)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.UnidadesDeMedidas()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      txtIdUnidadDeMedida.Focus()
   End Sub

#End Region

End Class
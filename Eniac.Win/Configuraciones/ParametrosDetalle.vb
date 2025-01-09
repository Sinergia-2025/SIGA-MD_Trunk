Public Class ParametrosDetalle

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.Parametro)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      BindearControles(_entidad)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Parametros()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      Reglas.ParametrosCache.Instancia.LimpiarCache(txtParametro.Text)
   End Sub

#End Region

End Class
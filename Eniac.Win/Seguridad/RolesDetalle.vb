Public Class RolesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Rol)
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
      Return New Reglas.Roles
   End Function
   Protected Overrides Function ValidarDetalle() As String
      Dim _error = String.Empty
      Return _error
   End Function

#End Region

End Class
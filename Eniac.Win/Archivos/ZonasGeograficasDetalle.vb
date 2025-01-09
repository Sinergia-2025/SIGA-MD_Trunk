Public Class ZonasGeograficasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.ZonaGeografica)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      BindearControles(_entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(_entidad, Entidades.ZonaGeografica).Usuario = actual.Nombre
      End If
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ZonasGeograficas()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      txtIdZonaGeografica.Select()
   End Sub

#End Region

End Class
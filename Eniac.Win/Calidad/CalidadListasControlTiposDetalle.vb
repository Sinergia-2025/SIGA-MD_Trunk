Public Class CalidadListasControlTiposDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.CalidadListaControlTipo)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BindearControles(_entidad)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoNumero()

            'txtNombreTipoListaControl.Focus()
         Else

         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CalidadListasControlTipos()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Métodos"
   Private Sub CargarProximoNumero()
      txtIdTipoListaControl.Text = New Reglas.CalidadListasControlTipos().GetCodigoMaximo().ToString()
   End Sub
#End Region

End Class
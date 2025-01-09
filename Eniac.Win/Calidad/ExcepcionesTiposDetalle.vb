Option Strict Off
Imports Infragistics.Win.UltraWinGrid
Public Class ExcepcionesTiposDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ExcepcionTipo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()

         DirectCast(Me._entidad, Entidades.ExcepcionTipo).Usuario = actual.Nombre
         Me.txtNombreExcepcionTipo.Focus()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ExcepcionesTipos()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub CargarProximoNumero()
      Me.txtIdExcepcionTipo.Text = New Reglas.ExcepcionesTipos().GetCodigoMaximo().ToString()
   End Sub

#End Region

End Class
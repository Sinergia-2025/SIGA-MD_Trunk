Option Strict Off
Imports Infragistics.Win.UltraWinGrid
Public Class ProductosTiposServiciosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ProductoTipoServicio)
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

         DirectCast(Me._entidad, Entidades.ProductoTipoServicio).Usuario = actual.Nombre
         Me.txtNombreProductoTipoServicio.Focus()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosTiposServicios()
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
      Me.txtIdProductoTipoServicio.Text = New Reglas.ProductosTiposServicios().GetCodigoMaximo().ToString()
   End Sub

#End Region

End Class
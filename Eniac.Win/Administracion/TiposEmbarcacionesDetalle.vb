Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Public Class TiposEmbarcacionesDetalle
   Private _publicos As Publicos
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.TipoEmbarcacion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoCodigo()
      End If
      Me.txtDescripcion.Focus()

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposEmbarcaciones()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtDescripcion.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoCodigo()
      Dim oTipoEmbarcacion As Reglas.TiposEmbarcaciones = New Reglas.TiposEmbarcaciones()
      Dim ProxId As Integer
      ProxId = oTipoEmbarcacion.GetCodigoMaximo() + 1
      Me.txtIdTipoEmbarcacion.Text = ProxId.ToString()
   End Sub

#End Region

End Class
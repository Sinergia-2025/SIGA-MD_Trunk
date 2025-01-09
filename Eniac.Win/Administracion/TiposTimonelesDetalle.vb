Option Explicit On
Option Strict On

Public Class TiposTimonelesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.TipoTimonel)
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
      Return New Reglas.TiposTimoneles()
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
      Dim oTipoTimoneles As Reglas.TiposTimoneles = New Reglas.TiposTimoneles()
      Dim ProxId As Integer
      ProxId = oTipoTimoneles.GetCodigoMaximo() + 1
      Me.txtIdTipoTimonel.Text = ProxId.ToString()
   End Sub

#End Region

End Class
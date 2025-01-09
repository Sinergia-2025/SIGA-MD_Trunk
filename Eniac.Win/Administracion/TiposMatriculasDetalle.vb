Option Explicit On
Option Strict On

Public Class TiposMatriculasDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.TipoMatricula)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.chbTieneNumeros.Checked = True
         Me.CargarProximoCodigo()
      End If
      Me.txtDescripcion.Focus()

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposMatriculas()
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
      Dim oTipoMatriculaes As Reglas.TiposMatriculas = New Reglas.TiposMatriculas()
      Dim ProxId As Integer
      ProxId = oTipoMatriculaes.GetCodigoMaximo() + 1
      Me.txtIdTipoMatricula.Text = ProxId.ToString()
   End Sub

#End Region

End Class
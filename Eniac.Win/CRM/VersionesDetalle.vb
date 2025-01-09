#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class VersionesDetalle
   Private _publicos As Publicos
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Version)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      _publicos = New Publicos()

      Me._publicos.CargaComboAplicaciones(cmbAplicacionBase)
      Me._publicos.CargaComboAplicaciones(cmbAplicacion)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(Me._entidad, Entidades.Version).Usuario = actual.Nombre
         Me.dtpFechaVersion.Value = DateTime.Now()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Versiones()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      Me.cmbAplicacion.Focus()
   End Sub

#End Region

   Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
      Try
         Me.cmbAplicacionBase.SelectedIndex = -1
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class
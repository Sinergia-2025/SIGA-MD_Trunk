Option Strict On
Option Explicit On

Public Class ScriptsVersionDetalle
   Private _publicos As Publicos

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.VersionScript)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         Me._liSources.Add("Aplicacion", DirectCast(Me._entidad, Eniac.Entidades.VersionScript).Aplicacion)
         Me._liSources.Add("Cliente", DirectCast(Me._entidad, Eniac.Entidades.VersionScript).Cliente)
         Me._liSources.Add("Version", DirectCast(Me._entidad, Eniac.Entidades.VersionScript).Version)

         Me.BindearControles(Me._entidad, Me._liSources)

     

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Dim reg As Reglas.VersionesScripts = New Reglas.VersionesScripts()
            Me.txtOrden.Text = (reg.GetOrdenMaximo(Me.txtAplicacion.Text, Me.txtVersion.Text) + 1).ToString()
         End If

         txtScript.Text = DirectCast(Me._entidad, Eniac.Entidades.VersionScript).Script

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.VersionesScripts()
   End Function

   Protected Overrides Sub Aceptar()
      DirectCast(Me._entidad, Eniac.Entidades.VersionScript).Script = txtScript.Text

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"
   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      Try

         If ofgScript.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.txtScript.Text = IO.File.ReadAllText(Me.ofgScript.FileName)
            Me.txtNombre.Text = New IO.FileInfo(ofgScript.FileName).Name
         End If

      Catch Ex As Exception

         MessageBox.Show(Ex.Message)

      End Try
   End Sub
#End Region



End Class
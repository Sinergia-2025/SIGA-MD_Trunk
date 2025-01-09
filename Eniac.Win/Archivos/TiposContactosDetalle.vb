Public Class TiposContactosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.TipoContacto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.BindearControles(Me._entidad)
         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.CargarProximoCodigo()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposContactos
   End Function
   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse(Me.txtIdTipoContacto.Text) <= 0 Then
         Me.txtIdTipoContacto.Focus()
         Return "Debe ingresar un Código de Tipo de Contacto positivo"
      End If

      Return MyBase.ValidarDetalle()

   End Function


#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdTipoContacto.Focus()
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarProximoCodigo()

      Dim oTiposContactos As Reglas.TiposContactos = New Reglas.TiposContactos()
      Dim ProximoTipoContacto As Integer

      ProximoTipoContacto = oTiposContactos.GetCodigoMaximo() + 1
      Me.txtIdTipoContacto.Text = ProximoTipoContacto.ToString()

   End Sub


#End Region

End Class

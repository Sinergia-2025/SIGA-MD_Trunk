Public Class BancosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Banco)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Me._tituloNuevo = "Nueva"
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Bancos()
   End Function

   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If

   End Sub


   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Integer.Parse(Me.txtCodigo.Text) <= 0 Then
         Me.txtCodigo.Focus()
         Return "Debe ingresar un Código de Banco positivo"
      End If

      If Me.chbDebitoDirecto.Checked Then
         If Integer.Parse(Me.txtEmpresa.Text) <= 0 Then
            Me.txtEmpresa.Focus()
            Return "Debe ingresar un Código de Empresa para Debito Directo"
         End If
         If Integer.Parse(Me.txtConvenio.Text) <= 0 Then
            Me.txtConvenio.Focus()
            Return "Debe ingresar un Código de Convenio para Debito Directo"
         End If
         If String.IsNullOrEmpty(Me.txtServicio.Text) Then
            Me.txtServicio.Focus()
            Return "Debe ingresar un Código de Servicio para Debito Directo"
         End If
      End If

      Return vacio

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.txtCodigo.Focus()
   End Sub

   Private Sub chbDebitoDirecto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbDebitoDirecto.CheckedChanged
      Try
         Me.txtEmpresa.Enabled = Me.chbDebitoDirecto.Checked
         Me.txtConvenio.Enabled = Me.chbDebitoDirecto.Checked
         Me.txtServicio.Enabled = Me.chbDebitoDirecto.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

#End Region

End Class

#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class UsuariosDetalle

   Private ReadOnly Property Usuario As Entidades.Usuario
      Get
         Return DirectCast(_entidad, Entidades.Usuario)
      End Get
   End Property
   Private ReadOnly Property MailConfig As Entidades.MailConfig
      Get
         Return Usuario.MailConfig
      End Get
   End Property

#Region "Campos"
   Protected _publicos As Eniac.Win.Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Usuario)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try

         Me.BindearControles(Me._entidad)

         '-- REQ-30959 --
         Me._publicos.CargaComboTipoUsuarios(Me.cmbTipoUsuario)
         Me.cmbTipoUsuario.SelectedIndex = 0
         Me.cmbTipoUsuario.Enabled = True

         'despues del bindeo si estoy insertando le cargo una fecha y lo pongo activo
         If Me.StateForm = Win.StateForm.Insertar Then
            'si estoy insertando le pongo a la fecha de la contraseña la fecha actual
            Me.dtpFechaUltimaModContraseña.Value = DateTime.Now
            Me.chbActivo.Checked = True
         Else
            cmbTipoUsuario.SelectedValue = Usuario.TipoUsuario
            chbUtilizaComoPredeterminado.Checked = MailConfig.UtilizaComoPredeterminado
            txtMailServidor.Text = MailConfig.ServidorSMTP
            txtMailPuertoSalida.Text = MailConfig.PuertoSalida.ToString()
            txtMailDireccion.Text = MailConfig.Direccion
            txtMailUsuario.Text = MailConfig.UsuarioMail
            txtMailPassword.Text = MailConfig.Clave
            chbMailRequiereSSL.Checked = MailConfig.RequiereSSL
            chbMailRequiereAutenticacion.Checked = MailConfig.RequiereAutenticacion
            txtCantidadMailsPorMinuto.Text = MailConfig.CantidadXMinuto.ToString()
            txtCantidadMailsPorHora.Text = MailConfig.CantidadXHora.ToString()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Usuarios()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      Dim _error As String = ""
      'If Me.cmbTipoDocGarante.Text = "" And Me.txtNroDocGarante.Text = "" Then
      '    Return ""
      'Else
      '    If Me._validaGarante Then
      '        Return ""
      '    Else
      '        Return "Debe validar el garante antes de aceptar"
      '    End If
      'End If
      Return _error
   End Function
   Protected Overrides Sub Aceptar()

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(Me._entidad, Entidades.Usuario).MailConfig = New Entidades.MailConfig()
      End If

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.ServidorSMTP = txtMailServidor.Text

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.UtilizaComoPredeterminado = chbUtilizaComoPredeterminado.Checked

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.PuertoSalida = Integer.Parse(txtMailPuertoSalida.Text.ToString())

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.Direccion = txtMailDireccion.Text

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.Usuario = txtMailUsuario.Text

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.Password = txtMailPassword.Text

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.RequiereSSL = chbMailRequiereSSL.Checked

      DirectCast(Me._entidad, Entidades.Usuario).MailConfig.RequiereAutenticacion = chbMailRequiereAutenticacion.Checked

      '-- REQ-30959 --
      DirectCast(Me._entidad, Entidades.Usuario).TipoUsuario = Integer.Parse(cmbTipoUsuario.SelectedValue.ToString())

      If Not String.IsNullOrEmpty(txtCantidadMailsPorMinuto.Text.ToString()) Then
         DirectCast(Me._entidad, Entidades.Usuario).MailConfig.CantidadXMinuto = Integer.Parse(txtCantidadMailsPorMinuto.Text.ToString())
      End If

      If Not String.IsNullOrEmpty(txtCantidadMailsPorHora.Text.ToString()) Then
         DirectCast(Me._entidad, Entidades.Usuario).MailConfig.CantidadXHora = Integer.Parse(txtCantidadMailsPorHora.Text.ToString())
      End If

      MyBase.Aceptar()

   End Sub
#End Region

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      'Pasa por aca si luego del aceptar
     
      If Me.StateForm = Eniac.Win.StateForm.Insertar And Not Me.HayError And Not Me.CierraAutomaticamente Then

         Me.chbActivo.Checked = True
      Else


      End If

      Me.txtId.Focus()

   End Sub

End Class
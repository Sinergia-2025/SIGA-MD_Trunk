Public Class DispositivosDetalle

#Region "Campos"
   Private _Publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.Dispositivo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me._Publicos = New Win.Publicos

      Me.BindearControles(Me._entidad, _liSources)


      If Me.StateForm = Win.StateForm.Insertar Then

         Me.chbActivo.Checked = True

      Else

         'Lo asigno para saber si luego la inactivó.
         Me.chbActivo.Tag = DirectCast(Me._entidad, Entidades.Dispositivo).Activo

         'GAR: 31/12/2022. Control de LIcencias. Por ahora en Editar No permito modificar nada.
         Me.txtNombreDispositivo.ReadOnly = True
         Me.txtIdTipoDispositivo.ReadOnly = True

         Dim ArrayUltimaInactivacion = Me.txtFechaUltimaInactivacion.Text.Split(";"c)

         Me.dtpFechaUltimaInactivacion.Value = Date.Parse(ArrayUltimaInactivacion(0).ToString())
         Me.dtpFechaUltimaInactivacion.Enabled = False

         Me.txtVersionFramework.ReadOnly = True
         Me.txtSistemaOperativo.ReadOnly = True
         Me.txtArquitecturaSO.ReadOnly = True
         Me.txtNumSerieDiscoPrimario.ReadOnly = True
         Me.txtBoxNumSerieHDD.ReadOnly = True
         Me.dtpFechaUltLogin.Enabled = False
         Me.txtUsuarioUltLogin.ReadOnly = True
         Me.txtNumeroSerieMotherboard.ReadOnly = True
         Me.txtBoxDirecMAC.ReadOnly = True
         Me.txtResolucionPantalla.ReadOnly = True

         'GAR:07/01/2023 como es que se pone la marca en DEBUG?? para que ahi muestre siempre.
         If Not Me.chbActivo.Checked Or actual.Nombre = "arolla" Then
            Me.lblFechaUltimaInactivacion.Visible = True
            Me.dtpFechaUltimaInactivacion.Visible = True
         Else
            Me.lblFechaUltimaInactivacion.Visible = False
            Me.dtpFechaUltimaInactivacion.Visible = False
            Me.txtFechaUltimaInactivacion.Visible = False
         End If
         'GAR:07/01/2023 como es que se pone la marca en DEBUG?? para que ahi muestre siempre.
         If actual.Nombre = "arolla" Then
            Me.txtFechaUltimaInactivacion.Visible = True
         End If

      End If

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Dispositivos()
   End Function

   'Protected Overrides Sub Aceptar()

   '   Dim ArrayUltimaInactivacion = Me.txtFechaUltimaInactivacion.Text.Split(";"c)

   '   'Si es inicial ya lo grabo con el nombre de la PC. Tal vez deberia hacerlo en otro lado.
   '   If ArrayUltimaInactivacion(1).ToString() = "**INICIAL**" Then
   '      Me.txtFechaUltimaInactivacion.Text = ArrayUltimaInactivacion(0).ToString() & ";" & Me.txtNombreDispositivo.Text
   '      ArrayUltimaInactivacion = Me.txtFechaUltimaInactivacion.Text.Split(";"c)
   '   End If

   '   If ArrayUltimaInactivacion(1).ToString() <> Me.txtNombreDispositivo.Text Then
   '      'Romper sistema (Parametros licencias PC?
   '      ShowMessage("ATENCIÓN: Hay Inconsistencia con la Licencia de esta PC. NO PUEDE USAR MAS EL SISTEMA. Por favor Contactese con la Mesa de Ayuda!")
   '      Exit Sub
   '   End If

   '   If Me.StateForm = Win.StateForm.Actualizar Then

   '      'Dim sistema = Publicos.GetSistema(actual.Sucursal.IdEmpresa)

   '      'Control de Fecha/Hora
   '      Dim FechaHoraServidor As Date = New Reglas.Generales().GetServerDBFechaHora()

   '      'Si Reactivo y pasaron menos de 60 dias par 
   '      If Me.chbActivo.Checked And Not Boolean.Parse(Me.chbActivo.Tag.ToString()) And DateDiff(DateInterval.Day, Date.Parse(ArrayUltimaInactivacion(0).ToString()), FechaHoraServidor) < 60 Then
   '         'Lo asigno para saber si luego la inactivó.
   '         ShowMessage("ATENCIÓN: No se puede Activar la PC porque hay menos de 60 dias desde que la inactivo. Por favor Contactese con la Mesa de Ayuda!")
   '         Exit Sub
   '      End If

   '      'Si INACTIVO
   '      If Not Me.chbActivo.Checked And Boolean.Parse(Me.chbActivo.Tag.ToString()) Then

   '         Me.txtFechaUltimaInactivacion.Text = Now.ToString("dd/MM/yyyy HH:mm") & ";" & Me.txtNombreDispositivo.Text
   '         ArrayUltimaInactivacion = Me.txtFechaUltimaInactivacion.Text.Split(";"c)

   '      End If

   '   End If

   '   MyBase.Aceptar()

   '   'If Not HayError Then
   '   'End If

   'End Sub

#End Region

#Region "Eventos"

   'GAR: esto esta buenisimo!!
   'Private Sub controlesContactos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreContacto.KeyDown, txtTelefonoContacto.KeyDown, txtObservacionContacto.KeyDown, txtMailContacto.KeyDown, txtDireccionContacto.KeyDown, txtCelularContacto.KeyDown, cmbTipoContacto.KeyDown, chbActivoContacto.KeyDown
   '   PresionarTab(e)
   'End Sub

#End Region

End Class
#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class UsuariosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New UsuariosDetalle(DirectCast(Me.GetEntidad(), Entidades.Usuario))
      End If
      Return New UsuariosDetalle(New Entidades.Usuario())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Usuarios()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ent As Entidades.Usuario = New Entidades.Usuario
      Dim reglas As Reglas.Usuarios = DirectCast(GetReglas(), Reglas.Usuarios)
      With Me.dgvDatos.ActiveRow
         Return reglas.GetUnoConMail(.Cells(Entidades.Usuario.Columnas.Id.ToString()).Value.ToString())
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns(Entidades.Usuario.Columnas.Id.ToString()).FormatearColumna("Id", col, 80)
         .Columns(Entidades.Usuario.Columnas.Nombre.ToString()).FormatearColumna("Nombre de Usuario", col, 310)
         .Columns(Entidades.Usuario.Columnas.Clave.ToString()).FormatearColumna("Clave", col, 0, HAlign.Default, True)
         .Columns(Entidades.Usuario.Columnas.CorreoElectronico.ToString()).FormatearColumna("Correo Electronico", col, 250, HAlign.Left, False)
         .Columns(Entidades.Usuario.Columnas.FechaUltimaModContraseña.ToString()).FormatearColumna("Ultima Modificación", col, 100, HAlign.Center, False)
         .Columns(Entidades.Usuario.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 50, HAlign.Center, False)
         .Columns(Entidades.Usuario.Columnas.NivelAutorizacion.ToString()).FormatearColumna("Nivel Autorizacion", col, 80, HAlign.Right)

         .Columns(Entidades.Usuario.Columnas.TipoUsuario.ToString()).FormatearColumna("Id Tipo Usuario", col, 80)
         .Columns(Entidades.Usuario.Columnas.NombreTipoUsuario.ToString()).FormatearColumna("Nombre Tipo de Usuario", col, 310)


         .Columns(Entidades.Usuario.Columnas.UtilizaComoPredeterminado.ToString()).FormatearColumna("Predeterminado", col, 60, HAlign.Center, False)
         .Columns(Entidades.Usuario.Columnas.MailServidorSMTP.ToString()).FormatearColumna("Servidor SMTP", col, 150, HAlign.Left, False)
         .Columns(Entidades.Usuario.Columnas.MailPuertoSalida.ToString()).FormatearColumna("Puerto", col, 60, HAlign.Right, False)

         .Columns(Entidades.Usuario.Columnas.MailDireccion.ToString()).FormatearColumna("Dirección", col, 150, HAlign.Left, False)
         .Columns(Entidades.Usuario.Columnas.MailUsuario.ToString()).FormatearColumna("Usuario Correo", col, 150, HAlign.Left, False)
         .Columns(Entidades.Usuario.Columnas.MailPassword.ToString()).FormatearColumna("Contraseña", col, 150, HAlign.Left, False)

         .Columns(Entidades.Usuario.Columnas.MailRequiereSSL.ToString()).FormatearColumna("SSL", col, 60, HAlign.Center, False)
         .Columns(Entidades.Usuario.Columnas.MailRequiereAutenticacion.ToString()).FormatearColumna("Autenticación", col, 60, HAlign.Center, False)

         .Columns(Entidades.Usuario.Columnas.MailCantxMinuto.ToString()).FormatearColumna("Correos x Minuto", col, 80, HAlign.Right, False)
         .Columns(Entidades.Usuario.Columnas.MailCantxHora.ToString()).FormatearColumna("Correos x Hora", col, 80, HAlign.Right, False)

         dgvDatos.AgregarFiltroEnLinea({Entidades.Usuario.Columnas.Nombre.ToString(),
                                        Entidades.Usuario.Columnas.MailUsuario.ToString(),
                                        Entidades.Usuario.Columnas.CorreoElectronico.ToString()})
      End With
   End Sub

   Private Const PasswordEnGrilla As String = "****************"

   Protected Overrides Function ProcesarDataTable(dt As DataTable) As DataTable
      For Each dr As DataRow In dt.Rows
         dr(Entidades.Usuario.Columnas.MailPassword.ToString()) = PasswordEnGrilla
      Next
      Return MyBase.ProcesarDataTable(dt)
   End Function

#End Region

End Class
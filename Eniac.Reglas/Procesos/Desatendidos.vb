Public Class Desatendidos

   Public Function InicializaAplicacion(parametros As IEnumerable(Of String)) As ParametrosInicio
      Dim params = CompletaParametrosConValoresPorDefecto(LeeParametros(parametros.ToArray()))
      Reglas.Publicos.VerificaConfiguracionRegional()

      My.Application.Log.WriteEntry(String.Format("Desatendidos.CuandoInicioElExe - ParametrosInicio: {0}", params), TraceEventType.Verbose)

      Return ConfiguroAplicacionConParametros(params)
   End Function

   Public Sub CuandoInicioElExe(abrirPantalla As Action(Of Entidades.Funcion))

      My.Application.Log.WriteEntry(String.Format("Desatendidos.CuandoInicioElExe - Inicia"), TraceEventType.Verbose)

      Try
         Dim params As ParametrosInicio
         params = CompletaParametrosConValoresPorDefecto(LeeParametros(Environment.GetCommandLineArgs()))

         My.Application.Log.WriteEntry(String.Format("Desatendidos.CuandoInicioElExe - ParametrosInicio: {0}", params), TraceEventType.Verbose)

         ControlaLoginYPermisosFuncion(ConfiguroAplicacionConParametros(params))

         Dim funcion As Entidades.Funcion = New Reglas.Funciones().GetUna(params.IdFuncion, cargaDocumentos:=False, cargaVinculadas:=False)

         Dim currentSecurityProtocol As Net.SecurityProtocolType = System.Net.ServicePointManager.SecurityProtocol
         Try
            Try
               If Reglas.Publicos.WebArchivos.HabilitarTLS1_1 Then
                  currentSecurityProtocol = currentSecurityProtocol Or DirectCast(768, Net.SecurityProtocolType)
                  System.Net.ServicePointManager.SecurityProtocol = currentSecurityProtocol
               End If
            Catch ex As Exception
               Throw New Exception("Error habilitando TLS 1.1", ex)
            End Try

            Try
               If Reglas.Publicos.WebArchivos.HabilitarTLS1_2 Then
                  currentSecurityProtocol = currentSecurityProtocol Or DirectCast(3072, Net.SecurityProtocolType)
                  System.Net.ServicePointManager.SecurityProtocol = currentSecurityProtocol
               End If
            Catch ex As Exception
               Throw New Exception("Error habilitando TLS 1.2", ex)
            End Try
         Catch ex As Exception
            My.Application.Log.WriteEntry(String.Format("Desatendidos.CuandoInicioElExe - {0}", ex.ToString()), TraceEventType.Error)
            Console.WriteLine(String.Format("ERROR: {0}", ex.ToString()))
         End Try

         My.Application.Log.WriteEntry(String.Format("Desatendidos.CuandoInicioElExe - Antes de abrir pantalla"), TraceEventType.Verbose)
         abrirPantalla(funcion)

      Catch ex As Exception
         My.Application.Log.WriteEntry(String.Format("Desatendidos.CuandoInicioElExe - {0}", ex.ToString()), TraceEventType.Error)
         Console.WriteLine(String.Format("ERROR: {0}", ex.ToString()))
      End Try
      My.Application.Log.WriteEntry(String.Format("Desatendidos.CuandoInicioElExe - Finaliza"), TraceEventType.Verbose)
   End Sub

   Private Function LeeParametros(args As String()) As ParametrosInicio
      Dim params As ParametrosInicio = New ParametrosInicio()
      For i As Integer = 1 To args.Length - 1
         Dim arg As String = args(i).ToLower()
         Dim nextArg As String = If(args.Length > i + 1, args(i + 1), String.Empty).ToLower()

         If arg = "--servidor" Or arg = "/s" Then
            params.Servidor = nextArg
            i += 1
         ElseIf arg = "--base" Or arg = "/b" Then
            params.Base = nextArg
            i += 1
         ElseIf (arg = "--idsucursal" Or arg = "/i") And IsNumeric(nextArg) Then
            params.IdSucursal = Integer.Parse(nextArg)
            i += 1
         ElseIf arg = "--usuario" Or arg = "/u" Then
            params.Usuario = nextArg
            i += 1
         ElseIf arg = "--contraseña" Or arg = "--contrasena" Or arg = "/c" Then
            params.Contrasena = nextArg
            i += 1
         ElseIf arg = "--comando" Or arg = "--funcion" Or arg = "/f" Then
            params.IdFuncion = nextArg
            i += 1
         Else
            Throw New ArgumentException(String.Format("El parametro {0} es inválido", arg), arg)
         End If
      Next
      Return params
   End Function

   Private Function CompletaParametrosConValoresPorDefecto(params As ParametrosInicio) As ParametrosInicio

      If String.IsNullOrWhiteSpace(params.Servidor) Then
         If IO.File.Exists("Servidor.txt") Then
            params.Servidor = IO.File.ReadAllText("Servidor.txt")
         End If
      End If
      If String.IsNullOrWhiteSpace(params.Base) Then
         If IO.File.Exists("BaseDefecto.txt") Then
            params.Base = IO.File.ReadAllText("BaseDefecto.txt")
         End If
      End If

      Return params
   End Function

   Private Function ConfiguroAplicacionConParametros(params As ParametrosInicio) As ParametrosInicio
      Ayudantes.Conexiones.Servidor = params.Servidor
      Ayudantes.Conexiones.Base = params.Base
      Ayudantes.Conexiones.BaseSegura = params.Base

      Dim rSucursal As Reglas.Sucursales = New Reglas.Sucursales()
      Dim sucursal As Entidades.Sucursal
      If params.IdSucursal > 0 Then
         sucursal = rSucursal.GetUna(params.IdSucursal, True)
      Else
         sucursal = rSucursal.GetEstoyAca(True)
      End If

      Try
         actual.Sistema = System.Configuration.ConfigurationManager.AppSettings("BaseBackup").ToString()
      Catch ex As Exception
         actual.Sistema = "SIGA"
      End Try
      actual.Nombre = params.Usuario.ToLower()
      actual.Pwd = params.Contrasena
      actual.Sucursal = sucursal
      actual.Empresa = Publicos.NombreEmpresa

      Dim rUsuario = New Reglas.Usuarios()
      Dim usuario = rUsuario.GetUnoConMail(actual.Nombre)

      actual.MailConfig = usuario.MailConfig
      actual.NivelAutorizacion = usuario.NivelAutorizacion

      actual.NombreLogo = Publicos.NombreLogo
      actual.Logo = Publicos.Logo(sucursal)

      Return params
   End Function

   Private Function ControlaLoginYPermisosFuncion(params As ParametrosInicio) As ParametrosInicio

      ValidarUsuario(params)

      If Not New Usuarios().TienePermisos(params.IdFuncion) Then
         Throw New Exception("No tiene permisos")
      End If

      Return params
   End Function

   Private Function ValidarUsuario(params As ParametrosInicio) As ParametrosInicio
      Dim rUsuarios As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
      If rUsuarios.GetUno(params.Usuario) Is Nothing Then
         Throw New Exception("Usuario Inexistente")
      End If
      If Not rUsuarios.EsValido(params.Usuario, params.Contrasena) Then
         Throw New Exception("Clave Incorrecta")
      End If
      If Not rUsuarios.EsUsuarioActivo(params.Usuario) Then
         Throw New Exception("Usuario No Activo")
      End If

      Return params
   End Function

   Public Class ParametrosInicio
      Public Property Servidor As String
      Public Property Base As String
      Public Property IdSucursal As Integer
      Public Property Usuario As String
      Public Property Contrasena As String

      Public Property IdFuncion As String

      Public Overrides Function ToString() As String
         Return String.Format("Servidor: {0} - Base: {1} - IdSucursal: {2} - Usuario: {3} - Contraseña: **** - IdFuncion: {5}",
                              Servidor, Base, IdSucursal, Usuario, Contrasena, IdFuncion)
      End Function

   End Class

End Class
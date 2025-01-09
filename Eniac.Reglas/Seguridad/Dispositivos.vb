Option Strict On
Option Explicit On
Public Class Dispositivos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Dispositivos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Merge(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Dispositivos = New SqlServer.Dispositivos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Dispositivos(Me.da).Dispositivos_GA()
   End Function
#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim en As Entidades.Dispositivo = DirectCast(entidad, Entidades.Dispositivo)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Dispositivos = New SqlServer.Dispositivos(Me.da)



         Dim cr As Eniac.Ayudantes.Criptografia = New Eniac.Ayudantes.Criptografia()

         'GAR: 07/01/2023. En el login no obtiene este valor asique viene. Modifique el Merge para que no lo grabe.
         'Por ahora no ejecuto este control. Lo dejo como idea.
         'If String.IsNullOrWhiteSpace(en.Control1) Then
         '   en.Control1 = "01/01/2000;** INICIAL**"
         'End If

         If String.IsNullOrWhiteSpace(en.Control1) Then
            en.Control1 = ""
         End If

         Dim Control1Encriptado = cr.EncryptString128Bit(en.Control1, "clave")

         Select Case tipo

            Case TipoSP._I
               sql.Dispositivos_I(en.IdDispositivo, en.NombreDispositivo, en.FechaUltimoLogin, en.UsuarioUltimoLogin, en.IdTipoDispositivo,
                                  en.SistemaOperativo, en.ArquitecturaSO, en.NumeroSerieDiscoRigido, en.DireccionMAC,
                                  en.NumeroSerieMotherboard, en.NumeroSerieDiscoPrimario, en.ResolucionPantalla, en.VersionFramework, en.Activo, Control1Encriptado)

            Case TipoSP._U
               sql.Dispositivos_U(en.IdDispositivo, en.NombreDispositivo, en.FechaUltimoLogin, en.UsuarioUltimoLogin, en.IdTipoDispositivo,
                                  en.SistemaOperativo, en.ArquitecturaSO, en.NumeroSerieDiscoRigido, en.DireccionMAC,
                                  en.NumeroSerieMotherboard, en.NumeroSerieDiscoPrimario, en.ResolucionPantalla, en.VersionFramework, en.Activo, Control1Encriptado)

            Case TipoSP._M
               sql.Dispositivos_M(en.IdDispositivo, en.NombreDispositivo, en.FechaUltimoLogin, en.UsuarioUltimoLogin, en.IdTipoDispositivo,
                                  en.SistemaOperativo, en.ArquitecturaSO, en.NumeroSerieDiscoRigido, en.DireccionMAC,
                                  en.NumeroSerieMotherboard, en.NumeroSerieDiscoPrimario, en.ResolucionPantalla, en.VersionFramework, Control1Encriptado)  ', en.Activo)

            Case TipoSP._D
               'GAR: 07/01/2023. No deberia borrarse porque hay un control de consistencia de todas las PC.
               'sql.Dispositivos_D(en.IdDispositivo)
               Throw New Exception(String.Format("Operacion NO Permitida. El dispositivo {0} NO Debe Eliminarse.", en.NombreDispositivo))

         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(o As Entidades.Dispositivo, dr As DataRow)
      With o
         .IdDispositivo = dr(Eniac.Entidades.Dispositivo.Columnas.IdDispositivo.ToString()).ToString()
         .NombreDispositivo = dr(Eniac.Entidades.Dispositivo.Columnas.NombreDispositivo.ToString()).ToString()
         .FechaUltimoLogin = DateTime.Parse(dr(Eniac.Entidades.Dispositivo.Columnas.FechaUltimoLogin.ToString()).ToString())
         .UsuarioUltimoLogin = dr(Eniac.Entidades.Dispositivo.Columnas.UsuarioUltimoLogin.ToString()).ToString()
         .IdTipoDispositivo = dr(Eniac.Entidades.Dispositivo.Columnas.IdTipoDispositivo.ToString()).ToString()
         .SistemaOperativo = dr(Eniac.Entidades.Dispositivo.Columnas.SistemaOperativo.ToString()).ToString()
         .ArquitecturaSO = dr(Eniac.Entidades.Dispositivo.Columnas.ArquitecturaSO.ToString()).ToString()
         .NumeroSerieDiscoPrimario = dr(Eniac.Entidades.Dispositivo.Columnas.NumeroSerieDiscoPrimario.ToString()).ToString()
         .NumeroSerieDiscoRigido = dr(Eniac.Entidades.Dispositivo.Columnas.NumeroSerieDiscoRigido.ToString()).ToString()
         .DireccionMAC = dr(Eniac.Entidades.Dispositivo.Columnas.DireccionMAC.ToString()).ToString()
         .NumeroSerieMotherboard = dr(Eniac.Entidades.Dispositivo.Columnas.NumeroSerieMotherboard.ToString()).ToString()
         .ResolucionPantalla = dr(Eniac.Entidades.Dispositivo.Columnas.ResolucionPantalla.ToString()).ToString()
         .VersionFramework = dr(Eniac.Entidades.Dispositivo.Columnas.VersionFramework.ToString()).ToString()
         .Activo = Boolean.Parse(dr(Eniac.Entidades.Dispositivo.Columnas.Activo.ToString()).ToString())

         Dim cr As Eniac.Ayudantes.Criptografia = New Eniac.Ayudantes.Criptografia()
         Dim valor = dr(Eniac.Entidades.Dispositivo.Columnas.Control1.ToString()).ToString()

         .Control1 = cr.DecryptString128Bit(valor, "clave")

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.Dispositivo)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Dispositivo
      Dim oLis As List(Of Entidades.Dispositivo) = New List(Of Entidades.Dispositivo)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Dispositivo()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(idDispositivo As String) As Entidades.Dispositivo
      Return GetUno(idDispositivo, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idDispositivo As String, accion As AccionesSiNoExisteRegistro) As Entidades.Dispositivo

      Dim sql As SqlServer.Dispositivos = New SqlServer.Dispositivos(Me.da)

      Dim dt As DataTable = sql.Dispositivos_G1(idDispositivo)

      Dim o As Entidades.Dispositivo = New Entidades.Dispositivo()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("El dispositivo {0} no existe. Por favor verifique.", idDispositivo))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            o = Nothing
         End If
      End If

      Return o
   End Function

   Public Function GetLicenciasVsDispositivos() As DataTable

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.Dispositivos = New SqlServer.Dispositivos(da)
         Return sql.GetLicenciasVsDispositivos(Publicos.DiasControlDeLicencias)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

#End Region

End Class
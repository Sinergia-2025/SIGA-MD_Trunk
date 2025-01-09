Public Class ClientesDispositivos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ClienteDispositivo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Inserta(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Actualiza(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Borra(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ClientesDispositivos = New SqlServer.ClientesDispositivos(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ClientesDispositivos(da).ClientesDispositivos_GA(actual.Sucursal.Id)
   End Function
#End Region

#Region "Metodos Privados"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteDispositivo), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteDispositivo), TipoSP._U)
   End Sub

   Public Sub Merge(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteDispositivo), TipoSP._M)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteDispositivo), TipoSP._D)
   End Sub

   Private Sub EjecutaSP(ByVal en As Entidades.ClienteDispositivo, ByVal tipo As TipoSP)

      Dim sqlC As SqlServer.ClientesDispositivos = New SqlServer.ClientesDispositivos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ClientesDispositivos_I(en.IdCliente, en.NombreServidor, en.BaseDatos, en.IdDispositivo, en.NombreDispositivo,
                                        en.FechaUltimoLogin, en.UsuarioUltimoLogin,
                                        en.IdTipoDispositivo, en.SistemaOperativo, en.ArquitecturaSO, en.NumeroSerieDiscoRigido)
         Case TipoSP._U
            sqlC.ClientesDispositivos_U(en.IdCliente, en.NombreServidor, en.BaseDatos, en.IdDispositivo, en.NombreDispositivo,
                                        en.FechaUltimoLogin, en.UsuarioUltimoLogin,
                                        en.IdTipoDispositivo, en.SistemaOperativo, en.ArquitecturaSO, en.NumeroSerieDiscoRigido)
         Case TipoSP._D
            sqlC.ClientesDispositivos_D(en.IdCliente, en.NombreServidor, en.BaseDatos, en.IdDispositivo)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ClienteDispositivo, ByVal dr As DataRow)
      With o
         .IdCliente = Long.Parse(dr(Entidades.ClienteDispositivo.Columnas.IdCliente.ToString()).ToString())
         .NombreServidor = dr(Entidades.ClienteDispositivo.Columnas.NombreServidor.ToString()).ToString()
         .BaseDatos = dr(Entidades.ClienteDispositivo.Columnas.BaseDatos.ToString()).ToString()
         .IdDispositivo = dr(Entidades.ClienteDispositivo.Columnas.IdDispositivo.ToString()).ToString()
         .NombreDispositivo = dr(Entidades.ClienteDispositivo.Columnas.NombreDispositivo.ToString()).ToString()
         .FechaUltimoLogin = DateTime.Parse(dr(Entidades.ClienteDispositivo.Columnas.FechaUltimoLogin.ToString()).ToString())
         .UsuarioUltimoLogin = dr(Entidades.ClienteDispositivo.Columnas.UsuarioUltimoLogin.ToString()).ToString()
         .IdTipoDispositivo = dr(Entidades.ClienteDispositivo.Columnas.IdTipoDispositivo.ToString()).ToString()
         .SistemaOperativo = dr(Entidades.ClienteDispositivo.Columnas.SistemaOperativo.ToString()).ToString()
         .ArquitecturaSO = dr(Entidades.ClienteDispositivo.Columnas.ArquitecturaSO.ToString()).ToString()
         .NumeroSerieDiscoRigido = dr(Entidades.ClienteDispositivo.Columnas.NumeroSerieDiscoRigido.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idCliente As Long,
                          nombreServidor As String,
                          baseDatos As String,
                          idDispositivo As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ClienteDispositivo
      Dim dt As DataTable = New SqlServer.ClientesDispositivos(da).ClientesDispositivos_G1(idCliente, nombreServidor, baseDatos, idDispositivo)
      Dim o As Entidades.ClienteDispositivo = New Entidades.ClienteDispositivo()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         ElseIf accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No se encontró el Dispositivo del Cliente"))
         End If
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.ClienteDispositivo)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.ClienteDispositivo), dr), Function() New Entidades.ClienteDispositivo())
   End Function

   Public Sub ImportarDesdeJson(codigoCliente As Long,
                                nombreServidor As String,
                                baseDatos As String,
                                dcRemoto As Entidades.JSonEntidades.SSSServicioWeb.Dispositivo())
      Try
         da.OpenConection()
         da.BeginTransaction()
         Dim rCliente As Clientes = New Clientes()
         Dim dtClientes As DataTable = rCliente.GetFiltradoPorCodigo(codigoCliente, False, False)
         If dtClientes.Rows.Count = 0 Then
            Throw New Exception(String.Format("No existe cliente con el código {0}", codigoCliente))
         End If
         Dim idCliente As Long = Long.Parse(dtClientes.Rows(0)("IdCliente").ToString())

         Borra(New Entidades.ClienteDispositivo() With {.IdCliente = idCliente})

         For Each dc As Entidades.JSonEntidades.SSSServicioWeb.Dispositivo In dcRemoto
            Inserta(New Entidades.ClienteDispositivo() _
                        With {.IdCliente = idCliente,
                              .NombreServidor = nombreServidor,
                              .BaseDatos = baseDatos,
                              .IdDispositivo = dc.IdDispositivo,
                              .NombreDispositivo = dc.NombreDispositivo,
                              .FechaUltimoLogin = DateTime.ParseExact(dc.FechaUltimoLogin, Entidades.JSonEntidades.SSSServicioWeb.Dispositivo.FormatoFecha, Globalization.CultureInfo.InvariantCulture),
                              .UsuarioUltimoLogin = dc.UsuarioUltimoLogin,
                              .IdTipoDispositivo = dc.IdTipoDispositivo,
                              .SistemaOperativo = dc.SistemaOperativo,
                              .ArquitecturaSO = dc.ArquitecturaSO,
                              .NumeroSerieDiscoRigido = dc.NumeroSerieDiscoRigido})
         Next

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function GetInfClienteDispositivos(idCliente As Long, desde As Date?, hasta As Date?) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ClientesDispositivos(da).
                                                GetInfClienteDispositivos(idCliente, desde, hasta))
   End Function

#End Region

End Class
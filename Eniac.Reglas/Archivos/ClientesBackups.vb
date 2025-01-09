#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ClientesBackups
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ClienteBackup.NombreTabla
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
      Dim sql As SqlServer.ClientesBackups = New SqlServer.ClientesBackups(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
      Return New SqlServer.ClientesBackups(Me.da).ClientesBackups_GA()
   End Function
   Public Function InfClientesBackups(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Return New SqlServer.ClientesBackups(Me.da).GetInfClientesBackups(idCliente, fechaDesde, fechaHasta)
   End Function

#End Region

#Region "Metodos Privados"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteBackup), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteBackup), TipoSP._U)
   End Sub

   Public Sub Merge(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteBackup), TipoSP._M)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteBackup), TipoSP._D)
   End Sub

   Private Sub EjecutaSP(ByVal en As Entidades.ClienteBackup, ByVal tipo As TipoSP)

      Dim sqlC As SqlServer.ClientesBackups = New SqlServer.ClientesBackups(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ClientesBackups_I(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioBackup, en.FechaFinBackup, en.Activo)
         Case TipoSP._U
            sqlC.ClientesBackups_U(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioBackup, en.FechaFinBackup, en.Activo)
         Case TipoSP._M
            sqlC.ClientesBackups_M(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioBackup, en.FechaFinBackup, en.Activo)
         Case TipoSP._D
            sqlC.ClientesBackups_D(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ClienteBackup, ByVal dr As DataRow)
      With o
         .IdCliente = Long.Parse(dr(Entidades.ClienteBackup.Columnas.IdCliente.ToString()).ToString())
         .NombreServidor = dr(Entidades.ClienteBackup.Columnas.NombreServidor.ToString()).ToString()
         .BaseDatos = dr(Entidades.ClienteBackup.Columnas.BaseDatos.ToString()).ToString()
         .FechaEjecucion = DateTime.Parse(dr(Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString()).ToString())
         If IsDate(dr(Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString())) Then
            .FechaInicioBackup = DateTime.Parse(dr(Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString()).ToString())
         End If
         If IsDate(dr(Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString())) Then
            .FechaFinBackup = DateTime.Parse(dr(Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString()).ToString())
         End If
         .Activo = Boolean.Parse(dr(Entidades.ClienteBackup.Columnas.Activo.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idCliente As Long,
                          nombreServidor As String,
                          baseDatos As String,
                          FechaEjecucion As DateTime,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ClienteBackup

      Return CargaEntidad(New SqlServer.ClientesBackups(da).ClientesBackups_G1(idCliente, nombreServidor, baseDatos, FechaEjecucion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ClienteBackup(),
                          accion, Function() String.Format("No se encontró el Backup del Cliente"))
   End Function



   Public Function GetTodos() As List(Of Entidades.ClienteBackup)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.ClienteBackup), dr), Function() New Entidades.ClienteBackup())
   End Function

   Public Sub ImportarDesdeJson(ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim rCliente As Clientes = New Clientes()
         Dim dtClientes As DataTable = rCliente.GetFiltradoPorCodigo(ejecucion.CodigoCliente, False, False)
         If dtClientes.Rows.Count = 0 Then
            Throw New Exception(String.Format("No existe cliente con el código {0}", ejecucion.CodigoCliente))
         End If
         Dim idCliente As Long = Long.Parse(dtClientes.Rows(0)("IdCliente").ToString())

         'Debo actualizar todo menos el estado de activo
         Dim sqlC As SqlServer.ClientesBackups = New SqlServer.ClientesBackups(da)
         sqlC.ClientesBackups_M(idCliente, ejecucion.NombreServidor, ejecucion.BaseDatos, ejecucion.FechaEjecucion, ejecucion.FechaInicio, ejecucion.FechaFinalizacion,
                                activo:=Nothing)

         'Merge(New Entidades.ClienteBackup() _
         '          With {.IdCliente = idCliente,
         '                .NombreServidor = ejecucion.NombreServidor,
         '                .BaseDatos = ejecucion.BaseDatos,
         '                .FechaEjecucion = ejecucion.FechaEjecucion,
         '                .FechaInicioBackup = ejecucion.FechaInicio,
         '                .FechaFinBackup = ejecucion.FechaFinalizacion})

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub


#End Region

End Class
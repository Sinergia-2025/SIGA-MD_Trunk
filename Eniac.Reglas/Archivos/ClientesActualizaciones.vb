#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ClientesActualizaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ClienteActualizacion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ClienteActualizacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ClienteActualizacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ClienteActualizacion)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ClientesActualizaciones = New SqlServer.ClientesActualizaciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
      Return New SqlServer.ClientesActualizaciones(Me.da).ClientesActualizaciones_GA()
   End Function
   Public Function InfClientesActualizaciones(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Return New SqlServer.ClientesActualizaciones(Me.da).GetInfClientesActualizaciones(idCliente, fechaDesde, fechaHasta)
   End Function

#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Eniac.Entidades.ClienteActualizacion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.ClienteActualizacion)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Eniac.Entidades.ClienteActualizacion)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.ClienteActualizacion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.ClienteActualizacion, tipo As TipoSP)

      Dim sqlC As SqlServer.ClientesActualizaciones = New SqlServer.ClientesActualizaciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ClientesActualizaciones_I(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioActualizacion, en.FechaFinActualizacion,
                                           en.IdUnico,
                                           en.Estado, en.EstadoDescargaScripts, en.EstadoDescargaInstalador,
                                           en.EstadoBackup, en.EstadoEjecucionScripts, en.EstadoEjecucionInstalador,
                                           en.Activo)
         Case TipoSP._U
            sqlC.ClientesActualizaciones_U(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioActualizacion, en.FechaFinActualizacion,
                                           en.IdUnico,
                                           en.Estado, en.EstadoDescargaScripts, en.EstadoDescargaInstalador,
                                           en.EstadoBackup, en.EstadoEjecucionScripts, en.EstadoEjecucionInstalador,
                                           en.Activo)
         Case TipoSP._M
            sqlC.ClientesActualizaciones_M(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioActualizacion, en.FechaFinActualizacion,
                                           en.IdUnico,
                                           en.Estado, en.EstadoDescargaScripts, en.EstadoDescargaInstalador,
                                           en.EstadoBackup, en.EstadoEjecucionScripts, en.EstadoEjecucionInstalador,
                                           en.Activo)
         Case TipoSP._D
            sqlC.ClientesActualizaciones_D(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ClienteActualizacion, dr As DataRow, cargaSucesos As Boolean)
      With o
         .IdCliente = Long.Parse(dr(Entidades.ClienteActualizacion.Columnas.IdCliente.ToString()).ToString())
         .NombreServidor = dr(Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString()).ToString()
         .BaseDatos = dr(Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString()).ToString()
         .FechaEjecucion = DateTime.Parse(dr(Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString()).ToString())
         If IsDate(dr(Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString())) Then
            .FechaInicioActualizacion = DateTime.Parse(dr(Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString()).ToString())
         End If
         If IsDate(dr(Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString())) Then
            .FechaFinActualizacion = DateTime.Parse(dr(Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString()).ToString())
         End If
         .IdUnico = dr(Entidades.ClienteActualizacion.Columnas.IdUnico.ToString()).ToString()
         .Estado = dr(Entidades.ClienteActualizacion.Columnas.Estado.ToString()).ToString().StringToEnum(Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         .EstadoDescargaScripts = dr(Entidades.ClienteActualizacion.Columnas.EstadoDescargaScripts.ToString()).ToString().StringToEnum(Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         .EstadoDescargaInstalador = dr(Entidades.ClienteActualizacion.Columnas.EstadoDescargaInstalador.ToString()).ToString().StringToEnum(Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         .EstadoBackup = dr(Entidades.ClienteActualizacion.Columnas.EstadoBackup.ToString()).ToString().StringToEnum(Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         .EstadoEjecucionScripts = dr(Entidades.ClienteActualizacion.Columnas.EstadoEjecucionScripts.ToString()).ToString().StringToEnum(Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         .EstadoEjecucionInstalador = dr(Entidades.ClienteActualizacion.Columnas.EstadoEjecucionInstalador.ToString()).ToString().StringToEnum(Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         .Activo = Boolean.Parse(dr(Entidades.ClienteActualizacion.Columnas.Activo.ToString()).ToString())

         .CodigoCliente = dr.Field(Of Long)(Entidades.Cliente.Columnas.CodigoCliente.ToString())
         .NombreCliente = dr.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())

         If cargaSucesos Then
            .Sucesos = New Reglas.ClientesActualizacionesSucesos(da).GetTodos(.IdCliente, .NombreServidor, .BaseDatos, .FechaEjecucion)
         End If

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idCliente As Long,
                          nombreServidor As String,
                          baseDatos As String,
                          fechaEjecucion As DateTime,
                          cargaSucesos As Boolean,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ClienteActualizacion

      Return CargaEntidad(New SqlServer.ClientesActualizaciones(da).ClientesActualizaciones_G1(idCliente, nombreServidor, baseDatos, fechaEjecucion),
                          Sub(o, dr) CargarUno(o, dr, cargaSucesos), Function() New Entidades.ClienteActualizacion(),
                          accion, Function() String.Format("No se encontró el Backup del Cliente"))
   End Function

   Public Function GetTodos() As List(Of Entidades.ClienteActualizacion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.ClienteActualizacion), dr, cargaSucesos:=False), Function() New Entidades.ClienteActualizacion())
   End Function

   Public Sub ImportarDesdeJson(ejecucion As Entidades.JSonEntidades.SSSServicioWeb.Ejecuciones, sucesos As List(Of Entidades.JSonEntidades.SSSServicioWeb.Sucesos))
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim rCliente As Clientes = New Clientes()
         Dim dtClientes As DataTable = rCliente.GetFiltradoPorCodigo(ejecucion.CodigoCliente, False, False)
         If dtClientes.Rows.Count = 0 Then
            Throw New Exception(String.Format("No existe cliente con el código {0}", ejecucion.CodigoCliente))
         End If
         Dim idCliente As Long = dtClientes.Rows(0).ValorNumericoPorDefecto("IdCliente", 0L)

         Dim estado As Entidades.ClienteActualizacion.EstadoActualizacion? = Nothing
         Dim estadoDescargaScripts As Entidades.ClienteActualizacion.EstadoActualizacion? = Nothing
         Dim estadoDescargaInstalador As Entidades.ClienteActualizacion.EstadoActualizacion? = Nothing
         Dim estadoBackup As Entidades.ClienteActualizacion.EstadoActualizacion? = Nothing
         Dim estadoEjecucionScripts As Entidades.ClienteActualizacion.EstadoActualizacion? = Nothing
         Dim estadoEjecucionInstalador As Entidades.ClienteActualizacion.EstadoActualizacion? = Nothing


         For Each s As Entidades.JSonEntidades.SSSServicioWeb.Sucesos In sucesos.OrderBy(Function(x) x.TipoSuceso)
            Select Case s.TipoSuceso
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_InicioBusqueda
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_InicioBusqueda_Error
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_SinVersion
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Finalizado
                  If estado <> Entidades.ClienteActualizacion.EstadoActualizacion.ConError Then
                     estado = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
                  End If

               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Scripts_Grabando
                  estadoDescargaScripts = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Scripts_Grabados
                  estadoDescargaScripts = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Scripts_ErrorBajando
                  estadoDescargaScripts = Entidades.ClienteActualizacion.EstadoActualizacion.ConError
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError

               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_MSI_IniciandoBajada
                  estadoDescargaInstalador = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_MSI_FinBajada
                  estadoDescargaInstalador = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_MSI_Error_BajandoInstaladores
                  estadoDescargaInstalador = Entidades.ClienteActualizacion.EstadoActualizacion.ConError
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError

               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Backup_Inicio
                  estadoBackup = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Backup_Fin
                  estadoBackup = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Backup_Error
                  estadoBackup = Entidades.ClienteActualizacion.EstadoActualizacion.ConError
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError

               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_EjecScripts_Inicio
                  estadoEjecucionScripts = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_EjecScripts_Fin
                  If estadoEjecucionScripts = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio Then
                     estadoEjecucionScripts = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
                  End If
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_EjecScripts_Error
                  estadoEjecucionScripts = Entidades.ClienteActualizacion.EstadoActualizacion.ConError
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError

               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_InstalandoMSI_Inicio
                  estadoEjecucionInstalador = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_InstalandoMSI_Fin
                  estadoEjecucionInstalador = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
               Case Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_InstalandoMSI_Error
                  estadoEjecucionInstalador = Entidades.ClienteActualizacion.EstadoActualizacion.ConError
                  estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError

            End Select

         Next

         'Debo actualizar todo menos el estado de activo
         Dim sqlC As SqlServer.ClientesActualizaciones = New SqlServer.ClientesActualizaciones(da)
         sqlC.ClientesActualizaciones_M(idCliente, ejecucion.NombreServidor, ejecucion.BaseDatos, ejecucion.FechaEjecucion, ejecucion.FechaInicio, ejecucion.FechaFinalizacion,
                                        ejecucion.IdUnico.ToString(),
                                        estado, estadoDescargaScripts, estadoDescargaInstalador, estadoBackup, estadoEjecucionScripts, estadoEjecucionInstalador,
                                        activo:=Nothing)

         Dim rSucesos As Reglas.ClientesActualizacionesSucesos = New ClientesActualizacionesSucesos(da)

         For Each s As Entidades.JSonEntidades.SSSServicioWeb.Sucesos In sucesos.OrderBy(Function(x) x.Orden)
            Dim mensaje As String = String.Empty
            Dim nombreScript As String = String.Empty
            Dim script As String = String.Empty

            If s.TipoSuceso = Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_EjecScripts_Error Or
               s.TipoSuceso = Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_EjecScripts_Exitoso Then
               Try
                  Dim dic As Dictionary(Of String, String) = New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Dictionary(Of String, String))(s.Datos)

                  mensaje = If(dic.ContainsKey("Mensaje"), dic("Mensaje"), String.Empty)
                  nombreScript = If(dic.ContainsKey("NombreScript"), dic("NombreScript"), String.Empty)
                  script = If(dic.ContainsKey("Script"), dic("Script"), String.Empty)

               Catch ex As Exception
                  mensaje = String.Empty
                  nombreScript = String.Empty
                  script = String.Empty
               End Try
            Else
               mensaje = s.Datos
            End If

            rSucesos._Merge(New Entidades.ClienteActualizacionSuceso() _
                              With {.IdCliente = idCliente,
                                    .NombreServidor = ejecucion.NombreServidor,
                                    .BaseDatos = ejecucion.BaseDatos,
                                    .FechaEjecucion = ejecucion.FechaEjecucion,
                                    .TipoSuceso = s.TipoSuceso,
                                    .Orden = s.Orden,
                                    .Datos = s.Datos,
                                    .Mensaje = mensaje,
                                    .NombreScript = nombreScript,
                                    .Script = script})
         Next

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ActualizarActivo(idCliente As Long,
                               nombreServidor As String,
                               baseDatos As String,
                               fechaEjecucion As DateTime,
                               activo As Boolean)
      EjecutaConTransaccion(Sub() _ActualizarActivo(idCliente, nombreServidor, baseDatos, fechaEjecucion, activo))
   End Sub
   Friend Sub _ActualizarActivo(idCliente As Long,
                                nombreServidor As String,
                                baseDatos As String,
                                fechaEjecucion As DateTime,
                                activo As Boolean)
      Dim sql As SqlServer.ClientesActualizaciones = New SqlServer.ClientesActualizaciones(da)
      sql.ClientesActualizaciones_U_Activo(idCliente, nombreServidor, baseDatos, fechaEjecucion, activo)
   End Sub

#End Region

End Class
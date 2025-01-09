Namespace Turnos.Handlers
   Public Interface ITurnosCalendariosHandler
      Function GetTodos() As List(Of Entidades.TurnoCalendario)
      Function GetTodos(idCalendario As Integer, fechaDesdeDesde As DateTime?, fechaDesdeHasta As DateTime?) As List(Of Entidades.TurnoCalendario)
      Function GetInvocados(venta As Entidades.Venta) As List(Of Entidades.TurnoCalendario)
      Function GetUno(idTurno As String) As Entidades.TurnoCalendario
      Function GetUno(idTurno As String, accion As Base.AccionesSiNoExisteRegistro) As Entidades.TurnoCalendario

      Sub Inserta(entidad As Entidades.TurnoCalendario)
      Sub Actualiza(entidad As Entidades.TurnoCalendario)
      Sub ActualizaEstadoPorIdUnico(idTurnoUnico As String, estado As Entidades.EstadoTurno)
      Sub Borra(entidad As Entidades.TurnoCalendario)

      Function ControlaCupoDisponible(turnos As List(Of Entidades.TurnoCalendario),
                                      turnoActual As Entidades.TurnoCalendario,
                                      fechaHoraDesde As DateTime,
                                      fechaHoraHasta As DateTime,
                                      cupo As Integer) As Boolean

      ReadOnly Property PuedeEditar() As Boolean
   End Interface


   Public NotInheritable Class TurnosCalendariosHandlerFactory

      Public Shared Function Crear(da As Datos.DataAccess, idCalendario As Integer) As ITurnosCalendariosHandler
         If idCalendario > 0 AndAlso Reglas.Ayudante.Cache.Turnos.CacheCalendarios.Instancia.Buscar(idCalendario).PublicarEnWeb Then
            Return Crear(da, Reglas.Ayudante.Cache.Turnos.CacheCalendarios.Instancia.Buscar(idCalendario).PublicarEnWeb)
         End If
         Return Crear(da, False)
      End Function
      Public Shared Function Crear(da As Datos.DataAccess, publicarEnWeb As Boolean) As ITurnosCalendariosHandler
         If publicarEnWeb Then
            Return New TurnosCalendariosHandlerRemoto(da)
         End If
         Return New TurnosCalendariosHandlerLocal(da)
      End Function
   End Class
End Namespace
Public Class Reservas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "Reservas"
      da = accesoDatos
   End Sub

#End Region

   Public Function Get1(turno As Entidades.TurnoCalendario) As DataTable
      Return Get1(turno.IdTurnoUnico)
   End Function
   Public Function Get1(idTurnoUnico As String) As DataTable
      Return New SqlServer.Reservas(da).Reservas_G1(idTurnoUnico)
   End Function

   Public Sub ActualizaDesdeTurno(turno As Entidades.TurnoCalendario)
      EjecutaConTransaccion(Sub() _ActualizaDesdeTurno(turno))
   End Sub
   Public Sub ActualizaDesdeTurno(turnos As ICollection(Of Entidades.TurnoCalendario))
      EjecutaConTransaccion(Sub() _ActualizaDesdeTurno(turnos))
   End Sub

   Public Sub _ActualizaDesdeTurno(turnos As ICollection(Of Entidades.TurnoCalendario))
      turnos.All(Function(t) _ActualizaDesdeTurno(t))
   End Sub

   Public Function _ActualizaDesdeTurno(turno As Entidades.TurnoCalendario) As Boolean
      Dim sql = New SqlServer.Reservas(da)

      Dim dtReserva = sql.Reservas_G1(turno.IdTurnoUnico)

      If dtReserva.Rows.Count = 0 Then
         Dim estadoAlta = "ALTA"
         Dim idReserva = GetCodigoMaximo() + 1

         sql.Reservas_I(idReserva, turno.IdEmbarcacion, turno.IdCliente, turno.IdTurnoUnico, turno.CantidadPasajeros, turno.FechaDesde, turno.FechaHoraLlegada.IfNull(),
                        turno.IdDestino, turno.DestinoLibre, turno.Calendario.IdNave.IfNull(), idTimonel:=turno.IdCliente,
                        fechaSolicitud:=Now, esEfectiva:=False, estado:=estadoAlta, activo:=True, usuarioSolicitud:=actual.Nombre)


         sql.ReservaEstado_I(idReserva, Now, estadoAlta, actual.Nombre, turno.IdCliente)

      Else
         Dim drReserva = dtReserva.Rows(0)
         Dim idReserva = drReserva.Field(Of Long)("IdReserva")
         Dim estadoReservaCancelado = "CANCELADA"
         Dim estadoTurnoCancelado = "CANCELADO"
         If turno.IdEstadoTurno = estadoTurnoCancelado AndAlso drReserva.Field(Of String)("Estado") <> estadoReservaCancelado Then
            sql.Reservas_U_Estado(idReserva, estadoReservaCancelado, turno.Calendario.IdNave.IfNull())
            sql.ReservaEstado_I(idReserva, Now, estadoReservaCancelado, actual.Nombre, turno.IdCliente)
         End If

      End If
      Return True

   End Function


   Public Sub CancelaDesdeTurno(turno As Entidades.TurnoCalendario)
      EjecutaConTransaccion(Sub() _CancelaDesdeTurno(turno))
   End Sub
   Public Sub CancelaDesdeTurno(turnos As ICollection(Of Entidades.TurnoCalendario))
      EjecutaConTransaccion(Sub() _CancelaDesdeTurno(turnos))
   End Sub
   Public Sub _CancelaDesdeTurno(turnos As ICollection(Of Entidades.TurnoCalendario))
      turnos.All(Function(t) _CancelaDesdeTurno(t))
   End Sub
   Public Function _CancelaDesdeTurno(turno As Entidades.TurnoCalendario) As Boolean
      Dim sql = New SqlServer.Reservas(da)

      Dim dtReserva = sql.Reservas_G1(turno.IdTurnoUnico)
      If dtReserva.Rows.Count > 0 Then
         Dim drReserva = dtReserva.Rows(0)
         Dim idReserva = drReserva.Field(Of Long)("IdReserva")

         Dim estadoReservaCancelado = "CANCELADA"

         If drReserva.Field(Of String)("Estado") <> estadoReservaCancelado Then
            sql.Reservas_U_Estado(idReserva, estadoReservaCancelado, turno.Calendario.IdNave.IfNull())
            sql.ReservaEstado_I(idReserva, Now, estadoReservaCancelado, actual.Nombre, turno.IdCliente)
         End If
      End If
      Return True
   End Function

   Public Function GetCodigoMaximo() As Long
      Return New SqlServer.Reservas(da).GetCodigoMaximo()
   End Function


   Public Function GetSemaforoBotado(idSucursal As Integer, idCliente As Long, idEmbarcacion As Long) As SemaforoBotado
      Return EjecutaConConexion(Function() _GetSemaforoBotado(idSucursal, idCliente, idEmbarcacion))
   End Function
   Public Function _GetSemaforoBotado(idSucursal As Integer, idCliente As Long, idEmbarcacion As Long) As SemaforoBotado
      Dim cliente = GetSemaforoBotadoCliente(idSucursal, idCliente)
      Dim embarcacion = GetSemaforoBotadoEmbarcacion(idSucursal, idCliente, idEmbarcacion)
      Return If(cliente > embarcacion, cliente, embarcacion)
   End Function

   Private Function GetSemaforoBotadoCliente(idSucursal As Integer, idCliente As Long) As SemaforoBotado
      Dim result = SemaforoBotado.VERDE
      If idCliente <> 0 Then
         Dim dt As DataTable = New Reglas.CuentasCorrientesPagos(da)._GetSaldosCtaCte(Nothing, idCliente, Nothing, 0)

         'Si es cero no hay deuda.
         If dt.Rows.Count = 1 Then
            'Podria tener un resultado a favor.
            If Decimal.Parse(dt.Rows(0)("Saldo").ToString()) > 0 Then
               result = GetSemaforoPorDeuda(actual.Sucursal.Id, idCliente)
            End If
         End If
      End If

      Return result
   End Function

   Private Function GetSemaforoBotadoEmbarcacion(idSucursal As Integer, idCliente As Long, idEmbarcacion As Long) As SemaforoBotado
      Dim result = SemaforoBotado.VERDE

      If idEmbarcacion > 0 Then
         Dim dtResponsablesDeEmbarc = New EmbarcacionesClientes(da).GetResponsablesDeCargos(idEmbarcacion)

         If dtResponsablesDeEmbarc.Rows.Count > 0 Then
            'Tenga 1 o muchos (no deberia), tomo el primero
            'Sino, tomo el que pide la embarcacion
            idCliente = dtResponsablesDeEmbarc.Rows(0).Field(Of Long)("IdCliente")
         End If

         result = GetSemaforoBotadoCliente(idSucursal, idCliente)

      End If
      Return result
   End Function

   Private Function GetSemaforoPorDeuda(idSucursal As Integer, idCliente As Long) As SemaforoBotado

      'Se busca la cantidad de meses de la deuda, despues se compara con los parametros

      Dim mesesAdeudados As Long = New CuentasCorrientes().GetMesesDeudaCliente(idSucursal, idCliente)
      'Dim cliente As Entidades.Cliente = New Clientes(da)._GetUno(idCliente)                 ''SACAR?

      Dim limiteMesesDeudaBotado As Integer = Publicos.SiSeN.ReservaSemaforoAmarillo
      Dim limiteMesesDeudaBotadoCliente As Integer? = New Categorias().GetLimiteMesesDeudaBotado(idCliente)
      'SACAR? Traer campos de SiSeN a SIGA
      If limiteMesesDeudaBotadoCliente.HasValue Then
         limiteMesesDeudaBotado = limiteMesesDeudaBotadoCliente.Value
      End If

      If mesesAdeudados < limiteMesesDeudaBotado Then
         'VERDE
         Return SemaforoBotado.VERDE

      ElseIf mesesAdeudados > limiteMesesDeudaBotado Then
         'ROJO
         Return SemaforoBotado.ROJO

      Else
         'AMARILLO
         Return SemaforoBotado.AMARILLO

      End If

   End Function
   Public Enum SemaforoBotado
      VERDE
      AMARILLO
      ROJO
      AZUL
   End Enum


End Class
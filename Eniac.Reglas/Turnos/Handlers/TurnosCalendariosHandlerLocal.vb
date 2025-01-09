Namespace Turnos.Handlers
   Public Class TurnosCalendariosHandlerLocal
      Inherits Base
      Implements ITurnosCalendariosHandler

      Public ReadOnly Property PuedeEditar As Boolean Implements ITurnosCalendariosHandler.PuedeEditar
         Get
            Return True
         End Get
      End Property

      Public Sub New(da As Datos.DataAccess)
         Me.da = da
      End Sub

      Protected Overridable Function NewSql(da As Datos.DataAccess) As SqlServer.TurnosCalendarios
         Return New SqlServer.TurnosCalendarios(da, Publicos.IDAplicacionSinergia)
      End Function
      Protected Overridable Function NewEntidad() As Entidades.TurnoCalendario
         Return New Entidades.TurnoCalendario()
      End Function
      Protected Overridable Sub CargarUno(o As Entidades.TurnoCalendario, dr As DataRow)
         With o
            .IdTurno = Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.IdTurno.ToString()).ToString())
            .IdTurnoUnico = dr.Field(Of String)(Entidades.TurnoCalendario.Columnas.IdTurnoUnico.ToString())
            .Calendario = New Reglas.Calendarios(da).GetUno(dr.Field(Of Integer)(Entidades.TurnoCalendario.Columnas.IdCalendario.ToString()))
            .FechaDesde = DateTime.Parse(dr(Entidades.TurnoCalendario.Columnas.FechaDesde.ToString()).ToString())
            .FechaHasta = DateTime.Parse(dr(Entidades.TurnoCalendario.Columnas.FechaHasta.ToString()).ToString())

            'Para mejorar performance solo cargo los datos necesarios del cliente.
            '.Cliente = New Clientes(da)._GetUno(Long.Parse(dr(Entidades.TurnoCalendario.Columnas.IdCliente.ToString()).ToString()))
            '.Cliente = New Entidades.Cliente()
            .IdCliente = Long.Parse(dr(Entidades.TurnoCalendario.Columnas.IdCliente.ToString()).ToString())
            .CodigoCliente = Long.Parse(dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
            .NombreCliente = dr(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()

            .Observaciones = dr(Entidades.TurnoCalendario.Columnas.Observaciones.ToString()).ToString()
            .IdTipoTurno = dr.Field(Of String)(Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
            .NombreTipoTurno = dr.Field(Of String)(Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString())
            '.EsEfectivo = Boolean.Parse(dr(Entidades.TurnoCalendario.Columnas.EsEfectivo.ToString()).ToString())

            .IdProducto = dr(Entidades.TurnoCalendario.Columnas.IdProducto.ToString()).ToString()
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.PrecioLista.ToString()).ToString()) Then
               .PrecioLista = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.PrecioLista.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.Precio.ToString()).ToString()) Then
               .Precio = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.Precio.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString()).ToString()) Then
               .DescuentoRecargoPorcGral = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString()).ToString()) Then
               .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) Then
               .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString()).ToString()) Then
               .PrecioNeto = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString()).ToString())
            End If

            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.IdSucursal.ToString()).ToString()) Then
               .IdSucursal = Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.IdSucursal.ToString()).ToString())
            End If
            .IdTipoComprobante = dr(Entidades.TurnoCalendario.Columnas.IdTipoComprobante.ToString()).ToString()
            .Letra = dr(Entidades.TurnoCalendario.Columnas.Letra.ToString()).ToString()
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.CentroEmisor.ToString()).ToString()) Then
               .CentroEmisor = Short.Parse(dr(Entidades.TurnoCalendario.Columnas.CentroEmisor.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.NumeroComprobante.ToString()).ToString()) Then
               .NumeroComprobante = Long.Parse(dr(Entidades.TurnoCalendario.Columnas.NumeroComprobante.ToString()).ToString())
            End If
            If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString()).ToString()) Then
               .NumeroSesion = Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString()).ToString())
            End If
            .TurnoProducto = New TurnosCalendariosProductos(da).GetTodos(Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.IdTurno.ToString()).ToString()))
            .IdEstadoTurno = dr.Field(Of String)(Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
            .NombreEstadoTurno = dr.Field(Of String)(Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString())
            '.EstadoTurno = New EstadosTurnos(da).GetUno(dr(Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString()).ToString())
            .IdPatenteVehiculo = dr.Field(Of String)("IdPatenteVehiculo")
            If Publicos.IDAplicacionSinergia = "SISEN" Then
               .IdEmbarcacion = dr.Field(Of Long?)("IdEmbarcacion").IfNull()
               .CodigoEmbarcacion = dr.Field(Of Long?)("CodigoEmbarcacion").IfNull()
               .NombreEmbarcacion = dr.Field(Of String)("NombreEmbarcacion")
            End If

         End With
      End Sub



      Public Function GetTodos() As List(Of Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.GetTodos
         Return GetTodos(idCalendario:=0, fechaDesdeDesde:=Nothing, fechaDesdeHasta:=Nothing)
      End Function
      Public Function GetTodos(idCalendario As Integer, fechaDesdeDesde As DateTime?, fechaDesdeHasta As DateTime?) As List(Of Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.GetTodos
         Dim result = CargaLista(NewSql(da).TurnosCalendarios_GA(idCalendario, fechaDesdeDesde, fechaDesdeHasta),
                           Sub(o, dr) CargarUno(DirectCast(o, Entidades.TurnoCalendario), dr),
                           Function() NewEntidad())
         'Dim b = New TurnosCalendariosHandlerRemoto(Nothing)
         'b.Inserta(result(0))
         'Dim a = b.GetTodos(idCalendario, fechaDesdeDesde, fechaDesdeHasta)
         Return result
      End Function
      Public Function GetInvocados(venta As Entidades.Venta) As List(Of Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.GetInvocados
         Return CargaLista(NewSql(da).TurnosCalendarios_GA(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante),
                           Sub(o, dr) CargarUno(DirectCast(o, Entidades.TurnoCalendario), dr),
                           Function() NewEntidad())
      End Function


      Public Function GetUno(idTurno As String) As Entidades.TurnoCalendario Implements ITurnosCalendariosHandler.GetUno
         Return GetUno(idTurno, AccionesSiNoExisteRegistro.Vacio)
      End Function
      Public Function GetUno(idTurno As String, accion As AccionesSiNoExisteRegistro) As Entidades.TurnoCalendario Implements ITurnosCalendariosHandler.GetUno
         Return CargaEntidad(NewSql(da).TurnosCalendarios_G1(idTurno),
                             Sub(o, dr) CargarUno(o, dr), Function() NewEntidad(),
                             accion, Function() String.Format("No existe un turno con id = {0}", idTurno))
      End Function

      Public Sub Inserta(entidad As Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.Inserta
         Me.EjecutaSP(entidad, TipoSP._I)
      End Sub

      Public Sub Actualiza(entidad As Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.Actualiza
         Me.EjecutaSP(entidad, TipoSP._U)
      End Sub
      Public Sub ActualizaEstadoPorIdUnico(idTurnoUnico As String, estado As Entidades.EstadoTurno) Implements ITurnosCalendariosHandler.ActualizaEstadoPorIdUnico
         Dim sql = NewSql(da)
         Dim dtTurno = sql.TurnosCalendarios_G1(idTurnoUnico)
         If dtTurno.Rows.Count > 0 Then
            Dim idTurno = dtTurno(0).Field(Of Integer)("IdTurno")
            ActualizaEstadoPorIdUnico(idTurno, estado)
         End If
      End Sub

      Public Sub ActualizaEstadoPorIdUnico(idTurno As Integer, estado As Entidades.EstadoTurno)
         Dim sql = NewSql(da)
         sql.ActualizarAtencion(idTurno, estado.IdEstadoTurno)
      End Sub

      Public Sub Borra(entidad As Entidades.TurnoCalendario) Implements ITurnosCalendariosHandler.Borra
         Me.EjecutaSP(entidad, TipoSP._D)
      End Sub



      Private Sub EjecutaSP(en As Entidades.TurnoCalendario, tipo As TipoSP)
         'Dim en As Entidades.TurnoCalendario = DirectCast(entidad, Entidades.TurnoCalendario)
         Dim sqlC As SqlServer.TurnosCalendarios = NewSql(da)
         Select Case tipo
            Case TipoSP._I
               If en.IdTurno = 0 Then
                  en.IdTurno = GetCodigoMaximo() + 1
               End If
               sqlC.TurnosCalendarios_I(en.IdTurno, en.IdTurnoUnico, en.IdCalendario, en.FechaDesde, en.FechaHasta, en.IdCliente, en.Observaciones, en.IdTipoTurno,
                                        en.IdProducto, en.PrecioLista, en.Precio, en.DescuentoRecargoPorcGral, en.DescuentoRecargoPorc1, en.DescuentoRecargoPorc2,
                                        en.PrecioNeto, en.NumeroSesion, en.IdEstadoTurno,
                                        en.IdEmbarcacion, en.IdDestino, en.DestinoLibre, en.CantidadPasajeros, en.FechaHoraLlegada, en.IdPatenteVehiculo)

               ActualizaTurnosCalendariosProductos(en.IdTurno, en.TurnoProducto)

            Case TipoSP._U
               sqlC.TurnosCalendarios_U(en.IdTurno, en.IdTurnoUnico, en.IdCalendario, en.FechaDesde, en.FechaHasta, en.IdCliente, en.Observaciones, en.IdTipoTurno,
                                        en.IdProducto, en.PrecioLista, en.Precio, en.DescuentoRecargoPorcGral, en.DescuentoRecargoPorc1, en.DescuentoRecargoPorc2,
                                        en.PrecioNeto, en.NumeroSesion, en.IdEstadoTurno,
                                        en.IdEmbarcacion, en.IdDestino, en.DestinoLibre, en.CantidadPasajeros, en.FechaHoraLlegada, en.IdPatenteVehiculo)

               ActualizaTurnosCalendariosProductos(en.IdTurno, en.TurnoProducto)
            Case TipoSP._D
               sqlC.TurnosCalendarios_D(en.IdTurno)
               BorrarTurnosCalendariosProductos(en.IdTurno)
         End Select

      End Sub

      Private Function GetCodigoMaximo() As Integer
         Return NewSql(da).GetCodigoMaximo()
      End Function

      Private Sub ActualizaTurnosCalendariosProductos(idTurno As Integer, turnoProductos As List(Of Entidades.TurnosCalendariosProductos))

         If turnoProductos IsNot Nothing Then
            Dim sql As SqlServer.TurnosCalendariosProductos = New SqlServer.TurnosCalendariosProductos(da)
            BorrarTurnosCalendariosProductos(idTurno)
            Dim orden As Integer = 0
            For Each item As Entidades.TurnosCalendariosProductos In turnoProductos
               orden += 1
               sql.TurnosCalendariosProductos_I(idTurno, item.IdProducto, orden, item.NumeroSesion, item.ValorFluencia)
            Next
         End If
      End Sub
      Private Sub BorrarTurnosCalendariosProductos(idTurno As Integer)
         Dim sql As SqlServer.TurnosCalendariosProductos = New SqlServer.TurnosCalendariosProductos(da)
         sql.TurnosCalendariosProductos_D(idTurno, idProducto:=String.Empty, orden:=0)
      End Sub

      Public Function ControlaCupoDisponible(turnos As List(Of Entidades.TurnoCalendario),
                                             turnoActual As Entidades.TurnoCalendario,
                                             fechaHoraDesde As DateTime,
                                             fechaHoraHasta As DateTime,
                                             cupo As Integer) As Boolean Implements ITurnosCalendariosHandler.ControlaCupoDisponible
         Dim contCupos As Integer = 0
         For Each turExistente As Entidades.TurnoCalendario In turnos
            If turExistente.IdTurno <> turnoActual.IdTurno Then
               If turExistente.FechaDesde < fechaHoraHasta And turExistente.FechaHasta > fechaHoraDesde Then
                  contCupos += 1
               End If
            End If
         Next
         Return contCupos < cupo
      End Function

   End Class
End Namespace
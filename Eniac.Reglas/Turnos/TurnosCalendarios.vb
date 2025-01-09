Public Class TurnosCalendarios
   Inherits Eniac.Reglas.Base

   'Private _handler As Turnos.Handlers.ITurnosCalendariosHandler

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TurnosCalendarios"
      da = accesoDatos
      '_handler = Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.TurnoCalendario)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.TurnoCalendario)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.TurnoCalendario)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TurnosCalendarios = NewSql(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return NewSql(da).TurnosCalendarios_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Protected Overridable Function NewSql(da As Datos.DataAccess) As SqlServer.TurnosCalendarios
      Return New SqlServer.TurnosCalendarios(da, Publicos.IDAplicacionSinergia)
   End Function
   'Protected Overridable Function NewSqlTurnosProductos(da As Datos.DataAccess) As SqlServer.TurnosCalendariosProductos
   '   Return New SqlServer.TurnosCalendariosProductos(da)
   'End Function
   'Private Sub EjecutaSP(en As Entidades.TurnoCalendario, tipo As TipoSP)
   '   'Dim en As Entidades.TurnoCalendario = DirectCast(entidad, Entidades.TurnoCalendario)
   '   Dim sqlC As SqlServer.TurnosCalendarios = NewSql(da)
   '   Select Case tipo
   '      Case TipoSP._I
   '         If en.IdTurno = 0 Then
   '            en.IdTurno = GetCodigoMaximo() + 1
   '         End If
   '         sqlC.TurnosCalendarios_I(en.IdTurno, en.IdCalendario, en.FechaDesde, en.FechaHasta, en.IdCliente, en.Observaciones, en.IdTipoTurno,
   '                                  en.IdProducto, en.PrecioLista, en.Precio, en.DescuentoRecargoPorcGral, en.DescuentoRecargoPorc1, en.DescuentoRecargoPorc2,
   '                                  en.PrecioNeto, en.NumeroSesion, en.IdEstadoTurno, en.IdEmbarcacion)

   '         ActualizaTurnosCalendariosProductos(en.IdTurno, en.TurnoProducto)

   '      Case TipoSP._U
   '         sqlC.TurnosCalendarios_U(en.IdTurno, en.IdCalendario, en.FechaDesde, en.FechaHasta, en.IdCliente, en.Observaciones, en.IdTipoTurno,
   '                                  en.IdProducto, en.PrecioLista, en.Precio, en.DescuentoRecargoPorcGral, en.DescuentoRecargoPorc1, en.DescuentoRecargoPorc2,
   '                                  en.PrecioNeto, en.NumeroSesion, en.IdEstadoTurno, en.IdEmbarcacion)

   '         ActualizaTurnosCalendariosProductos(en.IdTurno, en.TurnoProducto)
   '      Case TipoSP._D
   '         sqlC.TurnosCalendarios_D(en.IdTurno)
   '         BorrarTurnosCalendariosProductos(en.IdTurno)
   '   End Select

   'End Sub

   'Protected Overridable Sub CargarUno(o As Entidades.TurnoCalendario, dr As DataRow)
   '   With o
   '      .IdTurno = Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.IdTurno.ToString()).ToString())
   '      .IdCalendario = Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.IdCalendario.ToString()).ToString())
   '      .FechaDesde = DateTime.Parse(dr(Entidades.TurnoCalendario.Columnas.FechaDesde.ToString()).ToString())
   '      .FechaHasta = DateTime.Parse(dr(Entidades.TurnoCalendario.Columnas.FechaHasta.ToString()).ToString())

   '      'Para mejorar performance solo cargo los datos necesarios del cliente.
   '      '.Cliente = New Clientes(da)._GetUno(Long.Parse(dr(Entidades.TurnoCalendario.Columnas.IdCliente.ToString()).ToString()))
   '      '.Cliente = New Entidades.Cliente()
   '      .IdCliente = Long.Parse(dr(Entidades.TurnoCalendario.Columnas.IdCliente.ToString()).ToString())
   '      .CodigoCliente = Long.Parse(dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
   '      .NombreCliente = dr(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()

   '      .Observaciones = dr(Entidades.TurnoCalendario.Columnas.Observaciones.ToString()).ToString()
   '      .IdTipoTurno = dr.Field(Of String)(Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString())
   '      .NombreTipoTurno = dr.Field(Of String)(Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString())
   '      '.EsEfectivo = Boolean.Parse(dr(Entidades.TurnoCalendario.Columnas.EsEfectivo.ToString()).ToString())

   '      .IdProducto = dr(Entidades.TurnoCalendario.Columnas.IdProducto.ToString()).ToString()
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.PrecioLista.ToString()).ToString()) Then
   '         .PrecioLista = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.PrecioLista.ToString()).ToString())
   '      End If
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.Precio.ToString()).ToString()) Then
   '         .Precio = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.Precio.ToString()).ToString())
   '      End If
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString()).ToString()) Then
   '         .DescuentoRecargoPorcGral = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString()).ToString())
   '      End If
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString()).ToString()) Then
   '         .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
   '      End If
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) Then
   '         .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
   '      End If
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString()).ToString()) Then
   '         .PrecioNeto = Decimal.Parse(dr(Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString()).ToString())
   '      End If

   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.IdSucursal.ToString()).ToString()) Then
   '         .IdSucursal = Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.IdSucursal.ToString()).ToString())
   '      End If
   '      .IdTipoComprobante = dr(Entidades.TurnoCalendario.Columnas.IdTipoComprobante.ToString()).ToString()
   '      .Letra = dr(Entidades.TurnoCalendario.Columnas.Letra.ToString()).ToString()
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.CentroEmisor.ToString()).ToString()) Then
   '         .CentroEmisor = Short.Parse(dr(Entidades.TurnoCalendario.Columnas.CentroEmisor.ToString()).ToString())
   '      End If
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.NumeroComprobante.ToString()).ToString()) Then
   '         .NumeroComprobante = Long.Parse(dr(Entidades.TurnoCalendario.Columnas.NumeroComprobante.ToString()).ToString())
   '      End If
   '      If IsNumeric(dr(Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString()).ToString()) Then
   '         .NumeroSesion = Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString()).ToString())
   '      End If
   '      .TurnoProducto = New TurnosCalendariosProductos(da).GetTodos(Integer.Parse(dr(Entidades.TurnoCalendario.Columnas.IdTurno.ToString()).ToString()))
   '      .IdEstadoTurno = dr.Field(Of String)(Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString())
   '      .NombreEstadoTurno = dr.Field(Of String)(Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString())
   '      '.EstadoTurno = New EstadosTurnos(da).GetUno(dr(Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString()).ToString())

   '      If Publicos.IDAplicacionSinergia = "SISEN" Then
   '         .IdEmbarcacion = dr.Field(Of Long?)("IdEmbarcacion").IfNull()
   '         .CodigoEmbarcacion = dr.Field(Of Long?)("CodigoEmbarcacion").IfNull()
   '         .NombreEmbarcacion = dr.Field(Of String)("NombreEmbarcacion")
   '      End If

   '   End With
   'End Sub
#End Region

#Region "Metodos publicos"

   Public Function PuedeEditar(idCalendario As Integer) As Boolean
      Return Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, idCalendario).PuedeEditar()
   End Function

   Public Overridable Sub Inserta(entidad As Entidades.TurnoCalendario)
      Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, entidad.IdCalendario).Inserta(entidad)
   End Sub

   Public Overridable Sub Actualiza(entidad As Entidades.TurnoCalendario)
      Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, entidad.IdCalendario).Actualiza(entidad)
   End Sub

   Public Overridable Sub ActualizaEstadoPorIdUnico(idTurnoEstado As String, idEstado As String)
      Dim estado = Cache.TurnosCacheHandler.Instancia.EstadosTurnos.Buscar(idEstado)
      ActualizaEstadoPorIdUnico(idTurnoEstado, estado)
   End Sub
   Public Overridable Sub ActualizaEstadoPorIdUnico(idTurnoEstado As String, estado As Entidades.EstadoTurno)

      Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, publicarEnWeb:=False).ActualizaEstadoPorIdUnico(idTurnoEstado, estado)
      Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, publicarEnWeb:=True).ActualizaEstadoPorIdUnico(idTurnoEstado, estado)
   End Sub

   Public Sub Borra(entidad As Entidades.TurnoCalendario)
      Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, entidad.IdCalendario).Borra(entidad)
   End Sub

   Public Overloads Sub Actualizar(turnos As List(Of Entidades.TurnoCalendario), turnosBorrados As List(Of Entidades.TurnoCalendario))

      'GAR: Sebastian... porque hace una recorrida de turnos????
      'SPC: Porque está pensado para grabación masiva de todos los de pantalla. Ya cambio.
      Try
         da.OpenConection()
         da.BeginTransaction()
         If turnos IsNot Nothing AndAlso turnos.Count > 0 Then
            For Each turno As Entidades.TurnoCalendario In turnos
               If turno.IdTurno = 0 Then
                  Inserta(turno)
               Else
                  Actualiza(turno)
               End If
            Next
         End If
         If turnosBorrados IsNot Nothing AndAlso turnosBorrados.Count > 0 Then
            For Each turno As Entidades.TurnoCalendario In turnosBorrados
               If turno.IdTurno <> 0 Then
                  Borra(turno)
               End If
            Next
         End If
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Protected Overridable Function NewEntidad() As Entidades.TurnoCalendario
      Return New Entidades.TurnoCalendario()
   End Function

   Public Function GetTurnosDelDia(idUsuario As String) As DataTable
      Return NewSql(Me.da).GetTurnosDelDia(idUsuario)
   End Function

   Public Function GetUno(idTurno As String, idCalendario As Integer) As Entidades.TurnoCalendario
      Return Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, idCalendario).GetUno(idTurno)
   End Function
   Public Function GetUno(idTurno As String, idCalendario As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TurnoCalendario
      Return Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, idCalendario).GetUno(idTurno, accion)
   End Function

   Public Function GetTodos() As List(Of Entidades.TurnoCalendario)
      Return Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, 0).GetTodos()
   End Function
   Public Function GetTodos(idCalendario As Integer, fechaDesdeDesde As DateTime?, fechaDesdeHasta As DateTime?) As List(Of Entidades.TurnoCalendario)
      Return Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, idCalendario).GetTodos(idCalendario, fechaDesdeDesde, fechaDesdeHasta)
   End Function

   Public Function GetPorRangoFechas(filtros As Entidades.Filtros.GetPorRangoFechasFiltros) As DataTable
      'Dim remoto = New Turnos.Handlers.TurnosCalendariosHandlerRemoto(da)

      Dim dt = NewSql(Me.da).GetPorRangoFechas(filtros)

      'Dim turnosWeb = remoto.GetTodos(0, filtros.FechaDesde, filtros.FechaHasta)

      'For Each tw In turnosWeb
      '   Dim dr = dt.NewRow()
      '   dr(Entidades.TurnoCalendario.Columnas.IdTurno.ToString()) = tw.IdTurno
      '   dr(Entidades.TurnoCalendario.Columnas.IdCalendario.ToString()) = tw.IdCalendario
      '   dr(Entidades.Calendario.Columnas.NombreCalendario.ToString()) = ""
      '   dr(Entidades.TurnoCalendario.Columnas.FechaDesde.ToString()) = tw.FechaDesde
      '   dr(Entidades.TurnoCalendario.Columnas.FechaHasta.ToString()) = tw.FechaHasta
      '   dr(Entidades.TurnoCalendario.Columnas.IdCliente.ToString()) = tw.IdCliente
      '   dr(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = tw.CodigoCliente
      '   dr(Entidades.Cliente.Columnas.NombreCliente.ToString()) = tw.NombreCliente
      '   dr(Entidades.TurnoCalendario.Columnas.IdTipoTurno.ToString()) = tw.IdTipoTurno
      '   dr(Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString()) = tw.NombreTipoTurno
      '   dr(Entidades.TurnoCalendario.Columnas.Observaciones.ToString()) = tw.Observaciones
      '   'dr(Entidades.TurnoCalendario.Columnas.IdProducto.ToString())
      '   'dr(Entidades.Producto.Columnas.NombreProducto.ToString())
      '   'dr(Entidades.TurnoCalendario.Columnas.PrecioLista.ToString())
      '   'dr(Entidades.TurnoCalendario.Columnas.Precio.ToString())
      '   'dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorcGral.ToString())
      '   'dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc1.ToString())
      '   'dr(Entidades.TurnoCalendario.Columnas.DescuentoRecargoPorc2.ToString())
      '   'dr(Entidades.TurnoCalendario.Columnas.PrecioNeto.ToString())
      '   'dr(Entidades.TurnoCalendario.Columnas.NumeroSesion.ToString())
      '   dr(Entidades.TurnoCalendario.Columnas.IdEstadoTurno.ToString()) = tw.IdEstadoTurno
      '   dr(Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString()) = tw.NombreEstadoTurno

      '   If Publicos.IDAplicacionSinergia = "SISEN" Then
      '      dr("IdEmbarcacion") = tw.IdEmbarcacion
      '      dr("CodigoEmbarcacion") = tw.CodigoEmbarcacion
      '      dr("NombreEmbarcacion") = tw.NombreEmbarcacion
      '   End If

      'Next

      Return dt
   End Function
   Public Function GetPorRangoFechasZonas(filtros As Entidades.Filtros.GetPorRangoFechasFiltros) As DataTable
      Return NewSql(Me.da).GetPorRangoFechasZonas(filtros)
   End Function

   'Public Function GetCodigoMaximo() As Integer
   '   Return NewSql(da).GetCodigoMaximo()
   'End Function

   Public Function GetAusentesConTurnos(idCalendario As Integer, fecha As DateTime) As DataTable
      Return NewSql(Me.da).GetAusentesConTurnos(idCalendario, fecha)
   End Function

   Public Function GetPresentesConTurnos(idCalendario As Integer, fecha As DateTime, efectivo As Boolean) As DataTable
      Return NewSql(Me.da).GetPresentesConTurnos(idCalendario, fecha, efectivo)
   End Function

   Public Function GetAtendidos(idCalendario As Integer, fecha As DateTime, efectivo As Boolean) As DataTable
      Return NewSql(Me.da).GetAtendidos(idCalendario, fecha, efectivo)
   End Function

   <Obsolete("USAR ActualizarAtencion(Integer, Boolean, String)", True)>
   Public Sub ActualizarAtencion(turno As Entidades.TurnoCalendario)
      ActualizarAtencion(turno.IdTurno, turno.IdEstadoTurno)
   End Sub

   Public Sub ActualizarAtencion(idTurno As Integer, idEstadoTurno As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         _ActualizarAtencion(idTurno, idEstadoTurno)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Sub _ActualizarAtencion(idTurno As Integer, idEstadoTurno As String)
      NewSql(Me.da).ActualizarAtencion(idTurno, idEstadoTurno)
   End Sub

   Public Function GetTurnosxCliente(idCliente As Integer) As DataTable
      Return NewSql(Me.da).GetTurnosxCliente(idCliente)
   End Function

   Public Function GetTurnosxClienteHistorial(IdCliente As Integer) As DataTable
      Return NewSql(Me.da).GetTurnosxClienteHistorial(IdCliente)
   End Function

   Public Function ConvertirTurnoEnVenta(turnoPantalla As Entidades.TurnoCalendario, _cache As BusquedasCacheadas) As Entidades.Venta

      Dim turno As Entidades.TurnoCalendario = GetUno(turnoPantalla.IdTurnoUnico, turnoPantalla.IdCalendario)
      If Not String.IsNullOrWhiteSpace(turno.IdTipoComprobante) Then
         Throw New Exception(String.Format("El turno de {0} ({1}) ya fue facturado con el comprobante {2} {3} {4:0000}-{5:00000000}",
                                           turno.NombreCliente,
                                           turno.CodigoCliente,
                                           turno.IdTipoComprobante,
                                           turno.Letra,
                                           turno.CentroEmisor,
                                           turno.NumeroComprobante))
      End If

      '################################################# 
      '# Obtengo el IdCaja del calendario seleccionado #
      '#################################################

      Dim enCalendario As Entidades.Calendario = New Entidades.Calendario
      Dim reCalendario As Reglas.Calendarios = New Reglas.Calendarios
      enCalendario = reCalendario.GetUno(turnoPantalla.IdCalendario)

      ' Por defecto idCajaCalendario en 0
      Dim idCajaCalendario As Integer = 0

      If IsNumeric(Integer.Parse(enCalendario.CalendarioSucursal.IdCaja.ToString().ToString())) Then
         idCajaCalendario = enCalendario.CalendarioSucursal.IdCaja
      End If


      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      Dim tiposComprobante As List(Of Entidades.TipoComprobante)
      tiposComprobante = oTiposComprobantes.GetHabilitados(actual.Sucursal.Id,
                                                           My.Computer.Name,
                                                           "VENTAS",
                                                           Tipo2:="",
                                                           AfectaCaja:="",
                                                           UsaFacturacionRapida:="",
                                                           UsaFacturacion:=True,
                                                           IgnoraSucursal:=False,
                                                           esRecibo:=Nothing,
                                                           coeficionesStock:=Nothing,
                                                           grabaLibro:=Nothing,
                                                           esReciboClienteVinculado:=Nothing, coeficienteValor:=Nothing, importeComprobante:=Nothing,
                                                           esElectronico:=Nothing,
                                                           clase:=String.Empty)
      If tiposComprobante.Count = 0 Then
         Throw New Exception("No Existe la PC en Configuraciones/Impresoras")
      End If

      Dim cliente As Entidades.Cliente = _cache.BuscaClienteEntidadPorId(turno.IdCliente)
      Dim producto As Entidades.Producto = _cache.BuscaProductoEntidadPorId(turno.IdProducto)
      Dim tipoImpuesto As Entidades.TipoImpuesto = _cache.BuscaTiposImpuestos(producto.IdTipoImpuesto)
      Dim listaPrecios As Entidades.ListaDePrecios = _cache.BuscaListaDePrecios(cliente.IdListaPrecios)

      Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
      Dim venta As Entidades.Venta = rVentas.CreaVenta(actual.Sucursal.Id,
                                                       tiposComprobante(0),
                                                       cliente,
                                                       turno.DescuentoRecargoPorcGral,
                                                       turno.Observaciones,
                                                       idCajaCalendario)

      Dim precio As Decimal = turno.Precio.Value
      If Not (cliente.CategoriaFiscal.IvaDiscriminado And _cache.BuscaCategoriaFiscal(Reglas.Publicos.CategoriaFiscalEmpresa).IvaDiscriminado) Then
         precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precio, producto.Alicuota, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      End If

      rVentas.AgregarVentaProducto(venta, rVentas.CreaVentaProducto(producto,
                                                           producto.NombreProducto,
                                                           turno.DescuentoRecargoPorc1.Value,
                                                           turno.DescuentoRecargoPorc2.Value,
                                                           precio,
                                                           1,
                                                           tipoImpuesto,
                                                           producto.Alicuota,
                                                           listaPrecios,
                                                           Nothing,
                                                           Entidades.Producto.TiposOperaciones.NORMAL,
                                                           String.Empty, Nothing,
                                                           venta, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio),
                                   Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)

      'No haria falta preguntar, si no lo usan esta nothing, lo dejo por las dudas.
      Dim Calendario As Entidades.Calendario = New Reglas.Calendarios().GetUno(turno.IdCalendario)
      If Not Calendario.UtilizaZonas Then
      End If

      For Each TP As Entidades.TurnosCalendariosProductos In turno.TurnoProducto

         Dim productoTP As Entidades.Producto = _cache.BuscaProductoEntidadPorId(TP.IdProducto)

         rVentas.AgregarVentaProducto(venta, rVentas.CreaVentaProducto(productoTP,
                                                                 TP.NombreProducto & " - Sesion: " & TP.NumeroSesion.ToString(),
                                                                 0,
                                                                 0,
                                                                 0,
                                                                 1,
                                                                 tipoImpuesto,
                                                                 productoTP.Alicuota,
                                                                 listaPrecios,
                                                                 Nothing,
                                                                 Entidades.Producto.TiposOperaciones.BONIFICACION,
                                                                 String.Empty, Nothing,
                                                                 venta, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio),
                                      Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
      Next


      rVentas.AgregarVentaObservacion(venta, String.Format("Turno {0:dd/MM/yyyy HH:mm}", turno.FechaDesde))

      venta.TurnosInvocados.Add(turno)

      'Lo convierto con número 0 porque no necesito que tenga numero
      venta.NumeroComprobante = 0

      Return venta
   End Function

   Public Function GetInvocados(venta As Entidades.Venta) As List(Of Entidades.TurnoCalendario)
      Return Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, 0).GetInvocados(venta)
   End Function

   Public Sub AnularInvocarTurno(venta As Entidades.Venta)
      For Each turno As Entidades.TurnoCalendario In GetInvocados(venta)
         InvocarTurno(turno, Nothing)
      Next
   End Sub

   Public Sub InvocarTurno(venta As Entidades.Venta)
      For Each turno As Entidades.TurnoCalendario In venta.TurnosInvocados
         InvocarTurno(turno, venta)
      Next
   End Sub

   Public Sub InvocarTurno(turno As Entidades.TurnoCalendario, venta As Entidades.Venta)
      If turno IsNot Nothing Then
         If venta Is Nothing Then
            NewSql(Me.da).TurnosCalendarios_U(turno.IdTurno, Nothing, String.Empty, String.Empty, Nothing, Nothing)
         Else
            NewSql(Me.da).TurnosCalendarios_U(turno.IdTurno, venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
         End If
      End If
   End Sub

   Public Sub ActualizarComprobantePorComprobante(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then Me.da.OpenConection()

         NewSql(Me.da).ActualizarComprobantePorComprobante(vtaNueva.IdSucursal,
                                                           vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                                                           vtaNueva.IdSucursal,
                                                           vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)

      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Sub
   'Private Sub ActualizaTurnosCalendariosProductos(idTurno As Integer, turnoProductos As List(Of Entidades.TurnosCalendariosProductos))

   '   If turnoProductos IsNot Nothing Then
   '      Dim sql As SqlServer.TurnosCalendariosProductos = New SqlServer.TurnosCalendariosProductos(da)
   '      BorrarTurnosCalendariosProductos(idTurno)
   '      Dim orden As Integer = 0
   '      For Each item As Entidades.TurnosCalendariosProductos In turnoProductos
   '         orden += 1
   '         sql.TurnosCalendariosProductos_I(idTurno, item.IdProducto, orden, item.NumeroSesion, item.ValorFluencia)
   '      Next
   '   End If
   'End Sub
   'Private Sub BorrarTurnosCalendariosProductos(idTurno As Integer)
   '   Dim sql As SqlServer.TurnosCalendariosProductos = New SqlServer.TurnosCalendariosProductos(da)
   '   sql.TurnosCalendariosProductos_D(idTurno, idProducto:=String.Empty, orden:=0)
   'End Sub

   Public Function ControlaCupoDisponible(turnos As List(Of Entidades.TurnoCalendario),
                                          turnoActual As Entidades.TurnoCalendario,
                                          fechaHoraDesde As DateTime,
                                          fechaHoraHasta As DateTime,
                                          cupo As Integer) As Boolean
      Return Reglas.Turnos.Handlers.TurnosCalendariosHandlerFactory.Crear(da, turnoActual.Calendario.PublicarEnWeb).ControlaCupoDisponible(turnos, turnoActual, fechaHoraDesde, fechaHoraHasta, cupo)
      'Dim contCupos As Integer = 0
      'For Each turExistente As Entidades.TurnoCalendario In turnos
      '   If turExistente.IdTurno <> turnoActual.IdTurno Then
      '      If turExistente.FechaDesde < fechaHoraHasta And turExistente.FechaHasta > fechaHoraDesde Then
      '         contCupos += 1
      '      End If
      '   End If
      'Next
      'Return contCupos < cupo
   End Function

#End Region
End Class
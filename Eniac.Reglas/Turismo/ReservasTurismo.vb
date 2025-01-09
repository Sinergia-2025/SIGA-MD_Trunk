Public Class ReservasTurismo
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ReservasTurismo"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ReservaTurismo)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ReservaTurismo)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ReservaTurismo)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ReservasTurismo(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ReservasTurismo(da).ReservasTurismo_GA()
   End Function


   'Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad) As System.Data.DataTable
   '   If TipoNovedad Is Nothing Then
   '      Return GetAll()
   '   Else
   '      Return GetAll(TipoNovedad.IdTipoNovedad, False)
   '   End If
   'End Function
   'Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
   '   Return New SqlServer.Reservas(da).Reservas_GA()
   'End Function
#End Region

#Region "Metodos Privados"
   Public Sub _Insertar(entidad As Entidades.ReservaTurismo)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.ReservaTurismo)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.ReservaTurismo)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.ReservaTurismo, tipo As TipoSP)

      Dim sqlC = New SqlServer.ReservasTurismo(da)
      Dim sqlRP = New SqlServer.ReservasTurismoProductos(da)
      Dim sqlRPA = New SqlServer.ReservasTurismoPasajeros(da)
      Dim rVNRe = New VentasNumeros(da)
      Dim oVN = New Entidades.VentaNumero
      Dim rPasajeros = New ReservasTurismoPasajeros(da)
      Dim rFacturacion = New ReservaTurismoProductoFacturacion(da)

      Select Case tipo
         Case TipoSP._I

            If en.NumeroReserva = 0 Then
               Dim sucursal = New Sucursales(da).GetUna(en.IdSucursal, False)
               Dim oVentasNumeros = New VentasNumeros(da)
               en.NumeroReserva = oVentasNumeros.GetProximoNumero(sucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor)

               With oVN
                  .IdTipoComprobante = en.IdTipoReserva
                  .LetraFiscal = en.Letra
                  .CentroEmisor = en.CentroEmisor
                  .IdSucursal = en.IdSucursal
                  .Numero = en.NumeroReserva
                  .Fecha = en.Fecha
               End With

               rVNRe.ActualizarNumero(oVN)

            End If

            sqlC.ReservasTurismo_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
                                   en.NumeroReserva, en.Fecha, en.IdEstablecimiento, en.IdCurso, en.Division,
                                   en.IdTurno, en.IdResponsable, en.IdPrograma, en.Mes, en.QuincenaSemana,
                                   en.Dia, en.IdTipoVehiculo, en.CapacidadMax, en.LugarSalida, en.CantidadAlumnos,
                                   en.Costo, en.BaseAlumnos, en.IdFormaPago, en.Liberados, en.Seguimiento,
                                   en.CDDigital, en.IdEstadoTurismo, en.IdUsuarioAlta, en.IdUsuarioEstadoTurismo,
                                   en.FechaEstadoTurismo, en.BanderaColor, en.IdUnicoReserva, en.FechaViaje,
                                   en.ObservacionesVendedor, en.ObservacionesInternas, en.ErroresSincronizacion,
                                   en.IdTipoViaje)

            Dim Orden As Integer = 0

            If en.Visitas IsNot Nothing Then
               For Each Visita As Entidades.ReservaTurismoProducto In en.Visitas
                  Orden += 1
                  sqlRP.ReservasTurismoProductos_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
                                                         en.NumeroReserva, Visita.IdProducto,
                                                         Visita.IdProductoComponente, Visita.IdFormula, Orden)
               Next
            End If

            If en.Gastronomia IsNot Nothing Then
               For Each Gastronomia As Entidades.ReservaTurismoProducto In en.Gastronomia
                  Orden += 1
                  sqlRP.ReservasTurismoProductos_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
                                                         en.NumeroReserva, en.IdPrograma,
                                                        Gastronomia.IdProductoComponente,
                                                         Gastronomia.IdFormula, Orden)
               Next
            End If

            rPasajeros.ActualizaDesdeReserva(en)
            rFacturacion._Insertar(en)

         Case TipoSP._U
            sqlC.ReservasTurismo_U(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
                                   en.NumeroReserva, en.Fecha, en.IdEstablecimiento, en.IdCurso, en.Division,
                                   en.IdTurno, en.IdResponsable, en.IdPrograma, en.Mes, en.QuincenaSemana,
                                   en.Dia, en.IdTipoVehiculo, en.CapacidadMax, en.LugarSalida, en.CantidadAlumnos,
                                   en.Costo, en.BaseAlumnos, en.IdFormaPago, en.Liberados, en.Seguimiento,
                                   en.CDDigital, en.IdEstadoTurismo, en.IdUsuarioAlta, en.IdUsuarioEstadoTurismo,
                                   en.FechaEstadoTurismo, en.BanderaColor, en.FechaViaje,
                                   en.ObservacionesVendedor, en.ObservacionesInternas, en.ErroresSincronizacion,
                                   en.IdTipoViaje)

            sqlRP.ReservasTurismoProductos_D(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
                                       en.NumeroReserva)

            Dim Orden As Integer = 0
            Dim VisitaCant As Integer = 1
            Dim Prod As String = String.Empty
            If en.Visitas IsNot Nothing Then
               For Each visita In en.Visitas

                  Orden += 1
                  sqlRP.ReservasTurismoProductos_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
                                                   en.NumeroReserva, visita.IdProducto,
                                                   visita.IdProductoComponente, visita.IdFormula, Orden)

               Next
            End If

            If en.Gastronomia IsNot Nothing Then
               For Each Gastronomia As Entidades.ReservaTurismoProducto In en.Gastronomia
                  Orden += 1
                  sqlRP.ReservasTurismoProductos_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
                                                         en.NumeroReserva, en.IdPrograma,
                                                        Gastronomia.IdProductoComponente,
                                                         Gastronomia.IdFormula, Orden)
               Next
            End If

            rPasajeros.ActualizaDesdeReserva(en)
            rFacturacion._Actualizar(en)

         Case TipoSP._D

            rFacturacion._Borrar(en)
            sqlRPA.ReservasTurismoPasajeros_DxReserva(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva)
            sqlRP.ReservasTurismoProductos_D(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva)
            sqlC.ReservasTurismo_D(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva)

      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ReservaTurismo, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.IdSucursal.ToString())
         .IdTipoReserva = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.IdTipoReserva.ToString())
         .Letra = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.ReservaTurismo.Columnas.CentroEmisor.ToString())
         .NumeroReserva = dr.Field(Of Long)(Entidades.ReservaTurismo.Columnas.NumeroReserva.ToString())
         .Fecha = dr.Field(Of Date)(Entidades.ReservaTurismo.Columnas.Fecha.ToString())
         .IdEstablecimiento = dr.Field(Of Long)(Entidades.ReservaTurismo.Columnas.IdEstablecimiento.ToString())
         .IdCurso = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.IdCurso.ToString())
         .Division = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.Division.ToString())
         .IdTurno = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.IdTurno.ToString())
         .IdResponsable = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.IdResponsable.ToString())
         .IdPrograma = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.IdPrograma.ToString())
         .Mes = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.Mes.ToString())
         .QuincenaSemana = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.QuincenaSemana.ToString())
         .Dia = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.Dia.ToString())
         .IdTipoVehiculo = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.IdTipoVehiculo.ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ReservaTurismo.Columnas.CapacidadMax.ToString()).ToString()) Then
            .CapacidadMax = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.CapacidadMax.ToString())
         End If
         .LugarSalida = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.LugarSalida.ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ReservaTurismo.Columnas.CantidadAlumnos.ToString()).ToString()) Then
            .CantidadAlumnos = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.CantidadAlumnos.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ReservaTurismo.Columnas.Costo.ToString()).ToString()) Then
            .Costo = dr.Field(Of Decimal)(Entidades.ReservaTurismo.Columnas.Costo.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ReservaTurismo.Columnas.BaseAlumnos.ToString()).ToString()) Then
            .BaseAlumnos = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.BaseAlumnos.ToString())
         End If
         Dim valorInt As Integer? = dr.Field(Of Integer?)(Entidades.ReservaTurismo.Columnas.IdFormaPago.ToString())
         If valorInt.HasValue Then
            .IdFormaPago = valorInt.Value
         End If
         .Liberados = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.Liberados.ToString())
         .Seguimiento = dr.Field(Of Boolean)(Entidades.ReservaTurismo.Columnas.Seguimiento.ToString())
         .CDDigital = dr.Field(Of Boolean)(Entidades.ReservaTurismo.Columnas.CDDigital.ToString())
         .IdEstadoTurismo = dr.Field(Of Integer)(Entidades.ReservaTurismo.Columnas.IdEstadoTurismo.ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString()).ToString()) Then
            .BanderaColor = Drawing.Color.FromArgb(dr.Field(Of Integer)(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()))
         Else
            .BanderaColor = Nothing
         End If
         ' .BanderaColor = dr.Field(Of Color)(Entidades.Reserva.Columnas.Año.ToString())
         .NombreTipoReserva = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.NombreTipoReserva.ToString())
         .IdUsuarioAlta = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.IdUsuarioAlta.ToString())
         .IdUsuarioEstadoTurismo = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.IdUsuarioEstadoTurismo.ToString())
         .FechaEstadoTurismo = dr.Field(Of Date)(Entidades.ReservaTurismo.Columnas.FechaEstadoTurismo.ToString())
         .NombreEstadoTurismo = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.NombreEstadoTurismo.ToString())
         .NombreEstablecimiento = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.NombreEstablecimiento.ToString())
         .NombreContacto = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.NombreContacto.ToString())
         .NombrePrograma = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.NombrePrograma.ToString())
         .NombreTipoVehiculo = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.NombreTipoVehiculo.ToString())

         Dim lista As List(Of Entidades.ReservaTurismoPasajero) = New Reglas.ReservasTurismoPasajeros(da).GetReservaPasajero2(.IdSucursal,
                                                                                                                 .IdTipoReserva,
                                                                                                                 .Letra,
                                                                                                                 .CentroEmisor,
                                                                                                                 .NumeroReserva)

         .Pasajeros = New Entidades.ListConBorrados(Of Entidades.ReservaTurismoPasajero)(lista)

         .Visitas = New ReservasTurismoProductos(da).GetReservaProducto2(.IdSucursal, .IdTipoReserva, .Letra, .CentroEmisor, .NumeroReserva,
                                                                         Publicos.TurismoFormulaVisitasID)

         .Gastronomia = New ReservasTurismoProductos(da).GetReservaProducto2(.IdSucursal, .IdTipoReserva, .Letra, .CentroEmisor, .NumeroReserva,
                                                                             Publicos.TurismoFormulaGastronomiaID)

         .Facturacion = New ReservaTurismoProductoFacturacion(da).GetTodos(.IdSucursal, .IdTipoReserva, .Letra, .CentroEmisor, .NumeroReserva)

         If Not String.IsNullOrWhiteSpace(dr(Entidades.ReservaTurismo.Columnas.FechaViaje.ToString()).ToString()) Then
            .FechaViaje = dr.Field(Of Date)(Entidades.ReservaTurismo.Columnas.FechaViaje.ToString())
         End If
         .ObservacionesVendedor = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.ObservacionesVendedor.ToString())
         .ObservacionesInternas = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.ObservacionesInternas.ToString())
         .ErroresSincronizacion = dr.Field(Of String)(Entidades.ReservaTurismo.Columnas.ErroresSincronizacion.ToString())

         .IdTipoViaje = dr.Field(Of Integer?)(Entidades.ReservaTurismo.Columnas.IdTipoViaje.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, Numero As Long, accion As AccionesSiNoExisteRegistro) As Entidades.ReservaTurismo
      Return CargaEntidad(New SqlServer.ReservasTurismo(da).ReservasTurismo_G1(idSucursal, idTipoReserva, letra, centroEmisor, Numero),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ReservaTurismo(),
                          accion, Function() String.Format("No existe la Reserva Numero: {0}", Numero))
   End Function

   Public Function GetTodos(Optional ordenarPosicion As Boolean = False) As List(Of Entidades.ReservaTurismo)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(o, dr),
                        Function() New Entidades.ReservaTurismo())
   End Function

   Public Function GetReservas(buscarABM As Entidades.Buscar, idCliente As Long, fechaDesde As Date?, fechaHasta As Date?,
                               idUsuario As String, idEstadoTurismo As Integer, numero As Long,
                               finalizado As String) As DataTable
      Return New SqlServer.ReservasTurismo(da).GetReservas(buscarABM, idCliente, fechaDesde, fechaHasta, idUsuario,
                                                           idEstadoTurismo, numero, finalizado)
   End Function

   Public Function GetReservasPorEstado(estados As List(Of Integer), idSucursal As Integer,
                                        idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As DataTable

      Return New SqlServer.ReservasTurismo(da).GetReservasPorEstado(estados, idSucursal,
                                                                    idTipoReserva, letra, centroEmisor, numeroReserva)
   End Function

   Public Function InfReservas(idCliente As Long, fechaDesde As Date?, fechaHasta As Date?) As DataTable
      Return New SqlServer.ReservasTurismo(da).GetInfReservas(idCliente, fechaDesde, fechaHasta)
   End Function

   Public Sub GrabarComprobantesDeReservas(idSucursal As Integer,
                                           reserva As Entidades.ReservaTurismo,
                                           idCajaComprobante As Integer,
                                           dtPasajeros As DataTable,
                                           IdTipoComprobante As String,
                                           metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                           idFuncion As String,
                                           tspBarra As Windows.Forms.ToolStripProgressBar)
      EjecutaConConexion(
         Sub()

            Dim drProcesar = dtPasajeros.AsEnumerable().Where(Function(dr) dr.Field(Of Boolean)("Selec")).AsEnumerable()

            If drProcesar.Count = 0 Then
               Throw New Exception("No hay comprobantes por generar")
            End If

            tspBarra.Maximum = drProcesar.Count * 2
            tspBarra.Value = 0
            Windows.Forms.Application.DoEvents()

            ' Dim idTipoComprobanteReserva1 As String = Publicos.TurismoTipoComprobante
            Dim idTipoComprobanteReserva As String = IdTipoComprobante

            Dim rVentas = New Ventas(da)
            Dim rCtaCte = New CuentasCorrientes(da)
            Dim rCtaCtePagos = New CuentasCorrientesPagos(da)
            Dim rClientes = New Clientes(da)
            Dim rFeriados = New Feriados(da)

            Dim establecimiento = rClientes._GetUno(reserva.IdEstablecimiento)

            Dim tipoComprobanteReserva = New TiposComprobantes(da).GetUno(idTipoComprobanteReserva)
            Dim formaDePago = New VentasFormasPago(da).GetUna(reserva.IdFormaPago)
            'Dim intereses = New Intereses(da).GetUno(Publicos.TurismoRoelaInteresesVencimiento)
            Dim listaPrecios = New ListasDePrecios(da).GetUno(Publicos.ListaPreciosPredeterminada)

            Dim rProductos = New Productos(da)
            Dim productoPrograma = rProductos.GetUno(reserva.IdPrograma)

            Dim tipoImpuesto = New TiposImpuestos(da)._GetUno(productoPrograma.IdTipoImpuesto)

            Dim visitasProductos = reserva.Visitas.ConvertAll(Function(visita) rProductos.GetUno(visita.IdProducto))
            Dim lugaresProductos = reserva.Gastronomia.ConvertAll(Function(lugar) rProductos.GetUno(lugar.IdProducto))

            Dim lstVentas = New List(Of Entidades.Venta)()
            Using cacheIntereses = New Ayudante.Cache.Archivos.CacheIntereses()
               Using cacheTipoViaje = New Ayudante.Cache.Turismo.CacheTurismoTipoViaje

                  For Each dr In drProcesar
                     Dim clienteParaDic = rClientes._GetUno(dr.Field(Of Long)(Entidades.ReservaTurismoPasajero.Columnas.IdClientePasajero.ToString()))

                     Dim venta = rVentas.CreaVenta(idSucursal, tipoComprobanteReserva, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=Nothing,
                                                   cliente:=clienteParaDic, categoriaFiscal:=Nothing, fecha:=Date.Now,
                                                   vendedor:=Nothing, transportista:=Nothing, formaPago:=formaDePago,
                                                   descuentoRecargoPorc:=0, idCaja:=idCajaComprobante,
                                                   cotizacionDolar:=Nothing, mercDespachada:=True, numeroReparto:=Nothing,
                                                   fechaEnvio:=Nothing, proveedor:=Nothing, observaciones:=String.Empty,
                                                   cobrador:=Nothing, clienteVinculado:=establecimiento, nroOrdenCompra:=0)

                     lstVentas.Add(venta)

                     rVentas.AgregarVentaObservacion(venta, String.Format("RESERVA {0} - Establecimiento: {1}", reserva.NumeroReserva, reserva.NombreEstablecimiento))

                     'Agrego un producto para el programa con el importe tipo NORMAL
                     rVentas.AgregarVentaProducto(venta,
                                                  rVentas.CreaVentaProducto(productoPrograma, productoPrograma.NombreProducto,
                                                                            descuentoRecargoPorc1:=0, descuentoRecargoPorc2:=0,
                                                                            precio:=dr.Field(Of Decimal)("Importe"), cantidad:=1,
                                                                            tipoImpuesto:=tipoImpuesto, porcentajeIva:=Nothing,
                                                                            listaDePrecios:=listaPrecios, fechaEntrega:=Nothing,
                                                                            tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL, nota:=String.Empty, idEstadoVenta:=Nothing,
                                                                            venta:=venta, redondeoEnCalculo:=2),
                                                  redondeoEnCalculo:=2)
                     'Agrego un producto para las visitas del programa con importe 0 tipo BONIFICACION
                     For Each prod In visitasProductos
                        rVentas.AgregarVentaProducto(venta,
                                                     rVentas.CreaVentaProducto(productoPrograma, productoPrograma.NombreProducto,
                                                                               descuentoRecargoPorc1:=0, descuentoRecargoPorc2:=0,
                                                                               precio:=0, cantidad:=1,
                                                                               tipoImpuesto:=tipoImpuesto, porcentajeIva:=Nothing,
                                                                               listaDePrecios:=listaPrecios, fechaEntrega:=Nothing,
                                                                               tipoOperacion:=Entidades.Producto.TiposOperaciones.BONIFICACION, nota:=String.Empty, idEstadoVenta:=Nothing,
                                                                               venta:=venta, redondeoEnCalculo:=2),
                                                     redondeoEnCalculo:=2)
                     Next
                     'Agrego un producto para los lugares gastronómicos del programa con importe 0 tipo BONIFICACION
                     For Each prod In lugaresProductos
                        rVentas.AgregarVentaProducto(venta,
                                                     rVentas.CreaVentaProducto(productoPrograma, productoPrograma.NombreProducto,
                                                                               descuentoRecargoPorc1:=0, descuentoRecargoPorc2:=0,
                                                                               precio:=0, cantidad:=1,
                                                                               tipoImpuesto:=tipoImpuesto, porcentajeIva:=Nothing,
                                                                               listaDePrecios:=listaPrecios, fechaEntrega:=Nothing,
                                                                               tipoOperacion:=Entidades.Producto.TiposOperaciones.BONIFICACION, nota:=String.Empty, idEstadoVenta:=Nothing,
                                                                               venta:=venta, redondeoEnCalculo:=2),
                                                     redondeoEnCalculo:=2)
                     Next

                     venta.CuentaCorriente.Pagos.Clear()
                     Dim importeAnticipo = dr.Field(Of Decimal)("Anticipo")
                     Dim importePrimerCuota = dr.Field(Of Decimal)("ImportePrimerCuota")
                     Dim importeUltimaCuota = dr.Field(Of Decimal)("ImporteUltimaCuota")

                     Dim tipoViaje = cacheTipoViaje.Buscar(reserva.IdTipoViaje.IfNull())
                     Dim intereses = cacheIntereses.Buscar(tipoViaje.IdInteres.IfNull())

                     Dim agregarCuota =
                        Sub(cuota As Integer, fechaVencimiento As Date, importe As Decimal, ultima As Boolean)
                           Dim ctaCte = New Entidades.CuentaCorrientePago()
                           ctaCte.Cuota = cuota
                           ctaCte.FechaVencimiento = fechaVencimiento
                           ctaCte.ImporteCuota = importe
                           ctaCte.SaldoCuota = importe

                           ctaCte.FechaVencimiento = rFeriados.BuscaSiguienteDiaHabil(ctaCte.FechaVencimiento, excluyeSabados:=True, excluyeDomingos:=True, excluyeFeriados:=True)

                           'PE-35453 / 3) Al momento de calcular los vencimientos de las cuotas, si la FPV es mayor a la FV - CDUC debo tomar como
                           '              fecha de vencimiento de la cuota FV - CDUC.
                           Dim fechaLimiteCuotas = reserva.FechaViaje.AddDays(tipoViaje.CantidadDiasUltimaCuota * -1)
                           If ctaCte.FechaVencimiento > fechaLimiteCuotas Then
                              ctaCte.FechaVencimiento = fechaLimiteCuotas
                           End If

                           venta.CuentaCorriente.Pagos.Add(ctaCte)


                           If intereses.InteresesDias.Count > 0 Then
                              ctaCte.FechaVencimiento2 = ctaCte.FechaVencimiento.AddDays(intereses.InteresesDias(0).DiasDesde)
                              ctaCte.FechaVencimiento2 = rFeriados.BuscaSiguienteDiaHabil(ctaCte.FechaVencimiento2, intereses)
                              ctaCte.ImporteCuota2 = ctaCte.ImporteCuota * (1 + (intereses.InteresesDias(0).Interes) / 100)
                           End If
                           If Not ultima AndAlso intereses.InteresesDias.Count > 1 Then
                              ctaCte.FechaVencimiento3 = ctaCte.FechaVencimiento.AddDays(intereses.InteresesDias(1).DiasDesde)
                              ctaCte.FechaVencimiento3 = rFeriados.BuscaSiguienteDiaHabil(ctaCte.FechaVencimiento3, intereses)
                              ctaCte.ImporteCuota3 = ctaCte.ImporteCuota * (1 + (intereses.InteresesDias(1).Interes) / 100)
                           End If

                           'PE-35453 / 4) En caso de que los siguientes vencimientos de la cuota (que se calculan a partir de las tablas de intereses)
                           '              es mayor a FV - CDUC, se debe descartar dicho vencimiento (grabar NULL).

                           If ctaCte.FechaVencimiento2 > fechaLimiteCuotas Then
                              ctaCte.FechaVencimiento2 = Nothing
                              ctaCte.ImporteCuota2 = Nothing
                           End If
                           If ctaCte.FechaVencimiento3 > fechaLimiteCuotas Then
                              ctaCte.FechaVencimiento3 = Nothing
                              ctaCte.ImporteCuota3 = Nothing
                           End If

                           If Not ctaCte.FechaVencimiento2.HasValue And IdTipoComprobante = Publicos.TurismoSIRPLUSTiposComprobantes Then
                              ctaCte.FechaVencimiento2 = rFeriados.BuscaSiguienteDiaHabil(ctaCte.FechaVencimiento.AddDays(1), intereses)
                              ctaCte.ImporteCuota2 = ctaCte.ImporteCuota
                           End If
                           If Not ctaCte.FechaVencimiento3.HasValue And IdTipoComprobante = Publicos.TurismoSIRPLUSTiposComprobantes Then
                              ctaCte.FechaVencimiento3 = rFeriados.BuscaSiguienteDiaHabil(ctaCte.FechaVencimiento2.Value.AddDays(1), intereses)
                              ctaCte.ImporteCuota3 = ctaCte.ImporteCuota2
                           End If

                           Try
                              ctaCte.CodigoDeBarra = Banco.DebitosDirectos.RoelaSiro.ArmarCodigoBarras(
                                                                        venta.Cliente.CodigoCliente,
                                                                        Publicos.TurismoRoelaIdentificadorConcepto, ctaCte.FechaVencimiento,
                                                                        ctaCte.ImporteCuota, ctaCte.FechaVencimiento2, ctaCte.ImporteCuota2,
                                                                        ctaCte.FechaVencimiento3, ctaCte.ImporteCuota3, Publicos.TurismoRoelaIdentificadorCuenta)

                           Catch ex As Exception
                              Throw New Exception(String.Format("Error generando código de barras Roela: {0}", ex.Message), ex)
                           End Try

                        End Sub

                     Dim cantidadCuotas = dr.Field(Of Integer)("CantidadCuotas")
                     If importeAnticipo <> 0 Then
                        agregarCuota(0, venta.Fecha, importeAnticipo, cantidadCuotas = 0)
                     End If

                     Dim fechaPrimerVencimiento = dr.Field(Of Date)("PrimerVencimiento")
                     For iCuota = 1 To cantidadCuotas
                        agregarCuota(iCuota,
                                     fechaPrimerVencimiento.AddMonths(iCuota - 1),
                                     If(iCuota = cantidadCuotas, importeUltimaCuota, importePrimerCuota),
                                     cantidadCuotas = iCuota)
                     Next

                     tspBarra.PerformStep()
                     Windows.Forms.Application.DoEvents()

                  Next
               End Using
            End Using

            EjecutaSoloConTransaccion(
               Function()
                  Dim rReservaPasajero = New ReservasTurismoPasajeros(da)
                  For Each venta In lstVentas
                     venta.NumeroComprobante = 0

                     If String.IsNullOrWhiteSpace(venta.Direccion) Then
                        Throw New Exception(String.Format("El clienteo {0} - {1} no tiene dirección cargada. No es posible generar cuotas.",
                                                          venta.Cliente.CodigoCliente, venta.Cliente.NombreCliente))
                     End If

                     rVentas.Inserta(venta, metodoGrabacion, idFuncion)

                     rReservaPasajero.ActualizarComprobante(reserva.IdSucursal,
                                                            reserva.IdTipoReserva, reserva.Letra, reserva.CentroEmisor, reserva.NumeroReserva,
                                                            venta.Cliente.IdCliente,
                                                            venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante,
                                                            venta.CentroEmisor, venta.NumeroComprobante,
                                                            Entidades.ReservaTurismo.TipoGeneracionOpciones.Pasajero)

                     rCtaCte._ActualizaDatosReserva(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante,
                                                    venta.CentroEmisor, venta.NumeroComprobante,
                                                    reserva.FechaViaje, reserva.NombreEstablecimiento, reserva.NombrePrograma)

                     rCtaCtePagos.ActualizaCodigoDeBarraSirplus(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)

                     tspBarra.PerformStep()
                     Windows.Forms.Application.DoEvents()
                  Next
                  Return True
               End Function)
         End Sub)

   End Sub

   Public Sub GrabarFacturaDeReservas(idSucursal As Integer, reserva As Entidades.ReservaTurismo, idCajaComprobante As Integer, dtPasajeros As DataTable,
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String, tspBarra As Windows.Forms.ToolStripProgressBar)
      EjecutaConConexion(
         Sub()

            Dim drProcesar = dtPasajeros.AsEnumerable().Where(Function(dr) dr.Field(Of Boolean)("Selec")).AsEnumerable()

            If drProcesar.Count = 0 Then
               Throw New Exception("No hay comprobantes por generar")
            End If

            tspBarra.Maximum = drProcesar.Count * 2
            tspBarra.Value = 0
            Windows.Forms.Application.DoEvents()

            Dim idTipoComprobanteReserva = Publicos.TurismoTipoComprobanteFactura
            Dim tipoComprobanteReserva = New TiposComprobantes(da).GetUno(idTipoComprobanteReserva)

            Dim rVentas = New Ventas(da)
            Dim rCtaCte = New CuentasCorrientes(da)
            Dim rClientes = New Clientes(da)
            Dim rProductos = New Productos(da)

            Dim establecimiento = rClientes._GetUno(reserva.IdEstablecimiento)
            Dim listaPrecios = New ListasDePrecios(da).GetUno(Publicos.ListaPreciosPredeterminada)

            Dim cache = New BusquedasCacheadas()
            Dim lstVentas = New List(Of Entidades.Venta)()
            Dim productos = New List(Of Tuple(Of String, Entidades.Producto, Decimal, Decimal))()
            reserva.Facturacion.ForEach(
               Sub(f)
                  productos.Add(New Tuple(Of String, Entidades.Producto, Decimal, Decimal)(f.IdProducto, cache.BuscaProductoEntidadPorId(f.IdProducto), f.Precio / reserva.Costo, f.Cantidad))
               End Sub)

            Using cacheIntereses = New Ayudante.Cache.Archivos.CacheIntereses()
               Using cacheTipoViaje = New Ayudante.Cache.Turismo.CacheTurismoTipoViaje

                  For Each dr In drProcesar
                     Dim clienteParaDic = rClientes._GetUno(dr.Field(Of Long)(Entidades.ReservaTurismoPasajero.Columnas.IdClientePasajero.ToString()))

                     Dim formaDePago = cache.BuscaFormasPago(dr.Field(Of Integer?)("IdFormasPagoFact").IfNull())

                     Dim venta = rVentas.CreaVenta(idSucursal, tipoComprobanteReserva, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=Nothing,
                                                   cliente:=clienteParaDic, categoriaFiscal:=Nothing, fecha:=Date.Now,
                                                   vendedor:=Nothing, transportista:=Nothing, formaPago:=formaDePago,
                                                   descuentoRecargoPorc:=0, idCaja:=idCajaComprobante,
                                                   cotizacionDolar:=Nothing, mercDespachada:=True, numeroReparto:=Nothing,
                                                   fechaEnvio:=Nothing, proveedor:=Nothing, observaciones:=String.Empty,
                                                   cobrador:=Nothing, clienteVinculado:=establecimiento, nroOrdenCompra:=0)

                     lstVentas.Add(venta)

                     rVentas.AgregarVentaObservacion(venta, String.Format("RESERVA {0} - Establecimiento: {1}", reserva.NumeroReserva, reserva.NombreEstablecimiento))

                     For Each p In productos
                        Dim tipoImpuesto = cache.BuscaTiposImpuestos(p.Item2.IdTipoImpuesto)
                        'Agrego un producto para el programa con el importe tipo NORMAL
                        rVentas.AgregarVentaProducto(venta,
                                                     rVentas.CreaVentaProducto(p.Item2, p.Item2.NombreProducto,
                                                                               descuentoRecargoPorc1:=0, descuentoRecargoPorc2:=0,
                                                                               precio:=dr.Field(Of Decimal)("Importe") * p.Item3, cantidad:=p.Item4,
                                                                               tipoImpuesto:=tipoImpuesto, porcentajeIva:=Nothing,
                                                                               listaDePrecios:=listaPrecios, fechaEntrega:=Nothing,
                                                                               tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL, nota:=String.Empty, idEstadoVenta:=Nothing,
                                                                               venta:=venta, redondeoEnCalculo:=2),
                                                     redondeoEnCalculo:=2)

                     Next

                     tspBarra.PerformStep()
                     Windows.Forms.Application.DoEvents()

                  Next
               End Using
            End Using

            EjecutaSoloConTransaccion(
               Function()
                  Dim rReservaPasajero = New ReservasTurismoPasajeros(da)
                  For Each venta In lstVentas
                     venta.NumeroComprobante = 0

                     If String.IsNullOrWhiteSpace(venta.Direccion) Then
                        Throw New Exception(String.Format("El clienteo {0} - {1} no tiene dirección cargada. No es posible generar cuotas.",
                                                          venta.Cliente.CodigoCliente, venta.Cliente.NombreCliente))
                     End If

                     rVentas.Inserta(venta, metodoGrabacion, idFuncion)

                     rReservaPasajero.ActualizarComprobanteFact(reserva.IdSucursal,
                                                                reserva.IdTipoReserva, reserva.Letra, reserva.CentroEmisor, reserva.NumeroReserva,
                                                                venta.Cliente.IdCliente,
                                                                venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante,
                                                                venta.CentroEmisor, venta.NumeroComprobante)

                     tspBarra.PerformStep()
                     Windows.Forms.Application.DoEvents()
                  Next
                  Return True
               End Function)
         End Sub)

   End Sub

   Public Function GetFiltradoPorCodigo(numeroReserva As Integer) As DataTable
      Return GetFiltradoPorCodigo(numeroReserva, Nothing)
   End Function

   Public Function GetFiltradoPorCodigo(numeroReserva As Integer, busquedaParcial As Boolean) As DataTable
      Dim sql = New SqlServer.ReservasTurismo(da)
      Dim dt = sql.GetFiltradoPorCodigo(numeroReserva, String.Empty, False)

      If dt.Rows.Count = 0 And busquedaParcial Then
         dt = sql.GetFiltradoPorCodigo(numeroReserva, String.Empty, True)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorNombre(establecimiento As String, numeroReserva As Integer) As DataTable
      Return New SqlServer.ReservasTurismo(da).GetFiltradoPorCodigo(0, establecimiento, False)
   End Function
   Public Function GetFiltradoPorNombre(establecimiento As String) As DataTable
      Return GetFiltradoPorNombre(establecimiento)
   End Function

#End Region
End Class
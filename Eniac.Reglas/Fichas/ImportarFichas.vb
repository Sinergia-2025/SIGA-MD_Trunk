
Option Strict On
Option Explicit On
#Region "Option"
Imports Eniac.Entidades.Entidad
#End Region
Public Class ImportarFichas
   Private da As Datos.DataAccess
   Private commitLevel As CommitLevels
   Private _cache As BusquedasCacheadas

   Private Enum CommitLevels
      Todo
      ComprobanteYRecibo      'Comprobante y Recibo entran juntos
      ComprobanteORecibo      'Puede entrar el Comprobante, pero el recibo puede quedar por fuera
   End Enum

#Region "Constructores"
   Public Sub New()
      Me.New(New BusquedasCacheadas())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New(accesoDatos, New BusquedasCacheadas())
   End Sub
   Public Sub New(cache As BusquedasCacheadas)
      Me.New(New Datos.DataAccess(), cache)
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess, cache As BusquedasCacheadas)
      da = accesoDatos
      _cache = cache
      commitLevel = CommitLevels.ComprobanteYRecibo
   End Sub
#End Region


   Public Sub Grabar(dtGrilla As DataTable, fechaRecibo As DateTime, idFuncion As String)
      Dim redondeoEnCalculo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
      Try
         da.OpenConection()
         If commitLevel = CommitLevels.Todo Then da.BeginTransaction()

         Dim ficha As Entidades.Venta
         Dim rVenta As Reglas.Ventas = New Ventas(da)
         Dim rCliente As Reglas.Clientes = New Clientes(da)
         Dim rProducto As Reglas.Productos = New Productos(da)
         Dim dicCliente As Dictionary(Of Long, Entidades.Cliente) = New Dictionary(Of Long, Entidades.Cliente)()
         Dim dicProducto As Dictionary(Of String, Entidades.Producto) = New Dictionary(Of String, Entidades.Producto)()
         Dim idProducto As String
         Dim idCliente As Long
         Dim fecha As DateTime
         Dim tpComp As Entidades.TipoComprobante
         Dim vendedor As Entidades.Empleado
         Dim cobrador As Entidades.Empleado
         Dim formaPago As Entidades.VentaFormaPago = Nothing
         Dim listaPrecios As Entidades.ListaDePrecios
         Dim tipoImpuesto As Entidades.TipoImpuesto
         Dim idCaja As Integer
         Dim cantidad As Decimal
         Dim cantidadCuotas As Integer
         Dim cuotasPagas As Integer
         Dim importeTotal As Decimal
         Dim registroProcesado As Integer = 0

         Dim drCol As DataRow() = dtGrilla.Select("Importa")
         RaiseEvent IniciaGrabacion(Me, New IniciaGrabacionEventArgs() With {.CantidadTotalDeRegistros = drCol.Length})
         For Each drGrilla As DataRow In drCol
            Try
               If commitLevel = CommitLevels.ComprobanteORecibo Or commitLevel = CommitLevels.ComprobanteYRecibo Then da.BeginTransaction()

               tpComp = _cache.BuscaTipoComprobante(drGrilla(Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString())
               idCliente = Long.Parse(drGrilla(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
               fecha = DateTime.Parse(drGrilla("Fecha").ToString())

               If Not dicCliente.ContainsKey(idCliente) Then
                  dicCliente.Add(idCliente, rCliente._GetUno(idCliente))
               End If

               idCaja = Integer.Parse(drGrilla(Entidades.CajaNombre.Columnas.IdCaja.ToString()).ToString())

               vendedor = DirectCast(drGrilla("Entidad_Vendedor"), Entidades.Empleado)
               cobrador = DirectCast(drGrilla("Entidad_Cobrador"), Entidades.Empleado)
               formaPago = DirectCast(drGrilla("Entidad_FormaPago"), Entidades.VentaFormaPago)

               ficha = rVenta.CreaVenta(actual.Sucursal.Id, tpComp,
                                        drGrilla(Entidades.Venta.Columnas.Letra.ToString()).ToString(),
                                        Short.Parse(drGrilla(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToString()),
                                        Long.Parse(drGrilla(Entidades.Venta.Columnas.NumeroComprobante.ToString()).ToString()),
                                        dicCliente(idCliente),
                                        dicCliente(idCliente).CategoriaFiscal,
                                        fecha,
                                        vendedor,
                                        Nothing,
                                        formaPago,
                                        0,
                                        idCaja,
                                        Nothing,
                                        True,
                                        Nothing,
                                        Nothing,
                                        Nothing,
                                        "",
                                        cobrador:=cobrador,
                                        clienteVinculado:=Nothing,
                                        nroOrdenCompra:=0)

               RaiseEvent AvanceGrabacion(Me, New AvanceGrabacionEventArgs() With {.RegistrosProcesados = registroProcesado, .Accion = "Creando", .Comprobante = ficha})

               idProducto = drGrilla("IdProducto").ToString()
               If Not dicProducto.ContainsKey(idProducto) Then
                  dicProducto.Add(idProducto, rProducto.GetUno(idProducto))
               End If

               cantidad = Decimal.Parse(drGrilla("Cantidad").ToString())
               importeTotal = Decimal.Parse(drGrilla("ImporteTotal").ToString())

               tipoImpuesto = _cache.BuscaTiposImpuestos(dicProducto(idProducto).IdTipoImpuesto)
               listaPrecios = _cache.BuscaListaDePrecios(dicCliente(idCliente).IdListaPrecios)

               rVenta.AgregarVentaProducto(ficha, rVenta.CreaVentaProducto(dicProducto(idProducto),
                                                                           drGrilla("NombreProducto").ToString(),
                                                                           0, 0,
                                                                           Math.Round(importeTotal / cantidad, 2),
                                                                           cantidad,
                                                                           tipoImpuesto,
                                                                           dicProducto(idProducto).Alicuota,
                                                                           listaPrecios,
                                                                           Nothing,
                                                                           Entidades.Producto.TiposOperaciones.NORMAL,
                                                                           "",
                                                                           Nothing,
                                                                           ficha,
                                                                           redondeoEnCalculo), redondeoEnCalculo)

               cantidadCuotas = Integer.Parse(drGrilla("CantidadCuotas").ToString())
               cuotasPagas = Integer.Parse(drGrilla("CuotasPagas").ToString())

               ficha.CuentaCorriente.Pagos.Clear()

               CargarCuotas(ficha, formaPago, cantidadCuotas)

               RaiseEvent AvanceGrabacion(Me, New AvanceGrabacionEventArgs() With {.RegistrosProcesados = registroProcesado, .Accion = "Insertando", .Comprobante = ficha})

               rVenta.Inserta(ficha, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

               '******************************************************************************
               RaiseEvent AvanceGrabacion(Me, New AvanceGrabacionEventArgs() With {.RegistrosProcesados = registroProcesado, .Accion = "Asignando Rutas a Clientes", .Comprobante = ficha})

               Dim ruta As Entidades.MovilRuta = New Reglas.MovilRutas(da).GetUnoPorVendedor(vendedor.IdEmpleado)
               If ruta.IdRuta > 0 Then
                  Dim reglaRutaCliente As New Reglas.MovilRutasClientes(da)
                  If Not reglaRutaCliente.ExisteClienteEnRuta(ruta.IdRuta, 7, idCliente) Then
                     Dim oRutaCliente As New Entidades.MovilRutaCliente()
                     oRutaCliente.IdRuta = ruta.IdRuta
                     oRutaCliente.Dia = 7
                     oRutaCliente.Orden = reglaRutaCliente.GetOrdenRutaCliente(ruta.IdRuta, 7) + 1
                     oRutaCliente.IdCliente = idCliente
                     reglaRutaCliente._Insertar(oRutaCliente)
                  End If
               Else
                  Throw New Exception()
               End If
               '******************************************************************************

               Dim rMoviVenta As New MovimientosStock(da)
               Dim movVenta = New Ventas(da).GetMovimientoVenta(ficha)
               movVenta.Productos.All(Function(x)
                                         x.Cantidad *= -1
                                         Return True
                                      End Function)
               rMoviVenta.CargarMovimientoStock(movVenta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

               If commitLevel = CommitLevels.ComprobanteORecibo Then da.CommitTransaction()
               'Si el nivel de commit está en ComprobanteORecibo significa que puede entrar la ficha y no el recibo,
               'por lo que hago commit de la ficha y luego vuelvo a abrir la trasacción para el recibo.
               If commitLevel = CommitLevels.ComprobanteORecibo Then da.BeginTransaction()

               Dim oCtaCte As Entidades.CuentaCorriente

               Dim oReglasCuentaCorriente As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes(da)
               'Dim eCobrador As Entidades.Cobrador = DirectCast(cmbCobrador.SelectedItem, Entidades.Cobrador)

               RaiseEvent AvanceGrabacion(Me, New AvanceGrabacionEventArgs() With {.RegistrosProcesados = registroProcesado, .Accion = "Cobrando", .Comprobante = ficha})

               oCtaCte = oReglasCuentaCorriente.GrabarPagoDeFichas(actual.Sucursal.Id,
                                                                   tpComp.IdTipoComprobante,
                                                                   drGrilla(Entidades.Venta.Columnas.Letra.ToString()).ToString(),
                                                                   Short.Parse(drGrilla(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToString()),
                                                                   Long.Parse(drGrilla(Entidades.Venta.Columnas.NumeroComprobante.ToString()).ToString()),
                                                                   fechaRecibo,
                                                                   Math.Round(importeTotal / cantidadCuotas, 2) * cuotasPagas,
                                                                   0,
                                                                   vendedor,
                                                                   idCaja,
                                                                   "",
                                                                   cobrador,
                                                                   Entidades.Entidad.MetodoGrabacion.Automatico,
                                                                   idFuncion,
                                                                   False)

               If commitLevel = CommitLevels.ComprobanteORecibo Or commitLevel = CommitLevels.ComprobanteYRecibo Then da.CommitTransaction()

               registroProcesado += 1
               RaiseEvent AvanceGrabacion(Me, New AvanceGrabacionEventArgs() With {.RegistrosProcesados = registroProcesado})
               drGrilla("EstadoImporta") = "OK"
            Catch ex As Exception
               drGrilla("EstadoImporta") = "ERROR"
               drGrilla("Mensaje") = ex.Message
               Throw New Exception(ex.Message, ex)
            End Try
         Next

         RaiseEvent FinalizaGrabacion(Me, Nothing)

         If commitLevel = CommitLevels.Todo Then da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub AgregaCuota(ficha As Entidades.Venta, importeCapital As Decimal, importeInteres As Decimal, vencimiento As DateTime)

      Dim oCCP As Eniac.Entidades.CuentaCorrientePago
      oCCP = New Eniac.Entidades.CuentaCorrientePago()
      oCCP.ImporteCapital = importeCapital
      oCCP.ImporteInteres = importeInteres
      oCCP.ImporteCuota = importeCapital + importeInteres
      oCCP.SaldoCuota = oCCP.ImporteCuota
      oCCP.CuentaCorriente.ImportePesos = 0
      oCCP.FechaVencimiento = vencimiento
      ficha.CuentaCorriente.Pagos.Add(oCCP)

   End Sub

   Private Sub CargarCuotas(ficha As Entidades.Venta, formaPago As Entidades.VentaFormaPago, cantidadCuotas As Integer)

      Dim totalCuotas As Decimal = 0

      Dim DiasCC As Integer = formaPago.Dias
      Dim i As Integer = 0

      'El anticipo lo asumo, inicialmente en cero
      Dim anticipo As Decimal = 0
      Dim importeCapital As Decimal = Math.Round(ficha.ImporteTotal / cantidadCuotas, 2)

      'El anticipo no tiene interes
      'AgregaCuota(ficha, anticipo, 0, ficha.Fecha)

      'Dim sumaAnticipoCuotas As Decimal = anticipo
      totalCuotas = 0
      Dim totalADistribuir As Decimal = ficha.ImporteTotal

      Dim ultimaFecha As DateTime = ficha.Fecha             'Última fecha de vencimiento calculada (contemplando Sab/Dom/Fer)
      Dim ultimaFechaTeorica As DateTime = ficha.Fecha      'Última fecha de venc. TEORICA calculada (ignorando Sab/Dom/Fer)
      For i = 1 To cantidadCuotas
         ''''Dim pag As Eniac.Entidades.FichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

         'Si tengo que seguir contando las cuotas desde la última teórica calculada (por más que haya sido feriado)
         'tomo esa fecha y la pongo como última fecha para calcular la próxima.
         If formaPago.FechaBaseProximaCuota = Entidades.VentaFormaPago.ProximaCuota.TEORICA Then
            ultimaFecha = ultimaFechaTeorica
         End If

         'Le sumo la cantidad de días de la Forma de Pago a la última fecha de vencimiento.
         ultimaFecha = ultimaFecha.AddDays(DiasCC)
         'La copia a la TEORICA antes de analizar Sab/Dom/Fer
         ultimaFechaTeorica = ultimaFecha
         While Not EsDiaValido(ultimaFecha, formaPago)
            'Incrmento un día si la fecha no es válida (según Exclusiones de la forma de pago)
            ultimaFecha = ultimaFecha.AddDays(1)
         End While

         'Tomo la fecha calculada como fecha de vencimiento.
         AgregaCuota(ficha, importeCapital, 0, ultimaFecha)
         totalCuotas += importeCapital
      Next

      If totalCuotas <> totalADistribuir Then
         ficha.CuentaCorriente.Pagos(ficha.CuentaCorriente.Pagos.Count - 1).ImporteCapital += totalADistribuir - totalCuotas
         ficha.CuentaCorriente.Pagos(ficha.CuentaCorriente.Pagos.Count - 1).ImporteCuota += totalADistribuir - totalCuotas
         ficha.CuentaCorriente.Pagos(ficha.CuentaCorriente.Pagos.Count - 1).SaldoCuota += totalADistribuir - totalCuotas
      End If

   End Sub

   Private Function EsDiaValido(dia As DateTime, fp As Entidades.VentaFormaPago) As Boolean
      If dia.DayOfWeek = DayOfWeek.Saturday And fp.ExcluyeSabados Then
         'Si el día es Sábado y la Forma de Pago no tiene que Incluir Sábados es un día INVALIDO
         Return False
      ElseIf dia.DayOfWeek = DayOfWeek.Sunday And fp.ExcluyeDomingos Then
         'Si el día es Domingo y la Forma de Pago no tiene que Incluir Domingos es un día INVALIDO
         Return False
      ElseIf fp.ExcluyeFeriados AndAlso _cache.EsFeriado(dia) Then
         'Si la Forma de Pago no tiene que Incluir Feriados y el día es un Feriado es un día INVALIDO
         Return False
      Else
         Return True
      End If
   End Function


#Region "Definición de Eventos"
   Public Event IniciaGrabacion As EventHandler(Of IniciaGrabacionEventArgs)
   Public Class IniciaGrabacionEventArgs
      Inherits EventArgs
      Public Property CantidadTotalDeRegistros As Integer
   End Class

   Public Event AvanceGrabacion As EventHandler(Of AvanceGrabacionEventArgs)
   Public Class AvanceGrabacionEventArgs
      Inherits EventArgs
      Public Property RegistrosProcesados As Integer
      Public Property Accion As String
      Public Property Comprobante As Entidades.Venta
   End Class

   Public Event FinalizaGrabacion As EventHandler
#End Region

End Class
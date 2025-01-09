#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports Eniac.Entidades
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
#End Region
Partial Class Ventas

   ''REPARTOS
   Public Function GetInfReparto(idSucursal As Integer,
                         desde As Date,
                         hasta As Date,
                         IdVendedor As Integer,
                         idCliente As Long,
                         tipoComprobante As String,
                         numeroReparto As Long,
                         idFormasPago As Integer,
                         idUsuario As String,
                         idTransportista As Integer) As DataTable

      Return New SqlServer.Ventas(da).GetInfReparto(idSucursal,
                                                    desde,
                                                    hasta,
                                                    IdVendedor,
                                                    idCliente,
                                                    tipoComprobante,
                                                    numeroReparto,
                                                    idFormasPago,
                                                    idUsuario,
                                                    idTransportista)
   End Function

   Public Function GetRepartos(sucursales As Entidades.Sucursal(),
                               fechaEnvioDesde As Date?,
                               fechaEnvioHasta As Date?,
                               IdVendedor As Integer,
                               idCliente As Long,
                               idTipoComprobante As String,
                               numeroReparto As Long,
                               idFormasPago As Integer,
                               idUsuario As String,
                               idEstadoComprobante As String,
                               porcUtilidadDesde As Decimal?,
                               porcUtilidadHasta As Decimal?,
                               esComercial As Entidades.Publicos.SiNoTodos,
                               idCategoria As Integer,
                               idTransportista As Integer) As DataTable

      Return New SqlServer.Ventas(da).GetRepartos(sucursales,
                                                  fechaEnvioDesde,
                                                  fechaEnvioHasta,
                                                  IdVendedor,
                                                  idCliente,
                                                  idTipoComprobante,
                                                  numeroReparto,
                                                  idFormasPago,
                                                  idUsuario,
                                                  idEstadoComprobante,
                                                  porcUtilidadDesde,
                                                  porcUtilidadHasta,
                                                  esComercial,
                                                  idCategoria,
                                                  idTransportista)
   End Function

   Public Function GetUltNumeroReparto() As Integer
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
      Dim dt As DataTable = sql.GetUltNumeroReparto()
      Dim val As Integer = 0
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If
      Return val
   End Function

   Public Function GetNuevoNumeroReparto() As Integer
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
      Dim dt As DataTable = sql.GetUltNumeroRepartoMasivo()
      Dim val As Integer = 1
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString()) + 1
         End If
      End If
      Return val
   End Function

   Public Class RegistrarRepartoDatos
      Public Property dtProductos As DataTable
      Public Property dtGrilla As DataTable
   End Class

   Public Function GetParaRegistrarReparto(rutas As Entidades.MovilRuta(), idCliente As Long) As RegistrarRepartoDatos
      Try
         da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         Dim dtProductos As DataTable = sql.GetProductosParaRegistrarReparto()
         Dim dtGrilla As DataTable = sql.GetParaRegistrarReparto(dtProductos, rutas, idCliente, mostrarPrecioConIva:=True, blnPrecioConIva:=Publicos.PreciosConIVA)

         Return New RegistrarRepartoDatos() With {.dtProductos = dtProductos, .dtGrilla = dtGrilla}

      Finally
         da.CloseConection()
      End Try
   End Function

   Public Sub GrabarReparto(dtDetalle As DataTable,
                           tipoComprobante As Entidades.TipoComprobante,
                           fechaComprobantes As DateTime,
                           formaDePagoPantalla As Entidades.VentaFormaPago,
                           vendedor As Entidades.Empleado,
                           cobrador As Entidades.Empleado,
                           caja As Entidades.CajaNombre,
                           idFuncion As String,
                           idSucursalSalida As Integer,
                           idTipoComprobanteSalida As String,
                           letraSalida As String,
                           centroEmisorSalida As Integer,
                           numeroComprobanteSalida As Long,
                           idSucursalEntrada As Integer,
                           idTipoComprobanteEntrada As String,
                           letraEntrada As String,
                           centroEmisorEntrada As Integer,
                           numeroComprobanteEntrada As Long,
                           totalesEntregadosPorProducto As Dictionary(Of String, Decimal),
                           totalGastos As Decimal,
                           totalGastosCompras As Decimal,
                           totalGastosCaja As Decimal,
                           gastos As List(Of Entidades.RepartoGasto),
                           totalResumenComprobante As Decimal,
                           totalResumenEfectivo As Decimal,
                           totalResumenCtaCte As Decimal,
                           totalResumenCheques As Decimal,
                           totalResumenNCred As Decimal,
                           totalResumenReenvio As Decimal,
                           totalResumenSaldoGeneral As Decimal)

      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim rDescRec As CalculosDescuentosRecargos = New CalculosDescuentosRecargos(cache)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim ventaSalida As Entidades.Venta = GetUna(idSucursalSalida, idTipoComprobanteSalida, letraSalida, Convert.ToInt16(centroEmisorSalida), numeroComprobanteSalida)
         Dim numeroReparto As Integer = Convert.ToInt32(ventaSalida.NumeroComprobante)
         Dim fechaReparto As DateTime = ventaSalida.Fecha
         Dim transportista As Entidades.Transportista = ventaSalida.Transportista

         Dim reparto As Entidades.Reparto = New Reparto()
         reparto.FechaReparto = fechaReparto.Date
         reparto.IdReparto = numeroReparto
         reparto.Transportista = ventaSalida.Transportista

         reparto.IdSucursalSalida = idSucursalSalida
         reparto.IdTipoComprobanteSalida = idTipoComprobanteSalida
         reparto.LetraSalida = letraSalida
         reparto.CentroEmisorSalida = Convert.ToInt16(centroEmisorSalida)
         reparto.NumeroComprobanteSalida = numeroComprobanteSalida

         reparto.IdSucursalEntrada = idSucursalEntrada
         reparto.IdTipoComprobanteEntrada = idTipoComprobanteEntrada
         reparto.LetraEntrada = letraEntrada
         reparto.CentroEmisorEntrada = Convert.ToInt16(centroEmisorEntrada)
         reparto.NumeroComprobanteEntrada = numeroComprobanteEntrada

         Dim rCtaCte = New CuentasCorrientes(da)
         Dim sqlVentas As SqlServer.Ventas = New SqlServer.Ventas(da)
         sqlVentas.ActualizarNumeroReparto(idSucursalEntrada, idTipoComprobanteEntrada, letraEntrada, centroEmisorEntrada, numeroComprobanteEntrada,
                                           numeroReparto,
                                           transportista.idTransportista,
                                           fechaReparto.Date,
                                           mercDespachada:=True)
         rCtaCte._ActualizarNumeroReparto(idSucursalEntrada, idTipoComprobanteEntrada, letraEntrada, centroEmisorEntrada, numeroComprobanteEntrada, numeroReparto)

         Dim tempDt As DataTable = sqlVentas.Ventas_G1(idSucursalSalida, idTipoComprobanteSalida, letraSalida, centroEmisorSalida, numeroComprobanteSalida)
         If tempDt Is Nothing OrElse tempDt.Rows.Count = 0 Then
            Throw New Exception(String.Format("No se pudo encontrar {0} {1} {2:0000}-{3:00000000}. Por favor reintente.", idTipoComprobanteSalida, letraSalida, centroEmisorSalida, numeroComprobanteSalida, idSucursalSalida))
         End If
         If IsNumeric(tempDt.Rows(0)("NumeroReparto")) AndAlso Long.Parse(tempDt.Rows(0)("NumeroReparto").ToString()) > 0 Then
            Throw New Exception(String.Format("El {0} {1} {2:0000}-{3:00000000} fué registrado en otro reparto. Por favor verifique.", idTipoComprobanteSalida, letraSalida, centroEmisorSalida, numeroComprobanteSalida, idSucursalSalida))
         End If

         sqlVentas.ActualizarNumeroReparto(idSucursalSalida, idTipoComprobanteSalida, letraSalida, centroEmisorSalida, numeroComprobanteSalida,
                                           numeroReparto,
                                           transportista.idTransportista,
                                           fechaReparto.Date,
                                           mercDespachada:=True)
         rCtaCte._ActualizarNumeroReparto(idSucursalSalida, idTipoComprobanteSalida, letraSalida, centroEmisorSalida, numeroComprobanteSalida, numeroReparto)

         Dim clteSalida As Entidades.Cliente = New Reglas.Clientes(da)._GetUno(Long.Parse(tempDt.Rows(0)("IdCliente").ToString()))


         Dim tipoRecibo As Entidades.TipoComprobante
         tipoRecibo = New TiposComprobantes()._GetTipoComprobanteRecibo(tipoComprobante.IdTipoComprobante, 1D, Base.AccionesSiNoExisteRegistro.Nulo)

         Dim columnas As List(Of Tuple(Of String, String, String, String)) = New List(Of Tuple(Of String, String, String, String))()

         For Each dc As DataColumn In dtDetalle.Columns
            If dc.ColumnName.EndsWith("___cantidad") Then
               Dim idProducto As String = dc.ColumnName.Replace("___cantidad", "")
               columnas.Add(New Tuple(Of String, String, String, String)(dc.ColumnName, idProducto, String.Concat(idProducto, "___precio"), String.Concat(dc.ColumnName, "Cambio")))
            End If
         Next

         Dim comprobantes As List(Of Entidades.Venta) = New List(Of Entidades.Venta)()
         Dim comprobantesEntrega As List(Of Entidades.Venta) = New List(Of Entidades.Venta)()

         For Each dr As DataRow In dtDetalle.Select("ImporteTotal <> 0")
            Dim comp As Entidades.Venta = Nothing
            Dim repartoComprobante As Entidades.RepartoComprobante = Nothing
            Dim compEntrega As Entidades.Venta = Nothing

            Dim tipoComprobanteAsignado As Entidades.TipoComprobante
            If Not String.IsNullOrWhiteSpace(dr("IdTipoComprobante").ToString()) And dr("IdTipoComprobante").ToString() <> tipoComprobante.IdTipoComprobante Then
               tipoComprobanteAsignado = _cache.BuscaTipoComprobante(dr("IdTipoComprobante").ToString())
            Else
               tipoComprobanteAsignado = tipoComprobante
            End If

            Dim CategoriaAsignada As Integer
            CategoriaAsignada = Integer.Parse(dr("IdCategoria").ToString())

            For Each col As Tuple(Of String, String, String, String) In columnas
               If IsNumeric(dr(col.Item1)) Then
                  Dim cantidad As Decimal = Decimal.Parse(dr(col.Item1).ToString())
                  Dim cantidadCambio As Decimal = Decimal.Parse(dr(col.Item4).ToString())
                  If cantidad <> 0 Or cantidadCambio <> 0 Then
                     Dim idProducto As String = col.Item2
                     Dim precio As Decimal = 0
                     If IsNumeric(dr(col.Item3)) Then
                        precio = Decimal.Parse(dr(col.Item3).ToString())
                     End If


                     Dim clte As Cliente = cache.BuscaClienteEntidadPorId(Long.Parse(dr("IdCliente").ToString()))
                     clte.IdCategoria = CategoriaAsignada
                     clteSalida.IdCategoria = CategoriaAsignada

                     If comp Is Nothing Then
                        Dim formaPago As Entidades.VentaFormaPago

                        formaPago = _cache.BuscaFormasPago(clte.IdFormasPago)

                        If formaPago Is Nothing Then formaPago = formaDePagoPantalla

                        Dim descRec As Decimal = rDescRec.DescuentoRecargo(clte, tipoComprobanteAsignado.GrabaLibro, tipoComprobanteAsignado.EsPreElectronico, formaPago,
                                                                           cantidadLineasVenta:=0) 'TODO: Se pasa 0 porque el cambio es grande y se carga el PE-27093

                        comp = CreaVenta(actual.Sucursal.Id,
                                         tipoComprobanteAsignado,
                                         String.Empty, 0, Nothing,
                                         clte,
                                         Nothing,
                                         fechaComprobantes.AddSeconds(2),
                                         vendedor,
                                         transportista,
                                         formaPago:=formaPago,
                                         descuentoRecargoPorc:=descRec,
                                         idCaja:=caja.IdCaja,
                                         cotizacionDolar:=Nothing,
                                         mercDespachada:=True,
                                         numeroReparto:=numeroReparto,
                                         fechaEnvio:=fechaReparto,
                                         proveedor:=Nothing,
                                         observaciones:="",
                                         cobrador:=Nothing,
                                         clienteVinculado:=Nothing,
                                         nroOrdenCompra:=0)
                        compEntrega = CreaVenta(actual.Sucursal.Id,
                                                _cache.BuscaTipoComprobante("REPARTO-ENTREGA"),
                                                String.Empty, 0, Nothing,
                                                clteSalida,
                                                Nothing,
                                                fechaComprobantes.AddSeconds(1),
                                                vendedor,
                                                transportista,
                                                formaPago:=formaPago,
                                                descuentoRecargoPorc:=descRec,
                                                idCaja:=caja.IdCaja,
                                                cotizacionDolar:=Nothing,
                                                mercDespachada:=True,
                                                numeroReparto:=numeroReparto,
                                                fechaEnvio:=fechaReparto,
                                                proveedor:=Nothing,
                                                observaciones:="",
                                                cobrador:=Nothing,
                                                clienteVinculado:=Nothing,
                                                nroOrdenCompra:=0)
                        repartoComprobante = New Entidades.RepartoComprobante() With {.Venta = comp, .ImporteTotalFact = Nothing}
                        reparto.Comprobantes.Add(repartoComprobante)

                     End If

                     Dim producto As Entidades.Producto = cache.BuscaProductoEntidadPorId(idProducto)
                     Dim tipoImpuesto As Entidades.TipoImpuesto = cache.BuscaTiposImpuestos(producto.IdTipoImpuesto)
                     Dim desRecProd As DescuentoRecargoProducto = rDescRec.DescuentoRecargo(clte, idProducto, cantidad, 2)
                     Dim listaPrecios As Entidades.ListaDePrecios = cache.BuscaListaDePrecios(Integer.Parse(dr("IdListaPrecios").ToString()))

                     Dim repartoComprobanteProducto As RepartoComprobanteProducto = New RepartoComprobanteProducto()
                     repartoComprobanteProducto.IdProducto = producto.IdProducto
                     repartoComprobanteProducto.NombreProducto = producto.NombreProducto

                     If cantidad <> 0 Then
                        repartoComprobanteProducto.Cantidad = cantidad
                        repartoComprobanteProducto.Precio = CalculosImpositivos.ObtenerPrecioSinImpuestos(precio,
                                                                                                          producto.Alicuota,
                                                                                                          producto.PorcImpuestoInterno,
                                                                                                          producto.ImporteImpuestoInterno,
                                                                                                          producto.OrigenPorcImpInt)
                        repartoComprobanteProducto.PrecioConImp = precio

                        Dim discriminaImpuestos As Boolean
                        discriminaImpuestos = comp.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado

                        AgregarVentaProducto(comp,
                                             CreaVentaProducto(producto,
                                                               producto.NombreProducto,
                                                               desRecProd.DescuentoRecargo1, desRecProd.DescuentoRecargo2,
                                                               If(discriminaImpuestos, repartoComprobanteProducto.Precio, precio),
                                                               cantidad,
                                                               tipoImpuesto, producto.Alicuota,
                                                               listaPrecios,
                                                               Nothing,
                                                               Producto.TiposOperaciones.NORMAL, "",
                                                               Nothing,
                                                               comp, 2), 2)
                        AgregarVentaProducto(compEntrega,
                                             CreaVentaProducto(producto,
                                                               producto.NombreProducto,
                                                               desRecProd.DescuentoRecargo1, desRecProd.DescuentoRecargo2,
                                                               If(discriminaImpuestos, repartoComprobanteProducto.Precio, precio),
                                                               cantidad,
                                                               tipoImpuesto, producto.Alicuota,
                                                               listaPrecios,
                                                               Nothing,
                                                               Producto.TiposOperaciones.NORMAL, "",
                                                               Nothing,
                                                               compEntrega, 2), 2)
                     End If      'If cantidad <> 0 Then
                     If cantidadCambio <> 0 Then
                        repartoComprobanteProducto.CantidadCambio = cantidadCambio
                        AgregarVentaProducto(comp,
                                             CreaVentaProducto(producto,
                                                               producto.NombreProducto,
                                                               0, 0,
                                                               0,
                                                               cantidadCambio,
                                                               tipoImpuesto, producto.Alicuota,
                                                               listaPrecios,
                                                               Nothing,
                                                               Producto.TiposOperaciones.CAMBIO, "",
                                                               Nothing,
                                                               comp, 2), 2)
                        AgregarVentaProducto(compEntrega,
                                             CreaVentaProducto(producto,
                                                               producto.NombreProducto,
                                                               0, 0,
                                                               0,
                                                               cantidadCambio,
                                                               tipoImpuesto, producto.Alicuota,
                                                               listaPrecios,
                                                               Nothing,
                                                               Producto.TiposOperaciones.CAMBIO, "",
                                                               Nothing,
                                                               compEntrega, 2), 2)
                     End If      'If cantidadCambio <> 0 Then
                     If cantidad <> 0 Or cantidadCambio <> 0 Then
                        repartoComprobante.Productos.Add(repartoComprobanteProducto)
                     End If
                  End If         'If cantidad <> 0 Or cantidadCambio <> 0 Then
               End If            'If IsNumeric(dr(col.Item1)) Then
            Next                 'For Each col As Tuple(Of String, String, String) In columnas
            If comp IsNot Nothing Then
               comprobantes.Add(comp)
            End If
            If compEntrega IsNot Nothing Then
               comprobantesEntrega.Add(compEntrega)
            End If
         Next                    'For Each dr As DataRow In dtDetalle.Select("ImporteTotal <> 0")

         For Each comp As Entidades.Venta In comprobantesEntrega
            'Limpio el NumeroComprobante porque CrearVenta le pone el siguiente y al no grabarlo inmediatamente
            'después crea todos con el mismo número. Con 0 el Insertar toma el siguiente número.
            comp.NumeroComprobante = 0
            Inserta(comp, Entidad.MetodoGrabacion.Automatico, idFuncion)
         Next                    'For Each comp As Entidades.Venta In comprobantesEntrega

         For Each comp As Entidades.Venta In comprobantes
            'Limpio el NumeroComprobante porque CrearVenta le pone el siguiente y al no grabarlo inmediatamente
            'después crea todos con el mismo número. Con 0 el Insertar toma el siguiente número.
            comp.NumeroComprobante = 0
            Inserta(comp, Entidad.MetodoGrabacion.Automatico, idFuncion)
         Next                    'For Each comp As Entidades.Venta In comprobantes

         Dim sucursalCliente As Sucursal = New Sucursales(da).GetUna(clteSalida.IdSucursalAsociada, False)

         Dim rMovCompra = New MovimientosStock(da)
         For Each total As KeyValuePair(Of String, Decimal) In totalesEntregadosPorProducto
            If Not dtDetalle.Columns.Contains(String.Format("{0}___cantidad", total.Key)) Then

               Dim coeficienteStock As Integer = -1

               'Busco el Tipo de Movimiento que tiene el tilde en Reserva Mercaderia
               Dim tipoMovimiento As Entidades.TipoMovimiento = _cache.BuscaTipoMovimientoReservaMercaderia()
               If tipoMovimiento Is Nothing Then
                  Throw New Exception("No está definido ningún Tipo de Movimiento con el tilde en Reserva de Mercadería. Verifique y reintente.")
               End If


               'Instancio el Movimiento de Compra poniendo en la Observacion el motivo de la reserva.
               Dim movi = New MovimientoStock()
               movi.IdSucursal = sucursalCliente.IdSucursal
               movi.Sucursal = sucursalCliente
               movi.TipoMovimiento = tipoMovimiento
               movi.FechaMovimiento = Now
               movi.Usuario = actual.Nombre
               movi.Observacion = String.Format("Reparto: {0}", numeroReparto)

               'Instancio un Movimiento de Compra Producto poniendo el producto a reservar y la cantidad del stock a descontar.
               Dim moviProd = New MovimientoStockProducto()
               moviProd.IdSucursal = sucursalCliente.IdSucursal
               moviProd.IdProducto = total.Key
               'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
               moviProd.Cantidad = total.Value * coeficienteStock
               moviProd.Orden = 1
               movi.Productos.Add(moviProd)

               'Grabo el movimiento esperando que el mismo, al estar marcado como Reserva de Mercadería, impacte en StockReservado.
               rMovCompra.CargarMovimientoStock(movi, Entidad.MetodoGrabacion.Automatico, idFuncion)
            End If
         Next

         For Each dr As DataRow In dtDetalle.Select("ImportePagado <> 0")
            Dim importePagado As Decimal = Decimal.Parse(dr("ImportePagado").ToString())
            Dim eCuentaCorriente As Entidades.CuentaCorriente
            Dim rCtaCteRecibo As CtaCteClienteRecibo = New CtaCteClienteRecibo()
            Dim rCuentasCorrientes As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes(da)
            Dim cli As Cliente = cache.BuscaClienteEntidadPorId(Long.Parse(dr("IdCliente").ToString()))

            Dim formaPago As Entidades.VentaFormaPago

            formaPago = _cache.BuscaFormasPago(cli.IdFormasPago)
            If formaPago Is Nothing Then formaPago = formaDePagoPantalla

            eCuentaCorriente = rCtaCteRecibo.GetCtaCteCliente(tipoRecibo.IdTipoComprobante, tipoRecibo.LetrasHabilitadas, numeroComprobante:=0,
                                                  fechaComprobantes,
                                                  formaPago.IdFormasPago,
                                                  cli, cli.Vendedor, cobrador,
                                                  observaciones:="",
                                                  importePagado,
                                                  importePagado, importeDolares:=0, importeTarjetas:=0, importeTransferencia:=0,
                                                  idCuentaBancaria:=0,
                                                  caja.IdCaja, pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                  da,
                                                  nroOrdenCompra:=0)

            eCuentaCorriente.Pagos = rCuentasCorrientes.GetPagosDeCliente(eCuentaCorriente.TipoComprobante,
                                                                          eCuentaCorriente.IdSucursal,
                                                                          eCuentaCorriente.Cliente.IdCliente,
                                                                          eCuentaCorriente.ImporteTotal,
                                                                          Nothing)

            rCuentasCorrientes.Inserta(eCuentaCorriente, Entidad.MetodoGrabacion.Automatico, idFuncion)

            Dim encontro As Boolean = False
            For Each rc As RepartoComprobante In reparto.Comprobantes
               If Not rc.Venta Is Nothing Then
                  If rc.Venta.Cliente.IdCliente = eCuentaCorriente.Cliente.IdCliente Then
                     rc.Recibo = eCuentaCorriente
                     rc.ImporteTotalRecibo = eCuentaCorriente.ImporteTotal
                     encontro = True
                  End If
               End If
            Next
            If Not encontro Then
               Dim repartoComprobante As New Entidades.RepartoComprobante() With {.Recibo = eCuentaCorriente, .ImporteTotalRecibo = Nothing}
               reparto.Comprobantes.Add(repartoComprobante)
            End If


         Next                    'For Each dr As DataRow In dtDetalle.Select("ImportePagado <> 0")

         'El total de gastos se registra en la caja indicada como salida (si es positivo)
         If gastos.Count > 0 Then
            Dim rCajaDetalles As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)
            Dim rCajas As Reglas.Cajas = New Reglas.Cajas(da)
            For Each gasto As Entidades.RepartoGasto In gastos
               Dim detaE As Entidades.CajaDetalles
               detaE = New Entidades.CajaDetalles(actual.Sucursal.Id, actual.Nombre, "")
               With detaE
                  .FechaMovimiento = fechaComprobantes
                  .IdSucursal = actual.Sucursal.Id
                  .IdCaja = caja.IdCaja
                  .IdTipoMovimiento = "E"c
                  .NumeroPlanilla = rCajas.GetPlanillaActual(.IdSucursal, .IdCaja).NumeroPlanilla
                  .NumeroMovimiento = rCajaDetalles.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCaja, .NumeroPlanilla)

                  gasto.IdCaja = .IdCaja
                  gasto.NumeroPlanilla = .NumeroPlanilla
                  gasto.NumeroMovimiento = .NumeroMovimiento

                  .Observacion = gasto.Observacion

                  .IdCuentaCaja = gasto.IdCuentaCaja

                  .ImportePesos = gasto.ImportePesos * -1
                  .ImporteDolares = 0
                  .ImporteTarjetas = 0
                  .ImporteTickets = 0
                  .ImporteDolares = 0
                  'cambio el monto porque es un egreso
                  .ImporteCheques = 0
                  .ImporteBancos = 0    'por ahora
                  .EsModificable = False
                  .GeneraContabilidad = True
               End With
               rCajaDetalles.InsertarNuevoMovimiento(detaE)
            Next

         End If         'If gastos.Count > 0 Then
         reparto.TotalGastos = totalGastos
         reparto.TotalGastosCompras = totalGastosCompras
         reparto.TotalGastosCaja = totalGastosCaja
         reparto.Gastos = gastos

         reparto.TotalResumenComprobante = totalResumenComprobante
         reparto.TotalResumenEfectivo = totalResumenEfectivo
         reparto.TotalResumenCtaCte = totalResumenCtaCte
         reparto.TotalResumenCheques = totalResumenCheques
         reparto.TotalResumenNCred = totalResumenNCred
         reparto.TotalResumenReenvio = totalResumenReenvio
         reparto.TotalResumenSaldoGeneral = totalResumenSaldoGeneral

         'Throw New Exception("Corte para pruebas")

         Dim rReparto As Reglas.Repartos = New Reglas.Repartos(da)
         rReparto.Inserta(reparto)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try


   End Sub

End Class

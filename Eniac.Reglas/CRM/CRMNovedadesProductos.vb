Option Strict On
Option Explicit On

Public Class CRMNovedadesProductos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.CRMNovedadProducto.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMNovedadProducto.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Sub _Inserta(entidad As Entidades.CRMNovedadProducto)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.CRMNovedadProducto)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.CRMNovedadProducto)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
#End Region

#Region "Métodos Públicos"
   Public Sub _Inserta(novedad As Entidades.CRMNovedad)
      If novedad.ProductosNovedad IsNot Nothing Then
         novedad.ProductosNovedad.ForEach(
            Sub(en)
               en.TipoNovedad = novedad.TipoNovedad
               en.LetraNovedad = novedad.Letra
               en.CentroEmisor = novedad.CentroEmisor
               en.IdNovedad = novedad.IdNovedad
               _Inserta(en)
            End Sub)
         CargarAjusteStock(novedad)
      End If
   End Sub

   Public Sub _Actualiza(novedad As Entidades.CRMNovedad, novedadActual As Entidades.CRMNovedad)
      If novedad.ProductosNovedad IsNot Nothing Then
         For Each en In novedad.ProductosNovedad
            en.TipoNovedad = novedadActual.TipoNovedad
            en.LetraNovedad = novedadActual.Letra
            en.CentroEmisor = novedadActual.CentroEmisor
            en.IdNovedad = novedadActual.IdNovedad
            If Not en.StockConsumidoProducto Then
               ''If novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR Then
               ''   '-- Revertir Stock.- --
               ''   en.StockConsumidoProducto = True
               ''End If
               If novedadActual.ProductosNovedad.Any(Function(enActual) en.IdProducto = enActual.IdProducto And en.OrdenProducto = enActual.OrdenProducto) Then
                  'Lo encontré: Lo Actualizo
                  'Dim depositoActual As Integer = en.IdDepositoActual
                  'Dim ubicacionActual As Integer = en.IdUbicacionActual
                  'en.IdDepositoActual = en.IdDepositoAnterior
                  'en.IdUbicacionActual = en.IdUbicacionAnterior
                  'en.IdDepositoAnterior = depositoActual
                  'en.IdUbicacionAnterior = ubicacionActual
                  _Actualiza(en)
               Else
                  'No lo encontré: Es nuevo
                  _Inserta(en)
               End If
               ''Else
               ''   If novedad.AjustarStock = Entidades.Publicos.AjustaStock.REVERTIR Then
               ''      '-- Revertir Stock.- --
               ''      en.StockConsumidoProducto = False
               ''      'Lo encontré: Lo Actualizo
               ''      _Actualiza(en)
               ''   End If
            End If
         Next
         ''-- Actualizo Consumo de Stock.- --
         CargarAjusteStock(novedad)

         novedadActual.ProductosNovedad.ForEach(
            Sub(enActual)
               If Not novedad.ProductosNovedad.Any(Function(en) en.IdProducto = enActual.IdProducto And en.OrdenProducto = enActual.OrdenProducto) Then
                  novedadActual.AjustarStock = Entidades.Publicos.AjustaStock.DEVRESERVAR
                  enActual.StockReservadoProducto = False
                  CargarAjusteStock(novedadActual)
                  _Borra(enActual)
               End If
            End Sub)

      End If
   End Sub

   Public Sub _Borra(novedad As Entidades.CRMNovedad)
      If novedad.ProductosNovedad IsNot Nothing Then
         _Borra(New Entidades.CRMNovedadProducto() With
                  {
                     .TipoNovedad = novedad.TipoNovedad,
                     .LetraNovedad = novedad.Letra,
                     .CentroEmisor = novedad.CentroEmisor,
                     .IdNovedad = novedad.IdNovedad
                  })
         CargarAjusteStock(novedad)
      End If
   End Sub

   Public Function GetTodos(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As List(Of Entidades.CRMNovedadProducto)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad, letra, centroEmisor, idNovedad)

      Return CargaLista(dt, Sub(o, dr) CargarUno(DirectCast(o, Entidades.CRMNovedadProducto), dr), Function() New Entidades.CRMNovedadProducto())
   End Function

   Public Overloads Function GetAll(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As System.Data.DataTable
      Return New SqlServer.CRMNovedadesProductos(Me.da).CRMNovedadesProductos_GA(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function

   Private Sub CargarUno(o As Entidades.CRMNovedadProducto, dr As DataRow)
      With o
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()))
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())
         .LetraNovedad = dr.Field(Of String)(Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString())
         .OrdenProducto = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString())
         .NombreProducto = dr.Field(Of String)(Entidades.CRMNovedadProducto.Columnas.NombreProducto.ToString())
         .CantidadProducto = dr.Field(Of Decimal)(Entidades.CRMNovedadProducto.Columnas.CantidadProducto.ToString())
         .PrecioProducto = dr.Field(Of Decimal)(Entidades.CRMNovedadProducto.Columnas.PrecioProducto.ToString())
         .ImporteNovedad = (.CantidadProducto * .PrecioProducto)
         .IdListaPrecios = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdListaPrecios.ToString())
         .StockConsumidoProducto = dr.Field(Of Boolean)(Entidades.CRMNovedadProducto.Columnas.StockConsumidoProducto.ToString())
         .nroSerie = dr(Entidades.Producto.Columnas.NroSerie.ToString()).ToString()

         .ProductosNovedadNrosSerie = New CRMNovedadesProductosNrosSerie(da).GetTodos(.IdTipoNovedad, .LetraNovedad, .CentroEmisor,
                                                                             .IdNovedad, .IdProducto)

         .StockReservadoProducto = dr.Field(Of Boolean)(Entidades.CRMNovedadProducto.Columnas.StockReservadoProducto.ToString())

         .ProductosNovedadLote = New CRMNovedadesProductosLotes(da).GetTodos(.IdTipoNovedad, .LetraNovedad, .CentroEmisor,
                                                                             .IdNovedad, .IdProducto)
         If dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdSucursalActual.ToString()) > 0 Then
            .IdSucursalActual = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdSucursalActual.ToString())
         End If
         If dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdDepositoActual.ToString()) > 0 Then
            .IdDepositoActual = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdDepositoActual.ToString())
         End If
         If dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdUbicacionActual.ToString()) > 0 Then
            .IdUbicacionActual = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdUbicacionActual.ToString())
         End If
         If dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdsucursalAnterior.ToString()) > 0 Then
            .IdsucursalAnterior = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdsucursalAnterior.ToString())
         End If
         If dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdDepositoAnterior.ToString()) > 0 Then
            .IdDepositoAnterior = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdDepositoAnterior.ToString())
         End If
         If dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdUbicacionAnterior.ToString()) > 0 Then
            .IdUbicacionAnterior = dr.Field(Of Integer)(Entidades.CRMNovedadProducto.Columnas.IdUbicacionAnterior.ToString())
         End If
      End With
   End Sub

   Private Sub CargarAjusteStock(novedad As Entidades.CRMNovedad)
      If novedad.AjustarStock = Entidades.Publicos.AjustaStock.NOAJUSTA Then
         Exit Sub
      End If

      Dim idTipoMovimiento As String

      If novedad.ProductosNovedad.Count = 0 Then Exit Sub

      If String.IsNullOrWhiteSpace(Publicos.CRMNovedadesMovimientoConsumo) Then Throw New Exception("No está configurado el tipo de movimiento para Consumo. Parámetros del Sistema -> RMA -> Movimiento para Consumo")
      If String.IsNullOrWhiteSpace(Publicos.CRMNovedadesMovimientoReversado) Then Throw New Exception("No está configurado el tipo de movimiento para Reversado. Parámetros del Sistema -> RMA -> Movimiento para Reversado")
      If String.IsNullOrWhiteSpace(Publicos.CRMNovedadesMovimientoReserva) Then Throw New Exception("No está configurado el tipo de movimiento para Reserva. Parámetros del Sistema -> RMA -> Movimiento para Reserva")
      If String.IsNullOrWhiteSpace(Publicos.CRMNovedadesMovimientoDevReserva) Then Throw New Exception("No está configurado el tipo de movimiento para Dev. Reserva. Parámetros del Sistema -> RMA -> Movimiento para Dev. Reserva")

      Dim eMov = New Entidades.MovimientoStock()
      Dim eMovReserva = New Entidades.MovimientoStock()
      Dim eMovReservaLote As Entidades.MovimientoStockProductoLotes = New Entidades.MovimientoStockProductoLotes()


      idTipoMovimiento = If(novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR, Publicos.CRMNovedadesMovimientoConsumo, Publicos.CRMNovedadesMovimientoReversado)


      With eMov
         .Sucursal = New Sucursales(da).GetUna(actual.Sucursal.Id, False)
         '-- Recupera el Tipo de Movimiento.- --

         Select Case novedad.AjustarStock
            Case Entidades.Publicos.AjustaStock.RESERVAR
               idTipoMovimiento = Publicos.CRMNovedadesMovimientoReserva
               .TipoMovimiento = New TiposMovimientos(da).GetUno(Publicos.CRMNovedadesMovimientoConsumo)
            Case Entidades.Publicos.AjustaStock.DEVRESERVAR
               idTipoMovimiento = Publicos.CRMNovedadesMovimientoDevReserva
               .TipoMovimiento = New TiposMovimientos(da).GetUno(Publicos.CRMNovedadesMovimientoReversado)
            Case Else
               .TipoMovimiento = New TiposMovimientos(da).GetUno(idTipoMovimiento)
         End Select


         '--------------------------------------
         .FechaMovimiento = Date.Now
         .DescuentoRecargo = 0
         .Total = 0
         .PercepcionIVA = 0
         .PercepcionIB = 0
         .PercepcionGanancias = 0
         .PercepcionVarias = 0
         .Comentarios = String.Empty
         .Observacion = String.Empty
         .Usuario = actual.Nombre




         Select Case novedad.AjustarStock
            Case Entidades.Publicos.AjustaStock.RESERVAR, Entidades.Publicos.AjustaStock.DEVRESERVAR

               '------ Hago la reserva en el deposito de reserva----------
               With eMovReserva
                  .Sucursal = New Sucursales(da).GetUna(actual.Sucursal.Id, False)
                  '-- Recupera el Tipo de Movimiento.- --
                  .TipoMovimiento = New TiposMovimientos(da).GetUno(idTipoMovimiento)
                  '--------------------------------------
                  .FechaMovimiento = Date.Now
                  .DescuentoRecargo = 0
                  .Total = 0
                  .PercepcionIVA = 0
                  .PercepcionIB = 0
                  .PercepcionGanancias = 0
                  .PercepcionVarias = 0
                  .Comentarios = String.Empty
                  .Observacion = String.Empty
                  .Usuario = actual.Nombre

                  Dim paraReservar = Function(p As Entidades.CRMNovedadProducto) Not p.StockReservadoProducto And Not p.StockConsumidoProducto
                  Dim paraAnularReserva = Function(p As Entidades.CRMNovedadProducto) Not p.StockReservadoProducto And Not p.StockConsumidoProducto

                  novedad.ProductosNovedad.Where(If(novedad.AjustarStock = Entidades.Publicos.AjustaStock.RESERVAR, paraReservar, paraAnularReserva)).ToList().
              ForEach(
                 Sub(en)
                    Dim eProdSuc = New ProductosSucursales(da)._GetUno(eMov.Sucursal.IdSucursal, en.IdProducto)
                    Dim eLineaMov = New Entidades.MovimientoStockProducto()
                    Dim LoteProducto As Entidades.MovimientoStockProductoLotes
                    Dim NroSerieProducto As Entidades.MovimientoStockProductoNrosSerie

                    With eLineaMov
                       '-- Define Valores.- --
                       .CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE
                       .NombreProducto = en.NombreProducto
                       .Cantidad = en.CantidadProducto
                       .IdProducto = en.IdProducto
                       .IdDeposito = en.IdDepositoActual
                       .IdUbicacion = en.IdUbicacionActual
                       '-- Inicializa Valores.- --
                       .DescuentoRecargo = 0
                       .PorcentajeIVA = 0
                       .TotalProducto = 0
                       .ImporteTotal = 0
                       .Precio = 0
                       .IVA = 0
                       .Stock = eProdSuc.Stock
                       .Usuario = actual.Nombre
                       .IdLote = String.Empty
                       .VtoLote = Nothing
                       .Orden = eMov.Productos.Count + 1
                       .IdSucursal = actual.Sucursal.Id

                       '--cargo los lotes  
                       For Each lot As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote

                          LoteProducto = New Entidades.MovimientoStockProductoLotes
                          LoteProducto.IdSucursal = lot.IdSucursal
                          LoteProducto.IdProducto = lot.IdProducto
                          LoteProducto.IdLote = lot.IdLote
                          LoteProducto.Cantidad = lot.CantidadActual
                          LoteProducto.Orden = lot.OrdenProducto
                          LoteProducto.IdDeposito = lot.IdDeposito
                          LoteProducto.IdUbicacion = lot.IdUbicacion
                          LoteProducto.FechaVencimiento = lot.FechaVencimiento

                          .ProductosNrosLotes.Add(LoteProducto)

                       Next

                       For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie

                          NroSerieProducto = New Entidades.MovimientoStockProductoNrosSerie
                          NroSerieProducto.IdSucursal = ns.IdSucursal
                          NroSerieProducto.IdProducto = ns.IdProducto
                          NroSerieProducto.NroSerie = ns.NroSerie
                          NroSerieProducto.Cantidad = .Cantidad
                          NroSerieProducto.Orden = ns.OrdenProducto
                          NroSerieProducto.IdDeposito = ns.IdDeposito
                          NroSerieProducto.IdUbicacion = ns.IdUbicacion


                          .ProductosNrosSerie.Add(NroSerieProducto)

                       Next

                    End With
                    eMovReserva.Productos.Add(eLineaMov)


                    ''------ Hago el consumo en el deposito original----------

                    Dim eLineaMovCons = New Entidades.MovimientoStockProducto()
                    Dim LoteProductoCons As Entidades.MovimientoStockProductoLotes
                    With eLineaMovCons
                       '-- Define Valores.- --
                       .CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE
                       .NombreProducto = en.NombreProducto
                       .Cantidad = en.CantidadProducto
                       .IdProducto = en.IdProducto
                       .IdDeposito = eProdSuc.IdDepositoDefecto
                       .IdUbicacion = eProdSuc.IdUbicacionDefecto
                       '-- Inicializa Valores.- --
                       .DescuentoRecargo = 0
                       .PorcentajeIVA = 0
                       .TotalProducto = 0
                       .ImporteTotal = 0
                       .Precio = 0
                       .IVA = 0
                       .Stock = eProdSuc.Stock
                       .Usuario = actual.Nombre
                       .IdLote = String.Empty
                       .VtoLote = Nothing
                       .Orden = eMov.Productos.Count + 1
                       .IdSucursal = actual.Sucursal.Id

                       For Each lot As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote

                          LoteProductoCons = New Entidades.MovimientoStockProductoLotes
                          LoteProductoCons.IdSucursal = lot.IdSucursal
                          LoteProductoCons.IdProducto = lot.IdProducto
                          LoteProductoCons.IdLote = lot.IdLote
                          LoteProductoCons.Cantidad = lot.CantidadActual
                          LoteProductoCons.Orden = lot.OrdenProducto
                          LoteProductoCons.IdDeposito = eProdSuc.IdDepositoDefecto
                          LoteProductoCons.IdUbicacion = eProdSuc.IdUbicacionDefecto
                          LoteProductoCons.FechaVencimiento = lot.FechaVencimiento

                          .ProductosNrosLotes.Add(LoteProductoCons)
                       Next

                       For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie

                             NroSerieProducto = New Entidades.MovimientoStockProductoNrosSerie
                             NroSerieProducto.IdSucursal = ns.IdSucursal
                             NroSerieProducto.IdProducto = ns.IdProducto
                             NroSerieProducto.NroSerie = ns.NroSerie
                             NroSerieProducto.Cantidad = .Cantidad
                             NroSerieProducto.Orden = ns.OrdenProducto
                             NroSerieProducto.IdDeposito = eProdSuc.IdDepositoDefecto
                             NroSerieProducto.IdUbicacion = eProdSuc.IdUbicacionDefecto
                          .ProductosNrosSerie.Add(NroSerieProducto)

                       Next

                    End With
                    eMov.Productos.Add(eLineaMovCons)

                    ActualizaStockReservadoProducto(en, novedad.AjustarStock = Entidades.Publicos.AjustaStock.RESERVAR)
                    Dim Deposito As Integer
                    Dim Ubicacion As Integer
                    Dim Vendido As Boolean
                    If novedad.AjustarStock = Entidades.Publicos.AjustaStock.RESERVAR Then
                       Deposito = en.IdDepositoActual
                       Ubicacion = en.IdUbicacionActual
                       Vendido = True
                    Else
                       Deposito = en.IdDepositoAnterior
                       Ubicacion = en.IdUbicacionAnterior
                       Vendido = False
                    End If

                    Dim rProductosNrosSerie = New ProductosNrosSerie(da)
                    For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie
                       rProductosNrosSerie.ActualizaDepositoVendido(ns.IdProducto, ns.NroSerie,
                                                                    Deposito, Ubicacion, Vendido)
                    Next

                 End Sub)
               End With
               If eMovReserva.Productos.Count > 0 Then
                  Dim rMovimientos = New MovimientosStock(da)
                  rMovimientos._Insertar(eMovReserva, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, String.Empty) ' "CRMNovedadesABMCRM")
               End If

            Case Else

               '-- Revierto o hago reserva segun si es consumo o reversion
               MovimientosReserva(novedad.AjustarStock, novedad)


               '-- Carga los productos 
               Dim paraConsumir = Function(p As Entidades.CRMNovedadProducto) Not p.StockConsumidoProducto
               Dim paraRevertir = Function(p As Entidades.CRMNovedadProducto) p.StockConsumidoProducto


               novedad.ProductosNovedad.Where(If(novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR, paraConsumir, paraRevertir)).ToList().
                  ForEach(
                     Sub(en)
                        Dim eProdSuc = New ProductosSucursales(da)._GetUno(eMov.Sucursal.IdSucursal, en.IdProducto)
                        Dim eLineaMov = New Entidades.MovimientoStockProducto()
                        With eLineaMov
                           '-- Define Valores.- --
                           .CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE
                           .NombreProducto = en.NombreProducto
                           .Cantidad = en.CantidadProducto
                           .IdProducto = en.IdProducto
                           .IdDeposito = eProdSuc.IdDepositoDefecto
                           .IdUbicacion = eProdSuc.IdUbicacionDefecto
                           '-- Inicializa Valores.- --
                           .DescuentoRecargo = 0
                           .PorcentajeIVA = 0
                           .TotalProducto = 0
                           .ImporteTotal = 0
                           .Precio = 0
                           .IVA = 0
                           .Stock = eProdSuc.Stock
                           .Usuario = actual.Nombre
                           .IdLote = String.Empty
                           .VtoLote = Nothing
                           .Orden = eMov.Productos.Count + 1
                           .IdSucursal = actual.Sucursal.Id

                           For Each lot As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote

                              eMovReservaLote = New Entidades.MovimientoStockProductoLotes
                              eMovReservaLote.IdSucursal = lot.IdSucursal
                              eMovReservaLote.IdProducto = lot.IdProducto
                              eMovReservaLote.IdLote = lot.IdLote
                              eMovReservaLote.Cantidad = lot.CantidadActual
                              eMovReservaLote.Orden = lot.OrdenProducto
                              eMovReservaLote.IdDeposito = eProdSuc.IdDepositoDefecto
                              eMovReservaLote.IdUbicacion = eProdSuc.IdUbicacionDefecto
                              eMovReservaLote.FechaVencimiento = lot.FechaVencimiento

                              .ProductosNrosLotes.Add(eMovReservaLote)
                           Next

                        End With
                        eMov.Productos.Add(eLineaMov)
                        ActualizaStockConsumidoProducto(en, novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR)
                        ActualizaDepositos(en)
                        Dim Vendido As Boolean = Boolean.Parse(IIf(novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR, True, False).ToString())
                        Dim rProductosNrosSerie = New ProductosNrosSerie(da)
                        For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie
                           rProductosNrosSerie.ActualizaDepositoVendido(ns.IdProducto, ns.NroSerie, en.IdDepositoAnterior,
                                                                        en.IdUbicacionAnterior, Vendido)
                        Next
                     End Sub)


         End Select

      End With
      If eMov.Productos.Count > 0 Then
         Dim rMovimientos = New MovimientosStock(da)
         rMovimientos._Insertar(eMov, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, String.Empty) ' "CRMNovedadesABMCRM")

      End If
   End Sub

   Private Sub MovimientosReserva(AjustarStock As Entidades.Publicos.AjustaStock, novedad As Entidades.CRMNovedad)

      Dim eMovStock = New Entidades.MovimientoStock()
      Dim eMovReserva = New Entidades.MovimientoStock()

      Dim TipoMovimientoReserva As String
      Dim TipoMovimientoStock As String

      If novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR Then
         TipoMovimientoReserva = Publicos.CRMNovedadesMovimientoDevReserva
         TipoMovimientoStock = Publicos.CRMNovedadesMovimientoReversado
      Else
         TipoMovimientoReserva = Publicos.CRMNovedadesMovimientoReserva
         TipoMovimientoStock = Publicos.CRMNovedadesMovimientoConsumo
      End If


      '------ Hago movimientos en el deposito reserva----------

      With eMovReserva
         .Sucursal = New Sucursales(da).GetUna(actual.Sucursal.Id, False)
         '-- Recupera el Tipo de Movimiento.- --
         .TipoMovimiento = New TiposMovimientos(da).GetUno(TipoMovimientoReserva)
         '--------------------------------------
         .FechaMovimiento = Date.Now
         .DescuentoRecargo = 0
         .Total = 0
         .PercepcionIVA = 0
         .PercepcionIB = 0
         .PercepcionGanancias = 0
         .PercepcionVarias = 0
         .Comentarios = String.Empty
         .Observacion = String.Empty
         .Usuario = actual.Nombre


         Dim paraReservar = Function(p As Entidades.CRMNovedadProducto) p.StockReservadoProducto And Not p.StockConsumidoProducto
         Dim paraAnularReserva = Function(p As Entidades.CRMNovedadProducto) p.StockReservadoProducto And p.StockConsumidoProducto

         novedad.ProductosNovedad.Where(If(novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR, paraReservar, paraAnularReserva)).ToList().
     ForEach(
        Sub(en)
           Dim eProdSuc = New ProductosSucursales(da)._GetUno(eMovReserva.Sucursal.IdSucursal, en.IdProducto)
           Dim eLineaMov = New Entidades.MovimientoStockProducto()
           Dim LoteProducto As Entidades.MovimientoStockProductoLotes
           Dim NroSerieProducto As Entidades.MovimientoStockProductoNrosSerie

           With eLineaMov
              '-- Define Valores.- --
              .CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE
              .NombreProducto = en.NombreProducto
              .Cantidad = en.CantidadProducto
              .IdProducto = en.IdProducto

              If novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR Then
                 .IdDeposito = en.IdDepositoActual
                 .IdUbicacion = en.IdUbicacionActual
              Else
                 .IdDeposito = en.IdDepositoAnterior
                 .IdUbicacion = en.IdUbicacionAnterior
              End If

              '-- Inicializa Valores.- --
              .DescuentoRecargo = 0
              .PorcentajeIVA = 0
              .TotalProducto = 0
              .ImporteTotal = 0
              .Precio = 0
              .IVA = 0
              .Stock = eProdSuc.Stock
              .Usuario = actual.Nombre
              .IdLote = String.Empty
              .VtoLote = Nothing
              .Orden = eMovReserva.Productos.Count + 1
              .IdSucursal = actual.Sucursal.Id

              '--cargo los lotes  
              For Each lot As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote

                 LoteProducto = New Entidades.MovimientoStockProductoLotes
                 LoteProducto.IdSucursal = lot.IdSucursal
                 LoteProducto.IdProducto = lot.IdProducto
                 LoteProducto.IdLote = lot.IdLote
                 LoteProducto.Cantidad = lot.CantidadActual
                 LoteProducto.Orden = lot.OrdenProducto
                 If novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR Then
                    LoteProducto.IdDeposito = lot.IdDeposito
                    LoteProducto.IdUbicacion = lot.IdUbicacion
                 Else
                    LoteProducto.IdDeposito = en.IdDepositoAnterior
                    LoteProducto.IdUbicacion = en.IdUbicacionAnterior
                 End If

                 LoteProducto.FechaVencimiento = lot.FechaVencimiento

                 .ProductosNrosLotes.Add(LoteProducto)

              Next
              For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie

                 NroSerieProducto = New Entidades.MovimientoStockProductoNrosSerie
                 NroSerieProducto.IdSucursal = ns.IdSucursal
                 NroSerieProducto.IdProducto = ns.IdProducto
                 NroSerieProducto.NroSerie = ns.NroSerie
                 NroSerieProducto.Cantidad = .Cantidad
                 NroSerieProducto.Orden = ns.OrdenProducto
                 If novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR Then
                    NroSerieProducto.IdDeposito = ns.IdDeposito
                    NroSerieProducto.IdUbicacion = ns.IdUbicacion
                 Else
                    NroSerieProducto.IdDeposito = en.IdUbicacionAnterior
                    NroSerieProducto.IdUbicacion = en.IdUbicacionAnterior
                 End If

                 .ProductosNrosSerie.Add(NroSerieProducto)

              Next
           End With
           eMovReserva.Productos.Add(eLineaMov)


        End Sub)
      End With
      If eMovReserva.Productos.Count > 0 Then
         Dim rMovimientos = New MovimientosStock(da)
         rMovimientos._Insertar(eMovReserva, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, String.Empty)
      End If

      '------ Hago movimientos en el deposito original----------
      With eMovStock
         .Sucursal = New Sucursales(da).GetUna(actual.Sucursal.Id, False)
         .TipoMovimiento = New TiposMovimientos(da).GetUno(TipoMovimientoStock)
         '--------------------------------------
         .FechaMovimiento = Date.Now
         .DescuentoRecargo = 0
         .Total = 0
         .PercepcionIVA = 0
         .PercepcionIB = 0
         .PercepcionGanancias = 0
         .PercepcionVarias = 0
         .Comentarios = String.Empty
         .Observacion = String.Empty
         .Usuario = actual.Nombre

         Dim paraConsumir = Function(p As Entidades.CRMNovedadProducto) Not p.StockConsumidoProducto
         Dim paraRevertir = Function(p As Entidades.CRMNovedadProducto) p.StockConsumidoProducto

         novedad.ProductosNovedad.Where(If(novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR, paraConsumir, paraRevertir)).ToList().
         ForEach(
            Sub(en)
               Dim eProdSuc = New ProductosSucursales(da)._GetUno(eMovStock.Sucursal.IdSucursal, en.IdProducto)
               Dim eLineaMov = New Entidades.MovimientoStockProducto()
               Dim LoteProducto As Entidades.MovimientoStockProductoLotes
               Dim NroSerieProducto As Entidades.MovimientoStockProductoNrosSerie
               With eLineaMov
                  '-- Define Valores.- --
                  .CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE
                  .NombreProducto = en.NombreProducto
                  .Cantidad = en.CantidadProducto
                  .IdProducto = en.IdProducto
                  .IdDeposito = eProdSuc.IdDepositoDefecto
                  .IdUbicacion = eProdSuc.IdUbicacionDefecto
                  '-- Inicializa Valores.- --
                  .DescuentoRecargo = 0
                  .PorcentajeIVA = 0
                  .TotalProducto = 0
                  .ImporteTotal = 0
                  .Precio = 0
                  .IVA = 0
                  .Stock = eProdSuc.Stock
                  .Usuario = actual.Nombre
                  .IdLote = String.Empty
                  .VtoLote = Nothing
                  .Orden = eMovStock.Productos.Count + 1
                  .IdSucursal = actual.Sucursal.Id

                  For Each lot As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote

                     LoteProducto = New Entidades.MovimientoStockProductoLotes
                     LoteProducto.IdSucursal = lot.IdSucursal
                     LoteProducto.IdProducto = lot.IdProducto
                     LoteProducto.IdLote = lot.IdLote
                     LoteProducto.Cantidad = lot.CantidadActual
                     LoteProducto.Orden = lot.OrdenProducto
                     LoteProducto.IdDeposito = eProdSuc.IdDepositoDefecto
                     LoteProducto.IdUbicacion = eProdSuc.IdUbicacionDefecto
                     LoteProducto.FechaVencimiento = lot.FechaVencimiento

                     .ProductosNrosLotes.Add(LoteProducto)

                  Next

                  For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie

                     NroSerieProducto = New Entidades.MovimientoStockProductoNrosSerie
                     NroSerieProducto.IdSucursal = ns.IdSucursal
                     NroSerieProducto.IdProducto = ns.IdProducto
                     NroSerieProducto.NroSerie = ns.NroSerie
                     NroSerieProducto.Cantidad = .Cantidad
                     NroSerieProducto.Orden = ns.OrdenProducto
                     NroSerieProducto.IdDeposito = eProdSuc.IdDepositoDefecto
                     NroSerieProducto.IdUbicacion = eProdSuc.IdUbicacionDefecto


                     .ProductosNrosSerie.Add(NroSerieProducto)

                  Next
               End With
               eMovStock.Productos.Add(eLineaMov)



            End Sub)
      End With
      If eMovStock.Productos.Count > 0 Then
         Dim rMovimientos = New MovimientosStock(da)
         rMovimientos._Insertar(eMovStock, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, String.Empty)
      End If
   End Sub

#End Region


#Region "Métodos Privados"
   Private Sub EjecutaSP(en As Entidades.CRMNovedadProducto, tipo As TipoSP)
      Dim sCRMNovedadesProductos = New SqlServer.CRMNovedadesProductos(da)
      Dim sCRMNovedadesProductosLotes = New SqlServer.CRMNovedadesProductosLotes(da)
      Dim sCRMNovedadesProductosNrosSerie = New SqlServer.CRMNovedadesProductosNrosSerie(da)

      '-- Verifica Tipo de Operacion.- --
      Select Case tipo
         Case TipoSP._I
            sCRMNovedadesProductos.CRMNovedadesProductos_I(en.IdTipoNovedad,
                                                           en.LetraNovedad,
                                                           en.CentroEmisor,
                                                           en.IdNovedad,
                                                           en.IdProducto,
                                                           en.OrdenProducto,
                                                           en.NombreProducto,
                                                           en.CantidadProducto,
                                                           en.PrecioProducto,
                                                           en.IdListaPrecios,
                                                           en.StockConsumidoProducto, en.IdUbicacionActual, en.IdDepositoActual, en.IdUbicacionActual,
                                                           en.IdsucursalAnterior, en.IdDepositoAnterior, en.IdUbicacionAnterior,
                                                           en.StockReservadoProducto)

            If en.ProductosNovedadLote.Count > 0 Then
               For Each pl As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote
                  sCRMNovedadesProductosLotes.CRMNovedadesProductosLotes_I(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad, en.IdProducto,
                                                                           en.OrdenProducto, pl.IdLote, pl.FechaIngreso, pl.FechaVencimiento, pl.CantidadActual,
                                                                           pl.IdSucursal, pl.IdDeposito, pl.IdUbicacion)
               Next
            End If

            If en.ProductosNovedadNrosSerie.Count > 0 Then
               For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie
                  sCRMNovedadesProductosNrosSerie.CRMNovedadesProductosNrosSerie_I(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad, en.IdProducto,
                                                                           en.OrdenProducto, ns.NroSerie, ns.IdSucursal, ns.IdDeposito, ns.IdUbicacion)
               Next
            End If

         Case TipoSP._U
            sCRMNovedadesProductos.CRMNovedadesProductos_U(en.IdTipoNovedad,
                                                           en.LetraNovedad,
                                                           en.CentroEmisor,
                                                           en.IdNovedad,
                                                           en.IdProducto,
                                                           en.OrdenProducto,
                                                           en.CantidadProducto,
                                                           en.PrecioProducto,
                                                           en.StockConsumidoProducto, en.IdUbicacionActual, en.IdDepositoActual, en.IdUbicacionActual,
                                                           en.IdsucursalAnterior, en.IdDepositoAnterior, en.IdUbicacionAnterior,
                                                           en.StockReservadoProducto)

            'If en.ProductosNovedadLote.Count > 0 Then
            '   For Each pl As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote
            '      sCRMNovedadesProductosLotes.CRMNovedadesProductosLotes_U(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad, en.IdProducto,
            '                                                               en.OrdenProducto, pl.IdLote, pl.FechaIngreso, pl.FechaVencimiento, pl.CantidadActual,
            '                                                               pl.IdSucursal, en.IdDepositoActual, en.IdUbicacionActual)
            '   Next
            'End If

         Case TipoSP._D

            If en.ProductosNovedadLote.Count > 0 Then
               For Each pl As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote
                  sCRMNovedadesProductosLotes.CRMNovedadesProductosLotes_D(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad, en.IdProducto,
                                                                           en.OrdenProducto, pl.IdLote)
               Next
            End If

            If en.ProductosNovedadNrosSerie.Count > 0 Then
               For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie
                  sCRMNovedadesProductosNrosSerie.CRMNovedadesProductosNrosSerie_D(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad, en.IdProducto,
                                                                           en.OrdenProducto, ns.NroSerie)
               Next
            End If

            sCRMNovedadesProductos.CRMNovedadesProductos_D(en.IdTipoNovedad,
                                                           en.LetraNovedad,
                                                           en.CentroEmisor,
                                                           en.IdNovedad,
                                                           en.IdProducto,
                                                           en.OrdenProducto)

      End Select
   End Sub

   Private Sub ActualizaStockConsumidoProducto(en As Entidades.CRMNovedadProducto, stockConsumidoProducto As Boolean)
      Dim sql = New SqlServer.CRMNovedadesProductos(da)
      sql.CRMNovedadesProductos_U_StockConsumido(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad,
                                                 en.IdProducto, en.OrdenProducto,
                                                 stockConsumidoProducto)
   End Sub

   Private Sub ActualizaStockReservadoProducto(en As Entidades.CRMNovedadProducto, stockReservadoProducto As Boolean)
      Dim sql = New SqlServer.CRMNovedadesProductos(da)
      sql.CRMNovedadesProductos_U_StockReservado(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad,
                                                 en.IdProducto, en.OrdenProducto,
                                                 stockReservadoProducto)
   End Sub

   Private Sub ActualizaDepositos(en As Entidades.CRMNovedadProducto)
      Dim sql = New SqlServer.CRMNovedadesProductos(da)
      Dim sql2 = New SqlServer.CRMNovedadesProductosLotes(da)
      Dim sql3 = New SqlServer.CRMNovedadesProductosNrosSerie(da)

      If en.ProductosNovedadNrosSerie.Count > 0 Then
         For Each ns As Entidades.CRMNovedadProductoNrosSerie In en.ProductosNovedadNrosSerie
            sql3.CRMNovedadesProductosNrosSerie_U(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad, en.IdProducto,
                                                                     en.OrdenProducto, ns.NroSerie, en.IdsucursalAnterior, en.IdDepositoAnterior,
                                                                     en.IdUbicacionAnterior)
         Next
      End If

      If en.ProductosNovedadLote.Count > 0 Then
         For Each pl As Entidades.CRMNovedadProductoLote In en.ProductosNovedadLote
            sql2.CRMNovedadesProductosLotes_U(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad, en.IdProducto,
                                                                     en.OrdenProducto, pl.IdLote, pl.FechaIngreso, pl.FechaVencimiento, pl.CantidadActual,
                                                                     en.IdsucursalAnterior, en.IdDepositoAnterior, en.IdUbicacionAnterior)
         Next
      End If

      sql.CRMNovedadesProductos_U_Depositos(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad,
                                                 en.IdProducto, en.OrdenProducto, en.IdsucursalAnterior, en.IdDepositoAnterior,
                                                 en.IdUbicacionAnterior, en.IdSucursalActual, en.IdDepositoActual,
                                                 en.IdUbicacionActual)


   End Sub
#End Region

End Class
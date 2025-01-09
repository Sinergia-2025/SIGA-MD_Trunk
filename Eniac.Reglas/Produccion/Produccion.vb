Public Class Produccion
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Produccion", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Sub Insertar2(entidad As Entidades.Entidad, fecha As Date)
      EjecutaConTransaccion(Sub() GrabarProduccion(DirectCast(entidad, Entidades.Produccion), fecha, estadoOrigen:=Nothing))
   End Sub

   Public Sub AnularProduccion(tablaAnular As DataTable, responsable As Entidades.Empleado)
      EjecutaConTransaccion(Sub() _AnularProduccion(tablaAnular, responsable))
   End Sub

   Public Sub _AnularProduccion(tablaAnular As DataTable, responsable As Entidades.Empleado)
      For Each filaAnula As DataRow In tablaAnular.Rows
         Dim rProLote = New ProductosLotes(da)
         Dim rProdProd = New ProduccionProductos(da)
         Dim produccion = New Produccion(da).GetUna(filaAnula.Field(Of Integer)("IdSucursal"), filaAnula.Field(Of Integer)("IdProduccion"))
         produccion.IdEstado = "ANULADA"
         produccion.Responsable = responsable
         produccion.Usuario = actual.Nombre

         Dim sql = New SqlServer.Produccion(da)
         sql.Produccion_U(produccion.IdSucursal, produccion.IdProduccion,
                          produccion.IdEstado, produccion.Responsable.IdEmpleado,
                          produccion.Usuario)


         'Limpiar los lotes
         'Dim prolot = New Entidades.ProductoLote()
         'For Each pp In produccion.Productos
         '   If Not String.IsNullOrWhiteSpace(pp.IdLote) Then
         '      prolot = rProLote._GetUno(pp.IdProducto, pp.IdLote, pp.IdSucursal, pp.IdDeposito, pp.IdUbicacion)
         '      If prolot.CantidadActual = prolot.CantidadInicial Then
         '         rProLote.LimpiarLote(prolot)
         '      Else
         '         Throw New Exception("El Lote ha sido utilizado, no se puede realizar la anulación")
         '      End If
         '   End If
         'Next

         Dim rMovimientos = New MovimientosStock(da)
         'Dim oMov = New Entidades.MovimientoStock()
         Dim rMCP = New MovimientosStockProductos(da)
         Dim rMSPL = New MovimientosStockProductosLotes(da)
         Dim rPro = New ProductosSucursales(da)

         'Eliminar movimientosComprasproductos y Componentes
         Dim MovimientosProduccion As DataTable
         MovimientosProduccion = rMovimientos.GetMovimientosProduccion(produccion.IdSucursal, produccion.IdProduccion)
         If MovimientosProduccion.Rows.Count <> 0 Then
            For Each dr In MovimientosProduccion.AsEnumerable()

               Dim oMov = rMovimientos.GetUnoPorProduccion(dr.Field(Of Integer)("IdSucursal"),
                                                           0,
                                                           0,
                                                           dr.Field(Of String)("IdTipoMovimiento"),
                                                           dr.Field(Of Long)("NumeroMovimiento"))
               For Each mcp In oMov.Productos
                  '-- Produccion Lote de Existir.-
                  rMSPL.EliminarPorProduccionLote(mcp)
                  '-- Produccion.- 
                  rMCP.EliminarPorProduccion(mcp)
                  'actualizar el stock
                  rPro.ActualizarStock(mcp.IdSucursal, mcp.IdDeposito, mcp.IdUbicacion, mcp.ProductoSucursal.Producto.IdProducto, -mcp.Cantidad,
                                       0, 0, 0, 0, 0, 0, 0, 0)

                  Dim rProdLote = New ProductosLotes(da)
                  Dim eProdLote = New ProductosLotes(da)._GetUno(mcp.IdProducto, mcp.IdLote, mcp.IdSucursal, mcp.IdDeposito, mcp.IdUbicacion, AccionesSiNoExisteRegistro.Vacio)

                  eProdLote.CantidadActual += -mcp.Cantidad
                  If eProdLote Is Nothing Then
                     'VER SI VA
                     rProdLote.EjecutaSP(eProdLote, TipoSP._I)
                  Else
                     'Actualizo el Lote del Producto
                     rProdLote.EjecutaSP(eProdLote, TipoSP._U)
                  End If


               Next
               rMovimientos.EliminarMovimientosStock(oMov)
            Next
         End If

      Next
   End Sub

   Friend Sub GrabarProduccion(oProd As Entidades.Produccion, fecha As Date, estadoOrigen As Entidades.EstadoOrdenProduccion)

      Dim _cache = New BusquedasCacheadas()

      'Busco el último número de Producción
      oProd.IdProduccion = GetUltimoNro() + 1

      Dim suc = New Sucursales(da).GetUna(oProd.IdSucursal, False)
      Dim tpMovimientoProduccion = New TiposMovimientos(da).GetUno("PRODUCCION")
      Dim tpMovimientoComponente = New TiposMovimientos(da).GetUno("COMPROD")

      'actualizo los Lotes ------------------------------------------
      Dim rProLot = New ProductosLotes(da)
      'modifico las cantidades de los lotes según el tipo de movimiento que se ingreso
      For Each pl In oProd.ProductosLotes
         pl.CantidadActualOriginal = pl.CantidadActual
         pl.ProductoSucursal.Sucursal = suc
         pl.CantidadActual = pl.CantidadActual * tpMovimientoProduccion.CoeficienteStock
      Next
      rProLot.ActualizoLotes(oProd.ProductosLotes)
      For Each pl In oProd.ProductosLotes
         pl.CantidadActual = pl.CantidadActualOriginal
      Next


      Dim rProdProd = New ProduccionProductos(da)
      Dim rProdSuc = New ProductosSucursales(da)

      Dim lstMovProd = New List(Of Entidades.MovimientoStockProducto)

      Dim rMovComp = New MovimientosStock(da)
      'Dim lstMovStockComProd = New List(Of Entidades.MovimientoStockProducto)
      Dim rComponentes = New ProductosComponentes(da)

      Dim rProdProdComp = New ProduccionProductosComp(da)

      'Grabo la cabecera de Produccion
      oProd.IdEstado = "NORMAL"
      EjecutaSP(oProd, TipoSP._I)

      'Grabo los Productos de Produccion
      For Each pro In oProd.Productos
         pro.Produccion = oProd

         'Inserto el detalle de produccion
         rProdProd.EjecutaSP(pro, TipoSP._I)

         'Cargo los Movimientos de compra para cada producto
         Dim precioCosto = rProdSuc.GetUno(oProd.IdSucursal, pro.IdProducto, 0).PrecioCosto
         Dim movStockProd = New Entidades.MovimientoStockProducto With {
                .IdSucursal = pro.IdSucursal,
                .IdDeposito = pro.IdDeposito,
                .IdUbicacion = pro.IdUbicacion,
                .Cantidad = pro.Cantidad,
                .DescRecGeneral = 0,
                .DescuentoRecargo = 0,
                .IdLote = If(String.IsNullOrEmpty(pro.IdLote), "", pro.IdLote),
                .IdProducto = pro.IdProducto,
                .NombreProducto = pro.NombreProducto,
                .Precio = precioCosto,
                .ImporteTotal = Decimal.Round(pro.Cantidad * precioCosto, 2),
                .IVA = 0
            }

         lstMovProd.Add(movStockProd)

         'Busco los componentes del producto si los tiene y genero el movimiento de descuento de stock

         Dim prodProdComp = New Entidades.ProduccionProductoComp()

         Dim idListaDePrecios = Publicos.ListaPreciosPredeterminada  'Lista Base

         Dim componentes = pro.Componentes
         If Not componentes.AnySecure() Then
            Dim rEstructura = New EstructuraProductos(da)
            'Dim forma = New ProduccionModelosFormas(da).GetUno(pro.IdProduccionForma)
            Dim variables = ProduccionFormas.GetValoresForma(pro.Espmm, pro.LargoExtAlto, pro.AnchoIntBase, architrave:=0, forma:=Nothing)
            Dim estructura = rEstructura.CreaEstructura(pro.IdProducto, pro.IdFormula, idListaDePrecios, pro.Cantidad, muestraPrecio:=True,
                                                        variables, moneda:=Entidades.Moneda.Peso, 1)
            If estructura.AnySecure() Then
               componentes = estructura.First().ConvertToProduccionProductosFormula()
            End If
         End If

         If componentes.Any() Then
            For Each dr In componentes

               Dim cantidadComponente = dr.CantidadEnFormula * pro.Cantidad
               Dim movStockComp = New Entidades.MovimientoStock()
               Dim movStockComProd = New Entidades.MovimientoStockProducto With {
                        .IdSucursal = oProd.IdSucursal,
                        .Cantidad = cantidadComponente,
                        .DescRecGeneral = 0,
                        .DescuentoRecargo = 0,
                        .IdLote = dr.IdLote,
                        .IdProducto = dr.IdProductoComponente,
                        .NombreProducto = dr.NombreProducto,
                        .Precio = dr.PrecioCosto,
                        .ImporteTotal = dr.ImporteCosto,
                        .IVA = 0
                    }
               If estadoOrigen IsNot Nothing AndAlso estadoOrigen.ReservaMateriaPrima Then
                  movStockComProd.IdDeposito = estadoOrigen.IdDeposito
                  movStockComProd.IdUbicacion = estadoOrigen.IdUbicacion
               Else
                  Dim eProd = New Reglas.ProductosSucursales().GetUno(oProd.IdSucursal, dr.IdProductoComponente)
                  movStockComProd.IdDeposito = If(dr.IdDepositoDefecto = 0, eProd.IdDepositoDefecto, dr.IdDepositoDefecto)
                  movStockComProd.IdUbicacion = If(dr.IdUbicacionDefecto = 0, eProd.IdUbicacionDefecto, dr.IdUbicacionDefecto)
               End If

               If dr.SeleccionMultiple IsNot Nothing AndAlso dr.SeleccionMultiple.Ubicaciones.AnySecure() Then
                  Dim ubic = dr.SeleccionMultiple.Ubicaciones.FirstOrDefault()
                  dr.Lotes = ubic.Lotes.ConvertAll(Function(l) New Entidades.ProduccionProductoCompLote() With {.IdLote = l.IdLote, .Cantidad = l.Cantidad})
                  movStockComProd.ProductosNrosLotes = dr.Lotes.ConvertAll(Function(lt) New Entidades.MovimientoStockProductoLotes() With {
                                                                                    .IdSucursal = lt.IdSucursal,
                                                                                    .Cantidad = lt.Cantidad,
                                                                                    .IdLote = lt.IdLote,
                                                                                    .IdProducto = movStockComProd.IdProducto,
                                                                                    .Orden = movStockComProd.Orden
                                                                                 })
                  movStockComProd.IdLote = dr.Lotes(0).IdLote
                  dr.NrosSerie = ubic.NrosSerie.ConvertAll(Function(ns) New Entidades.ProduccionProductoCompNroSerie() With {.NroSerie = ns.NroSerie})
                  movStockComProd.ProductosNrosSerie = dr.NrosSerie.ConvertAll(Function(ns) New Entidades.MovimientoStockProductoNrosSerie() With {
                                                                                    .NroSerie = ns.NroSerie,
                                                                                    .IdProducto = movStockComProd.IdProducto,
                                                                                    .Orden = movStockComProd.Orden
                                                                                 })
                  movStockComProd.ProductoSucursal.Producto.NrosSeries = dr.NrosSerie.ConvertAll(
                                             Function(ns)
                                                Return New Entidades.ProductoNroSerie With {
                                                               .Producto = New Entidades.Producto() With {.IdProducto = movStockComProd.IdProducto},
                                                               .IdSucursal = movStockComProd.IdSucursal,
                                                               .Sucursal = New Entidades.Sucursal() With {.IdSucursal = movStockComProd.IdSucursal},
                                                               .IdDeposito = ubic.IdDeposito,
                                                               .IdUbicacion = ubic.IdUbicacion,
                                                               .NroSerie = ns.NroSerie,
                                                               .Vendido = True
                                                            }
                                             End Function)
               End If


               With dr
                  .IdSucursal = pro.Produccion.IdSucursal
                  .IdProduccion = pro.Produccion.IdProduccion
                  .Orden = pro.Orden
                  .IdProducto = pro.IdProducto
                  .Cantidad = cantidadComponente
               End With

               rProdProdComp._Insertar(dr)

               'Movimientos de Compras
               With movStockComp
                  .Sucursal = suc

                  .TipoMovimiento = tpMovimientoComponente

                  .FechaMovimiento = fecha

                  .DescuentoRecargo = 0
                  .PercepcionIVA = 0
                  .PercepcionIB = 0
                  .PercepcionGanancias = 0
                  .PercepcionVarias = 0

                  .Productos = New List(Of Entidades.MovimientoStockProducto)({movStockComProd}) ' lstMovStockComProd

                  .Usuario = oProd.Usuario
                  .IdProduccion = oProd.IdProduccion

                  .ProductosLotes = dr.Lotes.ConvertAll(Function(l) New Entidades.ProductoLote() With {.IdLote = l.IdLote})
                  .ProductosNrosSerie = dr.NrosSerie.ConvertAll(Function(ns) New Entidades.ProductoNroSerie() With {.NroSerie = ns.NroSerie, .Vendido = True})
               End With

               rMovComp.GrabarMovimientoProduccion(movStockComp)
            Next

         End If

         Dim rNrosSerie = New ProductosNrosSerie(da)
         For Each compo In componentes ' vp.VentasProductosFormulas
            If compo.SeleccionMultiple IsNot Nothing AndAlso compo.SeleccionMultiple.Ubicaciones.AnySecure Then
               For Each ubic In compo.SeleccionMultiple.Ubicaciones
                  For Each ns In ubic.NrosSerie

                     If tpMovimientoProduccion.CoeficienteStock = -1 Then
                        rNrosSerie.ProductosNrosSerie_UDevolucion(ns.IdProducto, ns.NroSerie)
                     Else
                        Dim nsActualizar = New Entidades.ProductoNroSerie With {
                                          .Producto = _cache.BuscaProductoEntidadPorId(ns.IdProducto, da),
                                          .NroSerie = ns.NroSerie,
                                          .Sucursal = _cache.BuscaSucursal(ubic.IdSucursal),
                                          .Vendido = True
                                       }
                        rNrosSerie._Actualiza(nsActualizar)
                     End If
                  Next
               Next
            End If
         Next
      Next

      'Inserto el movimiento de Producción

      Dim movStock = New Entidades.MovimientoStock()
      With movStock
         .Sucursal = suc

         .TipoMovimiento = tpMovimientoProduccion

         .FechaMovimiento = fecha

         .DescuentoRecargo = 0

         .PercepcionIVA = 0
         .PercepcionIB = 0
         .PercepcionGanancias = 0
         .PercepcionVarias = 0

         '.Comentarios = Me.txtObservacion.Text.Trim()
         '.Observacion = Me.txtObservacion.Text

         .Productos = lstMovProd

         '.ProductosLotes = Me._loductosLotes

         .Usuario = oProd.Usuario

         .IdProduccion = oProd.IdProduccion

      End With

      Dim rMovimientos = New MovimientosStock(da)
      rMovimientos.GrabarMovimientoProduccion(movStock)

   End Sub

   Public Sub _Insertar(produccion As Entidades.Produccion)
      EjecutaSP(produccion, TipoSP._I)
   End Sub

   Public Sub GrabarProduccion(produccion As Entidades.Produccion, fecha As Date, _cache As BusquedasCacheadas) ', estadoOrigen As Entidades.EstadoOrdenProduccion, _cache As BusquedasCacheadas)

      If _cache Is Nothing Then _cache = New BusquedasCacheadas()

      'Busco el último número de Producción
      produccion.IdProduccion = GetUltimoNro() + 1

      Dim suc = New Sucursales(da).GetUna(produccion.IdSucursal, False)
      Dim tpMovimientoProduccion = New TiposMovimientos(da).GetUno("PRODUCCION")
      Dim tpMovimientoComponente = New TiposMovimientos(da).GetUno("COMPROD")

      'Inserto el movimiento de Producción
      Dim movEntradaPT = New Entidades.MovimientoStock() With {
            .Sucursal = suc,
            .TipoMovimiento = tpMovimientoProduccion,
            .FechaMovimiento = fecha,
            .DescuentoRecargo = 0,
            .PercepcionIVA = 0,
            .PercepcionIB = 0,
            .PercepcionGanancias = 0,
            .PercepcionVarias = 0,
            .Usuario = produccion.Usuario,
            .IdProduccion = produccion.IdProduccion
         }
      'Genero el movimiento de stock para descontar todos los componentes en el mismo movimiento
      Dim movSalidaMP = New Entidades.MovimientoStock() With {
            .Sucursal = suc,
            .TipoMovimiento = tpMovimientoComponente,
            .FechaMovimiento = fecha,
            .DescuentoRecargo = 0,
            .PercepcionIVA = 0,
            .PercepcionIB = 0,
            .PercepcionGanancias = 0,
            .PercepcionVarias = 0,
            .Usuario = produccion.Usuario,
            .IdProduccion = produccion.IdProduccion
         }


      'actualizo los Lotes ------------------------------------------
      Dim rProLot = New ProductosLotes(da)
      'modifico las cantidades de los lotes según el tipo de movimiento que se ingreso
      For Each pl In produccion.ProductosLotes
         pl.CantidadActualOriginal = pl.CantidadActual
         pl.ProductoSucursal.Sucursal = suc
         pl.CantidadActual = pl.CantidadActual * tpMovimientoProduccion.CoeficienteStock
      Next
      rProLot.ActualizoLotes(produccion.ProductosLotes)
      For Each pl In produccion.ProductosLotes
         pl.CantidadActual = pl.CantidadActualOriginal
      Next


      Dim rProdProd = New ProduccionProductos(da)
      Dim rProdSuc = New ProductosSucursales(da)

      'Dim lstMovProd = New List(Of Entidades.MovimientoStockProducto)

      'Dim lstMovStockComProd = New List(Of Entidades.MovimientoStockProducto)
      'Dim rComponentes = New ProductosComponentes(da)

      Dim rProdProdComp = New ProduccionProductosComp(da)

      'Grabo la cabecera de Produccion
      produccion.IdEstado = "NORMAL"
      _Insertar(produccion)

      'Grabo los Productos de Produccion
      For Each proProducto In produccion.Productos
         proProducto.Produccion = produccion

         'Inserto el detalle de produccion
         rProdProd._Insertar(proProducto)

         Dim idListaDePrecios = Publicos.ListaPreciosPredeterminada  'Lista Base

         'Busco los componentes del producto si los tiene y genero el movimiento de descuento de stock
         Dim componentes = proProducto.Componentes
         If Not componentes.Any() Then
            Throw New Exception(String.Format("El producto '{0}' no tiene cargados componentes. No es posible continuar", proProducto.IdProducto))
         End If

         For Each comp In componentes
            Dim cantidadComponente = comp.Cantidad '* proProducto.Cantidad

            'Primero completo los datos del detalle de producción con los datos de cabecera
            With comp
               .IdSucursal = proProducto.Produccion.IdSucursal
               .IdProduccion = proProducto.Produccion.IdProduccion
               .Orden = proProducto.Orden
               .IdProducto = proProducto.IdProducto
               .Cantidad = cantidadComponente
            End With

            'Inserto el componente en la tabla
            rProdProdComp._Insertar(comp)

            If Not comp.Lotes.AnySecure() Then
               comp.Lotes.Add(New Entidades.ProduccionProductoCompLote() With {.IdLote = String.Empty, .Cantidad = cantidadComponente})
            End If
            For Each compLote In comp.Lotes
               'Una vez guardado, creo el detalle para el Movimiento de Stock y lo agrego en la respectiva colección de Productos
               Dim movCompSalidaMP = New Entidades.MovimientoStockProducto With {
                     .IdSucursal = produccion.IdSucursal,
                     .IdDeposito = comp.IdDeposito,
                     .IdUbicacion = comp.IdUbicacion,
                     .Cantidad = compLote.Cantidad, ' cantidadComponente,
                     .DescRecGeneral = 0,
                     .DescuentoRecargo = 0,
                     .IdLote = compLote.IdLote,
                     .IdProducto = comp.IdProductoComponente,
                     .NombreProducto = comp.NombreProducto,
                     .Precio = comp.PrecioCosto,
                     .ImporteTotal = comp.ImporteCosto,
                     .IVA = 0,
                     .ProductosNrosSerie = comp.NrosSerie.ConvertAll(Function(ns) New Entidades.MovimientoStockProductoNrosSerie() With {
                                                                                    .IdProducto = comp.IdProductoComponente,
                                                                                    .NroSerie = ns.NroSerie,
                                                                                    .Cantidad = movSalidaMP.TipoMovimiento.CoeficienteStock
                                                                              })
               }
               'movCompSalidaMP.ProductoSucursal.Producto = _cache.BuscaProductoEntidadPorId(movCompSalidaMP.IdProducto)
               movSalidaMP.Productos.Add(movCompSalidaMP) ' lstMovStockComProd

               If Not String.IsNullOrWhiteSpace(movCompSalidaMP.IdLote) Then
                  Dim prodLote = New Entidades.ProductoLote() With {
                                             .IdSucursal = comp.IdSucursal,
                                             .IdDeposito = comp.IdDeposito,
                                             .IdUbicacion = comp.IdUbicacion,
                                             .IdLote = compLote.IdLote,
                                             .CantidadActual = compLote.Cantidad,
                                             .CantidadInicial = compLote.Cantidad,
                                             .Habilitado = True,
                                             .FechaIngreso = Date.Now
                                          }
                  '.FechaVencimiento = compLote.FechaVencimiento
                  prodLote.ProductoSucursal.Producto.IdProducto = comp.IdProductoComponente
                  prodLote.ProductoSucursal.IdSucursal = movCompSalidaMP.IdSucursal
                  prodLote.ProductoSucursal.Sucursal.IdSucursal = movCompSalidaMP.IdSucursal
                  movSalidaMP.ProductosLotes.Add(prodLote)
               End If
            Next

         Next

         'Cargo los Movimientos de compra para cada producto
         Dim precioCosto = rProdSuc.GetUno(produccion.IdSucursal, proProducto.IdProducto, 0).PrecioCosto
         Dim movCompEntradaPT = New Entidades.MovimientoStockProducto With {
            .IdSucursal = proProducto.IdSucursal,
            .IdDeposito = proProducto.IdDeposito,
            .IdUbicacion = proProducto.IdUbicacion,
            .Cantidad = proProducto.Cantidad,
            .DescRecGeneral = 0,
            .DescuentoRecargo = 0,
            .IdLote = proProducto.IdLote,
            .IdProducto = proProducto.IdProducto,
            .NombreProducto = proProducto.NombreProducto,
            .Precio = precioCosto,
            .ImporteTotal = Decimal.Round(proProducto.Cantidad * precioCosto, 2),
            .IVA = 0,
            .ProductosNrosSerie = proProducto.NrosSerie.ConvertAll(Function(ns) New Entidades.MovimientoStockProductoNrosSerie() With {
                                                                                    .IdProducto = proProducto.IdProducto,
                                                                                    .NroSerie = ns.NroSerie,
                                                                                    .Cantidad = movEntradaPT.TipoMovimiento.CoeficienteStock
                                                                              })
         }

         movEntradaPT.Productos.Add(movCompEntradaPT)
      Next

      Dim rMovStock = New MovimientosStock(da)
      'Movimientos de Stock Salida de MP
      rMovStock.GrabarMovimientoProduccion(movSalidaMP)

      'El movimiento de stock de salida de MP no marca como Vendido el Nro de Serie.
      'Esto lo hacemos por fuera porque si lo agregamos a la lógica de grabación podemos afectar todas las otras formas de grabar.
      'De hecho:
      '   - Facturación lo hace de esta manera (actualizando luego de generar el Movimiento de Stock)
      '   - Movimiento de Stock borra el Nro de Serie cuando se hace un Ajuste negativo
      Dim rNS = New ProductosNrosSerie(da)
      For Each msp In movSalidaMP.Productos
         For Each ns In msp.ProductosNrosSerie
            rNS.ActualizaVendidoMPPorGeneraPT(ns.IdProducto, ns.NroSerie)
         Next
      Next

      'El movimiento de stock de salida de MP no descuenta el stock del Lote.
      'Esto lo hacemos por fuera porque si lo agregamos a la lógica de grabación podemos afectar todas las otras formas de grabar.
      'De hecho:
      '   - Movimiento de Stock lo actualiza antes de ejecutar la grabación
      Dim proLot = New ProductosLotes(da)
      For Each pl In movSalidaMP.ProductosLotes
         pl.CantidadActualOriginal = pl.CantidadActual
         pl.ProductoSucursal.Sucursal = movSalidaMP.Sucursal
         pl.CantidadInicial = 0
         pl.CantidadActual = pl.CantidadActual * -1    ' Fijo porque es la salida de la MP  movSalidaMP.TipoMovimiento.CoeficienteStock
      Next
      proLot.ActualizoLotes(movSalidaMP.ProductosLotes)

      'Movimientos de Stock Entrada de PT
      rMovStock.GrabarMovimientoProduccion(movEntradaPT)

   End Sub


   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      ''Me.EjecutaSP(DirectCast(entidad, Entidades.MovimientoCompra), TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      ''Me.EjecutaSP(DirectCast(entidad, Entidades.MovimientoCompra), TipoSP._D)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(produccion As Entidades.Produccion, tipo As TipoSP)
      Dim sql = New SqlServer.Produccion(da)
      sql.Produccion_I(produccion.IdSucursal, produccion.IdProduccion, produccion.Fecha, produccion.Usuario,
                       produccion.Responsable.IdEmpleado, produccion.IdEstado)
   End Sub
   Private Function GetUltimoNro() As Integer
      Return New SqlServer.Produccion(da).GetNumeroMaximo()
   End Function
   Private Sub CargarUno(o As Entidades.Produccion, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .IdProduccion = dr.Field(Of Integer)("IdProduccion")
         .Fecha = dr.Field(Of Date)("Fecha")
         .Usuario = dr.Field(Of String)("Usuario")
         .Responsable = New Empleados().GetUno(dr.Field(Of Integer)("IdResponsable"))
         .IdEstado = dr.Field(Of String)("IdEstado")

         .Productos = New ProduccionProductos(da).GetTodos(.IdSucursal, .IdProduccion)
      End With
   End Sub

#End Region

#Region "Metodos Públicos"
   Public Function GetPorRangoFechas(idSucursal As Integer, desde As Date, hasta As Date) As DataTable
      Return New SqlServer.Produccion(da).GetPorRangoFechas(idSucursal, desde, hasta)
   End Function

   Public Function Get1(idSucursal As Integer, idProduccion As Integer) As DataTable
      Return New SqlServer.Produccion(da).Produccion_G1(idSucursal, idProduccion)
   End Function
   Public Function GetUna(idSucursal As Integer, idProduccion As Integer) As Entidades.Produccion
      Return GetUna(idSucursal, idProduccion, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUna(idSucursal As Integer, idProduccion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Produccion
      Return CargaEntidad(Get1(idSucursal, idProduccion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Produccion(),
                          accion, Function() String.Format("No existe la Producción con Sucursal {0} y Id de Producción {1}", idSucursal, idProduccion))
   End Function
#End Region

End Class
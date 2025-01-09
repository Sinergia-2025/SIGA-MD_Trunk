Public Class MovimientosStockProductos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.MovimientoStockProducto.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Metodos Privados"
   Friend Sub EjecutaSP(movStockP As Entidades.MovimientoStockProducto, tipo As TipoSP)
      Dim sqlMSP = New SqlServer.MovimientosStockProductos(da)
      Select Case tipo
         Case TipoSP._I
            Dim valorADescontar As Decimal
            Dim valorADescontar2 As Decimal


            Dim rProdLote = New ProductosLotes(da)
            Dim eProdLote As Entidades.ProductoLote = Nothing
            Dim eProd = New Reglas.Productos(da).GetUno(movStockP.IdProducto)
            Dim linea As Integer = 0
            Dim rMovStockProdLotes = New MovimientosStockProductosLotes(da)

            If Not eProd.Lote Then
               sqlMSP.MovimientosStockProductos_I(movStockP.IdSucursal, movStockP.IdDeposito, movStockP.IdUbicacion,
                                                  movStockP.TipoMovimiento.IdTipoMovimiento, movStockP.NumeroMovimiento,
                                                  movStockP.IdProducto,
                                                  movStockP.Cantidad, movStockP.Cantidad2,
                                                  movStockP.Precio,
                                                  movStockP.IdLote,
                                                  movStockP.VtoLote,
                                                  movStockP.Orden,
                                                  movStockP.IdaAtributoProducto01, movStockP.IdaAtributoProducto02,
                                                  movStockP.IdaAtributoProducto03, movStockP.IdaAtributoProducto04,
                                                  movStockP.InformeCalidadNumero, movStockP.InformeCalidadLink)

            Else
               'si es una venta
               If movStockP.Cantidad < 0 Then
                  If Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then
                     '# Inserto el producto en MovimientosStockProductos
                     sqlMSP.MovimientosStockProductos_I(movStockP.IdSucursal, movStockP.IdDeposito, movStockP.IdUbicacion,
                                                        movStockP.TipoMovimiento.IdTipoMovimiento, movStockP.NumeroMovimiento,
                                                        movStockP.IdProducto,
                                                        movStockP.Cantidad, movStockP.Cantidad2,
                                                        movStockP.Precio,
                                                        movStockP.IdLote,
                                                        movStockP.VtoLote,
                                                        movStockP.Orden,
                                                        movStockP.IdaAtributoProducto01, movStockP.IdaAtributoProducto02,
                                                        movStockP.IdaAtributoProducto03, movStockP.IdaAtributoProducto04,
                                                        movStockP.InformeCalidadNumero, movStockP.InformeCalidadLink)

                     '# Por cada lote del producto, lo guardo
                     For Each eMVPL In movStockP.ProductosNrosLotes
                        eProdLote = New ProductosLotes(da)._GetUno(eMVPL.IdProducto, eMVPL.IdLote, movStockP.IdSucursal, movStockP.IdDeposito, movStockP.IdUbicacion, AccionesSiNoExisteRegistro.Vacio)
                        valorADescontar = eMVPL.Cantidad * If(movStockP.MovimientoStock.Venta.IdEstadoComprobante <> "ANULADO",
                                                              movStockP.MovimientoStock.TipoMovimiento.CoeficienteStock,
                                                              movStockP.MovimientoStock.Venta.TipoComprobante.CoeficienteValores)
                        '# Aplico el signo correspondiente al valor a descontar
                        eMVPL.Cantidad = valorADescontar
                        eProdLote.CantidadActual += valorADescontar
                        If eProdLote Is Nothing Then
                           'VER SI VA
                           rProdLote.EjecutaSP(eProdLote, TipoSP._I)
                        Else
                           'Actualizo el Lote del Producto
                           rProdLote.EjecutaSP(eProdLote, TipoSP._U)
                        End If

                        '# Inserto los movimientos de los productos con Lote.
                        eMVPL.IdSucursal = movStockP.IdSucursal
                        eMVPL.IdDeposito = movStockP.IdDeposito
                        eMVPL.IdUbicacion = movStockP.IdUbicacion
                        eMVPL.Orden = movStockP.Orden
                        '# Le asigno el núm de movimiento.
                        eMVPL.NumeroMovimiento = movStockP.MovimientoStock.NumeroMovimiento
                        eMVPL.IdTipoMovimiento = movStockP.TipoMovimiento.IdTipoMovimiento
                        rMovStockProdLotes._Inserta(eMVPL)
                     Next
                  Else
                     'Seleccion Automatica de Lote
                     valorADescontar = movStockP.Cantidad
                     '# Inserto el producto en MovimientosStockProductos
                     sqlMSP.MovimientosStockProductos_I(movStockP.IdSucursal, movStockP.IdDeposito, movStockP.IdUbicacion,
                                                        movStockP.TipoMovimiento.IdTipoMovimiento, movStockP.NumeroMovimiento,
                                                        movStockP.IdProducto,
                                                        movStockP.Cantidad, movStockP.Cantidad2,
                                                        movStockP.Precio,
                                                        movStockP.IdLote,
                                                        movStockP.VtoLote,
                                                        If(movStockP.Orden = 0, 1, movStockP.Orden),
                                                        movStockP.IdaAtributoProducto01, movStockP.IdaAtributoProducto02,
                                                        movStockP.IdaAtributoProducto03, movStockP.IdaAtributoProducto04,
                                                        movStockP.InformeCalidadNumero, movStockP.InformeCalidadLink)
                     Dim orden = 1
                     Do While valorADescontar <> 0
                        valorADescontar2 = valorADescontar
                        eProdLote = rProdLote.GetLoteMasViejoADescontar(eProd.IdProducto, movStockP.MovimientoStock.Sucursal.Id, movStockP.IdDeposito, movStockP.IdUbicacion)
                        If eProdLote IsNot Nothing And eProdLote.CantidadActual <> 0 Then
                           If Math.Abs(valorADescontar) >= eProdLote.CantidadActual Then
                              valorADescontar += eProdLote.CantidadActual
                              valorADescontar2 = eProdLote.CantidadActual * movStockP.MovimientoStock.TipoMovimiento.CoeficienteStock
                              eProdLote.CantidadActual = 0
                           Else
                              eProdLote.CantidadActual += valorADescontar
                              valorADescontar2 = valorADescontar
                              valorADescontar = 0
                           End If
                           'Actualizo el Lote del Producto
                           rProdLote.EjecutaSP(eProdLote, TipoSP._U)
                           linea += 1
                           '# En base al lote que se seleccionó automaticamente para descontar, hago el insert en MovimientosStockProductosLotes
                           rMovStockProdLotes._Inserta(New Entidades.MovimientoStockProductoLotes With {
                                                            .IdSucursal = movStockP.IdSucursal,
                                                            .IdDeposito = movStockP.IdDeposito,
                                                            .IdUbicacion = movStockP.IdUbicacion,
                                                            .IdTipoMovimiento = movStockP.MovimientoStock.TipoMovimiento.IdTipoMovimiento,
                                                            .NumeroMovimiento = movStockP.MovimientoStock.NumeroMovimiento,
                                                            .Orden = If(movStockP.Orden = 0, 1, movStockP.Orden),
                                                            .IdProducto = movStockP.IdProducto,
                                                            .IdLote = eProdLote.IdLote,
                                                            .Cantidad = valorADescontar2,
                                                            .Cantidad2 = 0
                                                       })
                           '# Si el cliente utiliza selección de lotes automática, Y NO ES UNA NC, los lotes a descontar fueron seleccionados recientemente, por lo que se tienen que cargar en la entidad en este momento..
                           '# Obtengo los lotes seleccionados desde el movimiento
                           If Not String.IsNullOrEmpty(movStockP.MovimientoStock.Venta.IdEstadoComprobante) And movStockP.MovimientoStock.Venta.IdEstadoComprobante <> "ANULADO" Then
                              Dim rVentasProductosLotes = New VentasProductosLotes(da)
                              rVentasProductosLotes._Inserta(New Entidades.VentaProductoLote With {
                                                                  .IdSucursal = movStockP.IdSucursal,
                                                                  .IdDeposito = movStockP.IdDeposito,
                                                                  .IdUbicacion = movStockP.IdUbicacion,
                                                                  .TipoComprobante = movStockP.MovimientoStock.Venta.IdTipoComprobante,
                                                                  .Letra = movStockP.MovimientoStock.Venta.LetraComprobante,
                                                                  .CentroEmisor = movStockP.MovimientoStock.Venta.CentroEmisor,
                                                                  .NumeroComprobante = movStockP.MovimientoStock.Venta.NumeroComprobante,
                                                                  .Producto = movStockP.ProductoSucursal.Producto,
                                                                  .IdLote = eProdLote.IdLote,
                                                                  .FechaVencimiento = eProdLote.FechaVencimiento,
                                                                  .Cantidad = valorADescontar2 * movStockP.MovimientoStock.Venta.TipoComprobante.CoeficienteStock,
                                                                  .Orden = movStockP.Orden
                                                             })
                           End If
                        Else
                           Throw New Exception("El Producto '" & eProd.NombreProducto & "' ( COD: " & eProd.IdProducto & " ) No tiene Stock para descontar " & Math.Abs(valorADescontar).ToString() & ",  No es posible con Lotes.")
                        End If
                     Loop
                  End If
               Else
                  '# Inserto el producto en MovimientosStockProductos
                  sqlMSP.MovimientosStockProductos_I(movStockP.IdSucursal, movStockP.IdDeposito, movStockP.IdUbicacion,
                                                     movStockP.TipoMovimiento.IdTipoMovimiento, movStockP.NumeroMovimiento,
                                                     movStockP.IdProducto,
                                                     movStockP.Cantidad, movStockP.Cantidad2,
                                                     movStockP.Precio,
                                                     movStockP.IdLote,
                                                     movStockP.VtoLote,
                                                     movStockP.Orden,
                                                     movStockP.IdaAtributoProducto01, movStockP.IdaAtributoProducto02,
                                                     movStockP.IdaAtributoProducto03, movStockP.IdaAtributoProducto04,
                                                     movStockP.InformeCalidadNumero, movStockP.InformeCalidadLink)

                  '# Inserto los movimientos de los productos con Lote.
                  For Each eMVPL In movStockP.ProductosNrosLotes
                     eMVPL.IdDeposito = movStockP.IdDeposito
                     eMVPL.IdUbicacion = movStockP.IdUbicacion
                     '# Le asigno el núm de movimiento.
                     eMVPL.NumeroMovimiento = movStockP.MovimientoStock.NumeroMovimiento
                     eMVPL.Cantidad *= movStockP.MovimientoStock.TipoMovimiento.CoeficienteStock
                     eMVPL.IdTipoMovimiento = movStockP.TipoMovimiento.IdTipoMovimiento

                     rMovStockProdLotes._Inserta(eMVPL)

                     eProdLote = rProdLote._GetUno(eMVPL.IdProducto, eMVPL.IdLote, eMVPL.IdSucursal, eMVPL.IdDeposito, eMVPL.IdUbicacion)

                     If eProdLote IsNot Nothing Then
                        valorADescontar = eMVPL.Cantidad + eProdLote.CantidadActual
                        rProdLote.ProductosLotes_UCantidadActual(eMVPL.IdLote, eMVPL.IdProducto,
                                                                 eMVPL.IdSucursal, eMVPL.IdDeposito, eMVPL.IdUbicacion,
                                                                 valorADescontar)
                     Else
                        eProdLote = New Entidades.ProductoLote
                        With eProdLote
                           .IdLote = eMVPL.IdLote
                           .ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(movStockP.MovimientoStock.Sucursal.IdSucursal, movStockP.IdProducto)
                           .IdDeposito = movStockP.IdDeposito
                           .IdUbicacion = movStockP.IdUbicacion
                           .FechaIngreso = movStockP.MovimientoStock.FechaMovimiento
                           .FechaVencimiento = eMVPL.FechaVencimiento
                           .PrecioCosto = eMVPL.PrecioCosto
                           .CantidadInicial = eMVPL.Cantidad
                           .CantidadActual = eMVPL.Cantidad
                           .Habilitado = True
                        End With
                        'Creo el Lote del Producto
                        rProdLote.EjecutaSP(eProdLote, TipoSP._I)
                     End If
                     '# Si el cliente utiliza selección de lotes automática, los lotes a descontar fueron seleccionados recientemente, por lo que se tienen que cargar en la entidad en este momento..
                     '# Obtengo los lotes seleccionados desde el movimiento
                     '# No debe entrar cuando se está realizando una anulación
                     If Not Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto AndAlso
                        movStockP.MovimientoStock.Venta.IdEstadoComprobante <> "ANULADO" Then
                        Dim rVentasProductosLotes = New Reglas.VentasProductosLotes(da)
                        rVentasProductosLotes._Inserta(New Entidades.VentaProductoLote With {
                                                            .IdSucursal = movStockP.MovimientoStock.IdSucursal,
                                                            .IdDeposito = movStockP.IdDeposito,
                                                            .IdUbicacion = movStockP.IdUbicacion,
                                                            .TipoComprobante = movStockP.MovimientoStock.Venta.IdTipoComprobante,
                                                            .Letra = movStockP.MovimientoStock.Venta.LetraComprobante,
                                                            .CentroEmisor = movStockP.MovimientoStock.Venta.CentroEmisor,
                                                            .NumeroComprobante = movStockP.MovimientoStock.Venta.NumeroComprobante,
                                                            .Producto = movStockP.ProductoSucursal.Producto,
                                                            .IdLote = eProdLote.IdLote,
                                                            .FechaVencimiento = eProdLote.FechaVencimiento,
                                                            .Cantidad = If(movStockP.MovimientoStock.Venta.TipoComprobante.CoeficienteStock > 0, eMVPL.Cantidad, valorADescontar) * movStockP.MovimientoStock.Venta.TipoComprobante.CoeficienteValores,
                                                            .Orden = movStockP.Orden
                                                       })
                     End If
                  Next
               End If
            End If


         Case TipoSP._D
            sqlMSP.MovimientosStockProductos_D(movStockP.IdSucursal, movStockP.IdDeposito, movStockP.IdUbicacion,
                                               movStockP.TipoMovimiento.IdTipoMovimiento, movStockP.NumeroMovimiento)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MovimientoStockProducto, dr As DataRow, cargaMovimientoStock As Boolean)
      With o
         If cargaMovimientoStock Then
            .MovimientoStock = New MovimientosStock(da).GetUno(dr.Field(Of Integer)(Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString()),
                                                               dr.Field(Of String)(Entidades.MovimientoStockProducto.Columnas.IdTipoMovimiento.ToString()),
                                                               dr.Field(Of Long)(Entidades.MovimientoStockProducto.Columnas.NumeroMovimiento.ToString()))
         End If

         .ProductoSucursal = New ProductosSucursales(da)._GetUno(dr.Field(Of Integer)(Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString()),
                                                                dr.Field(Of String)(Entidades.MovimientoStockProducto.Columnas.IdProducto.ToString()))

         .IdProducto = .ProductoSucursal.Producto.IdProducto
         .NombreProducto = .ProductoSucursal.Producto.NombreProducto

         .Orden = dr.Field(Of Integer)(Entidades.MovimientoStockProducto.Columnas.Orden.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.MovimientoStockProducto.Columnas.Cantidad.ToString())
         .Cantidad2 = dr.Field(Of Decimal)(Entidades.MovimientoStockProducto.Columnas.Cantidad2.ToString())
         .Precio = dr.Field(Of Decimal)(Entidades.MovimientoStockProducto.Columnas.Precio.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub EliminarPorComprobante(mcp As Entidades.MovimientoStock)
      Dim sql = New SqlServer.MovimientosStockProductos(da)
      sql.MovimientosStockProductos_D(mcp.IdSucursal, idDeposito:=0, idUbicacion:=0,
                                      mcp.TipoMovimiento.IdTipoMovimiento, mcp.NumeroMovimiento)
   End Sub
   Public Sub EliminarPorProduccion(mcp As Entidades.MovimientoStockProducto)
      Dim sql = New SqlServer.MovimientosStockProductos(da)
      sql.MovimientosStockProductos_D(mcp.IdSucursal, mcp.IdDeposito, mcp.IdUbicacion,
                                      mcp.TipoMovimiento.IdTipoMovimiento, mcp.NumeroMovimiento)
   End Sub

   Public Function GetMovimientos(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                  idTipoMovimiento As String, numeroMovimiento As Long) As DataTable

      Return New SqlServer.MovimientosStockProductos(da).GetUnoComprobanteProductos(idSucursal, idDeposito, idUbicacion, idTipoMovimiento, numeroMovimiento)
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long, cargaMovimientoStock As Boolean) As List(Of Entidades.MovimientoStockProducto)
      Return CargaLista(GetMovimientos(idSucursal, idDeposito:=0, idUbicacion:=0, idTipoMovimiento, numeroMovimiento),
                        Sub(o, dr) CargarUno(o, dr, cargaMovimientoStock), Function() New Entidades.MovimientoStockProducto())
   End Function

   Public Function GetUno(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                          idTipoMovimiento As String, numeroMovimiento As Long,
                          orden As Integer, idProducto As String) As Entidades.MovimientoStockProducto
      Return EjecutaConConexion(Function() _GetUno(idSucursal, idDeposito, idUbicacion,
                                                   idTipoMovimiento, numeroMovimiento,
                                                   orden, idProducto))
   End Function
   Friend Function _GetUno(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                           idTipoMovimiento As String, numeroMovimiento As Long,
                           orden As Integer, idProducto As String) As Entidades.MovimientoStockProducto
      Return _GetUno(idSucursal, idDeposito, idUbicacion, idTipoMovimiento, numeroMovimiento, orden, idProducto,
                     AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Friend Function _GetUno(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                           idTipoMovimiento As String, numeroMovimiento As Long, orden As Integer, idProducto As String,
                           accion As AccionesSiNoExisteRegistro) As Entidades.MovimientoStockProducto
      Return CargaEntidad(New SqlServer.MovimientosStockProductos(da).
                              MovimientosStockProductos_G1(idSucursal, idDeposito, idUbicacion,
                                                           idTipoMovimiento, numeroMovimiento, orden, idProducto),
                          Sub(o, dr) CargarUno(o, dr, cargaMovimientoStock:=True), Function() New Entidades.MovimientoStockProducto(),
                          accion, Function() "No existe el MovimientoStockProducto.")
   End Function
#End Region

End Class
Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

<Obsolete("Se reemplaza por MovimientosStockProductos", True)>
Public Class MovimientosVentasProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "MovimientosVentasProductos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "MovimientosVentasProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Friend Sub EjecutaSP(ByVal mov As Entidades.MovimientoVentaProducto, ByVal tipo As TipoSP)

         Dim sqlMVP As SqlServer.MovimientosVentasProductos = New SqlServer.MovimientosVentasProductos(Me.da)

         Select Case tipo

            Case TipoSP._I

               Dim valorADescontar As Decimal
               Dim valorADescontar2 As Decimal
               Dim prolo As Reglas.ProductosLotes = New Reglas.ProductosLotes(Me.da)
            Dim lot As Entidades.ProductoLote = Nothing
               Dim prod As Entidades.Producto = mov.ProductoSucursal.Producto
               Dim Linea As Integer = 0
               Dim rMovimientosVentasProductosLotes As Reglas.MovimientosVentasProductosLotes = New Reglas.MovimientosVentasProductosLotes(da)

               If Not prod.Lote Then

               sqlMVP.MovimientosVentasProductos_I(mov.MovimientoVenta.Sucursal.Id, mov.MovimientoVenta.TipoMovimiento.IdTipoMovimiento,
                                                   mov.MovimientoVenta.NumeroMovimiento, mov.Orden, mov.ProductoSucursal.Producto.IdProducto,
                                                   mov.Cantidad, mov.Precio, mov.IdaAtributoProducto01, mov.IdaAtributoProducto02,
                                                   mov.IdaAtributoProducto03, mov.IdaAtributoProducto04)

            Else
                  '# Productos Con Lote ----------------------------------------------------

                  'si es una venta
                  If mov.Cantidad < 0 Then
                     'Seleccion Manual de Lote
                     If Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Then

                     '# Inserto el producto en MovimientosVentasProductos
                     sqlMVP.MovimientosVentasProductos_I(mov.MovimientoVenta.Sucursal.IdSucursal, mov.MovimientoVenta.TipoMovimiento.IdTipoMovimiento, mov.MovimientoVenta.NumeroMovimiento,
                                                            mov.Orden, mov.ProductoSucursal.Producto.IdProducto, mov.Cantidad, mov.Precio, mov.IdaAtributoProducto01, mov.IdaAtributoProducto02,
                                                   mov.IdaAtributoProducto03, mov.IdaAtributoProducto04)

                     '# Por cada lote del producto, lo guardo
                     For Each eMVPL As Entidades.MovimientoVentaProductoLote In mov.ProductosNrosLotes
                        lot = New Reglas.ProductosLotes(da)._GetUno(eMVPL.IdLote, eMVPL.IdSucursal, eMVPL.IdProducto)
                        valorADescontar = eMVPL.Cantidad * If(mov.MovimientoVenta.Venta.IdEstadoComprobante <> "ANULADO", mov.MovimientoVenta.TipoMovimiento.CoeficienteStock, mov.MovimientoVenta.Venta.TipoComprobante.CoeficienteValores) '# Si estoy deshaciendo una NC, debo multiplicar x el coeficiente valor del comprobante

                        '# Aplico el signo correspondiente al valor a descontar
                        eMVPL.Cantidad = valorADescontar

                        lot.CantidadActual += valorADescontar

                        'Actualizo el Lote del Producto
                        prolo.EjecutaSP(lot, TipoSP._U)

                        '# Inserto los movimientos de los productos con Lote.
                        '# Le asigno el núm de movimiento.
                        eMVPL.NumeroMovimiento = mov.MovimientoVenta.NumeroMovimiento
                        rMovimientosVentasProductosLotes._Inserta(eMVPL)
                     Next

                  Else
                     'Seleccion Automatica de Lote
                     valorADescontar = mov.Cantidad


                     '# Inserto el producto en MovimientosVentasProductos
                     sqlMVP.MovimientosVentasProductos_I(mov.MovimientoVenta.Sucursal.Id, mov.MovimientoVenta.TipoMovimiento.IdTipoMovimiento,
                                                         mov.MovimientoVenta.NumeroMovimiento, mov.Orden, mov.ProductoSucursal.Producto.IdProducto,
                                                         mov.Cantidad, mov.Precio, mov.IdaAtributoProducto01, mov.IdaAtributoProducto02,
                                                   mov.IdaAtributoProducto03, mov.IdaAtributoProducto04)

                     Do While valorADescontar <> 0
                        valorADescontar2 = valorADescontar
                        lot = prolo.GetLoteMasViejoADescontar(prod.IdProducto, _
                                                                 mov.MovimientoVenta.Sucursal.Id)
                        If lot IsNot Nothing Then
                           If Math.Abs(valorADescontar) >= lot.CantidadActual Then
                              valorADescontar = valorADescontar + lot.CantidadActual
                              valorADescontar2 = lot.CantidadActual * mov.MovimientoVenta.TipoMovimiento.CoeficienteStock
                              lot.CantidadActual = 0
                           Else
                              lot.CantidadActual += valorADescontar
                              valorADescontar2 = valorADescontar
                              valorADescontar = 0
                           End If

                           'Actualizo el Lote del Producto
                           prolo.EjecutaSP(lot, TipoSP._U)

                           Linea += 1

                           '# En base al lote que se seleccionó automaticamente para descontar, hago el insert en MovimientosVentasProductosLotes
                           rMovimientosVentasProductosLotes._Inserta(New Entidades.MovimientoVentaProductoLote With {.IdSucursal = mov.MovimientoVenta.Sucursal.Id,
                                                                                                                     .IdTipoMovimiento = mov.MovimientoVenta.TipoMovimiento.IdTipoMovimiento,
                                                                                                                     .NumeroMovimiento = mov.MovimientoVenta.NumeroMovimiento,
                                                                                                                     .Orden = mov.Orden,
                                                                                                                     .IdProducto = mov.ProductoSucursal.Producto.IdProducto,
                                                                                                                     .IdLote = lot.IdLote,
                                                                                                                     .Cantidad = valorADescontar2})

                           '# Si el cliente utiliza selección de lotes automática, Y NO ES UNA NC, los lotes a descontar fueron seleccionados recientemente, por lo que se tienen que cargar en la entidad en este momento..
                           '# Obtengo los lotes seleccionados desde el movimiento
                           If mov.MovimientoVenta.Venta.IdEstadoComprobante <> "ANULADO" Then
                              Dim rVentasProductosLotes As Reglas.VentasProductosLotes = New Reglas.VentasProductosLotes(da)
                              rVentasProductosLotes._Inserta(New Entidades.VentaProductoLote With {.IdSucursal = mov.MovimientoVenta.Venta.IdSucursal,
                                                                                                   .TipoComprobante = mov.MovimientoVenta.Venta.IdTipoComprobante,
                                                                                                   .Letra = mov.MovimientoVenta.Venta.LetraComprobante,
                                                                                                   .CentroEmisor = mov.MovimientoVenta.Venta.CentroEmisor,
                                                                                                   .NumeroComprobante = mov.MovimientoVenta.Venta.NumeroComprobante,
                                                                                                   .Producto = mov.ProductoSucursal.Producto,
                                                                                                   .IdLote = lot.IdLote,
                                                                                                   .FechaVencimiento = lot.FechaVencimiento,
                                                                                                   .Cantidad = valorADescontar2 * mov.MovimientoVenta.Venta.TipoComprobante.CoeficienteStock,
                                                                                                   .Orden = mov.Orden})
                           End If
                        Else
                           'valorADescontar = 0
                           Throw New Exception("El Producto '" & prod.NombreProducto & "' ( COD: " & prod.IdProducto & " ) No tiene Stock para descontar " & Math.Abs(valorADescontar).ToString() & ",  No es posible con Lotes.")
                        End If
                     Loop


                  End If


               Else

                  '# Inserto el producto en MovimientosVentasProductos
                  sqlMVP.MovimientosVentasProductos_I(mov.MovimientoVenta.Sucursal.IdSucursal, mov.MovimientoVenta.TipoMovimiento.IdTipoMovimiento, mov.MovimientoVenta.NumeroMovimiento,
                                                         mov.Orden, mov.ProductoSucursal.Producto.IdProducto, mov.Cantidad, mov.Precio, mov.IdaAtributoProducto01, mov.IdaAtributoProducto02,
                                                   mov.IdaAtributoProducto03, mov.IdaAtributoProducto04)

                  '# Inserto los movimientos de los productos con Lote.
                  For Each eMVPL As Entidades.MovimientoVentaProductoLote In mov.ProductosNrosLotes
                     '# Le asigno el núm de movimiento.
                     eMVPL.NumeroMovimiento = mov.MovimientoVenta.NumeroMovimiento
                     eMVPL.Cantidad = eMVPL.Cantidad * mov.MovimientoVenta.TipoMovimiento.CoeficienteStock
                     rMovimientosVentasProductosLotes._Inserta(eMVPL)

                     lot = prolo._GetUno(eMVPL.IdLote, eMVPL.IdSucursal, eMVPL.IdProducto)
                     If lot IsNot Nothing Then
                        valorADescontar = eMVPL.Cantidad + lot.CantidadActual
                        prolo.ProductosLotes_UCantidadActual(eMVPL.IdLote, eMVPL.IdSucursal, eMVPL.IdProducto, valorADescontar)
                     Else

                        lot = New Entidades.ProductoLote
                        With lot
                           .IdLote = eMVPL.IdLote
                           .ProductoSucursal = New Reglas.ProductosSucursales(Me.da)._GetUno(mov.MovimientoVenta.Sucursal.IdSucursal, mov.ProductoSucursal.Producto.IdProducto)
                           .FechaIngreso = mov.MovimientoVenta.FechaMovimiento
                           .CantidadInicial = eMVPL.Cantidad
                           .CantidadActual = eMVPL.Cantidad
                           .Habilitado = True
                        End With

                        'Creo el Lote del Producto
                        prolo.EjecutaSP(lot, TipoSP._I)

                     End If

                     '# Si el cliente utiliza selección de lotes automática, los lotes a descontar fueron seleccionados recientemente, por lo que se tienen que cargar en la entidad en este momento..
                     '# Obtengo los lotes seleccionados desde el movimiento
                     '# No debe entrar cuando se está realizando una anulación
                     If Not Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto AndAlso
                        mov.MovimientoVenta.Venta.IdEstadoComprobante <> "ANULADO" Then

                        Dim rVentasProductosLotes As Reglas.VentasProductosLotes = New Reglas.VentasProductosLotes(da)
                        rVentasProductosLotes._Inserta(New Entidades.VentaProductoLote With {.IdSucursal = mov.MovimientoVenta.Venta.IdSucursal,
                                                                                             .TipoComprobante = mov.MovimientoVenta.Venta.IdTipoComprobante,
                                                                                             .Letra = mov.MovimientoVenta.Venta.LetraComprobante,
                                                                                             .CentroEmisor = mov.MovimientoVenta.Venta.CentroEmisor,
                                                                                             .NumeroComprobante = mov.MovimientoVenta.Venta.NumeroComprobante,
                                                                                             .Producto = mov.ProductoSucursal.Producto,
                                                                                             .IdLote = lot.IdLote,
                                                                                             .FechaVencimiento = lot.FechaVencimiento,
                                                                                             .Cantidad = If(mov.MovimientoVenta.Venta.TipoComprobante.CoeficienteStock > 0, eMVPL.Cantidad, valorADescontar) * mov.MovimientoVenta.Venta.TipoComprobante.CoeficienteValores,
                                                                                             .Orden = mov.Orden})
                     End If
                  Next
               End If
            End If

            Case TipoSP._D
               sqlMVP.MovimientosVentasProductos_D(mov.MovimientoVenta.Sucursal.Id, mov.MovimientoVenta.TipoMovimiento.IdTipoMovimiento, _
                              mov.MovimientoVenta.NumeroMovimiento)
         End Select
   End Sub

   Public Function GetMovimientos(ByVal idSucursal As Integer, _
                                  ByVal idTipoMovimiento As String, _
                                  ByVal numeroMovimiento As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT Orden")
         .AppendLine("      ,IdProducto")
         .AppendLine("      ,Cantidad")
         .AppendLine("      ,Precio")
         .AppendLine(" FROM MovimientosVentasProductos")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoMovimiento = '" & idTipoMovimiento & "'")
         .AppendLine("   AND numeroMovimiento = " & numeroMovimiento.ToString())
      End With

      Dim dt As DataTable = Me.DataServer.GetDataTable(stb.ToString())

      Return dt

   End Function

   Private Sub CargarUno(ByVal o As Entidades.MovimientoVentaProducto, ByVal dr As DataRow)
      With o
         .MovimientoVenta = New Reglas.MovimientosVentas(Me.da)._GetUno(Int32.Parse(dr(Entidades.MovimientoVentaProducto.Columnas.IdSucursal.ToString()).ToString()), _
                                                                              dr(Entidades.MovimientoVentaProducto.Columnas.IdTipoMovimiento.ToString()).ToString(), _
                                                                              Long.Parse(dr(Entidades.MovimientoVentaProducto.Columnas.NumeroMovimiento.ToString()).ToString()))
         .ProductoSucursal = New Reglas.ProductosSucursales(Me.da).GetUno(Int32.Parse(dr(Entidades.MovimientoVentaProducto.Columnas.IdSucursal.ToString()).ToString()), _
                                                                          dr(Entidades.MovimientoVentaProducto.Columnas.IdProducto.ToString()).ToString())
         .Orden = Int32.Parse(dr(Entidades.MovimientoVentaProducto.Columnas.Orden.ToString()).ToString())
         .Cantidad = Decimal.Parse(dr(Entidades.MovimientoVentaProducto.Columnas.Cantidad.ToString()).ToString())
         .Precio = Decimal.Parse(dr(Entidades.MovimientoVentaProducto.Columnas.Precio.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.MovimientoVentaProducto)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.MovimientoVentaProducto
         Dim oLis As List(Of Entidades.MovimientoVentaProducto) = New List(Of Entidades.MovimientoVentaProducto)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.MovimientoVentaProducto()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Me.da.CommitTransaction()
         Return oLis

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(ByVal IdSucursal As Integer, _
                           ByVal IdTipoMovimiento As String, _
                           ByVal NumeroMovimiento As Long, _
                           ByVal Orden As Long, _
                           ByVal IdProducto As String) As Entidades.MovimientoVentaProducto
      Try
         Me.da.OpenConection()

         Return Me._GetUno(IdSucursal, IdTipoMovimiento, NumeroMovimiento, _
                                                              Orden, IdProducto)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(ByVal IdSucursal As Integer, _
                           ByVal IdTipoMovimiento As String, _
                           ByVal NumeroMovimiento As Long, _
                           ByVal Orden As Long, _
                           ByVal IdProducto As String) As Entidades.MovimientoVentaProducto

      Dim sql As SqlServer.MovimientosVentasProductos = New SqlServer.MovimientosVentasProductos(Me.da)

      Dim dt As DataTable = sql.MovimientosVentasProductos_G1(IdSucursal, IdTipoMovimiento, NumeroMovimiento, _
                                                              Orden, IdProducto)

      Dim o As Entidades.MovimientoVentaProducto = New Entidades.MovimientoVentaProducto()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el MovimientoVentaProducto.")
      End If

      Return o

   End Function

#End Region

End Class
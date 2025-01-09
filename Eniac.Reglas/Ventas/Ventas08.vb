'Imports Eniac.Entidades
Partial Class Ventas

   ''GET MOVIMIENTOS DE VENTA

   Friend Function GetMovimientoVenta(venta As Entidades.Venta) As Entidades.MovimientoStock
      Dim mo = New Entidades.MovimientoStock()

      If venta.TipoComprobante.CoeficienteValores = -1 Then
         mo.TipoMovimiento = New TiposMovimientos(da).GetUno("DEVOLUCION")
      Else
         mo.TipoMovimiento = New TiposMovimientos(da).GetUno("VENTA")
      End If
      mo.Venta.TipoComprobante = venta.TipoComprobante
      mo.Venta.LetraComprobante = venta.LetraComprobante
      mo.Venta.CentroEmisor = venta.CentroEmisor
      mo.Venta.NumeroComprobante = venta.NumeroComprobante

      mo.Sucursal = New Reglas.Sucursales(da).GetUna(venta.IdSucursal, False)
      mo.FechaMovimiento = venta.Fecha
      mo.Neto = venta.Subtotal
      mo.TotalImpuestos = venta.TotalImpuestos + (venta.TotalImpuestoInterno * venta.TipoComprobante.CoeficienteValores)
      mo.Total = venta.ImporteTotal
      mo.Cliente = venta.Cliente
      mo.Venta = venta
      mo.Usuario = venta.Usuario
      mo.Observacion = venta.Observacion

      Dim pr As Entidades.MovimientoStockProducto
      Dim eMVPNS As Entidades.MovimientoStockProductoNrosSerie
      Dim eMVPL As Entidades.MovimientoStockProductoLotes
      For Each vp In venta.VentasProductos
         pr = New Entidades.MovimientoStockProducto()
         pr.ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(venta.IdSucursal, vp.Producto.IdProducto)
         pr.Cantidad = vp.Cantidad
         'Para los Movimientos solo existe 1 campo de precios y grabo el NETO.
         pr.Precio = vp.PrecioNeto
         pr.Orden = vp.Orden
         pr.IdaAtributoProducto01 = vp.IdaAtributoProducto01
         pr.IdaAtributoProducto02 = vp.IdaAtributoProducto02
         pr.IdaAtributoProducto03 = vp.IdaAtributoProducto03
         pr.IdaAtributoProducto04 = vp.IdaAtributoProducto04

         pr.IdSucursal = vp.IdSucursal
         pr.IdProducto = vp.Producto.IdProducto

         pr.IdDeposito = vp.IdDeposito    'If(vp.IdDeposito = 0, vp.Producto.IdDeposito, vp.IdDeposito)
         pr.IdUbicacion = vp.IdUbicacion  'If(vp.IdUbicacion = 0, vp.Producto.IdUbicacion, vp.IdUbicacion)

         '# Productos con Nro de Lote
         For Each eVPL In vp.VentasProductosLotes
            eMVPL = New Entidades.MovimientoStockProductoLotes
            eMVPL.IdSucursal = eVPL.IdSucursal
            eMVPL.IdTipoMovimiento = mo.TipoMovimiento.IdTipoMovimiento
            eMVPL.IdProducto = eVPL.Producto.IdProducto
            eMVPL.IdLote = eVPL.IdLote
            eMVPL.Orden = pr.Orden
            eMVPL.Cantidad = eVPL.Cantidad
            eMVPL.IdDeposito = If(vp.IdDeposito = 0, vp.Producto.IdDeposito, vp.IdDeposito)
            eMVPL.IdUbicacion = If(vp.IdUbicacion = 0, vp.Producto.IdUbicacion, vp.IdUbicacion)
            pr.ProductosNrosLotes.Add(eMVPL)
         Next

         '# Productos con Nro de Serie
         For Each ePNS In vp.Producto.NrosSeries
            eMVPNS = New Entidades.MovimientoStockProductoNrosSerie
            eMVPNS.IdProducto = ePNS.Producto.IdProducto
            eMVPNS.NroSerie = ePNS.NroSerie
            eMVPNS.Orden = vp.Orden
            eMVPNS.Cantidad = CInt((pr.Cantidad / Math.Abs(pr.Cantidad)))
            eMVPNS.IdDeposito = If(vp.IdDeposito = 0, vp.Producto.IdDeposito, vp.IdDeposito)
            eMVPNS.IdUbicacion = If(vp.IdUbicacion = 0, vp.Producto.IdUbicacion, vp.IdUbicacion)
            pr.ProductosNrosSerie.Add(eMVPNS)
         Next
         mo.Productos.Add(pr)
      Next

      Return mo
   End Function
   Private Function GetMovimientoVentaProdAutomatico(venta As Entidades.Venta) As Entidades.MovimientoStock

      Dim mo = New Entidades.MovimientoStock()

      mo.TipoMovimiento = New TiposMovimientos(da).GetUno("PRODUCCION")

      mo.Venta.TipoComprobante = venta.TipoComprobante
      mo.Venta.LetraComprobante = venta.LetraComprobante
      mo.Venta.CentroEmisor = venta.CentroEmisor
      mo.Venta.NumeroComprobante = venta.NumeroComprobante

      mo.Sucursal = New Reglas.Sucursales(da).GetUna(venta.IdSucursal, False)
      mo.FechaMovimiento = venta.Fecha
      mo.Neto = venta.Subtotal
      mo.TotalImpuestos = venta.TotalImpuestos + (venta.TotalImpuestoInterno * venta.TipoComprobante.CoeficienteValores)
      mo.Total = venta.ImporteTotal
      mo.Cliente = venta.Cliente
      mo.Venta = venta
      mo.Usuario = venta.Usuario
      mo.Observacion = venta.Observacion

      Dim pr As Entidades.MovimientoStockProducto
      For Each vp In venta.VentasProductos
         If vp.Producto.EsCompuesto And vp.Producto.DescontarStockComponentes Then
            pr = New Entidades.MovimientoStockProducto()
            pr.IdProducto = vp.Producto.IdProducto
            pr.IdSucursal = vp.IdSucursal
            pr.IdDeposito = vp.IdDeposito
            pr.IdUbicacion = vp.IdUbicacion
            pr.ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(venta.IdSucursal, vp.Producto.IdProducto)
            pr.Cantidad = vp.Cantidad * venta.TipoComprobante.CoeficienteValores
            'Para los Movimientos solo existe 1 campo de precios y grabo el NETO.
            pr.Precio = vp.PrecioNeto
            pr.Orden = vp.Orden
            mo.Productos.Add(pr)
         End If
      Next

      Return mo

   End Function
   Private Function GetMovimientoVentaDifCantidad(venta As Entidades.Venta) As Entidades.MovimientoStock

      Dim mo = New Entidades.MovimientoStock()

      If venta.TipoComprobante.CoeficienteValores = -1 Then
         mo.TipoMovimiento = New TiposMovimientos(da).GetUno("DEVOLUCION")
      Else
         mo.TipoMovimiento = New TiposMovimientos(da).GetUno("VENTA")
      End If
      mo.Venta.TipoComprobante = venta.TipoComprobante
      mo.Venta.LetraComprobante = venta.LetraComprobante
      mo.Venta.CentroEmisor = venta.CentroEmisor
      mo.Venta.NumeroComprobante = venta.NumeroComprobante

      mo.Sucursal = New Reglas.Sucursales(da).GetUna(venta.IdSucursal, False)
      mo.FechaMovimiento = venta.Fecha
      mo.Neto = venta.Subtotal
      mo.TotalImpuestos = venta.TotalImpuestos + (venta.TotalImpuestoInterno * venta.TipoComprobante.CoeficienteValores)
      mo.Total = venta.ImporteTotal
      mo.Cliente = venta.Cliente
      mo.Venta = venta
      mo.Usuario = venta.Usuario
      mo.Observacion = venta.Observacion

      Dim pr As Entidades.MovimientoStockProducto
      Dim eMVPNS As Entidades.MovimientoStockProductoNrosSerie
      Dim eMVPL As Entidades.MovimientoStockProductoLotes

      Dim VenProd As Entidades.VentaProducto

      For Each vp As Entidades.VentaProducto In venta.VentasProductos

         VenProd = New VentasProductos(da).GetUna(venta.IdSucursal,
                                                   venta.TipoComprobante.IdTipoComprobante,
                                                   venta.LetraComprobante,
                                                   venta.CentroEmisor,
                                                   venta.NumeroComprobante,
                                                   vp.Orden,
                                                   vp.Producto.IdProducto)

         'Chequeo si la nueva cantidad vario de la original, y luego grabo la diferencia como recuperacion.

         If vp.Cantidad <> VenProd.Cantidad Then
            pr = New Entidades.MovimientoStockProducto()
            pr.ProductoSucursal = New ProductosSucursales(da)._GetUno(venta.IdSucursal, vp.Producto.IdProducto)
            pr.Cantidad = vp.Cantidad - (VenProd.Cantidad * venta.TipoComprobante.CoeficienteValores)
            'Para los Movimientos solo existe 1 campo de precios y grabo el NETO.
            pr.Precio = VenProd.PrecioNeto      'TODO: Ver diferencia con VP.PrecioNeto...
            pr.Orden = VenProd.Orden
            '--------------------------------------------------------
            pr.IdSucursal = venta.IdSucursal
            pr.IdDeposito = vp.IdDeposito
            pr.IdUbicacion = vp.IdUbicacion
            pr.IdProducto = vp.Producto.IdProducto
            '--------------------------------------------------------
            pr.IdaAtributoProducto01 = VenProd.IdaAtributoProducto01
            pr.IdaAtributoProducto02 = VenProd.IdaAtributoProducto02
            pr.IdaAtributoProducto03 = VenProd.IdaAtributoProducto03
            pr.IdaAtributoProducto04 = VenProd.IdaAtributoProducto04
            '--------------------------------------------------------
            For Each eVPL In vp.VentasProductosLotes
               eMVPL = New Entidades.MovimientoStockProductoLotes()
               With eMVPL
                  .IdSucursal = eVPL.IdSucursal
                  .IdTipoMovimiento = mo.TipoMovimiento.IdTipoMovimiento
                  .IdProducto = eVPL.IdProducto
                  .IdLote = eVPL.IdLote
                  .Cantidad = eVPL.Cantidad * mo.TipoMovimiento.CoeficienteStock
                  .Orden = eVPL.Orden
               End With
               pr.ProductosNrosLotes.Add(eMVPL)
            Next

            For Each ePNS In vp.Producto.NrosSeries
               eMVPNS = New Entidades.MovimientoStockProductoNrosSerie()
               eMVPNS.IdProducto = ePNS.Producto.IdProducto
               eMVPNS.NroSerie = ePNS.NroSerie
               eMVPNS.Orden = vp.Orden
               pr.ProductosNrosSerie.Add(eMVPNS)
            Next

            mo.Productos.Add(pr)
         End If
      Next


      Return mo
   End Function

End Class
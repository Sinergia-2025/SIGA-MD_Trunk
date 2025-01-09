Public Class CalculosComisiones
   Private Property Cache As BusquedasCacheadas
   Public Sub New()
      Me.New(New BusquedasCacheadas())
   End Sub
   Public Sub New(cache As BusquedasCacheadas)
      Me.Cache = cache
   End Sub

   Public Function CalculaPorcentajeComision(venta As Entidades.Venta) As Decimal
      For Each vp In venta.VentasProductos
         vp.ComisionVendedorPorc = CalculaPorcentajeComision(vp, venta)
         vp.ComisionVendedor = CalculaComision(vp)
      Next
   End Function

   Const LogTAG As String = "CalculosComisiones.CalculaPorcentajeComision"
   Public Function CalculaPorcentajeComision(ventaProd As Entidades.VentaProducto, venta As Entidades.Venta) As Decimal

      'AR: Cambie que habra una conexion nueva porque mataba la del proceso principal
      Dim marca = Cache.BuscaMarca(ventaProd.Producto.IdMarca)
      Dim rubro = Cache.BuscaRubro(ventaProd.Producto.IdRubro)
      Dim subRubro = Cache.BuscaSubRubroEntidad(ventaProd.Producto.IdSubRubro)
      Dim producto = Cache.BuscaProductoLivianoPorId(ventaProd.Producto.IdProducto.Trim(), Base.AccionesSiNoExisteRegistro.Excepcion)

      Dim empleadoComisiones = Cache.BuscaEmpleado(venta.Vendedor.IdEmpleado, True)

      Dim porcEmpleadoProducto As Decimal? = Nothing
      Dim porcEmpleadoMarca As Decimal? = Nothing
      Dim porcEmpleadoRubro As Decimal? = Nothing
      Dim porcEmpleadoSubRubro As Decimal? = Nothing
      Dim porcEmpleadoSubSubRubro As Decimal? = Nothing

      Using dsComisiones = empleadoComisiones.Comisiones
         For Each rd In dsComisiones.Tables.OfType(Of DataTable)
            If rd.TableName = Entidades.Empleado.ComisionesMarcasTableName Then
               For Each dr In rd.Rows.OfType(Of DataRow)
                  If Integer.Parse(dr("IdMarca").ToString()) = ventaProd.Producto.IdMarca Then
                     porcEmpleadoMarca = Decimal.Parse(dr("Comision").ToString())
                  End If
               Next
            End If
            If rd.TableName = Entidades.Empleado.ComisionesRubrosTableName Then
               For Each dr In rd.Rows.OfType(Of DataRow)
                  If Integer.Parse(dr("IdRubro").ToString()) = ventaProd.Producto.IdRubro Then
                     porcEmpleadoRubro = Decimal.Parse(dr("Comision").ToString())
                  End If
               Next
            End If
            If rd.TableName = Entidades.Empleado.ComisionesSubRubrosTableName Then
               For Each dr In rd.Rows.OfType(Of DataRow)
                  If dr.Field(Of Integer)("IdSubRubro") = ventaProd.Producto.IdSubRubro Then
                     porcEmpleadoSubRubro = Decimal.Parse(dr("Comision").ToString())
                  End If
               Next
            End If
            If rd.TableName = Entidades.Empleado.ComisionesSubSubRubrosTableName Then
               For Each dr In rd.Rows.OfType(Of DataRow)
                  If dr.Field(Of Integer)("IdSubSubRubro") = ventaProd.Producto.IdSubSubRubro Then
                     porcEmpleadoSubSubRubro = Decimal.Parse(dr("Comision").ToString())
                  End If
               Next
            End If
            If rd.TableName = Entidades.Empleado.ComisionesProductosTableName Then
               For Each dr In rd.Rows.OfType(Of DataRow)
                  If dr("IdProducto").ToString() = ventaProd.IdProducto Then
                     porcEmpleadoProducto = Decimal.Parse(dr("Comision").ToString())
                  End If
               Next
            End If
         Next
      End Using

      Dim idListaDePrecios = ventaProd.IdListaPrecios

      Dim oVendedorMarcaLista = New EmpleadosComisionesMarcasPrecios().GetUna(venta.Vendedor.IdEmpleado, ventaProd.Producto.IdMarca, idListaDePrecios)
      Dim porcEmpleadoMarcaLista As Decimal? = Nothing
      If oVendedorMarcaLista <> 0 Then
         porcEmpleadoMarcaLista = oVendedorMarcaLista
      End If

      Dim oVendedorRubroLista = New EmpleadosComisionesRubrosPrecios().GetUna(venta.Vendedor.IdEmpleado, ventaProd.Producto.IdRubro, idListaDePrecios)
      Dim porcEmpleadoRubroLista As Decimal? = Nothing
      If oVendedorRubroLista <> 0 Then
         porcEmpleadoRubroLista = oVendedorRubroLista
      End If

      Dim oVendedorProductoLista = New EmpleadosComisionesProductosPrecios().GetUna(venta.Vendedor.IdEmpleado, ventaProd.Producto.IdProducto.Trim(), idListaDePrecios)
      Dim porcEmpleadoProductoLista As Decimal? = Nothing
      If oVendedorProductoLista <> 0 Then
         porcEmpleadoProductoLista = oVendedorProductoLista
      End If

      Dim porcentajeComision As Decimal? = Nothing

      My.Application.Log.WriteEntry(New String("="c, 80), TraceEventType.Information)
      My.Application.Log.WriteEntry(String.Format("Inicia {0}(Entidades.VentaProducto, Entidades.Venta)", LogTAG), TraceEventType.Information)
      My.Application.Log.WriteEntry(New String("="c, 80), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0}: Publicos.ComisionVendedor: '{1}'", LogTAG, Publicos.ComisionVendedor), TraceEventType.Information)

      If Publicos.ComisionVendedor = "VENDEDORRUBROMARCA" Then
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO PRODUCTO LISTA: '{1}'", LogTAG, porcEmpleadoProductoLista.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO PRODUCTO: '{1}'", LogTAG, porcEmpleadoProducto.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO SUB SUB RUBRO: '{1}'", LogTAG, porcEmpleadoSubSubRubro.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO SUB RUBRO: '{1}'", LogTAG, porcEmpleadoSubRubro.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO RUBRO LISTA: '{1}'", LogTAG, porcEmpleadoRubroLista.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO RUBRO: '{1}'", LogTAG, porcEmpleadoRubro.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO MARCA LISTA: '{1}'", LogTAG, porcEmpleadoMarcaLista.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO MARCA: '{1}'", LogTAG, porcEmpleadoMarca.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: PRODUCTO: '{1}'", LogTAG, producto.ComisionPorVenta), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: RUBRO: '{1}'", LogTAG, rubro.ComisionPorVenta), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: MARCA: '{1}'", LogTAG, marca.ComisionPorVenta), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO: '{1}'", LogTAG, venta.Vendedor.ComisionPorVenta), TraceEventType.Information)

         My.Application.Log.WriteEntry(New String("-"c, 80), TraceEventType.Information)

         If porcEmpleadoProductoLista.HasValue Then                   'EMPLEADO PRODUCTO LISTA
            porcentajeComision = porcEmpleadoProductoLista.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO PRODUCTO LISTA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoProducto.HasValue Then                          'EMPLEADO PRODUCTO
            porcentajeComision = porcEmpleadoProducto.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO PRODUCTO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoSubSubRubro.HasValue Then                   'EMPLEADO SUB SUB RUBRO
            porcentajeComision = porcEmpleadoSubSubRubro.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO SUB SUB RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoSubRubro.HasValue Then                      'EMPLEADO SUB RUBRO
            porcentajeComision = porcEmpleadoSubRubro.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO SUB RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoRubroLista.HasValue Then                    'EMPLEADO RUBRO LISTA
            porcentajeComision = porcEmpleadoRubroLista.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO RUBRO LISTA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoRubro.HasValue Then                         'EMPLEADO RUBRO
            porcentajeComision = porcEmpleadoRubro.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoMarcaLista.HasValue Then                    'EMPLEADO MARCA LISTA
            porcentajeComision = porcEmpleadoMarcaLista.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO MARCA LISTA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoMarca.HasValue Then                         'EMPLEADO MARCA
            porcentajeComision = porcEmpleadoMarca.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO MARCA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf producto.ComisionPorVenta <> 0 Then                     'PRODUCTO
            porcentajeComision = producto.ComisionPorVenta
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = PRODUCTO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf rubro.ComisionPorVenta <> 0 Then                        'RUBRO
            porcentajeComision = rubro.ComisionPorVenta
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf marca.ComisionPorVenta <> 0 Then                        'MARCA
            porcentajeComision = marca.ComisionPorVenta
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = MARCA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         End If
      Else
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO PRODUCTO LISTA: '{1}'", LogTAG, porcEmpleadoProductoLista.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO PRODUCTO: '{1}'", LogTAG, porcEmpleadoProducto.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO MARCA LISTA: '{1}'", LogTAG, porcEmpleadoMarcaLista.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO MARCA: '{1}'", LogTAG, porcEmpleadoMarca.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO SUB SUB RUBRO: '{1}'", LogTAG, porcEmpleadoSubSubRubro.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO SUB RUBRO: '{1}'", LogTAG, porcEmpleadoSubRubro.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO RUBRO LISTA: '{1}'", LogTAG, porcEmpleadoRubroLista.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO RUBRO: '{1}'", LogTAG, porcEmpleadoRubro.ToStringLog()), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: PRODUCTO: '{1}'", LogTAG, producto.ComisionPorVenta), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: MARCA: '{1}'", LogTAG, marca.ComisionPorVenta), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: RUBRO: '{1}'", LogTAG, rubro.ComisionPorVenta), TraceEventType.Information)
         My.Application.Log.WriteEntry(String.Format("{0}: EMPLEADO: '{1}'", LogTAG, venta.Vendedor.ComisionPorVenta), TraceEventType.Information)

         My.Application.Log.WriteEntry(New String("-"c, 80), TraceEventType.Information)

         If porcEmpleadoProductoLista.HasValue Then                   'EMPLEADO PRODUCTO LISTA
            porcentajeComision = porcEmpleadoProductoLista.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO PRODUCTO LISTA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoProducto.HasValue Then                          'EMPLEADO PRODUCTO
            porcentajeComision = porcEmpleadoProducto.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO PRODUCTO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoMarcaLista.HasValue Then                    'EMPLEADO MARCA LISTA
            porcentajeComision = porcEmpleadoMarcaLista.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO MARCA LISTA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoMarca.HasValue Then                         'EMPLEADO MARCA
            porcentajeComision = porcEmpleadoMarca.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO MARCA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoSubSubRubro.HasValue Then                   'EMPLEADO SUB SUB RUBRO
            porcentajeComision = porcEmpleadoSubSubRubro.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO SUB SUB RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoSubRubro.HasValue Then                      'EMPLEADO SUB RUBRO
            porcentajeComision = porcEmpleadoSubRubro.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO SUB RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoRubroLista.HasValue Then                    'EMPLEADO RUBRO LISTA
            porcentajeComision = porcEmpleadoRubroLista.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO RUBRO LISTA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf porcEmpleadoRubro.HasValue Then                         'EMPLEADO RUBRO
            porcentajeComision = porcEmpleadoRubro.Value
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf producto.ComisionPorVenta <> 0 Then                     'PRODUCTO
            porcentajeComision = producto.ComisionPorVenta
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = PRODUCTO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf marca.ComisionPorVenta <> 0 Then                        'MARCA
            porcentajeComision = marca.ComisionPorVenta
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = MARCA = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         ElseIf rubro.ComisionPorVenta <> 0 Then                        'RUBRO
            porcentajeComision = rubro.ComisionPorVenta
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = RUBRO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         End If
      End If
      If Not porcentajeComision.HasValue AndAlso venta.Vendedor.ComisionPorVenta <> 0 Then      'EMPLEADO
         porcentajeComision = venta.Vendedor.ComisionPorVenta
         My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = EMPLEADO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
      End If

      If Not porcentajeComision.HasValue Then
         porcentajeComision = 0
      End If

      Dim descuentoCombinado = CalculosDescuentosRecargos.CombinaDosDescuentos(ventaProd.DescuentoRecargoPorc1, ventaProd.DescuentoRecargoPorc2, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
      If subRubro IsNot Nothing AndAlso subRubro.SubRubroComisionPorDescuento.AnySecure() Then  'SUB RUBO POR DESCUENTO
         Dim com = subRubro.SubRubroComisionPorDescuento.Where(Function(x) x.DescuentoRecargoHasta <= descuentoCombinado).OrderByDescending(Function(x) x.DescuentoRecargoHasta).FirstOrDefault()
         If com IsNot Nothing Then
            porcentajeComision = com.Comision
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = SUB RUBO POR DESCUENTO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         End If
      ElseIf rubro IsNot Nothing AndAlso rubro.RubroComisionPorDescuento.AnySecure() Then       'RUBRO POR DESCUENTO
         Dim com = rubro.RubroComisionPorDescuento.Where(Function(x) x.DescuentoRecargoHasta <= descuentoCombinado).OrderByDescending(Function(x) x.DescuentoRecargoHasta).FirstOrDefault()
         If com IsNot Nothing Then
            porcentajeComision = com.Comision
            My.Application.Log.WriteEntry(String.Format("{0}: --> porcentajeComision = RUBRO POR DESCUENTO = {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)
         End If
      End If

      My.Application.Log.WriteEntry(String.Format("{0}: RETURN {1}", LogTAG, porcentajeComision.ToStringLog()), TraceEventType.Information)

      My.Application.Log.WriteEntry(New String("="c, 80), TraceEventType.Information)
      My.Application.Log.WriteEntry(String.Format("Finaliza {0}(Entidades.VentaProducto, Entidades.Venta)", LogTAG), TraceEventType.Information)
      My.Application.Log.WriteEntry(New String("="c, 80), TraceEventType.Information)

      Return porcentajeComision.Value
   End Function

   Public Function CalculaComision(vp As Entidades.VentaProducto) As Decimal
      Return CalculaComision(vp, redondeo:=4)
   End Function
   Public Function CalculaComision(vp As Entidades.VentaProducto, redondeo As Integer) As Decimal
      Return CalculaComisionInterno(vp.ImporteTotal, vp.ComisionVendedorPorc, redondeo)
   End Function

   Private Function CalculaComisionInterno(baseCalculo As Decimal, porc As Decimal, redondeo As Integer) As Decimal
      Return Decimal.Round(baseCalculo * porc / 100, redondeo)
   End Function

End Class
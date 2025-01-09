Imports Eniac.Entidades

Public Class NovedadesProduccionMRPProductos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = NovedadProduccionMRPProducto.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRPProducto), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRPProducto), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRPProducto), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRPProducto), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRPProducto), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRPProducto), TipoSP._D)
   End Sub
   '-------------------------------------------------------------------------------------------------
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.NovedadesProduccionMRPProductos
      Return New SqlServer.NovedadesProduccionMRPProductos(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.NovedadProduccionMRPProducto, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Novedades de Produccion Productos.- --------
            sqlC.NovedadesProduccionMRPProductos_I(en.NumeroNovedadesProducccion, en.CodigoOperacion, en.IdProducto, en.EsProductoNecesario,
                                                   en.EsProductoAgregado, en.CantidadInformada, en.IdSucursal, en.IdDeposito, en.IdUbicacion,
                                                   en.PrecioCosto, en.InformeCalidadNumero, en.InformeCalidadLink)
            '-- Actualiza Novedades de Produccion Productos Lotes.- --------------------------------------------
            Dim rProductosL = New NovedadesProduccionMRPProductosLotes(da)
            rProductosL.ActualizaNovedadesProductosLotes(en)
      End Select
   End Sub
#End Region

#Region "Metodos publicos"
   '-- REQ-41860.- ----------------------------------------------------------------------------------------------------------
   Public Sub ActualizaStockProductosResultantesNuevos(entidad As NovedadProduccionMRP, fecha As Date, _cache As BusquedasCacheadas)
      Dim suc = New Sucursales(da).GetUna(entidad.IdSucursal, False)
      Dim tpMovimientoProduccion = New TiposMovimientos(da).GetUno("PRODUCCION")
      Dim rProdSuc = New ProductosSucursales(da)
      Dim rMovStock = New MovimientosStock(da)

      'Inserto el movimiento de Producción
      Dim eMovStock = New Entidades.MovimientoStock() With {
            .Sucursal = suc,
            .TipoMovimiento = tpMovimientoProduccion,
            .FechaMovimiento = fecha,
            .DescuentoRecargo = 0,
            .PercepcionIVA = 0,
            .PercepcionIB = 0,
            .PercepcionGanancias = 0,
            .PercepcionVarias = 0,
            .Usuario = actual.Nombre,
            .IdProduccion = 0
         }
      For Each oPR In entidad.ProductosResultantes.Where(Function(x) x.CantidadInformada > 0 And x.IdProducto <> entidad.IdProducto)
         Dim precioCosto = rProdSuc.GetUno(oPR.IdSucursal, oPR.IdProducto, 0).PrecioCosto
         Dim movCompEntradaPT = New Entidades.MovimientoStockProducto With {
            .IdSucursal = oPR.IdSucursal,
            .IdDeposito = oPR.IdDeposito,
            .IdUbicacion = oPR.IdUbicacion,
            .Cantidad = oPR.CantidadInformada,
            .DescRecGeneral = 0,
            .DescuentoRecargo = 0,
            .IdProducto = oPR.IdProducto,
            .NombreProducto = oPR.NombreProducto,
            .Precio = precioCosto,
            .ImporteTotal = Decimal.Round(oPR.CantidadInformada * precioCosto, 2),
            .IVA = 0
         }

         eMovStock.Productos.Add(movCompEntradaPT)
      Next
      'Movimientos de Stock Entrada.- ---------------
      rMovStock.GrabarMovimientoProduccion(eMovStock)
      '----------------------------------------------
   End Sub

   Public Sub ActualizaNovedadesProductos(entidad As NovedadProduccionMRP)
      If entidad.ProductosNecesarios IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.ProductosNecesarios.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPN In entidad.ProductosNecesarios.Where(Function(x) x.CantidadInformada > 0)
            If oPN.NumeroNovedadesProducccion = 0 Then
               oPN.NumeroNovedadesProducccion = entidad.NumeroNovedadesProducccion
               oPN.IdSucursal = entidad.IdSucursal
               _Insertar(oPN)
               '-- Actualizar Cantidad Procesada.- -----------------------------------
               Dim rOrdProProd = New Reglas.OrdenesProduccionMRPProductos(da)
               rOrdProProd.ActualizarCantidadOrdProdMRPPro(entidad.IdSucursal, entidad.IdTipoComprobante, entidad.LetraComprobante,
                                                           entidad.CentroEmisor, entidad.NumeroOrdenProduccion, entidad.Orden,
                                                           entidad.IdProcesoProductivo, oPN.IdProducto, entidad.IdOperacion,
                                                           oPN.EsProductoNecesario, oPN.CantidadInformada)
               '----------------------------------------------------------------------
            End If
         Next
         '----------------------------------------------------------------------------
      End If
      If entidad.ProductosResultantes IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.ProductosResultantes.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPR In entidad.ProductosResultantes.Where(Function(x) x.CantidadInformada > 0)
            If oPR.NumeroNovedadesProducccion = 0 Then
               oPR.NumeroNovedadesProducccion = entidad.NumeroNovedadesProducccion
               oPR.IdSucursal = entidad.IdSucursal
               _Insertar(oPR)
               '-- Actualizar Cantidad Procesada.- -----------------------------------
               Dim rOrdProProd = New Reglas.OrdenesProduccionMRPProductos(da)
               rOrdProProd.ActualizarCantidadOrdProdMRPPro(entidad.IdSucursal, entidad.IdTipoComprobante, entidad.LetraComprobante,
                                                           entidad.CentroEmisor, entidad.NumeroOrdenProduccion, entidad.Orden,
                                                           entidad.IdProcesoProductivo, oPR.IdProducto, entidad.IdOperacion,
                                                           oPR.EsProductoNecesario, oPR.CantidadInformada)
               '----------------------------------------------------------------------
            End If
         Next
         '----------------------------------------------------------------------------
      End If
   End Sub

   Public Function GetInformeDeclaraciones(idResponsable As Integer, idTarea As Integer, fechaDesde As Date?, fechaHasta As Date?,
                                           idProductoDeclarado As String, esNecesario As Entidades.Publicos.NecesarioResultanteTodos, esAgregado As Entidades.Publicos.SiNoTodos,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                           idProducto As String, idCliente As Long?, idProcesoProductivo As Long,
                                           idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                           planMaestroNumero As Integer) As DataTable
      Return GetSql().GetInformeDeclaraciones(idResponsable, idTarea, fechaDesde, fechaHasta,
                                              idProductoDeclarado, esNecesario, esAgregado,
                                              idTipoComprobante, letraFiscal, centroEmisor, numeroDesde, numeroHasta,
                                              idProducto, idCliente, idProcesoProductivo,
                                              idTipoComprobantePedido, letraFiscalPedido, centroEmisorPedido, numeroPedidoDesde, numeroPedidoHasta, lineaPedido,
                                              planMaestroNumero)
   End Function


#End Region

End Class
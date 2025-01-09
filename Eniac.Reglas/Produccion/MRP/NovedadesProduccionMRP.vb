Imports Eniac.Entidades
Public Class NovedadesProduccionMRP
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = NovedadProduccionMRP.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Sub ActualizarDeclaracion(novedad As NovedadProduccionMRP, eOPO As OrdenProduccionMRPOperacion, _detalle As OrdenProduccionMRP, idFuncion As String)
      EjecutaConTransaccion(Sub() _ActualizarDeclaracion(novedad, eOPO, _detalle, idFuncion))
   End Sub
   Public Sub _ActualizarDeclaracion(novedad As NovedadProduccionMRP, eOPO As OrdenProduccionMRPOperacion, _detalle As OrdenProduccionMRP, idFuncion As String)
      Dim cache = New BusquedasCacheadas()
      ActualizaNovedadesProduccion(novedad)
      '-- Actualiza Estado.- ---------------------------------
      If eOPO IsNot Nothing Then
         Dim regla = New Reglas.OrdenesProduccionMRPOperaciones(da)
         regla._ActualizarAsigna(eOPO)
         '-- Carga Orden de Produccion.- -------------------------------------------------------------------------------------------------------
         Dim oLista = _detalle.Operaciones.Where(Function(x) x.CodigoProcProdOperacion <> novedad.CodigoOperacion And x.IdEstadoTarea <> Reglas.Publicos.EstadoAsignaTarea.FINALIZADA.ToString()).ToList()
         If oLista.Count = 0 Then
            '-- Define nuevo Estado.
            Dim estadoNew = Publicos.EstadoFinalOrdenProduccion

            Dim rOPE = New OrdenesProduccionEstados(da)

            Dim detalle = rOPE.GetParaAdmin(novedad.IdSucursal, novedad.IdTipoComprobante, novedad.LetraComprobante, novedad.CentroEmisor, novedad.NumeroOrdenProduccion, novedad.Orden, novedad.IdProducto, fechaEstado:=Nothing)

            Dim cambioEstado = New Entidades.OrdenesProduccionAdminCambioEstado(cache.BuscaEstadosOrdenesProduccion(estadoNew)) With {
               .Pedidos = detalle.ConvertAll(Function(op) DirectCast(op, AdminCambioEstadoDetalle(Of EstadoOrdenProduccion)))
            }
            rOPE._ActualizarEstadoOrdenProduccionMasivo(cambioEstado, idFuncion)
         End If
      End If
   End Sub

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRP), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRP), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRP), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRP), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRP), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, NovedadProduccionMRP), TipoSP._D)
   End Sub
   '-------------------------------------------------------------------------------------------------
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.NovedadesProduccionMRP
      Return New SqlServer.NovedadesProduccionMRP(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.NovedadProduccionMRP, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Novedades de Produccion.- --------
            sqlC.NovedadesProduccionMRP_I(en.NumeroNovedadesProducccion, en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante,
                                          en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto, en.IdProcesoProductivo,
                                          en.CodigoOperacion, en.UsuarioAlta, en.FechaAlta, en.FechaNovedad, en.IdEmpleado)
            '-- Actualiza Tiempos.- ---------------------------------
            Dim rTiemposN = New NovedadesProduccionMRPTiempos(da)
            rTiemposN.ActualizaNovedadesTiempos(en)
            '-- Actualiza Novedades de Produccion Productos.- --------------------------------------------
            Dim rProductosN = New NovedadesProduccionMRPProductos(da)
            rProductosN.ActualizaNovedadesProductos(en)

            If en.ClaseCentroProductor = MRPCentroProductor.ClaseCentrosProd.INT Then
               '--Actualiza Stock de Resultantes Agregados.- --REQ-41860.- ----------------------------------
               rProductosN.ActualizaStockProductosResultantesNuevos(en, Now, New BusquedasCacheadas())
               '---------------------------------------------------------------------------------------------
               Dim rProduccion = New Produccion(da)
               rProduccion.GrabarProduccion(ConvierteNovedadProduccionEnProduccion(en), Now, New BusquedasCacheadas())
            End If

      End Select
   End Sub

   Private Function ConvierteNovedadProduccionEnProduccion(en As Entidades.NovedadProduccionMRP) As Entidades.Produccion
      'Instancio el Movimiento de Compra poniendo en la Observacion el motivo de la reserva.
      Dim prod = New Entidades.Produccion With {
             .IdSucursal = actual.Sucursal.Id,
             .Fecha = Now,
             .Usuario = actual.Nombre,
             .Responsable = New Empleados(da).GetUno(en.IdEmpleado)
         }

      Dim orden = 0I
      For Each pr In en.ProductosResultantes.Where(Function(x) x.CantidadInformada >= 0 And x.EsProductoAgregado = False And x.IdProducto = en.IdProducto)
         Dim lotes = pr.ProductosLotes.ToList()
         If Not lotes.AnySecure() Then
            lotes.Add(New NovedadProduccionMRPProductoLote() With {
                           .Cantidad = pr.CantidadInformada,
                           .IdLote = String.Empty,
                           .EsProductoNecesario = pr.EsProductoNecesario
                      })
         End If
         For Each l In lotes
            orden += 1
            Dim prodProd = New Entidades.ProduccionProducto With {
                              .IdProducto = pr.IdProducto,
                              .IdSucursal = pr.IdSucursal,
                              .Cantidad = l.Cantidad,
                              .IdLote = l.IdLote,
                              .Orden = orden,
                              .IdDeposito = pr.IdDeposito,
                              .IdUbicacion = pr.IdUbicacion
                            }
            '.NrosSerie = pr.
            For Each pn In en.ProductosNecesarios
               Dim lotesC = pn.ProductosLotes.ToList()
               If Not lotesC.AnySecure() Then
                  lotesC.Add(New NovedadProduccionMRPProductoLote() With {
                           .Cantidad = pn.CantidadInformada,
                           .IdLote = String.Empty,
                           .EsProductoNecesario = pn.EsProductoNecesario
                      })
               End If
               For Each lc In lotesC
                  orden += 1
                  Dim prodComp = New Entidades.ProduccionProductoComp With {
                              .IdProducto = pr.IdProducto,
                              .IdProductoComponente = pn.IdProducto,
                              .IdSucursal = pn.IdSucursal,
                              .Cantidad = lc.Cantidad,
                              .Orden = orden,
                              .IdDeposito = pn.IdDeposito,
                              .IdUbicacion = pn.IdUbicacion,
                              .IdMoneda = Entidades.Moneda.Peso
                            }
                  'prodComp.IdLote = l.IdLote,
                  prodProd.Componentes.Add(prodComp)
                  '.NrosSerie = pr.
               Next
            Next
            prod.Productos.Add(prodProd)
         Next
      Next

      Return prod
   End Function

#End Region

#Region "Metodos publicos"
   Public Sub ActualizaNovedadesProduccion(entidad As NovedadProduccionMRP)
      Dim sqlC = GetSql()
      If entidad IsNot Nothing Then
         '----------------------------------------------------------------------------
         If entidad.NumeroNovedadesProducccion = 0 Then
            entidad.NumeroNovedadesProducccion = sqlC.GetCodigoMaximo() + 1
            _Insertar(entidad)
         End If
         '----------------------------------------------------------------------------
      End If
   End Sub

   Public Function GetInformeDeclaraciones(idResponsable As Integer, idTarea As Integer, fechaDesde As Date?, fechaHasta As Date?,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                           idProducto As String, idCliente As Long?, idProcesoProductivo As Long,
                                           idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                           planMaestroNumero As Integer) As DataTable
      Return GetSql().GetInformeDeclaraciones(idResponsable, idTarea, fechaDesde, fechaHasta,
                                              idTipoComprobante, letraFiscal, centroEmisor, numeroDesde, numeroHasta,
                                              idProducto, idCliente, idProcesoProductivo,
                                              idTipoComprobantePedido, letraFiscalPedido, centroEmisorPedido, numeroPedidoDesde, numeroPedidoHasta, lineaPedido,
                                              planMaestroNumero)
   End Function

#End Region

End Class
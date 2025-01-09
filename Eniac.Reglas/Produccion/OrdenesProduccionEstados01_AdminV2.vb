Partial Class OrdenesProduccionEstados

   Public Const AdminV2_DetalleProducto_DetalleComponentes_RelationName As String = "DetalleProducto_DetalleComponentes"
   Public Const AdminV2_DetalleProducto_TableName As String = "DetalleProducto"
   Public Const AdminV2_DetalleComponentes_TableName As String = "DetalleComponentes"

   Public Function GetDataSetCambioMasivo(dt As DataTable) As Tuple(Of DataSet,
                                                                       Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                                                       Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                                                       Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)))
      Dim _dsDetalle = New DataSet()

      Dim _dtDetalle = dt.Copy()
      _dsDetalle.Tables.Add(AdminV2_DetalleProducto_TableName, _dtDetalle)
      Dim _dtComponentes = New DataTable()
      _dsDetalle.Tables.Add(AdminV2_DetalleComponentes_TableName, _dtComponentes)
      _dtDetalle.Columns.Add("NombreDepositoUbicacion", GetType(String))
      _dtDetalle.Columns.Add("LoteSeleccionado", GetType(String))
      _dtDetalle.Columns.Add("NroSerieSeleccionado", GetType(String))

      _dtDetalle.Columns.Add("CantidadNuevoEstado", GetType(Decimal))

      _dtDetalle.Columns.Add("Producto", GetType(Object))

      Dim _ubicaciones = New Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))()
      For Each dr In _dtDetalle.AsEnumerable()
         _ubicaciones.Add(dr, New List(Of Entidades.SeleccionMultipleUbicaciones)())
      Next

      _dtDetalle.ForEach(
         Sub(dr)
            dr("CantidadNuevoEstado") = dr("CantEntregada")

            dr("LoteSeleccionado") = "(seleccionar)"
            dr("NroSerieSeleccionado") = "(seleccionar)"

            dr("Producto") = New Productos(da)._GetUnoParaM(dr.Field(Of String)("IdProducto"))
         End Sub)

      _dtComponentes.Columns.Add("IdSucursal", GetType(Integer))
      _dtComponentes.Columns.Add("IdTipoComprobante", GetType(String))
      _dtComponentes.Columns.Add("Letra", GetType(String))
      _dtComponentes.Columns.Add("CentroEmisor", GetType(Integer))
      _dtComponentes.Columns.Add("NumeroOrdenProduccion", GetType(Integer))
      _dtComponentes.Columns.Add("Orden", GetType(Integer))
      _dtComponentes.Columns.Add("IdProducto", GetType(String))
      _dtComponentes.Columns.Add("NombreProducto", GetType(String))

      _dtComponentes.Columns.Add("IdEstado", GetType(String))

      _dtComponentes.Columns.Add("IdFormula", GetType(Integer))
      _dtComponentes.Columns.Add("IdProcesoProductivo", GetType(Integer))

      _dtComponentes.Columns.Add("IdProductoComponente", GetType(String))
      _dtComponentes.Columns.Add("NombreProductoComponente", GetType(String))
      _dtComponentes.Columns.Add("CantidadFormula", GetType(Decimal))
      _dtComponentes.Columns.Add("CantidadNuevoEstado", GetType(Decimal))

      _dtComponentes.Columns.Add("Producto", GetType(Object))

      _dtComponentes.Columns.Add("IdDepositoDefecto", GetType(Integer))
      _dtComponentes.Columns.Add("IdUbicacionDefecto", GetType(Integer))
      _dtComponentes.Columns.Add("NombreDepositoDefecto", GetType(String))
      _dtComponentes.Columns.Add("NombreUbicacionDefecto", GetType(String))

      _dtComponentes.Columns.Add("NombreDepositoUbicacion", GetType(String))
      _dtComponentes.Columns.Add("LoteSeleccionado", GetType(String))
      _dtComponentes.Columns.Add("NroSerieSeleccionado", GetType(String))

      _dtComponentes.Columns.Add("NombreDepositoUbicacionDestino", GetType(String))
      _dtComponentes.Columns.Add("ProductoFormula", GetType(Object))


      Dim rProducto = New Reglas.Productos()
      Dim rOPPF = New Reglas.OrdenesProduccionProductosFormulas()

      Dim _ubicacionesComponentes = New Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))()
      Dim _ubicacionesComponentesDetalle = New Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))()

      For Each drDetalle In _dtDetalle.AsEnumerable()
         Dim idSucursal = drDetalle.Field(Of Integer)("IdSucursal")
         Dim idTipoComprobante = drDetalle.Field(Of String)("IdTipoComprobante")
         Dim letra = drDetalle.Field(Of String)("Letra")
         Dim centroEmisor = drDetalle.Field(Of Integer)("CentroEmisor")
         Dim numeroOrdenProduccion = drDetalle.Field(Of Integer)("NumeroOrdenProduccion")
         Dim orden = drDetalle.Field(Of Integer)("Orden")
         Dim idProducto = drDetalle.Field(Of String)("IdProducto")
         Dim nombreProducto = drDetalle.Field(Of String)("NombreProducto")

         Dim idFormula = drDetalle.Field(Of Integer?)("IdFormula")
         Dim idProcesoProductivo = drDetalle.Field(Of Long?)("IdProcesoProductivo")

         If idFormula.HasValue Then
            Dim oppFormula = rOPPF.GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                            idProducto, orden, soloMateriaPrima:=True)
            Dim fCOnverter = New Entidades.FormulaConverter()
            For Each oppf In oppFormula.OrderBy(Function(x) x.NombreProductoComponente)
               Dim drComponente = _dtComponentes.NewRow()
               drComponente("IdSucursal") = idSucursal
               drComponente("IdTipoComprobante") = idTipoComprobante
               drComponente("Letra") = letra
               drComponente("CentroEmisor") = centroEmisor
               drComponente("NumeroOrdenProduccion") = numeroOrdenProduccion
               drComponente("Orden") = orden
               drComponente("IdProducto") = idProducto
               drComponente("NombreProducto") = nombreProducto

               drComponente("IdEstado") = drDetalle.Field(Of String)("IdEstado")

               drComponente.SetField("IdFormula", idFormula)
               drComponente.SetField("IdProcesoProductivo", idProcesoProductivo)


               drComponente("IdProductoComponente") = oppf.IdProductoComponente
               drComponente("NombreProductoComponente") = oppf.NombreProductoComponente

               Dim productoComp = rProducto.GetUnoParaM(oppf.IdProductoComponente)

               drComponente("Producto") = productoComp

               drComponente("IdDepositoDefecto") = productoComp.IdDepositoDefecto
               drComponente("IdUbicacionDefecto") = productoComp.IdUbicacionDefecto
               drComponente("NombreDepositoDefecto") = productoComp.NombreDepositoDefecto
               drComponente("NombreUbicacionDefecto") = productoComp.NombreUbicacionDefecto

               drComponente("ProductoFormula") = fCOnverter.ConvertirFormulaOPEnProduccion(oppf)

               drComponente("LoteSeleccionado") = "(seleccionar)"
               drComponente("NroSerieSeleccionado") = "(seleccionar)"

               _dtComponentes.Rows.Add(drComponente)

               drComponente.SumField("CantidadFormula", oppf.CantidadEnFormula * drDetalle.Field(Of Decimal?)("CantidadNuevoEstado").IfNull())
               drComponente.SumField("CantidadNuevoEstado", oppf.CantidadEnFormula * drDetalle.Field(Of Decimal?)("CantidadNuevoEstado").IfNull())

               If Not _ubicacionesComponentes.ContainsKey(drComponente) Then
                  _ubicacionesComponentes.Add(drComponente, New List(Of Entidades.SeleccionMultipleUbicaciones)())
               End If
               If Not _ubicacionesComponentesDetalle.ContainsKey(drComponente) Then
                  _ubicacionesComponentesDetalle.Add(drComponente, New List(Of Entidades.SeleccionMultipleUbicaciones)())
               End If
            Next

         End If
         If idProcesoProductivo.HasValue Then

            If idProcesoProductivo.HasValue Then
               Dim sqlOPMRP = New SqlServer.OrdenesProduccionMRPProductos(da)

               Using dtMRP = New SqlServer.OrdenesProduccionMRPProductos(da).ObtieneListaNecesariosP(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                                                                     idProcesoProductivo.Value, False, idProducto)
                  For Each drMRP In dtMRP.AsEnumerable()
                     Dim drComponente = _dtComponentes.NewRow()
                     drComponente("IdSucursal") = idSucursal
                     drComponente("IdTipoComprobante") = idTipoComprobante
                     drComponente("Letra") = letra
                     drComponente("CentroEmisor") = centroEmisor
                     drComponente("NumeroOrdenProduccion") = numeroOrdenProduccion
                     drComponente("Orden") = orden
                     drComponente("IdProducto") = idProducto
                     drComponente("NombreProducto") = nombreProducto

                     drComponente("IdEstado") = drDetalle.Field(Of String)("IdEstado")

                     drComponente.SetField("IdFormula", idFormula)
                     drComponente.SetField("IdProcesoProductivo", idProcesoProductivo)

                     Dim idProductoComponente = drMRP.Field(Of String)(Entidades.MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString())
                     drComponente("IdProductoComponente") = idProductoComponente
                     drComponente("NombreProductoComponente") = drDetalle.Field(Of String)("NombreProducto")

                     Dim productoComp = rProducto.GetUnoParaM(idProductoComponente)

                     drComponente("Producto") = productoComp

                     drComponente("IdDepositoDefecto") = productoComp.IdDepositoDefecto
                     drComponente("IdUbicacionDefecto") = productoComp.IdUbicacionDefecto
                     drComponente("NombreDepositoDefecto") = productoComp.NombreDepositoDefecto
                     drComponente("NombreUbicacionDefecto") = productoComp.NombreUbicacionDefecto

                     Dim cantidadSolicitada = drMRP.Field(Of Decimal)("CantidadSolicitada")

                     drComponente("ProductoFormula") = New Entidades.ProduccionProductoComp() With {
                                                            .IdProducto = idProducto,
                                                            .IdProductoElaborado = idProducto,
                                                            .IdUnicoNodoProductoElaborado = Guid.NewGuid().ToString(),
                                                            .IdProductoComponente = productoComp.IdProducto,
                                                            .IdUnicoNodoProductoComponente = Guid.NewGuid().ToString(),
                                                            .SecuenciaFormula = 0,
                                                            .IdFormula = 0,
                                                            .NombreProductoElaborado = nombreProducto,
                                                            .NombreProductoComponente = productoComp.NombreProducto,
                                                            .NombreFormula = String.Empty,
                                                            .PrecioCosto = 0,
                                                            .PrecioVenta = 0,
                                                            .Cantidad = cantidadSolicitada * drDetalle.Field(Of Decimal?)("CantidadNuevoEstado").IfNull(),
                                                            .CantidadEnFormula = cantidadSolicitada * drDetalle.Field(Of Decimal?)("CantidadNuevoEstado").IfNull(),
                                                            .SegunCalculoForma = False,
                                                            .ImporteCosto = 0,
                                                            .ImporteVenta = 0,
                                                            .FormulaCalculoKilaje = String.Empty,
                                                            .IdMoneda = productoComp.IdMoneda,
                                                            .NombreProducto = nombreProducto,
                                                            .IdDepositoDefecto = productoComp.IdDepositoDefecto,
                                                            .IdUbicacionDefecto = productoComp.IdUbicacionDefecto
                        }

                     _dtComponentes.Rows.Add(drComponente)


                     drComponente.SumField("CantidadFormula", cantidadSolicitada * drDetalle.Field(Of Decimal?)("CantidadNuevoEstado").IfNull())
                     drComponente.SumField("CantidadNuevoEstado", cantidadSolicitada * drDetalle.Field(Of Decimal?)("CantidadNuevoEstado").IfNull())

                     If Not _ubicacionesComponentes.ContainsKey(drComponente) Then
                        _ubicacionesComponentes.Add(drComponente, New List(Of Entidades.SeleccionMultipleUbicaciones)())
                     End If
                     If Not _ubicacionesComponentesDetalle.ContainsKey(drComponente) Then
                        _ubicacionesComponentesDetalle.Add(drComponente, New List(Of Entidades.SeleccionMultipleUbicaciones)())
                     End If
                  Next

               End Using
            End If
         End If

      Next

      _dsDetalle.AddRelation(AdminV2_DetalleProducto_DetalleComponentes_RelationName, {"IdSucursal", "IdTipoComprobante", "Letra", "CentroEmisor", "NumeroOrdenProduccion", "Orden", "IdProducto"})

      Return New Tuple(Of DataSet,
                          Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                          Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                          Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones))) _
                      (_dsDetalle, _ubicaciones, _ubicacionesComponentes, _ubicacionesComponentesDetalle)
   End Function

   Public Sub ActualizarEstadoOrdenProduccionMasivo(cambioEstado As Entidades.OrdenesProduccionAdminCambioEstado, idFuncion As String)
      EjecutaConTransaccion(Sub() _ActualizarEstadoOrdenProduccionMasivo(cambioEstado, idFuncion))
   End Sub


   Private Shared Sub ValidarActualizarEstadoOrdenProduccionMasivo(cambioEstado As Entidades.OrdenesProduccionAdminCambioEstado, cache As BusquedasCacheadas, da As Datos.DataAccess)
      Dim rOPE = New OrdenesProduccionEstados(da)

      Using errBuilder = New Entidades.ErrorBuilder()
         If cambioEstado.EstadoDestino Is Nothing Then
            errBuilder.AddError("El Estado destino no puede ser Nulo")
         Else
            If Not cache.ExisteEstadosOrdenesProduccion(cambioEstado.EstadoDestino.IdEstado) Then
               errBuilder.AddError("No existe el Estado destino {0}", cambioEstado.EstadoDestino.IdEstado)
            End If
         End If
         If Not cache.ExisteUsuario(cambioEstado.IdUsuario) Then
            errBuilder.AddError("El usuario '{0}' no puede existe", cambioEstado.IdUsuario)
         End If

         For Each oc In cambioEstado.Pedidos
            If Not rOPE.Get1(oc.IdSucursal, oc.IdTipoComprobante, oc.Letra, oc.CentroEmisor, oc.NumeroPedido, oc.Orden, oc.IdProducto, oc.FechaEstado).Any() Then
               errBuilder.AddError("{0}: el pedido no existe", oc.PkToString())
            End If
            If Not cache.ExisteProductoPorIdRapido(oc.IdProducto) Then
               errBuilder.AddError("{0}: el producto '{1}' no existe", oc.PkToString(), oc.IdProducto)
            End If
            If oc.EstadoActual Is Nothing Then
               errBuilder.AddError("{0}: El Estado actual no puede ser Nulo", oc.PkToString())
            Else
               If Not cache.ExisteEstadosOrdenesProduccion(oc.EstadoActual.IdEstado) Then
                  errBuilder.AddError("{0}: No existe el Estado actual {1}", oc.PkToString(), oc.EstadoActual.IdEstado)
               End If
            End If
            If oc.Cantidad = 0 Then
               errBuilder.AddError("{0}: no puede tener cantidad 0", oc.PkToString())
            End If
            'IdCriticidad Validar existencia
            If Not cache.ExisteCriticidadesOrdenesProduccion(oc.IdCriticidad) Then
               errBuilder.AddError("{0}: No existe el Criticidad con Id {1}", oc.PkToString(), oc.IdCriticidad)
            End If
            If Not cache.ExisteEmpleado(oc.IdResponsable) Then
               errBuilder.AddError("{0}: el Responsable con Id {1} no existe", oc.PkToString(), oc.IdResponsable)
            End If

            Dim tipoComprobanteFact = cache.BuscaTipoComprobante(cambioEstado.EstadoDestino.IdTipoComprobante)
            If cambioEstado.EstadoDestino IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cambioEstado.EstadoDestino.IdTipoComprobante) Then
               If tipoComprobanteFact IsNot Nothing AndAlso tipoComprobanteFact.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() Then
                  If Not cache.ExisteClientePorIdRapido(oc.IdClienteProveedor) Then
                     errBuilder.AddError("{0}: cuando el estado destino genera un {1} y el cliente con Id {2} no existe", oc.PkToString(), tipoComprobanteFact.IdTipoComprobante, oc.IdClienteProveedor)
                  End If
               End If
            End If

            Dim coeficienteStock As Integer = 0
            Dim coeficienteStockComp As Integer = 0
            Dim solicitaInformeCalidad As Boolean = False

            If tipoComprobanteFact IsNot Nothing Then
               coeficienteStock = tipoComprobanteFact.CoeficienteStock
               coeficienteStockComp = tipoComprobanteFact.CoeficienteStock
               solicitaInformeCalidad = tipoComprobanteFact.SolicitaInformeCalidad
            Else
               If Not oc.EstadoActual.ReservaMateriaPrima And cambioEstado.EstadoDestino.ReservaMateriaPrima Then
                  coeficienteStock = -1
                  coeficienteStockComp = -1
               ElseIf oc.EstadoActual.ReservaMateriaPrima And Not cambioEstado.EstadoDestino.ReservaMateriaPrima Then
                  coeficienteStock = 1
                  coeficienteStockComp = 1
               Else
                  If cambioEstado.EstadoDestino.GeneraProductoTerminado Then
                     coeficienteStock = 1
                     coeficienteStockComp = -1
                  End If
               End If
            End If

            If coeficienteStock <> 0 Then
               ValidarUbicaciones(oc.Producto, oc.Cantidad, coeficienteStock, solicitaInformeCalidad, oc.PkToString(), oc.Ubicaciones, cache, errBuilder, da)

               For Each comp In oc.Componentes
                  ValidarUbicaciones(comp.Producto, comp.Cantidad, coeficienteStockComp, solicitaInformeCalidad, oc.PkToString(), comp.Ubicaciones, cache, errBuilder, da)
               Next
            End If

            'Validad componentes
         Next

         If errBuilder.AnyError() Then
            Throw New Exception(errBuilder.ErrorToString())
         End If
      End Using
   End Sub
   Private Shared Sub ValidarUbicaciones(producto As Entidades.ProductoLivianoParaImportarProducto, cantidadTotal As Decimal, coeficienteStock As Integer, solicitaInformeCalidad As Boolean,
                                         pkPedido As String, ubicaciones As List(Of Entidades.SeleccionMultipleUbicaciones), cache As BusquedasCacheadas, errBuilder As Entidades.ErrorBuilder,
                                         da As Datos.DataAccess)
      Dim rPU = New ProductosUbicaciones(da)
      Dim rPLote = New ProductosLotes(da)

      Dim cantidadUbicacion = ubicaciones.SumSecure(Function(u) u.Cantidad)
      'Verifico que la cantidad ingresada en todas las ubicaciones sea igual a la cantidad que se está queriendo cambiar de estado
      If cantidadUbicacion <> cantidadTotal Then
         errBuilder.AddError("{0}: La cantidad en Ubicaciones debe ser igual a la cantidad necesario. Ubicaciones {1} / Necesario {2}", pkPedido, cantidadUbicacion, cantidadTotal)
      Else
         'Para cada ubicación de manera individual
         For Each u In ubicaciones
            'Controlo que, si el producto UTILIZA LOTE, la suma de los lotes sea igual a la cantidad indicada en la ubicación
            If producto.Lote Then
               If u.Lotes.SumSecure(Function(l) l.Cantidad).IfNull() <> u.Cantidad Then
                  errBuilder.AddError("{0}: La cantidad total de lotes seleccionados para la ubicación {1} debe ser igual a la cantidad de la ubicación", pkPedido, u.DisplayMember)
               End If
            End If

            'Controlo que, si el producto UTILIZA NRO SERIE, se hayan cargado tantos Nros de Serie como la cantidad indicada en la ubicación
            If producto.NroSerie Then
               If u.NrosSerie.SumSecure(Function(ns) ns.Cantidad).IfNull() <> u.Cantidad Then
                  errBuilder.AddError("{0}: La cantidad total de Nro. Serie seleccionados para la ubicación {1} debe ser igual a la cantidad de la ubicación", pkPedido, u.DisplayMember)
               End If
            End If

            'Revisar control de stock para que controle más de un producto en diferentes pedidos

            '''''''''STOCK
            '''''''''Si el coeficiente de stock es negativo (saca mercadería del sistema) debo controla si tengo stock suficiente (si aplica el control)
            ''''''''If coeficienteStock = -1 Then
            ''''''''   'La cantidad debe haber sigo ingresada Positiva (+). Si se puso negativo o cero está mal cargado
            ''''''''   If u.Cantidad <= 0 Then
            ''''''''      errBuilder.AddError("{0}: La cantidad de {1} no puede ser cero o negativo", pkPedido, u.DisplayMember)
            ''''''''   End If
            ''''''''   'Si no permito en facturación que el stock quede negativo, cuando realizo una salida de mercadería de compras tampoco debería permitirlo
            ''''''''   If Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            ''''''''      'Busco el stock del Dep/Ubic para dicho producto
            ''''''''      Dim pu = rPU.GetUno(u.IdProducto, u.IdSucursal, u.IdDeposito, u.IdUbicacion)
            ''''''''      'Si se quiebra el stock (el Stock es menor a la cantidad a mover) damos error
            ''''''''      If pu.Stock < u.Cantidad Then
            ''''''''         errBuilder.AddError("{0}: El {1} no tiene stock suficiente", pkPedido, u.DisplayMember)
            ''''''''      End If
            ''''''''   End If

            ''''''''   If producto.Lote Then
            ''''''''      If u.Lotes.SumSecure(Function(l) l.Cantidad) <> u.Cantidad Then
            ''''''''         errBuilder.AddError("{0}: La total cantidad de lotes seleccionados para la ubicación {1} debe ser igual a la cantidad de la ubicación", pkPedido, u.DisplayMember)
            ''''''''      End If

            ''''''''      '''''For Each l In u.Lotes
            ''''''''      '''''   If l.Cantidad > l.Stock Then
            ''''''''      '''''      errBuilder.AddError("{0}: El Lote {1} de la {2} no tiene stock suficiente", pkPedido, l.IdLote, u.DisplayMember)
            ''''''''      '''''   End If
            ''''''''      '''''   If solicitaInformeCalidad Then
            ''''''''      '''''      If String.IsNullOrWhiteSpace(l.InformeCalidadLink) Then
            ''''''''      '''''         errBuilder.AddError("{0}: El Lote {1} de la {2} no tiene Link al Informe de Calidad el cual es requerido", pkPedido, l.IdLote, u.DisplayMember)
            ''''''''      '''''      End If
            ''''''''      '''''      If String.IsNullOrWhiteSpace(l.InformeCalidadNumero) Then
            ''''''''      '''''         errBuilder.AddError("{0}: El Lote {1} de la {2} no tiene Número de Informe de Calidad el cual es requerido", pkPedido, l.IdLote, u.DisplayMember)
            ''''''''      '''''      End If
            ''''''''      '''''   End If
            ''''''''      '''''Next
            ''''''''   End If
            ''''''''End If
            ''''''''If producto.NroSerie Then
            ''''''''   If coeficienteStock < -1 Then

            ''''''''   Else
            ''''''''   End If
            ''''''''End If
         Next
      End If
   End Sub

   Public Sub _ActualizarEstadoOrdenProduccionMasivo(cambioEstado As Entidades.OrdenesProduccionAdminCambioEstado, idFuncion As String)

      ValidarActualizarEstadoOrdenProduccionMasivo(cambioEstado, _cache, da)

      Dim fechaNuevoEstado = Date.Now
      Dim dicVentasAGenerar = New Dictionary(Of Entidades.PedProvAdminClaveGenerar, List(Of Entidades.OrdenesProduccionAdminPedidos))()
      Dim idFormaDePagoCtaCte = New VentasFormasPago(da).GetUna("VENTAS", False).IdFormasPago

      Dim sqlEOP = New SqlServer.EstadosOrdenesProduccion(da)
      For Each filaGrabar In cambioEstado.Pedidos.OfType(Of Entidades.OrdenesProduccionAdminPedidos) ' tablagrabar.Rows

         Dim rPP = New OrdenesProduccionProductos(da)
         Dim sqlPE = New SqlServer.OrdenesProduccionEstados(da)

         Dim opeOriginal = GetUno(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                  filaGrabar.Orden, filaGrabar.Producto.IdProducto, filaGrabar.FechaEstado)
         Dim oppOriginal = rPP.GetUno(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                      filaGrabar.Orden, filaGrabar.Producto.IdProducto)

         If opeOriginal.CantEstado = filaGrabar.Cantidad Then
            sqlPE.OrdenesProduccionEstados_U_Estado(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                    filaGrabar.Producto.IdProducto, filaGrabar.FechaEstado,
                                                    cambioEstado.EstadoDestino.IdEstado,
                                                    filaGrabar.Cantidad,
                                                    fechaNuevoEstado,
                                                    cambioEstado.Observaciones,
                                                    filaGrabar.Orden,
                                                    filaGrabar.IdCriticidad,
                                                    filaGrabar.FechaEntrega,
                                                    filaGrabar.NumeroReparto,
                                                    filaGrabar.IdResponsable,
                                                    filaGrabar.PlanMaestroNumero, filaGrabar.PlanMaestroFecha)
         Else
            sqlPE.OrdenesProduccionEstados_I(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                             filaGrabar.Producto.IdProducto, fechaNuevoEstado,
                                             cambioEstado.EstadoDestino.IdEstado,
                                             cambioEstado.IdUsuario,
                                             cambioEstado.Observaciones,
                                             filaGrabar.Cantidad, idTipoComprobanteFact:=String.Empty, letraFact:=String.Empty, centroEmisorFact:=0, numeroComprobanteFact:=0,
                                             filaGrabar.Orden,
                                             filaGrabar.IdCriticidad,
                                             filaGrabar.FechaEntrega,
                                             filaGrabar.NumeroReparto,
                                             opeOriginal.IdFormula,
                                             filaGrabar.IdResponsable,
                                             filaGrabar.PlanMaestroNumero, filaGrabar.PlanMaestroFecha)
            sqlPE.OrdenesProduccionEstados_U_Cantidad(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                      filaGrabar.Producto.IdProducto, filaGrabar.Orden, filaGrabar.FechaEstado,
                                                      filaGrabar.Cantidad * -1)
         End If
         rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                         filaGrabar.Producto.IdProducto, filaGrabar.Orden,
                                                         filaGrabar.EstadoActual.IdEstado, cambioEstado.EstadoDestino.IdTipoEstado, filaGrabar.Cantidad)

         If Not cambioEstado.EstadoDestino.GeneraProductoTerminado Then
            ReservaMateriaPrima(filaGrabar, filaGrabar.EstadoActual, cambioEstado.EstadoDestino, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
         End If
         GeneraProductoTerminado(filaGrabar, opeOriginal, oppOriginal, filaGrabar.EstadoActual, cambioEstado.EstadoDestino, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

         ActualizaPedidoOrigen(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                               filaGrabar.Producto.IdProducto, filaGrabar.Orden,
                               filaGrabar.EstadoActual.IdEstado, cambioEstado.EstadoDestino.IdEstado, filaGrabar.Cantidad, filaGrabar.IdResponsable, idFuncion)

         If Not String.IsNullOrEmpty(cambioEstado.EstadoDestino.IdTipoComprobante) Then
            Dim tipoComprobanteFact = _cache.BuscaTipoComprobante(cambioEstado.EstadoDestino.IdTipoComprobante)

            If tipoComprobanteFact.Tipo = Entidades.TipoComprobante.Tipos.VENTAS.ToString() Then
               Dim clave = New Entidades.PedProvAdminClaveGenerar(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
                                                                  filaGrabar.IdSucursal, tipoComprobanteFact.IdTipoComprobante, filaGrabar.IdClienteProveedor, filaGrabar.DescRecPorcGral)
               If Not dicVentasAGenerar.ContainsKey(clave) Then
                  dicVentasAGenerar.Add(clave, New List(Of Entidades.OrdenesProduccionAdminPedidos))
               End If
               dicVentasAGenerar(clave).Add(filaGrabar)
            End If
         End If
         fechaNuevoEstado = fechaNuevoEstado.AddSeconds(1)
      Next

      If Not String.IsNullOrEmpty(cambioEstado.EstadoDestino.IdTipoComprobante) Then
         CrearVentaDesdePedido(dicVentasAGenerar, fechaNuevoEstado, idFuncion)
      End If
   End Sub

   Private Sub CrearVentaDesdePedido(dicVentasAGenerar As Dictionary(Of Entidades.PedProvAdminClaveGenerar, List(Of Entidades.OrdenesProduccionAdminPedidos)),
                                     fechaNuevoEstado As Date, idFuncion As String)

      Dim rVentas = New Ventas(da, _cache)

      For Each valores In dicVentasAGenerar
         Dim clave = valores.Key
         Dim cliente = _cache.BuscaClienteEntidadPorId(clave.IdProveedor)
         Dim observacion = String.Format("Generado por Cambio de Estado de: {0} {1} {2:0000}-{3:00000000}",
                                         clave.IdTipoComprobante, clave.Letra, clave.CentroEmisor, clave.NumeroPedido).Truncar(100)

         Dim venta = rVentas.CreaVenta(clave.IdSucursal, _cache.BuscaTipoComprobante(clave.IdTipoComprobanteDestino),
                                       cliente, DescuentoRecargoPorc:=Nothing, observacion, idCaja:=0)
         venta.Fecha = fechaNuevoEstado

         For Each filaGrabar In valores.Value
            Dim producto = _cache.BuscaProductoEntidadPorId(filaGrabar.Producto.IdProducto)
            For Each u In filaGrabar.Ubicaciones
               Dim vp = rVentas.CreaVentaProducto(producto, producto.NombreProducto, descuentoRecargoPorc1:=0, descuentoRecargoPorc2:=0, filaGrabar.Precio,
                                                  u.Cantidad, _cache.BuscaTiposImpuestos(producto.IdTipoImpuesto), porcentajeIva:=Nothing,
                                                  listaDePrecios:=Nothing, fechaEntrega:=filaGrabar.FechaEntrega, tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL,
                                                  nota:=String.Empty, idEstadoVenta:=Nothing, venta, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
               vp.IdDeposito = u.IdDeposito
               vp.IdUbicacion = u.IdUbicacion
               vp.VentasProductosLotes = u.Lotes.ConvertAll(Function(l) New Entidades.VentaProductoLote() With {
                                                            .IdLote = l.IdLote,
                                                            .FechaVencimiento = l.FechaVencimiento,
                                                            .Cantidad = l.Cantidad
                                                         })
               vp.Producto.NrosSeries = u.NrosSerie.ConvertAll(Function(ns) New Entidades.ProductoNroSerie() With {
                                                               .NroSerie = ns.NroSerie
                                                            })
               rVentas.AgregarVentaProducto(venta, vp, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
            Next

         Next

         rVentas.Inserta(venta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
      Next
   End Sub

   Public Function ConvertirACambioEstado(dt As DataTable,
                                          _ubicaciones As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                          _ubicacionesComponentes As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                          _ubicacionesComponentesDestino As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                          _tipoTipoComprobante As String, idEstado As String,
                                          observaciones As String) As Entidades.OrdenesProduccionAdminCambioEstado
      Return EjecutaConConexion(Function() _ConvertirACambioEstado(dt, _ubicaciones, _ubicacionesComponentes, _ubicacionesComponentesDestino, _tipoTipoComprobante, idEstado, observaciones))
   End Function

   Private Function _ConvertirACambioEstado(dt As DataTable,
                                            _ubicaciones As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                            _ubicacionesComponentes As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                            _ubicacionesComponentesDestino As Dictionary(Of DataRow, List(Of Entidades.SeleccionMultipleUbicaciones)),
                                            _tipoTipoComprobante As String, idEstado As String,
                                            observaciones As String) As Entidades.OrdenesProduccionAdminCambioEstado
      Dim rUbic = New SucursalesUbicaciones(da)
      Dim cambioEstado = New Entidades.OrdenesProduccionAdminCambioEstado(_cache.BuscaEstadosOrdenesProduccion(idEstado)) With
               {
                  .Observaciones = observaciones
               }

      Dim rProductos = New Productos(da)

      For Each dr In dt.AsEnumerable()
         Dim pedido = New Entidades.OrdenesProduccionAdminPedidos(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("DescripcionTipoComprobante"),
                                                                  dr.Field(Of String)("Letra"), dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Integer)("NumeroOrdenProduccion"),
                                                                  dr.Field(Of Integer)("Orden"), dr.Field(Of Date)("FechaEstado"),
                                                                  rProductos._GetUnoParaM(dr.Field(Of String)("IdProducto"))) With
                      {
                         .FechaPedido = dr.Field(Of Date)("FechaOrdenProduccion"),
                         .IdClienteProveedor = dr.Field(Of Long)("IdCliente"),
                         .FechaEntrega = dr.Field(Of Date)("FechaEntrega"),
                         .EstadoActual = _cache.BuscaEstadosOrdenesProduccion(dr.Field(Of String)("IdEstado")),
                         .Cantidad = dr.Field(Of Decimal)("CantidadNuevoEstado"),
                         .Precio = dr.Field(Of Decimal)("Precio"),
                         .IdCriticidad = dr.Field(Of String)("IdCriticidad"),
                         .IdResponsable = dr.Field(Of Integer)("IdResponsable"),
                         .NumeroReparto = 0,
                         .Ubicaciones = _ubicaciones(dr),
                         .PlanMaestroNumero = dr.Field(Of Integer?)("PlanMaestroNumero"),
                         .PlanMaestroFecha = dr.Field(Of Date?)("PlanMaestroFecha")
                      }
         If Not pedido.Ubicaciones.AnySecure() Then
            pedido.Ubicaciones.Add(New Entidades.SeleccionMultipleUbicaciones() With {
                                       .Producto = pedido.Producto,
                                       .Cantidad = pedido.Cantidad,
                                       .Ubicacion = rUbic.GetUno(dr.Field(Of Integer)("IdDepositoDefecto"), dr.Field(Of Integer)("IdSucursal"), dr.Field(Of Integer)("IdUbicacionDefecto"),
                                                                 AccionesSiNoExisteRegistro.Excepcion)
                                   })
         End If

         For Each drComponentes In dr.GetChildRows(AdminV2_DetalleProducto_DetalleComponentes_RelationName)
            Dim compo = New Entidades.AdminCambioEstadoComponentes() With {
                              .Producto = rProductos._GetUnoParaM(drComponentes.Field(Of String)("IdProductoComponente")),
                              .Cantidad = drComponentes.Field(Of Decimal)("CantidadNuevoEstado"),
                              .Ubicaciones = _ubicacionesComponentes(drComponentes),
                              .ProductoComponente = drComponentes.Field(Of Entidades.ProduccionProductoComp)("ProductoFormula")
                           }

            If Not compo.Ubicaciones.AnySecure() Then
               Dim u = New Entidades.SeleccionMultipleUbicaciones() With {
                                       .Producto = compo.Producto,
                                       .Cantidad = compo.Cantidad,
                                       .Ubicacion = rUbic.GetUno(drComponentes.Field(Of Integer)("IdDepositoDefecto"), drComponentes.Field(Of Integer)("IdSucursal"), drComponentes.Field(Of Integer)("IdUbicacionDefecto"),
                                                                 AccionesSiNoExisteRegistro.Excepcion)
                                   }
               If pedido.EstadoActual.EvaluaReserva(cambioEstado.EstadoDestino) = Entidades.TipoReservaStock.DesReserva Then
                  u.Ubicacion = rUbic.GetUno(pedido.EstadoActual.IdDeposito, pedido.EstadoActual.IdSucursal, pedido.EstadoActual.IdUbicacion, AccionesSiNoExisteRegistro.Excepcion)
               End If
               compo.Ubicaciones.Add(u)
            End If

            If _ubicacionesComponentesDestino(drComponentes).AnySecure() Then
               compo.UbicacionDestino = _ubicacionesComponentesDestino(drComponentes).First().Ubicacion
            End If
            If compo.UbicacionDestino Is Nothing Then
               compo.UbicacionDestino = rUbic.GetUno(drComponentes.Field(Of Integer)("IdDepositoDefecto"), drComponentes.Field(Of Integer)("IdSucursal"), drComponentes.Field(Of Integer)("IdUbicacionDefecto"),
                                                     AccionesSiNoExisteRegistro.Excepcion)
            End If
            pedido.Componentes.Add(compo)
         Next

         cambioEstado.Pedidos.Add(pedido)
      Next

      Return cambioEstado
   End Function



   Public Sub ReservaMateriaPrima(filaGrabar As Entidades.OrdenesProduccionAdminPedidos,
                                  estadoAnterior As Entidades.EstadoOrdenProduccion, estadoNuevo As Entidades.EstadoOrdenProduccion,
                                  metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      'Solo debo realizar movimientos de Stock->Reservado y de Reservado->Stock si difieren en la propiedad ReservaMateriaPrima.
      'Si es igual esta propiedad significa que no cambian de un lado a otro las cantidades.
      If estadoAnterior.ReservaMateriaPrima <> estadoNuevo.ReservaMateriaPrima Then
         Dim esReserva = Not estadoAnterior.ReservaMateriaPrima And estadoNuevo.ReservaMateriaPrima

         'Si el estado actual NO reserva MP (PENDIENTE) y el nuevo SI lo hace (EN PROCESO) el coeficiente es NEGATIVO, porque se descuenta MP de Stock.
         'Si el estado actual SI reserva MP (EN PROCESO) y el nuevo NO lo hace (FINALIZADO) el coeficiente es POSITIVO, porque se incrementa MP de Stock.
         Dim coeficienteStock = -1  ''If(esReserva, -1I, 1I)
         'El movimiento de reserva tomará este coeficiente y lo multiplicará por -1 para así saber si tiene que sumar o restar en StockReservado.

         'Busco el Tipo de Movimiento que tiene el tilde en Reserva Mercaderia
         Dim tipoMovimiento = _cache.BuscaTipoMovimientoReservaMercaderia()
         If tipoMovimiento Is Nothing Then
            Throw New Exception("No está definido ningún Tipo de Movimiento con el tilde en Reserva de Mercadería. Verifique y reintente.")
         End If

         'Instancio el Movimiento de Compra poniendo en la Observacion el motivo de la reserva.
         Dim movi = New Entidades.MovimientoStock() With {
               .IdSucursal = actual.Sucursal.Id,
               .Sucursal = actual.Sucursal,
               .TipoMovimiento = tipoMovimiento,
               .FechaMovimiento = Now,
               .Usuario = actual.Nombre,
               .Observacion = String.Format("Reserva de mercadería por: {0} {1} {2:0000}-{3:00000000} Ln: {4}",
                                            filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido, filaGrabar.Orden)
            }

         Dim ordenMovimiento As Integer = 1
         For Each drComposicion In filaGrabar.Componentes ' dtComposicion.AsEnumerable()

            For Each ubic In drComposicion.Ubicaciones
               Dim idDepositoOrigen = If(esReserva, ubic.IdDeposito, estadoAnterior.IdDeposito)
               Dim idUbicacionOrigen = If(esReserva, ubic.IdUbicacion, estadoAnterior.IdUbicacion)

               If Not ubic.Lotes.AnySecure() Then
                  ubic.Lotes.Add(New Entidades.SeleccionMultipleLotes() With {
                                       .UbicacionAdmin = ubic,
                                       .IdLote = String.Empty,
                                       .Cantidad = ubic.Cantidad
                                    })
               End If

               For Each l In ubic.Lotes
                  'Detalles de Origen
                  Dim moviProd = New Entidades.MovimientoStockProducto With {
                     .IdSucursal = actual.Sucursal.Id,
                     .IdProducto = drComposicion.Producto.IdProducto,
                     .IdDeposito = idDepositoOrigen,
                     .IdUbicacion = idUbicacionOrigen,
                     .IdLote = l.IdLote,
                     .Cantidad = l.Cantidad * coeficienteStock,
                     .Orden = ordenMovimiento
                   }
                  If Not String.IsNullOrWhiteSpace(l.IdLote) Then
                     Dim prodLote = New Entidades.ProductoLote() With {
                                          .IdSucursal = l.IdSucursal,
                                          .IdDeposito = idDepositoOrigen,
                                          .IdUbicacion = idUbicacionOrigen,
                                          .IdLote = l.IdLote,
                                          .CantidadActual = l.Cantidad * coeficienteStock,
                                          .CantidadInicial = l.Cantidad * coeficienteStock,
                                          .Habilitado = True,
                                          .FechaIngreso = Date.Now,
                                          .FechaVencimiento = l.FechaVencimiento
                                       }
                     prodLote.ProductoSucursal.Producto.IdProducto = l.Producto.IdProducto
                     prodLote.ProductoSucursal.IdSucursal = l.IdSucursal
                     prodLote.ProductoSucursal.Sucursal.IdSucursal = l.IdSucursal
                     movi.ProductosLotes.Add(prodLote)
                  End If
                  moviProd.ProductosNrosSerie.AddRange(ubic.NrosSerie.
                                    ConvertAll(Function(ns)
                                                  Return New Entidades.MovimientoStockProductoNrosSerie With {
                                                               .IdProducto = ns.IdProducto,
                                                               .IdSucursal = ns.IdSucursal,
                                                               .IdDeposito = idDepositoOrigen,
                                                               .IdUbicacion = idUbicacionOrigen,
                                                               .NroSerie = ns.NroSerie,
                                                               .Cantidad = coeficienteStock
                                                         }
                                               End Function))
                  moviProd.ProductoSucursal.Producto.NrosSeries = ubic.NrosSerie.
                                    ConvertAll(Function(ns)
                                                  Return New Entidades.ProductoNroSerie With {
                                                               .Producto = New Entidades.Producto() With {.IdProducto = ns.IdProducto},
                                                               .IdSucursal = ns.IdSucursal,
                                                               .Sucursal = New Entidades.Sucursal() With {.IdSucursal = ns.IdSucursal},
                                                               .IdDeposito = idDepositoOrigen,
                                                               .IdUbicacion = idUbicacionOrigen,
                                                               .NroSerie = ns.NroSerie
                                                         }
                                               End Function)
                  ordenMovimiento += 1
                  movi.Productos.Add(moviProd)
               Next
               movi.ProductosNrosSerie.AddRange(ubic.NrosSerie.ConvertAll(Function(ns)
                                                                             Dim r = New Entidades.ProductoNroSerie() With {
                                                                                            .IdSucursal = ns.IdSucursal,
                                                                                            .IdDeposito = idDepositoOrigen,
                                                                                            .IdUbicacion = idUbicacionOrigen,
                                                                                            .NroSerie = ns.NroSerie
                                                                                         }
                                                                             r.Producto.IdProducto = ns.IdProducto
                                                                             Return r
                                                                          End Function))

               'Detalles de Destino
               Dim idDepositoDestino = If(esReserva, estadoNuevo.IdDeposito, drComposicion.UbicacionDestino.IdDeposito)
               Dim idUbicacionDestino = If(esReserva, estadoNuevo.IdUbicacion, drComposicion.UbicacionDestino.IdUbicacion)

               For Each l In ubic.Lotes

                  Dim moviProd = New Entidades.MovimientoStockProducto With {
                        .IdSucursal = actual.Sucursal.Id,
                        .IdProducto = drComposicion.Producto.IdProducto,
                        .IdDeposito = idDepositoDestino,
                        .IdUbicacion = idUbicacionDestino,
                        .IdLote = l.IdLote,
                        .Cantidad = l.Cantidad * coeficienteStock * -1,
                        .Orden = ordenMovimiento
                      }
                  If Not String.IsNullOrWhiteSpace(l.IdLote) Then
                     Dim prodLote = New Entidades.ProductoLote() With {
                                          .IdSucursal = l.IdSucursal,
                                          .IdDeposito = idDepositoDestino,
                                          .IdUbicacion = idUbicacionDestino,
                                          .IdLote = l.IdLote,
                                          .CantidadActual = l.Cantidad * coeficienteStock * -1,
                                          .CantidadInicial = l.Cantidad * coeficienteStock * -1,
                                          .Habilitado = True,
                                          .FechaIngreso = Date.Now,
                                          .FechaVencimiento = l.FechaVencimiento
                                       }
                     prodLote.ProductoSucursal.Producto.IdProducto = l.Producto.IdProducto
                     prodLote.ProductoSucursal.IdSucursal = l.IdSucursal
                     prodLote.ProductoSucursal.Sucursal.IdSucursal = l.IdSucursal
                     movi.ProductosLotes.Add(prodLote)
                  End If
                  moviProd.ProductosNrosSerie.AddRange(ubic.NrosSerie.
                                    ConvertAll(Function(ns)
                                                  Return New Entidades.MovimientoStockProductoNrosSerie With {
                                                               .IdProducto = ns.IdProducto,
                                                               .IdSucursal = ns.IdSucursal,
                                                               .IdDeposito = idDepositoDestino,
                                                               .IdUbicacion = idUbicacionDestino,
                                                               .NroSerie = ns.NroSerie,
                                                               .Cantidad = coeficienteStock * -1
                                                         }
                                               End Function))
                  moviProd.ProductoSucursal.Producto.NrosSeries = ubic.NrosSerie.
                                    ConvertAll(Function(ns)
                                                  Return New Entidades.ProductoNroSerie With {
                                                               .Producto = New Entidades.Producto() With {.IdProducto = ns.IdProducto},
                                                               .IdSucursal = ns.IdSucursal,
                                                               .Sucursal = New Entidades.Sucursal() With {.IdSucursal = ns.IdSucursal},
                                                               .IdDeposito = idDepositoDestino,
                                                               .IdUbicacion = idUbicacionDestino,
                                                               .NroSerie = ns.NroSerie
                                                         }
                                               End Function)
                  ordenMovimiento += 1
                  movi.Productos.Add(moviProd)
               Next
               movi.ProductosNrosSerie.AddRange(ubic.NrosSerie.ConvertAll(Function(ns)
                                                                             Dim r = New Entidades.ProductoNroSerie() With {
                                                                                 .IdSucursal = ns.IdSucursal,
                                                                                 .IdDeposito = idDepositoDestino,
                                                                                 .IdUbicacion = idUbicacionDestino,
                                                                                 .NroSerie = ns.NroSerie
                                                                             }
                                                                             r.Producto.IdProducto = ns.IdProducto
                                                                             Return r
                                                                          End Function))
            Next
         Next

         'Grabo el movimiento esperando que el mismo, al estar marcado como Reserva de Mercadería, impacte en StockReservado.
         Dim rMovimientoCompra = New MovimientosStock(da)
         rMovimientoCompra.CargarMovimientoStock(movi, metodoGrabacion, idFuncion)

      End If         'If estadoAnterior.ReservaMateriaPrima <> estadoNuevo.ReservaMateriaPrima Then
   End Sub

   Public Sub GeneraProductoTerminado(filaGrabar As Entidades.OrdenesProduccionAdminPedidos,
                                      opeOriginal As Entidades.OrdenProduccionEstado,
                                      oppOriginal As Entidades.OrdenProduccionProducto,
                                      estadoAnterior As Entidades.EstadoOrdenProduccion, estadoNuevo As Entidades.EstadoOrdenProduccion,
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      'Solo debo generar el Producto Terminado si el estado nuevo GeneraProductoTerminado.
      If estadoNuevo.GeneraProductoTerminado Then
         'Instancio el Movimiento de Compra poniendo en la Observacion el motivo de la reserva.
         Dim prod = New Entidades.Produccion With {
                .IdSucursal = actual.Sucursal.Id,
                .Fecha = Now,
                .Usuario = actual.Nombre,
                .Responsable = New Empleados(da).GetUno(filaGrabar.IdResponsable)
            }

         For Each ubic In filaGrabar.Ubicaciones
            If Not ubic.Lotes.Any Then
               ubic.Lotes.Add(New Entidades.SeleccionMultipleLotes() With {
                                 .IdLote = String.Empty,
                                 .Cantidad = ubic.Cantidad
                              })
            End If
            Dim orden = 0I
            For Each l In ubic.Lotes
               orden += 1
               Dim prodProd = New Entidades.ProduccionProducto With {
                     .IdProducto = filaGrabar.Producto.IdProducto,
                     .IdSucursal = ubic.IdSucursal,
                     .IdFormula = opeOriginal.IdFormula,
                     .IdLote = l.IdLote,
                     .Cantidad = l.Cantidad,
                     .Orden = orden,
                     .Espmm = oppOriginal.Espmm,
                     .LargoExtAlto = oppOriginal.LargoExtAlto,
                     .AnchoIntBase = oppOriginal.AnchoIntBase,
                     .IdDeposito = ubic.IdDeposito,
                     .IdUbicacion = ubic.IdUbicacion
                   }
               If ubic.NrosSerie.AnySecure() Then
                  prodProd.NrosSerie = ubic.NrosSerie.ConvertAll(Function(ns) New Entidades.ProduccionProductoNrosSerie() With {
                                                                                    .NroSerie = ns.NroSerie
                                                                                 })
               End If

               'Dim oppFormula = New OrdenesProduccionProductosFormulas(da).GetTodos(filaGrabar.IdSucursal, filaGrabar.IdTipoComprobante, filaGrabar.Letra, filaGrabar.CentroEmisor, filaGrabar.NumeroPedido,
               '                                                                     filaGrabar.Producto.IdProducto, filaGrabar.Orden, soloMateriaPrima:=True)
               'prodProd.Componentes = New Entidades.FormulaConverter().ConvertirFormulaOPEnProduccion(oppFormula)

               Dim fConverter = New Entidades.FormulaConverter()
               For Each filaGrabarComp In filaGrabar.Componentes
                  For Each u In filaGrabarComp.Ubicaciones
                     Dim ppComp = filaGrabarComp.ProductoComponente.Clonar(filaGrabarComp.ProductoComponente)
                     With ppComp '= New Entidades.ProduccionProductoComp With {
                        '.IdProductoElaborado = filaGrabar.Producto.IdProducto
                        '.IdProductoComponente = filaGrabarComp.Producto.IdProducto
                        .SecuenciaFormula = 0
                        .Cantidad = u.Cantidad
                        .IdSucursal = u.IdSucursal
                        .IdDeposito = u.IdDeposito
                        .IdUbicacion = u.IdUbicacion
                        .IdMoneda = filaGrabarComp.Producto.IdMoneda
                        .Lotes = u.Lotes.ConvertAll(Function(l1) New Entidades.ProduccionProductoCompLote() With {
                                                                           .IdLote = l1.IdLote,
                                                                           .Cantidad = l1.Cantidad
                                                                        })
                        .NrosSerie = u.NrosSerie.ConvertAll(Function(ns1) New Entidades.ProduccionProductoCompNroSerie() With {
                                                                           .NroSerie = ns1.NroSerie
                                                                        })
                     End With '}
                     prodProd.Componentes.Add(ppComp)
                  Next
               Next
               prod.Productos.Add(prodProd)
            Next
         Next

         Dim rProduccion = New Produccion(da)
         rProduccion.GrabarProduccion(prod, Now, _cache)

      End If         'If estadoNuevo.GeneraProductoTerminado Then
   End Sub

   Public Function GetParaAdmin(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                orden As Integer, idProducto As String, fechaEstado As Date?) As List(Of Entidades.OrdenesProduccionAdminPedidos)
      Dim dtPE = Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, fechaEstado)
      Dim result = New List(Of Entidades.OrdenesProduccionAdminPedidos)()
      For Each drPE In dtPE.AsEnumerable()
         Dim producto = New Productos(da)._GetUnoParaM(drPE.Field(Of String)("IdProducto"), AccionesSiNoExisteRegistro.Excepcion)
         result.Add(New Entidades.OrdenesProduccionAdminPedidos(drPE.Field(Of Integer)("IdSucursal"),
                                                                drPE.Field(Of String)("IdTipoComprobante"), drPE.Field(Of String)("DescripcionTipoComprobante"),
                                                                drPE.Field(Of String)("Letra"), drPE.Field(Of Integer)("CentroEmisor"),
                                                                drPE.Field(Of Integer)("NumeroOrdenProduccion"), drPE.Field(Of Integer)("Orden"),
                                                                drPE.Field(Of Date)("FechaEstado"), producto) With {
                           .FechaEntrega = drPE.Field(Of Date)("FechaEntrega"),
                           .EstadoActual = _cache.BuscaEstadosOrdenesProduccion(drPE.Field(Of String)("IdEstado")),
                           .Cantidad = drPE.Field(Of Decimal)("CantEstado"),
                           .IdCriticidad = drPE.Field(Of String)("IdCriticidad"),
                           .NumeroReparto = drPE.Field(Of Integer?)("NumeroReparto").IfNull(),
                           .IdResponsable = drPE.Field(Of Integer?)("IdResponsable").IfNull(),
                           .PlanMaestroNumero = drPE.Field(Of Integer?)("PlanMaestroNumero"),
                           .PlanMaestroFecha = drPE.Field(Of Date?)("PlanMaestroFecha")
                    })
      Next
      Return result
   End Function

End Class
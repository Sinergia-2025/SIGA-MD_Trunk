Partial Class RegistracionPagos

   Private _cache As BusquedasCacheadas
   Private ReadOnly Property Cache() As BusquedasCacheadas
      Get
         If _cache Is Nothing Then _cache = New BusquedasCacheadas()
         Return _cache
      End Get
   End Property

   Private Function GetSql() As SqlServer.RegistracionPagos
      Return New SqlServer.RegistracionPagos(Me.da)
   End Function

#Region "Metodos CargaRegistracionPagos"
   Public Function GetBorrador(idSucursal As Integer, idReparto As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.RepartoCobranza
      Return New Reglas.RepartosCobranzas().GetBorrador(idSucursal, idReparto, accion)
   End Function
   Public Sub CargarRegistracionPagos(ds As Entidades.dtsRegistracionPagosV2,
                                      idSucursal As Integer, numeroReparto As Integer, modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                      fechaDesde As Date?, fechaHasta As Date?,
                                      idDistribucion As Integer, idLocalidad As Integer, idEmpleado As Integer,
                                      idRuta As Integer, dia As Entidades.Publicos.Dias?)
      EjecutaConConexion(Sub() _CargarRegistracionPagos(ds,
                                                        idSucursal, numeroReparto, modoConsultarComprobantes,
                                                        fechaDesde, fechaHasta,
                                                        idDistribucion, idLocalidad, idEmpleado,
                                                        idRuta, dia))
   End Sub
   Private Sub _CargarRegistracionPagos(ds As Entidades.dtsRegistracionPagosV2,
                                        idSucursal As Integer, numeroReparto As Integer, modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                        fechaDesde As Date?, fechaHasta As Date?,
                                        idDistribucion As Integer, idLocalidad As Integer, idEmpleado As Integer,
                                        idRuta As Integer, dia As Entidades.Publicos.Dias?)
      ds.Clear()
      Try
         ds.Comprobantes.Merge(_GetComprobantesRegPagoV2(idSucursal, numeroReparto, modoConsultarComprobantes, fechaDesde, fechaHasta,
                                             idDistribucion, idLocalidad, idEmpleado, idRuta, dia),
                          False, MissingSchemaAction.Ignore)
         ds.Productos.Merge(_GetProductosComprobantesRegPagoV2(idSucursal, numeroReparto, modoConsultarComprobantes, fechaDesde, fechaHasta,
                                                   idDistribucion, idLocalidad, idEmpleado, idRuta, dia),
                            False, MissingSchemaAction.Ignore)

      Finally
         ds.AcceptChanges()
      End Try
   End Sub

   Private Function _GetComprobantesRegPagoV2(idSucursal As Integer, numeroReparto As Integer, modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                              fechaDesde As Date?, fechaHasta As Date?,
                                              idDistribucion As Integer, idLocalidad As Integer, idEmpleado As Integer,
                                              idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Return GetSql().GetComprobantesRegPagoV2(idSucursal, numeroReparto, modoConsultarComprobantes, fechaDesde, fechaHasta, idDistribucion, idLocalidad, idEmpleado, idRuta, dia)
   End Function

   Private Function _GetProductosComprobantesRegPagoV2(idSucursal As Integer, numeroReparto As Integer, modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                                       fechaDesde As Date?, fechaHasta As Date?,
                                                       idDistribucion As Integer, idLocalidad As Integer, idEmpleado As Integer,
                                                       idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Return GetSql().GetProductosComprobantesRegPagoV2(idSucursal, numeroReparto, modoConsultarComprobantes, fechaDesde, fechaHasta, idDistribucion, idLocalidad, idEmpleado, idRuta, dia)
   End Function
#End Region

   Public Sub SeteaFormaPago(medioPago As Reglas.RegistracionPagosMedioPago, drPedido As Entidades.dtsRegistracionPagosV2.ComprobantesRow,
                             idMotivo As Integer, motivo As String, borradorComp As Entidades.RepartoCobranzaComprobante)
      _SeteaFormaPago(medioPago, drPedido, idMotivo, motivo, borradorComp)
   End Sub
   Private Sub _SeteaFormaPago(medioPago As Reglas.RegistracionPagosMedioPago, drPedido As Entidades.dtsRegistracionPagosV2.ComprobantesRow,
                               idMotivo As Integer, motivo As String, borradorComp As Entidades.RepartoCobranzaComprobante)
      If medioPago = Reglas.RegistracionPagosMedioPago.Efectivo Then
         drPedido.TotalEfectivo = drPedido.SaldoComprobante

      ElseIf medioPago = Reglas.RegistracionPagosMedioPago.CuentaCorriente Then
         drPedido.TotalCuentaCorriente = drPedido.SaldoComprobante

      ElseIf medioPago = Reglas.RegistracionPagosMedioPago.NotaCredito Then
         'Using frm As frmMotivoNC = New frmMotivoNC(drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroComprobante)
         '   If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
         drPedido.TotalNC = drPedido.SaldoComprobante
         drPedido.GetProductosRows().All(Function(dr)
                                            dr.IdMotivo = idMotivo
                                            dr.Motivo = motivo
                                            dr.Devuelve = dr.Cantidad
                                            dr.ImporteDevuelve = dr.ImporteTotal
                                            Return True
                                         End Function)

      ElseIf medioPago = Reglas.RegistracionPagosMedioPago.ReEnviar Then
         drPedido.TotalReenvio = drPedido.SaldoComprobante

      ElseIf medioPago = Reglas.RegistracionPagosMedioPago.OtrasFormasPago Then

         drPedido.TotalEfectivo = borradorComp.TotalEfectivo
         drPedido.TotalCuentaCorriente = borradorComp.TotalCuentaCorriente
         drPedido.TotalTransferencia = borradorComp.TotalTransferencia
         If borradorComp.IdCuentaBancaria.HasValue Then
            drPedido.IdCuentaBancaria = borradorComp.IdCuentaBancaria.Value
         Else
            drPedido.SetIdCuentaBancariaNull()
         End If
         If borradorComp.FechaTransferencia.HasValue Then
            drPedido.FechaTransferencia = borradorComp.FechaTransferencia.Value
         Else
            drPedido.SetFechaTransferenciaNull()
         End If

         For Each prod In borradorComp.Productos
            For Each drP In drPedido.GetProductosRows().Where(Function(dr) dr.IdProducto = prod.IdProducto And dr.Orden = prod.Orden)
               drP.Devuelve = prod.CantidadDevuelta
               drP.ImporteDevuelve = Math.Round(drP.ImporteTotal / drP.Cantidad * drP.Devuelve, 2)
               drP.IdMotivo = prod.IdEstadoVenta
               drP.Motivo = prod.NombreEstadoNovedad
            Next
         Next
         drPedido.TotalNC = borradorComp.TotalNC

         Dim dtCheques = DirectCast(DirectCast(drPedido.Table, Entidades.dtsRegistracionPagosV2.ComprobantesDataTable).DataSet, Entidades.dtsRegistracionPagosV2).Cheques
         Dim cache = New BusquedasCacheadas()
         For Each chq In borradorComp.Cheques
            Dim drC = dtCheques.NewChequesRow()
            drC.IdSucursal = borradorComp.IdSucursalComp
            drC.IdTipoComprobante = borradorComp.IdTipoComprobanteComp
            drC.Letra = borradorComp.LetraComp
            drC.CentroEmisor = borradorComp.CentroEmisorComp
            drC.NumeroComprobante = borradorComp.NumeroComprobanteComp

            drC.IdBanco = chq.IdBanco
            drC.IdBancoSucursal = chq.IdBancoSucursal
            drC.IdLocalidad = chq.IdLocalidad
            drC.NumeroCheque = chq.NumeroCheque
            drC.IdBanco = chq.IdBanco
            drC.IdBancoSucursal = chq.IdBancoSucursal
            drC.IdLocalidad = chq.IdLocalidad
            drC.Cuit = chq.Cuit

            drC.FechaEmision = chq.FechaEmision
            drC.FechaCobro = chq.FechaCobro
            drC.Titular = chq.Titular
            drC.Importe = chq.Importe

            drC.CodigoCliente = drPedido.CodigoCliente
            drC.Usuario = actual.Nombre
            drC.IdEstadoCheque = "ENCARTERA"
            drC.NombreBanco = cache.BuscaBanco(chq.IdBanco).NombreBanco
            drC.IdTipoCheque = chq.IdTipoCheque
            drC.NombreTipoCheque = cache.BuscaTipoCheque(chq.IdTipoCheque).NombreTipoCheque
            drC.NroOperacion = chq.NroOperacion

            dtCheques.AddChequesRow(drC)
         Next
         drPedido.TotalCheques = borradorComp.TotalCheques

         Dim dtNCAplicadas = DirectCast(DirectCast(drPedido.Table, Entidades.dtsRegistracionPagosV2.ComprobantesDataTable).DataSet, Entidades.dtsRegistracionPagosV2).NCAplicadas
         For Each nc In borradorComp.NCAplicadas
            Dim drNC = dtNCAplicadas.NewNCAplicadasRow()
            drNC.Seleccionado = True

            drNC.IdSucursal = nc.IdSucursal
            drNC.IdTipoComprobante = nc.IdTipoComprobanteComp
            drNC.Letra = nc.LetraComp
            drNC.CentroEmisor = nc.CentroEmisorComp
            drNC.NumeroComprobante = nc.NumeroComprobanteComp

            drNC.IdSucursalNC = nc.IdSucursalNC
            drNC.IdTipoComprobanteNC = nc.IdTipoComprobanteNC
            drNC.LetraNC = nc.LetraNC
            drNC.CentroEmisorNC = nc.CentroEmisorNC
            drNC.NumeroComprobanteNC = nc.NumeroComprobanteNC

            drNC.SaldoComprobante = nc.SaldoComprobante
            drNC.ImporteAplicado = nc.ImporteAplicado

            dtNCAplicadas.AddNCAplicadasRow(drNC)
         Next

         drPedido.TotalRendido = drPedido.TotalEfectivo + drPedido.TotalCheques + drPedido.TotalTransferencia

      End If

      drPedido.MedioPagoSeleccionado = medioPago
      drPedido.NombreMedioPagoSeleccionado = Publicos.GetEnumString(medioPago)
      drPedido.Seleccionado = medioPago <> Reglas.RegistracionPagosMedioPago.SinSeleccionar

   End Sub
   Public Sub PagarTodo(ds As Entidades.dtsRegistracionPagosV2)
      For Each drPedido In ds.Comprobantes.Where(Function(dr) Not dr.Seleccionado And dr.ImporteTotal > 0)
         _SeteaFormaPago(RegistracionPagosMedioPago.Efectivo, drPedido, idMotivo:=0, motivo:=String.Empty, borradorComp:=Nothing)
      Next
      ds.AcceptChanges()
   End Sub

#Region "Metodos GrabarRegistracionPagos"
   Public Sub GrabarRegistracionPagos(ds As Entidades.dtsRegistracionPagosV2,
                                      fechaRendicion As Date,
                                      idCaja As Integer,
                                      numeroReparto As Integer?,
                                      idFuncion As String,
                                      totalesResumen As Entidades.Reparto)
      EjecutaConTransaccion(Sub() _GrabarRegistracionPagos(ds, fechaRendicion, idCaja, numeroReparto, idFuncion, totalesResumen))
   End Sub
   Private Sub _GrabarRegistracionPagos(ds As Entidades.dtsRegistracionPagosV2,
                                        fechaRendicion As Date,
                                        idCaja As Integer,
                                        numeroReparto As Integer?,
                                        idFuncion As String,
                                        totalesResumen As Entidades.Reparto)

      For Each drComprobante In ds.Comprobantes.Where(Function(x) x.Seleccionado)
         Dim medioPago = DirectCast(drComprobante.MedioPagoSeleccionado, RegistracionPagosMedioPago)

         If medioPago = RegistracionPagosMedioPago.Efectivo Then
            GrabaEfectivo(drComprobante, fechaRendicion, idCaja, numeroReparto, idFuncion)

         ElseIf medioPago = RegistracionPagosMedioPago.CuentaCorriente Then
            GrabaCuentaCorriente(drComprobante, fechaRendicion, idFuncion)

         ElseIf medioPago = RegistracionPagosMedioPago.ReEnviar Then
            GrabarReenvio(drComprobante)

         ElseIf medioPago = RegistracionPagosMedioPago.NotaCredito Then
            GrabaNotaCreditoTotal(drComprobante, fechaRendicion, idCaja, numeroReparto, idFuncion)

         ElseIf medioPago = RegistracionPagosMedioPago.OtrasFormasPago Then
            GrabaVarias(drComprobante, fechaRendicion, idCaja, numeroReparto, idFuncion)

         End If
      Next

      '# Actualizo los importes totales en resumenes
      Dim rReparto As Eniac.Reglas.Repartos = New Eniac.Reglas.Repartos(da)
      Dim reparto As Entidades.Reparto = New Entidades.Reparto() With {.IdSucursal = actual.Sucursal.Id, .IdReparto = numeroReparto.Value}
      With totalesResumen
         rReparto.ActualizaTotalesResumenes(reparto.IdSucursal, reparto.IdReparto,
                                            .TotalResumenComprobante, .TotalResumenEfectivo,
                                            .TotalResumenTransferencia, .TotalResumenCtaCte, .TotalResumenCheques,
                                            .TotalResumenNCred, .TotalResumenReenvio, .TotalResumenSaldoGeneral)
      End With

      Dim idCobranza = New RepartosCobranzas(da).GetMaximoIdCobranza(actual.Sucursal.Id, numeroReparto.Value) + 1
      _GrabarCobranzaRegistracionPagos(numeroReparto.Value, fechaRendicion, idCaja, idCobranza, ds)
      _BorrarBorradorRegistracionPagos(numeroReparto.Value)

   End Sub

   Private Function GrabaEfectivo(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow,
                                  fechaRendicion As Date,
                                  idCaja As Integer,
                                  numeroReparto As Integer?,
                                  idFuncion As String) As Entidades.CuentaCorriente
      Dim cheques As List(Of Eniac.Entidades.Cheque) = Nothing
      Dim comprobantesAfectados As List(Of Entidades.CuentaCorrientePago)
      comprobantesAfectados = GetDetalleComprobante(dr, dr.TotalEfectivo)
      Dim recibo = GrabaRecibo(GetTipoComprobanteRecibo(dr.IdTipoComprobante, dr.ImporteTotal), fechaRendicion,
                               dr.IdCliente, dr.IdVendedor, idCaja,
                               "Recibo por pago Efectivo",
                               dr.TotalEfectivo,
                               importeTransferencia:=0, ctaBancaria:=Nothing, fechaTransferencia:=Nothing,
                               cheques, comprobantesAfectados,
                               numeroReparto, idFuncion)
      'Si el pago seleccionado no tiene reparto se le asigna el del reparto a rendir (seleccionado)
      If dr.IsNumeroRepartoNull Then
         dr.NumeroReparto = CInt(numeroReparto)
      End If

      dr.ReciboGenerado = recibo
      RegistrarCambios(dr, fechaRendicion, idFuncion)
      ActualizarFechaRendicion(dr, fechaRendicion)

      AgregaReciboDataSet(dr, recibo, numeroReparto)

      Return recibo
   End Function
   Private Sub GrabaCuentaCorriente(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow,
                                    fechaRendicion As Date,
                                    idFuncion As String)
      ActualizarCC(dr, fechaRendicion)
      RegistrarCambios(dr, fechaRendicion, idFuncion)

      AgregaReciboDataSet(dr, recibo:=Nothing, numeroReparto:=Nothing)
   End Sub
   Private Sub GrabarReenvio(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow)

      Dim strFiltro As String
      strFiltro = String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                dr.IdSucursal, dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor, dr.NumeroComprobante)

      Dim oPedido As Reglas.Ventas = New Reglas.Ventas(da)
      'busco el pedido, luego actualizo con el nuevo nro de reparto.
      oPedido._ActualizarPedidoPorReenvio(strFiltro, NumeroReparto:=Nothing, idTransportista:=Nothing, fechaReparto:=Nothing)
      Dim rCtaCte = New CuentasCorrientes(da)
      rCtaCte._ActualizarNumeroReparto(dr.IdSucursal, dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor, dr.NumeroComprobante, numeroReparto:=Nothing)

      AgregaReciboDataSet(dr, recibo:=Nothing, numeroReparto:=Nothing)
   End Sub
   Private Function GrabaNotaCreditoTotal(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow,
                                          fechaRendicion As Date,
                                          idCaja As Integer,
                                          numeroReparto As Integer?,
                                          idFuncion As String) As Entidades.CuentaCorriente

      Dim rVenta = New Ventas(da)
      Dim comprobante = rVenta.GetUna(dr.IdSucursal, dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor.ToShort(), dr.NumeroComprobante)
      If dr.GetProductosRows().Any() Then
         comprobante.VentasProductos.ForEach(Sub(vp) vp.IdEstadoVenta = dr.GetProductosRows().FirstOrDefault().IdMotivo)
      End If

      If numeroReparto.HasValue Then
         comprobante.NumeroReparto = Integer.Parse(numeroReparto.ToString())
      End If


      Dim copiaResult = rVenta._CopiarReemplazarComprobante(comprobante,
                                                            Cache.BuscaTipoComprobante(GetTipoComprobanteNC(dr)), idCaja,
                                                            eliminarComprobanteOrigen:=False, esFiscal:=False,
                                                            nuevoNumeroComprobante:=0, metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Automatico,
                                                            idFuncion:=idFuncion, nuevaFecha:=fechaRendicion, copiaFacturables:=False, idSucursalNuevo:=dr.IdSucursal)

      Dim rVV = New VentasInvocados(da)
      '---------------------------------------------------------------------------
      Dim rVta = New Reglas.Ventas()
      If Not rVta.Existe(dr.IdSucursal, dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor.ToShort(), dr.NumeroComprobante) Then
         Dim eVV = New Entidades.VentaInvocado() With
                    {
                        .Invocado = New Entidades.VentaInvocada() With
                                    {
                                       .IdSucursal = dr.IdSucursal,
                                       .IdTipoComprobante = dr.IdTipoComprobante,
                                       .Letra = dr.Letra,
                                       .CentroEmisor = dr.CentroEmisor,
                                       .NumeroComprobante = dr.NumeroComprobante
                                    },
                        .Invocador = copiaResult.ComprobanteNuevo
                    }
         rVV._Insertar(eVV)
      End If
      '---------------------------------------------------------------------------

      Dim importeAplicar As Decimal = Math.Min(dr.ImporteTotal, copiaResult.ComprobanteNuevo.ImporteTotal * -1)

      Dim colComprobantes = New List(Of Entidades.CuentaCorrientePago)()
      AddDetalleComprobante(colComprobantes,
                            dr.IdSucursal, Cache.BuscaTipoComprobante(dr.IdTipoComprobante), dr.Letra, Convert.ToInt16(dr.CentroEmisor), dr.NumeroComprobante,
                            dr.IdCliente, importeAplicar)

      Dim nc = copiaResult.ComprobanteNuevo
      AddDetalleComprobante(colComprobantes,
                            nc.IdSucursal, nc.TipoComprobante, nc.LetraComprobante, nc.CentroEmisor, nc.NumeroComprobante,
                            nc.IdCliente, importeAplicar)

      Dim cheques As List(Of Eniac.Entidades.Cheque) = Nothing
      Dim importeMinuta = 0D
      Dim recibo = GrabaRecibo(GetTipoComprobanteRecibo(dr.IdTipoComprobante, importeMinuta), fechaRendicion,
                               dr.IdCliente, dr.IdVendedor, idCaja,
                               "Aplicación de NC",
                               importeMinuta,
                               importeTransferencia:=0, ctaBancaria:=Nothing, fechaTransferencia:=Nothing,
                               cheques, colComprobantes,
                               numeroReparto, idFuncion)

      dr.ReciboGenerado = recibo

      RegistrarCambios(dr, fechaRendicion, idFuncion)
      ActualizarFechaRendicion(dr, fechaRendicion)

      AgregaReciboDataSet(dr, recibo, numeroReparto)
      Return recibo
   End Function
   Private Function GrabaVarias(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow,
                                fechaRendicion As Date,
                                idCaja As Integer,
                                numeroReparto As Integer?,
                                idFuncion As String) As Entidades.CuentaCorriente

      Dim colComprobantes = New List(Of Entidades.CuentaCorrientePago)()

      Dim ncVenta As Entidades.Venta
      Dim totalNC = 0D
      Dim totalAplicado = 0D
      If dr.TotalNC <> 0 Then

         Dim drProdCol = dr.GetProductosRows().Where(Function(x) x.Devuelve <> 0)
         If drProdCol.Count > 0 Then
            Dim rVenta = New Ventas(da)
            Dim transportista = Cache.BuscaTransportista(If(dr.IsIdTransportistaNull, 0I, dr.IdTransportista))
            Dim Cliente As Entidades.Cliente = Cache.BuscaClienteEntidadPorId(dr.IdCliente)
            Dim FormaPagoCliente As Entidades.VentaFormaPago = New Eniac.Reglas.VentasFormasPago().GetUna(Cliente.IdFormasPago)
            If FormaPagoCliente.Dias = 0 Then
               Throw New Exception(String.Format("La Forma de Pago configurada en el cliente {0}-{1} no es de Cuenta Corriente", Cliente.CodigoCliente, Cliente.NombreCliente))
            End If
            ncVenta = rVenta.CreaVenta(dr.IdSucursal,
                                       Cache.BuscaTipoComprobante(GetTipoComprobanteNC(dr)), letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0,
                                       cliente:=Cache.BuscaClienteEntidadPorId(dr.IdCliente), categoriaFiscal:=Nothing,
                                       fecha:=fechaRendicion, vendedor:=Cache.BuscaEmpleado(dr.IdVendedor),
                                       transportista, formaPago:=Nothing,
                                       descuentoRecargoPorc:=Nothing, idCaja:=idCaja, cotizacionDolar:=Nothing, mercDespachada:=False,
                                       numeroReparto:=If(dr.IsNumeroRepartoNull, Nothing, dr.NumeroReparto),
                                       fechaEnvio:=Nothing, proveedor:=Nothing,
                                       observaciones:="Nota Credito Parcial",
                                       cobrador:=Nothing, clienteVinculado:=Nothing, nroOrdenCompra:=0)


            rVenta.AgregarInvocado(ncVenta,
                                   New Entidades.VentaInvocada() With
                                            {.IdSucursal = dr.IdSucursal,
                                             .IdTipoComprobante = dr.IdTipoComprobante,
                                             .TipoTipoComprobante = Cache.BuscaTipoComprobante(dr.IdTipoComprobante).Tipo,
                                             .Letra = dr.Letra,
                                             .CentroEmisor = Convert.ToInt16(dr.CentroEmisor),
                                             .NumeroComprobante = dr.NumeroComprobante,
                                             .Fecha = dr.FechaComprobante})
            ncVenta.SeleccionoInvocados = Entidades.Publicos.SiNoTodos.SI

            For Each drProd In drProdCol
               Dim prod = Cache.BuscaProductoEntidadPorId(drProd.IdProducto)
               Dim categoriaFiscalEmpresa = Cache.BuscaCategoriaFiscal(Publicos.CategoriaFiscalEmpresa)

               Dim precio = drProd.Precio
               If ncVenta.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado And
                  ncVenta.CategoriaFiscal.UtilizaImpuestos And categoriaFiscalEmpresa.UtilizaImpuestos Then
                  precio = Math.Round(CalculosImpositivos.ObtenerPrecioSinImpuestos(precio, prod), Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio)
               End If

               Dim ncProd = rVenta.CreaVentaProducto(prod, drProd.NombreProducto,
                                                     drProd.DescuentoRecargoPorc1, drProd.DescuentoRecargoPorc2,
                                                     precio, drProd.Devuelve,
                                                     Cache.BuscaTiposImpuestos(prod.IdTipoImpuesto), drProd.AlicuotaIVA,
                                                     Cache.BuscaListaDePrecios(drProd.IdListaPrecios),
                                                     fechaEntrega:=Nothing, tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL, nota:=String.Empty, idEstadoVenta:=drProd.Field(Of Integer?)("IdMotivo"),
                                                     venta:=ncVenta, redondeoEnCalculo:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
               rVenta.AgregarVentaProducto(ncVenta, ncProd, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
            Next

            rVenta.Inserta(ncVenta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)



            totalNC = ncVenta.ImporteTotal * -1

            AddDetalleComprobante(colComprobantes,
                                  ncVenta.IdSucursal, ncVenta.TipoComprobante, ncVenta.LetraComprobante, ncVenta.CentroEmisor, ncVenta.NumeroComprobante,
                                  ncVenta.IdCliente, totalNC)
            ''Vuelvo a tomar el valor porque el totalNC puede venir con diferencia por redondeo y de esta manera tomo el valor real de la NC.
            totalNC = colComprobantes.First().Paga * -1
         End If

         For Each drNC In dr.GetNCAplicadasRows()
            AddDetalleComprobante(colComprobantes,
                                  drNC.IdSucursalNC, Cache.BuscaTipoComprobante(drNC.IdTipoComprobanteNC), drNC.LetraNC, Convert.ToInt16(drNC.CentroEmisorNC), drNC.NumeroComprobanteNC,
                                  dr.IdCliente, drNC.ImporteAplicado * -1)
            totalAplicado += drNC.ImporteAplicado * -1
         Next

      End If

      AddDetalleComprobante(colComprobantes,
                            dr.IdSucursal, Cache.BuscaTipoComprobante(dr.IdTipoComprobante), dr.Letra, Convert.ToInt16(dr.CentroEmisor), dr.NumeroComprobante,
                            dr.IdCliente, totalNC + totalAplicado + dr.TotalEfectivo + dr.TotalCheques + dr.TotalTransferencia)


      Dim ctaBancaria = New CuentasBancarias(da).GetUna(dr.Field(Of Integer?)("IdCuentaBancaria").IfNull(-1), AccionesSiNoExisteRegistro.Nulo)
      Dim fechaTransferencia As Date? = Nothing
      If Not dr.IsFechaTransferenciaNull Then
         fechaTransferencia = dr.FechaTransferencia
      End If
      Dim cheques As List(Of Eniac.Entidades.Cheque) = Nothing
      Dim importeRecibo = dr.TotalEfectivo '+ dr.TotalCheques
      Dim recibo = GrabaRecibo(GetTipoComprobanteRecibo(dr.IdTipoComprobante, importeRecibo + dr.TotalCheques + dr.TotalTransferencia), fechaRendicion,
                               dr.IdCliente, dr.IdVendedor, idCaja,
                               "Recibo por pago con Varios medios",
                               importeRecibo,
                               dr.TotalTransferencia, ctaBancaria, fechaTransferencia,
                               GetDetalleCheques(dr.GetChequesRows), colComprobantes,
                               numeroReparto, idFuncion)

      dr.ReciboGenerado = recibo

      RegistrarCambios(dr, fechaRendicion, idFuncion)

      If dr.TotalCuentaCorriente <> 0 Then
         ActualizarCC(dr, fechaRendicion)
      Else
         ActualizarFechaRendicion(dr, fechaRendicion)
      End If

      AgregaReciboDataSet(dr, recibo, numeroReparto)
      Return recibo
   End Function

   Private Sub AgregaReciboDataSet(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow, recibo As Entidades.CuentaCorriente, numeroReparto As Integer?)
      If recibo Is Nothing Then recibo = New Entidades.CuentaCorriente()
      Dim drRec = DirectCast(dr.Table.DataSet, Entidades.dtsRegistracionPagosV2).Recibos.AddRecibosRow(dr.IdSucursal,
                                                                                                       If(dr.IsNumeroRepartoNull, numeroReparto.IfNull(), dr.NumeroReparto),
                                                                                                       dr.Table.Rows.Count + 1,
                                                                                                       recibo.TipoComprobante.IdTipoComprobante,
                                                                                                       recibo.CentroEmisor,
                                                                                                       recibo.Letra,
                                                                                                       recibo.NumeroComprobante,
                                                                                                       recibo.ImporteTotal,
                                                                                                       recibo.IdSucursal,
                                                                                                       dr.CodigoCliente,
                                                                                                       dr.NombreCliente,
                                                                                                       dr.NombreMedioPagoSeleccionado,
                                                                                                       dr.TotalEfectivo,
                                                                                                       dr.TotalCuentaCorriente,
                                                                                                       dr.TotalCheques,
                                                                                                       dr.TotalReenvio,
                                                                                                       dr.TotalNC,
                                                                                                       recibo.Observacion)
   End Sub

   Private _cacheTipoComprobanteRecibo As Dictionary(Of Tuple(Of String, Decimal), Entidades.TipoComprobante) = New Dictionary(Of Tuple(Of String, Decimal), Entidades.TipoComprobante)()
   Private Function GetTipoComprobanteRecibo(tipoComprobante As String, importe As Decimal) As Entidades.TipoComprobante

      Dim tuple = New Tuple(Of String, Decimal)(tipoComprobante, If(importe > 0, 1, If(importe < 0, -1, 0)))
      If Not _cacheTipoComprobanteRecibo.ContainsKey(tuple) Then
         Dim tipoRecibo = New Eniac.Reglas.TiposComprobantes(da)._GetTipoComprobanteRecibo(tipoComprobante, importe, AccionesSiNoExisteRegistro.Excepcion)
         _cacheTipoComprobanteRecibo.Add(tuple, tipoRecibo)
      End If

      Return _cacheTipoComprobanteRecibo(tuple)
   End Function
   Private Function GrabaRecibo(tipoRecibo As Entidades.TipoComprobante,
                                fechaRecibo As Date,
                                idCliente As Long,
                                idVendedor As Integer,
                                idCaja As Integer,
                                observaciones As String,
                                importeEfectivo As Decimal,
                                importeTransferencia As Decimal,
                                ctaBancaria As Entidades.CuentaBancaria,
                                fechaTransferencia As Date?,
                                cheques As List(Of Entidades.Cheque),
                                comprobantesAfectados As List(Of Entidades.CuentaCorrientePago),
                                numeroReparto As Integer?,
                                idFuncion As String) As Entidades.CuentaCorriente
      Dim rCtaCte = New CuentasCorrientes(da)
      Return rCtaCte.GrabaReciboAutomaticamente(tipoRecibo,
                                                fechaRecibo,
                                                Cache.BuscaClienteEntidadPorId(idCliente),
                                                Cache.BuscaEmpleado(idVendedor),
                                                idCaja,
                                                observaciones,
                                                cotizacionDolar:=Nothing,
                                                importeEfectivo:=importeEfectivo,
                                                importeDolares:=0,
                                                importeTickets:=0,
                                                importeTransferencia:=importeTransferencia,
                                                ctaBancaria:=ctaBancaria,
                                                fechaTransferencia:=fechaTransferencia,
                                                cheques:=cheques,
                                                tarjetas:=Nothing,
                                                retenciones:=Nothing,
                                                comprobantesAfectados:=comprobantesAfectados,
                                                numeroReparto:=numeroReparto,
                                                idFuncion:=idFuncion)
   End Function
   Private Function GetDetalleComprobante(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow,
                                          importeAplicar As Decimal) As List(Of Entidades.CuentaCorrientePago)
      Dim col = New List(Of Entidades.CuentaCorrientePago)()
      Return AddDetalleComprobante(col,
                                   dr.IdSucursal, Cache.BuscaTipoComprobante(dr.IdTipoComprobante), dr.Letra, Convert.ToInt16(dr.CentroEmisor), dr.NumeroComprobante,
                                   dr.IdCliente, importeAplicar)

   End Function
   Private Function AddDetalleComprobante(ByRef col As List(Of Entidades.CuentaCorrientePago),
                                          idSucursal As Integer,
                                          tipoComprobante As Entidades.TipoComprobante,
                                          letra As String,
                                          centroEmisor As Short,
                                          numeroComprobante As Long,
                                          idcliente As Long,
                                          totalPagos As Decimal) As List(Of Entidades.CuentaCorrientePago)
      If col Is Nothing Then
         col = New List(Of Entidades.CuentaCorrientePago)()
      End If
      Dim rPago = New CuentasCorrientes(da)
      Dim tempCol = rPago.GetPagosDeCliente(idSucursal, tipoComprobante, letra, centroEmisor, numeroComprobante,
                                            idcliente, totalPagos, idTipoLiquidacion:=Nothing, incluirPreElectronicos:=True, crmNovedad:=Nothing)
      col.AddRange(tempCol)
      Return col
   End Function

   Private Function GetDetalleCheques(dtCheques As IEnumerable(Of Entidades.dtsRegistracionPagosV2.ChequesRow)) As List(Of Entidades.Cheque)
      Dim cheques = New List(Of Entidades.Cheque)()
      For Each drCheque In dtCheques
         Dim cheque As Eniac.Entidades.Cheque = New Eniac.Entidades.Cheque()
         With cheque
            .NumeroCheque = drCheque.NumeroCheque
            .Banco = New Eniac.Reglas.Bancos().GetUno(drCheque.IdBanco)
            .IdBancoSucursal = drCheque.IdBancoSucursal
            .Localidad.IdLocalidad = drCheque.IdLocalidad
            .FechaEmision = drCheque.FechaEmision
            .FechaCobro = drCheque.FechaCobro
            .Titular = drCheque.Titular
            .Importe = drCheque.Importe
            .Cliente.CodigoCliente = drCheque.CodigoCliente
            .Usuario = drCheque.Usuario
            .IdEstadoCheque = Eniac.Entidades.Cheque.Estados.ENCARTERA
            .IdTipoCheque = drCheque.IdTipoCheque
            .Cuit = drCheque.Cuit
         End With
         cheques.Add(cheque)
      Next
      Return cheques
   End Function

#End Region

#Region "Metodos Borrador"
   Public Sub GrabarBorradorRegistracionPagos(idReparto As Integer,
                                              fechaRendicion As Date,
                                              idCaja As Integer,
                                              ds As Entidades.dtsRegistracionPagosV2)
      EjecutaConTransaccion(Sub() _GrabarBorradorRegistracionPagos(idReparto, fechaRendicion, idCaja, ds))
   End Sub
   Private Sub _GrabarBorradorRegistracionPagos(idReparto As Integer,
                                                fechaRendicion As Date,
                                                idCaja As Integer,
                                                ds As Entidades.dtsRegistracionPagosV2)
      _GrabarCobranzaRegistracionPagos(idReparto, fechaRendicion, idCaja, RepartosCobranzas.IdCobranzaBorrador, ds)
   End Sub
   Private Sub _BorrarBorradorRegistracionPagos(idReparto As Integer)
      Dim rRepCob = New RepartosCobranzas(da)
      rRepCob._Borrar(actual.Sucursal.Id, idReparto, RepartosCobranzas.IdCobranzaBorrador)
   End Sub

   Private Sub _GrabarCobranzaRegistracionPagos(idReparto As Integer,
                                                fechaRendicion As Date,
                                                idCaja As Integer,
                                                idCobranza As Integer,
                                                ds As Entidades.dtsRegistracionPagosV2)
      Dim rBorrador = New RepartosCobranzas(da)
      Dim rBorrComp = New RepartosCobranzasComprobantes(da)
      Dim repartoBorrador = New Entidades.RepartoCobranza() _
                              With {.IdSucursal = actual.Sucursal.Id,
                                    .IdReparto = idReparto,
                                    .IdCobranza = idCobranza,
                                    .FechaRendicion = fechaRendicion,
                                    .IdCaja = idCaja,
                                    .FechaAlta = Now,
                                    .IdUsuarioAlta = actual.Nombre}
      rBorrador._Borrar(repartoBorrador)

      repartoBorrador.Comprobantes.AddRange(RepartosCobranzasComprobantes.Parse(ds.Comprobantes.Where(Function(x) x.Seleccionado)))

      'ds.Comprobantes.Where(Function(x) x.Seleccionado).All(Function(drComp)
      '                                                         repartoBorrador.Comprobantes.Add(RepartosCobranzasComprobantesBorradores.Parse(drComp))
      '                                                         Return True
      '                                                      End Function)

      rBorrador._Insertar(repartoBorrador)
   End Sub
#End Region

   'Private Sub RegistrarCambios(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow, idFuncion As String)
   '   RegistrarCambios(dr:=dr, ventasProductosNC:=Nothing, idFuncion:=idFuncion)
   'End Sub

   Private Sub RegistrarCambios(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow, fechaRendicion As Date, idFuncion As String)
      'Se quita el parámetro de ventasProductosNC As List(Of Eniac.Entidades.VentaProducto), 
      'Agregar si en las pruebas resulta necesario

      'TODO: Analizar como recibir algo diferente de la lista de venta producto

      'If ventasProductosNC Is Nothing Then ventasProductosNC = New List(Of Eniac.Entidades.VentaProducto)()

      'Dim vpNC As Eniac.Entidades.VentaProducto
      'Dim vpCol = venta.VentasProductos
      'Dim vpCol = New VentasProductos(da).GetTodos(dr.IdSucursal, dr.IdTipoComprobante, dr.Letra, Convert.ToInt16(dr.CentroEmisor), dr.NumeroComprobante)
      'For Each vp As Eniac.Entidades.VentaProducto In vpCol

      Dim mps = New List(Of Eniac.Entidades.MovimientoStockProducto)()
      Dim mp As Eniac.Entidades.MovimientoStockProducto
      Dim orden As Integer = 0

      For Each vp In dr.GetProductosRows()
         'vpNC = Nothing
         'For Each q In (From vpNCq As Eniac.Entidades.VentaProducto In ventasProductosNC
         '               Where vpNCq.IdProducto = vp.IdProducto And vpNCq.Orden = vp.Orden
         '               Select vpNCq)
         '   vpNC = q
         'Next

         'Si es un cambio el cliente debió entregar una producto defectuoso por el que pidió el cambio.
         'Esa unidad defectuosa se graba como movimiento en deposito Defectuoso
         If vp.TipoOperacion = Eniac.Entidades.Producto.TiposOperaciones.CAMBIO.ToString() Then
            mp = New Eniac.Entidades.MovimientoStockProducto()
            mp.IdSucursal = actual.Sucursal.Id
            mp.IdProducto = vp.IdProducto
            'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
            '            mp.CantidadDefectuoso = vp.Cantidad - vp.Devuelve
            orden += 1
            mp.Orden = orden
            mps.Add(mp)
            'If vpNC IsNot Nothing Then
            '' '' Esta mercaderaía debería haberse cargado en la NC, reactivar en las pruebas si es necesario
            '' ''If vp.Devuelve > 0 Then
            '' ''   'mp.CantidadDefectuoso = mp.CantidadDefectuoso - vpNC.Cantidad
            '' ''   mp = New Eniac.Entidades.MovimientoCompraProducto()
            '' ''   mp.IdSucursal = actual.Sucursal.Id
            '' ''   mp.IdProducto = vp.IdProducto
            '' ''   'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
            '' ''   mp.Cantidad = vp.Devuelve 'vpNC.Cantidad
            '' ''   orden += 1
            '' ''   mp.Orden = orden
            '' ''   mps.Add(mp)
            '' ''End If
         ElseIf vp.TipoOperacion = Entidades.Producto.TiposOperaciones.BONIFICACION.ToString() Or
               (vp.TipoOperacion = Entidades.Producto.TiposOperaciones.NORMAL.ToString() And vp.Precio = 0) Then
            'If vpNC IsNot Nothing Then
            '' '' Esta mercaderaía debería haberse cargado en la NC, reactivar en las pruebas si es necesario
            '' ''If vp.Devuelve > 0 Then
            '' ''   mp = New Eniac.Entidades.MovimientoCompraProducto()
            '' ''   mp.IdSucursal = actual.Sucursal.Id
            '' ''   mp.IdProducto = vp.IdProducto
            '' ''   'Multiplico por el coeficiente antes definido. (asumo que el tipo está definido positivo)
            '' ''   mp.Cantidad = vp.Cantidad
            '' ''   orden += 1
            '' ''   mp.Orden = orden
            '' ''   mps.Add(mp)
            '' ''End If
         End If
      Next

      If mps.Count > 0 Then
         Dim idTipoMovimiento As String = Publicos.RegistracionPagosTipoMovimiento
         If String.IsNullOrWhiteSpace(idTipoMovimiento) Then
            Throw New Exception(String.Format("No está definido Tipo de movimiento para Cambio.{0}{0}Parámetros -> Logistica -> Registración de Pagos -> Tipo de Movimiento para cambio.", Environment.NewLine))
         End If
         Dim movi = New Entidades.MovimientoStock()
         movi.IdSucursal = actual.Sucursal.Id
         movi.Sucursal = actual.Sucursal
         movi.TipoMovimiento = Cache.BuscaTipoMovimiento(idTipoMovimiento) ' New Eniac.Reglas.TiposMovimientos().GetUno(idTipoMovimiento)
         movi.FechaMovimiento = fechaRendicion
         movi.Usuario = actual.Nombre
         movi.Observacion = String.Format("Registración de pagos de: {0} {1} {2:0000}-{3:00000000}", dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor, dr.NumeroComprobante)
         movi.Productos = mps

         Dim rMovCom = New MovimientosStock(da)
         rMovCom._Insertar(movi, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
      End If

   End Sub

   Private Sub ActualizarFechaRendicion(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow, fechaRendicion As Date)
      Dim rVentas = New Reglas.Ventas(da)
      rVentas._ModificarFechaRendicion(dr.IdSucursal,
                                       dr.IdTipoComprobante,
                                       dr.Letra,
                                       dr.CentroEmisor,
                                       dr.NumeroComprobante,
                                       fechaRendicion)
   End Sub
   Private Sub ActualizarCC(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow, fechaRendicion As Date)
      Dim rVentas = New Reglas.Ventas(da)
      rVentas._ModificarFormaPago(dr.IdSucursal,
                                  dr.IdTipoComprobante,
                                  dr.Letra,
                                  dr.CentroEmisor,
                                  dr.NumeroComprobante,
                                  fechaRendicion)
   End Sub


   Private Function GetTipoComprobanteNC(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow) As String
      Dim idTipoComprobanteNC As String

      If dr.GrabaLibro Then
         idTipoComprobanteNC = Publicos.IdNotaCreditoGrabaLibro
      Else
         idTipoComprobanteNC = Publicos.IdNotaCreditoNoGrabaLibro
      End If

      If Not dr.IsIdTipoComprobanteNCredNull Then
         idTipoComprobanteNC = dr.IdTipoComprobanteNCred
      End If

      Return idTipoComprobanteNC
   End Function
End Class
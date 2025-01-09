Imports Newtonsoft.Json

Public Class MovimientosStock
   Inherits Base

   Private _cache As BusquedasCacheadas

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New(accesoDatos, New BusquedasCacheadas())
   End Sub
   Public Sub New(cache As BusquedasCacheadas)
      Me.New(New Datos.DataAccess(), cache)
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess, cache As BusquedasCacheadas)
      NombreEntidad = Entidades.MovimientoStock.NombreTabla
      da = accesoDatos
      _cache = cache
   End Sub
#End Region

#Region "Overrides"
   Public Overloads Sub Insertar(entidad As Entidades.Entidad, dtExpensas As DataTable, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.MovimientoStock), dtExpensas, MetodoGrabacion, IdFuncion))
   End Sub
   Public Sub _Insertar(oMov As Entidades.MovimientoStock, dtExpensas As DataTable, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      'Dim a = JsonConvert.SerializeObject(oMov, Formatting.Indented,
      '                      New JsonSerializerSettings() With {
      '                             .ReferenceLoopHandling = ReferenceLoopHandling.Ignore
      '                      })

      CargarMovimientoStock(oMov, MetodoGrabacion, IdFuncion)
      'Dim s = New Web.Script.Serialization.JavaScriptSerializer()
      'Dim json = s.Serialize(oMov)

      'realiza contra aciento si tuviera una sucursal asociada 
      If oMov.TipoMovimiento.AsociaSucursal Then
         'si tiene el campo CONTRAMOVIMIENTOENVIORECEPCIONSUCURSAL en true en la tabla de Parametros
         If Publicos.ContraMovimientoEnvioRecepcionSucursal And Not String.IsNullOrEmpty(oMov.TipoMovimiento.IdContraTipoMovimiento) Then
            'guardo las sucursales origen y destino en variables
            Dim sucOrigen = oMov.Sucursal
            Dim sucDestino = oMov.Sucursal2
            Dim tipoMov = oMov.TipoMovimiento

            'invierto las sucursales - Deposito origen y destino
            '-- Origen.- --
            oMov.Sucursal = sucDestino
            oMov.IdSucursal = sucDestino.IdSucursal
            '-- Destino.- --
            oMov.Sucursal2 = sucOrigen
            '----------------------------------------------------
            Dim oTipoMovimiento = New TiposMovimientos(da)

            oMov.TipoMovimiento = oTipoMovimiento.GetUno(oMov.TipoMovimiento.IdContraTipoMovimiento)

            oMov.Productos.ForEach(
               Sub(ns)
                  ns.IdSucursal = sucDestino.IdSucursal
                  ns.IdDeposito = ns.IdDeposito2
                  ns.IdUbicacion = ns.IdUbicacion2
                  ns.Sucursal = sucDestino
               End Sub)

            oMov.ProductosNrosSerie.ForEach(
               Sub(ns)
                  ns.IdSucursal = sucDestino.IdSucursal
                  ns.Sucursal = sucDestino
                  ns.Vendido = False
               End Sub)

            'realizo la carga del movimiento de compra con los cambios de sucursales
            CargarMovimientoStock(oMov, MetodoGrabacion, IdFuncion)

            'vuelvo las sucursales a su lugar
            oMov.Sucursal = sucOrigen
            oMov.IdSucursal = sucOrigen.IdSucursal
            oMov.Sucursal2 = sucDestino
            oMov.TipoMovimiento = tipoMov

         End If
      End If

      If dtExpensas IsNot Nothing Then
         If Publicos.ExpensasRegistraComprasPor = Publicos.ExpensasRegistraComprasPorEnum.AreaComun.ToString() Then
            Dim reglaExpensas = New SqlServer.ComprasDistribucionExpensas(da)
            For Each drExpensas As DataRow In dtExpensas.Rows
               Dim importe As Decimal = 0
               Dim area As String = ""
               area = drExpensas(Entidades.AreaComun.Columnas.IdAreaComun.ToString()).ToString()
               If Not IsDBNull(drExpensas("importe")) Then
                  importe = DirectCast(drExpensas("importe"), Decimal)
                  ''Decimal.Parse(drExpensas("importe").ToString(), importe)
               End If
               If importe <> 0 Then
                  reglaExpensas.ComprasDistribucionExpensas_I(oMov.Compra.IdSucursal, oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante, oMov.Compra.Proveedor.IdProveedor,
                                                              area, importe)
               End If
            Next
         ElseIf Publicos.ExpensasRegistraComprasPor = Publicos.ExpensasRegistraComprasPorEnum.GrupoCama.ToString() Then
            Dim sqlExpensas = New SqlServer.ComprasDistribucionPorGrupo(da)
            For Each drExpensas As DataRow In dtExpensas.Rows
               Dim importe As Decimal = 0
               Dim grupoCama As Integer = 0
               grupoCama = CInt(drExpensas(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()))
               If Not IsDBNull(drExpensas("importe")) Then
                  importe = DirectCast(drExpensas("importe"), Decimal)
               End If
               If importe <> 0 Then
                  sqlExpensas.ComprasDistribucionPorGrupo_I(oMov.Compra.IdSucursal, oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante, oMov.Compra.Proveedor.IdProveedor,
                                                            grupoCama, importe)
               End If
            Next
         End If
      End If

   End Sub
   Public Sub ActualizarExpensas(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Integer,
                                 idProveedor As Integer, expensas As DataTable)
      EjecutaConTransaccion(Sub() ActualizarExpensas(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                     idProveedor, expensas))
   End Sub

   Public Sub _ActualizarExpensas(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Integer,
                                  idProveedor As Integer, expensas As DataTable)
      If expensas IsNot Nothing Then
         If Publicos.ExpensasRegistraComprasPor = Publicos.ExpensasRegistraComprasPorEnum.AreaComun.ToString() Then
            Dim sql = New SqlServer.ComprasDistribucionExpensas(da)
            sql.ComprasDistribucionExpensas_D(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                              idProveedor, String.Empty)
            For Each drExpensas As DataRow In expensas.Rows
               Dim area = drExpensas.Field(Of String)(Entidades.AreaComun.Columnas.IdAreaComun.ToString()).IfNull()
               Dim importe = drExpensas.Field(Of Decimal?)("importe").IfNull()
               If importe <> 0 Then
                  sql.ComprasDistribucionExpensas_I(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                    idProveedor, area,
                                                    importe)
               End If
            Next
         ElseIf Publicos.ExpensasRegistraComprasPor = Publicos.ExpensasRegistraComprasPorEnum.GrupoCama.ToString() Then
            Dim sql = New SqlServer.ComprasDistribucionPorGrupo(da)
            sql.ComprasDistribucionPorGrupo_D(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                              idProveedor, 0)
            For Each drExpensas As DataRow In expensas.Rows
               Dim grupoCama = drExpensas.Field(Of Integer?)(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()).IfNull()
               Dim importe = drExpensas.Field(Of Decimal?)("importe").IfNull()
               If importe <> 0 Then
                  sql.ComprasDistribucionPorGrupo_I(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                    idProveedor, grupoCama,
                                                    importe)
               End If
            Next
         End If
      End If
   End Sub

   '---------------------------------------------
   Public Sub CargarMovimientoStock(oMov As Entidades.MovimientoStock,
                                    MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)

      Dim tipoMov = oMov.Compra.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() ''(oMov.TipoMovimiento.IdTipoMovimiento = "COMPRA" Or oMov.TipoMovimiento.IdTipoMovimiento = "COMPRA-NC")

      Dim movNum As Reglas.MovimientosNumeros = New Reglas.MovimientosNumeros(da)

      'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
      'Los Movimientos que no tienen Comprobantes relacionados (ej: AJUSTE), toman el del stock.
      Dim coe As Integer = 1

      If Not String.IsNullOrEmpty(oMov.TipoMovimiento.ComprobantesAsociados) And tipoMov Then
         coe = oMov.Compra.TipoComprobante.CoeficienteValores
      End If

      Dim ctbl As Contabilidad = New Contabilidad(da)

      If oMov.Compra.TipoComprobante.AfectaCaja And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         'Para que se ejecuten las validaciones.
         ctbl.ArmarDetalle(oMov)
      End If


      'Recupero el ultimo numero de movimiento y le sumo uno para el nuevo
      oMov.NumeroMovimiento = movNum.GetUltimoNroMovimiento(oMov.Sucursal.Id, oMov.TipoMovimiento.IdTipoMovimiento) + 1

      'Actualizo los Comprobantes de Compra si el tipo de movimiento tiene comprobantes asociados
      'en caso contrario no togo los comprobantes

      '@@@ Tendriamos que hacer un campo "GrabaLibro".

      If Not String.IsNullOrEmpty(oMov.TipoMovimiento.ComprobantesAsociados) And tipoMov Then

         'Generl el Numero solo a aquellos fictisios, el resto corresponde el del Proveedor.
         If oMov.Compra.TipoComprobante.CoeficienteStock = 0 And
            Not oMov.Compra.TipoComprobante.AfectaCaja And
            Not oMov.Compra.TipoComprobante.ActualizaCtaCte Then

            Dim compraNum As Reglas.ComprasNumeros = New Reglas.ComprasNumeros(da)
            Dim vn As Entidades.CompraNumero = New Entidades.CompraNumero()

            vn.IdSucursal = oMov.Compra.IdSucursal
            vn.CentroEmisor = oMov.Compra.CentroEmisor
            vn.IdTipoComprobante = oMov.Compra.TipoComprobante.IdTipoComprobante
            vn.LetraFiscal = oMov.Compra.Letra
            vn.Numero = oMov.Compra.NumeroComprobante

            compraNum.ActualizarNumero(vn)

         End If

         Dim comp As Reglas.Compras = New Reglas.Compras(da)
         oMov.Compra.Proveedor = oMov.Proveedor

         'creo un producto
         Dim pro As Entidades.CompraProducto
         For Each mcpro In oMov.Productos
            pro = New Entidades.CompraProducto()

            mcpro.ProductoSucursal.Producto.IdProducto = mcpro.IdProducto
            pro.ProductoSucursal = mcpro.ProductoSucursal
            pro.Producto.IdProducto = mcpro.IdProducto
            pro.Producto.NombreProducto = mcpro.NombreProducto
            pro.Orden = mcpro.Orden
            pro.Cantidad = mcpro.Cantidad
            pro.CantidadUMCompra = mcpro.CantidadUMCompra
            pro.FactorConversionCompra = mcpro.FactorConversionCompra
            pro.PrecioPorUMCompra = mcpro.PrecioPorUMCompra
            pro.IdUnidadDeMedida = mcpro.IdUnidadDeMedida
            pro.IdUnidadDeMedidaCompra = mcpro.IdUnidadDeMedidaCompra
            pro.Precio = mcpro.Precio
            pro.DescuentoRecargo = mcpro.DescuentoRecargo
            pro.DescRecGeneral = mcpro.DescRecGeneral
            '--REQ-34986.- ----------------------------------
            pro.IdaAtributoProducto01 = mcpro.IdaAtributoProducto01
            pro.IdaAtributoProducto02 = mcpro.IdaAtributoProducto02
            pro.IdaAtributoProducto03 = mcpro.IdaAtributoProducto03
            pro.IdaAtributoProducto04 = mcpro.IdaAtributoProducto04
            '------------------------------------------------
            pro.IdDeposito = mcpro.IdDeposito
            pro.IdUbicacion = mcpro.IdUbicacion
            '------------------------------------------------
            pro.InformeCalidadNumero = mcpro.InformeCalidadNumero
            pro.InformeCalidadLink = mcpro.InformeCalidadLink
            pro.IdLote = mcpro.IdLote
            pro.FechaVencimientoLote = mcpro.VtoLote
            '------------------------------------------------
            If pro.Precio <> 0 Then
               pro.DescuentoRecargoProducto = Decimal.Round(pro.DescuentoRecargo / pro.Cantidad, 2)
               pro.DescuentoRecargoPorc = Decimal.Round((pro.DescuentoRecargoProducto / pro.Precio) * 100, 2)
               pro.DescRecGeneralProducto = Decimal.Round(pro.DescRecGeneral / pro.Cantidad, 2)
               pro.PrecioNeto = Decimal.Round(pro.Precio + pro.DescuentoRecargoProducto + pro.DescRecGeneralProducto, 2)
            End If

            'Tomo el descuento ya calculado para evitar problemas de redondeo.
            'pro.ImporteTotal = Decimal.Round((pro.Precio + pro.DescuentoRecargoProducto) * pro.Cantidad, 2)
            pro.ImporteTotal = Decimal.Round(pro.Precio * pro.Cantidad, 2) + pro.DescuentoRecargo

            pro.ImporteTotalNeto = Decimal.Round(pro.ImporteTotal + pro.DescRecGeneral, 2)

            pro.Iva = mcpro.IVA
            pro.PorcentajeIVA = mcpro.PorcentajeIVA
            '----------------------------------

            'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
            'En los informes de utilidad y demas, sumo los subtotales (no haga el calculo nuevamente)

            pro.Cantidad = pro.Cantidad * coe

            pro.Iva = pro.Iva * coe
            pro.ImporteTotal = pro.ImporteTotal * coe
            pro.ImporteTotalNeto = pro.ImporteTotalNeto * coe

            pro.IdConcepto = mcpro.IdConcepto
            pro.CentroCosto = mcpro.CentroCosto

            Dim ePNS As Entidades.ProductoNroSerie
            For Each eMCPNS In mcpro.ProductosNrosSerie
               ePNS = New Entidades.ProductoNroSerie
               ePNS.Producto.IdProducto = eMCPNS.IdProducto
               ePNS.OrdenCompra = eMCPNS.Orden
               ePNS.NroSerie = eMCPNS.NroSerie
               ePNS.IdSucursal = oMov.Compra.IdSucursal
               ePNS.IdDeposito = mcpro.IdDeposito
               ePNS.IdUbicacion = mcpro.IdUbicacion
               ePNS.TipoComprobante.IdTipoComprobante = oMov.Compra.IdTipoComprobante
               ePNS.Letra = oMov.Compra.Letra
               ePNS.CentroEmisor = oMov.Compra.CentroEmisor
               ePNS.NumeroComprobante = oMov.Compra.NumeroComprobante
               pro.Producto.NrosSeries.Add(ePNS)
            Next

            oMov.Compra.ComprasProductos.Add(pro)
         Next
         'graba los comprobantes de compra.-
         comp.GrabarCompra(oMov.Compra, MetodoGrabacion, idFuncion)
      End If
      'Actualizo el estado a los Comprobantes Facturados (si existieron)-----------------------------------
      If oMov.Compra.Facturables.Count > 0 Then
         ActualizoEstadoComprobantesFacturados(oMov.Compra)
      End If

      Dim blnSumoStock As Boolean = False
      Dim coeInvocado = If(oMov.Compra.Facturables.AnySecure(), oMov.Compra.Facturables(0).TipoComprobante.CoeficienteStock, 0)
      '-- REQ-42299 - REQ-42377 ---------------------------
      'If coeInvocado = 0 Then
      'actualizo los Lotes ------------------------------------------
      Dim proLot = New ProductosLotes(da)
      'modifico las cantidades de los lotes según el tipo de movimiento que se ingreso
      For Each pl In oMov.ProductosLotes
         pl.CantidadActualOriginal = pl.CantidadActual
         pl.ProductoSucursal.Sucursal = oMov.Sucursal
         pl.CantidadActual = pl.CantidadActual * oMov.TipoMovimiento.CoeficienteStock
      Next
      proLot.ActualizoLotes(oMov.ProductosLotes)
      For Each pl As Entidades.ProductoLote In oMov.ProductosLotes
         pl.CantidadActual = pl.CantidadActualOriginal
      Next
      'Actualizo Nros. Serie 
      For Each ns In oMov.ProductosNrosSerie
         ns.TipoComprobante = oMov.Compra.TipoComprobante
         ns.Letra = oMov.Compra.Letra
         ns.CentroEmisor = oMov.Compra.CentroEmisor
         ns.NumeroComprobante = oMov.Compra.NumeroComprobante
         ns.Proveedor = oMov.Proveedor
      Next
      '---------------------------------------------------------------
      Dim proNS = New ProductosNrosSerie(da)
      For Each pro In oMov.Productos
         If pro.ProductoSucursal.Producto.NrosSeries.Count > 0 Then

            If oMov.TipoMovimiento.CoeficienteStock * pro.Cantidad > 0 Then
               proNS.InsertoVariosNrosSerie(pro.ProductoSucursal.Producto.NrosSeries)
            Else
               For Each pr As Entidades.ProductoNroSerie In pro.ProductoSucursal.Producto.NrosSeries
                  proNS.EliminarNroSerie(pr.Producto.IdProducto, pr.NroSerie)
               Next
            End If
         End If
      Next

      ''Actualizo el número de movimiento en la tabla MovimientosNumeros
      Dim oMovNum = New Entidades.MovimientoNumero()
      oMovNum.Sucursal = oMov.Sucursal
      oMovNum.TipoMovimiento = oMov.TipoMovimiento
      oMovNum.Numero = oMov.NumeroMovimiento
      movNum.ActualizarNumero(oMovNum)

      'Grabo la cabecera del movimiento
      EjecutaSP(oMov, TipoSP._I)

      'Grabo el detalle del movimiento


      'pregunto si el CoeficienteStock es distinto de 0, si es asi lo multiplico por la cantidad del producto
      'los valores posibles para el coeficientestock son 0, 1 y -1
      If oMov.TipoMovimiento.CoeficienteStock <> 0 Then
         'Si NO facturo otros (ej: Factura sin Facturables).
         If oMov.Compra.Facturables.Count = 0 Then
            Me.GrabaMovimientoStock(oMov)
            blnSumoStock = oMov.Compra.TipoComprobante.CoeficienteStock > 0 'True  --- Solo interesa si Suma!!

            'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).
         ElseIf oMov.Compra.Facturables.Count > 0 And oMov.Compra.Facturables(0).TipoComprobante.CoeficienteStock = 0 Then
            Me.GrabaMovimientoStock(oMov)
            blnSumoStock = oMov.Compra.TipoComprobante.CoeficienteStock > 0 'True  --- Solo interesa si Suma!!

            'O Facturo pero devuelve (Deshace Remito) y ese facturado si desconto Stock (ej: Remito)
         ElseIf oMov.Compra.Facturables.Count > 0 And oMov.Compra.TipoComprobante.CoeficienteStock < 0 And oMov.Compra.Facturables(0).TipoComprobante.CoeficienteStock > 0 Then
            Me.GrabaMovimientoStock(oMov)
         End If
      End If
      'End If

      Dim ComprasObserv As Reglas.ComprasObservaciones = New Reglas.ComprasObservaciones(da)

      Dim iLinea = oMov.Compra.ComprasObservaciones.MaxSecure(Function(o) o.Linea).IfNull()
      For Each Observ As Entidades.CompraObservacion In oMov.Compra.ComprasObservaciones
         Observ.IdSucursal = oMov.Compra.IdSucursal
         Observ.IdTipoComprobante = oMov.Compra.TipoComprobante.IdTipoComprobante
         Observ.Letra = oMov.Compra.Letra
         Observ.CentroEmisor = oMov.Compra.CentroEmisor
         Observ.NumeroComprobante = oMov.Compra.NumeroComprobante
         Observ.Proveedor = oMov.Compra.Proveedor

         If Observ.Linea = 0 Then
            iLinea += 1
            Observ.Linea = iLinea
         End If

         'grabo las observaciones del comprobante de venta
         ComprasObserv.EjecutaSP(Observ, TipoSP._I)
      Next

      '-- REQ-33882.- Se cambia de Pedido a PedidoProv.- -----------------------------------------------------------------------------------------
      If blnSumoStock And Publicos.PedidosProvFacturarAutomatico And Not oMov.Observacion.Contains("Generado por Cambio de Estado") Then
         FacturarPedidos(oMov, idFuncion)
      End If

      If oMov.Compra.TipoComprobante.GeneraContabilidad And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         ctbl.RegistraContabilidadCompras(oMov.IdSucursal,
                                          oMov.Compra.TipoComprobante.IdTipoComprobante,
                                          oMov.Compra.Letra,
                                          oMov.Compra.CentroEmisor,
                                          oMov.Compra.NumeroComprobante,
                                          oMov.Compra.Proveedor.IdProveedor)   ''CargarContabilidad(oMov)
      End If

      'Si el tipo de pago es cuenta corriente tengo que grabar en las tablas de Cuentas Corrientes
      If oMov.Compra.TipoComprobante.ActualizaCtaCte Then
         If oMov.Compra.FormaPago.Dias > 0 Then
            If Publicos.TieneModuloCuentaCorrienteProveedores Then  ' Boolean.Parse(New Reglas.Parametros().GetValor(Parametro.Parametros.MODULOCUENTACORRIENTEPROVEEDORES)) Then
               'cargo el comprobante en el objeto CuentasCorrientes
               With oMov.Compra.CuentaCorrienteProv
                  .Proveedor = oMov.Compra.Proveedor
                  .TipoComprobante = oMov.Compra.TipoComprobante
                  .IdSucursal = oMov.Compra.IdSucursal
                  .Letra = oMov.Compra.Letra
                  .CentroEmisor = oMov.Compra.CentroEmisor
                  .NumeroComprobante = oMov.Compra.NumeroComprobante
                  .Fecha = oMov.Compra.Fecha
                  .FechaVencimiento = oMov.Compra.Fecha
                  .ImporteTotal = oMov.Compra.ImporteTotal
                  .ImportePesos = oMov.Compra.ImportePesos * oMov.Compra.TipoComprobante.CoeficienteValores
                  .CotizacionDolar = oMov.Compra.CotizacionDolar
                  .FormaPago = oMov.Compra.FormaPago
                  .Observacion = oMov.Compra.Observacion
               End With

               Dim oCtaCte = New Reglas.CuentasCorrientesProv(da)
               oCtaCte.GrabaCuentaCorrienteProv(oMov.Compra.CuentaCorrienteProv, MetodoGrabacion, idFuncion)
            End If
            Dim rCtaCte = New Reglas.CuentasCorrientesProv(da)
            'DP: tengo que insertar un recibo automaticamente si pago algo en la factura

            If oMov.Compra.ImporteACtaCte <> oMov.Compra.ImporteTotal And Not oMov.Compra.TipoComprobante.EsElectronico Then
               Dim oCtaCte As Entidades.CuentaCorrienteProv = New Entidades.CuentaCorrienteProv()

               With oCtaCte
                  .IdSucursal = oMov.Compra.IdSucursal
                  '.Letra = oMov.Compra.Letra
                  '.CentroEmisor = oMov.Compra.CentroEmisor

                  If oMov.Compra.TipoComprobante.GrabaLibro Then
                     .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(Entidades.TipoComprobante.Tipos.PAGO.ToString())
                  Else
                     .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(Entidades.TipoComprobante.Tipos.PAGOPROV.ToString())
                  End If

                  .Letra = If(.TipoComprobante.LetrasHabilitadas.Length = 1, .TipoComprobante.LetrasHabilitadas, oMov.Compra.Proveedor.CategoriaFiscal.LetraFiscal)
                  .CentroEmisor = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(.IdSucursal, My.Computer.Name, .TipoComprobante.IdTipoComprobante).CentroEmisor

                  ' .TipoComprobante = oMov.Compra.TipoComprobante
                  '.NumeroComprobante = New Reglas.VentasNumeros(da).GetProximoNumero(oVentas.IdSucursal, "PAGO", .Letra, .CentroEmisor)

                  .Fecha = oMov.Compra.Fecha
                  .FechaVencimiento = .Fecha
                  .FormaPago = New Reglas.VentasFormasPago(da).GetUna("COMPRAS", True) 'contado
                  .Proveedor = oMov.Compra.Proveedor
                  .Observacion = oMov.Compra.Observacion
                  .ImporteTotal = oMov.Compra.ImporteTotal - oMov.Compra.ImporteACtaCte
                  'cargo los comprobantes
                  '.Pagos = Me._ComprobantesGrilla
                  'cargo el efectivo para tenerlo discriminado
                  .ImportePesos = oMov.Compra.ImportePesos
                  .ImporteDolares = 0
                  .ImporteTarjetas = oMov.Compra.ImporteTarjetas
                  .ImporteTransfBancaria = oMov.Compra.ImporteTransfBancaria
                  .CuentaBancariaTransfBanc = oMov.Compra.CuentaBancariaTransfBanc
                  .CCTransferencias = oMov.Compra.Transferencias.ConvertAll(Function(trx) New Entidades.CuentaCorrienteProvTransferencia() With
                                                                         {
                                                                            .IdCuentaBancaria = trx.IdCuentaBancaria,
                                                                            .Importe = trx.Importe,
                                                                            .Orden = trx.Orden
                                                                         })

                  .CotizacionDolar = oMov.Compra.CotizacionDolar
                  'cargo los cheques
                  '.ImporteCheques = oMov.Compra.ImporteCheques
                  'cargo las Retenciones
                  '.Retenciones = Me._retenciones
                  '.ImporteRetenciones = Decimal.Parse(Me.txtRetenciones.Text)
                  .CajaDetalle.IdCaja = oMov.IdCaja
                  .Usuario = oMov.Compra.Usuario
                  .ChequesPropios = oMov.Compra.CuentaCorrienteProv.ChequesPropios
                  .ChequesTerceros = oMov.Compra.CuentaCorrienteProv.ChequesTerceros
               End With

               Dim oCtaCtePago As Entidades.CuentaCorrienteProvPago
               Dim impAPagar As Decimal = oMov.Compra.ImporteTotal - oMov.Compra.ImporteACtaCte
               Dim cuotita As Integer = 0

               For Each ct As Entidades.CuentaCorrienteProvPago In oMov.Compra.CuentaCorrienteProv.Pagos
                  If impAPagar = 0 Then Exit For
                  oCtaCtePago = New Entidades.CuentaCorrienteProvPago()
                  cuotita += 1
                  With oCtaCtePago
                     .TipoComprobante = oMov.Compra.TipoComprobante
                     .Letra = oMov.Compra.Letra
                     .CentroEmisor = oMov.Compra.CentroEmisor
                     .NumeroComprobante = oMov.Compra.NumeroComprobante
                     .Cuota = cuotita
                     .Fecha = ct.Fecha
                     .FechaVencimiento = ct.FechaVencimiento
                     .ImporteCuota = ct.ImporteCuota
                     .SaldoCuota = ct.SaldoCuota
                     If impAPagar <= ct.ImporteCuota Then
                        .Paga = impAPagar
                        impAPagar -= impAPagar
                     Else
                        .Paga = .SaldoCuota
                        impAPagar -= .SaldoCuota
                     End If
                     ' .DescuentoRecargoPorc = 0
                     '.DescuentoRecargo = .Paga - Decimal.Round(.Paga / (1 + .DescuentoRecargoPorc / 100), 2)
                     .IdSucursal = oMov.Compra.IdSucursal
                     .Usuario = oMov.Compra.Usuario
                  End With

                  oCtaCte.Pagos.Add(oCtaCtePago)
               Next

               rCtaCte.Inserta(oCtaCte, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

            End If
         End If
      End If

      'si es Contado verifico si tiene el modulo de Caja, asi grabo los movimientos
      If oMov.Compra.FormaPago IsNot Nothing Then
         If oMov.Compra.FormaPago.Dias = 0 Then

            Me.ActualizoInfoDeCheques(oMov)

            'si el cliente compro el modulo de caja
            Dim idCaja As Integer = 0
            Dim NroPlanilla As Integer = 0
            Dim NroMovimiento As Integer = 0

            If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Reglas.Parametros().GetValor(Parametro.Parametros.MODULOCAJA)) Then
               'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
               'ya que si es un cliente que tiene fichas y despues factura por aca se complica
               If oMov.Compra.TipoComprobante.AfectaCaja Then
                  Dim deta As Entidades.CajaDetalles = New Entidades.CajaDetalles(oMov.Compra.IdSucursal, oMov.Compra.Usuario, oMov.Compra.Password)
                  Dim caj As Reglas.Cajas = New Reglas.Cajas(da)
                  Dim ctaCaj As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas(da)
                  Dim cajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)

                  With deta
                     .FechaMovimiento = oMov.Compra.Fecha      'DateTime.Now
                     .IdSucursal = oMov.Compra.IdSucursal
                     .IdCaja = oMov.IdCaja
                     .IdTipoMovimiento = "E"c
                     .NumeroPlanilla = caj.GetPlanillaActual(oMov.Compra.IdSucursal, oMov.IdCaja).NumeroPlanilla
                     .Observacion = Strings.Left(oMov.Compra.TipoComprobante.Descripcion & " " & oMov.Compra.Letra & " " & oMov.Compra.CentroEmisor.ToString() &
                               "-" & oMov.Compra.NumeroComprobante.ToString("00000000") &
                               IIf(oMov.Compra.ChequesTerceros.Count > 0, " - Cant.Cheq.Terc.: " + oMov.Compra.ChequesTerceros.Count.ToString(), "").ToString() &
                               IIf(oMov.Compra.ChequesPropios.Count > 0, " - Cant.Cheq.Prop.: " + oMov.Compra.ChequesPropios.Count.ToString(), "").ToString() &
                               IIf(oMov.Compra.ImporteTransfBancaria > 0, " - Transf.Desde: " & oMov.Compra.CuentaBancariaTransfBanc.NombreCuenta, "").ToString() &
                               ". " & oMov.Compra.Proveedor.NombreProveedor, 100)
                     '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor(Parametro.Parametros.CTACAJACOMPRAS))
                     .IdCuentaCaja = oMov.Proveedor.CuentaDeCaja.IdCuentaCaja
                     .ImporteCheques = oMov.Compra.ImporteChequesTerceros
                     .ImporteTarjetas = oMov.Compra.ImporteTarjetas
                     .ImportePesos = oMov.Compra.ImportePesos
                     .ImporteBancos = oMov.Compra.ImporteTransfBancaria + oMov.Compra.ImporteChequesPropios
                     .ImporteRetenciones = oMov.Compra.Retenciones.SumSecure(Function(r) r.Retencion.ImporteTotal).IfNull()
                     .ImporteTarjetas += oMov.Compra.CuponesTarjetasLiquidacion.SumSecure(Function(c) c.TarjetaCupon.Monto).IfNull()
                     '-- REQ35989.- ------------------------------------------------------------------
                     If .ImporteBancos <> 0 Then
                        .IdMonedaImporteBancos = oMov.Compra.CuentaBancariaTransfBanc.Moneda.IdMoneda
                     End If
                     '--------------------------------------------------------------------------------
                     .ImporteDolares = 0
                     .CotizacionDolar = oMov.Compra.CotizacionDolar
                     .EsModificable = False
                     .GeneraContabilidad = False
                     .Usuario = actual.Nombre
                  End With

                  cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(oMov.Compra.ChequesTerceros), Publicos.ConvierteChequesPropiosEnArray(oMov.Compra.ChequesPropios))

                  idCaja = deta.IdCaja
                  NroPlanilla = deta.NumeroPlanilla
                  NroMovimiento = deta.NumeroMovimiento

                  oMov.Compra.IdCaja = idCaja
                  oMov.Compra.NumeroPlanilla = NroPlanilla
                  oMov.Compra.NumeroMovimiento = NroMovimiento

                  Me.ActualizaMovimientoCaja(oMov.Compra)

                  Dim totalAcreditado = oMov.Compra.CuponesTarjetasLiquidacion.Where(Function(c) c.TarjetaCupon.IdEstadoTarjeta = Entidades.TarjetaCupon.Estados.ACREDITADO).SumSecure(Function(c) c.TarjetaCupon.Monto).IfNull()
                  If totalAcreditado <> 0 Then
                     deta = New Entidades.CajaDetalles(oMov.Compra.IdSucursal, oMov.Compra.Usuario, oMov.Compra.Password)

                     With deta
                        .FechaMovimiento = oMov.Compra.Fecha      'DateTime.Now
                        .IdSucursal = oMov.Compra.IdSucursal
                        .IdCaja = oMov.IdCaja
                        .IdTipoMovimiento = "I"c
                        .NumeroPlanilla = caj.GetPlanillaActual(oMov.Compra.IdSucursal, oMov.IdCaja).NumeroPlanilla
                        .Observacion = String.Format("{0} {1} {2}-{3:00000000}. {4}",
                                                     oMov.Compra.TipoComprobante.Descripcion, oMov.Compra.Letra, oMov.Compra.CentroEmisor.ToString(), oMov.Compra.NumeroComprobante,
                                                     oMov.Compra.Proveedor.NombreProveedor).Truncar(100)
                        '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor(Parametro.Parametros.CTACAJACOMPRAS))
                        .IdCuentaCaja = Publicos.CtaCajaDeposito
                        .ImporteTarjetas = totalAcreditado
                        .ImporteBancos = totalAcreditado * -1
                        .IdMonedaImporteBancos = oMov.Compra.CuentaBancariaTransfBanc.Moneda.IdMoneda
                        If .IdMonedaImporteBancos = 0 Then
                           .IdMonedaImporteBancos = Entidades.Moneda.Peso
                        End If
                        .ImporteCheques = 0
                        .ImportePesos = 0
                        .ImporteRetenciones = 0
                        .ImporteDolares = 0
                        .CotizacionDolar = oMov.Compra.CotizacionDolar
                        .EsModificable = False
                        .GeneraContabilidad = False
                        .Usuario = actual.Nombre
                     End With

                     cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(oMov.Compra.ChequesTerceros), Publicos.ConvierteChequesPropiosEnArray(oMov.Compra.ChequesPropios))

                     Dim rLibroBancos = New LibroBancos(da)
                     Dim rTarjetas = New Tarjetas(da)
                     For Each cupon In oMov.Compra.CuponesTarjetasLiquidacion
                        Dim tarj = rTarjetas._GetUno(cupon.TarjetaCupon.IdTarjeta)
                        Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd) With {
                           .IdSucursal = cupon.IdSucursal,
                           .IdCuentaBancaria = tarj.CuentaBancaria.IdCuentaBancaria,
                           .NumeroMovimiento = rLibroBancos.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria),
                           .IdCuentaBanco = Publicos.CtaBancoDeposito,
                           .IdTipoMovimiento = "E",
                           .Importe = cupon.TarjetaCupon.Monto,
                           .FechaMovimiento = oMov.Compra.Fecha,
                           .FechaAplicado = cupon.TarjetaCupon.FechaEmision,
                           .Observacion = String.Format("{0} {1} {2}-{3:00000000}. {0}",
                                                     oMov.Compra.TipoComprobante.Descripcion, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                                     oMov.Proveedor.NombreProveedor).Truncar(100),
                           .Conciliado = False
                        }

                        rLibroBancos.AgregaMovimiento(entLibroBanco)
                     Next
                  End If

                  'si tiene modulo Bancos
                  If Publicos.TieneModuloBanco Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

                     My.Application.Log.WriteEntry("Actualizo los o el Banco con los datos de la Transferencia.", TraceEventType.Verbose)
                     Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos(da)
                     Dim entLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
                     Dim oLibBanco As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)

                     For Each cheq As Entidades.Cheque In oMov.Compra.ChequesPropios

                        With entLibroBanco
                           .IdSucursal = cheq.IdSucursal
                           .IdCuentaBancaria = cheq.CuentaBancaria.IdCuentaBancaria
                           .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                           .IdCuentaBanco = Publicos.CtaBancoPago  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOPAGO))
                           .IdTipoMovimiento = "E"
                           .Importe = cheq.Importe
                           .FechaMovimiento = oMov.Compra.Fecha
                           .IdCheque = cheq.IdCheque
                           .FechaAplicado = cheq.FechaCobro
                           '.Observacion = ent.Observacion
                           .Observacion = Strings.Left(oMov.Compra.TipoComprobante.Descripcion & " " & oMov.Compra.Letra & " " & oMov.Compra.CentroEmisor.ToString() & "-" & oMov.Compra.NumeroComprobante.ToString("00000000") & ". " & oMov.Proveedor.NombreProveedor, 100)
                           .Conciliado = False
                        End With

                        oLibroBancos.AgregaMovimiento(entLibroBanco)

                     Next

                     Dim rVTrx = New ComprasTransferencias(da)

                     If oMov.Compra.ImporteTransfBancaria <> 0 And oMov.Compra.FormaPago.Dias = 0 Then
                        For Each trx In oMov.Compra.Transferencias
                           With entLibroBanco
                              .IdSucursal = oMov.Compra.IdSucursal
                              .IdCuentaBancaria = trx.IdCuentaBancaria
                              .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                              .IdCuentaBanco = Publicos.CtaBancoTransfBancaria ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOTRANSFBANCARIA))
                              If oMov.Compra.TipoComprobante.CoeficienteValores > 0 Then
                                 .IdTipoMovimiento = "E"
                              Else
                                 .IdTipoMovimiento = "I"
                              End If
                              .Importe = Math.Abs(trx.Importe)
                              .FechaMovimiento = oMov.Compra.Fecha
                              .IdCheque = Nothing
                              .FechaAplicado = oMov.Compra.Fecha
                              '.Observacion = ent.Observacion
                              .Observacion = String.Format("{0} {1} {2}-{3:00000000} - Transf. desde: {4}",
                                                           oMov.Compra.TipoComprobante.Descripcion, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante, oMov.Proveedor.NombreProveedor).Truncar(100)
                              .Conciliado = False
                           End With

                           oLibroBancos.AgregaMovimiento(entLibroBanco)

                           trx.IdSucursalLibroBanco = entLibroBanco.IdSucursal
                           trx.IdCuentaBancariaLibroBanco = entLibroBanco.IdCuentaBancaria
                           trx.NumeroMovimientoLibroBanco = entLibroBanco.NumeroMovimiento

                           rVTrx._Actualizar(trx)
                        Next
                     End If

                     'If oMov.Compra.ImporteTransfBancaria > 0 Then

                     '   With entLibroBanco
                     '      .IdSucursal = oMov.Compra.IdSucursal
                     '      .IdCuentaBancaria = oMov.Compra.CuentaBancariaTransfBanc.IdCuentaBancaria
                     '      .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

                     '      If oMov.Compra.Proveedor.CuentaBanco.IdCuentaBanco > 0 Then
                     '         .IdCuentaBanco = oMov.Compra.Proveedor.CuentaBanco.IdCuentaBanco
                     '      Else
                     '         .IdCuentaBanco = Reglas.Publicos.CtaBancoTransfBancaria
                     '      End If

                     '      .IdTipoMovimiento = "E"
                     '      .Importe = oMov.Compra.ImporteTransfBancaria
                     '      .FechaMovimiento = oMov.Compra.Fecha
                     '      .IdCheque = Nothing
                     '      .FechaAplicado = oMov.Compra.Fecha
                     '      '.Observacion = ent.Observacion
                     '      .Observacion = Strings.Left(oMov.Compra.TipoComprobante.Descripcion & " " & oMov.Compra.Letra & " " & oMov.Compra.CentroEmisor.ToString() & "-" & oMov.Compra.NumeroComprobante.ToString("00000000") & " - Transf. desde: " & ". " & oMov.Proveedor.NombreProveedor, 100)
                     '      .Conciliado = False
                     '   End With

                     '   oLibroBancos.AgregaMovimiento(entLibroBanco)

                     'End If

                  End If
               End If
            End If
         End If
      End If

      If oMov.Compra.TipoComprobante.AfectaCaja And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         ctbl.MarcarCtaCteRegistroProcesado(oMov)
      End If

   End Sub

   Public Sub GrabaMovimientoStock(oMov As Entidades.MovimientoStock)

      Dim tipoMov = oMov.Compra.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString()      ' .TipoMovimiento.IdTipoMovimiento = "COMPRA")

      Dim oPro = New Reglas.ProductosSucursales(da)
      Dim oMovProductos = New Reglas.MovimientosStockProductos(da)
      'Dim oCom As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
      Dim prodProv = New Reglas.ProductosProveedores(da)
      Dim rMCPNS = New Reglas.MovimientosStockProductosNrosSerie(da)

      Dim Posicion As Integer = 0
      Dim Precio As Decimal

      For Each pro In oMov.Productos
         pro.IdSucursal = oMov.Sucursal.IdSucursal

         pro.MovimientoStock = oMov
         pro.TipoMovimiento = oMov.TipoMovimiento
         pro.NumeroMovimiento = oMov.NumeroMovimiento
         pro.Cantidad *= oMov.TipoMovimiento.CoeficienteStock

         If tipoMov Then
            If pro.ProductoSucursal.Producto.PrecioPorEmbalaje Then
               pro.Cantidad *= pro.ProductoSucursal.Producto.Embalaje
            End If
         End If

         ' TODO: DIEGO Existe otra forma ? Asignarlo en otro lado ?
         'En el movimiento grabo el precio final. No hace falta el detalle de los Descuentos
         Precio = pro.Precio

         If Not String.IsNullOrEmpty(oMov.TipoMovimiento.ComprobantesAsociados) And tipoMov Then
            pro.Precio = oMov.Compra.ComprasProductos(Posicion).PrecioNeto
         End If

         Posicion += 1

         'Inserto el detalle del movimiento
         oMovProductos.EjecutaSP(pro, TipoSP._I)

         '# Grabo el movimiento para los productos c/ Nro. Serie
         For Each ePNS In pro.ProductosNrosSerie
            ePNS.IdSucursal = oMov.Sucursal.Id
            ePNS.IdDeposito = pro.IdDeposito
            ePNS.IdUbicacion = pro.IdUbicacion
            ePNS.IdTipoMovimiento = oMov.TipoMovimiento.IdTipoMovimiento
            ePNS.NumeroMovimiento = oMov.NumeroMovimiento
            ePNS.Orden = pro.Orden
            ePNS.Cantidad = CInt((pro.Cantidad / Math.Abs(pro.Cantidad)))
            rMCPNS._Inserta(ePNS)
         Next

         oPro.ActualizarStock(pro.MovimientoStock.Sucursal.Id, pro.IdDeposito,
                              pro.IdUbicacion,
                              pro.IdProducto, pro.Cantidad, 0, 0, 0, 0,
                              pro.IdaAtributoProducto01, pro.IdaAtributoProducto02, pro.IdaAtributoProducto03, pro.IdaAtributoProducto04)

         'Vuelvo el precio porque al modificarlo en el objeto se cambia en pantalla y no queda prolijo. Aunque si diera error antes de esta linea volveria mal.
         pro.Precio = Precio

         'vuelvo la cantidad a su valor original
         pro.Cantidad *= oMov.TipoMovimiento.CoeficienteStock

         'Actualizo el precio de ultima compra en ProductoProveedores

         Dim dt1 As DataTable
         Dim PrecioNeto As Decimal = pro.Precio

         If pro.DescuentoRecargoPorc <> 0 Or oMov.DescuentoRecargo <> 0 Then
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + pro.DescuentoRecargoPorc / 100), 2)
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + oMov.DescuentoRecargo / 100), 2)
         End If

         If tipoMov And pro.ProductoSucursal.Producto.Moneda.IdMoneda = Entidades.Moneda.Dolar Then
            PrecioNeto = PrecioNeto / oMov.Compra.CotizacionDolar
         End If

         If oMov.Compra.Proveedor.IdProveedor <> 0 Then
            dt1 = prodProv.GetPorProductoYProveedor(oMov.Compra.Proveedor.IdProveedor, pro.IdProducto)
            If dt1.Rows.Count = 0 Then
               prodProv.InsertarProductoProveedor(oMov.Compra.Proveedor.IdProveedor, pro.IdProducto, pro.IdProducto, PrecioNeto, oMov.FechaMovimiento, PrecioNeto, 0, 0, 0, 0, 0, 0, False)
            Else
               prodProv.ActualizarUltimoPrecioCompra(oMov.Compra.Proveedor.IdProveedor, pro.IdProducto, PrecioNeto, oMov.FechaMovimiento)
            End If
         End If
      Next

   End Sub

   Public Sub GrabarMovimientoProduccion(oMov As Entidades.MovimientoStock)
      GrabaMovimientoStockVenta(oMov)
   End Sub

   Public Sub GrabaMovimientoStockVenta(oMov As Entidades.MovimientoStock)
      Dim movNum = New MovimientosNumeros(da)

      'Recupero el ultimo numero de movimiento y le sumo uno para el nuevo
      oMov.NumeroMovimiento = movNum.GetUltimoNroMovimiento(oMov.Sucursal.Id, oMov.TipoMovimiento.IdTipoMovimiento) + 1
      'Grabo la cabecera del movimiento
      EjecutaSP(oMov, TipoSP._I)
      'Inserto el detalle del movimiento
      GrabaMovimientoStock(oMov)

      ''Actualizo el número de movimiento en la tabla MovimientosNumeros
      Dim oMovNum = New Entidades.MovimientoNumero With {
         .Sucursal = oMov.Sucursal,
         .TipoMovimiento = oMov.TipoMovimiento,
         .Numero = oMov.NumeroMovimiento
      }
      movNum.ActualizarNumero(oMovNum)
   End Sub
   '---------------------------------------------

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(movimiento As Entidades.MovimientoStock, tipo As TipoSP)
      Try
         Dim sql = New SqlServer.MovimientosStock(da)
         Dim pkComprobante As Entidades.IPKComprobante
         Dim idCategoriaFiscal = 0S
         If Not String.IsNullOrWhiteSpace(movimiento.Venta.IdTipoComprobante) Then
            pkComprobante = movimiento.Venta
            idCategoriaFiscal = movimiento.Venta.CategoriaFiscal.IdCategoriaFiscal
         ElseIf Not String.IsNullOrWhiteSpace(movimiento.Compra.IdTipoComprobante) Then
            pkComprobante = movimiento.Compra
            idCategoriaFiscal = movimiento.Compra.IdcategoriaFiscal.ToShort()
         Else
            pkComprobante = New Entidades.PKComprobante()
         End If

         sql.MovimientosStock_I(movimiento.Sucursal.Id,
                                movimiento.TipoMovimiento.IdTipoMovimiento,
                                movimiento.NumeroMovimiento,
                                movimiento.FechaMovimiento,
                                movimiento.Neto,
                                movimiento.Total,
                                movimiento.PorcentajeIVA,
                                pkComprobante.IdTipoComprobante,
                                pkComprobante.Letra,
                                pkComprobante.CentroEmisor,
                                pkComprobante.NumeroComprobante,
                                idCategoriaFiscal,
                                movimiento.Usuario,
                                movimiento.Observacion,
                                movimiento.TotalImpuestos,
                                movimiento.Sucursal2.Id,
                                movimiento.PercepcionIVA,
                                movimiento.PercepcionIB,
                                movimiento.PercepcionGanancias,
                                movimiento.PercepcionVarias,
                                movimiento.IdProduccion,
                                movimiento.Cliente.IdCliente,
                                movimiento.Proveedor.IdProveedor,
                                movimiento.IdEmpleado,
                                movimiento.ImpuestosInternos)

      Catch
         Throw
      End Try
   End Sub

   Private Sub CargarUno(o As Entidades.MovimientoStock, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.MovimientoStock.Columnas.IdSucursal.ToString()).ToString())
         .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno(dr(Entidades.MovimientoStock.Columnas.IdTipoMovimiento.ToString()).ToString())
         .NumeroMovimiento = Long.Parse(dr(Entidades.MovimientoStock.Columnas.NumeroMovimiento.ToString()).ToString())
         .FechaMovimiento = DateTime.Parse(dr(Entidades.MovimientoStock.Columnas.FechaMovimiento.ToString()).ToString())
         .Total = Decimal.Parse(dr(Entidades.MovimientoStock.Columnas.Total.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoStock.Columnas.PorcentajeIVA.ToString()).ToString()) Then
            .PorcentajeIVA = Decimal.Parse(dr(Entidades.MovimientoStock.Columnas.PorcentajeIVA.ToString()).ToString())
         End If
         .Usuario = dr(Entidades.MovimientoStock.Columnas.Usuario.ToString()).ToString()
         .Observacion = dr(Entidades.MovimientoStock.Columnas.Observacion.ToString()).ToString()
         .PercepcionIVA = Decimal.Parse(dr(Entidades.MovimientoStock.Columnas.PercepcionIVA.ToString()).ToString())
         .PercepcionIB = Decimal.Parse(dr(Entidades.MovimientoStock.Columnas.PercepcionIB.ToString()).ToString())
         .PercepcionGanancias = Decimal.Parse(dr(Entidades.MovimientoStock.Columnas.PercepcionGanancias.ToString()).ToString())
         .PercepcionVarias = Decimal.Parse(dr(Entidades.MovimientoStock.Columnas.PercepcionVarias.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoStock.Columnas.IdProduccion.ToString()).ToString()) Then
            .IdProduccion = Integer.Parse(dr(Entidades.MovimientoStock.Columnas.IdProduccion.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoStock.Columnas.IdProveedor.ToString()).ToString()) Then
            .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dr(Entidades.MovimientoStock.Columnas.IdProveedor.ToString()).ToString()))
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoStock.Columnas.IdEmpleado.ToString()).ToString()) Then
            .Empleado = New Reglas.Empleados(da).GetUno(Integer.Parse(dr(Entidades.MovimientoStock.Columnas.IdEmpleado.ToString()).ToString()))
         End If

         .Productos = New MovimientosStockProductos(da).GetTodos(.IdSucursal, .TipoMovimiento.IdTipoMovimiento, .NumeroMovimiento, cargaMovimientoStock:=False)

         If IsNumeric(dr(Entidades.MovimientoStock.Columnas.IdSucursal2.ToString())) Then
            .Sucursal2 = New Reglas.Sucursales(da).GetUna(Integer.Parse(dr(Entidades.MovimientoStock.Columnas.IdSucursal2.ToString()).ToString()), False)
         End If

         .ImpuestosInternos = Decimal.Parse(dr(Entidades.MovimientoStock.Columnas.ImpuestosInternos.ToString()).ToString())

      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Function GetUnoPorComprobante(idSucursal As Integer, ''idDeposito As Integer, idUbicacion As Integer,
                                        idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                        idProveedor As Long) As Entidades.MovimientoStock
      '--
      Dim dt = New SqlServer.MovimientosStock(da).GetUnoPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
      '--
      Dim oMovStock = New Entidades.MovimientoStock
      '--
      If dt.Rows.Count > 0 Then
         With oMovStock
            .IdSucursal = Integer.Parse(dt.Rows(0)("IdSucursal").ToString())
            .TipoMovimiento = New TiposMovimientos(da).GetUno(dt.Rows(0)("IdTipoMovimiento").ToString())
            .NumeroMovimiento = Integer.Parse(dt.Rows(0)("NumeroMovimiento").ToString())
            .FechaMovimiento = Date.Parse(dt.Rows(0)("FechaMovimiento").ToString())
            .Proveedor = New Proveedores(da)._GetUno(Long.Parse(dt.Rows(0)("IdProveedor").ToString()))
            .Compra = New Compras(da).GetUna(.IdSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
         End With
         Dim dtp = New SqlServer.MovimientosStockProductos(da).GetUnoComprobanteProductos(idSucursal,
                                                                                          idDeposito:=0, idUbicacion:=0,   'Se debe pasar porque la PK de la linea está mal.
                                                                                          oMovStock.TipoMovimiento.IdTipoMovimiento,
                                                                                          oMovStock.NumeroMovimiento)
         Dim oMovStockP As Entidades.MovimientoStockProducto
         For Each dr As DataRow In dtp.Rows
            oMovStockP = New Entidades.MovimientoStockProducto()
            With oMovStockP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .IdDeposito = Integer.Parse(dr("IdDeposito").ToString())
               .IdUbicacion = Integer.Parse(dr("IdUbicacion").ToString())
               .MovimientoStock = oMovStock
               .ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(Integer.Parse(dr("IdSucursal").ToString()), dr("IdProducto").ToString())
               .IdLote = dr.Field(Of String)(Entidades.MovimientoStockProducto.Columnas.IdLote.ToString())
               .IdProducto = .ProductoSucursal.Producto.IdProducto
               .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               .Cantidad2 = Decimal.Parse(dr("Cantidad2").ToString())
               .Precio = Decimal.Parse(dr("Precio").ToString())
               .IdaAtributoProducto01 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto01").ToString()))
               .IdaAtributoProducto02 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto02").ToString()))
               .IdaAtributoProducto03 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto03").ToString()))
               .IdaAtributoProducto04 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto04").ToString()))
            End With
            oMovStock.Productos.Add(oMovStockP)
         Next
      Else
         Throw New Exception("No existe este comprobante de compra.")
      End If

      Return oMovStock
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long) As Entidades.MovimientoStock
      Dim dt = New SqlServer.MovimientosStock(da).MovimientosStock_G1(idSucursal, idTipoMovimiento, numeroMovimiento)
      Dim o = New Entidades.MovimientoStock()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetUnoPorProduccion(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                       idTipoMovimiento As String, NumeroMovimiento As Long) As Entidades.MovimientoStock

      Dim dt = New SqlServer.MovimientosStock(da).GetMovimientosStock(idSucursal, idProduccion:=0, idTipoMovimiento, NumeroMovimiento)
      Dim oMovStock = New Entidades.MovimientoStock()

      If dt.Rows.Count > 0 Then
         With oMovStock
            .IdSucursal = Integer.Parse(dt.Rows(0)("IdSucursal").ToString())
            .TipoMovimiento = New TiposMovimientos(da).GetUno(dt.Rows(0)("IdTipoMovimiento").ToString())
            .NumeroMovimiento = Integer.Parse(dt.Rows(0)("NumeroMovimiento").ToString())
            .FechaMovimiento = Date.Parse(dt.Rows(0)("FechaMovimiento").ToString())
         End With
         Dim dtp = New SqlServer.MovimientosStockProductos(da).GetUnoComprobanteProductos(idSucursal, idDeposito, idUbicacion,
                                                                                          oMovStock.TipoMovimiento.IdTipoMovimiento, oMovStock.NumeroMovimiento)
         Dim oMovStockP As Entidades.MovimientoStockProducto
         For Each dr As DataRow In dtp.Rows
            oMovStockP = New Entidades.MovimientoStockProducto()
            With oMovStockP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .IdDeposito = Integer.Parse(dr("IdDeposito").ToString())
               .IdUbicacion = Integer.Parse(dr("IdUbicacion").ToString())
               .TipoMovimiento = oMovStock.TipoMovimiento
               .NumeroMovimiento = oMovStock.NumeroMovimiento
               .MovimientoStock = oMovStock
               .ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(Integer.Parse(dr("IdSucursal").ToString()), dr("IdProducto").ToString())
               .IdLote = dr.Field(Of String)(Entidades.MovimientoStockProducto.Columnas.IdLote.ToString())
               .IdProducto = .ProductoSucursal.Producto.IdProducto
               .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               .Cantidad2 = Decimal.Parse(dr("Cantidad2").ToString())
               .Precio = Decimal.Parse(dr("Precio").ToString())
               .IdaAtributoProducto01 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto01").ToString()))
               .IdaAtributoProducto02 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto02").ToString()))
               .IdaAtributoProducto03 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto03").ToString()))
               .IdaAtributoProducto04 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto04").ToString()))
            End With
            oMovStock.Productos.Add(oMovStockP)
         Next
      Else
         Throw New Exception("No existe este comprobante de compra.")
      End If
      Return oMovStock
   End Function

   Public Function GetUnoPorComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                        idProveedor As Integer) As DataTable
      Return New SqlServer.MovimientosStock(da).GetUnoPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function

   Public Function GetMovimientosProduccion(idSucursal As Integer, idProduccion As Integer) As DataTable
      Return New SqlServer.MovimientosStock(da).GetMovimientosStock(idSucursal, idProduccion, idTipoMovimiento:=String.Empty, NumeroMovimiento:=0)
   End Function

   Public Sub EliminarMovimientosStock(movcompras As Entidades.MovimientoStock)
      Dim sql = New SqlServer.MovimientosStock(da)
      sql.MovimientosStock_D(movcompras.IdSucursal, movcompras.TipoMovimiento.IdTipoMovimiento, movcompras.NumeroMovimiento)
   End Sub

   Private Sub ActualizoInfoDeCheques(oMov As Entidades.MovimientoStock)
      Dim sqlCompraCheq = New SqlServer.ComprasCheques(da)
      Dim sqlCheques = New SqlServer.Cheques(da)

      '-- Graba los cheques de la venta y su relacion.-
      For Each ch As Entidades.Cheque In oMov.Compra.ChequesPropios
         'si el cheque no existe lo ingreso a las tablas del sistema
         ch.IdSucursal = oMov.Compra.IdSucursal
         ch.IdEstadoCheque = Entidades.Cheque.Estados.PROVEEDOR
         If Not sqlCheques.Existe(oMov.IdSucursal, ch.NumeroCheque, ch.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.Cuit) Then
            Dim rCheques As New Reglas.Cheques(da)
            rCheques._Inserta(ch)
         End If
         sqlCompraCheq.ComprasCheques_I(oMov.Compra.IdSucursal, oMov.Compra.TipoComprobante.IdTipoComprobante,
                                         oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                         oMov.Compra.Proveedor.IdProveedor,
                                         ch.NumeroCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.IdCheque)

         '# Luego de registrar un Cheque Propio, actualizo el numerador de último cheque registrado en mi chequera
         Dim rChequeras As Reglas.Chequeras = New Chequeras(da)
         rChequeras.ActualizarNumeroActual(ch.IdChequera.Value, ch.NumeroCheque)
      Next
      Dim oCheqTercero = New Reglas.Cheques(da)
      For Each cheq As Entidades.Cheque In oMov.Compra.ChequesTerceros
         cheq.IdSucursal = oMov.Compra.IdSucursal
         cheq.IdEstadoCheque = Entidades.Cheque.Estados.PROVEEDOR


         sqlCompraCheq.ComprasCheques_I(oMov.Compra.IdSucursal, oMov.Compra.TipoComprobante.IdTipoComprobante,
                                        oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                        oMov.Compra.Proveedor.IdProveedor,
                                        cheq.NumeroCheque, cheq.Banco.IdBanco, cheq.IdBancoSucursal, cheq.Localidad.IdLocalidad, cheq.IdCheque)
      Next
   End Sub
   Private Sub FacturarPedidos(oMov As Entidades.MovimientoStock, idFuncion As String)
      Dim tablaPedidos As DataTable
      Dim sql = New SqlServer.PedidosProveedores(da)
      Dim sqlPE = New SqlServer.PedidosEstadosProveedores(da)

      Dim rPedidosProductosProveedores = New Reglas.PedidosProductosProveedores(da)
      Dim rPE = New PedidosEstadosProveedores(da)

      Dim FechaNuevoEstado As Date
      Dim CantidadProducto As Decimal = 0
      Dim Cont As Integer = 0

      'TODO: Hay que ver como parametrizar esto diferente
      'SPC: Hay que ver como parametrizar esto diferente
      Dim tipoTipoComprobante As String = "PEDIDOSPROV"
      If oMov.Compra.Facturables.AnySecure() Then
         tipoTipoComprobante = oMov.Compra.Facturables.First().TipoComprobante.Tipo
      End If
      'DP: Lo comento por ahora que solo vamos a Facturar Pedidos, cuando tengamos que Facturar Presupuestos por ejemplo.
      'If oVenta.VentasProductos.Count > 0 Then
      '   tipoTipoComprobante = oVenta.TipoComprobante.Tipo '  New Reglas.TiposComprobantes(da).GetUno(PedidosEstados.Rows(0)("IdTipoComprobante").ToString()).Tipo
      'End If

      Dim estadosFacturables = _cache.BuscaEstadosPedidoProveedoresParaFacturar(tipoTipoComprobante)
      If Not estadosFacturables.AnySecure() Then
         Exit Sub
      End If

      Dim idEstadoAnterior As String = estadosFacturables.First().IdEstado ' Publicos.PedidoProveedorEstadoAFacturar
      Dim idTipoEstadoAnterior As String = estadosFacturables.First().IdTipoEstado ' New EstadosPedidosProveedores().GetUno(idEstadoAnterior, tipoTipoComprobante).IdTipoEstado
      Dim idEstadoNuevo As String = estadosFacturables.First().IdEstadoFacturado ' Publicos.PedidoProveedorEstadoFacturado
      Dim idTipoEstadoNuevo As String = _cache.BuscaEstadosPedidoProveedores(idEstadoNuevo, tipoTipoComprobante).IdTipoEstado  ' New EstadosPedidosProveedores().GetUno(idEstadoNuevo, tipoTipoComprobante).IdTipoEstado

      ' para cada producto de la factura busco los pedidos pendientes.
      For Each Prod In oMov.Productos

         Dim pedidos As Entidades.Compra() = {}
         If Publicos.Facturacion.FacturarPedidoSeleccionado Then
            pedidos = oMov.Compra.Facturables.ToArray()
         End If

         tablaPedidos = sql.GetPedidosXProveedorProducto(oMov.Compra.IdSucursal,
                                                         idEstadoAnterior,
                                                         Prod.IdProducto,
                                                         oMov.Proveedor.IdProveedor,
                                                         pedidos,
                                                         tipoTipoComprobante,
                                                         oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaFactura,
                                                         oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaRemito,
                                                         Publicos.PedidoProveedorEstadoAnulado)
         CantidadProducto = Prod.Cantidad
         ' para cada pedido me fijo que puedo facturar...
         For Each Pedido As DataRow In tablaPedidos.Rows
            Select Case CantidadProducto ' la cantidad del producto puede ser mayor 0 Igual, menor
               Case Is >= Decimal.Parse(Pedido("cantPendiente").ToString()) ' en este caso "sobra cantidad" facturo y finalizo
                  Dim fechaEntrega As DateTime = DateTime.Parse(Pedido(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString())
                  Dim fechaEntregaNueva As DateTime = oMov.Compra.Fecha.AddSeconds(Cont)
                  If oMov.Compra.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
                     rPE.CambiarEstado(oMov.Compra.IdSucursal,
                                       Pedido(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                       Pedido(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                       Integer.Parse(Pedido(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                       Long.Parse(Pedido(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                                       Prod.IdProducto,
                                       Date.Parse(Pedido("FechaEstado").ToString()),
                                       idEstadoNuevo,
                                       tipoTipoComprobante,
                                       Decimal.Parse(Pedido("cantEntregada").ToString()),
                                       fechaEntregaNueva,
                                       "Facturación Automática",
                                       Integer.Parse(Pedido("Orden").ToString()),
                                       Pedido("IdCriticidad").ToString(),
                                       Date.Parse(Pedido("FechaEntrega").ToString()),
                                       0)

                     rPedidosProductosProveedores.ActualizaCantidadesSegunEstadoAnteriorNuevo(oMov.Compra.IdSucursal,
                                                Pedido(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                Pedido(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                                Integer.Parse(Pedido(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                                Integer.Parse(Pedido(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                                                Prod.IdProducto,
                                                Integer.Parse(Pedido("Orden").ToString()),
                                                idTipoEstadoAnterior,
                                                idTipoEstadoNuevo,
                                                Decimal.Parse(Pedido("cantEntregada").ToString()))
                  End If


                  If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                     sqlPE.PedidosEstadosProveedores_U_Fact(oMov.Compra.IdSucursal,
                                                     Pedido(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                     Pedido(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                                     Integer.Parse(Pedido(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                                     Integer.Parse(Pedido(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                                                     Prod.IdProducto, fechaEntregaNueva,
                                                     oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra,
                                                     oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                                     Integer.Parse(Pedido("Orden").ToString()))
                  End If
                  If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaRemito Then
                     sqlPE.PedidosEstadosProveedores_U_Remito(oMov.Compra.IdSucursal,
                                                   Pedido(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                   Pedido(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString(),
                                                   Integer.Parse(Pedido(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString()),
                                                   Integer.Parse(Pedido(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString()),
                                                   Prod.IdProducto, fechaEntregaNueva,
                                                   oMov.Compra.IdSucursal, oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra,
                                                   oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                                   Integer.Parse(Pedido("Orden").ToString()))
                  End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then

                  Cont += 1
               Case Is < Decimal.Parse(Pedido("cantPendiente").ToString()) ' facturo y el resto pasa a pendiente

                  'Si al facturar repite el codigo da error de PK, tomo la fecha en cada momento esperando que los Segundos eviten el error por PK.
                  'FechaNuevoEstado = Date.Parse(Date.Now.ToString("yyyy-MM-dd HH:mm:ss")).AddSeconds(Cont)
                  FechaNuevoEstado = oMov.Compra.Fecha.AddSeconds(Cont) '' Date.Parse(oVenta.Fecha.ToString("yyyy-MM-dd HH:mm")).AddSeconds(Cont)

                  If oMov.Compra.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
                     Dim IdTipoComprobanteFact As String
                     Dim LetraComprobanteFact As String
                     Dim CentroEmisorFact As Short
                     Dim NumeroComprobanteFact As Long
                     Dim IdSucursalRemito As Integer
                     Dim IdTipoComprobanteRemito As String
                     Dim LetraComprobanteRemito As String
                     Dim CentroEmisorRemito As Short
                     Dim NumeroComprobanteRemito As Long

                     IdTipoComprobanteFact = Pedido(Entidades.PedidoEstado.Columnas.IdTipoComprobanteFact.ToString()).ToString()
                     LetraComprobanteFact = Pedido(Entidades.PedidoEstado.Columnas.LetraFact.ToString()).ToString()
                     If IsNumeric(Pedido(Entidades.PedidoEstado.Columnas.CentroEmisorFact.ToString()).ToString()) Then
                        CentroEmisorFact = Short.Parse(Pedido(Entidades.PedidoEstado.Columnas.CentroEmisorFact.ToString()).ToString())
                     End If
                     If IsNumeric(Pedido(Entidades.PedidoEstado.Columnas.NumeroComprobanteFact.ToString()).ToString()) Then
                        NumeroComprobanteFact = Long.Parse(Pedido(Entidades.PedidoEstado.Columnas.NumeroComprobanteFact.ToString()).ToString())
                     End If

                     If IsNumeric(Pedido(Entidades.PedidoEstado.Columnas.IdSucursalRemito.ToString()).ToString()) Then
                        IdSucursalRemito = Integer.Parse(Pedido(Entidades.PedidoEstado.Columnas.IdSucursalRemito.ToString()).ToString())
                     End If
                     IdTipoComprobanteRemito = Pedido(Entidades.PedidoEstado.Columnas.IdTipoComprobanteRemito.ToString()).ToString()
                     LetraComprobanteRemito = Pedido(Entidades.PedidoEstado.Columnas.LetraRemito.ToString()).ToString()
                     If IsNumeric(Pedido(Entidades.PedidoEstado.Columnas.CentroEmisorRemito.ToString()).ToString()) Then
                        CentroEmisorRemito = Short.Parse(Pedido(Entidades.PedidoEstado.Columnas.CentroEmisorRemito.ToString()).ToString())
                     End If
                     If IsNumeric(Pedido(Entidades.PedidoEstado.Columnas.NumeroComprobanteRemito.ToString()).ToString()) Then
                        NumeroComprobanteRemito = Long.Parse(Pedido(Entidades.PedidoEstado.Columnas.NumeroComprobanteRemito.ToString()).ToString())
                     End If

                     If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                        IdTipoComprobanteFact = oMov.Compra.TipoComprobante.IdTipoComprobante
                        LetraComprobanteFact = oMov.Compra.Letra
                        CentroEmisorFact = oMov.Compra.CentroEmisor
                        NumeroComprobanteFact = oMov.Compra.NumeroComprobante
                     End If
                     If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaRemito Then
                        IdSucursalRemito = oMov.Compra.IdSucursal
                        IdTipoComprobanteRemito = oMov.Compra.TipoComprobante.IdTipoComprobante
                        LetraComprobanteRemito = oMov.Compra.Letra
                        CentroEmisorRemito = oMov.Compra.CentroEmisor
                        NumeroComprobanteRemito = oMov.Compra.NumeroComprobante
                     End If

                     sqlPE.PedidosEstadosProveedores_I(oMov.Compra.IdSucursal,
                                             Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                             Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                             Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                             Long.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                             Prod.IdProducto,
                                             FechaNuevoEstado,
                                             oMov.Compra.Proveedor.IdProveedor,
                                             idEstadoNuevo,
                                             actual.Nombre,
                                             "Facturación Automática",
                                             CantidadProducto,
                                             IdTipoComprobanteFact,
                                             LetraComprobanteFact,
                                             CentroEmisorFact,
                                             NumeroComprobanteFact,
                                             Integer.Parse(Pedido("Orden").ToString()),
                                             Pedido("IdCriticidad").ToString(),
                                             Date.Parse(Pedido("FechaEntrega").ToString()),
                                             tipoTipoComprobante,
                                             numeroReparto:=0,
                                             idSucursalGenerado:=0,
                                             idTipoComprobanteGenerado:=String.Empty,
                                             letraGenerado:=String.Empty,
                                             centroEmisorGenerado:=0,
                                             numeroPedidoGenerado:=0,
                                             idSucursalRemito:=IdSucursalRemito,
                                             idTipoComprobanteRemito:=IdTipoComprobanteRemito,
                                             letraRemito:=LetraComprobanteRemito,
                                             centroEmisorRemito:=CentroEmisorRemito,
                                             numeroComprobanteRemito:=NumeroComprobanteRemito,
                                             idEstadoProducto:=String.Empty, idEstadoCantidad:=String.Empty, idEstadoPrecio:=String.Empty, idEstadoFechaEntrega:=String.Empty,
                                             fechaEstadoProducto:=Nothing, fechaEstadoCantidad:=Nothing, fechaEstadoPrecio:=Nothing, fechaEstadoFechaEntrega:=Nothing)

                     sqlPE.PedidosEstadosProveedores_U_Cantidad(oMov.Compra.IdSucursal,
                                                     Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                     Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                     Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                     Long.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                     Pedido(Entidades.PedidoEstado.Columnas.IdProducto.ToString()).ToString(),
                                                     Integer.Parse(Pedido(Entidades.PedidoEstado.Columnas.Orden.ToString()).ToString()),
                                                     DateTime.Parse(Pedido(Entidades.PedidoEstado.Columnas.FechaEstado.ToString()).ToString()),
                                                     CantidadProducto * -1)

                     rPedidosProductosProveedores.ActualizaCantidadesSegunEstadoAnteriorNuevo(oMov.Compra.IdSucursal,
                                                                     Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                     Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                                     Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                                     Integer.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                                     Prod.IdProducto,
                                                                     Integer.Parse(Pedido("Orden").ToString()),
                                                                     idTipoEstadoAnterior,
                                                                     idTipoEstadoNuevo,
                                                                     CantidadProducto)

                     rPE.RegistraMovimientoStock(oMov.Compra.IdSucursal,
                                             Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                             Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                             Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                             Integer.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                             Prod.IdProducto,
                                             Integer.Parse(Pedido("Orden").ToString()),
                                             idEstadoAnterior, idEstadoNuevo, "PEDIDOSPROV", Decimal.Parse(Pedido("cantEntregada").ToString()),
                                              Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
                  End If
                  If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                     sqlPE.PedidosEstadosProveedores_U_Fact(oMov.Compra.IdSucursal,
                                                 Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                 Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                 Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                 Integer.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                 Prod.IdProducto, FechaNuevoEstado,
                                                 oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                                 Integer.Parse(Pedido("Orden").ToString()))
                  End If
                  If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaRemito Then
                     sqlPE.PedidosEstadosProveedores_U_Remito(oMov.Compra.IdSucursal,
                                                   Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                   Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                   Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                   Integer.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                   Prod.IdProducto, FechaNuevoEstado,
                                                   oMov.Compra.IdSucursal, oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                                   Integer.Parse(Pedido("Orden").ToString()))
                  End If
                  Cont += 1
            End Select
            CantidadProducto = CantidadProducto - Decimal.Parse(Pedido("cantPendiente").ToString())
            If CantidadProducto <= 0 Then
               Exit For '-- Salgo xq no tengo mas cantidad facturada
            End If
         Next
      Next
   End Sub
   Private Sub ActualizoEstadoComprobantesFacturados(oCompras As Entidades.Compra)
      'Cree un entidad nueva para hacerlo mas chiquita, si esta mal borrar!!!
      For Cont = 0 To oCompras.Facturables.Count - 1
         Dim oFact = New Entidades.Facturable()
         'Comprobante que se esta Emitiendo
         oFact.IdSucursal = oCompras.IdSucursal
         oFact.IdTipoComprobante = oCompras.TipoComprobante.IdTipoComprobante
         oFact.Letra = oCompras.Letra 'Si Invoca una Factura con un Remito debe aplicarle "X" y no la Cat.Fiscal
         oFact.CentroEmisor = oCompras.CentroEmisor
         oFact.NumeroComprobante = oCompras.NumeroComprobante
         oFact.IdProveedor = oCompras.Proveedor.IdProveedor

         oFact.IdEstadoComprobante = "FACTURADO"

         'Comprobante que se esta Facturando
         oFact.IdTipoComprobanteFact = oCompras.Facturables(Cont).TipoComprobante.IdTipoComprobante
         oFact.LetraFact = oCompras.Facturables(Cont).Letra
         oFact.CentroEmisorFact = oCompras.Facturables(Cont).CentroEmisor
         oFact.NumeroComprobanteFact = oCompras.Facturables(Cont).NumeroComprobante
         oFact.IdProveedorFact = oCompras.Facturables(Cont).Proveedor.IdProveedor

         oFact.MercEnviada = oCompras.MercEnviada

         ActualizaEstadoFacturables(oFact)
      Next
   End Sub
   Private Sub ActualizaEstadoFacturables(ent As Entidades.Facturable)
      Dim sql = New SqlServer.Compras(da)
      sql.Compras_Facturables_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                ent.IdProveedor, ent.IdEstadoComprobante, ent.IdTipoComprobanteFact,
                                ent.LetraFact, ent.CentroEmisorFact, ent.NumeroComprobanteFact, ent.IdProveedorFact, ent.MercEnviada)
   End Sub
   Friend Sub ActualizaFacturablesDesdeVenta(ent As Entidades.Facturable)
      Dim sql = New SqlServer.Compras(da)
      sql.Compras_Facturables_Venta_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.IdProveedor,
                                      ent.IdSucursal, ent.IdTipoComprobanteFact, ent.LetraFact, ent.CentroEmisorFact, ent.NumeroComprobanteFact)
   End Sub

   Public Sub ActualizaMovimientoCaja(ent As Entidades.Compra)
      Dim sql = New SqlServer.Compras(da)
      sql.Compras_MovimientoCaja_U(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra,
                                   ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.IdProveedor,
                                   ent.IdCaja, ent.NumeroPlanilla, ent.NumeroMovimiento)
   End Sub

   Public Sub ActualizaPlanillaCaja(ent As Entidades.Compra)
      Dim sql = New SqlServer.Compras(da)
      sql.Compras_PlanillaCaja_U(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra,
                                 ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.IdProveedor,
                                 ent.IdCaja, ent.NumeroPlanilla)
   End Sub
#End Region

#Region "Metodos Friend"

   Friend Sub EliminarPorComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      'Obtengo todos los movimientos relacionados al comprobante
      Dim dtMov = New SqlServer.MovimientosStock(da).GetUnoPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, 0)

      If dtMov.Rows.Count > 0 Then
         Dim sql = New SqlServer.MovimientosStock(da)
         Dim sql2 = New SqlServer.MovimientosStockProductos(da)
         Dim ProdSuc = New Reglas.ProductosSucursales(da)
         Dim MovProd = New Reglas.MovimientosStockProductos(da)

         For Each dr As DataRow In dtMov.Rows
            'Por cada movimiento obtengo los productos relacionamos al movimiento
            Dim dtMovProd = MovProd.GetMovimientos(idSucursal, idDeposito:=0, idUbicacion:=0, dr("IdTipoMovimiento").ToString(), Long.Parse(dr("NumeroMovimiento").ToString()))

            For Each m As DataRow In dtMovProd.Rows
               'Ajusto el stock Inicial del producto en cuestion
               ProdSuc.ActualizarStockInicial(idSucursal, m("IdProducto").ToString(), Decimal.Parse(m("Cantidad").ToString()))
            Next

            'Borro todos los productos relacionado en este movimiento (Detalle)
            sql2.MovimientosStockProductos_D(idSucursal,
                                             idDeposito:=0,
                                             Integer.Parse(dr("NumeroMovimiento").ToString()),
                                             dr("IdTipoMovimiento").ToString(),
                                             Long.Parse(dr("NumeroMovimiento").ToString()))


            'Borro el movimiento (Cabecera)
            sql.MovimientosStock_D(idSucursal, dr("IdTipoMovimiento").ToString(), Long.Parse(dr("NumeroMovimiento").ToString()))
         Next
      End If
   End Sub

#End Region
End Class
<Obsolete("Se reemplaza por MovimientosStock", True)>
Public Class MovimientosCompras
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "MovimientosCompras"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   <Obsolete("No usar este método, usar Insertar(Entidad, MetodoGrabacion, String", True)>
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)

   End Sub

   Public Overloads Sub Insertar(entidad As Entidades.Entidad, dtExpensas As DataTable, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.MovimientoStock), dtExpensas, MetodoGrabacion, IdFuncion))
   End Sub


   Public Sub _Insertar(oMov As Entidades.MovimientoStock, dtExpensas As DataTable, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      CargarMovimientoCompra(oMov, MetodoGrabacion, IdFuncion)

      'realiza contra aciento si tuviera una sucursal asociada 
      If oMov.TipoMovimiento.AsociaSucursal Then
         'si tiene el campo CONTRAMOVIMIENTOENVIORECEPCIONSUCURSAL en true en la tabla de Parametros
         If Publicos.ContraMovimientoEnvioRecepcionSucursal And Not String.IsNullOrEmpty(oMov.TipoMovimiento.IdContraTipoMovimiento) Then
            'guardo las sucursales origen y destino en variables
            Dim sucOrigen = oMov.Sucursal
            Dim sucDestino = oMov.Sucursal2
            Dim tipoMov = oMov.TipoMovimiento

            'invierto las sucursales origen y destino
            oMov.Sucursal = sucDestino
            oMov.Sucursal2 = sucOrigen

            Dim oTipoMovimiento = New TiposMovimientos(da)

            oMov.TipoMovimiento = oTipoMovimiento.GetUno(oMov.TipoMovimiento.IdContraTipoMovimiento)

            oMov.ProductosNrosSerie.ForEach(
               Sub(ns)
                  ns.IdSucursal = sucDestino.IdSucursal
                  ns.Sucursal = sucDestino
                  ns.Vendido = False
               End Sub)

            'realizo la carga del movimiento de compra con los cambios de sucursales
            CargarMovimientoCompra(oMov, MetodoGrabacion, IdFuncion)

            'vuelvo las sucursales a su lugar
            oMov.Sucursal = sucOrigen
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


   Public Sub CargarMovimientoCompra(oMov As Entidades.MovimientoStock, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                      IdFuncion As String)

      Dim movNum As Reglas.MovimientosNumeros = New Reglas.MovimientosNumeros(da)

      'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
      'Los Movimientos que no tienen Comprobantes relacionados (ej: AJUSTE), toman el del stock.
      Dim coe As Integer = 1
      If Not String.IsNullOrEmpty(oMov.TipoMovimiento.ComprobantesAsociados) Then
         coe = oMov.Compra.TipoComprobante.CoeficienteValores
      End If

      Dim ctbl As Contabilidad = New Contabilidad(da)

      If oMov.Compra.TipoComprobante.AfectaCaja And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         'Para que se ejecuten las validaciones.
         ''oMov.tablaContabilidad = New ContabilidadProcesos(da).GetRubroVenta(oVentas, False)
         'ctbl.ArmarDetalle(oMov)
      End If


      'Recupero el ultimo numero de movimiento y le sumo uno para el nuevo
      oMov.NumeroMovimiento = movNum.GetUltimoNroMovimiento(oMov.Sucursal.Id, oMov.TipoMovimiento.IdTipoMovimiento) + 1

      'Actualizo los Comprobantes de Compra si el tipo de movimiento tiene comprobantes asociados
      'en caso contrario no togo los comprobantes

      '@@@ Tendriamos que hacer un campo "GrabaLibro".

      If Not String.IsNullOrEmpty(oMov.TipoMovimiento.ComprobantesAsociados) Then

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
            pro.Precio = mcpro.Precio
            pro.DescuentoRecargo = mcpro.DescuentoRecargo
            pro.DescRecGeneral = mcpro.DescRecGeneral
            '--REQ-34986.- ----------------------------------
            pro.IdaAtributoProducto01 = mcpro.IdaAtributoProducto01
            pro.IdaAtributoProducto02 = mcpro.IdaAtributoProducto02
            pro.IdaAtributoProducto03 = mcpro.IdaAtributoProducto03
            pro.IdaAtributoProducto04 = mcpro.IdaAtributoProducto04
            '------------------------------------------------
            'me fijo si los valores grabados son con IVA, se los saco y armo un ComprasProductos nuevo con los valores a grabar bien
            'If (New Reglas.Parametros(da).GetValor("PrecioConIVA").ToUpper() = "SI") Then
            '   pro.PrecioLista = Decimal.Round(pro.PrecioLista / (1 + (oMov.PorcentajeIVA / 100)), 2)
            '   pro.Costo = Decimal.Round(pro.Costo / (1 + (oMov.PorcentajeIVA / 100)), 2)
            'End If

            'If Not oMov.Proveedor.CategoriaFiscal.IvaDiscriminado Then
            '   pro.Precio = Decimal.Round(pro.Precio / (1 + (oMov.PorcentajeIVA / 100)), 2)
            '   pro.DescuentoRecargo = Decimal.Round(pro.DescuentoRecargo / (1 + (oMov.PorcentajeIVA / 100)), 2)
            '   pro.DescRecGeneral = Decimal.Round(pro.DescRecGeneral / (1 + (oMov.PorcentajeIVA / 100)), 2)
            '   pro.ImporteTotal = Decimal.Round(pro.ImporteTotal / (1 + (oMov.PorcentajeIVA / 100)), 2)
            'End If


            '----------------------------------------------------------------
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
            'TODO: Y los demas CAMPOS !!!???
            'Diego: En ventas se hace igual.

            pro.CentroCosto = mcpro.CentroCosto

            Dim ePNS As Entidades.ProductoNroSerie
            For Each eMCPNS In mcpro.ProductosNrosSerie
               ePNS = New Entidades.ProductoNroSerie
               ePNS.Producto.IdProducto = eMCPNS.IdProducto
               ePNS.OrdenCompra = eMCPNS.Orden
               ePNS.NroSerie = eMCPNS.NroSerie
               ePNS.IdSucursal = oMov.Compra.IdSucursal
               ePNS.TipoComprobante.IdTipoComprobante = oMov.Compra.IdTipoComprobante
               ePNS.Letra = oMov.Compra.Letra
               ePNS.CentroEmisor = oMov.Compra.CentroEmisor
               ePNS.NumeroComprobante = oMov.Compra.NumeroComprobante
               pro.Producto.NrosSeries.Add(ePNS)
            Next

            oMov.Compra.ComprasProductos.Add(pro)
         Next
         'graba los comprobantes de compra
         comp.GrabarCompra(oMov.Compra, MetodoGrabacion, IdFuncion)

      End If



      'Actualizo el estado a los Comprobantes Facturados (si existieron)-----------------------------------
      If oMov.Compra.Facturables.Count > 0 Then
         ActualizoEstadoComprobantesFacturados(oMov.Compra)
      End If

      '----------------------------------------------------------------------------------------------------


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
      '---------------------------------------------------------------

      'Actualizo Nros. Serie 
      For Each ns In oMov.ProductosNrosSerie
         ns.TipoComprobante = oMov.Compra.TipoComprobante
         ns.Letra = oMov.Compra.Letra
         ns.CentroEmisor = oMov.Compra.CentroEmisor
         ns.NumeroComprobante = oMov.Compra.NumeroComprobante
         ns.Proveedor = oMov.Proveedor
      Next

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
      'Dim oPro As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
      'Dim oMovProductos As Reglas.MovimientosComprasProductos = New Reglas.MovimientosComprasProductos(da)
      'Dim oCom As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)

      'Dim prodProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores(da)

      Dim blnSumoStock As Boolean = False

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

            'Solo interesa si Suma!!
            'blnSumoStock = True

         End If
      End If

      Dim ComprasObserv As Reglas.ComprasObservaciones = New Reglas.ComprasObservaciones(da)

      For Each Observ As Entidades.CompraObservacion In oMov.Compra.ComprasObservaciones

         Observ.IdTipoComprobante = oMov.Compra.TipoComprobante.IdTipoComprobante
         Observ.Letra = oMov.Compra.Letra
         Observ.CentroEmisor = oMov.Compra.CentroEmisor
         Observ.NumeroComprobante = oMov.Compra.NumeroComprobante
         Observ.Proveedor = oMov.Compra.Proveedor

         'grabo las observaciones del comprobante de venta
         ComprasObserv.EjecutaSP(Observ, TipoSP._I)
      Next

      'Pedidos
      '-- REQ-33882.- Se cambia de Pedido a PedidoProv.- -----------------------------------------------------------------------------------------
      If blnSumoStock And Publicos.PedidosProvFacturarAutomatico And Not oMov.Observacion.Contains("Generado por Cambio de Estado de pedido") Then
         FacturarPedidos(oMov, IdFuncion)
      End If


      If oMov.Compra.TipoComprobante.GeneraContabilidad And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         'ctbl.RegistraContabilidadCompras(oMov.Compra.IdSucursal,
         '                                 oMov.Compra.TipoComprobante.IdTipoComprobante,
         '                                 oMov.Compra.Letra,
         '                                 oMov.Compra.CentroEmisor,
         '                                 oMov.Compra.NumeroComprobante,
         '                                 oMov.Compra.Proveedor.IdProveedor)   ''CargarContabilidad(oMov)
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

               Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv(da)
               oCtaCte.GrabaCuentaCorrienteProv(oMov.Compra.CuentaCorrienteProv, MetodoGrabacion, IdFuncion)
            End If
            Dim rCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv(da)
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
                  .Conciliado = oMov.Compra.Conciliado
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

               rCtaCte.Inserta(oCtaCte, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

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
                     ' .IdTipoMovimiento = "E"c  -- Lo determino más abajo según el signo del importe.
                     Dim coeCaja = 0
                     If oMov.Compra.ImporteChequesTerceros + oMov.Compra.ImporteTarjetas + oMov.Compra.ImportePesos + oMov.Compra.ImporteTransfBancaria + oMov.Compra.ImporteChequesPropios > 0 Then
                        .IdTipoMovimiento = "E"c
                        coeCaja = 1
                     Else
                        .IdTipoMovimiento = "I"c
                        coeCaja = -1
                     End If
                     .NumeroPlanilla = caj.GetPlanillaActual(oMov.Compra.IdSucursal, oMov.IdCaja).NumeroPlanilla
                     .Observacion = Strings.Left(oMov.Compra.TipoComprobante.Descripcion & " " & oMov.Compra.Letra & " " & oMov.Compra.CentroEmisor.ToString() &
                               "-" & oMov.Compra.NumeroComprobante.ToString("00000000") &
                               IIf(oMov.Compra.ChequesTerceros.Count > 0, " - Cant.Cheq.Terc.: " + oMov.Compra.ChequesTerceros.Count.ToString(), "").ToString() &
                               IIf(oMov.Compra.ChequesPropios.Count > 0, " - Cant.Cheq.Prop.: " + oMov.Compra.ChequesPropios.Count.ToString(), "").ToString() &
                               IIf(oMov.Compra.ImporteTransfBancaria > 0, " - Transf.Desde: " & oMov.Compra.CuentaBancariaTransfBanc.NombreCuenta, "").ToString() &
                               ". " & oMov.Compra.Proveedor.NombreProveedor, 100)
                     '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor(Parametro.Parametros.CTACAJACOMPRAS))
                     .IdCuentaCaja = oMov.Proveedor.CuentaDeCaja.IdCuentaCaja
                     .ImporteCheques = oMov.Compra.ImporteChequesTerceros * coeCaja
                     .ImporteTarjetas = oMov.Compra.ImporteTarjetas * coeCaja
                     .ImportePesos = oMov.Compra.ImportePesos * coeCaja
                     .ImporteBancos = (oMov.Compra.ImporteTransfBancaria + oMov.Compra.ImporteChequesPropios) * coeCaja
                     '-- REQ35989.- ------------------------------------------------------------------
                     If oMov.Compra.ImporteTransfBancaria <> 0 Then
                        .IdMonedaImporteBancos = oMov.Compra.CuentaBancariaTransfBanc.Moneda.IdMoneda
                     End If
                     '--------------------------------------------------------------------------------
                     .ImporteDolares = 0 * coeCaja

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

                  'If oMov.Compra.ImporteTransfBancaria > 0 Then

                  '   With deta
                  '      .FechaMovimiento = oMov.Compra.Fecha    'Date.Now
                  '      .IdSucursal = oMov.Compra.IdSucursal
                  '      .IdTipoMovimiento = "I"c
                  '      .IdCaja = oMov.IdCaja
                  '      .NumeroPlanilla = caj.GetPlanillaActual(oMov.Compra.IdSucursal, oMov.IdCaja).NumeroPlanilla
                  '      .ImportePesos = oMov.Compra.ImporteTransfBancaria
                  '      .ImporteCheques = 0
                  '      .ImporteTickets = 0
                  '      .ImporteTarjetas = 0
                  '      .Observacion = Strings.Left(oMov.Compra.TipoComprobante.Descripcion & " " & oMov.Compra.Letra & " " & oMov.Compra.CentroEmisor.ToString() & "-" & oMov.Compra.NumeroComprobante.ToString("00000000") & " - Transf. a cuenta: " & oMov.Compra.CuentaBancariaTransfBanc.NombreCuenta & ". " & oMov.Proveedor.NombreProveedor, 100)
                  '      .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJATRANSFBANCARIA))
                  '      .EsModificable = False
                  '      .Usuario = actual.Nombre
                  '   End With

                  '   cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

                  'End If


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

                     If oMov.Compra.ImporteTransfBancaria <> 0 Then

                        With entLibroBanco
                           .IdSucursal = oMov.Compra.IdSucursal
                           .IdCuentaBancaria = oMov.Compra.CuentaBancariaTransfBanc.IdCuentaBancaria
                           .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

                           If oMov.Compra.Proveedor.CuentaBanco.IdCuentaBanco <> 0 Then
                              .IdCuentaBanco = oMov.Compra.Proveedor.CuentaBanco.IdCuentaBanco
                           Else
                              .IdCuentaBanco = Reglas.Publicos.CtaBancoTransfBancaria
                           End If
                           If oMov.Compra.ImporteTransfBancaria > 0 Then
                              .IdTipoMovimiento = "E"
                              .Importe = oMov.Compra.ImporteTransfBancaria
                           Else
                              .IdTipoMovimiento = "I"
                              .Importe = oMov.Compra.ImporteTransfBancaria
                           End If
                           .FechaMovimiento = oMov.Compra.Fecha
                           .IdCheque = Nothing
                           .FechaAplicado = oMov.Compra.Fecha
                           '.Observacion = ent.Observacion
                           .Observacion = Strings.Left(oMov.Compra.TipoComprobante.Descripcion & " " & oMov.Compra.Letra & " " & oMov.Compra.CentroEmisor.ToString() & "-" & oMov.Compra.NumeroComprobante.ToString("00000000") & " - Transf. desde: " & ". " & oMov.Proveedor.NombreProveedor, 100)
                           .Conciliado = oMov.Compra.Conciliado
                        End With

                        oLibroBancos.AgregaMovimiento(entLibroBanco)

                     End If

                  End If
               End If
            End If
         End If
      End If

      If oMov.Compra.TipoComprobante.AfectaCaja And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         'ctbl.MarcarCtaCteRegistroProcesado(oMov)
      End If

   End Sub

   Public Sub GrabaMovimientoStock(oMov As Entidades.MovimientoCompra)

      Dim oPro As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
      Dim oMovProductos As Reglas.MovimientosComprasProductos = New Reglas.MovimientosComprasProductos(da)
      'Dim oCom As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
      Dim prodProv As Reglas.ProductosProveedores = New Reglas.ProductosProveedores(da)
      Dim rMCPNS As Reglas.MovimientosComprasProductosNrosSerie = New Reglas.MovimientosComprasProductosNrosSerie(da)

      Dim Posicion As Integer = 0
      Dim Precio As Decimal

      For Each pro As Entidades.MovimientoCompraProducto In oMov.Productos

         pro.MovimientoCompra = oMov

         pro.Cantidad = pro.Cantidad * oMov.TipoMovimiento.CoeficienteStock
         pro.CantidadReservado = pro.CantidadReservado * oMov.TipoMovimiento.CoeficienteStock
         pro.CantidadDefectuoso = pro.CantidadDefectuoso * oMov.TipoMovimiento.CoeficienteStock
         pro.CantidadFuturo = pro.CantidadFuturo * oMov.TipoMovimiento.CoeficienteStock
         pro.CantidadFuturoReservado = pro.CantidadFuturoReservado * oMov.TipoMovimiento.CoeficienteStock

         If pro.ProductoSucursal.Producto.PrecioPorEmbalaje Then
            pro.Cantidad = pro.Cantidad * pro.ProductoSucursal.Producto.Embalaje
            pro.CantidadReservado = pro.CantidadReservado * pro.ProductoSucursal.Producto.Embalaje
            pro.CantidadDefectuoso = pro.CantidadDefectuoso * pro.ProductoSucursal.Producto.Embalaje
            pro.CantidadFuturo = pro.CantidadFuturo * pro.ProductoSucursal.Producto.Embalaje
            pro.CantidadFuturoReservado = pro.CantidadFuturoReservado * pro.ProductoSucursal.Producto.Embalaje
         End If


         ' TODO: DIEGO Existe otra forma ? Asignarlo en otro lado ?
         'En el movimiento grabo el precio final. No hace falta el detalle de los Descuentos
         Precio = pro.Precio

         If Not String.IsNullOrEmpty(oMov.TipoMovimiento.ComprobantesAsociados) Then
            pro.Precio = oMov.Compra.ComprasProductos(Posicion).PrecioNeto
         End If

         Posicion += 1

         'Inserto el detalle del movimiento
         oMovProductos.EjecutaSP(pro, TipoSP._I)

         '# Grabo el movimiento para los productos c/ Nro. Serie
         For Each ePNS As Entidades.MovimientoCompraProductoNroSerie In pro.ProductosNrosSerie
            ePNS.IdSucursal = oMov.Sucursal.Id
            ePNS.IdTipoMovimiento = oMov.TipoMovimiento.IdTipoMovimiento
            ePNS.NumeroMovimiento = oMov.NumeroMovimiento
            ePNS.Orden = pro.Orden
            ePNS.Cantidad = CInt((pro.Cantidad / Math.Abs(pro.Cantidad)))
            rMCPNS._Inserta(ePNS)
         Next

         oPro.ActualizarStock(pro.MovimientoCompra.Sucursal.Id, pro.IdProducto, pro.Cantidad, pro.CantidadReservado,
                              pro.CantidadDefectuoso, pro.CantidadFuturo, pro.CantidadFuturoReservado,
                              pro.IdaAtributoProducto01, pro.IdaAtributoProducto02, pro.IdaAtributoProducto03, pro.IdaAtributoProducto04)

         'Vuelvo el precio porque al modificarlo en el objeto se cambia en pantalla y no queda prolijo. Aunque si diera error antes de esta linea volveria mal.
         pro.Precio = Precio

         'vuelvo la cantidad a su valor original
         pro.Cantidad = pro.Cantidad * oMov.TipoMovimiento.CoeficienteStock

         'Actualizo el precio de ultima compra en ProductoProveedores

         Dim dt1 As DataTable
         Dim PrecioNeto As Decimal = pro.Precio

         If pro.DescuentoRecargoPorc <> 0 Or oMov.DescuentoRecargo <> 0 Then
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + pro.DescuentoRecargoPorc / 100), 2)
            PrecioNeto = Decimal.Round(PrecioNeto * (1 + oMov.DescuentoRecargo / 100), 2)
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

   Public Sub GrabarMovimientoProduccion(oMov As Entidades.MovimientoCompra)

      Dim movNum As Reglas.MovimientosNumeros = New Reglas.MovimientosNumeros(da)

      'Recupero el ultimo numero de movimiento y le sumo uno para el nuevo
      oMov.NumeroMovimiento = movNum.GetUltimoNroMovimiento(oMov.Sucursal.Id, oMov.TipoMovimiento.IdTipoMovimiento) + 1



      ''actualizo los Lotes ------------------------------------------
      'Dim proLot As Reglas.ProductosLotes = New Reglas.ProductosLotes(da)
      ''modifico las cantidades de los lotes según el tipo de movimiento que se ingreso
      'For Each pl As Entidades.ProductoLote In oMov.ProductosLotes
      '   pl.CantidadActualOriginal = pl.CantidadActual
      '   pl.ProductoSucursal.Sucursal = oMov.Sucursal
      '   pl.CantidadActual = pl.CantidadActual * oMov.TipoMovimiento.CoeficienteStock
      'Next
      'proLot.ActualizoLotes(oMov.ProductosLotes)
      'For Each pl As Entidades.ProductoLote In oMov.ProductosLotes
      '   pl.CantidadActual = pl.CantidadActualOriginal
      'Next

      '---------------------------------------------------------------

      'actualizo los Nros. de Serie
      'Dim proNS As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie(da)
      'proNS.InsertoVariosNrosSerie(oMov.ProductosNrosSerie)

      ''Actualizo el número de movimiento en la tabla MovimientosNumeros
      Dim oMovNum As Entidades.MovimientoNumero = New Entidades.MovimientoNumero()
      oMovNum.Sucursal = oMov.Sucursal
      oMovNum.TipoMovimiento = oMov.TipoMovimiento
      oMovNum.Numero = oMov.NumeroMovimiento
      movNum.ActualizarNumero(oMovNum)

      'Grabo la cabecera del movimiento
      Me.EjecutaSP(oMov, TipoSP._I)

      'Grabo el detalle del movimiento
      Dim oPro As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
      Dim oMovProductos As Reglas.MovimientosComprasProductos = New Reglas.MovimientosComprasProductos(da)
      Dim oCom As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)

      If oMov.TipoMovimiento.CoeficienteStock <> 0 Then

         Dim Posicion As Integer
         Posicion = 0

         Dim Precio As Decimal

         For Each pro As Entidades.MovimientoCompraProducto In oMov.Productos

            pro.MovimientoCompra = oMov

            pro.Cantidad = pro.Cantidad * oMov.TipoMovimiento.CoeficienteStock

            pro.Orden = Posicion + 1

            Precio = pro.Precio

            Posicion = Posicion + 1

            ''Inserto el detalle del movimiento
            oMovProductos.EjecutaSP(pro, TipoSP._I)

            oPro.ActualizarStock(pro.MovimientoCompra.Sucursal.Id, pro.IdProducto, pro.Cantidad, 0, 0, 0, 0, pro.IdaAtributoProducto01, pro.IdaAtributoProducto02, pro.IdaAtributoProducto03, pro.IdaAtributoProducto04)

            If Not String.IsNullOrWhiteSpace(pro.IdLote) Then
               Dim rProdLote = New ProductosLotes(da)
               rProdLote.ProductosLotes_UCantidad_Delta(pro.IdLote, pro.MovimientoCompra.Sucursal.Id, pro.IdProducto, pro.Cantidad)
            End If


            'Vuelvo el precio porque al modificarlo en el objeto se cambia en pantalla y no queda prolijo. Aunque si diera error antes de esta linea volveria mal.
            pro.Precio = Precio

            'vuelvo la cantidad a su valor original
            pro.Cantidad = pro.Cantidad * oMov.TipoMovimiento.CoeficienteStock

         Next

      End If

   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      ''Me.EjecutaSP(DirectCast(entidad, Entidades.MovimientoCompra), TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      ''Me.EjecutaSP(DirectCast(entidad, Entidades.MovimientoCompra), TipoSP._D)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(movimiento As Entidades.MovimientoStock, tipo As TipoSP)
      Try
         Dim sql = New SqlServer.MovimientosStock(da)
         sql.MovimientosCompras_I(movimiento.Sucursal.Id, movimiento.TipoMovimiento.IdTipoMovimiento,
                        movimiento.NumeroMovimiento, movimiento.FechaMovimiento,
                        movimiento.Total, movimiento.PorcentajeIVA,
                        movimiento.Proveedor.IdProveedor, movimiento.Proveedor.CategoriaFiscal.IdCategoriaFiscal,
                        movimiento.Compra.TipoComprobante.IdTipoComprobante, movimiento.Compra.Letra,
                        movimiento.Compra.CentroEmisor, movimiento.Compra.NumeroComprobante, movimiento.Sucursal2.Id,
                        movimiento.Usuario, movimiento.Observacion, movimiento.PercepcionIVA, movimiento.PercepcionIB,
                        movimiento.PercepcionGanancias, movimiento.PercepcionVarias, movimiento.IdProduccion,
                        movimiento.IdEmpleado, movimiento.ImpuestosInternos)

      Catch
         Throw
      End Try
   End Sub

   Public Function GetUnoPorComprobante(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Short,
                                             numeroComprobante As Long,
                                             IdProveedor As Long) As Entidades.MovimientoCompra

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT idSucursal")
         .AppendLine("      ,IdTipoMovimiento")
         .AppendLine("      ,NumeroMovimiento")
         .AppendLine("      ,FechaMovimiento")
         .AppendLine("      ,IdProveedor")
         .AppendLine("      ,IdTipoComprobante")
         .AppendLine("      ,Letra")
         .AppendLine("      ,CentroEmisor")
         .AppendLine("      ,NumeroComprobante")
         .AppendLine("      ,Usuario")
         .AppendLine("      ,Observacion")
         .AppendLine(" FROM MovimientosCompras")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
      End With

      Dim dt As DataTable = da.GetDataTable(stb.ToString())

      Dim oMovCompra As Entidades.MovimientoCompra = New Entidades.MovimientoCompra()

      If dt.Rows.Count > 0 Then
         With oMovCompra
            .IdSucursal = Integer.Parse(dt.Rows(0)("IdSucursal").ToString())
            .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno(dt.Rows(0)("IdTipoMovimiento").ToString())
            .NumeroMovimiento = Integer.Parse(dt.Rows(0)("NumeroMovimiento").ToString())
            .FechaMovimiento = Date.Parse(dt.Rows(0)("FechaMovimiento").ToString())
            .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dt.Rows(0)("IdProveedor").ToString()))
            .Compra = New Reglas.Compras(da).GetUna(.IdSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, IdProveedor)

         End With

         With stb
            .Length = 0
            .AppendLine("SELECT idSucursal")
            .AppendLine("      ,IdTipoMovimiento")
            .AppendLine("      ,NumeroMovimiento")
            .AppendLine("      ,Orden")
            .AppendLine("      ,IdLote")
            .AppendLine("      ,IdProducto")
            .AppendLine("      ,Cantidad")
            .AppendLine("      ,Precio")
            '-- REQ-34987.- ---------------------------------------------------
            .AppendLine("      ,IdaAtributoProducto01")
            .AppendLine("      ,IdaAtributoProducto02")
            .AppendLine("      ,IdaAtributoProducto03")
            .AppendLine("      ,IdaAtributoProducto04")
            '------------------------------------------------------------------
            .AppendLine("  FROM MovimientosComprasProductos")
            .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND IdTipoMovimiento = '" & oMovCompra.TipoMovimiento.IdTipoMovimiento & "'")
            .AppendLine("   AND NumeroMovimiento = " & oMovCompra.NumeroMovimiento.ToString())
         End With

         Dim dtMovComPro As DataTable = da.GetDataTable(stb.ToString())
         Dim oMVP As Entidades.MovimientoCompraProducto
         For Each dr As DataRow In dtMovComPro.Rows
            oMVP = New Entidades.MovimientoCompraProducto()
            With oMVP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .MovimientoCompra = oMovCompra
               .ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(Integer.Parse(dr("IdSucursal").ToString()), dr("IdProducto").ToString())
               .IdLote = dr.Field(Of String)(Entidades.MovimientoCompraProducto.Columnas.IdLote.ToString())
               .IdProducto = .ProductoSucursal.Producto.IdProducto
               .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               .Precio = Decimal.Parse(dr("Precio").ToString())
               .IdaAtributoProducto01 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto01").ToString()))
               .IdaAtributoProducto02 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto02").ToString()))
               .IdaAtributoProducto03 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto03").ToString()))
               .IdaAtributoProducto04 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto04").ToString()))
            End With
            oMovCompra.Productos.Add(oMVP)
         Next
      Else
         Throw New Exception("No existe este comprobante de compra.")
      End If

      Return oMovCompra

   End Function

   Private Sub CargarUno(o As Entidades.MovimientoCompra, dr As DataRow)
      With o

         .IdSucursal = Integer.Parse(dr(Entidades.MovimientoCompra.Columnas.IdSucursal.ToString()).ToString())
         .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno(dr(Entidades.MovimientoCompra.Columnas.IdTipoMovimiento.ToString()).ToString())
         .NumeroMovimiento = Long.Parse(dr(Entidades.MovimientoCompra.Columnas.NumeroMovimiento.ToString()).ToString())
         .FechaMovimiento = DateTime.Parse(dr(Entidades.MovimientoCompra.Columnas.FechaMovimiento.ToString()).ToString())
         .Total = Decimal.Parse(dr(Entidades.MovimientoCompra.Columnas.Total.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoCompra.Columnas.PorcentajeIVA.ToString()).ToString()) Then
            .PorcentajeIVA = Decimal.Parse(dr(Entidades.MovimientoCompra.Columnas.PorcentajeIVA.ToString()).ToString())
         End If
         '.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Short.Parse(dr(Entidades.MovimientoCompra.Columnas.IdCategoriaFiscal.ToString()).ToString()))
         .Usuario = dr(Entidades.MovimientoCompra.Columnas.Usuario.ToString()).ToString()
         .Observacion = dr(Entidades.MovimientoCompra.Columnas.Observacion.ToString()).ToString()
         .PercepcionIVA = Decimal.Parse(dr(Entidades.MovimientoCompra.Columnas.PercepcionIVA.ToString()).ToString())
         .PercepcionIB = Decimal.Parse(dr(Entidades.MovimientoCompra.Columnas.PercepcionIB.ToString()).ToString())
         .PercepcionGanancias = Decimal.Parse(dr(Entidades.MovimientoCompra.Columnas.PercepcionGanancias.ToString()).ToString())
         .PercepcionVarias = Decimal.Parse(dr(Entidades.MovimientoCompra.Columnas.PercepcionVarias.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoCompra.Columnas.IdProduccion.ToString()).ToString()) Then
            .IdProduccion = Integer.Parse(dr(Entidades.MovimientoCompra.Columnas.IdProduccion.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoCompra.Columnas.IdProveedor.ToString()).ToString()) Then
            .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dr(Entidades.MovimientoCompra.Columnas.IdProveedor.ToString()).ToString()))
         End If

         '  Dim IdEmpleado As Integer = Integer.Parse(dr(Entidades.MovimientoCompra.Columnas.IdEmpleado.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovimientoCompra.Columnas.IdEmpleado.ToString()).ToString()) Then
            .Empleado = New Reglas.Empleados(da).GetUno(Integer.Parse(dr(Entidades.MovimientoCompra.Columnas.IdEmpleado.ToString()).ToString()))
         End If

         .Productos = New Reglas.MovimientosComprasProductos(da).GetTodos(.IdSucursal, .TipoMovimiento.IdTipoMovimiento, .NumeroMovimiento)

         If IsNumeric(dr(Entidades.MovimientoCompra.Columnas.IdSucursal2.ToString())) Then
            .Sucursal2 = New Reglas.Sucursales(da).GetUna(Integer.Parse(dr(Entidades.MovimientoCompra.Columnas.IdSucursal2.ToString()).ToString()), False)
         End If
         .ImpuestosInternos = Decimal.Parse(dr(Entidades.MovimientoCompra.Columnas.ImpuestosInternos.ToString()).ToString())

      End With
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idTipoMovimiento As String,
                          NumeroMovimiento As Long) As Entidades.MovimientoCompra
      Dim dt As DataTable = New SqlServer.MovimientosCompras(da).MovimientosCompras_G1(idSucursal, idTipoMovimiento, NumeroMovimiento)
      Dim o As Entidades.MovimientoCompra = New Entidades.MovimientoCompra()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetUnoPorProduccion(idSucursal As Integer,
                                            idTipoMovimiento As String,
                                            NumeroMovimiento As Long) As Entidades.MovimientoCompra

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT idSucursal")
         .AppendLine("      ,IdTipoMovimiento")
         .AppendLine("      ,NumeroMovimiento")
         .AppendLine("      ,FechaMovimiento")
         .AppendLine("      ,IdProveedor")
         .AppendLine("      ,IdTipoComprobante")
         .AppendLine("      ,Letra")
         .AppendLine("      ,CentroEmisor")
         .AppendLine("      ,NumeroComprobante")
         .AppendLine("      ,Usuario")
         .AppendLine("      ,Observacion")
         .AppendLine(" FROM MovimientosCompras")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoMovimiento = '" & idTipoMovimiento & "'")
         .AppendLine("   AND NumeroMovimiento = " & NumeroMovimiento.ToString())
      End With

      Dim dt = da.GetDataTable(stb.ToString())

      Dim oMovCompra As Entidades.MovimientoCompra = New Entidades.MovimientoCompra()

      If dt.Rows.Count > 0 Then
         With oMovCompra
            .IdSucursal = Integer.Parse(dt.Rows(0)("IdSucursal").ToString())
            .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno(dt.Rows(0)("IdTipoMovimiento").ToString())
            .NumeroMovimiento = Integer.Parse(dt.Rows(0)("NumeroMovimiento").ToString())
            .FechaMovimiento = Date.Parse(dt.Rows(0)("FechaMovimiento").ToString())
            '.Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dt.Rows(0)("IdProveedor").ToString()))
         End With

         With stb
            .Length = 0

            .AppendLine("SELECT idSucursal")
            .AppendLine("      ,IdTipoMovimiento")
            .AppendLine("      ,NumeroMovimiento")
            .AppendLine("      ,Orden")
            .AppendLine("      ,IdProducto")
            .AppendLine("      ,Cantidad")
            .AppendLine("      ,Precio")

            .AppendLine("  FROM MovimientosComprasProductos")
            .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND IdTipoMovimiento = '" & oMovCompra.TipoMovimiento.IdTipoMovimiento & "'")
            .AppendLine("   AND NumeroMovimiento = " & oMovCompra.NumeroMovimiento.ToString())

         End With

         Dim dtMovComPro = da.GetDataTable(stb.ToString())
         Dim oMVP As Entidades.MovimientoCompraProducto
         For Each dr As DataRow In dtMovComPro.Rows
            oMVP = New Entidades.MovimientoCompraProducto()
            With oMVP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .MovimientoCompra = oMovCompra
               .IdProducto = dr("IdProducto").ToString()
               .Orden = Integer.Parse(dr("Orden").ToString())
               .ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(Integer.Parse(dr("IdSucursal").ToString()), dr("IdProducto").ToString())
               .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               .Precio = Decimal.Parse(dr("Precio").ToString())
            End With
            oMovCompra.Productos.Add(oMVP)
         Next
      Else
         Throw New Exception("No existe este comprobante de compra.")
      End If

      Return oMovCompra

   End Function

   Public Function GetMovimientosProduccion(idSucursal As Integer,
                                          idProduccion As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT idSucursal")
         .AppendLine("      ,IdTipoMovimiento")
         .AppendLine("      ,NumeroMovimiento")
         .AppendLine("      ,FechaMovimiento")
         .AppendLine("      ,IdProveedor")
         .AppendLine("      ,IdTipoComprobante")
         .AppendLine("      ,Letra")
         .AppendLine("      ,CentroEmisor")
         .AppendLine("      ,NumeroComprobante")
         .AppendLine("      ,Usuario")
         .AppendLine("      ,Observacion")
         .AppendLine(" FROM MovimientosCompras")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProduccion = " & idProduccion)
      End With

      Dim dt As DataTable = da.GetDataTable(stb.ToString())

      Return dt

   End Function

   Public Sub EliminarMovimientosCompras(movcompras As Entidades.MovimientoCompra)
      Dim sql As SqlServer.MovimientosCompras = New SqlServer.MovimientosCompras(da)
      sql.MovimientosCompras_D(movcompras.IdSucursal, movcompras.TipoMovimiento.IdTipoMovimiento, movcompras.NumeroMovimiento)
   End Sub

   Public Sub EliminarMovimientosComprasProduccion(movcompras As Entidades.MovimientoCompra)
      Dim sql As SqlServer.MovimientosCompras = New SqlServer.MovimientosCompras(da)
      sql.MovimientosCompras_D(movcompras.IdSucursal, movcompras.TipoMovimiento.IdTipoMovimiento, movcompras.NumeroMovimiento)
   End Sub

   Private Sub ActualizoInfoDeCheques(omov As Entidades.MovimientoCompra)

      Dim sqlCompraCheq As SqlServer.ComprasCheques = New SqlServer.ComprasCheques(da)

      Dim sqlCheques As SqlServer.Cheques = New SqlServer.Cheques(da)

      'graba los cheques de la venta y su relacion
      For Each ch As Entidades.Cheque In omov.Compra.ChequesPropios
         'si el cheque no existe lo ingreso a las tablas del sistema
         ch.IdSucursal = omov.Compra.IdSucursal
         ch.IdEstadoCheque = Entidades.Cheque.Estados.PROVEEDOR

         If Not sqlCheques.Existe(omov.IdSucursal, ch.NumeroCheque, ch.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.Cuit) Then
            Dim rCheques As New Reglas.Cheques(da)
            rCheques._Inserta(ch)
            ''sqlCheques.Cheques_I(ch.IdSucursal, ch.IdCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad,
            ''                        ch.NumeroCheque, ch.FechaEmision, ch.FechaCobro, ch.Titular, ch.Importe,
            ''                        Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, True, ch.CuentaBancaria.IdCuentaBancaria, ch.IdEstadoCheque,
            ''                       ch.Cliente.IdCliente, omov.Compra.Proveedor.IdProveedor, ch.Cuit, 0, actual.Nombre,
            ''                       ch.IdTipoCheque, ch.NroOperacion)

         End If


         sqlCompraCheq.ComprasCheques_I(omov.Compra.IdSucursal, omov.Compra.TipoComprobante.IdTipoComprobante,
                              omov.Compra.Letra, omov.Compra.CentroEmisor, omov.Compra.NumeroComprobante,
                              omov.Compra.Proveedor.IdProveedor,
                              ch.NumeroCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.IdCheque)

         '# Luego de registrar un Cheque Propio, actualizo el numerador de último cheque registrado en mi chequera
         Dim rChequeras As Reglas.Chequeras = New Reglas.Chequeras(da)
         rChequeras.ActualizarNumeroActual(ch.IdChequera.Value, ch.NumeroCheque)
      Next


      Dim oCheqTercero As Reglas.Cheques = New Reglas.Cheques(da)

      For Each cheq As Entidades.Cheque In omov.Compra.ChequesTerceros
         cheq.IdSucursal = omov.Compra.IdSucursal
         cheq.IdEstadoCheque = Entidades.Cheque.Estados.PROVEEDOR


         sqlCompraCheq.ComprasCheques_I(omov.Compra.IdSucursal, omov.Compra.TipoComprobante.IdTipoComprobante,
                              omov.Compra.Letra, omov.Compra.CentroEmisor, omov.Compra.NumeroComprobante,
                              omov.Compra.Proveedor.IdProveedor,
                              cheq.NumeroCheque, cheq.Banco.IdBanco, cheq.IdBancoSucursal, cheq.Localidad.IdLocalidad, cheq.IdCheque)

      Next

      'Dim sqlVentasCheqRech As SqlServer.VentasChequesRechazados = New SqlServer.VentasChequesRechazados(da)
      'Dim sqlLibroBanco As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)
      ''graba los cheques de la venta y su relacion
      'For Each ch As Entidades.Cheque In oVentas.ChequesRechazados

      '   sqlVentasCheqRech.VentasChequesRechazados_I(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, _
      '                                                oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, _
      '                                                oVentas.NumeroComprobante, ch.NumeroCheque, ch.Banco.IdBanco, _
      '                                                ch.IdBancoSucursal, ch.Localidad.IdLocalidad)

      '   'Si no estaba en banco, no afecta ningun registro
      '   sqlLibroBanco.LibroBancos_UImporteCheque(oVentas.IdSucursal, ch.Banco.IdBanco, ch.IdBancoSucursal, _
      '                                             ch.Localidad.IdLocalidad, ch.NumeroCheque, 0)

      '   sqlCheques.Cheques_ActualizaEstado(oVentas.IdSucursal, ch.Banco.IdBanco, ch.IdBancoSucursal, _
      '                                             ch.Localidad.IdLocalidad, ch.NumeroCheque, Cheque.Estados.RECHAZADO)

      'Next
   End Sub

   Private Sub FacturarPedidos(oMov As Eniac.Entidades.MovimientoCompra, idFuncion As String)

      Try

         Dim tablaPedidos As DataTable
         Dim sql As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
         Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)

         Dim rPedidosProductosProveedores As Reglas.PedidosProductosProveedores = New Reglas.PedidosProductosProveedores(da)
         Dim rPE As PedidosEstadosProveedores = New PedidosEstadosProveedores(da)

         Dim FechaNuevoEstado As Date '= Date.Now
         Dim CantidadProducto As Decimal = 0
         Dim Cont As Integer = 0

         'TODO: Hay que ver como parametrizar esto diferente
         'SPC: Hay que ver como parametrizar esto diferente
         Dim tipoTipoComprobante As String = "PEDIDOSPROV"
         'DP: Lo comento por ahora que solo vamos a Facturar Pedidos, cuando tengamos que Facturar Presupuestos por ejemplo.
         'If oVenta.VentasProductos.Count > 0 Then
         '   tipoTipoComprobante = oVenta.TipoComprobante.Tipo '  New Reglas.TiposComprobantes(da).GetUno(PedidosEstados.Rows(0)("IdTipoComprobante").ToString()).Tipo
         'End If

         Dim idEstadoAnterior As String = Publicos.PedidoProveedorEstadoAFacturar
         Dim idTipoEstadoAnterior As String = New EstadosPedidosProveedores().GetUno(idEstadoAnterior, tipoTipoComprobante).IdTipoEstado
         Dim idEstadoNuevo As String = Publicos.PedidoProveedorEstadoFacturado
         Dim idTipoEstadoNuevo As String = New EstadosPedidosProveedores().GetUno(idEstadoNuevo, tipoTipoComprobante).IdTipoEstado

         ' para cada producto de la factura busco los pedidos pendientes.
         For Each Prod As Entidades.MovimientoCompraProducto In oMov.Productos

            Dim pedidos As Entidades.Compra() = {}
            If Reglas.Publicos.Facturacion.FacturarPedidoSeleccionado Then
               pedidos = oMov.Compra.Facturables.ToArray()
            End If

            tablaPedidos = sql.GetPedidosXProveedorProducto(oMov.Compra.IdSucursal _
                                                         , idEstadoAnterior _
                                                         , Prod.IdProducto _
                                                         , oMov.Proveedor.IdProveedor,
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
                     End If         'If oVenta.TipoComprobante.InvocarPedidosConEstadoEspecifico Then


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
                     End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
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
                     End If         'If oVenta.TipoComprobante.InvocarPedidosConEstadoEspecifico Then

                     If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                        sqlPE.PedidosEstadosProveedores_U_Fact(oMov.Compra.IdSucursal,
                                                    Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                    Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                    Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                    Integer.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                    Prod.IdProducto, FechaNuevoEstado,
                                                    oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                                    Integer.Parse(Pedido("Orden").ToString()))
                     End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                     If oMov.Compra.TipoComprobante.AlInvocarPedidoAfectaRemito Then
                        sqlPE.PedidosEstadosProveedores_U_Remito(oMov.Compra.IdSucursal,
                                                      Pedido(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                      Pedido(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                                      Integer.Parse(Pedido(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                                      Integer.Parse(Pedido(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                                      Prod.IdProducto, FechaNuevoEstado,
                                                      oMov.Compra.IdSucursal, oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante,
                                                      Integer.Parse(Pedido("Orden").ToString()))
                     End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then


                     'sql.InsertaEstadoPedido(oMov.Compra.IdSucursal, _
                     '                        Integer.Parse(Pedido("IdPedido").ToString()) _
                     '                        , Prod.IdProducto _
                     '                        , FechaNuevoEstado _
                     '                        , "ENTREGADO" _
                     '                        , actual.Nombre _
                     '                        , "Facturación Automática" _
                     '                        , CantidadProducto _
                     '                        , oMov.Compra.TipoComprobante.IdTipoComprobante _
                     '                        , oMov.Compra.Letra _
                     '                        , oMov.Compra.CentroEmisor _
                     '                        , oMov.Compra.NumeroComprobante, _
                     '                         Integer.Parse(Pedido("Orden").ToString()))

                     'sql.ActualizarCantidadEntregada(oMov.Compra.IdSucursal, Integer.Parse(Pedido("IdPedido").ToString()), _
                     '                                Prod.IdProducto, CantidadProducto, Integer.Parse(Pedido("Orden").ToString()))

                     'sql.ActualizarComprobantePedido(oMov.Compra.IdSucursal, Integer.Parse(Pedido("IdPedido").ToString()), Prod.IdProducto, FechaNuevoEstado _
                     '               , oMov.Compra.TipoComprobante.IdTipoComprobante, oMov.Compra.Letra, oMov.Compra.CentroEmisor, oMov.Compra.NumeroComprobante, _
                     '                Integer.Parse(Pedido("Orden").ToString()))

                     Cont += 1
               End Select

               CantidadProducto = CantidadProducto - Decimal.Parse(Pedido("cantPendiente").ToString())

               If CantidadProducto <= 0 Then
                  Exit For ' salgo xq no tengo mas cantidad facturada
               End If

            Next

         Next

      Catch ex As Exception

         Throw ex

      Finally

      End Try

   End Sub


   Private Sub ActualizoEstadoComprobantesFacturados(oCompras As Entidades.Compra)
      Dim Cont As Integer
      Dim oFact As Entidades.Facturable = New Entidades.Facturable()

      'Cree un entidad nueva para hacerlo mas chiquita, si esta mal borrar!!!

      For Cont = 0 To oCompras.Facturables.Count - 1

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

         Me.ActualizaEstadoFacturables(oFact)

      Next

   End Sub

   Private Sub ActualizaEstadoFacturables(ent As Entidades.Facturable)
      Try

         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)

         sql.Compras_Facturables_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                   ent.IdProveedor, ent.IdEstadoComprobante, ent.IdTipoComprobanteFact,
                                   ent.LetraFact, ent.CentroEmisorFact, ent.NumeroComprobanteFact, ent.IdProveedorFact, ent.MercEnviada)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Friend Sub ActualizaFacturablesDesdeVenta(ent As Entidades.Facturable)
      Dim sql As SqlServer.Compras = New SqlServer.Compras(da)

      sql.Compras_Facturables_Venta_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.IdProveedor,
                                      ent.IdSucursal, ent.IdTipoComprobanteFact, ent.LetraFact, ent.CentroEmisorFact, ent.NumeroComprobanteFact)
   End Sub

   Public Sub ActualizaMovimientoCaja(ent As Entidades.Compra)
      Try

         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)

         sql.Compras_MovimientoCaja_U(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra,
                                       ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.IdProveedor,
                                       ent.IdCaja, ent.NumeroPlanilla, ent.NumeroMovimiento)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Sub ActualizaPlanillaCaja(ent As Entidades.Compra)
      Try

         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)

         sql.Compras_PlanillaCaja_U(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra,
                                       ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.IdProveedor,
                                       ent.IdCaja, ent.NumeroPlanilla)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

End Class
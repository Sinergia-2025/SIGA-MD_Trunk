Partial Class Ventas

   ''GET PARA INVOCACIONES/ANULACIONES/EXPORTACIONES/ETC
   Public Function GetFacturables(idSucursal As Integer,
                                  fechaDesde As Date, fechaHasta As Date,
                                  tiposComprobantes As List(Of String), nroComprobante As Long,
                                  idCliente As Long,
                                  idLocalidad As Integer, idProvincia As String,
                                  invocador As Entidades.Publicos.SiNoTodos) As DataTable
      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetFacturables(idSucursal, fechaDesde, fechaHasta, tiposComprobantes, nroComprobante, idCliente, idLocalidad, idProvincia, invocador)
   End Function


   'Public Function GetFacturables(idSucursal As Integer,
   '                                 fechaDesde As Date,
   '                                 fechaHasta As Date,
   '                                 tiposComprobantes As List(Of String),
   '                                 IdCliente As Long,
   '                                 IdEstadoComprobante As String,
   '                                 idListaPrecios As Integer,
   '                                 nroComprobante As Integer?) As List(Of Entidades.Venta)

   '   Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA '' (New Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.PRECIOCONIVA) = "SI")
   '   Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa '' Short.Parse(New Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.CATEGORIAFISCALEMPRESA))
   '   Dim blnInvocarInvocador As Boolean = Publicos.Facturacion.FacturacionInvocarInvocador '' Boolean.Parse(New Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.FACTURACIONINVOCARINVOCADOR))

   '   Dim stb As StringBuilder = New StringBuilder()

   '   With stb
   '      .AppendLine("SELECT V.IdSucursal")
   '      .AppendLine("   ,V.IdTipoComprobante")
   '      .AppendLine("   ,V.Letra")
   '      .AppendLine("   ,V.CentroEmisor")
   '      .AppendLine("   ,V.NumeroComprobante")
   '      .AppendLine("   ,V.Fecha")
   '      .AppendLine("   ,V.IdVendedor")
   '      .AppendLine("   ,V.DescuentoRecargo")
   '      .AppendLine("   ,V.DescuentoRecargoPorc")
   '      .AppendLine("   ,V.SubTotal")
   '      .AppendLine("   ,V.TotalImpuestos")
   '      .AppendLine("   ,V.TotalImpuestoInterno")
   '      .AppendLine("   ,V.ImporteTotal")
   '      .AppendLine("   ,V.IdCliente")
   '      .AppendLine("   ,V.IdCategoriaFiscal")
   '      .AppendLine("   ,V.IdFormasPago")
   '      .AppendLine("   ,V.Observacion")
   '      .AppendLine("   ,V.ImportePesos")
   '      .AppendLine("   ,V.ImporteTickets")
   '      .AppendLine("   ,V.ImporteTarjetas")
   '      .AppendLine("   ,V.ImporteCheques")
   '      .AppendLine("  ,V.IdCuentaBancaria")
   '      .AppendLine("  ,V.ImporteTransfBancaria")
   '      .AppendLine("   ,I.IdImpresora")
   '      .AppendLine("   ,I.TipoImpresora")
   '      .AppendLine("   ,V.Kilos")
   '      .AppendLine("   ,V.NumeroOrdenCompra")
   '      .AppendLine("   ,V.IdCobrador")
   '      .AppendLine("   ,V.IdMoneda")
   '      .AppendLine("   ,V.IdClienteVinculado")
   '      .AppendLine("   ,V.Cuit")
   '      .AppendLine("   ,V.CotizacionDolar")

   '      .AppendLine("   ,V.IdLocalidad")
   '      .AppendLine("   ,V.Direccion")
   '      .AppendLine("   ,V.Cuit")
   '      .AppendLine("   ,V.TipoDocCliente")
   '      .AppendLine("   ,V.NroDocCliente")
   '      .AppendLine("   ,V.NombreCliente NombreClienteGenerico")

   '      .AppendLine("   ,V.IdDestinoExportacion")
   '      .AppendLine("   ,V.IdIcotermExportacion")
   '      .AppendLine("   ,V.FechaPagoExportacion")


   '      .AppendLine(" FROM Ventas V")
   '      .AppendLine("INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
   '      .AppendLine(" INNER JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")
   '      .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.EsFacturable = 1")
   '      .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())

   '      If nroComprobante.HasValue Then
   '         .AppendFormatLine("   AND V.NumeroComprobante = {0}", nroComprobante)
   '      End If

   '      If tiposComprobantes.Count > 0 Then
   '         .AppendLine("   AND V.idTipoComprobante IN (")
   '         For Each tipo As String In tiposComprobantes
   '            .AppendFormat("'{0}',", tipo)
   '         Next
   '         .Remove(.Length - 1, 1)
   '         .AppendFormat(")")
   '      Else
   '         .AppendLine("   AND TC.CoeficienteStock < 0 AND TC.EsFacturable = 1 AND TC.AfectaCaja = 0")  '---Fuerzo Remitos
   '      End If

   '      If IdCliente <> 0 Then
   '         .AppendLine("   AND C.IdCliente = " & IdCliente)
   '      End If

   '      If IdEstadoComprobante <> "TODOS" Then
   '         'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
   '         If IdEstadoComprobante = "PENDIENTE" Then
   '            If blnInvocarInvocador Then
   '               .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
   '            Else
   '               .AppendLine("   AND V.IdEstadoComprobante IS NULL")
   '            End If
   '         ElseIf IdEstadoComprobante = "NO ANULADO" Then
   '            .AppendLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
   '         Else
   '            .AppendLine("   AND V.IdEstadoComprobante = '" & IdEstadoComprobante & "' ")
   '         End If
   '      End If

   '      '.AppendLine("   AND CONVERT(varchar(11), V.Fecha, 120) >= '" & fechaDesde.ToString("yyyy-MM-dd") & "'")
   '      '.AppendLine("   AND CONVERT(varchar(11), V.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
   '      .AppendLine("	  AND V.Fecha >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
   '      .AppendLine("	  AND V.Fecha <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")

   '      .AppendLine("   ORDER BY V.Fecha")  'Tiene la hora
   '   End With

   '   Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

   '   Dim oVentas As List(Of Entidades.Venta) = New List(Of Entidades.Venta)

   '   Dim venta As Entidades.Venta
   '   Dim cotizacionDolarDeLaVenta As Decimal = 0
   '   For Each drVen As DataRow In dt.Rows
   '      venta = New Entidades.Venta()

   '      With venta
   '         .IdSucursal = Integer.Parse(drVen("IdSucursal").ToString())
   '         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(drVen("IdTipoComprobante").ToString())

   '         .LetraComprobante = drVen("Letra").ToString()
   '         .CentroEmisor = Short.Parse(drVen("CentroEmisor").ToString())
   '         .NumeroComprobante = Long.Parse(drVen("NumeroComprobante").ToString())

   '         Dim rCliente As Reglas.Clientes = New Reglas.Clientes(da)
   '         .Cliente = rCliente._GetUno(Long.Parse(drVen("IdCliente").ToString()), False)
   '         .Cuit = drVen.ValorNumericoPorDefecto("Cuit", 0L).ToString()

   '         'Por ahora dejo tengo en cero para aquello que carga el precio actual (ej: REMITO)
   '         If venta.TipoComprobante.CargaPrecioActual Then
   '            .DescuentoRecargo = 0
   '         Else
   '            .DescuentoRecargo = Decimal.Parse(drVen("DescuentoRecargo").ToString())
   '         End If

   '         .DescuentoRecargoPorc = Decimal.Parse(drVen("DescuentoRecargoPorc").ToString())

   '         .Fecha = Date.Parse(drVen("Fecha").ToString())
   '         .FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(drVen("IdFormasPago").ToString()))
   '         .Vendedor = New Reglas.Empleados(da).GetUno(Integer.Parse(drVen("IdVendedor").ToString()))
   '         .Impresora = New Reglas.Impresoras().GetUna(Integer.Parse(drVen("IdSucursal").ToString()), drVen("IdImpresora").ToString())
   '         If Not String.IsNullOrEmpty(drVen("Observacion").ToString()) Then
   '            .Observacion = drVen("Observacion").ToString()
   '         End If
   '         .Subtotal = Decimal.Parse(drVen("SubTotal").ToString())
   '         .TotalImpuestos = Decimal.Parse(drVen("TotalImpuestos").ToString())
   '         '.TotalImpuestoInterno = Decimal.Parse(drVen("TotalImpuestoInterno").ToString()) Lo calcula a partir de VentasImpuestos
   '         .ImporteTotal = Decimal.Parse(drVen("ImporteTotal").ToString())

   '         'agrego las tarjetas
   '         .Tarjetas = Me.GetVentasTarjetas(.IdSucursal,
   '                                                 .IdTipoComprobante,
   '                                                 .LetraComprobante,
   '                                                 .CentroEmisor,
   '                                                 .NumeroComprobante)


   '         .ImportePesos = Decimal.Parse(drVen("ImportePesos").ToString())
   '         .ImporteTickets = Decimal.Parse(drVen("ImporteTickets").ToString())
   '         '.ImporteTarjetas = Decimal.Parse(drVen("ImporteTarjetas").ToString())
   '         '.ImporteCheques = 'Es read only
   '         .ImporteTransfBancaria = Decimal.Parse(dt.Rows(0)("ImporteTransfBancaria").ToString())

   '         If Not String.IsNullOrEmpty(dt.Rows(0)("IdCuentaBancaria").ToString()) Then
   '            .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias(da).GetUna(Integer.Parse(dt.Rows(0)("IdCuentaBancaria").ToString()))
   '         End If

   '         .Kilos = Decimal.Parse(drVen("Kilos").ToString())

   '         If Not String.IsNullOrEmpty(drVen("NumeroOrdenCompra").ToString()) Then
   '            If Long.Parse(drVen("NumeroOrdenCompra").ToString()) <> 0 Then
   '               .NumeroOrdenCompra = Long.Parse(drVen("NumeroOrdenCompra").ToString())
   '            End If
   '         End If

   '         If IsNumeric(drVen("IdCobrador")) Then
   '            .Cobrador = New Empleados(da).GetUno(Integer.Parse(drVen("IdCobrador").ToString()))
   '         End If

   '         .IdMoneda = Integer.Parse(drVen("IdMoneda").ToString())

   '         If IsNumeric(drVen("IdClienteVinculado")) Then
   '            .ClienteVinculado = rCliente._GetUno(Long.Parse(drVen("IdClienteVinculado").ToString()), False)
   '         End If

   '         cotizacionDolarDeLaVenta = drVen.Field(Of Decimal)(Entidades.Venta.Columnas.CotizacionDolar.ToString())
   '         .CotizacionDolar = cotizacionDolarDeLaVenta

   '         If .Cliente.EsClienteGenerico Then
   '            .NombreCliente = drVen.Field(Of String)("NombreClienteGenerico")
   '            .IdLocalidad = drVen.Field(Of Integer?)("IdLocalidad").IfNull()
   '            .Direccion = drVen.Field(Of String)("Direccion")
   '            .Cuit = drVen.Field(Of String)("Cuit")
   '            .TipoDocCliente = drVen.Field(Of String)("TipoDocCliente")
   '            .NroDocCliente = drVen.Field(Of Long?)("NroDocCliente").IfNull()
   '         End If

   '         If Not String.IsNullOrEmpty(drVen("IdDestinoExportacion").ToString()) Then
   '            .IdDestinoExportacion = drVen("IdDestinoExportacion").ToString()
   '         End If
   '         If Not String.IsNullOrEmpty(drVen("IdIcotermExportacion").ToString()) Then
   '            .IdIcotermExportacion = drVen("IdIcotermExportacion").ToString()
   '         End If
   '         .FechaPagoExportacion = drVen.Field(Of Date?)("FechaPagoExportacion")

   '         '# Obtener el detalle del service facturado en caso que corresponda
   '         .CrmInvocados = New Reglas.CRMNovedades(da).ObtenerServiciosFacturados(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroComprobante)
   '      End With

   '      With stb
   '         .Length = 0
   '         .AppendLine("SELECT VP.IdSucursal")
   '         .AppendLine("      ,VP.IdTipoComprobante")
   '         .AppendLine("      ,VP.Letra")
   '         .AppendLine("      ,VP.CentroEmisor")
   '         .AppendLine("      ,VP.NumeroComprobante")
   '         .AppendLine("      ,VP.IdProducto")
   '         .AppendLine("      ,VP.Orden")
   '         '.AppendLine("	   ,P.NombreProducto")
   '         .AppendLine("	   ,VP.NombreProducto")
   '         .AppendLine("	   ,PS.Stock")
   '         .AppendLine("      ,VP.Cantidad")
   '         .AppendLine("      ,VP.Precio")

   '         'Tengo que dejarlo sin IVA, como si lo hubiese leido de la tabla de VentasProductos
   '         If blnPreciosConIVA Then
   '            '.AppendLine("	,ROUND(PS.PrecioCosto / (1+(P.Alicuota/100)),2) as Costo")
   '            .AppendFormatLine("  ,(CASE WHEN VP.IdMoneda = 2 THEN ROUND(PS.PrecioCosto / (1+(P.Alicuota/100)),2) * {0} ELSE ROUND(PS.PrecioCosto / (1+(P.Alicuota/100)),2) END) Costo", cotizacionDolarDeLaVenta)
   '         Else
   '            '# Al venir el importe desde las listas de precios, si el producto está en dolares, el importe debe convertirse a PESOS.
   '            .AppendFormatLine("      ,(CASE WHEN VP.IdMoneda = 2 THEN PS.PrecioCosto * {0} ELSE PS.PrecioCosto END) Costo", cotizacionDolarDeLaVenta)
   '         End If

   '         .AppendLine("      ,VP.DescRecGeneral")
   '         .AppendLine("      ,VP.DescuentoRecargo")
   '         .AppendLine("      ,VP.DescuentoRecargoPorc")
   '         .AppendLine("      ,VP.DescuentoRecargoPorc2")

   '         'Tengo que dejarlo sin IVA, como si lo hubiese leido de la tabla de VentasProductos
   '         If blnPreciosConIVA Then
   '            '.AppendLine("	,ROUND(PSP.PrecioVenta / (1+(P.Alicuota/100)),2) as PrecioLista")
   '            .AppendFormatLine("  ,(CASE WHEN VP.IdMoneda = 2 THEN ROUND(PSP.PrecioVenta / (1+(P.Alicuota/100)),2) * {0} ELSE ROUND(PSP.PrecioVenta / (1+(P.Alicuota/100)),2) END) PrecioLista", cotizacionDolarDeLaVenta)
   '         Else
   '            '# Al venir el importe desde las listas de precios, si el producto está en dolares, el importe debe convertirse a PESOS.
   '            .AppendFormatLine("      ,(CASE WHEN VP.IdMoneda = 2 THEN PSP.PrecioVenta * {0} ELSE PSP.PrecioVenta END) PrecioLista", cotizacionDolarDeLaVenta)
   '         End If

   '         .AppendLine("      ,VP.Utilidad")
   '         .AppendLine("      ,VP.ImporteTotal")
   '         .AppendLine("      ,VP.ImporteTotalNeto")
   '         .AppendLine("      ,VP.ImporteImpuestoInterno")

   '         .AppendFormatLine("      ,(CASE WHEN VP.IdMoneda = 2 THEN PSP.PrecioVenta * {0} ELSE PSP.PrecioVenta END) PrecioVenta", cotizacionDolarDeLaVenta)
   '         .AppendLine("      ,PSP.FechaActualizacion")

   '         .AppendLine("      ,VP.Kilos")
   '         .AppendLine("      ,VP.IdTipoImpuesto")
   '         .AppendLine("      ,VP.AlicuotaImpuesto")
   '         .AppendLine("      ,VP.ImporteImpuesto")
   '         .AppendLine("      ,VP.IdListaPrecios")
   '         .AppendLine("      ,VP.NombreListaPrecios")
   '         .AppendLine("      ,VP.IdCentroCosto")

   '         .AppendLine("      ,VP.PrecioConImpuestos")
   '         .AppendLine("      ,VP.PrecioNetoConImpuestos")
   '         .AppendLine("      ,VP.ImporteTotalConImpuestos")
   '         .AppendLine("      ,VP.ImporteTotalNetoConImpuestos")

   '         .AppendLine("      ,VP.PrecioVentaPorTamano")
   '         .AppendLine("      ,VP.Tamano")
   '         .AppendLine("      ,VP.IdUnidadDeMedida")
   '         .AppendLine("      ,VP.IdMoneda")

   '         .AppendLine("      ,VP.Garantia")
   '         .AppendLine("      ,VP.FechaEntrega")
   '         .AppendLine("      ,VP.PorcImpuestoInterno")
   '         .AppendLine("      ,VP.OrigenPorcImpInt")

   '         .AppendLine("      ,VP.TipoOperacion")
   '         .AppendLine("      ,VP.Nota")

   '         .AppendLine(" ,VP.IdFormula")
   '         .AppendLine(" ,PF.NombreFormula")

   '         .AppendLine("      ,VP.NombreCortoListaPrecios")
   '         .AppendLine("      ,VP.Automatico")

   '         .AppendLine("      ,VP.IdEstadoVenta")
   '         .AppendLine("      ,VP.IdOferta")
   '         .AppendLine("      ,VP.IdUnidadDeMedida")
   '         .AppendLine("      ,VP.Conversion")
   '         .AppendLine("      ,VP.CantidadManual")
   '         '-----------------------------------------------------
   '         .AppendLine("      ,VP.IdaAtributoProducto01")
   '         .AppendLine("      ,VP.IdaAtributoProducto02")
   '         .AppendLine("      ,VP.IdaAtributoProducto03")
   '         .AppendLine("      ,VP.IdaAtributoProducto04")
   '         '-----------------------------------------------------
   '         .AppendLine("  FROM VentasProductos VP")
   '         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
   '         .AppendLine(" INNER JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = " & idSucursal.ToString())
   '         .Append("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")

   '         .AppendLine("  LEFT JOIN ProductosFormulas PF ON PF.IdProducto = VP.IdProducto AND PF.IdFormula = VP.IdFormula")

   '         .AppendLine(" WHERE VP.IdSucursal = " & idSucursal.ToString())

   '         .AppendFormat(" AND VP.IdTipoComprobante = '{0}'", venta.TipoComprobante.IdTipoComprobante)

   '         .AppendLine("   AND VP.Letra = '" & drVen("Letra").ToString() & "' ")
   '         .AppendLine("   AND VP.CentroEmisor = " & drVen("CentroEmisor").ToString() & " ")
   '         .AppendLine("   AND VP.NumeroComprobante = " & drVen("NumeroComprobante").ToString() & " ")

   '         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)

   '         .AppendLine(" ORDER BY VP.Orden")
   '      End With

   '      Dim dtPro As DataTable = Me.da.GetDataTable(stb.ToString())
   '      Dim oVP As Entidades.VentaProducto

   '      Dim CotizacionDolar As Decimal = New Reglas.Monedas().GetUna(2).FactorConversion

   '      'controlo si tiene orden de compra asociada
   '      Dim oc As Entidades.OrdenCompra
   '      If venta.NumeroOrdenCompra <> 0 Then
   '         oc = New Reglas.OrdenesCompra(Me.da).GetUno(venta.IdSucursal, venta.NumeroOrdenCompra, False)
   '      Else
   '         oc = New Entidades.OrdenCompra()
   '      End If

   '      For Each dr As DataRow In dtPro.Rows
   '         oVP = New Entidades.VentaProducto()
   '         With oVP
   '            .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
   '            .Letra = dr("Letra").ToString()
   '            .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
   '            .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
   '            Dim Produ As Entidades.Producto = New Reglas.Productos(Me.da).GetUno(dr("IdProducto").ToString())
   '            .Producto = Produ
   '            .Orden = dr.Field(Of Integer)("Orden")
   '            .Producto.NombreProducto = dr("NombreProducto").ToString()
   '            .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
   '            .CantidadManual = dr.Field(Of Decimal)("CantidadManual")
   '            .Conversion = dr.Field(Of Decimal)("Conversion")
   '            .Costo = Decimal.Parse(dr("Costo").ToString())
   '            .PrecioLista = Decimal.Parse(dr("PrecioLista").ToString())
   '            .ImporteImpuestoInterno = Decimal.Round(Produ.ImporteImpuestoInterno * .Cantidad, 2)
   '            .DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
   '            .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
   '            .CentroCosto = If(IsNumeric(dr("IdCentroCosto").ToString()), New Reglas.ContabilidadCentrosCostos().GetUna(dr.Field(Of Integer)("IdCentroCosto")), Nothing)
   '            .FechaActualizacion = Date.Parse(dr("FechaActualizacion").ToString())
   '            'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
   '            'si tiene una orden de compra no me importan los otros seteos
   '            If oc IsNot Nothing AndAlso oc.RespetaPreciosOrdenCompra Then
   '               .Precio = Decimal.Parse(dr("Precio").ToString())
   '               .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
   '               .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
   '               .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
   '               .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotalNeto").ToString())
   '               .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())
   '            Else
   '               If venta.TipoComprobante.CargaPrecioActual And Decimal.Parse(dr("PrecioVenta").ToString()) <> 0 And Not Produ.PermiteModificarDescripcion Then
   '                  .Precio = Decimal.Parse(dr("PrecioVenta").ToString())
   '                  .DescuentoRecargo = 0   'Despues se calcula.
                     '   .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
   '                  .DescRecGeneral = 0

   '                  '#########################################################>
   '                  '# Este calculo ahora se realiza en el query de consulta #
   '                  '#########################################################>
   '                  'If .Producto.Moneda.IdMoneda = 2 Then
   '                  '   .Costo = Decimal.Round(.Costo * CotizacionDolar, 2)
   '                  '   .PrecioLista = Decimal.Round(.PrecioLista * CotizacionDolar, 2)
   '                  '   .Precio = Decimal.Round(.Precio * CotizacionDolar, 2)
   '                  '   .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
   '                  'End If
   '                  '----------------------------------------------------------

   '               Else
   '                  .Precio = Decimal.Parse(dr("Precio").ToString())
   '                  .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
   '                  .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
   '                  .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
   '                  .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotalNeto").ToString())
   '                  .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())

   '                  'If .Producto.Moneda.IdMoneda = 2 Then
   '                  '   .Costo = Decimal.Round(.Costo * venta.CotizacionDolar, 2)
   '                  'End If

   '               End If

   '            End If



   '            If Not String.IsNullOrEmpty(dr("Stock").ToString()) Then
   '               .Stock = Decimal.Parse(dr("Stock").ToString())
   '            End If
   '            .TipoComprobante = dr("IdTipoComprobante").ToString()
   '            .Utilidad = Decimal.Parse(dr("Utilidad").ToString())
   '            .Kilos = Decimal.Parse(dr("Kilos").ToString())
   '            .TipoImpuesto.IdTipoImpuesto = DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), dr("IdTipoImpuesto").ToString()), Entidades.TipoImpuesto.Tipos)
   '            .AlicuotaImpuesto = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
   '            .ImporteImpuesto = Decimal.Parse(dr("ImporteImpuesto").ToString())
   '            .IdListaPrecios = Integer.Parse(dr("IdListaPrecios").ToString())
   '            .NombreListaPrecios = dr("NombreListaPrecios").ToString()
   '            .NombreCortoListaPrecios = dr("NombreCortoListaPrecios").ToString()
   '            .FechaActualizacion = Date.Parse(dr("FechaActualizacion").ToString())

   '            .PrecioConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioConImpuestos.ToString()).ToString())
   '            .PrecioNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioNetoConImpuestos.ToString()).ToString())
   '            .ImporteTotalConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotalConImpuestos.ToString()).ToString())
   '            .ImporteTotalNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotalNetoConImpuestos.ToString()).ToString())

   '            If Not String.IsNullOrEmpty(dr("PorcImpuestoInterno").ToString()) Then
   '               .PorcImpuestoInterno = Decimal.Parse(dr("PorcImpuestoInterno").ToString())
   '            End If

   '            .OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dr("OrigenPorcImpInt").ToString()), Entidades.OrigenesPorcImpInt)

   '            If IsNumeric(dr(Entidades.VentaProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString()) Then
   '               .PrecioVentaPorTamano = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString())
   '            End If
   '            If IsNumeric(dr(Entidades.VentaProducto.Columnas.Tamano.ToString()).ToString()) Then
   '               .Tamano = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.Tamano.ToString()).ToString())
   '            End If
   '            If Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()) Then
   '               .IdUnidadDeMedida = dr(Entidades.VentaProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()
   '            End If
   '            If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdMoneda.ToString())) Then
   '               .Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdMoneda.ToString()).ToString()))
   '            End If

   '            .Garantia = Integer.Parse(dr("Garantia").ToString())
   '            If Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.FechaEntrega.ToString()).ToString()) Then
   '               .FechaEntrega = Date.Parse(dr(Entidades.VentaProducto.Columnas.FechaEntrega.ToString()).ToString())
   '            End If

   '            .TipoOperacion = DirectCast([Enum].Parse(GetType(Entidades.Producto.TiposOperaciones), dr(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).ToString()), Entidades.Producto.TiposOperaciones)
   '            .Nota = dr(Entidades.PedidoProducto.Columnas.Nota.ToString()).ToString()

   '            If IsNumeric(dr(Entidades.PedidoProducto.Columnas.IdFormula.ToString())) Then
   '               .IdFormula = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdFormula.ToString()).ToString())
   '               .NombreFormula = dr(Entidades.ProductoFormula.Columnas.NombreFormula.ToString()).ToString()
   '            End If

   '            .Automatico = Boolean.Parse(dr(Entidades.VentaProducto.Columnas.Automatico.ToString()).ToString())

   '            If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdEstadoVenta.ToString())) Then
   '               .IdEstadoVenta = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdEstadoVenta.ToString()).ToString())
   '            End If

   '            If IsNumeric(dr(Entidades.VentaProducto.Columnas.IdOferta.ToString())) Then
   '               .IdOferta = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdOferta.ToString()).ToString())
   '            End If

   '            .VentasProductosFormulas = New Reglas.VentasProductosFormulas(da).GetTodos(.IdSucursal, .TipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, .IdProducto, .Orden)

   '            '# Lotes de Productos
   '            .VentasProductosLotes = New Reglas.VentasProductosLotes(da).GetTodos(.IdSucursal, .TipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, .IdProducto, .Orden)
   '            '-- REQ-35220.- --------------------------------------------------------------------------------------------------------
   '            .IdaAtributoProducto01 = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdaAtributoProducto01.ToString()).ToString())
   '            .IdaAtributoProducto02 = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdaAtributoProducto02.ToString()).ToString())
   '            .IdaAtributoProducto03 = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdaAtributoProducto03.ToString()).ToString())
   '            .IdaAtributoProducto04 = Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdaAtributoProducto04.ToString()).ToString())
   '            '-----------------------------------------------------------------------------------------------------------------------
   '         End With

   '         venta.VentasProductos.Add(oVP)

   '      Next

   '      'Observaciones
   '      With stb
   '         .Length = 0
   '         .AppendLine("SELECT VO.IdSucursal")
   '         .AppendLine("      ,VO.IdTipoComprobante")
   '         .AppendLine("      ,VO.Letra")
   '         .AppendLine("      ,VO.CentroEmisor")
   '         .AppendLine("      ,VO.NumeroComprobante")
   '         .AppendLine("      ,VO.Linea")
   '         .AppendLine("      ,VO.Observacion")
   '         .AppendLine("  FROM VentasObservaciones VO")
   '         .AppendLine(" WHERE VO.IdSucursal = " & idSucursal.ToString())
   '         .AppendFormat(" AND VO.IdTipoComprobante = '{0}'", venta.TipoComprobante.IdTipoComprobante)
   '         .AppendLine("   AND VO.Letra = '" & drVen("Letra").ToString() & "' ")
   '         .AppendLine("   AND VO.CentroEmisor = " & drVen("CentroEmisor").ToString() & " ")
   '         .AppendLine("   AND VO.NumeroComprobante = " & drVen("NumeroComprobante").ToString() & " ")
   '         .AppendLine(" ORDER BY VO.Linea")
   '      End With

   '      Dim dtObs As DataTable = Me.da.GetDataTable(stb.ToString())
   '      Dim oVO As Entidades.VentaObservacion

   '      For Each dr As DataRow In dtObs.Rows
   '         oVO = New Entidades.VentaObservacion()
   '         With oVO
   '            .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
   '            .IdTipoComprobante = dr("IdTipoComprobante").ToString()
   '            .Letra = dr("Letra").ToString()
   '            .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
   '            .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
   '            .Linea = Integer.Parse(dr("Linea").ToString())
   '            .Observacion = dr("Observacion").ToString()
   '         End With
   '         venta.VentasObservaciones.Add(oVO)
   '      Next
   '      '---------------------------------------------------------------------------------------------

   '      Dim rVentaContacto As Reglas.VentasClientesContactos = New Reglas.VentasClientesContactos(da)
   '      venta.VentasContactos = rVentaContacto.GetTodos(idSucursal,
   '                                                      drVen("IdTipoComprobante").ToString(),
   '                                                      drVen("Letra").ToString(),
   '                                                      Short.Parse(drVen("CentroEmisor").ToString()),
   '                                                      Long.Parse(drVen("NumeroComprobante").ToString()))

   '      venta.Percepciones = New Reglas.PercepcionVentas(da).GetTodos(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)

   '      oVentas.Add(venta)

   '   Next

   '   Return oVentas

   'End Function

   Public Function GetFacturablesPedidos(idSucursal As Integer,
                                         fechaDesde As Date,
                                         fechaHasta As Date,
                                         tiposComprobantes As List(Of String),
                                         IdCliente As Long,
                                         IdEstadoComprobante As String,
                                         idListaPrecios As Integer,
                                         comprobanteFacturador As Entidades.TipoComprobante,
                                         numeroOrdenCompra As Long) As List(Of Entidades.Venta)

      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA '' (New Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.PRECIOCONIVA) = "SI")
      Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa '' Short.Parse(New Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.CATEGORIAFISCALEMPRESA))
      Dim blnInvocarInvocador As Boolean = Publicos.Facturacion.FacturacionInvocarInvocador '' Boolean.Parse(New Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.FACTURACIONINVOCARINVOCADOR))

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT P.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.IdCliente")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdUsuario AS Usuario")
         .AppendLine("      ,P.Observacion")
         .AppendLine("      ,P.DescuentoRecargo")
         .AppendLine("      ,P.DescuentoRecargoPorc")
         .AppendLine("      ,P.ImporteTotal")
         .AppendLine("      ,P.IdVendedor")
         .AppendLine("      ,P.Kilos")
         .AppendLine("      ,P.IdFormasPago")
         .AppendLine("      ,P.NumeroOrdenCompra")
         .AppendLine("      ,P.IdClienteVinculado")
         .AppendFormatLine("      ,P.CotizacionDolar")
         .AppendFormatLine("      ,P.IdMoneda")
         .AppendLine("      ,P.IdLocalidad")
         .AppendLine("      ,P.Direccion")
         .AppendLine("      ,P.Cuit")
         .AppendLine("      ,P.TipoDocCliente")
         .AppendLine("      ,P.NroDocCliente")
         .AppendLine("      ,P.NombreCliente NombreClienteGenerico")
         .AppendLine("      ,PR.CodigoProveedor")
         .AppendLine("      ,PR.NombreProveedor")
         .AppendLine("      ,P.IdCaja")
         .AppendLine("      ,P.IdDomicilio")

         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")


         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto ")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" LEFT JOIN OrdenesCompra OC ON P.NumeroOrdenCompra = OC.NumeroOrdenCompra")
         .AppendLine(" LEFT JOIN Proveedores PR ON OC.IdProveedor= PR.IdProveedor")

         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendLine("   AND P.IdSucursal = " & idSucursal.ToString())
         End If

         .AppendLine(" AND P.IdTipoComprobante IN (")
         For Each Tip As String In tiposComprobantes
            .AppendFormat("'{0}',", Tip)
         Next
         .Remove(.Length - 1, 1)
         .AppendLine(")")

         If IdCliente <> 0 Then
            .AppendLine("   AND C.IdCliente = " & IdCliente)
         End If
         If Not String.IsNullOrWhiteSpace(IdEstadoComprobante) Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstadoComprobante & "' ")
         End If

         .AppendFormat("   AND PE.IdEstado <> '{0}'", Entidades.EstadoPedido.ESTADO_ANULADO).AppendLine()

         If comprobanteFacturador.AlInvocarPedidoAfectaFactura Then
            .AppendLine("   AND PE.NumeroComprobanteFact IS NULL")
         End If

         If comprobanteFacturador.AlInvocarPedidoAfectaRemito Then
            .AppendLine("   AND PE.NumeroComprobanteRemito IS NULL")
         End If

         If numeroOrdenCompra <> 0 Then
            .AppendFormat("   AND P.NumeroOrdenCompra = {0}", numeroOrdenCompra)
         End If

         .AppendLine("   AND CONVERT(varchar(11), P.FechaPedido, 120) >= '" & fechaDesde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("   AND CONVERT(varchar(11), P.FechaPedido, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         .AppendLine(" GROUP BY P.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroPedido, P.IdCliente,")
         .AppendLine("          P.FechaPedido, P.Observacion, P.IdUsuario, P.DescuentoRecargo, P.DescuentoRecargoPorc , P.ImporteTotal")
         .AppendLine("         ,P.IdVendedor , P.Kilos , P.IdFormasPago, P.NumeroOrdenCompra, P.IdClienteVinculado, P.CotizacionDolar, PR.CodigoProveedor, PR.NombreProveedor")
         .AppendLine("         ,P.IdLocalidad, P.NombreCliente, P.Cuit, P.TipoDocCliente, P.NroDocCliente, P.Direccion, P.IdCaja, P.IdMoneda, p.IdDomicilio")

         .AppendLine("   ORDER BY P.FechaPedido")  'Tiene la hora
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim oVentas As List(Of Entidades.Venta) = New List(Of Entidades.Venta)

      Dim venta As Entidades.Venta
      Dim cotizacionDolarPedido As Decimal = 0
      For Each drVen As DataRow In dt.Rows
         venta = New Entidades.Venta()

         With venta
            .Usuario = drVen("Usuario").ToString()

            .IdSucursal = Integer.Parse(drVen("IdSucursal").ToString())

            .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(drVen("IdTipoComprobante").ToString())

            .LetraComprobante = drVen("Letra").ToString()
            .CentroEmisor = Short.Parse(drVen("CentroEmisor").ToString())
            .NumeroComprobante = Long.Parse(drVen("NumeroPedido").ToString())

            .Cliente = New Reglas.Clientes(da)._GetUno(Long.Parse(drVen("IdCliente").ToString()), False)

            If IsNumeric(drVen("IdClienteVinculado")) Then
               .ClienteVinculado = New Reglas.Clientes(da)._GetUno(Long.Parse(drVen("IdClienteVinculado").ToString()), False)
            End If

            ''Por ahora dejo tengo en cero para aquello que carga el precio actual (ej: REMITO)
            If venta.TipoComprobante.CargaPrecioActual Then
               .DescuentoRecargo = 0
            Else
               If Not String.IsNullOrEmpty(drVen("DescuentoRecargo").ToString()) Then
                  .DescuentoRecargo = Decimal.Parse(drVen("DescuentoRecargo").ToString())
               End If

            End If

            If Not String.IsNullOrEmpty(drVen("DescuentoRecargoPorc").ToString()) Then
               .DescuentoRecargoPorc = Decimal.Parse(drVen("DescuentoRecargoPorc").ToString())
            End If

            .FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(drVen("IdFormasPago").ToString()))

            .Fecha = Date.Parse(drVen("FechaPedido").ToString())
            '.FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(drVen("IdFormasPago").ToString()))
            '.Vendedor = New Reglas.Empleados(da).GetUno(drVen("TipoDocVendedor").ToString(), drVen("NroDocVendedor").ToString())
            '.Impresora = New Reglas.Impresoras().GetUna(Integer.Parse(drVen("IdSucursal").ToString()), drVen("IdImpresora").ToString())

            If Not String.IsNullOrEmpty(drVen("Observacion").ToString()) Then
               .Observacion = drVen("Observacion").ToString()
            End If
            '  .Subtotal = Decimal.Parse(drVen("SubTotal").ToString())
            ' .TotalImpuestos = Decimal.Parse(drVen("TotalImpuestos").ToString())
            .ImporteTotal = Decimal.Parse(drVen("ImporteTotal").ToString())

            '.ImportePesos = Decimal.Parse(drVen("ImportePesos").ToString())
            '.ImporteTickets = Decimal.Parse(drVen("ImporteTickets").ToString())
            '.ImporteTarjetas = Decimal.Parse(drVen("ImporteTarjetas").ToString())
            ''.ImporteCheques = 'Es read only

            .Kilos = Decimal.Parse(drVen("Kilos").ToString())

            If Not String.IsNullOrWhiteSpace(drVen("IdVendedor").ToString()) Then
               .Vendedor = New Reglas.Empleados().GetUno(Integer.Parse(drVen("IdVendedor").ToString()))
            End If

            If Not String.IsNullOrWhiteSpace(drVen("IdCaja").ToString()) Then
               .Caja = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, Integer.Parse(drVen("IdCaja").ToString()))
            End If


            If Not String.IsNullOrEmpty(drVen("NumeroOrdenCompra").ToString()) Then
               If Long.Parse(drVen("NumeroOrdenCompra").ToString()) <> 0 Then
                  .NumeroOrdenCompra = Long.Parse(drVen("NumeroOrdenCompra").ToString())
               End If
            End If

            .IdMoneda = drVen.Field(Of Integer)("IdMoneda")

            ' Asigno el Proveedor del Pedido
            Dim codProve As Long? = drVen.Field(Of Long?)(Entidades.Proveedor.Columnas.CodigoProveedor.ToString())
            If codProve.HasValue Then
               .Proveedor.CodigoProveedor = codProve.Value
               .Proveedor.NombreProveedor = drVen.Field(Of String)(Entidades.Proveedor.Columnas.NombreProveedor.ToString())
            End If

            .CotizacionDolar = drVen.Field(Of Decimal)("CotizacionDolar")
            cotizacionDolarPedido = .CotizacionDolar

            .IdDomicilio = If(drVen.Field(Of Integer?)("IdDomicilio"), 0)

            If .Cliente.EsClienteGenerico Then
               .NombreCliente = drVen.Field(Of String)("NombreClienteGenerico")
               If drVen.Field(Of Integer?)("IdLocalidad").HasValue Then .IdLocalidad = drVen.Field(Of Integer?)("IdLocalidad").Value
               .Direccion = drVen.Field(Of String)("Direccion")
               .Cuit = drVen.Field(Of String)("Cuit")
               .TipoDocCliente = drVen.Field(Of String)("TipoDocCliente")
               If drVen.Field(Of Long?)("NroDocCliente").HasValue Then .NroDocCliente = drVen.Field(Of Long?)("NroDocCliente").Value
            End If

         End With

         With stb
            .Length = 0
            .AppendLine("SELECT   PP.IdSucursal")
            .AppendLine(" ,PP.IdTipoComprobante")
            .AppendLine(" ,PP.Letra")
            .AppendLine(" ,PP.CentroEmisor")
            .AppendLine(" ,PP.NumeroPedido")
            .AppendLine(" ,PP.IdProducto")
            .AppendLine(" ,PP.Cantidad")
            .AppendLine(" ,PP.Precio")

            '.AppendLine(" ,PP.PrecioLista")
            '.AppendLine(" ,PP.Costo")
            '# Conversión del costo y precio en caso que sea en Dólares
            .AppendFormatLine(",(CASE WHEN PP.IdMoneda = 2 THEN PSP.PrecioVenta * {0} ELSE PSP.PrecioVenta END) PrecioLista", cotizacionDolarPedido)

            If blnPreciosConIVA Then
               .AppendFormatLine(",(CASE WHEN PP.IdMoneda = 2 THEN {1} * {0} ELSE {1} END) Costo", cotizacionDolarPedido,
                                 SqlServer.CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto", "P"))
               .AppendFormatLine(",(CASE WHEN PP.IdMoneda = 2 THEN {1} * {0} ELSE {1} END) CostoConIVA", cotizacionDolarPedido,
                                 "PS.PrecioCosto")
            Else
               .AppendFormatLine(",(CASE WHEN PP.IdMoneda = 2 THEN {1} * {0} ELSE {1} END) Costo", cotizacionDolarPedido,
                                 "PS.PrecioCosto")
               .AppendFormatLine(",(CASE WHEN PP.IdMoneda = 2 THEN {1} * {0} ELSE {1} END) CostoConIVA", cotizacionDolarPedido,
                                 SqlServer.CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto", "P"))

            End If

            .AppendLine(" ,PP.ImporteTotal")
            .AppendLine(" ,PP.NombreProducto")
            .AppendLine(" ,PP.CantEntregada")
            .AppendLine(" ,PP.CantEnProceso")
            .AppendLine(" ,PP.DescuentoRecargoProducto")
            .AppendLine(" ,PP.DescuentoRecargoPorc")
            .AppendLine(" ,PP.DescuentoRecargoPorc2")
            .AppendLine(" ,PP.ImporteImpuesto")

            If blnPreciosConIVA Then
               .AppendLine("	,ROUND(PSP.PrecioVenta / (1+(P.Alicuota/100)),2) as PrecioVenta")
            Else
               .AppendLine("      ,PSP.PrecioVenta")
            End If

            .AppendLine(" ,P.ImporteImpuestoInterno")
            .AppendLine(" ,P.PorcImpuestoInterno AS PorcImpuestoInternoProducto")
            .AppendLine(" ,P.OrigenPorcImpInt AS OrigenPorcImpIntProducto")
            .AppendLine(" ,PP.PorcImpuestoInterno")
            .AppendLine(" ,PP.ImporteImpuestoInterno ImporteImpuestoInternoPedido")
            .AppendLine(" ,PP.OrigenPorcImpInt OrigenPorcImpIntPedido")
            .AppendLine(" ,PE.CantAfectada AS CantParaFacturar")
            .AppendLine(" ,PP.Kilos")

            .AppendLine(" ,PP.PrecioConImpuestos")
            .AppendLine(" ,PP.PrecioNetoConImpuestos")
            .AppendLine(" ,PP.ImporteTotalConImpuestos")
            .AppendLine(" ,PP.ImporteTotalNetoConImpuestos")

            .AppendLine(" ,PP.PrecioVentaPorTamano")
            .AppendLine(" ,PP.Tamano")
            .AppendLine(" ,PP.IdUnidadDeMedida")
            .AppendLine(" ,PP.IdMoneda")

            .AppendLine(" ,PP.IdListaPrecios")
            .AppendLine(" ,PP.NombreListaPrecios")

            .AppendLine(" ,PP.TipoOperacion")
            .AppendLine(" ,PP.Nota")
            .AppendLine(" ,PP.NombreCortoListaPrecios")
            .AppendLine(" ,PP.AlicuotaImpuesto")
            .AppendLine(" ,P.Alicuota AS AlicuotaImpuestoProducto")

            .AppendLine(" ,PP.IdFormula")
            .AppendLine(" ,PF.NombreFormula")

            .AppendLine("      ,PP.ModificoDescuentos")

            .AppendLine(" ,PP.Automatico")
            .AppendLine(" ,PP.CantidadManual")
            .AppendLine(" ,PP.Conversion")
            .AppendLine(" ,PPP.CodigoProductoProveedor")
            .AppendLine(" ,PP.ModificoPrecioManualmente")

            .AppendLine(" FROM PedidosProductos PP ")

            .AppendLine("  INNER JOIN (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden")
            .AppendLine("                   , SUM(CantEstado) AS CantAfectada")
            .AppendLine("                FROM PedidosEstados PE")
            .AppendFormat("               WHERE 1 = 1").AppendLine()

            If Not String.IsNullOrWhiteSpace(IdEstadoComprobante) Then
               .AppendLine("   AND PE.IdEstado = '" & IdEstadoComprobante & "' ")
            End If

            .AppendFormat("   AND PE.IdEstado <> '{0}'", Entidades.EstadoPedido.ESTADO_ANULADO).AppendLine()

            If comprobanteFacturador.AlInvocarPedidoAfectaFactura Then
               .AppendLine("   AND PE.NumeroComprobanteFact IS NULL")
            End If

            If comprobanteFacturador.AlInvocarPedidoAfectaRemito Then
               .AppendLine("   AND PE.NumeroComprobanteRemito IS NULL")
            End If

            .AppendFormat("                 AND PE.IdSucursal = {0}", drVen("IdSucursal").ToString()).AppendLine()
            .AppendFormat("                 AND PE.IdTipoComprobante = '{0}' ", drVen("IdTipoComprobante")).AppendLine()
            .AppendFormat("                 AND PE.Letra = '{0}' ", drVen("Letra")).AppendLine()
            .AppendFormat("                 AND PE.CentroEmisor = {0} ", drVen("CentroEmisor")).AppendLine()
            .AppendFormat("                 AND PE.NumeroPedido = {0} ", drVen("NumeroPedido")).AppendLine()
            .AppendLine("               GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, IdProducto, Orden) PE")
            .AppendLine("          ON PE.IdSucursal = PP.IdSucursal")
            .AppendLine("         AND PE.IdTipoComprobante = PP.IdTipoComprobante")
            .AppendLine("         AND PE.Letra = PP.Letra")
            .AppendLine("         AND PE.CentroEmisor = PP.CentroEmisor")
            .AppendLine("         AND PE.NumeroPedido = PP.NumeroPedido")
            .AppendLine("         AND PE.IdProducto = PP.IdProducto")
            .AppendLine("         AND PE.Orden = PP.Orden")

            .AppendLine(" INNER JOIN Productos P ON P.IdProducto = PP.IdProducto")
            .AppendLine(" INNER JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = " & drVen("IdSucursal").ToString())
            .Append("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
            .AppendLine("  LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
            .AppendLine("  LEFT JOIN ProductosProveedores PPP ON PPP.IdProducto = P.IdProducto AND PPP.IdProveedor = P.IdProveedor")

            .AppendLine(" WHERE PP.IdSucursal = " & drVen("IdSucursal").ToString())
            .AppendLine("   AND PP.IdTipoComprobante = '" & drVen("IdTipoComprobante").ToString() & "' ")
            .AppendLine("   AND PP.Letra = '" & drVen("Letra").ToString() & "' ")
            .AppendLine("   AND PP.CentroEmisor = " & drVen("CentroEmisor").ToString() & " ")
            .AppendLine("   AND PP.NumeroPedido = " & drVen("NumeroPedido").ToString() & " ")

            .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)

            .AppendLine(" ORDER BY PP.IdSucursal")
            .AppendLine("        , PP.IdTipoComprobante")
            .AppendLine("        , PP.Letra")
            .AppendLine("        , PP.CentroEmisor")
            .AppendLine("        , PP.NumeroPedido")
            .AppendLine("        , PP.Orden")

         End With

         Dim dtPro = Me.da.GetDataTable(stb.ToString())
         Dim oVP As Entidades.VentaProducto
         Dim Kilos As Decimal = 0

         Dim CotizacionDolar As Decimal = New Reglas.Monedas().GetUna(2).FactorConversion

         Dim RespetaPreciosOrdenDeCompra As Boolean = False

         If venta.NumeroOrdenCompra <> 0 Then
            Dim ordenCompra As Entidades.OrdenCompra = New Reglas.OrdenesCompra(Me.da).GetUno(venta.IdSucursal, venta.NumeroOrdenCompra, False)
            If ordenCompra IsNot Nothing Then
               RespetaPreciosOrdenDeCompra = ordenCompra.RespetaPreciosOrdenCompra
            End If
         End If


         For Each dr As DataRow In dtPro.Rows
            oVP = New Entidades.VentaProducto()
            With oVP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .TipoComprobante = dr("IdTipoComprobante").ToString()
               .Letra = dr("Letra").ToString()
               .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
               .NumeroComprobante = Long.Parse(dr("NumeroPedido").ToString())
               Dim Produ As Entidades.Producto = New Reglas.Productos(Me.da).GetUno(dr("IdProducto").ToString())
               .Producto = Produ
               .Producto.NombreProducto = dr("NombreProducto").ToString()

               .CodigoProductoProveedor = dr.Field(Of String)("CodigoProductoProveedor")

               '.Cantidad = Decimal.Parse(dr("Cantidad").ToString()) - Decimal.Parse(dr("CantEntregada").ToString())
               .Cantidad = Decimal.Parse(dr("CantParaFacturar").ToString())
               .CantidadManual = .Cantidad
               .Conversion = dr.Field(Of Decimal)("Conversion")

               'If .Producto.UnidadDeMedida.IdUnidadDeMedida.ToString() <> "" Then
               '   Dim Conversion As Decimal
               '   Dim oUM As Reglas.UnidadesDeMedidas = New Reglas.UnidadesDeMedidas
               '   Conversion = oUM.GetUno(.Producto.UnidadDeMedida.IdUnidadDeMedida).ConversionAKilos
               '   .Kilos = Decimal.Round(Decimal.Parse(.Cantidad.ToString()) * Decimal.Parse(.Producto.Tamano.ToString()) * Conversion, 3)
               '   Kilos += .Kilos
               'End If

               .Kilos = Decimal.Parse(dr("Kilos").ToString())
               .Kilos = .Kilos / Decimal.Parse(dr("Cantidad").ToString()) * .Cantidad
               Kilos += .Kilos

               '.Costo = Decimal.Parse(dr("Costo").ToString())
               If ((venta.Cliente.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                   Not venta.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Or
                   Not venta.TipoComprobante.UtilizaImpuestos) Then
                  'Sin Impuestos
                  .Costo = Decimal.Parse(dr("Costo").ToString())
               Else
                  If comprobanteFacturador.UtilizaImpuestos Then
                     'Con Impuestos
                     .Costo = Decimal.Parse(dr("CostoConIVA").ToString())
                  Else
                     .Costo = Decimal.Parse(dr("Costo").ToString())
                  End If
               End If
               .CostoParaGrabar = Decimal.Parse(dr("Costo").ToString())

               'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
               Dim alicuotaImpuestoProducto As Decimal = Decimal.Parse(dr("AlicuotaImpuestoProducto").ToString())
               Dim alicuotaImpuesto As Decimal = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
               If Not RespetaPreciosOrdenDeCompra AndAlso venta.TipoComprobante.CargaPrecioActual And Decimal.Parse(dr("Precio").ToString()) <> 0 And Not Produ.PermiteModificarDescripcion Then

                  .AlicuotaImpuesto = If(Not comprobanteFacturador.UtilizaImpuestos, alicuotaImpuesto, alicuotaImpuestoProducto) '# Si el comprobante facturador/invocador no utiliza impuestos y el invocado carga precio actual, mantiene el IVA del invocado.
                  .PrecioLista = Decimal.Parse(dr("PrecioLista").ToString())
                  .Precio = Decimal.Parse(dr("PrecioVenta").ToString())

                  .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInternoPedido").ToString())
                  .PorcImpuestoInterno = Decimal.Parse(dr("PorcImpuestoInterno").ToString())
                  .OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dr("OrigenPorcImpIntPedido").ToString()), Entidades.OrigenesPorcImpInt)

                  If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc").ToString()) Then
                     .DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
                  End If
                  If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                     .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                  End If

                  .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
               Else

                  .AlicuotaImpuesto = alicuotaImpuesto
                  .Precio = Decimal.Parse(dr("Precio").ToString())
                  .PrecioLista = Decimal.Parse(dr("PrecioLista").ToString())
                  If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc").ToString()) Then
                     .DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
                  End If
                  If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                     .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                  End If

                  .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInternoPedido").ToString())
                  .PorcImpuestoInterno = Decimal.Parse(dr("PorcImpuestoInterno").ToString())
                  .OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dr("OrigenPorcImpIntPedido").ToString()), Entidades.OrigenesPorcImpInt)

                  ' .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
                  .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
                  '    .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
                  .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotal").ToString())
               End If

               .Stock = New Reglas.ProductosSucursales().GetUno(.IdSucursal, dr("IdProducto").ToString()).Stock

               .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr("IdTipoComprobante").ToString()).Descripcion
               '.Utilidad = Decimal.Parse(dr("Utilidad").ToString())
               '.Kilos = Decimal.Parse(dr("Kilos").ToString())
               .TipoImpuesto.IdTipoImpuesto = DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), "IVA"), Entidades.TipoImpuesto.Tipos)
               '.AlicuotaImpuesto = New Reglas.Productos().GetUno(dr("IdProducto").ToString()).Alicuota
               .ImporteImpuesto = Decimal.Parse(dr("ImporteImpuesto").ToString())

               .PrecioConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioConImpuestos.ToString()).ToString())
               .PrecioNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioNetoConImpuestos.ToString()).ToString())
               .ImporteTotalConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotalConImpuestos.ToString()).ToString())
               .ImporteTotalNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotalNetoConImpuestos.ToString()).ToString())

               If IsNumeric(dr(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString()) Then
                  .PrecioVentaPorTamano = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).ToString())
               End If
               If IsNumeric(dr(Entidades.PedidoProducto.Columnas.Tamano.ToString()).ToString()) Then
                  .Tamano = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.Tamano.ToString()).ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()) Then
                  .IdUnidadDeMedida = dr(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()
               End If
               If IsNumeric(dr(Entidades.PedidoProducto.Columnas.IdMoneda.ToString())) Then
                  .Moneda = New Reglas.Monedas(da).GetUna(Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdMoneda.ToString()).ToString()))
               End If

               .IdListaPrecios = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdListaPrecios.ToString()).ToString())
               .NombreListaPrecios = dr(Entidades.PedidoProducto.Columnas.NombreListaPrecios.ToString()).ToString()
               .NombreCortoListaPrecios = dr(Entidades.PedidoProducto.Columnas.NombreCortoListaPrecios.ToString()).ToString()

               .TipoOperacion = DirectCast([Enum].Parse(GetType(Entidades.Producto.TiposOperaciones), dr(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).ToString()), Entidades.Producto.TiposOperaciones)
               .Nota = dr(Entidades.PedidoProducto.Columnas.Nota.ToString()).ToString()

               If IsNumeric(dr(Entidades.PedidoProducto.Columnas.IdFormula.ToString())) Then
                  .IdFormula = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdFormula.ToString()).ToString())
                  .NombreFormula = dr(Entidades.ProductoFormula.Columnas.NombreFormula.ToString()).ToString()
               End If

               .Automatico = Boolean.Parse(dr(Entidades.PedidoProducto.Columnas.Automatico.ToString()).ToString())
               .ModificoDescuentos = Boolean.Parse(dr(Entidades.PedidoProducto.Columnas.ModificoDescuentos.ToString()).ToString())
               .ModificoPrecioManualmente = dr.Field(Of Boolean?)("ModificoPrecioManualmente").IfNull()

               '-------------------------------------------------------------------------------------------------------------------
               .IdDeposito = Produ.IdDeposito
               .NombreDeposito = New Reglas.SucursalesDepositos(da).GetUno(Produ.IdDeposito, Integer.Parse(dr("IdSucursal").ToString())).NombreDeposito
               .IdUbicacion = Produ.IdUbicacion
               .NombreUbicacion = New Reglas.SucursalesUbicaciones(da).GetUno(Produ.IdDeposito, Integer.Parse(dr("IdSucursal").ToString()), Produ.IdUbicacion).NombreUbicacion
               '-------------------------------------------------------------------------------------------------------------------

               ''''Dim estado = _cache.BuscaEstadosPedido(IdEstadoComprobante, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())
               ''''If estado.ReservaStock Then
               ''''   .IdDeposito = estado.IdDeposito
               ''''   .NombreDeposito = New Reglas.SucursalesDepositos(da).GetUno(estado.IdDeposito, actual.Sucursal.Id).NombreDeposito
               ''''   .IdUbicacion = Produ.IdUbicacion
               ''''   .NombreUbicacion = New Reglas.SucursalesUbicaciones(da).GetUno(estado.IdDeposito, actual.Sucursal.Id, estado.IdUbicacion).NombreUbicacion
               ''''End If


               .VentasProductosFormulas = New PedidosProductosFormulas(da).GetTodos(.IdSucursal, .TipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, .IdProducto, .Orden).
                                                ConvertAll(Function(x) New Entidades.VentaProductoFormula() With {
                                                               .IdSucursal = x.IdSucursal,
                                                                                 .IdTipoComprobante = x.IdTipoComprobante,
                                                                                 .Letra = x.Letra,
                                                                                 .CentroEmisor = x.CentroEmisor,
                                                                                 .NumeroComprobante = x.NumeroPedido,
                                                                                 .IdProducto = x.IdProducto,
                                                                                 .Orden = x.Orden,
                                                                                 .IdProductoComponente = x.IdProductoComponente,
                                                                                 .IdFormula = x.IdFormula,
                                                                                 .NombreProductoComponente = x.NombreProductoComponente,
                                                                                 .NombreFormula = x.NombreFormula,
                                                                                 .PrecioCosto = x.PrecioCosto,
                                                                                 .PrecioVenta = x.PrecioVenta,
                                                                                 .Cantidad = x.Cantidad,
                                                               .SegunCalculoForma = x.SegunCalculoForma
                                                            })

            End With

            venta.VentasProductos.Add(oVP)

         Next

         Dim rPedidoContacto As Reglas.PedidosClientesContactos = New Reglas.PedidosClientesContactos(da)
         For Each Contacto In rPedidoContacto.GetTodos(Integer.Parse(drVen("IdSucursal").ToString()),
                                                       drVen("IdTipoComprobante").ToString(),
                                                       drVen("Letra").ToString(),
                                                       Short.Parse(drVen("CentroEmisor").ToString()),
                                                       Long.Parse(drVen("NumeroPedido").ToString()))
            venta.VentasContactos.Add(New Entidades.VentaClienteContacto(Contacto.Contacto))
         Next

         Dim rPedidoObservaciones As Reglas.PedidosObservaciones = New Reglas.PedidosObservaciones(da)
         For Each observacion In rPedidoObservaciones.GetTodos(Integer.Parse(drVen("IdSucursal").ToString()),
                                                            drVen("IdTipoComprobante").ToString(),
                                                            drVen("Letra").ToString(),
                                                            Short.Parse(drVen("CentroEmisor").ToString()),
                                                            Long.Parse(drVen("NumeroPedido").ToString()))
            venta.VentasObservaciones.Add(New Entidades.VentaObservacion(observacion.Observacion, observacion.IdTipoObservacion, observacion.DescripcionTipoObservacion))
         Next
         '---------------------------------------------------------------------------------------------
         venta.Kilos = Kilos

         oVentas.Add(venta)

      Next

      Return oVentas

   End Function

   Private Sub GetDisponibilidadComprobanteInvocadoPorTipo(oVenta As Entidades.Venta)
      Dim noDisponible As Boolean = False
      Dim sql = New SqlServer.Ventas(Me.da)

      If Not (oVenta.TipoComprobante.EsElectronico And Not oVenta.TipoComprobante.EsPreElectronico) Then
         For Each oComprobante In oVenta.Invocados
            Select Case oComprobante.Invocado.TipoTipoComprobante
               Case Entidades.TipoComprobante.Tipos.VENTAS.ToString()
                  If oVenta.SeleccionoInvocados = Entidades.Publicos.SiNoTodos.NO Then
                     noDisponible = sql.GetDisponibilidadComprobanteInvocado(oComprobante.IdSucursalInvocado,
                                                                             oComprobante.IdTipoComprobanteInvocado,
                                                                             oComprobante.LetraInvocado,
                                                                             oComprobante.CentroEmisorInvocado,
                                                                             oComprobante.NumeroComprobanteInvocado)
                  Else
                     noDisponible = True
                  End If
               Case Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString()
                  Dim estado As String = String.Empty
                  If oVenta.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
                     estado = Publicos.EstadoPedidoPendiente
                  End If
                  noDisponible = sql.GetDisponibilidadPedidoInvocado(oComprobante.IdSucursalInvocado,
                                                              oComprobante.IdTipoComprobanteInvocado,
                                                              oComprobante.LetraInvocado,
                                                              oComprobante.CentroEmisorInvocado,
                                                              oComprobante.NumeroComprobanteInvocado,
                                                              estado,
                                                              oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura,
                                                              oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito)


               Case Entidades.TipoComprobante.Tipos.COMPRAS.ToString()
                  noDisponible = sql.GetDisponibilidadComprasInvocado(oComprobante.IdSucursalInvocado,
                                                       oComprobante.IdTipoComprobanteInvocado,
                                                       oComprobante.LetraInvocado,
                                                       oComprobante.CentroEmisorInvocado,
                                                       oComprobante.NumeroComprobanteInvocado)
            End Select
            If noDisponible = False Then
               Throw New Exception(String.Format("El Comprobante Invocado {0} {1} {2:0000}-{3:00000000} no se encuentra disponible...", oComprobante.IdTipoComprobanteInvocado, oComprobante.LetraInvocado, oComprobante.CentroEmisorInvocado, oComprobante.NumeroComprobanteInvocado))
            End If
         Next
      End If
   End Sub

   Public Function GetExportacionVentasPDA(idSucursal As Integer,
                                        desde As Date,
                                        hasta As Date,
                                        Optional IdVendedor As Integer = 0,
                                        Optional grabaLibro As String = "TODOS",
                                        Optional idCliente As Long = 0,
                                        Optional afectaCaja As String = "TODOS",
                                        Optional tipoComprobante As String = "") As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("  SELECT  PE.CentroEmisor As CentroEmisorPedido ")
         .AppendLine("         ,PE.NumeroPedido ")
         .AppendLine("         ,C.CodigoCliente ")
         .AppendLine("         ,C.NombreCliente ")
         .AppendLine("         ,V.IdSucursal ")
         .AppendLine("         ,V.IdTipoComprobante ")
         .AppendLine("         ,TC.DescripcionAbrev ")
         .AppendLine("         ,TC.CoeficienteValores ")
         .AppendLine("         ,V.Letra ")
         .AppendLine("         ,V.CentroEmisor ")
         .AppendLine("         ,V.NumeroComprobante ")
         .AppendLine("         ,V.Fecha ")
         .AppendLine("         ,V.IdEstadoComprobante ")
         .AppendLine("         ,V.ImporteTotal ")
         .AppendLine("         ,V.SubTotal ")
         .AppendLine("         ,V.TotalImpuestos ")
         .AppendLine("         ,V.TotalImpuestoInterno ")
         .AppendLine("         ,TC1.TipoComprobantePDA ")


         .AppendLine("       ,0 as Cuit ")
         .AppendLine("       ,'' as Direccion ")
         .AppendLine("       ,'' as TipoDocCliente ")
         .AppendLine("       ,0 as NroDocCliente ")
         .AppendLine("       ,0 as CP ")
         .AppendLine("       ,'' as NombreLocalidad ")
         .AppendLine("       ,'' as NombreProvincia ")
         .AppendLine("       ,'' as IdCategoriaFiscal ")
         .AppendLine("       ,0  as Alicuota ")
         .AppendLine("       ,0  as Neto ")
         .AppendLine("       ,'' as IdAFIPTipoDocumento ")
         .AppendLine("       ,0 as IdTipoImpuesto")
         .AppendLine("       ,0 as ImportePorPercepcion ")

         .AppendLine("  FROM PedidosEstados PE ")
         .AppendLine("     LEFT JOIN Ventas V ON V.IdSucursal = PE.IdSucursalFact  ")
         .AppendLine("               AND V.IdTipoComprobante = PE.IdTipoComprobanteFact  ")
         .AppendLine("               AND V.Letra = PE.LetraFact  ")
         .AppendLine("               AND V.CentroEmisor = PE.CentroEmisorFact ")
         .AppendLine("               AND V.NumeroComprobante = PE.NumeroComprobanteFact ")
         .AppendLine("     LEFT JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendLine("	   LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("     LEFT JOIN TiposComprobantesPDA TC1 ON TC1.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendLine("               AND TC1.Letra = V.Letra")

         .AppendLine("  WHERE PE.IdEStado <> 'ANULADO' ")

         .AppendLine("        AND PE.IdSucursal= " & idSucursal.ToString())

         If Not String.IsNullOrEmpty(tipoComprobante) Then
            .AppendLine("     AND PE.idtipocomprobante = '" & tipoComprobante & "'")
         End If

         .AppendLine("     AND V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("     AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If IdVendedor > 0 Then
            .AppendLine("     AND V.IdVendedor = " & IdVendedor)
         End If

         If idCliente <> 0 Then
            .AppendLine("     AND C.IdCliente = " & idCliente)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("     AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("     AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         .AppendLine(" GROUP BY ")
         .AppendLine("        PE.CentroEmisor")
         .AppendLine("      , PE.NumeroPedido")
         .AppendLine("      , C.CodigoCliente")
         .AppendLine("      , C.NombreCliente")
         .AppendLine("      , V.IdSucursal")
         .AppendLine("      , V.IdTipoComprobante")
         .AppendLine("      , TC.DescripcionAbrev")
         .AppendLine("      , V.Letra")
         .AppendLine("      , V.CentroEmisor")
         .AppendLine("      , V.NumeroComprobante")
         .AppendLine("      , V.Fecha")
         .AppendLine("      , V.IdEstadoComprobante")
         .AppendLine("      , V.ImporteTotal")
         .AppendLine("      , V.SubTotal")
         .AppendLine("      , V.TotalImpuestos")
         .AppendLine("      , V.TotalImpuestoInterno")
         .AppendLine("      , TC1.TipoComprobantePDA")
         .AppendLine("     , TC.CoeficienteValores ")



         .AppendLine(" ORDER BY NumeroPedido ")

      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetExportacionVentasHolistor(sucursales As Entidades.Sucursal(),
                                                desde As Date,
                                                hasta As Date,
                                                idVendedor As Integer,
                                                grabaLibro As String,
                                                idCliente As Long,
                                                afectaCaja As String,
                                                idTipoComprobante As String) As DataTable
      '# Si utiliza Sub Rubros, se va a utilizar el cód. Exportación de esa tabla.
      '# Caso contrario se va a utilizar el cód. Exportación de la tabla de Rubros

      Dim sVentas = New SqlServer.Ventas(da)
      Return sVentas.GetExportacionVentasHolistor(sucursales,
                                                  desde,
                                                  hasta,
                                                  idVendedor,
                                                  grabaLibro,
                                                  idCliente,
                                                  afectaCaja,
                                                  idTipoComprobante,
                                                  Publicos.ProductoTieneSubRubro)
   End Function

   Public Function GetExportacionVentas(sucursales As Entidades.Sucursal(),
                                      desde As Date,
                                      hasta As Date,
                                      listaComprobantes As List(Of Entidades.TipoComprobante),
                                      Optional IdVendedor As Integer = 0,
                                      Optional grabaLibro As String = "TODOS",
                                      Optional idCliente As Long = 0,
                                      Optional afectaCaja As String = "TODOS",
                                      Optional tipoComprobante As String = "") As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim discIVA As Boolean
      discIVA = oCategoriaFiscalEmpresa.IvaDiscriminado

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0

         .Length = 0
         .AppendLine("SELECT V.Fecha")
         .AppendLine("      ,V.IdSucursal")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,V.IdVendedor ")
         .AppendLine("      ,E.NombreEmpleado")
         .AppendLine("      ,V.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("    ,CASE WHEN C.EsClienteGenerico = 'True' THEN V.NombreCliente ELSE C.NombreCliente END AS NombreCliente")
         .AppendLine("    ,C.NombreDeFantasia")
         .AppendLine("      ,CV.IdCliente IdClienteVinculado")
         .AppendLine("      ,CV.CodigoCliente CodigoClienteVinculado")
         .AppendLine("      ,CV.NombreCliente NombreClienteVinculado")
         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine("      ,V.IdEstadoComprobante")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago as FormaDePago")
         'RI
         If discIVA Then
            .AppendLine("	,V.SubTotal")
            .AppendLine("	,V.TotalImpuestos")
            .AppendLine("  ,V.TotalImpuestoInterno")
            .AppendLine("	,V.ImporteTotal")
            .AppendLine("  ,V.Utilidad")
            'Monotributo
         Else
            .AppendLine("  ,V.ImporteTotal AS Subtotal ")
            .AppendLine("	,0 AS TotalImpuestos ")
            .AppendLine("  ,0 AS TotalImpuestoInterno")
            .AppendLine("	,V.ImporteTotal")
            .AppendLine("  ,V.Utilidad + V.TotalImpuestos + V.TotalImpuestoInterno as Utilidad ")
         End If
         .AppendLine("     ,V.Usuario")
         .AppendLine("     ,V.Observacion")
         .AppendLine("     ,E.NombreEmpleado")
         .AppendLine("     ,ZG.NombreZonaGeografica")
         .AppendLine("     ,L.NombreLocalidad")
         .AppendLine("     ,PV.NombreProvincia")
         .AppendLine("     ,V.FechaActualizacion")
         .AppendLine("  	,PR.NombreProveedor")
         .AppendLine("     ,V.ImportePesos")
         .AppendLine("     ,V.ImporteTickets")
         .AppendLine("     ,V.ImporteTarjetas")
         .AppendLine("     ,V.ImporteCheques")
         .AppendLine("     ,V.IdCuentaBancaria")
         .AppendLine("     ,V.ImporteTransfBancaria")
         .AppendLine("     ,B.NombreBanco")

         .AppendLine("     ,ISNULL((SELECT SUM(VI.Importe) FROM VentasImpuestos VI")
         .AppendLine("               WHERE VI.IdSucursal = V.IdSucursal")
         .AppendLine("                 AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                 AND VI.Letra = V.Letra")
         .AppendLine("                 AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("                 AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("                 AND VI.IdTipoImpuesto <> 'IVA'), 0) Percepciones")

         If discIVA Then
            .AppendLine("     ,ISNULL((SELECT SUM(VI.Importe) FROM VentasImpuestos VI")
            .AppendLine("               WHERE VI.IdSucursal = V.IdSucursal")
            .AppendLine("                 AND VI.IdTipoComprobante = V.IdTipoComprobante")
            .AppendLine("                 AND VI.Letra = V.Letra")
            .AppendLine("                 AND VI.CentroEmisor = V.CentroEmisor")
            .AppendLine("                 AND VI.NumeroComprobante = V.NumeroComprobante")
            .AppendLine("                 AND VI.IdTipoImpuesto = 'IVA'), 0) IVA")
         Else
            .AppendLine("  ,0 AS IVA")
         End If
         .AppendLine("         ,TC1.TipoComprobantePDA ")
         .AppendLine("         ,TC.CoeficienteValores ")

         .AppendLine(" FROM Ventas V")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  LEFT JOIN Clientes CV ON CV.IdCliente = V.IdClienteVinculado")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias PV ON PV.IdProvincia = L.IdProvincia")

         'If Categoria <> "MOVIMIENTO" Then
         '   .AppendLine("  INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         'Else
         '   .AppendLine("  INNER JOIN Categorias CA ON CA.IdCategoria = V.IdCategoria")
         'End If

         .AppendLine(" LEFT JOIN CajasNombres CN ON CN.IdSucursal = V.IdSucursal AND CN.IdCaja = V.IdCaja")

         .AppendLine(" LEFT JOIN Proveedores PR ON PR.IdProveedor = V.IdProveedor")
         .AppendLine(" LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = V.IdCuentaBancaria")
         .AppendLine(" LEFT JOIN Bancos B ON B.IdBanco = CB.IdBanco")
         .AppendLine(" LEFT JOIN Monedas M ON M.IdMoneda = V.IdMoneda")
         .AppendLine("  LEFT JOIN TiposComprobantesPDA TC1 ON TC1.IdTipoComprobante = V.IdTipoComprobante AND TC1.Letra = V.Letra")
         .AppendLine(" WHERE 1=1")

         .AppendLine("	  AND V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("	  AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "V")

         If IdVendedor > 0 Then
            .AppendLine("	 AND V.IdVendedor = " & IdVendedor)
         End If

         If idCliente <> 0 Then
            .AppendLine("	 AND C.IdCliente = " & idCliente)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If listaComprobantes.Count > 0 Then

            .Append(" AND V.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               If tc IsNot Nothing Then
                  .AppendFormat(" '{0}',", tc.IdTipoComprobante)
               End If
            Next
            .Remove(.Length - 1, 1)
            .Append(")")

         End If

      End With

      Return Me.da.GetDataTable(stb.ToString())
   End Function

   'Public Function GetExportacionVentasSellOut(sucursales As Entidades.Sucursal(),
   '                                        desde As Date, _
   '                                        hasta As Date, _
   '                                        IdProveedor As Long,
   '                                        IdVendedor As Integer, _
   '                                       grabaLibro As String, _
   '                                        idCliente As Long, _
   '                                        afectaCaja As String, _
   '                                        tipoComprobante As String,
   '                                        listaComprobantes As List(Of Entidades.TipoComprobante)) As DataTable

   '   Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)
   '   Dim ivaDiscriminado As Boolean
   '   ivaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado
   '   Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

   '   Return sql.GetExportacionVentasSellOut(sucursales,
   '                                   desde,
   '                                  hasta,
   '                                  IdProveedor,
   '                                  IdVendedor,
   '                                  grabaLibro,
   '                                  idCliente,
   '                                  afectaCaja,
   '                                  tipoComprobante,
   '                                 ivaDiscriminado,
   '                                 listaComprobantes)


   'End Function
   Public Function GetExportacionVentasDetalle(sucursales As Entidades.Sucursal(),
                                        desde As Date,
                                        hasta As Date,
                                        IdProveedor As Long,
                                        IdVendedor As Integer,
                                       grabaLibro As String,
                                        idCliente As Long,
                                        afectaCaja As String,
                                        tipoComprobante As String,
                                        listaComprobantes As List(Of Entidades.TipoComprobante)) As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim ivaDiscriminado As Boolean
      ivaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

      Return sql.GetExportacionVentasDetalle(sucursales,
          desde,
          hasta,
          IdProveedor,
          IdVendedor,
          idCliente,
          grabaLibro,
          afectaCaja,
          tipoComprobante,
          ivaDiscriminado,
          listaComprobantes)


    End Function
   Public Function GetComprobantesACopiar(idSucursal As Integer, desde As Date, hasta As Date, IdCliente As Long, TipoComprobante As String,
                                       NumeroComprobante As Long, LetraFiscal As String,
                                       CentroEmisor As Integer, NumeroReparto As Integer,
                                       IdCaja As Integer?, usuario As String) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(Me.da)

         Return sql.GetComprobantesACopiar(idSucursal, desde, hasta, IdCliente, TipoComprobante, NumeroComprobante, LetraFiscal,
                                           CentroEmisor, NumeroReparto, IdCaja, usuario)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetParaEliminar(idSucursal As Integer, desde As Date, hasta As Date,
                                   idCliente As Long, idTipoComprobante As String, orden As String) As DataTable
      Return New SqlServer.Ventas(da).GetParaEliminar(idSucursal, desde, hasta, idCliente, idTipoComprobante, orden)
   End Function

   Public Function GetParaImpresionMasiva(idSucursal As Integer,
                                          fechaDesde As Date,
                                          fechaHasta As Date,
                                          impreso As Entidades.Publicos.SiNoTodos,
                                          orden As String,
                                          idCliente As Long,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Short,
                                          nroDesde As Long,
                                          nroHasta As Long,
                                          idEstadoComprobante As String,
                                          grabaLibro As String,
                                          afectaCaja As String,
                                          IdVendedor As Integer,
                                          idFormasPago As Integer,
                                          idUsuario As String,
                                          numeroReparto As Integer,
                                          numeroRepartoHasta As Integer,
                                          categorias As Entidades.Categoria(),
                                          origenCategorias As Entidades.OrigenFK,
                                          exportado As String,
                                          nroRepartoInvocacionMasiva As Integer) As DataTable

      Try

         Me.da.OpenConection()
         Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(Me.da)

         Return sql.GetParaImpresionMasiva(idSucursal,
                                           fechaDesde,
                                           fechaHasta,
                                           impreso,
                                           orden,
                                           idCliente,
                                           idTipoComprobante,
                                           letra,
                                           centroEmisor,
                                           nroDesde,
                                           nroHasta,
                                           idEstadoComprobante,
                                           oCategoriaFiscalEmpresa.IvaDiscriminado,
                                           grabaLibro,
                                           afectaCaja,
                                           IdVendedor,
                                           idFormasPago,
                                           idUsuario,
                                           numeroReparto,
                                           numeroRepartoHasta,
                                           categorias, origenCategorias,
                                           exportado,
                                           nroRepartoInvocacionMasiva)

      Finally
         Me.da.CloseConection()
      End Try

   End Function

   '-- REQ-34676.- ---------------------------------------------------------------------------------------------------------------------------------------
   ''' <summary>
   ''' Obtienen todos los registros para la invocacion masiva de pedidos.- 
   ''' </summary>
   ''' <param name="idEstado"></param>
   ''' <param name="nroOrdenCompra"></param>
   ''' <param name="idCliente"></param>
   ''' <param name="idTransportista"></param>
   ''' <param name="fechaDesde"></param>
   ''' <param name="fechaHasta"></param>
   ''' <returns></returns>
   Public Function GetInvocacionMasivaPedidos(idEstado As String,
                                              nroOrdenCompra As Long,
                                              idCliente As Long,
                                              idTransportista As Long,
                                              fechaDesde As Date?, fechaHasta As Date?) As DataTable
      Return New SqlServer.Ventas(da).GetInvocacionMasivaPedidos(idEstado, nroOrdenCompra, idCliente, idTransportista, fechaDesde, fechaHasta)
   End Function
   ''' <summary>
   ''' Establece el Nombre para el archivo de Exportacion.- 
   ''' </summary>
   ''' <returns></returns>
   Public Function FormatoNombreArchivoExportacion(eVentas As Entidades.Venta) As String
      Dim FormatoParametro = Publicos.Facturacion.Exportacion.FormatoArchivoExportacion
      Dim eSucursal = _cache.BuscaSucursal(eVentas.IdSucursal)
      '-- Comprobantes.- ----------------------------------------------------------------------------------------------------------------
      If FormatoParametro.Contains("@@COMPROBANTE@@") Then
         FormatoParametro = FormatoParametro.Replace("@@COMPROBANTE@@", String.Format("{0}_{1}_{2:0000}_{3:00000000}",
                                                                    eVentas.TipoComprobante.DescripcionAbrev, eVentas.LetraComprobante,
                                                                    eVentas.CentroEmisor, eVentas.NumeroComprobante))
      End If
      If FormatoParametro.Contains("@@TIPOCOMPROB@@") Then
         FormatoParametro = FormatoParametro.Replace("@@TIPOCOMPROB@@", eVentas.TipoComprobante.DescripcionAbrev)
      End If
      If FormatoParametro.Contains("@@LETRACOMPROB@@") Then
         FormatoParametro = FormatoParametro.Replace("@@LETRACOMPROB@@", eVentas.LetraComprobante)
      End If
      If FormatoParametro.Contains("@@CENTROEMISORCOMPROB@@") Then
         FormatoParametro = FormatoParametro.Replace("@@CENTROEMISORCOMPROB@@", String.Format("{0:0000}", eVentas.CentroEmisor))
      End If
      If FormatoParametro.Contains("@@NUMEROCOMPROB@@") Then
         FormatoParametro = FormatoParametro.Replace("@@NUMEROCOMPROB@@", String.Format("{0:00000000}", eVentas.NumeroComprobante))
      End If
      '-- Empresa.- ----------------------------------------------------------------------------------------------------------------
      If FormatoParametro.Contains("@@CUITEMPRESA@@") Then
         FormatoParametro = FormatoParametro.Replace("@@CUITEMPRESA@@", Publicos.CuitEmpresa(eSucursal))
      End If
      If FormatoParametro.Contains("@@NOMBREEMPRESA@@") Then
         FormatoParametro = FormatoParametro.Replace("@@NOMBREEMPRESA@@", Publicos.NombreEmpresaOficial(eSucursal))
      End If
      If FormatoParametro.Contains("@@NOMBREFANTASIAEMPRESA@@") Then
         FormatoParametro = FormatoParametro.Replace("@@NOMBREFANTASIAEMPRESA@@", Publicos.NombreFantasia(eSucursal))
      End If
      '-- Cliente.- ----------------------------------------------------------------------------------------------------------------
      If FormatoParametro.Contains("@@NOMBRECLIENTE@@") Then
         FormatoParametro = FormatoParametro.Replace("@@NOMBRECLIENTE@@", eVentas.NombreCliente)
      End If
      If FormatoParametro.Contains("@@NOMBREFANTASIACLIENTE@@") Then
         If String.IsNullOrEmpty(eVentas.Cliente.NombreDeFantasia) Then
            FormatoParametro = FormatoParametro.Replace("@@NOMBREFANTASIACLIENTE@@", eVentas.NombreCliente)
         Else
            FormatoParametro = FormatoParametro.Replace("@@NOMBREFANTASIACLIENTE@@", eVentas.Cliente.NombreDeFantasia)
         End If
      End If
      If FormatoParametro.Contains("@@CUITCLIENTE@@") Then
         If String.IsNullOrEmpty(eVentas.Cuit) Then
            FormatoParametro = FormatoParametro.Replace("@@CUITCLIENTE@@", eVentas.Cliente.Cuit)
         Else
            FormatoParametro = FormatoParametro.Replace("@@CUITCLIENTE@@", eVentas.Cuit)
         End If
      End If
      '-- Nro Reparto.- ----------------------------------------------------------------------------------------------------------------
      If FormatoParametro.Contains("@@NROREPARTO@@") Then
         FormatoParametro = FormatoParametro.Replace("@@NROREPARTO@@", String.Format("{0:00000000}", eVentas.NumeroReparto))
      End If
      '---------------------------------------------------------------------------------------------------------------------------------
      Return String.Format("{0}.pdf", FormatoParametro)
   End Function
   '-- REQ-34678.- ---------------------------------------------------------------------------------------------------------------------------------------
   ''' <summary>
   ''' Obtienen todos los registros para la invocacion masiva de Comprobantes.- 
   ''' </summary>
   ''' <param name="nroOrdenCompra"></param>
   ''' <param name="idCliente"></param>
   ''' <param name="idTransportista"></param>
   ''' <param name="fechaDesde"></param>
   ''' <param name="fechaHasta"></param>
   ''' <returns></returns>
   Public Function GetInvocacionMasivaComprobantes(idSucursal As Integer, idCliente As Long, idTransportista As Long, nroOrdenCompra As Long,
                                                   nroReparto As Integer, nroFacturaProveedor As String, nroRemitoProveedor As String,
                                                   fechaDesde As Date?, fechaHasta As Date?) As DataTable
      Return New SqlServer.Ventas(da).GetInvocacionMasivaComprobantes(idSucursal, idCliente, idTransportista, nroOrdenCompra,
                                                                      nroReparto, nroFacturaProveedor, nroRemitoProveedor,
                                                                      fechaDesde, fechaHasta)
   End Function

   Public Sub ModificarTComp(filas As DataRow(), idTipoComprobanteFact As String)
      EjecutaConConexion(
         Sub()
            filas.Where(Function(f) f IsNot Nothing).ToList().
                  ForEach(Sub(fila) EjecutaSoloConTransaccion(Sub() ModificarTComp(fila, idTipoComprobanteFact)))
         End Sub)
   End Sub

   Public Sub ModificarTComp(fila As DataRow, idTipoComprobanteFact As String)
      ModificarTComp(fila.Field(Of Integer)("IdSucursal"),
                     fila.Field(Of String)("IdTipoComprobante"), fila.Field(Of String)("Letra"),
                     fila.Field(Of Integer)("CentroEmisor"), fila.Field(Of Long)("NumeroComprobante"),
                     idTipoComprobanteFact)
   End Sub

   Public Sub ModificarTComp(idSucursal As Integer,
                             idTipoComprobante As String, letra As String,
                             centroEmisor As Integer, numeroPedido As Long,
                             idTipoComprobanteFact As String)
      Dim sql = New SqlServer.Ventas(da)
      sql.Cambia_TipoCompFact(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idTipoComprobanteFact)
   End Sub
   '-----------------------------------------------------------------------------------------------------------------------------------------------------
   Public Function GenerarPedidosInvocadosMasivos(data As DataRow(),
                                                  idCaja As Integer, idFuncion As String,
                                                  nroFacturaProveedor As String, nroRemitoProveedor As String,
                                                  fechaImputacion As Date) As Integer
      Return EjecutaConTransaccion(
                  Function() _GenerarPedidosInvocadosMasivos(data,
                                                             idCaja, idFuncion,
                                                             nroFacturaProveedor, nroRemitoProveedor,
                                                             fechaImputacion))
   End Function

   Public Function _GenerarPedidosInvocadosMasivos(data As DataRow(),
                                                   idCaja As Integer, idFuncion As String,
                                                   nroFacturaProveedor As String, nroRemitoProveedor As String,
                                                   fechaImputacion As Date) As Integer

      Dim rPedido = New Pedidos(da)
      Dim rVenta = New Ventas(da)
      Dim idReparto As Integer = rVenta.GetUltNumeroReparto() + 1

      For Each dr As DataRow In data
         Dim oPedido = rPedido.GetUno(Integer.Parse(dr(Entidades.Pedido.Columnas.IdSucursal.ToString()).ToString()),
                                      dr(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString(),
                                      dr(Entidades.Pedido.Columnas.Letra.ToString()).ToString(),
                                      Short.Parse(dr(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString()),
                                      Long.Parse(dr(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString()),
                                      Publicos.EstadoPedidoPendiente)

         Dim venta = rPedido.ConvertirPedidoEnVenta(oPedido, idCaja, idReparto)
         '-- Cambia Fecha de Imputacion.- --
         venta.Fecha = fechaImputacion.Date + Date.Now.TimeOfDay
         '-- Incorpora Datos de Nro de Factura y Remito de Proveedor.- --
         venta.NroFacturaProveedor = nroFacturaProveedor
         venta.NroRemitoProveedor = nroRemitoProveedor
         '---------------------------------------------------------------
         rVenta.Inserta(venta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
      Next
      '---------------------------------------------------------------
      Return idReparto
      '---------------------------------------------------------------
   End Function
   Public Function GenerarComprobotantesInvocaMasiva(data As DataRow(), IdFuncion As String, idCaja As Integer, fechaImputacion As Date) As Integer
      Return EjecutaConTransaccion(Function() _GenerarComprobotantesInvocaMasiva(data, IdFuncion, idCaja, fechaImputacion))
   End Function
   Public Function _GenerarComprobotantesInvocaMasiva(data As DataRow(), IdFuncion As String, idNroCaja As Integer, fechaImputacion As Date) As Integer

      '-----------------------------------------------------------------------------
      Dim rVenta = New Ventas(da)
      Dim idReparto As Integer = rVenta.GetNuevoNumeroReparto()

      For Each dr As DataRow In data
         '-- Obtener un comprobante desde el que seleccione en la grilla.- --
         Dim eVentas = rVenta.GetUna(Integer.Parse(dr(Entidades.Venta.Columnas.IdSucursal.ToString()).ToString()),
                                        dr(Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString(),
                                        dr(Entidades.Venta.Columnas.Letra.ToString()).ToString(),
                                        Short.Parse(dr(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToString()),
                                        Long.Parse(dr(Entidades.Venta.Columnas.NumeroComprobante.ToString()).ToString()))
         '-- Obtengo el tipo de Comprobante.- --
         Dim eNuevoTipoComprobante = New TiposComprobantes().GetUno(eVentas.IdTipoComprobanteInvocacionMasiva)
         '-- Guardo Categoria Fiscal Vieja.- --
         Dim CatFiscalOld = eVentas.CategoriaFiscal.IdCategoriaFiscal
         '-- Obtengo el coeValAnterior del comprobante de ORIGEN.- --
         Dim coeValAnterior As Integer = eVentas.TipoComprobante.CoeficienteValores
         '--------------------------------------------------------------------------
         Dim nuevo = CreaVenta(eVentas.IdSucursal,
                               eNuevoTipoComprobante, String.Empty, 0,
                               Nothing,
                               eVentas.Cliente,
                               eVentas.CategoriaFiscal,
                               fechaImputacion.Date + Date.Now.TimeOfDay,
                               eVentas.Vendedor, eVentas.Transportista, eVentas.FormaPago,
                               eVentas.DescuentoRecargoPorc,
                               If(eVentas.IdCaja = 0, idNroCaja, eVentas.IdCaja), eVentas.CotizacionDolar, eVentas.MercDespachada,
                               If(eVentas.NumeroReparto > 0, eVentas.NumeroReparto, Nothing),
                               If(eVentas.FechaEnvio <> Nothing, eVentas.FechaEnvio, Nothing),
                               eVentas.Proveedor,
                               If(eNuevoTipoComprobante.ImportaObservDeInvocados, eVentas.Observacion, ""),
                               eVentas.Cobrador,
                               clienteVinculado:=Nothing,
                               eVentas.NumeroOrdenCompra)
         nuevo.NroFacturaProveedor = eVentas.NroFacturaProveedor
         nuevo.NroRemitoProveedor = eVentas.NroRemitoProveedor
         '-- Carga nuevo numero de Reparto Masivo.- ---
         nuevo.NroRepartoInvocacionMasiva = idReparto
         '---------------------------------------------
         For Each vp In eVentas.VentasProductos
            If eNuevoTipoComprobante.UtilizaImpuestos Then
               '--
               If (eVentas.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                        Not eVentas.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
               Else
                  vp.Precio = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.DescRecGeneral = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescRecGeneral, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.DescuentoRecargo = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescuentoRecargo, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.PrecioNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioNeto, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.ImporteTotal = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotal, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.ImporteTotalNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotalNeto, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
               End If
               '--
            Else
               vp.Producto.Alicuota = 0
            End If
            AgregarVentaProducto(nuevo,
                                       CreaVentaProducto(vp.Producto, vp.NombreProducto,
                                                         vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2,
                                                         vp.Precio,
                                                         vp.Cantidad,
                                                         _cache.BuscaTiposImpuestos(vp.Producto.IdTipoImpuesto),
                                                         If(eNuevoTipoComprobante.UtilizaImpuestos, vp.Producto.Alicuota, 0),
                                                         _cache.BuscaListaDePrecios(vp.IdListaPrecios),
                                                         vp.FechaEntrega,
                                                         vp.TipoOperacion,
                                                         vp.Nota,
                                                         idEstadoVenta:=Nothing,
                                                         venta:=nuevo,
                                                         redondeoEnCalculo:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio),
                                       Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
         Next

         'Agregar producto con descuento recargo si la OC aplica descuento
         Dim OC As Entidades.OrdenCompra = New Reglas.OrdenesCompra(da).GetUno(eVentas.IdSucursal, eVentas.NumeroOrdenCompra, AccionesSiNoExisteRegistro.Nulo)
         If OC.AplicaDescuentoRecargo Then
            If Not String.IsNullOrEmpty(Publicos.CodigoProductoDRInvocacionMasiva) Then
               Dim Producto As Entidades.Producto = New Reglas.Productos(da).GetUno(Publicos.CodigoProductoDRInvocacionMasiva, False)
               If Publicos.PorcentajeDRInvocacionMasiva <> 0 Then

                  Dim Importe As Decimal = (eVentas.ImporteTotal * Publicos.PorcentajeDRInvocacionMasiva) / 100
                  AgregarVentaProducto(nuevo, CreaVentaProducto(Producto, Producto.NombreProducto,
                                                         0, 0, Importe, cantidad:=1,
                                                         _cache.BuscaTiposImpuestos(Producto.IdTipoImpuesto),
                                                         If(eNuevoTipoComprobante.UtilizaImpuestos, Producto.Alicuota, 0),
                                                         _cache.BuscaListaDePrecios(Publicos.ListaPreciosPredeterminada),
                                                         fechaEntrega:=Nothing,
                                                         tipoOperacion:=0, nota:="",
                                                         idEstadoVenta:=Nothing,
                                                         venta:=nuevo,
                                                         redondeoEnCalculo:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio),
                                                         Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
               Else
                  Throw New Exception("No esta definido el porcentaje de D/R en Invocacion Masiva de Comprobantes. (Parametros de Sistema\Ventas\Ventas3)")
               End If
            Else
               Throw New Exception("No esta definido el Producto para D/R en Invocacion Masiva de Comprobantes. (Parametros de Sistema\Ventas\Ventas3)")
            End If
         End If

         '--------------------------------------------------------------------------
         'nuevo.Invocados.Add(eVentas)
         AgregarInvocado(nuevo, eVentas)
         '--------------------------------------------------------------------------
         AgregarVentaContactos(nuevo, eVentas.VentasContactos)
         If eNuevoTipoComprobante.ImportaObservGrales Then
            AgregarVentaObservacion(nuevo, eVentas.VentasObservaciones)
         End If
         '--------------------------------------------------------------------------
         If Not nuevo.Cliente.EsClienteGenerico AndAlso CatFiscalOld <> nuevo.CategoriaFiscal.IdCategoriaFiscal Then
            nuevo.Cuit = nuevo.Cliente.Cuit
            nuevo.TipoDocCliente = nuevo.Cliente.TipoDocCliente
            nuevo.NroDocCliente = nuevo.Cliente.NroDocCliente
         End If
         '--------------------------------------------------------------------------
         Inserta(nuevo, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)
      Next
      '---------------------------------------------------------------
      Return idReparto
      '---------------------------------------------------------------
   End Function
   '---------------------------
End Class
Public Class ComprasProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasProductos_I(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long,
                                 idProveedor As Long,
                                 orden As Integer,
                                 idProducto As String,
                                 nombreProducto As String,
                                 cantidad As Double,
                                 precio As Double,
                                 descRecGeneral As Double,
                                 descRecGeneralProducto As Double,
                                 descuentoRecargo As Double,
                                 descuentoRecargoProducto As Double,
                                 descuentoRecargoPorc As Double,
                                 precioNeto As Double,
                                 importeTotal As Double,
                                 importeTotalNeto As Double,
                                 porcentajeIVA As Decimal,
                                 iva As Decimal,
                                 idConcepto As Integer,
                                 pasajeMovimiento As Boolean,
                                 montoAplicado As Decimal,
                                 montoSaldo As Decimal,
                                 proporcionalImp As Decimal,
                                 idCentroCosto As Integer?,
                                 idaAtributo01 As Integer?,
                                 idaAtributo02 As Integer?,
                                 idaAtributo03 As Integer?,
                                 idaAtributo04 As Integer?,
                                 idDeposito As Integer?,
                                 idUbicacion As Integer?,
                                 calidadNumero As String,
                                 linkDoc As String,
                                 idLote As String,
                                 fechaVencimientoLote As Date?,
                                 cantidadUMCompra As Decimal,
                                 factorConversionCompra As Decimal,
                                 precioPorUMCompra As Decimal,
                                 idUnidadDeMedida As String,
                                 idUnidadDeMedidaCompra As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO ComprasProductos ")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,Letra")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,IdProveedor")
         .AppendLine("           ,Orden")
         .AppendLine("           ,IdProducto")
         .AppendLine("           ,NombreProducto")
         .AppendLine("           ,Cantidad")
         .AppendLine("           ,Precio")
         .AppendLine("           ,DescRecGeneral")
         .AppendLine("           ,DescRecGeneralProducto")
         .AppendLine("           ,DescuentoRecargo")
         .AppendLine("           ,DescuentoRecargoProducto")
         .AppendLine("           ,DescuentoRecargoPorc")
         .AppendLine("           ,PrecioNeto")
         .AppendLine("           ,ImporteTotal")
         .AppendLine("           ,ImporteTotalNeto")
         .AppendLine("           ,PorcentajeIVA")
         .AppendLine("           ,IVA")
         .AppendLine("           ,IdConcepto")
         .AppendLine("           ,PasajeMovimiento")
         .AppendLine("           ,MontoAplicado")
         .AppendLine("           ,MontoSaldo")
         .AppendLine("           ,ProporcionalImp")
         .AppendLine("           ,IdCentroCosto")
         '-- REQ-34747.- -----------------------------------
         .Append("           ,IdaAtributoProducto01")
         .Append("           ,IdaAtributoProducto02")
         .Append("           ,IdaAtributoProducto03")
         .Append("           ,IdaAtributoProducto04")
         '--------------------------------------------------
         .Append("           ,IdDeposito")
         .Append("           ,IdUbicacion")
         '--------------------------------------------------
         .Append("           ,InformeCalidadNumero")
         .Append("           ,InformeCalidadLink")
         '--------------------------------------------------
         .Append("           ,IdLote")
         .Append("           ,FechaVencimientoLote")
         .AppendLine("           ,CantidadUMCompra")
         .AppendLine("           ,FactorConversionCompra")
         .AppendLine("           ,PrecioPorUMCompra")
         .AppendLine("           ,IdUnidadDeMedida")
         .AppendLine("           ,IdUnidadDeMedidaCompra")
         '--------------------------------------------------
         .AppendLine(") VALUES ")
         .AppendLine(" ( " & idSucursal & "")
         .AppendLine(" , '" & idTipoComprobante & "'")
         .AppendLine(" , '" & letra & "'")
         .AppendLine(" , " & centroEmisor)
         .AppendLine(" , " & numeroComprobante)
         .AppendLine(" , " & idProveedor.ToString())
         .AppendLine(" , " & orden.ToString())
         .AppendLine(" , '" & idProducto & "'")
         .AppendLine(" ,'" & nombreProducto & "'")
         .AppendLine(" , " & cantidad.ToString())
         .AppendLine(" , " & precio.ToString())
         .AppendLine(" , " & descRecGeneral.ToString())
         .AppendLine(" , " & descRecGeneralProducto.ToString())
         .AppendLine(" , " & descuentoRecargo.ToString())
         .AppendLine(" , " & descuentoRecargoProducto.ToString())
         .AppendLine(" , " & descuentoRecargoPorc.ToString())
         .AppendLine(" , " & precioNeto.ToString())
         .AppendLine(" , " & importeTotal.ToString())
         .AppendLine(" , " & importeTotalNeto.ToString())
         .AppendFormat(" ,{0} ", porcentajeIVA).AppendLine()
         .AppendFormat(" ,{0}", iva).AppendLine()
         If idConcepto > 0 Then
            .AppendFormat(" ,{0}", idConcepto).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If
         .AppendFormat(" ,{0}", GetStringFromBoolean(pasajeMovimiento)).AppendLine()
         .AppendFormat(" ,{0}", montoAplicado).AppendLine()
         .AppendFormat(" ,{0}", montoSaldo).AppendLine()
         .AppendFormat(" ,{0}", proporcionalImp).AppendLine()
         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendFormat(" ,{0}", idCentroCosto.Value).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If
         '-- REQ-34747.- -----------------------------------
         If idaAtributo01 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo01)
         Else
            .AppendLine("           ,NULL")
         End If
         If idaAtributo02 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo02)
         Else
            .AppendLine("           ,NULL")
         End If
         If idaAtributo03 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo03)
         Else
            .AppendLine("           ,NULL")
         End If
         If idaAtributo04 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo04)
         Else
            .AppendLine("           ,NULL")
         End If
         '--------------------------------------------------
         If idDeposito > 0 Then
            .AppendFormat("           ,{0}", idDeposito)
         Else
            .AppendLine("           ,NULL")
         End If
         If idUbicacion > 0 Then
            .AppendFormat("           ,{0}", idUbicacion)
         Else
            .AppendLine("           ,NULL")
         End If
         '--------------------------------------------------
         If Not String.IsNullOrEmpty(calidadNumero) Then
            .AppendFormat("           ,'{0}'", calidadNumero)
         Else
            .AppendLine("           ,NULL")
         End If
         If Not String.IsNullOrEmpty(linkDoc) Then
            .AppendFormat("           ,'{0}'", linkDoc)
         Else
            .AppendLine("           ,NULL")
         End If
         '--------------------------------------------------
         If Not String.IsNullOrEmpty(idLote) Then
            .AppendFormat("           ,'{0}'", idLote)
            .AppendFormat("           , {0}", ObtenerFecha(fechaVencimientoLote, True))
         Else
            .AppendLine("           ,NULL")
            .AppendLine("           ,NULL")
         End If
         '--------------------------------------------------
         .AppendFormatLine("           ,{0}", cantidadUMCompra)
         .AppendFormatLine("           ,{0}", factorConversionCompra)
         .AppendFormatLine("           ,{0}", precioPorUMCompra)
         .AppendFormatLine("           ,'{0}'", idUnidadDeMedida)
         .AppendFormatLine("           ,'{0}'", idUnidadDeMedidaCompra)
         .Append(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ComprasProductos")

   End Sub

   Public Sub ComprasProductos_D(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long,
                                 IdProveedor As Long,
                                 orden As Integer,
                                 idProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM ComprasProductos  ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal & "")
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
         .AppendLine("   AND Orden = " & orden.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ComprasProductos")
   End Sub

   Public Function GetDetallePorProductos(idSucursal As Integer, desde As Date?, hasta As Date?,
                                          idProducto As String,
                                          idMarca As Integer, rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subsubrubros As Entidades.SubSubRubro(),
                                          idTipoComprobante As String, IdComprador As Integer, idProveedor As Long,
                                          grabaLibro As String, afectaCaja As String, idFormaDePago As Integer,
                                          cantidad As String, nivelAutorizacion As Short, periodoFiscalDesde As Integer, periodoFiscalHasta As Integer,
                                          top As Integer, orderBy As Entidades.ComprasProductos_GetDetallePorProductos_OrderBy) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} C.Fecha", If(top > 0, String.Format("TOP {0}", top), String.Empty))
         .AppendLine("      ,C.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev")
         .AppendLine("      ,C.Letra")
         .AppendLine("      ,C.CentroEmisor")
         .AppendLine("      ,C.NumeroComprobante")
         .AppendLine("      ,C.IdComprador")

         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,PV.CodigoProveedor")
         .AppendLine("      ,CASE WHEN PV.EsProveedorGenerico = 'True' THEN C.NombreProveedor ELSE PV.NombreProveedor END AS NombreProveedor")
         .AppendLine("      ,PV.NombreProveedor")
         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         '.AppendLine(",C.IdEstadoComprobante")
         .AppendLine("      ,C.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago AS FormaDePago")
         .AppendLine("      ,CP.IdProducto")
         .AppendLine("      ,CASE WHEN P.PermiteModificarDescripcion = 1 THEN CP.NombreProducto ELSE P.NombreProducto END NombreProducto")
         '.AppendLine("      ,CP.NombreProducto")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,SSR.NombreSubSubRubro")
         .AppendLine("      ,CP.Cantidad")
         .AppendLine("        ,CP.CantidadUMCompra
	                           ,CP.IdUnidadDeMedida
	                           ,CP.IdUnidadDeMedidaCompra
	                           ,CP.FactorConversionCompra
                              ,UNS.NombreUnidadDeMedida
	                           ,UNC.NombreUnidadDeMedida NombreUnidadDeMedidaCompra")
         .AppendLine("      ,CP.Precio")
         '.AppendLine("      ,CP.Costo")
         .AppendLine("      ,CP.DescRecGeneral")
         .AppendLine("      ,CP.DescuentoRecargo")
         '.AppendLine("      ,CP.PrecioLista")
         .AppendLine("      ,CP.DescuentoRecargoPorc")
         '.AppendLine("      ,CP.DescuentoRecargoPorc2")
         .AppendLine("      ,CP.DescuentoRecargoProducto")
         .AppendLine("      ,C.DescuentoRecargoPorc AS DescuentoRecargoPorcGral")
         .AppendLine("      ,CP.PrecioNeto")
         '.AppendLine("      ,CP.Utilidad")
         '.AppendLine("      ,CP.IdTipoImpuesto")
         .AppendLine("      ,CP.PorcentajeIva")
         .AppendLine("      ,CP.IVA")
         .AppendLine("      ,CP.ImporteTotal")
         .AppendLine("      ,CP.ImporteTotalNeto")
         '.AppendLine("      ,CP.Kilos")
         '.AppendLine("      ,C.Usuario")
         .AppendLine("      ,CP.IdCentroCosto")
         .AppendLine("      ,CCC.NombreCentroCosto")
         .AppendLine("      ,C.PeriodoFiscal")
         .AppendLine("      ,C.Observacion AS Observaciones")
         .AppendLine("      ,P.NombreProducto AS NombreActualProducto")
         '-.PE-31661.-
         .AppendLine("      ,C.ImportePesos")
         .AppendLine("      ,C.ImporteTarjetas")
         .AppendLine("      ,C.ImporteCheques")
         .AppendLine("      ,C.ImporteTransfBancaria ")
         .AppendLine("      ,C.IdCuentaBancaria")
         .AppendLine("      ,CB.NombreCuenta")
         '-- REQ-40918.- ----------------------------------------------------------
         .AppendLine("      ,SD.NombreDeposito")
         .AppendLine("      ,SU.NombreUbicacion")
         .AppendLine("      ,CP.InformeCalidadNumero")
         .AppendLine("      ,CP.InformeCalidadLink")
         .AppendLine("      ,CP.IdLote")
         .AppendLine("      ,CP.FechaVencimientoLote")
         '-- REQ-35221.- ----------------------------------------------------------
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto01 IS NULL THEN 0  ELSE AP01.IdaAtributoProducto END) AS IdaAtributoProducto01")
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto01 IS NULL THEN '' ELSE AP01.Descripcion END) AS DescripcionAtributo01")
         '--
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto02 IS NULL THEN 0  ELSE AP02.IdaAtributoProducto END) AS IdaAtributoProducto02")
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto02 IS NULL THEN '' ELSE AP02.Descripcion END) AS DescripcionAtributo02")
         '--
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto03 IS NULL THEN 0  ELSE AP03.IdaAtributoProducto END) AS IdaAtributoProducto03")
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto03 IS NULL THEN '' ELSE AP03.Descripcion END) AS DescripcionAtributo03")
         '---
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto04 IS NULL THEN 0  ELSE AP04.IdaAtributoProducto END) AS IdaAtributoProducto04")
         .AppendFormatLine(" , (CASE WHEN CP.IdaAtributoProducto04 IS NULL THEN '' ELSE AP04.Descripcion END) AS DescripcionAtributo04")
         '-------------------------------------------------------------------------

         .AppendLine(" FROM ComprasProductos CP")
         .AppendLine(" INNER JOIN Compras C ON C.IdSucursal = CP.IdSucursal")
         .AppendLine("			AND C.IdProveedor = CP.IdProveedor")
         .AppendLine("			AND C.IdTipoComprobante = CP.IdTipoComprobante")
         .AppendLine("			AND C.Letra = CP.Letra")
         .AppendLine("			AND C.CentroEmisor = CP.CentroEmisor")
         .AppendLine("			AND C.NumeroComprobante = CP.NumeroComprobante")
         .AppendLine(" INNER JOIN Proveedores PV ON C.IdProveedor = PV.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON C.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = CP.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         '-- REQ-40918.- ----------------------------------------------------------
         .AppendLine(" INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = CP.IdSucursal AND SD.IdDeposito = CP.IdDeposito")
         .AppendLine(" INNER JOIN SucursalesUbicaciones SU ON SU.IdSucursal = CP.IdSucursal AND SU.IdDeposito = CP.IdDeposito AND SU.IdUbicacion = CP.IdUbicacion")
         '-- REQ-35221.- ----------------------------------------------------------
         .AppendLine("  LEFT JOIN AtributosProductos AP01 ON AP01.IdaAtributoProducto = CP.IdaAtributoProducto01")
         .AppendLine("  LEFT JOIN AtributosProductos AP02 ON AP02.IdaAtributoProducto = CP.IdaAtributoProducto02")
         .AppendLine("  LEFT JOIN AtributosProductos AP03 ON AP03.IdaAtributoProducto = CP.IdaAtributoProducto03")
         .AppendLine("  LEFT JOIN AtributosProductos AP04 ON AP04.IdaAtributoProducto = CP.IdaAtributoProducto04")
         '-------------------------------------------------------------------------
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON C.IdFormasPago = VFP.IdFormasPago")
         .AppendLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = CP.IdCentroCosto ")
         '-.PE-31661.-
         .AppendLine("  LEFT JOIN CuentasBancarias CB ON C.IdCuentaBancaria = CB.IdCuentaBancaria")
         .AppendLine("  LEFT JOIN UnidadesDeMedidas UNS ON UNS.IdUnidadDeMedida = CP.IdUnidadDeMedida
                        LEFT JOIN UnidadesDeMedidas UNC ON UNC.IdUnidadDeMedida = CP.IdUnidadDeMedidaCompra")

         .AppendLine("  WHERE C.IdSucursal = " & idSucursal.ToString())

         NivelAutorizacionProveedorTipoComprobante(stb, "PV", "TC", nivelAutorizacion)

         If desde.HasValue And hasta.HasValue Then
            .AppendFormatLine("    AND C.Fecha >= '{0}'", ObtenerFecha(desde.Value, True))
            .AppendFormatLine("    AND C.Fecha <= '{0}'", ObtenerFecha(hasta.Value, True))
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND CP.idproducto = '" & idProducto & "'")
         End If

         If idMarca <> 0 Then
            .AppendLine("	AND P.IdMarca = " & idMarca.ToString())
         End If

         If IdComprador > 0 Then
            .AppendLine("	AND C.IdComprador = " & IdComprador)
         End If

         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subrubros, "P")
         GetListaSubSubRubrosMultiples(stb, subsubrubros, "P")

         If idProveedor <> 0 Then
            .AppendLine("	AND PV.IdProveedor = '" & idProveedor & "'")
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND C.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If idFormaDePago > 0 Then
            .AppendLine("	AND C.IdFormasPago = " & idFormaDePago.ToString())
         End If

         If Not String.IsNullOrEmpty(cantidad) Then
            .AppendLine("   AND CP.Cantidad " & cantidad)
         End If

         '-.PE-31886.-
         If periodoFiscalDesde <> 0 Then
            .AppendLine("    AND C.PeriodoFiscal >= '" & periodoFiscalDesde.ToString() & "'")
            .AppendLine("    AND C.PeriodoFiscal <= '" & periodoFiscalHasta.ToString() & "'")
         End If

         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         If orderBy = Entidades.ComprasProductos_GetDetallePorProductos_OrderBy.Default Then
            .AppendLine("	ORDER BY CONVERT(varchar(11), C.Fecha, 120)")
            .AppendLine("	,C.IdTipoComprobante")
            .AppendLine("	,C.Letra")
            .AppendLine("	,C.CentroEmisor")
            .AppendLine("	,C.NumeroComprobante")
            .AppendLine("	,P.NombreProducto")
            .AppendLine("	,CP.IdProducto")
         ElseIf orderBy = Entidades.ComprasProductos_GetDetallePorProductos_OrderBy.FechaDescendente Then
            .AppendLine("	ORDER BY C.Fecha DESC")
         End If
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetCostoPromedioPonderado(idSucursal As Integer, idProducto As String,
                                             desde As Date, hasta As Date, decimalesRedondeoEnPrecio As Integer) As Decimal
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CP.IdProducto")
         .AppendFormatLine("     , SUM(CP.ImporteTotalNeto)/SUM(CP.Cantidad) AS PPP")
         .AppendFormatLine("  FROM ComprasProductos CP")
         .AppendFormatLine(" INNER JOIN Compras C ON C.IdSucursal = CP.IdSucursal")
         .AppendFormatLine("			AND C.IdProveedor = CP.IdProveedor")
         .AppendFormatLine("			AND C.IdTipoComprobante = CP.IdTipoComprobante")
         .AppendFormatLine("			AND C.Letra = CP.Letra")
         .AppendFormatLine("			AND C.CentroEmisor = CP.CentroEmisor")
         .AppendFormatLine("			AND C.NumeroComprobante = CP.NumeroComprobante")
         .AppendFormatLine("  WHERE C.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("    AND CP.idproducto = '{0}'", idProducto)
         .AppendFormatLine("    AND C.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("    AND C.Fecha <= '{0}'", ObtenerFecha(hasta, True))
         .AppendFormatLine("  GROUP BY CP.IdProducto")
      End With

      'El PPP o costo promedio ponderado como la palabra lo dice es un promedio, es decir, 
      'si compraste 5 manzanas a 100, 8 manzanas a 120 y 10 a 200 el costo PPP seria
      '((5 * 100)+(8 * 120)+(10 * 200)) / (5+8+10)= 3460 / 23 = 150.4347
      Dim dt = GetDataTable(stb)
      If dt.Rows.Count > 0 Then
         Return Decimal.Round(dt.Rows(0).Field(Of Decimal)("PPP"), decimalesRedondeoEnPrecio)
      Else
         Return 0
      End If
   End Function

   Public Sub ComprasProductos_UDescripcion(IdProducto As String, NombreProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE ComprasProductos SET ")
         .AppendLine("  NombreProducto = '" & NombreProducto.ToString() & "'")
         .AppendLine("  FROM ComprasProductos CP ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CP.IdTipoComprobante")
         .AppendLine(" WHERE IdProducto = '" & IdProducto & "'")
         '.AppendLine("   AND (TC.EsElectronico = 'False' OR TC.EsPREElectronico = 'True' ) ")
         '.AppendLine("   AND TC.EsFiscal = 'False'")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ComprasProductos")

   End Sub


   Public Sub ModificarMontoAplicar(IdSucursal As Integer,
                                    IdTipoComprobante As String,
                                    Letra As String,
                                    CentroEmisor As Integer,
                                    NumeroComprobante As Long,
                                    idProveedor As Long,
                                    Orden As Long,
                                    IdConcepto As Integer,
                                    PasajeMovimiento As Boolean,
                                    MontoAplicado As Decimal,
                                    MontoSaldo As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE ComprasProductos").AppendLine()
         .AppendFormat("   SET PasajeMovimiento = {0}", GetStringFromBoolean(PasajeMovimiento)).AppendLine()
         .AppendFormat("     , MontoAplicado = {0}", MontoAplicado).AppendLine()
         .AppendFormat("     , MontoSaldo = {0}", MontoSaldo).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", IdSucursal).AppendLine()
         .AppendFormat(" AND IdTipoComprobante = '{0}'", IdTipoComprobante).AppendLine()
         .AppendFormat(" AND Letra = '{0}'", Letra).AppendLine()
         .AppendFormat(" AND CentroEmisor = {0}", CentroEmisor).AppendLine()
         .AppendFormat(" AND NumeroComprobante = {0}", NumeroComprobante).AppendLine()
         .AppendFormat(" AND idProveedor = {0}", idProveedor).AppendLine()
         .AppendFormat(" AND Orden = {0}", Orden).AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Public Function GetComprobantesOrdenControlCalidad(fechaHasta As Date?, fechaDesde As Date?, tiposComprobantes As Entidades.TipoComprobante(),
                                                      idProveedor As Long, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT PRV.IdProveedor")
         .AppendFormatLine("     , PRV.CodigoProveedor")
         .AppendFormatLine("     , PRV.NombreProveedor")
         .AppendFormatLine("     , PRO.IdProducto")
         .AppendFormatLine("     , PRO.NombreProducto")
         .AppendFormatLine("     , CP.IdLote")
         .AppendFormatLine("     , CP.Cantidad")
         .AppendFormatLine("     , SUD.IdDeposito")
         .AppendFormatLine("     , SUD.CodigoDeposito")
         .AppendFormatLine("     , SUD.NombreDeposito")
         .AppendFormatLine("     , SUU.IdUbicacion")
         .AppendFormatLine("     , SUU.CodigoUbicacion")
         .AppendFormatLine("     , SUU.NombreUbicacion")
         .AppendFormatLine("     , C.IdSucursal AS IdSucursalCompra")
         .AppendFormatLine("     , C.IdTipoComprobante AS IdTipoComprobanteCompra")
         .AppendFormatLine("     , TC.Descripcion AS DescripcionComprobanteCompra")
         .AppendFormatLine("     , C.Letra AS LetraCompra")
         .AppendFormatLine("     , C.CentroEmisor AS CentroEmisorCompra")
         .AppendFormatLine("     , C.NumeroComprobante AS NumeroComprobanteCompra")
         .AppendFormatLine("     , CP.Orden as OrdenComprobanteCompra")
         .AppendFormatLine("     , C.Fecha FechaCompra")
         .AppendFormatLine("     , C.Observacion ObservacionCompra")
         '-------------------------------------------------------------------------
         .AppendFormatLine("  FROM Compras C")
         .AppendFormatLine(" INNER JOIN ComprasProductos CP")
         .AppendFormatLine("         ON C.IdSucursal = CP.IdSucursal")
         .AppendFormatLine("        AND C.IdTipoComprobante = CP.IdTipoComprobante")
         .AppendFormatLine("        AND C.Letra = CP.Letra")
         .AppendFormatLine("        AND C.CentroEmisor = CP.CentroEmisor")
         .AppendFormatLine("        AND C.NumeroComprobante = CP.NumeroComprobante")
         .AppendFormatLine(" INNER JOIN Proveedores PRV ON CP.IdProveedor = PRV.IdProveedor")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Productos   PRO ON CP.IdProducto = PRO.IdProducto")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SUD")
         .AppendFormatLine("         ON CP.IdSucursal = SUD.IdSucursal")
         .AppendFormatLine("        AND CP.IdDeposito = SUD.IdDeposito")
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SUU")
         .AppendFormatLine("         ON CP.IdSucursal = SUU.IdSucursal")
         .AppendFormatLine("        AND CP.IdDeposito = SUU.IdDeposito")
         .AppendFormatLine("        AND CP.IdUbicacion = SUU.IdUbicacion")
         .AppendFormatLine("  LEFT JOIN MovimientosStock MS")
         .AppendFormatLine("         ON MS.IdSucursal = CP.IdSucursal")
         .AppendFormatLine("        AND MS.IdTipoComprobante = CP.IdTipoComprobante")
         .AppendFormatLine("        AND MS.Letra = CP.Letra")
         .AppendFormatLine("        AND MS.CentroEmisor = CP.CentroEmisor")
         .AppendFormatLine("        AND MS.NumeroComprobante = CP.NumeroComprobante")
         .AppendFormatLine("  LEFT JOIN MovimientosStockProductos  MSP")
         .AppendFormatLine("         ON MS.IdSucursal = MSP.IdSucursal")
         .AppendFormatLine("        AND MS.IdTipoMovimiento = MSP.IdTipoMovimiento")
         .AppendFormatLine("        AND MS.NumeroMovimiento = MSP.NumeroMovimiento")
         .AppendFormatLine("        AND CP.IdProducto = MSP.IdProducto")
         '-------------------------------------------------------------------------
         .AppendFormatLine(" WHERE CP.FechaActualizacionCalidad IS NULL AND MSP.NumeroMovimiento IS NOT NULL")
         .AppendFormatLine("   AND EXISTS (SELECT * FROM CalidadListasControlProductos CLCP WHERE CLCP.IdProducto = CP.IdProducto)")

         GetListaTiposComprobantesMultiples(stb, tiposComprobantes, "C")

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND C.Fecha >= '{0}'", ObtenerFecha(fechaDesde, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND C.Fecha <= '{0}'", ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND CP.IdProducto = '{0}'", idProducto)
         End If

         If idProveedor <> 0 Then
            .AppendFormatLine("   AND C.IdProveedor = {0}", idProveedor)
         End If
      End With

      Return GetDataTable(stb)
   End Function
   Public Sub ComprasProductos_UFechaActualizacionCalidad(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Integer?, numeroComprobante As Long?,
                                                          ordenComprobante As Integer?, idProducto As String,
                                                          fecha As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ComprasProductos")
         .AppendFormatLine("   SET FechaActualizacionCalidad = {0}", ObtenerFecha(fecha, True))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND Orden = {0}", ordenComprobante)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
      End With
      Execute(myQuery)
   End Sub
End Class
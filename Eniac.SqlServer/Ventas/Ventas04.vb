Partial Class Ventas

   ''GET PARA INVOCACIONES/ANULACIONES/EXPORTACIONES/ETC
   Public Function GetFacturables(idSucursal As Integer,
                                  fechaDesde As Date, fechaHasta As Date,
                                  tiposComprobantes As List(Of String), nroComprobante As Long,
                                  idCliente As Long,
                                  idLocalidad As Integer, idProvincia As String,
                                  fueInvocado As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CONVERT(BIT, 0) [Check]")
         .AppendFormatLine("     , V.*")
         .AppendFormatLine("     , V.NombreCliente NombreClienteGenerico")
         .AppendFormatLine("     , V.Letra LetraComprobante")
         .AppendFormatLine("     , TC.Descripcion TipoComprobanteDescripcion")
         .AppendFormatLine("     , P.NombreProvincia")
         .AppendFormatLine("     , L.NombreLocalidad")

         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendFormatLine(" INNER JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN Localidades L ON L.IdLocalidad = V.IdLocalidad")
         .AppendFormatLine("  LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO') ")
         .AppendFormatLine("   AND TC.EsFacturable = 'True'")

         If nroComprobante > 0 Then
            .AppendFormatLine("   AND V.NumeroComprobante = {0}", nroComprobante)
         End If

         If tiposComprobantes.Count > 0 Then
            GetListaMultiples(stb, tiposComprobantes, "V", "idTipoComprobante", [in]:=True)
         Else
            .AppendFormatLine("   AND TC.CoeficienteStock < 0 AND TC.EsFacturable = 'True' AND TC.AfectaCaja = 'False'")  '---Fuerzo Remitos
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If idLocalidad <> 0 Then
            .AppendFormatLine("   AND V.IdLocalidad = {0}", idLocalidad)
         End If
         If Not String.IsNullOrWhiteSpace(idProvincia) Then
            .AppendFormatLine("   AND L.IdProvincia = '{0}'", idProvincia)
         End If

         'If blnInvocarInvocador Then
         '   .AppendFormatLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
         'Else
         '   .AppendFormatLine("   AND V.IdEstadoComprobante IS NULL")
         'End If

         If fueInvocado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND {0} EXISTS (SELECT 1 FROM VentasInvocados VV", If(fueInvocado = Entidades.Publicos.SiNoTodos.SI, "", "NOT"))
            .AppendFormatLine("                    WHERE VV.IdSucursalInvocado = V.IdSucursal")
            .AppendFormatLine("                      AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
            .AppendFormatLine("                      AND VV.LetraInvocado = V.Letra")
            .AppendFormatLine("                      AND VV.CentroEmisorInvocado = V.CentroEmisor")
            .AppendFormatLine("                      AND VV.NumeroComprobanteInvocado = V.NumeroComprobante)")
         End If

         .AppendFormatLine("   AND V.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))

         .AppendFormatLine(" ORDER BY V.Fecha")    'Tiene la hora
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetDisponibilidadComprobanteInvocado(ByVal idSucursal As Integer, _
                                          ByVal idTipoComprobante As String, _
                                          ByVal letra As String, _
                                          ByVal centroEmisor As Integer, _
                                          ByVal numeroComprobante As Long) As Boolean
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT  COUNT(*) AS Disponible")
         .AppendLine("   FROM Ventas V")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante AND TC.EsFacturable = 1")

         .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND V.Letra = '" & letra & "'")
         .AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND V.NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
         Return True
      Else
         Return False
      End If
   End Function
   Public Function GetDisponibilidadPedidoInvocado(ByVal idSucursal As Integer, _
                                          ByVal idTipoComprobante As String, _
                                          ByVal letra As String, _
                                          ByVal centroEmisor As Integer, _
                                          ByVal numeroComprobante As Long,
                                          ByVal idEstadoComprobante As String,
                                          ByVal buscoConFactNulo As Boolean,
                                          ByVal buscoConRemitoNulo As Boolean) As Boolean

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT  COUNT(*) AS Disponible")
         .AppendLine("   FROM Pedidos P")
         .AppendLine("        INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine("        INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                   AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                   AND PP.Letra = P.Letra")
         .AppendLine("                   AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                   AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine("        INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                   AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                   AND PE.Letra = P.Letra")
         .AppendLine("                   AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                   AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                   AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                   AND PE.Orden = PP.Orden")

         .AppendFormat(" WHERE P.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND P.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendFormat("   AND P.Letra = '" & letra & "'")
         .AppendFormat("   AND P.CentroEmisor = " & centroEmisor.ToString())
         .AppendFormat("   AND P.NumeroPedido = " & numeroComprobante.ToString())

         If Not String.IsNullOrWhiteSpace(idEstadoComprobante) Then
            .AppendLine("   AND PE.IdEstado = '" & idEstadoComprobante & "' ")
         End If

         .AppendFormat("   AND PE.IdEstado <> '{0}'", Entidades.EstadoPedido.ESTADO_ANULADO).AppendLine()

         If buscoConFactNulo Then
            .AppendLine("   AND PE.NumeroComprobanteFact IS NULL")
         End If

         If buscoConRemitoNulo Then
            .AppendLine("   AND PE.NumeroComprobanteRemito IS NULL")
         End If

      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
         Return True
      Else
         Return False
      End If
   End Function
   Public Function GetDisponibilidadComprasInvocado(ByVal idSucursal As Integer, _
                                          ByVal idTipoComprobante As String, _
                                          ByVal letra As String, _
                                          ByVal centroEmisor As Integer, _
                                          ByVal numeroComprobante As Long) As Boolean

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT  COUNT(*) AS Disponible")
         .AppendLine("    FROM Compras C")
         .AppendLine("  INNER JOIN Proveedores P ON P.IdProveedor = C.IdProveedor ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante  AND TC.EsFacturable = 1")


         .AppendLine(" WHERE C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND C.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND C.IdTipoComprobanteVenta IS NULL")
         .AppendLine("   AND C.Letra = '" & letra & "'")
         .AppendLine("   AND C.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND C.NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND (C.IdEstadoComprobante IS NULL OR C.IdEstadoComprobante = 'INVOCO')")

      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
         Return True
      Else
         Return False
      End If
   End Function


   Public Function GetComprobantesACopiar(idSucursal As Integer, desde As Date, hasta As Date, idCliente As Long, tipoComprobante As String,
                                          numeroComprobante As Long, letraFiscal As String,
                                          centroEmisor As Integer, numeroReparto As Integer,
                                          idCaja As Integer?, usuario As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT S.Nombre NombreSucursal, TC.Descripcion,C.NombreCliente, V.* ")
         .AppendFormatLine(" FROM VENTAS V ")
         .AppendFormatLine(" LEFT JOIN Sucursales S ON S.IdSucursal = V.IdSucursal ")
         .AppendFormatLine(" LEFT JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante ")
         .AppendFormatLine(" LEFT JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine("  WHERE V.IdSucursal = {0} ", idSucursal)
         .AppendFormatLine("  AND V.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(desde, False), ObtenerFecha(hasta.Date.AddDays(1).AddSeconds(-1), True))
         .AppendFormatLine("	 AND V.IdTipoComprobante = '{0}'", tipoComprobante)
         .AppendFormatLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO') ")

         If Not String.IsNullOrWhiteSpace(letraFiscal) Then
            .AppendFormatLine("	 AND V.Letra = '{0}'", letraFiscal)
         End If

         If centroEmisor > 0 Then
            .AppendFormatLine("	 AND V.CentroEmisor = {0}", centroEmisor)
         End If

         If numeroComprobante > 0 Then
            .AppendFormatLine("	 AND V.NumeroComprobante = {0}", numeroComprobante)
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("	 AND C.IdCliente = {0}", idCliente)
         End If
         If numeroReparto > 0 Then
            .AppendFormatLine("	 AND V.NumeroReparto = {0}", numeroReparto)
         End If

         If idCaja.HasValue Then
            .AppendFormatLine("	 AND (V.IdCaja = {0} OR V.IdCaja IS NULL)", idCaja.Value)
         End If

         If Not String.IsNullOrWhiteSpace(usuario) Then
            .AppendFormatLine("	 AND V.Usuario = '{0}'", usuario)
         End If

         .AppendFormatLine(" ORDER BY V.Fecha DESC")

      End With
      Return Me.GetDataTable(stb.ToString())
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
                                       discIVA As Boolean,
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

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT V.Fecha ")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("  ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("	,V.IdCliente ")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("	,V.ImporteBruto ")
         .AppendLine("	,V.DescuentoRecargoPorc ")
         .AppendLine("	,V.DescuentoRecargo ")

         'RI
         If discIVA Then
            .AppendLine("	,V.SubTotal ")
            .AppendLine("	,V.TotalImpuestos ")
            .AppendLine("  ,V.TotalImpuestoInterno")
         Else
            'Monotributo
            .AppendLine("	,ImporteTotal AS SubTotal ")
            .AppendLine("	,0 AS TotalImpuestos ")
            .AppendLine("  ,0 AS TotalImpuestoInterno")
         End If

         .AppendLine("	,V.ImporteTotal ")
         .AppendLine("	,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal ")
         .AppendLine("   ,I.IdImpresora")
         .AppendLine("   ,I.TipoImpresora")
         .AppendLine("   ,V.IdEstadoComprobante")
         .AppendLine("   ,V.Kilos")
         .AppendLine("   ,C.Cuit")
         .AppendLine("   ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("   ,V.IdFormasPago")
         .AppendLine("   ,V.ImportePesos")
         .AppendLine("   ,V.ImporteTickets")
         .AppendLine("   ,V.ImporteTarjetas")
         .AppendLine("   ,V.ImporteCheques")
         .AppendLine("   ,V.CantidadInvocados")
         .AppendLine("   ,V.CantidadLotes")
         .AppendLine("   ,V.Usuario")
         .AppendLine("   ,V.FechaAlta")
         .AppendLine("   ,V.CAE")
         .AppendLine("   ,V.CAEVencimiento")
         .AppendLine("   ,V.Observacion")

         .AppendLine("   ,V.SubTotal-V.Utilidad AS Costo")
         .AppendLine("   ,V.Utilidad")
         .AppendLine("   ,V.FechaTransmisionAFIP")

         .AppendLine("   ,TC.EsElectronico")
         .AppendLine("   ,V.FechaImpresion")
         .AppendLine("  ,V.NumeroReparto")
         .AppendLine("	FROM Ventas V")

         .AppendLine("	 LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("	 LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor AND V.IdSucursal = I.IdSucursal")
         .AppendLine("	 LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("	 LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("	 LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")

         .AppendLine("  WHERE V.IdSucursal= " & idSucursal.ToString())

         .AppendLine(" AND V.Fecha BETWEEN '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "' AND '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         Select Case impreso
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendLine("	AND V.FechaImpresion IS NOT NULL")
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendLine("	AND V.FechaImpresion IS NULL")
            Case Else
         End Select

         If idCliente > 0 Then
            .AppendLine("	 AND C.IdCliente = " & idCliente.ToString())
         End If

         Dim aliasCategoria As String = If(origenCategorias = Entidades.OrigenFK.Actual, "C", "V")
         GetListaCategoriasMultiples(stb, categorias, aliasCategoria)

         If Not String.IsNullOrEmpty(idEstadoComprobante) Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If idEstadoComprobante = "PENDIENTE" Then
               .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
            ElseIf idEstadoComprobante = "NO ANULADO" Then
               .AppendLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendLine("   AND V.IdEstadoComprobante = '" & idEstadoComprobante & "'")
            End If

         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(letra) Then
            .AppendLine("  AND V.Letra = '" & letra & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("  AND V.CentroEmisor = " & centroEmisor.ToString())
         End If

         If nroDesde > 0 Then
            .AppendLine("	  AND V.NumeroComprobante >= " & nroDesde.ToString())
         End If

         If nroHasta > 0 Then
            .AppendLine("	  AND V.NumeroComprobante <= " & nroHasta.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If IdVendedor > 0 Then
            .AppendLine("	 AND V.IdVendedor = " & IdVendedor)
         End If

         If idFormasPago > 0 Then
            .AppendLine("	 AND V.IdFormasPago = " & idFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & idUsuario & "'")
         End If
         If nroRepartoInvocacionMasiva > 0 Then
            .AppendLine("	 AND V.NroRepartoInvocacionMasiva = " & nroRepartoInvocacionMasiva.ToString())
         Else

            If numeroReparto > 0 Then
               .AppendLine("   AND V.NumeroReparto >= " & numeroReparto.ToString())
            End If

            If numeroRepartoHasta > 0 Then
               .AppendLine("	 AND V.NumeroReparto <= " & numeroRepartoHasta.ToString())
            End If
         End If

         If exportado = "SI" Then
            .AppendLine("      AND V.FechaExportacion IS NOT NULL")
         ElseIf exportado = "NO" Then
            .AppendLine("      AND V.FechaExportacion IS NULL")
         End If

         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.AppendLine("	,V.IdTipoComprobante")
         '.AppendLine("	,V.Letra")
         '.AppendLine("	,V.CentroEmisor")
         '.AppendLine("	,V.NumeroComprobante")

         '.Append("	ORDER BY V.fecha ")

         'Si Filtro por algun tipo de comprobantes.
         If Not String.IsNullOrEmpty(idTipoComprobante) Or Not String.IsNullOrEmpty(letra) Or centroEmisor > 0 Or nroDesde > 0 Or nroHasta > 0 Then
            .Append("	ORDER BY V.CentroEmisor, V.Letra, V.NumeroComprobante ")
         Else
            .Append("	ORDER BY V.fecha ")
         End If
         .AppendLine(orden)   'Asc o Desc
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetExportacionVentasHolistor(sucursales As Entidades.Sucursal(),
                                                desde As Date,
                                                hasta As Date,
                                                idVendedor As Integer,
                                                grabaLibro As String,
                                                idCliente As Long,
                                                afectaCaja As String,
                                                idTipoComprobante As String,
                                                utilizaSubRubros As Boolean) As DataTable

      '# Seteo a qué tabla hay que hacer el join para buscar la información
      '# Es de jerarquía inversa, así que primero se debe buscar en subrubros, en caso de que no utilice, a rubros
      Dim letra, tabla, id As String
      If utilizaSubRubros Then
         tabla = "SubRubros"
         letra = "SR"
         id = "IdSubRubro"
      Else
         tabla = "Rubros"
         letra = "R"
         id = "IdRubro"
      End If

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT   C.CodigoCliente ")
         .AppendFormatLine("         ,V.NombreCliente ")
         .AppendFormatLine("         ,V.IdSucursal")
         .AppendFormatLine("         ,V.IdTipoComprobante ")
         .AppendFormatLine("         ,ATCTC.IdAFIPTipoComprobante")
         .AppendFormatLine("         ,TC.DescripcionAbrev ")
         .AppendFormatLine("         ,TC.CoeficienteValores ")
         .AppendFormatLine("         ,V.Letra ")
         .AppendFormatLine("         ,V.CentroEmisor ")
         .AppendFormatLine("         ,0 As CentroEmisorPedido ")
         .AppendFormatLine("         ,0 AS NumeroPedido")
         .AppendFormatLine("         ,V.NumeroComprobante ")
         .AppendFormatLine("         ,V.Fecha ")
         .AppendFormatLine("         ,V.IdEstadoComprobante ")
         .AppendFormatLine("         ,V.ImporteTotal ")
         .AppendFormatLine("         ,V.SubTotal")
         .AppendFormatLine("		    ,VI.Alicuota")
         .AppendFormatLine("		    ,X.CodigoExportacion")
         .AppendFormatLine("		    ,X.TotalImpuestos ")
         .AppendFormatLine("         ,V.TotalImpuestoInterno ")
         .AppendFormatLine("         ,TC1.TipoComprobantePDA ")
         .AppendFormatLine("         ,V.Cuit")
         .AppendFormatLine("         ,V.TipoDocCliente")
         .AppendFormatLine("         ,V.NroDocCliente")
         .AppendFormatLine("         ,V.Direccion")
         .AppendFormatLine("         ,V.IdLocalidad AS CP")
         .AppendFormatLine("         ,L.NombreLocalidad")
         .AppendFormatLine("         ,P.IdAFIPProvincia")
         .AppendFormatLine("         ,P.NombreProvincia")
         .AppendFormatLine("         ,V.IdCategoriaFiscal")
         .AppendFormatLine("         ,X.Precio Neto")
         .AppendFormatLine("         ,ATD.IdAFIPTipoDocumento")
         .AppendFormatLine("         ,PI.IdProvincia IdProvinciaImpuesto")
         .AppendFormatLine("         ,CASE WHEN TI.Tipo='PERCEPCION' THEN  VI.Importe ELSE 0 END AS ImportePorPercepcion")
         .AppendFormatLine("         ,CASE WHEN TI.Tipo='PERCEPCION' THEN  VI.Total + VI.Importe ELSE X.Precio + X.TotalImpuestos END AS TOTAL")
         .AppendFormatLine("         ,CASE WHEN TI.Tipo='PERCEPCION' THEN VI.IdTipoImpuesto ELSE '' END AS IdTipoImpuesto")
         .AppendFormatLine("         ,CF.CodigoExportacion CodigoExportacion_CF")
         .AppendFormatLine("  FROM Ventas V ")
         .AppendFormatLine("  LEFT JOIN VentasImpuestos VI ON V.IdSucursal = VI.IdSucursal AND V.IdTipoComprobante = VI.IdTipoComprobante ")
         .AppendFormatLine("                             AND V.Letra = VI.Letra AND V.CentroEmisor = VI.CentroEmisor AND V.NumeroComprobante = VI.NumeroComprobante")
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendFormatLine("  LEFT JOIN TiposComprobantesPDA TC1 ON TC1.IdTipoComprobante = V.IdTipoComprobante AND TC1.Letra = V.Letra")
         .AppendFormatLine("  LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON V.IdTipoComprobante = ATCTC.IdTipoComprobante AND V.Letra = ATCTC.Letra")
         .AppendFormatLine("  LEFT JOIN AFIPTiposComprobantes ATC ON ATC.IdAFIPTipoComprobante = ATCTC.IdAFIPTipoComprobante")
         .AppendFormatLine("  LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = CASE WHEN C.EsClienteGenerico = 'True' THEN V.TipoDocCliente ELSE C.TipoDocCliente END")
         .AppendFormatLine("  LEFT JOIN Provincias PI ON VI.IdProvincia = PI.IdProvincia")
         .AppendFormatLine("  INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendFormatLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendFormatLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendFormatLine("  INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
         .AppendFormatLine("  INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .AppendFormatLine("")

         '# Obtengo el importe impuesto agrupado por Alícuota + Cód. Exportación
         .AppendFormatLine("  LEFT JOIN (SELECT VP.Precio,VP.AlicuotaImpuesto,VP.IdSucursal, VP.IdTipoComprobante, VP.Letra, VP.CentroEmisor,VP.NumeroComprobante,{0}.CodigoExportacion,SUM(ImporteImpuesto) TotalImpuestos  FROM VentasProductos VP", letra)
         .AppendFormatLine("			 INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")
         .AppendFormatLine("			 LEFT JOIN {0} {1} ON P.{2} = {1}.{2}", tabla, letra, id)
         .AppendFormatLine("			 GROUP BY VP.AlicuotaImpuesto,{0}.CodigoExportacion,VP.IdSucursal, VP.IdTipoComprobante, VP.Letra, VP.CentroEmisor,VP.NumeroComprobante,VP.Precio) X ON ", letra)
         .AppendFormatLine("												   X.IdSucursal = V.IdSucursal")
         .AppendFormatLine("												   AND X.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("												   AND X.Letra = V.Letra")
         .AppendFormatLine("												   AND X.CentroEmisor = V.CentroEmisor")
         .AppendFormatLine("												   AND X.NumeroComprobante = V.NumeroComprobante ")
         .AppendFormatLine("												   AND X.AlicuotaImpuesto = VI.Alicuota")
         .AppendFormatLine(" WHERE 1=1")

         GetListaSucursalesMultiples(query, sucursales, "V")

         .AppendFormatLine("	  AND V.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("	  AND V.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If idVendedor > 0 Then
            .AppendLine("	 AND V.IdVendedor = " & idVendedor)
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

         .AppendLine(" GROUP BY ")
         .AppendLine("        C.CodigoCliente ")
         .AppendLine("       ,V.NombreCliente ")
         .AppendLine("       ,V.IdSucursal ")
         .AppendLine("       ,V.IdTipoComprobante ")
         .AppendLine("       ,ATCTC.IdAFIPTipoComprobante")
         .AppendLine("       ,TC.DescripcionAbrev ")
         .AppendLine("       ,TC.CoeficienteValores ")
         .AppendLine("       ,V.Letra ")
         .AppendLine("       ,V.CentroEmisor ")
         .AppendLine("       ,V.NumeroComprobante ")
         .AppendLine("       ,V.Fecha ")
         .AppendLine("       ,V.IdEstadoComprobante ")
         .AppendLine("       ,V.ImporteTotal ")
         .AppendLine("       ,V.SubTotal ")
         .AppendLine("       ,V.TotalImpuestoInterno ")
         .AppendLine("       ,TC1.TipoComprobantePDA ")

         .AppendLine("       ,V.Cuit ")
         .AppendLine("       ,V.TipoDocCliente ")
         .AppendLine("       ,V.NroDocCliente ")
         .AppendLine("       ,V.Direccion ")
         .AppendLine("       ,V.IdLocalidad ")
         .AppendLine("       ,L.NombreLocalidad ")
         .AppendLine("       ,P.NombreProvincia ")
         .AppendLine("       ,V.IdCategoriaFiscal ")
         .AppendLine("       ,CF.CodigoExportacion")

         .AppendLine("       ,VI.Alicuota ")
         .AppendLine("       ,VI.Neto ")
         .AppendLine("       ,ATD.IdAFIPTipoDocumento ")
         .AppendLine("       ,PI.IdProvincia ")
         .AppendLine("       ,P.IdAFIPProvincia")
         .AppendLine("       ,TI.Tipo ")
         .AppendLine("       ,VI.Importe ")
         .AppendLine("       ,VI.Total ")
         .AppendLine("       ,VI.IdTipoImpuesto")
         .AppendFormatLine("	   ,X.TotalImpuestos")
         .AppendFormatLine("	   ,X.CodigoExportacion")
         .AppendFormatLine("     ,X.Precio")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   '-- REQ-34676.- ------------
   Public Function GetInvocacionMasivaPedidos(idEstado As String,
                                              nroOrdenCompra As Long,
                                              idCliente As Long,
                                              idTransportista As Long,
                                              fechaDesde As Date?,
                                              fechaHasta As Date?) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	CONVERT(BIT, 0) AS Proceso,")
         .AppendFormatLine("	'' AS Accion,")
         .AppendFormatLine("	PED.*,")
         .AppendFormatLine("	CLI.NombreCliente,")
         .AppendFormatLine("	CLI.IdCategoriaFiscal,")
         .AppendFormatLine("	CTF.NombreCategoriaFiscal,")
         .AppendFormatLine("	TRA.NombreTransportista,")
         .AppendFormatLine("	'' AS Mensaje")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("		SELECT")
         .AppendFormatLine("			PED.IdSucursal,")
         .AppendFormatLine("			PED.IdTipoComprobante,")
         .AppendFormatLine("			PED.Letra,")
         .AppendFormatLine("			PED.CentroEmisor,")
         .AppendFormatLine("			PED.NumeroPedido,")
         .AppendFormatLine("			PED.FechaPedido  AS FechaPedido,")
         .AppendFormatLine("			SUM(PEP.ImporteTotalNeto / PEP.Cantidad * PEE.CantEstado) as ImporteNeto,")
         .AppendFormatLine("			MAX(PEE.FechaEstado) AS FechaEstado,")
         .AppendFormatLine("			PED.IdCliente,")
         .AppendFormatLine("			PED.NumeroOrdenCompra,")
         .AppendFormatLine("			PED.IdTransportista,")
         .AppendFormatLine("			PED.IdTipoComprobanteFact")
         .AppendFormatLine("		FROM Pedidos PED")
         .AppendFormatLine("			INNER JOIN PedidosProductos PEP")
         .AppendFormatLine("				 ON PED.IdSucursal = PEP.IdSucursal")
         .AppendFormatLine("				AND PED.NumeroPedido = PEP.NumeroPedido")
         .AppendFormatLine("			INNER JOIN PedidosEstados PEE")
         .AppendFormatLine("				 ON PEP.IdSucursal = PEE.IdSucursal")
         .AppendFormatLine("				AND PEP.NumeroPedido = PEE.NumeroPedido")
         .AppendFormatLine("				AND PEP.IdProducto = PEE.IdProducto")
         .AppendFormatLine("		WHERE 1 = 1")
         '-------------------------------------------------------------------------------------------------
         .AppendFormatLine("		    AND PEE.IdEstado = '{0}'", idEstado)
         If nroOrdenCompra > 0 Then
            .AppendFormatLine("         AND PED.NumeroOrdenCompra = {0}", nroOrdenCompra)
         End If
         If idCliente > 0 Then
            .AppendFormatLine("			 AND PED.idCliente = {0}", idCliente)
         End If
         If idTransportista > 0 Then
            .AppendFormatLine("         AND PED.IdTransportista = {0}", idTransportista)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("	    AND PED.FechaPedido >= {0}", ObtenerFecha(fechaDesde, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("	    AND PED.FechaPedido <= {0}", ObtenerFecha(fechaHasta, True))
         End If
         '-------------------------------------------------------------------------------------------------
         .AppendFormatLine("		GROUP BY PED.IdSucursal, PED.IdTipoComprobante, PED.Letra, PED.CentroEmisor,PED.NumeroPedido,")
         .AppendFormatLine("				   PED.IdCliente, PED.NumeroOrdenCompra, PED.FechaPedido,PED.IdTransportista,")
         .AppendFormatLine("				   PED.IdTipoComprobanteFact")
         .AppendFormatLine("	   ) PED")
         .AppendFormatLine("	INNER JOIN Clientes CLI")
         .AppendFormatLine("		 ON PED.IdCliente = CLI.IdCliente")
         .AppendFormatLine("	INNER JOIN CategoriasFiscales CTF")
         .AppendFormatLine("		 ON CLI.IdCategoriaFiscal = CTF.IdCategoriaFiscal")
         .AppendFormatLine("	LEFT JOIN Transportistas TRA")
         .AppendFormatLine("		 ON PED.Idtransportista = TRA.IdTransportista")
         .AppendFormatLine("ORDER BY PED.NumeroPedido, PED.IdCliente")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
   '-- REQ-34676.- ------------
   Public Function GetInvocacionMasivaComprobantes(idSucursal As Integer,
                                                   idCliente As Long,
                                                   idTransportista As Long,
                                                   nroOrdenCompra As Long,
                                                   nroReparto As Integer,
                                                   nroFacturaProveedor As String,
                                                   nroRemitoProveedor As String,
                                                   fechaDesde As Date?, fechaHasta As Date?) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	CONVERT(BIT, 0) AS Proceso")
         .AppendFormatLine("	   , '' AS Accion")
         '-------------------------------------------------------------------------------------------------
         .AppendFormatLine("     , V.IdSucursal")
         .AppendFormatLine("     , V.IdTipoComprobante")
         .AppendFormatLine("     , V.Letra")
         .AppendFormatLine("     , V.CentroEmisor")
         .AppendFormatLine("     , V.NumeroComprobante")
         .AppendFormatLine("     , V.Fecha")
         '-------------------------------------------------------------------------------------------------
         .AppendFormatLine("     , ISNULL(V.IdTipoComprobanteInvocacionMasiva, C.IdTipoComprobanteInvocacionMasiva ) as IdTipoComprobanteFact")
         '-------------------------------------------------------------------------------------------------
         .AppendFormatLine("     , V.IdCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.Cuit")
         .AppendFormatLine("	   , C.IdCategoriaFiscal")
         .AppendFormatLine("	   , CTF.NombreCategoriaFiscal")
         .AppendFormatLine("     , V.SubTotal")
         .AppendFormatLine("     , V.TotalImpuestos")
         .AppendFormatLine("     , V.ImporteTotal")
         .AppendFormatLine("     , T.IdTransportista")
         .AppendFormatLine("     , T.NombreTransportista")
         .AppendFormatLine("     , V.NumeroOrdenCompra")
         .AppendFormatLine("     , V.NumeroReparto")
         .AppendFormatLine("     , V.NroFacturaProveedor")
         .AppendFormatLine("     , V.NroRemitoProveedor")
         '-------------------------------------------------------------------------------------------------
         .AppendFormatLine("	   ,'' AS Mensaje")
         .AppendFormatLine("  FROM Clientes C")
         .AppendFormatLine("     INNER JOIN Ventas V ON V.IdCliente = C.IdCliente")
         .AppendFormatLine("     INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("     INNER JOIN CategoriasFiscales CTF ON CTF.IdCategoriaFiscal = V.IdCategoriaFiscal")
         .AppendFormatLine("     LEFT OUTER JOIN Transportistas T ON T.IdTransportista = V.IdTransportista")
         '-------------------------------------------------------------------------------------------------
         .AppendFormatLine(" WHERE TC.EsFacturable = 'True' AND TC.AfectaCaja = 'False'")
         .AppendFormatLine("   AND V.IdSucursal = {0}", idSucursal)
         '-------------------------------------------------------------------------------------------------
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND V.fecha >= {0}", ObtenerFecha(fechaDesde, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND V.fecha <= {0}", ObtenerFecha(fechaHasta, True))
         End If
         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If
         If nroOrdenCompra > 0 Then
            .AppendFormatLine("         AND V.NumeroOrdenCompra = {0}", nroOrdenCompra)
         End If
         If nroReparto > 0 Then
            .AppendFormatLine("         AND V.NumeroReparto = {0}", nroReparto)
         End If
         '-------------------------------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(nroFacturaProveedor) Then
            .AppendFormatLine("         AND V.NroFacturaProveedor = '{0}'", nroFacturaProveedor)
         End If
         If Not String.IsNullOrEmpty(nroRemitoProveedor) Then
            .AppendFormatLine("         AND V.NroRemitoProveedor = '{0}'", nroRemitoProveedor)
         End If
         '-------------------------------------------------------------------------------------------------
         If idTransportista > 0 Then
            .AppendFormatLine("         AND V.IdTransportista = {0}", idTransportista)
         End If

         .AppendFormatLine("   AND NOT EXISTS (SELECT 1 FROM VentasInvocados VV")
         .AppendFormatLine("                           WHERE VV.IdSucursalInvocado = V.IdSucursal")
         .AppendFormatLine("                             AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
         .AppendFormatLine("                             AND VV.LetraInvocado = V.Letra")
         .AppendFormatLine("                             AND VV.CentroEmisorInvocado = V.CentroEmisor")
         .AppendFormatLine("                             AND VV.NumeroComprobanteInvocado = V.NumeroComprobante)")
         .AppendFormatLine("   AND ( V.IdEstadoComprobante is null or V.IdEstadoComprobante <> 'ANULADO')")

         '-------------------------------------------------------------------------------------------------

         .AppendLine("  ORDER BY V.Fecha")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub Cambia_TipoCompFact(idSucursal As Integer,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Integer,
                                  numeroComprobante As Long,
                                  idTipoComprobanteFact As String)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE Ventas ").AppendLine()
         .AppendFormat("   SET IdTipoComprobanteInvocacionMasiva = '{0}'", idTipoComprobanteFact).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroComprobante = {0}", numeroComprobante).AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Public Function GetParaEliminar(idSucursal As Integer, desde As Date, hasta As Date,
                                   idCliente As Long, idTipoComprobante As String, orden As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CONVERT(BIT, 0) Selec")
         .AppendFormatLine("     , V.Fecha")
         .AppendFormatLine("     , V.IdTipoComprobante")
         .AppendFormatLine("     , TC.DescripcionAbrev")
         .AppendFormatLine("     , V.Letra")
         .AppendFormatLine("     , V.CentroEmisor")
         .AppendFormatLine("     , V.NumeroComprobante")
         .AppendFormatLine("     , V.IdVendedor")
         .AppendFormatLine("     , V.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , V.ImporteBruto")
         .AppendFormatLine("     , V.DescuentoRecargoPorc")
         .AppendFormatLine("     , V.DescuentoRecargo")
         .AppendFormatLine("     , V.SubTotal")
         .AppendFormatLine("     , V.TotalImpuestos")
         .AppendFormatLine("     , V.TotalImpuestoInterno")
         .AppendFormatLine("     , V.ImporteTotal")
         .AppendFormatLine("     , CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal")
         .AppendFormatLine("     , I.IdImpresora")
         .AppendFormatLine("     , I.TipoImpresora")
         .AppendFormatLine("     , V.IdEstadoComprobante")
         .AppendFormatLine("     , V.Kilos")
         .AppendFormatLine("     , C.Cuit")
         .AppendFormatLine("     , VFP.DescripcionFormasPago as FormaDePago")
         .AppendFormatLine("     , V.IdFormasPago")
         .AppendFormatLine("     , V.ImportePesos")
         .AppendFormatLine("     , V.ImporteTickets")
         .AppendFormatLine("     , V.ImporteTarjetas")
         .AppendFormatLine("     , V.ImporteCheques")
         .AppendFormatLine("     , V.CantidadInvocados")
         .AppendFormatLine("     , V.CantidadLotes")
         .AppendFormatLine("     , V.Usuario")
         .AppendFormatLine("     , V.FechaAlta")

         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN VentasFormasPago VFP ON VFP.IdFormasPago = V.IdFormasPago")
         .AppendFormatLine(" INNER JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND V.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("   AND V.Fecha <= '{0}'", ObtenerFecha(hasta, True))


         '' '' '.AppendLine("      AND ( (TC.PuedeSerBorrado = 'True' AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante<>'FACTURADO')) ")
         '' '' '.AppendLine("                                              OR IdEstadoComprobante='ANULADO' )")

         '' '' 'Primero.. debe poder borrarse (aunque en el futuro se podria quitar
         '' '' 'Segundo... 1. tiene que ser inecte (PRESUP) y no ser invocado
         '' '' '           2. Si afecta Stock tiene que estar Anulado.

         '' '' '.AppendLine("    AND ( (TC.PuedeSerBorrado = 'True' ")
         '' '' '.AppendLine("         AND ((TC.CoeficienteStock = 0 AND TC.EsPreElectronico = 'False' AND IdEstadoComprobante IS NULL OR IdEstadoComprobante<>'FACTURADO')) ")
         '' '' '.AppendLine("              OR (TC.CoeficienteStock <> 0 AND IdEstadoComprobante='ANULADO' )) )")

         ''Se discute con Augusto y se decide simplificar la condición:
         ''  El proceso de Anulación realiza operaciones que la Eliminación no hace y podemos dejar agujeros abiertos innecesariamente
         .AppendFormatLine("   AND TC.PuedeSerBorrado = 'True' ")
         .AppendFormatLine("   AND V.IdEstadoComprobante='ANULADO'")

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         ''Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")

         .AppendLine(" ORDER BY V.Fecha " + orden)

      End With

      Return GetDataTable(stb)
   End Function
   '---------------------------

End Class
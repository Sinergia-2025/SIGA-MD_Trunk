Partial Class Ventas

   'Viene de SILIVE

   Public Sub ActualizarNumeroReparto(ByVal filtro As String, ByVal NumeroReparto As Integer?, idTransportista As Integer?, fechaReparto As DateTime?, MercDespachada As Boolean?, esReenvio As Boolean)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE Ventas SET ")
         If NumeroReparto.HasValue Then
            .AppendFormat("      NumeroReparto = {0}", NumeroReparto.Value)
         Else
            .AppendFormat("      NumeroReparto = NULL")
         End If

         If esReenvio Then
            .AppendFormat("    ,  Observacion = LEFT(Observacion + ' *Reenvio* - Nro Reparto Anterior: ' + CONVERT(varchar, NumeroReparto), 100)")
         End If

         If MercDespachada.HasValue Then
            .AppendFormat("    ,  MercDespachada = {0}", GetStringFromBoolean(MercDespachada.Value))
         End If

         If idTransportista.HasValue Then
            .AppendFormat("    ,  IdTransportista = {0}", idTransportista.Value)
         Else
            .AppendFormat("    ,  IdTransportista = NULL")
         End If

         If fechaReparto.HasValue Then
            .AppendFormat("    ,  FechaEnvio = '{0}'", ObtenerFecha(fechaReparto.Value, True))
         Else
            .AppendFormat("    ,  FechaEnvio = NULL")
         End If

         .Append(" WHERE ")
         .Append(filtro)

         '.AppendFormat("      IdSucursal = {0}", IdSucursal)
         '.AppendFormat("      and IdTipoComprobante = '{0}'", IdTipoComprobante)
         '.AppendFormat("      and Letra = '{0}'", Letra)
         '.AppendFormat("      and CentroEmisor = {0}", CentroEmisor)
         '.AppendFormat("      and NumeroComprobante = {0}", NumeroComprobante)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "Ventas")
   End Sub

   Public Sub actualizarFRendicion(filtro As String, fecha As DateTime)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE Ventas SET ")
         .AppendFormat("      fechaRendicion = '{0}'", Me.ObtenerFecha(fecha, True))
         .Append(" WHERE ")
         .Append(filtro)

         '.AppendFormat("      IdSucursal = {0}", IdSucursal)
         '.AppendFormat("      and IdTipoComprobante = '{0}'", IdTipoComprobante)
         '.AppendFormat("      and Letra = '{0}'", Letra)
         '.AppendFormat("      and CentroEmisor = {0}", CentroEmisor)
         '.AppendFormat("      and NumeroComprobante = {0}", NumeroComprobante)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "Ventas")
   End Sub
   Public Sub ActualizoEstadoFactura(ByVal filtro As String, ByVal estado As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE Ventas SET ")
         .AppendFormat("      idEstadoComprobante = '{0}'", estado)

         .Append(" WHERE ")
         .Append(filtro)


         '.AppendFormat("      and IdTipoComprobanteFact = '{0}'", IdTipoComprobante)
         '.AppendFormat("      and LetraFact = '{0}'", Letra)
         '.AppendFormat("      and CentroEmisorFact = {0}", CentroEmisor)
         '.AppendFormat("      and NumeroComprobanteFact = {0}", NumeroComprobante)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "Ventas")
   End Sub

   'Public Sub Ventas_Pedidos_TipoCompFact(ByVal idSucursal As Integer, _
   '                             ByVal idTipoComprobante As String, _
   '                             ByVal letra As String, _
   '                             ByVal centroEmisor As Integer, _
   '                             ByVal numeroComprobante As Long, _
   '                             ByVal TipoCompFact As Eniac.Entidades.TipoComprobante)
   '   Ventas_Pedidos_TipoCompFact(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, TipoCompFact.IdTipoComprobante)
   'End Sub

   'Public Sub Ventas_Pedidos_TipoCompFact(ByVal idSucursal As Integer, _
   '                             ByVal idTipoComprobante As String, _
   '                             ByVal letra As String, _
   '                             ByVal centroEmisor As Integer, _
   '                             ByVal numeroComprobante As Long, _
   '                             ByVal IdTipoComprobanteFact As String)

   '   Dim myQuery As StringBuilder = New StringBuilder("")

   '   With myQuery
   '      .Length = 0
   '      .AppendLine("UPDATE Ventas SET ")
   '      .AppendLine("  IdTipoComprobanteFact = '" & IdTipoComprobanteFact & "'")
   '      .AppendLine("  ,LetraFact = NULL") '' & TipoCompFact.LetrasHabilitadas & "'")
   '      .AppendLine(" , CentroEmisorFact = " & 0)
   '      .AppendLine(" , NumeroComprobanteFact = " & 0)

   '      .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
   '      .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
   '      .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
   '      .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
   '      .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
   '   End With

   '   Me.Execute(myQuery.ToString())
   '   Me.Sincroniza_I(myQuery.ToString(), "Ventas")
   'End Sub

   Public Sub Ventas_Pedidos_FormaPago(idSucursal As Integer, _
                                       idTipoComprobante As String, _
                                       letra As String, _
                                       centroEmisor As Integer, _
                                       numeroComprobante As Long, _
                                       idfpago As Integer, _
                                       fechaRendicion As DateTime?,
                                       cambiaFormaPago As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("  idformaspago = " & idfpago & "")
         If fechaRendicion.HasValue Then
            .AppendLine(" ,fechaRendicion = '" & ObtenerFecha(fechaRendicion.Value, False) & "'")
         End If
         If cambiaFormaPago Then
            .AppendLine(" ,NumeroMovimiento = Null")
            .AppendLine(" ,importePesos = 0")
            .AppendLine(" ,ImporteTarjetas = 0")
            .AppendLine(" ,ImporteCheques = 0")
            .AppendLine(" ,ImporteTickets = 0")
            .AppendLine(" ,IdCuentaBancaria = Null")
            .AppendLine(" ,ImporteTransfBancaria = 0")
            .AppendLine(" ,FechaTransferencia = Null")
         End If
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
         .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")
   End Sub
   Public Sub Ventas_Pedidos_FechaRendicion(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroComprobante As Long,
                                            fechaRendicion As DateTime)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Ventas ")
         .AppendFormatLine("   SET fechaRendicion = '{0}'", ObtenerFecha(fechaRendicion, False))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")
   End Sub
   Public Sub Ventas_Pedidos_RespDist(ByVal idSucursal As Integer, _
                                 ByVal idTipoComprobante As String, _
                                 ByVal letra As String, _
                                 ByVal centroEmisor As Integer, _
                                 ByVal numeroComprobante As Long, _
                                 ByVal idTransportista As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("  IdTransportista = " & idTransportista & "")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
         .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub Ventas_Pedidos_FechaEnvio(ByVal idSucursal As Integer, _
                                ByVal idTipoComprobante As String, _
                                ByVal letra As String, _
                                ByVal centroEmisor As Integer, _
                                ByVal numeroComprobante As Long, _
                                ByVal fechaEnvio As Date)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("  FechaEnvio = '" & fechaEnvio.ToString("yyyyMMdd HH:mm:ss") & "'")

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
         .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub Ventas_Pedidos_FechaEnvio_respDist(ByVal idSucursal As Integer, _
                                ByVal idTipoComprobante As String, _
                                ByVal letra As String, _
                                ByVal centroEmisor As Integer, _
                                ByVal numeroComprobante As Long, _
                                ByVal fechaEnvio As Date, _
                                 ByVal idTransportista As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("  FechaEnvio = '" & fechaEnvio.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("  ,IdTransportista = " & idTransportista & "")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
         .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")
   End Sub

   Public Sub ModificarObs(ByVal idSucursal As Integer, _
                           ByVal idTipoComprobante As String, _
                           ByVal letra As String, _
                           ByVal centroEmisor As Integer, _
                           ByVal numeroComprobante As Long, _
                           ByVal observacion As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("  Observacion = '" & observacion & "'")

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
         .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")
   End Sub

   Public Function GetCanalesYRubros(fechaDesde As DateTime,
                                     fechaHasta As DateTime,
                                     productos As List(Of Eniac.Entidades.Producto)) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT	tc.idtipocliente, ")
         .Append("		tc.nombretipoCliente, ")
         .Append("		vp.idproducto, ")
         .Append("		p.nombreproducto,   ")
         .Append("		sum(vp.cantidad) cantidad")
         .Append(" FROM Ventas v")
         .Append(" INNER JOIN Ventasproductos VP ON ")
         .Append("	V.IdSucursal = VP.IdSucursal")
         .Append("	AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .Append("	AND V.Letra = VP.Letra")
         .Append("	AND V.CentroEmisor = VP.CentroEmisor")
         .Append("	AND V.NumeroComprobante = VP.NumeroComprobante")
         .Append(" LEFT JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .Append(" INNER JOIN TiposClientes tc")
         .Append("	ON c.idtipocliente = tc.idtipocliente")
         .Append(" INNER JOIN Productos P")
         .Append("	ON p.idproducto = vp.idproducto")
         .AppendFormat(" WHERE v.Fecha BETWEEN '{0} 00:00:00' and '{1} 23:59:59'", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))
         If productos.Count > 0 Then
            .Append(" AND vp.idproducto in (")
            For Each pr As Eniac.Entidades.Producto In productos
               .AppendFormat(" '{0}',", pr.IdProducto)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If
         .Append(" GROUP BY	tc.idtipocliente, ")
         .Append("			tc.nombretipocliente, ")
         .Append("			vp.idproducto, ")
         .Append("			p.nombreproducto")
         .Append(" ORDER BY tc.idtipocliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetCajonesHectolitros(fechaDesde As DateTime,
                                          fechaHasta As DateTime,
                                          productos As List(Of Eniac.Entidades.Producto),
                                          localidades As List(Of Eniac.Entidades.Localidad),
                                           tiposComprobantes As List(Of Eniac.Entidades.TipoComprobante),
                                          IdVendedor As Integer,
                                          idTransportista As Integer,
                                          idTipoCliente As Integer,
                                          muestraImportes As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      Dim cadenaFiltros As String
      With stb
         Dim dt As DataTable = Me.GetDataTable("select distinct(CONVERT (char(10), v.fecha, 112)) fechita from ventas v WHERE v.Fecha BETWEEN '" +
                                               fechaDesde.ToString("yyyyMMdd") + " 00:00:00' and '" +
                                               fechaHasta.ToString("yyyyMMdd") + " 23:59:59' ORDER BY Fechita")
         For Each dr As DataRow In dt.Rows
            .AppendFormat("[{0}],", dr("fechita").ToString())
         Next
         If dt.Rows.Count > 0 Then
            .Remove(.Length - 1, 1)
         End If
         cadenaFiltros = .ToString()

         .Length = 0
         .AppendFormat("select idproducto, nombreproducto, tamano, Embalaje as presentacion, nombreMarca, {0}", cadenaFiltros)
         .Append(" from ")
         .Append(" (SELECT	vp.idproducto, ")
         .Append("		p.nombreproducto,")
         .Append("		p.Tamano,")
         .Append("		p.Embalaje,   ")
         .Append("		m.nombremarca,")
         .Append("		CONVERT (char(10), v.fecha, 112) fechita,")
         If muestraImportes Then
            .Append("		sum(vp.ImporteTotal) cantidad")
         Else
            .Append("		sum(vp.cantidad) cantidad")
         End If
         .Append(" FROM Ventas v")
         .Append(" LEFT JOIN Ventasproductos VP ON ")
         .Append("	V.IdSucursal = VP.IdSucursal")
         .Append("	AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .Append("	AND V.Letra = VP.Letra")
         .Append("	AND V.CentroEmisor = VP.CentroEmisor")
         .Append("	AND V.NumeroComprobante = VP.NumeroComprobante")
         .Append(" LEFT JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .Append(" LEFT JOIN Productos P")
         .Append("	ON p.idproducto = vp.idproducto")
         .Append(" LEFT JOIN Marcas M")
         .Append("	ON p.idmarca = M.idmarca")
         .Append(" LEFT JOIN TiposComprobantes tc")
         .Append("	ON tc.IdTipoComprobante = v.IdTipoComprobante")
         .Append(" LEFT JOIN Calles Cal	ON C.IdCalle = Cal.IdCalle ")
         .AppendFormat(" WHERE v.Fecha BETWEEN '{0} 00:00:00' and '{1} 23:59:59'",
                                                   fechaDesde.ToString("yyyyMMdd"),
                                                   fechaHasta.ToString("yyyyMMdd"))
         .Append(" AND tc.AfectaCaja = 1")
         If IdVendedor > 0 Then
            .AppendFormat(" AND v.IdVendedor = {0} ", IdVendedor)
         End If
         If idTransportista <> 0 Then
            .AppendFormat(" AND v.IdTransportista = {0}", idTransportista)
         End If
         If idTipoCliente <> 0 Then
            .AppendFormat(" AND C.IdTipoCliente = {0}", idTipoCliente)
         End If
         If productos.Count > 0 Then
            .Append(" AND vp.idproducto in (")
            For Each pr As Eniac.Entidades.Producto In productos
               .AppendFormat(" '{0}',", pr.IdProducto)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If
         If localidades.Count > 0 Then
            .Append(" AND Cal.idlocalidad in (")
            For Each pr As Eniac.Entidades.Localidad In localidades
               .AppendFormat(" {0},", pr.IdLocalidad)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If
         If tiposComprobantes.Count > 0 Then
            .Append(" AND V.IdTipoComprobante in (")
            For Each pr As Eniac.Entidades.TipoComprobante In tiposComprobantes
               .AppendFormat(" '{0}',", pr.IdTipoComprobante)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If
         .Append(" GROUP BY	fecha,")
         .Append("			vp.idproducto, ")
         .Append("			p.nombreproducto,")
         .Append("			p.tamano,")
         .Append("			p.Embalaje,")
         .Append("			m.nombremarca) as pvt")
         .Append(" PIVOT")
         .AppendFormat("  (SUM(cantidad) FOR fechita IN ({0})) AS PivotTable", cadenaFiltros)
         .AppendFormat("  group by idproducto,nombreproducto, tamano, Embalaje, nombremarca,{0}", cadenaFiltros)
         .Append("  order by nombremarca, idproducto, nombreproducto")
      End With
      If String.IsNullOrEmpty(cadenaFiltros) Then
         Return Nothing
      Else
         Return Me.GetDataTable(stb.ToString())
      End If
   End Function

   Public Function GetProximoNumeroReparto() As Integer
      Return New Repartos(_da).GetCodigoMaximo(actual.Sucursal.IdSucursal) + 1
   End Function

   Public Function GetFacturasGeneradas(ByVal Sucursal As Integer, _
                                       ByVal Desde As DateTime, _
                                       ByVal Hasta As DateTime) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.Fecha ")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("	,c.TipoDocCliente ")
         .AppendLine("	,c.NroDocCliente ")
         .AppendLine("	,V.ImporteBruto ")
         .AppendLine("	,V.DescuentoRecargoPorc ")
         .AppendLine("	,V.DescuentoRecargo ")
         .AppendLine("	,V.SubTotal ")
         .AppendLine("	,V.TotalImpuestos ")
         .AppendLine("	,V.ImporteTotal ")
         .AppendLine("	,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine("   ,I.IdImpresora")
         .AppendLine("   ,I.TipoImpresora")
         .AppendLine("   ,V.IdEstadoComprobante")
         .AppendLine("   ,C.Cuit")
         .AppendLine("   ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("   ,V.IdFormasPago")
         .AppendLine("   ,V2.Invoco")
         .AppendLine("   ,V.IdSucursal")

         .AppendLine("   ,V.NumeroReparto")

         .AppendLine("	FROM Clientes C, CategoriasFiscales CF, Impresoras I, TiposComprobantes TC, VentasFormasPago VFP, Ventas V")

         'Calcula los comprobantes Invocados
         .AppendLine("	LEFT JOIN (SELECT IdSucursal, IdTipoComprobanteFact, LetraFact, CentroEmisorFact, NumeroComprobanteFact, count(*) AS Invoco ")
         .AppendLine("	           FROM Ventas")
         .AppendLine("	           GROUP BY IdSucursal, IdTipoComprobanteFact, LetraFact, CentroEmisorFact, NumeroComprobanteFact) V2 ")
         .AppendLine("	ON V2.IdSucursal = V.IdSucursal AND V2.IdTipoComprobanteFact=V.IdTipoComprobante AND V2.LetraFact=V.Letra AND V2.CentroEmisorFact=V.CentroEmisor AND V2.NumeroComprobanteFact=V.NumeroComprobante")
         '---------

         'Calcula los lotes
         '.AppendLine("	LEFT JOIN MovimientosVentas MV ON V.IdSucursal = MV.IdSucursal AND V.IdTipoComprobante = MV.IdTipoComprobante")
         '.AppendLine("			AND V.Letra = MV.Letra AND V.CentroEmisor = MV.CentroEmisor AND V.NumeroComprobante = MV.NumeroComprobante")
         '.AppendLine("	LEFT JOIN (SELECT MVPL.IdSucursal, MVPL.IdTipoMovimiento, MVPL.NumeroMovimiento, COUNT(*) as Lotes")
         '.AppendLine("				FROM MovimientosVentasProductosLotes MVPL")
         '.AppendLine("				GROUP BY MVPL.IdSucursal, MVPL.IdTipoMovimiento, MVPL.NumeroMovimiento) MVL2")
         '.AppendLine("				ON MVL2.IdSucursal = MV.IdSucursal AND MVL2.IdTipoMovimiento = MV.IdTipoMovimiento AND")
         '.AppendLine("				MV.NumeroMovimiento = MVL2.NumeroMovimiento")

         .AppendLine("  WHERE V.IdCliente = C.IdCliente ")
         .AppendLine("    AND V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .AppendLine("    AND V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("    AND V.CentroEmisor = I.CentroEmisor")
         .AppendLine("    AND V.IdFormasPago = VFP.IdFormasPago")

         .AppendFormat("    AND I.IdSucursal=" & Sucursal.ToString())
         .AppendLine("	 AND V.IdSucursal = " & Sucursal.ToString())
         .AppendFormat("	  AND V.fecha BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' ", Desde.ToString("yyyyMMdd"), Hasta.ToString("yyyyMMdd"))
         .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO') ")
         .AppendLine("  and TC.Tipo <> 'PEDIDOSCLIE'") ''v.IdTipoComprobante<>'PEDIDO' ")
         '.AppendLine("  and (v.IdTipoComprobante='FACT' or v.IdTipoComprobante='COTIZACION') ")

         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         .AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,V.Letra")
         .AppendLine("	,V.CentroEmisor")
         .AppendLine("	,V.NumeroComprobante")

      End With

      Return Me.GetDataTable(stb.ToString())


   End Function

   Public Function ExistePedidoXCli_Fecha(ByVal IdCliente As Long, fechaPed As DateTime) As Boolean

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT * FROM Ventas")
         .AppendLine(" WHERE IdCliente = " & IdCliente.ToString())
         .AppendLine("   AND Fecha = '" & fechaPed.ToString("yyyyMMdd HH:mm:ss") & "'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return True 'existe el pedido
      Else
         Return False ' no existe el pedido
      End If

   End Function

   Public Function ExistePedidoPDA(ByVal NumeroPedido As Long) As Boolean

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT * FROM Ventas")
         .AppendLine(" WHERE NumeroLote = " & NumeroPedido.ToString())
         .AppendLine("   AND IdTipoComprobante = 'PEDIDOPDA'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return True 'existe el pedido
      Else
         Return False ' no existe el pedido
      End If

   End Function

   Public Sub VentasProductos_U_Cantidad(ByVal idSucursal As Integer, _
                                         ByVal idTipoComprobante As String, _
                                         ByVal letra As String, _
                                         ByVal centroEmisor As Integer, _
                                         ByVal numeroComprobante As Long, _
                                         ByVal orden As Integer, _
                                         ByVal idProducto As String, _
                                         ByVal cantidad As Decimal, _
                                         ByVal importeTotal As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE VentasProductos SET ")
         .AppendFormat("  Cantidad = {0}", cantidad)
         .AppendFormat("  ,ImporteTotal = {0}", importeTotal)
         .AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", letra)
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat("   AND Orden = {0}", orden)
         .AppendFormat("   AND IdProducto = '{0}'", idProducto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasProductos")
   End Sub

   Public Sub Ventas_Facturables_U(ByVal idSucursal As Integer, _
                                   ByVal idTipoComprobante As String, _
                                   ByVal letra As String, _
                                   ByVal centroEmisor As Integer, _
                                   ByVal numeroComprobante As Long, _
                                   ByVal idTipoComprobanteFact As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormat("UPDATE Ventas SET IdTipoComprobanteFact = '{0}'", idTipoComprobanteFact)
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", letra)
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

End Class
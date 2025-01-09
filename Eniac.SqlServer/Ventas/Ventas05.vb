Partial Class Ventas

   ''REPARTOS

   Public Function GetUltNumeroReparto() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(NumeroReparto) AS maximo ")
         .AppendLine(" FROM Ventas")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetUltNumeroRepartoMasivo() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(NroRepartoInvocacionMasiva) AS maximo ")
         .AppendLine(" FROM Ventas")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub ActualizarNumeroReparto(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroComprobante As Long,
                                      numeroReparto As Integer?,
                                      idTransportista As Integer?,
                                      fechaReparto As DateTime?,
                                      mercDespachada As Boolean?)
      Dim qry = New StringBuilder()

      With qry
         .Append("UPDATE Ventas SET ")

         .AppendFormatLine("      NumeroReparto = {0}", If(numeroReparto.HasValue, numeroReparto.Value.ToString(), "NULL"))
         .AppendFormatLine("    , IdTransportista = {0}", If(idTransportista.HasValue, idTransportista.Value.ToString(), "NULL"))
         .AppendFormatLine("    , FechaEnvio = '{0}'", If(fechaReparto.HasValue, ObtenerFecha(fechaReparto.Value, True), "NULL"))
         If mercDespachada.HasValue Then
            .AppendFormatLine("    , MercDespachada = {0}", GetStringFromBoolean(mercDespachada.Value))
         End If

         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = '{0}'", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = '{0}'", numeroComprobante)
      End With

      Me.Execute(qry.ToString())
   End Sub

   Public Sub ActualizarDespachaMercaderia(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroComprobante As Long,
                                           mercDespachada As Boolean?)
      Dim qry = New StringBuilder()

      With qry
         .AppendFormatLine("UPDATE V")
         .AppendFormatLine("   SET MercDespachada = {0}", GetStringFromBoolean(mercDespachada.Value))

         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine(" INNER JOIN VentasInvocados VV ON VV.IdSucursalInvocado = V.IdSucursal")
         .AppendFormatLine("                              AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
         .AppendFormatLine("                              AND VV.LetraInvocado = V.Letra")
         .AppendFormatLine("                              AND VV.CentroEmisorInvocado = V.CentroEmisor")
         .AppendFormatLine("                              AND VV.NumeroComprobanteInvocado = V.NumeroComprobante")

         .AppendFormatLine(" WHERE VV.IdSucursal = '{0}'", idSucursal)
         .AppendFormatLine("   AND VV.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VV.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VV.CentroEmisor = '{0}'", centroEmisor)
         .AppendFormatLine("   AND VV.NumeroComprobante = '{0}'", numeroComprobante)
      End With

      Execute(qry.ToString())
   End Sub

   Public Function GetInfReparto(idSucursal As Integer,
                         desde As Date,
                         hasta As Date,
                         IdVendedor As Integer,
                         idCliente As Long,
                         tipoComprobante As String,
                         numeroReparto As Long,
                         idFormasPago As Integer,
                         idUsuario As String,
                         idTransportista As Integer) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT  V.FechaEnvio ")
         .AppendLine("       ,V.NumeroReparto")
         .AppendLine("       ,V.IdTransportista")
         .AppendLine("       ,T.NombreTransportista")
         .AppendLine("       ,V.IdSucursal")
         .AppendLine("       ,V.IdTipoComprobante ")
         .AppendLine("       ,V.Letra ")
         .AppendLine("       ,V.CentroEmisor")
         .AppendLine("       ,V.NumeroComprobante")
         .AppendFormat("     ,VP.IdProducto, P.NombreProducto, VP.Cantidad, CONVERT(DECIMAL(14,2), {0}) AS ImporteTotal, VP.Orden, CONVERT(DECIMAL(14,2), {1}) AS Precio, VP.AlicuotaImpuesto AS AlicuotaIVA",
                       Eniac.SqlServer.CalculosImpositivos.ObtenerPrecioConImpuestos("VP.ImporteTotal", "VP.AlicuotaImpuesto",
                                                                                     "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                                     "VP.OrigenPorcImpInt"),
                       Eniac.SqlServer.CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Precio", "VP.AlicuotaImpuesto",
                                                                                     "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                                     "VP.OrigenPorcImpInt")).AppendLine()
         .AppendLine("      ,VP.IdListaPrecios")
         .AppendLine("      ,VP.PorcImpuestoInterno")
         .AppendLine("      ,VP.OrigenPorcImpInt")
         .AppendLine("      ,VP.TipoOperacion")
         .AppendLine("      ,VP.Nota")
         .AppendLine(" FROM Ventas V ")
         .AppendLine(" LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista ")
         .AppendLine(" INNER JOIN VentasProductos VP ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("                              AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                              AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("                              AND VP.Letra = V.Letra")
         .AppendLine("                              AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal")
         .AppendLine("                                AND CC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                                AND CC.Letra = V.Letra")
         .AppendLine("                                AND CC.CentroEmisor = V.CentroEmisor")
         .AppendLine("                                AND CC.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")

         .AppendLine("  WHERE V.IdSucursal= " & idSucursal.ToString())

         .AppendLine("	  AND V.FechaEnvio >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("	  AND V.FechaEnvio <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If idCliente <> 0 Then
            .AppendLine("	 AND C.IdCliente = " & idCliente)
         End If

         If Not String.IsNullOrEmpty(tipoComprobante) Then
            .AppendLine("	 AND V.IdTipoComprobante = '" & tipoComprobante & "'")
         End If

         If numeroReparto > 0 Then
            .AppendLine("	 AND V.NumeroReparto = " & numeroReparto.ToString())
         End If

         If idFormasPago > 0 Then
            .AppendLine("	 AND V.IdFormasPago = " & idFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & idUsuario & "'")
         End If

         .AppendLine("      AND V.MercDespachada = 1 ")


         If idTransportista > 0 Then
            .AppendLine("	 AND V.IdTransportista = " & idTransportista)
         End If

         If IdVendedor > 0 Then
            .AppendFormat(" 		 AND V.IdVendedor = {0} ", IdVendedor)
         End If

         .AppendLine("   	  AND V.fechaRendicion IS NULL  AND CC.Saldo <> 0 ")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetProductosParaRegistrarReparto() As DataTable
      Return GetDataTable(GetQueryProductosParaRegistrarReparto())
   End Function

   Public Shared Function GetQueryProductosParaRegistrarReparto() As String
      Return "SELECT * FROM Productos WHERE Activo = 1 AND IdRubro = 2"
   End Function

   Public Function GetParaRegistrarReparto(dtProductos As DataTable, rutas As Entidades.MovilRuta(), idCliente As Long, mostrarPrecioConIva As Boolean, blnPrecioConIva As Boolean) As DataTable
      'Dim idRuta As Integer = rutas(0).IdRuta
      Dim stb = New StringBuilder()

      Dim campo_pivot_precio As StringBuilder = New StringBuilder()
      Dim campo_pivot_cantidad As StringBuilder = New StringBuilder()
      Dim campo_pivot_cantidadCambio As StringBuilder = New StringBuilder()
      Dim campo_sum As StringBuilder = New StringBuilder()
      For Each drCampos As DataRow In dtProductos.Rows
         campo_pivot_precio.AppendFormat("[{0}___precio],", drCampos("IdProducto"))
         campo_pivot_cantidad.AppendFormat("[{0}___cantidad],", drCampos("IdProducto"))
         campo_pivot_cantidadCambio.AppendFormat("[{0}___cantidadCambio],", drCampos("IdProducto"))

         campo_sum.AppendFormat(", SUM([{0}___precio]) [{0}___precio], SUM([{0}___cantidad]) [{0}___cantidad], SUM([{0}___cantidadCambio]) [{0}___cantidadCambio]", drCampos("IdProducto")).AppendLine()
      Next

      With stb
         .AppendFormatLine("SELECT IdCliente, CodigoCliente, NombreCliente, Direccion, IdTipoComprobante,Comprobante,  IdCategoria, NombreCategoria,IdListaPrecios, NombreListaPrecios")
         .AppendFormatLine(campo_sum.ToString())
         .AppendFormatLine("     , CONVERT(decimal(12,2), 0) ImporteTotal")
         .AppendFormatLine("     , CONVERT(decimal(12,2), 0) ImportePagado")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("  SELECT *")
         .AppendFormatLine("  FROM (SELECT C.IdCliente, C.CodigoCliente, C.NombreCliente, C.Direccion,C.IdTipoComprobante,TC.Descripcion as Comprobante")
         .AppendFormatLine("          , C.IdCategoria, CAT.NombreCategoria   , P.IdProducto, P.NombreProducto, PSP.IdListaPrecios, LP.NombreListaPrecios")
         If blnPrecioConIva Then
            If mostrarPrecioConIva Then
               .AppendFormatLine("             , CONVERT(DECIMAL(14,2), PSP.PrecioVenta) PrecioVenta")
            Else
               .AppendFormatLine("             , CONVERT(DECIMAL(14,2), {0}) PrecioVenta", CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
            End If
         Else
            If mostrarPrecioConIva Then
               .AppendFormatLine("             , CONVERT(DECIMAL(14,2), {0}) PrecioVenta", CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
            Else
               .AppendFormatLine("             , CONVERT(DECIMAL(14,2), PSP.PrecioVenta) PrecioVenta")
            End If
         End If
         .AppendFormatLine("             , CONVERT(DECIMAL(14,2), 0) AS Cantidad")
         .AppendFormatLine("             , CONVERT(DECIMAL(14,2), 0) AS CantidadCambio")
         .AppendFormatLine("             , P.IdProducto + '___precio'   producto_precio")
         .AppendFormatLine("             , P.IdProducto + '___cantidad' producto_cantidad")
         .AppendFormatLine("             , P.IdProducto + '___cantidadCambio' producto_cantidadCambio")
         .AppendFormatLine("          FROM Clientes C")
         .AppendFormatLine("         CROSS JOIN ({0}) P", GetQueryProductosParaRegistrarReparto())
         .AppendFormatLine("         INNER JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = P.IdProducto AND PSP.IdListaPrecios = C.IdListaPrecios AND PSP.IdSucursal = {0}", Entidades.Usuario.Actual.Sucursal.Id)
         .AppendFormatLine("         INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = PSP.IdListaPrecios")
         If rutas.Count > 0 Then
            .AppendFormatLine("         INNER JOIN MovilRutasClientes MRC ON MRC.IdCliente = C.IdCliente")
         End If
         .AppendFormatLine("         LEFT JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendFormatLine("         LEFT JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendFormatLine("         WHERE 1 = 1")
         'If idRuta <> 0 Then
         '   .AppendFormatLine("           AND MRC.IdRuta = {0}", idRuta)
         'End If
         GetListaMultiples(stb, rutas, "MRC")
         If idCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", idCliente)
         End If
         .AppendFormatLine("       ) C_P")
         .AppendFormatLine(" PIVOT (MAX(C_P.PrecioVenta) FOR producto_precio IN ({0})) PV1", campo_pivot_precio.ToString().Trim(","c))
         .AppendFormatLine(" PIVOT (MAX(PV1.Cantidad) FOR producto_cantidad IN ({0})) PV2", campo_pivot_cantidad.ToString().Trim(","c))
         .AppendFormatLine(" PIVOT (MAX(PV2.CantidadCambio) FOR producto_cantidadCambio IN ({0})) PV3", campo_pivot_cantidadCambio.ToString().Trim(","c))
         .AppendFormatLine("")
         .AppendFormatLine(") T")
         .AppendFormatLine("  GROUP BY IdCliente, CodigoCliente, NombreCliente, Direccion, IdTipoComprobante,Comprobante,IdCategoria, NombreCategoria,IdListaPrecios, NombreListaPrecios")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetRepartos(sucursales As Entidades.Sucursal(),
                               fechaEnvioDesde As Date?,
                               fechaEnvioHasta As Date?,
                               IdVendedor As Integer,
                               idCliente As Long,
                               idTipoComprobante As String,
                               numeroReparto As Long,
                               idFormasPago As Integer,
                               idUsuario As String,
                               idEstadoComprobante As String,
                               porcUtilidadDesde As Decimal?,
                               porcUtilidadHasta As Decimal?,
                               esComercial As Entidades.Publicos.SiNoTodos,
                               idCategoria As Integer,
                               idTransportista As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT DISTINCT")
         .AppendLine("       V.FechaEnvio")
         .AppendLine("     , V.IdSucursal")
         .AppendLine("     , V.NumeroReparto")
         .AppendLine("     , V.IdTransportista")
         .AppendLine("     , T.NombreTransportista")
         .AppendLine("     , R.TotalResumenComprobante")
         .AppendLine("     , R.TotalResumenEfectivo")
         .AppendLine("     , R.TotalResumenCtaCte")
         .AppendLine("     , R.TotalResumenCheques")
         .AppendLine("     , R.TotalResumenNCred")
         .AppendLine("     , R.TotalResumenReenvio")
         .AppendLine("     , R.TotalResumenSaldoGeneral")
         .AppendLine("     , R.TotalResumenTransferencia")
         .AppendLine("  FROM Ventas V")
         .AppendLine("  LEFT JOIN Repartos R ON V.IdSucursal=R.IdSucursal AND V.NumeroReparto=R.IdReparto")
         .AppendLine("  LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista ")
         .AppendLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "V")

         If fechaEnvioDesde.HasValue Then
            .AppendFormatLine("   AND V.FechaEnvio >= '{0}'", ObtenerFecha(fechaEnvioDesde.Value, True))
         End If
         If fechaEnvioHasta.HasValue Then
            .AppendFormatLine("   AND V.FechaEnvio <= '{0}'", ObtenerFecha(fechaEnvioHasta.Value, True))
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If esComercial <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND TC.EsComercial = {0}", GetStringFromBoolean(esComercial = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If numeroReparto > 0 Then
            .AppendFormatLine("   AND V.NumeroReparto = {0}", numeroReparto)
         End If

         If idFormasPago > 0 Then
            .AppendFormatLine("   AND V.IdFormasPago = {0}", idFormasPago)
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("   AND V.Usuario = '{0}'", idUsuario)
         End If

         If Not String.IsNullOrEmpty(idEstadoComprobante) Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If idEstadoComprobante = "PENDIENTE" Then
               .AppendFormatLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
            ElseIf idEstadoComprobante = "NO ANULADO" Then
               .AppendFormatLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendFormatLine("   AND V.IdEstadoComprobante = '{0}'", idEstadoComprobante)
            End If
         End If

         If porcUtilidadDesde.HasValue Then
            .AppendFormatLine("   AND ROUND(V.Utilidad/V.SubTotal*100,2) BETWEEN {0} AND {1}", porcUtilidadDesde.Value, porcUtilidadHasta.Value)
         End If

         .AppendFormatLine("   AND V.MercDespachada = 'True'")

         If idCategoria > 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If

         If idTransportista > 0 Then
            .AppendFormatLine("   AND V.IdTransportista = {0}", idTransportista)
         End If

         If IdVendedor > 0 Then
            .AppendFormatLine("   AND V.IdVendedor = {0} ", IdVendedor)
         End If

         .AppendFormatLine("   AND (V.IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")

         ' FIX 2020-01-29: Numeros de Reparto NULL
         .AppendLine("    AND V.NumeroReparto IS NOT NULL")

         .AppendLine(" ORDER BY NumeroReparto")
      End With

      Return GetDataTable(stb.ToString())

   End Function

End Class
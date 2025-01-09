Public Class VentasInvocados
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasInvocados_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.VentaInvocado.NombreTabla)
         .AppendFormatLine("  ({0}", Entidades.VentaInvocado.Columnas.IdSucursal.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.Letra.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.IdSucursalInvocado.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.IdTipoComprobanteInvocado.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.LetraInvocado.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.CentroEmisorInvocado.ToString())
         .AppendFormatLine("  ,{0}", Entidades.VentaInvocado.Columnas.NumeroComprobanteInvocado.ToString())

         .AppendFormatLine("  ) VALUES ( ")
         .AppendFormatLine("    {0} ", idSucursal)
         .AppendFormatLine("  ,'{0}'", idTipoComprobante)
         .AppendFormatLine("  ,'{0}'", letra)
         .AppendFormatLine("  , {0} ", centroEmisor)
         .AppendFormatLine("  , {0} ", numeroComprobante)
         .AppendFormatLine("  , {0} ", idSucursalInvocado)
         .AppendFormatLine("  ,'{0}'", idTipoComprobanteInvocado)
         .AppendFormatLine("  ,'{0}'", letraInvocado)
         .AppendFormatLine("  , {0} ", centroEmisorInvocado)
         .AppendFormatLine("  , {0} ", numeroComprobanteInvocado)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasInvocados_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long)
      Throw New NotImplementedException("No hay campos para hacer Update de VentasInvocados")
      'Dim myQuery As StringBuilder = New StringBuilder()
      'With myQuery
      '   .AppendFormat("UPDATE {0}", Entidades.VentaInvocado.NombreTabla).AppendLine()
      '   .AppendFormat("   SET {0} = '{1}'", Entidades.VentaInvocado.Columnas.NombreVentaInvocado.ToString(), nombreVentaInvocado).AppendLine()
      '   .AppendFormat("   ,{0} = {1}", Entidades.VentaInvocado.Columnas.CapacidadMaxima.ToString(), capacidadMaxima).AppendLine()
      '   .AppendFormat(" WHERE {0} =  {1} ", Entidades.VentaInvocado.Columnas.IdVentaInvocado.ToString(), idVentaInvocado).AppendLine()
      'End With
      'Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasInvocados_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.VentaInvocado.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.VentaInvocado.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaInvocado.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaInvocado.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaInvocado.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaInvocado.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub VentasInvocados_D_Invocados(idSucursalInvocador As Integer, idTipoComprobanteInvocador As String, letraInvocador As String, centroEmisorInvocador As Integer, numeroComprobanteInvocador As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.VentaInvocado.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.VentaInvocado.Columnas.IdSucursal.ToString(), idSucursalInvocador)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaInvocado.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteInvocador)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaInvocado.Columnas.Letra.ToString(), letraInvocador)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaInvocado.Columnas.CentroEmisor.ToString(), centroEmisorInvocador)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaInvocado.Columnas.NumeroComprobante.ToString(), numeroComprobanteInvocador)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VV.*")

         .AppendFormatLine("     , VOrigen.IdCliente, VOrigen.Cuit, VOrigen.Fecha, TCOrigen.Tipo TipoTipoComprobante, TCOrigen.CoeficienteStock")
         .AppendFormatLine("     , VOrigen.IdProveedor, TCOrigen.IdTipoComprobanteContraMovInvocar")
         .AppendFormatLine("     , TCOrigen.Descripcion DescripcionTipoComprobante")

         .AppendFormatLine("     , VDestino.IdCliente IdClienteInvocado, VDestino.Cuit CuitInvocado, VDestino.Fecha FechaInvocado, TCDestino.Tipo TipoTipoComprobanteInvocado, TCDestino.CoeficienteStock CoeficienteStockInvocado")
         .AppendFormatLine("     , VOrigen.IdProveedor IdProveedorInvocado, TCOrigen.IdTipoComprobanteContraMovInvocar IdTipoComprobanteContraMovInvocarInvocado")
         .AppendFormatLine("     , TCDestino.Descripcion DescripcionTipoComprobanteInvocado")

         .AppendFormatLine("  FROM {0} AS VV", Entidades.VentaInvocado.NombreTabla)
         .AppendFormatLine(" INNER Join Ventas VOrigen ON VOrigen.IdSucursal = VV.IdSucursal")
         .AppendFormatLine("                          AND VOrigen.IdTipoComprobante = VV.IdTipoComprobante")
         .AppendFormatLine("                          AND VOrigen.Letra = VV.Letra")
         .AppendFormatLine("                          AND VOrigen.CentroEmisor = VV.CentroEmisor")
         .AppendFormatLine("                          AND VOrigen.NumeroComprobante = VV.NumeroComprobante")
         .AppendFormatLine(" INNER Join Ventas VDestino ON VDestino.IdSucursal = VV.IdSucursalInvocado")
         .AppendFormatLine("                           AND VDestino.IdTipoComprobante = VV.IdTipoComprobanteInvocado")
         .AppendFormatLine("                           AND VDestino.Letra = VV.LetraInvocado")
         .AppendFormatLine("                           AND VDestino.CentroEmisor = VV.CentroEmisorInvocado")
         .AppendFormatLine("                           AND VDestino.NumeroComprobante = VV.NumeroComprobanteInvocado")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TCOrigen ON TCOrigen.IdTipoComprobante = VOrigen.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TCDestino ON TCDestino.IdTipoComprobante = VDestino.IdTipoComprobante")
      End With
   End Sub

   Public Function VentasInvocados_GA() As DataTable
      Return VentasInvocados_G(idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0,
                               idSucursalInvocado:=0, idTipoComprobanteInvocado:=String.Empty, letraInvocado:=String.Empty, centroEmisorInvocado:=0, numeroComprobanteInvocado:=0)
   End Function
   Private Function VentasInvocados_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND VV.{0} =  {1} ", Entidades.VentaInvocado.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND VV.{0} = '{1}'", Entidades.VentaInvocado.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND VV.{0} = '{1}'", Entidades.VentaInvocado.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND VV.{0} =  {1} ", Entidades.VentaInvocado.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("   AND VV.{0} =  {1} ", Entidades.VentaInvocado.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If
         If idSucursalInvocado > 0 Then
            .AppendFormatLine("   AND VV.{0} =  {1} ", Entidades.VentaInvocado.Columnas.IdSucursalInvocado.ToString(), idSucursalInvocado)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteInvocado) Then
            .AppendFormatLine("   AND VV.{0} = '{1}'", Entidades.VentaInvocado.Columnas.IdTipoComprobanteInvocado.ToString(), idTipoComprobanteInvocado)
         End If
         If Not String.IsNullOrWhiteSpace(letraInvocado) Then
            .AppendFormatLine("   AND VV.{0} = '{1}'", Entidades.VentaInvocado.Columnas.LetraInvocado.ToString(), letraInvocado)
         End If
         If centroEmisorInvocado > 0 Then
            .AppendFormatLine("   AND VV.{0} =  {1} ", Entidades.VentaInvocado.Columnas.CentroEmisorInvocado.ToString(), centroEmisorInvocado)
         End If
         If numeroComprobanteInvocado > 0 Then
            .AppendFormatLine("   AND VV.{0} =  {1} ", Entidades.VentaInvocado.Columnas.NumeroComprobanteInvocado.ToString(), numeroComprobanteInvocado)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function VentasInvocados_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long) As DataTable
      Return VentasInvocados_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                               idSucursalInvocado, idTipoComprobanteInvocado, letraInvocado, centroEmisorInvocado, numeroComprobanteInvocado)
   End Function

   Public Function VentasInvocados_G_InvocadosPorInvocador(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return VentasInvocados_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                               idSucursalInvocado:=0, idTipoComprobanteInvocado:=String.Empty, letraInvocado:=String.Empty, centroEmisorInvocado:=0, numeroComprobanteInvocado:=0)
   End Function
   Public Function VentasInvocados_G_InvocadoresPorInvocado(idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long) As DataTable
      Return VentasInvocados_G(idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0,
                               idSucursalInvocado, idTipoComprobanteInvocado, letraInvocado, centroEmisorInvocado, numeroComprobanteInvocado)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreSucursal" Then
      '   columna = "S." + columna
      'Else
      columna = "VV." + columna
      'End If
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Friend Shared Function GetCantidadInvocadosParaInforme_SubQuery(aliasVentas As String) As String
      aliasVentas = aliasVentas.TrimEnd("."c)
      Return GetCantidadInvocadosParaInforme_SubQuery(String.Concat(aliasVentas, ".", "IdSucursal"),
                                                      String.Concat(aliasVentas, ".", "IdTipoComprobante"),
                                                      String.Concat(aliasVentas, ".", "Letra"),
                                                      String.Concat(aliasVentas, ".", "CentroEmisor"),
                                                      String.Concat(aliasVentas, ".", "NumeroComprobante"))
   End Function

   Friend Shared Function GetCantidadInvocadosParaInforme_SubQuery(idSucursalAlias As String, idTipoComprobanteAlias As String, letraAlias As String, centroEmisorAlias As String, numeroComprobanteAlias As String) As String
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT SUM(Cantidad)")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        -- VentasInvocados")
         .AppendFormatLine("        SELECT COUNT(1) Cantidad")
         .AppendFormatLine("          FROM VentasInvocados VV")
         .AppendFormatLine("         WHERE (VV.IdSucursal = {0} AND VV.IdTipoComprobante = {1} AND VV.Letra = {2} AND VV.CentroEmisor = {3} AND VV.NumeroComprobante = {4})",
                           idSucursalAlias, idTipoComprobanteAlias, letraAlias, centroEmisorAlias, numeroComprobanteAlias)
         .AppendFormatLine("        UNION ALL")
         .AppendFormatLine("        -- Compras")
         .AppendFormatLine("        SELECT COUNT(1) Cantidad")
         .AppendFormatLine("          FROM Compras C")
         .AppendFormatLine("         WHERE (C.IdSucursalVenta = {0} AND C.IdTipoComprobanteVenta = {1} AND C.LetraVenta = {2} AND C.CentroEmisorVenta = {3} AND C.NumeroComprobanteVenta = {4})",
                           idSucursalAlias, idTipoComprobanteAlias, letraAlias, centroEmisorAlias, numeroComprobanteAlias)
         .AppendFormatLine("        UNION ALL")
         .AppendFormatLine("        -- Pedidos")
         .AppendFormatLine("        SELECT COUNT(1) Cantidad")
         .AppendFormatLine("          FROM (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido")
         .AppendFormatLine("                  FROM PedidosEstados PE")
         .AppendFormatLine("                 WHERE (PE.IdSucursalFact   = {0} AND PE.IdTipoComprobanteFact   = {1} AND PE.LetraFact   = {2} AND PE.CentroEmisorFact   = {3} AND PE.NumeroComprobanteFact   = {4})",
                           idSucursalAlias, idTipoComprobanteAlias, letraAlias, centroEmisorAlias, numeroComprobanteAlias)
         .AppendFormatLine("                    OR (PE.IdSucursalRemito = {0} AND PE.IdTipoComprobanteRemito = {1} AND PE.LetraRemito = {2} AND PE.CentroEmisorRemito = {3} AND PE.NumeroComprobanteRemito = {4})",
                           idSucursalAlias, idTipoComprobanteAlias, letraAlias, centroEmisorAlias, numeroComprobanteAlias)
         .AppendFormatLine("                 GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido) PE")
         .AppendFormatLine("        UNION ALL")
         .AppendFormatLine("        -- Service")
         .AppendFormatLine("        SELECT COUNT(1) Cantidad")
         .AppendFormatLine("          FROM CRMNovedades N")
         .AppendFormatLine("         WHERE (N.IdSucursalFact = {0} AND N.IdTipoComprobanteFact = {1} AND N.LetraFact = {2} AND N.CentroEmisorFact = {3} AND N.NumeroComprobanteFact = {4})",
                           idSucursalAlias, idTipoComprobanteAlias, letraAlias, centroEmisorAlias, numeroComprobanteAlias)
         .AppendFormatLine("        UNION ALL")
         .AppendFormatLine("        -- Turismo")
         .AppendFormatLine("        SELECT COUNT(1) Cantidad")
         .AppendFormatLine("          FROM ReservasTurismoPasajeros RP")
         .AppendFormatLine("         WHERE (RP.IdSucursalComprobante = {0} AND RP.IdTipoComprobante = {1} AND RP.LetraComprobante = {2} AND RP.CentroEmisorComprobante = {3} AND RP.NumeroComprobante = {4})",
                           idSucursalAlias, idTipoComprobanteAlias, letraAlias, centroEmisorAlias, numeroComprobanteAlias)
         .AppendFormatLine("        UNION ALL")
         .AppendFormatLine("        -- Turnos")
         .AppendFormatLine("        SELECT COUNT(1) Cantidad")
         .AppendFormatLine("          FROM TurnosCalendarios T")
         .AppendFormatLine("         WHERE (T.IdSucursal = {0} AND T.IdTipoComprobante = {1} AND T.Letra = {2} AND T.CentroEmisor = {3} AND T.NumeroComprobante = {4})",
                           idSucursalAlias, idTipoComprobanteAlias, letraAlias, centroEmisorAlias, numeroComprobanteAlias)
         .AppendFormatLine("       ) C")

      End With

      Return stb.ToString()
   End Function

   Public Function GetInvocadosParaInformes(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT V.IdSucursal")
         .AppendFormatLine("     , V.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS TipoComprobante")
         .AppendFormatLine("     , V.Letra")
         .AppendFormatLine("     , V.CentroEmisor")
         .AppendFormatLine("     , V.NumeroComprobante")
         .AppendFormatLine("     , V.Fecha")
         .AppendFormatLine("     , V.Kilos")
         .AppendFormatLine("     , V.Subtotal AS ImporteNeto")
         .AppendFormatLine("     , P.IdProveedor")
         .AppendFormatLine("     , P.CodigoProveedor")
         .AppendFormatLine("     , P.NombreProveedor")
         .AppendFormatLine("  FROM VentasInvocados VV")
         .AppendFormatLine("  LEFT JOIN Ventas V ON V.IdSucursal = VV.IdSucursalInvocado")
         .AppendFormatLine("                    AND V.IdTipoComprobante = VV.IdTipoComprobanteInvocado")
         .AppendFormatLine("                    AND V.Letra = VV.LetraInvocado")
         .AppendFormatLine("                    AND V.CentroEmisor = VV.CentroEmisorInvocado")
         .AppendFormatLine("                    AND V.NumeroComprobante = VV.NumeroComprobanteInvocado")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN Proveedores AS P ON P.IdProveedor = V.IdProveedor")
         .AppendFormatLine(" WHERE (VV.IdSucursal = {0} AND VV.IdTipoComprobante = '{1}' AND VV.Letra = '{2}' AND VV.CentroEmisor = {3} AND VV.NumeroComprobante = {4})",
                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         .AppendFormatLine("UNION ALL")

         .AppendFormatLine("SELECT C.IdSucursal")
         .AppendFormatLine("     , C.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS TipoComprobante")
         .AppendFormatLine("     , C.Letra")
         .AppendFormatLine("     , C.CentroEmisor")
         .AppendFormatLine("     , C.NumeroComprobante")
         .AppendFormatLine("     , C.Fecha")
         .AppendFormatLine("     , 0 AS Kilos")
         .AppendFormatLine("     , C.TotalNeto AS ImporteNeto")
         .AppendFormatLine("     , P.IdProveedor")
         .AppendFormatLine("     , P.CodigoProveedor")
         .AppendFormatLine("     , P.NombreProveedor")
         .AppendFormatLine("  FROM Compras C")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON C.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN Proveedores AS P ON P.IdProveedor = C.IdProveedor")
         .AppendFormatLine(" WHERE (C.IdSucursalVenta = {0} AND C.IdTipoComprobanteVenta = '{1}' AND C.LetraVenta = '{2}' AND C.CentroEmisorVenta = {3} AND C.NumeroComprobanteVenta = {4})",
                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         .AppendFormatLine("UNION ALL")

         .AppendFormatLine("SELECT PE.IdSucursal")
         .AppendFormatLine("     , PE.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS TipoComprobante")
         .AppendFormatLine("     , PE.Letra")
         .AppendFormatLine("     , PE.CentroEmisor")
         .AppendFormatLine("     , PE.NumeroPedido AS NumeroComprobante")
         .AppendFormatLine("     , P.FechaPedido AS Fecha")
         .AppendFormatLine("     , P.Kilos")
         .AppendFormatLine("     , P.Subtotal AS ImporteNeto")
         .AppendFormatLine("     , NULL IdProveedor")
         .AppendFormatLine("     , NULL CodigoProveedor")
         .AppendFormatLine("     , NULL NombreProveedor")
         .AppendFormatLine("  FROM (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido")
         .AppendFormatLine("          FROM PedidosEstados PE")
         .AppendFormatLine("         WHERE (PE.IdSucursalFact   = {0} AND PE.IdTipoComprobanteFact   = '{1}' AND PE.LetraFact   = '{2}' AND PE.CentroEmisorFact   = {3} AND PE.NumeroComprobanteFact   = {4})",
                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         .AppendFormatLine("            OR (PE.IdSucursalRemito = {0} AND PE.IdTipoComprobanteRemito = '{1}' AND PE.LetraRemito = '{2}' AND PE.CentroEmisorRemito = {3} AND PE.NumeroComprobanteRemito = {4})",
                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         .AppendFormatLine("         GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido) PE")
         .AppendFormatLine(" INNER JOIN Pedidos P ON P.IdSucursal = PE.IdSucursal AND P.IdTipoComprobante = PE.IdTipoComprobante AND P.Letra = PE.Letra AND P.CentroEmisor = PE.CentroEmisor AND P.NumeroPedido = PE.NumeroPedido")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON PE.IdTipoComprobante = TC.IdTipoComprobante")

         .AppendFormatLine("UNION ALL")

         .AppendFormatLine("SELECT NULL IdSucursal")
         .AppendFormatLine("     , N.IdTipoNovedad IdTipoComprobante")
         .AppendFormatLine("     , TN.NombreTipoNovedad AS TipoComprobante")
         .AppendFormatLine("     , N.Letra")
         .AppendFormatLine("     , N.CentroEmisor")
         .AppendFormatLine("     , N.IdNovedad")
         .AppendFormatLine("     , N.FechaNovedad")
         .AppendFormatLine("     , NULL Kilos")
         .AppendFormatLine("     , NULL AS ImporteNeto")
         .AppendFormatLine("     , NULL IdProveedor")
         .AppendFormatLine("     , NULL CodigoProveedor")
         .AppendFormatLine("     , NULL NombreProveedor")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine("  LEFT JOIN CRMTiposNovedades TN ON N.IdTipoNovedad = TN.IdTipoNovedad")
         .AppendFormatLine(" WHERE (N.IdSucursalFact = {0} AND N.IdTipoComprobanteFact = '{1}' AND N.LetraFact = '{2}' AND N.CentroEmisorFact = {3} AND N.NumeroComprobanteFact = {4})",
                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         .AppendFormatLine("UNION ALL")

         .AppendFormatLine("SELECT RP.IdSucursal")
         .AppendFormatLine("     , RP.IdTipoReserva IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS TipoComprobante")
         .AppendFormatLine("     , RP.Letra")
         .AppendFormatLine("     , RP.CentroEmisor")
         .AppendFormatLine("     , RP.NumeroReserva")
         .AppendFormatLine("     , R.Fecha")
         .AppendFormatLine("     , NULL Kilos")
         .AppendFormatLine("     , NULL AS ImporteNeto")
         .AppendFormatLine("     , NULL IdProveedor")
         .AppendFormatLine("     , NULL CodigoProveedor")
         .AppendFormatLine("     , NULL NombreProveedor")
         .AppendFormatLine("  FROM ReservasTurismoPasajeros RP")
         .AppendFormatLine(" INNER JOIN ReservasTurismo R ON R.IdSucursal = RP.IdSucursal AND R.IdTipoReserva = RP.IdTipoReserva AND R.Letra = RP.Letra AND R.CentroEmisor = RP.CentroEmisor AND R.NumeroReserva = RP.NumeroReserva")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON R.IdTipoReserva = TC.IdTipoComprobante")
         .AppendFormatLine(" WHERE (RP.IdSucursalComprobante = {0} AND RP.IdTipoComprobante = '{1}' AND RP.LetraComprobante = '{2}' AND RP.CentroEmisorComprobante = {3} AND RP.NumeroComprobante = {4})",
                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         .AppendFormatLine("UNION ALL")

         .AppendFormatLine("SELECT NULL IdSucursal")
         .AppendFormatLine("     , CONVERT(VARCHAR(MAX), T.IdCalendario) IdTipoComprobante")
         .AppendFormatLine("     , C.NombreCalendario AS TipoComprobante")
         .AppendFormatLine("     , NULL Letra")
         .AppendFormatLine("     , NULL CentroEmisor")
         .AppendFormatLine("     , NULL NumeroReserva")
         .AppendFormatLine("     , T.FechaDesde AS Fecha")
         .AppendFormatLine("     , NULL Kilos")
         .AppendFormatLine("     , NULL AS ImporteNeto")
         .AppendFormatLine("     , NULL IdProveedor")
         .AppendFormatLine("     , NULL CodigoProveedor")
         .AppendFormatLine("     , NULL NombreProveedor")
         .AppendFormatLine("  FROM TurnosCalendarios T")
         .AppendFormatLine(" INNER JOIN Calendarios C ON C.IdCalendario = T.IdCalendario")
         .AppendFormatLine(" WHERE (T.IdSucursal = {0} AND T.IdTipoComprobante = '{1}' AND T.Letra = '{2}' AND T.CentroEmisor = {3} AND T.NumeroComprobante = {4})",
                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         .AppendFormatLine("   ORDER BY Fecha")
      End With


      Return GetDataTable(stb)
   End Function

   Public Function GetInvocadoresParaInformes(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT V.IdSucursal")
         .AppendFormatLine("     , V.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS TipoComprobante")
         .AppendFormatLine("     , V.Letra")
         .AppendFormatLine("     , V.CentroEmisor")
         .AppendFormatLine("     , V.NumeroComprobante")
         .AppendFormatLine("     , V.Fecha")
         .AppendFormatLine("     , V.Kilos")
         .AppendFormatLine("     , V.Subtotal AS ImporteNeto")
         .AppendFormatLine("     , P.IdProveedor")
         .AppendFormatLine("     , P.CodigoProveedor")
         .AppendFormatLine("     , P.NombreProveedor")
         .AppendFormatLine("  FROM VentasInvocados VV")
         .AppendFormatLine("  LEFT JOIN Ventas V ON V.IdSucursal = VV.IdSucursal")
         .AppendFormatLine("                    AND V.IdTipoComprobante = VV.IdTipoComprobante")
         .AppendFormatLine("                    AND V.Letra = VV.Letra")
         .AppendFormatLine("                    AND V.CentroEmisor = VV.CentroEmisor")
         .AppendFormatLine("                    AND V.NumeroComprobante = VV.NumeroComprobante")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN Proveedores AS P ON P.IdProveedor = V.IdProveedor")
         .AppendFormatLine(" WHERE VV.IdSucursalInvocado = {0}", idSucursal)
         .AppendFormatLine("   AND VV.IdTipoComprobanteInvocado = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VV.LetraInvocado = '{0}'", letra)
         .AppendFormatLine("   AND VV.CentroEmisorInvocado = {0}", centroEmisor)
         .AppendFormatLine("   AND VV.NumeroComprobanteInvocado = {0}", numeroComprobante)

         .AppendFormatLine("   ORDER BY Fecha")
      End With


      Return GetDataTable(stb)
   End Function

End Class
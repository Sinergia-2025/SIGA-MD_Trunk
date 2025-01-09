Partial Class CuentasCorrientes
   Public Function GetEstadoSituacionCrediticia(sucursales As Entidades.Sucursal(), idCliente As Long, desdeEmision As Date?, hastaEmision As Date?, fechaVencimiento As Date?, ctacteAnticipo As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT '...' AS Ver")
         .AppendFormatLine("     , CCP.IdSucursal AS IdSucursal")
         .AppendFormatLine("     , CCP.IdTipoComprobante AS IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS TipoComprobante")
         .AppendFormatLine("     , CCP.Letra AS Letra")
         .AppendFormatLine("     , CCP.CentroEmisor AS CentroEmisor")
         .AppendFormatLine("     , CCP.NumeroComprobante AS NumeroComprobante")
         .AppendFormatLine("     , CCP.CuotaNumero AS CuotaNumero")
         .AppendFormatLine("     , CCP.Fecha AS Fecha")
         .AppendFormatLine("     , VFP.DescripcionFormasPago FormaPago")
         .AppendFormatLine("     , CCP.FechaVencimiento FechaVencimiento")
         .AppendFormatLine("     , CCP.ImporteCuota")
         .AppendFormatLine("     , CCP.SaldoCuota")
         .AppendFormatLine("     , CC.Observacion ")
         .AppendFormatLine("  FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine(" INNER JOIN CuentasCorrientes CC")
         .AppendFormatLine("         ON CCP.IdSucursal = CC.IdSucursal ")
         .AppendFormatLine("        AND CCP.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendFormatLine("        AND CCP.Letra = CC.Letra ")
         .AppendFormatLine("        AND CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendFormatLine("        AND CCP.NumeroComprobante = CC.NumeroComprobante ")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN VentasFormasPago VFP ON CCP.IdFormasPago = VFP.IdFormasPago")

         .AppendFormatLine(" WHERE (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO')")
         .AppendFormatLine("   AND TC.EsPreElectronico = 'False'")
         .AppendFormatLine("   AND CCP.SaldoCuota <> 0")

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         .AppendFormatLine("   AND CC.IdCliente = {0}", idCliente)

         If ctacteAnticipo Then
            .AppendFormatLine("   AND TC.EsAnticipo = 'False'")
         Else
            .AppendFormatLine("   AND TC.EsAnticipo = 'True'")
         End If

         If desdeEmision.HasValue Then
            .AppendFormatLine("   AND CCP.Fecha >= '{0}'", ObtenerFecha(desdeEmision.Value, True))
            .AppendFormatLine("   AND CCP.Fecha <= '{0}'", ObtenerFecha(hastaEmision.Value, True))
         End If

         If fechaVencimiento.HasValue Then
            .AppendFormatLine("   AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(fechaVencimiento.Value.UltimoSegundoDelDia(), True))
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetChequesSituacionCrediticia(sucursales As Entidades.Sucursal(), idCliente As Long,
                                                 estadosSinFechaCobro As Entidades.Cheque.Estados(),
                                                 estadosConFechaCobro As Entidades.Cheque.Estados(), fechaCobroDesde As Date?, fechaCobroHasta As Date?) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT C.IdBanco")
         .AppendFormatLine("     , C.IdCheque")
         .AppendFormatLine("     , B.NombreBanco")
         .AppendFormatLine("     , C.IdBancoSucursal")
         .AppendFormatLine("     , C.IdLocalidad")
         .AppendFormatLine("     , L.NombreLocalidad")
         .AppendFormatLine("     , C.NumeroCheque")
         .AppendFormatLine("     , CONVERT(DATE, C.FechaEmision)  AS FechaEmision")
         .AppendFormatLine("     , CONVERT(DATE, C.FechaCobro)    AS FechaCobro")
         .AppendFormatLine("     , C.Titular")
         .AppendFormatLine("     , C.Importe")
         .AppendFormatLine("     , C.IdEstadoCheque")
         .AppendFormatLine("     , C.IdProveedor")
         .AppendFormatLine("     , P.CodigoProveedor")
         .AppendFormatLine("     , P.NombreProveedor")
         .AppendFormatLine("     , C.idSituacionCheque")
         .AppendFormatLine("     , SCH.NombreSituacionCheque")
         .AppendFormatLine("     , CASE WHEN CCP.IdTipoComprobante IS NULL AND CCC.IdCheque IS NOT NULL THEN 'SI' ELSE 'NO' END ChequeDeAnticipo")

         .AppendFormatLine("  FROM Cheques C")
         .AppendFormatLine(" INNER JOIN Bancos B ON B.IdBanco = C.IdBanco ")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON TC.IdTipoCheque = C.IdTipoCheque")
         .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendFormatLine(" INNER JOIN SituacionCheques SCH ON SCH.IdSituacionCheque = C.IdSituacionCheque ")
         .AppendFormatLine("  LEFT JOIN Proveedores P ON P.IdProveedor = C.IdProveedor ")

         .AppendFormatLine("  LEFT JOIN CuentasCorrientesCheques CCC ON CCC.IdCheque = C.IdCheque")
         .AppendFormatLine("  LEFT JOIN CuentasCorrientesPagos CCP")
         .AppendFormatLine("         ON CCP.IdSucursal = CCC.IdSucursal")
         .AppendFormatLine("			AND CCP.IdTipoComprobante = CCC.IdTipoComprobante")
         .AppendFormatLine("			AND CCP.CentroEmisor = CCC.CentroEmisor")
         .AppendFormatLine("			AND CCP.Letra = CCC.Letra")
         .AppendFormatLine("			AND CCP.NumeroComprobante = CCC.NumeroComprobante")

         .AppendFormatLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stbQuery, sucursales, "C")

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         '.AppendFormatLine("   AND (CCP.IdTipoComprobante IS NULL AND CCC.IdCheque IS NOT NULL) --Solo traigo los cheques de Anticipos")

         .AppendFormatLine("   AND C.EsPropio = 'False'")

         If estadosSinFechaCobro.AnySecure() Or estadosConFechaCobro.AnySecure() Then
            .AppendFormatLine("   AND (")
            If estadosSinFechaCobro.AnySecure() Then
               .AppendFormatLine("       (C.IdEstadoCheque IN ({0}))", String.Join(",", estadosSinFechaCobro.ToList().ConvertAll(Function(e) String.Format("'{0}'", e.ToString()))))
            End If
            If estadosSinFechaCobro.AnySecure() And estadosConFechaCobro.AnySecure() Then
               .AppendFormatLine("       OR ")
            End If
            If estadosConFechaCobro.AnySecure() Then
               .AppendFormatLine("       (C.IdEstadoCheque IN ({0}) ", String.Join(",", estadosConFechaCobro.ToList().ConvertAll(Function(e) String.Format("'{0}'", e.ToString()))))
               If fechaCobroDesde.HasValue Then
                  .AppendFormatLine("      AND C.FechaCobro >= '{0}'", ObtenerFecha(fechaCobroDesde.Value, False))
               End If
               If fechaCobroHasta.HasValue Then
                  .AppendFormatLine("      AND C.FechaCobro <= '{0}'", ObtenerFecha(fechaCobroDesde.Value.UltimoSegundoDelDia(), False))
               End If
               .AppendFormatLine("        )")
            End If
            .AppendFormatLine("        )")
         End If

         .AppendFormatLine("   ORDER BY C.FechaCobro")

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidosSituacionCrediticia(sucursales As Entidades.Sucursal(), idCliente As Long,
                                                 fechaPedidoDesde As Date?, fechaPedidoHasta As Date?) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT PP.IdSucursal")
         .AppendFormatLine("     , PP.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion DescripcionTipoComprobante")
         .AppendFormatLine("     , PP.Letra")
         .AppendFormatLine("     , PP.CentroEmisor")
         .AppendFormatLine("     , PP.NumeroPedido")
         .AppendFormatLine("     , PP.Orden")
         .AppendFormatLine("     , P.FechaPedido")
         .AppendFormatLine("     , P.NumeroOrdenCompra")
         .AppendFormatLine("     , OC.IdProveedor       IdProveedorOrdenCompra")
         .AppendFormatLine("     , POC.CodigoProveedor  CodigoProveedorOrdenCompra")
         .AppendFormatLine("     , POC.NombreProveedor  NombreProveedorOrdenCompra")
         .AppendFormatLine("     , PP.IdProducto")
         .AppendFormatLine("     , PP.NombreProducto")
         .AppendFormatLine("     , PP.ImporteTotalConImpuestos ImporteTotal")
         .AppendFormatLine("     , PP.ImporteTotalConImpuestos / PP.Cantidad * (PP.CantPendiente + PP.CantEnProceso) ImportePendiente")
         .AppendFormatLine("     , PP.CantPendiente + PP.CantEnProceso CantPendiente")
         .AppendFormatLine("     , PP.Cantidad")
         .AppendFormatLine("     , ISNULL(OC.Anticipado, 'False') Anticipado")

         .AppendFormatLine("  FROM PedidosProductos PP")
         .AppendFormatLine(" INNER JOIN Pedidos P ON P.IdSucursal = PP.IdSucursal")
         .AppendFormatLine("                     AND P.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendFormatLine("                     AND P.Letra = PP.Letra")
         .AppendFormatLine("                     AND P.CentroEmisor = PP.CentroEmisor")
         .AppendFormatLine("                     AND P.NumeroPedido = PP.NumeroPedido")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         .AppendFormatLine("  LEFT JOIN Proveedores POC ON POC.IdProveedor = OC.IdProveedor")
         .AppendFormatLine("")
         .AppendFormatLine(" WHERE TC.Tipo = '{0}'", Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())
         .AppendFormatLine("   AND (PP.CantPendiente <> 0 OR PP.CantEnProceso <> 0)")

         GetListaSucursalesMultiples(stbQuery, sucursales, "PP")

         If idCliente <> 0 Then
            .AppendFormatLine("   AND P.IdCliente = {0}", idCliente)
         End If

         If fechaPedidoDesde.HasValue Then
            .AppendFormatLine("   AND P.FechaPedido >= '{0}'", ObtenerFecha(fechaPedidoDesde.Value, False))
         End If
         If fechaPedidoHasta.HasValue Then
            .AppendFormatLine("   AND p.FechaPedido <= '{0}'", ObtenerFecha(fechaPedidoHasta.Value.Date.UltimoSegundoDelDia(), True))
         End If

         .AppendFormatLine(" ORDER BY P.FechaPedido")
      End With
      Return GetDataTable(stbQuery)
   End Function

End Class
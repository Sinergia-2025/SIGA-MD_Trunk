Partial Class CuentasCorrientes
   Private Sub ArmaQueryInternoParaSincronizacionMovilDebeHaber(stb As StringBuilder, mesesEnviar As Integer, saldoInicial As Boolean,
                                                                sucs As IEnumerable(Of Integer))
      With stb
         .AppendFormatLine("SELECT E.CuitEmpresa")
         .AppendFormatLine("     , CC.IdSucursal")                   '.AppendLine("     , CCP.IdSucursal")
         .AppendFormatLine("     , CC.IdTipoComprobante")            '.AppendLine("     , CCP.IdTipoComprobante")
         .AppendFormatLine("     , CC.Letra")                        '.AppendLine("     , CCP.Letra")
         .AppendFormatLine("     , CC.CentroEmisor")                 '.AppendLine("     , CCP.CentroEmisor")
         .AppendFormatLine("     , CC.NumeroComprobante")            '.AppendLine("     , CCP.NumeroComprobante")
         .AppendFormatLine("     , 0 CuotaNumero")                   '.AppendLine("     , CCP.CuotaNumero")
         .AppendFormatLine("     , TC.Descripcion")
         .AppendFormatLine("     , TC.DescripcionAbrev")
         .AppendFormatLine("     , C.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , CC.Fecha")                        '.AppendLine("     , CCP.Fecha") 
         .AppendFormatLine("     , CC1.Fecha FechaSaldoInicial")
         '.AppendFormatLine("     , CCP.FechaVencimiento")      
         .AppendFormatLine("     , ISNULL((SELECT MAX(CCP.FechaVencimiento)")
         .AppendFormatLine("                 FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine("                WHERE CCP.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("                  AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("                  AND CCP.Letra = CC.Letra")
         .AppendFormatLine("                  AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("                  AND CCP.NumeroComprobante = CC.NumeroComprobante), CC.Fecha) FechaVencimiento")
         .AppendFormatLine("     , CC.ImporteTotal ImporteCuota")    '.AppendLine("     , CCP.ImporteCuota") 
         .AppendFormatLine("     , CC.Saldo SaldoCuota")             '.AppendLine("     , CCP.SaldoCuota") 
         .AppendFormatLine("     , CASE WHEN TC.CoeficienteValores > 0 THEN CC.ImporteTotal * TC.CoeficienteValores ELSE 0 END Debe")
         .AppendFormatLine("     , CASE WHEN TC.CoeficienteValores < 0 THEN CC.ImporteTotal * TC.CoeficienteValores ELSE 0 END Haber")
         .AppendFormatLine("     , FP.IdFormasPago")
         .AppendFormatLine("     , FP.DescripcionFormasPago")
         .AppendFormatLine("     , FP.Dias")
         .AppendFormatLine("     , CC.Observacion")
         .AppendFormatLine("     , TC.GrabaLibro")
         .AppendFormatLine("     , ISNULL((SELECT '(' + VP.IdProducto + ') - ' + VP.NombreProducto + ' // '")
         .AppendFormatLine("                 FROM VentasProductos VP")
         .AppendFormatLine("         WHERE VP.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("                  AND VP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("                  AND VP.Letra = CC.Letra")
         .AppendFormatLine("                  AND VP.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("                  AND VP.NumeroComprobante= CC.NumeroComprobante")
         .AppendFormatLine("                  FOR XML PATH('')), '') NombreProductos")

         '.AppendFormatLine("  FROM (SELECT DISTINCT MRC.IdCliente FROM MovilRutas AS MR INNER JOIN MovilRutasClientes MRC ON MRC.IdRuta = MR.IdRuta WHERE MR.Activa = 1) AS MRC")
         '.AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = MRC.IdCliente")
         .AppendFormatLine("  FROM (SELECT C.IdCliente, C.CodigoCliente, C.NombreCliente, C.Activo FROM Clientes C WHERE C.Activo = 'True' AND (C.PublicarEnEmpresarial = 'True' OR C.PublicarEnGestion = 'True')) AS C")
         .AppendFormatLine(" INNER JOIN CuentasCorrientes CC ON CC.IdCliente = C.IdCliente")
         .AppendFormatLine(" INNER JOIN Sucursales S ON S.IdSucursal = CC.IdSucursal")
         .AppendFormatLine(" INNER JOIN Empresas E ON E.IdEmpresa = S.IdEmpresa")
         .AppendFormatLine(" INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = CC.IdFormasPago")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN (SELECT CC1.IdCliente, CONVERT(DATE, MAX(DATEADD(MONTH, {0}, CC1.Fecha))) Fecha FROM CuentasCorrientes CC1 GROUP BY CC1.IdCliente) CC1 ON CC1.IdCliente = CC.IdCliente",
                           mesesEnviar * -1)
         '.AppendFormatLine(" INNER JOIN CuentasCorrientesPagos CCP ON CCP.IdSucursal = CC.IdSucursal")
         '.AppendFormatLine("                                      AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         '.AppendFormatLine("                                      AND CCP.Letra = CC.Letra")
         '.AppendFormatLine("                                      AND CCP.CentroEmisor = CC.CentroEmisor")
         '.AppendFormatLine("                                      AND CCP.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine(" WHERE C.Activo = 'True'")
         If sucs IsNot Nothing Then
            .AppendFormatLine("   AND CC.IdSucursal IN ({0})", String.Join(",", sucs))
         End If
         .AppendFormatLine("   AND TC.EsPreElectronico = 'False'")
         .AppendFormatLine("   AND TC.EsAnticipo = 'False'")
         .AppendFormatLine("   AND NOT (TC.ImporteTope = 0 AND TC.ImporteMinimo = 0)")    'Excluir Minutas
         .AppendFormatLine("   AND ISNULL(CC.IdEstadoComprobante, '') <> 'ANULADO'")      'Excluir los anulados
         '.AppendFormatLine("   AND CC.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         .AppendFormatLine("   AND CC.Fecha {0} CC1.Fecha",
                           If(saldoInicial, "<", ">="))
      End With
   End Sub

   Public Function GetParaSincronizacionMovilDebeHaber(mesesEnviar As Integer, sucs As IEnumerable(Of Integer)) As DataTable
      'Dim fechaDesdeSaldoInicial As DateTime = New DateTime(1800, 1, 1)
      'Dim fechaHastaSaldoInicial As DateTime = fechaDesde.AddSeconds(-1)
      Dim stb = New StringBuilder()
      With stb
         'Obtengo los saldo iniciales agrupados por GRABA LIBRO
         .AppendFormatLine("SELECT * FROM (")
         .AppendFormatLine("SELECT ' ' CuitEmpresa")
         .AppendFormatLine("     , 0 AS IdSucursal")
         .AppendFormatLine("     , 'SALDOINICIAL' AS IdTipoComprobante")
         .AppendFormatLine("     , ' ' AS Letra")
         .AppendFormatLine("     , CC.GrabaLibro AS CentroEmisor")
         .AppendFormatLine("     , CC.CodigoCliente AS NumeroComprobante")
         .AppendFormatLine("     , 0 AS CuotaNumero")
         .AppendFormatLine("     , 'Saldo Inicial' Descripcion")
         .AppendFormatLine("     , 'S. Inicial' AS DescripcionAbrev")
         .AppendFormatLine("     , CC.IdCliente")
         .AppendFormatLine("     , CC.CodigoCliente")
         .AppendFormatLine("     , CC.NombreCliente")
         .AppendFormatLine("     , DATEADD(DAY, -1, CC.FechaSaldoInicial) AS Fecha") '', ObtenerFecha(fechaHastaSaldoInicial, True))
         .AppendFormatLine("     , CC.FechaSaldoInicial")
         .AppendFormatLine("     , DATEADD(DAY, -1, CC.FechaSaldoInicial) AS FechaVencimiento") '', ObtenerFecha(fechaHastaSaldoInicial, True))
         .AppendFormatLine("     , ABS(SUM(CC.Debe)  - SUM(CC.Haber)) AS ImporteCuota")
         .AppendFormatLine("     , ABS(SUM(CC.Debe)  - SUM(CC.Haber)) AS SaldoCuota")
         .AppendFormatLine("     , CASE WHEN SUM(CC.Debe)  > SUM(CC.Haber) THEN SUM(CC.Debe)  - SUM(CC.Haber) ELSE 0 END Debe")
         .AppendFormatLine("     , CASE WHEN SUM(CC.Haber) > SUM(CC.Debe)  THEN SUM(CC.Haber) - SUM(CC.Debe)  ELSE 0 END Haber")
         .AppendFormatLine("     , 0 AS IdFormasPago")
         .AppendFormatLine("     , '' AS DescripcionFormasPago")
         .AppendFormatLine("     , 0 AS Dias")
         .AppendFormatLine("     , '' AS Observacion")
         .AppendFormatLine("     , CC.GrabaLibro")
         .AppendFormatLine("     , '' NombreProductos")
         .AppendFormatLine("  FROM (")

         ArmaQueryInternoParaSincronizacionMovilDebeHaber(stb, mesesEnviar, saldoInicial:=True, sucs)
         .AppendFormatLine("       ) CC")
         .AppendFormatLine(" GROUP BY CC.IdCliente ")
         .AppendFormatLine("        , CC.CodigoCliente")
         .AppendFormatLine("        , CC.NombreCliente")
         .AppendFormatLine("        , CC.GrabaLibro")
         .AppendFormatLine("        , CC.FechaSaldoInicial")
         .AppendFormatLine("         UNION ALL")

         'Obtengo los saldo iniciales sin agrupar por GRABA LIBRO (para cuando se seleccione Todos)
         .AppendFormatLine("SELECT ' ' CuitEmpresa")
         .AppendFormatLine("     , 0 AS IdSucursal")
         .AppendFormatLine("     , 'SALDOINICIAL' AS IdTipoComprobante")
         .AppendFormatLine("     , ' ' AS Letra")
         .AppendFormatLine("     , -1 AS CentroEmisor")
         .AppendFormatLine("     , CC.CodigoCliente AS NumeroComprobante")
         .AppendFormatLine("     , 0 AS CuotaNumero")
         .AppendFormatLine("     , 'Saldo Inicial' Descripcion")
         .AppendFormatLine("     , 'S. Inicial' AS DescripcionAbrev")
         .AppendFormatLine("     , CC.IdCliente")
         .AppendFormatLine("     , CC.CodigoCliente")
         .AppendFormatLine("     , CC.NombreCliente")
         '.AppendFormatLine("     , CONVERT(DATETIME, '{0}') AS Fecha", ObtenerFecha(fechaHastaSaldoInicial, True))
         '.AppendFormatLine("     , CONVERT(DATETIME, '{0}') AS FechaVencimiento", ObtenerFecha(fechaHastaSaldoInicial, True))
         .AppendFormatLine("     , DATEADD(DAY, -1, CC.FechaSaldoInicial) AS Fecha") '', ObtenerFecha(fechaHastaSaldoInicial, True))
         .AppendFormatLine("     , CC.FechaSaldoInicial")
         .AppendFormatLine("     , DATEADD(DAY, -1, CC.FechaSaldoInicial) AS FechaVencimiento") '', ObtenerFecha(fechaHastaSaldoInicial, True))
         .AppendFormatLine("     , ABS(SUM(CC.Debe)  - SUM(CC.Haber)) AS ImporteCuota")
         .AppendFormatLine("     , ABS(SUM(CC.Debe)  - SUM(CC.Haber)) AS SaldoCuota")
         .AppendFormatLine("     , CASE WHEN SUM(CC.Debe)  > SUM(CC.Haber) THEN SUM(CC.Debe)  - SUM(CC.Haber) ELSE 0 END Debe")
         .AppendFormatLine("     , CASE WHEN SUM(CC.Haber) > SUM(CC.Debe)  THEN SUM(CC.Haber) - SUM(CC.Debe)  ELSE 0 END Haber")
         .AppendFormatLine("     , 0 AS IdFormasPago")
         .AppendFormatLine("     , '' AS DescripcionFormasPago")
         .AppendFormatLine("     , 0 AS Dias")
         .AppendFormatLine("     , '' AS Observacion")
         .AppendFormatLine("     , CONVERT(bit, 1) GrabaLibro")
         .AppendFormatLine("     , '' NombreProductos")
         .AppendFormatLine("  FROM (")

         ArmaQueryInternoParaSincronizacionMovilDebeHaber(stb, mesesEnviar, saldoInicial:=True, sucs)
         .AppendFormatLine("       ) CC")
         .AppendFormatLine(" GROUP BY CC.IdCliente ")
         .AppendFormatLine("        , CC.CodigoCliente")
         .AppendFormatLine("        , CC.NombreCliente")
         .AppendFormatLine("        , CC.FechaSaldoInicial")
         .AppendFormatLine("         UNION ALL")

         'Obtengo los movimientos del período
         ArmaQueryInternoParaSincronizacionMovilDebeHaber(stb, mesesEnviar, saldoInicial:=False, sucs)

         .AppendFormatLine("              ) AS CC")
         .AppendFormatLine(" ORDER BY CC.CodigoCliente")
         .AppendFormatLine("        , CC.Fecha")

      End With

      Return GetDataTable(stb)
   End Function

   Public Sub ActualizarNumeroReparto(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      numeroReparto As Integer?)
      Dim qry = New StringBuilder()

      With qry
         .AppendFormatLine("UPDATE CuentasCorrientes")
         .AppendFormatLine("   SET NumeroReparto = {0}", GetStringFromNumber(numeroReparto))

         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(qry)
   End Sub

   Public Function GetRecibosDeNovedad(idTipoNovedad As String, letraNovedad As String, centroEmisorNovedad As Short, numeroNovedad As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM CuentasCorrientes CC")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine(" WHERE CC.IdTipoNovedad         = '{0}'", idTipoNovedad)
         .AppendFormatLine("   AND CC.LetraNovedad          = '{0}'", letraNovedad)
         .AppendFormatLine("   AND CC.CentroEmisorNovedad   =  {0} ", centroEmisorNovedad)
         .AppendFormatLine("   AND CC.NumeroNovedad         =  {0} ", numeroNovedad)
         .AppendFormatLine("   AND TC.EsRecibo              = 'True'")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetComprobantesDeNovedad(idTipoNovedad As String, letraNovedad As String, centroEmisorNovedad As Short, numeroNovedad As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM CuentasCorrientes CC")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine(" WHERE CC.IdTipoNovedad         = '{0}'", idTipoNovedad)
         .AppendFormatLine("   AND CC.LetraNovedad          = '{0}'", letraNovedad)
         .AppendFormatLine("   AND CC.CentroEmisorNovedad   =  {0} ", centroEmisorNovedad)
         .AppendFormatLine("   AND CC.NumeroNovedad         =  {0} ", numeroNovedad)
      End With
      Return GetDataTable(stb)
   End Function
End Class
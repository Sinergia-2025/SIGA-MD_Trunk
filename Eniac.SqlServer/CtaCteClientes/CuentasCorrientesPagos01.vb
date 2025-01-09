Partial Class CuentasCorrientesPagos
   Public Function GetParaSincronizacionMovilDebeHaber(mesesEnviar As Integer, sucs As IEnumerable(Of Integer)) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT E.CuitEmpresa")
         .AppendFormatLine("     , C.IdCliente")
         .AppendFormatLine("     , CC.IdSucursal")
         .AppendFormatLine("     , CC.IdTipoComprobante")
         .AppendFormatLine("     , CC.Letra")
         .AppendFormatLine("     , CC.CentroEmisor")
         .AppendFormatLine("     , CC.NumeroComprobante")
         .AppendFormatLine("     , CCP.CuotaNumero")
         .AppendFormatLine("     , CC.Fecha")
         .AppendFormatLine("     , CC1.Fecha FechaDesde")
         .AppendFormatLine("     , CCP.ImporteCuota")
         .AppendFormatLine("     , CCP.SaldoCuota")
         .AppendFormatLine("     , CCP.FechaVencimiento")
         .AppendFormatLine("  FROM (SELECT C.IdCliente, C.Activo FROM Clientes C WHERE C.Activo = 'True' AND (C.PublicarEnEmpresarial = 'True' or C.PublicarEnGestion = 'True')) AS C")
         .AppendFormatLine(" INNER JOIN CuentasCorrientes CC ON CC.IdCliente = C.IdCliente")
         .AppendFormatLine(" INNER JOIN CuentasCorrientesPagos CCP ON CCP.IdSucursal = CC.IdSucursal AND CCP.IdTipoComprobante = CC.IdTipoComprobante AND CCP.Letra = CC.Letra AND CCP.CentroEmisor = CC.CentroEmisor AND CCP.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine(" INNER JOIN Sucursales S ON S.IdSucursal = CC.IdSucursal")
         .AppendFormatLine(" INNER JOIN Empresas E ON E.IdEmpresa = S.IdEmpresa")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN (SELECT CC1.IdCliente, CONVERT(DATE, MAX(DATEADD(MONTH, {0}, CC1.Fecha))) Fecha FROM CuentasCorrientes CC1 GROUP BY CC1.IdCliente) CC1 ON CC1.IdCliente = CC.IdCliente",
                           mesesEnviar * -1)
         .AppendFormatLine(" WHERE C.Activo = 'True'")
         If sucs IsNot Nothing Then
            .AppendFormatLine("   AND CC.IdSucursal IN ({0})", String.Join(",", sucs))
         End If
         .AppendFormatLine("   AND TC.EsPreElectronico = 'False'")
         .AppendFormatLine("   AND TC.EsAnticipo = 'False'")
         .AppendFormatLine("   AND TC.EsRecibo = 'False'")
         .AppendFormatLine("   AND NOT (TC.ImporteTope = 0 AND TC.ImporteMinimo = 0)")
         .AppendFormatLine("   AND ISNULL(CC.IdEstadoComprobante, '') <> 'ANULADO'")
         .AppendFormatLine("   AND CC.Fecha >= CC1.Fecha")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetParaAlerta(sucursales As Entidades.Sucursal(),
                                 fechaVancimientoHasta As Date?,
                                 saldoMinimoAlerta As Decimal,
                                 cantidadComprobanteAdeudados As Integer,
                                 incluirEmbarcacion As Boolean) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormatLine("SELECT C.IdCliente")
         '.AppendFormatLine("      ,C.TipoDocClient,")
         '.AppendFormatLine("      ,C.NroDocCliente")
         .AppendFormatLine("      ,C.CodigoCliente")
         .AppendFormatLine("      ,C.NombreCliente")
         '.AppendFormatLine("      ,C.NombreDeFantasia")
         .AppendFormatLine("      ,Ca.NombreCategoria")
         .AppendFormatLine("      ,Z.NombreZonaGeografica")
         .AppendFormatLine("      ,C.Telefono")
         .AppendFormatLine("      ,C.Celular")

         If incluirEmbarcacion Then
            .AppendFormatLine("      ,E.IdEmbarcacion")
            .AppendFormatLine("      ,E.CodigoEmbarcacion")
            .AppendFormatLine("      ,E.NombreEmbarcacion")
         End If
         .AppendFormatLine("       ,CC.Total")
         .AppendFormatLine("       ,CC.Saldo")
         .AppendFormatLine("       ,CC.Cantidad")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT CC.IdCliente")
         If incluirEmbarcacion Then
            .AppendFormatLine("             , CC.IdEmbarcacion")
         End If
         .AppendFormatLine("             , SUM(CCP.ImporteCuota) AS Total")
         .AppendFormatLine("             , SUM(CCP.SaldoCuota) as Saldo")
         .AppendFormatLine("             , COUNT(1) AS Cantidad")
         .AppendFormatLine("          FROM CuentasCorrientes CC")
         .AppendFormatLine("          INNER JOIN CuentasCorrientesPagos CCP ")
         .AppendFormatLine("                  ON CC.IdSucursal = CCP.IdSucursal")
         .AppendFormatLine("                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine("                 AND CC.Letra = CCP.Letra")
         .AppendFormatLine("                 AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendFormatLine("                 AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendFormatLine("          WHERE CC.IdTipoComprobante <> 'ANTICIPO'")

         GetListaSucursalesMultiples(stb, sucursales, "CC")

         If fechaVancimientoHasta.HasValue Then
            .AppendFormatLine("            AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(fechaVancimientoHasta.Value.UltimoSegundoDelDia(), True))
         End If
         .AppendFormatLine("           GROUP BY CC.IdCliente")
         If incluirEmbarcacion Then
            .AppendFormatLine("                  , CC.IdEmbarcacion")
         End If
         .AppendFormatLine("          HAVING SUM(CC.Saldo) > 0")
         .AppendFormatLine("             AND SUM(CC.Saldo) >= {0}", saldoMinimoAlerta)
         .AppendFormatLine("             AND COUNT(1) >= {0}", cantidadComprobanteAdeudados)
         .AppendFormatLine("        ) CC")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendFormatLine(" INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine(" INNER JOIN ZonasGeograficas Z ON Z.IdZonaGeografica = C.IdZonaGeografica")
         If incluirEmbarcacion Then
            .AppendFormatLine("  LEFT JOIN Embarcaciones E ON E.IdEmbarcacion = CC.IdEmbarcacion")
         End If
         .AppendFormatLine(" ORDER BY CC.Saldo DESC")
      End With

      Return GetDataTable(stb)

   End Function
   Public Function RecuperaAnticiposPremios(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroComprobante As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendLine("SELECT REC.* FROM CuentasCorrientesPagos CTP ")
         .AppendLine("INNER JOIN (SELECT  IdSucursal ,  ")
         .AppendLine("					IdTipoComprobante2,  ")
         .AppendLine("					Letra2,  ")
         .AppendLine("					CentroEmisor2,  ")
         .AppendLine("					NumeroComprobante2,  ")
         .AppendLine("					Fecha,   ")
         .AppendLine("					CantidadDiasCobro, ImporteCuota   ")
         .AppendLine("				FROM CuentasCorrientesPagos CCP   ")
         .AppendLine("					INNER JOIN TiposComprobantes TCP  ")
         .AppendLine("						ON TCP.IdTipoComprobante = CCP.IdTipoComprobante ")
         .AppendLine("				WHERE  ")
         .AppendFormatLine("			CCP.IdSucursal = {0} ", idSucursal)
         .AppendFormatLine("			AND CCP.IdTipoComprobante = '{0}' ", idTipoComprobante)
         .AppendFormatLine("			AND CCP.Letra = '{0}' ", letra)
         .AppendFormatLine("			AND CCP.CentroEmisor = {0} ", centroEmisor)
         .AppendFormatLine("			AND CCP.NumeroComprobante = {0} ", numeroComprobante)
         .AppendLine("				   AND CCP.IdTipoComprobante2 = TCP.IdTipoComprobanteSecundario ")
         .AppendLine("			) AS REC ")
         .AppendLine("			ON REC.IdSucursal = CTP.IdSucursal  ")
         .AppendLine("		   AND REC.IdTipoComprobante2 = CTP.IdTipoComprobante  ")
         .AppendLine("		   AND REC.Letra2 = CTP.Letra  ")
         .AppendLine("		   AND REC.NumeroComprobante2 = CTP.NumeroComprobante ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
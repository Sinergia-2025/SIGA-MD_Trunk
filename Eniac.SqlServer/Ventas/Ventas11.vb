Partial Class Ventas

   ''AFIP

   Public Function GetParaExportarAFIP(periodoFiscal As Integer, idEmpresa As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.Fecha")
         .AppendLine(" 	,V.IdSucursal")
         .AppendLine(" 	,V.IdTipoComprobante")
         .AppendLine(" 	,TC.DescripcionAbrev ")
         .AppendLine(" 	,V.Letra ")
         .AppendLine(" 	,V.CentroEmisor")
         .AppendLine(" 	,V.NumeroComprobante ")
         .AppendLine(" 	,V.IdVendedor ")
         .AppendLine(" 	,V.IdCliente ")
         .AppendLine(" 	,C.CodigoCliente ")
         '.AppendLine(" 	,C.NombreCliente ")
         '.AppendLine(" 	,C.TipoDocCliente ")
         '.AppendLine(" 	,C.NroDocCliente ")

         .AppendLine(" 	,CASE WHEN C.EsClienteGenerico = 'True' THEN V.NombreCliente ELSE C.NombreCliente END AS NombreCliente")
         .AppendLine(" 	,V.TipoDocCliente")
         .AppendLine(" 	,V.NroDocCliente")

         .AppendLine("  ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal")
         .AppendLine("  ,V.IdEstadoComprobante")
         '.AppendLine("  ,C.CUIT")

         .AppendLine("  ,V.CUIT")

         .AppendLine("  ,V.IdFormasPago")
         .AppendLine("  ,ATCTC.IdAFIPTipoComprobante")
         .AppendLine("  ,ATC.IdAFIPTipoDocumento IdAFIPTipoDocumentoTipoCbte")
         .AppendLine("  ,ATC.IncluyeFechaVencimiento")
         .AppendLine("  ,ATD.IdAFIPTipoDocumento")
         .AppendLine("  ,SUM(CASE WHEN VI.IdTipoImpuesto = 'IVA' THEN VI.Bruto ELSE 0 END) ImporteBruto")
         .AppendLine("  ,SUM(CASE WHEN VI.IdTipoImpuesto = 'IVA' THEN VI.Neto ELSE 0 END) Neto")
         '.AppendLine("  ,SUM(VI.Bruto) ImporteBruto")
         '.AppendLine("  ,SUM(VI.Neto) Neto")
         .AppendLine("  ,ISNULL(SUM(VI.Total), 0) Total")
         .AppendLine("  ,ISNULL(SUM(VI.Importe), 0) Importe")
         .AppendLine("  ,SUM(case VI.Alicuota when 21.00 then VI.Importe else 0 end) as IVA2100")
         .AppendLine("  ,SUM(case VI.Alicuota when 10.50 then VI.Importe else 0 end) as IVA1050")
         .AppendLine("  ,SUM(case VI.Alicuota when 27.00 then VI.Importe else 0 end) as IVA2700")
         .AppendLine("  ,SUM(case VI.Alicuota when 0.00 then VI.Neto else 0 end) as IVA0000")
         .AppendLine(" 	,SUM(case VI.IdTipoImpuesto when 'PGANA' then VI.Importe else 0 end) as PGANA")
         .AppendLine("  ,SUM(case VI.IdTipoImpuesto when 'PIIBB' then VI.Importe else 0 end) as PIIBB")
         .AppendLine("  ,SUM(case VI.IdTipoImpuesto when 'PIVA' then VI.Importe else 0 end) as PIVA")
         .AppendLine("	,SUM(case VI.IdTipoImpuesto when 'PVAR' then VI.Importe else 0 end) as PVAR")
         .AppendLine("	,SUM(case VI.IdTipoImpuesto when 'IMINT' then VI.Importe else 0 end) as IMPINT")
         .AppendLine("  FROM Ventas V")
         .AppendLine("  INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON L.IdProvincia = P.IdProvincia")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("  INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")
         .AppendLine(" LEFT JOIN VentasImpuestos VI ON V.IdSucursal = VI.IdSucursal AND V.IdTipoComprobante = VI.IdTipoComprobante ")
         .AppendLine("  AND V.Letra = VI.Letra AND V.CentroEmisor = VI.CentroEmisor AND V.NumeroComprobante = VI.NumeroComprobante  ")
         .AppendLine("  	LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON V.IdTipoComprobante = ATCTC.IdTipoComprobante AND V.Letra = ATCTC.Letra")
         .AppendLine("  	LEFT JOIN AFIPTiposComprobantes ATC ON ATC.IdAFIPTipoComprobante = ATCTC.IdAFIPTipoComprobante")
         '.AppendLine("	LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = C.TipoDocCliente")
         .AppendLine("  LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = V.TipoDocCliente")
         'CASE WHEN C.EsClienteGenerico = 'True' THEN V.TipoDocCliente ELSE C.TipoDocCliente END AS TipoDocCliente
         .AppendLine("  WHERE V.IdSucursal > 0 ")  ' & idSucursal.ToString())
         .AppendFormatLine("    AND S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("    AND YEAR(V.Fecha)*100+MONTH(V.Fecha) = " & periodoFiscal.ToString())
         .AppendLine("    AND TC.InformaLibroIva= 'True' ")
         '.AppendLine("    AND V.NumeroComprobante = 12")
         .AppendLine(" GROUP BY V.Fecha, V.IdSucursal,V.IdTipoComprobante ,TC.DescripcionAbrev ,V.Letra ,V.CentroEmisor ,V.NumeroComprobante ")
         .AppendLine(" ,V.IdVendedor	,V.IdCliente ,C.CodigoCliente	,C.NombreCliente ,C.TipoDocCliente ")
         .AppendLine(" ,C.NroDocCliente ,CF.NombreCategoriaFiscalAbrev ,V.IdEstadoComprobante ,C.CUIT ,V.IdFormasPago ")
         .AppendLine(" ,ATCTC.IdAFIPTipoComprobante ,ATD.IdAFIPTipoDocumento, ATC.IdAFIPTipoDocumento, ATC.IncluyeFechaVencimiento")
         .AppendLine(" ,C.EsClienteGenerico, V.NombreCliente, V.TipoDocCliente,V.NroDocCliente, V.CUIT, V.FechaAlta")
         .AppendLine("	ORDER BY V.Fecha, V.FechaAlta")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetParaExportarAFIPAlicuotas(periodoFiscal As Integer, idEmpresa As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT  V.Fecha")
         .AppendLine(" ,V.IdSucursal")
         .AppendLine(" ,V.IdTipoComprobante")
         .AppendLine(" ,TC.DescripcionAbrev ")
         .AppendLine(" ,V.Letra ")
         .AppendLine(" ,V.CentroEmisor")
         .AppendLine(" ,V.NumeroComprobante  ")
         '.AppendLine(" ,C.TipoDocCliente ")
         '.AppendLine(" ,C.NroDocCliente")
         '.AppendLine(" ,C.CUIT")

         .AppendLine(" ,CASE WHEN C.EsClienteGenerico = 'True' THEN V.TipoDocCliente ELSE C.TipoDocCliente END AS TipoDocCliente")
         .AppendLine(" ,CASE WHEN C.EsClienteGenerico = 'True' THEN V.NroDocCliente ELSE C.NroDocCliente END AS NroDocCliente")
         .AppendLine(" ,CASE WHEN C.EsClienteGenerico = 'True' THEN V.CUIT ELSE C.CUIT END AS CUIT")

         .AppendLine(" ,ATCTC.IdAFIPTipoComprobante")
         .AppendLine(" ,ATD.IdAFIPTipoDocumento ")
         .AppendLine(" ,VI.IdTipoImpuesto ")
         .AppendLine(" ,VI.Alicuota")
         .AppendLine(" ,AI.IdAFIPIVA")
         .AppendLine(" ,VI.Bruto")
         .AppendLine(" ,VI.Neto")
         .AppendLine(" ,VI.Total")
         .AppendLine(" ,VI.Importe")
         .AppendLine("  ,ATC.IdAFIPTipoDocumento IdAFIPTipoDocumentoTipoCbte")
         .AppendLine(" FROM Ventas V")
         .AppendLine("  INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" INNER JOIN VentasImpuestos VI ON V.IdSucursal = VI.IdSucursal AND V.IdTipoComprobante = VI.IdTipoComprobante ")
         .AppendLine(" AND V.Letra = VI.Letra AND V.CentroEmisor = VI.CentroEmisor AND V.NumeroComprobante = VI.NumeroComprobante ")
         .AppendLine(" LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON V.IdTipoComprobante = ATCTC.IdTipoComprobante AND V.Letra = ATCTC.Letra")
         .AppendLine(" LEFT JOIN AFIPTiposComprobantes ATC ON ATC.IdAFIPTipoComprobante = ATCTC.IdAFIPTipoComprobante")
         '.AppendLine(" LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = C.TipoDocCliente ")
         .AppendLine("  LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = CASE WHEN C.EsClienteGenerico = 'True' THEN V.TipoDocCliente ELSE C.TipoDocCliente END")
         .AppendLine(" LEFT JOIN AFIPIVAs AI ON AI.Alicuota = VI.Alicuota")
         .AppendLine("  WHERE V.IdSucursal > 0 ")  ' & idSucursal.ToString())
         .AppendFormatLine("    AND S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("    AND YEAR(V.Fecha)*100+MONTH(V.Fecha) = " & periodoFiscal.ToString())
         .AppendLine("    AND TC.InformaLibroIva = 'True'")
         .AppendLine("    AND VI.IdTipoImpuesto = 'IVA'")
         '.AppendLine("    AND V.NumeroComprobante = 3272")
         .AppendLine("	ORDER BY V.Fecha, V.FechaAlta")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetParaExportarAFIPComprobantesAnulados(periodoFiscal As Date, idEmpresa As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT V.Fecha")
         .AppendFormatLine("	   ,TC.DescripcionAbrev")
         .AppendFormatLine("	   ,V.IdTipoComprobante	   ")
         .AppendFormatLine("     ,ATCTC.IdAFIPTipoComprobante")
         .AppendFormatLine("	   ,V.Letra")
         .AppendFormatLine("	   ,V.CentroEmisor")
         .AppendFormatLine("	   ,V.NumeroComprobante")
         .AppendFormatLine("     ,C.NombreCliente  ")
         .AppendFormatLine("     ,C.TipoDocCliente ")
         .AppendFormatLine("     ,C.NroDocCliente  ")
         .AppendFormatLine("     ,C.Cuit           ")
         .AppendFormatLine("	   ,V.FechaActualizacion AS 'FechaDeAnulacion' ")
         .AppendFormatLine("     ,V.SubTotal")
         .AppendFormatLine("	   ,V.TotalImpuestos")
         .AppendFormatLine("	   ,V.ImporteTotal")
         .AppendFormatLine("FROM Ventas V")
         .AppendFormatLine(" INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendFormatLine(" INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         .AppendFormatLine(" LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON V.IdTipoComprobante = ATCTC.IdTipoComprobante AND V.Letra = ATCTC.Letra")
         .AppendFormatLine(" WHERE 1=1")
         .AppendFormatLine("   AND S.IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("	 AND V.Fecha >= '{0}'", ObtenerFecha(PrimerDiaMes(periodoFiscal), True))
         .AppendFormatLine("	 AND V.Fecha <= '{0}'", ObtenerFecha(UltimoSegundoDelDia(UltimoDiaMes(periodoFiscal)), True))
         .AppendFormatLine("	 AND V.IdEstadoComprobante = 'ANULADO'")
         .AppendFormatLine("	 AND TC.InformaLibroIva = 1")
      End With
      Return GetDataTable(query)
   End Function

   Public Function GetLibroDeIVA(idEmpresa As Integer, periodoFiscal As Integer, orden As String, idVendedor As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT ")
         If orden = "PROVINCIAIMPUESTO" Then
            .AppendLine("   PI.NombreProvincia")
         Else
            .AppendLine("   P.NombreProvincia")
         End If
         .AppendLine("	,V.Fecha")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("	,V.IdCliente ")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("  ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendLine("  ,V.IdEstadoComprobante")
         .AppendLine("  ,CASE WHEN C.CUIT IS NULL OR C.CUIT ='' THEN C.NroDocCliente ELSE C.CUIT END AS CUIT")
         .AppendLine("  ,V.IdFormasPago")
         .AppendLine("  ,VI.Bruto ImporteBruto")
         .AppendLine("  ,VI.Neto")
         .AppendLine("  ,VI.IdTipoImpuesto")
         .AppendLine("  ,VI.Alicuota")
         .AppendLine("  ,VI.Importe")
         .AppendLine("  ,VI.Total")
         If orden = "PROVINCIAIMPUESTO" Then
            .AppendLine("  ,PI.IdProvincia")
         Else
            .AppendLine("  ,P.IdProvincia")
         End If
         .AppendLine("  ,PI.IdProvincia IdProvinciaImpuesto")
         .AppendLine("  FROM Ventas V")
         .AppendLine("  INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON L.IdProvincia = P.IdProvincia")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("  INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")

         .AppendLine(" LEFT JOIN VentasImpuestos VI ON V.IdSucursal = VI.IdSucursal AND V.IdTipoComprobante = VI.IdTipoComprobante ")
         .AppendLine("                             AND V.Letra = VI.Letra AND V.CentroEmisor = VI.CentroEmisor AND V.NumeroComprobante = VI.NumeroComprobante")

         .AppendLine(" LEFT JOIN Provincias PI ON VI.IdProvincia = PI.IdProvincia")

         'El IVA es por EMPRESA, no por SUCURSAL.
         '.AppendLine("  WHERE V.IdSucursal > 0")    ' & idSucursal.ToString())
         .AppendFormatLine("  WHERE S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("    AND TC.InformaLibroIva = 'True' ")
         '.AppendLine("    AND TC.AfectaCaja = 'True' ")    'EsComercial es verdadera referencia. En algunos lugares son facturas ficticias.
         '.AppendLine("    AND TC.EsComercial = 'True' ")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)

         .AppendLine("    AND YEAR(V.Fecha)*100+MONTH(V.Fecha) = " & periodoFiscal.ToString())

         If idVendedor > 0 Then
            .AppendFormat("	AND V.IdVendedor = {0}", idVendedor)
         End If

         If orden = "PROVINCIA" Then
            .AppendLine("	ORDER BY P.NombreProvincia")
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	,CONVERT(varchar(11), V.Fecha, 120)")
         ElseIf orden = "PROVINCIAIMPUESTO" Then
            .AppendLine("	ORDER BY PI.NombreProvincia")
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	,CONVERT(varchar(11), V.Fecha, 120)")
         Else
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	ORDER BY CONVERT(varchar(11), V.Fecha, 120) ")
         End If

         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,V.Letra")
         .AppendLine("	,V.CentroEmisor")
         .AppendLine("	,V.NumeroComprobante")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetLibroDinamicoDeIVA(idEmpresa As Integer, periodoFiscal As Integer, orden As String, idVendedor As Integer) As DataTable
      Dim nombreCampo As String
      nombreCampo = "'____' + CASE WHEN VI.IdTipoImpuesto = 'IVA' THEN VI.IdTipoImpuesto + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), VI.Alicuota), '.', '¿') ELSE VI.IdTipoImpuesto + '_' + TI.NombreTipoImpuesto END"
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT QUOTENAME({0}) campo", nombreCampo)
         .AppendLine("  FROM Impuestos VI")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
         .AppendLine(" WHERE (VI.IdTipoImpuesto <> 'IVA' OR VI.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")
         .AppendLine(" ORDER BY CASE WHEN VI.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, VI.IdTipoImpuesto, Alicuota")
      End With

      Dim campo_pivot = New StringBuilder()
      Dim campos_nuevo = New StringBuilder()
      Dim camposExistentes = New List(Of String)()

      Using dtCampos = GetDataTable(stb)
         For Each drCampos As DataRow In dtCampos.Rows
            If Not camposExistentes.Contains(drCampos("campo").ToString()) Then
               campo_pivot.AppendFormat("{0},", drCampos("campo"))

               campos_nuevo.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", drCampos("campo"))

               camposExistentes.Add(drCampos("campo").ToString())
            End If
         Next
      End Using

      stb = New StringBuilder()

      With stb
         .AppendLine("SELECT  Fecha")
         .AppendLine("	  ,IdTipoComprobante")
         .AppendLine("	  ,IdEstadoComprobante")
         .AppendLine("	  ,DescripcionAbrev")
         .AppendLine("	  ,Letra ")
         .AppendLine("	  ,CentroEmisor")
         .AppendLine("	  ,NumeroComprobante")
         .AppendLine("	  ,NombreCliente")
         .AppendLine("	  ,NombreCategoriaFiscal")
         .AppendLine("	  ,Cuit")
         .AppendLine("	  ,IdFormasPago")
         .AppendLine("	  ,Sum(ImporteBruto) as ImporteBruto")
         .AppendLine("	  ,Sum(Neto) as Neto")
         .AppendLine(campos_nuevo.ToString())
         .AppendLine("	  ,SUM(ISNULL(ImportePorPercepcion, 0)) As Percepciones")
         .AppendLine("	  ,Sum(NetoNoGravado) As NetoNoGravado")
         .AppendLine("	  ,Sum(Total) AS Total")
         .AppendLine("  FROM (")

         .AppendLine("SELECT ")
         If orden = "PROVINCIAIMPUESTO" Then
            .AppendLine("   PI.NombreProvincia")
         Else
            .AppendLine("   P.NombreProvincia")
         End If
         .AppendLine("	,CONVERT(date, V.Fecha) as Fecha")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("	,V.IdCliente ")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("  ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendLine("  ,V.IdEstadoComprobante")
         .AppendLine("  ,CASE WHEN C.CUIT IS NULL OR C.CUIT ='' THEN C.NroDocCliente ELSE C.CUIT END AS CUIT")
         .AppendLine("  ,V.IdFormasPago")
         .AppendLine("  ,VI.Bruto ImporteBruto")
         .AppendLine("  ,CASE WHEN VI.IdTipoImpuesto='IVA' AND VI.Alicuota<>0 THEN VI.Neto ELSE 0 END AS NETO")
         .AppendLine("  ,VI.IdTipoImpuesto")
         .AppendLine("  ,VI.Alicuota")
         .AppendLine("  ,VI.Importe")
         .AppendLine("  ,CASE WHEN TI.Tipo='PERCEPCION' THEN  VI.Total+VI.Importe ELSE VI.Total END AS TOTAL")
         .AppendLine("  ,CASE WHEN VI.IdTipoImpuesto='IVA' AND VI.Alicuota=0 THEN VI.Neto ELSE 0 END AS NetoNoGravado")
         '.AppendLine("  ,CASE WHEN VI.Alicuota=0 THEN VI.Bruto ELSE 0 END AS NetoNoGravado")
         If orden = "PROVINCIAIMPUESTO" Then
            .AppendLine("  ,PI.IdProvincia")
         Else
            .AppendLine("  ,P.IdProvincia")
         End If
         .AppendLine("  ,PI.IdProvincia IdProvinciaImpuesto")
         .AppendLine("  ,CASE WHEN TI.Tipo='PERCEPCION' THEN  VI.Importe ELSE 0 END AS ImportePorPercepcion")

         .AppendFormatLine("  ,{0} AS Impuesto_Importe", nombreCampo)

         .AppendLine("  FROM Ventas V")
         .AppendLine("  INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON L.IdProvincia = P.IdProvincia")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("  INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")

         .AppendLine(" LEFT JOIN VentasImpuestos VI ON V.IdSucursal = VI.IdSucursal AND V.IdTipoComprobante = VI.IdTipoComprobante ")
         .AppendLine("                             AND V.Letra = VI.Letra AND V.CentroEmisor = VI.CentroEmisor AND V.NumeroComprobante = VI.NumeroComprobante")

         .AppendLine("  INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")

         .AppendLine(" LEFT JOIN Provincias PI ON VI.IdProvincia = PI.IdProvincia")

         'El IVA es por EMPRESA, no por SUCURSAL.
         '.AppendLine("  WHERE V.IdSucursal > 0")
         .AppendFormatLine("  WHERE S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("    AND TC.InformaLibroIva = 'True' ")

         .AppendLine("    AND YEAR(V.Fecha)*100+MONTH(V.Fecha) = " & periodoFiscal.ToString())

         If idVendedor > 0 Then
            .AppendFormat("	AND V.IdVendedor = {0}", idVendedor)
         End If

         '' ''.AppendFormatLine("   AND V.NumeroComprobante = 3410")       'Habilitar solo si se desea hacer alguna prueba

         .AppendLine(" ) AS VI")

         .AppendFormatLine("PIVOT (SUM(Importe) FOR Impuesto_Importe IN ({0}))", campo_pivot.ToString().Trim(","c))

         .AppendLine("AS VIP")

         .AppendLine("	 GROUP BY NombreProvincia")
         .AppendLine("	,Fecha")
         .AppendLine("	 ,IdTipoComprobante")
         .AppendLine("	,DescripcionAbrev ")
         .AppendLine("	,Letra ")
         .AppendLine("	,CentroEmisor ")
         .AppendLine("	,NumeroComprobante ")
         .AppendLine("	,NombreCliente ")
         .AppendLine("	,NombreCategoriaFiscal")
         .AppendLine("	,Cuit")
         .AppendLine("	,IdFormasPago")
         .AppendLine("	,IdProvincia")
         .AppendLine("	,IdEstadoComprobante")

         If orden = "PROVINCIA" Then
            .AppendLine("	ORDER BY NombreProvincia")

            .AppendLine("	,CONVERT(varchar(11), Fecha, 120)")

         ElseIf orden = "PROVINCIAIMPUESTO" Then
            .AppendLine("	ORDER BY NombreProvincia")
            .AppendLine("	,CONVERT(varchar(11), Fecha, 120)")
         Else
            .AppendLine("	ORDER BY CONVERT(varchar(11), Fecha, 120) ")
         End If

         .AppendLine("	,IdTipoComprobante")
         .AppendLine("	,Letra")
         .AppendLine("	,CentroEmisor")
         .AppendLine("	,NumeroComprobante")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetLibroDeIVAUnificado(idEmpresa As Integer, periodoFiscal As Integer, orden As String, idVendedor As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT P.NombreProvincia")
         .AppendLine("	,V.Fecha")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("	,V.IdCliente ")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("  ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendLine("  ,V.IdEstadoComprobante")
         .AppendLine("  ,C.Cuit")
         .AppendLine("  ,V.IdFormasPago")
         .AppendLine("  FROM Ventas V")
         .AppendLine("  INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON L.IdProvincia = P.IdProvincia")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("  INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")

         .AppendLine(" LEFT JOIN VentasImpuestos VI ON V.IdSucursal = VI.IdSucursal AND V.IdTipoComprobante = VI.IdTipoComprobante ")
         .Append(" AND V.Letra = VI.Letra AND V.CentroEmisor = VI.CentroEmisor AND V.NumeroComprobante = VI.NumeroComprobante")

         'El IVA es por EMPRESA, no por SUCURSAL.
         '.AppendLine("  WHERE V.IdSucursal > 0")    ' & idSucursal.ToString())
         .AppendFormatLine("  WHERE S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("    AND TC.GrabaLibro = 'True' ")
         '.AppendLine("    AND TC.AfectaCaja = 'True' ")    'EsComercial es verdadera referencia. En algunos lugares son facturas ficticias.
         '.AppendLine("    AND TC.EsComercial = 'True' ")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)

         .AppendLine("    AND YEAR(V.Fecha)*100+MONTH(V.Fecha) = " & periodoFiscal.ToString())

         If idVendedor > 0 Then
            .AppendFormat("	AND V.IdVendedor = {0}", idVendedor)
         End If
         .AppendLine(" GROUP BY  P.NombreProvincia ,V.Fecha ,V.IdTipoComprobante ,TC.DescripcionAbrev ,V.Letra ,V.CentroEmisor ")
         .AppendLine(" ,V.NumeroComprobante ,V.IdVendedor ,V.IdCliente ,C.CodigoCliente ")
         .AppendLine(" ,C.NombreCliente  ,CF.NombreCategoriaFiscalAbrev  ,V.IdEstadoComprobante")
         .AppendLine("  ,C.Cuit ,V.IdFormasPago")

         If orden = "PROVINCIA" Then
            .AppendLine("	ORDER BY P.NombreProvincia")
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	,CONVERT(varchar(11), V.Fecha, 120)")
         Else
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	ORDER BY CONVERT(varchar(11), V.Fecha, 120) ")
         End If

         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,V.Letra")
         .AppendLine("	,V.CentroEmisor")
         .AppendLine("	,V.NumeroComprobante")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetExportacionVentasDetalle(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                               idProveedor As Long, idVendedor As Integer, idCliente As Long,
                                               grabaLibro As String, afectaCaja As String, ipoComprobante As String,
                                               discIVA As Boolean,
                                               listaComprobantes As List(Of Entidades.TipoComprobante)) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT V.Fecha ")

         .AppendLine("       ,V.IdSucursal")
         .AppendLine("       ,SUC.Nombre Sucursal")
         .AppendLine("       ,V.IdTipoComprobante")
         .AppendLine("       ,TC.DescripcionAbrev")
         .AppendLine("       ,V.Letra")
         .AppendLine("       ,V.CentroEmisor")
         .AppendLine("       ,V.NumeroComprobante")
         .AppendLine("       ,V.IdVendedor")
         .AppendLine("       ,E.NombreEmpleado")
         .AppendLine("       ,V.IdCliente")
         .AppendLine("       ,V.CotizacionDolar")
         .AppendLine("       ,C.CodigoCliente")
         .AppendLine("       ,C.NombreCliente")
         .AppendLine(" 	     ,C.Cuit")
         .AppendLine("	     ,TCL.NombreTipoCliente")
         .AppendLine("	     ,C.IdLocalidad")
         .AppendLine("	     ,PROV.NombreProvincia")
         .AppendLine("       ,VP.IdProducto")
         .AppendLine("   	  ,M.NombreMoneda")
         .AppendLine("       ,VP.NombreProducto")
         .AppendLine(" 	     ,PP.CodigoProductoProveedor")
         .AppendLine("       ,VP.Cantidad")
         .AppendLine("       ,VP.Precio")
         .AppendLine("   	  ,VP.PrecioLista")
         .AppendLine(" 	     ,VP.PrecioNeto")
         .AppendLine("   	  ,VP.Costo")
         .AppendLine("       ,VP.DescuentoRecargoProducto")

         .AppendFormat(" ,{0} as DescuentoRecargoProductoConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.DescuentoRecargoProducto", "VP.AlicuotaImpuesto",
                                                                    "VP.PorcImpuestoInterno", "CASE WHEN VP.PorcImpuestoInterno = 0 THEN 0 ELSE P.ImporteImpuestoInterno END",
                                                                    "VP.OrigenPorcImpInt"))
         .AppendLine("      ,VP.DescuentoRecargoPorc")
         .AppendLine("      ,VP.AlicuotaImpuesto")
         .AppendLine("      ,VP.ImporteImpuestoInterno")
         .AppendFormat(" ,{0} as PrecioConIva", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Precio", "VP.AlicuotaImpuesto",
                                                                       "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                       "VP.OrigenPorcImpInt"))

         .AppendFormat(" ,{0} as PrecioListaConIva", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.PrecioLista", "VP.AlicuotaImpuesto",
                                                                                "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                                "VP.OrigenPorcImpInt"))

         .AppendFormat(" ,{0} as PrecioNetoConIva", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.PrecioNeto", "VP.AlicuotaImpuesto",
                                                                              "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                              "VP.OrigenPorcImpInt"))
         If discIVA Then

            .AppendLine("      ,VP.Utilidad ")
            .AppendLine("      ,VP.ImporteTotalNeto")
            .AppendLine("      ,VP.ImporteImpuesto")
            .AppendLine("      ,VP.ImporteImpuestoInterno")

         Else
            .AppendLine("      ,VP.Utilidad+VP.ImporteImpuesto+VP.ImporteImpuestoInterno as Utilidad")
            .AppendLine("      ,VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno as ImporteTotalNeto")
            .AppendLine("      ,0 as ImporteImpuesto")
            .AppendLine("      ,0 AS ImporteImpuestoInterno")

         End If
         .AppendLine("      ,VP.ImporteTotalConImpuestos")

         .AppendLine("       ,P.NombreProducto As NombreActualProducto")
         .AppendLine("         ,TC1.TipoComprobantePDA ")
         .AppendLine("  FROM VentasProductos VP")
         .AppendLine("  INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal")
         .AppendLine(" 			AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine(" 			AND V.Letra = VP.Letra")
         .AppendLine(" 			AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine(" 			AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor")
         .AppendLine(" 	LEFT JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto AND P.IdProveedor = PP.IdProveedor")
         .AppendLine(" 	LEFT JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendLine("  INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria ")
         .AppendLine("  INNER JOIN Monedas M ON M.IdMoneda = P.IdMoneda")
         .AppendLine("  LEFT JOIN TiposComprobantesPDA TC1 ON TC1.IdTipoComprobante = V.IdTipoComprobante AND TC1.Letra = V.Letra")
         .AppendFormatLine("  LEFT JOIN TiposClientes TCL ON C.IdTipoCliente = TCL.IdTipoCliente")
         .AppendFormatLine("  LEFT JOIN Localidades LOC ON C.IdLocalidad = LOC.IdLocalidad")
         .AppendFormatLine("  LEFT JOIN Provincias PROV ON LOC.IdProvincia = PROV.IdProvincia")
         .AppendFormatLine("  LEFT JOIN Sucursales SUC ON VP.IdSucursal = SUC.IdSucursal")

         .AppendLine(" WHERE 1=1")

         .AppendLine(" AND V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine(" AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         Comunes.GetListaSucursalesMultiples(stb, sucursales, "V")

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
         If idProveedor > 0 Then
            .AppendFormat("      AND PR.IdProveedor = {0} ", idProveedor)
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

      Return GetDataTable(stb)
   End Function
End Class
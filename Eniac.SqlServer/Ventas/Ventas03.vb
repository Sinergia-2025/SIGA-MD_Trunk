Partial Class Ventas

   ''GET SECUNDARIOS

   Public Function GetInfComparativoDiario(sucursales As Entidades.Sucursal(),
                                           desde As Date, hasta As Date,
                                           idVendedor As Integer, idCliente As Long,
                                           idMarca As Integer, idRubro As Integer, idProducto As String, idZonaGeografica As String, idLocalidad As Integer,
                                           campoTotalizar As Entidades.Publicos.ComparativoDiario_CampoTotalizar,
                                           conIva As Boolean) As DataTable
      Dim campoTotalizarResuelto As String
      If campoTotalizar = Entidades.Publicos.ComparativoDiario_CampoTotalizar.CANTIDAD Then
         campoTotalizarResuelto = "VP.Cantidad"
      ElseIf campoTotalizar = Entidades.Publicos.ComparativoDiario_CampoTotalizar.IMPORTE Then
         If conIva Then
            campoTotalizarResuelto = "(VP.ImporteTotalNeto + VP.ImporteImpuesto + VP.ImporteImpuestoInterno)"
         Else
            campoTotalizarResuelto = "VP.ImporteTotalNeto"
         End If
      Else
         Throw New ArgumentException(String.Format("Campo a Totalizar ´{0}´ no definido.", campoTotalizar))
      End If
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT DISTINCT")
         .AppendLine("       QUOTENAME(CONVERT(VARCHAR(MAX), V.Fecha, 112) + '_cv') campos_cv")
         .AppendLine("     , QUOTENAME(CONVERT(VARCHAR(MAX), V.Fecha, 112) + '_cd') campos_cd")
         .AppendLine("     , QUOTENAME(CONVERT(VARCHAR(MAX), V.Fecha, 112) + '_c') campos_c")
         .AppendLine("  FROM VentasProductos VP")
         .AppendLine(" INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal")
         .AppendLine("                    AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine("                    AND V.Letra = VP.Letra ")
         .AppendLine("                    AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine("                    AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         ''''''''''''''''''''''''''''''''''''''''''''''''
         GetInfComparativoDiario_AddWhereClause(stb,
                                                sucursales,
                                                desde,
                                                hasta,
                                                idVendedor,
                                                idCliente,
                                                idMarca,
                                                idRubro,
                                                idProducto,
                                                idZonaGeografica,
                                                idLocalidad,
                                                campoTotalizar,
                                                conIva)
         ''''''''''''''''''''''''''''''''''''''''''''''''
      End With
      Dim dtCampos As DataTable = GetDataTable(stb)
      Dim existenDias As Boolean = dtCampos.Rows.Count > 0

      Dim campo_pivot_cv As StringBuilder = New StringBuilder()
      Dim campo_pivot_cd As StringBuilder = New StringBuilder()
      Dim campo_sum As StringBuilder = New StringBuilder()
      For Each drCampos As DataRow In dtCampos.Rows
         campo_pivot_cv.AppendFormat("{0},", drCampos("campos_cv"))
         campo_pivot_cd.AppendFormat("{0},", drCampos("campos_cd"))

         campo_sum.AppendFormat(", SUM({0}) {0} ,SUM({1}) {1} ,SUM({0}) - SUM({1}) {2}", drCampos("campos_cv"), drCampos("campos_cd"), drCampos("campos_c")).AppendLine()
      Next

      stb = New StringBuilder()
      With stb

         .AppendLine("SELECT CD1.IdVendedor")
         .AppendLine("     , CD1.NombreVendedor")
         .AppendLine("     , CD1.IdProducto")
         .AppendLine("     , CD1.NombreProducto")
         If existenDias Then
            .AppendFormat(campo_sum.ToString())
         End If
         '.AppendLine("     , SUM([20180410_cv]) [20180410_cv] ,SUM([20180410_cd]) [20180410_cd] ,SUM([20180410_cv]) - SUM([20180410_cd]) [20180410_c]")
         '.AppendLine("     , SUM([20180411_cv]) [20180411_cv] ,SUM([20180411_cd]) [20180411_cd] ,SUM([20180411_cv]) - SUM([20180411_cd]) [20180411_c]")
         '.AppendLine("     , SUM([20180412_cv]) [20180412_cv] ,SUM([20180412_cd]) [20180412_cd] ,SUM([20180412_cv]) - SUM([20180412_cd]) [20180412_c]")
         '.AppendLine("     , SUM([20180418_cv]) [20180418_cv] ,SUM([20180418_cd]) [20180418_cd] ,SUM([20180418_cv]) - SUM([20180418_cd]) [20180418_c]")
         '.AppendLine("     , SUM([20180423_cv]) [20180423_cv] ,SUM([20180423_cd]) [20180423_cd] ,SUM([20180423_cv]) - SUM([20180423_cd]) [20180423_c]")

         .AppendLine("  FROM (SELECT CONVERT(VARCHAR(MAX), V.Fecha, 112) + '_cv' Fecha_cv")
         .AppendLine("             , CONVERT(VARCHAR(MAX), V.Fecha, 112) + '_cd' Fecha_cd")
         .AppendLine("             , V.IdVendedor")
         .AppendLine("             , E.NombreEmpleado AS NombreVendedor")
         .AppendLine("             , VP.IdProducto")
         .AppendLine("             , VP.NombreProducto")
         .AppendFormat("             , CASE WHEN VP.Cantidad > 0 THEN {0} ELSE 0 END CantidadVenta", campoTotalizarResuelto).AppendLine()
         .AppendFormat("             , CASE WHEN VP.Cantidad < 0 THEN {0} * -1 ELSE 0 END CantidadDevuelta", campoTotalizarResuelto).AppendLine()
         .AppendLine("          FROM VentasProductos VP")
         .AppendLine("         INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal")
         .AppendLine("                            AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine("                            AND V.Letra = VP.Letra ")
         .AppendLine("                            AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine("                            AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendLine("         INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine("         INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine("         INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendLine("         INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         ''''''''''''''''''''''''''''''''''''''''''''''''
         GetInfComparativoDiario_AddWhereClause(stb,
                                                sucursales,
                                                desde, hasta,
                                                idVendedor, idCliente,
                                                idMarca, idRubro, idProducto, idZonaGeografica, idLocalidad,
                                                campoTotalizar,
                                                conIva)
         ''''''''''''''''''''''''''''''''''''''''''''''''
         If existenDias Then
            .AppendLine("        ) V")
         Else
            .AppendLine(" ) AS cd1")
         End If

         If existenDias Then
            .AppendLine("PIVOT (")
            .AppendFormat("   SUM(CantidadVenta) FOR Fecha_cv IN ({0})", campo_pivot_cv.ToString().Trim(","c)).AppendLine()
            '.AppendLine("   SUM(CantidadVenta) FOR Fecha_cv IN ([20180410_cv],[20180411_cv],[20180412_cv],[20180418_cv],[20180423_cv])")

            .AppendLine(" ) AS cv1")
            .AppendLine("PIVOT (")
            .AppendFormat("   SUM(CantidadDevuelta) FOR Fecha_cd IN ({0})", campo_pivot_cd.ToString().Trim(","c)).AppendLine()
            '.AppendLine("   SUM(CantidadDevuelta) FOR Fecha_cd IN ([20180410_cd],[20180411_cd],[20180412_cd],[20180418_cd],[20180423_cd])")
            .AppendLine(" ) AS cd1")
         End If

         .AppendLine("GROUP BY CD1.IdVendedor")
         .AppendLine("       , CD1.NombreVendedor")
         .AppendLine("       , CD1.IdProducto")
         .AppendLine("       , CD1.NombreProducto")

      End With

      Return GetDataTable(stb)

   End Function
   Private Sub GetInfComparativoDiario_AddWhereClause(stb As StringBuilder,
                                                      sucursales As Entidades.Sucursal(),
                                                      desde As Date, hasta As Date,
                                                      idVendedor As Integer, idCliente As Long,
                                                      idMarca As Integer, idRubro As Integer, idProducto As String, idZonaGeografica As String, idLocalidad As Integer,
                                                      campoTotalizar As Entidades.Publicos.ComparativoDiario_CampoTotalizar,
                                                      conIva As Boolean)
      With stb
         .AppendLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "V")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")

         .AppendFormat("   AND V.Fecha >= '{0}'", ObtenerFecha(desde, False)).AppendLine()
         .AppendFormat("   AND V.Fecha <= '{0}'", ObtenerFecha(hasta.Date.AddDays(1).AddSeconds(-1), True)).AppendLine()

         If idVendedor > 0 Then
            .AppendFormat("	AND V.IdVendedor = {0}", idVendedor).AppendLine()
         End If

         If idCliente <> 0 Then
            .AppendFormat("	AND V.IdCliente = {0}", idCliente).AppendLine()
         End If

         If idMarca > 0 Then
            .AppendFormat("   AND P.IdMarca = {0}", idMarca).AppendLine()
         End If

         If idRubro > 0 Then
            .AppendFormat("   AND P.IdRubro = {0}", idRubro).AppendLine()
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat("	AND VP.IdProducto = '{0}'", idProducto).AppendLine()
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica).AppendLine()
         End If

         If idLocalidad > 0 Then
            .AppendFormat(" AND C.IdLocalidad = {0}", idLocalidad).AppendLine()
         End If
      End With

   End Sub

   Public Function ClienteDeComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("  FROM Ventas AS V")
         .AppendLine("  LEFT JOIN Clientes AS C ON C.IdCliente = V.IdCliente")
         .AppendFormat(" WHERE V.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND V.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND V.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND V.NumeroComprobante = {0}", numeroComprobante).AppendLine()
         .AppendFormat("   AND V.idSucursal = {0}", idSucursal).AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetComprobantesElectronicos(estado As Entidades.AFIPCAE.EstadoElectronicos,
                                               fechaDesde As Date, fechaHasta As Date,
                                               idCliente As Long,
                                               numeroRepartoDesde As Integer, numeroRepartoHasta As Integer,
                                               tipoComprobantes As Entidades.TipoComprobante(), letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                               idCategoria As Integer, idUsuario As String, IdVendedor As Integer, idFormasPago As Integer,
                                               idEmpresa As Integer, idSucursal As Integer,
                                               nroRepartoInvocacionMasiva As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdSucursal")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev")
         .AppendLine("      ,V.Letra")
         .AppendLine("      ,V.CentroEmisor")
         .AppendLine("      ,V.NumeroComprobante")
         .AppendLine("      ,V.Fecha")
         .AppendLine("      ,V.IdVendedor")
         .AppendLine("      ,V.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,V.CUIT")
         .AppendLine("      ,V.TipoDocCliente")
         .AppendLine("      ,V.NroDocCliente")
         .AppendLine("      ,V.NombreCliente")
         .AppendLine("      ,V.IdCategoriaFiscal")
         .AppendLine("      ,CF.NombreCategoriaFiscal")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago as FormaDePago")

         .AppendLine("      ,V.IdEstadoComprobante")
         .AppendLine("      ,V.Observacion")

         .AppendLine("      ,V.ImporteBruto")
         .AppendLine("      ,V.DescuentoRecargoPorc")
         .AppendLine("      ,V.DescuentoRecargo")
         .AppendLine("      ,V.SubTotal")
         .AppendLine("      ,V.TotalImpuestos")
         .AppendLine("      ,V.TotalImpuestoInterno")

         .AppendLine("      ,ISNULL((SELECT SUM(VI.Importe) AS Importe")
         .AppendLine("          FROM VentasImpuestos VI")
         .AppendLine("         INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
         .AppendLine("         WHERE VI.IdSucursal = V.IdSucursal AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("           AND VI.Letra = V.Letra AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("           AND VI.NumeroComprobante = V.NumeroComprobante AND TI.Tipo = 'PERCEPCION'), 0) AS TotalPercepcion")

         .AppendLine("      ,ISNULL((SELECT SUM(VI.Importe) AS Importe")
         .AppendLine("          FROM VentasImpuestos VI")
         .AppendLine("         INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
         .AppendLine("         WHERE VI.IdSucursal = V.IdSucursal AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("           AND VI.Letra = V.Letra AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("           AND VI.NumeroComprobante = V.NumeroComprobante AND TI.Tipo = 'IVA'), 0) AS TotalIVA")

         .AppendLine("      ,V.ImporteTotal")
         .AppendLine("      ,V.CAE")
         .AppendLine("      ,V.CAEVencimiento")
         ''.AppendLine("      ,V.IdTipoComprobanteFact")
         ''.AppendLine("      ,V.LetraFact")
         ''.AppendLine("      ,V.CentroEmisorFact")
         ''.AppendLine("      ,V.NumeroComprobanteFact")
         .AppendLine("      ,V.NumeroPlanilla")
         .AppendLine("      ,V.NumeroMovimiento")
         .AppendLine("      ,V.ImportePesos")
         .AppendLine("      ,V.ImporteTickets")
         .AppendLine("      ,V.ImporteTarjetas")
         .AppendLine("      ,V.ImporteCheques")
         .AppendLine("      ,V.Kilos")
         .AppendLine("      ,V.Bultos")
         .AppendLine("      ,V.ValorDeclarado")
         .AppendLine("      ,V.IdTransportista")
         .AppendLine("      ,V.NumeroLote")
         .AppendLine("      ,V.CantidadInvocados")
         .AppendLine("      ,V.CantidadLotes")
         .AppendLine("      ,V.Usuario")
         .AppendLine("      ,V.FechaAlta")
         .AppendLine("      ,V.CodigoErrorAfip")
         .AppendLine("      ,E.NombreEmpleado AS NombreVendedor")

         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine("  LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")

         .AppendLine(" WHERE TC.EsElectronico = 'True'")
         .AppendFormatLine("   AND V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND S.IdEmpresa = {0}", idEmpresa)
         .AppendLine(" AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO')")

         Select Case estado
            Case Entidades.AFIPCAE.EstadoElectronicos.ConCAE
               .AppendLine(" AND V.CAE is not Null")
            Case Entidades.AFIPCAE.EstadoElectronicos.SinCAE
               .AppendLine(" AND V.CAE is Null")
            Case Entidades.AFIPCAE.EstadoElectronicos.Todos
         End Select

         GetListaTiposComprobantesMultiples(stb, tipoComprobantes, "V")
         'If Not String.IsNullOrEmpty(idTipoComprobante) Then
         '   .AppendFormat(" AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         'End If

         If fechaDesde <> Nothing Then
            .AppendFormat(" AND V.Fecha >= '{0} 00:00:00' AND V.Fecha <= '{1} 23:59:59'", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))
         End If

         If idCliente > 0 Then
            .AppendLine("	AND V.IdCliente = " & idCliente.ToString())
         End If
         If nroRepartoInvocacionMasiva > 0 Then
            .AppendFormat(" AND V.NroRepartoInvocacionMasiva = " & nroRepartoInvocacionMasiva.ToString())
         Else
            If numeroRepartoDesde > 0 Then
               .AppendFormat(" AND V.NumeroReparto >= " & numeroRepartoDesde.ToString())
               .AppendFormat(" AND V.NumeroReparto <= " & numeroRepartoHasta.ToString())
            End If
         End If

         If IdVendedor > 0 Then
            .AppendLine("	 AND V.IdVendedor = " & IdVendedor)
         End If

         If letraFiscal <> "" Then
            .AppendLine("	 AND V.Letra = '" & letraFiscal.ToString() & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("	 AND V.CentroEmisor = " & centroEmisor.ToString())
         End If

         If numeroComprobante > 0 Then
            .AppendLine("	 AND V.NumeroComprobante = " & numeroComprobante.ToString())
         End If

         If idFormasPago > 0 Then
            .AppendLine("	 AND V.IdFormasPago = " & idFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & idUsuario & "'")
         End If

         If idCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & idCategoria.ToString())
         End If

         .AppendLine("   ORDER BY V.Fecha")

      End With

      Return GetDataTable(stb)

   End Function
   Public Function GetComprobantesFiscales(estado As Entidades.AFIPCAE.EstadoElectronicos,
                                           fechaDesde As Date, fechaHasta As Date,
                                           idCliente As Long,
                                           numeroRepartoDesde As Integer, numeroRepartoHasta As Integer,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                           idCategoria As Integer, idUsuario As String, IdVendedor As Integer, idFormasPago As Integer,
                                           idEmpresa As Integer, idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdSucursal")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev")
         .AppendLine("      ,V.Letra")
         .AppendLine("      ,V.CentroEmisor")
         .AppendLine("      ,V.NumeroComprobante")
         .AppendLine("      ,V.Fecha")
         .AppendLine("      ,V.IdVendedor")
         .AppendLine("      ,V.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,V.CUIT")
         .AppendLine("      ,V.TipoDocCliente")
         .AppendLine("      ,V.NroDocCliente")
         .AppendLine("      ,V.NombreCliente")
         .AppendLine("      ,V.IdCategoriaFiscal")
         .AppendLine("      ,CF.NombreCategoriaFiscal")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago as FormaDePago")

         .AppendLine("      ,V.IdEstadoComprobante")
         .AppendLine("      ,V.Observacion")

         .AppendLine("      ,V.ImporteBruto")
         .AppendLine("      ,V.DescuentoRecargoPorc")
         .AppendLine("      ,V.DescuentoRecargo")
         .AppendLine("      ,V.SubTotal")
         .AppendLine("      ,V.TotalImpuestos")
         .AppendLine("      ,V.TotalImpuestoInterno")

         .AppendLine("      ,ISNULL((SELECT SUM(VI.Importe) AS Importe")
         .AppendLine("          FROM VentasImpuestos VI")
         .AppendLine("         INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
         .AppendLine("         WHERE VI.IdSucursal = V.IdSucursal AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("           AND VI.Letra = V.Letra AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("           AND VI.NumeroComprobante = V.NumeroComprobante AND TI.Tipo = 'PERCEPCION'), 0) AS TotalPercepcion")

         .AppendLine("      ,ISNULL((SELECT SUM(VI.Importe) AS Importe")
         .AppendLine("          FROM VentasImpuestos VI")
         .AppendLine("         INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
         .AppendLine("         WHERE VI.IdSucursal = V.IdSucursal AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("           AND VI.Letra = V.Letra AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("           AND VI.NumeroComprobante = V.NumeroComprobante AND TI.Tipo = 'IVA'), 0) AS TotalIVA")

         .AppendLine("      ,V.ImporteTotal")
         .AppendLine("      ,V.CAE")
         .AppendLine("      ,V.CAEVencimiento")
         ''.AppendLine("      ,V.IdTipoComprobanteFact")
         ''.AppendLine("      ,V.LetraFact")
         ''.AppendLine("      ,V.CentroEmisorFact")
         ''.AppendLine("      ,V.NumeroComprobanteFact")
         .AppendLine("      ,V.NumeroPlanilla")
         .AppendLine("      ,V.NumeroMovimiento")
         .AppendLine("      ,V.ImportePesos")
         .AppendLine("      ,V.ImporteTickets")
         .AppendLine("      ,V.ImporteTarjetas")
         .AppendLine("      ,V.ImporteCheques")
         .AppendLine("      ,V.Kilos")
         .AppendLine("      ,V.Bultos")
         .AppendLine("      ,V.ValorDeclarado")
         .AppendLine("      ,V.IdTransportista")
         .AppendLine("      ,V.NumeroLote")
         .AppendLine("      ,V.CantidadInvocados")
         .AppendLine("      ,V.CantidadLotes")
         .AppendLine("      ,V.Usuario")
         .AppendLine("      ,V.FechaAlta")
         .AppendLine("      ,V.CodigoErrorAfip")
         .AppendLine("      ,E.NombreEmpleado AS NombreVendedor")
         .AppendLine("      ,V.NumeroComprobanteFiscal")
         .AppendLine("      ,V.CantidadReintentosImpresion")
         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine("  LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")

         .AppendLine(" WHERE TC.EsFiscal = 'True' AND TC.EsPreElectronico = 'True'")
         .AppendFormatLine("   AND V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND S.IdEmpresa = {0}", idEmpresa)
         .AppendLine(" AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO')")

         'Select Case estado
         '   Case Entidades.AFIPCAE.EstadoElectronicos.ConCAE
         '      .AppendLine(" AND V.CAE is not Null")
         '   Case Entidades.AFIPCAE.EstadoElectronicos.SinCAE
         '      .AppendLine(" AND V.CAE is Null")
         '   Case Entidades.AFIPCAE.EstadoElectronicos.Todos
         'End Select

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormat(" AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If fechaDesde <> Nothing Then
            .AppendFormat(" AND V.Fecha >= '{0} 00:00:00' AND V.Fecha <= '{1} 23:59:59'", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))
         End If

         If idCliente > 0 Then
            .AppendLine("	AND V.IdCliente = " & idCliente.ToString())
         End If

         If numeroRepartoDesde > 0 Then
            .AppendFormat(" AND V.NumeroReparto >= " & numeroRepartoDesde.ToString())
            .AppendFormat(" AND V.NumeroReparto <= " & numeroRepartoHasta.ToString())
         End If

         If IdVendedor > 0 Then
            .AppendLine("	 AND V.IdVendedor = " & IdVendedor)
         End If

         If letraFiscal <> "" Then
            .AppendLine("	 AND V.Letra = '" & letraFiscal.ToString() & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("	 AND V.CentroEmisor = " & centroEmisor.ToString())
         End If

         If numeroComprobante > 0 Then
            .AppendLine("	 AND V.NumeroComprobante = " & numeroComprobante.ToString())
         End If

         If idFormasPago > 0 Then
            .AppendLine("	 AND V.IdFormasPago = " & idFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & idUsuario & "'")
         End If

         If idCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & idCategoria.ToString())
         End If

         .AppendLine("   ORDER BY V.Fecha")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetNoCompradores(
                     desde As Date,
                     idCliente As Long, idVendedor As Integer,
                     idZonaGeografica As String, idCategoria As Integer,
                     idMarca As Integer, idRubro As Integer,
                     idLocalidad As Integer, idProvincia As String, idRuta As Integer,
                     activo As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT C.IdCliente")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , CT.NombreCategoria")
         .AppendLine("     , V.NombreEmpleado")
         .AppendLine("     , ZG.NombreZonaGeografica")
         .AppendLine("     , C.IdLocalidad")
         .AppendLine("     , L.NombreLocalidad")
         .AppendLine("     , P.NombreProvincia")
         .AppendLine("     , (SELECT MAX(Fecha) AS FechaVenta")
         .AppendLine("          FROM Ventas V")
         .AppendLine("         WHERE C.IdCliente = V.IdCliente) as FechaUltimaCompra")
         .AppendLine("  FROM Clientes C ")
         .AppendLine("  LEFT JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendLine("  LEFT JOIN Empleados V ON V.IdEmpleado = C.IdVendedor ")
         .AppendLine("  LEFT JOIN Categorias CT ON CT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine(" WHERE NOT EXISTS (SELECT V.Fecha")
         .AppendLine("                     FROM Ventas V")
         .AppendLine("                     LEFT JOIN VentasProductos VP")
         .AppendLine("                            ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("                           AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                           AND VP.Letra = V.Letra")
         .AppendLine("                           AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("                           AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("                     LEFT JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine("                    WHERE C.IdCliente = V.IdCliente")

         .AppendFormatLine("	                    AND V.Fecha >= '{0}'", ObtenerFecha(desde, False))
         If idMarca > 0 Then
            .AppendFormatLine("                      AND P.IdMarca = {0}", idMarca)
         End If
         If idRubro > 0 Then
            .AppendFormatLine("                      AND P.IdRubro = {0}", idRubro)
         End If
         .AppendLine("                  )")

         If idRuta > 0 Then
            .AppendFormatLine("  AND EXISTS (SELECT MRC.IdCliente")
            .AppendFormatLine("                FROM MovilRutasClientes MRC")
            .AppendFormatLine("               WHERE MRC.IdRuta = {0}", idRuta)
            .AppendFormatLine("                 AND MRC.IdCliente = C.IdCliente)")
         End If
         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If
         If idVendedor > 0 Then
            .AppendFormatLine("   AND C.IdVendedor = {0}", idVendedor)
         End If
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If idCategoria > 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If
         If idLocalidad > 0 Then
            .AppendFormatLine("   AND C.IdLocalidad = {0}", idLocalidad)
         End If
         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendFormatLine("   AND L.IdProvincia = '{0}'", idProvincia)
         End If
         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendLine(" ORDER BY FechaUltimaCompra")  ''V.NombreEmpleado, FechaUltimaCompra
      End With

      Return GetDataTable(stb)

   End Function

   Public Function Emisor(idSucursal As Integer, centroEmisor As Short) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT IdSucursal FROM Ventas ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
      End With
      Return GetDataTable(stb).Count > 0
   End Function

   Public Function GetProductosAlertaPorCaja(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,VP.IdProducto")
         .AppendLine("      ,VP.NombreProducto")
         .AppendLine("      ,P.Tamano")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,SUM(VP.Cantidad) AS Cantidad")
         .AppendLine("      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotalNeto")
         .AppendLine("      ,SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotal")
         .AppendLine("      ,SUM(VP.Kilos) AS Kilos")
         .AppendLine("      ,PS.Stock")

         .AppendLine("  FROM Ventas V, VentasProductos VP, TiposComprobantes TC,")
         .AppendLine("       Productos P, Marcas M, Rubros R, Clientes C, ProductosSucursales PS")

         .AppendLine(" WHERE V.IdSucursal = VP.IdSucursal")
         .AppendLine("   AND V.IdTipoComprobante=VP.IdTipoComprobante")
         .AppendLine("   AND V.Letra=VP.Letra")
         .AppendLine("   AND V.CentroEmisor=VP.CentroEmisor")
         .AppendLine("   AND V.NumeroComprobante=VP.NumeroComprobante")
         .AppendLine("   AND V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("   AND VP.IdProducto = P.IdProducto")
         .AppendLine("   AND VP.IdProducto = PS.IdProducto")
         .AppendLine("   AND VP.IdSucursal = PS.IdSucursal")
         .AppendLine("   AND P.IdMarca = M.IdMarca")
         .AppendLine("   AND P.IdRubro = R.IdRubro")
         .AppendLine("   AND V.IdCliente = C.IdCliente")
         .AppendLine("   AND P.AlertaDeCaja = 'True'")
         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         .AppendLine("   AND V.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.IdCaja = " & idCaja.ToString())
         .AppendLine("   AND V.NumeroPlanilla = " & numeroPlanilla.ToString())

         .AppendLine(" GROUP BY M.NombreMarca, R.NombreRubro, VP.IdProducto, VP.NombreProducto, P.Tamano, P.IdUnidadDeMedida, PS.Stock")
         .AppendLine(" ORDER BY VP.NombreProducto")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetComprobantesSinCAE(idSucursal As Integer, desde As Date, hasta As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.Fecha")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,TCF.IdTipoComprobanteFiscal")
         .AppendLine("      ,TC.DescripcionAbrev AS Descripcion")
         .AppendLine("      ,V.Letra")
         .AppendLine("      ,V.CentroEmisor")
         .AppendLine("      ,V.NumeroComprobante")
         .AppendLine("      ,TD.IdTipoDocumentoFiscal")
         .AppendLine("      ,V.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,V.IdEstadoComprobante")
         .AppendLine("      ,V.ImporteTotal")
         .AppendLine("      ,0 AS ImporteExento")
         .AppendLine("      ,0 AS ImportePercepcion")
         .AppendLine("      ,V.SubTotal AS ImporteNeto")
         .AppendLine("      ,V.TotalImpuestos AS IVA")
         .AppendLine("      ,V.TotalImpuestoInterno as IMPINT")
         .AppendLine(" FROM Ventas V, TiposComprobantes TC, TiposComprobantesFiscales TCF, Clientes C, TiposDocumento TD")
         .AppendLine(" WHERE V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("   AND V.IdTipoComprobante = TCF.IdTipoComprobante")
         .AppendLine("   AND V.Letra = TCF.Letra")
         .AppendLine("   AND V.IdCliente = C.IdCliente")
         .AppendLine("   AND C.TipoDocCliente = TD.TipoDocumento")
         .AppendLine("   AND TC.GrabaLibro = 'True'")

         .AppendFormatLine("	 AND V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("	 AND V.fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("	 AND V.fecha <= '{0}'", ObtenerFecha(hasta, True))

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.AppendLine("	,V.IdTipoComprobante")
         '.AppendLine("	,V.Letra")
         '.AppendLine("	,V.CentroEmisor")
         '.AppendLine("	,V.NumeroComprobante")

         .AppendLine("	ORDER BY V.Fecha")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetVentasCobranzasMensuales(sucursales As IEnumerable(Of Entidades.Sucursal),
                                               fechaDesde As Date, fechaHasta As Date, idCliente As Long,
                                               idCategoria As Integer, origenCategoria As Entidades.OrigenFK,
                                               idVendedor As Long, origenVendedor As Entidades.OrigenFK,
                                               idUsuario As String, idZonaGeografica As String, grabaLibro As Entidades.Publicos.SiNoTodos) As DataTable
      Dim fechaCorte = fechaHasta.Date.AddMonths(-12).AddDays(1)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT AnoFecha, MesFecha")
         .AppendFormatLine("     , SUM(Contado) Contado,                 SUM(CtaCte) CtaCte,                 SUM(Cobros) Cobros")
         .AppendFormatLine("     , SUM(Cobros) / NULLIF( SUM(CtaCte) , 0) * 100 PorcCobro")
         .AppendFormatLine("     , SUM(ContadoAnterior) ContadoAnterior, SUM(CtaCteAnterior) CtaCteAnterior, SUM(CobrosAnterior) CobrosAnterior")
         .AppendFormatLine("     , SUM(CobrosAnterior) / NULLIF( SUM(CtaCteAnterior) , 0) * 100 PorcCobroAnterior")
         .AppendFormatLine("     , ((SUM(Contado) / NULLIF( SUM(ContadoAnterior), 0)) - 1) * 100 ContadoPorc")
         .AppendFormatLine("     , ((SUM(CtaCte)  / NULLIF( SUM(CtaCteAnterior),  0)) - 1) * 100 CtaCtePorc")
         .AppendFormatLine("     , ((SUM(Cobros)  / NULLIF( SUM(CobrosAnterior),  0)) - 1) * 100 CobrosPorc")
         .AppendFormatLine("    FROM (")
         .AppendFormatLine("        SELECT YEAR(V.Fecha) + CASE WHEN V.Fecha < '{0}' THEN 1 ELSE 0 END AnoFecha", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , MONTH(V.Fecha) MesFecha")
         .AppendFormatLine("                , CASE WHEN V.Fecha > '{0}' THEN CASE WHEN FP.Dias = 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END Contado", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , CASE WHEN V.Fecha > '{0}' THEN CASE WHEN FP.Dias > 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END CtaCte", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , 0 Cobros")
         .AppendFormatLine("                , CASE WHEN V.Fecha < '{0}' THEN CASE WHEN FP.Dias = 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END ContadoAnterior", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , CASE WHEN V.Fecha < '{0}' THEN CASE WHEN FP.Dias > 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END CtaCteAnterior", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , 0 CobrosAnterior")
         .AppendFormatLine("            FROM Ventas V")
         .AppendFormatLine("            INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")

         .AppendFormatLine("            INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine("            INNER JOIN Categorias CAT ON CAT.IdCategoria = {0}.IdCategoria", If(origenCategoria = Entidades.OrigenFK.Actual, "C", "V"))
         .AppendFormatLine("            INNER JOIN Empleados E ON E.IdEmpleado = {0}.IdVendedor", If(origenVendedor = Entidades.OrigenFK.Actual, "C", "V"))

         .AppendFormatLine("            INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = V.IdFormasPago")
         .AppendFormatLine("            WHERE V.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))

         GetListaSucursalesMultiples(stb, sucursales, "V")

         If idCliente <> 0 Then
            .AppendFormatLine("              AND V.IdCliente = {0}", idCliente)
         End If
         If idCategoria <> 0 Then
            .AppendFormatLine("              AND CAT.IdCategoria = {0}", idCategoria)
         End If
         If idVendedor <> 0 Then
            .AppendFormatLine("              AND E.IdEmpleado = {0}", idVendedor)
         End If
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("              AND V.Usuario = '{0}'", idUsuario)
         End If
         If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
            .AppendFormatLine("              AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("              AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendFormatLine("              AND TC.EsComercial = 'True'")
         .AppendFormatLine("            UNION ALL")
         .AppendFormatLine("        SELECT YEAR(CC.Fecha) + CASE WHEN CC.Fecha < '{0}' THEN 1 ELSE 0 END AnoFecha", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , MONTH(CC.Fecha) MesFecha")
         .AppendFormatLine("                , 0 Contado")
         .AppendFormatLine("                , 0 CtaCte")
         .AppendFormatLine("                , CASE WHEN CC.Fecha > '{0}' THEN CC.ImporteTotal * - 1 ELSE 0 END Cobros", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , 0 ContadoAnterior")
         .AppendFormatLine("                , 0 CtaCteAnterior")
         .AppendFormatLine("                , CASE WHEN CC.Fecha < '{0}' THEN CC.ImporteTotal * - 1 ELSE 0 END CobrosAnterior", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("            FROM CuentasCorrientes CC")
         .AppendFormatLine("            INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")

         .AppendFormatLine("            INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendFormatLine("            INNER JOIN Categorias CAT ON CAT.IdCategoria = {0}.IdCategoria", If(origenCategoria = Entidades.OrigenFK.Actual, "C", "CC"))
         .AppendFormatLine("            INNER JOIN Empleados E ON E.IdEmpleado = {0}.IdVendedor", If(origenVendedor = Entidades.OrigenFK.Actual, "C", "CC"))

         .AppendFormatLine("            WHERE CC.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))

         GetListaSucursalesMultiples(stb, sucursales, "CC")

         If idCliente <> 0 Then
            .AppendFormatLine("              AND CC.IdCliente = {0}", idCliente)
         End If
         If idCategoria <> 0 Then
            .AppendFormatLine("              AND CAT.IdCategoria = {0}", idCategoria)
         End If
         If idVendedor <> 0 Then
            .AppendFormatLine("              AND E.IdEmpleado = {0}", idVendedor)
         End If
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("              AND CC.IdUsuario = '{0}'", idUsuario)
         End If
         If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
            .AppendFormatLine("              AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("              AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendFormatLine("              AND TC.EsRecibo = 'True' AND TC.EsAnticipo = 'False'")
         .AppendFormatLine("              AND TC.ImporteTope <> 0 AND TC.ImporteMinimo <> 0")
         .AppendFormatLine("        ) V")
         .AppendFormatLine("    GROUP BY AnoFecha, MesFecha")
         .AppendFormatLine("    ORDER BY AnoFecha DESC, MesFecha DESC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetUltimosNumerosComprobantes(idSucursal As Integer, tipo As String, anularComprobantesSinEmitir As Boolean,
                                                 reciboComparteNumeracionEntreSucursales As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT VN.IdTipoComprobante")
         .AppendLine("       ,TC.Descripcion AS TipoComprobante")
         .AppendLine("       ,VN.LetraFiscal")
         .AppendLine("       ,VN.CentroEmisor")
         .AppendLine("       ,VN.Numero")
         .AppendLine("       ,VN.Fecha")
         .AppendLine("       ,VN.IdTipoComprobanteRelacionado")
         .AppendLine("       ,CASE WHEN VN.IdSucursal = 0 THEN 1 ELSE 0 END AS ComparteEntreSucursales")
         .AppendLine("       ,TC.EsRecibo")
         .AppendLine(" FROM VentasNumeros VN")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VN.IdTipoComprobante")
         .AppendFormat(" WHERE (VN.IdSucursal = {0}", idSucursal)
         If reciboComparteNumeracionEntreSucursales AndAlso tipo = "CTACTECLIE" Then
            .Append(" OR VN.IdSucursal = 0")
         End If
         .AppendLine(")")
         If tipo <> "TODOS" Then
            .AppendFormatLine(" AND TC.Tipo = '{0}'", tipo)
         End If
         'GAR: 16/11/2016 - Se anula para que el usuario tenga todos los numerados. Si Necesita ajustarlo sera por una emergencia.
         '.AppendLine(" AND TC.EsElectronico <> 1")

         If anularComprobantesSinEmitir Then
            .AppendLine(" AND TC.EsElectronico = 'False'")
            .AppendLine(" AND TC.EsFiscal = 0")
         End If
      End With

      Return GetDataTable(stb)
   End Function
End Class
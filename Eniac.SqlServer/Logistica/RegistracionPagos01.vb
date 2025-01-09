Option Strict On
Option Explicit On
Option Infer On
Partial Class RegistracionPagos
   Public Function GetComprobantesRegPagoV2(idSucursal As Integer, numeroReparto As Integer, modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                fechaDesde As DateTime?, fechaHasta As DateTime?,
                                idDistribucion As Integer, idLocalidad As Integer, idEmpleado As Integer,
                                idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Return Me.GetDataTable(QueryGetComprobantesRegPagoV2(idSucursal, numeroReparto, modoConsultarComprobantes,
                                                           fechaDesde, fechaHasta,
                                                           idDistribucion, idLocalidad, idEmpleado,
                                                           idRuta, dia,
                                                           incluirOrden:=True))
   End Function

   Public Function GetProductosComprobantesRegPagoV2(idSucursal As Integer, numeroReparto As Integer, modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                         fechaDesde As DateTime?, fechaHasta As DateTime?,
                                         idDistribucion As Integer, idLocalidad As Integer, idEmpleado As Integer,
                                         idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT V.IdSucursal, V.IdTipoComprobante, ")
         .AppendFormatLine("       V.Letra, ")
         .AppendFormatLine("       V.CentroEmisor,")
         .AppendFormatLine("       V.NumeroComprobante,")
         .AppendFormatLine("       V.NumeroReparto,")
         .AppendFormatLine("       VP.IdProducto, P.NombreProducto, VP.Cantidad, CONVERT(DECIMAL(14,2), {0}) AS ImporteTotal, VP.Orden, CONVERT(DECIMAL(14,2), {1}) AS Precio, VP.AlicuotaImpuesto AS AlicuotaIVA",
                           CalculosImpositivos.ObtenerPrecioConImpuestos("VP.ImporteTotal", "VP.AlicuotaImpuesto",
                                                                         "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                         "VP.OrigenPorcImpInt"),
                           CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Precio", "VP.AlicuotaImpuesto",
                                                                         "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                         "VP.OrigenPorcImpInt"))
         .AppendFormatLine("      ,VP.IdListaPrecios")
         .AppendFormatLine("      ,VP.PorcImpuestoInterno")
         .AppendFormatLine("      ,VP.OrigenPorcImpInt")
         .AppendFormatLine("      ,VP.TipoOperacion")
         .AppendFormatLine("      ,VP.DescuentoRecargoPorc AS DescuentoRecargoPorc1")
         .AppendFormatLine("      ,VP.DescuentoRecargoPorc2")
         .AppendFormatLine("      ,VP.Nota")
         .AppendFormatLine("  FROM ({0}) V", QueryGetComprobantesRegPagoV2(idSucursal, numeroReparto, modoConsultarComprobantes,
                                                               fechaDesde, fechaHasta,
                                                               idDistribucion, idLocalidad, idEmpleado,
                                                               idRuta, dia,
                                                               incluirOrden:=False))
         .AppendFormatLine(" INNER JOIN VentasProductos VP ON VP.IdSucursal = V.IdSucursal")
         .AppendFormatLine("                              AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("                              AND VP.CentroEmisor = V.CentroEmisor")
         .AppendFormatLine("                              AND VP.Letra = V.Letra")
         .AppendFormatLine("                              AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Private Function QueryGetComprobantesRegPagoV2(idSucursal As Integer, numeroReparto As Integer, modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                                  fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                  idDistribucion As Integer, idLocalidad As Integer, idEmpleado As Integer,
                                                  idRuta As Integer, dia As Entidades.Publicos.Dias?,
                                                  incluirOrden As Boolean) As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CC.IdSucursal")
         .AppendFormatLine("     , CC.IdTipoComprobante")
         .AppendFormatLine("     , CC.Letra")
         .AppendFormatLine("     , CC.CentroEmisor")
         .AppendFormatLine("     , CC.NumeroComprobante")
         .AppendFormatLine("     , C.IdCliente ")
         .AppendFormatLine("     , C.CodigoCliente ")
         .AppendFormatLine("     , C.TipoDocCliente")
         .AppendFormatLine("     , C.NroDocCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.NombreDeFantasia")
         .AppendFormatLine("     , CA.NombreCalle + ' ' + CONVERT(VARCHAR(MAX), C.Altura) AS Direccion")
         .AppendFormatLine("     , L.NombreLocalidad")
         .AppendFormatLine("     , P.NombreProvincia")

         .AppendFormatLine("     , T.IdTransportista")
         .AppendFormatLine("     , T.NombreTransportista")

         .AppendFormatLine("     , CC.IdVendedor")
         .AppendFormatLine("     , E.NombreEmpleado AS NombreVendedor")

         .AppendFormatLine("     , CC.Fecha AS FechaComprobante")
         .AppendFormatLine("     , V.FechaEnvio")

         .AppendFormatLine("     , CC.ImporteTotal")
         .AppendFormatLine("     , CC.Saldo AS SaldoComprobante")
         .AppendFormatLine("     , CC.Saldo AS SaldoPendienteAplicar")

         .AppendFormatLine("     , C.IdCategoriaFiscal")
         .AppendFormatLine("     , CF.NombreCategoriaFiscal")

         .AppendFormatLine("     , CC.NumeroReparto")

         .AppendFormatLine("     , V.FechaAlta")
         .AppendFormatLine("     , VFP.IdFormasPago")
         .AppendFormatLine("     , VFP.DescripcionFormasPago as DescripcionFormasPago")

         .AppendFormatLine("     , S.SaldoCliente")

         .AppendFormatLine("     , TC.GrabaLibro")
         .AppendFormatLine("     , TC.IdTipoComprobanteNCred")
         '.AppendFormatLine("     , V.FechaRendicion")

         .AppendFormatLine("  FROM CuentasCorrientes CC")
         If idRuta > 0 Or dia.HasValue Then
            .AppendFormatLine(" INNER JOIN MovilRutasClientes MRC ON MRC.IdCliente = C.IdCliente")
         End If
         .AppendFormatLine("  LEFT JOIN Ventas V ON CC.IdSucursal = V.IdSucursal")
         .AppendFormatLine("                                AND CC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("                                AND CC.Letra = V.Letra")
         .AppendFormatLine("                                AND CC.CentroEmisor = V.CentroEmisor")
         .AppendFormatLine("                                AND CC.NumeroComprobante = V.NumeroComprobante")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
         .AppendFormatLine("  LEFT JOIN Empleados E ON E.IdEmpleado = CC.IdVendedor")
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.idcliente = CC.Idcliente")
         .AppendFormatLine("  LEFT JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
         .AppendFormatLine("  LEFT JOIN Calles CA ON Ca.IdCalle = C.IdCalle")

         .AppendFormatLine(" LEFT JOIN Localidades L ON L.IdLocalidad = Ca.IdLocalidad")
         .AppendFormatLine(" LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia")

         .AppendFormatLine("  LEFT JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago")

         '# Se agrega LEFT JOIN para visualizar el Saldo del Cliente.
         .AppendFormatLine("  LEFT JOIN (SELECT C.IdCliente, C.NombreCliente, SUM(CCP.SaldoCuota) SaldoCliente")
         .AppendFormatLine("               FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine("              INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendFormatLine("  		                                     AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine("   		                                     AND CC.Letra = CCP.Letra")
         .AppendFormatLine("   		                                     AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendFormatLine("   		                                     AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendFormatLine("               LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendFormatLine("              WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("              GROUP BY C.IdCliente, C.NombreCliente) S on S.IdCliente = CC.IdCliente")


         .AppendFormatLine(" WHERE (CC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CC.Saldo <> 0")
         .AppendFormatLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")
         .AppendFormatLine("   AND TC.AfectaCaja = 'True'")
         .AppendFormatLine("   AND TC.EsComercial = 'True'")      'Con esto solo alcanzaria, pero por ahora dejamos ambos.
         .AppendFormatLine("   AND (TC.EsRecibo = 'False' OR TC.EsAnticipo = 'True')")

         If numeroReparto > 0 Then
            If modoConsultarComprobantes = Entidades.RegistracionPagos.ModoConsultarComprobantes.SoloRepartoSeleccionado Then
               .AppendFormatLine("   AND CC.NumeroReparto = {0}", numeroReparto)
            ElseIf modoConsultarComprobantes = Entidades.RegistracionPagos.ModoConsultarComprobantes.ComprobantesClientesReparto Then
               .AppendFormatLine("   AND CC.IdCliente IN (SELECT DISTINCT IdCliente FROM Ventas WHERE NumeroReparto = {0})", numeroReparto)
            End If
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND CC.Fecha >= '{0}' ", ObtenerFecha(fechaHasta.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND CC.Fecha <= '{0}' ", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If
         If idDistribucion > 0 Then
            .AppendFormatLine("   AND V.IdTransportista = {0}", idDistribucion)
         End If
         If idLocalidad > 0 Then
            .AppendFormatLine("   AND C.idlocalidad = {0}", idLocalidad)
         End If
         If idEmpleado > 0 Then
            .AppendFormatLine("   AND CC.IdVendedor = {0} ", idEmpleado)
         End If
         If idRuta > 0 Then
            .AppendFormatLine("   AND MRC.IdRuta = {0}", idRuta)
         End If
         If dia.HasValue Then
            .AppendFormatLine("   AND MRC.Dia = {0}", Convert.ToInt32(dia.Value))
         End If

         .AppendFormatLine("  ) OR EXISTS(SELECT 1 FROM RepartosCobranzasComprobantes RCB")
         .AppendFormatLine("         WHERE RCB.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("                 AND RCB.IdReparto = {0}", numeroReparto)
         .AppendFormatLine("                 AND RCB.IdCobranza = -1")
         .AppendFormatLine("                 AND RCB.IdSucursalComp = CC.IdSucursal")
         .AppendFormatLine("                 AND RCB.IdTipoComprobanteComp = CC.IdTipoComprobante")
         .AppendFormatLine("                 AND RCB.LetraComp = CC.Letra")
         .AppendFormatLine("                 AND RCB.CentroEmisorComp = CC.CentroEmisor")
         .AppendFormatLine("                 AND RCB.NumeroComprobanteComp = CC.NumeroComprobante)")

         If incluirOrden Then
            .AppendFormatLine(" ORDER BY V.FechaEnvio, CC.NumeroReparto, C.NombreCliente, CC.IdTipoComprobante, CC.Letra, CC.CentroEmisor, CC.NumeroComprobante")
         End If

      End With
      Return stb.ToString()
   End Function
End Class
Partial Class Ventas

   ''GET PRINCIPALES

   Public Function GetConsultarVentas(IdSucursal As Integer,
                                    Desde As Date,
                                    Hasta As Date,
                                    IdVendedor As Integer,
                                    GrabaLibro As String,
                                    IdCliente As Long,
                                    AfectaCaja As String,
                                    TipoComprobante As String,
                                    NumeroComprobante As Long,
                                    IdFormasPago As Integer,
                                    IdUsuario As String,
                                    MercDespachada As String,
                                    Comercial As String,
                                    IdCategoria As Integer,
                                    IdLocalidad As Integer,
                                    IdProvincia As String,
                                    LetraFiscal As String,
                                    CentroEmisor As Integer,
                                     idZonaGeografica As String) As DataTable

      ' Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.Fecha ")
         .AppendLine("   ,V.IdSucursal")
         .AppendLine("  ,V.IdTipoComprobante")
         .AppendLine("  ,TC.DescripcionAbrev ")
         .AppendLine("  ,V.Letra ")
         .AppendLine("  ,V.CentroEmisor ")
         .AppendLine("  ,V.NumeroComprobante ")
         .AppendLine("  ,V.IdVendedor ")
         .AppendLine("  ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("  ,C.NombreCliente ")
         .AppendLine("  ,C.CodigoCliente ")
         .AppendLine("  ,C.IdCliente ")
         .AppendLine("  ,V.IdCliente ")
         .AppendLine("  ,V.ImporteBruto ")
         .AppendLine("  ,V.DescuentoRecargoPorc ")
         .AppendLine("  ,V.DescuentoRecargo ")
         .AppendLine("  ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine("   ,I.IdImpresora")
         .AppendLine("   ,I.TipoImpresora")
         .AppendLine("   ,V.IdEstadoComprobante")
         .AppendLine("   ,V.Kilos")
         .AppendLine("   ,C.Cuit")
         .AppendLine("   ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("   ,V.IdFormasPago")
         .AppendLine("   ,V.CantidadInvocados")
         .AppendLine("   ,V.CantidadLotes")
         .AppendLine("   ,V.Usuario")
         .AppendLine("   ,V.FechaAlta")
         .AppendLine("   ,V.CAE")
         .AppendLine("   ,V.CAEVencimiento")
         .AppendLine("   ,V.Observacion")

         'RI
         'If oCategoriaFiscalEmpresa.IvaDiscriminado Then

         .AppendLine("  ,V.SubTotal")
         .AppendLine("  ,V.TotalImpuestos")
         .AppendLine("  ,V.TotalImpuestoInterno")
         .AppendLine("  ,V.ImporteTotal")
         .AppendLine("  ,V.Utilidad")

         '   'Monotributo
         'Else
         '   .AppendLine("  ,V.ImporteTotal AS Subtotal ")
         '   .AppendLine("  ,0 AS TotalImpuestos ")
         '   .AppendLine("  ,0 AS TotalImpuestoInterno")
         '   .AppendLine("  ,V.ImporteTotal")
         '   .AppendLine("  ,V.Utilidad + V.TotalImpuestos + V.TotalImpuestoInterno as Utilidad ")
         'End If

         .AppendLine("      ,V.SubTotal-V.Utilidad AS Costo")
         .AppendLine("      ,V.FechaTransmisionAFIP")
         .AppendLine("      ,TC.EsElectronico")
         .AppendLine("      ,V.MercDespachada")
         .AppendLine("      ,V.FechaActualizacion")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,PV.NombreProvincia")
         .AppendLine("      ,PR.NombreProveedor")
         .AppendLine("   ,V.ImportePesos")
         .AppendLine("   ,V.ImporteTickets")
         .AppendLine("   ,V.ImporteTarjetas")
         .AppendLine("   ,V.ImporteCheques")
         .AppendLine("  ,V.IdCuentaBancaria")
         .AppendLine("  ,V.ImporteTransfBancaria")
         .AppendLine("    ,B.NombreBanco")
         .AppendLine("      ,SUM(CASE WHEN VI.IdTipoImpuesto <> 'IVA' THEN VI.Importe ELSE 0 END) as Percepciones")
         .AppendLine("     ,SUM(CASE WHEN VI.IdTipoImpuesto = 'IVA' THEN VI.Importe ELSE 0 END) as IVA")

         .AppendLine("  FROM Ventas V")

         .AppendLine("   LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("   LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor ")
         .AppendLine("   LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("   LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("   LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("   LEFT JOIN VentasImpuestos VI ON VI.IdSucursal = V.IdSucursal ")
         .AppendLine("    AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("    AND VI.Letra = V.Letra")
         .AppendLine("    AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("    AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("  INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias PV ON PV.IdProvincia = L.IdProvincia")
         .AppendLine("  LEFT JOIN Proveedores PR ON PR.IdProveedor = V.IdProveedor")
         .AppendLine("   LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = V.IdCuentaBancaria")
         .AppendLine("   LEFT JOIN Bancos B ON B.IdBanco = CB.IdBanco")
         .AppendLine("  WHERE 1=1 ")

         If IdSucursal > 0 Then
            .AppendFormatLine("    AND V.IdSucursal = {0}", IdSucursal)
         End If

         If Desde <> Nothing Then
            .AppendLine("    AND V.Fecha >= '" & Desde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("    AND V.Fecha <= '" & Hasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If IdVendedor > 0 Then
            .AppendLine("   AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente <> 0 Then
            .AppendLine("   AND C.IdCliente = " & IdCliente)
         End If

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         If AfectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         End If

         If Comercial <> "TODOS" Then
            .AppendLine("   AND TC.EsComercial = " & IIf(Comercial = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(TipoComprobante) Then
            .AppendLine("   AND V.IdTipoComprobante = '" & TipoComprobante & "'")
         End If

         If LetraFiscal <> "" Then
            .AppendLine("   AND V.Letra = '" & LetraFiscal.ToString() & "'")
         End If

         If CentroEmisor > 0 Then
            .AppendLine("   AND V.CentroEmisor = " & CentroEmisor.ToString())
         End If

         If NumeroComprobante > 0 Then
            .AppendLine("   AND V.NumeroComprobante = " & NumeroComprobante.ToString())
         End If

         If IdFormasPago > 0 Then
            .AppendLine("   AND V.IdFormasPago = " & IdFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(IdUsuario) Then
            .AppendLine("   AND V.Usuario = '" & IdUsuario & "'")
         End If

         If MercDespachada <> "TODOS" Then
            .AppendLine("      AND V.MercDespachada = " & IIf(MercDespachada = "SI", "1", "0").ToString())
         End If

         If IdCategoria > 0 Then
            .AppendLine("   AND C.IdCategoria = " & IdCategoria.ToString())
         End If

         If IdLocalidad > 0 Then
            .AppendLine("  AND C.IdLocalidad = " & IdLocalidad.ToString())
         End If

         If Not String.IsNullOrEmpty(IdProvincia) Then
            .AppendLine("  AND L.IdProvincia = '" & IdProvincia & "'")
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         .AppendLine("   GROUP BY V.Fecha, V.IdSucursal ,V.IdTipoComprobante,TC.DescripcionAbrev ,V.Letra ,V.CentroEmisor ")
         .AppendLine("   ,V.NumeroComprobante ,V.IdVendedor ,E.NombreEmpleado ,C.NombreCliente ")
         .AppendLine("   ,C.CodigoCliente ,C.IdCliente ,V.IdCliente ,V.ImporteBruto ,V.DescuentoRecargoPorc ")
         .AppendLine("   ,V.DescuentoRecargo ,CF.NombreCategoriaFiscalAbrev ,I.IdImpresora ,I.TipoImpresora ,V.IdEstadoComprobante")
         .AppendLine("  ,V.Kilos ,C.Cuit ,VFP.DescripcionFormasPago ,V.IdFormasPago ,V.CantidadInvocados ,V.CantidadLotes")
         .AppendLine("  ,V.Usuario ,V.FechaAlta ,V.CAE ,V.CAEVencimiento ,V.Observacion ,V.SubTotal ,V.TotalImpuestos, V.TotalImpuestoInterno")
         .AppendLine("   ,V.ImporteTotal ,V.Utilidad ,V.SubTotal-V.Utilidad ,V.FechaTransmisionAFIP ,TC.EsElectronico ")
         .AppendLine(" ,V.MercDespachada ,V.FechaActualizacion ,ZG.NombreZonaGeografica ,L.NombreLocalidad ,PV.NombreProvincia ")
         .AppendLine("  ,PR.NombreProveedor ,V.ImportePesos ,V.ImporteTickets ,V.ImporteTarjetas ,V.ImporteCheques ")
         .AppendLine("  ,V.IdCuentaBancaria ,V.ImporteTransfBancaria ,B.NombreBanco ")
         .AppendLine("  ORDER BY V.fecha")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetInformeDeVentas(sucursales As Entidades.Sucursal(),
                                      desde As Date,
                                      hasta As Date,
                                      idZonaGeografica As String,
                                      idVendedor As Integer,
                                      vendedor As Entidades.OrigenFK,
                                      idCliente As Long,
                                      grabaLibro As Entidades.Publicos.SiNoTodos,
                                      afectaCaja As Entidades.Publicos.SiNoTodos,
                                      idFormaDePago As Integer,
                                      idUsuario As String,
                                      discIVA As Boolean,
                                      idLocalidad As Integer,
                                      idProvincia As String,
                                      numeroComprobanteDesde As Long,
                                      numeroComprobanteHasta As Long,
                                      letraFiscal As String,
                                      centroEmisor As Integer,
                                      mercDespachada As Entidades.Publicos.SiNoTodos,
                                      comercial As Entidades.Publicos.SiNoTodos,
                                      idCategoria As Integer,
                                      categoria As Entidades.OrigenFK,
                                      numeroRepartoDesde As Integer?,
                                      numeroRepartoHasta As Integer?,
                                      listaComprobantes As List(Of Entidades.TipoComprobante),
                                      coeficienteStock As Integer?,
                                      esRemitoTransportista As Boolean?,
                                      incluirAnulados As Boolean,
                                      idCentroCosto As Integer,
                                      utilizaCentroCostos As Boolean,
                                      nivelAutorizacion As Short,
                                      correoEnviado As Entidades.Publicos.SiNoTodos,
                                      idPaciente As Long?,
                                      idDoctor As Long?,
                                      fechaCirugia As Date?,
                                      idTransportista As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.Fecha")
         .AppendLine("      ,CONVERT(DATE, V.Fecha) AS Fecha_FECHA")
         .AppendLine("      ,CONVERT(TIME, V.Fecha) AS Fecha_HORA")
         .AppendLine("      ,V.IdSucursal")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev AS TipoComprobante")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,V.IdVendedor ")
         .AppendLine("      ,E.NombreEmpleado AS NombreVendedor")
         .AppendLine("      ,V.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("    ,CASE WHEN C.EsClienteGenerico = 'True' THEN V.NombreCliente ELSE C.NombreCliente END AS NombreCliente")
         .AppendLine("    ,C.NombreDeFantasia")
         '   .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,CV.IdCliente IdClienteVinculado")
         .AppendLine("      ,CV.CodigoCliente CodigoClienteVinculado")
         .AppendLine("      ,CV.NombreCliente NombreClienteVinculado")
         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine("      ,V.IdEstadoComprobante")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago as FormaDePago")

         'RI
         '>>>>>> se cambia esto >>>>>> '
         'If discIVA Then
         '   .AppendLine("  ,V.SubTotal")
         '   .AppendLine("  ,V.TotalImpuestos")
         '   .AppendLine("  ,V.TotalImpuestoInterno")
         '   .AppendLine("  ,V.ImporteTotal")
         '   .AppendLine("  ,V.Utilidad")
         '   'Monotributo
         'Else
         '   .AppendLine("  ,V.ImporteTotal AS Subtotal ")
         '   .AppendLine("  ,0 AS TotalImpuestos ")
         '   .AppendLine("  ,0 AS TotalImpuestoInterno")
         '   .AppendLine("  ,V.ImporteTotal")
         '   .AppendLine("  ,V.Utilidad + V.TotalImpuestos + V.TotalImpuestoInterno as Utilidad ")
         'End If

         '<<<<<< por esto <<<<<<'
         .AppendFormatLine("    , CASE WHEN CFE.IvaDiscriminado = 1 THEN V.SubTotal ELSE V.ImporteTotal END Subtotal")
         .AppendFormatLine("    , CASE WHEN CFE.IvaDiscriminado = 1 THEN V.TotalImpuestos ELSE 0 END TotalImpuestos")
         .AppendFormatLine("    , CASE WHEN CFE.IvaDiscriminado = 1 THEN V.TotalImpuestoInterno ELSE 0 END TotalImpuestoInterno")
         .AppendFormatLine("    , V.ImporteTotal")
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN V.Utilidad ELSE V.Utilidad + CASE WHEN CFE.IvaDiscriminado = 1 THEN V.TotalImpuestos ELSE 0 END + CASE WHEN CFE.IvaDiscriminado = 1 THEN V.TotalImpuestoInterno else 0 END END Utilidad ")

         .AppendLine("     ,V.Usuario")
         .AppendLine("     ,V.Observacion")
         .AppendLine("     ,E.NombreEmpleado")
         .AppendLine("     ,ZG.NombreZonaGeografica")
         .AppendLine("     ,L.NombreLocalidad")
         .AppendLine("     ,PV.NombreProvincia")
         .AppendLine("     ,V.FechaActualizacion")
         .AppendLine("    ,PR.NombreProveedor")
         .AppendLine("     ,V.ImportePesos")
         .AppendLine("     ,V.ImporteDolares")
         .AppendLine("     ,V.ImporteTickets")
         .AppendLine("     ,V.ImporteTarjetas")
         .AppendLine("     ,V.ImporteCheques")
         .AppendLine("     ,V.IdCuentaBancaria")
         .AppendLine("     ,V.ImporteTransfBancaria")
         .AppendLine("     ,B.NombreBanco")
         .AppendLine("     ,CB.NombreCuenta NombreCuentaBancaria")

         .AppendLine("     , CASE WHEN CFE.IvaDiscriminado = 1 THEN ISNULL((SELECT SUM(VI.Neto) FROM VentasImpuestos VI")
         .AppendLine("                             WHERE VI.IdSucursal = V.IdSucursal")
         .AppendLine("                               AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                               AND VI.Letra = V.Letra")
         .AppendLine("                               AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("                               AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("                               AND VI.IdTipoImpuesto = 'IVA'")
         .AppendLine("                               AND VI.Alicuota = 0), 0) ELSE ImporteTotal END NetoNoGravado")

         .AppendLine("     , CASE WHEN CFE.IvaDiscriminado = 1 THEN ISNULL((SELECT SUM(VI.Neto) FROM VentasImpuestos VI")
         .AppendLine("                             WHERE VI.IdSucursal = V.IdSucursal")
         .AppendLine("                               AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                               AND VI.Letra = V.Letra")
         .AppendLine("                               AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("                               AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("                               AND VI.IdTipoImpuesto = 'IVA'")
         .AppendLine("                               AND VI.Alicuota <> 0), 0) ELSE 0 END NetoGravado")

         .AppendLine("     ,ISNULL((SELECT SUM(VI.Importe) FROM VentasImpuestos VI")
         .AppendLine("               WHERE VI.IdSucursal = V.IdSucursal")
         .AppendLine("                 AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                 AND VI.Letra = V.Letra")
         .AppendLine("                 AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("                 AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("                 AND VI.IdTipoImpuesto <> 'IVA'), 0) Percepciones")

         '>>>>>> se cambia esto >>>>>> '
         'If discIVA Then
         '   .AppendLine("     ,ISNULL((SELECT SUM(VI.Importe) FROM VentasImpuestos VI")
         '   .AppendLine("               WHERE VI.IdSucursal = V.IdSucursal")
         '   .AppendLine("                 AND VI.IdTipoComprobante = V.IdTipoComprobante")
         '   .AppendLine("                 AND VI.Letra = V.Letra")
         '   .AppendLine("                 AND VI.CentroEmisor = V.CentroEmisor")
         '   .AppendLine("                 AND VI.NumeroComprobante = V.NumeroComprobante")
         '   .AppendLine("                 AND VI.IdTipoImpuesto = 'IVA'), 0) IVA")
         'Else
         '   .AppendLine("  ,0 AS IVA")
         'End If

         '<<<<<< por esto <<<<<<'
         .AppendFormatLine("     , CASE WHEN CFE.IvaDiscriminado = 1 THEN ISNULL((SELECT SUM(VI.Importe) FROM VentasImpuestos VI")
         .AppendFormatLine("                             WHERE VI.IdSucursal = V.IdSucursal")
         .AppendFormatLine("                               AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("                               AND VI.Letra = V.Letra")
         .AppendFormatLine("                               AND VI.CentroEmisor = V.CentroEmisor")
         .AppendFormatLine("                               AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendFormatLine("                               AND VI.IdTipoImpuesto = 'IVA'), 0) ELSE 0 END IVA")


         '.AppendLine("      ,SUM(CASE WHEN VI.IdTipoImpuesto <> 'IVA' THEN VI.Importe ELSE 0 END) as Percepciones")
         '.AppendLine("     ,SUM(CASE WHEN VI.IdTipoImpuesto = 'IVA' THEN VI.Importe ELSE 0 END) as IVA")
         .AppendLine("     ,V.IdEjercicio")
         .AppendLine("     ,V.IdPlanCuenta")
         .AppendLine("     ,V.IdAsiento")
         .AppendLine("     ,CA.NombreCategoria")
         .AppendLine("     ,V.CantidadInvocados")

         .AppendLine("     ,(SELECT COUNT(1) FROM VentasInvocados VV WHERE VV.IdSucursalInvocado = V.IdSucursal")
         .AppendLine("                                                 AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
         .AppendLine("                                                 AND VV.CentroEmisorInvocado = V.CentroEmisor")
         .AppendLine("                                                 AND VV.LetraInvocado = V.Letra")
         .AppendLine("                                                 AND VV.NumeroComprobanteInvocado = V.NumeroComprobante) CantidadInvocadores")

         .AppendFormatLine("     ,NULLIF(CONVERT(VARCHAR(MAX), ({0})) + ' / ' +", VentasInvocados.GetCantidadInvocadosParaInforme_SubQuery("V"))
         .AppendLine("             CONVERT(VARCHAR(MAX), ISNULL((SELECT COUNT(1)")
         .AppendLine("                                             FROM VentasInvocados VV WHERE VV.IdSucursalInvocado = V.IdSucursal")
         .AppendLine("                                                        AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
         .AppendLine("                                                        AND VV.CentroEmisorInvocado = V.CentroEmisor")
         .AppendLine("                                                        AND VV.LetraInvocado = V.Letra")
         .AppendLine("                                                        AND VV.NumeroComprobanteInvocado = V.NumeroComprobante), 0)), '0 / 0')  CantidadInvocadosInvocadores")

         .AppendLine("     ,NULLIF(V.CantidadLotes, 0) AS CantidadLotes")
         .AppendLine("     ,V.CAE")
         .AppendLine("     ,V.CAEVencimiento")
         .AppendLine("     ,CN.NombreCaja")
         .AppendLine("     ,V.NumeroPlanilla")
         .AppendLine("     ,V.NumeroMovimiento")
         .AppendLine("     ,V.MetodoGrabacion")
         .AppendLine("     ,V.IdFuncion")
         .AppendLine("     ,V.NumeroReparto")

         .AppendLine("     ,V.IdMoneda")
         .AppendLine("     ,M.NombreMoneda")
         .AppendLine("     ,M.Simbolo")
         .AppendLine("     ,V.CotizacionDolar")
         .AppendLine("     ,V.FechaEnvioCorreo")

         .AppendLine("     ,NULLIF((SELECT COUNT(1) FROM VentasClientesContactos VCC")
         .AppendLine("               WHERE VCC.IdSucursal = V.IdSucursal")
         .AppendLine("                 AND VCC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                 AND VCC.Letra = V.Letra")
         .AppendLine("                  AND VCC.CentroEmisor = V.CentroEmisor")
         .AppendLine("                 AND VCC.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("              ), 0) AS CantidadContactos")

         If utilizaCentroCostos Then
            .AppendLine("      ,(SELECT DISTINCT CC.NombreCentroCosto + ' / '")
            .AppendLine("          FROM VentasProductos VP")
            .AppendLine("         INNER JOIN ContabilidadCentrosCostos CC ON CC.IdCentroCosto = VP.IdCentroCosto")
            .AppendLine("            WHERE VP.IdSucursal = V.IdSucursal And VP.IdTipoComprobante = V.IdTipoComprobante And VP.Letra = V.Letra")
            .AppendLine("           AND VP.CentroEmisor = V.CentroEmisor AND VP.NumeroComprobante = V.NumeroComprobante")
            .AppendLine("           FOR XML PATH('')) NombresCentrosCosto")
         Else
            .AppendLine("      , '' NombresCentrosCosto")
         End If
         .AppendLine("     ,V.NroVersionAplicacion")
         .AppendLine("      ,V.Direccion ")
         .AppendFormatLine("      ,V.FechaExportacion ")
         .AppendFormatLine("      ,V.IdPaciente")
         .AppendFormatLine("      ,PAC.NombreCliente NombrePaciente")
         .AppendFormatLine("      ,V.IdDoctor ")
         .AppendFormatLine("      ,DOC.NombreCliente NombreDoctor")
         .AppendFormatLine("      ,V.FechaCirugia ")

         .AppendFormatLine("      ,V.IdCategoriaEmbarcacion ")
         .AppendFormatLine("      ,V.NombreCategoriaEmbarcacion ")

         .AppendFormatLine("      ,V.IdConceptoCM05 ")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")

         .AppendFormatLine("     , V.IdTransportista, TR.NombreTransportista")


         .AppendLine(" FROM Ventas V")

         '# Obtengo la categoría fiscal de la empresa que realizó la venta
         .AppendFormatLine(" INNER JOIN (SELECT P.IdEmpresa, S.Id IdSucursal, CFC.IdCategoriaFiscalCliente, CFC.IvaDiscriminado FROM Parametros P ")
         .AppendFormatLine("         LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON P.ValorParametro = CFC.IdCategoriaFiscalEmpresa AND P.ValorParametro = CFC.IdCategoriaFiscalCliente")
         .AppendFormatLine("         LEFT JOIN Sucursales S ON S.IdEmpresa = P.IdEmpresa")
         .AppendFormatLine("         WHERE P.IdParametro = 'CATEGORIAFISCALEMPRESA' ) CFE ON CFE.IdSucursal = V.IdSucursal")

         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  LEFT JOIN Clientes CV ON CV.IdCliente = V.IdClienteVinculado")
         .AppendLine("  LEFT JOIN Clientes PAC ON V.IdPaciente = PAC.IdCliente")
         .AppendLine("  LEFT JOIN Clientes DOC ON V.IdDoctor = DOC.IdCliente")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         ' .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias PV ON PV.IdProvincia = L.IdProvincia")


         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor  ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         End If

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Categorias CA ON C.IdCategoria = CA.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CA ON V.IdCategoria = CA.IdCategoria")
         End If

         .AppendLine(" LEFT JOIN CajasNombres CN ON CN.IdSucursal = V.IdSucursal AND CN.IdCaja = V.IdCaja")

         .AppendLine(" LEFT JOIN Proveedores PR ON PR.IdProveedor = V.IdProveedor")
         .AppendLine(" LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = V.IdCuentaBancaria")
         .AppendLine(" LEFT JOIN Bancos B ON B.IdBanco = CB.IdBanco")
         .AppendLine(" LEFT JOIN Monedas M ON M.IdMoneda = V.IdMoneda")
         .AppendLine(" LEFT JOIN Transportistas TR ON TR.IdTransportista = V.IdTransportista")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = V.IdConceptoCM05")

         .AppendLine("  WHERE 1 = 1")
         GetListaSucursalesMultiples(stb, sucursales, "V")
         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         .AppendFormatLine("  AND V.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("  AND V.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idVendedor > 0 Then
            .AppendLine("  AND E.IdEmpleado = " & idVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("  AND C.IdCliente = " & idCliente.ToString())
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         If afectaCaja <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND TC.AfectaCaja = {0}", GetStringFromBoolean(afectaCaja = Entidades.Publicos.SiNoTodos.SI))
         End If

         'If Not String.IsNullOrEmpty(idTipoComprobante) Then

         '   .AppendLine("  AND V.IdTipoComprobante = '" & idTipoComprobante & "'")

         'Else
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

         If coeficienteStock.HasValue Then
            .AppendFormatLine("  AND TC.CoeficienteStock = {0}", coeficienteStock.Value)
         End If

         If esRemitoTransportista.HasValue Then
            .AppendFormatLine("  AND TC.EsRemitoTransportista = {0}", GetStringFromBoolean(esRemitoTransportista.Value))
         End If

         'If Marcas.Count > 0 Then
         '   .Append(" AND P.IdMarca IN (")
         '   For Each pr As Entidades.Marca In Marcas
         '      .AppendFormat(" {0},", pr.IdMarca)
         '   Next
         '   .Remove(.Length - 1, 1)
         '   .Append(")")
         'End If

         If Not incluirAnulados Then
            .AppendLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO')")
         End If


         If letraFiscal <> "" Then
            .AppendLine("   AND V.Letra = '" & letraFiscal.ToString() & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
         End If

         If numeroComprobanteDesde > 0 Then
            .AppendLine("   AND V.NumeroComprobante >= " & numeroComprobanteDesde.ToString())
         End If
         If numeroComprobanteHasta > 0 Then
            .AppendLine("   AND V.NumeroComprobante <= " & numeroComprobanteHasta.ToString())
         End If

         If idFormaDePago > 0 Then
            .AppendLine("  AND V.IdFormasPago = " & idFormaDePago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("  AND V.Usuario = '" & idUsuario & "'")
         End If

         If comercial <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine(" AND TC.EsComercial = {0}", GetStringFromBoolean(comercial = Entidades.Publicos.SiNoTodos.SI))
         End If

         If mercDespachada <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine(" AND V.MercDespachada = {0}", GetStringFromBoolean(mercDespachada = Entidades.Publicos.SiNoTodos.SI))
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND CA.IdCategoria = " & idCategoria.ToString())
         End If

         If idTransportista > 0 Then
            .AppendLine("  AND V.IdTransportista = " & idTransportista.ToString())
         End If

         If idLocalidad > 0 Then
            .AppendLine(" AND C.IdLocalidad = " & idLocalidad.ToString())
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("  AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If numeroRepartoDesde.HasValue Then
            .AppendFormat(" AND ISNULL(V.NumeroReparto, 0) >= " & numeroRepartoDesde.Value.ToString())
         End If
         If numeroRepartoHasta.HasValue Then
            .AppendFormat(" AND ISNULL(V.NumeroReparto, 0) <= " & numeroRepartoHasta.Value.ToString())
         End If

         If idPaciente.HasValue Then
            .AppendFormatLine("  AND V.IdPaciente = {0}", idPaciente.Value)
         End If
         If idDoctor.HasValue Then
            .AppendFormatLine("  AND V.IdDoctor = {0}", idDoctor.Value)
         End If
         If fechaCirugia.HasValue Then
            Dim fechaDesde As String = ObtenerFecha(UltimoSegundoDelDia(fechaCirugia.Value).AddDays(-1).AddSeconds(1), True)
            Dim fechaHasta As String = ObtenerFecha(UltimoSegundoDelDia(fechaCirugia.Value), True)
            .AppendFormatLine("  AND V.FechaCirugia >= '{0}'", fechaDesde)
            .AppendFormatLine("  AND V.FechaCirugia <= '{0}'", fechaHasta)
         End If

         If idCentroCosto > 0 Then
            .AppendLine("    AND EXISTS (SELECT idCentroCosto")
            .AppendLine("                  FROM VentasProductos VP")
            .AppendFormatLine("          WHERE VP.idCentroCosto= {0}", idCentroCosto)
            .AppendLine("                      AND V.IdSucursal=VP.IdSucursal")
            .AppendLine("                      AND V.IdTipoComprobante=VP.IdTipoComprobante")
            .AppendLine("                      AND V.Letra=VP.Letra")
            .AppendLine("                      AND V.CentroEmisor=VP.CentroEmisor")
            .AppendLine("                      AND V.NumeroComprobante=VP.NumeroComprobante)")
         End If

         If correoEnviado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND V.FechaEnvioCorreo IS {0} NULL", If(correoEnviado = Entidades.Publicos.SiNoTodos.SI, "NOT", ""))
         End If

         .AppendLine("  ORDER BY V.Fecha")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetInfVentasEnCtaCtePorCaja(IdSucursal As Integer, IdCaja As Integer, NumeroPlanilla As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.Fecha ")
         .AppendLine("  ,V.IdTipoComprobante")
         .AppendLine("  ,TC.DescripcionAbrev ")
         .AppendLine("  ,V.Letra ")
         .AppendLine("  ,V.CentroEmisor ")
         .AppendLine("  ,V.NumeroComprobante ")
         .AppendLine("  ,V.IdVendedor ")
         .AppendLine("  ,E.NombreEmpleado AS NombreVendedor")
         .AppendLine("  ,V.IdCliente ")
         .AppendLine("  ,C.CodigoCliente ")
         .AppendLine("  ,C.NombreCliente ")
         .AppendLine("  ,V.ImporteBruto ")
         .AppendLine("  ,V.DescuentoRecargoPorc ")
         .AppendLine("  ,V.DescuentoRecargo ")
         .AppendLine("  ,V.SubTotal ")
         .AppendLine("  ,V.TotalImpuestos ")
         .AppendLine("  ,V.TotalImpuestoInterno")
         .AppendLine("  ,V.ImporteTotal ")
         .AppendLine("  ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal ")
         .AppendLine("   ,I.IdImpresora")
         .AppendLine("   ,I.TipoImpresora")
         .AppendLine("   ,V.IdEstadoComprobante")
         .AppendLine("   ,V.Kilos")
         .AppendLine("   ,C.Cuit")
         .AppendLine("   ,VFP.DescripcionFormasPago AS FormaDePago")
         .AppendLine("   ,V.IdFormasPago")
         .AppendLine("   ,V.ImportePesos")
         .AppendLine("   ,V.ImporteTickets")
         .AppendLine("   ,V.ImporteTarjetas")
         .AppendLine("   ,V.ImporteCheques")
         .AppendLine("   ,V.CantidadInvocados")
         .AppendLine("   ,V.CantidadLotes")
         .AppendLine("   ,V.Usuario")
         .AppendLine("   ,V.FechaAlta")
         .AppendLine("   ,V.Observacion")

         .AppendLine("  FROM Clientes C, Localidades L, CategoriasFiscales CF, Impresoras I, TiposComprobantes TC, VentasFormasPago VFP, Empleados E, Ventas V")

         .AppendLine("   LEFT OUTER JOIN Transportistas T ON T.IdTransportista = V.IdTransportista")

         .AppendLine("  WHERE V.IdCliente = C.IdCliente")
         .AppendLine("    AND V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .AppendLine("    AND V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("    AND V.IdSucursal = I.IdSucursal")
         .AppendLine("    AND V.CentroEmisor = I.CentroEmisor")
         .AppendLine("    AND V.IdFormasPago = VFP.IdFormasPago")
         .AppendLine("    AND V.IdVendedor = E.IdEmpleado ")
         .AppendLine("    AND C.IdLocalidad = L.IdLocalidad ")

         .AppendLine("   AND TC.AfectaCaja = 'True'")
         .AppendLine("   AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO') ")

         .AppendLine("   AND VFP.Dias > 0 ")             'Forma de Pago de CtaCte

         .AppendLine("    AND V.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("    AND V.IdCaja = " & IdCaja.ToString())
         .AppendLine("    AND V.NumeroPlanilla = " & NumeroPlanilla.ToString())

         .AppendLine("  ORDER BY V.Fecha")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTarjetasVentas(idSucursal As Integer, desde As Date, hasta As Date,
                                     numeroCupon As Long,
                                     idCaja As Integer, idBanco As Integer, idCuentaBancaria As Integer,
                                     idCliente As Long, idVendedor As Integer,
                                     idTipoComprobante As String, grabaLibro As Entidades.Publicos.SiNoTodos,
                                     idUsuario As String,
                                     nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdTipoComprobante ")
         .AppendLine("     , TC.DescripcionAbrev")
         .AppendLine("     , V.Letra ")
         .AppendLine("     , V.CentroEmisor")
         .AppendLine("     , V.NumeroComprobante")
         .AppendLine("     , V.Fecha")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , CN.NombreCaja")
         .AppendLine("     , VT.IdTarjeta")
         .AppendLine("     , T.NombreTarjeta")
         .AppendLine("     , VT.IdBanco")
         .AppendLine("     , B.NombreBanco")
         .AppendLine("     , VT.Cuotas")
         .AppendLine("     , VT.NumeroCupon")
         .AppendLine("     , VT.Monto")
         .AppendLine("     , V.Usuario")
         .AppendLine("     , T.IdCuentaBancaria")
         .AppendLine("     , CB.NombreCuenta")
         .AppendLine("     , V.IdVendedor ")
         .AppendLine("     , E.NombreEmpleado as NombreVendedor")
         .AppendLine(" ,V.IdVendedor ")
         .AppendLine(" ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("  FROM Ventas V ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente ")
         .AppendLine(" INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" INNER JOIN VentasTarjetas VT ON VT.IdSucursal = V.IdSucursal")
         .AppendLine("        AND VT.IdTipoComprobante = V.IdTipoComprobante AND VT.Letra = V.Letra AND VT.CentroEmisor = V.CentroEmisor AND VT.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Tarjetas T ON T.IdTarjeta = VT.IdTarjeta")
         .AppendLine(" INNER JOIN Bancos B ON B.IdBanco = VT.IdBanco")
         .AppendLine(" INNER JOIN CajasNombres CN ON CN.IdSucursal = V.IdSucursal AND CN.IdCaja = V.IdCaja")
         .AppendLine("  LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = T.IdCuentaBancaria")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor")
         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         If idCaja > 0 Then
            .AppendFormatLine(" AND V.IdCaja = {0}", idCaja)
         End If

         If desde.Year > 1990 Then
            .AppendFormatLine("   AND V.fecha >= '{0}'", desde.ToString("yyyyMMdd HH:mm:ss"))
            .AppendFormatLine("   AND V.fecha <= '{0}'", hasta.ToString("yyyyMMdd HH:mm:ss"))
         End If

         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         'If AfectaCaja <> "TODOS" Then
         '   .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         'End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If numeroCupon > 0 Then
            .AppendFormatLine("   AND VT.NumeroCupon = {0}", numeroCupon)
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("   AND V.Usuario = '{0}'", idUsuario)
         End If

         If idBanco > 0 Then
            .AppendFormatLine("   AND VT.IdBanco = {0}", idBanco)
         End If

         If idCuentaBancaria > 0 Then
            .AppendFormatLine("   AND T.IdCuentaBancaria = {0}", idCuentaBancaria.ToString())
         End If

         If idVendedor > 0 Then
            .AppendFormatLine("   AND V.IdVendedor = {0}", idVendedor)
         End If

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         ''Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.Append("  ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.Append("  ,V.IdTipoComprobante")
         '.Append("  ,V.Letra")
         '.Append("  ,V.CentroEmisor")
         '.Append("  ,V.NumeroComprobante")

         .AppendLine("  ORDER BY V.Fecha")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetClientesConFacturables(idSucursal As Integer,
                                             desde As Date, hasta As Date,
                                             nombreProducto As String,
                                             idVendedor As Integer,
                                             idCategoria As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.NombreCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.IdCliente")

         GetInfFacturables_From(stb,
                                idSucursal,
                                desde, hasta,
                                idCliente:=0,
                                idEstadoComprobante:="PENDIENTE",
                                idUsuario:=String.Empty,
                                idVendedor,
                                idTipoComprobante:=String.Empty,
                                idCategoria,
                                idCategoriaFiscal:=0,
                                joinAdicionales:=Nothing)

         .AppendFormatLine(" GROUP BY C.NombreCliente, C.CodigoCliente, C.IdCliente")
         .AppendFormatLine(" ORDER BY C.NombreCliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetInfFacturables(idSucursal As Integer,
                                     desde As Date, hasta As Date,
                                     idCliente As Long,
                                     idEstadoComprobante As String,
                                     idUsuario As String,
                                     idVendedor As Integer,
                                     idTipoComprobante As String,
                                     idCategoria As Integer,
                                     idCategoriaFiscal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT '...' AS Ver")
         .AppendFormatLine("     , '...' AS Imprimir")
         .AppendFormatLine("     , V.Fecha")
         .AppendFormatLine("     , V.IdSucursal")
         .AppendFormatLine("     , V.IdTipoComprobante")
         .AppendFormatLine("     , TC.DescripcionAbrev")
         .AppendFormatLine("     , V.Letra")
         .AppendFormatLine("     , V.CentroEmisor")
         .AppendFormatLine("     , V.NumeroComprobante")
         .AppendFormatLine("     , V.IdVendedor")
         .AppendFormatLine("     , E.NombreEmpleado AS NombreVendedor")
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
         .AppendFormatLine("     , CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendFormatLine("     , I.IdImpresora")
         .AppendFormatLine("     , I.TipoImpresora")
         .AppendFormatLine("     , V.IdEstadoComprobante")
         .AppendFormatLine("     , V.Kilos")
         .AppendFormatLine("     , C.Cuit")
         .AppendFormatLine("     , VFP.DescripcionFormasPago AS FormaDePago")
         .AppendFormatLine("     , V.IdFormasPago")
         .AppendFormatLine("     , V.ImportePesos")
         .AppendFormatLine("     , V.ImporteTickets")
         .AppendFormatLine("     , V.ImporteTarjetas")
         .AppendFormatLine("     , V.ImporteCheques")
         .AppendFormatLine("     , V.CantidadInvocados")
         .AppendFormatLine("     , V.CantidadLotes")
         .AppendFormatLine("     , V.Usuario")
         .AppendFormatLine("     , V.FechaAlta")
         ''.AppendFormatLine("     , V.IdTipoComprobanteFact")
         ''.AppendFormatLine("     , V.LetraFact")
         ''.AppendFormatLine("     , V.CentroEmisorFact")
         ''.AppendFormatLine("     , V.NumeroComprobanteFact")
         .AppendFormatLine("     , V.Observacion")

         .AppendFormatLine("     , L.NombreLocalidad")
         .AppendFormatLine("     , T.NombreTransportista")
         .AppendFormatLine("     , V.Bultos")

         GetInfFacturables_From(stb,
                                idSucursal,
                                desde, hasta,
                                idCliente,
                                idEstadoComprobante,
                                idUsuario,
                                idVendedor,
                                idTipoComprobante,
                                idCategoria,
                                idCategoriaFiscal,
                                joinAdicionales:=Nothing)

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         ''Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("  ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.AppendLine("  ,V.IdTipoComprobante")
         '.AppendLine("  ,V.Letra")
         '.AppendLine("  ,V.CentroEmisor")
         '.AppendLine("  ,V.NumeroComprobante")

         .AppendLine("  ORDER BY V.Fecha")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetInfFacturablesDetalle(idSucursal As Integer,
                                            desde As Date, hasta As Date,
                                            idCliente As Long,
                                            idEstadoComprobante As String,
                                            idUsuario As String,
                                            idVendedor As Integer,
                                            idTipoComprobante As String,
                                            idCategoria As Integer,
                                            idCategoriaFiscal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT VV.*")
         .AppendFormatLine("     , TCVV.DescripcionAbrev DescripcionAbrevInvocador")

         GetInfFacturables_From(stb,
                                idSucursal,
                                desde, hasta,
                                idCliente,
                                idEstadoComprobante,
                                idUsuario,
                                idVendedor,
                                idTipoComprobante,
                                idCategoria,
                                idCategoriaFiscal,
                                Sub(stb1)
                                   stb1.AppendFormatLine(" INNER JOIN VentasInvocados VV ON VV.IdSucursalInvocado = V.IdSucursal")
                                   stb1.AppendFormatLine("                              AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
                                   stb1.AppendFormatLine("                              AND VV.LetraInvocado = V.Letra")
                                   stb1.AppendFormatLine("                              AND VV.CentroEmisorInvocado = V.CentroEmisor")
                                   stb1.AppendFormatLine("                              AND VV.NumeroComprobanteInvocado = V.NumeroComprobante")
                                   stb1.AppendFormatLine(" INNER JOIN TiposComprobantes TCVV ON TCVV.IdTipoComprobante = VV.IdTipoComprobante")
                                End Sub)

         stb.AppendFormatLine("")

      End With

      Return GetDataTable(stb)
   End Function

   Private Sub GetInfFacturables_From(stb As StringBuilder,
                                      idSucursal As Integer,
                                      desde As Date, hasta As Date,
                                      idCliente As Long,
                                      idEstadoComprobante As String,
                                      idUsuario As String,
                                      idVendedor As Integer,
                                      idTipoComprobante As String,
                                      idCategoria As Integer,
                                      idCategoriaFiscal As Integer,
                                      joinAdicionales As Action(Of StringBuilder))
      With stb
         .AppendFormatLine("  FROM Clientes C")
         .AppendFormatLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendFormatLine(" INNER JOIN Ventas V ON V.IdCliente = C.IdCliente")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")
         .AppendFormatLine(" INNER JOIN VentasFormasPago VFP ON VFP.IdFormasPago = V.IdFormasPago")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor")
         .AppendFormatLine(" INNER JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         If joinAdicionales IsNot Nothing Then
            joinAdicionales(stb)
         End If

         .AppendFormatLine("  LEFT OUTER JOIN Transportistas T ON T.IdTransportista = V.IdTransportista")

         .AppendFormatLine(" WHERE TC.EsFacturable = 'True' AND TC.AfectaCaja = 'False'")  'Aquellos Facturables que no son Comprobantes de Facturacion (FACT, NCD)
         .AppendFormatLine("   AND V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND V.fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("   AND V.fecha <= '{0}'", ObtenerFecha(hasta, True))

         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         Select Case idEstadoComprobante
            Case "PENDIENTE", "FACTURADO"
               .AppendFormatLine("   AND {0} EXISTS (SELECT 1 FROM VentasInvocados VV", If(idEstadoComprobante = "PENDIENTE", "NOT", ""))
               .AppendFormatLine("                           WHERE VV.IdSucursalInvocado = V.IdSucursal")
               .AppendFormatLine("                             AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
               .AppendFormatLine("                             AND VV.LetraInvocado = V.Letra")
               .AppendFormatLine("                             AND VV.CentroEmisorInvocado = V.CentroEmisor")
               .AppendFormatLine("                             AND VV.NumeroComprobanteInvocado = V.NumeroComprobante)")
               .AppendFormatLine("   AND ( V.IdEstadoComprobante is null or V.IdEstadoComprobante <> 'ANULADO')")

            Case "ANULADO"
               .AppendFormatLine("   AND V.IdEstadoComprobante = 'ANULADO'")

            Case "NO ANULADO"
               .AppendFormatLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO')")

            Case Else

         End Select

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("   AND V.Usuario = '{0}'", idUsuario)
         End If

         If idVendedor > 0 Then
            .AppendFormatLine("   AND V.IdVendedor = {0}", idVendedor)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If idCategoria <> 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If

         If idCategoriaFiscal <> 0 Then
            .AppendFormatLine("  AND C.IdCategoriaFiscal = {0}", idCategoriaFiscal)
         End If
      End With

   End Sub

   Public Function GetEstadVentasClientes(suc As List(Of Integer),
                                       cantidad As Integer,
                                       Desde As Date,
                                       Hasta As Date,
                                       idMarca As Integer,
                                       idModelo As Integer,
                                       idRubro As Integer,
                                       idSubRubro As Integer,
                                       IdProducto As String,
                                       discIVA As Boolean,
                                       IdVendedor As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb
         .Length = 0
         .AppendLine("SELECT TOP " & cantidad.ToString())
         .AppendLine("  V.IdCliente, ")
         .AppendLine("  C.CodigoCliente, ")
         .AppendLine("  C.NombreCliente, ")

         If discIVA Then
            .AppendLine("  SUM(VP.ImporteTotalNeto) AS Importe")
         Else
            .AppendLine("  SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS Importe")
         End If

         .AppendLine(" FROM Ventas V ")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN VentasProductos VP ON v.IdSucursal = vp.IdSucursal ")
         .AppendLine("      AND v.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine("      AND v.Letra = vp.Letra ")
         .AppendLine("      AND v.CentroEmisor = vp.CentroEmisor")
         .AppendLine("      AND v.NumeroComprobante = vp.NumeroComprobante ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto") ' AND P.AfectaStock = 'True'")
         .AppendLine("  WHERE TC.AfectaCaja = 'True' ")
         .AppendLine("    AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
         .AppendLine("   AND v.Fecha >= '" & Desde.ToString("yyyyMMdd") & " 00:00:00'")
         .AppendLine("    AND v.Fecha <= '" & Hasta.ToString("yyyyMMdd") & " 23:59:59'")
         If idMarca <> 0 Then
            .AppendFormat("  AND P.IdMarca = {0}", idMarca)
         End If
         If idModelo <> 0 Then
            .AppendFormat("  AND P.IdModelo = {0}", idModelo)
         End If
         If idRubro <> 0 Then
            .AppendFormat("  AND P.IdRubro = {0}", idRubro)
         End If
         If idSubRubro <> 0 Then
            .AppendFormat("  AND P.IdSubRubro = {0}", idSubRubro)
         End If
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND V.IdSucursal = 0")
         Else
            .AppendFormat(" AND V.IdSucursal IN ({0})", sucur)
         End If
         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("  AND VP.IdProducto = '" & IdProducto & "'")
         End If
         If IdVendedor <> 0 Then
            .AppendLine("  AND V.IdVendedor = " & IdVendedor)
         End If
         .AppendLine(" GROUP BY V.IdCliente, C.CodigoCliente, C.NombreCliente ")
         .AppendLine(" ORDER BY Importe desc ")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorRangoFechas(agregarSelec As Boolean,
                                     agregarVer As Boolean,
                                     categoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                     Sucursales As Entidades.Sucursal(),
                                     desde As Date, hasta As Date,
                                     idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                     grabaLibro As Entidades.Publicos.SiNoTodos, idCliente As Long,
                                     afectaCaja As Entidades.Publicos.SiNoTodos, tipoComprobante As String, numeroComprobante As Long,
                                     idFormasPago As Integer, idUsuario As String, idEstadoComprobante As String,
                                     porcUtilidadDesde As Decimal, porcUtilidadHasta As Decimal,
                                     mercDespachada As String, comercial As String,
                                     idCategoria As Integer, numeroReparto As Integer, ctaCte As Boolean,
                                     exclurirComprobanteFiscal As Boolean, exclurirComprobanteElectronico As Boolean,
                                     letra As String, emisor As Integer?, ncomprobantedesde As Long?, ncomprobantehasta As Long?) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.Fecha ")
         If agregarSelec Then .AppendLine("	,CONVERT(bit, 0) Selec")
         If agregarVer Then .AppendLine("	,'...' Ver")
         .AppendLine("	,V.IdSucursal")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,TC.DescripcionAbrev AS TipoComprobante")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("  ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("    ,CASE WHEN C.EsClienteGenerico = 'True' THEN V.NombreCliente ELSE C.NombreCliente END AS NombreCliente")
         .AppendLine("	,C.CodigoCliente ")
         .AppendLine("	,C.IdCliente ")
         .AppendLine("	,V.IdCliente ")
         .AppendLine("	, C.Direccion")
         .AppendLine("	, L.IdLocalidad")
         .AppendLine("	, L.NombreLocalidad")
         .AppendLine("	, Pv.IdProvincia")
         .AppendLine("	, Pv.NombreProvincia")
         .AppendLine("	,V.ImporteBruto ")
         .AppendLine("	,V.DescuentoRecargoPorc ")
         .AppendLine("	,V.DescuentoRecargo ")
         .AppendLine("	,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
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
         '.AppendLine("   ,V2.Invoco")
         '.AppendLine("   ,MVL2.Lotes")
         '.AppendLine("   ,MVL2.IdTipoMovimiento")
         '.AppendLine("   ,MVL2.NumeroMovimiento")
         '.AppendLine("   ,V.IdSucursal")
         .AppendLine("   ,V.Usuario")
         .AppendLine("   ,V.FechaAlta")
         .AppendLine("   ,V.CAE")
         .AppendLine("   ,V.CAEVencimiento")
         .AppendLine("   ,V.Observacion")
         .AppendLine("   ,V.IdCategoria")

         'RI
         If categoriaFiscalEmpresa.IvaDiscriminado Then

            .AppendLine("	,V.SubTotal")
            .AppendLine("	,V.TotalImpuestos")
            .AppendLine("  ,V.TotalImpuestoInterno")
            .AppendLine("	,V.ImporteTotal")
            .AppendLine("  ,V.Utilidad")
            .AppendLine("  ,V.SubTotal-V.Utilidad AS Costo")

            .AppendLine("      ,V.SubTotal + V.TotalImpuestos + V.TotalImpuestoInterno AS TotalConImpuestos ")
            .AppendFormatLine("     ,ISNULL((V.Utilidad * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + V.Utilidad),0) AS UtilidadConImpuestos")
            .AppendFormatLine("   ,ISNULL((V.SubTotal-V.Utilidad) * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + (V.SubTotal-V.Utilidad),0)  AS CostoConImpuestos")

            .AppendFormatLine("  ,ISNULL((V.Utilidad / NULLIF(V.SubTotal, 0)), 0) * 100 AS PorcUtilidad")
            .AppendFormatLine("  ,ISNULL(ISNULL((V.Utilidad * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + V.Utilidad),0) / NULLIF((V.SubTotal + V.TotalImpuestos + V.TotalImpuestoInterno), 0), 0) * 100 AS PorcUtilidadCI")

            'Monotributo
         Else

            .AppendLine("  ,V.ImporteTotal AS Subtotal ")
            .AppendLine("	,0 AS TotalImpuestos ")
            .AppendLine("  ,0 AS TotalImpuestoInterno")
            .AppendLine(" , V.ImporteTotal AS TotalConImpuestos ")
            .AppendFormatLine("     ,ISNULL((V.Utilidad * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + V.Utilidad),0) AS UtilidadConImpuestos")
            '.AppendLine(" , 0 AS CostoConImpuestos")
            .AppendFormatLine("   ,ISNULL((V.SubTotal-V.Utilidad) * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + (V.SubTotal-V.Utilidad),0)  AS CostoConImpuestos")
            .AppendLine("	,V.ImporteTotal")
            '.AppendLine("  ,V.Utilidad + V.TotalImpuestos + V.TotalImpuestoInterno as Utilidad ")
            .AppendLine("  ,ISNULL(V.Utilidad * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + V.Utilidad,0) as Utilidad ")
            .AppendLine("  ,ISNULL((V.SubTotal-V.Utilidad) * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + (V.SubTotal-V.Utilidad),0)  AS Costo")

            .AppendFormatLine("  ,(ISNULL(V.Utilidad * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + V.Utilidad,0) / V.ImporteTotal) * 100 AS PorcUtilidad")
            .AppendFormatLine("  ,(ISNULL((V.Utilidad * (V.TotalImpuestos / NULLIF(V.SubTotal,0)) + V.Utilidad),0) / V.ImporteTotal) * 100 AS PorcUtilidadCI")

         End If


         .AppendLine("   ,V.FechaTransmisionAFIP")
         .AppendLine("   ,TC.EsElectronico")
         .AppendLine("   ,V.MercDespachada")
         .AppendLine("   ,V.FechaActualizacion")
         .AppendLine("   ,V.FechaEnvio")
         .AppendLine("   ,V.NumeroReparto")
         .AppendLine("   ,V.IdTransportista")
         .AppendLine("   ,T.NombreTransportista")
         .AppendLine("   ,V.ComisionVendedor ")

         .AppendLine("   ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.IdCliente END AS IdClienteCtaCte ")
         .AppendLine("   ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.CodigoCliente END AS CodigoClienteCtaCte ")
         .AppendLine("   ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.NombreCliente END AS NombreClienteCtaCte ")
         .AppendLine("   ,CC.Saldo ")
         .AppendLine("   ,V.IdCobrador ")
         .AppendLine("   ,CB.NombreEmpleado AS NombreCobrador")
         .AppendLine("   ,CCC.IdCliente IdClienteVinculado")
         .AppendLine("   ,CCC.CodigoCliente CodigoClienteVinculado")
         .AppendLine("   ,CCC.NombreCliente NombreClienteVinculado")
         .AppendLine("   ,CC.Referencia")
         .AppendLine("	FROM Ventas V")
         .AppendLine("	 LEFT JOIN Empleados CB ON V.IdCobrador=CB.IdEmpleado ")
         .AppendLine("	 LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("	 LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor")
         .AppendLine("                          AND V.IdSucursal = I.IdSucursal")  'SE AGREGO ESTA SENTENCIA PORQUE SE DUPLICABAN LOS COMPROBANTES A ANULAR EN SEÑALAR
         .AppendLine("	 LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("	 LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("	 LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("	 LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("	 LEFT JOIN Provincias Pv ON Pv.IdProvincia = L.IdProvincia")
         .AppendLine("	 LEFT JOIN Transportistas T ON T.IdTransportista = V.IdTransportista ")
         .AppendLine("	 LEFT JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal")
         .AppendLine("                                 AND CC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                                 AND CC.Letra = V.Letra")
         .AppendLine("                                 AND CC.CentroEmisor = V.CentroEmisor")
         .AppendLine("                                 AND CC.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("	 LEFT JOIN Clientes CCC ON CCC.IdCliente = V.IdClienteVinculado ")

         '.AppendLine("  INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")

         If origenVendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor  ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         End If

         '.AppendLine("  WHERE V.IdSucursal= " & IdSucursal.ToString())
         .AppendFormatLine("  WHERE V.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("	  AND V.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         GetListaSucursalesMultiples(stb, Sucursales, "V")

         If exclurirComprobanteElectronico Then
            .AppendLine("    AND (TC.EsElectronico = 'False' OR TC.EsPreElectronico = 'True') ")
         End If

         If exclurirComprobanteFiscal Then
            .AppendLine("    AND (TC.EsFiscal = 'False' OR TC.EsPreElectronico = 'True')")
         End If

         If idVendedor > 0 Then
            .AppendLine("	 AND E.IdEmpleado = " & idVendedor)
         End If

         If idCliente <> 0 Then
            .AppendLine("	 AND C.IdCliente = " & idCliente)
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         If afectaCaja <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.AfectaCaja = {0}", GetStringFromBoolean(afectaCaja = Entidades.Publicos.SiNoTodos.SI))
         End If

         If comercial <> "TODOS" Then
            .AppendLine("   AND TC.EsComercial = '" & IIf(comercial = "SI", "True", "False").ToString() & "' ")
         End If

         If Not String.IsNullOrEmpty(tipoComprobante) Then
            .AppendLine("	 AND V.IdTipoComprobante = '" & tipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(letra) Then
            .AppendLine("	 AND V.Letra = '" & letra & "'")
         End If

         If emisor.HasValue Then
            .AppendLine("	 AND V.CentroEmisor= " & emisor)
         End If

         If ncomprobantedesde.HasValue Then
            .AppendFormatLine("	 AND V.NumeroComprobante >= {0}", ncomprobantedesde)
         End If

         If ncomprobantehasta.HasValue Then
            .AppendFormatLine("	 AND V.NumeroComprobante <= {0}", ncomprobantehasta)
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

         If Not String.IsNullOrEmpty(idEstadoComprobante) Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If idEstadoComprobante = "PENDIENTE" Then
               .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
            ElseIf idEstadoComprobante = "NO ANULADO" Then
               .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendLine("   AND V.IdEstadoComprobante = '" & idEstadoComprobante & "'")
            End If
         End If

         If porcUtilidadDesde >= 0 Then
            .AppendLine("	AND ROUND(V.Utilidad/V.SubTotal*100,2) BETWEEN " & porcUtilidadDesde.ToString() & " AND " & porcUtilidadHasta.ToString())
         End If

         If mercDespachada <> "TODOS" Then
            .AppendLine("      AND V.MercDespachada = " & IIf(mercDespachada = "SI", "1", "0").ToString())
         End If

         If idCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & idCategoria.ToString())
         End If

         If numeroReparto > 0 Then
            .AppendFormat("   AND V.NumeroReparto = {0}", numeroReparto).AppendLine()
         End If

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.AppendLine("	,V.IdTipoComprobante")
         '.AppendLine("	,V.Letra")
         '.AppendLine("	,V.CentroEmisor")
         '.AppendLine("	,V.NumeroComprobante")

         If ctaCte Then
            .AppendLine(" AND CC.Saldo <> 0")
         End If


         .AppendLine("	ORDER BY V.fecha")

      End With

      Return GetDataTable(stb)

   End Function


End Class
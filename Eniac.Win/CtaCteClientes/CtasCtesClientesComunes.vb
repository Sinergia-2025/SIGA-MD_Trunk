Public Class CtasCtesClientesComunes

   Private Function CrearDT() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdVendedor", GetType(Integer))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreCliente2", GetType(String))
         .Columns.Add("NombreDeFantasia", GetType(String))
         '.Columns.Add("NombreCategoria", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         '.Columns.Add("DescripcionTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("FechaVencimiento", GetType(Date))
         .Columns.Add("CantDias", GetType(Integer))
         '.Columns.Add("IdFormasPago", GetType(Integer))
         .Columns.Add("DescripcionFormasPago", GetType(String))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("Saldo", GetType(Decimal))
         .Columns.Add("Total", GetType(Decimal))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("NombreCategoria", GetType(String))
         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Integer))
         '.Columns.Add("Interes", GetType(Decimal))

         .Columns.Add("IdClienteCtaCte", GetType(Long))
         .Columns.Add("CodigoClienteCtaCte", GetType(Long))
         .Columns.Add("NombreClienteCtaCte", GetType(String))

         .Columns.Add("NombreZonaGeografica", GetType(String))
         .Columns.Add("Telefono", GetType(String))
         .Columns.Add("Grupo", GetType(String))
      End With

      Return dtTemp

   End Function
   Private Function CrearDTMutual() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdVendedor", GetType(Integer))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreCliente2", GetType(String))
         .Columns.Add("NombreDeFantasia", GetType(String))
         '.Columns.Add("NombreCategoria", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         '.Columns.Add("DescripcionTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("Fecha", GetType(Date))
         '.Columns.Add("FechaVencimiento", GetType(Date))
         .Columns.Add("CantDias", GetType(Integer))
         '.Columns.Add("IdFormasPago", GetType(Integer))
         .Columns.Add("DescripcionFormasPago", GetType(String))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("Saldo", GetType(Decimal))
         .Columns.Add("Total", GetType(Decimal))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("NombreCategoria", GetType(String))
         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Integer))
         '.Columns.Add("Interes", GetType(Decimal))

         .Columns.Add("IdClienteCtaCte", GetType(Long))
         .Columns.Add("CodigoClienteCtaCte", GetType(Long))
         .Columns.Add("NombreClienteCtaCte", GetType(String))

         .Columns.Add("NombreZonaGeografica", GetType(String))
         .Columns.Add("Referencia", GetType(String))
         .Columns.Add("Telefono", GetType(String))
      End With

      Return dtTemp

   End Function
   Private Function CrearDTDetalle() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdVendedor", GetType(Integer))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodVin", GetType(Long))
         .Columns.Add("NombreVin", GetType(String))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreCliente2", GetType(String))
         .Columns.Add("NombreDeFantasia", GetType(String))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("CuotaNumero", GetType(Integer))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("DiasFactura", GetType(Integer))
         .Columns.Add("FechaVencimiento", GetType(Date))
         .Columns.Add("DiasVencido", GetType(Integer))
         .Columns.Add("IdFormasPago", GetType(Integer))
         .Columns.Add("DescripcionFormasPago", GetType(String))
         .Columns.Add("ImporteCuota", GetType(Decimal))
         .Columns.Add("SaldoCuota", GetType(Decimal))
         .Columns.Add("Total", GetType(Decimal))
         .Columns.Add("SaldoVencido", GetType(Decimal))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("NombreCategoria", GetType(String))
         .Columns.Add("NombreZonaGeografica", GetType(String))
         .Columns.Add("Interes", GetType(Decimal))
         .Columns.Add("NombreEstadoCliente", GetType(String))
         .Columns.Add("NumeroOrdenCompra", GetType(Long))
         .Columns.Add("IdProveedor", GetType(Long))
         .Columns.Add("CodigoProveedor", GetType(Long))
         .Columns.Add("NombreProveedor", GetType(String))
         .Columns.Add("IdCobrador", GetType(Integer))
         .Columns.Add("NombreCobrador", GetType(String))
         .Columns.Add("CotizacionDolar", GetType(Decimal))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("NombreEmbarcacion", GetType(String))
      End With

      Return dtTemp

   End Function
   Public Function GetDataTableParaClientes(dtDetalle As DataTable, TipoSaldo As String) As DataTable

      Dim dt = CrearDT()

      If dtDetalle.Rows.Count > 0 Then
         Dim MontoMinimoInteresPermitido = Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido
         Dim IdCliente2 = Long.Parse(dtDetalle.Rows(0)("IdCliente").ToString())

         Dim Total = 0D
         For Each dr As DataRow In dtDetalle.Rows

            Dim drCl = dt.NewRow()

            drCl("Ver") = "..."
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdVendedor") = dr("IdVendedor").ToString()
            'drCl("NroDocVendedor") = dr("NroDocVendedor").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCliente2") = dr("NombreCliente2").ToString()
            drCl("NombreDeFantasia") = dr("NombreDeFantasia")
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            'drCl("DescripcionTipoComprobante") = dr("DescripcionTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("CantDias") = Integer.Parse(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()), Date.Today).ToString()) + 1
            ' drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago").ToString()
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("Saldo") = Decimal.Parse(dr("Saldo").ToString())

            If IdCliente2 <> Long.Parse(dr("IdCliente").ToString()) Then
               Total = 0
            End If

            If TipoSaldo = "TODOS" Then
               Total += Decimal.Parse(dr("ImporteTotal").ToString())
            Else
               Total += Decimal.Parse(dr("Saldo").ToString())
            End If

            'If reqInt = True Then
            '   If TipoSaldo = "TODOS" Then
            '      If MontoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
            '         Total += Decimal.Parse(dr("Interes").ToString())
            '         drCl("Interes") = dr("Interes")
            '      Else
            '         drCl("Interes") = 0
            '      End If
            '   Else
            '      If MontoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
            '         Total += Decimal.Parse(dr("Interes").ToString())
            '         drCl("Interes") = dr("Interes")
            '      Else
            '         drCl("Interes") = 0
            '      End If
            '   End If
            'End If
            drCl("Total") = Total

            drCl("Observacion") = dr("Observacion").ToString()
            drCl("NombreCategoria") = dr("NombreCategoria").ToString()

            drCl("IdPlanCuenta") = dr("IdPlanCuenta")
            drCl("IdAsiento") = dr("IdAsiento")

            drCl("IdClienteCtaCte") = dr("IdClienteCtaCte")
            drCl("CodigoClienteCtaCte") = dr("CodigoClienteCtaCte")
            drCl("NombreClienteCtaCte") = dr("NombreClienteCtaCte")

            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica")
            drCl("Telefono") = dr("Telefono").ToString()

            drCl("Grupo") = dr("Grupo").ToString()

            IdCliente2 = Long.Parse(dr("IdCliente").ToString())

            dt.Rows.Add(drCl)
         Next
      End If

      Return dt
   End Function

   Public Function GetDataTableDetalleClientes(dtDetalle As DataTable, TipoSaldo As String) As DataTable

      Dim dt = CrearDTDetalle()

      If dtDetalle.Rows.Count > 0 Then
         Dim MontoMinimoInteresPermitido = Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido
         Dim IdCliente2 = Long.Parse(dtDetalle.Rows(0)("IdCliente").ToString())
         Dim CtaCteEmbarcacion = Reglas.Publicos.CtaCteEmbarcacion

         Dim Total = 0D
         For Each dr As DataRow In dtDetalle.Rows
            Dim drCl = dt.NewRow()
            drCl("Ver") = "..."
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdVendedor") = dr("IdVendedor").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCliente2") = dr("NombreCliente2").ToString()
            drCl("NombreDeFantasia") = dr("NombreDeFantasia")
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("CuotaNumero") = Integer.Parse(dr("CuotaNumero").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())

            If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then
               Dim diasFactura As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()).Date, Date.Today)), 0)
               drCl("DiasFactura") = diasFactura
            End If
            drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())
            If Decimal.Parse(dr("SaldoCuota").ToString()) <> 0 Then
               Dim diasVencido As Integer = Math.Max(CInt(DateDiff(DateInterval.Day, Date.Parse(dr("FechaVencimiento").ToString()).Date, Date.Today)), 0)
               drCl("DiasVencido") = diasVencido
               If diasVencido > 0 Then
                  drCl("SaldoVencido") = dr("SaldoCuota")
               End If
            End If

            drCl("IdFormasPago") = dr("IdFormasPago")
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago")
            drCl("ImporteCuota") = Decimal.Parse(dr("ImporteCuota").ToString())
            drCl("SaldoCuota") = Decimal.Parse(dr("SaldoCuota").ToString())
            '---
            If IdCliente2 <> Long.Parse(dr("IdCliente").ToString()) Then
               Total = 0
            End If
            If MontoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
               Total += Decimal.Parse(dr("SaldoCuota").ToString()) + Decimal.Parse(dr("Interes").ToString())
               drCl("Interes") = dr("Interes")
            Else
               Total += Decimal.Parse(dr("SaldoCuota").ToString())
               drCl("Interes") = 0
            End If
            '--
            drCl("Total") = Total
            drCl("Observacion") = dr("Observacion").ToString()
            drCl("NombreCategoria") = dr("NombreCategoria").ToString()
            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica")
            drCl("NombreEstadoCliente") = dr("NombreEstadoCliente")
            drCl("NumeroOrdenCompra") = dr("NumeroOrdenCompra")
            drCl("IdProveedor") = dr("IdProveedor")
            drCl("CodigoProveedor") = dr("CodigoProveedor")
            drCl("NombreProveedor") = dr("NombreProveedor")
            drCl("IdCobrador") = dr("IdCobrador")
            drCl("NombreCobrador") = dr("NombreCobrador")
            drCl("CotizacionDolar") = dr("CotizacionDolar")
            drCl("Direccion") = dr("Direccion")

            If CtaCteEmbarcacion = True Then
               drCl("NombreEmbarcacion") = dr("NombreEmbarcacion")
            End If

            dt.Rows.Add(drCl)
         Next
      End If

      Return dt
   End Function

   Public Function GetDataTableParaClientesMutual(dtDetalle As DataTable, TipoSaldo As String) As DataTable

      Dim dt = Me.CrearDTMutual()

      If dtDetalle.Rows.Count > 0 Then
         Dim MontoMinimoInteresPermitido = Reglas.Publicos.CtaCte.MontoMinimoInteresPermitido
         Dim IdCliente2 = Long.Parse(dtDetalle.Rows(0)("IdCliente").ToString())

         Dim Total = 0D
         For Each dr As DataRow In dtDetalle.Rows

            Dim drCl = dt.NewRow()

            drCl("Ver") = "..."
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdVendedor") = dr("IdVendedor").ToString()
            ' drCl("NroDocVendedor") = dr("NroDocVendedor").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCliente2") = dr("NombreCliente2").ToString()
            drCl("NombreDeFantasia") = dr("NombreDeFantasia")
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            'drCl("DescripcionTipoComprobante") = dr("DescripcionTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("CantDias") = Integer.Parse(DateDiff(DateInterval.Day, Date.Parse(dr("Fecha").ToString()), Date.Today).ToString()) + 1
            ' drCl("FechaVencimiento") = Date.Parse(dr("FechaVencimiento").ToString())
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago").ToString()
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("Saldo") = Decimal.Parse(dr("Saldo").ToString())

            If IdCliente2 <> Long.Parse(dr("IdCliente").ToString()) Then
               Total = 0
            End If

            If TipoSaldo = "TODOS" Then
               If MontoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
                  Total += Decimal.Parse(dr("ImporteTotal").ToString()) + Decimal.Parse(dr("Interes").ToString())
                  drCl("Interes") = dr("Interes")
               Else
                  Total += Decimal.Parse(dr("ImporteTotal").ToString())
                  drCl("Interes") = 0
               End If
            Else
               If MontoMinimoInteresPermitido < Decimal.Parse(dr("Interes").ToString()) Then
                  Total += Decimal.Parse(dr("Saldo").ToString()) + Decimal.Parse(dr("Interes").ToString())
                  drCl("Interes") = dr("Interes")
               Else
                  Total += Decimal.Parse(dr("Saldo").ToString())
                  drCl("Interes") = 0
               End If

            End If
            drCl("Total") = Total

            drCl("Observacion") = dr("Observacion").ToString()
            drCl("Referencia") = dr("Referencia").ToString()
            drCl("NombreCategoria") = dr("NombreCategoria").ToString()

            drCl("IdPlanCuenta") = dr("IdPlanCuenta")
            drCl("IdAsiento") = dr("IdAsiento")

            drCl("IdClienteCtaCte") = dr("IdClienteCtaCte")
            drCl("CodigoClienteCtaCte") = dr("CodigoClienteCtaCte")
            drCl("NombreClienteCtaCte") = dr("NombreClienteCtaCte")

            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica")
            drCl("Telefono") = dr("Telefono").ToString()

            IdCliente2 = Long.Parse(dr("IdCliente").ToString())

            dt.Rows.Add(drCl)
         Next
      End If

      Return dt

   End Function

   Public Sub ImprimirInformeCtaCteClientes(dt As DataTable,
                                            filtros As String,
                                            ocultarSaldos As Boolean,
                                            esPorCliente As Boolean,
                                            nombreArchivoDestino As String,
                                            esImpresionNormal As Boolean,
                                            tituloPantalla As String,
                                            visualiza As Boolean, correo As String)
      'La impresion utiliza el campo que tiene otros datos (Direccion, Localidad, Cuit, Telefono+Celular, Correo y Transporte.
      For Each dr As DataRow In dt.Rows
         dr("NombreCliente") = dr("NombreCliente2")
      Next

      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtros))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("OcultarSaldo", ocultarSaldos.ToString()))

      '-- REQ-36071.- ------------------------------------------------------------------------------------------                    
      Dim LogoImagen As System.Drawing.Image
      LogoImagen = actual.Logo
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))
      With actual.Sucursal
         '-- Direccion Empresa.- -------------------------------------------------------------------------------
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", .DireccionComercial & " - " & .LocalidadComercial.NombreLocalidad))
         '-- Telefono Empresa.- --------------------------------------------------------------------------------
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", .Telefono))
         '-- Correo Empresa.- ----------------------------------------------------------------------------------
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoEmpresa", .Correo))
      End With
      '-- Web Empresa.- ----------------------------------------------------------------------------------------
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("WebEmpresa", Reglas.Publicos.DireccionWebEmpresa))
      '---------------------------------------------------------------------------------------------------------

      Dim reporte As Entidades.InformePersonalizadoResuelto
      If esPorCliente Then
         reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfCtaCteClientes, "Eniac.Win.ConsultarCtaCteClientes.rdlc")
      Else
         If esImpresionNormal Then
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfCtaCteClientesPorVendedor, "Eniac.Win.ConsultarCtaCteClientesPorVendedor.rdlc")
         Else
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfCtaCteClientesUnoPorHoja, "Eniac.Win.ConsultarCtaCteClientes1PorHoja.rdlc")
         End If
      End If

      If visualiza Then
         Dim frmImprime = New VisorReportes(reporte.NombreArchivo, "DataSetCtaCteClientes_CuentasCorrientes", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias

         frmImprime.Text = tituloPantalla
         frmImprime.WindowState = FormWindowState.Maximized
         If Not String.IsNullOrWhiteSpace(correo) Then
            frmImprime.Destinatarios = correo
         End If
         frmImprime.Show()
      Else
         Dim ePDF = New ExportarPDF()
         ePDF.Run(reporte.NombreArchivo, "DataSetCtaCteClientes_CuentasCorrientes", dt, parm, reporte.ReporteEmbebido, nombreArchivoDestino)
      End If
   End Sub

   Public Sub ImprimirInformeCtaCteClientesDH(dt As DataTable,
                                          filtros As String,
                                          ocultarSaldos As Boolean,
                                          esPorCliente As Boolean,
                                          nombreArchivoDestino As String,
                                          esImpresionNormal As Boolean,
                                          tituloPantalla As String,
                                          visualiza As Boolean, correo As String,
                                          saldoInicial As Decimal,
                                          saldoActual As Decimal,
                                          saldoFinal As Decimal)


      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtros))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicial", saldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", saldoActual.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinal", saldoFinal.ToString()))

      Dim reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfConsultarCtaCteClientesDH, "Eniac.Win.ConsultarCtaCteClientesDH.rdlc")

      If visualiza Then
         Dim frmImprime = New VisorReportes(reporte.NombreArchivo, "SistemaDataSet_CuentasCorrientesDH", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias

         frmImprime.Text = tituloPantalla
         frmImprime.WindowState = FormWindowState.Maximized
         If Not String.IsNullOrWhiteSpace(correo) Then
            frmImprime.Destinatarios = correo
         End If
         frmImprime.Show()
      Else
         Dim ePDF = New ExportarPDF()
         ePDF.Run(reporte.NombreArchivo, "SistemaDataSet_CuentasCorrientesDH", dt, parm, reporte.ReporteEmbebido, nombreArchivoDestino)
      End If
   End Sub

   Public Sub ImprimirInformeCtaCteDetalleClientes(dt As DataTable,
                                                   filtros As String,
                                                   esPorCliente As Boolean,
                                                   nombreArchivoDestino As String,
                                                   esImpresionNormal As Boolean,
                                                   tituloPantalla As String,
                                                   visualiza As Boolean, correo As String)

      For Each dr As DataRow In dt.Rows
         dr("NombreCliente") = dr("NombreCliente2")
      Next

      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      '-- REQ-36071.- ------------------------------------------------------------------------------------------                    
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtros))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Titulo", tituloPantalla))
      '-- REQ-36071.- ------------------------------------------------------------------------------------------                    
      Dim LogoImagen As System.Drawing.Image
      LogoImagen = actual.Logo
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))
      With actual.Sucursal
         '-- Direccion Empresa.- -------------------------------------------------------------------------------
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", .DireccionComercial & " - " & .LocalidadComercial.NombreLocalidad))
         '-- Telefono Empresa.- --------------------------------------------------------------------------------
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", .Telefono))
         '-- Correo Empresa.- ----------------------------------------------------------------------------------
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoEmpresa", .Correo))
      End With
      '-- Web Empresa.- ----------------------------------------------------------------------------------------
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("WebEmpresa", Reglas.Publicos.DireccionWebEmpresa))
      '---------------------------------------------------------------------------------------------------------

      Dim reporte As Entidades.InformePersonalizadoResuelto
      If esPorCliente Then
         reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfCtaCteDetalladoClientes, "Eniac.Win.ConsultarCtaCteDetalleClientes.rdlc")
      Else
         If esImpresionNormal Then
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfCtaCteDetalladoClientesPorVendedor, "Eniac.Win.ConsultarCtaCteDetalleClientesPorVendedor.rdlc")
         Else
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfCtaCteDetalladoClientesUnoPorHoja, "Eniac.Win.ConsultarCtaCteDetalleClientes1PorHoja.rdlc")
         End If
      End If

      If visualiza Then
         Dim frmImprime = New VisorReportes(reporte.NombreArchivo, "SistemaDataSet_CuentasCorrientesPagos", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias

         frmImprime.Text = tituloPantalla
         frmImprime.WindowState = FormWindowState.Maximized
         If Not String.IsNullOrWhiteSpace(correo) Then
            frmImprime.Destinatarios = correo
         End If
         frmImprime.Show()
      Else
         Dim ePDF = New ExportarPDF()
         ePDF.Run(reporte.NombreArchivo, "SistemaDataSet_CuentasCorrientesPagos", dt, parm, reporte.ReporteEmbebido, nombreArchivoDestino)
      End If
   End Sub

   Public Sub ImprimirInformeCtaCteDetalleClientesDH(dt As DataTable,
                                          filtros As String,
                                          nombreArchivoDestino As String,
                                          tituloPantalla As String,
                                          visualiza As Boolean, correo As String,
                                          saldoInicial As Decimal,
                                          saldoActual As Decimal,
                                          saldoFinal As Decimal)


      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtros))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicial", saldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", saldoActual.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinal", saldoFinal.ToString()))

      Dim reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.InfConsultarCtaCteDetalladoClientesDH, "Eniac.Win.ConsultarCtaCteDetClientesDH.rdlc")

      If visualiza Then
         Dim frmImprime = New VisorReportes(reporte.NombreArchivo, "SistemaDataSet_CuentasCorrientesPagosDH", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias

         frmImprime.Text = tituloPantalla
         frmImprime.WindowState = FormWindowState.Maximized
         If Not String.IsNullOrWhiteSpace(correo) Then
            frmImprime.Destinatarios = correo
         End If
         frmImprime.Show()
      Else
         Dim ePDF = New ExportarPDF()
         ePDF.Run(reporte.NombreArchivo, "SistemaDataSet_CuentasCorrientesPagosDH", dt, parm, reporte.ReporteEmbebido, nombreArchivoDestino)
      End If
   End Sub
End Class
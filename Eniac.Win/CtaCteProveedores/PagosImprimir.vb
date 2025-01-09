Public Class PagosImprimir

   Public Sub ImprimirPago(pago As Entidades.CuentaCorrienteProv, visualizar As Boolean)
      ImprimirPago(pago, visualizar, verEstandar:=False)
   End Sub
   Public Sub ImprimirPago(pago As Entidades.CuentaCorrienteProv, visualizar As Boolean, verEstandar As Boolean)
      Dim parm = New ReportParameterCollection() 'List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresa)
      parm.Add("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                 actual.Sucursal.DireccionComercial, actual.Sucursal.Localidad.NombreLocalidad,
                                                 actual.Sucursal.Localidad.IdLocalidad, actual.Sucursal.Localidad.IdProvincia))

      parm.Add("TelefonoEmpresa", actual.Sucursal.Telefono)
      parm.Add("EmpresaCUIT", Reglas.Publicos.CuitEmpresa)
      parm.Add("IIBBEmpresa", Reglas.Publicos.IngresosBrutos)
      parm.Add("InicioActividadEmpresa", Reglas.Publicos.FechaInicioActividades)
      parm.Add("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre)
      parm.Add("Fecha", pago.Fecha)
      parm.Add("TipoYNroDocumento", pago.Proveedor.CodigoProveedor)

      parm.Add("NombreYApellido", pago.Proveedor.NombreProveedor)
      parm.Add("TipoComprobante", pago.TipoComprobante.DescripcionImpresion)
      parm.Add("Letra", pago.Letra)
      parm.Add("CentroEmisor", pago.CentroEmisor)
      parm.Add("Numero", pago.NumeroComprobante)
      parm.Add("Direccion", pago.Proveedor.DireccionProveedor)
      parm.Add("Localidad", New Reglas.Localidades().GetUna(pago.Proveedor.IdLocalidadProveedor).NombreLocalidad)
      parm.Add("CategoriaIVA", pago.Proveedor.CategoriaFiscal.NombreCategoriaFiscal)
      parm.Add("CuitProveedor", pago.Proveedor.CuitProveedor)
      parm.Add("Observacion", pago.Observacion)
      parm.Add("Total", pago.ImporteTotal)
      parm.Add("Efectivo", pago.ImportePesos)
      parm.Add("CuentaBancaria", pago.CuentaBancariaTransfBanc.NombreCuenta)
      parm.Add("TransfBancaria", pago.ImporteTransfBancaria)
      parm.Add("Tarjetas", pago.ImporteTarjetas)
      parm.Add("Tickets", pago.ImporteTickets)
      parm.Add("Retencion", pago.ImporteRetenciones)
      parm.Add("Dolares", pago.ImporteDolares)

      parm.Add("Logo", "LogoMime", actual.Logo)

      'Dim LogoImagen = actual.Logo
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))

      Dim caja = New Reglas.CajasNombres().GetUna(pago.IdSucursal, pago.CajaDetalle.IdCaja)
      parm.Add("Caja", caja.NombreCaja)

      parm.Add("ImprimeSaldos", pago.ImprimeSaldos)
      parm.Add("ImprimeTotalImporte", Reglas.Publicos.CtaCteProv.PagoImprimeTotalImporte)
      parm.Add("ImprimeTotalSaldo", Reglas.Publicos.CtaCteProv.PagoImprimeTotalSaldo)
      parm.Add("ImprimeTotalDescRec", Reglas.Publicos.CtaCteProv.PagoImprimeTotalDescRec)


      Dim totalAplicado = 0D
      Dim SaldosPositivos = 0D
      Dim SaldosNegativos = 0D
      Dim dt1 = New SistemaDataSet.CuentasCorrientesProvPagosDataTable()
      For Each ven In pago.Pagos
         Dim dr1 = dt1.NewCuentasCorrientesProvPagosRow()
         dr1.IdTipoComprobante = ven.TipoComprobante.DescripcionAbrev
         dr1.Letra = ven.Letra
         dr1.CentroEmisor = ven.CentroEmisor
         dr1.NumeroComprobante = ven.NumeroComprobante
         dr1.CuotaNumero = ven.Cuota
         dr1.Fecha = ven.Fecha
         dr1.FechaVencimiento = ven.FechaVencimiento
         dr1.ImporteCuota = ven.ImporteCuota
         dr1.SaldoCuota = ven.SaldoCuota
         dr1.DescripcionFormasPago = ven.FormasPagoDescripcion
         dr1.Paga = ven.Paga
         dr1.DescuentoRecargo = ven.DescuentoRecargo
         dr1.DescuentoRecargoPorc = ven.DescuentoRecargoPorc
         dt1.AddCuentasCorrientesProvPagosRow(dr1)
         If ven.SaldoCuota < 0 Then
            SaldosNegativos += ven.SaldoCuota
         Else
            SaldosPositivos += ven.SaldoCuota
         End If
         totalAplicado = totalAplicado + ven.Paga
      Next

      parm.Add("TotalAplicado", totalAplicado)

      Dim dt2 = New SistemaDataSet.ChequesDataTable()
      For Each ch In pago.ChequesPropios
         Dim dr2 = dt2.NewChequesRow()
         dr2.NumeroCheque = ch.NumeroCheque
         dr2.IdBanco = ch.Banco.IdBanco
         dr2.NombreBanco = ch.Banco.NombreBanco
         dr2.IdBancoSucursal = ch.IdBancoSucursal
         dr2.IdLocalidad = ch.Localidad.IdLocalidad
         'dr2.NombreLocalidad = ch.Localidad.NombreLocalidad   'esta Nothing
         dr2.FechaCobro = ch.FechaCobro
         dr2.FechaEmision = ch.FechaEmision
         dr2.Titular = ""
         dr2.Importe = ch.Importe
         dr2.EsPropio = ch.EsPropio
         dr2.NombreCuenta = ch.CuentaBancaria.NombreCuenta
         dr2.IdTipoCheque = ch.IdTipoCheque
         dr2.NombreTipoCheque = ch.NombreTipoCheque
         dr2.Cuit = ch.Cuit
         dt2.AddChequesRow(dr2)
      Next



      'Dim dt2 As SistemaDataSet.ChequesDataTable = New SistemaDataSet.ChequesDataTable()
      'Dim dr2 As SistemaDataSet.ChequesRow

      For Each ch In pago.ChequesTerceros
         Dim dr2 = dt2.NewChequesRow()
         dr2.NumeroCheque = ch.NumeroCheque
         dr2.IdBanco = ch.Banco.IdBanco
         dr2.NombreBanco = ch.Banco.NombreBanco
         dr2.IdBancoSucursal = ch.IdBancoSucursal
         dr2.IdLocalidad = ch.Localidad.IdLocalidad
         'dr2.NombreLocalidad = ch.Localidad.NombreLocalidad   'esta Nothing
         dr2.FechaCobro = ch.FechaCobro
         dr2.FechaEmision = ch.FechaEmision
         dr2.Titular = ch.Titular
         dr2.Cuit = ch.Cuit
         dr2.Importe = ch.Importe
         dr2.IdTipoCheque = ch.IdTipoCheque
         dr2.NombreTipoCheque = ch.NombreTipoCheque
         dt2.AddChequesRow(dr2)
      Next

      'Ordeno los cheques por fecha de cobro
      Dim dt3 As DataTable = New DataTable()
      Dim dvCheques As New DataView
      dvCheques = dt2.DefaultView
      dvCheques.Sort = "FechaCobro asc"
      dt3 = dvCheques.ToTable()

      '** NO Funciona al estra separado porque la historia tiene Recibos X que aplicaron ambos tipos de comprobantes **
      'If Publicos.CtaCteProveedoresSeparar Then
      '   Dim grabaLibro As String = IIf(pago.TipoComprobante.GrabaLibro, "SI", "NO").ToString()
      '   SaldoActual = New Reglas.CuentasCorrientesProv().GetSaldoProveedor(pago.IdSucursal, pago.Proveedor, pago.Fecha, True, grabaLibro)
      'Else
      Dim saldoActual = New Reglas.CuentasCorrientesProv().GetSaldoProveedor(pago.IdSucursal, pago.Proveedor, pago.Fecha, True)
      'End If
      '----------------------------------------------------------------------------------------------------------------

      parm.Add("SaldoActual", saldoActual)

      Dim pagoImprimeSaldo = Reglas.Publicos.CtaCteProv.PagoImprimeSaldo
      If pagoImprimeSaldo And Not pago.ImprimeSaldos Then
         pagoImprimeSaldo = False
      End If

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ImprimeSaldo", pagoImprimeSaldo.ToString()))
      parm.Add("SaldosPositivos", SaldosPositivos.ToString())
      parm.Add("SaldosNegativos", SaldosNegativos.ToString())

      Dim reporteNombre As String = String.Empty
      Dim reporteEmbebido As Boolean = True

      If pago.TipoComprobante.GrabaLibro Then
         reporteNombre = "Eniac.Win.Pago.rdlc"
      Else
         reporteNombre = "Eniac.Win.PagoProvisorio.rdlc"
      End If

      If Not verEstandar Then
         Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(pago.TipoComprobante.IdTipoComprobante, pago.Letra)
         'Si contiene ";" es porque usa un procedimiento especifico directo al LPTX, 
         'pero ahora esta visualizando asi que lo dejo con el generico.
         If tipoLetra.ArchivoAImprimir <> String.Empty And Not tipoLetra.ArchivoAImprimir.Contains(";") Then
            reporteNombre = tipoLetra.ArchivoAImprimir
            reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
            ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)
            CantidadCopias = tipoLetra.CantidadCopias
            If Not reporteEmbebido Then
               reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
            End If
         End If
      End If

      If visualizar Then
         Using frmImprime = New VisorReportes(reporteNombre, "SistemaDataSet_CuentasCorrientesProvPagos", dt1, "SistemaDataSet_Cheques", dt3, parm, reporteEmbebido, CantidadCopias)
            frmImprime.Text = "Pago"
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.Destinatarios = pago.Proveedor.CorreoElectronico
            frmImprime.ShowDialog()
         End Using
      Else
         Dim imp = New Imprimir(ConfigImprimir)
         imp.Run(reporteNombre, "SistemaDataSet_CuentasCorrientesProvPagos", dt1, "SistemaDataSet_Cheques", dt3, parm, reporteEmbebido, "", pago.TipoComprobante.CantidadCopias, True)
      End If
   End Sub

#Region "Propiedades"
   Private Property _ConfigImprimir As ConfiguracionImprimir
   Public Property ConfigImprimir As ConfiguracionImprimir
      Get
         If _ConfigImprimir Is Nothing Then
            _ConfigImprimir = New ConfiguracionImprimir(0, 0)
         End If
         Return _ConfigImprimir
      End Get
      Set(value As ConfiguracionImprimir)
         _ConfigImprimir = value
      End Set
   End Property

   Private _cantidadCopias As Integer
   Public Property CantidadCopias() As Integer
      Get
         If _cantidadCopias = 0 Then
            Return 1
         Else
            Return _cantidadCopias
         End If
      End Get
      Set(value As Integer)
         _cantidadCopias = value
      End Set
   End Property

#End Region

End Class
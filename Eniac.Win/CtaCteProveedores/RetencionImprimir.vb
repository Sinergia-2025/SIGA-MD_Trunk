Public Class RetencionImprimir

   Public Sub ImprimirRetencion(pago As Entidades.CuentaCorrienteProv)

      Try
         'En algunos hay diferencias. Hay que buscar el error de grabacion!
         'Dim importeARetener As Decimal = 0
         'Dim tipoRetencion As String = ""
         'Dim baseImponible As Decimal = 0
         'Dim alicuota As Decimal = 0
         'Dim nroretencion As Long = 0

         'For Each re As Entidades.RetencionCompra In pago.Retenciones
         '   importeARetener += re.ImporteTotal
         '   baseImponible = re.BaseImponible
         '   alicuota = re.Alicuota
         '   tipoRetencion = New Reglas.TiposImpuestos().GetUno(re.TipoImpuesto.IdTipoImpuesto).NombreTipoImpuesto
         '   nroretencion = re.NumeroRetencion
         'Next

         For Each rete As Entidades.RetencionCompra In pago.Retenciones
            Dim oRetencion As Entidades.RetencionCompra = New Entidades.RetencionCompra
            'oRetencion = New Reglas.RetencionesCompras().GetUno(pago.IdSucursal, _
            '                                                    pago.Retenciones(0).TipoImpuesto.IdTipoImpuesto.ToString(), _
            '                                                    pago.Retenciones(0).EmisorRetencion, _
            '                                                    pago.Retenciones(0).NumeroRetencion, _
            '                                                    pago.Retenciones(0).Proveedor.IdProveedor)
            oRetencion = New Reglas.RetencionesCompras().GetUno(pago.IdSucursal,
                                                                rete.TipoImpuesto.IdTipoImpuesto.ToString(),
                                                                rete.EmisorRetencion,
                                                                rete.NumeroRetencion,
                                                                rete.Proveedor.IdProveedor)

            'creo la coleccion de parametros
            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaOficial))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.Direccion))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CUIT", Reglas.Publicos.CuitEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IngresosBrutos", Reglas.Publicos.IngresosBrutos))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", pago.Fecha.ToString()))

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", pago.Proveedor.CodigoProveedor.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", pago.Proveedor.NombreProveedor))

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", pago.TipoComprobante.Descripcion + "-" + pago.Letra))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", pago.Letra))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CentroEmisor", pago.CentroEmisor.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", pago.NumeroComprobante.ToString()))

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", pago.Proveedor.DireccionProveedor))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", New Reglas.Localidades().GetUna(pago.Proveedor.IdLocalidadProveedor).NombreLocalidad))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CategoriaIVA", pago.Proveedor.CategoriaFiscal.NombreCategoriaFiscal))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CUITProv", pago.Proveedor.CuitProveedor))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IngresosBrutosProv", pago.Proveedor.IngresosBrutos))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", pago.Observacion))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Total", oRetencion.ImporteTotal.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Efectivo", pago.ImportePesos.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CuentaBancaria", pago.CuentaBancariaTransfBanc.NombreCuenta))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TransfBancaria", pago.ImporteTransfBancaria.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tickets", pago.ImporteTarjetas.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("BaseImponible", oRetencion.BaseImponible.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Alicuota", oRetencion.Alicuota.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroRetencion", oRetencion.NumeroRetencion.ToString()))
            'solo muestro el primer regimen por ahora
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoRetencion", oRetencion.Regimen.ConceptoRegimen))

            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tipo", "GANANCIAS"))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tipo", oRetencion.Regimen.TipoImpuesto.NombreTipoImpuesto.ToUpper()))

            Dim dt1 As SistemaDataSet.CuentasCorrientesProvPagosDataTable = New SistemaDataSet.CuentasCorrientesProvPagosDataTable()
            Dim dr1 As SistemaDataSet.CuentasCorrientesProvPagosRow
            Dim TotalAplicado As Decimal = 0

            For Each ven As Entidades.CuentaCorrienteProvPago In pago.Pagos
               dr1 = dt1.NewCuentasCorrientesProvPagosRow()
               dr1.IdTipoComprobante = ven.TipoComprobante.DescripcionAbrev
               dr1.Letra = ven.Letra
               dr1.CentroEmisor = ven.CentroEmisor
               dr1.NumeroComprobante = ven.NumeroComprobante
               dr1.CuotaNumero = ven.Cuota
               dr1.Fecha = ven.Fecha
               dr1.FechaVencimiento = ven.FechaVencimiento
               dr1.ImporteCuota = ven.ImporteCuota
               dr1.Paga = ven.Paga
               dt1.AddCuentasCorrientesProvPagosRow(dr1)
               TotalAplicado = TotalAplicado + ven.Paga
            Next

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalAplicado", TotalAplicado.ToString()))

            Dim dt2 As SistemaDataSet.ChequesDataTable = New SistemaDataSet.ChequesDataTable()
            Dim dr2 As SistemaDataSet.ChequesRow

            For Each ch As Entidades.Cheque In pago.ChequesPropios
               dr2 = dt2.NewChequesRow()
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
               dt2.AddChequesRow(dr2)
            Next

            'Dim dt2 As SistemaDataSet.ChequesDataTable = New SistemaDataSet.ChequesDataTable()
            'Dim dr2 As SistemaDataSet.ChequesRow

            For Each ch As Entidades.Cheque In pago.ChequesTerceros
               dr2 = dt2.NewChequesRow()
               dr2.NumeroCheque = ch.NumeroCheque
               dr2.IdBanco = ch.Banco.IdBanco
               dr2.NombreBanco = ch.Banco.NombreBanco
               dr2.IdBancoSucursal = ch.IdBancoSucursal
               dr2.IdLocalidad = ch.Localidad.IdLocalidad
               'dr2.NombreLocalidad = ch.Localidad.NombreLocalidad   'esta Nothing
               dr2.FechaCobro = ch.FechaCobro
               dr2.FechaEmision = ch.FechaEmision
               dr2.Titular = ch.Titular
               dr2.Importe = ch.Importe
               dt2.AddChequesRow(dr2)
            Next

            Dim SaldoActual As Decimal = 0
            SaldoActual = New Reglas.CuentasCorrientesProv().GetSaldoProveedor(pago.IdSucursal, pago.Proveedor, pago.Fecha, True)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", SaldoActual.ToString()))

            Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Retencion.rdlc", "SistemaDataSet_CuentasCorrientesProvPagos", dt1, "SistemaDataSet_Cheques", dt2, parm, True, 1) '# 1 = Cantidad de Copias
            frmImprime.Text = "Pago"
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.ShowDialog()
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, "Imprimir Retención", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class
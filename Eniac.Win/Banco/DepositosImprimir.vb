Imports Microsoft.Reporting.WinForms
Public Class DepositosImprimir

   Public Sub ImprimirDeposito(deposito As Entidades.Deposito)

      Try
         'creo la coleccion de parametros
         'Dim nombreLogo As String = Entidades.Publicos.CarpetaEniac + "LOGOEMPRESA.jpg"
         Dim nombrelogo As String = Publicos.NombreLogo

         'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
         'Dim logo As System.Drawing.Image = parI.GetValor(Entidades.ParametroImagen.Parametros.LOGOEMPRESA)
         'If logo IsNot Nothing Then
         '   logo.Save(nombreLogo)
         'Else
         '   logo = My.Resources.paper_clip_64
         '   logo.Save(nombreLogo)
         'End If

         Dim parm = New List(Of ReportParameter)

         parm.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New ReportParameter("DireccionEmpresa", actual.Sucursal.DireccionComercial))
         parm.Add(New ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))
         parm.Add(New ReportParameter("TipoComprobante", deposito.TipoComprobante.DescripcionAbrev))
         parm.Add(New ReportParameter("Numero", deposito.NumeroDeposito.ToString()))
         parm.Add(New ReportParameter("CuentaBancaria", deposito.CuentaBancaria.NombreCuenta))
         parm.Add(New ReportParameter("UsoFechaCheque", IIf(deposito.UsoFechaCheque, "SI", "NO").ToString()))
         parm.Add(New ReportParameter("Fecha", deposito.Fecha.ToString()))
         parm.Add(New ReportParameter("Observacion", deposito.Observacion))
         parm.Add(New ReportParameter("Total", deposito.ImporteTotal.ToString()))
         parm.Add(New ReportParameter("Efectivo", deposito.ImportePesos.ToString()))
         parm.Add(New ReportParameter("Dolares", deposito.ImporteDolares.ToString()))
         parm.Add(New ReportParameter("Tarjetas", deposito.ImporteTarjetas.ToString()))
         parm.Add(New ReportParameter("Tickets", deposito.ImporteTickets.ToString()))
         parm.Add(New ReportParameter("FechaAplicado", deposito.FechaAplicado.ToString()))
         parm.Add(New ReportParameter("Caja", deposito.NombreCaja.ToString()))
         'Si es transferencia enviar los datos que faltan
         'Cambiar el orden de las cuentas para que en ambas transferencias muestre de dónde se extrajo y dónde se depositó correctamente.
         If deposito.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" AndAlso deposito.CuentaBancariaDestino.IdCuentaBancaria <> 0 Then
            'If deposito.NumeroDeposito Mod 2 <> 0 Then
            parm.Add(New ReportParameter("NombreCuentaDestino", deposito.CuentaBancariaDestino.NombreCuenta.ToString()))
            'Else
            '   parm.Add(New ReportParameter("NombreCuentaDestino", deposito.CuentaBancaria.NombreCuenta))
            '   parm.Remove(parm.Find(Function(param) param.Name = "CuentaBancaria"))
            '   parm.Add(New ReportParameter("CuentaBancaria", deposito.CuentaBancariaDestino.NombreCuenta.ToString()))
            'End If

            parm.Add(New ReportParameter("Dolares", deposito.ImporteDolares.ToString()))
         End If

         Dim parI = New Reglas.ParametrosImagenes()
         Dim LogoImagen = actual.Logo

         parm.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
         parm.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

         Dim dt1 As SistemaDataSet.ChequesDataTable = New SistemaDataSet.ChequesDataTable()
         Dim dr1 As SistemaDataSet.ChequesRow

         For Each ch As Entidades.Cheque In deposito.ChequesPropios
            dr1 = dt1.NewChequesRow()
            dr1.NumeroCheque = ch.NumeroCheque
            dr1.IdBanco = ch.Banco.IdBanco
            dr1.NombreBanco = ch.Banco.NombreBanco
            dr1.IdBancoSucursal = ch.IdBancoSucursal
            dr1.IdLocalidad = ch.Localidad.IdLocalidad
            'dr1.NombreLocalidad = ch.Localidad.NombreLocalidad   'esta Nothing
            dr1.FechaCobro = ch.FechaCobro
            dr1.FechaEmision = ch.FechaEmision
            'dr1.Titular = ""
            dr1.Importe = ch.Importe
            dt1.AddChequesRow(dr1)
         Next

         Dim dt2 As SistemaDataSet.ChequesDataTable = New SistemaDataSet.ChequesDataTable()
         Dim dr2 As SistemaDataSet.ChequesRow

         For Each ch As Entidades.Cheque In deposito.ChequesTerceros
            dr2 = dt2.NewChequesRow()
            dr2.NumeroCheque = ch.NumeroCheque
            dr2.IdBanco = ch.Banco.IdBanco
            dr2.NombreBanco = ch.Banco.NombreBanco
            dr2.IdBancoSucursal = ch.IdBancoSucursal
            dr2.IdLocalidad = ch.Localidad.IdLocalidad
            'dr2.NombreLocalidad = ch.Localidad.NombreLocalidad   'esta Nothing
            dr2.FechaCobro = ch.FechaCobro
            dr2.FechaEmision = ch.FechaEmision

            If Reglas.Publicos.DepositoMuestraClienteEnLugarDeTitular And Not String.IsNullOrEmpty(ch.Cliente.NombreCliente) Then
               dr2.Titular = ch.Cliente.NombreCliente
            Else
               dr2.Titular = ch.Titular
            End If

            dr2.Cuit = ch.Cuit
            dr2.Importe = ch.Importe
            dt2.AddChequesRow(dr2)
         Next

         '# LLeno el DS de Cuentas de Banco
         Dim dtCBanco As SistemaDataSet.CuentasDeBancoDataTable = New SistemaDataSet.CuentasDeBancoDataTable
         Dim drCBanco As SistemaDataSet.CuentasDeBancoRow
         For Each eCuentaBanco As Entidades.DepositosCuentasBancos In deposito.CuentasBancos
            drCBanco = dtCBanco.NewCuentasDeBancoRow

            drCBanco.IdCuentaBanco = eCuentaBanco.IdCuentaBanco
            drCBanco.NombreCuentaBanco = eCuentaBanco.NombreCuentaBanco
            drCBanco.Importe = eCuentaBanco.Importe
            drCBanco.Observacion = eCuentaBanco.Observacion
            drCBanco.IdTipoCuenta = eCuentaBanco.IdTipoCuenta

            dtCBanco.AddCuentasDeBancoRow(drCBanco)
         Next

         '# Seteo los parámetros de Liquidaciones de Tarjeta para mostrar o no la info correspondiente a la misma
         parm.Add(New ReportParameter("Cupones", If(deposito.TarjetasCupones.Count > 0, Boolean.TrueString, Boolean.FalseString)))
         parm.Add(New ReportParameter("CuentasDeBanco", If(dtCBanco.Count > 0, Boolean.TrueString, Boolean.FalseString)))

         Dim frmImprime As VisorReportes
         '# TRANSFERENCIA
         If deposito.TipoComprobante.IdTipoComprobante = "TRANSFERENCIA" Then
            frmImprime = New VisorReportes("Eniac.Win.Transferencia.rdlc", parm, True, 1) '# 1 = Cantidad de Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.Deposito.rdlc",
                                           "SistemaDataSet_TarjetasCupones",
                                           deposito.TarjetasCupones,
                                           "SistemaDataSet_CuentasDeBancos",
                                           dtCBanco,
                                           "SistemaDataSet_ChequesPropios",
                                           dt1,
                                           "SistemaDataSet_Cheques",
                                           dt2,
                                           parm,
                                           True, 1) '# 1 = Cantidad de Copias '# LIQUIDATARJETA / DEPOSITO
         End If

         frmImprime.Text = If(deposito.TipoComprobante.IdTipoComprobante = "LIQUIDATARJETA", "Liquidación de Tarjeta", "Depósito Bancario")
         frmImprime.rvReporte.DocumentMapCollapsed = True
         frmImprime.Size = New Size(780, 600)
         frmImprime.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, "Imprimir Deposito", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class

Imports Eniac.Entidades

Public Class ExtraccionesImprimir

   Public Sub ImprimirExtraccion(Extraccion As Deposito)

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

         Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.DireccionComercial))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoComprobante", Extraccion.TipoComprobante.DescripcionAbrev))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", Extraccion.NumeroDeposito.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CuentaBancaria", Extraccion.CuentaBancaria.NombreCuenta))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("UsoFechaCheque", IIf(Extraccion.UsoFechaCheque, "SI", "NO").ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Extraccion.Fecha.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", Extraccion.Observacion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Total", Extraccion.ImporteTotal.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Efectivo", Extraccion.ImportePesos.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Dolares", Extraccion.ImporteDolares.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tarjetas", Extraccion.ImporteTarjetas.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tickets", Extraccion.ImporteTickets.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaAplicado", Extraccion.FechaAplicado.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Caja", Extraccion.NombreCaja))

         Dim parI = New Reglas.ParametrosImagenes()
         Dim LogoImagen As Image = actual.Logo

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))

         Dim dt1 = New SistemaDataSet.ChequesDataTable()
         'Dim dr1 As SistemaDataSet.ChequesRow

         For Each ch In Extraccion.ChequesPropios
            Dim dr1 = dt1.NewChequesRow()
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
         'Dim dr2 As SistemaDataSet.ChequesRow

         'For Each ch As Entidades.Cheque In Extraccion.ChequesTerceros
         '   dr2 = dt2.NewChequesRow()
         '   dr2.NumeroCheque = ch.NumeroCheque
         '   dr2.IdBanco = ch.Banco.IdBanco
         '   dr2.NombreBanco = ch.Banco.NombreBanco
         '   dr2.IdBancoSucursal = ch.IdBancoSucursal
         '   dr2.IdLocalidad = ch.Localidad.IdLocalidad
         '   'dr2.NombreLocalidad = ch.Localidad.NombreLocalidad   'esta Nothing
         '   dr2.FechaCobro = ch.FechaCobro
         '   dr2.FechaEmision = ch.FechaEmision

         '   If Publicos.ExtraccionMuestraClienteEnLugarDeTitular And Not String.IsNullOrEmpty(ch.Cliente.NombreCliente) Then
         '      dr2.Titular = ch.Cliente.NombreCliente
         '   Else
         '      dr2.Titular = ch.Titular
         '   End If

         '   dr2.Cuit = ch.Cuit
         '   dr2.Importe = ch.Importe
         '   dt2.AddChequesRow(dr2)
         'Next

         Using frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Extraccion.rdlc", "SistemaDataSet_ChequesPropios", dt1, "SistemaDataSet_Cheques", dt2, parm, True, 1) '# 1 = Cantidad de Copias
            frmImprime.Text = "Extracción Bancaria"
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.ShowDialog()
         End Using

      Catch ex As Exception
         MessageBox.Show(ex.Message, "Imprimir Extracción", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

End Class
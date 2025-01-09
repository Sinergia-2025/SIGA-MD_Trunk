Public Class RecibosImprimir
   Public Function ImprimirRecibo(oRecibo As Entidades.CuentaCorriente, visualizar As Boolean) As Boolean
      Return ImprimirRecibo(oRecibo, visualizar, verEstandar:=False)
   End Function
   Public Function ImprimirRecibo(oRecibo As Entidades.CuentaCorriente, visualizar As Boolean, verEstandar As Boolean) As Boolean
      Dim rep = New ReporteCtaCteClientes()
      rep.ArmarReporteCtaCteClientes(oRecibo, verEstandar)

      If visualizar Then

         Using frmImprime = New VisorReportes(rep.ReporteNombre,
                                              rep.ReporteDataSource, rep.CtaCtePagosDT,
                                              rep.ReporteDataSource2, rep.ChequesDT,
                                              rep.ReporteDataSource3, rep.RetencionesDT,
                                              rep.ReporteDataSource4, rep.TransferenciasDT,
                                              rep.ReporteDataSource5, rep.TarjetasDT,
                                              rep.Parametros, rep.ReporteEmbebido, rep.CantidadCopias)

            frmImprime.Text = oRecibo.TipoComprobante.Descripcion
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.Destinatarios = oRecibo.Cliente.CorreoElectronico
            frmImprime.ShowDialog()
         End Using
      Else
         Dim tipoLetra = New Reglas.TiposComprobantesLetras().GetUno(oRecibo.TipoComprobante.IdTipoComprobante, oRecibo.Letra)

         Dim copias = If(tipoLetra.ArchivoAImprimir <> String.Empty, tipoLetra.CantidadCopias, oRecibo.TipoComprobante.CantidadCopias)
         Dim imp = New Imprimir(rep.ConfigImprimir)

         imp.Run(rep.ReporteNombre, rep.Parametros, rep.ReporteEmbebido, "", copias, seteaMargenes:=False,
                     {Imprimir.NewReportDataSource(rep.ReporteDataSource, rep.CtaCtePagosDT),
                      Imprimir.NewReportDataSource(rep.ReporteDataSource2, rep.ChequesDT),
                      Imprimir.NewReportDataSource(rep.ReporteDataSource3, rep.RetencionesDT),
                      Imprimir.NewReportDataSource(rep.ReporteDataSource4, rep.TransferenciasDT),
                      Imprimir.NewReportDataSource(rep.ReporteDataSource5, rep.TarjetasDT)})
         'imp.Run(rep.ReporteNombre,
         '        rep.ReporteDataSource, rep.CtaCtePagosDT,
         '        rep.ReporteDataSource2, rep.ChequesDT,
         '        rep.ReporteDataSource3, rep.RetencionesDT,
         '        rep.ReporteDataSource4, rep.TransferenciasDT,
         '        rep.Parametros, rep.ReporteEmbebido, "", Copias, seteaMargenes:=False)
      End If
      Return True
   End Function
End Class
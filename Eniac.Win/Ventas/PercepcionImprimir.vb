Public Class PercepcionImprimir

   Public Sub ImprimirPercepcion(venta As Entidades.Venta, oPercepcion As Entidades.PercepcionVenta, VisualizaPercepcion As Boolean, Imprime As Boolean)
      If VisualizaPercepcion Then
         Try
            'creo la coleccion de parametros
            Dim parm = New ReportParameterCollection() '' New List(Of Microsoft.Reporting.WinForms.ReportParameter)

            Dim prov = New Reglas.Provincias().GetUno(oPercepcion.IdProvincia, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
            Dim loc = New Reglas.Localidades().GetUna(venta.Cliente.IdLocalidad, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
            Dim activ = New Reglas.Actividades().GetUno(oPercepcion.IdProvincia, oPercepcion.IdActividad)

            parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
            parm.Add("DireccionEmpresa", actual.Sucursal.Direccion)
            parm.Add("TelefonoEmpresa", actual.Sucursal.Telefono)
            parm.Add("CUIT", Reglas.Publicos.CuitEmpresa)
            parm.Add("Provincia", prov.NombreProvincia.IfNull())
            parm.Add("IngresosBrutos", prov.IngBrutos.IfNull())
            parm.Add("AgenteIngresosBrutos", prov.AgenteIngBrutos.IfNull())
            parm.Add("Fecha", venta.Fecha)
            parm.Add("TipoYNroDocumento", venta.Cliente.CodigoCliente)
            parm.Add("NombreYApellido", venta.Cliente.NombreCliente)
            parm.Add("Comprobante", String.Format("{0}-{1}-{2}-{3}",
                                                  venta.TipoComprobante.Descripcion, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante))
            parm.Add("Letra", venta.LetraComprobante)
            parm.Add("CentroEmisor", venta.CentroEmisor.ToString())
            parm.Add("Numero", venta.NumeroComprobante.ToString())
            parm.Add("Direccion", venta.Cliente.Direccion)
            parm.Add("Localidad", loc.NombreLocalidad)
            parm.Add("CategoriaIVA", venta.Cliente.CategoriaFiscal.NombreCategoriaFiscal)
            parm.Add("CUITProv", venta.Cliente.Cuit)
            parm.Add("IngresosBrutosProv", venta.Cliente.IngresosBrutos)
            parm.Add("Observacion", venta.Observacion)
            parm.Add("Total", oPercepcion.ImporteTotal)
            parm.Add("Efectivo", venta.ImporteTotal)
            parm.Add("CuentaBancaria", venta.CuentaBancariaTransfBanc.NombreCuenta)
            parm.Add("TransfBancaria", venta.ImporteTransfBancaria)
            parm.Add("Tickets", venta.ImporteTarjetas)
            parm.Add("BaseImponible", oPercepcion.BaseImponible)
            parm.Add("Alicuota", oPercepcion.Alicuota)
            parm.Add("NroRetencion", oPercepcion.NumeroPercepcion)
            'solo muestro el primer regimen por ahora
            parm.Add("TipoRetencion", activ.NombreActividad.IfNull())

            Select Case oPercepcion.IdTipoImpuesto
               Case Entidades.TipoImpuesto.Tipos.PIIBB.ToString()
                  parm.Add("Tipo", "INGRESOS BRUTOS")
               Case Entidades.TipoImpuesto.Tipos.PIVA.ToString()
                  parm.Add("Tipo", "IVA")
               Case Else
                  parm.Add("Tipo", "")
            End Select

            Dim dt1 = New SistemaDataSet.CuentasCorrientesPagosDataTable()
            Dim totalAplicado = 0D

            For Each ven As Entidades.CuentaCorrientePago In venta.CuentaCorriente.Pagos
               Dim dr1 = dt1.NewCuentasCorrientesPagosRow()
               dr1.IdTipoComprobante = ven.TipoComprobante.DescripcionAbrev
               dr1.Letra = ven.Letra
               dr1.CentroEmisor = ven.CentroEmisor
               dr1.NumeroComprobante = ven.NumeroComprobante
               dr1.CuotaNumero = ven.Cuota
               dr1.Fecha = ven.FechaEmision
               dr1.FechaVencimiento = ven.FechaVencimiento
               dr1.ImporteCuota = ven.ImporteCuota
               dr1.Paga = ven.Paga
               dt1.AddCuentasCorrientesPagosRow(dr1)
               totalAplicado = totalAplicado + ven.Paga
            Next

            parm.Add("TotalAplicado", totalAplicado)

            Dim saldoActual = New Reglas.CuentasCorrientes().
               GetSaldoCliente({New Entidades.Sucursal() With {.Id = venta.IdSucursal}},
                               venta.Cliente.IdCliente, venta.Fecha, contemplaHora:=True,
                               comprobantesAsociados:="TODOS", grabaLibro:=Nothing,
                               comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty,
                               excluirPreComprobantes:=False,
                               IdCama:=0, IdEmbarcacion:=0)

            parm.Add("SaldoActual", saldoActual)
            If Not Imprime Then
               Dim frmImprime = New VisorReportes("Eniac.Win.Percepcion.rdlc", "SistemaDataSet_CuentasCorrientesProvPagos", dt1, parm, True, 1) '# 1 = Cantidad de Copias
               frmImprime.Text = "Venta"
               frmImprime.rvReporte.DocumentMapCollapsed = True
               frmImprime.Size = New Size(780, 600)
               frmImprime.ShowDialog()
            Else
               Dim imp = New Imprimir(New ConfiguracionImprimir(0, 0))
               imp.Run("Eniac.Win.Percepcion.rdlc", "SistemaDataSet_CuentasCorrientesProvPagos", dt1, parm, True, nombreImpresora:=String.Empty, cantidadCopias:=1)
            End If


         Catch ex As Exception
            Dim stb = New StringBuilder()
            stb.AppendFormatLine("Error imprimiendo percepción: {0:0000}-{1:00000000}",
                                 oPercepcion.IdTipoImpuesto.ToString(), oPercepcion.NumeroPercepcion)
            stb.AppendFormatLine("Del comprobante {0}/{1} {2} {3:0000}-{4:00000000}",
                                 venta.IdSucursal, venta.TipoComprobante.Descripcion, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
            stb.AppendLine()
            stb.AppendFormatLine(ex.Message)

            MessageBox.Show(stb.ToString(), "Imprimir Percepción", MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End If

   End Sub

End Class
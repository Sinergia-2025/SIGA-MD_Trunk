Imports System.Drawing.Imaging
Imports Eniac.Entidades.Extensiones.Encoders
Imports Microsoft.Reporting.WinForms

Public Class ImpresionCuotasCuentasCorrientes

   Private Function GenararReporte(venta As Entidades.Venta) As ValoresReporte
      ' # DT para Cuotas
      Dim dtCuotas = New TurismoDataSet.CuotasDataTable()
      Dim conAnticipo = False

      ' # Datos de las Cuotas

      If venta.CuentaCorriente.Pagos.Count > 0 Then

         For Each cuota In venta.CuentaCorriente.Pagos
            Dim dr = dtCuotas.NewCuotasRow()

            ' # Datos del Cliente
            dr.IdCliente = venta.Cliente.IdCliente
            dr.CodigoCliente = venta.Cliente.CodigoCliente
            dr.NombreCliente = venta.Cliente.NombreCliente
            dr.TipoDocCliente = venta.Cliente.TipoDocCliente
            dr.NroDocCliente = venta.Cliente.NroDocCliente
            dr.Direccion = venta.Cliente.Direccion
            dr.Telefono = venta.Cliente.Telefono
            dr.Localidad = venta.Cliente.Localidad.NombreLocalidad

            ' # Datos de la Cuota
            ' Si existe la Cuota 0, quiere decir que se realizo un Anticipo
            If cuota.Cuota = 0 Then
               conAnticipo = True
            End If
            dr.NumeroCuota = cuota.Cuota
            dr.ImporteCuota1 = cuota.ImporteCuota
            dr.FechaVencimiento1 = cuota.FechaVencimiento.ToString("dd/MM/yyyy")

            ' Verifico si las fechas de vencimiento y los importes correspondientes tienen valores.
            If cuota.ImporteCuota2.HasValue Then
               dr.ImporteCuota2 = cuota.ImporteCuota2.Value
            End If
            If cuota.FechaVencimiento2.HasValue Then
               dr.FechaVencimiento2 = cuota.FechaVencimiento2.Value.ToString("dd/MM/yyyy")
            End If
            If cuota.ImporteCuota3.HasValue Then
               dr.ImporteCuota3 = cuota.ImporteCuota3.Value
            End If
            If cuota.FechaVencimiento3.HasValue Then
               dr.FechaVencimiento3 = cuota.FechaVencimiento3.Value.ToString("dd/MM/yyyy")
            End If

            dr.CodigoBarras = cuota.CodigoDeBarra.ToIDAutomationHL25S()
            dr.CodigoBarrasSirPlus = cuota.CodigoDeBarraSirplus.ToIDAutomationHL25S()
            dr.CodigoPagoSirPlus = Reglas.Publicos.TurismoSIRPLUSIdentifCuenta.ToString("000000000") + venta.Cliente.CodigoCliente.ToString("0000000000")

            dr.FechaViaje = venta.CuentaCorriente.FechaViaje.ToString("dd/MM/yyyy") ' Fecha de Salida
            dr.NombrePrograma = venta.CuentaCorriente.NombrePrograma                ' Destino
            dr.NombreEstablecimiento = venta.CuentaCorriente.NombreEstablecimiento  ' Nombre del Colegio

            ' # Si hay anticipo, resto 1 al Total de Cuotas.
            If conAnticipo Then
               dr.TotalCuotas = venta.CuentaCorriente.Pagos.Count - 1
            Else
               dr.TotalCuotas = venta.CuentaCorriente.Pagos.Count
            End If

            ' # Datos del Comprobante
            dr.IdTipoComprobante = venta.IdTipoComprobante
            dr.NumeroComprobante = venta.NumeroComprobante
            dr.Letra = venta.LetraComprobante
            dr.CentroEmisor = venta.CentroEmisor

            Dim qr = New Reglas.CuentasCorrientesPagos()
            Dim json = qr.GetInfoParaPagoQR(
                                 Integer.Parse(Publicos.CodigoClienteSinergia.ToString()),
                                 venta.Cliente.CodigoCliente,
                                 actual.Sucursal.IdSucursal,
                                 venta.IdTipoComprobante,
                                 venta.LetraComprobante,
                                 venta.CentroEmisor,
                                 cuota.NumeroComprobante,
                                 cuota.Cuota,
                                 cuota.FechaVencimiento,
                                 cuota.ImporteCuota,
                                 cuota.FechaVencimiento2,
                                 cuota.ImporteCuota2,
                                 cuota.FechaVencimiento3,
                                 cuota.ImporteCuota3)

            Dim img As System.Drawing.Image = Ayudante.QRCodeHelper.GenerarQR(json)

            ' # QR & QRMime para la generación del QR en la impresión
            dr.QR = img.ConvertImageToBase64(ImageFormat.Png)
            dr.QRMime = ImageFormat.Png.MimeType

            dtCuotas.Rows.Add(dr)
         Next

         dtCuotas.TableName = "CuotasDataTable"

      Else
         Throw New Exception("No se puede realizar la operación con un comprobante que no tiene Cuotas.")
      End If

      Dim parm = New List(Of ReportParameter)()

      'Datos de la empresa
      parm.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
      parm.Add(New ReportParameter("DireccionEmpresa", actual.Sucursal.DireccionComercial & " - " & actual.Sucursal.LocalidadComercial.NombreLocalidad))
      parm.Add(New ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))

      'Logo
      Dim LogoImagen = actual.Logo
      parm.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
      parm.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

      'Identificación del comprobante
      parm.Add(New ReportParameter("TipoComprobante", venta.TipoComprobante.Descripcion))
      parm.Add(New ReportParameter("Letra", venta.LetraComprobante))
      parm.Add(New ReportParameter("CentroEmisor", venta.Impresora.CentroEmisor.ToString()))
      parm.Add(New ReportParameter("Numero", venta.NumeroComprobante.ToString()))

      Dim tipoLetra = New Reglas.TiposComprobantesLetras().GetUno(venta.TipoComprobante.IdTipoComprobante, venta.LetraComprobante)
      Dim ReporteEmbebido As Boolean = True
      Dim ReporteNombre As String = "Eniac.Win.Cuota.rdlc"

      If tipoLetra.ArchivoAImprimir <> String.Empty And Not tipoLetra.ArchivoAImprimir.Contains(";") Then
         ReporteNombre = tipoLetra.ArchivoAImprimir
         ReporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
         If Not ReporteEmbebido Then
            ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
         End If
      End If

      Return New ValoresReporte() With
         {
            .ReporteNombre = ReporteNombre,
            .ReporteEmbebido = ReporteEmbebido,
            .DtCuotas = dtCuotas,
            .parm = parm
         }

   End Function

   Public Sub Imprimir(venta As Entidades.Venta)
      Dim val = GenararReporte(venta)

      Dim imp = New Imprimir(New ConfiguracionImprimir(0, 0))
      imp.Run(val.ReporteNombre, "CuotasDataTable", val.DtCuotas, val.parm, val.ReporteEmbebido, nombreImpresora:=String.Empty, cantidadCopias:=1)

   End Sub

   Public Sub Ver(venta As Entidades.Venta)
      Dim val = GenararReporte(venta)

      ' # Parámetros: NombreDelReporte, DataSet, DataTable del SubReporte1, Parámetros, Embebido
      Using frmImprime As VisorReportes = New VisorReportes(val.ReporteNombre, val.DtCuotas, val.ReporteEmbebido, val.parm)
         frmImprime.Text = "Ficha"
         frmImprime.ShowDialog()
      End Using

   End Sub

   Public Sub Exportar(venta As Entidades.Venta, pathDestino As String)
      Dim archivoDestino As String = IO.Path.Combine(pathDestino,
                                                     String.Format("{0}_{1}_{2}_{3:0000}_{4:00000000}.pdf",
                                                                   Reglas.Publicos.CuitEmpresa,
                                                                   venta.TipoComprobante.DescripcionAbrev,
                                                                   venta.LetraComprobante,
                                                                   venta.CentroEmisor,
                                                                   venta.NumeroComprobante))

      Dim val = GenararReporte(venta)

      Using pdf = New ExportarPDF()
         pdf.Run(val.ReporteNombre, "CuotasDataTable", val.DtCuotas, val.parm, val.ReporteEmbebido, archivoDestino)
      End Using

   End Sub

   Private Class ValoresReporte
      Public ReporteEmbebido As Boolean
      Public ReporteNombre As String
      Public DtCuotas As TurismoDataSet.CuotasDataTable
      Public parm As List(Of ReportParameter)

   End Class

End Class
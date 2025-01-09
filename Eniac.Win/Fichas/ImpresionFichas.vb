Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class ImpresionFichas
   Public Sub ImprimirFicha(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Short,
                            nroOperacion As Long)

      If Reglas.Publicos.FichasImprimeCobrosFormatoRecibo Then
         Dim rCtaCtePago As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()
         Dim rCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
         Dim impRecibo As RecibosImprimir = New RecibosImprimir()
         Dim dtRecibos As DataTable = rCtaCtePago.GetRecibosDeUnComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, nroOperacion, 0)
         For Each drRecibo As DataRow In dtRecibos.Rows
            Dim recibo As Entidades.CuentaCorriente = rCtaCte.GetUna(Integer.Parse(drRecibo("IdSucursal").ToString()),
                                                                     drRecibo("IdTipoComprobante").ToString(),
                                                                     drRecibo("Letra").ToString(),
                                                                     Integer.Parse(drRecibo("CentroEmisor").ToString()),
                                                                     Long.Parse(drRecibo("NumeroComprobante").ToString()))
            impRecibo.ImprimirRecibo(recibo, True)
         Next
      Else

         Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
         Dim rMarca As Eniac.Reglas.Marcas = New Eniac.Reglas.Marcas()

         Dim ficha As Eniac.Entidades.Venta
         ficha = rVentas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, nroOperacion)


         Dim dtFic As FichasDataSet.FichasProductosDataTable = New FichasDataSet.FichasProductosDataTable()
         Dim drF As FichasDataSet.FichasProductosRow
         For Each fp As Eniac.Entidades.VentaProducto In ficha.VentasProductos
            Dim oMarca As Entidades.Marca = rMarca.GetUna(fp.Producto.IdMarca)
            drF = dtFic.NewFichasProductosRow()
            drF.ProductoDesc = fp.NombreProducto
            drF.Marca = oMarca.NombreMarca
            drF.Cantidad = Convert.ToInt32(fp.Cantidad)
            drF.Precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(fp.PrecioNeto, fp.AlicuotaImpuesto, fp.PorcImpuestoInterno, fp.Producto.ImporteImpuestoInterno, fp.OrigenPorcImpInt)
            dtFic.AddFichasProductosRow(drF)
         Next

         Dim totalCuotas As Decimal = 0
         Dim importeCuota As Decimal = 0
         For Each ctaCtePago As Entidades.CuentaCorrientePago In ficha.CuentaCorriente.Pagos
            'La cuota 0 es el anticipo.
            If ctaCtePago.Cuota = 0 Then
               Continue For
            End If
            totalCuotas += ctaCtePago.ImporteCuota
            importeCuota = ctaCtePago.ImporteCuota
         Next

         Dim pagare As String = String.Empty
         pagare = String.Format("{0} cuotas de $ {1:N2} cada una.------------------------------",
                                ficha.CuentaCorriente.CantidadCuotas,
                                importeCuota)
         'pagare = Me.txtCuotas.Text & " cuotas de $ " & Me.txtImpCuota.Text & " cada una.------------------------------"

         Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

         'Datos de la empresa
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.DireccionComercial & " - " & actual.Sucursal.LocalidadComercial.NombreLocalidad))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))

         'Identificación del comprobante
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoComprobante", ficha.TipoComprobante.Descripcion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", ficha.LetraComprobante))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CentroEmisor", ficha.Impresora.CentroEmisor.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", ficha.NumeroComprobante.ToString()))

         'Condiciones de la operación
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", ficha.Fecha.ToString("dd/MM/yyyy")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", ficha.FormaPago.DescripcionFormasPago))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", ficha.Vendedor.NombreEmpleado))

         'Datos del cliente
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", ficha.Cliente.CodigoCliente.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", ficha.Cliente.NombreCliente))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cuit", "0" & ficha.Cliente.Cuit.Replace("-", "")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", ficha.Direccion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", ficha.Cliente.Telefono + " " + ficha.Cliente.Celular))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", ficha.Localidad.NombreLocalidad))

         'Datos de la operación
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Saldo", totalCuotas.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pagaremos", pagare))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Anticipo", ficha.ImportePesos.ToString()))


         '-- REQ-35891.- ------------------------------------------------------------------------------------------------------------
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoIdentificacionFiscal", ficha.Cliente.TipoDocCliente.ToUpper()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroIdentificacionFiscal", ficha.Cliente.NroDocCliente.ToString()))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Provincia", ficha.Localidad.NombreProvincia))

         If ficha.VentasProductos.Count > 0 Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CantidadProducto", Numeros_A_Letras.EnLetrasSinMoneda(ficha.VentasProductos(0).Cantidad.ToString("N0"))))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProducto", ficha.VentasProductos(0).NombreProducto))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CantidadProducto", "0"))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProducto", ""))
         End If

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ImporteCuotaLetras", Numeros_A_Letras.EnLetrasSinMoneda(importeCuota.ToString())))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ImporteCuotaNumero", importeCuota.ToString()))


         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CantidadCuotasLetras", Numeros_A_Letras.EnLetrasSinMoneda(ficha.CuentaCorriente.CantidadCuotas.ToString())))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CantidadCuotasNumero", ficha.CuentaCorriente.CantidadCuotas.ToString))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ImporteTotalLetras", Numeros_A_Letras.EnLetrasSinMoneda(totalCuotas.ToString())))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ImporteTotalNumero", totalCuotas.ToString()))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DiaFicha", ficha.Fecha.Day.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("MesFicha", ficha.Fecha.GetMonthEnEspanol()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("AñoFicha", ficha.Fecha.Year().ToString()))


         '---------------------------------------------------------------------------------------------------------------------------
         Dim ReporteEmbebido As Boolean = True
         Dim ReporteNombre As String = "Eniac.Win.FichaV2.rdlc"
         Dim ReporteDataSource As String = "FichasDataSet_FichasProductos"

            'Se hizo HARCODE por la reimpresion de la ficha en el Informe de Ventas
            Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno("FICHA", "X")
            ' Dim tipoLetra As  Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(ficha.TipoComprobante.IdTipoComprobante, ficha.LetraComprobante)

            If tipoLetra.ArchivoAImprimir <> String.Empty And Not tipoLetra.ArchivoAImprimir.Contains(";") Then
            CantidadCopias = tipoLetra.CantidadCopias
            ReporteNombre = tipoLetra.ArchivoAImprimir
            ReporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
            If Not ReporteEmbebido Then
               ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
            End If
         End If

         If Not String.IsNullOrEmpty(ficha.FormaPago.ArchivoComplementario) Then
            ReporteEmbebido = ficha.FormaPago.ArchivoAImprimirEmbebido
            CantidadCopias = 1
            If Not ReporteEmbebido Then
               ReporteNombre = "Reportes\" & ficha.FormaPago.ArchivoComplementario
            Else
               ReporteNombre = ficha.FormaPago.ArchivoComplementario
            End If
         End If


         Using frmImprime As VisorReportes = New VisorReportes(ReporteNombre, ReporteDataSource, dtFic, parm, ReporteEmbebido, CantidadCopias)
            frmImprime.Text = "Ficha"
            frmImprime.ShowDialog()
         End Using
      End If
   End Sub

   Public Sub ImprimirFichaCtaCte(idSucursal As Integer,
                             idTipoComprobante As String,
                             letra As String,
                             centroEmisor As Short,
                             nroOperacion As Long,
                             dt As DataTable)



      Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()

      Dim ficha As Eniac.Entidades.Venta
      ficha = rVentas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, nroOperacion)

      Dim totalCuotas As Decimal = 0
      Dim importeCuota As Decimal = 0
      For Each ctaCtePago As Entidades.CuentaCorrientePago In ficha.CuentaCorriente.Pagos
         'La cuota 0 es el anticipo.
         If ctaCtePago.Cuota = 0 Then
            Continue For
         End If
         totalCuotas += ctaCtePago.ImporteCuota
         importeCuota = ctaCtePago.ImporteCuota
      Next

      Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      'Datos de la empresa
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.DireccionComercial & " - " & actual.Sucursal.LocalidadComercial.NombreLocalidad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))

      'Identificación del comprobante
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoComprobante", ficha.TipoComprobante.Descripcion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", ficha.LetraComprobante))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CentroEmisor", ficha.Impresora.CentroEmisor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", ficha.NumeroComprobante.ToString()))

      'Condiciones de la operación
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", ficha.Fecha.ToString("dd/MM/yyyy")))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", ficha.FormaPago.DescripcionFormasPago))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", ficha.Vendedor.NombreEmpleado))

      'Datos del cliente
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", ficha.Cliente.CodigoCliente.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", ficha.Cliente.NombreCliente))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cuit", "0" & ficha.Cliente.Cuit.Replace("-", "")))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", ficha.Direccion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", ficha.Cliente.Telefono + " " + ficha.Cliente.Celular))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", ficha.Localidad.NombreLocalidad))

      'Datos de la operación
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Saldo", totalCuotas.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Anticipo", ficha.ImportePesos.ToString()))

      Using frmImprime As VisorReportes = New VisorReportes("Eniac.Win.FichaCtaCte.rdlc", "FichasDataSet_FichaCtaCte", dt, parm, CantidadCopias)
         frmImprime.Text = "Ficha Cuenta Cliente"
         frmImprime.ShowDialog()
      End Using

   End Sub

   Public Sub ImprimirFichaCliente(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Short,
                                   nroOperacion As Long)

      Dim rVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()

      Dim ficha As Eniac.Entidades.Venta
      ficha = rVentas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, nroOperacion)


      Dim dtFic As FichasDataSet.FichasProductosDataTable = New FichasDataSet.FichasProductosDataTable()
      Dim drF As FichasDataSet.FichasProductosRow
      For Each fp As Eniac.Entidades.VentaProducto In ficha.VentasProductos
         drF = dtFic.NewFichasProductosRow()
         drF.ProductoDesc = fp.NombreProducto
         drF.Cantidad = Convert.ToInt32(fp.Cantidad)
         'drF.Precio = fp.Precio + fp.ImporteImpuesto + fp.ImporteImpuestoInterno
         drF.Precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(fp.PrecioNeto, fp.AlicuotaImpuesto, fp.PorcImpuestoInterno, fp.Producto.ImporteImpuestoInterno, fp.OrigenPorcImpInt)
         dtFic.AddFichasProductosRow(drF)
      Next

      Dim dtPag As FichasDataSet.FichasPagosDataTable = New FichasDataSet.FichasPagosDataTable()
      Dim drP As FichasDataSet.FichasPagosRow = Nothing
      Dim cont As Integer = 5
      Dim contMax As Integer = 5
      Dim nroCuota As Integer = 0
      'Dim anticipo As Boolean = True
      For Each fp As Eniac.Entidades.CuentaCorrientePago In ficha.CuentaCorriente.Pagos
         'El primer registro es siempre el anticipo. Lo debo ignorar.
         If fp.Cuota = 0 Then Continue For
         If fp.ImporteCuota <> 0 Then
            nroCuota += 1
            If cont = contMax Then
               drP = dtPag.NewFichasPagosRow()
               cont = 0
            End If
            If cont = 0 Then
               drP.NroOperacion = Convert.ToInt32(fp.NumeroComprobante)
               drP.TipoDocumento = ""
               drP.NroDocumento = ""
               drP.NroCuota = nroCuota
               drP.FechaVencimiento = fp.FechaVencimiento
               drP.Importe = fp.ImporteCuota
            End If
            If cont = 1 Then
               drP.NroCuota1 = nroCuota
               drP.FechaVencimiento1 = fp.FechaVencimiento
               drP.Importe1 = fp.ImporteCuota
            End If
            If cont = 2 Then
               drP.NroCuota2 = nroCuota
               drP.FechaVencimiento2 = fp.FechaVencimiento
               drP.Importe2 = fp.ImporteCuota
            End If
            If cont = 3 Then
               drP.NroCuota3 = nroCuota
               drP.FechaVencimiento3 = fp.FechaVencimiento
               drP.Importe3 = fp.ImporteCuota
            End If
            If cont = 4 Then
               drP.NroCuota4 = nroCuota
               drP.FechaVencimiento4 = fp.FechaVencimiento
               drP.Importe4 = fp.ImporteCuota
            End If
            cont += 1
            If cont = contMax Then
               dtPag.AddFichasPagosRow(drP)
            End If
         End If
      Next
      If cont <> contMax Then
         dtPag.AddFichasPagosRow(drP)
      End If

      Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      'Datos de la empresa
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.DireccionComercial & " - " & actual.Sucursal.LocalidadComercial.NombreLocalidad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))

      'Identificación del comprobante
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoComprobante", ficha.TipoComprobante.Descripcion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", ficha.LetraComprobante))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CentroEmisor", ficha.Impresora.CentroEmisor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", ficha.NumeroComprobante.ToString()))

      'Condiciones de la operación
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", ficha.Fecha.ToString("dd/MM/yyyy")))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", ficha.FormaPago.DescripcionFormasPago))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", ficha.Vendedor.NombreEmpleado))

      'Datos del cliente
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", ficha.Cliente.CodigoCliente.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", ficha.Cliente.NombreCliente))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cuit", "0" & ficha.Cliente.Cuit.Replace("-", "")))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", ficha.Direccion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", ficha.Cliente.Telefono + " " + ficha.Cliente.Celular))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", ficha.Localidad.NombreLocalidad))

      Dim reporte As Entidades.InformePersonalizadoResuelto

      reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.FichaParaClientes, "Eniac.Win.FichaClienteV2.rdlc")

      Dim frmImprime As VisorReportes = New VisorReportes(reporte.NombreArchivo, "FichasDataSet_FichasProductos", dtFic, "FichasDataSet_FichasPagos", dtPag, parm, reporte.ReporteEmbebido, CantidadCopias)
      frmImprime.Text = "Ficha Cliente"
      frmImprime.ShowDialog()

   End Sub

   Public Sub ImprimirRecibo(ByVal pag As Eniac.Entidades.CuentaCorriente)
      If Reglas.Publicos.FichasImprimeCobrosFormatoRecibo Then
         Dim impRecibo As RecibosImprimir = New RecibosImprimir()
         impRecibo.ImprimirRecibo(pag, True)
      Else
         'recupero si existen ajuste
         'Dim oFA As Eniac.Reglas.FichasPagosAjustes = New Eniac.Reglas.FichasPagosAjustes()

         'recupero los datos del cliente
         'Dim oCl As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
         Dim cliente As Eniac.Entidades.Cliente = pag.Cliente

         Dim pagos As List(Of Entidades.FichaPagoDetalle) = New List(Of Entidades.FichaPagoDetalle)()

         Dim ficha As Entidades.Venta = Nothing
         'calculo monto
         Dim intereses As Double = 0
         Dim concepto As String = pag.Observacion
         Dim monto As Decimal = 0
         For Each pago As Entidades.CuentaCorrientePago In pag.Pagos
            If pago.IdTipoComprobante = "FICHAS" Then
               If ficha Is Nothing Then ficha = New Reglas.Ventas().GetUna(pago.IdSucursal, pago.IdTipoComprobante, pago.Letra, Convert.ToInt16(pago.CentroEmisor), pago.NumeroComprobante)
               monto += pago.Paga
               pagos.Add(New Entidades.FichaPagoDetalle(Convert.ToInt32(pago.NumeroComprobante), pago.Cuota, pago.Paga))
            Else
               intereses += pago.Paga
            End If
         Next


         'obtengo el nombre del o los productos
         'Dim oFPro As Eniac.Reglas.FichasProductos = New Eniac.Reglas.FichasProductos()
         Dim produc As List(Of Eniac.Entidades.VentaProducto) = ficha.VentasProductos

         Dim productos As String = "  "
         For Each pr As Eniac.Entidades.VentaProducto In produc
            productos += pr.NombreProducto + " / "
         Next
         productos = productos.Substring(0, productos.Length - 2)

         'creo la coleccion de parametros
         Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

         'Datos de la empresa
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.DireccionComercial & " - " & actual.Sucursal.LocalidadComercial.NombreLocalidad))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))

         'Identificación del comprobante
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoComprobante", pag.TipoComprobante.Descripcion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", pag.Letra))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CentroEmisor", pag.CentroEmisor.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", pag.NumeroComprobante.ToString()))

         'Condiciones de la operación
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", pag.Fecha.ToString("dd/MM/yyyy")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", pag.FormaPago.DescripcionFormasPago))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", pag.Vendedor.NombreEmpleado))

         'Datos del cliente
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", cliente.CodigoCliente.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", cliente.NombreCliente))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cuit", "0" & cliente.Cuit.Replace("-", "")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", cliente.Direccion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", cliente.Telefono + " " + cliente.Celular))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", cliente.Localidad.NombreLocalidad))

         'Datos de la operación
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Monto", monto.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Productos", productos))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Intereses", intereses.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Concepto", concepto))


         Using frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ReciboPagoV2.rdlc", "SistemaDataSet_FichasPagosDetalle", pagos, parm, CantidadCopias) '# 1 = Cantidad Copias
            frmImprime.Text = "Recibo pago"
            frmImprime.ShowDialog()
         End Using
      End If
   End Sub

#Region "Propiedades"
   Private _cantidadCopias As Integer
   Public Property CantidadCopias() As Integer
      Get
         If _cantidadCopias = 0 Then
            Return 1
         Else
            Return _cantidadCopias
         End If
      End Get
      Set(ByVal value As Integer)
         _cantidadCopias = value
      End Set
   End Property
#End Region

End Class
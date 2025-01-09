Imports Microsoft.Reporting.WinForms
Public Class ImpresionPedidos
   Private _puedeVerPrecios As Boolean
   Public Sub ImprimirPedidoDetallado(oPedido As Entidades.Pedido, Visualizar As Boolean)
      ImprimirPedido(oPedido, Visualizar, "Eniac.Win.PedidoV2Detalle.rdlc", True)
   End Sub
   Public Sub ImprimirPedido(oPedido As Entidades.Pedido, Visualizar As Boolean)
      Dim tipoLetra As Entidades.TipoComprobanteLetra
      tipoLetra = New Reglas.TiposComprobantesLetras().GetUno(oPedido.TipoComprobante.IdTipoComprobante, oPedido.LetraComprobante)

      Dim reporteNombre As String = "Eniac.Win.PedidoV2.rdlc"
      _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "ImpresionPedidos-VerPre")
      If oPedido.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRESUPCLIE.ToString() Then
         reporteNombre = "Eniac.Win.Presupuesto.rdlc"
         _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "ImpresionPresupuestos-VerPre")
      End If
      Dim reporteEmbebido As Boolean = True

      If tipoLetra IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir) Then
         reporteNombre = tipoLetra.ArchivoAImprimir
         reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
         ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)
         If Not reporteEmbebido Then
            reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
         End If
      End If

      If (oPedido.IdMoneda = 2 Or oPedido.Cliente.UsaArchivoAImprimir2) AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir2) Then
         reporteNombre = tipoLetra.ArchivoAImprimir2
         reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido2
         ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir2, tipoLetra.DesplazamientoYArchivoAImprimir2)
         If Not reporteEmbebido Then
            reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir2
         End If
      End If

      ImprimirPedido(oPedido, Visualizar, reporteNombre, reporteEmbebido)
   End Sub
   Private Sub ImprimirPedido(oPedido As Entidades.Pedido, Visualizar As Boolean, reporteNombre As String, reporteEmbebido As Boolean)
      Try
         Dim categoriaFiscalEmpresa As Entidades.CategoriaFiscal
         categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         Dim reporteDataSource As String '= "dtsPedido_dtPedido"
         reporteDataSource = "SistemaDataSet_VentasProductos"  ' Cambio para poder usar las impresiones de comprobantes al querer imprimir un pedido.
         Dim titulo As String = oPedido.TipoComprobante.Descripcion

         Dim sucursal As Entidades.Sucursal = New Reglas.Sucursales().GetUna(oPedido.IdSucursal, False)

         Dim dtReporte As DataTable
         dtReporte = New Reglas.PedidosProductos().GetPedidosProductos(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante,
                                                                       oPedido.CentroEmisor, oPedido.NumeroPedido)

         '# Cantidad: la cantidad visualizada es la cantidad igresada manualmente
         For Each dr As DataRow In dtReporte.Rows
            dr("Cantidad") = dr("CantidadManual")
         Next

         dtReporte.Columns.Add("DescuentoProducto", GetType(Decimal))
         dtReporte.Columns.Add("DescuentoProductoPorc1", GetType(Decimal))
         dtReporte.Columns.Add("DescuentoProductoPorc2", GetType(Decimal))
         dtReporte.Columns.Add("DescuentoProductoPorcCompuesto", GetType(Decimal))

         'El reporte de Pedidos no lo usa, pero se pueden usar los reportes de VENTA por lo que es necesario.
         Dim dtVO As SistemaDataSet.VentasObservacionesDataTable = New SistemaDataSet.VentasObservacionesDataTable()
         Dim drVO As SistemaDataSet.VentasObservacionesRow
         Dim vProvision As String = String.Empty

         For Each vo As Entidades.PedidoObservacion In oPedido.PedidosObservaciones

            drVO = dtVO.NewVentasObservacionesRow()

            drVO.IdSucursal = vo.IdSucursal
            drVO.IdTipoComprobante = vo.IdTipoComprobante
            drVO.Letra = vo.Letra
            drVO.CentroEmisor = vo.CentroEmisor
            drVO.NumeroComprobante = vo.NumeroPedido
            drVO.Linea = vo.Linea
            drVO.Observacion = vo.Observacion
            drVO.IdTipoObservacion = vo.IdTipoObservacion
            drVO.Descripcion = vo.DescripcionTipoObservacion

            dtVO.AddVentasObservacionesRow(drVO)
         Next



         Dim dtVC As SistemaDataSet.VentasContactosDataTable = New SistemaDataSet.VentasContactosDataTable()
         Dim drVC As SistemaDataSet.VentasContactosRow

         For Each vo As Entidades.PedidoClienteContacto In oPedido.PedidosContactos

            drVC = dtVC.NewVentasContactosRow()

            drVC.IdSucursal = vo.IdSucursal
            drVC.IdTipoComprobante = vo.IdTipoComprobante
            drVC.Letra = vo.Letra
            drVC.CentroEmisor = vo.CentroEmisor
            drVC.NumeroComprobante = vo.NumeroPedido
            drVC.IdCliente = vo.IdCliente.ToInteger()
            drVC.IdContacto = vo.IdContacto.ToString()
            drVC.NombreContacto = vo.Contacto.NombreContacto
            drVC.CorreoElectronico = vo.Contacto.CorreoElectronico
            drVC.Telefono = vo.Contacto.Telefono

            dtVC.AddVentasContactosRow(drVC)
         Next

         Dim parm = New List(Of ReportParameter)()

         Dim gb = oPedido.PedidosObservaciones.GroupBy(Function(o) o.IdTipoObservacion)
         For Each g In gb
            Dim texto = String.Join(Environment.NewLine, g.ToList().ConvertAll(Function(o) o.Observacion))
            parm.Add(New ReportParameter(String.Format("ObsDetalladaTipo{0:00}", g.Key), texto))
         Next

         parm.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
         parm.Add(New ReportParameter("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                                        actual.Sucursal.Direccion,
                                                                        actual.Sucursal.Localidad.NombreLocalidad,
                                                                        actual.Sucursal.Localidad.IdLocalidad,
                                                                        actual.Sucursal.Localidad.IdProvincia)))

         parm.Add(New ReportParameter("TelefonoEmpresa", sucursal.Telefono))

         parm.Add(New ReportParameter("fechaPedido", oPedido.Fecha.ToShortDateString()))
         parm.Add(New ReportParameter("doc", oPedido.Cliente.CodigoCliente.ToString()))
         parm.Add(New ReportParameter("nombre", If(oPedido.Cliente.EsClienteGenerico, oPedido.NombreClienteGenerico, oPedido.Cliente.NombreCliente)))

         parm.Add(New ReportParameter("IdTipoComprobante", oPedido.TipoComprobante.Descripcion.ToString()))
         parm.Add(New ReportParameter("DescripcionImpresion", oPedido.TipoComprobante.DescripcionImpresion))
         parm.Add(New ReportParameter("Letra", oPedido.LetraComprobante.ToString))
         parm.Add(New ReportParameter("CentroEmisor", oPedido.CentroEmisor.ToString))
         parm.Add(New ReportParameter("NumeroPedido", oPedido.NumeroPedido.ToString))
         parm.Add(New ReportParameter("ObservacionPedido", oPedido.Observacion.ToString()))
         parm.Add(New ReportParameter("NumeroOrdenCompra", oPedido.NumeroOrdenCompra.ToString()))

         Dim cliente As Entidades.Cliente = New Reglas.Clientes().GetUnoPorCodigo(oPedido.Cliente.CodigoCliente, soloActivos:=False)

         parm.Add(New ReportParameter("Cliente_Direccion", oPedido.Cliente.Direccion))
         parm.Add(New ReportParameter("Cliente_Localidad", oPedido.Cliente.Localidad.NombreLocalidad))
         parm.Add(New ReportParameter("Cliente_CodigoPostal", oPedido.Cliente.Localidad.IdLocalidad.ToString()))
         parm.Add(New ReportParameter("Cliente_Provincia", oPedido.Cliente.Localidad.NombreProvincia))

         parm.Add(New ReportParameter("Direccion", oPedido.Direccion))
         Dim localidad As Entidades.Localidad = New Reglas.Localidades().GetUna(oPedido.IdLocalidad.IfNull())
         parm.Add(New ReportParameter("Localidad", localidad.NombreLocalidad))
         parm.Add(New ReportParameter("Provincia", localidad.NombreProvincia))

         parm.Add(New ReportParameter("CategoriaIVA", cliente.CategoriaFiscal.NombreCategoriaFiscal))
         parm.Add(New ReportParameter("Cuit", "0" + If(oPedido.Cliente.EsClienteGenerico, oPedido.Cuit, oPedido.Cliente.Cuit)))

         '--------------------------------------------------------------------------------------------------------
         Dim rEntrega = New Reglas.PlazosEntregas().GetUno(oPedido.IdPlazoEntrega).DescripcionPlazoEntrega.ToString()
         parm.Add(New ReportParameter("Entrega", rEntrega))

         parm.Add(New ReportParameter("Moneda", New Reglas.Monedas().GetUna(oPedido.IdMoneda).Simbolo.ToString()))
         parm.Add(New ReportParameter("Validez", oPedido.ValidezPresupuesto.ToString()))

         parm.Add(New ReportParameter("FormaPagoExtendida", oPedido.FormaPago.Descripcion))

         parm.Add(New ReportParameter("Pais", New Reglas.Paises().GetUno(New Reglas.Provincias().GetUno(localidad.IdProvincia).IdPais).NombrePais))

         parm.Add(New ReportParameter("ResponsableDisTribucion", oPedido.Transportista.NombreTransportista))

         parm.Add(New ReportParameter("Total_EnLetras", Eniac.Win.Numeros_A_Letras.EnLetrasSinMoneda(oPedido.ImporteTotal.ToString())))

         parm.Add(New ReportParameter("Provision", vProvision))
         '--------------------------------------------------------------------------------------------------------

         If oPedido.IdFormaPago.HasValue AndAlso oPedido.FormaPago IsNot Nothing Then
            parm.Add(New ReportParameter("FormaPago", oPedido.FormaPago.DescripcionFormasPago.ToString()))
            parm.Add(New ReportParameter("IdFormasPago", oPedido.FormaPago.IdFormasPago.ToString()))
         Else
            parm.Add(New ReportParameter("FormaPago", String.Empty))
            parm.Add(New ReportParameter("IdFormasPago", "0"))
         End If
         If oPedido.Vendedor IsNot Nothing Then
            parm.Add(New ReportParameter("Vendedor", oPedido.Vendedor.NombreEmpleado))
         Else
            parm.Add(New ReportParameter("Vendedor", String.Empty))
         End If

         Dim DiscriminaIVA As Boolean = oPedido.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado
         parm.Add(New ReportParameter("DiscriminaIVA", DiscriminaIVA.ToString()))

         If oPedido.PedidosContactos.Count > 0 Then
            Dim contacto As Entidades.PedidoClienteContacto = oPedido.PedidosContactos(0)
            parm.Add(New ReportParameter("Contacto", contacto.Contacto.NombreContacto))
            parm.Add(New ReportParameter("CorreoContacto", contacto.Contacto.CorreoElectronico))
            parm.Add(New ReportParameter("TelefonoContacto", contacto.Contacto.Telefono))
         Else
            parm.Add(New ReportParameter("Contacto", String.Empty))
            parm.Add(New ReportParameter("CorreoContacto", String.Empty))
            parm.Add(New ReportParameter("TelefonoContacto", String.Empty))
         End If

         '-- REQ-36051.- -------------------------------------------------------------------------------------------------
         parm.Add(New ReportParameter("MuestraHoraVenta", Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraHoraVenta.ToString()))
         '----------------------------------------------------------------------------------------------------------------
         parm.Add(New ReportParameter("VerValidez", Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraValidezPresupuesto.ToString()))
         ' vv DE ACÁ HACIA ABAJO VAN LOS PARAMETROS NECESARIO PARA PODER USAR Comprobante.rdlc

         Dim TotalImpuestos As Decimal = oPedido.TotalImpuestos
         Dim TotalImpuestoInterno As Decimal = oPedido.TotalImpuestoInterno

         If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
            With oPedido
               .ImporteBruto = .ImporteBruto + ((.TotalImpuestos + .TotalImpuestoInterno) / (1 + (.DescuentoRecargoPorc / 100)))
               .DescuentoRecargo = (oPedido.ImporteBruto) * (.DescuentoRecargoPorc / 100)
               .SubTotal = .SubTotal + .TotalImpuestos + .TotalImpuestoInterno
               .TotalImpuestos = 0
            End With
            TotalImpuestos = 0
            TotalImpuestoInterno = 0
         End If

         parm.Add(New ReportParameter("Observacion", oPedido.Observacion.ToString()))
         parm.Add(New ReportParameter("TipoComprobante", oPedido.TipoComprobante.Descripcion))
         parm.Add(New ReportParameter("TipoImpresionFiscal", Reglas.Publicos.TipoImpresionFiscal.ToString()))


         Dim dias As Integer = 0
         If oPedido.FormaPago IsNot Nothing Then dias = oPedido.FormaPago.Dias
         parm.Add(New ReportParameter("FormaPagoDias", dias.ToString()))
         parm.Add(New ReportParameter("IdCategoriaFiscal", oPedido.CategoriaFiscal.IdCategoriaFiscal.ToString()))
         parm.Add(New ReportParameter("NombreFantasia", Reglas.Publicos.NombreFantasia))
         parm.Add(New ReportParameter("NombreDeFantasia", Reglas.Publicos.NombreFantasia))

         parm.Add(New ReportParameter("TipoYNroDocumento", cliente.CodigoCliente.ToString()))
         parm.Add(New ReportParameter("NombreYApellido", If(oPedido.Cliente.EsClienteGenerico, oPedido.NombreClienteGenerico, oPedido.Cliente.NombreCliente)))

         If oPedido.ClienteVinculado IsNot Nothing Then
            parm.Add(New ReportParameter("TieneClienteVinculado", Boolean.TrueString))
            parm.Add(New ReportParameter("CodigoClienteVinculado", oPedido.CodigoClienteVinculado.ToString()))
            parm.Add(New ReportParameter("NombreClienteVinculado", oPedido.NombreClienteVinculado))
         Else
            parm.Add(New ReportParameter("TieneClienteVinculado", Boolean.FalseString))
            parm.Add(New ReportParameter("CodigoClienteVinculado", String.Empty))
            parm.Add(New ReportParameter("NombreClienteVinculado", String.Empty))
         End If

         '# Transportista DEL CLIENTE
         parm.Add(New ReportParameter("TransportistaClienteNombre", oPedido.Cliente.NombreTransportista))

         parm.Add(New ReportParameter("Telefono", cliente.Telefono & " " & cliente.Celular))
         parm.Add(New ReportParameter("Fecha", oPedido.Fecha.ToString()))
         parm.Add(New ReportParameter("Numero", oPedido.NumeroPedido.ToString()))
         parm.Add(New ReportParameter("FechaHasta", oPedido.Fecha.AddDays(Reglas.Publicos.DiasValidezPresupuesto).ToString()))

         'If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
         '   oPedido.ImporteBruto = oPedido.ImporteBruto + oPedido.TotalImpuestos + oPedido.TotalImpuestoInterno ''- oPedido.TotalImpuestosVarios 
         '   oPedido.SubTotal = oPedido.SubTotal + oPedido.TotalImpuestos + oPedido.TotalImpuestoInterno ''- oPedido.TotalImpuestosVarios 
         'End If

         If _puedeVerPrecios Then
            parm.Add(New ReportParameter("Bruto", oPedido.ImporteBruto.ToString()))
            parm.Add(New ReportParameter("Subtotal", oPedido.SubTotal.ToString()))

            parm.Add(New ReportParameter("DescuentoRecargo", oPedido.DescuentoRecargo.ToString()))
            parm.Add(New ReportParameter("TotalIVA", TotalImpuestos.ToString()))
            parm.Add(New ReportParameter("TotalImpuestosVarios", "0"))
            parm.Add(New ReportParameter("TotalImpuestosInternos", TotalImpuestoInterno.ToString()))
            parm.Add(New ReportParameter("Total", oPedido.ImporteTotal.ToString()))
         Else
            parm.Add(New ReportParameter("Bruto", "0"))
            parm.Add(New ReportParameter("Subtotal", "0"))

            parm.Add(New ReportParameter("DescuentoRecargo", "0"))
            parm.Add(New ReportParameter("TotalIVA", "0"))
            parm.Add(New ReportParameter("TotalImpuestosVarios", "0"))
            parm.Add(New ReportParameter("TotalImpuestosInternos", "0"))
            parm.Add(New ReportParameter("Total", "0"))
         End If

         parm.Add(New ReportParameter("DescuentoRecargoPorc", oPedido.DescuentoRecargoPorc.ToString()))

         parm.Add(New ReportParameter("Kilos", oPedido.Kilos.ToString()))
         parm.Add(New ReportParameter("DecimalesEnCantidad", If(Reglas.Publicos.ProductoUtilizaCantidadesEnteras, "0", "2")))
         parm.Add(New ReportParameter("DecimalesEnPrecio", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString()))
         parm.Add(New ReportParameter("DecimalesEnTotalXProducto", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto.ToString()))
         parm.Add(New ReportParameter("DescripcionAdicionalEmpresa", Reglas.Publicos.DescripcionAdicionalEmpresa.ToString()))
         parm.Add(New ReportParameter("eMail", actual.Sucursal.Correo.ToString()))
         parm.Add(New ReportParameter("web", Reglas.Publicos.DireccionWebEmpresa))
         parm.Add(New ReportParameter("ZonaGeografica", oPedido.Cliente.ZonaGeografica.IdZonaGeografica))

         parm.Add(New ReportParameter("TotalKilos", oPedido.Kilos.ToString()))
         parm.Add(New ReportParameter("TotalProductos", oPedido.CantidadProductos.ToString()))
         parm.Add(New ReportParameter("MuestraTotalKilos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalKilos.ToString()))
         parm.Add(New ReportParameter("MuestraTotalProductos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalProductos.ToString()))


         parm.Add(New ReportParameter("MuestraSaldo", Boolean.FalseString))
         parm.Add(New ReportParameter("SaldoActual", "0"))
         parm.Add(New ReportParameter("CotizacionDolar", oPedido.CotizacionDolar.ToString()))
         parm.Add(New ReportParameter("Coeficiente", "1"))

         parm.Add(New ReportParameter("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre))
         parm.Add(New ReportParameter("FechaInicioActividades", Reglas.Publicos.FechaInicioActividades.ToString()))

         parm.Add(New ReportParameter("IngresosBrutos", Reglas.Publicos.IngresosBrutos))
         parm.Add(New ReportParameter("EmpresaCUIT", Reglas.Publicos.CuitEmpresa))
         parm.Add(New ReportParameter("eMail", actual.Sucursal.Correo))
         parm.Add(New ReportParameter("Web", Reglas.Publicos.DireccionWebEmpresa))
         parm.Add(New ReportParameter("CantidadDecimalesCantidad", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()))
         parm.Add(New ReportParameter("HorarioClienteCompleto", oPedido.Cliente.HorarioClienteCompleto))
         parm.Add(New ReportParameter("SaldoActualCtaCte", oPedido.SaldoActualCtaCte.ToString()))

         Dim nombreLogo As String = Publicos.NombreLogo

         Dim parI = New Reglas.ParametrosImagenes()
         Dim LogoImagen = actual.Logo

         parm.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
         parm.Add(New ReportParameter("LogoMime", LogoImagen.MimeType()))


         Dim totalIva0 As Decimal = 0
         Dim totalIva105 As Decimal = 0
         Dim totalIva210 As Decimal = 0
         Dim totalIva270 As Decimal = 0
         dtReporte.Columns.Add("TipoOperacionAbreviado", GetType(String))
         dtReporte.Columns.Add("OrdenTipoOperacion", GetType(Integer))
         'dtReporte.Columns.Add("EsObservacion", GetType(Boolean))
         For Each dr As DataRow In dtReporte.Rows

            dr("TipoOperacionAbreviado") = dr("TipoOperacion").ToString().Substring(0, 1)
            dr("OrdenTipoOperacion") = Convert.ToInt32(DirectCast([Enum].Parse(GetType(Eniac.Entidades.Producto.TiposOperaciones),
                                                                               dr("TipoOperacion").ToString()),
                                                                  Eniac.Entidades.Producto.TiposOperaciones))

            If Not _puedeVerPrecios Then
               dr("Precio") = 0
               dr("Costo") = 0
               dr("ImporteTotal") = 0
               dr("DescuentoRecargoProducto") = 0
               dr("ImporteImpuesto") = 0
               dr("ImporteImpuestoInterno") = 0
               dr("PrecioNeto") = 0
               dr("ImporteTotalNeto") = 0
               dr("DescRecGeneral") = 0
               dr("DescRecGeneralProducto") = 0
               dr("PrecioConImpuestos") = 0
               dr("PrecioNetoConImpuestos") = 0
               dr("ImporteTotalConImpuestos") = 0
               dr("ImporteTotalNetoConImpuestos") = 0
               dr("PrecioVentaPorTamano") = 0
            End If

            dr("DescuentoProducto") = dr("DescuentoRecargoProducto")

            dr("DescuentoProductoPorc1") = dr("DescuentoRecargoPorc")
            dr("DescuentoProductoPorc2") = dr("DescuentoRecargoPorc2")
            dr("DescuentoProductoPorcCompuesto") = Reglas.CalculosDescuentosRecargos.CombinaDosDescuentos(dr.ValorNumericoPorDefecto("DescuentoProductoPorc1", 0D), dr.ValorNumericoPorDefecto("DescuentoProductoPorc2", 0D), 2)

            If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
               dr("Precio") = dr("PrecioConImpuestos")
               dr("PrecioNeto") = dr("PrecioNetoConImpuestos")
               dr("ImporteTotal") = dr("ImporteTotalConImpuestos")
               dr("ImporteTotalNeto") = dr("ImporteTotalNetoConImpuestos")
               dr("DescuentoRecargoProducto") = Decimal.Parse(dr("DescuentoRecargoProducto").ToString()) *
                                                (1 + (Decimal.Parse(dr("AlicuotaImpuesto").ToString()) / 100))
               dr("DescuentoProducto") = Decimal.Parse(dr("DescuentoProducto").ToString()) *
                                         (1 + (Decimal.Parse(dr("AlicuotaImpuesto").ToString()) / 100))
            End If
            Dim alicIVA As Decimal = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
            If alicIVA = 10.5 Then
               totalIva105 += Decimal.Parse(dr("ImporteImpuesto").ToString())
            ElseIf alicIVA = 21 Then
               totalIva210 += Decimal.Parse(dr("ImporteImpuesto").ToString())
            ElseIf alicIVA = 27 Then
               totalIva270 += Decimal.Parse(dr("ImporteImpuesto").ToString())
            End If
         Next
         If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
            parm.Add(New ReportParameter("IVA0", "0"))
            parm.Add(New ReportParameter("IVA105", "0"))
            parm.Add(New ReportParameter("IVA210", "0"))
            parm.Add(New ReportParameter("IVA270", "0"))
         Else
            parm.Add(New ReportParameter("IVA0", totalIva0.ToString()))
            parm.Add(New ReportParameter("IVA105", totalIva105.ToString()))
            parm.Add(New ReportParameter("IVA210", totalIva210.ToString()))
            parm.Add(New ReportParameter("IVA270", totalIva270.ToString()))
         End If
         ' ^^ HASTA ACÁ HACIA ABAJO VAN LOS PARAMETROS NECESARIO PARA PODER USAR Comprobante.rdlc


         If Visualizar Then
            Dim frmImprime As VisorReportes '= New VisorReportes(reporteNombre, reporteDataSource, dtReporte, parm, reporteEmbebido)
            frmImprime = New VisorReportes(reporteNombre,
                                           reporteDataSource, dtReporte,
                                           "SistemaDataSet_VentasContactos", dtVC,
                                           "SistemaDataSet_VentasObservaciones", dtVO,
                                           parm, reporteEmbebido, 1) '# 1 = Cantidad Copias

            frmImprime.Text = titulo
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Destinatarios = oPedido.Cliente.CorreoElectronico

            frmImprime.DisplayModeInicial = DisplayMode.PrintLayout

            frmImprime.ShowDialog()
         Else
            Dim imp As Imprimir = New Imprimir(ConfigImprimir)
            imp.Run(reporteNombre,
                    reporteDataSource, dtReporte,
                    "SistemaDataSet_VentasContactos", dtVC,
                    "SistemaDataSet_VentasObservaciones", dtVO,
                    parm, reporteEmbebido,
                    "", oPedido.TipoComprobante.CantidadCopias,
                    seteaMargenes:=False)
         End If

         ' Se actuliza fecha de impresion!
         If Not Visualizar Or (Visualizar And Publicos.VisualizarComprobanteVentaAsumeImpresion) Then
            Me.ActualizaFechaImpresion(oPedido)
         End If

         ' Verifico si el Cliente tiene Reporte Complementario
         Dim rep As Reporte = New Reporte()
         Dim _categoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         rep.ArmarReporteComplementarioPedido(oPedido, _categoriaFiscalEmpresa, False)

         If Not String.IsNullOrWhiteSpace(rep.ReporteNombreComplementario) Then
            Dim frmImprime2 As VisorReportes
            frmImprime2 = New VisorReportes(rep.ReporteNombreComplementario,
                                           reporteDataSource, dtReporte,
                                           "SistemaDataSet_VentasContactos", dtVC,
                                           "SistemaDataSet_VentasObservaciones", dtVO,
                                           parm, False, 1) '# 1 = Cantidad Copias
            frmImprime2.Text = rep.Titulo
            frmImprime2.StartPosition = FormStartPosition.CenterScreen
            'If Me._oVentas.TipoComprobante.EsElectronico Then
            '   frmImprime.ImprimeDirecto = True
            'End If
            frmImprime2.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
            frmImprime2.ShowDialog()
         End If
      Catch ex As LocalProcessingException
         If ex.InnerException IsNot Nothing Then
            Throw New Exception(String.Format("{0}: {1}", ex.Message, ex.InnerException.Message), ex)
         Else
            Throw New Exception(ex.Message, ex)
         End If
      End Try
   End Sub

   ''' <summary>
   ''' Actualiza la fecha de impresion del Pedido
   ''' </summary>
   ''' <param name="oPedido"></param>
   ''' <remarks></remarks>
   Private Sub ActualizaFechaImpresion(oPedido As Entidades.Pedido)

      Dim ped As Reglas.Pedidos = New Reglas.Pedidos()

      ped.ActualizaFechaImpresion(oPedido.IdSucursal, oPedido.TipoComprobante.IdTipoComprobante, oPedido.LetraComprobante, oPedido.CentroEmisor, oPedido.NumeroPedido)
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

   Private Property _ConfigImprimirComplementario As ConfiguracionImprimir
   Public Property ConfigImprimirComplementario As ConfiguracionImprimir
      Get
         If _ConfigImprimirComplementario Is Nothing Then
            _ConfigImprimirComplementario = New ConfiguracionImprimir(0, 0)
         End If
         Return _ConfigImprimirComplementario
      End Get
      Set(value As ConfiguracionImprimir)
         _ConfigImprimirComplementario = value
      End Set
   End Property
#End Region
End Class
Option Strict Off
Imports Microsoft.Reporting.WinForms
Public Class ImpresionPedidosProv
   Private _puedeVerPrecios As Boolean
   Public Sub ImprimirPedidoDetallado(oPedido As Entidades.PedidoProveedor, Visualizar As Boolean, EnviaMail As Boolean)
      ImprimirPedido(oPedido, Visualizar, "Eniac.Win.PedidoProvV2Detalle.rdlc", True, EnviaMail)
   End Sub
   Public Sub ImprimirPedido(oPedido As Entidades.PedidoProveedor, Visualizar As Boolean, EnviaMail As Boolean)
      Dim tipoLetra As Entidades.TipoComprobanteLetra
      tipoLetra = New Reglas.TiposComprobantesLetras().GetUno(oPedido.TipoComprobante.IdTipoComprobante, oPedido.LetraComprobante)

      Dim reporteNombre As String = "Eniac.Win.PedidoProvV2.rdlc"
      '_puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "PedidosProv", "ImpresionPedidosProv-VerPre")
      _puedeVerPrecios = True

      'GAR: 12/12/2017 - Por ahora no tiene utilidad.
      'If oPedido.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRESUPCLIE.ToString() Then
      '   reporteNombre = "Eniac.Win.Presupuesto.rdlc"
      '   _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "Presupuestos", "ImpresionPresupuestos-VerPre")
      'End If
      '--------------------------------------
      Dim reporteEmbebido As Boolean = True

      If tipoLetra IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir) Then
         reporteNombre = tipoLetra.ArchivoAImprimir
         reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
         ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)
         CantidadCopias = tipoLetra.CantidadCopias
         If Not reporteEmbebido Then
            reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
         End If
      End If

      'Dim Envios As DataTable = New Reglas.EnviosOC().GetEnviosXOC(oPedido.IdSucursal, oPedido.IdTipoComprobante,
      '                                                              oPedido.LetraComprobante, oPedido.CentroEmisor,
      '                                                              oPedido.NumeroPedido)

      'If Envios.Rows.Count > 0 AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir2) Then
      '   reporteNombre = tipoLetra.ArchivoAImprimir2
      '   reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido2
      '   If Not reporteEmbebido Then
      '      reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir2
      '   End If
      'End If

      'If oPedido.FechaReprogramacion <> Nothing Then

      '   If Envios.Rows.Count <> 0 Then

      '      If Not String.IsNullOrEmpty(Envios.Rows(0).Item("FechaReprogramacion").ToString()) Then

      '         ' TIENE ENVIOS Y EL ULTIMO ENVIO FUE REPROGRAMACION

      '         If DateTime.Parse(Envios.Rows(0).Item("FechaReprogramacion").ToString()) <> oPedido.FechaReprogramacion Then
      '            ' TIENE ENVIOS Y EL ULTIMO ENVIO FUE REPROGRAMACION Y LA ULTIMA FECHA DE REPROGRAMACION ES DISTINTA

      '            reporteNombre = tipoLetra.ArchivoAImprimirComplementario
      '            reporteEmbebido = tipoLetra.ArchivoAImprimirComplementarioEmbebido
      '            If Not reporteEmbebido Then
      '               reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimirComplementario
      '            End If

      '         Else
      '            ' TIENE ENVIOS Y EL ULTIMO ENVIO FUE REPROGRAMACION Y LA ULTIMA FECHA DE REPROGRAMACION ES IGUAL
      '            reporteNombre = tipoLetra.ArchivoAExportar
      '            reporteEmbebido = tipoLetra.ArchivoAExportarEmbebido
      '            If Not reporteEmbebido Then
      '               reporteNombre = "Reportes\" & tipoLetra.ArchivoAExportar
      '            End If
      '         End If

      '      Else
      '         ' TIENE ENVIOS Y EL ULTIMO ENVIO NO FUE REPROGRAMACION
      '         reporteNombre = tipoLetra.ArchivoAImprimirComplementario
      '         reporteEmbebido = tipoLetra.ArchivoAImprimirComplementarioEmbebido
      '         If Not reporteEmbebido Then
      '            reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimirComplementario
      '         End If

      '      End If

      '   End If

      'End If

      ImprimirPedido(oPedido, Visualizar, reporteNombre, reporteEmbebido, EnviaMail)
   End Sub
   Private Sub ImprimirPedido(oPedido As Entidades.PedidoProveedor, Visualizar As Boolean, reporteNombre As String, reporteEmbebido As Boolean, Enviamail As Boolean)
      Try
         Dim categoriaFiscalEmpresa As Entidades.CategoriaFiscal
         categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

         Dim reporteDataSource As String '= "dtsPedido_dtPedido"
         reporteDataSource = "SistemaDataSet_VentasProductos"  ' Cambio para poder usar las impresiones de comprobantes al querer imprimir un pedido.
         Dim titulo As String = oPedido.TipoComprobante.Descripcion

         Dim sucursal As Entidades.Sucursal = New Reglas.Sucursales().GetUna(oPedido.IdSucursal, False)

         Dim dtReporte As DataTable
         dtReporte = New Reglas.PedidosProductosProveedores().GetPedidosProductosProveedores(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante,
                                                                                             oPedido.CentroEmisor, oPedido.NumeroPedido)


         dtReporte.Columns.Add("DescuentoProducto", GetType(Decimal))
         dtReporte.Columns.Add("DescuentoProductoPorc1", GetType(Decimal))
         dtReporte.Columns.Add("DescuentoProductoPorc2", GetType(Decimal))

         'El reporte de Pedidos no lo usa, pero se pueden usar los reportes de VENTA por lo que es necesario.
         Dim dtVO As SistemaDataSet.VentasObservacionesDataTable = New SistemaDataSet.VentasObservacionesDataTable()
         Dim drVO As SistemaDataSet.VentasObservacionesRow

         For Each vo As Entidades.PedidoObservacionProveedor In oPedido.PedidosObservaciones

            drVO = dtVO.NewVentasObservacionesRow()

            drVO.IdSucursal = vo.IdSucursal
            drVO.IdTipoComprobante = vo.IdTipoComprobante
            drVO.Letra = vo.Letra
            drVO.CentroEmisor = vo.CentroEmisor
            drVO.NumeroComprobante = vo.NumeroPedido
            drVO.Linea = vo.Linea
            drVO.Observacion = vo.Observacion

            dtVO.AddVentasObservacionesRow(drVO)
         Next


         Dim dtVC As SistemaDataSet.VentasContactosDataTable = New SistemaDataSet.VentasContactosDataTable()
         'Dim drVC As SistemaDataSet.VentasContactosRow

         'For Each vo As Entidades.PedidoClienteContacto In oPedido.PedidosContactos

         '   drVC = dtVC.NewVentasContactosRow()

         '   drVC.IdSucursal = vo.IdSucursal
         '   drVC.IdTipoComprobante = vo.IdTipoComprobante
         '   drVC.Letra = vo.Letra
         '   drVC.CentroEmisor = vo.CentroEmisor
         '   drVC.NumeroComprobante = vo.NumeroPedido
         '   drVC.IdCliente = vo.IdCliente
         '   drVC.IdContacto = vo.IdContacto
         '   drVC.NombreContacto = vo.Contacto.NombreContacto
         '   drVC.CorreoElectronico = vo.Contacto.CorreoElectronico
         '   drVC.Telefono = vo.Contacto.Telefono

         '   dtVC.AddVentasContactosRow(drVC)
         'Next

         Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New ReportParameter("TipoImpresionFiscal", Reglas.Publicos.TipoImpresionFiscal))
         parm.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))

         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", Eniac.Win.Publicos.DireccionEmpresa))
         parm.Add(New ReportParameter("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                                                            actual.Sucursal.Direccion,
                                                                                            actual.Sucursal.Localidad.NombreLocalidad,
                                                                                            actual.Sucursal.Localidad.IdLocalidad,
                                                                                            actual.Sucursal.Localidad.IdProvincia)))

         parm.Add(New ReportParameter("TelefonoEmpresa", sucursal.Telefono))
         parm.Add(New ReportParameter("CuitEmpresa", Reglas.Publicos.CuitEmpresa))
         parm.Add(New ReportParameter("IBEmpresa", Reglas.Publicos.IngresosBrutos))

         parm.Add(New ReportParameter("fechaPedido", oPedido.Fecha.ToShortDateString()))
         parm.Add(New ReportParameter("doc", oPedido.Proveedor.CodigoProveedor.ToString()))
         parm.Add(New ReportParameter("nombre", oPedido.Proveedor.NombreProveedor))

         parm.Add(New ReportParameter("IdTipoComprobante", oPedido.TipoComprobante.DescripcionImpresion.ToString()))
         parm.Add(New ReportParameter("Letra", oPedido.LetraComprobante.ToString))
         parm.Add(New ReportParameter("CentroEmisor", oPedido.CentroEmisor.ToString))
         parm.Add(New ReportParameter("NumeroPedido", oPedido.NumeroPedido.ToString))
         parm.Add(New ReportParameter("ObservacionPedido", oPedido.Observacion.ToString()))
         parm.Add(New ReportParameter("NumeroOrdenCompra", oPedido.NumeroOrdenCompra.ToString()))

         Dim proveedor As Entidades.Proveedor = New Reglas.Proveedores().GetUnoPorCodigo(oPedido.Proveedor.CodigoProveedor)
         parm.Add(New ReportParameter("Direccion", proveedor.DireccionProveedor))
         parm.Add(New ReportParameter("Localidad", proveedor.NombreLocalidad))

         Dim localidad As Entidades.Localidad = New Reglas.Localidades().GetUna(proveedor.IdLocalidadProveedor)
         parm.Add(New ReportParameter("Provincia", localidad.NombreProvincia))
         parm.Add(New ReportParameter("CategoriaIVA", proveedor.CategoriaFiscal.NombreCategoriaFiscal))
         parm.Add(New ReportParameter("Cuit", "0" + proveedor.CuitProveedor.ToString()))

         If oPedido.IdFormaPago.HasValue AndAlso oPedido.FormaPago IsNot Nothing Then
            parm.Add(New ReportParameter("FormaPago", oPedido.FormaPago.DescripcionFormasPago.ToString()))
            parm.Add(New ReportParameter("IdFormasPago", oPedido.FormaPago.IdFormasPago.ToString()))
         Else
            parm.Add(New ReportParameter("FormaPago", String.Empty))
            parm.Add(New ReportParameter("IdFormasPago", 0))
         End If
         If oPedido.Comprador IsNot Nothing Then
            parm.Add(New ReportParameter("Vendedor", oPedido.Comprador.NombreEmpleado))
         Else
            parm.Add(New ReportParameter("Vendedor", String.Empty))
         End If

         Dim DiscriminaIVA As Boolean = oPedido.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado
         parm.Add(New ReportParameter("DiscriminaIVA", DiscriminaIVA))

         'Lo dejo para cuando se implemente ProveedoresContactos
         'If oPedido.PedidosContactos.Count > 0 Then
         '   Dim contacto As Entidades.PedidoClienteContacto = oPedido.PedidosContactos(0)
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Contacto", contacto.Contacto.NombreContacto))
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoContacto", contacto.Contacto.CorreoElectronico))
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoContacto", contacto.Contacto.Telefono))
         'Else
         parm.Add(New ReportParameter("Contacto", String.Empty))
         parm.Add(New ReportParameter("CorreoContacto", String.Empty))
         parm.Add(New ReportParameter("TelefonoContacto", String.Empty))
         'End If

         ' vv DE ACÁ HACIA ABAJO VAN LOS PARAMETROS NECESARIO PARA PODER USAR Comprobante.rdlc

         Dim TotalImpuestos As Decimal = oPedido.TotalImpuestos
         Dim TotalImpuestoInterno As Decimal = oPedido.TotalImpuestoInterno

         If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
            With oPedido
               .ImporteBruto = oPedido.ImporteBruto + .TotalImpuestos + .TotalImpuestoInterno
               .DescuentoRecargo = (oPedido.ImporteBruto - TotalImpuestoInterno) * (.DescuentoRecargoPorc / 100)
               .SubTotal = .SubTotal + .TotalImpuestos + .TotalImpuestoInterno
               .TotalImpuestos = 0
            End With
            TotalImpuestos = 0
            TotalImpuestoInterno = 0
         End If

         parm.Add(New ReportParameter("Observacion", oPedido.Observacion.ToString()))
         parm.Add(New ReportParameter("TipoComprobante", oPedido.TipoComprobante.DescripcionImpresion))
         parm.Add(New ReportParameter("DescripcionImpresion", oPedido.TipoComprobante.DescripcionImpresion))
         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", oPedido.FormaPago.DescripcionFormasPago))
         parm.Add(New ReportParameter("FormaPagoDias", oPedido.FormaPago.Dias.ToString()))
         parm.Add(New ReportParameter("IdCategoriaFiscal", oPedido.CategoriaFiscal.IdCategoriaFiscal.ToString()))
         parm.Add(New ReportParameter("NombreFantasia", Reglas.Publicos.NombreFantasia))
         parm.Add(New ReportParameter("CodigoProveedorLetras", proveedor.CodigoProveedorLetras.ToString()))
         parm.Add(New ReportParameter("TipoYNroDocumento", proveedor.CodigoProveedor.ToString()))
         parm.Add(New ReportParameter("NombreYApellido", proveedor.NombreProveedor))
         parm.Add(New ReportParameter("Telefono", proveedor.TelefonoProveedor & " " & proveedor.FaxProveedor))
         parm.Add(New ReportParameter("Fecha", oPedido.Fecha.ToString()))
         parm.Add(New ReportParameter("Numero", oPedido.NumeroPedido.ToString()))
         parm.Add(New ReportParameter("FechaHasta", oPedido.Fecha.AddDays(Reglas.Publicos.DiasValidezPresupuesto).ToString()))

         If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
            oPedido.ImporteBruto = oPedido.ImporteBruto + oPedido.TotalImpuestos + oPedido.TotalImpuestoInterno ''- oPedido.TotalImpuestosVarios 
            oPedido.SubTotal = oPedido.SubTotal + oPedido.TotalImpuestos + oPedido.TotalImpuestoInterno ''- oPedido.TotalImpuestosVarios 
         End If

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

         parm.Add(New ReportParameter("Total_EnLetras", Numeros_A_Letras.EnLetras(oPedido.ImporteTotal.ToString())))

         parm.Add(New ReportParameter("Kilos", 0D))
         parm.Add(New ReportParameter("DecimalesEnCantidad", IIf(Reglas.Publicos.ProductoUtilizaCantidadesEnteras, "0", "2").ToString()))
         parm.Add(New ReportParameter("DecimalesEnPrecio", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString()))
         parm.Add(New ReportParameter("DecimalesEnTotalXProducto", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto.ToString()))
         parm.Add(New ReportParameter("DescripcionAdicionalEmpresa", Reglas.Publicos.DescripcionAdicionalEmpresa.ToString()))
         parm.Add(New ReportParameter("eMail", actual.Sucursal.Correo.ToString()))
         parm.Add(New ReportParameter("web", Reglas.Publicos.DireccionWebEmpresa))
         parm.Add(New ReportParameter("ZonaGeografica", "")) 'oPedido.Proveedor.ZonaGeografica.IdZonaGeografica))

         parm.Add(New ReportParameter("TotalKilos", 0D))
         parm.Add(New ReportParameter("TotalProductos", oPedido.CantidadProductos))
         parm.Add(New ReportParameter("MuestraTotalKilos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalKilos))
         parm.Add(New ReportParameter("MuestraTotalProductos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalProductos))

         Dim SaldoActual As Decimal = 0
         'PE-35123 - Si no hay comprobante a generar (ejemplo: Metalsur) calcula el saldo en cero.
         ' If oPedido.TipoComprobanteFact IsNot Nothing Then
         parm.Add(New ReportParameter("MuestraSaldo", Boolean.FalseString))
         parm.Add(New ReportParameter("SaldoActual", "0"))
         parm.Add(New ReportParameter("CotizacionDolar", oPedido.CotizacionDolar.ToString()))
         parm.Add(New ReportParameter("Coeficiente", "1"))

         parm.Add(New ReportParameter("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre))
         parm.Add(New ReportParameter("FechaInicioActividades", Reglas.Publicos.FechaInicioActividades))

         parm.Add(New ReportParameter("IngresosBrutos", Reglas.Publicos.IngresosBrutos))
         parm.Add(New ReportParameter("EmpresaCUIT", Reglas.Publicos.CuitEmpresa))
         parm.Add(New ReportParameter("eMail", actual.Sucursal.Correo))
         parm.Add(New ReportParameter("Web", Reglas.Publicos.DireccionWebEmpresa))
         parm.Add(New ReportParameter("IdMoneda", oPedido.IdMoneda))

         Dim nombreLogo As String = Publicos.NombreLogo

         Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
         Dim LogoImagen As Image = actual.Logo

         parm.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
         parm.Add(New ReportParameter("LogoMime", LogoImagen.MimeType()))


         Dim totalIva0 As Decimal = 0
         Dim totalIva105 As Decimal = 0
         Dim totalIva210 As Decimal = 0
         Dim totalIva270 As Decimal = 0
         dtReporte.Columns.Add("Precio", GetType(Decimal))
         For Each dr As DataRow In dtReporte.Rows

            ' # Validar que código se debe mostrar a la hora de imprimir.
            If Reglas.Publicos.ImpresionMuestraCodigoProveedorTrue Then
               If Not String.IsNullOrEmpty(dr(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()).ToString()) Then
                  dr(Entidades.ProductoProveedor.Columnas.IdProducto.ToString()) = dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString())
               End If
            End If

            If Not _puedeVerPrecios Then
               'dr("Precio") = 0
               dr("Costo") = 0
               dr("CostoNeto") = 0
               dr("ImporteTotal") = 0
               dr("DescuentoRecargoProducto") = 0
               dr("ImporteImpuesto") = 0
               dr("ImporteImpuestoInterno") = 0
               'dr("PrecioNeto") = 0
               dr("ImporteTotalNeto") = 0
               dr("DescRecGeneral") = 0
               dr("DescRecGeneralProducto") = 0
               'dr("PrecioConImpuestos") = 0
               'dr("PrecioNetoConImpuestos") = 0
               dr("ImporteTotalConImpuestos") = 0
               dr("ImporteTotalNetoConImpuestos") = 0
               'dr("PrecioVentaPorTamano") = 0
            End If

            dr("Precio") = dr("Costo")

            dr("DescuentoProducto") = dr("DescuentoRecargoProducto")

            dr("DescuentoProductoPorc1") = dr("DescuentoRecargoPorc")
            dr("DescuentoProductoPorc2") = dr("DescuentoRecargoPorc2")

            If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
               dr("CostoNeto") = Decimal.Parse(dr("CostoNeto").ToString()) *
                                       (1 + (Decimal.Parse(dr("AlicuotaImpuesto").ToString()) / 100))
               '   dr("Precio") = dr("PrecioConImpuestos")
               '   dr("PrecioNeto") = dr("PrecioNetoConImpuestos")
               '   dr("ImporteTotal") = dr("ImporteTotalConImpuestos")
               '   dr("ImporteTotalNeto") = dr("ImporteTotalNetoConImpuestos")
               '   dr("DescuentoRecargoProducto") = Decimal.Parse(dr("DescuentoRecargoProducto").ToString()) * _
               '                                    (1 + (Decimal.Parse(dr("AlicuotaImpuesto").ToString()) / 100))
               '   dr("DescuentoProducto") = dr("DescuentoProducto") * _
               '                             (1 + (Decimal.Parse(dr("AlicuotaImpuesto").ToString()) / 100))
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
            parm.Add(New ReportParameter("IVA0", 0))
            parm.Add(New ReportParameter("IVA105", 0))
            parm.Add(New ReportParameter("IVA210", 0))
            parm.Add(New ReportParameter("IVA270", 0))
         Else
            parm.Add(New ReportParameter("IVA0", totalIva0))
            parm.Add(New ReportParameter("IVA105", totalIva105))
            parm.Add(New ReportParameter("IVA210", totalIva210))
            parm.Add(New ReportParameter("IVA270", totalIva270))
         End If
         ' ^^ HASTA ACÁ HACIA ABAJO VAN LOS PARAMETROS NECESARIO PARA PODER USAR Comprobante.rdlc


         If Visualizar Then
            Dim frmImprime As VisorReportes '= New VisorReportes(reporteNombre, reporteDataSource, dtReporte, parm, reporteEmbebido)
            frmImprime = New VisorReportes(reporteNombre,
                                           reporteDataSource, dtReporte,
                                           "SistemaDataSet_VentasContactos", dtVC,
                                           "SistemaDataSet_VentasObservaciones", dtVO,
                                           parm, reporteEmbebido, CantidadCopias)

            frmImprime.Text = titulo
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.WindowState = FormWindowState.Maximized

            frmImprime.btnEnviarPorMail.Visible = Enviamail

            frmImprime.Destinatarios = oPedido.Proveedor.CorreoElectronico

            frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout

            frmImprime.ShowDialog()
         Else
            Dim imp As Imprimir = New Imprimir(ConfigImprimir)
            imp.Run(reporteNombre, reporteDataSource, dtReporte, parm, reporteEmbebido, "", oPedido.TipoComprobante.CantidadCopias)
         End If
      Catch ex As LocalProcessingException
         If ex.InnerException IsNot Nothing Then
            Throw New Exception(String.Format("{0}: {1}", ex.Message, ex.InnerException.Message), ex)
         Else
            Throw New Exception(ex.Message, ex)
         End If
      End Try
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
      Set(value As Integer)
         _cantidadCopias = value
      End Set
   End Property
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
#End Region
End Class
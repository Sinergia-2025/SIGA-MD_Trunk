Option Strict Off
Public Class ImpresionCompra

#Region "Campos"

   Private _oCompra As Entidades.Compra

#End Region

#Region "Constructores"

   Public Sub New(Compra As Entidades.Compra)

      Me._oCompra = Compra

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function ImprimirComprobante(Visualizar As Boolean, decimales As Integer) As Boolean

      'cambio los valores porque se graban segun corresponde, ej: Mota de credito u otro tipo que necesite grabarlo en forma negativa
      Dim coe As Integer = Me._oCompra.TipoComprobante.CoeficienteValores

      Dim oCategFiscal As New Reglas.CategoriasFiscales

      Dim dtFic As SistemaDataSet.ComprasProductosDataTable = New SistemaDataSet.ComprasProductosDataTable()
      Dim drF As SistemaDataSet.ComprasProductosRow

      For Each fp As Entidades.CompraProducto In Me._oCompra.ComprasProductos
         drF = dtFic.NewComprasProductosRow()
         drF.IdTipoComprobante = Me._oCompra.TipoComprobante.IdTipoComprobante
         drF.NumeroComprobante = Me._oCompra.NumeroComprobante
         drF.Letra = Me._oCompra.Letra
         drF.IdSucursal = fp.IdSucursal
         drF.Orden = fp.Orden
         drF.IdProducto = fp.ProductoSucursal.Producto.IdProducto
         drF.CentroEmisor = fp.CentroEmisor

         '-- REQ-35143.- ------------------------------------------------------------
         Dim descAtr = fp.ConcatenaAtributos()
         If Not String.IsNullOrWhiteSpace(descAtr) Then
            fp.Producto.NombreProducto = String.Format("{0} ({1})", fp.Producto.NombreProducto, descAtr)
         End If
         '-----------------------------------------------------------------------------
         If Reglas.Publicos.Compras.ComprasImpresionVisualizaNrosSerie Then
            Dim PNS As List(Of Entidades.ProductoNroSerie) = New List(Of Entidades.ProductoNroSerie)
            Dim NumerosSerie As String = String.Empty

            '# <<nueva lógica: no se necesita ir a buscar nuevamente los Productos c/Nro Serie asociados a la venta>>
            If fp.Producto.NrosSeries.Count > 0 Then

               '# Count de Nros. Serie x Linea
               Dim countNrosSerieXLinea As Integer = 0
               For Each ePNS As Entidades.ProductoNroSerie In fp.Producto.NrosSeries
                  If ePNS.OrdenVenta = fp.Orden Then
                     countNrosSerieXLinea += 1
                  End If
               Next

               Dim cant As Integer = 1
               For Each ePNS As Entidades.ProductoNroSerie In fp.Producto.NrosSeries
                  If ePNS.OrdenVenta = fp.Orden Then
                     If countNrosSerieXLinea <> cant Then
                        NumerosSerie += ePNS.NroSerie & " // "
                        cant += 1
                     Else
                        NumerosSerie += ePNS.NroSerie
                     End If
                  End If
               Next

               drF.NombreProducto = fp.Producto.NombreProducto & " (" & NumerosSerie & ")"

            Else '<<anteriormente>>
               PNS = New Reglas.ProductosNrosSerie().GetNrosSerieProducto_Comprobante(_oCompra.IdSucursal,
                                                                                      _oCompra.TipoComprobante.IdTipoComprobante,
                                                                                      _oCompra.Letra,
                                                                                      _oCompra.CentroEmisor,
                                                                                      _oCompra.NumeroComprobante,
                                                                                      _oCompra.Proveedor.IdProveedor,
                                                                                      fp.ProductoSucursal.Producto.IdProducto)

               If PNS.Count <> 0 Then
                  Dim cant As Integer = 1
                  For Each dr As Entidades.ProductoNroSerie In PNS
                     If PNS.Count <> cant Then
                        NumerosSerie += dr.NroSerie & " // "
                        cant += 1
                     Else
                        NumerosSerie += dr.NroSerie
                     End If
                  Next
                  drF.NombreProducto = fp.Producto.NombreProducto & " (" & NumerosSerie & ")"
               Else
                  drF.NombreProducto = fp.Producto.NombreProducto
               End If
               drF.NombreProducto = fp.Producto.NombreProducto
            End If
         Else
            drF.NombreProducto = fp.Producto.NombreProducto
         End If

         drF.Cantidad = fp.Cantidad * coe

         'If Not Me._oCompra.Cliente.CategoriaFiscal.IvaDiscriminado Then
         If Not oCategFiscal.GetUno(Reglas.Publicos.CategoriaFiscalEmpresa).IvaDiscriminado Then

            drF.Precio = Decimal.Round(fp.Precio * (1 + (fp.PorcentajeIVA / 100)), 2)
            drF.ImporteTotal = Decimal.Round(fp.ImporteTotal * (1 + (fp.PorcentajeIVA / 100)), 2)
            drF.Descuento = Decimal.Round(fp.DescuentoRecargo * (1 + (fp.PorcentajeIVA / 100)), 2)
            drF.DescuentoProducto = Decimal.Round(fp.DescuentoRecargoProducto * (1 + (fp.PorcentajeIVA / 100)), 2)
         Else
            drF.Precio = fp.Precio
            drF.ImporteTotal = fp.ImporteTotal
            drF.Descuento = fp.DescuentoRecargo
            drF.DescuentoProducto = fp.DescuentoRecargoProducto
         End If
         drF.DescuentoProductoPorc = fp.DescuentoRecargoPorc.ToString()
         drF.PorcentajeIVA = fp.PorcentajeIVA

         With drF
            '.Precio = .Precio * coe
            '.PrecioNeto = .PrecioNeto * coe
            .ImporteTotal = .ImporteTotal * coe
            .Descuento = .Descuento * coe
            .DescuentoProducto = .DescuentoProducto * coe
         End With

         dtFic.AddComprasProductosRow(drF)
      Next

      Dim dtTA As SistemaDataSet.TarjetasCuponesDataTable = New SistemaDataSet.TarjetasCuponesDataTable()
      Dim drTA As SistemaDataSet.TarjetasCuponesRow

      For Each liq As Entidades.CompraTarjeta In Me._oCompra.CuponesTarjetasLiquidacion

         drTA = dtTA.NewTarjetasCuponesRow()

         drTA.Cuotas = liq.TarjetaCupon.Cuotas
         drTA.FechaEmision = liq.TarjetaCupon.FechaEmision
         drTA.IdBanco = liq.TarjetaCupon.IdBanco
         drTA.IdEstadoTarjetaAnt = liq.TarjetaCupon.IdEstadoTarjetaAnt.ToString()
         drTA.NumeroLote = liq.TarjetaCupon.NumeroLote
         drTA.NumeroCupon = liq.TarjetaCupon.NumeroCupon
         drTA.IdTarjeta = liq.TarjetaCupon.IdTarjeta
         drTA.IdTarjetaCupon = liq.TarjetaCupon.IdTarjetaCupon
         drTA.Monto = liq.TarjetaCupon.Monto
         drTA.NombreBanco = liq.TarjetaCupon.NombreBanco
         drTA.NombreTarjeta = liq.TarjetaCupon.NombreTarjeta

         dtTA.AddTarjetasCuponesRow(drTA)
      Next

      Dim dtRE As SistemaDataSet.ComprasRetencionesDataTable = New SistemaDataSet.ComprasRetencionesDataTable()
      Dim drRE As SistemaDataSet.ComprasRetencionesRow
      Dim TotalRetenciones As Decimal = 0

      For Each ret As Entidades.CompraRetencion In Me._oCompra.Retenciones

         drRE = dtRE.NewComprasRetencionesRow()

         drRE.NombreTipoImpuesto = ret.Retencion.NombreTipoImpuesto
         drRE.ImporteTotal = ret.Retencion.ImporteTotal * -1
         TotalRetenciones += drRE.ImporteTotal
         dtRE.AddComprasRetencionesRow(drRE)
      Next

      Dim dtCO As SistemaDataSet.ComprasObservacionesDataTable = New SistemaDataSet.ComprasObservacionesDataTable()
      Dim drCO As SistemaDataSet.ComprasObservacionesRow

      For Each vo As Entidades.CompraObservacion In Me._oCompra.ComprasObservaciones

         drCO = dtCO.NewComprasObservacionesRow()

         drCO.IdSucursal = Me._oCompra.IdSucursal
         drCO.IdTipoComprobante = Me._oCompra.TipoComprobante.IdTipoComprobante
         drCO.Letra = Me._oCompra.Letra
         drCO.CentroEmisor = Me._oCompra.CentroEmisor
         drCO.NumeroComprobante = Me._oCompra.NumeroComprobante
         drCO.IdProveedor = Me._oCompra.Proveedor.IdProveedor
         drCO.Linea = vo.Linea
         drCO.Observacion = vo.Observacion

         dtCO.AddComprasObservacionesRow(drCO)
      Next

      With Me._oCompra
         .DescuentoRecargo = .DescuentoRecargo * coe
         .PercepcionIVA = .PercepcionIVA * coe
         .PercepcionIB = .PercepcionIB * coe
         .PercepcionGanancias = .PercepcionGanancias * coe
         .PercepcionVarias = .PercepcionVarias * coe
         .ImporteTotal = .ImporteTotal * coe
      End With

      Dim dtCI As SistemaDataSet.ComprasImpuestosDataTable = New SistemaDataSet.ComprasImpuestosDataTable()
      Dim drCI As SistemaDataSet.ComprasImpuestosRow

      For Each ci As Entidades.CompraImpuesto In _oCompra.ComprasImpuestos
         'If ci.TipoTipoImpuesto = "PERCEPCION" Then
         drCI = dtCI.NewComprasImpuestosRow()

         drCI.IdSucursal = ci.IdSucursal
         drCI.IdTipoComprobante = ci.IdTipoComprobante
         drCI.Letra = ci.Letra
         drCI.CentroEmisor = ci.CentroEmisor
         drCI.NumeroComprobante = ci.NumeroComprobante
         drCI.IdProveedor = ci.IdProveedor
         drCI.Orden = ci.Orden
         drCI.IdTipoImpuesto = ci.IdTipoImpuesto
         drCI.IdProvincia = ci.IdProvincia
         drCI.Emisor = ci.Emisor
         drCI.Numero = ci.Numero
         drCI.Bruto = ci.Bruto * coe
         drCI.BaseImponible = ci.BaseImponible * coe
         drCI.Alicuota = ci.Alicuota
         drCI.Importe = ci.Importe * coe

         drCI.TipoTipoImpuesto = ci.TipoTipoImpuesto

         drCI.NombreProveedor = ci.NombreProveedor
         drCI.NombreProvincia = ci.NombreProvincia
         drCI.NombreTipoImpuesto = ci.NombreTipoImpuesto

         dtCI.AddComprasImpuestosRow(drCI)
         'End If
      Next

      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoImpresionFiscal", Reglas.Publicos.TipoImpresionFiscal))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", Me._oCompra.NumeroComprobante.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CentroEmisor", Me._oCompra.CentroEmisor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("RazonSocial", Me._oCompra.Proveedor.NombreProveedor))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", Me._oCompra.Proveedor.DireccionProveedor))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", Me._oCompra.Proveedor.TelefonoProveedor))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", Me._oCompra.Proveedor.NombreLocalidad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me._oCompra.Fecha.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescuentoRecargo", Me._oCompra.DescuentoRecargo.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescuentoRecargoPorc", Me._oCompra.DescuentoRecargoPorc.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CotizacionDolar", Me._oCompra.CotizacionDolar.ToString()))

      'Se deben quitar del reporte antes de sacarlos
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("BrutoNoGravado", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Bruto105", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Bruto210", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Bruto270", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NetoNoGravado", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Neto105", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Neto210", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Neto270", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA105", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA210", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA270", "0"))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PercepcionIVA", Me._oCompra.PercepcionIVA.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PercepcionIB", Me._oCompra.PercepcionIB.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PercepcionGanancias", Me._oCompra.PercepcionGanancias.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PercepcionVarias", Me._oCompra.PercepcionVarias.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalImpuestosInternos", Me._oCompra.ImpuestosInternos.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalRetenciones", TotalRetenciones.ToString()))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Total", Me._oCompra.ImporteTotal.ToString("#,##0." + New String("0"c, decimales))))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.Direccion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", Me._oCompra.FormaPago.DescripcionFormasPago))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", Me._oCompra.Observacion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CategoriaIVA", Me._oCompra.Proveedor.CategoriaFiscal.NombreCategoriaFiscal))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", Me._oCompra.Letra))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprador", Me._oCompra.Comprador.NombreEmpleado))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", Me._oCompra.Proveedor.CodigoProveedor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cuit", Me._oCompra.Proveedor.CuitProveedor))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Kilos", "0"))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoComprobante", Me._oCompra.TipoComprobante.Descripcion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PeriodoFiscal", Me._oCompra.PeriodoFiscal))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreRubro", Me._oCompra.Rubro.NombreRubro))


      'Propiedades necesarias para poder usar Remito Transporte Compras
      If _oCompra.TipoComprobante.EsRemitoTransportista Then
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmpresaCUIT", Reglas.Publicos.CuitEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreFantasia", Reglas.Publicos.NombreFantasia))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreDeFantasia", Reglas.Publicos.NombreFantasia))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescripcionAdicionalEmpresa", Reglas.Publicos.DescripcionAdicionalEmpresa.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaInicioActividades", Reglas.Publicos.FechaInicioActividades))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IngresosBrutos", Reglas.Publicos.IngresosBrutos))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("eMail", actual.Sucursal.Correo.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("web", Reglas.Publicos.DireccionWebEmpresa))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", Me._oCompra.Proveedor.NombreProveedor))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", Me._oCompra.Fecha.AddDays(Reglas.Publicos.DiasValidezPresupuesto).ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPagoDias", Me._oCompra.FormaPago.Dias.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdCategoriaFiscal", Me._oCompra.Proveedor.CategoriaFiscal.IdCategoriaFiscal.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CotizacionDolar", Me._oCompra.CotizacionDolar.ToString()))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Bultos", Me._oCompra.Bultos))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ValorDeclarado", Me._oCompra.ValorDeclarado))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NumeroLote", Me._oCompra.NumeroLote))

         If _oCompra.Transportista IsNot Nothing Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Nombre", Me._oCompra.Transportista.NombreTransportista))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Direccion", Me._oCompra.Transportista.DireccionTransportista))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Localidad", Me._oCompra.Transportista.NombreLocalidad))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_CUIT", "0" & Me._oCompra.Transportista.CuitTransportista.Replace("-", "")))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_CategoriaIVA", Me._oCompra.Transportista.CategoriaFiscal.NombreCategoriaFiscal))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Telefono", Me._oCompra.Transportista.TelefonoTransportista))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Nombre", ""))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Direccion", ""))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Localidad", ""))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_CUIT", "0"))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_CategoriaIVA", ""))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Transportista_Telefono", ""))
         End If

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Bruto", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescuentoRecargo", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescuentoRecargoPorc", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Subtotal", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalIVA", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalImpuestosVarios", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Total", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoActual", "0"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalKilos", 0))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TotalProductos", 0))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("MuestraTotalKilos", False))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("MuestraTotalProductos", False))
      End If


      Dim reporteNombre As String = String.Empty
      Dim reporteDataSource As String = String.Empty
      Dim reporteDataSource2 As String = String.Empty
      Dim reporteDataSource3 As String = String.Empty
      Dim reporteDataSource4 As String = String.Empty
      Dim reporteDataSource5 As String = String.Empty


      Dim titulo As String = String.Empty

      If _oCompra.TipoComprobante.EsRemitoTransportista Then
         reporteNombre = "Eniac.Win.RemitoTransportistaCompra.rdlc"
      Else
         reporteNombre = "Eniac.Win.ComprobanteCompra.rdlc"
      End If
      reporteDataSource = "SistemaDataSet_ComprasProductos"
      reporteDataSource2 = "SistemaDataSet_ComprasObservaciones"
      reporteDataSource3 = "SistemaDataSet_ComprasImpuestos"
      reporteDataSource4 = "SistemaDataSet_TarjetasCupones"
      reporteDataSource5 = "SistemaDataSet_ComprasRetenciones"

      titulo = Me._oCompra.TipoComprobante.Descripcion

      Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(Me._oCompra.TipoComprobante.IdTipoComprobante, Me._oCompra.Letra)
      Dim reporteEmbebido As Boolean = True

      If Not String.IsNullOrEmpty(tipoLetra.ArchivoAImprimir) Then
         reporteNombre = tipoLetra.ArchivoAImprimir
         reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
         _ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)
         CantidadCopias = tipoLetra.CantidadCopias
         If Not reporteEmbebido Then
            reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
         End If
      End If


      'Select Case Me._oCompra.TipoComprobante.IdTipoComprobante

      '   Case "FACTCOM", "REMITOCOM", "NCREDCOM", "REMITOCOM-NC", "NDEBCOM"

      '      Case Else
      '      MessageBox.Show("El comprobante no se puede Imprimir.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
      '      Return False

      'End Select

      If Visualizar Then
         Dim frmImprime As VisorReportes
         'frmImprime = New VisorReportes(reporteNombre, reporteDataSource, dtFic, parm, reporteEmbebido)
         frmImprime = New VisorReportes(reporteNombre, reporteDataSource, dtFic, reporteDataSource2,
                                        dtCO, reporteDataSource3, dtCI, reporteDataSource4,
                                        dtTA, reporteDataSource5, dtRE,
                                        parm, reporteEmbebido, CantidadCopias)
         frmImprime.Text = titulo
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.Destinatarios = Me._oCompra.Proveedor.CorreoElectronico
         frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
         frmImprime.ShowDialog()
      Else
         Dim imp As Imprimir = New Imprimir(ConfigImprimir)
         imp.Run(reporteNombre, reporteDataSource, dtFic, reporteDataSource2, dtCO, reporteDataSource3, dtCI, parm, reporteEmbebido, tipoLetra.NombreImpresora, Me._oCompra.TipoComprobante.CantidadCopias, False)
      End If
      Return True
   End Function

#End Region

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


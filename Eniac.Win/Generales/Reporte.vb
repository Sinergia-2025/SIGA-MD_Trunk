Option Strict Off
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Imaging

Public Class Reporte
   Public Shared Sub SeteaParametrosAReporte(reporte As LocalReport,
                                             parametros As IEnumerable(Of ReportParameter))

      Dim reporteParametros As ReportParameterInfoCollection = reporte.GetParameters()

      For Each pi As ReportParameterInfo In reporteParametros
         For Each pr As ReportParameter In parametros
            If pi.Name = pr.Name Then
               reporte.SetParameters(pr)
               Exit For
            End If
         Next
      Next
   End Sub

   Public Sub ArmarReporteComplementarioPedido(oPedido As Entidades.Pedido,
                                               categoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                               utilizarComprobanteEstandar As Boolean)

      Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(oPedido.TipoComprobante.IdTipoComprobante, oPedido.LetraComprobante)

      If Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimirComplementario) And Not utilizarComprobanteEstandar Then
         ReporteNombreComplementario = tipoLetra.ArchivoAImprimirComplementario
         ReporteEmbebidoComplementario = tipoLetra.ArchivoAImprimirComplementarioEmbebido
         ConfigImprimirComplementario = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimirComplementario, tipoLetra.DesplazamientoYArchivoAImprimirComplementario)
         If Not ReporteEmbebidoComplementario Then
            ReporteNombreComplementario = "Reportes\" & tipoLetra.ArchivoAImprimirComplementario
         End If
      End If
   End Sub

   Public Sub ArmarReporteDeVenta(oVenta As Entidades.Venta,
                                  categoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                  utilizarComprobanteEstandar As Boolean,
                                  utilizaArchivoAExportar As Boolean)

      '# Sucursal de la venta
      Dim eSucursal = New Reglas.Sucursales().GetUna(oVenta.IdSucursal, False)

      Dim decimalesAMostrarEnPrecio = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio(eSucursal)
      Dim DecimalesAMostrarEnTotalXProducto As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto(eSucursal)
      'cambio los valores porque se graban segun corresponde, ej: Mota de credito u otro tipo que necesite grabarlo en forma negativa
      Dim coe As Integer = oVenta.TipoComprobante.CoeficienteValores

      Me.VentasProductosDT = New SistemaDataSet.VentasProductosDataTable()
      Dim drVP As SistemaDataSet.VentasProductosRow
      Dim Linea As Integer = 0

      Dim ImporteBruto As Decimal = 0
      Dim descRec1 As Decimal = 0
      Dim descRec2 As Decimal = 0

      ' Importes Totales distinguidos por Forma de Pago
      Dim ImporteTotalPesos As Decimal = 0
      Dim ImporteTotalTickets As Decimal = 0
      Dim ImporteTotalCheques As Decimal = 0
      Dim ImporteTotalTarjetas As Decimal = 0

      ' Asigno los Importes Totales distinguidos en caso que sean <> 0
      If oVenta.ImportePesos <> 0 Then
         ImporteTotalPesos = oVenta.ImportePesos
      End If
      If oVenta.ImporteTarjetas <> 0 Then
         ImporteTotalTarjetas = oVenta.ImporteTarjetas
      End If
      If oVenta.ImporteTickets <> 0 Then
         ImporteTotalTickets = oVenta.ImporteTickets
      End If
      If oVenta.ImporteCheques <> 0 Then
         ImporteTotalCheques = oVenta.ImporteCheques
      End If


      For Each vp As Entidades.VentaProducto In oVenta.VentasProductos

         drVP = Me.VentasProductosDT.NewVentasProductosRow()

         Linea += 1
         drVP.NroLinea = Linea

         drVP.IdTipoComprobante = oVenta.TipoComprobante.IdTipoComprobante
         drVP.NumeroComprobante = oVenta.NumeroComprobante
         drVP.Letra = oVenta.LetraComprobante
         drVP.IdSucursal = vp.IdSucursal
         drVP.IdProducto = vp.Producto.IdProducto
         drVP.CodigoDeBarras = vp.Producto.CodigoDeBarras
         drVP.Orden = vp.Orden
         drVP.EsObservacion = vp.Producto.EsObservacion
         drVP.CentroEmisor = vp.CentroEmisor
         drVP.IdUnidadDeMedida = vp.IdUnidadDeMedida
         drVP.MesesGarantia = vp.Producto.MesesGarantia

         If vp.Producto.ProductoProveedorHabitual IsNot Nothing Then
            drVP.CodigoProductoProveedor = vp.Producto.ProductoProveedorHabitual.CodigoProductoProveedor
         Else
            drVP.CodigoProductoProveedor = String.Empty
         End If

         Dim rMarca = New Reglas.Marcas()
         Dim oMarca = rMarca.GetUna(vp.Producto.IdMarca)
         drVP.NombreMarca = oMarca.NombreMarca

         'Se tomo los meses de garantia del modulo de producto para el cliente (262)DEPETRIS GUSTAVO ARIEL, 
         'y no de ventas produtos por el cambia de recursivo de los modulos
         ' que utiliza meses de garantia ya que no esta pasando el valor.

         Dim NumerosSerie As String = String.Empty
         Dim PNS = New List(Of Entidades.ProductoNroSerie)()
         If Reglas.Publicos.Facturacion.Impresion.VentasImpresionVisualizaNrosSerie(eSucursal) Then

            '# <<nueva lógica: no se necesita ir a buscar nuevamente los Productos c/Nro Serie asociados a la venta>>
            If vp.Producto.NrosSeries.Count > 0 Then

               '# Count de Nros. Serie x Linea
               Dim countNrosSerieXLinea As Integer = 0
               For Each ePNS As Entidades.ProductoNroSerie In vp.Producto.NrosSeries
                  If ePNS.OrdenVenta = vp.Orden Then
                     countNrosSerieXLinea += 1
                  End If
               Next

               Dim cant As Integer = 1
               For Each ePNS As Entidades.ProductoNroSerie In vp.Producto.NrosSeries
                  If ePNS.OrdenVenta = vp.Orden Then
                     If countNrosSerieXLinea <> cant Then
                        NumerosSerie += ePNS.NroSerie & " // "
                        cant += 1
                     Else
                        NumerosSerie += ePNS.NroSerie
                     End If
                  End If
               Next
               drVP.NombreProducto = vp.Producto.NombreProducto & " (" & NumerosSerie & ")"

            Else '<<anteriormente>>
               PNS = New Reglas.ProductosNrosSerie().GetNrosSerieProducto_ComprobanteVenta(oVenta.IdSucursal,
                                                                                           oVenta.TipoComprobante.IdTipoComprobante,
                                                                                           oVenta.LetraComprobante,
                                                                                           oVenta.CentroEmisor,
                                                                                           oVenta.NumeroComprobante,
                                                                                           drVP.IdProducto)
               If PNS.Count <> 0 Then
                  '# Count de Nros. Serie x Linea
                  Dim countNrosSerieXLinea As Integer = 0
                  For Each dr As Entidades.ProductoNroSerie In PNS
                     If dr.OrdenVenta = vp.Orden Then
                        countNrosSerieXLinea += 1
                     End If
                  Next
                  Dim cant As Integer = 1
                  For Each dr As Entidades.ProductoNroSerie In PNS
                     If dr.OrdenVenta = vp.Orden Then
                        If countNrosSerieXLinea <> cant Then
                           NumerosSerie += dr.NroSerie & " // "
                           cant += 1
                        Else
                           NumerosSerie += dr.NroSerie
                        End If
                     End If
                  Next
                  drVP.NombreProducto = vp.Producto.NombreProducto & " (" & NumerosSerie & ")"
               Else
                  drVP.NombreProducto = vp.Producto.NombreProducto
               End If
            End If
         Else
            drVP.NombreProducto = vp.Producto.NombreProducto
         End If
         '-- REQ-35143.- ------------------------------------------------------------
         Dim descAtr = vp.ConcatenaAtributos()
         If Not String.IsNullOrWhiteSpace(descAtr) Then
            drVP.NombreProducto = String.Format("{0} ({1})", vp.Producto.NombreProducto, descAtr)
         End If
         '-----------------------------------------------------------------------------
         drVP.Cantidad = If(vp.CantidadManual <> 0, vp.CantidadManual, vp.Cantidad) * coe '# En Cantidad se manda la cantidad manual ya que todos los reportes manejan este valor
         drVP.CantidadManual = vp.Cantidad '# En CantidadManual se manda la cantidad REAL. Se hace de esta forma para no modificar el valor que reciben todos los reportes en Cantidad

         If Not oVenta.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then

            'drVP.Precio = Decimal.Round(vp.Precio * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), DecimalesAMostrarEnPrecio)
            'drVP.PrecioNeto = Decimal.Round(vp.PrecioNeto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
            'drVP.ImporteTotal = Decimal.Round((vp.ImporteTotal * (1 + (vp.AlicuotaImpuesto / 100))) + vp.ImporteImpuestoInterno, DecimalesAMostrarEnTotalXProducto)
            'drVP.Descuento = Decimal.Round(vp.DescuentoRecargo * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
            'drVP.DescuentoProducto = Decimal.Round(vp.DescuentoRecargoProducto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
            'drVP.DescRecGeneralProducto = Decimal.Round(vp.DescRecGeneralProducto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
            'drVP.ImporteTotalNeto = Decimal.Round((vp.ImporteTotalNeto * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno), DecimalesAMostrarEnTotalXProducto)
            drVP.Precio = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
            drVP.PrecioNeto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioNeto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
            drVP.ImporteTotal = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotal, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), DecimalesAMostrarEnTotalXProducto)
            drVP.Descuento = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescuentoRecargo, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
            drVP.DescuentoProducto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescuentoRecargoProducto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
            'drVP.DescRecGeneral = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescRecGeneral, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), DecimalesAMostrarEnPrecio)
            drVP.DescRecGeneralProducto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescRecGeneralProducto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
            drVP.ImporteTotalNeto = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotalNeto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), DecimalesAMostrarEnTotalXProducto)
            '-.PE-31657 .-
            drVP.PrecioLista = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioLista, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), DecimalesAMostrarEnTotalXProducto)
         Else
            drVP.Precio = vp.Precio
            drVP.PrecioNeto = vp.PrecioNeto
            drVP.ImporteTotal = vp.ImporteTotal
            drVP.Descuento = vp.DescuentoRecargo
            drVP.DescuentoProducto = vp.DescuentoRecargoProducto
            drVP.DescRecGeneralProducto = vp.DescRecGeneralProducto
            drVP.ImporteTotalNeto = vp.ImporteTotalNeto
            '-.PE-31657 .-
            drVP.PrecioLista = vp.PrecioLista
         End If
         drVP.ImporteImpuesto = vp.ImporteImpuesto
         drVP.ImporteImpuestoInterno = vp.ImporteImpuestoInterno

         'Para los comprobantes que por más que sean Responsables Inscriptos no desean discriminar los impuestos en las líneas.
         'drVP.PrecioConImpuestos = Decimal.Round(vp.Precio * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), DecimalesAMostrarEnPrecio)
         'drVP.PrecioNetoConImpuestos = Decimal.Round(vp.PrecioNeto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
         'drVP.ImporteTotalConImpuestos = Decimal.Round((vp.ImporteTotal * (1 + (vp.AlicuotaImpuesto / 100))) + vp.ImporteImpuestoInterno, DecimalesAMostrarEnTotalXProducto)
         'drVP.DescuentoConImpuestos = Decimal.Round(vp.DescuentoRecargo * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
         'drVP.DescuentoProductoConImpuestos = Decimal.Round(vp.DescuentoRecargoProducto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
         'drVP.DescRecGeneralProductoConImpuestos = Decimal.Round(vp.DescRecGeneralProducto * (1 + (vp.AlicuotaImpuesto / 100)), DecimalesAMostrarEnPrecio)
         'drVP.ImporteTotalNetoConImpuestos = Decimal.Round((vp.ImporteTotalNeto * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno), DecimalesAMostrarEnTotalXProducto)
         drVP.PrecioConImpuestos = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
         drVP.PrecioNetoConImpuestos = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioNeto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
         drVP.ImporteTotalConImpuestos = Decimal.Round((vp.ImporteTotal * (1 + (vp.AlicuotaImpuesto / 100))) + vp.ImporteImpuestoInterno, DecimalesAMostrarEnTotalXProducto)
         drVP.DescuentoConImpuestos = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescuentoRecargo, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
         drVP.DescuentoProductoConImpuestos = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescuentoRecargoProducto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
         'drVP.DescRecGeneral = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescRecGeneral, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), DecimalesAMostrarEnPrecio)
         drVP.DescRecGeneralProductoConImpuestos = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescRecGeneralProducto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), decimalesAMostrarEnPrecio)
         drVP.ImporteTotalNetoConImpuestos = Decimal.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotalNeto, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), DecimalesAMostrarEnTotalXProducto)


         If ((oVenta.TipoComprobante.IdTipoComprobante = "PRESUP" And Reglas.Publicos.Facturacion.FacturacionPresupuestoIncluyeRecargoGeneral(eSucursal)) Or
             (oVenta.TipoComprobante.GrabaLibro = False And Reglas.Publicos.Facturacion.GrabaLibroNoIncluyeRecargoGeneral(eSucursal))) And oVenta.DescuentoRecargoPorc > 0 Then
            drVP.Precio = drVP.Precio + Decimal.Round(drVP.Precio * oVenta.DescuentoRecargoPorc / 100, decimalesAMostrarEnPrecio)
            drVP.PrecioNeto = drVP.PrecioNeto + Decimal.Round(drVP.PrecioNeto * oVenta.DescuentoRecargoPorc / 100, decimalesAMostrarEnPrecio)
            drVP.ImporteTotal = drVP.ImporteTotal + Decimal.Round(drVP.ImporteTotal * oVenta.DescuentoRecargoPorc / 100, DecimalesAMostrarEnTotalXProducto)
            drVP.ImporteTotalNeto = drVP.ImporteTotalNeto + Decimal.Round(drVP.ImporteTotalNeto * oVenta.DescuentoRecargoPorc / 100, DecimalesAMostrarEnTotalXProducto)
            drVP.DescRecGeneralProducto = 0
         End If


         drVP.AlicuotaImpuesto = vp.AlicuotaImpuesto

         With drVP
            .ImporteTotal = .ImporteTotal * coe
            .Descuento = .Descuento * coe
         End With

         drVP.DescuentoProductoPorc1 = vp.DescuentoRecargoPorc1
         drVP.DescuentoProductoPorc2 = vp.DescuentoRecargoPorc2
         drVP.DescuentoProductoPorcCompuesto = Reglas.CalculosDescuentosRecargos.CombinaDosDescuentos(vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2, decimalesAMostrarEnPrecio)

         Dim precioParaDescuento As Decimal
         If Not oVenta.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
            If oVenta.TipoComprobante.GrabaLibro Or
               oVenta.TipoComprobante.EsPreElectronico Then
               precioParaDescuento = drVP.Precio - (drVP.ImporteImpuestoInterno / drVP.Cantidad)
            Else
               precioParaDescuento = drVP.Precio
            End If
         Else
            precioParaDescuento = drVP.Precio
         End If

         descRec1 = Decimal.Round(precioParaDescuento * vp.DescuentoRecargoPorc1 / 100, decimalesAMostrarEnPrecio)
         descRec2 = Decimal.Round((precioParaDescuento + descRec1) * vp.DescuentoRecargoPorc2 / 100, decimalesAMostrarEnPrecio)

         ImporteBruto += Decimal.Round((drVP.Precio + descRec1 + descRec2) * vp.Cantidad, 2)

         drVP.Embalaje = vp.Producto.Embalaje
         drVP.Kilos = vp.Kilos

         drVP.TipoOperacion = vp.TipoOperacion.ToString()
         drVP.TipoOperacionAbreviado = drVP.TipoOperacion.Substring(0, 1)
         drVP.OrdenTipoOperacion = vp.TipoOperacion
         drVP.NombreListaPrecios = vp.NombreListaPrecios
         drVP.NombreCortoListaPrecios = vp.NombreCortoListaPrecios

         drVP.Nota = vp.Nota

         '# Lotes Seleccionados
         drVP.LotesSeleccionados = String.Join(" / ", vp.VentasProductosLotes.ConvertAll(Function(vpl) String.Format("{0}", vpl.IdLote)))
         drVP.LotesSeleccionadosConCantidad = String.Join(" / ", vp.VentasProductosLotes.ConvertAll(Function(vpl) String.Format("{0}: {1:N2}", vpl.IdLote, vpl.Cantidad)))
         'nroSerieSeleccionados
         drVP.NroSerieSeleccionados = String.Join(" / ", vp.Producto.NrosSeries.ConvertAll(Function(ns) ns.NroSerie))
         'PE-31241

         If vp.IdEstadoVenta.HasValue Then
            drVP.IdEstadoVenta = vp.IdEstadoVenta.Value
            drVP.NombreEstadoVenta = New Reglas.EstadosVenta().GetUno(vp.IdEstadoVenta.Value, Reglas.Base.AccionesSiNoExisteRegistro.Vacio).NombreEstadoVenta
         End If
         drVP.IdProductoMercosur = vp.Producto.IdProductoMercosur
         drVP.IdProductoSecretaria = vp.Producto.IdProductoSecretaria

         VentasProductosDT.AddVentasProductosRow(drVP)

         '# Ventas Productos Formulas
         If Reglas.Publicos.Facturacion.Impresion.VentasImpresionImprimeComponentes Then

            Dim dtPC = New Reglas.VentasProductosFormulas().GetFormulas(drVP.IdSucursal, drVP.IdTipoComprobante, drVP.Letra,
                                                                                     drVP.CentroEmisor, drVP.NumeroComprobante, drVP.IdProducto, drVP.Orden)
            If dtPC.Rows.Count > 0 Then
               ' VentasProductosDT.AddCopy(drRep)
               For Each drPC In dtPC.AsEnumerable()
                  Dim drCompImp = VentasProductosDT.AddCopy(drVP)
                  drCompImp("IdProducto") = String.Empty
                  drCompImp("NombreProducto") = "    " + drPC.Field(Of String)("NombreProductoComponente")
                  Dim cantidad = If(Reglas.Publicos.Facturacion.Impresion.VentasImpresionImprimeCantidadComponentes, 1, drVP.Field(Of Decimal)("Cantidad"))
                  drCompImp("Cantidad") = drPC.Field(Of Decimal)("Cantidad") * cantidad
                  drCompImp("TipoOperacion") = Entidades.Producto.TiposOperaciones.PRODUCCION
                  drCompImp("Precio") = 0
                  drCompImp("DescuentoProductoPorc1") = 0
                  drCompImp("DescuentoProductoPorc2") = 0
                  drCompImp("AlicuotaImpuesto") = 0
                  drCompImp("ImporteTotal") = 0

               Next
               For j = 0 To Reglas.Publicos.Facturacion.Impresion.FacturacionImpresionCantidadLineasSeparacion - 1
                  Dim drCompImp = VentasProductosDT.AddCopy(drVP)
                  drCompImp("IdProducto") = String.Empty
                  drCompImp("NombreProducto") = String.Empty
                  drCompImp("Cantidad") = 0
                  drCompImp("TipoOperacion") = Entidades.Producto.TiposOperaciones.PRODUCCION
                  drCompImp("Precio") = 0
                  drCompImp("DescuentoProductoPorc1") = 0
                  drCompImp("DescuentoProductoPorc2") = 0
                  drCompImp("AlicuotaImpuesto") = 0
                  drCompImp("ImporteTotal") = 0
               Next

            End If
         End If

      Next



      '# Ventas Impuestos
      Dim line As SistemaDataSet.VentasImpuestosRow
      Me.VentasImpuestosDT = New SistemaDataSet.VentasImpuestosDataTable
      For Each vi As Entidades.VentaImpuesto In oVenta.VentasImpuestos
         line = VentasImpuestosDT.NewVentasImpuestosRow
         With line
            .IdSucursal = vi.IdSucursal
            .IdTipoComprobante = oVenta.IdTipoComprobante
            .Letra = oVenta.LetraComprobante
            .CentroEmisor = oVenta.CentroEmisor
            .NumeroComprobante = oVenta.NumeroComprobante
            .IdTipoImpuesto = vi.IdTipoImpuesto
            .Alicuota = vi.Alicuota
            .Bruto = vi.Bruto
            .Neto = vi.Neto
            .Importe = vi.Importe
            .Total = vi.Total
            .IdProvincia = vi.IdProvincia
         End With
         VentasImpuestosDT.AddVentasImpuestosRow(line)
      Next

      Me.VentasObservacionesDT = New SistemaDataSet.VentasObservacionesDataTable()
      Dim drVO As SistemaDataSet.VentasObservacionesRow

      Dim maxLinea As Integer = -1

      For Each vo As Entidades.VentaObservacion In oVenta.VentasObservaciones

         drVO = Me.VentasObservacionesDT.NewVentasObservacionesRow()

         drVO.IdSucursal = oVenta.IdSucursal
         drVO.IdTipoComprobante = oVenta.TipoComprobante.IdTipoComprobante
         drVO.Letra = oVenta.LetraComprobante
         drVO.CentroEmisor = oVenta.CentroEmisor
         drVO.NumeroComprobante = oVenta.NumeroComprobante
         drVO.Linea = vo.Linea
         drVO.Observacion = vo.Observacion

         maxLinea = Math.Max(maxLinea, vo.Linea)

         Me.VentasObservacionesDT.AddVentasObservacionesRow(drVO)
      Next


      If Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraLoteObservacion(eSucursal) Then
         For Each vp In oVenta.VentasProductosLotes
            drVO = VentasObservacionesDT.NewVentasObservacionesRow()

            drVO.IdSucursal = oVenta.IdSucursal
            drVO.IdTipoComprobante = oVenta.TipoComprobante.IdTipoComprobante
            drVO.Letra = oVenta.LetraComprobante
            drVO.CentroEmisor = oVenta.CentroEmisor
            drVO.NumeroComprobante = oVenta.NumeroComprobante
            maxLinea += 10
            drVO.Linea = maxLinea
            drVO.Observacion = String.Format("{2:N2} - {0}  -  {1}", vp.IdProducto, vp.IdLote, vp.Cantidad)

            VentasObservacionesDT.AddVentasObservacionesRow(drVO)
         Next
      End If

      'Total de Perceciones e Impuestos NO IVA
      Dim TotalImpuestosVarios As Decimal = 0
      For Each vi As Entidades.VentaImpuesto In oVenta.ImpuestosVarios
         TotalImpuestosVarios += vi.Importe
      Next

      Dim TotalImpuestos As Decimal = oVenta.TotalImpuestos - TotalImpuestosVarios
      Dim TotalImpuestoInterno As Decimal = oVenta.TotalImpuestoInterno

      If Not oVenta.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
         With oVenta
            .ImporteBruto = ImporteBruto
            '.DescuentoRecargo = (ImporteBruto - TotalImpuestoInterno) * (.DescuentoRecargoPorc / 100)
            .DescuentoRecargo = ImporteBruto * (.DescuentoRecargoPorc / 100)
            .Subtotal = .Subtotal + .TotalImpuestos - TotalImpuestosVarios + .TotalImpuestoInterno
            .TotalImpuestos = 0
         End With
         TotalImpuestos = 0
         TotalImpuestoInterno = 0
      End If

      With oVenta
         .ImporteBruto = .ImporteBruto * coe
         .DescuentoRecargo = .DescuentoRecargo * coe
         .Subtotal = .Subtotal * coe
         .ImporteTotal = .ImporteTotal * coe
      End With

      TotalImpuestos = TotalImpuestos * coe
      TotalImpuestosVarios = TotalImpuestosVarios * coe

      If ((oVenta.TipoComprobante.IdTipoComprobante = "PRESUP" And Reglas.Publicos.Facturacion.FacturacionPresupuestoIncluyeRecargoGeneral(eSucursal)) Or
         (oVenta.TipoComprobante.GrabaLibro = False And Reglas.Publicos.Facturacion.GrabaLibroNoIncluyeRecargoGeneral(eSucursal))) And oVenta.DescuentoRecargoPorc > 0 Then
         oVenta.ImporteBruto = oVenta.Subtotal
         oVenta.DescuentoRecargoPorc = 0
         oVenta.DescuentoRecargo = 0
      End If

      Dim pagare As String = String.Empty
      Me.Parametros = New List(Of ReportParameter)

      '      If oVenta.Proveedor.IdProveedor = 0 Then

      If Not oVenta.EsCtaOrden Then
         If oVenta.TipoComprobante.GrabaLibro Then
            Me.Parametros.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaOficial(eSucursal)))
            If String.IsNullOrWhiteSpace(oVenta.Impresora.DireccionCentroEmisor) Then
               Me.Parametros.Add(New ReportParameter("DireccionEmpresa", eSucursal.DireccionComercial & " - " & eSucursal.LocalidadComercial.NombreLocalidad))
            Else
               Me.Parametros.Add(New ReportParameter("DireccionEmpresa", oVenta.Impresora.DireccionCentroEmisor & " - " & oVenta.Impresora.LocalidadCentroEmisor.NombreLocalidad))
            End If
         Else
            Me.Parametros.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion(eSucursal)))
            Me.Parametros.Add(New ReportParameter("DireccionEmpresa", eSucursal.DireccionComercial & " - " & eSucursal.LocalidadComercial.NombreLocalidad))
         End If

         Me.Parametros.Add(New ReportParameter("TelefonoEmpresa", eSucursal.Telefono))

      Else
         Me.Parametros.Add(New ReportParameter("NombreEmpresa", oVenta.Proveedor.NombreProveedor))
         Me.Parametros.Add(New ReportParameter("TelefonoEmpresa", oVenta.Proveedor.TelefonoProveedor))
         Me.Parametros.Add(New ReportParameter("DireccionEmpresa", oVenta.Proveedor.DireccionProveedor & " - " & oVenta.Proveedor.NombreLocalidad))
      End If

      Me.Parametros.Add(New ReportParameter("FechaVencimiento1", oVenta.FechaVencimiento.IfNull()))
      Me.Parametros.Add(New ReportParameter("ImporteCuota", oVenta.ImporteCuota.IfNull()))
      Me.Parametros.Add(New ReportParameter("FechaVencimiento2", oVenta.FechaVencimiento2.IfNull()))
      Me.Parametros.Add(New ReportParameter("ImporteVencimiento2", oVenta.ImporteVencimiento2.IfNull()))
      Me.Parametros.Add(New ReportParameter("FechaVencimiento3", oVenta.FechaVencimiento3.IfNull()))
      Me.Parametros.Add(New ReportParameter("ImporteVencimiento3", oVenta.ImporteVencimiento3.IfNull()))
      Me.Parametros.Add(New ReportParameter("CodigoDeBarra", oVenta.CodigoDeBarra.IfNull()))
      Me.Parametros.Add(New ReportParameter("CodigoDeBarraSirplus", oVenta.CodigoDeBarraSirplus.IfNull()))

      'se agregaron estos 3 parametros para identificar en los reportes el Nombre de la Empresa sin ninguna alteracion
      Me.Parametros.Add(New ReportParameter("NombreEmpresaOriginal", Reglas.Publicos.NombreEmpresaOficial(eSucursal)))
      Me.Parametros.Add(New ReportParameter("DireccionEmpresaOriginal", eSucursal.Direccion & " - " & eSucursal.Localidad.NombreLocalidad))
      Me.Parametros.Add(New ReportParameter("TelefonoEmpresaOriginal", eSucursal.Telefono))
      '-------------------
      Me.Parametros.Add(New ReportParameter("VerValidez", Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraValidezPresupuesto))
      '-------------------
      Me.Parametros.Add(New ReportParameter("TipoComprobante", String.Concat(" ", oVenta.TipoComprobante.DescripcionImpresion))) ' Le concatenamos un espacio adelante porque los eComprobantes le sacaban un espacio para que no saliera eFactura
      Me.Parametros.Add(New ReportParameter("Letra", oVenta.LetraComprobante))
      Me.Parametros.Add(New ReportParameter("CentroEmisor", oVenta.Impresora.CentroEmisor.ToString()))
      Me.Parametros.Add(New ReportParameter("Numero", oVenta.NumeroComprobante.ToString()))
      Me.Parametros.Add(New ReportParameter("Fecha", oVenta.Fecha.ToString()))
      Me.Parametros.Add(New ReportParameter("FechaHasta", oVenta.Fecha.AddDays(Reglas.Publicos.DiasValidezPresupuesto(eSucursal)).ToString()))
      '--------------------------------------------------------------------------------------------
      If Not String.IsNullOrWhiteSpace(oVenta.NroFacturaProveedor) Then
         Me.Parametros.Add(New ReportParameter("NroFacturaProveedor", oVenta.NroFacturaProveedor))
      Else
         Me.Parametros.Add(New ReportParameter("NroFacturaProveedor", ""))
      End If
      If Not String.IsNullOrWhiteSpace(oVenta.NroRemitoProveedor) Then
         Me.Parametros.Add(New ReportParameter("NroRemitoProveedor", oVenta.NroRemitoProveedor))
      Else
         Me.Parametros.Add(New ReportParameter("NroRemitoProveedor", ""))
      End If

      '-- REQ-35923.- -------------------------------------------------------------------------------------------------
      Me.Parametros.Add(New ReportParameter("MuestraHoraVenta", Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraHoraVenta))
      '----------------------------------------------------------------------------------------------------------------

      Dim nombreProveedorOC = String.Empty
      If oVenta.NumeroOrdenCompra > 0 Then
         Dim oc = New Reglas.OrdenesCompra().GetUno(eSucursal.IdSucursal, oVenta.NumeroOrdenCompra, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
         If oc IsNot Nothing Then
            Dim prov = New Reglas.Proveedores().GetUno(oc.IdProveedor, incluirFoto:=False)
            nombreProveedorOC = prov.NombreProveedor
         End If
      End If
      Parametros.Add(New ReportParameter("NombreProveedorOC", nombreProveedorOC))
      '--------------------------------------------------------------------------------------------
      Dim fechaVencimiento = Today
      If oVenta.CuentaCorriente IsNot Nothing AndAlso oVenta.CuentaCorriente.Pagos IsNot Nothing AndAlso oVenta.CuentaCorriente.Pagos.Count > 0 Then
         fechaVencimiento = oVenta.CuentaCorriente.Pagos.Min(Function(x) x.FechaVencimiento)
      End If

      Me.Parametros.Add(New ReportParameter("FechaVencimiento", fechaVencimiento.ToString()))
      Me.Parametros.Add(New ReportParameter("ReferenciaComercial", oVenta.ReferenciaComercial.ToString()))
      Me.Parametros.Add(New ReportParameter("CantidadInvocados", oVenta.CantidadInvocados))

      If Not oVenta.Cliente.EsClienteGenerico Then
         Me.Parametros.Add(New ReportParameter("NombreYApellido", oVenta.Cliente.NombreCliente))
      Else
         Me.Parametros.Add(New ReportParameter("NombreYApellido", oVenta.NombreCliente))
      End If
      Me.Parametros.Add(New ReportParameter("NombreDeFantasiaCliente", oVenta.Cliente.NombreDeFantasia))

      Me.Parametros.Add(New ReportParameter("TipoYNroDocumento", oVenta.Cliente.CodigoCliente.ToString()))
      Me.Parametros.Add(New ReportParameter("Twitter", oVenta.Cliente.Twitter.ToString()))


      If oVenta.ClienteVinculado IsNot Nothing Then
         Me.Parametros.Add(New ReportParameter("TieneClienteVinculado", Boolean.TrueString))
         Me.Parametros.Add(New ReportParameter("CodigoClienteVinculado", oVenta.CodigoClienteVinculado))
         Me.Parametros.Add(New ReportParameter("NombreClienteVinculado", oVenta.NombreClienteVinculado))
      Else
         Me.Parametros.Add(New ReportParameter("TieneClienteVinculado", Boolean.FalseString))
         Me.Parametros.Add(New ReportParameter("CodigoClienteVinculado", String.Empty))
         Me.Parametros.Add(New ReportParameter("NombreClienteVinculado", String.Empty))
      End If

      Parametros.Add(New ReportParameter("Cliente_Direccion", oVenta.Cliente.Direccion))
      Parametros.Add(New ReportParameter("Cliente_Localidad", oVenta.Cliente.Localidad.NombreLocalidad))
      Parametros.Add(New ReportParameter("Cliente_CodigoPostal", oVenta.Cliente.Localidad.IdLocalidad.ToString()))
      Parametros.Add(New ReportParameter("Cliente_Provincia", oVenta.Cliente.Localidad.NombreProvincia))

      Parametros.Add(New ReportParameter("CategoriaIVA", oVenta.CategoriaFiscal.NombreCategoriaFiscal))
      Parametros.Add(New ReportParameter("IdCategoriaFiscal", oVenta.CategoriaFiscal.IdCategoriaFiscal.ToString()))
      Parametros.Add(New ReportParameter("Direccion", oVenta.Direccion))
      Parametros.Add(New ReportParameter("Telefono", oVenta.Cliente.Telefono & " " & oVenta.Cliente.Celular))
      Parametros.Add(New ReportParameter("Localidad", oVenta.Localidad.NombreLocalidad & " ( " & String.Format(oVenta.Localidad.IdLocalidad).Truncar(4) & " ) - " & oVenta.Localidad.NombreProvincia))
      Parametros.Add(New ReportParameter("ZonaGeografica", oVenta.Cliente.ZonaGeografica.NombreZonaGeografica))

      If Not oVenta.Cliente.EsClienteGenerico Then
         If oVenta.CategoriaFiscal.SolicitaCUIT = False Then
            '<<parámetro mal escrito>>
            Me.Parametros.Add(New ReportParameter("TipoIdentifiacionFiscal", oVenta.Cliente.TipoDocCliente.ToUpper() + ":"))
            Me.Parametros.Add(New ReportParameter("NroIdentifiacionFiscal", oVenta.Cliente.NroDocCliente))
            '<<nuevo parámetro>>
            Me.Parametros.Add(New ReportParameter("TipoIdentificacionFiscal", oVenta.Cliente.TipoDocCliente.ToUpper() + ":"))
            Me.Parametros.Add(New ReportParameter("NroIdentificacionFiscal", oVenta.Cliente.NroDocCliente))
         Else
            '<<parámetro mal escrito>>
            Me.Parametros.Add(New ReportParameter("TipoIdentifiacionFiscal", My.Resources.RTextos.Cuit.ToUpper() + ":"))
            '<<nuevo parámetro>>
            Me.Parametros.Add(New ReportParameter("TipoIdentificacionFiscal", My.Resources.RTextos.Cuit.ToUpper() + ":"))
            Dim nroIdentifiacionFiscal As String = oVenta.Cliente.Cuit.Replace("-", "")

            If Not String.IsNullOrWhiteSpace(nroIdentifiacionFiscal) Then
               nroIdentifiacionFiscal = Decimal.Parse(nroIdentifiacionFiscal).ToString("00-00000000-0")
            End If
            '<<parámetro mal escrito>>
            Me.Parametros.Add(New ReportParameter("NroIdentifiacionFiscal", nroIdentifiacionFiscal))
            '<<nuevo parámetro>>
            Me.Parametros.Add(New ReportParameter("NroIdentificacionFiscal", nroIdentifiacionFiscal))
         End If
      Else
         If oVenta.CategoriaFiscal.SolicitaCUIT = False Then
            '<<parámetro mal escrito>>
            Me.Parametros.Add(New ReportParameter("TipoIdentifiacionFiscal", oVenta.TipoDocCliente.ToUpper() + ":"))
            Me.Parametros.Add(New ReportParameter("NroIdentifiacionFiscal", oVenta.NroDocCliente))
            '<<nuevo parámetro>>
            Me.Parametros.Add(New ReportParameter("TipoIdentificacionFiscal", oVenta.TipoDocCliente.ToUpper() + ":"))
            Me.Parametros.Add(New ReportParameter("NroIdentificacionFiscal", oVenta.NroDocCliente))
         Else
            '<<parámetro mal escrito>>
            Me.Parametros.Add(New ReportParameter("TipoIdentifiacionFiscal", My.Resources.RTextos.Cuit.ToUpper() + ":"))
            '<<nuevo parámetro>>
            Me.Parametros.Add(New ReportParameter("TipoIdentificacionFiscal", My.Resources.RTextos.Cuit.ToUpper() + ":"))
            Dim nroIdentifiacionFiscal As String = oVenta.Cuit.Replace("-", "")

            If Not String.IsNullOrWhiteSpace(nroIdentifiacionFiscal) Then
               nroIdentifiacionFiscal = Decimal.Parse(nroIdentifiacionFiscal).ToString("00-00000000-0")
            End If
            '<<parámetro mal escrito>>
            Me.Parametros.Add(New ReportParameter("NroIdentifiacionFiscal", nroIdentifiacionFiscal))
            '<<nuevo parámetro>>
            Me.Parametros.Add(New ReportParameter("NroIdentificacionFiscal", nroIdentifiacionFiscal))
         End If
      End If

      If Not oVenta.Cliente.EsClienteGenerico Then
         Me.Parametros.Add(New ReportParameter("Cuit", "0" & oVenta.Cliente.Cuit.Replace("-", "")))
      Else
         Me.Parametros.Add(New ReportParameter("Cuit", "0" & oVenta.Cuit.Replace("-", "")))
      End If
      Me.Parametros.Add(New ReportParameter("HorarioClienteCompleto", oVenta.Cliente.HorarioClienteCompleto))
      '-- REQ-34356.- ------------------------------------------------------------------------------------------------------
      Me.Parametros.Add(New ReportParameter("IdImpositivoOtroPais", If(oVenta.Cliente.IdImpositivoOtroPais, String.Empty)))
      '---------------------------------------------------------------------------------------------------------------------
      Parametros.Add(New ReportParameter("FormaPago", oVenta.FormaPago.DescripcionFormasPago))
      Parametros.Add(New ReportParameter("FormaPagoDias", oVenta.FormaPago.Dias.ToString()))
      Parametros.Add(New ReportParameter("Observacion", oVenta.Observacion))
      Parametros.Add(New ReportParameter("NumeroOrdenCompra", oVenta.NumeroOrdenCompra.ToString()))
      Parametros.Add(New ReportParameter("Usuario", oVenta.Usuario)) 'nuevo parametro
      Parametros.Add(New ReportParameter("Vendedor", oVenta.Vendedor.NombreEmpleado))
      Parametros.Add(New ReportParameter("TipoDocVendedor", oVenta.Vendedor.TipoDocEmpleado))
      Parametros.Add(New ReportParameter("NroDocVendedor", oVenta.Vendedor.NroDocEmpleado))
      Parametros.Add(New ReportParameter("Bruto", oVenta.ImporteBruto.ToString()))
      Parametros.Add(New ReportParameter("DescuentoRecargo", oVenta.DescuentoRecargo.ToString()))
      Parametros.Add(New ReportParameter("DescuentoRecargoPorc", oVenta.DescuentoRecargoPorc.ToString()))
      Parametros.Add(New ReportParameter("Subtotal", oVenta.Subtotal.ToString()))
      Parametros.Add(New ReportParameter("TotalIVA", TotalImpuestos.ToString()))
      Parametros.Add(New ReportParameter("TotalImpuestosVarios", TotalImpuestosVarios.ToString()))
      Parametros.Add(New ReportParameter("TotalImpuestosInternos", TotalImpuestoInterno.ToString()))
      Parametros.Add(New ReportParameter("Total", oVenta.ImporteTotal.ToString()))
      Parametros.Add(New ReportParameter("Total_EnLetras", Numeros_A_Letras.EnLetras(oVenta.ImporteTotal.ToString())))
      Parametros.Add(New ReportParameter("Total_EnLetras_Dolares", Numeros_A_Letras.Instancia().EnLetras(If(oVenta.CotizacionDolar = 0, 0, Math.Round(oVenta.ImporteTotal / oVenta.CotizacionDolar, 2)).ToString(), Numeros_A_Letras.MonedaEnum.Dolares, monedaAlFinal:=True)))
      Parametros.Add(New ReportParameter("Cbu", oVenta.Cbu))
      Parametros.Add(New ReportParameter("CbuAlias", oVenta.CbuAlias))
      Parametros.Add(New ReportParameter("Kilos", oVenta.Kilos.ToString()))
      Parametros.Add(New ReportParameter("DecimalesEnCantidad", If(Reglas.Publicos.ProductoUtilizaCantidadesEnteras(eSucursal), 0I, 2I).ToString()))
      Parametros.Add(New ReportParameter("DecimalesEnPrecio", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio(eSucursal).ToString()))
      Parametros.Add(New ReportParameter("DecimalesEnTotalXProducto", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto(eSucursal).ToString()))
      Parametros.Add(New ReportParameter("DescripcionAdicionalEmpresa", Reglas.Publicos.DescripcionAdicionalEmpresa(eSucursal)))
      Parametros.Add(New ReportParameter("eMail", eSucursal.Correo.ToString()))
      Parametros.Add(New ReportParameter("web", Reglas.Publicos.DireccionWebEmpresa(eSucursal)))
      Parametros.Add(New ReportParameter("RedesSocialesSucursal", eSucursal.RedesSociales))
      Parametros.Add(New ReportParameter("ZonaGeografica", oVenta.Cliente.ZonaGeografica.IdZonaGeografica))
      Parametros.Add(New ReportParameter("NumeroReparto", oVenta.NumeroReparto))
      Parametros.Add(New ReportParameter("CantidadDecimalesCantidad", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()))

      ' Facturables
      Dim NumeroComprobanteFact As String = String.Empty
      Dim i As Integer = 0 ' # Indice

      ' # Junto los Num. Comprobantes de todos los facturables que tenga la venta
      NumeroComprobanteFact = String.Join("/", oVenta.Invocados.ToList().ConvertAll(Function(vv) String.Format("{0:0000}-{1:00000000}", vv.CentroEmisorInvocado, vv.NumeroComprobanteInvocado)))

      'INVMUL:
      ''''' # Junto los Num. Comprobantes de todos los facturables que tenga la venta
      ''''If oVenta.Facturables IsNot Nothing Then
      ''''   For Each item As Entidades.Venta In oVenta.Facturables
      ''''      i += 1
      ''''      NumeroComprobanteFact = String.Format("{0:0000}-{1:00000000}", item.CentroEmisor, item.NumeroComprobante)

      ''''      ' # Verifico si existe más de un item 'facturable' para controlar la "/" de separación. 
      ''''      Dim temp As Boolean = If(i = oVenta.Facturables.Count, True, False)
      ''''      If Not temp Then NumeroComprobanteFact = String.Concat(NumeroComprobanteFact, " / ")
      ''''   Next
      ''''End If
      Me.Parametros.Add(New ReportParameter("NumeroComprobanteFact", NumeroComprobanteFact))
      ' ------------------------------------------------------------

      ' Se agregan los Importes distinguidos por Forma de Pago
      Me.Parametros.Add(New ReportParameter("ImporteTotalPesos", ImporteTotalPesos))
      Me.Parametros.Add(New ReportParameter("ImporteTotalCheques", ImporteTotalCheques))
      Me.Parametros.Add(New ReportParameter("ImporteTotalTickets", ImporteTotalTickets))
      Me.Parametros.Add(New ReportParameter("ImporteTotalTarjetas", ImporteTotalTarjetas))
      ' ------------------------------------------------------------

      Me.Parametros.Add(New ReportParameter("TotalKilos", oVenta.Kilos))
      Me.Parametros.Add(New ReportParameter("TotalProductos", oVenta.CantidadProductos))
      Me.Parametros.Add(New ReportParameter("MuestraTotalKilos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalKilos(eSucursal)))
      Me.Parametros.Add(New ReportParameter("MuestraTotalProductos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalProductos(eSucursal)))

      Me.Parametros.Add(New ReportParameter("Provincia", oVenta.Localidad.NombreProvincia))
      If oVenta.CotizacionDolar = 0 Then
         Me.Parametros.Add(New ReportParameter("TotalDolaresEnLetras", ""))
      Else
         Me.Parametros.Add(New ReportParameter("TotalDolaresEnLetras", Eniac.Win.Numeros_A_Letras.EnLetrasSinMoneda((oVenta.ImporteTotal / oVenta.CotizacionDolar).ToString())))
      End If
      Me.Parametros.Add(New ReportParameter("MesEnLetras", oVenta.Fecha.GetMesEnEspanol()))

      'Calculo el saldo para imprimirlo
      Dim SaldoActual As Decimal = 0
      Dim blnContemplaHora As Boolean = Reglas.Publicos.Facturacion.SaldoContemplaHora(eSucursal)

      Dim muestraSaldoUnificado = Reglas.Publicos.Facturacion.Impresion.MuestraSaldoImpresionUnificado(eSucursal)
      If (Not muestraSaldoUnificado AndAlso oVenta.SaldoActualCtaCte.HasValue) OrElse (muestraSaldoUnificado AndAlso oVenta.SaldoActualCtaCteUnificado.HasValue) Then
         If Not muestraSaldoUnificado Then
            SaldoActual = oVenta.SaldoActualCtaCte.Value
         Else
            SaldoActual = oVenta.SaldoActualCtaCteUnificado.Value
         End If
      Else
         Dim grabaLibro As Boolean? = oVenta.TipoComprobante.GrabaLibro
         If muestraSaldoUnificado Then
            grabaLibro = Nothing
         End If
         'SPC - 07/03/2017 - Parametrizamos para mayor flexibilidad.
         If Reglas.Publicos.Facturacion.SaldoTomaActualAlImprimir(eSucursal) Then
            SaldoActual = New Reglas.CuentasCorrientes().GetSaldoCliente({eSucursal}, oVenta.Cliente.IdCliente, Nothing, blnContemplaHora, "TODOS", grabaLibro, Nothing, "", False, 0, 0)
         Else
            SaldoActual = New Reglas.CuentasCorrientes().GetSaldoCliente({eSucursal}, oVenta.Cliente.IdCliente, oVenta.Fecha, blnContemplaHora, "TODOS", grabaLibro, Nothing, "", False, 0, 0)
         End If
      End If

      Parametros.Add(New ReportParameter("Coeficiente", coe.ToString()))
      Parametros.Add(New ReportParameter("SaldoActual", SaldoActual.ToString()))
      Parametros.Add(New ReportParameter("MuestraSaldo", Reglas.Publicos.Facturacion.Impresion.MuestraSaldoImpresion(eSucursal)))
      Parametros.Add(New ReportParameter("MuestraVendedor", Reglas.Publicos.Facturacion.Impresion.MuestraVendedorImpresion(eSucursal)))
      '--------------------------------

      Parametros.Add(New ReportParameter("CotizacionDolar", oVenta.CotizacionDolar.ToString()))
      Parametros.Add(New ReportParameter("CP", Strings.Left(oVenta.Cliente.IdLocalidad.ToString, 4)))


      ' ** Factura Electronica ** (Compartido por otros)
      Dim codigoBarras As String = String.Empty

      '# Variables utilizadas para la generación del QR
      Dim infoQR As String = String.Empty
      Dim QR As String = String.Empty
      Dim QRMime As String = String.Empty
      '--------------------------------------
      With oVenta
         If .TipoComprobante.EsElectronico And Not .TipoComprobante.EsPreElectronico Then
            '# Código de Barras
            codigoBarras = New Publicos().GetCodigoBarrasFE(Reglas.Publicos.CuitEmpresa(eSucursal),
                                                            .AFIPIdTipoComprobante,
                                                            .CentroEmisor,
                                                            .AFIPCAE.CAE,
                                                            .AFIPCAE.CAEVencimiento)
            '# Código QR
            Dim tipoCodigoAutorizacion As String = "E" '# CAE = E // CAEA = A
            infoQR = New Reglas.Ventas().GetInfoCodigoQR(.Fecha,
                                                         Convert.ToInt64(Reglas.Publicos.CuitEmpresa(eSucursal)),
                                                         .CentroEmisor,
                                                         .AFIPIdTipoComprobante,
                                                         .NumeroComprobante,
                                                         .ImporteTotal,
                                                         .IdMoneda,
                                                         .CotizacionDolar,
                                                         .IdAFIPTipoDocCliente,
                                                         .AFIPNroDocCliente,
                                                         tipoCodigoAutorizacion,
                                                         .AFIPCAE.CAE)

            Dim img As System.Drawing.Image = Ayudante.QRCodeHelper.GenerarQR(infoQR)

            '# QR & QRMime para la generación del QR en la impresión
            QR = img.ConvertImageToBase64(ImageFormat.Png)
            QRMime = ImageFormat.Png.MimeType
         End If
      End With

      Me.Parametros.Add(New ReportParameter("CodigoBarras", codigoBarras)) '# Código de Barras
      Me.Parametros.Add(New ReportParameter("QR", QR)) '# QR
      Me.Parametros.Add(New ReportParameter("QRMime", QRMime)) '# QR

      Me.Parametros.Add(New ReportParameter("CAE", If(String.IsNullOrWhiteSpace(oVenta.AFIPCAE.CAE), String.Empty, oVenta.AFIPCAE.CAE)))
      Me.Parametros.Add(New ReportParameter("IdAFIPTipoComprobante", oVenta.AFIPIdTipoComprobante))

      '################################################################# 
      '# El parámetro de TipoImpresionFiscal se traslada abajo de todo #
      '#################################################################

      Me.Parametros.Add(New ReportParameter("CAEVencimiento", oVenta.AFIPCAE.CAEVencimiento.ToString()))
      Me.Parametros.Add(New ReportParameter("EmpresaCUIT", Reglas.Publicos.CuitEmpresa(eSucursal)))
      Me.Parametros.Add(New ReportParameter("NombreFantasia", Reglas.Publicos.NombreFantasia(eSucursal)))
      Me.Parametros.Add(New ReportParameter("NombreDeFantasia", Reglas.Publicos.NombreFantasia(eSucursal)))
      Me.Parametros.Add(New ReportParameter("FechaInicioActividades", Reglas.Publicos.FechaInicioActividades(eSucursal)))
      Me.Parametros.Add(New ReportParameter("IngresosBrutos", Reglas.Publicos.IngresosBrutos(eSucursal)))
      Me.Parametros.Add(New ReportParameter("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre(eSucursal)))
      Me.Parametros.Add(New ReportParameter("NumeroDocumento", oVenta.Cliente.NroDocCliente))
      '-----------------------------------------------------------------
      Dim DiscriminaIVA As Boolean = oVenta.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado
      Me.Parametros.Add(New ReportParameter("DiscriminaIVA", DiscriminaIVA))

      If Not oVenta.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
         Me.Parametros.Add(New ReportParameter("IVA0", 0))
         Me.Parametros.Add(New ReportParameter("IVA025", 0))
         Me.Parametros.Add(New ReportParameter("IVA050", 0))
         Me.Parametros.Add(New ReportParameter("IVA105", 0))
         Me.Parametros.Add(New ReportParameter("IVA210", 0))
         Me.Parametros.Add(New ReportParameter("IVA270", 0))
      Else
         Me.Parametros.Add(New ReportParameter("IVA0", oVenta.TotalIVA(0)))
         Me.Parametros.Add(New ReportParameter("IVA025", oVenta.TotalIVA(2.5) * coe))
         Me.Parametros.Add(New ReportParameter("IVA050", oVenta.TotalIVA(5) * coe))
         Me.Parametros.Add(New ReportParameter("IVA105", oVenta.TotalIVA(10.5) * coe))
         Me.Parametros.Add(New ReportParameter("IVA210", oVenta.TotalIVA(21) * coe))
         Me.Parametros.Add(New ReportParameter("IVA270", oVenta.TotalIVA(27) * coe))
      End If

      Me.Parametros.Add(New ReportParameter("IdCategoria", oVenta.Cliente.IdCategoria.ToString()))

      Me.Parametros.Add(New ReportParameter("Bultos", oVenta.Bultos))
      Me.Parametros.Add(New ReportParameter("ValorDeclarado", oVenta.ValorDeclarado))
      Me.Parametros.Add(New ReportParameter("NumeroLote", oVenta.NumeroLote))

      Me.Parametros.Add(New ReportParameter("Transportista_Nombre", oVenta.Transportista.NombreTransportista))
      Me.Parametros.Add(New ReportParameter("Transportista_Direccion", oVenta.Transportista.DireccionTransportista))
      Me.Parametros.Add(New ReportParameter("Transportista_Localidad", oVenta.Transportista.NombreLocalidad))
      Me.Parametros.Add(New ReportParameter("Transportista_CUIT", "0" & oVenta.Transportista.CuitTransportista.Replace("-", "")))
      Me.Parametros.Add(New ReportParameter("Transportista_CategoriaIVA", oVenta.Transportista.CategoriaFiscal.NombreCategoriaFiscal))
      Me.Parametros.Add(New ReportParameter("Transportista_Telefono", oVenta.Transportista.TelefonoTransportista))

      '-- REQ-33791.- --------------------------------------------------------------------------------------------------
      If Not String.IsNullOrEmpty(oVenta.NombreTransportistaTransporte) Then
         Me.Parametros.Add(New ReportParameter("NombreTransportista", oVenta.NombreTransportistaTransporte))
         Me.Parametros.Add(New ReportParameter("PatenteVehiculo", oVenta.VehiculoTransporte.PatenteVehiculo))
         Me.Parametros.Add(New ReportParameter("NombreMarcaVehiculo", New Reglas.MarcasVehiculos().GetUno(oVenta.VehiculoTransporte.IdMarcaVehiculo).NombreMarcaVehiculo))
         Me.Parametros.Add(New ReportParameter("NombreModeloVehiculo", New Reglas.ModelosVehiculos().GetUno(oVenta.VehiculoTransporte.IdModeloVehiculo).NombreModeloVehiculo))
      Else
         Me.Parametros.Add(New ReportParameter("NombreTransportista", ""))
         Me.Parametros.Add(New ReportParameter("PatenteVehiculo", ""))
         Me.Parametros.Add(New ReportParameter("NombreMarcaVehiculo", ""))
         Me.Parametros.Add(New ReportParameter("NombreModeloVehiculo", ""))

      End If
      '-----------------------------------------------------------------------------------------------------------------
      Dim horario As String = oVenta.Cliente.HorarioToString()

      Me.Parametros.Add(New ReportParameter("HorarioCliente", horario))

      If oVenta.IdPaciente.HasValue Then
         Me.Parametros.Add(New ReportParameter("Paciente", New Reglas.Clientes().GetUno(oVenta.IdPaciente).NombreCliente))
      End If
      If oVenta.IdDoctor.HasValue Then
         Me.Parametros.Add(New ReportParameter("Doctor", New Reglas.Clientes().GetUno(oVenta.IdDoctor).NombreCliente))
      End If
      If oVenta.FechaCirugia.HasValue Then
         Me.Parametros.Add(New ReportParameter("FechaCirugia", oVenta.FechaCirugia))
      End If

      Me.ReporteDataSource = String.Empty
      Me.ReporteDataSource2 = String.Empty

      Titulo = oVenta.TipoComprobante.Descripcion
      ReporteDataSource2 = "SistemaDataSet_VentasObservaciones" '# Observaciones
      ReporteDataSource3 = "SistemaDataSet_VentasImpuestos" '# Impuestos 

      '# Cuotas 
      '<< La impresión desde Informe de Ventas NO ESTÁ PENSADA para realizar una impresión de Cuotas. Se pasa un ds VACIO. >>
      ReporteDataSource4 = "CuotasDataTable"
      Me.CuotasDT = New TurismoDataSet.CuotasDataTable()

      '# Logo
      Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
      Dim LogoImagen As System.Drawing.Image

      If oVenta.Proveedor.IdProveedor > 0 Then
         LogoImagen = oVenta.Proveedor.Foto
      Else
         LogoImagen = Eniac.Entidades.Usuario.Actual.Logo
      End If

      Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
      Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

      Select Case oVenta.TipoComprobante.IdTipoComprobante
         Case "PRESUP", "PRESUPUESTO"

            ReporteNombre = "Eniac.Win.Presupuesto.rdlc"
            ReporteDataSource = "SistemaDataSet_VentasProductos"

            'Dim nombreLogo As String = Publicos.NombreLogo

            'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
            'Dim LogoImagen As System.Drawing.Image
            'Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
            'Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

         Case "REMITO", "DESHACE-REMITO", "CANCELA-REMITO", "DEV-REMITO"

            If oVenta.Proveedor.IdProveedor > 0 Then

               ReporteNombre = "Eniac.Win.RemitoLogo.rdlc"
               ReporteDataSource = "SistemaDataSet_VentasProductos"

               'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
               'Dim LogoImagen As System.Drawing.Image = oVenta.Proveedor.Foto

               'Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
               'Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

            Else
               ReporteNombre = "Eniac.Win.Remito.rdlc"
               ReporteDataSource = "SistemaDataSet_VentasProductos"
            End If


         Case "REMITOTRANSP", "ENTREGAMERCAD"

            If oVenta.Proveedor.IdProveedor > 0 Then

               ReporteNombre = "Eniac.Win.RemitoTransportistaLogo.rdlc"
               ReporteDataSource = "SistemaDataSet_VentasProductos"

               'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
               'Dim LogoImagen As System.Drawing.Image = oVenta.Proveedor.Foto

               'Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
               'Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

            Else

               'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
               'Dim LogoImagen As System.Drawing.Image = Eniac.Entidades.Usuario.Actual.Logo

               'Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
               'Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

               ReporteNombre = "Eniac.Win.RemitoTransportista_SinLogo.rdlc"
               ReporteDataSource = "SistemaDataSet_VentasProductos"
            End If



         Case "FACT", "NCRED", "NDEB", "PROFORMA", "DEV-PROFORMA", "COTIZACION", "DEV-COTIZACION", "NDEBCHEQRECH", "COTIZCHEQRECH"

            If oVenta.Proveedor.IdProveedor > 0 Then

               ReporteNombre = "Eniac.Win.ComprobanteLogo.rdlc"
               ReporteDataSource = "SistemaDataSet_VentasProductos"


               'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
               'Dim LogoImagen As System.Drawing.Image = oVenta.Proveedor.Foto

               'Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
               'Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

            Else
               ReporteNombre = "Eniac.Win.Comprobante.rdlc"
               ReporteDataSource = "SistemaDataSet_VentasProductos"

               'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
               'Dim LogoImagen As System.Drawing.Image = Eniac.Entidades.Usuario.Actual.Logo

               'Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
               'Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))
            End If

         Case "FACTCOM", "NCREDCOM", "NDEBCOM", "REMITOCOM", "REMITOCOM-NC", "REMITOCOM-ND"

            ReporteNombre = "Eniac.Win.ComprobanteCompra.rdlc"
            ReporteDataSource = "SistemaDataSet_ComprasProductos"

         Case "TICKET-CAJA", "TICKET-NC-CAJA"

            ReporteNombre = "Eniac.Win.ComprobanteTicket.rdlc"
            ReporteDataSource = "SistemaDataSet_VentasProductos"

            'parm.Add(New ReportParameter("NombreDeFantasia", Publicos.NombreFantasia))

         Case "COMANDA", "COMANDACOCINA", "COMANDAVARIOS"

            ReporteNombre = "Eniac.Win.ComprobanteComanda.rdlc"
            ReporteDataSource = "SistemaDataSet_VentasProductos"

            'parm.Add(New ReportParameter("NombreDeFantasia", Publicos.NombreFantasia))

         Case Else

            ReporteDataSource = "SistemaDataSet_VentasProductos"

            If oVenta.TipoComprobante.EsElectronico And Not oVenta.TipoComprobante.EsPreElectronico Then

               'Si es Electronico pero no tiene CAE le muestro el diseño con leyenda "Documento NO Valido como Factura"

               'Dim nombreLogo As String = actual.Sucursal.LogoSucursal.ToString()
               'Dim nombreLogo As String = Publicos.NombreLogo

               'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()

               'Pasado manualmente (en casos que lo perdieron)
               If String.IsNullOrEmpty(oVenta.AFIPCAE.CAE) Then

                  'Si no tengo CAE, no puedo imprimir la eFactura su formato ya que no sería legal
                  'Fuerzo que se utilice el estandar y cambio el parámetro de utilizarComprobanteEstandar a True
                  'para que no me lo cambie con los seteos del cliente
                  ReporteNombre = "Eniac.Win.Comprobante.rdlc"
                  utilizarComprobanteEstandar = True

               Else

                  'este parametro por ahora se agrego solo en este rdlc, a futuro tenemos que ver de agregar al resto, previa evalucación
                  ''Me.Parametros.Add(New ReportParameter("TipoImpresionFiscal", Publicos.TipoImpresionFiscal))
                  Dim tipoImpresionFiscal = Reglas.Publicos.TipoImpresionFiscal(eSucursal)

                  If oVenta.IdMoneda <> 2 Then
                     If Not oVenta.TipoComprobante.AFIPWSEsFEC Then
                        Select Case tipoImpresionFiscal
                           Case 1 'Original
                              ReporteNombre = "Eniac.Win.eComprobante.rdlc"
                           Case 2 'Original y Duplicado
                              ReporteNombre = "Eniac.Win.eComprobante_x_2.rdlc"
                           Case 3 'Original, Duplicado y Triplicado
                              ReporteNombre = "Eniac.Win.eComprobante_x_3.rdlc"
                        End Select
                     Else
                        Select Case tipoImpresionFiscal
                           Case 1 'Original
                              ReporteNombre = "Eniac.Win.eComprobanteCredito.rdlc"
                           Case 2 'Original y Duplicado
                              ReporteNombre = "Eniac.Win.eComprobanteCredito_x_2.rdlc"
                           Case 3 'Original, Duplicado y Triplicado
                              ReporteNombre = "Eniac.Win.eComprobanteCredito_x_3.rdlc"
                        End Select
                     End If

                  Else
                     If Not oVenta.TipoComprobante.AFIPWSEsFEC Then
                        Select Case tipoImpresionFiscal
                           Case 1 'Original
                              ReporteNombre = "Eniac.Win.eComprobanteDolares.rdlc"
                           Case 2 'Original y Duplicado
                              ReporteNombre = "Eniac.Win.eComprobanteDolares_x_2.rdlc"
                           Case 3 'Original, Duplicado y Triplicado
                              ReporteNombre = "Eniac.Win.eComprobanteDolares_x_3.rdlc"
                        End Select
                     Else
                        Select Case tipoImpresionFiscal
                           Case 1 'Original
                              ReporteNombre = "Eniac.Win.eComprobanteCreditoDolares.rdlc"
                           Case 2 'Original y Duplicado
                              ReporteNombre = "Eniac.Win.eComprobanteCreditoDolares_x_2.rdlc"
                           Case 3 'Original, Duplicado y Triplicado
                              ReporteNombre = "Eniac.Win.eComprobanteCreditoDolares_x_3.rdlc"
                        End Select
                     End If
                  End If

                  '  Dim LogoImagen As System.Drawing.Image = parI.GetValor(Entidades.ParametroImagen.Parametros.LOGOEMPRESA)
                  'Dim LogoImagen As System.Drawing.Image = Eniac.Entidades.Usuario.Actual.Logo

                  'Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
                  'Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

               End If

            Else
               'Otros tipos de comprobantes (inventados)
               If oVenta.IdMoneda <> 2 Then
                  ReporteNombre = "Eniac.Win.Comprobante.rdlc"
               Else
                  ReporteNombre = "Eniac.Win.Comprobante_Dolares.rdlc"
               End If

            End If

      End Select

      ReporteEmbebido = True

      Dim tipoLetra As Entidades.TipoComprobanteLetra = New Reglas.TiposComprobantesLetras().GetUno(oVenta.TipoComprobante.IdTipoComprobante, oVenta.LetraComprobante)
      Dim IdTipoImpresionFiscal = Reglas.Publicos.TipoImpresionFiscal(eSucursal)

      '# Exportación PDF
      '# Si no es Exportacion, se mantiene el comportamiento estándar.
      If utilizaArchivoAExportar And Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAExportar) And Not utilizarComprobanteEstandar Then
         ReporteNombre = tipoLetra.ArchivoAExportar
         ReporteEmbebido = tipoLetra.ArchivoAExportarEmbebido
         IdTipoImpresionFiscal = tipoLetra.IdTipoImpresionFiscalArchivoAExportar

         '# Parámetros con los que va a contar la impresión
         ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAExportar, tipoLetra.DesplazamientoYArchivoAExportar)

         If Not ReporteEmbebido Then
            ReporteNombre = "Reportes\" & tipoLetra.ArchivoAExportar
         End If
      Else
         If tipoLetra.ArchivoAImprimir <> String.Empty And Not tipoLetra.ArchivoAImprimir.Contains(";") And Not utilizarComprobanteEstandar Then
            ReporteNombre = tipoLetra.ArchivoAImprimir
            ReporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
            IdTipoImpresionFiscal = tipoLetra.IdTipoImpresionFiscalArchivoAImprimir

            '# Parámetros con los que va a contar la impresión
            ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)

            If Not ReporteEmbebido Then
               ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
            End If
         End If

         If (oVenta.IdMoneda = 2 Or oVenta.Cliente.UsaArchivoAImprimir2) AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir2) And Not utilizarComprobanteEstandar Then
            ReporteNombre = tipoLetra.ArchivoAImprimir2
            ReporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido2
            IdTipoImpresionFiscal = tipoLetra.IdTipoImpresionFiscalArchivoAImprimir2

            '# Parámetros con los que va a contar la impresión
            ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir2, tipoLetra.DesplazamientoYArchivoAImprimir2)

            If Not ReporteEmbebido Then
               ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir2
            End If
         End If

         If Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimirComplementario) And Not utilizarComprobanteEstandar Then
            ReporteNombreComplementario = tipoLetra.ArchivoAImprimirComplementario
            ReporteEmbebidoComplementario = tipoLetra.ArchivoAImprimirComplementarioEmbebido
            IdTipoImpresionFiscal = tipoLetra.IdTipoImpresionFiscalArchivoAImprimirComplementario

            '# Parámetros con los que va a contar la impresión
            ConfigImprimirComplementario = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimirComplementario, tipoLetra.DesplazamientoYArchivoAImprimirComplementario)

            If Not ReporteEmbebidoComplementario Then
               ReporteNombreComplementario = "Reportes\" & tipoLetra.ArchivoAImprimirComplementario
            End If
         End If
      End If

      '# Se asigna de forma particular el Tipo de Impresión Fiscal del comprobante
      Me.Parametros.Add(New ReportParameter("TipoImpresionFiscal", IdTipoImpresionFiscal))

   End Sub

   Public Sub ArmarReporteDePedidoProveedor(oPedido As Entidades.PedidoProveedor,
                                  categoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                                  utilizarComprobanteEstandar As Boolean,
                                  utilizaArchivoAExportar As Boolean)



      ' Dim categoriaFiscalEmpresa As Entidades.CategoriaFiscal
      categoriaFiscalEmpresa = New Reglas.CategoriasFiscales().GetUno(Reglas.Publicos.CategoriaFiscalEmpresa)

      ' Dim reporteDataSource As String '= "dtsPedido_dtPedido"
      Me.ReporteDataSource = "SistemaDataSet_VentasProductos"  ' Cambio para poder usar las impresiones de comprobantes al querer imprimir un pedido.
      Dim titulo As String = oPedido.TipoComprobante.Descripcion

      Dim sucursal As Entidades.Sucursal = New Reglas.Sucursales().GetUna(oPedido.IdSucursal, False)

      'Dim dtReporte As DataTable
      Me.PedidosProductos = New DataTable
      Me.PedidosProductos = New Reglas.PedidosProductosProveedores().GetPedidosProductosProveedores(oPedido.IdSucursal, oPedido.IdTipoComprobante, oPedido.LetraComprobante,
                                                                                          oPedido.CentroEmisor, oPedido.NumeroPedido)

      Me.PedidosProductos.Columns.Add("DescuentoProducto", GetType(Decimal))
      Me.PedidosProductos.Columns.Add("DescuentoProductoPorc1", GetType(Decimal))
      Me.PedidosProductos.Columns.Add("DescuentoProductoPorc2", GetType(Decimal))

      'El reporte de Pedidos no lo usa, pero se pueden usar los reportes de VENTA por lo que es necesario.
      '  Dim dtVO As SistemaDataSet.VentasObservacionesDataTable = New SistemaDataSet.VentasObservacionesDataTable()
      Dim drVO As SistemaDataSet.VentasObservacionesRow

      For Each vo As Entidades.PedidoObservacionProveedor In oPedido.PedidosObservaciones

         drVO = Me.VentasObservacionesDT.NewVentasObservacionesRow()

         drVO.IdSucursal = vo.IdSucursal
         drVO.IdTipoComprobante = vo.IdTipoComprobante
         drVO.Letra = vo.Letra
         drVO.CentroEmisor = vo.CentroEmisor
         drVO.NumeroComprobante = vo.NumeroPedido
         drVO.Linea = vo.Linea
         drVO.Observacion = vo.Observacion

         Me.VentasObservacionesDT.AddVentasObservacionesRow(drVO)
      Next

      Me.Parametros = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      Me.Parametros.Add(New ReportParameter("TipoImpresionFiscal", Reglas.Publicos.TipoImpresionFiscal))
      Me.Parametros.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", Eniac.Win.Publicos.DireccionEmpresa))
      Me.Parametros.Add(New ReportParameter("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                                                         actual.Sucursal.Direccion,
                                                                                         actual.Sucursal.Localidad.NombreLocalidad,
                                                                                         actual.Sucursal.Localidad.IdLocalidad,
                                                                                         actual.Sucursal.Localidad.IdProvincia)))

      Me.Parametros.Add(New ReportParameter("TelefonoEmpresa", sucursal.Telefono))
      Me.Parametros.Add(New ReportParameter("CuitEmpresa", Reglas.Publicos.CuitEmpresa))
      Me.Parametros.Add(New ReportParameter("IBEmpresa", Reglas.Publicos.IngresosBrutos))

      Me.Parametros.Add(New ReportParameter("fechaPedido", oPedido.Fecha.ToShortDateString()))
      Me.Parametros.Add(New ReportParameter("doc", oPedido.Proveedor.CodigoProveedor.ToString()))
      Me.Parametros.Add(New ReportParameter("nombre", oPedido.Proveedor.NombreProveedor))

      Me.Parametros.Add(New ReportParameter("IdTipoComprobante", oPedido.TipoComprobante.DescripcionImpresion.ToString()))
      Me.Parametros.Add(New ReportParameter("Letra", oPedido.LetraComprobante.ToString))
      Me.Parametros.Add(New ReportParameter("CentroEmisor", oPedido.CentroEmisor.ToString))
      Me.Parametros.Add(New ReportParameter("NumeroPedido", oPedido.NumeroPedido.ToString))
      Me.Parametros.Add(New ReportParameter("ObservacionPedido", oPedido.Observacion.ToString()))
      Me.Parametros.Add(New ReportParameter("NumeroOrdenCompra", oPedido.NumeroOrdenCompra.ToString()))

      Dim proveedor As Entidades.Proveedor = New Reglas.Proveedores().GetUnoPorCodigo(oPedido.Proveedor.CodigoProveedor)
      Me.Parametros.Add(New ReportParameter("Direccion", proveedor.DireccionProveedor))
      Me.Parametros.Add(New ReportParameter("Localidad", proveedor.NombreLocalidad))

      Dim localidad As Entidades.Localidad = New Reglas.Localidades().GetUna(proveedor.IdLocalidadProveedor)
      Me.Parametros.Add(New ReportParameter("Provincia", localidad.NombreProvincia))
      Me.Parametros.Add(New ReportParameter("CategoriaIVA", proveedor.CategoriaFiscal.NombreCategoriaFiscal))
      Me.Parametros.Add(New ReportParameter("Cuit", "0" + proveedor.CuitProveedor.ToString()))

      If oPedido.IdFormaPago.HasValue AndAlso oPedido.FormaPago IsNot Nothing Then
         Me.Parametros.Add(New ReportParameter("FormaPago", oPedido.FormaPago.DescripcionFormasPago.ToString()))
         Me.Parametros.Add(New ReportParameter("IdFormasPago", oPedido.FormaPago.IdFormasPago.ToString()))
      Else
         Me.Parametros.Add(New ReportParameter("FormaPago", String.Empty))
         Me.Parametros.Add(New ReportParameter("IdFormasPago", 0))
      End If
      If oPedido.Comprador IsNot Nothing Then
         Me.Parametros.Add(New ReportParameter("Vendedor", oPedido.Comprador.NombreEmpleado))
      Else
         Me.Parametros.Add(New ReportParameter("Vendedor", String.Empty))
      End If

      Dim DiscriminaIVA As Boolean = oPedido.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado
      Me.Parametros.Add(New ReportParameter("DiscriminaIVA", DiscriminaIVA))

      'Lo dejo para cuando se implemente ProveedoresContactos
      'If oPedido.PedidosContactos.Count > 0 Then
      '   Dim contacto As Entidades.PedidoClienteContacto = oPedido.PedidosContactos(0)
      '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Contacto", contacto.Contacto.NombreContacto))
      '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoContacto", contacto.Contacto.CorreoElectronico))
      '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoContacto", contacto.Contacto.Telefono))
      'Else
      Me.Parametros.Add(New ReportParameter("Contacto", String.Empty))
      Me.Parametros.Add(New ReportParameter("CorreoContacto", String.Empty))
      Me.Parametros.Add(New ReportParameter("TelefonoContacto", String.Empty))
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

      Me.Parametros.Add(New ReportParameter("Observacion", oPedido.Observacion.ToString()))
      Me.Parametros.Add(New ReportParameter("TipoComprobante", oPedido.TipoComprobante.DescripcionAbrev))
      Me.Parametros.Add(New ReportParameter("DescripcionImpresion", oPedido.TipoComprobante.DescripcionImpresion))
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FormaPago", oPedido.FormaPago.DescripcionFormasPago))
      Me.Parametros.Add(New ReportParameter("FormaPagoDias", oPedido.FormaPago.Dias.ToString()))
      Me.Parametros.Add(New ReportParameter("IdCategoriaFiscal", oPedido.CategoriaFiscal.IdCategoriaFiscal.ToString()))
      Me.Parametros.Add(New ReportParameter("NombreFantasia", Reglas.Publicos.NombreFantasia))
      Me.Parametros.Add(New ReportParameter("CodigoProveedorLetras", proveedor.CodigoProveedorLetras.ToString()))
      Me.Parametros.Add(New ReportParameter("TipoYNroDocumento", proveedor.CodigoProveedor.ToString()))
      Me.Parametros.Add(New ReportParameter("NombreYApellido", proveedor.NombreProveedor))
      Me.Parametros.Add(New ReportParameter("Telefono", proveedor.TelefonoProveedor & " " & proveedor.FaxProveedor))
      Me.Parametros.Add(New ReportParameter("Fecha", oPedido.Fecha.ToString()))
      Me.Parametros.Add(New ReportParameter("Numero", oPedido.NumeroPedido.ToString()))
      Me.Parametros.Add(New ReportParameter("FechaHasta", oPedido.Fecha.AddDays(Reglas.Publicos.DiasValidezPresupuesto).ToString()))

      If Not oPedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
         oPedido.ImporteBruto = oPedido.ImporteBruto + oPedido.TotalImpuestos + oPedido.TotalImpuestoInterno ''- oPedido.TotalImpuestosVarios 
         oPedido.SubTotal = oPedido.SubTotal + oPedido.TotalImpuestos + oPedido.TotalImpuestoInterno ''- oPedido.TotalImpuestosVarios 
      End If

      ' If _puedeVerPrecios Then
      Me.Parametros.Add(New ReportParameter("Bruto", oPedido.ImporteBruto.ToString()))
      Me.Parametros.Add(New ReportParameter("Subtotal", oPedido.SubTotal.ToString()))

      Me.Parametros.Add(New ReportParameter("DescuentoRecargo", oPedido.DescuentoRecargo.ToString()))
      Me.Parametros.Add(New ReportParameter("TotalIVA", TotalImpuestos.ToString()))
      Me.Parametros.Add(New ReportParameter("TotalImpuestosVarios", "0"))
      Me.Parametros.Add(New ReportParameter("TotalImpuestosInternos", TotalImpuestoInterno.ToString()))
      Me.Parametros.Add(New ReportParameter("Total", oPedido.ImporteTotal.ToString()))
      'Else
      '   parm.Add(New ReportParameter("Bruto", "0"))
      '   parm.Add(New ReportParameter("Subtotal", "0"))

      '   parm.Add(New ReportParameter("DescuentoRecargo", "0"))
      '   parm.Add(New ReportParameter("TotalIVA", "0"))
      '   parm.Add(New ReportParameter("TotalImpuestosVarios", "0"))
      '   parm.Add(New ReportParameter("TotalImpuestosInternos", "0"))
      '   parm.Add(New ReportParameter("Total", "0"))
      'End If

      Me.Parametros.Add(New ReportParameter("DescuentoRecargoPorc", oPedido.DescuentoRecargoPorc.ToString()))

      Me.Parametros.Add(New ReportParameter("Total_EnLetras", Numeros_A_Letras.EnLetras(oPedido.ImporteTotal.ToString())))

      Me.Parametros.Add(New ReportParameter("Kilos", 0D))
      Me.Parametros.Add(New ReportParameter("DecimalesEnCantidad", IIf(Reglas.Publicos.ProductoUtilizaCantidadesEnteras, "0", "2").ToString()))
      Me.Parametros.Add(New ReportParameter("DecimalesEnPrecio", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio.ToString()))
      Me.Parametros.Add(New ReportParameter("DecimalesEnTotalXProducto", Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnTotalXProducto.ToString()))
      Me.Parametros.Add(New ReportParameter("DescripcionAdicionalEmpresa", Reglas.Publicos.DescripcionAdicionalEmpresa.ToString()))
      Me.Parametros.Add(New ReportParameter("eMail", actual.Sucursal.Correo.ToString()))
      Me.Parametros.Add(New ReportParameter("web", Reglas.Publicos.DireccionWebEmpresa))
      Me.Parametros.Add(New ReportParameter("ZonaGeografica", "")) 'oPedido.Proveedor.ZonaGeografica.IdZonaGeografica))

      Me.Parametros.Add(New ReportParameter("TotalKilos", 0D))
      Me.Parametros.Add(New ReportParameter("TotalProductos", oPedido.CantidadProductos))
      Me.Parametros.Add(New ReportParameter("MuestraTotalKilos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalKilos))
      Me.Parametros.Add(New ReportParameter("MuestraTotalProductos", Reglas.Publicos.Facturacion.Impresion.ImpresionMuestraTotalProductos))

      Me.Parametros.Add(New ReportParameter("SaldoActual", "0"))
      Me.Parametros.Add(New ReportParameter("CotizacionDolar", oPedido.CotizacionDolar.ToString()))

      Me.Parametros.Add(New ReportParameter("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre))
      Me.Parametros.Add(New ReportParameter("FechaInicioActividades", Reglas.Publicos.FechaInicioActividades))

      Me.Parametros.Add(New ReportParameter("IngresosBrutos", Reglas.Publicos.IngresosBrutos))
      Me.Parametros.Add(New ReportParameter("EmpresaCUIT", Reglas.Publicos.CuitEmpresa))
      Me.Parametros.Add(New ReportParameter("eMail", actual.Sucursal.Correo))
      Me.Parametros.Add(New ReportParameter("Web", Reglas.Publicos.DireccionWebEmpresa))
      Me.Parametros.Add(New ReportParameter("IdMoneda", oPedido.IdMoneda))

      Dim nombreLogo As String = Publicos.NombreLogo

      Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
      Dim LogoImagen As Image = actual.Logo

      Me.Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
      Me.Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType()))


      Dim totalIva0 As Decimal = 0
      Dim totalIva105 As Decimal = 0
      Dim totalIva210 As Decimal = 0
      Dim totalIva270 As Decimal = 0
      Me.PedidosProductos.Columns.Add("Precio", GetType(Decimal))
      For Each dr As DataRow In Me.PedidosProductos.Rows

         ' # Validar que código se debe mostrar a la hora de imprimir.
         If Reglas.Publicos.ImpresionMuestraCodigoProveedorTrue Then
            If Not String.IsNullOrEmpty(dr(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()).ToString()) Then
               dr(Entidades.ProductoProveedor.Columnas.IdProducto.ToString()) = dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString())
            End If
         End If

         'If Not _puedeVerPrecios Then
         '   'dr("Precio") = 0
         '   dr("Costo") = 0
         '   dr("CostoNeto") = 0
         '   dr("ImporteTotal") = 0
         '   dr("DescuentoRecargoProducto") = 0
         '   dr("ImporteImpuesto") = 0
         '   dr("ImporteImpuestoInterno") = 0
         '   'dr("PrecioNeto") = 0
         '   dr("ImporteTotalNeto") = 0
         '   dr("DescRecGeneral") = 0
         '   dr("DescRecGeneralProducto") = 0
         '   'dr("PrecioConImpuestos") = 0
         '   'dr("PrecioNetoConImpuestos") = 0
         '   dr("ImporteTotalConImpuestos") = 0
         '   dr("ImporteTotalNetoConImpuestos") = 0
         '   'dr("PrecioVentaPorTamano") = 0
         'End If

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
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA0", 0))
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA105", 0))
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA210", 0))
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA270", 0))
      Else
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA0", totalIva0))
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA105", totalIva105))
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA210", totalIva210))
         Me.Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("IVA270", totalIva270))
      End If

      Dim tipoLetra As Entidades.TipoComprobanteLetra
      tipoLetra = New Reglas.TiposComprobantesLetras().GetUno(oPedido.TipoComprobante.IdTipoComprobante, oPedido.LetraComprobante)

      Me.ReporteNombre = "Eniac.Win.PedidoProvV2.rdlc"
      '_puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "PedidosProv", "ImpresionPedidosProv-VerPre")
      ' _puedeVerPrecios = True

      'GAR: 12/12/2017 - Por ahora no tiene utilidad.
      'If oPedido.TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRESUPCLIE.ToString() Then
      '   reporteNombre = "Eniac.Win.Presupuesto.rdlc"
      '   _puedeVerPrecios = New Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "Presupuestos", "ImpresionPresupuestos-VerPre")
      'End If
      '--------------------------------------
      Dim reporteEmbebido As Boolean = True

      If tipoLetra IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir) Then
         Me.ReporteNombre = tipoLetra.ArchivoAImprimir
         reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
         ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)
         CantidadCopias = tipoLetra.CantidadCopias
         If Not reporteEmbebido Then
            Me.ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
         End If
      End If

      'Dim Envios As DataTable = New DataTable()


      'Envios = New Reglas.EnviosOC().GetEnviosXOC(oPedido.IdSucursal, oPedido.IdTipoComprobante,
      '                                                             oPedido.LetraComprobante, oPedido.CentroEmisor,
      '                                                             oPedido.NumeroPedido)

      'If Envios.Rows.Count > 0 AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir2) Then
      '   ReporteNombre = tipoLetra.ArchivoAImprimir2
      '   reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido2
      '   If Not reporteEmbebido Then
      '      ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir2
      '   End If
      'End If

      'If oPedido.FechaReprogramacion <> Nothing Then

      '   If Envios.Rows.Count <> 0 Then

      '      If Not String.IsNullOrEmpty(Envios.Rows(0).Item("FechaReprogramacion").ToString()) Then

      '         ' TIENE ENVIOS Y EL ULTIMO ENVIO FUE REPROGRAMACION

      '         If DateTime.Parse(Envios.Rows(0).Item("FechaReprogramacion").ToString()) <> oPedido.FechaReprogramacion Then
      '            ' TIENE ENVIOS Y EL ULTIMO ENVIO FUE REPROGRAMACION Y LA ULTIMA FECHA DE REPROGRAMACION ES DISTINTA

      '            ReporteNombre = tipoLetra.ArchivoAImprimirComplementario
      '            reporteEmbebido = tipoLetra.ArchivoAImprimirComplementarioEmbebido
      '            If Not reporteEmbebido Then
      '               ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimirComplementario
      '            End If

      '         Else
      '            ' TIENE ENVIOS Y EL ULTIMO ENVIO FUE REPROGRAMACION Y LA ULTIMA FECHA DE REPROGRAMACION ES IGUAL
      '            ReporteNombre = tipoLetra.ArchivoAExportar
      '            reporteEmbebido = tipoLetra.ArchivoAExportarEmbebido
      '            If Not reporteEmbebido Then
      '               ReporteNombre = "Reportes\" & tipoLetra.ArchivoAExportar
      '            End If
      '         End If

      '      Else
      '         ' TIENE ENVIOS Y EL ULTIMO ENVIO NO FUE REPROGRAMACION
      '         ReporteNombre = tipoLetra.ArchivoAImprimirComplementario
      '         reporteEmbebido = tipoLetra.ArchivoAImprimirComplementarioEmbebido
      '         If Not reporteEmbebido Then
      '            ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimirComplementario
      '         End If

      '      End If

      '   End If

      'End If

   End Sub


   '# Desplazamiento que va a tener la impresión al momento de imprimir
   Private _ConfigImprimir As ConfiguracionImprimir
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

   Public Property ReporteNombreComplementario As String
   Public Property ReporteEmbebidoComplementario As Boolean

   Private _reporteNombre As String = String.Empty
   Public Property ReporteNombre() As String
      Get
         Return _reporteNombre
      End Get
      Set(ByVal value As String)
         _reporteNombre = value
      End Set
   End Property

   Public Property ReporteEmbebido As Boolean

   Private _titulo As String = String.Empty
   Public Property Titulo() As String
      Get
         Return _titulo
      End Get
      Set(ByVal value As String)
         _titulo = value
      End Set
   End Property

   Private _parametros As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
   Public Property Parametros() As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
      Get
         Return _parametros
      End Get
      Set(ByVal value As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter))
         _parametros = value
      End Set
   End Property

   Private _VentasProductosDT As SistemaDataSet.VentasProductosDataTable
   Public Property VentasProductosDT() As SistemaDataSet.VentasProductosDataTable
      Get
         Return _VentasProductosDT
      End Get
      Set(ByVal value As SistemaDataSet.VentasProductosDataTable)
         _VentasProductosDT = value
      End Set
   End Property

   Private _ventasObservacionesDT As SistemaDataSet.VentasObservacionesDataTable
   Public Property VentasObservacionesDT() As SistemaDataSet.VentasObservacionesDataTable
      Get
         Return _ventasObservacionesDT
      End Get
      Set(ByVal value As SistemaDataSet.VentasObservacionesDataTable)
         _ventasObservacionesDT = value
      End Set
   End Property

   Private _ventasImpuestosDT As SistemaDataSet.VentasImpuestosDataTable
   Public Property VentasImpuestosDT() As SistemaDataSet.VentasImpuestosDataTable
      Get
         Return _ventasImpuestosDT
      End Get
      Set(ByVal value As SistemaDataSet.VentasImpuestosDataTable)
         _ventasImpuestosDT = value
      End Set
   End Property

   Private _cuotasDT As TurismoDataSet.CuotasDataTable
   Public Property CuotasDT() As TurismoDataSet.CuotasDataTable
      Get
         Return _cuotasDT
      End Get
      Set(ByVal value As TurismoDataSet.CuotasDataTable)
         _cuotasDT = value
      End Set
   End Property

   Private _reporteDataSource As String
   Public Property ReporteDataSource() As String
      Get
         Return _reporteDataSource
      End Get
      Set(ByVal value As String)
         _reporteDataSource = value
      End Set
   End Property

   Private _reporteDataSource2 As String
   Public Property ReporteDataSource2() As String
      Get
         Return _reporteDataSource2
      End Get
      Set(ByVal value As String)
         _reporteDataSource2 = value
      End Set
   End Property

   Private _reporteDataSource3 As String
   Public Property ReporteDataSource3() As String
      Get
         Return _reporteDataSource3
      End Get
      Set(ByVal value As String)
         _reporteDataSource3 = value
      End Set
   End Property

   Private _reporteDataSource4 As String
   Public Property ReporteDataSource4() As String
      Get
         Return _reporteDataSource4
      End Get
      Set(ByVal value As String)
         _reporteDataSource4 = value
      End Set
   End Property

   Public Property CantidadCopias() As Integer

   Public Property PedidosProductos As DataTable

End Class

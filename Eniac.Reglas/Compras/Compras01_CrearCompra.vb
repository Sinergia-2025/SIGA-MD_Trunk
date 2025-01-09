Partial Class Compras

   Public Function CreaCompra(idSucursal As Integer,
                              tipoComprobante As Entidades.TipoComprobante,
                              letra As String,
                              centroEmisor As Short,
                              numeroComprobante As Integer?,
                              fecha As Date?,
                              _proveedorE As Entidades.Proveedor,
                              comprador As Entidades.Empleado,
                              descuentoRecargoPorc As Decimal,
                              cotizacionDolar As Decimal?,
                              formasPago As Entidades.VentaFormaPago,
                              idCaja As Integer,
                              observacion As String,
                              _cache As BusquedasCacheadas) As Entidades.Compra
      Dim sucursal = _cache.BuscaSucursal(idSucursal)

      Dim compra = New Entidades.Compra()

      If comprador Is Nothing Then
         Throw New ArgumentNullException("Comprador es requrido")
      End If

      compra.Usuario = actual.Nombre

      compra.Proveedor = _proveedorE
      compra.Comprador = comprador

      compra.Fecha = fecha.IfNull(Date.Now)
      compra.IdSucursal = idSucursal
      compra.TipoComprobante = tipoComprobante
      If String.IsNullOrWhiteSpace(letra) Then
         letra = tipoComprobante.GetLetraHabilitada(_proveedorE.CategoriaFiscal)
      End If
      compra.Letra = letra
      If String.IsNullOrWhiteSpace(letra) Then
         Throw New Exception("La letra no puede ser (blanco)")
      End If

      If centroEmisor = 0 Then
         Dim impresora = New Impresoras(da)._GetPorSucursalPCTipoComprobante(sucursal.IdSucursal, My.Computer.Name, tipoComprobante.IdTipoComprobante)
         centroEmisor = impresora.CentroEmisor
      End If
      compra.CentroEmisor = centroEmisor

      If Not numeroComprobante.HasValue Then
         compra.NumeroComprobante = New VentasNumeros(da).GetProximoNumero(sucursal, compra.TipoComprobante.IdTipoComprobante,
                                                                           compra.Letra, compra.CentroEmisor)
      End If

      'EsComercial=True excluye los Tipo de SALDOINICIAL.
      If compra.TipoComprobante.EsComercial Or compra.TipoComprobante.GeneraContabilidad Then
         compra.IdEmpresa = sucursal.IdEmpresa
         compra.PeriodoFiscal = Integer.Parse(compra.Fecha.ToString("yyyyMM"))
      End If

      'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
      Dim coe As Integer = compra.TipoComprobante.CoeficienteValores

      If idCaja = 0 Then
         Dim dtCajas = New CajasUsuarios(da).GetCajasTodas({actual.Sucursal}, actual.Nombre, nombrePC:=String.Empty, cajasModificables:=True)
         Dim caja = dtCajas.FirstOrDefault()
         If caja Is Nothing Then Throw New Exception("No tiene ninguna caja con permiso de escritura. No podrá continuar.")
         idCaja = caja.IdCaja
      End If
      compra.IdCaja = idCaja

      '------------------------------------------
      'If Not oCF.IvaDiscriminado Then
      '   .Compra.Bruto210 = Decimal.Round((.Compra.Bruto210 / (1 + (.PorcentajeIVA / 100))), 2)
      'End If

      ''''.Compra.DescuentoRecargo = .DescuentoRecargo * coe
      compra.DescuentoRecargoPorc = descuentoRecargoPorc
      compra.DescuentoRecargo = descuentoRecargoPorc

      compra.IVAModificadoManual = False

      ''''.Compra.PorcentajeIVA = .PorcentajeIVA * coe
      ''''.Compra.ImporteTotal = .Total * coe
      '-------------------------------------------

      compra.FechaActualizacion = Date.Now

      compra.FormaPago = formasPago
      compra.Rubro = _proveedorE.RubroCompra
      compra.Observacion = observacion

      'cargo cotizacion dolar
      If Not cotizacionDolar.HasValue Then
         cotizacionDolar = _cache.BuscaMoneda(Entidades.Moneda.Dolar).FactorConversion
      End If
      compra.CotizacionDolar = cotizacionDolar.Value

      If compra.IdcategoriaFiscal = 0 Then
         compra.IdcategoriaFiscal = compra.Proveedor.CategoriaFiscal.IdCategoriaFiscal
      End If
      If String.IsNullOrWhiteSpace(compra.NombreProveedor) Then
         compra.NombreProveedor = compra.Proveedor.NombreProveedor
      End If
      If String.IsNullOrWhiteSpace(compra.CuitProveedor) Then
         compra.CuitProveedor = compra.Proveedor.CuitProveedor
      End If

      'TODO: Analizar
      compra.PorcentajeIVA = 21    'Decimal.Parse(Me.lblPorcentaje.Text)
      ''''.Compra.IdSucursal = .Sucursal.Id
      ''''.Compra.Rubro = New Reglas.RubrosCompras(da).GetUno(Rubro)

      '.Compra.PercepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text) * coe
      '.Compra.PercepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text) * coe
      '.Compra.PercepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text) * coe
      '.Compra.PercepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text) * coe
      '.Compra.ImpuestosInternos = Decimal.Parse(Me.txtImpuestosInternos.Text) * coe


      'If .Compra.TipoComprobante.AfectaCaja Then
      '   'controlo el pago que se realiza si no va a la cuenta corriente
      '   If .Compra.FormaPago.Dias = 0 Then
      '      If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
      '         If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
      '            If Not Reglas.Publicos.ComprasContadoEsEnPesos AndAlso MessageBox.Show("El pago se realizara totalmente en pesos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
      '               Me.tbpPagosEfectivo.Focus()
      '               Me.txtEfectivo.Focus()
      '               Exit Sub
      '            Else
      '               Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
      '            End If
      '         End If
      '      Else
      '         'si puso algo en pagos, se debe controlar que la diferencia este en cero
      '         If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
      '            Me.tbpPagosEfectivo.Focus()
      '            Me.txtEfectivo.Focus()
      '            Throw New Exception("El pago debe ser igual al total del comprobante.")
      '         End If
      '      End If
      '   End If
      'Else
      '   Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
      'End If

      '.Compra.ChequesPropios = Me._chequesPropios
      ' .Compra.ChequesTerceros = Me._chequesTerceros

      compra.ImportePesos = 0
      ' .Compra.ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text) * coe
      '.Compra.ImporteCheques = (Decimal.Parse(Me.txtChequesPropios.Text) + Decimal.Parse(Me.txtChequesTerceros.Text)) * coe
      'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
      '   .Compra.ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text)
      '   .Compra.CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
      'End If

      '''''cargo las Observaciones
      ''''.Compra.ComprasObservaciones = observacionDetalladas


      '''''.PercepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
      '''''.PercepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
      '''''.PercepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
      '''''.PercepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)
      '''''.ImpuestosInternos = Decimal.Parse(Me.txtImpuestosInternos.Text)
      '''''.Compra.ComprasImpuestos.Clear()

      ''''' .Compra.ConceptoCM05 = If(chbAFIPConceptoCM05.Checked, cmbAFIPConceptoCM05.ItemSeleccionado(Of Entidades.AFIPConceptoCM05)(), Nothing)

      ''''.Compra.ComprasImpuestos = _subTotales

      '''''For Each ci As Entidades.CompraImpuesto In _comprasImpuestos
      '''''   .Compra.ComprasImpuestos.Add(ci)
      '''''Next

      '''''For Each drProvincias As DataRow In _dtProvincias.Rows
      '''''   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
      '''''   With ci
      '''''      .IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB.ToString()
      '''''      .TipoTipoImpuesto = "PERCEPCION"
      '''''      .IdProvincia = drProvincias("IdProvincia").ToString()
      '''''      .NombreProvincia = drProvincias("NombreProvincia").ToString()
      '''''      '.Emisor = Integer.Parse(drProvincias("Emisor").ToString())
      '''''      '.Numero = Long.Parse(drProvincias("Numero").ToString())
      '''''      .BaseImponible = Decimal.Parse(drProvincias("BaseImponible").ToString())
      '''''      .Alicuota = Decimal.Parse(drProvincias("Alicuota").ToString())
      '''''      .Importe = Decimal.Parse(drProvincias("Importe").ToString())
      '''''   End With
      '''''   .Compra.ComprasImpuestos.Add(ci)
      '''''Next

      '''''If .PercepcionGanancias <> 0 Then
      '''''   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
      '''''   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PGANA.ToString()
      '''''   ci.TipoTipoImpuesto = "PERCEPCION"
      '''''   ci.Importe = .PercepcionGanancias
      '''''   .Compra.ComprasImpuestos.Add(ci)
      '''''End If
      '''''If .PercepcionIVA <> 0 Then
      '''''   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
      '''''   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA.ToString()
      '''''   ci.TipoTipoImpuesto = "PERCEPCION"
      '''''   ci.Importe = .PercepcionIVA
      '''''   .Compra.ComprasImpuestos.Add(ci)
      '''''End If
      '''''If .PercepcionVarias <> 0 Then
      '''''   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
      '''''   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PVAR.ToString()
      '''''   ci.TipoTipoImpuesto = "PERCEPCION"
      '''''   ci.Importe = .PercepcionVarias
      '''''   .Compra.ComprasImpuestos.Add(ci)
      '''''End If

      '''''If .ImpuestosInternos <> 0 Then
      '''''   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
      '''''   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT.ToString()
      '''''   ci.TipoTipoImpuesto = "PERCEPCION"
      '''''   ci.Importe = .ImpuestosInternos
      '''''   .Compra.ComprasImpuestos.Add(ci)
      '''''End If

      '''''If .Compra.TipoComprobante.EsDespachoImportacion Then
      '''''   For Each cid As Entidades.CompraImpuesto In _comprasImpuestosDespachoImportacion
      '''''      Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
      '''''      ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
      '''''      ci.TipoTipoImpuesto = "PERCEPCION"
      '''''      ci.BaseImponible = cid.BaseImponible
      '''''      ci.Alicuota = cid.Alicuota
      '''''      ci.Importe = cid.Importe
      '''''      ci.EsDespacho = True
      '''''      .Compra.ComprasImpuestos.Add(ci)
      '''''   Next

      '''''   .Compra.FechaOficializacionDespacho = dtpFechaOficializacion.Value
      '''''   .Compra.IdAduana = Integer.Parse(bscCodigoAduana.Text.ToString())
      '''''   .Compra.IdDestinacion = bscCodigoDestinacion.Text.ToString()

      '''''   .Compra.NumeroDespacho = Long.Parse(txtNumeroDespacho.Text)
      '''''   .Compra.DigitoVerificadorDespacho = txtDigitoVerificador.Text
      '''''   .Compra.NumeroManifiestoDespacho = txtNumeroManifiesto.Text

      '''''   .Compra.IdDespachante = Integer.Parse(bscCodigoDespachante.Text.ToString())
      '''''   .Compra.IdAgenteTransporte = Integer.Parse(bscCodigoAgenteTransporte.Text.ToString())

      '''''   .Compra.DerechoAduanero = Decimal.Parse(txtDerechoAduana.Text)
      '''''   .Compra.BienCapitalDespacho = chbBienCapital.Checked
      '''''End If

      '''''.Comentarios = Me.bscObservacion.Text.Trim()
      ''''.Observacion = observacion

      '''''If Not .Compra.TipoComprobante.EsRemitoTransportista Then
      ''''.Productos = _productos

      ''''For Each p In _productos
      ''''   If Not String.IsNullOrWhiteSpace(p.IdLote) Then
      ''''      .ProductosLotes.Add(New Entidades.ProductoLote() With {
      ''''                           .IdSucursal = p.IdSucursal,
      ''''                           .IdDeposito = p.IdDeposito,
      ''''                           .IdUbicacion = p.IdUbicacion,
      ''''                           .ProductoSucursal = New Entidades.ProductoSucursal() With {.Producto = New Entidades.Producto() With {.IdProducto = p.IdProducto}},
      ''''                           .IdLote = p.IdLote,
      ''''                           .FechaIngreso = Date.Now,
      ''''                           .FechaVencimiento = p.VtoLote,
      ''''                           .CantidadActual = p.Cantidad,
      ''''                           .CantidadActualOriginal = p.Cantidad,
      ''''                           .Habilitado = True
      ''''                       })
      ''''   End If
      ''''   For Each ns In p.ProductosNrosSerie
      ''''      .ProductosNrosSerie.Add(New Entidades.ProductoNroSerie() With {
      ''''                              .IdSucursal = p.IdSucursal,
      ''''                              .Sucursal = New Entidades.Sucursal() With {.IdSucursal = p.IdSucursal},
      ''''                              .IdDeposito = p.IdDeposito,
      ''''                              .IdUbicacion = p.IdUbicacion,
      ''''                              .Producto = New Entidades.Producto() With {.IdProducto = p.IdProducto},
      ''''                              .Vendido = oMov.TipoMovimiento.CoeficienteStock < 0,
      ''''                              .NroSerie = ns.NroSerie,
      ''''                              .TipoComprobante = oMov.Compra.TipoComprobante,
      ''''                              .Letra = oMov.Compra.Letra,
      ''''                              .CentroEmisor = oMov.Compra.CentroEmisor,
      ''''                              .NumeroComprobante = oMov.Compra.NumeroComprobante,
      ''''                              .Proveedor = oMov.Compra.Proveedor
      ''''                           })
      ''''   Next

      Return compra
   End Function

   Public Function CreaCompraProducto(compra As Entidades.Compra,
                                      producto As Entidades.Producto,
                                      nombreProducto As String,
                                      descuentoRecargoPorc As Decimal,
                                      cantidad As Decimal,
                                      kilosProducto As Decimal,
                                      precioPorKilo As Decimal,
                                      idDeposito As Integer?,
                                      idUbicacion As Integer?,
                                      precio As PrecioEnmascarado?,
                                      alicuotaIVA As Decimal?,
                                      orden As Integer,
                                      idLote As String, vtoLote As Date?, informeNumero As String, informeLink As String, nrosSerie As List(Of String),
                                      decimalesRedondeoEnPrecio As Integer,
                                      cache As BusquedasCacheadas) As Entidades.CompraProducto
      If nrosSerie Is Nothing Then
         nrosSerie = New List(Of String)()
      End If
      Dim cp = New Entidades.CompraProducto()
      Dim categoriaFiscalEmpresa = cache.BuscaCategoriaFiscal(Publicos.CategoriaFiscalEmpresa)

      Dim usaPrecioConIVA = (Not compra.Proveedor.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado) And
                             compra.Proveedor.CategoriaFiscal.UtilizaImpuestos And categoriaFiscalEmpresa.UtilizaImpuestos And
                             compra.TipoComprobante.UtilizaImpuestos
      'Me._numeroOrden += 1
      'Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      'Dim oLineaDetalle = New Entidades.MovimientoStockProducto()
      '''''With oLineaDetalle
      cp.Orden = orden
      cp.Producto = producto
      If String.IsNullOrWhiteSpace(nombreProducto) Then
         cp.Producto.NombreProducto = nombreProducto
      End If
      cp.DescuentoRecargoPorc = descuentoRecargoPorc

      ''.DescRecGeneral = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

      If Not alicuotaIVA.HasValue Then
         alicuotaIVA = producto.Alicuota
      End If

      Dim precioConIVA = 0D
      Dim precioSinIVA = 0D

      Dim ps = New ProductosSucursales(da)._GetUno(compra.IdSucursal, producto.IdProducto)
      If precio.HasValue Then
         If precio.Value.ConIva Then
            precioConIVA = precio.Value.Precio
            precioSinIVA = precio.Value.Precio / (1 + alicuotaIVA.Value)
         Else
            precioConIVA = precio.Value.Precio * (1 + alicuotaIVA.Value)
            precioSinIVA = precio.Value.Precio
         End If
      Else
         If Publicos.PreciosConIVA Then
            precioConIVA = ps.PrecioCosto
            precioSinIVA = ps.PrecioCosto / (1 + producto.Alicuota)
         Else
            precioConIVA = ps.PrecioCosto * (1 + (producto.Alicuota / 100))
            precioSinIVA = ps.PrecioCosto
         End If
         If alicuotaIVA.Value <> producto.Alicuota Then
            precioConIVA = precioSinIVA * (1 + (alicuotaIVA.Value / 100))
         End If
         If producto.Moneda.IdMoneda = Entidades.Moneda.Dolar Then
            precioConIVA = precioConIVA * compra.CotizacionDolar
            precioSinIVA = precioSinIVA * compra.CotizacionDolar
         End If

      End If

      precioConIVA = Math.Round(precioConIVA, decimalesRedondeoEnPrecio)
      precioSinIVA = Math.Round(precioSinIVA, decimalesRedondeoEnPrecio)

      cp.Precio = If(usaPrecioConIVA, precioConIVA, precioSinIVA)


      Dim descRec1 = Math.Round(cp.Precio * cp.DescuentoRecargoPorc / 100, decimalesRedondeoEnPrecio)
      cp.DescuentoRecargo = descRec1
      Dim ImporteBruto = cp.Precio + descRec1

      cp.Stock = ps.Stock

      cp.Cantidad = cantidad

      Dim kilos = cp.Cantidad * kilosProducto

      cp.CantidadUMCompra = kilos
      cp.FactorConversionCompra = kilosProducto
      cp.PrecioPorUMCompra = precioPorKilo
      cp.ImporteTotal = ImporteBruto * cantidad

      cp.DescRecGeneral = Math.Round(cp.ImporteTotal * (compra.DescuentoRecargoPorc / 100), decimalesRedondeoEnPrecio)

      cp.PorcentajeIVA = alicuotaIVA.Value
      cp.Iva = (cp.ImporteTotal + cp.DescRecGeneral) * cp.PorcentajeIVA / 100

      ''''If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
      ''''         Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or
      ''''         Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

      ''''   If Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
      ''''      .PrecioCostoNuevo = Decimal.Round(ImporteBruto / (1 + Me._IVAO / 100), Me._decimalesRedondeoEnPrecio)
      ''''   Else
      ''''      .PrecioCostoNuevo = ImporteBruto
      ''''   End If
      ''''Else
      ''''   .PrecioCostoNuevo = ImporteBruto
      ''''End If

      '''''Si no tiene IVA discriminado no deberia entrar
      ''''If Reglas.Publicos.PreciosConIVA And Me._proveedor.CategoriaFiscal.IvaDiscriminado Then
      ''''   .PrecioCostoNuevo = Decimal.Round(.PrecioCostoNuevo * (1 + Me._IVAO / 100), Me._decimalesRedondeoEnPrecio)
      ''''End If

      ''''If Prod.Moneda.IdMoneda = 2 Then
      ''''   .PrecioCostoNuevo = .PrecioCostoNuevo / Decimal.Parse(Me.txtCotizacionDolar.Text)
      ''''End If

      ''''.PrecioVentaActual = Me._precioVenta

      ''''Dim porcentaje As Decimal = 0

      ''''If .PrecioCostoO > 0 Then
      ''''   porcentaje = Decimal.Round(.PrecioVentaActual / .PrecioCostoO, Me._decimalesRedondeoEnPrecio)
      ''''End If

      ''''If .PrecioVentaActual <> 0 Then
      ''''   .PorcentRecargo = (porcentaje - 1) * 100
      ''''End If


      ''''.PrecioVentaNuevo = Decimal.Round(.PrecioCostoNuevo * porcentaje, Me._decimalesRedondeoEnPrecio)
      '''''NO hace falta preguntar aca porque ahora lo bloqueo arriba.
      '''''If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
      '''''   Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
      '''''   Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
      '''''   .PorcentajeIVA = 0
      '''''   .IVA = 0
      '''''Else

      '''''End If

      ''''.TotalProducto = .ImporteTotal + .Iva
      'REG-36547.- -----------
      cp.IdSucursal = compra.IdSucursal
      cp.IdDeposito = idDeposito.IfNull(producto.IdDeposito)
      cp.IdUbicacion = idUbicacion.IfNull(producto.IdUbicacion)
      '-----------------------
      ''''oLineaDetalle.NombreDeposito = cmbDepositoOrigen.Text
      ''''oLineaDetalle.NombreUbicacion = cmbUbicacionOrigen.Text

      ''''Dim var As Decimal = 0
      ''''var = .PrecioCostoO - .PrecioCostoNuevo
      ''''If .PrecioCostoNuevo <> 0 Then
      ''''   .PorcVar = (var / .PrecioCostoNuevo * 100) * -1
      ''''Else
      ''''   If .PrecioCostoNuevo = var Then
      ''''      .PorcVar = 0
      ''''   Else
      ''''      .PorcVar = -100
      ''''   End If
      ''''End If

      ''''If Me.txtStock.Text.Length <> 0 Then
      ''''   .Stock = Decimal.Parse(Me.txtStock.Text)
      ''''Else
      ''''   .Stock = 0
      ''''End If
      ''''.IdSucursal = actual.Sucursal.Id
      cp.Usuario = compra.Usuario
      cp.IdLote = idLote
      cp.FechaVencimientoLote = vtoLote
      cp.InformeCalidadNumero = informeNumero
      cp.InformeCalidadLink = informeLink

      cp.IdUnidadDeMedida = producto.UnidadDeMedida.IdUnidadDeMedida
      cp.IdUnidadDeMedidaCompra = producto.UnidadDeMedidaCompra.IdUnidadDeMedida

      '''''ingreso los nros. de serie
      ''''' VER PORQUE ELIMINA LOS RENGLONES QUE NO SE EDITARON
      cp.ProductoSucursal = New Entidades.ProductoSucursal() With {.Producto = producto}
      ''''cp.ProductoSucursal.Producto = producto

      '# Nro. de Serie
      cp.Producto.NrosSeries = nrosSerie.ConvertAll(Function(ns) New Entidades.ProductoNroSerie() With {
                                                                     .Producto = cp.Producto,
                                                                     .NroSerie = ns
                                                         })
      ''''If oLineaDetalle.ProductoSucursal.Producto.NroSerie Then
      ''''   Me.CargarNumeroDeSerieProductosCompras(oLineaDetalle, Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()),
      ''''                                                         Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString()))
      ''''End If

      ''''If chbConcepto.Checked Then ' Me.cmbConceptos.SelectedItem IsNot Nothing Then
      ''''   .IdConcepto = Integer.Parse(Me.cmbConceptos.SelectedValue.ToString())
      ''''   .NombreConcepto = Me.cmbConceptos.Text.ToString()
      ''''End If

      ''''.FechaActualizacion = Me.dtpFechaActPrecios.Value

      '''''--REQ-34986.- ---------------------------------------------
      ''''.IdaAtributoProducto01 = MovAtributo01.IdaAtributoProducto
      ''''.DescripcionAtributo01 = MovAtributo01.Descripcion
      ''''.IdaAtributoProducto02 = MovAtributo02.IdaAtributoProducto
      ''''.DescripcionAtributo02 = MovAtributo02.Descripcion
      ''''.IdaAtributoProducto03 = MovAtributo03.IdaAtributoProducto
      ''''.DescripcionAtributo03 = MovAtributo03.Descripcion
      ''''.IdaAtributoProducto04 = MovAtributo04.IdaAtributoProducto
      ''''.DescripcionAtributo04 = MovAtributo04.Descripcion
      '''''---------------------------------------------------------
      '''''End With

      ''''Me.DefinirOrden(oLineaDetalle)

      ''''If oLineaDetalle.Orden = 0 Then
      ''''   oLineaDetalle.Orden = _numeroOrden
      ''''End If

      ''''If _utilizaCentroCostos Then
      ''''   oLineaDetalle.CentroCosto = DirectCast(cmbCentroCosto.SelectedItem, Entidades.ContabilidadCentroCosto)
      ''''End If
      ''''oLineaDetalle.CodigoProductoProveedor = Me._CodigoProductoProveedor

      ''''Me._productos.Add(oLineaDetalle)

      'Dim ns1 As IEnumerable(Of Entidades.ProductoNroSerie)

      'ns1 = From el As Entidades.ProductoNroSerie In Me._productosNrosSeries _
      '      Where el.Producto.IdProducto = Me._productos(Me._productos.Count - 1).ProductoSucursal.Producto.IdProducto


      'For Each pns As Entidades.ProductoNroSerie In ns
      '   Me._productos(Me._productos.Count - 1).ProductoSucursal.Producto.NrosSeries.Add(pns)
      'Next

      'Me._productos(Me._productos.Count - 1).ProductoSucursal.Producto.NrosSeries = Me._productosNrosSeries

      '''''-- REQ-34986.- ------------------------------------------------------
      ''''If _productos.MaxSecure(Function(p) p.IdaAtributoProducto01).IfNull() > 0 Then
      ''''   If Not _titProductos.ContainsKey("DescripcionAtributo01") Then _titProductos.Add("DescripcionAtributo01", "")
      ''''End If
      ''''If _productos.MaxSecure(Function(p) p.IdaAtributoProducto02).IfNull() > 0 Then
      ''''   If Not _titProductos.ContainsKey("DescripcionAtributo02") Then _titProductos.Add("DescripcionAtributo02", "")
      ''''End If
      ''''If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
      ''''   If Not _titProductos.ContainsKey("DescripcionAtributo03") Then _titProductos.Add("DescripcionAtributo03", "")
      ''''End If
      ''''If _productos.MaxSecure(Function(p) p.IdaAtributoProducto03).IfNull() > 0 Then
      ''''   If Not _titProductos.ContainsKey("DescripcionAtributo04") Then _titProductos.Add("DescripcionAtributo04", "")
      ''''End If
      '''''---------------------------------------------------------------------

      ''''SetProductosDataSource()
      ''''dgvProductos.FirstDisplayedScrollingRowIndex = Me.dgvProductos.Rows.Count - 1


      ''''Me.FormatearGrilla()
      ''''dgvProductos.Refresh()
      '''''Me.CalcularTotalProducto()
      ''''Me.LimpiarCamposProductos()
      ''''Me.CalcularTotales()
      '''''Me.CalcularDescuentoRecargo()
      '''''Me.CalcularTotales()

      '''''      cmbDepositoOrigen.Enabled = (Not _productos.Count > 0)

      ''''ProductoFocus()

      ''''Me._vieneDelDobleClick = False
      '''''--REQ-34986.- --------------------------------
      ''''InicializaAtributos()
      '''''---------------------------------------------

      Return cp
   End Function
   Public Function AgregaCompraProducto(compra As Entidades.Compra, compraProducto As Entidades.CompraProducto, decimalesRedondeoEnPrecio As Integer) As Entidades.CompraProducto
      compra.ComprasProductos.Add(compraProducto)

      CalcularTotales(compra, decimalesRedondeoEnPrecio)

      Return compraProducto
   End Function

   Private Function CalcularTotales(compra As Entidades.Compra, decimalesRedondeoEnPrecio As Integer) As Entidades.Compra

      compra.ComprasImpuestos.Clear()

      Dim brutoTotal = 0D
      Dim netoTotal = 0D         '' netos
      Dim ivaTotal = 0D          '' ivas
      Dim percepcionTotal = 0D
      Dim impuestosInternos = 0D

      For Each cp In compra.ComprasProductos
         Dim ci = compra.ComprasImpuestos.FirstOrDefault(Function(x) x.Alicuota = cp.PorcentajeIVA And x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString())
         If ci Is Nothing Then
            ci = New Entidades.CompraImpuesto() With {.Alicuota = cp.PorcentajeIVA,
                                                      .IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString(),
                                                      .TipoTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()}
            compra.ComprasImpuestos.Add(ci)
         End If
         ci.Bruto += Math.Round(cp.ImporteTotal, decimalesRedondeoEnPrecio)
         ci.BaseImponible += Math.Round(cp.ImporteTotal + cp.DescRecGeneral, decimalesRedondeoEnPrecio)
         ci.Importe += Math.Round(cp.Iva, decimalesRedondeoEnPrecio)
         ci.Importe_Calculado += Math.Round(cp.Iva, decimalesRedondeoEnPrecio)

      Next

      For Each ci In compra.ComprasImpuestos
         brutoTotal += ci.Bruto
         netoTotal += ci.BaseImponible    '' netos
         ivaTotal += ci.Importe           '' ivas
      Next

      compra.ImporteTotal = netoTotal + ivaTotal + percepcionTotal + impuestosInternos
      Return compra
   End Function

   Public Sub AgregarInvocado(compra As Entidades.Compra, invocado As Entidades.PedProvAdminClaveGenerar, _cache As BusquedasCacheadas)
      AgregarInvocado(compra,
                      New Entidades.Compra() With {
                              .IdSucursal = invocado.IdSucursal,
                              .TipoComprobante = _cache.BuscaTipoComprobante(invocado.IdTipoComprobante),
                              .Letra = invocado.Letra,
                              .CentroEmisor = invocado.CentroEmisor.ToShort(),
                              .NumeroComprobante = invocado.NumeroPedido,
                              .Proveedor = _cache.BuscaProveedor(invocado.IdProveedor)
                          })
   End Sub
   Public Sub AgregarInvocado(compra As Entidades.Compra, invocado As Entidades.PedidoProveedor)
      AgregarInvocado(compra,
                      New Entidades.Compra() With {
                              .IdSucursal = invocado.IdSucursal,
                              .TipoComprobante = invocado.TipoComprobante,
                              .Letra = invocado.LetraComprobante,
                              .CentroEmisor = invocado.CentroEmisor,
                              .NumeroComprobante = invocado.NumeroPedido,
                              .Proveedor = invocado.Proveedor
                          })
   End Sub
   Public Sub AgregarInvocado(compra As Entidades.Compra, invocado As Entidades.Compra)
      If Not compra.Facturables.Exists(Function(i) i.IdSucursal = invocado.IdSucursal And
                                                   i.IdTipoComprobante = invocado.IdTipoComprobante And
                                                   i.Letra = invocado.Letra And
                                                   i.NumeroComprobante = invocado.NumeroComprobante) Then
         compra.Facturables.Add(invocado)
         If compra.TipoComprobante.GeneraObservConInvocados Then
            AgregarVentaObservacion(compra, String.Format("Invoco: {0} ´{1}´ {2:0000}:{3:00000000}. Emision: {4:dd/MM/yyyy}.",
                                                      invocado.TipoComprobante.Descripcion,
                                                      invocado.Letra,
                                                      invocado.CentroEmisor,
                                                      invocado.NumeroComprobante,
                                                      invocado.Fecha))
         End If
      End If
   End Sub
   Public Sub AgregarVentaObservacion(compra As Entidades.Compra, observacion As String)
      Dim obs = New Entidades.CompraObservacion()
      With obs
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Observacion = observacion

         compra.ComprasObservaciones.Add(obs)
         obs.Linea = compra.ComprasObservaciones.Count
      End With
   End Sub


   Public Function PreparaRemitoTransporte(compra As Entidades.Compra,
                                           transportista As Entidades.Transportista, totalBultos As Integer, valorDeclarado As Decimal, lote As Integer) As Entidades.Compra

      If compra.TipoComprobante.EsRemitoTransportista Then

         If transportista Is Nothing Then
            Throw New Exception(String.Format("El comprobante de tipo {0} es Remito Transportista. El transportista es requerido.", compra.TipoComprobante.Descripcion))
         End If
         If totalBultos = 0 Then
            Throw New Exception(String.Format("El comprobante de tipo {0} es Remito Transportista. El total de bultos es requerido.", compra.TipoComprobante.Descripcion))
         End If
         If valorDeclarado <= 0 Then
            Throw New Exception(String.Format("El comprobante de tipo {0} es Remito Transportista. El valor declarado es requerido.", compra.TipoComprobante.Descripcion))
         End If
         If Publicos.Facturacion.FacturacionRemitoTranspUtilizaLote AndAlso lote <= 0 Then
            Throw New Exception(String.Format("El comprobante de tipo {0} es Remito Transportista. El lote es requerido.", compra.TipoComprobante.Descripcion))
         End If

         compra.Transportista = transportista
         compra.Bultos = totalBultos
         compra.NumeroLote = lote
         compra.ValorDeclarado = valorDeclarado

         compra.TotalBruto = valorDeclarado
         compra.TotalNeto = valorDeclarado
         compra.ImporteTotal = valorDeclarado

      End If

      Return compra
   End Function

   Public Function PreparaCompraParaGrabar(compra As Entidades.Compra, cache As BusquedasCacheadas) As Entidades.MovimientoStock
      Dim oMov = New Entidades.MovimientoStock With {
         .Sucursal = cache.BuscaSucursal(compra.IdSucursal),
         .IdCaja = compra.IdCaja,
         .TipoMovimiento = New TiposMovimientos(da).GetUnoPorComprobanteAsociado(compra.IdTipoComprobante),
         .NumeroMovimiento = 0,
         .FechaMovimiento = compra.Fecha,
         .Total = compra.ImporteTotal,
         .Proveedor = compra.Proveedor,
         .Observacion = compra.Observacion,
         .Comentarios = String.Empty,
         .Usuario = compra.Usuario,
         .Compra = compra
      }

      For Each cp In compra.ComprasProductos
         Dim msp = New Entidades.MovimientoStockProducto
         msp.Sucursal = oMov.Sucursal
         msp.TipoMovimiento = oMov.TipoMovimiento
         msp.NumeroMovimiento = 0
         msp.IdProducto = cp.Producto.IdProducto
         msp.NombreProducto = cp.NombreProducto
         msp.IdSucursal = oMov.Sucursal.IdSucursal
         msp.IdDeposito = cp.IdDeposito
         msp.IdUbicacion = cp.IdUbicacion
         msp.Cantidad = cp.Cantidad
         msp.Precio = cp.Precio
         msp.Orden = cp.Orden
         msp.PrecioCostoO = cp.Precio * (1 + cp.PorcentajeIVA)
         msp.DescuentoRecargoPorc = cp.DescuentoRecargoPorc
         msp.DescuentoRecargo = cp.DescuentoRecargo
         msp.DescRecGeneral = cp.DescRecGeneral
         msp.Stock = cp.Stock
         msp.ImporteTotal = cp.ImporteTotal
         msp.PorcentajeIVA = cp.PorcentajeIVA
         msp.IVA = cp.Iva
         msp.TotalProducto = cp.ImporteTotal + cp.Iva
         msp.PorcVar = 0
         msp.IdLote = cp.IdLote
         msp.VtoLote = cp.FechaVencimientoLote
         msp.InformeCalidadNumero = cp.InformeCalidadNumero
         msp.InformeCalidadLink = cp.InformeCalidadLink
         '-- REQ-41716.- -----------------------------------
         msp.CantidadUMCompra = cp.CantidadUMCompra
         msp.FactorConversionCompra = cp.FactorConversionCompra
         msp.PrecioPorUMCompra = cp.PrecioPorUMCompra
         '-- REQ-43215.- -----------------------------------
         msp.IdUnidadDeMedida = cp.IdUnidadDeMedida
         msp.IdUnidadDeMedidaCompra = cp.IdUnidadDeMedidaCompra
         '--------------------------------------------------

         msp.ProductosNrosSerie = cp.Producto.NrosSeries.ConvertAll(Function(ns) New Entidades.MovimientoStockProductoNrosSerie() With {
                                                                        .IdSucursal = ns.IdSucursal,
                                                                        .IdProducto = ns.Producto.IdProducto,
                                                                        .NroSerie = ns.NroSerie,
                                                                        .Cantidad = 1,
                                                                        .IdDeposito = ns.IdDeposito,
                                                                        .IdUbicacion = ns.IdUbicacion
                                                                     })
         If Not String.IsNullOrWhiteSpace(msp.IdLote) Then
            oMov.ProductosLotes.Add(New Entidades.ProductoLote() With {
                                       .IdSucursal = msp.IdSucursal,
                                       .IdDeposito = msp.IdDeposito,
                                       .IdUbicacion = msp.IdUbicacion,
                                       .ProductoSucursal = cp.ProductoSucursal,
                                       .IdLote = msp.IdLote,
                                       .FechaIngreso = Date.Now,
                                       .FechaVencimiento = msp.VtoLote,
                                       .CantidadActual = msp.Cantidad,
                                       .CantidadActualOriginal = msp.Cantidad,
                                       .Habilitado = True
                                    })
         End If
         If cp.Producto.NrosSeries.AnySecure() Then
            msp.ProductoSucursal.Producto.NrosSeries = msp.ProductosNrosSerie.ConvertAll(Function(ns) New Entidades.ProductoNroSerie() With {
                                            .IdSucursal = oMov.Sucursal.IdSucursal,
                                            .Sucursal = oMov.Sucursal,
                                            .IdDeposito = msp.IdDeposito,
                                            .IdUbicacion = msp.IdUbicacion,
                                            .Producto = New Entidades.Producto() With {.IdProducto = msp.IdProducto},
                                            .Vendido = oMov.TipoMovimiento.CoeficienteStock < 0,
                                            .NroSerie = ns.NroSerie,
                                            .TipoComprobante = oMov.Compra.TipoComprobante,
                                            .Letra = oMov.Compra.Letra,
                                            .CentroEmisor = oMov.Compra.CentroEmisor,
                                            .NumeroComprobante = oMov.Compra.NumeroComprobante,
                                            .Proveedor = oMov.Compra.Proveedor
                                         })
            oMov.ProductosNrosSerie.AddRange(msp.ProductoSucursal.Producto.NrosSeries)
            ''''oMov.ProductosNrosSerie.AddRange(msp.ProductosNrosSerie.ConvertAll(Function(ns) New Entidades.ProductoNroSerie() With {
            ''''                           .IdSucursal = oMov.Sucursal.IdSucursal,
            ''''                           .Sucursal = oMov.Sucursal,
            ''''                           .IdDeposito = msp.IdDeposito,
            ''''                           .IdUbicacion = msp.IdUbicacion,
            ''''                           .Producto = New Entidades.Producto() With {.IdProducto = msp.IdProducto},
            ''''                           .Vendido = oMov.TipoMovimiento.CoeficienteStock < 0,
            ''''                           .NroSerie = ns.NroSerie,
            ''''                           .TipoComprobante = oMov.Compra.TipoComprobante,
            ''''                           .Letra = oMov.Compra.Letra,
            ''''                           .CentroEmisor = oMov.Compra.CentroEmisor,
            ''''                           .NumeroComprobante = oMov.Compra.NumeroComprobante,
            ''''                           .Proveedor = oMov.Compra.Proveedor
            ''''                        }))
         End If
         msp.IdConcepto = cp.IdConcepto
         msp.IdaAtributoProducto01 = cp.IdaAtributoProducto01
         msp.DescripcionAtributo01 = cp.DescripcionAtributo01
         msp.IdaAtributoProducto02 = cp.IdaAtributoProducto02
         msp.DescripcionAtributo02 = cp.DescripcionAtributo02
         msp.IdaAtributoProducto03 = cp.IdaAtributoProducto03
         msp.DescripcionAtributo03 = cp.DescripcionAtributo03
         msp.IdaAtributoProducto04 = cp.IdaAtributoProducto04
         msp.DescripcionAtributo04 = cp.DescripcionAtributo04

         msp.Usuario = compra.Usuario
         msp.IdSucursal = compra.IdSucursal

         'msp.Deposito = cp.IdDeposito
         'msp.Ubicacion = cp.IdUbicacion
         'msp.NombreUbicacion As String
         'msp.NombreDeposito As String
         'msp.Cantidad2 = 0
         'msp.CantidadParaGrillas = 0
         'msp.IdSucursal2 As Integer
         'msp.NombreSucursal2 As String
         'msp.IdDeposito2 As Integer
         'msp.NombreDeposito2 As String
         'msp.IdUbicacion2 As Integer
         'msp.NombreUbicacion2 As String
         'msp.PorcentRecargo = cp.DescuentoRecargoPorc
         'msp.NombreConcepto() As String
         'msp.FechaActualizacion= 
         'msp.PrecioCostoNuevo() As Decimal
         'msp.PrecioVentaActual() As Decimal
         'msp.PrecioVentaNuevo() As Decimal
         'msp.CodigoProductoProveedor = String.Empty
         'msp.NrosSerie As String
         oMov.Productos.Add(msp)
      Next

      compra.ComprasProductos.Clear()

      Return oMov
   End Function

End Class
Public Structure PrecioEnmascarado
   Public Property Precio As Decimal
   Public Property ConIva As Boolean
   Public Sub New(valor As Decimal, conIva As Boolean)
      Me.Precio = valor
      Me.ConIva = conIva
   End Sub
End Structure
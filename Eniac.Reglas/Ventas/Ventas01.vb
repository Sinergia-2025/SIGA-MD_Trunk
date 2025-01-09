Imports SSSSoporte.Entidades

Imports Eniac.Reglas.WSFEv1
Imports Eniac.Entidades

Partial Class Ventas

   ''GRABACION / ACTUALIZACION

#Region "GrabarComprobante"
   Public Function GrabarComprobante(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     idCliente As Long,
                                     idCaja As Integer,
                                     fecha As Date,
                                     vendedor As Entidades.Empleado,
                                     idFormasPago As Integer,
                                     observacion As String,
                                     importeTotal As Decimal,
                                     idProducto As String,
                                     cantProducto As Decimal,
                                     observacionDetalladas As List(Of Entidades.VentaObservacion),
                                     solicitaCAE As Boolean?,
                                     contactos As List(Of Entidades.VentaClienteContacto),
                                     nombreProducto As String,
                                     cobrador As Entidades.Empleado,
                                     comprobantesAsociados As IEnumerable(Of Entidades.Venta),
                                     idEmbarcacion As Long,
                                     metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                     idFuncion As String) As Entidades.Venta

      '' ''Dim vp As VentaProducto = New VentaProducto()
      '' ''vp.Producto = New Productos().GetUno(IdProducto)

      '' ''Return GrabarComprobante(IdSucursal, IdTipoComprobante, IdCliente, IdCaja, Fecha, TipoDocVendedor, NroDocVendedor, IdFormasPago,
      '' ''                         Observacion, ImporteTotal, New List(Of VentaProducto)({vp}), ObservacionDetalladas)

      'Dim _ventasProductos As List(Of Entidades.VentaProducto)
      'Dim _subTotales As List(Of Entidades.VentaImpuesto)
      'Dim _ImpuestosVarios As System.Collections.Generic.List(Of Entidades.VentaImpuesto)
      'Dim _estado As Estados
      'Dim _publicos As Publicos
      'Dim _numeroComprobante As Integer
      'Dim _clienteE As Entidades.Cliente
      'Dim _comprobantesSeleccionados As List(Of Entidades.Venta)
      'Dim _ModificaDetalle As String
      'Dim _cheques As List(Of Entidades.Cheque)
      'Dim _ventasObservaciones As List(Of Entidades.VentaObservacion)
      'Dim _transportistaA As Entidades.Transportista
      'Dim _chequesRechazados As List(Of Entidades.Cheque)
      'Dim _estaCargando As Boolean = True
      'Dim _cantMaxItems As Integer
      'Dim _cantMaxItemsObserv As Integer
      'Dim _imprime As Boolean
      Dim _tipoImpuestoIVA = Entidades.TipoImpuesto.Tipos.IVA
      'Dim _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
      'Dim _productoLoteTemporal As Entidades.VentaProductoLote
      'Dim _productosLotes As List(Of Entidades.VentaProductoLote)
      'Dim _productosNrosSeries As List(Of Entidades.ProductoNroSerie)
      Dim _numeroOrden As Integer


      Dim cb As Entidades.Venta
      Dim Comprobante As Entidades.Venta
      '----------------------------------

      'Dim blnTransaccionActiva As Boolean = Me.da.Transaction Is Nothing
      Dim blnConexionAbierta As Boolean = Me.da.Connection.State = ConnectionState.Open

      Try

         If Not blnConexionAbierta Then
            da.OpenConection()
            da.BeginTransaction()
         End If

         Dim _publicos = New Publicos()

         Dim _ventasProductos = New List(Of Entidades.VentaProducto)()
         Dim _subTotales = New List(Of Entidades.VentaImpuesto)()

         'Me._estaCargando = False

         Dim _categoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
         Dim _clienteE = New Clientes(da)._GetUno(idCliente, False)

         '*****  GENERO EL PRODUCTO, LOS IMPUESTOS y OTROS ****

         Dim Producto As Entidades.Producto
         Producto = New Reglas.Productos(da).GetUno(idProducto)


         Dim oLineaDetalle As Entidades.VentaProducto = New Entidades.VentaProducto()
         Dim oLineaImpuestos As Entidades.VentaImpuesto = New Entidades.VentaImpuesto()

         Dim Kilos As Decimal = 0

         Dim importeBruto As Decimal = 0
         Dim importeNeto As Decimal = 0
         Dim importeIva As Decimal = 0
         'Dim importeTotal As Decimal = 0

         Dim precioCosto As Decimal = 0
         Dim precioLista As Decimal = 0
         Dim alicuotaIVA As Decimal = Producto.Alicuota
         Dim IdMoneda As Integer = Producto.Moneda.IdMoneda

         Dim tipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)

         If Not tipoComprobante.UtilizaImpuestos Then
            alicuotaIVA = 0
         End If

         'If IdMoneda = 2 Then
         '   precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
         '   precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
         'End If

         'If Producto.UnidadDeMedida.ConversionAKilos <> 0 Then
         '   Kilos = Decimal.Round(Producto.Tamano * Producto.UnidadDeMedida.ConversionAKilos, 3)
         'End If
         Kilos = Decimal.Round(Producto.Kilos * cantProducto, 3)


         Dim PrecioVentaSinIVA As Decimal = Decimal.Round(importeTotal / (1 + alicuotaIVA / 100), 2)
         Dim PrecioVentaConIVA As Decimal = importeTotal
         Dim precioProducto As Decimal = 0

         If (_clienteE.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
            Not _clienteE.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
            precioProducto = PrecioVentaSinIVA
         Else
            'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
            precioProducto = PrecioVentaConIVA
         End If

         Dim cantidad As Decimal = cantProducto

         Dim descRecPorGeneral As Decimal = 0

         Dim precioNeto As Decimal = 0

         _numeroOrden += 1

         '--------------------------------------------------------------------------------

         Dim alicuotaIVASobre100 As Decimal = (alicuotaIVA / 100)

         precioNeto = precioProducto

         importeBruto = precioProducto

         If Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            importeIva = Decimal.Round(precioNeto - precioNeto / (1 + alicuotaIVASobre100), 2)
         Else
            importeIva = Decimal.Round(precioNeto * alicuotaIVASobre100, 2)
         End If

         With oLineaDetalle
            .IdSucursal = idSucursal
            .Usuario = actual.Nombre
            .Producto = Producto
            If Not String.IsNullOrWhiteSpace(nombreProducto) Then
               .Producto.NombreProducto = nombreProducto
            End If
            .DescuentoRecargoPorc1 = 0
            .DescuentoRecargoPorc2 = 0
            .DescuentoRecargo = 0
            .Precio = precioProducto
            .Cantidad = cantidad
            .ImporteTotal = precioProducto
            .Stock = 0
            .Costo = precioCosto
            .PrecioLista = precioProducto
            .Kilos = Kilos
            .PrecioNeto = precioNeto
            .AlicuotaImpuesto = alicuotaIVA
            .ImporteImpuesto = importeIva
            .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)
            .ComisionVendedorPorc = 0
            .ComisionVendedor = 0
            Dim ListaPrecios As Entidades.ListaDePrecios = New Reglas.ListasDePrecios(da).GetUno(Publicos.ListaPreciosPredeterminada)
            .IdListaPrecios = ListaPrecios.IdListaPrecios
            .NombreListaPrecios = ListaPrecios.NombreListaPrecios
            .NombreCortoListaPrecios = ListaPrecios.NombreCortoListaPrecios
         End With

         oLineaDetalle.Orden = _numeroOrden
         _ventasProductos.Add(oLineaDetalle)

         importeNeto = precioNeto * cantidad

         'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
         If (Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado) Then
            importeBruto = Decimal.Round(importeBruto / (1 + alicuotaIVA / 100), 2)
            importeNeto = Decimal.Round(importeNeto / (1 + alicuotaIVA / 100), 2)
         End If

         With oLineaImpuestos
            .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)
            .Alicuota = alicuotaIVA
            .Bruto = importeBruto
            .Neto = importeNeto
            .Importe = importeIva
            .Total = importeTotal
         End With

         _subTotales.Add(oLineaImpuestos)

         'Me.CalcularTotales()
         'Me.CalcularDatosDetalle()

         '---------------------------------------------------------------

         Comprobante = New Entidades.Venta()

         With Comprobante

            'cargo el comprobante
            .TipoComprobante = tipoComprobante

            'cargo el cliente ----------
            .Cliente = _clienteE
            .NombreCliente = _clienteE.NombreCliente


            .IdCategoria = .Cliente.IdCategoria

            'cargo la direccion predeterminada.
            .Direccion = .Cliente.Direccion
            '.LocalidadCliente = .Cliente.NombreLocalidad
            '.ProvinciaCliente = .Cliente.Localidad.NombreProvincia
            .IdLocalidad = .Cliente.IdLocalidad


            'cargo datos generales del comprobante
            .IdSucursal = idSucursal
            .Usuario = actual.Nombre
            .Fecha = fecha

            ' .Vendedor = New Reglas.Empleados().GetUno(tipoDocVendedor, nroDocVendedor)
            .Vendedor = vendedor
            .Cobrador = cobrador

            .FormaPago = New Reglas.VentasFormasPago().GetUna(idFormasPago)

            .IdCaja = idCaja

            .IdEmbarcacion = idEmbarcacion

            .Observacion = observacion ' "Generado Automatico"

            .ImporteTotal = importeTotal


            ''cargo el comprobante
            '.TipoComprobante = New Reglas.TiposComprobantes().GetUno(IdTipoComprobante)

            ''cargo el cliente ----------
            '.Cliente = Me._clienteGrilla

            .CategoriaFiscal = .Cliente.CategoriaFiscal

            'Si es X es Cotizacion, Dev-Cotizacion, etc, siempre debe tener esa letra, sino dejo la del Cliente.

            If .TipoComprobante.LetrasHabilitadas = "X" Then
               .LetraComprobante = "X"
            Else
               .LetraComprobante = .CategoriaFiscal.LetraFiscal
            End If

            'cargo la impresora
            .Impresora = New Reglas.Impresoras(da)._GetPorSucursalPCTipoComprobante(.IdSucursal, My.Computer.Name, .TipoComprobante.IdTipoComprobante)
            .CentroEmisor = .Impresora.CentroEmisor
            .NumeroComprobante = New Reglas.VentasNumeros(da).GetProximoNumero(_cache.BuscaSucursal(.IdSucursal), .TipoComprobante.IdTipoComprobante, .LetraComprobante, .CentroEmisor)

            ''cargo datos generales del comprobante
            '.IdSucursal = actual.Sucursal.Id
            '.Usuario = actual.Nombre
            '.Fecha = Me.dtpFecha.Value

            '.Vendedor = Me._clienteGrilla.Vendedor

            '.FormaPago = New Reglas.VentasFormasPago().GetUna(3) 'Cuenta Corriente

            '.Observacion = "Generado Automatico" 'Me.txtObservacion.Text


            .VentasImpuestos = _subTotales
            '.ImpuestosVarios = _ImpuestosVarios

            'cargo valores del comprobante
            .ImporteBruto = importeBruto
            .DescuentoRecargo = 0
            .DescuentoRecargoPorc = 0
            .Subtotal = importeNeto
            .TotalImpuestos = importeIva
            '.ImporteTotal = importeTotal  'Ya seteado previamente.

            .Kilos = Kilos

            'cargo los productos
            .VentasProductos = _ventasProductos

            'Cargo los Comprobantes Facturados (tal vez ninguno)
            '.Facturables = Me._comprobantesSeleccionados

            'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
            'If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 AndAlso .TipoComprobante.CoeficienteStock <> 0 Then
            '   .IdEstadoComprobante = "INVOCO"
            '   .CantidadInvocados = Me._comprobantesSeleccionados.Count
            'Else
            ''''.CantidadInvocados = 0
            'End If

            'cargo el Remito Transportista
            .Bultos = 0
            .ValorDeclarado = 0
            .Transportista = Nothing   ' Me._transportistaA
            .NumeroLote = 0

            'cargo las Observaciones
            .VentasObservaciones = observacionDetalladas

            'If ObservacionDetalladas.Count > 0 Then

            '   Dim Cont As Integer

            '   'Tengo que asignar el numero de comprobante porque se genera a ultima momento.
            '   For Cont = 0 To ObservacionDetalladas.Count - 1
            '      ObservacionDetalladas(Cont).IdSucursal = .IdSucursal
            '      ObservacionDetalladas(Cont).IdTipoComprobante = .IdTipoComprobante
            '      ObservacionDetalladas(Cont).Letra = .LetraComprobante
            '      ObservacionDetalladas(Cont).CentroEmisor = .CentroEmisor
            '      ObservacionDetalladas(Cont).NumeroComprobante = .NumeroComprobante
            '   Next

            'End If

            'carga los importes de pagos y cheques
            '.Cheques = Me._cheques

            'Dejo en cero porque se pisa con la funcionalidad de CuentaCorriente Parcial.
            .ImportePesos = 0             '.ImporteTotal
            .ImporteDolares = 0
            '--------------------------------------------------------------
            '.ImporteTarjetas = 0
            .ImporteTickets = 0

            'carga los cheques rechazados
            '.ChequesRechazados = Me._chequesRechazados

            'Informe los Productos que tuvieron Lotes.
            .CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.

            'cargo los Lotes
            '.VentasProductosLotes = Me._productosLotes

            'Cargo la utilidad
            .Utilidad = importeNeto

            .CotizacionDolar = New Eniac.Reglas.Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion

            .ComisionVendedor = 0

            If .CategoriaFiscal.SolicitaCUIT Then
               .Cuit = .Cliente.Cuit
            ElseIf Not String.IsNullOrEmpty(.Cliente.NroDocCliente.ToString) Then
               .TipoDocCliente = .Cliente.TipoDocCliente
               .NroDocCliente = .Cliente.NroDocCliente
            End If

         End With

         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If Comprobante.TipoComprobante.ActualizaCtaCte Then

            If Comprobante.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Publicos.TieneModuloCuentaCorrienteClientes Then

                  Dim oCCP As Entidades.CuentaCorrientePago
                  oCCP = New Entidades.CuentaCorrientePago()
                  oCCP.ImporteCuota = Comprobante.ImporteTotal
                  oCCP.SaldoCuota = oCCP.ImporteCuota
                  oCCP.FechaVencimiento = Comprobante.Fecha.AddDays(Comprobante.FormaPago.Dias)
                  Comprobante.CuentaCorriente.Pagos.Add(oCCP)
               End If

            End If

         End If

         Comprobante.Invocados.Add(comprobantesAsociados)
         Comprobante.SeleccionoInvocados = Entidades.Publicos.SiNoTodos.SI

         'If comprobantesAsociados IsNot Nothing Then
         '   For Each asoc In comprobantesAsociados
         '      Comprobante.Facturables.Add(asoc)
         '   Next
         'End If

         ''si voy a imprimir en una impresora fiscal, primero imprimo y despues obtengo el nro. de comprobante
         ''en otro caso, grabo y despues imprimo
         'If oVentas.TipoComprobante.EsFiscal Then
         '   If Me.ImprimirComprobante(oVentas) Then
         '      oVentas.NumeroComprobante = Me._numeroComprobante
         '      oFacturacion.Insertar(oVentas)
         '      MessageBox.Show(oVentas.TipoComprobante.Descripcion & " Nro. " & oVentas.NumeroComprobante.ToString() & Convert.ToChar(Keys.Enter) & " de " & Me.bscCliente.Text & Convert.ToChar(Keys.Enter) & " fue impreso y grabado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '      If Not String.IsNullOrEmpty(oVentas.TipoComprobante.IdTipoComprobanteSecundario) Then
         '         If MessageBox.Show("¿Desea Cargar Automaticamente el Comprobante Secundario '" & oVentas.TipoComprobante.IdTipoComprobanteSecundario & "'?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         '            'Me.tsbGrabar.Enabled = True
         '            Me.NuevoSecundario(oVentas)
         '            Exit Sub
         '         End If
         '      End If
         '      Me.Nuevo()
         '   End If
         'Else

         Inserta(Comprobante, metodoGrabacion, idFuncion)

         '   Dim msg As System.Text.StringBuilder = New System.Text.StringBuilder()
         '   msg.AppendFormat("{0} Nro. {1}", oVentas.TipoComprobante.Descripcion, oVentas.NumeroComprobante.ToString()).AppendLine()
         '   msg.AppendFormat("de {0}", Me.bscCliente.Text).AppendLine()

         '   If oVentas.TipoComprobante.EsElectronico Then
         '      If Not String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
         '         msg.AppendFormat("CAE {0} con vencimiento {1} ", oVentas.AFIPCAE.CAE, oVentas.AFIPCAE.CAEVencimiento.ToString("dd/MM/yyyy")).AppendLine()
         '      End If
         '   End If

         '   'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
         '   If Me.ImprimeComprobante() Then
         '      If Me.ImprimirComprobante(oVentas) Then
         '         msg.AppendFormat(" fue impreso y grabado.")
         '      Else
         '         msg.AppendFormat(" fue grabado.")
         '      End If
         '   Else
         '      msg.AppendFormat(" fue grabado.")
         '   End If

         '   MessageBox.Show(msg.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         '   If Not String.IsNullOrEmpty(oVentas.TipoComprobante.IdTipoComprobanteSecundario) Then
         '      If MessageBox.Show("¿Desea Cargar Automaticamente el Comprobante Secundario '" & oVentas.TipoComprobante.IdTipoComprobanteSecundario & "'?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         '         Me.NuevoSecundario(oVentas)
         '         Exit Sub
         '      End If
         '   End If
         '   Me.Nuevo()
         'End If

         'Lo asigno completo para que tenga valor en el procedimiento que lo llamo.
         cb = GetUna(Comprobante.IdSucursal,
                     Comprobante.TipoComprobante.IdTipoComprobante,
                     Comprobante.LetraComprobante,
                     Comprobante.CentroEmisor,
                     Comprobante.NumeroComprobante)

         If Not blnConexionAbierta Then
            da.CommitTransaction()
         End If

      Catch
         If Not blnConexionAbierta Then
            da.RollbakTransaction()
         End If
         Throw
      Finally
         If Not blnConexionAbierta Then
            da.CloseConection()
         End If
      End Try

      'LA SOLICITUD DE CAE LA DEBEMOS HACER FUERA DE LA TRANSACCION
      '  - SI TODO OK: SE CREA EL COMPROBANTE FINAL Y SE ELIMINA EL PRE-COMPROBANTE
      '  - SI ERROR:   DEBE QUEDAR EL PRE-COMPROBANTE PARA SOLICITAR EL CAE A TRAVES
      '                DE LA PANTALLA DE SOLICITAR CAE
      Try
         If Not blnConexionAbierta Then
            da.OpenConection()
            da.BeginTransaction()
         End If

         If Not solicitaCAE.HasValue Then
            solicitaCAE = Publicos.Facturacion.FacturacionElectronica.FacturacionElectronicaSincronica ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.FACTELECTSINCRONICA))
         End If

         If Comprobante IsNot Nothing AndAlso
            (solicitaCAE.Value And Comprobante.TipoComprobante.EsPreElectronico) Then

            If Not Publicos.HayInternet() Then
               Throw New Exception("No tiene internet para realizar esta acción.")
               Exit Function
            End If

            'Actualizo la Fecha de Transmision al AFIP porque Si tiene la Fecha.. no podra anularlo.

            Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
            sql.U_FechaTransmisionAFIP(Comprobante.IdSucursal, Comprobante.TipoComprobante.IdTipoComprobante,
                                                Comprobante.LetraComprobante, Comprobante.Impresora.CentroEmisor,
                                                Comprobante.NumeroComprobante, Date.Now)

            Comprobante.Usuario = actual.Nombre

            Me.ActualizaCAE(Comprobante, Entidades.AFIPCAE.Secuencia.PrimeraVez, metodoGrabacion, idFuncion)

            cb = Me.GetUna(Comprobante.IdSucursal,
                           Comprobante.TipoComprobante.IdTipoComprobante,
                           Comprobante.LetraComprobante,
                           Comprobante.CentroEmisor,
                           Comprobante.NumeroComprobante)

         End If

         If Not blnConexionAbierta Then Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         If ComprobanteAnt IsNot Nothing Then
            With ComprobanteAnt
               Comprobante.IdSucursal = ComprobanteAnt.IdSucursal
               Comprobante.TipoComprobante = ComprobanteAnt.TipoComprobante
               Comprobante.LetraComprobante = ComprobanteAnt.LetraComprobante
               Comprobante.CentroEmisor = ComprobanteAnt.CentroEmisor
               Comprobante.NumeroComprobante = ComprobanteAnt.NumeroComprobante
            End With
         End If
         If Not blnConexionAbierta Then da.RollbakTransaction()
         Throw New ActualizaCAEException(ex, Comprobante)
      Finally
         If Not blnConexionAbierta Then da.CloseConection()
      End Try

      Return cb

   End Function

   Public Function GrabarComprobante(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     idCliente As Long,
                                     idCaja As Integer,
                                     fecha As Date,
                                     vendedor As Entidades.Empleado,
                                     idFormasPago As Integer,
                                     observacion As String,
                                     importeTotal As Decimal,
                                     productos As List(Of Entidades.VentaProducto),
                                     observacionDetalladas As List(Of Entidades.VentaObservacion),
                                     solicitaCAE As Boolean?,
                                     metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                     idFuncion As String,
                                     cuota As Integer,
                                     cuentaCorrientePago As List(Of Entidades.CuentaCorrientePago),
                                     cuentaCorriente As Entidades.CuentaCorriente) As Entidades.Venta

      Dim _ventasProductos As List(Of Entidades.VentaProducto)
      Dim _subTotales As List(Of Entidades.VentaImpuesto)
      Dim _publicos As Publicos
      Dim _clienteE As Entidades.Cliente
      Dim _tipoImpuestoIVA = Entidades.TipoImpuesto.Tipos.IVA
      Dim _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
      Dim _numeroOrden As Integer
      Dim entro As Boolean = False
      Dim cb As Entidades.Venta
      Dim Comprobante As Entidades.Venta
      Dim _ImporteBruto As Decimal
      Dim _TotalImpuestos As Decimal

      '----------------------------------

      Dim blnConexionAbierta As Boolean = Me.da.Connection.State = ConnectionState.Open

      Try

         If Not blnConexionAbierta Then
            Me.da.OpenConection()
            Me.da.BeginTransaction()
         End If

         _publicos = New Publicos()

         _ventasProductos = New System.Collections.Generic.List(Of Entidades.VentaProducto)
         _subTotales = New System.Collections.Generic.List(Of Entidades.VentaImpuesto)

         _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
         _clienteE = New Reglas.Clientes().GetUno(idCliente, False)

         '*****  GENERO EL PRODUCTO, LOS IMPUESTOS y OTROS ****

         Dim oLineaDetalle As Entidades.VentaProducto
         Dim oLineaImpuestos As Entidades.VentaImpuesto

         For Each dr As Entidades.VentaProducto In productos

            oLineaDetalle = New Entidades.VentaProducto()


            Dim Kilos As Decimal = 0

            Dim importeBruto As Decimal = 0
            Dim importeNeto As Decimal = 0
            Dim importeIva As Decimal = 0
            ' Dim importeTotal As Decimal = 0

            Dim precioCosto As Decimal = 0
            Dim precioLista As Decimal = 0

            Dim alicuotaIVA As Decimal = dr.Producto.Alicuota
            Dim IdMoneda As Integer = dr.Producto.Moneda.IdMoneda

            'If IdMoneda = 2 Then
            '   precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
            '   precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
            'End If

            Dim PrecioVentaConIVA As Decimal = dr.PrecioLista
            Dim PrecioVentaSinIVA As Decimal = Decimal.Round(PrecioVentaConIVA / (1 + alicuotaIVA / 100), 2)

            Dim precioProducto As Decimal = 0

            If (_clienteE.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
               Not _clienteE.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
               precioProducto = PrecioVentaSinIVA
            Else
               'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
               precioProducto = PrecioVentaConIVA
            End If

            Dim descRecPorGeneral As Decimal = 0

            Dim precioNeto As Decimal = 0

            _numeroOrden += 1

            '--------------------------------------------------------------------------------

            Dim alicuotaIVASobre100 As Decimal = (alicuotaIVA / 100)

            'precioNeto = precioProducto * (1 + (dr.DescuentoRecargoPorc1 / 100)) * (1 + (dr.DescuentoRecargoPorc2 / 100))
            precioNeto = precioProducto
            precioNeto = precioNeto * (1 + (dr.DescuentoRecargoPorc1 / 100))
            precioNeto = precioNeto * (1 + (dr.DescuentoRecargoPorc2 / 100))

            'GAR: 14/07/2018 - Falta la funcionalidad de Descuento General!!!
            'importeBruto = precioProducto * dr.Cantidad
            importeBruto = precioNeto * dr.Cantidad

            If Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
               importeIva = Decimal.Round(precioNeto - precioNeto / (1 + alicuotaIVASobre100), 2)
            Else
               importeIva = Decimal.Round(precioNeto * alicuotaIVASobre100, 2)
            End If

            importeIva = importeIva * dr.Cantidad

            With oLineaDetalle
               .IdSucursal = actual.Sucursal.Id
               .Usuario = actual.Nombre
               .Producto = dr.Producto

               .Costo = precioCosto
               .PrecioLista = precioProducto
               .Precio = precioProducto
               .PrecioNeto = precioNeto
               .DescuentoRecargoPorc1 = dr.DescuentoRecargoPorc1
               .DescuentoRecargoPorc2 = dr.DescuentoRecargoPorc2
               .DescuentoRecargoProducto = precioNeto - precioProducto 'Analizar si hubiera descuento general / Unificar con Grabacion normal.
               .Cantidad = dr.Cantidad
               .DescuentoRecargo = .DescuentoRecargoProducto * .Cantidad  'Analizar si hubiera descuento general / Unificar con Grabacion normal.
               .ImporteTotal = precioNeto * .Cantidad
               .Stock = 0
               .Kilos = Kilos
               .AlicuotaImpuesto = alicuotaIVA
               .ImporteImpuesto = importeIva
               .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)
               .ComisionVendedorPorc = 0
               .ComisionVendedor = 0
               .NombreListaPrecios = ""
               .NombreCortoListaPrecios = ""
            End With

            oLineaDetalle.Orden = _numeroOrden
            _ventasProductos.Add(oLineaDetalle)

            importeNeto = precioNeto * dr.Cantidad

            'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
            If (Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado) Then
               importeBruto = Decimal.Round(importeBruto / (1 + alicuotaIVA / 100), 2)
               importeNeto = Decimal.Round(importeNeto / (1 + alicuotaIVA / 100), 2)
            End If

            _ImporteBruto += importeBruto
            _TotalImpuestos += importeIva

            For Each vi As Entidades.VentaImpuesto In _subTotales
               If vi.Alicuota = alicuotaIVA And vi.TipoImpuesto.IdTipoImpuesto = _tipoImpuestoIVA Then
                  vi.TipoImpuesto.IdTipoImpuesto = _tipoImpuestoIVA

                  vi.Bruto += importeBruto
                  vi.Neto += importeNeto
                  vi.Importe += importeIva
                  vi.Total += (importeNeto + importeIva)
                  entro = True
               End If
            Next
            If Not entro Then

               oLineaImpuestos = New Entidades.VentaImpuesto()

               With oLineaImpuestos
                  .TipoImpuesto = New Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)
                  .Alicuota = alicuotaIVA
                  .Bruto = importeBruto
                  .Neto = importeNeto
                  .Importe = importeIva
                  .Total = (importeNeto + importeIva)
               End With

               _subTotales.Add(oLineaImpuestos)
            End If

         Next

         '---------------------------------------------------------------

         Comprobante = New Entidades.Venta()

         With Comprobante

            'cargo el comprobante
            .TipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)

            'cargo el cliente ----------
            .Cliente = _clienteE

            .IdCategoria = .Cliente.IdCategoria

            'cargo la direccion predeterminada.
            .Direccion = .Cliente.Direccion
            '.LocalidadCliente = .Cliente.NombreLocalidad
            '.ProvinciaCliente = .Cliente.Localidad.NombreProvincia
            .IdLocalidad = .Cliente.IdLocalidad


            'cargo datos generales del comprobante
            .IdSucursal = idSucursal
            .Usuario = actual.Nombre
            .Fecha = fecha

            ' .Vendedor = New Reglas.Empleados().GetUno(TipoDocVendedor, NroDocVendedor)
            .Vendedor = vendedor

            .FormaPago = New Reglas.VentasFormasPago().GetUna(idFormasPago)

            .IdCaja = idCaja

            .Observacion = observacion ' "Generado Automatico"

            .ImporteTotal = importeTotal

            .CategoriaFiscal = .Cliente.CategoriaFiscal

            'Si es X es Cotizacion, Dev-Cotizacion, etc, siempre debe tener esa letra, sino dejo la del Cliente.

            If .TipoComprobante.LetrasHabilitadas = "X" Then
               .LetraComprobante = "X"
            Else
               .LetraComprobante = .CategoriaFiscal.LetraFiscal
            End If

            'cargo la impresora
            .Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)
            .CentroEmisor = .Impresora.CentroEmisor
            .NumeroComprobante = New Reglas.VentasNumeros().GetProximoNumero(_cache.BuscaSucursal(.IdSucursal), .TipoComprobante.IdTipoComprobante, .LetraComprobante, .CentroEmisor)

            ''cargo datos generales del comprobante
            '.IdSucursal = actual.Sucursal.Id
            '.Usuario = actual.Nombre
            '.Fecha = Me.dtpFecha.Value

            '.Vendedor = Me._clienteGrilla.Vendedor

            '.FormaPago = New Reglas.VentasFormasPago().GetUna(3) 'Cuenta Corriente

            '.Observacion = "Generado Automatico" 'Me.txtObservacion.Text

            .VentasImpuestos = _subTotales
            '.ImpuestosVarios = _ImpuestosVarios

            'cargo valores del comprobante
            .ImporteBruto = _ImporteBruto
            .DescuentoRecargo = 0
            .DescuentoRecargoPorc = 0
            .Subtotal = _ImporteBruto
            .TotalImpuestos = _TotalImpuestos
            '.ImporteTotal = importeTotal  'Ya seteado previamente.

            '   .Kilos = Kilos

            'cargo los productos
            .VentasProductos = _ventasProductos

            'Cargo los Comprobantes Facturados (tal vez ninguno)
            '.Facturables = Me._comprobantesSeleccionados

            'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
            'If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 AndAlso .TipoComprobante.CoeficienteStock <> 0 Then
            '   .IdEstadoComprobante = "INVOCO"
            '   .CantidadInvocados = Me._comprobantesSeleccionados.Count
            'Else
            '''' .CantidadInvocados = 0
            'End If

            'cargo el Remito Transportista
            .Bultos = 0
            .ValorDeclarado = 0
            .Transportista = Nothing   ' Me._transportistaA
            .NumeroLote = 0

            'cargo las Observaciones

            If observacionDetalladas.Count > 0 Then

               Dim Cont As Integer

               'Tengo que asignar el numero de comprobante porque se genera a ultima momento.
               For Cont = 0 To observacionDetalladas.Count - 1
                  observacionDetalladas(Cont).IdSucursal = .IdSucursal
                  observacionDetalladas(Cont).IdTipoComprobante = .IdTipoComprobante
                  observacionDetalladas(Cont).Letra = .LetraComprobante
                  observacionDetalladas(Cont).CentroEmisor = .CentroEmisor
                  observacionDetalladas(Cont).NumeroComprobante = .NumeroComprobante
               Next

            End If
            .VentasObservaciones = observacionDetalladas


            'carga los importes de pagos y cheques
            '.Cheques = Me._cheques

            'Dejo en cero porque se pisa con la funcionalidad de CuentaCorriente Parcial.
            .ImportePesos = 0             '.ImporteTotal
            .ImporteDolares = 0
            '--------------------------------------------------------------
            '.ImporteTarjetas = 0
            .ImporteTickets = 0

            'carga los cheques rechazados
            '.ChequesRechazados = Me._chequesRechazados

            'Informe los Productos que tuvieron Lotes.
            .CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.

            'cargo los Lotes
            '.VentasProductosLotes = Me._productosLotes

            'Cargo la utilidad
            .Utilidad = _ImporteBruto

            .CotizacionDolar = New Eniac.Reglas.Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion

            .ComisionVendedor = 0

         End With

         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If Comprobante.TipoComprobante.ActualizaCtaCte Then

            If cuentaCorrientePago IsNot Nothing Then
               If Publicos.TieneModuloCuentaCorrienteClientes Then
                  Comprobante.CuentaCorriente.ImporteAnticipo = cuentaCorriente.ImporteAnticipo
                  Comprobante.CuentaCorriente.FechaVencimiento = cuentaCorriente.FechaVencimiento
                  For Each CuotaCtaCte As Entidades.CuentaCorrientePago In cuentaCorrientePago
                     Dim oCCP As Entidades.CuentaCorrientePago
                     oCCP = New Entidades.CuentaCorrientePago()
                     oCCP.ImporteCuota = CuotaCtaCte.ImporteCuota
                     oCCP.SaldoCuota = CuotaCtaCte.ImporteCuota
                     oCCP.FechaVencimiento = CuotaCtaCte.FechaVencimiento
                     oCCP.Cuota = CuotaCtaCte.Cuota
                     oCCP.FechaVencimiento2 = CuotaCtaCte.FechaVencimiento2
                     oCCP.ImporteCuota2 = CuotaCtaCte.ImporteCuota2
                     oCCP.FechaVencimiento3 = CuotaCtaCte.FechaVencimiento3
                     oCCP.ImporteCuota3 = CuotaCtaCte.ImporteCuota3
                     oCCP.CodigoDeBarra = CuotaCtaCte.CodigoDeBarra

                     Comprobante.CuentaCorriente.Pagos.Add(oCCP)
                  Next

               End If


            Else
               If Comprobante.FormaPago.Dias > 0 Then
                  'si el cliente compro el modulo de cuenta corriente
                  If Publicos.TieneModuloCuentaCorrienteClientes Then

                     Dim oCCP As Entidades.CuentaCorrientePago
                     oCCP = New Entidades.CuentaCorrientePago()
                     oCCP.ImporteCuota = Comprobante.ImporteTotal
                     oCCP.SaldoCuota = oCCP.ImporteCuota
                     oCCP.FechaVencimiento = Comprobante.Fecha.AddDays(Comprobante.FormaPago.Dias)
                     If cuota > 190101 Then
                        oCCP.Cuota = cuota
                     End If
                     Comprobante.CuentaCorriente.Pagos.Add(oCCP)
                  End If

               End If
            End If
         End If

         Me.Inserta(Comprobante, metodoGrabacion, idFuncion)


         'Lo asigno completo para que tenga valor en el procedimiento que lo llamo.
         cb = Me.GetUna(Comprobante.IdSucursal,
                        Comprobante.TipoComprobante.IdTipoComprobante,
                        Comprobante.LetraComprobante,
                        Comprobante.CentroEmisor,
                        Comprobante.NumeroComprobante)

         If Not blnConexionAbierta Then
            Me.da.CommitTransaction()
         End If

      Catch ex As Exception
         If Not blnConexionAbierta Then
            Me.da.RollbakTransaction()
         End If
         Throw ex
      Finally
         If Not blnConexionAbierta Then
            Me.da.CloseConection()
         End If
      End Try

      'LA SOLICITUD DE CAE LA DEBEMOS HACER FUERA DE LA TRANSACCION
      '  - SI TODO OK: SE CREA EL COMPROBANTE FINAL Y SE ELIMINA EL PRE-COMPROBANTE
      '  - SI ERROR:   DEBE QUEDAR EL PRE-COMPROBANTE PARA SOLICITAR EL CAE A TRAVES
      '                DE LA PANTALLA DE SOLICITAR CAE
      Try
         If Not blnConexionAbierta Then
            Me.da.OpenConection()
            Me.da.BeginTransaction()
         End If

         If Not solicitaCAE.HasValue Then
            solicitaCAE = Publicos.Facturacion.FacturacionElectronica.FacturacionElectronicaSincronica  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.FACTELECTSINCRONICA))
         End If

         If Comprobante IsNot Nothing AndAlso
            (solicitaCAE.Value And Comprobante.TipoComprobante.EsPreElectronico) Then

            If Not Publicos.HayInternet() Then
               Throw New Exception("No tiene internet para realizar esta acción.")
               Exit Function
            End If

            'Actualizo la Fecha de Transmision al AFIP porque Si tiene la Fecha.. no podra anularlo.

            Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
            sql.U_FechaTransmisionAFIP(Comprobante.IdSucursal, Comprobante.TipoComprobante.IdTipoComprobante,
                                                Comprobante.LetraComprobante, Comprobante.Impresora.CentroEmisor,
                                                Comprobante.NumeroComprobante, Date.Now)

            Comprobante.Usuario = actual.Nombre

            Me.ActualizaCAE(Comprobante, Entidades.AFIPCAE.Secuencia.PrimeraVez, metodoGrabacion, idFuncion)

            cb = Me.GetUna(Comprobante.IdSucursal,
                           Comprobante.TipoComprobante.IdTipoComprobante,
                           Comprobante.LetraComprobante,
                           Comprobante.CentroEmisor,
                           Comprobante.NumeroComprobante)

         End If

         If Not blnConexionAbierta Then Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         If ComprobanteAnt IsNot Nothing Then
            With ComprobanteAnt
               Comprobante.IdSucursal = ComprobanteAnt.IdSucursal
               Comprobante.TipoComprobante = ComprobanteAnt.TipoComprobante
               Comprobante.LetraComprobante = ComprobanteAnt.LetraComprobante
               Comprobante.CentroEmisor = ComprobanteAnt.CentroEmisor
               Comprobante.NumeroComprobante = ComprobanteAnt.NumeroComprobante
            End With
         End If
         If Not blnConexionAbierta Then da.RollbakTransaction()
         Throw New ActualizaCAEException(ex, Comprobante)
      Finally
         If Not blnConexionAbierta Then da.CloseConection()
      End Try

      Return cb

   End Function
#End Region

#Region "CrearComprobanteAutomatico"
   Public Function CreaVenta(idSucursal As Integer,
                             tipoComprobante As Entidades.TipoComprobante,
                             cliente As Entidades.Cliente,
                             DescuentoRecargoPorc As Decimal?,
                             observaciones As String,
                             idCaja As Integer) As Entidades.Venta
      Return CreaVenta(idSucursal:=actual.Sucursal.Id,
                       tipoComprobante:=tipoComprobante,
                       letra:=String.Empty, centroEmisor:=0, numeroComprobante:=Nothing,
                       cliente:=cliente,
                       categoriaFiscal:=Nothing,
                       fecha:=Now,
                       vendedor:=Nothing,
                       transportista:=Nothing,
                       formaPago:=Nothing,
                       descuentoRecargoPorc:=DescuentoRecargoPorc,
                       idCaja:=idCaja,
                       cotizacionDolar:=Nothing,
                       mercDespachada:=False,
                       numeroReparto:=Nothing,
                       fechaEnvio:=Nothing,
                       proveedor:=Nothing,
                       observaciones:=observaciones,
                       cobrador:=Nothing,
                       clienteVinculado:=Nothing,
                       nroOrdenCompra:=0)
   End Function

   Public Function CreaVenta(idSucursal As Integer,
                             tipoComprobante As Entidades.TipoComprobante,
                             letra As String,
                             centroEmisor As Short,
                             numeroComprobante As Long?,
                             cliente As Entidades.Cliente,
                             categoriaFiscal As Entidades.CategoriaFiscal,
                             fecha As Date,
                             vendedor As Entidades.Empleado,
                             transportista As Entidades.Transportista,
                             formaPago As Entidades.VentaFormaPago,
                             descuentoRecargoPorc As Decimal?,
                             idCaja As Integer,
                             cotizacionDolar As Decimal?,
                             mercDespachada As Boolean,
                             numeroReparto As Integer?,
                             fechaEnvio As Date?,
                             proveedor As Entidades.Proveedor,
                             observaciones As String,
                             cobrador As Entidades.Empleado,
                             clienteVinculado As Entidades.Cliente,
                             nroOrdenCompra As Long) As Entidades.Venta
      Dim venta = New Entidades.Venta()

      With venta

         'cargo el comprobante
         .TipoComprobante = tipoComprobante

         'cargo el cliente ----------
         .Cliente = cliente
         .NombreCliente = cliente.NombreCliente

         .IdCategoria = .Cliente.IdCategoria

         'cargo la direccion elegida
         .Direccion = .Cliente.Direccion
         .IdLocalidad = .Cliente.IdLocalidad

         If categoriaFiscal IsNot Nothing Then
            .CategoriaFiscal = categoriaFiscal
         Else
            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = .Cliente.CategoriaFiscal

            If Not tipoComprobante.GrabaLibro AndAlso Not tipoComprobante.EsPreElectronico AndAlso Eniac.Reglas.Publicos.Facturacion.FacturacionGrabaLibroNoFuerzaConsFinal Then
               .CategoriaFiscal = New Eniac.Reglas.CategoriasFiscales(da)._GetUno(1S)      'No deberia ser Fijo 1.
            End If
         End If

         If String.IsNullOrWhiteSpace(letra) Then
            If tipoComprobante.LetrasHabilitadas.Length = 1 Then
               .LetraComprobante = tipoComprobante.LetrasHabilitadas
            Else
               .LetraComprobante = .CategoriaFiscal.LetraFiscal
            End If
         Else
            .LetraComprobante = letra
         End If


         'cargo datos generales del comprobante
         .IdSucursal = idSucursal
         .Usuario = actual.Nombre

         'cargo la impresora
         .Impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(.IdSucursal, My.Computer.Name, .TipoComprobante.IdTipoComprobante)
         If centroEmisor = 0 Then
            .CentroEmisor = .Impresora.CentroEmisor
         Else
            .CentroEmisor = centroEmisor
         End If

         If numeroComprobante.HasValue Then
            .NumeroComprobante = numeroComprobante.Value
         Else
            .NumeroComprobante = New VentasNumeros(da).GetProximoNumero(_cache.BuscaSucursal(.IdSucursal), .TipoComprobante.IdTipoComprobante, .LetraComprobante, .CentroEmisor)
         End If

         .NumeroOrdenCompra = nroOrdenCompra

         .Fecha = fecha

         If vendedor Is Nothing Then
            .Vendedor = .Cliente.Vendedor
         Else
            .Vendedor = vendedor
         End If

         '# Siguiendo la misma lógica de vendedor, se agrega cobrador
         .Cobrador = If(cobrador IsNot Nothing, cobrador, .Cliente.Cobrador)

         'Si no me pasan la forma de pago, tomo la del cliente.
         If formaPago IsNot Nothing Then
            .FormaPago = formaPago
         ElseIf cliente.IdFormasPago > 0 Then
            .FormaPago = New Eniac.Reglas.VentasFormasPago().GetUna(cliente.IdFormasPago)
         Else
            Dim fpagos = New VentasFormasPago(da).GetTodas("VENTAS", contado:=Nothing)
            If fpagos.Count > 0 Then
               .FormaPago = fpagos(0)
            Else
               Throw New Exception(String.Format("Debe suministrar una forma de pago."))
            End If
         End If

         .Observacion = observaciones ' "Generado Automatico"

         .ValorDeclarado = 0
         .NumeroLote = 0

         If numeroReparto.HasValue Then
            .NumeroReparto = numeroReparto.Value
         End If

         If fechaEnvio.HasValue Then
            .FechaEnvio = fechaEnvio.Value
         End If

         'cargo el Remito Transportista

         .Transportista = transportista

         'Informe los Productos que tuvieron Lotes.
         '' '' '' ''.CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.
         'cargo los Lotes
         '' '' '' ''.VentasProductosLotes = Nothing 'Me._productosLotes


         'Cargo la utilidad
         If cotizacionDolar.HasValue Then
            .CotizacionDolar = cotizacionDolar.Value
         Else
            .CotizacionDolar = New Eniac.Reglas.Monedas(da).GetUna(2).FactorConversion
         End If

         If descuentoRecargoPorc.HasValue Then
            .DescuentoRecargoPorc = descuentoRecargoPorc.Value
         End If

         .ComisionVendedor = 0      'Se calcula despues al insertar

         .MercDespachada = mercDespachada

         'grabo la caja
         .IdCaja = idCaja

         .Proveedor = proveedor

         .ReemplazaComprobante = False

         'If .CategoriaFiscal.SolicitaCUIT Then
         '   .Cuit = .Cliente.Cuit
         'ElseIf Not String.IsNullOrEmpty(.Cliente.NroDocCliente.ToString) Then
         '   .TipoDocCliente = .Cliente.TipoDocCliente
         '   .NroDocCliente = .Cliente.NroDocCliente
         'End If

         '-- REQ-31373.- ---------------------------
         .Cuit = .Cliente.Cuit
         .TipoDocCliente = .Cliente.TipoDocCliente
         .NroDocCliente = .Cliente.NroDocCliente
         '------------------------------------------

         '-.PE-33055.-
         .ClienteVinculado = clienteVinculado
      End With

      Return venta
   End Function

   Public Function CreaVentaProducto(producto As Eniac.Entidades.Producto,
                                     productoDescripcion As String,
                                     descuentoRecargoPorc1 As Decimal,
                                     descuentoRecargoPorc2 As Decimal,
                                     precio As Decimal?,
                                     cantidad As Decimal,
                                     tipoImpuesto As Eniac.Entidades.TipoImpuesto,
                                     porcentajeIva As Decimal?,
                                     listaDePrecios As Eniac.Entidades.ListaDePrecios,
                                     fechaEntrega As Date?,
                                     tipoOperacion As Entidades.Producto.TiposOperaciones,
                                     nota As String,
                                     idEstadoVenta As Integer?,
                                     venta As Eniac.Entidades.Venta,
                                     redondeoEnCalculo As Integer) As Eniac.Entidades.VentaProducto
      Dim blnAbreConeccion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConeccion Then da.OpenConection()

      Try
         If Not venta.TipoComprobante.UtilizaImpuestos Then
            porcentajeIva = 0
         End If

         Dim usaPrecioSinIVA As Boolean = (venta.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                                          Not venta.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos

         If tipoOperacion <> Entidades.Producto.TiposOperaciones.NORMAL Then
            precio = 0
         End If

         Dim utilizaAlicuota2 As Boolean = Publicos.ProductoUtilizaAlicuota2 AndAlso venta.CategoriaFiscal.ResuelveUtilizaAlicuota2Producto(venta.Cliente) AndAlso producto.Alicuota2.HasValue
         Dim porcentajeIvaProducto = producto.Alicuota
         If utilizaAlicuota2 Then
            porcentajeIvaProducto = producto.Alicuota2.Value
         End If

         If Not precio.HasValue Then
            Dim precios As PreciosConSinIVA = GetPrecio(venta.TipoComprobante,
                                                        producto,
                                                        listaDePrecios,
                                                        venta.Cliente,
                                                        venta.CotizacionDolar,
                                                        redondeoEnCalculo)
            If usaPrecioSinIVA Then
               precio = precios.PrecioVentaSinIVA
            Else
               'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
               precio = precios.PrecioVentaConIVA

               If utilizaAlicuota2 Then
                  precio = precios.PrecioVentaConIVA2.Value
               End If
            End If

            'Si usa el precio con IVA y el IVA que se pasó al proceso es diferente al del producto, recalculo el precio con el nuevo IVA
            If Not usaPrecioSinIVA AndAlso porcentajeIva.HasValue AndAlso porcentajeIva.Value <> porcentajeIvaProducto Then
               'Le saco el IVA del producto
               precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precio.Value, porcentajeIvaProducto, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
               If venta.TipoComprobante.UtilizaImpuestos Then
                  ' Le pongo el nuevo IVA con los ImpInt
                  precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precio.Value, porcentajeIva.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
               Else
                  ' Le pongo el nuevo IVA sin los ImpInt (Comp UtilizaImpuestos = False)
                  precio = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(precio.Value, porcentajeIva.Value, 0, 0, Entidades.OrigenesPorcImpInt.BRUTO)
               End If
            End If
         End If

         Dim ventaProducto As Eniac.Entidades.VentaProducto = New Eniac.Entidades.VentaProducto()
         Dim proSuc As Eniac.Entidades.ProductoSucursal
         proSuc = New Eniac.Reglas.ProductosSucursales(da).GetUno(venta.IdSucursal,
                                                                  producto.IdProducto,
                                                                  listaDePrecios.IdListaPrecios)

         Dim kilos As Decimal = 0
         'If producto.UnidadDeMedida IsNot Nothing Then
         '   kilos = Decimal.Round(cantidad * producto.Tamano, 3)
         'End If

         If (producto.PermiteModificarDescripcion) And Publicos.Facturacion.FacturacionModificaDescripSolicitaKilos Then
            ' Necesitamos agregar un parámetro y corregir todos los llamados antes de implementar esto
            'kilos = Decimal.Parse(Me.txtKilosModDesc.Text.ToString())
         Else
            kilos = producto.Kilos
         End If

         kilos = Decimal.Round(cantidad * kilos, 3)

         If Not porcentajeIva.HasValue Then
            porcentajeIva = porcentajeIvaProducto
         End If

         Dim precioProducto As Decimal

         If (venta.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Then
            precioProducto = precio.Value
         Else
            If venta.TipoComprobante.GrabaLibro Or venta.TipoComprobante.EsPreElectronico Or Publicos.Facturacion.FacturacionDescuentoImpIntIgualado Then
               precioProducto = precio.Value - (producto.ImporteImpuestoInterno)
            Else
               precioProducto = precio.Value
            End If
         End If

         Dim impuestoInternoTotalLinea As Decimal = 0 ' producto.ImporteImpuestoInterno * cantidad
         If Not venta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            impuestoInternoTotalLinea = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoConIVA(precio.Value, porcentajeIva.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
            impuestoInternoTotalLinea *= cantidad
         Else
            impuestoInternoTotalLinea = Reglas.CalculosImpositivos.CalcularImpuestoInternoDesdeNetoSinIVA(precio.Value, porcentajeIva.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
            impuestoInternoTotalLinea *= cantidad
         End If

         Dim precioLista As Decimal = proSuc.PrecioVentaLista
         Dim precioListaSinIVA As Decimal
         Dim precioListaConIVA As Decimal
         Dim precioCosto As Decimal = proSuc.PrecioCosto
         Dim precioCostoSinIVA As Decimal
         Dim precioCostoConIVA As Decimal

         If Publicos.PreciosConIVA Then
            precioListaConIVA = precioLista
            precioListaSinIVA = CalculosImpositivos.ObtenerPrecioSinImpuestos(precioListaConIVA, producto)
            precioCostoConIVA = precioCosto
            precioCostoSinIVA = CalculosImpositivos.ObtenerPrecioSinImpuestos(precioCostoConIVA, producto)
         Else
            precioListaSinIVA = precioLista
            precioListaConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(precioListaSinIVA, producto)
            precioCostoSinIVA = precioCosto
            precioCostoConIVA = CalculosImpositivos.ObtenerPrecioSinImpuestos(precioCostoSinIVA, producto)
         End If
         If producto.Moneda.IdMoneda = 2 Then
            precioListaConIVA = Decimal.Round(precioListaConIVA * venta.CotizacionDolar, redondeoEnCalculo)
            precioListaSinIVA = Decimal.Round(precioListaSinIVA * venta.CotizacionDolar, redondeoEnCalculo)
            precioCostoSinIVA = Decimal.Round(precioCostoSinIVA * venta.CotizacionDolar, redondeoEnCalculo)
            precioCostoConIVA = Decimal.Round(precioCostoConIVA * venta.CotizacionDolar, redondeoEnCalculo)
         End If

         If (venta.CategoriaFiscal.IvaDiscriminado And Me._categoriaFiscalEmpresa.IvaDiscriminado) Or
             Not venta.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Then
            precioLista = precioListaSinIVA
            precioCosto = precioCostoSinIVA
         Else
            precioLista = precioListaSinIVA    'precioListaConIVA
            precioCosto = precioCostoSinIVA
         End If

         Dim descRec1 As Decimal = Decimal.Round(precioProducto * descuentoRecargoPorc1 / 100, redondeoEnCalculo)
         Dim descRec2 As Decimal = Decimal.Round((precioProducto + descRec1) * descuentoRecargoPorc2 / 100, redondeoEnCalculo)
         Dim descRecG As Decimal = Decimal.Round((precioProducto + descRec1 + descRec2) * venta.DescuentoRecargoPorc / 100, redondeoEnCalculo)

         Dim precioNeto As Decimal = precio.Value + descRec1 + descRec2 + descRecG
         Dim importeIVA As Decimal

         impuestoInternoTotalLinea = impuestoInternoTotalLinea * (1 + (descuentoRecargoPorc1 / 100))
         impuestoInternoTotalLinea = impuestoInternoTotalLinea * (1 + (descuentoRecargoPorc2 / 100))
         impuestoInternoTotalLinea = impuestoInternoTotalLinea * (1 + (venta.DescuentoRecargoPorc / 100))

         If Not venta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            importeIVA = Decimal.Round(((precioNeto * cantidad) - impuestoInternoTotalLinea) - ((precioNeto * cantidad) - impuestoInternoTotalLinea) / (1 + porcentajeIva.Value / 100), redondeoEnCalculo)
         Else
            importeIVA = Decimal.Round((precioNeto * cantidad) * porcentajeIva.Value / 100, redondeoEnCalculo)
         End If

         With ventaProducto
            .IdSucursal = venta.IdSucursal ' actual.Sucursal.Id
            .Usuario = actual.Nombre
            .Producto = producto.Clonar(producto)
            If producto.PermiteModificarDescripcion Then
               .Producto.NombreProducto = productoDescripcion   'Piso la descripcion si tiene habilitado la posibilidad de cambiarlas.
            End If
            .DescuentoRecargoPorc1 = descuentoRecargoPorc1
            .DescuentoRecargoPorc2 = descuentoRecargoPorc2
            .DescuentoRecargo = (descRec1 + descRec2) * cantidad
            .DescuentoRecargoProducto = (descRec1 + descRec2)
            .Precio = precio.Value
            .Cantidad = cantidad
            .CantidadManual = cantidad
            .IdUnidadDeMedida = producto.UnidadDeMedida.IdUnidadDeMedida
            .Conversion = 1
            .ImporteTotal = (precio.Value + descRec1 + descRec2) * cantidad
            .ImporteImpuesto = importeIVA
            .AlicuotaImpuesto = porcentajeIva.Value
            .TipoImpuesto = tipoImpuesto

            .Stock = proSuc.Stock
            .Costo = precioCosto
            'If Not _categoriaFiscalEmpresa.IvaDiscriminado Or Not venta.Cliente.CategoriaFiscal.IvaDiscriminado Then
            '   .Costo = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(.Costo, .AlicuotaImpuesto,
            '                                                                 .PorcImpuestoInterno, .Producto.ImporteImpuestoInterno,
            '                                                                 .OrigenPorcImpInt)
            'End If
            .PrecioLista = precioLista ' proSuc.GetPrecioVentaDeLista(Publicos.ListaPreciosPredeterminada)
            .Kilos = kilos
            .PrecioNeto = precioNeto
            .ImporteImpuestoInterno = impuestoInternoTotalLinea
            .PorcImpuestoInterno = producto.PorcImpuestoInterno
            .OrigenPorcImpInt = producto.OrigenPorcImpInt
            .ImporteTotalNeto = .PrecioNeto * cantidad
            .ComisionVendedorPorc = 0
            .ComisionVendedor = 0
            .ModificoPrecioManualmente = True
            If fechaEntrega.HasValue Then
               .FechaEntrega = fechaEntrega.Value
            End If
            .IdListaPrecios = listaDePrecios.IdListaPrecios
            .NombreListaPrecios = listaDePrecios.NombreListaPrecios
            .NombreCortoListaPrecios = listaDePrecios.NombreCortoListaPrecios
            .FechaActualizacion = Now
            .TipoOperacion = tipoOperacion
            .Nota = nota
            .IdEstadoVenta = idEstadoVenta

            .Moneda = _cache.BuscaMoneda(1)       'Por el momento no se permite generar en automático comprobantes en otras monedas
         End With

         Return ventaProducto
      Finally
         If blnAbreConeccion Then da.CloseConection()
      End Try

   End Function

   Public Sub AgregarVentaObservacion(venta As Eniac.Entidades.Venta, observaciones As IEnumerable(Of Entidades.VentaObservacion))
      For Each obs In observaciones
         AgregarVentaObservacion(venta, obs.Observacion)
      Next
   End Sub

   Public Sub AgregarVentaObservacion(venta As Eniac.Entidades.Venta, observacion As String)
      Dim obs As Eniac.Entidades.VentaObservacion = New Eniac.Entidades.VentaObservacion()
      Dim tipObs = New Entidades.TipoObservacion()
      With obs
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Observacion = observacion

         tipObs = New Reglas.TiposObservaciones().GetUno(New Reglas.TiposObservaciones().GetIdTipoObservacionDefecto())
         .IdTipoObservacion = tipObs.IdObservaciones
         .DescripcionTipoObservacion = tipObs.Descripcion

         venta.VentasObservaciones.Add(obs)
         obs.Linea = venta.VentasObservaciones.Count
      End With
   End Sub

   Public Overridable Function AgregarVentaProducto(venta As Entidades.Venta, ventaProducto As Entidades.VentaProducto, redondeoEnCalculo As Integer) As Entidades.VentaProducto
      ventaProducto.Orden = venta.VentasProductos.Count + 1

      venta.VentasProductos.Add(ventaProducto)

      RecalculaTotales(venta, redondeoEnCalculo)

      Return ventaProducto
   End Function

   Public Sub AgregarVentaContactos(venta As Eniac.Entidades.Venta, contactos As IEnumerable(Of Entidades.VentaClienteContacto))
      For Each vc In contactos
         AgregarVentaContactos(venta, vc.Contacto)
      Next
   End Sub

   Public Sub AgregarVentaContactos(venta As Eniac.Entidades.Venta, contacto As Entidades.ClienteContacto)
      venta.VentasContactos.Add(New Entidades.VentaClienteContacto(contacto))
   End Sub

   Private Sub RecalculaTotales(venta As Entidades.Venta, redondeoEnCalculo As Integer)
      Dim bruto As Decimal = 0
      Dim neto As Decimal = 0
      Dim iva As Decimal = 0
      Dim impint As Decimal = 0
      Dim total As Decimal = 0
      Dim utilidad As Decimal = 0

      venta.VentasImpuestos.Clear()
      venta.Bultos = 0
      For Each vp As Eniac.Entidades.VentaProducto In venta.VentasProductos
         Dim vpBruto As Decimal = 0
         Dim vpNeto As Decimal = 0
         Dim vpIva As Decimal = 0
         Dim vpImpInt As Decimal = 0
         Dim vpTotal As Decimal = 0

         ''Dim impuestoInterno As Decimal = vp.ImporteImpuestoInterno * vp.Cantidad

         If Not venta.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            'vpBruto = Math.Round(((vp.ImporteTotal - vp.ImporteImpuestoInterno) / ((100 + vp.AlicuotaImpuesto) / 100)), redondeoEnCalculo)
            vpBruto = Math.Round(CalculosImpositivos.ObtenerPrecioSinImpuestos(vp.ImporteTotal, vp.AlicuotaImpuesto, vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.OrigenPorcImpInt), redondeoEnCalculo)
            vpNeto = Math.Round(((vp.ImporteTotalNeto - vp.ImporteImpuestoInterno) / ((100 + vp.AlicuotaImpuesto) / 100)), redondeoEnCalculo)
            vpIva = vp.ImporteImpuesto
            vpImpInt = vp.ImporteImpuestoInterno

            vpTotal = vp.ImporteTotalNeto '+ vp.ImporteImpuestoInterno
         Else
            vpBruto = vp.ImporteTotal
            vpNeto = vp.ImporteTotalNeto
            vpIva = vp.ImporteImpuesto
            vpImpInt = vp.ImporteImpuestoInterno

            vpTotal = vp.ImporteTotalNeto + vp.ImporteImpuesto + vp.ImporteImpuestoInterno
         End If

         vp.DescRecGeneralProducto = vp.PrecioNeto - (vp.PrecioNeto / (1 + (venta.DescuentoRecargoPorc / 100)))
         vp.DescRecGeneral = vp.DescRecGeneralProducto * vp.Cantidad
         'vp.PrecioNeto += vp.DescRecGeneralProducto

         bruto += vpBruto
         neto += vpNeto
         iva += vpIva
         impint += vpImpInt

         total += vpTotal

         AgregarVentaImpuesto(venta, vp.TipoImpuesto, vp.AlicuotaImpuesto, vpBruto, vpNeto, vpIva, redondeoEnCalculo)
         If vpImpInt <> 0 Then
            AgregarVentaImpuesto(venta, Eniac.Entidades.TipoImpuesto.Tipos.IMINT, 0, 0, 0, vpImpInt, redondeoEnCalculo)
         End If

         venta.Kilos += vp.Kilos


         If Publicos.Facturacion.FacturacionRemitoTranspCalculaBultos Then
            If vp.Producto.AfectaStock Then
               If vp.Producto.Embalaje > 0 Then
                  If Not Eniac.Reglas.Publicos.ProductoEmbalajeHaciaArriba Then
                     venta.Bultos = Decimal.ToInt32(Math.Truncate(venta.Bultos + vp.Cantidad))
                  Else
                     venta.Bultos = Decimal.ToInt32(Math.Truncate(venta.Bultos + Decimal.Round((vp.Cantidad / Decimal.Parse(vp.Producto.Embalaje.ToString())), 0)))
                  End If
               Else
                  venta.Bultos = 0
               End If
            End If
         End If

         Dim precio As Decimal = vp.PrecioNeto
         If Not _categoriaFiscalEmpresa.IvaDiscriminado Or Not venta.CategoriaFiscal.IvaDiscriminado Then
            precio = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(vp.PrecioNeto, vp.AlicuotaImpuesto,
                                                                          vp.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno,
                                                                          vp.OrigenPorcImpInt)
         End If

         utilidad += ((precio - vp.Costo) * vp.Cantidad)
      Next

      venta.ImporteBruto = bruto
      venta.DescuentoRecargo = neto - bruto
      venta.Subtotal = neto
      venta.TotalImpuestos = iva
      ''venta.TotalImpuestoInterno = impint ' ES CALCULADO
      venta.ImporteTotal = total

      If venta.TipoComprobante.EsRemitoTransportista Then
         venta.ValorDeclarado = venta.Subtotal
      End If
      venta.Utilidad = utilidad

      CalculaPercepciones(venta, redondeoEnCalculo)

      If Not Reglas.Publicos.CtaCte.UtilizaCuotasVencimientoCtaCteClientes Then
         Dim oCCP As Entidades.CuentaCorrientePago
         If venta.CuentaCorriente.Pagos.Count = 0 Then
            oCCP = New Entidades.CuentaCorrientePago()
            venta.CuentaCorriente.Pagos.Add(oCCP)
         Else
            oCCP = venta.CuentaCorriente.Pagos(0)
         End If
         oCCP.ImporteCuota = venta.ImporteTotal
         oCCP.SaldoCuota = oCCP.ImporteCuota
         oCCP.FechaVencimiento = venta.Fecha.AddDays(venta.FormaPago.Dias)
      End If
   End Sub

   Private Sub CalculaPercepciones(venta As Entidades.Venta, redondeoEnCalculo As Integer)
      '''''''''''''''''''''''PERCEPCIONES
      Dim entPercIIBB = New List(Of Entidades.PercepcionVentaCalculo)()

      ''IIBB - Calcula la percepción de ingresos brutos del cliente
      ''solo se calcula si el cliente tiene una actividad
      ''EsComercial=True deja afuera las NDEBCHEQRECH

      Dim baseImponibleIIBB = 0D
      Dim PercepcionIIBB = 0D


      Dim fc = New FacturacionComunes()
      If venta.CategoriaFiscal.EsPasiblePercIIBB Then
         Using _dtActividades = New ClientesActividades().GetClientesActividades(venta.Cliente.IdCliente,
                                                                                 venta.Localidad.IdProvincia,
                                                                                 venta.CategoriaFiscal.IdCategoriaFiscal)
            If _dtActividades.Rows.Count > 0 Then
               If ((venta.TipoComprobante.GrabaLibro And venta.TipoComprobante.EsComercial) Or venta.TipoComprobante.EsPreElectronico) Then
                  entPercIIBB = GetMontoPercepcionIIBB(venta.Cliente,
                                                       _dtActividades,
                                                       venta.Subtotal,
                                                       venta.ImporteTotal,
                                                       venta.Fecha)
                  If entPercIIBB IsNot Nothing Then
                     PercepcionIIBB = 0
                     For Each perc As Entidades.PercepcionVentaCalculo In entPercIIBB
                        'Esta corrección se aplicó en FacturacionV2. De ser necesaria en este proceso descomentar.
                        PercepcionIIBB += Math.Round(perc.Monto, 2)
                        baseImponibleIIBB = perc.BaseImponible
                     Next
                  End If
               End If
            End If
         End Using
      End If   'If Publicos.RetieneIIBB Then

      Dim entPercIVA = fc.CalculaPercepcionesIVA(venta.Cliente, venta.TipoComprobante, _categoriaFiscalEmpresa, venta.VentasProductos, venta.Invocados)

      'TODO: 5329/2023
      fc.CargarRetenciones(entPercIVA, entPercIIBB, 0, 0)
      venta.ImpuestosVarios = fc.ImpuestosVarios
      venta.ImporteTotal += PercepcionIIBB + entPercIVA.SumSecure(Function(p) p.Monto).IfNull()
      venta.TotalImpuestos += PercepcionIIBB + entPercIVA.SumSecure(Function(p) p.Monto).IfNull()
      '''''''''''''''''''''''PERCEPCIONES
   End Sub

   Public Overridable Sub AgregarVentaImpuesto(venta As Eniac.Entidades.Venta,
                                               idTipoImpuesto As Eniac.Entidades.TipoImpuesto.Tipos,
                                               alicuota As Decimal,
                                               bruto As Decimal,
                                               neto As Decimal,
                                               importeIva As Decimal,
                                               redondeoEnCalculo As Integer)
      AgregarVentaImpuesto(venta, New Eniac.Reglas.TiposImpuestos(da).GetUno(idTipoImpuesto), alicuota, bruto, neto, importeIva, redondeoEnCalculo)
   End Sub

   Public Overridable Sub AgregarVentaImpuesto(venta As Eniac.Entidades.Venta,
                                               tipoImpuesto As Eniac.Entidades.TipoImpuesto,
                                               alicuota As Decimal,
                                               bruto As Decimal,
                                               neto As Decimal,
                                               importeIva As Decimal,
                                               redondeoEnCalculo As Integer)
      Dim vi As Entidades.VentaImpuesto = Nothing
      For Each vit In venta.VentasImpuestos
         If vit.IdTipoImpuesto.Equals(tipoImpuesto.IdTipoImpuesto) AndAlso vit.Alicuota.Equals(alicuota) Then
            vi = vit
            Exit For
         End If
      Next

      If vi Is Nothing Then
         vi = New Eniac.Entidades.VentaImpuesto()
         vi.TipoImpuesto = tipoImpuesto
         vi.Alicuota = alicuota
         venta.VentasImpuestos.Add(vi)
      End If

      vi.Bruto += bruto
      vi.Neto += neto
      vi.Importe += importeIva
      vi.Total += neto + importeIva
   End Sub

   Public Sub AgregarFacturable(venta As Entidades.Venta, facturable As Entidades.Pedido)
      Dim ventaPedido = New Entidades.Venta()
      ventaPedido.IdSucursal = facturable.IdSucursal
      ventaPedido.TipoComprobante = facturable.TipoComprobante
      ventaPedido.LetraComprobante = facturable.LetraComprobante
      ventaPedido.CentroEmisor = facturable.CentroEmisor
      ventaPedido.NumeroComprobante = facturable.NumeroPedido
      ventaPedido.Fecha = facturable.Fecha

      AgregarInvocado(venta, ventaPedido)
   End Sub

   Public Sub AgregarFacturable(venta As Entidades.Venta, facturables As IEnumerable(Of Entidades.Venta))
      For Each vf As Entidades.Venta In facturables
         AgregarInvocado(venta, vf)
      Next
   End Sub

   Public Sub AgregarPagos(venta As Entidades.Venta,
                           importePesos As Decimal,
                           importeDolares As Decimal,
                           importeTransferencia As Decimal,
                           cuentaBancaria As Entidades.CuentaBancaria,
                           fechaTransferencia As Date?,
                           importeTickets As Decimal,
                           cuponesTarjetas As List(Of Entidades.VentaTarjeta),
                           cheques As List(Of Entidades.Cheque),
                           aplicarSaldoCtaCte As Boolean)
      venta.ImportePesos = importePesos
      venta.ImporteDolares = importeDolares

      venta.ImporteTransfBancaria = importeTransferencia
      venta.CuentaBancariaTransfBanc = cuentaBancaria
      venta.FechaTransferencia = fechaTransferencia

      venta.ImporteTickets = importeTickets

      venta.Tarjetas.AddRange(cuponesTarjetas)
      venta.Cheques.AddRange(cheques)

      venta.AplicarSaldoCtaCte = aplicarSaldoCtaCte

   End Sub

   Public Sub AgregarInvocado(venta As Entidades.Venta, invocados As IEnumerable(Of Entidades.VentaInvocado))
      invocados.All(Function(vf)
                       AgregarInvocado(venta, vf.Invocado)
                       Return True
                    End Function)
   End Sub
   Public Sub AgregarInvocado(venta As Entidades.Venta, invocado As Entidades.IVentaInvocada)
      venta.Invocados.Add(invocado)

      If venta.TipoComprobante.GeneraObservConInvocados Then
         AgregarVentaObservacion(venta, String.Format("Invoco: {0} ´{1}´ {2:0000}:{3:00000000}. Emision: {4:dd/MM/yyyy}.",
                                                      invocado.DescripcionTipoComprobante,
                                                      invocado.Letra,
                                                      invocado.CentroEmisor,
                                                      invocado.NumeroComprobante,
                                                      invocado.Fecha))
      End If

      'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
      If venta.Invocados.Count > 0 AndAlso venta.TipoComprobante.CoeficienteStock <> 0 AndAlso invocado.TipoTipoComprobante <> "PEDIDOSCLIE" Then
         venta.IdEstadoComprobante = "INVOCO"
         ''''venta.CantidadInvocados = venta.Facturables.Count
      End If

   End Sub

   'INVMUL:
   <Obsolete("INVMUL: Reemplazar por AgregarInvocado", True)>
   Public Sub AgregarFacturable(venta As Entidades.Venta, facturable As Entidades.Venta)
      AgregarInvocado(venta, facturable)
      'venta.Facturables.Add(facturable)

      'If venta.TipoComprobante.GeneraObservConInvocados Then
      '   AgregarVentaObservacion(venta, String.Format("Invoco: {0} ´{1}´ {2:0000}:{3:00000000}. Emision: {4:dd/MM/yyyy}.",
      '                                                facturable.TipoComprobante.Descripcion,
      '                                                facturable.LetraComprobante,
      '                                                facturable.CentroEmisor,
      '                                                facturable.NumeroComprobante,
      '                                                facturable.Fecha))
      'End If

      ''Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
      'If venta.Facturables.Count > 0 AndAlso venta.TipoComprobante.CoeficienteStock <> 0 AndAlso facturable.TipoComprobante.Tipo <> "PEDIDOSCLIE" Then
      '   venta.IdEstadoComprobante = "INVOCO"
      '   ''''venta.CantidadInvocados = venta.Facturables.Count
      'End If

   End Sub
#End Region

#Region "Copiar/Reemplazar Comprobante"
   Public Function CopiarReemplazarComprobante(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Short,
                                            numeroComprobante As Long,
                                            nuevoTipoComprobante As Entidades.TipoComprobante,
                                            idCaja As Integer,
                                            eliminarComprobanteOrigen As Boolean,
                                            esFiscal As Boolean,
                                            nuevoNumeroComprobante As Long,
                                            metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                            idFuncion As String,
                                            nuevaFecha As Date,
                                            copiaFacturables As Boolean,
                                            solicitarCAE As Boolean,
                                            idSucursalNuevo As Integer) As Entidades.Venta
      Dim nuevo As CopiarReemplazarComprobanteResult
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         nuevo = _CopiarReemplazarComprobante(idSucursal,
                                              idTipoComprobante,
                                              letra,
                                              centroEmisor,
                                              numeroComprobante,
                                              nuevoTipoComprobante,
                                              idCaja,
                                              eliminarComprobanteOrigen,
                                              esFiscal,
                                              nuevoNumeroComprobante,
                                              metodoGrabacion,
                                              idFuncion,
                                              nuevaFecha,
                                              copiaFacturables,
                                              idSucursalNuevo)

         'Throw New Exception("CORTE PARA PRUEBAS")

         Me.da.CommitTransaction()
      Catch
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

      If solicitarCAE Then
         'LA SOLICITUD DE CAE LA DEBEMOS HACER FUERA DE LA TRANSACCION
         '  - SI TODO OK: SE CREA EL COMPROBANTE FINAL Y SE ELIMINA EL PRE-COMPROBANTE
         '  - SI ERROR:   DEBE QUEDAR EL PRE-COMPROBANTE PARA SOLICITAR EL CAE A TRAVES
         '                DE LA PANTALLA DE SOLICITAR CAE
         Try
            Me.da.OpenConection()
            Me.da.BeginTransaction()

            If nuevo.ComprobanteNuevo.TipoComprobante.EsPreElectronico Then

               Dim oVentasAnterior = nuevo.ComprobanteNuevo

               nuevo.ComprobanteNuevo = GetUna(nuevo.ComprobanteNuevo.IdSucursal, nuevo.ComprobanteNuevo.IdTipoComprobante, nuevo.ComprobanteNuevo.LetraComprobante, nuevo.ComprobanteNuevo.CentroEmisor, nuevo.ComprobanteNuevo.NumeroComprobante)

               nuevo.ComprobanteNuevo.Usuario = actual.Nombre
               nuevo.ComprobanteNuevo.IdCaja = oVentasAnterior.IdCaja
               nuevo.ComprobanteNuevo.Fecha = oVentasAnterior.Fecha


               If Not Publicos.HayInternet() Then
                  Throw New Exception("No tiene internet para realizar esta acción.")
                  Exit Function
               End If

               'Actualizo la Fecha de Transmision al AFIP porque Si tiene la Fecha.. no podra anularlo.

               Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
               sql.U_FechaTransmisionAFIP(nuevo.ComprobanteNuevo.IdSucursal, nuevo.ComprobanteNuevo.TipoComprobante.IdTipoComprobante,
                                                   nuevo.ComprobanteNuevo.LetraComprobante, nuevo.ComprobanteNuevo.Impresora.CentroEmisor,
                                                   nuevo.ComprobanteNuevo.NumeroComprobante, Date.Now)

               Me.ActualizaCAE(nuevo.ComprobanteNuevo, Entidades.AFIPCAE.Secuencia.PrimeraVez, metodoGrabacion, idFuncion)

               oVentasAnterior.TipoComprobante = nuevo.ComprobanteNuevo.TipoComprobante
               oVentasAnterior.LetraComprobante = nuevo.ComprobanteNuevo.LetraComprobante
               oVentasAnterior.CentroEmisor = nuevo.ComprobanteNuevo.CentroEmisor
               oVentasAnterior.NumeroComprobante = nuevo.ComprobanteNuevo.NumeroComprobante
            End If

            Me.da.CommitTransaction()

         Catch ex As Exception
            Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
            If ComprobanteAnt IsNot Nothing Then
               With ComprobanteAnt
                  nuevo.ComprobanteNuevo.IdSucursal = ComprobanteAnt.IdSucursal
                  nuevo.ComprobanteNuevo.TipoComprobante = ComprobanteAnt.TipoComprobante
                  nuevo.ComprobanteNuevo.LetraComprobante = ComprobanteAnt.LetraComprobante
                  nuevo.ComprobanteNuevo.CentroEmisor = ComprobanteAnt.CentroEmisor
                  nuevo.ComprobanteNuevo.NumeroComprobante = ComprobanteAnt.NumeroComprobante
               End With
            End If
            da.RollbakTransaction()
            Throw New ActualizaCAEException(ex, nuevo.ComprobanteNuevo)
         Finally
            da.CloseConection()
         End Try
      End If               'If solicitarCAE Then

      If Not nuevo.ComprobanteNuevo.TipoComprobante.EsPreElectronico AndAlso nuevo.Recibos IsNot Nothing AndAlso nuevo.Recibos.Count > 0 Then
         Try
            da.OpenConection()
            da.BeginTransaction()

            Dim rCtaCteRecibo As New Reglas.CtaCteClienteRecibo()
            Dim rCuentasCorrientes As New Eniac.Reglas.CuentasCorrientes(da)
            Dim recibo As Entidades.CuentaCorriente

            Dim tipoRecibo As Entidades.TipoComprobante
            tipoRecibo = New Reglas.TiposComprobantes(da)._GetTipoComprobanteRecibo(nuevo.ComprobanteNuevo.IdTipoComprobante, 0, Base.AccionesSiNoExisteRegistro.Nulo)

            If tipoRecibo Is Nothing Then
               Throw New ApplicationException(String.Format("El tipo de comprobante {0} no tiene tiene asociado una minuta. No se pudo aplicar el recibo al comprobante.",
                                                            nuevo.ComprobanteNuevo.IdTipoComprobante))
            End If

            'recibo.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(nuevo.Recibos.Values(0).TipoComprobante.IdTipoComprobanteSecundario)


            recibo = rCtaCteRecibo.GetCtaCteCliente(tipoRecibo.IdTipoComprobante, tipoRecibo.LetrasHabilitadas, numeroComprobante:=0,
                                                    nuevo.ComprobanteNuevo.Fecha,
                                                    nuevo.Recibos.Values(0).FormaPago.IdFormasPago,
                                                    nuevo.ComprobanteNuevo.Cliente,
                                                    nuevo.ComprobanteNuevo.Cliente.Vendedor,
                                                    nuevo.Recibos.Values(0).Cobrador,
                                                    observaciones:="", importeTotal:=0, importeEfectivo:=0, importeDolares:=0, importeTarjetas:=0, importeTransferencia:=0,
                                                    idCuentaBancaria:=0,
                                                    nuevo.Recibos.Values(0).CajaDetalle.IdCaja,
                                                    pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                    da,
                                                    nroOrdenCompra:=0)

            For Each keyValue As KeyValuePair(Of Integer, Entidades.CuentaCorriente) In nuevo.Recibos
               recibo.Pagos.AddRange(rCuentasCorrientes.GetPagosDeCliente(recibo.TipoComprobante,
                                                                          recibo.IdSucursal,
                                                                          recibo.Cliente.IdCliente,
                                                                          keyValue.Value.ImporteTotal,
                                                                          Nothing,
                                                                          "ANTICIPO",
                                                                          keyValue.Value.Letra,
                                                                          keyValue.Value.CentroEmisor,
                                                                          keyValue.Value.NumeroComprobante,
                                                                          1,
                                                                          soloCuotaIndicada:=False))
               Dim Cuota As Integer = keyValue.Key
               If idFuncion = "FichasABM2" Then
                  Cuota = Cuota - 1
               End If
               recibo.Pagos.AddRange(rCuentasCorrientes.GetPagosDeCliente(recibo.TipoComprobante,
                                                                          recibo.IdSucursal,
                                                                          recibo.Cliente.IdCliente,
                                                                          keyValue.Value.ImporteTotal,
                                                                          Nothing,
                                                                          nuevo.ComprobanteNuevo.IdTipoComprobante,
                                                                          nuevo.ComprobanteNuevo.LetraComprobante,
                                                                          nuevo.ComprobanteNuevo.CentroEmisor,
                                                                          nuevo.ComprobanteNuevo.NumeroComprobante,
                                                                          Cuota,
                                                                          soloCuotaIndicada:=False))
            Next

            rCuentasCorrientes.Inserta(recibo, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

            da.CommitTransaction()
         Catch
            da.RollbakTransaction()
            Throw
         Finally
            da.CloseConection()
         End Try
      End If               'If nuevo.Recibos IsNot Nothing AndAlso nuevo.Recibos.Count > 0 Then

      Return nuevo.ComprobanteNuevo

   End Function
   Friend Function _CopiarReemplazarComprobante(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                numeroComprobante As Long,
                                                nuevoTipoComprobante As Entidades.TipoComprobante,
                                                idCaja As Integer,
                                                eliminarComprobanteOrigen As Boolean,
                                                esFiscal As Boolean,
                                                nuevoNumeroComprobante As Long,
                                                metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                                idFuncion As String,
                                                nuevaFecha As Date,
                                                copiaFacturables As Boolean,
                                                idSucursalNuevo As Integer) As CopiarReemplazarComprobanteResult
      Dim comprobante = GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
      Return _CopiarReemplazarComprobante(comprobante,
                                          nuevoTipoComprobante,
                                          idCaja,
                                          eliminarComprobanteOrigen,
                                          esFiscal,
                                          nuevoNumeroComprobante,
                                          metodoGrabacion,
                                          idFuncion,
                                          nuevaFecha,
                                          copiaFacturables,
                                          idSucursalNuevo)
   End Function

   Friend Function _CopiarReemplazarComprobante(comprobante As Entidades.Venta,
                                                nuevoTipoComprobante As Entidades.TipoComprobante,
                                                idCaja As Integer,
                                                eliminarComprobanteOrigen As Boolean,
                                                esFiscal As Boolean,
                                                nuevoNumeroComprobante As Long,
                                                metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                                idFuncion As String,
                                                nuevaFecha As Date,
                                                copiaFacturables As Boolean,
                                                idSucursalNuevo As Integer) As CopiarReemplazarComprobanteResult

      Dim categoriaFiscalEmpresa = New CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim TipoComprobanteAnterior = comprobante.TipoComprobante

      'Dim comprobante As Entidades.Venta
      Dim reaplicaRecibos As Boolean = False
      If eliminarComprobanteOrigen And Publicos.ReemplazarComprobanteReaplicaRecibos Then
         reaplicaRecibos = True
      End If

      'obtener un comprobante desde el que seleccione en la grilla
      'comprobante = Me.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
      '-- REQ-31369.- - Guardo Categoria Fiscal Vieja.- --
      Dim CatFiscalOld = comprobante.CategoriaFiscal.IdCategoriaFiscal

      Dim comprobanteAnt = comprobante.PKComprobante()


      '# Obtengo el coeValAnterior del comprobante de ORIGEN
      Dim coeValAnterior As Integer = comprobante.TipoComprobante.CoeficienteValores

      'PE-34391 / Agregar control que no permita reemplazar comprobantes que invocaron Pendientes
      '    Se detectó un error al reemplazar un comprobante que invoca un pedido en el PE-33127.
      '    Su corrección requiere que se reformule la lógica de reemplazo porque al momento de insertar el nuevo comprobante se encuentra con el
      'pedido ya consumido y no descuenta nada (porque no hay que descontar), luego de esto anula el comprobante anterior y esto libera el pedido.
      '    Para resolverlo habría que reorganizar el código subiendo la anulación previo a insertar el nuevo registro; pero hay código de la
      'anulación que requiere saber cual es el nuevo comprobante ya que el mismo se usa para hacer un UPDATE del viejo comprobante al nuevo.
      '    Es factible hacer todos estos cambios, pero el tiempo de desarrollo sería elevado. Y luego los testeos se deberían hacer para todos
      'los casos de prueba e incluso volver a ejecutar los casos de prueba de los viejos pendientes para asegurarnos que no volvieron a aparecer
      'los mismos errores.
      ''''''-- REQ-34643.- -----------------------------------------------------------------------------------------------
      ''''''If Not nuevoTipoComprobante.EsPreElectronico Then
      '''''If comprobante.Invocados.Any(Function(i) i.Invocado.TipoTipoComprobante = Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString()) Then
      '''''   Throw New Exception(String.Format("El comprobante {1} {2} {3:0000}-{4:00000000} invocó Pedidos. No es posible reemplazar comprobantes que invocan Pedidos.",
      '''''                                     comprobante.IdSucursal, comprobante.IdTipoComprobante, comprobante.LetraComprobante, comprobante.CentroEmisor, comprobante.NumeroComprobante))
      '''''End If
      ''''''End If

      If eliminarComprobanteOrigen Then
         If Not comprobante.TipoComprobante.GrabaLibro AndAlso (nuevoTipoComprobante.GrabaLibro Or nuevoTipoComprobante.EsPreElectronico) Then
            If comprobante.VentasProductos.Any(Function(vp) vp.Producto.EsPerceptibleIVARes53292023) Then
               If Not comprobante.Cliente.EsExentoPercIVARes53292023 Then
                  Throw New Exception(String.Format("No se puede Reemplazar el comprobante {0} a {1} porque el cliente ({2} - {3}) no está exento a las Percepciones de IVA y el comprobante tiene productos Perceptibles",
                                                    comprobante.TipoComprobante.Descripcion, nuevoTipoComprobante.GrabaLibro,
                                                    comprobante.Cliente.CodigoCliente, comprobante.Cliente.NombreCliente))
               End If
            End If
         End If
      End If

      If Not copiaFacturables Then
         comprobante.Invocados.Clear()
      Else
         comprobante.NumeroPlanilla = 0
         comprobante.NumeroMovimiento = 0
         comprobante.Invocados.Clear()
      End If

      If comprobante.TipoComprobante.UtilizaImpuestos <> nuevoTipoComprobante.UtilizaImpuestos Then
         Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
         Dim nuevo As Entidades.Venta = CreaVenta(idSucursalNuevo,
                                                  nuevoTipoComprobante, String.Empty, 0, nuevoNumeroComprobante,
                                                  comprobante.Cliente,
                                                  comprobante.CategoriaFiscal,
                                                  If(nuevaFecha <> Nothing, nuevaFecha, comprobante.Fecha),
                                                  comprobante.Vendedor, comprobante.Transportista, comprobante.FormaPago,
                                                  comprobante.DescuentoRecargoPorc,
                                                  idCaja, comprobante.CotizacionDolar, comprobante.MercDespachada,
                                                  If(comprobante.NumeroReparto > 0, comprobante.NumeroReparto, Nothing),
                                                  If(comprobante.FechaEnvio <> Nothing, comprobante.FechaEnvio, Nothing),
                                                  comprobante.Proveedor,
                                                  comprobante.Observacion,
                                                  comprobante.Cobrador,
                                                  clienteVinculado:=Nothing,
                                                  nroOrdenCompra:=0)


         For Each vp In comprobante.VentasProductos
            If nuevoTipoComprobante.UtilizaImpuestos Then
               If (comprobante.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado) Or
                  Not comprobante.CategoriaFiscal.UtilizaImpuestos Or Not categoriaFiscalEmpresa.UtilizaImpuestos Then
               Else
                  vp.Precio = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.DescRecGeneral = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescRecGeneral, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.DescuentoRecargo = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.DescuentoRecargo, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  'vp.PrecioLista = Math.Round(pro.PrecioLista * (1 + (pro.AlicuotaImpuesto / 100)), 2)
                  vp.PrecioNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.PrecioNeto, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.ImporteTotal = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotal, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  vp.ImporteTotalNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(vp.ImporteTotalNeto, vp.Producto.Alicuota, vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno, vp.Producto.OrigenPorcImpInt), 2)
                  'pro.Costo = Math.Round(pro.Costo * (1 + (pro.AlicuotaImpuesto / 100)), 2)
               End If
            Else
               vp.Producto.Alicuota = 0
            End If


            AgregarVentaProducto(nuevo,
                                 CreaVentaProducto(vp.Producto, vp.NombreProducto,
                                                   vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2,
                                                   vp.Precio,
                                                   vp.Cantidad,
                                                   cache.BuscaTiposImpuestos(vp.Producto.IdTipoImpuesto),
                                                   If(nuevoTipoComprobante.UtilizaImpuestos, vp.Producto.Alicuota, 0),
                                                   cache.BuscaListaDePrecios(vp.IdListaPrecios),
                                                   vp.FechaEntrega,
                                                   vp.TipoOperacion,
                                                   vp.Nota,
                                                   idEstadoVenta:=vp.IdEstadoVenta,
                                                   venta:=nuevo,
                                                   redondeoEnCalculo:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio),
                                 Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
         Next

         '-- REQ-35716.- --------------------------
         If comprobante.FormaPago.Dias = 0 Then
            AgregarPagos(nuevo,
                         comprobante.ImportePesos,
                         comprobante.ImporteDolares,
                         comprobante.ImporteTransfBancaria,
                         comprobante.CuentaBancariaTransfBanc,
                         comprobante.FechaTransferencia,
                         comprobante.ImporteTickets,
                         comprobante.Tarjetas,
                         comprobante.Cheques,
                         comprobante.AplicarSaldoCtaCte)
         End If
         '-----------------------------------------

         AgregarInvocado(nuevo, comprobante.Invocados)
         AgregarVentaContactos(nuevo, comprobante.VentasContactos)
         AgregarVentaObservacion(nuevo, comprobante.VentasObservaciones)

         If reaplicaRecibos AndAlso TipoComprobanteAnterior.IdTipoComprobante = "FICHAS" Then
            comprobante.ImportePesos = 0
            For Each pago As Entidades.CuentaCorrientePago In comprobante.CuentaCorriente.Pagos
               pago.SaldoCuota = pago.ImporteCuota
            Next
         End If

         '-- REG-31369.- --
         If Not nuevo.Cliente.EsClienteGenerico AndAlso CatFiscalOld <> nuevo.CategoriaFiscal.IdCategoriaFiscal Then
            nuevo.Cuit = nuevo.Cliente.Cuit
            nuevo.TipoDocCliente = nuevo.Cliente.TipoDocCliente
            nuevo.NroDocCliente = nuevo.Cliente.NroDocCliente
         End If

         Inserta(nuevo, metodoGrabacion, idFuncion,
                 onAfterInsertarVenta:=
                 Sub(v)
                    Dim rPedidoEstado = New PedidosEstados(da)
                    rPedidoEstado.CambiarInvocadorFact(comprobanteAnt, v)
                    rPedidoEstado.CambiarInvocadorRemito(comprobanteAnt, v)
                    v.TipoComprobante.ConsumePedidos = False
                 End Sub)

         comprobante = nuevo

      Else

         'modificar los datos del comprobante con el combo de datos nuevos
         comprobante.IdSucursal = idSucursalNuevo
         comprobante.TipoComprobante = nuevoTipoComprobante
         comprobante.Usuario = actual.Nombre
         comprobante.IdCaja = idCaja

         If comprobante.TipoComprobante.LetrasHabilitadas.Length = 1 Then
            comprobante.LetraComprobante = comprobante.TipoComprobante.LetrasHabilitadas
         Else
            comprobante.LetraComprobante = comprobante.Cliente.CategoriaFiscal.LetraFiscal
         End If

         If nuevaFecha <> Nothing Then
            comprobante.Fecha = nuevaFecha
         End If

         comprobante.Impresora = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(comprobante.IdSucursal, My.Computer.Name, comprobante.IdTipoComprobante)
         comprobante.CentroEmisor = comprobante.Impresora.CentroEmisor
         'pongo el nro. de comprobante en cero para que cargue el proximo

         'If Not esFiscal Then
         '   comprobante.NumeroComprobante = 0
         'Else
         comprobante.NumeroComprobante = nuevoNumeroComprobante
         'End If

         'Recalculo el nuevo precio
         Dim CompAnterior As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(comprobante.IdTipoComprobante)


         If ((Publicos.Facturacion.FacturacionGrabaLibroNoFuerzaConsFinal And (Not CompAnterior.GrabaLibro)) Or TipoComprobanteAnterior.IdTipoComprobante = "FICHAS") And
            (comprobante.TipoComprobante.GrabaLibro Or comprobante.TipoComprobante.EsPreElectronico) Then
            comprobante.CategoriaFiscal = comprobante.Cliente.CategoriaFiscal
         End If

         '# Se acordó con seba realizar este condicional ya que se cruzaban dos pendientes (25373 y 28288)
         If String.IsNullOrEmpty(comprobante.NombreCliente) Then
            comprobante.NombreCliente = comprobante.Cliente.NombreCliente
            comprobante.Cuit = comprobante.Cliente.Cuit
            comprobante.TipoDocCliente = comprobante.Cliente.TipoDocCliente
            comprobante.NroDocCliente = comprobante.Cliente.NroDocCliente
         End If

         ''If comprobante.TipoComprobante.GrabaLibro <> CompAnterior.GrabaLibro OrElse
         ''   comprobante.TipoComprobante.EsPreElectronico <> CompAnterior.EsPreElectronico Then
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         'Dim ProdDT As DataTable

         'Dim DescRec1 As Decimal, DescRec2 As Decimal
         'Dim PrecioNeto As Decimal

         '# Si el coeValAnterior es negativo, multiplico los importes para que lleguen al INSERTAR como se muestran en pantalla
         If coeValAnterior < 0 Then
            comprobante.ImporteBruto = comprobante.ImporteBruto * coeValAnterior
            comprobante.DescuentoRecargo = comprobante.DescuentoRecargo * coeValAnterior
            comprobante.Subtotal = comprobante.Subtotal * coeValAnterior
            comprobante.TotalImpuestos = comprobante.TotalImpuestos * coeValAnterior
            comprobante.ImporteTotal = comprobante.ImporteTotal * coeValAnterior
            comprobante.Utilidad = comprobante.Utilidad * coeValAnterior
            comprobante.Kilos = comprobante.Kilos * coeValAnterior
            comprobante.ImporteTickets = comprobante.ImporteTickets * coeValAnterior
            comprobante.ImporteTransfBancaria = comprobante.ImporteTransfBancaria * coeValAnterior
            comprobante.ImportePesos = comprobante.ImportePesos * coeValAnterior
            comprobante.ImporteDolares = comprobante.ImporteDolares * coeValAnterior

         End If

         '# Si el coeValAnterior es negativo, multiplico los importes para que lleguen al INSERTAR como se muestran en pantalla
         If comprobante.Tarjetas IsNot Nothing Then
            For Each tarjeta As Entidades.VentaTarjeta In comprobante.Tarjetas
               If coeValAnterior < 0 Then
                  tarjeta.Monto = tarjeta.Monto * coeValAnterior
               End If
            Next
         End If

         ' Multiplico los importes por sus Coeficientes CCPagos
         If comprobante.CuentaCorriente IsNot Nothing AndAlso comprobante.CuentaCorriente.Pagos IsNot Nothing Then
            For Each pago As Entidades.CuentaCorrientePago In comprobante.CuentaCorriente.Pagos
               If coeValAnterior < 0 Then
                  pago.ImporteCapital = pago.ImporteCapital * coeValAnterior
               End If
            Next
         End If

#Region "Codigo-Comentado"
         '' Multiplico los importes por sus Coeficientes CCPagos
         'If comprobante.CuentaCorriente(0). IsNot Nothing Then

         'End If

         'comprobante.CuentaCorriente.Pagos(0).ImporteCapital = comprobante.CuentaCorriente.Pagos(0).ImporteCapital * coeValAnterior
#End Region

         For Each pro As Entidades.VentaProducto In comprobante.VentasProductos

            pro.IdSucursal = idSucursalNuevo

            If (comprobante.Cliente.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado) Or
               Not comprobante.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not categoriaFiscalEmpresa.UtilizaImpuestos Then
            Else
               pro.Precio = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(pro.Precio, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
               pro.DescRecGeneral = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.DescRecGeneral, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
               pro.DescuentoRecargo = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(pro.DescuentoRecargo, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
               'pro.PrecioLista = Math.Round(pro.PrecioLista * (1 + (pro.AlicuotaImpuesto / 100)), 2)
               pro.PrecioNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(pro.PrecioNeto, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno, pro.OrigenPorcImpInt), 2)
               pro.ImporteTotal = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(pro.ImporteTotal, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno * pro.Cantidad, pro.OrigenPorcImpInt), 2)
               pro.ImporteTotalNeto = Math.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(pro.ImporteTotalNeto, pro.AlicuotaImpuesto, pro.PorcImpuestoInterno, pro.Producto.ImporteImpuestoInterno * pro.Cantidad, pro.OrigenPorcImpInt), 2)
               'pro.Costo = Math.Round(pro.Costo * (1 + (pro.AlicuotaImpuesto / 100)), 2)
            End If


            '# Si el coeValAnterior es negativo, multiplico los importes para que lleguen al INSERTAR como se muestran en pantalla
            If coeValAnterior < 0 Then
               pro.Cantidad = pro.Cantidad * coeValAnterior
               pro.Utilidad = pro.Utilidad * coeValAnterior
               pro.ImporteTotal = pro.ImporteTotal * coeValAnterior
               pro.ImporteTotalNeto = pro.ImporteTotalNeto * coeValAnterior
               pro.Kilos = pro.Kilos * coeValAnterior
               pro.ImporteImpuesto = pro.ImporteImpuesto * coeValAnterior
               pro.ImporteImpuestoInterno = pro.ImporteImpuestoInterno * coeValAnterior
               pro.ImporteTotalConImpuestos = pro.ImporteTotalConImpuestos * coeValAnterior
               pro.ImporteTotalNetoConImpuestos = pro.ImporteTotalNetoConImpuestos * coeValAnterior
               pro.DescuentoRecargoProducto = pro.DescuentoRecargoProducto * coeValAnterior
               pro.DescRecGeneralProducto = pro.DescRecGeneralProducto * coeValAnterior
            End If

         Next

         For Each ventasImp In comprobante.VentasImpuestos
            '# Si el coeValAnterior es negativo, multiplico los importes para que lleguen al INSERTAR como se muestran en pantalla
            If coeValAnterior < 0 Then
               ventasImp.Bruto = ventasImp.Bruto * coeValAnterior
               ventasImp.Neto = ventasImp.Neto * coeValAnterior
               ventasImp.Importe = ventasImp.Importe * coeValAnterior
               ventasImp.Total = ventasImp.Total * coeValAnterior
            End If
         Next

#Region "Codigo-Comentado"
         'ProdDT = oProductos.GetPorCodigo(pro.Producto.IdProducto, actual.Sucursal.Id, pro.IdListaPrecios, "VENTAS")

         'If (comprobante.Cliente.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado) Or _
         '          Not comprobante.Cliente.CategoriaFiscal.UtilizaImpuestos Or Not categoriaFiscalEmpresa.UtilizaImpuestos Then
         '   pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaSinIVA").ToString())
         'Else
         '   pro.Precio = Decimal.Parse(ProdDT.Rows(0)("PrecioVentaConIVA").ToString())
         'End If

         ''Calculo el Nuevo Descuento/Recargo
         'DescRec1 = Decimal.Round((pro.Precio * pro.DescuentoRecargoPorc1 / 100), 2)
         'DescRec2 = Decimal.Round(((pro.Precio + DescRec1) * pro.DescuentoRecargoPorc2 / 100), 2)

         'pro.DescuentoRecargo = (DescRec1 + DescRec2) * pro.Cantidad

         ''Calculo el Nuevo Precio Neto
         'PrecioNeto = pro.Precio + DescRec1 + DescRec2
         'PrecioNeto = Decimal.Round(PrecioNeto * (1 + (comprobante.DescuentoRecargoPorc / 100)), 2)

         'pro.PrecioNeto = PrecioNeto

         'pro.ImporteTotal = (pro.Precio * pro.Cantidad) + pro.DescuentoRecargo

         ''End If
#End Region

         If Not eliminarComprobanteOrigen Then
            ''''comprobante.CantidadInvocados = 0
            comprobante.Invocados.Clear()
         End If

         If nuevoTipoComprobante.AFIPWSRequiereComprobanteAsociado Then
            AgregarInvocado(comprobante, New Entidades.Venta() With
                                             {
                                                .IdSucursal = comprobante.IdSucursal,
                                                .TipoComprobante = New Reglas.TiposComprobantes().GetUno(comprobanteAnt.IdTipoComprobante),
                                                .LetraComprobante = comprobanteAnt.Letra,
                                                .CentroEmisor = Short.Parse(comprobanteAnt.CentroEmisor.ToString()),
                                                .NumeroComprobante = comprobanteAnt.NumeroComprobante,
                                                .Fecha = comprobante.Fecha
                                             })
            'comprobante.Invocados.Add(New Entidades.Venta() With
            '                                 {
            '                                    .IdSucursal = comprobante.IdSucursal,
            '                                    .TipoComprobante = comprobante.TipoComprobante,
            '                                    .LetraComprobante = comprobante.LetraComprobante,
            '                                    .CentroEmisor = comprobante.CentroEmisor,
            '                                    .NumeroComprobante = comprobante.NumeroComprobante,
            '                                    .Fecha = comprobante.Fecha
            '                                 })
         End If

         If reaplicaRecibos AndAlso TipoComprobanteAnterior.IdTipoComprobante = "FICHAS" Then
            comprobante.ImportePesos = 0
            For Each pago As Entidades.CuentaCorrientePago In comprobante.CuentaCorriente.Pagos
               pago.SaldoCuota = pago.ImporteCuota
            Next
         End If
         If comprobante.CuentaCorriente.Pagos.Count > 0 Then
            comprobante.CuentaCorriente.Pagos(0).CodigoDeBarraSirplus = Nothing
         End If
         '-- REG-31369.- --
         If Not comprobante.Cliente.EsClienteGenerico AndAlso CatFiscalOld <> comprobante.CategoriaFiscal.IdCategoriaFiscal Then
            comprobante.Cuit = comprobante.Cliente.Cuit
            comprobante.TipoDocCliente = comprobante.Cliente.TipoDocCliente
            comprobante.NroDocCliente = comprobante.Cliente.NroDocCliente
         End If

         'insertar un comprobante igual al anterior con los datos nuevos
         Inserta(comprobante, metodoGrabacion, idFuncion,
                 onAfterInsertarVenta:=
                 Sub(v)
                    If eliminarComprobanteOrigen Then
                       Dim rPedidoEstado = New PedidosEstados(da)
                       rPedidoEstado.CambiarInvocadorFact(comprobanteAnt, v)
                       rPedidoEstado.CambiarInvocadorRemito(comprobanteAnt, v)
                       v.TipoComprobante.ConsumePedidos = False
                    End If
                 End Sub)
      End If

      Dim recibosNuevos = New Dictionary(Of Integer, Entidades.CuentaCorriente)()
      _CopiarReemplazarComprobante_EliminarAnterior(comprobante, comprobante.IdSucursal, comprobanteAnt.IdTipoComprobante, comprobanteAnt.Letra, Short.Parse(comprobanteAnt.CentroEmisor.ToString()), comprobanteAnt.NumeroComprobante, eliminarComprobanteOrigen, reaplicaRecibos, recibosNuevos, metodoGrabacion, idFuncion)

      Return New CopiarReemplazarComprobanteResult() With {.ComprobanteNuevo = comprobante,
                                                           .Recibos = recibosNuevos}

   End Function

   Private Sub _CopiarReemplazarComprobante_EliminarAnterior(comprobante As Entidades.Venta,
                                                             idSucursal As Integer,
                                                             idTipoComprobante As String,
                                                             letra As String,
                                                             centroEmisor As Short,
                                                             numeroComprobante As Long,
                                                             eliminarComprobanteOrigen As Boolean,
                                                             reaplicaRecibos As Boolean,
                                                             recibosNuevos As Dictionary(Of Integer, Entidades.CuentaCorriente),
                                                             MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                                             IdFuncion As String)

      'si esta el tilde seleccionado de eliminar el comprobante, eliminarlo
      If eliminarComprobanteOrigen Then
         Dim comprobanteEliminarCopiar As Entidades.Venta
         'Eliminando comprobante original...
         Dim lis As List(Of Entidades.Venta) = New List(Of Entidades.Venta)()
         comprobanteEliminarCopiar = GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         comprobanteEliminarCopiar.Usuario = actual.Nombre
         lis.Add(comprobanteEliminarCopiar)

         Dim rReparto As RepartosComprobantes = New RepartosComprobantes(da)
         rReparto.ActualizarComprobantePorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, comprobante.IdTipoComprobante, comprobante.LetraComprobante, comprobante.CentroEmisor, comprobante.NumeroComprobante)

         OnBeforeAnulaEliminaComprobantes(comprobante.IdSucursal,
                                          idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                          comprobante.IdTipoComprobante, comprobante.LetraComprobante, comprobante.CentroEmisor, comprobante.NumeroComprobante)

         Dim recibosReaplicar = New Dictionary(Of Integer, Entidades.CuentaCorriente)()
         Dim rCtaCte As Reglas.CuentasCorrientes = New CuentasCorrientes(da)

         If reaplicaRecibos Then
            Dim dt As DataTable = New Reglas.CuentasCorrientesPagos(da).GetRecibosDeUnComprobante(comprobanteEliminarCopiar.IdSucursal,
                                                                                                  comprobanteEliminarCopiar.IdTipoComprobante,
                                                                                                  comprobanteEliminarCopiar.LetraComprobante,
                                                                                                  comprobanteEliminarCopiar.CentroEmisor,
                                                                                                  comprobanteEliminarCopiar.NumeroComprobante,
                                                                                                  Nothing)
            Dim sb As StringBuilder = New StringBuilder()
            Dim alguno As Boolean = False
            sb.AppendLine("No se puede reemplazar el comprobante porque el/los siguiente/s recibo/s poseen más de un comprobante aplicado.").AppendLine()
            For Each dr As DataRow In dt.Select("ComprobantesAplicador > 1")
               sb.AppendFormatLine("    {0} {1} {2:0000}-{3:00000000}", dr("IdTipoComprobante"), dr("Letra"), dr("CentroEmisor"), dr("NumeroComprobante"))
               alguno = True
            Next
            sb.AppendLine().AppendLine("Deberá realizar el reemplazo de manera manual.")
            If alguno Then
               Throw New InvalidOperationException(sb.ToString())
            End If

            For Each dr As DataRow In dt.Rows
               Dim recibo = rCtaCte._GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                            dr("IdTipoComprobante").ToString(),
                                            dr("Letra").ToString(),
                                            Short.Parse(dr("CentroEmisor").ToString()),
                                            Long.Parse(dr("NumeroComprobante").ToString()))
               recibosReaplicar.Add(Integer.Parse(dr("CuotaNumero2").ToString()), recibo)
               recibo.Usuario = actual.Nombre
               rCtaCte._anularRecibo(recibo)
            Next
         End If            'If reaplicarRecibos Then

         Me.AnulaEliminaComprobantes(lis, MetodoGrabacion, IdFuncion)

         If reaplicaRecibos Then
            Dim rCtaCteRecibo As CtaCteClienteRecibo = New CtaCteClienteRecibo()
            Dim rTpComp As TiposComprobantes = New TiposComprobantes(da)

            Dim tipoRecibo As Entidades.TipoComprobante
            If comprobante.TipoComprobante.EsPreElectronico Then
               tipoRecibo = rTpComp._GetTipoComprobanteRecibo(comprobante.TipoComprobante.IdTipoComprobanteSecundario, comprobante.ImporteTotal, Base.AccionesSiNoExisteRegistro.Nulo)
            Else
               tipoRecibo = rTpComp._GetTipoComprobanteRecibo(comprobante.IdTipoComprobante, comprobante.ImporteTotal, Base.AccionesSiNoExisteRegistro.Nulo)
            End If

            If tipoRecibo Is Nothing Then
               Throw New ApplicationException(String.Format("El tipo de comprobante {0} no tiene tiene asociado un recibo. Por favor verifique la configuración y reintente.",
                                                            comprobante.IdTipoComprobante))
            End If

            For Each keyValue As KeyValuePair(Of Integer, Entidades.CuentaCorriente) In recibosReaplicar
               Dim recibo As Entidades.CuentaCorriente = keyValue.Value
               Dim reciboNuevo As Eniac.Entidades.CuentaCorriente
               reciboNuevo = rCtaCteRecibo.GetCtaCteCliente(tipoRecibo.IdTipoComprobante, tipoRecibo.LetrasHabilitadas, numeroComprobante:=0,
                                                            recibo.Fecha,
                                                            recibo.FormaPago.IdFormasPago,
                                                            recibo.Cliente, recibo.Vendedor, recibo.Cobrador,
                                                            recibo.Observacion,
                                                            recibo.ImportePesos + recibo.ImporteTarjetas + recibo.ImporteTransfBancaria + (recibo.ImporteDolares * recibo.CotizacionDolar),
                                                            recibo.ImportePesos, recibo.ImporteDolares, recibo.ImporteTarjetas, recibo.ImporteTransfBancaria,
                                                            recibo.CuentaBancariaTransfBanc.IdCuentaBancaria, comprobante.IdCaja,
                                                            pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                            da, nroOrdenCompra:=0)
               rCtaCte.Inserta(reciboNuevo, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

               rReparto.ActualizarReciboPorRecibo(recibo, reciboNuevo)

               recibosNuevos.Add(keyValue.Key, reciboNuevo)
            Next
         End If
      End If

   End Sub

   Public Class CopiarReemplazarComprobanteResult
      Public Property ComprobanteNuevo As Entidades.Venta
      Public Property Recibos As Dictionary(Of Integer, Entidades.CuentaCorriente)
   End Class
#End Region
#Region "Anular/Eliminar Comprobante"
   Public Sub AnularComprobante(invocado As Entidades.IVentaInvocada,
                                idCaja As Integer, usuario As String,
                                metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                idFuncion As String)
      Dim venta As Entidades.Venta = GetUna(invocado.IdSucursal, invocado.IdTipoComprobante, invocado.Letra, Convert.ToInt16(invocado.CentroEmisor), invocado.NumeroComprobante)
      venta.IdCaja = idCaja
      venta.Usuario = usuario

      AnularComprobante(venta, metodoGrabacion, idFuncion)
   End Sub
   Public Sub AnularComprobante(idSucursal As Integer,
                             idTipoComprobante As String,
                             letra As String,
                             centroEmisor As Short,
                             numeroComprobante As Long,
                             MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                             IdFuncion As String)
      Dim venta As Entidades.Venta = GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
      venta.Usuario = actual.Nombre

      AnularComprobante(venta, MetodoGrabacion, IdFuncion)
   End Sub

   Public Sub AnularComprobante(oVentas As Entidades.Venta,
                                metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                idFuncion As String)

      'Dim oVentas As Entidades.Venta = DirectCast(Entidad, Entidades.Venta)

      Dim abreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

      Try

         If abreConexion Then Me.da.OpenConection()
         If abreConexion Then Me.da.BeginTransaction()

         If Publicos.TieneModuloContabilidad And oVentas.TipoComprobante.GeneraContabilidad Then
            Dim ctblEjercicio As ContabilidadEjercicios = New ContabilidadEjercicios(da)
            ctblEjercicio.EstaPeriodoCerrado(oVentas.Fecha)
         End If

         'Si el tipo de pago es cuenta corriente tengo que grabar en las tablas de Cuentas Corrientes
         If oVentas.TipoComprobante.ActualizaCtaCte Then
            If oVentas.FormaPago.Dias > 0 Then
               If Publicos.TieneModuloCuentaCorrienteClientes Then  ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCUENTACORRIENTECLIENTES)) Then

                  'Chequeo si el comprobante tiene algun pago aplicado.

                  Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)
                  Dim ComprobCtaCte As Entidades.CuentaCorriente

                  ComprobCtaCte = oCtaCte._GetUna(oVentas.IdSucursal,
                                                   oVentas.TipoComprobante.IdTipoComprobante,
                                                   oVentas.LetraComprobante,
                                                   oVentas.CentroEmisor,
                                                   oVentas.NumeroComprobante)

                  'Si es NCRED viene dado vuelta, tengo que volver a cambiarlo.
                  If ComprobCtaCte.ImporteTotal * oVentas.TipoComprobante.CoeficienteValores <> ComprobCtaCte.Saldo Then
                     Throw New Exception("El Comprobante tiene algun(os) pago(s) relacionado(s), primero debe Anularlo(s). Nro:" & oVentas.NumeroComprobante)
                  End If

               End If
            End If
         End If

         'si es Contado verifico si tiene el modulo de Caja, asi grabo los movimientos
         If oVentas.FormaPago.Dias = 0 Then
            'si el cliente compro el modulo de caja
            If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then
               'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
               'ya que si es un cliente que tiene fichas y despues factura por aca se complica
               If oVentas.TipoComprobante.AfectaCaja And oVentas.Cheques.Count > 0 Then

                  Dim oCheques As List(Of Entidades.Cheque)

                  oCheques = New Reglas.Cheques(da).GetPorComprobante(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante, Short.Parse(oVentas.CentroEmisor.ToString()), oVentas.NumeroComprobante)

                  Dim Cont As Integer = 0

                  For Cont = 1 To oCheques.Count
                     If oCheques.Item(Cont - 1).NroMovimientoEgreso > 0 Then
                        Dim Mensaje As StringBuilder = New StringBuilder()
                        Mensaje.AppendFormatLine("ATENCION: el Comprobante: {0} {1} {2:0000}-{3:00000000} tiene al menos este cheque entregado, NO puede ANULARLO...",
                                                 oVentas.IdTipoComprobante,
                                                 oVentas.LetraComprobante,
                                                 oVentas.CentroEmisor,
                                                 oVentas.NumeroComprobante).AppendLine()
                        Mensaje.AppendFormat("Banco: {0} / Suc. Bco: {1} / Loc. Bco: {2} / Numero Cheq.: {0}",
                                             oCheques.Item(Cont - 1).Banco.NombreBanco,
                                             oCheques.Item(Cont - 1).IdBancoSucursal,
                                             oCheques.Item(Cont - 1).Localidad.NombreLocalidad,
                                             oCheques.Item(Cont - 1).NumeroCheque)
                        Throw New Exception(Mensaje.ToString())
                     End If
                  Next
               End If
            End If
         End If

         Dim rCupones = New TarjetasCupones(da)
         Dim cuponesInvalidos = rCupones.GetTodos(oVentas).Where(Function(x) x.IdEstadoTarjeta <> Entidades.TarjetaCupon.Estados.ENCARTERA And x.IdEstadoTarjeta <> Entidades.TarjetaCupon.Estados.ACREDITADO)
         If cuponesInvalidos.AnySecure Then
            Throw New Exception("Hay cupones con estado no permitido para anular. Los estados válidos son 'ENCARTERA' o 'ACREDITADO'")
         End If

         If oVentas.TipoComprobante.ActualizaCtaCte Then
            If oVentas.FormaPago.Dias > 0 Then
               If Publicos.TieneModuloCuentaCorrienteClientes Then  ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCUENTACORRIENTECLIENTES)) Then

                  ''cargo el comprobante en el objeto CuentasCorrientes
                  'With oVentas.CuentaCorriente
                  '   .IdSucursal = oVentas.IdSucursal
                  '   .TipoComprobante = oVentas.TipoComprobante
                  '   .Letra = oVentas.LetraComprobante
                  '   .CentroEmisor = oVentas.Impresora.CentroEmisor
                  '   .NumeroComprobante = oVentas.NumeroComprobante
                  'End With

                  Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)

                  oVentas.CuentaCorriente = oCtaCte._GetUna(oVentas.IdSucursal,
                                                            oVentas.TipoComprobante.IdTipoComprobante,
                                                            oVentas.LetraComprobante,
                                                            oVentas.CentroEmisor,
                                                            oVentas.NumeroComprobante)

                  oCtaCte.EliminarCuentaCorriente(oVentas.CuentaCorriente)
               End If
            End If
         End If

         'Si es Contado verifico si tiene el modulo de Caja, hago un contrasiento
         If oVentas.FormaPago.Dias = 0 Then
            'si el cliente compro el modulo de caja
            If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then
               'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
               'ya que si es un cliente que tiene fichas y despues factura por aca se complica
               If oVentas.TipoComprobante.AfectaCaja Then
                  Dim deta As Entidades.CajaDetalles = New Entidades.CajaDetalles(oVentas.IdSucursal, oVentas.Usuario, oVentas.Password)
                  Dim caj As Reglas.Cajas = New Reglas.Cajas(da)
                  Dim ctaCaj As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas(da)
                  Dim cajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)

                  ''tengo que recuperar las cajas del usuario logueado y se lo aplico a la primera si no tiene caja el mov.
                  'If oVentas.IdCaja = 0 Then
                  '   oVentas.IdCaja = Integer.Parse(New Reglas.CajasUsuarios(da)._GetCajas(oVentas.Usuario, oVentas.IdSucursal).Rows(0)("IdCaja").ToString())
                  'End If

                  With deta
                     .IdSucursal = oVentas.IdSucursal
                     .IdCaja = oVentas.IdCaja

                     '-- REQ-34142.- ------------------------------
                     .IdMonedaImporteBancos = oVentas.IdMoneda
                     '---------------------------------------------
                     .FechaMovimiento = oVentas.Fecha    'DAte.Now

                     'Invierto el tipo de movimiento.
                     If oVentas.TipoComprobante.CoeficienteValores = 1 Then
                        .IdTipoMovimiento = "E"c
                     Else
                        .IdTipoMovimiento = "I"c
                     End If

                     .NumeroPlanilla = caj.GetPlanillaActual(oVentas.IdSucursal, oVentas.IdCaja).NumeroPlanilla
                     .Observacion = Strings.Left("ANULA " & oVentas.TipoComprobante.DescripcionAbrev & " " & oVentas.LetraComprobante & " " & oVentas.Impresora.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & IIf(oVentas.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + oVentas.Cheques.Count.ToString(), "").ToString() & ". " & oVentas.Cliente.NombreCliente, 100)
                     .IdCuentaCaja = Publicos.CtaCajaVentas  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.CTACAJAVENTAS))
                     'me fijo si es Efectivo o Tarjeta para cargar el tipo de cuenta en la caja
                     .ImportePesos = oVentas.ImportePesos * oVentas.TipoComprobante.CoeficienteValores
                     .ImporteDolares = oVentas.ImporteDolares * oVentas.TipoComprobante.CoeficienteValores
                     .ImporteBancos = oVentas.ImporteTransfBancaria * oVentas.TipoComprobante.CoeficienteValores
                     .ImporteTarjetas = oVentas.ImporteTarjetas * oVentas.TipoComprobante.CoeficienteValores
                     .ImporteTickets = oVentas.ImporteTickets * oVentas.TipoComprobante.CoeficienteValores
                     .ImporteCheques = oVentas.ImporteCheques * oVentas.TipoComprobante.CoeficienteValores
                     .EsModificable = False
                     .GeneraContabilidad = False
                     .Usuario = actual.Nombre
                  End With

                  cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(oVentas.Cheques), Nothing)

                  oVentas.NumeroPlanilla = deta.NumeroPlanilla

                  'Las Anulaciones van aparte aunque acumule, para un mejor control interno.
                  'If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTASACUMULA")) Then
                  '   deta = cajaDet.GetUltimoMovVenta(deta.IdSucursal, deta.IdCaja, deta.NumeroPlanilla, deta.IdCuentaCaja, deta.FechaMovimiento)
                  'End If

                  oVentas.NumeroMovimiento = deta.NumeroMovimiento

                  Me.ActualizaMovimientoCaja(oVentas)


                  'Analizo c/Tarjeta para saber si hago la salida de Caja.
                  If oVentas.ImporteTarjetas > 0 Then
                     For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas
                        'Solo si tiene configurado el Deposito Automatico. Se analiza Individualmente.
                        If tr.Tarjeta.Acreditacion Then
                           With deta
                              .FechaMovimiento = oVentas.Fecha
                              .IdSucursal = oVentas.IdSucursal
                              .IdTipoMovimiento = If(oVentas.ImporteTarjetas > 0, "I"c, "E"c)
                              .IdCaja = oVentas.IdCaja
                              .NumeroPlanilla = caj.GetPlanillaActual(oVentas.IdSucursal, oVentas.IdCaja).NumeroPlanilla
                              .ImportePesos = 0
                              .ImporteDolares = 0
                              .ImporteCheques = 0
                              .ImporteTickets = 0
                              .ImporteTarjetas = tr.Monto * oVentas.TipoComprobante.CoeficienteValores
                              .ImporteBancos = .ImporteTarjetas * -1
                              If .IdMonedaImporteBancos.IfNull() = 0 Then
                                 .IdMonedaImporteBancos = Entidades.Moneda.Peso
                              End If
                              .Observacion = Strings.Left(oVentas.TipoComprobante.DescripcionAbrev & " " & oVentas.LetraComprobante & " " & oVentas.Impresora.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & " -Deposito de Tarjeta Crédito de: " & oVentas.Cliente.NombreCliente, 100)
                              .IdCuentaCaja = Publicos.CtaCajaDepositoTarjetas
                              .EsModificable = False
                              .GeneraContabilidad = False
                              .Usuario = actual.Nombre
                           End With
                           cajaDet.AgregaMovimiento(deta, Nothing, Nothing)
                        End If
                     Next
                  End If            'If oVentas.ImporteTarjetas > 0 Then



               End If
            End If
         End If

         'si tiene modulo Bancos
         If oVentas.TipoComprobante.AfectaCaja Then
            If Publicos.TieneModuloBanco Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

               Dim rLibroBancos = New LibroBancos(da)
               Dim eLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               Dim rLibBanco = New LibroBancos(da)

               If oVentas.ImporteTransfBancaria <> 0 Then
                  For Each trx In oVentas.Transferencias
                     With eLibroBanco
                        .IdSucursal = oVentas.IdSucursal
                        .IdCuentaBancaria = trx.IdCuentaBancaria
                        .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                        .IdCuentaBanco = Publicos.CtaBancoTransfBancaria
                        If oVentas.TipoComprobante.CoeficienteValores > 0 Then
                           .IdTipoMovimiento = "E"
                        Else
                           .IdTipoMovimiento = "I"
                        End If
                        .Importe = Math.Abs(trx.Importe)
                        .FechaMovimiento = oVentas.Fecha
                        .IdCheque = Nothing
                        .FechaAplicado = oVentas.Fecha
                        '.Observacion = ent.Observacion
                        .Observacion = String.Format("ANULA {0} {1} {2}-{3:00000000} - Transf. a Cuenta. {4}",
                                                     oVentas.TipoComprobante.Descripcion, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante,
                                                     oVentas.Cliente.NombreCliente).Truncar(100)
                        .Conciliado = False
                     End With
                     rLibroBancos.AgregaMovimiento(eLibroBanco)
                  Next
               End If

               If oVentas.FormaPago.Dias = 0 Then
                  'Acredito las tarjetas en la cuenta
                  Dim entLibroBancoTar As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
                  Dim oLibBancoTar As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)
                  Dim ultimoDia As Date
                  Dim diaUltimo As Integer
                  Dim cantdias As Integer
                  Dim ultimoDiaX As Date
                  Dim diaMes As Date
                  For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas

                     'Solo si tiene configurado el Deposito Automatico. Se analiza Individualmente.
                     If tr.Tarjeta.Acreditacion Then

                        With entLibroBancoTar
                           .IdSucursal = oVentas.IdSucursal
                           .IdCuentaBancaria = tr.Tarjeta.CuentaBancaria.IdCuentaBancaria
                           .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                           .IdCuentaBanco = Publicos.CtaBancoAcredTarjeta  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOACREDTARJETA))
                           .IdTipoMovimiento = "E"
                           .Importe = tr.Monto
                           .FechaMovimiento = oVentas.Fecha
                           .IdCheque = Nothing
                           If tr.Tarjeta.PagoPosVenta Then
                              .FechaAplicado = oVentas.Fecha.AddDays(tr.Tarjeta.CantDiasAcredit)
                           Else
                              If tr.Tarjeta.PagoPosCorte Then
                                 ultimoDia = DateSerial(Year(oVentas.Fecha), Month(oVentas.Fecha) + 1, 0)
                                 diaUltimo = ultimoDia.DayOfWeek()
                                 If diaUltimo = (tr.Tarjeta.DiaCorte + 1) Then
                                    ultimoDiaX = ultimoDia
                                 Else
                                    cantdias = (7 + diaUltimo - (tr.Tarjeta.DiaCorte + 1))
                                    ultimoDiaX = ultimoDia.AddDays(-cantdias)
                                 End If
                                 .FechaAplicado = ultimoDiaX.AddDays(tr.Tarjeta.CantDiasAcredit)
                              Else
                                 'PagoDiaMes
                                 diaMes = DateSerial(Year(.FechaMovimiento), Month(.FechaMovimiento), tr.Tarjeta.DiaMes)
                                 If .FechaMovimiento < diaMes Then
                                    .FechaAplicado = diaMes.AddDays(tr.Tarjeta.CantDiasAcredit)
                                 Else
                                    .FechaAplicado = DateAdd("m", 1, diaMes).AddDays(tr.Tarjeta.CantDiasAcredit)
                                 End If
                              End If

                           End If

                           '.Observacion = ent.Observacion
                           .Observacion = Strings.Left(tr.NombreTarjeta & "(" & tr.NombreBanco & ")Cup:" & tr.NumeroCupon & "-Ctas(" & tr.Cuotas & ")-" & oVentas.TipoComprobante.Descripcion & " " & oVentas.LetraComprobante & " " & oVentas.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & "(" & oVentas.Cliente.NombreCliente & ")", 100)
                           .Conciliado = False
                        End With

                        rLibroBancos.AgregaMovimiento(entLibroBancoTar)

                     End If

                  Next

               End If            'If oVentas.FormaPago.Dias = 0 Then
            End If


         End If

         Dim rVTrx = New VentasTransferencias(da)
         rVTrx._Borrar(oVentas)

         'Quito el Saldo de la Venta.
         If oVentas.TipoComprobante.GrabaLibro Then

            Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)

            Dim PeriodoFiscal As Integer = Integer.Parse(oVentas.Fecha.ToString("yyyyMM"))
            Dim Neto As Decimal = oVentas.Subtotal
            Dim IVA As Decimal = oVentas.TotalIVA

            oPF.ActualizarPosicion(actual.Sucursal.IdEmpresa, PeriodoFiscal, Neto * (-1), IVA * (-1), oVentas.ImporteTotal * (-1), 0, 0, 0, 0, 0)

         End If
         '--------------------------------------------------------------

         With oVentas

            .IdEstadoComprobante = "ANULADO"

            .Observacion = "*** COMPROBANTE ANULADO LUEGO DE EMITIR ***"

            'cargo valores del comprobante
            .ImporteBruto = 0
            .DescuentoRecargo = 0
            .DescuentoRecargoPorc = 0
            .Subtotal = 0
            .TotalImpuestos = 0
            .ImporteTotal = 0

            .Kilos = 0

            '@@@@ Si anulo uno que facturo otro deberia tirar todo para atras @@@@
            'Cargo los Comprobantes Facturados
            '.Facturables = Nothing

            'cargo las monedas de pago (Efectivo, Cheques, etc)
            '.Cheques = Nothing

            .ImportePesos = 0
            .ImporteDolares = 0
            '.ImporteTarjetas = 0
            .ImporteTickets = 0
            .ImporteTransfBancaria = 0

         End With

         'Necesito leerlo el count para forzar su generacion y que no de error despues.
         Dim ImpCheques As Decimal
         If oVentas.Cheques.Count > 0 Then
            ImpCheques = oVentas.ImporteCheques
         End If
         '------------------------------------------

         ''Graba el comprobante de Venta (Factura, Nota de Debito, Nota de Credito, etc.)
         'Me.EjecutaSP(oVentas, TipoSP._U, Entidades.Entidad.MetodoGrabacion.Manual, "")


         'Si obtengo movimiento es porque originalmente afecto.
         Dim dtMov As DataTable

         dtMov = New MovimientosStock(da).GetUnoPorComprobante(oVentas.IdSucursal,
                                                               oVentas.TipoComprobante.IdTipoComprobante,
                                                               oVentas.LetraComprobante,
                                                               oVentas.CentroEmisor,
                                                               oVentas.NumeroComprobante, 0)

         If dtMov.Rows.Count > 0 Then

            'Descuenta Stock de los Componentes de Productos
            Dim _Componentes As DataTable
            Dim produ As Productos
            Dim produc As Entidades.Producto
            Dim movComp = New Entidades.MovimientoStock()
            Dim movcomprod As Entidades.MovimientoStockProducto
            Dim omovcomprod = New List(Of Entidades.MovimientoStockProducto)
            Dim oMovComp = New MovimientosStock(da)
            Dim ocomponentes As Reglas.ProductosComponentes = New Reglas.ProductosComponentes(da)
            Dim prodprodcomp As Entidades.ProduccionProductoComp

            Dim idListaDePrecios As Integer = 0 'Lista Base

            For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos

               produ = New Reglas.Productos(da)
               produc = New Entidades.Producto()

               produc = produ.GetUno(Prod.IdProducto)


               'Si bien un producto NO Compuesto no podria marcarse como descontar componentes, lo hago por si en algun momento fallo algun control
               If produc.EsCompuesto And produc.DescontarStockComponentes Then



                  prodprodcomp = New Entidades.ProduccionProductoComp()

                  _Componentes = ocomponentes.GetComponentes(Prod.IdSucursal, Prod.IdProducto, Prod.Producto.IdFormula, idListaDePrecios)

                  If _Componentes.Rows.Count > 0 Then

                     'Alta del producto de produccion automatica
                     Dim oMov1 = New MovimientosStock(da)
                     oVentas.TipoComprobante.CoeficienteValores = -1
                     oMov1.CargarMovimientoStock(Me.GetMovimientoVentaProdAutomatico(oVentas), metodoGrabacion, idFuncion)

                     For Each dr As DataRow In _Componentes.Rows
                        movComp = New Entidades.MovimientoStock()
                        movcomprod = New Entidades.MovimientoStockProducto()

                        movcomprod.IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
                        movcomprod.IdDeposito = Integer.Parse(dr("IdDepositoDefecto").ToString())
                        movcomprod.IdUbicacion = Integer.Parse(dr("IdUbicacionDefecto").ToString())

                        movcomprod.Cantidad = Decimal.Parse(dr("Cantidad").ToString()) * Prod.Cantidad * (-1)
                        movcomprod.DescRecGeneral = 0
                        movcomprod.DescuentoRecargo = 0
                        movcomprod.IdLote = ""
                        movcomprod.IdProducto = dr("IdProductoComponente").ToString()
                        movcomprod.NombreProducto = dr("NombreProducto").ToString()
                        movcomprod.Precio = Decimal.Parse(dr("PrecioCosto").ToString())
                        movcomprod.ImporteTotal = Decimal.Round(movcomprod.Cantidad * movcomprod.Precio, 2)
                        movcomprod.IVA = 0

                        omovcomprod.Add(movcomprod)

                     Next

                     With movComp
                        .Sucursal = New Reglas.Sucursales(da).GetUna(Prod.IdSucursal, False)

                        .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno("COMPROD")

                        .FechaMovimiento = Date.Now   'oVentas.Fecha

                        .DescuentoRecargo = 0

                        .PercepcionIVA = 0
                        .PercepcionIB = 0
                        .PercepcionGanancias = 0
                        .PercepcionVarias = 0

                        .Productos = omovcomprod

                        '.PoductosLotes = Me._sLotes

                        .Usuario = oVentas.Usuario

                     End With
                  End If

                  oMovComp.GrabarMovimientoProduccion(movComp)

                  omovcomprod.Clear()

               End If

            Next

            '----------------------------------------------------------------------------------------

            'si el cliente tiene sucursal asociado tengo que realizar el contra-movimiento en la otra sucursal
            'esto es legal ya que transportar mercaderia entre sucursales tiene que ser con remito.

            If oVentas.Cliente.IdSucursalAsociada <> 0 Then
               'solo si el tipo de comprobante afecta stock
               If oVentas.TipoComprobante.CoeficienteStock <> 0 Then
                  Dim oCo = New Entidades.MovimientoStock()
                  Dim rCo = New MovimientosStock(da)
                  With oVentas
                     oCo.IdSucursal = .Cliente.IdSucursalAsociada
                     oCo.Sucursal.Id = .Cliente.IdSucursalAsociada
                     oCo.Sucursal2.Id = .Cliente.IdSucursal
                     oCo.FechaMovimiento = .Fecha
                     oCo.Usuario = .Usuario
                     'oCo.TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno(Entidades.TipoMovimiento.TiposMovimientos.AJUSTE.ToString())
                     oCo.TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno("REC-SUC")
                     oCo.Observacion = Strings.Left("ANULACION. Automatico. Sucursal Origen: " & actual.Sucursal.Nombre & ". " & oVentas.TipoComprobante.DescripcionAbrev & " " & oVentas.LetraComprobante & " " & oVentas.Impresora.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & IIf(oVentas.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + oVentas.Cheques.Count.ToString(), "").ToString() & ". " & oVentas.Cliente.NombreCliente, 100)

                     Dim cp As Entidades.MovimientoStockProducto
                     For Each vp As Entidades.VentaProducto In .VentasProductos
                        cp = New Entidades.MovimientoStockProducto()
                        cp.ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(.Cliente.IdSucursalAsociada, vp.Producto.IdProducto)
                        cp.IdProducto = vp.Producto.IdProducto
                        cp.Orden = vp.Orden
                        cp.Cantidad = vp.Cantidad * oVentas.TipoComprobante.CoeficienteStock
                        cp.Precio = vp.PrecioNeto
                        oCo.Productos.Add(cp)
                     Next
                  End With
                  rCo.CargarMovimientoStock(oCo, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
               End If
            End If

            '----------------------------------------------------------------------------------------

         End If
         '-------------------------------------------------------------------------------------------

         Dim oVentasProd As New Reglas.VentasProductos(da)

         'ACA Controlar si el comprobante ACTUAL facturo otro y que Coeficiente STock tiene... 
         'Tambien podria mirar si hay movimientos de stock, pero ... puedo blanquearlos.

         Dim invocados = New VentasInvocados(da).GetInvocados(oVentas)
         Dim blnEntrar As Boolean = False

#Region "Comentado"
         ''Chequea si invoco otros
         'If invocados.Count > 0 Then
         '   blnEntrar = invocados.FirstOrDefault().Invocado.CoeficienteStock = 0
         'End If


         ''Dim dtInvocados As DataTable
         ''dtInvocados = Me.GetInvocados(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
         ''                              oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)
         ''Dim blnEntrar As Boolean = True
         '' 'Chequea si invoco otros
         ''If dtInvocados.Rows.Count > 0 Then
         ''   Dim eTipoComprobante As Entidades.TipoComprobante
         ''   eTipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dtInvocados.Rows(0)("IdTipoComprobante").ToString())

         ''   'Si el que invoco no afectaba stock, significa que el comprabante antual.. SI lo hizo
         ''   blnEntrar = (eTipoComprobante.CoeficienteStock = 0)
         ''End If

         ''Primero grabo la diferencia de movimientos y el ajuste de stock
#End Region
         'Si NO facturo otros (ej: Factura sin Facturables).

         If oVentas.Invocados.Count = 0 Then
            blnEntrar = oVentas.TipoComprobante.CoeficienteStock <> 0
            'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).
         ElseIf oVentas.Invocados.Count > 0 And oVentas.Invocados(0).Invocado.CoeficienteStock = 0 Then
            blnEntrar = oVentas.TipoComprobante.CoeficienteStock <> 0
            'O Facturo pero devuelve (Deshace Remito) y ese facturado si desconto Stock (ej: Remito)
         ElseIf oVentas.Invocados.Count > 0 And oVentas.TipoComprobante.CoeficienteStock > 0 And oVentas.Invocados(0).Invocado.CoeficienteStock < 0 Then
            'Si tiene Produccion Automatica debe devolver los componentes
            blnEntrar = oVentas.TipoComprobante.CoeficienteStock <> 0
         End If

         If blnEntrar Then
            Dim oMov = New Reglas.MovimientosStock(da)
            'Cambio la fecha para que el nuevo movimiento quede registrado con la fecha del ajuste.
            oVentas.Fecha = Date.Now
            'Limpio las Cantidades para que se haga el contra-movimiento por la totalidad
            For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos
               Prod.Cantidad = 0
            Next
            oMov.CargarMovimientoStock(Me.GetMovimientoVentaDifCantidad(oVentas), metodoGrabacion, idFuncion)
         End If

         Dim rTurnos As Reglas.TurnosCalendarios = New TurnosCalendarios(da)
         rTurnos.AnularInvocarTurno(oVentas)

         '################
         '#    SERVICE   #
         '################

         '# Libero los servicios facturados
         For Each n As Entidades.CRMNovedad In oVentas.CrmInvocados
            Dim rCRMNovedades = New Reglas.CRMNovedades(da)
            rCRMNovedades.ActualizarDatosVentaCRM(oVentas, esAnulacion:=True)
         Next

         ''Prefiero borrar el detalle.
         'Dim oVentasProdLote As New Reglas.VentasProductosLotes(da)
         'Dim VenProdLote As New Entidades.VentaProductoLote()
         'VenProdLote.IdSucursal = actual.Sucursal.Id
         'VenProdLote.TipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
         'VenProdLote.Letra = oVentas.LetraComprobante
         'VenProdLote.CentroEmisor = oVentas.Impresora.CentroEmisor
         'VenProdLote.NumeroComprobante = oVentas.NumeroComprobante

         'oVentasProdLote.EjecutaSP(VenProdLote, TipoSP._D)
         ''--------------------------------------------------

         '# Productos con Número de Serie
         Dim nrosSerie = New Reglas.ProductosNrosSerie(da)


         Dim esDevolucion As Boolean = If(oVentas.TipoComprobante.CoeficienteStock > 0, True, False)
         Dim dt As DataTable
         For Each vp As Entidades.VentaProducto In oVentas.VentasProductos
            For Each p As Entidades.ProductoNroSerie In vp.Producto.NrosSeries

               '# Si el comprobante tiene coef. Stock negativo, valido que el producto no esté en stock por algún otro movimiento.
               '# Si el comprobante tiene coef. Stock positivo, valido que el producto esté en stock y no se haya vendido en otro movimiento.
               If Not nrosSerie.EstaVendido(p.Producto.IdProducto, p.NroSerie, Not esDevolucion) Then
                  Throw New Exception(String.Format("ATENCIÓN: El producto {0} Serie: {1} {2} se encuentra en stock. No es posible anular el comprobante.",
                                                    vp.NombreProducto,
                                                    p.NroSerie,
                                                    If(esDevolucion, "no", "ya")))
               End If

               '# Si el tipo de comprobante tiene coef. Stock positivo(por ej: una devolución), inserto en los campos de venta los valores del comprobante anterior a la devolución.
               If esDevolucion Then
                  dt = nrosSerie.GetEstadoComprobanteAnteriorAFecha(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                                                                    p.Producto.IdProducto, p.NroSerie, oVentas.Fecha, esDeVenta:=True)

                  If dt.Rows.Count > 0 Then
                     Dim dr As DataRow = dt.Rows(0)
                     nrosSerie._Actualiza(New Entidades.ProductoNroSerie With {.Sucursal = New Entidades.Sucursal With {.IdSucursal = dr.Field(Of Integer)(Entidades.ProductoNroSerie.Columnas.IdSucursal.ToString())},
                                                                               .TipoComprobante = New Entidades.TipoComprobante With {.IdTipoComprobante = dr.Field(Of String)(Entidades.MovimientoStock.Columnas.IdTipoComprobante.ToString())},
                                                                               .Letra = dr.Field(Of String)(Entidades.MovimientoStock.Columnas.Letra.ToString()),
                                                                               .CentroEmisor = Convert.ToInt16(dr.Field(Of Integer)(Entidades.MovimientoStock.Columnas.CentroEmisor.ToString())),
                                                                               .NumeroComprobante = dr.Field(Of Long)(Entidades.MovimientoStock.Columnas.NumeroComprobante.ToString()),
                                                                               .Vendido = True,
                                                                               .Producto = vp.Producto,
                                                                               .NroSerie = p.NroSerie,
                                                                               .OrdenVenta = p.OrdenVenta,
                                                                               .FechaDevolucionVenta = dr.Field(Of Date?)(Entidades.VentaProducto.Columnas.FechaDevolucion.ToString())})
                  End If
               End If
               '-- REQ-36948(Poder anular los remitos envio con numeros de serie).- ---------------------------------------
               If oVentas.Cliente.IdSucursalAsociada <> 0 And oVentas.IdSucursal <> oVentas.Cliente.IdSucursalAsociada Then
                  nrosSerie.ActualizaCambioSucursal(p.Producto.IdProducto, p.NroSerie, oVentas.IdSucursal)
               End If
               '-----------------------------------------------------------------------------------------------------------
            Next
         Next

         '<<anterior>> '# Si el tipo de comprobante tiene coef. Stock negativo, blanqueo los campos de Venta del producto.
         If Not esDevolucion Then
            nrosSerie.ActualizarNrosSerie(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante,
                                          oVentas.CentroEmisor, oVentas.NumeroComprobante)
         End If

         '<<nuevo>>
         '# Borro los registros de la tabla
         Dim rVentasProductosNrosSerie As Reglas.VentasProductosNrosSerie = New Reglas.VentasProductosNrosSerie(da)
         rVentasProductosNrosSerie._Borra(New Entidades.VentaProductoNroSerie With {.IdSucursal = oVentas.IdSucursal,
                                                                                    .IdTipoComprobante = oVentas.IdTipoComprobante,
                                                                                    .Letra = oVentas.LetraComprobante,
                                                                                    .CentroEmisor = oVentas.CentroEmisor,
                                                                                    .NumeroComprobante = oVentas.NumeroComprobante})
         '--------------------------------------------------

         'Borro el detalle de Productos.
         Dim VenProd As New Entidades.VentaProducto()
         VenProd.IdSucursal = actual.Sucursal.Id
         VenProd.TipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
         VenProd.Letra = oVentas.LetraComprobante
         VenProd.CentroEmisor = oVentas.Impresora.CentroEmisor
         VenProd.NumeroComprobante = oVentas.NumeroComprobante

         oVentasProd.EjecutaSP(VenProd, TipoSP._D)
         '--------------------------------------------------

         'Borro el detalle de Impuestos.
         Dim oVentasImpuestos As New Reglas.VentasImpuestos(da)
         Dim VenImpues As New Entidades.VentaImpuesto()
         VenImpues.IdSucursal = actual.Sucursal.Id
         VenImpues.TipoComprobante = oVentas.TipoComprobante
         VenImpues.Letra = oVentas.LetraComprobante
         VenImpues.CentroEmisor = oVentas.Impresora.CentroEmisor
         VenImpues.NumeroComprobante = oVentas.NumeroComprobante
         VenImpues.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.Ninguno  'Para forzar el borrado de toda la tabla

         oVentasImpuestos.EjecutaSP(VenImpues, TipoSP._D)
         '--------------------------------------------------

         Dim rVT = New VentasTransferencias(da)
         rVT._Borrar(oVentas)

         'Borro el detalle de Observaciones.
         Dim oVentasObserv As Reglas.VentasObservaciones = New Reglas.VentasObservaciones(da)

         For Each Observ As Entidades.VentaObservacion In oVentas.VentasObservaciones

            Observ.IdTipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
            'Observ.Letra = oVentas.Cliente.CategoriaFiscal.LetraFiscal
            Observ.Letra = oVentas.LetraComprobante
            Observ.CentroEmisor = oVentas.Impresora.CentroEmisor
            Observ.NumeroComprobante = oVentas.NumeroComprobante

            'grabo las observaciones del comprobante de venta
            oVentasObserv.EjecutaSP(Observ, TipoSP._D)
         Next


         'Borro las Percepciones
         Dim opercep As Reglas.PercepcionVentas = New Reglas.PercepcionVentas(da)
         Dim sqlPercepVenta As SqlServer.VentasPercepciones = New SqlServer.VentasPercepciones(da)
         If oVentas.Percepciones IsNot Nothing Then
            For Each perc In oVentas.Percepciones
               If perc.TipoImpuesto.IdTipoImpuesto <> 0 Then
                  opercep.EjecutaSP(perc, TipoSP._D)
               End If
            Next
            sqlPercepVenta.VentasPercepciones_D(oVentas.IdSucursal,
                                                oVentas.TipoComprobante.IdTipoComprobante,
                                                oVentas.LetraComprobante,
                                                oVentas.CentroEmisor,
                                                oVentas.NumeroComprobante)
         End If


         'BORRO los Cheques Asociados
         If oVentas.Cheques.Count > 0 Then

            Dim sqlVentasCheq As SqlServer.VentasCheques = New SqlServer.VentasCheques(da)

            sqlVentasCheq.VentasCheques_D2(oVentas.IdSucursal,
                                             oVentas.TipoComprobante.IdTipoComprobante,
                                             oVentas.LetraComprobante,
                                             oVentas.CentroEmisor,
                                             oVentas.NumeroComprobante)

            Dim sqlCheques As SqlServer.Cheques = New SqlServer.Cheques(da)
            Dim Conta As Integer = 0

            For Conta = 1 To oVentas.Cheques.Count

               sqlCheques.Cheques_D(oVentas.Cheques.Item(Conta - 1).IdCheque)
            Next

         End If

         'Anulo el Rechazado de los Cheques Asociados
         If oVentas.ChequesRechazados.Count > 0 Then

            Dim sqlCheques As SqlServer.Cheques = New SqlServer.Cheques(da)
            Dim sqlLibroBanco As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)
            Dim rCheques As Reglas.Cheques = New Reglas.Cheques(da)

            Dim Conta As Integer = 0

            For Conta = 1 To oVentas.ChequesRechazados.Count

               '# Recupero los estados de los cheques anteriores
               Dim eCheque As Entidades.Cheque = rCheques.RecuperarEstadosChequeAnteriores(oVentas.ChequesRechazados.Item(Conta - 1).IdCheque)

               sqlCheques.Cheques_VuelveEstadoAnt(oVentas.IdSucursal,
                                                   oVentas.ChequesRechazados.Item(Conta - 1).Banco.IdBanco,
                                                   oVentas.ChequesRechazados.Item(Conta - 1).IdBancoSucursal,
                                                   oVentas.ChequesRechazados.Item(Conta - 1).Localidad.IdLocalidad,
                                                   oVentas.ChequesRechazados.Item(Conta - 1).NumeroCheque, actual.Nombre,
                                                   eCheque.IdEstadoCheque.ToString(),
                                                   eCheque.IdEstadoChequeAnt.ToString(),
                                                   oVentas.ChequesRechazados.Item(Conta - 1).IdCheque,
                                                   limpiaPlanillaCaja:=False)

               'Si no estaba en banco, no afecta ningun registro
               sqlLibroBanco.LibroBancos_UImporteCheque(oVentas.ChequesRechazados.Item(Conta - 1).IdCheque,
                                                        oVentas.ChequesRechazados.Item(Conta - 1).Importe)

            Next

            Dim sqlVentasCheqRech As SqlServer.VentasChequesRechazados = New SqlServer.VentasChequesRechazados(da)

            sqlVentasCheqRech.VentasChequesRechazados_D2(oVentas.IdSucursal,
                                                         oVentas.TipoComprobante.IdTipoComprobante,
                                                         oVentas.LetraComprobante,
                                                         oVentas.CentroEmisor,
                                                         oVentas.NumeroComprobante)

         End If


         'Desaplico este comprobante de todos aquellos facturable que cancele (ejemplo Remito)

         Me.ActualizaDesaplicaFacturables(oVentas.IdSucursal,
                                          oVentas.TipoComprobante.IdTipoComprobante,
                                          oVentas.LetraComprobante,
                                          oVentas.CentroEmisor,
                                          oVentas.NumeroComprobante)

         'Borro el detalle de Tarjetas

         Dim sqlTarj As New SqlServer.VentasTarjetas(da)

         '-- REQ-31148.- --
         Dim dtl = sqlTarj.VentasTarjetas_Cupon(actual.Sucursal.Id, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante)



         sqlTarj.VentasTarjetas_D(actual.Sucursal.Id, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante, 0, 0, 0)

         '-- REQ-31148.- --
         '-- Verifica si existen cupones.- --
         If dtl.Rows.Count > 0 Then
            Dim sqlTC = New SqlServer.TarjetasCupones(da)
            'elimino los Cupones de tarjetas de credito
            For Each drl In dtl.AsEnumerable()
               sqlTC.TarjetasCupones_D(drl.Field(Of Integer)("IdTarjetaCupon"))
            Next
         End If

         oVentas.Tarjetas.Clear()
         oVentas.Cheques.Clear()
         oVentas.ChequesRechazados.Clear()
         'Graba el comprobante de Venta (Factura, Nota de Debito, Nota de Credito, etc.)
         Me.EjecutaSP(oVentas, TipoSP._U, Entidades.Entidad.MetodoGrabacion.Manual, "")



         'Actualizo Pedidos
         Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)
         Dim sqlPP As SqlServer.PedidosProductos = New SqlServer.PedidosProductos(da)
         Dim rPP As Reglas.PedidosProductos = New PedidosProductos(da)
         Dim sqlPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
         Dim rPE As PedidosEstados = New PedidosEstados(da)

         Dim pedidosEstados As DataTable = sqlPE.PedidosEstados_G_PorComprobanteFact(oVentas.IdSucursal,
                                                                 oVentas.IdTipoComprobante, oVentas.LetraComprobante,
                                                                 oVentas.CentroEmisor, oVentas.NumeroComprobante)

         If oVentas.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
            If pedidosEstados.Select().Any(Function(dr) dr.Field(Of String)("IdEstado") <> Publicos.EstadoPedidoFacturado) Then
               Throw New Exception(String.Format("El comprobante {2}/{3} {4} {5:0000}-{6:00000000} invocó un pedido que se encuentra en un estado distinto a {1}, por lo que no es posible anularlo.{0}{0}Debe cambiar el estado del pedido al mencionado estado para poder anular el comprobante.",
                                                 Environment.NewLine, Publicos.EstadoPedidoFacturado,
                                                 oVentas.IdSucursal, oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante))
            End If
         End If

         'Hay que ver como parametrizar esto diferente
         Dim tipoTipoComprobante As String = "PEDIDOSCLIE"
         If pedidosEstados.Rows.Count > 0 Then
            tipoTipoComprobante = New Reglas.TiposComprobantes(da).GetUno(pedidosEstados.Rows(0)("IdTipoComprobante").ToString()).Tipo
         End If

         Dim _cache As BusquedasCacheadas = New BusquedasCacheadas()

         Dim idEstadoAnterior As String
         Dim idTipoEstadoAnterior As String '= New EstadosPedidos(da).GetUno(Publicos.EstadoPedidoFacturado, tipoTipoComprobante).IdTipoEstado
         Dim idEstadoNuevo As String = Publicos.EstadoPedidoPendiente
         Dim idTipoEstadoNuevo As String = New EstadosPedidos(da).GetUno(idEstadoNuevo, tipoTipoComprobante).IdTipoEstado
         Dim fechaNuevoEstado As DateTime = Now
         For Each dr As DataRow In pedidosEstados.Rows

            idEstadoAnterior = dr("IdEstado").ToString()
            idTipoEstadoAnterior = _cache.BuscaEstadosPedido(idEstadoAnterior, tipoTipoComprobante).IdTipoEstado

            If oVentas.TipoComprobante.AlInvocarPedidoAfectaFactura Then
               sqlPE.PedidosEstados_U_Anular_Fact(Integer.Parse(dr("IdSucursal").ToString()),
                                 dr("IdTipoComprobante").ToString(),
                                 dr("Letra").ToString(),
                                 Short.Parse(dr("CentroEmisor").ToString()),
                                 Long.Parse(dr("NumeroPedido").ToString()),
                                 dr("IdProducto").ToString(),
                                 Date.Parse(dr("FechaEstado").ToString()),
                                 Integer.Parse(dr("Orden").ToString()))
            End If

            If oVentas.TipoComprobante.AlInvocarPedidoAfectaRemito Then
               sqlPE.PedidosEstados_U_Anular_Remito(Integer.Parse(dr("IdSucursal").ToString()),
                                 dr("IdTipoComprobante").ToString(),
                                 dr("Letra").ToString(),
                                 Short.Parse(dr("CentroEmisor").ToString()),
                                 Long.Parse(dr("NumeroPedido").ToString()),
                                 dr("IdProducto").ToString(),
                                 Date.Parse(dr("FechaEstado").ToString()),
                                 Integer.Parse(dr("Orden").ToString()))
            End If

            If oVentas.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
               sqlPE.PedidosEstados_U_Anular_Estado(Integer.Parse(dr("IdSucursal").ToString()),
                                          dr("IdTipoComprobante").ToString(),
                                          dr("Letra").ToString(),
                                          Short.Parse(dr("CentroEmisor").ToString()),
                                          Long.Parse(dr("NumeroPedido").ToString()),
                                          dr("IdProducto").ToString(),
                                          Date.Parse(dr("FechaEstado").ToString()),
                                          Integer.Parse(dr("Orden").ToString()),
                                          idEstadoNuevo,
                                          tipoTipoComprobante,
                                          fechaNuevoEstado,
                                          "Factura anulada")

               rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(dr("IdSucursal").ToString()),
                                                               dr("IdTipoComprobante").ToString(),
                                                               dr("Letra").ToString(),
                                                               Short.Parse(dr("CentroEmisor").ToString()),
                                                               Long.Parse(dr("NumeroPedido").ToString()),
                                                               dr("IdProducto").ToString(),
                                                               Integer.Parse(dr("Orden").ToString()),
                                                               idTipoEstadoAnterior,
                                                               idTipoEstadoNuevo,
                                                               Decimal.Parse(dr("CantEntregada").ToString()))

               rPE.ReservaProducto(Integer.Parse(dr("IdSucursal").ToString()),
                                   dr("IdTipoComprobante").ToString(),
                                   dr("Letra").ToString(),
                                   Integer.Parse(dr("CentroEmisor").ToString()),
                                   Long.Parse(dr("NumeroPedido").ToString()),
                                   dr("IdProducto").ToString(),
                                   Integer.Parse(dr("Orden").ToString()),
                                   idEstadoAnterior,
                                   idEstadoNuevo,
                                   tipoTipoComprobante,
                                   Decimal.Parse(dr("cantEntregada").ToString()),
                                   Entidades.Entidad.MetodoGrabacion.Automatico,
                                   idFuncion, 0, 0,
                                   If(String.IsNullOrEmpty(dr("IdDepositoAnterior").ToString()), 1, Integer.Parse(dr("IdDepositoAnterior").ToString())),
                                   If(String.IsNullOrEmpty(dr("IdUbicacionAnterior").ToString()), 1, Integer.Parse(dr("IdUbicacionAnterior").ToString())))

               fechaNuevoEstado = fechaNuevoEstado.AddSeconds(1)
            End If            'If oVentas.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
         Next

         Dim rVentasCajeros As Reglas.VentasCajeros = New VentasCajeros(da)
         Dim oVentaCajero = Entidades.VentaCajero.FromVenta(oVentas)
         rVentasCajeros._Borrar(oVentaCajero)
         '--------------------------------------------------
         'If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea AndAlso
         If Publicos.TieneModuloContabilidad And oVentas.TipoComprobante.GeneraContabilidad AndAlso
            oVentas.IdEjercicio.HasValue AndAlso oVentas.IdPlanCuenta.HasValue AndAlso oVentas.IdAsiento.HasValue Then
            Dim ctbl As Contabilidad = New Contabilidad(da)
            ctbl.AnularAsiento(oVentas.IdEjercicio.Value, oVentas.IdPlanCuenta.Value, oVentas.IdAsiento.Value, Today)
         End If


         '--------------------------------------
         Dim ReservaPasajero As Reglas.ReservasTurismoPasajeros = New Reglas.ReservasTurismoPasajeros(da)

         ReservaPasajero.ActualizarReservasPasajeros(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante,
                                       oVentas.CentroEmisor, oVentas.NumeroComprobante)



         If abreConexion Then Me.da.CommitTransaction()

      Catch ex As Exception
         If abreConexion Then Me.da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         If abreConexion Then Me.da.CloseConection()
      End Try
   End Sub

   Public Sub EliminaComprobantes(comprobantes As List(Of Entidades.Venta))
      For Each compro In comprobantes

         If Publicos.TieneModuloContabilidad And compro.TipoComprobante.GeneraContabilidad Then
            Dim ctblEjercicio = New ContabilidadEjercicios(da)
            ctblEjercicio.EstaPeriodoCerrado(compro.Fecha)
         End If

         'Actualiza la numeración si es el ultimo numero
         Dim oventasNumeros = New VentasNumeros(da)
         Dim VentaNumero = New Entidades.VentaNumero()

         Dim ultimoNumero = oventasNumeros.GetUltimoNumero(compro.IdSucursal, compro.TipoComprobante.IdTipoComprobante,
                                compro.LetraComprobante, compro.CentroEmisor)

         If ultimoNumero = compro.NumeroComprobante Then
            Dim compAnterior = oventasNumeros.GetCompAnterior(compro.IdSucursal, compro.IdTipoComprobante, compro.LetraComprobante,
                                                              compro.CentroEmisor, compro.NumeroComprobante)
            For Each dr In compAnterior.AsEnumerable()
               With VentaNumero
                  .IdSucursal = compro.IdSucursal
                  .IdTipoComprobante = compro.IdTipoComprobante
                  .LetraFiscal = compro.LetraComprobante
                  .CentroEmisor = compro.CentroEmisor
                  .Numero = Long.Parse(dr("NumeroComprobante").ToString())
                  .Fecha = Date.Parse(dr("Fecha").ToString())
               End With
               oventasNumeros.ActualizarNumero(VentaNumero)
            Next
         End If

         Dim rVentasCajeros = New VentasCajeros(da)
         Dim oVentaCajero = Entidades.VentaCajero.FromVenta(compro)
         rVentasCajeros._Borrar(oVentaCajero)

         'Borrar los Movimientos (Remitos SI Los GENERA, Presupuesto NO
         EjecutaSP(compro, TipoSP._D, Entidades.Entidad.MetodoGrabacion.Manual, "")
      Next
   End Sub

   Private Sub AnulaEliminaComprobantes(comprobantes As List(Of Entidades.Venta),
                                        MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      For Each Comprobante As Entidades.Venta In comprobantes

         Me.AnularComprobante(Comprobante, MetodoGrabacion, IdFuncion)

         'Actualiza la numeración si es el ultimo numero
         Dim oventasNumeros As Reglas.VentasNumeros = New Reglas.VentasNumeros(da)
         Dim VentaNumero As Entidades.VentaNumero = New Entidades.VentaNumero()

         Dim ultimoNumero As Long = oventasNumeros.GetUltimoNumero(Comprobante.IdSucursal, Comprobante.TipoComprobante.IdTipoComprobante,
                                        Comprobante.LetraComprobante, Comprobante.CentroEmisor)

         If ultimoNumero = Comprobante.NumeroComprobante Then
            Dim compAnterior As DataTable
            compAnterior = oventasNumeros.GetCompAnterior(Comprobante.IdSucursal, Comprobante.IdTipoComprobante, Comprobante.LetraComprobante,
                                           Comprobante.CentroEmisor, Comprobante.NumeroComprobante)
            For Each dr As DataRow In compAnterior.Rows
               With VentaNumero
                  .IdSucursal = Comprobante.IdSucursal
                  .IdTipoComprobante = Comprobante.IdTipoComprobante
                  .LetraFiscal = Comprobante.LetraComprobante
                  .CentroEmisor = Comprobante.CentroEmisor
                  .Numero = Long.Parse(dr("NumeroComprobante").ToString())
                  .Fecha = Date.Parse(dr("Fecha").ToString())
               End With
               oventasNumeros.ActualizarNumero(VentaNumero)
            Next

         End If

         'Borrar los Movimientos (Remitos SI Los GENERA, Presupuesto NO

         Me.EjecutaSP(Comprobante, TipoSP._D, Entidades.Entidad.MetodoGrabacion.Manual, "")

      Next
   End Sub

   Public Sub EliminarComprobantes(comprobantes As List(Of Entidades.Venta))
      EjecutaConTransaccion(Sub() EliminaComprobantes(comprobantes))
   End Sub

   Public Sub EliminarVentas(comprobantes As List(Of Entidades.Venta))

      'Primero valido si puedo anular todo Poruqe despues las transacciones son Individuales (no funciona de otra forma).
      'El riesgo es que alguien saque un pago o algo.
      For Each oComprobante As Entidades.Venta In comprobantes

         Try

            'Si el tipo de pago es cuenta corriente tengo que grabar en las tablas de Cuentas Corrientes
            If oComprobante.TipoComprobante.ActualizaCtaCte Then
               If oComprobante.FormaPago.Dias > 0 Then
                  If Publicos.TieneModuloCuentaCorrienteClientes Then  ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCUENTACORRIENTECLIENTES)) Then

                     'Chequeo si el comprobante tiene algun pago aplicado.

                     Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)
                     Dim ComprobCtaCte As Entidades.CuentaCorriente

                     ComprobCtaCte = oCtaCte._GetUna(oComprobante.IdSucursal,
                                                      oComprobante.TipoComprobante.IdTipoComprobante,
                                                      oComprobante.LetraComprobante,
                                                      oComprobante.CentroEmisor,
                                                      oComprobante.NumeroComprobante)

                     'Si es NCRED viene dado vuelta, tengo que volver a cambiarlo.
                     If ComprobCtaCte.ImporteTotal * oComprobante.TipoComprobante.CoeficienteValores <> ComprobCtaCte.Saldo Then
                        Dim Mensaje As String
                        Mensaje = "ATENCION: El Comprobante '"
                        Mensaje = Mensaje & oComprobante.TipoComprobante.Descripcion.Trim() & " "
                        Mensaje = Mensaje & oComprobante.LetraComprobante & " "
                        Mensaje = Mensaje & oComprobante.CentroEmisor.ToString("0000") & "-"
                        Mensaje = Mensaje & oComprobante.NumeroComprobante.ToString("00000000")
                        Mensaje = Mensaje & "' tiene algun(os) pago(s) relacionado(s), primero debe Anularlo(s)."

                        Throw New Exception(Mensaje)
                     End If

                  End If
               End If
            End If

            'si es Contado verifico si tiene el modulo de Caja, asi grabo los movimientos
            If oComprobante.FormaPago.Dias = 0 Then
               'si el cliente compro el modulo de caja
               If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then
                  'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
                  'ya que si es un cliente que tiene fichas y despues factura por aca se complica
                  If oComprobante.TipoComprobante.AfectaCaja And oComprobante.Cheques.Count > 0 Then

                     Dim oCheques As List(Of Entidades.Cheque)

                     'oCheques = New Reglas.Cheques(da).GetPorComprobante(oVentas.IdSucursal, oVentas.NumeroPlanilla, oVentas.NumeroMovimiento, False)
                     oCheques = New Reglas.Cheques(da).GetPorComprobante(oComprobante.IdSucursal, oComprobante.TipoComprobante.IdTipoComprobante, oComprobante.LetraComprobante, Short.Parse(oComprobante.CentroEmisor.ToString()), oComprobante.NumeroComprobante)

                     Dim Cont As Integer = 0

                     For Cont = 1 To oCheques.Count
                        If oCheques.Item(Cont - 1).NroMovimientoEgreso > 0 Then
                           Dim Mensaje As String
                           Mensaje = "ATENCION: el Comprobante tiene al menos este cheque entregado, NO puede ELIMINARLO..."
                           Mensaje = Mensaje & Chr(13) & Chr(13)
                           Mensaje = Mensaje & "Banco: " & oCheques.Item(Cont - 1).Banco.NombreBanco & " / "
                           Mensaje = Mensaje & "Suc. Bco: " & oCheques.Item(Cont - 1).IdBancoSucursal.ToString() & " / "
                           Mensaje = Mensaje & "Loc. Bco: " & oCheques.Item(Cont - 1).Localidad.NombreLocalidad & " / "
                           Mensaje = Mensaje & "Numero Cheq.: " & oCheques.Item(Cont - 1).NumeroCheque.ToString()

                           Throw New Exception(Mensaje)
                        End If
                     Next

                  End If
               End If
            End If

         Catch ex As Exception
            Throw ex
         End Try

      Next

      For Each oComprobante As Entidades.Venta In comprobantes

         Try

            da.OpenConection()
            da.BeginTransaction()

            ''Si el tipo de pago es cuenta corriente tengo que grabar en las tablas de Cuentas Corrientes
            'If oComprobante.TipoComprobante.ActualizaCtaCte Then
            '   If oComprobante.FormaPago.Dias > 0 Then
            '      If Boolean.Parse(New Reglas.Parametros().GetValor("MODULOCUENTACORRIENTECLIENTES")) Then

            '         'Chequeo si el comprobante tiene algun pago aplicado.

            '         Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)
            '         Dim ComprobCtaCte As Entidades.CuentaCorriente

            '         ComprobCtaCte = oCtaCte.GetUna(oComprobante.IdSucursal, _
            '                                        oComprobante.TipoComprobante.IdTipoComprobante, _
            '                                        oComprobante.LetraComprobante, _
            '                                        oComprobante.CentroEmisor, _
            '                                        oComprobante.NumeroComprobante)

            '         'Si es NCRED viene dado vuelta, tengo que volver a cambiarlo.
            '         If ComprobCtaCte.ImporteTotal * oComprobante.TipoComprobante.CoeficienteValores <> ComprobCtaCte.Saldo Then
            '            Dim Mensaje As String
            '            Mensaje = "ATENCION: El Comprobante '"
            '            Mensaje = Mensaje & oComprobante.TipoComprobante.Descripcion.Trim() & " "
            '            Mensaje = Mensaje & oComprobante.LetraComprobante & " "
            '            Mensaje = Mensaje & oComprobante.CentroEmisor.ToString("0000") & "-"
            '            Mensaje = Mensaje & oComprobante.NumeroComprobante.ToString("00000000")
            '            Mensaje = Mensaje & "' tiene algun(os) pago(s) relacionado(s), primero debe Anularlo(s)."

            '            Throw New Exception(Mensaje)
            '         End If

            '      End If
            '   End If
            'End If

            ''si es Contado verifico si tiene el modulo de Caja, asi grabo los movimientos
            'If oComprobante.FormaPago.Dias = 0 Then
            '   'si el cliente compro el modulo de caja
            '   If Boolean.Parse(New Reglas.Parametros().GetValor("MODULOCAJA")) Then
            '      'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
            '      'ya que si es un cliente que tiene fichas y despues factura por aca se complica
            '      If oComprobante.TipoComprobante.AfectaCaja And oComprobante.Cheques.Count > 0 Then

            '         Dim oCheques As List(Of Entidades.Cheque)

            '         'oCheques = New Reglas.Cheques(da).GetPorComprobante(oVentas.IdSucursal, oVentas.NumeroPlanilla, oVentas.NumeroMovimiento, False)
            '         oCheques = New Reglas.Cheques(da).GetPorComprobante(oComprobante.IdSucursal, oComprobante.TipoComprobante.IdTipoComprobante, oComprobante.LetraComprobante, Short.Parse(oComprobante.CentroEmisor.ToString()), oComprobante.NumeroComprobante)

            '         Dim Cont As Integer = 0

            '         For Cont = 1 To oCheques.Count
            '            If oCheques.Item(Cont - 1).NroMovimientoEgreso > 0 Then
            '               Dim Mensaje As String
            '               Mensaje = "ATENCION: el Comprobante tiene al menos este cheque entregado, NO puede ELIMINARLO..."
            '               Mensaje = Mensaje & Chr(13) & Chr(13)
            '               Mensaje = Mensaje & "Banco: " & oCheques.Item(Cont - 1).Banco.NombreBanco & " / "
            '               Mensaje = Mensaje & "Suc. Bco: " & oCheques.Item(Cont - 1).IdBancoSucursal.ToString() & " / "
            '               Mensaje = Mensaje & "Loc. Bco: " & oCheques.Item(Cont - 1).Localidad.NombreLocalidad & " / "
            '               Mensaje = Mensaje & "Numero Cheq.: " & oCheques.Item(Cont - 1).NumeroCheque.ToString()

            '               Throw New Exception(Mensaje)
            '            End If
            '         Next

            '      End If
            '   End If
            'End If

            If oComprobante.TipoComprobante.ActualizaCtaCte Then
               If oComprobante.FormaPago.Dias > 0 Then
                  If Publicos.TieneModuloCuentaCorrienteClientes Then ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCUENTACORRIENTECLIENTES)) Then

                     Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)

                     oComprobante.CuentaCorriente = oCtaCte._GetUna(oComprobante.IdSucursal,
                                                               oComprobante.TipoComprobante.IdTipoComprobante,
                                                               oComprobante.LetraComprobante,
                                                               oComprobante.CentroEmisor,
                                                               oComprobante.NumeroComprobante)

                     oCtaCte.EliminarCuentaCorriente(oComprobante.CuentaCorriente)
                  End If
               End If
            End If

            ''Si es Contado verifico si tiene el modulo de Caja, hago un contrasiento
            'If oComprobante.FormaPago.Dias = 0 Then
            '   'si el cliente compro el modulo de caja
            '   If Boolean.Parse(New Reglas.Parametros().GetValor("MODULOCAJA")) Then
            '      'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
            '      'ya que si es un cliente que tiene fichas y despues factura por aca se complica
            '      If oComprobante.TipoComprobante.AfectaCaja Then
            '         Dim deta As Entidades.CajaDetalles = New Entidades.CajaDetalles(oComprobante.IdSucursal, oComprobante.Usuario, oComprobante.Password)
            '         Dim caj As Reglas.Cajas = New Reglas.Cajas(da)
            '         Dim ctaCaj As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas(da)
            '         Dim cajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)

            '         With deta
            '            .FechaMovimiento = DAte.Now
            '            .IdSucursal = oComprobante.IdSucursal

            '            'Invierto el tipo de movimiento.
            '            If oComprobante.TipoComprobante.CoeficienteValores = 1 Then
            '               .IdTipoMovimiento = "E"c
            '            Else
            '               .IdTipoMovimiento = "I"c
            '            End If

            '            .NumeroPlanilla = caj.GetPlanillaActual(oComprobante.IdSucursal).NumeroPlanilla
            '            .Observacion = Strings.Left("ELIMINA " & oComprobante.TipoComprobante.DescripcionAbrev & " " & oComprobante.LetraComprobante & " " & oComprobante.Impresora.CentroEmisor.ToString() & "-" & oComprobante.NumeroComprobante.ToString("00000000") & IIf(oComprobante.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + oComprobante.Cheques.Count.ToString(), "").ToString() & ". " & oComprobante.Cliente.NombreCliente, 100)
            '            .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTAS"))
            '            'me fijo si es Efectivo o Tarjeta para cargar el tipo de cuenta en la caja
            '            .ImportePesos = oComprobante.ImportePesos * oComprobante.TipoComprobante.CoeficienteValores
            '            .ImporteTarjetas = oComprobante.ImporteTarjetas * oComprobante.TipoComprobante.CoeficienteValores
            '            .ImporteTickets = oComprobante.ImporteTickets * oComprobante.TipoComprobante.CoeficienteValores
            '            .ImporteCheques = oComprobante.ImporteCheques * oComprobante.TipoComprobante.CoeficienteValores
            '            .EsModificable = False
            '         End With

            '         cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(oComprobante.Cheques), Nothing)

            '         oComprobante.NumeroPlanilla = deta.NumeroPlanilla

            '         If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTASACUMULA")) Then
            '            deta = cajaDet.GetUltimoMovVenta(deta.IdSucursal, deta.NumeroPlanilla, deta.IdCuentaCaja)
            '         End If

            '         oComprobante.NumeroMovimiento = deta.NumeroMovimiento

            '         Me.ActualizaMovimientoCaja(oComprobante)

            '      End If
            '   End If
            'End If

            Dim MovVent As New MovimientosStock(da)

            'Borro los Movimientos de Stock (Cabecera y Detalle)
            MovVent.EliminarPorComprobante(oComprobante.IdSucursal,
                                           oComprobante.TipoComprobante.IdTipoComprobante,
                                           oComprobante.LetraComprobante,
                                           Short.Parse(oComprobante.CentroEmisor.ToString()),
                                           oComprobante.NumeroComprobante)

            'Borro el Comprobante (Cabecera, Detalle y Cheques)
            Me.EjecutaSP(oComprobante, TipoSP._D, Entidades.Entidad.MetodoGrabacion.Manual, "")


            'Quito el Saldo de la Venta.
            If oComprobante.TipoComprobante.GrabaLibro Then

               Dim oPF = New Reglas.PeriodosFiscales(da)

               Dim PeriodoFiscal As Integer = Integer.Parse(oComprobante.Fecha.ToString("yyyyMM"))
               Dim Neto As Decimal = oComprobante.Subtotal
               Dim IVA As Decimal = oComprobante.TotalIVA

               oPF.ActualizarPosicion(actual.Sucursal.IdEmpresa, PeriodoFiscal, Neto * (-1), IVA * (-1), oComprobante.ImporteTotal * (-1), 0, 0, 0, 0, 0)

            End If
            '--------------------------------------------------------------

            da.CommitTransaction()

         Catch ex As Exception
            da.RollbakTransaction()
            Throw ex
         Finally
            da.CloseConection()
         End Try

      Next

   End Sub

   Protected Overridable Sub OnBeforeAnulaEliminaComprobantes(idSucursal As Integer,
                                                              idTipoComprobanteOrigen As String, letraOrigen As String, centroEmisorOrigen As Integer, numeroComprobanteOrigen As Long,
                                                              idTipoComprobanteDestino As String, letraDestino As String, centroEmisorDestino As Integer, numeroComprobanteDestino As Long)
   End Sub

   Public Sub AnularComprobantesSinEmitir(entidad As Eniac.Entidades.Entidad, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      Dim oVentas As Entidades.Venta = DirectCast(entidad, Entidades.Venta)

      Try

         Dim oVentasNumeros As New Reglas.VentasNumeros
         Dim PrimerNumero As Long
         Dim NumeroTope As Long
         Dim Cont As Long

         da.OpenConection()
         da.BeginTransaction()

         PrimerNumero = oVentasNumeros.GetProximoNumero(_cache.BuscaSucursal(oVentas.IdSucursal),
                                             oVentas.TipoComprobante.IdTipoComprobante,
                                             oVentas.LetraComprobante,
                                             oVentas.Impresora.CentroEmisor)

         NumeroTope = oVentas.NumeroComprobante

         'Necesito leerlo el count para forzar su generacion y que no de error despues(siempre sera en cero).
         Dim ImpCheques As Decimal
         If oVentas.Cheques.Count > 0 Then
            ImpCheques = oVentas.ImporteCheques
         End If
         '------------------------------------------

         For Cont = PrimerNumero To NumeroTope

            oVentas.NumeroComprobante = Cont
            Me.EjecutaSP(oVentas, TipoSP._I, MetodoGrabacion, IdFuncion)

         Next

         Me.ActualizarNumerosVentas(oVentas.IdSucursal,
                                    oVentas.TipoComprobante.IdTipoComprobante,
                                    oVentas.LetraComprobante,
                                    oVentas.Impresora.CentroEmisor,
                                    oVentas.NumeroComprobante,
                                    oVentas.Fecha)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
#End Region

#Region "Facturar PEDIDOS"

   Private Sub FacturarPedidos(oVenta As Entidades.Venta, idFuncion As String)
      Try
         Dim tipoTipoComprobante = "PEDIDOSCLIE"

         Dim idEstadoAnterior = Publicos.EstadoPedidoPendiente
         Dim idEstadoNuevo = Publicos.EstadoPedidoFacturado

         Dim idSucursalParaBuscarPedido = If(Publicos.Facturacion.FacturacionInvocarPedidosDeOtrasSucursales, 0, oVenta.IdSucursal)

         ' para cada producto de la factura busco los pedidos pendientes.
         Dim cont As Integer = 0
         For Each vProd As Entidades.VentaProducto In oVenta.VentasProductos

            Dim idCliente As Long = oVenta.Cliente.IdCliente

            Dim pedidos As Entidades.IPKComprobante() = {}

            If Publicos.Facturacion.FacturarPedidoSeleccionado Then
               'pedidos = oVenta.Facturables.ToArray()
               pedidos = oVenta.Invocados.Where(Function(vv) TypeOf (vv.Invocado) Is Entidades.IPKComprobante).ToList().
                                    ConvertAll(Function(i) DirectCast(i.Invocado, Entidades.IPKComprobante)).ToArray()

               Dim idClientes = oVenta.Invocados.Where(Function(x) x.Invocado.IdCliente <> 0).ToList().ConvertAll(Function(x) x.Invocado.IdCliente).ToArray()
               If idClientes.Count > 0 Then
                  idCliente = idClientes(0)
               End If
            End If

            Dim alInvocarPedidoAfectaFactura = oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura
            Dim alInvocarPedidoAfectaRemito = oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito
            Dim invocarPedidosConEstadoEspecifico = oVenta.TipoComprobante.InvocarPedidosConEstadoEspecifico
            Dim idProducto = vProd.IdProducto

            Dim rPE = New PedidosEstados(da)
            rPE.ConsumirPedido(oVenta.Fecha, oVenta.NumeroReparto, tipoTipoComprobante,
                               idEstadoAnterior, idEstadoNuevo, "Facturación Automática",
                               idProducto, vProd.Cantidad, idCliente, pedidos, idSucursalParaBuscarPedido,
                               alInvocarPedidoAfectaFactura, alInvocarPedidoAfectaRemito, invocarPedidosConEstadoEspecifico,
                               oVenta.IdSucursal, oVenta.IdTipoComprobante, oVenta.LetraComprobante, oVenta.CentroEmisor, oVenta.NumeroComprobante,
                               anulacionPorModificacion:=False,
                               idFuncion, cont, _cache)
         Next
      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub ActualizaDesaplicaFacturables(idSucursal As Integer,
                                             idTipoComprobanteFact As String,
                                             letraFact As String,
                                             centroEmisorFact As Integer,
                                             numeroComprobanteFact As Long)
      'Dim sql = New SqlServer.Ventas(da)
      'sql.Ventas_Desaplica_Facturables_U(idSucursal, idTipoComprobanteFact, letraFact, centroEmisorFact, numeroComprobanteFact)

      Dim sqlC = New SqlServer.Compras(da)
      sqlC.LiberarInvocadosVenta(idSucursal, idTipoComprobanteFact, letraFact, Convert.ToInt16(centroEmisorFact), numeroComprobanteFact)

      Dim rVV = New VentasInvocados(da)
      rVV._Borrar(idSucursal, idTipoComprobanteFact, letraFact, centroEmisorFact, numeroComprobanteFact)

   End Sub

   Private Sub ActualizaCantidadLotes(idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Integer,
                                       numeroComprobante As Long)
      Try

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_ActualizaCantidadLotes(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      Catch ex As Exception
         Throw ex
      End Try

   End Sub

   'Actualiza la Comision Del Vendedor. Se calcula a partir del detalle que quitó impuestos y aplicando todos los descuentos.
   Private Sub ActualizaComisionVendedor(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroComprobante As Long)
      Try

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_ActualizaComisionVendedor(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      Catch ex As Exception
         Throw ex
      End Try

   End Sub

   Private Sub ActualizaMovimientoCaja(ent As Entidades.Venta)
      Try

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_MovimientoCaja_U(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.LetraComprobante,
                                       ent.Impresora.CentroEmisor, ent.NumeroComprobante, ent.IdCaja, ent.NumeroPlanilla, ent.NumeroMovimiento)

      Catch
         Throw
      End Try
   End Sub

   Private Sub ActualizaPlanillaCaja(ent As Entidades.Venta)
      Try

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_PlanillaCaja_U(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.LetraComprobante,
                                       ent.Impresora.CentroEmisor, ent.NumeroComprobante, ent.IdCaja, ent.NumeroPlanilla)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub


   Private Sub GrabaImpuestosVenta(oVentas As Entidades.Venta)
      'grabo los impuestos de ventas (IVA)
      Dim rVentImpu = New VentasImpuestos(da)
      For Each vi As Entidades.VentaImpuesto In oVentas.VentasImpuestos
         If vi.Importe = 0 And vi.Bruto = 0 And vi.Neto = 0 And vi.Total = 0 Then Continue For
         rVentImpu._Insertar(vi)
      Next

      'grabo los Otros impuestos de ventas (Percepciones)
      For Each vi As Entidades.VentaImpuesto In oVentas.ImpuestosVarios
         rVentImpu._Insertar(vi)
      Next

      'grabo las retenciones
      Dim rPercepVenta = New Reglas.PercepcionVentas(da)
      Dim rVentaPercep = New Reglas.VentasPercepciones(da)
      Dim sqlPercepVenta As SqlServer.VentasPercepciones = New SqlServer.VentasPercepciones(da)

      oVentas.Percepciones.Clear() ''.RemoveAll(Function(x) x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB.ToString())
      ' relaciono las retenciones con los comprobantes
      For Each impuesto As Entidades.VentaImpuesto In oVentas.ImpuestosVarios
         Dim percep = New Entidades.PercepcionVenta()
         If impuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB Then

            percep.IdSucursal = impuesto.IdSucursal
            percep.TipoImpuesto = impuesto.TipoImpuesto
            percep.EmisorPercepcion = impuesto.CentroEmisor
            percep.NumeroPercepcion = rPercepVenta.GetProximoNumero(percep.IdSucursal, percep.TipoImpuesto.IdTipoImpuesto, percep.EmisorPercepcion)
            percep.Cliente = oVentas.Cliente
            percep.FechaEmision = oVentas.Fecha

            'traer la base imponible
            percep.BaseImponible = impuesto.Neto ' oVentas.Percepciones.BaseImponible

            percep.ImporteTotal = impuesto.Importe
            If oVentas.IdActividad = 0 Then
               Dim actcli As DataTable = New Reglas.ClientesActividades().GetClientesActividades(oVentas.Cliente.IdCliente)
               For Each dr As DataRow In actcli.Rows
                  percep.IdActividad = impuesto.IdActividad  ' Integer.Parse(dr("IdActividad").ToString())
                  percep.IdProvincia = impuesto.IdProvincia
                  Exit For
               Next
            Else
               percep.IdActividad = oVentas.IdActividad
               percep.IdProvincia = impuesto.IdProvincia
            End If

            percep.Alicuota = impuesto.Alicuota ' New Reglas.Actividades().GetUno(percep.IdProvincia, percep.IdActividad).Porcentaje
            percep.IdEstado = Entidades.Retencion.Estados.APLICADO
            percep.Caja.IdCaja = oVentas.IdCaja
            percep.NroPlanillaIngreso = oVentas.NumeroPlanilla
            percep.NroMovimientoIngreso = oVentas.NumeroMovimiento
            rPercepVenta.EjecutaSP(percep, TipoSP._I)
            rVentaPercep.Insertar(oVentas, percep)
            'sqlPercepVenta.VentasPercepciones_I(percep.IdSucursal,
            '                                    oVentas.TipoComprobante.IdTipoComprobante,
            '                                    oVentas.LetraComprobante,
            '                                    oVentas.CentroEmisor,
            '                                    oVentas.NumeroComprobante,
            '                                    percep.TipoImpuesto.IdTipoImpuesto,
            '                                    percep.EmisorPercepcion,
            '                                    percep.NumeroPercepcion)

            oVentas.Percepciones.Add(percep)
         ElseIf impuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA Then
            percep.IdSucursal = impuesto.IdSucursal
            percep.TipoImpuesto = impuesto.TipoImpuesto
            percep.EmisorPercepcion = impuesto.CentroEmisor
            percep.NumeroPercepcion = rPercepVenta.GetProximoNumero(percep.IdSucursal, percep.TipoImpuesto.IdTipoImpuesto, percep.EmisorPercepcion)
            percep.Cliente = oVentas.Cliente
            percep.FechaEmision = oVentas.Fecha

            'traer la base imponible
            percep.BaseImponible = impuesto.Neto ' oVentas.Percepciones.BaseImponible

            percep.ImporteTotal = impuesto.Importe
            If impuesto.IdRegimenPercepcion <> 0 Then
               percep.RegimenPercepcion = New RegimenesPercepciones(da).GetUno(impuesto.IdTipoImpuesto, impuesto.IdRegimenPercepcion)
            End If

            percep.Alicuota = impuesto.Alicuota ' New Reglas.Actividades().GetUno(percep.IdProvincia, percep.IdActividad).Porcentaje
            percep.IdEstado = Entidades.Retencion.Estados.APLICADO
            percep.Caja.IdCaja = oVentas.IdCaja
            percep.NroPlanillaIngreso = oVentas.NumeroPlanilla
            percep.NroMovimientoIngreso = oVentas.NumeroMovimiento


            If (oVentas.TipoComprobante.GrabaLibro And oVentas.TipoComprobante.EsComercial) Or oVentas.TipoComprobante.EsPreElectronico Then
               rPercepVenta.EjecutaSP(percep, TipoSP._I)
               rVentaPercep.Insertar(oVentas, percep)
            End If

         End If
      Next

      ''''For Each perVta In oVentas.Percepciones.Where(Function(x) x.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA.ToString())
      ''''   Dim percepVta = New Entidades.PercepcionVenta()
      ''''   percepVta.IdSucursal = oVentas.IdSucursal
      ''''   percepVta.TipoImpuesto = perVta.TipoImpuesto
      ''''   percepVta.EmisorPercepcion = oVentas.CentroEmisor
      ''''   If perVta.NumeroPercepcion = 0 Then
      ''''      percepVta.NumeroPercepcion = rPercepVenta.GetProximoNumero(percep.IdSucursal, percep.TipoImpuesto.IdTipoImpuesto, percep.EmisorPercepcion)
      ''''   Else
      ''''      percepVta.NumeroPercepcion = perVta.NumeroPercepcion
      ''''   End If
      ''''   percepVta.Cliente = oVentas.Cliente
      ''''   percepVta.FechaEmision = oVentas.Fecha


      ''''   percepVta.BaseImponible = perVta.BaseImponible

      ''''   percepVta.ImporteTotal = perVta.ImporteTotal
      ''''   percepVta.RegimenPercepcion = perVta.RegimenPercepcion

      ''''   percepVta.Alicuota = perVta.Alicuota
      ''''   percepVta.IdEstado = Entidades.Retencion.Estados.APLICADO
      ''''   percepVta.Caja.IdCaja = oVentas.IdCaja
      ''''   percepVta.NroPlanillaIngreso = oVentas.NumeroPlanilla
      ''''   percepVta.NroMovimientoIngreso = oVentas.NumeroMovimiento

      ''''   rPercepVenta.EjecutaSP(percepVta, TipoSP._I)
      ''''   rVentaPercep.Insertar(oVentas, percepVta)
      ''''   Dim vi = New Entidades.VentaImpuesto With {
      ''''          .Venta = oVentas,
      ''''          .IdSucursal = oVentas.IdSucursal,
      ''''          .TipoComprobante = oVentas.TipoComprobante,
      ''''          .Letra = oVentas.LetraComprobante,
      ''''          .CentroEmisor = oVentas.CentroEmisor,
      ''''          .NumeroComprobante = oVentas.NumeroComprobante,
      ''''          .TipoImpuesto = percepVta.TipoImpuesto,
      ''''          .Alicuota = percepVta.Alicuota,
      ''''          .Bruto = 0,
      ''''          .Neto = perVta.BaseImponible,
      ''''          .Importe = perVta.ImporteTotal,
      ''''          .Total = perVta.BaseImponible + perVta.ImporteTotal,
      ''''          .IdProvincia = ""
      ''''      }

      ''''   rVentImpu._Insertar(vi)
      ''''Next

   End Sub
   Private Sub ActualizoInfoDeCheques(oVentas As Entidades.Venta)
      Dim sqlVentasCheq As SqlServer.VentasCheques = New SqlServer.VentasCheques(da)
      Dim sqlCheques As SqlServer.Cheques = New SqlServer.Cheques(da)
      'graba los cheques de la venta y su relacion
      For Each ch As Entidades.Cheque In oVentas.Cheques
         'si el cheque no existe lo ingreso a las tablas del sistema
         If Not sqlCheques.Existe(oVentas.IdSucursal, ch.NumeroCheque, ch.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.Cuit) Then

            Dim rCheques As Reglas.Cheques = New Reglas.Cheques(da)
            rCheques._Inserta(ch)
            'sqlCheques.Cheques_I(oVentas.IdSucursal, ch.IdCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad,
            '                        ch.NumeroCheque, ch.FechaEmision, ch.FechaCobro, ch.Titular, ch.Importe,
            '                        Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False, Nothing, ch.IdEstadoCheque,
            '                        oVentas.Cliente.IdCliente, 0, ch.Cuit, 0, actual.Nombre,
            '                        ch.IdTipoCheque, ch.NroOperacion)

         End If

         sqlVentasCheq.VentasCheques_I(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                              oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante,
                              ch.IdCheque)
      Next


      Dim sqlVentasCheqRech As SqlServer.VentasChequesRechazados = New SqlServer.VentasChequesRechazados(da)
      'Dim sqlLibroBanco As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)
      'graba los cheques de la venta y su relacion
      For Each ch As Entidades.Cheque In oVentas.ChequesRechazados

         sqlVentasCheqRech.VentasChequesRechazados_I(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                                                      oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                                                      oVentas.NumeroComprobante, ch.IdCheque)
         'SPC - Se saca según Pendiente 1775 - Cheque Rechazado: No debe dejar en cero el cheque en banco
         ''Si no estaba en banco, no afecta ningun registro
         'sqlLibroBanco.LibroBancos_UImporteCheque(oVentas.IdSucursal, ch.Banco.IdBanco, ch.IdBancoSucursal, _
         '                                          ch.Localidad.IdLocalidad, ch.NumeroCheque, 0)

         sqlCheques.Cheques_ActualizaEstado(oVentas.IdSucursal, ch.Banco.IdBanco, ch.IdBancoSucursal,
                                                   ch.Localidad.IdLocalidad, ch.NumeroCheque, Entidades.Cheque.Estados.RECHAZADO, actual.Nombre, ch.IdCheque)

      Next
   End Sub
   Private Sub ActualizoInfoDeTarjetas(oVentas As Entidades.Venta, idCaja As Integer, NroPlanilla As Integer, NroMovimiento As Integer)
      Dim sqlVentasTarjetas = New SqlServer.VentasTarjetas(da)
      Dim i = 0I

      Dim rTarjetasCupones = New TarjetasCupones(da)

      Dim rSituacionCupon = New SituacionCupones(da).GetPorDefecto()

      Dim coe = oVentas.TipoComprobante.CoeficienteValores
      For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas
         i += 1
         If tr.IdTarjetaCupon = 0 Then
            tr.IdTarjetaCupon = rTarjetasCupones.GetCodigoMaximo
         End If

         If Not rTarjetasCupones.Existe(tr.IdTarjetaCupon) Then
            rTarjetasCupones._Insertar(tr.IdTarjetaCupon,
                                    oVentas.IdSucursal,
                                    tr.Tarjeta.IdTarjeta,
                                    tr.Banco.IdBanco,
                                    tr.Monto * coe,
                                    tr.Cuotas,
                                    tr.NumeroLote,
                                    tr.NumeroCupon,
                                    Date.Now,
                                    Entidades.TarjetaCupon.Estados.ENCARTERA,
                                    idCaja,
                                    NroPlanilla,
                                    NroMovimiento,
                                    Nothing,
                                    Nothing,
                                    Nothing,
                                    actual.Nombre,
                                    Date.Now,
                                    oVentas.IdCliente,
                                    0, rSituacionCupon.IdSituacionCupon)
         Else
            rTarjetasCupones._ActualizaCupon(tr.IdTarjetaCupon, idCaja, NroPlanilla, NroMovimiento)
         End If
         If tr.Tarjeta.Acreditacion Then
            rTarjetasCupones.ActualizaEstado(tr.IdTarjetaCupon, Entidades.TarjetaCupon.Estados.ACREDITADO)
         End If
         If oVentas.TipoComprobante.CoeficienteValores = -1 Then
            rTarjetasCupones.ActualizaEstado(tr.IdTarjetaCupon, Entidades.TarjetaCupon.Estados.ANULADO, rTarjetasCupones.GetUno(tr.IdTarjetaCupon).IdEstadoTarjeta)
         End If

         sqlVentasTarjetas._Insertar(oVentas.IdSucursal,
                                    oVentas.TipoComprobante.IdTipoComprobante,
                                    oVentas.LetraComprobante,
                                    oVentas.CentroEmisor,
                                    oVentas.NumeroComprobante,
                                    tr.Tarjeta.IdTarjeta,
                                    tr.Banco.IdBanco,
                                    i,
                                    tr.Monto * coe,
                                    tr.Cuotas,
                                    tr.NumeroCupon,
                                    tr.NumeroLote,
                                    tr.IdTarjetaCupon)
      Next

   End Sub
   Private Sub RealizarContraMovimiento(oVentas As Entidades.Venta,
                                        MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      'solo si el tipo de comprobante afecta stock
      If oVentas.TipoComprobante.CoeficienteStock <> 0 Then
         Dim oCo = New Entidades.MovimientoStock()
         With oVentas
            oCo.IdSucursal = .Cliente.IdSucursalAsociada
            oCo.Sucursal.Id = .Cliente.IdSucursalAsociada
            oCo.Sucursal2.Id = .Cliente.IdSucursal
            oCo.FechaMovimiento = .Fecha
            oCo.Usuario = .Usuario
            oCo.TipoMovimiento = New TiposMovimientos(da).GetUno("REC-SUC")
            oCo.Observacion = String.Format("Automatico. Sucursal Origen: {0}. {1} {2} {3}-{4:00000000}{5}. {6}",
                                            actual.Sucursal.Nombre, oVentas.TipoComprobante.DescripcionAbrev, oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante,
                                            If(oVentas.Cheques.Any(), String.Format(" - Cantidad Cheq. Tercero: {0}", oVentas.Cheques.Count), ""), oVentas.Cliente.NombreCliente.Truncar(100))

            For Each vp In .VentasProductos
               Dim cp = New Entidades.MovimientoStockProducto()
               cp.ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(.Cliente.IdSucursalAsociada, vp.Producto.IdProducto)
               cp.Orden = vp.Orden
               cp.IdProducto = vp.Producto.IdProducto
               cp.Cantidad = vp.Cantidad * (oVentas.TipoComprobante.CoeficienteStock * -1)
               cp.Precio = vp.PrecioNeto
               cp.ProductosNrosSerie = vp.Producto.NrosSeries.ConvertAll(
                                             Function(pns)
                                                Return New Entidades.MovimientoStockProductoNrosSerie() With
                                                            {
                                                               .IdSucursal = oCo.IdSucursal,
                                                               .IdTipoMovimiento = oCo.TipoMovimiento.IdTipoMovimiento,
                                                               .NumeroMovimiento = oCo.NumeroMovimiento,
                                                               .Orden = cp.Orden,
                                                               .IdProducto = pns.Producto.IdProducto,
                                                               .NroSerie = pns.NroSerie
                                                            }
                                             End Function)
               oCo.Productos.Add(cp)
            Next
         End With
         Dim rCo = New Reglas.MovimientosStock(da)
         rCo.CargarMovimientoStock(oCo, MetodoGrabacion, IdFuncion)
      End If
   End Sub

   Private Sub GrabaMovimientosDeCtasCtes(oVentas As Entidades.Venta,
                                          MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      If oVentas.FormaPago.Dias > 0 Then
         If Publicos.TieneModuloCuentaCorrienteClientes Then
            'cargo el comprobante en el objeto CuentasCorrientes
            With oVentas.CuentaCorriente
               .Cliente = oVentas.Cliente
               .Vendedor = oVentas.Vendedor
               .Cobrador = oVentas.Cobrador
               .TipoComprobante = oVentas.TipoComprobante
               .IdSucursal = oVentas.IdSucursal
               .Letra = oVentas.LetraComprobante
               .CentroEmisor = oVentas.Impresora.CentroEmisor
               .NumeroComprobante = oVentas.NumeroComprobante
               .Fecha = oVentas.Fecha
               .FechaVencimiento = oVentas.Fecha
               .ImporteTotal = oVentas.ImporteTotal
               .ImportePesos = oVentas.ImportePesos * oVentas.TipoComprobante.CoeficienteValores
               .ImporteDolares = oVentas.ImporteDolares * oVentas.TipoComprobante.CoeficienteValores
               .ImporteTarjetas = oVentas.ImporteTarjetas * oVentas.TipoComprobante.CoeficienteValores
               .ImporteTickets = oVentas.ImporteTickets * oVentas.TipoComprobante.CoeficienteValores
               .ImporteTransfBancaria = oVentas.ImporteTransfBancaria * oVentas.TipoComprobante.CoeficienteValores
               .ImporteCheques = oVentas.ImporteCheques * oVentas.TipoComprobante.CoeficienteValores
               .CuentaBancariaTransfBanc = oVentas.CuentaBancariaTransfBanc
               .CCTransferencias = oVentas.Transferencias.ConvertAll(Function(trx) New Entidades.CuentaCorrienteTransferencia() With
                                                                           {
                                                                              .IdCuentaBancaria = trx.IdCuentaBancaria,
                                                                              .Importe = trx.Importe,
                                                                              .Orden = trx.Orden
                                                                           })
               .ImporteRetenciones = 0
               .FormaPago = oVentas.FormaPago
               .Observacion = oVentas.Observacion
               .Saldo = oVentas.ImporteTotal

               .Usuario = oVentas.Usuario

               'If oVentas.Cliente.IdClienteCtaCte <> 0 Then
               '   .IdClienteCtaCte = oVentas.Cliente.IdClienteCtaCte
               'Else
               '   .IdClienteCtaCte = .Cliente.IdCliente
               'End If
               If oVentas.ClienteVinculado IsNot Nothing Then
                  .IdClienteCtaCte = oVentas.ClienteVinculado.IdCliente
               Else
                  .IdClienteCtaCte = oVentas.IdCliente
               End If
               .IdCategoria = .Cliente.IdCategoria
               .NumeroOrdenCompra = oVentas.NumeroOrdenCompra
               .Referencia = oVentas.CuentaCorriente.Referencia
               .CotizacionDolar = oVentas.CotizacionDolar
               .FechaTransferencia = oVentas.FechaTransferencia
               .Direccion = oVentas.Direccion
               .IdLocalidad = oVentas.IdLocalidad
               .NumeroReparto = oVentas.NumeroReparto
               .IdEmbarcacion = oVentas.IdEmbarcacion
               '-- REQ-36331.- -----------------------
               .IdCama = oVentas.IdCama
               '--------------------------------------
            End With


            Dim rCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)
            rCtaCte.GrabaCuentaCorriente(oVentas.CuentaCorriente, MetodoGrabacion, IdFuncion)
            'rCtaCte.ActualizaSaldo(oVentas.CuentaCorriente)

            '# Grabo las CCTransferencia
            Dim rCCTransferencias = New Reglas.CuentasCorrientesTransferencias(da)
            oVentas.CuentaCorriente.CCTransferencias.ForEach(
               Sub(transfer)
                  With transfer
                     .IdSucursal = oVentas.CuentaCorriente.IdSucursal
                     .IdTipoComprobante = oVentas.CuentaCorriente.TipoComprobante.IdTipoComprobante
                     .Letra = oVentas.CuentaCorriente.Letra
                     .CentroEmisor = oVentas.CuentaCorriente.CentroEmisor
                     .NumeroComprobante = oVentas.CuentaCorriente.NumeroComprobante
                     '--------------------------------------------
                     '.IdCuentaBancaria = ent.CuentaBancariaTransfBanc.IdCuentaBancaria '# Se utiliza una única Cuenta Bancaria por el momento
                     '--------------------------------------------
                  End With
                  rCCTransferencias._Inserta(transfer)
               End Sub)

            'DP: tengo que insertar un recibo automaticamente si pago algo en la factura
            'AR: Si es Electronico que lo digite manualmente, sino Genera el recibo ahora y leugo en solicitar CAEs (doble error!)
            If (oVentas.AplicarSaldoCtaCte OrElse oVentas.ImporteACtaCte <> oVentas.ImporteTotal) And Not oVentas.TipoComprobante.EsPreElectronico Then
               Dim oCtaCte = New Entidades.CuentaCorriente()

               Dim coeRecibo = oVentas.TipoComprobante.CoeficienteValores
               With oCtaCte

                  .Letra = oVentas.LetraComprobante
                  .CentroEmisor = oVentas.CentroEmisor
                  '.TipoComprobante = oVentas.TipoComprobante

                  'AR: Pongo esto por si busco todas las referncias
                  'TODO: que hacemos en caso de no separar?
                  If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then

                  End If

                  'Se envia el importe para determinar el tipo de comprobante a generar RECIBO/MINUTA
                  'En los casos de Facturas Cta Cte con Cobro siempre va a ser un importe positivo (ya que no se estaría generando nunca una MINUTA)
                  'Envio la resta de ImporteTotal e ImporteACtaCte (total del comprobante e importe que va a para a Cta Cte respectivamente)
                  'esto nos permitiría operar en casos donde:
                  '     - RECIBO        0.01 a 10000.00
                  '     - RECIBO_1  10000.01 a 20000.00
                  '     - RECIBO_2  20000.02 a 20000.00
                  '     - etc.
                  'No tiene sentido enviar la suma de los importes cobrados por un lado  porque es lo mismo y por otro, si se agrega un nuevo importe
                  'de cobro podríamos olvidarnos de agregarlo aqui
                  .TipoComprobante = New Reglas.TiposComprobantes(da)._GetTipoComprobanteRecibo(oVentas.TipoComprobante.IdTipoComprobante,
                                                                                                (oVentas.ImporteTotal - oVentas.ImporteACtaCte) * coeRecibo,
                                                                                                AccionesSiNoExisteRegistro.Excepcion)

                  If .TipoComprobante.LetrasHabilitadas = "X" Or .TipoComprobante.LetrasHabilitadas = "R" Then
                     .Letra = .TipoComprobante.LetrasHabilitadas
                  End If

                  '.NumeroComprobante = New Reglas.VentasNumeros(da).GetProximoNumero(oVentas.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor)

                  .Fecha = oVentas.Fecha.AddMinutes(1)   'Le agrego un minuto para qe el recibo quede posterior al comprobante aplicado. Sino, queda mal el saldo al visualizar
                  .FechaVencimiento = .Fecha
                  .FormaPago = New VentasFormasPago(da).GetUna("VENTAS", True) 'contado
                  .Cliente = oVentas.Cliente
                  .Vendedor = oVentas.Vendedor
                  .Cobrador = oVentas.Cobrador
                  .Observacion = oVentas.Observacion
                  .ImporteTotal = (oVentas.ImporteTotal - oVentas.ImporteACtaCte) * coeRecibo
                  'cargo los comprobantes
                  '.Pagos = Me._ComprobantesGrilla
                  'cargo el efectivo para tenerlo discriminado
                  .ImportePesos = oVentas.ImportePesos * coeRecibo
                  .ImporteDolares = oVentas.ImporteDolares * coeRecibo
                  .ImporteTickets = oVentas.ImporteTickets * coeRecibo
                  .ImporteTarjetas = oVentas.ImporteTarjetas * coeRecibo
                  .ImporteTransfBancaria = oVentas.ImporteTransfBancaria * coeRecibo
                  .CuentaBancariaTransfBanc = oVentas.CuentaBancariaTransfBanc
                  .CCTransferencias = oVentas.Transferencias.ConvertAll(Function(trx) New Entidades.CuentaCorrienteTransferencia() With
                                                                           {
                                                                              .IdCuentaBancaria = trx.IdCuentaBancaria,
                                                                              .Importe = trx.Importe,
                                                                              .Orden = trx.Orden
                                                                           })
                  'cargo los cheques
                  .Cheques = oVentas.Cheques
                  .Cheques.ForEach(Sub(ch) ch.Importe *= coeRecibo)
                  .Tarjetas = oVentas.Tarjetas
                  .Tarjetas.ForEach(Sub(t) t.Monto *= coeRecibo)
                  .ImporteCheques = oVentas.ImporteCheques * coeRecibo
                  'cargo las Retenciones
                  '.Retenciones = Me._retenciones
                  '.ImporteRetenciones = Decimal.Parse(Me.txtRetenciones.Text)
                  .CajaDetalle.IdCaja = oVentas.IdCaja
                  .IdSucursal = oVentas.IdSucursal

                  .Usuario = oVentas.Usuario

                  .IdEstado = "NORMAL"

                  If .Cliente.IdClienteCtaCte <> 0 Then
                     .IdClienteCtaCte = .Cliente.IdClienteCtaCte
                  Else
                     .IdClienteCtaCte = .Cliente.IdCliente
                  End If

                  .IdCategoria = .Cliente.IdCategoria

                  .CotizacionDolar = oVentas.CotizacionDolar
                  .FechaTransferencia = oVentas.FechaTransferencia
                  .NumeroReparto = oVentas.NumeroReparto
               End With

               Dim oCtaCtePago As Entidades.CuentaCorrientePago
               Dim impAPagar As Decimal = (oVentas.ImporteTotal - oVentas.ImporteACtaCte)

               If oVentas.AplicarSaldoCtaCte Then
                  Dim pagos = rCtaCte.GetPagosDeCliente(oCtaCte.IdSucursal,
                                                     tipoComprobante:=oCtaCte.TipoComprobante, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0,
                                                     idcliente:=oCtaCte.Cliente.IdCliente, totalPagos:=999999999, idTipoLiquidacion:=Nothing, incluirPreElectronicos:=Nothing,
                                                     crmNovedad:=If(oVentas.CrmInvocados.Count = 0, Nothing, oVentas.CrmInvocados(0)))

                  Dim pendienteSaldar = oVentas.ImporteACtaCte - -oVentas.ImporteTotal - oVentas.ImporteACtaCte
                  For Each p In pagos.Where(Function(pp) pp.SaldoCuota < 0)
                     Dim porPagar = Math.Min(pendienteSaldar, p.SaldoCuota * -1)
                     p.Paga = porPagar * -1
                     pendienteSaldar -= porPagar
                     impAPagar += porPagar
                     oCtaCte.Pagos.Add(p)
                     If pendienteSaldar <= 0 Then
                        Exit For
                     End If
                  Next

               End If

               Dim cuotita As Integer = 0
               For Each ct In oVentas.CuentaCorriente.Pagos
                  If impAPagar = 0 Then Exit For
                  oCtaCtePago = New Entidades.CuentaCorrientePago()
                  'cuotita += 1
                  cuotita = ct.Cuota      'Tomo la cuota que tengo en Pagos.
                  With oCtaCtePago
                     .TipoComprobante = oVentas.TipoComprobante
                     .Letra = oVentas.LetraComprobante
                     .CentroEmisor = oVentas.CentroEmisor
                     .NumeroComprobante = oVentas.NumeroComprobante

                     'Por Facturacion no tiene el Periodo. Pero lo dejo por las dudas.
                     If ct.Cuota > 190101 And oVentas.CuentaCorriente.Pagos.Count = 1 Then
                        .Cuota = ct.Cuota
                     Else
                        .Cuota = cuotita
                     End If

                     .FechaEmision = ct.FechaEmision
                     .FechaVencimiento = ct.FechaVencimiento
                     .ImporteCuota = ct.ImporteCuota * coeRecibo
                     .SaldoCuota = ct.SaldoCuota * coeRecibo
                     If impAPagar <= ct.ImporteCuota Then
                        .Paga = impAPagar
                        impAPagar -= impAPagar
                     Else
                        .Paga = .SaldoCuota
                        impAPagar -= .SaldoCuota
                     End If
                     .Paga *= coeRecibo
                     .DescuentoRecargoPorc = 0
                     .DescuentoRecargo = .Paga - Decimal.Round(.Paga / (1 + .DescuentoRecargoPorc / 100), 2)
                     .IdSucursal = oVentas.IdSucursal
                     .Usuario = oVentas.Usuario
                  End With

                  oCtaCte.Pagos.Add(oCtaCtePago)
               Next        'For Each ct In oVentas.CuentaCorriente.Pagos

               If oCtaCte.Pagos.Count > 0 Then
                  rCtaCte.Inserta(oCtaCte, Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)
               End If
            End If
         End If
      End If
   End Sub

   Private Sub GrabaMovimientosDeCaja(oVentas As Entidades.Venta)

      If Publicos.TieneModuloCaja Then ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then
         'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
         'ya que si es un cliente que tiene fichas y despues factura por aca se complica
         If oVentas.TipoComprobante.AfectaCaja Then
            Dim deta = New Entidades.CajaDetalles(oVentas.IdSucursal,
                                                    oVentas.Usuario,
                                                    oVentas.Password)
            Dim rCaja = New Cajas(da)
            Dim rCtaCaja = New CuentasDeCajas(da)
            Dim rCajaDet = New CajaDetalles(da)

            With deta
               .FechaMovimiento = oVentas.Fecha     'DAte.Now
               .IdSucursal = oVentas.IdSucursal
               .IdCaja = oVentas.IdCaja
               If oVentas.TipoComprobante.CoeficienteValores = 1 Then
                  .IdTipoMovimiento = "I"c
               Else
                  .IdTipoMovimiento = "E"c
               End If

               .NumeroPlanilla = rCaja.GetPlanillaActual(oVentas.IdSucursal, oVentas.IdCaja).NumeroPlanilla
               .Observacion = Strings.Left(oVentas.TipoComprobante.DescripcionAbrev & " " & oVentas.LetraComprobante & " " & oVentas.Impresora.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & IIf(oVentas.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + oVentas.Cheques.Count.ToString(), "").ToString() & IIf(oVentas.ImporteTransfBancaria > 0, " - Transf. a cuenta: " & oVentas.CuentaBancariaTransfBanc.NombreCuenta, "").ToString() & ". " & oVentas.Cliente.NombreCliente, 100)
               .IdCuentaCaja = Publicos.CtaCajaVentas  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.CTACAJAVENTAS))
               'me fijo si es Efectivo o Tarjeta para cargar el tipo de cuenta en la caja
               .ImportePesos = oVentas.ImportePesos
               .ImporteDolares = oVentas.ImporteDolares
               .ImporteBancos = Math.Abs(oVentas.ImporteTransfBancaria)
               .ImporteTarjetas = oVentas.ImporteTarjetas
               .ImporteTickets = oVentas.ImporteTickets
               .ImporteCheques = oVentas.ImporteCheques
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
               .CotizacionDolar = oVentas.CotizacionDolar
               If .ImporteBancos <> 0 And oVentas.CuentaBancariaTransfBanc IsNot Nothing Then
                  .IdMonedaImporteBancos = oVentas.CuentaBancariaTransfBanc.Moneda.IdMoneda
               End If
            End With


            Dim rCupones = New TarjetasCupones(da)

            rCajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(oVentas.Cheques), Nothing, Publicos.ConvierteTarjetasCuponesEnArray(rCupones.GetTodos(oVentas)))

            oVentas.NumeroPlanilla = deta.NumeroPlanilla

            If Publicos.CtaCajaVentasAcumula Then ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.CTACAJAVENTASACUMULA)) Then
               'Pregunto si agrupa las NC o las hace aparte
               If deta.IdTipoMovimiento = "I" Or Not Publicos.CajaMostrarNCIndividual Then ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.CAJAMOSTRARNCINDIVIDUAL)) = False Then
                  deta = rCajaDet.GetUltimoMovVenta(deta.IdSucursal, deta.IdCaja, deta.NumeroPlanilla, deta.IdCuentaCaja, deta.FechaMovimiento)
               End If
            End If

            oVentas.NumeroMovimiento = deta.NumeroMovimiento

            ActualizaMovimientoCaja(oVentas)

            'Hago la salida de Caja de Transferencia
            'If oVentas.ImporteTransfBancaria > 0 Then

            '   With deta
            '      .FechaMovimiento = oVentas.Fecha     'Date.Now
            '      .IdSucursal = oVentas.IdSucursal
            '      .IdTipoMovimiento = "E"c
            '      .IdCaja = oVentas.IdCaja
            '      .NumeroPlanilla = caj.GetPlanillaActual(oVentas.IdSucursal, oVentas.IdCaja).NumeroPlanilla
            '      .ImportePesos = oVentas.ImporteTransfBancaria
            '      .ImporteCheques = 0
            '      .ImporteTickets = 0
            '      .ImporteTarjetas = 0
            '      .Observacion = Strings.Left(oVentas.TipoComprobante.Descripcion & " " & oVentas.LetraComprobante & " " & oVentas.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & " - Transf. a cuenta: " & oVentas.CuentaBancariaTransfBanc.NombreCuenta & ". " & oVentas.Cliente.NombreCliente, 100)
            '      .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJATRANSFBANCARIA))
            '      .EsModificable = False
            '      .Usuario = actual.Nombre
            '   End With

            '   cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

            'End If

            'Analizo c/Tarjeta para saber si hago la salida de Caja.
            If oVentas.ImporteTarjetas > 0 Then
               For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas
                  'Solo si tiene configurado el Deposito Automatico. Se analiza Individualmente.
                  If tr.Tarjeta.Acreditacion Then
                     With deta
                        .FechaMovimiento = oVentas.Fecha
                        .IdSucursal = oVentas.IdSucursal
                        .IdTipoMovimiento = "E"c
                        .IdCaja = oVentas.IdCaja
                        .NumeroPlanilla = rCaja.GetPlanillaActual(oVentas.IdSucursal, oVentas.IdCaja).NumeroPlanilla
                        .ImportePesos = 0
                        .ImporteDolares = 0
                        .ImporteCheques = 0
                        .ImporteTickets = 0
                        .ImporteTarjetas = If(oVentas.TipoComprobante.CoeficienteValores = -1 AndAlso oVentas.TipoComprobante.Tipo = "VENTAS", tr.Monto * -1, tr.Monto)   'oVentas.ImporteTarjetas
                        .ImporteBancos = .ImporteTarjetas * -1
                        .Observacion = String.Format("{0} {1} {2}-{3:00000000} -Deposito de Tarjeta de Crédigo de: {4}", oVentas.TipoComprobante.DescripcionAbrev, oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante, oVentas.Cliente.NombreCliente).Truncar(100)
                        .IdCuentaCaja = Publicos.CtaCajaDepositoTarjetas  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJADEPOSITOTARJETAS))
                        .EsModificable = False
                        .GeneraContabilidad = False
                        .Usuario = actual.Nombre
                        .CotizacionDolar = oVentas.CotizacionDolar
                        If .ImporteBancos <> 0 And oVentas.CuentaBancariaTransfBanc IsNot Nothing Then
                           .IdMonedaImporteBancos = oVentas.CuentaBancariaTransfBanc.Moneda.IdMoneda
                        End If
                        If .ImporteBancos <> 0 And .IdMonedaImporteBancos = 0 Then
                           .IdMonedaImporteBancos = Entidades.Moneda.Peso
                        End If
                     End With
                     rCajaDet.AgregaMovimiento(deta, Nothing, Nothing)
                  End If
               Next
            End If
         End If
      End If

   End Sub

   Private Sub InsertaDetalle(oVentas As Entidades.Venta,
                              coe As Integer,
                              categoriaFiscalEmpresa As Entidades.CategoriaFiscal,
                              idFuncion As String)

      LogV("********** Ventas.InsertaDetalle ********** ")
      LogV(" 0- Inicia InsertaDetalle")

      Dim oRegVenProd As Reglas.VentasProductos = New Reglas.VentasProductos(da)
      ''Dim oMarca As Entidades.Marca
      ''Dim oRubro As Entidades.Rubro
      ''Dim oVendedorMarcaLista As Decimal
      ''Dim oVendedorRubroLista As Decimal
      Dim porcEmpleadoProducto As Decimal? = Nothing
      Dim porcEmpleadoMarca As Decimal? = Nothing
      Dim porcEmpleadoRubro As Decimal? = Nothing
      Dim porcEmpleadoMarcaLista As Decimal? = Nothing
      Dim porcEmpleadoRubroLista As Decimal? = Nothing
      Dim porcMarca As Decimal? = Nothing
      Dim porcRubro As Decimal? = Nothing
      Dim porcEmpleado As Decimal? = Nothing
      ''Dim importeTotal As Decimal
      Dim porcentaje As Decimal? = Nothing
      Dim ListaDePrecios As Integer = 0
      Dim oRegProductosOfertas As Reglas.ProductosOfertas = New Reglas.ProductosOfertas(da)

      Dim dicTipoMovimiento As Dictionary(Of String, Dictionary(Of String, Decimal)) = New Dictionary(Of String, Dictionary(Of String, Decimal))()


      Dim utilizaCentroCostos As Boolean = Publicos.TieneModuloContabilidad AndAlso ContabilidadPublicos.UtilizaCentroCostos



      '-- REQ-33524.- --------------------------------------------------------------
      If Reglas.Publicos.CtaCteEmbarcacion And New Reglas.Generales().ExisteTabla("Embarcaciones") And oVentas.AgregarObservacionEmbarcacion Then
         Dim oLineaVP As Eniac.Entidades.VentaProducto
         Dim Item = oVentas.VentasProductos.Where(Function(c) c.Orden = 1)

         Dim colProd As List(Of Eniac.Entidades.Producto) = New Eniac.Reglas.Productos().GetTodosObservacion()
         Dim productoObservacion As Eniac.Entidades.Producto = Nothing
         If colProd.Count > 0 Then
            productoObservacion = colProd(0)
         End If

         oLineaVP = New Eniac.Entidades.VentaProducto()

         oLineaVP.Orden = oVentas.VentasProductos.Count + 1
         oLineaVP.Producto = productoObservacion.GetCopia()
         '--REQ-34202.- --------------------------------------------------------
         oLineaVP.Producto.NombreProducto = String.Empty
         If Not String.IsNullOrEmpty(oVentas.NombreEmbarcacion) Then
            oLineaVP.Producto.NombreProducto = oVentas.NombreEmbarcacion
         End If
         '----------------------------------------------------------------------
         oLineaVP.NombreListaPrecios = Item(0).NombreListaPrecios
         oLineaVP.TipoImpuesto.IdTipoImpuesto = Item(0).TipoImpuesto.IdTipoImpuesto

         oLineaVP.Cantidad = 1
         oLineaVP.PrecioLista = 0
         oVentas.VentasProductos.Add(oLineaVP)

         oLineaVP = New Eniac.Entidades.VentaProducto()
         oLineaVP.Orden = oVentas.VentasProductos.Count + 1
         oLineaVP.Producto = productoObservacion.GetCopia()

         oLineaVP.Producto.NombreProducto = String.Format("Categoria {0}", oVentas.NombreCategoriaEmbarcacion)
         oLineaVP.NombreListaPrecios = Item(0).NombreListaPrecios
         oLineaVP.TipoImpuesto.IdTipoImpuesto = Item(0).TipoImpuesto.IdTipoImpuesto

         oLineaVP.Cantidad = 1
         oLineaVP.PrecioLista = 0
         '-- Carga Categoria.-
         oVentas.VentasProductos.Add(oLineaVP)
      End If
      '-----------------------------------------------------------------------------
      For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos
         LogV(String.Format(" 1- Procesando {0} {1} {2} {3:0000}-{4:00000000} {5} {6}",
                   oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante,
                   oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante,
                   Prod.Orden, Prod.IdProducto))

         If Prod.IdDeposito = 0 Then Prod.IdDeposito = Prod.Producto.IdDeposito
         If Prod.IdUbicacion = 0 Then Prod.IdUbicacion = Prod.Producto.IdUbicacion

         If utilizaCentroCostos Then
            If Prod.CentroCosto Is Nothing Then
               Prod.CentroCosto = Prod.Producto.CentroCosto
               If Prod.CentroCosto Is Nothing Then
                  Throw New Exception(String.Format("El producto '{0} - {1}' no tiene asignado Centro de Costos. Por favor verifique y vuelva a intentar.",
                                                    Prod.IdProducto, Prod.NombreProducto))
               End If
            End If
         End If

         'numeroOrden += 1
         Prod.IdSucursal = oVentas.IdSucursal
         Prod.TipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
         Prod.Letra = oVentas.LetraComprobante
         Prod.CentroEmisor = oVentas.Impresora.CentroEmisor
         Prod.NumeroComprobante = oVentas.NumeroComprobante

         If Not categoriaFiscalEmpresa.IvaDiscriminado Or Not oVentas.CategoriaFiscal.IvaDiscriminado Then
            Prod.PrecioConImpuestos = Prod.Precio
            Prod.PrecioNetoConImpuestos = Prod.PrecioNeto
            Prod.ImporteTotalConImpuestos = Prod.ImporteTotal
            Prod.ImporteTotalNetoConImpuestos = Prod.ImporteTotalNeto

            'Prod.Precio = Decimal.Round((Prod.Precio - (Prod.ImporteImpuestoInterno / Prod.Cantidad)) / (1 + (Prod.AlicuotaImpuesto / 100)), 4)
            'Prod.DescuentoRecargo = Decimal.Round(Prod.DescuentoRecargo / (1 + (Prod.AlicuotaImpuesto / 100)), 4)
            'Prod.DescRecGeneral = Decimal.Round(Prod.DescRecGeneral / (1 + (Prod.AlicuotaImpuesto / 100)), 4)
            'Prod.ImporteTotal = Decimal.Round((Prod.ImporteTotal - Prod.ImporteImpuestoInterno) / (1 + (Prod.AlicuotaImpuesto / 100)), 4)
            Prod.Precio = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.Precio, Prod.AlicuotaImpuesto,
                                                                        Prod.PorcImpuestoInterno, Prod.Producto.ImporteImpuestoInterno,
                                                                        Prod.OrigenPorcImpInt)

            Prod.DescuentoRecargo = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.DescuentoRecargo, Prod.AlicuotaImpuesto,
                                                                                  Prod.PorcImpuestoInterno, If(Prod.PorcImpuestoInterno = 0, 0, Prod.Producto.ImporteImpuestoInterno * Prod.Cantidad),
                                                                                  Prod.OrigenPorcImpInt)

            Prod.DescRecGeneral = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.DescRecGeneral, Prod.AlicuotaImpuesto,
                                                                                Prod.PorcImpuestoInterno, If(Prod.PorcImpuestoInterno = 0, 0, Prod.Producto.ImporteImpuestoInterno * Prod.Cantidad),
                                                                                Prod.OrigenPorcImpInt)
            Prod.ImporteTotal = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.ImporteTotal, Prod.AlicuotaImpuesto,
                                                                              Prod.PorcImpuestoInterno, Prod.Producto.ImporteImpuestoInterno * Prod.Cantidad,
                                                                              Prod.OrigenPorcImpInt)
         Else
            'Prod.PrecioConImpuestos = (Prod.Precio * (1 + (Prod.AlicuotaImpuesto / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)
            'Prod.PrecioNetoConImpuestos = (Prod.PrecioNeto * (1 + (Prod.AlicuotaImpuesto / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)
            'Prod.ImporteTotalConImpuestos = (Prod.ImporteTotal * (1 + (Prod.AlicuotaImpuesto / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)
            'Prod.ImporteTotalNetoConImpuestos = (Prod.ImporteTotalNeto * (1 + (Prod.AlicuotaImpuesto / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)
            Prod.PrecioConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.Precio, Prod.AlicuotaImpuesto,
                                                                                    Prod.PorcImpuestoInterno, Prod.Producto.ImporteImpuestoInterno,
                                                                                    Prod.OrigenPorcImpInt)
            Prod.PrecioNetoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.PrecioNeto, Prod.AlicuotaImpuesto,
                                                                                        Prod.PorcImpuestoInterno, Prod.Producto.ImporteImpuestoInterno * Prod.Cantidad,
                                                                                        Prod.OrigenPorcImpInt)
            Prod.ImporteTotalConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.ImporteTotal, Prod.AlicuotaImpuesto,
                                                                                          Prod.PorcImpuestoInterno, Prod.Producto.ImporteImpuestoInterno * Prod.Cantidad,
                                                                                          Prod.OrigenPorcImpInt)
            Prod.ImporteTotalNetoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.ImporteTotalNeto, Prod.AlicuotaImpuesto,
                                                                                              Prod.PorcImpuestoInterno, Prod.Producto.ImporteImpuestoInterno * Prod.Cantidad,
                                                                                              Prod.OrigenPorcImpInt)
         End If

         'Los calculo Antes.
         Prod.DescuentoRecargoProducto = Decimal.Round(Prod.DescuentoRecargo / Prod.Cantidad, Publicos.Facturacion.Redondeo.FacturacionDecimalesGrabarDetalleEnPrecio)
         Prod.DescRecGeneralProducto = Decimal.Round(Prod.DescRecGeneral / Prod.Cantidad, Publicos.Facturacion.Redondeo.FacturacionDecimalesGrabarDetalleEnPrecio)
         Prod.PrecioNeto = Decimal.Round(Prod.Precio + Prod.DescuentoRecargoProducto + Prod.DescRecGeneralProducto, Publicos.Facturacion.Redondeo.FacturacionDecimalesGrabarDetalleEnPrecio)
         Prod.ImporteTotalNeto = Decimal.Round(Prod.ImporteTotal + Prod.DescRecGeneral, Publicos.Facturacion.Redondeo.FacturacionDecimalesGrabarDetalleEnPrecio)
         Prod.Utilidad = Decimal.Round((Prod.PrecioNeto - If(Prod.CostoParaGrabar.HasValue, Prod.CostoParaGrabar.Value, Prod.Costo)) * Prod.Cantidad, Publicos.Facturacion.Redondeo.FacturacionDecimalesGrabarDetalleEnPrecio)
         '--------------------------------------------------

         'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
         'En los informes de utilidad y demas, sumo los subtotales (no haga el calculo nuevamente)

         If Prod.CantidadManual = 0 Then
            Prod.CantidadManual = Prod.Cantidad
            Prod.Conversion = 1
         End If
         If String.IsNullOrWhiteSpace(Prod.IdUnidadDeMedida) Then
            Prod.IdUnidadDeMedida = Prod.Producto.UnidadDeMedida.IdUnidadDeMedida
         End If

         Prod.Cantidad = Prod.Cantidad * coe
         Prod.CantidadManual = Prod.CantidadManual * coe

         Prod.ImporteImpuesto = Prod.ImporteImpuesto * coe
         Prod.ImporteImpuestoInterno = Prod.ImporteImpuestoInterno * coe
         Prod.Utilidad = Prod.Utilidad * coe
         Prod.ImporteTotal = Prod.ImporteTotal * coe
         Prod.ImporteTotalNeto = Prod.ImporteTotalNeto * coe

         Prod.Kilos = Prod.Kilos * coe

         Dim rComisiones As CalculosComisiones = New CalculosComisiones(_cache)
         Prod.ComisionVendedorPorc = rComisiones.CalculaPorcentajeComision(Prod, oVentas)
         Prod.ComisionVendedor = rComisiones.CalculaComision(Prod)

         Prod.NombreCortoListaPrecios = _cache.BuscaListaDePrecios(Prod.IdListaPrecios).NombreCortoListaPrecios

         'grabo los productos del comprobante de venta
         oRegVenProd.EjecutaSP(Prod, TipoSP._I)

         If Prod.IdOferta <> 0 Then
            oRegProductosOfertas.ConsumirCantidadOferta(Prod.IdProducto, Prod.IdOferta, Prod.Cantidad)
         End If

         'Se lo quito para el asiento en STOCK
         Prod.Cantidad = Prod.Cantidad * coe
         Prod.CantidadManual = Prod.CantidadManual * coe

         If oVentas.TipoComprobante.CoeficienteStock <> 0 AndAlso Prod.Producto.AfectaStock AndAlso Prod.IdEstadoVenta.HasValue Then
            Dim estadoVenta As Entidades.EstadoVenta = _cache.BuscaEstadoVenta(Prod.IdEstadoVenta.Value)
            If Not String.IsNullOrWhiteSpace(estadoVenta.IdTipoMovimiento) Then
               If Not dicTipoMovimiento.ContainsKey(estadoVenta.IdTipoMovimiento) Then
                  dicTipoMovimiento.Add(estadoVenta.IdTipoMovimiento, New Dictionary(Of String, Decimal)())
               End If
               If Not dicTipoMovimiento(estadoVenta.IdTipoMovimiento).ContainsKey(Prod.IdProducto) Then
                  dicTipoMovimiento(estadoVenta.IdTipoMovimiento).Add(Prod.IdProducto, 0)
               End If
               dicTipoMovimiento(estadoVenta.IdTipoMovimiento)(Prod.IdProducto) += Prod.Cantidad
            End If
         End If
      Next

      If dicTipoMovimiento IsNot Nothing AndAlso dicTipoMovimiento.Count > 0 Then
         For Each kvTipoMovimiento As KeyValuePair(Of String, Dictionary(Of String, Decimal)) In dicTipoMovimiento
            Dim movi = New Eniac.Entidades.MovimientoStock()
            movi.IdSucursal = oVentas.IdSucursal
            movi.Sucursal = _cache.BuscaSucursal(oVentas.IdSucursal)
            movi.TipoMovimiento = _cache.BuscaTipoMovimiento(kvTipoMovimiento.Key)
            movi.FechaMovimiento = Now
            movi.Usuario = actual.Nombre
            movi.Observacion = String.Format("Contramovimiento: {0} {1} {2:0000}-{3:00000000}",
                                             oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)

            movi.Productos = New List(Of Eniac.Entidades.MovimientoStockProducto)()
            Dim orden As Integer = 0
            For Each kvProductos As KeyValuePair(Of String, Decimal) In kvTipoMovimiento.Value
               Dim mp As Entidades.MovimientoStockProducto = New Entidades.MovimientoStockProducto()
               mp.IdSucursal = actual.Sucursal.Id
               mp.IdProducto = kvProductos.Key
               mp.Cantidad = kvProductos.Value
               orden += 1
               mp.Orden = orden
               movi.Productos.Add(mp)
            Next

            Dim rMovCom = New Eniac.Reglas.MovimientosStock()
            rMovCom.Insertar(movi, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
         Next
      End If

      LogV("********** Ventas.InsertaDetalle ********** ")
      LogV(" 0.1- Finaliza InsertaDetalle")

   End Sub
   Private Sub AjustoValoresImpuestos(oVentas As Entidades.Venta, coe As Integer)
      'Ajusto valores de impuestos segun coe de ventas (IVA)
      For Each vi As Entidades.VentaImpuesto In oVentas.VentasImpuestos
         vi.IdSucursal = oVentas.IdSucursal
         vi.TipoComprobante = oVentas.TipoComprobante
         vi.Letra = oVentas.LetraComprobante
         vi.CentroEmisor = oVentas.CentroEmisor
         vi.NumeroComprobante = oVentas.NumeroComprobante
         vi.Bruto = vi.Bruto * coe
         vi.Neto = vi.Neto * coe
         vi.Importe = vi.Importe * coe
         vi.Total = vi.Total * coe
      Next

      'ajusto los Otros impuestos de ventas (Percepciones)
      For Each vi As Entidades.VentaImpuesto In oVentas.ImpuestosVarios
         vi.IdSucursal = oVentas.IdSucursal
         vi.TipoComprobante = oVentas.TipoComprobante
         vi.Letra = oVentas.LetraComprobante
         vi.CentroEmisor = oVentas.CentroEmisor
         vi.NumeroComprobante = oVentas.NumeroComprobante
         vi.Bruto = vi.Bruto * coe
         vi.Neto = vi.Neto * coe
         vi.Importe = vi.Importe * coe
         vi.Total = vi.Total * coe
      Next

   End Sub

   Private Sub ActualizoEstadoComprobantesFacturados(oVentas As Entidades.Venta)
      If oVentas.Invocados.Count = 0 Then Exit Sub
      'INVMUL:
      'Dim Cont As Integer
      'Dim oFact As Entidades.Facturable = New Entidades.Facturable()
      Dim rCompra = New MovimientosStock(da)
      Dim rVV = New VentasInvocados(da)

      'Cree un entidad nueva para hacerlo mas chiquita, si esta mal borrar!!!

      'For Cont = 0 To oVentas.Facturables.Count - 1
      For Each vv In oVentas.Invocados

         'Next
         'For Cont = 0 To oVentas.Invocados.Count - 1
         Dim invocado = vv.Invocado
         Dim invocador = vv.Invocador

         If invocado.TipoTipoComprobante = Entidades.TipoComprobante.Tipos.VENTAS.ToString() Then
            If Existe(vv.Invocado) Then
               rVV._Insertar(vv)

               If Publicos.TipoComprobanteEnviadoCajero.Split(";"c).Contains(invocado.IdTipoComprobante) Then
                  Dim rVentasCajeros As Reglas.VentasCajeros = New VentasCajeros(da)
                  rVentasCajeros._Borrar(invocado.IdSucursal, invocado.IdTipoComprobante, invocado.Letra, invocado.CentroEmisor, invocado.NumeroComprobante)
               End If
            End If
            'ElseIf oVentas.Facturables(Cont).TipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() Then
         ElseIf invocado.TipoTipoComprobante = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() Then
            'Dim facturable As Venta = oVentas.Facturables(Cont)
            rCompra.ActualizaFacturablesDesdeVenta(New Entidades.Facturable() _
                                                With {.IdSucursal = invocador.IdSucursal,
                                                      .IdTipoComprobante = invocado.IdTipoComprobante,
                                                      .Letra = invocado.Letra,
                                                      .CentroEmisor = invocado.CentroEmisor,
                                                      .NumeroComprobante = invocado.NumeroComprobante,
                                                      .IdProveedor = invocado.IdProveedor.IfNull(),
                                                      .IdTipoComprobanteFact = invocador.IdTipoComprobante,
                                                      .LetraFact = invocador.Letra,
                                                      .CentroEmisorFact = invocador.CentroEmisor,
                                                      .NumeroComprobanteFact = invocador.NumeroComprobante})
         End If
      Next
   End Sub

   Private Sub DescuentoStockComponentes(oVentas As Entidades.Venta,
                                      MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      Dim _Componentes As DataTable
      Dim oProducto As Entidades.Producto
      'Dim movcomprod As Entidades.MovimientoStockProducto
      'Dim omovcomprod = New List(Of Entidades.MovimientoStockProducto)()
      Dim oMovComp = New MovimientosStock(da)
      Dim ocomponentes = New ProductosComponentes(da)
      'Dim prodprodcomp As Entidades.ProduccionProductoComp
      Dim idListaDePrecios As Integer = 0    'Lista de Precios
      Dim rUbic = New SucursalesUbicaciones(da)

      For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos

         Dim rProductos = New Productos(da)
         oProducto = New Entidades.Producto()

         'Busco el producto Nuevamente aunque este en la Coleccion porque pudo ajustar alguna caracterisca luego de algun hipotetico mensaje anterior.
         oProducto = rProductos.GetUno(Prod.IdProducto)

         Dim movComp = New Entidades.MovimientoStock()

         'Si bien un producto NO Compuesto no podria marcarse como descontar componentes, lo hago por si en algun momento fallo algun control
         If oProducto.EsCompuesto And oProducto.DescontarStockComponentes Then

            If Prod.VentasProductosFormulas.AnySecure() Then

               'Alta del producto de produccion automatica
               'Agrega MovimientosStock con tipo de Movimiento PRODUCCION para el producto final ingresando la mercadería que acaba de salir por venta.
               Dim oMov1 = New Reglas.MovimientosStock(da)
               oMov1.CargarMovimientoStock(Me.GetMovimientoVentaProdAutomatico(oVentas), MetodoGrabacion, IdFuncion)

               'Agrega MovimientosStock con tipo de Movimiento COMPROD para los producto componentes descontando la materia prima que compone el producto que acaba de salir por venta.
               With movComp
                  .Sucursal = New Sucursales(da).GetUna(Prod.IdSucursal, False)

                  .TipoMovimiento = New TiposMovimientos(da).GetUno(If(oVentas.TipoComprobante.CoeficienteValores = -1, "DEVOLUCION", "COMPROD"))

                  'If oVentas.TipoComprobante.CoeficienteValores = -1 Then
                  '   .TipoMovimiento = New TiposMovimientos(da).GetUno("DEVOLUCION")
                  'Else
                  '   .TipoMovimiento = New TiposMovimientos(da).GetUno("COMPROD")
                  'End If

                  .FechaMovimiento = oVentas.Fecha

                  .DescuentoRecargo = 0

                  .PercepcionIVA = 0
                  .PercepcionIB = 0
                  .PercepcionGanancias = 0
                  .PercepcionVarias = 0

                  '.Productos = omovcomprod
                  .Usuario = oVentas.Usuario
               End With

               For Each dr In Prod.VentasProductosFormulas
                  'Si no viene información de SeleccionMultiple es posible que no venga de la pantalla de FacturacionV2 o que sea un Componente sin Lote/Serie
                  'entonces creo uno con la información de la línea
                  If dr.SeleccionMultiple Is Nothing Then
                     dr.SeleccionMultiple = New Entidades.SeleccionMultipleUbicaciones() With {
                           .Producto = rProductos._GetUnoParaM(dr.IdProductoComponente),
                           .Ubicacion = rUbic.GetUno(Prod.IdDeposito, Prod.IdSucursal, Prod.IdUbicacion),
                           .Cantidad = dr.Cantidad
                        }
                  End If
                  Dim ubic = dr.SeleccionMultiple
                  Dim lotes = ubic.Lotes.ToList()
                  'Si no viene informacón de Lotes creo una ficticia con lote vacio para poder hacer la conversión a MovimientoStock más facil.
                  If Not lotes.AnySecure() Then
                     lotes.Add(New Entidades.SeleccionMultipleLotes() With {
                                       .UbicacionAdmin = ubic,
                                       .Cantidad = dr.Cantidad,
                                       .IdLote = String.Empty
                                    })
                  End If

                  For Each l In lotes
                     Dim movcomprod = New Entidades.MovimientoStockProducto With {
                                                .IdSucursal = l.IdSucursal,
                                                .IdDeposito = l.IdDeposito,
                                                .IdUbicacion = l.IdUbicacion,
                                                .Cantidad = l.Cantidad * Prod.Cantidad,
                                                .DescRecGeneral = 0,
                                                .DescuentoRecargo = 0,
                                                .IdLote = l.IdLote,
                                                .IdProducto = l.IdProducto,
                                                .NombreProducto = l.NombreProducto,
                                                .Precio = dr.PrecioCosto
                                             }
                     movcomprod.ImporteTotal = Decimal.Round(movcomprod.Cantidad * movcomprod.Precio, 2)
                     movcomprod.IVA = 0

                     If Not String.IsNullOrWhiteSpace(l.IdLote) Then
                        Dim prodLote = New Entidades.ProductoLote() With {
                                          .IdSucursal = l.IdSucursal,
                                          .IdDeposito = l.IdDeposito,
                                          .IdUbicacion = l.IdUbicacion,
                                          .IdLote = l.IdLote,
                                          .CantidadActual = l.Cantidad,
                                          .CantidadInicial = l.Cantidad,
                                          .Habilitado = True,
                                          .FechaIngreso = Date.Now,
                                          .FechaVencimiento = l.FechaVencimiento
                                       }
                        prodLote.ProductoSucursal.Producto.IdProducto = l.Producto.IdProducto
                        prodLote.ProductoSucursal.IdSucursal = l.IdSucursal
                        prodLote.ProductoSucursal.Sucursal.IdSucursal = l.IdSucursal
                        movComp.ProductosLotes.Add(prodLote)
                     End If

                     movcomprod.ProductosNrosSerie.AddRange(ubic.NrosSerie.
                                    ConvertAll(Function(ns)
                                                  Return New Entidades.MovimientoStockProductoNrosSerie With {
                                                               .IdProducto = ns.IdProducto,
                                                               .IdSucursal = ns.IdSucursal,
                                                               .IdDeposito = l.IdDeposito,
                                                               .IdUbicacion = l.IdUbicacion,
                                                               .NroSerie = ns.NroSerie,
                                                               .Cantidad = 1
                                                         }
                                               End Function))
                     movcomprod.ProductoSucursal.Producto.NrosSeries = ubic.NrosSerie.
                                    ConvertAll(Function(ns)
                                                  Return New Entidades.ProductoNroSerie With {
                                                               .Producto = New Entidades.Producto() With {.IdProducto = ns.IdProducto},
                                                               .IdSucursal = ns.IdSucursal,
                                                               .Sucursal = New Entidades.Sucursal() With {.IdSucursal = ns.IdSucursal},
                                                               .IdDeposito = l.IdDeposito,
                                                               .IdUbicacion = l.IdUbicacion,
                                                               .NroSerie = ns.NroSerie,
                                                               .Vendido = True
                                                         }
                                               End Function)
                     movComp.Productos.Add(movcomprod)
                  Next
               Next
            Else

               'prodprodcomp = New Entidades.ProduccionProductoComp()

               _Componentes = ocomponentes.GetComponentes(Prod.IdSucursal, oProducto.IdProducto, oProducto.IdFormula, idListaDePrecios)

               If _Componentes.Rows.Count > 0 Then

                  'Alta del producto de produccion automatica
                  Dim oMov1 = New Reglas.MovimientosStock(da)
                  oMov1.CargarMovimientoStock(Me.GetMovimientoVentaProdAutomatico(oVentas), MetodoGrabacion, IdFuncion)

                  Dim omovcomprod = New List(Of Entidades.MovimientoStockProducto)()
                  For Each dr As DataRow In _Componentes.Rows
                     Dim movcomprod = New Entidades.MovimientoStockProducto()

                     movcomprod.IdSucursal = Prod.IdSucursal
                     movcomprod.IdDeposito = Integer.Parse(dr("IdDepositoDefecto").ToString())
                     movcomprod.IdUbicacion = Integer.Parse(dr("IdUbicacionDefecto").ToString())

                     movcomprod.Cantidad = Decimal.Parse(dr("Cantidad").ToString()) * Prod.Cantidad
                     movcomprod.DescRecGeneral = 0
                     movcomprod.DescuentoRecargo = 0
                     movcomprod.IdLote = ""
                     movcomprod.IdProducto = dr("IdProductoComponente").ToString()
                     movcomprod.NombreProducto = dr("NombreProducto").ToString()
                     movcomprod.Precio = Decimal.Parse(dr("PrecioCosto").ToString())
                     movcomprod.ImporteTotal = Decimal.Round(movcomprod.Cantidad * movcomprod.Precio, 2)
                     movcomprod.IVA = 0

                     omovcomprod.Add(movcomprod)

                  Next

                  With movComp
                     .Sucursal = New Reglas.Sucursales(da).GetUna(Prod.IdSucursal, False)

                     If oVentas.TipoComprobante.CoeficienteValores = -1 Then
                        .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno("DEVOLUCION")
                     Else
                        .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno("COMPROD")
                     End If

                     .FechaMovimiento = oVentas.Fecha

                     .DescuentoRecargo = 0

                     .PercepcionIVA = 0
                     .PercepcionIB = 0
                     .PercepcionGanancias = 0
                     .PercepcionVarias = 0

                     .Productos = omovcomprod
                     .Usuario = oVentas.Usuario
                  End With
               Else
                  Throw New Exception("ATENCION: El Producto '" & Prod.IdProducto & " - " & Prod.NombreProducto & "', tiene Predeterminada una Fórmula sin Componentes. NO puede Grabar.")
               End If
            End If
            oMovComp.GrabarMovimientoProduccion(movComp)
         End If
      Next
      '----------------------------------------------------------------------------------------
      'si el cliente tiene sucursal asociado tengo que realizar el contra-movimiento en la otra sucursal
      'esto es legal ya que transportar mercaderia entre sucursales tiene que ser con remito.
      If oVentas.Cliente.IdSucursalAsociada <> 0 Then
         Me.RealizarContraMovimiento(oVentas, MetodoGrabacion, IdFuncion)
      End If
   End Sub

#End Region

   Public Sub ActualizarComprobantesCargos(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)

      Dim oLiquidacionesCargos As Reglas.LiquidacionesCargos = New Reglas.LiquidacionesCargos(da)
      oLiquidacionesCargos.ActualizarComprobantePorComprobante(vtaActual, vtaNueva)

   End Sub

   Public Sub GeneraContramovimientoDeInvocados(venta As Entidades.Venta, idFuncion As String)
      For Each facturable In venta.Invocados
         If Not String.IsNullOrWhiteSpace(facturable.Invocado.IdTipoComprobanteContraMovInvocar) Then
            Dim tipoComprobanteContraMovInvocar = New TiposComprobantes(da).GetUno(facturable.Invocado.IdTipoComprobanteContraMovInvocar)
            _CopiarReemplazarComprobante(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante,
                                         tipoComprobanteContraMovInvocar, venta.IdCaja, False, False, 0, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, venta.Fecha,
                                         False, venta.IdSucursal)
         End If
      Next
   End Sub


   Public Sub ActualizaFechaImpresion(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long)
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.ActualizaFechaImpresion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

#Region "ActualizaFechaEnvioCorreo"
   Public Sub ActualizaFechaEnvioCorreo(comprobantes As List(Of VentasEnvioMasivoMails.ComprobanteEnvioMail), fechaEnvioCorreo As DateTime?)
      Try
         Me.da.OpenConection()
         da.BeginTransaction()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         _ActualizaFechaEnvioCorreo(comprobantes, fechaEnvioCorreo)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub ActualizaFechaEnvioCorreo(venta As Entidades.Venta, fechaEnvioCorreo As DateTime?)
      ActualizaFechaEnvioCorreo(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante, fechaEnvioCorreo)
   End Sub

   Public Sub ActualizaFechaEnvioCorreo(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Short,
                                        numeroComprobante As Long,
                                        fechaEnvioCorreo As DateTime?)
      Try
         Me.da.OpenConection()
         da.BeginTransaction()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         _ActualizaFechaEnvioCorreo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaEnvioCorreo)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub _ActualizaFechaEnvioCorreo(comprobantes As List(Of VentasEnvioMasivoMails.ComprobanteEnvioMail), fechaEnvioCorreo As DateTime?)
      For Each comp As VentasEnvioMasivoMails.ComprobanteEnvioMail In comprobantes
         _ActualizaFechaEnvioCorreo(comp.IdSucursal, comp.IdTipoComprobante, comp.LetraComprobante, comp.CentroEmisor, comp.NumeroComprobante, fechaEnvioCorreo)
      Next
   End Sub

   Public Sub _ActualizaFechaEnvioCorreo(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroComprobante As Long,
                                         fechaEnvioCorreo As DateTime?)
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      sql.ActualizaFechaEnvioCorreo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaEnvioCorreo)
   End Sub
#End Region

   Public Sub ActualizaVenta(venta As Entidades.Venta, modificaComision As Boolean, cambioFormaPago As Boolean, idFuncion As String,
                             modificoFechaDeComprobante As Boolean)
      EjecutaConTransaccion(
      Sub()
         Dim sql = New SqlServer.Ventas(da)
         Dim sqlProductos = New SqlServer.VentasProductos(da)
         Dim sqlCtaCte = New SqlServer.CuentasCorrientes(da)
         Dim sqlCtaCtePago = New SqlServer.CuentasCorrientesPagos(da)
         Dim sqlMovimientosStock = New SqlServer.MovimientosStock(da)

         Dim idClienteCtaCte As Long = 0
         If venta.CuentaCorriente IsNot Nothing Then
            idClienteCtaCte = venta.CuentaCorriente.IdClienteCtaCte
         End If
         'Actualizo Fecha (en cas que sea comprobante blue), Vendedor, Comision general, Categoria y Observación en Ventas
         '# Se actualizan Datos clínicos
         sql.ActualizaVenta(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor,
                            venta.NumeroComprobante, venta.Vendedor.IdEmpleado,
                            venta.ComisionVendedor, modificaComision, venta.Cobrador.IdEmpleado,
                            If(venta.IdCliente = idClienteCtaCte, 0, idClienteCtaCte), venta.Observacion, venta.IdCategoria, venta.Fecha,
                            venta.Cuit, venta.TipoDocCliente, venta.NroDocCliente,
                            venta.IdPaciente, venta.IdDoctor, venta.FechaCirugia)

         Dim fecha As Date? = Nothing
         If modificoFechaDeComprobante Then
            fecha = venta.Fecha
         End If
         'Actualizo Vendedor, Referencia, Categoria y Fecha en la cta cte
         sqlCtaCte.ActualizoVendedorClienteCtaCte(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor,
                                                  venta.NumeroComprobante, venta.Vendedor.IdEmpleado,
                                                  venta.Cobrador.IdEmpleado, idClienteCtaCte,
                                                  venta.CuentaCorriente.Referencia, venta.IdCategoria, fecha, venta.Observacion)
         ' PE- 40978 - 
         If fecha IsNot Nothing Then
            sqlMovimientosStock.ActualizoFechaMovimientoStock(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor,
                                                  venta.NumeroComprobante, fecha)
         End If

         '-.PE-31570.- Actualizo Observacion.. etc en CuentasCorrientesPagos
         sqlCtaCtePago.ActualizoVendedorClienteCtaCtePagos(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor,
                                                           venta.NumeroComprobante, venta.Observacion)


         sqlCtaCte.CuentasCorrientes_LimpiaFechaExportacion(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor,
                                   venta.NumeroComprobante)

         If modificaComision Then
            'Actualizo la comision individual de los productos proporcionalmente
            For Each dr As Entidades.VentaProducto In venta.VentasProductos
               dr.ComisionVendedor = venta.ComisionVendedor / venta.VentasProductos.Count
               dr.ComisionVendedorPorc = Decimal.Round(((dr.ComisionVendedor / dr.ImporteTotalNeto) * 100) / venta.VentasProductos.Count, 4)
               sqlProductos.ActualizaComisionProducto(dr.IdSucursal, dr.TipoComprobante, dr.Letra, dr.CentroEmisor,
                                          dr.NumeroComprobante, dr.IdProducto.Trim(), dr.Orden, dr.ComisionVendedor, dr.ComisionVendedorPorc)
            Next
         End If

         If cambioFormaPago Then

            Dim oCtasCtes = New Reglas.CuentasCorrientes(da)
            If oCtasCtes.Existe(venta.IdSucursal,
                                  venta.IdTipoComprobante,
                                  venta.LetraComprobante,
                                  venta.CentroEmisor,
                                  venta.NumeroComprobante) Then
               Throw New Exception("Este comprobante ya EXISTE en Cuentas Corrientes ")
            End If


            'si el cliente compro el modulo de caja
            If Publicos.TieneModuloCaja Then ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then
               'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
               'ya que si es un cliente que tiene fichas y despues factura por aca se complica

               Dim deta = New Entidades.CajaDetalles(venta.IdSucursal, venta.Usuario, venta.Password)
               Dim rCaja = New Cajas(da)
               Dim rCtaCaja = New CuentasDeCajas(da)
               Dim rCajaDet = New CajaDetalles(da)

               ''tengo que recuperar las cajas del usuario logueado y se lo aplico a la primera si no tiene caja el mov.
               'If oVentas.IdCaja = 0 Then
               '   oVentas.IdCaja = Integer.Parse(New Reglas.CajasUsuarios(da)._GetCajas(oVentas.Usuario, oVentas.IdSucursal).Rows(0)("IdCaja").ToString())
               'End If

               With deta
                  .IdSucursal = venta.IdSucursal
                  .IdCaja = venta.IdCaja
                  .FechaMovimiento = venta.Fecha    'DAte.Now
                  'Invierto el tipo de movimiento.
                  If venta.TipoComprobante.CoeficienteValores = 1 Then
                     .IdTipoMovimiento = "E"c
                  Else
                     .IdTipoMovimiento = "I"c
                  End If
                  .NumeroPlanilla = rCaja.GetPlanillaActual(venta.IdSucursal, venta.IdCaja).NumeroPlanilla
                  .Observacion = Strings.Left("CAMBIO F. PAGO " & venta.TipoComprobante.DescripcionAbrev & " " & venta.LetraComprobante & " " & venta.Impresora.CentroEmisor.ToString() & "-" & venta.NumeroComprobante.ToString("00000000") & IIf(venta.Cheques.Count > 0, " - Cantidad Cheq. Tercero: " + venta.Cheques.Count.ToString(), "").ToString() & ". " & venta.Cliente.NombreCliente, 100)
                  .IdCuentaCaja = Publicos.CtaCajaVentas  '  Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.CTACAJAVENTAS))
                  'me fijo si es Efectivo o Tarjeta para cargar el tipo de cuenta en la caja
                  .ImportePesos = venta.ImportePesos * venta.TipoComprobante.CoeficienteValores
                  .ImporteDolares = venta.ImporteDolares * venta.TipoComprobante.CoeficienteValores
                  .ImporteBancos = venta.ImporteTransfBancaria * venta.TipoComprobante.CoeficienteValores
                  .ImporteTarjetas = venta.ImporteTarjetas * venta.TipoComprobante.CoeficienteValores
                  .ImporteTickets = venta.ImporteTickets * venta.TipoComprobante.CoeficienteValores
                  .ImporteCheques = venta.ImporteCheques * venta.TipoComprobante.CoeficienteValores
                  .EsModificable = False
                  .GeneraContabilidad = False
                  .Usuario = actual.Nombre
               End With

               deta.IgnoraAcumulaVentas = True

               Dim rCupones = New TarjetasCupones(da)

               rCajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(venta.Cheques), Nothing, Publicos.ConvierteTarjetasCuponesEnArray(rCupones.GetTodos(venta)))

               venta.NumeroPlanilla = deta.NumeroPlanilla

               'Las Anulaciones van aparte aunque acumule, para un mejor control interno.
               'If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTASACUMULA")) Then
               '   deta = cajaDet.GetUltimoMovVenta(deta.IdSucursal, deta.IdCaja, deta.NumeroPlanilla, deta.IdCuentaCaja, deta.FechaMovimiento)
               'End If

               venta.NumeroMovimiento = deta.NumeroMovimiento

               ActualizaMovimientoCaja(venta)


               'Analizo c/Tarjeta para saber si hago la salida de Caja.
               If venta.ImporteTarjetas > 0 Then
                  For Each tr In venta.Tarjetas
                     'Solo si tiene configurado el Deposito Automatico. Se analiza Individualmente.
                     If tr.Tarjeta.Acreditacion Then
                        With deta
                           .FechaMovimiento = venta.Fecha
                           .IdSucursal = venta.IdSucursal
                           .IdTipoMovimiento = "I"c
                           .IdCaja = venta.IdCaja
                           .NumeroPlanilla = rCaja.GetPlanillaActual(venta.IdSucursal, venta.IdCaja).NumeroPlanilla
                           .ImportePesos = 0
                           .ImporteDolares = 0
                           .ImporteCheques = 0
                           .ImporteTickets = 0
                           .ImporteTarjetas = tr.Monto  'oVentas.ImporteTarjetas
                           .Observacion = Strings.Left(venta.TipoComprobante.DescripcionAbrev & " " & venta.LetraComprobante & " " & venta.Impresora.CentroEmisor.ToString() & "-" & venta.NumeroComprobante.ToString("00000000") & " -Deposito de Tarjeta Crédito de: " & venta.Cliente.NombreCliente, 100)
                           .IdCuentaCaja = Publicos.CtaCajaDepositoTarjetas  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJADEPOSITOTARJETAS))
                           .EsModificable = False
                           .GeneraContabilidad = False
                           .Usuario = actual.Nombre
                        End With
                        rCajaDet.AgregaMovimiento(deta, Nothing, Nothing)
                     End If
                  Next
               End If
            End If


            If Publicos.TieneModuloBanco Then ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

               Dim rLibroBancos = New LibroBancos(da)
               Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               Dim rLibBanco = New LibroBancos(da)

               If venta.ImporteTransfBancaria <> 0 Then

                  With entLibroBanco
                     .IdSucursal = venta.IdSucursal
                     .IdCuentaBancaria = venta.CuentaBancariaTransfBanc.IdCuentaBancaria
                     .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                     .IdCuentaBanco = Publicos.CtaBancoTransfBancaria  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOTRANSFBANCARIA))
                     If venta.TipoComprobante.CoeficienteValores > 0 Then
                        .IdTipoMovimiento = "E"
                     Else
                        .IdTipoMovimiento = "I"
                     End If
                     .Importe = Math.Abs(venta.ImporteTransfBancaria)
                     .FechaMovimiento = venta.Fecha
                     .IdCheque = Nothing
                     .FechaAplicado = venta.Fecha
                     '.Observacion = ent.Observacion
                     .Observacion = Strings.Left(venta.TipoComprobante.Descripcion & " " & venta.LetraComprobante & " " & venta.CentroEmisor.ToString() & "-" & venta.NumeroComprobante.ToString("00000000") & " - Transf. a Cuenta" & ". " & venta.Cliente.NombreCliente, 100)
                     .Conciliado = False
                  End With

                  rLibroBancos.AgregaMovimiento(entLibroBanco)

               End If


               Dim entLibroBancoTar = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               Dim rLibBancoTar = New LibroBancos(da)
               Dim ultimoDia As Date
               Dim diaUltimo As Integer
               Dim cantdias As Integer
               Dim ultimoDiaX As Date
               Dim diaMes As Date
               For Each tr In venta.Tarjetas

                  'Solo si tiene configurado el Deposito Automatico. Se analiza Individualmente.
                  If tr.Tarjeta.Acreditacion Then

                     With entLibroBancoTar
                        .IdSucursal = venta.IdSucursal
                        .IdCuentaBancaria = tr.Tarjeta.CuentaBancaria.IdCuentaBancaria
                        .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                        .IdCuentaBanco = Publicos.CtaBancoAcredTarjeta  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOACREDTARJETA))
                        .IdTipoMovimiento = "E"
                        .Importe = tr.Monto
                        .FechaMovimiento = venta.Fecha
                        .IdCheque = Nothing
                        If tr.Tarjeta.PagoPosVenta Then
                           .FechaAplicado = venta.Fecha.AddDays(tr.Tarjeta.CantDiasAcredit)
                        Else
                           If tr.Tarjeta.PagoPosCorte Then
                              ultimoDia = DateSerial(Year(venta.Fecha), Month(venta.Fecha) + 1, 0)
                              diaUltimo = ultimoDia.DayOfWeek()
                              If diaUltimo = (tr.Tarjeta.DiaCorte + 1) Then
                                 ultimoDiaX = ultimoDia
                              Else
                                 cantdias = (7 + diaUltimo - (tr.Tarjeta.DiaCorte + 1))
                                 ultimoDiaX = ultimoDia.AddDays(-cantdias)
                              End If
                              .FechaAplicado = ultimoDiaX.AddDays(tr.Tarjeta.CantDiasAcredit)
                           Else
                              'PagoDiaMes
                              diaMes = DateSerial(Year(.FechaMovimiento), Month(.FechaMovimiento), tr.Tarjeta.DiaMes)
                              If .FechaMovimiento < diaMes Then
                                 .FechaAplicado = diaMes.AddDays(tr.Tarjeta.CantDiasAcredit)
                              Else
                                 .FechaAplicado = DateAdd("m", 1, diaMes).AddDays(tr.Tarjeta.CantDiasAcredit)
                              End If
                           End If

                        End If

                        '.Observacion = ent.Observacion
                        .Observacion = Strings.Left("CAMBIO F. PAGO " & tr.NombreTarjeta & "(" & tr.NombreBanco & ")Cup:" & tr.NumeroCupon & "-Ctas(" & tr.Cuotas & ")-" & venta.TipoComprobante.Descripcion & " " & venta.LetraComprobante & " " & venta.CentroEmisor.ToString() & "-" & venta.NumeroComprobante.ToString("00000000") & "(" & venta.Cliente.NombreCliente & ")", 100)
                        .Conciliado = False
                     End With

                     rLibroBancos.AgregaMovimiento(entLibroBancoTar)

                  End If

               Next
            End If

            If Publicos.TieneModuloCuentaCorrienteClientes Then
               venta.Usuario = actual.Nombre
               venta.ImportePesos = 0
               venta.ImporteDolares = 0
               venta.ImporteTickets = 0
               venta.ImporteTransfBancaria = 0
               venta.NumeroMovimiento = 0
               venta.Tarjetas.Clear()
               venta.Cheques.Clear()
               venta.CuentaBancariaTransfBanc = Nothing
               venta.FechaTransferencia = Nothing

               Dim oCCP = New Entidades.CuentaCorrientePago()
               oCCP.ImporteCuota = venta.ImporteTotal
               '-- REQ-34392.- -----------------------------------------------------------------
               oCCP.SaldoCuota = oCCP.ImporteCuota * venta.TipoComprobante.CoeficienteValores
               '--------------------------------------------------------------------------------
               oCCP.FechaVencimiento = venta.Fecha.AddDays(venta.FormaPago.Dias)
               venta.CuentaCorriente.Pagos.Add(oCCP)

               GrabaMovimientosDeCtasCtes(venta, Entidades.Entidad.MetodoGrabacion.Manual, idFuncion)
            End If

         End If

         '# Cuando actualizo la fecha del comprobante, debo actualizar también los vencimientos de las cuotas SOLO SI:
         '#    - El comprobante tiene una única cuota
         '#    - El vencimiento de la cuota del comprobante NO FUÉ modificado manualmente

         '# Si se modificó la Fecha del Comprobante
         If modificoFechaDeComprobante Then

            '# Consulto los registros de CCPagos para saber si el comprobante tiene más de una cuota emitida.
            Dim rCuentasCorrientesPagos = New CuentasCorrientesPagos(da)
            Dim eCuentaCorrientePago = rCuentasCorrientesPagos.GetPorCuentaCorriente(New Entidades.CuentaCorriente With {
                                                                                             .IdSucursal = venta.IdSucursal,
                                                                                             .TipoComprobante = venta.TipoComprobante,
                                                                                             .Letra = venta.LetraComprobante,
                                                                                             .CentroEmisor = venta.CentroEmisor,
                                                                                             .NumeroComprobante = venta.NumeroComprobante
                                                                                          })

            '# Actualizo las fechas de emisión de los registros de CCPagos
            For Each eCCPago In eCuentaCorrientePago
               eCCPago.FechaEmision = venta.Fecha
            Next

            '# Si la consulta me devuelve +1 entidad, NO actualizo los vencimientos
            Dim actualizarVencimiento As Boolean = False
            If eCuentaCorrientePago.Count = 1 Then
               With eCuentaCorrientePago(0)

                  '# Si el vencimiento de la cuota fué modificado, NO actualizo los vencimientos
                  '# La fecha original del primer vencimiento va a estar determinada por la cantidad de días de la forma de pago seleccionada.
                  '# Fecha del comprobante + Cantidad de Días de la FP Debe dar la fecha de vencimiento. Si esto difiere, quiere decir que la fecha fué modificada.
                  Dim fechaComprobanteOriginal As Date = eCuentaCorrientePago(0).FechaEmision
                  Dim fechaOriginalPrimerVencimiento As Date = fechaComprobanteOriginal.AddDays(venta.FormaPago.Dias)
                  If Not fechaOriginalPrimerVencimiento <> eCuentaCorrientePago(0).FechaVencimiento Then

                     '# Actualizo la fecha de Vencimiento en CCPagos
                     .FechaVencimiento = .FechaVencimiento.AddDays(DateDiff(DateInterval.Day, fechaComprobanteOriginal, venta.Fecha))
                     actualizarVencimiento = True
                  End If
               End With
            End If

            rCuentasCorrientesPagos.ActualizaFechas(eCuentaCorrientePago, actualizarVencimiento)
         End If

         sql.Ventas_Pedidos_FormaPago(venta.IdSucursal, venta.TipoComprobante.IdTipoComprobante, venta.LetraComprobante,
                                      venta.CentroEmisor, venta.NumeroComprobante, venta.FormaPago.IdFormasPago, fechaRendicion:=Nothing, cambiaFormaPago:=cambioFormaPago)

      End Sub)
   End Sub

   Public Sub ActualizarFacturable(entidad As Eniac.Entidades.Entidad)

      Dim oVentas As Entidades.Venta = DirectCast(entidad, Entidades.Venta)
      Dim oCtaCte As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim oVenProd As Reglas.VentasProductos = New Reglas.VentasProductos(da)

         'If Not oVentas.Cliente.CategoriaFiscal.IvaDiscriminado Then
         If Not oVentas.CategoriaFiscal.IvaDiscriminado Then
            With oVentas
               '.ImporteBruto = Decimal.Round((.ImporteBruto / (1 + (.PorcentajeIVA / 100))), 2)
               '.Subtotal = Decimal.Round((.Subtotal / (1 + (.PorcentajeIVA / 100))), 2)
               '.Iva = Decimal.Round((.Subtotal * .PorcentajeIVA / 100), 2)
               '.DescuentoRecargo = Decimal.Round((.DescuentoRecargo / (1 + (.PorcentajeIVA / 100))), 2)
            End With
         End If

         'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
         Dim coe As Integer = oVentas.TipoComprobante.CoeficienteValores

         oVentas.ImporteBruto = oVentas.ImporteBruto * coe
         oVentas.DescuentoRecargo = oVentas.DescuentoRecargo * coe
         oVentas.DescuentoRecargoPorc = oVentas.DescuentoRecargoPorc * coe
         oVentas.Subtotal = oVentas.Subtotal * coe
         oVentas.TotalImpuestos = oVentas.TotalImpuestos * coe
         oVentas.ImporteTotal = oVentas.ImporteTotal * coe

         oVentas.ImportePesos = oVentas.ImportePesos * coe
         oVentas.ImporteDolares = oVentas.ImporteDolares * coe
         oVentas.ImporteTickets = oVentas.ImporteTickets * coe
         'oVentas.ImporteTarjetas = oVentas.ImporteTarjetas * coe

         oVentas.Kilos = oVentas.Kilos * coe

         oVentas.Utilidad = oVentas.Utilidad * coe

         'No es Necesario porque se valida que no acepten cheques de terceros en NCRED o DEV. PROFORMA.
         'oVentas.ImporteCheques

         'Necesito leerlo el count para forzar su generacion y que no de error despues(siempre sera en cero).
         Dim ImpCheques As Decimal
         If oVentas.Cheques.Count > 0 Then
            ImpCheques = oVentas.ImporteCheques
         End If
         '------------------------------------------




         'Graba el comprobante de Venta (Remito o Presupuesto)
         Me.EjecutaSP(oVentas, TipoSP._U, Entidades.Entidad.MetodoGrabacion.Manual, "")

         oCtaCte.CuentasCorrientes_LimpiaFechaExportacion(oVentas.IdSucursal, oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor,
                             oVentas.NumeroComprobante)

         'Vuelvo a dejarlo en positivo porque cada modulo hace el manejo del coeficiente, y sobre todo caja, es llamado de varios lugares.
         oVentas.ImportePesos = oVentas.ImportePesos * coe
         oVentas.ImporteDolares = oVentas.ImporteDolares * coe
         oVentas.ImporteTickets = oVentas.ImporteTickets * coe
         'oVentas.ImporteTarjetas = oVentas.ImporteTarjetas * coe

         'Primero grabo la diferencia de movimientos y el ajuste de stock
         'GetMovimientoVentaDifCantidad: cheque en la base el movimiento original
         If oVentas.TipoComprobante.CoeficienteStock <> 0 Then
            Dim oMov = New Reglas.MovimientosStock(da)

            'Cambio la fecha para que el nuevo movimiento quede registrado con la fecha del ajuste.
            oVentas.Fecha = Date.Now
            oMov.CargarMovimientoStock(Me.GetMovimientoVentaDifCantidad(oVentas), Entidades.Entidad.MetodoGrabacion.Manual, "")
         End If


         'Prefiero borrar el detalle, y volver a insertarlos sin cantidad en 0 y cantidades modificadas.
         Dim VenProd As New Entidades.VentaProducto
         VenProd.IdSucursal = actual.Sucursal.Id
         VenProd.TipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
         VenProd.Letra = oVentas.LetraComprobante
         VenProd.CentroEmisor = oVentas.Impresora.CentroEmisor
         VenProd.NumeroComprobante = oVentas.NumeroComprobante

         oVenProd.EjecutaSP(VenProd, TipoSP._D)
         '--------------------------------------------------

         For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos
            If Prod.Cantidad <> 0 Then

               Prod.CentroEmisor = oVentas.Impresora.CentroEmisor
               Prod.TipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
               Prod.Letra = oVentas.LetraComprobante
               Prod.NumeroComprobante = oVentas.NumeroComprobante

               'me fijo si los valores son grabados con IVA, se los saco y armo un ventaproducto nuevo con los valores a grabar bien
               If Publicos.PreciosConIVA Then ' (New Reglas.Parametros(da)._GetValor(Parametro.Parametros.PRECIOCONIVA).ToUpper() = "SI") Then
                  Prod.PrecioLista = Decimal.Round(Prod.PrecioLista / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
                  Prod.Costo = Decimal.Round(Prod.Costo / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
               End If

               If Not oVentas.CategoriaFiscal.IvaDiscriminado Then
                  Prod.Precio = Decimal.Round(Prod.Precio / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
                  Prod.DescuentoRecargo = Decimal.Round(Prod.DescuentoRecargo / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
                  Prod.DescRecGeneral = Decimal.Round(Prod.DescRecGeneral / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
                  Prod.ImporteTotal = Decimal.Round(Prod.ImporteTotal / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
               End If

               Prod.DescuentoRecargoProducto = Decimal.Round(Prod.DescuentoRecargo / Prod.Cantidad, 2)

               'Los Porcentajes NO se pueden modificar
               'Prod.DescuentoRecargoPorc1 = Decimal.Round((Prod.DescuentoRecargoProducto / Prod.Precio) * 100, 2)
               'Prod.DescuentoRecargoPorc2 = 
               Prod.DescRecGeneralProducto = Decimal.Round(Prod.DescRecGeneral / Prod.Cantidad, 2)
               Prod.PrecioNeto = Decimal.Round(Prod.Precio + Prod.DescuentoRecargoProducto + Prod.DescRecGeneralProducto, 2)
               Prod.ImporteTotalNeto = Decimal.Round(Prod.ImporteTotal + Prod.DescRecGeneral, 2)
               Prod.Utilidad = Decimal.Round((Prod.PrecioNeto - Prod.Costo) * Prod.Cantidad, 2)


               'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
               'En los informes de utilidad y demas, sumo los subtotales (no haga el calculo nuevamente)

               Prod.Cantidad = Prod.Cantidad * coe


               Prod.ImporteImpuesto = Prod.ImporteImpuesto * coe
               Prod.Utilidad = Prod.Utilidad * coe
               Prod.ImporteTotal = Prod.ImporteTotal * coe
               Prod.ImporteTotalNeto = Prod.ImporteTotalNeto * coe

               Prod.Kilos = Prod.Kilos * coe

               'grabo los productos del comprobante de venta
               oVenProd.EjecutaSP(Prod, TipoSP._I)

            End If

         Next

         '--------------------------------------------------------------

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Sub GrabarMercaderiaDespachada(comprobantes As List(Of Entidades.Venta))

      Dim sql As SqlServer.Ventas

      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim rCtaCte = New CuentasCorrientes(da)
         For Each Comprobante As Entidades.Venta In comprobantes

            sql = New SqlServer.Ventas(da)

            sql.GrabaMercaderiaDespachada(Comprobante.IdSucursal, Comprobante.IdTipoComprobante, Comprobante.LetraComprobante,
                                          Comprobante.CentroEmisor, Comprobante.NumeroComprobante, Comprobante.MercDespachada,
                                          Comprobante.NumeroReparto, Comprobante.FechaEnvio, Comprobante.Transportista.idTransportista)
            rCtaCte._ActualizarNumeroReparto(Comprobante, Comprobante.NumeroReparto)

            '-- REQ-30770 --
            ActualizaDespachoMercaderia(Comprobante.IdSucursal, Comprobante.IdTipoComprobante, Comprobante.LetraComprobante,
                                        Comprobante.CentroEmisor, Comprobante.NumeroComprobante, Comprobante.MercDespachada)

         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   ''Public Sub AnularMercaderiaDespachada(comprobantes As List(Of Entidades.Venta))

   ''   Dim sql As SqlServer.Ventas

   ''   Try

   ''      da.OpenConection()
   ''      da.BeginTransaction()

   ''      Dim rCtaCte = New CuentasCorrientes(da)
   ''      For Each Comprobante As Entidades.Venta In comprobantes

   ''         sql = New SqlServer.Ventas(da)

   ''         sql.AnularMercaderiaDespachada(Comprobante.IdSucursal, Comprobante.IdTipoComprobante, Comprobante.LetraComprobante,
   ''                                        Comprobante.CentroEmisor, Comprobante.NumeroComprobante)
   ''         rCtaCte._ActualizarNumeroReparto(Comprobante, numeroReparto:=Nothing)
   ''      Next

   ''      da.CommitTransaction()

   ''   Catch ex As Exception
   ''      da.RollbakTransaction()
   ''      Throw ex
   ''   Finally
   ''      da.CloseConection()
   ''   End Try
   ''End Sub

   Public Sub ActualizaCantidadReintentos(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroComprobante As Long,
                                cantidadReintentos As Integer)
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.ActualizaCantidadReintentos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, cantidadReintentos)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub ActualizaNumeroComprobanteFiscal(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Integer,
                              numeroComprobante As Long,
                              numeroComprobanteFiscal As Long)
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.U_NumeroComprobanteFiscal(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, numeroComprobanteFiscal)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub
End Class
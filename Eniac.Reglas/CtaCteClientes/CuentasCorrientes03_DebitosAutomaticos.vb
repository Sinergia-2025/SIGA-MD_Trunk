Imports System.IO
Partial Class CuentasCorrientes

   Public Function LeerArchivoRoela(nombreArchivo As String, informeStatus As Action(Of String)) As Entidades.ArchivoRespuestaRoelaPMC
      Dim arDa = New Entidades.ArchivoRespuestaRoelaPMC()

      Using reau = New StreamReader(nombreArchivo)
         '-- Informa Status.- -----------------
         informeStatus("Cargando archivo....")

         Dim linea = reau.ReadLine()
         Dim cont = 0I
         Do While linea IsNot Nothing
            cont += 1
            informeStatus(String.Format("Leyendo linea {0}....", cont))
            arDa.Datos.Add(ParseLinea(linea))
            linea = reau.ReadLine()
         Loop

         '-- Informa Status.- -----------------
         informeStatus("Generando información....")
      End Using

      Validar(arDa, informeStatus)

      Return arDa
   End Function

   Private Sub Validar(arDa As Entidades.ArchivoRespuestaRoelaPMC, informeStatus As Action(Of String))
      EjecutaConConexion(Sub() _Validar(arDa, informeStatus))
   End Sub
   Private Sub _Validar(arDa As Entidades.ArchivoRespuestaRoelaPMC, informeStatus As Action(Of String))
      '-- Variables de Accion y mensaje.- --
      Dim rClientes = New Clientes(da)
      Dim rCtaCtePago = New CuentasCorrientesPagos(da)

      Dim linea = 0I
      Dim total = arDa.Datos.Count
      For Each dato In arDa.Datos
         Dim accion = "A"
         Dim mensaje = New StringBuilder()
         linea += 1
         informeStatus(String.Format("Validando linea {0}/{1}....", linea, total))

         Dim cliente = rClientes.GetUnoLivianoPorCodigo(dato.IdentificadorDelUsuario, AccionesSiNoExisteRegistro.Nulo)
         If cliente IsNot Nothing Then
            dato.NombreCliente = cliente.NombreCliente
         Else
            accion = "X"
            mensaje.AppendFormat("Identificador de Cliente inválido - ")
         End If

         '-- En base al Codigo de Barra busca la Ficha en CuentasCorrientesPagos.- --------------------
         Using dtComprobante = rCtaCtePago.GetPorCodigoBarra(dato.CodigoDeBarra, codigoBarraSirplus:=Nothing)
            If dtComprobante IsNot Nothing AndAlso dtComprobante.Rows.Count > 0 Then
               '-- Si lo localiza carga los datos.- --------------------------------
               For Each dr As DataRow In dtComprobante.Rows
                  dato.IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
                  dato.Letra = dr.Field(Of String)("Letra")
                  dato.CentroEmisor = dr.Field(Of Integer)("CentroEmisor")
                  dato.NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
                  dato.Cuota = dr.Field(Of Integer)("CuotaNumero")
                  dato.SaldoCuota = dr.Field(Of Decimal)("SaldoCuota")
                  If dr.Field(Of Decimal)("SaldoCuota") <= 0 Then
                     accion = "X"
                     mensaje.AppendFormat("Saldo Insuficiente para cancelacion de Cuota - ")
                  ElseIf dato.ImportePagado > dr.Field(Of Decimal)("SaldoCuota") Then
                     accion = "D"
                     mensaje.Insert(0, "(ND) Saldo Insuficiente de Cuota se ingresará una Nota de Débito - ")
                  End If
               Next
            Else
               If cliente IsNot Nothing Then
                  Using dtAlternativo = rCtaCtePago.GetPorCodigoBarraAlternativo(cliente.IdCliente, dato.FechaDeVencimiento, dato.ImportePagado)
                     If dtAlternativo IsNot Nothing AndAlso dtAlternativo.Rows.Count > 0 Then
                        For Each dr As DataRow In dtAlternativo.Rows
                           dato.CodigoDeBarra = dr.Field(Of String)("CodigoDeBarra")
                           dato.IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
                           dato.Letra = dr.Field(Of String)("Letra")
                           dato.CentroEmisor = dr.Field(Of Integer)("CentroEmisor")
                           dato.NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
                           dato.Cuota = dr.Field(Of Integer)("CuotaNumero")
                           dato.SaldoCuota = dr.Field(Of Decimal)("SaldoCuota")
                           If dr.Field(Of Decimal)("SaldoCuota") <= 0 Then
                              accion = "X"
                              mensaje.AppendFormat("Saldo Insuficiente para cancelacion de Cuota - ")
                           ElseIf dato.ImportePagado > dr.Field(Of Decimal)("SaldoCuota") Then
                              accion = "D"
                              mensaje.Insert(0, "(ND) Saldo Insuficiente de Cuota se ingresará una Nota de Débito - ")
                           End If
                        Next
                     Else
                        accion = "X"
                        mensaje.AppendFormat("Codigo de Barra Inexistente - ")
                     End If
                  End Using
               Else
                  accion = "X"
                  mensaje.AppendFormat("Codigo de Barra Inexistente - ")
               End If
            End If
         End Using

         '-- Carga Mensajes.- --
         dato.Proceso = accion = "A" Or accion = "D"
         dato.Accion = accion
         dato.Mensaje = mensaje.ToString()
         '----------------------
      Next

   End Sub
   Private Function ParseLinea(linea As String) As Entidades.ArchivoRespuestaRoelaPMCDatos
      Dim dato = New Entidades.ArchivoRespuestaRoelaPMCDatos()
      With dato
         'Fecha en la que el cliente efectuó el pago.
         dato.FechaDePago = New DateTime(Integer.Parse(linea.Substring(0, 4)), Integer.Parse(linea.Substring(4, 2)), Integer.Parse(linea.Substring(6, 2)))
         'Fecha de acreditación del pago en cuenta corriente de Banco Roela.
         dato.FechaDeAcreditacion = New DateTime(Integer.Parse(linea.Substring(8, 4)), Integer.Parse(linea.Substring(12, 2)), Integer.Parse(linea.Substring(14, 2)))
         'Surge del Primer Vencimiento del código de barra. 
         dato.FechaDeVencimiento = New DateTime(Integer.Parse(linea.Substring(16, 4)), Integer.Parse(linea.Substring(20, 2)), Integer.Parse(linea.Substring(22, 2)))
         'Importe pagado: Ej: Si el monto fue de $1.490,80, se informa 0149080
         dato.ImportePagado = Decimal.Parse(linea.Substring(24, 7)) / 100
         'Surge del Identificador de Usuario del código de barra. Este dato le permite identificar a quien imputar el
         'pago. En caso de las cobranzas de Link Pagos y Pago Mis Cuentas, surge de tomar las posiciones 2º a 9º del
         'Identificador de Usuario ó Nro de Referencia del archivo subido a Link Pagos y Pago Mis Cuentas. 
         dato.IdentificadorDelUsuario = Long.Parse(linea.Substring(31, 8))

         'Surge del Identificador de Concepto
         'del código de barra. En caso de las cobranzas de Link Pagos y Pago Mis Cuentas, surge de tomar la 1º posición del Identificador
         'de Usuario ó Nro de Referencia del archivo subido a Link Pagos y Pago Mis Cuentas.
         dato.IdentificadorDeConcepto = Long.Parse(linea.Substring(39, 1))

         '-- Obtienen el Codigo de Barra.- ----------
         dato.CodigoDeBarra = linea.Substring(40, 56)
         dato.CanalDeCobro = linea.Substring(116, 3)
      End With

      Return dato
   End Function

   Public Function GenerarPagosRoela(_arRoelaPMC As Entidades.ArchivoRespuestaRoelaPMC, tipoComprobante As Entidades.TipoComprobante,
                                     idCaja As Integer, idFormaPago As Integer, cobrador As Entidades.Empleado, idCuentaBancaria As Integer,
                                     idFuncion As String, idTipoLiquidacion As Integer?, idSubfuncion As String, nombreArchivo As String,
                                     informeStatus As Action(Of String)) As Entidades.CuentasCorrientesGenerarPagosRoelaResult
      Return EjecutaConConexion(Function() _GenerarPagosRoela(_arRoelaPMC,
                                                  tipoComprobante, idCaja,
                                                  idFormaPago, cobrador, idCuentaBancaria,
                                                  idFuncion, idTipoLiquidacion, idSubfuncion, nombreArchivo,
                                                  informeStatus))
   End Function
   Private Function _GenerarPagosRoela(_arRoelaPMC As Entidades.ArchivoRespuestaRoelaPMC, tipoComprobante As Entidades.TipoComprobante,
                                       idCaja As Integer, idFormaPago As Integer, cobrador As Entidades.Empleado, idCuentaBancaria As Integer,
                                       idFuncion As String, idTipoLiquidacion As Integer?, idSubfuncion As String, nombreArchivo As String,
                                       informeStatus As Action(Of String)) As Entidades.CuentasCorrientesGenerarPagosRoelaResult
      If informeStatus Is Nothing Then informeStatus = Sub(a) Console.WriteLine(a)

      Dim result = New Entidades.CuentasCorrientesGenerarPagosRoelaResult()

      Dim rClientes = New Clientes(da)
      Dim rCtaCteRec = New CtaCteClienteRecibo()
      Dim rCtaCtePago = New CuentasCorrientesPagos(da)
      Dim rVenta = New Ventas(da)
      Dim cache = New BusquedasCacheadas()

      'CHEQUEAR
      For Each arc In _arRoelaPMC.Datos.FindAll(Function(a) a.Proceso = True)
         Try
            EjecutaSoloConTransaccion(
               Sub()
                  result.CantidadRegistros += 1

                  Dim cli = rClientes.GetUnoPorCodigo(arc.IdentificadorDelUsuario)
                  If cli Is Nothing Then
                     Throw New Exception(String.Format("El cliente identificado con el código {0} NO existe en los registros, controle esta información.", arc.IdentificadorDelUsuario))
                  End If

                  '-- En base al Codigo de Barra busca la Ficha en CuentasCorrientesPagos.- --------------------
                  Dim dtComprobante = rCtaCtePago.GetPorCodigoBarra(arc.CodigoDeBarra, codigoBarraSirplus:=Nothing)
                  If dtComprobante IsNot Nothing AndAlso dtComprobante.Rows.Count = 0 Then
                     Throw New Exception(String.Format("Codigo de Barra {0} Inexistente", arc.CodigoDeBarra))
                  End If

                  informeStatus(String.Format("Generando pago de Cliente {0}.", arc.NombreCliente))

                  Dim letra = tipoComprobante.LetrasHabilitadas
                  'Si tiene configurado mas de una Letra (A,B,C) significa que la toma de la categoria fiscal en lugar de fija (R o X)
                  If letra.Trim.Length > 1 Then
                     letra = cli.CategoriaFiscal.LetraFiscal
                  End If

                  Dim observ = String.Format("COBRO REALIZADO VIA: {0}", arc.CanalDeCobroResuelto)
                  '-- REQ-36216.- -----------------
                  Dim fechaRecibo = arc.FechaDePago
                  '--------------------------------
                  Dim oCuentaCorriente = rCtaCteRec.GetCtaCteCliente(
                                                tipoComprobante.IdTipoComprobante, letra, numeroComprobante:=0,
                                                fechaRecibo, idFormaPago, cli, cli.Vendedor, cobrador,
                                                observ,
                                                arc.ImportePagado,
                                                importeEfectivo:=0, importeDolares:=0, importeTarjetas:=0, importeTransferencia:=arc.ImportePagado,
                                                idCuentaBancaria,
                                                idCaja, pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                da,
                                                nroOrdenCompra:=0)

                  oCuentaCorriente.Pagos = GetPagosDeCliente(oCuentaCorriente.TipoComprobante,
                                                             oCuentaCorriente.IdSucursal,
                                                             oCuentaCorriente.Cliente.IdCliente,
                                                             oCuentaCorriente.ImporteTotal,
                                                             idTipoLiquidacion:=Nothing,
                                                             arc.IdTipoComprobante, arc.Letra, arc.CentroEmisor.ToShort(), arc.NumeroComprobante,
                                                             arc.Cuota,
                                                             soloCuotaIndicada:=True)

                  If oCuentaCorriente.Pagos.Count = 0 Then
                     arc.Accion = "E"
                     arc.Proceso = False
                     arc.Mensaje = String.Format("Error generando recibo: La cuota {4} del comprobante {0} {1} {2:0000}-{3:00000000} ya se encuentra saldada.",
                                                 arc.IdTipoComprobante, arc.Letra, arc.CentroEmisor.ToShort(), arc.NumeroComprobante, arc.Cuota)
                     Exit Sub
                  End If

                  Dim importeND = oCuentaCorriente.ImporteTotal - oCuentaCorriente.Pagos.Sum(Function(dr) dr.SaldoCuota)
                  If importeND > 0 Then

                     informeStatus(String.Format("Generando Nota de Débito pago de Cliente {0}.", arc.NombreCliente))

                     Dim dr = oCuentaCorriente.Pagos.First()
                     Dim tpComp = oCuentaCorriente.Pagos.First().TipoComprobante
                     Dim idTpCompNC = If(Not String.IsNullOrWhiteSpace(tpComp.IdTipoComprobanteNDeb), tpComp.IdTipoComprobanteNDeb,
                                         If(tpComp.GrabaLibro, Publicos.IdNotaDebitoGrabaLibro, Publicos.IdNotaDebitoNoGrabaLibro))

                     Dim ncVenta = rVenta.CreaVenta(dr.IdSucursal,
                                                    cache.BuscaTipoComprobante(idTpCompNC), letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0,
                                                    cliente:=cli, categoriaFiscal:=Nothing,
                                                    fecha:=fechaRecibo, vendedor:=cli.Vendedor,
                                                    transportista:=Nothing, formaPago:=dr.FormaPago,
                                                    descuentoRecargoPorc:=Nothing, idCaja:=idCaja, cotizacionDolar:=Nothing, mercDespachada:=False, numeroReparto:=Nothing,
                                                    fechaEnvio:=Nothing, proveedor:=Nothing,
                                                    observaciones:="Nota Débito Cobro con Intereses Roela",
                                                    cobrador:=Nothing, clienteVinculado:=Nothing, nroOrdenCompra:=0)

                     ncVenta.Invocados.Add(New Entidades.VentaInvocada() With
                                                     {.IdSucursal = dr.IdSucursal,
                                                      .IdTipoComprobante = dr.IdTipoComprobante,
                                                      .TipoTipoComprobante = cache.BuscaTipoComprobante(dr.IdTipoComprobante).Tipo,
                                                      .Letra = dr.Letra,
                                                      .CentroEmisor = Convert.ToInt16(dr.CentroEmisor),
                                                      .NumeroComprobante = dr.NumeroComprobante,
                                                      .Fecha = fechaRecibo})
                     ncVenta.SeleccionoInvocados = Entidades.Publicos.SiNoTodos.SI


                     Dim idProducto = If(String.IsNullOrWhiteSpace(tpComp.IdProductoNDeb), Publicos.CtaCte.IDProductoDescuentoRecargo, tpComp.IdProductoNDeb)

                     Dim prod = cache.BuscaProductoEntidadPorId(idProducto)
                     Dim ncProd = rVenta.CreaVentaProducto(prod,
                                                           prod.NombreProducto,
                                                           descuentoRecargoPorc1:=0,
                                                           descuentoRecargoPorc2:=0,
                                                           importeND,
                                                           1,
                                                           cache.BuscaTiposImpuestos(prod.IdTipoImpuesto),
                                                           prod.Alicuota,
                                                           cache.BuscaListaDePrecios(Publicos.ListaPreciosPredeterminada),
                                                           fechaEntrega:=Nothing, tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL, nota:=String.Empty, idEstadoVenta:=Nothing,
                                                           venta:=ncVenta, redondeoEnCalculo:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                     rVenta.AgregarVentaProducto(ncVenta, ncProd, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)

                     rVenta.Inserta(ncVenta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
                     result.CantidadNotasDebito += 1
                     result.CantidadNotasDebitoElectronicas += If(ncVenta.TipoComprobante.EsElectronico And ncVenta.TipoComprobante.EsPreElectronico, 1, 0)

                     oCuentaCorriente.Pagos.Add(New Entidades.CuentaCorrientePago() With
                                                {
                                                   .IdSucursal = ncVenta.IdSucursal,
                                                   .TipoComprobante = ncVenta.TipoComprobante,
                                                   .Letra = ncVenta.LetraComprobante,
                                                   .CentroEmisor = ncVenta.CentroEmisor,
                                                   .NumeroComprobante = ncVenta.NumeroComprobante,
                                                   .Cuota = 1,  'La NC debería haberse generado con una sola cuota. Si esto cambia debo buscar el comprobante y buscar todas sus cuotas.
                                                   .FechaEmision = ncVenta.Fecha,
                                                   .FechaVencimiento = ncVenta.CuentaCorriente.Pagos.First().FechaVencimiento,
                                                   .ImporteCuota = importeND,
                                                   .SaldoCuota = importeND,
                                                   .Paga = importeND,
                                                   .Usuario = actual.Nombre
                                                })

                  End If

                  Dim listadosCtasCtes = New List(Of Entidades.CuentaCorriente) From {oCuentaCorriente}
                  _GrabarPagosAutomaticos(listadosCtasCtes, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, idTipoLiquidacion, idSubfuncion, nombreArchivo:=String.Empty, True)

                  arc.Accion = "I"

               End Sub)
         Catch ex As Exception
            Throw New Exception(String.Format("Error registrando el recibo de {0}: {1}", arc.NombreCliente, ex.Message), ex)
         End Try
      Next
      EjecutaSoloConTransaccion(
         Sub()
            Dim ArchivoImportado = New Entidades.ArchivoImportado()
            With ArchivoImportado
               .IdFuncion = idFuncion
               .IdSubFuncion = idSubfuncion
               .NombreArchivo = nombreArchivo
               .IdUsuario = actual.Nombre
               .NombrePC = My.Computer.Name
               .IdSucursal = actual.Sucursal.IdSucursal
               .FechaLectura = Date.Now
            End With
            Dim rArchivosImportados = New ArchivosImportados(da)
            rArchivosImportados.Insertar(ArchivoImportado)
         End Sub)

      Return result
   End Function

   Public Function GenerarPagosSIRPLUS(_arSIRPLUS As Entidades.ArchivoRespuestaRoelaPMC, tipoComprobante As Entidades.TipoComprobante,
                                     idCaja As Integer, idFormaPago As Integer, cobrador As Entidades.Empleado, idCuentaBancaria As Integer,
                                     idFuncion As String, idTipoLiquidacion As Integer?, idSubfuncion As String, nombreArchivo As String,
                                     informeStatus As Action(Of String)) As Entidades.CuentasCorrientesGenerarPagosRoelaResult
      Return EjecutaConConexion(Function() _GenerarPagosSIRPLUS(_arSIRPLUS,
                                                  tipoComprobante, idCaja,
                                                  idFormaPago, cobrador, idCuentaBancaria,
                                                  idFuncion, idTipoLiquidacion, idSubfuncion, nombreArchivo,
                                                  informeStatus))
   End Function
   Private Function _GenerarPagosSIRPLUS(_arSIRPLUS As Entidades.ArchivoRespuestaRoelaPMC, tipoComprobante As Entidades.TipoComprobante,
                                       idCaja As Integer, idFormaPago As Integer, cobrador As Entidades.Empleado, idCuentaBancaria As Integer,
                                       idFuncion As String, idTipoLiquidacion As Integer?, idSubfuncion As String, nombreArchivo As String,
                                       informeStatus As Action(Of String)) As Entidades.CuentasCorrientesGenerarPagosRoelaResult
      If informeStatus Is Nothing Then informeStatus = Sub(a) Console.WriteLine(a)

      Dim result = New Entidades.CuentasCorrientesGenerarPagosRoelaResult()

      Dim rClientes = New Clientes(da)
      Dim rCtaCteRec = New CtaCteClienteRecibo()
      Dim rCtaCtePago = New CuentasCorrientesPagos(da)
      Dim rVenta = New Ventas(da)
      Dim cache = New BusquedasCacheadas()

      'CHEQUEAR
      For Each arc In _arSIRPLUS.Datos.FindAll(Function(a) a.Proceso = True)
         Try
            EjecutaSoloConTransaccion(
               Sub()
                  result.CantidadRegistros += 1

                  'Dim cli = rClientes.GetUnoPorCodigo(arc.IdentificadorDelUsuario)
                  'If cli Is Nothing Then
                  '   Throw New Exception(String.Format("El cliente identificado con el código {0} NO existe en los registros, controle esta información.", arc.IdentificadorDelUsuario))
                  'End If

                  '-- En base al Codigo de Barra busca la Ficha en CuentasCorrientesPagos.- --------------------
                  Dim dtComprobante = rCtaCtePago.GetPorCodigoBarra(codigoBarra:=Nothing, codigoBarraSirplus:=arc.CodigoDeBarra)

                  If dtComprobante IsNot Nothing AndAlso dtComprobante.Rows.Count = 0 Then
                     Throw New Exception(String.Format("Codigo de Barra {0} Inexistente", arc.CodigoDeBarra))
                  End If

                  Dim cli = rClientes._GetUno(Long.Parse(dtComprobante.Rows(0).Item("IdCliente").ToString()))

                  informeStatus(String.Format("Generando pago de Cliente {0}.", arc.NombreCliente))

                  Dim letra = tipoComprobante.LetrasHabilitadas
                  'Si tiene configurado mas de una Letra (A,B,C) significa que la toma de la categoria fiscal en lugar de fija (R o X)
                  If letra.Trim.Length > 1 Then
                     letra = cli.CategoriaFiscal.LetraFiscal
                  End If

                  Dim observ = String.Format("COBRO REALIZADO VIA: {0}", arc.CanalDeCobroResueltoSIRPLUS)
                  '-- REQ-36216.- -----------------
                  Dim fechaRecibo = arc.FechaDePago
                  '--------------------------------
                  Dim oCuentaCorriente = rCtaCteRec.GetCtaCteCliente(
                                                tipoComprobante.IdTipoComprobante, letra, numeroComprobante:=0,
                                                fechaRecibo, idFormaPago, cli, cli.Vendedor, cobrador,
                                                observ,
                                                arc.ImportePagado,
                                                importeEfectivo:=0, importeDolares:=0, importeTarjetas:=0,
                                                arc.ImportePagado, idCuentaBancaria,
                                                idCaja, pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                da,
                                                nroOrdenCompra:=0)

                  oCuentaCorriente.Pagos = GetPagosDeCliente(oCuentaCorriente.TipoComprobante,
                                                             oCuentaCorriente.IdSucursal,
                                                             oCuentaCorriente.Cliente.IdCliente,
                                                             oCuentaCorriente.ImporteTotal,
                                                             idTipoLiquidacion:=Nothing,
                                                             arc.IdTipoComprobante, arc.Letra, arc.CentroEmisor.ToShort(), arc.NumeroComprobante,
                                                             arc.Cuota,
                                                             soloCuotaIndicada:=True)

                  If oCuentaCorriente.Pagos.Count = 0 Then
                     arc.Accion = "E"
                     arc.Proceso = False
                     arc.Mensaje = String.Format("Error generando recibo: La cuota {4} del comprobante {0} {1} {2:0000}-{3:00000000} ya se encuentra saldada.",
                                                 arc.IdTipoComprobante, arc.Letra, arc.CentroEmisor.ToShort(), arc.NumeroComprobante, arc.Cuota)
                     Exit Sub
                  End If

                  Dim importeND = oCuentaCorriente.ImporteTotal - oCuentaCorriente.Pagos.Sum(Function(dr) dr.SaldoCuota)
                  If importeND > 0 Then

                     informeStatus(String.Format("Generando Nota de Débito pago de Cliente {0}.", arc.NombreCliente))

                     Dim dr = oCuentaCorriente.Pagos.First()
                     Dim tpComp = oCuentaCorriente.Pagos.First().TipoComprobante
                     Dim idTpCompNC = If(Not String.IsNullOrWhiteSpace(tpComp.IdTipoComprobanteNDeb), tpComp.IdTipoComprobanteNDeb,
                                         If(tpComp.GrabaLibro, Publicos.IdNotaDebitoGrabaLibro, Publicos.IdNotaDebitoNoGrabaLibro))

                     Dim ncVenta = rVenta.CreaVenta(dr.IdSucursal,
                                                    cache.BuscaTipoComprobante(idTpCompNC), letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0,
                                                    cliente:=cli, categoriaFiscal:=Nothing,
                                                    fecha:=fechaRecibo, vendedor:=cli.Vendedor,
                                                    transportista:=Nothing, formaPago:=dr.FormaPago,
                                                    descuentoRecargoPorc:=Nothing, idCaja:=idCaja, cotizacionDolar:=Nothing, mercDespachada:=False, numeroReparto:=Nothing,
                                                    fechaEnvio:=Nothing, proveedor:=Nothing,
                                                    observaciones:="Nota Débito Cobro con Intereses Roela",
                                                    cobrador:=Nothing, clienteVinculado:=Nothing, nroOrdenCompra:=0)

                     ncVenta.Invocados.Add(New Entidades.VentaInvocada() With
                                                     {.IdSucursal = dr.IdSucursal,
                                                      .IdTipoComprobante = dr.IdTipoComprobante,
                                                      .TipoTipoComprobante = cache.BuscaTipoComprobante(dr.IdTipoComprobante).Tipo,
                                                      .Letra = dr.Letra,
                                                      .CentroEmisor = Convert.ToInt16(dr.CentroEmisor),
                                                      .NumeroComprobante = dr.NumeroComprobante,
                                                      .Fecha = fechaRecibo})
                     ncVenta.SeleccionoInvocados = Entidades.Publicos.SiNoTodos.SI


                     Dim idProducto = If(String.IsNullOrWhiteSpace(tpComp.IdProductoNDeb), Publicos.CtaCte.IDProductoDescuentoRecargo, tpComp.IdProductoNDeb)

                     Dim prod = cache.BuscaProductoEntidadPorId(idProducto)
                     Dim ncProd = rVenta.CreaVentaProducto(prod,
                                                           prod.NombreProducto,
                                                           descuentoRecargoPorc1:=0,
                                                           descuentoRecargoPorc2:=0,
                                                           importeND,
                                                           1,
                                                           cache.BuscaTiposImpuestos(prod.IdTipoImpuesto),
                                                           prod.Alicuota,
                                                           cache.BuscaListaDePrecios(Publicos.ListaPreciosPredeterminada),
                                                           fechaEntrega:=Nothing, tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL, nota:=String.Empty, idEstadoVenta:=Nothing,
                                                           venta:=ncVenta, redondeoEnCalculo:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                     rVenta.AgregarVentaProducto(ncVenta, ncProd, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)

                     rVenta.Inserta(ncVenta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
                     result.CantidadNotasDebito += 1
                     result.CantidadNotasDebitoElectronicas += If(ncVenta.TipoComprobante.EsElectronico And ncVenta.TipoComprobante.EsPreElectronico, 1, 0)

                     oCuentaCorriente.Pagos.Add(New Entidades.CuentaCorrientePago() With
                                                {
                                                   .IdSucursal = ncVenta.IdSucursal,
                                                   .TipoComprobante = ncVenta.TipoComprobante,
                                                   .Letra = ncVenta.LetraComprobante,
                                                   .CentroEmisor = ncVenta.CentroEmisor,
                                                   .NumeroComprobante = ncVenta.NumeroComprobante,
                                                   .Cuota = 1,  'La NC debería haberse generado con una sola cuota. Si esto cambia debo buscar el comprobante y buscar todas sus cuotas.
                                                   .FechaEmision = ncVenta.Fecha,
                                                   .FechaVencimiento = ncVenta.CuentaCorriente.Pagos.First().FechaVencimiento,
                                                   .ImporteCuota = importeND,
                                                   .SaldoCuota = importeND,
                                                   .Paga = importeND,
                                                   .Usuario = actual.Nombre
                                                })

                  End If

                  Dim listadosCtasCtes = New List(Of Entidades.CuentaCorriente) From {oCuentaCorriente}
                  _GrabarPagosAutomaticos(listadosCtasCtes, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, idTipoLiquidacion, idSubfuncion, nombreArchivo:=String.Empty, True)

                  arc.Accion = "I"

               End Sub)
         Catch ex As Exception
            Throw New Exception(String.Format("Error registrando el recibo de {0}: {1}", arc.NombreCliente, ex.Message), ex)
         End Try
      Next
      EjecutaSoloConTransaccion(
         Sub()
            Dim ArchivoImportado = New Entidades.ArchivoImportado()
            With ArchivoImportado
               .IdFuncion = idFuncion
               .IdSubFuncion = idSubfuncion
               .NombreArchivo = nombreArchivo
               .IdUsuario = actual.Nombre
               .NombrePC = My.Computer.Name
               .IdSucursal = actual.Sucursal.IdSucursal
               .FechaLectura = Date.Now
            End With
            Dim rArchivosImportados = New ArchivosImportados(da)
            rArchivosImportados.Insertar(ArchivoImportado)
         End Sub)

      Return result
   End Function



End Class
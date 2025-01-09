'Imports Eniac.Entidades

Public Class CuentasCorrientesProv
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("CuentasCorrientesProv", accesoDatos)
   End Sub

#End Region

#Region "Metodos"

   Public Function GetProximoNumero(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer) As Integer
      Return New SqlServer.CuentasCorrientesProv(da).GetNumeroMaximoComprasNumeros(idSucursal, idTipoComprobante, letraFiscal, emisor) + 1
   End Function
   ''' <summary>
   ''' Traer siguiente numero de Comprobante.- --
   ''' </summary>
   Public Function GetProximoNumeroCC(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer) As Long
      Return New SqlServer.CuentasCorrientesProv(da).GetNumeroMaximo(idSucursal, idTipoComprobante, letraFiscal, emisor) + 1
   End Function

   Public Sub GrabaCuentaCorrienteProv(ent As Entidades.CuentaCorrienteProv, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      Dim ajuste As Decimal = ent.TipoComprobante.CoeficienteValores
      Dim saldo As Decimal = 0
      Dim cantidadCuotas As Integer = 0
      Dim TotalAplicado As Decimal = 0

      If Not ent.TipoComprobante.EsRecibo Then
         '         If ent.TipoComprobante.IdTipoComprobante.Trim() <> "PAGO" And ent.TipoComprobante.IdTipoComprobante.Trim() <> "PAGOPROV" Then
         'Si es NCRED viene negativo y lo da vuelva, no corresponde. El valor siempre esta bien.
         'saldo = ent.ImporteTotal * ajuste
         saldo = ent.ImporteTotal
         cantidadCuotas = ent.Pagos.Count
      Else

         For Each pag As Entidades.CuentaCorrienteProvPago In ent.Pagos
            TotalAplicado = TotalAplicado + pag.Paga
         Next

         'Si es mayor implica que dejo plata a cuenta.
         If ent.ImporteTotal > TotalAplicado Then
            saldo = ent.ImporteTotal - TotalAplicado
         End If

         ent.ImporteTotal *= ajuste
         saldo *= ajuste

      End If

      ''Lo asigno porque despues es utilizado (si deja anticipo).
      ent.Saldo = saldo

      'Actualiza la fecha de hoy, si se dejo la pantalla abierta mucho tiempo

      If ent.Fecha.Date = Date.Now.Date Then
         ent.Fecha = Date.Now
      End If

      ent.IdEstado = "NORMAL"
      ent.Usuario = actual.Nombre
      ent.FechaActualizacion = Date.Now()

      Dim sql = New SqlServer.CuentasCorrientesProv(da)

      Dim imprimeSaldos As Boolean? = Nothing

      If ent.TipoComprobante.EsRecibo Then
         '  If ent.TipoComprobante.IdTipoComprobante = "PAGO" Or ent.TipoComprobante.IdTipoComprobante = "PAGOPROV" Then
         imprimeSaldos = True
         ent.ImprimeSaldos = True
      End If

      Publicos.GetSistema().ControlaValidezDeFecha(ent.Fecha)
      Publicos.VerificaFechaUltimoLogin()
      sql.CuentasCorrientesProv_I(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante,
                                    ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Fecha,
                                    ent.FechaVencimiento, ent.ImporteTotal,
                                    ent.Proveedor.IdProveedor, ent.FormaPago.IdFormasPago,
                                    ent.Observacion, ent.Saldo, cantidadCuotas,
                                    ent.ImportePesos, ent.ImporteDolares, ent.ImporteTickets, ent.ImporteCheques,
                                    ent.ImporteTransfBancaria, ent.CuentaBancariaTransfBanc.IdCuentaBancaria,
                                    ent.ImporteRetenciones, ent.ImporteTarjetas, ent.IdEstado, ent.Usuario, ent.FechaActualizacion,
                                    MetodoGrabacion, IdFuncion, imprimeSaldos, ent.CotizacionDolar, ent.RefProveedor, ent.FechaTransferencia,
                                    ent.PromedioDiasPago, ent.SaldoCtaCte, ent.NumeroOrdenCompra)


      Dim CCP = New CuentasCorrientesProvPagos(da)
      Dim cuota As Integer = 1
      Dim TipoComprobantePago As String = String.Empty

      'graba todos los pagos que tiene que realizar por la cuenta corriente
      For Each pag As Entidades.CuentaCorrienteProvPago In ent.Pagos
         pag.CuentaCorrienteProv = ent

         'La fecha de vencimiento del Pago que corresponde es la de emision, asi las estadisticas marcan bien las diferencias.

         If pag.CuentaCorrienteProv.TipoComprobante.EsRecibo Then
            '  If pag.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante.Trim() = "PAGO" Or pag.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante.Trim() = "PAGOPROV" Then
            pag.FechaVencimiento = ent.Fecha
         End If

         CCP.GrabaCuentaCorrienteProvPagos(pag, cuota)

         If pag.CuentaCorrienteProv.TipoComprobante.EsRecibo Then
            '      If pag.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante.Trim() = "PAGO" Or pag.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante.Trim() = "PAGOPROV" Then
            CCP.ActualizaComprobantes(pag, cuota)
         End If

         cuota += 1

         'Si esta aplicando un ANTICIPO, le quito ese pago al recibo (para nivelar la cuenta) que tenia el monto en el saldo. En la tabla detalle tiene otra logica.


         If pag.TipoComprobante.EsAnticipo Then
            '  If pag.TipoComprobante.IdTipoComprobante.Trim() = "ANTICIPO" Or pag.TipoComprobante.IdTipoComprobante.Trim() = "ANTICIPOPROV" Then
            'Con el Recibo Provisio puede aplicar un ANTICIPO que venga de antes, asi que luego debe mirar RECIBO y no RECIBOPROV
            'If pag.TipoComprobante.IdTipoComprobante.Trim() = "ANTICIPO" Then
            '   TipoComprobantePago = "PAGO"
            'Else
            '   TipoComprobantePago = "PAGOPROV"
            'End If

            If String.IsNullOrEmpty(pag.TipoComprobante.IdTipoComprobanteSecundario) Then
               Throw New Exception("El cobro tiene un Anticipo pero el comprobante " & pag.TipoComprobante.Descripcion.Trim() & ", No tiene Asignado el IdTipoComprobanteSecundario")

            End If
            TipoComprobantePago = pag.TipoComprobante.IdTipoComprobanteSecundario

            'El Anticipo tiene el Numero del recibo que lo emitio, por eso uso sus datos.
            sql.CuentasCorrientesProv_AplicaAlSaldo(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                                         TipoComprobantePago, pag.Letra,
                                                         Short.Parse(pag.CentroEmisor.ToString()), pag.NumeroComprobante, pag.Paga * ajuste)
         End If

      Next

      ent.ImporteTotal = ent.ImporteTotal * ajuste

      'Si es un Recibo y Pago de mas, dejo la plata a Cuenta.

      If (ent.TipoComprobante.EsRecibo) And ent.ImporteTotal > TotalAplicado Then
         '   If (ent.TipoComprobante.IdTipoComprobante.Trim() = "PAGO" Or ent.TipoComprobante.IdTipoComprobante.Trim() = "PAGOPROV") And ent.ImporteTotal > TotalAplicado Then

         Dim tipoComp As Entidades.TipoComprobante

         If String.IsNullOrWhiteSpace(ent.TipoComprobante.IdTipoComprobanteSecundario) Then
            Throw New Exception(String.Format("El tipo de comprobante {0} no tiene configurado un comprobante secundario." + Environment.NewLine + Environment.NewLine +
                                              "No es posible generar el anticipo.", ent.TipoComprobante.Descripcion))
         End If
         tipoComp = New Reglas.TiposComprobantes(da).GetUno(ent.TipoComprobante.IdTipoComprobanteSecundario.ToString())


         'If ent.TipoComprobante.GrabaLibro Then
         '   tipoComp = New Reglas.TiposComprobantes(da).GetUno("ANTICIPO")
         'Else
         '   tipoComp = New Reglas.TiposComprobantes(da).GetUno("ANTICIPOPROV")
         'End If


         Dim ajuste2 As Decimal = tipoComp.CoeficienteValores
         Dim anticipo As Decimal = (ent.ImporteTotal - TotalAplicado) * ajuste2
         imprimeSaldos = Nothing

         Publicos.GetSistema().ControlaValidezDeFecha(ent.Fecha)
         Reglas.Publicos.VerificaFechaUltimoLogin()
         sql.CuentasCorrientesProv_I(ent.IdSucursal, tipoComp.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                       ent.Fecha, ent.FechaVencimiento, anticipo, ent.Proveedor.IdProveedor,
                                       ent.FormaPago.IdFormasPago, ent.Observacion, anticipo, 1, anticipo, 0, 0, 0, 0, 0, 0, 0, ent.IdEstado, ent.Usuario, ent.FechaActualizacion,
                                       MetodoGrabacion, IdFuncion, imprimeSaldos, ent.CotizacionDolar, ent.RefProveedor, ent.FechaTransferencia, ent.PromedioDiasPago, ent.SaldoCtaCte, ent.NumeroOrdenCompra)

         '   Dim sql2 As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

         Dim ecc As Entidades.CuentaCorrienteProvPago = New Entidades.CuentaCorrienteProvPago()
         ecc.TipoComprobante = tipoComp
         ecc.CuentaCorrienteProv = ent
         ecc.Paga = saldo * ecc.TipoComprobante.CoeficienteValores
         ecc.FechaVencimiento = ent.FechaVencimiento
         ecc.SaldoCuota = saldo * ecc.TipoComprobante.CoeficienteValores
         ecc.ImporteCuota = saldo * ecc.TipoComprobante.CoeficienteValores
         Dim tipo As String = Nothing
         Dim tipo2 As String = Nothing
         Dim letra2 As String = Nothing
         Dim cuota2 As Integer = 0
         Dim comprobante2 As Long = 0
         Dim emisor2 As Integer = 0

         Dim sqlccp As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(da)

         tipo = ecc.TipoComprobante.IdTipoComprobante
         cuota = 1
         saldo = ecc.SaldoCuota

         tipo2 = ecc.TipoComprobante.IdTipoComprobante
         letra2 = ecc.CuentaCorrienteProv.Letra
         emisor2 = ecc.CuentaCorrienteProv.CentroEmisor
         comprobante2 = ecc.CuentaCorrienteProv.NumeroComprobante
         cuota2 = 1

         sqlccp.CuentasCorrientesProvPagos_I(ecc.CuentaCorrienteProv.IdSucursal, tipo, ecc.CuentaCorrienteProv.Letra,
                                             ecc.CuentaCorrienteProv.CentroEmisor, ecc.CuentaCorrienteProv.NumeroComprobante,
                                             cuota, ent.Proveedor.IdProveedor, ecc.CuentaCorrienteProv.Fecha,
                                             ent.FechaVencimiento, ecc.ImporteCuota * ajuste, saldo * ajuste,
                                             ecc.CuentaCorrienteProv.FormaPago.IdFormasPago, ecc.CuentaCorrienteProv.Observacion,
                                             tipo2, comprobante2, emisor2, cuota2, letra2, ecc.DescuentoRecargoPorc, ecc.DescuentoRecargo)

      End If

   End Sub

   Friend Sub AnulaCuentaCorrienteProv(ent As Entidades.CuentaCorrienteProv)
      Dim sql = New SqlServer.CuentasCorrientesProv(da)
      sql.CuentasCorrientesProv_UPago(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.IdEstado)

      Dim CCP = New CuentasCorrientesProvPagos(da)
      For Each pag In ent.Pagos
         pag.CuentaCorrienteProv = ent
         CCP.Eliminar(pag)
      Next
   End Sub

   Public Function GetSaldoProveedor(sucursal As Integer,
                                     proveedor As Entidades.Proveedor,
                                     Optional fechaSaldo As Date = Nothing,
                                     Optional contemplaHora As Boolean = False,
                                     Optional grabaLibro As Boolean? = Nothing,
                                     Optional comprobantesAsociados As String = "TODOS") As Decimal
      Return GetSaldoProveedor({New Entidades.Sucursal() With {.Id = sucursal}},
                               proveedor, fechaSaldo, contemplaHora, grabaLibro, comprobantesAsociados)
   End Function
   Public Function GetSaldoProveedor(sucursales As Entidades.Sucursal(), proveedor As Entidades.Proveedor,
                                     fechaSaldo As Date, contemplaHora As Boolean,
                                     grabaLibro As Boolean?, comprobantesAsociados As String) As Decimal
      Using dt = New SqlServer.CuentasCorrientesProv(da).
                   GetSaldoProveedor(sucursales, proveedor, fechaSaldo, contemplaHora, grabaLibro, comprobantesAsociados, Publicos.CtaCteProveedoresSeparar)
         If dt.Rows.Count > 0 Then
            Return dt.AsEnumerable().First().Field(Of Decimal?)("Saldo").IfNull()
         Else
            Return 0
         End If
      End Using
   End Function

   Public Function BuscarPendientes(idSucursal As Integer, proveedor As Entidades.Proveedor, tiposComprobantes As String, numeroComprobante As Long) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).BuscarPendientes(idSucursal, proveedor, tiposComprobantes, numeroComprobante, Publicos.CtaCteProveedoresSeparar)
   End Function

   Public Function GetComprobantesCtaCteFecha(idSucursal As Integer, hasta As Date,
                                              idProveedor As Long, idTipoComprobante As String,
                                              idCategoria As Integer, idRubroCompra As Integer,
                                              grabaLibro As String) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).
               GetComprobantesCtaCteFecha(idSucursal, hasta,
                                          idProveedor, idTipoComprobante,
                                          idCategoria, idRubroCompra,
                                          grabaLibro, actual.NivelAutorizacion)

   End Function

   Public Function GetDetalle(sucursal As Integer,
                              desde As Date, hasta As Date,
                              idProveedor As Long, idTipoComprobante As String,
                              saldo As String,
                              idCategoria As Integer,
                              grabaLibro As String) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).
               GetDetalle(sucursal,
                          desde, hasta,
                          idProveedor, idTipoComprobante,
                          saldo,
                          idCategoria,
                          grabaLibro, actual.NivelAutorizacion)
   End Function

   Public Function GetPagosPorRangoFechas(sucursales As Entidades.Sucursal(),
                                          desde As Date, hasta As Date,
                                          idProveedor As Long, idCategoria As Integer, idUsuario As String, estado As String,
                                          idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                          idCaja As Integer) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).
                  GetPagosPorRangoFechas(sucursales,
                                         desde, hasta,
                                         idProveedor, idCategoria, idUsuario, estado,
                                         idTipoComprobante, letraFiscal, centroEmisor, numeroComprobante,
                                         idCaja,
                                         actual.NivelAutorizacion)
   End Function

   Public Function GetSaldosCtaCte(sucursal As Integer, desde As Date, hasta As Date, idProveedor As Long) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).GetSaldosCtaCte(sucursal, desde, hasta, idProveedor)
   End Function

   Friend Sub ActualizaSaldo(ent As Entidades.CuentaCorrienteProv, importeAplicado As Decimal)
      Dim sql = New SqlServer.CuentasCorrientesProv(da)
      sql.CuentasCorrientesProv_AplicaAlSaldo(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                              ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                              importeAplicado)
   End Sub

   ''' <summary>
   ''' Actualiza el nro. de comprante de la tabla "ComprasNumeros"
   ''' </summary>
   ''' <param name="ent"></param>
   ''' <remarks></remarks>
   Private Sub ActualizaNumeroComprobante(ent As Entidades.CuentaCorrienteProv)
      Dim compraNum As Reglas.ComprasNumeros = New Reglas.ComprasNumeros(da)
      Dim vn As Entidades.CompraNumero = New Entidades.CompraNumero()

      vn.IdSucursal = ent.IdSucursal
      vn.CentroEmisor = ent.CentroEmisor
      vn.IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
      vn.LetraFiscal = ent.Letra
      vn.Numero = ent.NumeroComprobante

      compraNum.ActualizarNumero(vn)
   End Sub

   ''' <summary>
   ''' Actualiza el saldo de cada pago realizado en la cuenta corriente
   ''' </summary>
   ''' <param name="ent"></param>
   ''' <remarks></remarks>
   Private Sub ActualizaSaldoPorCadaPagoRealizado(ent As Entidades.CuentaCorrienteProv)
      Dim ccttPag As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos(da)
      Dim ct As Entidades.CuentaCorrienteProv = New Entidades.CuentaCorrienteProv()

      'actualiza los saldos de los items de pago
      For Each com As Entidades.CuentaCorrienteProvPago In ent.Pagos

         'actualizo el saldo de la tabla CuentasCorrientesProvPagos
         com.CuentaCorrienteProv = ent
         ccttPag.ActualizaSaldo(com, com.Paga * (-1))

         'actualizo el saldo de la tabla CuentasCorrientesProv
         ct = GetUna(com.IdSucursal, com.CuentaCorrienteProv.Proveedor.IdProveedor, com.IdTipoComprobante,
                     com.Letra, com.CentroEmisor, com.NumeroComprobante)
         ct.Saldo = ct.Saldo - com.Paga
         ActualizaSaldo(ct, com.Paga * (-1))
      Next

   End Sub

   ''' <summary>
   ''' Actualiza los cheques de la cuenta corriente de proveedores
   ''' </summary>
   ''' <param name="ent"></param>
   ''' <remarks></remarks>
   Private Sub ActualizaChequesEnLaCuentaCorriente(ent As Entidades.CuentaCorrienteProv)
      Dim ctacteCheque = New CuentasCorrientesProvCheques(da)
      Dim oCheqPropio = New Cheques(da)

      For Each cheq As Entidades.Cheque In ent.ChequesPropios
         'Grabo el cheque primero luego cuando grabe caja, para propios NO se relaciona el cheque con el movimiento.
         cheq.IdSucursal = ent.IdSucursal
         cheq.IdEstadoCheque = Entidades.Cheque.Estados.PROVEEDOR

         oCheqPropio.EjecutaSP(cheq, TipoSP._I)

         'graba la relacion entre el comprobante de cta. cte. y el cheque
         ctacteCheque.GrabaCuentaCorrienteProvCheque(ent, cheq)

         '# Actualizo el numerador de Cheques de la chequera utilizada
         Dim sChequeras As Reglas.Chequeras = New Reglas.Chequeras(da)
         sChequeras.ActualizarNumeroActual(cheq.IdChequera.Value, cheq.NumeroCheque)
      Next

      Dim oCheqTercero = New Cheques(da)

      For Each cheq In ent.ChequesTerceros

         cheq.IdSucursal = ent.IdSucursal
         cheq.IdEstadoCheque = Entidades.Cheque.Estados.PROVEEDOR

         'graba la relacion entre el comprobante de cta. cte. y el cheque
         ctacteCheque.GrabaCuentaCorrienteProvCheque(ent, cheq)

      Next
   End Sub

   Private Sub ActualizaModuloDeCaja(ent As Entidades.CuentaCorrienteProv)
      'si el cliente compro el modulo de caja registro el movimiento de efectivo y/o cheques entregados
      If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOCAJA)) Then

         My.Application.Log.WriteEntry("Actualizo la caja según el efectio egresado en el Pago.", TraceEventType.Verbose)

         Dim deta = New Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
         Dim caj = New Cajas(da)
         Dim cajaDet = New CajaDetalles(da)

         With deta
            .FechaMovimiento = ent.Fecha   'Date.Now
            .IdCaja = ent.CajaDetalle.IdCaja
            .IdSucursal = ent.IdSucursal

            .IdTipoMovimiento = "E"c
            .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
            If .NumeroPlanilla = 0 Then
               .NumeroPlanilla = 1
            End If
            .ImportePesos = ent.ImportePesos
            .ImporteBancos = ent.ImporteTransfBancaria + ent.ImporteChequesPropios
            .ImporteCheques = ent.ImporteChequesTerceros
            .ImporteTickets = ent.ImporteTickets
            .ImporteTarjetas = ent.ImporteTarjetas
            .ImporteRetenciones = ent.ImporteRetenciones
            .ImporteDolares = ent.ImporteDolares
            .CotizacionDolar = ent.CotizacionDolar
            .IdMonedaImporteBancos = If(ent.ImporteTransfBancaria <> 0, ent.CuentaBancariaTransfBanc.Moneda.IdMoneda,                  'Si tiene importe de transferencia, tomo la moneda de transferencia
                                     If(ent.ImporteChequesPropios <> 0, ent.ChequesPropios.First().CuentaBancaria.Moneda.IdMoneda,     'Si tiene importe de cheques propios, tomo la moneda de chk propio
                                     0))                                                                                               'Cualquier otro caso tomo moneda 0 (NULL)
            .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() &
                                        "-" & ent.NumeroComprobante.ToString("00000000") &
                                        IIf(ent.ChequesTerceros.Count > 0, " - Cant.Cheq.Terc.: " + ent.ChequesTerceros.Count.ToString(), "").ToString() &
                                        IIf(ent.ChequesPropios.Count > 0, " - Cant.Cheq.Prop.: " + ent.ChequesPropios.Count.ToString(), "").ToString() &
                                        IIf(ent.ImporteTransfBancaria > 0, " - Transf.Desde: " & ent.CuentaBancariaTransfBanc.NombreCuenta, "").ToString() &
                                        ". " & ent.Proveedor.NombreProveedor, 100)

            .IdCuentaCaja = ent.Proveedor.CuentaDeCaja.IdCuentaCaja
            .EsModificable = False
            .GeneraContabilidad = False
            .Usuario = actual.Nombre
         End With

         'Por ahora marco los cheques con el movimiento, aunque en realidad no lo sume en el movimiento de Caja.
         cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(ent.ChequesTerceros), Publicos.ConvierteChequesPropiosEnArray(ent.ChequesPropios))

         'idPlanilla = deta.IdCaja
         'NroPlanilla = deta.NumeroPlanilla
         'NroMovimiento = deta.NumeroMovimiento

         'If ent.ImporteTransfBancaria > 0 Then

         '   With deta
         '      .FechaMovimiento = ent.Fecha     'Date.Now
         '      .IdSucursal = ent.IdSucursal
         '      .IdTipoMovimiento = "I"c
         '      .IdCaja = ent.CajaDetalle.IdCaja
         '      .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
         '      .ImportePesos = ent.ImporteTransfBancaria
         '      .ImporteCheques = 0
         '      .ImporteTickets = 0
         '      .ImporteTarjetas = 0
         '      .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " - Transf. a cuenta: " & ent.CuentaBancariaTransfBanc.NombreCuenta & ". " & ent.Proveedor.NombreProveedor, 100)
         '      .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJATRANSFBANCARIA))
         '      .EsModificable = False
         '      .Usuario = actual.Nombre
         '   End With

         '   cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

         'End If

         'Retenciones en Caja

         My.Application.Log.WriteEntry("Grabo las retenciones del Recibo.", TraceEventType.Verbose)

         For Each ret As Entidades.RetencionCompra In ent.Retenciones
            With deta
               .FechaMovimiento = ret.FechaEmision     'Date.Now
               .IdSucursal = ent.IdSucursal
               .IdTipoMovimiento = "I"c
               .IdCaja = ent.CajaDetalle.IdCaja
               .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
               .ImportePesos = 0
               .ImporteCheques = 0
               .ImporteTickets = 0
               .ImporteTarjetas = 0
               .ImporteBancos = 0
               .ImporteRetenciones = ret.ImporteTotal
               .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " - " & ent.Proveedor.NombreProveedor & " - Retención: " & ret.NombreTipoImpuesto, 100)
               .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.TiposImpuestos(da)._GetUno(ret.TipoImpuesto.IdTipoImpuesto).IdCuentaCaja.ToString())
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
            End With

            cajaDet.AgregaMovimiento(deta, Nothing, Nothing)
         Next

         'si cargue el movimiento en la caja tengo que actualizar la cta. cte. con los datos de la caja
         Dim sql As SqlServer.CuentasCorrientesProv = New SqlServer.CuentasCorrientesProv(da)
         sql.ActualizoDatosCaja(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                 ent.TipoComprobante.IdTipoComprobante,
                                 ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                 ent.CajaDetalle.IdCaja, deta.NumeroPlanilla, deta.NumeroMovimiento)

         Dim oRetenciones As Reglas.Retenciones = New Reglas.Retenciones(da)
         Dim CtacteRetenc As Reglas.CuentasCorrientesRetenciones = New Reglas.CuentasCorrientesRetenciones(da)

         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)

         My.Application.Log.WriteEntry("Grabo las retenciones del Recibo.", TraceEventType.Verbose)

         'grabo las retenciones
         Dim regRete As Reglas.RetencionesCompras = New Reglas.RetencionesCompras(da)
         Dim sqlReteCom As SqlServer.CuentasCorrientesProvRetenciones = New SqlServer.CuentasCorrientesProvRetenciones(da)

         'relaciono las retenciones con los comprobantes
         If deta IsNot Nothing Then
            For Each rete As Entidades.RetencionCompra In ent.Retenciones
               ''rete.Regimen = ent.Proveedor.Regimen
               If rete.Regimen Is Nothing Then Throw New Exception("ERROR - No se asignó regimen a la retención.")
               rete.Caja.IdCaja = deta.IdCaja
               rete.NroPlanillaEgreso = deta.NumeroPlanilla
               rete.NroMovimientoEgreso = deta.NumeroMovimiento
               regRete.EjecutaSP(rete, TipoSP._I)
               sqlReteCom.CuentasCorrientesProvRetenciones_I(rete.IdSucursal,
                                                               ent.Proveedor.IdProveedor,
                                                               ent.TipoComprobante.IdTipoComprobante,
                                                               ent.Letra,
                                                               ent.CentroEmisor,
                                                               ent.NumeroComprobante,
                                                               rete.TipoImpuesto.IdTipoImpuesto,
                                                               rete.EmisorRetencion,
                                                               rete.NumeroRetencion, rete.SecuenciaRetencion)
            Next
         End If

      End If
   End Sub

   Private Sub ActualizaModuloBancos(ent As Entidades.CuentaCorrienteProv)
      If Publicos.TieneModuloBanco Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

         My.Application.Log.WriteEntry("Actualizo los o el Banco con los datos de la Transferencia.", TraceEventType.Verbose)
         Dim rLibroBancos = New LibroBancos(da)
         Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         Dim rLibBanco = New LibroBancos(da)

         For Each cheq As Entidades.Cheque In ent.ChequesPropios

            With entLibroBanco
               .IdSucursal = cheq.IdSucursal
               .IdCuentaBancaria = cheq.CuentaBancaria.IdCuentaBancaria
               .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
               .IdCuentaBanco = Publicos.CtaBancoPago  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOPAGO))
               .IdTipoMovimiento = "E"
               .Importe = cheq.Importe
               .FechaMovimiento = ent.Fecha
               .IdCheque = cheq.IdCheque
               .FechaAplicado = cheq.FechaCobro
               '.Observacion = ent.Observacion
               .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & ". " & ent.Proveedor.NombreProveedor, 100)
               .Conciliado = ent.Conciliado
            End With

            rLibroBancos.AgregaMovimiento(entLibroBanco)

         Next

         If ent.ImporteTransfBancaria > 0 Then

            For Each transfer In ent.CCTransferencias
               entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               With entLibroBanco

                  .IdSucursal = ent.IdSucursal
                  .IdCuentaBancaria = transfer.IdCuentaBancaria
                  .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                  .IdCuentaBanco = Publicos.CtaBancoTransfBancaria

                  '# Se evalúa el importe TOTAL de la transferencia
                  If ent.ImporteTransfBancaria > 0 Then
                     .IdTipoMovimiento = "E"
                  Else
                     .IdTipoMovimiento = "I"
                  End If

                  '# Se graban los importes de cada transferencia por separado
                  .Importe = transfer.Importe

                  .FechaMovimiento = ent.Fecha
                  .IdCheque = Nothing
                  If ent.FechaTransferencia.HasValue Then
                     .FechaAplicado = ent.FechaTransferencia.Value.Date
                  Else
                     .FechaAplicado = ent.Fecha
                  End If
                  '.Observacion = ent.Observacion
                  '-- REQ-34389.- -----------------------------------------------------------------------------------------
                  .Observacion = String.Format("{0} {1} {2}-{3:00000000} - Transf. a Cuenta. {4}", ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.NombreProveedor).Truncar(100)
                  '--------------------------------------------------------------------------------------------------------
                  .Conciliado = ent.Conciliado

                  '# Por cada transferencia realizada, grabo un movimiento de LibroBanco
                  rLibBanco.AgregaMovimiento(entLibroBanco)

                  '# Completo la información de Libros Bancos en mis Transferencias realizadas para grabarlas más abajo.
                  With transfer
                     '' 'Se subió más arriba por si no tiene habilitado el módulo de bancos
                     ''.IdSucursal = ent.IdSucursal
                     ''.IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
                     ''.Letra = ent.Letra
                     ''.CentroEmisor = ent.CentroEmisor
                     ''.NumeroComprobante = ent.NumeroComprobante
                     '' '--------------------------------------------
                     ''.IdCuentaBancaria = ent.CuentaBancariaTransfBanc.IdCuentaBancaria '# Se utiliza una única Cuenta Bancaria por el momento
                     '' '--------------------------------------------

                     '# PK de LibrosBancos
                     .IdSucursalLibroBanco = entLibroBanco.IdSucursal
                     .IdCuentaBancariaLibroBanco = entLibroBanco.IdCuentaBancaria
                     .NumeroMovimientoLibroBanco = entLibroBanco.NumeroMovimiento
                  End With
               End With
            Next


         End If

         '   With entLibroBanco
         '      .IdSucursal = ent.IdSucursal
         '      .IdCuentaBancaria = ent.CuentaBancariaTransfBanc.IdCuentaBancaria
         '      .NumeroMovimiento = rLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

         '      If ent.Proveedor.CuentaBanco.IdCuentaBanco > 0 Then
         '         .IdCuentaBanco = ent.Proveedor.CuentaBanco.IdCuentaBanco
         '      Else
         '         .IdCuentaBanco = Publicos.CtaBancoTransfBancaria  ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOTRANSFBANCARIA))
         '      End If

         '      .IdTipoMovimiento = "E"
         '      .Importe = ent.ImporteTransfBancaria
         '      .FechaMovimiento = ent.Fecha
         '      .IdCheque = Nothing
         '      '-- REQ-38220.- -------------------------------------
         '      If ent.FechaTransferencia.HasValue Then
         '         .FechaAplicado = ent.FechaTransferencia.Value.Date
         '      Else
         '         .FechaAplicado = ent.Fecha
         '      End If
         '      '----------------------------------------------------
         '      '.Observacion = ent.Observacion
         '      .Observacion = Strings.Left(ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " - Transf. a Cuenta" & ". " & ent.Proveedor.NombreProveedor, 100)
         '      .Conciliado = ent.Conciliado
         '   End With

         '   rLibroBancos.AgregaMovimiento(entLibroBanco)

         'End If

      End If

      ent.CCTransferencias.ForEach(
         Sub(transfer)
            With transfer
               .IdSucursal = ent.IdSucursal
               .IdProveedor = ent.Proveedor.IdProveedor
               .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
               .Letra = ent.Letra
               .CentroEmisor = ent.CentroEmisor
               .NumeroComprobante = ent.NumeroComprobante
               '--------------------------------------------
               '.IdCuentaBancaria = ent.CuentaBancariaTransfBanc.IdCuentaBancaria '# Se utiliza una única Cuenta Bancaria por el momento
               '--------------------------------------------
            End With
         End Sub)

      '# Grabo las CCTransferencia
      Dim rCCTransferencias As New Reglas.CuentasCorrientesProvTransferencias(da)
      If ent.CCTransferencias IsNot Nothing Then
         For Each transfer In ent.CCTransferencias
            rCCTransferencias._Inserta(transfer)
         Next
      End If
      '--------------------------------------------------------------------------


   End Sub

   Public Function GetTodos() As List(Of Entidades.CuentaCorrienteProv)
      Return CargaLista(New SqlServer.CuentasCorrientesProv(da).CuentasCorrientesProv_GA(),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaCorrienteProv())
   End Function

   Public Function Get1(idSucursal As Integer, idProveedor As Long,
                        idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).CuentasCorrientesProv_G1(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
   Public Function GetUna(idSucursal As Integer, idProveedor As Long,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Entidades.CuentaCorrienteProv
      Return GetUna(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idSucursal As Integer, idProveedor As Long,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CuentaCorrienteProv
      Return CargaEntidad(Get1(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaCorrienteProv(),
                          accion, String.Format("No existe el Comprobante {0}/{1}/{2} {3} {4:0000}-{5:00000000} en la Cuenta Corriente",
                                                idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante))
   End Function

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Entidades.CuentaCorrienteProv
      Return GetUna(idSucursal, idProveedor:=0, idTipoComprobante, letra, centroEmisor, numeroComprobante, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetComprobantesCtaCte() As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).GetComprobantesCtaCte()
   End Function

   Public Sub AnularPago(ent As Entidades.CuentaCorrienteProv)
      EjecutaConTransaccion(Sub() _AnularPago(ent))
   End Sub

   Public Sub _AnularPago(ent As Entidades.CuentaCorrienteProv)
      If Publicos.TieneModuloContabilidad Then
         Dim ctblEjercicio = New ContabilidadEjercicios(da)
         ctblEjercicio.EstaPeriodoCerrado(ent.Fecha)
      End If

      Dim ccttPag = New CuentasCorrientesProvPagos(da)

      Dim ct = New Entidades.CuentaCorrienteProv()
      Dim sql = New SqlServer.CuentasCorrientesProv(da)
      Dim tipoComprobanteRecibo As String = String.Empty
      'actualiza los saldos de los items de pago
      For Each com In ent.Pagos
         com.CuentaCorrienteProv = ent

         ccttPag.ActualizaSaldo(com, com.Paga)

         ct = GetUna(com.IdSucursal, ent.Proveedor.IdProveedor, com.IdTipoComprobante, com.Letra, com.CentroEmisor, com.NumeroComprobante)
         ActualizaSaldo(ct, com.Paga)

         'Si aplico un ANTICIPO, le devuelvo ese pago al recibo (para nivelar la cuenta) que lleva el monto en el saldo. En la tabla detalle tiene otra logica.
         If com.TipoComprobante.EsAnticipo = True Then
            tipoComprobanteRecibo = com.TipoComprobante.IdTipoComprobanteSecundario

            'El Anticipo tiene el Numero del recibo que lo emitio, por eso uso sus datos.
            sql.CuentasCorrientesProv_AplicaAlSaldo(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                                    tipoComprobanteRecibo, com.Letra, com.CentroEmisor, com.NumeroComprobante,
                                                    com.Paga) '' * (-1))
         End If
      Next

      Dim oCheques = New Cheques(da).GetPorCuentaCorrienteProv(ent.IdSucursal, ent.Proveedor.IdProveedor,
                           ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, False)

      For cont = 1 To oCheques.Count
         If oCheques.Item(cont - 1).NroMovimientoEgreso = 0 Then
            Dim primerCheque = oCheques.Item(cont - 1)
            Dim stbMensaje = New StringBuilder("ATENCION: el Pago tiene al menos este cheque re-ingresado, NO puede ANULARLO...").AppendLine().AppendLine()
            stbMensaje.AppendFormat("Banco: {0} / Suc. Bco: {1} / Loc. Bco: {2} / Numero Cheq.: {3}",
                                    primerCheque.Banco.NombreBanco, primerCheque.IdBancoSucursal, primerCheque.Localidad.NombreLocalidad, primerCheque.NumeroCheque)
            Throw New Exception(stbMensaje.ToString())
         End If
      Next

      Dim grabaLibro As Boolean? = Nothing
      If Publicos.CtaCte.CtaCteClientesSeparar Then grabaLibro = ent.TipoComprobante.GrabaLibro
      sql.CuentasCorrientesProv_UImprimeSaldos(ent.Proveedor.IdProveedor, ent.TipoComprobante.Grupo, grabaLibro, ent.Fecha, imprimeSaldos:=False)

      Dim oCtaCte = New Cheques(da)
      Dim sqlCheq = New SqlServer.Cheques(da)
      Dim ctacteCheque = New CuentasCorrientesProvCheques(da)

      ctacteCheque.Eliminar(ent)

      Dim sqlLibroBancos = New SqlServer.LibroBancos(da)

      For Each cheq In ent.ChequesPropios
         cheq.IdSucursal = ent.IdSucursal

         sqlLibroBancos.LibroBancos_DPorCheque(cheq.IdCheque)

         oCtaCte.EjecutaSP(cheq, TipoSP._D)
      Next

      Dim decTotalCheqTerc = 0D
      For Each cheq In ent.ChequesTerceros.Where(Function(ch) ch.IdEstadoCheque < Entidades.Cheque.Estados.RECHAZADO)
         cheq.IdSucursal = ent.IdSucursal

         'Lo vuelvo a dejar en Cartera
         cheq.NroPlanillaEgreso = 0
         cheq.NroMovimientoEgreso = 0

         oCtaCte.EjecutaSP(cheq, TipoSP._U)

         'Para que lo tome el asiento de Caja que se hace posteriormente.
         cheq.IdEstadoCheque = cheq.IdEstadoChequeAnt

         sqlCheq.Cheques_VuelveEstadoAnt(cheq.IdSucursal,
                                         cheq.Banco.IdBanco,
                                         cheq.IdBancoSucursal,
                                         cheq.Localidad.IdLocalidad,
                                         cheq.NumeroCheque,
                                         actual.Nombre,
                                         idEstadoCheque:=Nothing,
                                         idEstadoChequeAnt:=Nothing,
                                         cheq.IdCheque,
                                         limpiaPlanillaCaja:=False)

         decTotalCheqTerc = decTotalCheqTerc + cheq.Importe
      Next

      'si el cliente compro el modulo de caja registro el movimiento de efectivo y/o cheques entregados
      If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOCAJA)) Then
         Dim deta = New Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
         Dim caj = New Cajas(da)
         Dim cajaDet = New CajaDetalles(da)

         With deta
            .FechaMovimiento = ent.Fecha  'DateTime.Now
            .IdSucursal = ent.IdSucursal
            .IdCaja = ent.CajaDetalle.IdCaja
            .IdTipoMovimiento = "I"c
            .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
            .ImportePesos = ent.ImportePesos
            .ImporteBancos = ent.ImporteTransfBancaria + ent.ImporteChequesPropios
            .ImporteCheques = decTotalCheqTerc
            .ImporteTickets = ent.ImporteTickets
            .ImporteTarjetas = ent.ImporteTarjetas
            .ImporteRetenciones = ent.ImporteRetenciones
            .ImporteDolares = ent.ImporteDolares
            .CotizacionDolar = ent.CotizacionDolar
            .IdMonedaImporteBancos = If(ent.ImporteTransfBancaria <> 0, ent.CuentaBancariaTransfBanc.Moneda.IdMoneda,                  'Si tiene importe de transferencia, tomo la moneda de transferencia
                                     If(ent.ImporteChequesPropios <> 0, ent.ChequesPropios.First().CuentaBancaria.Moneda.IdMoneda,     'Si tiene importe de cheques propios, tomo la moneda de chk propio
                                     0))                                                                                               'Cualquier otro caso tomo moneda 0 (NULL)

            Dim stbObs = New StringBuilder()
            stbObs.AppendFormat("ANULA {0} {1} {2}-{3:00000000}", ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

            Dim cntChequesTerceros = ent.ChequesTerceros.Where(Function(ch) ch.IdEstadoCheque < Entidades.Cheque.Estados.RECHAZADO).Count
            If cntChequesTerceros > 0 Then
               stbObs.AppendFormat(" - Cant.Cheq.Terc.: {0}", cntChequesTerceros)
            End If
            Dim cntChequesRech = ent.ChequesTerceros.Where(Function(ch) ch.IdEstadoCheque = Entidades.Cheque.Estados.RECHAZADO).Count
            If cntChequesRech > 0 Then
               stbObs.AppendFormat(" - Cant.Cheq.Rech.: {0}", cntChequesRech)
            End If
            Dim cntChequesPropios = ent.ChequesPropios.Count
            If cntChequesPropios > 0 Then
               stbObs.AppendFormat(" - Cant.Cheq.Prop.: {0}", cntChequesPropios)
            End If
            If ent.ImporteTransfBancaria > 0 Then
               stbObs.AppendFormat(" - Transf.Desde: {0}", ent.CuentaBancariaTransfBanc.NombreCuenta)
            End If

            stbObs.AppendFormat(". ", ent.Proveedor.NombreProveedor)

            .Observacion = stbObs.ToString().Truncar(100)

            '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAPAGO"))
            .IdCuentaCaja = ent.Proveedor.CuentaDeCaja.IdCuentaCaja
            .EsModificable = False
            .GeneraContabilidad = False
            .Usuario = actual.Nombre
         End With

         'Por ahora marco los cheques con el movimiento, aunque en realidad no lo sume en el movimiento de Caja.
         cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(ent.ChequesTerceros), Publicos.ConvierteChequesPropiosEnArray(ent.ChequesPropios))

         'Si Pagó parte con Transfencia Bancaria
         'If ent.ImporteTransfBancaria > 0 Then

         '   With deta
         '      .FechaMovimiento = ent.Fecha     'DateTime.Now
         '      .IdSucursal = ent.IdSucursal
         '      .IdTipoMovimiento = "E"c
         '      .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
         '      .ImportePesos = ent.ImporteTransfBancaria
         '      .ImporteCheques = 0
         '      .ImporteTickets = 0
         '      .ImporteTarjetas = 0
         '      .Observacion = Strings.Left("ANULA " & ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " - Transf. desde: " & ent.CuentaBancariaTransfBanc.NombreCuenta & ". " & ent.Proveedor.NombreProveedor, 100)
         '      .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJATRANSFBANCARIA))
         '      .EsModificable = False
         '      .Usuario = actual.Nombre
         '   End With

         '   cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

         'End If

         'Retenciones en Caja

         My.Application.Log.WriteEntry("Grabo las retenciones del Recibo.", TraceEventType.Verbose)
         For Each ret As Entidades.RetencionCompra In ent.Retenciones
            With deta
               .FechaMovimiento = ret.FechaEmision     'Date.Now
               .IdSucursal = ent.IdSucursal
               .IdTipoMovimiento = "E"c
               .IdCaja = ent.CajaDetalle.IdCaja
               .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
               .ImportePesos = 0
               .ImporteCheques = 0
               .ImporteTickets = 0
               .ImporteTarjetas = 0
               .ImporteBancos = 0
               .ImporteRetenciones = ret.ImporteTotal
               .Observacion = Strings.Left("ANULA " & ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " - " & ent.Proveedor.NombreProveedor & " - Retención: " & ret.NombreTipoImpuesto, 100)
               .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.TiposImpuestos(da)._GetUno(ret.TipoImpuesto.IdTipoImpuesto).IdCuentaCaja.ToString())
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
            End With

            cajaDet.AgregaMovimiento(deta, Nothing, Nothing)
         Next

      End If


      'si el Cliente compro el modulo de Banco registro el movimiento de Cheques Propios entregados

      If Publicos.TieneModuloBanco Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

         Dim rLibroBancos = New LibroBancos(da)

         For Each cheq In ent.ChequesPropios
            rLibroBancos.EliminarMovimientoPorCheque(cheq.IdCheque)
         Next

         'Si Pagó parte con Transfencia Bancaria
         If ent.ImporteTransfBancaria > 0 Then
            For Each transfer In ent.CCTransferencias
               Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

               With entLibroBanco
                  .IdSucursal = ent.IdSucursal
                  .IdCuentaBancaria = transfer.IdCuentaBancaria
                  .NumeroMovimiento = rLibroBancos.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

                  If ent.Proveedor.CuentaBanco.IdCuentaBanco > 0 Then
                     .IdCuentaBanco = ent.Proveedor.CuentaBanco.IdCuentaBanco
                  Else
                     .IdCuentaBanco = Publicos.CtaBancoTransfBancaria
                  End If

                  .IdTipoMovimiento = "I"
                  .Importe = transfer.Importe
                  .FechaMovimiento = ent.Fecha
                  .IdCheque = Nothing
                  .FechaAplicado = ent.Fecha
                  '.Observacion = ent.Observacion
                  .Observacion = String.Format("ANULA {0} {1} {2}-{3:00000000} - Transf. a Caja. {4}",
                                               ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.NombreProveedor).Truncar(100)
                  .Conciliado = False
               End With

               rLibroBancos.AgregaMovimiento(entLibroBanco)
            Next

         End If

      End If

      'Si genero un Anticipo, sera borrado.
      Dim sql2 = New SqlServer.CuentasCorrientesProvPagos(da)

      tipoComprobanteRecibo = ent.TipoComprobante.IdTipoComprobanteSecundario
      '  If ent.TipoComprobante.GrabaLibro Then

      sql2.CuentasCorrientesProvPagos_D(ent.IdSucursal, ent.Proveedor.IdProveedor, tipoComprobanteRecibo, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

      sql.CuentasCorrientesProv_D(ent.IdSucursal, ent.Proveedor.IdProveedor, tipoComprobanteRecibo, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

      'Else
      'sql2.CuentasCorrientesProvPagos_D(ent.IdSucursal, ent.Proveedor.IdProveedor, "ANTICIPOPROV", ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

      'sql.CuentasCorrientesProv_D(ent.IdSucursal, ent.Proveedor.IdProveedor, "ANTICIPOPROV", ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

      'End If

      Dim ctaCteTarjeta = New CuentasCorrientesProvTransferencias(da)
      ctaCteTarjeta._Borrar(ent)

      ent.IdEstado = "ANULADO"
      AnulaCuentaCorrienteProv(ent)

      Dim regRete = New RetencionesCompras(da)
      Dim sqlCtCtRet = New SqlServer.CuentasCorrientesProvRetenciones(da)

      sqlCtCtRet.CuentasCorrientesProvRetenciones_D(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                                    ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

      For Each ret In ent.Retenciones
         regRete.EjecutaSP(ret, TipoSP._D)
      Next

      'If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea AndAlso
      If Publicos.TieneModuloContabilidad AndAlso
         ent.IdEjercicio.HasValue AndAlso ent.IdPlanCuenta.HasValue AndAlso ent.IdAsiento.HasValue Then
         Dim rCtbl = New Contabilidad(da)
         rCtbl.AnularAsiento(ent.IdEjercicio.Value, ent.IdPlanCuenta.Value, ent.IdAsiento.Value, Today)
      End If

   End Sub

   Public Function GetSaldoProveedores(suc As List(Of Integer)) As DataTable
      Dim sql = New SqlServer.CuentasCorrientesProv(da)
      Return sql.GetSaldoProveedores(suc)
   End Function

   Public Function GetPorProveedor(sucursales As Entidades.Sucursal(),
                                   proveedor As Eniac.Entidades.Proveedor,
                                   desde As Date, hasta As Date, grabaLibro As String) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).
               GetPorProveedor(sucursales, proveedor, desde, hasta, grabaLibro, actual.NivelAutorizacion)
   End Function

   Public Sub EliminarCuentaCorriente(ent As Entidades.CuentaCorrienteProv)

      If Publicos.TieneModuloContabilidad Then
         Dim ctblEjercicio = New ContabilidadEjercicios(da)
         ctblEjercicio.EstaPeriodoCerrado(ent.Fecha)
      End If

      'Borro las Retenciones
      Dim CCR = New CuentasCorrientesProvRetenciones(da)
      CCR.Eliminar(ent)

      'Borro los Cheques
      Dim CCC = New CuentasCorrientesProvCheques(da)
      CCC.Eliminar(ent)

      'Borro las Cuotas
      Dim CCP = New CuentasCorrientesProvPagos(da)
      For Each pag As Entidades.CuentaCorrienteProvPago In ent.Pagos
         pag.CuentaCorrienteProv = ent
         CCP.Eliminar(pag)
      Next

      'Borro la Cabecera

      Dim sql = New SqlServer.CuentasCorrientesProv(da)
      sql.CuentasCorrientesProv_D(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                  ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

   End Sub

   Public Function GetPorRetencion(idSucursal As Integer, idProveedor As Long,
                                   idTipoImpuesto As String, emisorRetencion As Integer, numeroRetencion As Long) As Entidades.CuentaCorrienteProv
      Try
         Me.da.OpenConection()

         Dim sql = New SqlServer.CuentasCorrientesProv(da)

         Dim dt As DataTable = sql.GetPorRetencion(idSucursal, idProveedor, idTipoImpuesto, emisorRetencion, numeroRetencion)

         Dim o As Entidades.CuentaCorrienteProv = New Entidades.CuentaCorrienteProv()
         If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Me.CargarUna(o, dr)
         Else
            Throw New Exception("No existe el Comprobante en la Cuenta Corriente")
         End If
         Return o

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetMovEliminarProv(idSucursal As Integer,
                                      desde As Date, hasta As Date,
                                      idProveedor As Long, idTipoComprobante As String,
                                      idCategoria As Integer,
                                      grabaLibro As String) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).
               GetMovEliminarProv(idSucursal,
                                  desde, hasta,
                                  idProveedor, idTipoComprobante,
                                  idCategoria,
                                  grabaLibro, actual.NivelAutorizacion)

   End Function

   Public Sub EliminarCtaCteDirecta(ctactes As List(Of Entidades.CuentaCorrienteProv))
      'Borro las Cuotas
      EjecutaConTransaccion(Sub() _EliminarCtaCteDirecta(ctactes))
   End Sub

   Private Sub _EliminarCtaCteDirecta(ctactes As List(Of Entidades.CuentaCorrienteProv))
      For Each ent In ctactes
         If Publicos.TieneModuloContabilidad Then
            Dim ctblEjercicio As ContabilidadEjercicios = New ContabilidadEjercicios(da)
            ctblEjercicio.EstaPeriodoCerrado(ent.Fecha)
         End If

         Dim CCP = New Reglas.CuentasCorrientesProvPagos(da)
         For Each pag As Entidades.CuentaCorrienteProvPago In ent.Pagos
            pag.CuentaCorrienteProv = ent
            CCP.Eliminar(pag)
         Next

         'Borro la Cabecera
         Dim sql = New SqlServer.CuentasCorrientesProv(da)
         sql.CuentasCorrientesProv_D(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                     ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)
      Next
   End Sub

   Public Sub Importar(dt As DataTable, tspImportando As System.Windows.Forms.ToolStripProgressBar, IdFuncion As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim drCol As DataRow() = dt.Select(String.Format("{0} = True", Entidades.Importadores.Columnas.Importa.ToString()))
         tspImportando.Maximum = drCol.Length

         For Each dr As DataRow In drCol
            Try

               If blnAbreConexion Then da.BeginTransaction()
               Dim TipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())
               Dim coe As Integer = TipoComprobante.CoeficienteValores

               'cargo el comprobante en el objeto CuentasCorrientes
               Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
               Dim CC As Entidades.CuentaCorrienteProv = New Entidades.CuentaCorrienteProv()

               With CC
                  .IdSucursal = actual.Sucursal.Id
                  .TipoComprobante.IdTipoComprobante = dr("IdTipoComprobante").ToString()
                  .Letra = dr("Letra").ToString()
                  .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
                  .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
                  .Fecha = Date.Parse(dr("Fecha").ToString())
                  .FechaVencimiento = Date.Parse(dr("FechaVencimiento").ToString())
                  .Proveedor = New Reglas.Proveedores().GetUno(Long.Parse(dr("IdProveedor").ToString()))
                  '  .Vendedor = New Reglas.Empleados().GetUno(.Cliente.Vendedor.TipoDocEmpleado, .Cliente.Vendedor.NroDocEmpleado)
                  .FormaPago.IdFormasPago = 3
                  .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString()) '* coe
                  .Saldo = .ImporteTotal
                  .Cuotas = 1
                  .Observacion = dr("Observacion").ToString()
                  .Usuario = actual.Nombre
                  .IdEstado = "NORMAL"

                  'If .Proveedor.IdlienteCtaCte <> 0 Then
                  '   .IdClienteCtaCte = .Cliente.IdClienteCtaCte
                  'Else
                  '   .IdClienteCtaCte = .Cliente.IdCliente
                  'End If

                  ' .IdCategoria = .Proveedor.IdCategoria

               End With

               Dim CCP As Entidades.CuentaCorrienteProvPago = New Entidades.CuentaCorrienteProvPago()

               With CCP
                  .IdSucursal = CC.IdSucursal
                  .TipoComprobante.IdTipoComprobante = CC.TipoComprobante.IdTipoComprobante
                  .Letra = CC.Letra
                  .CentroEmisor = CC.CentroEmisor
                  .NumeroComprobante = CC.NumeroComprobante
                  .Cuota = 1
                  '.Fecha = Me.dtpFechaEmision.Value
                  .FechaVencimiento = CC.FechaVencimiento
                  .ImporteCuota = CC.ImporteTotal
                  .SaldoCuota = CC.ImporteTotal
                  .CuentaCorrienteProv = CC
               End With

               'CargarUna(dr, o)

               ' o.NuevoComentario = dr(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString()).ToString()

               If dr(Entidades.Importadores.Columnas.Accion.ToString()).Equals("A") Then
                  oCtaCte.GrabaCtaCte(CC, CCP, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
                  '  Inserta(o)
               ElseIf dr(Entidades.Importadores.Columnas.Accion.ToString()).Equals("M") Then
                  '  Actualiza(o)
               End If

               If blnAbreConexion Then da.CommitTransaction()
               dr(Entidades.Importadores.Columnas.EstadoImporta.ToString()) = "OK"
               tspImportando.PerformStep()
            Catch ex As Exception
               If blnAbreConexion Then da.RollbakTransaction()
               dr(Entidades.Importadores.Columnas.EstadoImporta.ToString()) = "ERROR"
               dr(Entidades.Importadores.Columnas.Mensaje.ToString()) = ex.Message
            End Try
            System.Windows.Forms.Application.DoEvents()
         Next
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Function GetPagosAnulados(sucursal As Integer, desde As Date, hasta As Date, idProveedor As Long) As DataTable
      Return New SqlServer.CuentasCorrientesProv(da).GetPagosAnulados(sucursal, desde, hasta, idProveedor)
   End Function
   Public Sub EliminarComprobante(ent As Entidades.CuentaCorrienteProv)
      EjecutaConTransaccion(Sub() EliminarCuentaCorrienteProv(ent))
   End Sub

   Public Sub EliminarCuentaCorrienteProv(ent As Entidades.CuentaCorrienteProv)

      If Publicos.TieneModuloContabilidad And ent.TipoComprobante.GeneraContabilidad Then
         Dim ctblEjercicio = New ContabilidadEjercicios(da)
         ctblEjercicio.EstaPeriodoCerrado(ent.Fecha)
      End If

      'Actualiza la numeración si es el ultimo numero
      If ent.TipoComprobante.EsRecibo Then
         Dim oComprasNumeros As Reglas.ComprasNumeros = New Reglas.ComprasNumeros(da)
         Dim CompraNumero As Entidades.CompraNumero = New Entidades.CompraNumero()

         Dim idSucursal As Integer = ent.IdSucursal
         'If Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales Then
         '   idSucursal = 0
         'End If

         Dim ultimoNumero As Long = oComprasNumeros.GetUltimoNumero(idSucursal, ent.TipoComprobante.IdTipoComprobante,
                                        ent.Letra, ent.CentroEmisor)

         If ultimoNumero = ent.NumeroComprobante Then
            Dim compAnterior As DataTable
            compAnterior = oComprasNumeros.GetPagoAnterior(idSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra,
                                           ent.CentroEmisor, ent.NumeroComprobante)

            For Each dr As DataRow In compAnterior.Rows
               With CompraNumero
                  'If Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales Then
                  '   .IdSucursal = -1
                  'Else
                  .IdSucursal = ent.IdSucursal
                  ' End If
                  .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
                  .LetraFiscal = ent.Letra
                  .CentroEmisor = ent.CentroEmisor
                  .Numero = Long.Parse(dr("NumeroComprobante").ToString())
                  '.Fecha = Date.Parse(dr("Fecha").ToString())
               End With
               oComprasNumeros.ActualizarNumero(CompraNumero)
            Next

         End If
      End If



      '*** Las validaciones si es correcto elminar o no, debieron hacerse antes de llamar a esta funcion ***

      'Borro los Cheques (pueden existir o no)

      Dim CCC As Reglas.CuentasCorrientesProvCheques = New Reglas.CuentasCorrientesProvCheques(da)

      CCC.Eliminar(ent)

      'Borro las Cuotas

      Dim CCP As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos(da)

      For Each pag As Entidades.CuentaCorrienteProvPago In ent.Pagos
         pag.CuentaCorrienteProv = ent
         CCP.Eliminar(pag)
      Next

      'Borro la Cabecera

      Dim sql As SqlServer.CuentasCorrientesProv = New SqlServer.CuentasCorrientesProv(da)

      sql.CuentasCorrientesProv_D(ent.IdSucursal,
                                  ent.Proveedor.IdProveedor,
                              ent.TipoComprobante.IdTipoComprobante,
                              ent.Letra,
                              ent.CentroEmisor,
                              ent.NumeroComprobante)

   End Sub

#End Region

#Region "Metodos Privados"

   ''' <summary>
   ''' Inserto un Pago a la Cta. Cte.
   ''' </summary>
   ''' <param name="ent"></param>
   ''' <remarks></remarks>

   Friend Sub Inserta(ent As Entidades.CuentaCorrienteProv, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      Dim NumeroComprob As Long = 0

      My.Application.Log.WriteEntry("Inserto un Pago a la Cta. Cte.", TraceEventType.Verbose)


      'GAR: 16/02/2016
      'Debe respetar lo que viene.
      'If ent.TipoComprobante.GrabaLibro Then
      '   ent.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(Entidades.TipoComprobante.Tipos.PAGO.ToString())
      'Else
      '   ent.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(Entidades.TipoComprobante.Tipos.PAGOPROV.ToString())
      'End If
      '-------------------------------

      My.Application.Log.WriteEntry("Obtengo el Tipo de Comprobante del Pago.", TraceEventType.Verbose)

      'Si no lo asigno previamente debo buscar el ultimo
      If ent.NumeroComprobante = 0 Then
         ent.NumeroComprobante = Me.GetProximoNumero(ent.IdSucursal,
                                                     ent.TipoComprobante.IdTipoComprobante,
                                                     ent.Letra,
                                                     ent.CentroEmisor)

         If Me.Existe(ent.IdSucursal, ent.Proveedor.IdProveedor, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, NumeroComprob) Then
            Throw New Exception("El número de Pago " & NumeroComprob.ToString() & " ya existe, debe digitar uno mayor y retomara la numeración.")
         End If
      End If

      'Si el numero es automatico o es manual pero coincide con el ultimo, debo actualizar el numerador
      If ent.NumeroComprobante >= NumeroComprob Then
         'actualizo el nro. de comprobante --------------------------
         Me.ActualizaNumeroComprobante(ent)
      End If

      'actualiza los saldos de los items de pago --------------------------
      My.Application.Log.WriteEntry("Actualizo los saldos de los items del Pago.", TraceEventType.Verbose)
      Me.ActualizaSaldoPorCadaPagoRealizado(ent)
      My.Application.Log.WriteEntry("Recorro los cheques que se insertaron en los Pagos.", TraceEventType.Verbose)

      If ent.CCTransferencias Is Nothing Then ent.CCTransferencias = New List(Of Entidades.CuentaCorrienteProvTransferencia)()
      If ent.CCTransferencias.Count > 0 Then
         ent.ImporteTransfBancaria = ent.CCTransferencias.Sum(Function(vt) vt.Importe) '* coe
         If ent.CCTransferencias.Select(Function(vt) vt.IdCuentaBancaria).Distinct().Count > 1 Then
            ent.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(999)
         Else
            ent.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(ent.CCTransferencias.First().IdCuentaBancaria)
         End If
      Else
         If ent.CCTransferencias.Count = 0 AndAlso ent.ImporteTransfBancaria <> 0 Then
            ent.CCTransferencias.Add(New Entidades.CuentaCorrienteProvTransferencia() With
                                       {
                                          .Importe = ent.ImporteTransfBancaria,
                                          .Orden = 1,
                                          .IdCuentaBancaria = ent.CuentaBancariaTransfBanc.IdCuentaBancaria
                                       })
         End If
      End If
      ent.CCTransferencias.ForEach(Sub(trx)
                                      trx.IdSucursalLibroBanco = Nothing
                                      trx.IdCuentaBancariaLibroBanco = Nothing
                                      trx.NumeroMovimientoLibroBanco = Nothing
                                   End Sub)

      My.Application.Log.WriteEntry("Grabo la Cta. Cte. del Proveedor.", TraceEventType.Verbose)
      Me.GrabaCuentaCorrienteProv(ent, MetodoGrabacion, IdFuncion)
      My.Application.Log.WriteEntry("Finaliza la grabación de la Cta. Cte. del Proveedor.", TraceEventType.Verbose)

      If ent.TipoComprobante.GeneraContabilidad AndAlso Publicos.TieneModuloContabilidad AndAlso Publicos.ContabilidadEjecutarEnLinea Then
         Dim ctbl As Contabilidad = New Contabilidad(da)
         ctbl.RegistraContabilidad(ent)
      End If

      'actualiza los cheques de la cuenta corriente de proveedores
      My.Application.Log.WriteEntry("Comienza a actualizar los cheques en la Cta. Cte. del Proveedor.", TraceEventType.Verbose)
      Me.ActualizaChequesEnLaCuentaCorriente(ent)
      My.Application.Log.WriteEntry("Finaliza actualización de cheques en la Cta. Cte. del Proveedor.", TraceEventType.Verbose)

      'si el cliente compro el modulo de caja ingreso el efectivo recibido a la caja
      Me.ActualizaModuloDeCaja(ent)

      'si tiene modulo Bancos
      Me.ActualizaModuloBancos(ent)

      My.Application.Log.WriteEntry("Graba asiento contable de Cta. Cte. del Proveedor.", TraceEventType.Verbose)

      My.Application.Log.WriteEntry("Finaliza la inserción de un Pago a la Cta. Cte. del Proveedor", TraceEventType.Verbose)

   End Sub

   Private Sub CargarUna(o As Entidades.CuentaCorrienteProv, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .TipoComprobante = New TiposComprobantes(da).GetUno(dr.Field(Of String)("IdTipoComprobante"))
         .Letra = dr.Field(Of String)("Letra")
         .CentroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
         .NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
         .Fecha = dr.Field(Of Date)("Fecha")
         .FechaVencimiento = dr.Field(Of Date)("FechaVencimiento")
         .ImporteTotal = dr.Field(Of Decimal)("ImporteTotal") * .TipoComprobante.CoeficienteValores
         .Proveedor = New Proveedores(da)._GetUno(dr.Field(Of Long)("IdProveedor"))
         Dim idFormaPago = dr.Field(Of Integer?)("IdFormasPago").IfNull()
         If idFormaPago <> 0 Then
            .FormaPago = New VentasFormasPago(da).GetUna(idFormaPago)
         End If
         .Observacion = dr.Field(Of String)("Observacion").IfNull()
         .RefProveedor = dr.Field(Of String)("RefProveedor").IfNull()
         .Saldo = dr.Field(Of Decimal)("Saldo")

         .ImportePesos = dr.Field(Of Decimal)("ImportePesos")
         .ImporteDolares = dr.Field(Of Decimal)("ImporteDolares")
         .ImporteTickets = dr.Field(Of Decimal)("ImporteTickets")
         .ImporteTarjetas = dr.Field(Of Decimal)("ImporteTarjetas")
         .ImporteTransfBancaria = dr.Field(Of Decimal)("ImporteTransfBancaria")

         .CotizacionDolar = dr.Field(Of Decimal)(Entidades.CuentaCorrienteProv.Columnas.CotizacionDolar.ToString())

         If .ImporteTransfBancaria <> 0 Then
            .CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(dr.Field(Of Integer?)("IdCuentaBancaria").IfNull(), AccionesSiNoExisteRegistro.Nulo)
            .FechaTransferencia = dr.Field(Of Date?)("FechaTransferencia")
         End If
         .PromedioDiasPago = dr.Field(Of Decimal)("PromedioDiasPago")

         .ImporteRetenciones = dr.Field(Of Decimal)("ImporteRetenciones")

         .Pagos = New CuentasCorrientesProvPagos(da).GetPorCuentaCorriente(o)

         .ChequesTerceros = New Cheques(da).GetPorCuentaCorrienteProv(.IdSucursal, .Proveedor.IdProveedor,
                           .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, False)

         .ChequesPropios = New Cheques(da).GetPorCuentaCorrienteProv(.IdSucursal, .Proveedor.IdProveedor,
                           .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, True)

         Dim idCaja = dr.Field(Of Integer?)("IdCaja")
         If Not String.IsNullOrEmpty(dr("IdCaja").ToString()) Then
            .CajaDetalle = New CajaDetalles(da)._GetUna(dr.Field(Of Integer)("IdSucursal"),
                                                        idCaja.Value,
                                                        dr.Field(Of Integer?)("NumeroPlanilla").IfNull(),
                                                        dr.Field(Of Integer?)("NumeroMovimiento").IfNull())
         End If

         .Retenciones = New RetencionesCompras(da).
                           GetPorCuentaCorriente(.IdSucursal, .TipoComprobante.IdTipoComprobante,
                                                 .Letra, .CentroEmisor, .NumeroComprobante, .Proveedor.IdProveedor)

         .CCTransferencias = New CuentasCorrientesProvTransferencias(da).GetTodos(.IdSucursal, .Proveedor.IdProveedor, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante)

         .IdEjercicio = dr.Field(Of Integer?)("IdEjercicio").IfNull()
         .IdPlanCuenta = dr.Field(Of Integer?)("IdPlanCuenta").IfNull()
         .IdAsiento = dr.Field(Of Integer?)("IdAsiento").IfNull()

         .MetodoGrabacionCampo = Entidades.Entidad.ParseMetodoGrabacion(dr(Entidades.CuentaCorriente.Columnas.MetodoGrabacion.ToString()).ToString())
         .IdFuncion = dr.Field(Of String)(Entidades.CuentaCorriente.Columnas.IdFuncion.ToString())
         .IdEstado = dr.Field(Of String)("IdEstadoComprobante").IfNull()

         .ImprimeSaldos = dr.Field(Of Boolean?)("ImprimeSaldos").IfNull(True)
      End With

   End Sub

   Private Sub SelectFiltrado(ByRef stb As StringBuilder)

      With stb
         .Length = 0
         .AppendLine("SELECT CCP.IdSucursal")
         .AppendLine("      ,CCP.IdTipoComprobante")
         .AppendLine("      ,CCP.Letra")
         .AppendLine("      ,CCP.CentroEmisor")
         .AppendLine("      ,CCP.NumeroComprobante")
         .AppendLine("      ,CCP.Fecha")
         .AppendLine("      ,CCP.FechaVencimiento")
         .AppendLine("      ,CCP.ImporteTotal")
         .AppendLine("      ,CCP.IdProveedor")
         .AppendLine("      ,CCP.IdFormasPago")
         .AppendLine("      ,CCP.Observacion")
         .AppendLine("      ,CCP.Saldo")
         .AppendLine("      ,CCP.ImportePesos")
         .AppendLine("      ,CCP.ImporteDolares")
         .AppendLine("      ,CCP.ImporteEuros")
         .AppendLine("      ,CCP.ImporteTickets")
         .AppendLine("      ,CCP.ImporteTransfBancaria")
         .AppendLine("      ,CCP.ImporteCheques")
         .AppendLine("      ,CCP.ImporteTarjetas")
         .AppendLine("      ,CCP.IdCuentaBancaria")
         .AppendLine("      ,CCP.ImporteRetenciones")
         .AppendLine("      ,CCP.IdCaja")
         .AppendLine("      ,CCP.NumeroPlanilla")
         .AppendLine("      ,CCP.NumeroMovimiento")
         .AppendLine("      ,P.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,CCP.IdEjercicio")
         .AppendLine("      ,CCP.IdPlanCuenta")
         .AppendLine("      ,CCP.IdAsiento")
         .AppendLine("      ,CCP.MetodoGrabacion")
         .AppendLine("      ,CCP.IdFuncion")
         .AppendLine("      ,CCP.ImprimeSaldos")
         .AppendLine("      ,CCP.CotizacionDolar")
         '-- REQ-31391.- --
         .AppendLine("      ,CCP.RefProveedor")
         '-- REQ-44077.- --
         .AppendLine("      ,CCP.PromedioDiasPago")
         .AppendLine("      ,CCP.IdEstadoComprobante")
         '-----------------
         .AppendLine("      ,CCP.NumeroOrdenCompra")
         .AppendLine("  FROM CuentasCorrientesProv CCP")
         .AppendLine(" INNER JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor")
      End With
   End Sub

#End Region

#Region "Overrides"
   <Obsolete("No usar, usar Insertar(Entidad, MetodoGrabacion, String", True)>
   Public Overrides Sub Insertar(entd As Entidades.Entidad)

   End Sub

   Public Overloads Sub Insertar(ent As Entidades.CuentaCorrienteProv,
                                 metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                 idFuncion As String)
      EjecutaConTransaccion(
         Sub()
            ent.NumeroComprobante = GetProximoNumero(ent.IdSucursal,
                                                     ent.TipoComprobante.IdTipoComprobante,
                                                     ent.Letra,
                                                     ent.CentroEmisor)

            Inserta(ent, metodoGrabacion, idFuncion)

            'Vuelvo a leer los datos por la fecha de vencimiento 
            ent = GetUna(ent.IdSucursal, ent.Proveedor.IdProveedor,
                         ent.TipoComprobante.IdTipoComprobante,
                         ent.Letra, ent.CentroEmisor,
                         ent.NumeroComprobante)

         End Sub)
   End Sub

   Public Function Existe(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Boolean
      Return New SqlServer.CuentasCorrientesProv(da).
                     Existe(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

   Public Sub GrabaCtaCte(CC As Entidades.CuentaCorrienteProv, CCP As Entidades.CuentaCorrienteProvPago,
                          MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      EjecutaConTransaccion(Sub() _GrabaCtaCte(CC, CCP, MetodoGrabacion, IdFuncion))
   End Sub

   Private Sub _GrabaCtaCte(cc As Entidades.CuentaCorrienteProv, ccp As Entidades.CuentaCorrienteProvPago,
                            MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Dim ctacte = New SqlServer.CuentasCorrientesProv(da)

      cc.FechaActualizacion = Date.Now()

      Dim imprimeSaldos As Boolean? = Nothing

      If cc.TipoComprobante.EsRecibo Then
         'If CC.TipoComprobante.IdTipoComprobante = "PAGO" Or CC.TipoComprobante.IdTipoComprobante = "PAGOPROV" Then
         imprimeSaldos = True
         cc.ImprimeSaldos = True
      End If

      Publicos.GetSistema().ControlaValidezDeFecha(cc.Fecha)
      Publicos.VerificaFechaUltimoLogin()
      ctacte.CuentasCorrientesProv_I(cc.IdSucursal, cc.TipoComprobante.IdTipoComprobante,
                                         cc.Letra, cc.CentroEmisor, cc.NumeroComprobante, cc.Fecha,
                                         cc.FechaVencimiento, cc.ImporteTotal,
                                         cc.Proveedor.IdProveedor, cc.FormaPago.IdFormasPago, cc.Observacion,
                                         cc.Saldo, cc.Cuotas, cc.ImportePesos, cc.ImporteDolares, cc.ImporteTickets,
                                         cc.ImporteCheques, cc.ImporteTransfBancaria, cc.CuentaBancariaTransfBanc.IdCuentaBancaria,
                                         cc.ImporteRetenciones, cc.ImporteTarjetas, cc.IdEstado, cc.Usuario, cc.FechaActualizacion,
                                         MetodoGrabacion, IdFuncion, imprimeSaldos, cc.CotizacionDolar, cc.RefProveedor, cc.FechaTransferencia, cc.PromedioDiasPago, cc.SaldoCtaCte, cc.NumeroOrdenCompra)

      Dim ctactepag = New SqlServer.CuentasCorrientesProvPagos(da)

      Dim tipo2 = ccp.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante
      Dim letra2 = ccp.CuentaCorrienteProv.Letra
      Dim emisor2 = ccp.CuentaCorrienteProv.CentroEmisor
      Dim comprobante2 = ccp.CuentaCorrienteProv.NumeroComprobante
      Dim cuota2 = 1

      ctactepag.CuentasCorrientesProvPagos_I(ccp.IdSucursal, ccp.TipoComprobante.IdTipoComprobante,
                                             ccp.Letra, cc.CentroEmisor, ccp.NumeroComprobante, ccp.Cuota,
                                             cc.Proveedor.IdProveedor, cc.Fecha,
                                             ccp.FechaVencimiento, ccp.ImporteCuota, ccp.SaldoCuota,
                                             cc.FormaPago.IdFormasPago, cc.Observacion,
                                             tipo2, comprobante2, emisor2, cuota2, letra2, ccp.DescuentoRecargoPorc, ccp.DescuentoRecargo)
   End Sub

   Public Sub ModificaRecibo(recibo As Entidades.CuentaCorrienteProv)

      Try
         If recibo.ImporteTransfBancaria <> 0 AndAlso recibo.CuentaBancariaTransfBanc Is Nothing Then
            Throw New ApplicationException(String.Format("El {0} {1} {2:0000}-{3:00000000} se pago con transferencia y no seleccionó una cuenta bancaria.",
                                                         recibo.TipoComprobante.Descripcion,
                                                         recibo.Letra,
                                                         recibo.CentroEmisor,
                                                         recibo.NumeroComprobante))
         End If

         da.OpenConection()
         da.BeginTransaction()

         Dim reciboAnt As Entidades.CuentaCorrienteProv = Me.GetUna(recibo.IdSucursal, recibo.Proveedor.IdProveedor, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante)
         Dim idCuentaBancaria As Integer? = Nothing

         If recibo IsNot Nothing AndAlso reciboAnt IsNot Nothing Then
            If recibo.CuentaBancariaTransfBanc.IdCuentaBancaria <> reciboAnt.CuentaBancariaTransfBanc.IdCuentaBancaria Then
               If reciboAnt.IdAsiento.HasValue Then
                  Throw New ApplicationException(String.Format("El {0} {1} {2:0000}-{3:00000000} ya fue registrada contablemente en el asiento {4}. No es posible modifcar la cuenta bancaria.",
                                                                  reciboAnt.TipoComprobante.Descripcion,
                                                                  reciboAnt.Letra,
                                                                  reciboAnt.CentroEmisor,
                                                                  reciboAnt.NumeroComprobante,
                                                                  reciboAnt.IdAsiento))
               End If

               If Publicos.TieneModuloBanco Then

                  'Dim rLibroBancos = New LibroBancos(da)
                  Dim rLibBanco = New LibroBancos(da)

                  'Si Pagó parte con Transfencia Bancaria
                  If recibo.ImporteTransfBancaria <> 0 Then
                     rLibBanco.AgregaMovimiento(ArmaLibroBancosPorRenumerar(reciboAnt, 1,
                                                                            rLibBanco.GetProximoNumeroDeMovimiento(recibo.IdSucursal,
                                                                                                                   reciboAnt.CuentaBancariaTransfBanc.IdCuentaBancaria)))
                     rLibBanco.AgregaMovimiento(ArmaLibroBancosPorRenumerar(recibo, -1,
                                                                            rLibBanco.GetProximoNumeroDeMovimiento(recibo.IdSucursal,
                                                                                                                   recibo.CuentaBancariaTransfBanc.IdCuentaBancaria)))
                  End If
               End If

               idCuentaBancaria = recibo.CuentaBancariaTransfBanc.IdCuentaBancaria
            End If
         End If

         If DirectCast(recibo, Entidades.IComprobanteModificable).DebeRenumerar Then
            If reciboAnt.IdAsiento.HasValue Then
               Throw New ApplicationException(String.Format("El {0} {1} {2:0000}-{3:00000000} ya fue registrada contablemente en el asiento {4}. No es posible modifcar su número.",
                                                            reciboAnt.TipoComprobante.Descripcion, reciboAnt.Letra, reciboAnt.CentroEmisor, reciboAnt.NumeroComprobante,
                                                            reciboAnt.IdAsiento))
            End If
         End If

         '-- REQ-35021.- -----------------------------------------------------------------------------------
         Dim fechaEmison As Date? = Nothing
         If reciboAnt.Fecha <> recibo.Fecha Then
            fechaEmison = recibo.Fecha
         End If

         Dim sqlCCP = New SqlServer.CuentasCorrientesProv(da)
         sqlCCP.CuentasCorrientesProvPagos(recibo.IdSucursal, recibo.Proveedor.IdProveedor,
                                           recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante,
                                           fechaEmison,
                                           recibo.Observacion,
                                           idCuentaBancaria)

         Dim DiasAjuste As Integer = Integer.Parse(DateDiff(DateInterval.Day, reciboAnt.Fecha, recibo.Fecha).ToString())

         If fechaEmison.HasValue Then
            Dim sqlCtaCtePagos = New SqlServer.CuentasCorrientesProvPagos(da)
            sqlCtaCtePagos.CuentasCorrientesProvPagos_UFecha(recibo.IdSucursal, recibo.Proveedor.IdProveedor,
                                                             recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante,
                                                             DiasAjuste,
                                                             recibo.Observacion)
         End If

         If DirectCast(recibo, Entidades.IComprobanteModificable).DebeRenumerar Then
            _RenumerarRecibo(recibo)
         End If
         '-----------------------------------------------------------------------------------------------------

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub _RenumerarRecibo(recibo As Entidades.CuentaCorrienteProv)
      _RenumerarRecibo(recibo, recibo)
   End Sub
   Private Sub _RenumerarRecibo(recibo As Entidades.CuentaCorrienteProv, reciboNuevo As Entidades.IComprobanteModificable)
      _RenumerarRecibo(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante,
                       reciboNuevo.IdSucursalNuevo, reciboNuevo.IdTipoComprobanteNuevo, reciboNuevo.LetraNuevo, reciboNuevo.CentroEmisorNuevo, reciboNuevo.NumeroComprobanteNuevo)
   End Sub
   Private Sub _RenumerarRecibo(idSucursalActual As Integer, idTipoComprobanteActual As String, letraActual As String, centroEmisorActual As Short, numeroComprobanteActual As Long,
                                idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Short, numeroComprobanteNuevo As Long)

      Dim sql = New SqlServer.Compras(da)
      'Condición para todas las tablas de compras y PK de CtaCteProv
      Dim whereClauseCompra As String
      whereClauseCompra = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                        Entidades.CuentaCorrienteProv.Columnas.IdSucursal.ToString(), idSucursalActual,
                                        Entidades.CuentaCorrienteProv.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteActual,
                                        Entidades.CuentaCorrienteProv.Columnas.Letra.ToString(), letraActual,
                                        Entidades.CuentaCorrienteProv.Columnas.CentroEmisor.ToString(), centroEmisorActual,
                                        Entidades.CuentaCorrienteProv.Columnas.NumeroComprobante.ToString(), numeroComprobanteActual)

      'Campos a cambiar en todas las tablas de compras y PK de CtaCteProv
      Dim camposCambio = New Dictionary(Of String, String)() _
                                                      From {{Entidades.CuentaCorrienteProv.Columnas.IdSucursal.ToString(), idSucursalNuevo.ToString()},
                                                            {Entidades.CuentaCorrienteProv.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteNuevo},
                                                            {Entidades.CuentaCorrienteProv.Columnas.Letra.ToString(), letraNuevo},
                                                            {Entidades.CuentaCorrienteProv.Columnas.CentroEmisor.ToString(), centroEmisorNuevo.ToString()},
                                                            {Entidades.CuentaCorrienteProv.Columnas.NumeroComprobante.ToString(), numeroComprobanteNuevo.ToString()}}

      Try
         sql.InsertSelect("CuentasCorrientesProv", camposCambio, whereClauseCompra)
      Catch ex As Exception
         If ex.InnerException IsNot Nothing AndAlso TypeOf (ex.InnerException) Is SqlClient.SqlException AndAlso
            DirectCast(ex.InnerException, SqlClient.SqlException).Number = 2627 Then
            Throw New ApplicationException(String.Format("El {1} {2} {3:0000}-{4:00000000} ya existe en la sucursal {0}.",
                                                         idSucursalNuevo, idTipoComprobanteNuevo, letraNuevo, centroEmisorNuevo, numeroComprobanteNuevo), ex)
         End If
         Throw
      End Try

      sql.UpdatePrimaryKey("CuentasCorrientesProvPagos", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesProvCheques", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesProvRetenciones", camposCambio, whereClauseCompra)

      sql.DeleteGenerico("CuentasCorrientesProv", camposCambio, whereClauseCompra)

   End Sub

   Private Function ArmaLibroBancosPorRenumerar(recibo As Entidades.CuentaCorrienteProv, coeficienteValor As Short, proximoNumero As Integer) As Entidades.LibroBanco
      Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      With entLibroBanco
         .IdSucursal = recibo.IdSucursal
         .IdCuentaBancaria = recibo.CuentaBancariaTransfBanc.IdCuentaBancaria
         .NumeroMovimiento = proximoNumero
         .IdCuentaBanco = Publicos.CtaBancoTransfBancaria
         If recibo.ImporteTransfBancaria * coeficienteValor > 0 Then
            .IdTipoMovimiento = "I"
         Else
            .IdTipoMovimiento = "E"
         End If
         .Importe = Math.Abs(recibo.ImporteTransfBancaria)
         .FechaMovimiento = recibo.Fecha
         .IdCheque = 0
         .FechaAplicado = recibo.Fecha
         .Observacion = String.Format("RENUMERA {0} {1} {2:0000}-{3:00000000} - Transf. a Caja. {4}",
                                      recibo.TipoComprobante.Descripcion.Trim(),
                                      recibo.Letra,
                                      recibo.CentroEmisor,
                                      recibo.NumeroComprobante,
                                      recibo.Proveedor.NombreProveedor).Truncar(100)
         .Conciliado = False
      End With
      Return entLibroBanco
   End Function


   Public Function GetSaldoParaMinutas(idSucursal As Integer, tipoComprobante As Entidades.TipoComprobante, grupo As String,
                                     fechaDesde As Date?, fechaHasta As Date?,
                                     numeroOrdenCompra As Long) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.CuentasCorrientesProv(da).GetSaldosParaMinutas(idSucursal, tipoComprobante.ComprobantesAsociados, grupo, fechaDesde, fechaHasta, numeroOrdenCompra))
   End Function

   Public Sub GenerarMinutas(idSucursal As Integer, saldos As DataTable, tipoComprobante As Entidades.TipoComprobante, grupo As String,
                             fechaDesde As Date?, fechaHasta As Date?, fecha As Date,
                             numeroOrdenCompra As Long,
                             MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      EjecutaConTransaccion(
         Sub()

            Dim regCli = New Proveedores(da)
            'recuperar comprobantes positivos / negativos de los clientes que tienen saldo
            ' y por cada cliente con saldo recorrerlos e identificar el meno valor absoluto ------
            For Each sal As DataRow In saldos.Rows
               'recuper los comprobantes de cada cliente
               Dim ctaCte = GetAlgunosComprobantesPorProveedor(idSucursal,
                                                             sal.Field(Of Long)("IdProveedor"),
                                                             tipoComprobante.ComprobantesAsociados,
                                                             grupo, fechaDesde, fechaHasta, numeroOrdenCompra)

               Dim saldoMenor = 0D
               'me fijo si el saldo menor es el positivo o el negativo e identifico el menor valor absoluto
               If Math.Abs(sal.Field(Of Decimal)("Positivo")) > Math.Abs(sal.Field(Of Decimal)("Negativo")) Then
                  'si el mayor es positivo seteo el saldoMayor al positivo
                  saldoMenor = Math.Abs(Decimal.Parse(sal("Negativo").ToString()))
               ElseIf Math.Abs(sal.Field(Of Decimal)("Positivo")) < Math.Abs(sal.Field(Of Decimal)("Negativo")) Then
                  'si el mayor es negativo seteo el saldoMayor al negativo
                  saldoMenor = Math.Abs(sal.Field(Of Decimal)("Positivo"))
               Else
                  'son iguales los saldos entonces seteo cualquiera de los 2
                  saldoMenor = Math.Abs(sal.Field(Of Decimal)("Positivo"))
               End If

               'defino saldos
               Dim saldoAcumuladoNegativo = saldoMenor * -1
               Dim saldoAcumuladoPositivo = saldoMenor

               Dim ctaCtePMinuta = New Entidades.CuentaCorrienteProv()
               ctaCtePMinuta.Fecha = fecha
               ctaCtePMinuta.Proveedor = regCli._GetUno(sal.Field(Of Long)("IdProveedor"))
               'ctaCtePMinuta.idcategoria = ctaCtePMinuta.Cliente.IdCategoria
               ctaCtePMinuta.IdSucursal = ctaCte(0).IdSucursal
               If tipoComprobante.LetrasHabilitadas.Trim.Length = 1 Then
                  ctaCtePMinuta.Letra = tipoComprobante.LetrasHabilitadas
               Else
                  ctaCtePMinuta.Letra = ctaCtePMinuta.Proveedor.CategoriaFiscal.LetraFiscal
               End If
               ctaCtePMinuta.CentroEmisor = ctaCte(0).CentroEmisor

               Dim ctacteDatos = _GetUna(ctaCte(0).IdSucursal, ctaCte(0).IdTipoComprobante, ctaCte(0).Letra,
                                         ctaCte(0).CentroEmisor, ctaCte(0).NumeroComprobante,
                                         sal.Field(Of Long)("IdProveedor"))

               ' ctaCtePMinuta.Vendedor = ctaCte(0).CuentaCorriente.Vendedor
               ' ctaCtePMinuta.Vendedor = ctacteDatos.Vendedor
               ctaCtePMinuta.FechaVencimiento = fecha
               'ctaCtePMinuta.FormaPago = ctaCte(0).FormaPago
               ctaCtePMinuta.FormaPago = ctacteDatos.FormaPago
               ctaCtePMinuta.CajaDetalle.IdCaja = 1
               ctaCtePMinuta.TipoComprobante = tipoComprobante
               ctaCtePMinuta.Usuario = actual.Nombre
               ctaCtePMinuta.CotizacionDolar = ctacteDatos.CotizacionDolar
               ctaCtePMinuta.SaldoCtaCte = sal.Field(Of Decimal)("Positivo") + sal.Field(Of Decimal)("Negativo")

               ctaCtePMinuta.NumeroOrdenCompra = numeroOrdenCompra

               'comienzo la barrida de los comprobantes para setear los saldos y generar la minuta
               'supongo que los comprobantes estan acomodados de la fecha mas vieja a la mas nueva
               For Each cc As Entidades.CuentaCorrienteProvPago In ctaCte

                  Dim ctactePago = New Entidades.CuentaCorrienteProvPago()
                  Dim saldoAPagar = 0D

                  If saldoAcumuladoNegativo = 0 And saldoAcumuladoPositivo = 0 Then
                     Exit For
                  End If

                  'si el comprobante es Negativo
                  If cc.SaldoCuota < 0 Then
                     'consulto si el saldo del comprobante es menor o igual al saldo a descontar
                     If saldoAcumuladoNegativo < 0 Then
                        If cc.SaldoCuota >= saldoAcumuladoNegativo Then
                           saldoAPagar = cc.SaldoCuota
                           saldoAcumuladoNegativo -= saldoAPagar
                        Else
                           saldoAPagar = saldoAcumuladoNegativo
                           saldoAcumuladoNegativo -= saldoAPagar
                        End If
                     Else
                        'voy al otro registro
                        Continue For
                     End If
                  Else
                     'el comprobante es Positivo
                     'consulto si el saldo es menor o igual al valor a pagar
                     If saldoAcumuladoPositivo > 0 Then
                        If cc.SaldoCuota <= saldoAcumuladoPositivo Then
                           saldoAPagar = cc.SaldoCuota
                           saldoAcumuladoPositivo -= saldoAPagar
                        Else
                           saldoAPagar = saldoAcumuladoPositivo
                           saldoAcumuladoPositivo -= saldoAPagar
                        End If
                     Else
                        'voy al otro registro
                        Continue For
                     End If
                  End If

                  With ctactePago
                     .TipoComprobante = cc.TipoComprobante
                     .Letra = cc.Letra
                     .CentroEmisor = cc.CentroEmisor
                     .NumeroComprobante = cc.NumeroComprobante
                     .Cuota = cc.Cuota
                     .Fecha = cc.Fecha
                     .FechaVencimiento = cc.FechaVencimiento
                     .ImporteCuota = cc.ImporteCuota


                     'esta quedando maal el saldo del comprobante ajustado en cta cte pagos, en cta cte bien!!!!!
                     .SaldoCuota = cc.SaldoCuota
                     'pago
                     .Paga = saldoAPagar
                     .DescuentoRecargoPorc = 0
                     .DescuentoRecargo = 0
                     .IdSucursal = cc.IdSucursal
                     .Usuario = cc.Usuario
                  End With
                  ctaCtePMinuta.Pagos.Add(ctactePago)

               Next

               'genero la minuta y la grabo
               Inserta(ctaCtePMinuta, MetodoGrabacion, IdFuncion)
            Next

         End Sub)
   End Sub
   Public Function _GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                           numeroComprobante As Long, idProveedor As Long) As Entidades.CuentaCorrienteProv
      Return _GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function _GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String,
                           centroEmisor As Integer, numeroComprobante As Long,
                           idProveedor As Long,
                           accion As AccionesSiNoExisteRegistro) As Entidades.CuentaCorrienteProv
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaCorrienteProv(),
                          accion, Function() String.Format("No existe el Comprobante {0} {1} {2} {3:0000}-{4:00000000} en Cuenta Corriente.", idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
   End Function

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectFiltrado(stb)
         .AppendFormatLine(" WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CCP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND CCP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND CCP.NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND CCP.IdProveedor = {0}", idProveedor)
      End With
      Return da.GetDataTable(stb.ToString())
   End Function
   Private Function GetAlgunosComprobantesPorProveedor(idSucursal As Integer, idProveedor As Long, algunosComprobantes As String, grupo As String,
                                                     fechaDesde As Date?, fechaHasta As Date?,
                                                     numeroOrdenCompra As Long) As List(Of Entidades.CuentaCorrienteProvPago)
      Dim cc As Entidades.CuentaCorrienteProvPago
      Dim lis = New List(Of Entidades.CuentaCorrienteProvPago)()

      Dim sql = New SqlServer.CuentasCorrientesProv(da)
      Using dt As DataTable = sql.GetAlgunosComprobantesPorProveedor(idSucursal, idProveedor, algunosComprobantes, grupo, fechaDesde, fechaHasta, numeroOrdenCompra)
         For Each dr As DataRow In dt.Rows
            cc = New Reglas.CuentasCorrientesProvPagos().GetUna(dr.ValorNumericoPorDefecto("IdSucursal", 0I),
                                                            dr("IdTipoComprobante").ToString(),
                                                            dr("Letra").ToString(),
                                                            dr.ValorNumericoPorDefecto("CentroEmisor", 0S),
                                                            dr.ValorNumericoPorDefecto("NumeroComprobante", 0L),
                                                            dr.ValorNumericoPorDefecto("IdProveedor", 0L),
                                                            dr.ValorNumericoPorDefecto("CuotaNumero", 0I))

            lis.Add(cc)
         Next
      End Using

      Return lis
   End Function
#End Region

End Class
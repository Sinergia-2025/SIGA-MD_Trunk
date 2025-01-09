Public Class CuentasCorrientes
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CuentasCorrientes"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Public Function GetProximoNumero(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer,
                                    comparteNumeracion As Boolean) As Integer
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Append("SELECT (Numero + 1) Numero ")
         .Append("  FROM VentasNumeros")
         .Append(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .Append("   AND LetraFiscal = '" & letraFiscal & "'")
         .Append("   AND CentroEmisor = " & emisor.ToString())
         .Append("   AND (IdSucursal = " & idSucursal.ToString())
         If comparteNumeracion Then
            .Append("  OR IdSucursal = 0")
         End If
         .Append(")")
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 1
      End If
   End Function

   Friend Sub GrabaCuentaCorriente(ent As Entidades.CuentaCorriente, metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      Dim ajuste As Decimal = ent.TipoComprobante.CoeficienteValores
      Dim saldo As Decimal = 0
      Dim cantidadCuotas As Integer = 0
      Dim TotalAplicado As Decimal = 0

      If ent.TipoComprobante.EsRecibo = False Then
         'Si es NCRED viene negativo y lo da vuelva, no corresponde. El valor siempre esta bien.
         'saldo = ent.ImporteTotal * ajuste
         saldo = ent.ImporteTotal
         cantidadCuotas = ent.Pagos.Count
      Else

         For Each pag As Entidades.CuentaCorrientePago In ent.Pagos
            TotalAplicado = TotalAplicado + pag.Paga
         Next

         'Si es mayor implica que dejo plata a cuenta.
         If ent.ImporteTotal <> TotalAplicado Then
            saldo = ent.ImporteTotal - TotalAplicado
         End If

         ent.ImporteTotal *= ajuste
         saldo *= ajuste

      End If

      ''Lo asigno porque despues es utilizado (si deja anticipo).
      ent.Saldo = saldo
      ent.FechaActualizacion = Date.Now()

      Dim sql = New SqlServer.CuentasCorrientes(da)

      Dim imprimeSaldos As Boolean? = Nothing
      If ent.TipoComprobante.EsRecibo Then
         imprimeSaldos = True
         ent.ImprimeSaldos = True
      End If

      Publicos.GetSistema().ControlaValidezDeFecha(ent.Fecha)
      Reglas.Publicos.VerificaFechaUltimoLogin()

      If String.IsNullOrWhiteSpace(ent.Direccion) Then
         ent.Direccion = ent.Cliente.Direccion
         ent.IdLocalidad = ent.Cliente.IdLocalidad
      End If

      sql.CuentasCorrientes_I(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                              ent.Fecha, ent.FechaVencimiento, ent.ImporteTotal, ent.Cliente.IdCliente,
                              ent.Vendedor.IdEmpleado, ent.FormaPago.IdFormasPago, ent.Observacion,
                              ent.Saldo, cantidadCuotas, ent.ImportePesos, ent.ImporteDolares, ent.ImporteTickets, ent.ImporteTarjetas,
                              ent.ImporteCheques, ent.ImporteTransfBancaria, ent.CuentaBancariaTransfBanc.IdCuentaBancaria,
                              ent.ImporteRetenciones, ent.Usuario, ent.IdEstado, ent.FechaActualizacion, ent.IdClienteCtaCte, ent.IdCategoria,
                              ent.SaldoCtaCte, metodoGrabacion, idFuncion, imprimeSaldos, ent.Cobrador.IdEmpleado, ent.EstadoCliente.IdEstadoCliente,
                              ent.NumeroOrdenCompra, ent.Referencia,
                              ent.IdSucursalVinculado, ent.IdTipoComprobanteVinculado, ent.LetraVinculado, ent.CentroEmisorVinculado,
                              ent.NumeroComprobanteVinculado, ent.CotizacionDolar, ent.FechaTransferencia, ent.FechaExportacion, ent.Direccion,
                              ent.IdLocalidad, ent.NumeroReparto, ent.IdTipoNovedad, ent.LetraNovedad, ent.CentroEmisorNovedad, ent.NumeroNovedad,
                              ent.IdEmbarcacion, ent.FechaCalculoInteresModif, ent.FechaCalculoInteres, ent.IdCama, ent.FechaPromedioCobro, ent.PromedioDiasCobro, ent.CantidadDiasCobro)

      '-- REQ-31710.- --------------------
      If ent.NumeroNovedad.HasValue Then
         '-- Llamo a la regla para que actualice el anticipo.- --
         Dim rNovedad = New Reglas.CRMNovedades(da)
         rNovedad.ActualizaAnticipos(ent.IdTipoNovedad, ent.LetraNovedad, ent.CentroEmisorNovedad.IfNull, ent.NumeroNovedad.IfNull, (ent.ImporteTotal * ent.TipoComprobante.CoeficienteValores))
      End If
      '-----------------------------------

      Dim rCCP = New Reglas.CuentasCorrientesPagos(da)

      'El ImporteAnticipo contiene el importe de anticipo de Fichas. Por ellos lo inserto primero como Cuota Cero
      Dim ctacteAnticipo As Entidades.CuentaCorrientePago = Nothing
      If ent.ImporteAnticipo <> 0 Then
         ctacteAnticipo = New Entidades.CuentaCorrientePago()
         With ctacteAnticipo
            .TipoComprobante = ent.TipoComprobante
            .Letra = ent.Letra
            .CentroEmisor = ent.CentroEmisor
            .NumeroComprobante = ent.NumeroComprobante

            'Por Facturacion no tiene el Periodo. Pero lo dejo por las dudas.
            .Cuota = 0

            .FechaEmision = ent.Fecha
            .FechaVencimiento = ent.Fecha
            .ImporteCuota = ent.ImporteAnticipo
            .SaldoCuota = ent.ImporteAnticipo
            'If impAPagar <= oVentas.CuentaCorriente.ImporteAnticipo Then
            '   .Paga = impAPagar
            '   impAPagar -= impAPagar
            'Else
            '   .Paga = .SaldoCuota
            '   impAPagar -= .SaldoCuota
            'End If
            .DescuentoRecargoPorc = 0
            .DescuentoRecargo = .Paga - Decimal.Round(.Paga / (1 + .DescuentoRecargoPorc / 100), 2)
            .IdSucursal = ent.IdSucursal
            .Usuario = ent.Usuario
            .CuentaCorriente = ent

         End With

         rCCP.GrabaCuentaCorrientePagos(ctacteAnticipo, ctacteAnticipo.Cuota)

      End If

      Dim renumerar As Boolean = ent.TipoComprobante.EsRecibo OrElse ent.TipoComprobante.EsAnticipo OrElse ent.Pagos.LongCount(Function(x) x.Cuota > 0) = 0
      Dim cuota As Integer = 1
      Dim TipoComprobanteRecibo As String = String.Empty

      If ent.FormaPago.Dias > 0 AndAlso ent.Pagos.CountSecure() = 0 Then
         ent.Pagos = New CuentasCorrientesPagos(da).CalculaCuotasSegunFormaPago(ent, 2)
      End If

      'graba todos los pagos que tiene que realizar por la cuenta corriente
      For Each pag As Entidades.CuentaCorrientePago In ent.Pagos

         pag.CuentaCorriente = ent

         'Si aplico un comprobante normal y tiene una cuota con un numero algo lo debe asignar, porque puede ser un periodo (EJ: 201501).
         If Not ent.TipoComprobante.EsRecibo And Not ent.TipoComprobante.EsAnticipo And pag.Cuota > 190101 Then
            cuota = pag.Cuota
         End If

         If renumerar Then
            If pag.Cuota = 0 Then
               pag.Cuota = cuota
            End If
         Else
            cuota = pag.Cuota
         End If
         '-- REQ-33524.- ---------------------
         If ent.IdEmbarcacion > 0 Then
            pag.IdEmbarcacion = ent.IdEmbarcacion
         End If
         '-- REQ-36331.- ---------------------
         If ent.IdCama > 0 Then
            pag.IdCama = ent.IdCama
         End If
         '------------------------------------

         'La fecha de vencimiento del Pago que corresponde es la de emision, asi las estadisticas marcan bien las diferencias.
         If pag.CuentaCorriente.TipoComprobante.EsRecibo = True Then
            pag.FechaVencimiento = ent.Fecha
         End If

         rCCP.GrabaCuentaCorrientePagos(pag, cuota)

         If pag.CuentaCorriente.TipoComprobante.EsRecibo = True Then
            rCCP.ActualizaComprobantes(pag, cuota)
         End If

         cuota += 1

         'Si esta aplicando un ANTICIPO, le quito ese pago al recibo (para nivelar la cuenta) que tenia el monto en el saldo. En la tabla detalle tiene otra logica.
         If pag.TipoComprobante.EsAnticipo = True Then

            'El Anticipo tiene asignado el Tipo de Recibo que lo Genera.
            If String.IsNullOrEmpty(pag.TipoComprobante.IdTipoComprobanteSecundario) Then
               Throw New Exception("El cobro tiene un Anticipo pero el comprobante " & pag.TipoComprobante.Descripcion.Trim() & ", No tiene Asignado el IdTipoComprobanteSecundario")

            End If
            TipoComprobanteRecibo = pag.TipoComprobante.IdTipoComprobanteSecundario

            'El Anticipo tiene el Numero del recibo que lo emitio, por eso uso sus datos.

            'sql.CuentasCorrientes_AplicaAlSaldo(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, pag.Letra, _
            sql.CuentasCorrientes_AplicaAlSaldo(ent.IdSucursal,
                                                TipoComprobanteRecibo,
                                                pag.Letra,
                                                Short.Parse(pag.CentroEmisor.ToString()),
                                                pag.NumeroComprobante,
                                                pag.Paga * ajuste)


            'CCP.ActualizaComprobantes(pag, cuota)
         End If

      Next

      If ctacteAnticipo IsNot Nothing Then
         ent.Pagos.Insert(0, ctacteAnticipo)
      End If

      ent.ImporteTotal = ent.ImporteTotal * ajuste

      'Si es un Recibo y Pago de mas, dejo la plata a Cuenta.
      If Not ent.TipoComprobante.EsReciboClienteVinculado And ent.TipoComprobante.EsRecibo = True And ent.ImporteTotal <> TotalAplicado Then
         Dim tipoComp As Entidades.TipoComprobante

         If String.IsNullOrWhiteSpace(ent.TipoComprobante.IdTipoComprobanteSecundario) Then
            Throw New Exception(String.Format("El tipo de comprobante {0} no tiene configurado un comprobante secundario." + Environment.NewLine + Environment.NewLine +
                                              "No es posible generar el anticipo.", ent.TipoComprobante.Descripcion))
         End If
         tipoComp = New Reglas.TiposComprobantes(da).GetUno(ent.TipoComprobante.IdTipoComprobanteSecundario.ToString())

         'If ent.TipoComprobante.GrabaLibro Then
         '    tipoComp = New Reglas.TiposComprobantes(da).GetUno("ANTICIPO")
         'Else
         '    tipoComp = New Reglas.TiposComprobantes(da).GetUno("ANTICIPOPROV")
         'End If


         Dim ajuste2 As Decimal = tipoComp.CoeficienteValores
         Dim anticipo As Decimal = (ent.ImporteTotal - TotalAplicado) * ajuste2
         imprimeSaldos = Nothing

         Publicos.GetSistema().ControlaValidezDeFecha(ent.Fecha)
         Reglas.Publicos.VerificaFechaUltimoLogin()

         sql.CuentasCorrientes_I(ent.IdSucursal, tipoComp.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                 ent.Fecha, ent.FechaVencimiento, anticipo, ent.Cliente.IdCliente,
                                 ent.Vendedor.IdEmpleado, ent.FormaPago.IdFormasPago, ent.Observacion,
                                 anticipo, 1, anticipo, 0, 0, 0, 0, 0, 0, 0, ent.Usuario, ent.IdEstado, ent.FechaActualizacion, ent.IdClienteCtaCte, ent.IdCategoria,
                                 0, metodoGrabacion, idFuncion, imprimeSaldos, ent.Cobrador.IdEmpleado, ent.EstadoCliente.IdEstadoCliente, ent.NumeroOrdenCompra, ent.Referencia,
                                 ent.IdSucursalVinculado, ent.IdTipoComprobanteVinculado, ent.LetraVinculado, ent.CentroEmisorVinculado, ent.NumeroComprobanteVinculado,
                                 ent.CotizacionDolar, ent.FechaTransferencia, ent.FechaExportacion, ent.Direccion, ent.IdLocalidad, ent.NumeroReparto,
                                 idtipoNovedad:=Nothing, letraNovedad:=Nothing, centroEmisorNovedad:=Nothing, numeroNovedad:=Nothing, ent.IdEmbarcacion, ent.FechaCalculoInteresModif, ent.FechaCalculoInteres, ent.IdCama,
                                 ent.FechaPromedioCobro, ent.PromedioDiasCobro, ent.CantidadDiasCobro)

         Dim ecc As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()
         ecc.TipoComprobante = tipoComp
         ecc.CuentaCorriente = ent
         '-- REQ-33207.- ------------------------------------------
         ecc.IdEmbarcacion = ent.IdEmbarcacion
         '---------------------------------------------------------
         ecc.Paga = saldo * ecc.TipoComprobante.CoeficienteValores
         ecc.FechaVencimiento = ent.FechaVencimiento
         ecc.SaldoCuota = saldo * ecc.TipoComprobante.CoeficienteValores
         ecc.ImporteCuota = saldo * ecc.TipoComprobante.CoeficienteValores
         ecc.ImporteCapital = ecc.ImporteCuota
         Dim tipo As String = Nothing
         Dim tipo2 As String = Nothing
         Dim letra2 As String = Nothing
         Dim cuota2 As Integer = 0
         Dim comprobante2 As Long = 0
         Dim emisor2 As Integer = 0

         Dim sqlccp As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

         tipo = ecc.TipoComprobante.IdTipoComprobante
         cuota = 1
         saldo = ecc.SaldoCuota

         tipo2 = ecc.TipoComprobante.IdTipoComprobante
         letra2 = ecc.CuentaCorriente.Letra
         emisor2 = ecc.CuentaCorriente.CentroEmisor
         comprobante2 = ecc.CuentaCorriente.NumeroComprobante
         cuota2 = 1

         sqlccp.CuentasCorrientesPagos_I(ecc.CuentaCorriente.IdSucursal, tipo, ecc.CuentaCorriente.Letra,
                                          ecc.CuentaCorriente.CentroEmisor, ecc.CuentaCorriente.NumeroComprobante, cuota,
                                          ecc.CuentaCorriente.Fecha, ent.FechaVencimiento, ecc.ImporteCuota * ajuste, saldo * ajuste,
                                          ecc.CuentaCorriente.FormaPago.IdFormasPago, ecc.CuentaCorriente.Observacion,
                                          tipo2, comprobante2, emisor2, cuota2, letra2, 0, 0,
                                          ecc.ImporteCapital, ecc.ImporteInteres, ecc.FechaVencimiento2, ecc.ImporteCuota2,
                                          ecc.FechaVencimiento3, ecc.ImporteCuota3, ecc.FechaVencimiento4, ecc.ImporteCuota4,
                                          ecc.FechaVencimiento5, ecc.ImporteCuota5, ecc.CodigoDeBarra, ecc.ReferenciaCuota,
                                          ecc.IdEmbarcacion, ent.IdCama, ecc.CodigoDeBarraSirplus, ecc.FechaPromedioCobro, ecc.PromedioDiasCobro, ecc.CantidadDiasCobro)


      End If

   End Sub

   Friend Sub AnulaCuentaCorriente(ent As Entidades.CuentaCorriente)

      Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)

      Dim sql2 As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)

      sql2.CuentasCorrientes_LimpiaFechaExportacion(ent.IdSucursal,
                                  ent.TipoComprobante.IdTipoComprobante,
                                  ent.Letra,
                                  ent.CentroEmisor,
                                  ent.NumeroComprobante)

      sql.CuentasCorrientes_AnulaRecibo(ent.IdSucursal,
                                    ent.TipoComprobante.IdTipoComprobante,
                                    ent.Letra,
                                    ent.CentroEmisor,
                                    ent.NumeroComprobante,
                                    ent.IdEstado)

      Dim CCP As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos(da)

      For Each pag As Entidades.CuentaCorrientePago In ent.Pagos
         pag.CuentaCorriente = ent
         CCP.Eliminar(pag)
      Next

   End Sub

   Public Sub EliminarComprobante(ent As Entidades.CuentaCorriente)
      EjecutaConTransaccion(Sub() EliminarCuentaCorriente(ent))
   End Sub

   Public Sub EliminarCuentaCorriente(ent As Entidades.CuentaCorriente)

      If Publicos.TieneModuloContabilidad And ent.TipoComprobante.GeneraContabilidad Then
         Dim ctblEjercicio = New ContabilidadEjercicios(da)
         ctblEjercicio.EstaPeriodoCerrado(ent.Fecha)
      End If

      'Actualiza la numeración si es el ultimo numero
      If ent.TipoComprobante.EsRecibo Then
         Dim oventasNumeros As Reglas.VentasNumeros = New Reglas.VentasNumeros(da)
         Dim VentaNumero As Entidades.VentaNumero = New Entidades.VentaNumero()

         Dim idSucursal As Integer = ent.IdSucursal
         If Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales Then
            idSucursal = 0
         End If

         Dim ultimoNumero As Long = oventasNumeros.GetUltimoNumero(idSucursal, ent.TipoComprobante.IdTipoComprobante,
                                        ent.Letra, ent.CentroEmisor)

         If ultimoNumero = ent.NumeroComprobante Then
            Dim compAnterior As DataTable
            compAnterior = oventasNumeros.GetReciboAnterior(idSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra,
                                           ent.CentroEmisor, ent.NumeroComprobante)
            For Each dr As DataRow In compAnterior.Rows
               With VentaNumero
                  If Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales Then
                     .IdSucursal = -1
                  Else
                     .IdSucursal = ent.IdSucursal
                  End If
                  .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
                  .LetraFiscal = ent.Letra
                  .CentroEmisor = ent.CentroEmisor
                  .Numero = Long.Parse(dr("NumeroComprobante").ToString())
                  .Fecha = Date.Parse(dr("Fecha").ToString())
               End With
               oventasNumeros.ActualizarNumero(VentaNumero)
            Next

         End If
      End If



      '*** Las validaciones si es correcto elminar o no, debieron hacerse antes de llamar a esta funcion ***

      'Borro los Cheques (pueden existir o no)

      Dim CCC As Reglas.CuentasCorrientesCheques = New Reglas.CuentasCorrientesCheques(da)

      CCC.Eliminar(ent)

      'Borro las Cuotas

      Dim CCP As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos(da)

      For Each pag As Entidades.CuentaCorrientePago In ent.Pagos
         pag.CuentaCorriente = ent
         CCP.Eliminar(pag)
      Next

      '--REQ-42024.- ---------------------------------------------------
      Dim oCtaCteTran = New Reglas.CuentasCorrientesTransferencias(da)
      For Each rCCTran In ent.CCTransferencias
         oCtaCteTran._Borra(rCCTran)
      Next
      '-----------------------------------------------------------------

      'Borro la Cabecera

      Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)

      sql.CuentasCorrientes_D(ent.IdSucursal,
                              ent.TipoComprobante.IdTipoComprobante,
                              ent.Letra,
                              ent.CentroEmisor,
                              ent.NumeroComprobante)

   End Sub

   <Obsolete("Por favor usar GetSaldoCliente(Entidades.Sucursal(),Long,Date,Boolean,String,Nullable(Of Boolean),List(Of String),String)")>
   Public Function GetSaldoCliente(sucursal As Integer,
                                   idCliente As Long,
                                   Optional fechaSaldo As Date = Nothing,
                                   Optional contemplaHora As Boolean = False,
                                   Optional comprobantesAsociados As String = "TODOS",
                                   Optional grabaLibro As Nullable(Of Boolean) = Nothing,
                                   Optional comprobantesExcluidos As List(Of String) = Nothing,
                                   Optional numeroComprobanteFinalizaCon As String = "",
                                   Optional Idcama As Long = 0,
                                   Optional IdEmbarcacion As Long = 0) As Decimal
      Return GetSaldoCliente({New Entidades.Sucursal() With {.Id = sucursal}},
                             idCliente,
                             fechaSaldo,
                             contemplaHora,
                             comprobantesAsociados,
                             grabaLibro,
                             comprobantesExcluidos,
                             numeroComprobanteFinalizaCon, False, 0, 0)
   End Function

   Public Function GetSaldoCliente(sucursales As Entidades.Sucursal(),
                                   idCliente As Long,
                                   fechaSaldo As Date,
                                   contemplaHora As Boolean,
                                   comprobantesAsociados As String,
                                   grabaLibro As Boolean?,
                                   comprobantesExcluidos As List(Of String),
                                   numeroComprobanteFinalizaCon As String,
                                   excluirPreComprobantes As Boolean,
                                   IdCama As Long,
                                   IdEmbarcacion As Long) As Decimal
      'Optional fechaSaldo As Date = Nothing,
      'Optional contemplaHora As Boolean = False,
      'Optional comprobantesAsociados As String = "TODOS",
      'Optional grabaLibro As Nullable(Of Boolean) = Nothing,
      'Optional comprobantesExcluidos As List(Of String) = Nothing,
      'Optional numeroComprobanteFinalizaCon As String = "") As Decimal



      'TODO: Revisar quienes lo usan y ver cuando se debe pasar GrabaLibro y cuando FechaSaldo
      'SPC: Revisar quienes lo usan y ver cuando se debe pasar GrabaLibro y cuando FechaSaldo

      Dim CtaCteClientesSeparar As Boolean = Reglas.Publicos.CtaCte.CtaCteClientesSeparar

      Return New SqlServer.CuentasCorrientes(da).GetSaldoCliente(sucursales,
                                                                 idCliente,
                                                                 fechaSaldo,
                                                                 contemplaHora,
                                                                 comprobantesAsociados,
                                                                 grabaLibro,
                                                                 comprobantesExcluidos,
                                                                 numeroComprobanteFinalizaCon,
                                                                 CtaCteClientesSeparar,
                                                                 excluirPreComprobantes,
                                                                 IdCama,
                                                                 IdEmbarcacion)

   End Function

   Public Function BuscarPendientes(idSucursal As Integer,
                     idCliente As Long, categoria As Integer, buscaPorClienteVinculado As Boolean,
                     tiposComprobantes As String, idTipoComprobante As String, letra As String, emisor As Short, numeroComprobante As Long, numeroComprobanteFinalizaCon As String,
                     idTipoLiquidacion As Integer?, incluirPreElectronicos As Boolean,
                     idEmbarcacion As Long, idCama As Long, crmNovedad As Entidades.CRMNovedad,
                     seleccionMultiple As Boolean) As DataTable
      Dim soySisen = New Generales().ExisteTabla("Embarcaciones")
      Return New SqlServer.CuentasCorrientes(da).BuscarPendientes(idSucursal,
                     idCliente, categoria, buscaPorClienteVinculado,
                     tiposComprobantes, idTipoComprobante, letra, emisor, numeroComprobante, numeroComprobanteFinalizaCon,
                     idTipoLiquidacion, incluirPreElectronicos,
                     idEmbarcacion, idCama, crmNovedad,
                     seleccionMultiple,
                     Publicos.CtaCte.CtaCteClientesPriorizarNCsyAnticipos, Publicos.CtaCte.CtaCteClientesSeparar, soySisen)

   End Function

   Public Function BuscarPendientesAPagar(IdSucursal As Integer,
                                          IdCliente As Long,
                                          TiposComprobantes As String) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT cc.IdSucursal AS Sucursal")
         .AppendLine("      ,cc.FechaVencimiento")
         .AppendLine("      ,TC.Descripcion AS Tipo")
         .AppendLine("      ,cc.Letra")
         .AppendLine("      ,cc.CentroEmisor AS Emisor")
         .AppendLine("      ,cc.NumeroComprobante AS Numero")
         .AppendLine("      ,cc.CuotaNumero AS Cuota")
         .AppendLine("      ,cc.Fecha")
         .AppendLine("      ,cc.ImporteCuota AS Importe")
         .AppendLine("      ,cc.SaldoCuota AS Saldo")
         .AppendLine("      ,cc.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")
         .AppendLine("      ,cc.Observacion")
         .AppendLine("      ,cc.IdTipoComprobante")
         .AppendLine("      ,aa.IdCliente")

         If Reglas.Publicos.CtaCte.CtaCteClientesPriorizarNCsyAnticipos Then
            .AppendLine("       ,(CASE WHEN cc.ImporteCuota<0 THEN 1 ELSE 2 END) AS Prioridad")
         Else
            .AppendLine("       ,1 AS Prioridad")
         End If

         .AppendLine(" FROM CuentasCorrientes aa ")
         .AppendLine(" INNER JOIN CuentasCorrientesPagos cc ON cc.idsucursal = aa.idsucursal and cc.idtipocomprobante = aa.idtipocomprobante")
         .AppendLine("       AND cc.letra = aa.letra AND cc.centroemisor = aa.centroemisor AND cc.numerocomprobante = aa.numerocomprobante")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON aa.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON aa.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" WHERE aa.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND aa.IdCliente = " & IdCliente.ToString())

         'Si el comprobante esta en la Cuenta Corriente, no debe mirar si es facturable.
         '.Append(" and tp.EsFacturable = 'False'")
         .AppendLine("   and cc.SaldoCuota < 0")     'Positivos: Factura y Nota Debito, Negativo: Nota Credito.
         .AppendLine("   and TC.EsRecibo = 'False'")

         If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
            '.AppendLine("   AND tp.GrabaLibro = '" & grabaLibro & "'")
            .AppendLine("   AND TC.IdTipoComprobante IN (" & TiposComprobantes & ")")
         End If

         '.AppendLine("   AND NOT (tp.EsElectronico = 'True' AND tp.CoeficienteStock = 0)") 'Los Pre-Electronicos no deben ser imputados.
         .AppendLine("   AND NOT TC.EsPreElectronico = 'True'")
         .AppendLine(" ORDER BY Prioridad")
         .AppendLine("          ,CONVERT(varchar(11), cc.FechaVencimiento, 120)")
         .AppendLine("          ,TC.Descripcion")
         .AppendLine("          ,cc.Letra")
         .AppendLine("          ,cc.CentroEmisor")
         .AppendLine("          ,cc.NumeroComprobante")
         .AppendLine("          ,cc.CuotaNumero")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function BuscarPendientesFichas(idSucursal As Integer, cliente As Eniac.Entidades.Cliente, todas As Boolean) As DataTable
      Return New SqlServer.CuentasCorrientes(da).BuscarFichasPendientes(idSucursal, cliente.IdCliente, todas)
   End Function

   Public Function GetPorCliente(sucursales As Entidades.Sucursal(),
                                 idCliente As Long,
                                 fechaUtilizada As String,
                                 desde As Date?,
                                 hasta As Date?,
                                 grabaLibro As String,
                                 grupo As String,
                                 excluirMinutas As String,
                                 idMoneda As Integer,
                                 tipoConversion As Entidades.Moneda_TipoConversion,
                                 cotizDolar As Decimal,
                                 excluirPreComprobantes As Boolean) As DataTable
      Return New SqlServer.CuentasCorrientes(da).GetPorCliente(sucursales, idCliente, fechaUtilizada, desde, hasta, grabaLibro, grupo,
                                                               excluirMinutas, idMoneda, tipoConversion, cotizDolar, excluirPreComprobantes)
   End Function
   Public Function GetPorClienteImporte(idSucursal As Integer,
                                desde As Date?,
                                hasta As Date?,
                                idTipoComprobante As String,
                                importeTotal As Decimal,
                                idCliente As Long,
                                conSaldo As Boolean,
                                numeroComprobanteDesde As Long,
                                numeroComprobanteHasta As Long,
                                letraFiscal As String,
                                centroEmisor As Integer) As DataTable

      Return New SqlServer.CuentasCorrientes(da).GetPorClienteImporte(idSucursal,
                                                                      desde,
                                                                      hasta,
                                                                      idTipoComprobante,
                                                                      importeTotal,
                                                                      idCliente,
                                                                      conSaldo,
                                                                      numeroComprobanteDesde,
                                                                      numeroComprobanteHasta,
                                                                      letraFiscal,
                                                                      centroEmisor)
   End Function

   Public Function GetRecibosPorRangoFechas(sucursales As Entidades.Sucursal(),
                                            desde As Date, hasta As Date,
                                            idCliente As Long,
                                            idCategoria As Integer, categoria As Entidades.OrigenFK,
                                            idVendedor As Integer, vendedor As Entidades.OrigenFK,
                                            idTipoComprobante As String,
                                            idUsuario As String,
                                            idCaja As Integer,
                                            letraFiscal As String, centroEmisor As Integer,
                                            numeroComprobanteDesde As Long, numeroComprobanteHasta As Long,
                                            idZonaGeografica As String,
                                            idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                            idEstadoCliente As Integer, estdoCliente As Entidades.OrigenFK,
                                            numeroReparto As Integer?) As DataTable
      Return New SqlServer.CuentasCorrientes(da).GetRecibosPorRangoFechas(sucursales,
                                                                          desde, hasta,
                                                                          idCliente,
                                                                          idCategoria, categoria,
                                                                          idVendedor, vendedor,
                                                                          idTipoComprobante,
                                                                          idUsuario,
                                                                          idCaja,
                                                                          letraFiscal, centroEmisor,
                                                                          numeroComprobanteDesde, numeroComprobanteHasta,
                                                                          idZonaGeografica,
                                                                          idCobrador, cobrador,
                                                                          idEstadoCliente, estdoCliente,
                                                                          actual.NivelAutorizacion,
                                                                          numeroReparto)
   End Function

   Public Function GetTotaldeCobranzaPorDia(sucursales As Entidades.Sucursal(),
                                            desde As Date,
                                            hasta As Date,
                                            idCliente As Long,
                                            idCategoria As Integer,
                                            categoria As Entidades.OrigenFK,
                                            IdVendedor As Integer,
                                            vendedor As Entidades.OrigenFK,
                                            idTipoComprobante As String,
                                            idCaja As Integer,
                                            idZonaGeografica As String,
                                            idCobrador As Integer,
                                            cobrador As Entidades.OrigenFK,
                                            incluirFecha As Boolean) As DataTable
      Dim dt As DataTable
      dt = New SqlServer.CuentasCorrientes(da).GetTotaldeCobranzaPorDia(sucursales,
                                                                        desde,
                                                                        hasta,
                                                                        idCliente,
                                                                        idCategoria,
                                                                        categoria,
                                                                        IdVendedor,
                                                                        vendedor,
                                                                        idTipoComprobante,
                                                                        idCaja,
                                                                        idZonaGeografica,
                                                                        idCobrador,
                                                                        cobrador,
                                                                        actual.NivelAutorizacion)
      If incluirFecha Then
         For i As Integer = 0 To Convert.ToInt32(hasta.Subtract(desde).TotalDays - 1)
            Dim fecha As Date = desde.AddDays(i)
            If dt.Select(String.Format("Fecha = '{0}'", fecha)).Length = 0 Then
               Dim dr As DataRow = dt.NewRow()
               dr("Fecha") = fecha
               For Each dc As DataColumn In dt.Columns
                  If dc.DataType.Equals(GetType(Decimal)) Then
                     dr(dc.ColumnName) = 0
                  End If
               Next
               Dim index As Integer = 0
               Dim drCol As DataRow() = dt.Select(String.Format("Fecha = '{0}'", fecha.AddDays(-1)))
               If drCol.Length > 0 Then
                  dr("Acumulado") = drCol(0)("Acumulado")
                  index = dt.Rows.IndexOf(drCol(0)) + 1
               End If
               dt.Rows.InsertAt(dr, index)
            End If
         Next
         dt.DefaultView.Sort = "Fecha"
      End If

      Return dt
   End Function


   Public Function GetRecibosAnulacion(sucursal As Integer,
                                            desde As Date,
                                            hasta As Date,
                                            idCliente As Long,
                                            idCategoria As Integer,
                                            IdVendedor As Integer,
                                            idTipoComprobante As String,
                                            idUsuario As String,
                                            idCaja As Integer,
                                            letraFiscal As String,
                                            centroEmisor As Integer,
                                            numeroComprobante As Long,
                                            idZonaGeografica As String) As DataTable

      Return New SqlServer.CuentasCorrientes(da).GetRecibosAnulacion(sucursal,
                                           desde,
                                           hasta,
                                           idCliente,
                                           idCategoria,
                                           IdVendedor,
                                           idTipoComprobante,
                                           idUsuario,
                                           idCaja,
                                           letraFiscal,
                                           centroEmisor,
                                           numeroComprobante,
                                           idZonaGeografica,
                                           actual.NivelAutorizacion)


   End Function
   Public Function GetRecibosAnulados(Sucursal As Integer,
                                       Desde As Date,
                                       Hasta As Date,
                                      IdCliente As Long) As DataTable

      Return New SqlServer.CuentasCorrientes(da).GetRecibosAnulados(Sucursal,
                                                                    Desde,
                                                                    Hasta,
                                                                    IdCliente,
                                                                    actual.NivelAutorizacion)
   End Function

   Friend Sub ActualizaSaldo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long, importeAplicado As Decimal)
      Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)
      sql.CuentasCorrientes_AplicaAlSaldo(idSucursal,
                                          idTipoComprobante,
                                          letra,
                                          centroEmisor,
                                          numeroComprobante,
                                          importeAplicado)
   End Sub

   Public Function GetTodos() As List(Of Entidades.CuentaCorriente)
      Dim stb = New StringBuilder()
      SelectFiltrado(stb)
      Dim dt As DataTable = da.GetDataTable(stb.ToString())
      Dim o As Entidades.CuentaCorriente
      Dim oLis As List(Of Entidades.CuentaCorriente) = New List(Of Entidades.CuentaCorriente)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CuentaCorriente()
         CargarUna(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Entidades.CuentaCorriente
      Return EjecutaConConexion(Function() _GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
   End Function

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectFiltrado(stb)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With
      Return da.GetDataTable(stb.ToString())
   End Function

   Public Function _GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Entidades.CuentaCorriente
      Return _GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function _GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                           accion As AccionesSiNoExisteRegistro) As Entidades.CuentaCorriente
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                          Sub(o, dr) CargarUna(dr, o), Function() New Entidades.CuentaCorriente(),
                          accion, Function() String.Format("No existe el Comprobante {0} {1} {2} {3:0000}-{4:00000000} en Cuenta Corriente.", idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
   End Function

   Public Function GetComprobantesCtaCte() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT IdTipoComprobante ")
         .AppendFormatLine("  FROM CuentasCorrientes ")
         '.Append("  WHERE IdSucursal = " & Sucursal.ToString())
      End With

      Return da.GetDataTable(stb.ToString())
   End Function

   Public Function GetSaldoClientes(suc As List(Of Integer)) As DataTable
      Return EjecutaConTransaccion(Function() New SqlServer.CuentasCorrientes(da).GetSaldoClientes(suc))
   End Function

   Public Function GetPagos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Return EjecutaConTransaccion(Function() New SqlServer.CuentasCorrientes(da).GetPagos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
   End Function

   Public Function GetMovEliminar(idSucursal As Integer,
                                  desde As Date, hasta As Date,
                                  idVendedor As Integer, idCliente As Long,
                                  idTipoComprobante As String, idZonaGeografica As String,
                                  idCategoria As Integer, grabaLibro As Entidades.Publicos.SiNoTodos) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.CuentasCorrientes(da).
                                      GetMovEliminar(idSucursal, desde, hasta, idVendedor, idCliente, idTipoComprobante, idZonaGeografica, idCategoria, grabaLibro))
   End Function

   Public Function GetCtaCte(idSucursal As Integer,
                             desde As Date, hasta As Date,
                             idVendedor As Integer,
                             idCliente As Long,
                             listaComprobantes As List(Of Entidades.TipoComprobante),
                             saldo As String,
                             idZonaGeografica As String,
                             idCategoria As Integer,
                             grabaLibro As String,
                             grupos As Entidades.Grupo(),
                             excluirSaldosNegativos As String, excluirAnticipos As String, excluirPreComprobantes As String,
                             idProvincia As String,
                             categoria As String,
                             vendedor As String,
                             excluirMinutas As String,
                             sucursales As Entidades.Sucursal(),
                             agruparIdClienteCtaCte As Boolean,
                             ruta As Integer,
                             dia As Entidades.Publicos.Dias?,
                             idReserva As Integer) As DataTable

      Return New SqlServer.CuentasCorrientes(da).GetCtaCte(idSucursal,
                                                           desde, hasta,
                                                           idVendedor,
                                                           idCliente,
                                                           listaComprobantes,
                                                           saldo,
                                                           idZonaGeografica,
                                                           idCategoria,
                                                           grabaLibro,
                                                           grupos,
                                                           excluirSaldosNegativos, excluirAnticipos, excluirPreComprobantes,
                                                           idProvincia,
                                                           categoria,
                                                           vendedor,
                                                           excluirMinutas,
                                                           sucursales,
                                                           agruparIdClienteCtaCte,
                                                           actual.NivelAutorizacion,
                                                           ruta,
                                                           dia,
                                                           idReserva)

   End Function

   Public Function GetCtaCtePendientesPorProducto(
                        idSucursal As Integer,
                        desde As Date, hasta As Date,
                        idVendedor As Integer, idCliente As Long,
                        listaComprobantes As List(Of Entidades.TipoComprobante), saldo As String,
                        idZonaGeografica As String, idCategoria As Integer,
                        grabaLibro As String, grupos As Entidades.Grupo(),
                        excluirSaldosNegativos As String, excluirAnticipos As String, excluirPreComprobantes As String,
                        idProvincia As String, categoria As String, vendedor As String, excluirMinutas As String,
                        sucursales As Entidades.Sucursal()) As DataTable
      Return New SqlServer.CuentasCorrientes(da).GetCtaCtePendientesPorProducto(
                              idSucursal,
                              desde, hasta,
                              idVendedor, idCliente,
                              listaComprobantes, saldo,
                              idZonaGeografica, idCategoria,
                              grabaLibro, grupos,
                              excluirSaldosNegativos, excluirAnticipos, excluirPreComprobantes,
                              idProvincia, categoria, vendedor, excluirMinutas,
                              sucursales,
                              actual.NivelAutorizacion)
   End Function

   Public Function GetCtaCteMutual(idSucursal As Integer,
                         desde As Date, hasta As Date,
                         idVendedor As Integer,
                         idCliente As Long,
                         listaComprobantes As List(Of Entidades.TipoComprobante),
                         saldo As String,
                         idZonaGeografica As String,
                         idCategoria As Integer,
                         grabaLibro As String,
                         grupo As String,
                         excluirSaldosNegativos As String,
                         excluirAnticipos As String,
                         ByRef ExcluirPreComprobantes As String,
                         idProvincia As String,
                         categoria As String,
                         vendedor As String,
                         excluirMinutas As String,
                         sucursales As Entidades.Sucursal()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("      ,C.IdVendedor")
         Else
            .AppendLine("      ,CC.IdVendedor")
         End If
         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreCliente +  ' ( ' + CONVERT(varchar(20), C.CodigoCliente)  + ' ) ' +  C.Direccion + ' - ' + L.NombreLocalidad + ' - ' + P.NombreProvincia + (CASE WHEN C.Cuit IS NULL THEN '' ELSE ' - ' + C.Cuit END) + ' - Tel: ' +(CASE WHEN C.Telefono IS NULL THEN '' ELSE ' - ' + C.Telefono END)  + ' ' + (CASE WHEN C.Celular IS NULL THEN '' ELSE ' - ' + C.Celular END) + (CASE WHEN C.CorreoElectronico IS NULL THEN '' ELSE ' - ' + C.CorreoElectronico END)  + (CASE WHEN T.NombreTransportista IS NULL THEN '' ELSE ' - ' + T.NombreTransportista  END) AS NombreCliente2")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,LTRIM(TC.Descripcion) AS DescripcionTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CC.FechaVencimiento")
         .AppendLine("      ,CC.ImporteTotal")
         .AppendLine("      ,CC.Saldo")
         .AppendLine("      ,CC.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")
         .AppendLine("      ,CC.Observacion")
         .AppendLine("      ,CC.Referencia")
         .AppendLine("      ,I.TipoImpresora")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,CC.IdEjercicio")
         .AppendLine("      ,CC.IdPlanCuenta")
         .AppendLine("      ,CC.IdAsiento")
         .AppendLine("      ,CONVERT(decimal(12,2), CC.Saldo * dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CC.Fecha, CC.FechaVencimiento, GETDATE(), CC.ImporteTotal, CC.Saldo) / 100) AS Interes")

         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CC.IdClienteCtaCte END IdClienteCtaCte")
         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.CodigoCliente END CodigoClienteCtaCte")
         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.NombreCliente END NombreClienteCtaCte")

         .AppendLine("  FROM CuentasCorrientes CC")

         .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("   LEFT JOIN Clientes CCC ON CC.IdClienteCtaCte = CCC.IdCliente")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("  INNER JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If


         'Los Comprobantes Fictision pueden tener cualquier Emisor.
         .AppendLine(" LEFT OUTER JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal = " & idSucursal.ToString())
         '------------------

         .AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")
         '.AppendLine(" INNER JOIN TiposComprobantes tp ON CC.IdTipoComprobante = tp.IdTipoComprobante")
         '.AppendLine(" LEFT JOIN Ventas V ON V.IdSucursal = CC.IdSucursal")
         '.AppendLine(" AND V.IdTipoComprobante = CC.IdTipoComprobante")
         '.AppendLine(" AND V.Letra = CC.Letra")
         '.AppendLine(" AND V.CentroEmisor = CC.CentroEmisor")
         '.AppendLine(" AND V.NumeroComprobante = CC.NumeroComprobante ")

         .AppendLine("  WHERE 1=1")

         'TODO:
         If sucursales Is Nothing Then
            .AppendLine(" AND CC.IdSucursal = " & idSucursal.ToString())
         Else
            SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "CC")
         End If


         If desde.Year > 1 Then
            '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("  AND CC.Fecha <= Format(" & CDate(desde) & ",'yyyy-MM-dd')")
            '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")
            .AppendLine("  AND CC.Fecha <= Format(" & CDate(hasta) & ",'yyyy-MM-dd')")
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         'If Categoria <> "MOVIMIENTO" Then
         '   .AppendLine(" AND C.IdCategoria = CC.IdCategoria")
         'End If

         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendLine("	AND TC.EsAnticipo = 'False'")

         .AppendLine("  AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")

         If listaComprobantes IsNot Nothing AndAlso listaComprobantes.Count > 0 Then
            .Append(" AND CC.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               .AppendFormat(" '{0}',", tc.IdTipoComprobante)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If



         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If saldo <> "TODOS" Then
            .AppendLine("   AND CC.Saldo <> 0 ")
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If excluirSaldosNegativos = "SI" Then
            .AppendLine("   AND CC.Saldo > 0 ")
         End If

         'El RECIBO tiene el saldo.
         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsRecibo = 'False'")
         End If

         If ExcluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If

         .AppendLine(" ORDER BY E.NombreEmpleado ")
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("   ,C.IdVendedor ")
         Else
            .AppendLine("   ,CC.IdVendedor ")
         End If

         .AppendLine("   ,C.NombreCliente ")
         .AppendLine("   ,CC.IdCliente ")
         .AppendLine("   ,ZG.NombreZonaGeografica")
         .AppendLine("   ,CC.Fecha")
         '.AppendLine("   ,CC.IdTipoComprobante")   'La Fecha tiene hora, Minutos y segundos.
         '.AppendLine("   ,CC.Letra")
         '.AppendLine("   ,CC.CentroEmisor")
         '.AppendLine("   ,CC.NumeroComprobante")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetComprobantesCtaCteFecha(idSucursal As Integer,
                                              hasta As Date,
                                              IdVendedor As Integer,
                                              idCliente As Long,
                                              idTipoComprobante As String,
                                              idZonaGeografica As String,
                                              idCategoria As Integer,
                                              grabaLibro As String,
                                              grupo As String,
                                              excluirAnticipos As String,
                                              excluirPreComprobantes As String,
                                              idProvincia As String,
                                              categoria As String,
                                              listaFormaDePago As Entidades.VentaFormaPago()) As DataTable

      Return New SqlServer.CuentasCorrientes(da).GetComprobantesCtaCteFecha(idSucursal,
                                                                            hasta,
                                                                            IdVendedor,
                                                                            idCliente,
                                                                            idTipoComprobante,
                                                                            idZonaGeografica,
                                                                            idCategoria,
                                                                            grabaLibro,
                                                                            grupo,
                                                                            excluirAnticipos,
                                                                            excluirPreComprobantes,
                                                                            idProvincia,
                                                                            categoria,
                                                                            listaFormaDePago)

   End Function

   Public Function GetSaldoParaMinutas(idSucursal As Integer, tipoComprobante As Entidades.TipoComprobante, grupo As String,
                                       fechaDesde As Date?, fechaHasta As Date?,
                                       numeroOrdenCompra As Long) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.CuentasCorrientes(da).
                                   GetSaldosParaMinutas(idSucursal, tipoComprobante.ComprobantesAsociados, grupo, fechaDesde, fechaHasta, numeroOrdenCompra))
   End Function

   Public Function GetAcuerdosRealizados(Sucursales As Entidades.Sucursal(), fechaDesde As Date?, fechaHasta As Date?) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.CuentasCorrientes(da).GetAcuerdosRealizados(Sucursales, fechaDesde, fechaHasta))
   End Function

   Private Function GetAlgunosComprobantesPorCliente(idSucursal As Integer, idCliente As Long, algunosComprobantes As String, grupo As String,
                                                     fechaDesde As Date?, fechaHasta As Date?,
                                                     numeroOrdenCompra As Long) As List(Of Entidades.CuentaCorrientePago)
      Dim cc As Entidades.CuentaCorrientePago
      Dim lis = New List(Of Entidades.CuentaCorrientePago)()

      Dim sql = New SqlServer.CuentasCorrientes(da)
      Using dt As DataTable = sql.GetAlgunosComprobantesPorCliente(idSucursal, idCliente, algunosComprobantes, grupo, fechaDesde, fechaHasta, numeroOrdenCompra)
         For Each dr As DataRow In dt.Rows
            cc = New Reglas.CuentasCorrientesPagos().GetUna(dr.ValorNumericoPorDefecto("IdSucursal", 0I),
                                                            dr("IdTipoComprobante").ToString(),
                                                            dr("Letra").ToString(),
                                                            dr.ValorNumericoPorDefecto("CentroEmisor", 0S),
                                                            dr.ValorNumericoPorDefecto("NumeroComprobante", 0L),
                                                            dr.ValorNumericoPorDefecto("CuotaNumero", 0I))

            lis.Add(cc)
         Next
      End Using

      Return lis
   End Function

   Public Function GetTarjetasRecibos(idSucursal As Integer,
                                      idCaja As Integer,
                                      desde As Date, hasta As Date,
                                      grabaLibro As String,
                                      idCliente As Long,
                                      idTipoComprobante As String,
                                      numeroCupon As Long,
                                      idUsuario As String,
                                      idBanco As Integer,
                                      idCuentaBancaria As Integer,
                                      idVendedor As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdTipoComprobante ")
         .AppendLine(" ,TC.DescripcionAbrev")
         .AppendLine(" ,CC.Letra ")
         .AppendLine(" ,CC.CentroEmisor")
         .AppendLine(" ,CC.NumeroComprobante")
         .AppendLine(" ,CC.Fecha")
         .AppendLine(" ,CC.IdCliente")
         .AppendLine(" ,C.CodigoCliente")
         .AppendLine(" ,C.NombreCliente")
         .AppendLine(" ,CN.NombreCaja")
         .AppendLine(" ,CCT.IdTarjeta")
         .AppendLine(" ,T.NombreTarjeta")
         .AppendLine(" ,CCT.IdBanco")
         .AppendLine(" ,B.NombreBanco")
         .AppendLine(" ,CCT.Cuotas")
         .AppendLine(" ,CCT.NumeroCupon")
         .AppendLine(" ,CCT.Monto")
         .AppendLine(" ,CC.IdUsuario")
         .AppendLine(" ,T.IdCuentaBancaria")
         .AppendLine(" ,CB.NombreCuenta")
         .AppendLine(" FROM CuentasCorrientes CC")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine(" INNER JOIN CuentasCorrientesTarjetas CCT ON CCT.IdSucursal = CC.IdSucursal")
         .AppendLine("        AND CCT.IdTipoComprobante = CC.IdTipoComprobante AND CCT.Letra = CC.Letra AND CCT.CentroEmisor = CC.CentroEmisor AND CCT.NumeroComprobante = CC.NumeroComprobante")
         .AppendLine(" INNER JOIN Tarjetas T ON T.IdTarjeta = CCT.IdTarjeta")
         .AppendLine(" INNER JOIN Bancos B ON B.IdBanco = CCT.IdBanco")
         .AppendLine(" INNER JOIN CajasNombres CN ON CN.IdSucursal = CC.IdSucursal AND CN.IdCaja = CC.IdCaja")
         .AppendLine(" LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = T.IdCuentaBancaria")

         .AppendLine(" WHERE CC.IdSucursal = " & idSucursal)

         If idCaja > 0 Then
            .AppendLine("   AND CC.IdCaja = " & idCaja.ToString())
         End If

         If desde > Date.Parse("01/01/1990") Then
            .AppendFormat("	 AND CC.fecha >= '{0}'", desde.ToString("yyyyMMdd HH:mm:ss"))
            .AppendFormat("	 AND CC.fecha <= '{0}'", hasta.ToString("yyyyMMdd HH:mm:ss"))
         End If

         If idCliente > 0 Then
            .Append("	AND C.IdCliente = " & idCliente)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         'If AfectaCaja <> "TODOS" Then
         '   .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         'End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	 AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If numeroCupon > 0 Then
            .AppendLine("	 AND CCT.NumeroCupon = " & numeroCupon.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND CC.IdUsuario = '" & idUsuario & "'")
         End If

         If idBanco > 0 Then
            .AppendLine("	 AND CCT.IdBanco = " & idBanco.ToString())
         End If

         If idCuentaBancaria > 0 Then
            .AppendLine("	 AND T.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If

         If idVendedor > 0 Then
            .AppendLine("	AND CC.IdVendedor = " & idVendedor)
         End If

         .AppendLine("	ORDER BY CC.Fecha")
      End With

      Return da.GetDataTable(stb.ToString())
   End Function



   Public Function GetCtaCteDebeHaber(sucursales As Entidades.Sucursal(),
                                      desde As Date?, hasta As Date?,
                                      idVendedor As Integer, vendedor As Entidades.OrigenFK,
                                      idCliente As Long,
                                      listaComprobantes As List(Of Entidades.TipoComprobante),
                                      idZonaGeografica As String,
                                      idCategoria As Integer, categoria As Entidades.OrigenFK,
                                      grabaLibro As String, grupo As String,
                                      excluirPreComprobantes As Boolean,
                                      idProvincia As String,
                                      excluirMinutas As String,
                                      agruparIdClienteCtaCte As Boolean) As DataTable

      Dim dt = New SqlServer.CuentasCorrientes(da).
                     GetCtaCteDebeHaber(sucursales,
                                        desde, hasta,
                                        idVendedor, vendedor,
                                        idCliente,
                                        listaComprobantes,
                                        idZonaGeografica,
                                        idCategoria, categoria,
                                        grabaLibro, grupo,
                                        excluirPreComprobantes,
                                        idProvincia,
                                        excluirMinutas,
                                        agruparIdClienteCtaCte)

      dt.Columns.Add("Ver", GetType(String))

      Dim ultimoIdCliente = -1L
      Dim ultimoDr As DataRow = Nothing
      Dim saldo As Decimal = 0
      For Each dr As DataRow In dt.Rows
         dr("Ver") = "..."
         Dim idClienteActual As Long = Long.Parse(dr("IdCliente").ToString())
         If ultimoIdCliente <> idClienteActual Then
            If ultimoDr IsNot Nothing Then
               ultimoDr("Saldo") = saldo
            End If
            saldo = 0
            ultimoIdCliente = idClienteActual
         End If
         Dim ImporteTotalDebe As Decimal = 0
         Dim ImporteTotalHaber As Decimal = 0

         If Not IsDBNull(dr("ImporteTotalDebe")) Then
            ImporteTotalDebe = Decimal.Parse(dr("ImporteTotalDebe").ToString())
         End If
         If Not IsDBNull(dr("ImporteTotalHaber")) Then
            ImporteTotalHaber = Decimal.Parse(dr("ImporteTotalHaber").ToString())
         End If

         saldo = saldo + ImporteTotalDebe - ImporteTotalHaber
         ultimoDr = dr
      Next
      If ultimoDr IsNot Nothing Then
         ultimoDr("Saldo") = saldo
      End If

      Return dt
   End Function


#End Region

#Region "Overrides"
   <Obsolete("No usar, usar Insertar(Entidad, MetodoGrabacion, String)", True)>
   Public Overrides Sub Insertar(entd As Entidades.Entidad)
      Throw New NotImplementedException("No usar, usar CuentasCorrientes.Insertar(Entidad, MetodoGrabacion, String)")
   End Sub
   Public Overloads Sub Insertar(entd As Entidades.Entidad, metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entd, Entidades.CuentaCorriente), metodoGrabacion, idFuncion))
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function ClienteDeComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return New SqlServer.CuentasCorrientes(da).ClienteDeComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

   Public Function ServicioTecnicoAsociados(idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return New SqlServer.CuentasCorrientes(da).ServicioTecnicoAsociados(idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

   Public Sub AnularRecibo(ent As Entidades.CuentaCorriente)
      EjecutaConTransaccion(Sub() _anularRecibo(ent))
   End Sub

   Public Sub _anularRecibo(ent As Entidades.CuentaCorriente)

      If Publicos.TieneModuloContabilidad Then
         Dim ctblEjercicio As ContabilidadEjercicios = New ContabilidadEjercicios(da)
         ctblEjercicio.EstaPeriodoCerrado(ent.Fecha)
      End If

      Dim ccttPag As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos(da)

      Dim ct As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()
      Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)

      Dim TipoComprobanteRecibo As String = String.Empty

      For Each ch As Entidades.Cheque In ent.Cheques
         If ent.CajaDetalle.IdCaja <> ch.IdCajaIngreso Then
            Throw New Exception("ATENCION: El Cheque " & ch.NombreBanco & "- Nro: " & ch.NumeroCheque & " no se encuentra en la caja del recibo a anular, debe moverlo a la caja original. Recibo Nro: " & ent.Letra & "-" & ent.CentroEmisor & "-" & ent.NumeroComprobante)
            Exit Sub
         End If
      Next

      Dim rCupones = New TarjetasCupones(da)
      Dim cuponesInvalidos = rCupones.GetTodos(ent).Where(Function(x) x.IdEstadoTarjeta <> Entidades.TarjetaCupon.Estados.ENCARTERA And x.IdEstadoTarjeta <> Entidades.TarjetaCupon.Estados.ACREDITADO)
      If cuponesInvalidos.AnySecure Then
         Throw New Exception("Hay cupones con estado no permitido para anular. Los estados válidos son 'ENCARTERA' o 'ACREDITADO'")
      End If

      'actualiza los saldos de los items de pago
      For Each com As Entidades.CuentaCorrientePago In ent.Pagos
         com.CuentaCorriente = ent
         'Agregado porque ahora el Saldo se carga al momento exacto del pago.
         com.SaldoCuota = com.SaldoCuota - com.Paga
         '--------------------------------------------------
         'com.Paga = com.Paga * (-1)
         ccttPag.ActualizaSaldo(com, com.Paga)

         '' ''ct = Me._GetUna(com.IdSucursal, com.IdTipoComprobante, com.Letra, com.CentroEmisor, com.NumeroComprobante)
         ' '' ''ct.Saldo = ct.Saldo - com.Paga
         '' ''Me.ActualizaSaldo(ct, com.Paga)

         Me.ActualizaSaldo(com.IdSucursal, com.IdTipoComprobante, com.Letra, Convert.ToInt16(com.CentroEmisor), com.NumeroComprobante, com.Paga)

         'Si aplico un ANTICIPO, le devuelvo ese pago al recibo (para nivelar la cuenta) que lleva el monto en el saldo. En la tabla detalle tiene otra logica.
         If com.TipoComprobante.EsAnticipo = True Then

            'Con el Anticipo tiene seteado el Tipo de Recibo que lo genera
            TipoComprobanteRecibo = com.TipoComprobante.IdTipoComprobanteSecundario

            'El Anticipo tiene el Numero del recibo que lo emitio, por eso uso sus datos.

            sql.CuentasCorrientes_AplicaAlSaldo(ent.IdSucursal, TipoComprobanteRecibo, com.Letra,
                                                com.CentroEmisor.ToShort(), com.NumeroComprobante, com.Paga)

         End If

      Next

      Dim colCheques = New Cheques(da).GetPorCuentaCorriente(ent.IdSucursal,
                                 ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                                 ent.NumeroComprobante)

      Dim Cont As Integer = 0

      For Cont = 1 To colCheques.Count
         'If colCheques.Item(Cont - 1).NroMovimientoEgreso > 0 Then
         If colCheques.Item(Cont - 1).IdEstadoCheque <> Entidades.Cheque.Estados.ENCARTERA Then
            Dim Mensaje As String
            Mensaje = "ATENCION: el Recibo tiene al menos este cheque entregado, NO puede ANULARLO..."
            'Mensaje = Mensaje & ct.TipoComprobante.IdTipoComprobante & "" & ct.Letra & "Número " & ct.NumeroComprobante & " " & ct.CentroEmisor
            'TODO: agregar al mensaje cuál es el recibo que está asociado al cheque para que el usuario pueda deseleccionarlo
            Mensaje = Mensaje & Chr(13) & Chr(13)
            Mensaje = Mensaje & "Banco: " & colCheques.Item(Cont - 1).Banco.NombreBanco & " / "
            Mensaje = Mensaje & "Suc. Bco: " & colCheques.Item(Cont - 1).IdBancoSucursal.ToString() & " / "
            Mensaje = Mensaje & "Loc. Bco: " & colCheques.Item(Cont - 1).Localidad.NombreLocalidad & " / "
            Mensaje = Mensaje & "Numero Cheq.: " & colCheques.Item(Cont - 1).NumeroCheque.ToString()

            Throw New Exception(Mensaje)
         End If
      Next

      'PE-34554 / Elimino los Cupones de las tarjetas en la tabla TarjetasCupones
      Dim rTarjCupones = New TarjetasCupones(da)
      Dim cupones = rTarjCupones.GetPorCuentaCorriente(ent)

      'Elimino los movimientos de las tarjetas en la tabla CuentasCorrientesTarjetas
      Dim rTar As Reglas.CuentasCorrientesTarjetas = New Reglas.CuentasCorrientesTarjetas(da)
      rTar._Borrar(ent)

      'PE-34554 / Elimino los Cupones de las tarjetas en la tabla TarjetasCupones
      If cupones.Count() > 0 Then
         Dim sqlVentasTarjetas = New SqlServer.VentasTarjetas(da)

         cupones.ForEach(
            Sub(c)
               sqlVentasTarjetas.VentasTarjetas_D(c.IdTarjetaCupon)
               rTarjCupones._Borrar(c)
            End Sub)
      End If

      '# Elimino las transferencias realizadas (en caso de que tenga) de la tabla CuentasCorrientesTransferencias
      Dim rCCTransferencias As New Reglas.CuentasCorrientesTransferencias(da)
      If ent.CCTransferencias.Count > 0 Then
         rCCTransferencias._Borra(New Entidades.CuentaCorrienteTransferencia With {.IdSucursal = ent.IdSucursal,
                                                                                   .IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante,
                                                                                   .Letra = ent.Letra,
                                                                                   .CentroEmisor = ent.CentroEmisor,
                                                                                   .NumeroComprobante = ent.NumeroComprobante,
                                                                                   .Orden = 0}) '# Paso 0 como Nro. de Orden para eliminar todas las transferencias vinculadas
      End If
      '----------------------------------------------------------------------------------------------

      Dim colRetenciones As List(Of Entidades.Retencion)

      colRetenciones = New Reglas.Retenciones(da).GetPorCuentaCorriente(ent.IdSucursal,
                                                                           ent.TipoComprobante.IdTipoComprobante,
                                                                           ent.Letra,
                                                                           ent.CentroEmisor,
                                                                           ent.NumeroComprobante,
                                                                           ent.Cliente.IdCliente)

      'Dim Cont As Integer = 0

      For Cont = 1 To colRetenciones.Count
         If colRetenciones.Item(Cont - 1).IdEstado <> Entidades.Retencion.Estados.APLICADO Then   'Por ahora no va a hacer nada.. no se toca el ESTADO
            Dim Mensaje As String
            Mensaje = "ATENCION: el Recibo tiene al menos esta Retencion usada, NO puede ANULARLO..."
            Mensaje = Mensaje & Chr(13) & Chr(13)
            Mensaje = Mensaje & "Tipo Impuesto: " & colRetenciones.Item(Cont - 1).TipoImpuesto.NombreTipoImpuesto & " / "
            Mensaje = Mensaje & "Emisor: " & colRetenciones.Item(Cont - 1).EmisorRetencion.ToString() & " / "
            Mensaje = Mensaje & "Numero: " & colRetenciones.Item(Cont - 1).NumeroRetencion.ToString()

            Throw New Exception(Mensaje)
         End If
      Next

      '----------------------------------------------------------------------------------------------


      'si el cliente compro el modulo de caja registro la anulacion en caja
      If Publicos.TieneModuloCaja Then
         Dim deta As Eniac.Entidades.CajaDetalles = New Eniac.Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
         Dim caj As Eniac.Reglas.Cajas = New Eniac.Reglas.Cajas(da)
         Dim cajaDet As Eniac.Reglas.CajaDetalles = New Eniac.Reglas.CajaDetalles(da)

         With deta
            .IdSucursal = ent.IdSucursal
            .IdCaja = ent.CajaDetalle.IdCaja
            .FechaMovimiento = ent.Fecha
            .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
            If ent.ImporteTotal >= 0 Then
               .IdTipoMovimiento = "E"c
               .ImportePesos = ent.ImportePesos
            Else
               .IdTipoMovimiento = "I"c
               .ImportePesos = ent.ImportePesos * -1
            End If
            .ImporteBancos = Math.Abs(ent.ImporteTransfBancaria)
            .ImporteCheques = ent.ImporteCheques
            .ImporteTickets = ent.ImporteTickets
            .ImporteTarjetas = ent.ImporteTarjetas
            .ImporteRetenciones = ent.ImporteRetenciones
            .ImporteDolares = ent.ImporteDolares
            .CotizacionDolar = ent.CotizacionDolar
            .IdMonedaImporteBancos = ent.CuentaBancariaTransfBanc.Moneda.IdMoneda
            .Observacion = String.Format("ANULA {0} {1} {2}-{3:00000000}{4}{5}", ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, If(ent.Cheques.Count > 0, String.Format(" - Cantidad Cheques: {0}", ent.Cheques.Count), ""), If(ent.ImporteTransfBancaria <> 0, String.Format(" - Transf. a cuenta: {0}", ent.CuentaBancariaTransfBanc.NombreCuenta), "")).Truncar(100)
            .IdCuentaCaja = Publicos.CtaCajaRecibos
            .EsModificable = False
            .GeneraContabilidad = False
         End With

         cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(ent.Cheques), Nothing)

         'Si Pagó parte con Transfencia Bancaria
         'If ent.ImporteTransfBancaria <> 0 Then

         '   With deta
         '      .FechaMovimiento = ent.Fecha     'Date.Now
         '      .IdSucursal = ent.IdSucursal
         '      If ent.ImporteTransfBancaria > 0 Then
         '         .IdTipoMovimiento = "I"c
         '      Else
         '         .IdTipoMovimiento = "E"c
         '      End If
         '      .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
         '      .ImportePesos = Math.Abs(ent.ImporteTransfBancaria)
         '      .ImporteCheques = 0
         '      .ImporteTickets = 0
         '      .ImporteTarjetas = 0
         '      .Observacion = Strings.Left("ANULA " & ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " - Transf. desde: " & ent.CuentaBancariaTransfBanc.NombreCuenta & ". " & ent.Cliente.NombreCliente, 100)
         '      .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJATRANSFBANCARIA))
         '      .EsModificable = False
         '   End With

         '   cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

         'End If

         Dim TarjetasAcreditar As Decimal

         For Each tr As Entidades.VentaTarjeta In ent.Tarjetas
            If tr.Tarjeta.Acreditacion Then
               TarjetasAcreditar = TarjetasAcreditar + tr.Monto
            End If
         Next

         If TarjetasAcreditar > 0 AndAlso ent.ImporteTarjetas > 0 Then

            With deta
               .FechaMovimiento = ent.Fecha
               .IdSucursal = ent.IdSucursal
               .IdTipoMovimiento = "I"c
               .IdCaja = ent.CajaDetalle.IdCaja
               .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
               .ImportePesos = 0
               .ImporteCheques = 0
               .ImporteTickets = 0
               If TarjetasAcreditar > 0 Then
                  .ImporteTarjetas = TarjetasAcreditar
               Else
                  .ImporteTarjetas = ent.ImporteTarjetas
               End If
               .Observacion = Strings.Left("ANULA " & ent.TipoComprobante.DescripcionAbrev & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " -Deposito de Tarjeta Crédito de: " & ent.Cliente.NombreCliente, 100)
               .IdCuentaCaja = Publicos.CtaCajaDepositoTarjetas
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
            End With

            cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

         End If

         'Retenciones en Caja

         My.Application.Log.WriteEntry("Grabo las retenciones del Recibo.", TraceEventType.Verbose)
         For Each ret As Entidades.Retencion In ent.Retenciones
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
               .Observacion = Strings.Left("ANULA " & ent.TipoComprobante.Descripcion & " " & ent.Letra & " " & ent.CentroEmisor.ToString() & "-" & ent.NumeroComprobante.ToString("00000000") & " - " & ent.Cliente.NombreCliente & " - Retención: " & ret.NombreTipoImpuesto, 100)
               .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.TiposImpuestos(da)._GetUno(ret.IdTipoImpuesto).IdCuentaCaja.ToString())
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
            End With

            cajaDet.AgregaMovimiento(deta, Nothing, Nothing)
         Next

      End If

      Dim oCheques As Reglas.Cheques = New Reglas.Cheques(da)
      Dim ctacteCheque As Reglas.CuentasCorrientesCheques = New Reglas.CuentasCorrientesCheques(da)

      ctacteCheque.Eliminar(ent)

      'puede existir el caso que el cheque se cargue en la factura y a cta. cte.
      'en ese caso tenemos que eliminar el cheque de la relacion VentasCheques
      'SiSeN y SiLIVE generan ctacte en automático, pero en estos casos las facturas por lo general
      'nunca son a ctacte con pago parcial (son siempre a ctacte y ya). Por eso se toma para esta
      'reversión solo los recibos automáticos y, por las dudas, solo los que tienen un solo comprobante,
      'de esa manera achicamos el margen de posible error.
      'Me fijo si es Automático porque ese MetodoGrabación se graba cuando se genera desde Venta y
      '  me fijo que tenga solo un comprobante (porque si ya tiene más de uno no vino de venta).
      For Each cheq As Entidades.Cheque In ent.Cheques
         If ent.MetodoGrabacionCampo = Entidades.Entidad.MetodoGrabacion.Automatico AndAlso ent.Pagos.Count = 1 Then
            Dim sqlVtaChe As SqlServer.VentasCheques = New SqlServer.VentasCheques(da)
            Dim sqlVta As SqlServer.Ventas = New SqlServer.Ventas(da)
            cheq.IdSucursal = ent.IdSucursal

            Dim pago = ent.Pagos(0)
            Dim dtVtaChe As DataTable
            'Verifico que el comprobante dado tiene el cheque en cuestión.
            dtVtaChe = sqlVtaChe.VentasCheques_G1(pago.IdSucursal, pago.IdTipoComprobante, pago.Letra,
                                                  pago.CentroEmisor, pago.NumeroComprobante,
                                                  cheq.IdCheque)
            If dtVtaChe.Rows.Count > 0 Then
               sqlVtaChe.VentasCheques_D(pago.IdSucursal,
                                         pago.IdTipoComprobante,
                                         pago.Letra,
                                         pago.CentroEmisor,
                                         pago.NumeroComprobante,
                                         cheq.IdCheque)
            End If
            'Anulo los valores de ImportePesos y otros.
            sqlVta.AnulaImportesCtaCteConPagoParcial(pago.IdSucursal,
                                                     pago.IdTipoComprobante,
                                                     pago.Letra,
                                                     pago.CentroEmisor,
                                                     pago.NumeroComprobante)

         End If
         oCheques.EjecutaSP(cheq, TipoSP._D)
      Next

      Dim grabaLibro As Boolean? = Nothing
      If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then grabaLibro = ent.TipoComprobante.GrabaLibro
      sql.CuentasCorrientes_UImprimeSaldos(ent.Cliente.IdCliente, ent.TipoComprobante.Grupo, grabaLibro, ent.Fecha, imprimeSaldos:=False)

      Dim oRetenciones As Reglas.Retenciones = New Reglas.Retenciones(da)
      Dim ctacteRetencion As Reglas.CuentasCorrientesRetenciones = New Reglas.CuentasCorrientesRetenciones(da)

      ctacteRetencion.Eliminar(ent)

      Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)

      For Each ret As Entidades.Retencion In ent.Retenciones
         'cheq.IdSucursal = ent.IdSucursal
         oRetenciones._Borrar(ret)

         If ret.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.RIVA Then
            oPF.ActualizarPosicion(actual.Sucursal.IdEmpresa, Integer.Parse(ret.FechaEmision.ToString("yyyyMM")), 0, 0, 0, 0, 0, 0, ret.ImporteTotal * (-1), 0)
         End If

      Next


      'si el Cliente compro el modulo de Banco registro el movimiento de Cheques Propios entregados

      If Publicos.TieneModuloBanco Then

         Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos(da)
         Dim entLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         Dim oLibBanco As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)

         'Si Pagó parte con Transfencia Bancaria
         If ent.ImporteTransfBancaria <> 0 Then

            For Each transfer As Entidades.CuentaCorrienteTransferencia In ent.CCTransferencias
               With transfer
                  With entLibroBanco
                     .IdSucursal = ent.IdSucursal
                     .IdCuentaBancaria = transfer.IdCuentaBancaria ' ent.CuentaBancariaTransfBanc.IdCuentaBancaria
                     .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                     .IdCuentaBanco = Publicos.CtaBancoTransfBancaria
                     If ent.ImporteTransfBancaria > 0 Then
                        .IdTipoMovimiento = "E"
                     Else
                        .IdTipoMovimiento = "I"
                     End If
                     .Importe = transfer.Importe
                     .FechaMovimiento = ent.Fecha
                     .IdCheque = Nothing
                     .FechaAplicado = ent.Fecha
                     '.Observacion = ent.Observacion
                     .Observacion = String.Format("ANULA {0} {1} {2}-{3:00000000} - Transf. a Caja. {4}",
                                                  ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Cliente.NombreCliente).Truncar(100)
                     .Conciliado = False
                  End With

                  oLibroBancos.AgregaMovimiento(entLibroBanco)
               End With
            Next

         End If

      End If

      If Not ent.TipoComprobante.EsReciboClienteVinculado Then
         'Si genero un Anticipo, sera borrado.
         Dim sql2 As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

         TipoComprobanteRecibo = ent.TipoComprobante.IdTipoComprobanteSecundario

         sql2.CuentasCorrientesPagos_D(ent.IdSucursal, TipoComprobanteRecibo, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

         sql.CuentasCorrientes_D(ent.IdSucursal, TipoComprobanteRecibo, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)
      End If

      ent.IdEstado = "ANULADO"
      Me.AnulaCuentaCorriente(ent)

      '-- REQ-31710.- --------------------
      If ent.NumeroNovedad.HasValue Then
         '-- Llamo a la regla para que actualice el anticipo.- --
         Dim rNovedad = New Reglas.CRMNovedades(da)
         rNovedad.ActualizaAnticipos(ent.IdTipoNovedad, ent.LetraNovedad, ent.CentroEmisorNovedad.IfNull, ent.NumeroNovedad.IfNull, (ent.ImporteTotal * ent.TipoComprobante.CoeficienteValores))
      End If
      '-----------------------------------

      'If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea AndAlso
      If Publicos.TieneModuloContabilidad AndAlso
         ent.IdEjercicio.HasValue AndAlso ent.IdPlanCuenta.HasValue AndAlso ent.IdAsiento.HasValue Then
         Dim ctbl As Contabilidad = New Contabilidad(da)
         ctbl.AnularAsiento(ent.IdEjercicio.Value, ent.IdPlanCuenta.Value, ent.IdAsiento.Value, Today)
      End If

   End Sub

   Public Function Existe(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Short,
                          numeroComprobante As Long) As Boolean
      Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)
      Dim existeTC As Boolean = sql.Existe(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      'Anulo la validación porque se loquea la búsqueda. Ver si son diferentes conexiones o es otro el problema.
      ' ''Si no existe el comprobante a grabar
      ''If Not existeTC Then
      ''   'Busco numeradores relacionados a este numerador.
      ''   'Por ejemplo NDEBCHEQRECH puede estar relacionado a FACT,NCRED,NDEB y debería controlar que no se haya generado
      ''   'un comprobante también con esos tipos de comprobante
      ''   Dim dtTC As DataTable = New SqlServer.VentasNumeros(da).VentasNumeros_G1(idTipoComprobante, letra, centroEmisor)
      ''   If dtTC.Rows.Count > 0 Then
      ''      For Each idTipoComprobanteRelacionado As String In dtTC(0)("IdTipoComprobanteRelacionado").ToString()
      ''         'Para cada tipo de comprobante relacionado (si no está en blanco) verifico si existe o no en ventas
      ''         If Not String.IsNullOrWhiteSpace(idTipoComprobanteRelacionado) Then
      ''            existeTC = sql.Existe(idSucursal, idTipoComprobanteRelacionado, letra, centroEmisor, numeroComprobante)
      ''            'Si lo encontré con este tipo de comprobante relacionado salgo 
      ''            'del FOR para que no me cambie el valor si hay otro relacionado.
      ''            If existeTC Then Exit For
      ''         End If
      ''      Next
      ''   End If
      ''End If

      Return existeTC
   End Function

   Public Sub GrabaCtaCteDominios(CC As Entidades.CuentaCorriente, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String, deudas As DataTable)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim ctacte As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)
         Dim ClientesDeudas As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(da)
         Dim SqlCRM As SqlServer.CRMNovedades = New SqlServer.CRMNovedades(da)
         Dim id As Long = 0

         CC.FechaActualizacion = Date.Now()

         Dim imprimeSaldos As Boolean? = Nothing
         If CC.TipoComprobante.EsRecibo Then
            imprimeSaldos = True
            CC.ImprimeSaldos = True
         End If

         ctacte.CuentasCorrientes_I(CC.IdSucursal, CC.TipoComprobante.IdTipoComprobante,
                                    CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, CC.Fecha,
                                    CC.FechaVencimiento, CC.ImporteTotal, CC.Cliente.IdCliente,
                                    CC.Vendedor.IdEmpleado,
                                    CC.FormaPago.IdFormasPago, CC.Observacion,
                                    CC.Saldo, CC.CantidadCuotas, CC.ImportePesos, CC.ImporteDolares,
                                    CC.ImporteTickets, CC.ImporteTarjetas, CC.ImporteCheques,
                                    CC.ImporteTransfBancaria, CC.CuentaBancariaTransfBanc.IdCuentaBancaria,
                                    CC.ImporteRetenciones, CC.Usuario, CC.IdEstado, CC.FechaActualizacion, CC.IdClienteCtaCte,
                                    CC.IdCategoria, CC.SaldoCtaCte, MetodoGrabacion, IdFuncion, imprimeSaldos, CC.Cobrador.IdEmpleado,
                                    CC.EstadoCliente.IdEstadoCliente,
                                    CC.NumeroOrdenCompra, CC.Referencia,
                                    CC.IdSucursalVinculado, CC.IdTipoComprobanteVinculado, CC.LetraVinculado, CC.CentroEmisorVinculado, CC.NumeroComprobanteVinculado,
                                    CC.CotizacionDolar, CC.FechaTransferencia, CC.FechaExportacion, CC.Direccion, CC.IdLocalidad, CC.NumeroReparto,
                                    idtipoNovedad:=Nothing, letraNovedad:=Nothing, centroEmisorNovedad:=Nothing, numeroNovedad:=Nothing, CC.IdEmbarcacion, CC.FechaCalculoInteresModif, CC.FechaCalculoInteres,
                                    CC.IdCama, CC.FechaPromedioCobro, CC.PromedioDiasCobro, CC.CantidadDiasCobro)

         Dim tipo2 As String = Nothing
         Dim letra2 As String = Nothing
         Dim cuota2 As Integer = 0
         Dim comprobante2 As Long = 0
         Dim emisor2 As Integer = 0

         Dim ctactepag As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

         tipo2 = CC.TipoComprobante.IdTipoComprobante
         letra2 = CC.Letra
         emisor2 = CC.CentroEmisor
         comprobante2 = CC.NumeroComprobante
         cuota2 = 1

         For Each cuota As Entidades.CuentaCorrientePago In CC.Pagos
            If cuota.ImporteCuota <> cuota.ImporteCapital + cuota.ImporteInteres Then
               If cuota.ImporteCapital = 0 Then
                  cuota.ImporteCapital = cuota.ImporteCuota
               ElseIf cuota.ImporteCapital <> 0 And cuota.ImporteInteres = 0 Then
                  cuota.ImporteInteres = cuota.ImporteCuota - cuota.ImporteCapital
               End If
            End If

            ctactepag.CuentasCorrientesPagos_I(CC.IdSucursal, CC.TipoComprobante.IdTipoComprobante,
                                                   CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, cuota.Cuota,
                                                   CC.Fecha, cuota.FechaVencimiento, cuota.ImporteCuota, cuota.SaldoCuota,
                                                   CC.FormaPago.IdFormasPago, CC.Observacion,
                                                   tipo2, comprobante2, emisor2, cuota2, letra2, 0, 0,
                                                   cuota.ImporteCapital, cuota.ImporteInteres, cuota.FechaVencimiento2, cuota.ImporteCuota2,
                                                   cuota.FechaVencimiento3, cuota.ImporteCuota3, cuota.FechaVencimiento4, cuota.ImporteCuota4,
                                                   cuota.FechaVencimiento5, cuota.ImporteCuota5, cuota.CodigoDeBarra, cuota.ReferenciaCuota,
                                                   cuota.IdEmbarcacion, cuota.IdCama, cuota.CodigoDeBarraSirplus, cuota.FechaPromedioCobro, cuota.PromedioDiasCobro, cuota.CantidadDiasCobro)

            '---------GENERACION DE LAS ALERTAS

            '    Dim offset As Integer = Integer.Parse(New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.ALERTAPROMESAONLINE.ToString))
            ' Dim alertaId As Long = sqlAler.GetProximoId()

            'sqlAler.Alertas_I(alertaId, Alerta.Vencimiento.AddDays(offset), msj, False, en.IdDato, False, tipoPromesa)



         Next

         For Each dr As DataRow In deudas.Rows
            If Not String.IsNullOrEmpty(dr("ImporteAcordado").ToString()) Then
               ClientesDeudas.ClientesDeudas_UCtaCte(CC, Long.Parse(dr("nro_prestamo").ToString()), Decimal.Parse(dr("ImporteAcordado").ToString()))
            End If
         Next

         '---------------GENERACION DE LA GESTION
         Dim textoGestion As String = "GENERACION ACUERDO DE PAGO."
         'Dim gestionId As Long = sqlGes.GetProximoId()
         'sqlGes.Gestiones_I(gestionId, en.IdDato, DateTime.Now, en.IdUsuario, textoGestion, DateTime.Now, tipoPromesaGestion, 0, 0)

         id = SqlCRM.GetCodigoMaximo("GESTIONES", "X", 1) + 1

         Dim fechaActualizacionWeb As Date? = Nothing   'Desde la aplicación de gestión pasamos siempre NOTHING para que lo grabe SQL
         Dim nroSerieProductoPrestado As String = Nothing

         SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "GESTIONES", "X", 1, id, DateTime.Now, textoGestion, 100, 31, 100, DateTime.Now,
                                   actual.Nombre, DateTime.Now, actual.Nombre, actual.Nombre, 0, 1, CC.Cliente.IdCliente,
                                   Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False,
                                   False, Nothing, "", 0, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

         id = SqlCRM.GetCodigoMaximo("ALERTAS", "X", 1) + 1
         Dim msj As String = "ENVIAR ACUERDO de PAGO"
         SqlCRM.CRMNovedades_I(fechaActualizacionWeb, "ALERTAS", "X", 1, id, DateTime.Now.AddDays(1), msj,
                               101, 51, 101, DateTime.Now, actual.Nombre, DateTime.Now, actual.Nombre, actual.Nombre,
                               0, 2, CC.Cliente.IdCliente, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, False, False, Nothing, "", 0, Nothing, Nothing, Nothing,
                               Nothing, Nothing, Nothing, Nothing)

         da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex

      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Public Sub GrabaCtaCte(CC As Entidades.CuentaCorriente, CCP As Entidades.CuentaCorrientePago,
                          MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim ctacte As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)

         CC.FechaActualizacion = Date.Now()

         Dim imprimeSaldos As Boolean? = Nothing
         If CC.TipoComprobante.EsRecibo Then
            imprimeSaldos = True
            CC.ImprimeSaldos = True
         End If

         Publicos.GetSistema().ControlaValidezDeFecha(CC.Fecha)
         Reglas.Publicos.VerificaFechaUltimoLogin()
         ctacte.CuentasCorrientes_I(CC.IdSucursal, CC.TipoComprobante.IdTipoComprobante,
                                    CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, CC.Fecha,
                                    CC.FechaVencimiento, CC.ImporteTotal, CC.Cliente.IdCliente,
                                    CC.Vendedor.IdEmpleado,
                                    CC.FormaPago.IdFormasPago, CC.Observacion,
                                    CC.Saldo, CC.CantidadCuotas, CC.ImportePesos, CC.ImporteDolares,
                                    CC.ImporteTickets, CC.ImporteTarjetas, CC.ImporteCheques,
                                    CC.ImporteTransfBancaria, CC.CuentaBancariaTransfBanc.IdCuentaBancaria,
                                    CC.ImporteRetenciones, CC.Usuario, CC.IdEstado, CC.FechaActualizacion, CC.IdClienteCtaCte,
                                    CC.IdCategoria, CC.SaldoCtaCte, MetodoGrabacion, IdFuncion, imprimeSaldos, CC.Cobrador.IdEmpleado,
                                    CC.EstadoCliente.IdEstadoCliente,
                                    CC.NumeroOrdenCompra, CC.Referencia,
                                    CC.IdSucursalVinculado, CC.IdTipoComprobanteVinculado, CC.LetraVinculado, CC.CentroEmisorVinculado,
                                    CC.NumeroComprobanteVinculado,
                                    CC.CotizacionDolar, CC.FechaTransferencia, CC.FechaExportacion, CC.Direccion, CC.IdLocalidad, CC.NumeroReparto,
                                    idtipoNovedad:=Nothing, letraNovedad:=Nothing, centroEmisorNovedad:=Nothing, numeroNovedad:=Nothing, CC.IdEmbarcacion, CC.FechaCalculoInteresModif, CC.FechaCalculoInteres,
                                    CC.IdCama, CC.FechaPromedioCobro, CC.PromedioDiasCobro, CC.CantidadDiasCobro)

         Dim tipo2 As String = Nothing
         Dim letra2 As String = Nothing
         Dim cuota2 As Integer = 0
         Dim comprobante2 As Long = 0
         Dim emisor2 As Integer = 0

         Dim ctactepag As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

         tipo2 = CCP.CuentaCorriente.TipoComprobante.IdTipoComprobante
         letra2 = CCP.CuentaCorriente.Letra
         emisor2 = CCP.CuentaCorriente.CentroEmisor
         comprobante2 = CCP.CuentaCorriente.NumeroComprobante
         cuota2 = 1

         'En caso de que venga desde un subsistema y no se haya grabado el ImporteCapital o ImporteInteres lo corrijo
         If CCP.ImporteCuota <> CCP.ImporteCapital + CCP.ImporteInteres Then
            If CCP.ImporteCapital = 0 Then
               CCP.ImporteCapital = CCP.ImporteCuota
            ElseIf CCP.ImporteCapital <> 0 And CCP.ImporteInteres = 0 Then
               CCP.ImporteInteres = CCP.ImporteCuota - CCP.ImporteCapital
            End If
         End If

         ctactepag.CuentasCorrientesPagos_I(CCP.IdSucursal, CCP.TipoComprobante.IdTipoComprobante,
                                                CCP.Letra, CC.CentroEmisor, CCP.NumeroComprobante, CCP.Cuota,
                                                CC.Fecha, CCP.FechaVencimiento, CCP.ImporteCuota, CCP.SaldoCuota,
                                                CC.FormaPago.IdFormasPago, CC.Observacion,
                                                tipo2, comprobante2, emisor2, cuota2, letra2, 0, 0,
                                                CCP.ImporteCapital, CCP.ImporteInteres, CCP.FechaVencimiento2, CCP.ImporteCuota2,
                                                CCP.FechaVencimiento3, CCP.ImporteCuota3, CCP.FechaVencimiento4, CCP.ImporteCuota4,
                                                CCP.FechaVencimiento5, CCP.ImporteCuota5, CCP.CodigoDeBarra, CCP.ReferenciaCuota,
                                                CCP.IdEmbarcacion, CCP.IdCama, CCP.CodigoDeBarraSirplus, CCP.FechaPromedioCobro, CCP.PromedioDiasCobro, CCP.CantidadDiasCobro)

         da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex

      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Public Sub GenerarMinutas(idSucursal As Integer, saldos As DataTable, tipoComprobante As Entidades.TipoComprobante, grupo As String,
                             fechaDesde As Date?, fechaHasta As Date?, fecha As Date,
                             numeroOrdenCompra As Long,
                             MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      EjecutaConTransaccion(
         Sub()

            Dim regCli = New Clientes(da)
            'recuperar comprobantes positivos / negativos de los clientes que tienen saldo
            ' y por cada cliente con saldo recorrerlos e identificar el meno valor absoluto ------
            For Each sal As DataRow In saldos.Rows
               'recuper los comprobantes de cada cliente
               Dim ctaCte = GetAlgunosComprobantesPorCliente(idSucursal,
                                                             sal.Field(Of Long)("IdCliente"),
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

               Dim ctaCtePMinuta = New Entidades.CuentaCorriente()
               ctaCtePMinuta.Fecha = fecha
               ctaCtePMinuta.Cliente = regCli._GetUno(sal.Field(Of Long)("IdCliente"))
               ctaCtePMinuta.IdCategoria = ctaCtePMinuta.Cliente.IdCategoria
               ctaCtePMinuta.IdSucursal = ctaCte(0).IdSucursal
               If tipoComprobante.LetrasHabilitadas.Trim.Length = 1 Then
                  ctaCtePMinuta.Letra = tipoComprobante.LetrasHabilitadas
               Else
                  ctaCtePMinuta.Letra = ctaCtePMinuta.Cliente.CategoriaFiscal.LetraFiscal
               End If
               ctaCtePMinuta.CentroEmisor = ctaCte(0).CentroEmisor.ToShort()

               Dim ctacteDatos = _GetUna(ctaCte(0).IdSucursal, ctaCte(0).IdTipoComprobante, ctaCte(0).Letra, ctaCte(0).CentroEmisor, ctaCte(0).NumeroComprobante)

               ' ctaCtePMinuta.Vendedor = ctaCte(0).CuentaCorriente.Vendedor
               ctaCtePMinuta.Vendedor = ctacteDatos.Vendedor
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
               For Each cc As Entidades.CuentaCorrientePago In ctaCte

                  Dim ctactePago = New Entidades.CuentaCorrientePago()
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
                     .FechaEmision = cc.FechaEmision
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

   Public Sub GrabarPagosAutomaticos(ctasCtesListados As List(Of Entidades.CuentaCorriente),
                                     metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                     idFuncion As String,
                                     idTipoLiquidacion As Integer?,
                                     idSubfuncion As String,
                                     nombreArchivo As String,
                                     imputacionAutomatica As Boolean)
      EjecutaConTransaccion(Sub() _GrabarPagosAutomaticos(ctasCtesListados, metodoGrabacion, idFuncion, idTipoLiquidacion, idSubfuncion, nombreArchivo, imputacionAutomatica))
   End Sub

   Public Sub _GrabarPagosAutomaticos(ctasCtesListados As List(Of Entidades.CuentaCorriente),
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                      idFuncion As String, idTipoLiquidacion As Integer?, idSubfuncion As String, nombreArchivo As String, imputacionAutomatica As Boolean)
      For Each ctaCte In ctasCtesListados
         '-- Habilita la Validacion para la imputacion Automatica.- ----
         If imputacionAutomatica Then
            If ctaCte.Pagos.Count = 0 Then
               'recupero los comprobantes si existiesen para cuando realizo los pagos 
               'en cuenta corriente en forma automatica
               'la idea es recuperar los comprobantes pendientes 
               ctaCte.Pagos = GetPagosDeCliente(ctaCte.TipoComprobante, ctaCte.IdSucursal, ctaCte.Cliente.IdCliente, ctaCte.ImporteTotal, idTipoLiquidacion)
               If Publicos.TieneModuloBanco Then
                  ctaCte.Conciliado = True
               End If
            End If
         End If

         Inserta(ctaCte, metodoGrabacion, idFuncion)
      Next
      If Not String.IsNullOrWhiteSpace(nombreArchivo) Then
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
      End If
   End Sub

   Public Sub GrabarPagosAutomaticosAClientes(ctasCtesListados As List(Of Entidades.CuentaCorriente),
                                              MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      EjecutaConTransaccion(
         Sub()
            For Each ctaCte As Entidades.CuentaCorriente In ctasCtesListados
               If ctaCte.Pagos.Count = 0 Then
                  'recupero los comprobantes si existiesen para cuando realizo los pagos 
                  'en cuenta corriente en forma automatica
                  'la idea es recuperar los comprobantes pendientes 
                  ctaCte.Pagos = Me.GetPagosACliente(ctaCte.TipoComprobante,
                                                   ctaCte.IdSucursal,
                                                   ctaCte.Cliente.IdCliente,
                                                   ctaCte.ImporteTotal)
               End If
               Me.Inserta(ctaCte, MetodoGrabacion, IdFuncion)
            Next

         End Sub)
   End Sub

   Friend Function GetPagosDeCliente(tipoComprobante As Entidades.TipoComprobante,
                                     idSucursal As Integer,
                                     idcliente As Long,
                                     totalPagos As Decimal,
                                     idTipoLiquidacion As Integer?) As List(Of Entidades.CuentaCorrientePago)
      Dim letra As String = String.Empty
      Dim centroEmisor As Short
      Dim numeroComprobante As Long
      Return GetPagosDeCliente(idSucursal, tipoComprobante, letra, centroEmisor, numeroComprobante,
                               idcliente, totalPagos, idTipoLiquidacion, incluirPreElectronicos:=False, crmNovedad:=Nothing)
   End Function

   Friend Function GetPagosDeCliente(idSucursal As Integer,
                                     tipoComprobante As Entidades.TipoComprobante,
                                     letra As String,
                                     centroEmisor As Short,
                                     numeroComprobante As Long,
                                     idcliente As Long,
                                     totalPagos As Decimal,
                                     idTipoLiquidacion As Integer?,
                                     incluirPreElectronicos As Boolean,
                                     crmNovedad As Entidades.CRMNovedad) As List(Of Entidades.CuentaCorrientePago)
      Dim pagos = New List(Of Entidades.CuentaCorrientePago)()

      Dim dt = BuscarPendientes(idSucursal, idcliente, categoria:=0, buscaPorClienteVinculado:=False,
                                tiposComprobantes:=tipoComprobante.ComprobantesAsociados, idTipoComprobante:=If(numeroComprobante > 0, tipoComprobante.IdTipoComprobante, String.Empty), letra:=letra, emisor:=centroEmisor, numeroComprobante:=numeroComprobante, numeroComprobanteFinalizaCon:="",
                                idTipoLiquidacion:=idTipoLiquidacion, incluirPreElectronicos:=incluirPreElectronicos,
                                idEmbarcacion:=0, idCama:=0, crmNovedad:=crmNovedad,
                                seleccionMultiple:=False)

      If numeroComprobante > 0 Then
         dt.Select().All(Function(dr)
                            dr("Saldo") = dr.Field(Of Decimal?)("Saldo").IfNull() * tipoComprobante.CoeficienteValores
                            Return True
                         End Function)
      End If

      Dim Paga As Double
      Paga = totalPagos
      Dim dt1 As DataTable = dt.Clone()
      dt1.Columns.Add("Paga", GetType(Decimal))
      Dim dr2 As DataRow

      For Each dr As DataRow In dt.Rows
         If Not Paga <= 0 Then
            If Double.Parse(dr("Saldo").ToString()) <= Paga Then
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr.ItemArray
               dr2("Paga") = Double.Parse(dr("Saldo").ToString())
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()
               Paga = Paga - Double.Parse(dr("Saldo").ToString())
            Else
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr.ItemArray
               dr2("Paga") = Paga
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()
               Paga = 0
            End If
         Else
            Exit For
         End If
      Next

      For Each dr1 As DataRow In dt1.Rows
         Dim oLineaDetalle = New Entidades.CuentaCorrientePago()
         With oLineaDetalle
            Dim rtipocomp = New Reglas.TiposComprobantes()
            .TipoComprobante = rtipocomp.GetUno(dr1.Field(Of String)("IdTipoComprobante"))
            .Letra = dr1.Field(Of String)("Letra")
            .CentroEmisor = dr1.Field(Of Integer)("Emisor")
            .NumeroComprobante = dr1.Field(Of Long)("Numero")
            .Cuota = dr1.Field(Of Integer)("Cuota")
            .FechaEmision = dr1.Field(Of Date)("Fecha")
            .FechaVencimiento = dr1.Field(Of Date)("FechaVencimiento")
            .ImporteCuota = dr1.Field(Of Decimal)("Importe")
            If numeroComprobante > 0 Then
               .SaldoCuota = dr1.Field(Of Decimal)("Saldo") * tipoComprobante.CoeficienteValores
               .Paga = dr1.Field(Of Decimal)("Paga") * tipoComprobante.CoeficienteValores
            Else
               .SaldoCuota = dr1.Field(Of Decimal)("Saldo")
               .Paga = dr1.Field(Of Decimal)("Paga")
            End If
            .IdSucursal = dr1.Field(Of Integer)("Sucursal")
            .Usuario = actual.Nombre
         End With
         pagos.Add(oLineaDetalle)
      Next

      Return pagos
   End Function

   Public Function GetPagosDeCliente(tipoComprobante As Entidades.TipoComprobante,
                                     idSucursal As Integer,
                                     idcliente As Long,
                                     totalPagos As Decimal,
                                     idTipoLiquidacion As Integer?,
                                     idTipoComprobanteDeuda As String,
                                     letraDeuda As String,
                                     centroEmisorDeuda As Short,
                                     numeroComprobanteDeuda As Long,
                                     cuotaNumeroDeuda As Integer,
                                     soloCuotaIndicada As Boolean) As List(Of Entidades.CuentaCorrientePago)

      Dim pagos = New List(Of Entidades.CuentaCorrientePago)()
      Dim dt As DataTable
      Dim cache = New BusquedasCacheadas()

      dt = BuscarPendientes(idSucursal, idcliente, 0, buscaPorClienteVinculado:=False, tiposComprobantes:=tipoComprobante.ComprobantesAsociados, idTipoComprobante:="", letra:="", emisor:=0, numeroComprobante:=0, numeroComprobanteFinalizaCon:="",
         idTipoLiquidacion:=idTipoLiquidacion, incluirPreElectronicos:=False, idEmbarcacion:=0, idCama:=0, crmNovedad:=Nothing, seleccionMultiple:=False)
      Dim Paga As Double
      Paga = totalPagos
      Dim dt1 As DataTable = dt.Clone()
      dt1.Columns.Add("Paga", GetType(Decimal))
      Dim dr2 As DataRow

      For Each dr In dt.Select(String.Format("Sucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND Emisor = {3} AND Numero = {4} AND Cuota = {5}",
                                             idSucursal, idTipoComprobanteDeuda, letraDeuda, centroEmisorDeuda, numeroComprobanteDeuda, cuotaNumeroDeuda))
         If Not Paga <= 0 Then
            If Double.Parse(dr("Saldo").ToString()) <= Paga Then
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr.ItemArray
               dr2("Paga") = Double.Parse(dr("Saldo").ToString())
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()
               Paga = Paga - Double.Parse(dr("Saldo").ToString())
            Else
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr.ItemArray
               dr2("Paga") = Paga
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()
               Paga = 0
            End If
         Else
            Exit For
         End If
      Next

      If Not soloCuotaIndicada Then
         For Each dr In dt.Select(String.Format("Sucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND Emisor = {3} AND Numero = {4} AND Cuota <> {5}",
                                                idSucursal, idTipoComprobanteDeuda, letraDeuda, centroEmisorDeuda, numeroComprobanteDeuda, cuotaNumeroDeuda))
            If Not Paga <= 0 Then
               If Double.Parse(dr("Saldo").ToString()) <= Paga Then
                  dr2 = dt1.NewRow()
                  dr2.ItemArray = dr.ItemArray
                  dr2("Paga") = Double.Parse(dr("Saldo").ToString())
                  dt1.Rows.Add(dr2)
                  dt1.AcceptChanges()
                  Paga = Paga - Double.Parse(dr("Saldo").ToString())
               Else
                  dr2 = dt1.NewRow()
                  dr2.ItemArray = dr.ItemArray
                  dr2("Paga") = Paga
                  dt1.Rows.Add(dr2)
                  dt1.AcceptChanges()
                  Paga = 0
               End If
            Else
               Exit For
            End If
         Next
      End If

      For Each dr1 As DataRow In dt1.Rows
         Dim oLineaDetalle = New Entidades.CuentaCorrientePago()
         With oLineaDetalle
            Dim otipocomp = New Reglas.TiposComprobantes()
            .TipoComprobante = otipocomp.GetUno(dr1("IdTipoComprobante").ToString())
            .Letra = dr1("Letra").ToString()
            .CentroEmisor = Integer.Parse(dr1("Emisor").ToString())
            .NumeroComprobante = Integer.Parse(dr1("Numero").ToString())
            .Cuota = Integer.Parse(dr1("Cuota").ToString())
            .FechaEmision = Date.Parse(dr1("Fecha").ToString())
            .FechaVencimiento = Date.Parse(dr1("FechaVencimiento").ToString())
            .ImporteCuota = Decimal.Parse(dr1("Importe").ToString())
            .SaldoCuota = Decimal.Parse(dr1("Saldo").ToString())
            .Paga = Decimal.Parse(dr1("Paga").ToString())
            .IdSucursal = Integer.Parse(dr1("Sucursal").ToString())
            .FormaPago = cache.BuscaFormasPago(dr1.Field(Of Integer)("IdFormasPago"))
            .Usuario = actual.Nombre
         End With
         pagos.Add(oLineaDetalle)
      Next

      Return pagos

   End Function

   Private Function GetPagosACliente(tipoComprobante As Entidades.TipoComprobante,
                                     idSucursal As Integer,
                                     idcliente As Long,
                                     totalPagos As Decimal) As List(Of Entidades.CuentaCorrientePago)

      Dim pagos = New List(Of Entidades.CuentaCorrientePago)()

      Dim dt = BuscarPendientes(idSucursal, idcliente, 0, buscaPorClienteVinculado:=False, tiposComprobantes:=tipoComprobante.ComprobantesAsociados, idTipoComprobante:="", letra:="", emisor:=0, numeroComprobante:=0, numeroComprobanteFinalizaCon:="",
         idTipoLiquidacion:=Nothing, incluirPreElectronicos:=False, idEmbarcacion:=0, idCama:=0, crmNovedad:=Nothing, seleccionMultiple:=False)
      Dim Paga As Double = totalPagos
      Dim dt1 As DataTable = dt.Clone()
      dt1.Columns.Add("Paga", GetType(Decimal))
      Dim dr2 As DataRow

      For Each dr As DataRow In dt.Rows
         If Not Paga = 0 Then
            'Aca es al Reves porque aplica Negativo (LIQUIDO PRODUCTO).
            If Double.Parse(dr("Saldo").ToString()) >= Paga Then
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr.ItemArray
               dr2("Paga") = Double.Parse(dr("Saldo").ToString())
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()
               Paga = Paga - Double.Parse(dr("Saldo").ToString())
            Else
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr.ItemArray
               dr2("Paga") = Paga
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()
               Paga = 0
            End If
         Else
            Exit For
         End If
      Next

      For Each dr1 As DataRow In dt1.Rows
         Dim oLineaDetalle = New Entidades.CuentaCorrientePago()
         With oLineaDetalle
            Dim otipocomp = New Reglas.TiposComprobantes()
            .TipoComprobante = otipocomp.GetUno(dr1("IdTipoComprobante").ToString())
            .Letra = dr1("Letra").ToString()
            .CentroEmisor = Integer.Parse(dr1("Emisor").ToString())
            .NumeroComprobante = Integer.Parse(dr1("Numero").ToString())
            .Cuota = Integer.Parse(dr1("Cuota").ToString())
            .FechaEmision = Date.Parse(dr1("Fecha").ToString())
            .FechaVencimiento = Date.Parse(dr1("FechaVencimiento").ToString())
            .ImporteCuota = Decimal.Parse(dr1("Importe").ToString())
            .SaldoCuota = Decimal.Parse(dr1("Saldo").ToString())
            .Paga = Decimal.Parse(dr1("Paga").ToString())
            .IdSucursal = Integer.Parse(dr1("Sucursal").ToString())
            .Usuario = actual.Nombre
         End With
         pagos.Add(oLineaDetalle)
      Next

      Return pagos

   End Function

   Public Function GetParaImpresionMasiva(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                                          orden As String,
                                          idCliente As Long,
                                          idTipoComprobante As String, letra As String, centroEmisor As Short, nroDesde As Long, nroHasta As Long,
                                          idEstadoComprobante As String,
                                          grabaLibro As Entidades.Publicos.SiNoTodos, afectaCaja As Entidades.Publicos.SiNoTodos,
                                          idFormasPago As Integer, idUsuario As String, exportado As String) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim oCategoriaFiscalEmpresa = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
            Dim sql = New SqlServer.CuentasCorrientes(da)
            Return sql.GetParaImpresionMasiva(idSucursal, fechaDesde, fechaHasta,
                                              orden,
                                              idCliente,
                                              idTipoComprobante, letra, centroEmisor, nroDesde, nroHasta,
                                              idEstadoComprobante,
                                              grabaLibro, afectaCaja,
                                              idFormasPago, idUsuario, exportado,
                                              oCategoriaFiscalEmpresa.IvaDiscriminado, actual.NivelAutorizacion)
         End Function)
   End Function

   Public Function GetImpresionCuotasMasiva(idSucursal As Integer,
                                            fechaDesde As Date, fechaHasta As Date,
                                            orden As String,
                                            idCliente As Long,
                                            idTipoComprobante As String, letra As String, centroEmisor As Short, nroDesde As Long, nroHasta As Long,
                                            idEstadoComprobante As String,
                                            grabaLibro As String, afectaCaja As String,
                                            idFormasPago As Integer,
                                            idUsuario As String,
                                            exportado As String) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim oCategoriaFiscalEmpresa = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
            Dim sql = New SqlServer.CuentasCorrientes(da)
            Return sql.GetImpresionCuotasMasiva(idSucursal,
                                                fechaDesde, fechaHasta,
                                                orden,
                                                idCliente,
                                                idTipoComprobante, letra, centroEmisor, nroDesde, nroHasta,
                                                idEstadoComprobante,
                                                oCategoriaFiscalEmpresa.IvaDiscriminado,
                                                grabaLibro, afectaCaja,
                                                idFormasPago,
                                                idUsuario,
                                                actual.NivelAutorizacion,
                                                exportado)
         End Function)
   End Function

   Public Sub Importar(dt As DataTable, tspImportando As Windows.Forms.ToolStripProgressBar, idFuncion As String,
                       tomaVinculadoDesdeCliente As Boolean)
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
               Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
               Dim CC As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()

               With CC
                  .IdSucursal = actual.Sucursal.Id
                  .TipoComprobante.IdTipoComprobante = dr("IdTipoComprobante").ToString()
                  .Letra = dr("Letra").ToString()
                  .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
                  .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
                  .Fecha = Date.Parse(dr("Fecha").ToString())
                  .FechaVencimiento = Date.Parse(dr("FechaVencimiento").ToString())
                  .Cliente = New Reglas.Clientes().GetUno(Long.Parse(dr("IdCliente").ToString()))
                  .Vendedor = New Reglas.Empleados().GetUno(.Cliente.Vendedor.IdEmpleado)
                  .FormaPago.IdFormasPago = 3
                  .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString()) '* coe
                  .Saldo = .ImporteTotal
                  .CantidadCuotas = 1
                  .Observacion = dr("Observacion").ToString()
                  .Usuario = actual.Nombre
                  .IdEstado = "NORMAL"

                  If IsNumeric(dr("IdClienteVinculado")) Then
                     .IdClienteCtaCte = Long.Parse(dr("IdClienteVinculado").ToString())
                  Else
                     If tomaVinculadoDesdeCliente Then
                        If .Cliente.IdClienteCtaCte <> 0 Then
                           .IdClienteCtaCte = .Cliente.IdClienteCtaCte
                        Else
                           .IdClienteCtaCte = .Cliente.IdCliente
                        End If
                     End If
                  End If

                  .IdCategoria = .Cliente.IdCategoria
                  .CotizacionDolar = Decimal.Parse(dr("CotizacionDolar").ToString())
                  .Direccion = .Cliente.Direccion
                  .IdLocalidad = .Cliente.IdLocalidad
                  '-- REQ-34501.- ---------------------------------------------
                  If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
                     If IsNumeric(dr("IdEmbarcacion").ToString()) Then
                        .IdEmbarcacion = Long.Parse(dr("IdEmbarcacion").ToString())
                        .NombreEmbarcacion = dr("NombreEmbarcacion").ToString()
                     End If
                  End If
                  '------------------------------------------------------------
                  If New Reglas.Generales().ExisteTabla("Camas") Then
                     If IsNumeric(dr("IdCama").ToString()) Then
                        .IdCama = Long.Parse(dr("IdCama").ToString())
                        .CodigoCama = dr("CodigoCama").ToString()
                     End If
                  End If

               End With

               Dim CCP As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()

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
                  .ImporteCapital = .ImporteCuota
                  .SaldoCuota = CC.ImporteTotal
                  .CuentaCorriente = CC
                  '-- REQ-34501.- ---------------------------------------------
                  If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
                     If IsNumeric(dr("IdEmbarcacion").ToString()) Then
                        .IdEmbarcacion = Long.Parse(dr("IdEmbarcacion").ToString())
                     End If
                  End If
                  '------------------------------------------------------------
                  If New Reglas.Generales().ExisteTabla("Camas") Then
                     If IsNumeric(dr("IdCama").ToString()) Then
                        .IdCama = Long.Parse(dr("IdCama").ToString())
                     End If
                  End If
               End With

               'CargarUna(dr, o)

               ' o.NuevoComentario = dr(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString()).ToString()

               If dr(Entidades.Importadores.Columnas.Accion.ToString()).Equals("A") Then
                  oCtaCte.GrabaCtaCte(CC, CCP, Entidades.Entidad.MetodoGrabacion.Manual, idFuncion)
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

   Public Function GetCtasCtesParaBanco(idCobrador As Integer, periodo As Date?, idTipoLiquidacion As Integer?) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.CuentasCorrientes(da).GetCtasCtesParaBanco(idCobrador, periodo, idTipoLiquidacion))
   End Function

   Public Function GetParaSincronizacionMovil() As DataTable
      Return New SqlServer.CuentasCorrientes(da).GetParaSincronizacionMovil(Reglas.Publicos.Simovil.MaximoCuotasEnviarCuentasCorrientes)
   End Function

   Public Sub ModificaRecibo(recibo As Entidades.CuentaCorriente)
      EjecutaConTransaccion(
         Sub()
            _ModificaRecibo(recibo)

            'En el TipoComprobante.IdTipoComprobanteSecundario se encuentra el ANTICIPO que podría haber generado.
            'Si encuentro el registro de Anticipo, debo realizar la modificación también para el Anticipo.
            If Existe(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobanteSecundario, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante) Then
               Dim rTipoComprobante = New TiposComprobantes(da)
               'Respaldo los tipos de comporbantes originales (para volver a ponerles los valores al final del proceso)
               Dim tipoComprobanteOrigen = recibo.TipoComprobante
               Dim idTipoComprobanteNuevoOrigen = DirectCast(recibo, Entidades.IComprobanteModificable).IdTipoComprobanteNuevo

               'Cambio el tipo de comprobante del recibo y el nuevo Tipo de Comprobante al Tipo de Comprobante Secundario.
               'En el Tipo de Comprobante Secundario se configura el ANTICIPO asociado
               recibo.TipoComprobante = rTipoComprobante.GetUno(recibo.TipoComprobante.IdTipoComprobanteSecundario)
               If DirectCast(recibo, Entidades.IComprobanteModificable).DebeRenumerar Then
                  Dim tipoComprobanteNuevo = rTipoComprobante.GetUno(DirectCast(recibo, Entidades.IComprobanteModificable).IdTipoComprobanteNuevo)
                  DirectCast(recibo, Entidades.IComprobanteModificable).IdTipoComprobanteNuevo = tipoComprobanteNuevo.IdTipoComprobanteSecundario
               End If

               Try
                  'Tipo el proceso para los Anticipos.
                  _ModificaRecibo(recibo)
               Finally
                  'Vuelvo los tipos de comporbantes originales para asegurarme que no haya cambios en las instancias
                  recibo.TipoComprobante = tipoComprobanteOrigen
                  If DirectCast(recibo, Entidades.IComprobanteModificable).DebeRenumerar Then
                     DirectCast(recibo, Entidades.IComprobanteModificable).IdTipoComprobanteNuevo = idTipoComprobanteNuevoOrigen
                  End If
               End Try
            End If
         End Sub)
   End Sub

   Public Sub _ModificaRecibo(recibo As Entidades.CuentaCorriente)
      If recibo.ImporteTransfBancaria <> 0 AndAlso recibo.CuentaBancariaTransfBanc Is Nothing Then
         Throw New ApplicationException(String.Format("El {0} {1} {2:0000}-{3:00000000} se pago con transferencia y no seleccionó una cuenta bancaria.",
                                                      recibo.TipoComprobante.Descripcion,
                                                      recibo.Letra,
                                                      recibo.CentroEmisor,
                                                      recibo.NumeroComprobante))
      End If

      Dim reciboAnt = _GetUna(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante) ', recibo.Vendedor.IdEmpleado

      Dim idCuentaBancaria As Integer? = Nothing


      If recibo IsNot Nothing AndAlso reciboAnt IsNot Nothing AndAlso
         Not recibo.TipoComprobante.EsAnticipo Then
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

               Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos(da)
               Dim oLibBanco As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)

               'Si Pagó parte con Transfencia Bancaria
               If recibo.ImporteTransfBancaria <> 0 Then
                  oLibroBancos.AgregaMovimiento(ArmaLibroBancosPorRenumerar(reciboAnt, -1,
                                                                               oLibBanco.GetProximoNumeroDeMovimiento(recibo.IdSucursal,
                                                                                                                      reciboAnt.CuentaBancariaTransfBanc.IdCuentaBancaria)))
                  oLibroBancos.AgregaMovimiento(ArmaLibroBancosPorRenumerar(recibo, 1,
                                                                               oLibBanco.GetProximoNumeroDeMovimiento(recibo.IdSucursal,
                                                                                                                      recibo.CuentaBancariaTransfBanc.IdCuentaBancaria)))
               End If
            End If

            idCuentaBancaria = recibo.CuentaBancariaTransfBanc.IdCuentaBancaria
         End If
      End If

      If DirectCast(recibo, Entidades.IComprobanteModificable).DebeRenumerar Then
         If reciboAnt.IdAsiento.HasValue Then
            Throw New ApplicationException(String.Format("El {0} {1} {2:0000}-{3:00000000} ya fue registrada contablemente en el asiento {4}. No es posible modifcar su número.",
                                                            reciboAnt.TipoComprobante.Descripcion,
                                                            reciboAnt.Letra,
                                                            reciboAnt.CentroEmisor,
                                                            reciboAnt.NumeroComprobante,
                                                            reciboAnt.IdAsiento))
         End If
      End If


      Dim fechaEmison As Date? = Nothing
      Dim fechaTransferencia As Date? = Nothing
      Dim idVendedor As Integer? = Nothing '-.PE-31462.-
      Dim numeroOrdenCompra As Long? = Nothing

      If reciboAnt.Fecha <> recibo.Fecha Then
         fechaEmison = recibo.Fecha
      End If

      If reciboAnt.FechaTransferencia <> recibo.FechaTransferencia Then
         fechaTransferencia = recibo.FechaTransferencia
      End If

      If reciboAnt.Vendedor.IdEmpleado <> recibo.Vendedor.IdEmpleado Then
         idVendedor = recibo.Vendedor.IdEmpleado '-.PE-31462.-
      End If

      If reciboAnt.NumeroOrdenCompra <> recibo.NumeroOrdenCompra Then
         numeroOrdenCompra = recibo.NumeroOrdenCompra
      End If


      Dim sqlCtaCte = New SqlServer.CuentasCorrientes(da)
      sqlCtaCte.CuentasCorrientes_ModificaRecibo(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante,
                                                    recibo.Observacion, idCuentaBancaria, fechaEmison, fechaTransferencia, idVendedor, numeroOrdenCompra)

      Dim sqlCtaCtePagos = New SqlServer.CuentasCorrientesPagos(da)
      'Actualizo La observacion en CuentasCorrientesPagos
      sqlCtaCtePagos.CuentasCorrientesPagos_UObservacion(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante, recibo.Observacion)

      '# Actualizo la cuenta bancaria de la tabla CuentasCorrientesTransferencias en caso que se haya actualizado la cuenta bancaria.
      If idCuentaBancaria IsNot Nothing Then
         Dim rCuentasCorrientesTransferencias = New Reglas.CuentasCorrientesTransferencias(da)
         rCuentasCorrientesTransferencias.ActualizarCuentaBancaria(idCuentaBancaria.Value, recibo)
      End If

      If fechaEmison.HasValue Then

         sqlCtaCtePagos.CuentasCorrientesPagos_UFechaEmision(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante, fechaEmison.Value)
      End If

      sqlCtaCte.CuentasCorrientes_LimpiaFechaExportacion(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante)


      If DirectCast(recibo, Entidades.IComprobanteModificable).DebeRenumerar Then
         _RenumerarRecibo(recibo)
      End If

   End Sub

   Private Function ArmaLibroBancosPorRenumerar(recibo As Entidades.CuentaCorriente, coeficienteValor As Short, proximoNumero As Integer) As Entidades.LibroBanco
      Dim entLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
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
         '.Observacion = ent.Observacion
         .Observacion = String.Format("RENUMERA {0} {1} {2:0000}-{3:00000000} - Transf. a Caja. {4}",
                                      recibo.TipoComprobante.Descripcion.Trim(),
                                      recibo.Letra,
                                      recibo.CentroEmisor,
                                      recibo.NumeroComprobante,
                                      recibo.Cliente.NombreCliente).Truncar(100)
         .Conciliado = False
      End With
      Return entLibroBanco
   End Function

   Public Sub RenumerarRecibo(recibo As Entidades.CuentaCorriente)
      EjecutaConTransaccion(Sub() _RenumerarRecibo(recibo))
   End Sub

   Private Sub _RenumerarRecibo(recibo As Entidades.CuentaCorriente)
      _RenumerarRecibo(recibo, DirectCast(recibo, Entidades.IComprobanteModificable))
   End Sub
   Private Sub _RenumerarRecibo(recibo As Entidades.CuentaCorriente, reciboNuevo As Entidades.IComprobanteModificable)
      _RenumerarRecibo(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante,
                       reciboNuevo.IdSucursalNuevo, reciboNuevo.IdTipoComprobanteNuevo, reciboNuevo.LetraNuevo, reciboNuevo.CentroEmisorNuevo, reciboNuevo.NumeroComprobanteNuevo)
   End Sub
   Private Sub _RenumerarRecibo(idSucursalActual As Integer, idTipoComprobanteActual As String, letraActual As String, centroEmisorActual As Short, numeroComprobanteActual As Long,
                                idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Short, numeroComprobanteNuevo As Long)
      Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
      'Condición para todas las tablas de compras y PK de CtaCteProv
      Dim whereClauseCompra = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                            Entidades.CuentaCorriente.Columnas.IdSucursal.ToString(), idSucursalActual,
                                            Entidades.CuentaCorriente.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteActual,
                                            Entidades.CuentaCorriente.Columnas.Letra.ToString(), letraActual,
                                            Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString(), centroEmisorActual,
                                            Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString(), numeroComprobanteActual)

      'Campos a cambiar en todas las tablas de compras y PK de CtaCteProv
      Dim camposCambio = New Dictionary(Of String, String)() From
                                      {{Entidades.CuentaCorriente.Columnas.IdSucursal.ToString(), idSucursalNuevo.ToString()},
                                       {Entidades.CuentaCorriente.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteNuevo},
                                       {Entidades.CuentaCorriente.Columnas.Letra.ToString(), letraNuevo},
                                       {Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString(), centroEmisorNuevo.ToString()},
                                       {Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString(), numeroComprobanteNuevo.ToString()}}

      Dim whereClausePagos2 = String.Format(" WHERE {0} = {1} AND {2}2 = '{3}' AND {4}2 = '{5}' AND {6}2 = {7} AND {8}2 = {9}",
                                            Entidades.CuentaCorriente.Columnas.IdSucursal.ToString(), idSucursalActual,
                                            Entidades.CuentaCorriente.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteActual,
                                            Entidades.CuentaCorriente.Columnas.Letra.ToString(), letraActual,
                                            Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString(), centroEmisorActual,
                                            Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString(), numeroComprobanteActual)

      'Campos a cambiar en todas las tablas de compras y PK de CtaCteProv
      Dim camposCambioPagos2 = New Dictionary(Of String, String)() From
                                      {{Entidades.CuentaCorriente.Columnas.IdSucursal.ToString(), idSucursalNuevo.ToString()},
                                       {Entidades.CuentaCorriente.Columnas.IdTipoComprobante.ToString() + "2", idTipoComprobanteNuevo},
                                       {Entidades.CuentaCorriente.Columnas.Letra.ToString() + "2", letraNuevo},
                                       {Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString() + "2", centroEmisorNuevo.ToString()},
                                       {Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString() + "2", numeroComprobanteNuevo.ToString()}}

      Try
         sql.InsertSelect("CuentasCorrientes", camposCambio, whereClauseCompra)
      Catch ex As Exception
         If ex.InnerException IsNot Nothing AndAlso TypeOf (ex.InnerException) Is SqlClient.SqlException AndAlso
            DirectCast(ex.InnerException, SqlClient.SqlException).Number = 2627 Then
            Throw New ApplicationException(String.Format("El {1} {2} {3:0000}-{4:00000000} ya existe en la sucursal {0}.",
                                                         idSucursalNuevo, idTipoComprobanteNuevo, letraNuevo, centroEmisorNuevo, numeroComprobanteNuevo), ex)
         End If
         Throw
      End Try
      sql.UpdatePrimaryKey("CuentasCorrientesPagos", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesPagos", camposCambioPagos2, whereClausePagos2)
      sql.UpdatePrimaryKey("CuentasCorrientesCheques", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesRetenciones", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesTarjetas", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesTransferencias", camposCambio, whereClauseCompra)


      Dim whereClauseCompraV As String
      whereClauseCompraV = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                         Entidades.CuentaCorriente.Columnas.IdSucursalVinculado.ToString(), idSucursalActual,
                                         Entidades.CuentaCorriente.Columnas.IdTipoComprobanteVinculado.ToString(), idTipoComprobanteActual,
                                         Entidades.CuentaCorriente.Columnas.LetraVinculado.ToString(), letraActual,
                                         Entidades.CuentaCorriente.Columnas.CentroEmisorVinculado.ToString(), centroEmisorActual,
                                         Entidades.CuentaCorriente.Columnas.NumeroComprobanteVinculado.ToString(), numeroComprobanteActual)
      'Campos a cambiar en todas las tablas de compras y PK de CtaCteProv
      Dim camposCambioV As Dictionary(Of String, String) = New Dictionary(Of String, String)() _
                                                                   From {{Entidades.CuentaCorriente.Columnas.IdSucursalVinculado.ToString(), idSucursalNuevo.ToString()},
                                                                         {Entidades.CuentaCorriente.Columnas.IdTipoComprobanteVinculado.ToString(), idTipoComprobanteNuevo},
                                                                         {Entidades.CuentaCorriente.Columnas.LetraVinculado.ToString(), letraNuevo},
                                                                         {Entidades.CuentaCorriente.Columnas.CentroEmisorVinculado.ToString(), centroEmisorNuevo.ToString()},
                                                                         {Entidades.CuentaCorriente.Columnas.NumeroComprobanteVinculado.ToString(), numeroComprobanteNuevo.ToString()}}
      sql.UpdatePrimaryKey("CuentasCorrientes", camposCambioV, whereClauseCompraV)

      sql.DeleteGenerico("CuentasCorrientes", camposCambio, whereClauseCompra)

      Dim sucursal = New Sucursales(da).GetUna(idSucursalNuevo, incluirLogo:=False)
      Dim rVN = New VentasNumeros(da)
      Dim sqlCC = New SqlServer.CuentasCorrientes(da)

      Dim vn = rVN.GetUno(sucursal, idTipoComprobanteNuevo, letraNuevo, centroEmisorNuevo,
                          comparteNumeracion:=Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales,
                          AccionesSiNoExisteRegistro.Nulo)
      If vn IsNot Nothing Then
         Dim maxCtaCte = sqlCC.GetNumeroMaximo(sucursal.IdEmpresa, sucursal.IdSucursal, idTipoComprobanteNuevo, letraNuevo, centroEmisorNuevo,
                                               comparteNumeracion:=Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales)
         If vn.Numero <> maxCtaCte Then
            vn.Numero = maxCtaCte
            rVN.ActualizarNumero(vn)
         End If

         If idTipoComprobanteActual <> idTipoComprobanteNuevo Or
            letraActual <> letraNuevo Or
            centroEmisorActual <> centroEmisorNuevo Then

            vn = rVN.GetUno(sucursal, idTipoComprobanteActual, letraActual, centroEmisorActual,
                            comparteNumeracion:=Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales,
                            AccionesSiNoExisteRegistro.Excepcion)
            maxCtaCte = sqlCC.GetNumeroMaximo(sucursal.IdEmpresa, sucursal.IdSucursal, idTipoComprobanteActual, letraActual, centroEmisorActual,
                                              comparteNumeracion:=Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales)
            If vn.Numero <> maxCtaCte Then
               vn.Numero = maxCtaCte
               rVN.ActualizarNumero(vn)
            End If
         End If
      End If

   End Sub

   Public Function GetCtasCtesParaPMC(idSucursal As Integer, categorias As Entidades.Categoria(),
                                      periodo? As Date, tipoLiquidacion? As Integer,
                                      numeroDesde As Long, numeroHasta As Long) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.CuentasCorrientes(da).GetCtasCtesParaPMC(idSucursal, periodo, categorias, tipoLiquidacion, numeroDesde, numeroHasta))
   End Function

   Public Function GetCtasCtesParaPMCRoela(idSucursal As Integer, categorias As Entidades.Categoria(),
                                           periodo? As Date, tipoLiquidacion? As Integer,
                                           numeroDesde As Long, numeroHasta As Long, tipo As Entidades.CuentaCorriente.FormatoPMC) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.CuentasCorrientes(da).GetCtasCtesParaPMCRoela(idSucursal, periodo, categorias, tipoLiquidacion, numeroDesde, numeroHasta, tipo))
   End Function

#End Region

#Region "Metodos Privados"

   ''' <summary>
   ''' Inserto un Recibo a la Cta. Cte.
   ''' </summary>
   ''' <param name="ent"></param>
   ''' <remarks></remarks>

   Friend Sub Inserta(ent As Entidades.CuentaCorriente, metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)

      Dim NumeroComprob = 0L

      My.Application.Log.WriteEntry("Releo el Tipo de Comprobante del Recibo.", TraceEventType.Verbose)

      '-- REQ-34389.- -----------------------------------------------------------------------------------------
      Dim ObservacionEmbCliente As String
      If String.IsNullOrEmpty(ent.NombreEmbarcacion) Then
         ObservacionEmbCliente = ent.Cliente.NombreCliente
      Else
         ObservacionEmbCliente = String.Format("{0} - {1}", ent.NombreEmbarcacion, ent.Cliente.NombreCliente)
      End If
      '--------------------------------------------------------------------------------------------------------
      Dim pagosVinculados As IEnumerable(Of Entidades.CuentaCorrientePago) = Nothing
      Dim importeTotalReciboVinculado As Decimal = 0
      ent.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(ent.TipoComprobante.IdTipoComprobante)

      If ent.TipoComprobante.EsReciboClienteVinculado Then
         pagosVinculados = ent.Pagos
         ent.Pagos = New List(Of Entidades.CuentaCorrientePago)()
         importeTotalReciboVinculado = ent.ImporteTotal
         ent.ImportePesos = ent.ImportePesos - (ent.ImporteTotal)
         ent.ImporteTotal = 0
      End If
      'VALIDO QUE LOS COMPROBANTES ASOCIADOS A LA CUENTA CORRIENTE PERTENEZCAN AL MISMO CLIENTE
      'BUSCO NUEVAMENTE EL IDCLIENTE DE LOS COMPROBANTES ASOCIADOS PARA ESTAR SEGURO DE QUE TENGO EL IDCLIENTE CORRECTO.
      For Each ccp In ent.Pagos
         Dim dtCliente As DataTable = ClienteDeComprobante(ccp.IdSucursal, ccp.IdTipoComprobante, ccp.Letra, ccp.CentroEmisor, ccp.NumeroComprobante)
         If dtCliente.Rows.Count = 0 Then
            Throw New Exception(String.Format("No se pudo encontrar el comprobante {0} {1} {2:0000}-{3:00000000} del recibo." + Environment.NewLine + Environment.NewLine +
                                              "Por facvor verifique.",
                                              ccp.IdTipoComprobante, ccp.Letra, ccp.CentroEmisor, ccp.NumeroComprobante))
         End If
         Dim idClientePago As Long = Integer.Parse(dtCliente.Rows(0)("IdCliente").ToString())
         Dim CodigoClientePago As Long = Long.Parse(dtCliente.Rows(0)("CodigoCliente").ToString())
         If idClientePago <> ent.Cliente.IdCliente Then
            Throw New Exception(String.Format("El cliente del comprobante {0} {1} {2:0000}-{3:00000000} ({4}) no coincide con el cliente del recibo ({5})." + Environment.NewLine + Environment.NewLine +
                                              "Por facvor verifique.",
                                              ccp.IdTipoComprobante, ccp.Letra, ccp.CentroEmisor, ccp.NumeroComprobante, CodigoClientePago, ent.Cliente.CodigoCliente))
         End If
      Next

      My.Application.Log.WriteEntry("Inserto un Recibo a la Cta. Cte.", TraceEventType.Verbose)

      Dim comparteNumeracion As Boolean = Reglas.Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales

      'Si no lo asigno previamente debo buscar el ultimo
      If ent.NumeroComprobante = 0 Then

         NumeroComprob = Me.GetProximoNumero(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, comparteNumeracion)

         Dim idSucursal As Integer = ent.IdSucursal
         If comparteNumeracion Then idSucursal = 0

         If Me.Existe(idSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, NumeroComprob) Then
            Throw New Exception("El número de recibo " & NumeroComprob.ToString() & " ya existe, debe digitar uno mayor y retomara la numeración.")
         End If

         ent.NumeroComprobante = NumeroComprob
      Else
         NumeroComprob = Me.GetProximoNumero(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, comparteNumeracion)
      End If

      'Si el numero es automatico o es manual pero coincide con el ultimo, debo actualizar el numerador
      Dim ventaNum As Reglas.VentasNumeros = New Reglas.VentasNumeros(da)
      Dim vn As Entidades.VentaNumero = New Entidades.VentaNumero()

      If ent.NumeroComprobante >= NumeroComprob Then
         vn.IdEmpresa = New Sucursales(da).GetUna(ent.IdSucursal, False).IdEmpresa
         If comparteNumeracion Then
            vn.IdSucursal = -1
         Else
            vn.IdSucursal = ent.IdSucursal
         End If
         vn.CentroEmisor = ent.CentroEmisor
         vn.IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
         vn.LetraFiscal = ent.Letra
         vn.Numero = ent.NumeroComprobante
         vn.Fecha = ent.Fecha
         ventaNum.ActualizarNumero(vn)
      Else
         If Reglas.Publicos.CtaCte.RecibosMantieneNumeracionModificada Then
            If comparteNumeracion Then
               vn.IdSucursal = -1
            Else
               vn.IdSucursal = ent.IdSucursal
            End If
            vn.IdSucursal = ent.IdSucursal
            vn.CentroEmisor = ent.CentroEmisor
            vn.IdTipoComprobante = ent.TipoComprobante.IdTipoComprobante
            vn.LetraFiscal = ent.Letra
            vn.Numero = ent.NumeroComprobante
            vn.Fecha = ent.Fecha
            ventaNum.ActualizarNumero(vn)
         End If
      End If

      Dim ccttPag As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos(da)

      Dim ct As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()

      Dim cajeroGenera As Entidades.VentaCajero.CajeroGenera
      cajeroGenera = DirectCast([Enum].Parse(GetType(Entidades.VentaCajero.CajeroGenera), Reglas.Publicos.CajeroGenera), Entidades.VentaCajero.CajeroGenera)

      My.Application.Log.WriteEntry("Actualizo los saldos de los items de Pago del Recibo.", TraceEventType.Verbose)
      'actualiza los saldos de los items de pago
      For Each com As Entidades.CuentaCorrientePago In ent.Pagos
         com.CuentaCorriente = ent
         ccttPag.ActualizaSaldo(com, com.Paga * (-1))

         '' ''ct = Me._GetUna(com.IdSucursal, com.IdTipoComprobante, com.Letra, com.CentroEmisor, com.NumeroComprobante)

         ' '' ''ct.Saldo = ct.Saldo - com.Paga
         ' '' ''ct.Saldo = ct.Saldo - (com.Paga * ent.TipoComprobante.CoeficienteValores)
         '' ''Me.ActualizaSaldo(ct, com.Paga * (-1))

         Me.ActualizaSaldo(com.IdSucursal, com.IdTipoComprobante, com.Letra, Convert.ToInt16(com.CentroEmisor), com.NumeroComprobante, com.Paga * (-1))

         If cajeroGenera = Entidades.VentaCajero.CajeroGenera.Recibos Then
            Dim ctCajero = Me._GetUna(com.IdSucursal, com.IdTipoComprobante, com.Letra, com.CentroEmisor, com.NumeroComprobante)

            Dim rVentasCajeros = New VentasCajeros(da)
            Dim oVentaCajero = Entidades.VentaCajero.FromCuentaCorriente(ctCajero)
            rVentasCajeros._Borrar(oVentaCajero)
         End If
      Next

      My.Application.Log.WriteEntry("Recorro los cheques que se insertaron en los Recibos.", TraceEventType.Verbose)

      ent.ImporteCheques = 0
      For Each cheq As Entidades.Cheque In ent.Cheques
         ent.ImporteCheques += cheq.Importe
      Next
      If ent.CCTransferencias Is Nothing Then ent.CCTransferencias = New List(Of Entidades.CuentaCorrienteTransferencia)()
      If ent.CCTransferencias.Count > 0 Then
         ent.ImporteTransfBancaria = ent.CCTransferencias.Sum(Function(vt) vt.Importe) '* coe
         If ent.CCTransferencias.Select(Function(vt) vt.IdCuentaBancaria).Distinct().Count > 1 Then
            ent.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(999)
         Else
            ent.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(ent.CCTransferencias.First().IdCuentaBancaria)
         End If
      Else
         If ent.CCTransferencias.Count = 0 AndAlso ent.ImporteTransfBancaria <> 0 Then
            ent.CCTransferencias.Add(New Entidades.CuentaCorrienteTransferencia() With
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

      My.Application.Log.WriteEntry("Grabo la Cta. Cte. del Cliente.", TraceEventType.Verbose)
      Me.GrabaCuentaCorriente(ent, metodoGrabacion, idFuncion)
      My.Application.Log.WriteEntry("Finaliza la grabación de la Cta. Cte. del Cliente.", TraceEventType.Verbose)

      Dim oCheques = New Reglas.Cheques(da)
      Dim ctacteCheque = New Reglas.CuentasCorrientesCheques(da)
      Dim decTotalCheq = 0D

      For Each cheq In ent.Cheques
         If Not oCheques._Existe(ent.IdSucursal,
                                 cheq.NumeroCheque,
                                 cheq.Banco.IdBanco,
                                 cheq.IdBancoSucursal,
                                 cheq.Localidad.IdLocalidad,
                                 cheq.Cuit) Then
            'Grabo el cheque primero luego cuando grabe caja, ahi relaciona el cheque con el movimiento.
            cheq.IdSucursal = ent.IdSucursal
            cheq.IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA

            If ent.NumeroOrdenCompra <> 0 Then
               cheq.Observacion = String.Format("OC: {0} ", ent.NumeroOrdenCompra.ToString())
            End If

            oCheques.EjecutaSP(cheq, TipoSP._I)
         End If

         If cheq.IdEstadoCheque = Entidades.Cheque.Estados.ALTA Then
            cheq.IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA
         End If

         decTotalCheq = decTotalCheq + cheq.Importe

         'graba la relacion entre el comprobante de cta. cte. y el cheque
         ctacteCheque.GrabaCuentaCorrienteCheque(ent, cheq)

      Next

      Dim idPlanilla As Integer = 0
      Dim NroPlanilla As Integer = 0
      Dim NroMovimiento As Integer = 0

      'si el cliente compro el modulo de caja ingreso el efectivo recibido a la caja
      If Publicos.TieneModuloCaja Then
         My.Application.Log.WriteEntry("Actualizo la caja según el efectivo ingresado en el Recibo.", TraceEventType.Verbose)

         Dim deta = New Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
         Dim rCaja = New Cajas(da)
         Dim rCajaDet = New CajaDetalles(da)

         With deta
            .FechaMovimiento = ent.Fecha   'Date.Now
            .IdCaja = ent.CajaDetalle.IdCaja
            .IdSucursal = ent.IdSucursal
            If ent.ImporteTotal >= 0 Then
               .IdTipoMovimiento = "I"c
            Else
               .IdTipoMovimiento = "E"c
            End If
            .NumeroPlanilla = rCaja.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
            If .NumeroPlanilla = Nothing Then
               .NumeroPlanilla = 1
            End If
            'Si es Ingreso (la mayoria de los casos) podria dar vuelto en Pesos con Cheques. Negativo es Pago a Inversionistas (generalmente solo transferencia).

            .ImportePesos = ent.ImportePesos
            .ImporteDolares = ent.ImporteDolares
            .CotizacionDolar = ent.CotizacionDolar

            .ImporteBancos = Math.Abs(ent.ImporteTransfBancaria)

            'En el caso que se devuelve plata cambio el signo porque despues multiplica por el coef 
            If ent.ImporteTotal < 0 Then
               .ImportePesos = ent.ImportePesos * -1
               .ImporteBancos = ent.ImporteTransfBancaria * -1
            End If

            If .ImporteBancos <> 0 And ent.CuentaBancariaTransfBanc IsNot Nothing Then
               .IdMonedaImporteBancos = ent.CuentaBancariaTransfBanc.Moneda.IdMoneda
            End If

            .ImporteCheques = decTotalCheq
            .ImporteTickets = ent.ImporteTickets
            .ImporteTarjetas = ent.ImporteTarjetas
            .ImporteRetenciones = ent.ImporteRetenciones
            '-- REQ-34389.- -----------------------------------------------------------------------------------------
            .Observacion = String.Format("{0} {1} {2}-{3:00000000} - {4}{5}{6}", ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ObservacionEmbCliente, If(ent.Cheques.Count > 0, String.Format(" - Cantidad Cheques: {0}", ent.Cheques.Count), String.Empty), If(ent.ImporteTransfBancaria <> 0, String.Format(" - Transf. a cuenta: {0}", ent.CuentaBancariaTransfBanc.NombreCuenta), String.Empty)).Truncar(100)
            '--------------------------------------------------------------------------------------------------------
            .IdCuentaCaja = Publicos.CtaCajaRecibos
            .EsModificable = False
            .GeneraContabilidad = False
            .Usuario = actual.Nombre
         End With

         rCajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(ent.Cheques), Nothing)

         idPlanilla = deta.IdCaja
         NroPlanilla = deta.NumeroPlanilla
         NroMovimiento = deta.NumeroMovimiento



         Dim TarjetasAcreditar As Decimal

         For Each tr As Entidades.VentaTarjeta In ent.Tarjetas
            If tr.Tarjeta.Acreditacion Then
               TarjetasAcreditar = TarjetasAcreditar + tr.Monto
            End If
         Next

         If TarjetasAcreditar > 0 Then 'Or ent.ImporteTarjetas > 0 Then

            With deta
               .FechaMovimiento = ent.Fecha
               .IdSucursal = ent.IdSucursal
               .IdTipoMovimiento = "E"c
               .IdCaja = ent.CajaDetalle.IdCaja
               .NumeroPlanilla = rCaja.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
               .ImportePesos = 0
               .ImporteDolares = 0
               .ImporteCheques = 0
               .ImporteTickets = 0
               If TarjetasAcreditar > 0 Then
                  .ImporteTarjetas = TarjetasAcreditar
               Else
                  .ImporteTarjetas = ent.ImporteTarjetas
               End If
               '-- REQ-34389.- -----------------------------------------------------------------------------------------
               .Observacion = String.Format("{0} {1} {2}-{3:00000000} -Deposito de Tarjeta Crédito de: {4}", ent.TipoComprobante.DescripcionAbrev, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ObservacionEmbCliente).Truncar(100)
               '--------------------------------------------------------------------------------------------------------
               .IdCuentaCaja = Publicos.CtaCajaDepositoTarjetas
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
            End With

            rCajaDet.AgregaMovimiento(deta, Nothing, Nothing)

         End If

         'si cargue el movimiento en la caja tengo que actualizar la cta. cte. con los datos de la caja
         Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)
         sql.ActualizoDatosCaja(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante,
                                ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                ent.CajaDetalle.IdCaja, deta.NumeroPlanilla, deta.NumeroMovimiento)

         'Retenciones en Caja

         My.Application.Log.WriteEntry("Grabo las retenciones del Recibo.", TraceEventType.Verbose)
         For Each ret As Entidades.Retencion In ent.Retenciones
            With deta
               .FechaMovimiento = ret.FechaEmision     'Date.Now
               .IdSucursal = ent.IdSucursal
               .IdTipoMovimiento = "E"c
               .IdCaja = ent.CajaDetalle.IdCaja
               .NumeroPlanilla = rCaja.GetPlanillaActual(ent.IdSucursal, ent.CajaDetalle.IdCaja).NumeroPlanilla
               .ImportePesos = 0
               .ImporteCheques = 0
               .ImporteTickets = 0
               .ImporteTarjetas = 0
               .ImporteBancos = 0
               .ImporteRetenciones = ret.ImporteTotal
               '-- REQ-34389.- -----------------------------------------------------------------------------------------
               .Observacion = String.Format("{0} {1} {2}-{3:00000000} - {4} - Retención: {5}", ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ObservacionEmbCliente, ret.NombreTipoImpuesto).Truncar(100)
               '--------------------------------------------------------------------------------------------------------
               .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.TiposImpuestos(da)._GetUno(ret.IdTipoImpuesto).IdCuentaCaja.ToString())
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
            End With

            rCajaDet.AgregaMovimiento(deta, Nothing, Nothing)
         Next

      End If

      'Inserto todas las tarjetas de credito que se pusieron en el Recibo
      If ent.Tarjetas.Count > 0 Then
         Me.ActualizoInfoDeTarjetas(ent, idPlanilla, NroPlanilla, NroMovimiento)
      End If

      Dim oRetenciones As Reglas.Retenciones = New Reglas.Retenciones(da)
      Dim CtacteRetenc As Reglas.CuentasCorrientesRetenciones = New Reglas.CuentasCorrientesRetenciones(da)

      Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)

      My.Application.Log.WriteEntry("Grabo las retenciones del Recibo.", TraceEventType.Verbose)
      For Each ret As Entidades.Retencion In ent.Retenciones

         ret.CajaIngreso.IdCaja = idPlanilla
         ret.NroPlanillaIngreso = NroPlanilla
         ret.NroMovimientoIngreso = NroMovimiento

         oRetenciones._Insertar(ret)

         'graba la relacion entre el comprobante de cta. cte. y el cheque
         CtacteRetenc.GrabaCuentaCorrienteRetencion(ent, ret)

         If ret.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.RIVA Then
            oPF.ActualizarPosicion(actual.Sucursal.IdEmpresa, Integer.Parse(ret.FechaEmision.ToString("yyyyMM")), 0, 0, 0, 0, 0, 0, ret.ImporteTotal, 0)
         End If

      Next


      'si tiene modulo Bancos
      If ent.TipoComprobante.AfectaCaja Then
         If Publicos.TieneModuloBanco Then

            My.Application.Log.WriteEntry("Actualizo los o el Banco con los datos de la Transferencia.", TraceEventType.Verbose)
            Dim oLibroBancos = New Reglas.LibroBancos(da)
            Dim entLibroBanco As Entidades.LibroBanco = Nothing
            Dim oLibBanco = New Reglas.LibroBancos(da)

            '# Multiples transferencias en caso que haya
            If ent.ImporteTransfBancaria <> 0 Then

               ''# Si el importe es <> 0 pero la colección de Transferencias está vacia o es Nothing, quiere decir que proviene de una pantalla donde no se encuentra implementado el cambio.
               ''# Se crea un único registro con el importe de la transferencia realizada.
               'If Not ent.CCTransferencias.AnySecure() Then
               '   If ent.CCTransferencias Is Nothing Then ent.CCTransferencias = New List(Of Entidades.CuentaCorrienteTransferencia) '# La instancio en caso que no lo esté

               '   ent.CCTransferencias.Add(New Entidades.CuentaCorrienteTransferencia With
               '                            {
               '                                 .Orden = ent.CCTransferencias.Count + 1,
               '                                 .Importe = ent.ImporteTransfBancaria,
               '                                 .IdCuentaBancaria = ent.CuentaBancariaTransfBanc.IdCuentaBancaria
               '                            })
               'End If

               For Each transfer In ent.CCTransferencias
                  entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
                  With entLibroBanco

                     .IdSucursal = ent.IdSucursal
                     .IdCuentaBancaria = transfer.IdCuentaBancaria
                     .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                     .IdCuentaBanco = Publicos.CtaBancoTransfBancaria

                     '# Se evalúa el importe TOTAL de la transferencia
                     If ent.ImporteTransfBancaria > 0 Then
                        .IdTipoMovimiento = "I"
                     Else
                        .IdTipoMovimiento = "E"
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
                     .Observacion = String.Format("{0} {1} {2}-{3:00000000} - Transf. a Cuenta. {4}", ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ObservacionEmbCliente).Truncar(100)
                     '--------------------------------------------------------------------------------------------------------
                     .Conciliado = ent.Conciliado

                     '# Por cada transferencia realizada, grabo un movimiento de LibroBanco
                     oLibroBancos.AgregaMovimiento(entLibroBanco)

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

            'Acredito las tarjetas en la cuenta
            Dim entLibroBancoTar As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            Dim oLibBancoTar As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)
            Dim ultimoDia As Date
            Dim diaUltimo As Integer
            Dim cantdias As Integer
            Dim ultimoDiaX As Date
            Dim diaMes As Date
            Dim rCupones = New TarjetasCupones(da)
            For Each tr As Entidades.VentaTarjeta In ent.Tarjetas

               'Solo si tiene configurado el Deposito Automatico. Se analiza Individualmente.
               If tr.Tarjeta.Acreditacion Then

                  With entLibroBancoTar
                     .IdSucursal = ent.IdSucursal
                     .IdCuentaBancaria = tr.Tarjeta.CuentaBancaria.IdCuentaBancaria
                     .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                     .IdCuentaBanco = Publicos.CtaBancoAcredTarjeta
                     .IdTipoMovimiento = "I"
                     .Importe = tr.Monto
                     .FechaMovimiento = ent.Fecha
                     .IdCheque = Nothing
                     If tr.Tarjeta.PagoPosVenta Then
                        .FechaAplicado = ent.Fecha.AddDays(tr.Tarjeta.CantDiasAcredit)
                     Else
                        If tr.Tarjeta.PagoPosCorte Then
                           ultimoDia = DateSerial(Year(ent.Fecha), Month(ent.Fecha) + 1, 0)
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
                     '-- REQ-34389.- -----------------------------------------------------------------------------------------
                     .Observacion = String.Format("{0}({1})Cup:{2}-Ctas({3})-{4} {5} {6}-{7:00000000}({8})", tr.NombreTarjeta, tr.NombreBanco, tr.NumeroCupon, tr.Cuotas, ent.TipoComprobante.Descripcion, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ObservacionEmbCliente).Truncar(100)
                     '--------------------------------------------------------------------------------------------------------
                     .Conciliado = False
                  End With

                  oLibroBancos.AgregaMovimiento(entLibroBancoTar)
                  rCupones.ActualizaEstado(tr.IdTarjetaCupon, Entidades.TarjetaCupon.Estados.ACREDITADO)

               End If

            Next

         End If
      End If

      ent.CCTransferencias.ForEach(
         Sub(transfer)
            With transfer
               .IdSucursal = ent.IdSucursal
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
      Dim rCCTransferencias As New Reglas.CuentasCorrientesTransferencias(da)
      If ent.CCTransferencias IsNot Nothing Then
         For Each transfer In ent.CCTransferencias
            rCCTransferencias._Inserta(transfer)
         Next
      End If
      '--------------------------------------------------------------------------

      My.Application.Log.WriteEntry("Graba asiento contable de Cta Cte.", TraceEventType.Verbose)

      If ent.TipoComprobante.GeneraContabilidad AndAlso Publicos.TieneModuloContabilidad AndAlso Publicos.ContabilidadEjecutarEnLinea Then
         Dim ctbl As Contabilidad = New Contabilidad(da)
         ctbl.RegistraContabilidad(ent)
      End If

      If ent.TipoComprobante.EsReciboClienteVinculado Then
         Dim dicPagos = New Dictionary(Of Long, List(Of Entidades.CuentaCorrientePago))()
         For Each pago As Entidades.CuentaCorrientePago In pagosVinculados
            If Not dicPagos.ContainsKey(pago.IdCliente) Then
               dicPagos.Add(pago.IdCliente, New List(Of Entidades.CuentaCorrientePago))
            End If
            dicPagos(pago.IdCliente).Add(pago)
         Next

         Dim tipoComprobanteSecundario As Entidades.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(ent.TipoComprobante.IdTipoComprobanteSecundario)
         Dim emisor As Short = New Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, tipoComprobanteSecundario.IdTipoComprobante).CentroEmisor
         For Each pagoKV As KeyValuePair(Of Long, List(Of Entidades.CuentaCorrientePago)) In dicPagos
            Dim cliente As Entidades.Cliente = New Reglas.Clientes(da)._GetUno(pagoKV.Key)
            Dim reciboVinculado As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()
            Dim importe As Decimal = 0
            For Each pago As Entidades.CuentaCorrientePago In pagoKV.Value
               importe = importe + pago.ImporteCuota
            Next
            With reciboVinculado
               .TipoComprobante = tipoComprobanteSecundario

               .Letra = tipoComprobanteSecundario.LetrasHabilitadas

               '.CentroEmisor = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, False).CentroEmisor
               .CentroEmisor = emisor

               .Fecha = ent.Fecha

               .FechaVencimiento = .Fecha

               .FormaPago = ent.FormaPago

               'cargo el cliente ----------
               .Cliente = cliente

               .Vendedor = ent.Vendedor

               .Observacion = ent.Observacion

               'cargo valores del comprobante
               .ImporteTotal = importe

               'cargo los comprobantes
               .Pagos = pagoKV.Value

               'cargo el efectivo para tenerlo discriminado
               .ImportePesos = importe
               .ImporteDolares = 0
               .ImporteTickets = 0
               .ImporteTarjetas = 0
               'cargo los cheques
               '.Cheques = Me._cheques
               '.ImporteCheques = Decimal.Parse(Me.txtCheques.Text)
               '.Tarjetas = Me._tarjetas

               'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) <> 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
               '   .ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text)
               '   .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
               '   .Conciliado = conciliado
               'End If

               'cargo las Retenciones
               '.Retenciones = Me._retenciones
               '.ImporteRetenciones = Decimal.Parse(Me.txtRetenciones.Text)

               'cargo la caja
               .CajaDetalle = ent.CajaDetalle

               .Cobrador = ent.Cobrador
               .EstadoCliente = ent.EstadoCliente

               'cargo datos generales del comprobante
               .IdSucursal = actual.Sucursal.Id
               .Usuario = actual.Nombre
               .IdEstado = "NORMAL"


               .IdClienteCtaCte = ent.Cliente.IdCliente


               .IdCategoria = ent.Cliente.IdCategoria

               '.SaldoCtaCte = Decimal.Parse(Me.txtSaldoActual.Text.ToString()) - Decimal.Parse(Me.txtTotalPagos.Text.ToString())

               .IdSucursalVinculado = ent.IdSucursal
               .IdTipoComprobanteVinculado = ent.TipoComprobante.IdTipoComprobante
               .LetraVinculado = ent.Letra
               .CentroEmisorVinculado = ent.CentroEmisor
               .NumeroComprobanteVinculado = ent.NumeroComprobante
               .CotizacionDolar = ent.CotizacionDolar

            End With
            Inserta(reciboVinculado, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
         Next

      End If

      'Throw New ApplicationException("Corte para pruebas")

      My.Application.Log.WriteEntry("Finaliza la inserción de un Recibo a la Cta. Cte.", TraceEventType.Verbose)

   End Sub

   Private Sub CargarUna(dr As DataRow, o As Entidades.CuentaCorriente)
      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr("IdTipoComprobante").ToString())
         .Letra = dr("Letra").ToString()
         .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
         .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
         .Fecha = Date.Parse(dr("Fecha").ToString())
         .FechaVencimiento = Date.Parse(dr("FechaVencimiento").ToString())
         .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString()) * .TipoComprobante.CoeficienteValores
         .Cliente = New Reglas.Clientes(da)._GetUno(Long.Parse(dr("IdCliente").ToString()))
         .IdCategoria = dr.ValorNumericoPorDefecto(Entidades.CuentaCorriente.Columnas.IdCategoria.ToString(), 0I)
         .Vendedor = New Reglas.Empleados(da).GetUno(Integer.Parse(dr("IdVendedor").ToString()))
         If Not String.IsNullOrEmpty(dr("IdFormasPago").ToString()) Then
            If Integer.Parse(dr("IdFormasPago").ToString()) <> 0 Then
               .FormaPago = New Reglas.VentasFormasPago(da).GetUna(Integer.Parse(dr("IdFormasPago").ToString()))
            End If
         End If
         .Observacion = dr("Observacion").ToString()
         If Not String.IsNullOrEmpty(dr("Saldo").ToString()) Then
            .Saldo = Decimal.Parse(dr("Saldo").ToString())
         End If
         .CantidadCuotas = Integer.Parse(dr("CantidadCuotas").ToString())
         .ImportePesos = Decimal.Parse(dr("ImportePesos").ToString())
         .ImporteDolares = Decimal.Parse(dr("ImporteDolares").ToString())
         .ImporteTickets = Decimal.Parse(dr("ImporteTickets").ToString())
         .ImporteTarjetas = Decimal.Parse(dr("ImporteTarjetas").ToString())
         .ImporteCheques = Decimal.Parse(dr("ImporteCheques").ToString())
         If Not String.IsNullOrEmpty(dr("ImporteTransfBancaria").ToString()) Then
            .ImporteTransfBancaria = Decimal.Parse(dr("ImporteTransfBancaria").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("IdCuentaBancaria").ToString()) Then
            .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias(da).GetUna(Integer.Parse(dr("IdCuentaBancaria").ToString()))
         End If

         .ImporteRetenciones = Decimal.Parse(dr("ImporteRetenciones").ToString())


         .Pagos = New CuentasCorrientesPagos(da).GetPorCuentaCorriente(o)

         .Cheques = New Cheques(da).GetPorCuentaCorriente(.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante)

         .Tarjetas = New CuentasCorrientesTarjetas(da).GetTodosAsVentasTarjetas(.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante)

         .CCTransferencias = New CuentasCorrientesTransferencias(da).GetTodos(.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante)

         .Retenciones = New Retenciones(da).GetPorCuentaCorriente(.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, .Cliente.IdCliente)

         If Not String.IsNullOrEmpty(dr("IdCaja").ToString()) Then
            .CajaDetalle = New CajaDetalles(da)._GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                        Integer.Parse(dr("IdCaja").ToString()),
                                                        Integer.Parse(dr("NumeroPlanilla").ToString()),
                                                        Integer.Parse(dr("NumeroMovimiento").ToString()))
         End If

         If Not String.IsNullOrEmpty(dr("IdClienteCtaCte").ToString()) Then
            .IdClienteCtaCte = Long.Parse(dr("IdClienteCtaCte").ToString())
         End If

         'Si esta nulo es un Recibo antiguo que no lo grabo. Va a mostrar el saldo Actual.
         If Not String.IsNullOrEmpty(dr("SaldoCtaCte").ToString()) Then
            .SaldoCtaCte = Decimal.Parse(dr("SaldoCtaCte").ToString())
         End If

         If Not IsDBNull(dr("IdEjercicio")) Then
            .IdEjercicio = CInt(dr("IdEjercicio"))
         End If

         If Not IsDBNull(dr("IdPlanCuenta")) Then
            .IdPlanCuenta = CInt(dr("IdPlanCuenta"))
         End If

         If Not IsDBNull(dr("IdAsiento")) Then
            .IdAsiento = CInt(dr("IdAsiento"))
         End If

         .MetodoGrabacionCampo = Entidades.Entidad.ParseMetodoGrabacion(dr(Entidades.CuentaCorriente.Columnas.MetodoGrabacion.ToString()).ToString())
         .IdFuncion = dr(Entidades.CuentaCorriente.Columnas.IdFuncion.ToString()).ToString()

         If Not String.IsNullOrWhiteSpace(dr("ImprimeSaldos").ToString()) Then
            .ImprimeSaldos = Boolean.Parse(dr("ImprimeSaldos").ToString())
         Else
            .ImprimeSaldos = True
         End If

         If IsNumeric(dr(Entidades.CuentaCorriente.Columnas.NumeroOrdenCompra.ToString())) Then
            .NumeroOrdenCompra = Long.Parse(dr(Entidades.CuentaCorriente.Columnas.NumeroOrdenCompra.ToString()).ToString())
         End If

         .Referencia = dr(Entidades.CuentaCorriente.Columnas.Referencia.ToString()).ToString()

         .CotizacionDolar = Decimal.Parse(dr(Entidades.CuentaCorriente.Columnas.CotizacionDolar.ToString()).ToString())

         If Not String.IsNullOrEmpty(dr("FechaTransferencia").ToString()) Then
            .FechaTransferencia = Date.Parse(dr("FechaTransferencia").ToString())
         End If

         .Direccion = dr(Entidades.CuentaCorriente.Columnas.Direccion.ToString()).ToString()
         .IdLocalidad = Integer.Parse(dr(Entidades.CuentaCorriente.Columnas.IdLocalidad.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr("FechaViaje").ToString()) Then
            .FechaViaje = Date.Parse(dr("FechaViaje").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("NombreEstablecimiento").ToString()) Then
            .NombreEstablecimiento = dr(Entidades.CuentaCorriente.Columnas.NombreEstablecimiento.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr("NombrePrograma").ToString()) Then
            .NombrePrograma = dr(Entidades.CuentaCorriente.Columnas.NombrePrograma.ToString()).ToString()
         End If

         '-- REQ-31710.- -------------------------------------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(dr("idTipoNovedad").ToString()) Then
            .IdTipoNovedad = dr(Entidades.CuentaCorriente.Columnas.IdTipoNovedad.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr("LetraNovedad").ToString()) Then
            .LetraNovedad = dr(Entidades.CuentaCorriente.Columnas.LetraNovedad.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr("CentroEmisorNovedad").ToString()) Then
            .CentroEmisorNovedad = Short.Parse(dr(Entidades.CuentaCorriente.Columnas.CentroEmisorNovedad.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr("NumeroNovedad").ToString()) Then
            .NumeroNovedad = Long.Parse(dr(Entidades.CuentaCorriente.Columnas.NumeroNovedad.ToString()).ToString())
         End If
         '-- REQ-33289.- -------------------------------------------------------------------------------------------------------
         If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
            .IdEmbarcacion = dr.Field(Of Long?)(Entidades.CuentaCorriente.Columnas.IdEmbarcacion.ToString()).IfNull()
            .NombreEmbarcacion = dr.Field(Of String)(Entidades.CuentaCorriente.Columnas.NombreEmbarcacion.ToString()).IfNull()
            .NombreCategoriaEmbarcacion = dr.Field(Of String)(Entidades.CuentaCorriente.Columnas.NombreCategoriaEmbarcacion.ToString()).IfNull()
         End If
         '-- REQ-36331.- -------------------------------------------------------------------------------------------------------
         If New Reglas.Generales().ExisteTabla("Camas") Then
            .IdCama = dr.Field(Of Long?)(Entidades.CuentaCorriente.Columnas.IdCama.ToString()).IfNull()
         End If
         '-- REQ-42455.- -------------------------------------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(dr("FechaPromedioCobro").ToString()) Then
            .FechaPromedioCobro = Date.Parse(dr("FechaPromedioCobro").ToString())
         End If
         .PromedioDiasCobro = dr.Field(Of Decimal?)(Entidades.CuentaCorriente.Columnas.PromedioDiasCobro.ToString())
         .CantidadDiasCobro = dr.Field(Of Decimal?)(Entidades.CuentaCorriente.Columnas.CantidadDiasCobro.ToString())
         '----------------------------------------------------------------------------------------------------------------------
      End With
   End Sub

   Private Sub SelectFiltrado(ByRef stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT CTA.IdSucursal")
         .AppendLine("      ,CTA.IdTipoComprobante")
         .AppendLine("      ,CTA.Letra")
         .AppendLine("      ,CTA.CentroEmisor")
         .AppendLine("      ,CTA.NumeroComprobante")
         .AppendLine("      ,CTA.Fecha")
         .AppendLine("      ,CTA.FechaVencimiento")
         .AppendLine("      ,CTA.ImporteTotal")
         .AppendLine("      ,CTA.IdCliente")
         .AppendLine("      ,CTA.IdCategoria")
         .AppendLine("      ,CTA.IdFormasPago")
         .AppendLine("      ,CTA.Observacion")
         .AppendLine("      ,CTA.Saldo")
         .AppendLine("      ,CTA.CantidadCuotas")
         .AppendLine("      ,CTA.ImportePesos")
         .AppendLine("      ,CTA.ImporteDolares")
         .AppendLine("      ,CTA.ImporteTickets")
         .AppendLine("      ,CTA.ImporteTarjetas")
         .AppendLine("      ,CTA.ImporteCheques")
         .AppendLine("      ,CTA.ImporteTransfbancaria")
         .AppendLine("      ,CTA.ImporteRetenciones")
         .AppendLine("      ,CTA.IdCuentaBancaria")
         .AppendLine("      ,CTA.IdVendedor")
         .AppendLine("      ,CTA.IdCaja")
         .AppendLine("      ,CTA.NumeroPlanilla")
         .AppendLine("      ,CTA.NumeroMovimiento")
         .AppendLine("      ,CTA.IdClienteCtaCte")
         .AppendLine("      ,CTA.SaldoCtaCte")
         .AppendLine("      ,CTA.IdEjercicio")
         .AppendLine("      ,CTA.IdPlanCuenta")
         .AppendLine("      ,CTA.IdAsiento")
         .AppendLine("      ,CTA.MetodoGrabacion")
         .AppendLine("      ,CTA.IdFuncion")
         .AppendLine("      ,CTA.ImprimeSaldos")
         .AppendLine("      ,CTA.NumeroOrdenCompra")
         .AppendLine("      ,CTA.Referencia")
         .AppendLine("      ,CTA.CotizacionDolar")
         .AppendLine("      ,CTA.FechaTransferencia")
         .AppendLine("      ,CTA.Direccion")
         .AppendLine("      ,CTA.IdLocalidad")
         .AppendLine("      ,CTA.FechaViaje")
         .AppendLine("      ,CTA.NombreEstablecimiento")
         .AppendLine("      ,CTA.NombrePrograma")
         '-- REQ-31710.- --
         .AppendLine("      ,CTA.IdTipoNovedad")
         .AppendLine("      ,CTA.LetraNovedad")
         .AppendLine("      ,CTA.CentroEmisorNovedad")
         .AppendLine("      ,CTA.NumeroNovedad")
         '-- REQ-42455.- --
         .AppendLine("      ,CTA.FechaPromedioCobro")
         .AppendLine("      ,CTA.PromedioDiasCobro")
         .AppendLine("      ,CTA.CantidadDiasCobro")

         If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
            .AppendLine("      ,EMB.IdEmbarcacion")
            .AppendLine("      ,EMB.NombreEmbarcacion")
            .AppendLine("      ,CEMB.NombreCategoriaEmbarcacion")
            .AppendLine("      ,CMS.IdCama")
            .AppendLine("      ,CMS.CodigoCama")
            .AppendLine("      ,CMS.IdNave")
            .AppendLine("      ,NAV.NombreNave")
            .AppendLine("      ,CMS.IdCategoriaCama")
            .AppendLine("      ,CTC.NombreCategoriaCama")
            .AppendLine("  FROM CuentasCorrientes CTA")
            .AppendLine("  LEFT JOIN Embarcaciones EMB ON CTA.IdEmbarcacion = EMB.IdEmbarcacion")
            .AppendLine("  LEFT JOIN CategoriasEmbarcaciones CEMB ON EMB.IdCategoriaEmbarcacion = CEMB.IdCategoriaEmbarcacion")
            .AppendLine("  LEFT JOIN Camas CMS ON CTA.IdCama = CMS.IdCama")
            .AppendLine("  LEFT JOIN Naves NAV ON NAV.IdNave = CMS.IdNave")
            .AppendLine("  LEFT JOIN CategoriasCamas CTC ON CTC.IdCategoriaCama = CMS.IdCategoriaCama")
         Else
            .AppendLine("  FROM CuentasCorrientes CTA")
         End If

      End With
   End Sub

   Public Sub EliminarCtaCteDirecta(ctactes As List(Of Entidades.CuentaCorriente))
      EjecutaConTransaccion(Sub() _EliminarCtaCteDirecta(ctactes))
   End Sub
   Private Sub _EliminarCtaCteDirecta(ctactes As List(Of Entidades.CuentaCorriente))
      'Borro las Cuotas
      For Each ent In ctactes
         If Publicos.TieneModuloContabilidad Then
            Dim ctblEjercicio = New ContabilidadEjercicios(da)
            ctblEjercicio.EstaPeriodoCerrado(ent.Fecha)
         End If

         Dim rCCP = New Reglas.CuentasCorrientesPagos(da)
         Dim rCD = New Reglas.ClientesDeudas(da)
         For Each pag In ent.Pagos
            pag.CuentaCorriente = ent
            rCCP.Eliminar(pag)
         Next

         'Borro la Cabecera
         Dim sql = New SqlServer.CuentasCorrientes(da)
         sql.CuentasCorrientes_D(ent.IdSucursal,
                                 ent.TipoComprobante.IdTipoComprobante,
                                 ent.Letra,
                                 ent.CentroEmisor,
                                 ent.NumeroComprobante)

         rCD.ActualizarDatosCtaCte(ent)
      Next
   End Sub

   Public Sub ModificarCtaCte(ctacte As Entidades.CuentaCorriente)
      EjecutaConTransaccion(Sub() _ModificarCtaCte(ctacte))
   End Sub
   Private Sub _ModificarCtaCte(ctacte As Entidades.CuentaCorriente)
      Dim sql = New SqlServer.CuentasCorrientes(da)
      sql.CuentasCorrientes_ModificaCtaCte(
         ctacte.IdSucursal,
         ctacte.TipoComprobante.IdTipoComprobante,
         ctacte.Letra,
         ctacte.CentroEmisor,
         ctacte.NumeroComprobante,
         ctacte.Referencia)
   End Sub

   Public Function GetProximoNumeroCC(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer) As Long
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT MAX(NumeroComprobante) AS Numero")
         .AppendFormatLine("  FROM CuentasCorrientes")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letraFiscal)
         .AppendFormatLine("   AND CentroEmisor = {0}", emisor)
      End With

      Dim dt = da.GetDataTable(stb.ToString())
      Dim val As Long = 1
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Numero").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Numero").ToString()) + 1
         End If
      End If
      Return val
   End Function

   Private Sub ActualizoInfoDeTarjetas(oCtaCte As Entidades.CuentaCorriente, idPlanilla As Integer, NroPlanilla As Integer, NroMovimiento As Integer)
      Dim sql = New SqlServer.CuentasCorrientesTarjetas(da)

      'Dim idTarjetaCupon As Integer = 0

      Dim rTarjetasCupones = New TarjetasCupones(da)

      Dim rSituacionCupon = New SituacionCupones(da).GetPorDefecto()

      For Each tr As Entidades.VentaTarjeta In oCtaCte.Tarjetas

         If tr.IdTarjetaCupon = 0 Then
            tr.IdTarjetaCupon = rTarjetasCupones.GetCodigoMaximo
         End If

         If tr.Orden = 0 Then
            tr.Orden = Math.Max(oCtaCte.Tarjetas.MaxSecure(Function(t) t.Orden).IfNull() + 1,
                                sql.GetOrdenMaximo(oCtaCte.IdSucursal, oCtaCte.TipoComprobante.IdTipoComprobante, oCtaCte.Letra, oCtaCte.CentroEmisor, oCtaCte.NumeroComprobante) + 1)
         End If

         If Not rTarjetasCupones.Existe(tr.IdTarjetaCupon) Then
            rTarjetasCupones._Insertar(tr.IdTarjetaCupon,
                                       oCtaCte.IdSucursal,
                                       tr.Tarjeta.IdTarjeta,
                                       tr.Banco.IdBanco,
                                       tr.Monto,
                                       tr.Cuotas,
                                       tr.NumeroLote,
                                       tr.NumeroCupon,
                                       Date.Now,
                                       Entidades.TarjetaCupon.Estados.ENCARTERA,
                                       idPlanilla, '-.PE-32195.-
                                       NroPlanilla,
                                       NroMovimiento,
                                       Nothing,
                                       Nothing,
                                       Nothing,
                                       actual.Nombre,
                                       Date.Now,
                                       oCtaCte.IdClienteCtaCte,
                                       0, rSituacionCupon.IdSituacionCupon)
         End If

         sql.CuentasCorrientesTarjetas_I(oCtaCte.IdSucursal,
                                         oCtaCte.TipoComprobante.IdTipoComprobante,
                                         oCtaCte.Letra,
                                         oCtaCte.CentroEmisor,
                                         oCtaCte.NumeroComprobante,
                                         tr.Orden,
                                         tr.Tarjeta.IdTarjeta,
                                         tr.Banco.IdBanco,
                                         tr.Monto,
                                         tr.Cuotas,
                                         tr.NumeroCupon,
                                         tr.NumeroLote,
                                         tr.IdTarjetaCupon)
      Next

   End Sub

#End Region

   Public Function GrabarPagoDeFichas(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Short,
                                      nroOperacion As Long,
                                      fecha As Date,
                                      importe As Decimal,
                                      interes As Decimal,
                                      vendedor As Entidades.Empleado,
                                      idCaja As Integer,
                                      concepto As String,
                                      cobrador As Entidades.Empleado,
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                      idFuncion As String,
                                      cancelarFicha As Boolean) As Entidades.CuentaCorriente

      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

      If blnAbreConexion Then da.OpenConection()
      Try
         If blnAbreConexion Then da.BeginTransaction()
         Dim _ComprobantesGrilla As New List(Of Entidades.CuentaCorrientePago)

         Dim tag As String = "GrabarPagoDeFichas"
         My.Application.Log.WriteEntry(String.Format("{0}/{6:HH:mm:ss}/{1} {2} {3:0000}-{4:00000000} - {5}", tag, idTipoComprobante, letra, centroEmisor, nroOperacion, "Inicio cobranza", Now), TraceEventType.Verbose)

         ' Verifico si se va a Cancelar una Ficha o se va a emitir un Recibo por un Pago
         Dim tipoRecibo As Entidades.TipoComprobante
         If cancelarFicha Then
            tipoRecibo = New Reglas.TiposComprobantes().GetUno("MINUTAPROV")
         Else
            tipoRecibo = New Reglas.TiposComprobantes().GetUno("RECIBOPROV")
         End If

         ' Consulto la entidad de la sucursal
         Dim sucursal As Entidades.Sucursal = New Reglas.Sucursales(da).GetUna(idSucursal, False)

         Dim rCC As CuentasCorrientes = New CuentasCorrientes(da)
         Dim rVenta As Ventas = New Ventas(da)
         Dim rProducto As Productos = New Productos(da)

         My.Application.Log.WriteEntry(String.Format("{0}/{6:HH:mm:ss}/{1} {2} {3:0000}-{4:00000000} - {5}", tag, idTipoComprobante, letra, centroEmisor, nroOperacion, "Antes de buscar", Now), TraceEventType.Verbose)
         Dim ficha As Entidades.Venta = rVenta.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, nroOperacion)
         My.Application.Log.WriteEntry(String.Format("{0}/{6:HH:mm:ss}/{1} {2} {3:0000}-{4:00000000} - {5}", tag, idTipoComprobante, letra, centroEmisor, nroOperacion, "Después de buscar", Now), TraceEventType.Verbose)

         Dim oCtaCteFicha = ficha.CuentaCorriente 'rCC._GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, nroOperacion)

         Dim CCP As Eniac.Entidades.CuentaCorrientePago = New Eniac.Entidades.CuentaCorrientePago()
         ''Dim OCCP As Eniac.Reglas.CuentasCorrientesPagos = New Eniac.Reglas.CuentasCorrientesPagos()
         Dim importeAPagar As Decimal = importe
         Dim paga As Decimal
         For Each comp As Eniac.Entidades.CuentaCorrientePago In oCtaCteFicha.Pagos
            If comp.SaldoCuota <> 0 And importeAPagar > 0 Then
               paga = Math.Min(importeAPagar, comp.SaldoCuota)
               comp.Paga = paga
               _ComprobantesGrilla.Add(comp)
               importeAPagar -= paga
            End If
         Next

         If importeAPagar <> 0 Then
            Throw New Exception("El importe que quiere cancelar es mayor al saldo")
         End If

         If cancelarFicha Then
            interes = importe * -1
         End If

         My.Application.Log.WriteEntry(String.Format("{0}/{6:HH:mm:ss}/{1} {2} {3:0000}-{4:00000000} - {5}", tag, idTipoComprobante, letra, centroEmisor, nroOperacion, "Antes de generar intereses", Now), TraceEventType.Verbose)

         If interes <> 0 Then
            Dim ventaInteres As Entidades.Venta
            Dim IdTipoComprobanteCredDeb As String = String.Empty
            Dim idProducto As String = String.Empty

            If interes > 0 Then
               If Not String.IsNullOrWhiteSpace(tipoRecibo.IdTipoComprobanteNDeb) Then
                  IdTipoComprobanteCredDeb = tipoRecibo.IdTipoComprobanteNDeb
               Else
                  IdTipoComprobanteCredDeb = Publicos.IdNotaDebitoNoGrabaLibro
               End If
               If Not String.IsNullOrWhiteSpace(tipoRecibo.IdProductoNDeb) Then
                  idProducto = tipoRecibo.IdProductoNDeb
               Else
                  idProducto = Reglas.Publicos.CtaCte.IDProductoDescuentoRecargo
               End If
            ElseIf interes < 0 Then
               If Not String.IsNullOrWhiteSpace(tipoRecibo.IdTipoComprobanteNCred) Then
                  IdTipoComprobanteCredDeb = tipoRecibo.IdTipoComprobanteNCred
               Else
                  IdTipoComprobanteCredDeb = Publicos.IdNotaCreditoNoGrabaLibro
               End If
               If Not String.IsNullOrWhiteSpace(tipoRecibo.IdProductoNCred) Then
                  idProducto = tipoRecibo.IdProductoNCred
               Else
                  idProducto = Reglas.Publicos.CtaCte.IDProductoDescuentoRecargo
               End If
            End If

            ' # Resuelto con Seba y Augusto.
            ' # Si se va a cancelar la ficha se hardcodea que el Tipo de Comprobante sea NCFICHAS.
            If cancelarFicha Then
               IdTipoComprobanteCredDeb = "NCFICHAS"
            End If

            If Not rProducto.Existe(idProducto) Then
               Throw New Exception(String.Format("No se puede registrar la '{0}' por los Intereses." + Environment.NewLine +
                                                 "El producto '{1}' no existe." + Environment.NewLine + Environment.NewLine +
                                                 "Verifique la configuración.",
                                                 IdTipoComprobanteCredDeb, idProducto))
            End If

            ventaInteres = rVenta.GrabarComprobante(idSucursal,
                                                    IdTipoComprobanteCredDeb,
                                                    oCtaCteFicha.Cliente.IdCliente,
                                                    idCaja,
                                                    fecha,
                                                    vendedor,
                                                    oCtaCteFicha.FormaPago.IdFormasPago,
                                                    concepto,
                                                    If(cancelarFicha, interes * -1, interes),
                                                    idProducto,
                                                    1,
                                                    observacionDetalladas:=Nothing,
                                                    solicitaCAE:=True,
                                                    contactos:=Nothing,
                                                    nombreProducto:=concepto,
                                                    cobrador:=cobrador,
                                                    comprobantesAsociados:={},
                                                    idEmbarcacion:=0,
                                                    metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Automatico,
                                                    idFuncion:=idFuncion)

            Dim oLineaDetalle As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()

            With oLineaDetalle
               .TipoComprobante = ventaInteres.TipoComprobante
               .Letra = ventaInteres.LetraComprobante
               .CentroEmisor = ventaInteres.CentroEmisor
               .NumeroComprobante = ventaInteres.NumeroComprobante
               .Cuota = 1
               .FechaEmision = ventaInteres.Fecha
               .FechaVencimiento = ventaInteres.Fecha
               .ImporteCuota = ventaInteres.ImporteTotal
               .SaldoCuota = ventaInteres.ImporteTotal
               .Paga = ventaInteres.ImporteTotal
               .DescuentoRecargoPorc = 0
               .DescuentoRecargo = 0
               .IdSucursal = idSucursal
               .Usuario = actual.Nombre
            End With

            _ComprobantesGrilla.Add(oLineaDetalle)
         End If

         My.Application.Log.WriteEntry(String.Format("{0}/{6:HH:mm:ss}/{1} {2} {3:0000}-{4:00000000} - {5}", tag, idTipoComprobante, letra, centroEmisor, nroOperacion, "Antes de crear CtaCte del Recibo", Now), TraceEventType.Verbose)

         'Dim oReglasCuentaCorriente As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
         Dim oCtaCteRecibo As Eniac.Entidades.CuentaCorriente = New Eniac.Entidades.CuentaCorriente()

         With oCtaCteRecibo
            .IdSucursal = idSucursal
            .Letra = tipoRecibo.LetrasHabilitadas
            .TipoComprobante = tipoRecibo
            '.CentroEmisor = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, False).CentroEmisor
            '.CentroEmisor = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(idSucursal, My.Computer.Name, "RECIBOPROV").CentroEmisor
            .CentroEmisor = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(idSucursal, My.Computer.Name, tipoRecibo.IdTipoComprobante).CentroEmisor

            Dim oventasnum As Eniac.Reglas.VentasNumeros = New Eniac.Reglas.VentasNumeros

            ' # OBSOLETE
            '.NumeroComprobante = oventasnum.GetProximoNumero(idSucursal, "RECIBOPROV", "X", .CentroEmisor)
            .NumeroComprobante = oventasnum.GetProximoNumero(sucursal, .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor)

            .Fecha = fecha
            .FechaVencimiento = .Fecha

            .FormaPago = New Eniac.Reglas.VentasFormasPago().GetUna("VENTAS", True) 'Contado

            'cargo el cliente ----------
            Dim ocli As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
            .Cliente = oCtaCteFicha.Cliente
            .IdCategoria = .Cliente.IdCategoria

            'Dim ocobrador As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados()

            .Vendedor = vendedor
            .Cobrador = cobrador

            .Observacion = concepto

            'cargo valores del comprobante
            .ImporteTotal = importe + interes

            'cargo los comprobantes
            .Pagos = _ComprobantesGrilla

            'cargo el efectivo para tenerlo discriminado
            .ImportePesos = importe + interes
            .ImporteDolares = 0
            .ImporteTickets = 0
            .ImporteTarjetas = 0

            'cargo los cheques
            '.Cheques = Me._cheques
            '.ImporteCheques = Decimal.Parse(Me.txtCheques.Text)


            'cargo la caja
            .CajaDetalle.IdCaja = idCaja

            'cargo datos generales del comprobante
            '.IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre

         End With

         My.Application.Log.WriteEntry(String.Format("{0}/{6:HH:mm:ss}/{1} {2} {3:0000}-{4:00000000} - {5}", tag, idTipoComprobante, letra, centroEmisor, nroOperacion, "Antes de Insertar cobranza", Now), TraceEventType.Verbose)

         Inserta(oCtaCteRecibo, metodoGrabacion, idFuncion)

         My.Application.Log.WriteEntry(String.Format("{0}/{6:HH:mm:ss}/{1} {2} {3:0000}-{4:00000000} - {5}", tag, idTipoComprobante, letra, centroEmisor, nroOperacion, "Después de Insertar cobranza", Now), TraceEventType.Verbose)

         If blnAbreConexion Then da.CommitTransaction()
         Return oCtaCteRecibo
      Catch 'ex As Exception
         If blnAbreConexion Then da.RollbakTransaction()
         Throw 'New Exception(ex.Message, ex)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Function

   Public Function GetCoeficienteCobranzas(sucursales As Entidades.Sucursal(),
                                           fechaDesde As Date, fechaHasta As Date,
                                           idCliente As Long,
                                           idCategoria As Integer, categoria As Entidades.OrigenFK,
                                           IdVendedor As Integer, vendedor As Entidades.OrigenFK,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                           idUsuario As String,
                                           idCaja As Integer,
                                           idZonaGeografica As String,
                                           idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                           idEstadoCliente As Integer, estdoCliente As Entidades.OrigenFK,
                                           modalidad As Entidades.EnumSql.GetCoeficienteCobranzasModalidad) As DataTable
      Return New SqlServer.CuentasCorrientes(da).GetCoeficienteCobranzas(sucursales,
                                                                         fechaDesde, fechaHasta,
                                                                         idCliente,
                                                                         idCategoria, categoria,
                                                                         IdVendedor, vendedor,
                                                                         idTipoComprobante, letraFiscal, centroEmisor, numeroComprobante,
                                                                         idUsuario,
                                                                         idCaja,
                                                                         idZonaGeografica,
                                                                         idCobrador, cobrador,
                                                                         idEstadoCliente, estdoCliente,
                                                                         modalidad)
   End Function

   Public Function GetInfNoCobranzas(idCliente As Long,
                                     fechaDesde As Date,
                                     fechaHasta As Date,
                                     idLocalidad As Integer,
                                     idProvincia As String,
                                     idCategoria As Integer,
                                     idZonaGeografica As String) As DataTable
      Dim sql = New SqlServer.CuentasCorrientes(da)

      Return sql.GetInfNoCobranzas(idCliente, fechaDesde, fechaHasta, idLocalidad, idProvincia, idCategoria, idZonaGeografica)
   End Function

   Public Function GetInfVentasCobranzas(fechaDesde As Date,
                                         fechaHasta As Date,
                                         idCliente As Long,
                                         idVendedor As Integer,
                                         vendedor As Entidades.OrigenFK,
                                         idCobrador As Integer,
                                         cobrador As Entidades.OrigenFK,
                                         sucursales As Entidades.Sucursal()) As DataTable

      Return New SqlServer.CuentasCorrientes(da).GetInfVentasCobranzas(fechaDesde,
                                                                       fechaHasta,
                                                                       idCliente,
                                                                       idVendedor,
                                                                       vendedor,
                                                                       idCobrador,
                                                                       cobrador,
                                                                       sucursales)

   End Function
   Public Function GetCobrSemana(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date, idCliente As Long,
                                 IdVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                 idCategoria As Integer, origenCategoria As Entidades.OrigenFK,
                                 idCobrador As Integer, origenCobrador As Entidades.OrigenFK) As DataTable
      Dim PivotcolName = New StringBuilder()
      Dim SumPivot = New StringBuilder()

      Dim fecha As Date = desde.LunesAnterior()
      Dim semana As Integer = desde.SemanaDelAnio()
      Dim anoActual As Integer = desde.Year

      PivotcolName.AppendFormat("[{0:0000}-{1}]", fecha.Year, semana)
      SumPivot.AppendFormat("SUM([{0:0000}-{1}]) as [{0:0000}-{1}]", fecha.Year, semana)
      While CDate(fecha) < CDate(hasta)
         fecha = fecha.AddDays(7)
         If anoActual < fecha.Year Then
            If fecha.SemanaDelAnio > 1 Then
               semana = 1
               PivotcolName.AppendFormat(",[{0:0000}-{1}]", fecha.Year, semana)
               SumPivot.AppendFormat(",SUM([{0:0000}-{1}]) as [{0:0000}-{1}]", fecha.Year, semana)
            End If
         End If
         anoActual = fecha.Year
         semana = fecha.SemanaDelAnio
         PivotcolName.AppendFormat(",[{0:0000}-{1}]", fecha.Year, semana)
         SumPivot.AppendFormat(",SUM([{0:0000}-{1}]) as [{0:0000}-{1}]", fecha.Year, semana)
      End While

      Dim dt As DataTable
      dt = New SqlServer.CuentasCorrientes(da).GetCobrSemana(sucursales, desde, hasta, idCliente,
                                                             IdVendedor, origenVendedor,
                                                             idCategoria, origenCategoria,
                                                             idCobrador, origenCobrador,
                                                             PivotcolName.ToString(), SumPivot.ToString())

      Dim pivotColNameSplit As String() = PivotcolName.ToString().Split(","c)
      For Each dr As DataRow In dt.Select("Saldo = 0")
         Dim total As Decimal = 0
         For Each col As String In pivotColNameSplit
            Dim col2 As String = col.Trim("["c).Trim("]"c)
            If IsNumeric(dr(col2)) Then
               total += Decimal.Parse(dr(col2).ToString())
            End If
         Next
         If total = 0 Then
            dr.Delete()
         End If
      Next
      dt.AcceptChanges()

      Return dt
   End Function

   Public Sub ActualizaFechaExportacion(recibo As Entidades.CuentaCorriente, fechaActualizacion As Date)
      EjecutaConTransaccion(Sub() _ActualizaFechaExportacion(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante, recibo.Letra, recibo.CentroEmisor, recibo.NumeroComprobante, fechaActualizacion))
   End Sub

   Public Sub _ActualizaFechaExportacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long, fechaActualizacion As Date)
      Dim sql = New SqlServer.CuentasCorrientes(da)
      sql.CuentasCorrientes_U_FechaExportacion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaActualizacion)
   End Sub

   Public Sub _ActualizaDatosReserva(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Short,
                                          numeroComprobante As Long,
                                          FechaViaje As Date,
                                          Establecimiento As String,
                                          Programa As String)

      Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)
      sql.CuentasCorrientes_U_DatosReserva(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, FechaViaje, Establecimiento, Programa)

   End Sub

   Public Sub ActualizaFechaEnvioCorreo(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Short,
                                        numeroComprobante As Long,
                                        fechaEnvioCorreo As Date?)
      EjecutaConTransaccion(
         Sub()
            Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)
            sql.ActualizaFechaEnvioCorreo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaEnvioCorreo)
         End Sub)
   End Sub

   Public Sub ComprobanteConPagoAPlicado(_recibo As Entidades.CuentaCorriente)
      ComprobanteConPagoAPlicado(_recibo.IdSucursal, _recibo.TipoComprobante, _recibo.Letra, _recibo.CentroEmisor, _recibo.NumeroComprobante)
   End Sub
   Public Sub ComprobanteConPagoAPlicado(idSucursal As Integer, tipoComprobante As Entidades.TipoComprobante, letra As String, centroEmisor As Short, numeroComprobante As Long)
      EjecutaConConexion(
         Sub()
            Dim idTipoCompBusqueda = If(tipoComprobante.EsRecibo, tipoComprobante.IdTipoComprobanteSecundario, tipoComprobante.IdTipoComprobante)

            Dim ctaCte = _GetUna(idSucursal, idTipoCompBusqueda, letra, centroEmisor, numeroComprobante)

            'El Saldo viene con el saldo cambiado, pero por las dudas le saco el signo a ambos.
            If Math.Abs(ctaCte.ImporteTotal) <> Math.Abs(ctaCte.Saldo) Then
               Throw New Exception(String.Format("El {0} {1} {2:0000}-{3:00000000} {4}tiene pago(s) aplicado(s), debe anular primero el/los Recibo(s) que lo afectó.",
                                                 tipoComprobante.IdTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                 If(tipoComprobante.EsRecibo, String.Format("generó un {0} y el mismo ", idTipoCompBusqueda), "")))
            End If
         End Sub)
   End Sub

   Public Function GetRecibosDelComprobante(venta As Entidades.Venta) As List(Of Entidades.CuentaCorriente)
      Dim sql = New SqlServer.CuentasCorrientes(da)
      Dim dt = sql.GetRecibosDelComprobante(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
      Return dt.AsEnumerable().ToList().ConvertAll(
               Function(dr)
                  Return _GetUna(dr.Field(Of Integer)("IdSucursal"),
                                 dr.Field(Of String)("IdTipoComprobante"),
                                 dr.Field(Of String)("Letra"),
                                 dr.Field(Of Integer)("CentroEmisor"),
                                 dr.Field(Of Long)("NumeroComprobante"))
               End Function)
   End Function

   Public Function GetRecibosDeNovedad(venta As Entidades.CRMNovedad) As List(Of Entidades.CuentaCorriente)
      Dim sql = New SqlServer.CuentasCorrientes(da)
      Dim dt = sql.GetRecibosDeNovedad(venta.IdTipoNovedad, venta.Letra, venta.CentroEmisor, venta.IdNovedad)
      Return dt.AsEnumerable().ToList().ConvertAll(
               Function(dr)
                  Return _GetUna(dr.Field(Of Integer)("IdSucursal"),
                                 dr.Field(Of String)("IdTipoComprobante"),
                                 dr.Field(Of String)("Letra"),
                                 dr.Field(Of Integer)("CentroEmisor"),
                                 dr.Field(Of Long)("NumeroComprobante"))
               End Function)
   End Function
   Public Function _GetComprobantesDeNovedadTodos(venta As Entidades.CRMNovedad) As DataTable
      Dim sql = New SqlServer.CuentasCorrientes(da)
      Dim dt = sql.GetComprobantesDeNovedad(venta.IdTipoNovedad, venta.Letra, venta.CentroEmisor, venta.IdNovedad)
      Return dt
   End Function
End Class
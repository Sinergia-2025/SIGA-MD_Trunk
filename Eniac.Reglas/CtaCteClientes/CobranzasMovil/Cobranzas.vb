Public Class Cobranzas
   Private da As Datos.DataAccess
   Private _cache As BusquedasCacheadas
   Private _sincronizacionSubidaMovil As ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil

   Public Event Avance(sender As Object, e As ReglasCobranzasEventArgs)

   Public Sub New(sincronizacionSubidaMovil As ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil)
      da = New Datos.DataAccess()
      _cache = New BusquedasCacheadas()
      _sincronizacionSubidaMovil = sincronizacionSubidaMovil
   End Sub

   Private Sub CambiaEstado(cobranza As Entidades.JSonEntidades.CobranzasMovil.Cobranzas, estado As Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion)
      If cobranza.EstadoImportacion < estado Then
         cobranza.EstadoImportacion = estado
      End If
   End Sub

   Public Function ValidarCobranzas(cobranzas As List(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas)) As List(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()

         Dim rCtaCtePagos = New CuentasCorrientesPagos(da)
         Dim rTpComp = New TiposComprobantes(da)

         Dim dicPagosPendientes = New Dictionary(Of Long, DataTable)()
         Dim dicTipoRecibo = New Dictionary(Of String, Entidades.TipoComprobante)()

         For Each cobranza As Entidades.JSonEntidades.CobranzasMovil.Cobranzas In cobranzas
            Dim stb = New StringBuilder()
            If Not _cache.ExisteClientePorIdRapido(cobranza.IdCliente) Then
               CambiaEstado(cobranza, Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Error)
               stb.AppendFormat("No existe Cliente con ID {0} - ", cobranza.IdCliente)
            End If

            Dim cobrador As Entidades.Empleado = Nothing
            If Not String.IsNullOrWhiteSpace(cobranza.IdUsuario) Then
               cobrador = _cache.BuscaCobradorPorIdUsuarioMovil(cobranza.IdUsuario)
            End If
            If cobrador Is Nothing AndAlso Not String.IsNullOrWhiteSpace(cobranza.IdDispositivo) Then
               cobrador = _cache.BuscaCobradorPorIdDispositivo(cobranza.IdDispositivo)
            End If
            If cobrador Is Nothing Then
               CambiaEstado(cobranza, Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Error)
               stb.AppendFormat("No existe Cobrador con el ID de Dispositivo '{0}' o Usuario '{1}' - ", cobranza.IdDispositivo, cobranza.IdUsuario)
            Else
               cobranza.Cobrador = cobrador
               If Not cobrador.IdCaja.HasValue Then
                  CambiaEstado(cobranza, Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Error)
                  stb.AppendFormat("El cobrador {0} - {1} no tiene caja asignada. - ", cobrador.NroDocEmpleado, cobrador.NombreEmpleado)
               Else
                  cobranza.Caja = _cache.BuscaCajaNombre(actual.Sucursal.IdSucursal, cobrador.IdCaja.Value)
               End If
            End If

            If Not dicPagosPendientes.ContainsKey(cobranza.IdCliente) Then
               dicPagosPendientes.Add(cobranza.IdCliente, rCtaCtePagos.GetPorCliente(Nothing,
                                                                                     cobranza.IdCliente,
                                                                                     fechaUtilizada:="",
                                                                                     desde:=Nothing,
                                                                                     hasta:=Nothing,
                                                                                     grabaLibro:="TODOS",
                                                                                     grupo:="",
                                                                                     excluirMinutas:="NO",
                                                                                     soloConSaldo:=True,
                                                                                     fechaInteres:=Date.Now,
                                                                                     idMoneda:=Entidades.Moneda.Peso,
                                                                                     tipoConversion:=Entidades.Moneda_TipoConversion.Comprobante,
                                                                                     cotizDolar:=1,
                                                                                     excluirPreComprobantes:=False,
                                                                                     IdEmbarcacion:=0, idCama:=0))
            End If

            If actual.Sucursal.IdSucursal <> cobranza.IdSucursal Then
               CambiaEstado(cobranza, Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Error)
               stb.AppendFormat("El comprobante pertenece a otra sucursal - ")
            Else

               If dicPagosPendientes(cobranza.IdCliente).Select(String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4} AND CuotaNumero = {5}",
                                                                              cobranza.IdSucursal,
                                                                              cobranza.IdTipoComprobante,
                                                                              cobranza.Letra,
                                                                              cobranza.CentroEmisor,
                                                                              cobranza.NumeroComprobante,
                                                                              cobranza.CuotaNumero)).Length = 0 Then
                  If dicPagosPendientes(cobranza.IdCliente).Select(String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                                                                 cobranza.IdSucursal,
                                                                                 cobranza.IdTipoComprobante,
                                                                                 cobranza.Letra,
                                                                                 cobranza.CentroEmisor,
                                                                                 cobranza.NumeroComprobante,
                                                                                 cobranza.CuotaNumero)).Length = 0 Then
                     CambiaEstado(cobranza, Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Advertencia)
                     stb.AppendFormat("El comprobante {0} {1} {2:0000}-{3:00000000} no tiene cuotas pendientes. Se dejará a cuenta - ",
                                      cobranza.IdTipoComprobante,
                                      cobranza.Letra,
                                      cobranza.CentroEmisor,
                                      cobranza.NumeroComprobante)
                  Else
                     CambiaEstado(cobranza, Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Advertencia)
                     stb.AppendFormat("El comprobante {0} {1} {2:0000}-{3:00000000} {4} no tiene cuotas pendientes. Se aplicará a la siguiente cuota pendiente - ",
                                      cobranza.IdTipoComprobante,
                                      cobranza.Letra,
                                      cobranza.CentroEmisor,
                                      cobranza.NumeroComprobante,
                                      cobranza.CuotaNumero)
                  End If         'If dicPagosPendientes(cobranza.IdCliente).Select( SIN INCLUIR CUOTA
               End If            'If dicPagosPendientes(cobranza.IdCliente).Select( INCLUYENDO CUOTA
            End If               'ELSE - If actual.Sucursal.IdSucursal <> cobranza.IdSucursal Then

            If Not dicTipoRecibo.ContainsKey(cobranza.IdTipoComprobante) Then
               Dim tipoReciboTemp = rTpComp._GetTipoComprobanteRecibo(cobranza.IdTipoComprobante, cobranza.ImportePesos, Base.AccionesSiNoExisteRegistro.Nulo)
               If tipoReciboTemp IsNot Nothing Then
                  dicTipoRecibo.Add(cobranza.IdTipoComprobante, tipoReciboTemp)
               End If
            End If

            If Not dicTipoRecibo.ContainsKey(cobranza.IdTipoComprobante) Then
               CambiaEstado(cobranza, Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Error)
               stb.AppendFormat("No se encuentra Tipo de Recibo para poder cancelar {0}. - ", cobranza.IdTipoComprobante)
            Else
               cobranza.TipoComprobanteRecibo = dicTipoRecibo(cobranza.IdTipoComprobante)
            End If


            cobranza.MensajeError = stb.ToString()
         Next

         Return cobranzas

      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Function

   Public Sub Importar(cobranzas As List(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas), idFuncion As String)
      Try
         da.OpenConection()
         _Importar(cobranzas, idFuncion)
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Sub _Importar(cobranzas As List(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas), idFuncion As String)

      Try
         Dim formaDePagoContado = New VentasFormasPago().GetUna(Entidades.TipoComprobante.Tipos.VENTAS.ToString(), esContado:=True)

         For Each cobranza In cobranzas.Where(Function(c) c.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Pendiente Or
                                                       c.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Advertencia)
            RaiseEvent Avance(Me, New ReglasCobranzasEventArgs(String.Format("Preparando recibo para comprobante {0} {1} {2:0000} {3:00000000} / {4} - Cliente: {5} - {6}",
                                                                          cobranza.IdTipoComprobante, cobranza.Letra, cobranza.CentroEmisor, cobranza.NumeroComprobante,
                                                                          cobranza.CuotaNumero, cobranza.CodigoCliente, cobranza.NombreCliente)))

            Dim cli = _cache.BuscaClienteEntidadPorId(cobranza.IdCliente)
            Dim cob = cobranza.Cobrador ' _cache.BuscaCobradorPorIdDispositivo(cobranza.IdDispositivo)

            Dim idTipoComprobanteRecibo = cobranza.TipoComprobanteRecibo.IdTipoComprobante
            Dim letraRecibo = cobranza.TipoComprobanteRecibo.LetrasHabilitadas

            If String.IsNullOrWhiteSpace(cobranza.Observaciones) Then
               cobranza.Observaciones = "Simovil Cobranza"
            End If

            Dim rCtaCteRecibo = New CtaCteClienteRecibo()
            Dim eCuentaCorriente = rCtaCteRecibo.GetCtaCteCliente(idTipoComprobanteRecibo, letraRecibo, numeroComprobante:=0, cobranza.FechaCobro,
                                                                  formaDePagoContado.IdFormasPago, cli, cli.Vendedor, cob,
                                                                  cobranza.Observaciones, cobranza.ImportePesos, cobranza.ImportePesos, importeDolares:=0,
                                                                  importeTarjetas:=0, importeTransferencia:=0, idCuentaBancaria:=0, cob.IdCaja.Value,
                                                                  pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                                  da, nroOrdenCompra:=0)

            Dim rCuentasCorrientes = New CuentasCorrientes(da)
            eCuentaCorriente.Pagos = rCuentasCorrientes.GetPagosDeCliente(eCuentaCorriente.TipoComprobante,
                                                                          eCuentaCorriente.IdSucursal,
                                                                          eCuentaCorriente.Cliente.IdCliente,
                                                                          eCuentaCorriente.ImporteTotal,
                                                                          idTipoLiquidacion:=Nothing,
                                                                          cobranza.IdTipoComprobante,
                                                                          cobranza.Letra,
                                                                          cobranza.CentroEmisor,
                                                                          cobranza.NumeroComprobante,
                                                                          cobranza.CuotaNumero,
                                                                          soloCuotaIndicada:=False)


            Try
               da.BeginTransaction()

               RaiseEvent Avance(Me, New ReglasCobranzasEventArgs(String.Format("Registrando el {7} para comprobante {0} {1} {2:0000} {3:00000000} / {4} - Cliente: {5} - {6}",
                                                                                cobranza.IdTipoComprobante, cobranza.Letra, cobranza.CentroEmisor, cobranza.NumeroComprobante,
                                                                                cobranza.CuotaNumero, cobranza.CodigoCliente, cobranza.NombreCliente,
                                                                                eCuentaCorriente.TipoComprobante.IdTipoComprobante)))

               rCuentasCorrientes.Inserta(eCuentaCorriente, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

               RaiseEvent Avance(Me, New ReglasCobranzasEventArgs(String.Format("Marcando el comprobante {0} {1} {2:0000} {3:00000000} / {4} - Cliente: {5} - {6} como procesado",
                                                                                cobranza.IdTipoComprobante, cobranza.Letra, cobranza.CentroEmisor, cobranza.NumeroComprobante,
                                                                                cobranza.CuotaNumero, cobranza.CodigoCliente, cobranza.NombreCliente)))

               _sincronizacionSubidaMovil.MarcarCobranza(cobranza)
               cobranza.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Procesado

               da.CommitTransaction()
            Catch
               da.RollbakTransaction()
               Throw
            End Try

         Next

         RaiseEvent Avance(Me, New ReglasCobranzasEventArgs("Proceso finalizado exitosamente!"))
      Catch ex As Exception
         RaiseEvent Avance(Me, New ReglasCobranzasEventArgs(String.Format("Se produjo un error {0}", ex.Message)))
         Throw
      End Try
   End Sub

   Public Class ReglasCobranzasEventArgs
      Inherits EventArgs
      Public Sub New(mensaje As String)
         Me.Mensaje = mensaje
      End Sub
      Public Property Mensaje As String
   End Class

   Public Sub ImportarAutomaticamente(idFuncion As String)
      Dim rBitacora As Reglas.Bitacora = New Reglas.Bitacora()
      Dim cobranzas As List(Of Entidades.JSonEntidades.CobranzasMovil.Cobranzas) = Nothing
      Dim mensaje As String
      Dim cantProceso As Long = 0
      Dim cantPendiente As Long = 0
      Dim cantAdvertencia As Long = 0
      Dim cantConError As Long = 0
      Try
         Dim sucursales = New Sucursales().GetTodosParaSincronizarSegunIncluir(Publicos.SimovilCobranzaSucursales).ConvertAll(Function(s) s.IdSucursal).ToArray()

         cobranzas = ValidarCobranzas(_sincronizacionSubidaMovil.ObtenerCobranzas(sucursales))

         cantPendiente = cobranzas.LongCount(Function(x) x.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Pendiente)
         cantAdvertencia = cobranzas.LongCount(Function(x) x.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Advertencia)
         cantConError = cobranzas.LongCount(Function(x) x.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Error)

         Importar(cobranzas, idFuncion)
      Catch ex As Exception
         mensaje = String.Format("Error Importando: {0}", ex.ToString())
         rBitacora.Insertar(Entidades.Bitacora.TipoBitacora.SucedioError, idFuncion, mensaje, Now)
      End Try

      If cobranzas IsNot Nothing Then
         cantProceso = cobranzas.LongCount(Function(x) x.EstadoImportacion = Entidades.JSonEntidades.CobranzasMovil.Cobranzas.EstadosImportacion.Procesado)
      End If

      mensaje = String.Format("Simovil.Cobranzas Proceso: {0} Recibos ({1} Pendientes, {2} Advertencia) - Con Error: {3}",
                              cantProceso, cantPendiente, cantAdvertencia, cantConError)
      rBitacora.Insertar(Entidades.Bitacora.TipoBitacora.NuevoRegistro, idFuncion, mensaje, Now)

   End Sub

End Class
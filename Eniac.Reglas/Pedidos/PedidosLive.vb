Partial Class Pedidos

#Region "Modificar datos Pedidos"
   Public Sub ModificaFechaEnvio(filas As DataRow(), fecEnvio As Date)
      Try
         da.OpenConection()
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         For Each fila As DataRow In filas
            If fila IsNot Nothing Then
               'Pruebo de actualizar el registro en las dos tablas. Si es un Pedido
               'lo encuentra en la tabla Pedidos y no en Ventas; si es una Factura
               '(o similar) lo encuentra en la tabla Ventas y no en Pedidos.
               Try
                  da.BeginTransaction()
                  ModificaFechaEnvio(fila, fecEnvio)
                  oVentas.CambiarFechaEnvio(fila, fecEnvio)
                  da.CommitTransaction()
               Catch
                  da.RollbakTransaction()
                  Throw
               End Try
            End If
         Next
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub ModificaFechaEnvio(fila As DataRow, fecEnvio As Date)
      Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)

      Dim idSucursal As Integer = fila.Field(Of Integer)("IdSucursal")     'actual.Sucursal.Id
      Dim idTipoComprobante As String = fila.Field(Of String)("IdTipoComprobante")
      Dim letra As String = fila.Field(Of String)("Letra")
      Dim centroEmisor As Short = Convert.ToInt16(fila.Field(Of Integer)("CentroEmisor"))
      '-- REG-31090 - 31210.- --
      '-- Dependiendo del filtro origen (todos/pedidos/ventas) la columna puede venir integer o long. --
      '-- No es la correccion mas adecuada, pero la mas practica por el momento.- 
      Dim numeroPedido As Long = CLng(fila("NumeroPedido").ToString())

      sql.PedidosProductos_U_FechaEnvio(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, fecEnvio)
      sql.PedidosEstados_U_FechaEnvio(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, fecEnvio)
   End Sub

   Public Sub ModificaRespDistribucion(filas As DataRow(), idRespDist As Integer, nomTransp As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

         If filas.Any() Then
            Dim dt = filas.First().Table
            If Not dt.Columns.Contains("NumeroPedido") And dt.Columns.Contains("NumeroComprobante") Then
               dt.Columns.Add("NumeroPedido", GetType(Long), "NumeroComprobante")
            End If
         End If

         For Each fila As DataRow In filas
            If fila IsNot Nothing Then
               'Pruebo de actualizar el registro en las dos tablas. Si es un Pedido
               'lo encuentra en la tabla Pedidos y no en Ventas; si es una Factura
               '(o similar) lo encuentra en la tabla Ventas y no en Pedidos.
               Try
                  If blnAbreConexion Then da.BeginTransaction()
                  ModificaRespDistribucion(fila, idRespDist, nomTransp)
                  oVentas.ModificarRespDistrib(fila, idRespDist, nomTransp)
                  If blnAbreConexion Then da.CommitTransaction()
               Catch
                  If blnAbreConexion Then da.RollbakTransaction()
                  Throw
               End Try
            End If
         Next
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
   Public Sub ModificaPalets(filas As DataRow(), cantidadPalets As Integer)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         For Each fila As DataRow In filas
            If fila IsNot Nothing Then
               Try
                  If blnAbreConexion Then da.BeginTransaction()
                  ModificaPaletsPedido(fila, cantidadPalets)
                  oVentas.ModificarPalets(fila, cantidadPalets)
                  If blnAbreConexion Then da.CommitTransaction()
               Catch
                  If blnAbreConexion Then da.RollbakTransaction()
                  Throw
               End Try
            End If
         Next
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
   Public Sub ModificaPaletsPedido(fila As DataRow, cantidadPalets As Integer)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)
         sql.Actualizar_Palets_Pedidos(actual.Sucursal.Id,
                                fila("IdTipoComprobante").ToString(),
                                fila("Letra").ToString(),
                                CShort(fila("CentroEmisor")),
                                CLng(fila("NumeroPedido")),
                                cantidadPalets)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ModificaRespDistribucion(fila As DataRow, idRespDist As Integer, nomTransp As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)
         sql.Pedidos_RespDist(actual.Sucursal.Id,
                              fila("IdTipoComprobante").ToString(),
                              fila("Letra").ToString(),
                              CShort(fila("CentroEmisor")),
                              CLng(fila("NumeroPedido")),
                              idRespDist)
         fila("NombreTransportista") = nomTransp
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ModificaFormaPago(filas As DataRow(), idFormaPago As Integer, formaPago As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         For Each fila As DataRow In filas
            If fila IsNot Nothing Then
               'Pruebo de actualizar el registro en las dos tablas. Si es un Pedido
               'lo encuentra en la tabla Pedidos y no en Ventas; si es una Factura
               '(o similar) lo encuentra en la tabla Ventas y no en Pedidos.
               Try
                  If blnAbreConexion Then da.BeginTransaction()
                  ModificaFormaPago(fila, idFormaPago, formaPago)
                  oVentas.ModificarFormaPago(fila, idFormaPago)
                  If blnAbreConexion Then da.CommitTransaction()
               Catch
                  If blnAbreConexion Then da.RollbakTransaction()
                  Throw
               End Try
            End If
         Next
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ModificaFormaPago(fila As DataRow, idFormaPago As Integer, formaPago As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)
         sql.Pedidos_FormaPago(actual.Sucursal.Id,
                               fila("IdTipoComprobante").ToString(),
                               fila("Letra").ToString(),
                               CShort(fila("CentroEmisor")),
                               CLng(fila("NumeroPedido")),
                               idFormaPago)
         fila("DescripcionFormasPago") = formaPago
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ModificarTComp(filas As DataRow(), idTipoComprobanteFact As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         For Each fila As DataRow In filas
            If fila IsNot Nothing Then
               'Pruebo de actualizar el registro en las dos tablas. Si es un Pedido
               'lo encuentra en la tabla Pedidos y no en Ventas; si es una Factura
               '(o similar) lo encuentra en la tabla Ventas y no en Pedidos.
               Try
                  If blnAbreConexion Then da.BeginTransaction()
                  ModificarTComp(fila, idTipoComprobanteFact)
                  If blnAbreConexion Then da.CommitTransaction()
               Catch
                  If blnAbreConexion Then da.RollbakTransaction()
                  Throw
               End Try
            End If
         Next
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ModificarTComp(fila As DataRow, idTipoComprobanteFact As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         ModificarTComp(actual.Sucursal.Id,
                              fila("IdTipoComprobante").ToString(),
                              fila("Letra").ToString(),
                              CShort(fila("CentroEmisor")),
                              CLng(fila("NumeroPedido")),
                              idTipoComprobanteFact)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ModificarTComp(idSucursal As Integer,
                             idTipoComprobante As String,
                             letra As String,
                             centroEmisor As Integer,
                             numeroPedido As Long,
                             idTipoComprobanteFact As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)

         'oVentas.ModificarTComp(idSucursal,
         '                       idTipoComprobante,
         '                       letra,
         '                       centroEmisor,
         '                       numeroPedido,
         '                       idTipoComprobanteFact)

         sql.Pedidos_TipoCompFact(idSucursal,
                                  idTipoComprobante,
                                  letra,
                                  centroEmisor,
                                  numeroPedido,
                                  idTipoComprobanteFact)
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
#End Region

   'Este método se encuentra ahora en el SIGA
   'Public Sub ActualizarComprobantePorComprobante(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)
   '   Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
   '   Try
   '      If blnAbreConexion Then Me.da.OpenConection()

   '      Dim sqlC As SqlServer.Pedidos = New SqlServer.Pedidos(da)

   '      sqlC.ActualizarComprobantePorComprobante(vtaNueva.IdSucursal,
   '                                               vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
   '                                               vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)

   '   Finally
   '      If blnAbreConexion Then Me.da.CloseConection()
   '   End Try
   'End Sub

   Public Function ValidaOrganizarEntrega(_dsOrganizarEntrega As DataSet) As ResultadoValidacionOrganizarEntrega
      Dim resultado As ResultadoValidacionOrganizarEntrega = New ResultadoValidacionOrganizarEntrega()
      Dim oVentasLIVE As Reglas.Ventas = New Reglas.Ventas()
      Dim oVentasSIGA As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
      Dim cantPasa As Integer = 0
      Dim fechaTmp As DateTime? = Nothing
      Dim direccion As String = String.Empty

      For Each drPedido As DataRow In _dsOrganizarEntrega.Tables("Pedidos").Rows

         If Boolean.Parse(drPedido("PASA").ToString()) Then
            cantPasa += 1
            If Not CBool(drPedido("Reenvio").ToString()) Then

               Dim pedido = GetUno(Integer.Parse(drPedido("IdSucursal").ToString()),
                                   drPedido("IdTipoComprobante").ToString(),
                                   drPedido("Letra").ToString(),
                                   Short.Parse(drPedido("CentroEmisor").ToString()),
                                   Long.Parse(drPedido("NumeroPedido").ToString()),
                                   estadoPedido:=Nothing)

               ' valido dirección
               If String.IsNullOrEmpty(drPedido("Direccion").ToString()) Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El cliente del comprobante {0} {1} {2:0000}-{3:00000000} no posee Dirección. No puede generar comprobante.",
                                                 pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineError()
               End If

               If pedido.FormaPago Is Nothing Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} tiene Forma de pago EFECTIVO !!! No puede generar comprobante, cambie la Forma de Pago.",
                                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineError()
               End If
               If Integer.Parse(drPedido("Dias").ToString()) = 0 Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} tiene Forma de pago EFECTIVO !!! No puede generar comprobante, cambie la Forma de Pago.",
                                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineError()
               End If
               If String.IsNullOrWhiteSpace(pedido.IdTipoComprobanteFact) Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} no tiene tipo de comprobante a generar. No puede generar comprobante, asignele un tipo de comprobante.",
                                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineError()
               End If

               '# Valido que no se esé generando un comprobante electrónico a un consumidor final por un importe > al permitido y sin que el cliente tenga un DNI asociado.
               If pedido.TipoComprobanteFact IsNot Nothing Then
                  If Not pedido.Cliente.CategoriaFiscal.IvaDiscriminado AndAlso Not pedido.Cliente.CategoriaFiscal.SolicitaCUIT And pedido.Cliente.CategoriaFiscal.LetraFiscal <> "E" And
                         pedido.ImporteTotal >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF And pedido.Cliente.NroDocCliente = 0 And
                         pedido.TipoComprobanteFact.ControlaTopeConsumidorFinal Then

                     If Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal Or
                    (Not Reglas.Publicos.Facturacion.FacturacionControlaDNIClienteConsumidorFinal And
                     pedido.TipoComprobanteFact.GrabaLibro Or pedido.TipoComprobanteFact.EsPreElectronico) Then

                        resultado.AlgunError = True

                        resultado.AppendFormatError("El cliente del comprobante {0} {1} {2:0000}-{3:00000000} es Consumidor Final y el Total de Comprobante es superior a $ {4}. El DNI es obligatorio.",
                                                 pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido, Reglas.Publicos.Facturacion.FacturacionControlaTopeCF).AppendLineError()
                     End If
                  End If
               End If

               If Not String.IsNullOrEmpty(pedido.IdTipoComprobanteFact) Then
                  If New Reglas.TiposComprobantes().GetUno(pedido.IdTipoComprobanteFact).CoeficienteValores < 1 Then
                     resultado.AlgunError = True
                     resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} tiene un tipo de comprobante a generar que no está permitido. ",
                                                 pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineError()
                  End If
               End If


               'Valido Cuit
               Dim result As Reglas.Validaciones.ValidacionResult
               result = Reglas.Validaciones.Impositivo.ValidarIdFiscal.Instancia.Validar(New Reglas.Validaciones.Impositivo.DatosValidacionFiscal() _
                                                                                         With {.IdFiscal = pedido.Cliente.Cuit,
                                                                                               .SolicitaCUIT = DirectCast(pedido.Cliente, Entidades.Cliente).CategoriaFiscal.SolicitaCUIT})
               If result.Error Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El cliente {0} - {1} tiene un CUIT invalido: {2}", pedido.Cliente.CodigoCliente, pedido.Cliente.NombreCliente, result.MensajeError).AppendLineError()
               End If


               Try
                  oVentasLIVE.ValidaCantidadLineas(pedido.IdTipoComprobanteFact, pedido.Cliente.IdCliente,
                                                   pedido.PedidosProductos, pedido.PedidosObservaciones)
               Catch ex As Exception
                  resultado.AlgunWarning = True
                  resultado.AppendFormatWarning("El comprobante {0} {1} {2:0000}-{3:00000000} tiene más lineas que el máximo permitido para el comprobante a generar. Se dividirá el mismo en varios pedidos.",
                                                pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineWarning()
                  resultado.PedidosConMuchasLineas.Add(pedido)
               End Try

               Dim fechaEnvio As DateTime?
               If pedido.PedidosProductos.Count > 0 AndAlso pedido.PedidosProductos(0).FechaEntrega > New Date() Then
                  fechaEnvio = pedido.PedidosProductos(0).FechaEntrega
               End If

               If Not fechaEnvio.HasValue Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} no tiene fecha de envio. No puede generar comprobante, ingrese una fecha de envio.",
                                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineError()
               End If
               If pedido.Transportista.idTransportista = 0 Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} no tiene Responsable de Distribución. No puede generar comprobante, ingrese un responsable de distribución.",
                                              pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AppendLineError()
               Else
                  Dim mensaje As String = ValidarCargaPermitida(drPedido, _dsOrganizarEntrega)
                  If Not String.IsNullOrWhiteSpace(mensaje) Then
                     resultado.AlgunError = True
                     resultado.AppendFormatError(mensaje).AppendLineError()
                  End If
               End If


               ' controlo limite de credito cliente

               Dim oCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos
               Dim SaldoCtaCte As Decimal
               Dim dt As DataTable
               dt = oCtaCteDet.GetSaldosCtaCte(Nothing, pedido.IdCliente, Nothing, 0)

               If dt.Rows.Count = 1 Then
                  If Reglas.Publicos.Facturacion.FacturacionSaldoCtaCteIncluyeCh3ros Then
                     SaldoCtaCte = Decimal.Parse(dt.Rows(0)("Saldo").ToString()) + Decimal.Parse("0" & dt.Rows(0)("IMPORTE2").ToString())
                  Else
                     SaldoCtaCte = Decimal.Parse(dt.Rows(0)("Saldo").ToString())
                  End If
               End If

               If pedido.Cliente.LimiteDeCredito > 0 AndAlso
                     pedido.FormaPago.Dias > 0 AndAlso pedido.TipoComprobanteFact.ActualizaCtaCte AndAlso
                     pedido.TipoComprobanteFact.CoeficienteValores > 0 Then

                  If SaldoCtaCte + pedido.ImporteTotal > pedido.Cliente.LimiteDeCredito Then
                     Select Case Reglas.Publicos.ControlaEventosdeLimiteDeCreditoDeClientes
                        Case "No Permitir"
                           ' If Not arrojarException Then
                           resultado.AlgunError = True
                           resultado.AppendFormatError("ATENCION: El Cliente {0} Superó el Límite de Crédito de {1}", pedido.Cliente.NombreCliente, pedido.Cliente.LimiteDeCredito)
                              'Else
                              '   Throw New Exception("ATENCION: El Cliente Superó la cantidad de dias de límite de Crédito. El Comprobante fué Cancelado por Falta de Crédito.")
                              'End If
                        Case "Avisar y Permitir"
                           'If ("ATENCION: El Cliente Superó el Límite de Crédito, ¿ Continúa ?") <> Windows.Forms.DialogResult.Yes Then
                           ' If Not arrojarException Then
                           'resultado.AlgunError = True
                           'resultado.AppendLineError("ATENCION: El Cliente Superó el Límite de Crédito")
                           '  Return False
                           ' Else
                           'Throw New Exception("El Comprobante fué Cancelado por Falta de Crédito.")
                           'End If
                           ' End If
                     End Select
                  End If

               End If

               resultado.Pedidos.Add(pedido)

            Else
               Dim venta = oVentasSIGA.GetUna(Integer.Parse(drPedido("IdSucursal").ToString()),
                                              drPedido("IdTipoComprobante").ToString(),
                                              drPedido("Letra").ToString(),
                                              Short.Parse(drPedido("CentroEmisor").ToString()),
                                              Long.Parse(drPedido("NumeroPedido").ToString()))

               ' valido direccion
               If String.IsNullOrEmpty(drPedido("Direccion").ToString()) Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El cliente del comprobante {0} {1} {2:0000}-{3:00000000} no posee Dirección. No puede generar comprobante.",
                                                 venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante).AppendLineError()
               End If

               If venta.FechaEnvio = New Date() Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} no tiene fecha de envio. No puede generar comprobante, ingrese una fecha de envio.",
                                              venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante).AppendLineError()
               End If
               If venta.Transportista.idTransportista = 0 Then
                  resultado.AlgunError = True
                  resultado.AppendFormatError("El comprobante {0} {1} {2:0000}-{3:00000000} no tiene Responsable de Distribución. No puede generar comprobante, ingrese un responsable de distribución.",
                                              venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante).AppendLineError()
               Else
                  Dim mensaje As String = ValidarCargaPermitida(drPedido, _dsOrganizarEntrega)
                  If Not String.IsNullOrWhiteSpace(mensaje) Then
                     resultado.AlgunError = True
                     resultado.AppendFormatError(mensaje).AppendLineError()
                  End If
               End If

               resultado.Ventas.Add(venta)

            End If      'If Not Boolean.Parse(drPedido("Reenvio").ToString()) Then

            ' Si es la primera vez que se ejecuta el bucle, le asigno el primer valor
            If Not fechaTmp.HasValue AndAlso IsDate(drPedido("FechaEntrega").ToString()) Then
               fechaTmp = DateTime.Parse(drPedido("FechaEntrega").ToString())
            End If

            ' verifico el valor del parámetro
            ' en el caso que NO permita
            If Not Reglas.Publicos.OrganizarEntregaPermiteDistintaFechaEnvio Then

               If IsDate(drPedido("FechaEntrega").ToString()) AndAlso fechaTmp.HasValue AndAlso fechaTmp <> DateTime.Parse(drPedido("FechaEntrega").ToString()) Then
                  resultado.AlgunError = True
                  resultado.AppendLineError("No puede generar un reparto con diferentes fechas de envio.")
                  Return resultado
               End If
            End If





         End If         'If Boolean.Parse(drPedido("PASA").ToString()) Then
      Next

      ControlaStockPedidosReparto(resultado)

      If cantPasa = 0 Then
         resultado.AlgunError = True
         resultado.AppendFormatError("No hay Filas seleccionadas para facturar.").AppendLineError()
      End If

      Return resultado
   End Function
   Private Function ValidarCargaPermitida(dr As DataRow, _dsOrganizarEntrega As DataSet) As String
      Dim msg As String = String.Empty
      If Not String.IsNullOrWhiteSpace(dr("NombreTransportista").ToString()) Then
         Dim Kilos As Decimal = 0
         Dim Palets As Decimal = 0
         Dim KilosMaximnos As Decimal = 0
         Dim PaletsMaximnos As Decimal = 0

         If Not String.IsNullOrWhiteSpace(dr("KilosMaximo").ToString()) Then
            KilosMaximnos = Decimal.Parse(dr("KilosMaximo").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("KilosMaximo").ToString()) Then
            PaletsMaximnos = Decimal.Parse(dr("PaletsMaximo").ToString())
         End If
         For Each drPedido As DataRow In _dsOrganizarEntrega.Tables("Pedidos").Select(String.Format("NombreTransportista = '{0}'", dr("NombreTransportista").ToString()))
            If Boolean.Parse((drPedido("Pasa").ToString())) Then
               Kilos += Decimal.Parse((drPedido("Kilos").ToString()))
               Palets += Decimal.Parse((drPedido("Palets").ToString()))
            End If
         Next
         If Kilos > KilosMaximnos Then
            msg = String.Format("Para el Responsable de Distribucción: {0}, ; La Cantidad maxima de Kilos permitida es: {1} Kg y se cargaron: {2} kg.", dr("NombreTransportista").ToString(), Math.Round(KilosMaximnos, 2), Math.Round(Kilos, 2))
         End If
         If Palets > PaletsMaximnos Then
            msg = String.Format("Para el Responsable de Distribucción: {0}, la Cantidad maxima de Palets permitida es: {1} y se cargaron: {2} Palets.",
                                        dr("NombreTransportista").ToString(), Math.Round(PaletsMaximnos, 2), Math.Round(Palets, 2))

         End If
      End If
      Return msg
   End Function
   Private Sub ControlaStockPedidosReparto(resultado As ResultadoValidacionOrganizarEntrega)

      Dim dicProductos As Dictionary(Of String, Decimal) = New Dictionary(Of String, Decimal)()
      For Each pedido In resultado.Pedidos
         For Each pedidoProducto In pedido.PedidosProductos
            If Not dicProductos.ContainsKey(pedidoProducto.IdProducto) Then
               dicProductos.Add(pedidoProducto.IdProducto, 0)
            End If
            dicProductos(pedidoProducto.IdProducto) += pedidoProducto.Cantidad
         Next
      Next
      Dim rProducto As ProductosSucursales = New ProductosSucursales(da)
      Dim productosSonStock As StringBuilder = New StringBuilder()
      Dim algunoSinStock As Boolean = False
      For Each prodstock As KeyValuePair(Of String, Decimal) In dicProductos
         Dim prodsuc = rProducto._GetUno(actual.Sucursal.Id, prodstock.Key)
         If prodstock.Value > prodsuc.Stock Then
            productosSonStock.AppendFormat("{1}{0}", prodstock.Key, If(algunoSinStock, ", ", ""))
            algunoSinStock = True
         End If
      Next

      If algunoSinStock Then
         If Publicos.Facturacion.FacturarSinStock = "NOPERMITIR" Then
            resultado.AlgunError = True
            resultado.AppendFormatError("No se pueden facturar los productos '{0}'. No hay stock suficiente.", productosSonStock.ToString())
         ElseIf Publicos.Facturacion.FacturarSinStock = "AVISARYPERMITIR" Then
            resultado.AlgunWarning = True
            resultado.AppendFormatWarning("Se van a facturar los productos '{0}' aunque no hay stock suficiente.", productosSonStock.ToString())
         End If
      End If
   End Sub

   Public Class ResultadoValidacionOrganizarEntrega
      Inherits ResultadoValidacion
      Public Sub New()
         MyBase.New()
         Pedidos = New List(Of Entidades.Pedido)()
         Ventas = New List(Of Entidades.Venta)()
         PedidosConMuchasLineas = New List(Of Entidades.Pedido)()
      End Sub

      Private _pedidos As List(Of Entidades.Pedido)
      Public Property Pedidos() As List(Of Entidades.Pedido)
         Get
            Return _pedidos
         End Get
         Private Set(ByVal value As List(Of Entidades.Pedido))
            _pedidos = value
         End Set
      End Property
      Private _ventas As List(Of Entidades.Venta)
      Public Property Ventas() As List(Of Entidades.Venta)
         Get
            Return _ventas
         End Get
         Private Set(ByVal value As List(Of Entidades.Venta))
            _ventas = value
         End Set
      End Property
      Private _pedidosConMuchasLineas As List(Of Entidades.Pedido)
      Public Property PedidosConMuchasLineas() As List(Of Entidades.Pedido)
         Get
            Return _pedidosConMuchasLineas
         End Get
         Private Set(ByVal value As List(Of Entidades.Pedido))
            _pedidosConMuchasLineas = value
         End Set
      End Property
   End Class

   Public Class ResultadoValidacion
      Public Sub New()
         _mensajeError = New StringBuilder()
         _mensajeWarning = New StringBuilder()
         AlgunError = False
      End Sub

      Private _algunError As Boolean
      Public Property AlgunError() As Boolean
         Get
            Return _algunError
         End Get
         Set(ByVal value As Boolean)
            _algunError = value
         End Set
      End Property

      Private _algunWarning As Boolean
      Public Property AlgunWarning() As Boolean
         Get
            Return _algunWarning
         End Get
         Set(ByVal value As Boolean)
            _algunWarning = value
         End Set
      End Property

      Private _mensajeError As StringBuilder
      Public ReadOnly Property MensajeError() As String
         Get
            Return _mensajeError.ToString()
         End Get
      End Property

      Private _mensajeWarning As StringBuilder
      Public ReadOnly Property MensajeWarning() As String
         Get
            Return _mensajeWarning.ToString()
         End Get
      End Property

      Public Function AppendFormatError(format As String, arg0 As Object) As ResultadoValidacion
         _mensajeError.AppendFormat(format, arg0)
         Return Me
      End Function
      Public Function AppendFormatError(format As String, arg0 As Object, arg1 As Object) As ResultadoValidacion
         _mensajeError.AppendFormat(format, arg0, arg1)
         Return Me
      End Function
      Public Function AppendFormatError(format As String, arg0 As Object, arg1 As Object, arg2 As Object) As ResultadoValidacion
         _mensajeError.AppendFormat(format, arg0, arg1, arg2)
         Return Me
      End Function
      Public Function AppendFormatError(format As String, ParamArray args() As Object) As ResultadoValidacion
         _mensajeError.AppendFormat(format, args)
         Return Me
      End Function
      Public Function AppendLineError() As ResultadoValidacion
         _mensajeError.AppendLine()
         Return Me
      End Function
      Public Function AppendLineError(value As String) As ResultadoValidacion
         _mensajeError.AppendLine(value)
         Return Me
      End Function

      Public Function AppendFormatWarning(format As String, arg0 As Object) As ResultadoValidacion
         _mensajeWarning.AppendFormat(format, arg0)
         Return Me
      End Function
      Public Function AppendFormatWarning(format As String, arg0 As Object, arg1 As Object) As ResultadoValidacion
         _mensajeWarning.AppendFormat(format, arg0, arg1)
         Return Me
      End Function
      Public Function AppendFormatWarning(format As String, arg0 As Object, arg1 As Object, arg2 As Object) As ResultadoValidacion
         _mensajeWarning.AppendFormat(format, arg0, arg1, arg2)
         Return Me
      End Function
      Public Function AppendFormatWarning(format As String, ParamArray args() As Object) As ResultadoValidacion
         _mensajeWarning.AppendFormat(format, args)
         Return Me
      End Function
      Public Function AppendLineWarning() As ResultadoValidacion
         _mensajeWarning.AppendLine()
         Return Me
      End Function
      Public Function AppendLineWarning(value As String) As ResultadoValidacion
         _mensajeWarning.AppendLine(value)
         Return Me
      End Function

   End Class

   Public Function GenerarReparto(resVal As ResultadoValidacionOrganizarEntrega, idCaja As Integer,
                                  grabarReparto As Boolean,
                                  MetodoGrabacion As Eniac.Entidades.Entidad.MetodoGrabacion, IdFuncion As String) As DataTable

      Dim dt As DataTable = CreaDTRepartos()

      Dim intRedondeoEnCalculos As Integer = Eniac.Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
      Dim decKilosModificados As Decimal = Nothing

      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConexion Then da.OpenConection()

      Try
         Dim oVentasLIVE As Reglas.Ventas = New Reglas.Ventas(da)
         Dim oVentasSIGA As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)

         If blnAbreConexion Then da.BeginTransaction()
         If resVal.PedidosConMuchasLineas.Count > 0 Then
            For Each pedidoOriginal In resVal.PedidosConMuchasLineas
               Dim cantidadLineas As Entidades.CantidadLineas = oVentasLIVE.ObtieneCantidadLineas(pedidoOriginal.IdTipoComprobanteFact, pedidoOriginal.Cliente.IdCliente)
               Dim CantObservaciones As Integer = 0

               If pedidoOriginal.TipoComprobante.ImportaObservDeInvocados Then
                  CantObservaciones = pedidoOriginal.PedidosObservaciones.Count
               End If

               If cantidadLineas.Imprime And pedidoOriginal.PedidosProductos.Count + CantObservaciones > cantidadLineas.CantMaxItems Then
                  Dim pedidoNuevo As Eniac.Entidades.Pedido = Nothing
                  Dim pedidoOriginalNuevo As Eniac.Entidades.Pedido = Nothing
                  Dim destinos As List(Of Eniac.Entidades.Pedido) = New List(Of Eniac.Entidades.Pedido)()
                  Dim iLinea As Integer = 0
                  Dim numeroPedido As Long? = pedidoOriginal.NumeroPedido
                  For Each prod As Eniac.Entidades.PedidoProducto In pedidoOriginal.PedidosProductos
                     iLinea += 1
                     If iLinea > cantidadLineas.CantMaxItems - CantObservaciones Then
                        If pedidoNuevo Is Nothing OrElse pedidoNuevo.PedidosProductos.Count >= cantidadLineas.CantMaxItems - CantObservaciones Then
                           pedidoNuevo = CrearPedido(pedidoOriginal.TipoComprobante, pedidoOriginal.Cliente,
                                                     String.Empty, Nothing,
                                                     numeroPedido, pedidoOriginal.Fecha,
                                                     pedidoOriginal.Vendedor, pedidoOriginal.Caja, pedidoOriginal.Transportista,
                                                     pedidoOriginal.FormaPago, pedidoOriginal.TipoComprobanteFact,
                                                     pedidoOriginal.Observacion, pedidoOriginal.EstadoVisita,
                                                     pedidoOriginal.NumeroOrdenCompra,
                                                     pedidoOriginal.DescuentoRecargoPorc,
                                                     pedidoOriginal.ClienteVinculado,
                                                     pedidoOriginal.IdMoneda, cotizacionDolar:=Nothing, 0, 0)

                           If pedidoOriginal.TipoComprobante.ImportaObservDeInvocados Then
                              pedidoNuevo.PedidosObservaciones = pedidoOriginal.PedidosObservaciones
                           End If


                           destinos.Add(pedidoNuevo)
                           numeroPedido = Nothing
                        End If
                        Dim pp As Eniac.Entidades.PedidoProducto
                        pp = CrearPedidoProducto(prod.Producto, prod.Producto.NombreProducto,
                                                 prod.DescuentoRecargoPorc, prod.DescuentoRecargoPorc2,
                                                 prod.Precio, prod.Cantidad,
                                                 prod.TipoImpuesto, Nothing,
                                                 prod.IdListaPrecios, prod.IdCriticidad,
                                                 prod.FechaEntrega, pedidoNuevo, intRedondeoEnCalculos, decKilosModificados,
                                                 0, prod.Producto.Tamano, prod.Producto.UnidadDeMedida.IdUnidadDeMedida, prod.Producto.Moneda,
                                                 prod.Espmm, prod.EspPulgadas, prod.CodigoSAE,
                                                 prod.ProduccionProceso, prod.ProduccionForma,
                                                 prod.LargoExtAlto, prod.AnchoIntBase, prod.Architrave, prod.ProduccionModeloForma, prod.UrlPlano,
                                                 prod.IdFormula,
                                                 prod.TipoOperacion, prod.Nota, costo:=0)

                        pp.CantPendiente = pp.Cantidad
                        AgregarLinea(pedidoNuevo, pp)
                        'prod.Cantidad = 0
                     Else
                        If pedidoOriginalNuevo Is Nothing Then
                           pedidoOriginalNuevo = CrearPedido(pedidoOriginal.TipoComprobante, pedidoOriginal.Cliente,
                                                             String.Empty, Nothing,
                                                             numeroPedido, pedidoOriginal.Fecha,
                                                             pedidoOriginal.Vendedor, pedidoOriginal.Caja, pedidoOriginal.Transportista,
                                                             pedidoOriginal.FormaPago, pedidoOriginal.TipoComprobanteFact,
                                                             pedidoOriginal.Observacion, pedidoOriginal.EstadoVisita,
                                                             pedidoOriginal.NumeroOrdenCompra,
                                                             pedidoOriginal.DescuentoRecargoPorc,
                                                             pedidoOriginal.ClienteVinculado,
                                                             pedidoOriginal.IdMoneda, cotizacionDolar:=Nothing, 0, 0)

                           If pedidoOriginal.TipoComprobante.ImportaObservDeInvocados Then
                              pedidoOriginalNuevo.PedidosObservaciones = pedidoOriginal.PedidosObservaciones
                           End If

                           destinos.Add(pedidoOriginalNuevo)
                           numeroPedido = Nothing
                        End If
                        Dim pp As Entidades.PedidoProducto
                        pp = CrearPedidoProducto(prod.Producto, prod.Producto.NombreProducto,
                                                 prod.DescuentoRecargoPorc, prod.DescuentoRecargoPorc2,
                                                 prod.Precio, prod.Cantidad,
                                                 prod.TipoImpuesto, Nothing,
                                                 prod.IdListaPrecios, prod.IdCriticidad,
                                                 prod.FechaEntrega, pedidoOriginalNuevo, intRedondeoEnCalculos, decKilosModificados,
                                                 0, prod.Producto.Tamano, prod.Producto.UnidadDeMedida.IdUnidadDeMedida, prod.Producto.Moneda,
                                                 prod.Espmm, prod.EspPulgadas, prod.CodigoSAE,
                                                 prod.ProduccionProceso, prod.ProduccionForma,
                                                 prod.LargoExtAlto, prod.AnchoIntBase, prod.Architrave, prod.ProduccionModeloForma, prod.UrlPlano,
                                                 prod.IdFormula,
                                                 prod.TipoOperacion, prod.Nota, costo:=0)

                        pp.CantPendiente = pp.Cantidad
                        AgregarLinea(pedidoOriginalNuevo, pp)
                     End If
                  Next
                  If destinos.Count > 0 Then
                     'Saco el pedidoOriginal porque no existe más como está y cuando 
                     'agrego los generados al dividir viene el mismo con menos lineas
                     resVal.Pedidos.Remove(pedidoOriginal)
                     resVal.Pedidos.AddRange(Dividir(pedidoOriginal, destinos).ToArray())
                  End If
               End If   'If cantidadLineas.Imprime And pedidoOriginal.VentasProductos.Count > cantidadLineas.CantMaxItems Then
            Next        'For Each pedidoOriginal As Pedido In resVal.PedidosConMuchasLineas
         End If         'If resVal.PedidosConMuchasLineas.Count > 0 Then

         'Dim proximoNumeroReparto As Integer = oVentasLIVE.GetProximoNumeroReparto

         Dim repartoTransportista As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)()
         Dim oReparto As Repartos = New Repartos(da)
         Dim oRepartoCompro As RepartosComprobantes = New RepartosComprobantes(da)

         Dim cacheClienteSiLive As Dictionary(Of Long, Entidades.Cliente) = New Dictionary(Of Long, Entidades.Cliente)()

         For Each pedido In resVal.Pedidos
            If Not cacheClienteSiLive.ContainsKey(pedido.Cliente.IdCliente) Then
               cacheClienteSiLive.Add(pedido.Cliente.IdCliente, New Reglas.Clientes(da)._GetUno(pedido.Cliente.IdCliente))
            End If
            'Dim key As Long = pedido.IdTransportista.Value
            Dim key As String = String.Format("{0:00000000}{1:yyyyMMdd}", pedido.IdTransportista.Value, pedido.PedidosProductos(0).FechaEntrega)

            If cacheClienteSiLive(pedido.Cliente.IdCliente).RepartoIndependiente Then
               'Para no cambiar completamente la lógica de generación de reparto, si el cliente genera Reparto Independiente,
               'le pongo key negativa para diferenciarlo de la positiva que es el transportista.
               'key = cacheClienteSiLive(pedido.Cliente.IdCliente).IdCliente * -1
               key = String.Format("{0:00000000}{1:yyyyMMdd}", cacheClienteSiLive(pedido.Cliente.IdCliente).IdCliente * -1, pedido.PedidosProductos(0).FechaEntrega)
            End If

            If Not repartoTransportista.ContainsKey(key) Then
               repartoTransportista.Add(key, oVentasLIVE.GetProximoNumeroReparto())

               For Each prod As Eniac.Entidades.PedidoProducto In pedido.PedidosProductos
                  prod.FechaEntrega = prod.FechaEntrega.Date
               Next

               If grabarReparto Then
                  oReparto.Inserta(repartoTransportista(key), pedido.PedidosProductos(0).FechaEntrega, pedido.Transportista)
               End If

               Dim dr As DataRow = dt.NewRow()
               dr("IdReparto") = repartoTransportista(key)
               dr("FechaReparto") = pedido.PedidosProductos(0).FechaEntrega
               dr("IdTransportista") = pedido.IdTransportista
               dr("NombreTransportista") = pedido.Transportista.NombreTransportista
               dt.Rows.Add(dr)
            End If
            '-- REQ-41759.- ---------------------------------------------------------
            '-- Se solicita Direccion de pedido sea la que se imprima en el listado.-
            pedido.Cliente.Direccion = pedido.Direccion
            '------------------------------------------------------------------------
            Dim venta = ConvertirPedidoEnVenta(pedido, idCaja, reparto:=If(grabarReparto, repartoTransportista(key), 0))
            oVentasSIGA.Inserta(venta, MetodoGrabacion, IdFuncion)

            If grabarReparto Then
               Dim repartoCompro As Entidades.RepartoComprobante = New Entidades.RepartoComprobante()
               repartoCompro.IdSucursal = actual.Sucursal.IdSucursal
               repartoCompro.IdReparto = repartoTransportista(key)
               repartoCompro.Orden = oRepartoCompro.GetCodigoMaximo(actual.Sucursal.Id, repartoCompro.IdReparto) + 1
               repartoCompro.Pedido = pedido
               repartoCompro.Venta = venta
               oRepartoCompro.Inserta(repartoCompro)
            End If
         Next        'For Each pedido As Pedido In resVal.Pedidos

         Dim sqlVentas As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
         Dim rCtaCte = New CuentasCorrientes(da)
         For Each venta As Eniac.Entidades.Venta In resVal.Ventas
            If Not cacheClienteSiLive.ContainsKey(venta.Cliente.IdCliente) Then
               cacheClienteSiLive.Add(venta.Cliente.IdCliente, New Reglas.Clientes(da)._GetUno(venta.Cliente.IdCliente))
            End If
            'Dim key As Long = venta.Transportista.idTransportista
            Dim key As String = String.Format("{0:00000000}{1:yyyyMMdd}", venta.Transportista.idTransportista, venta.FechaEnvio)
            If cacheClienteSiLive(venta.Cliente.IdCliente).RepartoIndependiente Then
               'Para no cambiar completamente la lógica de generación de reparto, si el cliente genera Reparto Independiente,
               'le pongo key negativa para diferenciarlo de la positiva que es el transportista.
               'key = cacheClienteSiLive(venta.Cliente.IdCliente).IdCliente * -1
               key = String.Format("{0:00000000}{1:yyyyMMdd}", cacheClienteSiLive(venta.Cliente.IdCliente).IdCliente * -1, venta.FechaEnvio)
            End If

            If Not repartoTransportista.ContainsKey(key) Then
               repartoTransportista.Add(key, oVentasLIVE.GetProximoNumeroReparto())

               oReparto.Inserta(repartoTransportista(key), venta.FechaEnvio, venta.Transportista)

               Dim dr As DataRow = dt.NewRow()
               dr("IdReparto") = repartoTransportista(key)
               dr("FechaReparto") = venta.FechaEnvio
               dr("IdTransportista") = venta.Transportista.idTransportista
               dr("NombreTransportista") = venta.Transportista.NombreTransportista
               dt.Rows.Add(dr)
            End If

            Dim stb As StringBuilder = New StringBuilder()
            stb.AppendFormat("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                             venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
            sqlVentas.ActualizarNumeroReparto(stb.ToString(), repartoTransportista(key),
                                              venta.Transportista.idTransportista, venta.FechaEnvio.Date, True, False)
            rCtaCte._ActualizarNumeroReparto(venta, repartoTransportista(key))

            Dim repartoCompro As Entidades.RepartoComprobante = New Entidades.RepartoComprobante()
            repartoCompro.IdSucursal = actual.Sucursal.IdSucursal
            repartoCompro.IdReparto = repartoTransportista(key)
            repartoCompro.Orden = oRepartoCompro.GetCodigoMaximo(actual.Sucursal.Id, repartoCompro.IdReparto) + 1
            repartoCompro.Pedido = Nothing
            repartoCompro.Venta = venta
            oRepartoCompro.Inserta(repartoCompro)
         Next        'For Each venta As Eniac.Entidades.Venta In resVal.Ventas


         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

      Return dt
   End Function

   Private Function CreaDTRepartos() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add("IdReparto", GetType(Integer))
      dt.Columns.Add("FechaReparto", GetType(String))
      dt.Columns.Add("IdTransportista", GetType(Integer))
      dt.Columns.Add("NombreTransportista", GetType(String))

      Return dt
   End Function

End Class

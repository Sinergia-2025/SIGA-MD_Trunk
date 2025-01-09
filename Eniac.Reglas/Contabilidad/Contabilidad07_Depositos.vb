#Region "Option"
Option Explicit On
Option Strict On
#End Region
Partial Class Contabilidad

#Region "Depositos Bancarios"
   Friend Function RegistraContabilidad(ByVal oDeposito As Entidades.Deposito) As Boolean
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
      Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
      Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios

      Try
         Dim idUltimoAsiento As Integer = 0
         Dim idEjercicioVigente As Integer
         Dim idPeriodoActual As String

         'obtengo el ejercicio vigente
         idEjercicioVigente = oEjercicio.GetEjercicioVigente(oDeposito.Fecha)
         idPeriodoActual = oEjercicio.GetPeriodoActual(idEjercicioVigente, oDeposito.Fecha)

         Dim idPlanCuenta As Integer = oDeposito.CuentaBancaria.idPlanCuenta
         Dim tipoProceso As String = Entidades.ContabilidadProceso.Procesos.MOVBANCO.ToString()

         'obtengo el ultimo id del los asientos
         idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idEjercicioVigente, idPlanCuenta) + 1

         sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                   idPlanCuenta,
                                   idUltimoAsiento,
                                   oDeposito.Fecha,
                                   ObtenerDescAsiento(oDeposito),
                                   0,
                                   oDeposito.IdSucursal,
                                   tipoProceso,
                                   idEjercicioDefinitivo:=Nothing,
                                   idPlanCuentaDefinitivo:=Nothing,
                                   idAsientoDefinitivo:=Nothing)


         sqlAsientos.Asiento_I_Detalle_TMP(idEjercicioVigente,
                                           idPlanCuenta,
                                           idUltimoAsiento,
                                           AgruparAsiento(ArmarDetalle(oDeposito, idUltimoAsiento)))

         sql.MarcarRegistroProcesado(oDeposito, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)

      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
      Return True
   End Function

   Friend Function ArmarDetalle(ByVal oDeposito As Entidades.Deposito) As DataTable
      Return ArmarDetalle(oDeposito, 0)
   End Function

   Private Function ArmarDetalle(ByVal oDeposito As Entidades.Deposito, ByVal idUltimoAsiento As Integer) As DataTable

      Dim dtDetalle As DataTable = CrearTablaDetalle()

      Dim cuentaCtaCteDebe As Eniac.Entidades.ContabilidadCuenta
      Try
         cuentaCtaCteDebe = New Reglas.ContabilidadCuentas(da)._GetUna(ContabilidadPublicos.ContabilidadCuentaCompras(da))
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas la Cuenta de Compras en Parámetros del Sistema."), ex)
      End Try

      'si el coeficiente del comprobante es positivo va al DEBE sino va al HABER
      Dim debe As Boolean = (oDeposito.TipoComprobante.CoeficienteValores <> 1)
      If oDeposito.CuentaBancariaDestino IsNot Nothing AndAlso oDeposito.CuentaBancariaDestino.IdCuentaBancaria > 0 Then debe = Not debe

      'Dim importeTotal As Decimal = oCtaCteProv.ImportePesos + oCtaCteProv.ImporteDolares + oCtaCteProv.ImporteCheques + oCtaCteProv.ImporteRetenciones + oCtaCteProv.ImporteTarjetas + oCtaCteProv.ImporteTickets + oCtaCteProv.ImporteTransfBancaria

      If oDeposito.ImporteTotal <> 0 Then
         Dim cuenta As entidades. ContabilidadCuenta
         Try
            cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(oDeposito.CuentaBancaria.idCuentaContable)
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               cuenta = cuentaCtaCteDebe
            End If
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria  {0} - {1} en el plan de cuenta {2}",
                                                             oDeposito.CuentaBancaria.IdCuentaBancaria, oDeposito.CuentaBancaria.NombreCuenta, oDeposito.TipoComprobante.IdPlanCuenta))
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} - {1} en el plan de cuenta {2}",
                                                          oDeposito.CuentaBancaria.IdCuentaBancaria, oDeposito.CuentaBancaria.NombreCuenta, oDeposito.TipoComprobante.IdPlanCuenta), ex)
         End Try

         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(Not debe, Math.Abs(oDeposito.ImporteTotal), 0).ToString()),
                        Decimal.Parse(IIf(debe, Math.Abs(oDeposito.ImporteTotal), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)

         If oDeposito.CuentaBancariaDestino IsNot Nothing AndAlso oDeposito.CuentaBancariaDestino.IdCuentaBancaria > 0 Then
            cuenta = Nothing
            Try
               cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(oDeposito.CuentaBancariaDestino.idCuentaContable)
               If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                  cuenta = cuentaCtaCteDebe
               End If
               If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria destino {0} - {1} en el plan de cuenta {2}",
                                                                oDeposito.CuentaBancaria.IdCuentaBancaria, oDeposito.CuentaBancaria.NombreCuenta, oDeposito.TipoComprobante.IdPlanCuenta))
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} - {1} en el plan de cuenta {2}",
                                                             oDeposito.CuentaBancaria.IdCuentaBancaria, oDeposito.CuentaBancaria.NombreCuenta, oDeposito.TipoComprobante.IdPlanCuenta), ex)
            End Try

            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(oDeposito.ImporteTotal), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(oDeposito.ImporteTotal), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         End If

      End If

      If oDeposito.CuentaBancariaDestino Is Nothing OrElse oDeposito.CuentaBancariaDestino.IdCuentaBancaria = 0 Then
         If oDeposito.ImportePesos <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta = Nothing
            Try
               Dim caja As Entidades.CajaNombre = New CajasNombres(da).GetUna(oDeposito.IdSucursal, oDeposito.IdCaja)
               If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
               If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                  Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Pesos)
                  cuenta = medioPago.CuentaContable
               End If
               If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                 oDeposito.TipoComprobante.IdPlanCuenta))
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                             oDeposito.TipoComprobante.IdPlanCuenta), ex)
            End Try
            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(oDeposito.ImportePesos), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(oDeposito.ImportePesos), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         End If

         Dim totalChequesTerceros As Decimal = 0
         For Each cheque As Entidades.Cheque In oDeposito.ChequesTerceros
            totalChequesTerceros += cheque.Importe
         Next
         If totalChequesTerceros <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Cheques)
               cuenta = medioPago.CuentaContable
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}",
                                                             oDeposito.TipoComprobante.IdPlanCuenta), ex)
            End Try
            If cuenta Is Nothing Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}", oDeposito.TipoComprobante.IdPlanCuenta))
            End If
            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(totalChequesTerceros), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(totalChequesTerceros), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         End If

         If oDeposito.ChequesPropios.Count > 0 Then
            For Each cheque As Entidades.Cheque In oDeposito.ChequesPropios
               Dim cuenta As Entidades.ContabilidadCuenta
               Try
                  If oDeposito.TipoComprobante.IdTipoComprobante = "EXTRACCION" Then
                     cuenta = Nothing
                     Dim caja As Entidades.CajaNombre = New CajasNombres(da).GetUna(oDeposito.IdSucursal, oDeposito.IdCaja)
                     If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
                     If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                        Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Pesos)
                        cuenta = medioPago.CuentaContable
                     End If
                     If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                        Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                       oDeposito.TipoComprobante.IdPlanCuenta))
                     End If
                  Else
                     cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(cheque.CuentaBancaria.idCuentaContable)
                     If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                        Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}",
                                                                      oDeposito.TipoComprobante.IdPlanCuenta))
                     End If
                  End If
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}",
                                                                oDeposito.TipoComprobante.IdPlanCuenta), ex)
               End Try
               AgregarFila(dtDetalle,
                              ObtenerDescCuenta(cuenta),
                              Decimal.Parse(IIf(debe, Math.Abs(cheque.Importe), 0).ToString()),
                              Decimal.Parse(IIf(Not debe, Math.Abs(cheque.Importe), 0).ToString()),
                              idUltimoAsiento,
                              cuenta.IdCuenta)
            Next
         End If


         'NO SE PUEDE REGISTRAR IMPORTE DE TARJETAS HASTA QUE NO SE SOLICITE LA TARJETA A LA QUE PERTECENE|
         '' ''If oCtaCteProv.ImporteTarjetas <> 0 Then

         '' ''   Dim cuenta As ContabilidadCuenta
         '' ''   Try
         '' ''      Dim medioPago As MedioDePago = New Reglas.MediosdePago(da).GetUna(MedioDePago.Ids.Tarjetas)
         '' ''      cuenta = medioPago.CuentaContable
         '' ''      If cuenta Is Nothing Then
         '' ''         Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe de Tarjeta en el plan de cuenta {0}",
         '' ''                                                       oCtaCteProv.TipoComprobante.IdPlanCuenta))
         '' ''      End If
         '' ''   Catch ex As Exception
         '' ''      Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe de Tarjeta en el plan de cuenta {0}",
         '' ''                                                    oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         '' ''   End Try

         '' ''   AgregarFila(dtDetalle,
         '' ''                  ObtenerDescCuenta(cuenta),
         '' ''                  Decimal.Parse(IIf(debe, Math.Abs(oCtaCteProv.ImporteTarjetas), 0).ToString()),
         '' ''                  Decimal.Parse(IIf(Not debe, Math.Abs(oCtaCteProv.ImporteTarjetas), 0).ToString()),
         '' ''                  idUltimoAsiento,
         '' ''                  cuenta.IdCuenta)
         '' ''End If

         If oDeposito.ImporteTickets <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Tickets)
               cuenta = medioPago.CuentaContable
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Tickets en el plan de cuenta {0}",
                                                             oDeposito.TipoComprobante.IdPlanCuenta), ex)
            End Try
            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(oDeposito.ImporteTickets), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(oDeposito.ImporteTickets), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         End If
      End If      'If oDeposito.CuentaBancariaDestino Is Nothing Then

      Return dtDetalle
   End Function

   Friend Function ObtenerDescAsiento(ByVal fila As Entidades.Deposito) As String
      Dim nombreCaja As String
      Try
         nombreCaja = New Reglas.CajasNombres(da).GetUna(fila.IdSucursal, fila.IdCaja).NombreCaja
      Catch ex As Exception
         nombreCaja = String.Empty
      End Try
      ' [IdSucursal],[TipoComprobante.Descripcion],[NumeroDeposito],[NombreCuenta],[nombreCaja]
      Return String.Format("{0}-{1} {2:00000000} - {3} - {4}",
                           fila.IdSucursal,
                           fila.TipoComprobante.Descripcion,
                           fila.NumeroDeposito,
                           fila.CuentaBancaria.NombreCuenta,
                           nombreCaja).Truncar(100)
   End Function
#End Region

End Class
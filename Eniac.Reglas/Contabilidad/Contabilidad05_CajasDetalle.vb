#Region "Option"
Option Explicit On
Option Strict On
#End Region
Partial Class Contabilidad

#Region "Caja"
   Friend Function RegistraContabilidad(ByVal eCajaDetalle As Entidades.CajaDetalles) As Boolean
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
      Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
      Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios(da)

      Try
         Dim idUltimoAsiento As Integer = 0

         Dim idEjercicioVigente As Integer
         Dim idPeriodoActual As String

         'obtengo el ejercicio vigente
         idEjercicioVigente = oEjercicio.GetEjercicioVigente(eCajaDetalle.FechaMovimiento)
         idPeriodoActual = oEjercicio.GetPeriodoActual(idEjercicioVigente, eCajaDetalle.FechaMovimiento)

         Dim idPlanCuenta As Integer = sql.GetPlanCtaXCaja(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja, eCajaDetalle.NumeroPlanilla, eCajaDetalle.NumeroMovimiento)
         Dim tipoproceso As String = Entidades.ContabilidadProceso.Procesos.MOVCAJA.ToString()

         If Not (oEjercicio.EstaPeriodoCerrado(idEjercicioVigente, idPeriodoActual)) Then
            idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idEjercicioVigente, idPlanCuenta) + 1

            tipoproceso = Entidades.ContabilidadProceso.Procesos.MOVCAJA.ToString()

            'obtengo el ultimo id del los asientos
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuenta,
                                      idUltimoAsiento,
                                      eCajaDetalle.FechaMovimiento,
                                      ObtenerDescAsiento(eCajaDetalle),
                                      0,
                                      eCajaDetalle.IdSucursal,
                                      tipoproceso,
                                      idEjercicioDefinitivo:=Nothing,
                                      idPlanCuentaDefinitivo:=Nothing,
                                      idAsientoDefinitivo:=Nothing)

            sqlAsientos.Asiento_I_Detalle_TMP(idEjercicioVigente,
                                              idPlanCuenta,
                                              idUltimoAsiento,
                                              AgruparAsiento(ArmarDetalle(eCajaDetalle, idUltimoAsiento, idPlanCuenta)))


            sql.MarcarRegistroProcesado(eCajaDetalle, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)
         Else
            Throw New Exception("El periodo contable se encuentra cerrado.")
         End If
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
      Return True
   End Function

   Friend Sub RegenerarDetalleContabilidad(eCajadetalle As Entidades.CajaDetalles)
      Try
         Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         If eCajadetalle.IdPlanCuenta.HasValue And eCajadetalle.IdAsiento.HasValue Then
            Dim idEjercicio As Integer = eCajadetalle.IdEjercicio.Value
            Dim idPlan As Integer = eCajadetalle.IdPlanCuenta.Value
            Dim idAsiento As Integer = eCajadetalle.IdAsiento.Value

            sqlAsientos.Asiento_D_Detalle_Tmp(idEjercicio, idPlan, idAsiento)
            sqlAsientos.Asiento_I_Detalle_TMP(idEjercicio, idPlan,
                                              idAsiento,
                                              AgruparAsiento(ArmarDetalle(eCajadetalle, idAsiento, idPlan)))
         End If
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
   End Sub

   Friend Sub EliminarAsientoContabilidad(eCajadetalle As Entidades.CajaDetalles)
      Try
         Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         If eCajadetalle.IdPlanCuenta.HasValue And eCajadetalle.IdAsiento.HasValue Then
            Dim idEjercicio As Integer = eCajadetalle.IdEjercicio.Value
            Dim idPlan As Integer = eCajadetalle.IdPlanCuenta.Value
            Dim idAsiento As Integer = eCajadetalle.IdAsiento.Value

            sqlAsientos.Asiento_D_Detalle_Tmp(idEjercicio, idPlan, idAsiento)
            sqlAsientos.Asiento_D_Tmp(idEjercicio, idPlan, idAsiento)
         End If
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
   End Sub

   Private Function ArmarDetalle(ByVal eCajaDetalle As Entidades.CajaDetalles,
                                 ByVal idUltimoAsiento As Integer,
                                 ByVal idPlan As Integer) As DataTable
      Dim tipomovimiento As String = eCajaDetalle.IdTipoMovimiento

      Dim dtDetalle As DataTable = CrearTablaDetalle()
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(Me.da)

      Dim debe As Boolean = (eCajaDetalle.IdTipoMovimiento = "I")
      Dim coe As Decimal = CDec(IIf(eCajaDetalle.IdTipoMovimiento = "I", 1, -1))

      Dim cuentaCaja As Entidades.CuentaDeCaja = New Reglas.CuentasDeCajas(da).GetUna(eCajaDetalle.IdCuentaCaja)
      Dim ctaCtbCtaCaja As Entidades.ContabilidadCuenta
      Try
         ctaCtbCtaCaja = New Reglas.ContabilidadCuentas(da)._GetUna(cuentaCaja.IdCuentaContable)
         If ctaCtbCtaCaja Is Nothing Then
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Cuenta de Caja {0} - {1} en el plan de cuenta {2}",
                                                          cuentaCaja.IdCuentaCaja, cuentaCaja.NombreCuentaCaja, idPlan))
         End If
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Cuenta de Caja {0} - {1} en el plan de cuenta {2}",
                                                       cuentaCaja.IdCuentaCaja, cuentaCaja.NombreCuentaCaja, idPlan), ex)
      End Try

      'Resolver ImporteDolares, porque está el importe en Dolares, hay que convertir a Pesos
      'Si viene en dolares, se suma en el debe, pero no en el haber a proposito ya que con contabilidad está deshabilitado.
      Dim totalMovimientoCaja As Decimal = eCajaDetalle.ImportePesos + (eCajaDetalle.ImporteDolares * eCajaDetalle.CotizacionDolar) + eCajaDetalle.ImporteCheques +
                                           eCajaDetalle.ImporteTickets + eCajaDetalle.ImporteTarjetas + eCajaDetalle.ImporteBancos +
                                           eCajaDetalle.ImporteRetenciones
      AgregarFila(dtDetalle,
                     ObtenerDescCuenta(ctaCtbCtaCaja),
                     Decimal.Parse(IIf(Not debe, totalMovimientoCaja * coe, 0).ToString()),
                     Decimal.Parse(IIf(debe, totalMovimientoCaja * coe, 0).ToString()),
                     idUltimoAsiento,
                     ctaCtbCtaCaja.IdCuenta,
                     eCajaDetalle.IdCentroCosto)

      'Caja al debe si es Ingreso
      If eCajaDetalle.ImportePesos <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta = Nothing
         Try
            Dim caja As Entidades.CajaNombre = New CajasNombres(da).GetUna(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja)
            If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Pesos)
               cuenta = medioPago.CuentaContable
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                          idPlan), ex)
         End Try
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debe, eCajaDetalle.ImportePesos * coe, 0).ToString()),
                        Decimal.Parse(IIf(Not debe, eCajaDetalle.ImportePesos * coe, 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If eCajaDetalle.ImporteDolares <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta = Nothing
         Try
            'TODO: De momento no tenemos configurada una cuenta contable para Dolares en las Cajas
            'Dim caja As CajaNombre = New CajasNombres(da).GetUna(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja)
            'If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Dolares)
               cuenta = medioPago.CuentaContable
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Dolares en el plan de cuenta {0}", idPlan), ex)
         End Try

         AgregarFila(dtDetalle,
               ObtenerDescCuenta(cuenta),
               Decimal.Parse(IIf(debe, eCajaDetalle.ImporteDolares * eCajaDetalle.CotizacionDolar * coe, 0).ToString()),
               Decimal.Parse(IIf(Not debe, eCajaDetalle.ImporteDolares * eCajaDetalle.CotizacionDolar * coe, 0).ToString()),
               idUltimoAsiento,
               cuenta.IdCuenta)
      End If

      If eCajaDetalle.ImporteCheques <> 0 Then 'Cheques de terceros
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Cheques)
            cuenta = medioPago.CuentaContable
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}", idPlan), ex)
         End Try
         If cuenta Is Nothing Then
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}", idPlan))
         End If
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debe, eCajaDetalle.ImporteCheques * coe, 0).ToString()),
                        Decimal.Parse(IIf(Not debe, eCajaDetalle.ImporteCheques * coe, 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If
      'SPC: Y cheques propios?

      'TARJETAS: Si usa contabilidad, no puede afectar Tarjetas en la Planilla de Caja
      '' ''If eCajaDetalle.ImporteTarjetas <> 0 Then

      '' ''   For Each VT As VentaTarjeta In oVenta.Tarjetas
      '' ''      Dim cuenta As ContabilidadCuenta
      '' ''      Try
      '' ''         cuenta = VT.Tarjeta.CuentaContable
      '' ''         If cuenta Is Nothing Then
      '' ''            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Tarjeta {0} en el plan de cuenta {1}",
      '' ''                                                          VT.Tarjeta.NombreTarjeta, oVenta.TipoComprobante.IdPlanCuenta))
      '' ''         End If
      '' ''      Catch ex As Exception
      '' ''         Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Tarjeta {0} en el plan de cuenta {1}",
      '' ''                                                       VT.Tarjeta.NombreTarjeta, oVenta.TipoComprobante.IdPlanCuenta), ex)
      '' ''      End Try

      '' ''      AgregarFila(dtDetalle,
      '' ''                     ObtenerDescCuenta(cuenta),
      '' ''                     Decimal.Parse(IIf(debe, VT.Monto, 0).ToString()),
      '' ''                     Decimal.Parse(IIf(Not debe, VT.Monto, 0).ToString()),
      '' ''                     idUltimoAsiento,
      '' ''                     cuenta.IdCuenta)
      '' ''   Next
      '' ''End If

      If eCajaDetalle.ImporteTickets <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta

         Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Tickets)
         cuenta = medioPago.CuentaContable
         If cuenta Is Nothing Then
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Tickets en el plan de cuenta {0}", idPlan))
         End If
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debe, eCajaDetalle.ImporteTickets * coe, 0).ToString()),
                        Decimal.Parse(IIf(Not debe, eCajaDetalle.ImporteTickets * coe, 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      'BANCOS: Si usa contabilidad, no puede afectar Bancos en la Planilla de Caja
      '' ''If oVenta.ImporteTransfBancaria <> 0 Then
      '' ''   Dim cuenta As ContabilidadCuenta
      '' ''   Try
      '' ''      cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(oVenta.CuentaBancariaTransfBanc.idCuentaContable)
      '' ''   Catch ex As Exception
      '' ''      Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} en el plan de cuenta {1}",
      '' ''                                                    oVenta.CuentaBancariaTransfBanc.NombreCuenta, oVenta.TipoComprobante.IdPlanCuenta), ex)
      '' ''   End Try
      '' ''   AgregarFila(dtDetalle,
      '' ''                  ObtenerDescCuenta(cuenta),
      '' ''                  Decimal.Parse(IIf(debe, oVenta.ImporteTransfBancaria, 0).ToString()),
      '' ''                  Decimal.Parse(IIf(Not debe, oVenta.ImporteTransfBancaria, 0).ToString()),
      '' ''                  idUltimoAsiento,
      '' ''                  cuenta.IdCuenta)
      '' ''End If

      Return dtDetalle

   End Function

   Friend Function ObtenerDescAsiento(ByRef fila As Entidades.CajaDetalles) As String
      Dim nombreCaja As String
      Try
         nombreCaja = New Reglas.CajasNombres(da).GetUna(fila.IdSucursal, fila.IdCaja).NombreCaja
      Catch ex As Exception
         nombreCaja = String.Empty
      End Try
      Dim nombreCuentaCaja As String
      Try
         nombreCuentaCaja = New Reglas.CuentasDeCajas(da).GetUna(fila.IdCuentaCaja).NombreCuentaCaja
      Catch ex As Exception
         nombreCuentaCaja = String.Empty
      End Try
      ' [IdSucursal],[nombreCaja],[NumeroPlanilla],[NumeroMovimiento],[nombreCuentaCaja]
      Return String.Format("{0}-{1} {2}-{3:00000000} - {4}",
                           fila.IdSucursal,
                           nombreCaja,
                           fila.NumeroPlanilla,
                           fila.NumeroMovimiento,
                           nombreCuentaCaja).Truncar(100)
   End Function

#End Region

End Class
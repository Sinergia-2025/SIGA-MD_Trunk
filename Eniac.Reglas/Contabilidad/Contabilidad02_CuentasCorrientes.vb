#Region "Option"
Option Explicit On
Option Strict On
#End Region
Partial Class Contabilidad

#Region "Cuenta Corriente Clientes"
   Friend Function RegistraContabilidad(ByVal oCtaCte As Entidades.CuentaCorriente) As Boolean
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
      Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
      Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios

      Try
         Dim idUltimoAsiento As Integer = 0
         Dim idEjercicioVigente As Integer
         Dim idPeriodoActual As String

         'obtengo el ejercicio vigente
         idEjercicioVigente = oEjercicio.GetEjercicioVigente(oCtaCte.Fecha)
         idPeriodoActual = oEjercicio.GetPeriodoActual(idEjercicioVigente, oCtaCte.Fecha)

         Dim idPlanCuenta As Integer = oCtaCte.TipoComprobante.IdPlanCuenta
         Dim tipoProceso As String = Entidades.ContabilidadProceso.Procesos.CuentaCte.ToString()

         'obtengo el ultimo id del los asientos
         idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idEjercicioVigente, idPlanCuenta) + 1

         sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                   idPlanCuenta,
                                   idUltimoAsiento,
                                   oCtaCte.Fecha,
                                   ObtenerDescAsiento(oCtaCte),
                                   0,
                                   oCtaCte.IdSucursal,
                                   tipoProceso,
                                   idEjercicioDefinitivo:=Nothing,
                                   idPlanCuentaDefinitivo:=Nothing,
                                   idAsientoDefinitivo:=Nothing)


         sqlAsientos.Asiento_I_Detalle_TMP(idEjercicioVigente,
                                           idPlanCuenta,
                                           idUltimoAsiento,
                                           AgruparAsiento(ArmarDetalle(oCtaCte, idUltimoAsiento)))

         sql.MarcarRegistroProcesado(oCtaCte, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)

         If Not String.IsNullOrWhiteSpace(oCtaCte.TipoComprobante.IdTipoComprobanteSecundario) Then
            Dim oCtaCteSec As Entidades.CuentaCorriente = New Entidades.CuentaCorriente()
            oCtaCteSec.IdSucursal = oCtaCte.IdSucursal
            oCtaCteSec.TipoComprobante.IdTipoComprobante = oCtaCte.TipoComprobante.IdTipoComprobanteSecundario
            oCtaCteSec.Letra = oCtaCte.Letra
            oCtaCteSec.CentroEmisor = oCtaCte.CentroEmisor
            oCtaCteSec.NumeroComprobante = oCtaCte.NumeroComprobante

            sql.MarcarRegistroProcesado(oCtaCteSec, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)
         End If

      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
      Return True
   End Function

   Friend Function ArmarDetalle(ByVal oCtaCte As Entidades.CuentaCorriente) As DataTable
      Return ArmarDetalle(oCtaCte, 0)
   End Function

   Private Function ArmarDetalle(ByVal oCtaCte As Entidades.CuentaCorriente, ByVal idUltimoAsiento As Integer) As DataTable

      Dim dtDetalle As DataTable = CrearTablaDetalle()

      Dim cuentaCtaCteDebe As Eniac.Entidades.ContabilidadCuenta
      Try
         cuentaCtaCteDebe = New Reglas.ContabilidadCuentas(da)._GetUna(ContabilidadPublicos.ContabilidadCuentaVentas(da))
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas la Cuenta de Ventas en Parámetros del Sistema."), ex)
      End Try

      'si el coeficiente del comprobante es positivo va al DEBE sino va al HABER
      Dim debe As Boolean = (oCtaCte.TipoComprobante.CoeficienteValores = -1)

      Dim importeTotal As Decimal = oCtaCte.ImportePesos + (oCtaCte.ImporteDolares * oCtaCte.CotizacionDolar) + oCtaCte.ImporteCheques + oCtaCte.ImporteRetenciones + oCtaCte.ImporteTarjetas + oCtaCte.ImporteTickets + oCtaCte.ImporteTransfBancaria

      Dim totalAplicado As Decimal = 0

      For Each ccp As Entidades.CuentaCorrientePago In oCtaCte.Pagos

         Dim cuenta As Entidades.ContabilidadCuenta = Nothing
         If oCtaCte.Cliente.IdCuentaContable > 0 Then
            cuenta = oCtaCte.Cliente.CuentaContable
         Else
            Dim categoria As Entidades.Categoria = Nothing
            Try
               Try
                  Dim oVenta As Entidades.Venta = New Ventas(da).GetUna(ccp.IdSucursal, ccp.IdTipoComprobante, ccp.Letra, CShort(ccp.CentroEmisor), ccp.NumeroComprobante)
                  categoria = New Reglas.Categorias(da).GetUno(oVenta.IdCategoria)
                  If oVenta.TipoComprobante.UtilizaCtaSecundariaCateg Then
                     cuenta = categoria.CuentaSecundaria
                  End If
               Catch
                  Try
                     Dim oVenta As Entidades.CuentaCorriente = New CuentasCorrientes(da)._GetUna(ccp.IdSucursal, ccp.IdTipoComprobante, ccp.Letra, ccp.CentroEmisor, ccp.NumeroComprobante)
                     categoria = New Reglas.Categorias(da).GetUno(oVenta.IdCategoria)
                     If oVenta.TipoComprobante.UtilizaCtaSecundariaCateg Then
                        cuenta = categoria.CuentaSecundaria
                     End If
                  Catch
                  End Try
               End Try
               If categoria Is Nothing Then categoria = New Reglas.Categorias(da).GetUno(oCtaCte.IdCategoria)
               If cuenta Is Nothing Then
                  cuenta = categoria.Cuenta
                  If cuenta Is Nothing Then
                     cuenta = cuentaCtaCteDebe
                  End If
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el cliente {0} - {1} en el plan de cuenta {2}",
                                                             oCtaCte.Cliente.IdCliente, oCtaCte.Cliente.NombreCliente, oCtaCte.TipoComprobante.IdPlanCuenta), ex)
            End Try
         End If

         Dim debeCCP As Boolean = ccp.Paga * oCtaCte.TipoComprobante.CoeficienteValores < 0
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(Not debeCCP, Math.Abs(ccp.Paga), 0).ToString()),
                        Decimal.Parse(IIf(debeCCP, Math.Abs(ccp.Paga), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta,
                        "C", oCtaCte.Cliente.IdCliente.ToString())
         totalAplicado += ccp.Paga * oCtaCte.TipoComprobante.CoeficienteValores
      Next

      If (importeTotal * oCtaCte.TipoComprobante.CoeficienteValores) - totalAplicado <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         If oCtaCte.Cliente.IdCuentaContable > 0 Then
            cuenta = oCtaCte.Cliente.CuentaContable
         Else
            Try
               cuenta = New Reglas.Categorias(da).GetUno(oCtaCte.IdCategoria).Cuenta
               If cuenta Is Nothing Then
                  cuenta = cuentaCtaCteDebe
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el cliente {0} - {1} en el plan de cuenta {2}",
                                                             oCtaCte.Cliente.IdCliente, oCtaCte.Cliente.NombreCliente, oCtaCte.TipoComprobante.IdPlanCuenta), ex)
            End Try
         End If
         Dim debeAnticipo As Boolean = debe
         If (importeTotal * oCtaCte.TipoComprobante.CoeficienteValores) - totalAplicado > 0 Then
            debeAnticipo = Not debeAnticipo
         End If
         'If totalAplicado = 0 Then
         '   If importeTotal < 0 Then
         '      debeAnticipo = Not debeAnticipo
         '   End If
         'Else
         '   If totalAplicado > 0 Then
         '      debeAnticipo = Not debeAnticipo
         '   End If
         'End If
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(Not debeAnticipo, Math.Abs((importeTotal * oCtaCte.TipoComprobante.CoeficienteValores) - totalAplicado), 0).ToString()),
                        Decimal.Parse(IIf(debeAnticipo, Math.Abs((importeTotal * oCtaCte.TipoComprobante.CoeficienteValores) - totalAplicado), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta,
                        "C", oCtaCte.Cliente.IdCliente.ToString())
      End If

      If oCtaCte.ImportePesos <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta = Nothing
         Try
            Dim caja As Entidades.CajaNombre = New CajasNombres(da).GetUna(oCtaCte.IdSucursal, oCtaCte.CajaDetalle.IdCaja)
            If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               'cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(New CajasNombres(da).GetUna(oCtaCte.IdSucursal, oCtaCte.CajaDetalle.IdCaja).IdCuentaContable)
               'If cuenta.IdCuenta = 0 Then
               Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Pesos)
               cuenta = medioPago.CuentaContable
            End If
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                              oCtaCte.TipoComprobante.IdPlanCuenta))
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                          oCtaCte.TipoComprobante.IdPlanCuenta), ex)
         End Try
         Dim debeVuelto As Boolean = debe
         If oCtaCte.TipoComprobante.ImporteTope < 0 Then
            debeVuelto = Not debe
         Else
            'SI EL SIGNO DE LA TRANSFERENCIA ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
            'If oCtaCte.ImportePesos / Math.Abs(oCtaCte.ImportePesos) <> importeTotal / Math.Abs(importeTotal) Then
            If oCtaCte.ImportePesos < 0 Then
               debeVuelto = Not debe
            End If
         End If

         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debeVuelto, Math.Abs(oCtaCte.ImportePesos), 0).ToString()),
                        Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCtaCte.ImportePesos), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCte.ImporteDolares <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta = Nothing
         Try
            'TODO: De momento no tenemos configurada una cuenta contable para Dolares en las Cajas
            'Dim caja As CajaNombre = New CajasNombres(da).GetUna(oCtaCte.IdSucursal, oCtaCte.CajaDetalle.IdCaja)
            'If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               'cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(New CajasNombres(da).GetUna(oCtaCte.IdSucursal, oCtaCte.CajaDetalle.IdCaja).IdCuentaContable)
               'If cuenta.IdCuenta = 0 Then
               Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Dolares)
               cuenta = medioPago.CuentaContable
            End If
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Dolares en el plan de cuenta {0}",
                                              oCtaCte.TipoComprobante.IdPlanCuenta))
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Dolares en el plan de cuenta {0}",
                                                          oCtaCte.TipoComprobante.IdPlanCuenta), ex)
         End Try
         Dim debeVuelto As Boolean = debe
         'TODO: Hay que ver si esto aplica para el caso de Dolares
         'If oCtaCte.TipoComprobante.ImporteTope < 0 Then
         '   debeVuelto = Not debe
         'Else
         '   'SI EL SIGNO DE LA TRANSFERENCIA ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
         '   'If oCtaCte.ImporteDolares / Math.Abs(oCtaCte.ImporteDolares) <> importeTotal / Math.Abs(importeTotal) Then
         '   If oCtaCte.ImporteDolares < 0 Then
         '      debeVuelto = Not debe
         '   End If
         'End If

         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debeVuelto, Math.Abs(oCtaCte.ImporteDolares * oCtaCte.CotizacionDolar), 0).ToString()),
                        Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCtaCte.ImporteDolares * oCtaCte.CotizacionDolar), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCte.ImporteCheques <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Cheques)
            cuenta = medioPago.CuentaContable
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}",
                                                          oCtaCte.TipoComprobante.IdPlanCuenta), ex)
         End Try
         If cuenta Is Nothing Then
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}", oCtaCte.TipoComprobante.IdPlanCuenta))
         End If
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debe, Math.Abs(oCtaCte.ImporteCheques), 0).ToString()),
                        Decimal.Parse(IIf(Not debe, Math.Abs(oCtaCte.ImporteCheques), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCte.ImporteTarjetas <> 0 Then

         For Each VT As Entidades.VentaTarjeta In oCtaCte.Tarjetas
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               cuenta = VT.Tarjeta.CuentaContable
               If cuenta Is Nothing Then
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Tarjeta {0} en el plan de cuenta {1}",
                                                                VT.Tarjeta.NombreTarjeta, oCtaCte.TipoComprobante.IdPlanCuenta))
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Tarjeta {0} en el plan de cuenta {1}",
                                                             VT.Tarjeta.NombreTarjeta, oCtaCte.TipoComprobante.IdPlanCuenta), ex)
            End Try

            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(VT.Monto), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(VT.Monto), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         Next
      End If

      If oCtaCte.ImporteTickets <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Tickets)
            cuenta = medioPago.CuentaContable
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Tickets en el plan de cuenta {0}",
                                                          oCtaCte.TipoComprobante.IdPlanCuenta), ex)
         End Try
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debe, Math.Abs(oCtaCte.ImporteTickets), 0).ToString()),
                        Decimal.Parse(IIf(Not debe, Math.Abs(oCtaCte.ImporteTickets), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCte.ImporteTransfBancaria <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(oCtaCte.CuentaBancariaTransfBanc.idCuentaContable)
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} en el plan de cuenta {1}",
                                                          oCtaCte.CuentaBancariaTransfBanc.NombreCuenta, oCtaCte.TipoComprobante.IdPlanCuenta), ex)
         End Try
         Dim debeVuelto As Boolean = debe
         If oCtaCte.TipoComprobante.ImporteTope < 0 Then
            debeVuelto = Not debe
         Else
            'SI EL SIGNO DE LA TRANSFERENCIA ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
            If oCtaCte.ImporteTransfBancaria / Math.Abs(oCtaCte.ImporteTransfBancaria) <> importeTotal / Math.Abs(importeTotal) Then
               'If oCtaCte.ImporteTransfBancaria < 0 Then
               debeVuelto = Not debe
            End If
         End If

         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debeVuelto, Math.Abs(oCtaCte.ImporteTransfBancaria), 0).ToString()),
                        Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCtaCte.ImporteTransfBancaria), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCte.ImporteRetenciones <> 0 Then
         For Each rt As Entidades.Retencion In oCtaCte.Retenciones
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               cuenta = New Reglas.Impuestos(da).GetUno(rt.IdTipoImpuesto.ToString(), rt.Alicuota).CuentaVentas
            Catch ex As Exception
               cuenta = New Entidades.ContabilidadCuenta()
            End Try
            If cuenta.IdCuenta = 0 Then
               Try
                  cuenta = New Reglas.Impuestos(da).GetUno(rt.IdTipoImpuesto.ToString(), 0).CuentaVentas
               Catch ex As Exception
                  cuenta = New Entidades.ContabilidadCuenta()
               End Try
            End If
            If cuenta.IdCuenta = 0 Then
               Try
                  cuenta = rt.TipoImpuesto.CuentaVentas
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                                rt.TipoImpuesto.IdTipoImpuesto, oCtaCte.TipoComprobante.IdPlanCuenta), ex)
               End Try
            End If
            If cuenta.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                             rt.TipoImpuesto.IdTipoImpuesto, oCtaCte.TipoComprobante.IdPlanCuenta))
            End If

            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(rt.ImporteTotal), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(rt.ImporteTotal), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         Next
      End If

      Return dtDetalle
   End Function

   Friend Function ObtenerDescAsiento(ByVal fila As Entidades.CuentaCorriente) As String
      '[IdSucursal],[TipoComprobante.Descripcion],[Letra],[CentroEmisor],[NumeroComprobante],[NombreCliente],[CodigoCliente]
      Return String.Format("{0}-{1} {2} {3:0000}-{4:00000000} - {5} ({6})",
                           fila.IdSucursal,
                           fila.TipoComprobante.Descripcion,
                           fila.Letra,
                           fila.CentroEmisor,
                           fila.NumeroComprobante,
                           fila.Cliente.NombreCliente,
                           fila.Cliente.CodigoCliente).Truncar(100)
   End Function
#End Region

End Class
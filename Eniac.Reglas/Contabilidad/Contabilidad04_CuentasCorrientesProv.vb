#Region "Option"
Option Explicit On
Option Strict On
#End Region
Partial Class Contabilidad

#Region "Cuenta Corriente Proveedores"
   Friend Function RegistraContabilidad(ByVal oCtaCteProv As Entidades.CuentaCorrienteProv) As Boolean
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
      Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
      Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios

      Try
         Dim idUltimoAsiento As Integer = 0
         Dim idEjercicioVigente As Integer
         Dim idPeriodoActual As String

         'obtengo el ejercicio vigente
         idEjercicioVigente = oEjercicio.GetEjercicioVigente(oCtaCteProv.Fecha)
         idPeriodoActual = oEjercicio.GetPeriodoActual(idEjercicioVigente, oCtaCteProv.Fecha)

         Dim idPlanCuenta As Integer = oCtaCteProv.TipoComprobante.IdPlanCuenta
         Dim tipoProceso As String = Entidades.ContabilidadProceso.Procesos.PagoProv.ToString()

         'obtengo el ultimo id del los asientos
         idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idEjercicioVigente, idPlanCuenta) + 1

         sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                   idPlanCuenta,
                                   idUltimoAsiento,
                                   oCtaCteProv.Fecha,
                                   ObtenerDescAsiento(oCtaCteProv),
                                   0,
                                   oCtaCteProv.IdSucursal,
                                   tipoProceso,
                                   idEjercicioDefinitivo:=Nothing,
                                   idPlanCuentaDefinitivo:=Nothing,
                                   idAsientoDefinitivo:=Nothing)


         sqlAsientos.Asiento_I_Detalle_TMP(idEjercicioVigente,
                                           idPlanCuenta,
                                           idUltimoAsiento,
                                           AgruparAsiento(ArmarDetalle(oCtaCteProv, idUltimoAsiento)))

         sql.MarcarRegistroProcesado(oCtaCteProv, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)

         'TODO: DESHARDCODEAR! ASÍ ESTÁ EN LA PANTALLA DE GENERACIÓN. POR LO QUE DEBERÍA SER CAMBIADO TAMBIÉN ALLÍ.
         'UNA VEZ CAMBIADO EN LA GENERACIÓN. VENIR Y CAMBIAR AQUÍ.
         '  Dim idTipoComprobanteSecundario As String = String.Empty

         'If oCtaCteProv.TipoComprobante.IdTipoComprobante.Trim() = "ANTICIPO" Then
         '   idTipoComprobanteSecundario = "PAGO"
         'ElseIf oCtaCteProv.TipoComprobante.IdTipoComprobante.Trim() = "ANTICIPOPROV" Then
         '   idTipoComprobanteSecundario = "PAGOPROV"
         'ElseIf oCtaCteProv.TipoComprobante.IdTipoComprobante.Trim() = "PAGO" Then
         '   idTipoComprobanteSecundario = "ANTICIPO"
         'ElseIf oCtaCteProv.TipoComprobante.IdTipoComprobante.Trim() = "PAGOPROV" Then
         '   idTipoComprobanteSecundario = "ANTICIPOPROV"
         'End If

         'If Not String.IsNullOrWhiteSpace(idTipoComprobanteSecundario) Then
         If Not String.IsNullOrWhiteSpace(oCtaCteProv.TipoComprobante.IdTipoComprobanteSecundario) Then
            Dim oCtaCteProvSec As Entidades.CuentaCorrienteProv = New Entidades.CuentaCorrienteProv()
            oCtaCteProvSec.IdSucursal = oCtaCteProv.IdSucursal
            oCtaCteProvSec.TipoComprobante.IdTipoComprobante = oCtaCteProv.TipoComprobante.IdTipoComprobanteSecundario
            oCtaCteProvSec.Letra = oCtaCteProv.Letra
            oCtaCteProvSec.CentroEmisor = oCtaCteProv.CentroEmisor
            oCtaCteProvSec.NumeroComprobante = oCtaCteProv.NumeroComprobante
            oCtaCteProvSec.Proveedor = oCtaCteProv.Proveedor

            sql.MarcarRegistroProcesado(oCtaCteProvSec, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)
         End If

      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
      Return True
   End Function

   Friend Function ArmarDetalle(ByVal oCtaCteProv As Entidades.CuentaCorrienteProv) As DataTable
      Return ArmarDetalle(oCtaCteProv, 0)
   End Function

   Private Function ArmarDetalle(ByVal oCtaCteProv As Entidades.CuentaCorrienteProv, ByVal idUltimoAsiento As Integer) As DataTable

      Dim dtDetalle As DataTable = CrearTablaDetalle()

      Dim cuentaCtaCteDebe As Eniac.Entidades.ContabilidadCuenta
      Try
         cuentaCtaCteDebe = New Reglas.ContabilidadCuentas(da)._GetUna(ContabilidadPublicos.ContabilidadCuentaCompras(da))
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas la Cuenta de Compras en Parámetros del Sistema."), ex)
      End Try

      'si el coeficiente del comprobante es positivo va al DEBE sino va al HABER
      Dim debe As Boolean = (oCtaCteProv.TipoComprobante.CoeficienteValores = 1)

      Dim importeTotal As Decimal = oCtaCteProv.ImporteTotal

      If importeTotal <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            cuenta = oCtaCteProv.Proveedor.CuentaContable
            If cuenta Is Nothing Then
               cuenta = New Reglas.CategoriasProveedores(da).GetUno(oCtaCteProv.Proveedor.Categoria.IdCategoria).CuentaContable
               If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                  cuenta = cuentaCtaCteDebe
               End If
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el cliente {0} - {1} en el plan de cuenta {2}",
                                                          oCtaCteProv.Proveedor.IdProveedor, oCtaCteProv.Proveedor.NombreProveedor, oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         End Try

         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(Not debe, Math.Abs(importeTotal), 0).ToString()),
                        Decimal.Parse(IIf(debe, Math.Abs(importeTotal), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta,
                        "P", oCtaCteProv.Proveedor.IdProveedor.ToString())
      End If

      If oCtaCteProv.ImportePesos <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta = Nothing
         Try
            Dim caja As Entidades.CajaNombre = New CajasNombres(da).GetUna(oCtaCteProv.IdSucursal, oCtaCteProv.CajaDetalle.IdCaja)
            If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               'cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(New CajasNombres(da).GetUna(oCtaCteProv.IdSucursal, oCtaCteProv.CajaDetalle.IdCaja).IdCuentaContable)
               'If cuenta.IdCuenta = 0 Then
               Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Pesos)
               cuenta = medioPago.CuentaContable
            End If
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                              oCtaCteProv.TipoComprobante.IdPlanCuenta))
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                          oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         End Try
         Dim debeVuelto As Boolean = debe
         'SI EL SIGNO DE LA TRANSFERENCIA ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
         If oCtaCteProv.ImportePesos / Math.Abs(oCtaCteProv.ImportePesos) <> importeTotal / Math.Abs(importeTotal) Then
            debeVuelto = Not debe
         End If
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debeVuelto, Math.Abs(oCtaCteProv.ImportePesos), 0).ToString()),
                        Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCtaCteProv.ImportePesos), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCteProv.ImporteCheques <> 0 Then
         Dim medioPago As Entidades.MedioDePago
         Try
            medioPago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Cheques)
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}",
                                                          oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         End Try
         For Each chk As Entidades.Cheque In oCtaCteProv.ChequesTerceros
            Dim cuenta As Entidades.ContabilidadCuenta = medioPago.CuentaContable
            If cuenta Is Nothing Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}", oCtaCteProv.TipoComprobante.IdPlanCuenta))
            End If
            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(chk.Importe), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(chk.Importe), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         Next
         For Each chk As Entidades.Cheque In oCtaCteProv.ChequesPropios
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(chk.CuentaBancaria.idCuentaContable)
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques Propios en el plan de cuenta {0}",
                                                             oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
            End Try
            If cuenta Is Nothing Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques Propios en el plan de cuenta {0}", oCtaCteProv.TipoComprobante.IdPlanCuenta))
            End If
            AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           Decimal.Parse(IIf(debe, Math.Abs(chk.Importe), 0).ToString()),
                           Decimal.Parse(IIf(Not debe, Math.Abs(chk.Importe), 0).ToString()),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
         Next
      End If

      If oCtaCteProv.ImporteTarjetas <> 0 Then

         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Tarjetas)
            cuenta = medioPago.CuentaContable
            If cuenta Is Nothing Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe de Tarjeta en el plan de cuenta {0}",
                                                             oCtaCteProv.TipoComprobante.IdPlanCuenta))
            End If
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe de Tarjeta en el plan de cuenta {0}",
                                                          oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         End Try

         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debe, Math.Abs(oCtaCteProv.ImporteTarjetas), 0).ToString()),
                        Decimal.Parse(IIf(Not debe, Math.Abs(oCtaCteProv.ImporteTarjetas), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCteProv.ImporteTickets <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Tickets)
            cuenta = medioPago.CuentaContable
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Tickets en el plan de cuenta {0}",
                                                          oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         End Try
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debe, Math.Abs(oCtaCteProv.ImporteTickets), 0).ToString()),
                        Decimal.Parse(IIf(Not debe, Math.Abs(oCtaCteProv.ImporteTickets), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCteProv.ImporteTransfBancaria <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(oCtaCteProv.CuentaBancariaTransfBanc.idCuentaContable)
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} en el plan de cuenta {1}",
                                                          oCtaCteProv.CuentaBancariaTransfBanc.NombreCuenta, oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         End Try
         Dim debeVuelto As Boolean = debe
         'SI EL SIGNO DE LA TRANSFERENCIA ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
         If oCtaCteProv.ImporteTransfBancaria / Math.Abs(oCtaCteProv.ImporteTransfBancaria) <> importeTotal / Math.Abs(importeTotal) Then
            debeVuelto = Not debe
         End If
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debeVuelto, Math.Abs(oCtaCteProv.ImporteTransfBancaria), 0).ToString()),
                        Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCtaCteProv.ImporteTransfBancaria), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCteProv.ImporteDolares <> 0 Then
         Dim cuenta As Entidades.ContabilidadCuenta
         Try
            'obtengo la CajasNombres para luego poder sacar la cuenta de contable de caja dolares
            Dim rgCaj As Reglas.CajasNombres = New CajasNombres(Me.da)
            Dim enCaj As Entidades.CajaNombre = rgCaj.GetUna(oCtaCteProv.CajaDetalle.IdSucursal, oCtaCteProv.CajaDetalle.IdCaja)

            cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(enCaj.IdCuentaContable)
         Catch ex As Exception
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} en el plan de cuenta {1}",
                                                          oCtaCteProv.CuentaBancariaTransfBanc.NombreCuenta, oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
         End Try
         Dim debeVuelto As Boolean = debe
         'SI EL SIGNO DE LA TRANSFERENCIA ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
         If importeTotal.MismoSigno(oCtaCteProv.ImporteDolares) Then
            debeVuelto = Not debe
         End If
         AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        Decimal.Parse(IIf(debeVuelto, Math.Abs(oCtaCteProv.ImporteDolares * oCtaCteProv.CotizacionDolar), 0).ToString()),
                        Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCtaCteProv.ImporteDolares * oCtaCteProv.CotizacionDolar), 0).ToString()),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
      End If

      If oCtaCteProv.ImporteRetenciones <> 0 Then
         For Each rt As Entidades.RetencionCompra In oCtaCteProv.Retenciones
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               cuenta = New Reglas.Impuestos(da).GetUno(rt.IdTipoImpuesto.ToString(), rt.Alicuota).CuentaCompras
            Catch ex As Exception
               cuenta = New Entidades.ContabilidadCuenta()
            End Try
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Try
                  cuenta = New Reglas.Impuestos(da).GetUno(rt.IdTipoImpuesto.ToString(), 0).CuentaCompras
               Catch ex As Exception
                  cuenta = New Entidades.ContabilidadCuenta()
               End Try
            End If
            If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
               Try
                  cuenta = rt.TipoImpuesto.CuentaCompras
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                                rt.TipoImpuesto.IdTipoImpuesto, oCtaCteProv.TipoComprobante.IdPlanCuenta), ex)
               End Try
            End If
            If cuenta.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                             rt.TipoImpuesto.IdTipoImpuesto, oCtaCteProv.TipoComprobante.IdPlanCuenta))
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

   Friend Function ObtenerDescAsiento(ByVal fila As Entidades.CuentaCorrienteProv) As String
      '[IdSucursal],[TipoComprobante.Descripcion],[Letra],[CentroEmisor],[NumeroComprobante],[NombreProveedor],[CodigoProveedor]
      Return String.Format("{0}-{1} {2} {3:0000}-{4:00000000} - {5} ({6})",
                           fila.IdSucursal,
                           fila.TipoComprobante.Descripcion,
                           fila.Letra,
                           fila.CentroEmisor,
                           fila.NumeroComprobante,
                           fila.Proveedor.NombreProveedor,
                           fila.Proveedor.CodigoProveedor).Truncar(100)
   End Function
#End Region

End Class
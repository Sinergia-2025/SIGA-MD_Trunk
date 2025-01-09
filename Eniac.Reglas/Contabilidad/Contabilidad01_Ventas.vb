Partial Class Contabilidad

#Region "Ventas"
   Friend Function RegistraContabilidad(oventas As Entidades.Venta) As Boolean
      Dim sql = New SqlServer.ContabilidadProcesos(da)
      Dim sqlAsientos = New SqlServer.ContabilidadAsientosTmp(da)
      Dim rEjercicio = New ContabilidadEjercicios

      Try
         'Obtengo el ejercicio vigente
         Dim idEjercicioVigente = rEjercicio.GetEjercicioVigente(oventas.Fecha)
         Dim idPeriodoActual = rEjercicio.GetPeriodoActual(idEjercicioVigente, oventas.Fecha)

         Dim idPlanCuenta = oventas.TipoComprobante.IdPlanCuenta
         Dim tipoProceso = Entidades.ContabilidadProceso.Procesos.VENTAS.ToString()

         'obtengo el ultimo id del los asientos
         Dim idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idEjercicioVigente, idPlanCuenta) + 1

         sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                   idPlanCuenta,
                                   idUltimoAsiento,
                                   oventas.Fecha,
                                   ObtenerDescAsiento(oventas),
                                   0,
                                   oventas.IdSucursal,
                                   tipoProceso,
                                   idEjercicioDefinitivo:=Nothing,
                                   idPlanCuentaDefinitivo:=Nothing,
                                   idAsientoDefinitivo:=Nothing)

         sqlAsientos.Asiento_I_Detalle_TMP(idEjercicioVigente,
                                           idPlanCuenta,
                                           idUltimoAsiento,
                                           AgruparAsiento(ArmarDetalle(oventas, idUltimoAsiento)))

         sql.MarcarRegistroProcesado(oventas, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)

         sql.MarcarCtaCteRegistroProcesado(oventas)

      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
      Return True
   End Function

   Public Sub MarcarCtaCteRegistroProcesado(oventas As Entidades.Venta)
      Try
         Dim sql = New SqlServer.ContabilidadProcesos(da)
         sql.MarcarCtaCteRegistroProcesado(oventas)
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try

   End Sub

   Friend Function ArmarDetalle(oVenta As Entidades.Venta) As DataTable
      Return ArmarDetalle(oVenta, 0)
   End Function

   Private Function ArmarDetalle(venta As Entidades.Venta, idUltimoAsiento As Integer) As DataTable

      Dim dtDetalle = CrearTablaDetalle()

      Dim cuentaCtaCteDebe As Entidades.ContabilidadCuenta
      Try
         cuentaCtaCteDebe = New ContabilidadCuentas(da)._GetUna(ContabilidadPublicos.ContabilidadCuentaVentas(da))
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas la Cuenta de Ventas en Parámetros del Sistema."), ex)
      End Try

      'si el coeficiente del comprobante es positivo va al DEBE sino va al HABER
      Dim coe = venta.TipoComprobante.CoeficienteValores
      Dim debe = (coe = 1)

      If venta.FormaPago.Dias <> 0 Then
         If venta.ImporteTotal <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta = Nothing
            If venta.Cliente.IdCuentaContable > 0 Then
               cuenta = venta.Cliente.CuentaContable
            Else
               Try
                  Dim categoria = New Categorias(da).GetUno(venta.IdCategoria)
                  If venta.TipoComprobante.UtilizaCtaSecundariaCateg Then
                     cuenta = categoria.CuentaSecundaria
                  End If
                  If cuenta Is Nothing Then
                     cuenta = categoria.Cuenta
                     If cuenta Is Nothing Then
                        cuenta = cuentaCtaCteDebe
                     End If
                  End If
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el cliente {0} - {1} en el plan de cuenta {2}",
                                                                venta.Cliente.IdCliente, venta.Cliente.NombreCliente, venta.TipoComprobante.IdPlanCuenta), ex)
               End Try
            End If

            AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        If(debe, Math.Abs(venta.ImporteTotal), 0D),
                        If(Not debe, Math.Abs(venta.ImporteTotal), 0D),
                        idUltimoAsiento,
                        cuenta.IdCuenta,
                        "C", venta.Cliente.IdCliente.ToString())
         End If
         Else
         If venta.ImportePesos <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta = Nothing
            Try
               Dim caja = New CajasNombres(da).GetUna(venta.IdSucursal, venta.IdCaja)
               If caja.IdCuentaContable > 0 Then cuenta = New ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
               If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                  'cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(New CajasNombres(da).GetUna(oVenta.IdSucursal, oVenta.IdCaja).IdCuentaContable)
                  'If cuenta.IdCuenta = 0 Then
                  Dim medioPago = New MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Pesos)
                  cuenta = medioPago.CuentaContable
               End If
               If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                 venta.TipoComprobante.IdPlanCuenta))
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                             venta.TipoComprobante.IdPlanCuenta), ex)
            End Try
            Dim debeVuelto As Boolean = debe
            'SI EL SIGNO DEL EFECTIVO ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
            If venta.ImportePesos < 0 Then
               debeVuelto = Not debe
            End If
            AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        If(debeVuelto, Math.Abs(venta.ImportePesos), 0D),
                        If(Not debeVuelto, Math.Abs(venta.ImportePesos), 0D),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
         End If

            If venta.ImporteCheques <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               Dim medioPago = New MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Cheques)
               cuenta = medioPago.CuentaContable
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}",
                                                             venta.TipoComprobante.IdPlanCuenta), ex)
            End Try
            If cuenta Is Nothing Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}", venta.TipoComprobante.IdPlanCuenta))
            End If

            AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        If(debe, Math.Abs(venta.ImporteCheques), 0D),
                        If(Not debe, Math.Abs(venta.ImporteCheques), 0D),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
         End If

            If venta.ImporteTarjetas <> 0 Then

            For Each VT In venta.Tarjetas
               Dim cuenta As Entidades.ContabilidadCuenta
               Try
                  cuenta = VT.Tarjeta.CuentaContable
                  If cuenta Is Nothing Then
                     Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Tarjeta {0} en el plan de cuenta {1}",
                                                                   VT.Tarjeta.NombreTarjeta, venta.TipoComprobante.IdPlanCuenta))
                  End If
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Tarjeta {0} en el plan de cuenta {1}",
                                                                VT.Tarjeta.NombreTarjeta, venta.TipoComprobante.IdPlanCuenta), ex)
               End Try

               AgregarFila(dtDetalle,
                           ObtenerDescCuenta(cuenta),
                           If(debe, Math.Abs(VT.Monto), 0D),
                           If(Not debe, Math.Abs(VT.Monto), 0D),
                           idUltimoAsiento,
                           cuenta.IdCuenta)
            Next
         End If

         If venta.ImporteTickets <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta

            Dim medioPago = New MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Tickets)
            cuenta = medioPago.CuentaContable
            If cuenta Is Nothing Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Tickets en el plan de cuenta {0}",
                                                             venta.TipoComprobante.IdPlanCuenta))
            End If
            AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        If(debe, Math.Abs(venta.ImporteTickets), 0D),
                        If(Not debe, Math.Abs(venta.ImporteTickets), 0D),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
         End If

            If venta.ImporteTransfBancaria <> 0 Then
            Dim cuenta As Entidades.ContabilidadCuenta
            Try
               cuenta = New ContabilidadCuentas(da)._GetUna(venta.CuentaBancariaTransfBanc.idCuentaContable)
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} en el plan de cuenta {1}",
                                                             venta.CuentaBancariaTransfBanc.NombreCuenta, venta.TipoComprobante.IdPlanCuenta), ex)
            End Try
            Dim debeVuelto As Boolean = debe
            'SI EL SIGNO DE LA TRANSFERENCIA NEGATIVO (teniendo en cuenta el coeficiente de valores) ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
            If venta.ImporteTransfBancaria * coe < 0 And venta.ImporteTotal > 0 Then
               debeVuelto = Not debe
            End If
            AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuenta),
                        If(debeVuelto, Math.Abs(venta.ImporteTransfBancaria), 0D),
                        If(Not debeVuelto, Math.Abs(venta.ImporteTransfBancaria), 0D),
                        idUltimoAsiento,
                        cuenta.IdCuenta)
         End If
      End If



      For Each VP In venta.VentasProductos
         If VP.Producto.EsObservacion Then Continue For

         Dim cuentaBruto = New Entidades.ContabilidadCuenta()
         If VP.Producto.CuentaVentas Is Nothing OrElse VP.Producto.CuentaVentas.IdCuenta <= 0 Then
            cuentaBruto = New Entidades.ContabilidadCuenta()
            Dim drCol = venta.tablaContabilidad.Select("IdProducto = '" + VP.IdProducto + "'")
            If drCol.Length > 0 Then
               cuentaBruto.IdCuenta = Long.Parse(drCol(0)("IdCuenta").ToString())
               cuentaBruto.NombreCuenta = drCol(0)("NombreCuenta").ToString()
            Else
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el rubro del producto {0} en el plan de cuenta {1}",
                                                             VP.IdProducto, venta.TipoComprobante.IdPlanCuenta))
            End If
         Else
            cuentaBruto = VP.Producto.CuentaVentas
         End If
         AgregarFila(dtDetalle,
                     ObtenerDescCuenta(cuentaBruto),
                     If(Not debe, VP.ImporteTotalNeto * coe, 0D),
                     If(debe, VP.ImporteTotalNeto * coe, 0D),
                     idUltimoAsiento,
                     cuentaBruto.IdCuenta,
                     VP.IdCentroCosto)
      Next

      For Each colVI In {venta.VentasImpuestos, venta.ImpuestosVarios}
         For Each VI In colVI 'oVenta.VentasImpuestos
            Dim cuentaImpuesto As Entidades.ContabilidadCuenta = Nothing
            Try
               Try
                  cuentaImpuesto = New Impuestos(da).GetUno(VI.IdTipoImpuesto.ToString(), VI.Alicuota).CuentaVentas
               Catch ex As Exception
                  cuentaImpuesto = Nothing
               End Try
               If cuentaImpuesto Is Nothing OrElse cuentaImpuesto.IdCuenta = 0 Then
                  cuentaImpuesto = VI.TipoImpuesto.CuentaVentas
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                             VI.IdTipoImpuesto, venta.TipoComprobante.IdPlanCuenta), ex)
            End Try

            If cuentaImpuesto Is Nothing OrElse cuentaImpuesto.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                             VI.IdTipoImpuesto, venta.TipoComprobante.IdPlanCuenta))
            End If
            AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuentaImpuesto),
                        If(Not debe, Math.Abs(VI.Importe), 0D),
                        If(debe, Math.Abs(VI.Importe), 0D),
                        idUltimoAsiento,
                        cuentaImpuesto.IdCuenta)
         Next
      Next

      Return dtDetalle
   End Function

   Friend Function ObtenerDescAsiento(fila As Entidades.Venta) As String
      '[IdSucursal],[TipoComprobante.Descripcion],[Letra],[CentroEmisor],[NumeroComprobante],[NombreCliente],[CodigoCliente]
      Return String.Format("{0}-{1} {2} {3:0000}-{4:00000000} - {5} ({6})",
                           fila.IdSucursal,
                           fila.TipoComprobante.Descripcion, fila.LetraComprobante,
                           fila.CentroEmisor, fila.NumeroComprobante,
                           fila.Cliente.NombreCliente, fila.Cliente.CodigoCliente).Truncar(100)
   End Function

#End Region

End Class
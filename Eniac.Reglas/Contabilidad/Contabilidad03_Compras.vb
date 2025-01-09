Option Explicit On
Option Strict On
#Region "Option"
Imports Eniac.Entidades


#End Region
Partial Class Contabilidad

#Region "Compras"
   Friend Function RegistraContabilidadCompras(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Short,
                                               numeroComprobante As Long,
                                               idProveedor As Long) As Boolean
      Dim ent = New MovimientosStock(Me.da).GetUnoPorComprobante(idSucursal,
                                                                 idTipoComprobante,
                                                                 letra,
                                                                 centroEmisor,
                                                                 numeroComprobante,
                                                                 idProveedor)

      Dim idPlanCuenta As Integer = ent.Compra.TipoComprobante.IdPlanCuenta
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(Me.da)
      ent.tablaContabilidad = sql.GetRubroCompras(ent, idPlanCuenta)

      RegistraContabilidad(ent)
   End Function
   Friend Function RegistraContabilidad(omov As Entidades.MovimientoStock) As Boolean
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(Me.da)
      Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios

      Try
         Dim idUltimoAsiento As Integer = 0
         Dim idEjercicioVigente As Integer
         Dim idPeriodoActual As String

         Dim fechaContable As DateTime = omov.FechaMovimiento
         If omov.Compra.PeriodoFiscal <> 0 And Integer.Parse(fechaContable.ToString("yyyyMM")) <> omov.Compra.PeriodoFiscal Then
            Dim anio As Integer = Convert.ToInt32(Math.Truncate(omov.Compra.PeriodoFiscal / 100))
            Dim mes As Integer = omov.Compra.PeriodoFiscal - (anio * 100)
            fechaContable = New Date(anio, mes, 1)
         End If

         'obtengo el ejercicio vigente
         idEjercicioVigente = oEjercicio.GetEjercicioVigente(fechaContable)
         idPeriodoActual = oEjercicio.GetPeriodoActual(idEjercicioVigente, fechaContable)

         Dim idPlanCuenta As Integer = omov.Compra.TipoComprobante.IdPlanCuenta '' CInt(omov.tablaContabilidad.Rows(0)("idPlanCuenta"))
         Dim tipoProceso As String = Entidades.ContabilidadProceso.Procesos.COMPRAS.ToString()  ''omov.tablaContabilidad.Rows(0)("tipo").ToString
         Dim idSucursal As Integer

         If tipoProceso = Entidades.ContabilidadProceso.Procesos.AJUSTE.ToString() Then
            idSucursal = omov.Productos(0).IdSucursal
         Else ' compra
            idSucursal = omov.Compra.IdSucursal
         End If

         'obtengo el ultimo id del los asientos
         idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idEjercicioVigente, idPlanCuenta) + 1

         sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                   idPlanCuenta,
                                   idUltimoAsiento,
                                   fechaContable,
                                   ObtenerDescAsiento(omov.Compra),
                                   0,
                                   idSucursal,
                                   tipoProceso,
                                   idEjercicioDefinitivo:=Nothing,
                                   idPlanCuentaDefinitivo:=Nothing,
                                   idAsientoDefinitivo:=Nothing)

         sqlAsientos.Asiento_I_Detalle_TMP(idEjercicioVigente,
                                           idPlanCuenta,
                                           idUltimoAsiento,
                                           AgruparAsiento(ArmarDetalle(omov, idUltimoAsiento)))

         If tipoProceso <> Entidades.ContabilidadProceso.Procesos.AJUSTE.ToString() Then
            sql.MarcarRegistroProcesado(omov.Compra, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)

            sql.MarcarCtaCteRegistroProcesado(omov)
         End If

      Catch
         Throw
      End Try
      Return True

   End Function

   Public Sub MarcarCtaCteRegistroProcesado(ByVal omov As Entidades.MovimientoStock)
      Try
         Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
         sql.MarcarCtaCteRegistroProcesado(omov)
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try

   End Sub

   Friend Function ArmarDetalle(ByVal oMov As Entidades.MovimientoStock) As DataTable
      Return ArmarDetalle(oMov, 0)
   End Function

   Private Function ArmarDetalle(ByVal oMov As Entidades.MovimientoStock, ByVal idUltimoAsiento As Integer) As DataTable

      Dim dtDetalle As DataTable = CrearTablaDetalle()

      Dim cuentaCtaCteDebe As Eniac.Entidades.ContabilidadCuenta

      Dim valorDebe As Decimal = 0
      Dim valorHaber As Decimal = 0

      Try
         cuentaCtaCteDebe = New Reglas.ContabilidadCuentas(da)._GetUna(ContabilidadPublicos.ContabilidadCuentaCompras(da))
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas la Cuenta de Compras en Parámetros del Sistema."), ex)
      End Try


      'si el coeficiente del comprobante es positivo va al DEBE sino va al HABER
      Dim debe As Boolean = (oMov.Compra.TipoComprobante.CoeficienteValores = -1)
      Dim oCompra As Entidades.Compra = oMov.Compra


      'Reviso que el comprobante tenga CuponesTarjestaLiquidacion para el tipo de comprobante LIQUIDACIONTARJETA
      'defino el valor que va a usar
      Dim sumaCuponesTarjetasNOEnCartera As Decimal = 0

      For Each cpt In oCompra.CuponesTarjetasLiquidacion
         'sumo los que no estan en Cartera para descontarlos luego
         If cpt.IdEstadoTarjeta <> TarjetaCupon.Estados.ENCARTERA Then
            sumaCuponesTarjetasNOEnCartera += cpt.TarjetaCupon.Monto
         End If
      Next
      'le saco el signo si lo tuviera
      sumaCuponesTarjetasNOEnCartera = Math.Abs(sumaCuponesTarjetasNOEnCartera)


      If Not oCompra.TipoComprobante.UtilizaCtaSecundariaProd Then
         If oCompra.FormaPago.Dias <> 0 Then
            If oCompra.ImporteTotal <> 0 Then
               Dim cuenta As Entidades.ContabilidadCuenta
               Try
                  cuenta = oCompra.Proveedor.CuentaContable
                  If cuenta Is Nothing Then
                     cuenta = New Reglas.CategoriasProveedores(da).GetUno(oCompra.Proveedor.Categoria.IdCategoria).CuentaContable
                     If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                        cuenta = cuentaCtaCteDebe
                     End If
                  End If
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el proveedor {0} - {1} en el plan de cuenta {2}",
                                                                oCompra.Proveedor.IdProveedor, oCompra.Proveedor.NombreProveedor, oCompra.TipoComprobante.IdPlanCuenta), ex)
               End Try

               AgregarFila(dtDetalle,
                              ObtenerDescCuenta(cuenta),
                              Decimal.Parse(IIf(debe, Math.Abs(oCompra.ImporteTotal), 0).ToString()),
                              Decimal.Parse(IIf(Not debe, Math.Abs(oCompra.ImporteTotal), 0).ToString()),
                              idUltimoAsiento,
                              cuenta.IdCuenta,
                              "P", oCompra.Proveedor.IdProveedor.ToString())
            End If
         Else
            If oCompra.ImportePesos <> 0 Then
               Dim cuenta As Entidades.ContabilidadCuenta = Nothing
               Try
                  Try
                     'TODO: En Compras no se persiste el IdCaja usado.
                     'SPC: En Compras no se persiste el IdCaja usado.
                     Dim caja As Entidades.CajaNombre = New CajasNombres(da).GetUna(oCompra.IdSucursal, oCompra.IdCaja)
                     If caja.IdCuentaContable > 0 Then cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(caja.IdCuentaContable)
                  Catch ex As Exception
                     cuenta = Nothing
                  End Try
                  If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                     'cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(New CajasNombres(da).GetUna(oCompra.IdSucursal, oCompra.IdCaja).IdCuentaContable)
                     'If cuenta.IdCuenta = 0 Then
                     Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Pesos)
                     cuenta = medioPago.CuentaContable
                  End If
                  If cuenta Is Nothing OrElse cuenta.IdCuenta = 0 Then
                     Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                    oCompra.TipoComprobante.IdPlanCuenta))
                  End If
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Efectivo en el plan de cuenta {0}",
                                                                oCompra.TipoComprobante.IdPlanCuenta), ex)
               End Try
               Dim debeVuelto As Boolean = debe
               'SI EL SIGNO DE LA EFECTIVO ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
               If oCompra.TipoComprobante.CoeficienteValores > -1 AndAlso oCompra.ImportePesos < 0 Then
                  debeVuelto = Not debe
               End If



               AgregarFila(dtDetalle,
                              ObtenerDescCuenta(cuenta),
                              Decimal.Parse(IIf(debeVuelto, Math.Abs(oCompra.ImportePesos), 0).ToString()),
                              Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCompra.ImportePesos), 0).ToString()),
                              idUltimoAsiento,
                              cuenta.IdCuenta)
            End If

            If oCompra.ImporteChequesTerceros <> 0 Then
               Dim cuenta As Entidades.ContabilidadCuenta
               Try
                  Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Cheques)
                  cuenta = medioPago.CuentaContable
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques de Terceros en el plan de cuenta {0}",
                                                                oCompra.TipoComprobante.IdPlanCuenta), ex)
               End Try
               If cuenta Is Nothing Then
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques en el plan de cuenta {0}", oCompra.TipoComprobante.IdPlanCuenta))
               End If
               AgregarFila(dtDetalle,
                              ObtenerDescCuenta(cuenta),
                              Decimal.Parse(IIf(debe, Math.Abs(oCompra.ImporteChequesTerceros), 0).ToString()),
                              Decimal.Parse(IIf(Not debe, Math.Abs(oCompra.ImporteChequesTerceros), 0).ToString()),
                              idUltimoAsiento,
                              cuenta.IdCuenta)
            End If

            If oCompra.ImporteChequesPropios <> 0 Then
               For Each CP As Entidades.Cheque In oCompra.ChequesPropios
                  Dim cuenta As Entidades.ContabilidadCuenta
                  Try
                     cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(CP.CuentaBancaria.idCuentaContable)
                  Catch ex As Exception
                     Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} en el plan de cuenta {1}",
                                                                   CP.CuentaBancaria.NombreCuenta, oCompra.TipoComprobante.IdPlanCuenta), ex)
                  End Try
                  ''Try
                  ''   Dim medioPago As MedioDePago = New Reglas.MediosdePago(da).GetUna(MedioDePago.Ids.Cheques)
                  ''   cuenta = medioPago.CuentaContable
                  ''Catch ex As Exception
                  ''   Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe en Cheques de Terceros en el plan de cuenta {0}",
                  ''                                                 oVenta.TipoComprobante.IdPlanCuenta), ex)
                  ''End Try
                  AgregarFila(dtDetalle,
                                 ObtenerDescCuenta(cuenta),
                                 Decimal.Parse(IIf(debe, Math.Abs(CP.Importe), 0).ToString()),
                                 Decimal.Parse(IIf(Not debe, Math.Abs(CP.Importe), 0).ToString()),
                                 idUltimoAsiento,
                                 cuenta.IdCuenta)
               Next
            End If

            If oCompra.ImporteTarjetas <> 0 Then

               Dim cuenta As Entidades.ContabilidadCuenta
               Try
                  Dim medioPago As Entidades.MedioDePago = New Reglas.MediosdePago(da).GetUna(Entidades.MedioDePago.Ids.Tarjetas)
                  cuenta = medioPago.CuentaContable
                  If cuenta Is Nothing Then
                     Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe de Tarjeta en el plan de cuenta {0}",
                                                                   oCompra.TipoComprobante.IdPlanCuenta))
                  End If
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el importe de Tarjeta en el plan de cuenta {0}",
                                                                oCompra.TipoComprobante.IdPlanCuenta), ex)
               End Try

               AgregarFila(dtDetalle,
                              ObtenerDescCuenta(cuenta),
                              Decimal.Parse(IIf(debe, Math.Abs(oCompra.ImporteTarjetas), 0).ToString()),
                              Decimal.Parse(IIf(Not debe, Math.Abs(oCompra.ImporteTarjetas), 0).ToString()),
                              idUltimoAsiento,
                              cuenta.IdCuenta)
            End If


            If oCompra.ImporteTransfBancaria <> 0 Then
               Dim cuenta As Entidades.ContabilidadCuenta
               Try
                  cuenta = New Reglas.ContabilidadCuentas(da)._GetUna(oCompra.CuentaBancariaTransfBanc.idCuentaContable)
               Catch ex As Exception
                  Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la cuenta bancaria {0} en el plan de cuenta {1}",
                                                                oCompra.CuentaBancariaTransfBanc.NombreCuenta, oCompra.TipoComprobante.IdPlanCuenta), ex)
               End Try
               Dim debeVuelto As Boolean = debe
               'SI EL SIGNO DE LA TRANSFERENCIA ES AL REVES DEL SIGNO DEL TOTAL ES PORQUE ES UN VUELTO. ENTONCES LO DOY VUELTA.
               If (oCompra.TipoComprobante.CoeficienteValores > -1 AndAlso oCompra.ImporteTransfBancaria < 0) OrElse (oCompra.ImporteTransfBancaria < 0 AndAlso oCompra.TotalBruto > 0) OrElse (oCompra.ImporteTransfBancaria > 0 AndAlso oCompra.TotalBruto < 0) Then
                  debeVuelto = Not debe
               End If

               If oCompra.TipoComprobante.ClaseComprobante = TipoComprobante.ClasesComprobante.LIQUIDATARJETA Then
                  valorDebe = Decimal.Parse(IIf(debeVuelto, Math.Abs(oCompra.ImporteTransfBancaria) - sumaCuponesTarjetasNOEnCartera, 0).ToString())
                  valorHaber = Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCompra.ImporteTransfBancaria) - sumaCuponesTarjetasNOEnCartera, 0).ToString())
               Else
                  valorDebe = Decimal.Parse(IIf(debeVuelto, Math.Abs(oCompra.ImporteTransfBancaria), 0).ToString())
                  valorHaber = Decimal.Parse(IIf(Not debeVuelto, Math.Abs(oCompra.ImporteTransfBancaria), 0).ToString())
               End If


               AgregarFila(dtDetalle,
                              ObtenerDescCuenta(cuenta),
                              valorDebe,
                              valorHaber,
                              idUltimoAsiento,
                              cuenta.IdCuenta)
            End If
         End If
      End If         'If Not oCompra.TipoComprobante.UtilizaCtaSecundariaProd Then

      For Each CP As Entidades.CompraProducto In oMov.Compra.ComprasProductos.Where(Function(cp1) cp1.ImporteTotal <> 0)

         Dim pro As Entidades.Producto = New Reglas.Productos(da).GetUno(CP.Producto.IdProducto)

         Dim cuentaBruto As Entidades.ContabilidadCuenta
         If pro.CuentaCompras Is Nothing OrElse pro.CuentaCompras.IdCuenta <= 0 Then
            cuentaBruto = New Entidades.ContabilidadCuenta()
            Dim drCol As DataRow() = oMov.tablaContabilidad.Select("IdProducto = '" + CP.Producto.IdProducto + "'")
            If drCol.Length > 0 Then
               cuentaBruto.IdCuenta = Long.Parse(drCol(0)("IdCuenta").ToString())
               cuentaBruto.NombreCuenta = drCol(0)("NombreCuenta").ToString()
            Else
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el rubro del producto {0} en el plan de cuenta {1}",
                                                             CP.Producto.IdProducto, oCompra.TipoComprobante.IdPlanCuenta))
            End If
         Else
            cuentaBruto = pro.CuentaCompras
         End If
         Dim debeVuelto As Boolean = debe

         If oCompra.TipoComprobante.UtilizaCtaSecundariaProd Then
            debeVuelto = Not debeVuelto
            If pro.CuentaComprasSecundaria Is Nothing OrElse
               pro.CuentaComprasSecundaria.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("El comprobante {2} está configurado para usar Cta Cble Secundaria de Producto y el no están configuradas la cuenta secundaria del producto {0} en el plan de cuenta {1}",
                                                             pro.IdProducto, oCompra.TipoComprobante.IdPlanCuenta, oCompra.TipoComprobante.IdTipoComprobante))
            End If

            cuentaBruto = pro.CuentaComprasSecundaria
         Else
            'Si el comprobante es + y la línea es - doy vuelta la pata del asiento.
            'Si el comprobante es - y la línea es + doy vuelta la pata del asiento.
            'Si el comprobante es + y la línea es + dejo como está la pata del asiento.
            'Si el comprobante es - y la línea es - dejo como está la pata del asiento.
            If Not CP.ImporteTotal.MismoSigno(oCompra.ImporteTotal) Then
               debeVuelto = Not debeVuelto
            End If
         End If


         'es muy fea esta solución pero hay que agregar algo mas a los productos para que lo descuenta una sola vez las tarjetas
         If CP.TipoComprobante.ClaseComprobante = TipoComprobante.ClasesComprobante.LIQUIDATARJETA And CP.Producto.IdProducto = Publicos.ComprasProductoLiquidacionTarjetas Then
            valorDebe = Decimal.Parse(IIf(Not debeVuelto, Math.Abs(CP.ImporteTotalNeto) - sumaCuponesTarjetasNOEnCartera, 0).ToString())
            valorHaber = Decimal.Parse(IIf(debeVuelto, Math.Abs(CP.ImporteTotalNeto) - sumaCuponesTarjetasNOEnCartera, 0).ToString())

         Else
            valorDebe = Decimal.Parse(IIf(Not debeVuelto, Math.Abs(CP.ImporteTotalNeto), 0).ToString())
            valorHaber = Decimal.Parse(IIf(debeVuelto, Math.Abs(CP.ImporteTotalNeto), 0).ToString())
         End If

         'Lo comentamos porque no está permitiendo generar asientos contables para NC.
         'Queda pendiente probar otros casos a ver que sucede.
         'If CP.ImporteTotalNeto < 0 Then
         '   debeVuelto = Not debeVuelto
         'End If

         AgregarFila(dtDetalle,
                     ObtenerDescCuenta(cuentaBruto),
                     valorDebe,
                     valorHaber,
                     idUltimoAsiento,
                     cuentaBruto.IdCuenta,
                     CP.IdCentroCosto)
      Next

      If Not oCompra.TipoComprobante.UtilizaCtaSecundariaProd Then
         Dim impuestos As List(Of Entidades.CompraImpuesto) = oCompra.ComprasImpuestos ' New List(Of VentaImpuesto)()

         For Each VI As Entidades.CompraImpuesto In impuestos

            'si el importe es cero salgo porque no tiene sentido agregar una linea
            If VI.Importe = 0 Then
               Continue For
            End If

            'Un impuestos en una NC si el CoeficienteValores esta en Negativo lo doy vuelta como devolución
            If oCompra.TipoComprobante.CoeficienteValores = -1 And VI.Importe.MismoSigno(oCompra.ImporteTotal) Then
               debe = False
            Else
               debe = True
            End If


            Dim cuentaImpuesto As Entidades.ContabilidadCuenta
            Try
               Try
                  cuentaImpuesto = Nothing
                  If Not String.IsNullOrWhiteSpace(VI.IdProvincia) Then
                     Dim prov As Entidades.Provincia = New Reglas.Provincias(da).GetUno(VI.IdProvincia)
                     If prov IsNot Nothing AndAlso prov.CuentaCompras IsNot Nothing Then
                        cuentaImpuesto = prov.CuentaCompras
                     End If
                  End If
                  If cuentaImpuesto Is Nothing OrElse cuentaImpuesto.IdCuenta = 0 Then
                     cuentaImpuesto = New Reglas.Impuestos(da).GetUno(VI.IdTipoImpuesto.ToString(), VI.Alicuota).CuentaCompras
                  End If
               Catch ex As Exception
                  cuentaImpuesto = Nothing
               End Try
               If cuentaImpuesto Is Nothing OrElse cuentaImpuesto.IdCuenta = 0 Then
                  cuentaImpuesto = New Reglas.TiposImpuestos(da)._GetUno(VI.IdTipoImpuesto).CuentaCompras
               End If
            Catch ex As Exception
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                             VI.IdTipoImpuesto, oCompra.TipoComprobante.IdPlanCuenta), ex)
            End Try

            If cuentaImpuesto Is Nothing OrElse cuentaImpuesto.IdCuenta = 0 Then
               Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                             VI.IdTipoImpuesto, oCompra.TipoComprobante.IdPlanCuenta))
            End If

            AgregarFila(dtDetalle,
                        ObtenerDescCuenta(cuentaImpuesto),
                        Decimal.Parse(IIf(debe, Math.Abs(VI.Importe), 0).ToString()),
                        Decimal.Parse(IIf(Not debe, Math.Abs(VI.Importe), 0).ToString()),
                        idUltimoAsiento,
                        cuentaImpuesto.IdCuenta)
         Next
      End If         'If Not oCompra.TipoComprobante.UtilizaCtaSecundariaProd Then


      'AGREGO LAS RETENCIONES
      For Each cr As CompraRetencion In oCompra.Retenciones

         'si el importe es cero salgo porque no tiene sentido agregar una linea
         If cr.Retencion.ImporteTotal = 0 Then
            Continue For
         End If

         'Un impuestos en una NC si el CoeficienteValores esta en Negativo lo doy vuelta como devolución
         If oCompra.TipoComprobante.CoeficienteValores = -1 And cr.Retencion.ImporteTotal.MismoSigno(oCompra.ImporteTotal) Then
            debe = False
         Else
            debe = True
         End If

         Dim cuentaRetencion As Entidades.ContabilidadCuenta
         Try
            cuentaRetencion = New Reglas.TiposImpuestos(da).GetUno(cr.Retencion.IdTipoImpuesto).CuentaCompras
         Catch ex As Exception
            cuentaRetencion = Nothing
         End Try

         If cuentaRetencion Is Nothing OrElse cuentaRetencion.IdCuenta = 0 Then
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para el tipo de impuestos {0} en el plan de cuenta {1}",
                                                             cr.Retencion.IdTipoImpuesto.ToString(), oCompra.TipoComprobante.IdPlanCuenta))
         End If

         AgregarFila(dtDetalle,
                     ObtenerDescCuenta(cuentaRetencion),
                     Decimal.Parse(IIf(debe, Math.Abs(cr.Retencion.ImporteTotal), 0).ToString()),
                     Decimal.Parse(IIf(Not debe, Math.Abs(cr.Retencion.ImporteTotal), 0).ToString()),
                     idUltimoAsiento,
                     cuentaRetencion.IdCuenta)
      Next



      Return dtDetalle
   End Function

   Friend Function ObtenerDescAsiento(ByVal fila As Entidades.Compra) As String
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

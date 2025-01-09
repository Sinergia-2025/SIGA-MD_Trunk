#Region "Option"
Option Explicit On
Option Strict On
#End Region
Partial Class Contabilidad

#Region "Bancos"
   Friend Function RegistraContabilidad(ByVal eLibroBanco As Entidades.LibroBanco) As Boolean
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
      Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
      Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios(da)

      Try
         Dim idUltimoAsiento As Integer = 0

         Dim idEjercicioVigente As Integer
         Dim idPeriodoActual As String

         'obtengo el ejercicio vigente
         idEjercicioVigente = oEjercicio.GetEjercicioVigente(eLibroBanco.FechaMovimiento)
         idPeriodoActual = oEjercicio.GetPeriodoActual(idEjercicioVigente, eLibroBanco.FechaMovimiento)

         Dim idPlanCuenta As Integer = sql.GetPlanCtaXCtaBan(eLibroBanco.IdCuentaBancaria)
         Dim tipoproceso As String = Entidades.ContabilidadProceso.Procesos.MOVBANCO.ToString()

         If Not (oEjercicio.EstaPeriodoCerrado(idEjercicioVigente, idPeriodoActual)) Then
            idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idEjercicioVigente, idPlanCuenta) + 1

            'tipoproceso = Entidades.ContabilidadProceso.Procesos.MOVCAJA.ToString()

            'obtengo el ultimo id del los asientos
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuenta,
                                      idUltimoAsiento,
                                      eLibroBanco.FechaMovimiento,
                                      ObtenerDescAsiento(eLibroBanco),
                                      0,
                                      eLibroBanco.IdSucursal,
                                      tipoproceso,
                                      idEjercicioDefinitivo:=Nothing,
                                      idPlanCuentaDefinitivo:=Nothing,
                                      idAsientoDefinitivo:=Nothing)

            sqlAsientos.Asiento_I_Detalle_TMP(idEjercicioVigente,
                                              idPlanCuenta,
                                              idUltimoAsiento,
                                              AgruparAsiento(ArmarDetalle(eLibroBanco, idUltimoAsiento, idPlanCuenta)))


            sql.MarcarRegistroProcesado(eLibroBanco, idEjercicioVigente, idPlanCuenta, idUltimoAsiento)
         Else
            Throw New Exception("El periodo contable se encuentra cerrado.")
         End If
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
      Return True
   End Function

   Friend Function RegenerarDetalleContabilidad(eLibroBanco As Entidades.LibroBanco) As Boolean
      Try
         Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         If eLibroBanco.IdEjercicio.HasValue And eLibroBanco.IdPlanCuenta.HasValue And eLibroBanco.IdAsiento.HasValue Then
            Dim idEjercicio As Integer = eLibroBanco.IdEjercicio.Value
            Dim idPlan As Integer = eLibroBanco.IdPlanCuenta.Value
            Dim idAsiento As Integer = eLibroBanco.IdAsiento.Value

            sqlAsientos.Asiento_D_Detalle_Tmp(idEjercicio, idPlan, idAsiento)
            sqlAsientos.Asiento_I_Detalle_TMP(idEjercicio, idPlan,
                                              idAsiento,
                                              AgruparAsiento(ArmarDetalle(eLibroBanco, idAsiento, idPlan)))
         End If
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
   End Function

   Friend Function EliminarAsientoContabilidad(eLibroBanco As Entidades.LibroBanco) As Boolean
      Try
         Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         If eLibroBanco.IdEjercicio.HasValue And eLibroBanco.IdPlanCuenta.HasValue And eLibroBanco.IdAsiento.HasValue Then
            Dim idEjercicio As Integer = eLibroBanco.IdEjercicio.Value
            Dim idPlan As Integer = eLibroBanco.IdPlanCuenta.Value
            Dim idAsiento As Integer = eLibroBanco.IdAsiento.Value

            sqlAsientos.Asiento_D_Detalle_Tmp(idEjercicio, idPlan, idAsiento)
            sqlAsientos.Asiento_D_Tmp(idEjercicio, idPlan, idAsiento)
         End If
      Catch ex As Exception
         Throw New ContabilidadException(ex)
      End Try
   End Function

   Private Function ArmarDetalle(ByVal eLibroBanco As Entidades.LibroBanco,
                                 ByVal idUltimoAsiento As Integer,
                                 ByVal idPlan As Integer) As DataTable
      Dim tipomovimiento As String = eLibroBanco.IdTipoMovimiento

      Dim dtDetalle As DataTable = CrearTablaDetalle()
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(Me.da)

      Dim debe As Boolean = (eLibroBanco.IdTipoMovimiento = "I")

      Dim cuentaBanco As Entidades.CuentaBanco = New Reglas.CuentasBancos(da).GetUna(eLibroBanco.IdCuentaBanco)
      Dim ctaCtbCtaBanco As Entidades.ContabilidadCuenta
      Try
         ctaCtbCtaBanco = New Reglas.ContabilidadCuentas(da)._GetUna(cuentaBanco.IdCuentaContable)
         If ctaCtbCtaBanco Is Nothing Then
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Cuenta de Banco {0} - {1} en el plan de cuenta {2}",
                                                          cuentaBanco.IdCuentaBanco, cuentaBanco.NombreCuentaBanco, idPlan))
         End If
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Cuenta de Banco {0} - {1} en el plan de cuenta {2}",
                                                       cuentaBanco.IdCuentaBanco, cuentaBanco.NombreCuentaBanco, idPlan), ex)
      End Try

      Dim cuentaBancaria As Entidades.CuentaBancaria = New Reglas.CuentasBancarias(da).GetUna(eLibroBanco.IdCuentaBancaria)
      Dim ctaCtbBco As Entidades.ContabilidadCuenta
      Try
         ctaCtbBco = New Reglas.ContabilidadCuentas(da)._GetUna(cuentaBancaria.idCuentaContable)
         If ctaCtbBco Is Nothing Then
            Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Cuenta Bancaria {0} - {1} en el plan de cuenta {2}",
                                                          cuentaBancaria.IdCuentaBancaria, cuentaBancaria.NombreCuenta, idPlan))
         End If
      Catch ex As Exception
         Throw New ContabilidadException(String.Format("No están configuradas las cuentas para la Cuenta Bancaria {0} - {1} en el plan de cuenta {2}",
                                                       cuentaBancaria.IdCuentaBancaria, cuentaBancaria.NombreCuenta, idPlan))
      End Try

      AgregarFila(dtDetalle,
                     ObtenerDescCuenta(ctaCtbCtaBanco),
                     Decimal.Parse(IIf(Not debe, Math.Abs(eLibroBanco.Importe), 0).ToString()),
                     Decimal.Parse(IIf(debe, Math.Abs(eLibroBanco.Importe), 0).ToString()),
                     idUltimoAsiento,
                     ctaCtbCtaBanco.IdCuenta,
                     eLibroBanco.IdCentroCosto)

      AgregarFila(dtDetalle,
                     ObtenerDescCuenta(ctaCtbBco),
                     Decimal.Parse(IIf(debe, Math.Abs(eLibroBanco.Importe), 0).ToString()),
                     Decimal.Parse(IIf(Not debe, Math.Abs(eLibroBanco.Importe), 0).ToString()),
                     idUltimoAsiento,
                     ctaCtbBco.IdCuenta)

      Return dtDetalle

   End Function

   Friend Function ObtenerDescAsiento(ByRef fila As Entidades.LibroBanco) As String
      ' [IdSucursal],[DescCuentaBancaria],[NumeroMovimiento],[NombreCuentaBanco]
      Return String.Format("{0}-{1} {2:00000000} - {3}",
                           fila.IdSucursal,
                           fila.DescCuentaBancaria,
                           fila.NumeroMovimiento,
                           fila.NombreCuentaBanco).Truncar(100)
   End Function

#End Region

End Class
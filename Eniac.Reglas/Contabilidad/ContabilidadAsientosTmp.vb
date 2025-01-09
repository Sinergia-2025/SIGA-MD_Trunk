#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class ContabilidadAsientosTmp
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadAsientosTmp"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region



   Private Sub CargarUna_Tmp(ByVal o As Entidades.ContabilidadAsientoTmp, ByVal dr As DataRow, ByVal dtDetalle As DataTable)
      With o
         .IdEjercicio = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdEjercicio.ToString()).ToString())
         .IdPlanCuenta = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdPlanCuenta.ToString()).ToString())
         .IdAsiento = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdAsiento.ToString()).ToString())
         .FechaAsiento = Date.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.FechaAsiento.ToString()).ToString())
         .NombreAsiento = dr(Entidades.ContabilidadAsientoTmp.Columnas.NombreAsiento.ToString()).ToString()
         .IdTipoDoc = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdTipoDoc.ToString()).ToString())
         .IdSucursal = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.idSucursal.ToString()).ToString())
         .SubsiAsiento = dr(Entidades.ContabilidadAsientoTmp.Columnas.SubsiAsiento.ToString()).ToString()
         If IsNumeric(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdEjercicioDefinitivo.ToString())) Then
            .IdEjercicioDefinitivo = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdEjercicioDefinitivo.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdPlanCuentaDefinitivo.ToString())) Then
            .IdPlanCuentaDefinitivo = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdPlanCuentaDefinitivo.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdAsientoDefinitivo.ToString())) Then
            .IdAsientoDefinitivo = Integer.Parse(dr(Entidades.ContabilidadAsientoTmp.Columnas.IdAsientoDefinitivo.ToString()).ToString())
         End If
      End With
   End Sub

   Public Function GetTodos_Tmp() As List(Of Entidades.ContabilidadAsientoTmp)
      ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUna_Tmp(o, dr, dtDetalle:=Nothing), Function() New Entidades.ContabilidadAsientoTmp())
   End Function

   Public Function GetUna_Tmp(idEjercicio As Integer, idPlan As Integer, idAsiento As Integer) As Entidades.ContabilidadAsientoTmp
      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      Return CargaEntidad(sql.Asientos_G1_Tmp(idEjercicio, idPlan, idAsiento),
                          Sub(o, dr) CargarUna_Tmp(o, dr, sql.Asiento_GetDetalle_Tmp(idEjercicio, idPlan, idAsiento)),
                          Function() New Entidades.ContabilidadAsientoTmp(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el asiento temporal con Ejercicio {0}, Plan {1} y Asiento {2}",
                                                                                          idEjercicio, idPlan, idAsiento))
   End Function

   Public Function Get1_Tmp(idEjercicio As Integer, idPlan As Integer, idAsiento As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      Return sql.Asientos_G1_Tmp(idEjercicio, idPlan, idAsiento)
   End Function

   Public Function GetPorIdASiento_Tmp(idPlanCuenta As Integer, idAsiento As Integer) As DataTable
      Dim idAsientoNull As Integer? = Nothing
      If idAsiento > 0 Then
         idAsientoNull = idAsiento
      End If
      Return New SqlServer.ContabilidadAsientosTmp(Me.da).Asientos_GA(idEjercicio:=Nothing, idPlanCuenta:=idPlanCuenta, idAsiento:=idAsientoNull)
   End Function

   Public Function GetPorNombre_Tmp(dscAsiento As String) As DataTable
      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      Return sql.GetPorNombre_Tmp(dscAsiento)
   End Function
   Public Sub MarcarContabilidadDefinitiva(idEjercicio As Integer,
                                           idPlanCuenta As Integer,
                                           idAsiento As Integer,
                                           idEjercicioDefinitivo As Integer,
                                           idPlanCuentaDefinitivo As Integer,
                                           idAsientoDefinitivo As Integer)
      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      sql.MarcarContabilidadDefinitiva(idEjercicio, idPlanCuenta, idAsiento, idEjercicioDefinitivo, idPlanCuentaDefinitivo, idAsientoDefinitivo)
   End Sub

   Public Sub DesmarcarDefinitivo(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)

      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      sql.MarcarContabilidadDefinitiva(idEjercicio, idPlanCuenta, idAsiento, idEjercicioDefinitivo:=Nothing, idPlanCuentaDefinitivo:=Nothing, idAsientoDefinitivo:=Nothing)
   End Sub


   Public Function GetIdMaximo_Tmp(idEjercicio As Integer, idPlan As Integer) As Integer

      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      Return sql.Asiento_GetIdMaximo_Tmp(idEjercicio, idPlan)
   End Function

   Public Function ComprobarExistenciaAsientos_Tmp(ByVal FechaInicial As DateTime, ByVal FechaFinal As DateTime) As Boolean
      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      Dim resultado As DataTable = sql.ComprobarExistenciaAsientos_Tmp(FechaInicial, FechaFinal)
      If CInt(resultado.Rows(0).Item("ExisteUno")) = 1 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Sub VincularMovimientoAsientoManual(modulo As Entidades.ContabilidadProceso.Procesos, dr As DataRow, idEjercicioDefinitivo As Integer, idPlanCuentaDefinitivo As Integer, idAsientoDefinitivo As Integer)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
         Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios(da)
         Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         'Dim idUltimoAsiento As Integer = sqlAsientos.Asiento_GetIdMaximo_Tmp(idPlanCuenta) + 1

         If modulo = Entidades.ContabilidadProceso.Procesos.VENTAS Then
            Dim ent As Entidades.Venta = New Reglas.Ventas(da).GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                                                      dr("IdTipoComprobante").ToString(),
                                                                      dr("Letra").ToString(),
                                                                      Int16.Parse(dr("CentroEmisor").ToString()),
                                                                      Int64.Parse(dr("NumeroComprobante").ToString()))
            Dim idEjercicioVigente As Integer = oEjercicio.GetEjercicioVigente(ent.Fecha)
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuentaDefinitivo,
                                      idAsientoDefinitivo,
                                      ent.Fecha,
                                      "Asiento vinculacion con movimiento manual",
                                      0,
                                      ent.IdSucursal,
                                      modulo.ToString(),
                                      idEjercicioDefinitivo, idPlanCuentaDefinitivo, idAsientoDefinitivo)

            sql.MarcarRegistroProcesado(ent, idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)
            sql.MarcarCtaCteRegistroProcesado(ent)

         ElseIf modulo = Entidades.ContabilidadProceso.Procesos.CuentaCte Then
            Dim ent As Entidades.CuentaCorriente
            ent = New Reglas.CuentasCorrientes(Me.da)._GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                                              dr("IdTipoComprobante").ToString(),
                                                              dr("Letra").ToString(),
                                                              Int32.Parse(dr("CentroEmisor").ToString()),
                                                              Int64.Parse(dr("NumeroComprobante").ToString()))

            Dim idEjercicioVigente As Integer = oEjercicio.GetEjercicioVigente(ent.Fecha)
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuentaDefinitivo,
                                      idAsientoDefinitivo,
                                      ent.Fecha,
                                      "Asiento vinculacion con movimiento manual",
                                      0,
                                      ent.IdSucursal,
                                      modulo.ToString(),
                                      idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

            sql.MarcarRegistroProcesado(ent, idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

         ElseIf modulo = Entidades.ContabilidadProceso.Procesos.COMPRAS Then
            Dim ent = New Reglas.MovimientosStock(Me.da).GetUnoPorComprobante(Int32.Parse(dr("IdSucursal").ToString()),
                                                                              dr("IdTipoComprobante").ToString(),
                                                                              dr("Letra").ToString(),
                                                                              Int16.Parse(dr("CentroEmisor").ToString()),
                                                                              Int64.Parse(dr("NumeroComprobante").ToString()),
                                                                              Int64.Parse(dr("IdProveedor").ToString()))

            Dim fechaContable As DateTime = ent.FechaMovimiento
            If ent.Compra.PeriodoFiscal <> 0 And Integer.Parse(fechaContable.ToString("yyyyMM")) <> ent.Compra.PeriodoFiscal Then
               Dim anio As Integer = Convert.ToInt32(Math.Truncate(ent.Compra.PeriodoFiscal / 100))
               Dim mes As Integer = ent.Compra.PeriodoFiscal - (anio * 100)
               fechaContable = New Date(anio, mes, 1)
            End If

            Dim idEjercicioVigente As Integer = oEjercicio.GetEjercicioVigente(fechaContable)
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuentaDefinitivo,
                                      idAsientoDefinitivo,
                                      fechaContable,
                                      "Asiento vinculacion con movimiento manual",
                                      0,
                                      ent.IdSucursal,
                                      modulo.ToString(),
                                      idEjercicioDefinitivo, idPlanCuentaDefinitivo, idAsientoDefinitivo)

            sql.MarcarRegistroProcesado(ent.Compra, idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)
            sql.MarcarCtaCteRegistroProcesado(ent)

         ElseIf modulo = Entidades.ContabilidadProceso.Procesos.PagoProv Then
            Dim ent As Entidades.CuentaCorrienteProv
            ent = New Reglas.CuentasCorrientesProv(Me.da).GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                                                 Int64.Parse(dr("IdProveedor").ToString()),
                                                                 dr("IdTipoComprobante").ToString(),
                                                                 dr("Letra").ToString(),
                                                                 Int32.Parse(dr("CentroEmisor").ToString()),
                                                                 Int64.Parse(dr("NumeroComprobante").ToString()))

            Dim idEjercicioVigente As Integer = oEjercicio.GetEjercicioVigente(ent.Fecha)
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuentaDefinitivo,
                                      idAsientoDefinitivo,
                                      ent.Fecha,
                                      "Asiento vinculacion con movimiento manual",
                                      0,
                                      ent.IdSucursal,
                                      modulo.ToString(),
                                      idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

            sql.MarcarRegistroProcesado(ent, idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

         ElseIf modulo = Entidades.ContabilidadProceso.Procesos.MOVCAJA Then
            Dim ent As Entidades.CajaDetalles
            ent = New Reglas.CajaDetalles(Me.da)._GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                                         Int32.Parse(dr("IdCaja").ToString()),
                                                         Int32.Parse(dr("NumeroPlanilla").ToString()),
                                                         Int32.Parse(dr("NumeroMovimiento").ToString()))

            Dim idEjercicioVigente As Integer = oEjercicio.GetEjercicioVigente(ent.FechaMovimiento)
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuentaDefinitivo,
                                      idAsientoDefinitivo,
                                      ent.FechaMovimiento,
                                      "Asiento vinculacion con movimiento manual",
                                      0,
                                      ent.IdSucursal,
                                      modulo.ToString(),
                                      idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

            sql.MarcarRegistroProcesado(ent, idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

         ElseIf modulo = Entidades.ContabilidadProceso.Procesos.MOVBANCO Then
            Dim ent As Entidades.LibroBanco
            ent = New Reglas.LibroBancos(Me.da).GetUno(Int32.Parse(dr("IdSucursal").ToString()),
                                                       Int32.Parse(dr("IdCuentaBancaria").ToString()),
                                                       Int32.Parse(dr("NumeroMovimiento").ToString()))

            Dim idEjercicioVigente As Integer = oEjercicio.GetEjercicioVigente(ent.FechaMovimiento)
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuentaDefinitivo,
                                      idAsientoDefinitivo,
                                      ent.FechaMovimiento,
                                      "Asiento vinculacion con movimiento manual",
                                      0,
                                      ent.IdSucursal,
                                      modulo.ToString(),
                                      0, idPlanCuentaDefinitivo, idAsientoDefinitivo)

            sql.MarcarRegistroProcesado(ent, idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

         ElseIf modulo = Entidades.ContabilidadProceso.Procesos.MANUALES Then
            Dim ent As Entidades.Deposito
            ent = New Reglas.Depositos(Me.da).GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                                     Long.Parse(dr("NumeroDeposito").ToString()), dr("IdTipoComprobante").ToString())

            Dim idEjercicioVigente As Integer = oEjercicio.GetEjercicioVigente(ent.Fecha)
            sqlAsientos.Asiento_I_TMP(idEjercicioVigente,
                                      idPlanCuentaDefinitivo,
                                      idAsientoDefinitivo,
                                      ent.Fecha,
                                      "Asiento vinculacion con movimiento manual",
                                      0,
                                      ent.IdSucursal,
                                      modulo.ToString(),
                                      idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

            sql.MarcarRegistroProcesado(ent, idEjercicioVigente, idPlanCuentaDefinitivo, idAsientoDefinitivo)

         End If

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)
      Return sql.Buscar_tmp(entidad.Columna, entidad.Valor.ToString())
   End Function



#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.ContabilidadAsientoTmp = DirectCast(entidad, Entidades.ContabilidadAsientoTmp)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(Me.da)

         Select Case tipo

            Case TipoSP._I

               sql.Asiento_I_TMP(en.IdEjercicio,
                                 en.IdPlanCuenta,
                                 en.IdAsiento,
                                 en.FechaAsiento,
                                 en.NombreAsiento,
                                 en.IdTipoDoc,
                                 en.IdSucursal,
                                 en.SubsiAsiento,
                                 en.IdEjercicioDefinitivo,
                                 en.IdPlanCuentaDefinitivo,
                                 en.IdAsientoDefinitivo)

               sql.Asiento_I_Detalle_TMP(en.IdEjercicio,
                                         en.IdPlanCuenta,
                                         en.IdAsiento,
                                         en.DetallesAsiento)


            Case TipoSP._U
               sql.Asiento_U_Tmp(en.IdEjercicio,
                                 en.IdPlanCuenta,
                                 en.IdAsiento,
                                 en.FechaAsiento,
                                 en.NombreAsiento,
                                 en.IdTipoDoc,
                                 en.IdSucursal,
                                 en.SubsiAsiento,
                                 en.IdEjercicioDefinitivo,
                                 en.IdPlanCuentaDefinitivo,
                                 en.IdAsientoDefinitivo)

               sql.Asiento_U_Detalle_Tmp(en.IdEjercicio,
                                         en.IdPlanCuenta,
                                         en.IdAsiento,
                                         en.DetallesAsiento)


            Case TipoSP._D
               sql.Asiento_D_Detalle_Tmp(en.IdEjercicio, en.IdPlanCuenta, en.IdAsiento)
               sql.Asiento_D_Tmp(en.IdEjercicio, en.IdPlanCuenta, en.IdAsiento)
         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

End Class

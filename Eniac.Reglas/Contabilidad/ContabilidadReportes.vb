Public Class ContabilidadReportes
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("ContabilidadReportes", accesoDatos)
   End Sub
#End Region

   Public Function Asiento_GetDetalle(idSucursales As Integer(), idPlan As Integer, idAsiento As Integer, idCentroCosto As Integer?,
                                      fechaDesde As Date?, fechaHasta As Date?,
                                      tipoRegistro As Entidades.ContabilidadReporte.TipoRegistro,
                                      exportados As Entidades.Publicos.SiNoTodos) As Entidades.ContabilidadReporte
      Dim sql = New SqlServer.ContabilidadReportes(da)
      Dim dtDetalle = sql.Asiento_GetDetalle(idSucursales, idPlan, idAsiento, idCentroCosto, fechaDesde, fechaHasta, tipoRegistro, exportados)
      Return New Entidades.ContabilidadReporte() With {.detallesAsiento = dtDetalle}
   End Function

   Public Function LibroMayor(fdesde As Date?,
                              fhasta As Date?,
                              codCuenta As Integer?,
                              codCuentaHasta As Integer?,
                              idPlan As Integer?,
                              idSucursales As Integer(),
                              tipoReferencia As String,
                              referencia As String,
                              mostrarComprobanteOrigen As Boolean,
                              saldoInicial As Boolean,
                              idCentroCosto As Integer?,
                              mostrarCentroCosto As Boolean) As Entidades.ContabilidadReporte

      Dim rEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios(da)
      rEjercicio.CompletaFechasSegunEjercicio(fdesde, fhasta)
      'rEjercicio.FechasMismoEfercicio(fdesde.Value, fhasta.Value)

      Dim sql As SqlServer.ContabilidadReportes = New SqlServer.ContabilidadReportes(da)
      Dim dtLibro As DataTable = sql.LibroMayor(fdesde, fhasta, codCuenta, codCuentaHasta, idPlan, idSucursales, tipoReferencia, referencia, mostrarComprobanteOrigen, saldoInicial, idCentroCosto, mostrarCentroCosto)
      Dim o As Entidades.ContabilidadReporte = New Entidades.ContabilidadReporte

      o.libroMayor = dtLibro
      If dtLibro.Rows.Count > 0 Then
         'Else
         '    Throw New Exception("No existe el libro")
      End If

      Dim saldo As Decimal = 0
      For Each dr As DataRow In o.libroMayor.Rows
         Dim debe As Decimal = 0
         Dim haber As Decimal = 0
         If Not IsDBNull(dr("debe")) Then
            debe = Convert.ToDecimal(dr("debe"))
         End If
         If Not IsDBNull(dr("haber")) Then
            haber = Convert.ToDecimal(dr("haber"))
         End If
         saldo = saldo + debe - haber
         dr("saldo") = saldo
      Next

      Return o

   End Function

   'Public Function balance(fHasta As Date _
   '                        , idPlan As Integer _
   '                        , idSucursales As Integer()) As Entidades.ContabilidadReporte

   '   Dim sql As SqlServer.ContabilidadReportes = New SqlServer.ContabilidadReportes(da)
   '   Dim sqlEj As SqlServer.ContabilidadEjercicios = New SqlServer.ContabilidadEjercicios(da)
   '   Dim MesDia As String = String.Empty

   '   Dim dtBalance As DataTable = sql.Balance(fHasta, idPlan, idSucursales)
   '   MesDia = sqlEj.GetPrimerMesPeriodo(fHasta)
   '   Dim dtBalanceNivel4 As DataTable = sql.BlanceNivel4(fHasta, idPlan, MesDia, idSucursales)
   '   MesDia = sqlEj.GetUltimoMesPeriodoAnterior(fHasta)
   '   Dim dtBalanceAnterior As DataTable = sql.BalanceN4Anterior(fHasta, idPlan, MesDia, idSucursales)

   '   dtBalance.Merge(dtBalanceNivel4)

   '   Dim o As Entidades.ContabilidadReporte = New Entidades.ContabilidadReporte

   '   o.Balance = dtBalance

   '   If dtBalance.Rows.Count > 0 Then
   '      Dim fila As DataRow
   '      fila = dtBalance.NewRow
   '      If idPlan <> -1 Then
   '         fila("IdPlanCuenta") = idPlan
   '         fila("NombrePlanCuenta") = dtBalance.Rows(0)("NombrePlanCuenta")
   '      End If
   '      fila("IdCuenta") = "30204001"
   '      fila("NombreCuenta") = "Resultados De Ejercicios Anteriores"
   '      fila("saldoCuenta") = CDec(dtBalanceAnterior.Rows(0)(0))
   '      dtBalance.Rows.Add(fila)
   '   End If

   '   If dtBalanceNivel4.Rows.Count > 0 Then
   '      o.BalanceN4 = dtBalanceNivel4
   '   End If
   '   If dtBalanceAnterior.Rows.Count > 0 Then
   '      o.SaldoAnterior = CDec(dtBalanceAnterior.Rows(0)(0))
   '   End If

   '   Return o

   'End Function


   Public Function balanceNuevo(fDesde As Date?,
                                fHasta As Date,
                                idPlan As Integer?,
                                idSucursales As Integer(),
                                incluirCuentasSinMovimientos As Boolean) As Entidades.ContabilidadReporte

      Dim sql As SqlServer.ContabilidadReportes = New SqlServer.ContabilidadReportes(da)
      'Dim sqlEj As SqlServer.ContabilidadEjercicios = New SqlServer.ContabilidadEjercicios(da)
      'Dim MesDiaPrimer As String = String.Empty
      'Dim MesDiaUltimo As String = String.Empty

      Dim fechaDesde As Date? = fDesde
      Dim fechaHasta As Date? = fHasta
      Dim rEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios(da)
      rEjercicio.CompletaFechasSegunEjercicio(fechaDesde, fechaHasta)
      rEjercicio.FechasMismoEfercicio(fechaDesde.Value, fechaHasta.Value)



      '' Dim dtBalance As DataTable = sql.Balance(fHasta, idPlan, idSucursales)
      'MesDiaPrimer = sqlEj.GetPrimerMesPeriodo(fHasta)
      '' Dim dtBalanceNivel4 As DataTable = sql.BlanceNivel4(fHasta, idPlan, MesDia, idSucursales)
      'MesDiaUltimo = sqlEj.GetUltimoMesPeriodoAnterior(fHasta)

      Dim o As Entidades.ContabilidadReporte = New Entidades.ContabilidadReporte
      o.Balance = sql.BalanceNuevo(fechaDesde.Value, fechaHasta.Value, idPlan, idSucursales, incluirCuentasSinMovimientos)  ''MesDiaPrimer, MesDiaUltimo, 

      Return o
   End Function

   Public Function BalanceSumaSaldoPorPeriodo(idSucursales As IEnumerable(Of Integer), fDesde As Date?, fHasta As Date?,
                                              idPlan As Integer?, incluirCuentasSinMovimientos As Boolean) As DataTable
      'Dim fDesde As Date? = fechaDesde
      'Dim fHasta As Date? = fechaHasta
      Dim rEjercicio = New ContabilidadEjercicios(da)
      rEjercicio.CompletaFechasSegunEjercicio(fDesde, fHasta)
      rEjercicio.FechasMismoEfercicio(fDesde.Value, fHasta.Value)

      Dim idEjercicio = rEjercicio.GetEjercicioVigente(fHasta.Value)
      Dim ejercicio = rEjercicio.GetUna(idEjercicio)
      Dim periodos = ejercicio.DetallesPeriodos.AsEnumerable().ToList().ConvertAll(Function(dr) dr.Field(Of String)("IdPeriodo"))

      Dim sql = New SqlServer.ContabilidadReportes(da)
      Return sql.BalanceSumaSaldoPorPeriodo(idSucursales, fDesde.Value, fHasta.Value, idPlan, incluirCuentasSinMovimientos, idEjercicio, periodos)
   End Function




   Public Function LibroDiario(fDesde As Date?, fHasta As Date?, idPlan As Integer, Sucursales As Integer()) As Entidades.ContabilidadReporte

      Dim sql As SqlServer.ContabilidadReportes = New SqlServer.ContabilidadReportes(da)
      Dim sqlEj As SqlServer.ContabilidadEjercicios = New SqlServer.ContabilidadEjercicios(da)
      Dim oAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos(da)
      Dim MesDia As String = String.Empty

      Dim rEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios(da)
      rEjercicio.CompletaFechasSegunEjercicio(fDesde, fHasta)
      rEjercicio.FechasMismoEfercicio(fDesde.Value, fHasta.Value)

      Dim o As Entidades.ContabilidadReporte = New Entidades.ContabilidadReporte
      o.LibroDiario = sql.LibroDiario(fDesde, fHasta, idPlan, Sucursales)

      Return o

      'Dim dtLibroDiario As DataTable = sql.LibroDiario(fhasta, idPlan, Sucursales)
      'MesDia = sqlEj.GetUltimoMesPeriodoAnterior(fhasta)

      'Dim dtLibroDiarioRefundicion As DataTable = sql.LibroDiarioRefundicion(fhasta, idPlan, Sucursales, MesDia)

      ''MesDia = sqlEj.GetPrimerMesPeriodo(fhasta)
      ''Dim dtBalanceNivel4 As DataTable = sql.BlanceNivel4(fhasta, idPlan, MesDia, idSucursales)
      ''MesDia = sqlEj.GetUltimoMesPeriodoAnterior(fhasta)

      ''Dim dtBalanceAnterior As DataTable = sql.BalanceN4Anterior(fhasta, idPlan, MesDia, idSucursales)

      'Dim o As Entidades.ContabilidadReporte = New Entidades.ContabilidadReporte

      'o.LibroDiario = dtLibroDiario

      'If dtLibroDiario.Rows.Count > 0 Then

      '   'obtengo el ultimo id del los asientos
      '   Dim idUltimoAsiento As Integer = oAsientos.GetIdMaximo(idPlan) + 1

      '   Dim saldoDeudor As Decimal = 0
      '   Dim saldoAcreedor As Decimal = 0

      '   For Each filaRefundicion As DataRow In dtLibroDiarioRefundicion.Rows
      '      Dim fila As DataRow
      '      fila = dtLibroDiario.NewRow

      '      fila("idAsiento") = idUltimoAsiento
      '      ' se invierten----
      '      fila("Debe") = filaRefundicion("Haber")
      '      fila("Haber") = filaRefundicion("Debe")
      '      saldoDeudor += CDec(filaRefundicion("Debe"))
      '      saldoAcreedor += CDec(filaRefundicion("Haber"))

      '      fila("IdCuenta") = filaRefundicion("idcuenta")
      '      fila("NombreCuenta") = filaRefundicion("nombrecuenta")
      '      fila("fechaAsiento") = filaRefundicion("fechaAsiento")
      '      fila("nombreAsiento") = "Refundición de Resultados del Ejercicio"

      '      dtLibroDiario.Rows.Add(fila)
      '   Next

      '   Dim filaFin As DataRow
      '   filaFin = dtLibroDiario.NewRow
      '   filaFin("idAsiento") = idUltimoAsiento

      '   If saldoAcreedor - saldoDeudor < 0 Then
      '      filaFin("Debe") = saldoAcreedor - saldoDeudor
      '      filaFin("Haber") = 0
      '   Else
      '      filaFin("Debe") = 0
      '      filaFin("Haber") = saldoAcreedor - saldoDeudor
      '   End If

      '   filaFin("IdCuenta") = "30204001"
      '   filaFin("NombreCuenta") = "Resultados De Ejercicios Anteriores"

      '   '  filaFin("fechaAsiento") = filaRefundicion("fechaAsiento")
      '   filaFin("nombreAsiento") = "Refundición de Resultados del Ejercicio"

      '   dtLibroDiario.Rows.Add(filaFin)
      'End If

   End Function

   Public Function BalanceGeneral(fHasta As Date,
                                  idPlan As Integer?,
                                  idSucursales As Integer()) As Entidades.ContabilidadReporte

      Dim sql As SqlServer.ContabilidadReportes = New SqlServer.ContabilidadReportes(da)
      Dim fechaDesde As Date?
      Dim fechaHasta As Date? = fHasta
      Dim rEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios(da)
      rEjercicio.CompletaFechasSegunEjercicio(fechaDesde, fechaHasta)
      rEjercicio.FechasMismoEfercicio(fechaDesde.Value, fechaHasta.Value)

      Dim cuentas As DataTable = New ContabilidadCuentas(da).GetArbol(0)
      Dim dtSumaSaldo As DataTable = New SqlServer.ContabilidadReportes(da).BalanceNuevo(fechaDesde.Value, fechaHasta.Value, idPlan, idSucursales, False)
      Dim dtResultado As DataTable = dtSumaSaldo.Clone()

      dtResultado.Columns.Add("rn", GetType(String))

      For i As Integer = 0 To dtSumaSaldo.Rows.Count - 1
         'Para cada row del DataTable de Suma y Saldo (dtSumaSaldo)
         Dim drSumaSaldo As DataRow = dtSumaSaldo.Rows(i)

         'Acumulo sus importes en sus ancestros (padre, abuelo, etc.)
         AcumulaEnPadre(drSumaSaldo, dtResultado, cuentas)

         'Agrego el registro de dtSumaSaldo en el DataTable de resultado (dtResultado)
         Dim drResultado As DataRow = dtResultado.Rows.Add(drSumaSaldo.ItemArray)

         'Busco la cuenta contable en el arbol para tomar valores de la cuenta.
         Dim drCuenta As DataRow = BuscarCuenta(drSumaSaldo("IdCuenta").ToString(), cuentas)

         'rn es la estructura del arbol, con ella puedo ordenar el arbol de forma correcta.
         drResultado("rn") = drCuenta("rn")

         'Tomo el nivel de la cuenta y le agrego espacios al nombre de la misma
         Dim level As Integer = Integer.Parse(drCuenta("level").ToString())
         drResultado("NombreCuenta") = New String(" "c, level * 4) + drResultado("NombreCuenta").ToString()
      Next

      Dim o As Entidades.ContabilidadReporte = New Entidades.ContabilidadReporte
      o.Balance = dtResultado

      'Limpio los valores en cero usando DBNull de las columnas de Sumas y Saldos
      For Each drResultado As DataRow In o.Balance.Rows
         If IsNumeric(drResultado("debeSumas")) AndAlso Decimal.Parse(drResultado("debeSumas").ToString()) = 0 Then
            drResultado("debeSumas") = DBNull.Value
         End If
         If IsNumeric(drResultado("haberSumas")) AndAlso Decimal.Parse(drResultado("haberSumas").ToString()) = 0 Then
            drResultado("haberSumas") = DBNull.Value
         End If

         If IsNumeric(drResultado("debeSaldos")) AndAlso Decimal.Parse(drResultado("debeSaldos").ToString()) <> 0 AndAlso
            IsNumeric(drResultado("haberSaldos")) AndAlso Decimal.Parse(drResultado("haberSaldos").ToString()) <> 0 Then
            If Decimal.Parse(drResultado("debeSaldos").ToString()) > Decimal.Parse(drResultado("haberSaldos").ToString()) Then
               drResultado("debeSaldos") = Decimal.Parse(drResultado("debeSaldos").ToString()) - Decimal.Parse(drResultado("haberSaldos").ToString())
               drResultado("haberSaldos") = DBNull.Value
            Else
               drResultado("haberSaldos") = Decimal.Parse(drResultado("haberSaldos").ToString()) - Decimal.Parse(drResultado("debeSaldos").ToString())
               drResultado("debeSaldos") = DBNull.Value
            End If
         End If

         If IsNumeric(drResultado("debeSaldos")) AndAlso Decimal.Parse(drResultado("debeSaldos").ToString()) = 0 Then
            drResultado("debeSaldos") = DBNull.Value
         End If
         If IsNumeric(drResultado("haberSaldos")) AndAlso Decimal.Parse(drResultado("haberSaldos").ToString()) = 0 Then
            drResultado("haberSaldos") = DBNull.Value
         End If
      Next

      Return o

   End Function

   Private Sub AcumulaEnPadre(drSumaSaldo As DataRow, dtResultado As DataTable, cuentas As DataTable)

      'Busco el padre en la colección de cuentas
      Dim cuentaPadre As DataRow = BuscarPadre(drSumaSaldo, cuentas)
      'Si no encontró el padre, lo corto
      If cuentaPadre Is Nothing Then Return

      'Tomo el Id del padre
      Dim idCuentaPadre As Long = Long.Parse(cuentaPadre("IdCuenta").ToString())
      'Busco si el padre ya se encuentra en el DataTable de resultados (drResultado)
      Dim drCol As DataRow() = dtResultado.Select(String.Format("IdCuenta = {0}", idCuentaPadre))
      Dim drCuentaPadre As DataRow
      If drCol.Length > 0 Then
         'Si ya está en el dtResultado, lo selecciono para acumular
         drCuentaPadre = drCol(0)
         If String.IsNullOrEmpty(drCuentaPadre("haberSumas").ToString()) Then
            drCuentaPadre("haberSumas") = 0
         End If
         If String.IsNullOrEmpty(drCuentaPadre("haberSaldos").ToString()) Then
            drCuentaPadre("haberSaldos") = 0
         End If
      Else
            'Si todavía no está, creo un nuevo regustro en drResultado para acumular en él los hijos.
            drCuentaPadre = dtResultado.NewRow()
         'drCuentaPadre("IdPlanCuenta") = drSumaSaldo("IdPlanCuenta")
         'drCuentaPadre("NombrePlanCuenta") = drSumaSaldo("NombrePlanCuenta")
         drCuentaPadre("IdCuenta") = cuentaPadre("IdCuenta")
         Dim level As Integer = Integer.Parse(cuentaPadre("level").ToString())
         drCuentaPadre("NombreCuenta") = New String(" "c, level * 4) + cuentaPadre("NombreCuenta").ToString()
         drCuentaPadre("IdCuentaPadre") = cuentaPadre("IdCuentaPadre")
         drCuentaPadre("debeSumas") = 0
         drCuentaPadre("haberSumas") = 0
         drCuentaPadre("debeSaldos") = 0
         drCuentaPadre("haberSaldos") = 0
         drCuentaPadre("rn") = cuentaPadre("rn")
         dtResultado.Rows.Add(drCuentaPadre)
      End If

      'Acumulo los valores en el padre
      If Not String.IsNullOrWhiteSpace(drSumaSaldo("debeSumas").ToString()) Then _
         drCuentaPadre("debeSumas") = Decimal.Parse(drCuentaPadre("debeSumas").ToString()) + Decimal.Parse(drSumaSaldo("debeSumas").ToString())

      If Not String.IsNullOrWhiteSpace(drSumaSaldo("haberSumas").ToString()) Then _
         drCuentaPadre("haberSumas") = Decimal.Parse(drCuentaPadre("haberSumas").ToString()) + Decimal.Parse(drSumaSaldo("haberSumas").ToString())

      If Not String.IsNullOrWhiteSpace(drSumaSaldo("debeSaldos").ToString()) Then _
         drCuentaPadre("debeSaldos") = Decimal.Parse(drCuentaPadre("debeSaldos").ToString()) + Decimal.Parse(drSumaSaldo("debeSaldos").ToString())

      If Not String.IsNullOrWhiteSpace(drSumaSaldo("haberSaldos").ToString()) Then _
         drCuentaPadre("haberSaldos") = Decimal.Parse(drCuentaPadre("haberSaldos").ToString()) + Decimal.Parse(drSumaSaldo("haberSaldos").ToString())

      'Acumulo en padre en su respectivo padre, haciendo esto recursivo
      If Not String.IsNullOrWhiteSpace(cuentaPadre("IdCuentaPadre").ToString()) Then
         AcumulaEnPadre(drCuentaPadre, dtResultado, cuentas)
      End If

   End Sub

   Private Function BuscarPadre(drSumaSaldo As DataRow, cuentas As DataTable) As DataRow
      'Busco una cuenta por el ID de su padre en el Datatable de cuentas.
      Return BuscarCuenta(drSumaSaldo("IdCuentaPadre").ToString(), cuentas)
   End Function
   Private Function BuscarCuenta(drSumaSaldo As DataRow, cuentas As DataTable) As DataRow
      'Busco una cuenta por su ID en el Datatable de cuentas.
      Return BuscarCuenta(drSumaSaldo("IdCuenta").ToString(), cuentas)
   End Function
   Private Function BuscarCuenta(idCuenta As String, cuentas As DataTable) As DataRow
      'Busco una cuenta por el ID suminstrado en el Datatable de cuentas.
      If Not String.IsNullOrWhiteSpace(idCuenta) Then
         Dim drCol As DataRow() = cuentas.Select(String.Format("IdCuenta = {0}", idCuenta))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Return Nothing
   End Function

End Class

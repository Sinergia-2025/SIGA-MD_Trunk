Public Class CajaDetalles
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CajaDetalles"
      da = accesoDatos
   End Sub

#End Region

#Region "Enumeraciones"

   Public Enum TipoOperacion
      Nuevo
      Modificacion
      Consulta
   End Enum

   Public Enum TipoMovimiento
      Ingreso
      Egreso
   End Enum

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer, OrdenarPor As String) As DataTable

      Dim stbQuery = New StringBuilder()

      Dim sql = New SqlServer.CajasDetalles(da)
      sql.SelectFiltrado(stbQuery)

      With stbQuery
         .AppendFormatLine("  WHERE C.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("    AND C.IdCaja = {0}", idCaja)
         .AppendFormatLine("    AND C.NumeroPlanilla = {0}", numeroPlanilla)

         If OrdenarPor = "FECHA" Then
            .AppendLine(" ORDER BY CONVERT(varchar(11), Cd.FechaMovimiento, 120), NumeroMovimiento")

         Else 'GRUPO
            .AppendLine(" ORDER BY Cc.IdGrupoCuenta, Cc.NombreCuentaCaja, CONVERT(varchar(11), Cd.FechaMovimiento, 120), NumeroMovimiento ")
         End If
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetUna(idSucursal As Integer,
                           idCaja As Integer,
                           numeroPlanilla As Integer,
                           numeroMovimiento As Integer) As Entidades.CajaDetalles
      Return EjecutaConConexion(Function() _GetUna(idSucursal, idCaja, numeroPlanilla, numeroMovimiento))
   End Function

   Public Function _GetUna(idSucursal As Integer,
                           idCaja As Integer,
                           numeroPlanilla As Integer,
                           numeroMovimiento As Integer) As Entidades.CajaDetalles

      Dim stbQuery = New StringBuilder()

      Dim sql = New SqlServer.CajasDetalles(da)
      sql.SelectFiltrado(stbQuery)

      With stbQuery
         .AppendFormat("  WHERE Cd.IdSucursal = {0}", idSucursal)
         .AppendFormat("    AND Cd.IdCaja = {0}", idCaja)
         .AppendFormat("    AND Cd.NumeroPlanilla = {0}", numeroPlanilla)
         .AppendFormat("    AND Cd.NumeroMovimiento = {0}", numeroMovimiento)
      End With

      Dim o As Entidades.CajaDetalles = Nothing
      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         o = New Entidades.CajaDetalles()
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o

   End Function

   Public Function GetTodasBuscarV2(entidad As Eniac.Entidades.Buscar,
                                    idSucursal As Integer,
                                    numeroPlanilla As Integer) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      entidad.Columna = "Cd." & entidad.Columna

      Select Case entidad.Columna

         Case "Cd.NombreCuentaCaja"
            entidad.Columna = "Cc." + entidad.Columna.Replace("Cd.", "")

            'Case "Lb.DescCheque"
            '   entidad.Columna = "Convert(varchar,Lb.NumeroCheque) + ' - ' + B.NombreBanco + ' (' + L.NombreLocalidad + ' )'"

      End Select
      Dim sql As SqlServer.CajasDetalles = New SqlServer.CajasDetalles(da)
      sql.SelectFiltrado(stbQuery)

      With stbQuery
         .AppendLine("  WHERE C.IdSucursal = " & idSucursal & " ")
         .AppendLine("    AND C.NumeroPlanilla = " & numeroPlanilla & " ")
         .AppendLine("     AND " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
         .AppendLine(" ORDER BY Cd.FechaMovimiento, NumeroMovimiento ")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetPorRangoFechas(entidad As Eniac.Entidades.Buscar,
                                     sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(),
                                     fechaDesde As Date, fechaHasta As Date, fechaConsulta As Entidades.CajaDetalles.FechaConsulta,
                                     idCuentaCaja As Integer, idGrupoCuenta As String,
                                     esModificable As Entidades.Publicos.SiNoTodos,
                                     nroPlanilla As Integer) As DataTable
      Return EjecutaConConexion(
         Function() New SqlServer.CajasDetalles(da).GetPorRangoFechas(entidad, sucursales, cajas,
                                                                      fechaDesde, fechaHasta, fechaConsulta,
                                                                      idCuentaCaja, idGrupoCuenta,
                                                                      esModificable, nroPlanilla))
   End Function

   Public Function GetSaldosIniciales(entidad As Entidades.Buscar,
                                      sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(),
                                      fechaDesde As Date, fechaConsulta As Entidades.CajaDetalles.FechaConsulta,
                                      idCuentaCaja As Integer, idGrupoCuenta As String,
                                      esModificable As Entidades.Publicos.SiNoTodos,
                                      nroPlanilla As Integer) As DataTable
      Return EjecutaConConexion(
         Function() New SqlServer.CajasDetalles(da).GetSaldosIniciales(entidad, sucursales, cajas,
                                                                       fechaDesde, fechaConsulta,
                                                                       idCuentaCaja, idGrupoCuenta,
                                                                       esModificable, nroPlanilla))
   End Function

   Public Function GetSaldosFinales(entidad As Eniac.Entidades.Buscar,
                                    sucursales As Entidades.Sucursal(),
                                    Cajas As List(Of Entidades.CajaNombre),
                                    FechaHasta As Date,
                                    EsFechaMovimiento As Boolean,
                                    IdCuentaCaja As Integer,
                                    IdGrupoCuenta As String,
                                    EsModificable As String,
                                    NroPlanilla As Integer) As DataTable
      Return EjecutaConConexion(
         Function() New SqlServer.CajasDetalles(da).GetSaldosFinales(entidad, sucursales, Cajas, FechaHasta, EsFechaMovimiento, IdCuentaCaja, IdGrupoCuenta, EsModificable, NroPlanilla))
   End Function
   Public Function GetSaldos(entidad As Eniac.Entidades.Buscar,
                                   sucursales As Entidades.Sucursal(),
                                   Cajas As List(Of Entidades.CajaNombre),
                                   FechaDesde As Date,
                                   EsFechaMovimiento As Boolean,
                                   IdCuentaCaja As Integer,
                                   IdGrupoCuenta As String,
                                   EsModificable As String,
                                   NroPlanilla As Integer) As DataTable
      Return EjecutaConConexion(
         Function() New SqlServer.CajasDetalles(da).GetSaldos(entidad, sucursales, Cajas, FechaDesde, EsFechaMovimiento, IdCuentaCaja, IdGrupoCuenta, EsModificable, NroPlanilla))
   End Function
   Public Function ResumenDeCaja(sucursales As Entidades.Sucursal(),
                                 cajas As Entidades.CajaNombre(),       'IdCaja As Integer,
                                 FechaDesde As Date,
                                 FechaHasta As Date,
                                 EsFechaMovimiento As Boolean) As DataTable
      Return EjecutaConConexion(
         Function() New SqlServer.CajasDetalles(da).ResumenDeCaja(sucursales, cajas, FechaDesde, FechaHasta, EsFechaMovimiento))
   End Function

   Public Function InformeCajayBancos(sucursales As Entidades.Sucursal(),
                                      cajas As Entidades.CajaNombre(),
                                      fechaDesde As Date,
                                      fechaHasta As Date,
                                      esFechaMovimiento As Boolean,
                                      idCuentaCaja As Integer,
                                      idGrupoCuenta As String,
                                      esModificable As String,
                                      incluyeSaldoInicial As Boolean) As DataTable
      Dim dtDetalle As DataTable
      Try
         da.OpenConection()
         dtDetalle = New SqlServer.CajasDetalles(da).InformeCajayBancos(sucursales, cajas, fechaDesde, fechaHasta, esFechaMovimiento, idCuentaCaja, idGrupoCuenta, esModificable, incluyeSaldoInicial)
      Finally
         da.CloseConection()
      End Try
      If dtDetalle IsNot Nothing Then
         Dim Saldo_Ef As Decimal = 0
         Dim Saldo_Ch As Decimal = 0
         Dim Saldo_Ta As Decimal = 0
         Dim Saldo_Dol As Decimal = 0
         Dim Saldo_Ret As Decimal = 0
         Dim SaldoTotalCaja As Decimal = 0
         Dim Saldo_Ba As Decimal = 0
         Dim SaldoGral As Decimal = 0

         For Each dr As DataRow In dtDetalle.Rows
            Saldo_Ef += Decimal.Parse(dr("Efectivo$").ToString())
            dr("Saldo_Ef_$") = Saldo_Ef.ToString("N2")

            Saldo_Ch += Decimal.Parse(dr("Cheques3ros").ToString())
            dr("Saldo_Ch_$") = Saldo_Ch.ToString("N2")

            Saldo_Ta += Decimal.Parse(dr("Tarjetas").ToString())
            dr("Saldo_Ta_$") = Saldo_Ta.ToString("N2")

            Saldo_Dol += Decimal.Parse(dr("Dolares").ToString())
            dr("Saldo_Dol_u$s") = Saldo_Dol.ToString("N2")

            Saldo_Ret += Decimal.Parse(dr("Retenciones").ToString())
            dr("Saldo_Ret_$") = Saldo_Ret.ToString("N2")

            Saldo_Ba += Decimal.Parse(dr("BancoCC").ToString())
            dr("Saldo_Ba_$") = Saldo_Ba.ToString("N2")

            SaldoTotalCaja = Saldo_Ef + Saldo_Ch + Saldo_Ta + Saldo_Dol + Saldo_Ret
            dr("SaldoTotalCaja") = SaldoTotalCaja.ToString("N2")

            SaldoGral = Saldo_Ba + SaldoTotalCaja
            dr("SaldoGeneral") = SaldoGral.ToString("N2")
         Next
      End If
      Return dtDetalle
   End Function

   Public Function MayorDeCuentaDeCaja(sucursales As Entidades.Sucursal(),
                                       IdCaja As Integer,
                                       IdCuentaCaja As Integer,
                                       FechaDesde As Date,
                                       FechaHasta As Date,
                                       EsFechaMovimiento As Boolean) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT  CD.IdSucursal,  CN.NombreCaja, C.FechaPlanilla, CD.FechaMovimiento, CD.NumeroPlanilla, CD.NumeroMovimiento, CD.Observacion, ")
         .AppendLine("  CASE CD.IdTipoMovimiento")
         .AppendLine("    WHEN 'I' Then CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas+CD.ImporteBancos+CD.ImporteRetenciones+(CD.ImporteDolares*Cd.CotizacionDolar)")
         .AppendLine("    WHEN 'E' Then 0")
         .AppendLine("  END Ingreso,")
         .AppendLine("  CASE CD.IdTipoMovimiento")
         .AppendLine("    WHEN 'I' Then 0")
         .AppendLine("    WHEN 'E' Then CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas+CD.ImporteBancos+CD.ImporteRetenciones+(CD.ImporteDolares*Cd.CotizacionDolar)")
         .AppendLine("  END Egreso")
         .AppendLine(" FROM Cajas C, CajasNombres CN, CajasDetalle CD")
         .AppendLine(" WHERE C.IdSucursal = CN.IdSucursal")
         .AppendLine("   AND C.IdCaja= CN.IdCaja")
         .AppendLine("   AND C.IdSucursal = CD.IdSucursal")
         .AppendLine("   AND C.IdCaja = CD.IdCaja ")
         .AppendLine("   AND C.NumeroPlanilla = CD.NumeroPlanilla")

         '.AppendLine("   AND C.idsucursal = " & idSucursal.ToString())
         SqlServer.Comunes.GetListaSucursalesMultiples(stbQuery, sucursales, "C")

         .AppendLine("   AND CD.IdCuentaCaja = " & IdCuentaCaja.ToString())
         If IdCaja > 0 Then
            .AppendLine("   AND C.IdCaja = " & IdCaja.ToString())
         End If
         If EsFechaMovimiento Then
            .AppendLine("   AND CD.FechaMovimiento BETWEEN '" & FechaDesde.ToString("yyyyMMdd") & " 00:00:00' AND '" & FechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         Else
            .AppendLine("   AND C.FechaPlanilla BETWEEN '" & FechaDesde.ToString("yyyyMMdd") & " 00:00:00' AND '" & FechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         End If
      End With

      Return da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function ResumenAnual(sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(),
                                anio As Integer, esFechaMovimiento As Boolean, tipoValor As String) As DataTable
      Return New SqlServer.CajasDetalles(da).ResumenAnual(sucursales, cajas, anio, esFechaMovimiento, tipoValor)
   End Function

   Public Function GetUltimoMovVenta(idSucursal As Integer, idCaja As Integer,
                                     numeroPlanilla As Integer, idCuentaCaja As Integer, fecha As Date) As Entidades.CajaDetalles
      Dim o As Entidades.CajaDetalles = Nothing
      Dim dt As DataTable = New SqlServer.CajasDetalles(da).GetUltimoMovimientoDeVentas(idSucursal, idCaja, numeroPlanilla, idCuentaCaja, fecha)
      If dt.Rows.Count > 0 Then
         o = New Entidades.CajaDetalles(idSucursal, "", "")
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   'Public Sub AgregaMovimiento(entidad As Entidades.Entidad, chequesTerceros As ArrayList, chequesPropios As ArrayList)
   Public Sub AgregaMovimiento(ByRef eCajaDetalle As Entidades.CajaDetalles,
                               chequesTerceros As IEnumerable(Of Entidades.Cheque),
                               chequesPropios As IEnumerable(Of Entidades.Cheque))
      AgregaMovimiento(eCajaDetalle, chequesTerceros, chequesPropios, cuponesTarjetas:={})
   End Sub

   Public Sub AgregaMovimiento(ByRef eCajaDetalle As Entidades.CajaDetalles,
                               chequesTerceros As IEnumerable(Of Entidades.Cheque),
                               chequesPropios As IEnumerable(Of Entidades.Cheque),
                               cuponesTarjetas As IEnumerable(Of Entidades.TarjetaCupon))

      Dim caja As Entidades.Caja = New Reglas.Cajas(da).GetPlanillaActual(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja)
      If caja.NumeroPlanilla <> eCajaDetalle.NumeroPlanilla Then
         Throw New Exception(String.Format("La planilla de caja {0} ya fue cerrada. No es posible agregar el movimiento. Por favor verifique.", eCajaDetalle.NumeroPlanilla))
      End If

      'Dim eCajaDetalle As Entidades.CajaDetalles
      'eCajaDetalle = DirectCast(entidad, Entidades.CajaDetalles)

      ' Obtener Proximo numero de movimiento
      Dim prNroMovimiento As Integer = Me.GetProximoNumeroDeMovimiento(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja, eCajaDetalle.NumeroPlanilla)
      eCajaDetalle.NumeroMovimiento = prNroMovimiento

      'Cambio los valores a grabar si es un egreso
      Dim Coef As Integer = Integer.Parse(IIf(eCajaDetalle.IdTipoMovimiento = "I", 1, -1).ToString())

      'Modifica coeficiente si devuelve plata
      'If eCajaDetalle.ImportePesos < 0 Or eCajaDetalle.ImporteDolares < 0 Or eCajaDetalle.ImporteTickets < 0 Or _
      '   eCajaDetalle.ImporteCheques < 0 Or eCajaDetalle.ImporteTarjetas < 0 Or eCajaDetalle.ImporteBancos < 0 Or _
      '   eCajaDetalle.ImporteRetenciones < 0 Then
      '   Coef = Coef * -1
      'End If

      eCajaDetalle.ImportePesos = eCajaDetalle.ImportePesos * Coef
      eCajaDetalle.ImporteDolares = eCajaDetalle.ImporteDolares * Coef
      eCajaDetalle.ImporteTickets = eCajaDetalle.ImporteTickets * Coef
      eCajaDetalle.ImporteCheques = eCajaDetalle.ImporteCheques * Coef
      eCajaDetalle.ImporteTarjetas = eCajaDetalle.ImporteTarjetas * Coef
      eCajaDetalle.ImporteBancos = eCajaDetalle.ImporteBancos * Coef
      eCajaDetalle.ImporteRetenciones = eCajaDetalle.ImporteRetenciones * Coef

      Dim detalleMovVentas As Entidades.CajaDetalles = Nothing
      If Not eCajaDetalle.EsModificable Then    'Los modificables (manuales) no deben agrupar nunca PE-26888
         If Not eCajaDetalle.IgnoraAcumulaVentas Then

            If eCajaDetalle.IdCuentaCaja = Publicos.CtaCajaVentas Then
               'Solo agrupa las ventas (FACT/NC), las anulaciones van aparte.
               If Publicos.CtaCajaVentasAcumula And Not eCajaDetalle.Observacion.StartsWith("ANULA") Then
                  'Pregunto si agrupa las NC o las hace aparte
                  If Coef = 1 Or Not Publicos.CajaMostrarNCIndividual Then
                     detalleMovVentas = Me.GetUltimoMovVenta(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja, eCajaDetalle.NumeroPlanilla, eCajaDetalle.IdCuentaCaja, eCajaDetalle.FechaMovimiento)
                  End If
               End If
            End If
         End If      ' If Not eCajaDetalle.IgnoraAcumulaVentas Then
      End If

      If detalleMovVentas Is Nothing Then

         ' Insertar nuevo movimiento
         Me.InsertarNuevoMovimiento(eCajaDetalle)

         ' Asociar Cheques de Terceros
         Me.AsociarChequesTercerosAMovimiento(chequesTerceros, eCajaDetalle)

         ' Asociar Cheques Propios
         Me.AsociarChequesPropiosAMovimiento(chequesPropios, eCajaDetalle)

         AsociarCuponesTarjetasAMovimiento(cuponesTarjetas, eCajaDetalle)

      Else

         'Privilegio el valor total, temporalmente aplicando una NC queda en Negativo.
         If detalleMovVentas.ImportePesos + eCajaDetalle.ImportePesos >= 0 Then
            detalleMovVentas.IdTipoMovimiento = "I"c
         Else
            detalleMovVentas.IdTipoMovimiento = "E"c
         End If

         detalleMovVentas.Observacion = "Ventas"
         detalleMovVentas.ImportePesos += eCajaDetalle.ImportePesos
         detalleMovVentas.ImporteTarjetas += eCajaDetalle.ImporteTarjetas
         detalleMovVentas.ImporteTickets += eCajaDetalle.ImporteTickets
         detalleMovVentas.ImporteCheques += eCajaDetalle.ImporteCheques
         detalleMovVentas.ImporteDolares += eCajaDetalle.ImporteDolares
         detalleMovVentas.ImporteBancos += eCajaDetalle.ImporteBancos
         detalleMovVentas.ImporteRetenciones += eCajaDetalle.ImporteRetenciones

         If detalleMovVentas.ImporteBancos <> 0 AndAlso Not detalleMovVentas.IdMonedaImporteBancos.HasValue AndAlso eCajaDetalle.IdMonedaImporteBancos.HasValue Then
            detalleMovVentas.IdMonedaImporteBancos = eCajaDetalle.IdMonedaImporteBancos
         End If

         detalleMovVentas.Usuario = eCajaDetalle.Usuario

         'Al sumar una NC sobre una venta, en la funcion "ActualizaMovimiento"
         Dim blnAplicaCoeficiente As Boolean = False

         Me.ActualizaMovimiento(detalleMovVentas, Nothing, blnAplicaCoeficiente)

         ' Asociar Cheques de Terceros
         Me.AsociarChequesTercerosAMovimiento(chequesTerceros, detalleMovVentas)

         ' Asociar Cheques Propios
         Me.AsociarChequesPropiosAMovimiento(chequesPropios, detalleMovVentas)

         AsociarCuponesTarjetasAMovimiento(cuponesTarjetas, detalleMovVentas)
      End If

      'SOLO REGISTRO LOS MOVIMIENTOS DE CAJA QUE SON GeneraContabilidad YA QUE LOS QUE SON DE VENTAS O COMPRAS LOS REGISTRO DESDE ALLI
      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea And eCajaDetalle.GeneraContabilidad Then
         Dim ctbl As Contabilidad = New Contabilidad(da)
         ctbl.RegistraContabilidad(eCajaDetalle)
      End If

   End Sub

   Private Function filaClave(TablaClave As DataTable, eCajaDetalle As Entidades.CajaDetalles) As DataRow
      Dim filaC As DataRow = TablaClave.NewRow

      filaC("IdSucursal") = eCajaDetalle.IdSucursal
      filaC("IdCaja") = eCajaDetalle.IdCaja
      filaC("NumeroPlanilla") = eCajaDetalle.NumeroPlanilla
      filaC("NumeroMovimiento") = eCajaDetalle.NumeroMovimiento

      TablaClave.Rows.Add(filaC)

      Return TablaClave.Rows(0)

   End Function


   'Public Sub AgregarMovimiento(entidad As Eniac.Entidades.Entidad, ChequesTerceros As ArrayList, ChequesPropios As ArrayList)
   Public Sub AgregarMovimiento(eCajaDetalle As Entidades.CajaDetalles,
                                chequesTerceros As IEnumerable(Of Entidades.Cheque), chequesPropios As IEnumerable(Of Entidades.Cheque),
                                cuponesTarjetas As DataTable)
      Dim rCupones = New TarjetasCupones(da)
      AgregarMovimiento(eCajaDetalle,
                                chequesTerceros, chequesPropios,
                                rCupones.GetTodos(cuponesTarjetas))
   End Sub
   Public Sub AgregarMovimiento(eCajaDetalle As Entidades.CajaDetalles,
                                chequesTerceros As IEnumerable(Of Entidades.Cheque), chequesPropios As IEnumerable(Of Entidades.Cheque),
                                cuponesTarjetas As IEnumerable(Of Entidades.TarjetaCupon))
      EjecutaConTransaccion(Sub() AgregaMovimiento(eCajaDetalle, chequesTerceros, chequesPropios, cuponesTarjetas))
   End Sub

   Friend Sub ActualizaMovimiento(entidad As Entidades.Entidad, cheques As IEnumerable(Of Entidades.Cheque), AplicaCoeficiente As Boolean)

      Dim eCajaDetalle As Entidades.CajaDetalles
      eCajaDetalle = DirectCast(entidad, Entidades.CajaDetalles)

      Dim caja As Entidades.Caja = New Reglas.Cajas(da).GetPlanillaActual(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja)
      If caja.NumeroPlanilla <> eCajaDetalle.NumeroPlanilla Then
         Throw New Exception(String.Format("La planilla de caja {0} ya fue cerrada. No es posible modificar el movimiento. Por favor verifique.", eCajaDetalle.NumeroPlanilla))
      End If

      If eCajaDetalle.GeneraContabilidad Then
         If Publicos.TieneModuloContabilidad AndAlso ContabilidadPublicos.UtilizaCentroCostos Then
            If eCajaDetalle.CentroCosto Is Nothing Then
               Dim cuenta As Entidades.CuentaDeCaja = New CuentasDeCajas(da).GetUna(eCajaDetalle.IdCuentaCaja)
               eCajaDetalle.CentroCosto = cuenta.CentroCosto
               If eCajaDetalle.CentroCosto Is Nothing Then
                  Throw New Exception(String.Format("La cuenta de caja {0} - {1} no tiene asignado un centro de costos. Por favor verifique la configuración y reintente.",
                                                    cuenta.IdCuentaCaja, cuenta.NombreCuentaCaja))
               End If
            End If
         End If
      End If

      If AplicaCoeficiente Then
         'Cambio los valores a grabar si es un egreso
         Dim Coef As Integer = Integer.Parse(IIf(eCajaDetalle.IdTipoMovimiento = "I", 1, -1).ToString())

         eCajaDetalle.ImportePesos = eCajaDetalle.ImportePesos * Coef
         eCajaDetalle.ImporteDolares = eCajaDetalle.ImporteDolares * Coef
         eCajaDetalle.ImporteTickets = eCajaDetalle.ImporteTickets * Coef
         eCajaDetalle.ImporteCheques = eCajaDetalle.ImporteCheques * Coef
         eCajaDetalle.ImporteTarjetas = eCajaDetalle.ImporteTarjetas * Coef
         eCajaDetalle.ImporteBancos = eCajaDetalle.ImporteBancos * Coef
         eCajaDetalle.ImporteRetenciones = eCajaDetalle.ImporteRetenciones * Coef

      End If

      ' Actualizar Movimiento
      Me.ModificarMovimiento(eCajaDetalle)

      ' Asociar / Desasociar Cheques
      Me.DesasociarChequesTercerosAMovimiento(eCajaDetalle.IdSucursal, eCajaDetalle.IdTipoMovimiento, cheques)

      ' Re-Asociar Cheques
      Me.AsociarChequesTercerosAMovimiento(cheques, eCajaDetalle)

      'DesasociarCuponesTarjetasAMovimiento(eCajaDetalle, notInCuponesTarjetas:=cuponesTarjeta)
      'AsociarCuponesTarjetasAMovimiento(cuponesTarjeta, eCajaDetalle)

      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea And eCajaDetalle.GeneraContabilidad And
         eCajaDetalle.IdEjercicio.HasValue AndAlso eCajaDetalle.IdAsiento.HasValue AndAlso eCajaDetalle.IdPlanCuenta.HasValue Then
         Dim ctbl As Contabilidad = New Contabilidad(da)
         If ctbl.AsientoProcesadoComoDefinitivo(eCajaDetalle.IdEjercicio, eCajaDetalle.IdPlanCuenta, eCajaDetalle.IdAsiento) Then
            Throw New Exception("No es posible Modificar el movimiento de caja porque el asiento contable asociado ya fue procesado como DEFINITIVO.")
         End If
         ctbl.RegenerarDetalleContabilidad(eCajaDetalle)
         ''Me.EditarContabilidad(eCajaDetalle)
      End If

   End Sub

   Public Sub ActualizarMovimiento(entidad As Entidades.Entidad, Cheques As IEnumerable(Of Entidades.Cheque), AplicaCoeficiente As Boolean)
      EjecutaConTransaccion(Sub() ActualizaMovimiento(entidad, Cheques, AplicaCoeficiente))
   End Sub

   Public Function GetProximoNumeroDeMovimiento(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Integer
      Dim dtMax = New SqlServer.CajasDetalles(da).GetProximoNumeroDeMovimiento(idSucursal, idCaja, numeroPlanilla)
      Dim proximoNumeroMovimiento As Integer = 1
      If Not dtMax.Rows(0)(0) Is DBNull.Value Then
         proximoNumeroMovimiento = Integer.Parse(dtMax.Rows(0)(0).ToString())
      End If
      Return proximoNumeroMovimiento
   End Function

   Public Sub InsertarNuevoMovimiento(cajaDetalles As Entidades.CajaDetalles)

      If cajaDetalles.GeneraContabilidad Then
         If Publicos.TieneModuloContabilidad AndAlso ContabilidadPublicos.UtilizaCentroCostos Then
            If cajaDetalles.CentroCosto Is Nothing Then
               Dim cuenta As Entidades.CuentaDeCaja = New CuentasDeCajas().GetUna(cajaDetalles.IdCuentaCaja)
               cajaDetalles.CentroCosto = cuenta.CentroCosto
               If cajaDetalles.CentroCosto Is Nothing Then
                  Throw New Exception(String.Format("La cuenta de caja {0} - {1} no tiene asignado un centro de costos. Por favor verifique la configuración y reintente.",
                                                    cuenta.IdCuentaCaja, cuenta.NombreCuentaCaja))
               End If
            End If
         End If
      End If

      Dim sqlCD As SqlServer.CajasDetalles = New SqlServer.CajasDetalles(da)

      sqlCD.CajaDetalles_I(cajaDetalles.IdSucursal, cajaDetalles.IdCaja, cajaDetalles.NumeroPlanilla,
                           cajaDetalles.NumeroMovimiento, cajaDetalles.IdCuentaCaja,
                           cajaDetalles.IdTipoMovimiento, cajaDetalles.FechaMovimiento,
                           cajaDetalles.Observacion, cajaDetalles.ImportePesos,
                           cajaDetalles.ImporteDolares, cajaDetalles.ImporteTickets,
                           cajaDetalles.ImporteCheques, cajaDetalles.ImporteTarjetas,
                           cajaDetalles.ImporteBancos, cajaDetalles.ImporteRetenciones,
                           cajaDetalles.EsModificable, cajaDetalles.Usuario,
                           cajaDetalles.IdCentroCosto, cajaDetalles.GeneraContabilidad,
                           cajaDetalles.CotizacionDolar, cajaDetalles.IdTipoComprobante,
                           cajaDetalles.NumeroDeposito, cajaDetalles.IdMonedaImporteBancos,
                           cajaDetalles.IdConceptoCM05)

      'Cuando inserto el primer movimiento, le asigno la fecha de la planilla
      'Antes, quedaba siempre con la fecha de cerrado, no necesariamente es la apertura (de Viernes para un Lunes).
      If cajaDetalles.NumeroMovimiento = 1 Then
         Dim sqlC As SqlServer.Cajas = New SqlServer.Cajas(da)
         'Dim fechaServidor As Date = New SqlServer.Generales(da).GetServerDBFechaHora()
         If Publicos.CajaPlanillaNuevaFechaDelDia Then
            sqlC.Cajas_UFecha(cajaDetalles.IdSucursal, cajaDetalles.IdCaja, cajaDetalles.NumeroPlanilla, Date.Now()) 'fechaServidor)
         Else
            sqlC.Cajas_UFecha(cajaDetalles.IdSucursal, cajaDetalles.IdCaja, cajaDetalles.NumeroPlanilla, cajaDetalles.FechaMovimiento) 'fechaServidor)
         End If
      End If
   End Sub

   Public Sub ModificarMovimiento(cajaDetalles As Entidades.CajaDetalles)
      Dim sqlCD As SqlServer.CajasDetalles = New SqlServer.CajasDetalles(da)
      sqlCD.CajaDetalles_U(cajaDetalles.IdSucursal, cajaDetalles.IdCaja, cajaDetalles.NumeroPlanilla,
                           cajaDetalles.NumeroMovimiento, cajaDetalles.IdCuentaCaja,
                           cajaDetalles.IdTipoMovimiento, cajaDetalles.FechaMovimiento,
                           cajaDetalles.Observacion, cajaDetalles.ImportePesos,
                           cajaDetalles.ImporteDolares, cajaDetalles.ImporteTickets,
                           cajaDetalles.ImporteCheques, cajaDetalles.ImporteTarjetas,
                           cajaDetalles.ImporteBancos, cajaDetalles.ImporteRetenciones,
                           cajaDetalles.Usuario, cajaDetalles.IdCentroCosto,
                           cajaDetalles.CotizacionDolar, cajaDetalles.IdTipoComprobante,
                           cajaDetalles.NumeroDeposito, cajaDetalles.IdMonedaImporteBancos,
                           cajaDetalles.IdConceptoCM05)
   End Sub

   Public Sub AsociarChequesTercerosAMovimiento(ChequesTerceros As IEnumerable(Of Entidades.Cheque), cajaDetalle As Entidades.CajaDetalles)

      If Not ChequesTerceros Is Nothing Then

         Dim oChequesTerceros As Reglas.Cheques = New Reglas.Cheques(da)

         For Each Ch As Entidades.Cheque In ChequesTerceros

            If Ch.RowState <> DataRowState.Deleted Then
               If Not Ch.RowState = DataRowState.Unchanged Then
                  If cajaDetalle.IdTipoMovimiento = "I" Then
                     oChequesTerceros.AsociarChequesAMovimientoIngreso(Ch, cajaDetalle.IdCaja, cajaDetalle.NumeroPlanilla, cajaDetalle.NumeroMovimiento)
                  ElseIf cajaDetalle.IdTipoMovimiento = "E" Then
                     oChequesTerceros.AsociarChequesAMovimientoEgreso(Ch, cajaDetalle.IdCaja, cajaDetalle.NumeroPlanilla, cajaDetalle.NumeroMovimiento)
                  End If
               End If
            End If
         Next
      End If

   End Sub

   Public Sub AsociarCuponesTarjetasAMovimiento(cuponesTarjetas As IEnumerable(Of Entidades.TarjetaCupon), cajaDetalle As Entidades.CajaDetalles)
      If cuponesTarjetas.AnySecure() Then
         Dim rCupones = New TarjetasCupones(da)
         For Each tr In cuponesTarjetas
            If cajaDetalle.IdTipoMovimiento = "I" Then
               tr.IdEstadoTarjeta = Entidades.TarjetaCupon.Estados.ENCARTERA
               rCupones.AsociarCuponAMovimientoIngreso(tr, cajaDetalle)
            ElseIf cajaDetalle.IdTipoMovimiento = "E" Then
               tr.IdEstadoTarjeta = Entidades.TarjetaCupon.Estados.ACREDITADO
               rCupones.AsociarCuponAMovimientoEgreso(tr, cajaDetalle)
            End If
         Next
      End If
   End Sub
   'Private Sub DesasociarCuponesTarjetasAMovimiento(cajaDetalle As Entidades.CajaDetalles, notInCuponesTarjetas As IEnumerable(Of Entidades.TarjetaCupon))
   '   Dim rCupones = New TarjetasCupones(da)
   '   If cajaDetalle.IdTipoMovimiento = "I" Then
   '      rCupones.DesasociarCuponAMovimientoIngreso(cajaDetalle, notInCuponesTarjetas)
   '   ElseIf cajaDetalle.IdTipoMovimiento = "E" Then
   '      rCupones.DesasociarCuponAMovimientoEgreso(cajaDetalle, notInCuponesTarjetas)
   '   End If
   'End Sub

   Public Function GetMovimiento(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer, numeroMovimiento As Integer) As DataTable
      Return New SqlServer.CajasDetalles(da).GetMovimiento(idSucursal, idCaja, numeroPlanilla, numeroMovimiento)
   End Function

   Public Sub BorrarMovimiento(eCajaDetalle As Entidades.CajaDetalles, Cheques As IEnumerable(Of Entidades.Cheque))
      EjecutaConTransaccion(Sub() _BorrarMovimiento(eCajaDetalle, Cheques))
   End Sub
   Public Sub _BorrarMovimiento(eCajaDetalle As Entidades.CajaDetalles, Cheques As IEnumerable(Of Entidades.Cheque))
      'Dim oReglas = New Reglas.Parametros()

      'Dim eCajaDetalle = DirectCast(entidad, Entidades.CajaDetalles)
      If Not eCajaDetalle.EsModificable Then
         Throw New Exception("No es modificable este detalle")
      End If

      'Si Utilizo Cheques los tengo que Desasociar
      If eCajaDetalle.ImporteCheques <> 0 Then
         DesasociarChequesTercerosAMovimiento(actual.Sucursal.Id, eCajaDetalle.IdTipoMovimiento, Cheques)
      End If

      'Si tiene Contablilidad elimino el asiento temporal, si tenia asiento definitivo, no llogo hasta aca
      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea And eCajaDetalle.IdEjercicio.HasValue And eCajaDetalle.IdPlanCuenta.HasValue And eCajaDetalle.IdAsiento.HasValue Then
         Dim ctbl As Contabilidad = New Contabilidad(da)
         If ctbl.AsientoProcesadoComoDefinitivo(eCajaDetalle.IdEjercicio, eCajaDetalle.IdPlanCuenta, eCajaDetalle.IdAsiento) Then
            Throw New Exception("No es posible Eliminar el movimiento de caja porque el asiento contable asociado ya fue procesado como DEFINITIVO.")
         End If
         ctbl.EliminarAsientoContabilidad(eCajaDetalle)
      End If

      Dim caja As Entidades.Caja = New Reglas.Cajas(da).GetPlanillaActual(eCajaDetalle.IdSucursal, eCajaDetalle.IdCaja)
      If caja.NumeroPlanilla <> eCajaDetalle.NumeroPlanilla Then
         Throw New Exception(String.Format("La planilla de caja {0} ya fue cerrada. No es posible eliminar el movimiento. Por favor verifique.", eCajaDetalle.NumeroPlanilla))
      End If

      'DesasociarCuponesTarjetasAMovimiento(eCajaDetalle, {})

      DesasociarCuponesAMovimiento(eCajaDetalle)

      EliminarMovimiento(actual.Sucursal.Id, eCajaDetalle.IdCaja, eCajaDetalle.NumeroPlanilla, eCajaDetalle.NumeroMovimiento)

   End Sub
#End Region

#Region "Metodos Privados"
   Private Sub CargarUno(o As Entidades.CajaDetalles, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .IdCaja = Integer.Parse(dr("IdCaja").ToString())
         .NumeroPlanilla = Integer.Parse(dr("NumeroPlanilla").ToString())
         .NumeroMovimiento = Integer.Parse(dr("NumeroMovimiento").ToString())
         .FechaMovimiento = DateTime.Parse(dr("FechaMovimiento").ToString())
         .IdCuentaCaja = Integer.Parse(dr("IdCuentaCaja").ToString())
         .IdTipoMovimiento = Char.Parse(dr("IdTipoMovimiento").ToString())
         .ImportePesos = Decimal.Parse(dr("ImportePesos").ToString())
         .ImporteDolares = Decimal.Parse(dr("ImporteDolares").ToString())
         .ImporteCheques = Decimal.Parse(dr("ImporteCheques").ToString())
         .ImporteTarjetas = Decimal.Parse(dr("ImporteTarjetas").ToString())
         .ImporteBancos = Decimal.Parse(dr("ImporteBancos").ToString())
         .ImporteRetenciones = Decimal.Parse(dr("ImporteRetenciones").ToString())
         .Observacion = dr("Observacion").ToString()
         .EsModificable = Boolean.Parse(dr("EsModificable").ToString())
         .GeneraContabilidad = Boolean.Parse(dr("GeneraContabilidad").ToString())
         .ImporteTickets = Decimal.Parse(dr("ImporteTickets").ToString())
         .CotizacionDolar = Decimal.Parse(dr("CotizacionDolar").ToString())
         .IdMonedaImporteBancos = dr.Field(Of Integer?)("IdMonedaImporteBancos")
         .IdConceptoCM05 = dr.Field(Of Integer?)("IdConceptoCM05")

         If Not IsDBNull(dr("IdEjercicio")) Then
            .IdEjercicio = CInt(dr("IdEjercicio"))
         End If
         If Not IsDBNull(dr("IdPlanCuenta")) Then
            .IdPlanCuenta = CInt(dr("IdPlanCuenta"))
         End If
         If Not IsDBNull(dr("IdAsiento")) Then
            .IdAsiento = CInt(dr("IdAsiento"))
         End If
         If Not IsDBNull(dr(Entidades.CajaDetalles.Columnas.IdTipoComprobante.ToString())) Then
            .IdTipoComprobante = dr.Field(Of String)(Entidades.CajaDetalles.Columnas.IdTipoComprobante.ToString())
         End If
         If Not IsDBNull(dr(Entidades.CajaDetalles.Columnas.NumeroDeposito.ToString())) Then
            .NumeroDeposito = dr.Field(Of Long?)(Entidades.CajaDetalles.Columnas.NumeroDeposito.ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CajaDetalles.Columnas.IdCentroCosto.ToString()).ToString()) Then
            .CentroCosto = New Reglas.ContabilidadCentrosCostos(da)._GetUna(Integer.Parse(dr(Entidades.CajaDetalles.Columnas.IdCentroCosto.ToString()).ToString()))
         End If
      End With
   End Sub

   Private Sub DesasociarChequesTercerosAMovimiento(idSucursal As Integer, TipoMovimiento As String, cheques As IEnumerable(Of Entidades.Cheque))

      Dim oCheques As Reglas.Cheques = New Reglas.Cheques(da)

      If Not cheques Is Nothing Then
         For Each ch As Entidades.Cheque In cheques
            If ch.RowState = DataRowState.Deleted Then
               oCheques.DesasociarChequesAMovimiento(idSucursal, TipoMovimiento, ch.NumeroCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.IdCheque)
            End If
         Next
      End If

   End Sub

   Private Sub AsociarChequesPropiosAMovimiento(ChequesPropios As IEnumerable(Of Entidades.Cheque), cajaDetalle As Entidades.CajaDetalles)

      If Not ChequesPropios Is Nothing Then

         Dim oChequesPropios As Reglas.Cheques = New Reglas.Cheques(da)

         For Each Ch As Entidades.Cheque In ChequesPropios
            If Ch.RowState <> DataRowState.Deleted Then
               oChequesPropios.AsociarChequesAMovimientoEgreso(Ch, cajaDetalle.IdCaja, cajaDetalle.NumeroPlanilla, cajaDetalle.NumeroMovimiento)
            End If
         Next

      End If

   End Sub

   Private Sub DesasociarChequesPropiosAMovimiento(idSucursal As Integer, TipoMovimiento As String, chequesPropios As ArrayList)
      Dim oChequesPropios As Reglas.Cheques = New Reglas.Cheques(da)
      If Not chequesPropios Is Nothing Then
         For Each ch As Entidades.Cheque In chequesPropios
            If ch.RowState = DataRowState.Deleted Then
               oChequesPropios.DesasociarChequesAMovimiento(idSucursal, TipoMovimiento, ch.NumeroCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.IdCheque)
            End If
         Next
      End If
   End Sub

   Private Sub DesasociarCuponesAMovimiento(cajaDetalle As Entidades.CajaDetalles)
      Dim estadoAnterior = If(cajaDetalle.IdTipoMovimiento = Entidades.CajaDetalles.TipoMovimiento.Ingreso, Entidades.TarjetaCupon.Estados.ALTA, Entidades.TarjetaCupon.Estados.ENCARTERA)
      Dim rCupones = New TarjetasCupones(da)
      rCupones.DesasociarCuponAMovimiento(cajaDetalle, estadoAnterior)
   End Sub

   Private Sub EliminarMovimiento(idSucursal As Integer,
                                  idCaja As Integer,
                                  nroPlanilla As Integer,
                                  nroMovimiento As Integer)
      Dim sqlCD As SqlServer.CajasDetalles = New SqlServer.CajasDetalles(da)
      sqlCD.CajaDetalles_D(idSucursal, idCaja, nroPlanilla, nroMovimiento)
   End Sub

   Public Function TieneMovimientosEnCaja(idCuentaCaja As Integer) As Boolean
      Return New SqlServer.CajasDetalles(da).TieneMovimientosEnCaja(idCuentaCaja)
   End Function
#End Region
End Class
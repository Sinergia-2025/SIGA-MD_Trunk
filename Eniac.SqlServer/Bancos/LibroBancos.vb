Public Class LibroBancos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub LibroBancos_I(idSucursal As Integer,
                            idCuentaBancaria As Integer,
                            numeroMovimiento As Integer,
                            idCuentaBanco As Integer,
                            idTipoMovimiento As String,
                            importe As Double,
                            fechaMovimiento As Date,
                            idCheque As Long?,
                            fechaAplicado As Date,
                            observacion As String,
                            conciliado As Boolean,
                            esModificable As Boolean,
                            idEjercicio As Integer?,
                            idPlanCuenta As Integer?,
                            idAsiento As Integer?,
                            idCentroCosto As Integer?,
                            generaContabilidad As Boolean,
                            idTipoComprobante As String,
                            numeroDeposito As Long?,
                            idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO LibrosBancos (")
         .AppendLine("	IdSucursal, ")
         .AppendLine("	IdCuentaBancaria, ")
         .AppendLine("	NumeroMovimiento,  ")
         .AppendLine("	IdCuentaBanco,  ")
         .AppendLine("	IdTipoMovimiento,  ")
         .AppendLine("	Importe,  ")
         .AppendLine("	FechaMovimiento,  ")
         .AppendLine("	IdCheque,  ")
         .AppendLine("	FechaAplicado,  ")
         .AppendLine("	Observacion,  ")
         .AppendLine("	Conciliado ")
         .AppendLine(" ,esModificable ")
         .AppendLine(" ,IdEjercicio")
         .AppendLine(" ,IdPlanCuenta ")
         .AppendLine(" ,IdAsiento ")
         .AppendLine(" ,IdCentroCosto ")
         .AppendLine(" ,GeneraContabilidad")
         .AppendFormatLine(" ,{0}", Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine(" ,{0}", Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())
         .AppendLine(" ,FechaActualizacionAsiento")
         .AppendLine(" ,IdConceptoCM05")
         .AppendLine(") Values ( ")
         .AppendLine(idSucursal.ToString() & ", ")
         .AppendLine(idCuentaBancaria.ToString() & ", ")
         .AppendLine(numeroMovimiento.ToString() & ", ")
         .AppendLine(idCuentaBanco.ToString() & ", ")
         .AppendLine("'" & idTipoMovimiento & "', ")
         If idTipoMovimiento = "I" Then
            .AppendLine(Math.Abs(importe).ToString() & ", ")
         Else
            .AppendLine((Math.Abs(importe) - (Math.Abs(importe) * 2)).ToString() & ", ")
         End If
         .AppendLine("'" & Me.ObtenerFecha(fechaMovimiento, True) & "',")
         If idCheque.HasValue AndAlso idCheque.Value > 0 Then
            .AppendFormatLine("{0}, ", idCheque.Value)
         Else
            .AppendLine("NULL, ")
         End If
         .AppendLine("'" & Me.ObtenerFecha(fechaAplicado, True) & "', ")
         .AppendLine("'" & observacion.ToString() & "', ")
         If conciliado Then
            .AppendLine("1 ")
         Else
            .AppendLine("0 ")
         End If
         .AppendLine(" ," + GetStringFromBoolean(esModificable))

         If idEjercicio.HasValue Then
            .AppendLine(" ," + idEjercicio.Value.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         If idPlanCuenta.HasValue Then
            .AppendLine(" ," + idPlanCuenta.Value.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         If idAsiento.HasValue Then
            .AppendLine(" ," + idAsiento.Value.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendLine(" ," + idCentroCosto.Value.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         .AppendFormatLine(" ,{0}", GetStringFromBoolean(generaContabilidad))

         '# Tipo de COmprobante y Nro de Deposito
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine(" ,'{0}'", idTipoComprobante)
         Else
            .AppendLine(" ,NULL")
         End If
         If numeroDeposito.HasValue Then
            If numeroDeposito.Value > 0 Then
               .AppendFormatLine(" ,{0}", numeroDeposito.Value)
            Else
               .AppendLine(" ,NULL")
            End If
         Else
            .AppendLine(" ,NULL")
         End If
         .AppendFormatLine(" ,GETDATE()")
         .AppendFormatLine(" ,{0}", GetStringFromNumber(idConceptoCM05))
         .AppendLine(" ) ")

      End With

      Execute(myQuery)
   End Sub

   Public Sub LibroBancos_U(idSucursal As Integer,
                            idCuentaBancaria As Integer,
                            numeroMovimiento As Integer,
                            idCuentaBanco As Integer,
                            idTipoMovimiento As String,
                            importe As Double,
                            fechaMovimiento As Date,
                            idCheque As Long?,
                            fechaAplicado As Date,
                            observacion As String,
                            conciliado As Boolean,
                            esModificable As Boolean,
                            idEjercicio As Integer?,
                            idPlanCuenta As Integer?,
                            idAsiento As Integer?,
                            idCentroCosto As Integer?,
                            generaContabilidad As Boolean,
                            idTipoComprobante As String,
                            numeroDeposito As Long?,
                            idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("	Update LibrosBancos Set ")
         .AppendLine("		IdCuentaBanco = " & idCuentaBanco.ToString() & ", ")
         .AppendLine("		IdTipoMovimiento = '" & idTipoMovimiento.ToString() & "', ")
         If idTipoMovimiento <> "I" Then
            .AppendLine("		Importe = " & (Math.Abs(importe) - (Math.Abs(importe) * 2)).ToString() & ",")
         Else
            .AppendLine("		Importe = " & Math.Abs(importe).ToString() & ",")
         End If
         .AppendLine("		FechaMovimiento = '" & Me.ObtenerFecha(fechaMovimiento, True) & "', ")

         If idCheque.HasValue Then
            .AppendFormatLine("		IdCheque = {0},", idCheque.Value)
         Else
            .AppendFormatLine("		IdCheque = NULL, ")
         End If

         .AppendLine("		FechaAplicado = '" & Me.ObtenerFecha(fechaAplicado, True) & "', ")
         .AppendLine("		Observacion = '" & observacion.ToString() & "', ")

         '# Tipo de COmprobante y Nro de Deposito
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("    {0} = '{1}',", Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If numeroDeposito.HasValue Then
            If numeroDeposito.Value > 0 Then
               .AppendFormatLine("    {0} = {1},", Entidades.LibroBanco.Columnas.NumeroDeposito.ToString(), numeroDeposito.Value)
            Else
               .AppendFormatLine("    {0} = NULL,", Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())
            End If
         End If

         If conciliado Then
            .AppendLine("		Conciliado = 1")
         Else
            .AppendLine("		Conciliado = 0")
         End If
         .AppendFormat("	,EsModificable = {0}", GetStringFromBoolean(esModificable)).AppendLine()

         If idEjercicio.HasValue Then
            .AppendFormat("	,IdEjercicio = {0}", idEjercicio.Value).AppendLine()
         Else
            .AppendLine("	,IdEjercicio = NULL")
         End If
         If idPlanCuenta.HasValue Then
            .AppendFormat("	,IdPlanCuenta = {0}", idPlanCuenta.Value).AppendLine()
         Else
            .AppendLine("	,IdPlanCuenta = NULL")
         End If
         If idAsiento.HasValue Then
            .AppendFormat("	,IdAsiento = {0}", idAsiento.Value).AppendLine()
         Else
            .AppendLine("	,IdAsiento = NULL")
         End If
         If idCentroCosto.HasValue Then
            .AppendFormat("	,IdCentroCosto = {0}", idCentroCosto.Value).AppendLine()
         Else
            .AppendLine("	,IdCentroCosto = NULL")
         End If
         .AppendFormatLine("  ,GeneraContabilidad = {0}", GetStringFromBoolean(generaContabilidad))
         .AppendFormatLine("  ,FechaActualizacionAsiento = GETDATE()")
         .AppendFormatLine("  ,IdConceptoCM05 = {0}", GetStringFromNumber(idConceptoCM05))

         .AppendLine("	Where IdSucursal = " & idSucursal.ToString())
         .AppendLine("	And IdCuentaBancaria = " & idCuentaBancaria.ToString())
         .AppendLine("	And NumeroMovimiento = " & numeroMovimiento.ToString())
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub LibroBancos_D(idSucursal As Integer, idCuentaBancaria As Integer, numeroMovimiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM LibrosBancos ")
         .AppendLine("  WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND IdCuentaBancaria = " & idCuentaBancaria.ToString())
         .AppendLine("    AND NumeroMovimiento = " & numeroMovimiento.ToString())
      End With
      Execute(myQuery)
   End Sub

   Public Function LibroBancos_G1(idSucursal As Integer, idCuentaBancaria As Integer, numeroMovimiento As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT * FROM LibrosBancos ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdCuentaBancaria = " & idCuentaBancaria.ToString())
         .AppendLine("   AND NumeroMovimiento = " & numeroMovimiento.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function LibroBancos_Existe(idSucursal As Integer, idCuentaBancaria As Integer, numeroMovimiento As Integer) As Boolean
      Dim myQuery = New StringBuilder()
      With myQuery
         .Append("SELECT * FROM LibrosBancos ")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdCuentaBancaria = {0}", idCuentaBancaria)
         .AppendFormat("   AND NumeroMovimiento = {0}", numeroMovimiento)
      End With
      Using dt = GetDataTable(myQuery)
         Return dt.Rows.Count > 0
      End Using
   End Function

   Public Sub LibroBancos_Conciliar(idSucursal As Integer, idCuentaBancaria As Integer, numeroMovimiento As Integer, conciliado As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .Append("	Update LibrosBancos ")
         If conciliado Then
            .Append("		Set Conciliado = 'True' ")
         Else
            .Append("		Set Conciliado = 'False' ")
         End If
         .Append("	Where IdSucursal = " & idSucursal.ToString())
         .Append("	And IdCuentaBancaria = " & idCuentaBancaria.ToString())
         .Append("	And NumeroMovimiento = " & numeroMovimiento.ToString())
      End With
      Execute(myQuery)
   End Sub

   Public Sub LibroBancos_Intercambiar(idSucursal As Integer, idCuentaBancaria As Integer, nuevoIdCuentaBancaria As Integer, numeroMovimiento As Integer, nuevoNumeroMovimiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .Append("UPDATE LibrosBancos ")
         .Append("   SET IdCuentaBancaria = " & nuevoIdCuentaBancaria.ToString())
         .Append("     , NumeroMovimiento = " & nuevoNumeroMovimiento.ToString())
         .Append(" WHERE IdSucursal = " & idSucursal.ToString())
         .Append("   AND IdCuentaBancaria = " & idCuentaBancaria.ToString())
         .Append("   AND NumeroMovimiento = " & numeroMovimiento.ToString())
      End With
      Execute(myQuery)
   End Sub

   Public Sub LibroBancos_DPorCheque(idCheque As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM LibrosBancos ")
         .AppendFormatLine("  WHERE IdCheque = {0}", idCheque)
      End With
      Execute(myQuery)
   End Sub
   Public Sub LibroBancos_DPorDeposito(idSucursal As Integer, numeroDeposito As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM LibrosBancos ")
         .AppendLine("  WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND NumeroDeposito = " & numeroDeposito.ToString())
      End With
      Execute(myQuery)
   End Sub
   Public Sub LibroBancos_DNroCheque(idSucursal As Integer, idBanco As Integer, idBancoSucursal As Integer, idLocalidad As Integer, numeroCheque As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM LibrosBancos ")
         .AppendLine("  WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND IdBancoChequeAnterior = " & idBanco.ToString())
         .AppendLine("    AND IdBancoSucursalChequeAnterior = " & idBancoSucursal.ToString())
         .AppendLine("    AND IdLocalidadChequeAnterior = " & idLocalidad.ToString())
         .AppendLine("    AND NumeroChequeAnterior = " & numeroCheque.ToString())
      End With
      Execute(myQuery)
   End Sub

   Public Sub LibroBancos_UImporteCheque(idCheque As Long, importe As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE LibrosBancos SET ")
         .AppendLine("   Importe = " & importe.ToString())
         .AppendFormatLine("  WHERE IdCheque = {0}", idCheque)
      End With
      Execute(myQuery)
   End Sub

   Public Sub LibroBancos_UFechaCobro(idCheque As Long, fechaCobro As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE LibrosBancos SET ")
         .AppendLine("   FechaAplicado = '" & ObtenerFecha(fechaCobro, True) & "'")
         .AppendFormatLine("  WHERE IdCheque = {0}", idCheque)
      End With
      Execute(myQuery)
   End Sub

   Public Function GetMovimientos(idSucursal As Integer, idMoneda As Integer, idCuentaBancaria As Integer,
                                  fechaDesde As Date, fechaHasta As Date,
                                  tipoFecha As Entidades.LibroBanco.TiposFechasLibrosBancos,
                                  concilidado As Entidades.Publicos.SiNoTodos,
                                  posdatado As String,
                                  idCuentaBanco As Integer,
                                  blnUnificaLibroBancos As Boolean,
                                  idGrupoCuenta As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT Lb.IdSucursal")
         .AppendLine("   	,Lb.IdCuentaBancaria")
         .AppendLine("   	,Cbs.NombreCuenta")
         .AppendLine("   	,Lb.NumeroMovimiento")
         '.AppendLine("    ,(VARCHAR,Lb.FechaMovimiento,103) FechaMovimiento")
         .AppendLine("     ,Lb.FechaMovimiento")
         .AppendLine("   	,Cb.IdCuentaBanco")
         .AppendLine("   	,Cb.NombreCuentaBanco")
         .AppendLine("     ,Cb.IdGrupoCuenta")
         .AppendLine("   	,Lb.Importe")
         .AppendLine("   	,Lb.IdTipoMovimiento")
         .AppendLine("   	,Convert(varchar,C.NumeroCheque) + ' - ' + B.NombreBanco + ' (' + L.NombreLocalidad + ' - ' + P.NombreProvincia + ' )'  DescCheque")
         .AppendLine("     ,C.FechaCobro")
         '.AppendLine("   	,CONVERT(VARCHAR,Lb.FechaAplicado,103) FechaAplicado")
         .AppendLine("   	,Lb.FechaAplicado")
         .AppendLine("   	,Case Lb.Conciliado")
         .AppendLine("   		When 1 Then 'Si' ")
         .AppendLine("   		When 0 Then 'No' ")
         .AppendLine("   	End Conciliado")
         .AppendLine("   	,Lb.Observacion")
         .AppendLine("   	,Lb.EsModificable")
         .AppendLine("     ,Lb.IdEjercicio")
         .AppendLine("   	,Lb.IdPlanCuenta")
         .AppendLine("   	,Lb.IdAsiento")
         .AppendLine("   	,Lb.IdCentroCosto")
         .AppendLine("   	,CCC.NombreCentroCosto")
         .AppendLine("     ,Lb.GeneraContabilidad")
         .AppendLine("     ,Lb.IdCheque")
         .AppendFormatLine(" ,{0}", Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine(" ,{0}", Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())
         .AppendLine("     ,Lb.FechaActualizacionAsiento")

         .AppendFormatLine("     , Lb.IdConceptoCM05")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")

         .AppendLine("   FROM LibrosBancos Lb ")
         .AppendLine("  INNER JOIN CuentasBancarias Cbs On Lb.IdCuentaBancaria = Cbs.IdCuentaBancaria")
         .AppendLine("  INNER JOIN CuentasBancos Cb On Lb.IdCuentaBanco = Cb.IdCuentaBanco ")
         .AppendLine("   LEFT JOIN Cheques C On Lb.IdCheque = C.IdCheque")
         .AppendLine("   LEFT JOIN Localidades L On C.IdLocalidad = L.IdLocalidad ")
         .AppendLine("   LEFT JOIN Bancos B On C.IdBanco = B.IdBanco ")
         .AppendLine("   LEFT JOIN Provincias P on L.IdProvincia = P.IdProvincia ")
         .AppendLine("   LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = Lb.IdCentroCosto")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = Lb.IdConceptoCM05")

         If Not blnUnificaLibroBancos Then
            .AppendLine(" WHERE Lb.IdSucursal = " & idSucursal.ToString())
         Else
            .AppendLine(" WHERE 1 = 1")
         End If

         If idMoneda > 0 Then
            .AppendLine(" AND Cbs.idMoneda = " & idMoneda.ToString())
         End If

         If Not String.IsNullOrEmpty(idGrupoCuenta) Then
            .AppendFormatLine(" AND Cb.IdGrupoCuenta = '{0}'", idGrupoCuenta)
         End If

         If idCuentaBancaria > 0 Then
            .AppendLine(" AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If

         If tipoFecha = Entidades.LibroBanco.TiposFechasLibrosBancos.FechaAplicacion Then
            .AppendFormatLine("   And LB.FechaAplicado >= '{0}' AND LB.FechaAplicado <= '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         ElseIf tipoFecha = Entidades.LibroBanco.TiposFechasLibrosBancos.FechaMovimiento Then
            .AppendFormatLine("   And LB.FechaMovimiento >= '{0}' AND LB.FechaMovimiento <= '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         Else
            .AppendFormatLine("   And LB.FechaActualizacionAsiento >= '{0}' AND LB.FechaActualizacionAsiento <= '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         End If

         If concilidado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendLine("  AND Lb.Conciliado= " & IIf(concilidado = Entidades.Publicos.SiNoTodos.SI, "1", "0").ToString())
         End If

         If posdatado = "SI" Then
            .AppendLine("   And Lb.FechaMovimiento <> Lb.FechaAplicado ")
         ElseIf posdatado = "NO" Then
            .AppendLine("   And Lb.FechaMovimiento = Lb.FechaAplicado ")
         End If

         If idCuentaBanco > 0 Then
            .AppendLine("   AND Lb.idCuentaBanco = " & idCuentaBanco.ToString())
         End If

         .AppendLine(" ORDER BY CONVERT(varchar(11), Lb.FechaAplicado, 120), CONVERT(varchar(11), Lb.FechaMovimiento, 120), Lb.NumeroMovimiento, Cbs.NombreCuenta")

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetSaldosCuentasBancarias(idSucursal As Integer, idMoneda As Integer, fechaSaldo As Date,
                                             activas As Entidades.Publicos.SiNoTodos, conSaldo As Entidades.Publicos.SiNoTodos,
                                             unificaLibrosDeBanco As Boolean, idClase As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Length = 0
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT L.IdCuentaBancaria, C.NombreCuenta, CL.NombreCuentaBancariaClase, C.IdMoneda,")
         .AppendFormatLine("               SUM(CASE WHEN C.IdMoneda = 1 THEN L.Importe ELSE 0 END) Saldo,")
         .AppendFormatLine("               SUM(CASE WHEN L.Conciliado = 'True' AND C.IdMoneda = 1 THEN L.Importe ELSE 0 END) SaldoConciliado,")
         .AppendFormatLine("               SUM(CASE WHEN C.IdMoneda = 2 THEN L.Importe ELSE 0 END) SaldoDolares,")
         .AppendFormatLine("               SUM(CASE WHEN L.Conciliado = 'True' AND C.IdMoneda = 2 THEN L.Importe ELSE 0 END) SaldoConciliadoDolares")
         .AppendFormatLine("          FROM LibrosBancos L")
         .AppendFormatLine("         INNER JOIN CuentasBancarias C ON C.IdCuentaBancaria = L.IdCuentaBancaria")
         .AppendFormatLine("         INNER JOIN CuentasBancariasClase CL ON CL.IdCuentaBancariaClase = C.IdCuentaBancariaClase")
         .AppendFormatLine("         WHERE L.FechaAplicado < '{0}'", ObtenerFecha(fechaSaldo.AddDays(1), False))     ' Fecha Tope + 1 día")
         If activas <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND C.Activo = {0}", GetStringFromBoolean(activas = Entidades.Publicos.SiNoTodos.SI))
         End If
         If idMoneda >= 0 Then
            .AppendFormatLine("           AND C.IdMoneda = {0}", idMoneda)
         End If
         If unificaLibrosDeBanco Then
            .AppendFormatLine("           AND L.IdSucursal = {0}", idSucursal)
         End If
         If idClase > 0 Then
            .AppendFormatLine("           AND C.IdCuentaBancariaClase = {0}", idClase)
         End If

         .AppendFormatLine("         GROUP BY L.IdCuentaBancaria, CL.NombreCuentaBancariaClase, C.NombreCuenta, C.IdMoneda")
         .AppendFormatLine("        ) C")
         .AppendFormatLine(" WHERE 1 = 1")
         If conSaldo = Entidades.Publicos.SiNoTodos.SI Then
            .AppendFormatLine("   AND (C.Saldo <> 0 OR C.SaldoConciliado <> 0 OR C.SaldoDolares <> 0 OR C.SaldoConciliadoDolares <> 0)")
         ElseIf conSaldo = Entidades.Publicos.SiNoTodos.NO Then
            .AppendFormatLine("   AND (C.Saldo = 0 AND C.SaldoConciliado = 0 AND C.SaldoDolares = 0 AND C.SaldoConciliadoDolares = 0)")
         End If
         .AppendFormatLine(" ORDER BY C.IdMoneda, C.NombreCuentaBancariaClase, C.NombreCuenta")

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function ResumenDeBanco(idSucursal As Integer, idCuentaBancaria As Integer, fechaDesde As Date, fechaHasta As Date, esFechaMovimiento As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT IdGrupoCuenta")
         .AppendFormatLine("   ,NombreCuentaBanco ")
         .AppendFormatLine("   ,SUM(IngresoPesos) AS IngresosPesos ")
         .AppendFormatLine("   ,SUM(EgresoPesos)  AS EgresosPesos ")
         .AppendFormatLine("   ,(SUM(IngresoPesos) + SUM(EgresoPesos)) AS TotalesPesos ")
         .AppendFormatLine("   ,SUM(IngresoDolar) AS IngresosDolar ")
         .AppendFormatLine("   ,SUM(EgresoDolar)  AS EgresosDolar ")
         .AppendFormatLine("   ,(SUM(IngresoDolar) + SUM(EgresoDolar)) AS TotalesDolar ")
         .AppendFormatLine("   FROM ")
         .AppendFormatLine("   (SELECT CB.IdGrupoCuenta, CB.NombreCuentaBanco, CB.IdCuentaBanco, ")
         .AppendFormatLine("   CASE CBS.Idmoneda ")
         .AppendFormatLine("     WHEN 1 Then ")
         .AppendFormatLine("          CASE LB.IdTipoMovimiento ")
         .AppendFormatLine("              WHEN 'I' Then SUM(LB.Importe) ")
         .AppendFormatLine("              WHEN 'E' Then 0  ")
         .AppendFormatLine("          END  ")
         .AppendFormatLine("     WHEN 2 Then 0 ")
         .AppendFormatLine("   END IngresoPesos, ")
         .AppendFormatLine("   CASE CBS.Idmoneda ")
         .AppendFormatLine("     WHEN 1 Then 0 ")
         .AppendFormatLine("     WHEN 2 Then   ")
         .AppendFormatLine("          CASE LB.IdTipoMovimiento ")
         .AppendFormatLine("              WHEN 'I' Then SUM(LB.Importe) ")
         .AppendFormatLine("              WHEN 'E' Then 0  ")
         .AppendFormatLine("          END  ")
         .AppendFormatLine("   END IngresoDolar, ")
         .AppendFormatLine("   CASE CBS.Idmoneda ")
         .AppendFormatLine("     WHEN 1 Then ")
         .AppendFormatLine("          CASE LB.IdTipoMovimiento ")
         .AppendFormatLine("              WHEN 'E' Then SUM(LB.Importe) ")
         .AppendFormatLine("              WHEN 'I' Then 0  ")
         .AppendFormatLine("          END  ")
         .AppendFormatLine("     WHEN 2 Then 0 ")
         .AppendFormatLine("   END EgresoPesos, ")
         .AppendFormatLine("   CASE CBS.Idmoneda ")
         .AppendFormatLine("     WHEN 1 Then 0 ")
         .AppendFormatLine("     WHEN 2 Then   ")
         .AppendFormatLine("          CASE LB.IdTipoMovimiento ")
         .AppendFormatLine("              WHEN 'E' Then SUM(LB.Importe) ")
         .AppendFormatLine("              WHEN 'I' Then 0  ")
         .AppendFormatLine("          END  ")
         .AppendFormatLine("   END EgresoDolar ")
         .AppendFormatLine("     FROM LibrosBancos LB ")
         .AppendFormatLine("      INNER JOIN CuentasBancos  CB ON CB.IdCuentaBanco  = LB.IdCuentaBanco")
         .AppendFormatLine("      INNER JOIN CuentasBancarias  CBS ON LB.IdCuentaBancaria  = CBS.IdCuentaBancaria")

         .AppendFormatLine("  WHERE LB.idsucursal = {0}", idSucursal)
         If idCuentaBancaria > 0 Then
            .AppendFormatLine("   AND LB.IdCuentaBancaria = {0}", idCuentaBancaria)
         End If
         If esFechaMovimiento Then
            .AppendFormatLine("   AND LB.FechaMovimiento BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         Else
            .AppendFormatLine("   AND LB.FechaAplicado   BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         End If

         .AppendFormatLine("  GROUP BY CB.IdGrupoCuenta, CB.NombreCuentaBanco , CB.IdCuentaBanco, CBS.IdMoneda, LB.IdTipoMovimiento) Detalle  ")
         .AppendFormatLine("  GROUP BY IdGrupoCuenta, NombreCuentaBanco, IdCuentaBanco   ")

      End With
      Return GetDataTable(stbQuery)
   End Function

End Class
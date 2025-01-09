Public Class SueldosLiquidacion
    Inherits Comunes

#Region "Constructores"

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Function GetResumenLiquidacion(idTipoRecibo As Integer) As DataTable


      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT a.idTipoConcepto, t.NombreTipoConcepto, a.idConcepto, c.CodigoConcepto, c.NombreConcepto, sum(Importe) AS Total")
         .AppendLine("  FROM SueldosLiquidacionActual a, SueldosConceptos c, SueldosTiposConceptos t")
         .AppendLine(" WHERE a.idTipoConcepto = t.idTipoConcepto")
         .AppendLine("   AND a.idConcepto = c.idConcepto AND a.idTipoConcepto = c.idTipoConcepto")
         .AppendLine("   AND c.idTipoConcepto = t.idTipoConcepto")
         .AppendFormat("   AND a.idTipoRecibo = {0}", idTipoRecibo)
         .AppendLine(" GROUP BY a.idTipoConcepto, t.NombreTipoConcepto, a.idConcepto, c.CodigoConcepto, c.NombreConcepto")
         .AppendLine(" ORDER BY a.idTipoConcepto, c.CodigoConcepto")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetConceptosPersona(idLegajo As Long) As DataTable


      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT a.idLegajo ")
         .AppendLine(" ,a.idTipoConcepto ")
         .AppendLine("  ,a.idConcepto ")
         .AppendLine("  ,b.NombreConcepto ")
         .AppendLine("  ,b.idQuepide ")
         .AppendLine("  ,a.Valor ")
         .AppendLine("  ,a.Aguinaldo ")
         .AppendLine("  ,a.Periodos ")
         .AppendLine("  ,t.NombreTipoConcepto ")
         .AppendLine("  ,a.CodigoConcepto")
         .AppendLine(" FROM SueldosPersonalCodigos a, SueldosConceptos b , SueldosTiposConceptos t ")
         .AppendLine(" WHERE a.idConcepto = b.idConcepto")
         .AppendLine("   AND a.idTipoConcepto = b.idTipoConcepto")
         .AppendLine("   AND a.idLegajo =" & idLegajo.ToString())
         .AppendLine("   AND a.idTipoConcepto = t.idTipoConcepto ")
         .AppendLine(" order by a.idTipoConcepto, a.CodigoConcepto")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Sub SueldosLiquidacionActual_I(idLegajo As Integer,
                                       idTipoConcepto As Integer,
                                       idConcepto As Integer,
                                       Valor As Decimal,
                                       ImporteLiquidado As Decimal,
                                       PeriodoLiquidacion As Integer,
                                       Aguinaldo As String,
                                       idTipoRecibo As Integer,
                                       periodos As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append(" SueldosLiquidacionActual  ")
         .Append(" ( idLegajo ")
         .Append(" ,idTipoConcepto ")
         .Append(" ,idConcepto ")
         .Append(" ,Valor  ")
         .Append(" ,Importe  ")
         .Append(" ,NroLiquidacion ")
         .Append(" ,Aguinaldo ")
         .Append(" ,IdTipoRecibo ")
         .Append(" ,Periodos ")

         .Append(")  VALUES (")
         .Append(idLegajo & ", ")
         .Append(idTipoConcepto & ", ")
         .Append(idConcepto & " ")
         .AppendFormat(" ,{0}", Valor)
         .AppendFormat(" ,{0}", ImporteLiquidado)
         .AppendFormat(" ,{0}", PeriodoLiquidacion)
         .Append(", '" & Aguinaldo & "'")
         .AppendFormat(", {0}", idTipoRecibo)
         .AppendFormat(", {0}", periodos)

         .Append(")")

      End With

      Me.Execute(myQuery.ToString())
      ' Me.Sincroniza_I(myQuery.ToString(), "SueldosPersonalCodigos")
   End Sub

   Public Sub SueldosCierreLiquidacion_I(idLegajo As Integer,
                                       idTipoConcepto As Integer,
                                       idConcepto As Integer,
                                       Valor As Decimal,
                                       ImporteLiquidado As Decimal,
                                       PeriodoLiquidacion As Integer,
                                       Aguinaldo As String,
                                       idTipoRecibo As Integer,
                                       NroLiquidacion As Integer,
                                       periodos As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append(" SueldosCierreLiquidacion  ")
         .Append(" ( idLegajo ")
         .Append(" ,idTipoConcepto ")
         .Append(" ,idConcepto ")
         .Append(" ,Valor  ")
         .Append(" ,Importe  ")
         .Append(" ,PeriodoLiquidacion ")
         .Append(" ,Aguinaldo ")
         .Append(" ,IdTipoRecibo ")
         .Append(" ,NroLiquidacion ")
         .Append(" ,Periodos ")
         .Append(") VALUES (")
         .Append(idLegajo & ", ")
         .Append(idTipoConcepto & ", ")
         .Append(idConcepto & " ")
         .AppendFormat(" ,{0}", Valor)
         .AppendFormat(" ,{0}", ImporteLiquidado)
         .AppendFormat(" ,{0}", PeriodoLiquidacion)
         .Append(", '" & Aguinaldo & "'")
         .Append(", '" & idTipoRecibo & "'")
         .AppendFormat(" ,{0}", NroLiquidacion)
         .AppendFormat(", {0}", periodos)
         .Append(")")

      End With

      Me.Execute(myQuery.ToString())
      ' Me.Sincroniza_I(myQuery.ToString(), "SueldosPersonalCodigos")
   End Sub

   Public Sub SueldosCierreLiqDatos_I(idLegajo As Integer,
                                      idTipoRecibo As Integer,
                                      PeriodoLiquidacion As Integer,
                                      FechaPago As Date,
                                      LugarPago As String,
                                      DomicilioEmpresa As String,
                                      IdBancoCtaBancaria As Integer,
                                      IdCuentasBancariasClaseCtaBancaria As Integer,
                                      NumeroCuentaBancaria As String,
                                      CBU As Decimal,
                                      NroLiquidacion As Integer,
                                      SueldoBasico As Decimal,
                                      idCategoria As Integer,
                                      TotalHaberesParaAguinaldo As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append(" SueldosCierreLiqDatos  ")
         .Append(" ( idLegajo ")
         .Append(" ,IdTipoRecibo ")
         .Append(" ,PeriodoLiquidacion ")
         .Append(" ,FechaPago  ")
         .Append(" ,LugarPago  ")
         .Append(" ,DomicilioEmpresa")
         .Append("           ,IdBancoCtaBancaria")
         .Append("           ,IdCuentasBancariasClaseCtaBancaria")
         .Append("           ,NumeroCuentaBancaria")
         .Append("           ,CBU")
         .Append("           ,NroLiquidacion")
         .Append("           ,SueldoBasico")
         .Append("           ,IdCategoria")
         .Append("           ,TotalHaberesParaAguinaldo")
         .Append(") VALUES (")
         .Append(idLegajo & ", ")
         .Append(idTipoRecibo & ", ")
         .Append(PeriodoLiquidacion & " ")
         .AppendFormat(" ,'{0}'", FechaPago.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat(" ,'{0}'", LugarPago)
         .Append(", '" & DomicilioEmpresa & "'")
         If IdBancoCtaBancaria = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdBancoCtaBancaria)
         End If
         If IdCuentasBancariasClaseCtaBancaria = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdCuentasBancariasClaseCtaBancaria)
         End If
         If String.IsNullOrEmpty(NumeroCuentaBancaria) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", NumeroCuentaBancaria)
         End If
         .AppendFormat("           ,{0}", CBU)
         .AppendFormat("           ,{0}", NroLiquidacion)
         .AppendFormat("           ,{0}", SueldoBasico)
         .AppendFormat("           ,{0}", idCategoria)
         .AppendFormat("           ,{0}", TotalHaberesParaAguinaldo)
         .Append(")")

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SueldosCierrePuntero_I(NroLiquidacion As Integer,
                                        MesLiquidacion As Integer,
                                        AnoLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      myQuery = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append(" SueldosCierrePuntero  ")
         .Append(" ( NroPerson ")

         .Append(" ,LiqMes ")
         .Append(" ,LiqAno )")

         .Append("  VALUES (")

         .Append(NroLiquidacion & ", ")
         .Append(MesLiquidacion & ", ")
         .Append(AnoLiquidacion & " )")


      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub InicializaAcumuladores()

      Dim myQuery As StringBuilder = New StringBuilder("")

      myQuery = New StringBuilder("")

      With myQuery
         .Append("UPDATE [SueldosPersonal]  SET ")
         .AppendLine(" [AnteriorAcumuladoAnual] = [AcumuladoAnual]")
         .AppendLine(" ,[AnteriorMejorSueldo] = [MejorSueldo] ")
         .AppendLine(" ,[AnteriorSalarioFamiliar] =[AcumuladoSalarioFamiliar]")
      End With

      Me.Execute(myQuery.ToString())

      myQuery = New StringBuilder("")

      With myQuery
         .Append("UPDATE [SueldosPersonal]  SET ")
         .AppendLine(" [AcumuladoAnual] = 0 ")
         .AppendLine(" ,[MejorSueldo] = 0 ")
         .AppendLine(" ,[AcumuladoSalarioFamiliar] = 0 ")
         .AppendLine(" ,[SueldoActual] = 0 ")
         .AppendLine(" ,[SalarioFamiliarActual] = 0 ")
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub GrabaSueldoActual(idLegajo As Integer,
                                        SueldoActual As Decimal,
                                        SalarioFamiliarActiual As Decimal)

      Dim anchoCampo As Integer = GetAnchoCampo("SueldosPersonal", "SueldoActual")
      Dim maxValue As Decimal = Decimal.Parse(New String("9"c, anchoCampo)) + 1
      If SueldoActual >= maxValue Then Throw New Exception(String.Format("SueldoActual tiene un valor mayor al máximo permitido ({0:N2}).", maxValue))

      anchoCampo = GetAnchoCampo("SueldosPersonal", "SalarioFamiliarActual")
      maxValue = Decimal.Parse(New String("9"c, anchoCampo)) + 1
      If SueldoActual >= maxValue Then Throw New Exception(String.Format("SalarioFamiliarActual tiene un valor mayor al máximo permitido ({0:N2}).", maxValue))

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosPersonal  ")
         .Append("SET  ")

         .AppendFormat(" sueldoactual={0}", SueldoActual)
         .AppendFormat(", SalarioFamiliarActual={0}", SalarioFamiliarActiual)


         .Append("WHERE ")
         .Append(" idLegajo = " & idLegajo)

      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub LimpiaSueldosLiquidacionActual(idTipoRecibo As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("DELETE  ")
         .Append("SueldosLiquidacionActual  ")
         .AppendFormat("where IdTipoRecibo = {0}", idTipoRecibo)

      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub CopiarCierreLiquidacionAPersonalCodigos(idTipoRecibo As Integer, periodo As Integer, nroLiquidacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         'Hago un MERGE con origen (O) en SueldosCierreLiquidacion (subquery) y destino SueldosPersonalCodigos (D)
         .AppendFormatLine("MERGE INTO SueldosPersonalCodigos AS D")
         .AppendFormatLine("     USING (SELECT IdLegajo,IdTipoRecibo,IdTipoConcepto,IdConcepto")
         .AppendFormatLine("                  ,Valor,Aguinaldo,Periodos FROM SueldosCierreLiquidacion")
         .AppendFormatLine("             WHERE PeriodoLiquidacion = {0}", periodo)
         .AppendFormatLine("               AND IdTipoRecibo       = {0}", idTipoRecibo)
         .AppendFormatLine("               AND NroLiquidacion     = {0}) AS O", nroLiquidacion)
         .AppendFormatLine("        ON O.IdLegajo       = D.IdLegajo")
         .AppendFormatLine("       AND O.IdTipoRecibo   = D.IdTipoRecibo")
         .AppendFormatLine("       AND O.IdTipoConcepto = D.IdTipoConcepto")
         .AppendFormatLine("       AND O.IdConcepto     = D.IdConcepto")

         'Si lo encuentra el registro en el destino, hace un UPDATE de los campos que no son PK
         .AppendLine(" WHEN MATCHED THEN")
         .AppendLine("    UPDATE")
         .AppendLine("       SET D.Valor     = O.Valor")
         .AppendLine("          ,D.Aguinaldo = O.Aguinaldo")
         .AppendLine("          ,D.Periodos  = O.Periodos")

         'Si no lo encuentra en el destino, hace un INSERT de todo el registro
         .AppendLine(" WHEN NOT MATCHED THEN")
         .AppendLine("    INSERT(  IdLegajo,   IdTipoRecibo,   IdTipoConcepto,   IdConcepto,   Valor,   Aguinaldo,   Periodos)")
         .AppendLine("    VALUES(O.IdLegajo, O.IdTipoRecibo, O.IdTipoConcepto, O.IdConcepto, O.Valor, O.Aguinaldo, O.Periodos)")

         'Si el registro no está más en el origen, lo borro del destino
         .AppendFormat(" WHEN NOT MATCHED BY SOURCE AND D.IdTipoRecibo = {0} THEN", idTipoRecibo).AppendLine()
         .AppendLine("    DELETE;")

      End With

      Execute(myQuery)
   End Sub

   Public Sub EliminaSueldosCierreLiquidacion(idTipoRecibo As Integer,
                                              periodoLiquidacion As Integer,
                                              nroLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("delete SueldosCierreLiquidacion  ")
         .AppendFormat(" where IdTipoRecibo = {0} and PeriodoLiquidacion = {1} and NroLiquidacion = {2}", idTipoRecibo, periodoLiquidacion, nroLiquidacion)
      End With

      Me.Execute(myQuery.ToString())

   End Sub


   Public Function UltimoPeriodoLuegoReabrir(idTipoRecibo As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT TOP 1 SCL.PeriodoLiquidacion, SCL.NroLiquidacion")
         .AppendFormatLine("     , (SELECT COUNT(1) CantidadLiquidPeriodo")
         .AppendFormatLine("          FROM (SELECT SCL2.IdTipoRecibo, SCL2.PeriodoLiquidacion, SCL2.NroLiquidacion")
         .AppendFormatLine("                  FROM SueldosCierreLiquidacion SCL2")
         .AppendFormatLine("                 WHERE SCL2.IdTipoRecibo = {0}", idTipoRecibo)
         .AppendFormatLine("                 GROUP BY SCL2.IdTipoRecibo, SCL2.PeriodoLiquidacion, SCL2.NroLiquidacion) SCL3")
         .AppendFormatLine("         WHERE SCL3.IdTipoRecibo        = SCL.IdTipoRecibo")
         .AppendFormatLine("           AND SCL3.PeriodoLiquidacion  = SCL.PeriodoLiquidacion) AS CantidadLiquidPeriodo")
         .AppendFormatLine("  FROM SueldosCierreLiquidacion SCL")
         .AppendFormatLine(" WHERE SCL.IdTipoRecibo = {0}", idTipoRecibo)
         .AppendFormatLine(" ORDER BY SCL.NroLiquidacion DESC")
         .AppendFormatLine("")
      End With

      Return GetDataTable(myQuery)
   End Function


   Public Sub EliminaSueldosCierreLiqDatos(idTipoRecibo As Integer,
                                            periodoLiquidacion As Integer,
                                            nroLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("delete SueldosCierreLiqDatos  ")
         .AppendFormat(" where IdTipoRecibo = {0} and PeriodoLiquidacion = {1} and NroLiquidacion = {2}", idTipoRecibo, periodoLiquidacion, nroLiquidacion)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub SueldosPersonalCodigos_D(idLegajo As Integer, idTipoConcepto As Integer, idConcepto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append(" SueldosPersonalCodigos  ")

         .Append(" WHERE  ")

         .Append(" idLegajo = " & idLegajo)

         .Append(" idTipoConcepto = " & idTipoConcepto)
         .Append(" and idConcepto = " & idConcepto)

      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub SueldosPersonalCodigos_D(idLegajo As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append(" SueldosPersonalCodigos  ")

         .Append(" WHERE  ")

         .Append(" idLegajo = " & idLegajo)


      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Function SueldosLiquidacionActual_GA(IdTipoRecibo As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery


         .AppendLine(" SELECT SLA.[idLegajo]")
         .AppendLine("       ,SLA.[idTipoConcepto]")
         .AppendLine("       ,SLA.[idConcepto]")
         .AppendLine("       ,SLA.[Valor]")
         .AppendLine("       ,SLA.[Aguinaldo]")
         .AppendLine("       ,SLA.[Importe]")
         .AppendLine("       ,SLA.[NroLiquidacion]")
         .AppendLine("       ,SLA.[IdTipoRecibo]")
         .AppendLine("       ,SC.[EsContempladoAguinaldo]")
         .AppendLine("       ,SLA.[Periodos]")
         .AppendLine("   FROM SueldosLiquidacionActual SLA")
         .AppendLine("   INNER JOIN SueldosConceptos SC on SLA.IdTipoConcepto = SC.IdTipoConcepto ")
         .AppendLine("     AND SLA.IdConcepto = SC.IdConcepto ")
         .AppendLine("   WHERE IdTipoRecibo = " & IdTipoRecibo)
         .AppendLine("   ORDER BY idLegajo")


      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SueldosLiquidacionActPersonal(IdTipoRecibo As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery


         .AppendLine("  SELECT distinct SL.idLegajo")
         .AppendLine("  ,SL.NroLiquidacion")
         .AppendLine("  ,SL.IdTipoRecibo")
         .AppendLine("  ,SP.IdBancoCtaBancaria")
         .AppendLine("  ,SP.IdCuentasBancariasClaseCtaBancaria")
         .AppendLine("  ,SP.NumeroCuentaBancaria")
         .AppendLine("  ,SP.CBU")
         .AppendLine("  ,SP.SueldoBasico")
         .AppendLine("  ,SP.IdCategoria")
         .AppendLine("  FROM SueldosLiquidacionActual  SL")
         .AppendLine("  inner join SueldosPersonal SP on SP.idLegajo = SL.idLegajo")
         .AppendLine("   WHERE IdTipoRecibo = " & IdTipoRecibo)

      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SueldosLiquidacionActualTotales() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine(" SELECT IdLegajo")
         .AppendLine("       ,IdTipoConcepto")
         .AppendLine("       ,sum(Importe) as Total")
         .AppendLine("   FROM SueldosLiquidacionActual")
         .AppendLine("   GROUP BY IdLegajo, IdTipoConcepto ")
         .AppendLine("   ORDER BY IdLegajo")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SueldosCierreLiquidacionTotales() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine(" SELECT IdLegajo")
         .AppendLine("       ,IdTipoConcepto")
         .AppendLine("       ,sum(Importe) as Total")
         .AppendLine("   FROM SueldosCierreLiquidacion")
         .AppendLine("   GROUP BY IdLegajo, IdTipoConcepto ")
         .AppendLine("   ORDER BY IdLegajo")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetAcumuladoAnual(idLegajo As Integer, ano As Integer) As Decimal
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine(" select idlegajo, IdTipoRecibo, sum(importe) Acumulado ")
         .AppendLine(" from SueldosCierreLiquidacion ")
         .AppendFormat(" where  substring(str(PeriodoLiquidacion,6),0,5) = '{0}'", ano)
         .AppendFormat(" and IdLegajo = {0}", idLegajo)
         .AppendLine(" and idtipoconcepto = 1 ")
         .AppendLine("   group by IdLegajo, IdTipoRecibo ")
      End With
      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count > 0 Then
         If Decimal.Parse(dt.Rows(0)("Acumulado").ToString()) <> 0 Then
            Return Decimal.Parse(dt.Rows(0)("Acumulado").ToString())
         End If
      End If
      Return 0
   End Function

   Public Function GetMejorSueldo(idLegajo As Integer, ano As Integer) As Decimal
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine(" select idlegajo, IdTipoRecibo, max(importe) Mejor ")
         .AppendLine(" from SueldosCierreLiquidacion ")
         .AppendFormat(" where  substring(str(PeriodoLiquidacion,6),0,5) = '{0}'", ano)
         .AppendFormat(" and IdLegajo = {0}", idLegajo)
         .AppendLine(" and idtipoconcepto = 1 ")
         .AppendLine("   group by IdLegajo, IdTipoRecibo ")
      End With
      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count > 0 Then
         If Decimal.Parse(dt.Rows(0)("Mejor").ToString()) <> 0 Then
            Return Decimal.Parse(dt.Rows(0)("Mejor").ToString())
         End If
      End If
      Return 0
   End Function

   Public Function SueldosLiquidacionEliminaConceptosLiquidacioPorUnicaVez(idTipoRecibo As Integer) As Boolean
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append(" SELECT *   FROM [SueldosPersonalCodigos] a, SueldosConceptos b where b.Tipo='U' AND A.idConcepto =b.IDCONCEPTO")
         .AppendFormat(" and a.IdTipoRecibo = {0}", idTipoRecibo)
      End With
      Dim Tabla As DataTable = Me.GetDataTable(myQuery.ToString())

      Dim Sql As String
      Dim Periodo As Integer

      For Each Linea As DataRow In Tabla.Rows
         Periodo = Integer.Parse(Linea.Item("periodos").ToString)
         Periodo -= 1

         If Periodo = 0 Then
            Sql = "delete SueldosPersonalCodigos  where idlegajo=" & Linea.Item("idlegajo").ToString()
            Sql &= " and idconcepto=" & Linea.Item("idconcepto").ToString()
            Sql &= " and IdTipoRecibo=" & idTipoRecibo.ToString()
         Else
            Sql = "update SueldosPersonalCodigos set periodos=" & Periodo & " where idlegajo=" & Linea.Item("idlegajo").ToString
            Sql &= " and idconcepto=" & Linea.Item("idconcepto").ToString()
            Sql &= " and IdTipoRecibo=" & idTipoRecibo.ToString()
         End If

         Me.Execute(Sql)
      Next

      Return True
      'TODO ESTEBAN COMPLETAR ACA

   End Function

   Public Function GetTodosLosPeriodosLiquidacion() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("SELECT DISTINCT	PeriodoLiquidacion ")
         .Append(" FROM SueldosCierreLiquidacion ")
         .Append(" ORDER BY PeriodoLiquidacion desc ")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTodosNroLiquidacion(IdTipoRecibo As Integer?, PeriodoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("SELECT DISTINCT	NroLiquidacion ")
         .Append(" FROM SueldosCierreLiquidacion ")
         .AppendLine(" WHERE PeriodoLiquidacion = " & PeriodoLiquidacion)
         If IdTipoRecibo.HasValue Then
            .AppendLine("  AND IdTipoRecibo = " & IdTipoRecibo.Value)
         End If
         .Append(" ORDER BY NroLiquidacion asc ")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetLugarDePagoyFecha(IdTipoRecibo As Integer?, PeriodoLiquidacion As Integer,
                                         nroLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("SELECT TOP 1 LugarPago, FechaPago FROM SueldosCierreLiqDatos ")
         .AppendLine(" WHERE PeriodoLiquidacion = " & PeriodoLiquidacion)
         If IdTipoRecibo.HasValue Then
            .AppendLine("  AND IdTipoRecibo = " & IdTipoRecibo.Value)
            .AppendLine("  AND NroLiquidacion = " & nroLiquidacion)
         End If
         .Append(" ORDER BY NroLiquidacion asc ")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("select ")
         .Append(" max(idConcepto) as maximo ")
         .Append(" from  SueldosPersonalCodigos")
      End With

      'Para el Importador de Productos (Airoldi y Generico)
      'Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function SueldosPersonalCodigos_G1(idTipoConcepto As Integer, idConcepto As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("  r.idConcepto ")
         .Append(" , r.idTipoConcepto ")
         .Append(" , r.NombreConcepto ")
         .Append(" , l.NombreTipoConcepto ")
         .AppendLine(", Q.NombreQuePiede")
         .Append(" ,[Valor] ")
         .Append(" ,[Tipo] ")
         .Append(" ,[Aguinaldo] ")
         .Append(" ,[idQuepide] ")
         .Append(" ,[Calculo1] ")
         .Append(" ,[Formula] ")
         .Append(" ,[LiquidacionAnual] ")
         .Append(" ,[LiquidacionMeses] ")
         .Append(" FROM SueldosPersonalCodigos r ")
         .AppendLine(" LEFT JOIN SueldosTiposConceptos L ON L.IdTipoCOncepto = R.IdTipoConcepto ")
         .AppendLine(" LEFT JOIN SueldosQuePideConcepto Q ON Q.idQuePide = R.idQuepide ")
         .Append(" WHERE r.idTipoConcepto = " & idTipoConcepto)
         .Append(" and idConcepto = " & idConcepto)
         .Append(" ORDER BY idTipoConcepto ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetDetalleRecibo(idLegajo As Integer,
                                    nroLiquidacion As Integer?,
                                    idTipoRecibo As Integer?,
                                    PeriodoLiquidacion As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT SCL.idLegajo")
         .AppendLine("      ,SS.CodigoConcepto")
         .AppendLine("      ,SP.NombrePersonal")
         .AppendLine("      ,SCL.idConcepto")
         .AppendLine("      ,SS.NombreConcepto")
         .AppendLine("      ,SCL.idTipoConcepto")
         .AppendLine("      ,SCL.Valor")
         .AppendLine("      ,SCL.Importe")
         .AppendLine("      ,SCL.NroLiquidacion")
         .AppendLine("      ,SCL.Aguinaldo")
         .AppendLine("      ,SCL.IdTipoRecibo")
         .AppendLine("      ,SS.MostrarEnRecibo")
         .AppendLine(" FROM SueldosCierreLiquidacion SCL")
         .AppendLine(" LEFT JOIN SueldosPersonal SP ON SP.idLegajo = SCL.idLegajo")
         .AppendLine(" LEFT JOIN SueldosConceptos SS ON SS.idConcepto = SCL.idConcepto")
         .AppendLine(" LEFT JOIN SueldosTiposConceptos ST ON ST.idTipoConcepto = SS.idTipoConcepto")
         .AppendFormat(" WHERE SCL.PeriodoLiquidacion = {0}", PeriodoLiquidacion).AppendLine()
         If idTipoRecibo.HasValue Then
            .AppendFormat(" AND SCL.IdTipoRecibo = {0}", idTipoRecibo.Value).AppendLine()
         End If
         If nroLiquidacion.HasValue Then
            .AppendFormat(" AND SCL.NroLiquidacion = {0}", nroLiquidacion.Value).AppendLine()
         End If
         If idLegajo <> 0 Then
            .AppendFormat(" AND SCL.idLegajo = {0}", idLegajo).AppendLine()
         End If
         .Append(" ORDER BY SCL.idLegajo, ST.Orden, SS.idTipoConcepto, SS.CodigoConcepto")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetDetalleReciboxPeriodos(idLegajo As Integer,
                                 nroLiquidacion As Integer?,
                                 idTipoRecibo As Integer?,
                                 PeriodoLiquidacionDesde As Integer,
                                  PeriodoLiquidacionHasta As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT SCL.idLegajo")
         .AppendLine("      ,SS.CodigoConcepto")
         .AppendLine("      ,SP.NombrePersonal")
         .AppendLine("      ,SCL.idConcepto")
         .AppendLine("      ,SS.NombreConcepto")
         .AppendLine("      ,SCL.idTipoConcepto")
         .AppendLine("      ,SCL.Valor")
         .AppendLine("      ,SCL.Importe")
         .AppendLine("      ,SCL.NroLiquidacion")
         .AppendLine("      ,SCL.Aguinaldo")
         .AppendLine("      ,SCL.IdTipoRecibo")
         .AppendLine("      ,SCL.PeriodoLiquidacion")
         .AppendLine(" FROM SueldosCierreLiquidacion SCL")
         .AppendLine(" LEFT JOIN SueldosPersonal SP ON SP.idLegajo = SCL.idLegajo")
         .AppendLine(" LEFT JOIN SueldosConceptos SS ON SS.idConcepto = SCL.idConcepto")
         .AppendFormat(" WHERE SCL.PeriodoLiquidacion >= {0}", PeriodoLiquidacionDesde).AppendLine()
         .AppendFormat(" AND SCL.PeriodoLiquidacion <= {0}", PeriodoLiquidacionHasta).AppendLine()
         If idTipoRecibo.HasValue Then
            .AppendFormat(" AND SCL.IdTipoRecibo = {0}", idTipoRecibo.Value).AppendLine()
         End If
         If nroLiquidacion.HasValue Then
            .AppendFormat(" AND SCL.NroLiquidacion = {0}", nroLiquidacion.Value).AppendLine()
         End If
         If idLegajo <> 0 Then
            .AppendFormat(" AND SCL.idLegajo = {0}", idLegajo).AppendLine()
         End If
         .Append(" ORDER BY SCL.idLegajo, SS.CodigoConcepto")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function SueldosCierreLiqDatos_G1(IdPersonal As Integer,
                                            idTipoRecibo As Integer?,
                                            NroLiquidacion As Integer?,
                                            PeriodoLiquidacion As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT SD.idLegajo")
         .AppendLine("  ,SD.IdTipoRecibo")
         .AppendLine("  ,SD.PeriodoLiquidacion")
         .AppendLine("  ,SD.FechaPago")
         .AppendLine("  ,SD.LugarPago")
         .AppendLine("  ,SD.DomicilioEmpresa")
         .AppendLine("  ,SD.IdBancoCtaBancaria")
         .AppendLine("  ,B.NombreBanco")
         .AppendLine("  ,SD.IdCuentasBancariasClaseCtaBancaria")
         .AppendLine("  ,BC.NombreCuentaBancariaClase")
         .AppendLine("  ,SD.NumeroCuentaBancaria")
         .AppendLine("  ,SD.CBU")
         .AppendLine("  ,SD.NroLiquidacion")
         .AppendLine("  ,SD.SueldoBasico")
         .AppendLine("  ,SD.IdCategoria")
         .AppendLine("  FROM SueldosCierreLiqDatos SD")
         .AppendLine("  LEFT JOIN Bancos B ON B.IdBanco = SD.IdBancoCtaBancaria")
         .AppendLine("  LEFT JOIN CuentasBancariasClase BC ON BC.IdCuentaBancariaClase = SD.IdCuentasBancariasClaseCtaBancaria")
         .AppendLine(" WHERE SD.idLegajo = " & IdPersonal)
         If idTipoRecibo.HasValue Then
            .AppendLine(" AND SD.IdTipoRecibo = " & idTipoRecibo.Value)
         End If
         .AppendLine(" AND SD.PeriodoLiquidacion = " & PeriodoLiquidacion)
         If NroLiquidacion.HasValue Then
            .AppendLine(" AND SD.NroLiquidacion = " & NroLiquidacion.Value)
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SueldosCierreLiqDatos_GetxPeriodos(IdPersonal As Integer,
                                              idTipoRecibo As Integer?,
                                              NroLiquidacion As Integer?,
                                              PeriodoLiquidacionDesde As Integer,
                                              PeriodoLiquidacionHasta As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT SD.idLegajo")
         .AppendLine("  ,SD.IdTipoRecibo")
         .AppendLine("  ,SD.PeriodoLiquidacion")
         .AppendLine("  ,SD.FechaPago")
         .AppendLine("  ,SD.LugarPago")
         .AppendLine("  ,SD.DomicilioEmpresa")
         .AppendLine("  ,SD.IdBancoCtaBancaria")
         .AppendLine("  ,B.NombreBanco")
         .AppendLine("  ,SD.IdCuentasBancariasClaseCtaBancaria")
         .AppendLine("  ,BC.NombreCuentaBancariaClase")
         .AppendLine("  ,SD.NumeroCuentaBancaria")
         .AppendLine("  ,SD.CBU")
         .AppendLine("  ,SD.NroLiquidacion")
         .AppendLine("  ,SD.SueldoBasico")
         .AppendLine("  ,SD.IdCategoria")
         .AppendLine("  FROM SueldosCierreLiqDatos SD")
         .AppendLine("  LEFT JOIN Bancos B ON B.IdBanco = SD.IdBancoCtaBancaria")
         .AppendLine("  LEFT JOIN CuentasBancariasClase BC ON BC.IdCuentaBancariaClase = SD.IdCuentasBancariasClaseCtaBancaria")
         .AppendLine(" WHERE SD.idLegajo = " & IdPersonal)
         If idTipoRecibo.HasValue Then
            .AppendLine(" AND SD.IdTipoRecibo = " & idTipoRecibo.Value)
         End If
         .AppendLine(" AND SD.PeriodoLiquidacion >= " & PeriodoLiquidacionDesde)
         .AppendLine(" AND SD.PeriodoLiquidacion <= " & PeriodoLiquidacionHasta)
         If NroLiquidacion.HasValue Then
            .AppendLine(" AND SD.NroLiquidacion = " & NroLiquidacion.Value)
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Sub ActualizarLugarDePagoyFecha(LugarPago As String,
                                          FechaPago As Date,
                                          idTipoRecibo As Integer,
                                           periodoLiquidacion As Integer,
                                           nroLiquidacion As Integer,
                                           idLegajo As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("UPDATE SueldosCierreLiqDatos SET ")
         .AppendFormat(" LugarPago = '{0}'", LugarPago)
         .AppendFormat(" ,FechaPago = '{0}'", FechaPago)
         .AppendFormat(" where IdTipoRecibo = {0} and PeriodoLiquidacion = {1} and NroLiquidacion = {2} ", idTipoRecibo, periodoLiquidacion, nroLiquidacion)
         If idLegajo <> 0 Then
            .AppendFormat(" and IdLegajo = {0}", idLegajo)
         End If
      End With

      Me.Execute(myQuery.ToString())

   End Sub
End Class

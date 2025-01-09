Imports System.Text

Public Class SueldosPersonalCodigos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetConceptosPersona(ByVal idLegajo As Long, ByVal idTipoRecibo As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT a.idLegajo ")
         .AppendLine("      ,a.idConcepto ")
         .AppendLine("      ,b.CodigoConcepto")
         .AppendLine("      ,b.NombreConcepto ")
         .AppendLine("      ,a.idTipoConcepto ")
         .AppendLine("      ,t.NombreTipoConcepto ")
         .AppendLine("      ,b.idQuepide ")
         .AppendLine("      ,q.NombreQuepide ")
         .AppendLine("      ,b.Formula ")
         .AppendLine("      ,b.Valor as ConceptoValor ")
         .AppendLine("      ,a.Valor ")
         .AppendLine("      ,a.Aguinaldo ")
         .AppendLine("      ,a.Periodos ")
         .AppendLine("      ,a.idTipoRecibo ")
         .AppendLine("      ,R.NombreTipoRecibo ")
         .AppendLine("      ,b.EsContempladoAguinaldo ")
         .AppendLine(" FROM SueldosPersonalCodigos a, SueldosConceptos b , SueldosTiposConceptos t, SueldosQuePideConcepto Q, SueldosTiposRecibos R ")
         .AppendLine("  WHERE a.idConcepto = b.idConcepto ")
         .AppendLine("    AND a.idTipoConcepto = b.idTipoConcepto ")
         .AppendLine("    AND a.idTipoConcepto = t.idTipoConcepto ")
         .AppendLine("   and a.IdTipoRecibo = R.IdTipoRecibo ")
         .AppendLine("    AND b.idQuePide = q.idQuePide ")
         .AppendLine("    AND a.idLegajo = " & idLegajo.ToString())
         .AppendLine("    AND a.IdTipoRecibo = " & idTipoRecibo.ToString())
         .AppendLine(" ORDER BY t.Orden, a.idTipoConcepto, b.CodigoConcepto")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetConceptosPersonas(ByVal idLegajos As List(Of Integer)) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT a.idLegajo ")
         .AppendLine("      ,a.idConcepto ")
         .AppendLine("      ,b.NombreConcepto ")
         .AppendLine("      ,a.idTipoConcepto ")
         .AppendLine("      ,t.NombreTipoConcepto ")
         .AppendLine("      ,b.idQuepide ")
         .AppendLine("      ,q.NombreQuepide ")
         .AppendLine("      ,b.Formula ")
         .AppendLine("      ,b.Valor as ConceptoValor ")
         .AppendLine("      ,a.Valor ")
         .AppendLine("      ,a.Aguinaldo ")
         .AppendLine("      ,a.Periodos ")
         .AppendLine("      ,a.IdTipoRecibo")
         .AppendLine("      ,a.Aguinaldo ")
         .AppendLine("      ,STR.NombreTipoRecibo ")
         .AppendLine("      ,b.CodigoConcepto ")
         .AppendLine(" FROM SueldosPersonalCodigos a, SueldosConceptos b , SueldosTiposConceptos t, SueldosQuePideConcepto Q, SueldosTiposRecibos STR ")
         .AppendLine("  WHERE a.idConcepto = b.idConcepto ")
         .AppendLine("    AND a.idTipoConcepto = b.idTipoConcepto ")
         .AppendLine("    AND a.idTipoRecibo = STR.IdTipoRecibo ")
         .AppendLine("    AND a.idTipoConcepto = t.idTipoConcepto ")
         .AppendLine("    AND b.idQuePide = q.idQuePide ")
         If idLegajos.Count > 0 Then
            .AppendLine("    AND a.idLegajo IN (")
            For Each i As Integer In idLegajos
               .AppendFormat("{0},", i)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
         Else
            .AppendLine("    AND a.idLegajo = 0 ")
         End If
         .AppendLine(" ORDER BY a.idTipoConcepto, b.CodigoConcepto")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetMejorSueldo(ByVal IdLegajo As Integer, ByVal PeriodoInicial As Integer, ByVal PeriodoFinal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(SCLD.TotalHaberesParaAguinaldo) as MejorSueldo")
         .AppendLine(" FROM SueldosCierreLiqDatos SCLD")
         .AppendLine("  WHERE SCLD.PeriodoLiquidacion BETWEEN " & PeriodoInicial.ToString() & " AND " & PeriodoFinal.ToString())
         .AppendLine("  AND SCLD.IdLegajo = " & IdLegajo.ToString())
         .AppendLine("  GROUP BY SCLD.IdLegajo")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub SueldosPersonalCodigos_I(ByVal idLegajo As Integer, _
                                       ByVal idTipoConcepto As Integer, _
                                       ByVal idConcepto As Integer, _
                                       ByVal Valor As Decimal, _
                                       ByVal Periodos As Integer, _
                                       ByVal Aguinaldo As String, _
                                       ByVal idTipoRecibo As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append(" SueldosPersonalCodigos  ")
         .Append(" ( idLegajo ")
         .Append(" ,idTipoConcepto ")
         .Append(" ,idConcepto ")
         .Append(" ,Valor  ")
         .Append(" ,Periodos ")
         .Append(" ,Aguinaldo ")
         .Append(" ,IdTipoRecibo ")
         .Append(")")

         .Append("  VALUES (")
         .Append(idLegajo & ", ")
         .Append(idTipoConcepto & ", ")
         .Append(idConcepto & " ")
         .AppendFormat(" ,{0}", Valor)
         .AppendFormat(" ,{0}", Periodos)
         .Append(", '" & Aguinaldo & "'")
         .AppendFormat(", {0}", idTipoRecibo)

         .Append(")")

      End With

      Me.Execute(myQuery.ToString())
      ' Me.Sincroniza_I(myQuery.ToString(), "SueldosPersonalCodigos")
   End Sub

   Public Sub SueldosPersonalCodigos_UValor(ByVal idConcepto As Integer,
                                       ByVal idTipoConcepto As Integer, _
                                        ByVal Valor As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosPersonalCodigos  ")
         .Append("SET  ")
         .Append("Valor = " & Valor & "")
         .Append(" WHERE ")
         .Append(" idTipoConcepto = " & idTipoConcepto)
         .Append(" and idConcepto = " & idConcepto)


      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub SueldosPersonalCodigos_U(ByVal idLegajo As Integer, _
                                       ByVal idTipoConcepto As Integer, _
                                       ByVal idConcepto As Integer, _
                            ByVal Valor As Decimal, _
                                        ByVal Periodo As Integer, _
                            ByVal Aguinaldo As String)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosPersonalCodigos  ")
         .Append("SET  ")
         .Append("Aguinaldo = '" & Aguinaldo & "' ")
         .Append("WHERE ")
         .Append(" idLegajo = " & idLegajo)
         .Append(" and idTipoConcepto = " & idTipoConcepto)
         .Append(" and idConcepto = " & idConcepto)


      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub SueldosPersonalCodigos_D(ByVal idLegajo As Integer, _
                                       ByVal idTipoConcepto As Integer, _
                                       ByVal idConcepto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append(" SueldosPersonalCodigos  ")

         .Append(" WHERE  ")

         .AppendFormat(" idLegajo = {0}", idLegajo)

         .AppendFormat(" and idTipoConcepto = {0}", idTipoConcepto)
         .AppendFormat(" and idConcepto = {0}", idConcepto)

      End With

      Me.Execute(myQuery.ToString())

   End Sub


   Public Sub SueldosPersonalCodigos_DPorTipoRecibo(ByVal idLegajo As Integer, _
                                       ByVal idTipoRecibo As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append(" SueldosPersonalCodigos  ")

         .Append(" WHERE  ")

         If idLegajo > 0 Then
            .AppendFormat(" idLegajo = {0}", idLegajo)
         End If
         If idTipoRecibo <> 0 Then
            .AppendFormat(" AND IdTipoRecibo = {0}", idTipoRecibo)
         End If

      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Function SueldosPersonalCodigos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery


         .AppendLine(" SELECT [idLegajo]")
         .AppendLine("       ,[idTipoConcepto]")
         .AppendLine("       ,[idConcepto]")
         .AppendLine("       ,[Valor]")
         .AppendLine("       ,[Aguinaldo]")
         .AppendLine("       ,[Periodos]")
         .AppendLine("   FROM [SueldosPersonalCodigos]")


      End With

      Return Me.GetDataTable(myQuery.ToString())
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

   Public Function SueldosPersonalCodigos_G1(ByVal idLegajo As Integer, _
                                             ByVal idTipoConcepto As Integer, _
                                             ByVal idConcepto As Integer, _
                                             ByVal idTipoRecibo As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT spc.idLegajo")
         .Append("      ,spc.idTipoConcepto")
         .Append("      ,spc.idConcepto")
         .Append("      ,spc.Valor")
         .Append("      ,spc.Aguinaldo")
         .Append("      ,spc.Periodos")
         .Append("      ,spc.IdTipoRecibo")
         .Append("  FROM SueldosPersonalCodigos spc")
         .AppendFormat("  WHERE spc.IdLegajo = {0}", idLegajo)
         .AppendFormat("  AND spc.idTipoConcepto = {0}", idTipoConcepto)
         .AppendFormat("  AND spc.idConcepto = {0}", idConcepto)
         .AppendFormat("  AND spc.IdTipoRecibo = {0}", idTipoRecibo)
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
End Class

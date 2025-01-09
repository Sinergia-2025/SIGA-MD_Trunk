Public Class SueldosConceptos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosConceptos_I(ByVal idConcepto As Integer, _
                                 ByVal NombreConcepto As String, _
                                 ByVal idTipoConcepto As Integer, _
                                 ByVal Valor As Decimal, _
                                 ByVal Tipo As String, _
                                 ByVal idQuePide As Integer, _
                                 ByVal Formula As String, _
                                 ByVal EsContempladoAguinaldo As Boolean, _
                                 ByVal Aguinaldo As String, _
                                 ByVal LiquidacionAnual As Boolean, _
                                 ByVal LiquidacionMeses As String, _
                                 ByVal CodigoConcepto As Integer, _
                                 ByVal MostrarEnRecibo As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append(" SueldosConceptos  ")
         .Append(" (idTipoConcepto ")
         .Append(" ,idConcepto ")
         .Append(" ,Tipo ")
         .Append(" ,NombreConcepto ")
         .Append(" ,Valor  ")
         .Append(" ,idQuepide ")
         '  .Append(" ,Calculo1 ")
         .Append(" ,Formula ")
         .Append(" ,EsContempladoAguinaldo ")
         .Append(" ,Aguinaldo ")
         .Append(" ,LiquidacionAnual ")
         .Append(" ,LiquidacionMeses ")
         .Append(" ,CodigoConcepto")
         .Append(" ,MostrarEnRecibo)")
         .Append("  VALUES (")
         .Append(idTipoConcepto.ToString() & ", ")
         .Append(idConcepto.ToString() & ", ")
         .Append("'" & Tipo & "' ")
         .Append(",'" & NombreConcepto & "' ")
         .AppendFormat(" ,{0}", Valor)
         .AppendFormat(" ,{0}", idQuePide)
         '     .Append(", '" & Calculo & "'")
         .Append(", '" & Formula & "'")
         .Append(", " & GetStringFromBoolean(EsContempladoAguinaldo))
         .Append(", '" & Aguinaldo & "'")
         .AppendFormat(" ,'{0}'", LiquidacionAnual.ToString())
         If LiquidacionMeses IsNot Nothing Then
            .Append(", '" & LiquidacionMeses.ToString() & "'")
         Else
            .Append(", ''")
         End If
         .Append("," & CodigoConcepto)
         .AppendFormat(" ,'{0}'", MostrarEnRecibo.ToString())
         .Append(")")

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosConceptos")

   End Sub

   Public Sub SueldosConceptos_U(ByVal idConcepto As Integer, _
                                 ByVal NombreConcepto As String, _
                                 ByVal idTipoConcepto As Integer, _
                                 ByVal Valor As Decimal, _
                                 ByVal Tipo As String, _
                                 ByVal idQuePide As Integer, _
                                 ByVal Formula As String, _
                                 ByVal EsContempladoAguinaldo As Boolean, _
                                 ByVal Aguinaldo As String, _
                                 ByVal LiquidacionAnual As Boolean, _
                                 ByVal LiquidacionMeses As String, _
                                 ByVal CodigoConcepto As Integer, _
                                 ByVal MostrarEnRecibo As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE SueldosConceptos SET ")
         .AppendLine("       NombreConcepto = '" & NombreConcepto & "'")
         .AppendLine("      ,idTipoConcepto = " & idTipoConcepto.ToString())
         .AppendLine("      ,Valor = " & Valor.ToString())
         .AppendLine("      ,Tipo = '" & Tipo & "'")
         .AppendLine("      ,IdQuePide = " & idQuePide.ToString())
         ' .AppendLine(", Calculo1 = '" & Calculo & "' ")
         .AppendLine("      ,Formula = '" & Formula & "' ")
         .AppendLine("      ,EsContempladoAguinaldo = " & GetStringFromBoolean(EsContempladoAguinaldo))
         .AppendLine("      ,Aguinaldo = '" & Aguinaldo & "'")
         .AppendLine("      ,LiquidacionAnual = '" & LiquidacionAnual.ToString() & "'")
         'POR AHORA NO ... hacer en pantalla
         .AppendLine("      ,LiquidacionMeses = '" & LiquidacionMeses & "'")
         .AppendLine("      ,CodigoConcepto = " & CodigoConcepto)
         .AppendLine("      ,MostrarEnRecibo = '" & MostrarEnRecibo.ToString() & "'")
         .AppendLine("   WHERE idConcepto = " & idConcepto.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosConceptos")

   End Sub

   Public Sub SueldosConceptos_D(ByVal idConcepto As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM SueldosConceptos")
         .AppendLine("  WHERE idConcepto = " & idConcepto.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosConceptos")

   End Sub

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT MAX(idConcepto) AS Maximo ")
         .Append(" FROM SueldosConceptos")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)

      With stb
         .Length = 0
         .AppendLine("SELECT C.CodigoConcepto")
         .AppendLine("      ,C.NombreConcepto ")
         .AppendLine("      ,C.idTipoConcepto")
         .AppendLine("      ,TC.NombreTipoConcepto ")
         .AppendLine("      ,C.IdQuepide")
         .AppendLine("      ,Q.NombreQuePide ")
         .AppendLine("      ,C.Valor ")
         .AppendLine("      ,C.Tipo ")
         .AppendLine("      ,C.EsContempladoAguinaldo ")
         .AppendLine("      ,C.Aguinaldo ")
         .AppendLine("      ,C.LiquidacionAnual ")
         .AppendLine("      ,C.LiquidacionMeses ")
         .AppendLine("      ,C.Formula ")
         'GAR: 13/09/2016 - 'Dejar aca hasta cambiar la ayuda a la que se usa por base, necesita los lugares exactos.
         .AppendLine("      ,C.IdConcepto ")
         .AppendLine("      ,C.MostrarEnRecibo")
         .AppendLine("  FROM SueldosConceptos C ")
         .AppendLine("  LEFT JOIN SueldosTiposConceptos TC ON TC.IdTipoCOncepto = C.IdTipoConcepto ")
         .AppendLine("  LEFT JOIN SueldosQuePideConcepto Q ON Q.idQuePide = C.idQuepide ")
      End With

   End Sub

   Public Function SueldosConceptos_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      Me.SelectTexto(myQuery)

      With myQuery
         .AppendLine("  ORDER BY C.IdTipoConcepto, C.NombreConcepto ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Overloads Function SueldosConceptos_G1(ByVal idConcepto As Integer, _
                                       ByVal EsAguinaldo As Boolean, _
                                       ByVal ModoNombre As Boolean, _
                                       ByVal NombreConcepto As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      Me.SelectTexto(myQuery)

      With myQuery

         .AppendLine(" WHERE 1=1 ")

         If EsAguinaldo Then
            .AppendLine(" AND C.Aguinaldo = 'S'")
         Else
            .AppendLine(" AND C.Aguinaldo = 'N'")
         End If

         If Not ModoNombre Then
            If idConcepto > 0 Then
               .AppendLine(" AND C.CodigoConcepto = " & idConcepto)
            End If
         Else
            .AppendLine(" AND C.NombreConcepto LIKE '%" & NombreConcepto & "%'")
         End If

         .AppendLine("  ORDER BY C.IdTipoConcepto, C.NombreConcepto ")

      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Overloads Function SueldosConceptos_G1(ByVal idConcepto As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      Me.SelectTexto(myQuery)

      With myQuery

         .AppendLine(" WHERE ")  '¿C.idTipoConcepto = " & idTipoConcepto)

         .AppendFormat(" C.IdConcepto = {0}", idConcepto).AppendLine()

      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Overloads Function SueldosConceptos_G1xCodigo(ByVal CodigoConcepto As Integer, ByVal idConcepto As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      Me.SelectTexto(myQuery)

      With myQuery

         .AppendLine(" WHERE ")
         .AppendFormat(" C.CodigoConcepto = {0}", CodigoConcepto).AppendLine()
         .AppendFormat(" AND C.idConcepto <> {0}", idConcepto).AppendLine()

      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

End Class

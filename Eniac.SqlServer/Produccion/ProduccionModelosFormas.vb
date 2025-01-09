Public Class ProduccionModelosFormas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionModelosFormas_I(idProduccionModeloForma As Integer, nombreProduccionModeloForma As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2})",
                           Entidades.ProduccionModeloForma.NombreTabla,
                           Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString(),
                           Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString())
         .AppendFormatLine("     VALUES ({1}, '{2}')",
                           Entidades.ProduccionModeloForma.NombreTabla,
                           idProduccionModeloForma, nombreProduccionModeloForma)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProduccionModelosFormas_U(idProduccionModeloForma As Integer, nombreProduccionModeloForma As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ProduccionModeloForma.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString(), nombreProduccionModeloForma)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString(), idProduccionModeloForma)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProduccionModelosFormas_D(idProduccionModeloForma As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}",
                       Entidades.ProduccionModeloForma.NombreTabla,
                       Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString(), idProduccionModeloForma)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, pivotVariables As Boolean)
      With stb
         If Not pivotVariables Then
            .AppendFormatLine("SELECT PML.*")
            .AppendFormatLine("  FROM {0} AS PML", Entidades.ProduccionModeloForma.NombreTabla)
         Else
            Dim variables = New ProduccionModelosFormasVariables(_da).ProduccionModelosFormasVariables_G_DistinctVariables().AsEnumerable().ToList().
                                 ConvertAll(Function(v) String.Format("[____{0}]", v.Field(Of String)(Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString())))
            If variables.Any Then
               .AppendFormatLine("SELECT PML.*")
               .AppendFormatLine("  FROM (")
               .AppendFormatLine("        SELECT PML.*, '____' + PMLV.CodigoVariable CodigoVariable, PMLV.ValorDecimalVariable")
               .AppendFormatLine("          FROM ProduccionModelosFormas AS PML")
               .AppendFormatLine("         INNER JOIN ProduccionModelosFormasVariables AS PMLV ")
               .AppendFormatLine("                 ON PMLV.IdProduccionModeloForma = PML.IdProduccionModeloForma")
               .AppendFormatLine("         WHERE 1 = 1")
               .AppendFormatLine("        ) T")
               .AppendFormatLine("PIVOT (MAX(ValorDecimalVariable) FOR CodigoVariable IN ({0})) AS PML", String.Join(",", variables))
            Else
               SelectTexto(stb, pivotVariables:=False)
            End If
         End If
      End With
   End Sub

   Public Function ProduccionModelosFormas_GA(pivotVariables As Boolean) As DataTable
      Return ProduccionModelosFormas_G(0, String.Empty, nombreProduccionModeloFormaExacto:=False, pivotVariables)
   End Function
   Private Function ProduccionModelosFormas_G(idProduccionModeloForma As Integer, nombreProduccionModeloForma As String, nombreProduccionModeloFormaExacto As Boolean,
                                              pivotVariables As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, pivotVariables)
         .AppendFormatLine(" WHERE 1 = 1")
         If idProduccionModeloForma <> 0 Then
            .AppendFormatLine("   AND PML.IdProduccionModeloForma = {0}", idProduccionModeloForma)
         End If
         If Not String.IsNullOrWhiteSpace(nombreProduccionModeloForma) Then
            If nombreProduccionModeloFormaExacto Then
               .AppendFormatLine("   AND PML.NombreProduccionModeloForma = '{0}'", nombreProduccionModeloForma)
            Else
               .AppendFormatLine("   AND PML.NombreProduccionModeloForma LIKE '%{0}%'", nombreProduccionModeloForma)
            End If
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ProduccionModelosFormas_G1(idProduccionModeloForma As Integer) As DataTable
      Return ProduccionModelosFormas_G(idProduccionModeloForma, String.Empty, nombreProduccionModeloFormaExacto:=False, pivotVariables:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String, pivotVariables As Boolean) As DataTable
      If Not pivotVariables Then
         Return Buscar(columna, valor, Sub(stb) SelectTexto(stb, pivotVariables), "PML.")
      Else
         Return Buscar(columna, valor, Sub(stb) SelectTexto(stb, pivotVariables), "PML.")
      End If
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString(), "ProduccionModelosFormas").ToInteger()
   End Function
End Class
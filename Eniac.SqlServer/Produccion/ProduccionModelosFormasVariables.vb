Public Class ProduccionModelosFormasVariables
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionModelosFormasVariables_I(idProduccionModeloForma As Integer, codigoVariable As String, valorDecimalVariable As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3})",
                        Entidades.ProduccionModeloFormaVariable.NombreTabla,
                        Entidades.ProduccionModeloFormaVariable.Columnas.IdProduccionModeloForma.ToString(),
                        Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString(),
                        Entidades.ProduccionModeloFormaVariable.Columnas.ValorDecimalVariable.ToString())
         .AppendFormatLine("     VALUES ({1}, '{2}', {3})",
                        Entidades.ProduccionModeloFormaVariable.NombreTabla,
                        idProduccionModeloForma, codigoVariable, valorDecimalVariable)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProduccionModelosFormasVariables_U(idProduccionModeloForma As Integer, codigoVariable As String, valorDecimalVariable As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ProduccionModeloFormaVariable.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ProduccionModeloFormaVariable.Columnas.ValorDecimalVariable.ToString(), valorDecimalVariable)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ProduccionModeloFormaVariable.Columnas.IdProduccionModeloForma.ToString(), idProduccionModeloForma)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString(), codigoVariable)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProduccionModelosFormasVariables_D(idProduccionModeloForma As Integer, codigoVariable As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.ProduccionModeloFormaVariable.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ProduccionModeloFormaVariable.Columnas.IdProduccionModeloForma.ToString(), idProduccionModeloForma)
         If Not String.IsNullOrWhiteSpace(codigoVariable) Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString(), codigoVariable)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PML.*")
         .AppendFormatLine("  FROM {0} AS PML", Entidades.ProduccionModeloFormaVariable.NombreTabla)
      End With
   End Sub

   Public Function ProduccionModelosFormasVariables_GA(idProduccionModeloForma As Integer) As DataTable
      Return ProduccionModelosFormasVariables_G(idProduccionModeloForma, String.Empty)
   End Function
   Private Function ProduccionModelosFormasVariables_G(idProduccionModeloForma As Integer, codigoVariable As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idProduccionModeloForma <> 0 Then
            .AppendFormatLine("   AND PML.IdProduccionModeloForma = {0}", idProduccionModeloForma)
         End If
         If Not String.IsNullOrWhiteSpace(codigoVariable) Then
            .AppendFormatLine("   AND PML.CodigoVariable = '{0}'", codigoVariable)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ProduccionModelosFormasVariables_G1(idProduccionModeloForma As Integer, codigoVariable As String) As DataTable
      Return ProduccionModelosFormasVariables_G(idProduccionModeloForma, codigoVariable)
   End Function

   Public Function ProduccionModelosFormasVariables_G_DistinctVariables() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT DISTINCT {0} CodigoVariable", Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString())
         .AppendFormatLine("  FROM {0}", Entidades.ProduccionModeloFormaVariable.NombreTabla)
         .AppendFormatLine(" ORDER BY {0}", Entidades.ProduccionModeloFormaVariable.Columnas.CodigoVariable.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PML.")
   End Function

End Class
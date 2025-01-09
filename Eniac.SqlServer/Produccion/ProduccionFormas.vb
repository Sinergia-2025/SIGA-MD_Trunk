Public Class ProduccionFormas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionFormas_I(idProduccionForma As Integer,
                                 nombreProduccionForma As String,
                                 formulaCalculoKilaje As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ProduccionFormas ({0}, {1}, {2})",
                           Entidades.ProduccionForma.Columnas.IdProduccionForma.ToString(),
                           Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString(),
                           Entidades.ProduccionForma.Columnas.FormulaCalculoKilaje.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}', '{2}')",
                           idProduccionForma, nombreProduccionForma, formulaCalculoKilaje)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProduccionFormas_U(idProduccionForma As Integer,
                                 nombreProduccionForma As String,
                                 formulaCalculoKilaje As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProduccionFormas ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString(), nombreProduccionForma)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ProduccionForma.Columnas.FormulaCalculoKilaje.ToString(), formulaCalculoKilaje)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ProduccionForma.Columnas.IdProduccionForma.ToString(), idProduccionForma)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProduccionFormas_D(idProduccionForma As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM ProduccionFormas WHERE {0} = {1}", Entidades.ProduccionForma.Columnas.IdProduccionForma.ToString(), idProduccionForma)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PRF.*")
         .AppendFormatLine("  FROM ProduccionFormas AS PRF")
      End With
   End Sub

   Public Function ProduccionFormas_GA() As DataTable
      Return ProduccionFormas_G(0, String.Empty)
   End Function
   Private Function ProduccionFormas_G(idProduccionForma As Integer, nombreProduccionForma As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idProduccionForma <> 0 Then
            .AppendFormatLine("   AND PRF.IdProduccionForma = {0}", idProduccionForma)
         End If
         If Not String.IsNullOrWhiteSpace(nombreProduccionForma) Then
            .AppendFormatLine("   AND PRF.NombreProduccionForma = '{0}'", nombreProduccionForma)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ProduccionFormas_G1(idProduccionForma As Integer) As DataTable
      Return ProduccionFormas_G(idProduccionForma, String.Empty)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "PRF.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.ProduccionForma.Columnas.IdProduccionForma.ToString(), Entidades.ProduccionForma.NombreTabla).ToInteger()
   End Function
End Class
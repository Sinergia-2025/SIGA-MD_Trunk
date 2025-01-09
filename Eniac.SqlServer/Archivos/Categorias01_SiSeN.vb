Partial Class Categorias
   Public Function Categorias_GA_PorCliente(idCliente As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CA.*")
         .AppendFormatLine("  FROM Categorias CA")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCategoria = CA.IdCategoria")
         .AppendFormatLine(" WHERE C.IdCliente = {0}", idCliente)
      End With
      Return GetDataTable(stb.ToString())
   End Function
End Class
Public Class ClientesDescuentosSubRubros
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ClientesDescuentosSubRubros_I(idCliente As Long, idSubrubro As Integer, descuentoRecargo As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ClientesDescuentosSubRubros (")
         .AppendFormatLine("     IdCliente")
         .AppendFormatLine("   , IdSubrubro")
         .AppendFormatLine("   , DescuentoRecargo")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("     {0}", idCliente)
         .AppendFormatLine("   , {0}", idSubrubro)
         .AppendFormatLine("   , {0}", descuentoRecargo)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ClientesDescuentosSubRubros")
   End Sub
   Public Sub ClientesDescuentosSubRubros_D(idCliente As Long, idSubRubro As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE CDS FROM ClientesDescuentosSubRubros CDS")
         .AppendFormatLine(" WHERE CDS.IdCliente = {0}", idCliente)
         If idSubRubro <> 0 Then
            .AppendFormatLine("   AND CDS.IdSubRubro = {0}", idSubRubro)
         End If
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ClientesDescuentosSubRubros")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CD.*")
         .AppendFormatLine("     , S.IdRubro")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , S.NombreSubRubro")
         .AppendFormatLine(" FROM ClientesDescuentosSubRubros CD")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente")
         .AppendFormatLine(" INNER JOIN SubRubros S ON S.IdSubRubro = CD.IdSubRubro")
         .AppendFormatLine(" INNER JOIN Rubros R ON R.IdRubro = S.IdRubro")
      End With
   End Sub
   Public Function GetClientesDescuentosSubRubros(idCliente As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If idCliente > 0 Then
            .AppendFormatLine("	AND CD.IdCliente = {0}", idCliente)
         End If
         .AppendFormatLine(" ORDER BY C.NombreCliente, R.NombreRubro, S.NombreSubRubro")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function Get1(idCliente As Long, idSubRubro As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE CD.IdCliente = {0}", idCliente)
         .AppendFormatLine("   AND CD.IdSubRubro = {0}", idSubRubro)
         .AppendFormatLine(" ORDER BY C.NombreCliente, R.NombreRubro, S.NombreSubRubro")
      End With
      Return GetDataTable(stb)
   End Function
End Class
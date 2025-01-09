Public Class MarcasEmbarcaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MarcasEmbarcaciones_I(idMarcaEmbarcacion As Integer, nombreMarcaEmbarcacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO MarcasEmbarcaciones (")
         .AppendFormatLine("     IdMarcaEmbarcacion")
         .AppendFormatLine("   , NombreMarcaEmbarcacion")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("     {0} ", idMarcaEmbarcacion)
         .AppendFormatLine("   ,'{0}'", nombreMarcaEmbarcacion)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "MarcasEmbarcaciones")
   End Sub

   Public Sub MarcasEmbarcaciones_U(idMarcaEmbarcacion As Integer, nombreMarcaEmbarcacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE MarcasEmbarcaciones ")
         .AppendFormatLine("   SET NombreMarcaEmbarcacion = '{0}'", nombreMarcaEmbarcacion)
         .AppendFormatLine(" WHERE idMarcaEmbarcacion = {0}", idMarcaEmbarcacion)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "MarcasEmbarcaciones")
   End Sub

   Public Sub MarcasEmbarcaciones_D(idMarcaEmbarcacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM MarcasEmbarcaciones")
         .AppendFormatLine(" WHERE idMarcaEmbarcacion = {0}", idMarcaEmbarcacion)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "MarcasEmbarcaciones")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT MaE.IdMarcaEmbarcacion")
         .AppendLine("     , MaE.NombreMarcaEmbarcacion")
         .AppendLine("  FROM MarcasEmbarcaciones MaE")
      End With
   End Sub

   Public Function MarcasEmbarcaciones_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" ORDER BY MaE.NombreMarcaEmbarcacion")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function MarcasEmbarcaciones_G1(IdMarcaEmbarcacion As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE MaE.IdMarcaEmbarcacion = {0}", IdMarcaEmbarcacion)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "MaE.")
   End Function

   Function GetPorNombreMarca(nombreMarcaEmbarcacion As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.MarcaEmbarcacion.Columnas.NombreMarcaEmbarcacion.ToString(), nombreMarcaEmbarcacion)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo("IdMarcaEmbarcacion", "MarcasEmbarcaciones").ToInteger()
   End Function

End Class
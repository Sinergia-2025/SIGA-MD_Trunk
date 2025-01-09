Public Class ModelosEmbarcaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ModelosEmbarcaciones_I(idModeloEmbarcacion As Integer,
                                     nombreModeloEmbarcacion As String,
                                     idMarcaEmbarcacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ModelosEmbarcaciones (")
         .AppendFormatLine("     IdModeloEmbarcacion")
         .AppendFormatLine("   , NombreModeloEmbarcacion")
         .AppendFormatLine("   , IdMarcaEmbarcacion")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      {0} ", idModeloEmbarcacion)
         .AppendFormatLine("   , '{0}'", nombreModeloEmbarcacion)
         .AppendFormatLine("   ,  {0} ", idMarcaEmbarcacion)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ModelosEmbarcaciones")
   End Sub

   Public Sub ModelosEmbarcaciones_U(idModeloEmbarcacion As Integer,
                                     nombreModeloEmbarcacion As String,
                                     idMarcaEmbarcacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ModelosEmbarcaciones ")
         .AppendFormatLine("   SET NombreModeloEmbarcacion = '{0}'", nombreModeloEmbarcacion)
         .AppendFormatLine("     , IdMarcaEmbarcacion = {0}", idMarcaEmbarcacion)
         .AppendFormatLine(" WHERE IdModeloEmbarcacion = {0}", idModeloEmbarcacion)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ModelosEmbarcaciones")
   End Sub

   Public Sub ModelosEmbarcaciones_D(idModeloEmbarcacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM ModelosEmbarcaciones ")
         .AppendFormatLine(" WHERE idModeloEmbarcacion = {0}", idModeloEmbarcacion)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ModelosEmbarcaciones")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT MoE.IdModeloEmbarcacion")
         .AppendLine("      ,MoE.NombreModeloEmbarcacion")
         .AppendLine("      ,MoE.IdMarcaEmbarcacion")
         .AppendLine("      ,MaE.NombreMarcaEmbarcacion")
         .AppendLine("  FROM ModelosEmbarcaciones MoE")
         .AppendLine(" INNER JOIN MarcasEmbarcaciones MaE ON MaE.IdMarcaEmbarcacion = MoE.IdMarcaEmbarcacion ")
      End With
   End Sub

   Public Function ModelosEmbarcaciones_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" ORDER BY MaE.NombreMarcaEmbarcacion, MoE.NombreModeloEmbarcacion")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ModelosEmbarcaciones_GA(IdMarcaEmbarcacion As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         If IdMarcaEmbarcacion > 0 Then
            .AppendFormatLine(" WHERE MoE.IdMarcaEmbarcacion = {0}", IdMarcaEmbarcacion)
         End If
         .AppendLine(" ORDER BY MaE.NombreMarcaEmbarcacion, MoE.NombreModeloEmbarcacion")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ModelosEmbarcaciones_G1(IdModeloEmbarcacion As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE MoE.IdModeloEmbarcacion = {0}", IdModeloEmbarcacion)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "MoE.")
   End Function

   Function GetPorNombreModelo(nombreMarcaEmbarcacion As String, nombreModeloEmbarcacion As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE MoE.{0} = '{1}'", Entidades.ModeloEmbarcacion.Columnas.NombreModeloEmbarcacion.ToString(), nombreModeloEmbarcacion)
         If Not String.IsNullOrWhiteSpace(nombreMarcaEmbarcacion) Then
            .AppendFormatLine(" AND MaE.{0} = '{1}'", Entidades.MarcaEmbarcacion.Columnas.NombreMarcaEmbarcacion.ToString(), nombreMarcaEmbarcacion)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo("IdModeloEmbarcacion", "ModelosEmbarcaciones").ToInteger()
   End Function

End Class
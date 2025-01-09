Public Class MarcasMotores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MarcasMotores_I(idMarcaMotor As Integer, nombreMarcaMotor As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO MarcasMotores (")
         .AppendFormatLine("     IdMarcaMotor")
         .AppendFormatLine("   , NombreMarcaMotor")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      {0} ", idMarcaMotor)
         .AppendFormatLine("   , '{0}'", nombreMarcaMotor)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "MarcasMotores")
   End Sub

   Public Sub MarcasMotores_U(idMarcaMotor As Integer, nombreMarcaMotor As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE MarcasMotores ")
         .AppendFormatLine("   SET NombreMarcaMotor = '{0}'", nombreMarcaMotor)
         .AppendFormatLine(" WHERE idMarcaMotor = {0}", idMarcaMotor)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "MarcasMotores")
   End Sub

   Public Sub MarcasMotores_D(idMarcaMotor As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM MarcasMotores ")
         .AppendFormatLine(" WHERE idMarcaMotor = {0}", idMarcaMotor)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "MarcasMotores")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT MaM.IdMarcaMotor")
         .AppendLine("     , MaM.NombreMarcaMotor")
         .AppendLine("  FROM MarcasMotores MaM")
      End With
   End Sub

   Public Function MarcasMotores_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" ORDER BY MaM.NombreMarcaMotor")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function MarcasMotores_G1(IdMarcaMotor As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE MaM.IdMarcaMotor = {0}", IdMarcaMotor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "MaM.")
   End Function

   Function GetPorNombreMarca(nombreMarcaMotor As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.MarcaMotor.Columnas.NombreMarcaMotor.ToString(), nombreMarcaMotor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo("IdMarcaMotor", "MarcasMotores").ToInteger()
   End Function

End Class
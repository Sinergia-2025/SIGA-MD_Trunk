Public Class Sectores
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Sectores_I(en As Entidades.Sector)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO Sectores ({0}, {1}, {2}, {3})",
                          Entidades.Sector.Columnas.IdSector.ToString(),
                          Entidades.Sector.Columnas.NombreSector.ToString(),
                          Entidades.Sector.Columnas.IdAreaComun.ToString(),
                          Entidades.Sector.Columnas.Observaciones.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2}, '{3}')",
                          en.IdSector, en.NombreSector,
                          IIf(String.IsNullOrWhiteSpace(en.IdAreaComun), "NULL", "'" + en.IdAreaComun + "'"), en.Observaciones)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Sectores_U(en As Entidades.Sector)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE Sectores ")
         .AppendFormat("   SET {0} = '{1}',", Entidades.Sector.Columnas.NombreSector.ToString(), en.NombreSector).AppendLine()
         .AppendFormat("       {0} =  {1} ,", Entidades.Sector.Columnas.IdAreaComun.ToString(), IIf(String.IsNullOrWhiteSpace(en.IdAreaComun), "NULL", "'" + en.IdAreaComun + "'")).AppendLine()
         .AppendFormat("       {0} = '{1}' ", Entidades.Sector.Columnas.Observaciones.ToString(), en.Observaciones).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", Entidades.Sector.Columnas.IdSector.ToString(), en.IdSector)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Sectores_D(idSector As Long?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM Sectores ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.Sector.Columnas.IdSector.ToString(), idSector)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT * ")
         .AppendFormatLine("  FROM {0} AS CA", Entidades.Sector.NombreTabla)
         '.AppendFormatLine(" INNER JOIN Clientes AS C ON C.IdCliente = CA.IdSector")
      End With
   End Sub

   Public Function Sectores_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" ORDER BY {0}.{1}", "CA", Entidades.Sector.Columnas.NombreSector.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Sectores_G1(idSector As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE {0}.{1} = {2} ", "CA", Entidades.Sector.Columnas.IdSector.ToString(), idSector)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "S." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE {0} LIKE '%{1}%'", columna, valor).AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Long
      Return GetCodigoMaximo(Entidades.Sector.Columnas.IdSector.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(Campo As String) As Long
      Return GetCodigoMaximo(Campo, "Sectores")
   End Function

End Class
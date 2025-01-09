Public Class Casilleros
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Casilleros_I(en As Entidades.Casillero)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO Casilleros ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                       Entidades.Casillero.Columnas.IdCasillero.ToString(),
                       Entidades.Casillero.Columnas.CodigoCasillero.ToString(),
                       Entidades.Casillero.Columnas.IdSector.ToString(),
                       Entidades.Casillero.Columnas.FilaCasillero.ToString(),
                       Entidades.Casillero.Columnas.ColumnaCasillero.ToString(),
                       Entidades.Casillero.Columnas.IdCliente.ToString(),
                       Entidades.Casillero.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6})",
                       en.IdCasillero, en.CodigoCasillero, en.IdSector,
                       en.FilaCasillero, en.ColumnaCasillero, GetStringFromNumber(en.IdCliente),
                       GetStringFromBoolean(en.Activo))
      End With
      Execute(myQuery)
   End Sub

   Public Sub Casilleros_U(en As Entidades.Casillero)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE Casilleros ")
         .AppendFormat("   SET {0} = '{1}',", Entidades.Casillero.Columnas.CodigoCasillero.ToString(), en.CodigoCasillero).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.Casillero.Columnas.IdSector.ToString(), en.IdSector).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.Casillero.Columnas.FilaCasillero.ToString(), en.FilaCasillero).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.Casillero.Columnas.ColumnaCasillero.ToString(), en.ColumnaCasillero).AppendLine()
         .AppendFormat("       {0} =  {1}, ", Entidades.Casillero.Columnas.IdCliente.ToString(), GetStringFromNumber(en.IdCliente)).AppendLine()
         .AppendFormat("       {0} =  {1}  ", Entidades.Casillero.Columnas.Activo.ToString(), GetStringFromBoolean(en.Activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", Entidades.Casillero.Columnas.IdCasillero.ToString(), en.IdCasillero)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Casilleros_D(idCasillero As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM Casilleros ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.Casillero.Columnas.IdCasillero.ToString(), idCasillero)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Length = 0
         .AppendFormat("SELECT {0}.{1}, {0}.{2}, {0}.{3}, {0}.{4}, {0}.{5}, {0}.{6}, {0}.{7}, {8}.{9}, {10}.{11} FROM Casilleros AS {0}", "C",
                       Entidades.Casillero.Columnas.IdCasillero.ToString(),
                       Entidades.Casillero.Columnas.CodigoCasillero.ToString(),
                       Entidades.Casillero.Columnas.IdSector.ToString(),
                       Entidades.Casillero.Columnas.FilaCasillero.ToString(),
                       Entidades.Casillero.Columnas.ColumnaCasillero.ToString(),
                       Entidades.Casillero.Columnas.IdCliente.ToString(),
                       Entidades.Casillero.Columnas.Activo.ToString(),
                       "S", Entidades.Sector.Columnas.NombreSector.ToString(),
                       "CL", Entidades.Cliente.Columnas.NombreCliente.ToString()
                       ).AppendLine()
         .AppendFormat(" INNER JOIN Sectores AS {0} ON {0}.{1} = {2}.{3}",
                       "S", Entidades.Sector.Columnas.IdSector, "C", Entidades.Casillero.Columnas.IdSector)
         .AppendFormat(" LEFT JOIN Clientes AS {0} ON {0}.{1} = {2}.{3}",
                       "CL", Entidades.Cliente.Columnas.IdCliente, "C", Entidades.Casillero.Columnas.IdCliente)
      End With
   End Sub

   Public Function Casilleros_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" ORDER BY {0}.{1}", "C", Entidades.Casillero.Columnas.CodigoCasillero.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Casilleros_G1(idCasillero As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE {0}.{1} = {2} ", "C", Entidades.Casillero.Columnas.IdCasillero.ToString(), idCasillero)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Select Case columna
         Case Entidades.Cliente.Columnas.NombreCliente.ToString()
            columna = "CL." + columna
         Case Entidades.Sector.Columnas.NombreSector.ToString()
            columna = "S." + columna
         Case Else
            columna = "C." + columna
      End Select

      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE {0} LIKE '%{1}%'", columna, valor).AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.Casillero.Columnas.IdCasillero.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(Campo As String) As Integer
      Return GetCodigoMaximo(Campo, "Casilleros").ToInteger()
   End Function

End Class
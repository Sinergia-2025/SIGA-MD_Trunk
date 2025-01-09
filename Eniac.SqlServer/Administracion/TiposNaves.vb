Public Class TiposNaves
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposNaves_I(en As Entidades.TipoNave)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO TiposNaves ({0}, {1}, {2})",
                       Entidades.TipoNave.Columnas.IdTipoNave.ToString(),
                       Entidades.TipoNave.Columnas.NombreTipoNave.ToString(),
                       Entidades.TipoNave.Columnas.Seco.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2})",
                       en.IdTipoNave, en.NombreTipoNave, IIf(en.Seco, 1, 0))
      End With
      Execute(myQuery)
   End Sub

   Public Sub TiposNaves_U(en As Entidades.TipoNave)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TiposNaves ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.TipoNave.Columnas.NombreTipoNave.ToString(), en.NombreTipoNave).AppendLine()
         .AppendFormat("     , {0} =  {1} ", Entidades.TipoNave.Columnas.Seco.ToString(), IIf(en.Seco, 1, 0)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoNave.Columnas.IdTipoNave.ToString(), en.IdTipoNave)
      End With
      Execute(myQuery)
   End Sub

   Public Sub TiposNaves_D(idTipoNave As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM TiposNaves ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoNave.Columnas.IdTipoNave.ToString(), idTipoNave)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT {0}.{1}, {0}.{2}, {0}.{3} FROM TiposNaves {0}", "TN",
                       Entidades.TipoNave.Columnas.IdTipoNave.ToString(),
                       Entidades.TipoNave.Columnas.NombreTipoNave.ToString(),
                       Entidades.TipoNave.Columnas.Seco.ToString()).AppendLine()
      End With
   End Sub

   Public Function TiposNaves_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" ORDER BY {0}.{1}", "TN", Entidades.TipoNave.Columnas.IdTipoNave.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function TiposNaves_G1(idTipoNave As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE {0}.{1} = {2} ", "TN", Entidades.TipoNave.Columnas.IdTipoNave.ToString(), idTipoNave)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "TN." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo(Campo As String) As Long
      Return GetCodigoMaximo(Campo, "TiposNaves")
   End Function

End Class
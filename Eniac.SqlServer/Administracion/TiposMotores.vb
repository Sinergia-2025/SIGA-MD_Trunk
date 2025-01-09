Public Class TiposMotores
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposMotores_I(en As Entidades.TipoMotor)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO TiposMotores ({0}, {1})",
                          Entidades.TipoMotor.Columnas.IdTipoMotor.ToString(),
                          Entidades.TipoMotor.Columnas.NombreTipoMotor.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}')",
                          en.IdTipoMotor, en.NombreTipoMotor)
      End With
      Execute(myQuery)
   End Sub

   Public Sub TiposMotores_U(en As Entidades.TipoMotor)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TiposMotores ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.TipoMotor.Columnas.NombreTipoMotor.ToString(), en.NombreTipoMotor).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoMotor.Columnas.IdTipoMotor.ToString(), en.IdTipoMotor)
      End With
      Execute(myQuery)
   End Sub

   Public Sub TiposMotores_D(idTipoMotor As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM TiposMotores ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoMotor.Columnas.IdTipoMotor.ToString(), idTipoMotor)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT {0}.{1}, {0}.{2} FROM TiposMotores AS {0}", "TN",
                          Entidades.TipoMotor.Columnas.IdTipoMotor.ToString(),
                          Entidades.TipoMotor.Columnas.NombreTipoMotor.ToString()).AppendLine()
      End With
   End Sub

   Public Function TiposMotores_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" ORDER BY {0}.{1}", "TN", Entidades.TipoMotor.Columnas.NombreTipoMotor.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function TiposMotores_G1(idTipoMotor As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE {0}.{1} = {2} ", "TN", Entidades.TipoMotor.Columnas.IdTipoMotor.ToString(), idTipoMotor)
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
      Return GetCodigoMaximo(Campo, "TiposMotores", String.Format("{0} <> 999", Campo))
   End Function

End Class
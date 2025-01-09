Public Class TiposClientes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposClientes_I(idTipoCliente As Integer, nombreTipoCliente As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO TiposClientes (")
         .AppendFormatLine("            IdTipoCliente")
         .AppendFormatLine("          , NombreTipoCliente")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("             {0}", idTipoCliente)
         .AppendFormatLine("          , '{0}'", nombreTipoCliente)
         .AppendFormatLine(")")
      End With

      Execute(stb)
   End Sub

   Public Sub TiposClientes_U(idTipoCliente As Integer, nombreTipoCliente As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE TiposClientes")
         .AppendFormatLine("   SET NombreTipoCliente = '{0}'", nombreTipoCliente)
         .AppendFormatLine(" WHERE IdTipoCliente = {0}", idTipoCliente)
      End With

      Execute(stb)
   End Sub

   Public Sub TiposClientes_D(idTipoCliente As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM TiposClientes")
         .AppendFormatLine(" WHERE IdTipoCliente = {0}", idTipoCliente)
      End With

      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Append("SELECT TC.*")
         .Append("  FROM TiposClientes TC ")
      End With
   End Sub

   Public Function TiposClientes_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine("  ORDER BY TC.NombreTipoCliente")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function TiposClientes_G1(idTipoCliente As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE TC.IdTipoCliente = {0}", idTipoCliente)
      End With

      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "TC.")
   End Function

   Public Function GetPorNombre(nombre As String, nombreExacto As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If Not String.IsNullOrEmpty(nombre) Then
            If nombreExacto Then
               .AppendFormatLine("WHERE TC.NombreTipoCliente = '{0}'", nombre)
            Else
               .AppendFormatLine("WHERE TC.NombreTipoCliente LIKE '%{0}%'", nombre)
            End If
         End If
         .AppendLine(" ORDER BY TC.NombreTipoCliente")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPorCodigo(codigo As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If codigo > 0 Then
            .AppendFormatLine("WHERE TC.IdTipoCliente LIKE '%{0}%'", codigo)
         End If
         .AppendFormatLine("  ORDER BY TC.NombreTipoCliente")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetProximoId() As Integer
      Return GetCodigoMaximo("IdTipoCliente", "TiposClientes").ToInteger() + 1
   End Function

   Public Function GetTop1() As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT TOP(1) IdTipoCliente FROM TiposClientes")
      End With
      Return GetDataTable(query)
   End Function
End Class
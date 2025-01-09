Public Class ConcesionariosAdicionales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub ConcesionariosAdicionales_I(idAdicional As Integer,
                                          nombreAdicional As String,
                                          descripcionAdicional As String,
                                          solicitaDetalle As Boolean)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4})",
                           Entidades.ConcesionariosAdicionales.NombreTabla,
                           Entidades.ConcesionariosAdicionales.Columnas.IdAdicional.ToString(),
                           Entidades.ConcesionariosAdicionales.Columnas.NombreAdicional.ToString(),
                           Entidades.ConcesionariosAdicionales.Columnas.DescripcionAdicional.ToString(),
                           Entidades.ConcesionariosAdicionales.Columnas.SolicitaDetalle.ToString())
         .AppendFormat("VALUES ({1}, '{2}', '{3}', '{4}')",
                           Entidades.ConcesionariosAdicionales.NombreTabla, idAdicional, nombreAdicional, descripcionAdicional, GetStringFromBoolean(solicitaDetalle))
      End With
      Me.Execute(query.ToString())
   End Sub
   'UPDATE
   Public Sub ConcesionariosAdicionales_U(idAdicional As Integer,
                                          nombreAdicional As String,
                                          descripcionAdicional As String,
                                          solicitaDetalle As Boolean)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ConcesionariosAdicionales.NombreTabla).AppendLine()
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ConcesionariosAdicionales.Columnas.NombreAdicional.ToString(), nombreAdicional)
         .AppendFormatLine("   ,{0} = '{1}'", Entidades.ConcesionariosAdicionales.Columnas.DescripcionAdicional.ToString(), descripcionAdicional)
         .AppendFormatLine("   ,{0} = {1}", Entidades.ConcesionariosAdicionales.Columnas.SolicitaDetalle.ToString(), GetStringFromBoolean(solicitaDetalle))
         .AppendFormatLine(" WHERE {0} = {1} ", Entidades.ConcesionariosAdicionales.Columnas.IdAdicional.ToString(), idAdicional)
      End With
      Me.Execute(query.ToString())
   End Sub
   'DELETE
   Public Sub ConcesionariosAdicionales_D(idAdicional As Integer, nombreAdicional As String)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.ConcesionariosAdicionales.NombreTabla, Entidades.ConcesionariosAdicionales.Columnas.IdAdicional.ToString(), idAdicional)
      End With
      Me.Execute(query.ToString())
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ConcesionariosAdicionales.* FROM {0} AS ConcesionariosAdicionales", Entidades.ConcesionariosAdicionales.NombreTabla)
      End With
   End Sub

   'G
   Private Function ConcesionariosAdicionales_G(idAdicional As Integer, nombreAdicional As String, nombreExacto As Boolean, descripcionAdicional As String, solicitaDetalle As Boolean) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idAdicional > 0 Then
            .AppendFormatLine("   AND ConcesionariosAdicionales.idAdicional = {0}", idAdicional)
         End If
         If Not String.IsNullOrWhiteSpace(nombreAdicional) Then
            If nombreExacto Then
               .AppendFormatLine("   AND ConcesionariosAdicionales.nombreAdicional = '{0}'", nombreAdicional)
            Else
               .AppendFormatLine("   AND ConcesionariosAdicionales.nombreAdicional LIKE '%{0}%'", nombreAdicional)
            End If
         End If

         If Not String.IsNullOrWhiteSpace(descripcionAdicional) Then
            .AppendFormatLine("   AND ConcesionariosAdicionales.descripcionAdicional = '{0}'", descripcionAdicional)
         End If
         If solicitaDetalle Then
            .AppendFormatLine("   AND ConcesionariosAdicionales.solicitaDetalle = '{0}'", solicitaDetalle)
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   'GA
   Public Function ConcesionariosAdicionales_GA() As DataTable
      Return ConcesionariosAdicionales_G(idAdicional:=0, nombreAdicional:=String.Empty, descripcionAdicional:=String.Empty, nombreExacto:=False, solicitaDetalle:=False)
   End Function

   'G1
   Public Function ConcesionariosAdicionales_G1(idAdicional As Integer) As DataTable
      Return ConcesionariosAdicionales_G(idAdicional:=idAdicional, nombreAdicional:=String.Empty, descripcionAdicional:=String.Empty, nombreExacto:=False, solicitaDetalle:=False)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      columna = "ConcesionariosAdicionales." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   'GET CODIGO MAXIMO
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ConcesionariosAdicionales.Columnas.IdAdicional.ToString(), "ConcesionariosAdicionales"))
   End Function
End Class

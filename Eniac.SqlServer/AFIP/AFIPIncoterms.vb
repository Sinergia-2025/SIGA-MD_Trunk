Public Class AFIPIncoterms
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   'INSERT
   Public Sub AFIPIncoterms_I(idIncoterm As String, nombreIncoterm As String)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2})",
            Entidades.AFIPIncoterm.NombreTabla,
            Entidades.AFIPIncoterm.Columnas.IdIncoterm.ToString(),
            Entidades.AFIPIncoterm.Columnas.NombreIncoterm.ToString())
         .AppendFormatLine("     VALUES ('{1}', '{2}')",
            Entidades.AFIPIncoterm.NombreTabla, idIncoterm, nombreIncoterm)
      End With
      Me.Execute(query.ToString())
   End Sub

   'UPDATE
   Public Sub AFIPIncoterms_U(idIncoterm As String, nombreIncoterm As String)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE {0}", Entidades.AFIPIncoterm.NombreTabla)
         .AppendFormatLine("  SET {0} = '{1}'", Entidades.AFIPIncoterm.Columnas.NombreIncoterm.ToString(), nombreIncoterm)
         .AppendFormatLine("  WHERE {0} = '{1}'", Entidades.AFIPIncoterm.Columnas.IdIncoterm.ToString(), idIncoterm)
      End With
      Me.Execute(query.ToString())
   End Sub

   'DELETE
   Public Sub AFIPIncoterms_D(idIncoterm As String)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'", Entidades.AFIPIncoterm.NombreTabla, Entidades.AFIPIncoterm.Columnas.IdIncoterm.ToString(), idIncoterm)
      End With
      Me.Execute(query.ToString())
   End Sub

   'SELECT TEXT
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT AFIPIncoterms.* FROM {0} AS AFIPIncoterms", Entidades.AFIPIncoterm.NombreTabla)
      End With
   End Sub

   'G
   Private Function AFIPIncoterms_G(idIncoterm As String, nombreIncoterm As String, nombreExacto As Boolean) As DataTable
      Dim query As StringBuilder = New StringBuilder()

      With query
         Me.SelectTexto(query)

         .AppendFormatLine("WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idIncoterm) Then
            .AppendFormatLine(" AND AFIPIncoterms.IdIncoterm = '{0}'", idIncoterm)
         End If
         If Not String.IsNullOrWhiteSpace(nombreIncoterm) Then
            If nombreExacto Then
               .AppendFormatLine("  AND AFIPIncoterms.NombreIncoterm = '{0}'", nombreIncoterm)
            Else
               .AppendFormatLine("  AND AFIPIncoterms.NombreIncoterm LIKE '%{0}%'", nombreIncoterm)
            End If
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   'GA
   Public Function AFIPIncoterms_GA() As DataTable
      Return AFIPIncoterms_G(idIncoterm:=String.Empty, nombreIncoterm:=String.Empty, nombreExacto:=False)
   End Function

   'G1
   Public Function AFIPIncoterms_G1(idIncoterm As String) As DataTable
      Return AFIPIncoterms_G(idIncoterm:=idIncoterm, nombreIncoterm:=String.Empty, nombreExacto:=False)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "AFIPIncoterms." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)

         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class

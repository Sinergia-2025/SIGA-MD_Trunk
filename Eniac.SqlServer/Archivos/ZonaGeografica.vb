Public Class ZonaGeografica
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ZonaGeografica_I(idZonaGeografica As String, nombreZonaGeografica As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ZonasGeograficas (")
         .AppendFormatLine("       IdZonaGeografica")
         .AppendFormatLine("     , NombreZonaGeografica ")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("       '{0}'", idZonaGeografica)
         .AppendFormatLine("     , '{0}'", nombreZonaGeografica)
         .AppendFormatLine(" )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ZonasGeograficas")
   End Sub

   Public Sub ZonaGeografica_U(idZonaGeografica As String, nombreZonaGeografica As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ZonasGeograficas")
         .AppendFormatLine("   SET NombreZonaGeografica = '{0}'", nombreZonaGeografica)
         .AppendFormatLine(" WHERE IdZonaGeografica = '{0}'", idZonaGeografica)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ZonasGeograficas")
   End Sub

   Public Sub ZonaGeografica_D(IdZonaGeografica As String)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM ZonasGeograficas")
         .AppendFormatLine(" WHERE IdZonaGeografica = '{0}'", IdZonaGeografica)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ZonasGeograficas")
   End Sub

   Public Sub SelectTexto(stb As StringBuilder, top As Integer)
      With stb
         .Append("SELECT ")
         If top > 0 Then
            .AppendFormat("TOP {0} ", top)
         End If
         .AppendLine("Z.*")
         .AppendFormatLine("  FROM ZonasGeograficas AS Z")
      End With
   End Sub

   Public Function ZonaGeografica_GA() As DataTable
      Return ZonaGeografica_G(idZonaGeografica:=String.Empty, nombreZonaGeografica:=String.Empty, idZonaGeograficaExacto:=False, nombreZonaGeograficaExacto:=False, top:=0)
   End Function

   Public Function ZonaGeografica_G1(idZonaGeografica As String) As DataTable
      Return ZonaGeografica_G(idZonaGeografica, nombreZonaGeografica:=String.Empty, idZonaGeograficaExacto:=True, nombreZonaGeograficaExacto:=False, top:=1)
   End Function

   Public Function ZonaGeografica_G(idZonaGeografica As String, nombreZonaGeografica As String,
                                    idZonaGeograficaExacto As Boolean, nombreZonaGeograficaExacto As Boolean,
                                    top As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, top)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
            If idZonaGeograficaExacto Then
               .AppendFormatLine("   AND Z.IdZonaGeografica = '{0}' ", idZonaGeografica)
            Else
               .AppendFormatLine("   AND Z.IdZonaGeografica LIKE '%{0}%' ", idZonaGeografica)
            End If
         End If

         If Not String.IsNullOrWhiteSpace(nombreZonaGeografica) Then
            If nombreZonaGeograficaExacto Then
               .AppendFormatLine("   AND Z.NombreZonaGeografica = '{0}' ", nombreZonaGeografica)
            Else
               .AppendFormatLine("   AND Z.NombreZonaGeografica LIKE '%{0}%' ", nombreZonaGeografica)
            End If
         End If

         .Append(" ORDER BY Z.NombreZonaGeografica")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function ZonaGeografica_GA_PorCodigo(codigo As String, exacto As Boolean) As DataTable
      Return ZonaGeografica_G(idZonaGeografica:=codigo, nombreZonaGeografica:=String.Empty, idZonaGeograficaExacto:=exacto, nombreZonaGeograficaExacto:=False, top:=0)
   End Function
   Public Function ZonaGeografica_GA_PorNombre(nombre As String, exacto As Boolean) As DataTable
      Return ZonaGeografica_G(idZonaGeografica:=String.Empty, nombreZonaGeografica:=nombre, idZonaGeograficaExacto:=False, nombreZonaGeograficaExacto:=exacto, top:=0)
   End Function

   Public Function ZonaGeografica_GetPrimerZonaGeografica() As DataTable
      Return ZonaGeografica_G(idZonaGeografica:=String.Empty, nombreZonaGeografica:=String.Empty, idZonaGeograficaExacto:=False, nombreZonaGeograficaExacto:=False, top:=1)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb, top:=0), "Z.")
   End Function

End Class
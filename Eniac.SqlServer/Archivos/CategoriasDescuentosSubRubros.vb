Public Class CategoriasDescuentosSubRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasDescuentosSubRubros_I(ByVal idCategoria As Integer, _
                                              ByVal idSubRubro As Integer, _
                                              ByVal idRubro As Integer, _
                                              ByVal DescuentoRecargoPorc1Porc1 As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO CategoriasDescuentosSubRubros")
         .AppendLine("           (idCategoria")
         .AppendLine("           ,idSubRubro")
         .AppendLine("           ,idRubro")
         .AppendLine("           ,DescuentoRecargoPorc1)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},{1},{2},{3})", idCategoria, idSubRubro, idRubro, DescuentoRecargoPorc1Porc1)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosSubRubros")

   End Sub

   Public Sub CategoriasDescuentosSubRubros_D(ByVal idCategoria As Integer, ByVal idSubRubro As Integer, ByVal idRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CategoriasDescuentosSubRubros ")
         .AppendFormat(" WHERE idCategoria = '{0}'", idCategoria).AppendLine()
         If idRubro <> 0 Then
            .AppendFormat("   and idRubro = '{0}'", idRubro).AppendLine()
         End If
         If idSubRubro <> 0 Then
            .AppendFormat("   and idSubRubro = '{0}'", idSubRubro).AppendLine()
         End If

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosSubRubros")

   End Sub

   Public Sub CategoriasDescuentosSubRubros_U(ByVal idCategoria As Integer, _
                                              ByVal idSubRubro As Integer, _
                                              ByVal idRubro As Integer, _
                                              ByVal DescuentoRecargoPorc1Porc1 As Decimal)


      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CategoriasDescuentosSubRubros SET ")
         If DescuentoRecargoPorc1Porc1 > 0 Then
            .AppendLine(" DescuentoRecargoPorc1 = " & DescuentoRecargoPorc1Porc1 & "")
         Else
            .AppendLine(" DescuentoRecargoPorc1 = 0")
         End If
         .AppendFormat("WHERE (idCategoria = {0}) AND (idRubro={1} AND (idSubRubro={2})", idCategoria, idRubro, idSubRubro)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosSubRubros")

   End Sub
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT DSR.IdCategoria")
         .AppendLine("       ,DSR.IdSubRubro")
         .AppendLine("       ,SR.NombreSubRubro")
         .AppendLine("       ,DSR.IdRubro")
         .AppendLine("       ,R.NombreRubro")
         .AppendLine("       ,DSR.DescuentoRecargoPorc1")
         .AppendLine("  FROM  CategoriasDescuentosSubRubros AS DSR")
         .AppendLine("        INNER JOIN SubRubros AS SR ON DSR.IdSubRubro = SR.IdSubRubro")
         .AppendLine("        INNER JOIN Rubros AS R ON DSR.IdRubro = R.IdRubro")
      End With
   End Sub

   Public Function CategoriasDescuentosSubRubros_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY SR.NombreSubRubro")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function CategoriasDescuentosSubRubros_G_PorRubroNombre(nombre As String, exacto As Boolean) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(nombre) Then
            If exacto Then
               .AppendFormat("   AND SR.NombreSubRubro = '{0}'", nombre).AppendLine()
            Else
               .AppendFormat("   AND SR.NombreSubRubro LIKE '%{0}%'", nombre).AppendLine()
            End If
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function CategoriasDescuentosSubRubros_GetAll(ByVal idCategoria As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE DSR.IdCategoria = " & idCategoria.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetAllCategoriasDescuentosSubRubros(ByVal idCategoria As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = CategoriasDescuentosSubRubros_GetAll(idCategoria)
      dtResult.TableName = Entidades.Categoria.DescuentosSubRubrosTableName
      Return dtResult
   End Function
   Public Function CategoriasDescuentosSubRubros_G1(ByVal idCategoria As Integer, ByVal idSubRubro As Integer, ByVal idRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("WHERE (idCategoria = {0}) AND (idRubro={1} AND (idSubRubro={2})", idCategoria, idRubro, idSubRubro)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class

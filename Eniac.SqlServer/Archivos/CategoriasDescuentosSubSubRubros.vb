Public Class CategoriasDescuentosSubSubRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasDescuentosSubSubRubros_I(ByVal idCategoria As Integer, _
                                              ByVal idSubSubRubro As Integer, _
                                              ByVal idSubRubro As Integer, _
                                              ByVal idRubro As Integer, _
                                              ByVal DescuentoRecargoPorc1 As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO CategoriasDescuentosSubSubRubros")
         .AppendLine("           (idCategoria")
         .AppendLine("           ,idSubSubRubro")
         .AppendLine("           ,idSubRubro")
         .AppendLine("           ,idRubro")
         .AppendLine("           ,DescuentoRecargoPorc1)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},{1},{2},{3},{4})", idCategoria, idSubSubRubro, idSubRubro, idRubro, DescuentoRecargoPorc1)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosSubSubRubros")

   End Sub

   Public Sub CategoriasDescuentosSubSubRubros_D(ByVal idCategoria As Integer, ByVal idSubSubRubro As Integer, idSubRubro As Integer, ByVal idRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CategoriasDescuentosSubSubRubros")
         .AppendFormat(" WHERE idCategoria = '{0}'", idCategoria).AppendLine()
         If idRubro <> 0 Then
            .AppendFormat("   and idRubro = '{0}'", idRubro).AppendLine()
         End If
         If idSubRubro <> 0 Then
            .AppendFormat("   and idSubRubro = '{0}'", idSubRubro).AppendLine()
         End If
         If idSubRubro <> 0 Then
            .AppendFormat("   and idSubSubRubro = '{0}'", idSubSubRubro).AppendLine()
         End If

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosSubSubRubros")

   End Sub

   Public Sub CategoriasDescuentosSubSubRubros_U(ByVal idCategoria As Integer, _
                                              ByVal idSubSubRubro As Integer, _
                                              ByVal idSubRubro As Integer, _
                                              ByVal idRubro As Integer, _
                                              ByVal DescuentoRecargoPorc1 As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CategoriasDescuentosSubSubRubros SET ")
         If DescuentoRecargoPorc1 > 0 Then
            .AppendLine(" DescuentoRecargoPorc1 = " & DescuentoRecargoPorc1 & "")
         Else
            .AppendLine(" DescuentoRecargoPorc1 = 0")
         End If
         .AppendFormat("WHERE (idCategoria = {0}) AND (idRubro={1} AND (idSubRubro={2} AND (idSubSubRubro={3})", idCategoria, idRubro, idSubRubro, idSubSubRubro)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosSubSubRubros")

   End Sub
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0

         .AppendLine("SELECT DSSR.IdCategoria")
         .AppendLine("      ,DSSR.IdRubro")
         .AppendLine("      ,Rubros.NombreRubro")
         .AppendLine("      ,DSSR.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,DSSR.IdSubSubRubro")
         .AppendLine("      ,SSR.NombreSubSubRubro")
         .AppendLine("      ,DSSR.DescuentoRecargoPorc1")
         .AppendLine("  FROM  CategoriasDescuentosSubSubRubros AS DSSR")
         .AppendLine("        INNER JOIN SubSubRubros AS SSR ON DSSR.IdSubSubRubro = SSR.IdSubSubRubro")
         .AppendLine("        INNER JOIN SubRubros AS SR ON DSSR.IdSubRubro = SR.IdSubRubro")
         .AppendLine("        INNER JOIN Rubros ON DSSR.IdRubro = Rubros.IdRubro")
      End With

   End Sub

   Public Function CategoriasDescuentosSubSubRubros_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY SSR.NombreSubSubRubro")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function CategoriasDescuentosSubSubRubros_G_PorRubroNombre(nombre As String, exacto As Boolean) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(nombre) Then
            If exacto Then
               .AppendFormat("   AND SSR.NombreSubSubRubro = '{0}'", nombre).AppendLine()
            Else
               .AppendFormat("   AND SSR.NombreSubSubRubro LIKE '%{0}%'", nombre).AppendLine()
            End If
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function CategoriasDescuentosSubSubRubros_GetAll(ByVal idCategoria As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE DSSR.IdCategoria = " & idCategoria.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetAllCategoriasDescuentosSubSubRubros(ByVal idCategoria As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = CategoriasDescuentosSubSubRubros_GetAll(idCategoria)
      dtResult.TableName = Entidades.Categoria.DescuentosSubSubRubrosTableName
      Return dtResult
   End Function
   Public Function CategoriasDescuentosSubSubRubros_G1(ByVal idCategoria As Integer, ByVal idRubro As Integer, ByVal idSubRubro As Integer, ByVal idSubSubRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("WHERE (idCategoria = {0}) AND (idRubro={1} AND (idSubRubro={2} AND (idSubSubRubro={3})", idCategoria, idRubro, idSubRubro, idSubSubRubro)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class

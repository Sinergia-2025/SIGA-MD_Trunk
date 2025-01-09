Public Class CategoriasDescuentosRubros
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasDescuentosRubros_I(idCategoria As Integer,
                                           idRubro As Integer,
                                           descuentoRecargoPorc1 As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO CategoriasDescuentosRubros")
         .AppendLine("           (IdCategoria")
         .AppendLine("           ,IdRubro")
         .AppendLine("           ,DescuentoRecargoPorc1)")
         .AppendLine("         VALUES")
         .AppendFormat("           ({0},{1},{2})", idCategoria, idRubro, descuentoRecargoPorc1)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosRubros")
   End Sub

   Public Sub CategoriasDescuentosRubros_D(idCategoria As Integer, idRubro As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM CategoriasDescuentosRubros ")
         .AppendFormatLine(" WHERE idCategoria = '{0}'", idCategoria)
         If idRubro <> 0 Then
            .AppendFormatLine("   AND IdRubro = '{0}'", idRubro)
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosRubros")
   End Sub

   Public Sub CategoriasDescuentosRubros_U(idCategoria As Integer,
                                           idRubro As Integer,
                                           descuentoRecargoPorc1 As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CategoriasDescuentosRubros SET ")
         If descuentoRecargoPorc1 > 0 Then
            .AppendFormatLine(" DescuentoRecargoPorc1 = {0}", descuentoRecargoPorc1)
         Else
            .AppendLine(" DescuentoRecargoPorc1 = 0")
         End If
         .AppendFormat("WHERE (IdCategoria = {0}) AND (IdRubro={1})", idCategoria, idRubro)
      End With

      'Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasDescuentosRubros")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT CR.IdCategoria")
         .AppendLine("     , CR.IdRubro")
         .AppendLine("     , R.NombreRubro")
         .AppendLine("     , CR.DescuentoRecargoPorc1")
         .AppendLine("  FROM CategoriasDescuentosRubros AS CR")
         .AppendLine(" INNER JOIN Rubros AS R ON CR.IdRubro = R.IdRubro")
      End With
   End Sub

   Public Function CategoriasDescuentosRubros_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY R.NombreRubro")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CategoriasDescuentosRubros_G_PorRubroNombre(nombre As String, exacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(nombre) Then
            If exacto Then
               .AppendFormatLine("   AND R.NombreRubro = '{0}'", nombre)
            Else
               .AppendFormatLine("   AND R.NombreRubro LIKE '%{0}%'", nombre)
            End If
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function CategoriasDescuentosRubros_G1(idCategoria As Integer, idRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine("WHERE IdCategoria = {0} AND IdRubro={1}", idCategoria, idRubro)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function CategoriasDescuentosRubros_GetAll(idCategoria As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If idCategoria <> 0 Then
            .AppendFormatLine("   AND CR.IdCategoria = {0}", idCategoria)
         End If
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetAllCategoriasDescuentosRubros(idCategoria As Integer) As DataTable
      Dim dtResult As DataTable
      dtResult = CategoriasDescuentosRubros_GetAll(idCategoria)
      dtResult.TableName = Entidades.Categoria.DescuentosRubrosTableName
      Return dtResult
   End Function

End Class
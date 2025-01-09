Public Class CRMCategoriasNovedades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMCategoriasNovedades_I(idCategoriaNovedad As Integer,
                                       nombreCategoriaNovedad As String,
                                       posicion As Integer,
                                       idTipoNovedad As String,
                                       porDefecto As Boolean,
                                       reporta As String,
                                       color As Integer?,
                                       publicarEnWeb As Boolean,
                                       idTipoCategoriaNovedad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormatLine("INSERT INTO CRMCategoriasNovedades ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                           Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.Posicion.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.PorDefecto.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.Reporta.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.Color.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.PublicarEnWeb.ToString(),
                           Entidades.CRMCategoriaNovedad.Columnas.IdTipoCategoriaNovedad.ToString())
         .AppendFormat("     VALUES ({0}, '{1}', {2}, '{3}', {4}, '{5}', {6}, {7}, {8})",
                       idCategoriaNovedad, nombreCategoriaNovedad, posicion, idTipoNovedad, GetStringFromBoolean(porDefecto), reporta,
                       GetStringFromNumber(color), GetStringFromBoolean(publicarEnWeb), idTipoCategoriaNovedad)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMCategoriasNovedades_U(idCategoriaNovedad As Integer,
                                       nombreCategoriaNovedad As String,
                                       posicion As Integer,
                                       idTipoNovedad As String,
                                       porDefecto As Boolean,
                                       reporta As String,
                                       color As Integer?,
                                       publicarEnWeb As Boolean,
                                       idTipoCategoriaNovedad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CRMCategoriasNovedades ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString(), nombreCategoriaNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCategoriaNovedad.Columnas.Posicion.ToString(), posicion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCategoriaNovedad.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCategoriaNovedad.Columnas.Reporta.ToString(), reporta)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCategoriaNovedad.Columnas.Color.ToString(), GetStringFromNumber(color))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCategoriaNovedad.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWeb))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCategoriaNovedad.Columnas.IdTipoCategoriaNovedad.ToString(), idTipoCategoriaNovedad)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString(), idCategoriaNovedad)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMCategoriasNovedades_D(IdCategoriaNovedad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CRMCategoriasNovedades WHERE {0} = {1}", Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString(), IdCategoriaNovedad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT CN.*, TN.NombreTipoNovedad, TCN.NombreTipoCategoriaNovedad")
         .AppendLine("  FROM CRMCategoriasNovedades AS CN")
         .AppendLine(" INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = CN.IdTipoNovedad")
         .AppendLine(" INNER JOIN CRMTiposCategoriasNovedades TCN ON CN.IdTipoCategoriaNovedad = TCN.IdTipoCategoriaNovedad")
      End With
   End Sub

   Public Function CRMCategoriasNovedades_GA() As DataTable
      Return CRMCategoriasNovedades_GA(String.Empty, False)
   End Function
   Public Function CRMCategoriasNovedades_GA(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormat(" WHERE CN.IdTipoNovedad = '{0}'", idTipoNovedad).AppendLine()
         End If
         If ordenarPosicion Then
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, CN.Posicion")
         Else
            .AppendFormat(" ORDER BY TN.NombreTipoNovedad, CN.NombreCategoriaNovedad")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMCategoriasNovedades_G1(IdCategoriaNovedad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE CN.{0} = {1}", Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString(), IdCategoriaNovedad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function CRMCategoriasNovedades_GxCodigo(IdCategoriaNovedad As Integer, idTipoNovedad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and CN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If IdCategoriaNovedad <> 0 Then
            .AppendFormat(" and CN.{0} = {1}", Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString(), IdCategoriaNovedad)
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      ElseIf columna = "NombreTipoCategoriaNovedad" Then
         columna = "TCN." + columna
      Else
         columna = "CN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString(), "CRMCategoriasNovedades"))
   End Function

   Public Function CRMCategoriasNovedades_PorNombre(nombreCategoria As String, nombreExacto As Boolean, idTipoNovedad As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and CN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If nombreExacto Then
            .AppendFormatLine(" and NombreCategoriaNovedad = '{0}'", nombreCategoria)
         Else
            .AppendFormatLine(" and NombreCategoriaNovedad LIKE '%{0}%'", nombreCategoria)
         End If
      End With
      Return GetDataTable(stb)
   End Function
End Class
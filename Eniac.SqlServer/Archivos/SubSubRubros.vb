Imports System.Text

Public Class SubSubRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SubSubRubros_I(idSubRubro As Integer,
                             idSubSubRubro As Integer,
                             nombreSubSubRubro As String,
                             idSubSubRubroTiendaNube As String,
                             idSubSubRubroMercadoLibre As String,
                             idSubSubRubroArborea As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO SubSubRubros (")
         .AppendLine(" IdSubRubro, ")
         .AppendLine(" IdSubSubRubro, ")
         .AppendLine(" NombreSubSubRubro ")
         .AppendLine(" ,IdSubSubRubroTiendaNube")
         .AppendLine(" ,IdSubSubRubroMercadoLibre")
         .AppendLine(" ,IdSubSubRubroArborea")
         .AppendLine(" ) VALUES (")
         .AppendLine(idSubRubro.ToString() & ", ")
         .AppendLine(idSubSubRubro.ToString() & ", ")
         .AppendLine("'" & nombreSubSubRubro & "'")


         If Not String.IsNullOrEmpty(idSubSubRubroTiendaNube) Then
            .AppendFormatLine(" , '{0}' ", idSubSubRubroTiendaNube)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(idSubSubRubroMercadoLibre) Then
            .AppendFormatLine(" , '{0}' ", idSubSubRubroMercadoLibre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(idSubSubRubroArborea) Then
            .AppendFormatLine(" , '{0}' ", idSubSubRubroArborea)
         Else
            .AppendFormatLine(" , NULL")
         End If
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SubSubRubros_U(idSubRubro As Integer,
                             idSubSubRubro As Integer,
                             nombreSubSubRubro As String,
                             idSubSubRubroTiendaNube As String,
                             idSubSubRubroMercadoLibre As String,
                             idSubSubRubroArborea As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE SubSubRubros ")
         .AppendLine("   SET NombreSubSubRubro = '" & nombreSubSubRubro & "'")

         If Not String.IsNullOrEmpty(idSubSubRubroTiendaNube) Then
            .AppendFormatLine("  ,IdSubSubRubroTiendaNube = '{0}'", idSubSubRubroTiendaNube)
         Else
            .AppendFormatLine("  ,IdSubSubRubroTiendaNube = NULL")
         End If
         If Not String.IsNullOrEmpty(idSubSubRubroMercadoLibre) Then
            .AppendFormatLine("  ,IdSubSubRubroMercadoLibre = '{0}'", idSubSubRubroMercadoLibre)
         Else
            .AppendFormatLine("  ,IdSubSubRubroMercadoLibre = NULL")
         End If
         If Not String.IsNullOrEmpty(idSubSubRubroArborea) Then
            .AppendFormatLine("  ,idSubSubRubroArborea = '{0}'", idSubSubRubroArborea)
         Else
            .AppendFormatLine("  ,idSubSubRubroArborea = NULL")
         End If
         .AppendLine(" WHERE IdSubRubro = " & idSubRubro.ToString())
         .AppendLine("   AND idSubSubRubro = " & idSubSubRubro.ToString())
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SubSubRubros_D(idSubRubro As Integer,
                             idSubSubRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM SubSubRubros ")
         .AppendLine(" WHERE IdSubRubro = " & IdSubRubro.ToString())
         .AppendLine("   AND idSubSubRubro = " & idSubSubRubro.ToString())
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT S.IdSubSubRubro")
         .AppendLine("      ,S.NombreSubSubRubro")
         .AppendLine("      ,SR.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,SR.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendFormat("      ,S.{0}", Entidades.SubSubRubro.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("      ,S.IdSubSubRubroTiendaNube")
         .AppendLine("      ,S.IdSubSubRubroMercadoLibre")
         .AppendLine("      ,S.IdSubSubRubroArborea")
         .AppendLine("  FROM SubSubRubros S ")
         .AppendLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = S.IdSubRubro")
         .AppendLine("  LEFT JOIN Rubros R ON R.IdRubro = SR.IdRubro")
      End With
   End Sub

   Public Function SubSubRubros_GA(fechaActualizacionDesde As DateTime?) As DataTable
      Return SubSubRubros_G(fechaActualizacionDesde:=fechaActualizacionDesde, idSubRubro:=0, idSubSubRubro:=0, nombreSubSubRubro:=String.Empty, subRubros:=Nothing)
   End Function

   Public Function SubSubRubros_GA(idSubRubro As Integer) As DataTable
      Return SubSubRubros_G(fechaActualizacionDesde:=Nothing, idSubRubro:=idSubRubro, idSubSubRubro:=0, nombreSubSubRubro:=String.Empty, subRubros:=Nothing)
   End Function

   Public Function SubSubRubros_G1(idSubSubRubro As Integer) As DataTable
      Return SubSubRubros_G(fechaActualizacionDesde:=Nothing, idSubRubro:=0, idSubSubRubro:=idSubSubRubro, nombreSubSubRubro:=String.Empty, subRubros:=Nothing)
   End Function
   Public Function SubSubRubros_G(idSubRubro As Integer, idSubSubRubro As Integer, nombreSubSubRubro As String, subRubros As Entidades.SubRubro()) As DataTable
      Return SubSubRubros_G(fechaActualizacionDesde:=Nothing, idSubRubro:=idSubRubro, idSubSubRubro:=idSubSubRubro, nombreSubSubRubro:=nombreSubSubRubro, subRubros:=subRubros)
   End Function
   Public Function SubSubRubros_G(fechaActualizacionDesde As DateTime?, idSubRubro As Integer, idSubSubRubro As Integer, nombreSubSubRubro As String, subRubros As Entidades.SubRubro()) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")

         If Not String.IsNullOrEmpty(nombreSubSubRubro) Then
            .AppendLine("	AND S.NombreSubSubRubro LIKE '%" & nombreSubSubRubro & "%' ")
         End If

         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine("   AND SR.{0} > '{1}'",
                              Entidades.SubSubRubro.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True))
         End If
         If idSubSubRubro <> 0 Then
            .AppendFormatLine("   AND S.IdSubSubRubro = {0}", idSubSubRubro)
         End If
         If idSubRubro <> 0 Then
            .AppendFormatLine("   AND S.IdSubRubro = {0}", idSubRubro)
         End If
         GetListaSubRubrosMultiples(myQuery, subRubros, "S")

         .AppendLine(" ORDER BY R.NombreRubro, SR.NombreSubRubro, S.NombreSubSubRubro")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function SubSubRubros_GetNombreUnido() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT S.IdSubSubRubro")
         .AppendLine("      ,R.NombreSubRubro + ' - ' + S.NombreSubSubRubro AS NombreCompleto")
         .AppendLine("  FROM SubSubRubros S ")
         .AppendLine("  INNER JOIN SubRubros R ON R.IdSubRubro = S.IdSubRubro")
         .AppendLine(" ORDER BY 2")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Overloads Function GetCodigoMaximo(idSubRubro As Integer) As Long
      Return GetCodigoMaximo("IdSubSubRubro", "SubSubRubros", If(idSubRubro = 0, "", String.Format("IdSubRubro = {0}", idSubRubro)))
   End Function

   Public Sub GuardarIdSubSubRubroTiendaNube(idSubSubRubro As Integer, idSubSubRubroTiendaNube As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE R SET R.IdSubSubRubroTiendaNube = '{0}' FROM SubSubRubros R ", idSubSubRubroTiendaNube)
         .AppendFormatLine("	WHERE IdSubSubRubro = {0}", idSubSubRubro)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Function GetSubSubRubrosTiendaWeb(idTiendaWeb As Entidades.TiendasWeb) As DataTable
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("SELECT SSR.IdSubSubRubro")
         .AppendFormatLine("	   , SSR.NombreSubSubRubro")
         .AppendFormatLine("	   , SSR.IdSubSubRubro{0}", idTiendaWeb.ToString())
         .AppendFormatLine("	   , SR.IdSubRubro{0}", idTiendaWeb.ToString())
         .AppendFormatLine("  FROM SubSubRubros SSR")
         .AppendFormatLine(" INNER JOIN Productos P ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine(" INNER JOIN SubRubros SR ON SSR.IdSubRubro = SR.IdSubRubro")
         .AppendFormatLine(" WHERE P.Activo = 'True'")
         .AppendFormatLine("   AND P.PublicarEn{0} = 'True'", idTiendaWeb.ToString())
         .AppendFormatLine("GROUP BY SSR.IdSubSubRubro, SSR.NombreSubSubRubro, SSR.IdSubSubRubro{0}, SR.IdSubRubro{0}", idTiendaWeb.ToString())
      End With
      Return GetDataTable(query)
   End Function

   Public Sub GuardarIdSubSubRubroTiendaWeb(idTiendaWeb As String, idSubSubRubro As Integer, idSubSubRubroTiendaWeb As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE R SET R.IdSubSubRubro{1} = '{0}' FROM SubSubRubros R ", idSubSubRubroTiendaWeb, idTiendaWeb)
         .AppendFormatLine("	WHERE IdSubSubRubro = {0}", idSubSubRubro)
      End With
      Me.Execute(query.ToString())
   End Sub

End Class
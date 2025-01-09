Imports System.Text

Public Class SubRubros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SubRubros_I(idRubro As Integer,
                          idSubRubro As Integer,
                          nombreSubRubro As String,
                          descuentoRecargoPorc1 As Decimal,
                          unidHasta1 As Decimal,
                          unidHasta2 As Decimal,
                          unidHasta3 As Decimal,
                          unidHasta4 As Decimal,
                          unidHasta5 As Decimal,
                          uHPorc1 As Decimal,
                          uHPorc2 As Decimal,
                          uHPorc3 As Decimal,
                          uHPorc4 As Decimal,
                          uHPorc5 As Decimal,
                          descuentoRecargoPorc2 As Decimal,
                          codigoExportacion As String,
                          idSubRubroTiendaNube As String,
                          idSubRubroMercadoLibre As String,
                          idSubRubroArborea As String,
                          grupoAtributo01 As Integer?,
                          tipoAtributo01 As Short?,
                          grupoAtributo02 As Integer?,
                          tipoAtributo02 As Short?,
                          grupoAtributo03 As Integer?,
                          tipoAtributo03 As Short?,
                          grupoAtributo04 As Integer?,
                          tipoAtributo04 As Short?)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO SubRubros ")
         .AppendLine(" (IdRubro")
         .AppendLine(" ,IdSubRubro")
         .AppendLine(" ,NombreSubRubro")
         .AppendLine(" ,DescuentoRecargoPorc1")
         .AppendLine(" ,UnidHasta1")
         .AppendLine(" ,UnidHasta2")
         .AppendLine(" ,UnidHasta3")
         .AppendLine(" ,UnidHasta4")
         .AppendLine(" ,UnidHasta5")
         .AppendLine(" ,UHPorc1")
         .AppendLine(" ,UHPorc2")
         .AppendLine(" ,UHPorc3")
         .AppendLine(" ,UHPorc4")
         .AppendLine(" ,UHPorc5")
         .AppendLine(" ,DescuentoRecargoPorc2")
         .AppendLine(" ,IdSubRubroTiendaNube")
         .AppendLine(" ,IdSubRubroMercadoLibre")
         .AppendLine(" ,IdSubRubroArborea")
         .AppendLine(" ,CodigoExportacion")
         '-- REQ-34666.- -----------------------------
         .AppendLine(" ,GrupoAtributo01")
         .AppendLine(" ,TipoAtributo01 ")
         .AppendLine(" ,GrupoAtributo02")
         .AppendLine(" ,TipoAtributo02 ")
         .AppendLine(" ,GrupoAtributo03")
         .AppendLine(" ,TipoAtributo03 ")
         .AppendLine(" ,GrupoAtributo04")
         .AppendLine(" ,TipoAtributo04 ")
         '--------------------------------------------
         .AppendLine(" ) VALUES (")
         .AppendFormatLine("  {0}", idRubro)
         .AppendFormatLine(", {0}", idSubRubro)
         .AppendFormatLine(",'{0}'", nombreSubRubro)
         .AppendFormatLine(", {0}", descuentoRecargoPorc1)
         .AppendFormatLine(", {0}", unidHasta1)
         .AppendFormatLine(", {0}", unidHasta2)
         .AppendFormatLine(", {0}", unidHasta3)
         .AppendFormatLine(", {0}", unidHasta4)
         .AppendFormatLine(", {0}", unidHasta5)
         .AppendFormatLine(", {0}", uHPorc1)
         .AppendFormatLine(", {0}", uHPorc2)
         .AppendFormatLine(", {0}", uHPorc3)
         .AppendFormatLine(", {0}", uHPorc4)
         .AppendFormatLine(", {0}", uHPorc5)
         .AppendFormatLine(", {0}", descuentoRecargoPorc2)

         If Not String.IsNullOrEmpty(idSubRubroTiendaNube) Then
            .AppendFormatLine(" , '{0}' ", idSubRubroTiendaNube)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(idSubRubroMercadoLibre) Then
            .AppendFormatLine(" , '{0}' ", idSubRubroMercadoLibre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(idSubRubroArborea) Then
            .AppendFormatLine(" , '{0}' ", idSubRubroArborea)
         Else
            .AppendFormatLine(" , NULL")
         End If
         .AppendFormatLine(", '{0}'", codigoExportacion)
         '-- REQ-34666.- ------------------------------------------------------
         If grupoAtributo01 > 0 Then
            .AppendFormatLine("      ,{0}", grupoAtributo01)
            .AppendFormatLine("      ,{0}", tipoAtributo01)
         Else
            .AppendFormatLine("      ,NULL")
            .AppendFormatLine("      ,NULL")
         End If
         If grupoAtributo02 > 0 Then
            .AppendFormatLine("      ,{0}", grupoAtributo02)
            .AppendFormatLine("      ,{0}", tipoAtributo02)
         Else
            .AppendFormatLine("      ,NULL")
            .AppendFormatLine("      ,NULL")
         End If
         If grupoAtributo03 > 0 Then
            .AppendFormatLine("      ,{0}", grupoAtributo03)
            .AppendFormatLine("      ,{0}", tipoAtributo03)
         Else
            .AppendFormatLine("      ,NULL")
            .AppendFormatLine("      ,NULL")
         End If
         If grupoAtributo04 > 0 Then
            .AppendFormatLine("      ,{0}", grupoAtributo04)
            .AppendFormatLine("      ,{0}", tipoAtributo04)
         Else
            .AppendFormatLine("      ,NULL")
            .AppendFormatLine("      ,NULL")
         End If
         '---------------------------------------------------------------------

         .AppendFormatLine(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SubRubros_U(idRubro As Integer,
                          idSubRubro As Integer,
                          nombreSubRubro As String,
                          descuentoRecargoPorc1 As Decimal,
                          unidHasta1 As Decimal,
                          unidHasta2 As Decimal,
                          unidHasta3 As Decimal,
                          unidHasta4 As Decimal,
                          unidHasta5 As Decimal,
                          uHPorc1 As Decimal,
                          uHPorc2 As Decimal,
                          uHPorc3 As Decimal,
                          uHPorc4 As Decimal,
                          uHPorc5 As Decimal,
                          descuentoRecargoPorc2 As Decimal,
                          codigoExportacion As String,
                          idSubRubroTiendaNube As String,
                          idSubRubroMercadoLibre As String,
                          idSubRubroArborea As String,
                          grupoAtributo01 As Integer?,
                          tipoAtributo01 As Short?,
                          grupoAtributo02 As Integer?,
                          tipoAtributo02 As Short?,
                          grupoAtributo03 As Integer?,
                          tipoAtributo03 As Short?,
                          grupoAtributo04 As Integer?,
                          tipoAtributo04 As Short?)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormatLine("UPDATE SubRubros ")
         .AppendFormatLine("   SET NombreSubRubro = '{0}'", nombreSubRubro)
         .AppendFormatLine("      ,DescuentoRecargoPorc1 = {0}", descuentoRecargoPorc1)
         .AppendFormatLine("      ,UnidHasta1 = {0}", unidHasta1)
         .AppendFormatLine("      ,UnidHasta2 = {0}", unidHasta2)
         .AppendFormatLine("      ,UnidHasta3 = {0}", unidHasta3)
         .AppendFormatLine("      ,UnidHasta4 = {0}", unidHasta4)
         .AppendFormatLine("      ,UnidHasta5 = {0}", unidHasta5)
         .AppendFormatLine("      ,UHPorc1 = {0}", uHPorc1)
         .AppendFormatLine("      ,UHPorc2 = {0}", uHPorc2)
         .AppendFormatLine("      ,UHPorc3 = {0}", uHPorc3)
         .AppendFormatLine("      ,UHPorc4 = {0}", uHPorc4)
         .AppendFormatLine("      ,UHPorc5 = {0}", uHPorc5)
         .AppendFormatLine("      ,DescuentoRecargoPorc2 = {0}", descuentoRecargoPorc2)
         .AppendFormatLine("      ,codigoExportacion = '{0}'", codigoExportacion)

         If Not String.IsNullOrEmpty(idSubRubroTiendaNube) Then
            .AppendFormatLine("      ,IdSubRubroTiendaNube = '{0}'", idSubRubroTiendaNube)
         Else
            .AppendFormatLine("      ,IdSubRubroTiendaNube = NULL")
         End If
         If Not String.IsNullOrEmpty(idSubRubroMercadoLibre) Then
            .AppendFormatLine("      ,IdSubRubroMercadoLibre = '{0}'", idSubRubroMercadoLibre)
         Else
            .AppendFormatLine("      ,IdSubRubroMercadoLibre = NULL")
         End If
         If Not String.IsNullOrEmpty(idSubRubroArborea) Then
            .AppendFormatLine("      ,idSubRubroArborea = '{0}'", idSubRubroArborea)
         Else
            .AppendFormatLine("      ,idSubRubroArborea = NULL")
         End If

         '-- REQ-34666.- ------------------------------------------------------
         If grupoAtributo01 > 0 Then
            .AppendFormatLine("      ,GrupoAtributo01 = {0}", grupoAtributo01)
            .AppendFormatLine("      ,TipoAtributo01 = {0}", tipoAtributo01)
         Else
            .AppendFormatLine("      ,GrupoAtributo01 = NULL")
            .AppendFormatLine("      ,TipoAtributo01 = NULL")
         End If
         If grupoAtributo02 > 0 Then
            .AppendFormatLine("      ,GrupoAtributo02 = {0}", grupoAtributo02)
            .AppendFormatLine("      ,TipoAtributo02 = {0}", tipoAtributo02)
         Else
            .AppendFormatLine("      ,GrupoAtributo02 = NULL")
            .AppendFormatLine("      ,TipoAtributo02 = NULL")
         End If
         If grupoAtributo03 > 0 Then
            .AppendFormatLine("      ,GrupoAtributo03 = {0}", grupoAtributo03)
            .AppendFormatLine("      ,TipoAtributo03 = {0}", tipoAtributo03)
         Else
            .AppendFormatLine("      ,GrupoAtributo03 = NULL")
            .AppendFormatLine("      ,TipoAtributo03 = NULL")
         End If
         If grupoAtributo04 > 0 Then
            .AppendFormatLine("      ,GrupoAtributo04 = {0}", grupoAtributo04)
            .AppendFormatLine("      ,TipoAtributo04 = {0}", tipoAtributo04)
         Else
            .AppendFormatLine("      ,GrupoAtributo04 = NULL")
            .AppendFormatLine("      ,TipoAtributo04 = NULL")
         End If
         '---------------------------------------------------------------------
         .AppendFormatLine(" WHERE idRubro = {0}", idRubro)
         .AppendFormatLine("   AND idSubRubro = {0}", idSubRubro)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SubRubros_D(ByVal idRubro As Integer, _
                          ByVal idSubRubro As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM SubRubros ")
         .AppendLine(" WHERE idRubro = " & idRubro.ToString())
         .AppendLine("   AND idSubRubro = " & idSubRubro.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SubRubros")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT S.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,S.IdSubRubro")
         .AppendLine("      ,S.NombreSubRubro")
         .AppendLine("      ,S.DescuentoRecargoPorc1")
         .AppendLine("      ,R.NombreRubro + ' - ' + S.NombreSubRubro AS NombreRubroSubRubro")
         .AppendLine("      ,S.UnidHasta1")
         .AppendLine("      ,S.UnidHasta2")
         .AppendLine("      ,S.UnidHasta3")
         .AppendLine("      ,S.UnidHasta4")
         .AppendLine("      ,S.UnidHasta5")
         .AppendLine("      ,S.UHPorc1")
         .AppendLine("      ,S.UHPorc2")
         .AppendLine("      ,S.UHPorc3")
         .AppendLine("      ,S.UHPorc4")
         .AppendLine("      ,S.UHPorc5")
         .AppendFormatLine("    ,S.{0}", Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString())
         .AppendLine("      ,S.DescuentoRecargoPorc2")
         .AppendLine("      ,S.IdSubRubroTiendaNube")
         .AppendLine("      ,S.IdSubRubroMercadoLibre")
         .AppendLine("      ,S.IdSubRubroArborea")
         .AppendLine("      ,S.CodigoExportacion")
         '-- REQ-34666.- -----------------------------------------------
         .AppendLine("      ,S.GrupoAtributo01")
         .AppendLine("      ,S.TipoAtributo01")
         .AppendLine("      ,S.GrupoAtributo02")
         .AppendLine("      ,S.TipoAtributo02")
         .AppendLine("      ,S.GrupoAtributo03")
         .AppendLine("      ,S.TipoAtributo03")
         .AppendLine("      ,S.GrupoAtributo04")
         .AppendLine("      ,S.TipoAtributo04")
         '-- REQ-35210.- ----------------------------------------------------------
         .AppendFormatLine(" , (CASE WHEN S.GrupoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN S.TipoAtributo01  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine(" + (CASE WHEN S.GrupoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN S.TipoAtributo02  IS NULL THEN 0 ELSE 1 END) ")
         .AppendFormatLine(" + (CASE WHEN S.GrupoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN S.TipoAtributo03  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine(" + (CASE WHEN S.GrupoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN S.TipoAtributo04  IS NULL THEN 0 ELSE 1 END) AS Atributos")
         '--------------------------------------------------------------
         .AppendLine("  FROM SubRubros S ")
         .AppendLine("  INNER JOIN Rubros R ON R.IdRubro = S.IdRubro")
      End With
   End Sub

   Public Function SubRubros_GA(fechaActualizacionDesde As DateTime?, idRubro As Integer, rubros As Entidades.Rubro()) As DataTable
      Return SubRubros_G(fechaActualizacionDesde, 0, "", idRubro, rubros, False)
   End Function

   Public Function SubRubros_GA(idSubRubro As Integer, nombreSubRubro As String, rubros As Entidades.Rubro(), nombreSubRubroExacto As Boolean) As DataTable
      Return SubRubros_G(Nothing, idSubRubro, nombreSubRubro, 0, rubros, nombreSubRubroExacto)
   End Function

   Public Function SubRubros_G(fechaActualizacionDesde As DateTime?, idSubRubro As Integer, nombreSubRubro As String, idRubro As Integer, rubros As Entidades.Rubro(), nombreSubRubroExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSubRubro <> 0 Then
            .AppendFormatLine("   AND S.IdSubRubro = {0}", idSubRubro)
         End If
         If Not String.IsNullOrWhiteSpace(nombreSubRubro) Then
            If nombreSubRubroExacto Then
               .AppendFormatLine("	  AND NombreSubRubro = '{0}'", nombreSubRubro)
            Else
               .AppendFormatLine("	  AND NombreSubRubro LIKE '%{0}%'", nombreSubRubro)
            End If
         End If
         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine("   AND S.{0} > '{1}'",
                              Entidades.SubRubro.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True))
         End If
         If idRubro > 0 Then
            .AppendFormatLine("   AND S.{0} = {1}", Entidades.SubRubro.Columnas.IdRubro.ToString(), idRubro)
         End If
         GetListaRubrosMultiples(myQuery, rubros, "S")
         .AppendLine(" ORDER BY R.NombreRubro, S.NombreSubRubro")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SubRubros_G1(IdSubRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE S.IdSubRubro = " & IdSubRubro.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function AtributoSubRubroProducto(IdSubRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT PD.IdProducto, SR.IdSubRubro   FROM SubRubros AS SR ")
         .AppendLine("	INNER JOIN Productos AS PD ON  PD.IdSubRubro = SR.IdSubRubro")
         .AppendFormatLine(" WHERE SR.IdSubRubro = {0}", IdSubRubro.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function TieneAtributoSubRubro(IdSubRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT (CASE WHEN SBR.GrupoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo01  IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("  + (CASE WHEN SBR.GrupoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo02  IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("  + (CASE WHEN SBR.GrupoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo03  IS NULL THEN 0 ELSE 1 END)")
         .AppendLine("  + (CASE WHEN SBR.GrupoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo04  IS NULL THEN 0 ELSE 1 END) AS AtributoSubRubro")
         .AppendLine("  FROM SubRubros AS SBR ")
         .AppendFormatLine(" WHERE SBR.IdSubRubro = {0}", IdSubRubro.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function SubRubros_GetNombreUnido() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT S.IdSubRubro")
         .AppendLine("      ,R.NombreRubro + ' - ' + S.NombreSubRubro AS NombreCompleto")
         .AppendLine("  FROM SubRubros S ")
         .AppendLine("  INNER JOIN Rubros R ON R.IdRubro = S.IdRubro")
         .AppendLine(" ORDER BY 2")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Sub GuardarIdSubRubroTiendaNube(idSubRubro As Integer, idSubRubroTiendaNube As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE SR SET SR.IdSubRubroTiendaNube = '{0}' FROM SubRubros SR ", idSubRubroTiendaNube)
         .AppendFormatLine("	WHERE IdSubRubro = {0}", idSubRubro)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Function GetSubRubrosTiendaWeb(idTiendaWeb As Entidades.TiendasWeb) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT SR.IdSubRubro")
         .AppendFormatLine("	   , SR.NombreSubRubro")
         .AppendFormatLine("	   , SR.IdSubRubro{0}", idTiendaWeb.ToString())
         .AppendFormatLine("	   , R.IdRubro{0}", idTiendaWeb.ToString())
         .AppendFormatLine("  FROM SubRubros SR")
         .AppendFormatLine(" INNER JOIN Productos P ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine(" INNER JOIN Rubros R ON SR.IdRubro= R.IdRubro")
         .AppendFormatLine(" WHERE P.Activo = 'True'")
         .AppendFormatLine("	 AND P.PublicarEn{0} = 'True'", idTiendaWeb.ToString())
         .AppendFormatLine(" GROUP BY SR.IdSubRubro, SR.NombreSubRubro, SR.IdSubRubro{0}, R.IdRubro{0}", idTiendaWeb.ToString())
      End With
      Return GetDataTable(query)
   End Function

   Public Sub GuardarIdSubRubroTiendaWeb(idTiendaWeb As String, idSubRubro As Integer, idSubRubroTiendaWeb As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE SR SET SR.IdSubRubro" + idTiendaWeb + " = '{0}' FROM SubRubros SR ", idSubRubroTiendaWeb)
         .AppendFormatLine("	WHERE IdSubRubro = {0}", idSubRubro)
      End With
      Me.Execute(query.ToString())
   End Sub

End Class
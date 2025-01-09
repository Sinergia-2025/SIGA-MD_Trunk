Public Class Versiones
   Inherits Comunes

   Private Const CantidadSinTop As Integer = 0

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Versiones_I(idAplicacion As String,
                          nroVersion As String,
                          versionFecha As Date,
                          idAplicacionBase As String,
                          nroVersionAplicacionBase As String,
                          versionFramework As String,
                          versionReportViewer As String,
                          versionLenguaje As String)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO Versiones")
         .AppendLine("           (IdAplicacion")
         .AppendLine("           ,NroVersion")
         .AppendLine("           ,VersionFecha")
         .AppendLine("           ,IdAplicacionBase")
         .AppendLine("           ,NroVersionAplicacionBase")
         .AppendLine("           ,VersionFramework")
         .AppendLine("           ,VersionReportViewer")
         .AppendLine("           ,VersionLenguaje")
         .AppendLine(")     VALUES (")
         .AppendFormatLine("  '{0}'", idAplicacion)
         .AppendFormatLine(" ,'{0}'", nroVersion)
         .AppendFormatLine(" ,'{0}'", ObtenerFecha(versionFecha, True))

         If Not String.IsNullOrEmpty(idAplicacionBase) Then
            .AppendFormatLine(" ,'{0}'", idAplicacionBase)
            .AppendFormatLine(" ,'{0}'", nroVersionAplicacionBase)
         Else
            .AppendFormatLine(" ,NULL")
            .AppendFormatLine(" ,NULL")
         End If

         .AppendFormatLine(" ,'{0}'", versionFramework)
         .AppendFormatLine(" ,'{0}'", versionReportViewer)
         .AppendFormatLine(" ,'{0}'", versionLenguaje)

         .Append(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Versiones_U(idAplicacion As String,
                          nroVersion As String,
                          versionFecha As Date,
                          idAplicacionBase As String,
                          nroVersionAplicacionBase As String,
                          versionFramework As String,
                          versionReportViewer As String,
                          versionLenguaje As String)


      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("UPDATE Versiones")
         .Append("   SET ")
         .AppendFormat("      VersionFecha = '{0}'", ObtenerFecha(versionFecha, True))
         If Not String.IsNullOrEmpty(idAplicacionBase) Then
            .AppendFormat("      ,IdAplicacionBase = '{0}'", idAplicacionBase)
            .AppendFormat("      ,NroVersionAplicacionBase = '{0}'", nroVersionAplicacionBase)
         Else
            .AppendFormat("      ,IdAplicacionBase = NULL")
            .AppendFormat("      ,NroVersionAplicacionBase = NULL")
         End If

         .AppendFormat("      ,VersionFramework = '{0}'", versionFramework)
         .AppendFormat("      ,VersionReportViewer = '{0}'", versionReportViewer)
         .AppendFormat("      ,VersionLenguaje = '{0}'", versionLenguaje)
         .AppendFormat(" WHERE IdAplicacion = '{0}'", idAplicacion)
         .AppendFormat(" AND NroVersion = '{0}'", nroVersion)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Versiones_M(idAplicacion As String,
                          nroVersion As String,
                          versionFecha As Date,
                          idAplicacionBase As String,
                          nroVersionAplicacionBase As String,
                          versionFramework As String,
                          versionReportViewer As String,
                          versionLenguaje As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS D", Entidades.Version.NombreTabla)
         .AppendFormatLine("        USING (SELECT '{1}' AS {0}", Entidades.Version.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.Version.Columnas.NroVersion.ToString(), nroVersion)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.Version.Columnas.VersionFecha.ToString(), ObtenerFecha(versionFecha, True))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.Version.Columnas.IdAplicacionBase.ToString(), GetStringParaQueryConComillas(idAplicacionBase))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.Version.Columnas.NroVersionAplicacionBase.ToString(), GetStringParaQueryConComillas(nroVersionAplicacionBase))
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.Version.Columnas.VersionFramework.ToString(), versionFramework)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.Version.Columnas.VersionReportViewer.ToString(), versionReportViewer)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.Version.Columnas.VersionLenguaje.ToString(), versionLenguaje)
         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1}", Entidades.Version.Columnas.IdAplicacion.ToString(), Entidades.Version.Columnas.NroVersion.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}, D.{2} = O.{2}, D.{3} = O.{3}, D.{4} = O.{4}, D.{5} = O.{5}",
                           Entidades.Version.Columnas.VersionFecha.ToString(),
                           Entidades.Version.Columnas.IdAplicacionBase.ToString(),
                           Entidades.Version.Columnas.NroVersionAplicacionBase.ToString(),
                           Entidades.Version.Columnas.VersionFramework.ToString(),
                           Entidades.Version.Columnas.VersionReportViewer.ToString(),
                           Entidades.Version.Columnas.VersionLenguaje.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}) VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4}, O.{5}, O.{6}, O.{7})",
                           Entidades.Version.Columnas.IdAplicacion.ToString(),
                           Entidades.Version.Columnas.NroVersion.ToString(),
                           Entidades.Version.Columnas.VersionFecha.ToString(),
                           Entidades.Version.Columnas.IdAplicacionBase.ToString(),
                           Entidades.Version.Columnas.NroVersionAplicacionBase.ToString(),
                           Entidades.Version.Columnas.VersionFramework.ToString(),
                           Entidades.Version.Columnas.VersionReportViewer.ToString(),
                           Entidades.Version.Columnas.VersionLenguaje.ToString())
         .AppendFormatLine(";")

      End With
      Execute(myQuery)
   End Sub

   Public Sub Versiones_D(idAplicacion As String, Version As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM Versiones")
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.Version.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.Version.Columnas.NroVersion.ToString(), Version)
      End With

      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, top As Integer)
      With stb
         'Si requiere traer un TOP (por ejemplo TOP 1) el parametro top será mayor a 0, entonces lo agrego al query
         'Si NO requiere traer un TOP el parametro top será 0, y NO lo agrego al query
         Dim strTop As String = If(top = CantidadSinTop, String.Empty, String.Format("TOP {0} ", top))
         .AppendFormatLine("SELECT {0}V.IdAplicacion", strTop)
         .AppendLine("     , V.NroVersion")
         .AppendLine("     , V.VersionFecha")
         .AppendLine("     , V.IdAplicacionBase")
         .AppendLine("     , V.NroVersionAplicacionBase")
         .AppendLine("     , V.VersionFramework")
         .AppendLine("     , V.VersionReportViewer")
         .AppendLine("     , V.VersionLenguaje")
         .AppendLine("  FROM Versiones V")
      End With
   End Sub

   Public Function Versiones_GA(idAplicacion As String, versionDesde As String, versionHasta As String) As DataTable
      Return Versiones_G(idAplicacion, versionDesde, versionHasta, top:=CantidadSinTop, groupByNroVersion:=False)
   End Function

   Private Function Versiones_G(idAplicacion As String, versionDesde As String, versionHasta As String, top As Integer, groupByNroVersion As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, top)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idAplicacion) Then
            If idAplicacion = "SIGA" Then
               .AppendFormatLine("   AND V.{0} IN ('SIGA', 'SIGA-MD', 'SILIVE')", Entidades.Version.Columnas.IdAplicacion.ToString())
            Else
               .AppendFormatLine("   AND V.{0} = '{1}'", Entidades.Version.Columnas.IdAplicacion.ToString(), idAplicacion)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(versionDesde) Then
            .AppendFormatLine("   AND V.{0} >= '{1}'", Entidades.Version.Columnas.NroVersion.ToString(), versionDesde)
         End If
         If Not String.IsNullOrWhiteSpace(versionDesde) Then
            .AppendFormatLine("   AND V.{0} <= '{1}'", Entidades.Version.Columnas.NroVersion.ToString(), versionHasta)
         End If

         If groupByNroVersion Then
            '.AppendLine(" GROUP BY V.nroversion")
         End If

         .AppendLine(" ORDER BY CAST(replace(replace(V.nroversion,'.',''),',','') AS bigint) DESC")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Versiones_GA(groupByNroVersion As Boolean) As DataTable
      Return Versiones_G(idAplicacion:=String.Empty, versionDesde:=String.Empty, versionHasta:=String.Empty, top:=CantidadSinTop, groupByNroVersion:=groupByNroVersion)
   End Function

   Public Function Versiones_GA(idAplicacion As String, groupByNroVersion As Boolean) As DataTable
      Return Versiones_G(idAplicacion, versionDesde:=String.Empty, versionHasta:=String.Empty, top:=CantidadSinTop, groupByNroVersion:=groupByNroVersion)
   End Function

   Public Function Versiones_G1(idAplicacion As String, version As String) As DataTable
      Return Versiones_G(idAplicacion, version, versionHasta:=version, top:=CantidadSinTop, groupByNroVersion:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = String.Concat("V.", columna)
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, top:=CantidadSinTop)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetUltimaPorAplicacion(idAplicacion As String) As DataTable
      Return Versiones_G(idAplicacion, versionDesde:=String.Empty, versionHasta:=String.Empty, top:=1, groupByNroVersion:=False)
   End Function

End Class
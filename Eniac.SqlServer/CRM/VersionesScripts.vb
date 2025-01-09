Public Class VersionesScripts
   Inherits Comunes

   Private Const CantidadSinTop As Integer = 0

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VersionesScripts_I(idAplicacion As String,
                                 nroVersion As String,
                                 orden As Integer,
                                 nombre As String,
                                 script As String,
                                 obligatorio As Boolean,
                                 codigoCliente As Long)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO VersionesScripts")
         .AppendFormatLine("           ([IdAplicacion]")
         .AppendFormatLine("           ,[NroVersion]")
         .AppendFormatLine("           ,[Orden]")
         .AppendFormatLine("           ,[Nombre]")
         .AppendFormatLine("           ,[Script]")
         .AppendFormatLine("           ,[Obligatorio]")
         .AppendFormatLine("           ,[CodigoCliente]")
         .AppendFormatLine(")     VALUES (")
         .AppendFormatLine("            '{0}'", idAplicacion)
         .AppendFormatLine("           ,'{0}'", nroVersion)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", nombre)
         .AppendFormatLine("           ,@script")
         .AppendFormatLine("           ,'{0}'", obligatorio)
         If codigoCliente <> 0 Then
            .AppendFormatLine("           , {0} ", codigoCliente)
         Else
            .AppendFormatLine("           ,NULL")
         End If
         .AppendFormatLine(")")

      End With

      ''Aquí defino el parámetro
      _da.Command.CommandText = myQuery.ToString()
      _da.Command.CommandType = CommandType.Text
      Dim oParameter = _da.Command.CreateParameter()
      oParameter.ParameterName = "@script"
      oParameter.DbType = DbType.String
      oParameter.Size = script.Length
      oParameter.Value = script
      _da.Command.Parameters.Add(oParameter)
      _da.Command.Connection = _da.Connection

      ''Execute(myQuery)
      _da.ExecuteNonQuery(_da.Command)
   End Sub

   Public Sub VersionesScripts_U(idAplicacion As String,
                                 nroVersion As String,
                                 orden As Integer,
                                 nombre As String,
                                 script As String,
                                 obligatorio As Boolean,
                                 codigoCliente As Long)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE VersionesScripts")
         .AppendFormatLine("   SET ")
         .AppendFormatLine("      [Nombre] = '{0}'", nombre)
         .AppendFormatLine("      ,[Script] = @script")
         .AppendFormatLine("      ,[Obligatorio] = {0}", GetStringFromBoolean(obligatorio))
         If codigoCliente <> 0 Then
            .AppendFormatLine("      ,[CodigoCliente] = {0}", codigoCliente)
         Else
            .AppendFormatLine("      ,[CodigoCliente] = NULL")
         End If
         .AppendFormatLine(" WHERE [IdAplicacion] = '{0}' ", idAplicacion)
         .AppendFormatLine(" AND [NroVersion] = '{0}' ", nroVersion)
         .AppendFormatLine(" AND [Orden] = {0} ", orden)

      End With

      ''Aquí defino el parámetro
      _da.Command.CommandText = myQuery.ToString()
      _da.Command.CommandType = CommandType.Text
      Dim oParameter = _da.Command.CreateParameter()
      oParameter.ParameterName = "@script"
      oParameter.DbType = DbType.String
      oParameter.Size = script.Length
      oParameter.Value = script
      _da.Command.Parameters.Add(oParameter)
      _da.Command.Connection = _da.Connection

      ''Execute(myQuery)
      _da.ExecuteNonQuery(_da.Command)
   End Sub

   Public Sub VersionesScripts_D(idAplicacion As String, Version As String, orden As Integer)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM VersionesScripts")
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.VersionScript.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VersionScript.Columnas.NroVersion.ToString(), Version)
         .AppendFormatLine("   AND {0} = {1}", Entidades.VersionScript.Columnas.Orden.ToString(), orden)
      End With

      Execute(myQuery)
   End Sub
   Public Sub VersionesScripts_D_Rango(idAplicacion As String, versionDesde As String, versionHasta As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM VersionesScripts")
         .AppendFormatLine(" WHERE {0}  = '{1}'", Entidades.VersionScript.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} >= '{1}'", Entidades.VersionScript.Columnas.NroVersion.ToString(), versionDesde)
         .AppendFormatLine("   AND {0} <= '{1}'", Entidades.VersionScript.Columnas.NroVersion.ToString(), versionHasta)
      End With

      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, top As Integer)
      With stb
         'Si requiere traer un TOP (por ejemplo TOP 1) el parametro top será mayor a 0, entonces lo agrego al query
         'Si NO requiere traer un TOP el parametro top será 0, y NO lo agrego al query
         Dim strTop = If(top = CantidadSinTop, String.Empty, String.Format("TOP {0} ", top))
         .AppendFormatLine("SELECT {0}V.IdAplicacion", strTop)
         .AppendFormatLine("     , V.NroVersion")
         .AppendFormatLine("     , V.Orden")
         .AppendFormatLine("     , V.Nombre")
         .AppendFormatLine("     , V.Script")
         .AppendFormatLine("     , V.Obligatorio")
         .AppendFormatLine("     , V.CodigoCliente")
         .AppendFormatLine("  FROM VersionesScripts V")
      End With
   End Sub
   Public Function GetOrdenMaximo(idAplicacion As String, version As String) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.VersionScript.Columnas.Orden.ToString(), "VersionesScripts",
                                             String.Format("{0} = '{1}' AND {2} = '{3}'",
                                                           Entidades.VersionScript.Columnas.IdAplicacion.ToString(), idAplicacion,
                                                           Entidades.VersionScript.Columnas.NroVersion.ToString(), version)))
   End Function
   Private Function VersionesScripts_G(idAplicacion As String, versionDesde As String, versionHasta As String, orden As Integer, top As Integer, nombre As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, top)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idAplicacion) Then
            .AppendFormatLine("   AND V.{0} = '{1}'", Entidades.VersionScript.Columnas.IdAplicacion.ToString(), idAplicacion)
         End If
         If Not String.IsNullOrWhiteSpace(versionDesde) Then
            .AppendFormatLine("   AND V.{0} >= '{1}'", Entidades.VersionScript.Columnas.NroVersion.ToString(), versionDesde)
         End If
         If Not String.IsNullOrWhiteSpace(versionHasta) Then
            .AppendFormatLine("   AND V.{0} <= '{1}'", Entidades.VersionScript.Columnas.NroVersion.ToString(), versionHasta)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND V.{0} = {1}", Entidades.VersionScript.Columnas.Orden.ToString(), orden)
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormatLine("   AND V.{0} = '{1}'", Entidades.VersionScript.Columnas.Nombre.ToString(), nombre)
         End If

         .AppendLine(" ORDER BY CAST(replace(replace(V.nroversion,'.',''),',','') AS bigint) DESC")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Versiones_GA() As DataTable
      Return VersionesScripts_G(idAplicacion:=String.Empty, versionDesde:=String.Empty, versionHasta:=String.Empty, orden:=0, top:=CantidadSinTop, nombre:=String.Empty)
   End Function

   Public Function Versiones_GA(idAplicacion As String) As DataTable
      Return VersionesScripts_G(idAplicacion, versionDesde:=String.Empty, versionHasta:=String.Empty, orden:=0, top:=CantidadSinTop, nombre:=String.Empty)
   End Function
   Public Function ExisteScriptPorNombre(idAplicacion As String, nombre As String) As DataTable
      Return VersionesScripts_G(idAplicacion, versionDesde:=String.Empty, versionHasta:=String.Empty, orden:=0, top:=0, nombre:=nombre)
   End Function
   Public Function ExisteScriptPorOrden(idAplicacion As String, nroVersion As String, orden As Integer) As DataTable
      Return VersionesScripts_G(idAplicacion, versionDesde:=nroVersion, versionHasta:=nroVersion, orden:=orden, top:=0, nombre:=String.Empty)
   End Function
   Public Function Versiones_G1(idAplicacion As String, versionDesde As String, orden As Integer) As DataTable
      Return VersionesScripts_G(idAplicacion, versionDesde, versionDesde, orden, top:=CantidadSinTop, nombre:="")
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "V." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, top:=CantidadSinTop)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetUltimaPorAplicacion(idAplicacion As String) As DataTable
      Return VersionesScripts_G(idAplicacion, versionDesde:=String.Empty, versionHasta:=String.Empty, orden:=0, top:=1, nombre:="")
   End Function

   Public Function GetxAplicacionVersion(idAplicacion As String, nroVersionDesde As String, nroVersionHasta As String) As DataTable
      Return VersionesScripts_G(idAplicacion, nroVersionDesde, nroVersionHasta, orden:=0, top:=0, nombre:="")
   End Function

   ''' <summary>
   ''' Ejecutar cualquier script
   ''' </summary>
   ''' <param name="script"></param>
   ''' <returns>Cantidad de registros afectados.</returns>
   ''' <remarks></remarks>
   Public Function EjecutarScript(script As String) As Integer
      Return ExecuteLimpio(script)
   End Function

   Public Sub EliminarScriptsVersion(idAplicacion As String, versiones As String())
      Dim myQuery = New StringBuilder()
      Dim cons = String.Empty
      For Each vs In versiones
         cons += "'" + vs + "', "
      Next
      cons = cons.Substring(0, cons.Length - 2)

      With myQuery
         .AppendFormatLine("DELETE FROM VersionesScripts ")
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.VersionScript.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} IN ({1})", Entidades.VersionScript.Columnas.NroVersion.ToString(), cons)
      End With

      Execute(myQuery)
   End Sub

   Public Function GetScriptsAEjecutar(idAplicacion As String, desde As Version, hasta As Version) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, top:=0)
         .AppendFormat(" WHERE V.IdAplicacion = '{0}'", idAplicacion.Trim())
         .AppendFormat("   AND NroVersion between '{0}.{1}.{2}.{3}'",
                               desde.Major.ToString("00"),
                               desde.Minor.ToString("00"),
                               desde.Build.ToString("00"),
                               desde.Revision.ToString("0"))
         .AppendFormat("   AND '{0}.{1}.{2}.{3}'",
                               hasta.Major.ToString("00"),
                               hasta.Minor.ToString("00"),
                               hasta.Build.ToString("00"),
                               hasta.Revision.ToString("0"))

         .AppendLine(" ORDER BY idAplicacion, CAST(replace(replace(V.nroversion,'.',''),',','') AS bigint) ASC")
      End With
      Return GetDataTable(myQuery)
   End Function

End Class
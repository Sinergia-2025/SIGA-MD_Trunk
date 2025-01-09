Public Class VersionesScriptsEjecuciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Function GetScript(script As String) As String
      script = script.Replace("'", "''")

      Return script
   End Function

   Private Function GetScriptAcotado(script As String, caracteres As Integer) As String
      script = script.Replace("'", "''")

      If script.Length > caracteres Then
         script = script.Substring(0, caracteres)
      End If

      Return script
   End Function


   Public Sub VersionesScriptsEjecuciones_I(idAplicacion As String,
                                        nroVersion As String,
                                        orden As Integer,
                                        codigoCliente As Long,
                                        base As String,
                                        nombre As String,
                                        script As String,
                                        obligatorio As Boolean,
                                        exitoso As Boolean,
                                        mensaje As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO [VersionesScriptsEjecuciones]")
         .Append("           ([IdAplicacion]")
         .Append("           ,[NroVersion]")
         .Append("           ,[Orden]")
         .Append("           ,[CodigoCliente]")
         .Append("           ,[Base]")
         .Append("           ,[Nombre]")
         .Append("           ,[Script]")
         .Append("           ,[Obligatorio]")
         .Append("           ,[FechaEjecucion]")
         .Append("           ,[Exitoso]")
         .Append("           ,[Mensaje]")
         .AppendLine(")     VALUES (")
         .AppendFormatLine("           '{0}'", idAplicacion)
         .AppendFormatLine("           ,'{0}'", nroVersion)
         .AppendFormatLine("           ,{0}", orden)
         .AppendFormatLine("           ,{0}", codigoCliente)
         .AppendFormatLine("           ,'{0}'", base)
         .AppendFormatLine("           ,'{0}'", nombre)
         .AppendFormatLine("           ,'{0}'", Me.GetScript(script))
         .AppendFormatLine("           ,'{0}'", obligatorio)
         .AppendFormatLine("           ,'{0}'", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormatLine("           ,'{0}'", Me.GetStringFromBoolean(exitoso))
         .AppendFormatLine("           ,'{0}'", Me.GetScriptAcotado(mensaje, 200))
         .Append(")")

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EliminarTodaLaVersion(idAplicacion As String, versiones As String(), codigoCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      Dim cons As String = ""
      For Each vs As String In versiones
         cons += "'" + vs + "', "
      Next
      cons = cons.Substring(0, cons.Length - 2)

      With myQuery
         .AppendFormatLine("DELETE FROM VersionesScriptsEjecuciones ")
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.VersionScriptEjecucion.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} IN ({1})", Entidades.VersionScriptEjecucion.Columnas.NroVersion.ToString(), cons)
         .AppendFormatLine("   AND {0} = {1}", Entidades.VersionScriptEjecucion.Columnas.CodigoCliente.ToString(), codigoCliente)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function ElScriptYaFueEjecutado(idAplicacion As String, version As String, orden As Integer) As Boolean
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT * FROM VersionesScriptsEjecuciones ")
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.VersionScriptEjecucion.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VersionScriptEjecucion.Columnas.NroVersion.ToString(), version)
         .AppendFormatLine("   AND {0} = {1}", Entidades.VersionScriptEjecucion.Columnas.Orden.ToString(), orden)
      End With
      Dim dt As DataTable
      dt = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function


End Class

Option Strict Off
Imports System.Text.RegularExpressions

Public Class ScriptsAdmin

   Public Shared Function SplitSqlStatements(ByVal sqlScript As String) As IEnumerable(Of String)
      Dim statements As IEnumerable(Of String) = Regex.Split(sqlScript, "^[\t\r\n]*GO[\t\r\n]*\d*[\t\r\n]*(?:--.*)?$", RegexOptions.Multiline Or RegexOptions.IgnorePatternWhitespace Or RegexOptions.IgnoreCase)
      If statements.Count <= 1 Then
         Return statements
      Else
         Return statements.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).[Select](Function(x) x.Trim(" "c, vbCr, vbLf))
      End If
   End Function

   Public Function EjecutarScrips(datos As DataTable) As List(Of Entidades.VersionScriptEjecucion)

      'revisa script x script para ver si se puede ejecutar.
      Dim reg As Reglas.VersionesScripts
      reg = New Reglas.VersionesScripts()

      Dim ent As Entidades.VersionScript
      Dim scriptsAEje As List(Of Entidades.VersionScript)
      scriptsAEje = New List(Of Entidades.VersionScript)()

      'creo un objeto de scripts desde la grilla de datos
      For Each dr As DataRow In datos.Rows
         ent = New Entidades.VersionScript()
         ent.Aplicacion.IdAplicacion = dr(Entidades.VersionScriptEjecucion.Columnas.IdAplicacion.ToString()).ToString()
         ent.Nombre = dr("Nombre").ToString()
         ent.Version.NroVersion = dr(Entidades.VersionScriptEjecucion.Columnas.NroVersion.ToString()).ToString()
         ent.Orden = Int32.Parse(dr(Entidades.VersionScriptEjecucion.Columnas.Orden.ToString()).ToString())
         ent.Script = dr("Script").ToString()
         scriptsAEje.Add(ent)
      Next

      'Return reg.TestearScripts(scriptsAEje)
      Throw New NotImplementedException("No está implementada la ejecución de prueba de los scripts")

   End Function

End Class

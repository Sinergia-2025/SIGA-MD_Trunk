Public Class ParametrosArchivos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ParametrosArchivos_I(idEmpresa As Integer, idParametroArchivo As String, valorParametroArchivo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ParametrosArchivos  ")
         .AppendFormatLine("    (IdEmpresa, IdParametroArchivo, ValorParametroArchivo) ")
         .AppendFormatLine(" VALUES ")
         .AppendFormatLine("    ({0}, '{1}', '{2}')", idEmpresa, idParametroArchivo, valorParametroArchivo)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub ParametrosArchivos_D(idEmpresa As Integer, idParametro As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM ParametrosArchivos")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametroArchivo = '{0}'", idParametro)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ParametrosArchivos_U01(idEmpresa As Integer, idParametro As String, valorParametro As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE ParametrosArchivos  ")
         .AppendFormatLine("   SET ValorParametroArchivo = '{0}'", valorParametro)

         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametroArchivo = '{0}'", idParametro)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PA.*")
         .AppendFormatLine("  FROM ParametrosArchivos PA")
      End With
   End Sub

   Public Function ParametrosArchivos_GA(idEmpresa As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE PA.IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine(" ORDER BY PA.IdParametroArchivo")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Sub ActualizaTA(idEmpresa As Integer, idParametroArchivo As String, valorParametroArchivo As String)
      If Me.Existe(idEmpresa, idParametroArchivo) Then
         Me.ParametrosArchivos_U01(idEmpresa, idParametroArchivo, valorParametroArchivo)
      Else
         Me.ParametrosArchivos_I(idEmpresa, idParametroArchivo, valorParametroArchivo)
      End If
   End Sub

   Public Function Existe(idEmpresa As Integer, idParametro As String) As Boolean
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE PA.IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND PA.IdParametroArchivo = '{0}'", idParametro)
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Function GetValor(idEmpresa As Integer, idParametro As String) As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE PA.IdEmpresa = {0}", idEmpresa)
         .AppendFormat("   AND PA.IdParametroArchivo = '{0}'", idParametro.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0)("ValorParametroArchivo").ToString().Trim()
      Else
         Throw New Exception(String.Format("NO existe el Parametro '{0}' para la empresa {1} y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.",
                                           idParametro.ToUpper.Trim(), idEmpresa))
      End If
   End Function

   Public Function GetValor2(idEmpresa As Integer, idParametro As String) As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE PA.IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND PA.IdParametroArchivo = '{0}'", idParametro.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0)("ValorParametroArchivo").ToString().Trim()
      Else
         Return String.Empty
      End If
   End Function

   Public Function Buscar(columna As String, valor As String, idEmpresa As Integer) As DataTable
      'If columna = "NombreVendedor" Then
      '   columna = "E.NombreEmpleado"
      'Else
      columna = "PA." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
         .AppendFormatLine("   AND PA.IdEmpresa = {0}", idEmpresa)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
Public Class Plantillas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Plantillas_I(ByVal IdPlantilla As Integer,
                           ByVal NombrePlantilla As String,
                           ByVal IdProveedor As Long,
                           ByVal FilaInicial As Integer, _
                           ByVal Sistema As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("INSERT INTO  ")
         .AppendLine("Plantillas ")
         .AppendLine("(IdPlantilla, ")
         .AppendLine("NombrePlantilla, ")
         .AppendLine("IdProveedor,")
         .AppendLine("FilaInicial,")
         .AppendLine("Sistema")
         .AppendLine(") VALUES (")
         .AppendLine(IdPlantilla & ", ")
         .AppendLine("'" & NombrePlantilla & "',")
         If IdProveedor > 0 Then
            .AppendLine(IdProveedor & ", ")
         Else
            .AppendLine("NULL, ")
         End If
         .AppendLine(FilaInicial & ", ")
         .AppendLine("'" & Sistema & "')")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Plantillas")
   End Sub

   Public Sub Plantillas_U(ByVal IdPlantilla As Integer, _
                           ByVal NombrePlantilla As String, _
                           ByVal IdProveedor As Long,
                           ByVal FilaInicial As Integer, _
                           ByVal Sistema As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("UPDATE  ")
         .AppendLine("Plantillas ")
         .AppendLine("SET  ")
         .AppendLine("NombrePlantilla = '" & NombrePlantilla & "',")
         If IdProveedor > 0 Then
            .AppendLine("IdProveedor = " & IdProveedor.ToString() & ",")
         Else
            .AppendLine("IdProveedor = NULL ,")
         End If

         .AppendLine("FilaInicial = " & FilaInicial & ",")
         .AppendLine("Sistema = '" & Sistema & "'")
         .AppendLine(" WHERE ")
         .AppendLine("IdPlantilla = " & IdPlantilla)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Plantillas")
   End Sub

   Public Sub Plantillas_D(ByVal IdPlantilla As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM Plantillas ")
         .AppendLine("  WHERE IdPlantilla = " & IdPlantilla.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Plantillas")
   End Sub

   Public Function Plantillas_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantilla, ")
         .AppendLine("P.NombrePlantilla, ")
         .AppendLine("P.IdProveedor, ")
         .AppendLine("Pr.NombreProveedor,")
         .AppendLine("P.FilaInicial,  ")
         .AppendLine("P.Sistema  ")
         .AppendLine("FROM Plantillas P")
         .AppendLine(" LEFT JOIN Proveedores Pr ON Pr.IdProveedor = P.IdProveedor ")
         .AppendLine("ORDER BY P.IdPlantilla ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Plantillas_G1(ByVal IdPlantilla As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantilla, ")
         .AppendLine("P.NombrePlantilla, ")
         .AppendLine("P.IdProveedor, ")
         .AppendLine("Pr.NombreProveedor,")
         .AppendLine("P.FilaInicial,  ")
         .AppendLine("P.Sistema  ")
         .AppendLine("FROM Plantillas P")
         .AppendLine(" LEFT JOIN Proveedores Pr ON Pr.IdProveedor = P.IdProveedor ")
         .AppendFormat("WHERE P.IdPlantilla = '{0}' ", IdPlantilla)
         .AppendLine("ORDER BY P.IdPlantilla ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetProximoId() As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendFormat(" SELECT MAX(IdPlantilla) AS PROXIMO FROM Plantillas ")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("PROXIMO").ToString()) Then
            Return Int32.Parse(dt.Rows(0)("PROXIMO").ToString()) + 1
         Else
            Return 1
         End If
      Else
         Return 1
      End If

   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = "NombreProveedor" Then
         columna = "Pr." + columna
      Else
         columna = "P." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantilla, ")
         .AppendLine("P.NombrePlantilla, ")
         .AppendLine("P.IdProveedor, ")
         .AppendLine("Pr.NombreProveedor,")
         .AppendLine("P.FilaInicial,  ")
         .AppendLine("P.Sistema  ")
         .AppendLine("FROM Plantillas P")
         .AppendLine(" LEFT JOIN Proveedores Pr ON Pr.IdProveedor = P.IdProveedor ")
         .AppendLine("  WHERE " & columna & " LIKE '%" & valor & "%'")
         .AppendLine("ORDER BY P.IdPlantilla ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorCodigo(codigoPlantilla As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantilla, ")
         .AppendLine("P.NombrePlantilla, ")
         .AppendLine("P.IdProveedor, ")
         .AppendLine("Pr.CodigoProveedor,")
         .AppendLine("Pr.NombreProveedor,")
         .AppendLine("P.FilaInicial,  ")
         .AppendLine("P.Sistema  ")
         .AppendLine("FROM Plantillas P")
         .AppendLine(" LEFT JOIN Proveedores Pr ON Pr.IdProveedor = P.IdProveedor ")
         If codigoPlantilla.HasValue AndAlso codigoPlantilla.Value > -1 Then
            .AppendFormat(" WHERE IdPlantilla = {0}", codigoPlantilla.Value)
         End If
         .AppendLine("ORDER BY P.IdPlantilla ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorProveedor(IdProveedor As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantilla, ")
         .AppendLine("P.NombrePlantilla, ")
         .AppendLine("P.IdProveedor, ")
         .AppendLine("Pr.CodigoProveedor,")
         .AppendLine("Pr.NombreProveedor,")
         .AppendLine("P.FilaInicial,  ")
         .AppendLine("P.Sistema  ")
         .AppendLine("FROM Plantillas P")
         .AppendLine(" LEFT JOIN Proveedores Pr ON Pr.IdProveedor = P.IdProveedor ")
         If IdProveedor.HasValue Then
            .AppendFormat(" WHERE P.IdProveedor = {0}", IdProveedor.Value)
         End If
         .AppendLine("ORDER BY P.IdPlantilla ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorNombre(NombrePlantilla As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantilla, ")
         .AppendLine("P.NombrePlantilla, ")
         .AppendLine("P.IdProveedor, ")
         .AppendLine("Pr.CodigoProveedor,")
         .AppendLine("Pr.NombreProveedor,")
         .AppendLine("P.FilaInicial,  ")
         .AppendLine("P.Sistema  ")
         .AppendLine("FROM Plantillas P")
         .AppendLine(" LEFT JOIN Proveedores Pr ON Pr.IdProveedor = P.IdProveedor ")
         If NombrePlantilla <> "" Then
            .AppendFormat(" WHERE NombrePlantilla LIKE '%{0}%'", NombrePlantilla)
         End If
         .AppendLine("ORDER BY P.IdPlantilla ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
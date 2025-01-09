Public Class PlantillasCalidad
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadPlantillas_I(ByVal IdPlantilla As Integer,
                           ByVal NombrePlantilla As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("INSERT INTO  ")
         .AppendLine("CalidadPlantillas ")
         .AppendLine("(IdPlantillaCalidad, ")
         .AppendLine("NombrePlantillaCalidad ")
         .AppendLine(") VALUES (")
         .AppendLine(IdPlantilla & ", ")
         .AppendLine("'" & NombrePlantilla & "')")

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadPlantillas")
   End Sub

   Public Sub CalidadPlantillas_U(ByVal IdPlantilla As Integer, _
                           ByVal NombrePlantilla As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("UPDATE  ")
         .AppendLine("CalidadPlantillas ")
         .AppendLine("SET  ")
         .AppendLine("NombrePlantillaCalidad = '" & NombrePlantilla & "'")
         .AppendLine(" WHERE ")
         .AppendLine("IdPlantillaCalidad = " & IdPlantilla)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadPlantillas")
   End Sub

   Public Sub CalidadPlantillas_D(ByVal IdPlantilla As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CalidadPlantillas ")
         .AppendLine("  WHERE IdPlantillaCalidad = " & IdPlantilla.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadPlantillas")
   End Sub

   Public Function CalidadPlantillas_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantillaCalidad, ")
         .AppendLine("P.NombrePlantillacalidad ")
         .AppendLine("FROM CalidadPlantillas P")
         .AppendLine("ORDER BY P.IdPlantillaCalidad ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CalidadPlantillas_G1(ByVal IdPlantilla As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantillaCalidad, ")
         .AppendLine("P.NombrePlantillaCalidad ")
         .AppendLine("FROM CalidadPlantillas P")
         .AppendFormat("WHERE P.IdPlantillaCalidad = {0} ", IdPlantilla)
         .AppendLine("ORDER BY P.IdPlantillaCalidad ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetProximoId() As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendFormat(" SELECT MAX(IdPlantillaCalidad) AS PROXIMO FROM CalidadPlantillas ")
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
    
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantillaCalidad, ")
         .AppendLine("P.NombrePlantillaCalidad, ")
         .AppendLine("FROM CalidadPlantillas P")
         .AppendLine("  WHERE " & columna & " LIKE '%" & valor & "%'")
         .AppendLine("ORDER BY P.IdPlantillaCalidad ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorCodigo(codigoPlantilla As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantillaCalidad, ")
         .AppendLine("P.NombrePlantillaCalidad, ")
         .AppendLine("FROM CalidadPlantillas P")
         If codigoPlantilla.HasValue AndAlso codigoPlantilla.Value > -1 Then
            .AppendFormat(" WHERE IdPlantillaCalidad = {0}", codigoPlantilla.Value)
         End If
         .AppendLine("ORDER BY P.IdPlantillaCalidad ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function GetFiltradoPorNombre(NombrePlantilla As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT  ")
         .AppendLine("P.IdPlantillaCalidad, ")
         .AppendLine("P.NombrePlantillaCalidad ")
         .AppendLine("FROM CalidadPlantillas P")
         If NombrePlantilla <> "" Then
            .AppendFormat(" WHERE NombrePlantillaCalidad LIKE '%{0}%'", NombrePlantilla)
         End If
         .AppendLine("ORDER BY P.IdPlantillaCalidad ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
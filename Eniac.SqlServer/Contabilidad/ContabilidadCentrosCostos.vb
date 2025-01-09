Public Class ContabilidadCentrosCostos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CentrosCostos_I(ByVal IdCentroCosto As Integer, _
                                 ByVal NombreCentroCosto As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("INSERT INTO ContabilidadCentrosCostos")
         .AppendLine("   (IdCentroCosto")
         .AppendLine("   ,NombreCentroCosto")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & IdCentroCosto.ToString())
         .AppendLine("   ,'" & NombreCentroCosto & "'")
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub CentrosCostos_U(ByVal IdCentroCosto As Integer, _
                                  ByVal NombreCentroCosto As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("UPDATE ContabilidadCentrosCostos SET ")
         .AppendLine("   NombreCentroCosto = '" & NombreCentroCosto & "'")
         .AppendLine(" WHERE IdCentroCosto = " & IdCentroCosto.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub CentrosCostos_D(ByVal IdCentroCosto As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM ContabilidadCentrosCostos")
         .AppendLine(" WHERE IdCentroCosto = " & IdCentroCosto.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT CC.* ")
         .AppendLine(" FROM ContabilidadCentrosCostos CC")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "CC." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CentrosCostos_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY CC.NombreCentroCosto")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CentrosCostos_G1(ByVal IdCentroCosto As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE IdCentroCosto = " & IdCentroCosto.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorCodigoNombre(idCentroCosto As Integer?, nombreCentroCosto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendFormat("   AND CC.IdCentroCosto = {0}", idCentroCosto.Value)
         End If
         If Not String.IsNullOrWhiteSpace(nombreCentroCosto) Then
            .AppendFormat("   AND CC.NombreCentroCosto LIKE '%{0}%'", nombreCentroCosto)
         End If
         If String.IsNullOrWhiteSpace(nombreCentroCosto) AndAlso idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendLine(" ORDER BY CC.IdCentroCosto")
         Else
            .AppendLine(" ORDER BY CC.NombreCentroCosto")
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CentrosCosto_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdCentroCosto) AS maximo ")
         .AppendLine(" FROM ContabilidadCentrosCostos")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class

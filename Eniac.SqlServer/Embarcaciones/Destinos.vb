Public Class Destinos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function Destinos_GA() As DataTable
      Return Destinos_G()
   End Function

   Public Function GetParaMovil() As DataTable
      Return Destinos_G()
   End Function
   Public Function Destinos_G1(ByVal IdDestino As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE D." & Entidades.Destino.Columnas.IdDestino.ToString() & " = " & IdDestino.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Private Function Destinos_G() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT D.*")
         .AppendFormatLine("  FROM Destinos D")
         .AppendFormatLine(" ORDER BY D.{0}", Entidades.Destino.Columnas.NombreDestino)

      End With
      Return GetDataTable(stb.ToString())
   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT D." & Entidades.Destino.Columnas.IdDestino.ToString())
         .AppendLine("      ,D." & Entidades.Destino.Columnas.NombreDestino.ToString())
         .AppendLine("      ,D." & Entidades.Destino.Columnas.EsLibre.ToString())
         .AppendLine("  FROM Destinos D")
      End With
   End Sub
   Public Sub Destinos_I(ByVal en As Eniac.Entidades.Destino)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO Destinos ")
         .AppendLine("   (" & Entidades.Destino.Columnas.IdDestino.ToString())
         .AppendLine("   ," & Entidades.Destino.Columnas.NombreDestino.ToString())
         .AppendLine("   ," & Entidades.Destino.Columnas.EsLibre.ToString())
         .AppendLine(" ) VALUES (")
         .AppendLine(en.IdDestino.ToString)
         .AppendLine("  ,'" & en.NombreDestino & "'")
         .AppendLine("  ,'" & en.EsLibre & "'")
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Destinos")

   End Sub

   Public Sub Destinos_U(ByVal en As Eniac.Entidades.Destino)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Destinos ")
         .AppendLine("   SET " & Entidades.Destino.Columnas.NombreDestino.ToString() & " = '" & en.NombreDestino & "'")
         .AppendLine("      ," & Entidades.Destino.Columnas.EsLibre.ToString() & " = '" & en.EsLibre.ToString() & "'")
         .AppendLine(" WHERE " & Entidades.Destino.Columnas.IdDestino.ToString() & " = " & en.IdDestino.ToString)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Destinos")

   End Sub

   Public Sub Destinos_D(ByVal idDestino As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM Destinos ")
         .AppendLine(" WHERE " & Entidades.Destino.Columnas.IdDestino.ToString() & " = " & idDestino.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Destinos")

   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "D." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class